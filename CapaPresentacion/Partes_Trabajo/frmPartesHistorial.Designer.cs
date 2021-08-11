namespace CapaPresentacion.Partes_Trabajo
{
    partial class frmPartesHistorial
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
            this.pnlHead = new System.Windows.Forms.Panel();
            this.lblLocacion = new System.Windows.Forms.Label();
            this.lbcorreo = new System.Windows.Forms.Label();
            this.lbcuit = new System.Windows.Forms.Label();
            this.LBNumero_documento = new System.Windows.Forms.Label();
            this.LBApellido = new System.Windows.Forms.Label();
            this.imgReturn = new System.Windows.Forms.PictureBox();
            this.lblTituloHeader = new System.Windows.Forms.Label();
            this.pnFooter = new System.Windows.Forms.Panel();
            this.lblTotal = new System.Windows.Forms.Label();
            this.pgCircular = new CapaPresentacion.Controles.progress();
            this.lblSinTarjeta = new System.Windows.Forms.Label();
            this.lblAsignado = new System.Windows.Forms.Label();
            this.lblReferencias = new System.Windows.Forms.Label();
            this.lblRealizado = new System.Windows.Forms.Label();
            this.lblSinTecnico = new System.Windows.Forms.Label();
            this.lblSinEquipo = new System.Windows.Forms.Label();
            this.lblNparte = new System.Windows.Forms.Label();
            this.lblEstado = new System.Windows.Forms.Label();
            this.lblSolicitud = new System.Windows.Forms.Label();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.lblLoc = new System.Windows.Forms.Label();
            this.lblFechaRec = new System.Windows.Forms.Label();
            this.lblFechaProg = new System.Windows.Forms.Label();
            this.lblFechaRealizado = new System.Windows.Forms.Label();
            this.lblFechaHasta = new System.Windows.Forms.Label();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.dtpFechaHasta = new System.Windows.Forms.DateTimePicker();
            this.dtpFechaDesde = new System.Windows.Forms.DateTimePicker();
            this.lblFechaDesde = new System.Windows.Forms.Label();
            this.rbFechaRealizado = new System.Windows.Forms.RadioButton();
            this.rbFechaReclamo = new System.Windows.Forms.RadioButton();
            this.lblServicio = new System.Windows.Forms.Label();
            this.lblLapsoTiempo = new System.Windows.Forms.Label();
            this.pnlInfoPartes = new System.Windows.Forms.Panel();
            this.btnImprimirContrato = new CapaPresentacion.Controles.boton();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblFechaConsulta = new System.Windows.Forms.Label();
            this.rbFechaProgramado = new System.Windows.Forms.RadioButton();
            this.cbPartesAnulados = new System.Windows.Forms.CheckBox();
            this.cmsOpciones = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.crearNuevoParteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.asignarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuIpFija = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTecnico = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEquipos = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTarjeta = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuReprogramar = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuConfirmar = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAnular = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSeguimiento = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuVerServicios = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuImprimir = new System.Windows.Forms.ToolStripMenuItem();
            this.gPSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuGpsEnviar = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuGpsObservacion = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuImprimirContrato = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuExportar = new System.Windows.Forms.ToolStripMenuItem();
            this.probarCassToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.observacionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cboLocacion = new CapaPresentacion.Controles.combo(this.components);
            this.btnBuscarUsuario = new CapaPresentacion.Controles.boton();
            this.btnBuscar = new CapaPresentacion.Controles.boton();
            this.dgvPartes = new CapaPresentacion.Controles.dgv(this.components);
            this.Seleccionar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.txtBuscar = new CapaPresentacion.textboxAdv();
            this.pnlHead.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgReturn)).BeginInit();
            this.pnFooter.SuspendLayout();
            this.pnlInfoPartes.SuspendLayout();
            this.cmsOpciones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPartes)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlHead
            // 
            this.pnlHead.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.pnlHead.Controls.Add(this.lblLocacion);
            this.pnlHead.Controls.Add(this.lbcorreo);
            this.pnlHead.Controls.Add(this.lbcuit);
            this.pnlHead.Controls.Add(this.LBNumero_documento);
            this.pnlHead.Controls.Add(this.LBApellido);
            this.pnlHead.Controls.Add(this.imgReturn);
            this.pnlHead.Controls.Add(this.lblTituloHeader);
            this.pnlHead.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHead.Location = new System.Drawing.Point(0, 0);
            this.pnlHead.Name = "pnlHead";
            this.pnlHead.Size = new System.Drawing.Size(1332, 105);
            this.pnlHead.TabIndex = 272;
            // 
            // lblLocacion
            // 
            this.lblLocacion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLocacion.AutoSize = true;
            this.lblLocacion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.lblLocacion.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblLocacion.ForeColor = System.Drawing.Color.White;
            this.lblLocacion.Location = new System.Drawing.Point(1015, 43);
            this.lblLocacion.Name = "lblLocacion";
            this.lblLocacion.Size = new System.Drawing.Size(0, 21);
            this.lblLocacion.TabIndex = 215;
            this.lblLocacion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbcorreo
            // 
            this.lbcorreo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbcorreo.AutoSize = true;
            this.lbcorreo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.lbcorreo.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lbcorreo.ForeColor = System.Drawing.Color.White;
            this.lbcorreo.Location = new System.Drawing.Point(873, 74);
            this.lbcorreo.Name = "lbcorreo";
            this.lbcorreo.Size = new System.Drawing.Size(0, 21);
            this.lbcorreo.TabIndex = 214;
            this.lbcorreo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbcuit
            // 
            this.lbcuit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbcuit.AutoSize = true;
            this.lbcuit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.lbcuit.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lbcuit.ForeColor = System.Drawing.Color.White;
            this.lbcuit.Location = new System.Drawing.Point(779, 43);
            this.lbcuit.Name = "lbcuit";
            this.lbcuit.Size = new System.Drawing.Size(0, 21);
            this.lbcuit.TabIndex = 213;
            this.lbcuit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LBNumero_documento
            // 
            this.LBNumero_documento.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LBNumero_documento.AutoSize = true;
            this.LBNumero_documento.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.LBNumero_documento.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.LBNumero_documento.ForeColor = System.Drawing.Color.White;
            this.LBNumero_documento.Location = new System.Drawing.Point(877, 9);
            this.LBNumero_documento.Name = "LBNumero_documento";
            this.LBNumero_documento.Size = new System.Drawing.Size(0, 21);
            this.LBNumero_documento.TabIndex = 212;
            this.LBNumero_documento.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LBApellido
            // 
            this.LBApellido.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LBApellido.AutoSize = true;
            this.LBApellido.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.LBApellido.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.LBApellido.ForeColor = System.Drawing.Color.White;
            this.LBApellido.Location = new System.Drawing.Point(1103, 9);
            this.LBApellido.Name = "LBApellido";
            this.LBApellido.Size = new System.Drawing.Size(0, 21);
            this.LBApellido.TabIndex = 211;
            this.LBApellido.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // imgReturn
            // 
            this.imgReturn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.imgReturn.Image = global::CapaPresentacion.Properties.Resources.Left_Arrow_32;
            this.imgReturn.Location = new System.Drawing.Point(11, 34);
            this.imgReturn.Name = "imgReturn";
            this.imgReturn.Size = new System.Drawing.Size(32, 32);
            this.imgReturn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgReturn.TabIndex = 209;
            this.imgReturn.TabStop = false;
            this.imgReturn.Click += new System.EventHandler(this.imgReturn_Click);
            // 
            // lblTituloHeader
            // 
            this.lblTituloHeader.Font = new System.Drawing.Font("Segoe UI Light", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloHeader.ForeColor = System.Drawing.Color.White;
            this.lblTituloHeader.Location = new System.Drawing.Point(49, 39);
            this.lblTituloHeader.Name = "lblTituloHeader";
            this.lblTituloHeader.Size = new System.Drawing.Size(311, 27);
            this.lblTituloHeader.TabIndex = 208;
            this.lblTituloHeader.Text = "Historial de partes de trabajo";
            // 
            // pnFooter
            // 
            this.pnFooter.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnFooter.Controls.Add(this.lblTotal);
            this.pnFooter.Controls.Add(this.pgCircular);
            this.pnFooter.Controls.Add(this.lblSinTarjeta);
            this.pnFooter.Controls.Add(this.lblAsignado);
            this.pnFooter.Controls.Add(this.lblReferencias);
            this.pnFooter.Controls.Add(this.lblRealizado);
            this.pnFooter.Controls.Add(this.lblSinTecnico);
            this.pnFooter.Controls.Add(this.lblSinEquipo);
            this.pnFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnFooter.Location = new System.Drawing.Point(0, 564);
            this.pnFooter.Name = "pnFooter";
            this.pnFooter.Size = new System.Drawing.Size(1332, 30);
            this.pnFooter.TabIndex = 274;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblTotal.ForeColor = System.Drawing.Color.SlateGray;
            this.lblTotal.Location = new System.Drawing.Point(12, 5);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(148, 21);
            this.lblTotal.TabIndex = 13;
            this.lblTotal.Text = "Total de Registros: 0";
            // 
            // pgCircular
            // 
            this.pgCircular.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pgCircular.Location = new System.Drawing.Point(1296, 2);
            this.pgCircular.Name = "pgCircular";
            this.pgCircular.Percentage = 0F;
            this.pgCircular.Rotation = CapaPresentacion.Controles.RotationType.CounterClockwise;
            this.pgCircular.Size = new System.Drawing.Size(24, 24);
            this.pgCircular.TabIndex = 0;
            // 
            // lblSinTarjeta
            // 
            this.lblSinTarjeta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSinTarjeta.BackColor = System.Drawing.Color.DarkOrange;
            this.lblSinTarjeta.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSinTarjeta.Location = new System.Drawing.Point(779, 6);
            this.lblSinTarjeta.Name = "lblSinTarjeta";
            this.lblSinTarjeta.Size = new System.Drawing.Size(106, 20);
            this.lblSinTarjeta.TabIndex = 309;
            this.lblSinTarjeta.Text = "Sin tarjeta";
            this.lblSinTarjeta.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblSinTarjeta.Click += new System.EventHandler(this.lblSinTarjeta_Click);
            // 
            // lblAsignado
            // 
            this.lblAsignado.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAsignado.BackColor = System.Drawing.Color.LightGreen;
            this.lblAsignado.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAsignado.Location = new System.Drawing.Point(327, 6);
            this.lblAsignado.Name = "lblAsignado";
            this.lblAsignado.Size = new System.Drawing.Size(106, 20);
            this.lblAsignado.TabIndex = 299;
            this.lblAsignado.Text = "Asignado";
            this.lblAsignado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblAsignado.Click += new System.EventHandler(this.lblAsignado_Click);
            // 
            // lblReferencias
            // 
            this.lblReferencias.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblReferencias.AutoSize = true;
            this.lblReferencias.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblReferencias.Location = new System.Drawing.Point(228, 6);
            this.lblReferencias.Name = "lblReferencias";
            this.lblReferencias.Size = new System.Drawing.Size(97, 21);
            this.lblReferencias.TabIndex = 300;
            this.lblReferencias.Text = "Referencias: ";
            // 
            // lblRealizado
            // 
            this.lblRealizado.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRealizado.BackColor = System.Drawing.Color.DarkGray;
            this.lblRealizado.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRealizado.Location = new System.Drawing.Point(443, 6);
            this.lblRealizado.Name = "lblRealizado";
            this.lblRealizado.Size = new System.Drawing.Size(106, 20);
            this.lblRealizado.TabIndex = 301;
            this.lblRealizado.Text = "Realizado";
            this.lblRealizado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblRealizado.Click += new System.EventHandler(this.lblRealizado_Click);
            // 
            // lblSinTecnico
            // 
            this.lblSinTecnico.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSinTecnico.BackColor = System.Drawing.Color.Tomato;
            this.lblSinTecnico.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSinTecnico.Location = new System.Drawing.Point(555, 6);
            this.lblSinTecnico.Name = "lblSinTecnico";
            this.lblSinTecnico.Size = new System.Drawing.Size(106, 20);
            this.lblSinTecnico.TabIndex = 302;
            this.lblSinTecnico.Text = "Sin técnico";
            this.lblSinTecnico.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblSinTecnico.Click += new System.EventHandler(this.lblSinTecnico_Click);
            // 
            // lblSinEquipo
            // 
            this.lblSinEquipo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSinEquipo.BackColor = System.Drawing.Color.Yellow;
            this.lblSinEquipo.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSinEquipo.Location = new System.Drawing.Point(667, 6);
            this.lblSinEquipo.Name = "lblSinEquipo";
            this.lblSinEquipo.Size = new System.Drawing.Size(106, 20);
            this.lblSinEquipo.TabIndex = 303;
            this.lblSinEquipo.Text = "Sin equipo";
            this.lblSinEquipo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblSinEquipo.Click += new System.EventHandler(this.lblSinEquipo_Click);
            // 
            // lblNparte
            // 
            this.lblNparte.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblNparte.AutoSize = true;
            this.lblNparte.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblNparte.ForeColor = System.Drawing.Color.Black;
            this.lblNparte.Location = new System.Drawing.Point(12, 10);
            this.lblNparte.Name = "lblNparte";
            this.lblNparte.Size = new System.Drawing.Size(185, 21);
            this.lblNparte.TabIndex = 281;
            this.lblNparte.Text = "N° de parte seleccionado:";
            // 
            // lblEstado
            // 
            this.lblEstado.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblEstado.AutoSize = true;
            this.lblEstado.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblEstado.ForeColor = System.Drawing.Color.Black;
            this.lblEstado.Location = new System.Drawing.Point(13, 31);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(59, 21);
            this.lblEstado.TabIndex = 282;
            this.lblEstado.Text = "Estado:";
            // 
            // lblSolicitud
            // 
            this.lblSolicitud.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSolicitud.AutoSize = true;
            this.lblSolicitud.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblSolicitud.ForeColor = System.Drawing.Color.Black;
            this.lblSolicitud.Location = new System.Drawing.Point(13, 52);
            this.lblSolicitud.Name = "lblSolicitud";
            this.lblSolicitud.Size = new System.Drawing.Size(73, 21);
            this.lblSolicitud.TabIndex = 283;
            this.lblSolicitud.Text = "Solicitud:";
            // 
            // lblUsuario
            // 
            this.lblUsuario.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblUsuario.ForeColor = System.Drawing.Color.Black;
            this.lblUsuario.Location = new System.Drawing.Point(454, 10);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(67, 21);
            this.lblUsuario.TabIndex = 284;
            this.lblUsuario.Text = "Usuario:";
            // 
            // lblLoc
            // 
            this.lblLoc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblLoc.AutoSize = true;
            this.lblLoc.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblLoc.ForeColor = System.Drawing.Color.Black;
            this.lblLoc.Location = new System.Drawing.Point(454, 31);
            this.lblLoc.Name = "lblLoc";
            this.lblLoc.Size = new System.Drawing.Size(78, 21);
            this.lblLoc.TabIndex = 285;
            this.lblLoc.Text = "Locación: ";
            // 
            // lblFechaRec
            // 
            this.lblFechaRec.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblFechaRec.AutoSize = true;
            this.lblFechaRec.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblFechaRec.ForeColor = System.Drawing.Color.Black;
            this.lblFechaRec.Location = new System.Drawing.Point(803, 10);
            this.lblFechaRec.Name = "lblFechaRec";
            this.lblFechaRec.Size = new System.Drawing.Size(134, 21);
            this.lblFechaRec.TabIndex = 287;
            this.lblFechaRec.Text = "Fecha de reclamo:";
            // 
            // lblFechaProg
            // 
            this.lblFechaProg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblFechaProg.AutoSize = true;
            this.lblFechaProg.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblFechaProg.ForeColor = System.Drawing.Color.Black;
            this.lblFechaProg.Location = new System.Drawing.Point(803, 31);
            this.lblFechaProg.Name = "lblFechaProg";
            this.lblFechaProg.Size = new System.Drawing.Size(135, 21);
            this.lblFechaProg.TabIndex = 288;
            this.lblFechaProg.Text = "Programado para:";
            // 
            // lblFechaRealizado
            // 
            this.lblFechaRealizado.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblFechaRealizado.AutoSize = true;
            this.lblFechaRealizado.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblFechaRealizado.ForeColor = System.Drawing.Color.Black;
            this.lblFechaRealizado.Location = new System.Drawing.Point(803, 52);
            this.lblFechaRealizado.Name = "lblFechaRealizado";
            this.lblFechaRealizado.Size = new System.Drawing.Size(152, 21);
            this.lblFechaRealizado.TabIndex = 289;
            this.lblFechaRealizado.Text = "Fecha de realización:";
            // 
            // lblFechaHasta
            // 
            this.lblFechaHasta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFechaHasta.AutoSize = true;
            this.lblFechaHasta.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblFechaHasta.ForeColor = System.Drawing.Color.Black;
            this.lblFechaHasta.Location = new System.Drawing.Point(1113, 192);
            this.lblFechaHasta.Name = "lblFechaHasta";
            this.lblFechaHasta.Size = new System.Drawing.Size(52, 21);
            this.lblFechaHasta.TabIndex = 291;
            this.lblFechaHasta.Text = "Hasta:";
            // 
            // lblBuscar
            // 
            this.lblBuscar.AutoSize = true;
            this.lblBuscar.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblBuscar.ForeColor = System.Drawing.Color.Black;
            this.lblBuscar.Location = new System.Drawing.Point(6, 159);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Size = new System.Drawing.Size(119, 21);
            this.lblBuscar.TabIndex = 292;
            this.lblBuscar.Text = "Buscar en grilla:";
            // 
            // dtpFechaHasta
            // 
            this.dtpFechaHasta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpFechaHasta.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.dtpFechaHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFechaHasta.Location = new System.Drawing.Point(1171, 187);
            this.dtpFechaHasta.Name = "dtpFechaHasta";
            this.dtpFechaHasta.Size = new System.Drawing.Size(107, 29);
            this.dtpFechaHasta.TabIndex = 293;
            // 
            // dtpFechaDesde
            // 
            this.dtpFechaDesde.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpFechaDesde.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.dtpFechaDesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFechaDesde.Location = new System.Drawing.Point(1000, 187);
            this.dtpFechaDesde.Name = "dtpFechaDesde";
            this.dtpFechaDesde.Size = new System.Drawing.Size(107, 29);
            this.dtpFechaDesde.TabIndex = 294;
            // 
            // lblFechaDesde
            // 
            this.lblFechaDesde.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFechaDesde.AutoSize = true;
            this.lblFechaDesde.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblFechaDesde.ForeColor = System.Drawing.Color.Black;
            this.lblFechaDesde.Location = new System.Drawing.Point(938, 190);
            this.lblFechaDesde.Name = "lblFechaDesde";
            this.lblFechaDesde.Size = new System.Drawing.Size(56, 21);
            this.lblFechaDesde.TabIndex = 295;
            this.lblFechaDesde.Text = "Desde:";
            // 
            // rbFechaRealizado
            // 
            this.rbFechaRealizado.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbFechaRealizado.AutoSize = true;
            this.rbFechaRealizado.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.rbFechaRealizado.ForeColor = System.Drawing.Color.Black;
            this.rbFechaRealizado.Location = new System.Drawing.Point(1157, 152);
            this.rbFechaRealizado.Name = "rbFechaRealizado";
            this.rbFechaRealizado.Size = new System.Drawing.Size(167, 25);
            this.rbFechaRealizado.TabIndex = 297;
            this.rbFechaRealizado.TabStop = true;
            this.rbFechaRealizado.Text = "Fecha de realización";
            this.rbFechaRealizado.UseVisualStyleBackColor = true;
            // 
            // rbFechaReclamo
            // 
            this.rbFechaReclamo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbFechaReclamo.AutoSize = true;
            this.rbFechaReclamo.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.rbFechaReclamo.ForeColor = System.Drawing.Color.Black;
            this.rbFechaReclamo.Location = new System.Drawing.Point(837, 152);
            this.rbFechaReclamo.Name = "rbFechaReclamo";
            this.rbFechaReclamo.Size = new System.Drawing.Size(149, 25);
            this.rbFechaReclamo.TabIndex = 296;
            this.rbFechaReclamo.TabStop = true;
            this.rbFechaReclamo.Text = "Fecha de reclamo";
            this.rbFechaReclamo.UseVisualStyleBackColor = true;
            // 
            // lblServicio
            // 
            this.lblServicio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblServicio.AutoSize = true;
            this.lblServicio.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblServicio.ForeColor = System.Drawing.Color.Black;
            this.lblServicio.Location = new System.Drawing.Point(454, 52);
            this.lblServicio.Name = "lblServicio";
            this.lblServicio.Size = new System.Drawing.Size(68, 21);
            this.lblServicio.TabIndex = 298;
            this.lblServicio.Text = "Servicio:";
            // 
            // lblLapsoTiempo
            // 
            this.lblLapsoTiempo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblLapsoTiempo.AutoSize = true;
            this.lblLapsoTiempo.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblLapsoTiempo.ForeColor = System.Drawing.Color.Black;
            this.lblLapsoTiempo.Location = new System.Drawing.Point(1032, 10);
            this.lblLapsoTiempo.Name = "lblLapsoTiempo";
            this.lblLapsoTiempo.Size = new System.Drawing.Size(76, 21);
            this.lblLapsoTiempo.TabIndex = 305;
            this.lblLapsoTiempo.Text = "Duración:";
            // 
            // pnlInfoPartes
            // 
            this.pnlInfoPartes.Controls.Add(this.btnImprimirContrato);
            this.pnlInfoPartes.Controls.Add(this.lblNparte);
            this.pnlInfoPartes.Controls.Add(this.lblEstado);
            this.pnlInfoPartes.Controls.Add(this.lblLapsoTiempo);
            this.pnlInfoPartes.Controls.Add(this.lblSolicitud);
            this.pnlInfoPartes.Controls.Add(this.lblServicio);
            this.pnlInfoPartes.Controls.Add(this.lblUsuario);
            this.pnlInfoPartes.Controls.Add(this.lblFechaRealizado);
            this.pnlInfoPartes.Controls.Add(this.lblLoc);
            this.pnlInfoPartes.Controls.Add(this.lblFechaProg);
            this.pnlInfoPartes.Controls.Add(this.lblFechaRec);
            this.pnlInfoPartes.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlInfoPartes.Location = new System.Drawing.Point(0, 484);
            this.pnlInfoPartes.Name = "pnlInfoPartes";
            this.pnlInfoPartes.Size = new System.Drawing.Size(1332, 80);
            this.pnlInfoPartes.TabIndex = 315;
            // 
            // btnImprimirContrato
            // 
            this.btnImprimirContrato.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImprimirContrato.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnImprimirContrato.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnImprimirContrato.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnImprimirContrato.FlatAppearance.BorderSize = 0;
            this.btnImprimirContrato.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnImprimirContrato.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnImprimirContrato.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImprimirContrato.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnImprimirContrato.ForeColor = System.Drawing.Color.White;
            this.btnImprimirContrato.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnImprimirContrato.Location = new System.Drawing.Point(1189, 7);
            this.btnImprimirContrato.Margin = new System.Windows.Forms.Padding(2);
            this.btnImprimirContrato.Name = "btnImprimirContrato";
            this.btnImprimirContrato.Size = new System.Drawing.Size(135, 31);
            this.btnImprimirContrato.TabIndex = 333;
            this.btnImprimirContrato.Text = "Contrato";
            this.btnImprimirContrato.UseVisualStyleBackColor = false;
            this.btnImprimirContrato.Click += new System.EventHandler(this.btnImprimirContrato_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(7, 193);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 21);
            this.label1.TabIndex = 323;
            this.label1.Text = "Locación:";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.Silver;
            this.panel1.Location = new System.Drawing.Point(0, 148);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1344, 1);
            this.panel1.TabIndex = 325;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.Silver;
            this.panel2.Location = new System.Drawing.Point(0, 225);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1344, 1);
            this.panel2.TabIndex = 326;
            // 
            // lblFechaConsulta
            // 
            this.lblFechaConsulta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFechaConsulta.AutoSize = true;
            this.lblFechaConsulta.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblFechaConsulta.ForeColor = System.Drawing.Color.Black;
            this.lblFechaConsulta.Location = new System.Drawing.Point(714, 154);
            this.lblFechaConsulta.Name = "lblFechaConsulta";
            this.lblFechaConsulta.Size = new System.Drawing.Size(108, 21);
            this.lblFechaConsulta.TabIndex = 327;
            this.lblFechaConsulta.Text = "Consultar por:";
            // 
            // rbFechaProgramado
            // 
            this.rbFechaProgramado.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbFechaProgramado.AutoSize = true;
            this.rbFechaProgramado.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.rbFechaProgramado.ForeColor = System.Drawing.Color.Black;
            this.rbFechaProgramado.Location = new System.Drawing.Point(992, 152);
            this.rbFechaProgramado.Name = "rbFechaProgramado";
            this.rbFechaProgramado.Size = new System.Drawing.Size(159, 25);
            this.rbFechaProgramado.TabIndex = 331;
            this.rbFechaProgramado.TabStop = true;
            this.rbFechaProgramado.Text = "Fecha programado";
            this.rbFechaProgramado.UseVisualStyleBackColor = true;
            // 
            // cbPartesAnulados
            // 
            this.cbPartesAnulados.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbPartesAnulados.AutoSize = true;
            this.cbPartesAnulados.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cbPartesAnulados.Location = new System.Drawing.Point(734, 189);
            this.cbPartesAnulados.Name = "cbPartesAnulados";
            this.cbPartesAnulados.Size = new System.Drawing.Size(198, 25);
            this.cbPartesAnulados.TabIndex = 333;
            this.cbPartesAnulados.Text = "Mostrar partes anulados";
            this.cbPartesAnulados.UseVisualStyleBackColor = true;
            this.cbPartesAnulados.CheckedChanged += new System.EventHandler(this.cbPartesAnulados_CheckedChanged);
            // 
            // cmsOpciones
            // 
            this.cmsOpciones.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.crearNuevoParteToolStripMenuItem,
            this.asignarToolStripMenuItem,
            this.mnuReprogramar,
            this.mnuConfirmar,
            this.mnuAnular,
            this.mnuSeguimiento,
            this.mnuVerServicios,
            this.mnuImprimir,
            this.gPSToolStripMenuItem,
            this.mnuImprimirContrato,
            this.mnuExportar,
            this.probarCassToolStripMenuItem,
            this.toolStripSeparator1,
            this.observacionesToolStripMenuItem});
            this.cmsOpciones.Name = "cmsOpciones";
            this.cmsOpciones.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.cmsOpciones.Size = new System.Drawing.Size(181, 318);
            // 
            // crearNuevoParteToolStripMenuItem
            // 
            this.crearNuevoParteToolStripMenuItem.Name = "crearNuevoParteToolStripMenuItem";
            this.crearNuevoParteToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.crearNuevoParteToolStripMenuItem.ShowShortcutKeys = false;
            this.crearNuevoParteToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.crearNuevoParteToolStripMenuItem.Text = "Crear nuevo parte";
            this.crearNuevoParteToolStripMenuItem.Click += new System.EventHandler(this.crearNuevoParteToolStripMenuItem_Click);
            // 
            // asignarToolStripMenuItem
            // 
            this.asignarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuIpFija,
            this.mnuTecnico,
            this.mnuEquipos,
            this.mnuTarjeta});
            this.asignarToolStripMenuItem.Name = "asignarToolStripMenuItem";
            this.asignarToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.asignarToolStripMenuItem.Text = "Asignar";
            // 
            // mnuIpFija
            // 
            this.mnuIpFija.Name = "mnuIpFija";
            this.mnuIpFija.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.mnuIpFija.ShowShortcutKeys = false;
            this.mnuIpFija.Size = new System.Drawing.Size(109, 22);
            this.mnuIpFija.Text = "IP Fija";
            // 
            // mnuTecnico
            // 
            this.mnuTecnico.Name = "mnuTecnico";
            this.mnuTecnico.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.T)));
            this.mnuTecnico.ShowShortcutKeys = false;
            this.mnuTecnico.Size = new System.Drawing.Size(109, 22);
            this.mnuTecnico.Text = "Tecnico";
            this.mnuTecnico.Click += new System.EventHandler(this.mnuTecnico_Click);
            // 
            // mnuEquipos
            // 
            this.mnuEquipos.Name = "mnuEquipos";
            this.mnuEquipos.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.mnuEquipos.ShowShortcutKeys = false;
            this.mnuEquipos.Size = new System.Drawing.Size(109, 22);
            this.mnuEquipos.Text = "Equipos";
            this.mnuEquipos.Click += new System.EventHandler(this.mnuEquipos_Click);
            // 
            // mnuTarjeta
            // 
            this.mnuTarjeta.Name = "mnuTarjeta";
            this.mnuTarjeta.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.J)));
            this.mnuTarjeta.ShowShortcutKeys = false;
            this.mnuTarjeta.Size = new System.Drawing.Size(109, 22);
            this.mnuTarjeta.Text = "Tarjeta";
            this.mnuTarjeta.Click += new System.EventHandler(this.mnuTarjeta_Click);
            // 
            // mnuReprogramar
            // 
            this.mnuReprogramar.Name = "mnuReprogramar";
            this.mnuReprogramar.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.mnuReprogramar.ShowShortcutKeys = false;
            this.mnuReprogramar.Size = new System.Drawing.Size(180, 22);
            this.mnuReprogramar.Text = "Reprogramar";
            this.mnuReprogramar.Click += new System.EventHandler(this.mnuReprogramar_Click);
            // 
            // mnuConfirmar
            // 
            this.mnuConfirmar.Name = "mnuConfirmar";
            this.mnuConfirmar.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.mnuConfirmar.ShowShortcutKeys = false;
            this.mnuConfirmar.Size = new System.Drawing.Size(180, 22);
            this.mnuConfirmar.Text = "Confirmar";
            this.mnuConfirmar.Click += new System.EventHandler(this.mnuConfirmar_Click);
            // 
            // mnuAnular
            // 
            this.mnuAnular.Name = "mnuAnular";
            this.mnuAnular.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.mnuAnular.ShowShortcutKeys = false;
            this.mnuAnular.Size = new System.Drawing.Size(180, 22);
            this.mnuAnular.Text = "Anular";
            this.mnuAnular.Click += new System.EventHandler(this.mnuAnular_Click);
            // 
            // mnuSeguimiento
            // 
            this.mnuSeguimiento.Name = "mnuSeguimiento";
            this.mnuSeguimiento.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.mnuSeguimiento.ShowShortcutKeys = false;
            this.mnuSeguimiento.Size = new System.Drawing.Size(180, 22);
            this.mnuSeguimiento.Text = "Seguimiento";
            this.mnuSeguimiento.Click += new System.EventHandler(this.mnuSeguimiento_Click);
            // 
            // mnuVerServicios
            // 
            this.mnuVerServicios.Name = "mnuVerServicios";
            this.mnuVerServicios.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.H)));
            this.mnuVerServicios.ShowShortcutKeys = false;
            this.mnuVerServicios.Size = new System.Drawing.Size(180, 22);
            this.mnuVerServicios.Text = "Ver servicios";
            this.mnuVerServicios.Click += new System.EventHandler(this.mnuVerServicios_Click);
            // 
            // mnuImprimir
            // 
            this.mnuImprimir.Name = "mnuImprimir";
            this.mnuImprimir.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.I)));
            this.mnuImprimir.ShowShortcutKeys = false;
            this.mnuImprimir.Size = new System.Drawing.Size(180, 22);
            this.mnuImprimir.Text = "Imprmir";
            this.mnuImprimir.Click += new System.EventHandler(this.mnuImprimir_Click);
            // 
            // gPSToolStripMenuItem
            // 
            this.gPSToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuGpsEnviar,
            this.mnuGpsObservacion});
            this.gPSToolStripMenuItem.Name = "gPSToolStripMenuItem";
            this.gPSToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.gPSToolStripMenuItem.Text = "GPS";
            // 
            // mnuGpsEnviar
            // 
            this.mnuGpsEnviar.Name = "mnuGpsEnviar";
            this.mnuGpsEnviar.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.mnuGpsEnviar.ShowShortcutKeys = false;
            this.mnuGpsEnviar.Size = new System.Drawing.Size(176, 22);
            this.mnuGpsEnviar.Text = "Enviar parte";
            this.mnuGpsEnviar.Click += new System.EventHandler(this.mnuGpsEnviar_Click);
            // 
            // mnuGpsObservacion
            // 
            this.mnuGpsObservacion.Name = "mnuGpsObservacion";
            this.mnuGpsObservacion.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.M)));
            this.mnuGpsObservacion.ShowShortcutKeys = false;
            this.mnuGpsObservacion.Size = new System.Drawing.Size(176, 22);
            this.mnuGpsObservacion.Text = "Agregar observacion";
            this.mnuGpsObservacion.Click += new System.EventHandler(this.mnuGpsObservacion_Click);
            // 
            // mnuImprimirContrato
            // 
            this.mnuImprimirContrato.Name = "mnuImprimirContrato";
            this.mnuImprimirContrato.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
            this.mnuImprimirContrato.ShowShortcutKeys = false;
            this.mnuImprimirContrato.Size = new System.Drawing.Size(180, 22);
            this.mnuImprimirContrato.Text = "Imprimir contrato";
            this.mnuImprimirContrato.Click += new System.EventHandler(this.mnuImprimirContrato_Click);
            // 
            // mnuExportar
            // 
            this.mnuExportar.Name = "mnuExportar";
            this.mnuExportar.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.L)));
            this.mnuExportar.ShowShortcutKeys = false;
            this.mnuExportar.Size = new System.Drawing.Size(180, 22);
            this.mnuExportar.Text = "Exportar";
            this.mnuExportar.Click += new System.EventHandler(this.mnuExportar_Click);
            // 
            // probarCassToolStripMenuItem
            // 
            this.probarCassToolStripMenuItem.Name = "probarCassToolStripMenuItem";
            this.probarCassToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.probarCassToolStripMenuItem.Text = "Actualizar Cass";
            this.probarCassToolStripMenuItem.Click += new System.EventHandler(this.probarCassToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            // 
            // observacionesToolStripMenuItem
            // 
            this.observacionesToolStripMenuItem.Name = "observacionesToolStripMenuItem";
            this.observacionesToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.observacionesToolStripMenuItem.Text = "Observaciones";
            this.observacionesToolStripMenuItem.Click += new System.EventHandler(this.observacionesToolStripMenuItem_Click);
            // 
            // cboLocacion
            // 
            this.cboLocacion.BorderColor = System.Drawing.Color.LightGray;
            this.cboLocacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLocacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboLocacion.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboLocacion.FormattingEnabled = true;
            this.cboLocacion.Location = new System.Drawing.Point(89, 190);
            this.cboLocacion.Name = "cboLocacion";
            this.cboLocacion.Size = new System.Drawing.Size(433, 29);
            this.cboLocacion.TabIndex = 324;
            this.cboLocacion.SelectedValueChanged += new System.EventHandler(this.cboLocacion_SelectedValueChanged);
            // 
            // btnBuscarUsuario
            // 
            this.btnBuscarUsuario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnBuscarUsuario.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscarUsuario.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnBuscarUsuario.FlatAppearance.BorderSize = 0;
            this.btnBuscarUsuario.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnBuscarUsuario.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnBuscarUsuario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarUsuario.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnBuscarUsuario.ForeColor = System.Drawing.Color.White;
            this.btnBuscarUsuario.Image = global::CapaPresentacion.Properties.Resources.Business_Man_Search_32;
            this.btnBuscarUsuario.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBuscarUsuario.Location = new System.Drawing.Point(10, 111);
            this.btnBuscarUsuario.Name = "btnBuscarUsuario";
            this.btnBuscarUsuario.Size = new System.Drawing.Size(187, 30);
            this.btnBuscarUsuario.TabIndex = 311;
            this.btnBuscarUsuario.Text = "Seleccionar usuario";
            this.btnBuscarUsuario.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscarUsuario.UseVisualStyleBackColor = false;
            this.btnBuscarUsuario.Click += new System.EventHandler(this.btnBuscarUsuario_Click);
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
            this.btnBuscar.Location = new System.Drawing.Point(1284, 185);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(39, 31);
            this.btnBuscar.TabIndex = 290;
            this.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // dgvPartes
            // 
            this.dgvPartes.AllowUserToAddRows = false;
            this.dgvPartes.AllowUserToDeleteRows = false;
            this.dgvPartes.AllowUserToOrderColumns = true;
            this.dgvPartes.AllowUserToResizeRows = false;
            this.dgvPartes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPartes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPartes.BackgroundColor = System.Drawing.Color.White;
            this.dgvPartes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvPartes.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvPartes.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSlateGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPartes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPartes.ColumnHeadersHeight = 40;
            this.dgvPartes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Seleccionar});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPartes.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvPartes.EnableHeadersVisualStyles = false;
            this.dgvPartes.GridColor = System.Drawing.Color.WhiteSmoke;
            this.dgvPartes.Location = new System.Drawing.Point(10, 228);
            this.dgvPartes.MultiSelect = false;
            this.dgvPartes.Name = "dgvPartes";
            this.dgvPartes.ReadOnly = true;
            this.dgvPartes.RowHeadersVisible = false;
            this.dgvPartes.RowHeadersWidth = 50;
            this.dgvPartes.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvPartes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPartes.Size = new System.Drawing.Size(1310, 246);
            this.dgvPartes.TabIndex = 273;
            this.dgvPartes.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPartes_CellClick);
            this.dgvPartes.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPartes_CellClick);
            this.dgvPartes.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPartes_CellEnter);
            this.dgvPartes.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvPartes_CellFormatting);
            this.dgvPartes.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvPartes_CellMouseClick);
            this.dgvPartes.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvPartes_CurrentCellDirtyStateChanged);
            // 
            // Seleccionar
            // 
            this.Seleccionar.HeaderText = "selecciona";
            this.Seleccionar.Name = "Seleccionar";
            this.Seleccionar.ReadOnly = true;
            this.Seleccionar.Visible = false;
            // 
            // txtBuscar
            // 
            this.txtBuscar.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtBuscar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBuscar.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBuscar.FocusColor = System.Drawing.Color.Empty;
            this.txtBuscar.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtBuscar.ForeColor = System.Drawing.Color.Black;
            this.txtBuscar.Location = new System.Drawing.Point(131, 155);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Numerico = false;
            this.txtBuscar.Size = new System.Drawing.Size(391, 29);
            this.txtBuscar.TabIndex = 211;
            this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);
            // 
            // frmPartesHistorial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(250)))), ((int)(((byte)(251)))));
            this.ClientSize = new System.Drawing.Size(1332, 594);
            this.Controls.Add(this.cbPartesAnulados);
            this.Controls.Add(this.rbFechaProgramado);
            this.Controls.Add(this.lblFechaConsulta);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cboLocacion);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtpFechaDesde);
            this.Controls.Add(this.btnBuscarUsuario);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.dgvPartes);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.lblFechaHasta);
            this.Controls.Add(this.lblBuscar);
            this.Controls.Add(this.pnlInfoPartes);
            this.Controls.Add(this.dtpFechaHasta);
            this.Controls.Add(this.lblFechaDesde);
            this.Controls.Add(this.pnFooter);
            this.Controls.Add(this.rbFechaReclamo);
            this.Controls.Add(this.pnlHead);
            this.Controls.Add(this.rbFechaRealizado);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "frmPartesHistorial";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "c";
            this.Load += new System.EventHandler(this.frmConsultaDePartes_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmConsultaDePartes_KeyDown);
            this.pnlHead.ResumeLayout(false);
            this.pnlHead.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgReturn)).EndInit();
            this.pnFooter.ResumeLayout(false);
            this.pnFooter.PerformLayout();
            this.pnlInfoPartes.ResumeLayout(false);
            this.pnlInfoPartes.PerformLayout();
            this.cmsOpciones.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPartes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlHead;
        private System.Windows.Forms.PictureBox imgReturn;
        private System.Windows.Forms.Label lblTituloHeader;
        private Controles.dgv dgvPartes;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Seleccionar;
        private System.Windows.Forms.Panel pnFooter;
        private System.Windows.Forms.Label lblTotal;
        private Controles.progress pgCircular;
        private System.Windows.Forms.Label lblNparte;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.Label lblSolicitud;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Label lblLoc;
        private System.Windows.Forms.Label lblFechaRec;
        private System.Windows.Forms.Label lblFechaProg;
        private System.Windows.Forms.Label lblFechaRealizado;
        private Controles.boton btnBuscar;
        private textboxAdv txtBuscar;
        private System.Windows.Forms.Label lblFechaHasta;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.DateTimePicker dtpFechaHasta;
        private System.Windows.Forms.DateTimePicker dtpFechaDesde;
        private System.Windows.Forms.Label lblFechaDesde;
        private System.Windows.Forms.RadioButton rbFechaRealizado;
        private System.Windows.Forms.RadioButton rbFechaReclamo;
        private System.Windows.Forms.Label lblServicio;
        private System.Windows.Forms.Label lblSinEquipo;
        private System.Windows.Forms.Label lblSinTecnico;
        private System.Windows.Forms.Label lblRealizado;
        private System.Windows.Forms.Label lblReferencias;
        private System.Windows.Forms.Label lblAsignado;
        private System.Windows.Forms.Label lblLapsoTiempo;
        private System.Windows.Forms.Label lblSinTarjeta;
        private Controles.boton btnBuscarUsuario;
        private System.Windows.Forms.Label lblLocacion;
        private System.Windows.Forms.Label lbcorreo;
        private System.Windows.Forms.Label lbcuit;
        private System.Windows.Forms.Label LBNumero_documento;
        private System.Windows.Forms.Label LBApellido;
        private System.Windows.Forms.Panel pnlInfoPartes;
        private System.Windows.Forms.Label label1;
        private Controles.combo cboLocacion;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblFechaConsulta;
        private System.Windows.Forms.RadioButton rbFechaProgramado;
        private Controles.boton btnImprimirContrato;
        private System.Windows.Forms.CheckBox cbPartesAnulados;
        private System.Windows.Forms.ContextMenuStrip cmsOpciones;
        private System.Windows.Forms.ToolStripMenuItem asignarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuIpFija;
        private System.Windows.Forms.ToolStripMenuItem mnuTecnico;
        private System.Windows.Forms.ToolStripMenuItem mnuEquipos;
        private System.Windows.Forms.ToolStripMenuItem mnuTarjeta;
        private System.Windows.Forms.ToolStripMenuItem mnuReprogramar;
        private System.Windows.Forms.ToolStripMenuItem mnuConfirmar;
        private System.Windows.Forms.ToolStripMenuItem mnuAnular;
        private System.Windows.Forms.ToolStripMenuItem mnuSeguimiento;
        private System.Windows.Forms.ToolStripMenuItem mnuVerServicios;
        private System.Windows.Forms.ToolStripMenuItem mnuImprimir;
        private System.Windows.Forms.ToolStripMenuItem gPSToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuGpsEnviar;
        private System.Windows.Forms.ToolStripMenuItem mnuGpsObservacion;
        private System.Windows.Forms.ToolStripMenuItem mnuImprimirContrato;
        private System.Windows.Forms.ToolStripMenuItem mnuExportar;
        private System.Windows.Forms.ToolStripMenuItem crearNuevoParteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem probarCassToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem observacionesToolStripMenuItem;
    }
}