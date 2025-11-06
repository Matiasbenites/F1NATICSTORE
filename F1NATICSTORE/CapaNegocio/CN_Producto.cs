using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Producto
    {
        private CD_Producto objcd_Producto = new CD_Producto(); // Instancia de la capa de datos
        public List<Producto> Listar() // Método para listar Productos
        {
            return objcd_Producto.Listar(); // Retorna la lista de Productos desde la capa de datos
        }
        // Método para registrar un nuevo Producto
        public int Registrar(Producto obj, out string Mensaje) // Método para registrar un nuevo Producto
        {
            Mensaje = string.Empty; // Inicializar el mensaje

            if (obj.Codigo == "") // Validar que el documento no esté vacío
            {
                Mensaje += " Es necesario indicar el CODIGO del Producto\n";
            }

            if (obj.Nombre == "") // Validar que el nombre no esté vacío
            {
                Mensaje += " Es necesario indicar el NOMBRE del Producto\n";
            }

            if (obj.Descripcion == "") // Validar que la contraseña no esté vacía
            {
                Mensaje += " Es necesario indicar la DESCRIPCION del Producto\n";
            }

            if (Mensaje != string.Empty)
            {
                return 0; // Si hay mensajes de error, retornar 0
            }
            else
            {
                return objcd_Producto.Registrar(obj, out Mensaje); // Uso de out para retornar mensajes
            }

        }

        // Método para editar un Producto
        public bool Editar(Producto obj, out string Mensaje) // Método para editar un Producto
        {
            Mensaje = string.Empty; // Inicializar el mensaje

            if (obj.Codigo == "") // Validar que el documento no esté vacío
            {
                Mensaje += " Es necesario indicar el CODIGO del Producto\n";
            }

            if (obj.Nombre == "") // Validar que el nombre no esté vacío
            {
                Mensaje += " Es necesario indicar el NOMBRE del Producto\n";
            }

            if (obj.Descripcion == "") // Validar que la contraseña no esté vacía
            {
                Mensaje += " Es necesario indicar la DESCRIPCION del Producto\n";
            }

            if (Mensaje != string.Empty)
            {
                return false; // Si hay mensajes de error, retornar 0
            }
            else
            {
                return objcd_Producto.Editar(obj, out Mensaje); // Uso de out para retornar mensajes
            }
        }

        // Método para eliminar un Producto
        public bool Eliminar(Producto obj, out string Mensaje) // Método para eliminar un Producto
        {
            return objcd_Producto.Eliminar(obj, out Mensaje); // Uso de out para retornar mensajes
        }
    }
}
