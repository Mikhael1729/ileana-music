using static System.Console;
using IleanaMusic.Models;
using System;
using IleanaMusic.Data;
using System.Linq;


namespace IleanaMusic.Screens 
{
    public class PieceList 
    {

        public PieceList() 
        {  
            WriteLine("Listado de canciones: \n");
             foreach (var piece in AppData.Instance.PieceList)
            {
                WriteLine(piece.Name);
            }
        }
    }
}