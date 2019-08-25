using static System.Console;
using IleanaMusic.Models;
using System;
using IleanaMusic.Data;
using System.Linq;
using System.Collections.Generic;
using IleanaMusic.Data.Services;

namespace IleanaMusic.Screens
{
    public class PieceList
    {
        List<Piece> pieces = PieceService.Instance.GetAll();

        public PieceList()
        {
            WriteLine(
                "Lista de canciones\n"
               + "------------------\n");

            if (pieces.Count > 0)
            {
                foreach (var piece in pieces)
                {
                    piece.Print();
                    WriteLine("");
                }
            }
            else
            {
                WriteLine("\n >> Lista vacía <<");
            }
        }
    }
}