using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogosCore.Entities
{
    public class Fabricantes
    {

        public int FabricanteId { get; set; }

        public string Codigo { get; set; }

        public string Descripcion { get; set; }

        public DateTime Fecha_Creacion { get; set; }
    }
}
