using System;
using System.Collections.Generic;
using System.Linq;
using IleanaMusic.Data;
using IleanaMusic.Data.Services;
using IleanaMusic.Models;
using static System.Console;

namespace IleanaMusic.Helpers
{
    public class PlaylistFragments
    {
        static PieceService pieceService = AppData.Instance.PieceService;
        static PlaylistService playlistService = AppData.Instance.PlaylistService;

        public PlaylistFragments()
        {
        }

        public static void PrintPlaylist(Playlist playlist, ConsoleWriter consoleWriter = null, bool withNumeration = false, bool withPieces = false, int indentation=0)
        {
            var writer = consoleWriter ?? new ConsoleWriter(0);
            var option = withNumeration;

            writer.Write(
                text: $"{(!option ? "- " : "   ")}ID: {playlist.Id}\n",
                indent: indentation
            );
            writer.Write(
                text: $"{(!option ? "  " : "1. ")}Logo: {playlist.Logo}\n",
                indent: indentation
            );
            writer.Write(
                text: $"{(!option ? "  " : "2. ")}Nombre: {playlist.Name}\n",
                indent: indentation
            );

            if (!withPieces)
            {
                writer.Write(
                    text:$"{(!option ? "  " : "3. ")}Cantidad de canciones: {playlist.PieceList.Count}\n",
                    indent: indentation
                );
            }
            else
            {
                writer.Write(
                    text: $"{(!option ? "  " : "3. ")}Piezas: \n",
                    indent: indentation
                );
                PrintPlaylistPieces(playlist, writer, indentation);
            }
        }

        public static void PrintPlaylistPieces(Playlist playlist, ConsoleWriter consoleWriter = null, int indent = 0)
        {
            var writer = consoleWriter != null ? consoleWriter : new ConsoleWriter(0);

            // Printing pieces of playlist.
            foreach (var piece in playlist.PieceList)
            {
                writer.WriteLine(
                    text: $"- ID: {piece.Id}, Nombre: {piece.Name}",
                    indent: indent + 1);
            }
        }

        public static void PrintOneLinePieces(List<Piece> pieceList, ConsoleWriter consoleWriter = null, int indent = 0)
        {
            var writer = consoleWriter != null ? consoleWriter : new ConsoleWriter(0);

            // Printing pieces of playlist.
            foreach (var piece in pieceList)
            {
                writer.WriteLine(
                    text: $"- ID: {piece.Id}, Nombre: {piece.Name}",
                    indent: indent);
            }
        }


        public static void RequestName(ref Playlist playlist, ConsoleWriter consoleWriter = null, int indent = 0)
        {
            var writer = consoleWriter != null ? consoleWriter : new ConsoleWriter(0);

            writer.Write(text: "- Nombre: ", indent: indent);
            playlist.Name = ReadLine();
        }

        public static void RequestLogo(ref Playlist playlist, ConsoleWriter consoleWriter = null, int indent = 0)
        {
            var writer = consoleWriter != null ? consoleWriter : new ConsoleWriter(0);

            writer.Write(text: "- Logo: ", indent: indent);
            playlist.Logo = ReadLine();
        }

        public static void RequestPieces(ref Playlist playlist, ConsoleWriter consoleWriter = null, int indent = 0)
        {
            var writer = consoleWriter != null ? consoleWriter : new ConsoleWriter(0);

            writer.Write("- Escribe los IDs de las piezas que quieres agregar a la playlist: \n", indent: indent);
            writer.Write(
                text: ">> Lista de piezas: \n",
                indent: indent + 1);

            // Printing pieces.
            foreach (var piece in pieceService.GetAll())
                writer.Write(
                    text: $"- Id: {piece.Id}, Nombre: {piece.Name}\n",
                    indent: indent + 2);


            WriteLine("");

            // Requestin piece IDs.
            writer.Write(
                text: ">> Escribe el id de las piezas a gregar (separados por coma): ",
                indent: indent + 1);

            // Procesing.
            var ids = ReadLine();
            var list = ids.Split(',');

            // Adding selected pieces to playlist.
            playlist.PieceList.Clear();
            foreach (var item in list)
            {
                var piece = pieceService.Get(Convert.ToInt32(item.Trim()));

                if (piece != null)
                {
                    playlist.PieceList.Add(piece);
                }
            }
        }

        public static void EditPlaylistPieces(ref Playlist playlist, ConsoleWriter consoleWriter = null, int indent = 0)
        {

            for (int i = 0; i < playlist.PieceList.Count; i++)
                playlist.PieceList[i] = pieceService.Get(playlist.PieceList[i].Id);

            var writer = consoleWriter != null ? consoleWriter : new ConsoleWriter(0);

            writer.WriteLine(
                text: "- Editando \"Piezas\"\n",
                indent: indent + 1);

            writer.WriteLine(
                text: "1. Agregar pieza",
                indent: indent + 2);

            writer.WriteLine(
                text: "2. Eliminar pieza\n",
                indent: indent + 2
            );

            writer.Write(
                text: "Escoge [1 y/o 2]: ",
                indent: indent + 2);

            var options = ConsoleReader.ReadNumberOptions();

            /* Piece list */

            writer.WriteLine(
                text: "[Lista de piezas]\n",
                indent: indent + 2,
                spaceBefore: true
            );

            var j = pieceService.GetAll();

            PrintOneLinePieces(
                consoleWriter: writer,
                pieceList: j,
                indent: indent + 2
            );

            foreach (var i in options)
            {
                // Add piece to playlist.
                if (i == 1)
                {
                    writer.WriteLine(
                        text: "[Agregar piezas]\n",
                        indent: indent + 2,
                        spaceBefore: true
                    );

                    writer.Write(
                        text: "- Escribe sus id, separados por coma: ", 
                        indent: indent + 2
                    );

                    var pieceIds = ConsoleReader.ReadNumberOptions();
                    foreach (var id in pieceIds)
                    {
                        var piece = pieceService.Get(id);

                        if (piece != null)
                            playlist.PieceList.Add(piece);
                    }
                }
                // If you want to remove a piece from playlist.PieceList.
                else if (i == 2)
                {
                    writer.WriteLine(
                        text: "[Eliminar piezas]\n",
                        indent: indent + 2,
                        spaceBefore: true
                    );

                    writer.Write(
                        text: "- Escribe sus id separados por coma: ",
                        indent: indent + 2
                    );

                    var pieceIds = ConsoleReader.ReadNumberOptions();

                    foreach (var id in pieceIds)
                    {
                        var piece = playlist.PieceList.Where(p => p.Id == id).FirstOrDefault();

                        if (piece != null)
                            playlist.PieceList.Remove(piece);
                    }
                }
            }
        }
    }
}