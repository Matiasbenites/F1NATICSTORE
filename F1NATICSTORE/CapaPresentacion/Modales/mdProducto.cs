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
    public partial class mdProducto : Form
    {
        public Producto _Producto { get; set; }
        public mdProducto()
        {
            InitializeComponent();
        }

        private void mdProducto_Load(object sender, EventArgs e)
        {
            foreach (DataGridViewColumn col in dgridData.Columns)
            {
                if (col.Visible)
                {
                    cboxBusquedaOpciones.Items.Add(new OpcionCombo() { Valor = col.Name, Texto = col.HeaderText }); // Agrega cada columna visible como una opción en el ComboBox de búsqueda
                }
            }
            cboxBusquedaOpciones.DisplayMember = "Texto"; // Establece el miembro de visualización para mostrar el texto
            cboxBusquedaOpciones.ValueMember = "Valor"; // Establece el miembro de valor para obtener el valor seleccionado
            cboxBusquedaOpciones.SelectedIndex = 0; // Selecciona la primera opción por defecto

            List<Producto> lista = new CN_Producto().Listar(); // Obtiene la lista de productos desde la capa de negocio

            foreach (Producto item in lista)
            {
                dgridData.Rows.Add(new object[] {
                    "", 
                    item.IdProducto, // Id (oculta)
                    item.Codigo, // Codigo
                    item.Nombre, // Nombre
                    item.Descripcion, // Descripcion (oculta)
                    item.oCategoria?.IdCategoria, // IdCategoria (oculta)
                    item.oCategoria?.Descripcion, // Categoria
                    item.Stock, // Stock (oculta)
                    item.PrecioCompra, // PrecioCompra (oculta)
                    item.PrecioVenta, // PrecioVenta (oculta)
                    item.Estado ?1 :0, // EstadoValor (oculta)
                    item.Estado ? "Activo" : "Inactivo" // Estado (oculta)
                });
            }
        }
        private void ibBuscador_Click(object sender, EventArgs e)
        {
            {
                string columnaFiltro = ((OpcionCombo)cboxBusquedaOpciones.SelectedItem).Valor.ToString(); // Obtiene el valor seleccionado del ComboBox de búsqueda

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
        }

        private void btnLimpiarBuscador_Click(object sender, EventArgs e)
        {
            txtBusqueda.Text = ""; // Limpia el texto de búsqueda
            foreach (DataGridViewRow row in dgridData.Rows) // Recorre cada fila del DataGridView
            {
                row.Visible = true; // Muestra todas las filas
            }
        }

        private void dgridData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int iRow = e.RowIndex;

            // Aceptar doble clic en cualquier fila de datos
            if (iRow >= 0)
            {
                _Producto = new Producto() // Instancia un nuevo objeto Producto y asigna los valores de la fila seleccionada
                {
                    IdProducto = Convert.ToInt32(dgridData.Rows[iRow].Cells["Id"].Value),
                    Codigo = dgridData.Rows[iRow].Cells["Codigo"].Value.ToString(),
                    Nombre = dgridData.Rows[iRow].Cells["Nombre"].Value.ToString(),
                    Descripcion = dgridData.Rows[iRow].Cells["Descripcion"].Value?.ToString(),
                    oCategoria = new Categoria(){
                        IdCategoria = dgridData.Rows[iRow].Cells["IdCategoria"].Value == null ?0 : Convert.ToInt32(dgridData.Rows[iRow].Cells["IdCategoria"].Value),
                        Descripcion = dgridData.Rows[iRow].Cells["Categoria"].Value?.ToString()
                    },
                    Stock = dgridData.Rows[iRow].Cells["Stock"].Value == null ?0 : Convert.ToInt32(dgridData.Rows[iRow].Cells["Stock"].Value),
                    PrecioCompra = dgridData.Rows[iRow].Cells["PrecioCompra"].Value == null ?0 : Convert.ToDecimal(dgridData.Rows[iRow].Cells["PrecioCompra"].Value), // Maneja posible valor nulo
                    PrecioVenta = dgridData.Rows[iRow].Cells["PrecioVenta"].Value == null ?0 : Convert.ToDecimal(dgridData.Rows[iRow].Cells["PrecioVenta"].Value), 
                    Estado = dgridData.Rows[iRow].Cells["EstadoValor"].Value == null ? false : Convert.ToInt32(dgridData.Rows[iRow].Cells["EstadoValor"].Value) == 1 // Convierte el valor numérico a booleano
                };

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
