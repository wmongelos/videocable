namespace CapaPresentacion.Partes_Trabajo
{
    partial class frmConfirmaParte
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
            this.label6 = new System.Windows.Forms.Label();
            this.lblFechaConfirmacion = new System.Windows.Forms.Label();
            this.lblSolicitud = new System.Windows.Forms.Label();
            this.lblFechaReclamo = new System.Windows.Forms.Label();
            this.lblSolucion = new System.Windows.Forms.Label();
            this.lblProblema = new System.Windows.Forms.Label();
            this.lblObservacion = new System.Windows.Forms.Label();
            this.lblTecnicoNuevo = new System.Windows.Forms.Label();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.lblEntreCalles = new System.Windows.Forms.Label();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.lblDomicilio = new System.Windows.Forms.Label();
            this.lblLocalidad = new System.Windows.Forms.Label();
            this.lblTipoOperacion = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.dpFechaConfirmacion = new System.Windows.Forms.DateTimePicker();
            this.panel2 = new System.Windows.Forms.Panel();
            this.imgReturn = new System.Windows.Forms.PictureBox();
            this.lblTituloHeader = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.gbDatosParte = new System.Windows.Forms.GroupBox();
            this.lblTecnico = new System.Windows.Forms.Label();
            this.lblFechaProgramacion = new System.Windows.Forms.Label();
            this.gbUsuarioLocacion = new System.Windows.Forms.GroupBox();
            this.gbDatosServicios = new System.Windows.Forms.GroupBox();
            this.dgvServiciosAsociados = new CapaPresentacion.Controles.dgv(this.components);
            this.gbConfirmacion = new System.Windows.Forms.GroupBox();
            this.cboTecnicos = new CapaPresentacion.Controles.combo(this.components);
            this.txtDetalleSolucion = new CapaPresentacion.textboxAdv();
            this.cboProblema = new CapaPresentacion.Controles.combo(this.components);
            this.cboSolucion = new CapaPresentacion.Controles.combo(this.components);
            this.btnConfirmar = new CapaPresentacion.Controles.boton();
            this.btnAnular = new CapaPresentacion.Controles.boton();
            this.btnBuscar = new CapaPresentacion.Controles.boton();
            this.txtNumParte = new CapaPresentacion.textboxAdv();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgReturn)).BeginInit();
            this.gbDatosParte.SuspendLayout();
            this.gbUsuarioLocacion.SuspendLayout();
            this.gbDatosServicios.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvServiciosAsociados)).BeginInit();
            this.gbConfirmacion.SuspendLayout();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(8, 134);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(92, 21);
            this.label6.TabIndex = 226;
            this.label6.Text = "N° de parte:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblFechaConfirmacion
            // 
            this.lblFechaConfirmacion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFechaConfirmacion.AutoSize = true;
            this.lblFechaConfirmacion.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblFechaConfirmacion.ForeColor = System.Drawing.Color.Black;
            this.lblFechaConfirmacion.Location = new System.Drawing.Point(-22, 38);
            this.lblFechaConfirmacion.Name = "lblFechaConfirmacion";
            this.lblFechaConfirmacion.Size = new System.Drawing.Size(217, 21);
            this.lblFechaConfirmacion.TabIndex = 245;
            this.lblFechaConfirmacion.Text = "Fecha y hora de confirmación:";
            // 
            // lblSolicitud
            // 
            this.lblSolicitud.AutoSize = true;
            this.lblSolicitud.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblSolicitud.ForeColor = System.Drawing.Color.Black;
            this.lblSolicitud.Location = new System.Drawing.Point(10, 25);
            this.lblSolicitud.Name = "lblSolicitud";
            this.lblSolicitud.Size = new System.Drawing.Size(73, 21);
            this.lblSolicitud.TabIndex = 245;
            this.lblSolicitud.Text = "Solicitud:";
            this.lblSolicitud.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblFechaReclamo
            // 
            this.lblFechaReclamo.AutoSize = true;
            this.lblFechaReclamo.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblFechaReclamo.ForeColor = System.Drawing.Color.Black;
            this.lblFechaReclamo.Location = new System.Drawing.Point(9, 67);
            this.lblFechaReclamo.Name = "lblFechaReclamo";
            this.lblFechaReclamo.Size = new System.Drawing.Size(138, 21);
            this.lblFechaReclamo.TabIndex = 257;
            this.lblFechaReclamo.Text = "Fecha de reclamo :";
            this.lblFechaReclamo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblSolucion
            // 
            this.lblSolucion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSolucion.AutoSize = true;
            this.lblSolucion.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblSolucion.ForeColor = System.Drawing.Color.Black;
            this.lblSolucion.Location = new System.Drawing.Point(10, 81);
            this.lblSolucion.Name = "lblSolucion";
            this.lblSolucion.Size = new System.Drawing.Size(77, 21);
            this.lblSolucion.TabIndex = 258;
            this.lblSolucion.Text = "Solución :";
            this.lblSolucion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblProblema
            // 
            this.lblProblema.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblProblema.AutoSize = true;
            this.lblProblema.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblProblema.ForeColor = System.Drawing.Color.Black;
            this.lblProblema.Location = new System.Drawing.Point(7, 113);
            this.lblProblema.Name = "lblProblema";
            this.lblProblema.Size = new System.Drawing.Size(80, 21);
            this.lblProblema.TabIndex = 261;
            this.lblProblema.Text = "Problema:";
            this.lblProblema.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblObservacion
            // 
            this.lblObservacion.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblObservacion.ForeColor = System.Drawing.Color.Black;
            this.lblObservacion.Location = new System.Drawing.Point(6, 205);
            this.lblObservacion.Name = "lblObservacion";
            this.lblObservacion.Size = new System.Drawing.Size(100, 22);
            this.lblObservacion.TabIndex = 263;
            this.lblObservacion.Text = "Observación:";
            this.lblObservacion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTecnicoNuevo
            // 
            this.lblTecnicoNuevo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTecnicoNuevo.AutoSize = true;
            this.lblTecnicoNuevo.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblTecnicoNuevo.ForeColor = System.Drawing.Color.Black;
            this.lblTecnicoNuevo.Location = new System.Drawing.Point(18, 150);
            this.lblTecnicoNuevo.Name = "lblTecnicoNuevo";
            this.lblTecnicoNuevo.Size = new System.Drawing.Size(67, 21);
            this.lblTecnicoNuevo.TabIndex = 266;
            this.lblTecnicoNuevo.Text = "Técnico :";
            this.lblTecnicoNuevo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTelefono
            // 
            this.lblTelefono.AutoSize = true;
            this.lblTelefono.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblTelefono.ForeColor = System.Drawing.Color.Black;
            this.lblTelefono.Location = new System.Drawing.Point(10, 109);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(71, 21);
            this.lblTelefono.TabIndex = 248;
            this.lblTelefono.Text = "Teléfono:";
            this.lblTelefono.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblEntreCalles
            // 
            this.lblEntreCalles.AutoSize = true;
            this.lblEntreCalles.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblEntreCalles.ForeColor = System.Drawing.Color.Black;
            this.lblEntreCalles.Location = new System.Drawing.Point(10, 67);
            this.lblEntreCalles.Name = "lblEntreCalles";
            this.lblEntreCalles.Size = new System.Drawing.Size(114, 21);
            this.lblEntreCalles.TabIndex = 246;
            this.lblEntreCalles.Text = "Entre las calles:";
            this.lblEntreCalles.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblUsuario.ForeColor = System.Drawing.Color.Black;
            this.lblUsuario.Location = new System.Drawing.Point(10, 25);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(67, 21);
            this.lblUsuario.TabIndex = 241;
            this.lblUsuario.Text = "Usuario:";
            this.lblUsuario.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDomicilio
            // 
            this.lblDomicilio.AutoSize = true;
            this.lblDomicilio.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblDomicilio.ForeColor = System.Drawing.Color.Black;
            this.lblDomicilio.Location = new System.Drawing.Point(10, 46);
            this.lblDomicilio.Name = "lblDomicilio";
            this.lblDomicilio.Size = new System.Drawing.Size(79, 21);
            this.lblDomicilio.TabIndex = 242;
            this.lblDomicilio.Text = "Domicilio:";
            this.lblDomicilio.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblLocalidad
            // 
            this.lblLocalidad.AutoSize = true;
            this.lblLocalidad.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblLocalidad.ForeColor = System.Drawing.Color.Black;
            this.lblLocalidad.Location = new System.Drawing.Point(10, 88);
            this.lblLocalidad.Name = "lblLocalidad";
            this.lblLocalidad.Size = new System.Drawing.Size(79, 21);
            this.lblLocalidad.TabIndex = 243;
            this.lblLocalidad.Text = "Localidad:";
            this.lblLocalidad.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTipoOperacion
            // 
            this.lblTipoOperacion.AutoSize = true;
            this.lblTipoOperacion.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblTipoOperacion.ForeColor = System.Drawing.Color.Black;
            this.lblTipoOperacion.Location = new System.Drawing.Point(9, 46);
            this.lblTipoOperacion.Name = "lblTipoOperacion";
            this.lblTipoOperacion.Size = new System.Drawing.Size(144, 21);
            this.lblTipoOperacion.TabIndex = 269;
            this.lblTipoOperacion.Text = "Tipo de Operación :";
            this.lblTipoOperacion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel8
            // 
            this.panel8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel8.BackColor = System.Drawing.Color.Silver;
            this.panel8.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.panel8.Location = new System.Drawing.Point(0, 119);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(1053, 1);
            this.panel8.TabIndex = 273;
            // 
            // dpFechaConfirmacion
            // 
            this.dpFechaConfirmacion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dpFechaConfirmacion.CalendarForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(84)))), ((int)(((byte)(101)))));
            this.dpFechaConfirmacion.CalendarTitleForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(84)))), ((int)(((byte)(101)))));
            this.dpFechaConfirmacion.CustomFormat = "dd/MM/yyyy hh:mm:ss tt";
            this.dpFechaConfirmacion.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.dpFechaConfirmacion.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dpFechaConfirmacion.Location = new System.Drawing.Point(201, 32);
            this.dpFechaConfirmacion.Name = "dpFechaConfirmacion";
            this.dpFechaConfirmacion.Size = new System.Drawing.Size(210, 29);
            this.dpFechaConfirmacion.TabIndex = 246;
            this.dpFechaConfirmacion.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dpFecha_KeyDown);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.panel2.Controls.Add(this.imgReturn);
            this.panel2.Controls.Add(this.lblTituloHeader);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1044, 75);
            this.panel2.TabIndex = 274;
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
            this.lblTituloHeader.Text = "Confirmación de partes";
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackColor = System.Drawing.Color.Silver;
            this.panel3.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.panel3.Location = new System.Drawing.Point(0, 166);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1053, 1);
            this.panel3.TabIndex = 274;
            // 
            // gbDatosParte
            // 
            this.gbDatosParte.Controls.Add(this.lblTecnico);
            this.gbDatosParte.Controls.Add(this.lblFechaProgramacion);
            this.gbDatosParte.Controls.Add(this.lblFechaReclamo);
            this.gbDatosParte.Controls.Add(this.lblTipoOperacion);
            this.gbDatosParte.Controls.Add(this.lblSolicitud);
            this.gbDatosParte.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.gbDatosParte.Location = new System.Drawing.Point(12, 173);
            this.gbDatosParte.Name = "gbDatosParte";
            this.gbDatosParte.Size = new System.Drawing.Size(590, 149);
            this.gbDatosParte.TabIndex = 280;
            this.gbDatosParte.TabStop = false;
            this.gbDatosParte.Text = "Datos del parte";
            // 
            // lblTecnico
            // 
            this.lblTecnico.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTecnico.AutoSize = true;
            this.lblTecnico.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblTecnico.ForeColor = System.Drawing.Color.Black;
            this.lblTecnico.Location = new System.Drawing.Point(10, 113);
            this.lblTecnico.Name = "lblTecnico";
            this.lblTecnico.Size = new System.Drawing.Size(67, 21);
            this.lblTecnico.TabIndex = 281;
            this.lblTecnico.Text = "Técnico :";
            this.lblTecnico.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblFechaProgramacion
            // 
            this.lblFechaProgramacion.AutoSize = true;
            this.lblFechaProgramacion.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblFechaProgramacion.ForeColor = System.Drawing.Color.Black;
            this.lblFechaProgramacion.Location = new System.Drawing.Point(10, 88);
            this.lblFechaProgramacion.Name = "lblFechaProgramacion";
            this.lblFechaProgramacion.Size = new System.Drawing.Size(135, 21);
            this.lblFechaProgramacion.TabIndex = 270;
            this.lblFechaProgramacion.Text = "Programado para:";
            this.lblFechaProgramacion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // gbUsuarioLocacion
            // 
            this.gbUsuarioLocacion.Controls.Add(this.lblLocalidad);
            this.gbUsuarioLocacion.Controls.Add(this.lblEntreCalles);
            this.gbUsuarioLocacion.Controls.Add(this.lblUsuario);
            this.gbUsuarioLocacion.Controls.Add(this.lblDomicilio);
            this.gbUsuarioLocacion.Controls.Add(this.lblTelefono);
            this.gbUsuarioLocacion.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.gbUsuarioLocacion.Location = new System.Drawing.Point(12, 328);
            this.gbUsuarioLocacion.Name = "gbUsuarioLocacion";
            this.gbUsuarioLocacion.Size = new System.Drawing.Size(587, 140);
            this.gbUsuarioLocacion.TabIndex = 259;
            this.gbUsuarioLocacion.TabStop = false;
            this.gbUsuarioLocacion.Text = "Usuario y locación:";
            // 
            // gbDatosServicios
            // 
            this.gbDatosServicios.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.gbDatosServicios.Controls.Add(this.dgvServiciosAsociados);
            this.gbDatosServicios.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.gbDatosServicios.Location = new System.Drawing.Point(12, 474);
            this.gbDatosServicios.Name = "gbDatosServicios";
            this.gbDatosServicios.Size = new System.Drawing.Size(590, 188);
            this.gbDatosServicios.TabIndex = 281;
            this.gbDatosServicios.TabStop = false;
            this.gbDatosServicios.Text = "Servicios asociados al parte:";
            // 
            // dgvServiciosAsociados
            // 
            this.dgvServiciosAsociados.AllowUserToAddRows = false;
            this.dgvServiciosAsociados.AllowUserToDeleteRows = false;
            this.dgvServiciosAsociados.AllowUserToOrderColumns = true;
            this.dgvServiciosAsociados.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvServiciosAsociados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvServiciosAsociados.BackgroundColor = System.Drawing.Color.White;
            this.dgvServiciosAsociados.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvServiciosAsociados.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSlateGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 12F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvServiciosAsociados.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvServiciosAsociados.ColumnHeadersHeight = 40;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 12F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvServiciosAsociados.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvServiciosAsociados.EnableHeadersVisualStyles = false;
            this.dgvServiciosAsociados.GridColor = System.Drawing.Color.WhiteSmoke;
            this.dgvServiciosAsociados.Location = new System.Drawing.Point(6, 28);
            this.dgvServiciosAsociados.MultiSelect = false;
            this.dgvServiciosAsociados.Name = "dgvServiciosAsociados";
            this.dgvServiciosAsociados.ReadOnly = true;
            this.dgvServiciosAsociados.RowHeadersVisible = false;
            this.dgvServiciosAsociados.RowHeadersWidth = 50;
            this.dgvServiciosAsociados.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvServiciosAsociados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvServiciosAsociados.Size = new System.Drawing.Size(578, 154);
            this.dgvServiciosAsociados.TabIndex = 282;
            // 
            // gbConfirmacion
            // 
            this.gbConfirmacion.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbConfirmacion.Controls.Add(this.cboTecnicos);
            this.gbConfirmacion.Controls.Add(this.lblTecnicoNuevo);
            this.gbConfirmacion.Controls.Add(this.txtDetalleSolucion);
            this.gbConfirmacion.Controls.Add(this.cboProblema);
            this.gbConfirmacion.Controls.Add(this.lblProblema);
            this.gbConfirmacion.Controls.Add(this.cboSolucion);
            this.gbConfirmacion.Controls.Add(this.lblSolucion);
            this.gbConfirmacion.Controls.Add(this.lblObservacion);
            this.gbConfirmacion.Controls.Add(this.dpFechaConfirmacion);
            this.gbConfirmacion.Controls.Add(this.lblFechaConfirmacion);
            this.gbConfirmacion.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.gbConfirmacion.Location = new System.Drawing.Point(608, 173);
            this.gbConfirmacion.Name = "gbConfirmacion";
            this.gbConfirmacion.Size = new System.Drawing.Size(424, 489);
            this.gbConfirmacion.TabIndex = 281;
            this.gbConfirmacion.TabStop = false;
            this.gbConfirmacion.Text = "Confirmación:";
            // 
            // cboTecnicos
            // 
            this.cboTecnicos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboTecnicos.BorderColor = System.Drawing.Color.Empty;
            this.cboTecnicos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTecnicos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboTecnicos.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTecnicos.FormattingEnabled = true;
            this.cboTecnicos.Location = new System.Drawing.Point(85, 147);
            this.cboTecnicos.Name = "cboTecnicos";
            this.cboTecnicos.Size = new System.Drawing.Size(326, 29);
            this.cboTecnicos.TabIndex = 279;
            // 
            // txtDetalleSolucion
            // 
            this.txtDetalleSolucion.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDetalleSolucion.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtDetalleSolucion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDetalleSolucion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDetalleSolucion.FocusColor = System.Drawing.Color.Empty;
            this.txtDetalleSolucion.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtDetalleSolucion.ForeColor = System.Drawing.Color.DimGray;
            this.txtDetalleSolucion.Location = new System.Drawing.Point(13, 230);
            this.txtDetalleSolucion.Multiline = true;
            this.txtDetalleSolucion.Name = "txtDetalleSolucion";
            this.txtDetalleSolucion.Numerico = false;
            this.txtDetalleSolucion.Size = new System.Drawing.Size(398, 253);
            this.txtDetalleSolucion.TabIndex = 229;
            this.txtDetalleSolucion.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDetalleSolucion_KeyDown);
            // 
            // cboProblema
            // 
            this.cboProblema.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboProblema.BorderColor = System.Drawing.Color.Empty;
            this.cboProblema.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProblema.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboProblema.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cboProblema.ForeColor = System.Drawing.Color.DimGray;
            this.cboProblema.FormattingEnabled = true;
            this.cboProblema.Location = new System.Drawing.Point(85, 110);
            this.cboProblema.Name = "cboProblema";
            this.cboProblema.Size = new System.Drawing.Size(326, 29);
            this.cboProblema.TabIndex = 260;
            this.cboProblema.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbProblema_KeyDown);
            // 
            // cboSolucion
            // 
            this.cboSolucion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboSolucion.BorderColor = System.Drawing.Color.Empty;
            this.cboSolucion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSolucion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboSolucion.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cboSolucion.ForeColor = System.Drawing.Color.DimGray;
            this.cboSolucion.FormattingEnabled = true;
            this.cboSolucion.Location = new System.Drawing.Point(85, 73);
            this.cboSolucion.Name = "cboSolucion";
            this.cboSolucion.Size = new System.Drawing.Size(326, 29);
            this.cboSolucion.TabIndex = 259;
            this.cboSolucion.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbSolucion_KeyDown);
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConfirmar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnConfirmar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConfirmar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(84)))), ((int)(((byte)(101)))));
            this.btnConfirmar.FlatAppearance.BorderSize = 0;
            this.btnConfirmar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(84)))), ((int)(((byte)(101)))));
            this.btnConfirmar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            this.btnConfirmar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirmar.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirmar.ForeColor = System.Drawing.Color.White;
            this.btnConfirmar.Image = global::CapaPresentacion.Properties.Resources.Save_32;
            this.btnConfirmar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnConfirmar.Location = new System.Drawing.Point(923, 79);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(109, 34);
            this.btnConfirmar.TabIndex = 278;
            this.btnConfirmar.Text = "Confirmar";
            this.btnConfirmar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConfirmar.UseVisualStyleBackColor = false;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click_1);
            // 
            // btnAnular
            // 
            this.btnAnular.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAnular.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnAnular.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAnular.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(84)))), ((int)(((byte)(101)))));
            this.btnAnular.FlatAppearance.BorderSize = 0;
            this.btnAnular.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(84)))), ((int)(((byte)(101)))));
            this.btnAnular.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            this.btnAnular.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAnular.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAnular.ForeColor = System.Drawing.Color.White;
            this.btnAnular.Image = global::CapaPresentacion.Properties.Resources.Data_Delete_32;
            this.btnAnular.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAnular.Location = new System.Drawing.Point(809, 79);
            this.btnAnular.Name = "btnAnular";
            this.btnAnular.Size = new System.Drawing.Size(108, 34);
            this.btnAnular.TabIndex = 276;
            this.btnAnular.Text = "Anular";
            this.btnAnular.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAnular.UseVisualStyleBackColor = false;
            this.btnAnular.Click += new System.EventHandler(this.btnAnular_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnBuscar.FlatAppearance.BorderSize = 0;
            this.btnBuscar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnBuscar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnBuscar.ForeColor = System.Drawing.Color.White;
            this.btnBuscar.Image = global::CapaPresentacion.Properties.Resources.lupa;
            this.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBuscar.Location = new System.Drawing.Point(923, 126);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(109, 34);
            this.btnBuscar.TabIndex = 275;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txtNumParte
            // 
            this.txtNumParte.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtNumParte.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNumParte.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNumParte.FocusColor = System.Drawing.Color.Empty;
            this.txtNumParte.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtNumParte.ForeColor = System.Drawing.Color.DimGray;
            this.txtNumParte.Location = new System.Drawing.Point(101, 131);
            this.txtNumParte.Name = "txtNumParte";
            this.txtNumParte.Numerico = true;
            this.txtNumParte.Size = new System.Drawing.Size(52, 29);
            this.txtNumParte.TabIndex = 227;
            this.txtNumParte.Text = "0";
            this.txtNumParte.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNumParte_KeyDown);
            // 
            // frmConfirmaParte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(250)))), ((int)(((byte)(251)))));
            this.ClientSize = new System.Drawing.Size(1044, 674);
            this.Controls.Add(this.gbDatosServicios);
            this.Controls.Add(this.gbConfirmacion);
            this.Controls.Add(this.gbUsuarioLocacion);
            this.Controls.Add(this.gbDatosParte);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.btnAnular);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel8);
            this.Controls.Add(this.txtNumParte);
            this.Controls.Add(this.label6);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "frmConfirmaParte";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmConfirmaParte";
            this.Load += new System.EventHandler(this.frmConfirmaParte_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmConfirmaParte_KeyDown);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgReturn)).EndInit();
            this.gbDatosParte.ResumeLayout(false);
            this.gbDatosParte.PerformLayout();
            this.gbUsuarioLocacion.ResumeLayout(false);
            this.gbUsuarioLocacion.PerformLayout();
            this.gbDatosServicios.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvServiciosAsociados)).EndInit();
            this.gbConfirmacion.ResumeLayout(false);
            this.gbConfirmacion.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label6;
        public textboxAdv txtDetalleSolucion;
        public textboxAdv txtNumParte;
        private System.Windows.Forms.Label lblFechaConfirmacion;
        private System.Windows.Forms.Label lblSolicitud;
        private System.Windows.Forms.Label lblFechaReclamo;
        private System.Windows.Forms.Label lblSolucion;
        private Controles.combo cboSolucion;
        private Controles.combo cboProblema;
        private System.Windows.Forms.Label lblProblema;
        private System.Windows.Forms.Label lblObservacion;
        private System.Windows.Forms.Label lblTecnicoNuevo;
        private System.Windows.Forms.Label lblTelefono;
        private System.Windows.Forms.Label lblEntreCalles;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Label lblDomicilio;
        private System.Windows.Forms.Label lblLocalidad;
        private System.Windows.Forms.Label lblTipoOperacion;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.DateTimePicker dpFechaConfirmacion;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox imgReturn;
        private System.Windows.Forms.Label lblTituloHeader;
        private Controles.boton btnBuscar;
        private Controles.boton btnAnular;
        private Controles.boton btnConfirmar;
        private Controles.combo cboTecnicos;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.GroupBox gbDatosParte;
        private System.Windows.Forms.GroupBox gbUsuarioLocacion;
        private System.Windows.Forms.GroupBox gbDatosServicios;
        private System.Windows.Forms.GroupBox gbConfirmacion;
        private System.Windows.Forms.Label lblFechaProgramacion;
        private System.Windows.Forms.Label lblTecnico;
        private Controles.dgv dgvServiciosAsociados;
    }
}