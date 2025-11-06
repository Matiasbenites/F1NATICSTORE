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
    public class CD_Proveedor
    {
        public List<Proveedor> Listar()
        {
            List<Proveedor> lista = new List<Proveedor>();

            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena)) // Usar using para asegurar el cierre de la conexión
            {

                try
                {

                    StringBuilder query = new StringBuilder(); // Usar StringBuilder para construir la consulta SQL
                    query.AppendLine("SELECT IdProveedor,Documento,RazonSocial,Correo,Telefono,Estado FROM PROVEEDOR"); // Consulta SQL mejorada

                    SqlCommand cmd = new SqlCommand(query.ToString(), oconexion); // Usar el comando con la consulta construida
                    cmd.CommandType = CommandType.Text; // Especificar que es una consulta de texto
                    oconexion.Open(); // Abrir la conexión antes de ejecutar el comando
                    using (SqlDataReader dr = cmd.ExecuteReader()) // Usar SqlDataReader para leer los datos
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Proveedor() // Mapear los datos a la entidad Proveedor
                            {
                                IdProveedor = Convert.ToInt32(dr["IdProveedor"]),
                                Documento = dr["Documento"].ToString(),
                                RazonSocial = dr["RazonSocial"].ToString(),
                                Correo = dr["Correo"].ToString(),
                                Telefono = dr["Telefono"].ToString(),
                                Estado = Convert.ToBoolean(dr["Estado"])
                            });
                        }
                    }

                }
                catch (Exception ex) // Manejo de excepciones
                {
                    lista = new List<Proveedor>(); // Retornar una lista vacía en caso de error
                }
            }

            return lista;
        }


        // Método para REGISTRAR un nuevo Proveedor
        public int Registrar(Proveedor obj, out string Mensaje) // Uso de out para retornar mensajes
        {
            int idProveedorgenerado = 0; // Variable para almacenar el ID generado
            Mensaje = string.Empty; // Inicializar el mensaje como cadena vacía


            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena)) // Usar using para asegurar el cierre de la conexión
                {
                    SqlCommand cmd = new SqlCommand("sp_RegistrarProveedor", oconexion); // Usar un procedimiento almacenado para la inserción
                    cmd.Parameters.AddWithValue("Documento", obj.Documento); // Agregar parámetros con AddWithValue
                    cmd.Parameters.AddWithValue("RazonSocial", obj.RazonSocial);
                    cmd.Parameters.AddWithValue("Correo", obj.Correo);
                    cmd.Parameters.AddWithValue("Telefono", obj.Telefono);
                    cmd.Parameters.AddWithValue("Estado", obj.Estado);
                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output; // Parámetro de salida para el ID generado
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output; // Parámetro de salida para el mensaje
                    cmd.CommandType = CommandType.StoredProcedure; // Especificar que es un procedimiento almacenado

                    oconexion.Open(); // Abrir la conexión antes de ejecutar el comando

                    cmd.ExecuteNonQuery(); // Ejecutar el comando

                    idProveedorgenerado = Convert.ToInt32(cmd.Parameters["Resultado"].Value); // Obtener el ID generado
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString(); // Obtener el mensaje
                }
                {

                }
            }
            catch (Exception ex)
            {
                idProveedorgenerado = 0;
                Mensaje = ex.Message;
            }

            return idProveedorgenerado;
        }


        // Método EDITAR Proveedor
        public bool Editar(Proveedor obj, out string Mensaje) // Uso de out para retornar mensajes
        {
            bool Resp = false; // Variable para almacenar el resultado de la operación
            Mensaje = string.Empty; // Inicializar el mensaje como cadena vacía


            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena)) // Usar using para asegurar el cierre de la conexión
                {
                    SqlCommand cmd = new SqlCommand("sp_ModificarProveedor", oconexion); // Usar un procedimiento almacenado para la inserción
                    cmd.Parameters.AddWithValue("IdProveedor", obj.IdProveedor); // Agregar parámetros con AddWithValue
                    cmd.Parameters.AddWithValue("Documento", obj.Documento);
                    cmd.Parameters.AddWithValue("RazonSocial", obj.RazonSocial);
                    cmd.Parameters.AddWithValue("Correo", obj.Correo);
                    cmd.Parameters.AddWithValue("Telefono", obj.Telefono);
                    cmd.Parameters.AddWithValue("Estado", obj.Estado);
                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output; // Parámetro de salida para la respuesta
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output; // Parámetro de salida para el mensaje
                    cmd.CommandType = CommandType.StoredProcedure; // Especificar que es un procedimiento almacenado

                    oconexion.Open(); // Abrir la conexión antes de ejecutar el comando

                    cmd.ExecuteNonQuery(); // Ejecutar el comando

                    Resp = Convert.ToBoolean(cmd.Parameters["Resultado"].Value); // Obtener la respuesta
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


        // Método ELIMINAR Proveedor

        public bool Eliminar(Proveedor obj, out string Mensaje) // Uso de out para retornar mensajes
        {
            bool Resp = false; // Variable para almacenar el ID generado
            Mensaje = string.Empty; // Inicializar el mensaje como cadena vacía


            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena)) // Usar using para asegurar el cierre de la conexión
                {
                    SqlCommand cmd = new SqlCommand("sp_EliminarProveedor", oconexion); // Usar un procedimiento almacenado para la inserción
                    cmd.Parameters.AddWithValue("IdProveedor", obj.IdProveedor); // Agregar parámetros con AddWithValue
                    cmd.Parameters.Add("Resulado", SqlDbType.Int).Direction = ParameterDirection.Output; // Parámetro de salida para el ID generado
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output; // Parámetro de salida para el mensaje
                    cmd.CommandType = CommandType.StoredProcedure; // Especificar que es un procedimiento almacenado

                    oconexion.Open(); // Abrir la conexión antes de ejecutar el comando

                    cmd.ExecuteNonQuery(); // Ejecutar el comando

                    Resp = Convert.ToBoolean(cmd.Parameters["Resultado"].Value); // Obtener el ID generado
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
