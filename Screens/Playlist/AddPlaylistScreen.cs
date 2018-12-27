using IleanaMusic.Data;
using IleanaMusic.Models;
using static System.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using IleanaMusic.Data.Services;
using IleanaMusic.Helpers;

namespace IleanaMusic.Screens
{
    public class AddPlayListScreen
    {
        Playlist playlist = new Playlist();
        PlaylistService playlistService = AppData.Instance.PlaylistService;
        List<Piece> pieceList = AppData.Instance.PieceService.GetAll();

        public AddPlayListScreen()
        {
            var writer = new ConsoleWriter(0);

            writer.Write("Agregar nueva playlist \n"
                    + "----------------------\n\n");

            PlaylistFragments.RequestName(ref playlist, writer);
            PlaylistFragments.RequestLogo(ref playlist, writer);
            PlaylistFragments.RequestPieces(ref playlist, writer);

            // Adding id.
            playlistService.Add(playlist);

            WriteLine("\n-->> Playlist agregada <<--\n");
        }
    }
}