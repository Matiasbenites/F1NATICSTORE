using CapaDatos;
using CapaEntidad;
using CapaNegocio;
using CapaPresentacion.Utilidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion.Modales
{
    public partial class mdCliente : Form
    {
        public Cliente _Cliente { get; set; }
        public mdCliente()
        {
            InitializeComponent();
        }

        private void mdCliente_Load(object sender, EventArgs e)
        {
            // Llenar combo de búsqueda con nombres de columna
            foreach (DataGridViewColumn columna in dgridData.Columns)
            {
                if (columna.Visible)
                {
                cboxBusqueda.Items.Add(new OpcionCombo() { Valor = columna.Name, Texto = columna.HeaderText }); // Agrega cada columna visible como una opción en el ComboBox de búsqueda
                }
            }

            cboxBusqueda.DisplayMember = "Texto";
            cboxBusqueda.ValueMember = "Valor";
            cboxBusqueda.SelectedIndex =0;

            // Obtener lista de clientes
            List<Cliente> lista = new CN_Cliente().Listar();

            foreach (Cliente item in lista)
            {
                if (item.Estado)
                    dgridData.Rows.Add(new object[] { item.Documento, item.NombreCompleto});
            }
        }

        private void dgridData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int iRow = e.RowIndex;

            // Aceptar doble clic en cualquier fila de datos
            if (iRow >= 0)
            {
                _Cliente = new Cliente() // Instancia un nuevo objeto Producto y asigna los valores de la fila seleccionada
                {
                    Documento = dgridData.Rows[iRow].Cells["Documento"].Value.ToString(),
                    NombreCompleto = dgridData.Rows[iRow].Cells["NombreCompleto"].Value.ToString()
                };

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            string columnaFiltro = ((OpcionCombo)cboxBusqueda.SelectedItem).Valor.ToString(); // Obtiene el valor seleccionado del ComboBox de búsqueda

            if (dgridData.Rows.Count > 0) // Verifica si hay filas en el DataGridView
            {
                foreach (DataGridViewRow row in dgridData.Rows) // Recorre cada fila del DataGridView
                {
                    if (row.Cells[columnaFiltro].Value.ToString().Trim().ToUpper().Contains(txtBusqueda.Text.Trim().ToUpper())) // Compara el valor de la celda con el texto de búsqueda
                        row.Visible = true; // Muestra la fila si coincide
                    else
                        row.Visible = false; // Oculta la fila si no coincide
                }
            }
        }

        private void btnLimpiarBuscador_Click(object sender, EventArgs e)
        {
            txtBusqueda.Text = ""; // Limpia el texto de búsqueda
            foreach (DataGridViewRow row in dgridData.Rows) // Recorre cada fila del DataGridView
            {
                row.Visible = true; // Muestra todas las filas
            }
        }
    }
}
