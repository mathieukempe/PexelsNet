using System;

namespace PexelsNet
{
    internal class UnixTimeStamp
    {
        private static readonly DateTime UnixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);

        public static DateTime ToDateTime(long unixTimeStamp)
        {
            return UnixEpoch.AddSeconds(unixTimeStamp).ToLocalTime();
        }
    }
}