namespace CapaPresentacion.Partes_Trabajo
{
    partial class frmEquiposCambio
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblLocacion = new System.Windows.Forms.Label();
            this.imgReturn = new System.Windows.Forms.PictureBox();
            this.lblTituloHeader = new System.Windows.Forms.Label();
            this.lbcorreo = new System.Windows.Forms.Label();
            this.lbcuit = new System.Windows.Forms.Label();
            this.LBNumero_documento = new System.Windows.Forms.Label();
            this.LBApellido = new System.Windows.Forms.Label();
            this.lblServicios = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lblEquipos = new System.Windows.Forms.Label();
            this.pnFooter = new System.Windows.Forms.Panel();
            this.lblTotal = new System.Windows.Forms.Label();
            this.pgCircular = new CapaPresentacion.Controles.progress();
            this.lblCosto = new System.Windows.Forms.Label();
            this.chkCobrar = new System.Windows.Forms.CheckBox();
            this.dgvEquipos = new CapaPresentacion.Controles.dgv(this.components);
            this.btnBuscar = new CapaPresentacion.Controles.boton();
            this.btnGenerarCambio = new CapaPresentacion.Controles.boton();
            this.dgvServiciosConEquipos = new CapaPresentacion.Controles.dgv(this.components);
            this.lblCostoTexto = new System.Windows.Forms.Label();
            this.pnlTipoEquipos = new System.Windows.Forms.Panel();
            this.btnCanelar = new CapaPresentacion.Controles.boton();
            this.btnAceptarTipoEquipo = new CapaPresentacion.Controles.boton();
            this.label1 = new System.Windows.Forms.Label();
            this.cboTiposEquipos = new CapaPresentacion.Controles.combo(this.components);
            this.panel3 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblTipoEquiposTitulo = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgReturn)).BeginInit();
            this.pnFooter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEquipos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvServiciosConEquipos)).BeginInit();
            this.pnlTipoEquipos.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
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
            this.panel1.Size = new System.Drawing.Size(951, 105);
            this.panel1.TabIndex = 272;
            // 
            // lblLocacion
            // 
            this.lblLocacion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLocacion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.lblLocacion.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblLocacion.ForeColor = System.Drawing.Color.White;
            this.lblLocacion.Location = new System.Drawing.Point(634, 43);
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
            this.lblTituloHeader.Text = "Solicitud de cambio de equipos";
            // 
            // lbcorreo
            // 
            this.lbcorreo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbcorreo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.lbcorreo.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lbcorreo.ForeColor = System.Drawing.Color.White;
            this.lbcorreo.Location = new System.Drawing.Point(492, 74);
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
            this.lbcuit.Location = new System.Drawing.Point(398, 43);
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
            this.LBNumero_documento.Location = new System.Drawing.Point(496, 9);
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
            this.LBApellido.Location = new System.Drawing.Point(722, 9);
            this.LBApellido.Name = "LBApellido";
            this.LBApellido.Size = new System.Drawing.Size(217, 23);
            this.LBApellido.TabIndex = 201;
            this.LBApellido.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblServicios
            // 
            this.lblServicios.AutoSize = true;
            this.lblServicios.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblServicios.ForeColor = System.Drawing.Color.Black;
            this.lblServicios.Location = new System.Drawing.Point(7, 174);
            this.lblServicios.Name = "lblServicios";
            this.lblServicios.Size = new System.Drawing.Size(404, 21);
            this.lblServicios.TabIndex = 313;
            this.lblServicios.Text = "Servicios contratados por el usuario que poseen equipos:";
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.BackColor = System.Drawing.Color.Gainsboro;
            this.panel4.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.panel4.Location = new System.Drawing.Point(0, 154);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(992, 1);
            this.panel4.TabIndex = 314;
            // 
            // lblEquipos
            // 
            this.lblEquipos.AutoSize = true;
            this.lblEquipos.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblEquipos.ForeColor = System.Drawing.Color.Black;
            this.lblEquipos.Location = new System.Drawing.Point(12, 387);
            this.lblEquipos.Name = "lblEquipos";
            this.lblEquipos.Size = new System.Drawing.Size(306, 21);
            this.lblEquipos.TabIndex = 318;
            this.lblEquipos.Text = "Equipos asociados al servicio seleccionado:";
            // 
            // pnFooter
            // 
            this.pnFooter.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnFooter.Controls.Add(this.lblTotal);
            this.pnFooter.Controls.Add(this.pgCircular);
            this.pnFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnFooter.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.pnFooter.Location = new System.Drawing.Point(0, 549);
            this.pnFooter.Name = "pnFooter";
            this.pnFooter.Size = new System.Drawing.Size(951, 30);
            this.pnFooter.TabIndex = 320;
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
            // pgCircular
            // 
            this.pgCircular.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pgCircular.Location = new System.Drawing.Point(915, 2);
            this.pgCircular.Name = "pgCircular";
            this.pgCircular.Percentage = 0F;
            this.pgCircular.Rotation = CapaPresentacion.Controles.RotationType.CounterClockwise;
            this.pgCircular.Size = new System.Drawing.Size(24, 24);
            this.pgCircular.TabIndex = 0;
            // 
            // lblCosto
            // 
            this.lblCosto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCosto.AutoSize = true;
            this.lblCosto.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblCosto.ForeColor = System.Drawing.Color.Black;
            this.lblCosto.Location = new System.Drawing.Point(519, 121);
            this.lblCosto.Name = "lblCosto";
            this.lblCosto.Size = new System.Drawing.Size(0, 21);
            this.lblCosto.TabIndex = 321;
            // 
            // chkCobrar
            // 
            this.chkCobrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkCobrar.AutoSize = true;
            this.chkCobrar.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.chkCobrar.Location = new System.Drawing.Point(586, 121);
            this.chkCobrar.Name = "chkCobrar";
            this.chkCobrar.Size = new System.Drawing.Size(77, 25);
            this.chkCobrar.TabIndex = 322;
            this.chkCobrar.Text = "Cobrar";
            this.chkCobrar.UseVisualStyleBackColor = true;
            // 
            // dgvEquipos
            // 
            this.dgvEquipos.AllowUserToAddRows = false;
            this.dgvEquipos.AllowUserToDeleteRows = false;
            this.dgvEquipos.AllowUserToOrderColumns = true;
            this.dgvEquipos.AllowUserToResizeColumns = false;
            this.dgvEquipos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvEquipos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvEquipos.BackgroundColor = System.Drawing.Color.White;
            this.dgvEquipos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvEquipos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSlateGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvEquipos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvEquipos.ColumnHeadersHeight = 40;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvEquipos.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvEquipos.EnableHeadersVisualStyles = false;
            this.dgvEquipos.GridColor = System.Drawing.Color.WhiteSmoke;
            this.dgvEquipos.Location = new System.Drawing.Point(12, 411);
            this.dgvEquipos.MultiSelect = false;
            this.dgvEquipos.Name = "dgvEquipos";
            this.dgvEquipos.ReadOnly = true;
            this.dgvEquipos.RowHeadersVisible = false;
            this.dgvEquipos.RowHeadersWidth = 50;
            this.dgvEquipos.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvEquipos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEquipos.Size = new System.Drawing.Size(928, 132);
            this.dgvEquipos.TabIndex = 317;
            this.dgvEquipos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEquipos_CellContentClick);
            this.dgvEquipos.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEquipos_CellEnter);
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
            this.btnBuscar.Location = new System.Drawing.Point(786, 158);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(153, 34);
            this.btnBuscar.TabIndex = 315;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnGenerarCambio
            // 
            this.btnGenerarCambio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGenerarCambio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnGenerarCambio.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGenerarCambio.Enabled = false;
            this.btnGenerarCambio.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnGenerarCambio.FlatAppearance.BorderSize = 0;
            this.btnGenerarCambio.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnGenerarCambio.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnGenerarCambio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerarCambio.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnGenerarCambio.ForeColor = System.Drawing.Color.White;
            this.btnGenerarCambio.Image = global::CapaPresentacion.Properties.Resources.Data_Add_32;
            this.btnGenerarCambio.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGenerarCambio.Location = new System.Drawing.Point(681, 114);
            this.btnGenerarCambio.Name = "btnGenerarCambio";
            this.btnGenerarCambio.Size = new System.Drawing.Size(259, 34);
            this.btnGenerarCambio.TabIndex = 316;
            this.btnGenerarCambio.Text = "Generar de cambio de equipo";
            this.btnGenerarCambio.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGenerarCambio.UseVisualStyleBackColor = false;
            this.btnGenerarCambio.Click += new System.EventHandler(this.btnGenerarCambio_Click);
            // 
            // dgvServiciosConEquipos
            // 
            this.dgvServiciosConEquipos.AllowUserToAddRows = false;
            this.dgvServiciosConEquipos.AllowUserToDeleteRows = false;
            this.dgvServiciosConEquipos.AllowUserToOrderColumns = true;
            this.dgvServiciosConEquipos.AllowUserToResizeColumns = false;
            this.dgvServiciosConEquipos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvServiciosConEquipos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvServiciosConEquipos.BackgroundColor = System.Drawing.Color.White;
            this.dgvServiciosConEquipos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvServiciosConEquipos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.LightSlateGray;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvServiciosConEquipos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvServiciosConEquipos.ColumnHeadersHeight = 40;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvServiciosConEquipos.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvServiciosConEquipos.EnableHeadersVisualStyles = false;
            this.dgvServiciosConEquipos.GridColor = System.Drawing.Color.WhiteSmoke;
            this.dgvServiciosConEquipos.Location = new System.Drawing.Point(12, 198);
            this.dgvServiciosConEquipos.MultiSelect = false;
            this.dgvServiciosConEquipos.Name = "dgvServiciosConEquipos";
            this.dgvServiciosConEquipos.ReadOnly = true;
            this.dgvServiciosConEquipos.RowHeadersVisible = false;
            this.dgvServiciosConEquipos.RowHeadersWidth = 50;
            this.dgvServiciosConEquipos.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvServiciosConEquipos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvServiciosConEquipos.Size = new System.Drawing.Size(928, 177);
            this.dgvServiciosConEquipos.TabIndex = 312;
            this.dgvServiciosConEquipos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvServiciosConEquipos_CellClick);
            this.dgvServiciosConEquipos.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvServiciosConEquipos_CellEnter);
            this.dgvServiciosConEquipos.SelectionChanged += new System.EventHandler(this.dgvServiciosConEquipos_SelectionChanged);
            // 
            // lblCostoTexto
            // 
            this.lblCostoTexto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCostoTexto.AutoSize = true;
            this.lblCostoTexto.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblCostoTexto.ForeColor = System.Drawing.Color.Black;
            this.lblCostoTexto.Location = new System.Drawing.Point(445, 122);
            this.lblCostoTexto.Name = "lblCostoTexto";
            this.lblCostoTexto.Size = new System.Drawing.Size(57, 21);
            this.lblCostoTexto.TabIndex = 323;
            this.lblCostoTexto.Text = "Costo: ";
            // 
            // pnlTipoEquipos
            // 
            this.pnlTipoEquipos.Controls.Add(this.btnCanelar);
            this.pnlTipoEquipos.Controls.Add(this.btnAceptarTipoEquipo);
            this.pnlTipoEquipos.Controls.Add(this.label1);
            this.pnlTipoEquipos.Controls.Add(this.cboTiposEquipos);
            this.pnlTipoEquipos.Controls.Add(this.panel3);
            this.pnlTipoEquipos.Location = new System.Drawing.Point(282, 219);
            this.pnlTipoEquipos.Name = "pnlTipoEquipos";
            this.pnlTipoEquipos.Size = new System.Drawing.Size(434, 238);
            this.pnlTipoEquipos.TabIndex = 324;
            this.pnlTipoEquipos.Visible = false;
            // 
            // btnCanelar
            // 
            this.btnCanelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCanelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnCanelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCanelar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnCanelar.FlatAppearance.BorderSize = 0;
            this.btnCanelar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnCanelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnCanelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCanelar.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnCanelar.ForeColor = System.Drawing.Color.White;
            this.btnCanelar.Image = global::CapaPresentacion.Properties.Resources.Command_Undo_32;
            this.btnCanelar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCanelar.Location = new System.Drawing.Point(184, 192);
            this.btnCanelar.Name = "btnCanelar";
            this.btnCanelar.Size = new System.Drawing.Size(114, 34);
            this.btnCanelar.TabIndex = 326;
            this.btnCanelar.Text = "Cancelar";
            this.btnCanelar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCanelar.UseVisualStyleBackColor = false;
            this.btnCanelar.Click += new System.EventHandler(this.btnCanelar_Click);
            // 
            // btnAceptarTipoEquipo
            // 
            this.btnAceptarTipoEquipo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAceptarTipoEquipo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnAceptarTipoEquipo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAceptarTipoEquipo.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnAceptarTipoEquipo.FlatAppearance.BorderSize = 0;
            this.btnAceptarTipoEquipo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnAceptarTipoEquipo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnAceptarTipoEquipo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAceptarTipoEquipo.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnAceptarTipoEquipo.ForeColor = System.Drawing.Color.White;
            this.btnAceptarTipoEquipo.Image = global::CapaPresentacion.Properties.Resources.Data_Add_32;
            this.btnAceptarTipoEquipo.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAceptarTipoEquipo.Location = new System.Drawing.Point(304, 192);
            this.btnAceptarTipoEquipo.Name = "btnAceptarTipoEquipo";
            this.btnAceptarTipoEquipo.Size = new System.Drawing.Size(127, 34);
            this.btnAceptarTipoEquipo.TabIndex = 325;
            this.btnAceptarTipoEquipo.Text = "Aceptar";
            this.btnAceptarTipoEquipo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAceptarTipoEquipo.UseVisualStyleBackColor = false;
            this.btnAceptarTipoEquipo.Click += new System.EventHandler(this.btnAceptarTipoEquipo_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(28, 103);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 21);
            this.label1.TabIndex = 325;
            this.label1.Text = "Tipo de equipo";
            // 
            // cboTiposEquipos
            // 
            this.cboTiposEquipos.BorderColor = System.Drawing.Color.Gainsboro;
            this.cboTiposEquipos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTiposEquipos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboTiposEquipos.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTiposEquipos.FormattingEnabled = true;
            this.cboTiposEquipos.Location = new System.Drawing.Point(31, 127);
            this.cboTiposEquipos.Name = "cboTiposEquipos";
            this.cboTiposEquipos.Size = new System.Drawing.Size(315, 29);
            this.cboTiposEquipos.TabIndex = 322;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.panel3.Controls.Add(this.pictureBox1);
            this.panel3.Controls.Add(this.lblTipoEquiposTitulo);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(434, 73);
            this.panel3.TabIndex = 273;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = global::CapaPresentacion.Properties.Resources.Left_Arrow_32;
            this.pictureBox1.Location = new System.Drawing.Point(11, 18);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 209;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // lblTipoEquiposTitulo
            // 
            this.lblTipoEquiposTitulo.Font = new System.Drawing.Font("Segoe UI Light", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipoEquiposTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTipoEquiposTitulo.Location = new System.Drawing.Point(49, 23);
            this.lblTipoEquiposTitulo.Name = "lblTipoEquiposTitulo";
            this.lblTipoEquiposTitulo.Size = new System.Drawing.Size(152, 27);
            this.lblTipoEquiposTitulo.TabIndex = 208;
            this.lblTipoEquiposTitulo.Text = "Tipo de equipo";
            // 
            // frmEquiposCambio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(250)))), ((int)(((byte)(251)))));
            this.ClientSize = new System.Drawing.Size(951, 579);
            this.Controls.Add(this.pnlTipoEquipos);
            this.Controls.Add(this.lblCostoTexto);
            this.Controls.Add(this.chkCobrar);
            this.Controls.Add(this.lblCosto);
            this.Controls.Add(this.pnFooter);
            this.Controls.Add(this.lblEquipos);
            this.Controls.Add(this.dgvEquipos);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.btnGenerarCambio);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.lblServicios);
            this.Controls.Add(this.dgvServiciosConEquipos);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "frmEquiposCambio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmEquiposCambio";
            this.Load += new System.EventHandler(this.frmEquiposCambio_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmEquiposCambio_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgReturn)).EndInit();
            this.pnFooter.ResumeLayout(false);
            this.pnFooter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEquipos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvServiciosConEquipos)).EndInit();
            this.pnlTipoEquipos.ResumeLayout(false);
            this.pnlTipoEquipos.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblLocacion;
        private System.Windows.Forms.PictureBox imgReturn;
        private System.Windows.Forms.Label lblTituloHeader;
        private System.Windows.Forms.Label lbcorreo;
        private System.Windows.Forms.Label lbcuit;
        private System.Windows.Forms.Label LBNumero_documento;
        private System.Windows.Forms.Label LBApellido;
        private Controles.dgv dgvServiciosConEquipos;
        private System.Windows.Forms.Label lblServicios;
        private System.Windows.Forms.Panel panel4;
        private Controles.boton btnBuscar;
        private Controles.boton btnGenerarCambio;
        private Controles.dgv dgvEquipos;
        private System.Windows.Forms.Label lblEquipos;
        private System.Windows.Forms.Panel pnFooter;
        private System.Windows.Forms.Label lblTotal;
        private Controles.progress pgCircular;
        private System.Windows.Forms.Label lblCosto;
        private System.Windows.Forms.CheckBox chkCobrar;
        private System.Windows.Forms.Label lblCostoTexto;
        private System.Windows.Forms.Panel pnlTipoEquipos;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblTipoEquiposTitulo;
        private Controles.boton btnAceptarTipoEquipo;
        private System.Windows.Forms.Label label1;
        private Controles.combo cboTiposEquipos;
        private Controles.boton btnCanelar;
    }
}