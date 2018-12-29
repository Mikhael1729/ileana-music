using static IleanaMusic.Helpers.ConsoleWriter;
using static IleanaMusic.Helpers.ConsoleReader;
using System;
using System.Xml.Linq;
using IleanaMusic.Helpers;
using System.Collections.Generic;
using IleanaMusic.Models;
using IleanaMusic.Data;
using System.Linq;

namespace IleanaMusic.Screens
{
    class ImportFromXmlScreen
    {
        public ImportFromXmlScreen()
        {
            var pieceService = AppData.Instance.PieceService;

            PrintLine(
                "Importar desde XML\n" +
                "------------------\n"
            );

            Print("Escribe la ubicación del archivo: ");
            var path = ReadLine();

            PrintLine("");

            try
            {
                var xml = XDocument.Load(path);
                var pieces = xml.ExtractPieces();// TODO: Add imported pieces to piece list.
                pieces.ToList().ForEach(p => pieceService.Add(p));
            }
            catch(Exception e)
            {
                PrintLine(">> Error al tratar de importar el archivo <<");
            }
        }
    }
}
