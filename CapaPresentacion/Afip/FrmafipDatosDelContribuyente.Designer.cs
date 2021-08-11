namespace CapaPresentacion.Afip
{
    partial class frmafipDatosDelContribuyente
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
            this.lblTituloHeader = new System.Windows.Forms.Label();
            this.pnlTitulo = new System.Windows.Forms.Panel();
            this.imgReturn = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbnombreusu = new System.Windows.Forms.Label();
            this.lbapellidousu = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.lbcodigo = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbLocalidad = new System.Windows.Forms.Label();
            this.lbNombre = new System.Windows.Forms.Label();
            this.lbApellido = new System.Windows.Forms.Label();
            this.lbtipopersona = new System.Windows.Forms.Label();
            this.lbestado = new System.Windows.Forms.Label();
            this.lbDireccion = new System.Windows.Forms.Label();
            this.lbclientecuit = new System.Windows.Forms.Label();
            this.btnConstancia = new CapaPresentacion.Controles.boton();
            this.pnlTitulo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgReturn)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTituloHeader
            // 
            this.lblTituloHeader.Font = new System.Drawing.Font("Segoe UI Light", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloHeader.ForeColor = System.Drawing.Color.White;
            this.lblTituloHeader.Location = new System.Drawing.Point(51, 30);
            this.lblTituloHeader.Name = "lblTituloHeader";
            this.lblTituloHeader.Size = new System.Drawing.Size(295, 23);
            this.lblTituloHeader.TabIndex = 205;
            this.lblTituloHeader.Text = "Búsqueda de usuarios";
            // 
            // pnlTitulo
            // 
            this.pnlTitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.pnlTitulo.Controls.Add(this.imgReturn);
            this.pnlTitulo.Controls.Add(this.lblTituloHeader);
            this.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTitulo.Location = new System.Drawing.Point(0, 0);
            this.pnlTitulo.Name = "pnlTitulo";
            this.pnlTitulo.Size = new System.Drawing.Size(1002, 80);
            this.pnlTitulo.TabIndex = 2;
            // 
            // imgReturn
            // 
            this.imgReturn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.imgReturn.Image = global::CapaPresentacion.Properties.Resources.Left_Arrow_32;
            this.imgReturn.Location = new System.Drawing.Point(13, 25);
            this.imgReturn.Name = "imgReturn";
            this.imgReturn.Size = new System.Drawing.Size(32, 32);
            this.imgReturn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgReturn.TabIndex = 206;
            this.imgReturn.TabStop = false;
            this.imgReturn.Click += new System.EventHandler(this.imgReturn_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.lbnombreusu);
            this.panel1.Controls.Add(this.lbapellidousu);
            this.panel1.Controls.Add(this.label16);
            this.panel1.Controls.Add(this.lbcodigo);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.lbLocalidad);
            this.panel1.Controls.Add(this.lbNombre);
            this.panel1.Controls.Add(this.lbApellido);
            this.panel1.Controls.Add(this.lbtipopersona);
            this.panel1.Controls.Add(this.lbestado);
            this.panel1.Controls.Add(this.lbDireccion);
            this.panel1.Controls.Add(this.lbclientecuit);
            this.panel1.Location = new System.Drawing.Point(12, 129);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(965, 221);
            this.panel1.TabIndex = 260;
            // 
            // lbnombreusu
            // 
            this.lbnombreusu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbnombreusu.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbnombreusu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.lbnombreusu.Location = new System.Drawing.Point(751, 58);
            this.lbnombreusu.Name = "lbnombreusu";
            this.lbnombreusu.Size = new System.Drawing.Size(193, 21);
            this.lbnombreusu.TabIndex = 269;
            this.lbnombreusu.Text = "-";
            // 
            // lbapellidousu
            // 
            this.lbapellidousu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbapellidousu.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbapellidousu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.lbapellidousu.Location = new System.Drawing.Point(751, 37);
            this.lbapellidousu.Name = "lbapellidousu";
            this.lbapellidousu.Size = new System.Drawing.Size(193, 21);
            this.lbapellidousu.TabIndex = 268;
            this.lbapellidousu.Text = "-";
            // 
            // label16
            // 
            this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.Black;
            this.label16.Location = new System.Drawing.Point(674, 14);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(71, 21);
            this.label16.TabIndex = 267;
            this.label16.Text = "Usuario :";
            this.label16.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lbcodigo
            // 
            this.lbcodigo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbcodigo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbcodigo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.lbcodigo.Location = new System.Drawing.Point(751, 14);
            this.lbcodigo.Name = "lbcodigo";
            this.lbcodigo.Size = new System.Drawing.Size(193, 21);
            this.lbcodigo.TabIndex = 266;
            this.lbcodigo.Text = "-";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(56, 139);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(83, 21);
            this.label9.TabIndex = 265;
            this.label9.Text = "Localidad :";
            this.label9.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(57, 108);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(82, 21);
            this.label8.TabIndex = 264;
            this.label8.Text = "Direccion :";
            this.label8.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(76, 82);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 21);
            this.label7.TabIndex = 263;
            this.label7.Text = "Estado :";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(23, 58);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(116, 21);
            this.label6.TabIndex = 262;
            this.label6.Text = "Contribuyente :";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(64, 7);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 21);
            this.label5.TabIndex = 261;
            this.label5.Text = "Nombre :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(65, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 21);
            this.label4.TabIndex = 260;
            this.label4.Text = "Apellido :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lbLocalidad
            // 
            this.lbLocalidad.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLocalidad.ForeColor = System.Drawing.Color.DimGray;
            this.lbLocalidad.Location = new System.Drawing.Point(154, 141);
            this.lbLocalidad.Name = "lbLocalidad";
            this.lbLocalidad.Size = new System.Drawing.Size(296, 21);
            this.lbLocalidad.TabIndex = 253;
            this.lbLocalidad.Text = "-";
            // 
            // lbNombre
            // 
            this.lbNombre.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNombre.ForeColor = System.Drawing.Color.DimGray;
            this.lbNombre.Location = new System.Drawing.Point(154, 11);
            this.lbNombre.Name = "lbNombre";
            this.lbNombre.Size = new System.Drawing.Size(289, 21);
            this.lbNombre.TabIndex = 248;
            this.lbNombre.Text = "-";
            // 
            // lbApellido
            // 
            this.lbApellido.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbApellido.ForeColor = System.Drawing.Color.DimGray;
            this.lbApellido.Location = new System.Drawing.Point(154, 35);
            this.lbApellido.Name = "lbApellido";
            this.lbApellido.Size = new System.Drawing.Size(289, 21);
            this.lbApellido.TabIndex = 249;
            this.lbApellido.Text = "-";
            // 
            // lbtipopersona
            // 
            this.lbtipopersona.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbtipopersona.ForeColor = System.Drawing.Color.DimGray;
            this.lbtipopersona.Location = new System.Drawing.Point(351, 62);
            this.lbtipopersona.Name = "lbtipopersona";
            this.lbtipopersona.Size = new System.Drawing.Size(205, 21);
            this.lbtipopersona.TabIndex = 250;
            this.lbtipopersona.Text = "-";
            // 
            // lbestado
            // 
            this.lbestado.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbestado.ForeColor = System.Drawing.Color.DimGray;
            this.lbestado.Location = new System.Drawing.Point(154, 83);
            this.lbestado.Name = "lbestado";
            this.lbestado.Size = new System.Drawing.Size(289, 21);
            this.lbestado.TabIndex = 251;
            this.lbestado.Text = "-";
            // 
            // lbDireccion
            // 
            this.lbDireccion.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDireccion.ForeColor = System.Drawing.Color.DimGray;
            this.lbDireccion.Location = new System.Drawing.Point(154, 111);
            this.lbDireccion.Name = "lbDireccion";
            this.lbDireccion.Size = new System.Drawing.Size(289, 21);
            this.lbDireccion.TabIndex = 252;
            this.lbDireccion.Text = "-";
            // 
            // lbclientecuit
            // 
            this.lbclientecuit.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbclientecuit.ForeColor = System.Drawing.Color.Black;
            this.lbclientecuit.Location = new System.Drawing.Point(154, 62);
            this.lbclientecuit.Name = "lbclientecuit";
            this.lbclientecuit.Size = new System.Drawing.Size(191, 21);
            this.lbclientecuit.TabIndex = 236;
            this.lbclientecuit.Text = "-";
            // 
            // btnConstancia
            // 
            this.btnConstancia.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnConstancia.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConstancia.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnConstancia.FlatAppearance.BorderSize = 0;
            this.btnConstancia.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnConstancia.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnConstancia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConstancia.Font = new System.Drawing.Font("Segoe UI Light", 12F);
            this.btnConstancia.ForeColor = System.Drawing.Color.White;
            this.btnConstancia.Image = global::CapaPresentacion.Properties.Resources.Download_32;
            this.btnConstancia.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnConstancia.Location = new System.Drawing.Point(820, 83);
            this.btnConstancia.Name = "btnConstancia";
            this.btnConstancia.Size = new System.Drawing.Size(157, 40);
            this.btnConstancia.TabIndex = 261;
            this.btnConstancia.Text = "Constacia Afip";
            this.btnConstancia.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConstancia.UseVisualStyleBackColor = false;
            this.btnConstancia.Click += new System.EventHandler(this.btnConstancia_Click);
            // 
            // frmafipDatosDelContribuyente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1002, 375);
            this.Controls.Add(this.btnConstancia);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "frmafipDatosDelContribuyente";
            this.Text = "frmDatosDelContribuyente";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmDatosDelContribuyente_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmafipDatosDelContribuyente_KeyDown);
            this.pnlTitulo.ResumeLayout(false);
            this.pnlTitulo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgReturn)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTituloHeader;
        private System.Windows.Forms.Panel pnlTitulo;
        private System.Windows.Forms.PictureBox imgReturn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbnombreusu;
        private System.Windows.Forms.Label lbapellidousu;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label lbcodigo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbLocalidad;
        private System.Windows.Forms.Label lbNombre;
        private System.Windows.Forms.Label lbApellido;
        private System.Windows.Forms.Label lbtipopersona;
        private System.Windows.Forms.Label lbestado;
        private System.Windows.Forms.Label lbDireccion;
        private System.Windows.Forms.Label lbclientecuit;
        private Controles.boton btnConstancia;
    }
}