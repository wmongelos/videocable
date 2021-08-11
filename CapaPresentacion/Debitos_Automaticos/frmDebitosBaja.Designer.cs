namespace CapaPresentacion.Debitos_Automaticos
{
    partial class frmDebitosBaja
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
            this.panel3 = new System.Windows.Forms.Panel();
            this.imgReturn = new System.Windows.Forms.PictureBox();
            this.lblTituloHeader = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpFechaBaja = new System.Windows.Forms.DateTimePicker();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnFooter = new System.Windows.Forms.Panel();
            this.lblTotal = new System.Windows.Forms.Label();
            this.pgCircular = new CapaPresentacion.Controles.progress();
            this.lblConsultarPor = new System.Windows.Forms.Label();
            this.rbUsuario = new System.Windows.Forms.RadioButton();
            this.rbNumeroPlastico = new System.Windows.Forms.RadioButton();
            this.lblPlasticos = new System.Windows.Forms.Label();
            this.lblServiciosAsociados = new System.Windows.Forms.Label();
            this.lblCondicionServicios = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.ttInfoIrHistorial = new System.Windows.Forms.ToolTip(this.components);
            this.btnHistorial = new CapaPresentacion.Controles.boton();
            this.dgvServiciosAsociados = new CapaPresentacion.Controles.dgv(this.components);
            this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dgvPlasticos = new CapaPresentacion.Controles.dgv(this.components);
            this.Seleccionar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.txtBuscar = new CapaPresentacion.textboxAdv();
            this.btnGenerarBaja = new CapaPresentacion.Controles.boton();
            this.btnBuscar = new CapaPresentacion.Controles.boton();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgReturn)).BeginInit();
            this.pnFooter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvServiciosAsociados)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlasticos)).BeginInit();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.panel3.Controls.Add(this.imgReturn);
            this.panel3.Controls.Add(this.lblTituloHeader);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(970, 80);
            this.panel3.TabIndex = 48;
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
            this.lblTituloHeader.Text = "Baja de débitos";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.Silver;
            this.panel2.Location = new System.Drawing.Point(0, 127);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1043, 1);
            this.panel2.TabIndex = 348;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(470, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 21);
            this.label1.TabIndex = 352;
            this.label1.Text = "Para la fecha:";
            this.label1.Visible = false;
            // 
            // dtpFechaBaja
            // 
            this.dtpFechaBaja.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpFechaBaja.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.dtpFechaBaja.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFechaBaja.Location = new System.Drawing.Point(576, 89);
            this.dtpFechaBaja.Name = "dtpFechaBaja";
            this.dtpFechaBaja.Size = new System.Drawing.Size(105, 29);
            this.dtpFechaBaja.TabIndex = 353;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.Silver;
            this.panel1.Location = new System.Drawing.Point(0, 175);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1043, 1);
            this.panel1.TabIndex = 349;
            // 
            // pnFooter
            // 
            this.pnFooter.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnFooter.Controls.Add(this.lblTotal);
            this.pnFooter.Controls.Add(this.pgCircular);
            this.pnFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnFooter.Location = new System.Drawing.Point(0, 537);
            this.pnFooter.Name = "pnFooter";
            this.pnFooter.Size = new System.Drawing.Size(970, 30);
            this.pnFooter.TabIndex = 375;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblTotal.ForeColor = System.Drawing.Color.SlateGray;
            this.lblTotal.Location = new System.Drawing.Point(8, 5);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(174, 21);
            this.lblTotal.TabIndex = 13;
            this.lblTotal.Text = "Cantidad de registros: 0";
            // 
            // pgCircular
            // 
            this.pgCircular.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pgCircular.Location = new System.Drawing.Point(934, 2);
            this.pgCircular.Name = "pgCircular";
            this.pgCircular.Percentage = 0F;
            this.pgCircular.Rotation = CapaPresentacion.Controles.RotationType.CounterClockwise;
            this.pgCircular.Size = new System.Drawing.Size(24, 24);
            this.pgCircular.TabIndex = 0;
            // 
            // lblConsultarPor
            // 
            this.lblConsultarPor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblConsultarPor.AutoSize = true;
            this.lblConsultarPor.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConsultarPor.ForeColor = System.Drawing.Color.Black;
            this.lblConsultarPor.Location = new System.Drawing.Point(241, 140);
            this.lblConsultarPor.Name = "lblConsultarPor";
            this.lblConsultarPor.Size = new System.Drawing.Size(108, 21);
            this.lblConsultarPor.TabIndex = 376;
            this.lblConsultarPor.Text = "Consultar por:";
            // 
            // rbUsuario
            // 
            this.rbUsuario.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbUsuario.AutoSize = true;
            this.rbUsuario.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.rbUsuario.ForeColor = System.Drawing.Color.Black;
            this.rbUsuario.Location = new System.Drawing.Point(355, 139);
            this.rbUsuario.Name = "rbUsuario";
            this.rbUsuario.Size = new System.Drawing.Size(82, 25);
            this.rbUsuario.TabIndex = 379;
            this.rbUsuario.TabStop = true;
            this.rbUsuario.Text = "Usuario";
            this.rbUsuario.UseVisualStyleBackColor = true;
            // 
            // rbNumeroPlastico
            // 
            this.rbNumeroPlastico.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbNumeroPlastico.AutoSize = true;
            this.rbNumeroPlastico.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.rbNumeroPlastico.ForeColor = System.Drawing.Color.Black;
            this.rbNumeroPlastico.Location = new System.Drawing.Point(443, 139);
            this.rbNumeroPlastico.Name = "rbNumeroPlastico";
            this.rbNumeroPlastico.Size = new System.Drawing.Size(164, 25);
            this.rbNumeroPlastico.TabIndex = 378;
            this.rbNumeroPlastico.TabStop = true;
            this.rbNumeroPlastico.Text = "Número de plástico";
            this.rbNumeroPlastico.UseVisualStyleBackColor = true;
            // 
            // lblPlasticos
            // 
            this.lblPlasticos.AutoSize = true;
            this.lblPlasticos.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlasticos.ForeColor = System.Drawing.Color.Black;
            this.lblPlasticos.Location = new System.Drawing.Point(8, 179);
            this.lblPlasticos.Name = "lblPlasticos";
            this.lblPlasticos.Size = new System.Drawing.Size(66, 21);
            this.lblPlasticos.TabIndex = 381;
            this.lblPlasticos.Text = "Plástico:";
            this.lblPlasticos.Visible = false;
            // 
            // lblServiciosAsociados
            // 
            this.lblServiciosAsociados.AutoSize = true;
            this.lblServiciosAsociados.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblServiciosAsociados.ForeColor = System.Drawing.Color.Black;
            this.lblServiciosAsociados.Location = new System.Drawing.Point(11, 283);
            this.lblServiciosAsociados.Name = "lblServiciosAsociados";
            this.lblServiciosAsociados.Size = new System.Drawing.Size(313, 21);
            this.lblServiciosAsociados.TabIndex = 382;
            this.lblServiciosAsociados.Text = "Servicios asociados al plástico seleccionado:";
            this.lblServiciosAsociados.Visible = false;
            // 
            // lblCondicionServicios
            // 
            this.lblCondicionServicios.AutoSize = true;
            this.lblCondicionServicios.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCondicionServicios.ForeColor = System.Drawing.Color.Black;
            this.lblCondicionServicios.Location = new System.Drawing.Point(337, 283);
            this.lblCondicionServicios.Name = "lblCondicionServicios";
            this.lblCondicionServicios.Size = new System.Drawing.Size(141, 21);
            this.lblCondicionServicios.TabIndex = 384;
            this.lblCondicionServicios.Text = "condicion servicios";
            this.lblCondicionServicios.Visible = false;
            // 
            // panel5
            // 
            this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel5.BackColor = System.Drawing.Color.Silver;
            this.panel5.Location = new System.Drawing.Point(0, 535);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1043, 1);
            this.panel5.TabIndex = 388;
            // 
            // btnHistorial
            // 
            this.btnHistorial.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHistorial.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnHistorial.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHistorial.Enabled = false;
            this.btnHistorial.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnHistorial.FlatAppearance.BorderSize = 0;
            this.btnHistorial.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnHistorial.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnHistorial.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHistorial.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHistorial.ForeColor = System.Drawing.Color.White;
            this.btnHistorial.Image = global::CapaPresentacion.Properties.Resources.Arrowhead_Right_32;
            this.btnHistorial.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnHistorial.Location = new System.Drawing.Point(825, 89);
            this.btnHistorial.Name = "btnHistorial";
            this.btnHistorial.Size = new System.Drawing.Size(132, 29);
            this.btnHistorial.TabIndex = 389;
            this.btnHistorial.Text = "Ir a Historial ";
            this.btnHistorial.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ttInfoIrHistorial.SetToolTip(this.btnHistorial, "Redireccionamiento al historial de partes de la ultima baja generada");
            this.btnHistorial.UseVisualStyleBackColor = false;
            this.btnHistorial.Click += new System.EventHandler(this.btnHistorial_Click);
            // 
            // dgvServiciosAsociados
            // 
            this.dgvServiciosAsociados.AllowUserToAddRows = false;
            this.dgvServiciosAsociados.AllowUserToDeleteRows = false;
            this.dgvServiciosAsociados.AllowUserToOrderColumns = true;
            this.dgvServiciosAsociados.AllowUserToResizeRows = false;
            this.dgvServiciosAsociados.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvServiciosAsociados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvServiciosAsociados.BackgroundColor = System.Drawing.Color.White;
            this.dgvServiciosAsociados.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvServiciosAsociados.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvServiciosAsociados.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.LightSlateGray;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvServiciosAsociados.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvServiciosAsociados.ColumnHeadersHeight = 40;
            this.dgvServiciosAsociados.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewCheckBoxColumn1});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvServiciosAsociados.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvServiciosAsociados.EnableHeadersVisualStyles = false;
            this.dgvServiciosAsociados.GridColor = System.Drawing.Color.WhiteSmoke;
            this.dgvServiciosAsociados.Location = new System.Drawing.Point(12, 307);
            this.dgvServiciosAsociados.MultiSelect = false;
            this.dgvServiciosAsociados.Name = "dgvServiciosAsociados";
            this.dgvServiciosAsociados.ReadOnly = true;
            this.dgvServiciosAsociados.RowHeadersVisible = false;
            this.dgvServiciosAsociados.RowHeadersWidth = 50;
            this.dgvServiciosAsociados.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvServiciosAsociados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvServiciosAsociados.Size = new System.Drawing.Size(946, 222);
            this.dgvServiciosAsociados.TabIndex = 380;
            this.dgvServiciosAsociados.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvServiciosAsociados_CellDoubleClick);
            // 
            // dataGridViewCheckBoxColumn1
            // 
            this.dataGridViewCheckBoxColumn1.HeaderText = "selecciona";
            this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            this.dataGridViewCheckBoxColumn1.ReadOnly = true;
            this.dataGridViewCheckBoxColumn1.Visible = false;
            // 
            // dgvPlasticos
            // 
            this.dgvPlasticos.AllowUserToAddRows = false;
            this.dgvPlasticos.AllowUserToDeleteRows = false;
            this.dgvPlasticos.AllowUserToOrderColumns = true;
            this.dgvPlasticos.AllowUserToResizeRows = false;
            this.dgvPlasticos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPlasticos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPlasticos.BackgroundColor = System.Drawing.Color.White;
            this.dgvPlasticos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvPlasticos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvPlasticos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.LightSlateGray;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPlasticos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvPlasticos.ColumnHeadersHeight = 40;
            this.dgvPlasticos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Seleccionar});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPlasticos.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgvPlasticos.EnableHeadersVisualStyles = false;
            this.dgvPlasticos.GridColor = System.Drawing.Color.WhiteSmoke;
            this.dgvPlasticos.Location = new System.Drawing.Point(12, 203);
            this.dgvPlasticos.MultiSelect = false;
            this.dgvPlasticos.Name = "dgvPlasticos";
            this.dgvPlasticos.ReadOnly = true;
            this.dgvPlasticos.RowHeadersVisible = false;
            this.dgvPlasticos.RowHeadersWidth = 50;
            this.dgvPlasticos.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvPlasticos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPlasticos.Size = new System.Drawing.Size(946, 75);
            this.dgvPlasticos.TabIndex = 374;
            this.dgvPlasticos.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPlasticos_CellEnter);
            this.dgvPlasticos.SelectionChanged += new System.EventHandler(this.dgvPlasticos_SelectionChanged);
            // 
            // Seleccionar
            // 
            this.Seleccionar.HeaderText = "selecciona";
            this.Seleccionar.Name = "Seleccionar";
            this.Seleccionar.ReadOnly = true;
            this.Seleccionar.Visible = false;
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
            this.txtBuscar.Location = new System.Drawing.Point(613, 136);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Numerico = true;
            this.txtBuscar.Size = new System.Drawing.Size(207, 29);
            this.txtBuscar.TabIndex = 354;
            // 
            // btnGenerarBaja
            // 
            this.btnGenerarBaja.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGenerarBaja.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnGenerarBaja.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGenerarBaja.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnGenerarBaja.FlatAppearance.BorderSize = 0;
            this.btnGenerarBaja.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnGenerarBaja.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnGenerarBaja.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerarBaja.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerarBaja.ForeColor = System.Drawing.Color.White;
            this.btnGenerarBaja.Image = global::CapaPresentacion.Properties.Resources.Data_Add_32;
            this.btnGenerarBaja.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGenerarBaja.Location = new System.Drawing.Point(687, 89);
            this.btnGenerarBaja.Name = "btnGenerarBaja";
            this.btnGenerarBaja.Size = new System.Drawing.Size(132, 29);
            this.btnGenerarBaja.TabIndex = 347;
            this.btnGenerarBaja.Text = "Generar Baja";
            this.btnGenerarBaja.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGenerarBaja.UseVisualStyleBackColor = false;
            this.btnGenerarBaja.Click += new System.EventHandler(this.btnGenerarBaja_Click);
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
            this.btnBuscar.Location = new System.Drawing.Point(826, 136);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(132, 29);
            this.btnBuscar.TabIndex = 346;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // frmDebitosBaja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(250)))), ((int)(((byte)(251)))));
            this.ClientSize = new System.Drawing.Size(970, 567);
            this.Controls.Add(this.btnHistorial);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.lblCondicionServicios);
            this.Controls.Add(this.lblServiciosAsociados);
            this.Controls.Add(this.lblPlasticos);
            this.Controls.Add(this.dgvServiciosAsociados);
            this.Controls.Add(this.rbUsuario);
            this.Controls.Add(this.rbNumeroPlastico);
            this.Controls.Add(this.lblConsultarPor);
            this.Controls.Add(this.pnFooter);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgvPlasticos);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.dtpFechaBaja);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btnGenerarBaja);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.panel3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmDebitosBaja";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmDebitosBaja";
            this.Load += new System.EventHandler(this.frmDebitosBaja_Load);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgReturn)).EndInit();
            this.pnFooter.ResumeLayout(false);
            this.pnFooter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvServiciosAsociados)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlasticos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox imgReturn;
        private System.Windows.Forms.Label lblTituloHeader;
        private Controles.boton btnBuscar;
        private Controles.boton btnGenerarBaja;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpFechaBaja;
        private textboxAdv txtBuscar;
        private Controles.dgv dgvPlasticos;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Seleccionar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pnFooter;
        private System.Windows.Forms.Label lblTotal;
        private Controles.progress pgCircular;
        private System.Windows.Forms.Label lblConsultarPor;
        private System.Windows.Forms.RadioButton rbUsuario;
        private System.Windows.Forms.RadioButton rbNumeroPlastico;
        private Controles.dgv dgvServiciosAsociados;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private System.Windows.Forms.Label lblPlasticos;
        private System.Windows.Forms.Label lblServiciosAsociados;
        private System.Windows.Forms.Label lblCondicionServicios;
        private System.Windows.Forms.Panel panel5;
        private Controles.boton btnHistorial;
        private System.Windows.Forms.ToolTip ttInfoIrHistorial;
    }
}