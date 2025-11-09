using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Compra
    {
        private CD_Compra objcd_compra = new CD_Compra(); // Instancia de la capa de datos
        public int ObtenerCorrelativo() // Método para listar correlativos
        {
            return objcd_compra.ObtenerCorrelativo(); // Retorna la lista de correlativos desde la capa de datos
        }
        // Método para registrar un nuevo usuario
        public bool Registrar(Compra obj,DataTable DetalleCompra, out string Mensaje) // Método para registrar un nuevo usuario
        {
            return objcd_compra.Registrar(obj, DetalleCompra, out Mensaje); // Uso de out para retornar mensajes
        }

        public Compra ObtenerCompra(string numero)
        {
            Compra oCompra = objcd_compra.ObtenerCompra(numero);

            if (oCompra.IdCompra != 0)
            {
                List<Detalle_Compra> oListaDetalle = objcd_compra.ObtenerDetalleCompra(oCompra.IdCompra);
                oCompra.oDetalleCompra = oListaDetalle;
            }
            return oCompra;
        }
    }
}
