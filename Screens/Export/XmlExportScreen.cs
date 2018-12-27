using static IleanaMusic.Helpers.ConsoleWriter;
using static IleanaMusic.Helpers.TurnHelper;
using IleanaMusic.Helpers;

namespace IleanaMusic.Screens
{
    class XmlExportScreen
    {
        public XmlExportScreen()
        {
            var exporter = ExporterHelper.Instance;
            var wasSuccesful = false;

            Title();

            PrintLine(
                "Exportando..."
            );

            wasSuccesful = exporter.ExportPiecesToXml();

            Clear();

            Title();
            if (wasSuccesful)
            {
                PrintLine(
                    "¡Exportación exitosa! : )"
                );
            }
            else
            {
                PrintLine(
                    "Exportación fallida. : ("
                );
            }

            Pause();
        }

        public void Title()
        {
            PrintLine(
                "Exportar a XML\n" +
                "---------------\n"
            );
        }
    }
}
