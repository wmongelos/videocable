namespace CapaPresentacion.Herramientas
{
    partial class frmCambioServicio
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
            this.lblModalidad = new System.Windows.Forms.Label();
            this.lblServiciosContratados = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel11 = new System.Windows.Forms.Panel();
            this.txtTotal = new CapaPresentacion.textboxAdv();
            this.lbTotal = new System.Windows.Forms.Label();
            this.lblTotalConexion = new System.Windows.Forms.Label();
            this.llblTotalEquipos = new System.Windows.Forms.Label();
            this.lblTotalServicios = new System.Windows.Forms.Label();
            this.txtTotalConexion = new CapaPresentacion.textboxAdv();
            this.txtTotalEquipamiento = new CapaPresentacion.textboxAdv();
            this.txtTotalServicio = new CapaPresentacion.textboxAdv();
            this.pnlContratar = new System.Windows.Forms.Panel();
            this.boton1 = new CapaPresentacion.Controles.boton();
            this.btnConfirmar = new CapaPresentacion.Controles.boton();
            this.cboTipoFacturacion = new CapaPresentacion.Controles.combo(this.components);
            this.btnServicios = new CapaPresentacion.Controles.boton();
            this.spMain = new System.Windows.Forms.SplitContainer();
            this.btnNuevo = new CapaPresentacion.Controles.boton();
            this.dgvServiciosContratados = new CapaPresentacion.Controles.dgv(this.components);
            this.dgvContrato = new CapaPresentacion.Controles.dgv(this.components);
            this.pnlHead = new System.Windows.Forms.Panel();
            this.imgReturn = new System.Windows.Forms.PictureBox();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.panel11.SuspendLayout();
            this.pnlContratar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spMain)).BeginInit();
            this.spMain.Panel1.SuspendLayout();
            this.spMain.Panel2.SuspendLayout();
            this.spMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvServiciosContratados)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvContrato)).BeginInit();
            this.pnlHead.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgReturn)).BeginInit();
            this.SuspendLayout();
            // 
            // lblModalidad
            // 
            this.lblModalidad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblModalidad.AutoSize = true;
            this.lblModalidad.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.lblModalidad.ForeColor = System.Drawing.Color.Black;
            this.lblModalidad.Location = new System.Drawing.Point(545, 8);
            this.lblModalidad.Name = "lblModalidad";
            this.lblModalidad.Size = new System.Drawing.Size(98, 25);
            this.lblModalidad.TabIndex = 67;
            this.lblModalidad.Text = "Categoria:";
            // 
            // lblServiciosContratados
            // 
            this.lblServiciosContratados.BackColor = System.Drawing.SystemColors.Control;
            this.lblServiciosContratados.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblServiciosContratados.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblServiciosContratados.ForeColor = System.Drawing.Color.Black;
            this.lblServiciosContratados.Location = new System.Drawing.Point(0, 0);
            this.lblServiciosContratados.Name = "lblServiciosContratados";
            this.lblServiciosContratados.Size = new System.Drawing.Size(1386, 49);
            this.lblServiciosContratados.TabIndex = 72;
            this.lblServiciosContratados.Text = "SERVICIOS CONTRATADOS";
            this.lblServiciosContratados.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblServiciosContratados.Click += new System.EventHandler(this.lblServiciosContratados_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 21);
            this.label1.TabIndex = 73;
            this.label1.Text = "NUEVO SERVICIO";
            // 
            // panel11
            // 
            this.panel11.BackColor = System.Drawing.Color.SlateGray;
            this.panel11.Controls.Add(this.txtTotal);
            this.panel11.Controls.Add(this.lbTotal);
            this.panel11.Controls.Add(this.lblTotalConexion);
            this.panel11.Controls.Add(this.llblTotalEquipos);
            this.panel11.Controls.Add(this.lblTotalServicios);
            this.panel11.Controls.Add(this.txtTotalConexion);
            this.panel11.Controls.Add(this.txtTotalEquipamiento);
            this.panel11.Controls.Add(this.txtTotalServicio);
            this.panel11.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel11.Location = new System.Drawing.Point(0, 587);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(1386, 60);
            this.panel11.TabIndex = 75;
            this.panel11.Visible = false;
            // 
            // txtTotal
            // 
            this.txtTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTotal.BackColor = System.Drawing.Color.SlateGray;
            this.txtTotal.BorderColor = System.Drawing.Color.Transparent;
            this.txtTotal.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTotal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTotal.FocusColor = System.Drawing.Color.Empty;
            this.txtTotal.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.txtTotal.ForeColor = System.Drawing.Color.White;
            this.txtTotal.Location = new System.Drawing.Point(1275, 30);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Numerico = true;
            this.txtTotal.Size = new System.Drawing.Size(84, 25);
            this.txtTotal.TabIndex = 82;
            this.txtTotal.TabStop = false;
            this.txtTotal.Tag = "\"\"";
            this.txtTotal.Text = "0";
            this.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lbTotal
            // 
            this.lbTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbTotal.AutoSize = true;
            this.lbTotal.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.lbTotal.ForeColor = System.Drawing.Color.White;
            this.lbTotal.Location = new System.Drawing.Point(1320, 5);
            this.lbTotal.Name = "lbTotal";
            this.lbTotal.Size = new System.Drawing.Size(52, 25);
            this.lbTotal.TabIndex = 83;
            this.lbTotal.Text = "Total";
            // 
            // lblTotalConexion
            // 
            this.lblTotalConexion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalConexion.AutoSize = true;
            this.lblTotalConexion.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.lblTotalConexion.ForeColor = System.Drawing.Color.White;
            this.lblTotalConexion.Location = new System.Drawing.Point(1036, 5);
            this.lblTotalConexion.Name = "lblTotalConexion";
            this.lblTotalConexion.Size = new System.Drawing.Size(171, 25);
            this.lblTotalConexion.TabIndex = 81;
            this.lblTotalConexion.Text = "Total por Conexion";
            // 
            // llblTotalEquipos
            // 
            this.llblTotalEquipos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.llblTotalEquipos.AutoSize = true;
            this.llblTotalEquipos.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.llblTotalEquipos.ForeColor = System.Drawing.Color.White;
            this.llblTotalEquipos.Location = new System.Drawing.Point(850, 5);
            this.llblTotalEquipos.Name = "llblTotalEquipos";
            this.llblTotalEquipos.Size = new System.Drawing.Size(158, 25);
            this.llblTotalEquipos.TabIndex = 79;
            this.llblTotalEquipos.Text = "Total por Equipos";
            // 
            // lblTotalServicios
            // 
            this.lblTotalServicios.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalServicios.AutoSize = true;
            this.lblTotalServicios.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.lblTotalServicios.ForeColor = System.Drawing.Color.White;
            this.lblTotalServicios.Location = new System.Drawing.Point(686, 5);
            this.lblTotalServicios.Name = "lblTotalServicios";
            this.lblTotalServicios.Size = new System.Drawing.Size(157, 25);
            this.lblTotalServicios.TabIndex = 77;
            this.lblTotalServicios.Text = "Total de Servicios";
            // 
            // txtTotalConexion
            // 
            this.txtTotalConexion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTotalConexion.BackColor = System.Drawing.Color.SlateGray;
            this.txtTotalConexion.BorderColor = System.Drawing.Color.Transparent;
            this.txtTotalConexion.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTotalConexion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTotalConexion.FocusColor = System.Drawing.Color.Empty;
            this.txtTotalConexion.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.txtTotalConexion.ForeColor = System.Drawing.Color.White;
            this.txtTotalConexion.Location = new System.Drawing.Point(1091, 30);
            this.txtTotalConexion.Name = "txtTotalConexion";
            this.txtTotalConexion.Numerico = true;
            this.txtTotalConexion.Size = new System.Drawing.Size(107, 25);
            this.txtTotalConexion.TabIndex = 80;
            this.txtTotalConexion.TabStop = false;
            this.txtTotalConexion.Tag = "\"\"";
            this.txtTotalConexion.Text = "0";
            this.txtTotalConexion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtTotalEquipamiento
            // 
            this.txtTotalEquipamiento.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTotalEquipamiento.BackColor = System.Drawing.Color.SlateGray;
            this.txtTotalEquipamiento.BorderColor = System.Drawing.Color.Transparent;
            this.txtTotalEquipamiento.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTotalEquipamiento.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTotalEquipamiento.FocusColor = System.Drawing.Color.Empty;
            this.txtTotalEquipamiento.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.txtTotalEquipamiento.ForeColor = System.Drawing.Color.White;
            this.txtTotalEquipamiento.Location = new System.Drawing.Point(892, 30);
            this.txtTotalEquipamiento.Name = "txtTotalEquipamiento";
            this.txtTotalEquipamiento.Numerico = true;
            this.txtTotalEquipamiento.Size = new System.Drawing.Size(107, 25);
            this.txtTotalEquipamiento.TabIndex = 78;
            this.txtTotalEquipamiento.TabStop = false;
            this.txtTotalEquipamiento.Tag = "\"\"";
            this.txtTotalEquipamiento.Text = "0";
            this.txtTotalEquipamiento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtTotalServicio
            // 
            this.txtTotalServicio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTotalServicio.BackColor = System.Drawing.Color.SlateGray;
            this.txtTotalServicio.BorderColor = System.Drawing.Color.Transparent;
            this.txtTotalServicio.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTotalServicio.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTotalServicio.FocusColor = System.Drawing.Color.Empty;
            this.txtTotalServicio.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.txtTotalServicio.ForeColor = System.Drawing.Color.White;
            this.txtTotalServicio.Location = new System.Drawing.Point(730, 30);
            this.txtTotalServicio.Name = "txtTotalServicio";
            this.txtTotalServicio.Numerico = true;
            this.txtTotalServicio.Size = new System.Drawing.Size(107, 25);
            this.txtTotalServicio.TabIndex = 76;
            this.txtTotalServicio.TabStop = false;
            this.txtTotalServicio.Tag = "\"\"";
            this.txtTotalServicio.Text = "0";
            this.txtTotalServicio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // pnlContratar
            // 
            this.pnlContratar.BackColor = System.Drawing.SystemColors.Control;
            this.pnlContratar.Controls.Add(this.boton1);
            this.pnlContratar.Controls.Add(this.btnConfirmar);
            this.pnlContratar.Controls.Add(this.label1);
            this.pnlContratar.Controls.Add(this.lblModalidad);
            this.pnlContratar.Controls.Add(this.cboTipoFacturacion);
            this.pnlContratar.Controls.Add(this.btnServicios);
            this.pnlContratar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlContratar.Location = new System.Drawing.Point(0, 0);
            this.pnlContratar.Name = "pnlContratar";
            this.pnlContratar.Size = new System.Drawing.Size(1386, 49);
            this.pnlContratar.TabIndex = 76;
            // 
            // boton1
            // 
            this.boton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.boton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(84)))), ((int)(((byte)(101)))));
            this.boton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.boton1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(84)))), ((int)(((byte)(101)))));
            this.boton1.FlatAppearance.BorderSize = 0;
            this.boton1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(84)))), ((int)(((byte)(101)))));
            this.boton1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            this.boton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.boton1.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.boton1.ForeColor = System.Drawing.Color.White;
            this.boton1.Image = global::CapaPresentacion.Properties.Resources.Command_Redo_32;
            this.boton1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.boton1.Location = new System.Drawing.Point(1109, 4);
            this.boton1.Name = "boton1";
            this.boton1.Size = new System.Drawing.Size(123, 35);
            this.boton1.TabIndex = 75;
            this.boton1.Text = "Cancelar";
            this.boton1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.boton1.UseVisualStyleBackColor = false;
            this.boton1.Click += new System.EventHandler(this.boton1_Click);
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConfirmar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(84)))), ((int)(((byte)(101)))));
            this.btnConfirmar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConfirmar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(84)))), ((int)(((byte)(101)))));
            this.btnConfirmar.FlatAppearance.BorderSize = 0;
            this.btnConfirmar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(84)))), ((int)(((byte)(101)))));
            this.btnConfirmar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            this.btnConfirmar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirmar.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.btnConfirmar.ForeColor = System.Drawing.Color.White;
            this.btnConfirmar.Image = global::CapaPresentacion.Properties.Resources.Save_32;
            this.btnConfirmar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnConfirmar.Location = new System.Drawing.Point(1238, 4);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(145, 35);
            this.btnConfirmar.TabIndex = 74;
            this.btnConfirmar.Text = "Confirmar";
            this.btnConfirmar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConfirmar.UseVisualStyleBackColor = false;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // cboTipoFacturacion
            // 
            this.cboTipoFacturacion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboTipoFacturacion.BorderColor = System.Drawing.Color.Gainsboro;
            this.cboTipoFacturacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoFacturacion.Enabled = false;
            this.cboTipoFacturacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboTipoFacturacion.Font = new System.Drawing.Font("Segoe UI", 13.75F);
            this.cboTipoFacturacion.FormattingEnabled = true;
            this.cboTipoFacturacion.Location = new System.Drawing.Point(649, 5);
            this.cboTipoFacturacion.Name = "cboTipoFacturacion";
            this.cboTipoFacturacion.Size = new System.Drawing.Size(284, 33);
            this.cboTipoFacturacion.TabIndex = 66;
            this.cboTipoFacturacion.SelectedValueChanged += new System.EventHandler(this.cboTipoFacturacion_SelectedValueChanged);
            // 
            // btnServicios
            // 
            this.btnServicios.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnServicios.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(84)))), ((int)(((byte)(101)))));
            this.btnServicios.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnServicios.Enabled = false;
            this.btnServicios.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(84)))), ((int)(((byte)(101)))));
            this.btnServicios.FlatAppearance.BorderSize = 0;
            this.btnServicios.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(84)))), ((int)(((byte)(101)))));
            this.btnServicios.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            this.btnServicios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnServicios.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.btnServicios.ForeColor = System.Drawing.Color.White;
            this.btnServicios.Image = global::CapaPresentacion.Properties.Resources.lupa;
            this.btnServicios.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnServicios.Location = new System.Drawing.Point(942, 4);
            this.btnServicios.Name = "btnServicios";
            this.btnServicios.Size = new System.Drawing.Size(161, 35);
            this.btnServicios.TabIndex = 70;
            this.btnServicios.Text = "Elegir Servicios";
            this.btnServicios.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnServicios.UseVisualStyleBackColor = false;
            this.btnServicios.Click += new System.EventHandler(this.btnServicios_Click);
            // 
            // spMain
            // 
            this.spMain.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.spMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spMain.Location = new System.Drawing.Point(0, 86);
            this.spMain.Name = "spMain";
            this.spMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // spMain.Panel1
            // 
            this.spMain.Panel1.Controls.Add(this.btnNuevo);
            this.spMain.Panel1.Controls.Add(this.dgvServiciosContratados);
            this.spMain.Panel1.Controls.Add(this.lblServiciosContratados);
            // 
            // spMain.Panel2
            // 
            this.spMain.Panel2.Controls.Add(this.dgvContrato);
            this.spMain.Panel2.Controls.Add(this.pnlContratar);
            this.spMain.Size = new System.Drawing.Size(1386, 501);
            this.spMain.SplitterDistance = 242;
            this.spMain.SplitterWidth = 7;
            this.spMain.TabIndex = 77;
            // 
            // btnNuevo
            // 
            this.btnNuevo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNuevo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(84)))), ((int)(((byte)(101)))));
            this.btnNuevo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNuevo.Enabled = false;
            this.btnNuevo.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(84)))), ((int)(((byte)(101)))));
            this.btnNuevo.FlatAppearance.BorderSize = 0;
            this.btnNuevo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(84)))), ((int)(((byte)(101)))));
            this.btnNuevo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            this.btnNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevo.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.btnNuevo.ForeColor = System.Drawing.Color.White;
            this.btnNuevo.Image = global::CapaPresentacion.Properties.Resources.lupa;
            this.btnNuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNuevo.Location = new System.Drawing.Point(1222, 3);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(161, 35);
            this.btnNuevo.TabIndex = 76;
            this.btnNuevo.Text = "Agregar servcio";
            this.btnNuevo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNuevo.UseVisualStyleBackColor = false;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // dgvServiciosContratados
            // 
            this.dgvServiciosContratados.AllowUserToAddRows = false;
            this.dgvServiciosContratados.AllowUserToDeleteRows = false;
            this.dgvServiciosContratados.AllowUserToOrderColumns = true;
            this.dgvServiciosContratados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvServiciosContratados.BackgroundColor = System.Drawing.Color.White;
            this.dgvServiciosContratados.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvServiciosContratados.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSlateGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 14F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvServiciosContratados.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvServiciosContratados.ColumnHeadersHeight = 40;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 14F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvServiciosContratados.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvServiciosContratados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvServiciosContratados.EnableHeadersVisualStyles = false;
            this.dgvServiciosContratados.GridColor = System.Drawing.Color.WhiteSmoke;
            this.dgvServiciosContratados.Location = new System.Drawing.Point(0, 49);
            this.dgvServiciosContratados.MultiSelect = false;
            this.dgvServiciosContratados.Name = "dgvServiciosContratados";
            this.dgvServiciosContratados.ReadOnly = true;
            this.dgvServiciosContratados.RowHeadersVisible = false;
            this.dgvServiciosContratados.RowHeadersWidth = 50;
            this.dgvServiciosContratados.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvServiciosContratados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvServiciosContratados.Size = new System.Drawing.Size(1386, 193);
            this.dgvServiciosContratados.TabIndex = 71;
            this.dgvServiciosContratados.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvServiciosContratados_CellClick);
            this.dgvServiciosContratados.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvServiciosContratados_CellFormatting);
            this.dgvServiciosContratados.SelectionChanged += new System.EventHandler(this.dgvServiciosContratados_SelectionChanged);
            // 
            // dgvContrato
            // 
            this.dgvContrato.AllowUserToAddRows = false;
            this.dgvContrato.AllowUserToDeleteRows = false;
            this.dgvContrato.AllowUserToOrderColumns = true;
            this.dgvContrato.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvContrato.BackgroundColor = System.Drawing.Color.White;
            this.dgvContrato.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvContrato.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.LightSlateGray;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 14F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvContrato.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvContrato.ColumnHeadersHeight = 40;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 14F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvContrato.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvContrato.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvContrato.EnableHeadersVisualStyles = false;
            this.dgvContrato.GridColor = System.Drawing.Color.WhiteSmoke;
            this.dgvContrato.Location = new System.Drawing.Point(0, 49);
            this.dgvContrato.MultiSelect = false;
            this.dgvContrato.Name = "dgvContrato";
            this.dgvContrato.ReadOnly = true;
            this.dgvContrato.RowHeadersVisible = false;
            this.dgvContrato.RowHeadersWidth = 50;
            this.dgvContrato.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvContrato.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvContrato.Size = new System.Drawing.Size(1386, 203);
            this.dgvContrato.TabIndex = 74;
            this.dgvContrato.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvContrato_CellValueChanged);
            // 
            // pnlHead
            // 
            this.pnlHead.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.pnlHead.Controls.Add(this.imgReturn);
            this.pnlHead.Controls.Add(this.lblTitulo);
            this.pnlHead.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHead.Location = new System.Drawing.Point(0, 0);
            this.pnlHead.Name = "pnlHead";
            this.pnlHead.Size = new System.Drawing.Size(1386, 86);
            this.pnlHead.TabIndex = 78;
            // 
            // imgReturn
            // 
            this.imgReturn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.imgReturn.Image = global::CapaPresentacion.Properties.Resources.Left_Arrow_32;
            this.imgReturn.Location = new System.Drawing.Point(9, 24);
            this.imgReturn.Name = "imgReturn";
            this.imgReturn.Size = new System.Drawing.Size(32, 32);
            this.imgReturn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgReturn.TabIndex = 205;
            this.imgReturn.TabStop = false;
            this.imgReturn.Click += new System.EventHandler(this.imgReturn_Click);
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Calibri", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(47, 22);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(236, 36);
            this.lblTitulo.TabIndex = 204;
            this.lblTitulo.Text = "Cambio de servicio";
            // 
            // frmCambioServicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1386, 647);
            this.Controls.Add(this.spMain);
            this.Controls.Add(this.pnlHead);
            this.Controls.Add(this.panel11);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmCambioServicio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmCambioServicio";
            this.Load += new System.EventHandler(this.frmCambioServicio_Load);
            this.panel11.ResumeLayout(false);
            this.panel11.PerformLayout();
            this.pnlContratar.ResumeLayout(false);
            this.pnlContratar.PerformLayout();
            this.spMain.Panel1.ResumeLayout(false);
            this.spMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spMain)).EndInit();
            this.spMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvServiciosContratados)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvContrato)).EndInit();
            this.pnlHead.ResumeLayout(false);
            this.pnlHead.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgReturn)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblModalidad;
        private Controles.combo cboTipoFacturacion;
        private Controles.boton btnServicios;
        private System.Windows.Forms.Label lblServiciosContratados;
        private System.Windows.Forms.Label label1;
        private Controles.dgv dgvContrato;
        private System.Windows.Forms.Panel panel11;
        private textboxAdv txtTotal;
        private System.Windows.Forms.Label lbTotal;
        private System.Windows.Forms.Label lblTotalConexion;
        private System.Windows.Forms.Label llblTotalEquipos;
        private System.Windows.Forms.Label lblTotalServicios;
        private textboxAdv txtTotalConexion;
        private textboxAdv txtTotalEquipamiento;
        private textboxAdv txtTotalServicio;
        private System.Windows.Forms.Panel pnlContratar;
        private System.Windows.Forms.SplitContainer spMain;
        private System.Windows.Forms.Panel pnlHead;
        private System.Windows.Forms.PictureBox imgReturn;
        private System.Windows.Forms.Label lblTitulo;
        private Controles.boton btnConfirmar;
        private Controles.dgv dgvServiciosContratados;
        private Controles.boton boton1;
        private Controles.boton btnNuevo;
    }
}