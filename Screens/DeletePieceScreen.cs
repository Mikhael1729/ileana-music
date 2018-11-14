using System;
using System.Collections.Generic;
using System.Linq;
using IleanaMusic.Data;
using IleanaMusic.Models;
using static System.Console;

namespace IleanaMusic 
{
    public class DeletePieceScreen 
    {
        List<Piece> pieceList = AppData.Instance.PieceList;

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
                {
                    piece = pieceList.Where(i => i.Id == pieceId).FirstOrDefault();
                }      
            }

            if(piece != null) 
            {
                pieceList.Remove(piece);
                WriteLine("\n>> Canción eliminada <<\n");
            }
            else 
            {
                WriteLine("\n>> Canción no encontrada <<\n");
            }
        }
    }
}