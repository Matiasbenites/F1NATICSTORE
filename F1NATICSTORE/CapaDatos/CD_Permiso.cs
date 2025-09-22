using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CD_Permiso
    {
        public List<Permiso> Listar(int idusuario)
        {
            List<Permiso> lista = new List<Permiso>();

            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {

                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT p.IdRol, p.NombreMenu FROM PERMISO p");
                    query.AppendLine("INNER JOIN ROL r on r.IdRol = p.IdRol");
                    query.AppendLine("INNER JOIN USUARIO u on u.IdRol = r.IdRol");
                    query.AppendLine("WHERE u.IdUsuario = @idusuario");
                    //query.AppendLine("SELECT p.IdRol, p.NombreMenu FROM PERMISO p");
                    //query.AppendLine("WHERE p.IdRol = (SELECT IdRol FROM USUARIO WHERE IdUsuario = @idusuario)");
                                                                
                    SqlCommand cmd = new SqlCommand(query.ToString(), oconexion);
                    cmd.Parameters.AddWithValue("@idusuario", idusuario); // Reemplaza el parametro de la query
                    cmd.CommandType = CommandType.Text;

                    oconexion.Open(); // abre la conexión a BD

                    using (SqlDataReader dr = cmd.ExecuteReader()) // lee las respuestas
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Permiso() // rellena la lista de permisos
                            {
                                oRol = new Rol() { IdRol = Convert.ToInt32(dr["IdRol"]) },
                                NombreMenu = dr["NombreMenu"].ToString(),                    
                            });
                        }
                    }

                }
                catch (Exception ex)
                {
                    lista = new List<Permiso>();
                }
            }

            return lista;
        }
    }
}
