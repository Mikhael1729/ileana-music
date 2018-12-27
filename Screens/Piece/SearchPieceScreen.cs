using System;
using System.Collections.Generic;
using System.Linq;
using IleanaMusic.Data;
using IleanaMusic.Models;
using static System.Console;

// TODO:
namespace IleanaMusic
{
    public class SearchPieceScreen
    {
        List<Piece> pieceList = AppData.Instance.PieceService.GetAll();
        Piece searchedPiece;

        public SearchPieceScreen()
        {

            WriteLine("Buscar canción\n"
                    + "--------------\n");

            if (pieceList.Count > 0)
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
                    searchedPiece = (pieceList.Where(p => p.Id == id)).FirstOrDefault();
                }
                else  // Si fue nombre
                {
                    name = option;
                    searchedPiece = (pieceList.Where(p => p.Name.ToLower() == name.ToLower())).FirstOrDefault();
                }

                if (searchedPiece != null)
                {
                    WriteLine(">> ¡Pieza encontrada!\n");

                   searchedPiece.Print();
                }
                else
                {
                    WriteLine(">> Canción no encontrada");
                }
            }
            else
            {
                WriteLine(">> No tienes canciones en tu lista <<");
            }
        }

    }
}