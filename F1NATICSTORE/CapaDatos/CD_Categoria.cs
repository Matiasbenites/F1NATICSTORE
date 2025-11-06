using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
<<<<<<< HEAD
    public class CD_Categoria
=======
     public class CD_Categoria
>>>>>>> 41d0856d80202121026c5d73399a30ab57738891
    {
        public List<Categoria> Listar()
        {
            List<Categoria> lista = new List<Categoria>();

            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena)) // Usar using para asegurar el cierre de la conexión
            {

                try
                {

                    StringBuilder query = new StringBuilder(); // Usar StringBuilder para construir la consulta SQL
<<<<<<< HEAD
                    query.AppendLine("select IdCategoria, Descripcion, Estado From CATEGORIA"); // Consulta SQL mejorada

                    SqlCommand cmd = new SqlCommand(query.ToString(), oconexion); // Usar el comando con la consulta construida
                    cmd.CommandType = CommandType.Text; // Especificar que es una consulta de texto
                    oconexion.Open(); // Abrir la conexión antes de ejecutar el comando
=======
                    query.AppendLine("select IdCategoria, Descripcion, Estado\tfrom Categoria"); // Consulta SQL mejorada
                    SqlCommand cmd = new SqlCommand(query.ToString(), oconexion); // Usar el comando con la consulta construida
                    cmd.CommandType = CommandType.Text; // Especificar que es una consulta de texto
                    
                    oconexion.Open(); // Abrir la conexión antes de ejecutar el comando
                   
>>>>>>> 41d0856d80202121026c5d73399a30ab57738891
                    using (SqlDataReader dr = cmd.ExecuteReader()) // Usar SqlDataReader para leer los datos
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Categoria() // Mapear los datos a la entidad Categoria
                            {
                                IdCategoria = Convert.ToInt32(dr["IdCategoria"]),
                                Descripcion = dr["Descripcion"].ToString(),
                                Estado = Convert.ToBoolean(dr["Estado"])
                            });
                        }
                    }

                }
                catch (Exception ex) // Manejo de excepciones
                {
                    lista = new List<Categoria>(); // Retornar una lista vacía en caso de error
                }
            }

            return lista;
        }


        // Método para REGISTRAR un nuevo Categoria
        public int Registrar(Categoria obj, out string Mensaje) // Uso de out para retornar mensajes
        {
            int idCategoriagenerado = 0; // Variable para almacenar el ID generado
            Mensaje = string.Empty; // Inicializar el mensaje como cadena vacía


            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena)) // Usar using para asegurar el cierre de la conexión
                {
<<<<<<< HEAD
                    SqlCommand cmd = new SqlCommand("SP_REGISTRARCATEGORIA", oconexion); // Usar un procedimiento almacenado para la inserción
                    cmd.Parameters.AddWithValue("Descripcion", obj.Descripcion); // Agregar parámetros con AddWithValue
=======
                    SqlCommand cmd = new SqlCommand("SP_RegistrarCategoria", oconexion); // Usar un procedimiento almacenado para la inserción
                    cmd.Parameters.AddWithValue("Descripcion", obj.Descripcion); // Agregar parámetros con AddWithValue
                    cmd.Parameters.AddWithValue("Estado", obj.Estado);// Agregar parámetros con AddWithValue
>>>>>>> 41d0856d80202121026c5d73399a30ab57738891
                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output; // Parámetro de salida para el ID generado
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output; // Parámetro de salida para el mensaje
                    cmd.CommandType = CommandType.StoredProcedure; // Especificar que es un procedimiento almacenado

                    oconexion.Open(); // Abrir la conexión antes de ejecutar el comando

                    cmd.ExecuteNonQuery(); // Ejecutar el comando

<<<<<<< HEAD
                    idCategoriagenerado = Convert.ToInt32(cmd.Parameters["Resultado"].Value); // Obtener el ID generado
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString(); // Obtener el mensaje
                }
=======
                    idCategoriagenerado = Convert.ToInt32(cmd.Parameters["Resultado"].Value); // Obtengo el resultado
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString(); // Obtener el mensaje
                }
                {

                }
