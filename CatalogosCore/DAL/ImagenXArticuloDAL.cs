using CatalogosCore.Entities;
using CatalogosCore.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogosCore.DAL
{
    public class ImagenXArticuloDAL : IImagenXArticulo
    {
        private readonly IRepositoryBase<ImagenXArticulo> _repository;
        public ImagenXArticuloDAL(IRepositoryBase<ImagenXArticulo> repository)
        {
            _repository = repository;
        }

        public void Insert(ImagenXArticulo table)
        {
            _repository.Insert(table);
        }

        public void Update(ImagenXArticulo table)
        {
            _repository.Update(table);
        }

        public void Remove(ImagenXArticulo table)
        {
            _repository.Remove(table);
        }

        public ImagenXArticulo GetById(int id)
        {
            return _repository.GetById(id);
        }

        public IEnumerable<ImagenXArticulo> GetImagenArticulo()
        {
            return _repository.GetAll();
        }

        public void DeleteMultiple(IEnumerable<ImagenXArticulo> entities)
        {
            _repository.DeleteMultiple(entities);
        }

    }
}
