namespace CapaPresentacion.Impuestos
{
    partial class frmImpuestosProvincial
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
            this.dtphasta = new System.Windows.Forms.DateTimePicker();
            this.dtpdesde = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.pnFooter = new System.Windows.Forms.Panel();
            this.pgCircular = new CapaPresentacion.Controles.progress();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.imgReturn = new System.Windows.Forms.PictureBox();
            this.lblTituloHeader = new System.Windows.Forms.Label();
            this.cboPuntosVenta = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel11 = new System.Windows.Forms.Panel();
            this.lblTotalConexion = new System.Windows.Forms.Label();
            this.llblTotalEquipos = new System.Windows.Forms.Label();
            this.txtTotalProvincial = new CapaPresentacion.textboxAdv();
            this.txtTotalNeto = new CapaPresentacion.textboxAdv();
            this.tarea = new System.ComponentModel.BackgroundWorker();
            this.pnlProgreso = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.barProgreso = new System.Windows.Forms.ProgressBar();
            this.btnGenerarTxt = new CapaPresentacion.Controles.boton();
            this.btnExportar = new CapaPresentacion.Controles.boton();
            this.btnReimprimeComprobante = new CapaPresentacion.Controles.boton();
            this.dgv = new CapaPresentacion.Controles.dgv(this.components);
            this.btnBuscar = new CapaPresentacion.Controles.boton();
            this.pnFooter.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgReturn)).BeginInit();
            this.panel11.SuspendLayout();
            this.pnlProgreso.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // dtphasta
            // 
            this.dtphasta.Font = new System.Drawing.Font("Segoe UI Light", 12F);
            this.dtphasta.Location = new System.Drawing.Point(333, 84);
            this.dtphasta.Name = "dtphasta";
            this.dtphasta.Size = new System.Drawing.Size(200, 29);
            this.dtphasta.TabIndex = 96;
            // 
            // dtpdesde
            // 
            this.dtpdesde.Font = new System.Drawing.Font("Segoe UI Light", 12F);
            this.dtpdesde.Location = new System.Drawing.Point(69, 84);
            this.dtpdesde.Name = "dtpdesde";
            this.dtpdesde.Size = new System.Drawing.Size(200, 29);
            this.dtpdesde.TabIndex = 95;
            this.dtpdesde.Value = new System.DateTime(2018, 5, 1, 0, 0, 0, 0);
            this.dtpdesde.ValueChanged += new System.EventHandler(this.dtpdesde_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(7, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 21);
            this.label1.TabIndex = 89;
            this.label1.Text = "Desde:";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.ForeColor = System.Drawing.Color.SlateGray;
            this.lblTotal.Location = new System.Drawing.Point(8, 8);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(111, 13);
            this.lblTotal.TabIndex = 13;
            this.lblTotal.Text = "Total de Registros: 0";
            // 
            // pnFooter
            // 
            this.pnFooter.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnFooter.Controls.Add(this.lblTotal);
            this.pnFooter.Controls.Add(this.pgCircular);
            this.pnFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnFooter.Location = new System.Drawing.Point(0, 513);
            this.pnFooter.Name = "pnFooter";
            this.pnFooter.Size = new System.Drawing.Size(1380, 30);
            this.pnFooter.TabIndex = 87;
            // 
            // pgCircular
            // 
            this.pgCircular.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pgCircular.Location = new System.Drawing.Point(1344, 3);
            this.pgCircular.Name = "pgCircular";
            this.pgCircular.Percentage = 0F;
            this.pgCircular.Rotation = CapaPresentacion.Controles.RotationType.CounterClockwise;
            this.pgCircular.Size = new System.Drawing.Size(24, 24);
            this.pgCircular.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(275, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 21);
            this.label2.TabIndex = 90;
            this.label2.Text = "Hasta:";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.panel3.Controls.Add(this.imgReturn);
            this.panel3.Controls.Add(this.lblTituloHeader);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1380, 75);
            this.panel3.TabIndex = 88;
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
            this.lblTituloHeader.Text = "Impuestos Provinciales";
            // 
            // cboPuntosVenta
            // 
            this.cboPuntosVenta.Font = new System.Drawing.Font("Segoe UI Light", 12F);
            this.cboPuntosVenta.FormattingEnabled = true;
            this.cboPuntosVenta.Location = new System.Drawing.Point(668, 85);
            this.cboPuntosVenta.Name = "cboPuntosVenta";
            this.cboPuntosVenta.Size = new System.Drawing.Size(239, 29);
            this.cboPuntosVenta.TabIndex = 103;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(545, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 21);
            this.label3.TabIndex = 102;
            this.label3.Text = "Punto de venta:";
            // 
            // panel11
            // 
            this.panel11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel11.BackColor = System.Drawing.Color.SlateGray;
            this.panel11.Controls.Add(this.lblTotalConexion);
            this.panel11.Controls.Add(this.llblTotalEquipos);
            this.panel11.Controls.Add(this.txtTotalProvincial);
            this.panel11.Controls.Add(this.txtTotalNeto);
            this.panel11.Location = new System.Drawing.Point(852, 447);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(517, 60);
            this.panel11.TabIndex = 106;
            // 
            // lblTotalConexion
            // 
            this.lblTotalConexion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalConexion.AutoSize = true;
            this.lblTotalConexion.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.lblTotalConexion.ForeColor = System.Drawing.Color.White;
            this.lblTotalConexion.Location = new System.Drawing.Point(303, 0);
            this.lblTotalConexion.Name = "lblTotalConexion";
            this.lblTotalConexion.Size = new System.Drawing.Size(211, 25);
            this.lblTotalConexion.TabIndex = 81;
            this.lblTotalConexion.Text = "Total importe provincial";
            // 
            // llblTotalEquipos
            // 
            this.llblTotalEquipos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.llblTotalEquipos.AutoSize = true;
            this.llblTotalEquipos.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.llblTotalEquipos.ForeColor = System.Drawing.Color.White;
            this.llblTotalEquipos.Location = new System.Drawing.Point(80, 0);
            this.llblTotalEquipos.Name = "llblTotalEquipos";
            this.llblTotalEquipos.Size = new System.Drawing.Size(166, 25);
            this.llblTotalEquipos.TabIndex = 79;
            this.llblTotalEquipos.Text = "Total importe neto";
            // 
            // txtTotalProvincial
            // 
            this.txtTotalProvincial.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTotalProvincial.BackColor = System.Drawing.Color.SlateGray;
            this.txtTotalProvincial.BorderColor = System.Drawing.Color.Transparent;
            this.txtTotalProvincial.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTotalProvincial.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTotalProvincial.FocusColor = System.Drawing.Color.Empty;
            this.txtTotalProvincial.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.txtTotalProvincial.ForeColor = System.Drawing.Color.White;
            this.txtTotalProvincial.Location = new System.Drawing.Point(405, 25);
            this.txtTotalProvincial.Name = "txtTotalProvincial";
            this.txtTotalProvincial.Numerico = true;
            this.txtTotalProvincial.Size = new System.Drawing.Size(107, 25);
            this.txtTotalProvincial.TabIndex = 80;
            this.txtTotalProvincial.TabStop = false;
            this.txtTotalProvincial.Tag = "\"\"";
            this.txtTotalProvincial.Text = "0";
            this.txtTotalProvincial.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtTotalNeto
            // 
            this.txtTotalNeto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTotalNeto.BackColor = System.Drawing.Color.SlateGray;
            this.txtTotalNeto.BorderColor = System.Drawing.Color.Transparent;
            this.txtTotalNeto.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTotalNeto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTotalNeto.FocusColor = System.Drawing.Color.Empty;
            this.txtTotalNeto.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.txtTotalNeto.ForeColor = System.Drawing.Color.White;
            this.txtTotalNeto.Location = new System.Drawing.Point(139, 25);
            this.txtTotalNeto.Name = "txtTotalNeto";
            this.txtTotalNeto.Numerico = true;
            this.txtTotalNeto.Size = new System.Drawing.Size(107, 25);
            this.txtTotalNeto.TabIndex = 78;
            this.txtTotalNeto.TabStop = false;
            this.txtTotalNeto.Tag = "\"\"";
            this.txtTotalNeto.Text = "0";
            this.txtTotalNeto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tarea
            // 
            this.tarea.WorkerReportsProgress = true;
            this.tarea.WorkerSupportsCancellation = true;
            this.tarea.DoWork += new System.ComponentModel.DoWorkEventHandler(this.GenerarLibroProvincial);
            this.tarea.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.tarea_ProgressChanged);
            this.tarea.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.Terminado);
            // 
            // pnlProgreso
            // 
            this.pnlProgreso.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.pnlProgreso.Controls.Add(this.label4);
            this.pnlProgreso.Controls.Add(this.barProgreso);
            this.pnlProgreso.Location = new System.Drawing.Point(343, 218);
            this.pnlProgreso.Name = "pnlProgreso";
            this.pnlProgreso.Size = new System.Drawing.Size(809, 106);
            this.pnlProgreso.TabIndex = 108;
            this.pnlProgreso.Visible = false;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(275, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(273, 21);
            this.label4.TabIndex = 89;
            this.label4.Text = "Procesando archivos de salida";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // barProgreso
            // 
            this.barProgreso.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.barProgreso.Location = new System.Drawing.Point(29, 57);
            this.barProgreso.Name = "barProgreso";
            this.barProgreso.Size = new System.Drawing.Size(753, 23);
            this.barProgreso.TabIndex = 0;
            this.barProgreso.Value = 50;
            // 
            // btnGenerarTxt
            // 
            this.btnGenerarTxt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnGenerarTxt.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGenerarTxt.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnGenerarTxt.FlatAppearance.BorderSize = 0;
            this.btnGenerarTxt.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnGenerarTxt.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnGenerarTxt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerarTxt.Font = new System.Drawing.Font("Segoe UI Light", 12F);
            this.btnGenerarTxt.ForeColor = System.Drawing.Color.White;
            this.btnGenerarTxt.Image = global::CapaPresentacion.Properties.Resources.Download_32;
            this.btnGenerarTxt.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGenerarTxt.Location = new System.Drawing.Point(1248, 81);
            this.btnGenerarTxt.Name = "btnGenerarTxt";
            this.btnGenerarTxt.Size = new System.Drawing.Size(118, 34);
            this.btnGenerarTxt.TabIndex = 107;
            this.btnGenerarTxt.Text = "Generar txt";
            this.btnGenerarTxt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGenerarTxt.UseVisualStyleBackColor = false;
            this.btnGenerarTxt.Click += new System.EventHandler(this.btnGenerarTxt_Click);
            // 
            // btnExportar
            // 
            this.btnExportar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnExportar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExportar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnExportar.FlatAppearance.BorderSize = 0;
            this.btnExportar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnExportar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnExportar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportar.Font = new System.Drawing.Font("Segoe UI Light", 12F);
            this.btnExportar.ForeColor = System.Drawing.Color.White;
            this.btnExportar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExportar.Location = new System.Drawing.Point(1130, 80);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(112, 34);
            this.btnExportar.TabIndex = 104;
            this.btnExportar.Text = "Exportar";
            this.btnExportar.UseVisualStyleBackColor = false;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // btnReimprimeComprobante
            // 
            this.btnReimprimeComprobante.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnReimprimeComprobante.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReimprimeComprobante.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnReimprimeComprobante.FlatAppearance.BorderSize = 0;
            this.btnReimprimeComprobante.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnReimprimeComprobante.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnReimprimeComprobante.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReimprimeComprobante.Font = new System.Drawing.Font("Segoe UI Light", 12F);
            this.btnReimprimeComprobante.ForeColor = System.Drawing.Color.White;
            this.btnReimprimeComprobante.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnReimprimeComprobante.Location = new System.Drawing.Point(1013, 81);
            this.btnReimprimeComprobante.Name = "btnReimprimeComprobante";
            this.btnReimprimeComprobante.Size = new System.Drawing.Size(112, 34);
            this.btnReimprimeComprobante.TabIndex = 98;
            this.btnReimprimeComprobante.Text = "Reimprime";
            this.btnReimprimeComprobante.UseVisualStyleBackColor = false;
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
            this.dgv.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSlateGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv.ColumnHeadersHeight = 45;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgv.EnableHeadersVisualStyles = false;
            this.dgv.GridColor = System.Drawing.Color.WhiteSmoke;
            this.dgv.Location = new System.Drawing.Point(0, 119);
            this.dgv.MultiSelect = false;
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersVisible = false;
            this.dgv.RowHeadersWidth = 50;
            this.dgv.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(1380, 314);
            this.dgv.TabIndex = 94;
            this.dgv.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellContentClick);
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(84)))), ((int)(((byte)(101)))));
            this.btnBuscar.FlatAppearance.BorderSize = 0;
            this.btnBuscar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(84)))), ((int)(((byte)(101)))));
            this.btnBuscar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.ForeColor = System.Drawing.Color.White;
            this.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBuscar.Location = new System.Drawing.Point(913, 81);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(94, 34);
            this.btnBuscar.TabIndex = 93;
            this.btnBuscar.Text = "Consultar";
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // frmImpuestosProvincial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1380, 543);
            this.Controls.Add(this.pnlProgreso);
            this.Controls.Add(this.btnGenerarTxt);
            this.Controls.Add(this.panel11);
            this.Controls.Add(this.btnExportar);
            this.Controls.Add(this.cboPuntosVenta);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnReimprimeComprobante);
            this.Controls.Add(this.dtphasta);
            this.Controls.Add(this.dtpdesde);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pnFooter);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "frmImpuestosProvincial";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmImpuestosProvincial";
            this.Load += new System.EventHandler(this.frmImpuestosProvincial_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmImpuestosProvincial_KeyDown);
            this.pnFooter.ResumeLayout(false);
            this.pnFooter.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgReturn)).EndInit();
            this.panel11.ResumeLayout(false);
            this.panel11.PerformLayout();
            this.pnlProgreso.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controles.progress pgCircular;
        private System.Windows.Forms.DateTimePicker dtphasta;
        private System.Windows.Forms.DateTimePicker dtpdesde;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Panel pnFooter;
        private System.Windows.Forms.PictureBox imgReturn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblTituloHeader;
        private System.Windows.Forms.ComboBox cboPuntosVenta;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Label lblTotalConexion;
        private System.Windows.Forms.Label llblTotalEquipos;
        private textboxAdv txtTotalProvincial;
        private textboxAdv txtTotalNeto;
        private Controles.boton btnGenerarTxt;
        private Controles.boton btnBuscar;
        private Controles.dgv dgv;
        private Controles.boton btnReimprimeComprobante;
        private Controles.boton btnExportar;
        private System.ComponentModel.BackgroundWorker tarea;
        private System.Windows.Forms.Panel pnlProgreso;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ProgressBar barProgreso;
    }
}