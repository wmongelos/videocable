namespace CapaPresentacion.Facturas
{
    partial class frmFacturasElectronicasAdheridos
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.imgReturn = new System.Windows.Forms.PictureBox();
            this.lblTituloHeader = new System.Windows.Forms.Label();
            this.tarea = new System.ComponentModel.BackgroundWorker();
            this.spMain = new System.Windows.Forms.SplitContainer();
            this.pnlCargando = new System.Windows.Forms.Panel();
            this.lblCargando = new System.Windows.Forms.Label();
            this.pgCircular = new CapaPresentacion.Controles.progress();
            this.dgvServiciosAFacturar = new CapaPresentacion.Controles.dgv(this.components);
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblTotalImporte = new System.Windows.Forms.Label();
            this.lblDebitos = new System.Windows.Forms.Label();
            this.lblDebitosColor = new System.Windows.Forms.Label();
            this.lblHasta = new System.Windows.Forms.Label();
            this.spHasta = new CapaPresentacion.Controles.spinner(this.components);
            this.btnVerErrores = new CapaPresentacion.Controles.boton();
            this.pnlErrores = new System.Windows.Forms.Panel();
            this.btnExportar = new CapaPresentacion.Controles.boton();
            this.dgvErrores = new CapaPresentacion.Controles.dgv(this.components);
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblTituloErrores = new System.Windows.Forms.Label();
            this.pnlControles = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.cboFacturacion = new CapaPresentacion.Controles.combo(this.components);
            this.btnSeleccionarFacturacion = new CapaPresentacion.Controles.boton();
            this.label4 = new System.Windows.Forms.Label();
            this.CboFiltro = new CapaPresentacion.Controles.combo(this.components);
            this.btnActualizar = new CapaPresentacion.Controles.boton();
            this.pnlProgreso = new System.Windows.Forms.Panel();
            this.lblCuanto = new System.Windows.Forms.Label();
            this.pgBar = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.btnFacturacion = new CapaPresentacion.Controles.boton();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgReturn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spMain)).BeginInit();
            this.spMain.Panel1.SuspendLayout();
            this.spMain.Panel2.SuspendLayout();
            this.spMain.SuspendLayout();
            this.pnlCargando.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvServiciosAFacturar)).BeginInit();
            this.flowLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spHasta)).BeginInit();
            this.pnlErrores.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvErrores)).BeginInit();
            this.panel3.SuspendLayout();
            this.pnlControles.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.pnlProgreso.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.panel1.Controls.Add(this.imgReturn);
            this.panel1.Controls.Add(this.lblTituloHeader);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1386, 87);
            this.panel1.TabIndex = 273;
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
            // lblTituloHeader
            // 
            this.lblTituloHeader.AutoSize = true;
            this.lblTituloHeader.Font = new System.Drawing.Font("Segoe UI Light", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloHeader.ForeColor = System.Drawing.Color.White;
            this.lblTituloHeader.Location = new System.Drawing.Point(51, 31);
            this.lblTituloHeader.Name = "lblTituloHeader";
            this.lblTituloHeader.Size = new System.Drawing.Size(192, 25);
            this.lblTituloHeader.TabIndex = 208;
            this.lblTituloHeader.Text = "Facturacion electronica";
            // 
            // tarea
            // 
            this.tarea.WorkerReportsProgress = true;
            this.tarea.WorkerSupportsCancellation = true;
            this.tarea.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.tarea_ProgressChanged);
            this.tarea.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.tarea_RunWorkerCompleted);
            // 
            // spMain
            // 
            this.spMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spMain.Location = new System.Drawing.Point(0, 87);
            this.spMain.Name = "spMain";
            // 
            // spMain.Panel1
            // 
            this.spMain.Panel1.Controls.Add(this.pnlCargando);
            this.spMain.Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel1_Paint);
            this.spMain.Panel1Collapsed = true;
            // 
            // spMain.Panel2
            // 
            this.spMain.Panel2.Controls.Add(this.dgvServiciosAFacturar);
            this.spMain.Panel2.Controls.Add(this.flowLayoutPanel3);
            this.spMain.Panel2.Controls.Add(this.pnlErrores);
            this.spMain.Panel2.Controls.Add(this.pnlControles);
            this.spMain.Size = new System.Drawing.Size(1386, 584);
            this.spMain.SplitterDistance = 716;
            this.spMain.TabIndex = 315;
            // 
            // pnlCargando
            // 
            this.pnlCargando.Controls.Add(this.lblCargando);
            this.pnlCargando.Controls.Add(this.pgCircular);
            this.pnlCargando.Location = new System.Drawing.Point(261, 63);
            this.pnlCargando.Name = "pnlCargando";
            this.pnlCargando.Size = new System.Drawing.Size(157, 147);
            this.pnlCargando.TabIndex = 315;
            // 
            // lblCargando
            // 
            this.lblCargando.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.lblCargando.ForeColor = System.Drawing.Color.Black;
            this.lblCargando.Location = new System.Drawing.Point(38, 93);
            this.lblCargando.Name = "lblCargando";
            this.lblCargando.Size = new System.Drawing.Size(90, 25);
            this.lblCargando.TabIndex = 15;
            this.lblCargando.Text = "Cargando";
            // 
            // pgCircular
            // 
            this.pgCircular.Location = new System.Drawing.Point(43, 14);
            this.pgCircular.Name = "pgCircular";
            this.pgCircular.Percentage = 0F;
            this.pgCircular.Rotation = CapaPresentacion.Controles.RotationType.CounterClockwise;
            this.pgCircular.Size = new System.Drawing.Size(76, 76);
            this.pgCircular.TabIndex = 314;
            // 
            // dgvServiciosAFacturar
            // 
            this.dgvServiciosAFacturar.AllowUserToAddRows = false;
            this.dgvServiciosAFacturar.AllowUserToDeleteRows = false;
            this.dgvServiciosAFacturar.AllowUserToOrderColumns = true;
            this.dgvServiciosAFacturar.AllowUserToResizeColumns = false;
            this.dgvServiciosAFacturar.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvServiciosAFacturar.BackgroundColor = System.Drawing.Color.White;
            this.dgvServiciosAFacturar.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvServiciosAFacturar.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSlateGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvServiciosAFacturar.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvServiciosAFacturar.ColumnHeadersHeight = 40;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvServiciosAFacturar.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvServiciosAFacturar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvServiciosAFacturar.EnableHeadersVisualStyles = false;
            this.dgvServiciosAFacturar.GridColor = System.Drawing.Color.WhiteSmoke;
            this.dgvServiciosAFacturar.Location = new System.Drawing.Point(0, 92);
            this.dgvServiciosAFacturar.MultiSelect = false;
            this.dgvServiciosAFacturar.Name = "dgvServiciosAFacturar";
            this.dgvServiciosAFacturar.ReadOnly = true;
            this.dgvServiciosAFacturar.RowHeadersVisible = false;
            this.dgvServiciosAFacturar.RowHeadersWidth = 50;
            this.dgvServiciosAFacturar.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvServiciosAFacturar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvServiciosAFacturar.Size = new System.Drawing.Size(1386, 456);
            this.dgvServiciosAFacturar.TabIndex = 313;
            this.dgvServiciosAFacturar.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvServiciosAFacturar_CellClick);
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Controls.Add(this.lblTotal);
            this.flowLayoutPanel3.Controls.Add(this.lblTotalImporte);
            this.flowLayoutPanel3.Controls.Add(this.lblDebitos);
            this.flowLayoutPanel3.Controls.Add(this.lblDebitosColor);
            this.flowLayoutPanel3.Controls.Add(this.lblHasta);
            this.flowLayoutPanel3.Controls.Add(this.spHasta);
            this.flowLayoutPanel3.Controls.Add(this.btnVerErrores);
            this.flowLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel3.Location = new System.Drawing.Point(0, 548);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(1386, 36);
            this.flowLayoutPanel3.TabIndex = 324;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.lblTotal.ForeColor = System.Drawing.Color.Black;
            this.lblTotal.Location = new System.Drawing.Point(3, 0);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(171, 25);
            this.lblTotal.TabIndex = 14;
            this.lblTotal.Text = "Total de Registros: 0";
            // 
            // lblTotalImporte
            // 
            this.lblTotalImporte.AutoSize = true;
            this.lblTotalImporte.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.lblTotalImporte.ForeColor = System.Drawing.Color.Black;
            this.lblTotalImporte.Location = new System.Drawing.Point(180, 0);
            this.lblTotalImporte.Name = "lblTotalImporte";
            this.lblTotalImporte.Size = new System.Drawing.Size(171, 25);
            this.lblTotalImporte.TabIndex = 324;
            this.lblTotalImporte.Text = "Total de Registros: 0";
            // 
            // lblDebitos
            // 
            this.lblDebitos.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.lblDebitos.ForeColor = System.Drawing.Color.Black;
            this.lblDebitos.Location = new System.Drawing.Point(357, 0);
            this.lblDebitos.Name = "lblDebitos";
            this.lblDebitos.Size = new System.Drawing.Size(177, 35);
            this.lblDebitos.TabIndex = 325;
            this.lblDebitos.Text = "Debitos automaticos";
            this.lblDebitos.Click += new System.EventHandler(this.lblDebitos_Click);
            // 
            // lblDebitosColor
            // 
            this.lblDebitosColor.BackColor = System.Drawing.Color.LightSteelBlue;
            this.lblDebitosColor.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDebitosColor.ForeColor = System.Drawing.Color.Black;
            this.lblDebitosColor.Location = new System.Drawing.Point(540, 0);
            this.lblDebitosColor.Name = "lblDebitosColor";
            this.lblDebitosColor.Size = new System.Drawing.Size(32, 25);
            this.lblDebitosColor.TabIndex = 334;
            this.lblDebitosColor.Text = "      ";
            this.lblDebitosColor.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblDebitosColor.Click += new System.EventHandler(this.lblDebitosColor_Click);
            // 
            // lblHasta
            // 
            this.lblHasta.AllowDrop = true;
            this.lblHasta.AutoSize = true;
            this.lblHasta.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.lblHasta.ForeColor = System.Drawing.Color.Black;
            this.lblHasta.Location = new System.Drawing.Point(578, 0);
            this.lblHasta.Name = "lblHasta";
            this.lblHasta.Size = new System.Drawing.Size(121, 25);
            this.lblHasta.TabIndex = 336;
            this.lblHasta.Text = "Facturar hasta";
            this.lblHasta.Click += new System.EventHandler(this.label2_Click);
            // 
            // spHasta
            // 
            this.spHasta.BorderColor = System.Drawing.Color.Empty;
            this.spHasta.DecimalPlaces = 2;
            this.spHasta.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.spHasta.Location = new System.Drawing.Point(705, 3);
            this.spHasta.Name = "spHasta";
            this.spHasta.Size = new System.Drawing.Size(158, 29);
            this.spHasta.TabIndex = 335;
            // 
            // btnVerErrores
            // 
            this.btnVerErrores.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnVerErrores.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVerErrores.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnVerErrores.FlatAppearance.BorderSize = 0;
            this.btnVerErrores.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnVerErrores.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnVerErrores.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVerErrores.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnVerErrores.ForeColor = System.Drawing.Color.White;
            this.btnVerErrores.Image = global::CapaPresentacion.Properties.Resources.lupa;
            this.btnVerErrores.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnVerErrores.Location = new System.Drawing.Point(869, 3);
            this.btnVerErrores.Name = "btnVerErrores";
            this.btnVerErrores.Size = new System.Drawing.Size(157, 30);
            this.btnVerErrores.TabIndex = 323;
            this.btnVerErrores.Text = "Ver rechazados";
            this.btnVerErrores.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVerErrores.UseVisualStyleBackColor = false;
            this.btnVerErrores.Visible = false;
            this.btnVerErrores.Click += new System.EventHandler(this.btnVerErrores_Click);
            // 
            // pnlErrores
            // 
            this.pnlErrores.Controls.Add(this.btnExportar);
            this.pnlErrores.Controls.Add(this.dgvErrores);
            this.pnlErrores.Controls.Add(this.panel3);
            this.pnlErrores.Location = new System.Drawing.Point(40, 98);
            this.pnlErrores.Name = "pnlErrores";
            this.pnlErrores.Size = new System.Drawing.Size(1294, 275);
            this.pnlErrores.TabIndex = 315;
            this.pnlErrores.Visible = false;
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
            this.btnExportar.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnExportar.ForeColor = System.Drawing.Color.White;
            this.btnExportar.Image = global::CapaPresentacion.Properties.Resources.Next_32;
            this.btnExportar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExportar.Location = new System.Drawing.Point(1169, 229);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(107, 39);
            this.btnExportar.TabIndex = 322;
            this.btnExportar.Text = "Exportar";
            this.btnExportar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExportar.UseVisualStyleBackColor = false;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // dgvErrores
            // 
            this.dgvErrores.AllowUserToAddRows = false;
            this.dgvErrores.AllowUserToDeleteRows = false;
            this.dgvErrores.AllowUserToOrderColumns = true;
            this.dgvErrores.AllowUserToResizeColumns = false;
            this.dgvErrores.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvErrores.BackgroundColor = System.Drawing.Color.White;
            this.dgvErrores.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvErrores.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.LightSlateGray;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvErrores.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvErrores.ColumnHeadersHeight = 40;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvErrores.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvErrores.EnableHeadersVisualStyles = false;
            this.dgvErrores.GridColor = System.Drawing.Color.WhiteSmoke;
            this.dgvErrores.Location = new System.Drawing.Point(13, 52);
            this.dgvErrores.MultiSelect = false;
            this.dgvErrores.Name = "dgvErrores";
            this.dgvErrores.ReadOnly = true;
            this.dgvErrores.RowHeadersVisible = false;
            this.dgvErrores.RowHeadersWidth = 50;
            this.dgvErrores.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvErrores.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvErrores.Size = new System.Drawing.Size(1263, 171);
            this.dgvErrores.TabIndex = 314;
            this.dgvErrores.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvErrores_CellContentClick);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.panel3.Controls.Add(this.lblTituloErrores);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1294, 46);
            this.panel3.TabIndex = 274;
            // 
            // lblTituloErrores
            // 
            this.lblTituloErrores.AutoSize = true;
            this.lblTituloErrores.Font = new System.Drawing.Font("Segoe UI Light", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloErrores.ForeColor = System.Drawing.Color.White;
            this.lblTituloErrores.Location = new System.Drawing.Point(8, 11);
            this.lblTituloErrores.Name = "lblTituloErrores";
            this.lblTituloErrores.Size = new System.Drawing.Size(387, 25);
            this.lblTituloErrores.TabIndex = 208;
            this.lblTituloErrores.Text = "Facturacion electronica. - Rechazados/Erroneos";
            // 
            // pnlControles
            // 
            this.pnlControles.Controls.Add(this.flowLayoutPanel1);
            this.pnlControles.Controls.Add(this.btnActualizar);
            this.pnlControles.Controls.Add(this.pnlProgreso);
            this.pnlControles.Controls.Add(this.label1);
            this.pnlControles.Controls.Add(this.btnFacturacion);
            this.pnlControles.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlControles.Location = new System.Drawing.Point(0, 0);
            this.pnlControles.Name = "pnlControles";
            this.pnlControles.Size = new System.Drawing.Size(1386, 92);
            this.pnlControles.TabIndex = 274;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.label2);
            this.flowLayoutPanel1.Controls.Add(this.cboFacturacion);
            this.flowLayoutPanel1.Controls.Add(this.btnSeleccionarFacturacion);
            this.flowLayoutPanel1.Controls.Add(this.label4);
            this.flowLayoutPanel1.Controls.Add(this.CboFiltro);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(8, 48);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1077, 38);
            this.flowLayoutPanel1.TabIndex = 327;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 32);
            this.label2.TabIndex = 323;
            this.label2.Text = "Periodo:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboFacturacion
            // 
            this.cboFacturacion.BorderColor = System.Drawing.Color.Gainsboro;
            this.cboFacturacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFacturacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboFacturacion.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.cboFacturacion.FormattingEnabled = true;
            this.cboFacturacion.Location = new System.Drawing.Point(91, 3);
            this.cboFacturacion.Name = "cboFacturacion";
            this.cboFacturacion.Size = new System.Drawing.Size(211, 31);
            this.cboFacturacion.TabIndex = 322;
            this.cboFacturacion.SelectionChangeCommitted += new System.EventHandler(this.cboFacturacion_SelectionChangeCommitted);
            // 
            // btnSeleccionarFacturacion
            // 
            this.btnSeleccionarFacturacion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnSeleccionarFacturacion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSeleccionarFacturacion.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnSeleccionarFacturacion.FlatAppearance.BorderSize = 0;
            this.btnSeleccionarFacturacion.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnSeleccionarFacturacion.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnSeleccionarFacturacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSeleccionarFacturacion.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnSeleccionarFacturacion.ForeColor = System.Drawing.Color.White;
            this.btnSeleccionarFacturacion.Image = global::CapaPresentacion.Properties.Resources.lupa;
            this.btnSeleccionarFacturacion.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSeleccionarFacturacion.Location = new System.Drawing.Point(305, 0);
            this.btnSeleccionarFacturacion.Margin = new System.Windows.Forms.Padding(0);
            this.btnSeleccionarFacturacion.Name = "btnSeleccionarFacturacion";
            this.btnSeleccionarFacturacion.Size = new System.Drawing.Size(99, 34);
            this.btnSeleccionarFacturacion.TabIndex = 326;
            this.btnSeleccionarFacturacion.Text = "Buscar";
            this.btnSeleccionarFacturacion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSeleccionarFacturacion.UseVisualStyleBackColor = false;
            this.btnSeleccionarFacturacion.Click += new System.EventHandler(this.btnSeleccionarFacturacion_Click);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(407, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 32);
            this.label4.TabIndex = 330;
            this.label4.Text = "Filtrar por:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CboFiltro
            // 
            this.CboFiltro.BorderColor = System.Drawing.Color.Gainsboro;
            this.CboFiltro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CboFiltro.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CboFiltro.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.CboFiltro.FormattingEnabled = true;
            this.CboFiltro.Items.AddRange(new object[] {
            "UNIVERSO",
            "ADHERIDOS A FE",
            "REMITOS",
            "DEBITOS"});
            this.CboFiltro.Location = new System.Drawing.Point(509, 3);
            this.CboFiltro.Name = "CboFiltro";
            this.CboFiltro.Size = new System.Drawing.Size(251, 31);
            this.CboFiltro.TabIndex = 328;
            this.CboFiltro.SelectedIndexChanged += new System.EventHandler(this.CboFiltro_SelectedIndexChanged);
            // 
            // btnActualizar
            // 
            this.btnActualizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnActualizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnActualizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnActualizar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnActualizar.FlatAppearance.BorderSize = 0;
            this.btnActualizar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnActualizar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnActualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActualizar.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnActualizar.ForeColor = System.Drawing.Color.White;
            this.btnActualizar.Image = global::CapaPresentacion.Properties.Resources.Command_Refresh_32;
            this.btnActualizar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnActualizar.Location = new System.Drawing.Point(1074, 3);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(128, 39);
            this.btnActualizar.TabIndex = 321;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnActualizar.UseVisualStyleBackColor = false;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // pnlProgreso
            // 
            this.pnlProgreso.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlProgreso.Controls.Add(this.lblCuanto);
            this.pnlProgreso.Controls.Add(this.pgBar);
            this.pnlProgreso.Location = new System.Drawing.Point(492, 6);
            this.pnlProgreso.Name = "pnlProgreso";
            this.pnlProgreso.Size = new System.Drawing.Size(576, 35);
            this.pnlProgreso.TabIndex = 320;
            this.pnlProgreso.Visible = false;
            // 
            // lblCuanto
            // 
            this.lblCuanto.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblCuanto.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.lblCuanto.ForeColor = System.Drawing.Color.Black;
            this.lblCuanto.Location = new System.Drawing.Point(97, 0);
            this.lblCuanto.Name = "lblCuanto";
            this.lblCuanto.Size = new System.Drawing.Size(323, 35);
            this.lblCuanto.TabIndex = 321;
            this.lblCuanto.Text = "Procesando: {0} de {1} ({2} %)";
            this.lblCuanto.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pgBar
            // 
            this.pgBar.Dock = System.Windows.Forms.DockStyle.Right;
            this.pgBar.Location = new System.Drawing.Point(420, 0);
            this.pgBar.Name = "pgBar";
            this.pgBar.Size = new System.Drawing.Size(156, 35);
            this.pgBar.TabIndex = 316;
            this.pgBar.Value = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(12, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(381, 25);
            this.label1.TabIndex = 319;
            this.label1.Text = "Comprobantes para pasar a factura electronica";
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
            this.btnFacturacion.Location = new System.Drawing.Point(1208, 3);
            this.btnFacturacion.Name = "btnFacturacion";
            this.btnFacturacion.Size = new System.Drawing.Size(175, 39);
            this.btnFacturacion.TabIndex = 318;
            this.btnFacturacion.Text = "Generar facturas";
            this.btnFacturacion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFacturacion.UseVisualStyleBackColor = false;
            this.btnFacturacion.Click += new System.EventHandler(this.btnFacturacion_Click);
            // 
            // frmFacturasElectronicasAdheridos
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1386, 671);
            this.Controls.Add(this.spMain);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "frmFacturasElectronicasAdheridos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmFacturasElectronicasAdheridos";
            this.Load += new System.EventHandler(this.frmFacturasElectronicasAdheridos_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmFacturasElectronicasAdheridos_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgReturn)).EndInit();
            this.spMain.Panel1.ResumeLayout(false);
            this.spMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spMain)).EndInit();
            this.spMain.ResumeLayout(false);
            this.pnlCargando.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvServiciosAFacturar)).EndInit();
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spHasta)).EndInit();
            this.pnlErrores.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvErrores)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.pnlControles.ResumeLayout(false);
            this.pnlControles.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.pnlProgreso.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox imgReturn;
        private System.Windows.Forms.Label lblTituloHeader;
        private System.Windows.Forms.Panel pnlControles;
        private Controles.boton btnFacturacion;
        private Controles.dgv dgvServiciosAFacturar;
        private Controles.progress pgCircular;
        private System.Windows.Forms.SplitContainer spMain;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ProgressBar pgBar;
        private System.ComponentModel.BackgroundWorker tarea;
        private System.Windows.Forms.Panel pnlCargando;
        private System.Windows.Forms.Label lblCargando;
        private System.Windows.Forms.Panel pnlProgreso;
        private System.Windows.Forms.Label lblCuanto;
        private Controles.boton btnActualizar;
        private System.Windows.Forms.Panel pnlErrores;
        private Controles.dgv dgvErrores;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblTituloErrores;
        private Controles.boton btnExportar;
        private Controles.boton btnVerErrores;
        private System.Windows.Forms.Label lblTotalImporte;
        private System.Windows.Forms.Label lblDebitos;
        private System.Windows.Forms.Label lblDebitosColor;
        private System.Windows.Forms.Label lblHasta;
        private Controles.spinner spHasta;
        private Controles.combo cboFacturacion;
        private Controles.boton btnSeleccionarFacturacion;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private Controles.combo CboFiltro;
        private System.Windows.Forms.Label label4;
    }
}