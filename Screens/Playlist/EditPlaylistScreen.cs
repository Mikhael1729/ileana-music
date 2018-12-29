using System;
using System.Collections.Generic;
using IleanaMusic.Data;
using IleanaMusic.Models;
using IleanaMusic.Helpers;
using IleanaMusic.Data.Services;
using static IleanaMusic.Helpers.ConsoleReader;

namespace IleanaMusic.Screens
{
    public class EditPlayListScreen
    {
        PlaylistService playlistService = AppData.Instance.PlaylistService;
        List<Piece> pieceList = AppData.Instance.PieceService.GetAll();

        public EditPlayListScreen()
        {
            Playlist searchedPlaylist;
            var writer = new ConsoleWriter(0);

            writer.WriteLine(
                "Editar playlist\n" +
                "---------------\n"
            );

            if (playlistService.Count() < 0)
            {
                writer.WriteLine(">> No tines playlists en tu lista. Agrega una para usar esta función.");
            }
            else
            {
                writer.Write("- Escribe el ID o el Nombre de la playlist: ");
                string option;
                string name = "";

                option = ReadLine();

                Console.WriteLine("");

                // Si fue ID.
                if (Int32.TryParse(option, out int id))
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
                    writer.WriteLine (
                        text: "[Playlist encontrada] \n",
                        indent: 1
                    );

                    PlaylistFragments.PrintPlaylist(
                        playlist: searchedPlaylist, 
                        withNumeration:true, 
                        withPieces: true, 
                        indentation: 1
                    );

                    // Requesting what fields want to modify.
                    Console.Write("\n- ¿Qué campos quieres editar? (separa con coma): ");
                    var options = ReadNumberOptions();

                    Console.WriteLine("");
                    var canceled = false;
                    foreach (var i in options)
                    {
                        if (i == 1)
                            PlaylistFragments.RequestLogo(ref searchedPlaylist, indent: 1);
                        else if (i == 2)
                            PlaylistFragments.RequestName(ref searchedPlaylist, indent: 1);
                        else if (i == 3)
                            PlaylistFragments.EditPlaylistPieces(ref searchedPlaylist);
                        else
                        {
                            canceled = true;
                            Console.WriteLine("\n>> EDICIÓN CANCELADA: Dato introducio no válido <<");
                        }
                    }

                    if (!canceled)
                    {
                        try
                        {
                            playlistService.Update(searchedPlaylist);
                            Console.WriteLine("\n>> Edición guardada <<");
                        }
                        catch(InvalidOperationException ex)
                        {
                            Console.WriteLine($"\n>> EDICIÓN CANCELADA: {ex.Message}");
                        }
                    }
                }
                else
                {
                    Console.WriteLine(">> Playlist no encontrada. : (");
                    Console.WriteLine("   El ID o nombre introducido no coincidió con ningún resultado de búsqueda <<");
                }
            }
        }
    }
}