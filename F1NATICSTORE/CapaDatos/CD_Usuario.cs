using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using CapaEntidad;
using System.Text;

namespace CapaDatos
{
    public class CD_Usuario
    {
        public List<Usuario> Listar()
        {
            List<Usuario> lista = new List<Usuario>();

            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena)) // Usar using para asegurar el cierre de la conexión
            {

                try
                {

                    StringBuilder query = new StringBuilder(); // Usar StringBuilder para construir la consulta SQL
                    query.AppendLine("select u.IdUsuario, u.Documento, u.NombreCompleto, u.Correo, u.Clave, u.Estado, r.IdRol, r.Descripcion From Usuario u"); // Consulta SQL mejorada
                    query.AppendLine("inner join rol r on r.IdRol = u.IdRol"); // 



                    SqlCommand cmd = new SqlCommand(query.ToString(), oconexion); // Usar el comando con la consulta construida
                    cmd.CommandType = CommandType.Text; // Especificar que es una consulta de texto
                    oconexion.Open(); // Abrir la conexión antes de ejecutar el comando
                    using (SqlDataReader dr = cmd.ExecuteReader()) // Usar SqlDataReader para leer los datos
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Usuario() // Mapear los datos a la entidad Usuario
                            {
                                IdUsuario = Convert.ToInt32(dr["IdUsuario"]),
                                Documento = dr["Documento"].ToString(),
                                NombreCompleto = dr["NombreCompleto"].ToString(),
                                Correo = dr["Correo"].ToString(),
                                Clave = dr["Clave"].ToString(),
                                Estado = Convert.ToBoolean(dr["Estado"]),
                                oRol = new Rol()
                                {
                                    IdRol = Convert.ToInt32(dr["IdRol"]),
                                    Descripcion = dr["Descripcion"].ToString(),
                                },
                            });
                        }
                    }

                }
                catch (Exception ex) // Manejo de excepciones
                {
                    lista = new List<Usuario>(); // Retornar una lista vacía en caso de error
                }
            }

            return lista;
        }


        // Método para REGISTRAR un nuevo usuario
        public int Registrar(Usuario obj, out string Mensaje) // Uso de out para retornar mensajes
        {
            int idusuariogenerado = 0; // Variable para almacenar el ID generado
            Mensaje = string.Empty; // Inicializar el mensaje como cadena vacía


            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena)) // Usar using para asegurar el cierre de la conexión
                {
                    SqlCommand cmd = new SqlCommand("SP_REGISTRARUSUARIO", oconexion); // Usar un procedimiento almacenado para la inserción
                    cmd.Parameters.AddWithValue("Documento", obj.Documento); // Agregar parámetros con AddWithValue
                    cmd.Parameters.AddWithValue("NombreCompleto", obj.NombreCompleto);
                    cmd.Parameters.AddWithValue("Correo", obj.Correo);
                    cmd.Parameters.AddWithValue("Clave", obj.Clave);
                    cmd.Parameters.AddWithValue("IdRol", obj.oRol.IdRol); // Asegurarse de que oRol no sea nulo antes de acceder a IdRol
                    cmd.Parameters.AddWithValue("Estado", obj.Estado);
                    cmd.Parameters.Add("IdUsuarioResultado", SqlDbType.Int).Direction = ParameterDirection.Output; // Parámetro de salida para el ID generado
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output; // Parámetro de salida para el mensaje
                    cmd.CommandType = CommandType.StoredProcedure; // Especificar que es un procedimiento almacenado

                    oconexion.Open(); // Abrir la conexión antes de ejecutar el comando

                    cmd.ExecuteNonQuery(); // Ejecutar el comando

                    idusuariogenerado = Convert.ToInt32(cmd.Parameters["IdUsuarioResultado"].Value); // Obtener el ID generado
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString(); // Obtener el mensaje
                }
                {

                }
            }
            catch (Exception ex)
            {
                idusuariogenerado = 0;
                Mensaje = ex.Message;
            }

            return idusuariogenerado;
        }


        // Método EDITAR Usuario
        public bool Editar(Usuario obj, out string Mensaje) // Uso de out para retornar mensajes
        {
            bool Resp = false; // Variable para almacenar el resultado de la operación
            Mensaje = string.Empty; // Inicializar el mensaje como cadena vacía


            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena)) // Usar using para asegurar el cierre de la conexión
                {
                    SqlCommand cmd = new SqlCommand("SP_EDITARUSUARIO", oconexion); // Usar un procedimiento almacenado para la inserción
                    cmd.Parameters.AddWithValue("IdUsuario", obj.IdUsuario); // Agregar parámetros con AddWithValue
                    cmd.Parameters.AddWithValue("Documento", obj.Documento);
                    cmd.Parameters.AddWithValue("NombreCompleto", obj.NombreCompleto);
                    cmd.Parameters.AddWithValue("Correo", obj.Correo);
                    cmd.Parameters.AddWithValue("Clave", obj.Clave);
                    cmd.Parameters.AddWithValue("IdRol", obj.oRol.IdRol); // Asegurarse de que oRol no sea nulo antes de acceder a IdRol
                    cmd.Parameters.AddWithValue("Estado", obj.Estado);
                    cmd.Parameters.Add("Respuesta", SqlDbType.Int).Direction = ParameterDirection.Output; // Parámetro de salida para la respuesta
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output; // Parámetro de salida para el mensaje
                    cmd.CommandType = CommandType.StoredProcedure; // Especificar que es un procedimiento almacenado

                    oconexion.Open(); // Abrir la conexión antes de ejecutar el comando

                    cmd.ExecuteNonQuery(); // Ejecutar el comando

                    Resp = Convert.ToBoolean(cmd.Parameters["Respuesta"].Value); // Obtener la respuesta
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString(); // Obtener el mensaje
                }
                {

                }
            }
            catch (Exception ex) // Manejo de excepciones
            {
                Resp = false; // En caso de error, la respuesta es falsa
                Mensaje = ex.Message; // Capturar el mensaje de la excepción
            }

            return Resp; // Retornar el resultado de la operación
        }


        // Método ELIMINAR Usuario

        public bool Eliminar(Usuario obj, out string Mensaje) // Uso de out para retornar mensajes
        {
            bool Resp = false; // Variable para almacenar el ID generado
            Mensaje = string.Empty; // Inicializar el mensaje como cadena vacía


            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena)) // Usar using para asegurar el cierre de la conexión
                {
                    SqlCommand cmd = new SqlCommand("SP_ELIMINARUSUARIO", oconexion); // Usar un procedimiento almacenado para la inserción
                    cmd.Parameters.AddWithValue("IdUsuario", obj.IdUsuario); // Agregar parámetros con AddWithValue
                    cmd.Parameters.Add("Respuesta", SqlDbType.Int).Direction = ParameterDirection.Output; // Parámetro de salida para el ID generado
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output; // Parámetro de salida para el mensaje
                    cmd.CommandType = CommandType.StoredProcedure; // Especificar que es un procedimiento almacenado

                    oconexion.Open(); // Abrir la conexión antes de ejecutar el comando

                    cmd.ExecuteNonQuery(); // Ejecutar el comando

                    Resp = Convert.ToBoolean(cmd.Parameters["Respuesta"].Value); // Obtener el ID generado
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
