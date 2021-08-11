namespace CapaPresentacion.Partes_Trabajo
{
    partial class frmCortesNuevo
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lbperiodos = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.imgReturn = new System.Windows.Forms.PictureBox();
            this.lblHeader = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.pnFooter = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.lblParciales = new System.Windows.Forms.Label();
            this.lblAvisos = new System.Windows.Forms.Label();
            this.lblCortes = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.pgCircular = new CapaPresentacion.Controles.progress();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.lblFecha = new System.Windows.Forms.Label();
            this.spPeriodosAdeudados = new System.Windows.Forms.NumericUpDown();
            this.rbFaltaPago = new System.Windows.Forms.RadioButton();
            this.rbFinalizacionServicio = new System.Windows.Forms.RadioButton();
            this.lblImporte = new System.Windows.Forms.Label();
            this.spImporte = new System.Windows.Forms.NumericUpDown();
            this.lblTipo = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmsOpciones = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.verCuentaCorrienteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verDatosDeContactoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.irAlUsuarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verDetalleDeDeudaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label3 = new System.Windows.Forms.Label();
            this.spTolerancia = new System.Windows.Forms.NumericUpDown();
            this.lblDiasTolerancia = new System.Windows.Forms.Label();
            this.btnFiltro = new CapaPresentacion.Controles.boton();
            this.cboFiltro = new CapaPresentacion.Controles.combo(this.components);
            this.cboTipoFacturacion = new CapaPresentacion.Controles.combo(this.components);
            this.btnExportar = new CapaPresentacion.Controles.boton();
            this.btnTildar = new CapaPresentacion.Controles.boton();
            this.txtBuscar = new CapaPresentacion.textboxAdv();
            this.dgvCortes = new CapaPresentacion.Controles.dgv(this.components);
            this.btnPostergar = new CapaPresentacion.Controles.boton();
            this.dgvTipos = new CapaPresentacion.Controles.dgv(this.components);
            this.btnAvisos = new CapaPresentacion.Controles.boton();
            this.btnBuscar = new CapaPresentacion.Controles.boton();
            this.btnGenera = new CapaPresentacion.Controles.boton();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnMapa = new CapaPresentacion.Controles.boton();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgReturn)).BeginInit();
            this.pnFooter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spPeriodosAdeudados)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spImporte)).BeginInit();
            this.cmsOpciones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spTolerancia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCortes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTipos)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbperiodos
            // 
            this.lbperiodos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbperiodos.AutoSize = true;
            this.lbperiodos.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbperiodos.ForeColor = System.Drawing.Color.White;
            this.lbperiodos.Location = new System.Drawing.Point(1324, 95);
            this.lbperiodos.Name = "lbperiodos";
            this.lbperiodos.Size = new System.Drawing.Size(56, 15);
            this.lbperiodos.TabIndex = 6;
            this.lbperiodos.Text = "Periodos";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.panel1.Controls.Add(this.imgReturn);
            this.panel1.Controls.Add(this.lblHeader);
            this.panel1.Controls.Add(this.lbperiodos);
            this.panel1.Location = new System.Drawing.Point(1, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1383, 76);
            this.panel1.TabIndex = 8;
            // 
            // imgReturn
            // 
            this.imgReturn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.imgReturn.Image = global::CapaPresentacion.Properties.Resources.Left_Arrow_32;
            this.imgReturn.Location = new System.Drawing.Point(13, 20);
            this.imgReturn.Name = "imgReturn";
            this.imgReturn.Size = new System.Drawing.Size(32, 32);
            this.imgReturn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgReturn.TabIndex = 139;
            this.imgReturn.TabStop = false;
            this.imgReturn.Click += new System.EventHandler(this.imgReturn_Click);
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.ForeColor = System.Drawing.Color.LightGray;
            this.lblHeader.Location = new System.Drawing.Point(51, 24);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(161, 26);
            this.lblHeader.TabIndex = 138;
            this.lblHeader.Text = "Cortes de servicio";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label4.Location = new System.Drawing.Point(1158, 188);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(155, 21);
            this.label4.TabIndex = 141;
            this.label4.Text = "Periodos Adeudados:";
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackColor = System.Drawing.Color.Gainsboro;
            this.panel3.Location = new System.Drawing.Point(1, 127);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1400, 1);
            this.panel3.TabIndex = 171;
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.BackColor = System.Drawing.Color.Gainsboro;
            this.panel4.Location = new System.Drawing.Point(1, 220);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1400, 1);
            this.panel4.TabIndex = 172;
            // 
            // pnFooter
            // 
            this.pnFooter.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnFooter.Controls.Add(this.label6);
            this.pnFooter.Controls.Add(this.lblParciales);
            this.pnFooter.Controls.Add(this.lblAvisos);
            this.pnFooter.Controls.Add(this.lblCortes);
            this.pnFooter.Controls.Add(this.lblTotal);
            this.pnFooter.Controls.Add(this.pgCircular);
            this.pnFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnFooter.Location = new System.Drawing.Point(0, 524);
            this.pnFooter.Name = "pnFooter";
            this.pnFooter.Size = new System.Drawing.Size(1386, 30);
            this.pnFooter.TabIndex = 245;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.LightSkyBlue;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label6.Location = new System.Drawing.Point(878, 4);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(143, 21);
            this.label6.TabIndex = 17;
            this.label6.Text = "Servicios en espera";
            // 
            // lblParciales
            // 
            this.lblParciales.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblParciales.AutoSize = true;
            this.lblParciales.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblParciales.ForeColor = System.Drawing.Color.SlateGray;
            this.lblParciales.Location = new System.Drawing.Point(412, 5);
            this.lblParciales.Name = "lblParciales";
            this.lblParciales.Size = new System.Drawing.Size(156, 21);
            this.lblParciales.TabIndex = 16;
            this.lblParciales.Text = "Registros parciales: 0";
            // 
            // lblAvisos
            // 
            this.lblAvisos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAvisos.AutoSize = true;
            this.lblAvisos.BackColor = System.Drawing.Color.Gold;
            this.lblAvisos.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblAvisos.Location = new System.Drawing.Point(1027, 4);
            this.lblAvisos.Name = "lblAvisos";
            this.lblAvisos.Size = new System.Drawing.Size(152, 21);
            this.lblAvisos.TabIndex = 15;
            this.lblAvisos.Text = "Avisos ya generados";
            // 
            // lblCortes
            // 
            this.lblCortes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCortes.AutoSize = true;
            this.lblCortes.BackColor = System.Drawing.Color.Tomato;
            this.lblCortes.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblCortes.Location = new System.Drawing.Point(1185, 4);
            this.lblCortes.Name = "lblCortes";
            this.lblCortes.Size = new System.Drawing.Size(152, 21);
            this.lblCortes.TabIndex = 14;
            this.lblCortes.Text = "Cortes ya generados";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblTotal.ForeColor = System.Drawing.Color.SlateGray;
            this.lblTotal.Location = new System.Drawing.Point(11, 5);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(148, 21);
            this.lblTotal.TabIndex = 13;
            this.lblTotal.Text = "Total de Registros: 0";
            // 
            // pgCircular
            // 
            this.pgCircular.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pgCircular.Location = new System.Drawing.Point(1350, 2);
            this.pgCircular.Name = "pgCircular";
            this.pgCircular.Percentage = 0F;
            this.pgCircular.Rotation = CapaPresentacion.Controles.RotationType.CounterClockwise;
            this.pgCircular.Size = new System.Drawing.Size(24, 24);
            this.pgCircular.TabIndex = 0;
            // 
            // dtpFecha
            // 
            this.dtpFecha.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpFecha.CustomFormat = "";
            this.dtpFecha.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFecha.Location = new System.Drawing.Point(1125, 137);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(106, 29);
            this.dtpFecha.TabIndex = 247;
            // 
            // lblFecha
            // 
            this.lblFecha.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFecha.AutoSize = true;
            this.lblFecha.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblFecha.Location = new System.Drawing.Point(975, 143);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(144, 21);
            this.lblFecha.TabIndex = 249;
            this.lblFecha.Text = "Con fecha menor a:";
            // 
            // spPeriodosAdeudados
            // 
            this.spPeriodosAdeudados.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.spPeriodosAdeudados.Enabled = false;
            this.spPeriodosAdeudados.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spPeriodosAdeudados.Location = new System.Drawing.Point(1320, 185);
            this.spPeriodosAdeudados.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spPeriodosAdeudados.Name = "spPeriodosAdeudados";
            this.spPeriodosAdeudados.Size = new System.Drawing.Size(54, 29);
            this.spPeriodosAdeudados.TabIndex = 250;
            this.spPeriodosAdeudados.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.spPeriodosAdeudados.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spPeriodosAdeudados.ValueChanged += new System.EventHandler(this.spPeriodosAdeudados_ValueChanged);
            // 
            // rbFaltaPago
            // 
            this.rbFaltaPago.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbFaltaPago.AutoSize = true;
            this.rbFaltaPago.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.rbFaltaPago.Location = new System.Drawing.Point(824, 141);
            this.rbFaltaPago.Name = "rbFaltaPago";
            this.rbFaltaPago.Size = new System.Drawing.Size(145, 25);
            this.rbFaltaPago.TabIndex = 251;
            this.rbFaltaPago.TabStop = true;
            this.rbFaltaPago.Text = "Por falta de pago";
            this.rbFaltaPago.UseVisualStyleBackColor = true;
            this.rbFaltaPago.CheckedChanged += new System.EventHandler(this.rbFaltaPago_CheckedChanged);
            // 
            // rbFinalizacionServicio
            // 
            this.rbFinalizacionServicio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbFinalizacionServicio.AutoSize = true;
            this.rbFinalizacionServicio.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.rbFinalizacionServicio.Location = new System.Drawing.Point(602, 141);
            this.rbFinalizacionServicio.Name = "rbFinalizacionServicio";
            this.rbFinalizacionServicio.Size = new System.Drawing.Size(215, 25);
            this.rbFinalizacionServicio.TabIndex = 252;
            this.rbFinalizacionServicio.TabStop = true;
            this.rbFinalizacionServicio.Text = "Por finalización del servicio";
            this.rbFinalizacionServicio.UseVisualStyleBackColor = true;
            this.rbFinalizacionServicio.CheckedChanged += new System.EventHandler(this.rbFinalizacionServicio_CheckedChanged);
            // 
            // lblImporte
            // 
            this.lblImporte.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblImporte.AutoSize = true;
            this.lblImporte.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblImporte.Location = new System.Drawing.Point(912, 188);
            this.lblImporte.Name = "lblImporte";
            this.lblImporte.Size = new System.Drawing.Size(147, 21);
            this.lblImporte.TabIndex = 255;
            this.lblImporte.Text = "Importe a partir de :";
            // 
            // spImporte
            // 
            this.spImporte.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.spImporte.Enabled = false;
            this.spImporte.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spImporte.Location = new System.Drawing.Point(1065, 186);
            this.spImporte.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.spImporte.Name = "spImporte";
            this.spImporte.Size = new System.Drawing.Size(87, 29);
            this.spImporte.TabIndex = 256;
            this.spImporte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.spImporte.ValueChanged += new System.EventHandler(this.spImporte_ValueChanged);
            // 
            // lblTipo
            // 
            this.lblTipo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTipo.AutoSize = true;
            this.lblTipo.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblTipo.Location = new System.Drawing.Point(516, 141);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(79, 21);
            this.lblTipo.TabIndex = 258;
            this.lblTipo.Text = "Corte por:";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label2.Location = new System.Drawing.Point(785, 231);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 21);
            this.label2.TabIndex = 260;
            this.label2.Text = "Buscar en grilla";
            // 
            // cmsOpciones
            // 
            this.cmsOpciones.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.verCuentaCorrienteToolStripMenuItem,
            this.verDatosDeContactoToolStripMenuItem,
            this.irAlUsuarioToolStripMenuItem,
            this.verDetalleDeDeudaToolStripMenuItem});
            this.cmsOpciones.Name = "cmsOpciones";
            this.cmsOpciones.Size = new System.Drawing.Size(189, 92);
            // 
            // verCuentaCorrienteToolStripMenuItem
            // 
            this.verCuentaCorrienteToolStripMenuItem.Name = "verCuentaCorrienteToolStripMenuItem";
            this.verCuentaCorrienteToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.verCuentaCorrienteToolStripMenuItem.Text = "Ver cuenta corriente";
            this.verCuentaCorrienteToolStripMenuItem.Click += new System.EventHandler(this.verCuentaCorrienteToolStripMenuItem_Click);
            // 
            // verDatosDeContactoToolStripMenuItem
            // 
            this.verDatosDeContactoToolStripMenuItem.Name = "verDatosDeContactoToolStripMenuItem";
            this.verDatosDeContactoToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.verDatosDeContactoToolStripMenuItem.Text = "Ver datos de contacto";
            this.verDatosDeContactoToolStripMenuItem.Click += new System.EventHandler(this.verDatosDeContactoToolStripMenuItem_Click);
            // 
            // irAlUsuarioToolStripMenuItem
            // 
            this.irAlUsuarioToolStripMenuItem.Name = "irAlUsuarioToolStripMenuItem";
            this.irAlUsuarioToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.irAlUsuarioToolStripMenuItem.Text = "Ir al usuario";
            this.irAlUsuarioToolStripMenuItem.Click += new System.EventHandler(this.irAlUsuarioToolStripMenuItem_Click);
            // 
            // verDetalleDeDeudaToolStripMenuItem
            // 
            this.verDetalleDeDeudaToolStripMenuItem.Name = "verDetalleDeDeudaToolStripMenuItem";
            this.verDetalleDeDeudaToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.verDetalleDeDeudaToolStripMenuItem.Text = "Ver detalle de deuda";
            this.verDetalleDeDeudaToolStripMenuItem.Click += new System.EventHandler(this.verDetalleDeDeudaToolStripMenuItem_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label3.Location = new System.Drawing.Point(412, 231);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 21);
            this.label3.TabIndex = 344;
            this.label3.Text = "Filtrar por:";
            // 
            // spTolerancia
            // 
            this.spTolerancia.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.spTolerancia.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spTolerancia.Location = new System.Drawing.Point(814, 185);
            this.spTolerancia.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.spTolerancia.Name = "spTolerancia";
            this.spTolerancia.Size = new System.Drawing.Size(87, 29);
            this.spTolerancia.TabIndex = 347;
            this.spTolerancia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblDiasTolerancia
            // 
            this.lblDiasTolerancia.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDiasTolerancia.AutoSize = true;
            this.lblDiasTolerancia.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblDiasTolerancia.Location = new System.Drawing.Point(612, 188);
            this.lblDiasTolerancia.Name = "lblDiasTolerancia";
            this.lblDiasTolerancia.Size = new System.Drawing.Size(196, 21);
            this.lblDiasTolerancia.TabIndex = 346;
            this.lblDiasTolerancia.Text = "Dias de tolerancia de pago:\r\n";
            // 
            // btnFiltro
            // 
            this.btnFiltro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnFiltro.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFiltro.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnFiltro.FlatAppearance.BorderSize = 0;
            this.btnFiltro.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnFiltro.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnFiltro.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFiltro.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnFiltro.ForeColor = System.Drawing.Color.White;
            this.btnFiltro.Image = global::CapaPresentacion.Properties.Resources.lupa;
            this.btnFiltro.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFiltro.Location = new System.Drawing.Point(718, 225);
            this.btnFiltro.Name = "btnFiltro";
            this.btnFiltro.Size = new System.Drawing.Size(28, 29);
            this.btnFiltro.TabIndex = 345;
            this.btnFiltro.UseVisualStyleBackColor = false;
            this.btnFiltro.Click += new System.EventHandler(this.btnFiltro_Click);
            // 
            // cboFiltro
            // 
            this.cboFiltro.BorderColor = System.Drawing.Color.Gainsboro;
            this.cboFiltro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFiltro.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboFiltro.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboFiltro.FormattingEnabled = true;
            this.cboFiltro.Items.AddRange(new object[] {
            "TODO",
            "CON AVISOS, SIN CORTE",
            "SIN AVISOS, SIN CORTE",
            "CON CORTE",
            "SIN CORTE"});
            this.cboFiltro.Location = new System.Drawing.Point(498, 226);
            this.cboFiltro.Name = "cboFiltro";
            this.cboFiltro.Size = new System.Drawing.Size(214, 29);
            this.cboFiltro.TabIndex = 343;
            // 
            // cboTipoFacturacion
            // 
            this.cboTipoFacturacion.BorderColor = System.Drawing.Color.Gainsboro;
            this.cboTipoFacturacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoFacturacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboTipoFacturacion.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTipoFacturacion.FormattingEnabled = true;
            this.cboTipoFacturacion.Location = new System.Drawing.Point(15, 226);
            this.cboTipoFacturacion.Name = "cboTipoFacturacion";
            this.cboTipoFacturacion.Size = new System.Drawing.Size(386, 29);
            this.cboTipoFacturacion.TabIndex = 342;
            // 
            // btnExportar
            // 
            this.btnExportar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnExportar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExportar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnExportar.FlatAppearance.BorderSize = 0;
            this.btnExportar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnExportar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnExportar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportar.ForeColor = System.Drawing.Color.White;
            this.btnExportar.Image = global::CapaPresentacion.Properties.Resources.Data_Export_32;
            this.btnExportar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExportar.Location = new System.Drawing.Point(816, 3);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(109, 39);
            this.btnExportar.TabIndex = 341;
            this.btnExportar.Text = "Exportar";
            this.btnExportar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExportar.UseVisualStyleBackColor = true;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // btnTildar
            // 
            this.btnTildar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTildar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnTildar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTildar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnTildar.FlatAppearance.BorderSize = 0;
            this.btnTildar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnTildar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnTildar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTildar.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnTildar.ForeColor = System.Drawing.Color.White;
            this.btnTildar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnTildar.Location = new System.Drawing.Point(1268, 227);
            this.btnTildar.Name = "btnTildar";
            this.btnTildar.Size = new System.Drawing.Size(106, 29);
            this.btnTildar.TabIndex = 261;
            this.btnTildar.Text = "Tildar";
            this.btnTildar.UseVisualStyleBackColor = false;
            this.btnTildar.Click += new System.EventHandler(this.btnTildar_Click);
            // 
            // txtBuscar
            // 
            this.txtBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBuscar.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtBuscar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBuscar.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBuscar.FocusColor = System.Drawing.Color.Empty;
            this.txtBuscar.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtBuscar.ForeColor = System.Drawing.Color.Black;
            this.txtBuscar.Location = new System.Drawing.Point(907, 227);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Numerico = false;
            this.txtBuscar.Size = new System.Drawing.Size(355, 29);
            this.txtBuscar.TabIndex = 259;
            this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);
            // 
            // dgvCortes
            // 
            this.dgvCortes.AllowUserToAddRows = false;
            this.dgvCortes.AllowUserToDeleteRows = false;
            this.dgvCortes.AllowUserToOrderColumns = true;
            this.dgvCortes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCortes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCortes.BackgroundColor = System.Drawing.Color.White;
            this.dgvCortes.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvCortes.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSlateGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI Light", 12F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCortes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCortes.ColumnHeadersHeight = 40;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Light", 12F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCortes.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvCortes.EnableHeadersVisualStyles = false;
            this.dgvCortes.GridColor = System.Drawing.Color.WhiteSmoke;
            this.dgvCortes.Location = new System.Drawing.Point(416, 270);
            this.dgvCortes.MultiSelect = false;
            this.dgvCortes.Name = "dgvCortes";
            this.dgvCortes.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI Light", 12F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCortes.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvCortes.RowHeadersVisible = false;
            this.dgvCortes.RowHeadersWidth = 50;
            this.dgvCortes.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvCortes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCortes.Size = new System.Drawing.Size(958, 248);
            this.dgvCortes.TabIndex = 254;
            this.dgvCortes.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCortes_CellEnter);
            this.dgvCortes.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvCortes_CellFormatting);
            this.dgvCortes.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvCortes_CellMouseClick);
            this.dgvCortes.CellStateChanged += new System.Windows.Forms.DataGridViewCellStateChangedEventHandler(this.dgvCortes_CellStateChanged);
            this.dgvCortes.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCortes_CellValueChanged);
            // 
            // btnPostergar
            // 
            this.btnPostergar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPostergar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnPostergar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPostergar.Enabled = false;
            this.btnPostergar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnPostergar.FlatAppearance.BorderSize = 0;
            this.btnPostergar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnPostergar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnPostergar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPostergar.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnPostergar.ForeColor = System.Drawing.Color.White;
            this.btnPostergar.Image = global::CapaPresentacion.Properties.Resources.Command_Refresh_32;
            this.btnPostergar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPostergar.Location = new System.Drawing.Point(1218, 3);
            this.btnPostergar.Name = "btnPostergar";
            this.btnPostergar.Size = new System.Drawing.Size(141, 39);
            this.btnPostergar.TabIndex = 253;
            this.btnPostergar.Text = "Postergar";
            this.btnPostergar.UseVisualStyleBackColor = false;
            this.btnPostergar.Click += new System.EventHandler(this.btnPostergar_Click);
            // 
            // dgvTipos
            // 
            this.dgvTipos.AllowUserToAddRows = false;
            this.dgvTipos.AllowUserToDeleteRows = false;
            this.dgvTipos.AllowUserToOrderColumns = true;
            this.dgvTipos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgvTipos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTipos.BackgroundColor = System.Drawing.Color.White;
            this.dgvTipos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvTipos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.LightSlateGray;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTipos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvTipos.ColumnHeadersHeight = 40;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTipos.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvTipos.EnableHeadersVisualStyles = false;
            this.dgvTipos.GridColor = System.Drawing.Color.WhiteSmoke;
            this.dgvTipos.Location = new System.Drawing.Point(15, 270);
            this.dgvTipos.MultiSelect = false;
            this.dgvTipos.Name = "dgvTipos";
            this.dgvTipos.ReadOnly = true;
            this.dgvTipos.RowHeadersVisible = false;
            this.dgvTipos.RowHeadersWidth = 50;
            this.dgvTipos.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvTipos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTipos.Size = new System.Drawing.Size(386, 248);
            this.dgvTipos.TabIndex = 4;
            this.dgvTipos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvServicios_CellClick);
            // 
            // btnAvisos
            // 
            this.btnAvisos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAvisos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnAvisos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAvisos.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnAvisos.FlatAppearance.BorderSize = 0;
            this.btnAvisos.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnAvisos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnAvisos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAvisos.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnAvisos.ForeColor = System.Drawing.Color.White;
            this.btnAvisos.Image = global::CapaPresentacion.Properties.Resources.Next_32;
            this.btnAvisos.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAvisos.Location = new System.Drawing.Point(931, 3);
            this.btnAvisos.Name = "btnAvisos";
            this.btnAvisos.Size = new System.Drawing.Size(138, 39);
            this.btnAvisos.TabIndex = 137;
            this.btnAvisos.Text = "Genera avisos";
            this.btnAvisos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAvisos.UseVisualStyleBackColor = false;
            this.btnAvisos.Click += new System.EventHandler(this.btnAvisos_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
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
            this.btnBuscar.Location = new System.Drawing.Point(1237, 134);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(137, 39);
            this.btnBuscar.TabIndex = 135;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnGenera
            // 
            this.btnGenera.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGenera.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnGenera.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGenera.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnGenera.FlatAppearance.BorderSize = 0;
            this.btnGenera.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnGenera.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnGenera.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenera.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnGenera.ForeColor = System.Drawing.Color.White;
            this.btnGenera.Image = global::CapaPresentacion.Properties.Resources.Task_03_32;
            this.btnGenera.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGenera.Location = new System.Drawing.Point(1075, 3);
            this.btnGenera.Name = "btnGenera";
            this.btnGenera.Size = new System.Drawing.Size(137, 39);
            this.btnGenera.TabIndex = 136;
            this.btnGenera.Text = "Genera cortes";
            this.btnGenera.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGenera.UseVisualStyleBackColor = false;
            this.btnGenera.Click += new System.EventHandler(this.btnGenera_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.Controls.Add(this.btnPostergar);
            this.flowLayoutPanel1.Controls.Add(this.btnGenera);
            this.flowLayoutPanel1.Controls.Add(this.btnAvisos);
            this.flowLayoutPanel1.Controls.Add(this.btnExportar);
            this.flowLayoutPanel1.Controls.Add(this.btnMapa);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(12, 78);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1362, 47);
            this.flowLayoutPanel1.TabIndex = 348;
            // 
            // btnMapa
            // 
            this.btnMapa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMapa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnMapa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMapa.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnMapa.FlatAppearance.BorderSize = 0;
            this.btnMapa.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnMapa.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnMapa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMapa.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMapa.ForeColor = System.Drawing.Color.White;
            this.btnMapa.Image = global::CapaPresentacion.Properties.Resources.Data_Add_32;
            this.btnMapa.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnMapa.Location = new System.Drawing.Point(649, 3);
            this.btnMapa.Name = "btnMapa";
            this.btnMapa.Size = new System.Drawing.Size(161, 39);
            this.btnMapa.TabIndex = 342;
            this.btnMapa.Text = "Filtrar por Mapa";
            this.btnMapa.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMapa.UseVisualStyleBackColor = true;
            this.btnMapa.Click += new System.EventHandler(this.btnMapa_Click);
            // 
            // frmCortesNuevo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(250)))), ((int)(((byte)(251)))));
            this.ClientSize = new System.Drawing.Size(1386, 554);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.spTolerancia);
            this.Controls.Add(this.lblDiasTolerancia);
            this.Controls.Add(this.btnFiltro);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cboFiltro);
            this.Controls.Add(this.cboTipoFacturacion);
            this.Controls.Add(this.btnTildar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.lblTipo);
            this.Controls.Add(this.spImporte);
            this.Controls.Add(this.lblImporte);
            this.Controls.Add(this.dgvCortes);
            this.Controls.Add(this.rbFinalizacionServicio);
            this.Controls.Add(this.rbFaltaPago);
            this.Controls.Add(this.spPeriodosAdeudados);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.dtpFecha);
            this.Controls.Add(this.dgvTipos);
            this.Controls.Add(this.pnFooter);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "frmCortesNuevo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmCortesNuevo";
            this.Load += new System.EventHandler(this.frmCortesNuevo_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmCortesNuevo_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgReturn)).EndInit();
            this.pnFooter.ResumeLayout(false);
            this.pnFooter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spPeriodosAdeudados)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spImporte)).EndInit();
            this.cmsOpciones.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spTolerancia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCortes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTipos)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Controles.dgv dgvTipos;
        private System.Windows.Forms.Label lbperiodos;
        private System.Windows.Forms.Panel panel1;
        private Controles.boton btnBuscar;
        private Controles.boton btnGenera;
        private Controles.boton btnAvisos;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox imgReturn;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel pnFooter;
        private System.Windows.Forms.Label lblTotal;
        private Controles.progress pgCircular;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.NumericUpDown spPeriodosAdeudados;
        private System.Windows.Forms.RadioButton rbFaltaPago;
        private System.Windows.Forms.RadioButton rbFinalizacionServicio;
        private Controles.boton btnPostergar;
        private Controles.dgv dgvCortes;
        private System.Windows.Forms.Label lblImporte;
        private System.Windows.Forms.NumericUpDown spImporte;
        private System.Windows.Forms.Label lblTipo;
        private textboxAdv txtBuscar;
        private System.Windows.Forms.Label label2;
        private Controles.boton btnTildar;
        private Controles.boton btnExportar;
        private System.Windows.Forms.Label lblCortes;
        private System.Windows.Forms.ContextMenuStrip cmsOpciones;
        private System.Windows.Forms.ToolStripMenuItem verCuentaCorrienteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verDatosDeContactoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem irAlUsuarioToolStripMenuItem;
        private System.Windows.Forms.Label lblAvisos;
        private System.Windows.Forms.ToolStripMenuItem verDetalleDeDeudaToolStripMenuItem;
        private Controles.combo cboTipoFacturacion;
        private Controles.combo cboFiltro;
        private System.Windows.Forms.Label label3;
        private Controles.boton btnFiltro;
        private System.Windows.Forms.NumericUpDown spTolerancia;
        private System.Windows.Forms.Label lblDiasTolerancia;
        private System.Windows.Forms.Label lblParciales;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private Controles.boton btnMapa;
    }
}