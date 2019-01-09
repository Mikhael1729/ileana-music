using System.Linq;
using IleanaMusic.Models;
using System;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using System.IO;
using System.Xml.Linq;
using IleanaMusic.Helpers;

namespace IleanaMusic.Data.Services
{
    public class PieceService : IPieceService
    {
        private static readonly Lazy<PieceService> instance = new Lazy<PieceService>(() => new PieceService("Pieces.xml"));
        public static PieceService Instance
        {
            get => instance.Value;
        }

        readonly string isolatedFilePath;
        readonly string isolatedDirectory = "IleanaData";
        XDocument _document;

        public XDocument Document { get => _document; }

        public string RootNode { get; } = "PieceList";
        public string ChildNode { get; } = "Piece";

        private PieceService(string fileName)
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
                            _document = new XDocument(new XElement(RootNode));
                        }
                    }
                }
                else
                {
                    _document = new XDocument(new XElement(RootNode));
                }
            }
        }

        int GetNextId()
        {
            var query = (
                from element in _document.Element(RootNode)?.Elements(ChildNode)
                select element
            ).LastOrDefault();


            return query != null ? Int32.Parse(query.Attribute("Id").Value) + 1 : 1;
        }

        IEnumerable<XElement> GetAllElements()
        {
            return from element in _document.Element(RootNode)?.Elements(ChildNode)
                   select element;
        }

        public Piece Add(Piece entity)
        {
            if (entity.ItCanBeAdded(this))
            {
                entity.Id = GetNextId();
                XElement pieceList = null;

                using (var storage = IsolatedStorageFile.GetStore(IsolatedStorageScope.User | IsolatedStorageScope.Assembly, null, null))
                {
                    // Getting PieceList node.
                    pieceList = _document.Descendants(RootNode)?.FirstOrDefault();

                    var pieceElement = new XElement(
                        name: ChildNode,
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
            else
            {
                throw new InvalidOperationException("OPERAIÓN BLOQUEADA: No se permite agregar piezas con el mismo nombre y mismo artista");
            }
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