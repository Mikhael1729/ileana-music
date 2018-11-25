using System.Collections.Generic;
using IleanaMusic.Models;

namespace IleanaMusic.Models
{
    public class Playlist 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public char Logo { get; set; }
        public List<Piece> PieceList { get; set; }

        // Delete a song from the playlist.
        public void DeletePiece(Piece piece) 
        {   
            PieceList.Remove(piece);
        }

        public override string ToString() => Name;
    }
}