namespace CapaPresentacion
{
    partial class frmCobradoresPagosUsuarios
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
            this.txtrecibo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtrendido = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtsaldo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCodUsuario = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblCodusuario = new System.Windows.Forms.Label();
            this.btnBuscar = new CapaPresentacion.Controles.boton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lblusuario = new System.Windows.Forms.Label();
            this.btnactualizarpago = new CapaPresentacion.Controles.boton();
            this.label4 = new System.Windows.Forms.Label();
            this.txtReciboNro = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.btnCancelar = new CapaPresentacion.Controles.boton();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.lbCuenta = new System.Windows.Forms.Label();
            this.txtImporte = new System.Windows.Forms.TextBox();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgReturn)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.panel3.Controls.Add(this.imgReturn);
            this.panel3.Controls.Add(this.lblTituloHeader);
            this.panel3.Controls.Add(this.txtrecibo);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.txtrendido);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.txtsaldo);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(713, 123);
            this.panel3.TabIndex = 91;
            // 
            // imgReturn
            // 
            this.imgReturn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.imgReturn.Image = global::CapaPresentacion.Properties.Resources.Left_Arrow_32;
            this.imgReturn.Location = new System.Drawing.Point(15, 44);
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
            this.lblTituloHeader.Location = new System.Drawing.Point(53, 49);
            this.lblTituloHeader.Name = "lblTituloHeader";
            this.lblTituloHeader.Size = new System.Drawing.Size(174, 23);
            this.lblTituloHeader.TabIndex = 31;
            this.lblTituloHeader.Text = "Registrar Pago";
            // 
            // txtrecibo
            // 
            this.txtrecibo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.txtrecibo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtrecibo.Enabled = false;
            this.txtrecibo.Font = new System.Drawing.Font("Segoe UI Light", 12F);
            this.txtrecibo.ForeColor = System.Drawing.Color.White;
            this.txtrecibo.Location = new System.Drawing.Point(556, 18);
            this.txtrecibo.Name = "txtrecibo";
            this.txtrecibo.ReadOnly = true;
            this.txtrecibo.Size = new System.Drawing.Size(129, 22);
            this.txtrecibo.TabIndex = 116;
            this.txtrecibo.TabStop = false;
            this.txtrecibo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Light", 12F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(441, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 21);
            this.label1.TabIndex = 113;
            this.label1.Text = "Importe recibo";
            // 
            // txtrendido
            // 
            this.txtrendido.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.txtrendido.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtrendido.Enabled = false;
            this.txtrendido.Font = new System.Drawing.Font("Segoe UI Light", 12F);
            this.txtrendido.ForeColor = System.Drawing.Color.White;
            this.txtrendido.Location = new System.Drawing.Point(556, 49);
            this.txtrendido.Name = "txtrendido";
            this.txtrendido.ReadOnly = true;
            this.txtrendido.Size = new System.Drawing.Size(129, 22);
            this.txtrendido.TabIndex = 1;
            this.txtrendido.TabStop = false;
            this.txtrendido.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Light", 12F);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(431, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 21);
            this.label2.TabIndex = 114;
            this.label2.Text = "Importe rendido";
            // 
            // txtsaldo
            // 
            this.txtsaldo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.txtsaldo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtsaldo.Enabled = false;
            this.txtsaldo.Font = new System.Drawing.Font("Segoe UI Light", 12F);
            this.txtsaldo.ForeColor = System.Drawing.Color.White;
            this.txtsaldo.Location = new System.Drawing.Point(556, 84);
            this.txtsaldo.Name = "txtsaldo";
            this.txtsaldo.ReadOnly = true;
            this.txtsaldo.Size = new System.Drawing.Size(129, 22);
            this.txtsaldo.TabIndex = 2;
            this.txtsaldo.TabStop = false;
            this.txtsaldo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Light", 12F);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(503, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 21);
            this.label3.TabIndex = 115;
            this.label3.Text = "Saldo";
            // 
            // txtCodUsuario
            // 
            this.txtCodUsuario.Font = new System.Drawing.Font("Segoe UI Light", 12F);
            this.txtCodUsuario.Location = new System.Drawing.Point(127, 146);
            this.txtCodUsuario.Name = "txtCodUsuario";
            this.txtCodUsuario.Size = new System.Drawing.Size(129, 29);
            this.txtCodUsuario.TabIndex = 0;
            this.txtCodUsuario.Enter += new System.EventHandler(this.txtCodUsuario_Enter);
            this.txtCodUsuario.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCodUsuario_KeyDown);
            this.txtCodUsuario.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodUsuario_KeyPress);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.Location = new System.Drawing.Point(0, 183);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(713, 1);
            this.panel1.TabIndex = 98;
            // 
            // lblCodusuario
            // 
            this.lblCodusuario.AutoSize = true;
            this.lblCodusuario.Font = new System.Drawing.Font("Segoe UI Light", 12F);
            this.lblCodusuario.Location = new System.Drawing.Point(25, 149);
            this.lblCodusuario.Name = "lblCodusuario";
            this.lblCodusuario.Size = new System.Drawing.Size(100, 21);
            this.lblCodusuario.TabIndex = 99;
            this.lblCodusuario.Text = "Cod. Usuario:";
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(84)))), ((int)(((byte)(101)))));
            this.btnBuscar.FlatAppearance.BorderSize = 0;
            this.btnBuscar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(84)))), ((int)(((byte)(101)))));
            this.btnBuscar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.ForeColor = System.Drawing.Color.White;
            this.btnBuscar.Image = global::CapaPresentacion.Properties.Resources.lupa;
            this.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBuscar.Location = new System.Drawing.Point(274, 143);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(104, 35);
            this.btnBuscar.TabIndex = 1;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.Gainsboro;
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Location = new System.Drawing.Point(0, 231);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(713, 1);
            this.panel2.TabIndex = 99;
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.BackColor = System.Drawing.Color.Gainsboro;
            this.panel4.Location = new System.Drawing.Point(0, 94);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(713, 1);
            this.panel4.TabIndex = 100;
            // 
            // lblusuario
            // 
            this.lblusuario.AutoSize = true;
            this.lblusuario.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblusuario.Location = new System.Drawing.Point(25, 198);
            this.lblusuario.Name = "lblusuario";
            this.lblusuario.Size = new System.Drawing.Size(65, 21);
            this.lblusuario.TabIndex = 119;
            this.lblusuario.Text = "Usuario";
            this.lblusuario.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnactualizarpago
            // 
            this.btnactualizarpago.BackColor = System.Drawing.Color.SteelBlue;
            this.btnactualizarpago.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnactualizarpago.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(84)))), ((int)(((byte)(101)))));
            this.btnactualizarpago.FlatAppearance.BorderSize = 0;
            this.btnactualizarpago.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(84)))), ((int)(((byte)(101)))));
            this.btnactualizarpago.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            this.btnactualizarpago.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnactualizarpago.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnactualizarpago.ForeColor = System.Drawing.Color.White;
            this.btnactualizarpago.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnactualizarpago.Location = new System.Drawing.Point(445, 355);
            this.btnactualizarpago.Name = "btnactualizarpago";
            this.btnactualizarpago.Size = new System.Drawing.Size(138, 35);
            this.btnactualizarpago.TabIndex = 4;
            this.btnactualizarpago.Text = "Registrar Pago";
            this.btnactualizarpago.UseVisualStyleBackColor = false;
            this.btnactualizarpago.Click += new System.EventHandler(this.btnactualizarpago_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Light", 12F);
            this.label4.Location = new System.Drawing.Point(492, 271);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 21);
            this.label4.TabIndex = 123;
            this.label4.Text = "Importe:";
            // 
            // txtReciboNro
            // 
            this.txtReciboNro.Font = new System.Drawing.Font("Segoe UI Light", 12F);
            this.txtReciboNro.Location = new System.Drawing.Point(127, 267);
            this.txtReciboNro.Name = "txtReciboNro";
            this.txtReciboNro.Size = new System.Drawing.Size(129, 29);
            this.txtReciboNro.TabIndex = 1;
            this.txtReciboNro.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtReciboNro.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtReciboNro_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Light", 12F);
            this.label5.Location = new System.Drawing.Point(29, 271);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 21);
            this.label5.TabIndex = 125;
            this.label5.Text = "Nro. Recibo:";
            // 
            // dtpFecha
            // 
            this.dtpFecha.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFecha.Location = new System.Drawing.Point(319, 267);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(121, 29);
            this.dtpFecha.TabIndex = 2;
            this.dtpFecha.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dtpFecha_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(266, 271);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 21);
            this.label6.TabIndex = 296;
            this.label6.Text = "Fecha:";
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(84)))), ((int)(((byte)(101)))));
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(84)))), ((int)(((byte)(101)))));
            this.btnCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.Location = new System.Drawing.Point(589, 355);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(104, 35);
            this.btnCancelar.TabIndex = 5;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // panel5
            // 
            this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel5.BackColor = System.Drawing.Color.Gainsboro;
            this.panel5.Controls.Add(this.panel6);
            this.panel5.Location = new System.Drawing.Point(2, 328);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(713, 1);
            this.panel5.TabIndex = 101;
            // 
            // panel6
            // 
            this.panel6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel6.BackColor = System.Drawing.Color.Gainsboro;
            this.panel6.Location = new System.Drawing.Point(0, 94);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(713, 1);
            this.panel6.TabIndex = 100;
            // 
            // lbCuenta
            // 
            this.lbCuenta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbCuenta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbCuenta.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCuenta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbCuenta.Location = new System.Drawing.Point(630, 138);
            this.lbCuenta.Name = "lbCuenta";
            this.lbCuenta.Size = new System.Drawing.Size(38, 32);
            this.lbCuenta.TabIndex = 297;
            this.lbCuenta.Text = "1";
            this.lbCuenta.Visible = false;
            // 
            // txtImporte
            // 
            this.txtImporte.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtImporte.Location = new System.Drawing.Point(566, 268);
            this.txtImporte.Name = "txtImporte";
            this.txtImporte.Size = new System.Drawing.Size(127, 29);
            this.txtImporte.TabIndex = 298;
            // 
            // frmCobradoresPagosUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(713, 403);
            this.Controls.Add(this.txtImporte);
            this.Controls.Add(this.lbCuenta);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.dtpFecha);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtReciboNro);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnactualizarpago);
            this.Controls.Add(this.lblusuario);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.lblCodusuario);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txtCodUsuario);
            this.Controls.Add(this.panel3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "frmCobradoresPagosUsuarios";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmCobradoresPagosUsuarios";
            this.Activated += new System.EventHandler(this.frmCobradoresPagosUsuarios_Activated);
            this.Load += new System.EventHandler(this.frmCobradoresPagosUsuarios_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmCobradoresPagosUsuarios_KeyDown);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgReturn)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox imgReturn;
        private System.Windows.Forms.Label lblTituloHeader;
        private System.Windows.Forms.TextBox txtCodUsuario;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblCodusuario;
        private Controles.boton btnBuscar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtrecibo;
        private System.Windows.Forms.TextBox txtrendido;
        private System.Windows.Forms.TextBox txtsaldo;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblusuario;
        private Controles.boton btnactualizarpago;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtReciboNro;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Label label6;
        private Controles.boton btnCancelar;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label lbCuenta;
        private System.Windows.Forms.TextBox txtImporte;
    }
}