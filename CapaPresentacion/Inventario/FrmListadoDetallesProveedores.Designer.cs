namespace CapaPresentacion.Inventario
{
    partial class FrmListadoDetallesProveedores
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblDesde = new System.Windows.Forms.Label();
            this.lblHasta = new System.Windows.Forms.Label();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.lblProveedor = new System.Windows.Forms.Label();
            this.pnLine = new System.Windows.Forms.Panel();
            this.imgReturn = new System.Windows.Forms.PictureBox();
            this.lblTituloHeader = new System.Windows.Forms.Label();
            this.cntDetallesCompras = new System.Windows.Forms.Panel();
            this.lblTipoComprobante = new System.Windows.Forms.Label();
            this.lblDetalle = new System.Windows.Forms.Label();
            this.dgvDetalleProveedores = new CapaPresentacion.Controles.dgv(this.components);
            this.dgvComprobantes = new CapaPresentacion.Controles.dgv(this.components);
            this.btnBuscar = new CapaPresentacion.Controles.boton();
            this.cboProveedores = new CapaPresentacion.Controles.combo(this.components);
            this.pnLine.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgReturn)).BeginInit();
            this.cntDetallesCompras.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalleProveedores)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvComprobantes)).BeginInit();
            this.SuspendLayout();
            // 
            // lblDesde
            // 
            this.lblDesde.AutoSize = true;
            this.lblDesde.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblDesde.ForeColor = System.Drawing.Color.Black;
            this.lblDesde.Location = new System.Drawing.Point(8, 108);
            this.lblDesde.Name = "lblDesde";
            this.lblDesde.Size = new System.Drawing.Size(56, 21);
            this.lblDesde.TabIndex = 341;
            this.lblDesde.Text = "Desde:";
            // 
            // lblHasta
            // 
            this.lblHasta.AutoSize = true;
            this.lblHasta.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblHasta.ForeColor = System.Drawing.Color.Black;
            this.lblHasta.Location = new System.Drawing.Point(12, 143);
            this.lblHasta.Name = "lblHasta";
            this.lblHasta.Size = new System.Drawing.Size(52, 21);
            this.lblHasta.TabIndex = 342;
            this.lblHasta.Text = "Hasta:";
            // 
            // dtpDesde
            // 
            this.dtpDesde.CustomFormat = "MMMM yyyy";
            this.dtpDesde.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDesde.Location = new System.Drawing.Point(70, 102);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(176, 29);
            this.dtpDesde.TabIndex = 343;
            this.dtpDesde.Value = new System.DateTime(2020, 2, 16, 16, 2, 0, 0);
            // 
            // dtpHasta
            // 
            this.dtpHasta.CustomFormat = "MMMM yyyy";
            this.dtpHasta.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpHasta.Location = new System.Drawing.Point(70, 137);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(176, 29);
            this.dtpHasta.TabIndex = 344;
            this.dtpHasta.Value = new System.DateTime(2020, 2, 16, 16, 2, 0, 0);
            // 
            // lblProveedor
            // 
            this.lblProveedor.AutoSize = true;
            this.lblProveedor.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblProveedor.ForeColor = System.Drawing.Color.Black;
            this.lblProveedor.Location = new System.Drawing.Point(326, 108);
            this.lblProveedor.Name = "lblProveedor";
            this.lblProveedor.Size = new System.Drawing.Size(85, 21);
            this.lblProveedor.TabIndex = 352;
            this.lblProveedor.Text = "Proveedor:";
            // 
            // pnLine
            // 
            this.pnLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.pnLine.Controls.Add(this.imgReturn);
            this.pnLine.Controls.Add(this.lblTituloHeader);
            this.pnLine.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnLine.Location = new System.Drawing.Point(0, 0);
            this.pnLine.Name = "pnLine";
            this.pnLine.Size = new System.Drawing.Size(933, 75);
            this.pnLine.TabIndex = 358;
            // 
            // imgReturn
            // 
            this.imgReturn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.imgReturn.Image = global::CapaPresentacion.Properties.Resources.Left_Arrow_32;
            this.imgReturn.Location = new System.Drawing.Point(15, 22);
            this.imgReturn.Name = "imgReturn";
            this.imgReturn.Size = new System.Drawing.Size(32, 32);
            this.imgReturn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgReturn.TabIndex = 32;
            this.imgReturn.TabStop = false;
            this.imgReturn.Click += new System.EventHandler(this.imgReturn_Click);
            // 
            // lblTituloHeader
            // 
            this.lblTituloHeader.Font = new System.Drawing.Font("Segoe UI Light", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloHeader.ForeColor = System.Drawing.Color.White;
            this.lblTituloHeader.Location = new System.Drawing.Point(53, 27);
            this.lblTituloHeader.Name = "lblTituloHeader";
            this.lblTituloHeader.Size = new System.Drawing.Size(338, 23);
            this.lblTituloHeader.TabIndex = 31;
            this.lblTituloHeader.Text = "Consulta de Compras a Proveedores";
            // 
            // cntDetallesCompras
            // 
            this.cntDetallesCompras.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cntDetallesCompras.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cntDetallesCompras.Controls.Add(this.lblTipoComprobante);
            this.cntDetallesCompras.Controls.Add(this.lblDetalle);
            this.cntDetallesCompras.Controls.Add(this.dgvDetalleProveedores);
            this.cntDetallesCompras.Controls.Add(this.dgvComprobantes);
            this.cntDetallesCompras.Location = new System.Drawing.Point(16, 172);
            this.cntDetallesCompras.Name = "cntDetallesCompras";
            this.cntDetallesCompras.Size = new System.Drawing.Size(905, 359);
            this.cntDetallesCompras.TabIndex = 360;
            // 
            // lblTipoComprobante
            // 
            this.lblTipoComprobante.AutoSize = true;
            this.lblTipoComprobante.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblTipoComprobante.ForeColor = System.Drawing.Color.Black;
            this.lblTipoComprobante.Location = new System.Drawing.Point(12, 10);
            this.lblTipoComprobante.Name = "lblTipoComprobante";
            this.lblTipoComprobante.Size = new System.Drawing.Size(205, 21);
            this.lblTipoComprobante.TabIndex = 361;
            this.lblTipoComprobante.Text = "COMPROBANTES COMPRA:";
            // 
            // lblDetalle
            // 
            this.lblDetalle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblDetalle.AutoSize = true;
            this.lblDetalle.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblDetalle.ForeColor = System.Drawing.Color.Black;
            this.lblDetalle.Location = new System.Drawing.Point(12, 160);
            this.lblDetalle.Name = "lblDetalle";
            this.lblDetalle.Size = new System.Drawing.Size(82, 21);
            this.lblDetalle.TabIndex = 360;
            this.lblDetalle.Text = "DETALLES:";
            // 
            // dgvDetalleProveedores
            // 
            this.dgvDetalleProveedores.AllowUserToAddRows = false;
            this.dgvDetalleProveedores.AllowUserToDeleteRows = false;
            this.dgvDetalleProveedores.AllowUserToOrderColumns = true;
            this.dgvDetalleProveedores.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDetalleProveedores.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDetalleProveedores.BackgroundColor = System.Drawing.Color.White;
            this.dgvDetalleProveedores.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDetalleProveedores.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI Light", 14F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDetalleProveedores.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvDetalleProveedores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDetalleProveedores.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvDetalleProveedores.EnableHeadersVisualStyles = false;
            this.dgvDetalleProveedores.GridColor = System.Drawing.Color.WhiteSmoke;
            this.dgvDetalleProveedores.Location = new System.Drawing.Point(6, 184);
            this.dgvDetalleProveedores.MultiSelect = false;
            this.dgvDetalleProveedores.Name = "dgvDetalleProveedores";
            this.dgvDetalleProveedores.ReadOnly = true;
            this.dgvDetalleProveedores.RowHeadersVisible = false;
            this.dgvDetalleProveedores.RowHeadersWidth = 50;
            this.dgvDetalleProveedores.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvDetalleProveedores.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetalleProveedores.Size = new System.Drawing.Size(895, 168);
            this.dgvDetalleProveedores.TabIndex = 357;
            // 
            // dgvComprobantes
            // 
            this.dgvComprobantes.AllowUserToAddRows = false;
            this.dgvComprobantes.AllowUserToDeleteRows = false;
            this.dgvComprobantes.AllowUserToOrderColumns = true;
            this.dgvComprobantes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvComprobantes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvComprobantes.BackgroundColor = System.Drawing.Color.White;
            this.dgvComprobantes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvComprobantes.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Segoe UI Light", 14F);
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvComprobantes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvComprobantes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvComprobantes.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgvComprobantes.EnableHeadersVisualStyles = false;
            this.dgvComprobantes.GridColor = System.Drawing.Color.WhiteSmoke;
            this.dgvComprobantes.Location = new System.Drawing.Point(6, 39);
            this.dgvComprobantes.MultiSelect = false;
            this.dgvComprobantes.Name = "dgvComprobantes";
            this.dgvComprobantes.ReadOnly = true;
            this.dgvComprobantes.RowHeadersVisible = false;
            this.dgvComprobantes.RowHeadersWidth = 50;
            this.dgvComprobantes.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvComprobantes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvComprobantes.Size = new System.Drawing.Size(892, 118);
            this.dgvComprobantes.TabIndex = 359;
            this.dgvComprobantes.SelectionChanged += new System.EventHandler(this.dgvComprobantes_SelectionChanged);
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnBuscar.FlatAppearance.BorderSize = 0;
            this.btnBuscar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnBuscar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnBuscar.ForeColor = System.Drawing.Color.White;
            this.btnBuscar.Image = global::CapaPresentacion.Properties.Resources.lupa;
            this.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBuscar.Location = new System.Drawing.Point(739, 103);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(107, 30);
            this.btnBuscar.TabIndex = 355;
            this.btnBuscar.Tag = "";
            this.btnBuscar.Text = "CONSULTA";
            this.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // cboProveedores
            // 
            this.cboProveedores.BorderColor = System.Drawing.Color.Empty;
            this.cboProveedores.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProveedores.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboProveedores.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboProveedores.FormattingEnabled = true;
            this.cboProveedores.Items.AddRange(new object[] {
            "TODOS",
            "AREAS",
            "PERSONAL",
            "MOVIL"});
            this.cboProveedores.Location = new System.Drawing.Point(417, 105);
            this.cboProveedores.Name = "cboProveedores";
            this.cboProveedores.Size = new System.Drawing.Size(316, 29);
            this.cboProveedores.TabIndex = 351;
            // 
            // FrmListadoDetallesProveedores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 554);
            this.Controls.Add(this.cntDetallesCompras);
            this.Controls.Add(this.pnLine);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.lblProveedor);
            this.Controls.Add(this.cboProveedores);
            this.Controls.Add(this.dtpHasta);
            this.Controls.Add(this.dtpDesde);
            this.Controls.Add(this.lblHasta);
            this.Controls.Add(this.lblDesde);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmListadoDetallesProveedores";
            this.Text = "FrmListadoDetallesProveedores";
            this.Load += new System.EventHandler(this.FrmListadoDetallesProveedores_Load);
            this.pnLine.ResumeLayout(false);
            this.pnLine.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgReturn)).EndInit();
            this.cntDetallesCompras.ResumeLayout(false);
            this.cntDetallesCompras.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalleProveedores)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvComprobantes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDesde;
        private System.Windows.Forms.Label lblHasta;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private Controles.combo cboProveedores;
        private System.Windows.Forms.Label lblProveedor;
        private Controles.boton btnBuscar;
        private Controles.dgv dgvDetalleProveedores;
        private System.Windows.Forms.Panel pnLine;
        private System.Windows.Forms.PictureBox imgReturn;
        private System.Windows.Forms.Label lblTituloHeader;
        private Controles.dgv dgvComprobantes;
        private System.Windows.Forms.Panel cntDetallesCompras;
        private System.Windows.Forms.Label lblDetalle;
        private System.Windows.Forms.Label lblTipoComprobante;
    }
}