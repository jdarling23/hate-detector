using HateDetector.API.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

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

        public IEnumerable<Tweet> GetTweets(string searchQuery)
        {
            throw new NotImplementedException();
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

            _token = JsonConvert.DeserializeObject<TwitterToken>(response.Content);
        }
    }
}
