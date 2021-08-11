namespace CapaPresentacion
{
    partial class frmDetallesComprobantes
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
            this.txtDet1 = new System.Windows.Forms.TextBox();
            this.txtDet2 = new System.Windows.Forms.TextBox();
            this.lblDetalle1 = new System.Windows.Forms.Label();
            this.lblDetalle2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.imgReturn = new System.Windows.Forms.PictureBox();
            this.lblTituloHeader = new System.Windows.Forms.Label();
            this.lblDetActual1 = new System.Windows.Forms.Label();
            this.lblDetActual2 = new System.Windows.Forms.Label();
            this.pnFooter = new System.Windows.Forms.Panel();
            this.pgCircular = new CapaPresentacion.Controles.progress();
            this.btnGuardar = new CapaPresentacion.Controles.boton();
            this.dgv = new CapaPresentacion.Controles.dgv(this.components);
            this.lblTipoComp = new System.Windows.Forms.Label();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgReturn)).BeginInit();
            this.pnFooter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // txtDet1
            // 
            this.txtDet1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDet1.Font = new System.Drawing.Font("Segoe UI Light", 12F);
            this.txtDet1.Location = new System.Drawing.Point(412, 132);
            this.txtDet1.Name = "txtDet1";
            this.txtDet1.Size = new System.Drawing.Size(404, 29);
            this.txtDet1.TabIndex = 377;
            // 
            // txtDet2
            // 
            this.txtDet2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDet2.Font = new System.Drawing.Font("Segoe UI Light", 12F);
            this.txtDet2.Location = new System.Drawing.Point(412, 349);
            this.txtDet2.Name = "txtDet2";
            this.txtDet2.Size = new System.Drawing.Size(404, 29);
            this.txtDet2.TabIndex = 378;
            // 
            // lblDetalle1
            // 
            this.lblDetalle1.AutoSize = true;
            this.lblDetalle1.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetalle1.ForeColor = System.Drawing.Color.Black;
            this.lblDetalle1.Location = new System.Drawing.Point(336, 135);
            this.lblDetalle1.Name = "lblDetalle1";
            this.lblDetalle1.Size = new System.Drawing.Size(70, 21);
            this.lblDetalle1.TabIndex = 379;
            this.lblDetalle1.Text = "Detalle 1:";
            // 
            // lblDetalle2
            // 
            this.lblDetalle2.AutoSize = true;
            this.lblDetalle2.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetalle2.ForeColor = System.Drawing.Color.Black;
            this.lblDetalle2.Location = new System.Drawing.Point(336, 352);
            this.lblDetalle2.Name = "lblDetalle2";
            this.lblDetalle2.Size = new System.Drawing.Size(72, 21);
            this.lblDetalle2.TabIndex = 380;
            this.lblDetalle2.Text = "Detalle 2:";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.panel3.Controls.Add(this.imgReturn);
            this.panel3.Controls.Add(this.lblTituloHeader);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(828, 75);
            this.panel3.TabIndex = 381;
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
            this.lblTituloHeader.Text = "Detalle por tipo de comprobante";
            // 
            // lblDetActual1
            // 
            this.lblDetActual1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDetActual1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblDetActual1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDetActual1.Font = new System.Drawing.Font("Segoe UI Light", 12F);
            this.lblDetActual1.Location = new System.Drawing.Point(412, 164);
            this.lblDetActual1.Name = "lblDetActual1";
            this.lblDetActual1.Size = new System.Drawing.Size(404, 164);
            this.lblDetActual1.TabIndex = 383;
            this.lblDetActual1.Text = "lblDetActual1";
            // 
            // lblDetActual2
            // 
            this.lblDetActual2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDetActual2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblDetActual2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDetActual2.Font = new System.Drawing.Font("Segoe UI Light", 12F);
            this.lblDetActual2.Location = new System.Drawing.Point(412, 381);
            this.lblDetActual2.Name = "lblDetActual2";
            this.lblDetActual2.Size = new System.Drawing.Size(404, 164);
            this.lblDetActual2.TabIndex = 384;
            this.lblDetActual2.Text = "label1";
            // 
            // pnFooter
            // 
            this.pnFooter.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnFooter.Controls.Add(this.pgCircular);
            this.pnFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnFooter.Location = new System.Drawing.Point(0, 566);
            this.pnFooter.Name = "pnFooter";
            this.pnFooter.Size = new System.Drawing.Size(828, 30);
            this.pnFooter.TabIndex = 386;
            // 
            // pgCircular
            // 
            this.pgCircular.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pgCircular.Location = new System.Drawing.Point(801, 3);
            this.pgCircular.Name = "pgCircular";
            this.pgCircular.Percentage = 0F;
            this.pgCircular.Rotation = CapaPresentacion.Controles.RotationType.CounterClockwise;
            this.pgCircular.Size = new System.Drawing.Size(24, 24);
            this.pgCircular.TabIndex = 1;
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
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Image = global::CapaPresentacion.Properties.Resources.Save_32;
            this.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGuardar.Location = new System.Drawing.Point(720, 87);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(96, 35);
            this.btnGuardar.TabIndex = 387;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AllowUserToOrderColumns = true;
            this.dgv.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv.BackgroundColor = System.Drawing.Color.White;
            this.dgv.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgv.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgv.EnableHeadersVisualStyles = false;
            this.dgv.GridColor = System.Drawing.Color.WhiteSmoke;
            this.dgv.Location = new System.Drawing.Point(12, 87);
            this.dgv.MultiSelect = false;
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersVisible = false;
            this.dgv.RowHeadersWidth = 50;
            this.dgv.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(308, 458);
            this.dgv.TabIndex = 385;
            this.dgv.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvComprobantes_CellEnter);
            // 
            // lblTipoComp
            // 
            this.lblTipoComp.AutoSize = true;
            this.lblTipoComp.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipoComp.ForeColor = System.Drawing.Color.Black;
            this.lblTipoComp.Location = new System.Drawing.Point(408, 101);
            this.lblTipoComp.Name = "lblTipoComp";
            this.lblTipoComp.Size = new System.Drawing.Size(77, 21);
            this.lblTipoComp.TabIndex = 388;
            this.lblTipoComp.Text = "tipoComp";
            // 
            // frmDetallesComprobantes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(828, 596);
            this.Controls.Add(this.lblTipoComp);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.pnFooter);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.lblDetActual2);
            this.Controls.Add(this.lblDetActual1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.lblDetalle2);
            this.Controls.Add(this.lblDetalle1);
            this.Controls.Add(this.txtDet2);
            this.Controls.Add(this.txtDet1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "frmDetallesComprobantes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmDetallesComprobantes";
            this.Load += new System.EventHandler(this.frmDetallesComprobantes_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmDetallesComprobantes_KeyDown);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgReturn)).EndInit();
            this.pnFooter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtDet1;
        private System.Windows.Forms.TextBox txtDet2;
        private System.Windows.Forms.Label lblDetalle1;
        private System.Windows.Forms.Label lblDetalle2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox imgReturn;
        private System.Windows.Forms.Label lblTituloHeader;
        private System.Windows.Forms.Label lblDetActual1;
        private System.Windows.Forms.Label lblDetActual2;
        private Controles.dgv dgv;
        private System.Windows.Forms.Panel pnFooter;
        private Controles.progress pgCircular;
        private Controles.boton btnGuardar;
        private System.Windows.Forms.Label lblTipoComp;
    }
}