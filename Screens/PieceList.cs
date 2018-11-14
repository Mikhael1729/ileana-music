using static System.Console;
using IleanaMusic.Models;
using System;
using IleanaMusic.Data;
using System.Linq;
using System.Collections.Generic;

namespace IleanaMusic.Screens 
{
    public class PieceList 
    {
        List<Piece> pieces = AppData.Instance.PieceList; 
        
        public PieceList() 
        {  
            WriteLine(
                "Lista de canciones\n"
               +"------------------\n");

            if(pieces.Count > 0) 
            {
                foreach (var piece in AppData.Instance.PieceList)
                    WriteLine($"{piece.Id}. {piece.Name}");
            } 
            else
            {
                WriteLine("\n >> Lista vacía <<");
            }
        }
    }
}