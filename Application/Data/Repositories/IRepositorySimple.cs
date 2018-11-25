using System;
using System.Collections.Generic;

namespace Application.Data.Repositories
{
    public interface IRepositorySimple<T> : IDisposable
        where T : class
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        void Create(T item);
        void Update(T item);
        void Delete(int id);
    }
}
