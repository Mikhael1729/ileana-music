using System;
using System.Collections.Generic;
using System.Linq;
using IleanaMusic.Data;
using IleanaMusic.Data.Services;
using IleanaMusic.Models;
using static System.Console;

namespace IleanaMusic
{
    public class DeletePieceScreen
    {
        PieceService pieceService = AppData.Instance.PieceService;

        public DeletePieceScreen()
        {
            // Title
            WriteLine(
                "Borrar una canción\n"
               + "------------------\n");


            // Requesting Id.
            int pieceId = 0;
            Piece piece = null;


            Write("- Escribe el ID de la pieza a eliminar: ");

            if (Int32.TryParse(ReadLine(), out pieceId))
                piece = pieceService.Get(pieceId);

            if (piece != null)
            {
                WriteLine($"\n>> La pieza \"{piece.Name}\" ha sido eliminada <<");
                pieceService.Delete(piece);
            }
            else
            {
                WriteLine("\n>> Pieza no encontrada <<\n");
            }
        }
    }
}