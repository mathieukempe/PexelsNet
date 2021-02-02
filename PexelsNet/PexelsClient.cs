using System;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace PexelsNet
{
    public class PexelsClient
    {
        private const string BaseUrl = "https://api.pexels.com/v1/";

        private readonly HttpClient _client = new HttpClient();

        public PexelsClient(string apiKey)
        {
            _client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", apiKey);
        }

        public Task<Photo> GetPhotoAsync(int photoId)
        {
            return GetPhotoAsync(photoId.ToString());
        }

        public async Task<Photo> GetPhotoAsync(string photoId)
        {
            HttpResponseMessage response = await _client.GetAsync(BaseUrl + "photos/" + photoId).ConfigureAwait(false);

            return await GetResultAsync<Photo>(response).ConfigureAwait(false);
        }

        public async Task<Page> SearchAsync(string query, int page = 1, int perPage = 15)
        {
            HttpResponseMessage response = await _client.GetAsync(BaseUrl + "search?query=" + Uri.EscapeDataString(query) + "&per_page=" + perPage + "&page=" + page).ConfigureAwait(false);

            return await GetResultAsync<Page>(response).ConfigureAwait(false);
        }

        public async Task<Page> PopularAsync(int page = 1, int perPage = 15)
        {
            HttpResponseMessage response = await _client.GetAsync(BaseUrl + "popular?per_page=" + perPage + "&page=" + page).ConfigureAwait(false);

            return await GetResultAsync<Page>(response).ConfigureAwait(false);
        }

        public async Task<Page> CuratedAsync(int page = 1, int perPage = 15)
        {
            HttpResponseMessage response = await _client.GetAsync(BaseUrl + "curated?per_page=" + perPage + "&page=" + page).ConfigureAwait(false);

            return await GetResultAsync<Page>(response).ConfigureAwait(false);
        }

        private static async Task<T> GetResultAsync<T>(HttpResponseMessage response)
        {
            var body = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            response.EnsureSuccessStatusCode();

            if (response.IsSuccessStatusCode)
            {
                var resultObject = JsonConvert.DeserializeObject<T>(body);

                if (resultObject is Page page)
                    page.RateLimit = new RateLimitParser(response).Parse();

                return resultObject;
            }

            throw new PexelsNetException(response.StatusCode, body);
        }
    }
}
