using System;
using System.Collections.Generic;

namespace kaigang.Models.Repositories.Interfaces
{
    public interface IRepository<T>
    {
        bool Add(T entity);
        bool Update(T entity);
        bool Delete(Object obj);
        T Get(Object obj);
        ICollection<T> GetMany(Object obj);
    }
}