using static System.Console;
using IleanaMusic.Models;
using System;
using IleanaMusic.Data;
using IleanaMusic.Helpers;
using IleanaMusic.Data.Services;

namespace IleanaMusic.Screens
{
    public class AddPieceScreen
    {
        Piece piece;

        public AddPieceScreen()
        {
            var pieceService = PieceService.Instance;

            piece = new Piece();

            WriteLine("Agregar nueva pieza\n"
                    + "-------------------\n");

            piece.RequestAll();

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