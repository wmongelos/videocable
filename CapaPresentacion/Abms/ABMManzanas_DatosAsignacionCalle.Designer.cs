namespace CapaPresentacion.Abms
{
    partial class ABMManzanas_DatosAsignacionCalle
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
            this.lblAltura = new System.Windows.Forms.Label();
            this.lblParidad = new System.Windows.Forms.Label();
            this.lblTituloHeader = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblDesde = new System.Windows.Forms.Label();
            this.lblHasta = new System.Windows.Forms.Label();
            this.btnAsignar = new CapaPresentacion.Controles.boton();
            this.btnCancelar = new CapaPresentacion.Controles.boton();
            this.cboParidad = new CapaPresentacion.Controles.combo(this.components);
            this.spnDesde = new CapaPresentacion.Controles.spinner(this.components);
            this.spnHasta = new CapaPresentacion.Controles.spinner(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.spnDesde)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spnHasta)).BeginInit();
            this.SuspendLayout();
            // 
            // lblAltura
            // 
            this.lblAltura.AutoSize = true;
            this.lblAltura.Font = new System.Drawing.Font("Segoe UI Light", 12F);
            this.lblAltura.ForeColor = System.Drawing.Color.Black;
            this.lblAltura.Location = new System.Drawing.Point(6, 51);
            this.lblAltura.Name = "lblAltura";
            this.lblAltura.Size = new System.Drawing.Size(54, 21);
            this.lblAltura.TabIndex = 55;
            this.lblAltura.Text = "Altura:";
            // 
            // lblParidad
            // 
            this.lblParidad.AutoSize = true;
            this.lblParidad.Font = new System.Drawing.Font("Segoe UI Light", 12F);
            this.lblParidad.ForeColor = System.Drawing.Color.Black;
            this.lblParidad.Location = new System.Drawing.Point(29, 90);
            this.lblParidad.Name = "lblParidad";
            this.lblParidad.Size = new System.Drawing.Size(65, 21);
            this.lblParidad.TabIndex = 56;
            this.lblParidad.Text = "Paridad:";
            // 
            // lblTituloHeader
            // 
            this.lblTituloHeader.Font = new System.Drawing.Font("Segoe UI Light", 14F);
            this.lblTituloHeader.ForeColor = System.Drawing.Color.Black;
            this.lblTituloHeader.Location = new System.Drawing.Point(12, 9);
            this.lblTituloHeader.Name = "lblTituloHeader";
            this.lblTituloHeader.Size = new System.Drawing.Size(384, 23);
            this.lblTituloHeader.TabIndex = 57;
            this.lblTituloHeader.Text = "Calle:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Silver;
            this.panel1.Location = new System.Drawing.Point(0, 41);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(423, 1);
            this.panel1.TabIndex = 58;
            // 
            // lblDesde
            // 
            this.lblDesde.AutoSize = true;
            this.lblDesde.Font = new System.Drawing.Font("Segoe UI Light", 12F);
            this.lblDesde.ForeColor = System.Drawing.Color.Black;
            this.lblDesde.Location = new System.Drawing.Point(53, 51);
            this.lblDesde.Name = "lblDesde";
            this.lblDesde.Size = new System.Drawing.Size(56, 21);
            this.lblDesde.TabIndex = 59;
            this.lblDesde.Text = "Desde:";
            // 
            // lblHasta
            // 
            this.lblHasta.AutoSize = true;
            this.lblHasta.Font = new System.Drawing.Font("Segoe UI Light", 12F);
            this.lblHasta.ForeColor = System.Drawing.Color.Black;
            this.lblHasta.Location = new System.Drawing.Point(257, 51);
            this.lblHasta.Name = "lblHasta";
            this.lblHasta.Size = new System.Drawing.Size(52, 21);
            this.lblHasta.TabIndex = 60;
            this.lblHasta.Text = "Hasta:";
            // 
            // btnAsignar
            // 
            this.btnAsignar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnAsignar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAsignar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnAsignar.FlatAppearance.BorderSize = 0;
            this.btnAsignar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnAsignar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnAsignar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAsignar.Font = new System.Drawing.Font("Segoe UI Light", 12F);
            this.btnAsignar.ForeColor = System.Drawing.Color.White;
            this.btnAsignar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAsignar.Location = new System.Drawing.Point(206, 146);
            this.btnAsignar.Name = "btnAsignar";
            this.btnAsignar.Size = new System.Drawing.Size(92, 34);
            this.btnAsignar.TabIndex = 61;
            this.btnAsignar.Text = "Asignar";
            this.btnAsignar.UseVisualStyleBackColor = false;
            this.btnAsignar.Click += new System.EventHandler(this.boton2_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI Light", 12F);
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.Location = new System.Drawing.Point(304, 146);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(92, 34);
            this.btnCancelar.TabIndex = 7;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.boton1_Click);
            // 
            // cboParidad
            // 
            this.cboParidad.BorderColor = System.Drawing.Color.Empty;
            this.cboParidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboParidad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboParidad.Font = new System.Drawing.Font("Segoe UI Light", 12F);
            this.cboParidad.ForeColor = System.Drawing.Color.Black;
            this.cboParidad.FormattingEnabled = true;
            this.cboParidad.Location = new System.Drawing.Point(115, 87);
            this.cboParidad.Name = "cboParidad";
            this.cboParidad.Size = new System.Drawing.Size(81, 29);
            this.cboParidad.TabIndex = 5;
            // 
            // spnDesde
            // 
            this.spnDesde.BorderColor = System.Drawing.Color.Empty;
            this.spnDesde.Font = new System.Drawing.Font("Segoe UI Light", 12F);
            this.spnDesde.ForeColor = System.Drawing.Color.Black;
            this.spnDesde.Location = new System.Drawing.Point(115, 49);
            this.spnDesde.Name = "spnDesde";
            this.spnDesde.Size = new System.Drawing.Size(81, 29);
            this.spnDesde.TabIndex = 62;
            // 
            // spnHasta
            // 
            this.spnHasta.BorderColor = System.Drawing.Color.Empty;
            this.spnHasta.Font = new System.Drawing.Font("Segoe UI Light", 12F);
            this.spnHasta.ForeColor = System.Drawing.Color.Black;
            this.spnHasta.Location = new System.Drawing.Point(314, 49);
            this.spnHasta.Name = "spnHasta";
            this.spnHasta.Size = new System.Drawing.Size(81, 29);
            this.spnHasta.TabIndex = 63;
            // 
            // ABMDatosAsignacionCalle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(250)))), ((int)(((byte)(251)))));
            this.ClientSize = new System.Drawing.Size(407, 196);
            this.Controls.Add(this.spnHasta);
            this.Controls.Add(this.spnDesde);
            this.Controls.Add(this.btnAsignar);
            this.Controls.Add(this.lblHasta);
            this.Controls.Add(this.lblDesde);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblTituloHeader);
            this.Controls.Add(this.lblParidad);
            this.Controls.Add(this.lblAltura);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.cboParidad);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "ABMDatosAsignacionCalle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ABMDatosAsignacionCaller";
            this.Load += new System.EventHandler(this.ABMDatosAsignacionCalle_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ABMDatosAsignacionCalle_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.spnDesde)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spnHasta)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Controles.combo cboParidad;
        private Controles.boton btnCancelar;
        private System.Windows.Forms.Label lblAltura;
        private System.Windows.Forms.Label lblParidad;
        private System.Windows.Forms.Label lblTituloHeader;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblDesde;
        private System.Windows.Forms.Label lblHasta;
        private Controles.boton btnAsignar;
        private Controles.spinner spnDesde;
        private Controles.spinner spnHasta;
    }
}