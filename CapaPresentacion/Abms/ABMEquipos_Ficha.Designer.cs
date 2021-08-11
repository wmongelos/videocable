namespace CapaPresentacion.Abms
{
    partial class ABMEquipos_Ficha
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
            this.panel3 = new System.Windows.Forms.Panel();
            this.imgReturn = new System.Windows.Forms.PictureBox();
            this.lblTituloHeader = new System.Windows.Forms.Label();
            this.lblEstado = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblAdvertenciaTipoEquipo = new System.Windows.Forms.Label();
            this.txtMac = new System.Windows.Forms.MaskedTextBox();
            this.pgCircular = new CapaPresentacion.Controles.progress();
            this.btnCancelar = new CapaPresentacion.Controles.boton();
            this.btnGuardar = new CapaPresentacion.Controles.boton();
            this.txtSerie = new CapaPresentacion.textboxAdv();
            this.cboEquiposEstados = new CapaPresentacion.Controles.combo(this.components);
            this.cboEquipos_Modelos = new CapaPresentacion.Controles.combo(this.components);
            this.spinnerCant = new CapaPresentacion.Controles.spinner(this.components);
            this.cboEquipos_Tipos = new CapaPresentacion.Controles.combo(this.components);
            this.cboEquipos_Marcas = new CapaPresentacion.Controles.combo(this.components);
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgReturn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinnerCant)).BeginInit();
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
            this.panel3.Size = new System.Drawing.Size(648, 75);
            this.panel3.TabIndex = 46;
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
            this.lblTituloHeader.Size = new System.Drawing.Size(338, 27);
            this.lblTituloHeader.TabIndex = 31;
            this.lblTituloHeader.Text = "Carga y edición de equipos";
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Font = new System.Drawing.Font("Segoe UI Light", 12F);
            this.lblEstado.ForeColor = System.Drawing.Color.SlateGray;
            this.lblEstado.Location = new System.Drawing.Point(19, 253);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(59, 21);
            this.lblEstado.TabIndex = 61;
            this.lblEstado.Text = "Estado:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Light", 12F);
            this.label1.ForeColor = System.Drawing.Color.SlateGray;
            this.label1.Location = new System.Drawing.Point(428, 127);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 21);
            this.label1.TabIndex = 15;
            this.label1.Text = "Serie:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Light", 12F);
            this.label2.ForeColor = System.Drawing.Color.SlateGray;
            this.label2.Location = new System.Drawing.Point(432, 169);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 21);
            this.label2.TabIndex = 16;
            this.label2.Text = "Mac:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Light", 12F);
            this.label6.ForeColor = System.Drawing.Color.SlateGray;
            this.label6.Location = new System.Drawing.Point(399, 211);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 21);
            this.label6.TabIndex = 58;
            this.label6.Text = "Cantidad:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Light", 12F);
            this.label4.ForeColor = System.Drawing.Color.SlateGray;
            this.label4.Location = new System.Drawing.Point(13, 211);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 21);
            this.label4.TabIndex = 53;
            this.label4.Text = "Modelo:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Light", 12F);
            this.label3.ForeColor = System.Drawing.Color.SlateGray;
            this.label3.Location = new System.Drawing.Point(35, 127);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 21);
            this.label3.TabIndex = 51;
            this.label3.Text = "Tipo:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Light", 12F);
            this.label5.ForeColor = System.Drawing.Color.SlateGray;
            this.label5.Location = new System.Drawing.Point(23, 169);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 21);
            this.label5.TabIndex = 55;
            this.label5.Text = "Marca:";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.Font = new System.Drawing.Font("Segoe UI Light", 12F);
            this.panel1.Location = new System.Drawing.Point(0, 117);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(720, 1);
            this.panel1.TabIndex = 63;
            // 
            // lblAdvertenciaTipoEquipo
            // 
            this.lblAdvertenciaTipoEquipo.AutoSize = true;
            this.lblAdvertenciaTipoEquipo.Font = new System.Drawing.Font("Segoe UI Light", 12F);
            this.lblAdvertenciaTipoEquipo.ForeColor = System.Drawing.Color.Red;
            this.lblAdvertenciaTipoEquipo.Location = new System.Drawing.Point(12, 292);
            this.lblAdvertenciaTipoEquipo.Name = "lblAdvertenciaTipoEquipo";
            this.lblAdvertenciaTipoEquipo.Size = new System.Drawing.Size(16, 21);
            this.lblAdvertenciaTipoEquipo.TabIndex = 69;
            this.lblAdvertenciaTipoEquipo.Text = "*";
            // 
            // txtMac
            // 
            this.txtMac.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMac.Location = new System.Drawing.Point(475, 165);
            this.txtMac.Mask = "AA:AA:AA:AA:AA:AA";
            this.txtMac.Name = "txtMac";
            this.txtMac.Size = new System.Drawing.Size(144, 29);
            this.txtMac.TabIndex = 264;
            // 
            // pgCircular
            // 
            this.pgCircular.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pgCircular.Location = new System.Drawing.Point(610, 289);
            this.pgCircular.Name = "pgCircular";
            this.pgCircular.Percentage = 0F;
            this.pgCircular.Rotation = CapaPresentacion.Controles.RotationType.CounterClockwise;
            this.pgCircular.Size = new System.Drawing.Size(26, 26);
            this.pgCircular.TabIndex = 68;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI Light", 12F);
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Image = global::CapaPresentacion.Properties.Resources.Command_Redo_32;
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.Location = new System.Drawing.Point(525, 81);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(111, 30);
            this.btnCancelar.TabIndex = 67;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnGuardar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI Light", 12F);
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Image = global::CapaPresentacion.Properties.Resources.Save_32;
            this.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGuardar.Location = new System.Drawing.Point(408, 81);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(111, 30);
            this.btnGuardar.TabIndex = 7;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // txtSerie
            // 
            this.txtSerie.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtSerie.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSerie.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSerie.FocusColor = System.Drawing.Color.Empty;
            this.txtSerie.Font = new System.Drawing.Font("Segoe UI Light", 12F);
            this.txtSerie.ForeColor = System.Drawing.Color.DimGray;
            this.txtSerie.Location = new System.Drawing.Point(475, 124);
            this.txtSerie.Name = "txtSerie";
            this.txtSerie.Numerico = false;
            this.txtSerie.Size = new System.Drawing.Size(144, 29);
            this.txtSerie.TabIndex = 4;
            // 
            // cboEquiposEstados
            // 
            this.cboEquiposEstados.BorderColor = System.Drawing.Color.Gainsboro;
            this.cboEquiposEstados.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEquiposEstados.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboEquiposEstados.Font = new System.Drawing.Font("Segoe UI Light", 12F);
            this.cboEquiposEstados.FormattingEnabled = true;
            this.cboEquiposEstados.Location = new System.Drawing.Point(84, 250);
            this.cboEquiposEstados.Name = "cboEquiposEstados";
            this.cboEquiposEstados.Size = new System.Drawing.Size(291, 29);
            this.cboEquiposEstados.TabIndex = 3;
            // 
            // cboEquipos_Modelos
            // 
            this.cboEquipos_Modelos.BorderColor = System.Drawing.Color.Gainsboro;
            this.cboEquipos_Modelos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEquipos_Modelos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboEquipos_Modelos.Font = new System.Drawing.Font("Segoe UI Light", 12F);
            this.cboEquipos_Modelos.FormattingEnabled = true;
            this.cboEquipos_Modelos.Location = new System.Drawing.Point(84, 208);
            this.cboEquipos_Modelos.Name = "cboEquipos_Modelos";
            this.cboEquipos_Modelos.Size = new System.Drawing.Size(291, 29);
            this.cboEquipos_Modelos.TabIndex = 2;
            // 
            // spinnerCant
            // 
            this.spinnerCant.BorderColor = System.Drawing.Color.Empty;
            this.spinnerCant.Font = new System.Drawing.Font("Segoe UI Light", 12F);
            this.spinnerCant.Location = new System.Drawing.Point(475, 207);
            this.spinnerCant.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spinnerCant.Name = "spinnerCant";
            this.spinnerCant.Size = new System.Drawing.Size(67, 29);
            this.spinnerCant.TabIndex = 6;
            this.spinnerCant.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // cboEquipos_Tipos
            // 
            this.cboEquipos_Tipos.BorderColor = System.Drawing.Color.Gainsboro;
            this.cboEquipos_Tipos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEquipos_Tipos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboEquipos_Tipos.Font = new System.Drawing.Font("Segoe UI Light", 12F);
            this.cboEquipos_Tipos.FormattingEnabled = true;
            this.cboEquipos_Tipos.Location = new System.Drawing.Point(84, 124);
            this.cboEquipos_Tipos.Name = "cboEquipos_Tipos";
            this.cboEquipos_Tipos.Size = new System.Drawing.Size(291, 29);
            this.cboEquipos_Tipos.TabIndex = 0;
            this.cboEquipos_Tipos.SelectedIndexChanged += new System.EventHandler(this.cboEquipos_Tipos_SelectedIndexChanged);
            // 
            // cboEquipos_Marcas
            // 
            this.cboEquipos_Marcas.BorderColor = System.Drawing.Color.Gainsboro;
            this.cboEquipos_Marcas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEquipos_Marcas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboEquipos_Marcas.Font = new System.Drawing.Font("Segoe UI Light", 12F);
            this.cboEquipos_Marcas.FormattingEnabled = true;
            this.cboEquipos_Marcas.Location = new System.Drawing.Point(84, 166);
            this.cboEquipos_Marcas.Name = "cboEquipos_Marcas";
            this.cboEquipos_Marcas.Size = new System.Drawing.Size(291, 29);
            this.cboEquipos_Marcas.TabIndex = 1;
            this.cboEquipos_Marcas.SelectedIndexChanged += new System.EventHandler(this.cboEquipos_Marcas_SelectedIndexChanged);
            // 
            // ABMEquipos_Ficha
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(250)))), ((int)(((byte)(251)))));
            this.ClientSize = new System.Drawing.Size(648, 329);
            this.Controls.Add(this.txtMac);
            this.Controls.Add(this.lblAdvertenciaTipoEquipo);
            this.Controls.Add(this.pgCircular);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSerie);
            this.Controls.Add(this.cboEquiposEstados);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.lblEstado);
            this.Controls.Add(this.cboEquipos_Modelos);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.spinnerCant);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cboEquipos_Tipos);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cboEquipos_Marcas);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "ABMEquipos_Ficha";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmEquiposModal";
            this.Load += new System.EventHandler(this.frmEquiposModal_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmEquiposModal_KeyDown);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgReturn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinnerCant)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox imgReturn;
        private System.Windows.Forms.Label lblTituloHeader;
        private Controles.combo cboEquiposEstados;
        private System.Windows.Forms.Label lblEstado;
        private textboxAdv txtSerie;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private Controles.spinner spinnerCant;
        private Controles.combo cboEquipos_Modelos;
        private System.Windows.Forms.Label label4;
        private Controles.combo cboEquipos_Marcas;
        private Controles.combo cboEquipos_Tipos;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel1;
        private Controles.boton btnCancelar;
        private Controles.boton btnGuardar;
        private Controles.progress pgCircular;
        private System.Windows.Forms.Label lblAdvertenciaTipoEquipo;
        private System.Windows.Forms.MaskedTextBox txtMac;
    }
}