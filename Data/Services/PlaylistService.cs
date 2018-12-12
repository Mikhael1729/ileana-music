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
        string _filePath;
        string _rootNode;
        string _playlistNode;
        XDocument _document;

        public PlaylistService(string fileName)
        {
            _filePath = Path.Combine(Directory.GetCurrentDirectory(), fileName);
            _rootNode = "Playlists";
            _playlistNode = "Playlist";
            InitializeDocument();
        }

        void InitializeDocument()
        {
            using (var storage = IsolatedStorageFile.GetUserStoreForApplication())
            {
                // Uploading existing .xml file.
                if (storage.FileExists(_filePath))
                {
                    using (var stream = storage.OpenFile(_filePath, FileMode.Open))
                    {
                        _document = XDocument.Load(stream);
                    }
                }
                else
                {
                    _document = new XDocument(new XElement(_rootNode));
                }
            }
        }

        int GetNextId()
        {
            var query = (
                from element in _document.Element(_rootNode)?.Elements(_playlistNode)
                select element
            ).LastOrDefault();


            return query != null ? Int32.Parse(query.Attribute("Id").Value) + 1 : 1;
        }

        IEnumerable<XElement> GetAllElements() =>
            from element in _document.Element(_rootNode)?.Elements(_playlistNode)
            select element;


        public Playlist Add(Playlist entity)
        {
            entity.Id = GetNextId();
            XElement playlist = null;

            using (var storage = IsolatedStorageFile.GetUserStoreForApplication())
            {
                // Playlists (parent node).
                playlist = _document.Descendants(_rootNode)?.FirstOrDefault();

                // Playlist element (child node)
                var playlistElement = new XElement(
                    name: _playlistNode,
                    content: new[] {
                        new XAttribute("Id", entity.Id),
                        new XAttribute("Name", entity.Name),
                        new XAttribute("Logo", entity.Logo),
                    }
                );

                // Adding piece IDs to Playlist element..
                var pieces = entity.PieceList.Select<Piece, XElement>(p => {
                    var element = new XElement("PieceId"); 
                    element.Add(p.Id);
                    return element;
                });

                foreach (var p in pieces)
                    playlistElement.Add(p);

                // If exists, add the new piece to descendatants
                playlist?.Add(playlistElement);

                using (Stream stream = storage.CreateFile(_filePath))
                {
                    _document.Save(stream);
                }
            }

            return entity;
        }

        public int Count()
        {
            throw new System.NotImplementedException();
        }

        public void Delete(Playlist entity)
        {
            throw new System.NotImplementedException();
        }

        public Playlist Get(int id)
        {
            throw new System.NotImplementedException();
        }

        public List<Playlist> GetAll() => GetAllElements().Select(p => Playlist.ConvertFromXElement(p)).ToList();

        public Playlist Update(Playlist entity)
        {
            throw new System.NotImplementedException();
        }
    }
}