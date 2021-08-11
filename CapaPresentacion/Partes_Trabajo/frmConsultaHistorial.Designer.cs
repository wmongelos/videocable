namespace CapaPresentacion.Partes_Trabajo
{
    partial class frmConsultaHistorial
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
            this.panel3 = new System.Windows.Forms.Panel();
            this.imgVolver = new System.Windows.Forms.PictureBox();
            this.imgReturn = new System.Windows.Forms.PictureBox();
            this.lblTituloHeader = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panelFecha = new System.Windows.Forms.Panel();
            this.boton1 = new CapaPresentacion.Controles.boton();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dgv = new CapaPresentacion.Controles.dgv(this.components);
            this.btnSelecServicios = new CapaPresentacion.Controles.boton();
            this.btnSelecPersonal = new CapaPresentacion.Controles.boton();
            this.btnSelecAreaPersonal = new CapaPresentacion.Controles.boton();
            this.btnSelecOperacion = new CapaPresentacion.Controles.boton();
            this.btnSelecLocalidad = new CapaPresentacion.Controles.boton();
            this.btnSelecZonas = new CapaPresentacion.Controles.boton();
            this.btnSelecEstados = new CapaPresentacion.Controles.boton();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgVolver)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgReturn)).BeginInit();
            this.panelFecha.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.panel3.Controls.Add(this.imgVolver);
            this.panel3.Controls.Add(this.imgReturn);
            this.panel3.Controls.Add(this.lblTituloHeader);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1044, 98);
            this.panel3.TabIndex = 155;
            // 
            // imgVolver
            // 
            this.imgVolver.Cursor = System.Windows.Forms.Cursors.Hand;
            this.imgVolver.Enabled = false;
            this.imgVolver.Image = global::CapaPresentacion.Properties.Resources.Arrowhead_Right_32;
            this.imgVolver.Location = new System.Drawing.Point(1315, 32);
            this.imgVolver.Name = "imgVolver";
            this.imgVolver.Size = new System.Drawing.Size(32, 32);
            this.imgVolver.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgVolver.TabIndex = 33;
            this.imgVolver.TabStop = false;
            this.imgVolver.Click += new System.EventHandler(this.imgVolver_Click);
            // 
            // imgReturn
            // 
            this.imgReturn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.imgReturn.Image = global::CapaPresentacion.Properties.Resources.Left_Arrow_32;
            this.imgReturn.Location = new System.Drawing.Point(15, 32);
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
            this.lblTituloHeader.Location = new System.Drawing.Point(53, 37);
            this.lblTituloHeader.Name = "lblTituloHeader";
            this.lblTituloHeader.Size = new System.Drawing.Size(338, 27);
            this.lblTituloHeader.TabIndex = 31;
            this.lblTituloHeader.Text = "Consulta historial partes";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Light", 12F);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(16, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 21);
            this.label1.TabIndex = 340;
            this.label1.Text = "Desde:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Light", 12F);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(187, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 21);
            this.label2.TabIndex = 341;
            this.label2.Text = "Hasta:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Light", 12F);
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(363, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(97, 21);
            this.label6.TabIndex = 363;
            this.label6.Text = "Por fecha de:";
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Font = new System.Drawing.Font("Segoe UI Light", 12F);
            this.radioButton3.Location = new System.Drawing.Point(675, 13);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(92, 25);
            this.radioButton3.TabIndex = 353;
            this.radioButton3.Tag = "3";
            this.radioButton3.Text = "Realizado";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Font = new System.Drawing.Font("Segoe UI Light", 12F);
            this.radioButton2.Location = new System.Drawing.Point(557, 13);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(112, 25);
            this.radioButton2.TabIndex = 352;
            this.radioButton2.Tag = "1";
            this.radioButton2.Text = "Programado";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // dtpHasta
            // 
            this.dtpHasta.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpHasta.Location = new System.Drawing.Point(240, 9);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(107, 29);
            this.dtpHasta.TabIndex = 362;
            // 
            // dtpDesde
            // 
            this.dtpDesde.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDesde.Location = new System.Drawing.Point(74, 9);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(107, 29);
            this.dtpDesde.TabIndex = 361;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Font = new System.Drawing.Font("Segoe UI Light", 12F);
            this.radioButton1.Location = new System.Drawing.Point(466, 13);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(85, 25);
            this.radioButton1.TabIndex = 351;
            this.radioButton1.TabStop = true;
            this.radioButton1.Tag = "0";
            this.radioButton1.Text = "Reclamo";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 98);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1044, 1);
            this.panel1.TabIndex = 355;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 99);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1044, 1);
            this.panel2.TabIndex = 357;
            // 
            // panelFecha
            // 
            this.panelFecha.Controls.Add(this.dtpDesde);
            this.panelFecha.Controls.Add(this.label1);
            this.panelFecha.Controls.Add(this.label6);
            this.panelFecha.Controls.Add(this.label2);
            this.panelFecha.Controls.Add(this.radioButton3);
            this.panelFecha.Controls.Add(this.radioButton1);
            this.panelFecha.Controls.Add(this.radioButton2);
            this.panelFecha.Controls.Add(this.dtpHasta);
            this.panelFecha.Controls.Add(this.boton1);
            this.panelFecha.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelFecha.Location = new System.Drawing.Point(0, 100);
            this.panelFecha.Name = "panelFecha";
            this.panelFecha.Size = new System.Drawing.Size(1044, 50);
            this.panelFecha.TabIndex = 358;
            // 
            // boton1
            // 
            this.boton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.boton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.boton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.boton1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.boton1.FlatAppearance.BorderSize = 0;
            this.boton1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.boton1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.boton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.boton1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.boton1.ForeColor = System.Drawing.Color.White;
            this.boton1.Image = global::CapaPresentacion.Properties.Resources.lupa;
            this.boton1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.boton1.Location = new System.Drawing.Point(922, 10);
            this.boton1.Name = "boton1";
            this.boton1.Size = new System.Drawing.Size(110, 30);
            this.boton1.TabIndex = 344;
            this.boton1.Tag = "";
            this.boton1.Text = "Consultar";
            this.boton1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.boton1.UseVisualStyleBackColor = false;
            this.boton1.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 150);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1044, 1);
            this.panel4.TabIndex = 359;
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AllowUserToResizeColumns = false;
            this.dgv.AllowUserToResizeRows = false;
            this.dgv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv.BackgroundColor = System.Drawing.Color.White;
            this.dgv.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgv.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.DarkGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI Light", 14F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgv.EnableHeadersVisualStyles = false;
            this.dgv.GridColor = System.Drawing.Color.WhiteSmoke;
            this.dgv.Location = new System.Drawing.Point(271, 168);
            this.dgv.MultiSelect = false;
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersVisible = false;
            this.dgv.RowHeadersWidth = 50;
            this.dgv.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(748, 366);
            this.dgv.TabIndex = 384;
            // 
            // btnSelecServicios
            // 
            this.btnSelecServicios.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnSelecServicios.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSelecServicios.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnSelecServicios.FlatAppearance.BorderSize = 0;
            this.btnSelecServicios.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnSelecServicios.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnSelecServicios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelecServicios.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelecServicios.ForeColor = System.Drawing.Color.White;
            this.btnSelecServicios.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSelecServicios.Location = new System.Drawing.Point(30, 168);
            this.btnSelecServicios.Name = "btnSelecServicios";
            this.btnSelecServicios.Size = new System.Drawing.Size(218, 30);
            this.btnSelecServicios.TabIndex = 383;
            this.btnSelecServicios.Text = "Seleccionar servicios";
            this.btnSelecServicios.UseVisualStyleBackColor = true;
            this.btnSelecServicios.Click += new System.EventHandler(this.btnSelecServicios_Click);
            // 
            // btnSelecPersonal
            // 
            this.btnSelecPersonal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnSelecPersonal.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSelecPersonal.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnSelecPersonal.FlatAppearance.BorderSize = 0;
            this.btnSelecPersonal.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnSelecPersonal.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnSelecPersonal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelecPersonal.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelecPersonal.ForeColor = System.Drawing.Color.White;
            this.btnSelecPersonal.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSelecPersonal.Location = new System.Drawing.Point(30, 262);
            this.btnSelecPersonal.Name = "btnSelecPersonal";
            this.btnSelecPersonal.Size = new System.Drawing.Size(218, 30);
            this.btnSelecPersonal.TabIndex = 381;
            this.btnSelecPersonal.Text = "Seleccionar personal";
            this.btnSelecPersonal.UseVisualStyleBackColor = true;
            this.btnSelecPersonal.Click += new System.EventHandler(this.btnSelecPersonal_Click);
            // 
            // btnSelecAreaPersonal
            // 
            this.btnSelecAreaPersonal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnSelecAreaPersonal.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSelecAreaPersonal.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnSelecAreaPersonal.FlatAppearance.BorderSize = 0;
            this.btnSelecAreaPersonal.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnSelecAreaPersonal.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnSelecAreaPersonal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelecAreaPersonal.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelecAreaPersonal.ForeColor = System.Drawing.Color.White;
            this.btnSelecAreaPersonal.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSelecAreaPersonal.Location = new System.Drawing.Point(30, 215);
            this.btnSelecAreaPersonal.Name = "btnSelecAreaPersonal";
            this.btnSelecAreaPersonal.Size = new System.Drawing.Size(218, 30);
            this.btnSelecAreaPersonal.TabIndex = 379;
            this.btnSelecAreaPersonal.Text = "Seleccionar area personal";
            this.btnSelecAreaPersonal.UseVisualStyleBackColor = true;
            this.btnSelecAreaPersonal.Click += new System.EventHandler(this.btnSelecAreaPersonal_Click);
            // 
            // btnSelecOperacion
            // 
            this.btnSelecOperacion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnSelecOperacion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSelecOperacion.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnSelecOperacion.FlatAppearance.BorderSize = 0;
            this.btnSelecOperacion.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnSelecOperacion.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnSelecOperacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelecOperacion.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelecOperacion.ForeColor = System.Drawing.Color.White;
            this.btnSelecOperacion.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSelecOperacion.Location = new System.Drawing.Point(30, 450);
            this.btnSelecOperacion.Name = "btnSelecOperacion";
            this.btnSelecOperacion.Size = new System.Drawing.Size(218, 30);
            this.btnSelecOperacion.TabIndex = 377;
            this.btnSelecOperacion.Text = "Seleccionar operaciones";
            this.btnSelecOperacion.UseVisualStyleBackColor = true;
            this.btnSelecOperacion.Click += new System.EventHandler(this.btnSelecOperacion_Click);
            // 
            // btnSelecLocalidad
            // 
            this.btnSelecLocalidad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnSelecLocalidad.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSelecLocalidad.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnSelecLocalidad.FlatAppearance.BorderSize = 0;
            this.btnSelecLocalidad.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnSelecLocalidad.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnSelecLocalidad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelecLocalidad.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelecLocalidad.ForeColor = System.Drawing.Color.White;
            this.btnSelecLocalidad.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSelecLocalidad.Location = new System.Drawing.Point(30, 403);
            this.btnSelecLocalidad.Name = "btnSelecLocalidad";
            this.btnSelecLocalidad.Size = new System.Drawing.Size(218, 30);
            this.btnSelecLocalidad.TabIndex = 375;
            this.btnSelecLocalidad.Text = "Seleccionar localidades";
            this.btnSelecLocalidad.UseVisualStyleBackColor = true;
            this.btnSelecLocalidad.Click += new System.EventHandler(this.btnSelecLocalidad_Click);
            // 
            // btnSelecZonas
            // 
            this.btnSelecZonas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnSelecZonas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSelecZonas.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnSelecZonas.FlatAppearance.BorderSize = 0;
            this.btnSelecZonas.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnSelecZonas.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnSelecZonas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelecZonas.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelecZonas.ForeColor = System.Drawing.Color.White;
            this.btnSelecZonas.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSelecZonas.Location = new System.Drawing.Point(30, 356);
            this.btnSelecZonas.Name = "btnSelecZonas";
            this.btnSelecZonas.Size = new System.Drawing.Size(218, 30);
            this.btnSelecZonas.TabIndex = 373;
            this.btnSelecZonas.Text = "Seleccionar zonas";
            this.btnSelecZonas.UseVisualStyleBackColor = true;
            this.btnSelecZonas.Click += new System.EventHandler(this.btnSelecZonas_Click);
            // 
            // btnSelecEstados
            // 
            this.btnSelecEstados.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnSelecEstados.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSelecEstados.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnSelecEstados.FlatAppearance.BorderSize = 0;
            this.btnSelecEstados.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnSelecEstados.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnSelecEstados.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelecEstados.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelecEstados.ForeColor = System.Drawing.Color.White;
            this.btnSelecEstados.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSelecEstados.Location = new System.Drawing.Point(30, 309);
            this.btnSelecEstados.Name = "btnSelecEstados";
            this.btnSelecEstados.Size = new System.Drawing.Size(218, 30);
            this.btnSelecEstados.TabIndex = 371;
            this.btnSelecEstados.Text = "Seleccionar estados";
            this.btnSelecEstados.UseVisualStyleBackColor = true;
            this.btnSelecEstados.Click += new System.EventHandler(this.btnSelecEstados_Click);
            // 
            // frmConsultaHistorial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1044, 565);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.btnSelecServicios);
            this.Controls.Add(this.btnSelecPersonal);
            this.Controls.Add(this.btnSelecAreaPersonal);
            this.Controls.Add(this.btnSelecOperacion);
            this.Controls.Add(this.btnSelecLocalidad);
            this.Controls.Add(this.btnSelecZonas);
            this.Controls.Add(this.btnSelecEstados);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panelFecha);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "frmConsultaHistorial";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmConsultaPartes";
            this.Load += new System.EventHandler(this.frmConsultaHistorial_Load);
            this.Shown += new System.EventHandler(this.frmConsultaHistorial_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmConsultaHistorial_KeyDown);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgVolver)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgReturn)).EndInit();
            this.panelFecha.ResumeLayout(false);
            this.panelFecha.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox imgReturn;
        private System.Windows.Forms.Label lblTituloHeader;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panelFecha;
        private System.Windows.Forms.Panel panel4;
        private Controles.boton boton1;
        private System.Windows.Forms.PictureBox imgVolver;
        private Controles.boton btnSelecEstados;
        private Controles.boton btnSelecZonas;
        private Controles.boton btnSelecLocalidad;
        private Controles.boton btnSelecOperacion;
        private Controles.boton btnSelecAreaPersonal;
        private Controles.boton btnSelecPersonal;
        private Controles.boton btnSelecServicios;
        private Controles.dgv dgv;
    }
}