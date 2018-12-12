using System;
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

        public PlaylistFragments() 
        {
        }

        public static void PrintPlaylist(Playlist playlist, ConsoleWriter consoleWriter = null, bool withNumeration = false, bool withPieces = false)
        {
            var writer = consoleWriter != null ? consoleWriter : new ConsoleWriter(0);
            var option = withNumeration;

            writer.Write($"{(!option ? "- " : "   ")}ID: {playlist.Id}\n");
            writer.Write($"{(!option ? "  " : "1. ")}Logo: {playlist.Logo}\n");
            writer.Write($"{(!option ? "  " : "2. ")}Nombre: {playlist.Name}\n");

            if (!withPieces)
            {
                writer.Write($"{(!option ? "  " : "3. ")}Cantidad de canciones: {playlist.PieceList.Count}\n");
            }
            else
            {
                writer.Write($"{(!option ? "  " : "3. ")}Piezas: \n");
                PrintPlaylistPieces(playlist, writer, 3);
            }
        }

        public static void PrintPlaylistPieces(Playlist playlist, ConsoleWriter consoleWriter = null, int indent = 0)
        {
            var writer = consoleWriter != null ? consoleWriter : new ConsoleWriter(0);

            // Printing pieces of playlist.
            foreach (var piece in playlist.PieceList)
            {
                writer.WriteLine(
                    text:$"- ID: {piece.Id}, Nombre: {piece.Name}",
                    indent: indent);
            }
        }

        public static void RequestName(ref Playlist playlist, ConsoleWriter consoleWriter = null, int indent = 0)
        {
            var writer = consoleWriter != null ? consoleWriter : new ConsoleWriter(0);

            writer.Write(text:"- Nombre: ", indent:indent);
            playlist.Name = ReadLine();
        }

        public static void RequestLogo(ref Playlist playlist, ConsoleWriter consoleWriter = null, int indent = 0)
        {
            var writer = consoleWriter != null ? consoleWriter : new ConsoleWriter(0);

            writer.Write(text:"- Logo: ", indent: indent);
            playlist.Logo = ReadLine();
        }

        public static void RequestPieces(ref Playlist playlist, ConsoleWriter consoleWriter = null, int indent = 0)
        {
            var writer = consoleWriter != null ? consoleWriter : new ConsoleWriter(0);

            writer.Write("- Escribe los IDs de las piezas que quieres agregar a la playlist: \n", indent: indent+1);
            writer.Write(
                text: ">> Lista de piezas: \n",
                indent: indent+2);

            // Printing pieces.
            foreach (var piece in pieceService.GetAll())
                writer.Write(
                    text: $"- Id: {piece.Id}, Nombre: {piece.Name}\n",
                    indent: indent+3);

            WriteLine("");

            // Requestin piece IDs.
            writer.Write(
                text: ">> Escribe el id de las piezas a gregar (separados por coma): ",
                indent: indent+2);

            // Procesing.
            var ids = ReadLine();
            var list = ids.Split(',');

            // Adding selected pieces to playlist.
            foreach (var item in list)
            {
                var piece = pieceService.Get(Convert.ToInt32(item.Trim()));

                if (piece != null)
                {
                    playlist.PieceList.Clear();
                    playlist.PieceList.Add(piece);
                }
            }
        }
    }
}