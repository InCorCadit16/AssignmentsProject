using Assignment9.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment9.Repositories
{
    interface IRepository<T> where T : class, IEntity
    {
        IEnumerable<T> GetAll();
        T GetById(string id);

        void Insert(T obj);

        void Update(T obj);

        void Delete(T obj);
    }
}
