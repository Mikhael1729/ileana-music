using System.Collections.Generic;
using IleanaMusic.Data;
using IleanaMusic.Helpers;
using IleanaMusic.Models;
using static System.Console;

namespace IleanaMusic.Screens
{
    public class PlaylistsScreen 
    {
        List<Playlist> playlists = AppData.Instance.PlaylistService.GetAll();

        public PlaylistsScreen() 
        {
            WriteLine("Tus playlists\n" 
                    + "-------------\n");

            if(playlists.Count > 0)
            {
                foreach (var p in playlists)
                {
                    PlaylistFragments.PrintPlaylist(playlist: p);
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