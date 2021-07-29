using System;
using System.Collections.Generic;

namespace Backend.Repositories.Interfaces
{
    public interface IRepository<T>
    {
        public bool Add(T entity);
        public bool Remove(T entity);
        public List<T> GetAll();
        public List<T> Query(Func<T,bool> predicate);

        public bool Update(T entity);
    }
}