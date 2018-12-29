using System;
using System.Collections.Generic;
using System.Xml.Linq;
using IleanaMusic.Models;
using System.Linq;
using IleanaMusic.Data;
using IleanaMusic.Data.Services;

namespace IleanaMusic.Models
{
    public class Playlist : BaseEntity
    {
        public string Name { get; set; }
        public string Logo { get; set; }
        public List<Piece> PieceList { get; set; } = new List<Piece>();

        // Delete a song from the playlist.
        public void DeletePiece(Piece piece)
        {
            PieceList.Remove(piece);
        }

        public override string ToString() => Name;

        internal static Playlist ConvertFromXElement(XElement element)
        {
            var pieces = element.Elements("PieceId").Select<XElement, Piece>(e =>
            {
                var searched = PieceService.Instance.Find((Piece p) => p.Id == Int32.Parse(e.Value));

                if (searched == null)
                    return null;

                return new Piece
                {
                    Id = searched.Id,
                    Album = searched.Album,
                    Artist = searched.Artist,
                    Duration = searched.Duration,
                    Format = searched.Format,
                    Gender = searched.Gender,
                    Name = searched.Name,
                    Quality = searched.Quality
                };
            });

            return new Playlist
            {
                Id = Int32.Parse(element.Attribute("Id").Value),
                Name = element.Attribute("Name").Value,
                Logo = element.Attribute("Logo").Value,
                PieceList = pieces.ToList()
            };
        }
    }
}