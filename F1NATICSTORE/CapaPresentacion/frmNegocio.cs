using System;
using CapaNegocio;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using CapaEntidad;

namespace CapaPresentacion
{
    public partial class frmNegocio : Form
    {
        public frmNegocio()
        {
            InitializeComponent();
        }
        public Image ByteToImage(byte[] imageBytes)
        {
            MemoryStream ms = new MemoryStream();// nos permite guardar imagenes en memoria
            ms.Write(imageBytes, 0, imageBytes.Length);
            Image image =new Bitmap (ms);

            return image;

        }

        private void frmNegocio_Load(object sender, EventArgs e)
        {
            bool obtenido = true;
            byte[] byteimage = new CN_Negocio().ObtenerLogo(out obtenido);

            if (obtenido) 
                picLogo.Image = ByteToImage(byteimage);        

            Negocio datos = new CN_Negocio().ObtenerDatos();
            txtNombre.Text = datos.Nombre;
            txtTipoFactura.Text = datos.TipoFactura.ToString();
            txtCuit.Text = datos.Cuit;
            txtIva.Text = datos.CondicionIVA;
            txtDireccion.Text = datos.Direccion;

        }

        private void btnSubir_Click(object sender, EventArgs e)
        {
            string mensaje = string.Empty;
            OpenFileDialog open = new OpenFileDialog();
            open.FileName = "Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";

            if (open.ShowDialog() == DialogResult.OK)
            {
                byte[] imagen = File.ReadAllBytes(open.FileName);
                bool respuesta = new CN_Negocio().ActualizarLogo(imagen,out mensaje);
                if (respuesta)
                {
                   picLogo.Image = ByteToImage(imagen);
                }
                else
                {
                    MessageBox.Show("No se pudo actualizar el logo", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string mensaje = string.Empty;

            Negocio obj = new Negocio()
            {
                Nombre = txtNombre.Text,
                TipoFactura = Convert.ToChar(txtTipoFactura.Text),
                Cuit = txtCuit.Text,
                CondicionIVA = txtIva.Text,
                Direccion = txtDireccion.Text
            };
            bool respuesta = new CN_Negocio().GuardarDatos(obj, out mensaje);
            if (respuesta)
            {
                MessageBox.Show("Los datos se han guardado correctamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No se pudo guardar los datos. " + mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
