using CatalogosCore.Entities;
using CatalogosCore.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogosCore.DAL
{
    public class ArticulosDAL : IArticulos
    {
        private readonly IRepositoryBase<Articulos> _repository;
        public ArticulosDAL(IRepositoryBase<Articulos> repository)
        {
            _repository = repository;
        }

        public void Insert(Articulos table)
        {
            _repository.Insert(table);
        }

        public void Update(Articulos table)
        {
            _repository.Update(table);
        }

        public void Remove(Articulos table)
        {
            _repository.Remove(table);
        }

        public Articulos GetById(int id)
        {
            return _repository.GetById(id);
        }

        public IEnumerable<Articulos> GetArticulos()
        {
            return _repository.GetAll();
        }

        public int Count(IEnumerable<Articulos> table)
        {
            return _repository.Count(table);
        }

    }
}
