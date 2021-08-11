namespace CapaPresentacion.Abms
{
    partial class ABMEdicionLocacion
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
            this.panel3 = new System.Windows.Forms.Panel();
            this.imgReturn = new System.Windows.Forms.PictureBox();
            this.lblTituloHeader = new System.Windows.Forms.Label();
            this.txtTel2 = new CapaPresentacion.textboxAdv();
            this.lblTel2 = new System.Windows.Forms.Label();
            this.txtTel1 = new CapaPresentacion.textboxAdv();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblObservacion = new System.Windows.Forms.Label();
            this.txtObservacion = new CapaPresentacion.textboxAdv();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCancelar = new CapaPresentacion.Controles.boton();
            this.btnGuardar = new CapaPresentacion.Controles.boton();
            this.prefijo1 = new CapaPresentacion.textboxAdv();
            this.prefijo2 = new CapaPresentacion.textboxAdv();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgReturn)).BeginInit();
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
            this.panel3.Size = new System.Drawing.Size(458, 75);
            this.panel3.TabIndex = 156;
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
            this.lblTituloHeader.TabIndex = 0;
            this.lblTituloHeader.Text = "Datos de locación";
            // 
            // txtTel2
            // 
            this.txtTel2.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtTel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTel2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTel2.FocusColor = System.Drawing.Color.Empty;
            this.txtTel2.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtTel2.ForeColor = System.Drawing.Color.Black;
            this.txtTel2.Location = new System.Drawing.Point(212, 177);
            this.txtTel2.MaxLength = 12;
            this.txtTel2.Name = "txtTel2";
            this.txtTel2.Numerico = true;
            this.txtTel2.Size = new System.Drawing.Size(232, 29);
            this.txtTel2.TabIndex = 3;
            // 
            // lblTel2
            // 
            this.lblTel2.AutoSize = true;
            this.lblTel2.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblTel2.ForeColor = System.Drawing.Color.Black;
            this.lblTel2.Location = new System.Drawing.Point(12, 179);
            this.lblTel2.Name = "lblTel2";
            this.lblTel2.Size = new System.Drawing.Size(101, 21);
            this.lblTel2.TabIndex = 193;
            this.lblTel2.Text = "Teléfono n°2:";
            // 
            // txtTel1
            // 
            this.txtTel1.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtTel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTel1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTel1.FocusColor = System.Drawing.Color.Empty;
            this.txtTel1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtTel1.ForeColor = System.Drawing.Color.Black;
            this.txtTel1.Location = new System.Drawing.Point(212, 144);
            this.txtTel1.MaxLength = 12;
            this.txtTel1.Name = "txtTel1";
            this.txtTel1.Numerico = true;
            this.txtTel1.Size = new System.Drawing.Size(232, 29);
            this.txtTel1.TabIndex = 1;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblNombre.ForeColor = System.Drawing.Color.Black;
            this.lblNombre.Location = new System.Drawing.Point(11, 144);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(105, 21);
            this.lblNombre.TabIndex = 191;
            this.lblNombre.Text = "Teléfono n° 1:";
            // 
            // lblObservacion
            // 
            this.lblObservacion.AutoSize = true;
            this.lblObservacion.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblObservacion.ForeColor = System.Drawing.Color.Black;
            this.lblObservacion.Location = new System.Drawing.Point(12, 212);
            this.lblObservacion.Name = "lblObservacion";
            this.lblObservacion.Size = new System.Drawing.Size(100, 21);
            this.lblObservacion.TabIndex = 194;
            this.lblObservacion.Text = "Observación:";
            // 
            // txtObservacion
            // 
            this.txtObservacion.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtObservacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtObservacion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtObservacion.FocusColor = System.Drawing.Color.Empty;
            this.txtObservacion.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtObservacion.ForeColor = System.Drawing.Color.Black;
            this.txtObservacion.Location = new System.Drawing.Point(15, 236);
            this.txtObservacion.MaxLength = 200;
            this.txtObservacion.Multiline = true;
            this.txtObservacion.Name = "txtObservacion";
            this.txtObservacion.Numerico = false;
            this.txtObservacion.Size = new System.Drawing.Size(429, 127);
            this.txtObservacion.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.Silver;
            this.panel1.Location = new System.Drawing.Point(0, 122);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(475, 1);
            this.panel1.TabIndex = 196;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.Enabled = false;
            this.btnCancelar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI Light", 12F);
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Image = global::CapaPresentacion.Properties.Resources.Command_Redo_32;
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.Location = new System.Drawing.Point(331, 78);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(113, 38);
            this.btnCancelar.TabIndex = 6;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGuardar.BackColor = System.Drawing.Color.SteelBlue;
            this.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnGuardar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI Light", 12F);
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Image = global::CapaPresentacion.Properties.Resources.Save_32;
            this.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGuardar.Location = new System.Drawing.Point(212, 78);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(113, 38);
            this.btnGuardar.TabIndex = 5;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // prefijo1
            // 
            this.prefijo1.BorderColor = System.Drawing.Color.Gainsboro;
            this.prefijo1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.prefijo1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.prefijo1.FocusColor = System.Drawing.Color.Empty;
            this.prefijo1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.prefijo1.ForeColor = System.Drawing.Color.Black;
            this.prefijo1.Location = new System.Drawing.Point(113, 144);
            this.prefijo1.MaxLength = 5;
            this.prefijo1.Name = "prefijo1";
            this.prefijo1.Numerico = true;
            this.prefijo1.Size = new System.Drawing.Size(93, 29);
            this.prefijo1.TabIndex = 0;
            // 
            // prefijo2
            // 
            this.prefijo2.BorderColor = System.Drawing.Color.Gainsboro;
            this.prefijo2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.prefijo2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.prefijo2.FocusColor = System.Drawing.Color.Empty;
            this.prefijo2.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.prefijo2.ForeColor = System.Drawing.Color.Black;
            this.prefijo2.Location = new System.Drawing.Point(113, 177);
            this.prefijo2.MaxLength = 5;
            this.prefijo2.Name = "prefijo2";
            this.prefijo2.Numerico = true;
            this.prefijo2.Size = new System.Drawing.Size(93, 29);
            this.prefijo2.TabIndex = 2;
            // 
            // frmEdicionDatosLocacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(250)))), ((int)(((byte)(251)))));
            this.ClientSize = new System.Drawing.Size(458, 375);
            this.Controls.Add(this.prefijo2);
            this.Controls.Add(this.prefijo1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txtObservacion);
            this.Controls.Add(this.lblObservacion);
            this.Controls.Add(this.txtTel2);
            this.Controls.Add(this.lblTel2);
            this.Controls.Add(this.txtTel1);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.panel3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "frmEdicionDatosLocacion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmEdicionDatosLocacion";
            this.Load += new System.EventHandler(this.frmEdicionDatosLocacion_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmEdicionDatosLocacion_KeyDown);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgReturn)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox imgReturn;
        private System.Windows.Forms.Label lblTituloHeader;
        private textboxAdv txtTel2;
        private System.Windows.Forms.Label lblTel2;
        private textboxAdv txtTel1;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblObservacion;
        private textboxAdv txtObservacion;
        private System.Windows.Forms.Panel panel1;
        private Controles.boton btnCancelar;
        private Controles.boton btnGuardar;
        private textboxAdv prefijo1;
        private textboxAdv prefijo2;
    }
}