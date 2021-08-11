
namespace CapaPresentacion.Contabilidad
{
    partial class FrmInformeCajas
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
            this.lblTituloHeader = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.panel2 = new System.Windows.Forms.Panel();
            this.rbCajaDiaria = new System.Windows.Forms.RadioButton();
            this.rbCajaGeneral = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.imgReturn = new System.Windows.Forms.PictureBox();
            this.dgvCajaGeneral = new CapaPresentacion.Controles.dgv(this.components);
            this.dgvCajaDiaria = new CapaPresentacion.Controles.dgv(this.components);
            this.btnExportarExcel = new CapaPresentacion.Controles.boton();
            this.btnBuscar = new CapaPresentacion.Controles.boton();
            this.lblImporteGeneral = new System.Windows.Forms.Label();
            this.lblRegistrosGeneral = new System.Windows.Forms.Label();
            this.lblImporteDiaria = new System.Windows.Forms.Label();
            this.lblRegistroDiaria = new System.Windows.Forms.Label();
            this.panel3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgReturn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCajaGeneral)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCajaDiaria)).BeginInit();
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
            this.panel3.Size = new System.Drawing.Size(1556, 75);
            this.panel3.TabIndex = 68;
            // 
            // lblTituloHeader
            // 
            this.lblTituloHeader.Font = new System.Drawing.Font("Segoe UI Light", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloHeader.ForeColor = System.Drawing.Color.White;
            this.lblTituloHeader.Location = new System.Drawing.Point(53, 27);
            this.lblTituloHeader.Name = "lblTituloHeader";
            this.lblTituloHeader.Size = new System.Drawing.Size(338, 23);
            this.lblTituloHeader.TabIndex = 31;
            this.lblTituloHeader.Text = "Cajas cerradas";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(650, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 21);
            this.label2.TabIndex = 353;
            this.label2.Text = "Hasta:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(314, 111);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 21);
            this.label1.TabIndex = 352;
            this.label1.Text = "Desde:";
            // 
            // dtpHasta
            // 
            this.dtpHasta.CustomFormat = "dddd dd , MMMM , yyyy";
            this.dtpHasta.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpHasta.Location = new System.Drawing.Point(708, 105);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(268, 29);
            this.dtpHasta.TabIndex = 351;
            this.dtpHasta.Value = new System.DateTime(2020, 2, 16, 16, 2, 0, 0);
            // 
            // dtpDesde
            // 
            this.dtpDesde.Cursor = System.Windows.Forms.Cursors.Default;
            this.dtpDesde.CustomFormat = "dddd dd , MMMM , yyyy";
            this.dtpDesde.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDesde.Location = new System.Drawing.Point(376, 105);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(268, 29);
            this.dtpDesde.TabIndex = 350;
            this.dtpDesde.Value = new System.DateTime(2020, 2, 16, 16, 2, 0, 0);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.Silver;
            this.panel2.Location = new System.Drawing.Point(12, 170);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1594, 1);
            this.panel2.TabIndex = 368;
            // 
            // rbCajaDiaria
            // 
            this.rbCajaDiaria.AutoSize = true;
            this.rbCajaDiaria.Checked = true;
            this.rbCajaDiaria.Location = new System.Drawing.Point(7, 28);
            this.rbCajaDiaria.Name = "rbCajaDiaria";
            this.rbCajaDiaria.Size = new System.Drawing.Size(116, 25);
            this.rbCajaDiaria.TabIndex = 369;
            this.rbCajaDiaria.TabStop = true;
            this.rbCajaDiaria.Text = "CAJA DIARIA";
            this.rbCajaDiaria.UseVisualStyleBackColor = true;
            // 
            // rbCajaGeneral
            // 
            this.rbCajaGeneral.AutoSize = true;
            this.rbCajaGeneral.Location = new System.Drawing.Point(129, 28);
            this.rbCajaGeneral.Name = "rbCajaGeneral";
            this.rbCajaGeneral.Size = new System.Drawing.Size(132, 25);
            this.rbCajaGeneral.TabIndex = 370;
            this.rbCajaGeneral.Text = "CAJA GENERAL";
            this.rbCajaGeneral.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbCajaGeneral);
            this.groupBox1.Controls.Add(this.rbCajaDiaria);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(15, 81);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(282, 63);
            this.groupBox1.TabIndex = 371;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tipo de Caja";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(286, 193);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(118, 21);
            this.label3.TabIndex = 378;
            this.label3.Text = "CAJA GENERAL";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(1170, 193);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 21);
            this.label4.TabIndex = 379;
            this.label4.Text = "CAJA DIARIA";
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
            // dgvCajaGeneral
            // 
            this.dgvCajaGeneral.AllowUserToAddRows = false;
            this.dgvCajaGeneral.AllowUserToDeleteRows = false;
            this.dgvCajaGeneral.AllowUserToOrderColumns = true;
            this.dgvCajaGeneral.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgvCajaGeneral.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCajaGeneral.BackgroundColor = System.Drawing.Color.White;
            this.dgvCajaGeneral.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvCajaGeneral.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.LightSlateGray;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCajaGeneral.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvCajaGeneral.ColumnHeadersHeight = 40;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCajaGeneral.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvCajaGeneral.EnableHeadersVisualStyles = false;
            this.dgvCajaGeneral.GridColor = System.Drawing.Color.WhiteSmoke;
            this.dgvCajaGeneral.Location = new System.Drawing.Point(15, 217);
            this.dgvCajaGeneral.MultiSelect = false;
            this.dgvCajaGeneral.Name = "dgvCajaGeneral";
            this.dgvCajaGeneral.ReadOnly = true;
            this.dgvCajaGeneral.RowHeadersVisible = false;
            this.dgvCajaGeneral.RowHeadersWidth = 50;
            this.dgvCajaGeneral.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvCajaGeneral.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCajaGeneral.Size = new System.Drawing.Size(749, 384);
            this.dgvCajaGeneral.TabIndex = 377;
            this.dgvCajaGeneral.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCajaGeneral_CellEnter);
            this.dgvCajaGeneral.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvCajaGeneral_CellMouseClick);
            // 
            // dgvCajaDiaria
            // 
            this.dgvCajaDiaria.AllowUserToAddRows = false;
            this.dgvCajaDiaria.AllowUserToDeleteRows = false;
            this.dgvCajaDiaria.AllowUserToOrderColumns = true;
            this.dgvCajaDiaria.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCajaDiaria.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCajaDiaria.BackgroundColor = System.Drawing.Color.White;
            this.dgvCajaDiaria.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvCajaDiaria.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.LightSlateGray;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCajaDiaria.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvCajaDiaria.ColumnHeadersHeight = 40;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCajaDiaria.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgvCajaDiaria.EnableHeadersVisualStyles = false;
            this.dgvCajaDiaria.GridColor = System.Drawing.Color.WhiteSmoke;
            this.dgvCajaDiaria.Location = new System.Drawing.Point(770, 217);
            this.dgvCajaDiaria.MultiSelect = false;
            this.dgvCajaDiaria.Name = "dgvCajaDiaria";
            this.dgvCajaDiaria.ReadOnly = true;
            this.dgvCajaDiaria.RowHeadersVisible = false;
            this.dgvCajaDiaria.RowHeadersWidth = 50;
            this.dgvCajaDiaria.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvCajaDiaria.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCajaDiaria.Size = new System.Drawing.Size(774, 384);
            this.dgvCajaDiaria.TabIndex = 375;
            this.dgvCajaDiaria.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvCajaDiaria_CellMouseClick);
            // 
            // btnExportarExcel
            // 
            this.btnExportarExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportarExcel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnExportarExcel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExportarExcel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnExportarExcel.FlatAppearance.BorderSize = 0;
            this.btnExportarExcel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnExportarExcel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnExportarExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportarExcel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportarExcel.ForeColor = System.Drawing.Color.White;
            this.btnExportarExcel.Image = global::CapaPresentacion.Properties.Resources.Data_Export_32;
            this.btnExportarExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExportarExcel.Location = new System.Drawing.Point(1437, 125);
            this.btnExportarExcel.Name = "btnExportarExcel";
            this.btnExportarExcel.Size = new System.Drawing.Size(107, 31);
            this.btnExportarExcel.TabIndex = 373;
            this.btnExportarExcel.Text = "Exportar";
            this.btnExportarExcel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExportarExcel.UseVisualStyleBackColor = true;
            this.btnExportarExcel.Click += new System.EventHandler(this.btnExportarExcel_Click);
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
            this.btnBuscar.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.ForeColor = System.Drawing.Color.White;
            this.btnBuscar.Image = global::CapaPresentacion.Properties.Resources.lupa;
            this.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBuscar.Location = new System.Drawing.Point(1437, 88);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(106, 31);
            this.btnBuscar.TabIndex = 372;
            this.btnBuscar.Text = "Consulta";
            this.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // lblImporteGeneral
            // 
            this.lblImporteGeneral.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblImporteGeneral.AutoSize = true;
            this.lblImporteGeneral.Font = new System.Drawing.Font("Segoe UI Light", 12F);
            this.lblImporteGeneral.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblImporteGeneral.Location = new System.Drawing.Point(205, 604);
            this.lblImporteGeneral.Name = "lblImporteGeneral";
            this.lblImporteGeneral.Size = new System.Drawing.Size(102, 21);
            this.lblImporteGeneral.TabIndex = 381;
            this.lblImporteGeneral.Text = "Importe total:";
            // 
            // lblRegistrosGeneral
            // 
            this.lblRegistrosGeneral.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblRegistrosGeneral.AutoSize = true;
            this.lblRegistrosGeneral.Font = new System.Drawing.Font("Segoe UI Light", 12F);
            this.lblRegistrosGeneral.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblRegistrosGeneral.Location = new System.Drawing.Point(25, 604);
            this.lblRegistrosGeneral.Name = "lblRegistrosGeneral";
            this.lblRegistrosGeneral.Size = new System.Drawing.Size(141, 21);
            this.lblRegistrosGeneral.TabIndex = 380;
            this.lblRegistrosGeneral.Text = "Total de Registros: 0";
            // 
            // lblImporteDiaria
            // 
            this.lblImporteDiaria.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblImporteDiaria.AutoSize = true;
            this.lblImporteDiaria.Font = new System.Drawing.Font("Segoe UI Light", 12F);
            this.lblImporteDiaria.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblImporteDiaria.Location = new System.Drawing.Point(950, 604);
            this.lblImporteDiaria.Name = "lblImporteDiaria";
            this.lblImporteDiaria.Size = new System.Drawing.Size(102, 21);
            this.lblImporteDiaria.TabIndex = 383;
            this.lblImporteDiaria.Text = "Importe total:";
            // 
            // lblRegistroDiaria
            // 
            this.lblRegistroDiaria.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblRegistroDiaria.AutoSize = true;
            this.lblRegistroDiaria.Font = new System.Drawing.Font("Segoe UI Light", 12F);
            this.lblRegistroDiaria.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblRegistroDiaria.Location = new System.Drawing.Point(766, 604);
            this.lblRegistroDiaria.Name = "lblRegistroDiaria";
            this.lblRegistroDiaria.Size = new System.Drawing.Size(141, 21);
            this.lblRegistroDiaria.TabIndex = 382;
            this.lblRegistroDiaria.Text = "Total de Registros: 0";
            // 
            // FrmInformeCajas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1556, 632);
            this.Controls.Add(this.lblImporteDiaria);
            this.Controls.Add(this.lblRegistroDiaria);
            this.Controls.Add(this.lblImporteGeneral);
            this.Controls.Add(this.lblRegistrosGeneral);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dgvCajaGeneral);
            this.Controls.Add(this.dgvCajaDiaria);
            this.Controls.Add(this.btnExportarExcel);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtpHasta);
            this.Controls.Add(this.dtpDesde);
            this.Controls.Add(this.panel3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmInformeCajas";
            this.Text = "FrmInformeCajas";
            this.Load += new System.EventHandler(this.FrmInformeCajas_Load);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgReturn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCajaGeneral)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCajaDiaria)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox imgReturn;
        private System.Windows.Forms.Label lblTituloHeader;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton rbCajaDiaria;
        private System.Windows.Forms.RadioButton rbCajaGeneral;
        private System.Windows.Forms.GroupBox groupBox1;
        private Controles.boton btnExportarExcel;
        private Controles.boton btnBuscar;
        private Controles.dgv dgvCajaDiaria;
        private Controles.dgv dgvCajaGeneral;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblImporteGeneral;
        private System.Windows.Forms.Label lblRegistrosGeneral;
        private System.Windows.Forms.Label lblImporteDiaria;
        private System.Windows.Forms.Label lblRegistroDiaria;
    }
}