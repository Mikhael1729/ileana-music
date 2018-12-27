using static IleanaMusic.Helpers.ConsoleReader;
using static IleanaMusic.Helpers.ConsoleWriter;
using static IleanaMusic.Helpers.TurnHelper;
using IleanaMusic.Helpers;

namespace IleanaMusic.Screens
{
    public class JsonExportScreen
    {
        public JsonExportScreen()
        {
            var exporter = ExporterHelper.Instance;
            var wasSuccesful = false;

            Title();

            PrintLine(
                "Exportando..."
            );

            wasSuccesful = exporter.ExportPiecesToJson();

            Clear();

            Title();
            if(wasSuccesful)
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
                "Exportar a JSON\n" +
                "---------------\n"
            );
        }
    }
}
