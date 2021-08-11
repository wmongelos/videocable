namespace CapaPresentacion
{
    partial class frmFacturacionServiciosPorPeriodo
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.imgReturn = new System.Windows.Forms.PictureBox();
            this.lblFS = new System.Windows.Forms.Label();
            this.lblFacturacion = new System.Windows.Forms.Label();
            this.pnFooter = new System.Windows.Forms.Panel();
            this.lblImporteTotal = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lblTotal = new System.Windows.Forms.Label();
            this.pgCircular = new CapaPresentacion.Controles.progress();
            this.radioButtonUniverso = new System.Windows.Forms.RadioButton();
            this.radioButtonEspeciales = new System.Windows.Forms.RadioButton();
            this.radioButtonTodos = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.labelPeriodoSelec = new System.Windows.Forms.Label();
            this.labelMostrar = new System.Windows.Forms.Label();
            this.cboAgrupacion = new CapaPresentacion.Controles.combo(this.components);
            this.btnExportar = new CapaPresentacion.Controles.boton();
            this.txtPeriodoSeleccionado = new CapaPresentacion.textboxAdv();
            this.dgvPrincipal = new CapaPresentacion.Controles.dgv(this.components);
            this.dgvPeriodos = new CapaPresentacion.Controles.dgv(this.components);
            this.btnBuscar = new CapaPresentacion.Controles.boton();
            this.lblNetoTotal = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgReturn)).BeginInit();
            this.pnFooter.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrincipal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPeriodos)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panel1.Controls.Add(this.imgReturn);
            this.panel1.Controls.Add(this.lblFS);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1377, 75);
            this.panel1.TabIndex = 114;
            // 
            // imgReturn
            // 
            this.imgReturn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.imgReturn.Image = global::CapaPresentacion.Properties.Resources.Left_Arrow_32;
            this.imgReturn.Location = new System.Drawing.Point(17, 21);
            this.imgReturn.Name = "imgReturn";
            this.imgReturn.Size = new System.Drawing.Size(32, 32);
            this.imgReturn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgReturn.TabIndex = 122;
            this.imgReturn.TabStop = false;
            this.imgReturn.Click += new System.EventHandler(this.imgReturn_Click);
            // 
            // lblFS
            // 
            this.lblFS.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFS.ForeColor = System.Drawing.Color.White;
            this.lblFS.Location = new System.Drawing.Point(64, 26);
            this.lblFS.Name = "lblFS";
            this.lblFS.Size = new System.Drawing.Size(304, 23);
            this.lblFS.TabIndex = 114;
            this.lblFS.Text = "Facturacion Servicios";
            // 
            // lblFacturacion
            // 
            this.lblFacturacion.AutoSize = true;
            this.lblFacturacion.Font = new System.Drawing.Font("Segoe UI Light", 12F);
            this.lblFacturacion.ForeColor = System.Drawing.Color.Black;
            this.lblFacturacion.Location = new System.Drawing.Point(8, 131);
            this.lblFacturacion.Name = "lblFacturacion";
            this.lblFacturacion.Size = new System.Drawing.Size(141, 21);
            this.lblFacturacion.TabIndex = 288;
            this.lblFacturacion.Text = "Periodo Facturacion";
            // 
            // pnFooter
            // 
            this.pnFooter.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnFooter.Controls.Add(this.lblNetoTotal);
            this.pnFooter.Controls.Add(this.lblImporteTotal);
            this.pnFooter.Controls.Add(this.panel4);
            this.pnFooter.Controls.Add(this.lblTotal);
            this.pnFooter.Controls.Add(this.pgCircular);
            this.pnFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnFooter.Location = new System.Drawing.Point(0, 457);
            this.pnFooter.Name = "pnFooter";
            this.pnFooter.Size = new System.Drawing.Size(1377, 30);
            this.pnFooter.TabIndex = 322;
            // 
            // lblImporteTotal
            // 
            this.lblImporteTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblImporteTotal.AutoSize = true;
            this.lblImporteTotal.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblImporteTotal.ForeColor = System.Drawing.Color.Black;
            this.lblImporteTotal.Location = new System.Drawing.Point(1031, 5);
            this.lblImporteTotal.Name = "lblImporteTotal";
            this.lblImporteTotal.Size = new System.Drawing.Size(116, 21);
            this.lblImporteTotal.TabIndex = 338;
            this.lblImporteTotal.Text = "Importe total: 0";
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1377, 1);
            this.panel4.TabIndex = 337;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.ForeColor = System.Drawing.Color.Black;
            this.lblTotal.Location = new System.Drawing.Point(12, 4);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(148, 21);
            this.lblTotal.TabIndex = 13;
            this.lblTotal.Text = "Total de Registros: 0";
            // 
            // pgCircular
            // 
            this.pgCircular.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pgCircular.Location = new System.Drawing.Point(1341, 2);
            this.pgCircular.Name = "pgCircular";
            this.pgCircular.Percentage = 0F;
            this.pgCircular.Rotation = CapaPresentacion.Controles.RotationType.CounterClockwise;
            this.pgCircular.Size = new System.Drawing.Size(24, 24);
            this.pgCircular.TabIndex = 0;
            // 
            // radioButtonUniverso
            // 
            this.radioButtonUniverso.AutoSize = true;
            this.radioButtonUniverso.Location = new System.Drawing.Point(6, 28);
            this.radioButtonUniverso.Name = "radioButtonUniverso";
            this.radioButtonUniverso.Size = new System.Drawing.Size(85, 25);
            this.radioButtonUniverso.TabIndex = 324;
            this.radioButtonUniverso.Tag = "";
            this.radioButtonUniverso.Text = "Universo";
            this.radioButtonUniverso.UseVisualStyleBackColor = true;
            // 
            // radioButtonEspeciales
            // 
            this.radioButtonEspeciales.AutoSize = true;
            this.radioButtonEspeciales.Location = new System.Drawing.Point(101, 28);
            this.radioButtonEspeciales.Name = "radioButtonEspeciales";
            this.radioButtonEspeciales.Size = new System.Drawing.Size(94, 25);
            this.radioButtonEspeciales.TabIndex = 325;
            this.radioButtonEspeciales.Tag = "";
            this.radioButtonEspeciales.Text = "Especiales";
            this.radioButtonEspeciales.UseVisualStyleBackColor = true;
            // 
            // radioButtonTodos
            // 
            this.radioButtonTodos.AutoSize = true;
            this.radioButtonTodos.Checked = true;
            this.radioButtonTodos.Location = new System.Drawing.Point(201, 28);
            this.radioButtonTodos.Name = "radioButtonTodos";
            this.radioButtonTodos.Size = new System.Drawing.Size(66, 25);
            this.radioButtonTodos.TabIndex = 326;
            this.radioButtonTodos.TabStop = true;
            this.radioButtonTodos.Tag = "";
            this.radioButtonTodos.Text = "Todos";
            this.radioButtonTodos.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.radioButtonTodos);
            this.groupBox1.Controls.Add(this.radioButtonEspeciales);
            this.groupBox1.Controls.Add(this.radioButtonUniverso);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI Light", 12F);
            this.groupBox1.Location = new System.Drawing.Point(984, 85);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(269, 69);
            this.groupBox1.TabIndex = 327;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Presentacion";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Location = new System.Drawing.Point(0, 161);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1377, 1);
            this.panel2.TabIndex = 334;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Location = new System.Drawing.Point(166, 161);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1, 297);
            this.panel3.TabIndex = 335;
            // 
            // labelPeriodoSelec
            // 
            this.labelPeriodoSelec.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelPeriodoSelec.AutoSize = true;
            this.labelPeriodoSelec.Font = new System.Drawing.Font("Segoe UI Light", 12F);
            this.labelPeriodoSelec.ForeColor = System.Drawing.Color.Black;
            this.labelPeriodoSelec.Location = new System.Drawing.Point(821, 85);
            this.labelPeriodoSelec.Name = "labelPeriodoSelec";
            this.labelPeriodoSelec.Size = new System.Drawing.Size(151, 21);
            this.labelPeriodoSelec.TabIndex = 338;
            this.labelPeriodoSelec.Text = "Periodo seleccionado";
            // 
            // labelMostrar
            // 
            this.labelMostrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelMostrar.AutoSize = true;
            this.labelMostrar.Font = new System.Drawing.Font("Segoe UI Light", 12F);
            this.labelMostrar.ForeColor = System.Drawing.Color.Black;
            this.labelMostrar.Location = new System.Drawing.Point(684, 85);
            this.labelMostrar.Name = "labelMostrar";
            this.labelMostrar.Size = new System.Drawing.Size(66, 21);
            this.labelMostrar.TabIndex = 341;
            this.labelMostrar.Text = "Mostrar:";
            // 
            // cboAgrupacion
            // 
            this.cboAgrupacion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboAgrupacion.BorderColor = System.Drawing.Color.Empty;
            this.cboAgrupacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAgrupacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboAgrupacion.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboAgrupacion.FormattingEnabled = true;
            this.cboAgrupacion.Items.AddRange(new object[] {
            "Agrupado",
            "Detallado"});
            this.cboAgrupacion.Location = new System.Drawing.Point(688, 123);
            this.cboAgrupacion.Name = "cboAgrupacion";
            this.cboAgrupacion.Size = new System.Drawing.Size(121, 29);
            this.cboAgrupacion.TabIndex = 342;
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
            this.btnExportar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportar.ForeColor = System.Drawing.Color.White;
            this.btnExportar.Image = global::CapaPresentacion.Properties.Resources.Data_Export_32;
            this.btnExportar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExportar.Location = new System.Drawing.Point(1264, 121);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(101, 31);
            this.btnExportar.TabIndex = 340;
            this.btnExportar.Text = "Exportar";
            this.btnExportar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExportar.UseVisualStyleBackColor = true;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // txtPeriodoSeleccionado
            // 
            this.txtPeriodoSeleccionado.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPeriodoSeleccionado.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtPeriodoSeleccionado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPeriodoSeleccionado.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPeriodoSeleccionado.FocusColor = System.Drawing.Color.Empty;
            this.txtPeriodoSeleccionado.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtPeriodoSeleccionado.ForeColor = System.Drawing.Color.Black;
            this.txtPeriodoSeleccionado.Location = new System.Drawing.Point(825, 123);
            this.txtPeriodoSeleccionado.Name = "txtPeriodoSeleccionado";
            this.txtPeriodoSeleccionado.Numerico = false;
            this.txtPeriodoSeleccionado.ReadOnly = true;
            this.txtPeriodoSeleccionado.Size = new System.Drawing.Size(143, 29);
            this.txtPeriodoSeleccionado.TabIndex = 339;
            // 
            // dgvPrincipal
            // 
            this.dgvPrincipal.AllowUserToAddRows = false;
            this.dgvPrincipal.AllowUserToDeleteRows = false;
            this.dgvPrincipal.AllowUserToOrderColumns = true;
            this.dgvPrincipal.AllowUserToResizeColumns = false;
            this.dgvPrincipal.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPrincipal.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPrincipal.BackgroundColor = System.Drawing.Color.White;
            this.dgvPrincipal.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvPrincipal.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSlateGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPrincipal.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPrincipal.ColumnHeadersHeight = 40;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPrincipal.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvPrincipal.EnableHeadersVisualStyles = false;
            this.dgvPrincipal.GridColor = System.Drawing.Color.WhiteSmoke;
            this.dgvPrincipal.Location = new System.Drawing.Point(173, 168);
            this.dgvPrincipal.MultiSelect = false;
            this.dgvPrincipal.Name = "dgvPrincipal";
            this.dgvPrincipal.ReadOnly = true;
            this.dgvPrincipal.RowHeadersVisible = false;
            this.dgvPrincipal.RowHeadersWidth = 50;
            this.dgvPrincipal.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvPrincipal.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPrincipal.Size = new System.Drawing.Size(1192, 273);
            this.dgvPrincipal.TabIndex = 336;
            // 
            // dgvPeriodos
            // 
            this.dgvPeriodos.AllowUserToAddRows = false;
            this.dgvPeriodos.AllowUserToDeleteRows = false;
            this.dgvPeriodos.AllowUserToOrderColumns = true;
            this.dgvPeriodos.AllowUserToResizeColumns = false;
            this.dgvPeriodos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgvPeriodos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPeriodos.BackgroundColor = System.Drawing.Color.White;
            this.dgvPeriodos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvPeriodos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.LightSlateGray;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPeriodos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvPeriodos.ColumnHeadersHeight = 40;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPeriodos.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvPeriodos.EnableHeadersVisualStyles = false;
            this.dgvPeriodos.GridColor = System.Drawing.Color.WhiteSmoke;
            this.dgvPeriodos.Location = new System.Drawing.Point(12, 168);
            this.dgvPeriodos.MultiSelect = false;
            this.dgvPeriodos.Name = "dgvPeriodos";
            this.dgvPeriodos.ReadOnly = true;
            this.dgvPeriodos.RowHeadersVisible = false;
            this.dgvPeriodos.RowHeadersWidth = 50;
            this.dgvPeriodos.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvPeriodos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPeriodos.Size = new System.Drawing.Size(148, 273);
            this.dgvPeriodos.TabIndex = 321;
            this.dgvPeriodos.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPeriodos_CellEnter);
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
            this.btnBuscar.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnBuscar.ForeColor = System.Drawing.Color.White;
            this.btnBuscar.Image = global::CapaPresentacion.Properties.Resources.lupa;
            this.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBuscar.Location = new System.Drawing.Point(1264, 85);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(101, 31);
            this.btnBuscar.TabIndex = 319;
            this.btnBuscar.Text = "Consulta";
            this.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // lblNetoTotal
            // 
            this.lblNetoTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNetoTotal.AutoSize = true;
            this.lblNetoTotal.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNetoTotal.ForeColor = System.Drawing.Color.Black;
            this.lblNetoTotal.Location = new System.Drawing.Point(731, 5);
            this.lblNetoTotal.Name = "lblNetoTotal";
            this.lblNetoTotal.Size = new System.Drawing.Size(95, 21);
            this.lblNetoTotal.TabIndex = 339;
            this.lblNetoTotal.Text = "Neto total: 0";
            // 
            // frmFacturacionServiciosPorPeriodo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1377, 487);
            this.Controls.Add(this.cboAgrupacion);
            this.Controls.Add(this.labelMostrar);
            this.Controls.Add(this.btnExportar);
            this.Controls.Add(this.txtPeriodoSeleccionado);
            this.Controls.Add(this.labelPeriodoSelec);
            this.Controls.Add(this.dgvPrincipal);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pnFooter);
            this.Controls.Add(this.dgvPeriodos);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.lblFacturacion);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "frmFacturacionServiciosPorPeriodo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "";
            this.Text = "frmFacturacionServicios";
            this.Load += new System.EventHandler(this.frmFacturacionServicios_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmFacturacionServicios_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgReturn)).EndInit();
            this.pnFooter.ResumeLayout(false);
            this.pnFooter.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrincipal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPeriodos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox imgReturn;
        private System.Windows.Forms.Label lblFS;
        private System.Windows.Forms.Label lblFacturacion;
        private Controles.boton btnBuscar;
        private Controles.dgv dgvPeriodos;
        private System.Windows.Forms.Panel pnFooter;
        private System.Windows.Forms.Label lblTotal;
        private Controles.progress pgCircular;
        private System.Windows.Forms.RadioButton radioButtonUniverso;
        private System.Windows.Forms.RadioButton radioButtonEspeciales;
        private System.Windows.Forms.RadioButton radioButtonTodos;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private Controles.dgv dgvPrincipal;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label labelPeriodoSelec;
        private textboxAdv txtPeriodoSeleccionado;
        private Controles.boton btnExportar;
        private System.Windows.Forms.Label labelMostrar;
        private Controles.combo cboAgrupacion;
        private System.Windows.Forms.Label lblImporteTotal;
        private System.Windows.Forms.Label lblNetoTotal;
    }
}