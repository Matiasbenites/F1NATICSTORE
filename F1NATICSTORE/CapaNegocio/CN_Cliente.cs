using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Cliente
    {
        private CD_Cliente objcd_Cliente = new CD_Cliente(); // Instancia de la capa de datos
        public List<Cliente> Listar() // Método para listar Clientes
        {
            return objcd_Cliente.Listar(); // Retorna la lista de Clientes desde la capa de datos
        }
        // Método para registrar un nuevo Cliente
        public int Registrar(Cliente obj, out string Mensaje) // Método para registrar un nuevo Cliente
        {
            Mensaje = string.Empty; // Inicializar el mensaje

            if (obj.Documento == "") // Validar que el documento no esté vacío
            {
                Mensaje += " Es necesario indicar el DOCUMENTO del Cliente\n";
            }

            if (obj.NombreCompleto == "") // Validar que el nombre no esté vacío
            {
                Mensaje += " Es necesario indicar el NOMBRE del Cliente\n";
            }

            if (obj.Correo == "") // Validar que la contraseña no esté vacía
            {
                Mensaje += " Es necesario indicar el correo del Cliente\n";
            }

            if (Mensaje != string.Empty)
            {
                return 0; // Si hay mensajes de error, retornar 0
            }
            else
            {
                return objcd_Cliente.Registrar(obj, out Mensaje); // Uso de out para retornar mensajes
            }

        }

        // Método para editar un Cliente
        public bool Editar(Cliente obj, out string Mensaje) // Método para editar un Cliente
        {
            Mensaje = string.Empty; // Inicializar el mensaje

            if (obj.Documento == "") // Validar que el documento no esté vacío
            {
                Mensaje += " Es necesario indicar el DOCUMENTO del Cliente\n";
            }

            if (obj.NombreCompleto == "") // Validar que el nombre no esté vacío
            {
                Mensaje += " Es necesario indicar el NOMBRE del Cliente\n";
            }

            if (obj.Correo == "") // Validar que la contraseña no esté vacía
            {
                Mensaje += " Es necesario indicar el correo del Cliente\n";
            }

            if (Mensaje != string.Empty)
            {
                return false; // Si hay mensajes de error, retornar 0
            }
            else
            {
                return objcd_Cliente.Editar(obj, out Mensaje); // retorna el resultado de la edición
            }
        }

        // Método para eliminar un Cliente
        public bool Eliminar(Cliente obj, out string Mensaje) // Método para eliminar un Cliente
        {
            return objcd_Cliente.Eliminar(obj, out Mensaje); // Uso de out para retornar mensajes
        }
    }
}

