using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CD_Backup
    {
        private readonly string connectionString;

        public CD_Backup(string cadenaConexion)
        {
            connectionString = cadenaConexion;
        }

        public void RealizarBackup(string rutaDestino)
        {
            try
            {
                // Comprobar si la ruta indicada es válida para el servidor.
                var csb = new SqlConnectionStringBuilder(connectionString);
                string dataSource = csb.DataSource; // puede ser 'MYSERVER' o 'MYSERVER\\SQLEXPRESS' o 'localhost'
                string serverName = dataSource.Split('\\')[0];
                bool serverIsLocal = string.Equals(serverName, ".", StringComparison.OrdinalIgnoreCase)
                    || string.Equals(serverName, "(local)", StringComparison.OrdinalIgnoreCase)
                    || string.Equals(serverName, "localhost", StringComparison.OrdinalIgnoreCase)
                    || string.Equals(serverName, Environment.MachineName, StringComparison.OrdinalIgnoreCase);

                // Si el servidor es remoto y la ruta no es UNC, no intentamos crear carpetas locales (fallará en el servidor).
                if (!serverIsLocal && !rutaDestino.StartsWith("\\\\"))
                {
                    throw new Exception($"La ruta '{rutaDestino}' no es accesible desde el servidor '{serverName}'. Use una ruta UNC (\\\\servidor\\share) o una ruta local en el servidor.");
                }

                using (SqlConnection conexion = new SqlConnection(connectionString))
                {
                    conexion.Open();

                    string nombreDB = conexion.Database;
                    string nombreBackup = $"{nombreDB}_{DateTime.Now:yyyyMMdd_HHmmss}.bak";
                    string rutaFinal = Path.Combine(rutaDestino, nombreBackup);

                    // Si el servidor es local al equipo donde corre esta aplicación, podemos crear la carpeta.
                    if (serverIsLocal)
                    {
                        var directorio = Path.GetDirectoryName(rutaFinal);
                        if (!Directory.Exists(directorio)) Directory.CreateDirectory(directorio);
                    }

                    string query = $@"
                        BACKUP DATABASE [{nombreDB}]
                        TO DISK = N'{rutaFinal}'
                        WITH INIT, STATS =10;
                    ";

                    using (var comando = new SqlCommand(query, conexion))
                    {
                        comando.CommandTimeout =0;
                        comando.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                // Re-lanzamos con información útil de SqlException
                var sb = new StringBuilder();
                sb.AppendLine("Error de SQL al realizar el backup:");
                foreach (SqlError err in sqlEx.Errors)
                {
                    sb.AppendLine($"Código: {err.Number} - {err.Message}");
                }
                throw new Exception(sb.ToString(), sqlEx);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al realizar el backup: " + ex.Message, ex);
            }
        }
    }
}
