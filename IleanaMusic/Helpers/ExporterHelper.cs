using IleanaMusic.Data.Services;
using Newtonsoft.Json;
using System;
using System.IO;
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

        private ExporterHelper()
        {
            pieceService = PieceService.Instance;
            basePath = Path.Combine(Directory.GetCurrentDirectory(), "Exportaciones");

            if (!File.Exists(basePath))
                Directory.CreateDirectory(basePath);
        }

        public bool ExportPiecesToXml()
        {
            var completeExport = false;

            try
            {
                var path = GenerateFilePath(Path.Combine(basePath, "Piezas"), ".xml");
                pieceService.Document.Save(path);
                System.Diagnostics.Process.Start(basePath);
                System.Diagnostics.Process.Start(path);
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

                var path = GenerateFilePath(Path.Combine(basePath, "Piezas"), ".json");
                var json = JsonConvert.SerializeObject(pieces, Newtonsoft.Json.Formatting.Indented);
                File.WriteAllText(path, json);
                System.Diagnostics.Process.Start(basePath);
                System.Diagnostics.Process.Start(path);
                completeExport = true;
            }
            catch(Exception e)
            { }

            return completeExport;
        }

        string GenerateFilePath(string pathWithoutExtension, string extension)
        {
            while (File.Exists(pathWithoutExtension + extension))
            {
                var lastCharacter = pathWithoutExtension[pathWithoutExtension.Length - 2];

                var partOne = pathWithoutExtension.Split(' ');
                if (Int32.TryParse(lastCharacter.ToString(), out int number))
                    pathWithoutExtension = $"{partOne[0]} ({number + 1})";
                else
                    pathWithoutExtension = $"{partOne[0]} ({1})";
            }

            return pathWithoutExtension + extension;
        }
    }
}
