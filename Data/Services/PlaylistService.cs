using System;
using System.Collections.Generic;
using System.IO;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Xml.Linq;
using IleanaMusic.Models;

namespace IleanaMusic.Data.Services
{
    public class PlaylistService : IPlaylistService
    {
        readonly string isolatedFilePath;
        readonly string isolatedDirectory = "IleanaData";
        readonly string rootNode;
        readonly string playlistNode;
        int count;
        XDocument _document;

        public PlaylistService(string fileName)
        {
            isolatedFilePath = Path.Combine(isolatedDirectory, fileName);
            rootNode = "Playlists";
            playlistNode = "Playlist";
            count = 0;
            InitializeDocument();
        }

        void InitializeDocument()
        {
            using (var storage = IsolatedStorageFile.GetStore(IsolatedStorageScope.User | IsolatedStorageScope.Assembly, null, null))
            {
                // Uploading existing .xml file.
                if (storage.FileExists(isolatedFilePath))
                {
                    using (var stream = storage.OpenFile(isolatedFilePath, FileMode.Open))
                    {
                        _document = XDocument.Load(stream);
                        this.count = GetAll().Count;
                    }
                }
                else
                {
                    _document = new XDocument(new XElement(rootNode));
                }
            }
        }

        int ComputeNextId()
        {
            var query = (   
                from element in _document.Element(rootNode)?.Elements(playlistNode)
                select element
            ).LastOrDefault();


            return query != null ? Int32.Parse(query.Attribute("Id").Value) + 1 : 1;
        }

        IEnumerable<XElement> GetAllElements() =>
            from element in _document.Element(rootNode)?.Elements(playlistNode)
            select element;


        public Playlist Add(Playlist entity)
        {
            if(ItCanBeAdded(entity))
            {
                entity.Id = ComputeNextId();
                XElement playlist = null;

                using (var storage = IsolatedStorageFile.GetStore(IsolatedStorageScope.User | IsolatedStorageScope.Assembly, null, null))
                {
                    // Playlists (parent node).
                    playlist = _document.Descendants(rootNode)?.FirstOrDefault();

                    // Playlist element (child node)
                    var playlistElement = new XElement(
                        name: playlistNode,
                        content: new[] {
                            new XAttribute("Id", entity.Id),
                            new XAttribute("Name", entity.Name),
                            new XAttribute("Logo", entity.Logo),
                        }
                    );

                    // Adding piece IDs to Playlist element..
                    var pieces = entity.PieceList.Select<Piece, XElement>(p =>
                    {
                        var element = new XElement("PieceId");
                        element.Add(p.Id);
                        return element;
                    });

                    foreach (var p in pieces)
                        playlistElement.Add(p);

                    // If exists, add the new piece to descendatants
                    playlist?.Add(playlistElement);

                    using (Stream stream = storage.CreateFile(isolatedFilePath))
                    {
                        _document.Save(stream);
                    }
                }

                this.count++;

                return entity;
            }
            else
            {
                throw new InvalidOperationException("No se puede agregar una lista de reproducción con el nombre de una ya existente");
            }
        }

        public int Count()
        {
            return count;
        }

        public void Delete(Playlist entity)
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

            this.count--;
        }

        public Playlist Get(int id)
        {
            return GetAll().Where(p => p.Id == id).FirstOrDefault();
        }

        public List<Playlist> GetAll() => GetAllElements().Select(p => Playlist.ConvertFromXElement(p)).ToList();

        public Playlist Update(Playlist entity)
        {
            if (!ItCanBeUpdated(entity))
                throw new InvalidOperationException("No pueden existir dos listas de reproducción con el mismo nombre");

            var query = (
                from element in GetAllElements()
                where Int32.Parse(element.Attribute("Id").Value) == entity.Id
                select element).FirstOrDefault();

            query.Attribute("Name").Value = entity.Name;
            query.Attribute("Logo").Value = entity.Logo;

            // Deleting pieces.
            query.Elements("PieceId").Remove();

            // Updating with possible modified data.
            var pieces = entity.PieceList.Select<Piece, XElement>(p =>
            {
                var element = new XElement("PieceId");
                element.Add(p.Id);
                return element;
            });

            foreach (var p in pieces)
                query.Add(p);


            using (var storage = IsolatedStorageFile.GetStore(IsolatedStorageScope.User | IsolatedStorageScope.Assembly, null, null))
            {
                using (Stream stream = storage.CreateFile(isolatedFilePath))
                {
                    _document.Save(stream);
                }
            }

            return entity;
        }

        private bool ItCanBeUpdated(Playlist entity)
        {
            // Has another ID and the same name.
            var anotherWithTheSameName = Find((Playlist p) => p.Id != entity.Id && p.Name.ToLower() == entity.Name.ToLower());
            return anotherWithTheSameName == null ? true : false;
        }

        public Playlist Find(Func<Playlist, bool> critery) => GetAll().Where(critery).FirstOrDefault();

        public bool ItCanBeAdded(Playlist playlist)
        {
            // Playlists with the same name of another can't be added
            var searched = Find((Playlist p) => p.Name.ToLower() == playlist.Name.ToLower());
            return searched == null ? true : false;
        }
    }
}