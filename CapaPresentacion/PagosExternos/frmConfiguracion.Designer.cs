
namespace CapaPresentacion.PagosExternos
{
    partial class frmConfiguracion
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
            this.pnlSuperior = new System.Windows.Forms.Panel();
            this.imgReturn = new System.Windows.Forms.PictureBox();
            this.lblTitulos = new System.Windows.Forms.Label();
            this.flpInferior = new System.Windows.Forms.FlowLayoutPanel();
            this.btnCancelar = new CapaPresentacion.Controles.boton();
            this.btnAceptar = new CapaPresentacion.Controles.boton();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.txtCPHash = new CapaPresentacion.textboxAdv();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCPIdEntidad = new CapaPresentacion.textboxAdv();
            this.label1 = new System.Windows.Forms.Label();
            this.tbControlPagos = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.txtMPCPass = new CapaPresentacion.textboxAdv();
            this.label5 = new System.Windows.Forms.Label();
            this.txtMPCUsuario = new CapaPresentacion.textboxAdv();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMPCServer = new CapaPresentacion.textboxAdv();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMPCBase = new CapaPresentacion.textboxAdv();
            this.lblDb = new System.Windows.Forms.Label();
            this.pnlSuperior.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgReturn)).BeginInit();
            this.flpInferior.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tbControlPagos.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlSuperior
            // 
            this.pnlSuperior.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.pnlSuperior.Controls.Add(this.imgReturn);
            this.pnlSuperior.Controls.Add(this.lblTitulos);
            this.pnlSuperior.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSuperior.Location = new System.Drawing.Point(0, 0);
            this.pnlSuperior.Name = "pnlSuperior";
            this.pnlSuperior.Size = new System.Drawing.Size(687, 71);
            this.pnlSuperior.TabIndex = 174;
            // 
            // imgReturn
            // 
            this.imgReturn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.imgReturn.Image = global::CapaPresentacion.Properties.Resources.Left_Arrow_32;
            this.imgReturn.Location = new System.Drawing.Point(12, 19);
            this.imgReturn.Name = "imgReturn";
            this.imgReturn.Size = new System.Drawing.Size(32, 32);
            this.imgReturn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgReturn.TabIndex = 76;
            this.imgReturn.TabStop = false;
            this.imgReturn.Click += new System.EventHandler(this.imgReturn_Click);
            // 
            // lblTitulos
            // 
            this.lblTitulos.AutoSize = true;
            this.lblTitulos.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulos.ForeColor = System.Drawing.Color.Transparent;
            this.lblTitulos.Location = new System.Drawing.Point(45, 23);
            this.lblTitulos.Name = "lblTitulos";
            this.lblTitulos.Size = new System.Drawing.Size(422, 25);
            this.lblTitulos.TabIndex = 172;
            this.lblTitulos.Text = "Configuración de plataformas de pagos externos";
            // 
            // flpInferior
            // 
            this.flpInferior.Controls.Add(this.btnCancelar);
            this.flpInferior.Controls.Add(this.btnAceptar);
            this.flpInferior.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flpInferior.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flpInferior.Location = new System.Drawing.Point(0, 363);
            this.flpInferior.Name = "flpInferior";
            this.flpInferior.Size = new System.Drawing.Size(687, 38);
            this.flpInferior.TabIndex = 175;
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
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.Location = new System.Drawing.Point(596, 3);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(88, 28);
            this.btnCancelar.TabIndex = 206;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAceptar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnAceptar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAceptar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnAceptar.FlatAppearance.BorderSize = 0;
            this.btnAceptar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnAceptar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAceptar.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAceptar.ForeColor = System.Drawing.Color.White;
            this.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAceptar.Location = new System.Drawing.Point(502, 3);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(88, 28);
            this.btnAceptar.TabIndex = 205;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = false;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txtCPHash);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.txtCPIdEntidad);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 30);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(679, 258);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Captar Pagos";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // txtCPHash
            // 
            this.txtCPHash.AccessibleName = "captarpagos";
            this.txtCPHash.BorderColor = System.Drawing.Color.Empty;
            this.txtCPHash.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCPHash.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCPHash.FocusColor = System.Drawing.Color.Empty;
            this.txtCPHash.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCPHash.Location = new System.Drawing.Point(172, 46);
            this.txtCPHash.Name = "txtCPHash";
            this.txtCPHash.Numerico = false;
            this.txtCPHash.Size = new System.Drawing.Size(494, 29);
            this.txtCPHash.TabIndex = 3;
            this.txtCPHash.Text = "0";
            this.txtCPHash.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCPHash.TextChanged += new System.EventHandler(this.txtCPHash_TextChanged);
            // 
            // label2
            // 
            this.label2.AccessibleDescription = "IdEntidad es proporcionado por CaptarPagos";
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(67, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 21);
            this.label2.TabIndex = 2;
            this.label2.Text = "Código Hash";
            // 
            // txtCPIdEntidad
            // 
            this.txtCPIdEntidad.AccessibleName = "captarpagos";
            this.txtCPIdEntidad.BorderColor = System.Drawing.Color.Empty;
            this.txtCPIdEntidad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCPIdEntidad.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCPIdEntidad.FocusColor = System.Drawing.Color.Empty;
            this.txtCPIdEntidad.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtCPIdEntidad.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            this.txtCPIdEntidad.Location = new System.Drawing.Point(172, 11);
            this.txtCPIdEntidad.Name = "txtCPIdEntidad";
            this.txtCPIdEntidad.Numerico = true;
            this.txtCPIdEntidad.Size = new System.Drawing.Size(69, 29);
            this.txtCPIdEntidad.TabIndex = 1;
            this.txtCPIdEntidad.Text = "0";
            this.txtCPIdEntidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCPIdEntidad.TextChanged += new System.EventHandler(this.txtCPIdEntidad_TextChanged);
            this.txtCPIdEntidad.Enter += new System.EventHandler(this.txtCPIdEntidad_Enter);
            // 
            // label1
            // 
            this.label1.AccessibleDescription = "IdEntidad es proporcionado por CaptarPagos";
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(158, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Número de identidad";
            // 
            // tbControlPagos
            // 
            this.tbControlPagos.Controls.Add(this.tabPage1);
            this.tbControlPagos.Controls.Add(this.tabPage2);
            this.tbControlPagos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbControlPagos.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbControlPagos.Location = new System.Drawing.Point(0, 71);
            this.tbControlPagos.Name = "tbControlPagos";
            this.tbControlPagos.SelectedIndex = 0;
            this.tbControlPagos.Size = new System.Drawing.Size(687, 292);
            this.tbControlPagos.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.txtMPCBase);
            this.tabPage2.Controls.Add(this.lblDb);
            this.tabPage2.Controls.Add(this.txtMPCPass);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.txtMPCUsuario);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.txtMPCServer);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Location = new System.Drawing.Point(4, 30);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(679, 258);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "MercadoPago";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // txtMPCPass
            // 
            this.txtMPCPass.AccessibleName = "captarpagos";
            this.txtMPCPass.BorderColor = System.Drawing.Color.Empty;
            this.txtMPCPass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMPCPass.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMPCPass.FocusColor = System.Drawing.Color.Empty;
            this.txtMPCPass.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMPCPass.Location = new System.Drawing.Point(194, 101);
            this.txtMPCPass.Name = "txtMPCPass";
            this.txtMPCPass.Numerico = false;
            this.txtMPCPass.Size = new System.Drawing.Size(186, 29);
            this.txtMPCPass.TabIndex = 9;
            this.txtMPCPass.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtMPCPass.TextChanged += new System.EventHandler(this.txtPass_TextChanged);
            // 
            // label5
            // 
            this.label5.AccessibleDescription = "IdEntidad es proporcionado por CaptarPagos";
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(96, 103);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 21);
            this.label5.TabIndex = 8;
            this.label5.Text = "Contraseña:";
            // 
            // txtMPCUsuario
            // 
            this.txtMPCUsuario.AccessibleName = "captarpagos";
            this.txtMPCUsuario.BorderColor = System.Drawing.Color.Empty;
            this.txtMPCUsuario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMPCUsuario.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMPCUsuario.FocusColor = System.Drawing.Color.Empty;
            this.txtMPCUsuario.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMPCUsuario.Location = new System.Drawing.Point(194, 66);
            this.txtMPCUsuario.Name = "txtMPCUsuario";
            this.txtMPCUsuario.Numerico = false;
            this.txtMPCUsuario.Size = new System.Drawing.Size(186, 29);
            this.txtMPCUsuario.TabIndex = 7;
            this.txtMPCUsuario.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtMPCUsuario.TextChanged += new System.EventHandler(this.txtUsuario_TextChanged);
            // 
            // label4
            // 
            this.label4.AccessibleDescription = "IdEntidad es proporcionado por CaptarPagos";
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(121, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 21);
            this.label4.TabIndex = 6;
            this.label4.Text = "Usuario:";
            // 
            // txtMPCServer
            // 
            this.txtMPCServer.AccessibleName = "captarpagos";
            this.txtMPCServer.BackColor = System.Drawing.Color.White;
            this.txtMPCServer.BorderColor = System.Drawing.Color.Empty;
            this.txtMPCServer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMPCServer.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMPCServer.FocusColor = System.Drawing.Color.Empty;
            this.txtMPCServer.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtMPCServer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            this.txtMPCServer.Location = new System.Drawing.Point(194, 31);
            this.txtMPCServer.Name = "txtMPCServer";
            this.txtMPCServer.Numerico = false;
            this.txtMPCServer.Size = new System.Drawing.Size(186, 29);
            this.txtMPCServer.TabIndex = 5;
            this.txtMPCServer.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtMPCServer.TextChanged += new System.EventHandler(this.txtServer_TextChanged);
            // 
            // label3
            // 
            this.label3.AccessibleDescription = "IdEntidad es proporcionado por CaptarPagos";
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(178, 21);
            this.label3.TabIndex = 4;
            this.label3.Text = "IP/Nombre del Servidor:";
            // 
            // txtMPCBase
            // 
            this.txtMPCBase.AccessibleName = "captarpagos";
            this.txtMPCBase.BorderColor = System.Drawing.Color.Empty;
            this.txtMPCBase.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMPCBase.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMPCBase.FocusColor = System.Drawing.Color.Empty;
            this.txtMPCBase.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMPCBase.Location = new System.Drawing.Point(194, 136);
            this.txtMPCBase.Name = "txtMPCBase";
            this.txtMPCBase.Numerico = false;
            this.txtMPCBase.Size = new System.Drawing.Size(186, 29);
            this.txtMPCBase.TabIndex = 11;
            this.txtMPCBase.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblDb
            // 
            this.lblDb.AccessibleDescription = "IdEntidad es proporcionado por CaptarPagos";
            this.lblDb.AutoSize = true;
            this.lblDb.Location = new System.Drawing.Point(80, 138);
            this.lblDb.Name = "lblDb";
            this.lblDb.Size = new System.Drawing.Size(108, 21);
            this.lblDb.TabIndex = 10;
            this.lblDb.Text = "Base de datos:";
            // 
            // frmConfiguracion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(687, 401);
            this.Controls.Add(this.tbControlPagos);
            this.Controls.Add(this.flpInferior);
            this.Controls.Add(this.pnlSuperior);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "frmConfiguracion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configuracion de pagos externos";
            this.Load += new System.EventHandler(this.frmConfiguracion_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmConfiguracion_KeyDown);
            this.pnlSuperior.ResumeLayout(false);
            this.pnlSuperior.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgReturn)).EndInit();
            this.flpInferior.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tbControlPagos.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnlSuperior;
        private System.Windows.Forms.PictureBox imgReturn;
        private System.Windows.Forms.Label lblTitulos;
        private System.Windows.Forms.FlowLayoutPanel flpInferior;
        private Controles.boton btnAceptar;
        private Controles.boton btnCancelar;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabControl tbControlPagos;
        private textboxAdv txtCPIdEntidad;
        private System.Windows.Forms.Label label1;
        private textboxAdv txtCPHash;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabPage tabPage2;
        private textboxAdv txtMPCPass;
        private System.Windows.Forms.Label label5;
        private textboxAdv txtMPCUsuario;
        private System.Windows.Forms.Label label4;
        private textboxAdv txtMPCServer;
        private System.Windows.Forms.Label label3;
        private textboxAdv txtMPCBase;
        private System.Windows.Forms.Label lblDb;
    }
}