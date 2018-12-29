using IleanaMusic.Data;
using IleanaMusic.Data.Services;
using IleanaMusic.Helpers;
using IleanaMusic.Models;
using System;
using System.Collections.Generic;
using static IleanaMusic.Helpers.PlaylistFragments;

namespace IleanaMusic.Screens
{
    public class AddPlayListScreen
    {
        PlaylistService playlistService = AppData.Instance.PlaylistService;
        Playlist playlist = new Playlist();
        List<Piece> pieceList = PieceService.Instance.GetAll();

        public AddPlayListScreen()
        {
            var writer = new ConsoleWriter(0);

            writer.Write("Agregar nueva playlist \n"
                    + "----------------------\n\n");

            RequestName(ref playlist, writer);
            RequestLogo(ref playlist, writer);
            RequestPieces(ref playlist, writer);

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