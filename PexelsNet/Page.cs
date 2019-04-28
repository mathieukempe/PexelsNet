using System.Collections.Generic;
using Newtonsoft.Json;

namespace PexelsNet
{
    public class Source
    {
        [JsonProperty("original")]
        public string Original { get; set; }

        [JsonProperty("large")]
        public string Large { get; set; }

        [JsonProperty("medium")]
        public string Medium { get; set; }

        [JsonProperty("small")]
        public string Small { get; set; }

        [JsonProperty("portrait")]
        public string Portrait { get; set; }

        [JsonProperty("square")]
        public string Square { get; set; }

        [JsonProperty("landscape")]
        public string Landscape { get; set; }

        [JsonProperty("tiny")]
        public string Tiny { get; set; }
    }

    public class Photo
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("width")]
        public int Width { get; set; }

        [JsonProperty("height")]
        public int Height { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("photographer")]
        public string Photographer { get; set; }

        [JsonProperty("src")]
        public Source Src { get; set; }
    }

    public class Page
    {
        [JsonProperty("page")]
        public int PageNumber { get; set; }

        [JsonProperty("per_page")]
        public int PerPage { get; set; }

        [JsonProperty("total_results")]
        public int TotalResults { get; set; }

        [JsonProperty("next_page")]
        public string NextPage { get; set; }

        [JsonProperty("photos")]
        public List<Photo> Photos { get; set; }
    }
}
