namespace CapaPresentacion.Herramientas
{
    partial class frmCambioServicioVelSel
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
            this.imgReturn = new System.Windows.Forms.PictureBox();
            this.lblTituloHeader = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.chkTarifa = new System.Windows.Forms.CheckBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.btnCancelar = new CapaPresentacion.Controles.boton();
            this.btnCambioVel = new CapaPresentacion.Controles.boton();
            this.cboTarifas = new CapaPresentacion.Controles.combo(this.components);
            this.cboServicios_Vel = new CapaPresentacion.Controles.combo(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgReturn)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.panel1.Controls.Add(this.imgReturn);
            this.panel1.Controls.Add(this.lblTituloHeader);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(408, 75);
            this.panel1.TabIndex = 54;
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
            // 
            // lblTituloHeader
            // 
            this.lblTituloHeader.Font = new System.Drawing.Font("Segoe UI Light", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloHeader.ForeColor = System.Drawing.Color.White;
            this.lblTituloHeader.Location = new System.Drawing.Point(53, 27);
            this.lblTituloHeader.Name = "lblTituloHeader";
            this.lblTituloHeader.Size = new System.Drawing.Size(338, 23);
            this.lblTituloHeader.TabIndex = 31;
            this.lblTituloHeader.Text = "Seleccionar Velocidad";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(85, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 21);
            this.label4.TabIndex = 233;
            this.label4.Text = "Velocidad:";
            // 
            // chkTarifa
            // 
            this.chkTarifa.AutoSize = true;
            this.chkTarifa.Location = new System.Drawing.Point(165, 139);
            this.chkTarifa.Name = "chkTarifa";
            this.chkTarifa.Size = new System.Drawing.Size(141, 25);
            this.chkTarifa.TabIndex = 234;
            this.chkTarifa.Text = "Conservar Tarifa";
            this.chkTarifa.UseVisualStyleBackColor = true;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.ForeColor = System.Drawing.Color.Black;
            this.lblNombre.Location = new System.Drawing.Point(109, 173);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(50, 21);
            this.lblNombre.TabIndex = 235;
            this.lblNombre.Text = "Tarifa:";
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.Gainsboro;
            this.panel7.Location = new System.Drawing.Point(0, 240);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(409, 1);
            this.panel7.TabIndex = 239;
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
            this.btnCancelar.Image = global::CapaPresentacion.Properties.Resources.Command_Redo_32;
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.Location = new System.Drawing.Point(288, 252);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(100, 37);
            this.btnCancelar.TabIndex = 238;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnCambioVel
            // 
            this.btnCambioVel.BackColor = System.Drawing.Color.SteelBlue;
            this.btnCambioVel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCambioVel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnCambioVel.FlatAppearance.BorderSize = 0;
            this.btnCambioVel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnCambioVel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnCambioVel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCambioVel.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnCambioVel.ForeColor = System.Drawing.Color.White;
            this.btnCambioVel.Image = global::CapaPresentacion.Properties.Resources.Task_03_32;
            this.btnCambioVel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCambioVel.Location = new System.Drawing.Point(111, 252);
            this.btnCambioVel.Name = "btnCambioVel";
            this.btnCambioVel.Size = new System.Drawing.Size(171, 37);
            this.btnCambioVel.TabIndex = 237;
            this.btnCambioVel.Text = "Cambiar Velocidad";
            this.btnCambioVel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCambioVel.UseVisualStyleBackColor = false;
            this.btnCambioVel.Click += new System.EventHandler(this.btnCambioVel_Click);
            // 
            // cboTarifas
            // 
            this.cboTarifas.BorderColor = System.Drawing.Color.Gainsboro;
            this.cboTarifas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTarifas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboTarifas.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTarifas.FormattingEnabled = true;
            this.cboTarifas.Location = new System.Drawing.Point(165, 170);
            this.cboTarifas.Name = "cboTarifas";
            this.cboTarifas.Size = new System.Drawing.Size(223, 29);
            this.cboTarifas.TabIndex = 236;
            // 
            // cboServicios_Vel
            // 
            this.cboServicios_Vel.BorderColor = System.Drawing.Color.Gainsboro;
            this.cboServicios_Vel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboServicios_Vel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboServicios_Vel.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboServicios_Vel.FormattingEnabled = true;
            this.cboServicios_Vel.Location = new System.Drawing.Point(165, 95);
            this.cboServicios_Vel.Name = "cboServicios_Vel";
            this.cboServicios_Vel.Size = new System.Drawing.Size(223, 29);
            this.cboServicios_Vel.TabIndex = 232;
            // 
            // frmCambioServicioVelSel
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(408, 296);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnCambioVel);
            this.Controls.Add(this.cboTarifas);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.chkTarifa);
            this.Controls.Add(this.cboServicios_Vel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmCambioServicioVelSel";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cambio de Velocidad";
            this.Load += new System.EventHandler(this.frmCambioServicioVelSel_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgReturn)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox imgReturn;
        private System.Windows.Forms.Label lblTituloHeader;
        private Controles.combo cboServicios_Vel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkTarifa;
        private Controles.combo cboTarifas;
        private System.Windows.Forms.Label lblNombre;
        private Controles.boton btnCambioVel;
        private Controles.boton btnCancelar;
        private System.Windows.Forms.Panel panel7;
    }
}