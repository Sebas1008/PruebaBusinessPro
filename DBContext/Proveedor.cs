using System;
using System.Collections.Generic;

namespace DBContext
{
    public partial class Proveedor
    {
        public Proveedor()
        {
            Articulos = new HashSet<Articulos>();
        }

        public int IdProveedor { get; set; }
        public string CodigoProveedor { get; set; }
        public string Nombre { get; set; }
        public string Estado { get; set; }
        public int? Cedula { get; set; }
        public string Direccion { get; set; }
        public int? Telefono { get; set; }

        public virtual ICollection<Articulos> Articulos { get; set; }
    }
}
