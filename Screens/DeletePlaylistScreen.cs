using static System.Console;
using System;
using IleanaMusic.Models;
using System.Linq;
using IleanaMusic.Data;
using System.Collections.Generic;

namespace IleanaMusic.Screens
{
    public class DeletePlaylitScreen
    {
        List<Playlist> playlists = AppData.Instance.Playlists;
        Playlist searchedPlaylist;

        public DeletePlaylitScreen()
        {

            WriteLine("Eliminar playlist\n"
                    + "-----------------\n");

            Write("Escribe el ID o el Nombre de tu playlist: ");

            if (playlists.Count > 0)
            {
                string option;
                string name = "";
                int id = 0;

                option = ReadLine();

                WriteLine("");

                // Si fue ID.
                if (Int32.TryParse(option, out id))
                {
                    searchedPlaylist = (playlists.Where(p => p.Id == id)).FirstOrDefault();
                }
                else  // Si fue nombre
                {
                    name = option;
                    searchedPlaylist = (playlists.Where(p => p.Name == name)).FirstOrDefault();
                }

                if (searchedPlaylist != null)
                {
                    WriteLine(">> Playlist eliminada");
                    playlists.Remove(searchedPlaylist);
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