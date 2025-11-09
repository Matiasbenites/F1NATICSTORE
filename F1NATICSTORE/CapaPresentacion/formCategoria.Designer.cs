using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace CapaPresentacion
{
    partial class formCategoria
    {
        private IContainer components = null;

        private DataGridView dgridData;
        private TextBox txtId;
        private TextBox txtIndice;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        private void InitializeComponent()
        {
            this.dgridData = new System.Windows.Forms.DataGridView();
            this.txtId = new System.Windows.Forms.TextBox();
            this.txtIndice = new System.Windows.Forms.TextBox();
            this.lblDetalle_usuario = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cboxBusqueda = new System.Windows.Forms.ComboBox();
            this.txtBusqueda = new System.Windows.Forms.TextBox();
            this.btnBuscador = new FontAwesome.Sharp.IconButton();
            this.btnLimpiarBuscador = new FontAwesome.Sharp.IconButton();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.cboxEstado = new System.Windows.Forms.ComboBox();
            this.lblEstado = new System.Windows.Forms.Label();
            this.btnLimpiar = new FontAwesome.Sharp.IconButton();
            this.btnGuardar = new FontAwesome.Sharp.IconButton();
            this.btnEliminar = new FontAwesome.Sharp.IconButton();
            this.btnSeleccionar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EstadoValor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgridData)).BeginInit();
            this.SuspendLayout();
            // 
            // dgridData
            // 
            this.dgridData.AllowUserToAddRows = false;
            this.dgridData.AllowUserToDeleteRows = false;
            this.dgridData.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgridData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgridData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.btnSeleccionar,
            this.Id,
            this.Descripcion,
            this.EstadoValor,
            this.Estado});
            this.dgridData.Location = new System.Drawing.Point(208, 95);
            this.dgridData.Name = "dgridData";
            this.dgridData.ReadOnly = true;
            this.dgridData.RowHeadersVisible = false;
            this.dgridData.RowTemplate.Height = 25;
            this.dgridData.Size = new System.Drawing.Size(663, 165);
            this.dgridData.TabIndex = 0;
            this.dgridData.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgridData_CellContentClick);
            this.dgridData.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgridData_CellPainting);
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(150, 72);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(29, 20);
            this.txtId.TabIndex = 3;
            this.txtId.Text = "0";
            this.txtId.Visible = false;
            // 
            // txtIndice
            // 
            this.txtIndice.Location = new System.Drawing.Point(119, 72);
            this.txtIndice.Name = "txtIndice";
            this.txtIndice.Size = new System.Drawing.Size(25, 20);
            this.txtIndice.TabIndex = 5;
            this.txtIndice.Text = "-1";
            this.txtIndice.Visible = false;
            // 
            // lblDetalle_usuario
            // 
            this.lblDetalle_usuario.AutoSize = true;
            this.lblDetalle_usuario.BackColor = System.Drawing.Color.Transparent;
            this.lblDetalle_usuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetalle_usuario.ForeColor = System.Drawing.Color.Goldenrod;
            this.lblDetalle_usuario.Location = new System.Drawing.Point(25, 31);
            this.lblDetalle_usuario.Name = "lblDetalle_usuario";
            this.lblDetalle_usuario.Size = new System.Drawing.Size(162, 25);
            this.lblDetalle_usuario.TabIndex = 22;
            this.lblDetalle_usuario.Text = "Detalle Categoría";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.Info;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Goldenrod;
            this.label1.Location = new System.Drawing.Point(208, 23);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.label1.Size = new System.Drawing.Size(740, 44);
            this.label1.TabIndex = 24;
            this.label1.Text = "Listado de Categorías";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.Info;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Goldenrod;
            this.label2.Location = new System.Drawing.Point(500, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 17);
            this.label2.TabIndex = 26;
            this.label2.Text = "Buscar por:";
            // 
            // cboxBusqueda
            // 
            this.cboxBusqueda.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.cboxBusqueda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxBusqueda.FormattingEnabled = true;
            this.cboxBusqueda.Location = new System.Drawing.Point(587, 37);
            this.cboxBusqueda.Name = "cboxBusqueda";
            this.cboxBusqueda.Size = new System.Drawing.Size(130, 21);
            this.cboxBusqueda.TabIndex = 27;
            // 
            // txtBusqueda
            // 
            this.txtBusqueda.Location = new System.Drawing.Point(723, 37);
            this.txtBusqueda.Name = "txtBusqueda";
            this.txtBusqueda.Size = new System.Drawing.Size(123, 20);
            this.txtBusqueda.TabIndex = 28;
            // 
            // btnBuscador
            // 
            this.btnBuscador.BackColor = System.Drawing.Color.Gold;
            this.btnBuscador.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscador.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnBuscador.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscador.ForeColor = System.Drawing.Color.Black;
            this.btnBuscador.IconChar = FontAwesome.Sharp.IconChar.MagnifyingGlass;
            this.btnBuscador.IconColor = System.Drawing.Color.Black;
            this.btnBuscador.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnBuscador.IconSize = 21;
            this.btnBuscador.Location = new System.Drawing.Point(851, 33);
            this.btnBuscador.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnBuscador.Name = "btnBuscador";
            this.btnBuscador.Size = new System.Drawing.Size(38, 27);
            this.btnBuscador.TabIndex = 29;
            this.btnBuscador.UseVisualStyleBackColor = false;
            this.btnBuscador.Click += new System.EventHandler(this.btnBuscador_Click);
            // 
            // btnLimpiarBuscador
            // 
            this.btnLimpiarBuscador.BackColor = System.Drawing.Color.Gold;
            this.btnLimpiarBuscador.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLimpiarBuscador.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnLimpiarBuscador.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiarBuscador.ForeColor = System.Drawing.Color.Black;
            this.btnLimpiarBuscador.IconChar = FontAwesome.Sharp.IconChar.Sync;
            this.btnLimpiarBuscador.IconColor = System.Drawing.Color.Black;
            this.btnLimpiarBuscador.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnLimpiarBuscador.IconSize = 21;
            this.btnLimpiarBuscador.Location = new System.Drawing.Point(893, 33);
            this.btnLimpiarBuscador.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnLimpiarBuscador.Name = "btnLimpiarBuscador";
            this.btnLimpiarBuscador.Size = new System.Drawing.Size(38, 27);
            this.btnLimpiarBuscador.TabIndex = 30;
            this.btnLimpiarBuscador.UseVisualStyleBackColor = false;
            this.btnLimpiarBuscador.Click += new System.EventHandler(this.btnLimpiarBuscador_Click);
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(30, 111);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(149, 20);
            this.txtDescripcion.TabIndex = 31;
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.BackColor = System.Drawing.Color.Transparent;
            this.lblDescripcion.ForeColor = System.Drawing.Color.Goldenrod;
            this.lblDescripcion.Location = new System.Drawing.Point(27, 95);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(63, 13);
            this.lblDescripcion.TabIndex = 32;
            this.lblDescripcion.Text = "Descripción";
            // 
            // cboxEstado
            // 
            this.cboxEstado.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.cboxEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxEstado.FormattingEnabled = true;
            this.cboxEstado.Location = new System.Drawing.Point(30, 170);
            this.cboxEstado.Name = "cboxEstado";
            this.cboxEstado.Size = new System.Drawing.Size(149, 21);
            this.cboxEstado.TabIndex = 33;
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.BackColor = System.Drawing.Color.Transparent;
            this.lblEstado.ForeColor = System.Drawing.Color.Goldenrod;
            this.lblEstado.Location = new System.Drawing.Point(27, 154);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(40, 13);
            this.lblEstado.TabIndex = 34;
            this.lblEstado.Text = "Estado";
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnLimpiar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLimpiar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiar.ForeColor = System.Drawing.Color.White;
            this.btnLimpiar.IconChar = FontAwesome.Sharp.IconChar.Sync;
            this.btnLimpiar.IconColor = System.Drawing.Color.White;
            this.btnLimpiar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnLimpiar.IconSize = 21;
            this.btnLimpiar.Location = new System.Drawing.Point(30, 266);
            this.btnLimpiar.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(149, 32);
            this.btnLimpiar.TabIndex = 35;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLimpiar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.ForestGreen;
            this.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.IconChar = FontAwesome.Sharp.IconChar.SdCard;
            this.btnGuardar.IconColor = System.Drawing.Color.White;
            this.btnGuardar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnGuardar.IconSize = 21;
            this.btnGuardar.Location = new System.Drawing.Point(30, 228);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(149, 32);
            this.btnGuardar.TabIndex = 36;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGuardar.UseVisualStyleBackColor = false;
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.Red;
            this.btnEliminar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.ForeColor = System.Drawing.Color.White;
            this.btnEliminar.IconChar = FontAwesome.Sharp.IconChar.TrashAlt;
            this.btnEliminar.IconColor = System.Drawing.Color.White;
            this.btnEliminar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnEliminar.IconSize = 21;
            this.btnEliminar.Location = new System.Drawing.Point(30, 314);
            this.btnEliminar.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(149, 32);
            this.btnEliminar.TabIndex = 37;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEliminar.UseVisualStyleBackColor = false;
            // 
            // btnSeleccionar
            // 
            this.btnSeleccionar.HeaderText = "";
            this.btnSeleccionar.Name = "btnSeleccionar";
            this.btnSeleccionar.ReadOnly = true;
            this.btnSeleccionar.Width = 30;
            // 
            // Id
            // 
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            // 
            // Descripcion
            // 
            this.Descripcion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Descripcion.HeaderText = "Descripción";
            this.Descripcion.Name = "Descripcion";
            this.Descripcion.ReadOnly = true;
            // 
            // EstadoValor
            // 
            this.EstadoValor.HeaderText = "EstadoValor";
            this.EstadoValor.Name = "EstadoValor";
            this.EstadoValor.ReadOnly = true;
            this.EstadoValor.Visible = false;
            // 
            // Estado
            // 
            this.Estado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Estado.HeaderText = "Estado";
            this.Estado.Name = "Estado";
            this.Estado.ReadOnly = true;
            // 
            // formCategoria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::CapaPresentacion.Properties.Resources.ferrari_frm_user;
            this.ClientSize = new System.Drawing.Size(960, 540);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.lblEstado);
            this.Controls.Add(this.cboxEstado);
            this.Controls.Add(this.lblDescripcion);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.btnLimpiarBuscador);
            this.Controls.Add(this.btnBuscador);
            this.Controls.Add(this.txtBusqueda);
            this.Controls.Add(this.cboxBusqueda);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblDetalle_usuario);
            this.Controls.Add(this.txtIndice);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.dgridData);
            this.Name = "formCategoria";
            this.Text = "Gestión de Categorías";
            this.Load += new System.EventHandler(this.formCategoria_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgridData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private Label lblDetalle_usuario;
        private Label label1;
        private Label label2;
        private ComboBox cboxBusqueda;
        private TextBox txtBusqueda;
        private FontAwesome.Sharp.IconButton btnBuscador;
        private FontAwesome.Sharp.IconButton btnLimpiarBuscador;
        private TextBox txtDescripcion;
        private Label lblDescripcion;
        private ComboBox cboxEstado;
        private Label lblEstado;
        private FontAwesome.Sharp.IconButton btnLimpiar;
        private FontAwesome.Sharp.IconButton btnGuardar;
        private FontAwesome.Sharp.IconButton btnEliminar;
        private DataGridViewButtonColumn btnSeleccionar;
        private DataGridViewTextBoxColumn Id;
        private DataGridViewTextBoxColumn Descripcion;
        private DataGridViewTextBoxColumn EstadoValor;
        private DataGridViewTextBoxColumn Estado;
    }
}