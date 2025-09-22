﻿using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CD_Rol
    {
        public List<Rol> Listar()
        {
            List<Rol> lista = new List<Rol>();

            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {

                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT IdRol, Descripcion FROM Rol");

                    SqlCommand cmd = new SqlCommand(query.ToString(), oconexion);

                    cmd.CommandType = CommandType.Text;

                    oconexion.Open(); // abre la conexión a BD

                    using (SqlDataReader dr = cmd.ExecuteReader()) // lee las respuestas
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Rol() // rellena la lista de permisos
                            {
                                IdRol = Convert.ToInt32(dr["IdRol"]),
                                Descripcion = dr["Descripcion"].ToString()
                            });
                        }
                    }

                }
                catch (Exception ex)
                {
                    lista = new List<Rol>();
                }
            }

            return lista;
        }
    }
}
