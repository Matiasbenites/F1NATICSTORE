using CapaEntidad;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        private void TDocumento_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Solo números
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnIngresar_Click(object sender, EventArgs e)
        {

            //---------- Validaciones LOGIN ---------------------------------------

            // Validar que el campo Documento no esté vacío
            if (string.IsNullOrWhiteSpace(txtDocumento.Text))
            {
                MessageBox.Show("El campo Documento es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDocumento.Focus();
                return;
            }
            if (!txtDocumento.Text.All(char.IsDigit))
            {
                MessageBox.Show("El Documento solo debe contener números.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDocumento.Focus();
                return;
            }
            // Validar que el campo Clave no esté vacío
            if (string.IsNullOrWhiteSpace(txtClave.Text))
            {
                MessageBox.Show("El campo Clave es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtClave.Focus();
                return;
            }
            // Validar que la Clave tenga al menos 6 caracteres
            if (txtClave.Text.Length < 6)
            {
                MessageBox.Show("La Clave debe tener al menos 6 caracteres.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtClave.Focus();
                return;
            }
            // ----------------------Fin Validaciones LOGIN-----------------------

            List<Usuario> test = new CN_Usuario().Listar();

            Usuario ousuario = new CN_Usuario().Listar().Where(u => u.Documento == txtDocumento.Text && u.Clave == txtClave.Text).FirstOrDefault(); //Expresiones lambda para automatizar la busqueda de un objeto

            if (ousuario != null)
            {
                Inicio formInicio = new Inicio(ousuario);

                formInicio.Show();
                this.Hide();

                formInicio.FormClosing += frm_closing;
            }
            else
            {
                MessageBox.Show("El usuario o la contraseña no coinciden", "Login", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void frm_closing(object sender, FormClosingEventArgs e)
        {
            txtDocumento.Text = "";
            txtClave.Text = "";
            this.Show();
        }
    }
}
