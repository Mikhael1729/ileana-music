using static IleanaMusic.Helpers.ConsoleWriter;
using static IleanaMusic.Helpers.ConsoleReader;
using System;
using System.Xml.Linq;


namespace IleanaMusic.Screens
{
    class ImportFromXmlScreen
    {
        public ImportFromXmlScreen()
        {
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

                // TODO: Add imported pieces to piece list.
            }
            catch(Exception e)
            {
                PrintLine(">> Error al tratar de importar el archivo <<");
            }
        }
    }
}
