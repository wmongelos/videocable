
namespace CapaPresentacion.PagosExternos.CaptarPagos
{
    partial class frmListaPagos
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
            this.tlvLista = new BrightIdeasSoftware.TreeListView();
            this.Fecha = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.IdPago = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.Detalle = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.IdCliente = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.CodigoUsuario = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.Dni = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.Nombre = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.Email = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.Monto = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.FechaCobro = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.pnlSuperior = new System.Windows.Forms.Panel();
            this.imgReturn = new System.Windows.Forms.PictureBox();
            this.lblTitulos = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.lblDesde = new System.Windows.Forms.Label();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.lblHasta = new System.Windows.Forms.Label();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.rbtPago = new System.Windows.Forms.RadioButton();
            this.rbtImpago = new System.Windows.Forms.RadioButton();
            this.rbTodos = new System.Windows.Forms.RadioButton();
            this.btnBuscar = new CapaPresentacion.Controles.boton();
            this.btnExportar = new CapaPresentacion.Controles.boton();
            this.btnPasarPagos = new CapaPresentacion.Controles.boton();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.bgWorker = new System.ComponentModel.BackgroundWorker();
            this.link = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            ((System.ComponentModel.ISupportInitialize)(this.tlvLista)).BeginInit();
            this.pnlSuperior.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgReturn)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlvLista
            // 
            this.tlvLista.AllColumns.Add(this.Fecha);
            this.tlvLista.AllColumns.Add(this.IdPago);
            this.tlvLista.AllColumns.Add(this.Detalle);
            this.tlvLista.AllColumns.Add(this.IdCliente);
            this.tlvLista.AllColumns.Add(this.CodigoUsuario);
            this.tlvLista.AllColumns.Add(this.Dni);
            this.tlvLista.AllColumns.Add(this.Nombre);
            this.tlvLista.AllColumns.Add(this.Email);
            this.tlvLista.AllColumns.Add(this.Monto);
            this.tlvLista.AllColumns.Add(this.FechaCobro);
            this.tlvLista.AllColumns.Add(this.link);
            this.tlvLista.CellEditUseWholeCell = false;
            this.tlvLista.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Fecha,
            this.IdPago,
            this.Detalle,
            this.CodigoUsuario,
            this.Dni,
            this.Nombre,
            this.Email,
            this.Monto,
            this.FechaCobro,
            this.link});
            this.tlvLista.Cursor = System.Windows.Forms.Cursors.Default;
            this.tlvLista.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlvLista.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tlvLista.GridLines = true;
            this.tlvLista.HideSelection = false;
            this.tlvLista.Location = new System.Drawing.Point(0, 111);
            this.tlvLista.Name = "tlvLista";
            this.tlvLista.ShowGroups = false;
            this.tlvLista.Size = new System.Drawing.Size(1307, 443);
            this.tlvLista.TabIndex = 1;
            this.tlvLista.UseCompatibleStateImageBehavior = false;
            this.tlvLista.View = System.Windows.Forms.View.Details;
            this.tlvLista.VirtualMode = true;
            // 
            // Fecha
            // 
            this.Fecha.AspectName = "Fecha";
            this.Fecha.Text = "Fecha";
            this.Fecha.Width = 70;
            // 
            // IdPago
            // 
            this.IdPago.AspectName = "IdPago";
            this.IdPago.Text = "Codigo de pago";
            this.IdPago.Width = 118;
            // 
            // Detalle
            // 
            this.Detalle.AspectName = "Detalle";
            this.Detalle.Text = "Detalle";
            this.Detalle.Width = 114;
            // 
            // IdCliente
            // 
            this.IdCliente.AspectName = "IdCliente";
            this.IdCliente.DisplayIndex = 3;
            this.IdCliente.IsVisible = false;
            this.IdCliente.Text = "IdCliente";
            // 
            // CodigoUsuario
            // 
            this.CodigoUsuario.AspectName = "CodigoUsuario";
            this.CodigoUsuario.Text = "Codigo Abonado";
            this.CodigoUsuario.Width = 120;
            // 
            // Dni
            // 
            this.Dni.AspectName = "Dni";
            this.Dni.Text = "Dni";
            this.Dni.Width = 97;
            // 
            // Nombre
            // 
            this.Nombre.AspectName = "Nombre";
            this.Nombre.Text = "Nombre";
            this.Nombre.Width = 134;
            // 
            // Email
            // 
            this.Email.AspectName = "Email";
            this.Email.Text = "Email";
            this.Email.Width = 132;
            // 
            // Monto
            // 
            this.Monto.AspectName = "Monto";
            this.Monto.Text = "Monto";
            this.Monto.Width = 82;
            // 
            // FechaCobro
            // 
            this.FechaCobro.AspectName = "FechaCobro";
            this.FechaCobro.Text = "FechaCobro";
            this.FechaCobro.Width = 177;
            // 
            // pnlSuperior
            // 
            this.pnlSuperior.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.pnlSuperior.Controls.Add(this.imgReturn);
            this.pnlSuperior.Controls.Add(this.lblTitulos);
            this.pnlSuperior.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSuperior.Location = new System.Drawing.Point(0, 0);
            this.pnlSuperior.Name = "pnlSuperior";
            this.pnlSuperior.Size = new System.Drawing.Size(1307, 71);
            this.pnlSuperior.TabIndex = 175;
            // 
            // imgReturn
            // 
            this.imgReturn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.imgReturn.Image = global::CapaPresentacion.Properties.Resources.Left_Arrow_32;
            this.imgReturn.Location = new System.Drawing.Point(12, 19);
            this.imgReturn.Name = "imgReturn";
            this.imgReturn.Size = new System.Drawing.Size(32, 32);
            this.imgReturn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgReturn.TabIndex = 76;
            this.imgReturn.TabStop = false;
            this.imgReturn.Click += new System.EventHandler(this.imgReturn_Click);
            // 
            // lblTitulos
            // 
            this.lblTitulos.AutoSize = true;
            this.lblTitulos.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulos.ForeColor = System.Drawing.Color.Transparent;
            this.lblTitulos.Location = new System.Drawing.Point(45, 23);
            this.lblTitulos.Name = "lblTitulos";
            this.lblTitulos.Size = new System.Drawing.Size(261, 25);
            this.lblTitulos.TabIndex = 172;
            this.lblTitulos.Text = "Lista de pagos - Captar Pagos";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.lblDesde);
            this.flowLayoutPanel1.Controls.Add(this.dtpDesde);
            this.flowLayoutPanel1.Controls.Add(this.lblHasta);
            this.flowLayoutPanel1.Controls.Add(this.dtpHasta);
            this.flowLayoutPanel1.Controls.Add(this.rbtPago);
            this.flowLayoutPanel1.Controls.Add(this.rbtImpago);
            this.flowLayoutPanel1.Controls.Add(this.rbTodos);
            this.flowLayoutPanel1.Controls.Add(this.btnBuscar);
            this.flowLayoutPanel1.Controls.Add(this.btnExportar);
            this.flowLayoutPanel1.Controls.Add(this.btnPasarPagos);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.BottomUp;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 71);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1307, 40);
            this.flowLayoutPanel1.TabIndex = 176;
            // 
            // lblDesde
            // 
            this.lblDesde.AutoSize = true;
            this.lblDesde.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDesde.Location = new System.Drawing.Point(3, 10);
            this.lblDesde.Margin = new System.Windows.Forms.Padding(3, 3, 3, 9);
            this.lblDesde.Name = "lblDesde";
            this.lblDesde.Size = new System.Drawing.Size(56, 21);
            this.lblDesde.TabIndex = 207;
            this.lblDesde.Text = "Desde:";
            // 
            // dtpDesde
            // 
            this.dtpDesde.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDesde.Location = new System.Drawing.Point(65, 4);
            this.dtpDesde.Margin = new System.Windows.Forms.Padding(3, 3, 3, 7);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(131, 29);
            this.dtpDesde.TabIndex = 208;
            // 
            // lblHasta
            // 
            this.lblHasta.AutoSize = true;
            this.lblHasta.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHasta.Location = new System.Drawing.Point(202, 10);
            this.lblHasta.Margin = new System.Windows.Forms.Padding(3, 3, 3, 9);
            this.lblHasta.Name = "lblHasta";
            this.lblHasta.Size = new System.Drawing.Size(52, 21);
            this.lblHasta.TabIndex = 209;
            this.lblHasta.Text = "Hasta:";
            // 
            // dtpHasta
            // 
            this.dtpHasta.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHasta.Location = new System.Drawing.Point(260, 4);
            this.dtpHasta.Margin = new System.Windows.Forms.Padding(3, 3, 3, 7);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(131, 29);
            this.dtpHasta.TabIndex = 210;
            // 
            // rbtPago
            // 
            this.rbtPago.AutoSize = true;
            this.rbtPago.Checked = true;
            this.rbtPago.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtPago.Location = new System.Drawing.Point(397, 7);
            this.rbtPago.Margin = new System.Windows.Forms.Padding(3, 3, 3, 8);
            this.rbtPago.Name = "rbtPago";
            this.rbtPago.Size = new System.Drawing.Size(62, 25);
            this.rbtPago.TabIndex = 212;
            this.rbtPago.TabStop = true;
            this.rbtPago.Text = "Pago";
            this.rbtPago.UseVisualStyleBackColor = true;
            // 
            // rbtImpago
            // 
            this.rbtImpago.AutoSize = true;
            this.rbtImpago.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtImpago.Location = new System.Drawing.Point(465, 7);
            this.rbtImpago.Margin = new System.Windows.Forms.Padding(3, 3, 3, 8);
            this.rbtImpago.Name = "rbtImpago";
            this.rbtImpago.Size = new System.Drawing.Size(81, 25);
            this.rbtImpago.TabIndex = 213;
            this.rbtImpago.Text = "Impago";
            this.rbtImpago.UseVisualStyleBackColor = true;
            // 
            // rbTodos
            // 
            this.rbTodos.AutoSize = true;
            this.rbTodos.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbTodos.Location = new System.Drawing.Point(552, 7);
            this.rbTodos.Margin = new System.Windows.Forms.Padding(3, 3, 3, 8);
            this.rbTodos.Name = "rbTodos";
            this.rbTodos.Size = new System.Drawing.Size(68, 25);
            this.rbTodos.TabIndex = 214;
            this.rbTodos.Text = "Todos";
            this.rbTodos.UseVisualStyleBackColor = true;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnBuscar.FlatAppearance.BorderSize = 0;
            this.btnBuscar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnBuscar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.ForeColor = System.Drawing.Color.White;
            this.btnBuscar.Image = global::CapaPresentacion.Properties.Resources.lupa;
            this.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBuscar.Location = new System.Drawing.Point(626, 5);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(3, 3, 3, 7);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(106, 28);
            this.btnBuscar.TabIndex = 211;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_ClickAsync);
            // 
            // btnExportar
            // 
            this.btnExportar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnExportar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExportar.Enabled = false;
            this.btnExportar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnExportar.FlatAppearance.BorderSize = 0;
            this.btnExportar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnExportar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnExportar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportar.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportar.ForeColor = System.Drawing.Color.White;
            this.btnExportar.Image = global::CapaPresentacion.Properties.Resources.Data_Export_32;
            this.btnExportar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExportar.Location = new System.Drawing.Point(738, 5);
            this.btnExportar.Margin = new System.Windows.Forms.Padding(3, 3, 3, 7);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(124, 28);
            this.btnExportar.TabIndex = 206;
            this.btnExportar.Text = "Exportar";
            this.btnExportar.UseVisualStyleBackColor = false;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // btnPasarPagos
            // 
            this.btnPasarPagos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPasarPagos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnPasarPagos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPasarPagos.Enabled = false;
            this.btnPasarPagos.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnPasarPagos.FlatAppearance.BorderSize = 0;
            this.btnPasarPagos.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnPasarPagos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnPasarPagos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPasarPagos.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPasarPagos.ForeColor = System.Drawing.Color.White;
            this.btnPasarPagos.Image = global::CapaPresentacion.Properties.Resources.Command_Refresh_32;
            this.btnPasarPagos.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPasarPagos.Location = new System.Drawing.Point(868, 5);
            this.btnPasarPagos.Margin = new System.Windows.Forms.Padding(3, 3, 3, 7);
            this.btnPasarPagos.Name = "btnPasarPagos";
            this.btnPasarPagos.Size = new System.Drawing.Size(175, 28);
            this.btnPasarPagos.TabIndex = 215;
            this.btnPasarPagos.Text = "Actualizar pagos";
            this.btnPasarPagos.UseVisualStyleBackColor = false;
            this.btnPasarPagos.Click += new System.EventHandler(this.btnPasarPagos_Click);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.label4);
            this.flowLayoutPanel2.Controls.Add(this.label3);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(0, 554);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.flowLayoutPanel2.Size = new System.Drawing.Size(1307, 35);
            this.flowLayoutPanel2.TabIndex = 177;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.ForestGreen;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(3, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 25);
            this.label4.TabIndex = 3;
            this.label4.Text = "PAGO";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Red;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(72, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "IMPAGO";
            // 
            // bgWorker
            // 
            this.bgWorker.WorkerReportsProgress = true;
            this.bgWorker.WorkerSupportsCancellation = true;
            // 
            // link
            // 
            this.link.AspectName = "link";
            this.link.Text = "Link";
            // 
            // frmListaPagos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1307, 589);
            this.Controls.Add(this.tlvLista);
            this.Controls.Add(this.flowLayoutPanel2);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.pnlSuperior);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmListaPagos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ordenes de pago";
            ((System.ComponentModel.ISupportInitialize)(this.tlvLista)).EndInit();
            this.pnlSuperior.ResumeLayout(false);
            this.pnlSuperior.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgReturn)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private BrightIdeasSoftware.TreeListView tlvLista;
        private BrightIdeasSoftware.OLVColumn IdPago;
        private BrightIdeasSoftware.OLVColumn Fecha;
        private BrightIdeasSoftware.OLVColumn Detalle;
        private BrightIdeasSoftware.OLVColumn Monto;
        private BrightIdeasSoftware.OLVColumn IdCliente;
        private BrightIdeasSoftware.OLVColumn Nombre;
        private BrightIdeasSoftware.OLVColumn Email;
        private BrightIdeasSoftware.OLVColumn Dni;
        private BrightIdeasSoftware.OLVColumn FechaCobro;
        private System.Windows.Forms.Panel pnlSuperior;
        private System.Windows.Forms.PictureBox imgReturn;
        private System.Windows.Forms.Label lblTitulos;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private Controles.boton btnExportar;
        private BrightIdeasSoftware.OLVColumn CodigoUsuario;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblDesde;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.Label lblHasta;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private Controles.boton btnBuscar;
        private System.Windows.Forms.RadioButton rbtPago;
        private System.Windows.Forms.RadioButton rbtImpago;
        private System.Windows.Forms.RadioButton rbTodos;
        private Controles.boton btnPasarPagos;
        private System.ComponentModel.BackgroundWorker bgWorker;
        private BrightIdeasSoftware.OLVColumn link;
    }
}