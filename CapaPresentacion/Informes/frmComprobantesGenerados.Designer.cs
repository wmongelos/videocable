
namespace CapaPresentacion.Informes
{
    partial class frmComprobantesGenerados
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel3 = new System.Windows.Forms.Panel();
            this.imgReturn = new System.Windows.Forms.PictureBox();
            this.lblTituloHeader = new System.Windows.Forms.Label();
            this.lblOrigen = new System.Windows.Forms.Label();
            this.pnlFiltros = new System.Windows.Forms.Panel();
            this.pnlFechas = new System.Windows.Forms.Panel();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.lblDesde = new System.Windows.Forms.Label();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.lblHasta = new System.Windows.Forms.Label();
            this.pnlFiltroCombos = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.lblFaturacion = new System.Windows.Forms.Label();
            this.lblTipoComprobante = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pnFooter = new System.Windows.Forms.Panel();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblImporteTotal = new System.Windows.Forms.Label();
            this.dgvComprobantes = new CapaPresentacion.Controles.dgv(this.components);
            this.pgCircular = new CapaPresentacion.Controles.progress();
            this.cboOrigen = new CapaPresentacion.Controles.combo(this.components);
            this.cboFacPres = new CapaPresentacion.Controles.combo(this.components);
            this.cboTipo = new CapaPresentacion.Controles.combo(this.components);
            this.txtCod = new CapaPresentacion.textboxAdv();
            this.btnBuscar = new CapaPresentacion.Controles.boton();
            this.btnExportar = new CapaPresentacion.Controles.boton();
            this.lblReferencias = new System.Windows.Forms.Label();
            this.lblRechazado = new System.Windows.Forms.Label();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.lblCantRechazados = new System.Windows.Forms.Label();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgReturn)).BeginInit();
            this.pnlFiltros.SuspendLayout();
            this.pnlFechas.SuspendLayout();
            this.pnlFiltroCombos.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.pnFooter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvComprobantes)).BeginInit();
            this.flowLayoutPanel2.SuspendLayout();
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
            this.panel3.Size = new System.Drawing.Size(1370, 75);
            this.panel3.TabIndex = 55;
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
            this.lblTituloHeader.AutoSize = true;
            this.lblTituloHeader.Font = new System.Drawing.Font("Segoe UI Light", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloHeader.ForeColor = System.Drawing.Color.White;
            this.lblTituloHeader.Location = new System.Drawing.Point(53, 27);
            this.lblTituloHeader.Name = "lblTituloHeader";
            this.lblTituloHeader.Size = new System.Drawing.Size(222, 25);
            this.lblTituloHeader.TabIndex = 31;
            this.lblTituloHeader.Text = "Comprobantes generados";
            // 
            // lblOrigen
            // 
            this.lblOrigen.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrigen.ForeColor = System.Drawing.Color.Black;
            this.lblOrigen.Location = new System.Drawing.Point(3, 0);
            this.lblOrigen.Name = "lblOrigen";
            this.lblOrigen.Size = new System.Drawing.Size(61, 31);
            this.lblOrigen.TabIndex = 421;
            this.lblOrigen.Text = "Origen:";
            this.lblOrigen.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlFiltros
            // 
            this.pnlFiltros.Controls.Add(this.pnlFechas);
            this.pnlFiltros.Controls.Add(this.pnlFiltroCombos);
            this.pnlFiltros.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFiltros.Location = new System.Drawing.Point(0, 75);
            this.pnlFiltros.Name = "pnlFiltros";
            this.pnlFiltros.Size = new System.Drawing.Size(1370, 95);
            this.pnlFiltros.TabIndex = 423;
            // 
            // pnlFechas
            // 
            this.pnlFechas.Controls.Add(this.dtpHasta);
            this.pnlFechas.Controls.Add(this.lblDesde);
            this.pnlFechas.Controls.Add(this.dtpDesde);
            this.pnlFechas.Controls.Add(this.lblHasta);
            this.pnlFechas.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFechas.Location = new System.Drawing.Point(0, 45);
            this.pnlFechas.Name = "pnlFechas";
            this.pnlFechas.Size = new System.Drawing.Size(1370, 43);
            this.pnlFechas.TabIndex = 441;
            // 
            // dtpHasta
            // 
            this.dtpHasta.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.dtpHasta.Location = new System.Drawing.Point(425, 5);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(303, 29);
            this.dtpHasta.TabIndex = 439;
            // 
            // lblDesde
            // 
            this.lblDesde.AutoSize = true;
            this.lblDesde.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDesde.ForeColor = System.Drawing.Color.Black;
            this.lblDesde.Location = new System.Drawing.Point(3, 12);
            this.lblDesde.Name = "lblDesde";
            this.lblDesde.Size = new System.Drawing.Size(56, 21);
            this.lblDesde.TabIndex = 436;
            this.lblDesde.Text = "Desde:";
            // 
            // dtpDesde
            // 
            this.dtpDesde.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.dtpDesde.Location = new System.Drawing.Point(65, 6);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(286, 29);
            this.dtpDesde.TabIndex = 437;
            this.dtpDesde.ValueChanged += new System.EventHandler(this.dtpDesde_ValueChanged);
            // 
            // lblHasta
            // 
            this.lblHasta.AutoSize = true;
            this.lblHasta.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHasta.ForeColor = System.Drawing.Color.Black;
            this.lblHasta.Location = new System.Drawing.Point(367, 11);
            this.lblHasta.Name = "lblHasta";
            this.lblHasta.Size = new System.Drawing.Size(52, 21);
            this.lblHasta.TabIndex = 438;
            this.lblHasta.Text = "Hasta:";
            // 
            // pnlFiltroCombos
            // 
            this.pnlFiltroCombos.Controls.Add(this.flowLayoutPanel1);
            this.pnlFiltroCombos.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFiltroCombos.Location = new System.Drawing.Point(0, 0);
            this.pnlFiltroCombos.Name = "pnlFiltroCombos";
            this.pnlFiltroCombos.Size = new System.Drawing.Size(1370, 45);
            this.pnlFiltroCombos.TabIndex = 442;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.lblOrigen);
            this.flowLayoutPanel1.Controls.Add(this.cboOrigen);
            this.flowLayoutPanel1.Controls.Add(this.lblFaturacion);
            this.flowLayoutPanel1.Controls.Add(this.cboFacPres);
            this.flowLayoutPanel1.Controls.Add(this.lblTipoComprobante);
            this.flowLayoutPanel1.Controls.Add(this.cboTipo);
            this.flowLayoutPanel1.Controls.Add(this.label1);
            this.flowLayoutPanel1.Controls.Add(this.txtCod);
            this.flowLayoutPanel1.Controls.Add(this.btnBuscar);
            this.flowLayoutPanel1.Controls.Add(this.btnExportar);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 7);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1367, 31);
            this.flowLayoutPanel1.TabIndex = 441;
            // 
            // lblFaturacion
            // 
            this.lblFaturacion.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFaturacion.ForeColor = System.Drawing.Color.Black;
            this.lblFaturacion.Location = new System.Drawing.Point(281, 0);
            this.lblFaturacion.Name = "lblFaturacion";
            this.lblFaturacion.Size = new System.Drawing.Size(92, 31);
            this.lblFaturacion.TabIndex = 434;
            this.lblFaturacion.Text = "Facturacion:";
            this.lblFaturacion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTipoComprobante
            // 
            this.lblTipoComprobante.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipoComprobante.ForeColor = System.Drawing.Color.Black;
            this.lblTipoComprobante.Location = new System.Drawing.Point(554, 0);
            this.lblTipoComprobante.Name = "lblTipoComprobante";
            this.lblTipoComprobante.Size = new System.Drawing.Size(161, 31);
            this.lblTipoComprobante.TabIndex = 436;
            this.lblTipoComprobante.Text = "Tipo de comprobante:";
            this.lblTipoComprobante.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(878, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 31);
            this.label1.TabIndex = 442;
            this.label1.Text = "Abonado";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnFooter
            // 
            this.pnFooter.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnFooter.Controls.Add(this.flowLayoutPanel2);
            this.pnFooter.Controls.Add(this.lblReferencias);
            this.pnFooter.Controls.Add(this.lblRechazado);
            this.pnFooter.Controls.Add(this.pgCircular);
            this.pnFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnFooter.Location = new System.Drawing.Point(0, 648);
            this.pnFooter.Name = "pnFooter";
            this.pnFooter.Size = new System.Drawing.Size(1370, 30);
            this.pnFooter.TabIndex = 434;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.ForeColor = System.Drawing.Color.Black;
            this.lblTotal.Location = new System.Drawing.Point(3, 0);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(148, 21);
            this.lblTotal.TabIndex = 13;
            this.lblTotal.Text = "Total de Registros: 0";
            // 
            // lblImporteTotal
            // 
            this.lblImporteTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblImporteTotal.AutoSize = true;
            this.lblImporteTotal.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblImporteTotal.ForeColor = System.Drawing.Color.Black;
            this.lblImporteTotal.Location = new System.Drawing.Point(157, 0);
            this.lblImporteTotal.Name = "lblImporteTotal";
            this.lblImporteTotal.Size = new System.Drawing.Size(103, 21);
            this.lblImporteTotal.TabIndex = 14;
            this.lblImporteTotal.Text = "Importe total:";
            // 
            // dgvComprobantes
            // 
            this.dgvComprobantes.AllowUserToAddRows = false;
            this.dgvComprobantes.AllowUserToDeleteRows = false;
            this.dgvComprobantes.AllowUserToOrderColumns = true;
            this.dgvComprobantes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvComprobantes.BackgroundColor = System.Drawing.Color.White;
            this.dgvComprobantes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvComprobantes.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.LightSlateGray;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvComprobantes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvComprobantes.ColumnHeadersHeight = 40;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvComprobantes.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgvComprobantes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvComprobantes.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.dgvComprobantes.EnableHeadersVisualStyles = false;
            this.dgvComprobantes.GridColor = System.Drawing.Color.WhiteSmoke;
            this.dgvComprobantes.Location = new System.Drawing.Point(0, 170);
            this.dgvComprobantes.MultiSelect = false;
            this.dgvComprobantes.Name = "dgvComprobantes";
            this.dgvComprobantes.ReadOnly = true;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvComprobantes.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvComprobantes.RowHeadersVisible = false;
            this.dgvComprobantes.RowHeadersWidth = 50;
            this.dgvComprobantes.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvComprobantes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvComprobantes.Size = new System.Drawing.Size(1370, 478);
            this.dgvComprobantes.TabIndex = 435;
            // 
            // pgCircular
            // 
            this.pgCircular.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pgCircular.Location = new System.Drawing.Point(1334, 2);
            this.pgCircular.Name = "pgCircular";
            this.pgCircular.Percentage = 0F;
            this.pgCircular.Rotation = CapaPresentacion.Controles.RotationType.CounterClockwise;
            this.pgCircular.Size = new System.Drawing.Size(24, 24);
            this.pgCircular.TabIndex = 0;
            // 
            // cboOrigen
            // 
            this.cboOrigen.BorderColor = System.Drawing.Color.Empty;
            this.cboOrigen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboOrigen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboOrigen.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cboOrigen.ForeColor = System.Drawing.Color.Black;
            this.cboOrigen.FormattingEnabled = true;
            this.cboOrigen.Items.AddRange(new object[] {
            "TODAS",
            "ALTA",
            "MEDIA",
            "BAJA"});
            this.cboOrigen.Location = new System.Drawing.Point(70, 3);
            this.cboOrigen.Name = "cboOrigen";
            this.cboOrigen.Size = new System.Drawing.Size(205, 29);
            this.cboOrigen.TabIndex = 422;
            this.cboOrigen.SelectionChangeCommitted += new System.EventHandler(this.cboOrigen_SelectionChangeCommitted);
            // 
            // cboFacPres
            // 
            this.cboFacPres.BorderColor = System.Drawing.Color.Empty;
            this.cboFacPres.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFacPres.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboFacPres.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cboFacPres.ForeColor = System.Drawing.Color.Black;
            this.cboFacPres.FormattingEnabled = true;
            this.cboFacPres.Items.AddRange(new object[] {
            "TODAS",
            "ALTA",
            "MEDIA",
            "BAJA"});
            this.cboFacPres.Location = new System.Drawing.Point(379, 3);
            this.cboFacPres.Name = "cboFacPres";
            this.cboFacPres.Size = new System.Drawing.Size(169, 29);
            this.cboFacPres.TabIndex = 435;
            // 
            // cboTipo
            // 
            this.cboTipo.BorderColor = System.Drawing.Color.Empty;
            this.cboTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboTipo.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cboTipo.ForeColor = System.Drawing.Color.Black;
            this.cboTipo.FormattingEnabled = true;
            this.cboTipo.Items.AddRange(new object[] {
            "TODAS",
            "ALTA",
            "MEDIA",
            "BAJA"});
            this.cboTipo.Location = new System.Drawing.Point(721, 3);
            this.cboTipo.Name = "cboTipo";
            this.cboTipo.Size = new System.Drawing.Size(151, 29);
            this.cboTipo.TabIndex = 437;
            // 
            // txtCod
            // 
            this.txtCod.BorderColor = System.Drawing.Color.Empty;
            this.txtCod.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCod.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCod.FocusColor = System.Drawing.Color.Empty;
            this.txtCod.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtCod.Location = new System.Drawing.Point(961, 3);
            this.txtCod.Name = "txtCod";
            this.txtCod.Numerico = true;
            this.txtCod.Size = new System.Drawing.Size(63, 29);
            this.txtCod.TabIndex = 440;
            this.txtCod.Text = "0";
            this.txtCod.Leave += new System.EventHandler(this.txtCod_Leave);
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
            this.btnBuscar.Location = new System.Drawing.Point(1030, 3);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(83, 28);
            this.btnBuscar.TabIndex = 433;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
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
            this.btnExportar.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportar.ForeColor = System.Drawing.Color.White;
            this.btnExportar.Image = global::CapaPresentacion.Properties.Resources.Save_32;
            this.btnExportar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExportar.Location = new System.Drawing.Point(1119, 3);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(117, 28);
            this.btnExportar.TabIndex = 440;
            this.btnExportar.Text = "Exportar";
            this.btnExportar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExportar.UseVisualStyleBackColor = false;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // lblReferencias
            // 
            this.lblReferencias.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblReferencias.AutoSize = true;
            this.lblReferencias.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblReferencias.Location = new System.Drawing.Point(1117, 6);
            this.lblReferencias.Name = "lblReferencias";
            this.lblReferencias.Size = new System.Drawing.Size(97, 21);
            this.lblReferencias.TabIndex = 304;
            this.lblReferencias.Text = "Referencias: ";
            this.lblReferencias.Visible = false;
            // 
            // lblRechazado
            // 
            this.lblRechazado.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRechazado.BackColor = System.Drawing.Color.Tomato;
            this.lblRechazado.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRechazado.Location = new System.Drawing.Point(1220, 6);
            this.lblRechazado.Name = "lblRechazado";
            this.lblRechazado.Size = new System.Drawing.Size(106, 20);
            this.lblRechazado.TabIndex = 306;
            this.lblRechazado.Text = "Rechazado";
            this.lblRechazado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblRechazado.Visible = false;
            this.lblRechazado.Click += new System.EventHandler(this.lblRechazado_Click);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.lblTotal);
            this.flowLayoutPanel2.Controls.Add(this.lblImporteTotal);
            this.flowLayoutPanel2.Controls.Add(this.lblCantRechazados);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(823, 26);
            this.flowLayoutPanel2.TabIndex = 436;
            // 
            // lblCantRechazados
            // 
            this.lblCantRechazados.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCantRechazados.AutoSize = true;
            this.lblCantRechazados.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCantRechazados.ForeColor = System.Drawing.Color.Black;
            this.lblCantRechazados.Location = new System.Drawing.Point(266, 0);
            this.lblCantRechazados.Name = "lblCantRechazados";
            this.lblCantRechazados.Size = new System.Drawing.Size(190, 21);
            this.lblCantRechazados.TabIndex = 15;
            this.lblCantRechazados.Text = "Cantiadad de rechazados: ";
            this.lblCantRechazados.Visible = false;
            // 
            // frmComprobantesGenerados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1370, 678);
            this.Controls.Add(this.dgvComprobantes);
            this.Controls.Add(this.pnFooter);
            this.Controls.Add(this.pnlFiltros);
            this.Controls.Add(this.panel3);
            this.Name = "frmComprobantesGenerados";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Comprobantes generados";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmComprobantesGenerados_Load);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgReturn)).EndInit();
            this.pnlFiltros.ResumeLayout(false);
            this.pnlFechas.ResumeLayout(false);
            this.pnlFechas.PerformLayout();
            this.pnlFiltroCombos.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.pnFooter.ResumeLayout(false);
            this.pnFooter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvComprobantes)).EndInit();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox imgReturn;
        private System.Windows.Forms.Label lblTituloHeader;
        private System.Windows.Forms.Label lblOrigen;
        private Controles.combo cboOrigen;
        private System.Windows.Forms.Panel pnlFiltros;
        private System.Windows.Forms.Label lblFaturacion;
        private Controles.boton btnBuscar;
        private System.Windows.Forms.Label lblDesde;
        private Controles.combo cboFacPres;
        private System.Windows.Forms.Panel pnFooter;
        private System.Windows.Forms.Label lblTotal;
        private Controles.progress pgCircular;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.Label lblHasta;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private Controles.boton btnExportar;
        private System.Windows.Forms.Panel pnlFechas;
        private Controles.dgv dgvComprobantes;
        private System.Windows.Forms.Panel pnlFiltroCombos;
        private Controles.combo cboTipo;
        private System.Windows.Forms.Label lblTipoComprobante;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private textboxAdv txtCod;
        private System.Windows.Forms.Label lblImporteTotal;
        private System.Windows.Forms.Label lblReferencias;
        private System.Windows.Forms.Label lblRechazado;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Label lblCantRechazados;
    }
}