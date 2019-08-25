using System.Collections.Generic;

namespace IleanaMusic.Data
{
    public interface IData<T>
    {
        List<T> List { get; }
        T Save();
        void Delete(T entity);
        List<T> GetAll();
        void SaveAll();
    }
}