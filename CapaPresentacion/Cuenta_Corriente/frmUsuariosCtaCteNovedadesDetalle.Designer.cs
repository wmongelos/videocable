namespace CapaPresentacion.Cuenta_Corriente
{
    partial class frmUsuariosCtaCteNovedadesDetalle
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.imgReturn = new System.Windows.Forms.PictureBox();
            this.pnLinea1 = new System.Windows.Forms.Panel();
            this.lblocalidad = new System.Windows.Forms.Label();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.lbHasta = new System.Windows.Forms.Label();
            this.lbDesde = new System.Windows.Forms.Label();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.chkFinaliza = new System.Windows.Forms.CheckBox();
            this.pnlComun = new System.Windows.Forms.Panel();
            this.lblDirigido = new System.Windows.Forms.Label();
            this.pnlServicios = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblSubServicios = new System.Windows.Forms.Label();
            this.lblServicios = new System.Windows.Forms.Label();
            this.lblLocacion = new System.Windows.Forms.Label();
            this.pnlDescuentos = new System.Windows.Forms.Panel();
            this.lvlInfo = new System.Windows.Forms.Label();
            this.lblDtopesos = new System.Windows.Forms.Label();
            this.lblDtoPorc = new System.Windows.Forms.Label();
            this.txtDtoPor = new CapaPresentacion.Controles.spinner(this.components);
            this.txtDtoPes = new CapaPresentacion.textboxAdv();
            this.cboTipoFacturacion = new CapaPresentacion.Controles.combo(this.components);
            this.cboUsuarios = new CapaPresentacion.Controles.combo(this.components);
            this.cboLocacion = new CapaPresentacion.Controles.combo(this.components);
            this.dgvServicios = new CapaPresentacion.Controles.dgv(this.components);
            this.dgvSubservicios = new CapaPresentacion.Controles.dgv(this.components);
            this.cboDirigido = new CapaPresentacion.Controles.combo(this.components);
            this.txtDetalle = new CapaPresentacion.textboxAdv();
            this.btnCancela = new CapaPresentacion.Controles.boton();
            this.btnAplicar = new CapaPresentacion.Controles.boton();
            this.pgCircular = new CapaPresentacion.Controles.progress();
            ((System.ComponentModel.ISupportInitialize)(this.imgReturn)).BeginInit();
            this.pnLinea1.SuspendLayout();
            this.pnlComun.SuspendLayout();
            this.pnlServicios.SuspendLayout();
            this.pnlDescuentos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDtoPor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvServicios)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSubservicios)).BeginInit();
            this.SuspendLayout();
            // 
            // imgReturn
            // 
            this.imgReturn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.imgReturn.Image = global::CapaPresentacion.Properties.Resources.Left_Arrow_32;
            this.imgReturn.Location = new System.Drawing.Point(12, 31);
            this.imgReturn.Name = "imgReturn";
            this.imgReturn.Size = new System.Drawing.Size(32, 32);
            this.imgReturn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgReturn.TabIndex = 75;
            this.imgReturn.TabStop = false;
            this.imgReturn.Click += new System.EventHandler(this.imgReturn_Click);
            // 
            // pnLinea1
            // 
            this.pnLinea1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnLinea1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.pnLinea1.Controls.Add(this.imgReturn);
            this.pnLinea1.Controls.Add(this.lblocalidad);
            this.pnLinea1.Controls.Add(this.lblUsuario);
            this.pnLinea1.Controls.Add(this.pgCircular);
            this.pnLinea1.Location = new System.Drawing.Point(-3, -17);
            this.pnLinea1.Name = "pnLinea1";
            this.pnLinea1.Size = new System.Drawing.Size(1360, 80);
            this.pnLinea1.TabIndex = 45;
            // 
            // lblocalidad
            // 
            this.lblocalidad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblocalidad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblocalidad.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblocalidad.ForeColor = System.Drawing.Color.White;
            this.lblocalidad.Location = new System.Drawing.Point(555, 53);
            this.lblocalidad.Name = "lblocalidad";
            this.lblocalidad.Size = new System.Drawing.Size(369, 19);
            this.lblocalidad.TabIndex = 70;
            this.lblocalidad.Text = "-";
            this.lblocalidad.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblUsuario
            // 
            this.lblUsuario.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUsuario.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuario.ForeColor = System.Drawing.Color.White;
            this.lblUsuario.Location = new System.Drawing.Point(559, 25);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(369, 23);
            this.lblUsuario.TabIndex = 48;
            this.lblUsuario.Text = "-";
            this.lblUsuario.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbHasta
            // 
            this.lbHasta.AutoSize = true;
            this.lbHasta.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbHasta.ForeColor = System.Drawing.Color.Black;
            this.lbHasta.Location = new System.Drawing.Point(82, 77);
            this.lbHasta.Name = "lbHasta";
            this.lbHasta.Size = new System.Drawing.Size(49, 21);
            this.lbHasta.TabIndex = 182;
            this.lbHasta.Text = "Hasta";
            // 
            // lbDesde
            // 
            this.lbDesde.AutoSize = true;
            this.lbDesde.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDesde.ForeColor = System.Drawing.Color.Black;
            this.lbDesde.Location = new System.Drawing.Point(78, 17);
            this.lbDesde.Name = "lbDesde";
            this.lbDesde.Size = new System.Drawing.Size(53, 21);
            this.lbDesde.TabIndex = 179;
            this.lbDesde.Text = "Desde";
            // 
            // dtpHasta
            // 
            this.dtpHasta.Enabled = false;
            this.dtpHasta.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.dtpHasta.Location = new System.Drawing.Point(137, 71);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(383, 29);
            this.dtpHasta.TabIndex = 181;
            this.dtpHasta.ValueChanged += new System.EventHandler(this.dtpHasta_ValueChanged);
            // 
            // dtpDesde
            // 
            this.dtpDesde.Checked = false;
            this.dtpDesde.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.dtpDesde.Location = new System.Drawing.Point(137, 11);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(383, 29);
            this.dtpDesde.TabIndex = 180;
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescripcion.ForeColor = System.Drawing.Color.Black;
            this.lblDescripcion.Location = new System.Drawing.Point(40, 109);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(91, 21);
            this.lblDescripcion.TabIndex = 184;
            this.lblDescripcion.Text = "Descripcion";
            // 
            // chkFinaliza
            // 
            this.chkFinaliza.AutoSize = true;
            this.chkFinaliza.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkFinaliza.Location = new System.Drawing.Point(137, 46);
            this.chkFinaliza.Name = "chkFinaliza";
            this.chkFinaliza.Size = new System.Drawing.Size(130, 19);
            this.chkFinaliza.TabIndex = 185;
            this.chkFinaliza.Text = "Con fecha de fin";
            this.chkFinaliza.UseVisualStyleBackColor = true;
            this.chkFinaliza.CheckedChanged += new System.EventHandler(this.chkFinaliza_CheckedChanged);
            // 
            // pnlComun
            // 
            this.pnlComun.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlComun.Controls.Add(this.cboDirigido);
            this.pnlComun.Controls.Add(this.lblDirigido);
            this.pnlComun.Controls.Add(this.dtpDesde);
            this.pnlComun.Controls.Add(this.txtDetalle);
            this.pnlComun.Controls.Add(this.dtpHasta);
            this.pnlComun.Controls.Add(this.lbDesde);
            this.pnlComun.Controls.Add(this.chkFinaliza);
            this.pnlComun.Controls.Add(this.lblDescripcion);
            this.pnlComun.Controls.Add(this.lbHasta);
            this.pnlComun.Location = new System.Drawing.Point(9, 69);
            this.pnlComun.Name = "pnlComun";
            this.pnlComun.Size = new System.Drawing.Size(912, 187);
            this.pnlComun.TabIndex = 188;
            // 
            // lblDirigido
            // 
            this.lblDirigido.AutoSize = true;
            this.lblDirigido.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDirigido.ForeColor = System.Drawing.Color.Black;
            this.lblDirigido.Location = new System.Drawing.Point(53, 151);
            this.lblDirigido.Name = "lblDirigido";
            this.lblDirigido.Size = new System.Drawing.Size(78, 21);
            this.lblDirigido.TabIndex = 188;
            this.lblDirigido.Text = "Dirigido a";
            // 
            // pnlServicios
            // 
            this.pnlServicios.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlServicios.Controls.Add(this.cboTipoFacturacion);
            this.pnlServicios.Controls.Add(this.cboUsuarios);
            this.pnlServicios.Controls.Add(this.label3);
            this.pnlServicios.Controls.Add(this.label2);
            this.pnlServicios.Controls.Add(this.lblSubServicios);
            this.pnlServicios.Controls.Add(this.lblServicios);
            this.pnlServicios.Controls.Add(this.cboLocacion);
            this.pnlServicios.Controls.Add(this.lblLocacion);
            this.pnlServicios.Controls.Add(this.dgvServicios);
            this.pnlServicios.Controls.Add(this.dgvSubservicios);
            this.pnlServicios.Location = new System.Drawing.Point(9, 262);
            this.pnlServicios.Name = "pnlServicios";
            this.pnlServicios.Size = new System.Drawing.Size(912, 305);
            this.pnlServicios.TabIndex = 189;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(59, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 21);
            this.label3.TabIndex = 193;
            this.label3.Text = "Usuario";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.ForestGreen;
            this.label2.Location = new System.Drawing.Point(515, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 21);
            this.label2.TabIndex = 192;
            this.label2.Text = "Servicios Activos";
            // 
            // lblSubServicios
            // 
            this.lblSubServicios.AutoSize = true;
            this.lblSubServicios.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubServicios.ForeColor = System.Drawing.Color.Black;
            this.lblSubServicios.Location = new System.Drawing.Point(410, 54);
            this.lblSubServicios.Name = "lblSubServicios";
            this.lblSubServicios.Size = new System.Drawing.Size(99, 21);
            this.lblSubServicios.TabIndex = 191;
            this.lblSubServicios.Text = "SubServicios";
            // 
            // lblServicios
            // 
            this.lblServicios.AutoSize = true;
            this.lblServicios.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblServicios.ForeColor = System.Drawing.Color.Black;
            this.lblServicios.Location = new System.Drawing.Point(59, 54);
            this.lblServicios.Name = "lblServicios";
            this.lblServicios.Size = new System.Drawing.Size(72, 21);
            this.lblServicios.TabIndex = 190;
            this.lblServicios.Text = "Servicios";
            // 
            // lblLocacion
            // 
            this.lblLocacion.AutoSize = true;
            this.lblLocacion.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLocacion.ForeColor = System.Drawing.Color.Black;
            this.lblLocacion.Location = new System.Drawing.Point(439, 16);
            this.lblLocacion.Name = "lblLocacion";
            this.lblLocacion.Size = new System.Drawing.Size(71, 21);
            this.lblLocacion.TabIndex = 187;
            this.lblLocacion.Text = "Locacion";
            // 
            // pnlDescuentos
            // 
            this.pnlDescuentos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDescuentos.Controls.Add(this.txtDtoPor);
            this.pnlDescuentos.Controls.Add(this.lvlInfo);
            this.pnlDescuentos.Controls.Add(this.txtDtoPes);
            this.pnlDescuentos.Controls.Add(this.lblDtopesos);
            this.pnlDescuentos.Controls.Add(this.lblDtoPorc);
            this.pnlDescuentos.Location = new System.Drawing.Point(9, 573);
            this.pnlDescuentos.Name = "pnlDescuentos";
            this.pnlDescuentos.Size = new System.Drawing.Size(912, 72);
            this.pnlDescuentos.TabIndex = 190;
            // 
            // lvlInfo
            // 
            this.lvlInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lvlInfo.AutoSize = true;
            this.lvlInfo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lvlInfo.ForeColor = System.Drawing.Color.Black;
            this.lvlInfo.Location = new System.Drawing.Point(579, 41);
            this.lvlInfo.Name = "lvlInfo";
            this.lvlInfo.Size = new System.Drawing.Size(320, 19);
            this.lvlInfo.TabIndex = 194;
            this.lvlInfo.Text = "Importe negativo = descuento, positivo= aumento";
            // 
            // lblDtopesos
            // 
            this.lblDtopesos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDtopesos.AutoSize = true;
            this.lblDtopesos.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDtopesos.ForeColor = System.Drawing.Color.Black;
            this.lblDtopesos.Location = new System.Drawing.Point(738, 12);
            this.lblDtopesos.Name = "lblDtopesos";
            this.lblDtopesos.Size = new System.Drawing.Size(65, 21);
            this.lblDtopesos.TabIndex = 192;
            this.lblDtopesos.Text = "Importe";
            // 
            // lblDtoPorc
            // 
            this.lblDtoPorc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDtoPorc.AutoSize = true;
            this.lblDtoPorc.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDtoPorc.ForeColor = System.Drawing.Color.Black;
            this.lblDtoPorc.Location = new System.Drawing.Point(540, 12);
            this.lblDtoPorc.Name = "lblDtoPorc";
            this.lblDtoPorc.Size = new System.Drawing.Size(82, 21);
            this.lblDtoPorc.TabIndex = 190;
            this.lblDtoPorc.Text = "Porcentaje";
            // 
            // txtDtoPor
            // 
            this.txtDtoPor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtDtoPor.BorderColor = System.Drawing.Color.Empty;
            this.txtDtoPor.DecimalPlaces = 2;
            this.txtDtoPor.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtDtoPor.Location = new System.Drawing.Point(628, 10);
            this.txtDtoPor.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.txtDtoPor.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.txtDtoPor.Name = "txtDtoPor";
            this.txtDtoPor.Size = new System.Drawing.Size(99, 29);
            this.txtDtoPor.TabIndex = 195;
            this.txtDtoPor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtDtoPes
            // 
            this.txtDtoPes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDtoPes.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtDtoPes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDtoPes.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDtoPes.FocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtDtoPes.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDtoPes.ForeColor = System.Drawing.Color.DimGray;
            this.txtDtoPes.Location = new System.Drawing.Point(809, 10);
            this.txtDtoPes.Name = "txtDtoPes";
            this.txtDtoPes.Numerico = false;
            this.txtDtoPes.Size = new System.Drawing.Size(90, 25);
            this.txtDtoPes.TabIndex = 193;
            this.txtDtoPes.Tag = "\"\"";
            this.txtDtoPes.Text = "0";
            this.txtDtoPes.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDtoPes.Leave += new System.EventHandler(this.txtDtoPes_Leave);
            // 
            // cboTipoFacturacion
            // 
            this.cboTipoFacturacion.BorderColor = System.Drawing.Color.DimGray;
            this.cboTipoFacturacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoFacturacion.Enabled = false;
            this.cboTipoFacturacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboTipoFacturacion.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTipoFacturacion.FormattingEnabled = true;
            this.cboTipoFacturacion.Location = new System.Drawing.Point(566, 271);
            this.cboTipoFacturacion.Name = "cboTipoFacturacion";
            this.cboTipoFacturacion.Size = new System.Drawing.Size(333, 29);
            this.cboTipoFacturacion.TabIndex = 196;
            this.cboTipoFacturacion.Visible = false;
            this.cboTipoFacturacion.SelectedIndexChanged += new System.EventHandler(this.cboTipoFacturacion_SelectedIndexChanged);
            // 
            // cboUsuarios
            // 
            this.cboUsuarios.BorderColor = System.Drawing.Color.DimGray;
            this.cboUsuarios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboUsuarios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboUsuarios.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboUsuarios.FormattingEnabled = true;
            this.cboUsuarios.Location = new System.Drawing.Point(126, 13);
            this.cboUsuarios.Name = "cboUsuarios";
            this.cboUsuarios.Size = new System.Drawing.Size(282, 29);
            this.cboUsuarios.TabIndex = 194;
            this.cboUsuarios.SelectedIndexChanged += new System.EventHandler(this.cboUsuarios_SelectedIndexChanged);
            // 
            // cboLocacion
            // 
            this.cboLocacion.BorderColor = System.Drawing.Color.DimGray;
            this.cboLocacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLocacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboLocacion.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboLocacion.FormattingEnabled = true;
            this.cboLocacion.Location = new System.Drawing.Point(516, 13);
            this.cboLocacion.Name = "cboLocacion";
            this.cboLocacion.Size = new System.Drawing.Size(383, 29);
            this.cboLocacion.TabIndex = 188;
            this.cboLocacion.SelectedIndexChanged += new System.EventHandler(this.cboLocacion_SelectedIndexChanged);
            this.cboLocacion.SelectedValueChanged += new System.EventHandler(this.cboLocacion_SelectedValueChanged);
            // 
            // dgvServicios
            // 
            this.dgvServicios.AllowUserToAddRows = false;
            this.dgvServicios.AllowUserToDeleteRows = false;
            this.dgvServicios.AllowUserToOrderColumns = true;
            this.dgvServicios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvServicios.BackgroundColor = System.Drawing.Color.White;
            this.dgvServicios.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvServicios.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSlateGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvServicios.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvServicios.ColumnHeadersHeight = 40;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvServicios.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvServicios.EnableHeadersVisualStyles = false;
            this.dgvServicios.GridColor = System.Drawing.Color.WhiteSmoke;
            this.dgvServicios.Location = new System.Drawing.Point(63, 78);
            this.dgvServicios.MultiSelect = false;
            this.dgvServicios.Name = "dgvServicios";
            this.dgvServicios.ReadOnly = true;
            this.dgvServicios.RowHeadersVisible = false;
            this.dgvServicios.RowHeadersWidth = 50;
            this.dgvServicios.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvServicios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvServicios.Size = new System.Drawing.Size(345, 192);
            this.dgvServicios.TabIndex = 1;
            this.dgvServicios.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvServicios_CellEndEdit);
            this.dgvServicios.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvServicios_CellEnter);
            // 
            // dgvSubservicios
            // 
            this.dgvSubservicios.AllowUserToAddRows = false;
            this.dgvSubservicios.AllowUserToDeleteRows = false;
            this.dgvSubservicios.AllowUserToOrderColumns = true;
            this.dgvSubservicios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSubservicios.BackgroundColor = System.Drawing.Color.White;
            this.dgvSubservicios.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvSubservicios.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.LightSlateGray;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSubservicios.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvSubservicios.ColumnHeadersHeight = 40;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSubservicios.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvSubservicios.EnableHeadersVisualStyles = false;
            this.dgvSubservicios.GridColor = System.Drawing.Color.WhiteSmoke;
            this.dgvSubservicios.Location = new System.Drawing.Point(414, 78);
            this.dgvSubservicios.MultiSelect = false;
            this.dgvSubservicios.Name = "dgvSubservicios";
            this.dgvSubservicios.ReadOnly = true;
            this.dgvSubservicios.RowHeadersVisible = false;
            this.dgvSubservicios.RowHeadersWidth = 50;
            this.dgvSubservicios.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvSubservicios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSubservicios.Size = new System.Drawing.Size(485, 192);
            this.dgvSubservicios.TabIndex = 0;
            // 
            // cboDirigido
            // 
            this.cboDirigido.BorderColor = System.Drawing.Color.DimGray;
            this.cboDirigido.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDirigido.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboDirigido.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboDirigido.FormattingEnabled = true;
            this.cboDirigido.Location = new System.Drawing.Point(137, 148);
            this.cboDirigido.Name = "cboDirigido";
            this.cboDirigido.Size = new System.Drawing.Size(192, 29);
            this.cboDirigido.TabIndex = 189;
            // 
            // txtDetalle
            // 
            this.txtDetalle.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtDetalle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDetalle.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDetalle.FocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtDetalle.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDetalle.ForeColor = System.Drawing.Color.DimGray;
            this.txtDetalle.Location = new System.Drawing.Point(137, 110);
            this.txtDetalle.Name = "txtDetalle";
            this.txtDetalle.Numerico = false;
            this.txtDetalle.Size = new System.Drawing.Size(383, 25);
            this.txtDetalle.TabIndex = 187;
            this.txtDetalle.Tag = "\"\"";
            // 
            // btnCancela
            // 
            this.btnCancela.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancela.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnCancela.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancela.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnCancela.FlatAppearance.BorderSize = 0;
            this.btnCancela.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnCancela.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnCancela.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancela.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancela.ForeColor = System.Drawing.Color.White;
            this.btnCancela.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancela.Location = new System.Drawing.Point(842, 652);
            this.btnCancela.Name = "btnCancela";
            this.btnCancela.Size = new System.Drawing.Size(85, 38);
            this.btnCancela.TabIndex = 87;
            this.btnCancela.Text = "Cancelar";
            this.btnCancela.UseVisualStyleBackColor = false;
            this.btnCancela.Click += new System.EventHandler(this.btnCancela_Click);
            // 
            // btnAplicar
            // 
            this.btnAplicar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAplicar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnAplicar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAplicar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnAplicar.FlatAppearance.BorderSize = 0;
            this.btnAplicar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnAplicar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnAplicar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAplicar.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAplicar.ForeColor = System.Drawing.Color.White;
            this.btnAplicar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAplicar.Location = new System.Drawing.Point(751, 652);
            this.btnAplicar.Name = "btnAplicar";
            this.btnAplicar.Size = new System.Drawing.Size(85, 38);
            this.btnAplicar.TabIndex = 86;
            this.btnAplicar.Text = "Aplicar";
            this.btnAplicar.UseVisualStyleBackColor = false;
            this.btnAplicar.Click += new System.EventHandler(this.btnAplicar_Click);
            // 
            // pgCircular
            // 
            this.pgCircular.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pgCircular.Location = new System.Drawing.Point(888, 56);
            this.pgCircular.Name = "pgCircular";
            this.pgCircular.Percentage = 0F;
            this.pgCircular.Rotation = CapaPresentacion.Controles.RotationType.CounterClockwise;
            this.pgCircular.Size = new System.Drawing.Size(24, 24);
            this.pgCircular.TabIndex = 83;
            // 
            // frmUsuariosCtaCteNovedadesDetalle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 696);
            this.Controls.Add(this.pnlDescuentos);
            this.Controls.Add(this.pnlServicios);
            this.Controls.Add(this.pnlComun);
            this.Controls.Add(this.btnCancela);
            this.Controls.Add(this.btnAplicar);
            this.Controls.Add(this.pnLinea1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "frmUsuariosCtaCteNovedadesDetalle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmUsuariosCtaCteNovedadesDetalle";
            this.Load += new System.EventHandler(this.frmUsuariosCtaCteNovedadesDetalle_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmUsuariosCtaCteNovedadesDetalle_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmUsuariosCtaCteNovedadesDetalle_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.imgReturn)).EndInit();
            this.pnLinea1.ResumeLayout(false);
            this.pnLinea1.PerformLayout();
            this.pnlComun.ResumeLayout(false);
            this.pnlComun.PerformLayout();
            this.pnlServicios.ResumeLayout(false);
            this.pnlServicios.PerformLayout();
            this.pnlDescuentos.ResumeLayout(false);
            this.pnlDescuentos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDtoPor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvServicios)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSubservicios)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Controles.dgv dgvSubservicios;
        private Controles.dgv dgvServicios;
        private System.Windows.Forms.PictureBox imgReturn;
        private System.Windows.Forms.Panel pnLinea1;
        private System.Windows.Forms.Label lblocalidad;
        private System.Windows.Forms.Label lblUsuario;
        private Controles.progress pgCircular;
        private Controles.boton btnAplicar;
        private Controles.boton btnCancela;
        private System.Windows.Forms.Label lbHasta;
        private System.Windows.Forms.Label lbDesde;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.CheckBox chkFinaliza;
        private System.Windows.Forms.Panel pnlComun;
        private System.Windows.Forms.Panel pnlServicios;
        private System.Windows.Forms.Label lblDirigido;
        private Controles.combo cboDirigido;
        private Controles.combo cboLocacion;
        private System.Windows.Forms.Label lblLocacion;
        private System.Windows.Forms.Label lblSubServicios;
        private System.Windows.Forms.Label lblServicios;
        private textboxAdv txtDetalle;
        private System.Windows.Forms.Panel pnlDescuentos;
        private System.Windows.Forms.Label lblDtoPorc;
        private textboxAdv txtDtoPes;
        private System.Windows.Forms.Label lblDtopesos;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lvlInfo;
        private Controles.combo cboUsuarios;
        private System.Windows.Forms.Label label3;
        private Controles.combo cboTipoFacturacion;
        private Controles.spinner txtDtoPor;
    }
}