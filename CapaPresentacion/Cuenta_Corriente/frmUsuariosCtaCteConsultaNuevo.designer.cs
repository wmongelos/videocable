namespace CapaPresentacion
{
    public partial class frmUsuariosCtaCteConsultaNuevo
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtidlo = new System.Windows.Forms.TextBox();
            this.txtidcta = new System.Windows.Forms.TextBox();
            this.lblocalidad = new System.Windows.Forms.Label();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.pnLinea1 = new System.Windows.Forms.Panel();
            this.lbTitulo = new System.Windows.Forms.Label();
            this.imgReturn = new System.Windows.Forms.PictureBox();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.lbldesde = new System.Windows.Forms.Label();
            this.lblhasta = new System.Windows.Forms.Label();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.ckTodos = new System.Windows.Forms.CheckBox();
            this.ckPorFechas = new System.Windows.Forms.CheckBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblCompronteDeuda = new System.Windows.Forms.Label();
            this.lblPlanPagos = new System.Windows.Forms.Label();
            this.lblImpago = new System.Windows.Forms.Label();
            this.lblLocacion = new System.Windows.Forms.Label();
            this.LbSaldoCta = new System.Windows.Forms.Label();
            this.lblPlandePago = new System.Windows.Forms.Label();
            this.lblCompDeuda = new System.Windows.Forms.Label();
            this.lblComImp = new System.Windows.Forms.Label();
            this.lbdomfiscal = new System.Windows.Forms.Label();
            this.tbEstado = new System.Windows.Forms.TabPage();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dgvDebeHaber = new CapaPresentacion.Controles.dgv(this.components);
            this.btnAjuste = new CapaPresentacion.Controles.boton();
            this.btnExportar = new CapaPresentacion.Controles.boton();
            this.tabPageCtaCteMov = new System.Windows.Forms.TabPage();
            this.pnlRuta = new System.Windows.Forms.Panel();
            this.btnExaminar = new CapaPresentacion.Controles.boton();
            this.btnGuardar = new CapaPresentacion.Controles.boton();
            this.lblRuta = new System.Windows.Forms.Label();
            this.txtRuta = new CapaPresentacion.textboxAdv();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.pnReturnPDF = new System.Windows.Forms.PictureBox();
            this.pnlEmail = new System.Windows.Forms.Panel();
            this.lblInfo = new System.Windows.Forms.Label();
            this.btnEnviar = new CapaPresentacion.Controles.boton();
            this.lblCorreo = new System.Windows.Forms.Label();
            this.txtCorreo = new CapaPresentacion.textboxAdv();
            this.pnlTituloEmail = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.pnReturnCorreo = new System.Windows.Forms.PictureBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dgvComprobantes = new CapaPresentacion.Controles.dgv(this.components);
            this.dgvRecibos = new CapaPresentacion.Controles.dgv(this.components);
            this.tbCtaCte = new System.Windows.Forms.TabControl();
            this.tbCtaCteLineal = new System.Windows.Forms.TabPage();
            this.dgvLineal = new CapaPresentacion.Controles.dgv(this.components);
            this.ckPreviewImpresion = new System.Windows.Forms.CheckBox();
            this.MenuAcciones = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsImprimir = new System.Windows.Forms.ToolStripMenuItem();
            this.tsGenerarPDF = new System.Windows.Forms.ToolStripMenuItem();
            this.tsEditar = new System.Windows.Forms.ToolStripMenuItem();
            this.tsEliminar = new System.Windows.Forms.ToolStripMenuItem();
            this.tsGenerarFactura = new System.Windows.Forms.ToolStripMenuItem();
            this.tsGenerarFacturaCredito = new System.Windows.Forms.ToolStripMenuItem();
            this.tsVerComponentes = new System.Windows.Forms.ToolStripMenuItem();
            this.tsContratoTemporario = new System.Windows.Forms.ToolStripMenuItem();
            this.tsIva = new System.Windows.Forms.ToolStripMenuItem();
            this.tsNotaCredito = new System.Windows.Forms.ToolStripMenuItem();
            this.generarLinkDePagoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblSaldoTotalLoc = new System.Windows.Forms.Label();
            this.btnGeneraComprobantes = new CapaPresentacion.Controles.boton();
            this.btnRecibos = new CapaPresentacion.Controles.boton();
            this.cboLocacion = new CapaPresentacion.Controles.combo(this.components);
            this.btnFiltrar = new CapaPresentacion.Controles.boton();
            this.pgCircular = new CapaPresentacion.Controles.progress();
            this.label1 = new System.Windows.Forms.Label();
            this.pnLinea1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgReturn)).BeginInit();
            this.tbEstado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDebeHaber)).BeginInit();
            this.tabPageCtaCteMov.SuspendLayout();
            this.pnlRuta.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnReturnPDF)).BeginInit();
            this.pnlEmail.SuspendLayout();
            this.pnlTituloEmail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnReturnCorreo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvComprobantes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecibos)).BeginInit();
            this.tbCtaCte.SuspendLayout();
            this.tbCtaCteLineal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLineal)).BeginInit();
            this.MenuAcciones.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtidlo
            // 
            this.txtidlo.Location = new System.Drawing.Point(806, 9);
            this.txtidlo.Name = "txtidlo";
            this.txtidlo.Size = new System.Drawing.Size(100, 20);
            this.txtidlo.TabIndex = 70;
            this.txtidlo.Text = "0";
            this.txtidlo.Visible = false;
            // 
            // txtidcta
            // 
            this.txtidcta.Location = new System.Drawing.Point(735, 12);
            this.txtidcta.Name = "txtidcta";
            this.txtidcta.Size = new System.Drawing.Size(100, 20);
            this.txtidcta.TabIndex = 69;
            this.txtidcta.Text = "0";
            this.txtidcta.Visible = false;
            // 
            // lblocalidad
            // 
            this.lblocalidad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblocalidad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblocalidad.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblocalidad.ForeColor = System.Drawing.Color.White;
            this.lblocalidad.Location = new System.Drawing.Point(787, 32);
            this.lblocalidad.Name = "lblocalidad";
            this.lblocalidad.Size = new System.Drawing.Size(369, 19);
            this.lblocalidad.TabIndex = 70;
            this.lblocalidad.Text = "-";
            this.lblocalidad.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblUsuario
            // 
            this.lblUsuario.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUsuario.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuario.ForeColor = System.Drawing.Color.White;
            this.lblUsuario.Location = new System.Drawing.Point(787, 8);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(369, 23);
            this.lblUsuario.TabIndex = 48;
            this.lblUsuario.Text = "-";
            this.lblUsuario.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pnLinea1
            // 
            this.pnLinea1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnLinea1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.pnLinea1.Controls.Add(this.lbTitulo);
            this.pnLinea1.Controls.Add(this.imgReturn);
            this.pnLinea1.Controls.Add(this.lblocalidad);
            this.pnLinea1.Controls.Add(this.lblUsuario);
            this.pnLinea1.Location = new System.Drawing.Point(-1, 0);
            this.pnLinea1.Name = "pnLinea1";
            this.pnLinea1.Size = new System.Drawing.Size(1661, 85);
            this.pnLinea1.TabIndex = 77;
            // 
            // lbTitulo
            // 
            this.lbTitulo.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitulo.ForeColor = System.Drawing.Color.White;
            this.lbTitulo.Location = new System.Drawing.Point(53, 29);
            this.lbTitulo.Name = "lbTitulo";
            this.lbTitulo.Size = new System.Drawing.Size(308, 23);
            this.lbTitulo.TabIndex = 85;
            this.lbTitulo.Text = "Movimientos en Cuenta Corriente";
            this.lbTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // imgReturn
            // 
            this.imgReturn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.imgReturn.Image = global::CapaPresentacion.Properties.Resources.Left_Arrow_32;
            this.imgReturn.Location = new System.Drawing.Point(12, 24);
            this.imgReturn.Name = "imgReturn";
            this.imgReturn.Size = new System.Drawing.Size(32, 32);
            this.imgReturn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgReturn.TabIndex = 79;
            this.imgReturn.TabStop = false;
            this.imgReturn.Click += new System.EventHandler(this.imgReturn_Click);
            // 
            // dtpDesde
            // 
            this.dtpDesde.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpDesde.Enabled = false;
            this.dtpDesde.Font = new System.Drawing.Font("Segoe UI Light", 12F);
            this.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDesde.Location = new System.Drawing.Point(874, 89);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(113, 29);
            this.dtpDesde.TabIndex = 85;
            // 
            // lbldesde
            // 
            this.lbldesde.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbldesde.AutoSize = true;
            this.lbldesde.Font = new System.Drawing.Font("Segoe UI Light", 12F);
            this.lbldesde.Location = new System.Drawing.Point(820, 92);
            this.lbldesde.Name = "lbldesde";
            this.lbldesde.Size = new System.Drawing.Size(52, 21);
            this.lbldesde.TabIndex = 86;
            this.lbldesde.Text = "Desde";
            // 
            // lblhasta
            // 
            this.lblhasta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblhasta.AutoSize = true;
            this.lblhasta.Font = new System.Drawing.Font("Segoe UI Light", 12F);
            this.lblhasta.Location = new System.Drawing.Point(992, 91);
            this.lblhasta.Name = "lblhasta";
            this.lblhasta.Size = new System.Drawing.Size(48, 21);
            this.lblhasta.TabIndex = 88;
            this.lblhasta.Text = "Hasta";
            // 
            // dtpHasta
            // 
            this.dtpHasta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpHasta.Enabled = false;
            this.dtpHasta.Font = new System.Drawing.Font("Segoe UI Light", 12F);
            this.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHasta.Location = new System.Drawing.Point(1043, 87);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(113, 29);
            this.dtpHasta.TabIndex = 87;
            // 
            // ckTodos
            // 
            this.ckTodos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ckTodos.AutoSize = true;
            this.ckTodos.Checked = true;
            this.ckTodos.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckTodos.Font = new System.Drawing.Font("Segoe UI Light", 12F);
            this.ckTodos.Location = new System.Drawing.Point(721, 91);
            this.ckTodos.Name = "ckTodos";
            this.ckTodos.Size = new System.Drawing.Size(67, 25);
            this.ckTodos.TabIndex = 90;
            this.ckTodos.Text = "Todos";
            this.ckTodos.UseVisualStyleBackColor = true;
            this.ckTodos.CheckedChanged += new System.EventHandler(this.ckTodos_CheckedChanged);
            // 
            // ckPorFechas
            // 
            this.ckPorFechas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ckPorFechas.AutoSize = true;
            this.ckPorFechas.Font = new System.Drawing.Font("Segoe UI Light", 12F);
            this.ckPorFechas.Location = new System.Drawing.Point(883, 117);
            this.ckPorFechas.Name = "ckPorFechas";
            this.ckPorFechas.Size = new System.Drawing.Size(169, 25);
            this.ckPorFechas.TabIndex = 91;
            this.ckPorFechas.Text = "Fechas determinadas";
            this.ckPorFechas.UseVisualStyleBackColor = true;
            this.ckPorFechas.CheckedChanged += new System.EventHandler(this.ckPorFechas_CheckedChanged);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.Gainsboro;
            this.panel2.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.panel2.Location = new System.Drawing.Point(1, 168);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1659, 1);
            this.panel2.TabIndex = 315;
            // 
            // lblCompronteDeuda
            // 
            this.lblCompronteDeuda.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblCompronteDeuda.AutoSize = true;
            this.lblCompronteDeuda.BackColor = System.Drawing.Color.LightBlue;
            this.lblCompronteDeuda.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCompronteDeuda.ForeColor = System.Drawing.Color.Black;
            this.lblCompronteDeuda.Location = new System.Drawing.Point(322, 697);
            this.lblCompronteDeuda.Name = "lblCompronteDeuda";
            this.lblCompronteDeuda.Size = new System.Drawing.Size(32, 17);
            this.lblCompronteDeuda.TabIndex = 319;
            this.lblCompronteDeuda.Text = "      ";
            // 
            // lblPlanPagos
            // 
            this.lblPlanPagos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblPlanPagos.AutoSize = true;
            this.lblPlanPagos.BackColor = System.Drawing.Color.LightGreen;
            this.lblPlanPagos.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlanPagos.ForeColor = System.Drawing.Color.Black;
            this.lblPlanPagos.Location = new System.Drawing.Point(109, 697);
            this.lblPlanPagos.Name = "lblPlanPagos";
            this.lblPlanPagos.Size = new System.Drawing.Size(32, 17);
            this.lblPlanPagos.TabIndex = 318;
            this.lblPlanPagos.Text = "      ";
            // 
            // lblImpago
            // 
            this.lblImpago.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblImpago.AutoSize = true;
            this.lblImpago.BackColor = System.Drawing.Color.Tomato;
            this.lblImpago.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblImpago.ForeColor = System.Drawing.Color.Black;
            this.lblImpago.Location = new System.Drawing.Point(523, 697);
            this.lblImpago.Name = "lblImpago";
            this.lblImpago.Size = new System.Drawing.Size(32, 17);
            this.lblImpago.TabIndex = 320;
            this.lblImpago.Text = "      ";
            this.lblImpago.Click += new System.EventHandler(this.lblImpago_Click);
            // 
            // lblLocacion
            // 
            this.lblLocacion.AutoSize = true;
            this.lblLocacion.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLocacion.ForeColor = System.Drawing.Color.Black;
            this.lblLocacion.Location = new System.Drawing.Point(8, 98);
            this.lblLocacion.Name = "lblLocacion";
            this.lblLocacion.Size = new System.Drawing.Size(71, 21);
            this.lblLocacion.TabIndex = 321;
            this.lblLocacion.Text = "Locación";
            // 
            // LbSaldoCta
            // 
            this.LbSaldoCta.BackColor = System.Drawing.Color.Transparent;
            this.LbSaldoCta.Font = new System.Drawing.Font("Segoe UI Light", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LbSaldoCta.ForeColor = System.Drawing.Color.DimGray;
            this.LbSaldoCta.Location = new System.Drawing.Point(307, 131);
            this.LbSaldoCta.Name = "LbSaldoCta";
            this.LbSaldoCta.Size = new System.Drawing.Size(550, 32);
            this.LbSaldoCta.TabIndex = 331;
            this.LbSaldoCta.Text = "Saldo $ 0.00";
            this.LbSaldoCta.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPlandePago
            // 
            this.lblPlandePago.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblPlandePago.AutoSize = true;
            this.lblPlandePago.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlandePago.ForeColor = System.Drawing.Color.Black;
            this.lblPlandePago.Location = new System.Drawing.Point(13, 699);
            this.lblPlandePago.Name = "lblPlandePago";
            this.lblPlandePago.Size = new System.Drawing.Size(94, 13);
            this.lblPlandePago.TabIndex = 331;
            this.lblPlandePago.Text = "[ PLAN DE PAGO ]";
            // 
            // lblCompDeuda
            // 
            this.lblCompDeuda.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblCompDeuda.AutoSize = true;
            this.lblCompDeuda.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCompDeuda.ForeColor = System.Drawing.Color.Black;
            this.lblCompDeuda.Location = new System.Drawing.Point(164, 699);
            this.lblCompDeuda.Name = "lblCompDeuda";
            this.lblCompDeuda.Size = new System.Drawing.Size(157, 13);
            this.lblCompDeuda.TabIndex = 332;
            this.lblCompDeuda.Text = "[ COMPROBANTE DE DEUDA ]";
            // 
            // lblComImp
            // 
            this.lblComImp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblComImp.AutoSize = true;
            this.lblComImp.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblComImp.ForeColor = System.Drawing.Color.Black;
            this.lblComImp.Location = new System.Drawing.Point(376, 699);
            this.lblComImp.Name = "lblComImp";
            this.lblComImp.Size = new System.Drawing.Size(145, 13);
            this.lblComImp.TabIndex = 333;
            this.lblComImp.Text = "[ COMPROBANTE IMPAGO ]";
            // 
            // lbdomfiscal
            // 
            this.lbdomfiscal.Font = new System.Drawing.Font("Segoe UI Light", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbdomfiscal.ForeColor = System.Drawing.Color.Black;
            this.lbdomfiscal.Location = new System.Drawing.Point(18, 172);
            this.lbdomfiscal.Name = "lbdomfiscal";
            this.lbdomfiscal.Size = new System.Drawing.Size(570, 23);
            this.lbdomfiscal.TabIndex = 334;
            this.lbdomfiscal.Text = "-";
            // 
            // tbEstado
            // 
            this.tbEstado.Controls.Add(this.label12);
            this.tbEstado.Controls.Add(this.label13);
            this.tbEstado.Controls.Add(this.label10);
            this.tbEstado.Controls.Add(this.label11);
            this.tbEstado.Controls.Add(this.label8);
            this.tbEstado.Controls.Add(this.label9);
            this.tbEstado.Controls.Add(this.label5);
            this.tbEstado.Controls.Add(this.label6);
            this.tbEstado.Controls.Add(this.dgvDebeHaber);
            this.tbEstado.Controls.Add(this.btnAjuste);
            this.tbEstado.Controls.Add(this.btnExportar);
            this.tbEstado.Location = new System.Drawing.Point(4, 26);
            this.tbEstado.Name = "tbEstado";
            this.tbEstado.Padding = new System.Windows.Forms.Padding(3);
            this.tbEstado.Size = new System.Drawing.Size(1131, 421);
            this.tbEstado.TabIndex = 1;
            this.tbEstado.Text = "Estado";
            this.tbEstado.UseVisualStyleBackColor = true;
            this.tbEstado.Enter += new System.EventHandler(this.tbEstado_Enter);
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(511, 418);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(57, 13);
            this.label12.TabIndex = 345;
            this.label12.Text = "[ RECIBO ]";
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.label13.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Black;
            this.label13.Location = new System.Drawing.Point(574, 415);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(32, 17);
            this.label13.TabIndex = 344;
            this.label13.Text = "      ";
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(372, 416);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(96, 13);
            this.label10.TabIndex = 343;
            this.label10.Text = "[ FACTURA PAGA ]";
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label11.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(472, 415);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(32, 17);
            this.label11.TabIndex = 342;
            this.label11.Text = "      ";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(201, 416);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(127, 13);
            this.label8.TabIndex = 341;
            this.label8.Text = "[ FACTURA SIN RECIBO ]";
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(153)))));
            this.label9.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(334, 415);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(32, 17);
            this.label9.TabIndex = 340;
            this.label9.Text = "      ";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(16, 416);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(145, 13);
            this.label5.TabIndex = 339;
            this.label5.Text = "[ COMPROBANTE IMPAGO ]";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(83)))), ((int)(((byte)(80)))));
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(163, 415);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 17);
            this.label6.TabIndex = 338;
            this.label6.Text = "      ";
            // 
            // dgvDebeHaber
            // 
            this.dgvDebeHaber.AllowUserToAddRows = false;
            this.dgvDebeHaber.AllowUserToDeleteRows = false;
            this.dgvDebeHaber.AllowUserToOrderColumns = true;
            this.dgvDebeHaber.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDebeHaber.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDebeHaber.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvDebeHaber.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvDebeHaber.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSlateGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDebeHaber.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDebeHaber.ColumnHeadersHeight = 40;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDebeHaber.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDebeHaber.EnableHeadersVisualStyles = false;
            this.dgvDebeHaber.GridColor = System.Drawing.Color.WhiteSmoke;
            this.dgvDebeHaber.Location = new System.Drawing.Point(3, 6);
            this.dgvDebeHaber.MultiSelect = false;
            this.dgvDebeHaber.Name = "dgvDebeHaber";
            this.dgvDebeHaber.ReadOnly = true;
            this.dgvDebeHaber.RowHeadersVisible = false;
            this.dgvDebeHaber.RowHeadersWidth = 50;
            this.dgvDebeHaber.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.dgvDebeHaber.RowTemplate.Height = 20;
            this.dgvDebeHaber.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDebeHaber.Size = new System.Drawing.Size(1139, 395);
            this.dgvDebeHaber.TabIndex = 1;
            this.dgvDebeHaber.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvDebeHaber_CellFormatting);
            this.dgvDebeHaber.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvDebeHaber_CellMouseClick);
            this.dgvDebeHaber.SelectionChanged += new System.EventHandler(this.dgvDebeHaber_SelectionChanged);
            // 
            // btnAjuste
            // 
            this.btnAjuste.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAjuste.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnAjuste.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAjuste.Enabled = false;
            this.btnAjuste.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnAjuste.FlatAppearance.BorderSize = 0;
            this.btnAjuste.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnAjuste.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnAjuste.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAjuste.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAjuste.ForeColor = System.Drawing.Color.White;
            this.btnAjuste.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAjuste.Location = new System.Drawing.Point(812, 407);
            this.btnAjuste.Name = "btnAjuste";
            this.btnAjuste.Size = new System.Drawing.Size(200, 30);
            this.btnAjuste.TabIndex = 337;
            this.btnAjuste.Text = "Generar Recibo de Ajuste";
            this.btnAjuste.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAjuste.UseVisualStyleBackColor = false;
            this.btnAjuste.Click += new System.EventHandler(this.btnAjuste_Click);
            // 
            // btnExportar
            // 
            this.btnExportar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnExportar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExportar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnExportar.FlatAppearance.BorderSize = 0;
            this.btnExportar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnExportar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnExportar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportar.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportar.ForeColor = System.Drawing.Color.White;
            this.btnExportar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExportar.Location = new System.Drawing.Point(1018, 408);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(143, 31);
            this.btnExportar.TabIndex = 335;
            this.btnExportar.Text = "Exportar";
            this.btnExportar.UseVisualStyleBackColor = false;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // tabPageCtaCteMov
            // 
            this.tabPageCtaCteMov.Controls.Add(this.pnlRuta);
            this.tabPageCtaCteMov.Controls.Add(this.pnlEmail);
            this.tabPageCtaCteMov.Controls.Add(this.splitContainer1);
            this.tabPageCtaCteMov.Location = new System.Drawing.Point(4, 26);
            this.tabPageCtaCteMov.Name = "tabPageCtaCteMov";
            this.tabPageCtaCteMov.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageCtaCteMov.Size = new System.Drawing.Size(1131, 421);
            this.tabPageCtaCteMov.TabIndex = 0;
            this.tabPageCtaCteMov.Text = "Detalle de Movimientos";
            this.tabPageCtaCteMov.UseVisualStyleBackColor = true;
            this.tabPageCtaCteMov.Enter += new System.EventHandler(this.tabPageCtaCteMov_Enter);
            // 
            // pnlRuta
            // 
            this.pnlRuta.Controls.Add(this.btnExaminar);
            this.pnlRuta.Controls.Add(this.btnGuardar);
            this.pnlRuta.Controls.Add(this.lblRuta);
            this.pnlRuta.Controls.Add(this.txtRuta);
            this.pnlRuta.Controls.Add(this.panel3);
            this.pnlRuta.Location = new System.Drawing.Point(527, 68);
            this.pnlRuta.Name = "pnlRuta";
            this.pnlRuta.Size = new System.Drawing.Size(432, 163);
            this.pnlRuta.TabIndex = 336;
            this.pnlRuta.Visible = false;
            // 
            // btnExaminar
            // 
            this.btnExaminar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExaminar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnExaminar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExaminar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnExaminar.FlatAppearance.BorderSize = 0;
            this.btnExaminar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnExaminar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnExaminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExaminar.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExaminar.ForeColor = System.Drawing.Color.White;
            this.btnExaminar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExaminar.Location = new System.Drawing.Point(140, 117);
            this.btnExaminar.Name = "btnExaminar";
            this.btnExaminar.Size = new System.Drawing.Size(154, 30);
            this.btnExaminar.TabIndex = 335;
            this.btnExaminar.Text = "Seleccionar carpeta";
            this.btnExaminar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExaminar.UseVisualStyleBackColor = false;
            this.btnExaminar.Click += new System.EventHandler(this.btnExaminar_Click);
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
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGuardar.Location = new System.Drawing.Point(300, 117);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(103, 30);
            this.btnGuardar.TabIndex = 334;
            this.btnGuardar.Text = "Guardar pdf";
            this.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // lblRuta
            // 
            this.lblRuta.AutoSize = true;
            this.lblRuta.Font = new System.Drawing.Font("Segoe UI Light", 12F);
            this.lblRuta.Location = new System.Drawing.Point(34, 84);
            this.lblRuta.Name = "lblRuta";
            this.lblRuta.Size = new System.Drawing.Size(41, 21);
            this.lblRuta.TabIndex = 334;
            this.lblRuta.Text = "Ruta";
            // 
            // txtRuta
            // 
            this.txtRuta.BorderColor = System.Drawing.Color.Empty;
            this.txtRuta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRuta.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtRuta.FocusColor = System.Drawing.Color.Empty;
            this.txtRuta.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRuta.Location = new System.Drawing.Point(81, 82);
            this.txtRuta.Name = "txtRuta";
            this.txtRuta.Numerico = false;
            this.txtRuta.Size = new System.Drawing.Size(322, 29);
            this.txtRuta.TabIndex = 79;
            this.txtRuta.Text = "C:\\GIES\\FACTURAS\\PDF\\";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.pnReturnPDF);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(432, 64);
            this.panel3.TabIndex = 78;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(50, 20);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(165, 23);
            this.label7.TabIndex = 85;
            this.label7.Text = "Donde guardar pdf";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnReturnPDF
            // 
            this.pnReturnPDF.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnReturnPDF.Image = global::CapaPresentacion.Properties.Resources.Left_Arrow_32;
            this.pnReturnPDF.Location = new System.Drawing.Point(12, 14);
            this.pnReturnPDF.Name = "pnReturnPDF";
            this.pnReturnPDF.Size = new System.Drawing.Size(32, 32);
            this.pnReturnPDF.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pnReturnPDF.TabIndex = 79;
            this.pnReturnPDF.TabStop = false;
            this.pnReturnPDF.Click += new System.EventHandler(this.pnReturnPDF_Click);
            // 
            // pnlEmail
            // 
            this.pnlEmail.Controls.Add(this.lblInfo);
            this.pnlEmail.Controls.Add(this.btnEnviar);
            this.pnlEmail.Controls.Add(this.lblCorreo);
            this.pnlEmail.Controls.Add(this.txtCorreo);
            this.pnlEmail.Controls.Add(this.pnlTituloEmail);
            this.pnlEmail.Location = new System.Drawing.Point(36, 68);
            this.pnlEmail.Name = "pnlEmail";
            this.pnlEmail.Size = new System.Drawing.Size(485, 163);
            this.pnlEmail.TabIndex = 333;
            this.pnlEmail.Visible = false;
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Font = new System.Drawing.Font("Segoe UI Light", 12F);
            this.lblInfo.ForeColor = System.Drawing.Color.Red;
            this.lblInfo.Location = new System.Drawing.Point(77, 121);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(189, 21);
            this.lblInfo.TabIndex = 335;
            this.lblInfo.Text = "Formato de correo invalido";
            this.lblInfo.Visible = false;
            // 
            // btnEnviar
            // 
            this.btnEnviar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEnviar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnEnviar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEnviar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnEnviar.FlatAppearance.BorderSize = 0;
            this.btnEnviar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnEnviar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnEnviar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEnviar.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnviar.ForeColor = System.Drawing.Color.White;
            this.btnEnviar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEnviar.Location = new System.Drawing.Point(325, 117);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(99, 30);
            this.btnEnviar.TabIndex = 334;
            this.btnEnviar.Text = "Enviar";
            this.btnEnviar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEnviar.UseVisualStyleBackColor = false;
            this.btnEnviar.Click += new System.EventHandler(this.btnEnviar_ClickAsync);
            // 
            // lblCorreo
            // 
            this.lblCorreo.AutoSize = true;
            this.lblCorreo.Font = new System.Drawing.Font("Segoe UI Light", 12F);
            this.lblCorreo.Location = new System.Drawing.Point(19, 84);
            this.lblCorreo.Name = "lblCorreo";
            this.lblCorreo.Size = new System.Drawing.Size(56, 21);
            this.lblCorreo.TabIndex = 334;
            this.lblCorreo.Text = "Correo";
            // 
            // txtCorreo
            // 
            this.txtCorreo.BorderColor = System.Drawing.Color.Empty;
            this.txtCorreo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCorreo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCorreo.FocusColor = System.Drawing.Color.Empty;
            this.txtCorreo.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCorreo.Location = new System.Drawing.Point(81, 82);
            this.txtCorreo.Name = "txtCorreo";
            this.txtCorreo.Numerico = false;
            this.txtCorreo.Size = new System.Drawing.Size(290, 29);
            this.txtCorreo.TabIndex = 79;
            // 
            // pnlTituloEmail
            // 
            this.pnlTituloEmail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.pnlTituloEmail.Controls.Add(this.label4);
            this.pnlTituloEmail.Controls.Add(this.pnReturnCorreo);
            this.pnlTituloEmail.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTituloEmail.Location = new System.Drawing.Point(0, 0);
            this.pnlTituloEmail.Name = "pnlTituloEmail";
            this.pnlTituloEmail.Size = new System.Drawing.Size(485, 64);
            this.pnlTituloEmail.TabIndex = 78;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(50, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(165, 23);
            this.label4.TabIndex = 85;
            this.label4.Text = "Confirmar Correo";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnReturnCorreo
            // 
            this.pnReturnCorreo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnReturnCorreo.Image = global::CapaPresentacion.Properties.Resources.Left_Arrow_32;
            this.pnReturnCorreo.Location = new System.Drawing.Point(12, 14);
            this.pnReturnCorreo.Name = "pnReturnCorreo";
            this.pnReturnCorreo.Size = new System.Drawing.Size(32, 32);
            this.pnReturnCorreo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pnReturnCorreo.TabIndex = 79;
            this.pnReturnCorreo.TabStop = false;
            this.pnReturnCorreo.Click += new System.EventHandler(this.pnReturnCorreo_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dgvComprobantes);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgvRecibos);
            this.splitContainer1.Size = new System.Drawing.Size(1132, 413);
            this.splitContainer1.SplitterDistance = 202;
            this.splitContainer1.TabIndex = 338;
            // 
            // dgvComprobantes
            // 
            this.dgvComprobantes.AllowUserToAddRows = false;
            this.dgvComprobantes.AllowUserToDeleteRows = false;
            this.dgvComprobantes.AllowUserToOrderColumns = true;
            this.dgvComprobantes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvComprobantes.BackgroundColor = System.Drawing.Color.White;
            this.dgvComprobantes.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvComprobantes.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.LightSlateGray;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvComprobantes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvComprobantes.ColumnHeadersHeight = 40;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvComprobantes.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvComprobantes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvComprobantes.EnableHeadersVisualStyles = false;
            this.dgvComprobantes.GridColor = System.Drawing.Color.WhiteSmoke;
            this.dgvComprobantes.Location = new System.Drawing.Point(0, 0);
            this.dgvComprobantes.MultiSelect = false;
            this.dgvComprobantes.Name = "dgvComprobantes";
            this.dgvComprobantes.ReadOnly = true;
            this.dgvComprobantes.RowHeadersVisible = false;
            this.dgvComprobantes.RowHeadersWidth = 50;
            this.dgvComprobantes.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvComprobantes.RowTemplate.Height = 20;
            this.dgvComprobantes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvComprobantes.Size = new System.Drawing.Size(1132, 202);
            this.dgvComprobantes.TabIndex = 0;
            this.dgvComprobantes.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvComprobantes_CellClick);
            this.dgvComprobantes.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvComprobantes_CellMouseClick);
            this.dgvComprobantes.SelectionChanged += new System.EventHandler(this.dgvComprobantes_SelectionChanged);
            // 
            // dgvRecibos
            // 
            this.dgvRecibos.AllowUserToAddRows = false;
            this.dgvRecibos.AllowUserToDeleteRows = false;
            this.dgvRecibos.AllowUserToOrderColumns = true;
            this.dgvRecibos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRecibos.BackgroundColor = System.Drawing.Color.White;
            this.dgvRecibos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvRecibos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.LightSlateGray;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRecibos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvRecibos.ColumnHeadersHeight = 40;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvRecibos.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvRecibos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRecibos.EnableHeadersVisualStyles = false;
            this.dgvRecibos.GridColor = System.Drawing.Color.WhiteSmoke;
            this.dgvRecibos.Location = new System.Drawing.Point(0, 0);
            this.dgvRecibos.MultiSelect = false;
            this.dgvRecibos.Name = "dgvRecibos";
            this.dgvRecibos.ReadOnly = true;
            this.dgvRecibos.RowHeadersVisible = false;
            this.dgvRecibos.RowHeadersWidth = 50;
            this.dgvRecibos.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI Light", 10F);
            this.dgvRecibos.RowTemplate.Height = 20;
            this.dgvRecibos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRecibos.Size = new System.Drawing.Size(1132, 207);
            this.dgvRecibos.TabIndex = 325;
            this.dgvRecibos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRecibos_CellClick);
            // 
            // tbCtaCte
            // 
            this.tbCtaCte.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbCtaCte.Controls.Add(this.tabPageCtaCteMov);
            this.tbCtaCte.Controls.Add(this.tbEstado);
            this.tbCtaCte.Controls.Add(this.tbCtaCteLineal);
            this.tbCtaCte.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCtaCte.Location = new System.Drawing.Point(16, 238);
            this.tbCtaCte.Name = "tbCtaCte";
            this.tbCtaCte.SelectedIndex = 0;
            this.tbCtaCte.Size = new System.Drawing.Size(1139, 451);
            this.tbCtaCte.TabIndex = 0;
            this.tbCtaCte.Selected += new System.Windows.Forms.TabControlEventHandler(this.tbCtaCte_Selected);
            // 
            // tbCtaCteLineal
            // 
            this.tbCtaCteLineal.Controls.Add(this.dgvLineal);
            this.tbCtaCteLineal.Location = new System.Drawing.Point(4, 26);
            this.tbCtaCteLineal.Name = "tbCtaCteLineal";
            this.tbCtaCteLineal.Padding = new System.Windows.Forms.Padding(3);
            this.tbCtaCteLineal.Size = new System.Drawing.Size(1131, 421);
            this.tbCtaCteLineal.TabIndex = 4;
            this.tbCtaCteLineal.Text = "Detalle de Movimientos Lineal";
            this.tbCtaCteLineal.UseVisualStyleBackColor = true;
            // 
            // dgvLineal
            // 
            this.dgvLineal.AllowUserToAddRows = false;
            this.dgvLineal.AllowUserToDeleteRows = false;
            this.dgvLineal.AllowUserToOrderColumns = true;
            this.dgvLineal.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLineal.BackgroundColor = System.Drawing.Color.White;
            this.dgvLineal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvLineal.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.LightSlateGray;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLineal.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvLineal.ColumnHeadersHeight = 40;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLineal.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgvLineal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLineal.EnableHeadersVisualStyles = false;
            this.dgvLineal.GridColor = System.Drawing.Color.WhiteSmoke;
            this.dgvLineal.Location = new System.Drawing.Point(3, 3);
            this.dgvLineal.MultiSelect = false;
            this.dgvLineal.Name = "dgvLineal";
            this.dgvLineal.ReadOnly = true;
            this.dgvLineal.RowHeadersVisible = false;
            this.dgvLineal.RowHeadersWidth = 50;
            this.dgvLineal.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvLineal.RowTemplate.Height = 20;
            this.dgvLineal.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLineal.Size = new System.Drawing.Size(1125, 415);
            this.dgvLineal.TabIndex = 1;
            // 
            // ckPreviewImpresion
            // 
            this.ckPreviewImpresion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ckPreviewImpresion.AutoSize = true;
            this.ckPreviewImpresion.Font = new System.Drawing.Font("Segoe UI Light", 12F);
            this.ckPreviewImpresion.Location = new System.Drawing.Point(883, 140);
            this.ckPreviewImpresion.Name = "ckPreviewImpresion";
            this.ckPreviewImpresion.Size = new System.Drawing.Size(174, 25);
            this.ckPreviewImpresion.TabIndex = 336;
            this.ckPreviewImpresion.Text = "Vista previa impresion";
            this.ckPreviewImpresion.UseVisualStyleBackColor = true;
            // 
            // MenuAcciones
            // 
            this.MenuAcciones.BackColor = System.Drawing.SystemColors.Control;
            this.MenuAcciones.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.MenuAcciones.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsImprimir,
            this.tsGenerarPDF,
            this.tsEditar,
            this.tsEliminar,
            this.tsGenerarFactura,
            this.tsGenerarFacturaCredito,
            this.tsVerComponentes,
            this.tsContratoTemporario,
            this.tsIva,
            this.tsNotaCredito,
            this.generarLinkDePagoToolStripMenuItem});
            this.MenuAcciones.Name = "MenuAcciones";
            this.MenuAcciones.Size = new System.Drawing.Size(216, 246);
            // 
            // tsImprimir
            // 
            this.tsImprimir.Name = "tsImprimir";
            this.tsImprimir.Size = new System.Drawing.Size(215, 22);
            this.tsImprimir.Text = "Imprimir";
            this.tsImprimir.Click += new System.EventHandler(this.tsImprimir_Click);
            // 
            // tsGenerarPDF
            // 
            this.tsGenerarPDF.Name = "tsGenerarPDF";
            this.tsGenerarPDF.Size = new System.Drawing.Size(215, 22);
            this.tsGenerarPDF.Text = "Generar PDF";
            this.tsGenerarPDF.Click += new System.EventHandler(this.tsGenerarPDF_Click);
            // 
            // tsEditar
            // 
            this.tsEditar.Name = "tsEditar";
            this.tsEditar.Size = new System.Drawing.Size(215, 22);
            this.tsEditar.Text = "Editar";
            this.tsEditar.Click += new System.EventHandler(this.tsEditar_Click);
            // 
            // tsEliminar
            // 
            this.tsEliminar.Name = "tsEliminar";
            this.tsEliminar.Size = new System.Drawing.Size(215, 22);
            this.tsEliminar.Text = "Eliminar";
            this.tsEliminar.Click += new System.EventHandler(this.tsEliminar_Click);
            // 
            // tsGenerarFactura
            // 
            this.tsGenerarFactura.Name = "tsGenerarFactura";
            this.tsGenerarFactura.Size = new System.Drawing.Size(215, 22);
            this.tsGenerarFactura.Text = "Generar Factura";
            this.tsGenerarFactura.Click += new System.EventHandler(this.tsGenerarFactura_Click);
            // 
            // tsGenerarFacturaCredito
            // 
            this.tsGenerarFacturaCredito.Name = "tsGenerarFacturaCredito";
            this.tsGenerarFacturaCredito.Size = new System.Drawing.Size(215, 22);
            this.tsGenerarFacturaCredito.Text = "Generar Factura de Credito";
            this.tsGenerarFacturaCredito.Click += new System.EventHandler(this.tsGenerarFacturaCredito_Click);
            // 
            // tsVerComponentes
            // 
            this.tsVerComponentes.Name = "tsVerComponentes";
            this.tsVerComponentes.Size = new System.Drawing.Size(215, 22);
            this.tsVerComponentes.Text = "Ver Componentes";
            this.tsVerComponentes.Click += new System.EventHandler(this.tsVerComponentes_Click);
            // 
            // tsContratoTemporario
            // 
            this.tsContratoTemporario.Name = "tsContratoTemporario";
            this.tsContratoTemporario.Size = new System.Drawing.Size(215, 22);
            this.tsContratoTemporario.Text = "Contrato Temporario";
            this.tsContratoTemporario.Click += new System.EventHandler(this.tsContratoTemporario_Click);
            // 
            // tsIva
            // 
            this.tsIva.Name = "tsIva";
            this.tsIva.Size = new System.Drawing.Size(215, 22);
            this.tsIva.Text = "Ver en IVA";
            this.tsIva.Click += new System.EventHandler(this.tsIva_Click);
            // 
            // tsNotaCredito
            // 
            this.tsNotaCredito.Name = "tsNotaCredito";
            this.tsNotaCredito.Size = new System.Drawing.Size(215, 22);
            this.tsNotaCredito.Text = "Generar Nota de Credito";
            this.tsNotaCredito.Click += new System.EventHandler(this.tsNotaCredito_Click);
            // 
            // generarLinkDePagoToolStripMenuItem
            // 
            this.generarLinkDePagoToolStripMenuItem.Name = "generarLinkDePagoToolStripMenuItem";
            this.generarLinkDePagoToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.generarLinkDePagoToolStripMenuItem.Text = "Generar link de pago";
            this.generarLinkDePagoToolStripMenuItem.Click += new System.EventHandler(this.generarLinkDePagoToolStripMenuItem_ClickAsync);
            // 
            // lblSaldoTotalLoc
            // 
            this.lblSaldoTotalLoc.BackColor = System.Drawing.Color.Transparent;
            this.lblSaldoTotalLoc.Font = new System.Drawing.Font("Segoe UI Light", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSaldoTotalLoc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.lblSaldoTotalLoc.Location = new System.Drawing.Point(7, 131);
            this.lblSaldoTotalLoc.Name = "lblSaldoTotalLoc";
            this.lblSaldoTotalLoc.Size = new System.Drawing.Size(279, 32);
            this.lblSaldoTotalLoc.TabIndex = 337;
            this.lblSaldoTotalLoc.Text = "Saldo $ 0.00";
            this.lblSaldoTotalLoc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnGeneraComprobantes
            // 
            this.btnGeneraComprobantes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGeneraComprobantes.BackColor = System.Drawing.Color.ForestGreen;
            this.btnGeneraComprobantes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGeneraComprobantes.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            this.btnGeneraComprobantes.FlatAppearance.BorderSize = 0;
            this.btnGeneraComprobantes.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(84)))), ((int)(((byte)(101)))));
            this.btnGeneraComprobantes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(58)))), ((int)(((byte)(68)))));
            this.btnGeneraComprobantes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGeneraComprobantes.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGeneraComprobantes.ForeColor = System.Drawing.Color.White;
            this.btnGeneraComprobantes.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGeneraComprobantes.Location = new System.Drawing.Point(777, 175);
            this.btnGeneraComprobantes.Name = "btnGeneraComprobantes";
            this.btnGeneraComprobantes.Size = new System.Drawing.Size(186, 34);
            this.btnGeneraComprobantes.TabIndex = 335;
            this.btnGeneraComprobantes.Text = "Generar Comprobantes";
            this.btnGeneraComprobantes.UseVisualStyleBackColor = false;
            this.btnGeneraComprobantes.Click += new System.EventHandler(this.btnGeneraComprobantes_Click);
            // 
            // btnRecibos
            // 
            this.btnRecibos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRecibos.BackColor = System.Drawing.Color.SteelBlue;
            this.btnRecibos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRecibos.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            this.btnRecibos.FlatAppearance.BorderSize = 0;
            this.btnRecibos.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(84)))), ((int)(((byte)(101)))));
            this.btnRecibos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(58)))), ((int)(((byte)(68)))));
            this.btnRecibos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRecibos.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRecibos.ForeColor = System.Drawing.Color.White;
            this.btnRecibos.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRecibos.Location = new System.Drawing.Point(969, 175);
            this.btnRecibos.Name = "btnRecibos";
            this.btnRecibos.Size = new System.Drawing.Size(186, 34);
            this.btnRecibos.TabIndex = 324;
            this.btnRecibos.Text = "Generar Recibos [F5]";
            this.btnRecibos.UseVisualStyleBackColor = false;
            this.btnRecibos.Click += new System.EventHandler(this.btnRecibos_Click);
            // 
            // cboLocacion
            // 
            this.cboLocacion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboLocacion.BorderColor = System.Drawing.Color.LightGray;
            this.cboLocacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLocacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboLocacion.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboLocacion.FormattingEnabled = true;
            this.cboLocacion.Location = new System.Drawing.Point(85, 95);
            this.cboLocacion.Name = "cboLocacion";
            this.cboLocacion.Size = new System.Drawing.Size(630, 29);
            this.cboLocacion.TabIndex = 322;
            this.cboLocacion.SelectedValueChanged += new System.EventHandler(this.cboLocacion_SelectedValueChanged);
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFiltrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnFiltrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFiltrar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnFiltrar.FlatAppearance.BorderSize = 0;
            this.btnFiltrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnFiltrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnFiltrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFiltrar.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFiltrar.ForeColor = System.Drawing.Color.White;
            this.btnFiltrar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFiltrar.Location = new System.Drawing.Point(1063, 127);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(96, 34);
            this.btnFiltrar.TabIndex = 92;
            this.btnFiltrar.Text = "Buscar";
            this.btnFiltrar.UseVisualStyleBackColor = false;
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);
            // 
            // pgCircular
            // 
            this.pgCircular.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pgCircular.Location = new System.Drawing.Point(1407, 688);
            this.pgCircular.Name = "pgCircular";
            this.pgCircular.Percentage = 0F;
            this.pgCircular.Rotation = CapaPresentacion.Controles.RotationType.CounterClockwise;
            this.pgCircular.Size = new System.Drawing.Size(32, 32);
            this.pgCircular.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(16, 214);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(223, 17);
            this.label1.TabIndex = 338;
            this.label1.Text = "*Click derecho para realizar acciones";
            // 
            // frmUsuariosCtaCteConsultaNuevo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(250)))), ((int)(((byte)(251)))));
            this.ClientSize = new System.Drawing.Size(1167, 718);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblSaldoTotalLoc);
            this.Controls.Add(this.ckPreviewImpresion);
            this.Controls.Add(this.btnGeneraComprobantes);
            this.Controls.Add(this.lbdomfiscal);
            this.Controls.Add(this.LbSaldoCta);
            this.Controls.Add(this.lblComImp);
            this.Controls.Add(this.lblCompDeuda);
            this.Controls.Add(this.lblPlandePago);
            this.Controls.Add(this.tbCtaCte);
            this.Controls.Add(this.btnRecibos);
            this.Controls.Add(this.cboLocacion);
            this.Controls.Add(this.lblLocacion);
            this.Controls.Add(this.lblImpago);
            this.Controls.Add(this.lblCompronteDeuda);
            this.Controls.Add(this.lblPlanPagos);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btnFiltrar);
            this.Controls.Add(this.ckPorFechas);
            this.Controls.Add(this.ckTodos);
            this.Controls.Add(this.dtpHasta);
            this.Controls.Add(this.dtpDesde);
            this.Controls.Add(this.pnLinea1);
            this.Controls.Add(this.txtidlo);
            this.Controls.Add(this.txtidcta);
            this.Controls.Add(this.pgCircular);
            this.Controls.Add(this.lblhasta);
            this.Controls.Add(this.lbldesde);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "frmUsuariosCtaCteConsultaNuevo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Movimientos en Cuenta Corriente";
            this.Load += new System.EventHandler(this.frmUsuariosCtaCteConsulta_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmUsuariosCtaCteConsulta_KeyDown);
            this.pnLinea1.ResumeLayout(false);
            this.pnLinea1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgReturn)).EndInit();
            this.tbEstado.ResumeLayout(false);
            this.tbEstado.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDebeHaber)).EndInit();
            this.tabPageCtaCteMov.ResumeLayout(false);
            this.pnlRuta.ResumeLayout(false);
            this.pnlRuta.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnReturnPDF)).EndInit();
            this.pnlEmail.ResumeLayout(false);
            this.pnlEmail.PerformLayout();
            this.pnlTituloEmail.ResumeLayout(false);
            this.pnlTituloEmail.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnReturnCorreo)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvComprobantes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecibos)).EndInit();
            this.tbCtaCte.ResumeLayout(false);
            this.tbCtaCteLineal.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLineal)).EndInit();
            this.MenuAcciones.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controles.progress pgCircular;
        private System.Windows.Forms.TextBox txtidlo;
        private System.Windows.Forms.TextBox txtidcta;
        private System.Windows.Forms.Label lblocalidad;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Panel pnLinea1;
        private System.Windows.Forms.PictureBox imgReturn;
        private System.Windows.Forms.Label lbTitulo;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.Label lbldesde;
        private System.Windows.Forms.Label lblhasta;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.CheckBox ckTodos;
        private System.Windows.Forms.CheckBox ckPorFechas;
        private Controles.boton btnFiltrar;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblCompronteDeuda;
        private System.Windows.Forms.Label lblPlanPagos;
        private System.Windows.Forms.Label lblImpago;
        private Controles.combo cboLocacion;
        private System.Windows.Forms.Label lblLocacion;
        private Controles.boton btnRecibos;
        private System.Windows.Forms.Label lblPlandePago;
        private System.Windows.Forms.Label lblCompDeuda;
        private System.Windows.Forms.Label lblComImp;
        private System.Windows.Forms.Label LbSaldoCta;
        private System.Windows.Forms.Label lbdomfiscal;
        private System.Windows.Forms.TabPage tbEstado;
        private Controles.boton btnAjuste;
        private Controles.dgv dgvDebeHaber;
        private Controles.boton btnExportar;
        private System.Windows.Forms.TabPage tabPageCtaCteMov;
        private System.Windows.Forms.Panel pnlRuta;
        private Controles.boton btnExaminar;
        private Controles.boton btnGuardar;
        private System.Windows.Forms.Label lblRuta;
        private textboxAdv txtRuta;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox pnReturnPDF;
        private System.Windows.Forms.Panel pnlEmail;
        private System.Windows.Forms.Label lblInfo;
        private Controles.boton btnEnviar;
        private System.Windows.Forms.Label lblCorreo;
        private textboxAdv txtCorreo;
        private System.Windows.Forms.Panel pnlTituloEmail;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pnReturnCorreo;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private Controles.dgv dgvComprobantes;
        private Controles.dgv dgvRecibos;
        private System.Windows.Forms.TabControl tbCtaCte;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private Controles.boton btnGeneraComprobantes;
        private System.Windows.Forms.CheckBox ckPreviewImpresion;
        private System.Windows.Forms.TabPage tbCtaCteLineal;
        private Controles.dgv dgvLineal;
        private System.Windows.Forms.ContextMenuStrip MenuAcciones;
        private System.Windows.Forms.ToolStripMenuItem tsImprimir;
        private System.Windows.Forms.ToolStripMenuItem tsGenerarPDF;
        private System.Windows.Forms.ToolStripMenuItem tsEditar;
        private System.Windows.Forms.ToolStripMenuItem tsEliminar;
        private System.Windows.Forms.ToolStripMenuItem tsGenerarFactura;
        private System.Windows.Forms.ToolStripMenuItem tsVerComponentes;
        private System.Windows.Forms.ToolStripMenuItem tsContratoTemporario;
        private System.Windows.Forms.ToolStripMenuItem tsIva;
        private System.Windows.Forms.Label lblSaldoTotalLoc;
        private System.Windows.Forms.ToolStripMenuItem tsNotaCredito;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem tsGenerarFacturaCredito;
        private System.Windows.Forms.ToolStripMenuItem generarLinkDePagoToolStripMenuItem;
    }
}