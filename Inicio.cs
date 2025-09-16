using FontAwesome.Sharp;
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
    public partial class Inicio : Form
    {
        private static IconMenuItem menuActivo = null;
        private static Form formularioActivo = null;
        public Inicio()
        {
            InitializeComponent();
        }

        private void contenedor_Paint(object sender, PaintEventArgs e)
        {

        }

        private void menuSalir_Click(object sender, EventArgs e)
        {

        }

        private void AbrirFormulario(IconMenuItem menu, Form formulario)
        {
            if(menuActivo != null)
            {
                //si ya hay un menu activo que se vuelva al color original blanco
                menuActivo.BackColor = Color.White;  //FromArgb(31, 30, 68);
            }
            // el menu seleccionado queda marcado de otro color
            menu.BackColor = Color.Silver; //FromArgb(26, 25, 62);
            // ahora este es el nuevo menú visible
            menuActivo = menu;
        }
        private void menuUsuarios_Click(object sender, EventArgs e)
        {
            AbrirFormulario((IconMenuItem)sender, new frmUsuarios());
        }
    }
}
