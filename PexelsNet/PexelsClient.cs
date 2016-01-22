using System;
using System.Net;
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
            string body = response.Content.ReadAsStringAsync().Result;

            response.EnsureSuccessStatusCode();

            if (response.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<Page>(body);
                return result;
            }

            throw new PexelsNetException(response.StatusCode, body);
        }

        
    }
}
