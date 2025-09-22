using CapaEntidad;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.ComponentModel;
using System.Windows.Forms;
using FontAwesome.Sharp;


namespace CapaPresentacion
{
    public partial class Inicio : Form
    {
        private static Usuario usuarioActual; // estático para mantener su valor durante la ejecución del proyecto
        private static IconMenuItem menuActivo = null;
        private static Form formActivo = null;
        public Inicio(Usuario objusuario = null)
        {
            //if (objusuario == null)
            //    usuarioActual = new Usuario() { NombreCompleto = "ADMIN PREDEFINIDO", IdUsuario = 1 };
            //else
                usuarioActual = objusuario; // USUARIO LOGEADO

            InitializeComponent();
        }
        private void Inicio_Load(object sender, EventArgs e)
        {   
            List<Permiso> ListaPermisos = new CN_Permiso().Listar(usuarioActual.IdUsuario);   // Recibe el usuario logeado para listar sus permisos

            foreach (IconMenuItem iconmenu in menu.Items)
            {
                bool encontrado = ListaPermisos.Any(m => m.NombreMenu == iconmenu.Name);

                if (!encontrado)
                {
                    iconmenu.Visible = false; // se oculta el menu encontrado
                }
            }

            lblUsuario.Text = usuarioActual.NombreCompleto;

        }
        private void menuSalir_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("¿Esta seguro que desea salir?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) // Pregunta de confirmación
            {
            this.Close();
            }
        }

        // Método para abrir formularios dentro del contenedor
        private void AbrirFormulario(IconMenuItem menu, Form formulario)
        {
            if(menuActivo != null)
            {
                menuActivo.BackColor = Color.Silver; // Color original del menú
            }
            menu.BackColor = Color.Goldenrod; // Color cuando el menú está activo
            menuActivo = menu; // Guardar el menú activo

            if (formActivo != null)
            {
                formActivo.Close();
            }
            formActivo = formulario; // Guardar el formulario activo
            formulario.TopLevel = false; // Indicar que no es un formulario principal
            formulario.FormBorderStyle = FormBorderStyle.None; // Quitar bordes
            formulario.Dock = DockStyle.Fill; // Llenar el contenedor
            formulario.BackColor = Color.DimGray; // Cambiar color de fondo
            contenedor.Controls.Add(formulario); // Agregar al contenedor
            formulario.Show(); // Mostrar el formulario
        }

        private void menuUsuarios_Click(object sender, EventArgs e)
        {
            AbrirFormulario((IconMenuItem)sender, new formUsuarios());
        }
        private void menuBackup_Click(object sender, EventArgs e)
        {
            AbrirFormulario((IconMenuItem)sender, new formBackup());
        }
        private void menuVentas_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menuVentas, new formVentas());
        }
        private void submenuRegistrarVenta_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menuVentas, new formVentas());
        }
        private void submenuDetalleVenta_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menuVentas, new formDetalleVenta());
        }
        private void menuCompras_Click(object sender, EventArgs e)
        {
            AbrirFormulario((menuCompras), new formCompras());
        }
        private void submenuCompra_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menuCompras, new formCompras());
        }
        private void submenuDetalleCompra_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menuCompras, new formDetalleCompra());
        }
        private void menuClientes_Click(object sender, EventArgs e)
        {
            AbrirFormulario((IconMenuItem)sender, new formClientes());
        }
        private void menuProductos_Click(object sender, EventArgs e)
        {
            AbrirFormulario((IconMenuItem)sender, new formProductos());
        }
        private void submenuCategoria_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menuProductos, new formCategoria());
        }
        private void submenuProducto_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menuProductos, new formProductos());
        }
        private void menuReportes_Click(object sender, EventArgs e)
        {
            AbrirFormulario((IconMenuItem)sender, new formReportes());
        }

    }
}
