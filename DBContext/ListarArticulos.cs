using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DBContext
{
    public partial class ListarArticulos
    {
        //Entidades paara el uso del procedimiento almacenado de listar
        [Key]
        public string CodigoArticulo { get; set; }
        public string NombreArticulo { get; set; }
        public int? Costo { get; set; }
        public string CodigoProveedor { get; set; }
        public string Nombre { get; set; }
    }
}
