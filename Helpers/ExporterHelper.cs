using IleanaMusic.Data;
using IleanaMusic.Data.Services;
using System;
using System.IO; 

namespace IleanaMusic.Helpers
{
    public class ExporterHelper
    {
        static readonly PieceService pieceService = AppData.Instance.PieceService;

        public ExporterHelper()
        {

        }

        public static bool ExportPiecesToXml()
        {
            var completeExport = false;

            var basePath = Path.Combine(Directory.GetCurrentDirectory(), "Exportaciones");
            var piecesPath = Path.Combine(basePath, "Piezas.xml");

            try
            {
                if(!File.Exists(basePath))
                    Directory.CreateDirectory(basePath);

                pieceService.Document.Save(piecesPath);
            }
            catch (Exception e)
            { }

            return completeExport;
        }
    }
}
