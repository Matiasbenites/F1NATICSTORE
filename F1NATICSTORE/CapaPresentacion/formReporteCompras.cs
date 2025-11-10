using CapaEntidad;
using CapaNegocio;
using CapaPresentacion.Utilidades;
using ClosedXML.Excel;
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
    public partial class formReporteCompras : Form
    {
        public formReporteCompras()
        {
            InitializeComponent();
        }

        private void formReporteCompras_Load(object sender, EventArgs e)
        {
            dgridReporteCompra.AutoGenerateColumns = false;
            dgridReporteCompra.AllowUserToAddRows = false;
            dgridReporteCompra.ReadOnly = true;

            List<Proveedor> lista = new CN_Proveedor().Listar();

            cboxProveedor.Items.Add(new OpcionCombo() { Valor = 0, Texto = "TODOS" });
            foreach (Proveedor item in lista)
            {
                cboxProveedor.Items.Add(new OpcionCombo() { Valor = item.IdProveedor, Texto = item.RazonSocial });
            }

            cboxProveedor.DisplayMember = "Texto";
            cboxProveedor.ValueMember = "Valor";
            cboxProveedor.SelectedIndex = 0;

            foreach (DataGridViewColumn col in dgridReporteCompra.Columns)
            {  
                cboxBusqueda.Items.Add(new OpcionCombo() { Valor = col.Name, Texto = col.HeaderText });
            }
            
            cboxBusqueda.DisplayMember = "Texto";
            cboxBusqueda.ValueMember = "Valor";
            cboxBusqueda.SelectedIndex = 0;

        }

        private void btnBuscador_Click(object sender, EventArgs e)
        {
            int idproveedor = Convert.ToInt32(((OpcionCombo)cboxProveedor.SelectedItem).Valor);

            string fechaInicio = dtimeFechaInicio.Value.ToString("yyyy-MM-dd");
            string fechaFin = dtimeFechaFin.Value.ToString("yyyy-MM-dd");

            List<ReporteCompra> lista = new List<ReporteCompra>();

            lista = new CN_Reporte().Compra(
                dtimeFechaInicio.Value.ToString("yyyy-MM-dd"),
                dtimeFechaFin.Value.ToString("yyyy-MM-dd"),
                idproveedor
                );

            dgridReporteCompra.Rows.Clear();

            if (lista.Count == 0)
            {
                MessageBox.Show("No se encontraron registros en el rango de fechas seleccionado.",
                                "Sin resultados",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                return;
            }

            foreach (ReporteCompra rc in lista)
            {
                dgridReporteCompra.Rows.Add(new object[]
                {
                    rc.FechaRegistro,       // 1. Fecha Registro
                    rc.TipoDocumento,       // 2. Tipo Documento
                    rc.NumeroDocumento,     // 3. Número Documento
                    rc.MontoTotal,          // 4. Monto Total
                    rc.UsuarioRegistro,     // 5. Usuario Registro
                    rc.DocumentoProveedor,  // 6. Documento Proveedor
                    rc.RazonSocial,         // 7. Razón Social
                    rc.CodigoProducto,      // 8. Código Producto
                    rc.NombreProducto,      // 9. Nombre Producto
                    rc.Categoria,           // 10. Categoría
                    rc.PrecioCompra,        // 11. Precio Compra
                    rc.PrecioVenta,         // 12. Precio Venta
                    rc.Cantidad,            // 13. Cantidad
                    rc.SubTotal             // 14. Sub Total
                });
            }

        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            if (dgridReporteCompra.Rows.Count < 1)
            {
                MessageBox.Show("No hay datos para exportar.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                DataTable dt = new DataTable();//inserto todas las cabeceras en el excel

                foreach (DataGridViewColumn column in dgridReporteCompra.Columns)//accedo a cada una de las columnas que tengan encabezado
                {
                    dt.Columns.Add(column.HeaderText, typeof(string)); // Agrega las columnas visibles al DataTable
                }

                foreach (DataGridViewRow row in dgridReporteCompra.Rows)//recorro todas las filas del datagridview
                {
                    if (row.Visible)
                        dt.Rows.Add(new object[] {
                            row.Cells[0].Value.ToString(),
                            row.Cells[1].Value.ToString(),
                            row.Cells[2].Value.ToString(),
                            row.Cells[3].Value.ToString(),
                            row.Cells[4].Value.ToString(),
                            row.Cells[5].Value.ToString(),
                            row.Cells[6].Value.ToString(),
                            row.Cells[7].Value.ToString(),
                            row.Cells[8].Value.ToString(),
                            row.Cells[9].Value.ToString(),
                            row.Cells[10].Value.ToString(),
                            row.Cells[11].Value.ToString(),
                            row.Cells[12].Value.ToString(),
                            row.Cells[13].Value.ToString()
                        });
                }
                SaveFileDialog saveFile = new SaveFileDialog();//creo el cuadro de dialogo para guardar el archivo
                saveFile.FileName = string.Format("ReporteProductos_{0}.xlsx", DateTime.Now.ToString("ddMMyyyyHHmmss"));//nombre del archivo
                saveFile.Filter = "Excel Files | *.xlsx";//tipo de archivo

                if (saveFile.ShowDialog() == DialogResult.OK)//si el usuario presiona ok
                {
                    try
                    {
                        XLWorkbook wb = new XLWorkbook(); //creo el libro de excel
                        var hoja = wb.Worksheets.Add(dt, "Informe"); //agrego una hoja al libro
                        hoja.ColumnsUsed().AdjustToContents(); //ajusto el tamaño de las columnas al contenido
                        wb.SaveAs(saveFile.FileName); //guardo el archivo
                        MessageBox.Show("Reporte generado correctamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch
                    {
                        MessageBox.Show("Error al generar el reporte: ", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            string columnaFiltro = ((OpcionCombo)cboxBusqueda.SelectedItem).Valor.ToString(); // Obtiene el valor seleccionado del ComboBox de búsqueda

            if (dgridReporteCompra.Rows.Count > 0) // Verifica si hay filas en el DataGridView
            {
                foreach (DataGridViewRow row in dgridReporteCompra.Rows) // Recorre cada fila del DataGridView
                {
                    if (row.Cells[columnaFiltro].Value.ToString().Trim().ToUpper().Contains(txtBusqueda.Text.Trim().ToUpper())) // Compara el valor de la celda con el texto de búsqueda
                        row.Visible = true; // Muestra la fila si coincide
                    else
                        row.Visible = false; // Oculta la fila si no coincide
                }
            }
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            txtBusqueda.Text = ""; // Limpia el texto de búsqueda
            foreach (DataGridViewRow row in dgridReporteCompra.Rows) // Recorre cada fila del DataGridView
            {
                row.Visible = true; // Muestra todas las filas
            }
        }
    }
}
