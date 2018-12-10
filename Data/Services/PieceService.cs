using System.Linq;
using IleanaMusic.Data.Repositories;
using IleanaMusic.Models;
using System;

namespace IleanaMusic.Data.Services
{
    public class PieceService : BaseRepository<Piece>, IPieceService
    {
        public PieceService(IData<Piece> data) : base(data)
        { }

        public Piece Find(Func<Piece, bool> critery) => _data.List.Where(critery).FirstOrDefault();
    }
}