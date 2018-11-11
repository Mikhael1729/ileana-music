﻿using System;
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

                // I'm Lehkikm
                var lehkikm = "Lehkikm";
                WriteLine(lehkikm);

                // Go to selected screen.
                switch (option)
                {
                    case 1:
                        var pieceScreen = new AddPieceScreen();
                        break;
                }

                WriteLine("\nPresiona cualquier tecla para volver atrás");
                ReadLine();
        }
        }
    }
}
