using IleanaMusic.Data;
using IleanaMusic.Data.Services;
using IleanaMusic.Helpers;
using IleanaMusic.Models;
using System;
using static System.Console;

namespace IleanaMusic.Screens
{
    public class SearchPlaylistScreen
    {
        PlaylistService playlistService = AppData.Instance.PlaylistService;
        Playlist searchedPlaylist;

        public SearchPlaylistScreen()
        {
            var writer = new ConsoleWriter(0);

            writer.WriteLine(
                "Buscar playlist\n"+ 
                "---------------\n"
            );

            if (playlistService.Count() > 0)
            {
                writer.Write("Escribe el ID o el Nombre de tu playlist: ");
                string option;
                string name = "";

                option = ReadLine();

                writer.WriteLine("");

                // Si fue ID.
                if (Int32.TryParse(option, out int id))
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
                        ">> ¡Playlist encontrada!\n"
                    );

                    writer.WriteLine(
                      $"- ID: {searchedPlaylist.Id}\n" +
                      $"- Logo: {searchedPlaylist.Logo}\n" +
                      $"- Nombre: {searchedPlaylist.Name}\n" +
                      $"- Piezas: {searchedPlaylist.PieceList.Count}\n"
                    );

                    var pieces = searchedPlaylist.PieceList;

                    // Printing pieces
                    foreach (var piece in pieces)
                        writer.WriteLine(
                            text: $"- ID: {piece.Id}, Nombre: {piece.Name}, Artista: {piece.Artist}", 
                            indent: 1
                        );
                }
                else
                {
                    writer.WriteLine(">> Playlist no encontrada");
                }
            }
            else
            {
                writer.WriteLine(">> No tienes playlists en tu lista <<");
            }
        }

    }
}