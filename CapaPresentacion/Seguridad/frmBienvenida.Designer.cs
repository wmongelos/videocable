
namespace CapaPresentacion.Seguridad
{
    partial class frmBienvenida
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.imgIzq = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.timerInicio = new System.Windows.Forms.Timer(this.components);
            this.timerFinal = new System.Windows.Forms.Timer(this.components);
            this.pbDatos = new System.Windows.Forms.ProgressBar();
            this.lblDatos = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.imgIzq)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Location = new System.Drawing.Point(327, 128);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(741, 1);
            this.panel1.TabIndex = 2;
            // 
            // imgIzq
            // 
            this.imgIzq.BackColor = System.Drawing.Color.White;
            this.imgIzq.Dock = System.Windows.Forms.DockStyle.Left;
            this.imgIzq.Location = new System.Drawing.Point(0, 0);
            this.imgIzq.Name = "imgIzq";
            this.imgIzq.Size = new System.Drawing.Size(321, 352);
            this.imgIzq.TabIndex = 1;
            this.imgIzq.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Light", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(445, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(525, 40);
            this.label2.TabIndex = 5;
            this.label2.Text = "Gestión Integral de Empresas de Servicios";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Light", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(661, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 50);
            this.label3.TabIndex = 4;
            this.label3.Text = "GIES";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Light", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(327, 146);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(192, 37);
            this.label1.TabIndex = 6;
            this.label1.Text = "BIENVENIDO/A";
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Font = new System.Drawing.Font("Segoe UI Light", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuario.ForeColor = System.Drawing.Color.White;
            this.lblUsuario.Location = new System.Drawing.Point(514, 214);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(106, 30);
            this.lblUsuario.TabIndex = 7;
            this.lblUsuario.Text = "UserName";
            // 
            // timerInicio
            // 
            this.timerInicio.Interval = 10;
            this.timerInicio.Tick += new System.EventHandler(this.timerInicio_Tick);
            // 
            // timerFinal
            // 
            this.timerFinal.Interval = 30;
            this.timerFinal.Tick += new System.EventHandler(this.timerFinal_Tick);
            // 
            // pbDatos
            // 
            this.pbDatos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbDatos.Location = new System.Drawing.Point(343, 265);
            this.pbDatos.Name = "pbDatos";
            this.pbDatos.Size = new System.Drawing.Size(725, 23);
            this.pbDatos.TabIndex = 9;
            // 
            // lblDatos
            // 
            this.lblDatos.AutoSize = true;
            this.lblDatos.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDatos.ForeColor = System.Drawing.Color.White;
            this.lblDatos.Location = new System.Drawing.Point(627, 300);
            this.lblDatos.Name = "lblDatos";
            this.lblDatos.Size = new System.Drawing.Size(79, 21);
            this.lblDatos.TabIndex = 10;
            this.lblDatos.Text = "UserName";
            // 
            // frmBienvenida
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.ClientSize = new System.Drawing.Size(1071, 352);
            this.Controls.Add(this.lblDatos);
            this.Controls.Add(this.pbDatos);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.imgIzq);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmBienvenida";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmBienvenida";
            this.Load += new System.EventHandler(this.frmBienvenida_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imgIzq)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox imgIzq;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Timer timerInicio;
        private System.Windows.Forms.Timer timerFinal;
        private System.Windows.Forms.ProgressBar pbDatos;
        private System.Windows.Forms.Label lblDatos;
    }
}