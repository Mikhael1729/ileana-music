using static System.Console;
using System;
using IleanaMusic.Models;
using System.Linq;
using IleanaMusic.Data;
using System.Collections.Generic;


namespace IleanaMusic.Screens
{
    public class SearchPlaylistScreen
    {
        List<Playlist> playlists = AppData.Instance.Playlists;
        Playlist searchedPlaylist;

        public SearchPlaylistScreen()
        {

            WriteLine("Buscar playlist\n"
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
                    searchedPlaylist = (playlists.Where(p => p.Name.ToLower() == name.ToLower())).FirstOrDefault();
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