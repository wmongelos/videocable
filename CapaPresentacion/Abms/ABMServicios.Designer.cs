namespace CapaPresentacion.Abms
{
    partial class ABMServicios
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
            this.pnFooter = new System.Windows.Forms.Panel();
            this.lblRequiereCondicion = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.pgCircular = new CapaPresentacion.Controles.progress();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblSubServ = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.chkValor_Defecto = new System.Windows.Forms.CheckBox();
            this.chkRequiere_IP = new System.Windows.Forms.CheckBox();
            this.lblServTec = new System.Windows.Forms.Label();
            this.lblTipoSub = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.imgReturn = new System.Windows.Forms.PictureBox();
            this.lblTituloHeader = new System.Windows.Forms.Label();
            this.lblPorDef = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.txtBusca = new System.Windows.Forms.TextBox();
            this.btnVelocidad = new CapaPresentacion.Controles.boton();
            this.cboAlicuotas = new CapaPresentacion.Controles.combo(this.components);
            this.btnCondicionesContratacion = new CapaPresentacion.Controles.boton();
            this.btnCancelarSub = new CapaPresentacion.Controles.boton();
            this.btnNuevaSub = new CapaPresentacion.Controles.boton();
            this.btnGuardarSub = new CapaPresentacion.Controles.boton();
            this.btnEditarSub = new CapaPresentacion.Controles.boton();
            this.cboSubservicios_Tipos = new CapaPresentacion.Controles.combo(this.components);
            this.txtSubServicio = new CapaPresentacion.textboxAdv();
            this.txtIdSubServicio = new CapaPresentacion.textboxAdv();
            this.dgvSub = new CapaPresentacion.Controles.dgv(this.components);
            this.btnCancelar = new CapaPresentacion.Controles.boton();
            this.btnGuardar = new CapaPresentacion.Controles.boton();
            this.btnEliminar = new CapaPresentacion.Controles.boton();
            this.btnEditar = new CapaPresentacion.Controles.boton();
            this.btnNuevo = new CapaPresentacion.Controles.boton();
            this.btnActualizar = new CapaPresentacion.Controles.boton();
            this.dgv = new CapaPresentacion.Controles.dgv(this.components);
            this.pnFooter.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgReturn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSub)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // pnFooter
            // 
            this.pnFooter.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnFooter.Controls.Add(this.lblRequiereCondicion);
            this.pnFooter.Controls.Add(this.lblTotal);
            this.pnFooter.Controls.Add(this.pgCircular);
            this.pnFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnFooter.Location = new System.Drawing.Point(0, 488);
            this.pnFooter.Name = "pnFooter";
            this.pnFooter.Size = new System.Drawing.Size(1361, 30);
            this.pnFooter.TabIndex = 2;
            // 
            // lblRequiereCondicion
            // 
            this.lblRequiereCondicion.AutoSize = true;
            this.lblRequiereCondicion.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRequiereCondicion.ForeColor = System.Drawing.Color.Black;
            this.lblRequiereCondicion.Location = new System.Drawing.Point(226, 5);
            this.lblRequiereCondicion.Name = "lblRequiereCondicion";
            this.lblRequiereCondicion.Size = new System.Drawing.Size(172, 21);
            this.lblRequiereCondicion.TabIndex = 14;
            this.lblRequiereCondicion.Text = "REQUIERE CONDICION";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.ForeColor = System.Drawing.Color.Black;
            this.lblTotal.Location = new System.Drawing.Point(12, 5);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(148, 21);
            this.lblTotal.TabIndex = 13;
            this.lblTotal.Text = "Total de Registros: 0";
            // 
            // pgCircular
            // 
            this.pgCircular.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pgCircular.Location = new System.Drawing.Point(1325, 2);
            this.pgCircular.Name = "pgCircular";
            this.pgCircular.Percentage = 0F;
            this.pgCircular.Rotation = CapaPresentacion.Controles.RotationType.CounterClockwise;
            this.pgCircular.Size = new System.Drawing.Size(24, 24);
            this.pgCircular.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.Location = new System.Drawing.Point(0, 119);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1361, 1);
            this.panel1.TabIndex = 6;
            // 
            // lblSubServ
            // 
            this.lblSubServ.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSubServ.AutoSize = true;
            this.lblSubServ.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubServ.ForeColor = System.Drawing.Color.Black;
            this.lblSubServ.Location = new System.Drawing.Point(6, 279);
            this.lblSubServ.Name = "lblSubServ";
            this.lblSubServ.Size = new System.Drawing.Size(95, 21);
            this.lblSubServ.TabIndex = 22;
            this.lblSubServ.Text = "SubServicio:";
            // 
            // panel5
            // 
            this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel5.BackColor = System.Drawing.Color.Gainsboro;
            this.panel5.Location = new System.Drawing.Point(-2, 342);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1361, 1);
            this.panel5.TabIndex = 9;
            // 
            // chkValor_Defecto
            // 
            this.chkValor_Defecto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkValor_Defecto.AutoSize = true;
            this.chkValor_Defecto.Enabled = false;
            this.chkValor_Defecto.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkValor_Defecto.Location = new System.Drawing.Point(312, 314);
            this.chkValor_Defecto.Name = "chkValor_Defecto";
            this.chkValor_Defecto.Size = new System.Drawing.Size(15, 14);
            this.chkValor_Defecto.TabIndex = 30;
            this.chkValor_Defecto.UseVisualStyleBackColor = true;
            // 
            // chkRequiere_IP
            // 
            this.chkRequiere_IP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkRequiere_IP.AutoSize = true;
            this.chkRequiere_IP.Enabled = false;
            this.chkRequiere_IP.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkRequiere_IP.Location = new System.Drawing.Point(488, 314);
            this.chkRequiere_IP.Name = "chkRequiere_IP";
            this.chkRequiere_IP.Size = new System.Drawing.Size(15, 14);
            this.chkRequiere_IP.TabIndex = 32;
            this.chkRequiere_IP.UseVisualStyleBackColor = true;
            // 
            // lblServTec
            // 
            this.lblServTec.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblServTec.AutoSize = true;
            this.lblServTec.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblServTec.ForeColor = System.Drawing.Color.Black;
            this.lblServTec.Location = new System.Drawing.Point(326, 311);
            this.lblServTec.Name = "lblServTec";
            this.lblServTec.Size = new System.Drawing.Size(158, 21);
            this.lblServTec.TabIndex = 31;
            this.lblServTec.Text = "Requiere Velocidades";
            // 
            // lblTipoSub
            // 
            this.lblTipoSub.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTipoSub.AutoSize = true;
            this.lblTipoSub.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipoSub.ForeColor = System.Drawing.Color.Black;
            this.lblTipoSub.Location = new System.Drawing.Point(533, 279);
            this.lblTipoSub.Name = "lblTipoSub";
            this.lblTipoSub.Size = new System.Drawing.Size(43, 21);
            this.lblTipoSub.TabIndex = 35;
            this.lblTipoSub.Text = "Tipo:";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.panel3.Controls.Add(this.imgReturn);
            this.panel3.Controls.Add(this.lblTituloHeader);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1361, 75);
            this.panel3.TabIndex = 49;
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
            this.lblTituloHeader.Size = new System.Drawing.Size(338, 23);
            this.lblTituloHeader.TabIndex = 31;
            this.lblTituloHeader.Text = "Servicios";
            // 
            // lblPorDef
            // 
            this.lblPorDef.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblPorDef.AutoSize = true;
            this.lblPorDef.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPorDef.ForeColor = System.Drawing.Color.Black;
            this.lblPorDef.Location = new System.Drawing.Point(95, 311);
            this.lblPorDef.Name = "lblPorDef";
            this.lblPorDef.Size = new System.Drawing.Size(218, 21);
            this.lblPorDef.TabIndex = 29;
            this.lblPorDef.Text = "Por defecto en P. de Conexion:";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(539, 311);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 21);
            this.label1.TabIndex = 63;
            this.label1.Text = "IVA:";
            // 
            // lblBuscar
            // 
            this.lblBuscar.AutoSize = true;
            this.lblBuscar.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBuscar.Location = new System.Drawing.Point(6, 87);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Size = new System.Drawing.Size(70, 21);
            this.lblBuscar.TabIndex = 66;
            this.lblBuscar.Text = "BUSCAR:";
            // 
            // txtBusca
            // 
            this.txtBusca.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtBusca.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtBusca.Location = new System.Drawing.Point(82, 82);
            this.txtBusca.Name = "txtBusca";
            this.txtBusca.Size = new System.Drawing.Size(518, 29);
            this.txtBusca.TabIndex = 67;
            this.txtBusca.TextChanged += new System.EventHandler(this.txtBusca_TextChanged);
            // 
            // btnVelocidad
            // 
            this.btnVelocidad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnVelocidad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnVelocidad.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVelocidad.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnVelocidad.FlatAppearance.BorderSize = 0;
            this.btnVelocidad.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnVelocidad.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnVelocidad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVelocidad.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVelocidad.ForeColor = System.Drawing.Color.White;
            this.btnVelocidad.Image = global::CapaPresentacion.Properties.Resources.Data_Add_32;
            this.btnVelocidad.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnVelocidad.Location = new System.Drawing.Point(819, 275);
            this.btnVelocidad.Name = "btnVelocidad";
            this.btnVelocidad.Size = new System.Drawing.Size(124, 35);
            this.btnVelocidad.TabIndex = 65;
            this.btnVelocidad.Text = "Velocidades";
            this.btnVelocidad.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVelocidad.UseVisualStyleBackColor = false;
            this.btnVelocidad.Visible = false;
            this.btnVelocidad.Click += new System.EventHandler(this.btnVelocidad_Click);
            // 
            // cboAlicuotas
            // 
            this.cboAlicuotas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cboAlicuotas.BorderColor = System.Drawing.Color.Gainsboro;
            this.cboAlicuotas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAlicuotas.Enabled = false;
            this.cboAlicuotas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboAlicuotas.Font = new System.Drawing.Font("Segoe UI Light", 12F);
            this.cboAlicuotas.FormattingEnabled = true;
            this.cboAlicuotas.Location = new System.Drawing.Point(582, 307);
            this.cboAlicuotas.Name = "cboAlicuotas";
            this.cboAlicuotas.Size = new System.Drawing.Size(206, 29);
            this.cboAlicuotas.TabIndex = 64;
            // 
            // btnCondicionesContratacion
            // 
            this.btnCondicionesContratacion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCondicionesContratacion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnCondicionesContratacion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCondicionesContratacion.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnCondicionesContratacion.FlatAppearance.BorderSize = 0;
            this.btnCondicionesContratacion.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnCondicionesContratacion.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnCondicionesContratacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCondicionesContratacion.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCondicionesContratacion.ForeColor = System.Drawing.Color.White;
            this.btnCondicionesContratacion.Image = global::CapaPresentacion.Properties.Resources.Data_Edit_32__1_;
            this.btnCondicionesContratacion.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCondicionesContratacion.Location = new System.Drawing.Point(722, 80);
            this.btnCondicionesContratacion.Name = "btnCondicionesContratacion";
            this.btnCondicionesContratacion.Size = new System.Drawing.Size(124, 35);
            this.btnCondicionesContratacion.TabIndex = 50;
            this.btnCondicionesContratacion.Text = "Condiciones";
            this.btnCondicionesContratacion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCondicionesContratacion.UseVisualStyleBackColor = false;
            this.btnCondicionesContratacion.Click += new System.EventHandler(this.btnCondicionesContratacion_Click);
            // 
            // btnCancelarSub
            // 
            this.btnCancelarSub.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelarSub.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnCancelarSub.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelarSub.Enabled = false;
            this.btnCancelarSub.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnCancelarSub.FlatAppearance.BorderSize = 0;
            this.btnCancelarSub.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnCancelarSub.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnCancelarSub.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelarSub.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelarSub.ForeColor = System.Drawing.Color.White;
            this.btnCancelarSub.Image = global::CapaPresentacion.Properties.Resources.Command_Redo_32;
            this.btnCancelarSub.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelarSub.Location = new System.Drawing.Point(1247, 275);
            this.btnCancelarSub.Name = "btnCancelarSub";
            this.btnCancelarSub.Size = new System.Drawing.Size(102, 35);
            this.btnCancelarSub.TabIndex = 48;
            this.btnCancelarSub.Text = "Cancelar";
            this.btnCancelarSub.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelarSub.UseVisualStyleBackColor = false;
            this.btnCancelarSub.Click += new System.EventHandler(this.btnCancelarSub_Click);
            // 
            // btnNuevaSub
            // 
            this.btnNuevaSub.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNuevaSub.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnNuevaSub.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNuevaSub.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnNuevaSub.FlatAppearance.BorderSize = 0;
            this.btnNuevaSub.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnNuevaSub.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnNuevaSub.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevaSub.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevaSub.ForeColor = System.Drawing.Color.White;
            this.btnNuevaSub.Image = global::CapaPresentacion.Properties.Resources.Data_Add_32;
            this.btnNuevaSub.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNuevaSub.Location = new System.Drawing.Point(949, 275);
            this.btnNuevaSub.Name = "btnNuevaSub";
            this.btnNuevaSub.Size = new System.Drawing.Size(91, 35);
            this.btnNuevaSub.TabIndex = 46;
            this.btnNuevaSub.Text = "Nuevo";
            this.btnNuevaSub.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNuevaSub.UseVisualStyleBackColor = false;
            this.btnNuevaSub.Click += new System.EventHandler(this.btnNuevaSub_Click);
            // 
            // btnGuardarSub
            // 
            this.btnGuardarSub.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGuardarSub.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnGuardarSub.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardarSub.Enabled = false;
            this.btnGuardarSub.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnGuardarSub.FlatAppearance.BorderSize = 0;
            this.btnGuardarSub.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnGuardarSub.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnGuardarSub.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardarSub.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardarSub.ForeColor = System.Drawing.Color.White;
            this.btnGuardarSub.Image = global::CapaPresentacion.Properties.Resources.Save_32;
            this.btnGuardarSub.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGuardarSub.Location = new System.Drawing.Point(1143, 275);
            this.btnGuardarSub.Name = "btnGuardarSub";
            this.btnGuardarSub.Size = new System.Drawing.Size(98, 35);
            this.btnGuardarSub.TabIndex = 45;
            this.btnGuardarSub.Text = "Guardar";
            this.btnGuardarSub.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuardarSub.UseVisualStyleBackColor = false;
            this.btnGuardarSub.Click += new System.EventHandler(this.btnGuardarSub_Click);
            // 
            // btnEditarSub
            // 
            this.btnEditarSub.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditarSub.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnEditarSub.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditarSub.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnEditarSub.FlatAppearance.BorderSize = 0;
            this.btnEditarSub.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnEditarSub.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnEditarSub.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditarSub.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditarSub.ForeColor = System.Drawing.Color.White;
            this.btnEditarSub.Image = global::CapaPresentacion.Properties.Resources.Data_Edit_32__1_;
            this.btnEditarSub.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEditarSub.Location = new System.Drawing.Point(1046, 275);
            this.btnEditarSub.Name = "btnEditarSub";
            this.btnEditarSub.Size = new System.Drawing.Size(91, 35);
            this.btnEditarSub.TabIndex = 44;
            this.btnEditarSub.Text = "Editar";
            this.btnEditarSub.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEditarSub.UseVisualStyleBackColor = false;
            this.btnEditarSub.Click += new System.EventHandler(this.btnEditarSub_Click);
            // 
            // cboSubservicios_Tipos
            // 
            this.cboSubservicios_Tipos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cboSubservicios_Tipos.BorderColor = System.Drawing.Color.Gainsboro;
            this.cboSubservicios_Tipos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSubservicios_Tipos.Enabled = false;
            this.cboSubservicios_Tipos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboSubservicios_Tipos.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboSubservicios_Tipos.FormattingEnabled = true;
            this.cboSubservicios_Tipos.Location = new System.Drawing.Point(582, 275);
            this.cboSubservicios_Tipos.Name = "cboSubservicios_Tipos";
            this.cboSubservicios_Tipos.Size = new System.Drawing.Size(206, 29);
            this.cboSubservicios_Tipos.TabIndex = 36;
            this.cboSubservicios_Tipos.SelectedValueChanged += new System.EventHandler(this.cboSubservicios_Tipos_SelectedValueChanged);
            // 
            // txtSubServicio
            // 
            this.txtSubServicio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtSubServicio.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtSubServicio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSubServicio.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSubServicio.Enabled = false;
            this.txtSubServicio.FocusColor = System.Drawing.Color.Empty;
            this.txtSubServicio.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSubServicio.ForeColor = System.Drawing.Color.Black;
            this.txtSubServicio.Location = new System.Drawing.Point(99, 275);
            this.txtSubServicio.Name = "txtSubServicio";
            this.txtSubServicio.Numerico = false;
            this.txtSubServicio.Size = new System.Drawing.Size(390, 29);
            this.txtSubServicio.TabIndex = 24;
            // 
            // txtIdSubServicio
            // 
            this.txtIdSubServicio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtIdSubServicio.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtIdSubServicio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIdSubServicio.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtIdSubServicio.Enabled = false;
            this.txtIdSubServicio.FocusColor = System.Drawing.Color.Empty;
            this.txtIdSubServicio.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdSubServicio.ForeColor = System.Drawing.Color.Black;
            this.txtIdSubServicio.Location = new System.Drawing.Point(10, 307);
            this.txtIdSubServicio.Name = "txtIdSubServicio";
            this.txtIdSubServicio.Numerico = false;
            this.txtIdSubServicio.Size = new System.Drawing.Size(59, 29);
            this.txtIdSubServicio.TabIndex = 23;
            this.txtIdSubServicio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtIdSubServicio.Visible = false;
            // 
            // dgvSub
            // 
            this.dgvSub.AllowUserToAddRows = false;
            this.dgvSub.AllowUserToDeleteRows = false;
            this.dgvSub.AllowUserToOrderColumns = true;
            this.dgvSub.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSub.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSub.BackgroundColor = System.Drawing.Color.White;
            this.dgvSub.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvSub.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSlateGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSub.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvSub.ColumnHeadersHeight = 40;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSub.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvSub.Enabled = false;
            this.dgvSub.EnableHeadersVisualStyles = false;
            this.dgvSub.GridColor = System.Drawing.Color.WhiteSmoke;
            this.dgvSub.Location = new System.Drawing.Point(12, 352);
            this.dgvSub.MultiSelect = false;
            this.dgvSub.Name = "dgvSub";
            this.dgvSub.ReadOnly = true;
            this.dgvSub.RowHeadersVisible = false;
            this.dgvSub.RowHeadersWidth = 50;
            this.dgvSub.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvSub.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSub.Size = new System.Drawing.Size(1337, 129);
            this.dgvSub.TabIndex = 13;
            this.dgvSub.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSub_CellContentClick);
            this.dgvSub.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSub_CellEnter);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.Enabled = false;
            this.btnCancelar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Image = global::CapaPresentacion.Properties.Resources.Command_Redo_32;
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.Location = new System.Drawing.Point(1247, 80);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(102, 35);
            this.btnCancelar.TabIndex = 10;
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
            this.btnGuardar.Enabled = false;
            this.btnGuardar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnGuardar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Image = global::CapaPresentacion.Properties.Resources.Save_32;
            this.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGuardar.Location = new System.Drawing.Point(1143, 80);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(98, 35);
            this.btnGuardar.TabIndex = 8;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
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
            this.btnEliminar.Location = new System.Drawing.Point(1046, 80);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(91, 35);
            this.btnEliminar.TabIndex = 7;
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
            this.btnEditar.Location = new System.Drawing.Point(949, 80);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(91, 35);
            this.btnEditar.TabIndex = 6;
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
            this.btnNuevo.Location = new System.Drawing.Point(852, 80);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(91, 35);
            this.btnNuevo.TabIndex = 4;
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
            this.btnActualizar.Location = new System.Drawing.Point(606, 80);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(110, 35);
            this.btnActualizar.TabIndex = 3;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnActualizar.UseVisualStyleBackColor = false;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AllowUserToOrderColumns = true;
            this.dgv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv.BackgroundColor = System.Drawing.Color.White;
            this.dgv.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgv.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.LightSlateGray;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgv.ColumnHeadersHeight = 40;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgv.Enabled = false;
            this.dgv.EnableHeadersVisualStyles = false;
            this.dgv.GridColor = System.Drawing.Color.WhiteSmoke;
            this.dgv.Location = new System.Drawing.Point(12, 124);
            this.dgv.MultiSelect = false;
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersVisible = false;
            this.dgv.RowHeadersWidth = 50;
            this.dgv.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(1337, 143);
            this.dgv.TabIndex = 1;
            this.dgv.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellEnter);
            // 
            // ABMServicios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(250)))), ((int)(((byte)(251)))));
            this.ClientSize = new System.Drawing.Size(1361, 518);
            this.ControlBox = false;
            this.Controls.Add(this.txtBusca);
            this.Controls.Add(this.lblBuscar);
            this.Controls.Add(this.btnVelocidad);
            this.Controls.Add(this.cboAlicuotas);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCondicionesContratacion);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.btnCancelarSub);
            this.Controls.Add(this.btnNuevaSub);
            this.Controls.Add(this.btnGuardarSub);
            this.Controls.Add(this.btnEditarSub);
            this.Controls.Add(this.cboSubservicios_Tipos);
            this.Controls.Add(this.lblTipoSub);
            this.Controls.Add(this.chkRequiere_IP);
            this.Controls.Add(this.lblServTec);
            this.Controls.Add(this.chkValor_Defecto);
            this.Controls.Add(this.lblPorDef);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.txtSubServicio);
            this.Controls.Add(this.txtIdSubServicio);
            this.Controls.Add(this.lblSubServ);
            this.Controls.Add(this.dgvSub);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.pnFooter);
            this.Controls.Add(this.dgv);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "ABMServicios";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "ABMServicios";
            this.Load += new System.EventHandler(this.ABMServicios_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ABMServicios_KeyDown);
            this.pnFooter.ResumeLayout(false);
            this.pnFooter.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgReturn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSub)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Controles.dgv dgv;
        private System.Windows.Forms.Panel pnFooter;
        private Controles.progress pgCircular;
        private Controles.boton btnActualizar;
        private Controles.boton btnNuevo;
        private Controles.boton btnEliminar;
        private Controles.boton btnEditar;
        private Controles.boton btnGuardar;
        private System.Windows.Forms.Panel panel1;
        private Controles.boton btnCancelar;
        private System.Windows.Forms.Label lblTotal;
        private Controles.dgv dgvSub;
        private textboxAdv txtSubServicio;
        private textboxAdv txtIdSubServicio;
        private System.Windows.Forms.Label lblSubServ;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.CheckBox chkValor_Defecto;
        private System.Windows.Forms.CheckBox chkRequiere_IP;
        private System.Windows.Forms.Label lblServTec;
        private Controles.combo cboSubservicios_Tipos;
        private System.Windows.Forms.Label lblTipoSub;
        private Controles.boton btnEditarSub;
        private Controles.boton btnGuardarSub;
        private Controles.boton btnNuevaSub;
        private Controles.boton btnCancelarSub;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox imgReturn;
        private System.Windows.Forms.Label lblTituloHeader;
        private System.Windows.Forms.Label lblPorDef;
        private Controles.boton btnCondicionesContratacion;
        private Controles.combo cboAlicuotas;
        private System.Windows.Forms.Label label1;
        private Controles.boton btnVelocidad;
        private System.Windows.Forms.Label lblRequiereCondicion;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.TextBox txtBusca;
    }
}