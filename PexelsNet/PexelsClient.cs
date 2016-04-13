using System;
using System.Net.Http;
using Newtonsoft.Json;

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

        public Page Search(string query, int page = 1, int perPage = 15)
        {
            var client = InitHttpClient();

            HttpResponseMessage response = client.GetAsync(BaseUrl + "search?query=" + Uri.EscapeDataString(query) + "&per_page="+ perPage + "&page=" + page).Result;

            return GetResult(response);
        }

        public Page Popular(int page = 1, int perPage = 15)
        {
            var client = InitHttpClient();

            HttpResponseMessage response = client.GetAsync(BaseUrl + "popular?per_page=" + perPage + "&page=" + page).Result;

            return GetResult(response);
        }

        private static Page GetResult(HttpResponseMessage response)
        {
            var body = response.Content.ReadAsStringAsync().Result;

            response.EnsureSuccessStatusCode();

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<Page>(body);
            }

            throw new PexelsNetException(response.StatusCode, body);
        }
    }
}
