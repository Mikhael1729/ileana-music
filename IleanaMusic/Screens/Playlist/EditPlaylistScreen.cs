using System;
using System.Collections.Generic;
using IleanaMusic.Data;
using IleanaMusic.Models;
using IleanaMusic.Helpers;
using IleanaMusic.Data.Services;
using static IleanaMusic.Helpers.ConsoleReader;
using static IleanaMusic.Helpers.PlaylistFragments;

namespace IleanaMusic.Screens
{
    public class EditPlayListScreen
    {
        PlaylistService playlistService = AppData.Instance.PlaylistService;
        readonly List<Piece> pieceList = PieceService.Instance.GetAll();

        public EditPlayListScreen()
        {
            Playlist searchedPlaylist;
            var writer = new ConsoleWriter(0);

            // Title.
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
                var validName = true;
                var validLogo = true;
                var validPieces = true;

                // Requesting ID or Name
                writer.Write("- Escribe el ID o el Nombre de la playlist: ");
                string option;
                string name = "";

                option = ReadLine();

                writer.WriteLine("");

                // If an ID is written
                if (Int32.TryParse(option, out int id))
                {
                    searchedPlaylist = playlistService.Get(id);
                }
                else 
                {
                    name = option;
                    searchedPlaylist = playlistService.Find(p => p.Name == name);
                }

                // If playlist has finded
                if (searchedPlaylist != null)
                {
                    writer.WriteLine (
                        text: "[Playlist encontrada] \n",
                        indent: 1
                    );

                    PrintPlaylist(
                        playlist: searchedPlaylist, 
                        withNumeration:true, 
                        withPieces: true, 
                        indentation: 1
                    );

                    // Requesting what fields wants to modify.
                    writer.Write("\n- ¿Qué campos quieres editar? (separa con coma): ");
                    var options = ReadNumberOptions();

                    writer.WriteLine("");

                    var canceled = false; 
                    foreach (var i in options)
                    {
                        if (i == 1)
                        {
                            validLogo = RequestLogo(ref searchedPlaylist, indent: 1);
                        }
                        else if (i == 2)
                        {
                            validName = EditName(ref searchedPlaylist, indent: 1);

                            if (!validName)
                            {
                                writer.WriteLine(
                                    text: "  (Ya existe una playlist con ese nombre. El nombre no será cambiado)\n",
                                    indent: 1
                                );
                            }
                        }
                        else if (i == 3)
                        {
                            validPieces = EditPlaylistPieces(ref searchedPlaylist);
                        }
                        else
                        {
                            canceled = true;
                            writer.WriteLine("\n>> EDICIÓN CANCELADA: Dato introducio no válido <<");
                        }
                    }

                    if (!canceled)
                    {
                        try
                        {
                            playlistService.Update(searchedPlaylist);
                            writer.WriteLine("\n>> Edición guardada <<");
                        }
                        catch(InvalidOperationException ex)
                        { }
                    }
                }
                else
                {
                    writer.WriteLine(">> Playlist no encontrada. : (");
                    writer.WriteLine("   El ID o nombre introducido no coincidió con ningún resultado de búsqueda <<");
                }
            }
        }
    }
}