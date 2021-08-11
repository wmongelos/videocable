namespace CapaPresentacion.Abms
{
    partial class ABMLocaciones_Fiscales
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel3 = new System.Windows.Forms.Panel();
            this.imgReturn = new System.Windows.Forms.PictureBox();
            this.lblTituloHeader = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelCargaEdicion = new System.Windows.Forms.Panel();
            this.btnGuardar = new CapaPresentacion.Controles.boton();
            this.txtTelefono = new CapaPresentacion.textboxAdv();
            this.label5 = new System.Windows.Forms.Label();
            this.cboProvincia = new CapaPresentacion.Controles.combo(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.btnCancelar = new CapaPresentacion.Controles.boton();
            this.txtLocalidad = new CapaPresentacion.textboxAdv();
            this.label2 = new System.Windows.Forms.Label();
            this.label40 = new System.Windows.Forms.Label();
            this.label41 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCUIT = new CapaPresentacion.textboxAdv();
            this.cboCondIVA = new CapaPresentacion.Controles.combo(this.components);
            this.txtRSocial = new CapaPresentacion.textboxAdv();
            this.label25 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtCP = new CapaPresentacion.textboxAdv();
            this.txtDepto = new CapaPresentacion.textboxAdv();
            this.txtPiso = new CapaPresentacion.textboxAdv();
            this.txtAltura = new CapaPresentacion.textboxAdv();
            this.txtCalle = new CapaPresentacion.textboxAdv();
            this.panel4 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblTituloPanel = new System.Windows.Forms.Label();
            this.pgCircular = new CapaPresentacion.Controles.progress();
            this.btnEliminar = new CapaPresentacion.Controles.boton();
            this.btnEditar = new CapaPresentacion.Controles.boton();
            this.btnNuevo = new CapaPresentacion.Controles.boton();
            this.btnActualizar = new CapaPresentacion.Controles.boton();
            this.dgvLocacionesFiscales = new CapaPresentacion.Controles.dgv(this.components);
            this.dgvLocacionesServicios = new CapaPresentacion.Controles.dgv(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.btnAgregarLocacionServicio = new CapaPresentacion.Controles.boton();
            this.label6 = new System.Windows.Forms.Label();
            this.numProvincial = new System.Windows.Forms.NumericUpDown();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgReturn)).BeginInit();
            this.panelCargaEdicion.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocacionesFiscales)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocacionesServicios)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numProvincial)).BeginInit();
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
            this.panel3.Size = new System.Drawing.Size(1098, 100);
            this.panel3.TabIndex = 317;
            // 
            // imgReturn
            // 
            this.imgReturn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.imgReturn.Image = global::CapaPresentacion.Properties.Resources.Left_Arrow_32;
            this.imgReturn.Location = new System.Drawing.Point(16, 35);
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
            this.lblTituloHeader.Location = new System.Drawing.Point(54, 40);
            this.lblTituloHeader.Name = "lblTituloHeader";
            this.lblTituloHeader.Size = new System.Drawing.Size(338, 23);
            this.lblTituloHeader.TabIndex = 31;
            this.lblTituloHeader.Text = "Locaciones fiscales";
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblTitulo.ForeColor = System.Drawing.Color.Black;
            this.lblTitulo.Location = new System.Drawing.Point(7, 151);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(224, 21);
            this.lblTitulo.TabIndex = 320;
            this.lblTitulo.Text = "Locaciones fiscales del usuario:";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.Location = new System.Drawing.Point(0, 147);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1098, 1);
            this.panel1.TabIndex = 328;
            // 
            // panelCargaEdicion
            // 
            this.panelCargaEdicion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelCargaEdicion.Controls.Add(this.numProvincial);
            this.panelCargaEdicion.Controls.Add(this.label6);
            this.panelCargaEdicion.Controls.Add(this.btnGuardar);
            this.panelCargaEdicion.Controls.Add(this.txtTelefono);
            this.panelCargaEdicion.Controls.Add(this.label5);
            this.panelCargaEdicion.Controls.Add(this.cboProvincia);
            this.panelCargaEdicion.Controls.Add(this.label4);
            this.panelCargaEdicion.Controls.Add(this.btnCancelar);
            this.panelCargaEdicion.Controls.Add(this.txtLocalidad);
            this.panelCargaEdicion.Controls.Add(this.label2);
            this.panelCargaEdicion.Controls.Add(this.label40);
            this.panelCargaEdicion.Controls.Add(this.label41);
            this.panelCargaEdicion.Controls.Add(this.label3);
            this.panelCargaEdicion.Controls.Add(this.txtCUIT);
            this.panelCargaEdicion.Controls.Add(this.cboCondIVA);
            this.panelCargaEdicion.Controls.Add(this.txtRSocial);
            this.panelCargaEdicion.Controls.Add(this.label25);
            this.panelCargaEdicion.Controls.Add(this.label22);
            this.panelCargaEdicion.Controls.Add(this.label21);
            this.panelCargaEdicion.Controls.Add(this.label8);
            this.panelCargaEdicion.Controls.Add(this.label7);
            this.panelCargaEdicion.Controls.Add(this.txtCP);
            this.panelCargaEdicion.Controls.Add(this.txtDepto);
            this.panelCargaEdicion.Controls.Add(this.txtPiso);
            this.panelCargaEdicion.Controls.Add(this.txtAltura);
            this.panelCargaEdicion.Controls.Add(this.txtCalle);
            this.panelCargaEdicion.Controls.Add(this.panel4);
            this.panelCargaEdicion.Location = new System.Drawing.Point(78, 106);
            this.panelCargaEdicion.Name = "panelCargaEdicion";
            this.panelCargaEdicion.Size = new System.Drawing.Size(639, 402);
            this.panelCargaEdicion.TabIndex = 331;
            this.panelCargaEdicion.Visible = false;
            this.panelCargaEdicion.Paint += new System.Windows.Forms.PaintEventHandler(this.panelCargaEdicion_Paint);
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
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Image = global::CapaPresentacion.Properties.Resources.Save_32;
            this.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGuardar.Location = new System.Drawing.Point(400, 347);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(110, 35);
            this.btnGuardar.TabIndex = 10;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // txtTelefono
            // 
            this.txtTelefono.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtTelefono.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTelefono.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTelefono.FocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.txtTelefono.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtTelefono.ForeColor = System.Drawing.Color.DimGray;
            this.txtTelefono.Location = new System.Drawing.Point(87, 318);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Numerico = false;
            this.txtTelefono.Size = new System.Drawing.Size(255, 29);
            this.txtTelefono.TabIndex = 9;
            this.txtTelefono.Tag = "txtPanel";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(8, 320);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 21);
            this.label5.TabIndex = 339;
            this.label5.Text = "Teléfono:";
            // 
            // cboProvincia
            // 
            this.cboProvincia.BorderColor = System.Drawing.Color.Gainsboro;
            this.cboProvincia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProvincia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboProvincia.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cboProvincia.FormattingEnabled = true;
            this.cboProvincia.Items.AddRange(new object[] {
            "DNI",
            "CUIT",
            "CUIL"});
            this.cboProvincia.Location = new System.Drawing.Point(87, 202);
            this.cboProvincia.Name = "cboProvincia";
            this.cboProvincia.Size = new System.Drawing.Size(193, 29);
            this.cboProvincia.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(4, 205);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 21);
            this.label4.TabIndex = 337;
            this.label4.Text = "Provincia:";
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
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Image = global::CapaPresentacion.Properties.Resources.Command_Redo_32;
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.Location = new System.Drawing.Point(516, 347);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(110, 35);
            this.btnCancelar.TabIndex = 326;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // txtLocalidad
            // 
            this.txtLocalidad.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtLocalidad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLocalidad.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtLocalidad.FocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.txtLocalidad.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtLocalidad.ForeColor = System.Drawing.Color.DimGray;
            this.txtLocalidad.Location = new System.Drawing.Point(371, 203);
            this.txtLocalidad.Name = "txtLocalidad";
            this.txtLocalidad.Numerico = false;
            this.txtLocalidad.Size = new System.Drawing.Size(257, 29);
            this.txtLocalidad.TabIndex = 4;
            this.txtLocalidad.Tag = "txtPanel";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(286, 205);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 21);
            this.label2.TabIndex = 335;
            this.label2.Text = "Localidad:";
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label40.ForeColor = System.Drawing.Color.Black;
            this.label40.Location = new System.Drawing.Point(35, 163);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(46, 21);
            this.label40.TabIndex = 334;
            this.label40.Text = "CUIT:";
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label41.ForeColor = System.Drawing.Color.Black;
            this.label41.Location = new System.Drawing.Point(8, 128);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(131, 21);
            this.label41.TabIndex = 333;
            this.label41.Text = "Condicion de IVA:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(10, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 21);
            this.label3.TabIndex = 332;
            this.label3.Text = "R. Social:";
            // 
            // txtCUIT
            // 
            this.txtCUIT.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtCUIT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCUIT.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCUIT.FocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.txtCUIT.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtCUIT.ForeColor = System.Drawing.Color.DimGray;
            this.txtCUIT.Location = new System.Drawing.Point(87, 163);
            this.txtCUIT.Name = "txtCUIT";
            this.txtCUIT.Numerico = true;
            this.txtCUIT.Size = new System.Drawing.Size(161, 29);
            this.txtCUIT.TabIndex = 2;
            this.txtCUIT.Tag = "txtPanel";
            this.txtCUIT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cboCondIVA
            // 
            this.cboCondIVA.BorderColor = System.Drawing.Color.Gainsboro;
            this.cboCondIVA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCondIVA.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboCondIVA.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cboCondIVA.FormattingEnabled = true;
            this.cboCondIVA.Items.AddRange(new object[] {
            "DNI",
            "CUIT",
            "CUIL"});
            this.cboCondIVA.Location = new System.Drawing.Point(147, 128);
            this.cboCondIVA.Name = "cboCondIVA";
            this.cboCondIVA.Size = new System.Drawing.Size(262, 29);
            this.cboCondIVA.TabIndex = 1;
            // 
            // txtRSocial
            // 
            this.txtRSocial.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtRSocial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRSocial.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtRSocial.FocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.txtRSocial.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtRSocial.ForeColor = System.Drawing.Color.DimGray;
            this.txtRSocial.Location = new System.Drawing.Point(87, 87);
            this.txtRSocial.Name = "txtRSocial";
            this.txtRSocial.Numerico = false;
            this.txtRSocial.Size = new System.Drawing.Size(541, 29);
            this.txtRSocial.TabIndex = 0;
            this.txtRSocial.Tag = "txtPanel";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label25.ForeColor = System.Drawing.Color.Black;
            this.label25.Location = new System.Drawing.Point(415, 283);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(109, 21);
            this.label25.TabIndex = 331;
            this.label25.Text = "Código postal:";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label22.ForeColor = System.Drawing.Color.Black;
            this.label22.Location = new System.Drawing.Point(287, 283);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(55, 21);
            this.label22.TabIndex = 330;
            this.label22.Text = "Depto:";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label21.ForeColor = System.Drawing.Color.Black;
            this.label21.Location = new System.Drawing.Point(163, 283);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(42, 21);
            this.label21.TabIndex = 329;
            this.label21.Text = "Piso:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(26, 283);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(55, 21);
            this.label8.TabIndex = 328;
            this.label8.Text = "Altura:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(34, 245);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 21);
            this.label7.TabIndex = 327;
            this.label7.Text = "Calle:";
            // 
            // txtCP
            // 
            this.txtCP.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtCP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCP.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCP.FocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.txtCP.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtCP.ForeColor = System.Drawing.Color.DimGray;
            this.txtCP.Location = new System.Drawing.Point(530, 281);
            this.txtCP.Name = "txtCP";
            this.txtCP.Numerico = true;
            this.txtCP.Size = new System.Drawing.Size(98, 29);
            this.txtCP.TabIndex = 326;
            this.txtCP.Tag = "txtPanel";
            this.txtCP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtDepto
            // 
            this.txtDepto.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtDepto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDepto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDepto.FocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.txtDepto.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtDepto.ForeColor = System.Drawing.Color.DimGray;
            this.txtDepto.Location = new System.Drawing.Point(348, 281);
            this.txtDepto.Name = "txtDepto";
            this.txtDepto.Numerico = false;
            this.txtDepto.Size = new System.Drawing.Size(61, 29);
            this.txtDepto.TabIndex = 8;
            this.txtDepto.Tag = "txtPanel";
            this.txtDepto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtPiso
            // 
            this.txtPiso.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtPiso.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPiso.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPiso.FocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.txtPiso.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtPiso.ForeColor = System.Drawing.Color.DimGray;
            this.txtPiso.Location = new System.Drawing.Point(211, 281);
            this.txtPiso.Name = "txtPiso";
            this.txtPiso.Numerico = false;
            this.txtPiso.Size = new System.Drawing.Size(61, 29);
            this.txtPiso.TabIndex = 7;
            this.txtPiso.Tag = "txtPanel";
            this.txtPiso.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtAltura
            // 
            this.txtAltura.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtAltura.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAltura.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAltura.FocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.txtAltura.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtAltura.ForeColor = System.Drawing.Color.DimGray;
            this.txtAltura.Location = new System.Drawing.Point(87, 281);
            this.txtAltura.Name = "txtAltura";
            this.txtAltura.Numerico = true;
            this.txtAltura.Size = new System.Drawing.Size(63, 29);
            this.txtAltura.TabIndex = 6;
            this.txtAltura.Tag = "txtPanel";
            this.txtAltura.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtCalle
            // 
            this.txtCalle.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtCalle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCalle.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCalle.FocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.txtCalle.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtCalle.ForeColor = System.Drawing.Color.DimGray;
            this.txtCalle.Location = new System.Drawing.Point(87, 243);
            this.txtCalle.Name = "txtCalle";
            this.txtCalle.Numerico = false;
            this.txtCalle.Size = new System.Drawing.Size(541, 29);
            this.txtCalle.TabIndex = 5;
            this.txtCalle.Tag = "txtPanel";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.panel4.Controls.Add(this.pictureBox1);
            this.panel4.Controls.Add(this.lblTituloPanel);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(637, 72);
            this.panel4.TabIndex = 318;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = global::CapaPresentacion.Properties.Resources.Left_Arrow_32;
            this.pictureBox1.Location = new System.Drawing.Point(14, 20);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 32;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // lblTituloPanel
            // 
            this.lblTituloPanel.Font = new System.Drawing.Font("Segoe UI Light", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloPanel.ForeColor = System.Drawing.Color.White;
            this.lblTituloPanel.Location = new System.Drawing.Point(52, 25);
            this.lblTituloPanel.Name = "lblTituloPanel";
            this.lblTituloPanel.Size = new System.Drawing.Size(338, 23);
            this.lblTituloPanel.TabIndex = 31;
            this.lblTituloPanel.Text = "Nueva locación fiscal";
            // 
            // pgCircular
            // 
            this.pgCircular.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pgCircular.Location = new System.Drawing.Point(1053, 532);
            this.pgCircular.Name = "pgCircular";
            this.pgCircular.Percentage = 0F;
            this.pgCircular.Rotation = CapaPresentacion.Controles.RotationType.CounterClockwise;
            this.pgCircular.Size = new System.Drawing.Size(33, 33);
            this.pgCircular.TabIndex = 330;
            // 
            // btnEliminar
            // 
            this.btnEliminar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEliminar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnEliminar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnEliminar.FlatAppearance.BorderSize = 0;
            this.btnEliminar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnEliminar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.ForeColor = System.Drawing.Color.White;
            this.btnEliminar.Image = global::CapaPresentacion.Properties.Resources.Data_Delete_32;
            this.btnEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEliminar.Location = new System.Drawing.Point(976, 106);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(110, 35);
            this.btnEliminar.TabIndex = 324;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnEditar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnEditar.FlatAppearance.BorderSize = 0;
            this.btnEditar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnEditar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnEditar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditar.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditar.ForeColor = System.Drawing.Color.White;
            this.btnEditar.Image = global::CapaPresentacion.Properties.Resources.Data_Edit_32__1_;
            this.btnEditar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEditar.Location = new System.Drawing.Point(860, 106);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(110, 35);
            this.btnEditar.TabIndex = 323;
            this.btnEditar.Text = "Editar";
            this.btnEditar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEditar.UseVisualStyleBackColor = false;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
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
            this.btnNuevo.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevo.ForeColor = System.Drawing.Color.White;
            this.btnNuevo.Image = global::CapaPresentacion.Properties.Resources.Data_Add_32;
            this.btnNuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNuevo.Location = new System.Drawing.Point(743, 106);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(110, 35);
            this.btnNuevo.TabIndex = 322;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNuevo.UseVisualStyleBackColor = false;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnActualizar
            // 
            this.btnActualizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnActualizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnActualizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnActualizar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnActualizar.FlatAppearance.BorderSize = 0;
            this.btnActualizar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnActualizar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnActualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActualizar.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActualizar.ForeColor = System.Drawing.Color.White;
            this.btnActualizar.Image = global::CapaPresentacion.Properties.Resources.Command_Refresh_32;
            this.btnActualizar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnActualizar.Location = new System.Drawing.Point(627, 106);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(110, 35);
            this.btnActualizar.TabIndex = 321;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnActualizar.UseVisualStyleBackColor = false;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // dgvLocacionesFiscales
            // 
            this.dgvLocacionesFiscales.AllowUserToAddRows = false;
            this.dgvLocacionesFiscales.AllowUserToDeleteRows = false;
            this.dgvLocacionesFiscales.AllowUserToOrderColumns = true;
            this.dgvLocacionesFiscales.AllowUserToResizeColumns = false;
            this.dgvLocacionesFiscales.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvLocacionesFiscales.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLocacionesFiscales.BackgroundColor = System.Drawing.Color.White;
            this.dgvLocacionesFiscales.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvLocacionesFiscales.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.LightSlateGray;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLocacionesFiscales.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvLocacionesFiscales.ColumnHeadersHeight = 40;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLocacionesFiscales.DefaultCellStyle = dataGridViewCellStyle10;
            this.dgvLocacionesFiscales.EnableHeadersVisualStyles = false;
            this.dgvLocacionesFiscales.GridColor = System.Drawing.Color.WhiteSmoke;
            this.dgvLocacionesFiscales.Location = new System.Drawing.Point(12, 179);
            this.dgvLocacionesFiscales.MultiSelect = false;
            this.dgvLocacionesFiscales.Name = "dgvLocacionesFiscales";
            this.dgvLocacionesFiscales.ReadOnly = true;
            this.dgvLocacionesFiscales.RowHeadersVisible = false;
            this.dgvLocacionesFiscales.RowHeadersWidth = 50;
            this.dgvLocacionesFiscales.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvLocacionesFiscales.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLocacionesFiscales.Size = new System.Drawing.Size(1074, 150);
            this.dgvLocacionesFiscales.TabIndex = 318;
            this.dgvLocacionesFiscales.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLocacionesFiscales_CellClick);
            // 
            // dgvLocacionesServicios
            // 
            this.dgvLocacionesServicios.AllowUserToAddRows = false;
            this.dgvLocacionesServicios.AllowUserToDeleteRows = false;
            this.dgvLocacionesServicios.AllowUserToOrderColumns = true;
            this.dgvLocacionesServicios.AllowUserToResizeColumns = false;
            this.dgvLocacionesServicios.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvLocacionesServicios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLocacionesServicios.BackgroundColor = System.Drawing.Color.White;
            this.dgvLocacionesServicios.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvLocacionesServicios.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.LightSlateGray;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLocacionesServicios.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.dgvLocacionesServicios.ColumnHeadersHeight = 40;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLocacionesServicios.DefaultCellStyle = dataGridViewCellStyle12;
            this.dgvLocacionesServicios.EnableHeadersVisualStyles = false;
            this.dgvLocacionesServicios.GridColor = System.Drawing.Color.WhiteSmoke;
            this.dgvLocacionesServicios.Location = new System.Drawing.Point(12, 381);
            this.dgvLocacionesServicios.MultiSelect = false;
            this.dgvLocacionesServicios.Name = "dgvLocacionesServicios";
            this.dgvLocacionesServicios.ReadOnly = true;
            this.dgvLocacionesServicios.RowHeadersVisible = false;
            this.dgvLocacionesServicios.RowHeadersWidth = 50;
            this.dgvLocacionesServicios.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvLocacionesServicios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLocacionesServicios.Size = new System.Drawing.Size(1074, 149);
            this.dgvLocacionesServicios.TabIndex = 332;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(7, 350);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(238, 21);
            this.label1.TabIndex = 333;
            this.label1.Text = "Locaciones de servicio asociadas:";
            // 
            // btnAgregarLocacionServicio
            // 
            this.btnAgregarLocacionServicio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAgregarLocacionServicio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnAgregarLocacionServicio.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregarLocacionServicio.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnAgregarLocacionServicio.FlatAppearance.BorderSize = 0;
            this.btnAgregarLocacionServicio.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnAgregarLocacionServicio.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnAgregarLocacionServicio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarLocacionServicio.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarLocacionServicio.ForeColor = System.Drawing.Color.White;
            this.btnAgregarLocacionServicio.Image = global::CapaPresentacion.Properties.Resources.Data_Add_32;
            this.btnAgregarLocacionServicio.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAgregarLocacionServicio.Location = new System.Drawing.Point(976, 340);
            this.btnAgregarLocacionServicio.Name = "btnAgregarLocacionServicio";
            this.btnAgregarLocacionServicio.Size = new System.Drawing.Size(110, 35);
            this.btnAgregarLocacionServicio.TabIndex = 334;
            this.btnAgregarLocacionServicio.Text = "Agregar";
            this.btnAgregarLocacionServicio.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgregarLocacionServicio.UseVisualStyleBackColor = false;
            this.btnAgregarLocacionServicio.Click += new System.EventHandler(this.btnAgregarLocacionServicio_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(254, 165);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(150, 21);
            this.label6.TabIndex = 341;
            this.label6.Text = "Impuesto Provincial:";
            // 
            // numProvincial
            // 
            this.numProvincial.DecimalPlaces = 2;
            this.numProvincial.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.numProvincial.Location = new System.Drawing.Point(410, 161);
            this.numProvincial.Name = "numProvincial";
            this.numProvincial.Size = new System.Drawing.Size(120, 29);
            this.numProvincial.TabIndex = 342;
            this.numProvincial.Tag = "txtPanel";
            // 
            // ABMlocacionesFiscales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(250)))), ((int)(((byte)(251)))));
            this.ClientSize = new System.Drawing.Size(1098, 566);
            this.Controls.Add(this.panelCargaEdicion);
            this.Controls.Add(this.pgCircular);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.dgvLocacionesFiscales);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.dgvLocacionesServicios);
            this.Controls.Add(this.btnAgregarLocacionServicio);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "ABMlocacionesFiscales";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ABMlocacionesFiscales";
            this.Load += new System.EventHandler(this.ABMlocacionesFiscales_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ABMlocacionesFiscales_KeyDown);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgReturn)).EndInit();
            this.panelCargaEdicion.ResumeLayout(false);
            this.panelCargaEdicion.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocacionesFiscales)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocacionesServicios)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numProvincial)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox imgReturn;
        private System.Windows.Forms.Label lblTituloHeader;
        private Controles.dgv dgvLocacionesFiscales;
        private System.Windows.Forms.Label lblTitulo;
        private Controles.boton btnCancelar;
        private Controles.boton btnEliminar;
        private Controles.boton btnEditar;
        private Controles.boton btnNuevo;
        private Controles.boton btnActualizar;
        private System.Windows.Forms.Panel panel1;
        private Controles.progress pgCircular;
        private System.Windows.Forms.Panel panelCargaEdicion;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblTituloPanel;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.Label label3;
        private textboxAdv txtCUIT;
        private Controles.combo cboCondIVA;
        private textboxAdv txtRSocial;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private textboxAdv txtCP;
        private textboxAdv txtDepto;
        private textboxAdv txtPiso;
        private textboxAdv txtAltura;
        private textboxAdv txtCalle;
        private textboxAdv txtTelefono;
        private System.Windows.Forms.Label label5;
        private Controles.combo cboProvincia;
        private System.Windows.Forms.Label label4;
        private textboxAdv txtLocalidad;
        private System.Windows.Forms.Label label2;
        private Controles.boton btnGuardar;
        private Controles.dgv dgvLocacionesServicios;
        private System.Windows.Forms.Label label1;
        private Controles.boton btnAgregarLocacionServicio;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numProvincial;
    }
}