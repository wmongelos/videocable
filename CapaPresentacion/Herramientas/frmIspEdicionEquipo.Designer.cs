
namespace CapaPresentacion.Herramientas
{
    partial class frmIspEdicionEquipo
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
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnCancelar = new CapaPresentacion.Controles.boton();
            this.btnTerminar = new CapaPresentacion.Controles.boton();
            this.txtModelo = new CapaPresentacion.textboxAdv();
            this.txtMarca = new CapaPresentacion.textboxAdv();
            this.txtSerial = new CapaPresentacion.textboxAdv();
            this.txtMac = new CapaPresentacion.textboxAdv();
            this.txtIp = new CapaPresentacion.textboxAdv();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label2.Location = new System.Drawing.Point(16, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 21);
            this.label2.TabIndex = 345;
            this.label2.Text = "Marca:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtModelo);
            this.groupBox1.Controls.Add(this.txtMarca);
            this.groupBox1.Controls.Add(this.txtSerial);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtMac);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtIp);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(30, -1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(345, 235);
            this.groupBox1.TabIndex = 346;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos del equipo";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label5.Location = new System.Drawing.Point(20, 195);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 21);
            this.label5.TabIndex = 353;
            this.label5.Text = "Serial:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label4.Location = new System.Drawing.Point(25, 158);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 21);
            this.label4.TabIndex = 351;
            this.label4.Text = "Mac:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label3.Location = new System.Drawing.Point(46, 121);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 21);
            this.label3.TabIndex = 349;
            this.label3.Text = "Ip:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label1.Location = new System.Drawing.Point(6, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 21);
            this.label1.TabIndex = 347;
            this.label1.Text = "Modelo:";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
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
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Image = global::CapaPresentacion.Properties.Resources.Command_Undo_32;
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.Location = new System.Drawing.Point(115, 263);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(118, 31);
            this.btnCancelar.TabIndex = 6;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnTerminar
            // 
            this.btnTerminar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTerminar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnTerminar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTerminar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnTerminar.FlatAppearance.BorderSize = 0;
            this.btnTerminar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnTerminar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnTerminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTerminar.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnTerminar.ForeColor = System.Drawing.Color.White;
            this.btnTerminar.Image = global::CapaPresentacion.Properties.Resources.Save_32;
            this.btnTerminar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnTerminar.Location = new System.Drawing.Point(237, 263);
            this.btnTerminar.Margin = new System.Windows.Forms.Padding(2);
            this.btnTerminar.Name = "btnTerminar";
            this.btnTerminar.Size = new System.Drawing.Size(118, 31);
            this.btnTerminar.TabIndex = 5;
            this.btnTerminar.Text = "Guardar";
            this.btnTerminar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTerminar.UseVisualStyleBackColor = false;
            this.btnTerminar.Click += new System.EventHandler(this.btnTerminar_Click);
            // 
            // txtModelo
            // 
            this.txtModelo.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtModelo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtModelo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtModelo.FocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            this.txtModelo.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.txtModelo.ForeColor = System.Drawing.Color.DimGray;
            this.txtModelo.Location = new System.Drawing.Point(78, 81);
            this.txtModelo.Name = "txtModelo";
            this.txtModelo.Numerico = false;
            this.txtModelo.Size = new System.Drawing.Size(247, 31);
            this.txtModelo.TabIndex = 1;
            this.txtModelo.Tag = "\"0\"";
            this.txtModelo.Enter += new System.EventHandler(this.txtModelo_Enter);
            // 
            // txtMarca
            // 
            this.txtMarca.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtMarca.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMarca.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMarca.FocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            this.txtMarca.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.txtMarca.ForeColor = System.Drawing.Color.DimGray;
            this.txtMarca.Location = new System.Drawing.Point(78, 44);
            this.txtMarca.Name = "txtMarca";
            this.txtMarca.Numerico = false;
            this.txtMarca.Size = new System.Drawing.Size(247, 31);
            this.txtMarca.TabIndex = 0;
            this.txtMarca.Tag = "\"0\"";
            this.txtMarca.Enter += new System.EventHandler(this.txtMarca_Enter);
            this.txtMarca.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMarca_KeyDown);
            this.txtMarca.Leave += new System.EventHandler(this.txtMarca_Leave);
            // 
            // txtSerial
            // 
            this.txtSerial.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtSerial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSerial.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSerial.FocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            this.txtSerial.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.txtSerial.ForeColor = System.Drawing.Color.DimGray;
            this.txtSerial.Location = new System.Drawing.Point(78, 192);
            this.txtSerial.Name = "txtSerial";
            this.txtSerial.Numerico = false;
            this.txtSerial.Size = new System.Drawing.Size(247, 31);
            this.txtSerial.TabIndex = 4;
            this.txtSerial.Tag = "\"0\"";
            // 
            // txtMac
            // 
            this.txtMac.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtMac.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMac.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMac.FocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            this.txtMac.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.txtMac.ForeColor = System.Drawing.Color.DimGray;
            this.txtMac.Location = new System.Drawing.Point(78, 155);
            this.txtMac.Name = "txtMac";
            this.txtMac.Numerico = false;
            this.txtMac.Size = new System.Drawing.Size(247, 31);
            this.txtMac.TabIndex = 3;
            this.txtMac.Tag = "\"0\"";
            // 
            // txtIp
            // 
            this.txtIp.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtIp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIp.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtIp.FocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            this.txtIp.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.txtIp.ForeColor = System.Drawing.Color.DimGray;
            this.txtIp.Location = new System.Drawing.Point(78, 118);
            this.txtIp.Name = "txtIp";
            this.txtIp.Numerico = false;
            this.txtIp.Size = new System.Drawing.Size(247, 31);
            this.txtIp.TabIndex = 2;
            this.txtIp.Tag = "\"0\"";
            // 
            // frmIspEdicionEquipo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(387, 305);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnTerminar);
            this.Controls.Add(this.groupBox1);
            this.KeyPreview = true;
            this.Name = "frmIspEdicionEquipo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edicion de datos del equipo en ISP";
            this.Load += new System.EventHandler(this.frmIspEdicionEquipo_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private Controles.boton btnTerminar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private textboxAdv txtIp;
        private textboxAdv txtSerial;
        private System.Windows.Forms.Label label5;
        private textboxAdv txtMac;
        private System.Windows.Forms.Label label4;
        private Controles.boton btnCancelar;
        private textboxAdv txtModelo;
        private textboxAdv txtMarca;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}