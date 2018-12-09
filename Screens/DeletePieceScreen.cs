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
               +"------------------\n");


            // Requesting Id.
            int pieceId = 0;
            Piece piece = null;

            while(pieceId == 0) 
            {
                Write("- ID de la canción: ");  

                if(Int32.TryParse(ReadLine(), out pieceId))
                    piece = pieceService.Get(pieceId);
            }

            if(piece != null) 
            {
                pieceService.Delete(piece);
                WriteLine("\n>> Canción eliminada <<\n");
            }
            else 
            {
                WriteLine("\n>> Canción no encontrada <<\n");
            }
        }
    }
}