namespace CapaPresentacion.Partes_Trabajo
{
    partial class frmParteInfraestructura
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
            this.panel3 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblAvisoCalle = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.lblAltura = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblLocalidad = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label22 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cboTipoServicio = new CapaPresentacion.Controles.combo(this.components);
            this.btnCancelar = new CapaPresentacion.Controles.boton();
            this.btnConfirmar = new CapaPresentacion.Controles.boton();
            this.txtObsUsuario = new CapaPresentacion.textboxAdv();
            this.txtManzServicio = new CapaPresentacion.textboxAdv();
            this.txtParcelaServicio = new CapaPresentacion.textboxAdv();
            this.txtCPServicio = new CapaPresentacion.textboxAdv();
            this.txtDeptoServicio = new CapaPresentacion.textboxAdv();
            this.txtPisoServicio = new CapaPresentacion.textboxAdv();
            this.txtAlturaServicio = new CapaPresentacion.textboxAdv();
            this.txtEntreCalleServicio_2 = new CapaPresentacion.textboxAdv();
            this.txtEntreCalleServicio_1 = new CapaPresentacion.textboxAdv();
            this.btnBuscarCalle = new CapaPresentacion.Controles.boton();
            this.txtCalleServicio = new CapaPresentacion.textboxAdv();
            this.cboLocalidades = new CapaPresentacion.Controles.combo(this.components);
            this.cboGrupoServicio = new CapaPresentacion.Controles.combo(this.components);
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
            this.panel1.Size = new System.Drawing.Size(835, 75);
            this.panel1.TabIndex = 239;
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
            this.lblTituloHeader.Size = new System.Drawing.Size(246, 27);
            this.lblTituloHeader.TabIndex = 31;
            this.lblTituloHeader.Text = "Parte de Infraestructura";
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackColor = System.Drawing.Color.Gainsboro;
            this.panel3.Location = new System.Drawing.Point(98, 90);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(725, 1);
            this.panel3.TabIndex = 268;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.SteelBlue;
            this.label2.Location = new System.Drawing.Point(10, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(160, 25);
            this.label2.TabIndex = 269;
            this.label2.Text = "Datos de Servicio";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(33, 115);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(137, 21);
            this.label4.TabIndex = 274;
            this.label4.Text = "Grupo de Servicio:";
            // 
            // lblAvisoCalle
            // 
            this.lblAvisoCalle.AutoSize = true;
            this.lblAvisoCalle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblAvisoCalle.ForeColor = System.Drawing.Color.Red;
            this.lblAvisoCalle.Location = new System.Drawing.Point(502, 229);
            this.lblAvisoCalle.Name = "lblAvisoCalle";
            this.lblAvisoCalle.Size = new System.Drawing.Size(171, 19);
            this.lblAvisoCalle.TabIndex = 322;
            this.lblAvisoCalle.Text = "[Debe Seleccionar la Calle ]";
            this.lblAvisoCalle.Visible = false;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.ForeColor = System.Drawing.Color.Black;
            this.label23.Location = new System.Drawing.Point(677, 259);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(45, 21);
            this.label23.TabIndex = 321;
            this.label23.Text = "Parc.:";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.ForeColor = System.Drawing.Color.Black;
            this.label25.Location = new System.Drawing.Point(461, 257);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(32, 21);
            this.label25.TabIndex = 319;
            this.label25.Text = "CP:";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.ForeColor = System.Drawing.Color.Black;
            this.label24.Location = new System.Drawing.Point(563, 257);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(54, 21);
            this.label24.TabIndex = 320;
            this.label24.Text = "Manz.:";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.ForeColor = System.Drawing.Color.Black;
            this.label27.Location = new System.Drawing.Point(471, 312);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(22, 21);
            this.label27.TabIndex = 314;
            this.label27.Text = "Y:";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.ForeColor = System.Drawing.Color.Black;
            this.label26.Location = new System.Drawing.Point(25, 312);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(87, 21);
            this.label26.TabIndex = 313;
            this.label26.Text = "Entre Calle:";
            // 
            // lblAltura
            // 
            this.lblAltura.AutoSize = true;
            this.lblAltura.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblAltura.ForeColor = System.Drawing.Color.Red;
            this.lblAltura.Location = new System.Drawing.Point(114, 286);
            this.lblAltura.Name = "lblAltura";
            this.lblAltura.Size = new System.Drawing.Size(54, 19);
            this.lblAltura.TabIndex = 312;
            this.lblAltura.Text = "[Altura]";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(446, 198);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 21);
            this.label7.TabIndex = 311;
            this.label7.Text = "Calle:";
            // 
            // lblLocalidad
            // 
            this.lblLocalidad.AutoSize = true;
            this.lblLocalidad.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLocalidad.ForeColor = System.Drawing.Color.Black;
            this.lblLocalidad.Location = new System.Drawing.Point(33, 200);
            this.lblLocalidad.Name = "lblLocalidad";
            this.lblLocalidad.Size = new System.Drawing.Size(79, 21);
            this.lblLocalidad.TabIndex = 310;
            this.lblLocalidad.Text = "Localidad:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.SteelBlue;
            this.label5.Location = new System.Drawing.Point(12, 159);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(167, 25);
            this.label5.TabIndex = 309;
            this.label5.Text = "Datos de Locacion";
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.BackColor = System.Drawing.Color.Gainsboro;
            this.panel4.Location = new System.Drawing.Point(96, 174);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(725, 1);
            this.panel4.TabIndex = 308;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.ForeColor = System.Drawing.Color.Black;
            this.label22.Location = new System.Drawing.Point(292, 257);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(55, 21);
            this.label22.TabIndex = 317;
            this.label22.Text = "Depto:";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.Color.Black;
            this.label21.Location = new System.Drawing.Point(183, 257);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(42, 21);
            this.label21.TabIndex = 316;
            this.label21.Text = "Piso:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(57, 257);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(55, 21);
            this.label8.TabIndex = 315;
            this.label8.Text = "Altura:";
            // 
            // panel5
            // 
            this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel5.BackColor = System.Drawing.Color.Gainsboro;
            this.panel5.Location = new System.Drawing.Point(13, 371);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(808, 1);
            this.panel5.TabIndex = 326;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.SteelBlue;
            this.label1.Location = new System.Drawing.Point(10, 357);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 25);
            this.label1.TabIndex = 327;
            this.label1.Text = "Agregar Detalle";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(399, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(127, 21);
            this.label3.TabIndex = 331;
            this.label3.Text = "Tipo de  Servicio:";
            // 
            // cboTipoServicio
            // 
            this.cboTipoServicio.BorderColor = System.Drawing.Color.Gainsboro;
            this.cboTipoServicio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoServicio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboTipoServicio.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.cboTipoServicio.FormattingEnabled = true;
            this.cboTipoServicio.Items.AddRange(new object[] {
            "DNI",
            "CUIT",
            "CUIL"});
            this.cboTipoServicio.Location = new System.Drawing.Point(527, 112);
            this.cboTipoServicio.Name = "cboTipoServicio";
            this.cboTipoServicio.Size = new System.Drawing.Size(290, 31);
            this.cboTipoServicio.TabIndex = 330;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.AutoSize = true;
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.Location = new System.Drawing.Point(577, 500);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(102, 40);
            this.btnCancelar.TabIndex = 329;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
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
            this.btnConfirmar.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.btnConfirmar.ForeColor = System.Drawing.Color.White;
            this.btnConfirmar.Image = global::CapaPresentacion.Properties.Resources.Task_03_32;
            this.btnConfirmar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnConfirmar.Location = new System.Drawing.Point(692, 500);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(125, 40);
            this.btnConfirmar.TabIndex = 328;
            this.btnConfirmar.Text = "Confirmar";
            this.btnConfirmar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConfirmar.UseVisualStyleBackColor = false;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // txtObsUsuario
            // 
            this.txtObsUsuario.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtObsUsuario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtObsUsuario.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtObsUsuario.FocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.txtObsUsuario.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtObsUsuario.ForeColor = System.Drawing.Color.DimGray;
            this.txtObsUsuario.Location = new System.Drawing.Point(118, 389);
            this.txtObsUsuario.Multiline = true;
            this.txtObsUsuario.Name = "txtObsUsuario";
            this.txtObsUsuario.Numerico = false;
            this.txtObsUsuario.Size = new System.Drawing.Size(699, 93);
            this.txtObsUsuario.TabIndex = 324;
            this.txtObsUsuario.Tag = "\"\"";
            // 
            // txtManzServicio
            // 
            this.txtManzServicio.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtManzServicio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtManzServicio.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtManzServicio.FocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            this.txtManzServicio.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.txtManzServicio.ForeColor = System.Drawing.Color.DimGray;
            this.txtManzServicio.Location = new System.Drawing.Point(613, 254);
            this.txtManzServicio.Name = "txtManzServicio";
            this.txtManzServicio.Numerico = true;
            this.txtManzServicio.Size = new System.Drawing.Size(63, 31);
            this.txtManzServicio.TabIndex = 306;
            this.txtManzServicio.Tag = "\"\"";
            this.txtManzServicio.Text = "0";
            this.txtManzServicio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtParcelaServicio
            // 
            this.txtParcelaServicio.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtParcelaServicio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtParcelaServicio.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtParcelaServicio.FocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            this.txtParcelaServicio.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.txtParcelaServicio.ForeColor = System.Drawing.Color.DimGray;
            this.txtParcelaServicio.Location = new System.Drawing.Point(721, 254);
            this.txtParcelaServicio.MaxLength = 3;
            this.txtParcelaServicio.Name = "txtParcelaServicio";
            this.txtParcelaServicio.Numerico = true;
            this.txtParcelaServicio.Size = new System.Drawing.Size(63, 31);
            this.txtParcelaServicio.TabIndex = 307;
            this.txtParcelaServicio.Tag = "\"\"";
            this.txtParcelaServicio.Text = "0";
            this.txtParcelaServicio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtCPServicio
            // 
            this.txtCPServicio.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtCPServicio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCPServicio.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCPServicio.FocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            this.txtCPServicio.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.txtCPServicio.ForeColor = System.Drawing.Color.DimGray;
            this.txtCPServicio.Location = new System.Drawing.Point(494, 254);
            this.txtCPServicio.Name = "txtCPServicio";
            this.txtCPServicio.Numerico = true;
            this.txtCPServicio.ReadOnly = true;
            this.txtCPServicio.Size = new System.Drawing.Size(63, 31);
            this.txtCPServicio.TabIndex = 318;
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
            this.txtDeptoServicio.Location = new System.Drawing.Point(344, 252);
            this.txtDeptoServicio.MaxLength = 3;
            this.txtDeptoServicio.Name = "txtDeptoServicio";
            this.txtDeptoServicio.Numerico = false;
            this.txtDeptoServicio.Size = new System.Drawing.Size(63, 31);
            this.txtDeptoServicio.TabIndex = 305;
            this.txtDeptoServicio.Tag = "\"\"";
            this.txtDeptoServicio.Text = "0";
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
            this.txtPisoServicio.Location = new System.Drawing.Point(224, 252);
            this.txtPisoServicio.MaxLength = 3;
            this.txtPisoServicio.Name = "txtPisoServicio";
            this.txtPisoServicio.Numerico = false;
            this.txtPisoServicio.Size = new System.Drawing.Size(63, 31);
            this.txtPisoServicio.TabIndex = 304;
            this.txtPisoServicio.Tag = "\"\"";
            this.txtPisoServicio.Text = "0";
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
            this.txtAlturaServicio.Location = new System.Drawing.Point(118, 252);
            this.txtAlturaServicio.MaxLength = 5;
            this.txtAlturaServicio.Name = "txtAlturaServicio";
            this.txtAlturaServicio.Numerico = true;
            this.txtAlturaServicio.Size = new System.Drawing.Size(63, 31);
            this.txtAlturaServicio.TabIndex = 303;
            this.txtAlturaServicio.Tag = "\"\"";
            this.txtAlturaServicio.Text = "0";
            this.txtAlturaServicio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtEntreCalleServicio_2
            // 
            this.txtEntreCalleServicio_2.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtEntreCalleServicio_2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEntreCalleServicio_2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtEntreCalleServicio_2.FocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            this.txtEntreCalleServicio_2.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.txtEntreCalleServicio_2.ForeColor = System.Drawing.Color.DimGray;
            this.txtEntreCalleServicio_2.Location = new System.Drawing.Point(494, 307);
            this.txtEntreCalleServicio_2.MaxLength = 70;
            this.txtEntreCalleServicio_2.Name = "txtEntreCalleServicio_2";
            this.txtEntreCalleServicio_2.Numerico = false;
            this.txtEntreCalleServicio_2.Size = new System.Drawing.Size(294, 31);
            this.txtEntreCalleServicio_2.TabIndex = 302;
            this.txtEntreCalleServicio_2.Tag = "\"0\"";
            // 
            // txtEntreCalleServicio_1
            // 
            this.txtEntreCalleServicio_1.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtEntreCalleServicio_1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEntreCalleServicio_1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtEntreCalleServicio_1.FocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            this.txtEntreCalleServicio_1.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.txtEntreCalleServicio_1.ForeColor = System.Drawing.Color.DimGray;
            this.txtEntreCalleServicio_1.Location = new System.Drawing.Point(118, 307);
            this.txtEntreCalleServicio_1.MaxLength = 70;
            this.txtEntreCalleServicio_1.Name = "txtEntreCalleServicio_1";
            this.txtEntreCalleServicio_1.Numerico = false;
            this.txtEntreCalleServicio_1.Size = new System.Drawing.Size(289, 31);
            this.txtEntreCalleServicio_1.TabIndex = 301;
            this.txtEntreCalleServicio_1.Tag = "\"0\"";
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
            this.btnBuscarCalle.Location = new System.Drawing.Point(788, 195);
            this.btnBuscarCalle.Name = "btnBuscarCalle";
            this.btnBuscarCalle.Size = new System.Drawing.Size(28, 32);
            this.btnBuscarCalle.TabIndex = 300;
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
            this.txtCalleServicio.Location = new System.Drawing.Point(494, 195);
            this.txtCalleServicio.Name = "txtCalleServicio";
            this.txtCalleServicio.Numerico = false;
            this.txtCalleServicio.Size = new System.Drawing.Size(288, 31);
            this.txtCalleServicio.TabIndex = 299;
            this.txtCalleServicio.Tag = "\"0\"";
            // 
            // cboLocalidades
            // 
            this.cboLocalidades.BorderColor = System.Drawing.Color.Gainsboro;
            this.cboLocalidades.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLocalidades.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboLocalidades.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.cboLocalidades.FormattingEnabled = true;
            this.cboLocalidades.Location = new System.Drawing.Point(118, 195);
            this.cboLocalidades.Name = "cboLocalidades";
            this.cboLocalidades.Size = new System.Drawing.Size(289, 31);
            this.cboLocalidades.TabIndex = 298;
            this.cboLocalidades.SelectedValueChanged += new System.EventHandler(this.cboLocalidades_SelectedValueChanged);
            // 
            // cboGrupoServicio
            // 
            this.cboGrupoServicio.BorderColor = System.Drawing.Color.Gainsboro;
            this.cboGrupoServicio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGrupoServicio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboGrupoServicio.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.cboGrupoServicio.FormattingEnabled = true;
            this.cboGrupoServicio.Items.AddRange(new object[] {
            "CABLE",
            "INTERNET"});
            this.cboGrupoServicio.Location = new System.Drawing.Point(176, 111);
            this.cboGrupoServicio.Name = "cboGrupoServicio";
            this.cboGrupoServicio.Size = new System.Drawing.Size(217, 31);
            this.cboGrupoServicio.TabIndex = 273;
            // 
            // frmParteInfraestructura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(835, 559);
            this.Controls.Add(this.cboTipoServicio);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.txtObsUsuario);
            this.Controls.Add(this.txtManzServicio);
            this.Controls.Add(this.lblAvisoCalle);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.label27);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.lblAltura);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblLocalidad);
            this.Controls.Add(this.txtParcelaServicio);
            this.Controls.Add(this.txtCPServicio);
            this.Controls.Add(this.txtDeptoServicio);
            this.Controls.Add(this.txtPisoServicio);
            this.Controls.Add(this.txtAlturaServicio);
            this.Controls.Add(this.txtEntreCalleServicio_2);
            this.Controls.Add(this.txtEntreCalleServicio_1);
            this.Controls.Add(this.btnBuscarCalle);
            this.Controls.Add(this.txtCalleServicio);
            this.Controls.Add(this.cboLocalidades);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cboGrupoServicio);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmParteInfraestructura";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmParteInfraestructura";
            this.Load += new System.EventHandler(this.frmParteInfraestructura_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmParteInfraestructura_KeyDown);
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
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private Controles.combo cboGrupoServicio;
        private textboxAdv txtManzServicio;
        private System.Windows.Forms.Label lblAvisoCalle;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label lblAltura;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblLocalidad;
        private textboxAdv txtParcelaServicio;
        private textboxAdv txtCPServicio;
        private textboxAdv txtDeptoServicio;
        private textboxAdv txtPisoServicio;
        private textboxAdv txtAlturaServicio;
        private textboxAdv txtEntreCalleServicio_2;
        private textboxAdv txtEntreCalleServicio_1;
        private Controles.boton btnBuscarCalle;
        private textboxAdv txtCalleServicio;
        private Controles.combo cboLocalidades;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel5;
        private textboxAdv txtObsUsuario;
        private System.Windows.Forms.Label label1;
        private Controles.boton btnCancelar;
        private Controles.boton btnConfirmar;
        private Controles.combo cboTipoServicio;
        private System.Windows.Forms.Label label3;
    }
}