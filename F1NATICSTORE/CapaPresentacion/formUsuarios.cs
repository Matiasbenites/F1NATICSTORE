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
using System.Windows.Media;

namespace CapaPresentacion
{
    public partial class formUsuarios : Form
    {
        public formUsuarios()
        {
            InitializeComponent();
        }

        private void formUsuarios_Load(object sender, EventArgs e)
        {
            cboxEstado.Items.Add(new OpcionCombo() { Valor = 1, Texto = "Activo" }); // Agrega una opción con valor 1 y texto "Activo"
            cboxEstado.Items.Add(new OpcionCombo() { Valor = 0, Texto = "Baja" }); // Agrega una opción con valor 0 y texto "Baja"
            cboxEstado.DisplayMember = "Texto"; // Establece el miembro de visualización para mostrar el texto
            cboxEstado.ValueMember = "Valor"; // Establece el miembro de valor para obtener el valor seleccionado
            cboxEstado.SelectedIndex = 0; // Selecciona la primera opción por defecto

            List<Rol> listaRoles = new CN_Rol().Listar(); // Obtiene la lista de roles desde la capa de negocio

            foreach (Rol item in listaRoles)
            {
                cboxRol.Items.Add(new OpcionCombo() { Valor = item.IdRol, Texto = item.Descripcion }); // Agrega cada rol como una opción en el ComboBox
            }
            cboxRol.DisplayMember = "Texto"; // Establece el miembro de visualización para mostrar el texto
            cboxRol.ValueMember = "Valor"; // Establece el miembro de valor para obtener el valor seleccionado
            cboxRol.SelectedIndex = 0; // Selecciona la primera opción por defecto

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

            // MOSTRAR TODOS LOS USUARIOS
            List<Usuario> listaUsuario = new CN_Usuario().Listar(); // Obtiene la lista de roles desde la capa de negocio

            foreach (Usuario item in listaUsuario)
            {
                dgridData.Rows.Add(new object[] {
                "",
                item.IdUsuario,
                item.Documento, // Cambia txtDocumento.Text por item.Documento
                item.NombreCompleto, // Cambia txtNombreCompleto.Text por item.NombreCompleto
                item.Correo, // Cambia txtCorreo.Text por item.Correo
                item.Clave, // Cambia txtContrasenia.Text por item.Contrasenia
                item.oRol.IdRol.ToString(), // Asumiendo que Usuario tiene una propiedad oRol
                item.oRol.Descripcion.ToString(),
                item.Estado == true ? "1" : "0", // Asumiendo que Estado es bool
                item.Estado == true ? "Activo" : "Baja"
                });
            }
        }

        private void txtDocumento_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Solo números
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void txtNombreCompleto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string Mensaje = string.Empty; // Variable para almacenar mensajes

            // ------------ Validaciones Usuario ----------------------

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

