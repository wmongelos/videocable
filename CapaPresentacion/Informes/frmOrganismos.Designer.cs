namespace CapaPresentacion
{
    partial class frmOrganismos
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel3 = new System.Windows.Forms.Panel();
            this.imgReturn = new System.Windows.Forms.PictureBox();
            this.lblTituloHeader = new System.Windows.Forms.Label();
            this.pnFooter = new System.Windows.Forms.Panel();
            this.lblTotal = new System.Windows.Forms.Label();
            this.pgCircular = new CapaPresentacion.Controles.progress();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnAgregarSer = new CapaPresentacion.Controles.boton();
            this.lblServicios = new System.Windows.Forms.Label();
            this.comboServicios = new CapaPresentacion.Controles.combo(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvOrganismos = new System.Windows.Forms.DataGridView();
            this.dgvSubservicios = new System.Windows.Forms.DataGridView();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgReturn)).BeginInit();
            this.pnFooter.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrganismos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSubservicios)).BeginInit();
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
            this.panel3.Size = new System.Drawing.Size(724, 99);
            this.panel3.TabIndex = 155;
            // 
            // imgReturn
            // 
            this.imgReturn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.imgReturn.Image = global::CapaPresentacion.Properties.Resources.Left_Arrow_32;
            this.imgReturn.Location = new System.Drawing.Point(15, 33);
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
            this.lblTituloHeader.Location = new System.Drawing.Point(53, 36);
            this.lblTituloHeader.Name = "lblTituloHeader";
            this.lblTituloHeader.Size = new System.Drawing.Size(338, 27);
            this.lblTituloHeader.TabIndex = 31;
            this.lblTituloHeader.Text = "Organismos";
            // 
            // pnFooter
            // 
            this.pnFooter.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnFooter.Controls.Add(this.lblTotal);
            this.pnFooter.Controls.Add(this.pgCircular);
            this.pnFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnFooter.Location = new System.Drawing.Point(0, 420);
            this.pnFooter.Name = "pnFooter";
            this.pnFooter.Size = new System.Drawing.Size(724, 30);
            this.pnFooter.TabIndex = 358;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblTotal.ForeColor = System.Drawing.Color.SlateGray;
            this.lblTotal.Location = new System.Drawing.Point(12, 5);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(148, 21);
            this.lblTotal.TabIndex = 13;
            this.lblTotal.Text = "Total de Registros: 0";
            // 
            // pgCircular
            // 
            this.pgCircular.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pgCircular.Location = new System.Drawing.Point(688, 2);
            this.pgCircular.Name = "pgCircular";
            this.pgCircular.Percentage = 0F;
            this.pgCircular.Rotation = CapaPresentacion.Controles.RotationType.CounterClockwise;
            this.pgCircular.Size = new System.Drawing.Size(24, 24);
            this.pgCircular.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnAgregarSer);
            this.panel1.Controls.Add(this.lblServicios);
            this.panel1.Controls.Add(this.comboServicios);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 99);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(724, 47);
            this.panel1.TabIndex = 359;
            // 
            // btnAgregarSer
            // 
            this.btnAgregarSer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAgregarSer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnAgregarSer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregarSer.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnAgregarSer.FlatAppearance.BorderSize = 0;
            this.btnAgregarSer.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnAgregarSer.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnAgregarSer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarSer.Font = new System.Drawing.Font("Segoe UI Light", 12.25F);
            this.btnAgregarSer.ForeColor = System.Drawing.Color.White;
            this.btnAgregarSer.Image = global::CapaPresentacion.Properties.Resources.Download_32;
            this.btnAgregarSer.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAgregarSer.Location = new System.Drawing.Point(551, 8);
            this.btnAgregarSer.Name = "btnAgregarSer";
            this.btnAgregarSer.Size = new System.Drawing.Size(161, 30);
            this.btnAgregarSer.TabIndex = 363;
            this.btnAgregarSer.Text = "Agregar Servicio";
            this.btnAgregarSer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgregarSer.UseVisualStyleBackColor = false;
            this.btnAgregarSer.Click += new System.EventHandler(this.btnAgregarSer_Click);
            // 
            // lblServicios
            // 
            this.lblServicios.AutoSize = true;
            this.lblServicios.Font = new System.Drawing.Font("Segoe UI Light", 12.25F);
            this.lblServicios.ForeColor = System.Drawing.Color.Black;
            this.lblServicios.Location = new System.Drawing.Point(8, 12);
            this.lblServicios.Name = "lblServicios";
            this.lblServicios.Size = new System.Drawing.Size(73, 23);
            this.lblServicios.TabIndex = 37;
            this.lblServicios.Text = "Servicios";
            // 
            // comboServicios
            // 
            this.comboServicios.BorderColor = System.Drawing.Color.Empty;
            this.comboServicios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboServicios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboServicios.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboServicios.FormattingEnabled = true;
            this.comboServicios.Location = new System.Drawing.Point(94, 9);
            this.comboServicios.Name = "comboServicios";
            this.comboServicios.Size = new System.Drawing.Size(315, 29);
            this.comboServicios.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 146);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(724, 1);
            this.panel2.TabIndex = 360;
            // 
            // dgvOrganismos
            // 
            this.dgvOrganismos.AllowUserToAddRows = false;
            this.dgvOrganismos.AllowUserToDeleteRows = false;
            this.dgvOrganismos.AllowUserToOrderColumns = true;
            this.dgvOrganismos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvOrganismos.BackgroundColor = System.Drawing.Color.White;
            this.dgvOrganismos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvOrganismos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.LightSlateGray;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 12F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvOrganismos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvOrganismos.ColumnHeadersHeight = 40;
            this.dgvOrganismos.Dock = System.Windows.Forms.DockStyle.Left;
            this.dgvOrganismos.EnableHeadersVisualStyles = false;
            this.dgvOrganismos.GridColor = System.Drawing.Color.WhiteSmoke;
            this.dgvOrganismos.Location = new System.Drawing.Point(0, 147);
            this.dgvOrganismos.Name = "dgvOrganismos";
            this.dgvOrganismos.RowHeadersVisible = false;
            this.dgvOrganismos.RowHeadersWidth = 50;
            this.dgvOrganismos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOrganismos.Size = new System.Drawing.Size(188, 273);
            this.dgvOrganismos.TabIndex = 361;
            this.dgvOrganismos.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOrganismos_CellEnter);
            // 
            // dgvSubservicios
            // 
            this.dgvSubservicios.AllowUserToAddRows = false;
            this.dgvSubservicios.AllowUserToDeleteRows = false;
            this.dgvSubservicios.AllowUserToOrderColumns = true;
            this.dgvSubservicios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSubservicios.BackgroundColor = System.Drawing.Color.White;
            this.dgvSubservicios.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvSubservicios.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.LightSlateGray;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 12F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSubservicios.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvSubservicios.ColumnHeadersHeight = 40;
            this.dgvSubservicios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSubservicios.EnableHeadersVisualStyles = false;
            this.dgvSubservicios.GridColor = System.Drawing.Color.WhiteSmoke;
            this.dgvSubservicios.Location = new System.Drawing.Point(188, 147);
            this.dgvSubservicios.Name = "dgvSubservicios";
            this.dgvSubservicios.ReadOnly = true;
            this.dgvSubservicios.RowHeadersVisible = false;
            this.dgvSubservicios.RowHeadersWidth = 50;
            this.dgvSubservicios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSubservicios.Size = new System.Drawing.Size(536, 273);
            this.dgvSubservicios.TabIndex = 362;
            this.dgvSubservicios.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSubservicios_CellEnter);
            // 
            // frmOrganismos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(724, 450);
            this.Controls.Add(this.dgvSubservicios);
            this.Controls.Add(this.dgvOrganismos);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnFooter);
            this.Controls.Add(this.panel3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "frmOrganismos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmOrganismos";
            this.Load += new System.EventHandler(this.frmOrganismos_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmOrganismos_KeyDown);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgReturn)).EndInit();
            this.pnFooter.ResumeLayout(false);
            this.pnFooter.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrganismos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSubservicios)).EndInit();
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
        private System.Windows.Forms.DataGridView dgvOrganismos;
        private System.Windows.Forms.DataGridView dgvSubservicios;
        private Controles.combo comboServicios;
        private System.Windows.Forms.Label lblServicios;
        private Controles.boton btnAgregarSer;
    }
}