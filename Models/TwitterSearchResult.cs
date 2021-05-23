using Newtonsoft.Json;
using System.Collections.Generic;

namespace HateDetector.API.Models
{
    /// <summary>
    /// Root class of data for search results response from Twitter API
    /// </summary>
    public class TwitterSearchResult
    {
        public List<Tweet> Results { get; set; }

        public SearchResultMetadata Metadata { get; set; }
    }


    /// <summary>
    /// The metrics for an individual Tweet returned in search
    /// </summary>
    public class PublicMetrics
    {
        [JsonProperty("retweet_count")]
        public int Retweets { get; set; }
        
        [JsonProperty("reply_count")]
        public int Replies { get; set; }

        [JsonProperty("like_count")]
        public int Likes { get; set; }

        [JsonProperty("quote_count")]
        public int Quotes { get; set; }
    }

    /// <summary>
    /// Model for Metadata for payload returned from searching the Twitter API
    /// </summary>
    public class SearchResultMetadata
    {
        [JsonProperty("newest_id")]
        public string NewestTweetId { get; set; }

        [JsonProperty("oldest_id")]
        public string OldestTweetId { get; set; }

        [JsonProperty("result_count")]
        public int ResultCount { get; set; }
    }

}
