using IleanaMusic.Data;
using IleanaMusic.Models;
using static System.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using IleanaMusic.Data.Services;
using IleanaMusic.Helpers;
using static IleanaMusic.Helpers.ConsoleWriter;

namespace IleanaMusic.Screens
{
    public class AddPlayListScreen
    {
        PlaylistService playlistService = AppData.Instance.PlaylistService;
        Playlist playlist = new Playlist();
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
            try
            {
                playlistService.Add(playlist);
                writer.WriteLine(
                    text: "-->> Playlist agregada <<--\n", 
                    spaceBefore:true
                );
            } 
            catch(InvalidOperationException e)
            {
                writer.WriteLine(
                    text: $">> OPERACIÓN BLOQUEADA: {e.Message} <<",
                    spaceBefore: true
                );
            }
        }
    }
}