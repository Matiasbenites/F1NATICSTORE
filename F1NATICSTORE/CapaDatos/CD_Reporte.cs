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
    public class CD_Reporte
    {
        public List<ReporteCompra> Compra(string fechainicio, string fechafin, int idproveedor)
        {
            List<ReporteCompra> lista = new List<ReporteCompra>();

            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena)) // Usar using para asegurar el cierre de la conexión
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand("sp_ReporteCompras", oconexion))
                    {
                        cmd.Parameters.Add("@fechainicio", SqlDbType.VarChar, 10).Value = fechainicio; // Agregar parámetros
                        cmd.Parameters.Add("@fechafin", SqlDbType.VarChar, 10).Value = fechafin;
                        cmd.Parameters.Add("@idproveedor", SqlDbType.Int).Value = idproveedor;
                        cmd.CommandType = CommandType.StoredProcedure; // Especificar que es un procedimiento almacenado

                        oconexion.Open(); // Abrir la conexión antes de ejecutar el comando

                        using (SqlDataReader dr = cmd.ExecuteReader()) // Usar SqlDataReader para leer los datos
                        {
                            while (dr.Read())
                            {
                                lista.Add(new ReporteCompra() // Mapear los datos a la entidad Producto
                                {
                                    FechaRegistro = dr["FechaRegistro"].ToString(),
                                    TipoDocumento = dr["TipoDocumento"].ToString(),
                                    NumeroDocumento = dr["NumeroDocumento"].ToString(),
                                    MontoTotal = Convert.ToDecimal(dr["MontoTotal"]),
                                    UsuarioRegistro = dr["UsuarioRegistro"].ToString(),
                                    DocumentoProveedor = dr["DocumentoProveedor"].ToString(),
                                    RazonSocial = dr["RazonSocial"].ToString(),
                                    CodigoProducto = dr["CodigoProducto"].ToString(),
                                    NombreProducto = dr["NombreProducto"].ToString(),
                                    Categoria = dr["Categoría"].ToString(),
                                    PrecioCompra = Convert.ToDecimal(dr["PrecioCompra"]),
                                    PrecioVenta = Convert.ToDecimal(dr["PrecioVenta"]),
                                    Cantidad = Convert.ToInt32(dr["Cantidad"]),
                                    SubTotal = dr["SubTotal"].ToString()
                                });
                            }
                        }

                    }
                }
                catch (Exception ex) // Manejo de excepciones
                {
                    lista = new List<ReporteCompra>(); // Retornar una lista vacía en caso de error
                }
            }

            return lista;

        }

        public List<ReporteVenta> Venta(string fechainicio, string fechafin)
        {
            List<ReporteVenta> lista = new List<ReporteVenta>();

            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena)) // Usar using para asegurar el cierre de la conexión
            {

                try
                {
                    StringBuilder query = new StringBuilder(); // Usar StringBuilder para construir la consulta SQL
                    SqlCommand cmd = new SqlCommand("sp_ReporteVentas", oconexion); // Usar el procedimiento almacenado
                    cmd.CommandType = CommandType.StoredProcedure; // Especificar que es un procedimiento almacenado
                    cmd.Parameters.Add("@fechainicio", SqlDbType.VarChar, 10).Value = fechainicio; // Agregar parámetros
                    cmd.Parameters.Add("@fechafin", SqlDbType.VarChar, 10).Value = fechafin;

                    oconexion.Open(); // Abrir la conexión antes de ejecutar el comando

                    using (SqlDataReader dr = cmd.ExecuteReader()) // Usar SqlDataReader para leer los datos
                    {
                        while (dr.Read())
                        {
                            lista.Add(new ReporteVenta() // Mapear los datos a la entidad ReporteVenta
                            {
                                FechaRegistro = dr["FechaRegistro"].ToString(),
                                TipoDocumento = dr["TipoDocumento"].ToString(),
                                NumeroDocumento = dr["NumeroDocumento"].ToString(),
                                MontoTotal = Convert.ToDecimal(dr["MontoTotal"]),
                                UsuarioRegistro = dr["UsuarioRegistro"].ToString(),
                                DocumentoCliente = dr["DocumentoCliente"].ToString(),
                                NombreCliente = dr["NombreCliente"].ToString(),
                                CodigoProducto = dr["CodigoProducto"].ToString(),
                                NombreProducto = dr["NombreProducto"].ToString(),
                                Categoria = dr["Categoria"].ToString(),
                                PrecioVenta = Convert.ToDecimal(dr["PrecioVenta"]),
                                Cantidad = Convert.ToInt32(dr["Cantidad"]),
                                SubTotal = dr["SubTotal"].ToString()
                            });
                        }
                    }

                }
                catch (Exception ex) // Manejo de excepciones
                {
                    lista = new List<ReporteVenta>(); // Retornar una lista vacía en caso de error
                }
            }

            return lista;

        }
    }
}