using IleanaMusic.Models;
using System.Collections.Generic;
using System;

namespace IleanaMusic.Data 
{
    public class AppData 
    {
        private static readonly Lazy<AppData> instance = new Lazy<AppData>(() => new AppData());
        public List<Piece> PieceList = new List<Piece>();

        private AppData()
        {
        }

        public static AppData Instance
        {
            get => instance.Value;
        }
    }
}