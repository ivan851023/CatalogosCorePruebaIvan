using CatalogosCore.Context;
using CatalogosCore.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CatalogosCore.Repository
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class, new()
    {
        private readonly CatalogosContext _context;
        private readonly DbSet<T> _entities;

        public RepositoryBase(CatalogosContext context)
        {
            this._context = context;
            _entities = context.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return _entities.AsEnumerable();
        }

        public T GetByFilter(Expression<Func<T, bool>> filter)
        {
            return _entities.SingleOrDefaultAsync(filter).Result;
        }

        public T GetById(int id)
        {
            return _entities.Find(id);
        }

        public List<T> GetListByFilter(Expression<Func<T, bool>> filter)
        {
            return _entities.Where(filter).ToList();
        }

        public void Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            _entities.Add(entity);
            SaveChanges();
        }

        public void Remove(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            _entities.Remove(entity);
            SaveChanges();
        }

        public void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            _entities.Update(entity);
            SaveChanges();
        }
        private void SaveChanges()
        {
            _context.SaveChanges();
        }

        public int Count(IEnumerable<T> entity)
        {
            return _entities.ToList().Count();
        }

        public void DeleteMultiple(IEnumerable<T> entity)
        {
            _entities.RemoveRange(entity);
            SaveChanges();
        }

    }
}
