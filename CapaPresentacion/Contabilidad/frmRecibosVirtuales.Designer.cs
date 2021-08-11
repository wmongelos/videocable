
namespace CapaPresentacion.Contabilidad
{
    partial class frmRecibosVirtuales
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
            this.pnlSuperior = new System.Windows.Forms.Panel();
            this.imgReturn = new System.Windows.Forms.PictureBox();
            this.lblTitulos = new System.Windows.Forms.Label();
            this.scMain = new System.Windows.Forms.SplitContainer();
            this.dgvCajas = new CapaPresentacion.Controles.dgv(this.components);
            this.flpRecibos = new System.Windows.Forms.FlowLayoutPanel();
            this.lblCantCajas = new System.Windows.Forms.Label();
            this.flwFiltro = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.dgvRecibos = new CapaPresentacion.Controles.dgv(this.components);
            this.flwBusquedaRecibos = new System.Windows.Forms.FlowLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBuscador = new CapaPresentacion.textboxAdv();
            this.pnlCargando = new System.Windows.Forms.Panel();
            this.lblCargando = new System.Windows.Forms.Label();
            this.pgCircular = new CapaPresentacion.Controles.progress();
            this.tlpInferior = new System.Windows.Forms.TableLayoutPanel();
            this.btnExportar = new CapaPresentacion.Controles.boton();
            this.btnCerrar = new CapaPresentacion.Controles.boton();
            this.lblCantRecibos = new System.Windows.Forms.Label();
            this.flwBuscar = new System.Windows.Forms.FlowLayoutPanel();
            this.lblSelecPunto = new System.Windows.Forms.Label();
            this.cboPuntos = new CapaPresentacion.Controles.combo(this.components);
            this.btnBuscar = new CapaPresentacion.Controles.boton();
            this.pnlSuperior.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgReturn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.scMain)).BeginInit();
            this.scMain.Panel1.SuspendLayout();
            this.scMain.Panel2.SuspendLayout();
            this.scMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCajas)).BeginInit();
            this.flpRecibos.SuspendLayout();
            this.flwFiltro.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecibos)).BeginInit();
            this.flwBusquedaRecibos.SuspendLayout();
            this.pnlCargando.SuspendLayout();
            this.tlpInferior.SuspendLayout();
            this.flwBuscar.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlSuperior
            // 
            this.pnlSuperior.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.pnlSuperior.Controls.Add(this.imgReturn);
            this.pnlSuperior.Controls.Add(this.lblTitulos);
            this.pnlSuperior.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSuperior.Location = new System.Drawing.Point(0, 0);
            this.pnlSuperior.Name = "pnlSuperior";
            this.pnlSuperior.Size = new System.Drawing.Size(1240, 71);
            this.pnlSuperior.TabIndex = 177;
            // 
            // imgReturn
            // 
            this.imgReturn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.imgReturn.Image = global::CapaPresentacion.Properties.Resources.Left_Arrow_32;
            this.imgReturn.Location = new System.Drawing.Point(12, 19);
            this.imgReturn.Name = "imgReturn";
            this.imgReturn.Size = new System.Drawing.Size(32, 32);
            this.imgReturn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgReturn.TabIndex = 76;
            this.imgReturn.TabStop = false;
            this.imgReturn.Click += new System.EventHandler(this.imgReturn_Click);
            // 
            // lblTitulos
            // 
            this.lblTitulos.AutoSize = true;
            this.lblTitulos.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulos.ForeColor = System.Drawing.Color.Transparent;
            this.lblTitulos.Location = new System.Drawing.Point(45, 23);
            this.lblTitulos.Name = "lblTitulos";
            this.lblTitulos.Size = new System.Drawing.Size(110, 25);
            this.lblTitulos.TabIndex = 172;
            this.lblTitulos.Text = "Caja Virtual";
            // 
            // scMain
            // 
            this.scMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scMain.Location = new System.Drawing.Point(0, 109);
            this.scMain.Name = "scMain";
            // 
            // scMain.Panel1
            // 
            this.scMain.Panel1.Controls.Add(this.dgvCajas);
            this.scMain.Panel1.Controls.Add(this.flpRecibos);
            this.scMain.Panel1.Controls.Add(this.flwFiltro);
            // 
            // scMain.Panel2
            // 
            this.scMain.Panel2.Controls.Add(this.dgvRecibos);
            this.scMain.Panel2.Controls.Add(this.flwBusquedaRecibos);
            this.scMain.Panel2.Controls.Add(this.pnlCargando);
            this.scMain.Panel2.Controls.Add(this.tlpInferior);
            this.scMain.Size = new System.Drawing.Size(1240, 466);
            this.scMain.SplitterDistance = 556;
            this.scMain.SplitterWidth = 20;
            this.scMain.TabIndex = 178;
            // 
            // dgvCajas
            // 
            this.dgvCajas.AllowUserToAddRows = false;
            this.dgvCajas.AllowUserToDeleteRows = false;
            this.dgvCajas.AllowUserToOrderColumns = true;
            this.dgvCajas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCajas.BackgroundColor = System.Drawing.Color.White;
            this.dgvCajas.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvCajas.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSlateGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCajas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCajas.ColumnHeadersHeight = 40;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCajas.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvCajas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCajas.EnableHeadersVisualStyles = false;
            this.dgvCajas.GridColor = System.Drawing.Color.WhiteSmoke;
            this.dgvCajas.Location = new System.Drawing.Point(0, 36);
            this.dgvCajas.MultiSelect = false;
            this.dgvCajas.Name = "dgvCajas";
            this.dgvCajas.ReadOnly = true;
            this.dgvCajas.RowHeadersVisible = false;
            this.dgvCajas.RowHeadersWidth = 50;
            this.dgvCajas.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvCajas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCajas.Size = new System.Drawing.Size(556, 395);
            this.dgvCajas.TabIndex = 1;
            this.dgvCajas.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCajas_CellClick);
            this.dgvCajas.SelectionChanged += new System.EventHandler(this.dgvCajas_SelectionChanged);
            // 
            // flpRecibos
            // 
            this.flpRecibos.Controls.Add(this.lblCantCajas);
            this.flpRecibos.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flpRecibos.Location = new System.Drawing.Point(0, 431);
            this.flpRecibos.Name = "flpRecibos";
            this.flpRecibos.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.flpRecibos.Size = new System.Drawing.Size(556, 35);
            this.flpRecibos.TabIndex = 184;
            // 
            // lblCantCajas
            // 
            this.lblCantCajas.AutoSize = true;
            this.lblCantCajas.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblCantCajas.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCantCajas.Location = new System.Drawing.Point(3, 8);
            this.lblCantCajas.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.lblCantCajas.Name = "lblCantCajas";
            this.lblCantCajas.Size = new System.Drawing.Size(543, 21);
            this.lblCantCajas.TabIndex = 218;
            this.lblCantCajas.Text = "Cantidad de cajas: 500 - Cuenta 1 50000$ - Cuenta 2: 50000$ - Total: 50000$";
            this.lblCantCajas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // flwFiltro
            // 
            this.flwFiltro.Controls.Add(this.label1);
            this.flwFiltro.Controls.Add(this.dtpDesde);
            this.flwFiltro.Controls.Add(this.label2);
            this.flwFiltro.Controls.Add(this.dtpHasta);
            this.flwFiltro.Dock = System.Windows.Forms.DockStyle.Top;
            this.flwFiltro.Enabled = false;
            this.flwFiltro.Location = new System.Drawing.Point(0, 0);
            this.flwFiltro.Name = "flwFiltro";
            this.flwFiltro.Size = new System.Drawing.Size(556, 36);
            this.flwFiltro.TabIndex = 183;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 3);
            this.label1.Margin = new System.Windows.Forms.Padding(3);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.label1.Size = new System.Drawing.Size(56, 24);
            this.label1.TabIndex = 220;
            this.label1.Text = "Desde:";
            // 
            // dtpDesde
            // 
            this.dtpDesde.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDesde.Location = new System.Drawing.Point(65, 3);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(106, 29);
            this.dtpDesde.TabIndex = 222;
            this.dtpDesde.ValueChanged += new System.EventHandler(this.dtpDesde_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(177, 3);
            this.label2.Margin = new System.Windows.Forms.Padding(3);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.label2.Size = new System.Drawing.Size(52, 24);
            this.label2.TabIndex = 223;
            this.label2.Text = "Hasta:";
            // 
            // dtpHasta
            // 
            this.dtpHasta.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHasta.Location = new System.Drawing.Point(235, 3);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(111, 29);
            this.dtpHasta.TabIndex = 224;
            this.dtpHasta.ValueChanged += new System.EventHandler(this.dtpHasta_ValueChanged);
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
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.LightSlateGray;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRecibos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvRecibos.ColumnHeadersHeight = 40;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvRecibos.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvRecibos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRecibos.EnableHeadersVisualStyles = false;
            this.dgvRecibos.GridColor = System.Drawing.Color.WhiteSmoke;
            this.dgvRecibos.Location = new System.Drawing.Point(0, 36);
            this.dgvRecibos.MultiSelect = false;
            this.dgvRecibos.Name = "dgvRecibos";
            this.dgvRecibos.ReadOnly = true;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRecibos.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvRecibos.RowHeadersVisible = false;
            this.dgvRecibos.RowHeadersWidth = 50;
            this.dgvRecibos.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvRecibos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRecibos.Size = new System.Drawing.Size(664, 395);
            this.dgvRecibos.TabIndex = 2;
            // 
            // flwBusquedaRecibos
            // 
            this.flwBusquedaRecibos.Controls.Add(this.label3);
            this.flwBusquedaRecibos.Controls.Add(this.txtBuscador);
            this.flwBusquedaRecibos.Dock = System.Windows.Forms.DockStyle.Top;
            this.flwBusquedaRecibos.Location = new System.Drawing.Point(0, 0);
            this.flwBusquedaRecibos.Name = "flwBusquedaRecibos";
            this.flwBusquedaRecibos.Size = new System.Drawing.Size(664, 36);
            this.flwBusquedaRecibos.TabIndex = 317;
            this.flwBusquedaRecibos.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 3);
            this.label3.Margin = new System.Windows.Forms.Padding(3);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.label3.Size = new System.Drawing.Size(59, 24);
            this.label3.TabIndex = 220;
            this.label3.Text = "Buscar:";
            // 
            // txtBuscador
            // 
            this.txtBuscador.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBuscador.BorderColor = System.Drawing.Color.Empty;
            this.txtBuscador.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBuscador.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBuscador.FocusColor = System.Drawing.Color.Empty;
            this.txtBuscador.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscador.Location = new System.Drawing.Point(68, 3);
            this.txtBuscador.Name = "txtBuscador";
            this.txtBuscador.Numerico = false;
            this.txtBuscador.Size = new System.Drawing.Size(584, 29);
            this.txtBuscador.TabIndex = 221;
            this.txtBuscador.TextChanged += new System.EventHandler(this.txtBuscador_TextChanged);
            // 
            // pnlCargando
            // 
            this.pnlCargando.BackColor = System.Drawing.SystemColors.Control;
            this.pnlCargando.Controls.Add(this.lblCargando);
            this.pnlCargando.Controls.Add(this.pgCircular);
            this.pnlCargando.Location = new System.Drawing.Point(245, 160);
            this.pnlCargando.Name = "pnlCargando";
            this.pnlCargando.Size = new System.Drawing.Size(157, 147);
            this.pnlCargando.TabIndex = 316;
            this.pnlCargando.Visible = false;
            // 
            // lblCargando
            // 
            this.lblCargando.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.lblCargando.ForeColor = System.Drawing.Color.Black;
            this.lblCargando.Location = new System.Drawing.Point(38, 93);
            this.lblCargando.Name = "lblCargando";
            this.lblCargando.Size = new System.Drawing.Size(90, 25);
            this.lblCargando.TabIndex = 15;
            this.lblCargando.Text = "Cargando";
            // 
            // pgCircular
            // 
            this.pgCircular.Location = new System.Drawing.Point(43, 14);
            this.pgCircular.Name = "pgCircular";
            this.pgCircular.Percentage = 0F;
            this.pgCircular.Rotation = CapaPresentacion.Controles.RotationType.CounterClockwise;
            this.pgCircular.Size = new System.Drawing.Size(76, 76);
            this.pgCircular.TabIndex = 314;
            // 
            // tlpInferior
            // 
            this.tlpInferior.ColumnCount = 3;
            this.tlpInferior.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpInferior.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 186F));
            this.tlpInferior.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 129F));
            this.tlpInferior.Controls.Add(this.btnExportar, 0, 0);
            this.tlpInferior.Controls.Add(this.btnCerrar, 1, 0);
            this.tlpInferior.Controls.Add(this.lblCantRecibos, 0, 0);
            this.tlpInferior.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tlpInferior.Location = new System.Drawing.Point(0, 431);
            this.tlpInferior.Name = "tlpInferior";
            this.tlpInferior.RowCount = 1;
            this.tlpInferior.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpInferior.Size = new System.Drawing.Size(664, 35);
            this.tlpInferior.TabIndex = 186;
            this.tlpInferior.Visible = false;
            // 
            // btnExportar
            // 
            this.btnExportar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnExportar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExportar.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnExportar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnExportar.FlatAppearance.BorderSize = 0;
            this.btnExportar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnExportar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnExportar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportar.ForeColor = System.Drawing.Color.White;
            this.btnExportar.Image = global::CapaPresentacion.Properties.Resources.Data_Export_32;
            this.btnExportar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExportar.Location = new System.Drawing.Point(352, 3);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(180, 29);
            this.btnExportar.TabIndex = 223;
            this.btnExportar.Text = "Exportar listados";
            this.btnExportar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExportar.UseVisualStyleBackColor = true;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCerrar.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnCerrar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnCerrar.FlatAppearance.BorderSize = 0;
            this.btnCerrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnCerrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrar.ForeColor = System.Drawing.Color.White;
            this.btnCerrar.Image = global::CapaPresentacion.Properties.Resources.Save_32;
            this.btnCerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCerrar.Location = new System.Drawing.Point(538, 3);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(123, 29);
            this.btnCerrar.TabIndex = 222;
            this.btnCerrar.Text = "Cerrar caja";
            this.btnCerrar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // lblCantRecibos
            // 
            this.lblCantRecibos.AutoSize = true;
            this.lblCantRecibos.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblCantRecibos.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCantRecibos.Location = new System.Drawing.Point(3, 3);
            this.lblCantRecibos.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.lblCantRecibos.Name = "lblCantRecibos";
            this.lblCantRecibos.Size = new System.Drawing.Size(158, 32);
            this.lblCantRecibos.TabIndex = 217;
            this.lblCantRecibos.Text = "Cantiadad de recibos:";
            this.lblCantRecibos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // flwBuscar
            // 
            this.flwBuscar.Controls.Add(this.lblSelecPunto);
            this.flwBuscar.Controls.Add(this.cboPuntos);
            this.flwBuscar.Controls.Add(this.btnBuscar);
            this.flwBuscar.Dock = System.Windows.Forms.DockStyle.Top;
            this.flwBuscar.Location = new System.Drawing.Point(0, 71);
            this.flwBuscar.Name = "flwBuscar";
            this.flwBuscar.Size = new System.Drawing.Size(1240, 38);
            this.flwBuscar.TabIndex = 182;
            // 
            // lblSelecPunto
            // 
            this.lblSelecPunto.AutoSize = true;
            this.lblSelecPunto.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelecPunto.Location = new System.Drawing.Point(3, 3);
            this.lblSelecPunto.Margin = new System.Windows.Forms.Padding(3);
            this.lblSelecPunto.Name = "lblSelecPunto";
            this.lblSelecPunto.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.lblSelecPunto.Size = new System.Drawing.Size(193, 26);
            this.lblSelecPunto.TabIndex = 220;
            this.lblSelecPunto.Text = "Puntos de cobros virtuales";
            // 
            // cboPuntos
            // 
            this.cboPuntos.BorderColor = System.Drawing.Color.Empty;
            this.cboPuntos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPuntos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboPuntos.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboPuntos.FormattingEnabled = true;
            this.cboPuntos.Location = new System.Drawing.Point(202, 3);
            this.cboPuntos.Name = "cboPuntos";
            this.cboPuntos.Size = new System.Drawing.Size(272, 29);
            this.cboPuntos.TabIndex = 219;
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
            this.btnBuscar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.ForeColor = System.Drawing.Color.White;
            this.btnBuscar.Image = global::CapaPresentacion.Properties.Resources.lupa;
            this.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBuscar.Location = new System.Drawing.Point(480, 3);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(87, 29);
            this.btnBuscar.TabIndex = 221;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // frmRecibosVirtuales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1240, 575);
            this.Controls.Add(this.scMain);
            this.Controls.Add(this.flwBuscar);
            this.Controls.Add(this.pnlSuperior);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "frmRecibosVirtuales";
            this.Text = "frmRecibosVirtuales";
            this.Load += new System.EventHandler(this.frmRecibosVirtuales_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmRecibosVirtuales_KeyDown);
            this.pnlSuperior.ResumeLayout(false);
            this.pnlSuperior.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgReturn)).EndInit();
            this.scMain.Panel1.ResumeLayout(false);
            this.scMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scMain)).EndInit();
            this.scMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCajas)).EndInit();
            this.flpRecibos.ResumeLayout(false);
            this.flpRecibos.PerformLayout();
            this.flwFiltro.ResumeLayout(false);
            this.flwFiltro.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecibos)).EndInit();
            this.flwBusquedaRecibos.ResumeLayout(false);
            this.flwBusquedaRecibos.PerformLayout();
            this.pnlCargando.ResumeLayout(false);
            this.tlpInferior.ResumeLayout(false);
            this.tlpInferior.PerformLayout();
            this.flwBuscar.ResumeLayout(false);
            this.flwBuscar.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlSuperior;
        private System.Windows.Forms.PictureBox imgReturn;
        private System.Windows.Forms.Label lblTitulos;
        private System.Windows.Forms.SplitContainer scMain;
        private Controles.dgv dgvCajas;
        private Controles.dgv dgvRecibos;
        private System.Windows.Forms.FlowLayoutPanel flwBuscar;
        private System.Windows.Forms.Label lblSelecPunto;
        private Controles.combo cboPuntos;
        private Controles.boton btnBuscar;
        private Controles.boton btnCerrar;
        private System.Windows.Forms.FlowLayoutPanel flwFiltro;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.FlowLayoutPanel flpRecibos;
        private System.Windows.Forms.Label lblCantRecibos;
        private System.Windows.Forms.TableLayoutPanel tlpInferior;
        private System.Windows.Forms.Panel pnlCargando;
        private System.Windows.Forms.Label lblCargando;
        private Controles.progress pgCircular;
        private System.Windows.Forms.Label lblCantCajas;
        private Controles.boton btnExportar;
        private System.Windows.Forms.FlowLayoutPanel flwBusquedaRecibos;
        private System.Windows.Forms.Label label3;
        private textboxAdv txtBuscador;
    }
}