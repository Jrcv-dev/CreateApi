using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using Google.Apis.YouTube.v3.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    public class MTTController : ApiController
    {
        public IHttpActionResult GetVideo(string keyword)
        {
            //string keyword = "banda";
            var youtubeService = new YouTubeService(new BaseClientService.Initializer()
            {
                ApiKey = "AIzaSyAV7dZdpjsqH9K2IkJ0tlqHWklDay0qMW4",
                ApplicationName = this.GetType().ToString()
            });

            var searchListRequest = youtubeService.Search.List("snippet");
            searchListRequest.Q = keyword; // Replace with your search term.
            searchListRequest.MaxResults = 10;

            // Call the search.list method to retrieve results matching the specified query term.
            SearchListResponse searchListResponse = searchListRequest.Execute();

            IList<SearchResult> searchResults = searchListResponse.Items;
            List<Videos> listvideos = new List<Videos>();

            foreach (var item in searchResults)
            {
                listvideos.Add(new Videos { ID = item.Id.VideoId, tittle = item.Snippet.Title });
            }
            return Ok(listvideos);
        }
    }
}
