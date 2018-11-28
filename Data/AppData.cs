using IleanaMusic.Models;
using System.Collections.Generic;
using System;

namespace IleanaMusic.Data 
{
    public class AppData 
    {
        private static readonly Lazy<AppData> instance = new Lazy<AppData>(() => new AppData());
        public List<Piece> PieceList = new List<Piece>() 
        {
            new Piece() {
                Id = 1,
                Name = "Pieza 1",
                Album ="Album 1",
                Artist = "Artista 1",
                Duration = 23,
                Quality = Quality.High,
                Format = MusicFormat.Mp3,
                Gender = Gender.Classical
            },
            new Piece() {
                Id = 2,
                Name = "Pieza 2",
                Album ="Album 2",
                Artist = "Artista 2",
                Duration = 23,
                Quality = Quality.High,
                Format = MusicFormat.Mp3,
                Gender = Gender.Classical
            },
        };
        public List<Playlist> Playlists = new List<Playlist>() {};
        
        private AppData()
        {
        }

        public static AppData Instance
        {
            get => instance.Value;
        }
    }
}