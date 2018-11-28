using System;
using static System.Console;
using IleanaMusic.Models;
using IleanaMusic.Screens;

namespace IleanaMusic
{
    class Program
    {
        static void Main(string[] args)
        {
            int option = 0;
            int playlistsOption = 0;

            /* Options (of MenuScreen)
             *  1. Canciones.
             *  2. Listas de canciones.
             *  3. Salir. 
             */
            while (option != 3)
            {
                // Refreshing console if there are some content before menu screen.
                Clear();

                // Menu screen.
                var menuScreen = new MenuScreen();
                option = menuScreen.Data();

                switch (option)
                {
                    case 1:
                        new MenuOneScreen();
                        break;
                    case 2:
                        /*
                            1. Agregar playlist
                            2. Listar playlists
                            3. Editar playlist
                            4. Borrar playlist
                            5. Buscar canción en playlist
                            6. <<-- Ir atrás
                         */
                        while (playlistsOption != 6)
                        {
                            Clear();
                            // Showing the menu and getting selected option.
                            playlistsOption = (new PlayListsMenuScreen()).Data();
                            Clear();
                            switch (playlistsOption)
                            {
                                case 1:
                                    new AddPlayListScreen();
                                    break;
                                case 2: 
                                    new PlaylistsScreen();
                                    break;
                            }
                            if(playlistsOption != 6)
                                Pause();
                        }

                        playlistsOption = 0;
                        break;
                    case 3:
                        WriteLine("Nada por aquí (opción 3)");
                        break;
                }

                // If option is "1" you don't want to show the follow message.
                if (option != 1 && playlistsOption != 0)
                {
                    Pause();
                }
            }
        }

        static void Pause()
        {
            WriteLine("\nPresiona cualquier tecla para volver atrás");
            ReadLine();
        }
    }
}
