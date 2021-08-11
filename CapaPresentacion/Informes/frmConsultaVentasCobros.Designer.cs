namespace CapaPresentacion.Informes
{
    partial class frmConsultaVentasCobros
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
            this.pnFooter = new System.Windows.Forms.Panel();
            this.dgvTotales = new CapaPresentacion.Controles.dgv(this.components);
            this.lblTotal = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pgCircular = new CapaPresentacion.Controles.progress();
            this.pnBody = new System.Windows.Forms.Panel();
            this.btnExportar = new CapaPresentacion.Controles.boton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.txtBuscar = new CapaPresentacion.textboxAdv();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dgvDatos = new CapaPresentacion.Controles.dgv(this.components);
            this.lblTituloHeader = new System.Windows.Forms.Label();
            this.imgReturn = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pnFiltros = new System.Windows.Forms.Panel();
            this.lblServicio = new System.Windows.Forms.Label();
            this.cboServicios = new System.Windows.Forms.ComboBox();
            this.btnBuscar = new CapaPresentacion.Controles.boton();
            this.lblTipo = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbTipo = new System.Windows.Forms.ComboBox();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.pnFooter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTotales)).BeginInit();
            this.pnBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgReturn)).BeginInit();
            this.panel3.SuspendLayout();
            this.pnFiltros.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnFooter
            // 
            this.pnFooter.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnFooter.Controls.Add(this.dgvTotales);
            this.pnFooter.Controls.Add(this.lblTotal);
            this.pnFooter.Controls.Add(this.label1);
            this.pnFooter.Controls.Add(this.pgCircular);
            this.pnFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnFooter.Location = new System.Drawing.Point(0, 422);
            this.pnFooter.Name = "pnFooter";
            this.pnFooter.Size = new System.Drawing.Size(1380, 93);
            this.pnFooter.TabIndex = 204;
            // 
            // dgvTotales
            // 
            this.dgvTotales.AllowUserToAddRows = false;
            this.dgvTotales.AllowUserToDeleteRows = false;
            this.dgvTotales.AllowUserToOrderColumns = true;
            this.dgvTotales.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTotales.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTotales.BackgroundColor = System.Drawing.Color.White;
            this.dgvTotales.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvTotales.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSlateGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTotales.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvTotales.ColumnHeadersHeight = 40;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTotales.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvTotales.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.dgvTotales.EnableHeadersVisualStyles = false;
            this.dgvTotales.GridColor = System.Drawing.Color.WhiteSmoke;
            this.dgvTotales.Location = new System.Drawing.Point(517, 11);
            this.dgvTotales.MultiSelect = false;
            this.dgvTotales.Name = "dgvTotales";
            this.dgvTotales.ReadOnly = true;
            this.dgvTotales.RowHeadersVisible = false;
            this.dgvTotales.RowHeadersWidth = 50;
            this.dgvTotales.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvTotales.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTotales.Size = new System.Drawing.Size(764, 73);
            this.dgvTotales.TabIndex = 186;
            // 
            // lblTotal
            // 
            this.lblTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 12.25F);
            this.lblTotal.ForeColor = System.Drawing.Color.SlateGray;
            this.lblTotal.Location = new System.Drawing.Point(160, 61);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(19, 23);
            this.lblTotal.TabIndex = 14;
            this.lblTotal.Text = "0";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12.25F);
            this.label1.ForeColor = System.Drawing.Color.SlateGray;
            this.label1.Location = new System.Drawing.Point(8, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(153, 23);
            this.label1.TabIndex = 13;
            this.label1.Text = "Total de Registros: ";
            // 
            // pgCircular
            // 
            this.pgCircular.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pgCircular.Location = new System.Drawing.Point(1319, 23);
            this.pgCircular.Name = "pgCircular";
            this.pgCircular.Percentage = 0F;
            this.pgCircular.Rotation = CapaPresentacion.Controles.RotationType.CounterClockwise;
            this.pgCircular.Size = new System.Drawing.Size(49, 49);
            this.pgCircular.TabIndex = 0;
            // 
            // pnBody
            // 
            this.pnBody.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(250)))), ((int)(((byte)(251)))));
            this.pnBody.Controls.Add(this.btnExportar);
            this.pnBody.Controls.Add(this.panel1);
            this.pnBody.Controls.Add(this.lblBuscar);
            this.pnBody.Controls.Add(this.txtBuscar);
            this.pnBody.Controls.Add(this.panel4);
            this.pnBody.Controls.Add(this.dgvDatos);
            this.pnBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnBody.Location = new System.Drawing.Point(0, 126);
            this.pnBody.Name = "pnBody";
            this.pnBody.Size = new System.Drawing.Size(1380, 296);
            this.pnBody.TabIndex = 206;
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
            this.btnExportar.Image = global::CapaPresentacion.Properties.Resources.Data_Export_32;
            this.btnExportar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExportar.Location = new System.Drawing.Point(1267, 9);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(101, 37);
            this.btnExportar.TabIndex = 327;
            this.btnExportar.Text = "Exportar";
            this.btnExportar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExportar.UseVisualStyleBackColor = false;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.panel1.Location = new System.Drawing.Point(0, 48);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1380, 1);
            this.panel1.TabIndex = 323;
            // 
            // lblBuscar
            // 
            this.lblBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBuscar.AutoSize = true;
            this.lblBuscar.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblBuscar.ForeColor = System.Drawing.Color.Black;
            this.lblBuscar.Location = new System.Drawing.Point(763, 19);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Size = new System.Drawing.Size(130, 21);
            this.lblBuscar.TabIndex = 326;
            this.lblBuscar.Text = "Buscar en listado:";
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
            this.txtBuscar.Location = new System.Drawing.Point(899, 15);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Numerico = false;
            this.txtBuscar.Size = new System.Drawing.Size(347, 29);
            this.txtBuscar.TabIndex = 325;
            this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.BackColor = System.Drawing.Color.Gainsboro;
            this.panel4.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.panel4.Location = new System.Drawing.Point(0, 6);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1380, 1);
            this.panel4.TabIndex = 322;
            // 
            // dgvDatos
            // 
            this.dgvDatos.AllowUserToAddRows = false;
            this.dgvDatos.AllowUserToDeleteRows = false;
            this.dgvDatos.AllowUserToOrderColumns = true;
            this.dgvDatos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDatos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDatos.BackgroundColor = System.Drawing.Color.White;
            this.dgvDatos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDatos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.LightSlateGray;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDatos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvDatos.ColumnHeadersHeight = 40;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDatos.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvDatos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.dgvDatos.EnableHeadersVisualStyles = false;
            this.dgvDatos.GridColor = System.Drawing.Color.WhiteSmoke;
            this.dgvDatos.Location = new System.Drawing.Point(12, 55);
            this.dgvDatos.MultiSelect = false;
            this.dgvDatos.Name = "dgvDatos";
            this.dgvDatos.ReadOnly = true;
            this.dgvDatos.RowHeadersVisible = false;
            this.dgvDatos.RowHeadersWidth = 50;
            this.dgvDatos.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvDatos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDatos.Size = new System.Drawing.Size(1356, 235);
            this.dgvDatos.TabIndex = 185;
            // 
            // lblTituloHeader
            // 
            this.lblTituloHeader.Font = new System.Drawing.Font("Segoe UI Light", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloHeader.ForeColor = System.Drawing.Color.White;
            this.lblTituloHeader.Location = new System.Drawing.Point(53, 27);
            this.lblTituloHeader.Name = "lblTituloHeader";
            this.lblTituloHeader.Size = new System.Drawing.Size(338, 23);
            this.lblTituloHeader.TabIndex = 31;
            this.lblTituloHeader.Text = "Informes";
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
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.panel3.Controls.Add(this.imgReturn);
            this.panel3.Controls.Add(this.lblTituloHeader);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1380, 75);
            this.panel3.TabIndex = 205;
            // 
            // pnFiltros
            // 
            this.pnFiltros.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(250)))), ((int)(((byte)(251)))));
            this.pnFiltros.Controls.Add(this.lblServicio);
            this.pnFiltros.Controls.Add(this.cboServicios);
            this.pnFiltros.Controls.Add(this.btnBuscar);
            this.pnFiltros.Controls.Add(this.lblTipo);
            this.pnFiltros.Controls.Add(this.label3);
            this.pnFiltros.Controls.Add(this.dtpHasta);
            this.pnFiltros.Controls.Add(this.label2);
            this.pnFiltros.Controls.Add(this.cmbTipo);
            this.pnFiltros.Controls.Add(this.dtpDesde);
            this.pnFiltros.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnFiltros.Location = new System.Drawing.Point(0, 75);
            this.pnFiltros.Name = "pnFiltros";
            this.pnFiltros.Size = new System.Drawing.Size(1380, 51);
            this.pnFiltros.TabIndex = 207;
            // 
            // lblServicio
            // 
            this.lblServicio.AutoSize = true;
            this.lblServicio.Font = new System.Drawing.Font("Segoe UI Light", 12.25F);
            this.lblServicio.ForeColor = System.Drawing.Color.Black;
            this.lblServicio.Location = new System.Drawing.Point(953, 14);
            this.lblServicio.Name = "lblServicio";
            this.lblServicio.Size = new System.Drawing.Size(73, 23);
            this.lblServicio.TabIndex = 207;
            this.lblServicio.Text = "Servicios";
            // 
            // cboServicios
            // 
            this.cboServicios.Font = new System.Drawing.Font("Segoe UI Light", 12.25F);
            this.cboServicios.FormattingEnabled = true;
            this.cboServicios.Items.AddRange(new object[] {
            "VENTAS",
            "COBROS",
            "TODOS"});
            this.cboServicios.Location = new System.Drawing.Point(1032, 11);
            this.cboServicios.Name = "cboServicios";
            this.cboServicios.Size = new System.Drawing.Size(205, 29);
            this.cboServicios.TabIndex = 206;
            this.cboServicios.SelectedValueChanged += new System.EventHandler(this.cboServicios_SelectedValueChanged);
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
            this.btnBuscar.Location = new System.Drawing.Point(1267, 8);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(101, 37);
            this.btnBuscar.TabIndex = 205;
            this.btnBuscar.Text = "Consulta";
            this.btnBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // lblTipo
            // 
            this.lblTipo.AutoSize = true;
            this.lblTipo.Font = new System.Drawing.Font("Segoe UI Light", 12.25F);
            this.lblTipo.ForeColor = System.Drawing.Color.Black;
            this.lblTipo.Location = new System.Drawing.Point(12, 20);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(42, 23);
            this.lblTipo.TabIndex = 36;
            this.lblTipo.Text = "Tipo";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Light", 12.25F);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(575, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 23);
            this.label3.TabIndex = 35;
            this.label3.Text = "Fecha hasta";
            // 
            // dtpHasta
            // 
            this.dtpHasta.Font = new System.Drawing.Font("Segoe UI Light", 12.25F);
            this.dtpHasta.Location = new System.Drawing.Point(675, 10);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(274, 29);
            this.dtpHasta.TabIndex = 34;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Light", 12.25F);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(190, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 23);
            this.label2.TabIndex = 33;
            this.label2.Text = "Fecha desde";
            // 
            // cmbTipo
            // 
            this.cmbTipo.Font = new System.Drawing.Font("Segoe UI Light", 12.25F);
            this.cmbTipo.FormattingEnabled = true;
            this.cmbTipo.Items.AddRange(new object[] {
            "VENTAS",
            "COBROS",
            "TODOS"});
            this.cmbTipo.Location = new System.Drawing.Point(58, 15);
            this.cmbTipo.Name = "cmbTipo";
            this.cmbTipo.Size = new System.Drawing.Size(121, 29);
            this.cmbTipo.TabIndex = 0;
            this.cmbTipo.SelectedIndexChanged += new System.EventHandler(this.cmbTipo_SelectedIndexChanged);
            // 
            // dtpDesde
            // 
            this.dtpDesde.Font = new System.Drawing.Font("Segoe UI Light", 12.25F);
            this.dtpDesde.Location = new System.Drawing.Point(298, 12);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(271, 29);
            this.dtpDesde.TabIndex = 1;
            // 
            // frmConsultaVentasCobros
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1380, 515);
            this.Controls.Add(this.pnBody);
            this.Controls.Add(this.pnFiltros);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.pnFooter);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "frmConsultaVentasCobros";
            this.Text = "frmConsultaVentasCobros";
            this.Load += new System.EventHandler(this.frmConsultaVentasCobros_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmConsultaVentasCobros_KeyDown);
            this.pnFooter.ResumeLayout(false);
            this.pnFooter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTotales)).EndInit();
            this.pnBody.ResumeLayout(false);
            this.pnBody.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgReturn)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.pnFiltros.ResumeLayout(false);
            this.pnFiltros.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Controles.dgv dgvDatos;
        private System.Windows.Forms.Panel pnFooter;
        private System.Windows.Forms.Label label1;
        private Controles.progress pgCircular;
        private System.Windows.Forms.Panel pnBody;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblTituloHeader;
        private System.Windows.Forms.PictureBox imgReturn;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel pnFiltros;
        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbTipo;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private Controles.boton btnBuscar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblBuscar;
        private textboxAdv txtBuscar;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label lblServicio;
        private System.Windows.Forms.ComboBox cboServicios;
        private Controles.dgv dgvTotales;
        private Controles.boton btnExportar;
    }
}