using System;
using static System.Console;

namespace IleanaMusic 
{
    public class MenuScreen 
    {
        private int option;
        private const string menu = @"Ileana Music
------------

1. Canciones
2. Playlists
3. Menú de reportes.
4. Salir

Escoge una opción: ";


        public MenuScreen() 
        {
            option = 0; 

            Write(menu);

            while(!Int32.TryParse(ReadLine(), out option))
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