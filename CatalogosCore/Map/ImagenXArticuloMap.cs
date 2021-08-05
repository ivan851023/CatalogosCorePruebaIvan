using CatalogosCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogosCore.Map
{
    public class ImagenXArticuloMap : IEntityTypeConfiguration<ImagenXArticulo>
    {
        public void Configure(EntityTypeBuilder<ImagenXArticulo> entity)
        {
            entity.HasKey(e => e.ImagenArticuloId);
            entity.ToTable("IMAGENXARTICULO");
            entity.HasIndex(e => e.ImagenArticuloId);
            entity.Property(e => e.ImagenArticuloId).HasColumnName("ImagenArticuloId");
            entity.HasAlternateKey(e => e.ArticuloId);
            entity.Property(e => e.Imagen).HasColumnName("Imagen");
            entity.Property(e => e.NombreArchivo).HasColumnName("NombreArchivo");

        }

    }
}
