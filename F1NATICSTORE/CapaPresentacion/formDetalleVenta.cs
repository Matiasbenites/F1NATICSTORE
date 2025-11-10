using CapaEntidad;
using CapaNegocio;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class formDetalleVenta : Form
    {
        public formDetalleVenta()
        {
            InitializeComponent();
        }
        private void formDetalleVenta_Load(object sender, EventArgs e)
        {
            txtBusqueda.Select();
        }
        private void btnBuscador_Click(object sender, EventArgs e)
        {
            Venta oVenta = new CN_Venta().ObtenerVenta(txtBusqueda.Text);

            if (oVenta.IdVenta != 0)
            {
                txtNumeroDocumento.Text = oVenta.NumeroDocumento;

                txtFecha.Text = oVenta.FechaRegistro;
                txtTipoDocumento.Text = oVenta.TipoDocumento;
                txtUsuario.Text = oVenta.oUsuario.NombreCompleto;

                txtDocCliente.Text = oVenta.DocumentoCliente;
                txtNombreCliente.Text = oVenta.NombreCliente;

                dgridDetalleVenta.Rows.Clear();
                foreach (Detalle_Venta dc in oVenta.oDetalleVenta)
                {
                    dgridDetalleVenta.Rows.Add(new object[]
                    {
                        dc.oProducto != null ? dc.oProducto.IdProducto :0,
                        dc.oProducto.Nombre,
                        dc.PrecioVenta,
                        dc.Cantidad,
                        dc.SubTotal
                    });
                }
                txtMontoTotal.Text = oVenta.MontoTotal.ToString("0.00");
                txtMontoPago.Text = oVenta.MontoPago.ToString("0.00");
                txtMontoCambio.Text = oVenta.MontoCambio.ToString("0.00");
            }
        }

        private void btnLimpiarBuscador_Click(object sender, EventArgs e)
        {
            txtFecha.Text = "";
            txtTipoDocumento.Text = "";
            txtUsuario.Text = "";
            txtDocCliente.Text = "";
            txtNombreCliente.Text = "";

            dgridDetalleVenta.Rows.Clear();
            txtMontoTotal.Text = "";
            txtMontoPago.Text = "";
            txtMontoCambio.Text = "";
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            if (txtTipoDocumento.Text == "")
            {
                MessageBox.Show("No hay datos para exportar", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            // Cargar la plantilla HTML
            // Si PlantillaVentaF1 es byte[]
            var TextoHtml = Properties.Resources.PlantillaVentaF1;
            Negocio odatos = new CN_Negocio().ObtenerDatos();

            // Reemplazos del encabezado
            TextoHtml = TextoHtml.Replace("@nombrenegocio", odatos.Nombre.ToUpper());
            TextoHtml = TextoHtml.Replace("@cuitempresa", odatos.Cuit.ToString());
            TextoHtml = TextoHtml.Replace("@condicioniva", odatos.CondicionIVA);
            TextoHtml = TextoHtml.Replace("@direccionempresa", odatos.Direccion);
            TextoHtml = TextoHtml.Replace("@tipocomprobante", odatos.TipoFactura.ToString());
            TextoHtml = TextoHtml.Replace("@numerocomprobante", txtNumeroDocumento.Text);

            // Datos del cliente / proveedor
            TextoHtml = TextoHtml.Replace("@nombrecliente", txtNombreCliente.Text);
            TextoHtml = TextoHtml.Replace("@cuitcliente", odatos.Cuit);
            TextoHtml = TextoHtml.Replace("@direccioncliente", odatos.Direccion);
            TextoHtml = TextoHtml.Replace("@fechaemision", txtFecha.Text);
            TextoHtml = TextoHtml.Replace("@condicionivacliente", "Consumidor Final");
            TextoHtml = TextoHtml.Replace("@usuarioemisor", txtUsuario.Text);

            // Cargar el logo de la BD
            bool obtenido;
            byte[] byteImage = new CN_Negocio().ObtenerLogo(out obtenido);
            if (obtenido && byteImage != null)
            {
                string base64Logo = Convert.ToBase64String(byteImage);
                TextoHtml = TextoHtml.Replace("@logoempresa", "data:image/png;base64," + base64Logo);
            }
            else
            {
                TextoHtml = TextoHtml.Replace("@logoempresa", "");
            }

            // Cargar los productos
            var sb = new StringBuilder();
            decimal subtotal = 0m;
            int index = 1;

            foreach (DataGridViewRow row in dgridDetalleVenta.Rows)
            {
                if (row.IsNewRow) continue;

                var producto = row.Cells["Producto"].Value?.ToString() ?? "";
                var cantidad = row.Cells["Cantidad"].Value?.ToString() ?? "0";
                // usar el nombre real de la columna definido en InitializeComponent
                var precioStr = row.Cells["Precio"].Value?.ToString() ?? "0";
                decimal precio;
                decimal.TryParse(precioStr, NumberStyles.Any, CultureInfo.CurrentCulture, out precio);

                decimal sub = 0m;
                decimal.TryParse(Convert.ToString(row.Cells["Subtotal"].Value), NumberStyles.Any, CultureInfo.CurrentCulture, out sub);

                sb.Append("<tr>");
                sb.AppendFormat("<td>{0}</td><td>{1}</td><td>{2}</td><td>{3}</td><td>21%</td><td>{4}</td>",
                                index++, producto, cantidad, precio.ToString("N2"), sub.ToString("N2"));
                sb.Append("</tr>");

                subtotal += sub;
            }

            TextoHtml = TextoHtml.Replace("@filas", sb.ToString());

            decimal iva = subtotal * 0.21m;
            decimal total = subtotal + iva;

            TextoHtml = TextoHtml.Replace("@subtotal", subtotal.ToString("N2"));
            TextoHtml = TextoHtml.Replace("@iva", iva.ToString("N2"));
            TextoHtml = TextoHtml.Replace("@montototal", total.ToString("N2"));

            // Generar el PDF
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.FileName = $"Factura_{txtNumeroDocumento.Text}.pdf";
            saveFile.Filter = "Pdf Files | *.pdf";

            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                using (FileStream stream = new FileStream(saveFile.FileName, FileMode.Create))
                {
                    Document pdfDoc = new Document(PageSize.A4, 25, 25, 25, 25);
                    PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);
                    pdfDoc.Open();

                    // Sanear HTML para que sea well-formed XML/XHTML antes de pasar a XMLWorker
                    TextoHtml = FixVoidTags(TextoHtml);

                    using (StringReader sr = new StringReader(TextoHtml))
                    {
                        XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
                    }

                    pdfDoc.Close();
                    stream.Close();
                    MessageBox.Show("El documento se creó correctamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        // Método auxiliar para cerrar tags void y producir XHTML compatible con XMLWorker
        private string FixVoidTags(string html)
        {
            string[] voids = { "meta", "br", "hr", "img", "link", "input", "area", "base", "col", "embed", "param", "source", "track", "wbr" };
            foreach (var tag in voids)
            {
                html = Regex.Replace(html, $@"<\s*{tag}(\s[^>]*?)?>",
                    m =>
                    {
                        var s = m.Value;
                        if (s.EndsWith("/>") || s.EndsWith("/ >")) return s;
                        return s.TrimEnd('>') + " />";
                    }, RegexOptions.IgnoreCase);
            }
            return html;
        }
    }
}