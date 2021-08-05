using CatalogosCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogosCore.Map
{
    public class FabricantesMap : IEntityTypeConfiguration<Fabricantes>
    {

        public void Configure(EntityTypeBuilder<Fabricantes> entity)
        {
            entity.HasKey(e => e.FabricanteId);
            entity.ToTable("FABRICANTES");
            entity.HasIndex(e => e.FabricanteId);
            entity.Property(e => e.FabricanteId).HasColumnName("FabricanteId");
            entity.Property(e => e.Codigo).HasColumnName("Codigo");
            entity.Property(e => e.Descripcion).HasColumnName("Descripcion");
            entity.Property(e => e.Fecha_Creacion).HasColumnName("Fecha_Creacion");
        }

    }
}
