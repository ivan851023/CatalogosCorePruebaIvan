using CatalogosCore.Entities;
using CatalogosCore.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogosCore.DAL
{
    public class FabricantesDAL : IFabricantes
    {
        private readonly IRepositoryBase<Fabricantes> _repository;
        public FabricantesDAL(IRepositoryBase<Fabricantes> repository)
        {
            _repository = repository;
        }

        public void Insert(Fabricantes table)
        {
            _repository.Insert(table);
        }

        public void Update(Fabricantes table)
        {
            _repository.Update(table);
        }

        public void Remove(Fabricantes table)
        {
            _repository.Remove(table);
        }

        public Fabricantes GetById(int id)
        {
            return _repository.GetById(id);
        }

        public IEnumerable<Fabricantes> GetFabricantes()
        {
            return _repository.GetAll();
        }

        public int Count(IEnumerable<Fabricantes> table)
        {
            return _repository.Count(table);
        }


    }
}
