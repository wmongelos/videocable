namespace CapaPresentacion.Partes_Trabajo
{
    partial class frmAvisos
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
            this.dtFecha = new System.Windows.Forms.DateTimePicker();
            this.CmbTipo_de_comunicacion = new System.Windows.Forms.ComboBox();
            this.txtdescripcion = new CapaPresentacion.textboxAdv();
            this.pnLinea1 = new System.Windows.Forms.Panel();
            this.btnSalir = new CapaPresentacion.Controles.boton();
            this.lblocalidad = new System.Windows.Forms.Label();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.btnGenerarAviso = new CapaPresentacion.Controles.boton();
            this.btnCancela = new CapaPresentacion.Controles.boton();
            this.txtReceptor = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pnLinea1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtFecha
            // 
            this.dtFecha.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtFecha.Location = new System.Drawing.Point(474, 104);
            this.dtFecha.Name = "dtFecha";
            this.dtFecha.Size = new System.Drawing.Size(445, 21);
            this.dtFecha.TabIndex = 0;
            // 
            // CmbTipo_de_comunicacion
            // 
            this.CmbTipo_de_comunicacion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CmbTipo_de_comunicacion.FormattingEnabled = true;
            this.CmbTipo_de_comunicacion.Location = new System.Drawing.Point(561, 130);
            this.CmbTipo_de_comunicacion.Name = "CmbTipo_de_comunicacion";
            this.CmbTipo_de_comunicacion.Size = new System.Drawing.Size(356, 21);
            this.CmbTipo_de_comunicacion.TabIndex = 1;
            // 
            // txtdescripcion
            // 
            this.txtdescripcion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtdescripcion.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtdescripcion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtdescripcion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtdescripcion.FocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.txtdescripcion.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtdescripcion.ForeColor = System.Drawing.Color.DimGray;
            this.txtdescripcion.Location = new System.Drawing.Point(474, 212);
            this.txtdescripcion.Multiline = true;
            this.txtdescripcion.Name = "txtdescripcion";
            this.txtdescripcion.Numerico = false;
            this.txtdescripcion.Size = new System.Drawing.Size(445, 192);
            this.txtdescripcion.TabIndex = 23;
            this.txtdescripcion.Tag = "\"\"";
            // 
            // pnLinea1
            // 
            this.pnLinea1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnLinea1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(84)))), ((int)(((byte)(101)))));
            this.pnLinea1.Controls.Add(this.btnSalir);
            this.pnLinea1.Controls.Add(this.lblocalidad);
            this.pnLinea1.Controls.Add(this.lblUsuario);
            this.pnLinea1.Location = new System.Drawing.Point(2, 1);
            this.pnLinea1.Name = "pnLinea1";
            this.pnLinea1.Size = new System.Drawing.Size(926, 80);
            this.pnLinea1.TabIndex = 78;
            // 
            // btnSalir
            // 
            this.btnSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(104)))), ((int)(((byte)(121)))));
            this.btnSalir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSalir.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnSalir.FlatAppearance.BorderSize = 0;
            this.btnSalir.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnSalir.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalir.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.ForeColor = System.Drawing.Color.White;
            this.btnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSalir.Location = new System.Drawing.Point(874, 7);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(46, 23);
            this.btnSalir.TabIndex = 73;
            this.btnSalir.Text = "X";
            this.btnSalir.UseVisualStyleBackColor = false;
            // 
            // lblocalidad
            // 
            this.lblocalidad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(84)))), ((int)(((byte)(101)))));
            this.lblocalidad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblocalidad.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblocalidad.ForeColor = System.Drawing.Color.White;
            this.lblocalidad.Location = new System.Drawing.Point(8, 30);
            this.lblocalidad.Name = "lblocalidad";
            this.lblocalidad.Size = new System.Drawing.Size(369, 19);
            this.lblocalidad.TabIndex = 70;
            this.lblocalidad.Text = "-";
            this.lblocalidad.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblUsuario
            // 
            this.lblUsuario.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuario.ForeColor = System.Drawing.Color.White;
            this.lblUsuario.Location = new System.Drawing.Point(8, 8);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(369, 23);
            this.lblUsuario.TabIndex = 48;
            this.lblUsuario.Text = "-";
            this.lblUsuario.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnGenerarAviso
            // 
            this.btnGenerarAviso.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGenerarAviso.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnGenerarAviso.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGenerarAviso.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnGenerarAviso.FlatAppearance.BorderSize = 0;
            this.btnGenerarAviso.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnGenerarAviso.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnGenerarAviso.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerarAviso.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerarAviso.ForeColor = System.Drawing.Color.White;
            this.btnGenerarAviso.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGenerarAviso.Location = new System.Drawing.Point(697, 436);
            this.btnGenerarAviso.Name = "btnGenerarAviso";
            this.btnGenerarAviso.Size = new System.Drawing.Size(108, 31);
            this.btnGenerarAviso.TabIndex = 135;
            this.btnGenerarAviso.Text = "Confirma";
            this.btnGenerarAviso.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGenerarAviso.UseVisualStyleBackColor = true;
            this.btnGenerarAviso.Click += new System.EventHandler(this.btnGenerarAviso_Click);
            // 
            // btnCancela
            // 
            this.btnCancela.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancela.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnCancela.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancela.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnCancela.FlatAppearance.BorderSize = 0;
            this.btnCancela.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnCancela.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnCancela.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancela.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancela.ForeColor = System.Drawing.Color.White;
            this.btnCancela.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancela.Location = new System.Drawing.Point(811, 436);
            this.btnCancela.Name = "btnCancela";
            this.btnCancela.Size = new System.Drawing.Size(108, 31);
            this.btnCancela.TabIndex = 136;
            this.btnCancela.Text = "Sale";
            this.btnCancela.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancela.UseVisualStyleBackColor = true;
            this.btnCancela.Click += new System.EventHandler(this.btnCancela_Click);
            // 
            // txtReceptor
            // 
            this.txtReceptor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtReceptor.Location = new System.Drawing.Point(474, 167);
            this.txtReceptor.Name = "txtReceptor";
            this.txtReceptor.Size = new System.Drawing.Size(445, 21);
            this.txtReceptor.TabIndex = 137;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(434, 108);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 138;
            this.label1.Text = "Fecha";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(444, 133);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 13);
            this.label2.TabIndex = 139;
            this.label2.Text = "Tipo de Nota de Aviso";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(419, 171);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 140;
            this.label3.Text = "Receptor";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(423, 214);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 141;
            this.label4.Text = "Mensaje";
            // 
            // frmAvisos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(929, 473);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtReceptor);
            this.Controls.Add(this.btnCancela);
            this.Controls.Add(this.btnGenerarAviso);
            this.Controls.Add(this.pnLinea1);
            this.Controls.Add(this.txtdescripcion);
            this.Controls.Add(this.CmbTipo_de_comunicacion);
            this.Controls.Add(this.dtFecha);
            this.Name = "frmAvisos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "6";
            this.Controls.SetChildIndex(this.dtFecha, 0);
            this.Controls.SetChildIndex(this.CmbTipo_de_comunicacion, 0);
            this.Controls.SetChildIndex(this.txtdescripcion, 0);
            this.Controls.SetChildIndex(this.pnLinea1, 0);
            this.Controls.SetChildIndex(this.btnGenerarAviso, 0);
            this.Controls.SetChildIndex(this.btnCancela, 0);
            this.Controls.SetChildIndex(this.txtReceptor, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.pnLinea1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtFecha;
        private System.Windows.Forms.ComboBox CmbTipo_de_comunicacion;
        private textboxAdv txtdescripcion;
        private System.Windows.Forms.Panel pnLinea1;
        private Controles.boton btnSalir;
        private System.Windows.Forms.Label lblocalidad;
        private System.Windows.Forms.Label lblUsuario;
        private Controles.boton btnGenerarAviso;
        private Controles.boton btnCancela;
        private System.Windows.Forms.TextBox txtReceptor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}