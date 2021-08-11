namespace CapaPresentacion.Informes
{
    partial class frmPagosAdelantados
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
            this.panel3 = new System.Windows.Forms.Panel();
            this.imgReturn = new System.Windows.Forms.PictureBox();
            this.lblTituloHeader = new System.Windows.Forms.Label();
            this.pnFooter = new System.Windows.Forms.Panel();
            this.lblTotal = new System.Windows.Forms.Label();
            this.pgCircular = new CapaPresentacion.Controles.progress();
            this.panel1 = new System.Windows.Forms.Panel();
            this.gbCuenta = new System.Windows.Forms.GroupBox();
            this.rbTodasCuenta = new System.Windows.Forms.RadioButton();
            this.rbCuenta2 = new System.Windows.Forms.RadioButton();
            this.rbCuenta1 = new System.Windows.Forms.RadioButton();
            this.gbPresentacion = new System.Windows.Forms.GroupBox();
            this.rbTodosUniverso = new System.Windows.Forms.RadioButton();
            this.rbEspeciales = new System.Windows.Forms.RadioButton();
            this.rbUniverso = new System.Windows.Forms.RadioButton();
            this.btnExportar = new CapaPresentacion.Controles.boton();
            this.cboTipoServicio = new CapaPresentacion.Controles.combo(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.btnBuscar = new CapaPresentacion.Controles.boton();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgv = new CapaPresentacion.Controles.dgv(this.components);
            this.lblImporteTotal = new System.Windows.Forms.Label();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgReturn)).BeginInit();
            this.pnFooter.SuspendLayout();
            this.panel1.SuspendLayout();
            this.gbCuenta.SuspendLayout();
            this.gbPresentacion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
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
            this.panel3.Size = new System.Drawing.Size(1306, 75);
            this.panel3.TabIndex = 38;
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
            this.lblTituloHeader.Size = new System.Drawing.Size(161, 25);
            this.lblTituloHeader.TabIndex = 31;
            this.lblTituloHeader.Text = "Pagos adelantados";
            // 
            // pnFooter
            // 
            this.pnFooter.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnFooter.Controls.Add(this.lblImporteTotal);
            this.pnFooter.Controls.Add(this.lblTotal);
            this.pnFooter.Controls.Add(this.pgCircular);
            this.pnFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnFooter.Location = new System.Drawing.Point(0, 420);
            this.pnFooter.Name = "pnFooter";
            this.pnFooter.Size = new System.Drawing.Size(1306, 30);
            this.pnFooter.TabIndex = 193;
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
            // pgCircular
            // 
            this.pgCircular.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pgCircular.Location = new System.Drawing.Point(1270, 2);
            this.pgCircular.Name = "pgCircular";
            this.pgCircular.Percentage = 0F;
            this.pgCircular.Rotation = CapaPresentacion.Controles.RotationType.CounterClockwise;
            this.pgCircular.Size = new System.Drawing.Size(24, 24);
            this.pgCircular.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.gbCuenta);
            this.panel1.Controls.Add(this.gbPresentacion);
            this.panel1.Controls.Add(this.btnExportar);
            this.panel1.Controls.Add(this.cboTipoServicio);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.btnBuscar);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.dtpFecha);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 75);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1306, 92);
            this.panel1.TabIndex = 194;
            // 
            // gbCuenta
            // 
            this.gbCuenta.Controls.Add(this.rbTodasCuenta);
            this.gbCuenta.Controls.Add(this.rbCuenta2);
            this.gbCuenta.Controls.Add(this.rbCuenta1);
            this.gbCuenta.Enabled = false;
            this.gbCuenta.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.gbCuenta.Location = new System.Drawing.Point(688, 12);
            this.gbCuenta.Name = "gbCuenta";
            this.gbCuenta.Size = new System.Drawing.Size(284, 61);
            this.gbCuenta.TabIndex = 357;
            this.gbCuenta.TabStop = false;
            this.gbCuenta.Text = "Cuenta";
            // 
            // rbTodasCuenta
            // 
            this.rbTodasCuenta.AutoSize = true;
            this.rbTodasCuenta.Checked = true;
            this.rbTodasCuenta.Location = new System.Drawing.Point(201, 25);
            this.rbTodasCuenta.Name = "rbTodasCuenta";
            this.rbTodasCuenta.Size = new System.Drawing.Size(62, 23);
            this.rbTodasCuenta.TabIndex = 2;
            this.rbTodasCuenta.TabStop = true;
            this.rbTodasCuenta.Text = "Todas";
            this.rbTodasCuenta.UseVisualStyleBackColor = true;
            this.rbTodasCuenta.CheckedChanged += new System.EventHandler(this.rbCuenta_CheckedChanged);
            // 
            // rbCuenta2
            // 
            this.rbCuenta2.AutoSize = true;
            this.rbCuenta2.Location = new System.Drawing.Point(108, 25);
            this.rbCuenta2.Name = "rbCuenta2";
            this.rbCuenta2.Size = new System.Drawing.Size(83, 23);
            this.rbCuenta2.TabIndex = 1;
            this.rbCuenta2.Text = "Cuenta 2";
            this.rbCuenta2.UseVisualStyleBackColor = true;
            this.rbCuenta2.CheckedChanged += new System.EventHandler(this.rbCuenta_CheckedChanged);
            // 
            // rbCuenta1
            // 
            this.rbCuenta1.AutoSize = true;
            this.rbCuenta1.Location = new System.Drawing.Point(21, 25);
            this.rbCuenta1.Name = "rbCuenta1";
            this.rbCuenta1.Size = new System.Drawing.Size(83, 23);
            this.rbCuenta1.TabIndex = 0;
            this.rbCuenta1.Text = "Cuenta 1";
            this.rbCuenta1.UseVisualStyleBackColor = true;
            this.rbCuenta1.CheckedChanged += new System.EventHandler(this.rbCuenta_CheckedChanged);
            // 
            // gbPresentacion
            // 
            this.gbPresentacion.Controls.Add(this.rbTodosUniverso);
            this.gbPresentacion.Controls.Add(this.rbEspeciales);
            this.gbPresentacion.Controls.Add(this.rbUniverso);
            this.gbPresentacion.Enabled = false;
            this.gbPresentacion.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.gbPresentacion.Location = new System.Drawing.Point(398, 12);
            this.gbPresentacion.Name = "gbPresentacion";
            this.gbPresentacion.Size = new System.Drawing.Size(284, 61);
            this.gbPresentacion.TabIndex = 356;
            this.gbPresentacion.TabStop = false;
            this.gbPresentacion.Text = "Presentacion";
            // 
            // rbTodosUniverso
            // 
            this.rbTodosUniverso.AutoSize = true;
            this.rbTodosUniverso.Checked = true;
            this.rbTodosUniverso.Location = new System.Drawing.Point(201, 25);
            this.rbTodosUniverso.Name = "rbTodosUniverso";
            this.rbTodosUniverso.Size = new System.Drawing.Size(63, 23);
            this.rbTodosUniverso.TabIndex = 2;
            this.rbTodosUniverso.TabStop = true;
            this.rbTodosUniverso.Text = "Todos";
            this.rbTodosUniverso.UseVisualStyleBackColor = true;
            this.rbTodosUniverso.CheckedChanged += new System.EventHandler(this.rbPresentacion_CheckedChanged);
            // 
            // rbEspeciales
            // 
            this.rbEspeciales.AutoSize = true;
            this.rbEspeciales.Location = new System.Drawing.Point(108, 25);
            this.rbEspeciales.Name = "rbEspeciales";
            this.rbEspeciales.Size = new System.Drawing.Size(87, 23);
            this.rbEspeciales.TabIndex = 1;
            this.rbEspeciales.Text = "Especiales";
            this.rbEspeciales.UseVisualStyleBackColor = true;
            this.rbEspeciales.CheckedChanged += new System.EventHandler(this.rbPresentacion_CheckedChanged);
            // 
            // rbUniverso
            // 
            this.rbUniverso.AutoSize = true;
            this.rbUniverso.Location = new System.Drawing.Point(21, 25);
            this.rbUniverso.Name = "rbUniverso";
            this.rbUniverso.Size = new System.Drawing.Size(81, 23);
            this.rbUniverso.TabIndex = 0;
            this.rbUniverso.Text = "Universo";
            this.rbUniverso.UseVisualStyleBackColor = true;
            this.rbUniverso.CheckedChanged += new System.EventHandler(this.rbPresentacion_CheckedChanged);
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
            this.btnExportar.Image = global::CapaPresentacion.Properties.Resources.Data_Export_32;
            this.btnExportar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExportar.Location = new System.Drawing.Point(1172, 49);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(124, 31);
            this.btnExportar.TabIndex = 355;
            this.btnExportar.Text = "Exportar";
            this.btnExportar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExportar.UseVisualStyleBackColor = false;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // cboTipoServicio
            // 
            this.cboTipoServicio.BorderColor = System.Drawing.Color.Gainsboro;
            this.cboTipoServicio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoServicio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboTipoServicio.Font = new System.Drawing.Font("Segoe UI Light", 12.25F);
            this.cboTipoServicio.FormattingEnabled = true;
            this.cboTipoServicio.Location = new System.Drawing.Point(104, 52);
            this.cboTipoServicio.Name = "cboTipoServicio";
            this.cboTipoServicio.Size = new System.Drawing.Size(197, 29);
            this.cboTipoServicio.TabIndex = 354;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(12, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 19);
            this.label3.TabIndex = 353;
            this.label3.Text = "Servicio tipo:";
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
            this.btnBuscar.Location = new System.Drawing.Point(1172, 12);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(124, 31);
            this.btnBuscar.TabIndex = 350;
            this.btnBuscar.Text = "Consultar";
            this.btnBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(12, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(146, 19);
            this.label2.TabIndex = 349;
            this.label2.Text = "Pagos adelantados de:";
            // 
            // dtpFecha
            // 
            this.dtpFecha.CustomFormat = "yyyy MMMM";
            this.dtpFecha.Font = new System.Drawing.Font("Segoe UI Light", 12.25F);
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFecha.Location = new System.Drawing.Point(160, 11);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.ShowUpDown = true;
            this.dtpFecha.Size = new System.Drawing.Size(195, 29);
            this.dtpFecha.TabIndex = 348;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 167);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1306, 1);
            this.panel2.TabIndex = 195;
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
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSlateGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv.ColumnHeadersHeight = 40;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv.EnableHeadersVisualStyles = false;
            this.dgv.GridColor = System.Drawing.Color.WhiteSmoke;
            this.dgv.Location = new System.Drawing.Point(0, 168);
            this.dgv.MultiSelect = false;
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersVisible = false;
            this.dgv.RowHeadersWidth = 50;
            this.dgv.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(1306, 252);
            this.dgv.TabIndex = 418;
            this.dgv.VirtualMode = true;
            this.dgv.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellDoubleClick);
            // 
            // lblImporteTotal
            // 
            this.lblImporteTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblImporteTotal.AutoSize = true;
            this.lblImporteTotal.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblImporteTotal.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblImporteTotal.Location = new System.Drawing.Point(1049, 8);
            this.lblImporteTotal.Name = "lblImporteTotal";
            this.lblImporteTotal.Size = new System.Drawing.Size(44, 13);
            this.lblImporteTotal.TabIndex = 14;
            this.lblImporteTotal.Text = "Total: 0";
            // 
            // frmPagosAdelantados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1306, 450);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnFooter);
            this.Controls.Add(this.panel3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "frmPagosAdelantados";
            this.Text = "frmPagosAdelantados";
            this.Load += new System.EventHandler(this.frmPagosAdelantados_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmPagosAdelantados_KeyDown);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgReturn)).EndInit();
            this.pnFooter.ResumeLayout(false);
            this.pnFooter.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.gbCuenta.ResumeLayout(false);
            this.gbCuenta.PerformLayout();
            this.gbPresentacion.ResumeLayout(false);
            this.gbPresentacion.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox imgReturn;
        private System.Windows.Forms.Label lblTituloHeader;
        private System.Windows.Forms.Panel pnFooter;
        private System.Windows.Forms.Label lblTotal;
        private Controles.progress pgCircular;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Label label2;
        private Controles.boton btnBuscar;
        private Controles.dgv dgv;
        private Controles.combo cboTipoServicio;
        private System.Windows.Forms.Label label3;
        private Controles.boton btnExportar;
        private System.Windows.Forms.GroupBox gbPresentacion;
        private System.Windows.Forms.RadioButton rbTodosUniverso;
        private System.Windows.Forms.RadioButton rbEspeciales;
        private System.Windows.Forms.RadioButton rbUniverso;
        private System.Windows.Forms.GroupBox gbCuenta;
        private System.Windows.Forms.RadioButton rbTodasCuenta;
        private System.Windows.Forms.RadioButton rbCuenta2;
        private System.Windows.Forms.RadioButton rbCuenta1;
        private System.Windows.Forms.Label lblImporteTotal;
    }
}