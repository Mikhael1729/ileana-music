using System.Linq;
using IleanaMusic.Data.Repositories;
using IleanaMusic.Models;
using System;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using System.IO;
using System.Xml.Linq;

namespace IleanaMusic.Data.Services
{
    public class PieceService : IPieceService
    {
        string filePath;
        XDocument _document;

        public PieceService(string fileName)
        {
            filePath = Path.Combine(Directory.GetCurrentDirectory(), fileName);
            InitializeDocument();
        }

        void InitializeDocument()
        {
            using (var storage = IsolatedStorageFile.GetUserStoreForApplication())
            {
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
                    _document = new XDocument(new XElement("PieceList"));
                }
            }
        }

        int GetNextId()
        {
            var query = (
                from element in _document.Element("PieceList")?.Elements("Piece")
                select element
            ).LastOrDefault();


            return query != null ? Int32.Parse(query.Attribute("Id").Value) + 1 : 1;
        }

        IEnumerable<XElement> GetAllElements() =>
            from element in _document.Element("PieceList")?.Elements("Piece")
            select element;

        public Piece Add(Piece entity)
        {
            entity.Id = GetNextId();
            XElement pieceList = null;

            using (var storage = IsolatedStorageFile.GetUserStoreForApplication())
            {
                // Getting PieceList node.
                pieceList = _document.Descendants("PieceList")?.FirstOrDefault();

                var pieceElement = new XElement(
                    name: "Piece",
                    content: new[] {
                        new XAttribute("Id", entity.Id),
                        new XAttribute("Name", entity.Name),
                        new XAttribute("Artist", entity.Artist),
                        new XAttribute("Album", entity.Album),
                        new XAttribute("Gender", Enum.GetName(entity.Gender.GetType(), entity.Gender)),
                        new XAttribute("Duration", entity.Duration),
                        new XAttribute("Quality", Enum.GetName(entity.Quality.GetType(), entity.Quality)),
                        new XAttribute("Format", Enum.GetName(entity.Format.GetType(), entity.Format))
                    }
                );

                // If exists, add the new piece to descendatants
                pieceList?.Add(pieceElement);

                using (Stream stream = storage.CreateFile(filePath))
                {
                    _document.Save(stream);
                }
            }

            return entity;
        }

        public int Count()
        {
            return GetAll().Count;
        }

        public void Delete(Piece entity)
        {
            var query = GetAllElements().Where(e => Int32.Parse(e.Attribute("Id").Value) == entity.Id).FirstOrDefault();
            query.Remove();

            using (var storage = IsolatedStorageFile.GetUserStoreForApplication())
            {
                using (Stream stream = storage.CreateFile(filePath))
                {
                    _document.Save(stream);
                }
            }
        }

        public Piece Get(int id) => GetAll().Where(p => p.Id == id).FirstOrDefault();

        public List<Piece> GetAll() => GetAllElements().Select(p => Piece.ConvertFromXElement(p)).ToList();

        public Piece Update(Piece entity)
        {
            var query = (
                from element in GetAllElements()
                where Int32.Parse(element.Attribute("Id").Value) == entity.Id
                select element).FirstOrDefault();

            query.Attribute("Name").Value = entity.Name;
            query.Attribute("Artist").Value = entity.Artist;
            query.Attribute("Album").Value = entity.Album;
            query.Attribute("Gender").Value = Enum.GetName(entity.Gender.GetType(), entity.Gender);
            query.Attribute("Duration").Value = entity.Duration.ToString();
            query.Attribute("Quality").Value = Enum.GetName(entity.Quality.GetType(), entity.Quality);
            query.Attribute("Format").Value =  Enum.GetName(entity.Format.GetType(), entity.Format);
            
            using (var storage = IsolatedStorageFile.GetUserStoreForApplication())
            {
                using (Stream stream = storage.CreateFile(filePath))
                {
                    _document.Save(stream);
                }
            }

            return entity;
        }

        public Piece Find(Func<Piece, bool> critery) => GetAll().Where(critery).FirstOrDefault();
    }
}