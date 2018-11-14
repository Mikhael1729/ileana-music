using static System.Console;
using IleanaMusic.Models;
using System;
using IleanaMusic.Data;

namespace IleanaMusic.Screens
{
    public class AddPieceScreen 
    {
        Piece piece;

        public AddPieceScreen() 
        {
            var pieceList = AppData.Instance.PieceList;

            piece = new Piece();

            WriteLine("Agregar nueva pieza\n" 
                    + "-------------------\n");
            
            Write("- Nombre: ");
            piece.Name = ReadLine();

            Write("- Artista: ");
            piece.Artist = ReadLine();

            Write("- Álbum: ");
            piece.Album = ReadLine();


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
                            piece.Gender = Gender.Classical;
                            break;
                        case 2: 
                            piece.Gender = Gender.Raggeton;
                            break;
                        case 3: 
                            piece.Gender = Gender.Rock;
                            break;
                    }
                }
            }

            double duration = 0;
            while(duration == 0) 
            {
                Write("- Duración: ");

                if(Double.TryParse(ReadLine(), out duration)) 
                    piece.Duration = duration;
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
                            piece.Quality = Quality.Low;
                            break;
                        case 2: 
                            piece.Quality = Quality.Medium;
                            break;
                        case 3: 
                            piece.Quality = Quality.High;
                            break;
                    }
                }
            }

            // Adding id.
            var id = 1;

            if(pieceList.Count > 0) {
                id = pieceList[pieceList.Count-1].Id + 1;
            }

            piece.Id = id;
            pieceList.Add(piece);
          
            WriteLine("\n-->> Pieza agregada <<--\n");
        }

        public Piece Data() 
        {
            return piece;
        }
    }
}