using CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace CapaPresentacion
{
    public partial class formBackup : Form
    {
        public formBackup()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Ejecutar el proceso paso a paso y capturar excepciones en cada etapa para identificar dónde falla
            try
            {
                // Verificar usuario en sesión
                if (Session.CurrentUser == null)
                {
                    MessageBox.Show("No hay usuario logueado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Solo solicitar contraseña si es el administrador (IdUsuario ==1)
                if (Session.CurrentUser.IdUsuario ==1)
                {
                    string pass = null;
                    try
                    {
                        pass = ShowPasswordPrompt("Autorización requerida", $"Ingrese la contraseña del usuario {Session.CurrentUser.NombreCompleto} (documento: {Session.CurrentUser.Documento}):");
                    }
                    catch (Exception ex)
                    {
                        // Falló la ventana de input
                        MessageBox.Show("Fallo al mostrar el cuadro de entrada (Prompt):\n" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (pass == null)
                    {
                        // Usuario canceló el prompt
                        return;
                    }

                    if (pass != Session.CurrentUser.Clave)
                    {
                        MessageBox.Show("Contraseña incorrecta.", "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                string rutaDestino = null;

                try
                {
                    using (var folderDlg = new FolderBrowserDialog())
                    {
                        folderDlg.Description = "Seleccionar carpeta destino para el backup (nota: SQL Server debe tener permisos de escritura en la ruta seleccionada).";
                        folderDlg.SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);

                        var dlgResult = folderDlg.ShowDialog();
                        // Comprobamos resultado
                        if (dlgResult != DialogResult.OK)
                        {
                            // Usuario canceló
                            return;
                        }

                        rutaDestino = folderDlg.SelectedPath;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Fallo al mostrar el selector de carpeta (FolderBrowserDialog):\n" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Validación mínima de la ruta antes de continuar
                if (string.IsNullOrWhiteSpace(rutaDestino))
                {
                    MessageBox.Show("No se seleccionó ninguna ruta válida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Crear carpeta si no existe
                try
                {
                    if (!Directory.Exists(rutaDestino)) Directory.CreateDirectory(rutaDestino);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo crear la carpeta seleccionada:\n" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Obtener cadena de conexion
                string cadenaConexion = null;
                try
                {
                    var cs = ConfigurationManager.ConnectionStrings["cadena_conexion"];
                    cadenaConexion = cs != null ? cs.ConnectionString : null;
                }
                catch (Exception ex)
                {
                    // No crítico, solo notificamos
                    DebugShow("No se pudo leer connectionStrings desde config: " + ex.Message);
                }

                if (string.IsNullOrWhiteSpace(cadenaConexion))
                {
                    cadenaConexion = @"Data Source=MATIAS\SQLEXPRESS;Initial Catalog=F1NATICSTORE;Integrated Security=True";
                }

                // Confirmación final
                var res = MessageBox.Show($"Se realizará el backup en la ruta:\n{rutaDestino}\n\n¿Desea continuar?\n\nIMPORTANTE: el servicio de SQL Server debe tener permisos de escritura en la ruta seleccionada (si la ruta es local de este equipo y SQL Server está en otro servidor, el backup fallará).",
                    "Confirmar backup",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (res != DialogResult.Yes) return;

                // Ejecutar backup
                try
                {
                    CN_Backup backup = new CN_Backup(cadenaConexion);
                    backup.GenerarBackup(rutaDestino);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al ejecutar el backup:\n" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                MessageBox.Show($"✅ Backup realizado correctamente.\nUbicación: {rutaDestino}", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                // Captura cualquier excepción inesperada
                MessageBox.Show("Error inesperado:\n" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DebugShow(string text)
        {
            try
            {
                System.Diagnostics.Debug.WriteLine(text);
            }
            catch { }
        }

        // Prompt simple para pedir contraseña (evita dependencia en Microsoft.VisualBasic)
        private string ShowPasswordPrompt(string title, string prompt)
        {
            using (var form = new Form())
            {
                form.StartPosition = FormStartPosition.CenterParent;
                form.Width =400;
                form.Height =150;
                form.FormBorderStyle = FormBorderStyle.FixedDialog;
                form.Text = title;
                form.MinimizeBox = false;
                form.MaximizeBox = false;
                form.ShowInTaskbar = false;

                var lbl = new Label() { Left =10, Top =10, Text = prompt, AutoSize = true };
                var txt = new TextBox() { Left =10, Top =35, Width =360 };
                txt.UseSystemPasswordChar = true;

                var btnOk = new Button() { Text = "OK", Left =200, Width =80, Top =65, DialogResult = DialogResult.OK };
                var btnCancel = new Button() { Text = "Cancelar", Left =290, Width =80, Top =65, DialogResult = DialogResult.Cancel };

                form.Controls.Add(lbl);
                form.Controls.Add(txt);
                form.Controls.Add(btnOk);
                form.Controls.Add(btnCancel);

                form.AcceptButton = btnOk;
                form.CancelButton = btnCancel;

                var dr = form.ShowDialog(this);
                if (dr == DialogResult.OK)
                {
                    return txt.Text;
                }
                else
                {
                    return null;
                }
            }
        }
    }
}

