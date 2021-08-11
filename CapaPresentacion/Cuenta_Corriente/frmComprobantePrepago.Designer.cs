namespace CapaPresentacion
{
    partial class frmComprobantePrepago
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
            this.lblDesde = new System.Windows.Forms.Label();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.lblHasta = new System.Windows.Forms.Label();
            this.dpHasta = new System.Windows.Forms.DateTimePicker();
            this.lblDias = new System.Windows.Forms.Label();
            this.lblImporte = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblDescuentoDato = new System.Windows.Forms.Label();
            this.lblImporteDato = new System.Windows.Forms.Label();
            this.pnlSubServicios = new System.Windows.Forms.Panel();
            this.pnlBotones = new System.Windows.Forms.Panel();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.chkPosdatado = new System.Windows.Forms.CheckBox();
            this.pnlInferior = new System.Windows.Forms.Panel();
            this.lblServicio = new System.Windows.Forms.Label();
            this.pnlInfoServicio = new System.Windows.Forms.Panel();
            this.imgReturn = new System.Windows.Forms.PictureBox();
            this.LbTitulos = new System.Windows.Forms.Label();
            this.pnHead = new System.Windows.Forms.Panel();
            this.lblCantDiasAnteriores = new System.Windows.Forms.Label();
            this.dgvSub = new CapaPresentacion.Controles.dgv(this.components);
            this.spCantDias = new CapaPresentacion.Controles.spinner(this.components);
            this.btnGuardar = new CapaPresentacion.Controles.boton();
            this.pnlSubServicios.SuspendLayout();
            this.pnlBotones.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.pnlInferior.SuspendLayout();
            this.pnlInfoServicio.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgReturn)).BeginInit();
            this.pnHead.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSub)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spCantDias)).BeginInit();
            this.SuspendLayout();
            // 
            // lblDesde
            // 
            this.lblDesde.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDesde.ForeColor = System.Drawing.Color.Black;
            this.lblDesde.Location = new System.Drawing.Point(8, 76);
            this.lblDesde.Name = "lblDesde";
            this.lblDesde.Size = new System.Drawing.Size(60, 21);
            this.lblDesde.TabIndex = 177;
            this.lblDesde.Text = "Desde";
            this.lblDesde.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtpDesde
            // 
            this.dtpDesde.Checked = false;
            this.dtpDesde.CustomFormat = "";
            this.dtpDesde.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDesde.Location = new System.Drawing.Point(74, 72);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(113, 30);
            this.dtpDesde.TabIndex = 178;
            this.dtpDesde.ValueChanged += new System.EventHandler(this.dtpDesde_ValueChanged);
            // 
            // lblHasta
            // 
            this.lblHasta.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHasta.ForeColor = System.Drawing.Color.Black;
            this.lblHasta.Location = new System.Drawing.Point(188, 76);
            this.lblHasta.Name = "lblHasta";
            this.lblHasta.Size = new System.Drawing.Size(66, 21);
            this.lblHasta.TabIndex = 179;
            this.lblHasta.Text = "Hasta";
            this.lblHasta.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dpHasta
            // 
            this.dpHasta.Checked = false;
            this.dpHasta.CustomFormat = "";
            this.dpHasta.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpHasta.Location = new System.Drawing.Point(260, 72);
            this.dpHasta.Name = "dpHasta";
            this.dpHasta.Size = new System.Drawing.Size(113, 30);
            this.dpHasta.TabIndex = 180;
            this.dpHasta.ValueChanged += new System.EventHandler(this.dpHasta_ValueChanged);
            // 
            // lblDias
            // 
            this.lblDias.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDias.ForeColor = System.Drawing.Color.Black;
            this.lblDias.Location = new System.Drawing.Point(8, 39);
            this.lblDias.Name = "lblDias";
            this.lblDias.Size = new System.Drawing.Size(233, 21);
            this.lblDias.TabIndex = 181;
            this.lblDias.Text = "Cantidad de días a contratar";
            this.lblDias.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblImporte
            // 
            this.lblImporte.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblImporte.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.lblImporte.ForeColor = System.Drawing.Color.White;
            this.lblImporte.Location = new System.Drawing.Point(348, 27);
            this.lblImporte.Name = "lblImporte";
            this.lblImporte.Size = new System.Drawing.Size(88, 32);
            this.lblImporte.TabIndex = 182;
            this.lblImporte.Text = "Importe $";
            this.lblImporte.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(334, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 21);
            this.label1.TabIndex = 183;
            this.label1.Text = "Descuento %";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDescuentoDato
            // 
            this.lblDescuentoDato.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDescuentoDato.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.lblDescuentoDato.ForeColor = System.Drawing.Color.White;
            this.lblDescuentoDato.Location = new System.Drawing.Point(445, 3);
            this.lblDescuentoDato.Name = "lblDescuentoDato";
            this.lblDescuentoDato.Size = new System.Drawing.Size(127, 24);
            this.lblDescuentoDato.TabIndex = 186;
            this.lblDescuentoDato.Text = "Descuento %";
            this.lblDescuentoDato.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblImporteDato
            // 
            this.lblImporteDato.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblImporteDato.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.lblImporteDato.ForeColor = System.Drawing.Color.White;
            this.lblImporteDato.Location = new System.Drawing.Point(445, 27);
            this.lblImporteDato.Name = "lblImporteDato";
            this.lblImporteDato.Size = new System.Drawing.Size(108, 26);
            this.lblImporteDato.TabIndex = 185;
            this.lblImporteDato.Text = "Importe";
            this.lblImporteDato.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlSubServicios
            // 
            this.pnlSubServicios.Controls.Add(this.dgvSub);
            this.pnlSubServicios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSubServicios.Location = new System.Drawing.Point(0, 220);
            this.pnlSubServicios.Name = "pnlSubServicios";
            this.pnlSubServicios.Size = new System.Drawing.Size(617, 194);
            this.pnlSubServicios.TabIndex = 188;
            // 
            // pnlBotones
            // 
            this.pnlBotones.Controls.Add(this.btnGuardar);
            this.pnlBotones.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBotones.Location = new System.Drawing.Point(0, 414);
            this.pnlBotones.Name = "pnlBotones";
            this.pnlBotones.Size = new System.Drawing.Size(617, 43);
            this.pnlBotones.TabIndex = 189;
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.lblCantDiasAnteriores);
            this.pnlMain.Controls.Add(this.spCantDias);
            this.pnlMain.Controls.Add(this.chkPosdatado);
            this.pnlMain.Controls.Add(this.lblDias);
            this.pnlMain.Controls.Add(this.dtpDesde);
            this.pnlMain.Controls.Add(this.lblDesde);
            this.pnlMain.Controls.Add(this.dpHasta);
            this.pnlMain.Controls.Add(this.lblHasta);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMain.Location = new System.Drawing.Point(0, 112);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(617, 108);
            this.pnlMain.TabIndex = 190;
            // 
            // chkPosdatado
            // 
            this.chkPosdatado.AutoSize = true;
            this.chkPosdatado.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.chkPosdatado.Location = new System.Drawing.Point(455, 76);
            this.chkPosdatado.Name = "chkPosdatado";
            this.chkPosdatado.Size = new System.Drawing.Size(159, 29);
            this.chkPosdatado.TabIndex = 3;
            this.chkPosdatado.Text = "Con notificación";
            this.chkPosdatado.UseVisualStyleBackColor = true;
            // 
            // pnlInferior
            // 
            this.pnlInferior.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.pnlInferior.Controls.Add(this.lblDescuentoDato);
            this.pnlInferior.Controls.Add(this.lblImporte);
            this.pnlInferior.Controls.Add(this.label1);
            this.pnlInferior.Controls.Add(this.lblImporteDato);
            this.pnlInferior.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlInferior.Location = new System.Drawing.Point(0, 457);
            this.pnlInferior.Name = "pnlInferior";
            this.pnlInferior.Size = new System.Drawing.Size(617, 65);
            this.pnlInferior.TabIndex = 191;
            // 
            // lblServicio
            // 
            this.lblServicio.AutoSize = true;
            this.lblServicio.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.lblServicio.ForeColor = System.Drawing.Color.Black;
            this.lblServicio.Location = new System.Drawing.Point(12, 5);
            this.lblServicio.Name = "lblServicio";
            this.lblServicio.Size = new System.Drawing.Size(73, 25);
            this.lblServicio.TabIndex = 185;
            this.lblServicio.Text = "Servicio";
            this.lblServicio.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlInfoServicio
            // 
            this.pnlInfoServicio.Controls.Add(this.lblServicio);
            this.pnlInfoServicio.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlInfoServicio.Location = new System.Drawing.Point(0, 77);
            this.pnlInfoServicio.Name = "pnlInfoServicio";
            this.pnlInfoServicio.Size = new System.Drawing.Size(617, 35);
            this.pnlInfoServicio.TabIndex = 192;
            // 
            // imgReturn
            // 
            this.imgReturn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.imgReturn.Image = global::CapaPresentacion.Properties.Resources.Left_Arrow_32;
            this.imgReturn.Location = new System.Drawing.Point(11, 26);
            this.imgReturn.Name = "imgReturn";
            this.imgReturn.Size = new System.Drawing.Size(32, 32);
            this.imgReturn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgReturn.TabIndex = 76;
            this.imgReturn.TabStop = false;
            this.imgReturn.Click += new System.EventHandler(this.imgReturn_Click);
            // 
            // LbTitulos
            // 
            this.LbTitulos.AutoSize = true;
            this.LbTitulos.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.LbTitulos.ForeColor = System.Drawing.Color.Transparent;
            this.LbTitulos.Location = new System.Drawing.Point(49, 26);
            this.LbTitulos.Name = "LbTitulos";
            this.LbTitulos.Size = new System.Drawing.Size(178, 30);
            this.LbTitulos.TabIndex = 172;
            this.LbTitulos.Text = "Servicio prepago";
            // 
            // pnHead
            // 
            this.pnHead.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.pnHead.Controls.Add(this.LbTitulos);
            this.pnHead.Controls.Add(this.imgReturn);
            this.pnHead.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnHead.Location = new System.Drawing.Point(0, 0);
            this.pnHead.Name = "pnHead";
            this.pnHead.Size = new System.Drawing.Size(617, 77);
            this.pnHead.TabIndex = 168;
            // 
            // lblCantDiasAnteriores
            // 
            this.lblCantDiasAnteriores.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCantDiasAnteriores.ForeColor = System.Drawing.Color.Black;
            this.lblCantDiasAnteriores.Location = new System.Drawing.Point(8, 3);
            this.lblCantDiasAnteriores.Name = "lblCantDiasAnteriores";
            this.lblCantDiasAnteriores.Size = new System.Drawing.Size(332, 21);
            this.lblCantDiasAnteriores.TabIndex = 186;
            this.lblCantDiasAnteriores.Text = "Cant. días de la última contratación";
            this.lblCantDiasAnteriores.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblCantDiasAnteriores.Visible = false;
            // 
            // dgvSub
            // 
            this.dgvSub.AllowUserToAddRows = false;
            this.dgvSub.AllowUserToDeleteRows = false;
            this.dgvSub.AllowUserToOrderColumns = true;
            this.dgvSub.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSub.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSub.BackgroundColor = System.Drawing.Color.White;
            this.dgvSub.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvSub.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSlateGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSub.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvSub.ColumnHeadersHeight = 40;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSub.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvSub.Enabled = false;
            this.dgvSub.EnableHeadersVisualStyles = false;
            this.dgvSub.GridColor = System.Drawing.Color.WhiteSmoke;
            this.dgvSub.Location = new System.Drawing.Point(11, 9);
            this.dgvSub.MultiSelect = false;
            this.dgvSub.Name = "dgvSub";
            this.dgvSub.ReadOnly = true;
            this.dgvSub.RowHeadersVisible = false;
            this.dgvSub.RowHeadersWidth = 50;
            this.dgvSub.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvSub.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSub.Size = new System.Drawing.Size(594, 182);
            this.dgvSub.TabIndex = 187;
            this.dgvSub.SelectionChanged += new System.EventHandler(this.dgvSub_SelectionChanged);
            // 
            // spCantDias
            // 
            this.spCantDias.BorderColor = System.Drawing.Color.Empty;
            this.spCantDias.Font = new System.Drawing.Font("Segoe UI", 12.75F);
            this.spCantDias.Location = new System.Drawing.Point(236, 36);
            this.spCantDias.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spCantDias.Name = "spCantDias";
            this.spCantDias.Size = new System.Drawing.Size(137, 30);
            this.spCantDias.TabIndex = 185;
            this.spCantDias.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.spCantDias.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.spCantDias.ValueChanged += new System.EventHandler(this.spCantDias_ValueChanged);
            this.spCantDias.Enter += new System.EventHandler(this.spCantDias_Enter);
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
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Image = global::CapaPresentacion.Properties.Resources.Save_32;
            this.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGuardar.Location = new System.Drawing.Point(486, 6);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(119, 33);
            this.btnGuardar.TabIndex = 2;
            this.btnGuardar.Text = "Aceptar";
            this.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // frmComprobantePrepago
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(250)))), ((int)(((byte)(251)))));
            this.ClientSize = new System.Drawing.Size(617, 522);
            this.Controls.Add(this.pnlSubServicios);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlInfoServicio);
            this.Controls.Add(this.pnlBotones);
            this.Controls.Add(this.pnHead);
            this.Controls.Add(this.pnlInferior);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "frmComprobantePrepago";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmGeneraComprobantesManual";
            this.Load += new System.EventHandler(this.frmComprobantePrepago_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmComprobantePrepago_KeyDown);
            this.pnlSubServicios.ResumeLayout(false);
            this.pnlBotones.ResumeLayout(false);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.pnlInferior.ResumeLayout(false);
            this.pnlInfoServicio.ResumeLayout(false);
            this.pnlInfoServicio.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgReturn)).EndInit();
            this.pnHead.ResumeLayout(false);
            this.pnHead.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSub)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spCantDias)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Controles.boton btnGuardar;
        private System.Windows.Forms.Label lblDesde;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.Label lblHasta;
        private System.Windows.Forms.DateTimePicker dpHasta;
        private System.Windows.Forms.Label lblDias;
        private System.Windows.Forms.Label lblImporte;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblDescuentoDato;
        private System.Windows.Forms.Label lblImporteDato;
        private Controles.dgv dgvSub;
        private System.Windows.Forms.Panel pnlSubServicios;
        private System.Windows.Forms.Panel pnlBotones;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlInferior;
        private System.Windows.Forms.CheckBox chkPosdatado;
        private System.Windows.Forms.Label lblServicio;
        private System.Windows.Forms.Panel pnlInfoServicio;
        private System.Windows.Forms.PictureBox imgReturn;
        private System.Windows.Forms.Label LbTitulos;
        private System.Windows.Forms.Panel pnHead;
        private Controles.spinner spCantDias;
        private System.Windows.Forms.Label lblCantDiasAnteriores;
    }
}