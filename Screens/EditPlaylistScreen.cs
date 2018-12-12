using System;
using System.Collections.Generic;
using IleanaMusic.Data;
using IleanaMusic.Models;
using System.Linq;
using static System.Console;
using IleanaMusic.Helpers;
using IleanaMusic.Data.Services;

namespace IleanaMusic.Screens
{
    public class EditPlayListScreen
    {
        PlaylistService playlistService = AppData.Instance.PlaylistService;
        List<Piece> pieceList = AppData.Instance.PieceService.GetAll();

        public EditPlayListScreen()
        {
            Playlist searchedPlaylist;

            WriteLine("Editar playlist\n"
                    + "---------------\n");

            if (playlistService.Count() < 0)
            {
                WriteLine(">> No tines playlists en tu lista. Agrega una para usar esta función.");
            }
            else
            {
                Write("- Escribe el ID o el Nombre de la playlist: ");
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
                    searchedPlaylist = playlistService.Find(p => p.Name == name);
                }

                if (searchedPlaylist != null)
                {
                    PlaylistFragments.PrintPlaylist(playlist: searchedPlaylist, withNumeration:true, withPieces: true);

                    // Requesting what fields want to modify.
                    Write("\n>> ¿Qué campos quieres editar? (separa con coma): ");
                    var options = ReadLine();
                    var selected = options.Split(',');

                    WriteLine("");
                    foreach (var i in selected)
                    {
                        var n = Convert.ToInt32(i.Trim());
                        if (n == 1)
                        {
                            PlaylistFragments.RequestLogo(ref searchedPlaylist, indent:1);
                        }
                        else if (n == 2)
                        {
                            PlaylistFragments.RequestName(ref searchedPlaylist, indent:1);
                        }
                        else if (n == 3)
                        {
                            PlaylistFragments.RequestPieces(ref searchedPlaylist);
                        }
                    }

                    WriteLine("\n>> Playlist editada correctamente <<");

                    playlistService.Update(searchedPlaylist);
                }
                else
                {
                    WriteLine(">> Playlist no encontrada. : (");
                    WriteLine(">> El Id o nombre que introdujiste no es una playlist");
                }
            }
        }
    }
}