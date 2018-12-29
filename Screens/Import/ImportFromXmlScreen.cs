using IleanaMusic.Data;
using IleanaMusic.Data.Services;
using IleanaMusic.Helpers;
using System;
using System.Linq;
using System.Xml.Linq;
using static IleanaMusic.Helpers.ConsoleReader;
using static IleanaMusic.Helpers.ConsoleWriter;

namespace IleanaMusic.Screens
{
    class ImportFromXmlScreen
    {
        public ImportFromXmlScreen()
        {
            var pieceService = PieceService.Instance;

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

                PrintLine("Cargando datos...\n");

                // Extrating pieces.
                var pieces = xml.ExtractPieces(pieceService); // TODO: Add imported pieces to piece list.

                // Adding imported pieces to the list of pieces.
                pieces.ToList().ForEach(p => {
                    if(p.ItCanBeAdded(pieceService))
                    {
                        pieceService.Add(p);

                        PrintLine($"- La pieza \"{p}\" ha sido agregada.");
                    }
                    else
                    {
                        PrintLine(
                            $"* La pieza \"{p}\" ya existe en la lista. No será agregada."
                        );
                    }
                });

                PrintLine("\n¡Proceso finalizado!");
            }
            catch(Exception e)
            {
                if(e is InvalidOperationException)
                {
                    PrintLine($">> {e.Message} <<");
                }
                else if(e is ArgumentException)
                {
                    PrintLine($">> Debe introducir una Uri válida. (Nada se ha procesado) <<");
                }
                else
                {
                    PrintLine($">> Ha ocurrido un error. No pudimos encontrar un archivo XML válido. Vuelva a intentarlo << ");
                }
            }
        }
    }
}
