using System;
using System.Globalization;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace Extractor.Utilities
{
    internal static class OtherExtensions
    {
        internal static StringContent ToJsonStringContent(this JsonObject jsonObject)
        {
            if (jsonObject == null) throw new ArgumentNullException(nameof(jsonObject));

            return new StringContent(jsonObject.ToJsonString(), System.Text.Encoding.UTF8, "application/json");
        }

        internal static async Task<T> DeserializeAsync<T>(this HttpContent content)
        {
            return await JsonSerializer.DeserializeAsync<T>(await content.ReadAsStreamAsync());
        }

        internal static string GetCountryCode(this CultureInfo culture)
        {
            return culture.Name.Split('-')?[1];
        }

#if DEVELOPMENT
		private static readonly JsonSerializerOptions s_dumpOptions = new JsonSerializerOptions {
            WriteIndented = true,
        };

        internal static void Dump(this object obj)
        {
            Console.WriteLine(JsonSerializer.Serialize(obj, s_dumpOptions));
        }
#endif
    }
}