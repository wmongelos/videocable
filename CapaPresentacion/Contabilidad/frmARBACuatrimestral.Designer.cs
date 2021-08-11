
namespace CapaPresentacion.Informes
{
    partial class frmARBACuatrimestral
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
            this.panel3 = new System.Windows.Forms.Panel();
            this.imgReturn = new System.Windows.Forms.PictureBox();
            this.lblTituloHeader = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.txtImporteCable = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtFiltrar = new System.Windows.Forms.TextBox();
            this.lblFiltro = new System.Windows.Forms.Label();
            this.lblTotalRegistros = new System.Windows.Forms.Label();
            this.lblImporteTotal = new System.Windows.Forms.Label();
            this.tbArbaCuatrimestral = new System.Windows.Forms.TabControl();
            this.tbDatosFiltrados = new System.Windows.Forms.TabPage();
            this.lblEstado = new System.Windows.Forms.Label();
            this.pgCircular = new CapaPresentacion.Controles.progress();
            this.dgv = new CapaPresentacion.Controles.dgv(this.components);
            this.tbDatosFinal = new System.Windows.Forms.TabPage();
            this.dgvFinal = new CapaPresentacion.Controles.dgv(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.txtImporteInternet = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtImporteAmbos = new System.Windows.Forms.TextBox();
            this.btnGeneraTxt = new CapaPresentacion.Controles.boton();
            this.btnExportarExcel = new CapaPresentacion.Controles.boton();
            this.btnBuscar = new CapaPresentacion.Controles.boton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pnlPie = new System.Windows.Forms.Panel();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgReturn)).BeginInit();
            this.tbArbaCuatrimestral.SuspendLayout();
            this.tbDatosFiltrados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.tbDatosFinal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFinal)).BeginInit();
            this.pnlPie.SuspendLayout();
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
            this.panel3.Size = new System.Drawing.Size(1188, 75);
            this.panel3.TabIndex = 37;
            // 
            // imgReturn
            // 
            this.imgReturn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.imgReturn.Image = global::CapaPresentacion.Properties.Resources.Left_Arrow_32;
            this.imgReturn.Location = new System.Drawing.Point(15, 21);
            this.imgReturn.Name = "imgReturn";
            this.imgReturn.Size = new System.Drawing.Size(32, 32);
            this.imgReturn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgReturn.TabIndex = 32;
            this.imgReturn.TabStop = false;
            this.imgReturn.Click += new System.EventHandler(this.imgReturn_Click);
            // 
            // lblTituloHeader
            // 
            this.lblTituloHeader.AutoSize = true;
            this.lblTituloHeader.Font = new System.Drawing.Font("Segoe UI Light", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloHeader.ForeColor = System.Drawing.Color.White;
            this.lblTituloHeader.Location = new System.Drawing.Point(53, 26);
            this.lblTituloHeader.Name = "lblTituloHeader";
            this.lblTituloHeader.Size = new System.Drawing.Size(250, 25);
            this.lblTituloHeader.TabIndex = 31;
            this.lblTituloHeader.Text = "Facturado ARBA Cuatrimestral";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(394, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 21);
            this.label2.TabIndex = 349;
            this.label2.Text = "Hasta:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(58, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 21);
            this.label1.TabIndex = 348;
            this.label1.Text = "Desde:";
            // 
            // dtpHasta
            // 
            this.dtpHasta.CustomFormat = "dddd dd , MMMM , yyyy";
            this.dtpHasta.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpHasta.Location = new System.Drawing.Point(452, 81);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(268, 29);
            this.dtpHasta.TabIndex = 347;
            this.dtpHasta.Value = new System.DateTime(2020, 2, 16, 16, 2, 0, 0);
            // 
            // dtpDesde
            // 
            this.dtpDesde.Cursor = System.Windows.Forms.Cursors.Default;
            this.dtpDesde.CustomFormat = "dddd dd , MMMM , yyyy";
            this.dtpDesde.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDesde.Location = new System.Drawing.Point(120, 81);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(268, 29);
            this.dtpDesde.TabIndex = 346;
            this.dtpDesde.Value = new System.DateTime(2020, 2, 16, 16, 2, 0, 0);
            this.dtpDesde.ValueChanged += new System.EventHandler(this.dtpDesde_ValueChanged);
            // 
            // txtImporteCable
            // 
            this.txtImporteCable.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtImporteCable.Location = new System.Drawing.Point(120, 116);
            this.txtImporteCable.Name = "txtImporteCable";
            this.txtImporteCable.Size = new System.Drawing.Size(58, 29);
            this.txtImporteCable.TabIndex = 353;
            this.txtImporteCable.Text = "3000";
            this.txtImporteCable.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtImporteCable.TextChanged += new System.EventHandler(this.txtImporteCable_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(2, 119);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 21);
            this.label4.TabIndex = 354;
            this.label4.Text = "Cable Desde: $";
            // 
            // txtFiltrar
            // 
            this.txtFiltrar.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtFiltrar.Location = new System.Drawing.Point(62, 169);
            this.txtFiltrar.Name = "txtFiltrar";
            this.txtFiltrar.Size = new System.Drawing.Size(658, 29);
            this.txtFiltrar.TabIndex = 356;
            this.txtFiltrar.TextChanged += new System.EventHandler(this.txtFiltrar_TextChanged);
            // 
            // lblFiltro
            // 
            this.lblFiltro.AutoSize = true;
            this.lblFiltro.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFiltro.ForeColor = System.Drawing.Color.Black;
            this.lblFiltro.Location = new System.Drawing.Point(4, 175);
            this.lblFiltro.Name = "lblFiltro";
            this.lblFiltro.Size = new System.Drawing.Size(54, 21);
            this.lblFiltro.TabIndex = 357;
            this.lblFiltro.Text = "Filtrar:";
            // 
            // lblTotalRegistros
            // 
            this.lblTotalRegistros.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblTotalRegistros.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalRegistros.ForeColor = System.Drawing.Color.Black;
            this.lblTotalRegistros.Location = new System.Drawing.Point(0, 0);
            this.lblTotalRegistros.Name = "lblTotalRegistros";
            this.lblTotalRegistros.Size = new System.Drawing.Size(162, 36);
            this.lblTotalRegistros.TabIndex = 358;
            this.lblTotalRegistros.Text = "Total de Registros:";
            this.lblTotalRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblImporteTotal
            // 
            this.lblImporteTotal.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblImporteTotal.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblImporteTotal.ForeColor = System.Drawing.Color.Black;
            this.lblImporteTotal.Location = new System.Drawing.Point(901, 0);
            this.lblImporteTotal.Name = "lblImporteTotal";
            this.lblImporteTotal.Size = new System.Drawing.Size(287, 36);
            this.lblImporteTotal.TabIndex = 359;
            this.lblImporteTotal.Text = "Total: $";
            this.lblImporteTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbArbaCuatrimestral
            // 
            this.tbArbaCuatrimestral.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbArbaCuatrimestral.Controls.Add(this.tbDatosFiltrados);
            this.tbArbaCuatrimestral.Controls.Add(this.tbDatosFinal);
            this.tbArbaCuatrimestral.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.tbArbaCuatrimestral.Location = new System.Drawing.Point(9, 208);
            this.tbArbaCuatrimestral.Margin = new System.Windows.Forms.Padding(2);
            this.tbArbaCuatrimestral.Name = "tbArbaCuatrimestral";
            this.tbArbaCuatrimestral.SelectedIndex = 0;
            this.tbArbaCuatrimestral.Size = new System.Drawing.Size(1175, 339);
            this.tbArbaCuatrimestral.TabIndex = 361;
            this.tbArbaCuatrimestral.Selected += new System.Windows.Forms.TabControlEventHandler(this.tbArbaCuatrimestral_Selected);
            // 
            // tbDatosFiltrados
            // 
            this.tbDatosFiltrados.BackColor = System.Drawing.Color.Transparent;
            this.tbDatosFiltrados.Controls.Add(this.lblEstado);
            this.tbDatosFiltrados.Controls.Add(this.pgCircular);
            this.tbDatosFiltrados.Controls.Add(this.dgv);
            this.tbDatosFiltrados.Location = new System.Drawing.Point(4, 30);
            this.tbDatosFiltrados.Margin = new System.Windows.Forms.Padding(2);
            this.tbDatosFiltrados.Name = "tbDatosFiltrados";
            this.tbDatosFiltrados.Padding = new System.Windows.Forms.Padding(2);
            this.tbDatosFiltrados.Size = new System.Drawing.Size(1167, 305);
            this.tbDatosFiltrados.TabIndex = 0;
            this.tbDatosFiltrados.Text = "Informacion Consultada";
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblEstado.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstado.ForeColor = System.Drawing.Color.Black;
            this.lblEstado.Location = new System.Drawing.Point(338, 168);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(165, 21);
            this.lblEstado.TabIndex = 369;
            this.lblEstado.Text = "Buscando información";
            this.lblEstado.Visible = false;
            // 
            // pgCircular
            // 
            this.pgCircular.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pgCircular.Location = new System.Drawing.Point(385, 93);
            this.pgCircular.Name = "pgCircular";
            this.pgCircular.Percentage = 0F;
            this.pgCircular.Rotation = CapaPresentacion.Controles.RotationType.CounterClockwise;
            this.pgCircular.Size = new System.Drawing.Size(72, 72);
            this.pgCircular.TabIndex = 350;
            this.pgCircular.Visible = false;
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AllowUserToOrderColumns = true;
            this.dgv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dgv.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgv.BackgroundColor = System.Drawing.Color.White;
            this.dgv.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgv.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSlateGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 12F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv.ColumnHeadersHeight = 40;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 12F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgv.EnableHeadersVisualStyles = false;
            this.dgv.GridColor = System.Drawing.Color.WhiteSmoke;
            this.dgv.Location = new System.Drawing.Point(5, 6);
            this.dgv.MultiSelect = false;
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersVisible = false;
            this.dgv.RowHeadersWidth = 50;
            this.dgv.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(1158, 296);
            this.dgv.TabIndex = 355;
            this.dgv.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgv_CellMouseClick);
            // 
            // tbDatosFinal
            // 
            this.tbDatosFinal.Controls.Add(this.dgvFinal);
            this.tbDatosFinal.Location = new System.Drawing.Point(4, 30);
            this.tbDatosFinal.Margin = new System.Windows.Forms.Padding(2);
            this.tbDatosFinal.Name = "tbDatosFinal";
            this.tbDatosFinal.Padding = new System.Windows.Forms.Padding(2);
            this.tbDatosFinal.Size = new System.Drawing.Size(1167, 305);
            this.tbDatosFinal.TabIndex = 1;
            this.tbDatosFinal.Text = "Informacion Final";
            this.tbDatosFinal.UseVisualStyleBackColor = true;
            // 
            // dgvFinal
            // 
            this.dgvFinal.AllowUserToAddRows = false;
            this.dgvFinal.AllowUserToDeleteRows = false;
            this.dgvFinal.AllowUserToOrderColumns = true;
            this.dgvFinal.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvFinal.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvFinal.BackgroundColor = System.Drawing.Color.White;
            this.dgvFinal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvFinal.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.LightSlateGray;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 12F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvFinal.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvFinal.ColumnHeadersHeight = 40;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 12F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvFinal.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvFinal.EnableHeadersVisualStyles = false;
            this.dgvFinal.GridColor = System.Drawing.Color.WhiteSmoke;
            this.dgvFinal.Location = new System.Drawing.Point(6, 6);
            this.dgvFinal.MultiSelect = false;
            this.dgvFinal.Name = "dgvFinal";
            this.dgvFinal.ReadOnly = true;
            this.dgvFinal.RowHeadersVisible = false;
            this.dgvFinal.RowHeadersWidth = 50;
            this.dgvFinal.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvFinal.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFinal.Size = new System.Drawing.Size(979, 241);
            this.dgvFinal.TabIndex = 356;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(184, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(127, 21);
            this.label3.TabIndex = 364;
            this.label3.Text = "Internet Desde: $";
            // 
            // txtImporteInternet
            // 
            this.txtImporteInternet.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtImporteInternet.Location = new System.Drawing.Point(317, 116);
            this.txtImporteInternet.Name = "txtImporteInternet";
            this.txtImporteInternet.Size = new System.Drawing.Size(71, 29);
            this.txtImporteInternet.TabIndex = 363;
            this.txtImporteInternet.Text = "2000";
            this.txtImporteInternet.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtImporteInternet.TextChanged += new System.EventHandler(this.txtImporteInternet_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(394, 119);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(122, 21);
            this.label5.TabIndex = 366;
            this.label5.Text = "Ambos Desde: $";
            // 
            // txtImporteAmbos
            // 
            this.txtImporteAmbos.Enabled = false;
            this.txtImporteAmbos.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtImporteAmbos.Location = new System.Drawing.Point(522, 116);
            this.txtImporteAmbos.Name = "txtImporteAmbos";
            this.txtImporteAmbos.Size = new System.Drawing.Size(85, 29);
            this.txtImporteAmbos.TabIndex = 365;
            this.txtImporteAmbos.Text = "5000";
            this.txtImporteAmbos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnGeneraTxt
            // 
            this.btnGeneraTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGeneraTxt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnGeneraTxt.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGeneraTxt.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnGeneraTxt.FlatAppearance.BorderSize = 0;
            this.btnGeneraTxt.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnGeneraTxt.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnGeneraTxt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGeneraTxt.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGeneraTxt.ForeColor = System.Drawing.Color.White;
            this.btnGeneraTxt.Image = global::CapaPresentacion.Properties.Resources.Data_Export_32;
            this.btnGeneraTxt.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGeneraTxt.Location = new System.Drawing.Point(996, 81);
            this.btnGeneraTxt.Name = "btnGeneraTxt";
            this.btnGeneraTxt.Size = new System.Drawing.Size(180, 32);
            this.btnGeneraTxt.TabIndex = 360;
            this.btnGeneraTxt.Text = "Generar archivo Txt";
            this.btnGeneraTxt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGeneraTxt.UseVisualStyleBackColor = true;
            this.btnGeneraTxt.Click += new System.EventHandler(this.btnGeneraTxt_Click);
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
            this.btnExportarExcel.Location = new System.Drawing.Point(883, 82);
            this.btnExportarExcel.Name = "btnExportarExcel";
            this.btnExportarExcel.Size = new System.Drawing.Size(107, 31);
            this.btnExportarExcel.TabIndex = 345;
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
            this.btnBuscar.Location = new System.Drawing.Point(771, 82);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(106, 31);
            this.btnBuscar.TabIndex = 341;
            this.btnBuscar.Text = "Consulta";
            this.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.Silver;
            this.panel2.Location = new System.Drawing.Point(4, 156);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1180, 1);
            this.panel2.TabIndex = 367;
            // 
            // pnlPie
            // 
            this.pnlPie.Controls.Add(this.lblImporteTotal);
            this.pnlPie.Controls.Add(this.lblTotalRegistros);
            this.pnlPie.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlPie.Location = new System.Drawing.Point(0, 552);
            this.pnlPie.Name = "pnlPie";
            this.pnlPie.Size = new System.Drawing.Size(1188, 36);
            this.pnlPie.TabIndex = 368;
            // 
            // frmARBACuatrimestral
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1188, 588);
            this.Controls.Add(this.pnlPie);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.txtImporteAmbos);
            this.Controls.Add(this.txtImporteCable);
            this.Controls.Add(this.txtImporteInternet);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbArbaCuatrimestral);
            this.Controls.Add(this.btnGeneraTxt);
            this.Controls.Add(this.lblFiltro);
            this.Controls.Add(this.txtFiltrar);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtpHasta);
            this.Controls.Add(this.dtpDesde);
            this.Controls.Add(this.btnExportarExcel);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.panel3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmARBACuatrimestral";
            this.Load += new System.EventHandler(this.frmARBACuatrimestral_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmARBACuatrimestral_KeyDown);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgReturn)).EndInit();
            this.tbArbaCuatrimestral.ResumeLayout(false);
            this.tbDatosFiltrados.ResumeLayout(false);
            this.tbDatosFiltrados.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.tbDatosFinal.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFinal)).EndInit();
            this.pnlPie.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox imgReturn;
        private System.Windows.Forms.Label lblTituloHeader;
        private Controles.boton btnBuscar;
        private Controles.boton btnExportarExcel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private Controles.progress pgCircular;
        private System.Windows.Forms.TextBox txtImporteCable;
        private System.Windows.Forms.Label label4;
        private Controles.dgv dgv;
        private System.Windows.Forms.TextBox txtFiltrar;
        private System.Windows.Forms.Label lblFiltro;
        private System.Windows.Forms.Label lblTotalRegistros;
        private System.Windows.Forms.Label lblImporteTotal;
        private Controles.boton btnGeneraTxt;
        private System.Windows.Forms.TabControl tbArbaCuatrimestral;
        private System.Windows.Forms.TabPage tbDatosFiltrados;
        private System.Windows.Forms.TabPage tbDatosFinal;
        private Controles.dgv dgvFinal;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtImporteInternet;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtImporteAmbos;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel pnlPie;
        private System.Windows.Forms.Label lblEstado;
    }
}