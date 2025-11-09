using CapaEntidad;
using CapaNegocio;
using CapaPresentacion.Modales;
using CapaPresentacion.Utilidades;
using DocumentFormat.OpenXml.Wordprocessing;
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
    public partial class formCompras : Form
    {
        private Usuario _Usuario;

        public formCompras(Usuario oUsuario = null)
        {
            _Usuario = oUsuario;
            InitializeComponent();
            this.Load += formCompras_Load;
        }

        private void formCompras_Load(object sender, EventArgs e)
        {
            cboxTDocumento.Items.Add(new OpcionCombo() { Valor = "Boleta", Texto = "Activo" });
            cboxTDocumento.Items.Add(new OpcionCombo() { Valor = "Factura", Texto = "Inactivo" });
            cboxTDocumento.DisplayMember = "Texto"; // Establece el miembro de visualización para mostrar el texto
            cboxTDocumento.ValueMember = "Valor"; // Establece el miembro de valor para obtener el valor seleccionado
            cboxTDocumento.SelectedIndex = 0; // Selecciona la primera opción por defecto

            txtFecha.Text = DateTime.Now.ToString("dd/MM/yyyy");

            txtIdProducto.Text = "0";
            txtIdProveedor.Text = "0";

            // Evitar la fila de nueva inserción y asegurar el repintado del botón
            dgridRegistrarCompra.AllowUserToAddRows = false;
            dgridRegistrarCompra.CellPainting += dgridRegistrarCompra_CellPainting;
        }

        private void btnBuscarProveedor_Click(object sender, EventArgs e)
        {
            // Abrir el modal de selección de proveedor
            using (var modal = new mdProveedor())
            {
                var result = modal.ShowDialog();

                if (result == DialogResult.OK)
                {
                    txtIdProveedor.Text = modal._Proveedor.IdProveedor.ToString();
                    txtDocProveedor.Text = modal._Proveedor.Documento;
                    txtNombreProveedor.Text = modal._Proveedor.RazonSocial;
                }
                else
                {
                    txtDocProveedor.Select();
                }
            }
        }

        private void btnBuscarProducto_Click(object sender, EventArgs e)
        {
            using (var modal = new mdProducto())
            {
                var result = modal.ShowDialog();

                if (result == DialogResult.OK)
                {
                    txtIdProducto.Text = modal._Producto.IdProducto.ToString();
                    txtCodProducto.Text = modal._Producto.Codigo;
                    txtProducto.Text = modal._Producto.Nombre;
                    txtPrecioCompra.Select();
                }
                else
                {
                    txtDocProveedor.Select();
                }
            }
        }

        private void txtCodProducto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                // Buscar el producto por su código filtrando por código y estado activo, si encuentra retorna el primero o nulo
                Producto oProducto = new CN_Producto().Listar().Where(p => p.Codigo == txtCodProducto.Text && p.Estado == true).FirstOrDefault();

                if (oProducto != null)
                {
                    txtCodProducto.BackColor = System.Drawing.Color.Honeydew;
                    txtIdProducto.Text = oProducto.IdProducto.ToString();
                    txtProducto.Text = oProducto.Nombre;
                    txtPrecioCompra.Select();
                }
                else
                {
                    txtCodProducto.BackColor = System.Drawing.Color.MistyRose;
                    txtIdProducto.Text = "0";
                    txtProducto.Text = "";
                }
            }
        }

        private void ibAgregarProducto_Click(object sender, EventArgs e)
        {
            decimal precioCompra = 0;
            decimal precioVenta = 0;
            bool productoExiste = false;

            if (int.Parse(txtIdProducto.Text) == 0)
            {
                MessageBox.Show("Debe seleccionar un producto", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (!decimal.TryParse(txtPrecioCompra.Text, out precioCompra) || precioCompra <= 0)
            {
                MessageBox.Show("Debe ingresar un precio de compra válido", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtPrecioCompra.Select();
                return;
            }

            if (!decimal.TryParse(txtPrecioVenta.Text, out precioVenta) || precioVenta <= 0)
            {
                MessageBox.Show("Debe ingresar un precio de venta válido", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtPrecioVenta.Select();
                return;
            }

            foreach (DataGridViewRow fila in dgridRegistrarCompra.Rows)
            {
                if (fila.Cells["IdProducto"].Value != null && fila.Cells["IdProducto"].Value.ToString() == txtIdProducto.Text)
                {
                    productoExiste = true;
                    break;
                }
            }

            if (!productoExiste)
            {
                decimal subtotal = precioCompra * nudCantidad.Value;

                // IdProducto, Producto, PrecioCompra, PrecioVenta, Cantidad, Subtotal, btnEliminar
                dgridRegistrarCompra.Rows.Add(new object[] {
                    txtIdProducto.Text,                   // IdProducto (oculto)
                    txtProducto.Text,                     // Producto (nombre)
                    precioCompra.ToString("0.00"),        // PrecioCompra
                    precioVenta.ToString("0.00"),         // PrecioVenta
                    nudCantidad.Value.ToString(),         // Cantidad
                    subtotal.ToString("0.00"),            // Subtotal
                });

                calcularTotal();
                limpiarProducto();
                txtCodProducto.Select();
            }
        }

        // Limpiar los campos de producto después de agregarlo
        private void limpiarProducto()
        {
            txtIdProducto.Text = "0";
            txtCodProducto.Text = "";
            txtCodProducto.BackColor = System.Drawing.Color.White;
            txtProducto.Text = "";
            txtPrecioCompra.Text = "";
            txtPrecioVenta.Text = "";
            nudCantidad.Value = 1;
            txtCodProducto.Select();
        }
        // Calcular el total de la compra sumando los subtotales de cada fila
        private void calcularTotal()
        {
            decimal total = 0;

            if (dgridRegistrarCompra.Rows.Count > 0)
            {
                foreach (DataGridViewRow fila in dgridRegistrarCompra.Rows)
                {
                    total += Convert.ToDecimal(fila.Cells["Subtotal"].Value.ToString());
                }
                txtTotal.Text = total.ToString("0.00");
            }
        }

        // Lógica para pintar el botón eliminar en el DataGridView
        private void dgridRegistrarCompra_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (e.ColumnIndex == 6) // indice columna btnEliminar
            {
                int maxSize = (int)(Math.Min(e.CellBounds.Width, e.CellBounds.Height) * 0.6);

                e.Paint(e.CellBounds, DataGridViewPaintParts.All); // Pintar el fondo y los bordes de la celda
                int w = Math.Min(Properties.Resources.delete_40623.Width, maxSize); // Tomo el ancho de mi img
                int h = Math.Min(Properties.Resources.delete_40623.Height, maxSize); // Tomo el alto de mi img
                var x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2; // Dirreción de la imagen dentro del botón
                var y = e.CellBounds.Top + (e.CellBounds.Height - h) / 2; // usar Height para centrar verticalmente

                e.Graphics.DrawImage(Properties.Resources.delete_40623, new Rectangle(x, y, w, h)); // Pintamos la img del bton
                e.Handled = true; // Permiso para proceder con evento click cuando oprime el btn en caso de q falle/congele
            }
        }
        // Lógica para eliminar una fila cuando se hace clic en el botón eliminar
        private void dgridRegistrarCompra_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgridRegistrarCompra.Columns[e.ColumnIndex].Name == "btnEliminar") // evento para cuando seleccione la celda "eliminar"
            {
                int indice = e.RowIndex;

                if (indice >= 0)
                {
                    dgridRegistrarCompra.Rows.RemoveAt(indice);
                    txtTotal.Text = "";
                    calcularTotal();
                }
            }
        }
        // Validar entrada para precio de compra (solo números y un punto decimal)
        private void txtPrecioCompra_KeyPress(object sender, KeyPressEventArgs e)
        {
            var tb = (TextBox)sender;

            // Permitir teclas de control (borrar, retroceso, etc.)
            if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
                return;
            }

            // Permitir dígitos
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
                return;
            }

            // Permitir un único punto decimal pero no como primer carácter
            if (e.KeyChar == '.')
            {
                bool primerCaracter = tb.Text.Length == 0 && tb.SelectionStart == 0 && tb.SelectionLength == 0;
                bool yaTienePunto = tb.Text.Contains(".") && tb.SelectionLength == 0; // si se está reemplazando toda la selección, se permite

                e.Handled = primerCaracter || yaTienePunto;
                return;
            }

            // Bloquear cualquier otro caracter
            e.Handled = true;
        }

        private void ibPagar_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtIdProveedor.Text) == 0)
            {
                MessageBox.Show("Debe seleccionar un proveedor", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if(dgridRegistrarCompra.Rows.Count < 1)
            {
                MessageBox.Show("Debe agregar productos a la compra", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            /* Modelod de datatable para manipular parámetros */
            DataTable detalle_Compra = new DataTable();

            detalle_Compra.Columns.Add("IdProducto", typeof(int));
            detalle_Compra.Columns.Add("PrecioCompra", typeof(decimal));
            detalle_Compra.Columns.Add("PrecioVenta", typeof(decimal));
            detalle_Compra.Columns.Add("Cantidad", typeof(int));
            detalle_Compra.Columns.Add("MontoTotal", typeof(decimal));

            // leer cada fila del datagrid y agregarla al datatable

            foreach (DataGridViewRow row in dgridRegistrarCompra.Rows)
            {
                detalle_Compra.Rows.Add(
                    new object[]
                    {
                        Convert.ToInt32(row.Cells["IdProducto"].Value.ToString()),
                        row.Cells["PrecioCompra"].Value.ToString(),
                        row.Cells["PrecioVenta"].Value.ToString(),
                        row.Cells["Cantidad"].Value.ToString(),
                        row.Cells["Subtotal"].Value.ToString()
                    });
            }
            int idcorrelativo = new CN_Compra().ObtenerCorrelativo();
            string numerodocumento = string.Format("{0:00000}", idcorrelativo);

            // Crear el objeto compra
            Compra oCompra = new Compra()
            {
                oUsuario = new Usuario() { IdUsuario = _Usuario.IdUsuario },
                oProveedor = new Proveedor() { IdProveedor = Convert.ToInt32(txtIdProveedor.Text) },
                TipoDocumento = ((OpcionCombo)cboxTDocumento.SelectedItem).Valor.ToString(),
                NumeroDocumento = numerodocumento,
                MontoTotal = Convert.ToDecimal(txtTotal.Text)
            };

            string mensaje = string.Empty;
            bool respuesta = new CN_Compra().Registrar(oCompra, detalle_Compra, out mensaje);

            if(respuesta)
            {
                var result = MessageBox.Show("Número de documento generado: " + numerodocumento + "\n¿Desea copiar el número de documento?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result == DialogResult.Yes)
                {
                    Clipboard.SetText(numerodocumento);

                    txtIdProveedor.Text = "0";
                    txtDocProveedor.Text = "";
                    txtNombreProveedor.Text = "";
                    dgridRegistrarCompra.Rows.Clear();
                    calcularTotal();
                }
                else
                {
                    this.Close();
                }
            }
        }
    }
}