using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices.ComTypes;
using System.Threading;
using System.Threading.Tasks;

using Google.Apis.Auth.OAuth2;
using Google.Apis.Http;
using Google.Apis.Services;
using Google.Apis.Upload;
using Google.Apis.Util.Store;
using Google.Apis.YouTube.v3;
using Google.Apis.YouTube.v3.Data;
using Microsoft.IdentityModel.Clients.ActiveDirectory;

namespace Playlist.Controllers
{
  public class PlaylistController : Controller
  {
    

    // GET
    public IActionResult Index()
    {
      return View();
    }

    /// <summary>
    /// YouTube Data API v3 sample: search by keyword.
    /// </summary>
    internal class Search
    {
      private string keyword;
      
      [STAThread]
      static void MainSearch(string[] args)
      {
        Console.WriteLine("YouTube Data API: Search");
        Console.WriteLine("========================");

        try
        {
          new Search().Run().Wait();
        }
        catch (AggregateException ex)
        {
          foreach (var e in ex.InnerExceptions)
          {
            Console.WriteLine("Error: " + e.Message);
          }
        }

        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
      }

      private async Task Run()
      {
        var youtubeService = new YouTubeService(new BaseClientService.Initializer()
        {
          //Clé API à mettre ici
          ApiKey = "REPLACE_ME",
          ApplicationName = this.GetType().ToString()
        });

        var searchListRequest = youtubeService.Search.List("snippet");
        searchListRequest.Q = this.keyword ; // Search term.
        searchListRequest.MaxResults = 50;

        
        // Call the search.list method to retrieve results matching the specified query term.
        var searchListResponse = await searchListRequest.ExecuteAsync();

        
        
        List<string> videos = new List<string>();
        
        // Add each result to the appropriate list, and then display the lists of
        // matching videos.
        foreach (var searchResult in searchListResponse.Items)
        {
          if(searchResult.Id.Kind == "youtube#video")
          {
            
              videos.Add(String.Format("{0} ({1})", searchResult.Snippet.Title, searchResult.Id.VideoId));
              
        }

        Console.WriteLine(String.Format("Videos:\n{0}\n", string.Join("\n", videos)));
      }
    }
  }
}
}