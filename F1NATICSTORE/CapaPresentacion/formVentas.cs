using CapaEntidad;
using CapaNegocio;
using CapaPresentacion.Modales;
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
    public partial class formVentas : Form
    {
        private Usuario _Usuario;
        public formVentas(Usuario oUsuario = null)
        {
            _Usuario = oUsuario;
            InitializeComponent();
        }

        private void formVentas_Load(object sender, EventArgs e)
        {
            cboxTDocumento.Items.Add(new OpcionCombo() { Valor = "Factura A", Texto = "Factura A" });
            cboxTDocumento.Items.Add(new OpcionCombo() { Valor = "Factura B", Texto = "Factura B" });
            cboxTDocumento.Items.Add(new OpcionCombo() { Valor = "Factura C", Texto = "Factura C" });
            cboxTDocumento.Items.Add(new OpcionCombo() { Valor = "OTROS", Texto = "OTROS" });
            cboxTDocumento.DisplayMember = "Texto"; // Establece el miembro de visualización para mostrar el texto
            cboxTDocumento.ValueMember = "Valor";   // Establece el miembro de valor para obtener el valor seleccionado
            cboxTDocumento.SelectedIndex = 0;      // Selecciona la primera opción por defecto

            txtFecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtIdProducto.Text = "0";

            txtMontoPago.Text = "";
            txtCambio.Text = "";
            txtTotal.Text = "";
        }

        // Botón para buscar y seleccionar un cliente
        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            using (var modal = new mdCliente())
            {
                var result = modal.ShowDialog();

                if(result == DialogResult.OK)
                {
                    txtDocCliente.Text = modal._Cliente.Documento;
                    txtNombreCliente.Text = modal._Cliente.NombreCompleto;
                    txtCodProducto.Select();
                }
                else
                {
                    txtDocCliente.Select();
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
                    txtPrecioVenta.Text = modal._Producto.PrecioVenta.ToString("0.00");
                    txtStock.Text = modal._Producto.Stock.ToString();
                    nudCantidad.Select();
                }
                else
                {
                    txtCodProducto.Select();
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
                    txtPrecioVenta.Text = oProducto.PrecioVenta.ToString("0.00");
                    txtStock.Text = oProducto.Stock.ToString();
                    nudCantidad.Select();
                }
                else
                {
                    txtCodProducto.BackColor = System.Drawing.Color.MistyRose;
                    txtIdProducto.Text = "0";
                    txtProducto.Text = "";
                    txtPrecioVenta.Text = "";
                    txtStock.Text = "";
                    nudCantidad.Value = 1;
                }
            }
        }

        private void ibAgregarProducto_Click(object sender, EventArgs e)
        {
            decimal precio = 0;
            bool productoExiste = false;

            if (int.Parse(txtIdProducto.Text) == 0)
            {
                MessageBox.Show("Debe seleccionar un producto", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (!decimal.TryParse(txtPrecioVenta.Text, out precio) || precio <= 0)
            {
                MessageBox.Show("Debe ingresar un precio de venta válido", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtPrecioVenta.Select();
                return;
            }

            if(Convert.ToInt32(txtStock.Text) < Convert.ToInt32(nudCantidad.Value))
            {
                MessageBox.Show("La cantidad a vender supera el stock disponible", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                nudCantidad.Select();
                return;
            }

            foreach (DataGridViewRow fila in dgridRegistrarVenta.Rows)
            {
                if (fila.Cells["IdProducto"].Value != null && fila.Cells["IdProducto"].Value.ToString() == txtIdProducto.Text)
                {
                    productoExiste = true;
                    break;
                }
            }

            if (!productoExiste)
            {
                decimal subtotal = precio * nudCantidad.Value;

                // Restar el stock del producto en la base de datos
                bool respuesta = new CN_Venta().RestarStock(
                    Convert.ToInt32(txtIdProducto.Text),
                    Convert.ToInt32(nudCantidad.Value.ToString()));

                if (respuesta)
                {

                    dgridRegistrarVenta.Rows.Add(new object[] {
                    txtIdProducto.Text,                   // IdProducto (oculto)
                    txtProducto.Text,                     // Producto (nombre)
                    precio.ToString("0.00"),         // PrecioVenta
                    nudCantidad.Value.ToString(),         // Cantidad
                    (nudCantidad.Value * precio).ToString("0.00") // Subtotal
                });

                    calcularTotal();
                    limpiarProducto();
                    txtCodProducto.Select();
                }
            }
        }

        // Limpiar los campos de producto después de agregarlo
        private void limpiarProducto()
        {
            txtIdProducto.Text = "0";
            txtCodProducto.Text = "";
            txtCodProducto.BackColor = System.Drawing.Color.White;
            txtProducto.Text = "";
            txtPrecioVenta.Text = "";
            txtStock.Text = "";
            nudCantidad.Value = 1;
        }
        // Calcular el total de la venta sumando los subtotales de cada fila en el DataGridView
        private void calcularTotal()
        {
            decimal total = 0;

            if (dgridRegistrarVenta.Rows.Count > 0)
            {
                foreach (DataGridViewRow fila in dgridRegistrarVenta.Rows)
                {
                    total += Convert.ToDecimal(fila.Cells["Subtotal"].Value.ToString());
                }
                txtTotal.Text = total.ToString("0.00");
            } 
        }

        private void dgridRegistrarVenta_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (e.ColumnIndex == 5) // indice columna btnEliminar
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

        private void dgridRegistrarVenta_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgridRegistrarVenta.Columns[e.ColumnIndex].Name == "btnEliminar") // evento para cuando seleccione la celda "eliminar"
            {
                int indice = e.RowIndex;

                if (indice >= 0)
                {

                    bool respuesta = new CN_Venta().SumarStock( // Al eliminar el producto de la venta, se vuelve a sumar el stock en la base de datos
                        Convert.ToInt32(dgridRegistrarVenta.Rows[indice].Cells["IdProducto"].Value.ToString()),
                        Convert.ToInt32(dgridRegistrarVenta.Rows[indice].Cells["Cantidad"].Value.ToString()));

                    if (respuesta)
                    {
                    dgridRegistrarVenta.Rows.RemoveAt(indice);
                    txtCambio.Text = "";
                    txtTotal.Text = "";
                    txtMontoPago.Text = "";
                    calcularTotal();
                    }
                }
            }
        }

        private void txtPrecioVenta_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtMontoPago_KeyPress(object sender, KeyPressEventArgs e)
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

        // Método para calcular el cambio a devolver al cliente
        private void calcularCambio()
        {
            if(txtTotal.Text.Trim() == "")
            {
                MessageBox.Show("No existen productos en la venta", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            decimal pagaCon;
            decimal total = Convert.ToDecimal(txtTotal.Text);

            if(txtMontoPago.Text.Trim() == "")
            {
                txtMontoPago.Text = "0";
            }

            if(decimal.TryParse(txtMontoPago.Text.Trim(), out pagaCon))
            {
                if(pagaCon < total)
                {
                    txtCambio.Text = "0.00";
                }
                else
                {
                    decimal cambio = pagaCon - total;
                    txtCambio.Text = cambio.ToString("0.00");
                }
            }
        }
        // Evento para calcular el cambio cuando presiona Enter en el campo Monto Pago
        private void txtMontoPago_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyData == Keys.Enter)
            {
                calcularCambio();
            }
        }

        private void ibPagar_Click(object sender, EventArgs e)
        {
            if (txtDocCliente.Text == "")
            {
                MessageBox.Show("Debe seleccionar un cliente para la venta", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (txtNombreCliente.Text == "")
            {
                MessageBox.Show("Debe seleccionar un cliente para la venta", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            if (dgridRegistrarVenta.Rows.Count < 1)
            {
                MessageBox.Show("Debe agregar productos a la venta", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            // Crear el objeto Venta y completar sus propiedades
            DataTable detalle_venta = new DataTable();

            detalle_venta.Columns.Add("IdProducto", typeof(int));
            detalle_venta.Columns.Add("PrecioVenta", typeof(decimal));
            detalle_venta.Columns.Add("Cantidad", typeof(int));
            detalle_venta.Columns.Add("SubTotal", typeof(decimal));

            // Llenar el DataTable con los detalles de la venta desde el DataGridView
            foreach (DataGridViewRow row in dgridRegistrarVenta.Rows)
            {
                detalle_venta.Rows.Add(
                    new object[]
                    {
                        row.Cells["IdProducto"].Value.ToString(),
                        row.Cells["Precio"].Value.ToString(),
                        row.Cells["Cantidad"].Value.ToString(),
                        row.Cells["Subtotal"].Value.ToString()
                    });
            }
            int idcorrelativo = new CN_Venta().ObtenerCorrelativo();
            string numeroDocumento = string.Format("{0:00000000}", idcorrelativo);
            calcularCambio();

            Venta oventa = new Venta()
            {
                oUsuario = new Usuario() { IdUsuario = _Usuario.IdUsuario },
                TipoDocumento = ((OpcionCombo)cboxTDocumento.SelectedItem).Valor.ToString(),
                NumeroDocumento = numeroDocumento,
                DocumentoCliente = txtDocCliente.Text,
                NombreCliente = txtNombreCliente.Text,
                MontoPago = Convert.ToDecimal(txtMontoPago.Text),
                MontoCambio = Convert.ToDecimal(txtCambio.Text),
                MontoTotal = Convert.ToDecimal(txtTotal.Text)
            };

            string mensaje = string.Empty;
            bool respuesta = new CN_Venta().Registrar(oventa, detalle_venta, out mensaje);

            if (respuesta)
            {
                var result = MessageBox.Show("Numero de venta generado:\n" + numeroDocumento + "\n\n¿Desea copiar al portapapeles?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (result == DialogResult.Yes)
                {
                    Clipboard.SetText(numeroDocumento);

                    txtDocCliente.Text = "";
                    txtNombreCliente.Text = "";
                    dgridRegistrarVenta.Rows.Clear();
                    calcularTotal();
                    txtMontoPago.Text = "";
                    txtCambio.Text = "";
                    txtTotal.Text = "";
                }
                else
                {
                    MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }
    }
}
