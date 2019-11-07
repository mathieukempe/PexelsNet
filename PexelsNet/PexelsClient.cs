using System;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace PexelsNet
{
    public class PexelsClient
    {
        private const string BaseUrl = "http://api.pexels.com/v1/";

        private readonly HttpClient _client = new HttpClient();

        public PexelsClient(string apiKey)
        {
            _client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", apiKey);
        }

        public async Task<Page> SearchAsync(string query, int page = 1, int perPage = 15)
        {
            HttpResponseMessage response = await _client.GetAsync(BaseUrl + "search?query=" + Uri.EscapeDataString(query) + "&per_page=" + perPage + "&page=" + page).ConfigureAwait(false);

            return await GetResultAsync(response).ConfigureAwait(false);
        }

        public async Task<Page> PopularAsync(int page = 1, int perPage = 15)
        {
            HttpResponseMessage response = await _client.GetAsync(BaseUrl + "popular?per_page=" + perPage + "&page=" + page).ConfigureAwait(false);

            return await GetResultAsync(response).ConfigureAwait(false);
        }

        private static async Task<Page> GetResultAsync(HttpResponseMessage response)
        {
            var body = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            response.EnsureSuccessStatusCode();

            if (response.IsSuccessStatusCode)
            {
                var page = JsonConvert.DeserializeObject<Page>(body);

                page.RateLimit = new RateLimitParser(response).Parse();

                return page;
            }

            throw new PexelsNetException(response.StatusCode, body);
        }
    }
}
