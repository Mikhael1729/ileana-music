using System.Linq;
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
        readonly string isolatedFilePath;
        readonly string isolatedDirectory = "IleanaData";
        XDocument _document;

        public XDocument Document { get => _document; }

        public PieceService(string fileName)
        {
            this.isolatedFilePath = Path.Combine(isolatedDirectory, fileName);
            InitializeDocument();
        }

        void InitializeDocument()
        {
            using (var storage = IsolatedStorageFile.GetStore(IsolatedStorageScope.User | IsolatedStorageScope.Assembly, null, null))
            {
                if (!storage.DirectoryExists(isolatedDirectory))
                    storage.CreateDirectory(isolatedDirectory);

                var h = storage.GetFileNames();

                // Uploading existing .xml file.
                if (storage.FileExists(isolatedFilePath))
                {
                    using (var stream = storage.OpenFile(isolatedFilePath, FileMode.Open))
                    {
                        try
                        {
                            _document = XDocument.Load(stream);
                        } 
                        catch(System.Xml.XmlException e)
                        {
                            _document = new XDocument(new XElement("PieceList"));
                        }
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

        IEnumerable<XElement> GetAllElements()
        {
            return from element in _document.Element("PieceList")?.Elements("Piece")
                   select element;
        }

        public Piece Add(Piece entity)
        {
            entity.Id = GetNextId();
            XElement pieceList = null;

            using (var storage = IsolatedStorageFile.GetStore(IsolatedStorageScope.User | IsolatedStorageScope.Assembly, null, null))
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

                using (Stream stream = storage.CreateFile(isolatedFilePath))
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

            using (var storage = IsolatedStorageFile.GetStore(IsolatedStorageScope.User | IsolatedStorageScope.Assembly, null, null))
            {
                using (Stream stream = storage.CreateFile(isolatedFilePath))
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
            
            using (var storage = IsolatedStorageFile.GetStore(IsolatedStorageScope.User | IsolatedStorageScope.Assembly, null, null))
            {
                using (Stream stream = storage.CreateFile(isolatedFilePath))
                {
                    _document.Save(stream);
                }
            }

            return entity;
        }

        public Piece Find(Func<Piece, bool> critery) => GetAll().Where(critery).FirstOrDefault();
    }
}