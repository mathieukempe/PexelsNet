using System;
using System.Linq;
using System.Net.Http;

namespace PexelsNet
{
    public class RateLimitParser
    {
        private readonly HttpResponseMessage responseMessage;

        public RateLimitParser(HttpResponseMessage responseMessage)
        {
            this.responseMessage = responseMessage;
        }

        public RateLimit Parse()
        {
            return new RateLimit
            {
                Limit = GetLong("X-Ratelimit-Limit"),
                Remaining = GetLong("X-Ratelimit-Remaining"),
                ResetDate = GetDateTime("X-Ratelimit-Reset")
            };
        }

        private DateTime GetDateTime(string headerName)
        {
            var unixTimeStamp = GetLong(headerName);

            return UnixTimeStamp.ToDateTime(unixTimeStamp);
        }

        private long GetLong(string headerName)
        {
            var rawValue = responseMessage.Headers.GetValues(headerName).FirstOrDefault();

            long.TryParse(rawValue, out var value);

            return value;
        }
    }
}