            // Validar que el campo Nombre Completo no esté vacío
            if (string.IsNullOrWhiteSpace(txtNombreCompleto.Text))
            {
                MessageBox.Show("El campo Nombre Completo es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombreCompleto.Focus();
                return;
            }
            // Validar que el campo Nombre Completo solo contenga letras y espacios
            if (!txtNombreCompleto.Text.All(c => char.IsLetter(c) || char.IsWhiteSpace(c)))
            {
                MessageBox.Show("El Nombre Completo solo debe contener letras y espacios.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombreCompleto.Focus();
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
            // Validar que el campo Contraseña no esté vacío y tenga al menos 6 caracteres
            if (string.IsNullOrWhiteSpace(txtContrasenia.Text) || txtContrasenia.Text.Length < 6)
            {
                MessageBox.Show("El campo Contraseña es obligatorio y debe tener al menos 6 caracteres.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtContrasenia.Focus();
                return;
            }
            // Validar que el campo Confirmar Contraseña coincida con el campo Contraseña
            if (txtContrasenia.Text != txtConfirmaContrasenia.Text)
            {
                MessageBox.Show("Las contraseñas no coinciden.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtConfirmaContrasenia.Focus();
                return;
            }

            // ------------ Fin Validaciones Usuario ----------------------


            Usuario objUsuario = new Usuario() // Crear una instancia de Usuario
            {
                IdUsuario = Convert.ToInt32(txtId.Text), // Convertir el texto a entero
                Documento = txtDocumento.Text, // Asignar el texto del TextBox
                NombreCompleto = txtNombreCompleto.Text,
                Correo = txtCorreo.Text,
                Clave = txtContrasenia.Text,
                oRol = new Rol() { IdRol = Convert.ToInt32(((OpcionCombo)cboxRol.SelectedItem).Valor) }, // Crear una instancia de Rol y asignar el IdRol
                Estado = Convert.ToInt32(((OpcionCombo)cboxEstado.SelectedItem).Valor) == 1 ? true : false // Convertir el valor seleccionado a booleano
            };

            if (objUsuario.IdUsuario == 0)
            {
                int idusuariogenerado = new CN_Usuario().Registrar(objUsuario, out Mensaje); // Llamar al método Registrar y obtener el ID generado y el mensaje


                if (idusuariogenerado != 0) // Si el ID generado es diferente de 0, la operación fue exitosa
                {
                    // Agregar una nueva fila al DataGridView con los datos del usuario registrado
                    dgridData.Rows.Add(new object[] {
                "",
                idusuariogenerado,
                txtDocumento.Text,
                txtNombreCompleto.Text,
                txtCorreo.Text,
                txtContrasenia.Text,
                ((OpcionCombo)cboxRol.SelectedItem).Valor.ToString(),
                ((OpcionCombo)cboxRol.SelectedItem).Texto.ToString(),
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
                bool Resultado = new CN_Usuario().Editar(objUsuario, out Mensaje); // Llamar al método Editar y obtener el resultado y el mensaje

                if (Resultado)
                {
                    DataGridViewRow row = dgridData.Rows[Convert.ToInt32(txtIndice.Text)]; // Obtener la fila seleccionada en el DataGridView
                    row.Cells["Id"].Value = txtId.Text;
                    row.Cells["Documento"].Value = txtDocumento.Text;
                    row.Cells["NombreCompleto"].Value = txtNombreCompleto.Text;
                    row.Cells["Correo"].Value = txtCorreo.Text;
                    row.Cells["Clave"].Value = txtContrasenia.Text;
                    row.Cells["IdRol"].Value = ((OpcionCombo)cboxRol.SelectedItem).Valor.ToString();
                    row.Cells["Rol"].Value = ((OpcionCombo)cboxRol.SelectedItem).Texto.ToString();
                    row.Cells["EstadoValor"].Value = ((OpcionCombo)cboxEstado.SelectedItem).Valor.ToString();
                    row.Cells["Estado"].Value = ((OpcionCombo)cboxEstado.SelectedItem).Texto.ToString();

                    Limpiar();
                } else
                {
                    MessageBox.Show(Mensaje); // Mostrar el mensaje de error
                }
            }

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtId.Text) != 0)
            {
                if(MessageBox.Show($"¿Desea eliminar el usuario {txtNombreCompleto.Text}?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string Mensaje = string.Empty; // Variable para almacenar mensajes
                    Usuario objUsuario = new Usuario() // Crear una instancia de Usuario
                    {
                        IdUsuario = Convert.ToInt32(txtId.Text), // Convertir el texto a entero
                    };
                    bool respuesta = new CN_Usuario().Eliminar(objUsuario, out Mensaje); // Llamar al método Eliminar y obtener el resultado y el mensaje

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

        private void Limpiar()
        { // Limpiar los campos del formulario
            txtIndice.Text = "-1";
            txtId.Text = "0";
            txtDocumento.Text = "";
            txtNombreCompleto.Text = "";
            txtCorreo.Text = "";
            txtContrasenia.Text = "";
            txtConfirmaContrasenia.Text = "";
            cboxRol.SelectedIndex = 0;
            cboxEstado.SelectedIndex = 0;

            txtDocumento.Select(); // Coloca el foco en el campo Documento
        }

        // Evento para pintar el botón con imagen en el DataGridView
        private void dgridData_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {

            if(e.RowIndex < 0) return;

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
        // Evento para cuando se da click en el botón del DataGridView
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
                    txtNombreCompleto.Text = dgridData.Rows[indice].Cells["NombreCompleto"].Value.ToString();
                    txtCorreo.Text = dgridData.Rows[indice].Cells["Correo"].Value.ToString();
                    txtContrasenia.Text = dgridData.Rows[indice].Cells["Clave"].Value.ToString();
                    txtConfirmaContrasenia.Text = dgridData.Rows[indice].Cells["Clave"].Value.ToString();

                    // recuperar valor del combobox segun indice de grid seleccionado (ROL)
                    foreach (OpcionCombo opc in cboxRol.Items)
                    {
                        if (Convert.ToInt32(opc.Valor) == Convert.ToInt32(dgridData.Rows[indice].Cells["IdRol"].Value)) { // obtiene el indice edl combobox
                            int indice_combo = cboxRol.Items.IndexOf(opc); // recupero el indice de la coleccion de un elemento
                            cboxRol.SelectedIndex = indice_combo; // queda seleccionado el indice q encontro
                            break; // forzamos fin del foreach
                        }
                    }

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

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar(); // Limpiar los campos del formulario
        }
        // Evento para buscar en el DataGridView
        private void btnBuscador_Click(object sender, EventArgs e)
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

        // Evento para limpiar el buscador y mostrar todas las filas
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
