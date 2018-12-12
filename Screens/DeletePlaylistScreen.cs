using static System.Console;
using System;
using IleanaMusic.Models;
using System.Linq;
using IleanaMusic.Data;
using System.Collections.Generic;
using IleanaMusic.Data.Services;

namespace IleanaMusic.Screens
{
    public class DeletePlaylitScreen
    {
        PlaylistService playlistService = AppData.Instance.PlaylistService;

        List<Playlist> playlists = AppData.Instance.Playlists;
        Playlist searchedPlaylist;

        public DeletePlaylitScreen()
        {

            WriteLine("Eliminar playlist\n"
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
                    searchedPlaylist = (playlistService.Find(p => p.Name.ToLower() == name.ToLower()));
                }

                if (searchedPlaylist != null)
                {
                    WriteLine($">> La playlist llamada \"{searchedPlaylist.Name}\" ha sido eliminada");
                    playlistService.Delete(searchedPlaylist);
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