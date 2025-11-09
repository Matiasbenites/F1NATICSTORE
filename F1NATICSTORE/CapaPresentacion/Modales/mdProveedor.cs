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
    public partial class mdProveedor : Form
    {
        public Proveedor _Proveedor { get; set; }
        public mdProveedor()
        {
            InitializeComponent();
        }

        private void mdProveedor_Load(object sender, EventArgs e)
        {
            foreach (DataGridViewColumn col in dgridData.Columns)
            {
                if (col.Visible)
                {
                    cboxBusqueda.Items.Add(new OpcionCombo() { Valor = col.Name, Texto = col.HeaderText }); // Agrega cada columna visible como una opción en el ComboBox de búsqueda
                }
            }
            cboxBusqueda.DisplayMember = "Texto"; // Establece el miembro de visualización para mostrar el texto
            cboxBusqueda.ValueMember = "Valor"; // Establece el miembro de valor para obtener el valor seleccionado
            cboxBusqueda.SelectedIndex = 0; // Selecciona la primera opción por defecto

            // MOSTRAR TODOS LOS Proveedores
            List<Proveedor> lista = new CN_Proveedor().Listar(); // Obtiene la lista de roles desde la capa de negocio

            foreach (Proveedor item in lista)
            {
                dgridData.Rows.Add(new object[] {
                "",
                item.IdProveedor,
                item.Documento, 
                item.RazonSocial,
                });
            }

        }

        private void dgridData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int iRow = e.RowIndex;

            // Aceptar doble clic en cualquier fila de datos (ignorar encabezados)
            if (iRow >=0)
            {
                _Proveedor = new Proveedor() // Instancia un nuevo objeto Proveedor y asigna los valores de la fila seleccionada
                {
                    IdProveedor = Convert.ToInt32(dgridData.Rows[iRow].Cells["Id"].Value),
                    Documento = dgridData.Rows[iRow].Cells["Documento"].Value.ToString(),
                    RazonSocial = dgridData.Rows[iRow].Cells["RazonSocial"].Value.ToString()
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
