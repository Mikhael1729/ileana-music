using System;
using System.Collections.Generic;
using System.Linq;
using IleanaMusic.Data;
using IleanaMusic.Models;
using static System.Console;

// TODO:
namespace IleanaMusic
{
    public class SearchPieceScreen
    {
        List<Piece> pieceList = AppData.Instance.PieceList;
        Piece searchedPiece;

        public SearchPieceScreen()
        {

            WriteLine("Buscar canción\n"
                    + "--------------\n");

            Write("Escribe el ID o el Nombre de tu canción: ");

            if (pieceList.Count > 0)
            {
                string option;
                string name = "";
                int id = 0;

                option = ReadLine();

                WriteLine("");

                // Si fue ID.
                if (Int32.TryParse(option, out id))
                {
                    searchedPiece = (pieceList.Where(p => p.Id == id)).FirstOrDefault();
                }
                else  // Si fue nombre
                {
                    name = option;
                    searchedPiece = (pieceList.Where(p => p.Name.ToLower() == name.ToLower())).FirstOrDefault();
                }

                if (searchedPiece != null)
                {
                    WriteLine(">> ¡Pieza encontrada!\n");

                    WriteLine($"  ID: {searchedPiece.Id}");
                    WriteLine($"1. Nombre: {searchedPiece.Name}");
                    WriteLine($"2. Artista: {searchedPiece.Artist}");
                    WriteLine($"3. Álbum: {searchedPiece.Album}");
                    Write($"4. Género: Música ");
                    switch (searchedPiece.Gender)
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

                    WriteLine($"- Duración: {searchedPiece.Duration} minutos");

                    Write($"- Calidad: ");
                    switch (searchedPiece.Quality)
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

                    Write("- Formato: ");
                    switch (searchedPiece.Format)
                    {
                        case MusicFormat.Mp3:
                            Write("Mp3");
                            break;
                        case MusicFormat.Mp4:
                            Write("Mp4");
                            break;
                    }

                    WriteLine("");
                }
                else
                {
                    WriteLine(">> Canción no encontrada");
                }
            }
            else
            {
                WriteLine(">> No tienes canciones en tu lista <<");
            }
        }

    }
}