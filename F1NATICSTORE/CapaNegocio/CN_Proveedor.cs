using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Proveedor
    {
        private CD_Proveedor objcd_Proveedor = new CD_Proveedor(); // Instancia de la capa de datos
        public List<Proveedor> Listar() // Método para listar Proveedors
        {
            return objcd_Proveedor.Listar(); // Retorna la lista de Proveedors desde la capa de datos
        }
        // Método para registrar un nuevo Proveedor
        public int Registrar(Proveedor obj, out string Mensaje) // Método para registrar un nuevo Proveedor
        {
            Mensaje = string.Empty; // Inicializar el mensaje

            if (obj.Documento == "") // Validar que el documento no esté vacío
            {
                Mensaje += " Es necesario indicar el DOCUMENTO del Proveedor\n";
            }

            if (obj.RazonSocial == "") // Validar que la razon social no esté vacío
            {
                Mensaje += " Es necesario indicar la Razon Social del Proveedor\n";
            }

            if (obj.Correo == "") // Validar que la contraseña no esté vacía
            {
                Mensaje += " Es necesario indicar la Correo del Proveedor\n";
            }

            if (Mensaje != string.Empty)
            {
                return 0; // Si hay mensajes de error, retornar 0
            }
            else
            {
                return objcd_Proveedor.Registrar(obj, out Mensaje); // Uso de out para retornar mensajes
            }

        }

        // Método para editar un Proveedor
        public bool Editar(Proveedor obj, out string Mensaje) // Método para editar un Proveedor
        {
            Mensaje = string.Empty; // Inicializar el mensaje

            if (obj.Documento == "") // Validar que el documento no esté vacío
            {
                Mensaje += " Es necesario indicar el DOCUMENTO del Proveedor\n";
            }

            if (obj.RazonSocial == "") // Validar que la razon social no esté vacío
            {
                Mensaje += " Es necesario indicar la Razon Social del Proveedor\n";
            }

            if (obj.Correo == "") // Validar que la contraseña no esté vacía
            {
                Mensaje += " Es necesario indicar la Correo del Proveedor\n";
            }

            if (Mensaje != string.Empty)
            {
                return false; // Si hay mensajes de error, retornar 0
            }
            else
            {
                return objcd_Proveedor.Editar(obj, out Mensaje); // retorna el resultado de la edición
            }
        }

        // Método para eliminar un Proveedor
        public bool Eliminar(Proveedor obj, out string Mensaje) // Método para eliminar un Proveedor
        {
            return objcd_Proveedor.Eliminar(obj, out Mensaje); // Uso de out para retornar mensajes
        }
    }
}

