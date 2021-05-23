using Newtonsoft.Json;

namespace HateDetector.API.Models
{
    /// <summary>
    /// Model containing data for an individual Tweet
    /// </summary>
    public class Tweet
    {
        [JsonProperty("id")]
        public string TweetId { get; set; }

        [JsonProperty("public_metrics")]
        public PublicMetrics Metrics { get; set; }

        [JsonProperty("text")]
        public string TweetText { get; set; }
    }
}
