namespace CapaPresentacion.Partes_Trabajo
{
    partial class frmAsignarDatosFactibilidad
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
            this.txtDetalle = new CapaPresentacion.textboxAdv();
            this.lblDetalle = new System.Windows.Forms.Label();
            this.lblSeleccionFecha = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.btnAsignar = new CapaPresentacion.Controles.boton();
            this.btnCancelar = new CapaPresentacion.Controles.boton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTituloHeader = new System.Windows.Forms.Label();
            this.chkPrioridad = new System.Windows.Forms.CheckBox();
            this.btnAsignarTiposEquipos = new CapaPresentacion.Controles.boton();
            this.SuspendLayout();
            // 
            // txtDetalle
            // 
            this.txtDetalle.BorderColor = System.Drawing.Color.Empty;
            this.txtDetalle.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDetalle.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDetalle.FocusColor = System.Drawing.Color.Empty;
            this.txtDetalle.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDetalle.Location = new System.Drawing.Point(75, 113);
            this.txtDetalle.MaxLength = 50;
            this.txtDetalle.Multiline = true;
            this.txtDetalle.Name = "txtDetalle";
            this.txtDetalle.Numerico = false;
            this.txtDetalle.Size = new System.Drawing.Size(356, 62);
            this.txtDetalle.TabIndex = 255;
            // 
            // lblDetalle
            // 
            this.lblDetalle.AutoSize = true;
            this.lblDetalle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetalle.ForeColor = System.Drawing.Color.Black;
            this.lblDetalle.Location = new System.Drawing.Point(2, 129);
            this.lblDetalle.Name = "lblDetalle";
            this.lblDetalle.Size = new System.Drawing.Size(61, 21);
            this.lblDetalle.TabIndex = 254;
            this.lblDetalle.Text = "Detalle:";
            // 
            // lblSeleccionFecha
            // 
            this.lblSeleccionFecha.AutoSize = true;
            this.lblSeleccionFecha.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSeleccionFecha.ForeColor = System.Drawing.Color.Black;
            this.lblSeleccionFecha.Location = new System.Drawing.Point(12, 66);
            this.lblSeleccionFecha.Name = "lblSeleccionFecha";
            this.lblSeleccionFecha.Size = new System.Drawing.Size(57, 21);
            this.lblSeleccionFecha.TabIndex = 253;
            this.lblSeleccionFecha.Text = "Fecha: ";
            // 
            // dtpFecha
            // 
            this.dtpFecha.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpFecha.Font = new System.Drawing.Font("Segoe UI Light", 12F);
            this.dtpFecha.Location = new System.Drawing.Point(75, 66);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(200, 29);
            this.dtpFecha.TabIndex = 252;
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
            this.btnAsignar.Location = new System.Drawing.Point(241, 184);
            this.btnAsignar.Name = "btnAsignar";
            this.btnAsignar.Size = new System.Drawing.Size(92, 34);
            this.btnAsignar.TabIndex = 251;
            this.btnAsignar.Text = "Guardar";
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
            this.btnCancelar.Location = new System.Drawing.Point(339, 184);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(92, 34);
            this.btnCancelar.TabIndex = 250;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Silver;
            this.panel1.Location = new System.Drawing.Point(-67, 51);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(566, 1);
            this.panel1.TabIndex = 249;
            // 
            // lblTituloHeader
            // 
            this.lblTituloHeader.Font = new System.Drawing.Font("Segoe UI Light", 14F);
            this.lblTituloHeader.ForeColor = System.Drawing.Color.Black;
            this.lblTituloHeader.Location = new System.Drawing.Point(1, 16);
            this.lblTituloHeader.Name = "lblTituloHeader";
            this.lblTituloHeader.Size = new System.Drawing.Size(330, 32);
            this.lblTituloHeader.TabIndex = 248;
            this.lblTituloHeader.Text = "Detalles de factibilidad:";
            // 
            // chkPrioridad
            // 
            this.chkPrioridad.AutoSize = true;
            this.chkPrioridad.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.chkPrioridad.Location = new System.Drawing.Point(311, 71);
            this.chkPrioridad.Name = "chkPrioridad";
            this.chkPrioridad.Size = new System.Drawing.Size(122, 25);
            this.chkPrioridad.TabIndex = 257;
            this.chkPrioridad.Text = "Prioridad alta";
            this.chkPrioridad.UseVisualStyleBackColor = true;
            // 
            // btnAsignarTiposEquipos
            // 
            this.btnAsignarTiposEquipos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAsignarTiposEquipos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnAsignarTiposEquipos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAsignarTiposEquipos.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnAsignarTiposEquipos.FlatAppearance.BorderSize = 0;
            this.btnAsignarTiposEquipos.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnAsignarTiposEquipos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnAsignarTiposEquipos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAsignarTiposEquipos.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnAsignarTiposEquipos.ForeColor = System.Drawing.Color.White;
            this.btnAsignarTiposEquipos.Image = global::CapaPresentacion.Properties.Resources.Data_Add_32;
            this.btnAsignarTiposEquipos.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAsignarTiposEquipos.Location = new System.Drawing.Point(75, 184);
            this.btnAsignarTiposEquipos.Name = "btnAsignarTiposEquipos";
            this.btnAsignarTiposEquipos.Size = new System.Drawing.Size(159, 34);
            this.btnAsignarTiposEquipos.TabIndex = 258;
            this.btnAsignarTiposEquipos.Text = "Tipos de equipos";
            this.btnAsignarTiposEquipos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAsignarTiposEquipos.UseVisualStyleBackColor = false;
            this.btnAsignarTiposEquipos.Click += new System.EventHandler(this.btnAsignarTiposEquipos_Click);
            // 
            // frmAsignarDatosFactibilidad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(250)))), ((int)(((byte)(251)))));
            this.ClientSize = new System.Drawing.Size(445, 230);
            this.Controls.Add(this.btnAsignarTiposEquipos);
            this.Controls.Add(this.chkPrioridad);
            this.Controls.Add(this.txtDetalle);
            this.Controls.Add(this.lblDetalle);
            this.Controls.Add(this.lblSeleccionFecha);
            this.Controls.Add(this.dtpFecha);
            this.Controls.Add(this.btnAsignar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblTituloHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmAsignarDatosFactibilidad";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "AsignarDatosFactibilidad";
            this.Load += new System.EventHandler(this.frmAsignarDatosFactibilidad_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private textboxAdv txtDetalle;
        private System.Windows.Forms.Label lblDetalle;
        private System.Windows.Forms.Label lblSeleccionFecha;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private Controles.boton btnAsignar;
        private Controles.boton btnCancelar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblTituloHeader;
        private System.Windows.Forms.CheckBox chkPrioridad;
        private Controles.boton btnAsignarTiposEquipos;
    }
}