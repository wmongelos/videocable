namespace CapaPresentacion.Cuenta_Corriente
{
    partial class frmComprobantePeriodoCerrado
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
            this.panel3 = new System.Windows.Forms.Panel();
            this.imgReturn = new System.Windows.Forms.PictureBox();
            this.lblTituloHeader = new System.Windows.Forms.Label();
            this.dgvPaquetes = new CapaPresentacion.Controles.dgv(this.components);
            this.lblModalidadDeServicio = new System.Windows.Forms.Label();
            this.lblServicio = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAsignar = new CapaPresentacion.Controles.boton();
            this.pgCircular = new CapaPresentacion.Controles.progress();
            this.lblContratarFecha = new System.Windows.Forms.Label();
            this.chkExtender = new System.Windows.Forms.CheckBox();
            this.dtpFechaContratacion = new System.Windows.Forms.DateTimePicker();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgReturn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPaquetes)).BeginInit();
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
            this.panel3.Size = new System.Drawing.Size(676, 80);
            this.panel3.TabIndex = 48;
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
            this.lblTituloHeader.Text = "Servicio de periodo cerrado";
            // 
            // dgvPaquetes
            // 
            this.dgvPaquetes.AllowUserToAddRows = false;
            this.dgvPaquetes.AllowUserToDeleteRows = false;
            this.dgvPaquetes.AllowUserToOrderColumns = true;
            this.dgvPaquetes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPaquetes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPaquetes.BackgroundColor = System.Drawing.Color.White;
            this.dgvPaquetes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvPaquetes.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSlateGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 12F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPaquetes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPaquetes.ColumnHeadersHeight = 40;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 12F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPaquetes.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvPaquetes.EnableHeadersVisualStyles = false;
            this.dgvPaquetes.GridColor = System.Drawing.Color.WhiteSmoke;
            this.dgvPaquetes.Location = new System.Drawing.Point(16, 152);
            this.dgvPaquetes.MultiSelect = false;
            this.dgvPaquetes.Name = "dgvPaquetes";
            this.dgvPaquetes.ReadOnly = true;
            this.dgvPaquetes.RowHeadersVisible = false;
            this.dgvPaquetes.RowHeadersWidth = 50;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPaquetes.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvPaquetes.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvPaquetes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPaquetes.Size = new System.Drawing.Size(649, 185);
            this.dgvPaquetes.TabIndex = 342;
            // 
            // lblModalidadDeServicio
            // 
            this.lblModalidadDeServicio.AutoSize = true;
            this.lblModalidadDeServicio.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblModalidadDeServicio.ForeColor = System.Drawing.Color.Black;
            this.lblModalidadDeServicio.Location = new System.Drawing.Point(12, 104);
            this.lblModalidadDeServicio.Name = "lblModalidadDeServicio";
            this.lblModalidadDeServicio.Size = new System.Drawing.Size(165, 21);
            this.lblModalidadDeServicio.TabIndex = 343;
            this.lblModalidadDeServicio.Text = "Modalidad de servicio:";
            // 
            // lblServicio
            // 
            this.lblServicio.AutoSize = true;
            this.lblServicio.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblServicio.ForeColor = System.Drawing.Color.Black;
            this.lblServicio.Location = new System.Drawing.Point(12, 83);
            this.lblServicio.Name = "lblServicio";
            this.lblServicio.Size = new System.Drawing.Size(68, 21);
            this.lblServicio.TabIndex = 344;
            this.lblServicio.Text = "Servicio:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(11, 125);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(303, 21);
            this.label2.TabIndex = 345;
            this.label2.Text = "Seleccione el paquete que desea contratar:";
            // 
            // btnAsignar
            // 
            this.btnAsignar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAsignar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnAsignar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAsignar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnAsignar.FlatAppearance.BorderSize = 0;
            this.btnAsignar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnAsignar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnAsignar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAsignar.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAsignar.ForeColor = System.Drawing.Color.White;
            this.btnAsignar.Image = global::CapaPresentacion.Properties.Resources.Data_Add_32;
            this.btnAsignar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAsignar.Location = new System.Drawing.Point(568, 86);
            this.btnAsignar.Name = "btnAsignar";
            this.btnAsignar.Size = new System.Drawing.Size(96, 35);
            this.btnAsignar.TabIndex = 346;
            this.btnAsignar.Text = "Asignar";
            this.btnAsignar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAsignar.UseVisualStyleBackColor = false;
            this.btnAsignar.Click += new System.EventHandler(this.btnAsignar_Click);
            // 
            // pgCircular
            // 
            this.pgCircular.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pgCircular.Location = new System.Drawing.Point(640, 381);
            this.pgCircular.Name = "pgCircular";
            this.pgCircular.Percentage = 0F;
            this.pgCircular.Rotation = CapaPresentacion.Controles.RotationType.CounterClockwise;
            this.pgCircular.Size = new System.Drawing.Size(24, 24);
            this.pgCircular.TabIndex = 347;
            // 
            // lblContratarFecha
            // 
            this.lblContratarFecha.AutoSize = true;
            this.lblContratarFecha.Enabled = false;
            this.lblContratarFecha.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContratarFecha.ForeColor = System.Drawing.Color.Black;
            this.lblContratarFecha.Location = new System.Drawing.Point(12, 377);
            this.lblContratarFecha.Name = "lblContratarFecha";
            this.lblContratarFecha.Size = new System.Drawing.Size(211, 21);
            this.lblContratarFecha.TabIndex = 349;
            this.lblContratarFecha.Text = "Contratar a partir de la fecha:";
            // 
            // chkExtender
            // 
            this.chkExtender.AutoSize = true;
            this.chkExtender.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.chkExtender.Location = new System.Drawing.Point(16, 343);
            this.chkExtender.Name = "chkExtender";
            this.chkExtender.Size = new System.Drawing.Size(350, 25);
            this.chkExtender.TabIndex = 350;
            this.chkExtender.Text = "Extender desde la última fecha de contratación";
            this.chkExtender.UseVisualStyleBackColor = true;
            this.chkExtender.CheckedChanged += new System.EventHandler(this.chkExtender_CheckedChanged);
            // 
            // dtpFechaContratacion
            // 
            this.dtpFechaContratacion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpFechaContratacion.CustomFormat = "dd/MM/yyyy";
            this.dtpFechaContratacion.Enabled = false;
            this.dtpFechaContratacion.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.dtpFechaContratacion.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFechaContratacion.Location = new System.Drawing.Point(228, 371);
            this.dtpFechaContratacion.Name = "dtpFechaContratacion";
            this.dtpFechaContratacion.Size = new System.Drawing.Size(127, 29);
            this.dtpFechaContratacion.TabIndex = 351;
            this.dtpFechaContratacion.ValueChanged += new System.EventHandler(this.dtpFechaContratacion_ValueChanged);
            // 
            // frmComprobantePeriodoCerrado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(250)))), ((int)(((byte)(251)))));
            this.ClientSize = new System.Drawing.Size(676, 408);
            this.Controls.Add(this.dtpFechaContratacion);
            this.Controls.Add(this.chkExtender);
            this.Controls.Add(this.lblContratarFecha);
            this.Controls.Add(this.pgCircular);
            this.Controls.Add(this.btnAsignar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblServicio);
            this.Controls.Add(this.lblModalidadDeServicio);
            this.Controls.Add(this.dgvPaquetes);
            this.Controls.Add(this.panel3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmComprobantePeriodoCerrado";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmComprobantePeriodoCerrado";
            this.Load += new System.EventHandler(this.frmComprobantePeriodoCerrado_Load);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgReturn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPaquetes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox imgReturn;
        private System.Windows.Forms.Label lblTituloHeader;
        private Controles.dgv dgvPaquetes;
        private System.Windows.Forms.Label lblModalidadDeServicio;
        private System.Windows.Forms.Label lblServicio;
        private System.Windows.Forms.Label label2;
        private Controles.boton btnAsignar;
        private Controles.progress pgCircular;
        private System.Windows.Forms.Label lblContratarFecha;
        private System.Windows.Forms.CheckBox chkExtender;
        private System.Windows.Forms.DateTimePicker dtpFechaContratacion;
    }
}