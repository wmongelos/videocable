namespace CapaPresentacion.Partes_Trabajo
{
    partial class frmListadoCortes
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
            this.dgvServiciosCortados = new System.Windows.Forms.DataGridView();
            this.pnlTitulo = new System.Windows.Forms.Panel();
            this.imgReturn = new System.Windows.Forms.PictureBox();
            this.lblTituloHeader = new System.Windows.Forms.Label();
            this.spcMain = new System.Windows.Forms.SplitContainer();
            this.dgvTiposServicio = new System.Windows.Forms.DataGridView();
            this.btnAplicarFiltros = new CapaPresentacion.Controles.boton();
            this.pnlReferencias = new System.Windows.Forms.Panel();
            this.pnlProceso = new System.Windows.Forms.Panel();
            this.pbrTrabajo = new System.Windows.Forms.ProgressBar();
            this.lblProgreso = new System.Windows.Forms.Label();
            this.pgCircular = new CapaPresentacion.Controles.progress();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblReferencias = new System.Windows.Forms.Label();
            this.lblRef60menos = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblRef60 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.pnlBotones = new System.Windows.Forms.Panel();
            this.rbFecha = new System.Windows.Forms.RadioButton();
            this.rbNoventa = new System.Windows.Forms.RadioButton();
            this.rbSesenta = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.btnBuscarPartes = new CapaPresentacion.Controles.boton();
            this.dtpFechaDesde = new System.Windows.Forms.DateTimePicker();
            this.btnGenerarPartes = new CapaPresentacion.Controles.boton();
            this.tarea = new System.ComponentModel.BackgroundWorker();
            this.tmrTiempo = new System.Windows.Forms.Timer(this.components);
            this.pnlCentral = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvServiciosCortados)).BeginInit();
            this.pnlTitulo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgReturn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spcMain)).BeginInit();
            this.spcMain.Panel1.SuspendLayout();
            this.spcMain.Panel2.SuspendLayout();
            this.spcMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTiposServicio)).BeginInit();
            this.pnlReferencias.SuspendLayout();
            this.pnlProceso.SuspendLayout();
            this.pnlBotones.SuspendLayout();
            this.pnlCentral.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvServiciosCortados
            // 
            this.dgvServiciosCortados.AllowUserToAddRows = false;
            this.dgvServiciosCortados.AllowUserToDeleteRows = false;
            this.dgvServiciosCortados.AllowUserToOrderColumns = true;
            this.dgvServiciosCortados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvServiciosCortados.BackgroundColor = System.Drawing.Color.White;
            this.dgvServiciosCortados.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvServiciosCortados.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSlateGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 12.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvServiciosCortados.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvServiciosCortados.ColumnHeadersHeight = 40;
            this.dgvServiciosCortados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 12F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvServiciosCortados.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvServiciosCortados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvServiciosCortados.EnableHeadersVisualStyles = false;
            this.dgvServiciosCortados.GridColor = System.Drawing.Color.WhiteSmoke;
            this.dgvServiciosCortados.Location = new System.Drawing.Point(0, 0);
            this.dgvServiciosCortados.MultiSelect = false;
            this.dgvServiciosCortados.Name = "dgvServiciosCortados";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI Light", 12F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvServiciosCortados.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvServiciosCortados.RowHeadersVisible = false;
            this.dgvServiciosCortados.RowHeadersWidth = 50;
            this.dgvServiciosCortados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvServiciosCortados.Size = new System.Drawing.Size(859, 351);
            this.dgvServiciosCortados.TabIndex = 251;
            this.dgvServiciosCortados.DataSourceChanged += new System.EventHandler(this.dgvServiciosCortados_DataSourceChanged);
            // 
            // pnlTitulo
            // 
            this.pnlTitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.pnlTitulo.Controls.Add(this.imgReturn);
            this.pnlTitulo.Controls.Add(this.lblTituloHeader);
            this.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTitulo.Location = new System.Drawing.Point(0, 0);
            this.pnlTitulo.Name = "pnlTitulo";
            this.pnlTitulo.Size = new System.Drawing.Size(1044, 105);
            this.pnlTitulo.TabIndex = 252;
            // 
            // imgReturn
            // 
            this.imgReturn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.imgReturn.Image = global::CapaPresentacion.Properties.Resources.Left_Arrow_32;
            this.imgReturn.Location = new System.Drawing.Point(16, 34);
            this.imgReturn.Name = "imgReturn";
            this.imgReturn.Size = new System.Drawing.Size(32, 32);
            this.imgReturn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgReturn.TabIndex = 32;
            this.imgReturn.TabStop = false;
            this.imgReturn.Click += new System.EventHandler(this.imgReturn_Click);
            // 
            // lblTituloHeader
            // 
            this.lblTituloHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.lblTituloHeader.Font = new System.Drawing.Font("Segoe UI Light", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloHeader.ForeColor = System.Drawing.Color.White;
            this.lblTituloHeader.Location = new System.Drawing.Point(54, 39);
            this.lblTituloHeader.Name = "lblTituloHeader";
            this.lblTituloHeader.Size = new System.Drawing.Size(338, 23);
            this.lblTituloHeader.TabIndex = 31;
            this.lblTituloHeader.Text = "Baja de servicios";
            // 
            // spcMain
            // 
            this.spcMain.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.spcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spcMain.Location = new System.Drawing.Point(0, 0);
            this.spcMain.Name = "spcMain";
            // 
            // spcMain.Panel1
            // 
            this.spcMain.Panel1.BackColor = System.Drawing.SystemColors.Control;
            this.spcMain.Panel1.Controls.Add(this.dgvTiposServicio);
            this.spcMain.Panel1.Controls.Add(this.btnAplicarFiltros);
            // 
            // spcMain.Panel2
            // 
            this.spcMain.Panel2.Controls.Add(this.dgvServiciosCortados);
            this.spcMain.Panel2.Controls.Add(this.pnlReferencias);
            this.spcMain.Size = new System.Drawing.Size(1044, 390);
            this.spcMain.SplitterDistance = 184;
            this.spcMain.SplitterWidth = 1;
            this.spcMain.TabIndex = 254;
            // 
            // dgvTiposServicio
            // 
            this.dgvTiposServicio.AllowUserToAddRows = false;
            this.dgvTiposServicio.AllowUserToDeleteRows = false;
            this.dgvTiposServicio.AllowUserToOrderColumns = true;
            this.dgvTiposServicio.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTiposServicio.BackgroundColor = System.Drawing.Color.White;
            this.dgvTiposServicio.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvTiposServicio.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.LightSlateGray;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 12.25F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTiposServicio.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvTiposServicio.ColumnHeadersHeight = 40;
            this.dgvTiposServicio.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 12F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTiposServicio.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvTiposServicio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTiposServicio.EnableHeadersVisualStyles = false;
            this.dgvTiposServicio.GridColor = System.Drawing.Color.WhiteSmoke;
            this.dgvTiposServicio.Location = new System.Drawing.Point(0, 0);
            this.dgvTiposServicio.MultiSelect = false;
            this.dgvTiposServicio.Name = "dgvTiposServicio";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI Light", 12F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTiposServicio.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvTiposServicio.RowHeadersVisible = false;
            this.dgvTiposServicio.RowHeadersWidth = 50;
            this.dgvTiposServicio.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTiposServicio.Size = new System.Drawing.Size(184, 351);
            this.dgvTiposServicio.TabIndex = 252;
            this.dgvTiposServicio.CellBorderStyleChanged += new System.EventHandler(this.dgvTiposServicio_CellBorderStyleChanged);
            this.dgvTiposServicio.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTiposServicio_CellClick);
            this.dgvTiposServicio.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTiposServicio_CellValueChanged);
            // 
            // btnAplicarFiltros
            // 
            this.btnAplicarFiltros.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnAplicarFiltros.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAplicarFiltros.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnAplicarFiltros.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnAplicarFiltros.FlatAppearance.BorderSize = 0;
            this.btnAplicarFiltros.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnAplicarFiltros.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnAplicarFiltros.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAplicarFiltros.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAplicarFiltros.ForeColor = System.Drawing.Color.White;
            this.btnAplicarFiltros.Image = global::CapaPresentacion.Properties.Resources.lupa;
            this.btnAplicarFiltros.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAplicarFiltros.Location = new System.Drawing.Point(0, 351);
            this.btnAplicarFiltros.Name = "btnAplicarFiltros";
            this.btnAplicarFiltros.Size = new System.Drawing.Size(184, 39);
            this.btnAplicarFiltros.TabIndex = 321;
            this.btnAplicarFiltros.Text = "Aplicar filtros";
            this.btnAplicarFiltros.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAplicarFiltros.UseVisualStyleBackColor = false;
            this.btnAplicarFiltros.Click += new System.EventHandler(this.boton1_Click_1);
            // 
            // pnlReferencias
            // 
            this.pnlReferencias.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlReferencias.Controls.Add(this.pnlProceso);
            this.pnlReferencias.Controls.Add(this.pgCircular);
            this.pnlReferencias.Controls.Add(this.lblTotal);
            this.pnlReferencias.Controls.Add(this.lblReferencias);
            this.pnlReferencias.Controls.Add(this.lblRef60menos);
            this.pnlReferencias.Controls.Add(this.label1);
            this.pnlReferencias.Controls.Add(this.lblRef60);
            this.pnlReferencias.Controls.Add(this.panel4);
            this.pnlReferencias.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlReferencias.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.pnlReferencias.Location = new System.Drawing.Point(0, 351);
            this.pnlReferencias.Name = "pnlReferencias";
            this.pnlReferencias.Size = new System.Drawing.Size(859, 39);
            this.pnlReferencias.TabIndex = 252;
            // 
            // pnlProceso
            // 
            this.pnlProceso.Controls.Add(this.pbrTrabajo);
            this.pnlProceso.Controls.Add(this.lblProgreso);
            this.pnlProceso.Location = new System.Drawing.Point(234, 3);
            this.pnlProceso.Name = "pnlProceso";
            this.pnlProceso.Size = new System.Drawing.Size(122, 33);
            this.pnlProceso.TabIndex = 19;
            this.pnlProceso.Visible = false;
            // 
            // pbrTrabajo
            // 
            this.pbrTrabajo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbrTrabajo.Location = new System.Drawing.Point(78, 11);
            this.pbrTrabajo.Name = "pbrTrabajo";
            this.pbrTrabajo.Size = new System.Drawing.Size(31, 23);
            this.pbrTrabajo.TabIndex = 14;
            this.pbrTrabajo.Value = 1;
            this.pbrTrabajo.Click += new System.EventHandler(this.pbrTrabajo_Click);
            // 
            // lblProgreso
            // 
            this.lblProgreso.AutoSize = true;
            this.lblProgreso.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblProgreso.ForeColor = System.Drawing.Color.Black;
            this.lblProgreso.Location = new System.Drawing.Point(3, 11);
            this.lblProgreso.Name = "lblProgreso";
            this.lblProgreso.Size = new System.Drawing.Size(73, 21);
            this.lblProgreso.TabIndex = 52;
            this.lblProgreso.Text = "progreso";
            this.lblProgreso.Visible = false;
            // 
            // pgCircular
            // 
            this.pgCircular.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.pgCircular.Location = new System.Drawing.Point(5, 6);
            this.pgCircular.Name = "pgCircular";
            this.pgCircular.Percentage = 0F;
            this.pgCircular.Rotation = CapaPresentacion.Controles.RotationType.CounterClockwise;
            this.pgCircular.Size = new System.Drawing.Size(24, 24);
            this.pgCircular.TabIndex = 0;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.ForeColor = System.Drawing.Color.SlateGray;
            this.lblTotal.Location = new System.Drawing.Point(36, 9);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(148, 21);
            this.lblTotal.TabIndex = 13;
            this.lblTotal.Text = "Total de Registros: 0";
            // 
            // lblReferencias
            // 
            this.lblReferencias.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblReferencias.AutoSize = true;
            this.lblReferencias.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblReferencias.ForeColor = System.Drawing.Color.Black;
            this.lblReferencias.Location = new System.Drawing.Point(306, 9);
            this.lblReferencias.Name = "lblReferencias";
            this.lblReferencias.Size = new System.Drawing.Size(90, 21);
            this.lblReferencias.TabIndex = 53;
            this.lblReferencias.Text = "Referencias";
            // 
            // lblRef60menos
            // 
            this.lblRef60menos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRef60menos.AutoSize = true;
            this.lblRef60menos.BackColor = System.Drawing.Color.PeachPuff;
            this.lblRef60menos.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblRef60menos.ForeColor = System.Drawing.Color.Black;
            this.lblRef60menos.Location = new System.Drawing.Point(696, 9);
            this.lblRef60menos.Name = "lblRef60menos";
            this.lblRef60menos.Size = new System.Drawing.Size(148, 21);
            this.lblRef60menos.TabIndex = 55;
            this.lblRef60menos.Text = "MENOS DE 60 DIAS";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.LightSalmon;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(539, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 21);
            this.label1.TabIndex = 54;
            this.label1.Text = "ENTRE 60 Y 90 DIAS";
            // 
            // lblRef60
            // 
            this.lblRef60.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRef60.AutoSize = true;
            this.lblRef60.BackColor = System.Drawing.Color.Tomato;
            this.lblRef60.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblRef60.ForeColor = System.Drawing.Color.Black;
            this.lblRef60.Location = new System.Drawing.Point(407, 9);
            this.lblRef60.Name = "lblRef60";
            this.lblRef60.Size = new System.Drawing.Size(126, 21);
            this.lblRef60.TabIndex = 53;
            this.lblRef60.Text = "MAS DE 90 DIAS";
            // 
            // panel4
            // 
            this.panel4.AutoSize = true;
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(0, 39);
            this.panel4.TabIndex = 20;
            // 
            // pnlBotones
            // 
            this.pnlBotones.Controls.Add(this.rbFecha);
            this.pnlBotones.Controls.Add(this.rbNoventa);
            this.pnlBotones.Controls.Add(this.rbSesenta);
            this.pnlBotones.Controls.Add(this.label2);
            this.pnlBotones.Controls.Add(this.btnBuscarPartes);
            this.pnlBotones.Controls.Add(this.dtpFechaDesde);
            this.pnlBotones.Controls.Add(this.btnGenerarPartes);
            this.pnlBotones.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBotones.Location = new System.Drawing.Point(0, 105);
            this.pnlBotones.Name = "pnlBotones";
            this.pnlBotones.Size = new System.Drawing.Size(1044, 42);
            this.pnlBotones.TabIndex = 254;
            // 
            // rbFecha
            // 
            this.rbFecha.AutoSize = true;
            this.rbFecha.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.rbFecha.Location = new System.Drawing.Point(260, 10);
            this.rbFecha.Name = "rbFecha";
            this.rbFecha.Size = new System.Drawing.Size(136, 25);
            this.rbFecha.TabIndex = 320;
            this.rbFecha.Text = "fecha especifica";
            this.rbFecha.UseVisualStyleBackColor = true;
            // 
            // rbNoventa
            // 
            this.rbNoventa.AutoSize = true;
            this.rbNoventa.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.rbNoventa.Location = new System.Drawing.Point(176, 10);
            this.rbNoventa.Name = "rbNoventa";
            this.rbNoventa.Size = new System.Drawing.Size(78, 25);
            this.rbNoventa.TabIndex = 319;
            this.rbNoventa.Text = "90 dias";
            this.rbNoventa.UseVisualStyleBackColor = true;
            // 
            // rbSesenta
            // 
            this.rbSesenta.AutoSize = true;
            this.rbSesenta.Checked = true;
            this.rbSesenta.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.rbSesenta.Location = new System.Drawing.Point(92, 10);
            this.rbSesenta.Name = "rbSesenta";
            this.rbSesenta.Size = new System.Drawing.Size(78, 25);
            this.rbSesenta.TabIndex = 318;
            this.rbSesenta.TabStop = true;
            this.rbSesenta.Text = "60 dias";
            this.rbSesenta.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(6, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 21);
            this.label2.TabIndex = 317;
            this.label2.Text = "A partir de:";
            // 
            // btnBuscarPartes
            // 
            this.btnBuscarPartes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBuscarPartes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnBuscarPartes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscarPartes.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnBuscarPartes.FlatAppearance.BorderSize = 0;
            this.btnBuscarPartes.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnBuscarPartes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnBuscarPartes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarPartes.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscarPartes.ForeColor = System.Drawing.Color.White;
            this.btnBuscarPartes.Image = global::CapaPresentacion.Properties.Resources.lupa;
            this.btnBuscarPartes.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBuscarPartes.Location = new System.Drawing.Point(685, 3);
            this.btnBuscarPartes.Name = "btnBuscarPartes";
            this.btnBuscarPartes.Size = new System.Drawing.Size(201, 35);
            this.btnBuscarPartes.TabIndex = 316;
            this.btnBuscarPartes.Text = "Buscar servicios cortados";
            this.btnBuscarPartes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscarPartes.UseVisualStyleBackColor = false;
            this.btnBuscarPartes.Click += new System.EventHandler(this.boton1_Click);
            // 
            // dtpFechaDesde
            // 
            this.dtpFechaDesde.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.dtpFechaDesde.Location = new System.Drawing.Point(402, 6);
            this.dtpFechaDesde.Name = "dtpFechaDesde";
            this.dtpFechaDesde.Size = new System.Drawing.Size(275, 29);
            this.dtpFechaDesde.TabIndex = 315;
            // 
            // btnGenerarPartes
            // 
            this.btnGenerarPartes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGenerarPartes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnGenerarPartes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGenerarPartes.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnGenerarPartes.FlatAppearance.BorderSize = 0;
            this.btnGenerarPartes.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnGenerarPartes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnGenerarPartes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerarPartes.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerarPartes.ForeColor = System.Drawing.Color.White;
            this.btnGenerarPartes.Image = global::CapaPresentacion.Properties.Resources.Data_Edit_32;
            this.btnGenerarPartes.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGenerarPartes.Location = new System.Drawing.Point(892, 4);
            this.btnGenerarPartes.Name = "btnGenerarPartes";
            this.btnGenerarPartes.Size = new System.Drawing.Size(140, 34);
            this.btnGenerarPartes.TabIndex = 314;
            this.btnGenerarPartes.Text = "Generar partes";
            this.btnGenerarPartes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGenerarPartes.UseVisualStyleBackColor = false;
            this.btnGenerarPartes.Click += new System.EventHandler(this.btnGenerarPartes_Click);
            // 
            // tarea
            // 
            this.tarea.WorkerReportsProgress = true;
            this.tarea.WorkerSupportsCancellation = true;
            this.tarea.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.tarea_ProgressChanged);
            this.tarea.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.tarea_RunWorkerCompleted);
            // 
            // tmrTiempo
            // 
            this.tmrTiempo.Enabled = true;
            this.tmrTiempo.Tick += new System.EventHandler(this.tmrTiempo_Tick);
            // 
            // pnlCentral
            // 
            this.pnlCentral.Controls.Add(this.spcMain);
            this.pnlCentral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCentral.Location = new System.Drawing.Point(0, 147);
            this.pnlCentral.Name = "pnlCentral";
            this.pnlCentral.Size = new System.Drawing.Size(1044, 390);
            this.pnlCentral.TabIndex = 256;
            // 
            // frmListadoCortes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1044, 537);
            this.Controls.Add(this.pnlCentral);
            this.Controls.Add(this.pnlBotones);
            this.Controls.Add(this.pnlTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "frmListadoCortes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmListadoCortes";
            this.Load += new System.EventHandler(this.frmListadoCortes_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmListadoCortes_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvServiciosCortados)).EndInit();
            this.pnlTitulo.ResumeLayout(false);
            this.pnlTitulo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgReturn)).EndInit();
            this.spcMain.Panel1.ResumeLayout(false);
            this.spcMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spcMain)).EndInit();
            this.spcMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTiposServicio)).EndInit();
            this.pnlReferencias.ResumeLayout(false);
            this.pnlReferencias.PerformLayout();
            this.pnlProceso.ResumeLayout(false);
            this.pnlProceso.PerformLayout();
            this.pnlBotones.ResumeLayout(false);
            this.pnlBotones.PerformLayout();
            this.pnlCentral.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvServiciosCortados;
        private System.Windows.Forms.Panel pnlTitulo;
        private System.Windows.Forms.PictureBox imgReturn;
        private System.Windows.Forms.Label lblTituloHeader;
        private System.Windows.Forms.SplitContainer spcMain;
        private System.Windows.Forms.Label lblTotal;
        private Controles.progress pgCircular;
        private System.Windows.Forms.Panel pnlBotones;
        private Controles.boton btnGenerarPartes;
        private System.Windows.Forms.DateTimePicker dtpFechaDesde;
        private System.Windows.Forms.ProgressBar pbrTrabajo;
        private System.ComponentModel.BackgroundWorker tarea;
        private Controles.boton btnBuscarPartes;
        private System.Windows.Forms.Timer tmrTiempo;
        private System.Windows.Forms.Label lblProgreso;
        private System.Windows.Forms.RadioButton rbNoventa;
        private System.Windows.Forms.RadioButton rbSesenta;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton rbFecha;
        private System.Windows.Forms.DataGridView dgvTiposServicio;
        private Controles.boton btnAplicarFiltros;
        private System.Windows.Forms.Panel pnlCentral;
        private System.Windows.Forms.Panel pnlReferencias;
        private System.Windows.Forms.Label lblReferencias;
        private System.Windows.Forms.Label lblRef60menos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblRef60;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel pnlProceso;
    }
}