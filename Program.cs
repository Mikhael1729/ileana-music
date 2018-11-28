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

            /* Options (of MenuScreen)
             *  1. Canciones.
             *  2. Listas de canciones.
             *  3. Salir. 
             */
            while (option != 4)
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
                        var menu2Option = new PlayListsMenuScreen();
                        break;
                    case 3: 
                        WriteLine("Nada por aquí (opción 3)");
                        break;
                }

                // If option is "1" you don't want to show the follow message.
                if (option != 1)
                {
                    WriteLine("\nPresiona cualquier tecla para volver atrás");
                    ReadLine();
                }
            }
        }
    }
}
