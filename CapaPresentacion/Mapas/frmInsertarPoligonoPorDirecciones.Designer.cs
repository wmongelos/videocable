
namespace CapaPresentacion.Mapas
{
    partial class frmInsertarPoligonoPorDirecciones
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
            this.panel3 = new System.Windows.Forms.Panel();
            this.imgReturn = new System.Windows.Forms.PictureBox();
            this.lblTituloHeader = new System.Windows.Forms.Label();
            this.lblCalle = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvPuntos = new CapaPresentacion.Controles.dgv(this.components);
            this.cboLocalidades = new CapaPresentacion.Controles.combo(this.components);
            this.btnAgregar = new CapaPresentacion.Controles.boton();
            this.textAltura = new CapaPresentacion.textboxAdv();
            this.btnCalle = new CapaPresentacion.Controles.boton();
            this.textCalle = new CapaPresentacion.textboxAdv();
            this.btnInsMapa = new CapaPresentacion.Controles.boton();
            this.btnEliminar = new CapaPresentacion.Controles.boton();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgReturn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPuntos)).BeginInit();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.panel3.Controls.Add(this.imgReturn);
            this.panel3.Controls.Add(this.lblTituloHeader);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(820, 75);
            this.panel3.TabIndex = 320;
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
            this.imgReturn.Click += new System.EventHandler(this.imgReturn_Click);
            // 
            // lblTituloHeader
            // 
            this.lblTituloHeader.Font = new System.Drawing.Font("Segoe UI Light", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloHeader.ForeColor = System.Drawing.Color.White;
            this.lblTituloHeader.Location = new System.Drawing.Point(53, 27);
            this.lblTituloHeader.Name = "lblTituloHeader";
            this.lblTituloHeader.Size = new System.Drawing.Size(561, 23);
            this.lblTituloHeader.TabIndex = 31;
            this.lblTituloHeader.Text = "INSERTAR POLIGONO POR DIRECCIONES";
            // 
            // lblCalle
            // 
            this.lblCalle.AutoSize = true;
            this.lblCalle.Location = new System.Drawing.Point(232, 107);
            this.lblCalle.Name = "lblCalle";
            this.lblCalle.Size = new System.Drawing.Size(33, 13);
            this.lblCalle.TabIndex = 334;
            this.lblCalle.Text = "Calle:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(559, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 337;
            this.label2.Text = "Altura:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 107);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 340;
            this.label1.Text = "Localidad:";
            // 
            // dgvPuntos
            // 
            this.dgvPuntos.AllowUserToAddRows = false;
            this.dgvPuntos.AllowUserToDeleteRows = false;
            this.dgvPuntos.AllowUserToOrderColumns = true;
            this.dgvPuntos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPuntos.BackgroundColor = System.Drawing.Color.White;
            this.dgvPuntos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvPuntos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI Light", 14F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPuntos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPuntos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPuntos.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvPuntos.EnableHeadersVisualStyles = false;
            this.dgvPuntos.GridColor = System.Drawing.Color.WhiteSmoke;
            this.dgvPuntos.Location = new System.Drawing.Point(18, 137);
            this.dgvPuntos.Name = "dgvPuntos";
            this.dgvPuntos.ReadOnly = true;
            this.dgvPuntos.RowHeadersVisible = false;
            this.dgvPuntos.RowHeadersWidth = 50;
            this.dgvPuntos.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvPuntos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPuntos.Size = new System.Drawing.Size(790, 247);
            this.dgvPuntos.TabIndex = 342;
            // 
            // cboLocalidades
            // 
            this.cboLocalidades.BorderColor = System.Drawing.Color.Empty;
            this.cboLocalidades.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLocalidades.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboLocalidades.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboLocalidades.FormattingEnabled = true;
            this.cboLocalidades.Location = new System.Drawing.Point(77, 98);
            this.cboLocalidades.Name = "cboLocalidades";
            this.cboLocalidades.Size = new System.Drawing.Size(135, 29);
            this.cboLocalidades.TabIndex = 341;
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnAgregar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnAgregar.FlatAppearance.BorderSize = 0;
            this.btnAgregar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnAgregar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregar.ForeColor = System.Drawing.Color.White;
            this.btnAgregar.Image = global::CapaPresentacion.Properties.Resources.Data_Add_32;
            this.btnAgregar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAgregar.Location = new System.Drawing.Point(689, 95);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(119, 36);
            this.btnAgregar.TabIndex = 339;
            this.btnAgregar.Text = "AGREGAR";
            this.btnAgregar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // textAltura
            // 
            this.textAltura.BorderColor = System.Drawing.Color.Empty;
            this.textAltura.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textAltura.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textAltura.FocusColor = System.Drawing.Color.Empty;
            this.textAltura.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textAltura.Location = new System.Drawing.Point(599, 99);
            this.textAltura.Name = "textAltura";
            this.textAltura.Numerico = false;
            this.textAltura.Size = new System.Drawing.Size(84, 29);
            this.textAltura.TabIndex = 338;
            // 
            // btnCalle
            // 
            this.btnCalle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnCalle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCalle.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnCalle.FlatAppearance.BorderSize = 0;
            this.btnCalle.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnCalle.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnCalle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCalle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCalle.ForeColor = System.Drawing.Color.White;
            this.btnCalle.Image = global::CapaPresentacion.Properties.Resources.lupa;
            this.btnCalle.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCalle.Location = new System.Drawing.Point(503, 99);
            this.btnCalle.Name = "btnCalle";
            this.btnCalle.Size = new System.Drawing.Size(35, 29);
            this.btnCalle.TabIndex = 336;
            this.btnCalle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCalle.UseVisualStyleBackColor = true;
            this.btnCalle.Click += new System.EventHandler(this.btnCalle_Click);
            // 
            // textCalle
            // 
            this.textCalle.BorderColor = System.Drawing.Color.Empty;
            this.textCalle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textCalle.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textCalle.Enabled = false;
            this.textCalle.FocusColor = System.Drawing.Color.Empty;
            this.textCalle.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textCalle.Location = new System.Drawing.Point(268, 99);
            this.textCalle.Name = "textCalle";
            this.textCalle.Numerico = false;
            this.textCalle.Size = new System.Drawing.Size(229, 29);
            this.textCalle.TabIndex = 335;
            // 
            // btnInsMapa
            // 
            this.btnInsMapa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnInsMapa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnInsMapa.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnInsMapa.FlatAppearance.BorderSize = 0;
            this.btnInsMapa.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnInsMapa.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnInsMapa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInsMapa.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInsMapa.ForeColor = System.Drawing.Color.White;
            this.btnInsMapa.Image = global::CapaPresentacion.Properties.Resources.Data_Export_32;
            this.btnInsMapa.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnInsMapa.Location = new System.Drawing.Point(625, 390);
            this.btnInsMapa.Name = "btnInsMapa";
            this.btnInsMapa.Size = new System.Drawing.Size(183, 48);
            this.btnInsMapa.TabIndex = 322;
            this.btnInsMapa.Text = "INSERTAR EN MAPA";
            this.btnInsMapa.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInsMapa.UseVisualStyleBackColor = true;
            this.btnInsMapa.Click += new System.EventHandler(this.btnInsMapa_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnEliminar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnEliminar.FlatAppearance.BorderSize = 0;
            this.btnEliminar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnEliminar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.ForeColor = System.Drawing.Color.White;
            this.btnEliminar.Image = global::CapaPresentacion.Properties.Resources.Data_Delete_32;
            this.btnEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEliminar.Location = new System.Drawing.Point(398, 390);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(216, 48);
            this.btnEliminar.TabIndex = 343;
            this.btnEliminar.Text = "ELIMINAR ULTIMO ITEM";
            this.btnEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // frmInsertarPoligonoPorDirecciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(820, 450);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.dgvPuntos);
            this.Controls.Add(this.cboLocalidades);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.textAltura);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblCalle);
            this.Controls.Add(this.btnCalle);
            this.Controls.Add(this.textCalle);
            this.Controls.Add(this.btnInsMapa);
            this.Controls.Add(this.panel3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmInsertarPoligonoPorDirecciones";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmInsertarPoligonoPorDirecciones";
            this.Load += new System.EventHandler(this.frmInsertarPoligonoPorDirecciones_Load);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgReturn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPuntos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox imgReturn;
        private System.Windows.Forms.Label lblTituloHeader;
        private Controles.boton btnInsMapa;
        private System.Windows.Forms.Label lblCalle;
        private Controles.boton btnCalle;
        private textboxAdv textCalle;
        private textboxAdv textAltura;
        private System.Windows.Forms.Label label2;
        private Controles.boton btnAgregar;
        private System.Windows.Forms.Label label1;
        private Controles.combo cboLocalidades;
        private Controles.dgv dgvPuntos;
        private Controles.boton btnEliminar;
    }
}