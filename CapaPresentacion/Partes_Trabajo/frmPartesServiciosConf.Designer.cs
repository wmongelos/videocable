namespace CapaPresentacion.Partes_Trabajo
{
    partial class frmPartesServiciosConf
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
            this.pnlSuperior = new System.Windows.Forms.Panel();
            this.imgReturn = new System.Windows.Forms.PictureBox();
            this.lblTituloHeader = new System.Windows.Forms.Label();
            this.pnlFiltros = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.txtParte = new CapaPresentacion.textboxAdv();
            this.cboOperaciones = new CapaPresentacion.Controles.combo(this.components);
            this.lblFecha = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCodigo = new CapaPresentacion.textboxAdv();
            this.pnlInferior = new System.Windows.Forms.Panel();
            this.lblFechaUltimoDato = new System.Windows.Forms.Label();
            this.lbCantPosterioresDato = new System.Windows.Forms.Label();
            this.lblTotalDato = new System.Windows.Forms.Label();
            this.lblFechaUltimo = new System.Windows.Forms.Label();
            this.lbCantPosteriores = new System.Windows.Forms.Label();
            this.pgCircular = new CapaPresentacion.Controles.progress();
            this.lblTotal = new System.Windows.Forms.Label();
            this.pnlContenido = new System.Windows.Forms.Panel();
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tabOperaciones = new System.Windows.Forms.TabPage();
            this.dgvPartes = new CapaPresentacion.Controles.dgv(this.components);
            this.pnlBotones = new System.Windows.Forms.Panel();
            this.comboAppExternas = new CapaPresentacion.Controles.combo(this.components);
            this.btnCargar = new CapaPresentacion.Controles.boton();
            this.btnSeleccionar = new CapaPresentacion.Controles.boton();
            this.btnImprimir = new CapaPresentacion.Controles.boton();
            this.btnPaasarAconf = new CapaPresentacion.Controles.boton();
            this.btnAsignarTecnico = new CapaPresentacion.Controles.boton();
            this.btnConectar = new CapaPresentacion.Controles.boton();
            this.btnAsignarEquipos = new CapaPresentacion.Controles.boton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblListoParaConfg = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tabPartesInternos = new System.Windows.Forms.TabPage();
            this.dgvPartesInternos = new CapaPresentacion.Controles.dgv(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.boton2 = new CapaPresentacion.Controles.boton();
            this.boton5 = new CapaPresentacion.Controles.boton();
            this.tmrTimer = new System.Windows.Forms.Timer(this.components);
            this.pnlSuperior.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgReturn)).BeginInit();
            this.pnlFiltros.SuspendLayout();
            this.pnlInferior.SuspendLayout();
            this.pnlContenido.SuspendLayout();
            this.tabMain.SuspendLayout();
            this.tabOperaciones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPartes)).BeginInit();
            this.pnlBotones.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabPartesInternos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPartesInternos)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlSuperior
            // 
            this.pnlSuperior.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.pnlSuperior.Controls.Add(this.imgReturn);
            this.pnlSuperior.Controls.Add(this.lblTituloHeader);
            this.pnlSuperior.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSuperior.Location = new System.Drawing.Point(0, 0);
            this.pnlSuperior.Name = "pnlSuperior";
            this.pnlSuperior.Size = new System.Drawing.Size(1386, 75);
            this.pnlSuperior.TabIndex = 51;
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
            this.lblTituloHeader.Size = new System.Drawing.Size(242, 23);
            this.lblTituloHeader.TabIndex = 31;
            this.lblTituloHeader.Text = "Partes para configuracion";
            // 
            // pnlFiltros
            // 
            this.pnlFiltros.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFiltros.Controls.Add(this.comboAppExternas);
            this.pnlFiltros.Controls.Add(this.btnCargar);
            this.pnlFiltros.Controls.Add(this.cboOperaciones);
            this.pnlFiltros.Controls.Add(this.lblFecha);
            this.pnlFiltros.Controls.Add(this.label2);
            this.pnlFiltros.Controls.Add(this.dtpFecha);
            this.pnlFiltros.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFiltros.Location = new System.Drawing.Point(3, 3);
            this.pnlFiltros.Name = "pnlFiltros";
            this.pnlFiltros.Size = new System.Drawing.Size(1372, 46);
            this.pnlFiltros.TabIndex = 52;
            this.pnlFiltros.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlBotones_Paint);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(142, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 21);
            this.label3.TabIndex = 329;
            this.label3.Text = "N° de parte:";
            // 
            // txtParte
            // 
            this.txtParte.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtParte.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtParte.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtParte.Enabled = false;
            this.txtParte.FocusColor = System.Drawing.Color.Empty;
            this.txtParte.Font = new System.Drawing.Font("Segoe UI Light", 12F);
            this.txtParte.ForeColor = System.Drawing.Color.Black;
            this.txtParte.Location = new System.Drawing.Point(240, 10);
            this.txtParte.Name = "txtParte";
            this.txtParte.Numerico = false;
            this.txtParte.Size = new System.Drawing.Size(63, 29);
            this.txtParte.TabIndex = 328;
            this.txtParte.TextChanged += new System.EventHandler(this.txtParte_TextChanged);
            // 
            // cboOperaciones
            // 
            this.cboOperaciones.BorderColor = System.Drawing.Color.Gainsboro;
            this.cboOperaciones.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboOperaciones.Enabled = false;
            this.cboOperaciones.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboOperaciones.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboOperaciones.FormattingEnabled = true;
            this.cboOperaciones.Location = new System.Drawing.Point(427, 6);
            this.cboOperaciones.Name = "cboOperaciones";
            this.cboOperaciones.Size = new System.Drawing.Size(206, 29);
            this.cboOperaciones.TabIndex = 321;
            this.cboOperaciones.SelectedValueChanged += new System.EventHandler(this.cboOperaciones_SelectedValueChanged);
            // 
            // lblFecha
            // 
            this.lblFecha.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFecha.AutoSize = true;
            this.lblFecha.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFecha.ForeColor = System.Drawing.Color.Black;
            this.lblFecha.Location = new System.Drawing.Point(846, 11);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(182, 21);
            this.lblFecha.TabIndex = 327;
            this.lblFecha.Text = "Fecha programado hasta";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(341, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 21);
            this.label2.TabIndex = 322;
            this.label2.Text = "Tipo parte";
            // 
            // dtpFecha
            // 
            this.dtpFecha.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpFecha.Font = new System.Drawing.Font("Segoe UI Light", 12F);
            this.dtpFecha.Location = new System.Drawing.Point(1034, 8);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(326, 29);
            this.dtpFecha.TabIndex = 326;
            this.dtpFecha.ValueChanged += new System.EventHandler(this.dtpFecha_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(14, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 21);
            this.label1.TabIndex = 317;
            this.label1.Text = "Usuario:";
            // 
            // txtCodigo
            // 
            this.txtCodigo.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtCodigo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCodigo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCodigo.Enabled = false;
            this.txtCodigo.FocusColor = System.Drawing.Color.Empty;
            this.txtCodigo.Font = new System.Drawing.Font("Segoe UI Light", 12F);
            this.txtCodigo.ForeColor = System.Drawing.Color.Black;
            this.txtCodigo.Location = new System.Drawing.Point(88, 10);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Numerico = false;
            this.txtCodigo.Size = new System.Drawing.Size(48, 29);
            this.txtCodigo.TabIndex = 316;
            this.txtCodigo.TextChanged += new System.EventHandler(this.txtCodigo_TextChanged);
            // 
            // pnlInferior
            // 
            this.pnlInferior.Controls.Add(this.lblFechaUltimoDato);
            this.pnlInferior.Controls.Add(this.lbCantPosterioresDato);
            this.pnlInferior.Controls.Add(this.lblTotalDato);
            this.pnlInferior.Controls.Add(this.lblFechaUltimo);
            this.pnlInferior.Controls.Add(this.lbCantPosteriores);
            this.pnlInferior.Controls.Add(this.pgCircular);
            this.pnlInferior.Controls.Add(this.lblTotal);
            this.pnlInferior.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlInferior.Location = new System.Drawing.Point(0, 604);
            this.pnlInferior.Name = "pnlInferior";
            this.pnlInferior.Size = new System.Drawing.Size(1386, 40);
            this.pnlInferior.TabIndex = 54;
            // 
            // lblFechaUltimoDato
            // 
            this.lblFechaUltimoDato.AutoSize = true;
            this.lblFechaUltimoDato.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaUltimoDato.ForeColor = System.Drawing.Color.Black;
            this.lblFechaUltimoDato.Location = new System.Drawing.Point(773, 10);
            this.lblFechaUltimoDato.Name = "lblFechaUltimoDato";
            this.lblFechaUltimoDato.Size = new System.Drawing.Size(48, 21);
            this.lblFechaUltimoDato.TabIndex = 312;
            this.lblFechaUltimoDato.Text = "Total";
            // 
            // lbCantPosterioresDato
            // 
            this.lbCantPosterioresDato.AutoSize = true;
            this.lbCantPosterioresDato.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCantPosterioresDato.ForeColor = System.Drawing.Color.Black;
            this.lbCantPosterioresDato.Location = new System.Drawing.Point(433, 10);
            this.lbCantPosterioresDato.Name = "lbCantPosterioresDato";
            this.lbCantPosterioresDato.Size = new System.Drawing.Size(48, 21);
            this.lbCantPosterioresDato.TabIndex = 311;
            this.lbCantPosterioresDato.Text = "Total";
            // 
            // lblTotalDato
            // 
            this.lblTotalDato.AutoSize = true;
            this.lblTotalDato.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalDato.ForeColor = System.Drawing.Color.Black;
            this.lblTotalDato.Location = new System.Drawing.Point(157, 10);
            this.lblTotalDato.Name = "lblTotalDato";
            this.lblTotalDato.Size = new System.Drawing.Size(48, 21);
            this.lblTotalDato.TabIndex = 310;
            this.lblTotalDato.Text = "Total";
            // 
            // lblFechaUltimo
            // 
            this.lblFechaUltimo.AutoSize = true;
            this.lblFechaUltimo.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblFechaUltimo.ForeColor = System.Drawing.Color.Black;
            this.lblFechaUltimo.Location = new System.Drawing.Point(619, 10);
            this.lblFechaUltimo.Name = "lblFechaUltimo";
            this.lblFechaUltimo.Size = new System.Drawing.Size(148, 21);
            this.lblFechaUltimo.TabIndex = 309;
            this.lblFechaUltimo.Text = "Total de Registros: 0";
            // 
            // lbCantPosteriores
            // 
            this.lbCantPosteriores.AutoSize = true;
            this.lbCantPosteriores.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lbCantPosteriores.ForeColor = System.Drawing.Color.Black;
            this.lbCantPosteriores.Location = new System.Drawing.Point(279, 10);
            this.lbCantPosteriores.Name = "lbCantPosteriores";
            this.lbCantPosteriores.Size = new System.Drawing.Size(148, 21);
            this.lbCantPosteriores.TabIndex = 308;
            this.lbCantPosteriores.Text = "Total de Registros: 0";
            // 
            // pgCircular
            // 
            this.pgCircular.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pgCircular.Location = new System.Drawing.Point(1349, 3);
            this.pgCircular.Name = "pgCircular";
            this.pgCircular.Percentage = 0F;
            this.pgCircular.Rotation = CapaPresentacion.Controles.RotationType.CounterClockwise;
            this.pgCircular.Size = new System.Drawing.Size(34, 34);
            this.pgCircular.TabIndex = 15;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblTotal.ForeColor = System.Drawing.Color.Black;
            this.lblTotal.Location = new System.Drawing.Point(3, 10);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(148, 21);
            this.lblTotal.TabIndex = 14;
            this.lblTotal.Text = "Total de Registros: 0";
            // 
            // pnlContenido
            // 
            this.pnlContenido.Controls.Add(this.tabMain);
            this.pnlContenido.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContenido.Location = new System.Drawing.Point(0, 75);
            this.pnlContenido.Name = "pnlContenido";
            this.pnlContenido.Size = new System.Drawing.Size(1386, 529);
            this.pnlContenido.TabIndex = 55;
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.tabOperaciones);
            this.tabMain.Controls.Add(this.tabPartesInternos);
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabMain.Location = new System.Drawing.Point(0, 0);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(1386, 529);
            this.tabMain.TabIndex = 56;
            this.tabMain.SelectedIndexChanged += new System.EventHandler(this.tabMain_SelectedIndexChanged);
            this.tabMain.TabIndexChanged += new System.EventHandler(this.tabMain_TabIndexChanged);
            // 
            // tabOperaciones
            // 
            this.tabOperaciones.Controls.Add(this.dgvPartes);
            this.tabOperaciones.Controls.Add(this.pnlBotones);
            this.tabOperaciones.Controls.Add(this.panel1);
            this.tabOperaciones.Controls.Add(this.pnlFiltros);
            this.tabOperaciones.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabOperaciones.Location = new System.Drawing.Point(4, 34);
            this.tabOperaciones.Name = "tabOperaciones";
            this.tabOperaciones.Padding = new System.Windows.Forms.Padding(3);
            this.tabOperaciones.Size = new System.Drawing.Size(1378, 491);
            this.tabOperaciones.TabIndex = 0;
            this.tabOperaciones.Text = "Partes";
            this.tabOperaciones.UseVisualStyleBackColor = true;
            // 
            // dgvPartes
            // 
            this.dgvPartes.AllowUserToAddRows = false;
            this.dgvPartes.AllowUserToDeleteRows = false;
            this.dgvPartes.AllowUserToOrderColumns = true;
            this.dgvPartes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPartes.BackgroundColor = System.Drawing.Color.White;
            this.dgvPartes.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvPartes.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSlateGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPartes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPartes.ColumnHeadersHeight = 40;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPartes.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvPartes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPartes.EnableHeadersVisualStyles = false;
            this.dgvPartes.GridColor = System.Drawing.Color.WhiteSmoke;
            this.dgvPartes.Location = new System.Drawing.Point(3, 95);
            this.dgvPartes.MultiSelect = false;
            this.dgvPartes.Name = "dgvPartes";
            this.dgvPartes.ReadOnly = true;
            this.dgvPartes.RowHeadersVisible = false;
            this.dgvPartes.RowHeadersWidth = 50;
            this.dgvPartes.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvPartes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPartes.Size = new System.Drawing.Size(1372, 353);
            this.dgvPartes.TabIndex = 52;
            this.dgvPartes.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPartes_CellClick);
            this.dgvPartes.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPartes_CellContentClick);
            this.dgvPartes.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPartes_CellEnter);
            this.dgvPartes.ColumnSortModeChanged += new System.Windows.Forms.DataGridViewColumnEventHandler(this.dgvPartes_ColumnSortModeChanged);
            this.dgvPartes.SelectionChanged += new System.EventHandler(this.dgvPartes_SelectionChanged);
            this.dgvPartes.Sorted += new System.EventHandler(this.dgvPartes_Sorted);
            // 
            // pnlBotones
            // 
            this.pnlBotones.Controls.Add(this.btnSeleccionar);
            this.pnlBotones.Controls.Add(this.btnImprimir);
            this.pnlBotones.Controls.Add(this.label3);
            this.pnlBotones.Controls.Add(this.btnPaasarAconf);
            this.pnlBotones.Controls.Add(this.btnAsignarTecnico);
            this.pnlBotones.Controls.Add(this.btnConectar);
            this.pnlBotones.Controls.Add(this.txtParte);
            this.pnlBotones.Controls.Add(this.btnAsignarEquipos);
            this.pnlBotones.Controls.Add(this.txtCodigo);
            this.pnlBotones.Controls.Add(this.label1);
            this.pnlBotones.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBotones.Location = new System.Drawing.Point(3, 49);
            this.pnlBotones.Name = "pnlBotones";
            this.pnlBotones.Size = new System.Drawing.Size(1372, 46);
            this.pnlBotones.TabIndex = 53;
            this.pnlBotones.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlBotones_Paint_1);
            // 
            // comboAppExternas
            // 
            this.comboAppExternas.BorderColor = System.Drawing.Color.Gainsboro;
            this.comboAppExternas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboAppExternas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboAppExternas.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboAppExternas.FormattingEnabled = true;
            this.comboAppExternas.Location = new System.Drawing.Point(7, 7);
            this.comboAppExternas.Name = "comboAppExternas";
            this.comboAppExternas.Size = new System.Drawing.Size(206, 29);
            this.comboAppExternas.TabIndex = 327;
            // 
            // btnCargar
            // 
            this.btnCargar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnCargar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCargar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnCargar.FlatAppearance.BorderSize = 0;
            this.btnCargar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnCargar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnCargar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCargar.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnCargar.ForeColor = System.Drawing.Color.White;
            this.btnCargar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCargar.Location = new System.Drawing.Point(218, 6);
            this.btnCargar.Margin = new System.Windows.Forms.Padding(2);
            this.btnCargar.Name = "btnCargar";
            this.btnCargar.Size = new System.Drawing.Size(104, 31);
            this.btnCargar.TabIndex = 326;
            this.btnCargar.Text = "Cargar";
            this.btnCargar.UseVisualStyleBackColor = false;
            this.btnCargar.Click += new System.EventHandler(this.btnCargar_Click);
            // 
            // btnSeleccionar
            // 
            this.btnSeleccionar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSeleccionar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnSeleccionar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSeleccionar.Enabled = false;
            this.btnSeleccionar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnSeleccionar.FlatAppearance.BorderSize = 0;
            this.btnSeleccionar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnSeleccionar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnSeleccionar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSeleccionar.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnSeleccionar.ForeColor = System.Drawing.Color.White;
            this.btnSeleccionar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSeleccionar.Location = new System.Drawing.Point(733, 7);
            this.btnSeleccionar.Margin = new System.Windows.Forms.Padding(2);
            this.btnSeleccionar.Name = "btnSeleccionar";
            this.btnSeleccionar.Size = new System.Drawing.Size(160, 31);
            this.btnSeleccionar.TabIndex = 325;
            this.btnSeleccionar.Text = "Seleccionar todos";
            this.btnSeleccionar.UseVisualStyleBackColor = false;
            this.btnSeleccionar.Click += new System.EventHandler(this.btnSeleccionar_Click);
            // 
            // btnImprimir
            // 
            this.btnImprimir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImprimir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnImprimir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnImprimir.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnImprimir.FlatAppearance.BorderSize = 0;
            this.btnImprimir.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnImprimir.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImprimir.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnImprimir.ForeColor = System.Drawing.Color.White;
            this.btnImprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnImprimir.Location = new System.Drawing.Point(625, 7);
            this.btnImprimir.Margin = new System.Windows.Forms.Padding(2);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(104, 31);
            this.btnImprimir.TabIndex = 318;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.UseVisualStyleBackColor = false;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // btnPaasarAconf
            // 
            this.btnPaasarAconf.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPaasarAconf.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnPaasarAconf.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPaasarAconf.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnPaasarAconf.FlatAppearance.BorderSize = 0;
            this.btnPaasarAconf.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnPaasarAconf.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnPaasarAconf.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPaasarAconf.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnPaasarAconf.ForeColor = System.Drawing.Color.White;
            this.btnPaasarAconf.Image = global::CapaPresentacion.Properties.Resources.Data_Add_32;
            this.btnPaasarAconf.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPaasarAconf.Location = new System.Drawing.Point(432, 7);
            this.btnPaasarAconf.Margin = new System.Windows.Forms.Padding(2);
            this.btnPaasarAconf.Name = "btnPaasarAconf";
            this.btnPaasarAconf.Size = new System.Drawing.Size(189, 31);
            this.btnPaasarAconf.TabIndex = 316;
            this.btnPaasarAconf.Text = "Pasar a configurado";
            this.btnPaasarAconf.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPaasarAconf.UseVisualStyleBackColor = false;
            this.btnPaasarAconf.Visible = false;
            this.btnPaasarAconf.Click += new System.EventHandler(this.btnPaasarAconf_Click);
            // 
            // btnAsignarTecnico
            // 
            this.btnAsignarTecnico.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAsignarTecnico.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnAsignarTecnico.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAsignarTecnico.Enabled = false;
            this.btnAsignarTecnico.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnAsignarTecnico.FlatAppearance.BorderSize = 0;
            this.btnAsignarTecnico.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnAsignarTecnico.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnAsignarTecnico.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAsignarTecnico.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnAsignarTecnico.ForeColor = System.Drawing.Color.White;
            this.btnAsignarTecnico.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAsignarTecnico.Location = new System.Drawing.Point(897, 7);
            this.btnAsignarTecnico.Margin = new System.Windows.Forms.Padding(2);
            this.btnAsignarTecnico.Name = "btnAsignarTecnico";
            this.btnAsignarTecnico.Size = new System.Drawing.Size(135, 31);
            this.btnAsignarTecnico.TabIndex = 320;
            this.btnAsignarTecnico.Text = "Asignar técnico";
            this.btnAsignarTecnico.UseVisualStyleBackColor = false;
            this.btnAsignarTecnico.Click += new System.EventHandler(this.btnAsignarTecnico_Click);
            // 
            // btnConectar
            // 
            this.btnConectar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConectar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnConectar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConectar.Enabled = false;
            this.btnConectar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnConectar.FlatAppearance.BorderSize = 0;
            this.btnConectar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnConectar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnConectar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConectar.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnConectar.ForeColor = System.Drawing.Color.White;
            this.btnConectar.Image = global::CapaPresentacion.Properties.Resources.Data_Add_32;
            this.btnConectar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnConectar.Location = new System.Drawing.Point(1175, 7);
            this.btnConectar.Margin = new System.Windows.Forms.Padding(2);
            this.btnConectar.Name = "btnConectar";
            this.btnConectar.Size = new System.Drawing.Size(194, 31);
            this.btnConectar.TabIndex = 314;
            this.btnConectar.Text = "Conectar con ";
            this.btnConectar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConectar.UseVisualStyleBackColor = false;
            this.btnConectar.Click += new System.EventHandler(this.btnParteNuevo_Click);
            // 
            // btnAsignarEquipos
            // 
            this.btnAsignarEquipos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAsignarEquipos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnAsignarEquipos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAsignarEquipos.Enabled = false;
            this.btnAsignarEquipos.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnAsignarEquipos.FlatAppearance.BorderSize = 0;
            this.btnAsignarEquipos.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnAsignarEquipos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnAsignarEquipos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAsignarEquipos.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnAsignarEquipos.ForeColor = System.Drawing.Color.White;
            this.btnAsignarEquipos.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAsignarEquipos.Location = new System.Drawing.Point(1036, 7);
            this.btnAsignarEquipos.Margin = new System.Windows.Forms.Padding(2);
            this.btnAsignarEquipos.Name = "btnAsignarEquipos";
            this.btnAsignarEquipos.Size = new System.Drawing.Size(135, 31);
            this.btnAsignarEquipos.TabIndex = 319;
            this.btnAsignarEquipos.Text = "Asignar equipos";
            this.btnAsignarEquipos.UseVisualStyleBackColor = false;
            this.btnAsignarEquipos.Click += new System.EventHandler(this.btnAsignarEquipos_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblListoParaConfg);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(3, 448);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1372, 40);
            this.panel1.TabIndex = 55;
            // 
            // lblListoParaConfg
            // 
            this.lblListoParaConfg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblListoParaConfg.BackColor = System.Drawing.Color.LightGreen;
            this.lblListoParaConfg.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblListoParaConfg.Location = new System.Drawing.Point(936, 11);
            this.lblListoParaConfg.Name = "lblListoParaConfg";
            this.lblListoParaConfg.Size = new System.Drawing.Size(169, 20);
            this.lblListoParaConfg.TabIndex = 304;
            this.lblListoParaConfg.Text = "Listo para configurar ";
            this.lblListoParaConfg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label6.Location = new System.Drawing.Point(833, 11);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(97, 21);
            this.label6.TabIndex = 305;
            this.label6.Text = "Referencias: ";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.BackColor = System.Drawing.Color.Tomato;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(1111, 10);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(106, 20);
            this.label7.TabIndex = 306;
            this.label7.Text = "Sin técnico";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.BackColor = System.Drawing.Color.Yellow;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(1223, 10);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(106, 20);
            this.label8.TabIndex = 307;
            this.label8.Text = "Sin equipo";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabPartesInternos
            // 
            this.tabPartesInternos.Controls.Add(this.dgvPartesInternos);
            this.tabPartesInternos.Controls.Add(this.panel2);
            this.tabPartesInternos.Location = new System.Drawing.Point(4, 34);
            this.tabPartesInternos.Name = "tabPartesInternos";
            this.tabPartesInternos.Padding = new System.Windows.Forms.Padding(3);
            this.tabPartesInternos.Size = new System.Drawing.Size(1378, 491);
            this.tabPartesInternos.TabIndex = 1;
            this.tabPartesInternos.Text = "Partes internos";
            this.tabPartesInternos.UseVisualStyleBackColor = true;
            this.tabPartesInternos.RegionChanged += new System.EventHandler(this.tabPage2_RegionChanged);
            // 
            // dgvPartesInternos
            // 
            this.dgvPartesInternos.AllowUserToAddRows = false;
            this.dgvPartesInternos.AllowUserToDeleteRows = false;
            this.dgvPartesInternos.AllowUserToOrderColumns = true;
            this.dgvPartesInternos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPartesInternos.BackgroundColor = System.Drawing.Color.White;
            this.dgvPartesInternos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvPartesInternos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.LightSlateGray;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPartesInternos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvPartesInternos.ColumnHeadersHeight = 40;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPartesInternos.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvPartesInternos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPartesInternos.EnableHeadersVisualStyles = false;
            this.dgvPartesInternos.GridColor = System.Drawing.Color.WhiteSmoke;
            this.dgvPartesInternos.Location = new System.Drawing.Point(3, 49);
            this.dgvPartesInternos.MultiSelect = false;
            this.dgvPartesInternos.Name = "dgvPartesInternos";
            this.dgvPartesInternos.ReadOnly = true;
            this.dgvPartesInternos.RowHeadersVisible = false;
            this.dgvPartesInternos.RowHeadersWidth = 50;
            this.dgvPartesInternos.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvPartesInternos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPartesInternos.Size = new System.Drawing.Size(1372, 439);
            this.dgvPartesInternos.TabIndex = 54;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.boton2);
            this.panel2.Controls.Add(this.boton5);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1372, 46);
            this.panel2.TabIndex = 55;
            // 
            // boton2
            // 
            this.boton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.boton2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.boton2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.boton2.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.boton2.FlatAppearance.BorderSize = 0;
            this.boton2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.boton2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.boton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.boton2.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.boton2.ForeColor = System.Drawing.Color.White;
            this.boton2.Image = global::CapaPresentacion.Properties.Resources.Print_321;
            this.boton2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.boton2.Location = new System.Drawing.Point(1078, 7);
            this.boton2.Margin = new System.Windows.Forms.Padding(2);
            this.boton2.Name = "boton2";
            this.boton2.Size = new System.Drawing.Size(135, 31);
            this.boton2.TabIndex = 318;
            this.boton2.Text = "Imprimir";
            this.boton2.UseVisualStyleBackColor = false;
            this.boton2.Click += new System.EventHandler(this.boton2_Click);
            // 
            // boton5
            // 
            this.boton5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.boton5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.boton5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.boton5.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.boton5.FlatAppearance.BorderSize = 0;
            this.boton5.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.boton5.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.boton5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.boton5.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.boton5.ForeColor = System.Drawing.Color.White;
            this.boton5.Image = global::CapaPresentacion.Properties.Resources.Arrowhead_Right_32;
            this.boton5.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.boton5.Location = new System.Drawing.Point(1217, 7);
            this.boton5.Margin = new System.Windows.Forms.Padding(2);
            this.boton5.Name = "boton5";
            this.boton5.Size = new System.Drawing.Size(152, 31);
            this.boton5.TabIndex = 314;
            this.boton5.Text = "Confirmar parte";
            this.boton5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.boton5.UseVisualStyleBackColor = false;
            this.boton5.Click += new System.EventHandler(this.boton5_Click);
            // 
            // tmrTimer
            // 
            this.tmrTimer.Interval = 5000;
            this.tmrTimer.Tick += new System.EventHandler(this.tmrTimer_Tick);
            // 
            // frmPartesServiciosConf
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1386, 644);
            this.Controls.Add(this.pnlContenido);
            this.Controls.Add(this.pnlInferior);
            this.Controls.Add(this.pnlSuperior);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "frmPartesServiciosConf";
            this.Text = "frmPartesServiciosConf";
            this.Load += new System.EventHandler(this.frmPartesServiciosConf_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmPartesServiciosConf_KeyDown);
            this.pnlSuperior.ResumeLayout(false);
            this.pnlSuperior.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgReturn)).EndInit();
            this.pnlFiltros.ResumeLayout(false);
            this.pnlFiltros.PerformLayout();
            this.pnlInferior.ResumeLayout(false);
            this.pnlInferior.PerformLayout();
            this.pnlContenido.ResumeLayout(false);
            this.tabMain.ResumeLayout(false);
            this.tabOperaciones.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPartes)).EndInit();
            this.pnlBotones.ResumeLayout(false);
            this.pnlBotones.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabPartesInternos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPartesInternos)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlSuperior;
        private System.Windows.Forms.PictureBox imgReturn;
        private System.Windows.Forms.Label lblTituloHeader;
        private System.Windows.Forms.Panel pnlFiltros;
        private System.Windows.Forms.Panel pnlInferior;
        private System.Windows.Forms.Panel pnlContenido;
        private System.Windows.Forms.Label lblTotal;
        private Controles.progress pgCircular;
        private Controles.dgv dgvPartes;
        private System.Windows.Forms.Label label1;
        private textboxAdv txtCodigo;
        private System.Windows.Forms.Label label2;
        private Controles.combo cboOperaciones;
        private Controles.boton btnPaasarAconf;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Label lblFechaUltimo;
        private System.Windows.Forms.Label lbCantPosteriores;
        private System.Windows.Forms.Panel pnlBotones;
        private Controles.boton btnSeleccionar;
        private Controles.boton btnImprimir;
        private Controles.boton btnAsignarTecnico;
        private Controles.boton btnConectar;
        private Controles.boton btnAsignarEquipos;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblListoParaConfg;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblFechaUltimoDato;
        private System.Windows.Forms.Label lbCantPosterioresDato;
        private System.Windows.Forms.Label lblTotalDato;
        private System.Windows.Forms.Label label3;
        private textboxAdv txtParte;
        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage tabOperaciones;
        private System.Windows.Forms.TabPage tabPartesInternos;
        private Controles.dgv dgvPartesInternos;
        private System.Windows.Forms.Panel panel2;
        private Controles.boton boton2;
        private Controles.boton boton5;
        private System.Windows.Forms.Timer tmrTimer;
        private Controles.boton btnCargar;
        private Controles.combo comboAppExternas;
    }
}