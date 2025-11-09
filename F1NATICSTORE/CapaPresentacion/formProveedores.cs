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

namespace CapaPresentacion
{
    public partial class formProveedores : Form
    {
        public formProveedores()
        {
            InitializeComponent();
        }

        private void formProveedores_Load(object sender, EventArgs e)
        {
            cboxEstado.Items.Add(new OpcionCombo() { Valor = 1, Texto = "Activo" }); // Agrega una opción con valor 1 y texto "Activo"
            cboxEstado.Items.Add(new OpcionCombo() { Valor = 0, Texto = "Baja" }); // Agrega una opción con valor 0 y texto "Baja"
            cboxEstado.DisplayMember = "Texto"; // Establece el miembro de visualización para mostrar el texto
            cboxEstado.ValueMember = "Valor"; // Establece el miembro de valor para obtener el valor seleccionado
            cboxEstado.SelectedIndex = 0; // Selecciona la primera opción por defecto

            foreach (DataGridViewColumn col in dgridData.Columns)
            {
                if (col.Visible && col.Name != "btnSeleccionar")
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
                item.Documento, // Cambia txtDocumento.Text por item.Documento
                item.RazonSocial,
                item.Correo, // Cambia txtCorreo.Text por item.Correo
                item.Telefono, // Cambia txtContrasenia.Text por item.Telefono
                item.Estado == true ? "1" : "0", // Asumiendo que Estado es bool
                item.Estado == true ? "Activo" : "Baja"
                });
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string Mensaje = string.Empty; // Variable para almacenar mensajes

            // ------------ Validaciones Proveedor ----------------------

