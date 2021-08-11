namespace CapaPresentacion.Abms
{
    partial class ABMImpresiones
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
            this.lblPuntoDeCobro = new System.Windows.Forms.Label();
            this.cmbPuntoCobro = new System.Windows.Forms.ComboBox();
            this.cntDatos = new System.Windows.Forms.Panel();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.imgReturn = new System.Windows.Forms.PictureBox();
            this.pnLine = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblTituloHeader = new System.Windows.Forms.Label();
            this.dgvComprobantesTipo = new CapaPresentacion.Controles.dgv(this.components);
            this.cboPersonal = new CapaPresentacion.Controles.combo(this.components);
            this.btnCancela = new CapaPresentacion.Controles.boton();
            this.btnConfirma = new CapaPresentacion.Controles.boton();
            this.btnElimina = new CapaPresentacion.Controles.boton();
            this.btnNuevo = new CapaPresentacion.Controles.boton();
            this.dgvImpresiones = new CapaPresentacion.Controles.dgv(this.components);
            this.cntDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgReturn)).BeginInit();
            this.pnLine.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvComprobantesTipo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvImpresiones)).BeginInit();
            this.SuspendLayout();
            // 
            // lblPuntoDeCobro
            // 
            this.lblPuntoDeCobro.AutoSize = true;
            this.lblPuntoDeCobro.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPuntoDeCobro.ForeColor = System.Drawing.SystemColors.GrayText;
            this.lblPuntoDeCobro.Location = new System.Drawing.Point(15, 89);
            this.lblPuntoDeCobro.Name = "lblPuntoDeCobro";
            this.lblPuntoDeCobro.Size = new System.Drawing.Size(122, 21);
            this.lblPuntoDeCobro.TabIndex = 1;
            this.lblPuntoDeCobro.Text = "Punto de Cobro:";
            // 
            // cmbPuntoCobro
            // 
            this.cmbPuntoCobro.FormattingEnabled = true;
            this.cmbPuntoCobro.Location = new System.Drawing.Point(150, 89);
            this.cmbPuntoCobro.Name = "cmbPuntoCobro";
            this.cmbPuntoCobro.Size = new System.Drawing.Size(221, 21);
            this.cmbPuntoCobro.TabIndex = 2;
            this.cmbPuntoCobro.SelectedIndexChanged += new System.EventHandler(this.cmbPuntoCobro_SelectedIndexChanged);
            // 
            // cntDatos
            // 
            this.cntDatos.Controls.Add(this.dgvComprobantesTipo);
            this.cntDatos.Controls.Add(this.lblBuscar);
            this.cntDatos.Controls.Add(this.cboPersonal);
            this.cntDatos.Controls.Add(this.btnCancela);
            this.cntDatos.Controls.Add(this.btnConfirma);
            this.cntDatos.Location = new System.Drawing.Point(19, 169);
            this.cntDatos.Name = "cntDatos";
            this.cntDatos.Size = new System.Drawing.Size(937, 361);
            this.cntDatos.TabIndex = 8;
            this.cntDatos.Visible = false;
            // 
            // lblBuscar
            // 
            this.lblBuscar.AutoSize = true;
            this.lblBuscar.Font = new System.Drawing.Font("Segoe UI Light", 12F);
            this.lblBuscar.ForeColor = System.Drawing.Color.SlateGray;
            this.lblBuscar.Location = new System.Drawing.Point(3, 18);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Size = new System.Drawing.Size(88, 21);
            this.lblBuscar.TabIndex = 25;
            this.lblBuscar.Text = "PERSONAL:";
            // 
            // imgReturn
            // 
            this.imgReturn.BackColor = System.Drawing.SystemColors.HotTrack;
            this.imgReturn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.imgReturn.Image = global::CapaPresentacion.Properties.Resources.Left_Arrow_32;
            this.imgReturn.Location = new System.Drawing.Point(12, 12);
            this.imgReturn.Name = "imgReturn";
            this.imgReturn.Size = new System.Drawing.Size(32, 32);
            this.imgReturn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgReturn.TabIndex = 33;
            this.imgReturn.TabStop = false;
            // 
            // pnLine
            // 
            this.pnLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.pnLine.Controls.Add(this.pictureBox1);
            this.pnLine.Controls.Add(this.lblTituloHeader);
            this.pnLine.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnLine.Location = new System.Drawing.Point(0, 0);
            this.pnLine.Name = "pnLine";
            this.pnLine.Size = new System.Drawing.Size(994, 75);
            this.pnLine.TabIndex = 34;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = global::CapaPresentacion.Properties.Resources.Left_Arrow_32;
            this.pictureBox1.Location = new System.Drawing.Point(15, 22);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 32;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // lblTituloHeader
            // 
            this.lblTituloHeader.Font = new System.Drawing.Font("Segoe UI Light", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloHeader.ForeColor = System.Drawing.Color.White;
            this.lblTituloHeader.Location = new System.Drawing.Point(53, 27);
            this.lblTituloHeader.Name = "lblTituloHeader";
            this.lblTituloHeader.Size = new System.Drawing.Size(338, 23);
            this.lblTituloHeader.TabIndex = 31;
            this.lblTituloHeader.Text = "Impresiones";
            // 
            // dgvComprobantesTipo
            // 
            this.dgvComprobantesTipo.AllowUserToAddRows = false;
            this.dgvComprobantesTipo.AllowUserToDeleteRows = false;
            this.dgvComprobantesTipo.AllowUserToOrderColumns = true;
            this.dgvComprobantesTipo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvComprobantesTipo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvComprobantesTipo.BackgroundColor = System.Drawing.Color.White;
            this.dgvComprobantesTipo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvComprobantesTipo.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSlateGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvComprobantesTipo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvComprobantesTipo.ColumnHeadersHeight = 40;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvComprobantesTipo.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvComprobantesTipo.EnableHeadersVisualStyles = false;
            this.dgvComprobantesTipo.GridColor = System.Drawing.Color.WhiteSmoke;
            this.dgvComprobantesTipo.Location = new System.Drawing.Point(7, 64);
            this.dgvComprobantesTipo.MultiSelect = false;
            this.dgvComprobantesTipo.Name = "dgvComprobantesTipo";
            this.dgvComprobantesTipo.ReadOnly = true;
            this.dgvComprobantesTipo.RowHeadersVisible = false;
            this.dgvComprobantesTipo.RowHeadersWidth = 50;
            this.dgvComprobantesTipo.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvComprobantesTipo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvComprobantesTipo.Size = new System.Drawing.Size(813, 283);
            this.dgvComprobantesTipo.TabIndex = 26;
            this.dgvComprobantesTipo.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvComprobantesTipo_CellMouseClick);
            // 
            // cboPersonal
            // 
            this.cboPersonal.BorderColor = System.Drawing.Color.Gainsboro;
            this.cboPersonal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPersonal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboPersonal.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboPersonal.FormattingEnabled = true;
            this.cboPersonal.Location = new System.Drawing.Point(104, 15);
            this.cboPersonal.Name = "cboPersonal";
            this.cboPersonal.Size = new System.Drawing.Size(490, 29);
            this.cboPersonal.TabIndex = 24;
            this.cboPersonal.SelectedIndexChanged += new System.EventHandler(this.cboPersonal_SelectedIndexChanged);
            // 
            // btnCancela
            // 
            this.btnCancela.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancela.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnCancela.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancela.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnCancela.FlatAppearance.BorderSize = 0;
            this.btnCancela.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnCancela.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnCancela.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancela.Font = new System.Drawing.Font("Segoe UI Light", 12F);
            this.btnCancela.ForeColor = System.Drawing.Color.White;
            this.btnCancela.Image = global::CapaPresentacion.Properties.Resources.Data_Add_32;
            this.btnCancela.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancela.Location = new System.Drawing.Point(826, 313);
            this.btnCancela.Name = "btnCancela";
            this.btnCancela.Size = new System.Drawing.Size(108, 34);
            this.btnCancela.TabIndex = 7;
            this.btnCancela.Text = "Cancela";
            this.btnCancela.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancela.UseVisualStyleBackColor = false;
            this.btnCancela.Click += new System.EventHandler(this.btnCancela_Click);
            // 
            // btnConfirma
            // 
            this.btnConfirma.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConfirma.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnConfirma.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConfirma.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnConfirma.FlatAppearance.BorderSize = 0;
            this.btnConfirma.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnConfirma.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnConfirma.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirma.Font = new System.Drawing.Font("Segoe UI Light", 12F);
            this.btnConfirma.ForeColor = System.Drawing.Color.White;
            this.btnConfirma.Image = global::CapaPresentacion.Properties.Resources.Data_Add_32;
            this.btnConfirma.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnConfirma.Location = new System.Drawing.Point(826, 273);
            this.btnConfirma.Name = "btnConfirma";
            this.btnConfirma.Size = new System.Drawing.Size(108, 34);
            this.btnConfirma.TabIndex = 6;
            this.btnConfirma.Text = "Confirma";
            this.btnConfirma.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConfirma.UseVisualStyleBackColor = false;
            this.btnConfirma.Click += new System.EventHandler(this.btnConfirma_Click);
            // 
            // btnElimina
            // 
            this.btnElimina.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnElimina.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnElimina.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnElimina.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnElimina.FlatAppearance.BorderSize = 0;
            this.btnElimina.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnElimina.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnElimina.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnElimina.Font = new System.Drawing.Font("Segoe UI Light", 12F);
            this.btnElimina.ForeColor = System.Drawing.Color.White;
            this.btnElimina.Image = global::CapaPresentacion.Properties.Resources.Data_Add_32;
            this.btnElimina.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnElimina.Location = new System.Drawing.Point(874, 81);
            this.btnElimina.Name = "btnElimina";
            this.btnElimina.Size = new System.Drawing.Size(108, 34);
            this.btnElimina.TabIndex = 6;
            this.btnElimina.Text = "Eliminar";
            this.btnElimina.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnElimina.UseVisualStyleBackColor = false;
            this.btnElimina.Click += new System.EventHandler(this.btnElimina_Click);
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
            this.btnNuevo.Font = new System.Drawing.Font("Segoe UI Light", 12F);
            this.btnNuevo.ForeColor = System.Drawing.Color.White;
            this.btnNuevo.Image = global::CapaPresentacion.Properties.Resources.Data_Add_32;
            this.btnNuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNuevo.Location = new System.Drawing.Point(748, 82);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(120, 34);
            this.btnNuevo.TabIndex = 5;
            this.btnNuevo.Text = "Impresiones";
            this.btnNuevo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNuevo.UseVisualStyleBackColor = false;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // dgvImpresiones
            // 
            this.dgvImpresiones.AllowUserToAddRows = false;
            this.dgvImpresiones.AllowUserToDeleteRows = false;
            this.dgvImpresiones.AllowUserToOrderColumns = true;
            this.dgvImpresiones.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvImpresiones.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvImpresiones.BackgroundColor = System.Drawing.Color.White;
            this.dgvImpresiones.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvImpresiones.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.LightSlateGray;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvImpresiones.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvImpresiones.ColumnHeadersHeight = 40;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvImpresiones.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvImpresiones.EnableHeadersVisualStyles = false;
            this.dgvImpresiones.GridColor = System.Drawing.Color.WhiteSmoke;
            this.dgvImpresiones.Location = new System.Drawing.Point(12, 144);
            this.dgvImpresiones.MultiSelect = false;
            this.dgvImpresiones.Name = "dgvImpresiones";
            this.dgvImpresiones.ReadOnly = true;
            this.dgvImpresiones.RowHeadersVisible = false;
            this.dgvImpresiones.RowHeadersWidth = 50;
            this.dgvImpresiones.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvImpresiones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvImpresiones.Size = new System.Drawing.Size(957, 408);
            this.dgvImpresiones.TabIndex = 3;
            // 
            // ABMImpresiones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(994, 564);
            this.Controls.Add(this.pnLine);
            this.Controls.Add(this.imgReturn);
            this.Controls.Add(this.cntDatos);
            this.Controls.Add(this.btnElimina);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.dgvImpresiones);
            this.Controls.Add(this.cmbPuntoCobro);
            this.Controls.Add(this.lblPuntoDeCobro);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ABMImpresiones";
            this.Text = "ABMImpresiones";
            this.Load += new System.EventHandler(this.ABMImpresiones_Load);
            this.cntDatos.ResumeLayout(false);
            this.cntDatos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgReturn)).EndInit();
            this.pnLine.ResumeLayout(false);
            this.pnLine.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvComprobantesTipo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvImpresiones)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblPuntoDeCobro;
        private System.Windows.Forms.ComboBox cmbPuntoCobro;
        private Controles.dgv dgvImpresiones;
        private Controles.boton btnNuevo;
        private Controles.boton btnElimina;
        private System.Windows.Forms.Panel cntDatos;
        private Controles.boton btnConfirma;
        private Controles.boton btnCancela;
        private Controles.combo cboPersonal;
        private System.Windows.Forms.Label lblBuscar;
        private Controles.dgv dgvComprobantesTipo;
        private System.Windows.Forms.PictureBox imgReturn;
        private System.Windows.Forms.Panel pnLine;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblTituloHeader;
    }
}