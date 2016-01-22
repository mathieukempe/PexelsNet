using System.Collections.Generic;
using Newtonsoft.Json;

namespace PexelsNet
{
    public class Source
    {
        public string Original { get; set; }
        public string Large { get; set; }
        public string Medium { get; set; }
        public string Small { get; set; }
        public string Portrait { get; set; }
        public string Square { get; set; }
        public string Landscape { get; set; }
        public string Tiny { get; set; }
    }

    public class Photo
    {
        public int Id { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public string Url { get; set; }
        public string Photographer { get; set; }
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

        public List<Photo> Photos { get; set; }
    }
}
