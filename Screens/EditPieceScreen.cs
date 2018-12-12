using System;
using System.Collections.Generic;
using System.Linq;
using IleanaMusic.Data;
using IleanaMusic.Models;
using static System.Console;
using IleanaMusic.Helpers;
using IleanaMusic.Data.Services;

namespace IleanaMusic.Screens
{
    public class EditPieceScreen
    {
        PieceService pieceService = AppData.Instance.PieceService;
        Piece piece;

        public EditPieceScreen()
        {
            // Title
            WriteLine(
                "Edita una canción\n"
               + "-----------------\n");

            if (pieceService.Count() > 0)
            {

                Write("Escribe el ID o el Nombre de tu canción: ");

                string option;
                string name = "";
                int id = 0;

                option = ReadLine();

                WriteLine("");

                // Si fue ID.
                if (Int32.TryParse(option, out id))
                {
                    var searchedPiece = pieceService.Get(id);

                    if (searchedPiece != null)
                        piece = searchedPiece.Clone();
                }
                else  // Si fue nombre
                {
                    name = option;
                    var searchedPiece = pieceService.Find((Piece piece) => piece.Name.ToLower() == name.ToLower());
                    piece = searchedPiece.Clone();
                }

                if (piece != null)
                {
                    WriteLine(">> ¡Pieza encontrada!\n");

                    // Printing piece.
                    piece.Print(withNumeration: true, spaceQuantity: 3);

                    // Writer.
                    var writer = new ConsoleWriter(3);

                    // Selecting fields to edit.
                    writer.Write(text: "¿Qué campos quieres editar? (separa con coma): ", spaceBefore: true);
                    var options = ReadLine();
                    var selected = options.Split(',');

                    WriteLine("");

                    // Requesting selected fields to edit.
                    RequestPieceData(selected, writer);
                }
                else
                {
                    WriteLine("\n>> Canción no encontrada <<\n");
                }
            }
            else
            {
                WriteLine(">> Tu lista de canciones está vacía. Agrega una para habilitar esta sección");
            }
        }

        private void RequestPieceData(string[] fields, ConsoleWriter consoleWriter = null)
        {
            var writer = consoleWriter != null ? consoleWriter : new ConsoleWriter(0);

            foreach (var i in fields)
            {
                var n = Convert.ToInt32(i.Trim());

                switch (n)
                {
                    case 1:
                        piece.RequestName(writer);
                        break;
                    case 2:
                        piece.RequestArtist(writer);
                        break;
                    case 3:
                        piece.RequestAlbum(writer);
                        break;
                    case 4:
                        piece.RequestGender(writer);
                        break;
                    case 5:
                        piece.RequestDuration(writer);
                        break;
                    case 6:
                        piece.RequestQuality(writer);
                        break;
                    case 7:
                        piece.RequestFormat(writer);
                        break;
                }
            }

            pieceService.Update(piece);

            writer.Write(
                text: "-->> Pieza editada <<--\n",
                spaceBefore: true,
                cancelSpace: true
            );
        }
    }
}