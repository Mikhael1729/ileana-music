using System.Collections.Generic;
using IleanaMusic.Models;
using System.Linq;

namespace IleanaMusic.Data.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        IData<T> _data;
        
        public BaseRepository(IData<T> data)
        {
            _data = data;
        }

        public T Add(T entity)
        {
            var id = 1;

            if (_data.List.Count > 0)
                id = _data.List[_data.List.Count - 1].Id + 1;

            entity.Id = id;
            _data.List.Add(entity);

            _data.SaveAll();

            return entity;
        }

        public void Delete(T entity)
        {
            _data.List.Remove(entity);
        }

        public T Get(int id)
        {
            return _data.List.Where(d => d.Id == id).FirstOrDefault();
        }

        public List<T> GetAll()
        {
            return _data.List;
        }

        public T Update(T entity)
        {
            var searchedEntity = _data.List.Where(d => d.Id == entity.Id).FirstOrDefault();
            searchedEntity = entity;

            return searchedEntity;
        }
    }
}