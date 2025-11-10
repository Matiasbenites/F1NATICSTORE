using CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Backup
    {
        private CD_Backup objDatos;

        public CN_Backup(string cadenaConexion)
        {
            objDatos = new CD_Backup(cadenaConexion);
        }

        public void GenerarBackup(string rutaDestino)
        {
            if (string.IsNullOrWhiteSpace(rutaDestino))
                throw new Exception("Debe especificar una carpeta de destino para el backup.");

            objDatos.RealizarBackup(rutaDestino);
        }
    }
}
