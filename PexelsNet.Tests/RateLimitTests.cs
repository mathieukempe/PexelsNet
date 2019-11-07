using System.Net;
using System.Net.Http;
using Xunit;
using Xunit.Abstractions;

namespace PexelsNet.Tests
{
    public class RateLimitTests
    {
        private readonly ITestOutputHelper output;

        public RateLimitTests(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void CanParseRateLimitFromHttpResponseMessage()
        {
            var unixTimeStampFor_2019_04_28__14_29 = 1556458151;

            var responseMessage = new HttpResponseMessage(HttpStatusCode.OK)
                .AddHeader("X-Ratelimit-Limit", 20000)
                .AddHeader("X-Ratelimit-Remaining", 9876)
                .AddHeader("X-Ratelimit-Reset", unixTimeStampFor_2019_04_28__14_29);

            var rateLimit = new RateLimitParser(responseMessage).Parse();

            output.WriteLine(rateLimit.ToString());

            Assert.Equal(20000, rateLimit.Limit);
            Assert.Equal(9876, rateLimit.Remaining);
            Assert.Equal("2019-04-28 14:29", rateLimit.ResetDate.ToString("yyyy-MM-dd HH:mm"));
        }
    }

    static class HttpResponseMessageExtensions
    {
        public static HttpResponseMessage AddHeader(this HttpResponseMessage httpResponseMessage, string headerName, long value)
        {
            httpResponseMessage.Headers.Add(headerName, value.ToString());

            return httpResponseMessage;
        }
    }
}
