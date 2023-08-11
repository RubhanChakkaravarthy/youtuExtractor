using System;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text.Json.Nodes;
using System.Globalization;
using System.Text.Json;
using System.Linq;
using System.Collections.Generic;

using Extractor.ItemExtractors;
using Extractor.ItemCollectors;
using Extractor.Utilities;
using Extractor.Models;
using Extractor.Exceptions;
using System.IO;

namespace Extractor.PageExtractors
{
	public class HomePageExtractor : PageExtractor
	{
		private static readonly string s_browseId = "FEwhat_to_watch";
		private static readonly string s_endpoint = "browse";

		public HomePageExtractor(HttpClient client, CultureInfo culture) : base(client, culture) { }
		public HomePageExtractor(HttpClient client) : base(client) { }

		/// <summary>
		/// Fetch Initial Page Data
		/// </summary>
		/// <exception cref="HttpRequestException"></exception>
		/// <exception cref="JsonException"></exception>
		private async Task<JsonObject> FetchDataAsync()
		{
			using (var request = new HttpRequestMessage(HttpMethod.Post, RequestHelpers.GetYoutubeV1Uri(s_endpoint, ApiKey)))
			{
				request.AddYoutubeV1Headers()
					.AddYoutubeV1EndpointBody(Culture, new Dictionary<string, JsonNode> { { "browseId", s_browseId } });

				using (var response = await Client.SendAsync(request))
				{
					response.EnsureSuccessStatusCode();
					return await response.Content.DeserializeAsync<JsonObject>();
				}
			}
		}

		/// <summary>
		/// Get Home Page Contents
		/// </summary>
		/// <returns>Contents of the home page</returns>
		/// <exception cref="HttpRequestException"></exception>
		/// <exception cref="JsonException"></exception>
		/// <exception cref="ParsingException"></exception>
		public async Task<HomePageContents> GetContentsAsync()
		{
			var response = await FetchDataAsync();
			var contents = GetTabContents(GetTab(response));
			return GetPageContents(contents);
		}


		/// <summary>
		/// Get Home Page Continuation Contents
		/// </summary>
		/// <returns>Continuation Contents of the home page</returns>
		/// <exception cref="HttpRequestException"></exception>
		/// <exception cref="JsonException"></exception>
		/// <exception cref="ParsingException"></exception>
		public async Task<HomePageContents> GetContinuationContentsAsync(string continuationToken)
		{
			var response = await FetchContinuationDataAsync("browse", continuationToken);
			var contents = response.GetArray("onResponseReceivedActions").GetObject(0).GetArray("appendContinuationItemsAction.continuationItems");
			return GetPageContents(contents);
		}

		private static HomePageContents GetPageContents(JsonArray contents)
		{
			var mainItemsCollector = new StreamItemCollector();
			mainItemsCollector.Collect(contents
				.Where(c => c.Has("richItemRenderer"))
				.Select(c => new StreamItemExtractor(c.GetObject("richItemRenderer.content.videoRenderer"))));

			var pageContents = new HomePageContents {
				Items = mainItemsCollector.Items,
				Exceptions = mainItemsCollector.Exceptions
			};

			var continuation = contents.
				LastOrDefault(c => c.Has("continuationItemRenderer"));
			if (continuation != null)
				pageContents.ContinuationToken = ParsingHelpers.ParseContinuationItemRenderer(continuation.GetObject("continuationItemRenderer"));


			try
			{
				var sections = contents
					.Where(c => c.Has("richSectionRenderer"))
					.Select(c => ParsingHelpers.ParseRichSectionRenderer(c.GetObject("richSectionRenderer")))
					.Where(c => c != default);

				if (sections.Any())
				{
					pageContents.Sections = new List<ItemsSection<StreamItem>>();
					foreach (var (title, items) in sections)
					{
						var collector = new StreamItemCollector();
						collector.Collect(items);
						pageContents.Sections.Add(new ItemsSection<StreamItem> {
							Name = title,
							Items = collector.Items,
							Exceptions = collector.Exceptions
						});
					}
				}
			}
			catch (Exception ex)
			{
				if (pageContents.Exceptions == null)
					pageContents.Exceptions = new List<Exception>();

				pageContents.Exceptions.Add(new ParsingException("Unable to get \"Sections\" of home page", ex));
			}

			return pageContents;
		}

		private static JsonObject GetTab(JsonObject data)
		{
			try
			{
				var t = data.GetArray("contents.twoColumnBrowseResultsRenderer.tabs")
					.First(tab => {
						var tabRenderer = tab.GetObject("tabRenderer");
						return tabRenderer.Get<string>("tabIdentifier") == s_browseId &&
							tabRenderer.Get<bool>("selected") &&
							tabRenderer.ContainsKey("content");
					});

				return t.AsObject();
			}
			catch (InvalidOperationException ex)
			{
				throw new ParsingException("Unable to get \"What to Watch\" tab", ex);
			}
		}

		private static JsonArray GetTabContents(JsonObject tab)
		{
			try
			{
				return tab.GetArray("tabRenderer.content.richGridRenderer.contents");
			}
			catch (Exception ex)
			{
				throw new ParsingException("Unable to get \"What to Watch\" tab contents", ex);
			}
		}

	}
}
