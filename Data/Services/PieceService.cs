using System.Collections.Generic;
using IleanaMusic.Data.Repositories;
using IleanaMusic.Models;

namespace IleanaMusic.Data.Services 
{
    public class PieceService : BaseRepository<Piece>, IPieceService
    {
        public PieceService(List<Piece> data) : base(data)
        { }
    }
}