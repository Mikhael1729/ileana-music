using IleanaMusic.Data;
using IleanaMusic.Data.Services;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Xml;
using System.Xml.Linq;

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
            pieceService = AppData.Instance.PieceService;
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
                var json = JsonConvert.SerializeObject(pieceService.GetAll(), Newtonsoft.Json.Formatting.Indented);
                File.WriteAllText(piecesJsonPath, json);
                completeExport = true;
            }
            catch(Exception e)
            { }

            return completeExport;
        }
    }
}
