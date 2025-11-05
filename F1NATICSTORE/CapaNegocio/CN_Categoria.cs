using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Categoria
    {
        private CD_Categoria objcd_Categoria = new CD_Categoria(); // Instancia de la capa de datos
        public List<Categoria> Listar() // Método para listar Categorias
        {
            return objcd_Categoria.Listar(); // Retorna la lista de Categorias desde la capa de datos
        }
        // Método para registrar un nuevo Categoria
        public int Registrar(Categoria obj, out string Mensaje) // Método para registrar un nuevo Categoria
        {
            Mensaje = string.Empty; // Inicializar el mensaje

            if (obj.Descripcion == "") // Validar que la descripcion no esté vacío
            {
                Mensaje += " Es necesario la descripcion de la Categoria\n";
            }

            if (Mensaje != string.Empty)
            {
                return 0; // Si hay mensajes de error, retornar 0
            }
            else
            {
                return objcd_Categoria.Registrar(obj, out Mensaje); // Uso de out para retornar mensajes
            }

        }

        // Método para editar un Categoria
        public bool Editar(Categoria obj, out string Mensaje) // Método para editar un Categoria
        {
            Mensaje = string.Empty; // Inicializar el mensaje

            if (obj.Descripcion == "") // Validar que la descripcion no esté vacío
            {
                Mensaje += " Es necesario la descripcion de la Categoria\n";
            }

            if (Mensaje != string.Empty)
            {
                return false; // Si hay mensajes de error, retornar 0
            }
            else
            {
                return objcd_Categoria.Editar(obj, out Mensaje); // retorna el resultado de la edición
            }
        }

        // Método para eliminar un Categoria
        public bool Eliminar(Categoria obj, out string Mensaje) // Método para eliminar un Categoria
        {
            return objcd_Categoria.Eliminar(obj, out Mensaje); // Uso de out para retornar mensajes
        }
    }
}

