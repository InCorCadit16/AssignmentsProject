using Assignment9.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment9.Repositories
{
    class Repository<T> : IRepository<T> where T : class, IEntity
    {
        List<T> _articleContext;

        public Repository()
        {
            _articleContext = new List<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return _articleContext;
        }

        public void Delete(T obj)
        {
            _articleContext.Remove(obj);
        }

        public T GetById(string id)
        {
            T Article = null;
            _articleContext.ForEach(obj => { if (obj.ID.Equals(id)) Article = obj; });
            return Article;
        }

        public void Insert(T obj)
        {
            _articleContext.Add(obj);
        }

        public void Update(T obj)
        {
            _articleContext.Insert(_articleContext.IndexOf(obj), obj);
        }
    }
}
