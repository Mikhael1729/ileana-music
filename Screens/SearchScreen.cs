using static System.Console;
using IleanaMusic.Models;
using System;
using IleanaMusic.Data;

namespace IleanaMusic.Screens
{
    public class SearchScreen 
    {
        
        public SearchScreen()
        {
            piece = new Piece();
            WriteLine("Buscar por:\n");
            WriteLine("\n 1. Artista \n 2. Género \n 3. Nombre");
            var option=ReadLine();

                switch (option)
              { 
                case "1":
                //Búsqueda por artista
                    break;
                case "2":
                //Búsqueda por género
                    break;
                case "3":
                //Búsqueda por nombre
                    break;

                  default: break;
              } 
        }
       
    }
}