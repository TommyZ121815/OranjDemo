using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OranjDemo.Models
{
    // used jsontocsharp to get C# class from json 
    public class Song
    {
        public string S { get; set; }
    }

    public class PlaylistId
    {
        public string N { get; set; }
    }

    public class Album
    {
        public string S { get; set; }
    }

    public class Artist
    {
        public string S { get; set; }
    }

    public class URL
    {
        public string S { get; set; }
    }

    public class Item
    {
        public Song Song { get; set; }
        public PlaylistId playlistId { get; set; }
        public DemoAlbum Album { get; set; }
        public Artist Artist { get; set; }
        public URL URL { get; set; }
    }

    public class OranjDemoAlbum
    {
        public int Count { get; set; }
        public List<Item> Items { get; set; }
        public int ScannedCount { get; set; }
    }
}