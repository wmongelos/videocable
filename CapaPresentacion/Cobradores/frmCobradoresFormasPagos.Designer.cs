namespace CapaPresentacion
{
    partial class frmCobradoresFormasPagos
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
            this.pnPagos = new System.Windows.Forms.Panel();
            this.dtpFechaAcre = new System.Windows.Forms.DateTimePicker();
            this.dtpFechaCom = new System.Windows.Forms.DateTimePicker();
            this.spImporte = new CapaPresentacion.Controles.spinner(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTituloPanel = new System.Windows.Forms.Label();
            this.imgCancelaPago = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtcliente = new CapaPresentacion.textboxAdv();
            this.label2 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtcuit = new CapaPresentacion.textboxAdv();
            this.btnConfirma = new CapaPresentacion.Controles.boton();
            this.label4 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtsucursal = new CapaPresentacion.textboxAdv();
            this.label8 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtbanco = new CapaPresentacion.textboxAdv();
            this.label1 = new System.Windows.Forms.Label();
            this.txtcuenta = new CapaPresentacion.textboxAdv();
            this.txtnumero = new CapaPresentacion.textboxAdv();
            this.btnQuitar = new CapaPresentacion.Controles.boton();
            this.btnAgregar = new CapaPresentacion.Controles.boton();
            this.btnBusca = new CapaPresentacion.Controles.boton();
            this.btnAceptar = new CapaPresentacion.Controles.boton();
            this.dgvDetallesPagos = new CapaPresentacion.Controles.dgv(this.components);
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgReturn)).BeginInit();
            this.pnPagos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spImporte)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgCancelaPago)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetallesPagos)).BeginInit();
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
            this.panel3.Size = new System.Drawing.Size(661, 75);
            this.panel3.TabIndex = 90;
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
            this.lblTituloHeader.Size = new System.Drawing.Size(550, 23);
            this.lblTituloHeader.TabIndex = 31;
            this.lblTituloHeader.Text = "Pago de Cobradores - Forma de pago";
            // 
            // pnPagos
            // 
            this.pnPagos.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnPagos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnPagos.Controls.Add(this.dtpFechaAcre);
            this.pnPagos.Controls.Add(this.dtpFechaCom);
            this.pnPagos.Controls.Add(this.spImporte);
            this.pnPagos.Controls.Add(this.panel1);
            this.pnPagos.Controls.Add(this.label6);
            this.pnPagos.Controls.Add(this.txtcliente);
            this.pnPagos.Controls.Add(this.label2);
            this.pnPagos.Controls.Add(this.label10);
            this.pnPagos.Controls.Add(this.txtcuit);
            this.pnPagos.Controls.Add(this.btnConfirma);
            this.pnPagos.Controls.Add(this.label4);
            this.pnPagos.Controls.Add(this.label9);
            this.pnPagos.Controls.Add(this.label5);
            this.pnPagos.Controls.Add(this.txtsucursal);
            this.pnPagos.Controls.Add(this.label8);
            this.pnPagos.Controls.Add(this.label3);
            this.pnPagos.Controls.Add(this.txtbanco);
            this.pnPagos.Controls.Add(this.label1);
            this.pnPagos.Controls.Add(this.txtcuenta);
            this.pnPagos.Controls.Add(this.txtnumero);
            this.pnPagos.Location = new System.Drawing.Point(95, 109);
            this.pnPagos.Name = "pnPagos";
            this.pnPagos.Size = new System.Drawing.Size(535, 359);
            this.pnPagos.TabIndex = 333;
            this.pnPagos.Visible = false;
            // 
            // dtpFechaAcre
            // 
            this.dtpFechaAcre.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.dtpFechaAcre.Location = new System.Drawing.Point(347, 215);
            this.dtpFechaAcre.Name = "dtpFechaAcre";
            this.dtpFechaAcre.Size = new System.Drawing.Size(171, 29);
            this.dtpFechaAcre.TabIndex = 178;
            // 
            // dtpFechaCom
            // 
            this.dtpFechaCom.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.dtpFechaCom.Location = new System.Drawing.Point(95, 215);
            this.dtpFechaCom.Name = "dtpFechaCom";
            this.dtpFechaCom.Size = new System.Drawing.Size(164, 29);
            this.dtpFechaCom.TabIndex = 177;
            // 
            // spImporte
            // 
            this.spImporte.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.spImporte.BorderColor = System.Drawing.Color.Empty;
            this.spImporte.DecimalPlaces = 2;
            this.spImporte.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.spImporte.ForeColor = System.Drawing.Color.Black;
            this.spImporte.Location = new System.Drawing.Point(96, 74);
            this.spImporte.Maximum = new decimal(new int[] {
            -1981284353,
            -1966660860,
            0,
            131072});
            this.spImporte.Name = "spImporte";
            this.spImporte.Size = new System.Drawing.Size(423, 29);
            this.spImporte.TabIndex = 124;
            this.spImporte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.panel1.Controls.Add(this.lblTituloPanel);
            this.panel1.Controls.Add(this.imgCancelaPago);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(535, 58);
            this.panel1.TabIndex = 176;
            // 
            // lblTituloPanel
            // 
            this.lblTituloPanel.AutoSize = true;
            this.lblTituloPanel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloPanel.ForeColor = System.Drawing.Color.Transparent;
            this.lblTituloPanel.Location = new System.Drawing.Point(49, 20);
            this.lblTituloPanel.Name = "lblTituloPanel";
            this.lblTituloPanel.Size = new System.Drawing.Size(114, 21);
            this.lblTituloPanel.TabIndex = 173;
            this.lblTituloPanel.Text = "Datos del pago";
            // 
            // imgCancelaPago
            // 
            this.imgCancelaPago.Cursor = System.Windows.Forms.Cursors.Hand;
            this.imgCancelaPago.Image = global::CapaPresentacion.Properties.Resources.Left_Arrow_32;
            this.imgCancelaPago.Location = new System.Drawing.Point(11, 13);
            this.imgCancelaPago.Name = "imgCancelaPago";
            this.imgCancelaPago.Size = new System.Drawing.Size(32, 32);
            this.imgCancelaPago.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgCancelaPago.TabIndex = 123;
            this.imgCancelaPago.TabStop = false;
            this.imgCancelaPago.Click += new System.EventHandler(this.imgCancelaPago_Click);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(296, 111);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 21);
            this.label6.TabIndex = 105;
            this.label6.Text = "Cuit :";
            // 
            // txtcliente
            // 
            this.txtcliente.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtcliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtcliente.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtcliente.FocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtcliente.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtcliente.ForeColor = System.Drawing.Color.Black;
            this.txtcliente.Location = new System.Drawing.Point(95, 109);
            this.txtcliente.Name = "txtcliente";
            this.txtcliente.Numerico = false;
            this.txtcliente.Size = new System.Drawing.Size(164, 29);
            this.txtcliente.TabIndex = 1;
            this.txtcliente.Tag = "\"\"";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(28, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 21);
            this.label2.TabIndex = 100;
            this.label2.Text = "Titular :";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(14, 259);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(75, 21);
            this.label10.TabIndex = 112;
            this.label10.Text = "Numero :";
            // 
            // txtcuit
            // 
            this.txtcuit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtcuit.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtcuit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtcuit.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtcuit.FocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtcuit.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtcuit.ForeColor = System.Drawing.Color.Black;
            this.txtcuit.Location = new System.Drawing.Point(347, 109);
            this.txtcuit.Name = "txtcuit";
            this.txtcuit.Numerico = false;
            this.txtcuit.Size = new System.Drawing.Size(171, 29);
            this.txtcuit.TabIndex = 2;
            this.txtcuit.Tag = "\"\"";
            // 
            // btnConfirma
            // 
            this.btnConfirma.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConfirma.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnConfirma.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConfirma.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnConfirma.FlatAppearance.BorderSize = 0;
            this.btnConfirma.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnConfirma.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnConfirma.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirma.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnConfirma.ForeColor = System.Drawing.Color.White;
            this.btnConfirma.Image = global::CapaPresentacion.Properties.Resources.Data_Add_32;
            this.btnConfirma.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnConfirma.Location = new System.Drawing.Point(415, 305);
            this.btnConfirma.Name = "btnConfirma";
            this.btnConfirma.Size = new System.Drawing.Size(103, 38);
            this.btnConfirma.TabIndex = 9;
            this.btnConfirma.Text = "Agregar";
            this.btnConfirma.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConfirma.UseVisualStyleBackColor = false;
            this.btnConfirma.Click += new System.EventHandler(this.btnConfirma_Click);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(265, 145);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 21);
            this.label4.TabIndex = 102;
            this.label4.Text = "Sucursal :";
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(284, 219);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(57, 21);
            this.label9.TabIndex = 111;
            this.label9.Text = "Acred :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(23, 182);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 21);
            this.label5.TabIndex = 103;
            this.label5.Text = "Cuenta :";
            // 
            // txtsucursal
            // 
            this.txtsucursal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtsucursal.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtsucursal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtsucursal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtsucursal.FocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtsucursal.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtsucursal.ForeColor = System.Drawing.Color.Black;
            this.txtsucursal.Location = new System.Drawing.Point(347, 144);
            this.txtsucursal.Name = "txtsucursal";
            this.txtsucursal.Numerico = false;
            this.txtsucursal.Size = new System.Drawing.Size(171, 29);
            this.txtsucursal.TabIndex = 4;
            this.txtsucursal.Tag = "\"\"";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(21, 219);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(68, 21);
            this.label8.TabIndex = 110;
            this.label8.Text = "Compr. :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(30, 145);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 21);
            this.label3.TabIndex = 101;
            this.label3.Text = "Banco :";
            // 
            // txtbanco
            // 
            this.txtbanco.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtbanco.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtbanco.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtbanco.FocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtbanco.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtbanco.ForeColor = System.Drawing.Color.Black;
            this.txtbanco.Location = new System.Drawing.Point(95, 143);
            this.txtbanco.Name = "txtbanco";
            this.txtbanco.Numerico = false;
            this.txtbanco.Size = new System.Drawing.Size(164, 29);
            this.txtbanco.TabIndex = 3;
            this.txtbanco.Tag = "\"\"";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(8, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 21);
            this.label1.TabIndex = 93;
            this.label1.Text = "Importe $:";
            // 
            // txtcuenta
            // 
            this.txtcuenta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtcuenta.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtcuenta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtcuenta.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtcuenta.FocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtcuenta.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtcuenta.ForeColor = System.Drawing.Color.Black;
            this.txtcuenta.Location = new System.Drawing.Point(95, 180);
            this.txtcuenta.Name = "txtcuenta";
            this.txtcuenta.Numerico = false;
            this.txtcuenta.Size = new System.Drawing.Size(423, 29);
            this.txtcuenta.TabIndex = 5;
            this.txtcuenta.Tag = "\"\"";
            // 
            // txtnumero
            // 
            this.txtnumero.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtnumero.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtnumero.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtnumero.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtnumero.FocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtnumero.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtnumero.ForeColor = System.Drawing.Color.Black;
            this.txtnumero.Location = new System.Drawing.Point(95, 257);
            this.txtnumero.Name = "txtnumero";
            this.txtnumero.Numerico = true;
            this.txtnumero.Size = new System.Drawing.Size(423, 29);
            this.txtnumero.TabIndex = 8;
            this.txtnumero.Tag = "\"\"";
            this.txtnumero.Text = "0";
            this.txtnumero.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnQuitar
            // 
            this.btnQuitar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnQuitar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnQuitar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(84)))), ((int)(((byte)(101)))));
            this.btnQuitar.FlatAppearance.BorderSize = 0;
            this.btnQuitar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(84)))), ((int)(((byte)(101)))));
            this.btnQuitar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            this.btnQuitar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuitar.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnQuitar.ForeColor = System.Drawing.Color.White;
            this.btnQuitar.Image = global::CapaPresentacion.Properties.Resources.Data_Delete_32;
            this.btnQuitar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnQuitar.Location = new System.Drawing.Point(8, 173);
            this.btnQuitar.Name = "btnQuitar";
            this.btnQuitar.Size = new System.Drawing.Size(148, 35);
            this.btnQuitar.TabIndex = 332;
            this.btnQuitar.Text = "Eliminar pago";
            this.btnQuitar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQuitar.UseVisualStyleBackColor = false;
            this.btnQuitar.Click += new System.EventHandler(this.btnQuitar_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnAgregar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(84)))), ((int)(((byte)(101)))));
            this.btnAgregar.FlatAppearance.BorderSize = 0;
            this.btnAgregar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(84)))), ((int)(((byte)(101)))));
            this.btnAgregar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            this.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregar.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnAgregar.ForeColor = System.Drawing.Color.White;
            this.btnAgregar.Image = global::CapaPresentacion.Properties.Resources.Data_Add_32;
            this.btnAgregar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAgregar.Location = new System.Drawing.Point(8, 91);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(148, 35);
            this.btnAgregar.TabIndex = 331;
            this.btnAgregar.Text = "Agregar pago";
            this.btnAgregar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgregar.UseVisualStyleBackColor = false;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnBusca
            // 
            this.btnBusca.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnBusca.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBusca.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(84)))), ((int)(((byte)(101)))));
            this.btnBusca.FlatAppearance.BorderSize = 0;
            this.btnBusca.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(84)))), ((int)(((byte)(101)))));
            this.btnBusca.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            this.btnBusca.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBusca.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnBusca.ForeColor = System.Drawing.Color.White;
            this.btnBusca.Image = global::CapaPresentacion.Properties.Resources.Business_Man_Search_32;
            this.btnBusca.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBusca.Location = new System.Drawing.Point(8, 132);
            this.btnBusca.Name = "btnBusca";
            this.btnBusca.Size = new System.Drawing.Size(148, 35);
            this.btnBusca.TabIndex = 330;
            this.btnBusca.Text = "Buscar usuario";
            this.btnBusca.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBusca.UseVisualStyleBackColor = false;
            this.btnBusca.Click += new System.EventHandler(this.btnBusca_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnAceptar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAceptar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(84)))), ((int)(((byte)(101)))));
            this.btnAceptar.FlatAppearance.BorderSize = 0;
            this.btnAceptar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(84)))), ((int)(((byte)(101)))));
            this.btnAceptar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            this.btnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAceptar.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnAceptar.ForeColor = System.Drawing.Color.White;
            this.btnAceptar.Image = global::CapaPresentacion.Properties.Resources.Save_32;
            this.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAceptar.Location = new System.Drawing.Point(500, 91);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(148, 35);
            this.btnAceptar.TabIndex = 329;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAceptar.UseVisualStyleBackColor = false;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // dgvDetallesPagos
            // 
            this.dgvDetallesPagos.AllowUserToAddRows = false;
            this.dgvDetallesPagos.AllowUserToDeleteRows = false;
            this.dgvDetallesPagos.AllowUserToOrderColumns = true;
            this.dgvDetallesPagos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDetallesPagos.BackgroundColor = System.Drawing.Color.White;
            this.dgvDetallesPagos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDetallesPagos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSlateGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDetallesPagos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDetallesPagos.ColumnHeadersHeight = 40;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDetallesPagos.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDetallesPagos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.dgvDetallesPagos.EnableHeadersVisualStyles = false;
            this.dgvDetallesPagos.GridColor = System.Drawing.Color.WhiteSmoke;
            this.dgvDetallesPagos.Location = new System.Drawing.Point(162, 91);
            this.dgvDetallesPagos.MultiSelect = false;
            this.dgvDetallesPagos.Name = "dgvDetallesPagos";
            this.dgvDetallesPagos.ReadOnly = true;
            this.dgvDetallesPagos.RowHeadersVisible = false;
            this.dgvDetallesPagos.RowHeadersWidth = 50;
            this.dgvDetallesPagos.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvDetallesPagos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvDetallesPagos.Size = new System.Drawing.Size(331, 305);
            this.dgvDetallesPagos.TabIndex = 328;
            this.dgvDetallesPagos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetallesPagos_CellClick);
            this.dgvDetallesPagos.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetallesPagos_CellEndEdit);
            this.dgvDetallesPagos.CellValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetallesPagos_CellValidated);
            this.dgvDetallesPagos.SelectionChanged += new System.EventHandler(this.dgvDetallesPagos_SelectionChanged);
            // 
            // frmCobradoresFormasPagos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(661, 480);
            this.Controls.Add(this.pnPagos);
            this.Controls.Add(this.btnQuitar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.btnBusca);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.dgvDetallesPagos);
            this.Controls.Add(this.panel3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "frmCobradoresFormasPagos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmCobradoresFormasPagos";
            this.Load += new System.EventHandler(this.frmCobradoresFormasPagos_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmCobradoresFormasPagos_KeyDown);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgReturn)).EndInit();
            this.pnPagos.ResumeLayout(false);
            this.pnPagos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spImporte)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgCancelaPago)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetallesPagos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox imgReturn;
        private System.Windows.Forms.Label lblTituloHeader;
        private Controles.dgv dgvDetallesPagos;
        private Controles.boton btnAceptar;
        private Controles.boton btnQuitar;
        private Controles.boton btnAgregar;
        private Controles.boton btnBusca;
        private System.Windows.Forms.Panel pnPagos;
        private Controles.spinner spImporte;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblTituloPanel;
        private System.Windows.Forms.PictureBox imgCancelaPago;
        private System.Windows.Forms.Label label6;
        private textboxAdv txtcliente;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label10;
        private textboxAdv txtcuit;
        private Controles.boton btnConfirma;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label5;
        private textboxAdv txtsucursal;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label3;
        private textboxAdv txtbanco;
        private System.Windows.Forms.Label label1;
        private textboxAdv txtcuenta;
        private textboxAdv txtnumero;
        private System.Windows.Forms.DateTimePicker dtpFechaAcre;
        private System.Windows.Forms.DateTimePicker dtpFechaCom;
    }
}