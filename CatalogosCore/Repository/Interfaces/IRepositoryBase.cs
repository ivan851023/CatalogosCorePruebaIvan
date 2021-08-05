using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CatalogosCore.Repository.Interfaces
{
    public interface IRepositoryBase<T>
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        T GetByFilter(Expression<Func<T, bool>> filter);
        List<T> GetListByFilter(Expression<Func<T, bool>> filter);
        void Insert(T entity);
        void Remove(T entity);
        void Update(T entity);
        int Count(IEnumerable<T> entity);

        void DeleteMultiple(IEnumerable<T> entity);
    }
}
