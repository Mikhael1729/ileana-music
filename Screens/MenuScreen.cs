using System;
using static IleanaMusic.Helpers.ConsoleReader;
using static IleanaMusic.Helpers.TurnHelper;

namespace IleanaMusic 
{
    public class MenuScreen 
    {
        private int option;
        private const string menu = @"Ileana Music
------------

1. Canciones
2. Playlists
3. Menú de reportes
4. Exportar piezas
5. Importar piezas
6. Salir

Escoge una opción: ";


        public MenuScreen() 
        {
            option = ReadNumberWithValidation(() => { Clear(); Console.Write(menu);  });
        }

        public int Data() 
        {
            return option;
        }
    }
}