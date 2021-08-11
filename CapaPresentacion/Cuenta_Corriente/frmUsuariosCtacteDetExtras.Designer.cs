namespace CapaPresentacion
{
    partial class frmUsuariosCtacteDetExtras
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlTitulo = new System.Windows.Forms.Panel();
            this.imgReturn = new System.Windows.Forms.PictureBox();
            this.lblTituloHeader = new System.Windows.Forms.Label();
            this.dgvCtaCteDetExtras = new CapaPresentacion.Controles.dgv(this.components);
            this.pnlInferior = new System.Windows.Forms.Panel();
            this.lblTotal = new System.Windows.Forms.Label();
            this.pgCircular = new CapaPresentacion.Controles.progress();
            this.pnlInfo = new System.Windows.Forms.Panel();
            this.lblImporteDescontado = new System.Windows.Forms.Label();
            this.pnlTitulo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgReturn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCtaCteDetExtras)).BeginInit();
            this.pnlInferior.SuspendLayout();
            this.pnlInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTitulo
            // 
            this.pnlTitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.pnlTitulo.Controls.Add(this.imgReturn);
            this.pnlTitulo.Controls.Add(this.lblTituloHeader);
            this.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTitulo.Location = new System.Drawing.Point(0, 0);
            this.pnlTitulo.Name = "pnlTitulo";
            this.pnlTitulo.Size = new System.Drawing.Size(800, 80);
            this.pnlTitulo.TabIndex = 42;
            // 
            // imgReturn
            // 
            this.imgReturn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.imgReturn.Image = global::CapaPresentacion.Properties.Resources.Left_Arrow_32;
            this.imgReturn.Location = new System.Drawing.Point(11, 19);
            this.imgReturn.Name = "imgReturn";
            this.imgReturn.Size = new System.Drawing.Size(32, 32);
            this.imgReturn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgReturn.TabIndex = 75;
            this.imgReturn.TabStop = false;
            this.imgReturn.Click += new System.EventHandler(this.imgReturn_Click);
            // 
            // lblTituloHeader
            // 
            this.lblTituloHeader.AutoSize = true;
            this.lblTituloHeader.Font = new System.Drawing.Font("Segoe UI Light", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloHeader.ForeColor = System.Drawing.Color.White;
            this.lblTituloHeader.Location = new System.Drawing.Point(49, 26);
            this.lblTituloHeader.Name = "lblTituloHeader";
            this.lblTituloHeader.Size = new System.Drawing.Size(58, 25);
            this.lblTituloHeader.TabIndex = 74;
            this.lblTituloHeader.Text = "Extras";
            // 
            // dgvCtaCteDetExtras
            // 
            this.dgvCtaCteDetExtras.AllowUserToAddRows = false;
            this.dgvCtaCteDetExtras.AllowUserToDeleteRows = false;
            this.dgvCtaCteDetExtras.AllowUserToOrderColumns = true;
            this.dgvCtaCteDetExtras.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCtaCteDetExtras.BackgroundColor = System.Drawing.Color.White;
            this.dgvCtaCteDetExtras.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvCtaCteDetExtras.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.LightSlateGray;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCtaCteDetExtras.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvCtaCteDetExtras.ColumnHeadersHeight = 40;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCtaCteDetExtras.DefaultCellStyle = dataGridViewCellStyle10;
            this.dgvCtaCteDetExtras.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCtaCteDetExtras.EnableHeadersVisualStyles = false;
            this.dgvCtaCteDetExtras.GridColor = System.Drawing.Color.WhiteSmoke;
            this.dgvCtaCteDetExtras.Location = new System.Drawing.Point(0, 80);
            this.dgvCtaCteDetExtras.MultiSelect = false;
            this.dgvCtaCteDetExtras.Name = "dgvCtaCteDetExtras";
            this.dgvCtaCteDetExtras.ReadOnly = true;
            this.dgvCtaCteDetExtras.RowHeadersVisible = false;
            this.dgvCtaCteDetExtras.RowHeadersWidth = 50;
            this.dgvCtaCteDetExtras.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvCtaCteDetExtras.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCtaCteDetExtras.Size = new System.Drawing.Size(800, 292);
            this.dgvCtaCteDetExtras.TabIndex = 43;
            // 
            // pnlInferior
            // 
            this.pnlInferior.Controls.Add(this.lblTotal);
            this.pnlInferior.Controls.Add(this.pgCircular);
            this.pnlInferior.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlInferior.Location = new System.Drawing.Point(0, 417);
            this.pnlInferior.Name = "pnlInferior";
            this.pnlInferior.Size = new System.Drawing.Size(800, 33);
            this.pnlInferior.TabIndex = 44;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblTotal.ForeColor = System.Drawing.Color.SlateGray;
            this.lblTotal.Location = new System.Drawing.Point(7, 6);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(148, 21);
            this.lblTotal.TabIndex = 14;
            this.lblTotal.Text = "Total de Registros: 0";
            // 
            // pgCircular
            // 
            this.pgCircular.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pgCircular.Location = new System.Drawing.Point(764, 6);
            this.pgCircular.Name = "pgCircular";
            this.pgCircular.Percentage = 0F;
            this.pgCircular.Rotation = CapaPresentacion.Controles.RotationType.CounterClockwise;
            this.pgCircular.Size = new System.Drawing.Size(24, 24);
            this.pgCircular.TabIndex = 1;
            // 
            // pnlInfo
            // 
            this.pnlInfo.Controls.Add(this.lblImporteDescontado);
            this.pnlInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlInfo.Location = new System.Drawing.Point(0, 372);
            this.pnlInfo.Name = "pnlInfo";
            this.pnlInfo.Size = new System.Drawing.Size(800, 45);
            this.pnlInfo.TabIndex = 45;
            // 
            // lblImporteDescontado
            // 
            this.lblImporteDescontado.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblImporteDescontado.AutoSize = true;
            this.lblImporteDescontado.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblImporteDescontado.ForeColor = System.Drawing.Color.Black;
            this.lblImporteDescontado.Location = new System.Drawing.Point(612, 12);
            this.lblImporteDescontado.Name = "lblImporteDescontado";
            this.lblImporteDescontado.Size = new System.Drawing.Size(185, 21);
            this.lblImporteDescontado.TabIndex = 15;
            this.lblImporteDescontado.Text = "Total importe descontado";
            // 
            // frmUsuariosCtacteDetExtras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvCtaCteDetExtras);
            this.Controls.Add(this.pnlTitulo);
            this.Controls.Add(this.pnlInfo);
            this.Controls.Add(this.pnlInferior);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "frmUsuariosCtacteDetExtras";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmUsuariosCtacteDetExtras";
            this.Load += new System.EventHandler(this.frmUsuariosCtacteDetExtras_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmUsuariosCtacteDetExtras_KeyDown);
            this.pnlTitulo.ResumeLayout(false);
            this.pnlTitulo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgReturn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCtaCteDetExtras)).EndInit();
            this.pnlInferior.ResumeLayout(false);
            this.pnlInferior.PerformLayout();
            this.pnlInfo.ResumeLayout(false);
            this.pnlInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTitulo;
        private System.Windows.Forms.PictureBox imgReturn;
        private System.Windows.Forms.Label lblTituloHeader;
        private Controles.dgv dgvCtaCteDetExtras;
        private System.Windows.Forms.Panel pnlInferior;
        private Controles.progress pgCircular;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Panel pnlInfo;
        private System.Windows.Forms.Label lblImporteDescontado;
    }
}