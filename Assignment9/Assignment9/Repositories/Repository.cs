using Assignment9.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment9.Repositories
{
    class Repository<T> : IRepository<T> where T : Entity
    {
        List<T> _context;

        public Repository()
        {
            _context = new List<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return _context;
        }

        public void Delete(T obj)
        {
            _context.Remove(obj);
        }

        public T GetById(string id)
        {
            return _context.Find(obj => obj.ID == id);
        }

        public void Insert(T obj)
        {
            _context.Add(obj);
        }

        public void Update(T obj)
        {
            _context.Insert(_context.IndexOf(obj), obj);
        }
    }
}
