using System.Collections.Generic;
using System.Xml.Linq;
using System.Linq;
using IleanaMusic.Data.Repositories;
using IleanaMusic.Models;
using System;
using System.IO;
using System.IO.IsolatedStorage;

namespace IleanaMusic.Data.Services
{
    public class PieceData : IData<Piece>
    {
        public List<Piece> List { get; } = new List<Piece>();
        XDocument _document;

        public PieceData()
        {
            InitializeDocument();

            var query =
                from element in _document.Element("PieceList")?.Elements("Piece")
                select new Piece
                {
                    Name = element.Attribute("Name").Value,
                    Artist = element.Attribute("Artist").Value,
                    Album = element.Attribute("Album").Value,
                    Gender = (Gender)Enum.Parse(typeof(Gender), element.Attribute("Gender").Value),
                    Duration = Int32.Parse(element.Attribute("Duration").Value),
                    Quality = (Quality)Enum.Parse(typeof(Quality), element.Attribute("Quality").Value),
                    Format = (MusicFormat)Enum.Parse(typeof(MusicFormat), element.Attribute("Format").Value),
                };

            List = query.ToList();
        }

        void InitializeDocument()
        {
            using (var storage = IsolatedStorageFile.GetUserStoreForApplication())
            {
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Pieces.xml");

                // Uploading existing .xml file.
                if (storage.FileExists(filePath))
                {
                    using (var stream = storage.OpenFile(filePath, FileMode.Open))
                    {
                        _document = XDocument.Load(stream);
                    }
                }
                else
                {
                    _document = new XDocument();
                }
            }
        }

        public void Add(Piece piece)
        {
            XElement pieceList = null;

            using (var storage = IsolatedStorageFile.GetUserStoreForApplication())
            {
                // Getting PieceList node.
                pieceList = _document.Descendants("PieceList").FirstOrDefault();

                var pieceElement = new XElement(
                    name: "Piece",
                    content: new[] {
                        new XAttribute("Name", piece.Name),
                        new XAttribute("Artist", piece.Artist),
                        new XAttribute("Album", piece.Album),
                        new XAttribute("Gender", piece.Gender),
                        new XAttribute("Duration", piece.Duration),
                        new XAttribute("Quality", piece.Quality),
                        new XAttribute("Format", piece.Format)
                    }
                );

                // If exists, add the new piece to descendatants
                if (pieceList != null)
                {
                    pieceList.Add(pieceElement);
                }
                else
                {
                    pieceList = new XElement(
                        name: "PieceList", 
                        content: new [] { pieceElement }
                    );

                    _document.Add(pieceList);
                }

                using (Stream stream = storage.CreateFile("Pieces.xml"))
                {
                    _document.Save(stream);
                }
            }
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