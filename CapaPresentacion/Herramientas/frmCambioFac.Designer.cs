namespace CapaPresentacion.Herramientas
{
    partial class frmCambioFac
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
            this.pnTitle = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.imgReturn = new System.Windows.Forms.PictureBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.txtCPServicio = new CapaPresentacion.textboxAdv();
            this.txtDeptoServicio = new CapaPresentacion.textboxAdv();
            this.txtPisoServicio = new CapaPresentacion.textboxAdv();
            this.txtAlturaServicio = new CapaPresentacion.textboxAdv();
            this.btnBuscarCalle = new CapaPresentacion.Controles.boton();
            this.txtCalleServicio = new CapaPresentacion.textboxAdv();
            this.cboLocalidades = new CapaPresentacion.Controles.combo(this.components);
            this.cboZona = new CapaPresentacion.Controles.combo(this.components);
            this.btnCancelar = new CapaPresentacion.Controles.boton();
            this.btnConfirmar = new CapaPresentacion.Controles.boton();
            this.pnTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgReturn)).BeginInit();
            this.SuspendLayout();
            // 
            // pnTitle
            // 
            this.pnTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.pnTitle.Controls.Add(this.label1);
            this.pnTitle.Controls.Add(this.imgReturn);
            this.pnTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnTitle.Location = new System.Drawing.Point(0, 0);
            this.pnTitle.Name = "pnTitle";
            this.pnTitle.Size = new System.Drawing.Size(397, 80);
            this.pnTitle.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(58, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 25);
            this.label1.TabIndex = 124;
            this.label1.Text = "Cambio de Zona";
            // 
            // imgReturn
            // 
            this.imgReturn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.imgReturn.Image = global::CapaPresentacion.Properties.Resources.Left_Arrow_32;
            this.imgReturn.Location = new System.Drawing.Point(12, 23);
            this.imgReturn.Name = "imgReturn";
            this.imgReturn.Size = new System.Drawing.Size(32, 32);
            this.imgReturn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgReturn.TabIndex = 33;
            this.imgReturn.TabStop = false;
            this.imgReturn.Click += new System.EventHandler(this.imgReturn_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.label11.Location = new System.Drawing.Point(8, 109);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(55, 25);
            this.label11.TabIndex = 119;
            this.label11.Text = "Zona";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.label2.Location = new System.Drawing.Point(8, 169);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 25);
            this.label2.TabIndex = 125;
            this.label2.Text = "Localidad";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.label25.ForeColor = System.Drawing.Color.Black;
            this.label25.Location = new System.Drawing.Point(279, 197);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(37, 25);
            this.label25.TabIndex = 151;
            this.label25.Text = "CP:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(5, 293);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 25);
            this.label8.TabIndex = 149;
            this.label8.Text = "Altura:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(15, 247);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 25);
            this.label7.TabIndex = 144;
            this.label7.Text = "Calle:";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.label22.ForeColor = System.Drawing.Color.Black;
            this.label22.Location = new System.Drawing.Point(266, 293);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(66, 25);
            this.label22.TabIndex = 153;
            this.label22.Text = "Depto:";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.label21.ForeColor = System.Drawing.Color.Black;
            this.label21.Location = new System.Drawing.Point(142, 293);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(49, 25);
            this.label21.TabIndex = 152;
            this.label21.Text = "Piso:";
            // 
            // txtCPServicio
            // 
            this.txtCPServicio.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtCPServicio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCPServicio.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCPServicio.FocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            this.txtCPServicio.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.txtCPServicio.ForeColor = System.Drawing.Color.DimGray;
            this.txtCPServicio.Location = new System.Drawing.Point(322, 195);
            this.txtCPServicio.Name = "txtCPServicio";
            this.txtCPServicio.Numerico = true;
            this.txtCPServicio.ReadOnly = true;
            this.txtCPServicio.Size = new System.Drawing.Size(63, 31);
            this.txtCPServicio.TabIndex = 150;
            this.txtCPServicio.Tag = "\"\"";
            this.txtCPServicio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtDeptoServicio
            // 
            this.txtDeptoServicio.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtDeptoServicio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDeptoServicio.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDeptoServicio.FocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            this.txtDeptoServicio.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.txtDeptoServicio.ForeColor = System.Drawing.Color.DimGray;
            this.txtDeptoServicio.Location = new System.Drawing.Point(338, 291);
            this.txtDeptoServicio.MaxLength = 3;
            this.txtDeptoServicio.Name = "txtDeptoServicio";
            this.txtDeptoServicio.Numerico = false;
            this.txtDeptoServicio.Size = new System.Drawing.Size(47, 31);
            this.txtDeptoServicio.TabIndex = 5;
            this.txtDeptoServicio.Tag = "\"\"";
            this.txtDeptoServicio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtPisoServicio
            // 
            this.txtPisoServicio.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtPisoServicio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPisoServicio.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPisoServicio.FocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            this.txtPisoServicio.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.txtPisoServicio.ForeColor = System.Drawing.Color.DimGray;
            this.txtPisoServicio.Location = new System.Drawing.Point(197, 291);
            this.txtPisoServicio.MaxLength = 3;
            this.txtPisoServicio.Name = "txtPisoServicio";
            this.txtPisoServicio.Numerico = false;
            this.txtPisoServicio.Size = new System.Drawing.Size(63, 31);
            this.txtPisoServicio.TabIndex = 4;
            this.txtPisoServicio.Tag = "\"\"";
            this.txtPisoServicio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtAlturaServicio
            // 
            this.txtAlturaServicio.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtAlturaServicio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAlturaServicio.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAlturaServicio.FocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            this.txtAlturaServicio.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.txtAlturaServicio.ForeColor = System.Drawing.Color.DimGray;
            this.txtAlturaServicio.Location = new System.Drawing.Point(73, 291);
            this.txtAlturaServicio.MaxLength = 5;
            this.txtAlturaServicio.Name = "txtAlturaServicio";
            this.txtAlturaServicio.Numerico = true;
            this.txtAlturaServicio.Size = new System.Drawing.Size(63, 31);
            this.txtAlturaServicio.TabIndex = 3;
            this.txtAlturaServicio.Tag = "\"\"";
            this.txtAlturaServicio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnBuscarCalle
            // 
            this.btnBuscarCalle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(84)))), ((int)(((byte)(101)))));
            this.btnBuscarCalle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscarCalle.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(84)))), ((int)(((byte)(101)))));
            this.btnBuscarCalle.FlatAppearance.BorderSize = 0;
            this.btnBuscarCalle.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(84)))), ((int)(((byte)(101)))));
            this.btnBuscarCalle.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            this.btnBuscarCalle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarCalle.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscarCalle.ForeColor = System.Drawing.Color.White;
            this.btnBuscarCalle.Image = global::CapaPresentacion.Properties.Resources.lupa;
            this.btnBuscarCalle.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBuscarCalle.Location = new System.Drawing.Point(338, 244);
            this.btnBuscarCalle.Name = "btnBuscarCalle";
            this.btnBuscarCalle.Size = new System.Drawing.Size(47, 32);
            this.btnBuscarCalle.TabIndex = 2;
            this.btnBuscarCalle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscarCalle.UseVisualStyleBackColor = false;
            this.btnBuscarCalle.Click += new System.EventHandler(this.btnBuscarCalle_Click);
            // 
            // txtCalleServicio
            // 
            this.txtCalleServicio.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtCalleServicio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCalleServicio.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCalleServicio.Enabled = false;
            this.txtCalleServicio.FocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            this.txtCalleServicio.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.txtCalleServicio.ForeColor = System.Drawing.Color.DimGray;
            this.txtCalleServicio.Location = new System.Drawing.Point(75, 245);
            this.txtCalleServicio.Name = "txtCalleServicio";
            this.txtCalleServicio.Numerico = false;
            this.txtCalleServicio.Size = new System.Drawing.Size(257, 31);
            this.txtCalleServicio.TabIndex = 2;
            this.txtCalleServicio.Tag = "\"0\"";
            // 
            // cboLocalidades
            // 
            this.cboLocalidades.BorderColor = System.Drawing.Color.Empty;
            this.cboLocalidades.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLocalidades.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboLocalidades.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboLocalidades.FormattingEnabled = true;
            this.cboLocalidades.Location = new System.Drawing.Point(13, 197);
            this.cboLocalidades.Name = "cboLocalidades";
            this.cboLocalidades.Size = new System.Drawing.Size(247, 29);
            this.cboLocalidades.TabIndex = 1;
            this.cboLocalidades.SelectedValueChanged += new System.EventHandler(this.cboLocalidades_SelectedValueChanged);
            // 
            // cboZona
            // 
            this.cboZona.BorderColor = System.Drawing.Color.Empty;
            this.cboZona.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboZona.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboZona.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboZona.FormattingEnabled = true;
            this.cboZona.Location = new System.Drawing.Point(13, 137);
            this.cboZona.Name = "cboZona";
            this.cboZona.Size = new System.Drawing.Size(372, 29);
            this.cboZona.TabIndex = 0;
            this.cboZona.SelectedValueChanged += new System.EventHandler(this.cboZona_SelectedValueChanged);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
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
            this.btnCancelar.Location = new System.Drawing.Point(285, 364);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(100, 35);
            this.btnCancelar.TabIndex = 7;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConfirmar.BackColor = System.Drawing.Color.SteelBlue;
            this.btnConfirmar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConfirmar.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
            this.btnConfirmar.FlatAppearance.BorderSize = 0;
            this.btnConfirmar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SteelBlue;
            this.btnConfirmar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SteelBlue;
            this.btnConfirmar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirmar.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirmar.ForeColor = System.Drawing.Color.White;
            this.btnConfirmar.Image = global::CapaPresentacion.Properties.Resources.Task_03_32;
            this.btnConfirmar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnConfirmar.Location = new System.Drawing.Point(155, 364);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(126, 35);
            this.btnConfirmar.TabIndex = 6;
            this.btnConfirmar.Text = "Confirmar";
            this.btnConfirmar.UseVisualStyleBackColor = false;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // frmCambioFac
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(397, 411);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtCPServicio);
            this.Controls.Add(this.txtDeptoServicio);
            this.Controls.Add(this.txtPisoServicio);
            this.Controls.Add(this.txtAlturaServicio);
            this.Controls.Add(this.btnBuscarCalle);
            this.Controls.Add(this.txtCalleServicio);
            this.Controls.Add(this.cboLocalidades);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboZona);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.pnTitle);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmCambioFac";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmFechaFactura";
            this.Load += new System.EventHandler(this.frmFechaFactura_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmFechaFactura_KeyDown);
            this.pnTitle.ResumeLayout(false);
            this.pnTitle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgReturn)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnTitle;
        private System.Windows.Forms.PictureBox imgReturn;
        private System.Windows.Forms.Label label11;
        private Controles.boton btnCancelar;
        private Controles.boton btnConfirmar;
        private System.Windows.Forms.Label label1;
        private Controles.combo cboZona;
        private Controles.combo cboLocalidades;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private textboxAdv txtCPServicio;
        private textboxAdv txtDeptoServicio;
        private textboxAdv txtPisoServicio;
        private textboxAdv txtAlturaServicio;
        private Controles.boton btnBuscarCalle;
        private textboxAdv txtCalleServicio;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label21;
    }
}