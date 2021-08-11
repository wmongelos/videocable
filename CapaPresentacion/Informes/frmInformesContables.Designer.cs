namespace CapaPresentacion.Contabilidad
{
    partial class frmInformesContables
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
            this.pnHeader = new System.Windows.Forms.Panel();
            this.imgReturn = new System.Windows.Forms.PictureBox();
            this.lblTituloHeader = new System.Windows.Forms.Label();
            this.gestorTabs = new System.Windows.Forms.TabControl();
            this.infLibroIvaA = new System.Windows.Forms.TabPage();
            this.btnBuscar = new CapaPresentacion.Controles.boton();
            this.btnExportar = new CapaPresentacion.Controles.boton();
            this.lblTotalesLibroIvaA = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpFechaHastaLibroIvaA = new System.Windows.Forms.DateTimePicker();
            this.lblY = new System.Windows.Forms.Label();
            this.dtpFechaDesdeLibroIvaA = new System.Windows.Forms.DateTimePicker();
            this.dgvLibroIvaA = new CapaPresentacion.Controles.dgv(this.components);
            this.infLibroIvaB = new System.Windows.Forms.TabPage();
            this.pgCircular = new CapaPresentacion.Controles.progress();
            this.pnHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgReturn)).BeginInit();
            this.gestorTabs.SuspendLayout();
            this.infLibroIvaA.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLibroIvaA)).BeginInit();
            this.SuspendLayout();
            // 
            // pnHeader
            // 
            this.pnHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.pnHeader.Controls.Add(this.imgReturn);
            this.pnHeader.Controls.Add(this.lblTituloHeader);
            this.pnHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnHeader.Location = new System.Drawing.Point(0, 0);
            this.pnHeader.Name = "pnHeader";
            this.pnHeader.Size = new System.Drawing.Size(1007, 75);
            this.pnHeader.TabIndex = 49;
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
            this.lblTituloHeader.Size = new System.Drawing.Size(388, 23);
            this.lblTituloHeader.TabIndex = 31;
            this.lblTituloHeader.Text = "Informes contables";
            // 
            // gestorTabs
            // 
            this.gestorTabs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gestorTabs.Controls.Add(this.infLibroIvaA);
            this.gestorTabs.Controls.Add(this.infLibroIvaB);
            this.gestorTabs.Location = new System.Drawing.Point(12, 90);
            this.gestorTabs.Name = "gestorTabs";
            this.gestorTabs.SelectedIndex = 0;
            this.gestorTabs.Size = new System.Drawing.Size(983, 444);
            this.gestorTabs.TabIndex = 50;
            // 
            // infLibroIvaA
            // 
            this.infLibroIvaA.Controls.Add(this.btnBuscar);
            this.infLibroIvaA.Controls.Add(this.btnExportar);
            this.infLibroIvaA.Controls.Add(this.lblTotalesLibroIvaA);
            this.infLibroIvaA.Controls.Add(this.label2);
            this.infLibroIvaA.Controls.Add(this.dtpFechaHastaLibroIvaA);
            this.infLibroIvaA.Controls.Add(this.lblY);
            this.infLibroIvaA.Controls.Add(this.dtpFechaDesdeLibroIvaA);
            this.infLibroIvaA.Controls.Add(this.dgvLibroIvaA);
            this.infLibroIvaA.Location = new System.Drawing.Point(4, 22);
            this.infLibroIvaA.Name = "infLibroIvaA";
            this.infLibroIvaA.Padding = new System.Windows.Forms.Padding(3);
            this.infLibroIvaA.Size = new System.Drawing.Size(975, 418);
            this.infLibroIvaA.TabIndex = 0;
            this.infLibroIvaA.Text = "Libro de IVA facturas A";
            this.infLibroIvaA.UseVisualStyleBackColor = true;
            this.infLibroIvaA.Click += new System.EventHandler(this.infLibroIvaA_Click);
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
            this.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBuscar.Location = new System.Drawing.Point(777, 5);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(2);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(97, 35);
            this.btnBuscar.TabIndex = 414;
            this.btnBuscar.Text = "Consulta";
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
            this.btnExportar.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnExportar.ForeColor = System.Drawing.Color.White;
            this.btnExportar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExportar.Location = new System.Drawing.Point(878, 5);
            this.btnExportar.Margin = new System.Windows.Forms.Padding(2);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(91, 35);
            this.btnExportar.TabIndex = 413;
            this.btnExportar.Text = "Exporta";
            this.btnExportar.UseVisualStyleBackColor = false;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // lblTotalesLibroIvaA
            // 
            this.lblTotalesLibroIvaA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTotalesLibroIvaA.AutoSize = true;
            this.lblTotalesLibroIvaA.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalesLibroIvaA.ForeColor = System.Drawing.Color.Black;
            this.lblTotalesLibroIvaA.Location = new System.Drawing.Point(1, 384);
            this.lblTotalesLibroIvaA.Name = "lblTotalesLibroIvaA";
            this.lblTotalesLibroIvaA.Size = new System.Drawing.Size(82, 30);
            this.lblTotalesLibroIvaA.TabIndex = 361;
            this.lblTotalesLibroIvaA.Text = "Totales:";
            this.lblTotalesLibroIvaA.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(353, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(149, 21);
            this.label2.TabIndex = 360;
            this.label2.Text = "Periodo de consulta:";
            // 
            // dtpFechaHastaLibroIvaA
            // 
            this.dtpFechaHastaLibroIvaA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpFechaHastaLibroIvaA.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.dtpFechaHastaLibroIvaA.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFechaHastaLibroIvaA.Location = new System.Drawing.Point(640, 6);
            this.dtpFechaHastaLibroIvaA.Name = "dtpFechaHastaLibroIvaA";
            this.dtpFechaHastaLibroIvaA.Size = new System.Drawing.Size(105, 29);
            this.dtpFechaHastaLibroIvaA.TabIndex = 359;
            // 
            // lblY
            // 
            this.lblY.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblY.AutoSize = true;
            this.lblY.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblY.ForeColor = System.Drawing.Color.Black;
            this.lblY.Location = new System.Drawing.Point(618, 12);
            this.lblY.Name = "lblY";
            this.lblY.Size = new System.Drawing.Size(16, 21);
            this.lblY.TabIndex = 358;
            this.lblY.Text = "-";
            // 
            // dtpFechaDesdeLibroIvaA
            // 
            this.dtpFechaDesdeLibroIvaA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpFechaDesdeLibroIvaA.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.dtpFechaDesdeLibroIvaA.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFechaDesdeLibroIvaA.Location = new System.Drawing.Point(508, 6);
            this.dtpFechaDesdeLibroIvaA.Name = "dtpFechaDesdeLibroIvaA";
            this.dtpFechaDesdeLibroIvaA.Size = new System.Drawing.Size(105, 29);
            this.dtpFechaDesdeLibroIvaA.TabIndex = 357;
            // 
            // dgvLibroIvaA
            // 
            this.dgvLibroIvaA.AllowUserToAddRows = false;
            this.dgvLibroIvaA.AllowUserToDeleteRows = false;
            this.dgvLibroIvaA.AllowUserToOrderColumns = true;
            this.dgvLibroIvaA.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvLibroIvaA.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLibroIvaA.BackgroundColor = System.Drawing.Color.White;
            this.dgvLibroIvaA.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvLibroIvaA.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSlateGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 12F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLibroIvaA.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvLibroIvaA.ColumnHeadersHeight = 40;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 12F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvLibroIvaA.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvLibroIvaA.EnableHeadersVisualStyles = false;
            this.dgvLibroIvaA.GridColor = System.Drawing.Color.WhiteSmoke;
            this.dgvLibroIvaA.Location = new System.Drawing.Point(6, 45);
            this.dgvLibroIvaA.MultiSelect = false;
            this.dgvLibroIvaA.Name = "dgvLibroIvaA";
            this.dgvLibroIvaA.ReadOnly = true;
            this.dgvLibroIvaA.RowHeadersVisible = false;
            this.dgvLibroIvaA.RowHeadersWidth = 50;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLibroIvaA.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvLibroIvaA.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvLibroIvaA.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvLibroIvaA.Size = new System.Drawing.Size(963, 336);
            this.dgvLibroIvaA.TabIndex = 343;
            // 
            // infLibroIvaB
            // 
            this.infLibroIvaB.Location = new System.Drawing.Point(4, 22);
            this.infLibroIvaB.Name = "infLibroIvaB";
            this.infLibroIvaB.Padding = new System.Windows.Forms.Padding(3);
            this.infLibroIvaB.Size = new System.Drawing.Size(975, 418);
            this.infLibroIvaB.TabIndex = 1;
            this.infLibroIvaB.Text = "Libro de IVA facturas B";
            this.infLibroIvaB.UseVisualStyleBackColor = true;
            // 
            // pgCircular
            // 
            this.pgCircular.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pgCircular.Location = new System.Drawing.Point(964, 536);
            this.pgCircular.Name = "pgCircular";
            this.pgCircular.Percentage = 0F;
            this.pgCircular.Rotation = CapaPresentacion.Controles.RotationType.CounterClockwise;
            this.pgCircular.Size = new System.Drawing.Size(24, 24);
            this.pgCircular.TabIndex = 51;
            // 
            // frmInformesContables
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(250)))), ((int)(((byte)(251)))));
            this.ClientSize = new System.Drawing.Size(1007, 567);
            this.Controls.Add(this.pgCircular);
            this.Controls.Add(this.gestorTabs);
            this.Controls.Add(this.pnHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmInformesContables";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmInformesContables";
            this.pnHeader.ResumeLayout(false);
            this.pnHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgReturn)).EndInit();
            this.gestorTabs.ResumeLayout(false);
            this.infLibroIvaA.ResumeLayout(false);
            this.infLibroIvaA.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLibroIvaA)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnHeader;
        private System.Windows.Forms.PictureBox imgReturn;
        private System.Windows.Forms.Label lblTituloHeader;
        private System.Windows.Forms.TabControl gestorTabs;
        private System.Windows.Forms.TabPage infLibroIvaA;
        private System.Windows.Forms.TabPage infLibroIvaB;
        private Controles.dgv dgvLibroIvaA;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpFechaHastaLibroIvaA;
        private System.Windows.Forms.Label lblY;
        private System.Windows.Forms.DateTimePicker dtpFechaDesdeLibroIvaA;
        private System.Windows.Forms.Label lblTotalesLibroIvaA;
        private Controles.progress pgCircular;
        private Controles.boton btnBuscar;
        private Controles.boton btnExportar;
    }
}