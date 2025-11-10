using CapaDatos;
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
    public class CD_Negocio
    {
        public int IdNegocio { get; private set; }
        public string Nombre { get; private set; }
        public char TipoFactura { get; private set; }
        public string Cuit { get; private set; }
        public string CondicionIVA { get; private set; }
        public string Direccion { get; private set; }

        public Negocio ObtenetDatos()
        {

            Negocio obj = new Negocio();

            try
            {
                using (SqlConnection conexion = new SqlConnection(Conexion.cadena))
                {
                    conexion.Open();

                    string query = "select IdNegocio,Nombre,TipoFactura,CUIT,CondicionIva,Direccion from Negocio where IdNegocio =1";
                    SqlCommand cmd = new SqlCommand(query, conexion);
                    cmd.CommandType = CommandType.Text;

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            obj = new Negocio()
                            {
                                IdNegocio = int.Parse(dr["IdNegocio"].ToString()),
                                Nombre = dr["Nombre"].ToString(),
                                TipoFactura = char.Parse(dr["TipoFactura"].ToString()),
                                Cuit = dr["CUIT"].ToString(),
                                CondicionIVA = dr["CondicionIva"].ToString(),
                                Direccion = dr["Direccion"].ToString()
                            };
                        }
                    }
                }
            }
            catch
            {
                obj = new Negocio();
            }

            return obj;
        }

        public bool GuardarDatos(Negocio objeto, out string mensaje)
        {
            mensaje = string.Empty;
            bool respuesta = true;

            try
            {
                using (SqlConnection conexion = new SqlConnection(Conexion.cadena))
                {
                    conexion.Open();
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("update Negocio set Nombre = @Nombre, TipoFactura = @TipoFactura, Cuit = @CUIT, CondicionIva = @CondicionIva, Direccion = @Direccion where IdNegocio =1");

                    SqlCommand cmd = new SqlCommand(query.ToString(), conexion);
                    cmd.Parameters.Add("@Nombre", SqlDbType.VarChar, 60).Value = objeto.Nombre ?? (object)DBNull.Value;
                    cmd.Parameters.Add("@TipoFactura", SqlDbType.VarChar, 1).Value = objeto.TipoFactura.ToString();
                    cmd.Parameters.Add("@CUIT", SqlDbType.VarChar, 50).Value = objeto.Cuit ?? (object)DBNull.Value;
                    cmd.Parameters.Add("@CondicionIva", SqlDbType.VarChar, 60).Value = objeto.CondicionIVA ?? (object)DBNull.Value;
                    cmd.Parameters.Add("@Direccion", SqlDbType.VarChar, 60).Value = objeto.Direccion ?? (object)DBNull.Value;
                    cmd.CommandType = CommandType.Text;

                    if (cmd.ExecuteNonQuery() < 1)
                    {
                        mensaje = "No se pudo actualizar los datos del negocio";
                        respuesta = false;
                    }


                }
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
                respuesta = false;
            }
            return respuesta;

        }

        public byte[] ObtenerLogo(out bool obtenido)
        {
            // Por defecto no se obtuvo el logo
            obtenido = false;

            byte[] LogoBytes = new byte[0];

            try
            {
                using (SqlConnection conexion = new SqlConnection(Conexion.cadena))
                {
                    conexion.Open();
                    string query = "select Logo from Negocio where IdNegocio =1";

                    using (SqlCommand cmd = new SqlCommand(query, conexion))
                    {
                        cmd.CommandType = CommandType.Text;

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                int idx = dr.GetOrdinal("Logo");
                                if (!dr.IsDBNull(idx))
                                {
                                    var value = dr.GetValue(idx);
                                    if (value is byte[] bytes && bytes.Length > 0)
                                    {
                                        LogoBytes = bytes;
                                        obtenido = true;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                obtenido = false;
                LogoBytes = new byte[0];
                // opcional: loggear ex.Message
            }
            return LogoBytes;
        }

        public bool ActualizarLogo(byte[] image, out string mensaje)
        {
            mensaje = string.Empty;
            bool respuesta = true;
            try
            {
                using (SqlConnection conexion = new SqlConnection(Conexion.cadena))
                {
                    conexion.Open();
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("update Negocio set Logo = @imagen where IdNegocio =1");
                    SqlCommand cmd = new SqlCommand(query.ToString(), conexion);
                    cmd.Parameters.AddWithValue("@imagen", image);
                    cmd.CommandType = CommandType.Text;
                    if (cmd.ExecuteNonQuery() < 1)
                    {
                        mensaje = "No se pudo actualizar el logo del negocio";
                        respuesta = false;
                    }
                }
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
                respuesta = false;
            }
            return respuesta;

        }
    }
}