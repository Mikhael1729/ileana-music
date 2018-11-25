using IleanaMusic.Data;
using IleanaMusic.Models;
using static System.Console;
using System;

namespace IleanaMusic.Screens
{
    public class AddPlayListScreen
    {
        Playlist playlist = new Playlist();

        public AddPlayListScreen()
        {
            var playlists = AppData.Instance.Playlists;

            WriteLine("Agregar nueva pieza\n"
                    + "-------------------\n");

            Write("- Nombre: ");
            playlist.Name = ReadLine();

            Write("- Artista: ");
            playlist.Logo = ReadLine();

            // Adding id.
            var id = 1;

            if (playlists.Count > 0)
            {
                id = playlists[playlists.Count - 1].Id + 1;
            }

            playlist.Id = id;
            playlists.Add(playlist);

            WriteLine("\n-->> Pieza agregada <<--\n");
        }
    }
}