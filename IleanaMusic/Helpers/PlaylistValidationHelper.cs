using IleanaMusic.Models;
using System.Collections.Generic;
using System.Linq;

namespace IleanaMusic.Helpers
{
    public static class PlaylistValidationHelper
    {
        public static bool ExistInAnotherThreePlaylist(this IEnumerable<Playlist> playlists, Piece newPiece)
        {
            var counter = 0;
            foreach (var playlist in playlists)
            {
                foreach (var piece in playlist.PieceList)
                {
                    if (piece.Id == newPiece.Id)
                    {
                        counter++;

                        if (counter == 3)
                            return true;
                    }
                }
            }

            return false;
        }

        public static bool ExistInTheList(this Playlist playlist, Piece newPiece)
        {
            foreach (var piece in playlist.PieceList)
                if (piece.Id == newPiece.Id)
                    return true;

            return false;
        }

        public static bool HasReachedTheLimit(this Playlist playlist)
        {
            return playlist.PieceList.Count >= 10 ? true : false;
        }

        public static bool ItCanBeAdded(this IEnumerable<Playlist> playlists, string playlistName)
        {
            // Playlists with the same name of another can't be added
            var searched = playlists.Where((Playlist p) => p.Name.ToLower() == playlistName.ToLower()).FirstOrDefault();
            return searched == null ? true : false;
        }
    }
}
