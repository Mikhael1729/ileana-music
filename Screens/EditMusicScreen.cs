using static System.Console;
using IleanaMusic.Models;
using System;
using IleanaMusic.Data;
using System.Linq;

namespace IleanaMusic.Screens
{
    public class EditMusicScreen
    {
        public EditMusicScreen(){

            var pieceList = AppData.Instance.PieceList;
     
            WriteLine("Editar una pieza:\n" + "-------------------\n");
            Write("Ingresar id para editar:");
            
            var InsertId = Convert.ToInt32(ReadLine());

            var music = AppData.Instance.PieceList.Where(i => i.Id == InsertId).FirstOrDefault();
                
            Write("- Nombre: ");
            music.Name = ReadLine();

            Write("- Artista: ");
            music.Artist = ReadLine();

            Write("- Álbum: ");
            music.Album = ReadLine();


            int genderOption = 0;
            while(genderOption == 0 && genderOption < 3)
            {
                WriteLine("- Género: ");
                Write("    1. Música clásica: \n" + 
                        "    2. Rock: \n" + 
                        "    3. Raggeton:\n\n" +
                        "    Escoje [1-3]: ");

                if(Int32.TryParse(ReadLine(), out genderOption))
                {
                    switch (genderOption)
                    {
                        case 1:
                            music.Gender = Gender.Classical;
                            break;
                        case 2: 
                            music.Gender = Gender.Raggeton;
                            break;
                        case 3: 
                            music.Gender = Gender.Rock;
                            break;
                    }
                }
            }

            double duration = 0;
            while(duration == 0) 
            {
                Write("- Duración: ");

                if(Double.TryParse(ReadLine(), out duration)) 
                    music.Duration = duration;
            }


            var quality = 0;
            while(quality == 0) 
            {
                Write("- Calidad: \n" 
                        + "    1. Baja. \n"
                        + "    2. Media\n"
                        + "    3. Alta \n\n"
                        + "    Escoje [1-3]: ");
                
                if(Int32.TryParse(ReadLine(), out quality))
                {
                    switch (quality)
                    {
                        case 1: 
                            music.Quality = Quality.Low;
                            break;
                        case 2: 
                            music.Quality = Quality.Medium;
                            break;
                        case 3: 
                            music.Quality = Quality.High;
                            break;
                    }
                }
            }

            pieceList.Add(music);
        }
       
    }
}