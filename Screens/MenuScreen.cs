using IleanaMusic.Data;
using IleanaMusic.Screens;
using static IleanaMusic.Helpers.ConsoleReader;
using static IleanaMusic.Helpers.ConsoleWriter;
using static IleanaMusic.Helpers.TurnHelper;

namespace IleanaMusic
{
    public class MenuScreen 
    {
        public MenuScreen() 
        {
            Title();

            var thereArePieces = AppData.Instance.PieceService.Count() > 0;

            if(!thereArePieces)
            {
                PrintLine(">> No tienes canciones, por lo que está función se encuentra deshabilitada");
                Pause();
            } 
            else
            {
                var option = ReadNumberWithValidation(() => 
                {
                    Clear();
                    Render();
                });


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
                        PrintLine("Nothing here 4");
                        break;

                    case 5:
                        PrintLine("Nothing here 5");
                        break;
                }
            }

        }

        private void Render()
        {
            var thereArePieces = AppData.Instance.PieceService.Count() > 0;

            PrintLine(
                "1. Canciones\n" +
                "2. Playlists\n" +
                "3. Menú de reportes\n" +
                "4. Exportar piezas\n" +
                "5. Importar piezas\n" +
                "6. Salir\n"
            );
            
            Print("Escoge una opción: ");
        }

        private void Title()
        {
            PrintLine(
                "Ileana Music \n" +
                "------------\n"
           );
        }
    }
}