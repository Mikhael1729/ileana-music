using static IleanaMusic.Helpers.ConsoleReader;
using static IleanaMusic.Helpers.ConsoleWriter;
using static IleanaMusic.Helpers.TurnHelper;

namespace IleanaMusic.Screens
{
    public class ExportMenuScreen
    {
        public ExportMenuScreen()
        {
            int option = 0;

            while (option != 3)
            {
                option = ReadNumberWithValidation(() =>
                {
                    Clear();

                    PrintLine(
                        "Exportar Piezas\n" +
                        "---------------\n"
                    );

                    PrintLine(
                        "1. Exportar a XML\n" +
                        "2. Exportar a JSON\n" +
                        "3. <<-- Ir atrás\n"
                    );

                    Print(
                        "Escoge una opción: "
                    );
                });

                Clear();

                switch (option)
                {
                    case 1:
                        break;
                    case 2:
                        new JsonExportScreen();
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
