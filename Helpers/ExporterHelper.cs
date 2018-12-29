using IleanaMusic.Data;
using IleanaMusic.Data.Services;
using IleanaMusic.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.Linq;

namespace IleanaMusic.Helpers
{
    public class ExporterHelper
    {
        private static readonly Lazy<ExporterHelper> instance = new Lazy<ExporterHelper>(() => new ExporterHelper());
        public static ExporterHelper Instance
        {
            get => instance.Value;
        }

        readonly PieceService pieceService;
        readonly string basePath;
        readonly string piecesPath;
        readonly string piecesJsonPath;

        private ExporterHelper()
        {
            pieceService = PieceService.Instance;
            basePath = Path.Combine(Directory.GetCurrentDirectory(), "Exportaciones");
            piecesPath = Path.Combine(basePath, "Piezas.xml");
            piecesJsonPath = Path.Combine(basePath, "Piezas.json");


            if (!File.Exists(basePath))
                Directory.CreateDirectory(basePath);
        }

        public bool ExportPiecesToXml()
        {
            var completeExport = false;

            try
            {
                pieceService.Document.Save(piecesPath);
                completeExport = true;
            }
            catch (Exception e)
            { }

            return completeExport;
        }

        public bool ExportPiecesToJson()
        {
            var completeExport = false;

            try
            {
                var pieces = pieceService.GetAll()
                    .AsEnumerable()
                    .Select(piece => new
                    {
                        piece.Id,
                        piece.Name,
                        piece.Artist,
                        piece.Album,
                        Gender = Enum.GetName(piece.Gender.GetType(), piece.Gender),
                        piece.Duration,
                        Quality = Enum.GetName(piece.Quality.GetType(), piece.Quality),
                        Format = Enum.GetName(piece.Format.GetType(), piece.Format)
                    });

                var json = JsonConvert.SerializeObject(pieces, Newtonsoft.Json.Formatting.Indented);
                File.WriteAllText(piecesJsonPath, json);
                completeExport = true;
            }
            catch(Exception e)
            { }

            return completeExport;
        }
    }
}
