using HateDetector.API.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HateDetector.API.DataAccess
{
    public class TweetApiRepository : ITweetRepository
    {
        private string _apiKey;
        private string _apiSecret;

        private TwitterToken _token;

        public TweetApiRepository(
            string apiKey,
            string apiSecret
        )
        {
            _apiKey = apiKey;
            _apiSecret = apiSecret;

            GetBearerToken();
        }

        /// <summary>
        /// Return tweets with a given query.
        /// </summary>
        /// <param name="searchQuery">Text to search for in Tweets</param>
        /// <param name="maxCount">Maximum number of Tweets to bring back, defaults to 1000.</param>
        /// <returns>Collection of Tweet objects.</returns>
        public async Task<IEnumerable<Tweet>> GetTweets(string searchQuery, int maxCount = 100)
        {
            if (maxCount < 0 || maxCount > 100)
            {
                throw new Exception("Max count of Tweets must be between 0 and 100.");
            }

            var client = new RestClient("https://api.twitter.com/2/tweets/search/recent");
            var request = new RestRequest(Method.GET);

            request.AddHeader("Authorization", $"Bearer {_token.TokenValue}");
            request.AddQueryParameter("tweet.fields", "public_metrics,text");
            request.AddQueryParameter("max_results", maxCount.ToString());
            request.AddQueryParameter("query", searchQuery);

            var response = await client.ExecuteAsync(request);

            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw new Exception($"Error contacting Twitter API: {response.Content}");
            }

            var searchResults = JsonConvert.DeserializeObject<TwitterSearchResult>(response.Content);

            return searchResults.Results;
        }

        private void GetBearerToken()
        {
            string svcCredentials = Convert.ToBase64String(Encoding.ASCII.GetBytes(_apiKey + ":" + _apiSecret));
            var client = new RestClient("https://api.twitter.com/oauth2/token");
            var request = new RestRequest(Method.POST);

            request.AddHeader("Authorization", $"Basic {svcCredentials}");
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddParameter("grant_type", "client_credentials");

            var response = client.Execute(request);

            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw new Exception($"Error authenticating with Twitter API: {response.Content}");
            }

            _token = JsonConvert.DeserializeObject<TwitterToken>(response.Content);
        }
    }
}
