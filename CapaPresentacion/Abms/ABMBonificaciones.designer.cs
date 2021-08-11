namespace CapaPresentacion.Abms
{
    partial class ABMBonificaciones
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pgCircular = new CapaPresentacion.Controles.progress();
            this.pnlDatos = new System.Windows.Forms.Panel();
            this.rbVenta = new System.Windows.Forms.RadioButton();
            this.rbPago = new System.Windows.Forms.RadioButton();
            this.spCantidadPeriodos = new CapaPresentacion.Controles.spinner(this.components);
            this.lblPeriodoVigencia = new System.Windows.Forms.Label();
            this.lblCantidadPeriodos = new System.Windows.Forms.Label();
            this.chkContemplarMeses = new System.Windows.Forms.CheckBox();
            this.cboTipoBonificaciones = new CapaPresentacion.Controles.combo(this.components);
            this.lblSimboloPorcentaje = new System.Windows.Forms.Label();
            this.lblTipoBonificacion = new System.Windows.Forms.Label();
            this.txtNombre = new CapaPresentacion.textboxAdv();
            this.lblNombre = new System.Windows.Forms.Label();
            this.dtpFechaDesde = new System.Windows.Forms.DateTimePicker();
            this.lblFechaDesde = new System.Windows.Forms.Label();
            this.chkPorContratacion = new System.Windows.Forms.CheckBox();
            this.dtpFechaHasta = new System.Windows.Forms.DateTimePicker();
            this.lblFechaHasta = new System.Windows.Forms.Label();
            this.spPorcentaje = new CapaPresentacion.Controles.spinner(this.components);
            this.lblPorcentaje = new System.Windows.Forms.Label();
            this.lblBonificaciones = new System.Windows.Forms.Label();
            this.lblAplicacion = new System.Windows.Forms.Label();
            this.lblSinCondiciones = new System.Windows.Forms.Label();
            this.lblConCondiciones = new System.Windows.Forms.Label();
            this.lblReferencias = new System.Windows.Forms.Label();
            this.lblInformacion = new System.Windows.Forms.Label();
            this.lblRequiereCondiciones = new System.Windows.Forms.Label();
            this.btnEliminarAplicacion = new CapaPresentacion.Controles.boton();
            this.dgvAplicaciones = new CapaPresentacion.Controles.dgv(this.components);
            this.btnAsignarItem = new CapaPresentacion.Controles.boton();
            this.dgvBonificaciones = new CapaPresentacion.Controles.dgv(this.components);
            this.btnCancelar = new CapaPresentacion.Controles.boton();
            this.btnGuardar = new CapaPresentacion.Controles.boton();
            this.btnEliminar = new CapaPresentacion.Controles.boton();
            this.btnEditar = new CapaPresentacion.Controles.boton();
            this.btnNuevo = new CapaPresentacion.Controles.boton();
            this.btnActualizar = new CapaPresentacion.Controles.boton();
            this.pnlBonificaciones = new System.Windows.Forms.Panel();
            this.pnlBotnoes = new System.Windows.Forms.Panel();
            this.pnlReferencias = new System.Windows.Forms.Panel();
            this.pnlAplicaciones = new System.Windows.Forms.Panel();
            this.pnlBotonesAplicaciones = new System.Windows.Forms.Panel();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgReturn)).BeginInit();
            this.pnlDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spCantidadPeriodos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spPorcentaje)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAplicaciones)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBonificaciones)).BeginInit();
            this.pnlBonificaciones.SuspendLayout();
            this.pnlBotnoes.SuspendLayout();
            this.pnlReferencias.SuspendLayout();
            this.pnlAplicaciones.SuspendLayout();
            this.pnlBotonesAplicaciones.SuspendLayout();
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
            this.panel3.Size = new System.Drawing.Size(1300, 75);
            this.panel3.TabIndex = 45;
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
            this.lblTituloHeader.Text = "Bonificaciones";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.Location = new System.Drawing.Point(3, 47);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1353, 1);
            this.panel1.TabIndex = 52;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.Gainsboro;
            this.panel2.Location = new System.Drawing.Point(0, 257);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1353, 1);
            this.panel2.TabIndex = 53;
            // 
            // pgCircular
            // 
            this.pgCircular.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pgCircular.Location = new System.Drawing.Point(1258, 4);
            this.pgCircular.Name = "pgCircular";
            this.pgCircular.Percentage = 0F;
            this.pgCircular.Rotation = CapaPresentacion.Controles.RotationType.CounterClockwise;
            this.pgCircular.Size = new System.Drawing.Size(34, 34);
            this.pgCircular.TabIndex = 0;
            // 
            // pnlDatos
            // 
            this.pnlDatos.Controls.Add(this.rbVenta);
            this.pnlDatos.Controls.Add(this.rbPago);
            this.pnlDatos.Controls.Add(this.spCantidadPeriodos);
            this.pnlDatos.Controls.Add(this.lblPeriodoVigencia);
            this.pnlDatos.Controls.Add(this.lblCantidadPeriodos);
            this.pnlDatos.Controls.Add(this.chkContemplarMeses);
            this.pnlDatos.Controls.Add(this.cboTipoBonificaciones);
            this.pnlDatos.Controls.Add(this.lblSimboloPorcentaje);
            this.pnlDatos.Controls.Add(this.lblTipoBonificacion);
            this.pnlDatos.Controls.Add(this.txtNombre);
            this.pnlDatos.Controls.Add(this.lblNombre);
            this.pnlDatos.Controls.Add(this.dtpFechaDesde);
            this.pnlDatos.Controls.Add(this.lblFechaDesde);
            this.pnlDatos.Controls.Add(this.chkPorContratacion);
            this.pnlDatos.Controls.Add(this.dtpFechaHasta);
            this.pnlDatos.Controls.Add(this.lblFechaHasta);
            this.pnlDatos.Controls.Add(this.spPorcentaje);
            this.pnlDatos.Controls.Add(this.lblPorcentaje);
            this.pnlDatos.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlDatos.Enabled = false;
            this.pnlDatos.Location = new System.Drawing.Point(0, 127);
            this.pnlDatos.Name = "pnlDatos";
            this.pnlDatos.Size = new System.Drawing.Size(1300, 126);
            this.pnlDatos.TabIndex = 304;
            // 
            // rbVenta
            // 
            this.rbVenta.AutoSize = true;
            this.rbVenta.Enabled = false;
            this.rbVenta.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.rbVenta.Location = new System.Drawing.Point(358, 92);
            this.rbVenta.Name = "rbVenta";
            this.rbVenta.Size = new System.Drawing.Size(93, 25);
            this.rbVenta.TabIndex = 338;
            this.rbVenta.TabStop = true;
            this.rbVenta.Text = "Por venta";
            this.rbVenta.UseVisualStyleBackColor = true;
            // 
            // rbPago
            // 
            this.rbPago.AutoSize = true;
            this.rbPago.Enabled = false;
            this.rbPago.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.rbPago.Location = new System.Drawing.Point(476, 92);
            this.rbPago.Name = "rbPago";
            this.rbPago.Size = new System.Drawing.Size(90, 25);
            this.rbPago.TabIndex = 337;
            this.rbPago.TabStop = true;
            this.rbPago.Text = "Por pago";
            this.rbPago.UseVisualStyleBackColor = true;
            // 
            // spCantidadPeriodos
            // 
            this.spCantidadPeriodos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.spCantidadPeriodos.BorderColor = System.Drawing.Color.Empty;
            this.spCantidadPeriodos.Enabled = false;
            this.spCantidadPeriodos.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.spCantidadPeriodos.Location = new System.Drawing.Point(894, 53);
            this.spCantidadPeriodos.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spCantidadPeriodos.Name = "spCantidadPeriodos";
            this.spCantidadPeriodos.Size = new System.Drawing.Size(58, 29);
            this.spCantidadPeriodos.TabIndex = 333;
            this.spCantidadPeriodos.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblPeriodoVigencia
            // 
            this.lblPeriodoVigencia.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPeriodoVigencia.AutoSize = true;
            this.lblPeriodoVigencia.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPeriodoVigencia.ForeColor = System.Drawing.Color.Black;
            this.lblPeriodoVigencia.Location = new System.Drawing.Point(605, 13);
            this.lblPeriodoVigencia.Name = "lblPeriodoVigencia";
            this.lblPeriodoVigencia.Size = new System.Drawing.Size(72, 21);
            this.lblPeriodoVigencia.TabIndex = 323;
            this.lblPeriodoVigencia.Text = "Vigencia:";
            // 
            // lblCantidadPeriodos
            // 
            this.lblCantidadPeriodos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCantidadPeriodos.AutoSize = true;
            this.lblCantidadPeriodos.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCantidadPeriodos.ForeColor = System.Drawing.Color.Black;
            this.lblCantidadPeriodos.Location = new System.Drawing.Point(758, 55);
            this.lblCantidadPeriodos.Name = "lblCantidadPeriodos";
            this.lblCantidadPeriodos.Size = new System.Drawing.Size(129, 21);
            this.lblCantidadPeriodos.TabIndex = 334;
            this.lblCantidadPeriodos.Text = "Nro. de periodos:";
            // 
            // chkContemplarMeses
            // 
            this.chkContemplarMeses.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkContemplarMeses.AutoSize = true;
            this.chkContemplarMeses.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.chkContemplarMeses.Location = new System.Drawing.Point(1062, 13);
            this.chkContemplarMeses.Name = "chkContemplarMeses";
            this.chkContemplarMeses.Size = new System.Drawing.Size(192, 25);
            this.chkContemplarMeses.TabIndex = 336;
            this.chkContemplarMeses.Text = "Contemplar sólo meses";
            this.chkContemplarMeses.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkContemplarMeses.UseVisualStyleBackColor = true;
            this.chkContemplarMeses.CheckedChanged += new System.EventHandler(this.chkContemplarMeses_CheckedChanged);
            // 
            // cboTipoBonificaciones
            // 
            this.cboTipoBonificaciones.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboTipoBonificaciones.BorderColor = System.Drawing.Color.Empty;
            this.cboTipoBonificaciones.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoBonificaciones.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboTipoBonificaciones.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cboTipoBonificaciones.ForeColor = System.Drawing.Color.Black;
            this.cboTipoBonificaciones.FormattingEnabled = true;
            this.cboTipoBonificaciones.Items.AddRange(new object[] {
            "POR COMBINACIÓN",
            "POR REPETICIÓN",
            "ESPECIAL"});
            this.cboTipoBonificaciones.Location = new System.Drawing.Point(163, 52);
            this.cboTipoBonificaciones.Name = "cboTipoBonificaciones";
            this.cboTipoBonificaciones.Size = new System.Drawing.Size(428, 29);
            this.cboTipoBonificaciones.TabIndex = 322;
            this.cboTipoBonificaciones.SelectedIndexChanged += new System.EventHandler(this.cboTipoBonificaciones_SelectedIndexChanged);
            // 
            // lblSimboloPorcentaje
            // 
            this.lblSimboloPorcentaje.AutoSize = true;
            this.lblSimboloPorcentaje.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblSimboloPorcentaje.ForeColor = System.Drawing.Color.Black;
            this.lblSimboloPorcentaje.Location = new System.Drawing.Point(232, 98);
            this.lblSimboloPorcentaje.Name = "lblSimboloPorcentaje";
            this.lblSimboloPorcentaje.Size = new System.Drawing.Size(23, 21);
            this.lblSimboloPorcentaje.TabIndex = 321;
            this.lblSimboloPorcentaje.Text = "%";
            // 
            // lblTipoBonificacion
            // 
            this.lblTipoBonificacion.AutoSize = true;
            this.lblTipoBonificacion.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipoBonificacion.ForeColor = System.Drawing.Color.Black;
            this.lblTipoBonificacion.Location = new System.Drawing.Point(3, 55);
            this.lblTipoBonificacion.Name = "lblTipoBonificacion";
            this.lblTipoBonificacion.Size = new System.Drawing.Size(152, 21);
            this.lblTipoBonificacion.TabIndex = 320;
            this.lblTipoBonificacion.Text = "Tipo de bonificación:";
            // 
            // txtNombre
            // 
            this.txtNombre.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNombre.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtNombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNombre.FocusColor = System.Drawing.Color.Empty;
            this.txtNombre.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.ForeColor = System.Drawing.Color.DimGray;
            this.txtNombre.Location = new System.Drawing.Point(80, 12);
            this.txtNombre.MaxLength = 50;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Numerico = false;
            this.txtNombre.Size = new System.Drawing.Size(511, 29);
            this.txtNombre.TabIndex = 307;
            this.txtNombre.Tag = "\"\"";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.ForeColor = System.Drawing.Color.Black;
            this.lblNombre.Location = new System.Drawing.Point(3, 16);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(71, 21);
            this.lblNombre.TabIndex = 305;
            this.lblNombre.Text = "Nombre:";
            // 
            // dtpFechaDesde
            // 
            this.dtpFechaDesde.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpFechaDesde.CustomFormat = "dd/MM/yyyy";
            this.dtpFechaDesde.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.dtpFechaDesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFechaDesde.Location = new System.Drawing.Point(748, 10);
            this.dtpFechaDesde.Name = "dtpFechaDesde";
            this.dtpFechaDesde.Size = new System.Drawing.Size(108, 29);
            this.dtpFechaDesde.TabIndex = 311;
            // 
            // lblFechaDesde
            // 
            this.lblFechaDesde.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFechaDesde.AutoSize = true;
            this.lblFechaDesde.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblFechaDesde.ForeColor = System.Drawing.Color.Black;
            this.lblFechaDesde.Location = new System.Drawing.Point(686, 14);
            this.lblFechaDesde.Name = "lblFechaDesde";
            this.lblFechaDesde.Size = new System.Drawing.Size(56, 21);
            this.lblFechaDesde.TabIndex = 312;
            this.lblFechaDesde.Text = "Desde:";
            // 
            // chkPorContratacion
            // 
            this.chkPorContratacion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkPorContratacion.AutoSize = true;
            this.chkPorContratacion.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.chkPorContratacion.Location = new System.Drawing.Point(610, 54);
            this.chkPorContratacion.Name = "chkPorContratacion";
            this.chkPorContratacion.Size = new System.Drawing.Size(142, 25);
            this.chkPorContratacion.TabIndex = 335;
            this.chkPorContratacion.Text = "Por contratación";
            this.chkPorContratacion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkPorContratacion.UseVisualStyleBackColor = true;
            this.chkPorContratacion.CheckedChanged += new System.EventHandler(this.chkPorContratacion_CheckedChanged);
            // 
            // dtpFechaHasta
            // 
            this.dtpFechaHasta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpFechaHasta.CustomFormat = "dd/MM/yyyy";
            this.dtpFechaHasta.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.dtpFechaHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFechaHasta.Location = new System.Drawing.Point(935, 10);
            this.dtpFechaHasta.Name = "dtpFechaHasta";
            this.dtpFechaHasta.Size = new System.Drawing.Size(108, 29);
            this.dtpFechaHasta.TabIndex = 310;
            // 
            // lblFechaHasta
            // 
            this.lblFechaHasta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFechaHasta.AutoSize = true;
            this.lblFechaHasta.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblFechaHasta.ForeColor = System.Drawing.Color.Black;
            this.lblFechaHasta.Location = new System.Drawing.Point(877, 13);
            this.lblFechaHasta.Name = "lblFechaHasta";
            this.lblFechaHasta.Size = new System.Drawing.Size(52, 21);
            this.lblFechaHasta.TabIndex = 309;
            this.lblFechaHasta.Text = "Hasta:";
            // 
            // spPorcentaje
            // 
            this.spPorcentaje.BorderColor = System.Drawing.Color.Empty;
            this.spPorcentaje.DecimalPlaces = 2;
            this.spPorcentaje.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.spPorcentaje.Location = new System.Drawing.Point(163, 94);
            this.spPorcentaje.Name = "spPorcentaje";
            this.spPorcentaje.Size = new System.Drawing.Size(63, 29);
            this.spPorcentaje.TabIndex = 317;
            this.spPorcentaje.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblPorcentaje
            // 
            this.lblPorcentaje.AutoSize = true;
            this.lblPorcentaje.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPorcentaje.ForeColor = System.Drawing.Color.Black;
            this.lblPorcentaje.Location = new System.Drawing.Point(5, 94);
            this.lblPorcentaje.Name = "lblPorcentaje";
            this.lblPorcentaje.Size = new System.Drawing.Size(147, 21);
            this.lblPorcentaje.TabIndex = 306;
            this.lblPorcentaje.Text = "Porcentaje a aplicar:";
            // 
            // lblBonificaciones
            // 
            this.lblBonificaciones.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblBonificaciones.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBonificaciones.ForeColor = System.Drawing.Color.Black;
            this.lblBonificaciones.Location = new System.Drawing.Point(0, 0);
            this.lblBonificaciones.Name = "lblBonificaciones";
            this.lblBonificaciones.Size = new System.Drawing.Size(1300, 32);
            this.lblBonificaciones.TabIndex = 322;
            this.lblBonificaciones.Text = "Bonificaciones:";
            this.lblBonificaciones.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblAplicacion
            // 
            this.lblAplicacion.AutoSize = true;
            this.lblAplicacion.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAplicacion.ForeColor = System.Drawing.Color.Black;
            this.lblAplicacion.Location = new System.Drawing.Point(5, 12);
            this.lblAplicacion.Name = "lblAplicacion";
            this.lblAplicacion.Size = new System.Drawing.Size(316, 21);
            this.lblAplicacion.TabIndex = 324;
            this.lblAplicacion.Text = "Aplicaciones de la bonificación seleccionada:";
            this.lblAplicacion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSinCondiciones
            // 
            this.lblSinCondiciones.BackColor = System.Drawing.Color.LightCoral;
            this.lblSinCondiciones.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblSinCondiciones.Location = new System.Drawing.Point(939, 8);
            this.lblSinCondiciones.Name = "lblSinCondiciones";
            this.lblSinCondiciones.Size = new System.Drawing.Size(151, 25);
            this.lblSinCondiciones.TabIndex = 329;
            this.lblSinCondiciones.Text = "Sin condiciones";
            this.lblSinCondiciones.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblConCondiciones
            // 
            this.lblConCondiciones.BackColor = System.Drawing.Color.LightGreen;
            this.lblConCondiciones.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblConCondiciones.Location = new System.Drawing.Point(782, 8);
            this.lblConCondiciones.Name = "lblConCondiciones";
            this.lblConCondiciones.Size = new System.Drawing.Size(151, 25);
            this.lblConCondiciones.TabIndex = 328;
            this.lblConCondiciones.Text = "Posee condiciones";
            this.lblConCondiciones.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblReferencias
            // 
            this.lblReferencias.AutoSize = true;
            this.lblReferencias.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblReferencias.ForeColor = System.Drawing.Color.Black;
            this.lblReferencias.Location = new System.Drawing.Point(683, 10);
            this.lblReferencias.Name = "lblReferencias";
            this.lblReferencias.Size = new System.Drawing.Size(93, 21);
            this.lblReferencias.TabIndex = 327;
            this.lblReferencias.Text = "Referencias:";
            // 
            // lblInformacion
            // 
            this.lblInformacion.AutoSize = true;
            this.lblInformacion.Font = new System.Drawing.Font("Segoe UI Light", 12F);
            this.lblInformacion.ForeColor = System.Drawing.Color.Red;
            this.lblInformacion.Location = new System.Drawing.Point(9, 10);
            this.lblInformacion.Name = "lblInformacion";
            this.lblInformacion.Size = new System.Drawing.Size(622, 21);
            this.lblInformacion.TabIndex = 330;
            this.lblInformacion.Text = "*Las bonificaciones que requieren condiciones deben tener al menos una para ser a" +
    "plicadas.";
            // 
            // lblRequiereCondiciones
            // 
            this.lblRequiereCondiciones.BackColor = System.Drawing.Color.Gold;
            this.lblRequiereCondiciones.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblRequiereCondiciones.Location = new System.Drawing.Point(1096, 8);
            this.lblRequiereCondiciones.Name = "lblRequiereCondiciones";
            this.lblRequiereCondiciones.Size = new System.Drawing.Size(151, 25);
            this.lblRequiereCondiciones.TabIndex = 331;
            this.lblRequiereCondiciones.Text = "No requiere";
            this.lblRequiereCondiciones.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnEliminarAplicacion
            // 
            this.btnEliminarAplicacion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEliminarAplicacion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnEliminarAplicacion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminarAplicacion.Enabled = false;
            this.btnEliminarAplicacion.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnEliminarAplicacion.FlatAppearance.BorderSize = 0;
            this.btnEliminarAplicacion.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnEliminarAplicacion.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnEliminarAplicacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminarAplicacion.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminarAplicacion.ForeColor = System.Drawing.Color.White;
            this.btnEliminarAplicacion.Image = global::CapaPresentacion.Properties.Resources.Data_Delete_32;
            this.btnEliminarAplicacion.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEliminarAplicacion.Location = new System.Drawing.Point(1189, 6);
            this.btnEliminarAplicacion.Name = "btnEliminarAplicacion";
            this.btnEliminarAplicacion.Size = new System.Drawing.Size(99, 33);
            this.btnEliminarAplicacion.TabIndex = 326;
            this.btnEliminarAplicacion.Text = "Eliminar";
            this.btnEliminarAplicacion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEliminarAplicacion.UseVisualStyleBackColor = false;
            this.btnEliminarAplicacion.Click += new System.EventHandler(this.btnEliminarAplicacion_Click);
            // 
            // dgvAplicaciones
            // 
            this.dgvAplicaciones.AllowUserToAddRows = false;
            this.dgvAplicaciones.AllowUserToDeleteRows = false;
            this.dgvAplicaciones.AllowUserToOrderColumns = true;
            this.dgvAplicaciones.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAplicaciones.BackgroundColor = System.Drawing.Color.White;
            this.dgvAplicaciones.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvAplicaciones.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.LightSlateGray;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAplicaciones.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvAplicaciones.ColumnHeadersHeight = 40;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvAplicaciones.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvAplicaciones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAplicaciones.EnableHeadersVisualStyles = false;
            this.dgvAplicaciones.GridColor = System.Drawing.Color.WhiteSmoke;
            this.dgvAplicaciones.Location = new System.Drawing.Point(0, 45);
            this.dgvAplicaciones.MultiSelect = false;
            this.dgvAplicaciones.Name = "dgvAplicaciones";
            this.dgvAplicaciones.ReadOnly = true;
            this.dgvAplicaciones.RowHeadersVisible = false;
            this.dgvAplicaciones.RowHeadersWidth = 50;
            this.dgvAplicaciones.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvAplicaciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAplicaciones.Size = new System.Drawing.Size(1300, 91);
            this.dgvAplicaciones.TabIndex = 323;
            this.dgvAplicaciones.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAplicaciones_CellClick);
            // 
            // btnAsignarItem
            // 
            this.btnAsignarItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAsignarItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnAsignarItem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAsignarItem.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnAsignarItem.FlatAppearance.BorderSize = 0;
            this.btnAsignarItem.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnAsignarItem.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnAsignarItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAsignarItem.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnAsignarItem.ForeColor = System.Drawing.Color.White;
            this.btnAsignarItem.Image = global::CapaPresentacion.Properties.Resources.Data_Add_32;
            this.btnAsignarItem.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAsignarItem.Location = new System.Drawing.Point(1084, 6);
            this.btnAsignarItem.Name = "btnAsignarItem";
            this.btnAsignarItem.Size = new System.Drawing.Size(99, 33);
            this.btnAsignarItem.TabIndex = 316;
            this.btnAsignarItem.Text = "Nueva";
            this.btnAsignarItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAsignarItem.UseVisualStyleBackColor = false;
            this.btnAsignarItem.Click += new System.EventHandler(this.btnAsignarItem_Click);
            // 
            // dgvBonificaciones
            // 
            this.dgvBonificaciones.AllowUserToAddRows = false;
            this.dgvBonificaciones.AllowUserToDeleteRows = false;
            this.dgvBonificaciones.AllowUserToOrderColumns = true;
            this.dgvBonificaciones.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBonificaciones.BackgroundColor = System.Drawing.Color.White;
            this.dgvBonificaciones.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvBonificaciones.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.LightSlateGray;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvBonificaciones.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvBonificaciones.ColumnHeadersHeight = 40;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvBonificaciones.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgvBonificaciones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBonificaciones.Enabled = false;
            this.dgvBonificaciones.EnableHeadersVisualStyles = false;
            this.dgvBonificaciones.GridColor = System.Drawing.Color.WhiteSmoke;
            this.dgvBonificaciones.Location = new System.Drawing.Point(0, 32);
            this.dgvBonificaciones.MultiSelect = false;
            this.dgvBonificaciones.Name = "dgvBonificaciones";
            this.dgvBonificaciones.ReadOnly = true;
            this.dgvBonificaciones.RowHeadersVisible = false;
            this.dgvBonificaciones.RowHeadersWidth = 50;
            this.dgvBonificaciones.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvBonificaciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBonificaciones.Size = new System.Drawing.Size(1300, 160);
            this.dgvBonificaciones.TabIndex = 57;
            this.dgvBonificaciones.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBonificaciones_CellEnter);
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
            this.btnCancelar.Location = new System.Drawing.Point(1181, 6);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(110, 35);
            this.btnCancelar.TabIndex = 51;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
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
            this.btnGuardar.Location = new System.Drawing.Point(1065, 6);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(110, 35);
            this.btnGuardar.TabIndex = 50;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEliminar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnEliminar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnEliminar.FlatAppearance.BorderSize = 0;
            this.btnEliminar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnEliminar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.ForeColor = System.Drawing.Color.White;
            this.btnEliminar.Image = global::CapaPresentacion.Properties.Resources.Data_Delete_32;
            this.btnEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEliminar.Location = new System.Drawing.Point(949, 6);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(110, 35);
            this.btnEliminar.TabIndex = 49;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnEditar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnEditar.FlatAppearance.BorderSize = 0;
            this.btnEditar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnEditar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnEditar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditar.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditar.ForeColor = System.Drawing.Color.White;
            this.btnEditar.Image = global::CapaPresentacion.Properties.Resources.Data_Edit_32__1_;
            this.btnEditar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEditar.Location = new System.Drawing.Point(833, 6);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(110, 35);
            this.btnEditar.TabIndex = 48;
            this.btnEditar.Text = "Editar";
            this.btnEditar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEditar.UseVisualStyleBackColor = false;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNuevo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnNuevo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNuevo.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnNuevo.FlatAppearance.BorderSize = 0;
            this.btnNuevo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnNuevo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevo.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevo.ForeColor = System.Drawing.Color.White;
            this.btnNuevo.Image = global::CapaPresentacion.Properties.Resources.Data_Add_32;
            this.btnNuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNuevo.Location = new System.Drawing.Point(716, 6);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(110, 35);
            this.btnNuevo.TabIndex = 47;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNuevo.UseVisualStyleBackColor = false;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
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
            this.btnActualizar.Location = new System.Drawing.Point(600, 6);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(110, 35);
            this.btnActualizar.TabIndex = 46;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnActualizar.UseVisualStyleBackColor = false;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // pnlBonificaciones
            // 
            this.pnlBonificaciones.Controls.Add(this.dgvBonificaciones);
            this.pnlBonificaciones.Controls.Add(this.lblBonificaciones);
            this.pnlBonificaciones.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBonificaciones.Location = new System.Drawing.Point(0, 253);
            this.pnlBonificaciones.Name = "pnlBonificaciones";
            this.pnlBonificaciones.Size = new System.Drawing.Size(1300, 192);
            this.pnlBonificaciones.TabIndex = 332;
            // 
            // pnlBotnoes
            // 
            this.pnlBotnoes.Controls.Add(this.btnCancelar);
            this.pnlBotnoes.Controls.Add(this.btnActualizar);
            this.pnlBotnoes.Controls.Add(this.btnNuevo);
            this.pnlBotnoes.Controls.Add(this.btnEditar);
            this.pnlBotnoes.Controls.Add(this.btnEliminar);
            this.pnlBotnoes.Controls.Add(this.btnGuardar);
            this.pnlBotnoes.Controls.Add(this.panel1);
            this.pnlBotnoes.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBotnoes.Location = new System.Drawing.Point(0, 75);
            this.pnlBotnoes.Name = "pnlBotnoes";
            this.pnlBotnoes.Size = new System.Drawing.Size(1300, 52);
            this.pnlBotnoes.TabIndex = 333;
            // 
            // pnlReferencias
            // 
            this.pnlReferencias.Controls.Add(this.lblInformacion);
            this.pnlReferencias.Controls.Add(this.pgCircular);
            this.pnlReferencias.Controls.Add(this.lblReferencias);
            this.pnlReferencias.Controls.Add(this.lblRequiereCondiciones);
            this.pnlReferencias.Controls.Add(this.lblConCondiciones);
            this.pnlReferencias.Controls.Add(this.lblSinCondiciones);
            this.pnlReferencias.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlReferencias.Location = new System.Drawing.Point(0, 581);
            this.pnlReferencias.Name = "pnlReferencias";
            this.pnlReferencias.Size = new System.Drawing.Size(1300, 42);
            this.pnlReferencias.TabIndex = 334;
            // 
            // pnlAplicaciones
            // 
            this.pnlAplicaciones.Controls.Add(this.dgvAplicaciones);
            this.pnlAplicaciones.Controls.Add(this.pnlBotonesAplicaciones);
            this.pnlAplicaciones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlAplicaciones.Location = new System.Drawing.Point(0, 445);
            this.pnlAplicaciones.Name = "pnlAplicaciones";
            this.pnlAplicaciones.Size = new System.Drawing.Size(1300, 136);
            this.pnlAplicaciones.TabIndex = 335;
            // 
            // pnlBotonesAplicaciones
            // 
            this.pnlBotonesAplicaciones.Controls.Add(this.lblAplicacion);
            this.pnlBotonesAplicaciones.Controls.Add(this.btnAsignarItem);
            this.pnlBotonesAplicaciones.Controls.Add(this.btnEliminarAplicacion);
            this.pnlBotonesAplicaciones.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBotonesAplicaciones.Location = new System.Drawing.Point(0, 0);
            this.pnlBotonesAplicaciones.Name = "pnlBotonesAplicaciones";
            this.pnlBotonesAplicaciones.Size = new System.Drawing.Size(1300, 45);
            this.pnlBotonesAplicaciones.TabIndex = 325;
            // 
            // ABMBonificaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(250)))), ((int)(((byte)(251)))));
            this.ClientSize = new System.Drawing.Size(1300, 623);
            this.Controls.Add(this.pnlAplicaciones);
            this.Controls.Add(this.pnlReferencias);
            this.Controls.Add(this.pnlBonificaciones);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pnlDatos);
            this.Controls.Add(this.pnlBotnoes);
            this.Controls.Add(this.panel3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "ABMBonificaciones";
            this.Text = "ABMBonificacionesSubServicios";
            this.Load += new System.EventHandler(this.ABMBonificaciones_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ABMBonificaciones_KeyDown);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgReturn)).EndInit();
            this.pnlDatos.ResumeLayout(false);
            this.pnlDatos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spCantidadPeriodos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spPorcentaje)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAplicaciones)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBonificaciones)).EndInit();
            this.pnlBonificaciones.ResumeLayout(false);
            this.pnlBotnoes.ResumeLayout(false);
            this.pnlReferencias.ResumeLayout(false);
            this.pnlReferencias.PerformLayout();
            this.pnlAplicaciones.ResumeLayout(false);
            this.pnlBotonesAplicaciones.ResumeLayout(false);
            this.pnlBotonesAplicaciones.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox imgReturn;
        private System.Windows.Forms.Label lblTituloHeader;
        private Controles.boton btnCancelar;
        private Controles.boton btnEliminar;
        private Controles.boton btnEditar;
        private Controles.boton btnNuevo;
        private Controles.boton btnActualizar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private Controles.dgv dgvBonificaciones;
        private Controles.progress pgCircular;
        private System.Windows.Forms.Panel pnlDatos;
        private Controles.boton btnAsignarItem;
        private textboxAdv txtNombre;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblPorcentaje;
        private System.Windows.Forms.Label lblFechaDesde;
        private System.Windows.Forms.Label lblFechaHasta;
        private System.Windows.Forms.DateTimePicker dtpFechaDesde;
        private System.Windows.Forms.DateTimePicker dtpFechaHasta;
        private Controles.spinner spPorcentaje;
        private System.Windows.Forms.Label lblBonificaciones;
        private Controles.dgv dgvAplicaciones;
        private System.Windows.Forms.Label lblAplicacion;
        private Controles.boton btnEliminarAplicacion;
        private System.Windows.Forms.Label lblTipoBonificacion;
        private System.Windows.Forms.Label lblSimboloPorcentaje;
        private System.Windows.Forms.Label lblSinCondiciones;
        private System.Windows.Forms.Label lblConCondiciones;
        private System.Windows.Forms.Label lblReferencias;
        private System.Windows.Forms.Label lblInformacion;
        private Controles.combo cboTipoBonificaciones;
        private System.Windows.Forms.Label lblRequiereCondiciones;
        private Controles.boton btnGuardar;
        private System.Windows.Forms.Label lblCantidadPeriodos;
        private Controles.spinner spCantidadPeriodos;
        private System.Windows.Forms.CheckBox chkContemplarMeses;
        private System.Windows.Forms.CheckBox chkPorContratacion;
        private System.Windows.Forms.Label lblPeriodoVigencia;
        private System.Windows.Forms.RadioButton rbVenta;
        private System.Windows.Forms.RadioButton rbPago;
        private System.Windows.Forms.Panel pnlBonificaciones;
        private System.Windows.Forms.Panel pnlBotnoes;
        private System.Windows.Forms.Panel pnlReferencias;
        private System.Windows.Forms.Panel pnlAplicaciones;
        private System.Windows.Forms.Panel pnlBotonesAplicaciones;
    }
}