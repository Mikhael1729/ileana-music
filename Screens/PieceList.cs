using static System.Console;
using IleanaMusic.Data;

namespace IleanaMusic.Screens 
{
    public class PieceList 
    {
        public PieceList() 
        {
            var title = @"Lista de canciones
------------------";

            WriteLine(title);
            
            foreach (var piece in AppData.Instance.PieceList)
            {
                WriteLine(piece.Name);
            }
        }
    }
}