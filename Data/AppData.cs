using IleanaMusic.Models;
using System.Collections.Generic;
using System;
using IleanaMusic.Data.Services;

namespace IleanaMusic.Data
{
    public class AppData
    {
        private static readonly Lazy<AppData> instance = new Lazy<AppData>(() => new AppData());
        
        public List<Playlist> Playlists;
        public PieceService PieceService;
        public PlaylistService PlaylistService;

        private AppData()
        {
            Playlists = new List<Playlist>();
            PieceService = new PieceService("Pieces.xml");
            PlaylistService = new PlaylistService("Playlists.xml");
        }

        public static AppData Instance
        {
            get => instance.Value;
        }
    }
}