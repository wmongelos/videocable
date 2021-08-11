namespace CapaPresentacion
{
    partial class frmFacturacionMensualNuevo
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
            this.lblTituloHeader = new System.Windows.Forms.Label();
            this.imgReturn = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnPreGuardar = new CapaPresentacion.Controles.boton();
            this.btnCargar = new CapaPresentacion.Controles.boton();
            this.pnFooter = new System.Windows.Forms.Panel();
            this.lblReloj2 = new System.Windows.Forms.Label();
            this.lblReloj = new System.Windows.Forms.Label();
            this.lblCantidadPalsticos = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.pgCircular = new CapaPresentacion.Controles.progress();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lblPeriodo = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblPeriodoSeleccionado = new System.Windows.Forms.Label();
            this.lblListado = new System.Windows.Forms.Label();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pnlErrores = new System.Windows.Forms.Panel();
            this.boton1 = new CapaPresentacion.Controles.boton();
            this.dgvErrores = new CapaPresentacion.Controles.dgv(this.components);
            this.panel6 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.bgwCalcularMontos = new System.ComponentModel.BackgroundWorker();
            this.pbProgreso = new System.Windows.Forms.ProgressBar();
            this.bgwGenerarDeudas = new System.ComponentModel.BackgroundWorker();
            this.bgwFiltrarGrilla = new System.ComponentModel.BackgroundWorker();
            this.lblProgreso = new System.Windows.Forms.Label();
            this.lblmonto = new System.Windows.Forms.Label();
            this.lblMontoTotal = new System.Windows.Forms.Label();
            this.lblTotalAnexado = new System.Windows.Forms.Label();
            this.lblAnexado = new System.Windows.Forms.Label();
            this.olvDeudas = new BrightIdeasSoftware.ObjectListView();
            this.colCodigo = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colResp = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colUsuario = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colTipofac = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colLocacion = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colPlastico = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colImporte = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colBonif = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colImporteProvincial = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colAnex = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colTotal = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.cmsOpciones = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.verDetallesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verCuentaCorrienteDelUsuarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlDetalles = new System.Windows.Forms.Panel();
            this.lblUsuarioDetalles = new System.Windows.Forms.Label();
            this.dgvDetalles = new CapaPresentacion.Controles.dgv(this.components);
            this.btnCerrar = new CapaPresentacion.Controles.boton();
            this.pnlTituloDetalle = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.lblDetalles = new System.Windows.Forms.Label();
            this.lblTotalTotal = new System.Windows.Forms.Label();
            this.lblMontoTotalTotal = new System.Windows.Forms.Label();
            this.bgwReCalcularSaldos = new System.ComponentModel.BackgroundWorker();
            this.btnExportarPdf = new CapaPresentacion.Controles.boton();
            this.spnCantidad = new CapaPresentacion.Controles.spinner(this.components);
            this.btnGenerarArchivo = new CapaPresentacion.Controles.boton();
            this.btnListadoErrores = new CapaPresentacion.Controles.boton();
            this.txtBuscar = new CapaPresentacion.textboxAdv();
            this.btnFacturacion = new CapaPresentacion.Controles.boton();
            this.btnBuscar = new CapaPresentacion.Controles.boton();
            this.btnPagosExternos = new CapaPresentacion.Controles.boton();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.imgReturn)).BeginInit();
            this.panel1.SuspendLayout();
            this.pnFooter.SuspendLayout();
            this.pnlErrores.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvErrores)).BeginInit();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.olvDeudas)).BeginInit();
            this.cmsOpciones.SuspendLayout();
            this.pnlDetalles.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalles)).BeginInit();
            this.pnlTituloDetalle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spnCantidad)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTituloHeader
            // 
            this.lblTituloHeader.Font = new System.Drawing.Font("Segoe UI Light", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloHeader.ForeColor = System.Drawing.Color.White;
            this.lblTituloHeader.Location = new System.Drawing.Point(51, 31);
            this.lblTituloHeader.Name = "lblTituloHeader";
            this.lblTituloHeader.Size = new System.Drawing.Size(556, 27);
            this.lblTituloHeader.TabIndex = 208;
            this.lblTituloHeader.Text = "Facturación mensual";
            // 
            // imgReturn
            // 
            this.imgReturn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.imgReturn.Image = global::CapaPresentacion.Properties.Resources.Left_Arrow_32;
            this.imgReturn.Location = new System.Drawing.Point(13, 26);
            this.imgReturn.Name = "imgReturn";
            this.imgReturn.Size = new System.Drawing.Size(32, 32);
            this.imgReturn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgReturn.TabIndex = 209;
            this.imgReturn.TabStop = false;
            this.imgReturn.Click += new System.EventHandler(this.imgReturn_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.panel1.Controls.Add(this.imgReturn);
            this.panel1.Controls.Add(this.lblTituloHeader);
            this.panel1.Controls.Add(this.btnPreGuardar);
            this.panel1.Controls.Add(this.btnCargar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1351, 87);
            this.panel1.TabIndex = 272;
            // 
            // btnPreGuardar
            // 
            this.btnPreGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPreGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnPreGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPreGuardar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnPreGuardar.FlatAppearance.BorderSize = 0;
            this.btnPreGuardar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnPreGuardar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnPreGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPreGuardar.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnPreGuardar.ForeColor = System.Drawing.Color.White;
            this.btnPreGuardar.Image = global::CapaPresentacion.Properties.Resources.Next_32;
            this.btnPreGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPreGuardar.Location = new System.Drawing.Point(1146, 25);
            this.btnPreGuardar.Name = "btnPreGuardar";
            this.btnPreGuardar.Size = new System.Drawing.Size(192, 39);
            this.btnPreGuardar.TabIndex = 347;
            this.btnPreGuardar.Text = "Exportar Predeudas";
            this.btnPreGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPreGuardar.UseVisualStyleBackColor = false;
            this.btnPreGuardar.Visible = false;
            this.btnPreGuardar.Click += new System.EventHandler(this.btnPreGuardar_Click);
            // 
            // btnCargar
            // 
            this.btnCargar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCargar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnCargar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCargar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnCargar.FlatAppearance.BorderSize = 0;
            this.btnCargar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnCargar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnCargar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCargar.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnCargar.ForeColor = System.Drawing.Color.White;
            this.btnCargar.Image = global::CapaPresentacion.Properties.Resources.Next_32;
            this.btnCargar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCargar.Location = new System.Drawing.Point(966, 25);
            this.btnCargar.Name = "btnCargar";
            this.btnCargar.Size = new System.Drawing.Size(174, 39);
            this.btnCargar.TabIndex = 348;
            this.btnCargar.Text = "Cargar Predeudas";
            this.btnCargar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCargar.UseVisualStyleBackColor = false;
            this.btnCargar.Visible = false;
            this.btnCargar.Click += new System.EventHandler(this.btnCargar_Click);
            // 
            // pnFooter
            // 
            this.pnFooter.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnFooter.Controls.Add(this.lblReloj2);
            this.pnFooter.Controls.Add(this.lblReloj);
            this.pnFooter.Controls.Add(this.lblCantidadPalsticos);
            this.pnFooter.Controls.Add(this.lblTotal);
            this.pnFooter.Controls.Add(this.pgCircular);
            this.pnFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnFooter.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.pnFooter.Location = new System.Drawing.Point(0, 612);
            this.pnFooter.Name = "pnFooter";
            this.pnFooter.Size = new System.Drawing.Size(1351, 30);
            this.pnFooter.TabIndex = 273;
            // 
            // lblReloj2
            // 
            this.lblReloj2.AutoSize = true;
            this.lblReloj2.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblReloj2.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.lblReloj2.ForeColor = System.Drawing.Color.SlateGray;
            this.lblReloj2.Location = new System.Drawing.Point(498, 0);
            this.lblReloj2.Name = "lblReloj2";
            this.lblReloj2.Size = new System.Drawing.Size(145, 25);
            this.lblReloj2.TabIndex = 16;
            this.lblReloj2.Text = "Tiempo etapa 2: ";
            this.lblReloj2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblReloj
            // 
            this.lblReloj.AutoSize = true;
            this.lblReloj.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblReloj.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.lblReloj.ForeColor = System.Drawing.Color.SlateGray;
            this.lblReloj.Location = new System.Drawing.Point(353, 0);
            this.lblReloj.Name = "lblReloj";
            this.lblReloj.Size = new System.Drawing.Size(145, 25);
            this.lblReloj.TabIndex = 15;
            this.lblReloj.Text = "Tiempo etapa 1: ";
            this.lblReloj.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCantidadPalsticos
            // 
            this.lblCantidadPalsticos.AutoSize = true;
            this.lblCantidadPalsticos.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblCantidadPalsticos.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.lblCantidadPalsticos.ForeColor = System.Drawing.Color.SlateGray;
            this.lblCantidadPalsticos.Location = new System.Drawing.Point(171, 0);
            this.lblCantidadPalsticos.Name = "lblCantidadPalsticos";
            this.lblCantidadPalsticos.Size = new System.Drawing.Size(182, 25);
            this.lblCantidadPalsticos.TabIndex = 14;
            this.lblCantidadPalsticos.Text = "Cantidad de plasticos";
            this.lblCantidadPalsticos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.lblTotal.ForeColor = System.Drawing.Color.SlateGray;
            this.lblTotal.Location = new System.Drawing.Point(0, 0);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(171, 25);
            this.lblTotal.TabIndex = 13;
            this.lblTotal.Text = "Total de Registros: 0";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pgCircular
            // 
            this.pgCircular.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pgCircular.Location = new System.Drawing.Point(1315, 2);
            this.pgCircular.Name = "pgCircular";
            this.pgCircular.Percentage = 0F;
            this.pgCircular.Rotation = CapaPresentacion.Controles.RotationType.CounterClockwise;
            this.pgCircular.Size = new System.Drawing.Size(24, 24);
            this.pgCircular.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.BackColor = System.Drawing.Color.Gainsboro;
            this.panel4.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.panel4.Location = new System.Drawing.Point(0, 185);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1386, 1);
            this.panel4.TabIndex = 313;
            // 
            // lblPeriodo
            // 
            this.lblPeriodo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPeriodo.AutoSize = true;
            this.lblPeriodo.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblPeriodo.Location = new System.Drawing.Point(975, 156);
            this.lblPeriodo.Name = "lblPeriodo";
            this.lblPeriodo.Size = new System.Drawing.Size(66, 21);
            this.lblPeriodo.TabIndex = 316;
            this.lblPeriodo.Text = "Periodo:";
            // 
            // dtpFecha
            // 
            this.dtpFecha.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpFecha.CustomFormat = "MMMM yyyy";
            this.dtpFecha.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFecha.Location = new System.Drawing.Point(1048, 150);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(176, 29);
            this.dtpFecha.TabIndex = 315;
            this.dtpFecha.Value = new System.DateTime(2020, 3, 16, 16, 2, 0, 0);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.Gainsboro;
            this.panel2.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.panel2.Location = new System.Drawing.Point(0, 137);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1386, 1);
            this.panel2.TabIndex = 314;
            // 
            // lblPeriodoSeleccionado
            // 
            this.lblPeriodoSeleccionado.AutoSize = true;
            this.lblPeriodoSeleccionado.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblPeriodoSeleccionado.Location = new System.Drawing.Point(9, 156);
            this.lblPeriodoSeleccionado.Name = "lblPeriodoSeleccionado";
            this.lblPeriodoSeleccionado.Size = new System.Drawing.Size(159, 21);
            this.lblPeriodoSeleccionado.TabIndex = 318;
            this.lblPeriodoSeleccionado.Text = "Periodo seleccionado:";
            // 
            // lblListado
            // 
            this.lblListado.AutoSize = true;
            this.lblListado.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblListado.Location = new System.Drawing.Point(12, 196);
            this.lblListado.Name = "lblListado";
            this.lblListado.Size = new System.Drawing.Size(63, 21);
            this.lblListado.TabIndex = 319;
            this.lblListado.Text = "Listado:";
            // 
            // lblBuscar
            // 
            this.lblBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBuscar.AutoSize = true;
            this.lblBuscar.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblBuscar.ForeColor = System.Drawing.Color.Black;
            this.lblBuscar.Location = new System.Drawing.Point(856, 196);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Size = new System.Drawing.Size(130, 21);
            this.lblBuscar.TabIndex = 321;
            this.lblBuscar.Text = "Buscar en listado:";
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackColor = System.Drawing.Color.Gainsboro;
            this.panel3.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.panel3.Location = new System.Drawing.Point(0, 227);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1386, 1);
            this.panel3.TabIndex = 314;
            // 
            // pnlErrores
            // 
            this.pnlErrores.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlErrores.Controls.Add(this.boton1);
            this.pnlErrores.Controls.Add(this.dgvErrores);
            this.pnlErrores.Controls.Add(this.panel6);
            this.pnlErrores.Location = new System.Drawing.Point(604, 273);
            this.pnlErrores.Name = "pnlErrores";
            this.pnlErrores.Size = new System.Drawing.Size(640, 202);
            this.pnlErrores.TabIndex = 328;
            this.pnlErrores.Visible = false;
            // 
            // boton1
            // 
            this.boton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.boton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.boton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.boton1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.boton1.FlatAppearance.BorderSize = 0;
            this.boton1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.boton1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.boton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.boton1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.boton1.ForeColor = System.Drawing.Color.White;
            this.boton1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.boton1.Location = new System.Drawing.Point(466, 157);
            this.boton1.Margin = new System.Windows.Forms.Padding(2);
            this.boton1.Name = "boton1";
            this.boton1.Size = new System.Drawing.Size(156, 30);
            this.boton1.TabIndex = 329;
            this.boton1.Text = "Exportar a Excel";
            this.boton1.UseVisualStyleBackColor = false;
            this.boton1.Click += new System.EventHandler(this.boton1_Click);
            // 
            // dgvErrores
            // 
            this.dgvErrores.AllowUserToAddRows = false;
            this.dgvErrores.AllowUserToDeleteRows = false;
            this.dgvErrores.AllowUserToOrderColumns = true;
            this.dgvErrores.AllowUserToResizeColumns = false;
            this.dgvErrores.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvErrores.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvErrores.BackgroundColor = System.Drawing.Color.White;
            this.dgvErrores.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvErrores.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.LightSlateGray;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvErrores.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvErrores.ColumnHeadersHeight = 40;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvErrores.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvErrores.EnableHeadersVisualStyles = false;
            this.dgvErrores.GridColor = System.Drawing.Color.WhiteSmoke;
            this.dgvErrores.Location = new System.Drawing.Point(14, 75);
            this.dgvErrores.MultiSelect = false;
            this.dgvErrores.Name = "dgvErrores";
            this.dgvErrores.ReadOnly = true;
            this.dgvErrores.RowHeadersVisible = false;
            this.dgvErrores.RowHeadersWidth = 50;
            this.dgvErrores.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvErrores.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvErrores.Size = new System.Drawing.Size(608, 77);
            this.dgvErrores.TabIndex = 313;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.panel6.Controls.Add(this.pictureBox1);
            this.panel6.Controls.Add(this.label1);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(638, 59);
            this.panel6.TabIndex = 273;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = global::CapaPresentacion.Properties.Resources.Left_Arrow_32;
            this.pictureBox1.Location = new System.Drawing.Point(14, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 209;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI Light", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(52, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(181, 27);
            this.label1.TabIndex = 208;
            this.label1.Text = "Errores producidos durante prefacturación";
            // 
            // bgwCalcularMontos
            // 
            this.bgwCalcularMontos.WorkerReportsProgress = true;
            this.bgwCalcularMontos.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgwCalcularMontos_ProgressChanged);
            this.bgwCalcularMontos.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwCalcularMontos_RunWorkerCompleted);
            // 
            // pbProgreso
            // 
            this.pbProgreso.Location = new System.Drawing.Point(12, 108);
            this.pbProgreso.Name = "pbProgreso";
            this.pbProgreso.Size = new System.Drawing.Size(295, 23);
            this.pbProgreso.TabIndex = 329;
            this.pbProgreso.Visible = false;
            // 
            // bgwGenerarDeudas
            // 
            this.bgwGenerarDeudas.WorkerReportsProgress = true;
            this.bgwGenerarDeudas.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgwGenerarDeudas_ProgressChanged);
            this.bgwGenerarDeudas.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwGenerarDeudas_RunWorkerCompleted);
            // 
            // bgwFiltrarGrilla
            // 
            this.bgwFiltrarGrilla.WorkerReportsProgress = true;
            // 
            // lblProgreso
            // 
            this.lblProgreso.AutoSize = true;
            this.lblProgreso.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblProgreso.Location = new System.Drawing.Point(313, 110);
            this.lblProgreso.Name = "lblProgreso";
            this.lblProgreso.Size = new System.Drawing.Size(73, 21);
            this.lblProgreso.TabIndex = 330;
            this.lblProgreso.Text = "Progreso";
            this.lblProgreso.Visible = false;
            // 
            // lblmonto
            // 
            this.lblmonto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblmonto.AutoSize = true;
            this.lblmonto.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblmonto.ForeColor = System.Drawing.Color.Black;
            this.lblmonto.Location = new System.Drawing.Point(792, 584);
            this.lblmonto.Name = "lblmonto";
            this.lblmonto.Size = new System.Drawing.Size(108, 21);
            this.lblmonto.TabIndex = 331;
            this.lblmonto.Text = "Total mensual:";
            // 
            // lblMontoTotal
            // 
            this.lblMontoTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMontoTotal.AutoSize = true;
            this.lblMontoTotal.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblMontoTotal.ForeColor = System.Drawing.Color.Black;
            this.lblMontoTotal.Location = new System.Drawing.Point(905, 584);
            this.lblMontoTotal.Name = "lblMontoTotal";
            this.lblMontoTotal.Size = new System.Drawing.Size(19, 21);
            this.lblMontoTotal.TabIndex = 332;
            this.lblMontoTotal.Text = "0";
            this.lblMontoTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTotalAnexado
            // 
            this.lblTotalAnexado.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalAnexado.AutoSize = true;
            this.lblTotalAnexado.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblTotalAnexado.ForeColor = System.Drawing.Color.Black;
            this.lblTotalAnexado.Location = new System.Drawing.Point(756, 584);
            this.lblTotalAnexado.Name = "lblTotalAnexado";
            this.lblTotalAnexado.Size = new System.Drawing.Size(19, 21);
            this.lblTotalAnexado.TabIndex = 338;
            this.lblTotalAnexado.Text = "0";
            this.lblTotalAnexado.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblAnexado
            // 
            this.lblAnexado.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAnexado.AutoSize = true;
            this.lblAnexado.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblAnexado.ForeColor = System.Drawing.Color.Black;
            this.lblAnexado.Location = new System.Drawing.Point(601, 584);
            this.lblAnexado.Name = "lblAnexado";
            this.lblAnexado.Size = new System.Drawing.Size(107, 21);
            this.lblAnexado.TabIndex = 337;
            this.lblAnexado.Text = "Total anexado:";
            // 
            // olvDeudas
            // 
            this.olvDeudas.AllColumns.Add(this.colCodigo);
            this.olvDeudas.AllColumns.Add(this.colResp);
            this.olvDeudas.AllColumns.Add(this.colUsuario);
            this.olvDeudas.AllColumns.Add(this.colTipofac);
            this.olvDeudas.AllColumns.Add(this.colLocacion);
            this.olvDeudas.AllColumns.Add(this.colPlastico);
            this.olvDeudas.AllColumns.Add(this.colImporte);
            this.olvDeudas.AllColumns.Add(this.colBonif);
            this.olvDeudas.AllColumns.Add(this.colImporteProvincial);
            this.olvDeudas.AllColumns.Add(this.colAnex);
            this.olvDeudas.AllColumns.Add(this.colTotal);
            this.olvDeudas.AllowColumnReorder = true;
            this.olvDeudas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.olvDeudas.CellEditUseWholeCell = false;
            this.olvDeudas.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colCodigo,
            this.colResp,
            this.colUsuario,
            this.colTipofac,
            this.colLocacion,
            this.colPlastico,
            this.colImporte,
            this.colBonif,
            this.colImporteProvincial,
            this.colAnex,
            this.colTotal});
            this.olvDeudas.Cursor = System.Windows.Forms.Cursors.Default;
            this.olvDeudas.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.olvDeudas.FullRowSelect = true;
            this.olvDeudas.HasCollapsibleGroups = false;
            this.olvDeudas.HideSelection = false;
            this.olvDeudas.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.olvDeudas.Location = new System.Drawing.Point(5, 234);
            this.olvDeudas.MultiSelect = false;
            this.olvDeudas.Name = "olvDeudas";
            this.olvDeudas.ShowGroups = false;
            this.olvDeudas.Size = new System.Drawing.Size(1334, 340);
            this.olvDeudas.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.olvDeudas.TabIndex = 344;
            this.olvDeudas.UseCompatibleStateImageBehavior = false;
            this.olvDeudas.UseFiltering = true;
            this.olvDeudas.View = System.Windows.Forms.View.Details;
            this.olvDeudas.SelectedIndexChanged += new System.EventHandler(this.olvDeudas_SelectedIndexChanged);
            this.olvDeudas.MouseClick += new System.Windows.Forms.MouseEventHandler(this.olvDeudas_MouseClick);
            // 
            // colCodigo
            // 
            this.colCodigo.AspectName = "CodigoUsuario";
            this.colCodigo.Text = "Codigo";
            // 
            // colResp
            // 
            this.colResp.AspectName = "Responsable";
            this.colResp.Text = "Tipo";
            this.colResp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // colUsuario
            // 
            this.colUsuario.AspectName = "Usuario";
            this.colUsuario.Text = "Usuario";
            this.colUsuario.Width = 130;
            // 
            // colTipofac
            // 
            this.colTipofac.AspectName = "Categoria";
            this.colTipofac.Text = "Tipo Facturacion";
            this.colTipofac.Width = 121;
            // 
            // colLocacion
            // 
            this.colLocacion.AspectName = "Locacion";
            this.colLocacion.Text = "Locacion";
            this.colLocacion.Width = 140;
            // 
            // colPlastico
            // 
            this.colPlastico.AspectName = "NumeroPlastico";
            this.colPlastico.Text = "Tarjeta";
            this.colPlastico.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colPlastico.Width = 146;
            // 
            // colImporte
            // 
            this.colImporte.AspectName = "ImporteOriginal";
            this.colImporte.AspectToStringFormat = "{0:C}";
            this.colImporte.Text = "Importe";
            this.colImporte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colImporte.Width = 110;
            // 
            // colBonif
            // 
            this.colBonif.AspectName = "ImporteBonificacion";
            this.colBonif.AspectToStringFormat = "{0:C}";
            this.colBonif.Text = "Importe Bonificacion";
            this.colBonif.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colBonif.Width = 141;
            // 
            // colImporteProvincial
            // 
            this.colImporteProvincial.AspectName = "ImporteProvincial";
            this.colImporteProvincial.AspectToStringFormat = "{0:C}";
            this.colImporteProvincial.Text = "Importe Provincial";
            this.colImporteProvincial.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colImporteProvincial.Width = 146;
            // 
            // colAnex
            // 
            this.colAnex.AspectName = "ImporteAnexado";
            this.colAnex.AspectToStringFormat = "{0:C}";
            this.colAnex.Text = "Importe Anexado";
            this.colAnex.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colAnex.Width = 136;
            // 
            // colTotal
            // 
            this.colTotal.AspectName = "ImporteTotal";
            this.colTotal.AspectToStringFormat = "{0:C}";
            this.colTotal.Text = "Importe Total";
            this.colTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colTotal.Width = 128;
            // 
            // cmsOpciones
            // 
            this.cmsOpciones.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.verDetallesToolStripMenuItem,
            this.verCuentaCorrienteDelUsuarioToolStripMenuItem});
            this.cmsOpciones.Name = "cmsOpciones";
            this.cmsOpciones.Size = new System.Drawing.Size(241, 48);
            // 
            // verDetallesToolStripMenuItem
            // 
            this.verDetallesToolStripMenuItem.Name = "verDetallesToolStripMenuItem";
            this.verDetallesToolStripMenuItem.Size = new System.Drawing.Size(240, 22);
            this.verDetallesToolStripMenuItem.Text = "Ver detalles";
            this.verDetallesToolStripMenuItem.Click += new System.EventHandler(this.verDetallesToolStripMenuItem_Click);
            // 
            // verCuentaCorrienteDelUsuarioToolStripMenuItem
            // 
            this.verCuentaCorrienteDelUsuarioToolStripMenuItem.Name = "verCuentaCorrienteDelUsuarioToolStripMenuItem";
            this.verCuentaCorrienteDelUsuarioToolStripMenuItem.Size = new System.Drawing.Size(240, 22);
            this.verCuentaCorrienteDelUsuarioToolStripMenuItem.Text = "Ver cuenta corriente del usuario";
            this.verCuentaCorrienteDelUsuarioToolStripMenuItem.Click += new System.EventHandler(this.verCuentaCorrienteDelUsuarioToolStripMenuItem_Click);
            // 
            // pnlDetalles
            // 
            this.pnlDetalles.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDetalles.Controls.Add(this.lblUsuarioDetalles);
            this.pnlDetalles.Controls.Add(this.dgvDetalles);
            this.pnlDetalles.Controls.Add(this.btnCerrar);
            this.pnlDetalles.Controls.Add(this.pnlTituloDetalle);
            this.pnlDetalles.Location = new System.Drawing.Point(16, 273);
            this.pnlDetalles.Name = "pnlDetalles";
            this.pnlDetalles.Size = new System.Drawing.Size(582, 202);
            this.pnlDetalles.TabIndex = 346;
            this.pnlDetalles.Visible = false;
            // 
            // lblUsuarioDetalles
            // 
            this.lblUsuarioDetalles.AutoSize = true;
            this.lblUsuarioDetalles.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblUsuarioDetalles.Location = new System.Drawing.Point(10, 64);
            this.lblUsuarioDetalles.Name = "lblUsuarioDetalles";
            this.lblUsuarioDetalles.Size = new System.Drawing.Size(63, 21);
            this.lblUsuarioDetalles.TabIndex = 330;
            this.lblUsuarioDetalles.Text = "Listado:";
            // 
            // dgvDetalles
            // 
            this.dgvDetalles.AllowUserToAddRows = false;
            this.dgvDetalles.AllowUserToDeleteRows = false;
            this.dgvDetalles.AllowUserToOrderColumns = true;
            this.dgvDetalles.AllowUserToResizeColumns = false;
            this.dgvDetalles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDetalles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDetalles.BackgroundColor = System.Drawing.Color.White;
            this.dgvDetalles.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDetalles.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.LightSlateGray;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDetalles.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvDetalles.ColumnHeadersHeight = 40;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDetalles.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgvDetalles.EnableHeadersVisualStyles = false;
            this.dgvDetalles.GridColor = System.Drawing.Color.White;
            this.dgvDetalles.Location = new System.Drawing.Point(14, 95);
            this.dgvDetalles.MultiSelect = false;
            this.dgvDetalles.Name = "dgvDetalles";
            this.dgvDetalles.ReadOnly = true;
            this.dgvDetalles.RowHeadersVisible = false;
            this.dgvDetalles.RowHeadersWidth = 50;
            this.dgvDetalles.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvDetalles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetalles.Size = new System.Drawing.Size(550, 68);
            this.dgvDetalles.TabIndex = 313;
            // 
            // btnCerrar
            // 
            this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCerrar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnCerrar.FlatAppearance.BorderSize = 0;
            this.btnCerrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnCerrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnCerrar.ForeColor = System.Drawing.Color.White;
            this.btnCerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCerrar.Location = new System.Drawing.Point(465, 168);
            this.btnCerrar.Margin = new System.Windows.Forms.Padding(2);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(99, 30);
            this.btnCerrar.TabIndex = 329;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // pnlTituloDetalle
            // 
            this.pnlTituloDetalle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.pnlTituloDetalle.Controls.Add(this.pictureBox2);
            this.pnlTituloDetalle.Controls.Add(this.lblDetalles);
            this.pnlTituloDetalle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTituloDetalle.Location = new System.Drawing.Point(0, 0);
            this.pnlTituloDetalle.Name = "pnlTituloDetalle";
            this.pnlTituloDetalle.Size = new System.Drawing.Size(580, 59);
            this.pnlTituloDetalle.TabIndex = 273;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox2.Image = global::CapaPresentacion.Properties.Resources.Left_Arrow_32;
            this.pictureBox2.Location = new System.Drawing.Point(14, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(32, 32);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 209;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // lblDetalles
            // 
            this.lblDetalles.Font = new System.Drawing.Font("Segoe UI Light", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetalles.ForeColor = System.Drawing.Color.White;
            this.lblDetalles.Location = new System.Drawing.Point(52, 17);
            this.lblDetalles.Name = "lblDetalles";
            this.lblDetalles.Size = new System.Drawing.Size(181, 27);
            this.lblDetalles.TabIndex = 208;
            this.lblDetalles.Text = "Detalles";
            // 
            // lblTotalTotal
            // 
            this.lblTotalTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalTotal.AutoSize = true;
            this.lblTotalTotal.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblTotalTotal.ForeColor = System.Drawing.Color.Black;
            this.lblTotalTotal.Location = new System.Drawing.Point(988, 584);
            this.lblTotalTotal.Name = "lblTotalTotal";
            this.lblTotalTotal.Size = new System.Drawing.Size(45, 21);
            this.lblTotalTotal.TabIndex = 349;
            this.lblTotalTotal.Text = "Total:";
            // 
            // lblMontoTotalTotal
            // 
            this.lblMontoTotalTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMontoTotalTotal.AutoSize = true;
            this.lblMontoTotalTotal.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblMontoTotalTotal.ForeColor = System.Drawing.Color.Black;
            this.lblMontoTotalTotal.Location = new System.Drawing.Point(1039, 584);
            this.lblMontoTotalTotal.Name = "lblMontoTotalTotal";
            this.lblMontoTotalTotal.Size = new System.Drawing.Size(19, 21);
            this.lblMontoTotalTotal.TabIndex = 350;
            this.lblMontoTotalTotal.Text = "0";
            this.lblMontoTotalTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnExportarPdf
            // 
            this.btnExportarPdf.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportarPdf.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnExportarPdf.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExportarPdf.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnExportarPdf.FlatAppearance.BorderSize = 0;
            this.btnExportarPdf.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnExportarPdf.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnExportarPdf.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportarPdf.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnExportarPdf.ForeColor = System.Drawing.Color.White;
            this.btnExportarPdf.Image = global::CapaPresentacion.Properties.Resources.Next_32;
            this.btnExportarPdf.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExportarPdf.Location = new System.Drawing.Point(9, 3);
            this.btnExportarPdf.Name = "btnExportarPdf";
            this.btnExportarPdf.Size = new System.Drawing.Size(155, 39);
            this.btnExportarPdf.TabIndex = 340;
            this.btnExportarPdf.Text = "Exportar listado";
            this.btnExportarPdf.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExportarPdf.UseVisualStyleBackColor = false;
            this.btnExportarPdf.Click += new System.EventHandler(this.btnExportarPdf_Click);
            // 
            // spnCantidad
            // 
            this.spnCantidad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.spnCantidad.BorderColor = System.Drawing.Color.Empty;
            this.spnCantidad.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spnCantidad.Location = new System.Drawing.Point(886, 150);
            this.spnCantidad.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.spnCantidad.Name = "spnCantidad";
            this.spnCantidad.Size = new System.Drawing.Size(83, 29);
            this.spnCantidad.TabIndex = 339;
            this.spnCantidad.Visible = false;
            // 
            // btnGenerarArchivo
            // 
            this.btnGenerarArchivo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGenerarArchivo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnGenerarArchivo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGenerarArchivo.Enabled = false;
            this.btnGenerarArchivo.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnGenerarArchivo.FlatAppearance.BorderSize = 0;
            this.btnGenerarArchivo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnGenerarArchivo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnGenerarArchivo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerarArchivo.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnGenerarArchivo.ForeColor = System.Drawing.Color.White;
            this.btnGenerarArchivo.Image = global::CapaPresentacion.Properties.Resources.Next_32;
            this.btnGenerarArchivo.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGenerarArchivo.Location = new System.Drawing.Point(331, 3);
            this.btnGenerarArchivo.Name = "btnGenerarArchivo";
            this.btnGenerarArchivo.Size = new System.Drawing.Size(155, 39);
            this.btnGenerarArchivo.TabIndex = 333;
            this.btnGenerarArchivo.Text = "Generar archivo";
            this.btnGenerarArchivo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGenerarArchivo.UseVisualStyleBackColor = false;
            this.btnGenerarArchivo.Click += new System.EventHandler(this.boton2_Click_1);
            // 
            // btnListadoErrores
            // 
            this.btnListadoErrores.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnListadoErrores.BackColor = System.Drawing.Color.Red;
            this.btnListadoErrores.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnListadoErrores.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnListadoErrores.FlatAppearance.BorderSize = 0;
            this.btnListadoErrores.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnListadoErrores.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnListadoErrores.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnListadoErrores.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnListadoErrores.ForeColor = System.Drawing.Color.White;
            this.btnListadoErrores.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnListadoErrores.Location = new System.Drawing.Point(12, 579);
            this.btnListadoErrores.Margin = new System.Windows.Forms.Padding(2);
            this.btnListadoErrores.Name = "btnListadoErrores";
            this.btnListadoErrores.Size = new System.Drawing.Size(193, 30);
            this.btnListadoErrores.TabIndex = 327;
            this.btnListadoErrores.Text = "Listado de errores";
            this.btnListadoErrores.UseVisualStyleBackColor = false;
            this.btnListadoErrores.Click += new System.EventHandler(this.btnListadoErrores_Click);
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
            this.txtBuscar.Location = new System.Drawing.Point(992, 192);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Numerico = false;
            this.txtBuscar.Size = new System.Drawing.Size(347, 29);
            this.txtBuscar.TabIndex = 320;
            this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);
            // 
            // btnFacturacion
            // 
            this.btnFacturacion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFacturacion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnFacturacion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFacturacion.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnFacturacion.FlatAppearance.BorderSize = 0;
            this.btnFacturacion.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnFacturacion.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnFacturacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFacturacion.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnFacturacion.ForeColor = System.Drawing.Color.White;
            this.btnFacturacion.Image = global::CapaPresentacion.Properties.Resources.Next_32;
            this.btnFacturacion.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFacturacion.Location = new System.Drawing.Point(170, 3);
            this.btnFacturacion.Name = "btnFacturacion";
            this.btnFacturacion.Size = new System.Drawing.Size(155, 39);
            this.btnFacturacion.TabIndex = 317;
            this.btnFacturacion.Text = "Generar deudas";
            this.btnFacturacion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFacturacion.UseVisualStyleBackColor = false;
            this.btnFacturacion.Click += new System.EventHandler(this.btnFacturacion_Click);
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
            this.btnBuscar.Location = new System.Drawing.Point(1230, 140);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(109, 39);
            this.btnBuscar.TabIndex = 314;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.BtnBuscar_Click);
            // 
            // btnPagosExternos
            // 
            this.btnPagosExternos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPagosExternos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnPagosExternos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPagosExternos.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnPagosExternos.FlatAppearance.BorderSize = 0;
            this.btnPagosExternos.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnPagosExternos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnPagosExternos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPagosExternos.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnPagosExternos.ForeColor = System.Drawing.Color.White;
            this.btnPagosExternos.Image = global::CapaPresentacion.Properties.Resources.Next_32;
            this.btnPagosExternos.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPagosExternos.Location = new System.Drawing.Point(492, 3);
            this.btnPagosExternos.Name = "btnPagosExternos";
            this.btnPagosExternos.Size = new System.Drawing.Size(225, 39);
            this.btnPagosExternos.TabIndex = 351;
            this.btnPagosExternos.Text = "Generar botones de pago";
            this.btnPagosExternos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPagosExternos.UseVisualStyleBackColor = false;
            this.btnPagosExternos.Visible = false;
            this.btnPagosExternos.Click += new System.EventHandler(this.btnPagosExternos_ClickAsync);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnPagosExternos);
            this.flowLayoutPanel1.Controls.Add(this.btnGenerarArchivo);
            this.flowLayoutPanel1.Controls.Add(this.btnFacturacion);
            this.flowLayoutPanel1.Controls.Add(this.btnExportarPdf);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(619, 93);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(720, 42);
            this.flowLayoutPanel1.TabIndex = 352;
            // 
            // frmFacturacionMensualNuevo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(250)))), ((int)(((byte)(251)))));
            this.ClientSize = new System.Drawing.Size(1351, 642);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.lblMontoTotalTotal);
            this.Controls.Add(this.lblTotalTotal);
            this.Controls.Add(this.pnlDetalles);
            this.Controls.Add(this.spnCantidad);
            this.Controls.Add(this.lblTotalAnexado);
            this.Controls.Add(this.lblAnexado);
            this.Controls.Add(this.lblMontoTotal);
            this.Controls.Add(this.lblmonto);
            this.Controls.Add(this.lblProgreso);
            this.Controls.Add(this.pbProgreso);
            this.Controls.Add(this.pnlErrores);
            this.Controls.Add(this.btnListadoErrores);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.lblBuscar);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.lblListado);
            this.Controls.Add(this.lblPeriodoSeleccionado);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.lblPeriodo);
            this.Controls.Add(this.dtpFecha);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.pnFooter);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.olvDeudas);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "frmFacturacionMensualNuevo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmFacturacionMensual";
            this.Load += new System.EventHandler(this.FrmFacturacionMensual_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmFacturacionMensual_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.imgReturn)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnFooter.ResumeLayout(false);
            this.pnFooter.PerformLayout();
            this.pnlErrores.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvErrores)).EndInit();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.olvDeudas)).EndInit();
            this.cmsOpciones.ResumeLayout(false);
            this.pnlDetalles.ResumeLayout(false);
            this.pnlDetalles.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalles)).EndInit();
            this.pnlTituloDetalle.ResumeLayout(false);
            this.pnlTituloDetalle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spnCantidad)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTituloHeader;
        private System.Windows.Forms.PictureBox imgReturn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pnFooter;
        private System.Windows.Forms.Label lblTotal;
        private Controles.progress pgCircular;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label lblPeriodo;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private Controles.boton btnBuscar;
        private System.Windows.Forms.Panel panel2;
        private Controles.boton btnFacturacion;
        private System.Windows.Forms.Label lblPeriodoSeleccionado;
        private System.Windows.Forms.Label lblListado;
        private System.Windows.Forms.Label lblBuscar;
        private textboxAdv txtBuscar;
        private System.Windows.Forms.Panel panel3;
        private Controles.boton btnListadoErrores;
        private System.Windows.Forms.Panel pnlErrores;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private Controles.dgv dgvErrores;
        private Controles.boton boton1;
        private System.ComponentModel.BackgroundWorker bgwCalcularMontos;
        private System.Windows.Forms.ProgressBar pbProgreso;
        private System.ComponentModel.BackgroundWorker bgwGenerarDeudas;
        private System.ComponentModel.BackgroundWorker bgwFiltrarGrilla;
        private System.Windows.Forms.Label lblProgreso;
        private System.Windows.Forms.Label lblmonto;
        private System.Windows.Forms.Label lblMontoTotal;
        private System.Windows.Forms.Label lblCantidadPalsticos;
        private Controles.boton btnGenerarArchivo;
        private System.Windows.Forms.Label lblTotalAnexado;
        private System.Windows.Forms.Label lblAnexado;
        private Controles.spinner spnCantidad;
        private Controles.boton btnExportarPdf;
        private System.Windows.Forms.Label lblReloj;
        private System.Windows.Forms.Label lblReloj2;
        private BrightIdeasSoftware.ObjectListView olvDeudas;
        private BrightIdeasSoftware.OLVColumn colCodigo;
        private BrightIdeasSoftware.OLVColumn colResp;
        private BrightIdeasSoftware.OLVColumn colUsuario;
        private BrightIdeasSoftware.OLVColumn colLocacion;
        private BrightIdeasSoftware.OLVColumn colPlastico;
        private BrightIdeasSoftware.OLVColumn colImporte;
        private BrightIdeasSoftware.OLVColumn colAnex;
        private BrightIdeasSoftware.OLVColumn colTotal;
        private System.Windows.Forms.ContextMenuStrip cmsOpciones;
        private System.Windows.Forms.ToolStripMenuItem verDetallesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verCuentaCorrienteDelUsuarioToolStripMenuItem;
        private System.Windows.Forms.Panel pnlDetalles;
        private System.Windows.Forms.Label lblUsuarioDetalles;
        private Controles.dgv dgvDetalles;
        private Controles.boton btnCerrar;
        private System.Windows.Forms.Panel pnlTituloDetalle;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label lblDetalles;
        private Controles.boton btnCargar;
        private Controles.boton btnPreGuardar;
        private BrightIdeasSoftware.OLVColumn colBonif;
        private BrightIdeasSoftware.OLVColumn colImporteProvincial;
        private BrightIdeasSoftware.OLVColumn colTipofac;
        private System.Windows.Forms.Label lblTotalTotal;
        private System.Windows.Forms.Label lblMontoTotalTotal;
        private System.ComponentModel.BackgroundWorker bgwReCalcularSaldos;
        private Controles.boton btnPagosExternos;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}