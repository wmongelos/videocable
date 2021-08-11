namespace CapaPresentacion
{
    partial class frmUsuariosEquipos
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.imgReturn = new System.Windows.Forms.PictureBox();
            this.lbForma_de_Pago = new System.Windows.Forms.Label();
            this.lblEquipoSeleccionado = new System.Windows.Forms.Label();
            this.lblServicio = new System.Windows.Forms.Label();
            this.btnDesafectar = new CapaPresentacion.Controles.boton();
            this.btnAsignarTarjeta = new CapaPresentacion.Controles.boton();
            this.dgvEquipos = new CapaPresentacion.Controles.dgv(this.components);
            this.pnlDatos = new System.Windows.Forms.Panel();
            this.pnlBotones = new System.Windows.Forms.Panel();
            this.btnCass = new CapaPresentacion.Controles.boton();
            this.btnAsignarEquipo = new CapaPresentacion.Controles.boton();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgReturn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEquipos)).BeginInit();
            this.pnlDatos.SuspendLayout();
            this.pnlBotones.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panel1.Controls.Add(this.imgReturn);
            this.panel1.Controls.Add(this.lbForma_de_Pago);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1081, 75);
            this.panel1.TabIndex = 112;
            // 
            // imgReturn
            // 
            this.imgReturn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.imgReturn.Image = global::CapaPresentacion.Properties.Resources.Left_Arrow_32;
            this.imgReturn.Location = new System.Drawing.Point(17, 21);
            this.imgReturn.Name = "imgReturn";
            this.imgReturn.Size = new System.Drawing.Size(32, 32);
            this.imgReturn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgReturn.TabIndex = 122;
            this.imgReturn.TabStop = false;
            this.imgReturn.Click += new System.EventHandler(this.imgReturn_Click);
            // 
            // lbForma_de_Pago
            // 
            this.lbForma_de_Pago.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbForma_de_Pago.ForeColor = System.Drawing.Color.White;
            this.lbForma_de_Pago.Location = new System.Drawing.Point(64, 26);
            this.lbForma_de_Pago.Name = "lbForma_de_Pago";
            this.lbForma_de_Pago.Size = new System.Drawing.Size(304, 23);
            this.lbForma_de_Pago.TabIndex = 114;
            this.lbForma_de_Pago.Text = "EQUIPOS ASIGNADOS";
            // 
            // lblEquipoSeleccionado
            // 
            this.lblEquipoSeleccionado.AutoSize = true;
            this.lblEquipoSeleccionado.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEquipoSeleccionado.ForeColor = System.Drawing.Color.Black;
            this.lblEquipoSeleccionado.Location = new System.Drawing.Point(3, 11);
            this.lblEquipoSeleccionado.Name = "lblEquipoSeleccionado";
            this.lblEquipoSeleccionado.Size = new System.Drawing.Size(154, 21);
            this.lblEquipoSeleccionado.TabIndex = 299;
            this.lblEquipoSeleccionado.Text = "Equipo seleccionado:";
            // 
            // lblServicio
            // 
            this.lblServicio.AutoSize = true;
            this.lblServicio.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblServicio.ForeColor = System.Drawing.Color.Black;
            this.lblServicio.Location = new System.Drawing.Point(981, 11);
            this.lblServicio.Name = "lblServicio";
            this.lblServicio.Size = new System.Drawing.Size(68, 21);
            this.lblServicio.TabIndex = 301;
            this.lblServicio.Text = "Servicio:";
            // 
            // btnDesafectar
            // 
            this.btnDesafectar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDesafectar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnDesafectar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDesafectar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnDesafectar.FlatAppearance.BorderSize = 0;
            this.btnDesafectar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnDesafectar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnDesafectar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDesafectar.Font = new System.Drawing.Font("Segoe UI Light", 12F);
            this.btnDesafectar.ForeColor = System.Drawing.Color.White;
            this.btnDesafectar.Image = global::CapaPresentacion.Properties.Resources.Data_Delete_32;
            this.btnDesafectar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDesafectar.Location = new System.Drawing.Point(792, 7);
            this.btnDesafectar.Name = "btnDesafectar";
            this.btnDesafectar.Size = new System.Drawing.Size(130, 38);
            this.btnDesafectar.TabIndex = 300;
            this.btnDesafectar.Text = "Desafectar ";
            this.btnDesafectar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDesafectar.UseVisualStyleBackColor = false;
            this.btnDesafectar.Click += new System.EventHandler(this.btnDesafectar_Click);
            // 
            // btnAsignarTarjeta
            // 
            this.btnAsignarTarjeta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAsignarTarjeta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnAsignarTarjeta.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAsignarTarjeta.Enabled = false;
            this.btnAsignarTarjeta.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnAsignarTarjeta.FlatAppearance.BorderSize = 0;
            this.btnAsignarTarjeta.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnAsignarTarjeta.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnAsignarTarjeta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAsignarTarjeta.Font = new System.Drawing.Font("Segoe UI Light", 12F);
            this.btnAsignarTarjeta.ForeColor = System.Drawing.Color.White;
            this.btnAsignarTarjeta.Image = global::CapaPresentacion.Properties.Resources.Data_Add_32;
            this.btnAsignarTarjeta.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAsignarTarjeta.Location = new System.Drawing.Point(928, 7);
            this.btnAsignarTarjeta.Name = "btnAsignarTarjeta";
            this.btnAsignarTarjeta.Size = new System.Drawing.Size(141, 38);
            this.btnAsignarTarjeta.TabIndex = 298;
            this.btnAsignarTarjeta.Text = "Asignar tarjeta";
            this.btnAsignarTarjeta.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAsignarTarjeta.UseVisualStyleBackColor = false;
            this.btnAsignarTarjeta.Click += new System.EventHandler(this.btnAsignarTarjeta_Click);
            // 
            // dgvEquipos
            // 
            this.dgvEquipos.AllowUserToAddRows = false;
            this.dgvEquipos.AllowUserToDeleteRows = false;
            this.dgvEquipos.AllowUserToOrderColumns = true;
            this.dgvEquipos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvEquipos.BackgroundColor = System.Drawing.Color.White;
            this.dgvEquipos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvEquipos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSlateGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvEquipos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvEquipos.ColumnHeadersHeight = 40;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvEquipos.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvEquipos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvEquipos.EnableHeadersVisualStyles = false;
            this.dgvEquipos.GridColor = System.Drawing.Color.WhiteSmoke;
            this.dgvEquipos.Location = new System.Drawing.Point(0, 117);
            this.dgvEquipos.MultiSelect = false;
            this.dgvEquipos.Name = "dgvEquipos";
            this.dgvEquipos.ReadOnly = true;
            this.dgvEquipos.RowHeadersVisible = false;
            this.dgvEquipos.RowHeadersWidth = 50;
            this.dgvEquipos.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvEquipos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEquipos.Size = new System.Drawing.Size(1081, 366);
            this.dgvEquipos.TabIndex = 113;
            this.dgvEquipos.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEquipos_CellEnter);
            // 
            // pnlDatos
            // 
            this.pnlDatos.Controls.Add(this.lblEquipoSeleccionado);
            this.pnlDatos.Controls.Add(this.lblServicio);
            this.pnlDatos.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlDatos.Location = new System.Drawing.Point(0, 75);
            this.pnlDatos.Name = "pnlDatos";
            this.pnlDatos.Size = new System.Drawing.Size(1081, 42);
            this.pnlDatos.TabIndex = 302;
            // 
            // pnlBotones
            // 
            this.pnlBotones.Controls.Add(this.btnCass);
            this.pnlBotones.Controls.Add(this.btnAsignarEquipo);
            this.pnlBotones.Controls.Add(this.lblCantidad);
            this.pnlBotones.Controls.Add(this.btnAsignarTarjeta);
            this.pnlBotones.Controls.Add(this.btnDesafectar);
            this.pnlBotones.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBotones.Location = new System.Drawing.Point(0, 483);
            this.pnlBotones.Name = "pnlBotones";
            this.pnlBotones.Size = new System.Drawing.Size(1081, 53);
            this.pnlBotones.TabIndex = 303;
            // 
            // btnCass
            // 
            this.btnCass.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCass.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnCass.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCass.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnCass.FlatAppearance.BorderSize = 0;
            this.btnCass.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnCass.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnCass.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCass.Font = new System.Drawing.Font("Segoe UI Light", 12F);
            this.btnCass.ForeColor = System.Drawing.Color.White;
            this.btnCass.Image = global::CapaPresentacion.Properties.Resources.Data_Delete_32;
            this.btnCass.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCass.Location = new System.Drawing.Point(459, 7);
            this.btnCass.Name = "btnCass";
            this.btnCass.Size = new System.Drawing.Size(107, 38);
            this.btnCass.TabIndex = 303;
            this.btnCass.Text = "Cass";
            this.btnCass.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCass.UseVisualStyleBackColor = false;
            this.btnCass.Click += new System.EventHandler(this.btnCass_Click);
            // 
            // btnAsignarEquipo
            // 
            this.btnAsignarEquipo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAsignarEquipo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnAsignarEquipo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAsignarEquipo.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnAsignarEquipo.FlatAppearance.BorderSize = 0;
            this.btnAsignarEquipo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnAsignarEquipo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnAsignarEquipo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAsignarEquipo.Font = new System.Drawing.Font("Segoe UI Light", 12F);
            this.btnAsignarEquipo.ForeColor = System.Drawing.Color.White;
            this.btnAsignarEquipo.Image = global::CapaPresentacion.Properties.Resources.Data_Delete_32;
            this.btnAsignarEquipo.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAsignarEquipo.Location = new System.Drawing.Point(599, 7);
            this.btnAsignarEquipo.Name = "btnAsignarEquipo";
            this.btnAsignarEquipo.Size = new System.Drawing.Size(152, 38);
            this.btnAsignarEquipo.TabIndex = 302;
            this.btnAsignarEquipo.Text = "Asignar Equipo";
            this.btnAsignarEquipo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAsignarEquipo.UseVisualStyleBackColor = false;
            this.btnAsignarEquipo.Click += new System.EventHandler(this.btnAsignarEquipo_Click);
            // 
            // lblCantidad
            // 
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCantidad.ForeColor = System.Drawing.Color.Black;
            this.lblCantidad.Location = new System.Drawing.Point(8, 16);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(155, 21);
            this.lblCantidad.TabIndex = 301;
            this.lblCantidad.Text = "Cantidad de equipos:";
            // 
            // frmUsuariosEquipos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(250)))), ((int)(((byte)(251)))));
            this.ClientSize = new System.Drawing.Size(1081, 536);
            this.Controls.Add(this.dgvEquipos);
            this.Controls.Add(this.pnlBotones);
            this.Controls.Add(this.pnlDatos);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "frmUsuariosEquipos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmUsuariosEquipos";
            this.Load += new System.EventHandler(this.frmUsuariosEquipos_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmUsuariosEquipos_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgReturn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEquipos)).EndInit();
            this.pnlDatos.ResumeLayout(false);
            this.pnlDatos.PerformLayout();
            this.pnlBotones.ResumeLayout(false);
            this.pnlBotones.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox imgReturn;
        private System.Windows.Forms.Label lbForma_de_Pago;
        private Controles.dgv dgvEquipos;
        private Controles.boton btnAsignarTarjeta;
        private System.Windows.Forms.Label lblEquipoSeleccionado;
        private Controles.boton btnDesafectar;
        private System.Windows.Forms.Label lblServicio;
        private System.Windows.Forms.Panel pnlDatos;
        private System.Windows.Forms.Panel pnlBotones;
        private System.Windows.Forms.Label lblCantidad;
        private Controles.boton btnAsignarEquipo;
        private Controles.boton btnCass;
    }
}