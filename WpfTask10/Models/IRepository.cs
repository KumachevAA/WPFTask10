using System;
using System.Collections.Generic;

namespace WpfTask10.Models
{
    public interface IRepository<T>
    {
        T Add(T item);
        List<T> Get();
        T Get(int id);
        void Update(T item);
        void Remove(int id);
        void Pull();

        event Action CollectionChanged;
    }
}
