using HateDetector.API.Models;
using System.Collections.Generic;

namespace HateDetector.API.DataAccess
{
    public interface ITweetRepository
    {
        public IEnumerable<Tweet> GetTweets(string searchQuery);
    }
}
