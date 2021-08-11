namespace CapaPresentacion
{
    partial class frmPing
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
            this.label1 = new System.Windows.Forms.Label();
            this.lblEstado = new System.Windows.Forms.Label();
            this.boton2 = new CapaPresentacion.Controles.boton();
            this.btnOtraVez = new CapaPresentacion.Controles.boton();
            this.txtIp = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(20, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ping a";
            // 
            // lblEstado
            // 
            this.lblEstado.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstado.Location = new System.Drawing.Point(20, 50);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(514, 111);
            this.lblEstado.TabIndex = 2;
            this.lblEstado.Text = "Ping a";
            // 
            // boton2
            // 
            this.boton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.boton2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.boton2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.boton2.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.boton2.FlatAppearance.BorderSize = 0;
            this.boton2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.boton2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.boton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.boton2.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.boton2.ForeColor = System.Drawing.Color.White;
            this.boton2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.boton2.Location = new System.Drawing.Point(295, 174);
            this.boton2.Name = "boton2";
            this.boton2.Size = new System.Drawing.Size(92, 38);
            this.boton2.TabIndex = 335;
            this.boton2.Text = "Cerrar";
            this.boton2.UseVisualStyleBackColor = false;
            this.boton2.Click += new System.EventHandler(this.boton2_Click);
            // 
            // btnOtraVez
            // 
            this.btnOtraVez.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOtraVez.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnOtraVez.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOtraVez.Enabled = false;
            this.btnOtraVez.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnOtraVez.FlatAppearance.BorderSize = 0;
            this.btnOtraVez.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnOtraVez.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnOtraVez.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOtraVez.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnOtraVez.ForeColor = System.Drawing.Color.White;
            this.btnOtraVez.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOtraVez.Location = new System.Drawing.Point(393, 174);
            this.btnOtraVez.Name = "btnOtraVez";
            this.btnOtraVez.Size = new System.Drawing.Size(141, 38);
            this.btnOtraVez.TabIndex = 334;
            this.btnOtraVez.Text = "Intentar otra vez";
            this.btnOtraVez.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOtraVez.UseVisualStyleBackColor = false;
            this.btnOtraVez.Click += new System.EventHandler(this.btnOtraVez_Click);
            // 
            // txtIp
            // 
            this.txtIp.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIp.Location = new System.Drawing.Point(91, 6);
            this.txtIp.Name = "txtIp";
            this.txtIp.Size = new System.Drawing.Size(206, 33);
            this.txtIp.TabIndex = 336;
            // 
            // frmPing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(546, 218);
            this.Controls.Add(this.txtIp);
            this.Controls.Add(this.boton2);
            this.Controls.Add(this.btnOtraVez);
            this.Controls.Add(this.lblEstado);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmPing";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Prueba de conexion";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblEstado;
        private Controles.boton btnOtraVez;
        private Controles.boton boton2;
        private System.Windows.Forms.TextBox txtIp;
    }
}