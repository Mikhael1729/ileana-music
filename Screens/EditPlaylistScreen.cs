using System;
using System.Collections.Generic;
using IleanaMusic.Data;
using IleanaMusic.Models;
using System.Linq;
using static System.Console;


namespace IleanaMusic.Screens
{
    public class EditPlayListScreen
    {
        List<Playlist> playlists = AppData.Instance.Playlists;
        List<Piece> pieceList = AppData.Instance.PieceList;

        public EditPlayListScreen()
        {
            Playlist searchedPlaylist;

            WriteLine("Editar playlist\n"
                    + "---------------\n");

            if (playlists.Count > 0)
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
                    searchedPlaylist = (playlists.Where(p => p.Id == id)).FirstOrDefault();
                }
                else  // Si fue nombre
                {
                    name = option;
                    searchedPlaylist = (playlists.Where(p => p.Name == name)).FirstOrDefault();
                }

                if (searchedPlaylist != null)
                {
                    WriteLine(">> Play list encontrada <<\n");

                    WriteLine($"   ID: {searchedPlaylist.Id}");
                    WriteLine($"1. Logo: {searchedPlaylist.Logo}");
                    WriteLine($"2. Nombre: {searchedPlaylist.Name}");
                    WriteLine($"3. Canciones:\n");

                    // Printing pieces of playlist.
                    foreach (var piece in searchedPlaylist.PieceList)
                        WriteLine($"     - ID: {piece.Id}, Nombre: {piece.Name}");

                    WriteLine("");

                    // Requesting what fields want to modify.
                    Write(">> ¿Qué campos quieres editar? (separa con coma): ");
                    var options = ReadLine();
                    var selected = options.Split(',');

                    WriteLine("");
                    foreach (var i in selected)
                    {
                        var n = Convert.ToInt32(i.Trim());
                        if (n == 1)
                        {
                            Write("   - Nuevo Logo: ");
                            var newLogo = ReadLine();

                            searchedPlaylist.Logo = newLogo;
                        }
                        else if (n == 2)
                        {
                            Write("   - Nuevo nombre: ");
                            var newName = ReadLine();

                            searchedPlaylist.Name = newName;
                        }
                        else if (n == 3)
                        {
                            Write("   - Cambiando canciones de la lista. Escribe sus IDs (separados por coma): ");
                            var ids = ReadLine();
                            var list = ids.Split(',');

                            // Adding selected pieces to playlist.
                            foreach (var item in list)
                            {
                                var piece = pieceList.Where(p => p.Id == Convert.ToInt32(item.Trim())).FirstOrDefault();

                                // Removing all of pieces of the playlist
                                searchedPlaylist.PieceList.Clear();

                                if (piece != null)
                                    searchedPlaylist.PieceList.Add(piece);
                            }
                        }
                    }

                    WriteLine("\n>> Pieza editada correctamente <<");
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