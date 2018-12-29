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
                int id = 0;
                var writer = new ConsoleWriter(0);

                option = ReadLine();

                WriteLine("");

                // Si fue ID.
                if (Int32.TryParse(option, out id))
                {
                    searchedPlaylist = playlistService.Get(id);
                }
                else  // Si fue nombre
                {
                    name = option;
                    searchedPlaylist = playlistService.Find(p => p.Name.ToLower() == name.ToLower());
                }

                if (searchedPlaylist != null)
                {
                    writer.WriteLine(
                        text:$">> ¿Qué canción quieres buscar en la playlist \"{searchedPlaylist.Name}\"?\n",
                        indent: 1);

                    writer.Write("- Escribe el ID o el Nombre de la canción: ", indent:2);

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
                        WriteLine(">> ¡Tu pieza ha sido encontada!\n");

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