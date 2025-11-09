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
    public class CD_Compra
    {
        // Método para obtener ids correlativos de compra
        public int ObtenerCorrelativo()
        {
            int idcorrelativo = 0;

            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena)) // Usar using para asegurar el cierre de la conexión
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("select count(*) +1 from Compra");

                    using (SqlCommand cmd = new SqlCommand(query.ToString(), oconexion))
                    {
                        cmd.CommandType = CommandType.Text;
                        oconexion.Open();
                        idcorrelativo = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                }
                catch (Exception ex)
                {
                    idcorrelativo = 0;
                    throw new Exception("Error al obtener el correlativo de compra", ex);
                }
            }
            return idcorrelativo;
        }

        // Método para registrar una compra con detalle respectivamente
        public bool Registrar(Compra obj, DataTable DetalleCompra, out string Mensaje)
        {
            bool Respuesta = false;
            Mensaje = string.Empty;

            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand("sp_RegistrarCompra", oconexion))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("IdUsuario", obj.oUsuario.IdUsuario);
                        cmd.Parameters.AddWithValue("IdProveedor", obj.oProveedor.IdProveedor);
                        cmd.Parameters.AddWithValue("TipoDocumento", obj.TipoDocumento);
                        cmd.Parameters.AddWithValue("NumeroDocumento", obj.NumeroDocumento);
                        cmd.Parameters.AddWithValue("MontoTotal", obj.MontoTotal);
                        cmd.Parameters.AddWithValue("DetalleCompra", DetalleCompra);
                        cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                        cmd.Parameters.Add("Mensaje", SqlDbType.VarChar,500).Direction = ParameterDirection.Output;

                        oconexion.Open();
                        cmd.ExecuteNonQuery();

                        Respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
                        Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                    }
                }
                catch (Exception ex)
                {
                    Respuesta = false;
                    Mensaje = ex.Message;
                }
            }

            return Respuesta;
        }

        public Compra ObtenerCompra(string numero)
        {
            Compra obj = new Compra();

            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena)) // Usar using para asegurar el cierre de la conexión
            {
                try
                {
                    StringBuilder query = new StringBuilder(); // Usar StringBuilder para construir la consulta SQL
                    query.AppendLine("select c.IdCompra,"); // Consulta SQL mejorada
                    query.AppendLine("u.NombreCompleto,");
                    query.AppendLine("pr.Documento,");
                    query.AppendLine("pr.RazonSocial,");
                    query.AppendLine("c.TipoDocumento,");
                    query.AppendLine("c.NumeroDocumento,");
                    query.AppendLine("c.MontoTotal,");
                    query.AppendLine("convert(char(10), c.FechaRegistro, 103)[FechaRegistro]");
                    query.AppendLine("from Compra c");
                    query.AppendLine("inner join Usuario u on u.IdUsuario = c.IdUsuario");
                    query.AppendLine("inner join Proveedor pr on pr.IdProveedor = c.IdProveedor");
                    query.AppendLine("where c.NumeroDocumento = @numero");


                    using (SqlCommand cmd = new SqlCommand(query.ToString(), oconexion)) // Usar el comando con la consulta construida
                    {
                        cmd.Parameters.AddWithValue("@numero", numero);
                        cmd.CommandType = CommandType.Text; // Especificar que es una consulta de texto
                        oconexion.Open(); // Abrir la conexión antes de ejecutar el comando
                        using (SqlDataReader dr = cmd.ExecuteReader()) // Usar SqlDataReader para leer los datos
                        {
                            while (dr.Read())
                            {     // Configurar todos los atributos del objeto Compra
                                obj = new Compra()
                                {
                                    IdCompra = Convert.ToInt32(dr["IdCompra"]),
                                    oUsuario = new Usuario() { NombreCompleto = dr["NombreCompleto"].ToString() },
                                    oProveedor = new Proveedor()
                                    {
                                        Documento = dr["Documento"].ToString(),
                                        RazonSocial = dr["RazonSocial"].ToString()
                                    },
                                    TipoDocumento = dr["TipoDocumento"].ToString(),
                                    NumeroDocumento = dr["NumeroDocumento"].ToString(),
                                    MontoTotal = Convert.ToDecimal(dr["MontoTotal"]),
                                    FechaRegistro = dr["FechaRegistro"].ToString()
                                };
                            }
                        }
                    }
                }
                catch (Exception) // Manejo de excepciones
                {
                    obj = new Compra(); // Retornar una lista vacía en caso de error
                }
            }
            return obj;
        }

        public List<Detalle_Compra> ObtenerDetalleCompra(int idcompra)
        {
            List<Detalle_Compra> oLista = new List<Detalle_Compra>();

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
                {
                    oconexion.Open();

                    StringBuilder query = new StringBuilder();
                    query.AppendLine("select p.Nombre, dc.PrecioCompra, dc.Cantidad, dc.Total from DETALLE_COMPRA dc");
                    query.AppendLine("inner join PRODUCTO p on p.IdProducto = dc.IdProducto");
                    query.AppendLine("where dc.IdCompra = @idcompra");

                    using (SqlCommand cmd = new SqlCommand(query.ToString(), oconexion))
                    {
                    cmd.Parameters.AddWithValue("@idcompra", idcompra);
                    cmd.CommandType = System.Data.CommandType.Text;

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                oLista.Add(new Detalle_Compra
                                {
                                    oProducto = new Producto { Nombre = dr["Nombre"].ToString() },
                                    PrecioCompra = Convert.ToDecimal(dr["PrecioCompra"]),
                                    Cantidad = Convert.ToInt32(dr["Cantidad"]),
                                    Total = Convert.ToDecimal(dr["Total"])
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                oLista = new List<Detalle_Compra>();
            }

            return oLista;
        }
    }
}

