namespace CapaPresentacion.Informes
{
    partial class frmListadoFormaDePagos
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
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pnLine = new System.Windows.Forms.Panel();
            this.imgReturn = new System.Windows.Forms.PictureBox();
            this.lblTituloHeader = new System.Windows.Forms.Label();
            this.lblFormaPago = new System.Windows.Forms.Label();
            this.lblResultado = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.txtBusca = new System.Windows.Forms.TextBox();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.lvlMovimientos = new System.Windows.Forms.Label();
            this.lblTotalMov = new System.Windows.Forms.Label();
            this.lblImporteDesde = new System.Windows.Forms.Label();
            this.lblImporteHasta = new System.Windows.Forms.Label();
            this.cntDetalladoFormaPago = new System.Windows.Forms.Panel();
            this.cntMuestraDetalles = new System.Windows.Forms.Panel();
            this.lblNumMuestra = new System.Windows.Forms.Label();
            this.lblCajaDiaria = new System.Windows.Forms.Label();
            this.lblTotalCajaDiaria = new System.Windows.Forms.Label();
            this.lblTotalNumMuestra = new System.Windows.Forms.Label();
            this.lblTotalNombre = new System.Windows.Forms.Label();
            this.lblSucursal = new System.Windows.Forms.Label();
            this.lblTotalCuit = new System.Windows.Forms.Label();
            this.lblTotalSucursal = new System.Windows.Forms.Label();
            this.lblTotalBanco = new System.Windows.Forms.Label();
            this.lblCuit = new System.Windows.Forms.Label();
            this.lblFechaMovimiento = new System.Windows.Forms.Label();
            this.lblnombre = new System.Windows.Forms.Label();
            this.lblTotalFechaMov = new System.Windows.Forms.Label();
            this.lblBanco = new System.Windows.Forms.Label();
            this.btnSale = new CapaPresentacion.Controles.boton();
            this.dgvDetalladoFormaPago = new CapaPresentacion.Controles.dgv(this.components);
            this.btnFiltraImporte = new CapaPresentacion.Controles.boton();
            this.spnImporteHasta = new CapaPresentacion.Controles.spinner(this.components);
            this.spnImporteDesde = new CapaPresentacion.Controles.spinner(this.components);
            this.dgvFechas = new CapaPresentacion.Controles.dgv(this.components);
            this.btnActualizar = new CapaPresentacion.Controles.boton();
            this.cboFormaPago = new CapaPresentacion.Controles.combo(this.components);
            this.btnBuscar = new CapaPresentacion.Controles.boton();
            this.pnLine.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgReturn)).BeginInit();
            this.cntDetalladoFormaPago.SuspendLayout();
            this.cntMuestraDetalles.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalladoFormaPago)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spnImporteHasta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spnImporteDesde)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFechas)).BeginInit();
            this.SuspendLayout();
            // 
            // dtpDesde
            // 
            this.dtpDesde.CustomFormat = "MMMM yyyy";
            this.dtpDesde.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDesde.Location = new System.Drawing.Point(69, 81);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(284, 29);
            this.dtpDesde.TabIndex = 339;
            this.dtpDesde.Value = new System.DateTime(2020, 2, 16, 16, 2, 0, 0);
            // 
            // dtpHasta
            // 
            this.dtpHasta.CustomFormat = "MMMM yyyy";
            this.dtpHasta.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpHasta.Location = new System.Drawing.Point(417, 81);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(261, 29);
            this.dtpHasta.TabIndex = 340;
            this.dtpHasta.Value = new System.DateTime(2020, 2, 16, 16, 2, 0, 0);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(8, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 21);
            this.label1.TabIndex = 341;
            this.label1.Text = "Desde:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label2.ForeColor = System.Drawing.Color.DimGray;
            this.label2.Location = new System.Drawing.Point(359, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 21);
            this.label2.TabIndex = 342;
            this.label2.Text = "Hasta:";
            // 
            // pnLine
            // 
            this.pnLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.pnLine.Controls.Add(this.imgReturn);
            this.pnLine.Controls.Add(this.lblTituloHeader);
            this.pnLine.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnLine.Location = new System.Drawing.Point(0, 0);
            this.pnLine.Name = "pnLine";
            this.pnLine.Size = new System.Drawing.Size(1158, 75);
            this.pnLine.TabIndex = 343;
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
            this.lblTituloHeader.Size = new System.Drawing.Size(338, 27);
            this.lblTituloHeader.TabIndex = 31;
            this.lblTituloHeader.Text = "Historial Forma de Pagos";
            // 
            // lblFormaPago
            // 
            this.lblFormaPago.AutoSize = true;
            this.lblFormaPago.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblFormaPago.ForeColor = System.Drawing.Color.DimGray;
            this.lblFormaPago.Location = new System.Drawing.Point(684, 87);
            this.lblFormaPago.Name = "lblFormaPago";
            this.lblFormaPago.Size = new System.Drawing.Size(117, 21);
            this.lblFormaPago.TabIndex = 357;
            this.lblFormaPago.Text = "Forma de Pago:";
            // 
            // lblResultado
            // 
            this.lblResultado.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblResultado.AutoSize = true;
            this.lblResultado.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblResultado.ForeColor = System.Drawing.Color.DimGray;
            this.lblResultado.Location = new System.Drawing.Point(897, 488);
            this.lblResultado.Name = "lblResultado";
            this.lblResultado.Size = new System.Drawing.Size(125, 21);
            this.lblResultado.TabIndex = 361;
            this.lblResultado.Text = "SUMA IMPORTE:";
            // 
            // lblTotal
            // 
            this.lblTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblTotal.ForeColor = System.Drawing.Color.DimGray;
            this.lblTotal.Location = new System.Drawing.Point(1020, 487);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(19, 21);
            this.lblTotal.TabIndex = 362;
            this.lblTotal.Text = "$";
            // 
            // txtBusca
            // 
            this.txtBusca.Location = new System.Drawing.Point(69, 126);
            this.txtBusca.Name = "txtBusca";
            this.txtBusca.Size = new System.Drawing.Size(761, 20);
            this.txtBusca.TabIndex = 363;
            this.txtBusca.TextChanged += new System.EventHandler(this.txtBusca_TextChanged);
            // 
            // lblBuscar
            // 
            this.lblBuscar.AutoSize = true;
            this.lblBuscar.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblBuscar.ForeColor = System.Drawing.Color.DimGray;
            this.lblBuscar.Location = new System.Drawing.Point(8, 123);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Size = new System.Drawing.Size(59, 21);
            this.lblBuscar.TabIndex = 364;
            this.lblBuscar.Text = "Buscar:";
            // 
            // lvlMovimientos
            // 
            this.lvlMovimientos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lvlMovimientos.AutoSize = true;
            this.lvlMovimientos.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lvlMovimientos.ForeColor = System.Drawing.Color.DimGray;
            this.lvlMovimientos.Location = new System.Drawing.Point(566, 488);
            this.lvlMovimientos.Name = "lvlMovimientos";
            this.lvlMovimientos.Size = new System.Drawing.Size(163, 21);
            this.lvlMovimientos.TabIndex = 366;
            this.lvlMovimientos.Text = "TOTAL MOVIMIENTOS";
            // 
            // lblTotalMov
            // 
            this.lblTotalMov.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalMov.AutoSize = true;
            this.lblTotalMov.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblTotalMov.ForeColor = System.Drawing.Color.DimGray;
            this.lblTotalMov.Location = new System.Drawing.Point(725, 487);
            this.lblTotalMov.Name = "lblTotalMov";
            this.lblTotalMov.Size = new System.Drawing.Size(13, 21);
            this.lblTotalMov.TabIndex = 367;
            this.lblTotalMov.Text = ":";
            // 
            // lblImporteDesde
            // 
            this.lblImporteDesde.AutoSize = true;
            this.lblImporteDesde.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblImporteDesde.ForeColor = System.Drawing.Color.DimGray;
            this.lblImporteDesde.Location = new System.Drawing.Point(11, 159);
            this.lblImporteDesde.Name = "lblImporteDesde";
            this.lblImporteDesde.Size = new System.Drawing.Size(115, 21);
            this.lblImporteDesde.TabIndex = 370;
            this.lblImporteDesde.Text = "Importe Desde:";
            // 
            // lblImporteHasta
            // 
            this.lblImporteHasta.AutoSize = true;
            this.lblImporteHasta.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblImporteHasta.ForeColor = System.Drawing.Color.DimGray;
            this.lblImporteHasta.Location = new System.Drawing.Point(288, 159);
            this.lblImporteHasta.Name = "lblImporteHasta";
            this.lblImporteHasta.Size = new System.Drawing.Size(111, 21);
            this.lblImporteHasta.TabIndex = 371;
            this.lblImporteHasta.Text = "Importe Hasta:";
            // 
            // cntDetalladoFormaPago
            // 
            this.cntDetalladoFormaPago.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cntDetalladoFormaPago.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.cntDetalladoFormaPago.Controls.Add(this.cntMuestraDetalles);
            this.cntDetalladoFormaPago.Controls.Add(this.dgvDetalladoFormaPago);
            this.cntDetalladoFormaPago.Location = new System.Drawing.Point(0, 204);
            this.cntDetalladoFormaPago.Name = "cntDetalladoFormaPago";
            this.cntDetalladoFormaPago.Size = new System.Drawing.Size(1146, 257);
            this.cntDetalladoFormaPago.TabIndex = 375;
            this.cntDetalladoFormaPago.Paint += new System.Windows.Forms.PaintEventHandler(this.cntDetalladoFormaPago_Paint);
            // 
            // cntMuestraDetalles
            // 
            this.cntMuestraDetalles.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.cntMuestraDetalles.Controls.Add(this.lblNumMuestra);
            this.cntMuestraDetalles.Controls.Add(this.btnSale);
            this.cntMuestraDetalles.Controls.Add(this.lblCajaDiaria);
            this.cntMuestraDetalles.Controls.Add(this.lblTotalCajaDiaria);
            this.cntMuestraDetalles.Controls.Add(this.lblTotalNumMuestra);
            this.cntMuestraDetalles.Controls.Add(this.lblTotalNombre);
            this.cntMuestraDetalles.Controls.Add(this.lblSucursal);
            this.cntMuestraDetalles.Controls.Add(this.lblTotalCuit);
            this.cntMuestraDetalles.Controls.Add(this.lblTotalSucursal);
            this.cntMuestraDetalles.Controls.Add(this.lblTotalBanco);
            this.cntMuestraDetalles.Controls.Add(this.lblCuit);
            this.cntMuestraDetalles.Controls.Add(this.lblFechaMovimiento);
            this.cntMuestraDetalles.Controls.Add(this.lblnombre);
            this.cntMuestraDetalles.Controls.Add(this.lblTotalFechaMov);
            this.cntMuestraDetalles.Controls.Add(this.lblBanco);
            this.cntMuestraDetalles.Location = new System.Drawing.Point(0, 0);
            this.cntMuestraDetalles.Name = "cntMuestraDetalles";
            this.cntMuestraDetalles.Size = new System.Drawing.Size(1116, 74);
            this.cntMuestraDetalles.TabIndex = 390;
            // 
            // lblNumMuestra
            // 
            this.lblNumMuestra.AutoSize = true;
            this.lblNumMuestra.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblNumMuestra.ForeColor = System.Drawing.Color.White;
            this.lblNumMuestra.Location = new System.Drawing.Point(12, 11);
            this.lblNumMuestra.Name = "lblNumMuestra";
            this.lblNumMuestra.Size = new System.Drawing.Size(109, 21);
            this.lblNumMuestra.TabIndex = 380;
            this.lblNumMuestra.Text = "Num Muestra:";
            // 
            // lblCajaDiaria
            // 
            this.lblCajaDiaria.AutoSize = true;
            this.lblCajaDiaria.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblCajaDiaria.ForeColor = System.Drawing.Color.White;
            this.lblCajaDiaria.Location = new System.Drawing.Point(557, 42);
            this.lblCajaDiaria.Name = "lblCajaDiaria";
            this.lblCajaDiaria.Size = new System.Drawing.Size(88, 21);
            this.lblCajaDiaria.TabIndex = 382;
            this.lblCajaDiaria.Text = "Caja Diaria:";
            // 
            // lblTotalCajaDiaria
            // 
            this.lblTotalCajaDiaria.AutoSize = true;
            this.lblTotalCajaDiaria.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblTotalCajaDiaria.ForeColor = System.Drawing.Color.White;
            this.lblTotalCajaDiaria.Location = new System.Drawing.Point(651, 42);
            this.lblTotalCajaDiaria.Name = "lblTotalCajaDiaria";
            this.lblTotalCajaDiaria.Size = new System.Drawing.Size(13, 21);
            this.lblTotalCajaDiaria.TabIndex = 389;
            this.lblTotalCajaDiaria.Text = ".";
            // 
            // lblTotalNumMuestra
            // 
            this.lblTotalNumMuestra.AutoSize = true;
            this.lblTotalNumMuestra.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblTotalNumMuestra.ForeColor = System.Drawing.Color.White;
            this.lblTotalNumMuestra.Location = new System.Drawing.Point(128, 11);
            this.lblTotalNumMuestra.Name = "lblTotalNumMuestra";
            this.lblTotalNumMuestra.Size = new System.Drawing.Size(13, 21);
            this.lblTotalNumMuestra.TabIndex = 383;
            this.lblTotalNumMuestra.Text = ".";
            // 
            // lblTotalNombre
            // 
            this.lblTotalNombre.AutoSize = true;
            this.lblTotalNombre.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblTotalNombre.ForeColor = System.Drawing.Color.White;
            this.lblTotalNombre.Location = new System.Drawing.Point(634, 11);
            this.lblTotalNombre.Name = "lblTotalNombre";
            this.lblTotalNombre.Size = new System.Drawing.Size(13, 21);
            this.lblTotalNombre.TabIndex = 388;
            this.lblTotalNombre.Text = ".";
            // 
            // lblSucursal
            // 
            this.lblSucursal.AutoSize = true;
            this.lblSucursal.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblSucursal.ForeColor = System.Drawing.Color.White;
            this.lblSucursal.Location = new System.Drawing.Point(339, 10);
            this.lblSucursal.Name = "lblSucursal";
            this.lblSucursal.Size = new System.Drawing.Size(72, 21);
            this.lblSucursal.TabIndex = 377;
            this.lblSucursal.Text = "Sucursal:";
            // 
            // lblTotalCuit
            // 
            this.lblTotalCuit.AutoSize = true;
            this.lblTotalCuit.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblTotalCuit.ForeColor = System.Drawing.Color.White;
            this.lblTotalCuit.Location = new System.Drawing.Point(386, 42);
            this.lblTotalCuit.Name = "lblTotalCuit";
            this.lblTotalCuit.Size = new System.Drawing.Size(13, 21);
            this.lblTotalCuit.TabIndex = 387;
            this.lblTotalCuit.Text = ".";
            // 
            // lblTotalSucursal
            // 
            this.lblTotalSucursal.AutoSize = true;
            this.lblTotalSucursal.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblTotalSucursal.ForeColor = System.Drawing.Color.White;
            this.lblTotalSucursal.Location = new System.Drawing.Point(417, 10);
            this.lblTotalSucursal.Name = "lblTotalSucursal";
            this.lblTotalSucursal.Size = new System.Drawing.Size(13, 21);
            this.lblTotalSucursal.TabIndex = 386;
            this.lblTotalSucursal.Text = ".";
            // 
            // lblTotalBanco
            // 
            this.lblTotalBanco.AutoSize = true;
            this.lblTotalBanco.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblTotalBanco.ForeColor = System.Drawing.Color.White;
            this.lblTotalBanco.Location = new System.Drawing.Point(858, 10);
            this.lblTotalBanco.Name = "lblTotalBanco";
            this.lblTotalBanco.Size = new System.Drawing.Size(13, 21);
            this.lblTotalBanco.TabIndex = 385;
            this.lblTotalBanco.Text = ".";
            // 
            // lblCuit
            // 
            this.lblCuit.AutoSize = true;
            this.lblCuit.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblCuit.ForeColor = System.Drawing.Color.White;
            this.lblCuit.Location = new System.Drawing.Point(339, 42);
            this.lblCuit.Name = "lblCuit";
            this.lblCuit.Size = new System.Drawing.Size(41, 21);
            this.lblCuit.TabIndex = 379;
            this.lblCuit.Text = "Cuit:";
            // 
            // lblFechaMovimiento
            // 
            this.lblFechaMovimiento.AutoSize = true;
            this.lblFechaMovimiento.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblFechaMovimiento.ForeColor = System.Drawing.Color.White;
            this.lblFechaMovimiento.Location = new System.Drawing.Point(12, 42);
            this.lblFechaMovimiento.Name = "lblFechaMovimiento";
            this.lblFechaMovimiento.Size = new System.Drawing.Size(88, 21);
            this.lblFechaMovimiento.TabIndex = 381;
            this.lblFechaMovimiento.Text = "Fecha Mov:";
            // 
            // lblnombre
            // 
            this.lblnombre.AutoSize = true;
            this.lblnombre.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblnombre.ForeColor = System.Drawing.Color.White;
            this.lblnombre.Location = new System.Drawing.Point(557, 10);
            this.lblnombre.Name = "lblnombre";
            this.lblnombre.Size = new System.Drawing.Size(71, 21);
            this.lblnombre.TabIndex = 378;
            this.lblnombre.Text = "Nombre:";
            // 
            // lblTotalFechaMov
            // 
            this.lblTotalFechaMov.AutoSize = true;
            this.lblTotalFechaMov.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblTotalFechaMov.ForeColor = System.Drawing.Color.White;
            this.lblTotalFechaMov.Location = new System.Drawing.Point(108, 42);
            this.lblTotalFechaMov.Name = "lblTotalFechaMov";
            this.lblTotalFechaMov.Size = new System.Drawing.Size(13, 21);
            this.lblTotalFechaMov.TabIndex = 384;
            this.lblTotalFechaMov.Text = ".";
            // 
            // lblBanco
            // 
            this.lblBanco.AutoSize = true;
            this.lblBanco.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblBanco.ForeColor = System.Drawing.Color.White;
            this.lblBanco.Location = new System.Drawing.Point(797, 11);
            this.lblBanco.Name = "lblBanco";
            this.lblBanco.Size = new System.Drawing.Size(55, 21);
            this.lblBanco.TabIndex = 376;
            this.lblBanco.Text = "Banco:";
            // 
            // btnSale
            // 
            this.btnSale.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSale.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnSale.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSale.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnSale.FlatAppearance.BorderSize = 0;
            this.btnSale.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnSale.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnSale.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSale.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSale.ForeColor = System.Drawing.Color.White;
            this.btnSale.Image = global::CapaPresentacion.Properties.Resources.Command_Redo_32;
            this.btnSale.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSale.Location = new System.Drawing.Point(1037, 37);
            this.btnSale.Name = "btnSale";
            this.btnSale.Size = new System.Drawing.Size(67, 31);
            this.btnSale.TabIndex = 375;
            this.btnSale.Text = "Salir";
            this.btnSale.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSale.UseVisualStyleBackColor = false;
            this.btnSale.Click += new System.EventHandler(this.btnSale_Click);
            // 
            // dgvDetalladoFormaPago
            // 
            this.dgvDetalladoFormaPago.AllowUserToAddRows = false;
            this.dgvDetalladoFormaPago.AllowUserToDeleteRows = false;
            this.dgvDetalladoFormaPago.AllowUserToOrderColumns = true;
            this.dgvDetalladoFormaPago.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDetalladoFormaPago.BackgroundColor = System.Drawing.Color.LightGray;
            this.dgvDetalladoFormaPago.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDetalladoFormaPago.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.LightSlateGray;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDetalladoFormaPago.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvDetalladoFormaPago.ColumnHeadersHeight = 40;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDetalladoFormaPago.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvDetalladoFormaPago.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDetalladoFormaPago.EnableHeadersVisualStyles = false;
            this.dgvDetalladoFormaPago.GridColor = System.Drawing.Color.WhiteSmoke;
            this.dgvDetalladoFormaPago.Location = new System.Drawing.Point(0, 0);
            this.dgvDetalladoFormaPago.MultiSelect = false;
            this.dgvDetalladoFormaPago.Name = "dgvDetalladoFormaPago";
            this.dgvDetalladoFormaPago.ReadOnly = true;
            this.dgvDetalladoFormaPago.RowHeadersVisible = false;
            this.dgvDetalladoFormaPago.RowHeadersWidth = 50;
            this.dgvDetalladoFormaPago.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvDetalladoFormaPago.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetalladoFormaPago.Size = new System.Drawing.Size(1146, 257);
            this.dgvDetalladoFormaPago.TabIndex = 374;
            // 
            // btnFiltraImporte
            // 
            this.btnFiltraImporte.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnFiltraImporte.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFiltraImporte.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnFiltraImporte.FlatAppearance.BorderSize = 0;
            this.btnFiltraImporte.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnFiltraImporte.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnFiltraImporte.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFiltraImporte.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnFiltraImporte.ForeColor = System.Drawing.Color.White;
            this.btnFiltraImporte.Image = global::CapaPresentacion.Properties.Resources.lupa;
            this.btnFiltraImporte.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFiltraImporte.Location = new System.Drawing.Point(537, 154);
            this.btnFiltraImporte.Name = "btnFiltraImporte";
            this.btnFiltraImporte.Size = new System.Drawing.Size(156, 30);
            this.btnFiltraImporte.TabIndex = 372;
            this.btnFiltraImporte.Tag = "";
            this.btnFiltraImporte.Text = "Filtrar Importe";
            this.btnFiltraImporte.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFiltraImporte.UseVisualStyleBackColor = false;
            this.btnFiltraImporte.Click += new System.EventHandler(this.btnFiltraImporte_Click);
            // 
            // spnImporteHasta
            // 
            this.spnImporteHasta.BorderColor = System.Drawing.Color.Empty;
            this.spnImporteHasta.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spnImporteHasta.Location = new System.Drawing.Point(405, 158);
            this.spnImporteHasta.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.spnImporteHasta.Name = "spnImporteHasta";
            this.spnImporteHasta.Size = new System.Drawing.Size(120, 22);
            this.spnImporteHasta.TabIndex = 369;
            this.spnImporteHasta.Value = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            // 
            // spnImporteDesde
            // 
            this.spnImporteDesde.BorderColor = System.Drawing.Color.Empty;
            this.spnImporteDesde.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spnImporteDesde.Location = new System.Drawing.Point(132, 158);
            this.spnImporteDesde.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            0});
            this.spnImporteDesde.Name = "spnImporteDesde";
            this.spnImporteDesde.Size = new System.Drawing.Size(120, 22);
            this.spnImporteDesde.TabIndex = 368;
            // 
            // dgvFechas
            // 
            this.dgvFechas.AllowUserToAddRows = false;
            this.dgvFechas.AllowUserToDeleteRows = false;
            this.dgvFechas.AllowUserToOrderColumns = true;
            this.dgvFechas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvFechas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvFechas.BackgroundColor = System.Drawing.Color.LightGray;
            this.dgvFechas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvFechas.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.LightSlateGray;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvFechas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvFechas.ColumnHeadersHeight = 40;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvFechas.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgvFechas.EnableHeadersVisualStyles = false;
            this.dgvFechas.GridColor = System.Drawing.Color.WhiteSmoke;
            this.dgvFechas.Location = new System.Drawing.Point(0, 186);
            this.dgvFechas.MultiSelect = false;
            this.dgvFechas.Name = "dgvFechas";
            this.dgvFechas.ReadOnly = true;
            this.dgvFechas.RowHeadersVisible = false;
            this.dgvFechas.RowHeadersWidth = 50;
            this.dgvFechas.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvFechas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFechas.Size = new System.Drawing.Size(1158, 299);
            this.dgvFechas.TabIndex = 360;
            this.dgvFechas.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFechas_CellDoubleClick);
            // 
            // btnActualizar
            // 
            this.btnActualizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnActualizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnActualizar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnActualizar.FlatAppearance.BorderSize = 0;
            this.btnActualizar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnActualizar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnActualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActualizar.Font = new System.Drawing.Font("Segoe UI Light", 12F);
            this.btnActualizar.ForeColor = System.Drawing.Color.White;
            this.btnActualizar.Image = global::CapaPresentacion.Properties.Resources.Command_Refresh_32;
            this.btnActualizar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnActualizar.Location = new System.Drawing.Point(1039, 116);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(108, 34);
            this.btnActualizar.TabIndex = 358;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnActualizar.UseVisualStyleBackColor = false;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // cboFormaPago
            // 
            this.cboFormaPago.BorderColor = System.Drawing.Color.Empty;
            this.cboFormaPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFormaPago.Enabled = false;
            this.cboFormaPago.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboFormaPago.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboFormaPago.FormattingEnabled = true;
            this.cboFormaPago.Items.AddRange(new object[] {
            "TODOS"});
            this.cboFormaPago.Location = new System.Drawing.Point(807, 81);
            this.cboFormaPago.Name = "cboFormaPago";
            this.cboFormaPago.Size = new System.Drawing.Size(226, 29);
            this.cboFormaPago.TabIndex = 356;
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
            this.btnBuscar.Location = new System.Drawing.Point(1039, 82);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(107, 30);
            this.btnBuscar.TabIndex = 355;
            this.btnBuscar.Tag = "";
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // frmListadoFormaDePagos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1158, 508);
            this.Controls.Add(this.cntDetalladoFormaPago);
            this.Controls.Add(this.btnFiltraImporte);
            this.Controls.Add(this.lblImporteHasta);
            this.Controls.Add(this.lblImporteDesde);
            this.Controls.Add(this.spnImporteHasta);
            this.Controls.Add(this.spnImporteDesde);
            this.Controls.Add(this.lblTotalMov);
            this.Controls.Add(this.lvlMovimientos);
            this.Controls.Add(this.lblBuscar);
            this.Controls.Add(this.txtBusca);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.lblResultado);
            this.Controls.Add(this.dgvFechas);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.lblFormaPago);
            this.Controls.Add(this.cboFormaPago);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.pnLine);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtpHasta);
            this.Controls.Add(this.dtpDesde);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "frmListadoFormaDePagos";
            this.Text = "frmListadoFormaDePagos";
            this.Load += new System.EventHandler(this.frmListadoFormaDePagos_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmListadoFormaDePagos_KeyDown);
            this.pnLine.ResumeLayout(false);
            this.pnLine.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgReturn)).EndInit();
            this.cntDetalladoFormaPago.ResumeLayout(false);
            this.cntMuestraDetalles.ResumeLayout(false);
            this.cntMuestraDetalles.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalladoFormaPago)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spnImporteHasta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spnImporteDesde)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFechas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel pnLine;
        private System.Windows.Forms.PictureBox imgReturn;
        private System.Windows.Forms.Label lblTituloHeader;
        private Controles.boton btnBuscar;
        private Controles.combo cboFormaPago;
        private System.Windows.Forms.Label lblFormaPago;
        private Controles.boton btnActualizar;
        private Controles.dgv dgvFechas;
        private System.Windows.Forms.Label lblResultado;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.TextBox txtBusca;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.Label lvlMovimientos;
        private System.Windows.Forms.Label lblTotalMov;
        private Controles.spinner spnImporteDesde;
        private Controles.spinner spnImporteHasta;
        private System.Windows.Forms.Label lblImporteDesde;
        private System.Windows.Forms.Label lblImporteHasta;
        private Controles.boton btnFiltraImporte;
        private Controles.dgv dgvDetalladoFormaPago;
        private System.Windows.Forms.Panel cntDetalladoFormaPago;
        private Controles.boton btnSale;
        private System.Windows.Forms.Label lblCajaDiaria;
        private System.Windows.Forms.Label lblFechaMovimiento;
        private System.Windows.Forms.Label lblNumMuestra;
        private System.Windows.Forms.Label lblCuit;
        private System.Windows.Forms.Label lblnombre;
        private System.Windows.Forms.Label lblSucursal;
        private System.Windows.Forms.Label lblBanco;
        private System.Windows.Forms.Label lblTotalCajaDiaria;
        private System.Windows.Forms.Label lblTotalNombre;
        private System.Windows.Forms.Label lblTotalCuit;
        private System.Windows.Forms.Label lblTotalSucursal;
        private System.Windows.Forms.Label lblTotalBanco;
        private System.Windows.Forms.Label lblTotalFechaMov;
        private System.Windows.Forms.Label lblTotalNumMuestra;
        private System.Windows.Forms.Panel cntMuestraDetalles;
    }
}