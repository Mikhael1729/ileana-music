using System.Collections.Generic;
using System.Xml.Linq;
using System.Linq;
using IleanaMusic.Data.Repositories;
using IleanaMusic.Models;

namespace IleanaMusic.Data.Services
{
    public class PieceService : BaseRepository<Piece>, IPieceService
    {
        public PieceService(IData<Piece> data) : base(data)
        {
        }
    }
}