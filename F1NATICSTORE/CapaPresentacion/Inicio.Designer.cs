using System;
using System.Windows.Forms;

namespace CapaPresentacion
{
    partial class Inicio
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuTitulo = new System.Windows.Forms.MenuStrip();
            this.label1 = new System.Windows.Forms.Label();
            this.contenedor = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.menuUsuarios = new FontAwesome.Sharp.IconMenuItem();
            this.menuBackup = new FontAwesome.Sharp.IconMenuItem();
            this.menuVentas = new FontAwesome.Sharp.IconMenuItem();
            this.submenuRegistrarVenta = new FontAwesome.Sharp.IconMenuItem();
            this.submenuDetalleVenta = new FontAwesome.Sharp.IconMenuItem();
            this.menuCompras = new FontAwesome.Sharp.IconMenuItem();
            this.submenuCompra = new FontAwesome.Sharp.IconMenuItem();
            this.submenuDetalleCompra = new FontAwesome.Sharp.IconMenuItem();
            this.menuClientes = new FontAwesome.Sharp.IconMenuItem();
            this.menuProductos = new FontAwesome.Sharp.IconMenuItem();
            this.submenuCategoria = new FontAwesome.Sharp.IconMenuItem();
            this.submenuProducto = new FontAwesome.Sharp.IconMenuItem();
            this.menuReportes = new FontAwesome.Sharp.IconMenuItem();
            this.menuSalir = new FontAwesome.Sharp.IconMenuItem();
            this.menu = new System.Windows.Forms.MenuStrip();
            this.menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuTitulo
            // 
            this.menuTitulo.AutoSize = false;
            this.menuTitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(40)))), ((int)(((byte)(0)))));
            this.menuTitulo.Location = new System.Drawing.Point(0, 0);
            this.menuTitulo.Name = "menuTitulo";
            this.menuTitulo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.menuTitulo.Size = new System.Drawing.Size(1174, 64);
            this.menuTitulo.TabIndex = 1;
            this.menuTitulo.Text = "menuStrip2";
            this.menuTitulo.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuTitulo_ItemClicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(40)))), ((int)(((byte)(0)))));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(467, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(235, 31);
            this.label1.TabIndex = 2;
            this.label1.Text = "F1NATICSTORE";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // contenedor
            // 
            this.contenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contenedor.Location = new System.Drawing.Point(0, 137);
            this.contenedor.Name = "contenedor";
            this.contenedor.Size = new System.Drawing.Size(1174, 551);
            this.contenedor.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(985, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Usuario:";
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Location = new System.Drawing.Point(1037, 33);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(51, 13);
            this.lblUsuario.TabIndex = 5;
            this.lblUsuario.Text = "lblusuario";
            // 
            // menuUsuarios
            // 
            this.menuUsuarios.AutoSize = false;
            this.menuUsuarios.ForeColor = System.Drawing.Color.Black;
            this.menuUsuarios.IconChar = FontAwesome.Sharp.IconChar.UsersGear;
            this.menuUsuarios.IconColor = System.Drawing.Color.Black;
            this.menuUsuarios.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuUsuarios.IconSize = 50;
            this.menuUsuarios.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuUsuarios.Name = "menuUsuarios";
            this.menuUsuarios.Size = new System.Drawing.Size(122, 69);
            this.menuUsuarios.Text = "Usuarios";
            this.menuUsuarios.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.menuUsuarios.Click += new System.EventHandler(this.menuUsuarios_Click);
            // 
            // menuBackup
            // 
            this.menuBackup.AutoSize = false;
            this.menuBackup.ForeColor = System.Drawing.Color.Black;
            this.menuBackup.IconChar = FontAwesome.Sharp.IconChar.Database;
            this.menuBackup.IconColor = System.Drawing.Color.Black;
            this.menuBackup.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuBackup.IconSize = 50;
            this.menuBackup.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuBackup.Name = "menuBackup";
            this.menuBackup.Size = new System.Drawing.Size(122, 69);
            this.menuBackup.Text = "Backup";
            this.menuBackup.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.menuBackup.Click += new System.EventHandler(this.menuBackup_Click);
            // 
            // menuVentas
            // 
            this.menuVentas.AutoSize = false;
            this.menuVentas.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.submenuRegistrarVenta,
            this.submenuDetalleVenta});
            this.menuVentas.ForeColor = System.Drawing.Color.Black;
            this.menuVentas.IconChar = FontAwesome.Sharp.IconChar.Tags;
            this.menuVentas.IconColor = System.Drawing.Color.Black;
            this.menuVentas.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuVentas.IconSize = 50;
            this.menuVentas.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuVentas.Name = "menuVentas";
            this.menuVentas.Size = new System.Drawing.Size(122, 69);
            this.menuVentas.Text = "Ventas";
            this.menuVentas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.menuVentas.Click += new System.EventHandler(this.menuVentas_Click);
            // 
            // submenuRegistrarVenta
            // 
            this.submenuRegistrarVenta.IconChar = FontAwesome.Sharp.IconChar.None;
            this.submenuRegistrarVenta.IconColor = System.Drawing.Color.Black;
            this.submenuRegistrarVenta.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.submenuRegistrarVenta.Name = "submenuRegistrarVenta";
            this.submenuRegistrarVenta.Size = new System.Drawing.Size(152, 22);
            this.submenuRegistrarVenta.Text = "Registrar Venta";
            this.submenuRegistrarVenta.Click += new System.EventHandler(this.submenuRegistrarVenta_Click);
            // 
            // submenuDetalleVenta
            // 
            this.submenuDetalleVenta.IconChar = FontAwesome.Sharp.IconChar.None;
            this.submenuDetalleVenta.IconColor = System.Drawing.Color.Black;
            this.submenuDetalleVenta.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.submenuDetalleVenta.Name = "submenuDetalleVenta";
            this.submenuDetalleVenta.Size = new System.Drawing.Size(152, 22);
            this.submenuDetalleVenta.Text = "Ver Detalle";
            this.submenuDetalleVenta.Click += new System.EventHandler(this.submenuDetalleVenta_Click);
            // 
            // menuCompras
            // 
            this.menuCompras.AutoSize = false;
            this.menuCompras.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.submenuCompra,
            this.submenuDetalleCompra});
            this.menuCompras.ForeColor = System.Drawing.Color.Black;
            this.menuCompras.IconChar = FontAwesome.Sharp.IconChar.DollarSign;
            this.menuCompras.IconColor = System.Drawing.Color.Black;
            this.menuCompras.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuCompras.IconSize = 50;
            this.menuCompras.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuCompras.Name = "menuCompras";
            this.menuCompras.Size = new System.Drawing.Size(122, 69);
            this.menuCompras.Text = "Compras";
            this.menuCompras.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.menuCompras.Click += new System.EventHandler(this.menuCompras_Click);
            // 
            // submenuCompra
            // 
            this.submenuCompra.IconChar = FontAwesome.Sharp.IconChar.None;
            this.submenuCompra.IconColor = System.Drawing.Color.Black;
            this.submenuCompra.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.submenuCompra.Name = "submenuCompra";
            this.submenuCompra.Size = new System.Drawing.Size(129, 22);
            this.submenuCompra.Text = "Registrar";
            this.submenuCompra.Click += new System.EventHandler(this.submenuCompra_Click);
            // 
            // submenuDetalleCompra
            // 
            this.submenuDetalleCompra.IconChar = FontAwesome.Sharp.IconChar.None;
            this.submenuDetalleCompra.IconColor = System.Drawing.Color.Black;
            this.submenuDetalleCompra.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.submenuDetalleCompra.Name = "submenuDetalleCompra";
            this.submenuDetalleCompra.Size = new System.Drawing.Size(129, 22);
            this.submenuDetalleCompra.Text = "Ver Detalle";
            this.submenuDetalleCompra.Click += new System.EventHandler(this.submenuDetalleCompra_Click);
            // 
            // menuClientes
            // 
            this.menuClientes.AutoSize = false;
            this.menuClientes.ForeColor = System.Drawing.Color.Black;
            this.menuClientes.IconChar = FontAwesome.Sharp.IconChar.UserGroup;
            this.menuClientes.IconColor = System.Drawing.Color.Black;
            this.menuClientes.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuClientes.IconSize = 50;
            this.menuClientes.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuClientes.Name = "menuClientes";
            this.menuClientes.Size = new System.Drawing.Size(122, 69);
            this.menuClientes.Text = "Clientes";
            this.menuClientes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.menuClientes.Click += new System.EventHandler(this.menuClientes_Click);
            // 
            // menuProductos
            // 
            this.menuProductos.AutoSize = false;
            this.menuProductos.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.submenuCategoria,
            this.submenuProducto});
            this.menuProductos.ForeColor = System.Drawing.Color.Black;
            this.menuProductos.IconChar = FontAwesome.Sharp.IconChar.DollyFlatbed;
            this.menuProductos.IconColor = System.Drawing.Color.Black;
            this.menuProductos.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuProductos.IconSize = 50;
            this.menuProductos.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuProductos.Name = "menuProductos";
            this.menuProductos.Size = new System.Drawing.Size(122, 69);
            this.menuProductos.Text = "Productos";
            this.menuProductos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.menuProductos.Click += new System.EventHandler(this.menuProductos_Click);
            // 
            // submenuCategoria
            // 
            this.submenuCategoria.IconChar = FontAwesome.Sharp.IconChar.None;
            this.submenuCategoria.IconColor = System.Drawing.Color.Black;
            this.submenuCategoria.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.submenuCategoria.Name = "submenuCategoria";
            this.submenuCategoria.Size = new System.Drawing.Size(125, 22);
            this.submenuCategoria.Text = "Categoría";
            this.submenuCategoria.Click += new System.EventHandler(this.submenuCategoria_Click);
            // 
            // submenuProducto
            // 
            this.submenuProducto.IconChar = FontAwesome.Sharp.IconChar.None;
            this.submenuProducto.IconColor = System.Drawing.Color.Black;
            this.submenuProducto.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.submenuProducto.Name = "submenuProducto";
            this.submenuProducto.Size = new System.Drawing.Size(125, 22);
            this.submenuProducto.Text = "Producto";
            this.submenuProducto.Click += new System.EventHandler(this.submenuProducto_Click);
            // 
            // menuReportes
            // 
            this.menuReportes.AutoSize = false;
            this.menuReportes.ForeColor = System.Drawing.Color.Black;
            this.menuReportes.IconChar = FontAwesome.Sharp.IconChar.ChartBar;
            this.menuReportes.IconColor = System.Drawing.Color.Black;
            this.menuReportes.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuReportes.IconSize = 50;
            this.menuReportes.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuReportes.Name = "menuReportes";
            this.menuReportes.Size = new System.Drawing.Size(122, 69);
            this.menuReportes.Text = "Reportes";
            this.menuReportes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.menuReportes.Click += new System.EventHandler(this.menuReportes_Click);
            // 
            // menuSalir
            // 
            this.menuSalir.AutoSize = false;
            this.menuSalir.ForeColor = System.Drawing.Color.Black;
            this.menuSalir.IconChar = FontAwesome.Sharp.IconChar.SignOut;
            this.menuSalir.IconColor = System.Drawing.Color.Black;
            this.menuSalir.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuSalir.IconSize = 50;
            this.menuSalir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuSalir.Name = "menuSalir";
            this.menuSalir.Size = new System.Drawing.Size(122, 69);
            this.menuSalir.Text = "Salir";
            this.menuSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.menuSalir.Click += new System.EventHandler(this.menuSalir_Click);
            // 
            // menu
            // 
            this.menu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(242)))), ((int)(((byte)(0)))));
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuUsuarios,
            this.menuBackup,
            this.menuVentas,
            this.menuCompras,
            this.menuClientes,
            this.menuProductos,
            this.menuReportes,
            this.menuSalir});
            this.menu.Location = new System.Drawing.Point(0, 64);
            this.menu.Name = "menu";
            this.menu.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.menu.Size = new System.Drawing.Size(1174, 73);
            this.menu.TabIndex = 0;
            this.menu.Text = "menuStrip1";
            this.menu.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menu_ItemClicked);
            // 
            // Inicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.ClientSize = new System.Drawing.Size(1174, 688);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.contenedor);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menu);
            this.Controls.Add(this.menuTitulo);
            this.ForeColor = System.Drawing.Color.Goldenrod;
            this.MainMenuStrip = this.menu;
            this.Name = "Inicio";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "F1NATICSTORE Punto de Venta";
            this.Load += new System.EventHandler(this.Inicio_Load);
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void menu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            //throw new NotImplementedException();
        }
        private void menuTitulo_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
        #endregion
        private System.Windows.Forms.MenuStrip menuTitulo;
        private System.Windows.Forms.Label label1;
        private Panel contenedor;
        private Label label2;
        private Label lblUsuario;
        private FontAwesome.Sharp.IconMenuItem menuUsuarios;
        private FontAwesome.Sharp.IconMenuItem menuBackup;
        private FontAwesome.Sharp.IconMenuItem menuVentas;
        private FontAwesome.Sharp.IconMenuItem submenuRegistrarVenta;
        private FontAwesome.Sharp.IconMenuItem submenuDetalleVenta;
        private FontAwesome.Sharp.IconMenuItem menuCompras;
        private FontAwesome.Sharp.IconMenuItem menuClientes;
        private FontAwesome.Sharp.IconMenuItem menuProductos;
        private FontAwesome.Sharp.IconMenuItem submenuCategoria;
        private FontAwesome.Sharp.IconMenuItem submenuProducto;
        private FontAwesome.Sharp.IconMenuItem menuReportes;
        private FontAwesome.Sharp.IconMenuItem menuSalir;
        private MenuStrip menu;
        private FontAwesome.Sharp.IconMenuItem submenuCompra;
        private FontAwesome.Sharp.IconMenuItem submenuDetalleCompra;
    }
}

