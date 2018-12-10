using System.Collections.Generic;

namespace IleanaMusic.Data
{
    public interface IData<T>
    {
        List<T> List { get; }
        void SaveAll();
    }
}