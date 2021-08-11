
namespace CapaPresentacion.Complementarias
{
    partial class frmCambioServicioGeneracionPartes
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
            this.pnLinea1 = new System.Windows.Forms.Panel();
            this.LbTitulos = new System.Windows.Forms.Label();
            this.imgReturn = new System.Windows.Forms.PictureBox();
            this.chkCambioEquipo = new System.Windows.Forms.CheckBox();
            this.chkCambioTecnologia = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnCambiar = new CapaPresentacion.Controles.boton();
            this.cboFallasCambioEquipo = new CapaPresentacion.Controles.combo(this.components);
            this.cboFallasCambioTecnologia = new CapaPresentacion.Controles.combo(this.components);
            this.pnLinea1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgReturn)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnLinea1
            // 
            this.pnLinea1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.pnLinea1.Controls.Add(this.LbTitulos);
            this.pnLinea1.Controls.Add(this.imgReturn);
            this.pnLinea1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnLinea1.Location = new System.Drawing.Point(0, 0);
            this.pnLinea1.Name = "pnLinea1";
            this.pnLinea1.Size = new System.Drawing.Size(645, 83);
            this.pnLinea1.TabIndex = 201;
            // 
            // LbTitulos
            // 
            this.LbTitulos.AutoSize = true;
            this.LbTitulos.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LbTitulos.ForeColor = System.Drawing.Color.Transparent;
            this.LbTitulos.Location = new System.Drawing.Point(47, 29);
            this.LbTitulos.Name = "LbTitulos";
            this.LbTitulos.Size = new System.Drawing.Size(192, 25);
            this.LbTitulos.TabIndex = 172;
            this.LbTitulos.Text = "Generacion de partes";
            // 
            // imgReturn
            // 
            this.imgReturn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.imgReturn.Image = global::CapaPresentacion.Properties.Resources.Left_Arrow_32;
            this.imgReturn.Location = new System.Drawing.Point(11, 25);
            this.imgReturn.Name = "imgReturn";
            this.imgReturn.Size = new System.Drawing.Size(32, 32);
            this.imgReturn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgReturn.TabIndex = 76;
            this.imgReturn.TabStop = false;
            this.imgReturn.Click += new System.EventHandler(this.imgReturn_Click);
            // 
            // chkCambioEquipo
            // 
            this.chkCambioEquipo.AutoSize = true;
            this.chkCambioEquipo.Checked = true;
            this.chkCambioEquipo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCambioEquipo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkCambioEquipo.Location = new System.Drawing.Point(26, 30);
            this.chkCambioEquipo.Name = "chkCambioEquipo";
            this.chkCambioEquipo.Size = new System.Drawing.Size(156, 25);
            this.chkCambioEquipo.TabIndex = 212;
            this.chkCambioEquipo.Text = "Cambio de equipo";
            this.chkCambioEquipo.UseVisualStyleBackColor = true;
            this.chkCambioEquipo.CheckedChanged += new System.EventHandler(this.cambiarEstadoCheckbox);
            // 
            // chkCambioTecnologia
            // 
            this.chkCambioTecnologia.AutoSize = true;
            this.chkCambioTecnologia.Checked = true;
            this.chkCambioTecnologia.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCambioTecnologia.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkCambioTecnologia.Location = new System.Drawing.Point(26, 67);
            this.chkCambioTecnologia.Name = "chkCambioTecnologia";
            this.chkCambioTecnologia.Size = new System.Drawing.Size(180, 25);
            this.chkCambioTecnologia.TabIndex = 214;
            this.chkCambioTecnologia.Text = "Cambio de tecnologia";
            this.chkCambioTecnologia.UseVisualStyleBackColor = true;
            this.chkCambioTecnologia.CheckedChanged += new System.EventHandler(this.cambiarEstadoCheckbox);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cboFallasCambioTecnologia);
            this.groupBox1.Controls.Add(this.cboFallasCambioEquipo);
            this.groupBox1.Controls.Add(this.chkCambioEquipo);
            this.groupBox1.Controls.Add(this.chkCambioTecnologia);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(11, 87);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(622, 111);
            this.groupBox1.TabIndex = 215;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Seleccionar partes y motivos";
            // 
            // btnCambiar
            // 
            this.btnCambiar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCambiar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnCambiar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCambiar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnCambiar.FlatAppearance.BorderSize = 0;
            this.btnCambiar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnCambiar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnCambiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCambiar.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnCambiar.ForeColor = System.Drawing.Color.White;
            this.btnCambiar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCambiar.Location = new System.Drawing.Point(536, 204);
            this.btnCambiar.Name = "btnCambiar";
            this.btnCambiar.Size = new System.Drawing.Size(97, 34);
            this.btnCambiar.TabIndex = 221;
            this.btnCambiar.Text = "Seleccionar";
            this.btnCambiar.UseVisualStyleBackColor = false;
            this.btnCambiar.Click += new System.EventHandler(this.btnCambiar_Click);
            // 
            // cboFallasCambioEquipo
            // 
            this.cboFallasCambioEquipo.BorderColor = System.Drawing.Color.Gainsboro;
            this.cboFallasCambioEquipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFallasCambioEquipo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboFallasCambioEquipo.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cboFallasCambioEquipo.FormattingEnabled = true;
            this.cboFallasCambioEquipo.Location = new System.Drawing.Point(229, 28);
            this.cboFallasCambioEquipo.Name = "cboFallasCambioEquipo";
            this.cboFallasCambioEquipo.Size = new System.Drawing.Size(379, 29);
            this.cboFallasCambioEquipo.TabIndex = 215;
            // 
            // cboFallasCambioTecnologia
            // 
            this.cboFallasCambioTecnologia.BorderColor = System.Drawing.Color.Gainsboro;
            this.cboFallasCambioTecnologia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFallasCambioTecnologia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboFallasCambioTecnologia.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cboFallasCambioTecnologia.FormattingEnabled = true;
            this.cboFallasCambioTecnologia.Location = new System.Drawing.Point(229, 65);
            this.cboFallasCambioTecnologia.Name = "cboFallasCambioTecnologia";
            this.cboFallasCambioTecnologia.Size = new System.Drawing.Size(379, 29);
            this.cboFallasCambioTecnologia.TabIndex = 216;
            // 
            // frmCambioServicioGeneracionPartes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(645, 245);
            this.Controls.Add(this.btnCambiar);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pnLinea1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmCambioServicioGeneracionPartes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmCambioServicioGeneracionPartes";
            this.Load += new System.EventHandler(this.frmCambioServicioGeneracionPartes_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmCambioServicioGeneracionPartes_KeyDown);
            this.pnLinea1.ResumeLayout(false);
            this.pnLinea1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgReturn)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnLinea1;
        private System.Windows.Forms.Label LbTitulos;
        private System.Windows.Forms.PictureBox imgReturn;
        private System.Windows.Forms.CheckBox chkCambioEquipo;
        private System.Windows.Forms.CheckBox chkCambioTecnologia;
        private System.Windows.Forms.GroupBox groupBox1;
        private Controles.boton btnCambiar;
        private Controles.combo cboFallasCambioTecnologia;
        private Controles.combo cboFallasCambioEquipo;
    }
}