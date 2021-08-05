using CatalogosCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogosCore.Repository.Interfaces
{
    public interface IImagenXArticulo
    {
        void Insert(ImagenXArticulo entity);

        void Update(ImagenXArticulo entity);

        void Remove(ImagenXArticulo entity);

        ImagenXArticulo GetById(int id);

        IEnumerable<ImagenXArticulo> GetImagenArticulo();

        void DeleteMultiple(IEnumerable<ImagenXArticulo> entities);

    }
}
