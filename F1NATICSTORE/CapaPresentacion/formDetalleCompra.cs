using CapaEntidad;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using iTextSharp.text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using System.Globalization;
using System.Text.RegularExpressions;

namespace CapaPresentacion
{
    public partial class formDetalleCompra : Form
    {
        public formDetalleCompra()
        {
            InitializeComponent();
        }
        private void formDetalleCompra_Load(object sender, EventArgs e)
        {
            txtBusqueda.Select();
        }
        private void btnBuscador_Click(object sender, EventArgs e)
        {
            Compra oCompra = new CN_Compra().ObtenerCompra(txtBusqueda.Text);

            if (oCompra.IdCompra != 0)
            {
                txtNumeroDocumento.Text = oCompra.NumeroDocumento;

                txtFecha.Text = oCompra.FechaRegistro;
                txtTipoDocumento.Text = oCompra.TipoDocumento;
                txtUsuario.Text = oCompra.oUsuario.NombreCompleto;
                txtDocProveedor.Text = oCompra.oProveedor.Documento;
                txtNombreProveedor.Text = oCompra.oProveedor.RazonSocial;

                dgridRegistrarCompra.Rows.Clear();
                foreach (Detalle_Compra dc in oCompra.oDetalleCompra)
                {
                    dgridRegistrarCompra.Rows.Add(new object[]
                    {
                        dc.oProducto.IdProducto,   // IdProducto
                        dc.oProducto.Nombre,       // Producto
                        dc.PrecioCompra,           // PrecioCompra
                        dc.PrecioVenta,            // PrecioVenta (si no aplica, pasar 0m)
                        dc.Cantidad,               // Cantidad
                        dc.Total                   // Subtotal
                        // btnEliminar queda por defecto
                    });
                }
                txtMontoTotal.Text = oCompra.MontoTotal.ToString("0.00");
            }
        }

        private void btnLimpiarBuscador_Click(object sender, EventArgs e)
        {
            txtFecha.Text = "";
            txtTipoDocumento.Text = "";
            txtUsuario.Text = "";
            txtDocProveedor.Text = "";
            txtNombreProveedor.Text = "";
            dgridRegistrarCompra.Rows.Clear();
            txtMontoTotal.Text = "";
        }

