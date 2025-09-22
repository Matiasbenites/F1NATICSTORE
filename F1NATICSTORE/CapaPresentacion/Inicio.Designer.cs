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
            this.contenedor = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.menu = new System.Windows.Forms.MenuStrip();
            this.iconPictureBox9 = new FontAwesome.Sharp.IconPictureBox();
            this.iconPictureBox8 = new FontAwesome.Sharp.IconPictureBox();
            this.iconPictureBox7 = new FontAwesome.Sharp.IconPictureBox();
            this.iconPictureBox6 = new FontAwesome.Sharp.IconPictureBox();
            this.iconPictureBox5 = new FontAwesome.Sharp.IconPictureBox();
            this.iconPictureBox4 = new FontAwesome.Sharp.IconPictureBox();
            this.iconPictureBox3 = new FontAwesome.Sharp.IconPictureBox();
            this.iconPictureBox2 = new FontAwesome.Sharp.IconPictureBox();
            this.iconPictureBox1 = new FontAwesome.Sharp.IconPictureBox();
            this.iconAlpine = new FontAwesome.Sharp.IconPictureBox();
            this.iconWilliams = new FontAwesome.Sharp.IconPictureBox();
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
            this.iconPictureBox10 = new FontAwesome.Sharp.IconPictureBox();
            this.menu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconAlpine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconWilliams)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox10)).BeginInit();
            this.SuspendLayout();
            // 
            // menuTitulo
            // 
            this.menuTitulo.AutoSize = false;
            this.menuTitulo.BackColor = System.Drawing.Color.White;
            this.menuTitulo.Location = new System.Drawing.Point(0, 0);
            this.menuTitulo.Name = "menuTitulo";
            this.menuTitulo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.menuTitulo.Size = new System.Drawing.Size(1202, 64);
            this.menuTitulo.TabIndex = 1;
            this.menuTitulo.Text = "menuStrip2";
            this.menuTitulo.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuTitulo_ItemClicked);
            // 
            // contenedor
            // 
            this.contenedor.BackColor = System.Drawing.Color.Transparent;
            this.contenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contenedor.Location = new System.Drawing.Point(0, 137);
            this.contenedor.Name = "contenedor";
            this.contenedor.Size = new System.Drawing.Size(1202, 551);
            this.contenedor.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(1030, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Usuario:";
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.BackColor = System.Drawing.Color.White;
            this.lblUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuario.ForeColor = System.Drawing.Color.Red;
            this.lblUsuario.Location = new System.Drawing.Point(1082, 32);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(61, 13);
            this.lblUsuario.TabIndex = 5;
            this.lblUsuario.Text = "lblusuario";
            // 
            // menu
            // 
            this.menu.BackColor = System.Drawing.Color.Silver;
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
            this.menu.Size = new System.Drawing.Size(1202, 73);
            this.menu.TabIndex = 0;
            this.menu.Text = "menuStrip1";
            this.menu.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menu_ItemClicked);
            // 
            // iconPictureBox9
            // 
            this.iconPictureBox9.BackColor = System.Drawing.Color.White;
            this.iconPictureBox9.BackgroundImage = global::CapaPresentacion.Properties.Resources.logo_f1;
            this.iconPictureBox9.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.iconPictureBox9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.iconPictureBox9.ForeColor = System.Drawing.Color.Transparent;
            this.iconPictureBox9.IconChar = FontAwesome.Sharp.IconChar.None;
            this.iconPictureBox9.IconColor = System.Drawing.Color.Transparent;
            this.iconPictureBox9.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconPictureBox9.IconSize = 49;
            this.iconPictureBox9.Location = new System.Drawing.Point(462, 12);
            this.iconPictureBox9.Name = "iconPictureBox9";
            this.iconPictureBox9.Size = new System.Drawing.Size(207, 49);
            this.iconPictureBox9.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.iconPictureBox9.TabIndex = 15;
            this.iconPictureBox9.TabStop = false;
            // 
            // iconPictureBox8
            // 
            this.iconPictureBox8.BackColor = System.Drawing.Color.White;
            this.iconPictureBox8.BackgroundImage = global::CapaPresentacion.Properties.Resources.logo_cadillac;
            this.iconPictureBox8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.iconPictureBox8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.iconPictureBox8.ForeColor = System.Drawing.Color.Transparent;
            this.iconPictureBox8.IconChar = FontAwesome.Sharp.IconChar.None;
            this.iconPictureBox8.IconColor = System.Drawing.Color.Transparent;
            this.iconPictureBox8.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconPictureBox8.IconSize = 49;
            this.iconPictureBox8.Location = new System.Drawing.Point(923, 12);
            this.iconPictureBox8.Name = "iconPictureBox8";
            this.iconPictureBox8.Size = new System.Drawing.Size(52, 49);
            this.iconPictureBox8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.iconPictureBox8.TabIndex = 14;
            this.iconPictureBox8.TabStop = false;
            // 
            // iconPictureBox7
            // 
            this.iconPictureBox7.BackColor = System.Drawing.Color.White;
            this.iconPictureBox7.BackgroundImage = global::CapaPresentacion.Properties.Resources.logo_racingbulls;
            this.iconPictureBox7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.iconPictureBox7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.iconPictureBox7.ForeColor = System.Drawing.Color.Transparent;
            this.iconPictureBox7.IconChar = FontAwesome.Sharp.IconChar.None;
            this.iconPictureBox7.IconColor = System.Drawing.Color.Transparent;
            this.iconPictureBox7.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconPictureBox7.IconSize = 49;
            this.iconPictureBox7.Location = new System.Drawing.Point(850, 12);
            this.iconPictureBox7.Name = "iconPictureBox7";
            this.iconPictureBox7.Size = new System.Drawing.Size(52, 49);
            this.iconPictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.iconPictureBox7.TabIndex = 11;
            this.iconPictureBox7.TabStop = false;
            // 
            // iconPictureBox6
            // 
            this.iconPictureBox6.BackColor = System.Drawing.Color.White;
            this.iconPictureBox6.BackgroundImage = global::CapaPresentacion.Properties.Resources.logo_ferrari;
            this.iconPictureBox6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.iconPictureBox6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.iconPictureBox6.ForeColor = System.Drawing.Color.Transparent;
            this.iconPictureBox6.IconChar = FontAwesome.Sharp.IconChar.None;
            this.iconPictureBox6.IconColor = System.Drawing.Color.Transparent;
            this.iconPictureBox6.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconPictureBox6.IconSize = 49;
            this.iconPictureBox6.Location = new System.Drawing.Point(777, 12);
            this.iconPictureBox6.Name = "iconPictureBox6";
            this.iconPictureBox6.Size = new System.Drawing.Size(52, 49);
            this.iconPictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.iconPictureBox6.TabIndex = 13;
            this.iconPictureBox6.TabStop = false;
            // 
            // iconPictureBox5
            // 
            this.iconPictureBox5.BackColor = System.Drawing.Color.White;
            this.iconPictureBox5.BackgroundImage = global::CapaPresentacion.Properties.Resources.logo_kick;
            this.iconPictureBox5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.iconPictureBox5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.iconPictureBox5.ForeColor = System.Drawing.Color.Transparent;
            this.iconPictureBox5.IconChar = FontAwesome.Sharp.IconChar.None;
            this.iconPictureBox5.IconColor = System.Drawing.Color.Transparent;
            this.iconPictureBox5.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconPictureBox5.IconSize = 49;
            this.iconPictureBox5.Location = new System.Drawing.Point(704, 12);
            this.iconPictureBox5.Name = "iconPictureBox5";
            this.iconPictureBox5.Size = new System.Drawing.Size(52, 49);
            this.iconPictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.iconPictureBox5.TabIndex = 12;
            this.iconPictureBox5.TabStop = false;
            // 
            // iconPictureBox4
            // 
            this.iconPictureBox4.BackColor = System.Drawing.Color.White;
            this.iconPictureBox4.BackgroundImage = global::CapaPresentacion.Properties.Resources.logo_redbull;
            this.iconPictureBox4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.iconPictureBox4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.iconPictureBox4.ForeColor = System.Drawing.Color.Transparent;
            this.iconPictureBox4.IconChar = FontAwesome.Sharp.IconChar.None;
            this.iconPictureBox4.IconColor = System.Drawing.Color.Transparent;
            this.iconPictureBox4.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconPictureBox4.IconSize = 47;
            this.iconPictureBox4.Location = new System.Drawing.Point(375, 12);
            this.iconPictureBox4.Name = "iconPictureBox4";
            this.iconPictureBox4.Size = new System.Drawing.Size(47, 49);
            this.iconPictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.iconPictureBox4.TabIndex = 11;
            this.iconPictureBox4.TabStop = false;
            // 
            // iconPictureBox3
            // 
            this.iconPictureBox3.BackColor = System.Drawing.Color.White;
            this.iconPictureBox3.BackgroundImage = global::CapaPresentacion.Properties.Resources.logo_mercedez;
            this.iconPictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.iconPictureBox3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.iconPictureBox3.ForeColor = System.Drawing.Color.Transparent;
            this.iconPictureBox3.IconChar = FontAwesome.Sharp.IconChar.None;
            this.iconPictureBox3.IconColor = System.Drawing.Color.Transparent;
            this.iconPictureBox3.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconPictureBox3.IconSize = 49;
            this.iconPictureBox3.Location = new System.Drawing.Point(302, 12);
            this.iconPictureBox3.Name = "iconPictureBox3";
            this.iconPictureBox3.Size = new System.Drawing.Size(52, 49);
            this.iconPictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.iconPictureBox3.TabIndex = 10;
            this.iconPictureBox3.TabStop = false;
            // 
            // iconPictureBox2
            // 
            this.iconPictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.iconPictureBox2.BackgroundImage = global::CapaPresentacion.Properties.Resources.logo_haas;
            this.iconPictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.iconPictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.iconPictureBox2.ForeColor = System.Drawing.Color.Transparent;
            this.iconPictureBox2.IconChar = FontAwesome.Sharp.IconChar.None;
            this.iconPictureBox2.IconColor = System.Drawing.Color.Transparent;
            this.iconPictureBox2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconPictureBox2.IconSize = 49;
            this.iconPictureBox2.Location = new System.Drawing.Point(231, 12);
            this.iconPictureBox2.Name = "iconPictureBox2";
            this.iconPictureBox2.Size = new System.Drawing.Size(52, 49);
            this.iconPictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.iconPictureBox2.TabIndex = 9;
            this.iconPictureBox2.TabStop = false;
            // 
            // iconPictureBox1
            // 
            this.iconPictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.iconPictureBox1.BackgroundImage = global::CapaPresentacion.Properties.Resources.logo_aston_martin;
            this.iconPictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.iconPictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.iconPictureBox1.ForeColor = System.Drawing.Color.Transparent;
            this.iconPictureBox1.IconChar = FontAwesome.Sharp.IconChar.None;
            this.iconPictureBox1.IconColor = System.Drawing.Color.Transparent;
            this.iconPictureBox1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconPictureBox1.IconSize = 49;
            this.iconPictureBox1.Location = new System.Drawing.Point(159, 12);
            this.iconPictureBox1.Name = "iconPictureBox1";
            this.iconPictureBox1.Size = new System.Drawing.Size(52, 49);
            this.iconPictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.iconPictureBox1.TabIndex = 8;
            this.iconPictureBox1.TabStop = false;
            // 
            // iconAlpine
            // 
            this.iconAlpine.BackColor = System.Drawing.Color.White;
            this.iconAlpine.BackgroundImage = global::CapaPresentacion.Properties.Resources.logo_alpine;
            this.iconAlpine.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.iconAlpine.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.iconAlpine.ForeColor = System.Drawing.Color.Transparent;
            this.iconAlpine.IconChar = FontAwesome.Sharp.IconChar.None;
            this.iconAlpine.IconColor = System.Drawing.Color.Transparent;
            this.iconAlpine.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconAlpine.IconSize = 49;
            this.iconAlpine.Location = new System.Drawing.Point(88, 12);
            this.iconAlpine.Name = "iconAlpine";
            this.iconAlpine.Size = new System.Drawing.Size(52, 49);
            this.iconAlpine.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.iconAlpine.TabIndex = 7;
            this.iconAlpine.TabStop = false;
            // 
            // iconWilliams
            // 
            this.iconWilliams.BackColor = System.Drawing.Color.White;
            this.iconWilliams.BackgroundImage = global::CapaPresentacion.Properties.Resources.Logo_Williams;
            this.iconWilliams.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.iconWilliams.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.iconWilliams.ForeColor = System.Drawing.Color.Transparent;
            this.iconWilliams.IconChar = FontAwesome.Sharp.IconChar.None;
            this.iconWilliams.IconColor = System.Drawing.Color.Transparent;
            this.iconWilliams.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconWilliams.IconSize = 49;
            this.iconWilliams.Location = new System.Drawing.Point(12, 12);
            this.iconWilliams.Name = "iconWilliams";
            this.iconWilliams.Size = new System.Drawing.Size(52, 49);
            this.iconWilliams.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.iconWilliams.TabIndex = 6;
            this.iconWilliams.TabStop = false;
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
            // iconPictureBox10
            // 
            this.iconPictureBox10.BackColor = System.Drawing.Color.White;
            this.iconPictureBox10.BackgroundImage = global::CapaPresentacion.Properties.Resources.logo_tienda;
            this.iconPictureBox10.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.iconPictureBox10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.iconPictureBox10.ForeColor = System.Drawing.Color.Transparent;
            this.iconPictureBox10.IconChar = FontAwesome.Sharp.IconChar.None;
            this.iconPictureBox10.IconColor = System.Drawing.Color.Transparent;
            this.iconPictureBox10.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconPictureBox10.IconSize = 49;
            this.iconPictureBox10.Location = new System.Drawing.Point(983, 82);
            this.iconPictureBox10.Name = "iconPictureBox10";
            this.iconPictureBox10.Size = new System.Drawing.Size(207, 49);
            this.iconPictureBox10.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.iconPictureBox10.TabIndex = 16;
            this.iconPictureBox10.TabStop = false;
            // 
            // Inicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.ClientSize = new System.Drawing.Size(1202, 688);
            this.Controls.Add(this.iconPictureBox10);
            this.Controls.Add(this.iconPictureBox9);
            this.Controls.Add(this.iconPictureBox8);
            this.Controls.Add(this.iconPictureBox7);
            this.Controls.Add(this.iconPictureBox6);
            this.Controls.Add(this.iconPictureBox5);
            this.Controls.Add(this.iconPictureBox4);
            this.Controls.Add(this.iconPictureBox3);
            this.Controls.Add(this.iconPictureBox2);
            this.Controls.Add(this.iconPictureBox1);
            this.Controls.Add(this.iconAlpine);
            this.Controls.Add(this.iconWilliams);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.contenedor);
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
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconAlpine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconWilliams)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox10)).EndInit();
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
        private FontAwesome.Sharp.IconPictureBox iconWilliams;
        private FontAwesome.Sharp.IconPictureBox iconAlpine;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox1;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox2;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox3;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox4;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox5;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox6;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox7;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox8;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox9;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox10;
    }
}

