using HateDetector.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HateDetector.API.DataAccess
{
    public interface ITweetRepository
    {
        public Task<IEnumerable<Tweet>> GetTweets(string searchQuery, int maxCount);
    }
}
