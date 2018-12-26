using IleanaMusic.Models;
using System.Collections.Generic;
using System;
using IleanaMusic.Data.Services;
using IleanaMusic.Helpers;
using static System.IO.Path;
using static System.IO.Directory;
using System.IO;

namespace IleanaMusic.Data
{
    public class AppData
    {
        private static readonly Lazy<AppData> instance = new Lazy<AppData>(() => new AppData());
        
        public PieceService PieceService;
        public PlaylistService PlaylistService;
        public ReportingHelper ReportingHelper;

        private AppData()
        {
            // Piece service.
            PieceService = new PieceService("Pieces.xml");

            // Playlist service.
            PlaylistService = new PlaylistService(@"Playlists.xml");

            ReportingHelper = new ReportingHelper();
        }

        public static AppData Instance
        {
            get => instance.Value;
        }
    }
}