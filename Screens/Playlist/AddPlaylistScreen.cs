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

            writer.WriteLine(
                "Agregar nueva playlist \n" +
                "----------------------\n"
            );

            var validName = false;
            var validLogo = false;
            var validPieces = false;

            validName = RequestName(ref playlist, writer);

            if(validName)
            {
                validLogo = RequestLogo(ref playlist, writer);
                validPieces = RequestPieces(ref playlist, writer);

                writer.WriteLine("");

                if(validPieces)
                {
                    playlistService.Add(playlist);

                    writer.WriteLine(
                        text: "-->> Playlist agregada <<--\n",
                        spaceBefore: true
                    );
                }
            }

            if (!validName || !validPieces)
            {
                writer.WriteLine("\n[INSERCIÓN CANCELADA]\n");

                if(!validName)
                    writer.WriteLine(
                         text: $"- No se puede tener una lista de reproducción con el nombre de otra ya existente <<"
                    );

                if (!validPieces)
                    writer.WriteLine(
                        text: $"- No está permitido agregar una playlist sin canciones"
                    );
            }
        }
    }
}