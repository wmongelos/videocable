namespace CapaPresentacion.Partes_Trabajo
{
    partial class frmParteConexion_Auxiliar
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnContent = new System.Windows.Forms.Panel();
            this.pnlVelEqui = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabVelocidad = new System.Windows.Forms.TabPage();
            this.dgvVelocidades = new CapaPresentacion.Controles.dgv(this.components);
            this.chkIPFija = new System.Windows.Forms.CheckBox();
            this.tabEquipos = new System.Windows.Forms.TabPage();
            this.spCantidadEquipos = new CapaPresentacion.Controles.spinner(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.btnAgregarEquipo = new CapaPresentacion.Controles.boton();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvEquipos = new CapaPresentacion.Controles.dgv(this.components);
            this.cboEquipos = new CapaPresentacion.Controles.combo(this.components);
            this.tabPaquetes = new System.Windows.Forms.TabPage();
            this.dgvPaquetes = new CapaPresentacion.Controles.dgv(this.components);
            this.pnlFechas = new System.Windows.Forms.Panel();
            this.cboServicios_Categ = new CapaPresentacion.Controles.combo(this.components);
            this.gbModalidad = new System.Windows.Forms.GroupBox();
            this.rbUFuncionales = new System.Windows.Forms.RadioButton();
            this.rbBocas = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.lblMesesServicio = new System.Windows.Forms.Label();
            this.spMesesServicio = new CapaPresentacion.Controles.spinner(this.components);
            this.lblMesesCobro = new System.Windows.Forms.Label();
            this.spMesesCobro = new CapaPresentacion.Controles.spinner(this.components);
            this.dtpFechaConexion = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dtpFechaInicioServ = new System.Windows.Forms.DateTimePicker();
            this.lblModalidadCantidad = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.spUFuncional = new CapaPresentacion.Controles.spinner(this.components);
            this.lblModalidadCantidadPac = new System.Windows.Forms.Label();
            this.spUFuncionalPac = new CapaPresentacion.Controles.spinner(this.components);
            this.pnlBotones = new System.Windows.Forms.Panel();
            this.btnCancelar = new CapaPresentacion.Controles.boton();
            this.btnConfirmar = new CapaPresentacion.Controles.boton();
            this.pnlSuperior = new System.Windows.Forms.Panel();
            this.lblServicio = new System.Windows.Forms.Label();
            this.pnLinea1 = new System.Windows.Forms.Panel();
            this.pnContent.SuspendLayout();
            this.pnlVelEqui.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabVelocidad.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVelocidades)).BeginInit();
            this.tabEquipos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spCantidadEquipos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEquipos)).BeginInit();
            this.tabPaquetes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPaquetes)).BeginInit();
            this.pnlFechas.SuspendLayout();
            this.gbModalidad.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spMesesServicio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spMesesCobro)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spUFuncional)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spUFuncionalPac)).BeginInit();
            this.pnlBotones.SuspendLayout();
            this.pnlSuperior.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnContent
            // 
            this.pnContent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnContent.Controls.Add(this.pnlVelEqui);
            this.pnContent.Controls.Add(this.pnlFechas);
            this.pnContent.Controls.Add(this.pnlBotones);
            this.pnContent.Controls.Add(this.pnlSuperior);
            this.pnContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnContent.Location = new System.Drawing.Point(0, 0);
            this.pnContent.Name = "pnContent";
            this.pnContent.Size = new System.Drawing.Size(900, 608);
            this.pnContent.TabIndex = 0;
            // 
            // pnlVelEqui
            // 
            this.pnlVelEqui.Controls.Add(this.tabControl1);
            this.pnlVelEqui.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlVelEqui.Location = new System.Drawing.Point(0, 300);
            this.pnlVelEqui.Name = "pnlVelEqui";
            this.pnlVelEqui.Size = new System.Drawing.Size(898, 263);
            this.pnlVelEqui.TabIndex = 119;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabVelocidad);
            this.tabControl1.Controls.Add(this.tabEquipos);
            this.tabControl1.Controls.Add(this.tabPaquetes);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Segoe UI Light", 14F);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(898, 263);
            this.tabControl1.TabIndex = 119;
            // 
            // tabVelocidad
            // 
            this.tabVelocidad.Controls.Add(this.dgvVelocidades);
            this.tabVelocidad.Controls.Add(this.chkIPFija);
            this.tabVelocidad.Location = new System.Drawing.Point(4, 34);
            this.tabVelocidad.Name = "tabVelocidad";
            this.tabVelocidad.Padding = new System.Windows.Forms.Padding(3);
            this.tabVelocidad.Size = new System.Drawing.Size(890, 225);
            this.tabVelocidad.TabIndex = 0;
            this.tabVelocidad.Text = "Velocidades";
            this.tabVelocidad.UseVisualStyleBackColor = true;
            // 
            // dgvVelocidades
            // 
            this.dgvVelocidades.AllowUserToAddRows = false;
            this.dgvVelocidades.AllowUserToDeleteRows = false;
            this.dgvVelocidades.AllowUserToOrderColumns = true;
            this.dgvVelocidades.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvVelocidades.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvVelocidades.BackgroundColor = System.Drawing.Color.White;
            this.dgvVelocidades.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvVelocidades.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSlateGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI Light", 14F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvVelocidades.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvVelocidades.ColumnHeadersHeight = 50;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Light", 14F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvVelocidades.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvVelocidades.EnableHeadersVisualStyles = false;
            this.dgvVelocidades.GridColor = System.Drawing.Color.WhiteSmoke;
            this.dgvVelocidades.Location = new System.Drawing.Point(21, 48);
            this.dgvVelocidades.MultiSelect = false;
            this.dgvVelocidades.Name = "dgvVelocidades";
            this.dgvVelocidades.ReadOnly = true;
            this.dgvVelocidades.RowHeadersVisible = false;
            this.dgvVelocidades.RowHeadersWidth = 50;
            this.dgvVelocidades.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvVelocidades.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvVelocidades.Size = new System.Drawing.Size(827, 170);
            this.dgvVelocidades.TabIndex = 78;
            this.dgvVelocidades.SelectionChanged += new System.EventHandler(this.dgvVelocidades_SelectionChanged);
            // 
            // chkIPFija
            // 
            this.chkIPFija.AutoSize = true;
            this.chkIPFija.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.chkIPFija.Location = new System.Drawing.Point(18, 18);
            this.chkIPFija.Name = "chkIPFija";
            this.chkIPFija.Size = new System.Drawing.Size(150, 25);
            this.chkIPFija.TabIndex = 77;
            this.chkIPFija.Text = "Servicio de IP Fija";
            this.chkIPFija.UseVisualStyleBackColor = true;
            // 
            // tabEquipos
            // 
            this.tabEquipos.Controls.Add(this.spCantidadEquipos);
            this.tabEquipos.Controls.Add(this.label3);
            this.tabEquipos.Controls.Add(this.btnAgregarEquipo);
            this.tabEquipos.Controls.Add(this.label1);
            this.tabEquipos.Controls.Add(this.dgvEquipos);
            this.tabEquipos.Controls.Add(this.cboEquipos);
            this.tabEquipos.Location = new System.Drawing.Point(4, 34);
            this.tabEquipos.Name = "tabEquipos";
            this.tabEquipos.Padding = new System.Windows.Forms.Padding(3);
            this.tabEquipos.Size = new System.Drawing.Size(890, 225);
            this.tabEquipos.TabIndex = 1;
            this.tabEquipos.Text = "Equipamiento";
            this.tabEquipos.UseVisualStyleBackColor = true;
            // 
            // spCantidadEquipos
            // 
            this.spCantidadEquipos.BorderColor = System.Drawing.Color.Empty;
            this.spCantidadEquipos.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spCantidadEquipos.Location = new System.Drawing.Point(480, 14);
            this.spCantidadEquipos.Maximum = new decimal(new int[] {
            1661992959,
            1808227885,
            5,
            0});
            this.spCantidadEquipos.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spCantidadEquipos.Name = "spCantidadEquipos";
            this.spCantidadEquipos.Size = new System.Drawing.Size(72, 29);
            this.spCantidadEquipos.TabIndex = 112;
            this.spCantidadEquipos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.spCantidadEquipos.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(402, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 21);
            this.label3.TabIndex = 110;
            this.label3.Text = "Cantidad";
            // 
            // btnAgregarEquipo
            // 
            this.btnAgregarEquipo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnAgregarEquipo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregarEquipo.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnAgregarEquipo.FlatAppearance.BorderSize = 0;
            this.btnAgregarEquipo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnAgregarEquipo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnAgregarEquipo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarEquipo.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnAgregarEquipo.ForeColor = System.Drawing.Color.White;
            this.btnAgregarEquipo.Image = global::CapaPresentacion.Properties.Resources.Download_32;
            this.btnAgregarEquipo.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAgregarEquipo.Location = new System.Drawing.Point(566, 13);
            this.btnAgregarEquipo.Name = "btnAgregarEquipo";
            this.btnAgregarEquipo.Size = new System.Drawing.Size(116, 30);
            this.btnAgregarEquipo.TabIndex = 109;
            this.btnAgregarEquipo.Text = "Agregar";
            this.btnAgregarEquipo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgregarEquipo.UseVisualStyleBackColor = false;
            this.btnAgregarEquipo.Click += new System.EventHandler(this.btnAgregarEquipo_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 21);
            this.label1.TabIndex = 108;
            this.label1.Text = "Equipos";
            // 
            // dgvEquipos
            // 
            this.dgvEquipos.AllowUserToAddRows = false;
            this.dgvEquipos.AllowUserToDeleteRows = false;
            this.dgvEquipos.AllowUserToOrderColumns = true;
            this.dgvEquipos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvEquipos.BackgroundColor = System.Drawing.Color.White;
            this.dgvEquipos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvEquipos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.LightSlateGray;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI Light", 14F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvEquipos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvEquipos.ColumnHeadersHeight = 8;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI Light", 14F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvEquipos.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvEquipos.EnableHeadersVisualStyles = false;
            this.dgvEquipos.GridColor = System.Drawing.Color.WhiteSmoke;
            this.dgvEquipos.Location = new System.Drawing.Point(21, 48);
            this.dgvEquipos.MultiSelect = false;
            this.dgvEquipos.Name = "dgvEquipos";
            this.dgvEquipos.ReadOnly = true;
            this.dgvEquipos.RowHeadersVisible = false;
            this.dgvEquipos.RowHeadersWidth = 50;
            this.dgvEquipos.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvEquipos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEquipos.Size = new System.Drawing.Size(827, 171);
            this.dgvEquipos.TabIndex = 65;
            this.dgvEquipos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEquipos_CellContentClick);
            this.dgvEquipos.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgvEquipos_RowsAdded);
            // 
            // cboEquipos
            // 
            this.cboEquipos.BorderColor = System.Drawing.Color.Gainsboro;
            this.cboEquipos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEquipos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboEquipos.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboEquipos.FormattingEnabled = true;
            this.cboEquipos.Location = new System.Drawing.Point(82, 14);
            this.cboEquipos.Name = "cboEquipos";
            this.cboEquipos.Size = new System.Drawing.Size(297, 29);
            this.cboEquipos.TabIndex = 107;
            // 
            // tabPaquetes
            // 
            this.tabPaquetes.Controls.Add(this.dgvPaquetes);
            this.tabPaquetes.Location = new System.Drawing.Point(4, 34);
            this.tabPaquetes.Name = "tabPaquetes";
            this.tabPaquetes.Padding = new System.Windows.Forms.Padding(3);
            this.tabPaquetes.Size = new System.Drawing.Size(890, 225);
            this.tabPaquetes.TabIndex = 2;
            this.tabPaquetes.Text = "Paquetes";
            this.tabPaquetes.UseVisualStyleBackColor = true;
            // 
            // dgvPaquetes
            // 
            this.dgvPaquetes.AllowUserToAddRows = false;
            this.dgvPaquetes.AllowUserToDeleteRows = false;
            this.dgvPaquetes.AllowUserToOrderColumns = true;
            this.dgvPaquetes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPaquetes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPaquetes.BackgroundColor = System.Drawing.Color.White;
            this.dgvPaquetes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvPaquetes.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.LightSlateGray;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI Light", 14F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPaquetes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvPaquetes.ColumnHeadersHeight = 50;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI Light", 14F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPaquetes.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvPaquetes.EnableHeadersVisualStyles = false;
            this.dgvPaquetes.GridColor = System.Drawing.Color.WhiteSmoke;
            this.dgvPaquetes.Location = new System.Drawing.Point(32, 27);
            this.dgvPaquetes.MultiSelect = false;
            this.dgvPaquetes.Name = "dgvPaquetes";
            this.dgvPaquetes.ReadOnly = true;
            this.dgvPaquetes.RowHeadersVisible = false;
            this.dgvPaquetes.RowHeadersWidth = 50;
            this.dgvPaquetes.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvPaquetes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPaquetes.Size = new System.Drawing.Size(827, 170);
            this.dgvPaquetes.TabIndex = 79;
            // 
            // pnlFechas
            // 
            this.pnlFechas.Controls.Add(this.cboServicios_Categ);
            this.pnlFechas.Controls.Add(this.gbModalidad);
            this.pnlFechas.Controls.Add(this.label2);
            this.pnlFechas.Controls.Add(this.lblMesesServicio);
            this.pnlFechas.Controls.Add(this.spMesesServicio);
            this.pnlFechas.Controls.Add(this.lblMesesCobro);
            this.pnlFechas.Controls.Add(this.spMesesCobro);
            this.pnlFechas.Controls.Add(this.dtpFechaConexion);
            this.pnlFechas.Controls.Add(this.label9);
            this.pnlFechas.Controls.Add(this.label7);
            this.pnlFechas.Controls.Add(this.dtpFechaInicioServ);
            this.pnlFechas.Controls.Add(this.lblModalidadCantidad);
            this.pnlFechas.Controls.Add(this.label11);
            this.pnlFechas.Controls.Add(this.spUFuncional);
            this.pnlFechas.Controls.Add(this.lblModalidadCantidadPac);
            this.pnlFechas.Controls.Add(this.spUFuncionalPac);
            this.pnlFechas.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFechas.Location = new System.Drawing.Point(0, 56);
            this.pnlFechas.Name = "pnlFechas";
            this.pnlFechas.Size = new System.Drawing.Size(898, 244);
            this.pnlFechas.TabIndex = 123;
            // 
            // cboServicios_Categ
            // 
            this.cboServicios_Categ.BorderColor = System.Drawing.Color.Gainsboro;
            this.cboServicios_Categ.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboServicios_Categ.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboServicios_Categ.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboServicios_Categ.FormattingEnabled = true;
            this.cboServicios_Categ.Location = new System.Drawing.Point(486, 86);
            this.cboServicios_Categ.Name = "cboServicios_Categ";
            this.cboServicios_Categ.Size = new System.Drawing.Size(375, 33);
            this.cboServicios_Categ.TabIndex = 103;
            // 
            // gbModalidad
            // 
            this.gbModalidad.Controls.Add(this.rbUFuncionales);
            this.gbModalidad.Controls.Add(this.rbBocas);
            this.gbModalidad.Location = new System.Drawing.Point(486, 115);
            this.gbModalidad.Name = "gbModalidad";
            this.gbModalidad.Size = new System.Drawing.Size(375, 45);
            this.gbModalidad.TabIndex = 124;
            this.gbModalidad.TabStop = false;
            // 
            // rbUFuncionales
            // 
            this.rbUFuncionales.AutoSize = true;
            this.rbUFuncionales.Checked = true;
            this.rbUFuncionales.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbUFuncionales.Location = new System.Drawing.Point(6, 15);
            this.rbUFuncionales.Name = "rbUFuncionales";
            this.rbUFuncionales.Size = new System.Drawing.Size(189, 23);
            this.rbUFuncionales.TabIndex = 1;
            this.rbUFuncionales.TabStop = true;
            this.rbUFuncionales.Text = "UNIDADES FUNCIONALES";
            this.rbUFuncionales.UseVisualStyleBackColor = true;
            // 
            // rbBocas
            // 
            this.rbBocas.AutoSize = true;
            this.rbBocas.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbBocas.Location = new System.Drawing.Point(201, 15);
            this.rbBocas.Name = "rbBocas";
            this.rbBocas.Size = new System.Drawing.Size(71, 23);
            this.rbBocas.TabIndex = 0;
            this.rbBocas.Text = "BOCAS";
            this.rbBocas.UseVisualStyleBackColor = true;
            this.rbBocas.CheckedChanged += new System.EventHandler(this.rbBocas_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(377, 127);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 25);
            this.label2.TabIndex = 123;
            this.label2.Text = "Modalidad";
            // 
            // lblMesesServicio
            // 
            this.lblMesesServicio.AutoSize = true;
            this.lblMesesServicio.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.lblMesesServicio.ForeColor = System.Drawing.Color.Black;
            this.lblMesesServicio.Location = new System.Drawing.Point(310, 202);
            this.lblMesesServicio.Name = "lblMesesServicio";
            this.lblMesesServicio.Size = new System.Drawing.Size(170, 25);
            this.lblMesesServicio.TabIndex = 120;
            this.lblMesesServicio.Text = "Meses de Servicios";
            // 
            // spMesesServicio
            // 
            this.spMesesServicio.BorderColor = System.Drawing.Color.Empty;
            this.spMesesServicio.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spMesesServicio.Location = new System.Drawing.Point(486, 200);
            this.spMesesServicio.Maximum = new decimal(new int[] {
            1661992959,
            1808227885,
            5,
            0});
            this.spMesesServicio.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spMesesServicio.Name = "spMesesServicio";
            this.spMesesServicio.Size = new System.Drawing.Size(72, 33);
            this.spMesesServicio.TabIndex = 119;
            this.spMesesServicio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.spMesesServicio.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblMesesCobro
            // 
            this.lblMesesCobro.AutoSize = true;
            this.lblMesesCobro.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMesesCobro.ForeColor = System.Drawing.Color.Black;
            this.lblMesesCobro.Location = new System.Drawing.Point(564, 202);
            this.lblMesesCobro.Name = "lblMesesCobro";
            this.lblMesesCobro.Size = new System.Drawing.Size(148, 25);
            this.lblMesesCobro.TabIndex = 122;
            this.lblMesesCobro.Text = "Meses de Cobro";
            // 
            // spMesesCobro
            // 
            this.spMesesCobro.BorderColor = System.Drawing.Color.Empty;
            this.spMesesCobro.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spMesesCobro.Location = new System.Drawing.Point(718, 200);
            this.spMesesCobro.Maximum = new decimal(new int[] {
            1661992959,
            1808227885,
            5,
            0});
            this.spMesesCobro.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spMesesCobro.Name = "spMesesCobro";
            this.spMesesCobro.Size = new System.Drawing.Size(97, 33);
            this.spMesesCobro.TabIndex = 121;
            this.spMesesCobro.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.spMesesCobro.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // dtpFechaConexion
            // 
            this.dtpFechaConexion.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaConexion.Location = new System.Drawing.Point(486, 12);
            this.dtpFechaConexion.Name = "dtpFechaConexion";
            this.dtpFechaConexion.Size = new System.Drawing.Size(375, 33);
            this.dtpFechaConexion.TabIndex = 115;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.label9.Location = new System.Drawing.Point(281, 89);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(199, 25);
            this.label9.TabIndex = 106;
            this.label9.Text = "Categoria de Servicios";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.label7.Location = new System.Drawing.Point(206, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(274, 25);
            this.label7.TabIndex = 110;
            this.label7.Text = "Fecha de Conexión del Servicio";
            // 
            // dtpFechaInicioServ
            // 
            this.dtpFechaInicioServ.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaInicioServ.Location = new System.Drawing.Point(486, 49);
            this.dtpFechaInicioServ.Name = "dtpFechaInicioServ";
            this.dtpFechaInicioServ.Size = new System.Drawing.Size(375, 33);
            this.dtpFechaInicioServ.TabIndex = 118;
            // 
            // lblModalidadCantidad
            // 
            this.lblModalidadCantidad.AutoSize = true;
            this.lblModalidadCantidad.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.lblModalidadCantidad.ForeColor = System.Drawing.Color.Black;
            this.lblModalidadCantidad.Location = new System.Drawing.Point(419, 166);
            this.lblModalidadCantidad.Name = "lblModalidadCantidad";
            this.lblModalidadCantidad.Size = new System.Drawing.Size(61, 25);
            this.lblModalidadCantidad.TabIndex = 112;
            this.lblModalidadCantidad.Text = "Bocas";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.label11.Location = new System.Drawing.Point(240, 55);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(240, 25);
            this.label11.TabIndex = 117;
            this.label11.Text = "Fecha de Inicio del Servicio";
            // 
            // spUFuncional
            // 
            this.spUFuncional.BorderColor = System.Drawing.Color.Empty;
            this.spUFuncional.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spUFuncional.Location = new System.Drawing.Point(486, 164);
            this.spUFuncional.Maximum = new decimal(new int[] {
            1661992959,
            1808227885,
            5,
            0});
            this.spUFuncional.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spUFuncional.Name = "spUFuncional";
            this.spUFuncional.Size = new System.Drawing.Size(72, 33);
            this.spUFuncional.TabIndex = 111;
            this.spUFuncional.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.spUFuncional.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblModalidadCantidadPac
            // 
            this.lblModalidadCantidadPac.AutoSize = true;
            this.lblModalidadCantidadPac.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblModalidadCantidadPac.ForeColor = System.Drawing.Color.Black;
            this.lblModalidadCantidadPac.Location = new System.Drawing.Point(572, 166);
            this.lblModalidadCantidadPac.Name = "lblModalidadCantidadPac";
            this.lblModalidadCantidadPac.Size = new System.Drawing.Size(140, 25);
            this.lblModalidadCantidadPac.TabIndex = 114;
            this.lblModalidadCantidadPac.Text = "Bocas Pactadas";
            // 
            // spUFuncionalPac
            // 
            this.spUFuncionalPac.BorderColor = System.Drawing.Color.Empty;
            this.spUFuncionalPac.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spUFuncionalPac.Location = new System.Drawing.Point(718, 164);
            this.spUFuncionalPac.Maximum = new decimal(new int[] {
            1661992959,
            1808227885,
            5,
            0});
            this.spUFuncionalPac.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spUFuncionalPac.Name = "spUFuncionalPac";
            this.spUFuncionalPac.Size = new System.Drawing.Size(97, 33);
            this.spUFuncionalPac.TabIndex = 113;
            this.spUFuncionalPac.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.spUFuncionalPac.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // pnlBotones
            // 
            this.pnlBotones.Controls.Add(this.btnCancelar);
            this.pnlBotones.Controls.Add(this.btnConfirmar);
            this.pnlBotones.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBotones.Location = new System.Drawing.Point(0, 563);
            this.pnlBotones.Name = "pnlBotones";
            this.pnlBotones.Size = new System.Drawing.Size(898, 43);
            this.pnlBotones.TabIndex = 123;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Image = global::CapaPresentacion.Properties.Resources.Command_Redo_32;
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.Location = new System.Drawing.Point(795, 3);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(100, 35);
            this.btnCancelar.TabIndex = 121;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConfirmar.BackColor = System.Drawing.Color.SteelBlue;
            this.btnConfirmar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConfirmar.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
            this.btnConfirmar.FlatAppearance.BorderSize = 0;
            this.btnConfirmar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SteelBlue;
            this.btnConfirmar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SteelBlue;
            this.btnConfirmar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirmar.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirmar.ForeColor = System.Drawing.Color.White;
            this.btnConfirmar.Image = global::CapaPresentacion.Properties.Resources.Task_03_32;
            this.btnConfirmar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnConfirmar.Location = new System.Drawing.Point(665, 3);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(126, 35);
            this.btnConfirmar.TabIndex = 120;
            this.btnConfirmar.Text = "Confirmar";
            this.btnConfirmar.UseVisualStyleBackColor = false;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // pnlSuperior
            // 
            this.pnlSuperior.Controls.Add(this.lblServicio);
            this.pnlSuperior.Controls.Add(this.pnLinea1);
            this.pnlSuperior.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSuperior.Location = new System.Drawing.Point(0, 0);
            this.pnlSuperior.Name = "pnlSuperior";
            this.pnlSuperior.Size = new System.Drawing.Size(898, 56);
            this.pnlSuperior.TabIndex = 79;
            // 
            // lblServicio
            // 
            this.lblServicio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblServicio.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblServicio.ForeColor = System.Drawing.Color.Black;
            this.lblServicio.Location = new System.Drawing.Point(523, 11);
            this.lblServicio.Name = "lblServicio";
            this.lblServicio.Size = new System.Drawing.Size(364, 23);
            this.lblServicio.TabIndex = 108;
            this.lblServicio.Text = "[ SERVICIO ]";
            this.lblServicio.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pnLinea1
            // 
            this.pnLinea1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnLinea1.BackColor = System.Drawing.Color.Gainsboro;
            this.pnLinea1.Location = new System.Drawing.Point(-324, 46);
            this.pnLinea1.Name = "pnLinea1";
            this.pnLinea1.Size = new System.Drawing.Size(1210, 1);
            this.pnLinea1.TabIndex = 107;
            // 
            // frmParteConexion_Auxiliar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 608);
            this.Controls.Add(this.pnContent);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "frmParteConexion_Auxiliar";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmParteConexionAuxiliar";
            this.Load += new System.EventHandler(this.frmParteConexion_Auxiliar_Load);
            this.Shown += new System.EventHandler(this.frmParteConexion_Auxiliar_Shown);
            this.pnContent.ResumeLayout(false);
            this.pnlVelEqui.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabVelocidad.ResumeLayout(false);
            this.tabVelocidad.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVelocidades)).EndInit();
            this.tabEquipos.ResumeLayout(false);
            this.tabEquipos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spCantidadEquipos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEquipos)).EndInit();
            this.tabPaquetes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPaquetes)).EndInit();
            this.pnlFechas.ResumeLayout(false);
            this.pnlFechas.PerformLayout();
            this.gbModalidad.ResumeLayout(false);
            this.gbModalidad.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spMesesServicio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spMesesCobro)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spUFuncional)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spUFuncionalPac)).EndInit();
            this.pnlBotones.ResumeLayout(false);
            this.pnlSuperior.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnContent;
        private System.Windows.Forms.DateTimePicker dtpFechaInicioServ;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DateTimePicker dtpFechaConexion;
        private Controles.spinner spUFuncionalPac;
        private System.Windows.Forms.Label lblModalidadCantidadPac;
        private Controles.spinner spUFuncional;
        private System.Windows.Forms.Label lblModalidadCantidad;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblServicio;
        private System.Windows.Forms.Panel pnLinea1;
        private System.Windows.Forms.Label label9;
        private Controles.combo cboServicios_Categ;
        private Controles.boton btnCancelar;
        private Controles.boton btnConfirmar;
        private System.Windows.Forms.Panel pnlFechas;
        private System.Windows.Forms.Panel pnlBotones;
        private System.Windows.Forms.Panel pnlSuperior;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabVelocidad;
        private Controles.dgv dgvVelocidades;
        private System.Windows.Forms.CheckBox chkIPFija;
        private System.Windows.Forms.TabPage tabEquipos;
        private Controles.boton btnAgregarEquipo;
        private System.Windows.Forms.Label label1;
        private Controles.combo cboEquipos;
        private Controles.dgv dgvEquipos;
        private System.Windows.Forms.Panel pnlVelEqui;
        private System.Windows.Forms.Label lblMesesServicio;
        private Controles.spinner spMesesServicio;
        private System.Windows.Forms.Label lblMesesCobro;
        private Controles.spinner spMesesCobro;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox gbModalidad;
        private System.Windows.Forms.RadioButton rbUFuncionales;
        private System.Windows.Forms.RadioButton rbBocas;
        private System.Windows.Forms.TabPage tabPaquetes;
        private Controles.dgv dgvPaquetes;
        private Controles.spinner spCantidadEquipos;
        private System.Windows.Forms.Label label3;
    }
}