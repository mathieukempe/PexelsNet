using System;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace PexelsNet
{
    public class PexelsClient
    {
        private readonly string _apiKey;
        private const string BaseUrl = "http://api.pexels.com/v1/";

        public PexelsClient(string apiKey)
        {
            _apiKey = apiKey;
        }

        private HttpClient InitHttpClient()
        {
            var client = new HttpClient();

            client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", _apiKey);

            return client;
        }

        public async Task<Page> SearchAsync(string query, int page = 1, int perPage = 15)
        {
            var client = InitHttpClient();

            HttpResponseMessage response = await client.GetAsync(BaseUrl + "search?query=" + Uri.EscapeDataString(query) + "&per_page=" + perPage + "&page=" + page);

            return await GetResultAsync(response).ConfigureAwait(false);
        }

        public async Task<Page> PopularAsync(int page = 1, int perPage = 15)
        {
            var client = InitHttpClient();

            HttpResponseMessage response = await client.GetAsync(BaseUrl + "popular?per_page=" + perPage + "&page=" + page).ConfigureAwait(false);

            return await GetResultAsync(response).ConfigureAwait(false);
        }

        private static async Task<Page> GetResultAsync(HttpResponseMessage response)
        {
            var body = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            response.EnsureSuccessStatusCode();

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<Page>(body);
            }

            throw new PexelsNetException(response.StatusCode, body);
        }
    }
}
