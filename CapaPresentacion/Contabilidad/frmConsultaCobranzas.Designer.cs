namespace CapaPresentacion.Contabilidad
{
    partial class frmConsultaCobranzas
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnHeader = new System.Windows.Forms.Panel();
            this.imgReturn = new System.Windows.Forms.PictureBox();
            this.lblTituloHeader = new System.Windows.Forms.Label();
            this.pnFooter = new System.Windows.Forms.Panel();
            this.lblTotal = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpFechaHasta = new System.Windows.Forms.DateTimePicker();
            this.lblY = new System.Windows.Forms.Label();
            this.dtpFechaDesde = new System.Windows.Forms.DateTimePicker();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTipoFacturacion = new System.Windows.Forms.Label();
            this.lblModalidad = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblCajas = new System.Windows.Forms.Label();
            this.lblA = new System.Windows.Forms.Label();
            this.chkConsultarPorCajas = new System.Windows.Forms.CheckBox();
            this.pnlDetalles = new System.Windows.Forms.Panel();
            this.lblSumatoriaMontos = new System.Windows.Forms.Label();
            this.lblPuntoCobro = new System.Windows.Forms.Label();
            this.lblTotalRegistroDetalles = new System.Windows.Forms.Label();
            this.lblConsultaDetalles = new System.Windows.Forms.Label();
            this.lblColumnaConsultada = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblInfo = new System.Windows.Forms.Label();
            this.boton1 = new CapaPresentacion.Controles.boton();
            this.dgvDetalles = new CapaPresentacion.Controles.dgv(this.components);
            this.spIdCajaHasta = new CapaPresentacion.Controles.spinner(this.components);
            this.spIdCajaDesde = new CapaPresentacion.Controles.spinner(this.components);
            this.btnExportar = new CapaPresentacion.Controles.boton();
            this.cboTipoServicio = new CapaPresentacion.Controles.combo(this.components);
            this.cboModalidadServicio = new CapaPresentacion.Controles.combo(this.components);
            this.cboTipoFacturacion = new CapaPresentacion.Controles.combo(this.components);
            this.btnBuscar = new CapaPresentacion.Controles.boton();
            this.pgCircular = new CapaPresentacion.Controles.progress();
            this.dgvCobranzas = new CapaPresentacion.Controles.dgv(this.components);
            this.pnHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgReturn)).BeginInit();
            this.pnFooter.SuspendLayout();
            this.pnlDetalles.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spIdCajaHasta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spIdCajaDesde)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCobranzas)).BeginInit();
            this.SuspendLayout();
            // 
            // pnHeader
            // 
            this.pnHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.pnHeader.Controls.Add(this.imgReturn);
            this.pnHeader.Controls.Add(this.lblTituloHeader);
            this.pnHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnHeader.Location = new System.Drawing.Point(0, 0);
            this.pnHeader.Name = "pnHeader";
            this.pnHeader.Size = new System.Drawing.Size(1270, 75);
            this.pnHeader.TabIndex = 48;
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
            this.lblTituloHeader.Size = new System.Drawing.Size(388, 23);
            this.lblTituloHeader.TabIndex = 31;
            this.lblTituloHeader.Text = "Cobranzas realizadas";
            // 
            // pnFooter
            // 
            this.pnFooter.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnFooter.Controls.Add(this.lblTotal);
            this.pnFooter.Controls.Add(this.pgCircular);
            this.pnFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnFooter.Location = new System.Drawing.Point(0, 528);
            this.pnFooter.Name = "pnFooter";
            this.pnFooter.Size = new System.Drawing.Size(1270, 30);
            this.pnFooter.TabIndex = 350;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblTotal.ForeColor = System.Drawing.Color.SlateGray;
            this.lblTotal.Location = new System.Drawing.Point(8, 5);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(174, 21);
            this.lblTotal.TabIndex = 13;
            this.lblTotal.Text = "Cantidad de registros: 0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(8, 163);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 21);
            this.label2.TabIndex = 356;
            this.label2.Text = "Entre las fechas";
            // 
            // dtpFechaHasta
            // 
            this.dtpFechaHasta.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.dtpFechaHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFechaHasta.Location = new System.Drawing.Point(267, 159);
            this.dtpFechaHasta.Name = "dtpFechaHasta";
            this.dtpFechaHasta.Size = new System.Drawing.Size(105, 29);
            this.dtpFechaHasta.TabIndex = 355;
            // 
            // lblY
            // 
            this.lblY.AutoSize = true;
            this.lblY.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblY.ForeColor = System.Drawing.Color.Black;
            this.lblY.Location = new System.Drawing.Point(243, 163);
            this.lblY.Name = "lblY";
            this.lblY.Size = new System.Drawing.Size(18, 21);
            this.lblY.TabIndex = 354;
            this.lblY.Text = "y";
            // 
            // dtpFechaDesde
            // 
            this.dtpFechaDesde.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.dtpFechaDesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFechaDesde.Location = new System.Drawing.Point(132, 159);
            this.dtpFechaDesde.Name = "dtpFechaDesde";
            this.dtpFechaDesde.Size = new System.Drawing.Size(105, 29);
            this.dtpFechaDesde.TabIndex = 353;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.Silver;
            this.panel1.Location = new System.Drawing.Point(0, 194);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1278, 1);
            this.panel1.TabIndex = 358;
            // 
            // lblTipoFacturacion
            // 
            this.lblTipoFacturacion.AutoSize = true;
            this.lblTipoFacturacion.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipoFacturacion.ForeColor = System.Drawing.Color.Black;
            this.lblTipoFacturacion.Location = new System.Drawing.Point(8, 123);
            this.lblTipoFacturacion.Name = "lblTipoFacturacion";
            this.lblTipoFacturacion.Size = new System.Drawing.Size(115, 21);
            this.lblTipoFacturacion.TabIndex = 362;
            this.lblTipoFacturacion.Text = "Zona/categoría";
            // 
            // lblModalidad
            // 
            this.lblModalidad.AutoSize = true;
            this.lblModalidad.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblModalidad.ForeColor = System.Drawing.Color.Black;
            this.lblModalidad.Location = new System.Drawing.Point(358, 85);
            this.lblModalidad.Name = "lblModalidad";
            this.lblModalidad.Size = new System.Drawing.Size(84, 21);
            this.lblModalidad.TabIndex = 363;
            this.lblModalidad.Text = "Modalidad";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(8, 85);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(118, 21);
            this.label4.TabIndex = 364;
            this.label4.Text = "Tipo de servicio";
            // 
            // lblCajas
            // 
            this.lblCajas.AutoSize = true;
            this.lblCajas.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCajas.ForeColor = System.Drawing.Color.Black;
            this.lblCajas.Location = new System.Drawing.Point(684, 85);
            this.lblCajas.Name = "lblCajas";
            this.lblCajas.Size = new System.Drawing.Size(119, 21);
            this.lblCajas.TabIndex = 415;
            this.lblCajas.Text = "Desde la caja n°";
            // 
            // lblA
            // 
            this.lblA.AutoSize = true;
            this.lblA.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblA.ForeColor = System.Drawing.Color.Black;
            this.lblA.Location = new System.Drawing.Point(866, 85);
            this.lblA.Name = "lblA";
            this.lblA.Size = new System.Drawing.Size(47, 21);
            this.lblA.TabIndex = 416;
            this.lblA.Text = "hasta";
            // 
            // chkConsultarPorCajas
            // 
            this.chkConsultarPorCajas.AutoSize = true;
            this.chkConsultarPorCajas.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.chkConsultarPorCajas.Location = new System.Drawing.Point(688, 121);
            this.chkConsultarPorCajas.Name = "chkConsultarPorCajas";
            this.chkConsultarPorCajas.Size = new System.Drawing.Size(195, 25);
            this.chkConsultarPorCajas.TabIndex = 417;
            this.chkConsultarPorCajas.Text = "Consultar por n° de caja";
            this.chkConsultarPorCajas.UseVisualStyleBackColor = true;
            this.chkConsultarPorCajas.CheckedChanged += new System.EventHandler(this.chkConsultarPorCajas_CheckedChanged);
            // 
            // pnlDetalles
            // 
            this.pnlDetalles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlDetalles.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDetalles.Controls.Add(this.boton1);
            this.pnlDetalles.Controls.Add(this.lblSumatoriaMontos);
            this.pnlDetalles.Controls.Add(this.lblPuntoCobro);
            this.pnlDetalles.Controls.Add(this.lblTotalRegistroDetalles);
            this.pnlDetalles.Controls.Add(this.lblConsultaDetalles);
            this.pnlDetalles.Controls.Add(this.lblColumnaConsultada);
            this.pnlDetalles.Controls.Add(this.dgvDetalles);
            this.pnlDetalles.Controls.Add(this.panel3);
            this.pnlDetalles.Location = new System.Drawing.Point(98, 247);
            this.pnlDetalles.Name = "pnlDetalles";
            this.pnlDetalles.Size = new System.Drawing.Size(891, 440);
            this.pnlDetalles.TabIndex = 418;
            this.pnlDetalles.Visible = false;
            // 
            // lblSumatoriaMontos
            // 
            this.lblSumatoriaMontos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSumatoriaMontos.AutoSize = true;
            this.lblSumatoriaMontos.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSumatoriaMontos.ForeColor = System.Drawing.Color.Black;
            this.lblSumatoriaMontos.Location = new System.Drawing.Point(548, 406);
            this.lblSumatoriaMontos.Name = "lblSumatoriaMontos";
            this.lblSumatoriaMontos.Size = new System.Drawing.Size(241, 21);
            this.lblSumatoriaMontos.TabIndex = 423;
            this.lblSumatoriaMontos.Text = "Sumatoria de montos de detalles:";
            // 
            // lblPuntoCobro
            // 
            this.lblPuntoCobro.AutoSize = true;
            this.lblPuntoCobro.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPuntoCobro.ForeColor = System.Drawing.Color.Black;
            this.lblPuntoCobro.Location = new System.Drawing.Point(11, 102);
            this.lblPuntoCobro.Name = "lblPuntoCobro";
            this.lblPuntoCobro.Size = new System.Drawing.Size(119, 21);
            this.lblPuntoCobro.TabIndex = 422;
            this.lblPuntoCobro.Text = "Punto de cobro:";
            // 
            // lblTotalRegistroDetalles
            // 
            this.lblTotalRegistroDetalles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTotalRegistroDetalles.AutoSize = true;
            this.lblTotalRegistroDetalles.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalRegistroDetalles.ForeColor = System.Drawing.Color.Black;
            this.lblTotalRegistroDetalles.Location = new System.Drawing.Point(11, 406);
            this.lblTotalRegistroDetalles.Name = "lblTotalRegistroDetalles";
            this.lblTotalRegistroDetalles.Size = new System.Drawing.Size(131, 21);
            this.lblTotalRegistroDetalles.TabIndex = 421;
            this.lblTotalRegistroDetalles.Text = "Total de registros:";
            this.lblTotalRegistroDetalles.Click += new System.EventHandler(this.label3_Click);
            // 
            // lblConsultaDetalles
            // 
            this.lblConsultaDetalles.AutoSize = true;
            this.lblConsultaDetalles.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConsultaDetalles.ForeColor = System.Drawing.Color.Black;
            this.lblConsultaDetalles.Location = new System.Drawing.Point(11, 127);
            this.lblConsultaDetalles.Name = "lblConsultaDetalles";
            this.lblConsultaDetalles.Size = new System.Drawing.Size(242, 21);
            this.lblConsultaDetalles.TabIndex = 420;
            this.lblConsultaDetalles.Text = "Detalles que componen el monto:";
            // 
            // lblColumnaConsultada
            // 
            this.lblColumnaConsultada.AutoSize = true;
            this.lblColumnaConsultada.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblColumnaConsultada.ForeColor = System.Drawing.Color.Black;
            this.lblColumnaConsultada.Location = new System.Drawing.Point(11, 78);
            this.lblColumnaConsultada.Name = "lblColumnaConsultada";
            this.lblColumnaConsultada.Size = new System.Drawing.Size(155, 21);
            this.lblColumnaConsultada.TabIndex = 419;
            this.lblColumnaConsultada.Text = "Columna consultada:";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.panel3.Controls.Add(this.pictureBox1);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(889, 75);
            this.panel3.TabIndex = 49;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = global::CapaPresentacion.Properties.Resources.Left_Arrow_32;
            this.pictureBox1.Location = new System.Drawing.Point(15, 22);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 32;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI Light", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(53, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(388, 23);
            this.label1.TabIndex = 31;
            this.label1.Text = "Detalles";
            // 
            // lblInfo
            // 
            this.lblInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblInfo.AutoSize = true;
            this.lblInfo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfo.ForeColor = System.Drawing.Color.Black;
            this.lblInfo.Location = new System.Drawing.Point(489, 503);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(769, 21);
            this.lblInfo.TabIndex = 421;
            this.lblInfo.Text = "*Para ver la composición de los montos presentes en cada celda de la grilla haga " +
    "doble click sobre dicha celda.";
            // 
            // boton1
            // 
            this.boton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.boton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.boton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.boton1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.boton1.FlatAppearance.BorderSize = 0;
            this.boton1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.boton1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.boton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.boton1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.boton1.ForeColor = System.Drawing.Color.White;
            this.boton1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.boton1.Location = new System.Drawing.Point(735, 111);
            this.boton1.Margin = new System.Windows.Forms.Padding(2);
            this.boton1.Name = "boton1";
            this.boton1.Size = new System.Drawing.Size(139, 35);
            this.boton1.TabIndex = 422;
            this.boton1.Text = "Exportar a Excel";
            this.boton1.UseVisualStyleBackColor = false;
            this.boton1.Click += new System.EventHandler(this.boton1_Click);
            // 
            // dgvDetalles
            // 
            this.dgvDetalles.AllowUserToAddRows = false;
            this.dgvDetalles.AllowUserToDeleteRows = false;
            this.dgvDetalles.AllowUserToOrderColumns = true;
            this.dgvDetalles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDetalles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDetalles.BackgroundColor = System.Drawing.Color.White;
            this.dgvDetalles.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDetalles.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSlateGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 12F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDetalles.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDetalles.ColumnHeadersHeight = 40;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 12F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDetalles.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDetalles.EnableHeadersVisualStyles = false;
            this.dgvDetalles.GridColor = System.Drawing.Color.WhiteSmoke;
            this.dgvDetalles.Location = new System.Drawing.Point(15, 151);
            this.dgvDetalles.MultiSelect = false;
            this.dgvDetalles.Name = "dgvDetalles";
            this.dgvDetalles.ReadOnly = true;
            this.dgvDetalles.RowHeadersVisible = false;
            this.dgvDetalles.RowHeadersWidth = 50;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDetalles.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvDetalles.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvDetalles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvDetalles.Size = new System.Drawing.Size(859, 242);
            this.dgvDetalles.TabIndex = 343;
            // 
            // spIdCajaHasta
            // 
            this.spIdCajaHasta.BorderColor = System.Drawing.Color.Empty;
            this.spIdCajaHasta.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.spIdCajaHasta.Location = new System.Drawing.Point(919, 81);
            this.spIdCajaHasta.Name = "spIdCajaHasta";
            this.spIdCajaHasta.Size = new System.Drawing.Size(51, 29);
            this.spIdCajaHasta.TabIndex = 414;
            // 
            // spIdCajaDesde
            // 
            this.spIdCajaDesde.BorderColor = System.Drawing.Color.Empty;
            this.spIdCajaDesde.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.spIdCajaDesde.Location = new System.Drawing.Point(809, 81);
            this.spIdCajaDesde.Name = "spIdCajaDesde";
            this.spIdCajaDesde.Size = new System.Drawing.Size(51, 29);
            this.spIdCajaDesde.TabIndex = 413;
            // 
            // btnExportar
            // 
            this.btnExportar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnExportar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExportar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnExportar.FlatAppearance.BorderSize = 0;
            this.btnExportar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnExportar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnExportar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportar.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnExportar.ForeColor = System.Drawing.Color.White;
            this.btnExportar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExportar.Location = new System.Drawing.Point(1125, 80);
            this.btnExportar.Margin = new System.Windows.Forms.Padding(2);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(139, 35);
            this.btnExportar.TabIndex = 412;
            this.btnExportar.Text = "Exportar a Excel";
            this.btnExportar.UseVisualStyleBackColor = false;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // cboTipoServicio
            // 
            this.cboTipoServicio.BorderColor = System.Drawing.Color.Empty;
            this.cboTipoServicio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoServicio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboTipoServicio.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cboTipoServicio.ForeColor = System.Drawing.Color.Black;
            this.cboTipoServicio.FormattingEnabled = true;
            this.cboTipoServicio.Items.AddRange(new object[] {
            "TODAS",
            "ALTA",
            "MEDIA",
            "BAJA"});
            this.cboTipoServicio.Location = new System.Drawing.Point(132, 81);
            this.cboTipoServicio.Name = "cboTipoServicio";
            this.cboTipoServicio.Size = new System.Drawing.Size(220, 29);
            this.cboTipoServicio.TabIndex = 361;
            // 
            // cboModalidadServicio
            // 
            this.cboModalidadServicio.BorderColor = System.Drawing.Color.Empty;
            this.cboModalidadServicio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboModalidadServicio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboModalidadServicio.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cboModalidadServicio.ForeColor = System.Drawing.Color.Black;
            this.cboModalidadServicio.FormattingEnabled = true;
            this.cboModalidadServicio.Items.AddRange(new object[] {
            "TODAS",
            "ALTA",
            "MEDIA",
            "BAJA"});
            this.cboModalidadServicio.Location = new System.Drawing.Point(448, 81);
            this.cboModalidadServicio.Name = "cboModalidadServicio";
            this.cboModalidadServicio.Size = new System.Drawing.Size(232, 29);
            this.cboModalidadServicio.TabIndex = 360;
            // 
            // cboTipoFacturacion
            // 
            this.cboTipoFacturacion.BorderColor = System.Drawing.Color.Empty;
            this.cboTipoFacturacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoFacturacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboTipoFacturacion.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cboTipoFacturacion.ForeColor = System.Drawing.Color.Black;
            this.cboTipoFacturacion.FormattingEnabled = true;
            this.cboTipoFacturacion.Items.AddRange(new object[] {
            "TODAS",
            "ALTA",
            "MEDIA",
            "BAJA"});
            this.cboTipoFacturacion.Location = new System.Drawing.Point(132, 119);
            this.cboTipoFacturacion.Name = "cboTipoFacturacion";
            this.cboTipoFacturacion.Size = new System.Drawing.Size(548, 29);
            this.cboTipoFacturacion.TabIndex = 359;
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
            this.btnBuscar.Location = new System.Drawing.Point(1009, 80);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(111, 35);
            this.btnBuscar.TabIndex = 357;
            this.btnBuscar.Text = "Consultar";
            this.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // pgCircular
            // 
            this.pgCircular.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pgCircular.Location = new System.Drawing.Point(1234, 2);
            this.pgCircular.Name = "pgCircular";
            this.pgCircular.Percentage = 0F;
            this.pgCircular.Rotation = CapaPresentacion.Controles.RotationType.CounterClockwise;
            this.pgCircular.Size = new System.Drawing.Size(24, 24);
            this.pgCircular.TabIndex = 0;
            // 
            // dgvCobranzas
            // 
            this.dgvCobranzas.AllowUserToAddRows = false;
            this.dgvCobranzas.AllowUserToDeleteRows = false;
            this.dgvCobranzas.AllowUserToOrderColumns = true;
            this.dgvCobranzas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCobranzas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCobranzas.BackgroundColor = System.Drawing.Color.White;
            this.dgvCobranzas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvCobranzas.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.LightSlateGray;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 12F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCobranzas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvCobranzas.ColumnHeadersHeight = 40;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 12F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCobranzas.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvCobranzas.EnableHeadersVisualStyles = false;
            this.dgvCobranzas.GridColor = System.Drawing.Color.WhiteSmoke;
            this.dgvCobranzas.Location = new System.Drawing.Point(12, 211);
            this.dgvCobranzas.MultiSelect = false;
            this.dgvCobranzas.Name = "dgvCobranzas";
            this.dgvCobranzas.ReadOnly = true;
            this.dgvCobranzas.RowHeadersVisible = false;
            this.dgvCobranzas.RowHeadersWidth = 50;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCobranzas.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvCobranzas.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvCobranzas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvCobranzas.Size = new System.Drawing.Size(1246, 289);
            this.dgvCobranzas.TabIndex = 342;
            this.dgvCobranzas.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCobranzas_CellClick);
            this.dgvCobranzas.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCobranzas_CellDoubleClick);
            // 
            // frmConsultaCobranzas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(250)))), ((int)(((byte)(251)))));
            this.ClientSize = new System.Drawing.Size(1270, 558);
            this.Controls.Add(this.pnlDetalles);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.chkConsultarPorCajas);
            this.Controls.Add(this.lblA);
            this.Controls.Add(this.lblCajas);
            this.Controls.Add(this.spIdCajaHasta);
            this.Controls.Add(this.spIdCajaDesde);
            this.Controls.Add(this.btnExportar);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblModalidad);
            this.Controls.Add(this.lblTipoFacturacion);
            this.Controls.Add(this.cboTipoServicio);
            this.Controls.Add(this.cboModalidadServicio);
            this.Controls.Add(this.cboTipoFacturacion);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtpFechaHasta);
            this.Controls.Add(this.lblY);
            this.Controls.Add(this.dtpFechaDesde);
            this.Controls.Add(this.pnFooter);
            this.Controls.Add(this.dgvCobranzas);
            this.Controls.Add(this.pnHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "frmConsultaCobranzas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmConsultaCobranzas";
            this.Load += new System.EventHandler(this.frmConsultaCobranzas_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmConsultaCobranzas_KeyDown);
            this.pnHeader.ResumeLayout(false);
            this.pnHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgReturn)).EndInit();
            this.pnFooter.ResumeLayout(false);
            this.pnFooter.PerformLayout();
            this.pnlDetalles.ResumeLayout(false);
            this.pnlDetalles.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spIdCajaHasta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spIdCajaDesde)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCobranzas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnHeader;
        private System.Windows.Forms.PictureBox imgReturn;
        private System.Windows.Forms.Label lblTituloHeader;
        private Controles.dgv dgvCobranzas;
        private System.Windows.Forms.Panel pnFooter;
        private System.Windows.Forms.Label lblTotal;
        private Controles.progress pgCircular;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpFechaHasta;
        private System.Windows.Forms.Label lblY;
        private System.Windows.Forms.DateTimePicker dtpFechaDesde;
        private Controles.boton btnBuscar;
        private System.Windows.Forms.Panel panel1;
        private Controles.combo cboTipoFacturacion;
        private Controles.combo cboModalidadServicio;
        private Controles.combo cboTipoServicio;
        private System.Windows.Forms.Label lblTipoFacturacion;
        private System.Windows.Forms.Label lblModalidad;
        private System.Windows.Forms.Label label4;
        private Controles.boton btnExportar;
        private Controles.spinner spIdCajaDesde;
        private Controles.spinner spIdCajaHasta;
        private System.Windows.Forms.Label lblCajas;
        private System.Windows.Forms.Label lblA;
        private System.Windows.Forms.CheckBox chkConsultarPorCajas;
        private System.Windows.Forms.Panel pnlDetalles;
        private Controles.dgv dgvDetalles;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblConsultaDetalles;
        private System.Windows.Forms.Label lblColumnaConsultada;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Label lblTotalRegistroDetalles;
        private System.Windows.Forms.Label lblPuntoCobro;
        private System.Windows.Forms.Label lblSumatoriaMontos;
        private Controles.boton boton1;
    }
}