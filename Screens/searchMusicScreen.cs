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

          var prueba = AppData.Instance.PieceList.Where(i => i.Id == InsertId).FirstOrDefault();
            WriteLine("- Nombre: " + prueba.Name);
            WriteLine("- Artista: " + prueba.Artist);
            WriteLine("- Album: " + prueba.Album);
            WriteLine("- Gender: " + prueba.Gender);
            WriteLine("- Duracion: " + prueba.Duration);
            WriteLine("- Quality: " + prueba.Quality);
            WriteLine("- Formato: " + prueba.Format);
       
        }
       
    }
}