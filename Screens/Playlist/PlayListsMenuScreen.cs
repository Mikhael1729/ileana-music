using static IleanaMusic.Helpers.ConsoleReader;
using static IleanaMusic.Helpers.ConsoleWriter;
using static IleanaMusic.Helpers.TurnHelper;

namespace IleanaMusic.Screens
{
    public class PlayListsMenuScreen
    {
        int option;


        public PlayListsMenuScreen()
        {
            var option = ReadNumberWithValidation(() =>
            {
                Clear();
                Render();
            });

            while (option != 7)
            {
                Clear();
                switch (option)
                {
                    case 1:
                        new AddPlayListScreen();
                        break;
                    case 2:
                        new PlaylistsScreen();
                        break;
                    case 3:
                        new EditPlayListScreen();
                        break;
                    case 4:
                        new DeletePlaylitScreen();
                        break;
                    case 5:
                        new SearchPlaylistScreen();
                        break;
                    case 6:
                        new SearchPieceInPlaylistScreen();
                        break;
                }
                if (option != 7)
                    Pause();
            }
        }

        private void Render()
        {
            PrintLine(
                 "Playlists \n" +
                 "---------\n"
            );

            PrintLine(
                "1. Agregar playlist\n" +
                "2. Listar playlists\n" +
                "3. Editar playlist\n" +
                "4. Borrar playlist\n" +
                "5. Buscar playlist\n" +
                "6. Buscar canción en playlist\n"+
                "7. <<-- Ir atrás\n"
            );

            Print("Escoge una opción: ");
        }
    }
}