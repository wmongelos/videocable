namespace CapaPresentacion.Abms
{
    partial class ABMUsuarios_LocacionFiscal
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtCP = new CapaPresentacion.textboxAdv();
            this.txtDepto = new CapaPresentacion.textboxAdv();
            this.txtPiso = new CapaPresentacion.textboxAdv();
            this.txtAltura = new CapaPresentacion.textboxAdv();
            this.txtCalle = new CapaPresentacion.textboxAdv();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnConfirmar = new CapaPresentacion.Controles.boton();
            this.btnCancelar = new CapaPresentacion.Controles.boton();
            this.label40 = new System.Windows.Forms.Label();
            this.label41 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCUIT = new CapaPresentacion.textboxAdv();
            this.cboCondIVA = new CapaPresentacion.Controles.combo(this.components);
            this.txtRSocial = new CapaPresentacion.textboxAdv();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.panel2.Controls.Add(this.lblUsuario);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(541, 40);
            this.panel2.TabIndex = 67;
            // 
            // lblUsuario
            // 
            this.lblUsuario.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUsuario.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuario.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblUsuario.Location = new System.Drawing.Point(4, 10);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(525, 19);
            this.lblUsuario.TabIndex = 201;
            this.lblUsuario.Text = "[DOMICILIO FISCAL]";
            this.lblUsuario.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label25.ForeColor = System.Drawing.Color.Black;
            this.label25.Location = new System.Drawing.Point(10, 211);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(109, 21);
            this.label25.TabIndex = 92;
            this.label25.Text = "Codigo Postal:";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label22.ForeColor = System.Drawing.Color.Black;
            this.label22.Location = new System.Drawing.Point(310, 172);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(55, 21);
            this.label22.TabIndex = 91;
            this.label22.Text = "Depto:";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label21.ForeColor = System.Drawing.Color.Black;
            this.label21.Location = new System.Drawing.Point(171, 172);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(42, 21);
            this.label21.TabIndex = 90;
            this.label21.Text = "Piso:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(12, 170);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(55, 21);
            this.label8.TabIndex = 89;
            this.label8.Text = "Altura:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(12, 135);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 21);
            this.label7.TabIndex = 88;
            this.label7.Text = "Calle:";
            // 
            // txtCP
            // 
            this.txtCP.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtCP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCP.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCP.FocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.txtCP.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtCP.ForeColor = System.Drawing.Color.DimGray;
            this.txtCP.Location = new System.Drawing.Point(125, 209);
            this.txtCP.Name = "txtCP";
            this.txtCP.Numerico = true;
            this.txtCP.Size = new System.Drawing.Size(179, 29);
            this.txtCP.TabIndex = 7;
            this.txtCP.Tag = "\"\"";
            this.txtCP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtDepto
            // 
            this.txtDepto.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtDepto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDepto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDepto.FocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.txtDepto.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtDepto.ForeColor = System.Drawing.Color.DimGray;
            this.txtDepto.Location = new System.Drawing.Point(371, 170);
            this.txtDepto.Name = "txtDepto";
            this.txtDepto.Numerico = false;
            this.txtDepto.Size = new System.Drawing.Size(158, 29);
            this.txtDepto.TabIndex = 6;
            this.txtDepto.Tag = "\"\"";
            this.txtDepto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtPiso
            // 
            this.txtPiso.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtPiso.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPiso.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPiso.FocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.txtPiso.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtPiso.ForeColor = System.Drawing.Color.DimGray;
            this.txtPiso.Location = new System.Drawing.Point(219, 170);
            this.txtPiso.Name = "txtPiso";
            this.txtPiso.Numerico = false;
            this.txtPiso.Size = new System.Drawing.Size(85, 29);
            this.txtPiso.TabIndex = 5;
            this.txtPiso.Tag = "\"\"";
            this.txtPiso.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtAltura
            // 
            this.txtAltura.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtAltura.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAltura.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAltura.FocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.txtAltura.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtAltura.ForeColor = System.Drawing.Color.DimGray;
            this.txtAltura.Location = new System.Drawing.Point(95, 170);
            this.txtAltura.Name = "txtAltura";
            this.txtAltura.Numerico = true;
            this.txtAltura.Size = new System.Drawing.Size(63, 29);
            this.txtAltura.TabIndex = 4;
            this.txtAltura.Tag = "\"\"";
            this.txtAltura.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtCalle
            // 
            this.txtCalle.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtCalle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCalle.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCalle.FocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.txtCalle.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtCalle.ForeColor = System.Drawing.Color.DimGray;
            this.txtCalle.Location = new System.Drawing.Point(95, 135);
            this.txtCalle.Name = "txtCalle";
            this.txtCalle.Numerico = false;
            this.txtCalle.Size = new System.Drawing.Size(434, 29);
            this.txtCalle.TabIndex = 3;
            this.txtCalle.Tag = "\"0\"";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.Location = new System.Drawing.Point(0, 244);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(549, 1);
            this.panel1.TabIndex = 126;
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConfirmar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnConfirmar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConfirmar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnConfirmar.FlatAppearance.BorderSize = 0;
            this.btnConfirmar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnConfirmar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnConfirmar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirmar.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirmar.ForeColor = System.Drawing.Color.White;
            this.btnConfirmar.Image = global::CapaPresentacion.Properties.Resources.Save_32;
            this.btnConfirmar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnConfirmar.Location = new System.Drawing.Point(344, 251);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(91, 30);
            this.btnConfirmar.TabIndex = 8;
            this.btnConfirmar.Text = "Guardar";
            this.btnConfirmar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConfirmar.UseVisualStyleBackColor = false;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Image = global::CapaPresentacion.Properties.Resources.Command_Redo_32;
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.Location = new System.Drawing.Point(438, 251);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(91, 30);
            this.btnCancelar.TabIndex = 9;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label40.ForeColor = System.Drawing.Color.Black;
            this.label40.Location = new System.Drawing.Point(319, 100);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(46, 21);
            this.label40.TabIndex = 134;
            this.label40.Text = "CUIT:";
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label41.ForeColor = System.Drawing.Color.Black;
            this.label41.Location = new System.Drawing.Point(10, 100);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(132, 21);
            this.label41.TabIndex = 133;
            this.label41.Text = "Condicion de IVA:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(9, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 21);
            this.label3.TabIndex = 132;
            this.label3.Text = "R. Social:";
            // 
            // txtCUIT
            // 
            this.txtCUIT.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtCUIT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCUIT.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCUIT.FocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.txtCUIT.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtCUIT.ForeColor = System.Drawing.Color.DimGray;
            this.txtCUIT.Location = new System.Drawing.Point(371, 98);
            this.txtCUIT.Name = "txtCUIT";
            this.txtCUIT.Numerico = true;
            this.txtCUIT.Size = new System.Drawing.Size(158, 29);
            this.txtCUIT.TabIndex = 2;
            this.txtCUIT.Tag = "\"\"";
            this.txtCUIT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cboCondIVA
            // 
            this.cboCondIVA.BorderColor = System.Drawing.Color.Gainsboro;
            this.cboCondIVA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCondIVA.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboCondIVA.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cboCondIVA.FormattingEnabled = true;
            this.cboCondIVA.Items.AddRange(new object[] {
            "DNI",
            "CUIT",
            "CUIL"});
            this.cboCondIVA.Location = new System.Drawing.Point(148, 98);
            this.cboCondIVA.Name = "cboCondIVA";
            this.cboCondIVA.Size = new System.Drawing.Size(149, 29);
            this.cboCondIVA.TabIndex = 1;
            // 
            // txtRSocial
            // 
            this.txtRSocial.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtRSocial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRSocial.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtRSocial.FocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.txtRSocial.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtRSocial.ForeColor = System.Drawing.Color.DimGray;
            this.txtRSocial.Location = new System.Drawing.Point(95, 58);
            this.txtRSocial.Name = "txtRSocial";
            this.txtRSocial.Numerico = false;
            this.txtRSocial.Size = new System.Drawing.Size(434, 29);
            this.txtRSocial.TabIndex = 0;
            this.txtRSocial.Tag = "\"\"";
            // 
            // ABMUsuarios_LocacionFiscal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(250)))), ((int)(((byte)(251)))));
            this.ClientSize = new System.Drawing.Size(541, 288);
            this.Controls.Add(this.label40);
            this.Controls.Add(this.label41);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtCUIT);
            this.Controls.Add(this.cboCondIVA);
            this.Controls.Add(this.txtRSocial);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtCP);
            this.Controls.Add(this.txtDepto);
            this.Controls.Add(this.txtPiso);
            this.Controls.Add(this.txtAltura);
            this.Controls.Add(this.txtCalle);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "ABMUsuarios_LocacionFiscal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.ABMLocacionF_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ABMUsuarios_LocacionFiscal_KeyDown);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private textboxAdv txtCP;
        private textboxAdv txtDepto;
        private textboxAdv txtPiso;
        private textboxAdv txtAltura;
        private textboxAdv txtCalle;
        private System.Windows.Forms.Panel panel1;
        private Controles.boton btnConfirmar;
        private Controles.boton btnCancelar;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.Label label3;
        private textboxAdv txtCUIT;
        private Controles.combo cboCondIVA;
        private textboxAdv txtRSocial;
    }
}