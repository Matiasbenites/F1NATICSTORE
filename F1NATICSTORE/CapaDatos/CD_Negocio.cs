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

                    string query = "select IdNegocio,Nombre,TipoFactura,CUIT,CondicionIva,Direccion from Negocio  where IdNegocio = 1";
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
                    query.AppendLine("update Negocio set Nombre = @Nombre, TipoFactura = @TipoFactura, Cuit = @CUIT, CondicionIva = @CondicionIva, Direccion = @Direccion where IdNegocio = 1");

                    SqlCommand cmd = new SqlCommand(query.ToString(), conexion);
                    cmd.Parameters.AddWithValue("@Nombre", objeto.Nombre);
                    cmd.Parameters.AddWithValue("@TipoFactura", objeto.TipoFactura);
                    cmd.Parameters.AddWithValue("@CUIT", objeto.Cuit);
                    cmd.Parameters.AddWithValue("@CondicionIva", objeto.CondicionIVA);
                    cmd.Parameters.AddWithValue("@Direccion", objeto.Direccion);
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
            obtenido = true;

            byte[] LogoBytes = new byte[0];

            try
            {
                using (SqlConnection conexion = new SqlConnection(Conexion.cadena))
                {
                    conexion.Open();
                    string query = "select Logo from Negocio  where IdNegocio = 1";

                    SqlCommand cmd = new SqlCommand(query, conexion);

                    cmd.CommandType = CommandType.Text;

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            LogoBytes = (byte[])dr["Logo"];
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                obtenido = false;
                LogoBytes = new byte[0];


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
                    query.AppendLine("update Negocio set Logo = @imagen where IdNegocio = 1");
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