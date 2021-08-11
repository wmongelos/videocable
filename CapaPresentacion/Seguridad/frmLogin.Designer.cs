namespace CapaPresentacion
{
    partial class frmLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblAppName = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbPuntos_de_Cobro = new System.Windows.Forms.Label();
            this.lbArea = new System.Windows.Forms.Label();
            this.lbNombre = new System.Windows.Forms.Label();
            this.cboPuntosCobros = new CapaPresentacion.Controles.combo(this.components);
            this.btnIngresar = new CapaPresentacion.Controles.boton();
            this.txtClave = new CapaPresentacion.textboxAdv();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.panel1.Controls.Add(this.lblAppName);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(361, 275);
            this.panel1.TabIndex = 4;
            // 
            // lblAppName
            // 
            this.lblAppName.Font = new System.Drawing.Font("Segoe UI Light", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAppName.ForeColor = System.Drawing.Color.White;
            this.lblAppName.Location = new System.Drawing.Point(3, 106);
            this.lblAppName.Name = "lblAppName";
            this.lblAppName.Size = new System.Drawing.Size(358, 37);
            this.lblAppName.TabIndex = 5;
            this.lblAppName.Text = "SERVICIOS IT";
            this.lblAppName.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.cboPuntosCobros);
            this.panel2.Controls.Add(this.lbPuntos_de_Cobro);
            this.panel2.Controls.Add(this.lbArea);
            this.panel2.Controls.Add(this.lbNombre);
            this.panel2.Controls.Add(this.btnIngresar);
            this.panel2.Controls.Add(this.txtClave);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 275);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(361, 253);
            this.panel2.TabIndex = 5;
            // 
            // lbPuntos_de_Cobro
            // 
            this.lbPuntos_de_Cobro.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPuntos_de_Cobro.ForeColor = System.Drawing.Color.DimGray;
            this.lbPuntos_de_Cobro.Location = new System.Drawing.Point(-2, 178);
            this.lbPuntos_de_Cobro.Name = "lbPuntos_de_Cobro";
            this.lbPuntos_de_Cobro.Size = new System.Drawing.Size(358, 16);
            this.lbPuntos_de_Cobro.TabIndex = 8;
            this.lbPuntos_de_Cobro.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbArea
            // 
            this.lbArea.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbArea.ForeColor = System.Drawing.Color.DimGray;
            this.lbArea.Location = new System.Drawing.Point(0, 162);
            this.lbArea.Name = "lbArea";
            this.lbArea.Size = new System.Drawing.Size(358, 16);
            this.lbArea.TabIndex = 7;
            this.lbArea.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbNombre
            // 
            this.lbNombre.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNombre.ForeColor = System.Drawing.Color.Black;
            this.lbNombre.Location = new System.Drawing.Point(-2, 130);
            this.lbNombre.Name = "lbNombre";
            this.lbNombre.Size = new System.Drawing.Size(358, 28);
            this.lbNombre.TabIndex = 6;
            this.lbNombre.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cboPuntosCobros
            // 
            this.cboPuntosCobros.BorderColor = System.Drawing.Color.Gray;
            this.cboPuntosCobros.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPuntosCobros.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboPuntosCobros.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboPuntosCobros.FormattingEnabled = true;
            this.cboPuntosCobros.Location = new System.Drawing.Point(62, 79);
            this.cboPuntosCobros.Name = "cboPuntosCobros";
            this.cboPuntosCobros.Size = new System.Drawing.Size(235, 29);
            this.cboPuntosCobros.TabIndex = 4;
            this.cboPuntosCobros.Visible = false;
            this.cboPuntosCobros.Enter += new System.EventHandler(this.cboPuntosCobros_Enter);
            // 
            // btnIngresar
            // 
            this.btnIngresar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnIngresar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnIngresar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnIngresar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            this.btnIngresar.FlatAppearance.BorderSize = 0;
            this.btnIngresar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            this.btnIngresar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            this.btnIngresar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIngresar.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIngresar.ForeColor = System.Drawing.Color.White;
            this.btnIngresar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnIngresar.Location = new System.Drawing.Point(0, 206);
            this.btnIngresar.Name = "btnIngresar";
            this.btnIngresar.Size = new System.Drawing.Size(359, 45);
            this.btnIngresar.TabIndex = 5;
            this.btnIngresar.Text = "INGRESAR";
            this.btnIngresar.UseVisualStyleBackColor = false;
            this.btnIngresar.Click += new System.EventHandler(this.btnIngresar_Click);
            // 
            // txtClave
            // 
            this.txtClave.BorderColor = System.Drawing.Color.Gray;
            this.txtClave.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtClave.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtClave.FocusColor = System.Drawing.Color.Empty;
            this.txtClave.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtClave.Location = new System.Drawing.Point(62, 25);
            this.txtClave.Name = "txtClave";
            this.txtClave.Numerico = false;
            this.txtClave.PasswordChar = '•';
            this.txtClave.Size = new System.Drawing.Size(235, 29);
            this.txtClave.TabIndex = 3;
            this.txtClave.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtClave.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtClave_KeyPress);
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(361, 528);
            this.ControlBox = false;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmLogin";
            this.Load += new System.EventHandler(this.frmLogin_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmLogin_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblAppName;
        private System.Windows.Forms.Panel panel2;
        private Controles.boton btnIngresar;
        private textboxAdv txtClave;
        private System.Windows.Forms.Label lbNombre;
        private System.Windows.Forms.Label lbArea;
        private System.Windows.Forms.Label lbPuntos_de_Cobro;
        private Controles.combo cboPuntosCobros;
    }
}