namespace CapaPresentacion.Abms
{
    partial class ABMClientes
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
            this.pnlSuperior = new System.Windows.Forms.Panel();
            this.imgReturn = new System.Windows.Forms.PictureBox();
            this.lblTituloHeader = new System.Windows.Forms.Label();
            this.chkExentoProv = new System.Windows.Forms.CheckBox();
            this.spImpuestoProv = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.lblCalculoBonificacion = new System.Windows.Forms.Label();
            this.chkDebitoAutomatico = new System.Windows.Forms.CheckBox();
            this.chkAdhesionFacturaElec = new System.Windows.Forms.CheckBox();
            this.lblCorreo = new System.Windows.Forms.Label();
            this.dtpFechaNacimiento = new System.Windows.Forms.DateTimePicker();
            this.lblFechaNac = new System.Windows.Forms.Label();
            this.lblCuit = new System.Windows.Forms.Label();
            this.lblCondicionIva = new System.Windows.Forms.Label();
            this.lblNumDoc = new System.Windows.Forms.Label();
            this.lblTipoDNI = new System.Windows.Forms.Label();
            this.lblApellido = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblTituloDatosContacto = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblProfesion = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblLocalidad = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblDepto = new System.Windows.Forms.Label();
            this.pnlBotones = new System.Windows.Forms.Panel();
            this.errorIcon = new System.Windows.Forms.ErrorProvider(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.txtTelefono2 = new CapaPresentacion.textboxAdv();
            this.boton1 = new CapaPresentacion.Controles.boton();
            this.txtCodigo = new CapaPresentacion.textboxAdv();
            this.txtPrefijo2 = new CapaPresentacion.textboxAdv();
            this.btnBuscarCalle = new CapaPresentacion.Controles.boton();
            this.txtTelefono1 = new CapaPresentacion.textboxAdv();
            this.txtPrefijo1 = new CapaPresentacion.textboxAdv();
            this.cboProfesion = new CapaPresentacion.Controles.combo(this.components);
            this.txtCorreo = new CapaPresentacion.textboxAdv();
            this.cboCalculoBonificaciones = new CapaPresentacion.Controles.combo(this.components);
            this.txtNombre = new CapaPresentacion.textboxAdv();
            this.txtCodigoPostal = new CapaPresentacion.textboxAdv();
            this.txtApellido = new CapaPresentacion.textboxAdv();
            this.txtDepto = new CapaPresentacion.textboxAdv();
            this.cboTipoDNI = new CapaPresentacion.Controles.combo(this.components);
            this.txtPiso = new CapaPresentacion.textboxAdv();
            this.cboCondIVA = new CapaPresentacion.Controles.combo(this.components);
            this.txtLocalidad = new CapaPresentacion.textboxAdv();
            this.txtAltura = new CapaPresentacion.textboxAdv();
            this.txtCUIT = new CapaPresentacion.textboxAdv();
            this.txtCalle = new CapaPresentacion.textboxAdv();
            this.txtNumero = new CapaPresentacion.textboxAdv();
            this.btnNuevo = new CapaPresentacion.Controles.boton();
            this.boton2 = new CapaPresentacion.Controles.boton();
            this.btnCancelar = new CapaPresentacion.Controles.boton();
            this.btnGuardar = new CapaPresentacion.Controles.boton();
            this.pnlSuperior.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgReturn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spImpuestoProv)).BeginInit();
            this.pnlBotones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorIcon)).BeginInit();
            this.pnlMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlSuperior
            // 
            this.pnlSuperior.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.pnlSuperior.Controls.Add(this.imgReturn);
            this.pnlSuperior.Controls.Add(this.lblTituloHeader);
            this.pnlSuperior.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSuperior.Location = new System.Drawing.Point(0, 0);
            this.pnlSuperior.Name = "pnlSuperior";
            this.pnlSuperior.Size = new System.Drawing.Size(1197, 75);
            this.pnlSuperior.TabIndex = 54;
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
            this.lblTituloHeader.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloHeader.ForeColor = System.Drawing.Color.White;
            this.lblTituloHeader.Location = new System.Drawing.Point(53, 27);
            this.lblTituloHeader.Name = "lblTituloHeader";
            this.lblTituloHeader.Size = new System.Drawing.Size(134, 23);
            this.lblTituloHeader.TabIndex = 31;
            this.lblTituloHeader.Text = "Clientes ";
            // 
            // chkExentoProv
            // 
            this.chkExentoProv.AutoSize = true;
            this.chkExentoProv.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkExentoProv.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.chkExentoProv.Location = new System.Drawing.Point(194, 252);
            this.chkExentoProv.Name = "chkExentoProv";
            this.chkExentoProv.Size = new System.Drawing.Size(207, 24);
            this.chkExentoProv.TabIndex = 7;
            this.chkExentoProv.Text = "Exento Impuesto Provincial";
            this.chkExentoProv.UseVisualStyleBackColor = true;
            // 
            // spImpuestoProv
            // 
            this.spImpuestoProv.DecimalPlaces = 2;
            this.spImpuestoProv.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.spImpuestoProv.Location = new System.Drawing.Point(209, 215);
            this.spImpuestoProv.Name = "spImpuestoProv";
            this.spImpuestoProv.Size = new System.Drawing.Size(192, 31);
            this.spImpuestoProv.TabIndex = 6;
            this.spImpuestoProv.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(22, 217);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(181, 25);
            this.label1.TabIndex = 332;
            this.label1.Text = "ARBA Percepcion (%):";
            // 
            // lblCalculoBonificacion
            // 
            this.lblCalculoBonificacion.AutoSize = true;
            this.lblCalculoBonificacion.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblCalculoBonificacion.ForeColor = System.Drawing.Color.Black;
            this.lblCalculoBonificacion.Location = new System.Drawing.Point(469, 184);
            this.lblCalculoBonificacion.Name = "lblCalculoBonificacion";
            this.lblCalculoBonificacion.Size = new System.Drawing.Size(96, 21);
            this.lblCalculoBonificacion.TabIndex = 331;
            this.lblCalculoBonificacion.Text = "Bonifica por:";
            // 
            // chkDebitoAutomatico
            // 
            this.chkDebitoAutomatico.AutoSize = true;
            this.chkDebitoAutomatico.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.chkDebitoAutomatico.Location = new System.Drawing.Point(658, 145);
            this.chkDebitoAutomatico.Name = "chkDebitoAutomatico";
            this.chkDebitoAutomatico.Size = new System.Drawing.Size(157, 25);
            this.chkDebitoAutomatico.TabIndex = 12;
            this.chkDebitoAutomatico.Text = "Débito automático";
            this.chkDebitoAutomatico.UseVisualStyleBackColor = true;
            // 
            // chkAdhesionFacturaElec
            // 
            this.chkAdhesionFacturaElec.AutoSize = true;
            this.chkAdhesionFacturaElec.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.chkAdhesionFacturaElec.Location = new System.Drawing.Point(478, 145);
            this.chkAdhesionFacturaElec.Name = "chkAdhesionFacturaElec";
            this.chkAdhesionFacturaElec.Size = new System.Drawing.Size(177, 25);
            this.chkAdhesionFacturaElec.TabIndex = 11;
            this.chkAdhesionFacturaElec.Text = "Adhesion Fact. Digital";
            this.chkAdhesionFacturaElec.UseVisualStyleBackColor = true;
            // 
            // lblCorreo
            // 
            this.lblCorreo.AutoSize = true;
            this.lblCorreo.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblCorreo.ForeColor = System.Drawing.Color.Black;
            this.lblCorreo.Location = new System.Drawing.Point(496, 110);
            this.lblCorreo.Name = "lblCorreo";
            this.lblCorreo.Size = new System.Drawing.Size(55, 21);
            this.lblCorreo.TabIndex = 327;
            this.lblCorreo.Text = "E mail:";
            // 
            // dtpFechaNacimiento
            // 
            this.dtpFechaNacimiento.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.dtpFechaNacimiento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaNacimiento.Location = new System.Drawing.Point(553, 35);
            this.dtpFechaNacimiento.Name = "dtpFechaNacimiento";
            this.dtpFechaNacimiento.Size = new System.Drawing.Size(149, 29);
            this.dtpFechaNacimiento.TabIndex = 8;
            // 
            // lblFechaNac
            // 
            this.lblFechaNac.AutoSize = true;
            this.lblFechaNac.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblFechaNac.ForeColor = System.Drawing.Color.Black;
            this.lblFechaNac.Location = new System.Drawing.Point(463, 37);
            this.lblFechaNac.Name = "lblFechaNac";
            this.lblFechaNac.Size = new System.Drawing.Size(84, 21);
            this.lblFechaNac.TabIndex = 323;
            this.lblFechaNac.Text = "Fecha nac.:";
            // 
            // lblCuit
            // 
            this.lblCuit.AutoSize = true;
            this.lblCuit.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.lblCuit.ForeColor = System.Drawing.Color.Black;
            this.lblCuit.Location = new System.Drawing.Point(160, 182);
            this.lblCuit.Name = "lblCuit";
            this.lblCuit.Size = new System.Drawing.Size(53, 25);
            this.lblCuit.TabIndex = 321;
            this.lblCuit.Text = "CUIT:";
            // 
            // lblCondicionIva
            // 
            this.lblCondicionIva.AutoSize = true;
            this.lblCondicionIva.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.lblCondicionIva.ForeColor = System.Drawing.Color.Black;
            this.lblCondicionIva.Location = new System.Drawing.Point(11, 145);
            this.lblCondicionIva.Name = "lblCondicionIva";
            this.lblCondicionIva.Size = new System.Drawing.Size(63, 25);
            this.lblCondicionIva.TabIndex = 319;
            this.lblCondicionIva.Text = "C. IVA:";
            // 
            // lblNumDoc
            // 
            this.lblNumDoc.AutoSize = true;
            this.lblNumDoc.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.lblNumDoc.ForeColor = System.Drawing.Color.Black;
            this.lblNumDoc.Location = new System.Drawing.Point(191, 107);
            this.lblNumDoc.Name = "lblNumDoc";
            this.lblNumDoc.Size = new System.Drawing.Size(46, 25);
            this.lblNumDoc.TabIndex = 317;
            this.lblNumDoc.Text = "Nro:";
            // 
            // lblTipoDNI
            // 
            this.lblTipoDNI.AutoSize = true;
            this.lblTipoDNI.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblTipoDNI.ForeColor = System.Drawing.Color.Black;
            this.lblTipoDNI.Location = new System.Drawing.Point(7, 108);
            this.lblTipoDNI.Name = "lblTipoDNI";
            this.lblTipoDNI.Size = new System.Drawing.Size(74, 21);
            this.lblTipoDNI.TabIndex = 316;
            this.lblTipoDNI.Text = "Tipo DNI:";
            // 
            // lblApellido
            // 
            this.lblApellido.AutoSize = true;
            this.lblApellido.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblApellido.ForeColor = System.Drawing.Color.Black;
            this.lblApellido.Location = new System.Drawing.Point(12, 72);
            this.lblApellido.Name = "lblApellido";
            this.lblApellido.Size = new System.Drawing.Size(70, 21);
            this.lblApellido.TabIndex = 314;
            this.lblApellido.Text = "Apellido:";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblNombre.ForeColor = System.Drawing.Color.Black;
            this.lblNombre.Location = new System.Drawing.Point(10, 37);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(71, 21);
            this.lblNombre.TabIndex = 312;
            this.lblNombre.Text = "Nombre:";
            // 
            // lblTituloDatosContacto
            // 
            this.lblTituloDatosContacto.AutoSize = true;
            this.lblTituloDatosContacto.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.lblTituloDatosContacto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            this.lblTituloDatosContacto.Location = new System.Drawing.Point(13, 278);
            this.lblTituloDatosContacto.Name = "lblTituloDatosContacto";
            this.lblTituloDatosContacto.Size = new System.Drawing.Size(158, 25);
            this.lblTituloDatosContacto.TabIndex = 337;
            this.lblTituloDatosContacto.Text = "Datos de Locacion";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.Gainsboro;
            this.panel2.Location = new System.Drawing.Point(147, 292);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1031, 1);
            this.panel2.TabIndex = 336;
            // 
            // lblProfesion
            // 
            this.lblProfesion.AutoSize = true;
            this.lblProfesion.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblProfesion.ForeColor = System.Drawing.Color.Black;
            this.lblProfesion.Location = new System.Drawing.Point(471, 72);
            this.lblProfesion.Name = "lblProfesion";
            this.lblProfesion.Size = new System.Drawing.Size(79, 21);
            this.lblProfesion.TabIndex = 325;
            this.lblProfesion.Text = "Profesión:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(53, 317);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 21);
            this.label2.TabIndex = 339;
            this.label2.Text = "Calle:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(439, 317);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 21);
            this.label3.TabIndex = 340;
            this.label3.Text = "Altura:";
            // 
            // lblLocalidad
            // 
            this.lblLocalidad.AutoSize = true;
            this.lblLocalidad.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblLocalidad.ForeColor = System.Drawing.Color.Black;
            this.lblLocalidad.Location = new System.Drawing.Point(21, 352);
            this.lblLocalidad.Name = "lblLocalidad";
            this.lblLocalidad.Size = new System.Drawing.Size(79, 21);
            this.lblLocalidad.TabIndex = 343;
            this.lblLocalidad.Text = "Localidad:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(575, 317);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 21);
            this.label4.TabIndex = 344;
            this.label4.Text = "Piso:";
            // 
            // lblDepto
            // 
            this.lblDepto.AutoSize = true;
            this.lblDepto.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblDepto.ForeColor = System.Drawing.Color.Black;
            this.lblDepto.Location = new System.Drawing.Point(693, 317);
            this.lblDepto.Name = "lblDepto";
            this.lblDepto.Size = new System.Drawing.Size(55, 21);
            this.lblDepto.TabIndex = 346;
            this.lblDepto.Text = "Depto:";
            // 
            // pnlBotones
            // 
            this.pnlBotones.Controls.Add(this.btnNuevo);
            this.pnlBotones.Controls.Add(this.boton2);
            this.pnlBotones.Controls.Add(this.btnCancelar);
            this.pnlBotones.Controls.Add(this.btnGuardar);
            this.pnlBotones.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBotones.Location = new System.Drawing.Point(0, 75);
            this.pnlBotones.Name = "pnlBotones";
            this.pnlBotones.Size = new System.Drawing.Size(1197, 54);
            this.pnlBotones.TabIndex = 348;
            // 
            // errorIcon
            // 
            this.errorIcon.ContainerControl = this;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(439, 352);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(108, 21);
            this.label5.TabIndex = 25;
            this.label5.Text = "Codigo Postal:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(192, 431);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 21);
            this.label6.TabIndex = 356;
            this.label6.Text = "Telefono";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(49, 431);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 21);
            this.label7.TabIndex = 354;
            this.label7.Text = "Prefijo:";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            this.label8.Location = new System.Drawing.Point(9, 396);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(161, 25);
            this.label8.TabIndex = 352;
            this.label8.Text = "Datos de Contacto";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.Location = new System.Drawing.Point(143, 410);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1031, 1);
            this.panel1.TabIndex = 351;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(192, 466);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(68, 21);
            this.label9.TabIndex = 360;
            this.label9.Text = "Telefono";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(49, 466);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(58, 21);
            this.label10.TabIndex = 358;
            this.label10.Text = "Prefijo:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(18, 2);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(63, 21);
            this.label11.TabIndex = 364;
            this.label11.Text = "Codigo:";
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.lblFechaNac);
            this.pnlMain.Controls.Add(this.txtTelefono2);
            this.pnlMain.Controls.Add(this.boton1);
            this.pnlMain.Controls.Add(this.label9);
            this.pnlMain.Controls.Add(this.txtCodigo);
            this.pnlMain.Controls.Add(this.txtPrefijo2);
            this.pnlMain.Controls.Add(this.btnBuscarCalle);
            this.pnlMain.Controls.Add(this.label10);
            this.pnlMain.Controls.Add(this.dtpFechaNacimiento);
            this.pnlMain.Controls.Add(this.txtTelefono1);
            this.pnlMain.Controls.Add(this.label11);
            this.pnlMain.Controls.Add(this.label6);
            this.pnlMain.Controls.Add(this.lblProfesion);
            this.pnlMain.Controls.Add(this.txtPrefijo1);
            this.pnlMain.Controls.Add(this.cboProfesion);
            this.pnlMain.Controls.Add(this.label7);
            this.pnlMain.Controls.Add(this.lblCorreo);
            this.pnlMain.Controls.Add(this.label8);
            this.pnlMain.Controls.Add(this.panel1);
            this.pnlMain.Controls.Add(this.txtCorreo);
            this.pnlMain.Controls.Add(this.chkAdhesionFacturaElec);
            this.pnlMain.Controls.Add(this.chkDebitoAutomatico);
            this.pnlMain.Controls.Add(this.lblCalculoBonificacion);
            this.pnlMain.Controls.Add(this.cboCalculoBonificaciones);
            this.pnlMain.Controls.Add(this.txtNombre);
            this.pnlMain.Controls.Add(this.txtCodigoPostal);
            this.pnlMain.Controls.Add(this.lblNombre);
            this.pnlMain.Controls.Add(this.label5);
            this.pnlMain.Controls.Add(this.lblApellido);
            this.pnlMain.Controls.Add(this.txtApellido);
            this.pnlMain.Controls.Add(this.txtDepto);
            this.pnlMain.Controls.Add(this.cboTipoDNI);
            this.pnlMain.Controls.Add(this.lblDepto);
            this.pnlMain.Controls.Add(this.lblTipoDNI);
            this.pnlMain.Controls.Add(this.txtPiso);
            this.pnlMain.Controls.Add(this.lblNumDoc);
            this.pnlMain.Controls.Add(this.label4);
            this.pnlMain.Controls.Add(this.cboCondIVA);
            this.pnlMain.Controls.Add(this.txtLocalidad);
            this.pnlMain.Controls.Add(this.lblCondicionIva);
            this.pnlMain.Controls.Add(this.lblLocalidad);
            this.pnlMain.Controls.Add(this.lblCuit);
            this.pnlMain.Controls.Add(this.txtAltura);
            this.pnlMain.Controls.Add(this.txtCUIT);
            this.pnlMain.Controls.Add(this.label3);
            this.pnlMain.Controls.Add(this.label1);
            this.pnlMain.Controls.Add(this.txtCalle);
            this.pnlMain.Controls.Add(this.spImpuestoProv);
            this.pnlMain.Controls.Add(this.label2);
            this.pnlMain.Controls.Add(this.chkExentoProv);
            this.pnlMain.Controls.Add(this.lblTituloDatosContacto);
            this.pnlMain.Controls.Add(this.panel2);
            this.pnlMain.Controls.Add(this.txtNumero);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 129);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1197, 522);
            this.pnlMain.TabIndex = 365;
            // 
            // txtTelefono2
            // 
            this.txtTelefono2.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtTelefono2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTelefono2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTelefono2.FocusColor = System.Drawing.Color.Empty;
            this.txtTelefono2.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtTelefono2.ForeColor = System.Drawing.Color.Black;
            this.txtTelefono2.Location = new System.Drawing.Point(268, 464);
            this.txtTelefono2.MaxLength = 50;
            this.txtTelefono2.Name = "txtTelefono2";
            this.txtTelefono2.Numerico = true;
            this.txtTelefono2.Size = new System.Drawing.Size(265, 29);
            this.txtTelefono2.TabIndex = 23;
            this.txtTelefono2.Text = "0";
            this.txtTelefono2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // boton1
            // 
            this.boton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(84)))), ((int)(((byte)(101)))));
            this.boton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.boton1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(84)))), ((int)(((byte)(101)))));
            this.boton1.FlatAppearance.BorderSize = 0;
            this.boton1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(84)))), ((int)(((byte)(101)))));
            this.boton1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            this.boton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.boton1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.boton1.ForeColor = System.Drawing.Color.White;
            this.boton1.Image = global::CapaPresentacion.Properties.Resources.lupa;
            this.boton1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.boton1.Location = new System.Drawing.Point(377, 352);
            this.boton1.Name = "boton1";
            this.boton1.Size = new System.Drawing.Size(35, 29);
            this.boton1.TabIndex = 362;
            this.boton1.UseVisualStyleBackColor = false;
            // 
            // txtCodigo
            // 
            this.txtCodigo.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtCodigo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCodigo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCodigo.FocusColor = System.Drawing.Color.Empty;
            this.txtCodigo.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtCodigo.ForeColor = System.Drawing.Color.Black;
            this.txtCodigo.Location = new System.Drawing.Point(87, 0);
            this.txtCodigo.MaxLength = 50;
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Numerico = false;
            this.txtCodigo.ReadOnly = true;
            this.txtCodigo.Size = new System.Drawing.Size(90, 29);
            this.txtCodigo.TabIndex = 363;
            this.txtCodigo.Text = "0";
            this.txtCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtPrefijo2
            // 
            this.txtPrefijo2.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtPrefijo2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPrefijo2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPrefijo2.FocusColor = System.Drawing.Color.Empty;
            this.txtPrefijo2.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtPrefijo2.ForeColor = System.Drawing.Color.Black;
            this.txtPrefijo2.Location = new System.Drawing.Point(113, 464);
            this.txtPrefijo2.MaxLength = 50;
            this.txtPrefijo2.Name = "txtPrefijo2";
            this.txtPrefijo2.Numerico = true;
            this.txtPrefijo2.Size = new System.Drawing.Size(73, 29);
            this.txtPrefijo2.TabIndex = 22;
            this.txtPrefijo2.Text = "0";
            this.txtPrefijo2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
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
            this.btnBuscarCalle.Location = new System.Drawing.Point(377, 315);
            this.btnBuscarCalle.Name = "btnBuscarCalle";
            this.btnBuscarCalle.Size = new System.Drawing.Size(35, 29);
            this.btnBuscarCalle.TabIndex = 361;
            this.btnBuscarCalle.UseVisualStyleBackColor = false;
            // 
            // txtTelefono1
            // 
            this.txtTelefono1.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtTelefono1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTelefono1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTelefono1.FocusColor = System.Drawing.Color.Empty;
            this.txtTelefono1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtTelefono1.ForeColor = System.Drawing.Color.Black;
            this.txtTelefono1.Location = new System.Drawing.Point(268, 429);
            this.txtTelefono1.MaxLength = 50;
            this.txtTelefono1.Name = "txtTelefono1";
            this.txtTelefono1.Numerico = true;
            this.txtTelefono1.Size = new System.Drawing.Size(265, 29);
            this.txtTelefono1.TabIndex = 21;
            this.txtTelefono1.Text = "0";
            this.txtTelefono1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtPrefijo1
            // 
            this.txtPrefijo1.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtPrefijo1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPrefijo1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPrefijo1.FocusColor = System.Drawing.Color.Empty;
            this.txtPrefijo1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtPrefijo1.ForeColor = System.Drawing.Color.Black;
            this.txtPrefijo1.Location = new System.Drawing.Point(113, 429);
            this.txtPrefijo1.MaxLength = 50;
            this.txtPrefijo1.Name = "txtPrefijo1";
            this.txtPrefijo1.Numerico = true;
            this.txtPrefijo1.Size = new System.Drawing.Size(73, 29);
            this.txtPrefijo1.TabIndex = 20;
            this.txtPrefijo1.Text = "0";
            this.txtPrefijo1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cboProfesion
            // 
            this.cboProfesion.BorderColor = System.Drawing.Color.Empty;
            this.cboProfesion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProfesion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboProfesion.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cboProfesion.ForeColor = System.Drawing.Color.Black;
            this.cboProfesion.FormattingEnabled = true;
            this.cboProfesion.Location = new System.Drawing.Point(553, 69);
            this.cboProfesion.Name = "cboProfesion";
            this.cboProfesion.Size = new System.Drawing.Size(265, 29);
            this.cboProfesion.TabIndex = 9;
            // 
            // txtCorreo
            // 
            this.txtCorreo.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtCorreo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCorreo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCorreo.FocusColor = System.Drawing.Color.Empty;
            this.txtCorreo.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtCorreo.Location = new System.Drawing.Point(553, 108);
            this.txtCorreo.MaxLength = 50;
            this.txtCorreo.Name = "txtCorreo";
            this.txtCorreo.Numerico = false;
            this.txtCorreo.Size = new System.Drawing.Size(265, 29);
            this.txtCorreo.TabIndex = 10;
            // 
            // cboCalculoBonificaciones
            // 
            this.cboCalculoBonificaciones.BorderColor = System.Drawing.Color.Empty;
            this.cboCalculoBonificaciones.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCalculoBonificaciones.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboCalculoBonificaciones.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cboCalculoBonificaciones.ForeColor = System.Drawing.Color.Black;
            this.cboCalculoBonificaciones.FormattingEnabled = true;
            this.cboCalculoBonificaciones.Items.AddRange(new object[] {
            "POR USUARIO",
            "POR LOCACIÓN",
            "NO SE APLICA"});
            this.cboCalculoBonificaciones.Location = new System.Drawing.Point(577, 180);
            this.cboCalculoBonificaciones.Name = "cboCalculoBonificaciones";
            this.cboCalculoBonificaciones.Size = new System.Drawing.Size(241, 29);
            this.cboCalculoBonificaciones.TabIndex = 13;
            // 
            // txtNombre
            // 
            this.txtNombre.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtNombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNombre.FocusColor = System.Drawing.Color.Empty;
            this.txtNombre.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtNombre.ForeColor = System.Drawing.Color.Black;
            this.txtNombre.Location = new System.Drawing.Point(87, 35);
            this.txtNombre.MaxLength = 50;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Numerico = false;
            this.txtNombre.Size = new System.Drawing.Size(314, 29);
            this.txtNombre.TabIndex = 0;
            // 
            // txtCodigoPostal
            // 
            this.txtCodigoPostal.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtCodigoPostal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCodigoPostal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCodigoPostal.FocusColor = System.Drawing.Color.Empty;
            this.txtCodigoPostal.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtCodigoPostal.ForeColor = System.Drawing.Color.Black;
            this.txtCodigoPostal.Location = new System.Drawing.Point(553, 350);
            this.txtCodigoPostal.MaxLength = 8;
            this.txtCodigoPostal.Name = "txtCodigoPostal";
            this.txtCodigoPostal.Numerico = true;
            this.txtCodigoPostal.Size = new System.Drawing.Size(78, 29);
            this.txtCodigoPostal.TabIndex = 19;
            this.txtCodigoPostal.Text = "0";
            this.txtCodigoPostal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtApellido
            // 
            this.txtApellido.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtApellido.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtApellido.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtApellido.FocusColor = System.Drawing.Color.Empty;
            this.txtApellido.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtApellido.ForeColor = System.Drawing.Color.Black;
            this.txtApellido.Location = new System.Drawing.Point(87, 70);
            this.txtApellido.MaxLength = 50;
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Numerico = false;
            this.txtApellido.Size = new System.Drawing.Size(314, 29);
            this.txtApellido.TabIndex = 1;
            // 
            // txtDepto
            // 
            this.txtDepto.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtDepto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDepto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDepto.FocusColor = System.Drawing.Color.Empty;
            this.txtDepto.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtDepto.ForeColor = System.Drawing.Color.Black;
            this.txtDepto.Location = new System.Drawing.Point(754, 315);
            this.txtDepto.MaxLength = 8;
            this.txtDepto.Name = "txtDepto";
            this.txtDepto.Numerico = false;
            this.txtDepto.Size = new System.Drawing.Size(65, 29);
            this.txtDepto.TabIndex = 17;
            this.txtDepto.Text = "0";
            this.txtDepto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cboTipoDNI
            // 
            this.cboTipoDNI.BorderColor = System.Drawing.Color.Empty;
            this.cboTipoDNI.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoDNI.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboTipoDNI.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cboTipoDNI.ForeColor = System.Drawing.Color.Black;
            this.cboTipoDNI.FormattingEnabled = true;
            this.cboTipoDNI.Location = new System.Drawing.Point(87, 105);
            this.cboTipoDNI.Name = "cboTipoDNI";
            this.cboTipoDNI.Size = new System.Drawing.Size(103, 29);
            this.cboTipoDNI.TabIndex = 2;
            // 
            // txtPiso
            // 
            this.txtPiso.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtPiso.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPiso.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPiso.FocusColor = System.Drawing.Color.Empty;
            this.txtPiso.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtPiso.ForeColor = System.Drawing.Color.Black;
            this.txtPiso.Location = new System.Drawing.Point(623, 315);
            this.txtPiso.MaxLength = 8;
            this.txtPiso.Name = "txtPiso";
            this.txtPiso.Numerico = false;
            this.txtPiso.Size = new System.Drawing.Size(65, 29);
            this.txtPiso.TabIndex = 16;
            this.txtPiso.Text = "0";
            this.txtPiso.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cboCondIVA
            // 
            this.cboCondIVA.BorderColor = System.Drawing.Color.Gainsboro;
            this.cboCondIVA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCondIVA.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboCondIVA.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.cboCondIVA.FormattingEnabled = true;
            this.cboCondIVA.Items.AddRange(new object[] {
            "DNI",
            "CUIT",
            "CUIL"});
            this.cboCondIVA.Location = new System.Drawing.Point(87, 142);
            this.cboCondIVA.Name = "cboCondIVA";
            this.cboCondIVA.Size = new System.Drawing.Size(314, 31);
            this.cboCondIVA.TabIndex = 4;
            this.cboCondIVA.SelectedIndexChanged += new System.EventHandler(this.cboCondIVA_SelectedIndexChanged);
            // 
            // txtLocalidad
            // 
            this.txtLocalidad.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtLocalidad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLocalidad.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtLocalidad.FocusColor = System.Drawing.Color.Empty;
            this.txtLocalidad.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtLocalidad.ForeColor = System.Drawing.Color.Black;
            this.txtLocalidad.Location = new System.Drawing.Point(106, 350);
            this.txtLocalidad.MaxLength = 50;
            this.txtLocalidad.Name = "txtLocalidad";
            this.txtLocalidad.Numerico = false;
            this.txtLocalidad.Size = new System.Drawing.Size(265, 29);
            this.txtLocalidad.TabIndex = 18;
            // 
            // txtAltura
            // 
            this.txtAltura.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtAltura.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAltura.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAltura.FocusColor = System.Drawing.Color.Empty;
            this.txtAltura.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtAltura.ForeColor = System.Drawing.Color.Black;
            this.txtAltura.Location = new System.Drawing.Point(500, 315);
            this.txtAltura.MaxLength = 8;
            this.txtAltura.Name = "txtAltura";
            this.txtAltura.Numerico = true;
            this.txtAltura.Size = new System.Drawing.Size(65, 29);
            this.txtAltura.TabIndex = 15;
            this.txtAltura.Text = "0";
            this.txtAltura.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtCUIT
            // 
            this.txtCUIT.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtCUIT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCUIT.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCUIT.FocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            this.txtCUIT.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.txtCUIT.ForeColor = System.Drawing.Color.DimGray;
            this.txtCUIT.Location = new System.Drawing.Point(209, 179);
            this.txtCUIT.MaxLength = 11;
            this.txtCUIT.Name = "txtCUIT";
            this.txtCUIT.Numerico = true;
            this.txtCUIT.Size = new System.Drawing.Size(192, 31);
            this.txtCUIT.TabIndex = 5;
            this.txtCUIT.Tag = "\"\"";
            this.txtCUIT.Text = "0";
            this.txtCUIT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtCalle
            // 
            this.txtCalle.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtCalle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCalle.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCalle.FocusColor = System.Drawing.Color.Empty;
            this.txtCalle.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtCalle.ForeColor = System.Drawing.Color.Black;
            this.txtCalle.Location = new System.Drawing.Point(106, 315);
            this.txtCalle.MaxLength = 50;
            this.txtCalle.Name = "txtCalle";
            this.txtCalle.Numerico = false;
            this.txtCalle.Size = new System.Drawing.Size(265, 29);
            this.txtCalle.TabIndex = 14;
            // 
            // txtNumero
            // 
            this.txtNumero.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtNumero.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNumero.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNumero.FocusColor = System.Drawing.Color.Empty;
            this.txtNumero.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtNumero.ForeColor = System.Drawing.Color.Black;
            this.txtNumero.Location = new System.Drawing.Point(243, 107);
            this.txtNumero.MaxLength = 8;
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Numerico = true;
            this.txtNumero.Size = new System.Drawing.Size(158, 29);
            this.txtNumero.TabIndex = 3;
            this.txtNumero.Text = "0";
            this.txtNumero.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnNuevo
            // 
            this.btnNuevo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNuevo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnNuevo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNuevo.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnNuevo.FlatAppearance.BorderSize = 0;
            this.btnNuevo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnNuevo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevo.Font = new System.Drawing.Font("Segoe UI Light", 12F);
            this.btnNuevo.ForeColor = System.Drawing.Color.White;
            this.btnNuevo.Image = global::CapaPresentacion.Properties.Resources.Command_Redo_32;
            this.btnNuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNuevo.Location = new System.Drawing.Point(719, 6);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(113, 38);
            this.btnNuevo.TabIndex = 190;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNuevo.UseVisualStyleBackColor = false;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // boton2
            // 
            this.boton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.boton2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.boton2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.boton2.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.boton2.FlatAppearance.BorderSize = 0;
            this.boton2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.boton2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.boton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.boton2.Font = new System.Drawing.Font("Segoe UI Light", 12F);
            this.boton2.ForeColor = System.Drawing.Color.White;
            this.boton2.Image = global::CapaPresentacion.Properties.Resources.Command_Redo_32;
            this.boton2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.boton2.Location = new System.Drawing.Point(838, 6);
            this.boton2.Name = "boton2";
            this.boton2.Size = new System.Drawing.Size(113, 38);
            this.boton2.TabIndex = 189;
            this.boton2.Text = "Editar";
            this.boton2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.boton2.UseVisualStyleBackColor = false;
            this.boton2.Click += new System.EventHandler(this.boton2_Click);
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
            this.btnCancelar.Location = new System.Drawing.Point(1072, 6);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(113, 38);
            this.btnCancelar.TabIndex = 188;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGuardar.BackColor = System.Drawing.Color.SteelBlue;
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
            this.btnGuardar.Location = new System.Drawing.Point(957, 6);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(113, 38);
            this.btnGuardar.TabIndex = 187;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // ABMClientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1197, 651);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlBotones);
            this.Controls.Add(this.pnlSuperior);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "ABMClientes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ABMClientes";
            this.Load += new System.EventHandler(this.ABMClientes_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ABMClientes_KeyDown);
            this.pnlSuperior.ResumeLayout(false);
            this.pnlSuperior.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgReturn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spImpuestoProv)).EndInit();
            this.pnlBotones.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorIcon)).EndInit();
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlSuperior;
        private System.Windows.Forms.PictureBox imgReturn;
        private System.Windows.Forms.Label lblTituloHeader;
        private textboxAdv txtNumero;
        private System.Windows.Forms.CheckBox chkExentoProv;
        private System.Windows.Forms.NumericUpDown spImpuestoProv;
        private System.Windows.Forms.Label label1;
        private Controles.combo cboCalculoBonificaciones;
        private System.Windows.Forms.Label lblCalculoBonificacion;
        private System.Windows.Forms.CheckBox chkDebitoAutomatico;
        private System.Windows.Forms.CheckBox chkAdhesionFacturaElec;
        private textboxAdv txtCorreo;
        private System.Windows.Forms.Label lblCorreo;
        private System.Windows.Forms.DateTimePicker dtpFechaNacimiento;
        private System.Windows.Forms.Label lblFechaNac;
        private textboxAdv txtCUIT;
        private System.Windows.Forms.Label lblCuit;
        private System.Windows.Forms.Label lblCondicionIva;
        private Controles.combo cboCondIVA;
        private System.Windows.Forms.Label lblNumDoc;
        private System.Windows.Forms.Label lblTipoDNI;
        private Controles.combo cboTipoDNI;
        private textboxAdv txtApellido;
        private System.Windows.Forms.Label lblApellido;
        private textboxAdv txtNombre;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblTituloDatosContacto;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblProfesion;
        private Controles.combo cboProfesion;
        private textboxAdv txtCalle;
        private System.Windows.Forms.Label label2;
        private textboxAdv txtAltura;
        private System.Windows.Forms.Label label3;
        private textboxAdv txtLocalidad;
        private System.Windows.Forms.Label lblLocalidad;
        private textboxAdv txtPiso;
        private System.Windows.Forms.Label label4;
        private textboxAdv txtDepto;
        private System.Windows.Forms.Label lblDepto;
        private System.Windows.Forms.Panel pnlBotones;
        private Controles.boton btnCancelar;
        private Controles.boton btnGuardar;
        private System.Windows.Forms.ErrorProvider errorIcon;
        private textboxAdv txtCodigoPostal;
        private System.Windows.Forms.Label label5;
        private textboxAdv txtTelefono1;
        private System.Windows.Forms.Label label6;
        private textboxAdv txtPrefijo1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel1;
        private textboxAdv txtTelefono2;
        private System.Windows.Forms.Label label9;
        private textboxAdv txtPrefijo2;
        private System.Windows.Forms.Label label10;
        private Controles.boton boton1;
        private Controles.boton btnBuscarCalle;
        private textboxAdv txtCodigo;
        private System.Windows.Forms.Label label11;
        private Controles.boton btnNuevo;
        private Controles.boton boton2;
        private System.Windows.Forms.Panel pnlMain;
    }
}