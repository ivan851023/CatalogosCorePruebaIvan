using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogosCore.Entities
{
    public class ImagenXArticulo
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ImagenArticuloId { get; set; }

        public int ArticuloId { get; set; }

        public byte[] Imagen { get; set; }

        public string NombreArchivo { get; set; }

    }
}
