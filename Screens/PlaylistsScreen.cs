using System.Collections.Generic;
using IleanaMusic.Data;
using IleanaMusic.Models;
using static System.Console;

namespace IleanaMusic.Screens
{
    public class PlaylistsScreen 
    {
        List<Playlist> playlists = AppData.Instance.Playlists;

        public PlaylistsScreen() 
        {
            WriteLine("Tus playlists\n" 
                    + "-------------\n");

            if(playlists.Count > 0)
            {
                foreach (var p in playlists)
                {
                    WriteLine($"- ID: {p.Id}");
                    WriteLine($"  Logo: {p.Logo}");
                    WriteLine($"  Nombre: {p.Name}");
                    WriteLine($"  Cantidad de canciones: {p.PieceList.Count}");

                    WriteLine("");
                }
            } 
            else
            {
                WriteLine(">> No tienes ninguna playlist <<");
            }
        }
    }
}