using System;
using static System.Console;

namespace IleanaMusic.Screens
{
    public class PlayListsMenuScreen
    {
        int option;
        const string menu = @"Playlists
----------
1. Agregar playlist
2. Listar playlists
3. Editar playlist
4. Borrar playlist
5. Buscar canción en playlist
6. <<-- Ir atrás

Escoge una opción: ";

        public PlayListsMenuScreen()
        {
            option = 0;

            Write(menu);

            while (!Int32.TryParse(ReadLine(), out option))
            {
                Clear();

                // Menu screen.
                Write(menu);
            }

            Clear();
        }

        public int Data()
        {
            return option;
        }
    }
}