using System.Collections.Generic;
using IleanaMusic.Models;
using System.Linq;

namespace IleanaMusic.Data.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        List<T> _data;
        
        public BaseRepository(List<T> data)
        {
            _data = data;
        }

        public T Add(T entity)
        {
            var id = 1;

            if (_data.Count > 0)
                id = _data[_data.Count - 1].Id + 1;

            entity.Id = id;
            _data.Add(entity);

            return entity;
        }

        public void Delete(T entity)
        {
            _data.Remove(entity);
        }

        public T Get(int id)
        {
            return _data.Where(d => d.Id == id).FirstOrDefault();
        }

        public List<T> GetAll()
        {
            return _data;
        }

        public T Update(T entity)
        {
            var searchedEntity = _data.Where(d => d.Id == entity.Id).FirstOrDefault();
            searchedEntity = entity;

            return searchedEntity;
        }
    }
}