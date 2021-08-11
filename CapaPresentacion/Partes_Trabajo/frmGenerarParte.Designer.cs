namespace CapaPresentacion.Partes_Trabajo
{
    partial class frmGenerarParte
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
            this.lblTotal = new System.Windows.Forms.Label();
            this.pnFooter = new System.Windows.Forms.Panel();
            this.pgCircular = new CapaPresentacion.Controles.progress();
            this.lblSolicitud = new System.Windows.Forms.Label();
            this.lblDetalles = new System.Windows.Forms.Label();
            this.lblServiciosContratados = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblLocacion = new System.Windows.Forms.Label();
            this.imgReturn = new System.Windows.Forms.PictureBox();
            this.lblTituloHeader = new System.Windows.Forms.Label();
            this.lbcorreo = new System.Windows.Forms.Label();
            this.lbcuit = new System.Windows.Forms.Label();
            this.LBNumero_documento = new System.Windows.Forms.Label();
            this.LBApellido = new System.Windows.Forms.Label();
            this.bDocumento = new System.Windows.Forms.RadioButton();
            this.Bdomicilio = new System.Windows.Forms.RadioButton();
            this.bNombre = new System.Windows.Forms.RadioButton();
            this.bUsuario = new System.Windows.Forms.RadioButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dpFecha = new System.Windows.Forms.DateTimePicker();
            this.lblFechaReclamo = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lblCosto = new System.Windows.Forms.Label();
            this.lblInformacion = new System.Windows.Forms.Label();
            this.dgvServiciosContratados = new CapaPresentacion.Controles.dgv(this.components);
            this.btnBuscar = new CapaPresentacion.Controles.boton();
            this.txtbuscaraltura = new CapaPresentacion.textboxAdv();
            this.txtDetalle = new CapaPresentacion.textboxAdv();
            this.txtbusca = new CapaPresentacion.textboxAdv();
            this.cbFalla = new CapaPresentacion.Controles.combo(this.components);
            this.txtId = new CapaPresentacion.textboxAdv();
            this.btnGenerarParte = new CapaPresentacion.Controles.boton();
            this.chkCortadosRetirados = new System.Windows.Forms.CheckBox();
            this.pnFooter.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgReturn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvServiciosContratados)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.ForeColor = System.Drawing.Color.SlateGray;
            this.lblTotal.Location = new System.Drawing.Point(12, 2);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(148, 21);
            this.lblTotal.TabIndex = 13;
            this.lblTotal.Text = "Total de Registros: 0";
            // 
            // pnFooter
            // 
            this.pnFooter.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnFooter.Controls.Add(this.lblTotal);
            this.pnFooter.Controls.Add(this.pgCircular);
            this.pnFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnFooter.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.pnFooter.Location = new System.Drawing.Point(0, 543);
            this.pnFooter.Name = "pnFooter";
            this.pnFooter.Size = new System.Drawing.Size(980, 30);
            this.pnFooter.TabIndex = 137;
            // 
            // pgCircular
            // 
            this.pgCircular.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pgCircular.Location = new System.Drawing.Point(944, 2);
            this.pgCircular.Name = "pgCircular";
            this.pgCircular.Percentage = 0F;
            this.pgCircular.Rotation = CapaPresentacion.Controles.RotationType.CounterClockwise;
            this.pgCircular.Size = new System.Drawing.Size(24, 24);
            this.pgCircular.TabIndex = 0;
            // 
            // lblSolicitud
            // 
            this.lblSolicitud.AutoSize = true;
            this.lblSolicitud.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblSolicitud.ForeColor = System.Drawing.Color.Black;
            this.lblSolicitud.Location = new System.Drawing.Point(13, 345);
            this.lblSolicitud.Name = "lblSolicitud";
            this.lblSolicitud.Size = new System.Drawing.Size(73, 21);
            this.lblSolicitud.TabIndex = 139;
            this.lblSolicitud.Text = "Solicitud:";
            // 
            // lblDetalles
            // 
            this.lblDetalles.AutoSize = true;
            this.lblDetalles.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblDetalles.ForeColor = System.Drawing.Color.Black;
            this.lblDetalles.Location = new System.Drawing.Point(13, 427);
            this.lblDetalles.Name = "lblDetalles";
            this.lblDetalles.Size = new System.Drawing.Size(65, 21);
            this.lblDetalles.TabIndex = 141;
            this.lblDetalles.Text = "Detalle :";
            // 
            // lblServiciosContratados
            // 
            this.lblServiciosContratados.AutoSize = true;
            this.lblServiciosContratados.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblServiciosContratados.ForeColor = System.Drawing.Color.Black;
            this.lblServiciosContratados.Location = new System.Drawing.Point(14, 156);
            this.lblServiciosContratados.Name = "lblServiciosContratados";
            this.lblServiciosContratados.Size = new System.Drawing.Size(261, 21);
            this.lblServiciosContratados.TabIndex = 268;
            this.lblServiciosContratados.Text = "Servicios contratados por el usuario:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.panel1.Controls.Add(this.lblLocacion);
            this.panel1.Controls.Add(this.imgReturn);
            this.panel1.Controls.Add(this.lblTituloHeader);
            this.panel1.Controls.Add(this.lbcorreo);
            this.panel1.Controls.Add(this.lbcuit);
            this.panel1.Controls.Add(this.LBNumero_documento);
            this.panel1.Controls.Add(this.LBApellido);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(980, 105);
            this.panel1.TabIndex = 271;
            // 
            // lblLocacion
            // 
            this.lblLocacion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLocacion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.lblLocacion.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblLocacion.ForeColor = System.Drawing.Color.White;
            this.lblLocacion.Location = new System.Drawing.Point(663, 43);
            this.lblLocacion.Name = "lblLocacion";
            this.lblLocacion.Size = new System.Drawing.Size(301, 23);
            this.lblLocacion.TabIndex = 210;
            this.lblLocacion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.lblTituloHeader.Text = "Partes de trabajo";
            // 
            // lbcorreo
            // 
            this.lbcorreo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbcorreo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.lbcorreo.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lbcorreo.ForeColor = System.Drawing.Color.White;
            this.lbcorreo.Location = new System.Drawing.Point(521, 74);
            this.lbcorreo.Name = "lbcorreo";
            this.lbcorreo.Size = new System.Drawing.Size(447, 22);
            this.lbcorreo.TabIndex = 206;
            this.lbcorreo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbcuit
            // 
            this.lbcuit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbcuit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.lbcuit.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lbcuit.ForeColor = System.Drawing.Color.White;
            this.lbcuit.Location = new System.Drawing.Point(427, 43);
            this.lbcuit.Name = "lbcuit";
            this.lbcuit.Size = new System.Drawing.Size(230, 23);
            this.lbcuit.TabIndex = 205;
            this.lbcuit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LBNumero_documento
            // 
            this.LBNumero_documento.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LBNumero_documento.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.LBNumero_documento.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.LBNumero_documento.ForeColor = System.Drawing.Color.White;
            this.LBNumero_documento.Location = new System.Drawing.Point(525, 9);
            this.LBNumero_documento.Name = "LBNumero_documento";
            this.LBNumero_documento.Size = new System.Drawing.Size(220, 23);
            this.LBNumero_documento.TabIndex = 204;
            this.LBNumero_documento.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LBApellido
            // 
            this.LBApellido.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LBApellido.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.LBApellido.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.LBApellido.ForeColor = System.Drawing.Color.White;
            this.LBApellido.Location = new System.Drawing.Point(751, 9);
            this.LBApellido.Name = "LBApellido";
            this.LBApellido.Size = new System.Drawing.Size(217, 23);
            this.LBApellido.TabIndex = 201;
            this.LBApellido.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // bDocumento
            // 
            this.bDocumento.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bDocumento.AutoSize = true;
            this.bDocumento.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.bDocumento.ForeColor = System.Drawing.Color.Black;
            this.bDocumento.Location = new System.Drawing.Point(388, 114);
            this.bDocumento.Name = "bDocumento";
            this.bDocumento.Size = new System.Drawing.Size(52, 25);
            this.bDocumento.TabIndex = 3;
            this.bDocumento.TabStop = true;
            this.bDocumento.Text = "Dni";
            this.bDocumento.UseVisualStyleBackColor = true;
            // 
            // Bdomicilio
            // 
            this.Bdomicilio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Bdomicilio.AutoSize = true;
            this.Bdomicilio.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.Bdomicilio.ForeColor = System.Drawing.Color.Black;
            this.Bdomicilio.Location = new System.Drawing.Point(123, 114);
            this.Bdomicilio.Name = "Bdomicilio";
            this.Bdomicilio.Size = new System.Drawing.Size(94, 25);
            this.Bdomicilio.TabIndex = 2;
            this.Bdomicilio.TabStop = true;
            this.Bdomicilio.Text = "Domicilio";
            this.Bdomicilio.UseVisualStyleBackColor = true;
            // 
            // bNombre
            // 
            this.bNombre.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bNombre.AutoSize = true;
            this.bNombre.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.bNombre.ForeColor = System.Drawing.Color.Black;
            this.bNombre.Location = new System.Drawing.Point(223, 114);
            this.bNombre.Name = "bNombre";
            this.bNombre.Size = new System.Drawing.Size(159, 25);
            this.bNombre.TabIndex = 1;
            this.bNombre.TabStop = true;
            this.bNombre.Text = "Apellido y Nombre";
            this.bNombre.UseVisualStyleBackColor = true;
            // 
            // bUsuario
            // 
            this.bUsuario.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bUsuario.AutoSize = true;
            this.bUsuario.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.bUsuario.ForeColor = System.Drawing.Color.Black;
            this.bUsuario.Location = new System.Drawing.Point(36, 114);
            this.bUsuario.Name = "bUsuario";
            this.bUsuario.Size = new System.Drawing.Size(82, 25);
            this.bUsuario.TabIndex = 0;
            this.bUsuario.TabStop = true;
            this.bUsuario.Text = "Usuario";
            this.bUsuario.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackColor = System.Drawing.Color.Gainsboro;
            this.panel3.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.panel3.Location = new System.Drawing.Point(0, 335);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(992, 1);
            this.panel3.TabIndex = 272;
            // 
            // dpFecha
            // 
            this.dpFecha.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dpFecha.CalendarForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(84)))), ((int)(((byte)(101)))));
            this.dpFecha.CalendarTitleForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(84)))), ((int)(((byte)(101)))));
            this.dpFecha.CustomFormat = "";
            this.dpFecha.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.dpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dpFecha.Location = new System.Drawing.Point(860, 342);
            this.dpFecha.Name = "dpFecha";
            this.dpFecha.Size = new System.Drawing.Size(109, 29);
            this.dpFecha.TabIndex = 274;
            // 
            // lblFechaReclamo
            // 
            this.lblFechaReclamo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFechaReclamo.AutoSize = true;
            this.lblFechaReclamo.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblFechaReclamo.ForeColor = System.Drawing.Color.Black;
            this.lblFechaReclamo.Location = new System.Drawing.Point(716, 345);
            this.lblFechaReclamo.Name = "lblFechaReclamo";
            this.lblFechaReclamo.Size = new System.Drawing.Size(138, 21);
            this.lblFechaReclamo.TabIndex = 273;
            this.lblFechaReclamo.Text = "Fecha de reclamo :";
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.BackColor = System.Drawing.Color.Gainsboro;
            this.panel4.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.panel4.Location = new System.Drawing.Point(-4, 149);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(992, 1);
            this.panel4.TabIndex = 274;
            // 
            // lblCosto
            // 
            this.lblCosto.AutoSize = true;
            this.lblCosto.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblCosto.ForeColor = System.Drawing.Color.Black;
            this.lblCosto.Location = new System.Drawing.Point(14, 377);
            this.lblCosto.Name = "lblCosto";
            this.lblCosto.Size = new System.Drawing.Size(53, 21);
            this.lblCosto.TabIndex = 275;
            this.lblCosto.Text = "Costo:";
            // 
            // lblInformacion
            // 
            this.lblInformacion.AutoSize = true;
            this.lblInformacion.Font = new System.Drawing.Font("Segoe UI Light", 12F);
            this.lblInformacion.ForeColor = System.Drawing.Color.SlateGray;
            this.lblInformacion.Location = new System.Drawing.Point(13, 398);
            this.lblInformacion.Name = "lblInformacion";
            this.lblInformacion.Size = new System.Drawing.Size(575, 21);
            this.lblInformacion.TabIndex = 313;
            this.lblInformacion.Text = "*Al elegir ASIGNACIÓN DE EQUIPO, los precios de los equipos se adicionarán al cos" +
    "to";
            // 
            // dgvServiciosContratados
            // 
            this.dgvServiciosContratados.AllowUserToAddRows = false;
            this.dgvServiciosContratados.AllowUserToDeleteRows = false;
            this.dgvServiciosContratados.AllowUserToOrderColumns = true;
            this.dgvServiciosContratados.AllowUserToResizeColumns = false;
            this.dgvServiciosContratados.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvServiciosContratados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvServiciosContratados.BackgroundColor = System.Drawing.Color.White;
            this.dgvServiciosContratados.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvServiciosContratados.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSlateGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvServiciosContratados.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvServiciosContratados.ColumnHeadersHeight = 40;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvServiciosContratados.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvServiciosContratados.EnableHeadersVisualStyles = false;
            this.dgvServiciosContratados.GridColor = System.Drawing.Color.WhiteSmoke;
            this.dgvServiciosContratados.Location = new System.Drawing.Point(14, 180);
            this.dgvServiciosContratados.MultiSelect = false;
            this.dgvServiciosContratados.Name = "dgvServiciosContratados";
            this.dgvServiciosContratados.ReadOnly = true;
            this.dgvServiciosContratados.RowHeadersVisible = false;
            this.dgvServiciosContratados.RowHeadersWidth = 50;
            this.dgvServiciosContratados.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvServiciosContratados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvServiciosContratados.Size = new System.Drawing.Size(954, 149);
            this.dgvServiciosContratados.TabIndex = 311;
            this.dgvServiciosContratados.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvServiciosContratados_CellEnter);
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
            this.btnBuscar.Image = global::CapaPresentacion.Properties.Resources.Business_Man_Search_32;
            this.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBuscar.Location = new System.Drawing.Point(671, 109);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(146, 34);
            this.btnBuscar.TabIndex = 6;
            this.btnBuscar.Text = "Buscar usuario";
            this.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txtbuscaraltura
            // 
            this.txtbuscaraltura.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtbuscaraltura.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtbuscaraltura.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtbuscaraltura.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtbuscaraltura.FocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.txtbuscaraltura.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtbuscaraltura.ForeColor = System.Drawing.Color.DimGray;
            this.txtbuscaraltura.Location = new System.Drawing.Point(619, 114);
            this.txtbuscaraltura.Name = "txtbuscaraltura";
            this.txtbuscaraltura.Numerico = true;
            this.txtbuscaraltura.Size = new System.Drawing.Size(38, 29);
            this.txtbuscaraltura.TabIndex = 5;
            this.txtbuscaraltura.Tag = "\"\"";
            this.txtbuscaraltura.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtDetalle
            // 
            this.txtDetalle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDetalle.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtDetalle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDetalle.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDetalle.FocusColor = System.Drawing.Color.Empty;
            this.txtDetalle.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtDetalle.ForeColor = System.Drawing.Color.DimGray;
            this.txtDetalle.Location = new System.Drawing.Point(17, 451);
            this.txtDetalle.Multiline = true;
            this.txtDetalle.Name = "txtDetalle";
            this.txtDetalle.Numerico = false;
            this.txtDetalle.Size = new System.Drawing.Size(951, 74);
            this.txtDetalle.TabIndex = 142;
            // 
            // txtbusca
            // 
            this.txtbusca.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtbusca.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtbusca.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtbusca.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtbusca.FocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.txtbusca.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtbusca.ForeColor = System.Drawing.Color.DimGray;
            this.txtbusca.Location = new System.Drawing.Point(446, 114);
            this.txtbusca.Name = "txtbusca";
            this.txtbusca.Numerico = false;
            this.txtbusca.Size = new System.Drawing.Size(172, 29);
            this.txtbusca.TabIndex = 4;
            this.txtbusca.Tag = "\"\"";
            // 
            // cbFalla
            // 
            this.cbFalla.BorderColor = System.Drawing.Color.Gainsboro;
            this.cbFalla.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFalla.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbFalla.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cbFalla.FormattingEnabled = true;
            this.cbFalla.Location = new System.Drawing.Point(92, 342);
            this.cbFalla.Name = "cbFalla";
            this.cbFalla.Size = new System.Drawing.Size(319, 29);
            this.cbFalla.TabIndex = 140;
            this.cbFalla.SelectedValueChanged += new System.EventHandler(this.cbFalla_SelectedValueChanged);
            // 
            // txtId
            // 
            this.txtId.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtId.FocusColor = System.Drawing.Color.Empty;
            this.txtId.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtId.ForeColor = System.Drawing.Color.DimGray;
            this.txtId.Location = new System.Drawing.Point(-50, 72);
            this.txtId.Name = "txtId";
            this.txtId.Numerico = false;
            this.txtId.Size = new System.Drawing.Size(27, 22);
            this.txtId.TabIndex = 135;
            // 
            // btnGenerarParte
            // 
            this.btnGenerarParte.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGenerarParte.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnGenerarParte.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGenerarParte.Enabled = false;
            this.btnGenerarParte.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnGenerarParte.FlatAppearance.BorderSize = 0;
            this.btnGenerarParte.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnGenerarParte.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnGenerarParte.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerarParte.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnGenerarParte.ForeColor = System.Drawing.Color.White;
            this.btnGenerarParte.Image = global::CapaPresentacion.Properties.Resources.Data_Add_32;
            this.btnGenerarParte.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGenerarParte.Location = new System.Drawing.Point(823, 109);
            this.btnGenerarParte.Name = "btnGenerarParte";
            this.btnGenerarParte.Size = new System.Drawing.Size(146, 34);
            this.btnGenerarParte.TabIndex = 134;
            this.btnGenerarParte.Text = "Generar Parte";
            this.btnGenerarParte.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGenerarParte.UseVisualStyleBackColor = false;
            this.btnGenerarParte.Click += new System.EventHandler(this.btnGenerarParte_Click);
            // 
            // chkCortadosRetirados
            // 
            this.chkCortadosRetirados.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkCortadosRetirados.AutoSize = true;
            this.chkCortadosRetirados.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.chkCortadosRetirados.Location = new System.Drawing.Point(683, 156);
            this.chkCortadosRetirados.Name = "chkCortadosRetirados";
            this.chkCortadosRetirados.Size = new System.Drawing.Size(290, 25);
            this.chkCortadosRetirados.TabIndex = 314;
            this.chkCortadosRetirados.Text = "Mostrar servicios retirados y cortados";
            this.chkCortadosRetirados.UseVisualStyleBackColor = true;
            this.chkCortadosRetirados.Visible = false;
            this.chkCortadosRetirados.CheckedChanged += new System.EventHandler(this.chkCortadosRetirados_CheckedChanged);
            // 
            // frmGenerarParte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(250)))), ((int)(((byte)(251)))));
            this.ClientSize = new System.Drawing.Size(980, 573);
            this.Controls.Add(this.chkCortadosRetirados);
            this.Controls.Add(this.lblInformacion);
            this.Controls.Add(this.dgvServiciosContratados);
            this.Controls.Add(this.lblCosto);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.dpFecha);
            this.Controls.Add(this.lblFechaReclamo);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.txtbuscaraltura);
            this.Controls.Add(this.lblServiciosContratados);
            this.Controls.Add(this.bDocumento);
            this.Controls.Add(this.txtDetalle);
            this.Controls.Add(this.txtbusca);
            this.Controls.Add(this.Bdomicilio);
            this.Controls.Add(this.lblDetalles);
            this.Controls.Add(this.bNombre);
            this.Controls.Add(this.cbFalla);
            this.Controls.Add(this.bUsuario);
            this.Controls.Add(this.lblSolicitud);
            this.Controls.Add(this.pnFooter);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.btnGenerarParte);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "frmGenerarParte";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmCrearParte";
            this.Load += new System.EventHandler(this.frmCrearParte_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmCrearParte_KeyDown);
            this.pnFooter.ResumeLayout(false);
            this.pnFooter.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgReturn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvServiciosContratados)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Controles.boton btnGenerarParte;
        public textboxAdv txtId;
        private System.Windows.Forms.Label lblTotal;
        private Controles.progress pgCircular;
        private System.Windows.Forms.Panel pnFooter;
        private Controles.combo cbFalla;
        private System.Windows.Forms.Label lblSolicitud;
        private System.Windows.Forms.Label lblDetalles;
        private textboxAdv txtDetalle;
        private System.Windows.Forms.Label lblServiciosContratados;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbcorreo;
        private System.Windows.Forms.Label lbcuit;
        private System.Windows.Forms.Label LBNumero_documento;
        private Controles.boton btnBuscar;
        private textboxAdv txtbuscaraltura;
        private System.Windows.Forms.Label LBApellido;
        private System.Windows.Forms.RadioButton bDocumento;
        private textboxAdv txtbusca;
        private System.Windows.Forms.RadioButton Bdomicilio;
        private System.Windows.Forms.RadioButton bNombre;
        private System.Windows.Forms.RadioButton bUsuario;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DateTimePicker dpFecha;
        private System.Windows.Forms.Label lblFechaReclamo;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.PictureBox imgReturn;
        private System.Windows.Forms.Label lblTituloHeader;
        private System.Windows.Forms.Label lblLocacion;
        private System.Windows.Forms.Label lblCosto;
        private Controles.dgv dgvServiciosContratados;
        private System.Windows.Forms.Label lblInformacion;
        private System.Windows.Forms.CheckBox chkCortadosRetirados;
    }
}