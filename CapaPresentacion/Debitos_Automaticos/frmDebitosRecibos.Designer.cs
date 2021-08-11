namespace CapaPresentacion.Debitos_Automaticos
{
    partial class frmDebitosRecibos
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
            this.panel3 = new System.Windows.Forms.Panel();
            this.imgReturn = new System.Windows.Forms.PictureBox();
            this.lblTituloHeader = new System.Windows.Forms.Label();
            this.pnlInferior = new System.Windows.Forms.Panel();
            this.lblProgreso = new System.Windows.Forms.Label();
            this.pgBar = new System.Windows.Forms.ProgressBar();
            this.lblTotal = new System.Windows.Forms.Label();
            this.pgCircular = new CapaPresentacion.Controles.progress();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgv1 = new CapaPresentacion.Controles.dgv(this.components);
            this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.btnExportar2 = new CapaPresentacion.Controles.boton();
            this.btnBuscar = new CapaPresentacion.Controles.boton();
            this.btnRechazados = new CapaPresentacion.Controles.boton();
            this.btnGenerarRecibo = new CapaPresentacion.Controles.boton();
            this.lblPeriodo = new System.Windows.Forms.Label();
            this.cboPeriodos = new System.Windows.Forms.ComboBox();
            this.tarea = new System.ComponentModel.BackgroundWorker();
            this.pnlErrores = new System.Windows.Forms.Panel();
            this.boton1 = new CapaPresentacion.Controles.boton();
            this.btnExportar = new CapaPresentacion.Controles.boton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblTituloErrores = new System.Windows.Forms.Label();
            this.pnlTotales = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblImpago = new System.Windows.Forms.Label();
            this.lblCompronteDeuda = new System.Windows.Forms.Label();
            this.lblTotalTotal = new System.Windows.Forms.Label();
            this.lblTotalNoRechazado = new System.Windows.Forms.Label();
            this.lblRechazado = new System.Windows.Forms.Label();
            this.pnlFiltros = new System.Windows.Forms.Panel();
            this.chkNombre = new System.Windows.Forms.RadioButton();
            this.chkTarjeta = new System.Windows.Forms.RadioButton();
            this.chkCodigo = new System.Windows.Forms.RadioButton();
            this.lblFiltroPlastico = new System.Windows.Forms.Label();
            this.txtFitro = new CapaPresentacion.textboxAdv();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dgvDeudasAnexadas = new CapaPresentacion.Controles.dgv(this.components);
            this.Seleccionar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dgvErrores = new CapaPresentacion.Controles.dgv(this.components);
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgReturn)).BeginInit();
            this.pnlInferior.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).BeginInit();
            this.pnlErrores.SuspendLayout();
            this.panel2.SuspendLayout();
            this.pnlTotales.SuspendLayout();
            this.pnlFiltros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDeudasAnexadas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvErrores)).BeginInit();
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
            this.panel3.Size = new System.Drawing.Size(1131, 80);
            this.panel3.TabIndex = 49;
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
            this.lblTituloHeader.Text = "Generar recibos";
            // 
            // pnlInferior
            // 
            this.pnlInferior.Controls.Add(this.lblProgreso);
            this.pnlInferior.Controls.Add(this.pgBar);
            this.pnlInferior.Controls.Add(this.lblTotal);
            this.pnlInferior.Controls.Add(this.pgCircular);
            this.pnlInferior.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlInferior.Location = new System.Drawing.Point(0, 509);
            this.pnlInferior.Name = "pnlInferior";
            this.pnlInferior.Size = new System.Drawing.Size(1131, 38);
            this.pnlInferior.TabIndex = 376;
            // 
            // lblProgreso
            // 
            this.lblProgreso.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblProgreso.AutoSize = true;
            this.lblProgreso.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblProgreso.ForeColor = System.Drawing.Color.SlateGray;
            this.lblProgreso.Location = new System.Drawing.Point(663, 8);
            this.lblProgreso.Name = "lblProgreso";
            this.lblProgreso.Size = new System.Drawing.Size(174, 21);
            this.lblProgreso.TabIndex = 16;
            this.lblProgreso.Text = "Cantidad de registros: 0";
            this.lblProgreso.Visible = false;
            // 
            // pgBar
            // 
            this.pgBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pgBar.Location = new System.Drawing.Point(843, 6);
            this.pgBar.Name = "pgBar";
            this.pgBar.Size = new System.Drawing.Size(244, 29);
            this.pgBar.TabIndex = 15;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblTotal.ForeColor = System.Drawing.Color.SlateGray;
            this.lblTotal.Location = new System.Drawing.Point(12, 8);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(174, 21);
            this.lblTotal.TabIndex = 14;
            this.lblTotal.Text = "Cantidad de registros: 0";
            // 
            // pgCircular
            // 
            this.pgCircular.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pgCircular.Location = new System.Drawing.Point(1093, 2);
            this.pgCircular.Name = "pgCircular";
            this.pgCircular.Percentage = 0F;
            this.pgCircular.Rotation = CapaPresentacion.Controles.RotationType.CounterClockwise;
            this.pgCircular.Size = new System.Drawing.Size(35, 35);
            this.pgCircular.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgv1);
            this.panel1.Controls.Add(this.btnExportar2);
            this.panel1.Controls.Add(this.btnBuscar);
            this.panel1.Controls.Add(this.btnRechazados);
            this.panel1.Controls.Add(this.btnGenerarRecibo);
            this.panel1.Controls.Add(this.lblPeriodo);
            this.panel1.Controls.Add(this.cboPeriodos);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 80);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1131, 44);
            this.panel1.TabIndex = 377;
            // 
            // dgv1
            // 
            this.dgv1.AllowUserToAddRows = false;
            this.dgv1.AllowUserToDeleteRows = false;
            this.dgv1.AllowUserToOrderColumns = true;
            this.dgv1.AllowUserToResizeRows = false;
            this.dgv1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dgv1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv1.BackgroundColor = System.Drawing.Color.White;
            this.dgv1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgv1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSlateGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv1.ColumnHeadersHeight = 40;
            this.dgv1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewCheckBoxColumn1});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgv1.EnableHeadersVisualStyles = false;
            this.dgv1.GridColor = System.Drawing.Color.WhiteSmoke;
            this.dgv1.Location = new System.Drawing.Point(632, 6);
            this.dgv1.MultiSelect = false;
            this.dgv1.Name = "dgv1";
            this.dgv1.ReadOnly = true;
            this.dgv1.RowHeadersVisible = false;
            this.dgv1.RowHeadersWidth = 50;
            this.dgv1.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgv1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv1.Size = new System.Drawing.Size(39, 32);
            this.dgv1.TabIndex = 376;
            this.dgv1.Visible = false;
            // 
            // dataGridViewCheckBoxColumn1
            // 
            this.dataGridViewCheckBoxColumn1.HeaderText = "selecciona";
            this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            this.dataGridViewCheckBoxColumn1.ReadOnly = true;
            this.dataGridViewCheckBoxColumn1.Visible = false;
            // 
            // btnExportar2
            // 
            this.btnExportar2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportar2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnExportar2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExportar2.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnExportar2.FlatAppearance.BorderSize = 0;
            this.btnExportar2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnExportar2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnExportar2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportar2.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnExportar2.ForeColor = System.Drawing.Color.White;
            this.btnExportar2.Image = global::CapaPresentacion.Properties.Resources.Next_32;
            this.btnExportar2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExportar2.Location = new System.Drawing.Point(677, 5);
            this.btnExportar2.Name = "btnExportar2";
            this.btnExportar2.Size = new System.Drawing.Size(107, 35);
            this.btnExportar2.TabIndex = 391;
            this.btnExportar2.Text = "Exportar";
            this.btnExportar2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExportar2.UseVisualStyleBackColor = false;
            this.btnExportar2.Click += new System.EventHandler(this.btnExportar2_Click);
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
            this.btnBuscar.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.ForeColor = System.Drawing.Color.White;
            this.btnBuscar.Image = global::CapaPresentacion.Properties.Resources.lupa;
            this.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBuscar.Location = new System.Drawing.Point(329, 5);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(92, 35);
            this.btnBuscar.TabIndex = 389;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnRechazados
            // 
            this.btnRechazados.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRechazados.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnRechazados.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRechazados.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnRechazados.FlatAppearance.BorderSize = 0;
            this.btnRechazados.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnRechazados.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnRechazados.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRechazados.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRechazados.ForeColor = System.Drawing.Color.White;
            this.btnRechazados.Image = global::CapaPresentacion.Properties.Resources.Data_Delete_32;
            this.btnRechazados.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRechazados.Location = new System.Drawing.Point(790, 5);
            this.btnRechazados.Name = "btnRechazados";
            this.btnRechazados.Size = new System.Drawing.Size(172, 35);
            this.btnRechazados.TabIndex = 387;
            this.btnRechazados.Text = "Rechazado";
            this.btnRechazados.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRechazados.UseVisualStyleBackColor = false;
            this.btnRechazados.Click += new System.EventHandler(this.btnRechazados_Click);
            // 
            // btnGenerarRecibo
            // 
            this.btnGenerarRecibo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGenerarRecibo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnGenerarRecibo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGenerarRecibo.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnGenerarRecibo.FlatAppearance.BorderSize = 0;
            this.btnGenerarRecibo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnGenerarRecibo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnGenerarRecibo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerarRecibo.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerarRecibo.ForeColor = System.Drawing.Color.White;
            this.btnGenerarRecibo.Image = global::CapaPresentacion.Properties.Resources.Data_Add_32;
            this.btnGenerarRecibo.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGenerarRecibo.Location = new System.Drawing.Point(968, 5);
            this.btnGenerarRecibo.Name = "btnGenerarRecibo";
            this.btnGenerarRecibo.Size = new System.Drawing.Size(158, 35);
            this.btnGenerarRecibo.TabIndex = 386;
            this.btnGenerarRecibo.Text = "Generar Recibos";
            this.btnGenerarRecibo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGenerarRecibo.UseVisualStyleBackColor = false;
            this.btnGenerarRecibo.Click += new System.EventHandler(this.btnGenerarRecibo_Click);
            // 
            // lblPeriodo
            // 
            this.lblPeriodo.AutoSize = true;
            this.lblPeriodo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPeriodo.ForeColor = System.Drawing.Color.Black;
            this.lblPeriodo.Location = new System.Drawing.Point(9, 12);
            this.lblPeriodo.Name = "lblPeriodo";
            this.lblPeriodo.Size = new System.Drawing.Size(63, 21);
            this.lblPeriodo.TabIndex = 385;
            this.lblPeriodo.Text = "Periodo";
            // 
            // cboPeriodos
            // 
            this.cboPeriodos.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboPeriodos.FormattingEnabled = true;
            this.cboPeriodos.Location = new System.Drawing.Point(74, 9);
            this.cboPeriodos.Name = "cboPeriodos";
            this.cboPeriodos.Size = new System.Drawing.Size(249, 29);
            this.cboPeriodos.TabIndex = 384;
            this.cboPeriodos.SelectedValueChanged += new System.EventHandler(this.cboPeriodos_SelectedValueChanged);
            // 
            // tarea
            // 
            this.tarea.WorkerReportsProgress = true;
            this.tarea.WorkerSupportsCancellation = true;
            this.tarea.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.tarea_ProgressChanged);
            // 
            // pnlErrores
            // 
            this.pnlErrores.Controls.Add(this.boton1);
            this.pnlErrores.Controls.Add(this.btnExportar);
            this.pnlErrores.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlErrores.Location = new System.Drawing.Point(0, 290);
            this.pnlErrores.Name = "pnlErrores";
            this.pnlErrores.Size = new System.Drawing.Size(751, 54);
            this.pnlErrores.TabIndex = 378;
            // 
            // boton1
            // 
            this.boton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.boton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.boton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.boton1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.boton1.FlatAppearance.BorderSize = 0;
            this.boton1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.boton1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.boton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.boton1.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.boton1.ForeColor = System.Drawing.Color.White;
            this.boton1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.boton1.Location = new System.Drawing.Point(544, 13);
            this.boton1.Name = "boton1";
            this.boton1.Size = new System.Drawing.Size(81, 35);
            this.boton1.TabIndex = 388;
            this.boton1.Text = "Cerrar";
            this.boton1.UseVisualStyleBackColor = false;
            this.boton1.Click += new System.EventHandler(this.boton1_Click);
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
            this.btnExportar.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnExportar.ForeColor = System.Drawing.Color.White;
            this.btnExportar.Image = global::CapaPresentacion.Properties.Resources.Next_32;
            this.btnExportar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExportar.Location = new System.Drawing.Point(631, 13);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(107, 35);
            this.btnExportar.TabIndex = 322;
            this.btnExportar.Text = "Exportar";
            this.btnExportar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExportar.UseVisualStyleBackColor = false;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.panel2.Controls.Add(this.lblTituloErrores);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(751, 40);
            this.panel2.TabIndex = 274;
            // 
            // lblTituloErrores
            // 
            this.lblTituloErrores.AutoSize = true;
            this.lblTituloErrores.Font = new System.Drawing.Font("Segoe UI Light", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloErrores.ForeColor = System.Drawing.Color.White;
            this.lblTituloErrores.Location = new System.Drawing.Point(3, 3);
            this.lblTituloErrores.Name = "lblTituloErrores";
            this.lblTituloErrores.Size = new System.Drawing.Size(148, 25);
            this.lblTituloErrores.TabIndex = 208;
            this.lblTituloErrores.Text = "Recibos - Errores";
            // 
            // pnlTotales
            // 
            this.pnlTotales.Controls.Add(this.label3);
            this.pnlTotales.Controls.Add(this.label2);
            this.pnlTotales.Controls.Add(this.lblImpago);
            this.pnlTotales.Controls.Add(this.lblCompronteDeuda);
            this.pnlTotales.Controls.Add(this.lblTotalTotal);
            this.pnlTotales.Controls.Add(this.lblTotalNoRechazado);
            this.pnlTotales.Controls.Add(this.lblRechazado);
            this.pnlTotales.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlTotales.Location = new System.Drawing.Point(0, 547);
            this.pnlTotales.Name = "pnlTotales";
            this.pnlTotales.Size = new System.Drawing.Size(1131, 32);
            this.pnlTotales.TabIndex = 379;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(169, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 13);
            this.label3.TabIndex = 337;
            this.label3.Text = "[ RECHAZADO ]";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(12, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 13);
            this.label2.TabIndex = 336;
            this.label2.Text = "[ NO RECHAZADO ]";
            // 
            // lblImpago
            // 
            this.lblImpago.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblImpago.AutoSize = true;
            this.lblImpago.BackColor = System.Drawing.Color.LightSalmon;
            this.lblImpago.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblImpago.ForeColor = System.Drawing.Color.Black;
            this.lblImpago.Location = new System.Drawing.Point(259, 9);
            this.lblImpago.Name = "lblImpago";
            this.lblImpago.Size = new System.Drawing.Size(32, 17);
            this.lblImpago.TabIndex = 335;
            this.lblImpago.Text = "      ";
            this.lblImpago.Click += new System.EventHandler(this.lblImpago_Click);
            // 
            // lblCompronteDeuda
            // 
            this.lblCompronteDeuda.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblCompronteDeuda.AutoSize = true;
            this.lblCompronteDeuda.BackColor = System.Drawing.Color.LightBlue;
            this.lblCompronteDeuda.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCompronteDeuda.ForeColor = System.Drawing.Color.Black;
            this.lblCompronteDeuda.Location = new System.Drawing.Point(122, 9);
            this.lblCompronteDeuda.Name = "lblCompronteDeuda";
            this.lblCompronteDeuda.Size = new System.Drawing.Size(32, 17);
            this.lblCompronteDeuda.TabIndex = 334;
            this.lblCompronteDeuda.Text = "      ";
            this.lblCompronteDeuda.Click += new System.EventHandler(this.lblCompronteDeuda_Click);
            // 
            // lblTotalTotal
            // 
            this.lblTotalTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalTotal.AutoSize = true;
            this.lblTotalTotal.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.lblTotalTotal.ForeColor = System.Drawing.Color.Black;
            this.lblTotalTotal.Location = new System.Drawing.Point(785, 7);
            this.lblTotalTotal.Name = "lblTotalTotal";
            this.lblTotalTotal.Size = new System.Drawing.Size(52, 25);
            this.lblTotalTotal.TabIndex = 19;
            this.lblTotalTotal.Text = "Total";
            this.lblTotalTotal.Click += new System.EventHandler(this.lblTotalTotal_Click);
            // 
            // lblTotalNoRechazado
            // 
            this.lblTotalNoRechazado.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalNoRechazado.AutoSize = true;
            this.lblTotalNoRechazado.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.lblTotalNoRechazado.ForeColor = System.Drawing.Color.Black;
            this.lblTotalNoRechazado.Location = new System.Drawing.Point(956, 7);
            this.lblTotalNoRechazado.Name = "lblTotalNoRechazado";
            this.lblTotalNoRechazado.Size = new System.Drawing.Size(172, 25);
            this.lblTotalNoRechazado.TabIndex = 18;
            this.lblTotalNoRechazado.Text = "Total no rechazado";
            // 
            // lblRechazado
            // 
            this.lblRechazado.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRechazado.AutoSize = true;
            this.lblRechazado.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.lblRechazado.ForeColor = System.Drawing.Color.Black;
            this.lblRechazado.Location = new System.Drawing.Point(833, 7);
            this.lblRechazado.Name = "lblRechazado";
            this.lblRechazado.Size = new System.Drawing.Size(145, 25);
            this.lblRechazado.TabIndex = 17;
            this.lblRechazado.Text = "Total rechazado";
            this.lblRechazado.Click += new System.EventHandler(this.lblRechazado_Click);
            // 
            // pnlFiltros
            // 
            this.pnlFiltros.Controls.Add(this.chkNombre);
            this.pnlFiltros.Controls.Add(this.chkTarjeta);
            this.pnlFiltros.Controls.Add(this.chkCodigo);
            this.pnlFiltros.Controls.Add(this.lblFiltroPlastico);
            this.pnlFiltros.Controls.Add(this.txtFitro);
            this.pnlFiltros.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFiltros.Location = new System.Drawing.Point(0, 124);
            this.pnlFiltros.Name = "pnlFiltros";
            this.pnlFiltros.Size = new System.Drawing.Size(1131, 41);
            this.pnlFiltros.TabIndex = 380;
            // 
            // chkNombre
            // 
            this.chkNombre.AutoSize = true;
            this.chkNombre.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.chkNombre.Location = new System.Drawing.Point(611, 7);
            this.chkNombre.Name = "chkNombre";
            this.chkNombre.Size = new System.Drawing.Size(151, 25);
            this.chkNombre.TabIndex = 391;
            this.chkNombre.Text = "Nombre abonado";
            this.chkNombre.UseVisualStyleBackColor = true;
            this.chkNombre.CheckedChanged += new System.EventHandler(this.chkNombre_CheckedChanged);
            // 
            // chkTarjeta
            // 
            this.chkTarjeta.AutoSize = true;
            this.chkTarjeta.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.chkTarjeta.Location = new System.Drawing.Point(471, 7);
            this.chkTarjeta.Name = "chkTarjeta";
            this.chkTarjeta.Size = new System.Drawing.Size(134, 25);
            this.chkTarjeta.TabIndex = 390;
            this.chkTarjeta.Text = "Numero tarjeta";
            this.chkTarjeta.UseVisualStyleBackColor = true;
            // 
            // chkCodigo
            // 
            this.chkCodigo.AutoSize = true;
            this.chkCodigo.Checked = true;
            this.chkCodigo.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.chkCodigo.Location = new System.Drawing.Point(331, 7);
            this.chkCodigo.Name = "chkCodigo";
            this.chkCodigo.Size = new System.Drawing.Size(134, 25);
            this.chkCodigo.TabIndex = 389;
            this.chkCodigo.TabStop = true;
            this.chkCodigo.Text = "Codigo usuario";
            this.chkCodigo.UseVisualStyleBackColor = true;
            // 
            // lblFiltroPlastico
            // 
            this.lblFiltroPlastico.AutoSize = true;
            this.lblFiltroPlastico.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFiltroPlastico.ForeColor = System.Drawing.Color.Black;
            this.lblFiltroPlastico.Location = new System.Drawing.Point(22, 8);
            this.lblFiltroPlastico.Name = "lblFiltroPlastico";
            this.lblFiltroPlastico.Size = new System.Drawing.Size(46, 21);
            this.lblFiltroPlastico.TabIndex = 386;
            this.lblFiltroPlastico.Text = "Filtro";
            // 
            // txtFitro
            // 
            this.txtFitro.BorderColor = System.Drawing.Color.Empty;
            this.txtFitro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFitro.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtFitro.FocusColor = System.Drawing.Color.Empty;
            this.txtFitro.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFitro.Location = new System.Drawing.Point(74, 6);
            this.txtFitro.Name = "txtFitro";
            this.txtFitro.Numerico = false;
            this.txtFitro.Size = new System.Drawing.Size(249, 29);
            this.txtFitro.TabIndex = 0;
            this.txtFitro.TextChanged += new System.EventHandler(this.txtFitro_TextChanged);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 165);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dgvDeudasAnexadas);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgvErrores);
            this.splitContainer1.Panel2.Controls.Add(this.pnlErrores);
            this.splitContainer1.Panel2.Controls.Add(this.panel2);
            this.splitContainer1.Size = new System.Drawing.Size(1131, 344);
            this.splitContainer1.SplitterDistance = 376;
            this.splitContainer1.TabIndex = 381;
            // 
            // dgvDeudasAnexadas
            // 
            this.dgvDeudasAnexadas.AllowUserToAddRows = false;
            this.dgvDeudasAnexadas.AllowUserToDeleteRows = false;
            this.dgvDeudasAnexadas.AllowUserToOrderColumns = true;
            this.dgvDeudasAnexadas.AllowUserToResizeRows = false;
            this.dgvDeudasAnexadas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDeudasAnexadas.BackgroundColor = System.Drawing.Color.White;
            this.dgvDeudasAnexadas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDeudasAnexadas.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvDeudasAnexadas.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.LightSlateGray;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDeudasAnexadas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvDeudasAnexadas.ColumnHeadersHeight = 40;
            this.dgvDeudasAnexadas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Seleccionar});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDeudasAnexadas.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvDeudasAnexadas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDeudasAnexadas.EnableHeadersVisualStyles = false;
            this.dgvDeudasAnexadas.GridColor = System.Drawing.Color.WhiteSmoke;
            this.dgvDeudasAnexadas.Location = new System.Drawing.Point(0, 0);
            this.dgvDeudasAnexadas.MultiSelect = false;
            this.dgvDeudasAnexadas.Name = "dgvDeudasAnexadas";
            this.dgvDeudasAnexadas.ReadOnly = true;
            this.dgvDeudasAnexadas.RowHeadersVisible = false;
            this.dgvDeudasAnexadas.RowHeadersWidth = 50;
            this.dgvDeudasAnexadas.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvDeudasAnexadas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDeudasAnexadas.Size = new System.Drawing.Size(376, 344);
            this.dgvDeudasAnexadas.TabIndex = 375;
            this.dgvDeudasAnexadas.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDeudasAnexadas_CellClick);
            this.dgvDeudasAnexadas.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDeudasAnexadas_CellEndEdit);
            this.dgvDeudasAnexadas.SelectionChanged += new System.EventHandler(this.dgvDeudasAnexadas_SelectionChanged);
            this.dgvDeudasAnexadas.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvDeudasAnexadas_KeyDown);
            // 
            // Seleccionar
            // 
            this.Seleccionar.HeaderText = "selecciona";
            this.Seleccionar.Name = "Seleccionar";
            this.Seleccionar.ReadOnly = true;
            this.Seleccionar.Visible = false;
            // 
            // dgvErrores
            // 
            this.dgvErrores.AllowUserToAddRows = false;
            this.dgvErrores.AllowUserToDeleteRows = false;
            this.dgvErrores.AllowUserToOrderColumns = true;
            this.dgvErrores.AllowUserToResizeColumns = false;
            this.dgvErrores.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvErrores.BackgroundColor = System.Drawing.Color.White;
            this.dgvErrores.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvErrores.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.LightSlateGray;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvErrores.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvErrores.ColumnHeadersHeight = 40;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvErrores.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvErrores.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvErrores.EnableHeadersVisualStyles = false;
            this.dgvErrores.GridColor = System.Drawing.Color.WhiteSmoke;
            this.dgvErrores.Location = new System.Drawing.Point(0, 40);
            this.dgvErrores.MultiSelect = false;
            this.dgvErrores.Name = "dgvErrores";
            this.dgvErrores.ReadOnly = true;
            this.dgvErrores.RowHeadersVisible = false;
            this.dgvErrores.RowHeadersWidth = 50;
            this.dgvErrores.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvErrores.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvErrores.Size = new System.Drawing.Size(751, 250);
            this.dgvErrores.TabIndex = 314;
            // 
            // frmDebitosRecibos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1131, 579);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.pnlInferior);
            this.Controls.Add(this.pnlTotales);
            this.Controls.Add(this.pnlFiltros);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Name = "frmDebitosRecibos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Debitos";
            this.Load += new System.EventHandler(this.frmDebitosRecibos_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmDebitosRecibos_KeyDown);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgReturn)).EndInit();
            this.pnlInferior.ResumeLayout(false);
            this.pnlInferior.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).EndInit();
            this.pnlErrores.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.pnlTotales.ResumeLayout(false);
            this.pnlTotales.PerformLayout();
            this.pnlFiltros.ResumeLayout(false);
            this.pnlFiltros.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDeudasAnexadas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvErrores)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox imgReturn;
        private System.Windows.Forms.Label lblTituloHeader;
        private Controles.dgv dgvDeudasAnexadas;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Seleccionar;
        private System.Windows.Forms.Panel pnlInferior;
        private Controles.progress pgCircular;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cboPeriodos;
        private System.Windows.Forms.Label lblPeriodo;
        private Controles.boton btnGenerarRecibo;
        private System.Windows.Forms.ProgressBar pgBar;
        private Controles.boton btnRechazados;
        private System.ComponentModel.BackgroundWorker tarea;
        private System.Windows.Forms.Panel pnlErrores;
        private Controles.boton btnExportar;
        private Controles.dgv dgvErrores;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblTituloErrores;
        private Controles.boton boton1;
        private System.Windows.Forms.Label lblProgreso;
        private System.Windows.Forms.Panel pnlTotales;
        private System.Windows.Forms.Label lblTotalTotal;
        private System.Windows.Forms.Label lblTotalNoRechazado;
        private System.Windows.Forms.Label lblRechazado;
        private Controles.boton btnBuscar;
        private System.Windows.Forms.Panel pnlFiltros;
        private System.Windows.Forms.Label lblFiltroPlastico;
        private textboxAdv txtFitro;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblImpago;
        private System.Windows.Forms.Label lblCompronteDeuda;
        private System.Windows.Forms.RadioButton chkTarjeta;
        private System.Windows.Forms.RadioButton chkCodigo;
        private Controles.boton btnExportar2;
        private Controles.dgv dgv1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private System.Windows.Forms.RadioButton chkNombre;
    }
}