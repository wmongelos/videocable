namespace CapaPresentacion.Abms
{
    partial class ABMTarifas_Editor
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
            this.pnlTarifaInfo = new System.Windows.Forms.Panel();
            this.lblHastaDato2 = new System.Windows.Forms.Label();
            this.lblDesdeDato2 = new System.Windows.Forms.Label();
            this.lblTarifaNueva = new System.Windows.Forms.Label();
            this.lblTarifaNuevaDato = new System.Windows.Forms.Label();
            this.lblHasta2 = new System.Windows.Forms.Label();
            this.lblDesde2 = new System.Windows.Forms.Label();
            this.pnlGrilla = new System.Windows.Forms.Panel();
            this.pnlSubservicios = new System.Windows.Forms.Panel();
            this.pnlBotonera = new System.Windows.Forms.Panel();
            this.lblServicioDato = new System.Windows.Forms.Label();
            this.lblServicio = new System.Windows.Forms.Label();
            this.spcMain = new System.Windows.Forms.SplitContainer();
            this.pnlAumentoTipoServicio = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkPartes = new System.Windows.Forms.CheckBox();
            this.chkEquipos = new System.Windows.Forms.CheckBox();
            this.chkSub = new System.Windows.Forms.CheckBox();
            this.pnFooter = new System.Windows.Forms.Panel();
            this.lblInfo = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTituloAumento = new System.Windows.Forms.Label();
            this.lblTipoServicio = new System.Windows.Forms.Label();
            this.lblTipoServicioDato = new System.Windows.Forms.Label();
            this.pnlHead = new System.Windows.Forms.Panel();
            this.dgvServicios = new CapaPresentacion.Controles.dgv(this.components);
            this.btnRestablecer = new CapaPresentacion.Controles.boton();
            this.btnAgregarVelocidad = new CapaPresentacion.Controles.boton();
            this.btnEspeciales = new CapaPresentacion.Controles.boton();
            this.btnGuardar = new CapaPresentacion.Controles.boton();
            this.pgCircular = new CapaPresentacion.Controles.progress();
            this.btnGuardar2 = new CapaPresentacion.Controles.boton();
            this.txtImporteTipo = new CapaPresentacion.textboxAdv();
            this.txtPorcentajeTipo = new CapaPresentacion.textboxAdv();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgReturn)).BeginInit();
            this.pnlTarifaInfo.SuspendLayout();
            this.pnlGrilla.SuspendLayout();
            this.pnlSubservicios.SuspendLayout();
            this.pnlBotonera.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spcMain)).BeginInit();
            this.spcMain.Panel1.SuspendLayout();
            this.spcMain.Panel2.SuspendLayout();
            this.spcMain.SuspendLayout();
            this.pnlAumentoTipoServicio.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.pnFooter.SuspendLayout();
            this.pnlHead.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvServicios)).BeginInit();
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
            this.panel3.Size = new System.Drawing.Size(941, 75);
            this.panel3.TabIndex = 59;
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
            this.lblTituloHeader.Size = new System.Drawing.Size(211, 23);
            this.lblTituloHeader.TabIndex = 31;
            this.lblTituloHeader.Text = "Actualizar tarifas";
            // 
            // pnlTarifaInfo
            // 
            this.pnlTarifaInfo.Controls.Add(this.lblHastaDato2);
            this.pnlTarifaInfo.Controls.Add(this.lblDesdeDato2);
            this.pnlTarifaInfo.Controls.Add(this.lblTarifaNueva);
            this.pnlTarifaInfo.Controls.Add(this.lblTarifaNuevaDato);
            this.pnlTarifaInfo.Controls.Add(this.lblHasta2);
            this.pnlTarifaInfo.Controls.Add(this.lblDesde2);
            this.pnlTarifaInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTarifaInfo.Location = new System.Drawing.Point(0, 0);
            this.pnlTarifaInfo.Name = "pnlTarifaInfo";
            this.pnlTarifaInfo.Size = new System.Drawing.Size(941, 81);
            this.pnlTarifaInfo.TabIndex = 48;
            // 
            // lblHastaDato2
            // 
            this.lblHastaDato2.AutoSize = true;
            this.lblHastaDato2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHastaDato2.ForeColor = System.Drawing.Color.Black;
            this.lblHastaDato2.Location = new System.Drawing.Point(285, 46);
            this.lblHastaDato2.Name = "lblHastaDato2";
            this.lblHastaDato2.Size = new System.Drawing.Size(52, 21);
            this.lblHastaDato2.TabIndex = 48;
            this.lblHastaDato2.Text = "Hasta:";
            // 
            // lblDesdeDato2
            // 
            this.lblDesdeDato2.AutoSize = true;
            this.lblDesdeDato2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDesdeDato2.ForeColor = System.Drawing.Color.Black;
            this.lblDesdeDato2.Location = new System.Drawing.Point(91, 46);
            this.lblDesdeDato2.Name = "lblDesdeDato2";
            this.lblDesdeDato2.Size = new System.Drawing.Size(56, 21);
            this.lblDesdeDato2.TabIndex = 47;
            this.lblDesdeDato2.Text = "Desde:";
            // 
            // lblTarifaNueva
            // 
            this.lblTarifaNueva.AutoSize = true;
            this.lblTarifaNueva.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTarifaNueva.ForeColor = System.Drawing.Color.Black;
            this.lblTarifaNueva.Location = new System.Drawing.Point(26, 13);
            this.lblTarifaNueva.Name = "lblTarifaNueva";
            this.lblTarifaNueva.Size = new System.Drawing.Size(50, 21);
            this.lblTarifaNueva.TabIndex = 43;
            this.lblTarifaNueva.Text = "Tarifa:";
            // 
            // lblTarifaNuevaDato
            // 
            this.lblTarifaNuevaDato.AutoSize = true;
            this.lblTarifaNuevaDato.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTarifaNuevaDato.ForeColor = System.Drawing.Color.Black;
            this.lblTarifaNuevaDato.Location = new System.Drawing.Point(91, 13);
            this.lblTarifaNuevaDato.Name = "lblTarifaNuevaDato";
            this.lblTarifaNuevaDato.Size = new System.Drawing.Size(98, 21);
            this.lblTarifaNuevaDato.TabIndex = 46;
            this.lblTarifaNuevaDato.Text = "Nueva tarifa:";
            // 
            // lblHasta2
            // 
            this.lblHasta2.AutoSize = true;
            this.lblHasta2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHasta2.ForeColor = System.Drawing.Color.Black;
            this.lblHasta2.Location = new System.Drawing.Point(227, 46);
            this.lblHasta2.Name = "lblHasta2";
            this.lblHasta2.Size = new System.Drawing.Size(52, 21);
            this.lblHasta2.TabIndex = 45;
            this.lblHasta2.Text = "Hasta:";
            // 
            // lblDesde2
            // 
            this.lblDesde2.AutoSize = true;
            this.lblDesde2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDesde2.ForeColor = System.Drawing.Color.Black;
            this.lblDesde2.Location = new System.Drawing.Point(29, 46);
            this.lblDesde2.Name = "lblDesde2";
            this.lblDesde2.Size = new System.Drawing.Size(56, 21);
            this.lblDesde2.TabIndex = 44;
            this.lblDesde2.Text = "Desde:";
            // 
            // pnlGrilla
            // 
            this.pnlGrilla.Controls.Add(this.pnlSubservicios);
            this.pnlGrilla.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGrilla.Location = new System.Drawing.Point(0, 41);
            this.pnlGrilla.Name = "pnlGrilla";
            this.pnlGrilla.Size = new System.Drawing.Size(941, 98);
            this.pnlGrilla.TabIndex = 62;
            // 
            // pnlSubservicios
            // 
            this.pnlSubservicios.Controls.Add(this.dgvServicios);
            this.pnlSubservicios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSubservicios.Location = new System.Drawing.Point(0, 0);
            this.pnlSubservicios.Name = "pnlSubservicios";
            this.pnlSubservicios.Size = new System.Drawing.Size(941, 98);
            this.pnlSubservicios.TabIndex = 62;
            // 
            // pnlBotonera
            // 
            this.pnlBotonera.Controls.Add(this.lblServicioDato);
            this.pnlBotonera.Controls.Add(this.lblServicio);
            this.pnlBotonera.Controls.Add(this.btnRestablecer);
            this.pnlBotonera.Controls.Add(this.btnAgregarVelocidad);
            this.pnlBotonera.Controls.Add(this.btnEspeciales);
            this.pnlBotonera.Controls.Add(this.btnGuardar);
            this.pnlBotonera.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBotonera.Location = new System.Drawing.Point(0, 0);
            this.pnlBotonera.Name = "pnlBotonera";
            this.pnlBotonera.Size = new System.Drawing.Size(941, 41);
            this.pnlBotonera.TabIndex = 63;
            // 
            // lblServicioDato
            // 
            this.lblServicioDato.AutoSize = true;
            this.lblServicioDato.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblServicioDato.ForeColor = System.Drawing.Color.Black;
            this.lblServicioDato.Location = new System.Drawing.Point(79, 10);
            this.lblServicioDato.Name = "lblServicioDato";
            this.lblServicioDato.Size = new System.Drawing.Size(68, 21);
            this.lblServicioDato.TabIndex = 217;
            this.lblServicioDato.Text = "Servicio:";
            // 
            // lblServicio
            // 
            this.lblServicio.AutoSize = true;
            this.lblServicio.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblServicio.ForeColor = System.Drawing.Color.Black;
            this.lblServicio.Location = new System.Drawing.Point(13, 10);
            this.lblServicio.Name = "lblServicio";
            this.lblServicio.Size = new System.Drawing.Size(68, 21);
            this.lblServicio.TabIndex = 45;
            this.lblServicio.Text = "Servicio:";
            // 
            // spcMain
            // 
            this.spcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spcMain.Location = new System.Drawing.Point(0, 156);
            this.spcMain.Name = "spcMain";
            this.spcMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // spcMain.Panel1
            // 
            this.spcMain.Panel1.Controls.Add(this.pnlGrilla);
            this.spcMain.Panel1.Controls.Add(this.pnlBotonera);
            // 
            // spcMain.Panel2
            // 
            this.spcMain.Panel2.Controls.Add(this.pnlAumentoTipoServicio);
            this.spcMain.Size = new System.Drawing.Size(941, 366);
            this.spcMain.SplitterDistance = 139;
            this.spcMain.TabIndex = 64;
            // 
            // pnlAumentoTipoServicio
            // 
            this.pnlAumentoTipoServicio.Controls.Add(this.groupBox1);
            this.pnlAumentoTipoServicio.Controls.Add(this.pnFooter);
            this.pnlAumentoTipoServicio.Controls.Add(this.lblInfo);
            this.pnlAumentoTipoServicio.Controls.Add(this.btnGuardar2);
            this.pnlAumentoTipoServicio.Controls.Add(this.txtImporteTipo);
            this.pnlAumentoTipoServicio.Controls.Add(this.label1);
            this.pnlAumentoTipoServicio.Controls.Add(this.txtPorcentajeTipo);
            this.pnlAumentoTipoServicio.Controls.Add(this.lblTituloAumento);
            this.pnlAumentoTipoServicio.Controls.Add(this.lblTipoServicio);
            this.pnlAumentoTipoServicio.Controls.Add(this.lblTipoServicioDato);
            this.pnlAumentoTipoServicio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlAumentoTipoServicio.Location = new System.Drawing.Point(0, 0);
            this.pnlAumentoTipoServicio.Name = "pnlAumentoTipoServicio";
            this.pnlAumentoTipoServicio.Size = new System.Drawing.Size(941, 223);
            this.pnlAumentoTipoServicio.TabIndex = 0;
            this.pnlAumentoTipoServicio.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlAumentoTipoServicio_Paint);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.chkPartes);
            this.groupBox1.Controls.Add(this.chkEquipos);
            this.groupBox1.Controls.Add(this.chkSub);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.groupBox1.Location = new System.Drawing.Point(496, 47);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 189);
            this.groupBox1.TabIndex = 223;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Aplicar aumento a:";
            // 
            // chkPartes
            // 
            this.chkPartes.AutoSize = true;
            this.chkPartes.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.chkPartes.Location = new System.Drawing.Point(19, 98);
            this.chkPartes.Name = "chkPartes";
            this.chkPartes.Size = new System.Drawing.Size(71, 25);
            this.chkPartes.TabIndex = 224;
            this.chkPartes.Text = "Partes";
            this.chkPartes.UseVisualStyleBackColor = true;
            // 
            // chkEquipos
            // 
            this.chkEquipos.AutoSize = true;
            this.chkEquipos.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.chkEquipos.Location = new System.Drawing.Point(19, 67);
            this.chkEquipos.Name = "chkEquipos";
            this.chkEquipos.Size = new System.Drawing.Size(84, 25);
            this.chkEquipos.TabIndex = 223;
            this.chkEquipos.Text = "Equipos";
            this.chkEquipos.UseVisualStyleBackColor = true;
            // 
            // chkSub
            // 
            this.chkSub.AutoSize = true;
            this.chkSub.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.chkSub.Location = new System.Drawing.Point(19, 36);
            this.chkSub.Name = "chkSub";
            this.chkSub.Size = new System.Drawing.Size(116, 25);
            this.chkSub.TabIndex = 222;
            this.chkSub.Text = "Subservicios";
            this.chkSub.UseVisualStyleBackColor = true;
            // 
            // pnFooter
            // 
            this.pnFooter.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnFooter.Controls.Add(this.pgCircular);
            this.pnFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnFooter.Location = new System.Drawing.Point(0, 193);
            this.pnFooter.Name = "pnFooter";
            this.pnFooter.Size = new System.Drawing.Size(941, 30);
            this.pnFooter.TabIndex = 221;
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfo.ForeColor = System.Drawing.Color.Red;
            this.lblInfo.Location = new System.Drawing.Point(26, 47);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(565, 21);
            this.lblInfo.TabIndex = 220;
            this.lblInfo.Text = "*Aumentaran todos los servicios (todos sus subservicios) de este tipo de servicio" +
    "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(222, 173);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(153, 21);
            this.label1.TabIndex = 53;
            this.label1.Text = "Aumento general ($)";
            // 
            // lblTituloAumento
            // 
            this.lblTituloAumento.AutoSize = true;
            this.lblTituloAumento.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloAumento.ForeColor = System.Drawing.Color.Black;
            this.lblTituloAumento.Location = new System.Drawing.Point(222, 138);
            this.lblTituloAumento.Name = "lblTituloAumento";
            this.lblTituloAumento.Size = new System.Drawing.Size(157, 21);
            this.lblTituloAumento.TabIndex = 51;
            this.lblTituloAumento.Text = "Aumento general (%)";
            // 
            // lblTipoServicio
            // 
            this.lblTipoServicio.AutoSize = true;
            this.lblTipoServicio.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipoServicio.ForeColor = System.Drawing.Color.Black;
            this.lblTipoServicio.Location = new System.Drawing.Point(26, 15);
            this.lblTipoServicio.Name = "lblTipoServicio";
            this.lblTipoServicio.Size = new System.Drawing.Size(121, 21);
            this.lblTipoServicio.TabIndex = 49;
            this.lblTipoServicio.Text = "Tipo de servicio:";
            // 
            // lblTipoServicioDato
            // 
            this.lblTipoServicioDato.AutoSize = true;
            this.lblTipoServicioDato.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipoServicioDato.ForeColor = System.Drawing.Color.Black;
            this.lblTipoServicioDato.Location = new System.Drawing.Point(153, 15);
            this.lblTipoServicioDato.Name = "lblTipoServicioDato";
            this.lblTipoServicioDato.Size = new System.Drawing.Size(98, 21);
            this.lblTipoServicioDato.TabIndex = 50;
            this.lblTipoServicioDato.Text = "Nueva tarifa:";
            // 
            // pnlHead
            // 
            this.pnlHead.Controls.Add(this.pnlTarifaInfo);
            this.pnlHead.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHead.Location = new System.Drawing.Point(0, 75);
            this.pnlHead.Name = "pnlHead";
            this.pnlHead.Size = new System.Drawing.Size(941, 81);
            this.pnlHead.TabIndex = 61;
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
            this.dgvServicios.EnableHeadersVisualStyles = false;
            this.dgvServicios.GridColor = System.Drawing.Color.WhiteSmoke;
            this.dgvServicios.Location = new System.Drawing.Point(0, 0);
            this.dgvServicios.MultiSelect = false;
            this.dgvServicios.Name = "dgvServicios";
            this.dgvServicios.ReadOnly = true;
            this.dgvServicios.RowHeadersVisible = false;
            this.dgvServicios.RowHeadersWidth = 50;
            this.dgvServicios.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvServicios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvServicios.Size = new System.Drawing.Size(941, 98);
            this.dgvServicios.TabIndex = 60;
            this.dgvServicios.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvServicios_CellBeginEdit);
            this.dgvServicios.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvServicios_CellClick);
            this.dgvServicios.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvServicios_CellDoubleClick);
            this.dgvServicios.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvServicios_CellEndEdit);
            this.dgvServicios.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvServicios_CellEnter);
            this.dgvServicios.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvServicios_CellValueChanged);
            // 
            // btnRestablecer
            // 
            this.btnRestablecer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnRestablecer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRestablecer.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnRestablecer.FlatAppearance.BorderSize = 0;
            this.btnRestablecer.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnRestablecer.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnRestablecer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRestablecer.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRestablecer.ForeColor = System.Drawing.Color.White;
            this.btnRestablecer.Image = global::CapaPresentacion.Properties.Resources.Command_Undo_32;
            this.btnRestablecer.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRestablecer.Location = new System.Drawing.Point(403, 3);
            this.btnRestablecer.Name = "btnRestablecer";
            this.btnRestablecer.Size = new System.Drawing.Size(172, 35);
            this.btnRestablecer.TabIndex = 219;
            this.btnRestablecer.Text = "Deshacer cambios";
            this.btnRestablecer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRestablecer.UseVisualStyleBackColor = false;
            this.btnRestablecer.Click += new System.EventHandler(this.btnRestablecer_Click);
            // 
            // btnAgregarVelocidad
            // 
            this.btnAgregarVelocidad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnAgregarVelocidad.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregarVelocidad.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnAgregarVelocidad.FlatAppearance.BorderSize = 0;
            this.btnAgregarVelocidad.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnAgregarVelocidad.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnAgregarVelocidad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarVelocidad.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarVelocidad.ForeColor = System.Drawing.Color.White;
            this.btnAgregarVelocidad.Image = global::CapaPresentacion.Properties.Resources.Data_Add_32;
            this.btnAgregarVelocidad.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAgregarVelocidad.Location = new System.Drawing.Point(581, 3);
            this.btnAgregarVelocidad.Name = "btnAgregarVelocidad";
            this.btnAgregarVelocidad.Size = new System.Drawing.Size(113, 35);
            this.btnAgregarVelocidad.TabIndex = 218;
            this.btnAgregarVelocidad.Text = "Nuevo";
            this.btnAgregarVelocidad.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgregarVelocidad.UseVisualStyleBackColor = false;
            this.btnAgregarVelocidad.Click += new System.EventHandler(this.btnAgregarVelocidad_Click);
            // 
            // btnEspeciales
            // 
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
            this.btnEspeciales.Location = new System.Drawing.Point(700, 3);
            this.btnEspeciales.Name = "btnEspeciales";
            this.btnEspeciales.Size = new System.Drawing.Size(115, 35);
            this.btnEspeciales.TabIndex = 215;
            this.btnEspeciales.Text = "Especiales";
            this.btnEspeciales.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEspeciales.UseVisualStyleBackColor = false;
            this.btnEspeciales.Click += new System.EventHandler(this.btnEspeciales_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnGuardar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Image = global::CapaPresentacion.Properties.Resources.Save_32;
            this.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGuardar.Location = new System.Drawing.Point(821, 3);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(115, 35);
            this.btnGuardar.TabIndex = 216;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // pgCircular
            // 
            this.pgCircular.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pgCircular.Location = new System.Drawing.Point(905, 2);
            this.pgCircular.Name = "pgCircular";
            this.pgCircular.Percentage = 0F;
            this.pgCircular.Rotation = CapaPresentacion.Controles.RotationType.CounterClockwise;
            this.pgCircular.Size = new System.Drawing.Size(24, 24);
            this.pgCircular.TabIndex = 0;
            // 
            // btnGuardar2
            // 
            this.btnGuardar2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGuardar2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnGuardar2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar2.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnGuardar2.FlatAppearance.BorderSize = 0;
            this.btnGuardar2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnGuardar2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnGuardar2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar2.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar2.ForeColor = System.Drawing.Color.White;
            this.btnGuardar2.Image = global::CapaPresentacion.Properties.Resources.Save_32;
            this.btnGuardar2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGuardar2.Location = new System.Drawing.Point(814, 154);
            this.btnGuardar2.Name = "btnGuardar2";
            this.btnGuardar2.Size = new System.Drawing.Size(115, 35);
            this.btnGuardar2.TabIndex = 219;
            this.btnGuardar2.Text = "Guardar";
            this.btnGuardar2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuardar2.UseVisualStyleBackColor = false;
            this.btnGuardar2.Click += new System.EventHandler(this.btnGuardar2_Click);
            // 
            // txtImporteTipo
            // 
            this.txtImporteTipo.BorderColor = System.Drawing.Color.Empty;
            this.txtImporteTipo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtImporteTipo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtImporteTipo.FocusColor = System.Drawing.Color.Empty;
            this.txtImporteTipo.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtImporteTipo.Location = new System.Drawing.Point(385, 171);
            this.txtImporteTipo.Name = "txtImporteTipo";
            this.txtImporteTipo.Numerico = true;
            this.txtImporteTipo.Size = new System.Drawing.Size(85, 29);
            this.txtImporteTipo.TabIndex = 54;
            this.txtImporteTipo.Text = "0";
            this.txtImporteTipo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtPorcentajeTipo
            // 
            this.txtPorcentajeTipo.BorderColor = System.Drawing.Color.Empty;
            this.txtPorcentajeTipo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPorcentajeTipo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPorcentajeTipo.FocusColor = System.Drawing.Color.Empty;
            this.txtPorcentajeTipo.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPorcentajeTipo.Location = new System.Drawing.Point(385, 136);
            this.txtPorcentajeTipo.Name = "txtPorcentajeTipo";
            this.txtPorcentajeTipo.Numerico = true;
            this.txtPorcentajeTipo.Size = new System.Drawing.Size(85, 29);
            this.txtPorcentajeTipo.TabIndex = 52;
            this.txtPorcentajeTipo.Text = "0";
            this.txtPorcentajeTipo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // ABMTarifas_Editor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(941, 522);
            this.Controls.Add(this.spcMain);
            this.Controls.Add(this.pnlHead);
            this.Controls.Add(this.panel3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "ABMTarifas_Editor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmTarifasServicios";
            this.Load += new System.EventHandler(this.frmTarifasServicios_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmTarifasServicios_KeyDown);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgReturn)).EndInit();
            this.pnlTarifaInfo.ResumeLayout(false);
            this.pnlTarifaInfo.PerformLayout();
            this.pnlGrilla.ResumeLayout(false);
            this.pnlSubservicios.ResumeLayout(false);
            this.pnlBotonera.ResumeLayout(false);
            this.pnlBotonera.PerformLayout();
            this.spcMain.Panel1.ResumeLayout(false);
            this.spcMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spcMain)).EndInit();
            this.spcMain.ResumeLayout(false);
            this.pnlAumentoTipoServicio.ResumeLayout(false);
            this.pnlAumentoTipoServicio.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.pnFooter.ResumeLayout(false);
            this.pnlHead.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvServicios)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox imgReturn;
        private System.Windows.Forms.Label lblTituloHeader;
        private System.Windows.Forms.Panel pnlTarifaInfo;
        private System.Windows.Forms.Label lblTarifaNueva;
        private System.Windows.Forms.Label lblTarifaNuevaDato;
        private System.Windows.Forms.Label lblHasta2;
        private System.Windows.Forms.Label lblDesde2;
        private System.Windows.Forms.Label lblHastaDato2;
        private System.Windows.Forms.Label lblDesdeDato2;
        private System.Windows.Forms.Panel pnlGrilla;
        private System.Windows.Forms.Panel pnlBotonera;
        private Controles.boton btnEspeciales;
        private Controles.boton btnGuardar;
        private System.Windows.Forms.Label lblServicioDato;
        private System.Windows.Forms.Label lblServicio;
        private Controles.boton btnAgregarVelocidad;
        private Controles.dgv dgvServicios;
        private System.Windows.Forms.SplitContainer spcMain;
        private System.Windows.Forms.Panel pnlAumentoTipoServicio;
        private System.Windows.Forms.Label lblTipoServicio;
        private System.Windows.Forms.Label lblTipoServicioDato;
        private Controles.boton btnGuardar2;
        private textboxAdv txtImporteTipo;
        private System.Windows.Forms.Label label1;
        private textboxAdv txtPorcentajeTipo;
        private System.Windows.Forms.Label lblTituloAumento;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Panel pnFooter;
        private Controles.progress pgCircular;
        private System.Windows.Forms.Panel pnlHead;
        private System.Windows.Forms.Panel pnlSubservicios;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkPartes;
        private System.Windows.Forms.CheckBox chkEquipos;
        private System.Windows.Forms.CheckBox chkSub;
        private Controles.boton btnRestablecer;
    }
}