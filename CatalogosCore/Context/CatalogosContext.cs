using CatalogosCore.Entities;
using CatalogosCore.Map;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogosCore.Context
{
    public class CatalogosContext : DbContext
    {

        public CatalogosContext()
        {
        }

        public CatalogosContext(DbContextOptions<CatalogosContext> options)
              : base(options)
        {
        }


        public DbSet<Fabricantes> Fabricantes { get; set; }

        public DbSet<Articulos> Articulos { get; set; }

        public DbSet<ImagenXArticulo> ImagenXArticulo { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new FabricantesMap());
            modelBuilder.ApplyConfiguration(new ArticulosMap());
            modelBuilder.ApplyConfiguration(new ImagenXArticuloMap());
        }
    }
}
