using static System.Console;
using System;
using IleanaMusic.Models;
using System.Linq;
using IleanaMusic.Data;
using System.Collections.Generic;
using IleanaMusic.Data.Services;

namespace IleanaMusic.Screens
{
    public class SearchPlaylistScreen
    {
        PlaylistService playlistService = AppData.Instance.PlaylistService;
        Playlist searchedPlaylist;

        public SearchPlaylistScreen()
        {

            WriteLine("Buscar playlist\n"
                    + "-----------------\n");

            if (playlistService.Count() > 0)
            {
                Write("Escribe el ID o el Nombre de tu playlist: ");
                string option;
                string name = "";
                int id = 0;

                option = ReadLine();

                WriteLine("");

                // Si fue ID.
                if (Int32.TryParse(option, out id))
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
                    WriteLine(">> ¡Playlist encontrada!\n");

                    WriteLine($"- ID: {searchedPlaylist.Id}");
                    WriteLine($"- Logo: {searchedPlaylist.Logo}");
                    WriteLine($"- Nombre: {searchedPlaylist.Name}");
                    WriteLine($"- Cantidad de canciones: {searchedPlaylist.PieceList.Count}");
                }
                else
                {
                    WriteLine(">> Playlist no encontrada");
                }
            }
            else
            {
                WriteLine(">> No tienes playlists en tu lista <<");
            }
        }

    }
}