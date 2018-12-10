using IleanaMusic.Data;
using IleanaMusic.Models;
using static System.Console;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IleanaMusic.Screens
{
    public class AddPlayListScreen
    {
        Playlist playlist = new Playlist();
        List<Piece> pieceList = AppData.Instance.PieceService.GetAll();

        public AddPlayListScreen()
        {
            var playlists = AppData.Instance.Playlists;

            WriteLine("Agregar nueva playlist \n"
                    + "----------------------\n");

            Write("- Nombre: ");
            playlist.Name = ReadLine();

            Write("- Logo: ");
            playlist.Logo = ReadLine();

            WriteLine("- Escribe los IDs de las piezas que quieres agregar a la playlist: \n");
            WriteLine("  >> Lista de piezas: \n");

            // Printing pieces.
            foreach (var piece in pieceList)
                WriteLine($"     - Id: {piece.Id}, Nombre: {piece.Name}");

            WriteLine("");

            // Requestin piece IDs.
            Write("  >> Escribe el id de las piezas a gregar (separados por coma): ");

            // Procesing.
            var ids = ReadLine();
            var list = ids.Split(',');

            // Adding selected pieces to playlist.
            foreach (var item in list)
            {
                var piece = pieceList.Where(p => p.Id == Convert.ToInt32(item.Trim())).FirstOrDefault();

                if (piece != null)
                    playlist.PieceList.Add(piece);
            }

            // Adding id.
            var id = 1;

            if (playlists.Count > 0)
            {
                id = playlists[playlists.Count - 1].Id + 1;
            }

            playlist.Id = id;
            playlists.Add(playlist);

            WriteLine("\n-->> Playlist agregada <<--\n");
        }
    }
}