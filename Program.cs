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

            while(option != 6)
            {
                // Refreshing console if there are some content before menu screen.
                Clear();

                // Menu screen.
                var menuScreen = new MenuScreen();
                option = menuScreen.Data();

                // Go to selected screen.
                switch (option)
                {
                    case 1:
                        var pieceScreen = new AddPieceScreen();
                        break;
                    case 2: 
                        new PieceList();    
                        break;
                    case 3: 
                        new EditMusicScreen();
                        break;
                    case 4: 
                        new deleteMusicScreen();
                        break;
                    case 5:
                        new searchMusicScreen();
                        break;
                }

                WriteLine("\nPresiona cualquier tecla para volver atrás");
                ReadLine();
        }
        }
    }
}
