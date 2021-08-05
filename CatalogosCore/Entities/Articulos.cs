using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogosCore.Entities
{
    public class Articulos
    {
        public int ArticuloId { get; set; }

        public string Codigo { get; set; }

        public string Descripcion { get; set; }

        public int FabricanteId { get; set; }

    }
}
