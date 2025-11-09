namespace CapaPresentacion
{
    partial class formVentas
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.ibPagar = new FontAwesome.Sharp.IconButton();
            this.lblTotal = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.dgridRegistrarCompra = new System.Windows.Forms.DataGridView();
            this.IdProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Producto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Precio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Subtotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnEliminar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.gboxProducto = new System.Windows.Forms.GroupBox();
            this.ibAgregarProducto = new FontAwesome.Sharp.IconButton();
            this.nudCantidad = new System.Windows.Forms.NumericUpDown();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.txtPrecioVenta = new System.Windows.Forms.TextBox();
            this.lblPrecioVenta = new System.Windows.Forms.Label();
            this.lblPrecioCompra = new System.Windows.Forms.Label();
            this.txtPrecioCompra = new System.Windows.Forms.TextBox();
            this.btnBuscarProducto = new FontAwesome.Sharp.IconButton();
            this.txtIdProducto = new System.Windows.Forms.TextBox();
            this.txtProducto = new System.Windows.Forms.TextBox();
            this.lblProducto = new System.Windows.Forms.Label();
            this.lblCodProducto = new System.Windows.Forms.Label();
            this.txtCodProducto = new System.Windows.Forms.TextBox();
            this.gboxCliente = new System.Windows.Forms.GroupBox();
            this.txtIdProveedor = new System.Windows.Forms.TextBox();
            this.btnBuscarCliente = new FontAwesome.Sharp.IconButton();
            this.txtNombreProveedor = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblNroDoc = new System.Windows.Forms.Label();
            this.txtDocProveedor = new System.Windows.Forms.TextBox();
            this.cboxVenta = new System.Windows.Forms.GroupBox();
            this.cboxTDocumento = new System.Windows.Forms.ComboBox();
            this.lblTipoDoc = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();
            this.txtFecha = new System.Windows.Forms.TextBox();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMontoPago = new System.Windows.Forms.TextBox();
            this.lblCambio = new System.Windows.Forms.Label();
            this.txtCambio = new System.Windows.Forms.TextBox();
            this.lblMontoPaga = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgridRegistrarCompra)).BeginInit();
            this.gboxProducto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidad)).BeginInit();
            this.gboxCliente.SuspendLayout();
            this.cboxVenta.SuspendLayout();
            this.SuspendLayout();
            // 
            // ibPagar
            // 
            this.ibPagar.BackColor = System.Drawing.Color.ForestGreen;
            this.ibPagar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ibPagar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.ibPagar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.ibPagar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ibPagar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ibPagar.ForeColor = System.Drawing.SystemColors.Control;
            this.ibPagar.IconChar = FontAwesome.Sharp.IconChar.Tag;
            this.ibPagar.IconColor = System.Drawing.Color.White;
            this.ibPagar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.ibPagar.IconSize = 25;
            this.ibPagar.Location = new System.Drawing.Point(662, 461);
            this.ibPagar.Name = "ibPagar";
            this.ibPagar.Size = new System.Drawing.Size(110, 37);
            this.ibPagar.TabIndex = 52;
            this.ibPagar.Text = "Registrar Venta";
            this.ibPagar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ibPagar.UseVisualStyleBackColor = false;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.BackColor = System.Drawing.Color.Transparent;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.ForeColor = System.Drawing.Color.Goldenrod;
            this.lblTotal.Location = new System.Drawing.Point(21, 452);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(120, 46);
            this.lblTotal.TabIndex = 50;
            this.lblTotal.Text = "Total:";
            // 
            // txtTotal
            // 
            this.txtTotal.BackColor = System.Drawing.SystemColors.Info;
            this.txtTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotal.Location = new System.Drawing.Point(147, 459);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(132, 38);
            this.txtTotal.TabIndex = 47;
            this.txtTotal.Text = "0";
            this.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // dgridRegistrarCompra
            // 
            this.dgridRegistrarCompra.AllowUserToAddRows = false;
            this.dgridRegistrarCompra.BackgroundColor = System.Drawing.SystemColors.Info;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgridRegistrarCompra.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgridRegistrarCompra.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgridRegistrarCompra.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdProducto,
            this.Producto,
            this.Precio,
            this.Cantidad,
            this.Subtotal,
            this.btnEliminar});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Info;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgridRegistrarCompra.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgridRegistrarCompra.GridColor = System.Drawing.SystemColors.Info;
            this.dgridRegistrarCompra.Location = new System.Drawing.Point(21, 294);
            this.dgridRegistrarCompra.Name = "dgridRegistrarCompra";
            this.dgridRegistrarCompra.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgridRegistrarCompra.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.dgridRegistrarCompra.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.dgridRegistrarCompra.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.dgridRegistrarCompra.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgridRegistrarCompra.Size = new System.Drawing.Size(757, 137);
            this.dgridRegistrarCompra.TabIndex = 51;
            // 
            // IdProducto
            // 
            this.IdProducto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.IdProducto.HeaderText = "IdProducto";
            this.IdProducto.Name = "IdProducto";
            this.IdProducto.Visible = false;
            // 
            // Producto
            // 
            this.Producto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Producto.DefaultCellStyle = dataGridViewCellStyle2;
            this.Producto.HeaderText = "Producto";
            this.Producto.Name = "Producto";
            // 
            // Precio
            // 
            this.Precio.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Precio.HeaderText = "Precio";
            this.Precio.Name = "Precio";
            // 
            // Cantidad
            // 
            this.Cantidad.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Cantidad.HeaderText = "Cantidad";
            this.Cantidad.Name = "Cantidad";
            // 
            // Subtotal
            // 
            this.Subtotal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.Format = "N2";
            this.Subtotal.DefaultCellStyle = dataGridViewCellStyle3;
            this.Subtotal.HeaderText = "Subtotal";
            this.Subtotal.Name = "Subtotal";
            // 
            // btnEliminar
            // 
            this.btnEliminar.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.btnEliminar.HeaderText = "";
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.btnEliminar.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.btnEliminar.Width = 19;
            // 
            // gboxProducto
            // 
            this.gboxProducto.BackColor = System.Drawing.SystemColors.Info;
            this.gboxProducto.Controls.Add(this.ibAgregarProducto);
            this.gboxProducto.Controls.Add(this.nudCantidad);
            this.gboxProducto.Controls.Add(this.lblCantidad);
            this.gboxProducto.Controls.Add(this.txtPrecioVenta);
            this.gboxProducto.Controls.Add(this.lblPrecioVenta);
            this.gboxProducto.Controls.Add(this.lblPrecioCompra);
            this.gboxProducto.Controls.Add(this.txtPrecioCompra);
            this.gboxProducto.Controls.Add(this.btnBuscarProducto);
            this.gboxProducto.Controls.Add(this.txtIdProducto);
            this.gboxProducto.Controls.Add(this.txtProducto);
            this.gboxProducto.Controls.Add(this.lblProducto);
            this.gboxProducto.Controls.Add(this.lblCodProducto);
            this.gboxProducto.Controls.Add(this.txtCodProducto);
            this.gboxProducto.ForeColor = System.Drawing.Color.Goldenrod;
            this.gboxProducto.Location = new System.Drawing.Point(21, 168);
            this.gboxProducto.Name = "gboxProducto";
            this.gboxProducto.Size = new System.Drawing.Size(757, 120);
            this.gboxProducto.TabIndex = 48;
            this.gboxProducto.TabStop = false;
            this.gboxProducto.Text = "Información Producto";
            // 
            // ibAgregarProducto
            // 
            this.ibAgregarProducto.BackColor = System.Drawing.Color.ForestGreen;
            this.ibAgregarProducto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ibAgregarProducto.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.ibAgregarProducto.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.ibAgregarProducto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ibAgregarProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ibAgregarProducto.ForeColor = System.Drawing.SystemColors.Control;
            this.ibAgregarProducto.IconChar = FontAwesome.Sharp.IconChar.Plus;
            this.ibAgregarProducto.IconColor = System.Drawing.Color.White;
            this.ibAgregarProducto.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.ibAgregarProducto.IconSize = 25;
            this.ibAgregarProducto.Location = new System.Drawing.Point(641, 76);
            this.ibAgregarProducto.Name = "ibAgregarProducto";
            this.ibAgregarProducto.Size = new System.Drawing.Size(110, 37);
            this.ibAgregarProducto.TabIndex = 42;
            this.ibAgregarProducto.Text = "Agregar";
            this.ibAgregarProducto.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ibAgregarProducto.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ibAgregarProducto.UseVisualStyleBackColor = false;
            // 
            // nudCantidad
            // 
            this.nudCantidad.Location = new System.Drawing.Point(649, 50);
            this.nudCantidad.Name = "nudCantidad";
            this.nudCantidad.Size = new System.Drawing.Size(86, 20);
            this.nudCantidad.TabIndex = 41;
            this.nudCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudCantidad.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblCantidad
            // 
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.Location = new System.Drawing.Point(645, 34);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(52, 13);
            this.lblCantidad.TabIndex = 39;
            this.lblCantidad.Text = "Cantidad:";
            // 
            // txtPrecioVenta
            // 
            this.txtPrecioVenta.Location = new System.Drawing.Point(538, 50);
            this.txtPrecioVenta.Name = "txtPrecioVenta";
            this.txtPrecioVenta.Size = new System.Drawing.Size(105, 20);
            this.txtPrecioVenta.TabIndex = 38;
            // 
            // lblPrecioVenta
            // 
            this.lblPrecioVenta.AutoSize = true;
            this.lblPrecioVenta.Location = new System.Drawing.Point(535, 35);
            this.lblPrecioVenta.Name = "lblPrecioVenta";
            this.lblPrecioVenta.Size = new System.Drawing.Size(71, 13);
            this.lblPrecioVenta.TabIndex = 37;
            this.lblPrecioVenta.Text = "Precio Venta:";
            // 
            // lblPrecioCompra
            // 
            this.lblPrecioCompra.AutoSize = true;
            this.lblPrecioCompra.Location = new System.Drawing.Point(424, 35);
            this.lblPrecioCompra.Name = "lblPrecioCompra";
            this.lblPrecioCompra.Size = new System.Drawing.Size(79, 13);
            this.lblPrecioCompra.TabIndex = 36;
            this.lblPrecioCompra.Text = "Precio Compra:";
            // 
            // txtPrecioCompra
            // 
            this.txtPrecioCompra.Location = new System.Drawing.Point(427, 51);
            this.txtPrecioCompra.Name = "txtPrecioCompra";
            this.txtPrecioCompra.Size = new System.Drawing.Size(105, 20);
            this.txtPrecioCompra.TabIndex = 35;
            // 
            // btnBuscarProducto
            // 
            this.btnBuscarProducto.BackColor = System.Drawing.Color.Gold;
            this.btnBuscarProducto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscarProducto.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnBuscarProducto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarProducto.ForeColor = System.Drawing.Color.Black;
            this.btnBuscarProducto.IconChar = FontAwesome.Sharp.IconChar.MagnifyingGlass;
            this.btnBuscarProducto.IconColor = System.Drawing.Color.Black;
            this.btnBuscarProducto.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnBuscarProducto.IconSize = 21;
            this.btnBuscarProducto.Location = new System.Drawing.Point(162, 50);
            this.btnBuscarProducto.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnBuscarProducto.Name = "btnBuscarProducto";
            this.btnBuscarProducto.Size = new System.Drawing.Size(38, 21);
            this.btnBuscarProducto.TabIndex = 34;
            this.btnBuscarProducto.UseVisualStyleBackColor = false;
            // 
            // txtIdProducto
            // 
            this.txtIdProducto.Location = new System.Drawing.Point(118, 28);
            this.txtIdProducto.Name = "txtIdProducto";
            this.txtIdProducto.Size = new System.Drawing.Size(29, 20);
            this.txtIdProducto.TabIndex = 34;
            this.txtIdProducto.Text = "-1";
            this.txtIdProducto.Visible = false;
            // 
            // txtProducto
            // 
            this.txtProducto.Location = new System.Drawing.Point(214, 51);
            this.txtProducto.Name = "txtProducto";
            this.txtProducto.ReadOnly = true;
            this.txtProducto.Size = new System.Drawing.Size(198, 20);
            this.txtProducto.TabIndex = 31;
            // 
            // lblProducto
            // 
            this.lblProducto.AutoSize = true;
            this.lblProducto.Location = new System.Drawing.Point(211, 35);
            this.lblProducto.Name = "lblProducto";
            this.lblProducto.Size = new System.Drawing.Size(53, 13);
            this.lblProducto.TabIndex = 30;
            this.lblProducto.Text = "Producto:";
            // 
            // lblCodProducto
            // 
            this.lblCodProducto.AutoSize = true;
            this.lblCodProducto.Location = new System.Drawing.Point(17, 35);
            this.lblCodProducto.Name = "lblCodProducto";
            this.lblCodProducto.Size = new System.Drawing.Size(40, 13);
            this.lblCodProducto.TabIndex = 29;
            this.lblCodProducto.Text = "Código";
            // 
            // txtCodProducto
            // 
            this.txtCodProducto.Location = new System.Drawing.Point(20, 51);
            this.txtCodProducto.Name = "txtCodProducto";
            this.txtCodProducto.Size = new System.Drawing.Size(127, 20);
            this.txtCodProducto.TabIndex = 28;
            // 
            // gboxCliente
            // 
            this.gboxCliente.BackColor = System.Drawing.SystemColors.Info;
            this.gboxCliente.Controls.Add(this.txtIdProveedor);
            this.gboxCliente.Controls.Add(this.btnBuscarCliente);
            this.gboxCliente.Controls.Add(this.txtNombreProveedor);
            this.gboxCliente.Controls.Add(this.label2);
            this.gboxCliente.Controls.Add(this.lblNroDoc);
            this.gboxCliente.Controls.Add(this.txtDocProveedor);
            this.gboxCliente.ForeColor = System.Drawing.Color.Goldenrod;
            this.gboxCliente.Location = new System.Drawing.Point(402, 53);
            this.gboxCliente.Name = "gboxCliente";
            this.gboxCliente.Size = new System.Drawing.Size(376, 109);
            this.gboxCliente.TabIndex = 49;
            this.gboxCliente.TabStop = false;
            this.gboxCliente.Text = "Información Cliente";
            // 
            // txtIdProveedor
            // 
            this.txtIdProveedor.Location = new System.Drawing.Point(325, 19);
            this.txtIdProveedor.Name = "txtIdProveedor";
            this.txtIdProveedor.Size = new System.Drawing.Size(29, 20);
            this.txtIdProveedor.TabIndex = 33;
            this.txtIdProveedor.Text = "-1";
            this.txtIdProveedor.Visible = false;
            // 
            // btnBuscarCliente
            // 
            this.btnBuscarCliente.BackColor = System.Drawing.Color.Gold;
            this.btnBuscarCliente.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscarCliente.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnBuscarCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarCliente.ForeColor = System.Drawing.Color.Black;
            this.btnBuscarCliente.IconChar = FontAwesome.Sharp.IconChar.MagnifyingGlass;
            this.btnBuscarCliente.IconColor = System.Drawing.Color.Black;
            this.btnBuscarCliente.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnBuscarCliente.IconSize = 21;
            this.btnBuscarCliente.Location = new System.Drawing.Point(129, 51);
            this.btnBuscarCliente.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnBuscarCliente.Name = "btnBuscarCliente";
            this.btnBuscarCliente.Size = new System.Drawing.Size(38, 21);
            this.btnBuscarCliente.TabIndex = 32;
            this.btnBuscarCliente.UseVisualStyleBackColor = false;
            // 
            // txtNombreProveedor
            // 
            this.txtNombreProveedor.Location = new System.Drawing.Point(179, 51);
            this.txtNombreProveedor.Name = "txtNombreProveedor";
            this.txtNombreProveedor.Size = new System.Drawing.Size(175, 20);
            this.txtNombreProveedor.TabIndex = 31;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(176, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 30;
            this.label2.Text = "Razón Social:";
            // 
            // lblNroDoc
            // 
            this.lblNroDoc.AutoSize = true;
            this.lblNroDoc.Location = new System.Drawing.Point(19, 35);
            this.lblNroDoc.Name = "lblNroDoc";
            this.lblNroDoc.Size = new System.Drawing.Size(105, 13);
            this.lblNroDoc.TabIndex = 29;
            this.lblNroDoc.Text = "Número Documento:";
            // 
            // txtDocProveedor
            // 
            this.txtDocProveedor.Location = new System.Drawing.Point(22, 51);
            this.txtDocProveedor.Name = "txtDocProveedor";
            this.txtDocProveedor.Size = new System.Drawing.Size(100, 20);
            this.txtDocProveedor.TabIndex = 28;
            // 
            // cboxVenta
            // 
            this.cboxVenta.BackColor = System.Drawing.SystemColors.Info;
            this.cboxVenta.Controls.Add(this.cboxTDocumento);
            this.cboxVenta.Controls.Add(this.lblTipoDoc);
            this.cboxVenta.Controls.Add(this.lblFecha);
            this.cboxVenta.Controls.Add(this.txtFecha);
            this.cboxVenta.ForeColor = System.Drawing.Color.Goldenrod;
            this.cboxVenta.Location = new System.Drawing.Point(21, 53);
            this.cboxVenta.Name = "cboxVenta";
            this.cboxVenta.Size = new System.Drawing.Size(375, 109);
            this.cboxVenta.TabIndex = 46;
            this.cboxVenta.TabStop = false;
            this.cboxVenta.Text = "Información Venta";
            // 
            // cboxTDocumento
            // 
            this.cboxTDocumento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxTDocumento.FormattingEnabled = true;
            this.cboxTDocumento.Location = new System.Drawing.Point(145, 49);
            this.cboxTDocumento.Name = "cboxTDocumento";
            this.cboxTDocumento.Size = new System.Drawing.Size(205, 21);
            this.cboxTDocumento.TabIndex = 31;
            // 
            // lblTipoDoc
            // 
            this.lblTipoDoc.AutoSize = true;
            this.lblTipoDoc.Location = new System.Drawing.Point(142, 35);
            this.lblTipoDoc.Name = "lblTipoDoc";
            this.lblTipoDoc.Size = new System.Drawing.Size(87, 13);
            this.lblTipoDoc.TabIndex = 30;
            this.lblTipoDoc.Text = "Tipo documento:";
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Location = new System.Drawing.Point(17, 35);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(40, 13);
            this.lblFecha.TabIndex = 29;
            this.lblFecha.Text = "Fecha:";
            // 
            // txtFecha
            // 
            this.txtFecha.Location = new System.Drawing.Point(20, 51);
            this.txtFecha.Name = "txtFecha";
            this.txtFecha.Size = new System.Drawing.Size(100, 20);
            this.txtFecha.TabIndex = 28;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.BackColor = System.Drawing.Color.Transparent;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.Goldenrod;
            this.lblTitulo.Location = new System.Drawing.Point(16, 14);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(146, 25);
            this.lblTitulo.TabIndex = 45;
            this.lblTitulo.Text = "Registrar Venta";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Goldenrod;
            this.label1.Location = new System.Drawing.Point(-1, 0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.label1.Size = new System.Drawing.Size(806, 519);
            this.label1.TabIndex = 44;
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMontoPago
            // 
            this.txtMontoPago.BackColor = System.Drawing.SystemColors.Info;
            this.txtMontoPago.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMontoPago.Location = new System.Drawing.Point(311, 471);
            this.txtMontoPago.Name = "txtMontoPago";
            this.txtMontoPago.Size = new System.Drawing.Size(105, 26);
            this.txtMontoPago.TabIndex = 43;
            // 
            // lblCambio
            // 
            this.lblCambio.AutoSize = true;
            this.lblCambio.BackColor = System.Drawing.Color.Transparent;
            this.lblCambio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCambio.ForeColor = System.Drawing.Color.Goldenrod;
            this.lblCambio.Location = new System.Drawing.Point(442, 446);
            this.lblCambio.Name = "lblCambio";
            this.lblCambio.Size = new System.Drawing.Size(74, 20);
            this.lblCambio.TabIndex = 54;
            this.lblCambio.Text = "Cambio:";
            // 
            // txtCambio
            // 
            this.txtCambio.BackColor = System.Drawing.SystemColors.Info;
            this.txtCambio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCambio.Location = new System.Drawing.Point(446, 471);
            this.txtCambio.Name = "txtCambio";
            this.txtCambio.Size = new System.Drawing.Size(105, 26);
            this.txtCambio.TabIndex = 53;
            // 
            // lblMontoPaga
            // 
            this.lblMontoPaga.AutoSize = true;
            this.lblMontoPaga.BackColor = System.Drawing.Color.Transparent;
            this.lblMontoPaga.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMontoPaga.ForeColor = System.Drawing.Color.Goldenrod;
            this.lblMontoPaga.Location = new System.Drawing.Point(307, 446);
            this.lblMontoPaga.Name = "lblMontoPaga";
            this.lblMontoPaga.Size = new System.Drawing.Size(89, 20);
            this.lblMontoPaga.TabIndex = 44;
            this.lblMontoPaga.Text = "Paga con:";
            // 
            // formVentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::CapaPresentacion.Properties.Resources.ferrari_frm_user;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(799, 521);
            this.Controls.Add(this.lblCambio);
            this.Controls.Add(this.txtCambio);
            this.Controls.Add(this.lblMontoPaga);
            this.Controls.Add(this.txtMontoPago);
            this.Controls.Add(this.ibPagar);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.dgridRegistrarCompra);
            this.Controls.Add(this.gboxProducto);
            this.Controls.Add(this.gboxCliente);
            this.Controls.Add(this.cboxVenta);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.label1);
            this.Name = "formVentas";
            this.Text = "formVentas";
            this.Load += new System.EventHandler(this.formVentas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgridRegistrarCompra)).EndInit();
            this.gboxProducto.ResumeLayout(false);
            this.gboxProducto.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidad)).EndInit();
            this.gboxCliente.ResumeLayout(false);
            this.gboxCliente.PerformLayout();
            this.cboxVenta.ResumeLayout(false);
            this.cboxVenta.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FontAwesome.Sharp.IconButton ibPagar;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.DataGridView dgridRegistrarCompra;
        private System.Windows.Forms.GroupBox gboxProducto;
        private FontAwesome.Sharp.IconButton ibAgregarProducto;
        private System.Windows.Forms.NumericUpDown nudCantidad;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.TextBox txtPrecioVenta;
        private System.Windows.Forms.Label lblPrecioVenta;
        private System.Windows.Forms.Label lblPrecioCompra;
        private System.Windows.Forms.TextBox txtPrecioCompra;
        private FontAwesome.Sharp.IconButton btnBuscarProducto;
        private System.Windows.Forms.TextBox txtIdProducto;
        private System.Windows.Forms.TextBox txtProducto;
        private System.Windows.Forms.Label lblProducto;
        private System.Windows.Forms.Label lblCodProducto;
        private System.Windows.Forms.TextBox txtCodProducto;
        private System.Windows.Forms.GroupBox gboxCliente;
        private System.Windows.Forms.TextBox txtIdProveedor;
        private FontAwesome.Sharp.IconButton btnBuscarCliente;
        private System.Windows.Forms.TextBox txtNombreProveedor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblNroDoc;
        private System.Windows.Forms.TextBox txtDocProveedor;
        private System.Windows.Forms.GroupBox cboxVenta;
        private System.Windows.Forms.ComboBox cboxTDocumento;
        private System.Windows.Forms.Label lblTipoDoc;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.TextBox txtFecha;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Producto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Precio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Subtotal;
        private System.Windows.Forms.DataGridViewButtonColumn btnEliminar;
        private System.Windows.Forms.TextBox txtMontoPago;
        private System.Windows.Forms.Label lblCambio;
        private System.Windows.Forms.TextBox txtCambio;
        private System.Windows.Forms.Label lblMontoPaga;
    }
}