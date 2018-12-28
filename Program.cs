using IleanaMusic.Screens;
using static IleanaMusic.Helpers.ConsoleReader;
using static IleanaMusic.Helpers.ConsoleWriter;
using static IleanaMusic.Helpers.TurnHelper;

namespace IleanaMusic
{
    class Program
    {
        static void Main(string[] args)
        {
            int option = 0;

            while(option != 6)
            {
                option = ReadNumberWithValidation(() =>
                {
                    Clear();

                    PrintLine(
                        "Ileana Music \n" +
                        "------------\n"
                    );

                    PrintLine(
                        "1. Canciones\n" +
                        "2. Playlists\n" +
                        "3. Menú de reportes\n" +
                        "4. Exportar piezas\n" +
                        "5. Importar piezas\n" +
                        "6. Salir\n"
                    );

                    Print("Escoge una opción: ");
                });

                Clear();
                switch (option)
                {
                    case 1:
                        new MenuOneScreen();
                        break;
                    case 2:
                        new PlayListsMenuScreen();
                        break;
                    case 3:
                        new ReporterMenuScreen();
                        break;
                    case 4:
                        new ExportMenuScreen();
                        break;

                    case 5:
                        new ImportMenuScreen();
                        break;
                }
            }
        }
    }
}
