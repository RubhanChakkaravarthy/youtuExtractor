using System.Linq;
using Extractor.Models;
using System.Text.Json.Nodes;
using Extractor.ItemExtractors;
using Extractor.Exceptions;

namespace Extractor.Utilities
{
	internal static class ParsingHelpers
	{
		/// <summary>
		/// Extracts Thumbnail Info from thumbnails
		/// </summary>
		/// <param name="thumbnails">Thumbnails Object</param>
		/// <returns>ThumbnailInfo[]</returns>
		/// <exception cref="ParsingException"></exception>
		internal static ThumbnailInfo[] ParseThumbnails(JsonArray thumbnails)
		{
			return thumbnails
				.Select(t => new ThumbnailInfo {
					Url = t.Get<string>("url"),
					Width = t.Get<int>("width"),
					Height = t.Get<int>("height")
				})
				.ToArray();
		}

		/// <summary>
		/// Extracts Stream Item from richSectionRenderer
		/// </summary>
		/// <param name="richSectionRenderer">Rich Section Renderer Object</param>
		/// <returns>(title, StreamInfoExtractor[])</returns>
		/// <exception cref="ParsingException"></exception>
		internal static (string, StreamItemExtractor[]) ParseRichSectionRenderer(JsonObject richSectionRenderer)
		{
			if (richSectionRenderer.TryGetObject("content.richShelfRenderer", out var shelf))
			{
				var title = GetText(shelf.GetObject("title"));
				var contents = shelf.GetArray("contents")
					.Select(c => new StreamItemExtractor(c.GetObject("richItemRenderer.content").GetOneOf<JsonObject>(new string[] { "videoRenderer", "reelItemRenderer" })))
					.ToArray();

				return (title, contents);
			}

			return default;
		}

		/// <summary>
		/// Extracts Stream Info from ItemSectionRenderer
		/// </summary>
		/// <param name="itemSectionRenderer">Item Section Renderer Object</param>
		/// <returns>(title, StreamInfoExtractor[])</returns>
		/// <exception cref="ParsingException"></exception>
		internal static (string, StreamItemExtractor[]) ParseItemSectionRenderer(JsonObject itemSectionRenderer)
		{
			if (itemSectionRenderer.ContainsKey("contents"))
			{
				if (itemSectionRenderer.GetArray("contents").GetObject(0)
						.TryGetOneOf<JsonObject>(new string[] { "shelfRenderer", "reelShelfRenderer" }, out var shelf))
					return ParseShelfRenderer(shelf);
			}

			return default;
		}

		/// <summary>
		/// Extracts Stream Info from ShelfRenderer
		/// </summary>
		/// <param name="shelfRenderer">Shelf Renderer Object</param>
		/// <returns>(title, StreamInfoExtractor[])</returns>
		/// <exception cref="ParsingException"></exception>
		internal static (string, StreamItemExtractor[]) ParseShelfRenderer(JsonObject shelfRenderer)
		{
			StreamItemExtractor[] contents;
			if (shelfRenderer.Has("content"))
			{
				contents = shelfRenderer.GetObject("content")
					.GetOneOf<JsonObject>(new string[] { "horizontalListRenderer", "expandedShelfContentsRenderer" })
					.GetArray("items")
					.Select(i => new StreamItemExtractor(i.GetOneOf<JsonObject>(new string[] { "gridVideoRenderer", "videoRenderer" })))
					.ToArray();
			}
			else
			{
				contents = shelfRenderer.GetArray("items")
					.Select(i => new StreamItemExtractor(i.GetObject("reelItemRenderer")))
					.ToArray();
			}
			string title = null;
			if (shelfRenderer.TryGetObject("title", out var titleObj)) title = GetText(titleObj);
			return (title, contents);
		}

		/// <summary>
		/// Extracts Continuation token from ContinuationItemRenderer
		/// </summary>
		/// <param name="continuationItemRenderer">Continuation Item Renderer Object</param>
		/// <returns>Continuation token</returns>
		/// <exception cref="ParsingException"></exception>
		internal static string ParseContinuationItemRenderer(JsonObject continuationItemRenderer)
		{
			return continuationItemRenderer.Get<string>("continuationEndpoint.continuationCommand.token");
		}

		internal static string GetText(JsonObject obj)
		{
			string text;
			if (obj.Has("runs"))
				text = obj.GetArray("runs").GetObject(0).Get<string>("text");
			else obj.TryGet("simpleText", out text);

			return text;
		}

		internal static bool IsChannelVerified(JsonArray badges)
		{
			return badges.FirstOrDefault(b => b.TryGet<string>("metadataBadgeRenderer.style", out var badgeStyle) && badgeStyle == "BADGE_STYLE_TYPE_VERIFIED") != null;
		}

		internal static string GetUrl(JsonObject navigationEndpoint)
		{
			return navigationEndpoint.Get<string>("commandMetadata.webCommandMetadata.url");
		}

		internal static string GetBrowseId(JsonObject navigationEndpoint)
		{
			return navigationEndpoint.Get<string>("browseEndpoint.browseId");
		}
	}
}
