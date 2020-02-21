using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace PexelsNet
{
    /// <summary>
    /// 
    /// </summary>
    public class Source
    {
        /// <summary>
        /// The size of the original image is given with the attributes width and height.
        /// </summary>
        [JsonProperty("original")]
        public string Original { get; set; }

        /// <summary>
        /// This image has a maximum width of 940px and a maximum height of 650px. It has the aspect ratio of the original image.
        /// </summary>
        [JsonProperty("large")]
        public string Large { get; set; }

        /// <summary>
        /// This image has a height of 350px and a flexible width. It has the aspect ratio of the original image.
        /// </summary>
        [JsonProperty("medium")]
        public string Medium { get; set; }

        /// <summary>
        /// This image has a height of 130px and a flexible width. It has the aspect ratio of the original image.
        /// </summary>
        [JsonProperty("Small")]
        public string Small { get; set; }

        /// <summary>
        /// This image has a width of 800px and a height of 1200px.
        /// </summary>
        [JsonProperty("portrait")]
        public string Portrait { get; set; }

        /// <summary>
        /// Square
        /// </summary>
        [JsonProperty("square")]
        public string Square { get; set; }

        /// <summary>
        /// This image has a width of 1200px and height of 627px.
        /// </summary>
        [JsonProperty("landscape")]
        public string Landscape { get; set; }

        /// <summary>
        /// This image has a width of 280px and height of 200px.
        /// </summary>
        [JsonProperty("tiny")]
        public string Tiny { get; set; }
    }

    /// <summary>
    /// Photo
    /// </summary>
    public class Photo
    {
        /// <summary>
        /// Id
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// Width
        /// </summary>
        [JsonProperty("width")]
        public int Width { get; set; }

        /// <summary>
        /// Height
        /// </summary>
        [JsonProperty("height")]
        public int Height { get; set; }

        /// <summary>
        /// Url
        /// </summary>
        [JsonProperty("url")]
        public string Url { get; set; }

        /// <summary>
        /// Photographer
        /// </summary>
        [JsonProperty("photographer")]
        public string Photographer { get; set; }

        /// <summary>
        /// Src
        /// </summary>
        [JsonProperty("src")]
        public Source Src { get; set; }
    }

    /// <summary>
    /// Page
    /// </summary>
    public class Page
    {
        /// <summary>
        /// PageNumber
        /// </summary>
        [JsonProperty("page")]
        public int PageNumber { get; set; }

        /// <summary>
        /// PerPage
        /// </summary>
        [JsonProperty("per_page")]
        public int PerPage { get; set; }

        /// <summary>
        /// TotalResults
        /// </summary>
        [JsonProperty("total_results")]
        public int TotalResults { get; set; }

        /// <summary>
        /// NextPage
        /// </summary>
        [JsonProperty("next_page")]
        public string NextPage { get; set; }

        /// <summary>
        /// Photos
        /// </summary>
        [JsonProperty("photos")]
        public List<Photo> Photos { get; set; }

        /// <summary>
        /// RateLimit
        /// </summary>
        [JsonProperty("rate_limit")]
        public RateLimit RateLimit { get; set; }
    }

    /// <summary>
    /// RateLimit
    /// </summary>
    public class RateLimit
    {
        /// <summary>
        /// Limit
        /// </summary>
        [JsonProperty("limit")]
        public long Limit { get; set; }

        /// <summary>
        /// Remaining
        /// </summary>
        [JsonProperty("remaining")]
        public long Remaining { get; set; }

        /// <summary>
        /// ResetDate
        /// </summary>
        [JsonProperty("reset_date")]
        public DateTime ResetDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{Remaining} of {Limit} remaining. Limit will reset at: {ResetDate:yyyy-MM-dd HH:mm}";
        }
    }
}
