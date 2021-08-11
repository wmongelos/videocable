namespace CapaPresentacion.Impuestos
{
    partial class frmImpuestos
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel3 = new System.Windows.Forms.Panel();
            this.imgReturn = new System.Windows.Forms.PictureBox();
            this.lblTituloHeader = new System.Windows.Forms.Label();
            this.pnFooter = new System.Windows.Forms.Panel();
            this.lblTotal = new System.Windows.Forms.Label();
            this.pgCircular = new CapaPresentacion.Controles.progress();
            this.lblDesde = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpdesde = new System.Windows.Forms.DateTimePicker();
            this.dtphasta = new System.Windows.Forms.DateTimePicker();
            this.cboPuntosVenta = new System.Windows.Forms.ComboBox();
            this.pnlHead = new System.Windows.Forms.Panel();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.txtBuscador = new System.Windows.Forms.TextBox();
            this.btnTxtDuplicadoElectronico = new CapaPresentacion.Controles.boton();
            this.chkMuestraRemito = new System.Windows.Forms.CheckBox();
            this.btnGenerarTxt = new CapaPresentacion.Controles.boton();
            this.btnExportar = new CapaPresentacion.Controles.boton();
            this.btnReimprimeComprobante = new CapaPresentacion.Controles.boton();
            this.btnBuscar = new CapaPresentacion.Controles.boton();
            this.spcMain = new System.Windows.Forms.SplitContainer();
            this.dgv = new CapaPresentacion.Controles.dgv(this.components);
            this.dgv1 = new CapaPresentacion.Controles.dgv(this.components);
            this.btnTxtDuplicadoDigital = new CapaPresentacion.Controles.boton();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgReturn)).BeginInit();
            this.pnFooter.SuspendLayout();
            this.pnlHead.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spcMain)).BeginInit();
            this.spcMain.Panel1.SuspendLayout();
            this.spcMain.Panel2.SuspendLayout();
            this.spcMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).BeginInit();
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
            this.panel3.Size = new System.Drawing.Size(1365, 75);
            this.panel3.TabIndex = 66;
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
            this.lblTituloHeader.Text = "Libro de IVA Ventas";
            // 
            // pnFooter
            // 
            this.pnFooter.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnFooter.Controls.Add(this.lblTotal);
            this.pnFooter.Controls.Add(this.pgCircular);
            this.pnFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnFooter.Location = new System.Drawing.Point(0, 668);
            this.pnFooter.Name = "pnFooter";
            this.pnFooter.Size = new System.Drawing.Size(1365, 30);
            this.pnFooter.TabIndex = 60;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.ForeColor = System.Drawing.Color.SlateGray;
            this.lblTotal.Location = new System.Drawing.Point(12, 8);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(111, 13);
            this.lblTotal.TabIndex = 13;
            this.lblTotal.Text = "Total de Registros: 0";
            // 
            // pgCircular
            // 
            this.pgCircular.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pgCircular.Location = new System.Drawing.Point(1085, 3);
            this.pgCircular.Name = "pgCircular";
            this.pgCircular.Percentage = 0F;
            this.pgCircular.Rotation = CapaPresentacion.Controles.RotationType.CounterClockwise;
            this.pgCircular.Size = new System.Drawing.Size(24, 24);
            this.pgCircular.TabIndex = 0;
            // 
            // lblDesde
            // 
            this.lblDesde.AutoSize = true;
            this.lblDesde.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDesde.ForeColor = System.Drawing.Color.Black;
            this.lblDesde.Location = new System.Drawing.Point(12, 13);
            this.lblDesde.Name = "lblDesde";
            this.lblDesde.Size = new System.Drawing.Size(56, 21);
            this.lblDesde.TabIndex = 68;
            this.lblDesde.Text = "Desde:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(16, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 21);
            this.label2.TabIndex = 70;
            this.label2.Text = "Hasta:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(460, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 21);
            this.label3.TabIndex = 72;
            this.label3.Text = "Punto de venta:";
            // 
            // dtpdesde
            // 
            this.dtpdesde.Font = new System.Drawing.Font("Segoe UI Light", 12F);
            this.dtpdesde.Location = new System.Drawing.Point(74, 9);
            this.dtpdesde.Name = "dtpdesde";
            this.dtpdesde.Size = new System.Drawing.Size(380, 29);
            this.dtpdesde.TabIndex = 75;
            this.dtpdesde.Value = new System.DateTime(2020, 1, 1, 0, 0, 0, 0);
            this.dtpdesde.ValueChanged += new System.EventHandler(this.dtpdesde_ValueChanged);
            this.dtpdesde.Validating += new System.ComponentModel.CancelEventHandler(this.dtpdesde_Validating);
            // 
            // dtphasta
            // 
            this.dtphasta.Font = new System.Drawing.Font("Segoe UI Light", 12F);
            this.dtphasta.Location = new System.Drawing.Point(74, 49);
            this.dtphasta.Name = "dtphasta";
            this.dtphasta.Size = new System.Drawing.Size(380, 29);
            this.dtphasta.TabIndex = 76;
            this.dtphasta.Value = new System.DateTime(2020, 1, 31, 17, 58, 0, 0);
            // 
            // cboPuntosVenta
            // 
            this.cboPuntosVenta.Font = new System.Drawing.Font("Segoe UI Light", 12F);
            this.cboPuntosVenta.FormattingEnabled = true;
            this.cboPuntosVenta.Location = new System.Drawing.Point(583, 10);
            this.cboPuntosVenta.Name = "cboPuntosVenta";
            this.cboPuntosVenta.Size = new System.Drawing.Size(439, 29);
            this.cboPuntosVenta.TabIndex = 87;
            // 
            // pnlHead
            // 
            this.pnlHead.Controls.Add(this.btnTxtDuplicadoDigital);
            this.pnlHead.Controls.Add(this.lblBuscar);
            this.pnlHead.Controls.Add(this.txtBuscador);
            this.pnlHead.Controls.Add(this.btnTxtDuplicadoElectronico);
            this.pnlHead.Controls.Add(this.chkMuestraRemito);
            this.pnlHead.Controls.Add(this.btnGenerarTxt);
            this.pnlHead.Controls.Add(this.dtpdesde);
            this.pnlHead.Controls.Add(this.cboPuntosVenta);
            this.pnlHead.Controls.Add(this.lblDesde);
            this.pnlHead.Controls.Add(this.btnExportar);
            this.pnlHead.Controls.Add(this.label2);
            this.pnlHead.Controls.Add(this.btnReimprimeComprobante);
            this.pnlHead.Controls.Add(this.label3);
            this.pnlHead.Controls.Add(this.btnBuscar);
            this.pnlHead.Controls.Add(this.dtphasta);
            this.pnlHead.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHead.Location = new System.Drawing.Point(0, 75);
            this.pnlHead.Name = "pnlHead";
            this.pnlHead.Size = new System.Drawing.Size(1365, 153);
            this.pnlHead.TabIndex = 88;
            // 
            // lblBuscar
            // 
            this.lblBuscar.AutoSize = true;
            this.lblBuscar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBuscar.ForeColor = System.Drawing.Color.Black;
            this.lblBuscar.Location = new System.Drawing.Point(16, 120);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Size = new System.Drawing.Size(56, 21);
            this.lblBuscar.TabIndex = 92;
            this.lblBuscar.Text = "Buscar";
            this.lblBuscar.Visible = false;
            // 
            // txtBuscador
            // 
            this.txtBuscador.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscador.Location = new System.Drawing.Point(78, 117);
            this.txtBuscador.Name = "txtBuscador";
            this.txtBuscador.Size = new System.Drawing.Size(944, 29);
            this.txtBuscador.TabIndex = 91;
            this.txtBuscador.Visible = false;
            this.txtBuscador.TextChanged += new System.EventHandler(this.txtBuscador_TextChanged);
            // 
            // btnTxtDuplicadoElectronico
            // 
            this.btnTxtDuplicadoElectronico.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnTxtDuplicadoElectronico.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTxtDuplicadoElectronico.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnTxtDuplicadoElectronico.FlatAppearance.BorderSize = 0;
            this.btnTxtDuplicadoElectronico.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnTxtDuplicadoElectronico.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnTxtDuplicadoElectronico.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTxtDuplicadoElectronico.Font = new System.Drawing.Font("Segoe UI Light", 12F);
            this.btnTxtDuplicadoElectronico.ForeColor = System.Drawing.Color.White;
            this.btnTxtDuplicadoElectronico.Image = global::CapaPresentacion.Properties.Resources.Download_32;
            this.btnTxtDuplicadoElectronico.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnTxtDuplicadoElectronico.Location = new System.Drawing.Point(1100, 76);
            this.btnTxtDuplicadoElectronico.Name = "btnTxtDuplicadoElectronico";
            this.btnTxtDuplicadoElectronico.Size = new System.Drawing.Size(253, 34);
            this.btnTxtDuplicadoElectronico.TabIndex = 90;
            this.btnTxtDuplicadoElectronico.Text = "Generar Duplicado Electronico";
            this.btnTxtDuplicadoElectronico.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTxtDuplicadoElectronico.UseVisualStyleBackColor = false;
            this.btnTxtDuplicadoElectronico.Click += new System.EventHandler(this.btnTxtDuplicadoElectronico_Click);
            // 
            // chkMuestraRemito
            // 
            this.chkMuestraRemito.AutoSize = true;
            this.chkMuestraRemito.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkMuestraRemito.Location = new System.Drawing.Point(464, 51);
            this.chkMuestraRemito.Name = "chkMuestraRemito";
            this.chkMuestraRemito.Size = new System.Drawing.Size(145, 25);
            this.chkMuestraRemito.TabIndex = 89;
            this.chkMuestraRemito.Text = "Mostrar Remitos";
            this.chkMuestraRemito.UseVisualStyleBackColor = true;
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
            this.btnGenerarTxt.Location = new System.Drawing.Point(1226, 40);
            this.btnGenerarTxt.Name = "btnGenerarTxt";
            this.btnGenerarTxt.Size = new System.Drawing.Size(127, 34);
            this.btnGenerarTxt.TabIndex = 88;
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
            this.btnExportar.Image = global::CapaPresentacion.Properties.Resources.Data_Export_32;
            this.btnExportar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExportar.Location = new System.Drawing.Point(1226, 4);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(127, 34);
            this.btnExportar.TabIndex = 86;
            this.btnExportar.Text = "Exportar";
            this.btnExportar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.btnReimprimeComprobante.Image = global::CapaPresentacion.Properties.Resources.Print_321;
            this.btnReimprimeComprobante.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnReimprimeComprobante.Location = new System.Drawing.Point(1100, 40);
            this.btnReimprimeComprobante.Name = "btnReimprimeComprobante";
            this.btnReimprimeComprobante.Size = new System.Drawing.Size(124, 34);
            this.btnReimprimeComprobante.TabIndex = 85;
            this.btnReimprimeComprobante.Text = "Reimprime";
            this.btnReimprimeComprobante.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReimprimeComprobante.UseVisualStyleBackColor = false;
            this.btnReimprimeComprobante.Click += new System.EventHandler(this.btnReimprimeComprobante_Click);
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
            this.btnBuscar.Image = global::CapaPresentacion.Properties.Resources.lupa;
            this.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBuscar.Location = new System.Drawing.Point(1100, 4);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(124, 34);
            this.btnBuscar.TabIndex = 73;
            this.btnBuscar.Text = "Consultar";
            this.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // spcMain
            // 
            this.spcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spcMain.Location = new System.Drawing.Point(0, 228);
            this.spcMain.Name = "spcMain";
            this.spcMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // spcMain.Panel1
            // 
            this.spcMain.Panel1.Controls.Add(this.dgv);
            // 
            // spcMain.Panel2
            // 
            this.spcMain.Panel2.Controls.Add(this.dgv1);
            this.spcMain.Size = new System.Drawing.Size(1365, 440);
            this.spcMain.SplitterDistance = 248;
            this.spcMain.SplitterWidth = 20;
            this.spcMain.TabIndex = 89;
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AllowUserToOrderColumns = true;
            this.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgv.BackgroundColor = System.Drawing.Color.White;
            this.dgv.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.dgv.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.LightSlateGray;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dgv.ColumnHeadersHeight = 45;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv.DefaultCellStyle = dataGridViewCellStyle10;
            this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv.EnableHeadersVisualStyles = false;
            this.dgv.GridColor = System.Drawing.Color.WhiteSmoke;
            this.dgv.Location = new System.Drawing.Point(0, 0);
            this.dgv.MultiSelect = false;
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersVisible = false;
            this.dgv.RowHeadersWidth = 50;
            this.dgv.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(1365, 248);
            this.dgv.TabIndex = 74;
            // 
            // dgv1
            // 
            this.dgv1.AllowUserToAddRows = false;
            this.dgv1.AllowUserToDeleteRows = false;
            this.dgv1.AllowUserToOrderColumns = true;
            this.dgv1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv1.BackgroundColor = System.Drawing.Color.White;
            this.dgv1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.LightSlateGray;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.dgv1.ColumnHeadersHeight = 40;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv1.DefaultCellStyle = dataGridViewCellStyle12;
            this.dgv1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv1.EnableHeadersVisualStyles = false;
            this.dgv1.GridColor = System.Drawing.Color.WhiteSmoke;
            this.dgv1.Location = new System.Drawing.Point(0, 0);
            this.dgv1.MultiSelect = false;
            this.dgv1.Name = "dgv1";
            this.dgv1.ReadOnly = true;
            this.dgv1.RowHeadersVisible = false;
            this.dgv1.RowHeadersWidth = 50;
            this.dgv1.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgv1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv1.Size = new System.Drawing.Size(1365, 172);
            this.dgv1.TabIndex = 84;
            // 
            // btnTxtDuplicadoDigital
            // 
            this.btnTxtDuplicadoDigital.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnTxtDuplicadoDigital.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTxtDuplicadoDigital.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnTxtDuplicadoDigital.FlatAppearance.BorderSize = 0;
            this.btnTxtDuplicadoDigital.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnTxtDuplicadoDigital.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnTxtDuplicadoDigital.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTxtDuplicadoDigital.Font = new System.Drawing.Font("Segoe UI Light", 12F);
            this.btnTxtDuplicadoDigital.ForeColor = System.Drawing.Color.White;
            this.btnTxtDuplicadoDigital.Image = global::CapaPresentacion.Properties.Resources.Download_32;
            this.btnTxtDuplicadoDigital.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnTxtDuplicadoDigital.Location = new System.Drawing.Point(1100, 112);
            this.btnTxtDuplicadoDigital.Name = "btnTxtDuplicadoDigital";
            this.btnTxtDuplicadoDigital.Size = new System.Drawing.Size(253, 34);
            this.btnTxtDuplicadoDigital.TabIndex = 93;
            this.btnTxtDuplicadoDigital.Text = "Generar Duplicado Digital";
            this.btnTxtDuplicadoDigital.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTxtDuplicadoDigital.UseVisualStyleBackColor = false;
            this.btnTxtDuplicadoDigital.Click += new System.EventHandler(this.btnTxtDuplicadoDigital_Click);
            // 
            // frmImpuestos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1365, 698);
            this.Controls.Add(this.spcMain);
            this.Controls.Add(this.pnlHead);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.pnFooter);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "frmImpuestos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmImpuestos";
            this.Load += new System.EventHandler(this.frmImpuestos_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmImpuestos_KeyDown);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgReturn)).EndInit();
            this.pnFooter.ResumeLayout(false);
            this.pnFooter.PerformLayout();
            this.pnlHead.ResumeLayout(false);
            this.pnlHead.PerformLayout();
            this.spcMain.Panel1.ResumeLayout(false);
            this.spcMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spcMain)).EndInit();
            this.spcMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox imgReturn;
        private System.Windows.Forms.Label lblTituloHeader;
        private System.Windows.Forms.Panel pnFooter;
        private System.Windows.Forms.Label lblTotal;
        private Controles.progress pgCircular;
        private System.Windows.Forms.Label lblDesde;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private Controles.boton btnBuscar;
        private Controles.dgv dgv;
        private System.Windows.Forms.DateTimePicker dtpdesde;
        private System.Windows.Forms.DateTimePicker dtphasta;
        private Controles.dgv dgv1;
        private Controles.boton btnReimprimeComprobante;
        private Controles.boton btnExportar;
        private System.Windows.Forms.ComboBox cboPuntosVenta;
        private System.Windows.Forms.Panel pnlHead;
        private System.Windows.Forms.SplitContainer spcMain;
        private Controles.boton btnGenerarTxt;
        private System.Windows.Forms.CheckBox chkMuestraRemito;
        private Controles.boton btnTxtDuplicadoElectronico;
        private System.Windows.Forms.TextBox txtBuscador;
        private System.Windows.Forms.Label lblBuscar;
        private Controles.boton btnTxtDuplicadoDigital;
    }
}