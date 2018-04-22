﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
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
            return
            View();
        }
    }
    
     /// <summary>
  /// YouTube Data API v3 sample: create a playlist.
  /// Relies on the Google APIs Client Library for .NET, v1.7.0 or higher.
  /// See https://developers.google.com/api-client-library/dotnet/get_started
  /// </summary>
  internal class PlaylistUpdates
  {
    [STAThread]
    static void MainUpdates(string[] args)
    {
      Console.WriteLine("YouTube Data API: Playlist Updates");
      Console.WriteLine("==================================");

      try
      {
        new PlaylistUpdates().Run().Wait();
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
      IConfigurableHttpClientInitializer credential;
      using (var stream = new FileStream("client_secrets.json", FileMode.Open, FileAccess.Read))
      {
        credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(
            GoogleClientSecrets.Load(stream).Secrets,
            // This OAuth 2.0 access scope allows for full read/write access to the
            // authenticated user's account.
            new[] { YouTubeService.Scope.Youtube },
            "user",
            CancellationToken.None,
            new FileDataStore(this.GetType().ToString())
        );
      }

      var youtubeService = new YouTubeService(new BaseClientService.Initializer()
      {
        HttpClientInitializer = credential,
        ApplicationName = this.GetType().ToString()
      });

      // Create a new, private playlist in the authorized user's channel.
      var newPlaylist = new Google.Apis.YouTube.v3.Data.Playlist();
      newPlaylist.Snippet = new PlaylistSnippet();
      newPlaylist.Snippet.Title = "Test Playlist";
      newPlaylist.Snippet.Description = "A playlist created with the YouTube API v3";
      newPlaylist.Status = new PlaylistStatus();
      newPlaylist.Status.PrivacyStatus = "public";
      newPlaylist = await youtubeService.Playlists.Insert(newPlaylist, "snippet,status").ExecuteAsync();

      // Add a video to the newly created playlist.
      var newPlaylistItem = new PlaylistItem();
      newPlaylistItem.Snippet = new PlaylistItemSnippet();
      newPlaylistItem.Snippet.PlaylistId = newPlaylist.Id;
      newPlaylistItem.Snippet.ResourceId = new ResourceId();
      newPlaylistItem.Snippet.ResourceId.Kind = "youtube#video";
      newPlaylistItem.Snippet.ResourceId.VideoId = "GNRMeaz6QRI";
      newPlaylistItem = await youtubeService.PlaylistItems.Insert(newPlaylistItem, "snippet").ExecuteAsync();

      Console.WriteLine("Playlist item id {0} was added to playlist id {1}.", newPlaylistItem.Id, newPlaylist.Id);
    }
  }
  
  /// <summary>
  /// YouTube Data API v3 sample: search by keyword.
  /// Relies on the Google APIs Client Library for .NET, v1.7.0 or higher.
  /// See https://developers.google.com/api-client-library/dotnet/get_started
  ///
  /// Set ApiKey to the API key value from the APIs & auth > Registered apps tab of
  ///   https://cloud.google.com/console
  /// Please ensure that you have enabled the YouTube Data API for your project.
  /// </summary>
  internal class Search
  {
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
        ApiKey = "REPLACE_ME",
        ApplicationName = this.GetType().ToString()
      });

      var searchListRequest = youtubeService.Search.List("snippet");
      searchListRequest.Q = "Google"; // Replace with your search term.
      searchListRequest.MaxResults = 50;

      // Call the search.list method to retrieve results matching the specified query term.
      var searchListResponse = await searchListRequest.ExecuteAsync();

      List<string> videos = new List<string>();
      List<string> channels = new List<string>();
      List<string> playlists = new List<string>();

      // Add each result to the appropriate list, and then display the lists of
      // matching videos, channels, and playlists.
      foreach (var searchResult in searchListResponse.Items)
      {
        switch (searchResult.Id.Kind)
        {
          case "youtube#video":
            videos.Add(String.Format("{0} ({1})", searchResult.Snippet.Title, searchResult.Id.VideoId));
            break;

          case "youtube#channel":
            channels.Add(String.Format("{0} ({1})", searchResult.Snippet.Title, searchResult.Id.ChannelId));
            break;

          case "youtube#playlist":
            playlists.Add(String.Format("{0} ({1})", searchResult.Snippet.Title, searchResult.Id.PlaylistId));
            break;
        }
      }

      Console.WriteLine(String.Format("Videos:\n{0}\n", string.Join("\n", videos)));
      Console.WriteLine(String.Format("Channels:\n{0}\n", string.Join("\n", channels)));
      Console.WriteLine(String.Format("Playlists:\n{0}\n", string.Join("\n", playlists)));
    }
  }
    
}