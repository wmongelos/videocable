namespace CapaPresentacion.Afip
{
    partial class frmDiferenciasDeComprobantesGiesAfip
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
            this.pnHeader = new System.Windows.Forms.Panel();
            this.imgReturn = new System.Windows.Forms.PictureBox();
            this.lblTituloHeader = new System.Windows.Forms.Label();
            this.pnlControles = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.grbNumero = new System.Windows.Forms.GroupBox();
            this.btnVerificar = new CapaPresentacion.Controles.boton();
            this.label4 = new System.Windows.Forms.Label();
            this.spHasta = new CapaPresentacion.Controles.spinner(this.components);
            this.spDesde = new CapaPresentacion.Controles.spinner(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.btnExportar = new CapaPresentacion.Controles.boton();
            this.btnGenerarComp = new CapaPresentacion.Controles.boton();
            this.label2 = new System.Windows.Forms.Label();
            this.cboComprobantesTipo = new CapaPresentacion.Controles.combo(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.spPuntodeVenta = new CapaPresentacion.Controles.spinner(this.components);
            this.btnSeleccionar = new CapaPresentacion.Controles.boton();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.lbDesde = new System.Windows.Forms.Label();
            this.lbHasta = new System.Windows.Forms.Label();
            this.pnFooter = new System.Windows.Forms.Panel();
            this.lblTotal = new System.Windows.Forms.Label();
            this.pgCircular = new CapaPresentacion.Controles.progress();
            this.dgv = new CapaPresentacion.Controles.dgv(this.components);
            this.pnHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgReturn)).BeginInit();
            this.pnlControles.SuspendLayout();
            this.grbNumero.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spHasta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spDesde)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spPuntodeVenta)).BeginInit();
            this.pnFooter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // pnHeader
            // 
            this.pnHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.pnHeader.Controls.Add(this.imgReturn);
            this.pnHeader.Controls.Add(this.lblTituloHeader);
            this.pnHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnHeader.Location = new System.Drawing.Point(0, 0);
            this.pnHeader.Name = "pnHeader";
            this.pnHeader.Size = new System.Drawing.Size(1322, 86);
            this.pnHeader.TabIndex = 259;
            // 
            // imgReturn
            // 
            this.imgReturn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.imgReturn.Image = global::CapaPresentacion.Properties.Resources.Left_Arrow_32;
            this.imgReturn.Location = new System.Drawing.Point(15, 27);
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
            this.lblTituloHeader.Location = new System.Drawing.Point(53, 32);
            this.lblTituloHeader.Name = "lblTituloHeader";
            this.lblTituloHeader.Size = new System.Drawing.Size(266, 23);
            this.lblTituloHeader.TabIndex = 31;
            this.lblTituloHeader.Text = "Diferencia entre AFIP y GIES";
            // 
            // pnlControles
            // 
            this.pnlControles.Controls.Add(this.panel2);
            this.pnlControles.Controls.Add(this.grbNumero);
            this.pnlControles.Controls.Add(this.btnExportar);
            this.pnlControles.Controls.Add(this.btnGenerarComp);
            this.pnlControles.Controls.Add(this.label2);
            this.pnlControles.Controls.Add(this.cboComprobantesTipo);
            this.pnlControles.Controls.Add(this.label1);
            this.pnlControles.Controls.Add(this.spPuntodeVenta);
            this.pnlControles.Controls.Add(this.btnSeleccionar);
            this.pnlControles.Controls.Add(this.dtpDesde);
            this.pnlControles.Controls.Add(this.dtpHasta);
            this.pnlControles.Controls.Add(this.lbDesde);
            this.pnlControles.Controls.Add(this.lbHasta);
            this.pnlControles.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlControles.Location = new System.Drawing.Point(0, 86);
            this.pnlControles.Name = "pnlControles";
            this.pnlControles.Size = new System.Drawing.Size(1322, 131);
            this.pnlControles.TabIndex = 260;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.Silver;
            this.panel2.Location = new System.Drawing.Point(3, 57);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1322, 1);
            this.panel2.TabIndex = 360;
            // 
            // grbNumero
            // 
            this.grbNumero.Controls.Add(this.btnVerificar);
            this.grbNumero.Controls.Add(this.label4);
            this.grbNumero.Controls.Add(this.spHasta);
            this.grbNumero.Controls.Add(this.spDesde);
            this.grbNumero.Controls.Add(this.label3);
            this.grbNumero.Enabled = false;
            this.grbNumero.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.grbNumero.Location = new System.Drawing.Point(8, 61);
            this.grbNumero.Name = "grbNumero";
            this.grbNumero.Size = new System.Drawing.Size(483, 58);
            this.grbNumero.TabIndex = 359;
            this.grbNumero.TabStop = false;
            this.grbNumero.Text = "Comprobantes";
            // 
            // btnVerificar
            // 
            this.btnVerificar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnVerificar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnVerificar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVerificar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnVerificar.FlatAppearance.BorderSize = 0;
            this.btnVerificar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnVerificar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnVerificar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVerificar.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVerificar.ForeColor = System.Drawing.Color.White;
            this.btnVerificar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnVerificar.Location = new System.Drawing.Point(385, 19);
            this.btnVerificar.Name = "btnVerificar";
            this.btnVerificar.Size = new System.Drawing.Size(92, 29);
            this.btnVerificar.TabIndex = 363;
            this.btnVerificar.Text = "Verificar";
            this.btnVerificar.UseVisualStyleBackColor = false;
            this.btnVerificar.Click += new System.EventHandler(this.btnVerificar_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(207, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 21);
            this.label4.TabIndex = 362;
            this.label4.Text = "N° Hasta :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // spHasta
            // 
            this.spHasta.BorderColor = System.Drawing.Color.Empty;
            this.spHasta.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spHasta.Location = new System.Drawing.Point(294, 19);
            this.spHasta.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.spHasta.Name = "spHasta";
            this.spHasta.Size = new System.Drawing.Size(81, 29);
            this.spHasta.TabIndex = 361;
            this.spHasta.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // spDesde
            // 
            this.spDesde.BorderColor = System.Drawing.Color.Empty;
            this.spDesde.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spDesde.Location = new System.Drawing.Point(111, 19);
            this.spDesde.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.spDesde.Name = "spDesde";
            this.spDesde.Size = new System.Drawing.Size(81, 29);
            this.spDesde.TabIndex = 359;
            this.spDesde.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(24, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 21);
            this.label3.TabIndex = 360;
            this.label3.Text = "N° Desde :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
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
            this.btnExportar.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportar.ForeColor = System.Drawing.Color.White;
            this.btnExportar.Image = global::CapaPresentacion.Properties.Resources.Data_Export_32;
            this.btnExportar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExportar.Location = new System.Drawing.Point(1208, 10);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(105, 36);
            this.btnExportar.TabIndex = 358;
            this.btnExportar.Text = "Exportar";
            this.btnExportar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExportar.UseVisualStyleBackColor = false;
            this.btnExportar.Click += new System.EventHandler(this.boton1_Click);
            // 
            // btnGenerarComp
            // 
            this.btnGenerarComp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGenerarComp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnGenerarComp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGenerarComp.Enabled = false;
            this.btnGenerarComp.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnGenerarComp.FlatAppearance.BorderSize = 0;
            this.btnGenerarComp.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnGenerarComp.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnGenerarComp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerarComp.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerarComp.ForeColor = System.Drawing.Color.White;
            this.btnGenerarComp.Image = global::CapaPresentacion.Properties.Resources.Save_32;
            this.btnGenerarComp.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGenerarComp.Location = new System.Drawing.Point(1099, 10);
            this.btnGenerarComp.Name = "btnGenerarComp";
            this.btnGenerarComp.Size = new System.Drawing.Size(105, 36);
            this.btnGenerarComp.TabIndex = 357;
            this.btnGenerarComp.Text = "Guardar";
            this.btnGenerarComp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGenerarComp.UseVisualStyleBackColor = false;
            this.btnGenerarComp.Click += new System.EventHandler(this.btnGenerarComp_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(237, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 21);
            this.label2.TabIndex = 356;
            this.label2.Text = "Tipo Comprobante";
            // 
            // cboComprobantesTipo
            // 
            this.cboComprobantesTipo.BorderColor = System.Drawing.Color.Gainsboro;
            this.cboComprobantesTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboComprobantesTipo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboComprobantesTipo.Font = new System.Drawing.Font("Segoe UI Light", 12.25F);
            this.cboComprobantesTipo.FormattingEnabled = true;
            this.cboComprobantesTipo.Location = new System.Drawing.Point(379, 14);
            this.cboComprobantesTipo.Name = "cboComprobantesTipo";
            this.cboComprobantesTipo.Size = new System.Drawing.Size(197, 29);
            this.cboComprobantesTipo.TabIndex = 355;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(14, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 21);
            this.label1.TabIndex = 342;
            this.label1.Text = "Punto de Venta :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // spPuntodeVenta
            // 
            this.spPuntodeVenta.BorderColor = System.Drawing.Color.Empty;
            this.spPuntodeVenta.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spPuntodeVenta.Location = new System.Drawing.Point(141, 14);
            this.spPuntodeVenta.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.spPuntodeVenta.Name = "spPuntodeVenta";
            this.spPuntodeVenta.Size = new System.Drawing.Size(81, 29);
            this.spPuntodeVenta.TabIndex = 341;
            this.spPuntodeVenta.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnSeleccionar
            // 
            this.btnSeleccionar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSeleccionar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnSeleccionar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSeleccionar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnSeleccionar.FlatAppearance.BorderSize = 0;
            this.btnSeleccionar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnSeleccionar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnSeleccionar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSeleccionar.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSeleccionar.ForeColor = System.Drawing.Color.White;
            this.btnSeleccionar.Image = global::CapaPresentacion.Properties.Resources.lupa;
            this.btnSeleccionar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSeleccionar.Location = new System.Drawing.Point(990, 10);
            this.btnSeleccionar.Name = "btnSeleccionar";
            this.btnSeleccionar.Size = new System.Drawing.Size(105, 36);
            this.btnSeleccionar.TabIndex = 340;
            this.btnSeleccionar.Text = "Buscar";
            this.btnSeleccionar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSeleccionar.UseVisualStyleBackColor = false;
            this.btnSeleccionar.Click += new System.EventHandler(this.btnSeleccionar_Click);
            // 
            // dtpDesde
            // 
            this.dtpDesde.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpDesde.Checked = false;
            this.dtpDesde.CustomFormat = "dd-MM-yyyy";
            this.dtpDesde.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDesde.Location = new System.Drawing.Point(693, 14);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(111, 29);
            this.dtpDesde.TabIndex = 337;
            this.dtpDesde.ValueChanged += new System.EventHandler(this.dtpDesde_ValueChanged);
            // 
            // dtpHasta
            // 
            this.dtpHasta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpHasta.CustomFormat = "dd-MM-yyyy";
            this.dtpHasta.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpHasta.Location = new System.Drawing.Point(873, 14);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(111, 29);
            this.dtpHasta.TabIndex = 338;
            // 
            // lbDesde
            // 
            this.lbDesde.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbDesde.AutoSize = true;
            this.lbDesde.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDesde.ForeColor = System.Drawing.Color.Black;
            this.lbDesde.Location = new System.Drawing.Point(635, 18);
            this.lbDesde.Name = "lbDesde";
            this.lbDesde.Size = new System.Drawing.Size(53, 21);
            this.lbDesde.TabIndex = 336;
            this.lbDesde.Text = "Desde";
            // 
            // lbHasta
            // 
            this.lbHasta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbHasta.AutoSize = true;
            this.lbHasta.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbHasta.ForeColor = System.Drawing.Color.Black;
            this.lbHasta.Location = new System.Drawing.Point(819, 18);
            this.lbHasta.Name = "lbHasta";
            this.lbHasta.Size = new System.Drawing.Size(49, 21);
            this.lbHasta.TabIndex = 339;
            this.lbHasta.Text = "Hasta";
            // 
            // pnFooter
            // 
            this.pnFooter.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnFooter.Controls.Add(this.lblTotal);
            this.pnFooter.Controls.Add(this.pgCircular);
            this.pnFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnFooter.Location = new System.Drawing.Point(0, 418);
            this.pnFooter.Name = "pnFooter";
            this.pnFooter.Size = new System.Drawing.Size(1322, 32);
            this.pnFooter.TabIndex = 261;
            // 
            // lblTotal
            // 
            this.lblTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.ForeColor = System.Drawing.Color.SlateGray;
            this.lblTotal.Location = new System.Drawing.Point(12, 10);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(111, 13);
            this.lblTotal.TabIndex = 13;
            this.lblTotal.Text = "Total de Registros: 0";
            // 
            // pgCircular
            // 
            this.pgCircular.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pgCircular.Location = new System.Drawing.Point(1286, 4);
            this.pgCircular.Name = "pgCircular";
            this.pgCircular.Percentage = 0F;
            this.pgCircular.Rotation = CapaPresentacion.Controles.RotationType.CounterClockwise;
            this.pgCircular.Size = new System.Drawing.Size(24, 24);
            this.pgCircular.TabIndex = 0;
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AllowUserToOrderColumns = true;
            this.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv.BackgroundColor = System.Drawing.Color.White;
            this.dgv.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.LightSlateGray;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 12F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgv.ColumnHeadersHeight = 40;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 12F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv.EnableHeadersVisualStyles = false;
            this.dgv.GridColor = System.Drawing.Color.WhiteSmoke;
            this.dgv.Location = new System.Drawing.Point(0, 217);
            this.dgv.MultiSelect = false;
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersVisible = false;
            this.dgv.RowHeadersWidth = 50;
            this.dgv.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(1322, 201);
            this.dgv.TabIndex = 262;
            // 
            // frmDiferenciasDeComprobantesGiesAfip
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1322, 450);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.pnFooter);
            this.Controls.Add(this.pnlControles);
            this.Controls.Add(this.pnHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "frmDiferenciasDeComprobantesGiesAfip";
            this.Text = "frmDiferenciasDeComprobantesGiesAfip";
            this.Load += new System.EventHandler(this.frmDiferenciasDeComprobantesGiesAfip_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmDiferenciasDeComprobantesGiesAfip_KeyDown);
            this.pnHeader.ResumeLayout(false);
            this.pnHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgReturn)).EndInit();
            this.pnlControles.ResumeLayout(false);
            this.pnlControles.PerformLayout();
            this.grbNumero.ResumeLayout(false);
            this.grbNumero.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spHasta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spDesde)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spPuntodeVenta)).EndInit();
            this.pnFooter.ResumeLayout(false);
            this.pnFooter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnHeader;
        private System.Windows.Forms.PictureBox imgReturn;
        private System.Windows.Forms.Label lblTituloHeader;
        private System.Windows.Forms.Panel pnlControles;
        private System.Windows.Forms.Label label1;
        private Controles.spinner spPuntodeVenta;
        private Controles.boton btnSeleccionar;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.Label lbDesde;
        private System.Windows.Forms.Label lbHasta;
        private System.Windows.Forms.Panel pnFooter;
        private System.Windows.Forms.Label lblTotal;
        private Controles.progress pgCircular;
        private Controles.dgv dgv;
        private System.Windows.Forms.Label label2;
        private Controles.combo cboComprobantesTipo;
        private Controles.boton btnGenerarComp;
        private Controles.boton btnExportar;
        private System.Windows.Forms.Label label3;
        private Controles.spinner spDesde;
        private System.Windows.Forms.GroupBox grbNumero;
        private System.Windows.Forms.Label label4;
        private Controles.spinner spHasta;
        private System.Windows.Forms.Panel panel2;
        private Controles.boton btnVerificar;
    }
}