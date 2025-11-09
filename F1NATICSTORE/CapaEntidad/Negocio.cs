using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Negocio
    {
        public int IdNegocio { get; set; }
        public string Nombre { get; set; }
        public char TipoFactura { get; set; }
        public string Cuit { get; set; }
        public string CondicionIVA { get; set; }
        public string Direccion { get; set; }

    }
}
