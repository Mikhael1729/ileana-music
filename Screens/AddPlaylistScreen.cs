using IleanaMusic.Data;
using IleanaMusic.Models;
using static System.Console;
using System;
using System.Collections.Generic;

namespace IleanaMusic.Screens
{
    public class AddPlayListScreen
    {
        Playlist playlist = new Playlist();

        public AddPlayListScreen()
        {
            var playlists = AppData.Instance.Playlists;

            WriteLine("Agregar nueva playlist \n"
                    + "----------------------\n");

            Write("- Nombre: ");
            playlist.Name = ReadLine();

            Write("- Logo: ");
            playlist.Logo = ReadLine();

            WriteLine("- Escribe los IDs de las piezas que quieres agregar a la playlist: \n");
            Write("  ");
            // var ids = ReadLin
            // string ids = "4,5, 6,7";
            // var list = ids.Split(',');
            // foreach (var item in list)
            // {
            //     Console.WriteLine("-" + item.Trim());
            // }

            // Adding id.
            var id = 1;

            if (playlists.Count > 0)
            {
                id = playlists[playlists.Count - 1].Id + 1;
            }

            playlist.Id = id;
            playlists.Add(playlist);

            WriteLine("\n-->> Playlist agregada <<--\n");
        }
    }
}