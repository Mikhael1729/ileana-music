using System.Collections.Generic;
using System.Xml.Linq;
using System.Linq;
using IleanaMusic.Data.Repositories;
using IleanaMusic.Models;

namespace IleanaMusic.Data.Services
{
    public class PieceData : IData<Piece>
    {
        public List<Piece> List { get; set; } = new List<Piece>();

        public PieceData() 
        {

        }

        public void SaveAll()
        {
            var document = new XDocument(
              new XElement(
                  name: "PieceList",
                  content: (
                      from piece in (from register in List select register)
                      select new XElement(
                          name: "Piece",
                          content: new[] {
                                new XAttribute("Name", piece.Name),
                                new XAttribute("Artist", piece.Artist),
                                new XAttribute("Album", piece.Album),
                                new XAttribute("Gender", piece.Gender),
                                new XAttribute("Duration", piece.Duration),
                                new XAttribute("Quality", piece.Quality),
                                new XAttribute("Format", piece.Format)
                          })
                  )
            ));

            document.Save("Pieces.xml");
        }
    }
}