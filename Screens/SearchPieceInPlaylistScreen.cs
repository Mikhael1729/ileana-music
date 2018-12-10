using static System.Console;
using System;
using IleanaMusic.Models;
using System.Linq;
using IleanaMusic.Data;
using System.Collections.Generic;


namespace IleanaMusic.Screens
{
    public class SearchPieceInPlaylistScreen
    {
        List<Playlist> playlists = AppData.Instance.Playlists;
        List<Piece> pieceList = AppData.Instance.PieceService.GetAll();
        Playlist searchedPlaylist;
        Piece searchedPiece;

        public SearchPieceInPlaylistScreen()
        {

            WriteLine("Buscar pieza en playlist\n"
                    + "------------------------\n");


            if (playlists.Count > 0)
            {
                Write("- Escribe el ID o el Nombre de la playlist: ");
                string option;
                string name = "";
                int id = 0;

                option = ReadLine();

                WriteLine("");

                // Si fue ID.
                if (Int32.TryParse(option, out id))
                {
                    searchedPlaylist = (playlists.Where(p => p.Id == id)).FirstOrDefault();
                }
                else  // Si fue nombre
                {
                    name = option;
                    searchedPlaylist = (playlists.Where(p => p.Name.ToLower() == name.ToLower())).FirstOrDefault();
                }

                if (searchedPlaylist != null)
                {
                    WriteLine($">> ¿Qué canción quieres buscar en la playlist \"{searchedPlaylist.Name}\"\n");

                    Write("- Escribe el ID o el Nombre de la canción: ");

                    string pieceOption;
                    string pieceName = "";
                    int pieceId = 0;

                    pieceOption = ReadLine();

                    WriteLine("");

                    // Si fue ID.
                    if (Int32.TryParse(pieceOption, out id))
                    {
                        searchedPiece = (pieceList.Where(p => p.Id == id)).FirstOrDefault();
                    }
                    else  // Si fue nombre
                    {
                        name = pieceOption;
                        searchedPiece = (pieceList.Where(p => p.Name.ToLower() == name.ToLower())).FirstOrDefault();
                    }

                    if (searchedPiece != null)
                    {
                        WriteLine(">> ¡Tu pieza ha sido encontada!\n");

                        WriteLine($"- ID: {searchedPiece.Id}");
                        WriteLine($"  Nombre: {searchedPiece.Name}");
                        WriteLine($"  Artista: {searchedPiece.Artist}");
                        WriteLine($"  Álbum: {searchedPiece.Album}");
                        Write($"  Género: Música ");
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

                        WriteLine($"  Duración: {searchedPiece.Duration} minutos");

                        Write($"  Calidad: ");
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

                        Write("  Formato: ");
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
                }
                else
                {
                    WriteLine(">> Playlist no encontrada");
                }
            }
            else
            {
                WriteLine(">> No tienes playlists en tu lista <<");
            }
        }

    }
}