using IleanaMusic.Data;
using IleanaMusic.Helpers;
using IleanaMusic.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using static IleanaMusic.Helpers.ConsoleReader;
using static IleanaMusic.Helpers.ConsoleWriter;

namespace IleanaMusic.Screens
{
    class ImportFromJsonScreen
    {
        public ImportFromJsonScreen()
        {
            var pieceService = AppData.Instance.PieceService;

            PrintLine(
                "Importar desde JSON\n" +
                "-------------------\n"
            );

            Print("Escribe la ubicación del archivo: ");
            var path = ReadLine();

            PrintLine("");

            try
            {
                // Loading xml file.
                PrintLine("Cargando datos...\n");

                // Extracting pieces.
                var pieces = JsonConvert.DeserializeObject<List<Piece>>(File.ReadAllText(path));

                pieces.ForEach(p =>
                {
                    if (p.ItCanBeAdded(pieceService))
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
            catch (Exception e)
            {
                if (e is InvalidOperationException)
                {
                    PrintLine($">> {e.Message} <<");
                }
                else if (e is ArgumentException)
                {
                    PrintLine($">> Debe introducir una Uri válida. (Nada se ha procesado) <<");
                }
                else
                {
                    PrintLine($">> Ha ocurrido un error. No pudimos encontrar un archivo JSON válido. Vuelva a intentarlo  <<");
                }
            }
        }
    }
}
