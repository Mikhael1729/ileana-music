using static System.Console;
using IleanaMusic.Models;
using System;
using IleanaMusic.Data;
using System.Linq;
using System.Collections.Generic;

namespace IleanaMusic.Screens
{
    public class PieceList
    {
        List<Piece> pieces = AppData.Instance.PieceList;

        public PieceList()
        {
            WriteLine(
                "Lista de canciones\n"
               + "------------------\n");

            if (pieces.Count > 0)
            {
                foreach (var piece in AppData.Instance.PieceList)
                {
                    WriteLine($"- ID: {piece.Id}");
                    WriteLine($"  Nombre: {piece.Name}");
                    WriteLine($"  Artista: {piece.Artist}");
                    WriteLine($"  Álbum: {piece.Album}");
                    Write($"  Género: Música ");
                    switch (piece.Gender)
                    {
                        case Gender.Classical:
                            Write("Clásica");
                            break;
                        case Gender.Raggeton:
                            Write("Raggeton");
                            break;
                        case Gender.Rock:
                            Write("Rock");
                            break;
                    }

                    WriteLine("");

                    WriteLine($"  Duración: {piece.Duration} minutos");

                    Write($"  Calidad: ");
                    switch (piece.Quality)
                    {
                        case Quality.High:
                            Write("Alta");
                            break;
                        case Quality.Low:
                            Write("Baja");
                            break;
                        case Quality.Medium:
                            Write("Media");
                            break;
                    }

                    WriteLine("");

                    Write("  Formato: ");
                    switch (piece.Format)
                    {
                        case MusicFormat.Mp3:
                            Write("Mp3");
                            break;
                        case MusicFormat.Mp4:
                            Write("Mp4");
                            break;
                    }

                    WriteLine("");
                    WriteLine("");
                }

            }
            else
            {
                WriteLine("\n >> Lista vacía <<");
            }
        }
    }
}