            // Validar que el campo Documento no esté vacío
            if (string.IsNullOrWhiteSpace(txtDocumento.Text))
            {
                MessageBox.Show("El campo Documento es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDocumento.Focus();
                return;
            }
            // Validar que el campo Documento solo contenga números
            if (!txtDocumento.Text.All(char.IsDigit))
            {
                MessageBox.Show("El Documento solo debe contener números.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDocumento.Focus();
                return;
            }

            // Validar que el campo Razon Social no esté vacío
            if (string.IsNullOrWhiteSpace(txtRazonSocial.Text))
            {
                MessageBox.Show("El campo Razon Social es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtRazonSocial.Focus();
                return;
            }
            // Validar que el campo Correo no esté vacío
            if (string.IsNullOrWhiteSpace(txtCorreo.Text))
            {
                MessageBox.Show("El campo Correo es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCorreo.Focus();
                return;
            }
            // Validar que el campo Correo tenga un formato válido
            if (!System.Text.RegularExpressions.Regex.IsMatch(txtCorreo.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("El Correo no tiene un formato válido. Ej: Nombre@ejemplo.com", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCorreo.Focus();
                return;
            }

            // ------------ Fin Validaciones proveedores ----------------------


                Proveedor obj = new Proveedor() // Crear una instancia de proveedores
            {
                IdProveedor = Convert.ToInt32(txtId.Text), // Convertir el texto a entero
                Documento = txtDocumento.Text, // Asignar el texto del TextBox
                RazonSocial = txtRazonSocial.Text,
                Correo = txtCorreo.Text,
                Telefono = txtTelefono.Text,
                Estado = Convert.ToInt32(((OpcionCombo)cboxEstado.SelectedItem).Valor) == 1 ? true : false // Convertir el valor seleccionado a booleano
            };

            if (obj.IdProveedor == 0)
            {
                int idgenerado = new CN_Proveedor().Registrar(obj, out Mensaje); // Llamar al método Registrar y obtener el ID generado y el mensaje


                if (idgenerado != 0) // Si el ID generado es diferente de 0, la operación fue exitosa
                {
                    // Agregar una nueva fila al DataGridView con los datos del usuario registrado
                    dgridData.Rows.Add(new object[] {
                "",
                idgenerado,
                txtDocumento.Text,
                txtRazonSocial.Text,
                txtCorreo.Text,
                txtTelefono.Text,
                ((OpcionCombo)cboxEstado.SelectedItem).Valor.ToString(),
                ((OpcionCombo)cboxEstado.SelectedItem).Texto.ToString()
                 });
                    Limpiar(); // Limpiar los campos del formulario
                }
                else // Si el ID generado es 0, nos dio un error
                {
                    MessageBox.Show(Mensaje); // Mostrar el mensaje de error
                }
            }
            else
            {
                bool Resultado = new CN_Proveedor().Editar(obj, out Mensaje); // Llamar al método Editar y obtener el resultado y el mensaje

                if (Resultado)
                {
                    DataGridViewRow row = dgridData.Rows[Convert.ToInt32(txtIndice.Text)]; // Obtener la fila seleccionada en el DataGridView
                    row.Cells["Id"].Value = txtId.Text;
                    row.Cells["Documento"].Value = txtDocumento.Text;
                    row.Cells["RazonSocial"].Value = txtRazonSocial.Text;
                    row.Cells["Correo"].Value = txtCorreo.Text;
                    row.Cells["Telefono"].Value = txtTelefono.Text;
                    row.Cells["EstadoValor"].Value = ((OpcionCombo)cboxEstado.SelectedItem).Valor.ToString();
                    row.Cells["Estado"].Value = ((OpcionCombo)cboxEstado.SelectedItem).Texto.ToString();

                    Limpiar();
                }
                else
                {
                    MessageBox.Show(Mensaje); // Mostrar el mensaje de error
                }
            }
        }
       
        private void Limpiar()
        { // Limpiar los campos del formulario
            txtIndice.Text = "-1";
            txtId.Text = "0";
            txtDocumento.Text = "";
            txtRazonSocial.Text = "";
            txtCorreo.Text = "";
            txtTelefono.Text = "";
            cboxEstado.SelectedIndex = 0;
            txtDocumento.Select(); // Coloca el foco en el campo Documento
        }

        private void dgridData_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (e.ColumnIndex == 0)
            {
                // Tamaño máximo permitido (80% del tamaño de la celda)
                int maxSize = (int)(Math.Min(e.CellBounds.Width, e.CellBounds.Height) * 0.8);

                e.Paint(e.CellBounds, DataGridViewPaintParts.All); // Pintar el fondo y los bordes de la celda
                int w = Math.Min(Properties.Resources.check_40622.Width, maxSize); // Tomo el ancho de mi img
                int h = Math.Min(Properties.Resources.check_40622.Height, maxSize); // Tomo el alto de mi img
                //var w = Properties.Resources.check_40622.Width; // Tomo el ancho de mi img
                //var h = Properties.Resources.check_40622.Height; // Tomo el alto de mi img
                var x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2; // Dirreción de la imagen dentro del botón
                var y = e.CellBounds.Top + (e.CellBounds.Width - h) / 2;  // Dirección de la imagen dentro del botón    

                e.Graphics.DrawImage(Properties.Resources.check_40622, new Rectangle(x, y, w, h)); // Pintamos la img del bton
                e.Handled = true; // Permiso para proceder con evento click cuando oprime el btn en caso de q falle/congele
            }
        }

        private void dgridData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgridData.Columns[e.ColumnIndex].Name == "btnSeleccionar") // evento para cuando seleccione la celda "seleccionar"
            {
                int indice = e.RowIndex;

                if (indice >= 0)
                {
                    txtIndice.Text = indice.ToString();
                    txtId.Text = dgridData.Rows[indice].Cells["Id"].Value.ToString(); // Internamente va recuperar el ID de la fila seleccionada en el item superior del form
                    txtDocumento.Text = dgridData.Rows[indice].Cells["Documento"].Value.ToString();
                    txtRazonSocial.Text = dgridData.Rows[indice].Cells["RazonSocial"].Value.ToString();
                    txtCorreo.Text = dgridData.Rows[indice].Cells["Correo"].Value.ToString();
                    txtTelefono.Text = dgridData.Rows[indice].Cells["Telefono"].Value.ToString();

                    // recuperar valor del combobox segun indice de grid seleccionado (ESTADO)
                    foreach (OpcionCombo opc in cboxEstado.Items)
                    {
                        if (Convert.ToInt32(opc.Valor) == Convert.ToInt32(dgridData.Rows[indice].Cells["EstadoValor"].Value))
                        { // obtiene el indice edl combobox
                            int indice_combo = cboxEstado.Items.IndexOf(opc); // recupero el indice de la coleccion de un elemento
                            cboxEstado.SelectedIndex = indice_combo; // queda seleccionado el indice q encontro
                            break; // forzamos fin del foreach
                        }
                    }
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtId.Text) != 0)
            {
                if (MessageBox.Show($"¿Desea eliminar al proveedor?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string Mensaje = string.Empty; // Variable para almacenar mensajes
                    Proveedor obj = new Proveedor() // Crear una instancia de Cliente
                    {
                        IdProveedor = Convert.ToInt32(txtId.Text), // Convertir el texto a entero
                    };
                    bool respuesta = new CN_Proveedor().Eliminar(obj, out Mensaje); // Llamar al método Eliminar y obtener el resultado y el mensaje

                    if (respuesta) // Si la respuesta es verdadera, la operación fue exitosa
                    {
                        dgridData.Rows.RemoveAt(Convert.ToInt32(txtIndice.Text)); // Eliminar la fila seleccionada en el DataGridView
                        Limpiar(); // Limpiar los campos del formulario
                    }
                    else // Si la respuesta es falsa, nos dio un error
                    {
                        MessageBox.Show(Mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); // Mostrar el mensaje de error
                    }

                }
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

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar(); // Llama al método Limpiar para limpiar los campos del formulario
        }
    }
}
