using System;
using System.Collections.Generic;
using System.Linq;
using IleanaMusic.Data;
using IleanaMusic.Models;
using static System.Console;
using IleanaMusic.Helpers;

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
                        pieceId = piece.Id;
                        WriteLine(">> ¡Pieza encontrada!\n");

                        // Printing piece.
                        piece.Print(withNumeration: true, spaceQuantity: 3);

                        var writer = new ConsoleWriter(3);

                        writer.Write(text:"¿Qué campos quieres editar? (separa con coma): ", spaceBefore: true);
                        var options = ReadLine();
                        var selected = options.Split(',');

                        WriteLine("");

                        RequestPieceData(selected, writer);
                    }
                    else
                    {
                        WriteLine("\n>> Canción no encontrada <<\n");
                    }
                }
            }
            else
            {
                WriteLine(">> Tu lista de canciones está vacía. Agrega una para habilitar esta sección");
            }
        }

        private void RequestPieceData(string[] fields, ConsoleWriter consoleWriter = null)
        {
            var writer = consoleWriter != null ? consoleWriter : new ConsoleWriter(0);

            foreach (var i in fields)
            {
                var n = Convert.ToInt32(i.Trim());

                switch (n)
                {
                    case 1:
                        writer.Write("- Nombre: ");
                        piece.Name = ReadLine();
                        break;
                    case 2:
                        writer.Write("- Artista: ");
                        piece.Artist = ReadLine();
                        break;
                    case 3:
                        writer.Write("- Álbum");
                        piece.Album = ReadLine();
                        break;
                    case 4:
                        int genderOption = 0;
                        while (genderOption == 0 && genderOption < 3)
                        {
                            writer.Write("- Género: \n");
                            writer.Write("    1. Música clásica\n");
                            writer.Write("    2. Rock: \n");
                            writer.Write("    3. Raggeton:\n\n");
                            writer.Write("    Escoje [1-3]: ");

                            if (Int32.TryParse(ReadLine(), out genderOption))
                            {
                                switch (genderOption)
                                {
                                    case 1:
                                        piece.Gender = Gender.Classical;
                                        break;
                                    case 2:
                                        piece.Gender = Gender.Rock;
                                        break;
                                    case 3:
                                        piece.Gender = Gender.Raggeton;
                                        break;
                                }
                            }
                        }
                        break;
                    case 5:
                        double duration = 0;
                        while (duration == 0)
                        {
                            writer.Write("- Duración: ");

                            if (Double.TryParse(ReadLine(), out duration))
                                piece.Duration = duration;
                        }
                        break;
                    case 6:
                        var quality = 0;
                        while (quality == 0)
                        {
                            writer.Write("- Calidad: \n");
                            writer.Write(text: $"1. Baja. \n", indent: 1);
                            writer.Write(text: $"2. Media\n", indent: 1);
                            writer.Write(text: $"3. Alta \n\n", indent: 1);
                            writer.Write(text: $"Escoje [1-3]: ", indent: 1);

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
                        break;
                    case 7:
                        var formatOption = 0;
                        writer.Write("- Formato: \n");
                        writer.Write(text:"1. Mp3\n", indent: 1);
                        writer.Write(text:"2. Mp4\n\n", indent: 1);
                        writer.Write(text:"Escoge [1-2]: ", indent: 1);

                        if (Int32.TryParse(ReadLine(), out formatOption))
                        {
                            switch (formatOption)
                            {
                                case 1:
                                    piece.Format = MusicFormat.Mp3;
                                    break;
                                case 2:
                                    piece.Format = MusicFormat.Mp4;
                                    break;
                            }
                        }
                        break;
                }
            }

            writer.Write(
                text: "-->> Pieza editada <<--\n", 
                spaceBefore: true,
                cancelSpace: true
            );
        }
    }
}