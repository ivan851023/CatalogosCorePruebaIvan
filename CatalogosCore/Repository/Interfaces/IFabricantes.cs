using CatalogosCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogosCore.Repository.Interfaces
{
    public interface IFabricantes
    {
        void Insert(Fabricantes entity);

        void Update(Fabricantes entity);

        void Remove(Fabricantes entity);

        Fabricantes GetById(int id);

        IEnumerable<Fabricantes> GetFabricantes();

        int Count(IEnumerable<Fabricantes> entity);

    }
}
