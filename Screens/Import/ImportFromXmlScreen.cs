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
                // Loading xml file.
                var xml = XDocument.Load(path);

                // Extrating pieces.
                var pieces = xml.ExtractPieces(); // TODO: Add imported pieces to piece list.

                // Adding imported pieces to the list of pieces.
                pieces.ToList().ForEach(p => pieceService.Add(p));
            }
            catch(Exception e)
            {
                PrintLine(">> Ha ocurrido un error al tratar de importar el archivo <<");
            }
        }
    }
}
