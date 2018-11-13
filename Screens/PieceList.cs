using static System.Console;
using IleanaMusic.Data;

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