using System;
using System.Collections.Generic;
using System.Linq;
using IleanaMusic.Data;
using IleanaMusic.Models;
using static System.Console;

namespace IleanaMusic.Screens
{
    public class EditPieceScreen
    {
        List<Piece> pieceList = AppData.Instance.PieceList;
        Piece piece;

        public EditPieceScreen()
        {
            // Title
            WriteLine(
                "Edita una canción\n"
               + "-----------------\n");

            // Requesting Id.
            int pieceId = 0;

            if (pieceList.Count > 0)
            {
                while (pieceId == 0)
                {
                    Write("Escribe el ID o el Nombre de tu canción: ");

                    string option;
                    string name = "";
                    int id = 0;

                    option = ReadLine();

                    WriteLine("");

                    // Si fue ID.
                    if (Int32.TryParse(option, out id))
                    {
                        piece = (pieceList.Where(p => p.Id == id)).FirstOrDefault();
                    }
                    else  // Si fue nombre
                    {
                        name = option;
                        piece = (pieceList.Where(p => p.Name.ToLower() == name.ToLower())).FirstOrDefault();
                    }

                    if (piece != null)
                    {
                        WriteLine(">> ¡Pieza encontrada!\n");

                        piece.Print();
                    }

                    if (Int32.TryParse(ReadLine(), out pieceId))
                    {
                        piece = pieceList.Where(i => i.Id == pieceId).FirstOrDefault();
                    }
                }

                if (piece == null)
                {
                    WriteLine("\n>> Canción no encontrada <<\n");
                }
                else
                {
                    WriteLine($"\n >> Editando la pieza \"{piece.Name}\" <<\n");

                    Write("- Nombre: ");
                    piece.Name = ReadLine();

                    Write("- Artista: ");
                    piece.Artist = ReadLine();

                    Write("- Álbum: ");
                    piece.Album = ReadLine();


                    int genderOption = 0;
                    while (genderOption == 0 && genderOption < 3)
                    {
                        WriteLine("- Género: ");
                        Write("    1. Música clásica: \n" +
                                "    2. Rock: \n" +
                                "    3. Raggeton:\n\n" +
                                "    Escoje [1-3]: ");

                        if (Int32.TryParse(ReadLine(), out genderOption))
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
                    while (duration == 0)
                    {
                        Write("- Duración: ");

                        if (Double.TryParse(ReadLine(), out duration))
                            piece.Duration = duration;
                    }


                    var quality = 0;
                    while (quality == 0)
                    {
                        Write("- Calidad: \n"
                                + "    1. Baja. \n"
                                + "    2. Media\n"
                                + "    3. Alta \n\n"
                                + "    Escoje [1-3]: ");

                        if (Int32.TryParse(ReadLine(), out quality))
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

                    WriteLine("\n-->> Pieza editada <<--\n");

                }
            }
            else
            {
                WriteLine(">> Tu lista de canciones está vacía. Agrega una para habilitar esta sección");
            }
        }
    }
}