
namespace CapaPresentacion.Complementarias
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnLinea1 = new System.Windows.Forms.Panel();
            this.gbFiltroModalidad = new System.Windows.Forms.GroupBox();
            this.rbTodasModalidad = new System.Windows.Forms.RadioButton();
            this.rbMismaModalidad = new System.Windows.Forms.RadioButton();
            this.LbTitulos = new System.Windows.Forms.Label();
            this.imgReturn = new System.Windows.Forms.PictureBox();
            this.gbFiltroServicio = new System.Windows.Forms.GroupBox();
            this.rbGrupoServicio = new System.Windows.Forms.RadioButton();
            this.rbTipoServicio = new System.Windows.Forms.RadioButton();
            this.lblPartesAbiertos = new System.Windows.Forms.Label();
            this.lblEquipos = new System.Windows.Forms.Label();
            this.lblEstadoServActual = new System.Windows.Forms.Label();
            this.lblNoTieneEquipos = new System.Windows.Forms.Label();
            this.lblAsignado = new System.Windows.Forms.Label();
            this.lblPendienteAsignacion = new System.Windows.Forms.Label();
            this.lblPlasticos = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTipoServActual = new System.Windows.Forms.Label();
            this.lblServicioActual = new System.Windows.Forms.Label();
            this.lblPresentaDeuda = new System.Windows.Forms.Label();
            this.lblFechaFacturado = new System.Windows.Forms.Label();
            this.lblISP = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblSubInactivos = new System.Windows.Forms.Label();
            this.dgvSubServiciosActuales = new CapaPresentacion.Controles.dgv(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.Lbl_PresentaDeuda = new System.Windows.Forms.Label();
            this.LblAsociadoAppExterna = new System.Windows.Forms.Label();
            this.Lbl_PartesAbiertos = new System.Windows.Forms.Label();
            this.LblPlasticoAsociado = new System.Windows.Forms.Label();
            this.LblEstadoServ = new System.Windows.Forms.Label();
            this.dgvEquipos = new CapaPresentacion.Controles.dgv(this.components);
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cboParteFalla = new CapaPresentacion.Controles.combo(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.btnCambiar = new CapaPresentacion.Controles.boton();
            this.dgvSeleccionDeSubServicios = new CapaPresentacion.Controles.dgv(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.cboServicios = new CapaPresentacion.Controles.combo(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.pnLinea1.SuspendLayout();
            this.gbFiltroModalidad.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgReturn)).BeginInit();
            this.gbFiltroServicio.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSubServiciosActuales)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEquipos)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSeleccionDeSubServicios)).BeginInit();
            this.SuspendLayout();
            // 
            // pnLinea1
            // 
            this.pnLinea1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.pnLinea1.Controls.Add(this.gbFiltroModalidad);
            this.pnLinea1.Controls.Add(this.LbTitulos);
            this.pnLinea1.Controls.Add(this.imgReturn);
            this.pnLinea1.Controls.Add(this.gbFiltroServicio);
            this.pnLinea1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnLinea1.Location = new System.Drawing.Point(0, 0);
            this.pnLinea1.Name = "pnLinea1";
            this.pnLinea1.Size = new System.Drawing.Size(1351, 83);
            this.pnLinea1.TabIndex = 200;
            // 
            // gbFiltroModalidad
            // 
            this.gbFiltroModalidad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gbFiltroModalidad.Controls.Add(this.rbTodasModalidad);
            this.gbFiltroModalidad.Controls.Add(this.rbMismaModalidad);
            this.gbFiltroModalidad.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbFiltroModalidad.ForeColor = System.Drawing.SystemColors.Control;
            this.gbFiltroModalidad.Location = new System.Drawing.Point(1168, 12);
            this.gbFiltroModalidad.Name = "gbFiltroModalidad";
            this.gbFiltroModalidad.Size = new System.Drawing.Size(155, 51);
            this.gbFiltroModalidad.TabIndex = 223;
            this.gbFiltroModalidad.TabStop = false;
            this.gbFiltroModalidad.Text = "Modalidad";
            this.gbFiltroModalidad.Visible = false;
            // 
            // rbTodasModalidad
            // 
            this.rbTodasModalidad.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rbTodasModalidad.AutoSize = true;
            this.rbTodasModalidad.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbTodasModalidad.ForeColor = System.Drawing.SystemColors.Control;
            this.rbTodasModalidad.Location = new System.Drawing.Point(87, 20);
            this.rbTodasModalidad.Name = "rbTodasModalidad";
            this.rbTodasModalidad.Size = new System.Drawing.Size(61, 21);
            this.rbTodasModalidad.TabIndex = 222;
            this.rbTodasModalidad.Text = "Todas";
            this.rbTodasModalidad.UseVisualStyleBackColor = true;
            this.rbTodasModalidad.CheckedChanged += new System.EventHandler(this.rbModalidad_CheckedChanged);
            // 
            // rbMismaModalidad
            // 
            this.rbMismaModalidad.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rbMismaModalidad.AutoSize = true;
            this.rbMismaModalidad.Checked = true;
            this.rbMismaModalidad.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbMismaModalidad.ForeColor = System.Drawing.SystemColors.Control;
            this.rbMismaModalidad.Location = new System.Drawing.Point(15, 20);
            this.rbMismaModalidad.Name = "rbMismaModalidad";
            this.rbMismaModalidad.Size = new System.Drawing.Size(65, 21);
            this.rbMismaModalidad.TabIndex = 221;
            this.rbMismaModalidad.TabStop = true;
            this.rbMismaModalidad.Text = "Misma";
            this.rbMismaModalidad.UseVisualStyleBackColor = true;
            this.rbMismaModalidad.CheckedChanged += new System.EventHandler(this.rbModalidad_CheckedChanged);
            // 
            // LbTitulos
            // 
            this.LbTitulos.AutoSize = true;
            this.LbTitulos.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LbTitulos.ForeColor = System.Drawing.Color.Transparent;
            this.LbTitulos.Location = new System.Drawing.Point(53, 29);
            this.LbTitulos.Name = "LbTitulos";
            this.LbTitulos.Size = new System.Drawing.Size(172, 25);
            this.LbTitulos.TabIndex = 172;
            this.LbTitulos.Text = "Cambio de servicio";
            // 
            // imgReturn
            // 
            this.imgReturn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.imgReturn.Image = global::CapaPresentacion.Properties.Resources.Left_Arrow_32;
            this.imgReturn.Location = new System.Drawing.Point(11, 25);
            this.imgReturn.Name = "imgReturn";
            this.imgReturn.Size = new System.Drawing.Size(32, 32);
            this.imgReturn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgReturn.TabIndex = 76;
            this.imgReturn.TabStop = false;
            this.imgReturn.Click += new System.EventHandler(this.imgReturn_Click);
            // 
            // gbFiltroServicio
            // 
            this.gbFiltroServicio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gbFiltroServicio.Controls.Add(this.rbGrupoServicio);
            this.gbFiltroServicio.Controls.Add(this.rbTipoServicio);
            this.gbFiltroServicio.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbFiltroServicio.ForeColor = System.Drawing.SystemColors.Control;
            this.gbFiltroServicio.Location = new System.Drawing.Point(1018, 12);
            this.gbFiltroServicio.Name = "gbFiltroServicio";
            this.gbFiltroServicio.Size = new System.Drawing.Size(141, 51);
            this.gbFiltroServicio.TabIndex = 222;
            this.gbFiltroServicio.TabStop = false;
            this.gbFiltroServicio.Text = "Servicio";
            this.gbFiltroServicio.Visible = false;
            // 
            // rbGrupoServicio
            // 
            this.rbGrupoServicio.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rbGrupoServicio.AutoSize = true;
            this.rbGrupoServicio.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbGrupoServicio.ForeColor = System.Drawing.SystemColors.Control;
            this.rbGrupoServicio.Location = new System.Drawing.Point(68, 20);
            this.rbGrupoServicio.Name = "rbGrupoServicio";
            this.rbGrupoServicio.Size = new System.Drawing.Size(63, 21);
            this.rbGrupoServicio.TabIndex = 222;
            this.rbGrupoServicio.Text = "Grupo";
            this.rbGrupoServicio.UseVisualStyleBackColor = true;
            this.rbGrupoServicio.CheckedChanged += new System.EventHandler(this.rb_CheckedChanged);
            // 
            // rbTipoServicio
            // 
            this.rbTipoServicio.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rbTipoServicio.AutoSize = true;
            this.rbTipoServicio.Checked = true;
            this.rbTipoServicio.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbTipoServicio.ForeColor = System.Drawing.SystemColors.Control;
            this.rbTipoServicio.Location = new System.Drawing.Point(10, 20);
            this.rbTipoServicio.Name = "rbTipoServicio";
            this.rbTipoServicio.Size = new System.Drawing.Size(52, 21);
            this.rbTipoServicio.TabIndex = 221;
            this.rbTipoServicio.TabStop = true;
            this.rbTipoServicio.Text = "Tipo";
            this.rbTipoServicio.UseVisualStyleBackColor = true;
            this.rbTipoServicio.CheckedChanged += new System.EventHandler(this.rb_CheckedChanged);
            // 
            // lblPartesAbiertos
            // 
            this.lblPartesAbiertos.AutoSize = true;
            this.lblPartesAbiertos.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPartesAbiertos.ForeColor = System.Drawing.Color.Black;
            this.lblPartesAbiertos.Location = new System.Drawing.Point(65, 112);
            this.lblPartesAbiertos.Name = "lblPartesAbiertos";
            this.lblPartesAbiertos.Size = new System.Drawing.Size(234, 21);
            this.lblPartesAbiertos.TabIndex = 201;
            this.lblPartesAbiertos.Text = "El usuario tiene partes abiertos";
            // 
            // lblEquipos
            // 
            this.lblEquipos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblEquipos.AutoSize = true;
            this.lblEquipos.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEquipos.ForeColor = System.Drawing.Color.Black;
            this.lblEquipos.Location = new System.Drawing.Point(543, 30);
            this.lblEquipos.Name = "lblEquipos";
            this.lblEquipos.Size = new System.Drawing.Size(121, 17);
            this.lblEquipos.TabIndex = 202;
            this.lblEquipos.Text = "Equipos asignados";
            // 
            // lblEstadoServActual
            // 
            this.lblEstadoServActual.AutoSize = true;
            this.lblEstadoServActual.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstadoServActual.ForeColor = System.Drawing.Color.Black;
            this.lblEstadoServActual.Location = new System.Drawing.Point(65, 32);
            this.lblEstadoServActual.Name = "lblEstadoServActual";
            this.lblEstadoServActual.Size = new System.Drawing.Size(167, 21);
            this.lblEstadoServActual.TabIndex = 204;
            this.lblEstadoServActual.Text = "Estado servicio actual";
            // 
            // lblNoTieneEquipos
            // 
            this.lblNoTieneEquipos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblNoTieneEquipos.AutoSize = true;
            this.lblNoTieneEquipos.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoTieneEquipos.ForeColor = System.Drawing.Color.Black;
            this.lblNoTieneEquipos.Location = new System.Drawing.Point(659, 30);
            this.lblNoTieneEquipos.Name = "lblNoTieneEquipos";
            this.lblNoTieneEquipos.Size = new System.Drawing.Size(212, 17);
            this.lblNoTieneEquipos.TabIndex = 205;
            this.lblNoTieneEquipos.Text = "(No tiene ningun equipo asignado)";
            this.lblNoTieneEquipos.Visible = false;
            // 
            // lblAsignado
            // 
            this.lblAsignado.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblAsignado.AutoSize = true;
            this.lblAsignado.BackColor = System.Drawing.Color.LimeGreen;
            this.lblAsignado.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAsignado.ForeColor = System.Drawing.Color.Black;
            this.lblAsignado.Location = new System.Drawing.Point(543, 239);
            this.lblAsignado.Name = "lblAsignado";
            this.lblAsignado.Size = new System.Drawing.Size(63, 17);
            this.lblAsignado.TabIndex = 206;
            this.lblAsignado.Text = "Asignado";
            // 
            // lblPendienteAsignacion
            // 
            this.lblPendienteAsignacion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblPendienteAsignacion.AutoSize = true;
            this.lblPendienteAsignacion.BackColor = System.Drawing.Color.Tomato;
            this.lblPendienteAsignacion.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPendienteAsignacion.ForeColor = System.Drawing.Color.Black;
            this.lblPendienteAsignacion.Location = new System.Drawing.Point(616, 240);
            this.lblPendienteAsignacion.Name = "lblPendienteAsignacion";
            this.lblPendienteAsignacion.Size = new System.Drawing.Size(150, 17);
            this.lblPendienteAsignacion.TabIndex = 207;
            this.lblPendienteAsignacion.Text = "Pendiente de asignacion";
            // 
            // lblPlasticos
            // 
            this.lblPlasticos.AutoSize = true;
            this.lblPlasticos.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlasticos.ForeColor = System.Drawing.Color.Black;
            this.lblPlasticos.Location = new System.Drawing.Point(65, 72);
            this.lblPlasticos.Name = "lblPlasticos";
            this.lblPlasticos.Size = new System.Drawing.Size(149, 21);
            this.lblPlasticos.TabIndex = 208;
            this.lblPlasticos.Text = "Plasticos asociados";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(16, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(169, 21);
            this.label1.TabIndex = 210;
            this.label1.Text = "Subservicios asociados";
            // 
            // lblTipoServActual
            // 
            this.lblTipoServActual.AutoSize = true;
            this.lblTipoServActual.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipoServActual.ForeColor = System.Drawing.Color.Black;
            this.lblTipoServActual.Location = new System.Drawing.Point(16, 29);
            this.lblTipoServActual.Name = "lblTipoServActual";
            this.lblTipoServActual.Size = new System.Drawing.Size(170, 21);
            this.lblTipoServActual.TabIndex = 211;
            this.lblTipoServActual.Text = "Tipo de servicio origen:";
            // 
            // lblServicioActual
            // 
            this.lblServicioActual.AutoSize = true;
            this.lblServicioActual.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblServicioActual.ForeColor = System.Drawing.Color.Black;
            this.lblServicioActual.Location = new System.Drawing.Point(16, 57);
            this.lblServicioActual.Name = "lblServicioActual";
            this.lblServicioActual.Size = new System.Drawing.Size(113, 21);
            this.lblServicioActual.TabIndex = 212;
            this.lblServicioActual.Text = "Servicio actual:";
            // 
            // lblPresentaDeuda
            // 
            this.lblPresentaDeuda.AutoSize = true;
            this.lblPresentaDeuda.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPresentaDeuda.ForeColor = System.Drawing.Color.Black;
            this.lblPresentaDeuda.Location = new System.Drawing.Point(65, 192);
            this.lblPresentaDeuda.Name = "lblPresentaDeuda";
            this.lblPresentaDeuda.Size = new System.Drawing.Size(57, 21);
            this.lblPresentaDeuda.TabIndex = 213;
            this.lblPresentaDeuda.Text = "Deuda";
            // 
            // lblFechaFacturado
            // 
            this.lblFechaFacturado.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblFechaFacturado.AutoSize = true;
            this.lblFechaFacturado.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaFacturado.ForeColor = System.Drawing.Color.Black;
            this.lblFechaFacturado.Location = new System.Drawing.Point(65, 232);
            this.lblFechaFacturado.Name = "lblFechaFacturado";
            this.lblFechaFacturado.Size = new System.Drawing.Size(128, 21);
            this.lblFechaFacturado.TabIndex = 214;
            this.lblFechaFacturado.Text = "Facturado hasta:";
            // 
            // lblISP
            // 
            this.lblISP.AutoSize = true;
            this.lblISP.BackColor = System.Drawing.Color.Transparent;
            this.lblISP.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblISP.ForeColor = System.Drawing.Color.Black;
            this.lblISP.Location = new System.Drawing.Point(65, 152);
            this.lblISP.Name = "lblISP";
            this.lblISP.Size = new System.Drawing.Size(226, 21);
            this.lblISP.TabIndex = 215;
            this.lblISP.Text = "Asociado a aplicacion externa";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblSubInactivos);
            this.groupBox1.Controls.Add(this.dgvSubServiciosActuales);
            this.groupBox1.Controls.Add(this.lblTipoServActual);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lblServicioActual);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(17, 86);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(618, 258);
            this.groupBox1.TabIndex = 217;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos servicio origen";
            // 
            // lblSubInactivos
            // 
            this.lblSubInactivos.AutoSize = true;
            this.lblSubInactivos.BackColor = System.Drawing.Color.LightGray;
            this.lblSubInactivos.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubInactivos.ForeColor = System.Drawing.Color.DimGray;
            this.lblSubInactivos.Location = new System.Drawing.Point(432, 85);
            this.lblSubInactivos.Name = "lblSubInactivos";
            this.lblSubInactivos.Size = new System.Drawing.Size(162, 21);
            this.lblSubInactivos.TabIndex = 224;
            this.lblSubInactivos.Text = "Subservicios inactivos";
            // 
            // dgvSubServiciosActuales
            // 
            this.dgvSubServiciosActuales.AllowUserToAddRows = false;
            this.dgvSubServiciosActuales.AllowUserToDeleteRows = false;
            this.dgvSubServiciosActuales.AllowUserToOrderColumns = true;
            this.dgvSubServiciosActuales.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSubServiciosActuales.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSubServiciosActuales.BackgroundColor = System.Drawing.Color.White;
            this.dgvSubServiciosActuales.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvSubServiciosActuales.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.LightSlateGray;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSubServiciosActuales.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvSubServiciosActuales.ColumnHeadersHeight = 40;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSubServiciosActuales.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgvSubServiciosActuales.EnableHeadersVisualStyles = false;
            this.dgvSubServiciosActuales.GridColor = System.Drawing.Color.WhiteSmoke;
            this.dgvSubServiciosActuales.Location = new System.Drawing.Point(19, 114);
            this.dgvSubServiciosActuales.MultiSelect = false;
            this.dgvSubServiciosActuales.Name = "dgvSubServiciosActuales";
            this.dgvSubServiciosActuales.ReadOnly = true;
            this.dgvSubServiciosActuales.RowHeadersVisible = false;
            this.dgvSubServiciosActuales.RowHeadersWidth = 50;
            this.dgvSubServiciosActuales.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvSubServiciosActuales.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSubServiciosActuales.Size = new System.Drawing.Size(579, 129);
            this.dgvSubServiciosActuales.TabIndex = 218;
            this.dgvSubServiciosActuales.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvSubServiciosActuales_CellFormatting);
            this.dgvSubServiciosActuales.SelectionChanged += new System.EventHandler(this.dgvEquipos_SelectionChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.Lbl_PresentaDeuda);
            this.groupBox2.Controls.Add(this.LblAsociadoAppExterna);
            this.groupBox2.Controls.Add(this.Lbl_PartesAbiertos);
            this.groupBox2.Controls.Add(this.LblPlasticoAsociado);
            this.groupBox2.Controls.Add(this.LblEstadoServ);
            this.groupBox2.Controls.Add(this.dgvEquipos);
            this.groupBox2.Controls.Add(this.lblPlasticos);
            this.groupBox2.Controls.Add(this.lblNoTieneEquipos);
            this.groupBox2.Controls.Add(this.lblFechaFacturado);
            this.groupBox2.Controls.Add(this.lblEquipos);
            this.groupBox2.Controls.Add(this.lblPendienteAsignacion);
            this.groupBox2.Controls.Add(this.lblPartesAbiertos);
            this.groupBox2.Controls.Add(this.lblAsignado);
            this.groupBox2.Controls.Add(this.lblPresentaDeuda);
            this.groupBox2.Controls.Add(this.lblEstadoServActual);
            this.groupBox2.Controls.Add(this.lblISP);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.groupBox2.Location = new System.Drawing.Point(17, 386);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1318, 267);
            this.groupBox2.TabIndex = 218;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Condiciones";
            // 
            // Lbl_PresentaDeuda
            // 
            this.Lbl_PresentaDeuda.AutoSize = true;
            this.Lbl_PresentaDeuda.Font = new System.Drawing.Font("Webdings", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.Lbl_PresentaDeuda.ForeColor = System.Drawing.Color.Green;
            this.Lbl_PresentaDeuda.Location = new System.Drawing.Point(9, 187);
            this.Lbl_PresentaDeuda.Name = "Lbl_PresentaDeuda";
            this.Lbl_PresentaDeuda.Size = new System.Drawing.Size(49, 34);
            this.Lbl_PresentaDeuda.TabIndex = 231;
            this.Lbl_PresentaDeuda.Text = "a";
            // 
            // LblAsociadoAppExterna
            // 
            this.LblAsociadoAppExterna.AutoSize = true;
            this.LblAsociadoAppExterna.Font = new System.Drawing.Font("Webdings", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.LblAsociadoAppExterna.ForeColor = System.Drawing.Color.Green;
            this.LblAsociadoAppExterna.Location = new System.Drawing.Point(10, 147);
            this.LblAsociadoAppExterna.Name = "LblAsociadoAppExterna";
            this.LblAsociadoAppExterna.Size = new System.Drawing.Size(49, 34);
            this.LblAsociadoAppExterna.TabIndex = 230;
            this.LblAsociadoAppExterna.Text = "a";
            // 
            // Lbl_PartesAbiertos
            // 
            this.Lbl_PartesAbiertos.AutoSize = true;
            this.Lbl_PartesAbiertos.Font = new System.Drawing.Font("Webdings", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.Lbl_PartesAbiertos.ForeColor = System.Drawing.Color.Green;
            this.Lbl_PartesAbiertos.Location = new System.Drawing.Point(10, 107);
            this.Lbl_PartesAbiertos.Name = "Lbl_PartesAbiertos";
            this.Lbl_PartesAbiertos.Size = new System.Drawing.Size(49, 34);
            this.Lbl_PartesAbiertos.TabIndex = 229;
            this.Lbl_PartesAbiertos.Text = "a";
            // 
            // LblPlasticoAsociado
            // 
            this.LblPlasticoAsociado.AutoSize = true;
            this.LblPlasticoAsociado.Font = new System.Drawing.Font("Webdings", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.LblPlasticoAsociado.ForeColor = System.Drawing.Color.Green;
            this.LblPlasticoAsociado.Location = new System.Drawing.Point(10, 67);
            this.LblPlasticoAsociado.Name = "LblPlasticoAsociado";
            this.LblPlasticoAsociado.Size = new System.Drawing.Size(49, 34);
            this.LblPlasticoAsociado.TabIndex = 228;
            this.LblPlasticoAsociado.Text = "a";
            // 
            // LblEstadoServ
            // 
            this.LblEstadoServ.AutoSize = true;
            this.LblEstadoServ.Font = new System.Drawing.Font("Webdings", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.LblEstadoServ.ForeColor = System.Drawing.Color.Green;
            this.LblEstadoServ.Location = new System.Drawing.Point(10, 27);
            this.LblEstadoServ.Name = "LblEstadoServ";
            this.LblEstadoServ.Size = new System.Drawing.Size(49, 34);
            this.LblEstadoServ.TabIndex = 226;
            this.LblEstadoServ.Text = "a";
            // 
            // dgvEquipos
            // 
            this.dgvEquipos.AllowUserToAddRows = false;
            this.dgvEquipos.AllowUserToDeleteRows = false;
            this.dgvEquipos.AllowUserToOrderColumns = true;
            this.dgvEquipos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvEquipos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvEquipos.BackgroundColor = System.Drawing.Color.White;
            this.dgvEquipos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvEquipos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.LightSlateGray;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvEquipos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvEquipos.ColumnHeadersHeight = 40;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvEquipos.DefaultCellStyle = dataGridViewCellStyle10;
            this.dgvEquipos.EnableHeadersVisualStyles = false;
            this.dgvEquipos.GridColor = System.Drawing.Color.WhiteSmoke;
            this.dgvEquipos.Location = new System.Drawing.Point(540, 50);
            this.dgvEquipos.MultiSelect = false;
            this.dgvEquipos.Name = "dgvEquipos";
            this.dgvEquipos.ReadOnly = true;
            this.dgvEquipos.RowHeadersVisible = false;
            this.dgvEquipos.RowHeadersWidth = 50;
            this.dgvEquipos.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvEquipos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEquipos.Size = new System.Drawing.Size(766, 176);
            this.dgvEquipos.TabIndex = 219;
            this.dgvEquipos.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvEquipos_CellFormatting);
            this.dgvEquipos.SelectionChanged += new System.EventHandler(this.dgvEquipos_SelectionChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.cboParteFalla);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.btnCambiar);
            this.groupBox3.Controls.Add(this.dgvSeleccionDeSubServicios);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.cboServicios);
            this.groupBox3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.groupBox3.Location = new System.Drawing.Point(653, 86);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(682, 258);
            this.groupBox3.TabIndex = 219;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Seleccion de nuevo servicio";
            // 
            // cboParteFalla
            // 
            this.cboParteFalla.BorderColor = System.Drawing.Color.Gainsboro;
            this.cboParteFalla.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboParteFalla.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboParteFalla.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cboParteFalla.FormattingEnabled = true;
            this.cboParteFalla.Location = new System.Drawing.Point(109, 31);
            this.cboParteFalla.Name = "cboParteFalla";
            this.cboParteFalla.Size = new System.Drawing.Size(392, 29);
            this.cboParteFalla.TabIndex = 224;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(22, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 21);
            this.label3.TabIndex = 223;
            this.label3.Text = "Motivo:";
            // 
            // btnCambiar
            // 
            this.btnCambiar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCambiar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnCambiar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCambiar.Enabled = false;
            this.btnCambiar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnCambiar.FlatAppearance.BorderSize = 0;
            this.btnCambiar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnCambiar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnCambiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCambiar.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnCambiar.ForeColor = System.Drawing.Color.White;
            this.btnCambiar.Image = global::CapaPresentacion.Properties.Resources.Data_Edit_32;
            this.btnCambiar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCambiar.Location = new System.Drawing.Point(522, 68);
            this.btnCambiar.Name = "btnCambiar";
            this.btnCambiar.Size = new System.Drawing.Size(136, 34);
            this.btnCambiar.TabIndex = 220;
            this.btnCambiar.Text = "Cambiar";
            this.btnCambiar.UseVisualStyleBackColor = false;
            this.btnCambiar.Click += new System.EventHandler(this.btnCambiar_Click);
            // 
            // dgvSeleccionDeSubServicios
            // 
            this.dgvSeleccionDeSubServicios.AllowUserToAddRows = false;
            this.dgvSeleccionDeSubServicios.AllowUserToDeleteRows = false;
            this.dgvSeleccionDeSubServicios.AllowUserToOrderColumns = true;
            this.dgvSeleccionDeSubServicios.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSeleccionDeSubServicios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSeleccionDeSubServicios.BackgroundColor = System.Drawing.Color.White;
            this.dgvSeleccionDeSubServicios.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvSeleccionDeSubServicios.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.LightSlateGray;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSeleccionDeSubServicios.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.dgvSeleccionDeSubServicios.ColumnHeadersHeight = 40;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle12.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSeleccionDeSubServicios.DefaultCellStyle = dataGridViewCellStyle12;
            this.dgvSeleccionDeSubServicios.EnableHeadersVisualStyles = false;
            this.dgvSeleccionDeSubServicios.GridColor = System.Drawing.Color.WhiteSmoke;
            this.dgvSeleccionDeSubServicios.Location = new System.Drawing.Point(26, 114);
            this.dgvSeleccionDeSubServicios.MultiSelect = false;
            this.dgvSeleccionDeSubServicios.Name = "dgvSeleccionDeSubServicios";
            this.dgvSeleccionDeSubServicios.ReadOnly = true;
            this.dgvSeleccionDeSubServicios.RowHeadersVisible = false;
            this.dgvSeleccionDeSubServicios.RowHeadersWidth = 50;
            this.dgvSeleccionDeSubServicios.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvSeleccionDeSubServicios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSeleccionDeSubServicios.Size = new System.Drawing.Size(632, 129);
            this.dgvSeleccionDeSubServicios.TabIndex = 219;
            this.dgvSeleccionDeSubServicios.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSeleccionDeSubServicios_CellContentClick);
            this.dgvSeleccionDeSubServicios.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvSubServiciosActuales_CellFormatting);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(22, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 21);
            this.label2.TabIndex = 215;
            this.label2.Text = "Servicios:";
            // 
            // cboServicios
            // 
            this.cboServicios.BorderColor = System.Drawing.Color.Gainsboro;
            this.cboServicios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboServicios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboServicios.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cboServicios.FormattingEnabled = true;
            this.cboServicios.Location = new System.Drawing.Point(109, 72);
            this.cboServicios.Name = "cboServicios";
            this.cboServicios.Size = new System.Drawing.Size(392, 29);
            this.cboServicios.TabIndex = 170;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.MediumAquamarine;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(285, 349);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 21);
            this.label4.TabIndex = 220;
            this.label4.Text = "Subservicio";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.CornflowerBlue;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(392, 349);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(116, 21);
            this.label5.TabIndex = 221;
            this.label5.Text = "Mantenimiento";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Coral;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(525, 349);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(116, 21);
            this.label6.TabIndex = 222;
            this.label6.Text = "Costo adicional";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Silver;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(658, 349);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(155, 21);
            this.label7.TabIndex = 223;
            this.label7.Text = "Derecho de conexion";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(20, 349);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(259, 21);
            this.label8.TabIndex = 224;
            this.label8.Text = "Referencias de tipo de subservicios: ";
            // 
            // frmCambioServicio
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1351, 665);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pnLinea1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "frmCambioServicio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmCambioServicio";
            this.Load += new System.EventHandler(this.frmCambioServicio_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmCambioServicio_KeyDown);
            this.pnLinea1.ResumeLayout(false);
            this.pnLinea1.PerformLayout();
            this.gbFiltroModalidad.ResumeLayout(false);
            this.gbFiltroModalidad.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgReturn)).EndInit();
            this.gbFiltroServicio.ResumeLayout(false);
            this.gbFiltroServicio.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSubServiciosActuales)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEquipos)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSeleccionDeSubServicios)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnLinea1;
        private System.Windows.Forms.Label LbTitulos;
        private System.Windows.Forms.PictureBox imgReturn;
        private System.Windows.Forms.Label lblPartesAbiertos;
        private System.Windows.Forms.Label lblEquipos;
        private System.Windows.Forms.Label lblEstadoServActual;
        private System.Windows.Forms.Label lblNoTieneEquipos;
        private System.Windows.Forms.Label lblAsignado;
        private System.Windows.Forms.Label lblPendienteAsignacion;
        private System.Windows.Forms.Label lblPlasticos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTipoServActual;
        private System.Windows.Forms.Label lblServicioActual;
        private System.Windows.Forms.Label lblPresentaDeuda;
        private System.Windows.Forms.Label lblFechaFacturado;
        private System.Windows.Forms.Label lblISP;
        private System.Windows.Forms.GroupBox groupBox1;
        private Controles.dgv dgvSubServiciosActuales;
        private System.Windows.Forms.GroupBox groupBox2;
        private Controles.dgv dgvEquipos;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label2;
        private Controles.combo cboServicios;
        private Controles.dgv dgvSeleccionDeSubServicios;
        private Controles.boton btnCambiar;
        private System.Windows.Forms.RadioButton rbTipoServicio;
        private System.Windows.Forms.GroupBox gbFiltroServicio;
        private System.Windows.Forms.RadioButton rbGrupoServicio;
        private Controles.combo cboParteFalla;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox gbFiltroModalidad;
        private System.Windows.Forms.RadioButton rbTodasModalidad;
        private System.Windows.Forms.RadioButton rbMismaModalidad;
        private System.Windows.Forms.Label lblSubInactivos;
        private System.Windows.Forms.Label LblEstadoServ;
        private System.Windows.Forms.Label Lbl_PresentaDeuda;
        private System.Windows.Forms.Label LblAsociadoAppExterna;
        private System.Windows.Forms.Label Lbl_PartesAbiertos;
        private System.Windows.Forms.Label LblPlasticoAsociado;
    }
}