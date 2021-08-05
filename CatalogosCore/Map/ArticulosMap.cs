using CatalogosCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogosCore.Map
{
    public class ArticulosMap : IEntityTypeConfiguration<Articulos>
    {
        public void Configure(EntityTypeBuilder<Articulos> entity)
        {
            entity.HasKey(e => e.ArticuloId);
            entity.ToTable("ARTICULOS");
            entity.HasIndex(e => e.ArticuloId);
            entity.Property(e => e.ArticuloId).HasColumnName("ArticuloId");
            entity.Property(e => e.Codigo).HasColumnName("Codigo");
            entity.Property(e => e.Descripcion).HasColumnName("Descripcion");
            entity.Property(e => e.FabricanteId).HasColumnName("FabricanteId");
        }

    }
}
