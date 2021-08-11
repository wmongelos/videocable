namespace CapaPresentacion.Complementarias
{
    partial class frmCambioMeses
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnTitulo = new System.Windows.Forms.Panel();
            this.LbTitulos = new System.Windows.Forms.Label();
            this.imgReturn = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvSubServiciosActuales = new CapaPresentacion.Controles.dgv(this.components);
            this.btnCancelar = new CapaPresentacion.Controles.boton();
            this.btnAceptar = new CapaPresentacion.Controles.boton();
            this.lblMesesServicio = new System.Windows.Forms.Label();
            this.spnServicio = new System.Windows.Forms.NumericUpDown();
            this.lblMesesCobro = new System.Windows.Forms.Label();
            this.spnCobro = new System.Windows.Forms.NumericUpDown();
            this.pnTitulo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgReturn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSubServiciosActuales)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spnServicio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spnCobro)).BeginInit();
            this.SuspendLayout();
            // 
            // pnTitulo
            // 
            this.pnTitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.pnTitulo.Controls.Add(this.LbTitulos);
            this.pnTitulo.Controls.Add(this.imgReturn);
            this.pnTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnTitulo.Location = new System.Drawing.Point(0, 0);
            this.pnTitulo.Name = "pnTitulo";
            this.pnTitulo.Size = new System.Drawing.Size(516, 83);
            this.pnTitulo.TabIndex = 201;
            // 
            // LbTitulos
            // 
            this.LbTitulos.AutoSize = true;
            this.LbTitulos.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LbTitulos.ForeColor = System.Drawing.Color.Transparent;
            this.LbTitulos.Location = new System.Drawing.Point(53, 31);
            this.LbTitulos.Name = "LbTitulos";
            this.LbTitulos.Size = new System.Drawing.Size(161, 25);
            this.LbTitulos.TabIndex = 172;
            this.LbTitulos.Text = "Cambio de Meses";
            // 
            // imgReturn
            // 
            this.imgReturn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.imgReturn.Image = global::CapaPresentacion.Properties.Resources.Left_Arrow_32;
            this.imgReturn.Location = new System.Drawing.Point(11, 26);
            this.imgReturn.Name = "imgReturn";
            this.imgReturn.Size = new System.Drawing.Size(32, 32);
            this.imgReturn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgReturn.TabIndex = 76;
            this.imgReturn.TabStop = false;
            this.imgReturn.Click += new System.EventHandler(this.imgReturn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(12, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 25);
            this.label2.TabIndex = 204;
            this.label2.Text = "Servicio";
            // 
            // dgvSubServiciosActuales
            // 
            this.dgvSubServiciosActuales.AllowUserToAddRows = false;
            this.dgvSubServiciosActuales.AllowUserToDeleteRows = false;
            this.dgvSubServiciosActuales.AllowUserToOrderColumns = true;
            this.dgvSubServiciosActuales.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSubServiciosActuales.BackgroundColor = System.Drawing.Color.White;
            this.dgvSubServiciosActuales.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvSubServiciosActuales.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSlateGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSubServiciosActuales.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvSubServiciosActuales.ColumnHeadersHeight = 40;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSubServiciosActuales.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvSubServiciosActuales.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.dgvSubServiciosActuales.EnableHeadersVisualStyles = false;
            this.dgvSubServiciosActuales.GridColor = System.Drawing.Color.WhiteSmoke;
            this.dgvSubServiciosActuales.Location = new System.Drawing.Point(17, 132);
            this.dgvSubServiciosActuales.MultiSelect = false;
            this.dgvSubServiciosActuales.Name = "dgvSubServiciosActuales";
            this.dgvSubServiciosActuales.ReadOnly = true;
            this.dgvSubServiciosActuales.RowHeadersVisible = false;
            this.dgvSubServiciosActuales.RowHeadersWidth = 50;
            this.dgvSubServiciosActuales.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvSubServiciosActuales.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSubServiciosActuales.Size = new System.Drawing.Size(467, 110);
            this.dgvSubServiciosActuales.TabIndex = 205;
            // 
            // btnCancelar
            // 
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
            this.btnCancelar.Location = new System.Drawing.Point(386, 89);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(98, 35);
            this.btnCancelar.TabIndex = 212;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
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
            this.btnAceptar.Location = new System.Drawing.Point(282, 89);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(98, 35);
            this.btnAceptar.TabIndex = 209;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = false;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // lblMesesServicio
            // 
            this.lblMesesServicio.AutoSize = true;
            this.lblMesesServicio.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblMesesServicio.Location = new System.Drawing.Point(360, 257);
            this.lblMesesServicio.Name = "lblMesesServicio";
            this.lblMesesServicio.Size = new System.Drawing.Size(132, 21);
            this.lblMesesServicio.TabIndex = 210;
            this.lblMesesServicio.Text = "Meses de servicio";
            // 
            // spnServicio
            // 
            this.spnServicio.Font = new System.Drawing.Font("Segoe UI Light", 12F);
            this.spnServicio.Location = new System.Drawing.Point(364, 281);
            this.spnServicio.Name = "spnServicio";
            this.spnServicio.Size = new System.Drawing.Size(120, 29);
            this.spnServicio.TabIndex = 211;
            // 
            // lblMesesCobro
            // 
            this.lblMesesCobro.AutoSize = true;
            this.lblMesesCobro.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblMesesCobro.Location = new System.Drawing.Point(210, 257);
            this.lblMesesCobro.Name = "lblMesesCobro";
            this.lblMesesCobro.Size = new System.Drawing.Size(119, 21);
            this.lblMesesCobro.TabIndex = 213;
            this.lblMesesCobro.Text = "Meses de cobro";
            // 
            // spnCobro
            // 
            this.spnCobro.Font = new System.Drawing.Font("Segoe UI Light", 12F);
            this.spnCobro.Location = new System.Drawing.Point(214, 281);
            this.spnCobro.Name = "spnCobro";
            this.spnCobro.Size = new System.Drawing.Size(120, 29);
            this.spnCobro.TabIndex = 214;
            // 
            // frmCambioMeses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(516, 329);
            this.Controls.Add(this.lblMesesCobro);
            this.Controls.Add(this.spnCobro);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.lblMesesServicio);
            this.Controls.Add(this.spnServicio);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvSubServiciosActuales);
            this.Controls.Add(this.pnTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmCambioMeses";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmCambioMeses";
            this.Load += new System.EventHandler(this.frmCambioMeses_Load);
            this.pnTitulo.ResumeLayout(false);
            this.pnTitulo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgReturn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSubServiciosActuales)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spnServicio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spnCobro)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnTitulo;
        private System.Windows.Forms.Label LbTitulos;
        private System.Windows.Forms.PictureBox imgReturn;
        private System.Windows.Forms.Label label2;
        private Controles.dgv dgvSubServiciosActuales;
        private Controles.boton btnCancelar;
        private Controles.boton btnAceptar;
        private System.Windows.Forms.Label lblMesesServicio;
        private System.Windows.Forms.NumericUpDown spnServicio;
        private System.Windows.Forms.Label lblMesesCobro;
        private System.Windows.Forms.NumericUpDown spnCobro;
    }
}