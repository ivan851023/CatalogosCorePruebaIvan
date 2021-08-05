using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogosCore.Models
{
    public class FabricantesModel
    {
        public int id { get; set; }

        [Display(Name = "Código Fabricante")]
        public string labelCodigo { get; set; }

        public string CodigoFabricante { get; set; }

        [Display(Name = "Nombre Fabricante")]
        public string labelDescripcion { get; set; }

        public string DescripcionFabricante { get; set; }

    }
}
