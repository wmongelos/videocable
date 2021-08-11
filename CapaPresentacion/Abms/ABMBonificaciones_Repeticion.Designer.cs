namespace CapaPresentacion.Abms
{
    partial class ABMBonificaciones_Repeticion
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
            this.panel6 = new System.Windows.Forms.Panel();
            this.lblPorcentajePorItem = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblRepeticion = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblItemRepeticion = new System.Windows.Forms.Label();
            this.lblPorcentaje = new System.Windows.Forms.Label();
            this.lblAplicacionDesde = new System.Windows.Forms.Label();
            this.lblAplicacionHasta = new System.Windows.Forms.Label();
            this.chkHasta = new System.Windows.Forms.CheckBox();
            this.btnEliminar = new CapaPresentacion.Controles.boton();
            this.cboLimiteDesde = new CapaPresentacion.Controles.combo(this.components);
            this.spItemHasta = new CapaPresentacion.Controles.spinner(this.components);
            this.spCantidadAContemplar = new CapaPresentacion.Controles.spinner(this.components);
            this.spItemDesde = new CapaPresentacion.Controles.spinner(this.components);
            this.btnNuevo = new CapaPresentacion.Controles.boton();
            this.btnGuardar = new CapaPresentacion.Controles.boton();
            this.spPorcentaje = new CapaPresentacion.Controles.spinner(this.components);
            this.dgvPorcentajes = new CapaPresentacion.Controles.dgv(this.components);
            this.pnFooter = new System.Windows.Forms.Panel();
            this.lblTotal = new System.Windows.Forms.Label();
            this.pgCircular = new CapaPresentacion.Controles.progress();
            this.btnEditar = new CapaPresentacion.Controles.boton();
            this.panelControles = new System.Windows.Forms.Panel();
            this.lblAplicacion = new System.Windows.Forms.Label();
            this.lblBonificacion = new System.Windows.Forms.Label();
            this.btnActualizar = new CapaPresentacion.Controles.boton();
            this.btnCancelar = new CapaPresentacion.Controles.boton();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spItemHasta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spCantidadAContemplar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spItemDesde)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spPorcentaje)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPorcentajes)).BeginInit();
            this.pnFooter.SuspendLayout();
            this.panelControles.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel6
            // 
            this.panel6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel6.BackColor = System.Drawing.Color.Gainsboro;
            this.panel6.Location = new System.Drawing.Point(0, 122);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(1093, 1);
            this.panel6.TabIndex = 347;
            // 
            // lblPorcentajePorItem
            // 
            this.lblPorcentajePorItem.AutoSize = true;
            this.lblPorcentajePorItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPorcentajePorItem.ForeColor = System.Drawing.Color.Black;
            this.lblPorcentajePorItem.Location = new System.Drawing.Point(7, 259);
            this.lblPorcentajePorItem.Name = "lblPorcentajePorItem";
            this.lblPorcentajePorItem.Size = new System.Drawing.Size(162, 21);
            this.lblPorcentajePorItem.TabIndex = 345;
            this.lblPorcentajePorItem.Text = "Porcentajes aplicados:";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.panel5.Controls.Add(this.pictureBox1);
            this.panel5.Controls.Add(this.label1);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1093, 75);
            this.panel5.TabIndex = 341;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = global::CapaPresentacion.Properties.Resources.Left_Arrow_32;
            this.pictureBox1.Location = new System.Drawing.Point(15, 22);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 32;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI Light", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(53, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(385, 23);
            this.label1.TabIndex = 31;
            this.label1.Text = "Repetición de unidades pactadas";
            // 
            // lblRepeticion
            // 
            this.lblRepeticion.AutoSize = true;
            this.lblRepeticion.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRepeticion.ForeColor = System.Drawing.Color.Black;
            this.lblRepeticion.Location = new System.Drawing.Point(7, 168);
            this.lblRepeticion.Name = "lblRepeticion";
            this.lblRepeticion.Size = new System.Drawing.Size(362, 21);
            this.lblRepeticion.TabIndex = 352;
            this.lblRepeticion.Text = "N° de unidades funcionales pactadas a contemplar:";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.Location = new System.Drawing.Point(0, 204);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1093, 1);
            this.panel1.TabIndex = 348;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.Gainsboro;
            this.panel2.Location = new System.Drawing.Point(0, 255);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1093, 1);
            this.panel2.TabIndex = 349;
            // 
            // lblItemRepeticion
            // 
            this.lblItemRepeticion.AutoSize = true;
            this.lblItemRepeticion.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItemRepeticion.ForeColor = System.Drawing.Color.Black;
            this.lblItemRepeticion.Location = new System.Drawing.Point(35, 350);
            this.lblItemRepeticion.Name = "lblItemRepeticion";
            this.lblItemRepeticion.Size = new System.Drawing.Size(256, 21);
            this.lblItemRepeticion.TabIndex = 353;
            this.lblItemRepeticion.Text = "Determine los porcentajes a aplicar:";
            // 
            // lblPorcentaje
            // 
            this.lblPorcentaje.AutoSize = true;
            this.lblPorcentaje.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPorcentaje.ForeColor = System.Drawing.Color.Black;
            this.lblPorcentaje.Location = new System.Drawing.Point(7, 10);
            this.lblPorcentaje.Name = "lblPorcentaje";
            this.lblPorcentaje.Size = new System.Drawing.Size(86, 21);
            this.lblPorcentaje.TabIndex = 348;
            this.lblPorcentaje.Text = "Porcentaje:";
            // 
            // lblAplicacionDesde
            // 
            this.lblAplicacionDesde.AutoSize = true;
            this.lblAplicacionDesde.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAplicacionDesde.ForeColor = System.Drawing.Color.Black;
            this.lblAplicacionDesde.Location = new System.Drawing.Point(292, 12);
            this.lblAplicacionDesde.Name = "lblAplicacionDesde";
            this.lblAplicacionDesde.Size = new System.Drawing.Size(248, 21);
            this.lblAplicacionDesde.TabIndex = 342;
            this.lblAplicacionDesde.Text = "Aplicar desde la unidad pactada n°";
            // 
            // lblAplicacionHasta
            // 
            this.lblAplicacionHasta.AutoSize = true;
            this.lblAplicacionHasta.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAplicacionHasta.ForeColor = System.Drawing.Color.Black;
            this.lblAplicacionHasta.Location = new System.Drawing.Point(701, 12);
            this.lblAplicacionHasta.Name = "lblAplicacionHasta";
            this.lblAplicacionHasta.Size = new System.Drawing.Size(194, 21);
            this.lblAplicacionHasta.TabIndex = 356;
            this.lblAplicacionHasta.Text = "Hasta la unidad pactada n°";
            // 
            // chkHasta
            // 
            this.chkHasta.AutoSize = true;
            this.chkHasta.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.chkHasta.Location = new System.Drawing.Point(971, 14);
            this.chkHasta.Name = "chkHasta";
            this.chkHasta.Size = new System.Drawing.Size(15, 14);
            this.chkHasta.TabIndex = 359;
            this.chkHasta.UseVisualStyleBackColor = true;
            this.chkHasta.CheckedChanged += new System.EventHandler(this.chkHasta_CheckedChanged);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEliminar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnEliminar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminar.Enabled = false;
            this.btnEliminar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnEliminar.FlatAppearance.BorderSize = 0;
            this.btnEliminar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnEliminar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.ForeColor = System.Drawing.Color.White;
            this.btnEliminar.Image = global::CapaPresentacion.Properties.Resources.Data_Delete_32;
            this.btnEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEliminar.Location = new System.Drawing.Point(739, 81);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(110, 35);
            this.btnEliminar.TabIndex = 361;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // cboLimiteDesde
            // 
            this.cboLimiteDesde.BorderColor = System.Drawing.Color.Gainsboro;
            this.cboLimiteDesde.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLimiteDesde.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboLimiteDesde.Font = new System.Drawing.Font("Segoe UI Light", 12F);
            this.cboLimiteDesde.FormattingEnabled = true;
            this.cboLimiteDesde.Items.AddRange(new object[] {
            "=",
            ">"});
            this.cboLimiteDesde.Location = new System.Drawing.Point(546, 7);
            this.cboLimiteDesde.Name = "cboLimiteDesde";
            this.cboLimiteDesde.Size = new System.Drawing.Size(55, 29);
            this.cboLimiteDesde.TabIndex = 357;
            // 
            // spItemHasta
            // 
            this.spItemHasta.BorderColor = System.Drawing.Color.Empty;
            this.spItemHasta.Enabled = false;
            this.spItemHasta.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.spItemHasta.Location = new System.Drawing.Point(902, 8);
            this.spItemHasta.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spItemHasta.Name = "spItemHasta";
            this.spItemHasta.Size = new System.Drawing.Size(63, 29);
            this.spItemHasta.TabIndex = 357;
            this.spItemHasta.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // spCantidadAContemplar
            // 
            this.spCantidadAContemplar.BorderColor = System.Drawing.Color.Empty;
            this.spCantidadAContemplar.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.spCantidadAContemplar.Location = new System.Drawing.Point(375, 166);
            this.spCantidadAContemplar.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spCantidadAContemplar.Name = "spCantidadAContemplar";
            this.spCantidadAContemplar.Size = new System.Drawing.Size(63, 29);
            this.spCantidadAContemplar.TabIndex = 351;
            this.spCantidadAContemplar.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spCantidadAContemplar.ValueChanged += new System.EventHandler(this.spCantidadAContemplar_ValueChanged);
            // 
            // spItemDesde
            // 
            this.spItemDesde.BorderColor = System.Drawing.Color.Empty;
            this.spItemDesde.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.spItemDesde.Location = new System.Drawing.Point(607, 8);
            this.spItemDesde.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spItemDesde.Name = "spItemDesde";
            this.spItemDesde.Size = new System.Drawing.Size(63, 29);
            this.spItemDesde.TabIndex = 343;
            this.spItemDesde.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnNuevo
            // 
            this.btnNuevo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNuevo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnNuevo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNuevo.Enabled = false;
            this.btnNuevo.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnNuevo.FlatAppearance.BorderSize = 0;
            this.btnNuevo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnNuevo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevo.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevo.ForeColor = System.Drawing.Color.White;
            this.btnNuevo.Image = global::CapaPresentacion.Properties.Resources.Data_Add_32;
            this.btnNuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNuevo.Location = new System.Drawing.Point(733, 163);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(171, 35);
            this.btnNuevo.TabIndex = 355;
            this.btnNuevo.Text = "Agregar porcentaje";
            this.btnNuevo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNuevo.UseVisualStyleBackColor = false;
            this.btnNuevo.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.Enabled = false;
            this.btnGuardar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnGuardar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Image = global::CapaPresentacion.Properties.Resources.Save_32;
            this.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGuardar.Location = new System.Drawing.Point(855, 81);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(110, 35);
            this.btnGuardar.TabIndex = 346;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // spPorcentaje
            // 
            this.spPorcentaje.BorderColor = System.Drawing.Color.Empty;
            this.spPorcentaje.DecimalPlaces = 2;
            this.spPorcentaje.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.spPorcentaje.Location = new System.Drawing.Point(99, 10);
            this.spPorcentaje.Name = "spPorcentaje";
            this.spPorcentaje.Size = new System.Drawing.Size(119, 29);
            this.spPorcentaje.TabIndex = 349;
            // 
            // dgvPorcentajes
            // 
            this.dgvPorcentajes.AllowUserToAddRows = false;
            this.dgvPorcentajes.AllowUserToDeleteRows = false;
            this.dgvPorcentajes.AllowUserToOrderColumns = true;
            this.dgvPorcentajes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPorcentajes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPorcentajes.BackgroundColor = System.Drawing.Color.White;
            this.dgvPorcentajes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvPorcentajes.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.LightSlateGray;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPorcentajes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvPorcentajes.ColumnHeadersHeight = 40;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPorcentajes.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvPorcentajes.EnableHeadersVisualStyles = false;
            this.dgvPorcentajes.GridColor = System.Drawing.Color.WhiteSmoke;
            this.dgvPorcentajes.Location = new System.Drawing.Point(12, 283);
            this.dgvPorcentajes.MultiSelect = false;
            this.dgvPorcentajes.Name = "dgvPorcentajes";
            this.dgvPorcentajes.ReadOnly = true;
            this.dgvPorcentajes.RowHeadersVisible = false;
            this.dgvPorcentajes.RowHeadersWidth = 50;
            this.dgvPorcentajes.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvPorcentajes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPorcentajes.Size = new System.Drawing.Size(1069, 205);
            this.dgvPorcentajes.TabIndex = 344;
            this.dgvPorcentajes.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPorcentajes_CellClick);
            this.dgvPorcentajes.SelectionChanged += new System.EventHandler(this.dgvPorcentajes_SelectionChanged);
            // 
            // pnFooter
            // 
            this.pnFooter.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnFooter.Controls.Add(this.lblTotal);
            this.pnFooter.Controls.Add(this.pgCircular);
            this.pnFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnFooter.Location = new System.Drawing.Point(0, 494);
            this.pnFooter.Name = "pnFooter";
            this.pnFooter.Size = new System.Drawing.Size(1093, 30);
            this.pnFooter.TabIndex = 362;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.ForeColor = System.Drawing.Color.SlateGray;
            this.lblTotal.Location = new System.Drawing.Point(12, 8);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(111, 13);
            this.lblTotal.TabIndex = 13;
            this.lblTotal.Text = "Total de Registros: 0";
            // 
            // pgCircular
            // 
            this.pgCircular.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pgCircular.Location = new System.Drawing.Point(1057, 2);
            this.pgCircular.Name = "pgCircular";
            this.pgCircular.Percentage = 0F;
            this.pgCircular.Rotation = CapaPresentacion.Controles.RotationType.CounterClockwise;
            this.pgCircular.Size = new System.Drawing.Size(24, 24);
            this.pgCircular.TabIndex = 0;
            // 
            // btnEditar
            // 
            this.btnEditar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnEditar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditar.Enabled = false;
            this.btnEditar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnEditar.FlatAppearance.BorderSize = 0;
            this.btnEditar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnEditar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnEditar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditar.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditar.ForeColor = System.Drawing.Color.White;
            this.btnEditar.Image = global::CapaPresentacion.Properties.Resources.Data_Edit_32__1_;
            this.btnEditar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEditar.Location = new System.Drawing.Point(910, 163);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(171, 35);
            this.btnEditar.TabIndex = 363;
            this.btnEditar.Text = "Editar porcentaje";
            this.btnEditar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEditar.UseVisualStyleBackColor = false;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // panelControles
            // 
            this.panelControles.Controls.Add(this.lblAplicacionDesde);
            this.panelControles.Controls.Add(this.spPorcentaje);
            this.panelControles.Controls.Add(this.lblPorcentaje);
            this.panelControles.Controls.Add(this.spItemDesde);
            this.panelControles.Controls.Add(this.cboLimiteDesde);
            this.panelControles.Controls.Add(this.spItemHasta);
            this.panelControles.Controls.Add(this.chkHasta);
            this.panelControles.Controls.Add(this.lblAplicacionHasta);
            this.panelControles.Enabled = false;
            this.panelControles.Location = new System.Drawing.Point(0, 210);
            this.panelControles.Name = "panelControles";
            this.panelControles.Size = new System.Drawing.Size(1069, 43);
            this.panelControles.TabIndex = 364;
            // 
            // lblAplicacion
            // 
            this.lblAplicacion.AutoSize = true;
            this.lblAplicacion.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAplicacion.ForeColor = System.Drawing.Color.Black;
            this.lblAplicacion.Location = new System.Drawing.Point(7, 147);
            this.lblAplicacion.Name = "lblAplicacion";
            this.lblAplicacion.Size = new System.Drawing.Size(0, 21);
            this.lblAplicacion.TabIndex = 366;
            // 
            // lblBonificacion
            // 
            this.lblBonificacion.AutoSize = true;
            this.lblBonificacion.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBonificacion.ForeColor = System.Drawing.Color.Black;
            this.lblBonificacion.Location = new System.Drawing.Point(7, 126);
            this.lblBonificacion.Name = "lblBonificacion";
            this.lblBonificacion.Size = new System.Drawing.Size(97, 21);
            this.lblBonificacion.TabIndex = 365;
            this.lblBonificacion.Text = "Bonificación:";
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
            this.btnActualizar.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActualizar.ForeColor = System.Drawing.Color.White;
            this.btnActualizar.Image = global::CapaPresentacion.Properties.Resources.Command_Refresh_32;
            this.btnActualizar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnActualizar.Location = new System.Drawing.Point(623, 81);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(110, 35);
            this.btnActualizar.TabIndex = 367;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnActualizar.UseVisualStyleBackColor = false;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.Enabled = false;
            this.btnCancelar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Image = global::CapaPresentacion.Properties.Resources.Command_Redo_32;
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.Location = new System.Drawing.Point(971, 81);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(110, 35);
            this.btnCancelar.TabIndex = 368;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // ABMBonificaciones_Repeticion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(250)))), ((int)(((byte)(251)))));
            this.ClientSize = new System.Drawing.Size(1093, 524);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.lblAplicacion);
            this.Controls.Add(this.lblBonificacion);
            this.Controls.Add(this.panelControles);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.pnFooter);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblRepeticion);
            this.Controls.Add(this.spCantidadAContemplar);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.lblPorcentajePorItem);
            this.Controls.Add(this.dgvPorcentajes);
            this.Controls.Add(this.lblItemRepeticion);
            this.Controls.Add(this.panel5);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "ABMBonificaciones_Repeticion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmRepeticion";
            this.Load += new System.EventHandler(this.frmRepeticion_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmRepeticion_KeyDown);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spItemHasta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spCantidadAContemplar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spItemDesde)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spPorcentaje)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPorcentajes)).EndInit();
            this.pnFooter.ResumeLayout(false);
            this.pnFooter.PerformLayout();
            this.panelControles.ResumeLayout(false);
            this.panelControles.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel6;
        private Controles.boton btnGuardar;
        private System.Windows.Forms.Label lblPorcentajePorItem;
        private Controles.dgv dgvPorcentajes;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private Controles.spinner spCantidadAContemplar;
        private System.Windows.Forms.Label lblRepeticion;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblItemRepeticion;
        private Controles.spinner spPorcentaje;
        private System.Windows.Forms.Label lblPorcentaje;
        private Controles.boton btnNuevo;
        private System.Windows.Forms.Label lblAplicacionDesde;
        private Controles.spinner spItemDesde;
        private System.Windows.Forms.Label lblAplicacionHasta;
        private Controles.spinner spItemHasta;
        private System.Windows.Forms.CheckBox chkHasta;
        private Controles.combo cboLimiteDesde;
        private Controles.boton btnEliminar;
        private System.Windows.Forms.Panel pnFooter;
        private System.Windows.Forms.Label lblTotal;
        private Controles.progress pgCircular;
        private Controles.boton btnEditar;
        private System.Windows.Forms.Panel panelControles;
        private System.Windows.Forms.Label lblAplicacion;
        private System.Windows.Forms.Label lblBonificacion;
        private Controles.boton btnActualizar;
        private Controles.boton btnCancelar;
    }
}