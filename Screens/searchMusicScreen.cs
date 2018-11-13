using static System.Console;
using IleanaMusic.Models;
using System;
using IleanaMusic.Data;
using System.Linq;

namespace IleanaMusic.Screens
{
    public class searchMusicScreen
    {
      

        public searchMusicScreen(){

          WriteLine("Buscar musica:\n" + "-------------------\n");
          
          Write("- Ingrese el id de su musica: ");
          var InsertId = Convert.ToInt32(ReadLine());

          var music = AppData.Instance.PieceList.Where(i => i.Id == InsertId).FirstOrDefault();
            WriteLine("- Nombre: " + music.Name);
            WriteLine("- Artista: " + music.Artist);
            WriteLine("- Album: " + music.Album);
            WriteLine("- Gender: " + music.Gender);
            WriteLine("- Duracion: " + music.Duration);
            WriteLine("- Quality: " + music.Quality);
            WriteLine("- Formato: " + music.Format);
       
        }
       
    }
}