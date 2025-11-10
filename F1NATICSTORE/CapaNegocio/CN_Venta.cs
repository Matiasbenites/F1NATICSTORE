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
    public class CN_Venta
    {
        private CD_Venta objcd_venta = new CD_Venta(); // Instancia de la capa de datos

        public bool RestarStock(int idproducto, int cantidad)
        {
            return objcd_venta.RestarStock(idproducto, cantidad);
        }

        public bool SumarStock(int idproducto, int cantidad)
        {
            return objcd_venta.SumarStock(idproducto, cantidad);
        }
        public int ObtenerCorrelativo() // Método para listar correlativos
        {
            return objcd_venta.ObtenerCorrelativo(); // Retorna la lista de correlativos desde la capa de datos
        }
        // Método para registrar un nuevo usuario
        public bool Registrar(Venta obj, DataTable DetalleVenta, out string Mensaje) // Método para registrar un nuevo usuario
        {
            return objcd_venta.Registrar(obj, DetalleVenta, out Mensaje); // Uso de out para retornar mensajes
        }

        public Venta ObtenerVenta(string numero)
        {
            Venta oVenta = objcd_venta.ObtenerVenta(numero);

            if (oVenta.IdVenta != 0)
            {
                List<Detalle_Venta> oListaDetalle = objcd_venta.ObtenerDetalleVenta(oVenta.IdVenta);
                oVenta.oDetalleVenta = oListaDetalle;
            }
            return oVenta;
        }
    }
}
