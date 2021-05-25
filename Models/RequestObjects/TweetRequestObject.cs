using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HateDetector.API.Models.RequestObjects
{
    public class TweetRequestObject
    {
        [JsonProperty("textQuery")]
        public string TextQuery { get; set; }

        [JsonProperty("maxCount")]
        public int MaxCount { get; set; }
    }
}
