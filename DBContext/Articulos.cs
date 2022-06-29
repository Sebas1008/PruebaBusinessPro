using System;
using System.Collections.Generic;

namespace DBContext
{
    public partial class Articulos
    {

        //Entidades de la tabla Articulos de la base de datos
        public int IdArticulo { get; set; }
        public string CodigoArticulo { get; set; }
        public string NombreArticulo { get; set; }
        public string EstadoActivo { get; set; }
        public int? Costo { get; set; }
        public int? IdProveedor { get; set; }

        public virtual Proveedor Proveedor { get; set; }
    }
}
