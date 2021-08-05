using CatalogosCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogosCore.Repository.Interfaces
{
    public interface IArticulos
    {
        void Insert(Articulos entity);

        void Update(Articulos entity);

        void Remove(Articulos entity);

        Articulos GetById(int id);

        IEnumerable<Articulos> GetArticulos();

        int Count(IEnumerable<Articulos> entity);

    }
}
