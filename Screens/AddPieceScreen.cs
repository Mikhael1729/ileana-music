using static System.Console;
using IleanaMusic.Models;
using System;
using IleanaMusic.Data;
using IleanaMusic.Helpers;

namespace IleanaMusic.Screens
{
    public class AddPieceScreen
    {
        Piece piece;

        public AddPieceScreen()
        {
            var pieceService = AppData.Instance.PieceService;

            piece = new Piece();

            WriteLine("Agregar nueva pieza\n"
                    + "-------------------\n");

            piece.Request();

            // Adding id.
            pieceService.Add(piece);
            WriteLine("\n-->> Pieza agregada <<--\n");
        }

        public Piece Data()
        {
            return piece;
        }
    }
}