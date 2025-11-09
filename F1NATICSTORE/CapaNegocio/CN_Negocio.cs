using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Negocio
    {
        private CD_Negocio objcd_Negocio = new CD_Negocio(); // Instancia de la capa de datos
        public Negocio ObtenerDatos() // Método para listar Negocios
        {
            return objcd_Negocio.ObtenetDatos(); // Retorna la lista de Negocios desde la capa de datos
        }
        // Método para registrar un nuevo Negocio
        public bool GuardarDatos(Negocio obj, out string Mensaje) // Método para registrar un nuevo Negocio
        {
            Mensaje = string.Empty; // Inicializar el mensaje

            if (obj.Nombre == "") // Validar que el documento no esté vacío
            {
                Mensaje += " Es necesario indicar el Nombre del Negocio\n";
            }

            if (obj.TipoFactura == '\0') // Validar que el TIPO DE FACTURA NO esté vacío
            {
                Mensaje += " Es necesario indicar el tipo de factura del Negocio\n";
            }

            if (obj.Cuit == "") // Validar que el cuit no esté vacío
            {
                Mensaje += " Es necesario indicar el Núm de CUIT del Negocio\n";
            }

            if (obj.CondicionIVA == "") // Validar que la condición de IVA no esté vacía
            {
                Mensaje += " Es necesario indicar la CONDICIÓN DE IVA del Negocio\n";
            }

            if (obj.Direccion == "") // Validar que la dirección no esté vacía
            {
                Mensaje += " Es necesario indicar la DIRECCIÓN del Negocio\n";
            }

            if (Mensaje != string.Empty)
            {
                return false; 
            }
            else
            {
                return objcd_Negocio.GuardarDatos(obj, out Mensaje); // Uso de out para retornar mensajes
            }

        }
        public byte[] ObtenerLogo(out bool obtenido) 
        {
            return objcd_Negocio.ObtenerLogo(out obtenido); 
        }

        public bool ActualizarLogo(byte[] imagen, out string mensaje) 
        {
            return objcd_Negocio.ActualizarLogo(imagen, out mensaje); // Retorna la lista de Negocios desde la capa de datos
        }

    }
}
