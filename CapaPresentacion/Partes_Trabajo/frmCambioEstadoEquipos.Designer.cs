namespace CapaPresentacion.Abms
{
    partial class frmCambioEstadoEquipos
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
            this.lblTituloHeader = new System.Windows.Forms.Label();
            this.lblSeleccionEstado = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cboEquiposEstados = new CapaPresentacion.Controles.combo(this.components);
            this.btnAsignar = new CapaPresentacion.Controles.boton();
            this.btnCancelar = new CapaPresentacion.Controles.boton();
            this.SuspendLayout();
            // 
            // lblTituloHeader
            // 
            this.lblTituloHeader.Font = new System.Drawing.Font("Segoe UI Light", 14F);
            this.lblTituloHeader.ForeColor = System.Drawing.Color.Black;
            this.lblTituloHeader.Location = new System.Drawing.Point(12, 9);
            this.lblTituloHeader.Name = "lblTituloHeader";
            this.lblTituloHeader.Size = new System.Drawing.Size(384, 23);
            this.lblTituloHeader.TabIndex = 60;
            this.lblTituloHeader.Text = "Cambio de estado";
            // 
            // lblSeleccionEstado
            // 
            this.lblSeleccionEstado.Font = new System.Drawing.Font("Segoe UI Light", 12F);
            this.lblSeleccionEstado.ForeColor = System.Drawing.Color.Black;
            this.lblSeleccionEstado.Location = new System.Drawing.Point(13, 72);
            this.lblSeleccionEstado.Name = "lblSeleccionEstado";
            this.lblSeleccionEstado.Size = new System.Drawing.Size(183, 23);
            this.lblSeleccionEstado.TabIndex = 62;
            this.lblSeleccionEstado.Text = "Seleccione nuevo estado:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Silver;
            this.panel1.Location = new System.Drawing.Point(0, 39);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(566, 1);
            this.panel1.TabIndex = 63;
            // 
            // cboEquiposEstados
            // 
            this.cboEquiposEstados.BorderColor = System.Drawing.Color.Gainsboro;
            this.cboEquiposEstados.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEquiposEstados.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboEquiposEstados.Font = new System.Drawing.Font("Segoe UI Light", 12F);
            this.cboEquiposEstados.FormattingEnabled = true;
            this.cboEquiposEstados.Location = new System.Drawing.Point(202, 69);
            this.cboEquiposEstados.Name = "cboEquiposEstados";
            this.cboEquiposEstados.Size = new System.Drawing.Size(264, 29);
            this.cboEquiposEstados.TabIndex = 64;
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
            this.btnAsignar.Font = new System.Drawing.Font("Segoe UI Light", 12F);
            this.btnAsignar.ForeColor = System.Drawing.Color.White;
            this.btnAsignar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAsignar.Location = new System.Drawing.Point(276, 121);
            this.btnAsignar.Name = "btnAsignar";
            this.btnAsignar.Size = new System.Drawing.Size(92, 34);
            this.btnAsignar.TabIndex = 243;
            this.btnAsignar.Text = "Asignar";
            this.btnAsignar.UseVisualStyleBackColor = false;
            this.btnAsignar.Click += new System.EventHandler(this.btnAsignar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
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
            this.btnCancelar.Location = new System.Drawing.Point(374, 121);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(92, 34);
            this.btnCancelar.TabIndex = 242;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // frmCambioEstadoEquipos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(250)))), ((int)(((byte)(251)))));
            this.ClientSize = new System.Drawing.Size(478, 167);
            this.Controls.Add(this.btnAsignar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.cboEquiposEstados);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblSeleccionEstado);
            this.Controls.Add(this.lblTituloHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmCambioEstadoEquipos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmCambioEstadoEquipos";
            this.Load += new System.EventHandler(this.frmCambioEstadoEquipos_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTituloHeader;
        private System.Windows.Forms.Label lblSeleccionEstado;
        private System.Windows.Forms.Panel panel1;
        private Controles.combo cboEquiposEstados;
        private Controles.boton btnAsignar;
        private Controles.boton btnCancelar;
    }
}