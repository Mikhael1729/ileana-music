using static System.Console;
using System;
using IleanaMusic.Models;
using System.Linq;
using IleanaMusic.Data;
using System.Collections.Generic;
using IleanaMusic.Data.Services;
using IleanaMusic.Helpers;

namespace IleanaMusic.Screens
{
    public class SearchPieceInPlaylistScreen
    {
        PlaylistService playlistService = AppData.Instance.PlaylistService;
        PieceService pieceService = PieceService.Instance;
        Playlist searchedPlaylist;
        Piece searchedPiece;

        public SearchPieceInPlaylistScreen()
        {

            WriteLine("Buscar pieza en playlist\n"
                    + "------------------------\n");


            if (playlistService.Count() > 0)
            {
                Write("- Escribe el ID o el Nombre de la playlist: ");
                string option;
                string name = "";
                var writer = new ConsoleWriter(0);

                option = ReadLine();

                WriteLine("");

                // If you wrote an ID.
                if (Int32.TryParse(option, out int id))
                {
                    searchedPlaylist = playlistService.Get(id);
                }
                else // If you wrote a Name.
                {
                    name = option;
                    searchedPlaylist = playlistService.Find(p => p.Name.ToLower() == name.ToLower());
                }

                if (searchedPlaylist != null)
                {
                    writer.Write(
                        $"- ¿Qué canción quieres buscar en la playlist \"{searchedPlaylist.Name}\"? (Escribe el ID o el Nombre): "
                    );

                    string pieceOption;
                    
                    pieceOption = ReadLine();

                    WriteLine("");

                    // Si fue ID.
                    if (Int32.TryParse(pieceOption, out id))
                    {
                        searchedPiece = pieceService.Get(id);
                    }
                    else  // Si fue nombre
                    {
                        name = pieceOption;
                        searchedPiece = pieceService.Find(p => p.Name.ToLower() == name.ToLower());
                    }

                    if (searchedPiece != null)
                    {
                        WriteLine("[Pieza encontrada]\n");

                        searchedPiece.Print();
                        WriteLine("");
                    } 
                    else 
                    {
                        WriteLine(">> No se encontraron resultados <<\n");
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