            private void btnExportar_Click(object sender, EventArgs e)
        {
            if (txtTipoDocumento.Text == "")
            {
                MessageBox.Show("No hay datos para exportar", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            // Cargar la plantilla HTML
            // Si PlantillaFacturaF1 es byte[]
            var TextoHtml = Encoding.UTF8.GetString(Properties.Resources.PlantillaFacturaF1);
            Negocio odatos = new CN_Negocio().ObtenerDatos();

            // Reemplazos del encabezado
            TextoHtml = TextoHtml.Replace("@nombrenegocio", odatos.Nombre.ToUpper());
            TextoHtml = TextoHtml.Replace("@cuitempresa", odatos.Cuit.ToString());
            TextoHtml = TextoHtml.Replace("@condicioniva", odatos.CondicionIVA);
            TextoHtml = TextoHtml.Replace("@direccionempresa", odatos.Direccion);
            TextoHtml = TextoHtml.Replace("@tipocomprobante", odatos.TipoFactura.ToString());
            TextoHtml = TextoHtml.Replace("@numerocomprobante", txtNumeroDocumento.Text);

            // Datos del cliente / proveedor
            TextoHtml = TextoHtml.Replace("@nombrecliente", txtNombreProveedor.Text);
            TextoHtml = TextoHtml.Replace("@cuitcliente", txtDocProveedor.Text);
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
            string filas = "";
            decimal subtotal = 0m;
            int index = 1;
            foreach (DataGridViewRow row in dgridRegistrarCompra.Rows)
            {
                if (row.IsNewRow) continue;

                var producto = row.Cells["Producto"].Value?.ToString() ?? "";
                var cantidad = row.Cells["Cantidad"].Value?.ToString() ?? "0";
                var precio = row.Cells["PrecioCompra"].Value?.ToString() ?? "0";
                decimal sub = 0m;
                decimal.TryParse(Convert.ToString(row.Cells["Subtotal"].Value), NumberStyles.Any, CultureInfo.CurrentCulture, out sub);

                filas += "<tr>";
                filas += "<td>" + index++ + "</td>";
                filas += "<td>" + producto + "</td>";
                filas += "<td>" + cantidad + "</td>";
                filas += "<td>" + precio + "</td>";
                filas += "<td>21%</td>";
                filas += "<td>" + sub.ToString("N2") + "</td>";
                filas += "</tr>";

                subtotal += sub;
            }

            decimal iva = subtotal * 0.21m;
            decimal total = subtotal + iva;

            TextoHtml = TextoHtml.Replace("@filas", filas);
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
                    Document pdfDoc = new Document(PageSize.A4,25,25,25,25);
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








    //MessageBox.Show("En desarrollo!!", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);


    //if (txtTipoDocumento.Text == "")
    //{
    //    MessageBox.Show("No hay datos para exportar", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
    //    return;
    //}
    //string TextoHtml = Properties.Resources.PlantillaCompra.ToString();
    //Negocio odatos = new CN_Negocio().ObtenerDatos();

    //TextoHtml = TextoHtml.Replace("@NOMBREEMPRESA", odatos.Nombre.ToUpper());
    //TextoHtml = TextoHtml.Replace("@RUCEMPRESA", odatos.RUC);
    //TextoHtml = TextoHtml.Replace("@DIRECCIONEMPRESA", odatos.Direccion);

    //TextoHtml = TextoHtml.Replace("@TIPODOCUMENTO", txtTipoDocumento.Text);
    //TextoHtml = TextoHtml.Replace("@NUMERODOCUMENTO", txtNumeroDocumento.Text);

    //TextoHtml = TextoHtml.Replace("@DOCPROVEEDOR", txtDocProveedor.Text);
    //TextoHtml = TextoHtml.Replace("@NOMBREPROVEEDOR", txtNombreProveedor.Text);
    //TextoHtml = TextoHtml.Replace("@FECHAREGISTRO", txtFecha.Text); 
    //TextoHtml = TextoHtml.Replace("@USUARIOREGISTRO", txtUsuario.Text);

    //string filas = string.Empty;
    //foreach (DataGridViewRow row in dgridRegistrarCompra.Rows)
    //{
    //    filas += "<tr>";
    //    filas += "<td>" + row.Cells["Producto"].Value.ToString() + "</td>";
    //    filas += "<td>" + row.Cells["PrecioCompra"].Value.ToString() + "</td>";
    //    filas += "<td>" + row.Cells["Cantidad"].Value.ToString() + "</td>";
    //    filas += "<td>" + row.Cells["SubTotal"].Value.ToString() + "</td>";
    //    filas += "<tr>";
    //}
    //TextoHtml = TextoHtml.Replace("@filas", filas);
    //TextoHtml = TextoHtml.Replace("@montototal", txtMontoTotal.Text);

    //SaveFileDialog saveFile = new SaveFileDialog();//creo el cuadro de dialogo para guardar el archivo
    //saveFile.FileName = string.Format("Compra_{0}.pdf", txtNumeroDocumento.Text);//nombre del archivo
    //saveFile.Filter = "Pdf Files | *.pdf";//tipo de archivo

    /*  Abro el cuadro de dialogo para guardar el archivo */
    //if (saveFile.ShowDialog() == DialogResult.OK)
    //{
    //    using (FileStream stream = new FileStream(saveFile.FileName, FileMode.Create))
    //    {
    //        Document pdfDoc = new Document(PageSize.A4, 25, 25, 25, 25); // crea un doc pdf con tamaño A4 y margenes de 25

    //        PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream); // crea el pdf en un archivo en memoria con las caracteristicas del doc de arriba
    //        pdfDoc.Open(); // abre el doc para escribir en el

    //        bool obtenido = true;
    //        byte[] byteImage = new CN_Negocio().ObtenerLogo(out obtenido); // obtengo el logo de la empresa

    //        if (obtenido) { 
    //            iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(byteImage); // convierto el logo a una imagen compatible con iTextSharp
    //            img.ScaleToFit(60, 60); // ajusto el tamaño de la imagen
    //            img.Alignment = iTextSharp.text.Image.UNDERLYING;// Element.ALIGN_LEFT; // alineo la imagen a la izquierda
    //            img.SetAbsolutePosition(pdfDoc.Left, pdfDoc.GetTop(51)); // posiciono la imagen en la parte superior izquierda del doc
    //            pdfDoc.Add(img); // agrego la imagen al doc
    //        }
    //        using (StringReader sr = new StringReader(TextoHtml)) // creo un lector de strings para leer el html
    //        {
    //           XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr); // convierto el html a pdf
    //        }
    //        pdfDoc.Close(); // cierro el doc
    //        stream.Close(); // cierro el archivo en memoria
    //        MessageBox.Show("El documento se creo correctamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
    //    }
    //}