namespace CapaPresentacion.Facturas
{
    partial class frmEnviaFacturasElectronicas
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.imgReturn = new System.Windows.Forms.PictureBox();
            this.lblTituloHeader = new System.Windows.Forms.Label();
            this.pnlControles = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.txtbusca = new CapaPresentacion.textboxAdv();
            this.rbTodos = new System.Windows.Forms.RadioButton();
            this.rbNoEnviados = new System.Windows.Forms.RadioButton();
            this.rbEnviados = new System.Windows.Forms.RadioButton();
            this.btnBuscar = new CapaPresentacion.Controles.boton();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.lblDesde = new System.Windows.Forms.Label();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.btnSeleccionarTodo = new CapaPresentacion.Controles.boton();
            this.pnlProgreso = new System.Windows.Forms.Panel();
            this.pgCircular2 = new CapaPresentacion.Controles.progress();
            this.lblCuanto = new System.Windows.Forms.Label();
            this.pgBar = new System.Windows.Forms.ProgressBar();
            this.btnGuardar = new CapaPresentacion.Controles.boton();
            this.btnFacturacion = new CapaPresentacion.Controles.boton();
            this.spMain = new System.Windows.Forms.SplitContainer();
            this.pnlCargando = new System.Windows.Forms.Panel();
            this.lblCargando = new System.Windows.Forms.Label();
            this.pgCircular = new CapaPresentacion.Controles.progress();
            this.dgvFacturas = new CapaPresentacion.Controles.dgv(this.components);
            this.pnlInferior = new System.Windows.Forms.Panel();
            this.lblTotal = new System.Windows.Forms.Label();
            this.tarea = new System.ComponentModel.BackgroundWorker();
            this.tarea2 = new System.ComponentModel.BackgroundWorker();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgReturn)).BeginInit();
            this.pnlControles.SuspendLayout();
            this.pnlProgreso.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spMain)).BeginInit();
            this.spMain.Panel1.SuspendLayout();
            this.spMain.Panel2.SuspendLayout();
            this.spMain.SuspendLayout();
            this.pnlCargando.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFacturas)).BeginInit();
            this.pnlInferior.SuspendLayout();
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
            this.panel1.Size = new System.Drawing.Size(1221, 87);
            this.panel1.TabIndex = 274;
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
            // pnlControles
            // 
            this.pnlControles.Controls.Add(this.label2);
            this.pnlControles.Controls.Add(this.txtbusca);
            this.pnlControles.Controls.Add(this.rbTodos);
            this.pnlControles.Controls.Add(this.rbNoEnviados);
            this.pnlControles.Controls.Add(this.rbEnviados);
            this.pnlControles.Controls.Add(this.btnBuscar);
            this.pnlControles.Controls.Add(this.dtpHasta);
            this.pnlControles.Controls.Add(this.label1);
            this.pnlControles.Controls.Add(this.lblDesde);
            this.pnlControles.Controls.Add(this.dtpDesde);
            this.pnlControles.Controls.Add(this.btnSeleccionarTodo);
            this.pnlControles.Controls.Add(this.pnlProgreso);
            this.pnlControles.Controls.Add(this.btnGuardar);
            this.pnlControles.Controls.Add(this.btnFacturacion);
            this.pnlControles.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlControles.Location = new System.Drawing.Point(0, 0);
            this.pnlControles.Name = "pnlControles";
            this.pnlControles.Size = new System.Drawing.Size(1221, 98);
            this.pnlControles.TabIndex = 275;
            this.pnlControles.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlControles_Paint);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label2.Location = new System.Drawing.Point(922, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 21);
            this.label2.TabIndex = 337;
            this.label2.Text = "Buscar:";
            // 
            // txtbusca
            // 
            this.txtbusca.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtbusca.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtbusca.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtbusca.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtbusca.FocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.txtbusca.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtbusca.ForeColor = System.Drawing.Color.DimGray;
            this.txtbusca.Location = new System.Drawing.Point(987, 57);
            this.txtbusca.Name = "txtbusca";
            this.txtbusca.Numerico = false;
            this.txtbusca.Size = new System.Drawing.Size(228, 29);
            this.txtbusca.TabIndex = 336;
            this.txtbusca.Tag = "\"\"";
            this.txtbusca.TextChanged += new System.EventHandler(this.txtbusca_TextChanged);
            // 
            // rbTodos
            // 
            this.rbTodos.AutoSize = true;
            this.rbTodos.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.rbTodos.ForeColor = System.Drawing.Color.Black;
            this.rbTodos.Location = new System.Drawing.Point(232, 57);
            this.rbTodos.Name = "rbTodos";
            this.rbTodos.Size = new System.Drawing.Size(68, 25);
            this.rbTodos.TabIndex = 335;
            this.rbTodos.Text = "Todos";
            this.rbTodos.UseVisualStyleBackColor = true;
            // 
            // rbNoEnviados
            // 
            this.rbNoEnviados.AutoSize = true;
            this.rbNoEnviados.Checked = true;
            this.rbNoEnviados.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.rbNoEnviados.ForeColor = System.Drawing.Color.Black;
            this.rbNoEnviados.Location = new System.Drawing.Point(14, 57);
            this.rbNoEnviados.Name = "rbNoEnviados";
            this.rbNoEnviados.Size = new System.Drawing.Size(115, 25);
            this.rbNoEnviados.TabIndex = 334;
            this.rbNoEnviados.TabStop = true;
            this.rbNoEnviados.Text = "No enviados";
            this.rbNoEnviados.UseVisualStyleBackColor = true;
            // 
            // rbEnviados
            // 
            this.rbEnviados.AutoSize = true;
            this.rbEnviados.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.rbEnviados.ForeColor = System.Drawing.Color.Black;
            this.rbEnviados.Location = new System.Drawing.Point(136, 57);
            this.rbEnviados.Name = "rbEnviados";
            this.rbEnviados.Size = new System.Drawing.Size(90, 25);
            this.rbEnviados.TabIndex = 333;
            this.rbEnviados.Text = "Enviados";
            this.rbEnviados.UseVisualStyleBackColor = true;
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
            this.btnBuscar.Location = new System.Drawing.Point(486, 11);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(87, 32);
            this.btnBuscar.TabIndex = 332;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // dtpHasta
            // 
            this.dtpHasta.CustomFormat = "dd MMMM yyyy";
            this.dtpHasta.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpHasta.Location = new System.Drawing.Point(304, 13);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(176, 29);
            this.dtpHasta.TabIndex = 331;
            this.dtpHasta.Value = new System.DateTime(2020, 3, 16, 16, 2, 0, 0);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label1.Location = new System.Drawing.Point(249, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 21);
            this.label1.TabIndex = 330;
            this.label1.Text = "Hasta:";
            // 
            // lblDesde
            // 
            this.lblDesde.AutoSize = true;
            this.lblDesde.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblDesde.Location = new System.Drawing.Point(9, 19);
            this.lblDesde.Name = "lblDesde";
            this.lblDesde.Size = new System.Drawing.Size(56, 21);
            this.lblDesde.TabIndex = 329;
            this.lblDesde.Text = "Desde:";
            // 
            // dtpDesde
            // 
            this.dtpDesde.CustomFormat = "dd MMMM yyyy";
            this.dtpDesde.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDesde.Location = new System.Drawing.Point(67, 13);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(176, 29);
            this.dtpDesde.TabIndex = 328;
            this.dtpDesde.Value = new System.DateTime(2020, 3, 16, 16, 2, 0, 0);
            // 
            // btnSeleccionarTodo
            // 
            this.btnSeleccionarTodo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSeleccionarTodo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnSeleccionarTodo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSeleccionarTodo.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnSeleccionarTodo.FlatAppearance.BorderSize = 0;
            this.btnSeleccionarTodo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnSeleccionarTodo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnSeleccionarTodo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSeleccionarTodo.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnSeleccionarTodo.ForeColor = System.Drawing.Color.White;
            this.btnSeleccionarTodo.Image = global::CapaPresentacion.Properties.Resources.Arrowhead_Right_32;
            this.btnSeleccionarTodo.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSeleccionarTodo.Location = new System.Drawing.Point(690, 3);
            this.btnSeleccionarTodo.Name = "btnSeleccionarTodo";
            this.btnSeleccionarTodo.Size = new System.Drawing.Size(166, 39);
            this.btnSeleccionarTodo.TabIndex = 322;
            this.btnSeleccionarTodo.Text = "Seleccionar todos";
            this.btnSeleccionarTodo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSeleccionarTodo.UseVisualStyleBackColor = false;
            this.btnSeleccionarTodo.Click += new System.EventHandler(this.btnSeleccionarTodo_Click);
            // 
            // pnlProgreso
            // 
            this.pnlProgreso.Controls.Add(this.pgCircular2);
            this.pnlProgreso.Controls.Add(this.lblCuanto);
            this.pnlProgreso.Controls.Add(this.pgBar);
            this.pnlProgreso.Location = new System.Drawing.Point(321, 53);
            this.pnlProgreso.Name = "pnlProgreso";
            this.pnlProgreso.Size = new System.Drawing.Size(552, 35);
            this.pnlProgreso.TabIndex = 321;
            this.pnlProgreso.Visible = false;
            // 
            // pgCircular2
            // 
            this.pgCircular2.Dock = System.Windows.Forms.DockStyle.Right;
            this.pgCircular2.Location = new System.Drawing.Point(16, 0);
            this.pgCircular2.Name = "pgCircular2";
            this.pgCircular2.Percentage = 0F;
            this.pgCircular2.Rotation = CapaPresentacion.Controles.RotationType.CounterClockwise;
            this.pgCircular2.Size = new System.Drawing.Size(35, 35);
            this.pgCircular2.TabIndex = 317;
            // 
            // lblCuanto
            // 
            this.lblCuanto.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblCuanto.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.lblCuanto.ForeColor = System.Drawing.Color.Black;
            this.lblCuanto.Location = new System.Drawing.Point(51, 0);
            this.lblCuanto.Name = "lblCuanto";
            this.lblCuanto.Size = new System.Drawing.Size(239, 35);
            this.lblCuanto.TabIndex = 321;
            this.lblCuanto.Text = "Procesando: {0} de {1} ({2} %)";
            this.lblCuanto.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pgBar
            // 
            this.pgBar.Dock = System.Windows.Forms.DockStyle.Right;
            this.pgBar.Location = new System.Drawing.Point(290, 0);
            this.pgBar.Name = "pgBar";
            this.pgBar.Size = new System.Drawing.Size(262, 35);
            this.pgBar.TabIndex = 316;
            this.pgBar.Value = 1;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnGuardar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Image = global::CapaPresentacion.Properties.Resources.Save_32;
            this.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGuardar.Location = new System.Drawing.Point(862, 3);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(175, 39);
            this.btnGuardar.TabIndex = 319;
            this.btnGuardar.Text = "Guardar archivos";
            this.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnFacturacion
            // 
            this.btnFacturacion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFacturacion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnFacturacion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFacturacion.Enabled = false;
            this.btnFacturacion.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnFacturacion.FlatAppearance.BorderSize = 0;
            this.btnFacturacion.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnFacturacion.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnFacturacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFacturacion.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnFacturacion.ForeColor = System.Drawing.Color.White;
            this.btnFacturacion.Image = global::CapaPresentacion.Properties.Resources.Next_32;
            this.btnFacturacion.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFacturacion.Location = new System.Drawing.Point(1043, 3);
            this.btnFacturacion.Name = "btnFacturacion";
            this.btnFacturacion.Size = new System.Drawing.Size(175, 39);
            this.btnFacturacion.TabIndex = 318;
            this.btnFacturacion.Text = "Enviar facturas";
            this.btnFacturacion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFacturacion.UseVisualStyleBackColor = false;
            this.btnFacturacion.Click += new System.EventHandler(this.btnFacturacion_Click);
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
            this.spMain.Panel1Collapsed = true;
            // 
            // spMain.Panel2
            // 
            this.spMain.Panel2.Controls.Add(this.dgvFacturas);
            this.spMain.Panel2.Controls.Add(this.pnlInferior);
            this.spMain.Panel2.Controls.Add(this.pnlControles);
            this.spMain.Size = new System.Drawing.Size(1221, 446);
            this.spMain.SplitterDistance = 407;
            this.spMain.TabIndex = 315;
            // 
            // pnlCargando
            // 
            this.pnlCargando.Controls.Add(this.lblCargando);
            this.pnlCargando.Controls.Add(this.pgCircular);
            this.pnlCargando.Location = new System.Drawing.Point(125, 150);
            this.pnlCargando.Name = "pnlCargando";
            this.pnlCargando.Size = new System.Drawing.Size(157, 147);
            this.pnlCargando.TabIndex = 316;
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
            // dgvFacturas
            // 
            this.dgvFacturas.AllowUserToAddRows = false;
            this.dgvFacturas.AllowUserToDeleteRows = false;
            this.dgvFacturas.AllowUserToOrderColumns = true;
            this.dgvFacturas.AllowUserToResizeColumns = false;
            this.dgvFacturas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvFacturas.BackgroundColor = System.Drawing.Color.White;
            this.dgvFacturas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvFacturas.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSlateGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvFacturas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvFacturas.ColumnHeadersHeight = 40;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvFacturas.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvFacturas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvFacturas.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvFacturas.EnableHeadersVisualStyles = false;
            this.dgvFacturas.GridColor = System.Drawing.Color.WhiteSmoke;
            this.dgvFacturas.Location = new System.Drawing.Point(0, 98);
            this.dgvFacturas.MultiSelect = false;
            this.dgvFacturas.Name = "dgvFacturas";
            this.dgvFacturas.ReadOnly = true;
            this.dgvFacturas.RowHeadersVisible = false;
            this.dgvFacturas.RowHeadersWidth = 50;
            this.dgvFacturas.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvFacturas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvFacturas.Size = new System.Drawing.Size(1221, 309);
            this.dgvFacturas.TabIndex = 314;
            this.dgvFacturas.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFacturas_CellClick);
            this.dgvFacturas.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFacturas_CellEnter);
            this.dgvFacturas.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvFacturas_KeyDown);
            // 
            // pnlInferior
            // 
            this.pnlInferior.Controls.Add(this.lblTotal);
            this.pnlInferior.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlInferior.Location = new System.Drawing.Point(0, 407);
            this.pnlInferior.Name = "pnlInferior";
            this.pnlInferior.Size = new System.Drawing.Size(1221, 39);
            this.pnlInferior.TabIndex = 315;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.lblTotal.ForeColor = System.Drawing.Color.Black;
            this.lblTotal.Location = new System.Drawing.Point(3, 5);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(171, 25);
            this.lblTotal.TabIndex = 14;
            this.lblTotal.Text = "Total de Registros: 0";
            // 
            // tarea
            // 
            this.tarea.WorkerReportsProgress = true;
            this.tarea.WorkerSupportsCancellation = true;
            this.tarea.DoWork += new System.ComponentModel.DoWorkEventHandler(this.tarea_DoWork);
            this.tarea.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.tarea_ProgressChanged);
            this.tarea.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.tarea_RunWorkerCompleted);
            // 
            // tarea2
            // 
            this.tarea2.WorkerReportsProgress = true;
            this.tarea2.WorkerSupportsCancellation = true;
            this.tarea2.DoWork += new System.ComponentModel.DoWorkEventHandler(this.tarea2_DoWork);
            this.tarea2.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.tarea2_ProgressChanged);
            this.tarea2.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.TerminardoEnviar);
            // 
            // frmEnviaFacturasElectronicas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1221, 533);
            this.Controls.Add(this.spMain);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "frmEnviaFacturasElectronicas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmEnviaFacturasElectronicas";
            this.Load += new System.EventHandler(this.frmEnviaFacturasElectronicas_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmEnviaFacturasElectronicas_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgReturn)).EndInit();
            this.pnlControles.ResumeLayout(false);
            this.pnlControles.PerformLayout();
            this.pnlProgreso.ResumeLayout(false);
            this.spMain.Panel1.ResumeLayout(false);
            this.spMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spMain)).EndInit();
            this.spMain.ResumeLayout(false);
            this.pnlCargando.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFacturas)).EndInit();
            this.pnlInferior.ResumeLayout(false);
            this.pnlInferior.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox imgReturn;
        private System.Windows.Forms.Label lblTituloHeader;
        private System.Windows.Forms.Panel pnlControles;
        private Controles.boton btnFacturacion;
        private Controles.dgv dgvFacturas;
        private System.Windows.Forms.SplitContainer spMain;
        private System.Windows.Forms.Panel pnlCargando;
        private System.Windows.Forms.Label lblCargando;
        private Controles.progress pgCircular;
        private System.Windows.Forms.Panel pnlInferior;
        private System.Windows.Forms.Label lblTotal;
        private Controles.boton btnGuardar;
        private System.ComponentModel.BackgroundWorker tarea;
        private System.Windows.Forms.Panel pnlProgreso;
        private System.Windows.Forms.Label lblCuanto;
        private System.Windows.Forms.ProgressBar pgBar;
        private Controles.progress pgCircular2;
        private Controles.boton btnSeleccionarTodo;
        private System.ComponentModel.BackgroundWorker tarea2;
        private Controles.boton btnBuscar;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblDesde;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.RadioButton rbTodos;
        private System.Windows.Forms.RadioButton rbNoEnviados;
        private System.Windows.Forms.RadioButton rbEnviados;
        private System.Windows.Forms.Label label2;
        private textboxAdv txtbusca;
    }
}