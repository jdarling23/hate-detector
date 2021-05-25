using HateDetector.API.DataAccess;
using HateDetector.API.Models;
using HateDetector.API.Models.RequestObjects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HateDetector.API.Controllers
{
    [Route("api/Tweet")]
    [ApiController]
    public class TweetController : ControllerBase
    {
        private ITweetRepository _tweetRepository;

        public TweetController(
            ITweetRepository tweetRepository    
        )
        {
            _tweetRepository = tweetRepository;
        }

        /// <summary>
        /// Gets tweets that contain a given text.
        /// </summary>
        /// <param name="textQuery">The text to search for.</param>
        /// <param name="maxCount">The maximum number of tweets to return</param>
        /// <returns>A collection of tweet objects.</returns>
        [Route("GetTweets"), HttpGet, AllowAnonymous]
        public async Task<ActionResult<IEnumerable<Tweet>>> GetTweets([FromBody] TweetRequestObject request)
        {
            try
            {         
                var result = await _tweetRepository.GetTweets(request.TextQuery, request.MaxCount);
                return new OkObjectResult(result);
            }
            catch (Exception ex)
            {
                var errMessage = new ObjectResult($"Error: {ex.Message}");
                errMessage.StatusCode = 500;

                return errMessage;
            }
        }

    }
}
