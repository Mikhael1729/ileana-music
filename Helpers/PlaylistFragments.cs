using System;
using System.Linq;
using IleanaMusic.Data;
using IleanaMusic.Models;
using static System.Console;

namespace IleanaMusic.Helpers
{
    public static class PlaylistFragments
    {
        public static void PrintPlaylist(Playlist playlist, ConsoleWriter consoleWriter = null)
        {
            var writer = consoleWriter != null ? consoleWriter : new ConsoleWriter(0);

            writer.Write($"- ID: {playlist.Id}\n");
            writer.Write($"  Logo: {playlist.Logo}\n");
            writer.Write($"  Nombre: {playlist.Name}\n");
            writer.Write($"  Cantidad de canciones: {playlist.PieceList.Count}\n");
        }

        public static void RequestName(ref Playlist playlist, ConsoleWriter consoleWriter = null)
        {
            var writer = consoleWriter != null ? consoleWriter : new ConsoleWriter(0);

            writer.Write("- Nombre: ");
            playlist.Name = ReadLine();
        }

        public static void RequestLogo(ref Playlist playlist, ConsoleWriter consoleWriter = null)
        {
            var writer = consoleWriter != null ? consoleWriter : new ConsoleWriter(0);

            writer.Write("- Logo: ");
            playlist.Logo = ReadLine();
        }

        public static void RequestPieces(ref Playlist playlist, ConsoleWriter consoleWriter = null)
        {
            // Procesing.
            var ids = ReadLine();
            var list = ids.Split(',');

            // Adding selected pieces to playlist.
            foreach (var item in list)
            {
                var piece = AppData.Instance.PieceService.Get(Convert.ToInt32(item.Trim()));

                if (piece != null)
                    playlist.PieceList.Add(piece);
            }
        }
    }
}