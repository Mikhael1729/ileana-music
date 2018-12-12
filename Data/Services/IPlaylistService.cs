using IleanaMusic.Data.Repositories;
using IleanaMusic.Models;

namespace IleanaMusic.Data.Services
{
    public interface IPlaylistService : IRepository<Playlist>
    { }
}