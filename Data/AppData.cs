using IleanaMusic.Data.Services;
using IleanaMusic.Helpers;
using System;

namespace IleanaMusic.Data
{
    public class AppData
    {
        private static readonly Lazy<AppData> instance = new Lazy<AppData>(() => new AppData());
        
        public PlaylistService PlaylistService { get; set; }
        public ReportingHelper ReportingHelper { get; set; }

        private AppData()
        {

            // Piece service.

            // Playlist service.
            PlaylistService = new PlaylistService("Playlists.xml");
           
            // Reporting helper
            ReportingHelper = new ReportingHelper();
        }

        public static AppData Instance
        {
            get => instance.Value;
        }
    }
}