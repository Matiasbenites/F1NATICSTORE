using CapaDatos;
using CapaEntidad;
using System.Collections.Generic;

namespace CapaNegocio
{
    public class CN_Usuario
    {
        private CD_Usuario objcd_usuario = new CD_Usuario(); // Instancia de la capa de datos
        public List<Usuario> Listar() // Método para listar usuarios
        {
            return objcd_usuario.Listar(); // Retorna la lista de usuarios desde la capa de datos
        }
        // Método para registrar un nuevo usuario
        public int Registrar(Usuario obj, out string Mensaje) // Método para registrar un nuevo usuario
        {
            Mensaje = string.Empty; // Inicializar el mensaje

            if (obj.Documento == "") // Validar que el documento no esté vacío
            {
                Mensaje += " Es necesario indicar el DOCUMENTO del usuario\n";
            }

            if (obj.NombreCompleto == "") // Validar que el nombre no esté vacío
            {
                Mensaje += " Es necesario indicar el NOMBRE del usuario\n";
            }

            if (obj.Clave == "") // Validar que la contraseña no esté vacía
            {
                Mensaje += " Es necesario indicar la CONTRASEÑA del usuario\n";
            }

            if (Mensaje != string.Empty) {
                return 0; // Si hay mensajes de error, retornar 0
            }
            else
            {
                return objcd_usuario.Registrar(obj, out Mensaje); // Uso de out para retornar mensajes
            }

        }

        // Método para editar un usuario
        public bool Editar(Usuario obj, out string Mensaje) // Método para editar un usuario
        {
            Mensaje = string.Empty; // Inicializar el mensaje

            if (obj.Documento == "") // Validar que el documento no esté vacío
            {
                Mensaje += " Es necesario indicar el DOCUMENTO del usuario\n";
            }

            if (obj.NombreCompleto == "") // Validar que el nombre no esté vacío
            {
                Mensaje += " Es necesario indicar el NOMBRE del usuario\n";
            }

            if (obj.Clave == "") // Validar que la contraseña no esté vacía
            {
                Mensaje += " Es necesario indicar la CONTRASEÑA del usuario\n";
            }

            if (Mensaje != string.Empty)
            {
                return false; // Si hay mensajes de error, retornar 0
            }
            else
            {
                return objcd_usuario.Editar(obj, out Mensaje); // retorna el resultado de la edición
            }
        }

        // Método para eliminar un usuario
        public bool Eliminar(Usuario obj, out string Mensaje) // Método para eliminar un usuario
        {
            return objcd_usuario.Eliminar(obj, out Mensaje); // Uso de out para retornar mensajes
        }
    }
}
