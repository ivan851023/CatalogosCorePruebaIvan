using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogosCore.Models
{
    public class ArticulosModel
    {
        public int id { get; set; }

        [Display(Name = "Código Articulo")]
        public string labelCodigo { get; set; }

        public string CodigoArticulo { get; set; }

        [Display(Name = "Nombre Articulo")]
        public string labelDescripcion { get; set; }

        public string DescripcionArticulo { get; set; }

        public int selectValueFabricante { get; set; }

        public IEnumerable<SelectListItem> listFabricantes { get; set; }

    }
}