>>>>>>> 41d0856d80202121026c5d73399a30ab57738891
            }
            catch (Exception ex)
            {
                idCategoriagenerado = 0;
                Mensaje = ex.Message;
            }

            return idCategoriagenerado;
        }


        // Método EDITAR Categoria
        public bool Editar(Categoria obj, out string Mensaje) // Uso de out para retornar mensajes
        {
            bool Resp = false; // Variable para almacenar el resultado de la operación
            Mensaje = string.Empty; // Inicializar el mensaje como cadena vacía


            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena)) // Usar using para asegurar el cierre de la conexión
                {
<<<<<<< HEAD
                    SqlCommand cmd = new SqlCommand("SP_EDITARCATEGORIA", oconexion); // Usar un procedimiento almacenado para la inserción
                    cmd.Parameters.AddWithValue("IdCategoria", obj.IdCategoria); // Agregar parámetros con AddWithValue
                    cmd.Parameters.AddWithValue("Descripcion", obj.Descripcion); // Agregar parámetros con AddWithValue
                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output; // Parámetro de salida para el ID generado
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output; // Parámetro de salida para el mensaje
=======
                    SqlCommand cmd = new SqlCommand("sp_EditarCategoria", oconexion); // Usar un procedimiento almacenado para la inserción
                    cmd.Parameters.AddWithValue("IdCategoria", obj.IdCategoria); 
                    cmd.Parameters.AddWithValue("Descripcion", obj.Descripcion);
                    cmd.Parameters.AddWithValue("Estado", obj.Estado);
                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output; 
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
>>>>>>> 41d0856d80202121026c5d73399a30ab57738891
                    cmd.CommandType = CommandType.StoredProcedure; // Especificar que es un procedimiento almacenado

                    oconexion.Open(); // Abrir la conexión antes de ejecutar el comando

                    cmd.ExecuteNonQuery(); // Ejecutar el comando

<<<<<<< HEAD
                    Resp = Convert.ToBoolean(cmd.Parameters["Resultado"].Value); // Obtener la respuesta
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString(); // Obtener el mensaje
                }
=======
                    Resp = Convert.ToBoolean(cmd.Parameters["Resultado"].Value); // Obtener el resultado
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString(); // Obtener el mensaje
                }
                {

                }
>>>>>>> 41d0856d80202121026c5d73399a30ab57738891
            }
            catch (Exception ex) // Manejo de excepciones
            {
                Resp = false; // En caso de error, la respuesta es falsa
                Mensaje = ex.Message; // Capturar el mensaje de la excepción
            }

            return Resp; // Retornar el resultado de la operación
        }


        // Método ELIMINAR Categoria

        public bool Eliminar(Categoria obj, out string Mensaje) // Uso de out para retornar mensajes
        {
            bool Resp = false; // Variable para almacenar el ID generado
            Mensaje = string.Empty; // Inicializar el mensaje como cadena vacía


            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena)) // Usar using para asegurar el cierre de la conexión
                {
<<<<<<< HEAD
                    SqlCommand cmd = new SqlCommand("SP_ELIMINARCATEGORIA", oconexion); // Usar un procedimiento almacenado para la inserción
=======
                    SqlCommand cmd = new SqlCommand("SP_ELIMINARCategoria", oconexion); // Usar un procedimiento almacenado para la inserción
>>>>>>> 41d0856d80202121026c5d73399a30ab57738891
                    cmd.Parameters.AddWithValue("IdCategoria", obj.IdCategoria); // Agregar parámetros con AddWithValue
                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output; // Parámetro de salida para el ID generado
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output; // Parámetro de salida para el mensaje
                    cmd.CommandType = CommandType.StoredProcedure; // Especificar que es un procedimiento almacenado

                    oconexion.Open(); // Abrir la conexión antes de ejecutar el comando

                    cmd.ExecuteNonQuery(); // Ejecutar el comando

<<<<<<< HEAD
                    Resp = Convert.ToBoolean(cmd.Parameters["Resultado"].Value); // Obtener el ID generado
=======
                    Resp = Convert.ToBoolean(cmd.Parameters["Resultado"].Value); // Obtener el resultado
>>>>>>> 41d0856d80202121026c5d73399a30ab57738891
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString(); // Obtener el mensaje
                }
                {

                }
            }
            catch (Exception ex)
            {
                Resp = false;
                Mensaje = ex.Message;
            }

            return Resp;
        }


    }
}
