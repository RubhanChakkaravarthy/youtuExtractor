using System.Collections.Generic;
using System.Globalization;
using System.Net.Http;
using System.Text.Json.Nodes;
using System.Threading;
using System.Threading.Tasks;

using Extractor.Utilities;

namespace Extractor.PageExtractors
{
	public abstract class PageExtractor
	{
		protected static string ApiKey
		{
			// TODO Change this logic to retrieve it dynamically
			get => Constants.DefaultApiKey;
		}

		protected HttpClient Client { get; }
		protected CultureInfo Culture { get; }

		public PageExtractor(HttpClient client, CultureInfo culture)
		{
			Client = client;
			Culture = culture;
		}

		public PageExtractor(HttpClient client) : this(client, Thread.CurrentThread.CurrentCulture) { }

		protected async Task<JsonObject> FetchContinuationDataAsync(string endpoint, string continuationToken)
		{
			using (var request = new HttpRequestMessage(HttpMethod.Post, RequestHelpers.GetYoutubeV1Uri(endpoint, ApiKey)))
            {
                request.AddYoutubeV1Headers()
                    .AddYoutubeV1EndpointBody(Culture, new Dictionary<string, JsonNode> { { "continuation", continuationToken } });

                using (var response = await Client.SendAsync(request))
                {
                    response.EnsureSuccessStatusCode();
                    return await response.Content.DeserializeAsync<JsonObject>();
                }
            }
		}
	}
}
