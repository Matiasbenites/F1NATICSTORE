using CapaEntidad;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CD_Producto
    {
        public List<Producto> Listar()
        {
            List<Producto> lista = new List<Producto>();

            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena)) // Usar using para asegurar el cierre de la conexión
            {

                try
                {
                    StringBuilder query = new StringBuilder(); // Usar StringBuilder para construir la consulta SQL
                    query.AppendLine("select IdProducto, Codigo, Nombre, p.Descripcion,c.Descripcion[DescripcionCategoria],c.IdCategoria,Stock, PrecioCompra, PrecioVenta,p.Estado from Producto p"); // Consulta SQL mejorada
                    query.AppendLine("inner join Categoria c on c.IdCategoria = p.IdCategoria"); // 



                    SqlCommand cmd = new SqlCommand(query.ToString(), oconexion); // Usar el comando con la consulta construida
                    cmd.CommandType = CommandType.Text; // Especificar que es una consulta de texto
                    oconexion.Open(); // Abrir la conexión antes de ejecutar el comando
                    using (SqlDataReader dr = cmd.ExecuteReader()) // Usar SqlDataReader para leer los datos
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Producto() // Mapear los datos a la entidad Producto
                            {
                                IdProducto = Convert.ToInt32(dr["IdProducto"]),
                                Codigo = dr["Codigo"].ToString(),
                                Nombre = dr["Nombre"].ToString(),
                                Descripcion = dr["Descripcion"].ToString(),
                                oCategoria = new Categoria()
                                {
                                    IdCategoria = Convert.ToInt32(dr["IdCategoria"]),
                                    Descripcion = dr["DescripcionCategoria"].ToString(),
                                },
                                Stock = Convert.ToInt32(dr["Stock"].ToString()),
                                PrecioCompra = Convert.ToDecimal(dr["PrecioCompra"]),
                                PrecioVenta = Convert.ToDecimal(dr["PrecioVenta"]),
                                Estado = Convert.ToBoolean(dr["Estado"]),
                            });
                        }
                    }

                }
                catch (Exception ex) // Manejo de excepciones
                {
                    lista = new List<Producto>(); // Retornar una lista vacía en caso de error
                }
            }

            return lista;
        }


        // Método para REGISTRAR un nuevo Producto
        public int Registrar(Producto obj, out string Mensaje) // Uso de out para retornar mensajes
        {
            int idProductogenerado = 0; // Variable para almacenar el ID generado
            Mensaje = string.Empty; // Inicializar el mensaje como cadena vacía


            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena)) // Usar using para asegurar el cierre de la conexión
                {
                    SqlCommand cmd = new SqlCommand("sp_RegistrarProducto", oconexion); // Usar un procedimiento almacenado para la inserción
                    cmd.Parameters.AddWithValue("Codigo", obj.Codigo); // Agregar parámetros con AddWithValue
                    cmd.Parameters.AddWithValue("Nombre", obj.Nombre);
                    cmd.Parameters.AddWithValue("Descripcion", obj.Descripcion);
                    cmd.Parameters.AddWithValue("IdCategoria", obj.oCategoria.IdCategoria);
                    cmd.Parameters.AddWithValue("Estado", obj.Estado);
                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output; // Parámetro de salida para el ID generado
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output; // Parámetro de salida para el mensaje
                    cmd.CommandType = CommandType.StoredProcedure; // Especificar que es un procedimiento almacenado

                    oconexion.Open(); // Abrir la conexión antes de ejecutar el comando

                    cmd.ExecuteNonQuery(); // Ejecutar el comando

                    idProductogenerado = Convert.ToInt32(cmd.Parameters["Resultado"].Value); // Obtener el ID generado
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString(); // Obtener el mensaje
                }
                {

                }
            }
            catch (Exception ex)
            {
                idProductogenerado = 0;
                Mensaje = ex.Message;
            }

            return idProductogenerado;
        }


        // Método EDITAR Producto
        public bool Editar(Producto obj, out string Mensaje) // Uso de out para retornar mensajes
        {
            bool Resp = false; // Variable para almacenar el resultado de la operación
            Mensaje = string.Empty; // Inicializar el mensaje como cadena vacía


            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena)) // Usar using para asegurar el cierre de la conexión
                {
                    SqlCommand cmd = new SqlCommand("sp_ModificarProducto", oconexion); // Usar un procedimiento almacenado para la inserción
                    cmd.Parameters.AddWithValue("IdProducto", obj.IdProducto); // Agregar parámetros con AddWithValue
                    cmd.Parameters.AddWithValue("Codigo", obj.Codigo);
                    cmd.Parameters.AddWithValue("Nombre", obj.Nombre);
                    cmd.Parameters.AddWithValue("Descripcion", obj.Descripcion);
                    cmd.Parameters.AddWithValue("IdCategoria", obj.oCategoria.IdCategoria);
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


        // Método ELIMINAR Producto

        public bool Eliminar(Producto obj, out string Mensaje) // Uso de out para retornar mensajes
        {
            bool Resp = false; // Variable para almacenar el ID generado
            Mensaje = string.Empty; // Inicializar el mensaje como cadena vacía


            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena)) // Usar using para asegurar el cierre de la conexión
                {
                    SqlCommand cmd = new SqlCommand("sp_EliminarProducto", oconexion); // Usar un procedimiento almacenado para la inserción
                    cmd.Parameters.AddWithValue("IdProducto", obj.IdProducto); // Agregar parámetros con AddWithValue
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

