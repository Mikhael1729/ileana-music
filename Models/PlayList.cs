using System;
using System.Collections.Generic;
using System.Xml.Linq;
using IleanaMusic.Models;
using System.Linq;
using IleanaMusic.Data;

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
            var pieces = element.Elements("PieceId").Select<XElement, Piece>(e => new Piece { Id = Int32.Parse(e.Value) }).ToList();

            return new Playlist
            {
                Id = Int32.Parse(element.Attribute("Id").Value),
                Name = element.Attribute("Name").Value,
                Logo = element.Attribute("Logo").Value,
                PieceList = pieces
            };
        }
    }
}