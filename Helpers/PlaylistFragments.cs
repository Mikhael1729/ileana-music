using IleanaMusic.Models;

namespace IleanaMusic.Helpers
{
    public static class PlaylistFragments
    {
        public static void PrintPlaylist(Playlist playlist, ConsoleWriter consoleWriter = null)
        {
            var writer = consoleWriter != null ? consoleWriter : new ConsoleWriter(0);

            writer.Write($"- ID: {playlist.Id}");
            writer.Write($"  Logo: {playlist.Logo}");
            writer.Write($"  Nombre: {playlist.Name}");
            writer.Write($"  Cantidad de canciones: {playlist.PieceList.Count}");
        }
    }
}