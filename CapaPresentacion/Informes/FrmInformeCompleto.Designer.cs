namespace CapaPresentacion.Informes
{
    partial class FrmInformeCompleto
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel3 = new System.Windows.Forms.Panel();
            this.imgReturn = new System.Windows.Forms.PictureBox();
            this.lblTituloHeader = new System.Windows.Forms.Label();
            this.pnFooter = new System.Windows.Forms.Panel();
            this.lblTotal = new System.Windows.Forms.Label();
            this.pnlControles = new System.Windows.Forms.Panel();
            this.gbUniverso = new System.Windows.Forms.GroupBox();
            this.rbTodos = new System.Windows.Forms.RadioButton();
            this.rbEspeciales = new System.Windows.Forms.RadioButton();
            this.rbUniverso = new System.Windows.Forms.RadioButton();
            this.lblFiltros = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rbFechaInicioServ = new System.Windows.Forms.RadioButton();
            this.rbFechaMov = new System.Windows.Forms.RadioButton();
            this.rbPeriodo = new System.Windows.Forms.RadioButton();
            this.dtpFechaInicioServ = new System.Windows.Forms.DateTimePicker();
            this.dtpFechaMov = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTipo = new System.Windows.Forms.Label();
            this.dgv = new CapaPresentacion.Controles.dgv(this.components);
            this.dgvDatos = new CapaPresentacion.Controles.dgv(this.components);
            this.btnFiltrar = new CapaPresentacion.Controles.boton();
            this.btnExportar = new CapaPresentacion.Controles.boton();
            this.cboHistorialFacturacion = new CapaPresentacion.Controles.combo(this.components);
            this.btnBuscar = new CapaPresentacion.Controles.boton();
            this.pgCircular = new CapaPresentacion.Controles.progress();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgReturn)).BeginInit();
            this.pnFooter.SuspendLayout();
            this.pnlControles.SuspendLayout();
            this.gbUniverso.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).BeginInit();
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
            this.panel3.Size = new System.Drawing.Size(1055, 75);
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
            this.lblTituloHeader.Size = new System.Drawing.Size(156, 25);
            this.lblTituloHeader.TabIndex = 31;
            this.lblTituloHeader.Text = "Informe completo";
            // 
            // pnFooter
            // 
            this.pnFooter.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnFooter.Controls.Add(this.lblTotal);
            this.pnFooter.Controls.Add(this.pgCircular);
            this.pnFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnFooter.Location = new System.Drawing.Point(0, 420);
            this.pnFooter.Name = "pnFooter";
            this.pnFooter.Size = new System.Drawing.Size(1055, 30);
            this.pnFooter.TabIndex = 192;
            // 
            // lblTotal
            // 
            this.lblTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.ForeColor = System.Drawing.Color.SlateGray;
            this.lblTotal.Location = new System.Drawing.Point(12, 8);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(111, 13);
            this.lblTotal.TabIndex = 13;
            this.lblTotal.Text = "Total de Registros: 0";
            // 
            // pnlControles
            // 
            this.pnlControles.Controls.Add(this.btnFiltrar);
            this.pnlControles.Controls.Add(this.gbUniverso);
            this.pnlControles.Controls.Add(this.lblFiltros);
            this.pnlControles.Controls.Add(this.panel1);
            this.pnlControles.Controls.Add(this.rbFechaInicioServ);
            this.pnlControles.Controls.Add(this.rbFechaMov);
            this.pnlControles.Controls.Add(this.rbPeriodo);
            this.pnlControles.Controls.Add(this.dtpFechaInicioServ);
            this.pnlControles.Controls.Add(this.dtpFechaMov);
            this.pnlControles.Controls.Add(this.label2);
            this.pnlControles.Controls.Add(this.label1);
            this.pnlControles.Controls.Add(this.btnExportar);
            this.pnlControles.Controls.Add(this.lblTipo);
            this.pnlControles.Controls.Add(this.cboHistorialFacturacion);
            this.pnlControles.Controls.Add(this.btnBuscar);
            this.pnlControles.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlControles.Location = new System.Drawing.Point(0, 75);
            this.pnlControles.Name = "pnlControles";
            this.pnlControles.Size = new System.Drawing.Size(1055, 120);
            this.pnlControles.TabIndex = 193;
            // 
            // gbUniverso
            // 
            this.gbUniverso.Controls.Add(this.rbTodos);
            this.gbUniverso.Controls.Add(this.rbEspeciales);
            this.gbUniverso.Controls.Add(this.rbUniverso);
            this.gbUniverso.Enabled = false;
            this.gbUniverso.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.gbUniverso.Location = new System.Drawing.Point(419, 45);
            this.gbUniverso.Name = "gbUniverso";
            this.gbUniverso.Size = new System.Drawing.Size(255, 56);
            this.gbUniverso.TabIndex = 354;
            this.gbUniverso.TabStop = false;
            this.gbUniverso.Text = "Presentacion";
            // 
            // rbTodos
            // 
            this.rbTodos.AutoSize = true;
            this.rbTodos.Checked = true;
            this.rbTodos.Location = new System.Drawing.Point(186, 24);
            this.rbTodos.Name = "rbTodos";
            this.rbTodos.Size = new System.Drawing.Size(63, 23);
            this.rbTodos.TabIndex = 2;
            this.rbTodos.TabStop = true;
            this.rbTodos.Text = "Todos";
            this.rbTodos.UseVisualStyleBackColor = true;
            // 
            // rbEspeciales
            // 
            this.rbEspeciales.AutoSize = true;
            this.rbEspeciales.Location = new System.Drawing.Point(93, 24);
            this.rbEspeciales.Name = "rbEspeciales";
            this.rbEspeciales.Size = new System.Drawing.Size(87, 23);
            this.rbEspeciales.TabIndex = 1;
            this.rbEspeciales.Text = "Especiales";
            this.rbEspeciales.UseVisualStyleBackColor = true;
            // 
            // rbUniverso
            // 
            this.rbUniverso.AutoSize = true;
            this.rbUniverso.Location = new System.Drawing.Point(6, 22);
            this.rbUniverso.Name = "rbUniverso";
            this.rbUniverso.Size = new System.Drawing.Size(81, 23);
            this.rbUniverso.TabIndex = 0;
            this.rbUniverso.Text = "Universo";
            this.rbUniverso.UseVisualStyleBackColor = true;
            // 
            // lblFiltros
            // 
            this.lblFiltros.AutoSize = true;
            this.lblFiltros.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFiltros.ForeColor = System.Drawing.Color.Black;
            this.lblFiltros.Location = new System.Drawing.Point(415, 14);
            this.lblFiltros.Name = "lblFiltros";
            this.lblFiltros.Size = new System.Drawing.Size(49, 19);
            this.lblFiltros.TabIndex = 353;
            this.lblFiltros.Text = "Filtros:";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(398, 14);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1, 93);
            this.panel1.TabIndex = 352;
            // 
            // rbFechaInicioServ
            // 
            this.rbFechaInicioServ.AutoSize = true;
            this.rbFechaInicioServ.Location = new System.Drawing.Point(374, 94);
            this.rbFechaInicioServ.Name = "rbFechaInicioServ";
            this.rbFechaInicioServ.Size = new System.Drawing.Size(14, 13);
            this.rbFechaInicioServ.TabIndex = 351;
            this.rbFechaInicioServ.UseVisualStyleBackColor = true;
            this.rbFechaInicioServ.CheckedChanged += new System.EventHandler(this.rbConsulta_CheckedChanged);
            // 
            // rbFechaMov
            // 
            this.rbFechaMov.AutoSize = true;
            this.rbFechaMov.Location = new System.Drawing.Point(374, 54);
            this.rbFechaMov.Name = "rbFechaMov";
            this.rbFechaMov.Size = new System.Drawing.Size(14, 13);
            this.rbFechaMov.TabIndex = 350;
            this.rbFechaMov.UseVisualStyleBackColor = true;
            this.rbFechaMov.CheckedChanged += new System.EventHandler(this.rbConsulta_CheckedChanged);
            // 
            // rbPeriodo
            // 
            this.rbPeriodo.AutoSize = true;
            this.rbPeriodo.Checked = true;
            this.rbPeriodo.Location = new System.Drawing.Point(375, 14);
            this.rbPeriodo.Name = "rbPeriodo";
            this.rbPeriodo.Size = new System.Drawing.Size(14, 13);
            this.rbPeriodo.TabIndex = 349;
            this.rbPeriodo.TabStop = true;
            this.rbPeriodo.UseVisualStyleBackColor = true;
            this.rbPeriodo.CheckedChanged += new System.EventHandler(this.rbConsulta_CheckedChanged);
            // 
            // dtpFechaInicioServ
            // 
            this.dtpFechaInicioServ.CustomFormat = "yyyy MMMM";
            this.dtpFechaInicioServ.Font = new System.Drawing.Font("Segoe UI Light", 12.25F);
            this.dtpFechaInicioServ.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFechaInicioServ.Location = new System.Drawing.Point(173, 84);
            this.dtpFechaInicioServ.Name = "dtpFechaInicioServ";
            this.dtpFechaInicioServ.ShowUpDown = true;
            this.dtpFechaInicioServ.Size = new System.Drawing.Size(195, 29);
            this.dtpFechaInicioServ.TabIndex = 348;
            // 
            // dtpFechaMov
            // 
            this.dtpFechaMov.CustomFormat = "yyyy MMMM";
            this.dtpFechaMov.Font = new System.Drawing.Font("Segoe UI Light", 12.25F);
            this.dtpFechaMov.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFechaMov.Location = new System.Drawing.Point(173, 46);
            this.dtpFechaMov.Name = "dtpFechaMov";
            this.dtpFechaMov.ShowUpDown = true;
            this.dtpFechaMov.Size = new System.Drawing.Size(195, 29);
            this.dtpFechaMov.TabIndex = 347;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(43, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 19);
            this.label2.TabIndex = 346;
            this.label2.Text = "Fecha movimiento:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(17, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 19);
            this.label1.TabIndex = 345;
            this.label1.Text = "Fecha inicio de servicio:";
            // 
            // lblTipo
            // 
            this.lblTipo.AutoSize = true;
            this.lblTipo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipo.ForeColor = System.Drawing.Color.Black;
            this.lblTipo.Location = new System.Drawing.Point(38, 14);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(129, 19);
            this.lblTipo.TabIndex = 343;
            this.lblTipo.Text = "Periodo facturacion:";
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AllowUserToOrderColumns = true;
            this.dgv.AllowUserToResizeColumns = false;
            this.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv.BackgroundColor = System.Drawing.Color.White;
            this.dgv.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgv.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.LightSlateGray;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.dgv.ColumnHeadersHeight = 40;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv.DefaultCellStyle = dataGridViewCellStyle12;
            this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv.EnableHeadersVisualStyles = false;
            this.dgv.GridColor = System.Drawing.Color.WhiteSmoke;
            this.dgv.Location = new System.Drawing.Point(0, 195);
            this.dgv.MultiSelect = false;
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersVisible = false;
            this.dgv.RowHeadersWidth = 50;
            this.dgv.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(1055, 225);
            this.dgv.TabIndex = 417;
            this.dgv.VirtualMode = true;
            // 
            // dgvDatos
            // 
            this.dgvDatos.AllowUserToAddRows = false;
            this.dgvDatos.AllowUserToDeleteRows = false;
            this.dgvDatos.AllowUserToOrderColumns = true;
            this.dgvDatos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDatos.BackgroundColor = System.Drawing.Color.White;
            this.dgvDatos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDatos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle13.BackColor = System.Drawing.Color.LightSlateGray;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Segoe UI", 12F);
            dataGridViewCellStyle13.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDatos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle13;
            this.dgvDatos.ColumnHeadersHeight = 40;
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Segoe UI", 12F);
            dataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDatos.DefaultCellStyle = dataGridViewCellStyle14;
            this.dgvDatos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDatos.EnableHeadersVisualStyles = false;
            this.dgvDatos.GridColor = System.Drawing.Color.WhiteSmoke;
            this.dgvDatos.Location = new System.Drawing.Point(0, 195);
            this.dgvDatos.MultiSelect = false;
            this.dgvDatos.Name = "dgvDatos";
            this.dgvDatos.ReadOnly = true;
            this.dgvDatos.RowHeadersVisible = false;
            this.dgvDatos.RowHeadersWidth = 50;
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDatos.RowsDefaultCellStyle = dataGridViewCellStyle15;
            this.dgvDatos.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvDatos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvDatos.Size = new System.Drawing.Size(1055, 225);
            this.dgvDatos.TabIndex = 416;
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFiltrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnFiltrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFiltrar.Enabled = false;
            this.btnFiltrar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnFiltrar.FlatAppearance.BorderSize = 0;
            this.btnFiltrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnFiltrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnFiltrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFiltrar.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFiltrar.ForeColor = System.Drawing.Color.White;
            this.btnFiltrar.Image = global::CapaPresentacion.Properties.Resources.Data_Edit_32;
            this.btnFiltrar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFiltrar.Location = new System.Drawing.Point(924, 45);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(124, 31);
            this.btnFiltrar.TabIndex = 355;
            this.btnFiltrar.Text = "Filtrar";
            this.btnFiltrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnFiltrar.UseVisualStyleBackColor = false;
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);
            // 
            // btnExportar
            // 
            this.btnExportar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnExportar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExportar.Enabled = false;
            this.btnExportar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnExportar.FlatAppearance.BorderSize = 0;
            this.btnExportar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnExportar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnExportar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportar.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportar.ForeColor = System.Drawing.Color.White;
            this.btnExportar.Image = global::CapaPresentacion.Properties.Resources.Data_Export_32;
            this.btnExportar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExportar.Location = new System.Drawing.Point(924, 81);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(124, 31);
            this.btnExportar.TabIndex = 344;
            this.btnExportar.Text = "Exportar";
            this.btnExportar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExportar.UseVisualStyleBackColor = false;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // cboHistorialFacturacion
            // 
            this.cboHistorialFacturacion.BorderColor = System.Drawing.Color.Gray;
            this.cboHistorialFacturacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboHistorialFacturacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboHistorialFacturacion.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboHistorialFacturacion.FormattingEnabled = true;
            this.cboHistorialFacturacion.Location = new System.Drawing.Point(173, 8);
            this.cboHistorialFacturacion.Name = "cboHistorialFacturacion";
            this.cboHistorialFacturacion.Size = new System.Drawing.Size(195, 29);
            this.cboHistorialFacturacion.TabIndex = 342;
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
            this.btnBuscar.Location = new System.Drawing.Point(924, 9);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(124, 31);
            this.btnBuscar.TabIndex = 341;
            this.btnBuscar.Text = "Consultar";
            this.btnBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // pgCircular
            // 
            this.pgCircular.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pgCircular.Location = new System.Drawing.Point(1019, 2);
            this.pgCircular.Name = "pgCircular";
            this.pgCircular.Percentage = 0F;
            this.pgCircular.Rotation = CapaPresentacion.Controles.RotationType.CounterClockwise;
            this.pgCircular.Size = new System.Drawing.Size(24, 24);
            this.pgCircular.TabIndex = 0;
            // 
            // FrmInformeCompleto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1055, 450);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.dgvDatos);
            this.Controls.Add(this.pnlControles);
            this.Controls.Add(this.pnFooter);
            this.Controls.Add(this.panel3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "FrmInformeCompleto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmInformeCompleto";
            this.Load += new System.EventHandler(this.FrmInformeCompleto_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmInformeCompleto_KeyDown);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgReturn)).EndInit();
            this.pnFooter.ResumeLayout(false);
            this.pnFooter.PerformLayout();
            this.pnlControles.ResumeLayout(false);
            this.pnlControles.PerformLayout();
            this.gbUniverso.ResumeLayout(false);
            this.gbUniverso.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox imgReturn;
        private System.Windows.Forms.Label lblTituloHeader;
        private System.Windows.Forms.Panel pnFooter;
        private System.Windows.Forms.Label lblTotal;
        private Controles.progress pgCircular;
        private System.Windows.Forms.Panel pnlControles;
        private Controles.dgv dgvDatos;
        private Controles.boton btnBuscar;
        private Controles.combo cboHistorialFacturacion;
        private System.Windows.Forms.Label lblTipo;
        private BrightIdeasSoftware.ObjectListView olvDatos;
        private Controles.dgv dgv;
        private Controles.boton btnExportar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpFechaMov;
        private System.Windows.Forms.DateTimePicker dtpFechaInicioServ;
        private System.Windows.Forms.RadioButton rbFechaInicioServ;
        private System.Windows.Forms.RadioButton rbFechaMov;
        private System.Windows.Forms.RadioButton rbPeriodo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblFiltros;
        private System.Windows.Forms.GroupBox gbUniverso;
        private System.Windows.Forms.RadioButton rbEspeciales;
        private System.Windows.Forms.RadioButton rbUniverso;
        private Controles.boton btnFiltrar;
        private System.Windows.Forms.RadioButton rbTodos;
    }
}