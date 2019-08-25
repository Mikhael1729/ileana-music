using System.Collections.Generic;
using IleanaMusic.Models;

namespace IleanaMusic.Data.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        T Get(int id);
        List<T> GetAll();
        T Add(T entity);
        T Update(T entity);
        void Delete(T entity);
        int Count();
    }
}
