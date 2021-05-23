using Newtonsoft.Json;

namespace HateDetector.API.Models
{
    public class TwitterToken
    {
        [JsonProperty("access_token")]
        public string TokenValue { get; set; }
    }
}
