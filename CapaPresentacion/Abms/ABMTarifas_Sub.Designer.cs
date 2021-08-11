namespace CapaPresentacion.Abms
{
    partial class ABMTarifas_Sub
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
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblInformacion = new System.Windows.Forms.Label();
            this.pgCircular = new CapaPresentacion.Controles.progress();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblTipo_Facturacion = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.imgReturn = new System.Windows.Forms.PictureBox();
            this.lblTituloHeader = new System.Windows.Forms.Label();
            this.lbltitulo = new System.Windows.Forms.Label();
            this.lblServicios = new System.Windows.Forms.Label();
            this.lblsubservicios = new System.Windows.Forms.Label();
            this.btnEspeciales = new CapaPresentacion.Controles.boton();
            this.dgvServicios = new CapaPresentacion.Controles.dgv(this.components);
            this.cboTipo_Facturacion = new CapaPresentacion.Controles.combo(this.components);
            this.txtHasta = new CapaPresentacion.Controles.textboxMask();
            this.txtDesde = new CapaPresentacion.Controles.textboxMask();
            this.cboGrupoServicios = new CapaPresentacion.Controles.combo(this.components);
            this.btnActualizar = new CapaPresentacion.Controles.boton();
            this.dgvSubServicios = new CapaPresentacion.Controles.dgv(this.components);
            this.btnGuardar = new CapaPresentacion.Controles.boton();
            this.cboTarifas = new CapaPresentacion.Controles.combo(this.components);
            this.lblServicioSeleccinado = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pnFooter.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgReturn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvServicios)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSubServicios)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnFooter
            // 
            this.pnFooter.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnFooter.Controls.Add(this.lblTotal);
            this.pnFooter.Controls.Add(this.lblInformacion);
            this.pnFooter.Controls.Add(this.pgCircular);
            this.pnFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnFooter.Location = new System.Drawing.Point(0, 621);
            this.pnFooter.Name = "pnFooter";
            this.pnFooter.Size = new System.Drawing.Size(1191, 30);
            this.pnFooter.TabIndex = 2;
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
            // lblInformacion
            // 
            this.lblInformacion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblInformacion.AutoSize = true;
            this.lblInformacion.Font = new System.Drawing.Font("Segoe UI Light", 12F);
            this.lblInformacion.ForeColor = System.Drawing.Color.Red;
            this.lblInformacion.Location = new System.Drawing.Point(687, 4);
            this.lblInformacion.Name = "lblInformacion";
            this.lblInformacion.Size = new System.Drawing.Size(430, 21);
            this.lblInformacion.TabIndex = 331;
            this.lblInformacion.Text = "*Recuerde guardar las modificaciones realizadas en los montos.";
            // 
            // pgCircular
            // 
            this.pgCircular.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pgCircular.Location = new System.Drawing.Point(1155, 2);
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
            this.panel1.Location = new System.Drawing.Point(0, 183);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1191, 1);
            this.panel1.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(506, 116);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 21);
            this.label1.TabIndex = 31;
            this.label1.Text = "Grupo de Servicios:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(94, 152);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 21);
            this.label2.TabIndex = 33;
            this.label2.Text = "Desde:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(262, 152);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 21);
            this.label3.TabIndex = 35;
            this.label3.Text = "Hasta:";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.ForeColor = System.Drawing.Color.Black;
            this.lblNombre.Location = new System.Drawing.Point(10, 117);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(50, 21);
            this.lblNombre.TabIndex = 9;
            this.lblNombre.Text = "Tarifa:";
            // 
            // lblTipo_Facturacion
            // 
            this.lblTipo_Facturacion.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipo_Facturacion.ForeColor = System.Drawing.Color.Black;
            this.lblTipo_Facturacion.Location = new System.Drawing.Point(506, 149);
            this.lblTipo_Facturacion.Name = "lblTipo_Facturacion";
            this.lblTipo_Facturacion.Size = new System.Drawing.Size(140, 21);
            this.lblTipo_Facturacion.TabIndex = 40;
            this.lblTipo_Facturacion.Text = "Zonas:";
            this.lblTipo_Facturacion.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.panel3.Controls.Add(this.imgReturn);
            this.panel3.Controls.Add(this.lblTituloHeader);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1191, 75);
            this.panel3.TabIndex = 54;
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
            this.lblTituloHeader.Text = "Tarifas de Servicios";
            // 
            // lbltitulo
            // 
            this.lbltitulo.AutoSize = true;
            this.lbltitulo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltitulo.ForeColor = System.Drawing.Color.Black;
            this.lbltitulo.Location = new System.Drawing.Point(8, 78);
            this.lbltitulo.Name = "lbltitulo";
            this.lbltitulo.Size = new System.Drawing.Size(702, 21);
            this.lbltitulo.TabIndex = 215;
            this.lbltitulo.Text = "Determine la tarifa, grupo de servicios y zona o categoría sobre las que desea co" +
    "nsultar los servicios:";
            // 
            // lblServicios
            // 
            this.lblServicios.AutoSize = true;
            this.lblServicios.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblServicios.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblServicios.ForeColor = System.Drawing.Color.Black;
            this.lblServicios.Location = new System.Drawing.Point(0, 0);
            this.lblServicios.Name = "lblServicios";
            this.lblServicios.Size = new System.Drawing.Size(75, 21);
            this.lblServicios.TabIndex = 216;
            this.lblServicios.Text = "Servicios:";
            // 
            // lblsubservicios
            // 
            this.lblsubservicios.AutoSize = true;
            this.lblsubservicios.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblsubservicios.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblsubservicios.ForeColor = System.Drawing.Color.Black;
            this.lblsubservicios.Location = new System.Drawing.Point(0, 0);
            this.lblsubservicios.Name = "lblsubservicios";
            this.lblsubservicios.Size = new System.Drawing.Size(664, 21);
            this.lblsubservicios.TabIndex = 217;
            this.lblsubservicios.Text = "Seleccione y edite los montos de los sub servicios para la tarifa y zona/categorí" +
    "a seleccionadas:";
            // 
            // btnEspeciales
            // 
            this.btnEspeciales.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEspeciales.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnEspeciales.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEspeciales.Enabled = false;
            this.btnEspeciales.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnEspeciales.FlatAppearance.BorderSize = 0;
            this.btnEspeciales.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnEspeciales.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnEspeciales.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEspeciales.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEspeciales.ForeColor = System.Drawing.Color.White;
            this.btnEspeciales.Image = global::CapaPresentacion.Properties.Resources.Data_Edit_32;
            this.btnEspeciales.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEspeciales.Location = new System.Drawing.Point(960, 582);
            this.btnEspeciales.Name = "btnEspeciales";
            this.btnEspeciales.Size = new System.Drawing.Size(105, 35);
            this.btnEspeciales.TabIndex = 214;
            this.btnEspeciales.Text = "Especiales";
            this.btnEspeciales.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEspeciales.UseVisualStyleBackColor = false;
            this.btnEspeciales.Click += new System.EventHandler(this.btnTarifas_Click);
            // 
            // dgvServicios
            // 
            this.dgvServicios.AllowUserToAddRows = false;
            this.dgvServicios.AllowUserToDeleteRows = false;
            this.dgvServicios.AllowUserToOrderColumns = true;
            this.dgvServicios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvServicios.BackgroundColor = System.Drawing.Color.White;
            this.dgvServicios.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvServicios.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvServicios.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvServicios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvServicios.Enabled = false;
            this.dgvServicios.EnableHeadersVisualStyles = false;
            this.dgvServicios.GridColor = System.Drawing.Color.WhiteSmoke;
            this.dgvServicios.Location = new System.Drawing.Point(0, 32);
            this.dgvServicios.MultiSelect = false;
            this.dgvServicios.Name = "dgvServicios";
            this.dgvServicios.ReadOnly = true;
            this.dgvServicios.RowHeadersVisible = false;
            this.dgvServicios.RowHeadersWidth = 50;
            this.dgvServicios.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvServicios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvServicios.Size = new System.Drawing.Size(1179, 163);
            this.dgvServicios.TabIndex = 55;
            this.dgvServicios.SelectionChanged += new System.EventHandler(this.dgvServicios_SelectionChanged);
            // 
            // cboTipo_Facturacion
            // 
            this.cboTipo_Facturacion.BorderColor = System.Drawing.Color.Gainsboro;
            this.cboTipo_Facturacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipo_Facturacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboTipo_Facturacion.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTipo_Facturacion.FormattingEnabled = true;
            this.cboTipo_Facturacion.Location = new System.Drawing.Point(656, 146);
            this.cboTipo_Facturacion.Name = "cboTipo_Facturacion";
            this.cboTipo_Facturacion.Size = new System.Drawing.Size(344, 29);
            this.cboTipo_Facturacion.TabIndex = 41;
            // 
            // txtHasta
            // 
            this.txtHasta.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtHasta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtHasta.Enabled = false;
            this.txtHasta.FocusColor = System.Drawing.Color.Empty;
            this.txtHasta.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHasta.ForeColor = System.Drawing.Color.Black;
            this.txtHasta.Location = new System.Drawing.Point(320, 147);
            this.txtHasta.Mask = "00/00/0000";
            this.txtHasta.Name = "txtHasta";
            this.txtHasta.ReadOnly = true;
            this.txtHasta.Size = new System.Drawing.Size(100, 29);
            this.txtHasta.TabIndex = 36;
            this.txtHasta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtHasta.ValidatingType = typeof(System.DateTime);
            // 
            // txtDesde
            // 
            this.txtDesde.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtDesde.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDesde.Enabled = false;
            this.txtDesde.FocusColor = System.Drawing.Color.Empty;
            this.txtDesde.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDesde.ForeColor = System.Drawing.Color.Black;
            this.txtDesde.Location = new System.Drawing.Point(156, 148);
            this.txtDesde.Mask = "00/00/0000";
            this.txtDesde.Name = "txtDesde";
            this.txtDesde.ReadOnly = true;
            this.txtDesde.Size = new System.Drawing.Size(100, 29);
            this.txtDesde.TabIndex = 34;
            this.txtDesde.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtDesde.ValidatingType = typeof(System.DateTime);
            // 
            // cboGrupoServicios
            // 
            this.cboGrupoServicios.BorderColor = System.Drawing.Color.Gainsboro;
            this.cboGrupoServicios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGrupoServicios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboGrupoServicios.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboGrupoServicios.FormattingEnabled = true;
            this.cboGrupoServicios.Location = new System.Drawing.Point(656, 113);
            this.cboGrupoServicios.Name = "cboGrupoServicios";
            this.cboGrupoServicios.Size = new System.Drawing.Size(344, 29);
            this.cboGrupoServicios.TabIndex = 32;
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
            this.btnActualizar.Location = new System.Drawing.Point(1070, 127);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(105, 35);
            this.btnActualizar.TabIndex = 30;
            this.btnActualizar.Text = "Consultar";
            this.btnActualizar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnActualizar.UseVisualStyleBackColor = false;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // dgvSubServicios
            // 
            this.dgvSubServicios.AllowUserToAddRows = false;
            this.dgvSubServicios.AllowUserToDeleteRows = false;
            this.dgvSubServicios.AllowUserToOrderColumns = true;
            this.dgvSubServicios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSubServicios.BackgroundColor = System.Drawing.Color.White;
            this.dgvSubServicios.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvSubServicios.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSubServicios.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvSubServicios.ColumnHeadersHeight = 40;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSubServicios.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvSubServicios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSubServicios.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.dgvSubServicios.EnableHeadersVisualStyles = false;
            this.dgvSubServicios.GridColor = System.Drawing.Color.WhiteSmoke;
            this.dgvSubServicios.Location = new System.Drawing.Point(0, 21);
            this.dgvSubServicios.MultiSelect = false;
            this.dgvSubServicios.Name = "dgvSubServicios";
            this.dgvSubServicios.ReadOnly = true;
            this.dgvSubServicios.RowHeadersVisible = false;
            this.dgvSubServicios.RowHeadersWidth = 50;
            this.dgvSubServicios.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvSubServicios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvSubServicios.Size = new System.Drawing.Size(1179, 170);
            this.dgvSubServicios.TabIndex = 29;
            this.dgvSubServicios.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSubServicios_CellClick);
            this.dgvSubServicios.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSubServicios_CellValueChanged);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
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
            this.btnGuardar.Location = new System.Drawing.Point(1071, 582);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(104, 35);
            this.btnGuardar.TabIndex = 28;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // cboTarifas
            // 
            this.cboTarifas.BorderColor = System.Drawing.Color.Gainsboro;
            this.cboTarifas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTarifas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboTarifas.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTarifas.FormattingEnabled = true;
            this.cboTarifas.Location = new System.Drawing.Point(68, 113);
            this.cboTarifas.Name = "cboTarifas";
            this.cboTarifas.Size = new System.Drawing.Size(352, 29);
            this.cboTarifas.TabIndex = 27;
            this.cboTarifas.SelectedIndexChanged += new System.EventHandler(this.cboTarifas_SelectedIndexChanged);
            // 
            // lblServicioSeleccinado
            // 
            this.lblServicioSeleccinado.AutoSize = true;
            this.lblServicioSeleccinado.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblServicioSeleccinado.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblServicioSeleccinado.ForeColor = System.Drawing.Color.Firebrick;
            this.lblServicioSeleccinado.Location = new System.Drawing.Point(75, 0);
            this.lblServicioSeleccinado.Name = "lblServicioSeleccinado";
            this.lblServicioSeleccinado.Size = new System.Drawing.Size(215, 21);
            this.lblServicioSeleccinado.TabIndex = 332;
            this.lblServicioSeleccinado.Text = "[ SELECCIONE UN SERVICIO ]";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(0, 186);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dgvServicios);
            this.splitContainer1.Panel1.Controls.Add(this.panel2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgvSubServicios);
            this.splitContainer1.Panel2.Controls.Add(this.lblsubservicios);
            this.splitContainer1.Size = new System.Drawing.Size(1179, 390);
            this.splitContainer1.SplitterDistance = 195;
            this.splitContainer1.TabIndex = 333;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblServicioSeleccinado);
            this.panel2.Controls.Add(this.lblServicios);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1179, 32);
            this.panel2.TabIndex = 333;
            // 
            // ABMTarifas_Sub
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(250)))), ((int)(((byte)(251)))));
            this.ClientSize = new System.Drawing.Size(1191, 651);
            this.ControlBox = false;
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.lbltitulo);
            this.Controls.Add(this.btnEspeciales);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.cboTipo_Facturacion);
            this.Controls.Add(this.lblTipo_Facturacion);
            this.Controls.Add(this.txtHasta);
            this.Controls.Add(this.txtDesde);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboGrupoServicios);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.cboTarifas);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.pnFooter);
            this.Controls.Add(this.label3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "ABMTarifas_Sub";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "ABMTarifas_Sub";
            this.Load += new System.EventHandler(this.ABMTarifas_Sub_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ABMTarifas_Sub_KeyDown);
            this.pnFooter.ResumeLayout(false);
            this.pnFooter.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgReturn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvServicios)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSubServicios)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel pnFooter;
        private Controles.progress pgCircular;
        private System.Windows.Forms.Label lblTotal;
        private Controles.combo cboTarifas;
        private Controles.boton btnGuardar;
        private System.Windows.Forms.Panel panel1;
        private Controles.dgv dgvSubServicios;
        private Controles.boton btnActualizar;
        private Controles.combo cboGrupoServicios;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private Controles.textboxMask txtDesde;
        private Controles.textboxMask txtHasta;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblNombre;
        private Controles.combo cboTipo_Facturacion;
        private System.Windows.Forms.Label lblTipo_Facturacion;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox imgReturn;
        private System.Windows.Forms.Label lblTituloHeader;
        private Controles.dgv dgvServicios;
        private Controles.boton btnEspeciales;
        private System.Windows.Forms.Label lbltitulo;
        private System.Windows.Forms.Label lblServicios;
        private System.Windows.Forms.Label lblsubservicios;
        private System.Windows.Forms.Label lblInformacion;
        private System.Windows.Forms.Label lblServicioSeleccinado;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel2;
    }
}