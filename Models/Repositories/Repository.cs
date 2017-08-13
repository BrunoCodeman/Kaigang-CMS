using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

using kaigang.Models.Entities;
using kaigang.Models.Repositories.Interfaces;

namespace kaigang.Models.Repositories
{
    public class Repository<T> : IRepository<T> where T : class, IModel
    {
        protected DbContext context;

        public bool Add(T entity)
        {
            context.AddAsync(entity);
            return context.SaveChangesAsync().Result > 0;
        }

        public bool Delete(object obj)
        {
            throw new NotImplementedException();
        }

        public T Get(object obj)
        {
            throw new NotImplementedException();
        }

        public ICollection<T> GetMany(object obj)
        {
            throw new NotImplementedException();
        }
        
        public bool Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}