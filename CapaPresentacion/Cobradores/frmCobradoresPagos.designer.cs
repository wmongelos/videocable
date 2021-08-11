namespace CapaPresentacion
{
    partial class frmCobradoresPagos
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
            this.panel3 = new System.Windows.Forms.Panel();
            this.imgReturn = new System.Windows.Forms.PictureBox();
            this.lblTituloHeader = new System.Windows.Forms.Label();
            this.lblCobrador = new System.Windows.Forms.Label();
            this.lblrecibodesde1 = new System.Windows.Forms.Label();
            this.lblrecibohasta1 = new System.Windows.Forms.Label();
            this.lblpesos1 = new System.Windows.Forms.Label();
            this.txtReciboDesde1 = new System.Windows.Forms.TextBox();
            this.txtReciboHasta1 = new System.Windows.Forms.TextBox();
            this.txtReciboHasta2 = new System.Windows.Forms.TextBox();
            this.txtReciboDesde2 = new System.Windows.Forms.TextBox();
            this.lblMontoTotal = new System.Windows.Forms.Label();
            this.pnlInferior = new System.Windows.Forms.Panel();
            this.lblTotal = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dgvForma1 = new CapaPresentacion.Controles.dgv(this.components);
            this.panel5 = new System.Windows.Forms.Panel();
            this.lblTotal1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dgvForma2 = new CapaPresentacion.Controles.dgv(this.components);
            this.panel4 = new System.Windows.Forms.Panel();
            this.lblTotal2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.pnlSuperior = new System.Windows.Forms.Panel();
            this.btnGuardar = new CapaPresentacion.Controles.boton();
            this.boton1 = new CapaPresentacion.Controles.boton();
            this.cboCobradores = new CapaPresentacion.Controles.combo(this.components);
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgReturn)).BeginInit();
            this.pnlInferior.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvForma1)).BeginInit();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvForma2)).BeginInit();
            this.panel4.SuspendLayout();
            this.pnlSuperior.SuspendLayout();
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
            this.panel3.Size = new System.Drawing.Size(1150, 75);
            this.panel3.TabIndex = 89;
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
            this.lblTituloHeader.Text = "Pago de Cobradores";
            // 
            // lblCobrador
            // 
            this.lblCobrador.AutoSize = true;
            this.lblCobrador.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCobrador.ForeColor = System.Drawing.Color.Black;
            this.lblCobrador.Location = new System.Drawing.Point(8, 12);
            this.lblCobrador.Name = "lblCobrador";
            this.lblCobrador.Size = new System.Drawing.Size(76, 21);
            this.lblCobrador.TabIndex = 92;
            this.lblCobrador.Text = "Cobrador";
            // 
            // lblrecibodesde1
            // 
            this.lblrecibodesde1.AutoSize = true;
            this.lblrecibodesde1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblrecibodesde1.ForeColor = System.Drawing.Color.Black;
            this.lblrecibodesde1.Location = new System.Drawing.Point(7, 48);
            this.lblrecibodesde1.Name = "lblrecibodesde1";
            this.lblrecibodesde1.Size = new System.Drawing.Size(102, 21);
            this.lblrecibodesde1.TabIndex = 93;
            this.lblrecibodesde1.Text = "Recibo desde";
            // 
            // lblrecibohasta1
            // 
            this.lblrecibohasta1.AutoSize = true;
            this.lblrecibohasta1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblrecibohasta1.ForeColor = System.Drawing.Color.Black;
            this.lblrecibohasta1.Location = new System.Drawing.Point(11, 86);
            this.lblrecibohasta1.Name = "lblrecibohasta1";
            this.lblrecibohasta1.Size = new System.Drawing.Size(98, 21);
            this.lblrecibohasta1.TabIndex = 97;
            this.lblrecibohasta1.Text = "Recibo hasta";
            // 
            // lblpesos1
            // 
            this.lblpesos1.AutoSize = true;
            this.lblpesos1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblpesos1.ForeColor = System.Drawing.Color.Black;
            this.lblpesos1.Location = new System.Drawing.Point(52, 120);
            this.lblpesos1.Name = "lblpesos1";
            this.lblpesos1.Size = new System.Drawing.Size(56, 21);
            this.lblpesos1.TabIndex = 98;
            this.lblpesos1.Text = "Monto";
            // 
            // txtReciboDesde1
            // 
            this.txtReciboDesde1.Font = new System.Drawing.Font("Segoe UI Light", 12F);
            this.txtReciboDesde1.Location = new System.Drawing.Point(114, 45);
            this.txtReciboDesde1.Name = "txtReciboDesde1";
            this.txtReciboDesde1.ReadOnly = true;
            this.txtReciboDesde1.Size = new System.Drawing.Size(129, 29);
            this.txtReciboDesde1.TabIndex = 100;
            this.txtReciboDesde1.Text = "0";
            this.txtReciboDesde1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtReciboHasta1
            // 
            this.txtReciboHasta1.Font = new System.Drawing.Font("Segoe UI Light", 12F);
            this.txtReciboHasta1.Location = new System.Drawing.Point(114, 83);
            this.txtReciboHasta1.Name = "txtReciboHasta1";
            this.txtReciboHasta1.Size = new System.Drawing.Size(129, 29);
            this.txtReciboHasta1.TabIndex = 1;
            this.txtReciboHasta1.Text = "0";
            this.txtReciboHasta1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtReciboHasta1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtReciboHasta1_KeyPress);
            // 
            // txtReciboHasta2
            // 
            this.txtReciboHasta2.Font = new System.Drawing.Font("Segoe UI Light", 12F);
            this.txtReciboHasta2.Location = new System.Drawing.Point(117, 83);
            this.txtReciboHasta2.Name = "txtReciboHasta2";
            this.txtReciboHasta2.Size = new System.Drawing.Size(152, 29);
            this.txtReciboHasta2.TabIndex = 3;
            this.txtReciboHasta2.Text = "0";
            this.txtReciboHasta2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtReciboHasta2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtReciboHasta2_KeyPress);
            // 
            // txtReciboDesde2
            // 
            this.txtReciboDesde2.Font = new System.Drawing.Font("Segoe UI Light", 12F);
            this.txtReciboDesde2.Location = new System.Drawing.Point(117, 45);
            this.txtReciboDesde2.Name = "txtReciboDesde2";
            this.txtReciboDesde2.ReadOnly = true;
            this.txtReciboDesde2.Size = new System.Drawing.Size(152, 29);
            this.txtReciboDesde2.TabIndex = 103;
            this.txtReciboDesde2.Text = "0";
            this.txtReciboDesde2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblMontoTotal
            // 
            this.lblMontoTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMontoTotal.AutoSize = true;
            this.lblMontoTotal.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.lblMontoTotal.ForeColor = System.Drawing.Color.White;
            this.lblMontoTotal.Location = new System.Drawing.Point(992, 10);
            this.lblMontoTotal.Name = "lblMontoTotal";
            this.lblMontoTotal.Size = new System.Drawing.Size(70, 28);
            this.lblMontoTotal.TabIndex = 106;
            this.lblMontoTotal.Text = "Total $";
            // 
            // pnlInferior
            // 
            this.pnlInferior.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.pnlInferior.Controls.Add(this.lblTotal);
            this.pnlInferior.Controls.Add(this.lblMontoTotal);
            this.pnlInferior.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlInferior.Location = new System.Drawing.Point(0, 494);
            this.pnlInferior.Name = "pnlInferior";
            this.pnlInferior.Size = new System.Drawing.Size(1150, 47);
            this.pnlInferior.TabIndex = 327;
            // 
            // lblTotal
            // 
            this.lblTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.lblTotal.ForeColor = System.Drawing.Color.White;
            this.lblTotal.Location = new System.Drawing.Point(1068, 10);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(49, 28);
            this.lblTotal.TabIndex = 107;
            this.lblTotal.Text = "0.00";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 123);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dgvForma1);
            this.splitContainer1.Panel1.Controls.Add(this.panel5);
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgvForma2);
            this.splitContainer1.Panel2.Controls.Add(this.panel4);
            this.splitContainer1.Panel2.Controls.Add(this.label5);
            this.splitContainer1.Size = new System.Drawing.Size(1150, 371);
            this.splitContainer1.SplitterDistance = 575;
            this.splitContainer1.TabIndex = 330;
            // 
            // dgvForma1
            // 
            this.dgvForma1.AllowUserToAddRows = false;
            this.dgvForma1.AllowUserToDeleteRows = false;
            this.dgvForma1.AllowUserToOrderColumns = true;
            this.dgvForma1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvForma1.BackgroundColor = System.Drawing.Color.White;
            this.dgvForma1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvForma1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSlateGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvForma1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvForma1.ColumnHeadersHeight = 40;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvForma1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvForma1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvForma1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.dgvForma1.EnableHeadersVisualStyles = false;
            this.dgvForma1.GridColor = System.Drawing.Color.WhiteSmoke;
            this.dgvForma1.Location = new System.Drawing.Point(256, 32);
            this.dgvForma1.MultiSelect = false;
            this.dgvForma1.Name = "dgvForma1";
            this.dgvForma1.ReadOnly = true;
            this.dgvForma1.RowHeadersVisible = false;
            this.dgvForma1.RowHeadersWidth = 50;
            this.dgvForma1.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvForma1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvForma1.Size = new System.Drawing.Size(319, 339);
            this.dgvForma1.TabIndex = 326;
            this.dgvForma1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFunciones_CellClick);
            this.dgvForma1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvForma1_CellValueChanged);
            this.dgvForma1.SelectionChanged += new System.EventHandler(this.dgvForma1_SelectionChanged);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.lblTotal1);
            this.panel5.Controls.Add(this.txtReciboDesde1);
            this.panel5.Controls.Add(this.txtReciboHasta1);
            this.panel5.Controls.Add(this.lblpesos1);
            this.panel5.Controls.Add(this.lblrecibodesde1);
            this.panel5.Controls.Add(this.lblrecibohasta1);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel5.Location = new System.Drawing.Point(0, 32);
            this.panel5.Name = "panel5";
            this.panel5.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.panel5.Size = new System.Drawing.Size(256, 339);
            this.panel5.TabIndex = 330;
            // 
            // lblTotal1
            // 
            this.lblTotal1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal1.ForeColor = System.Drawing.Color.Black;
            this.lblTotal1.Location = new System.Drawing.Point(114, 120);
            this.lblTotal1.Name = "lblTotal1";
            this.lblTotal1.Size = new System.Drawing.Size(129, 21);
            this.lblTotal1.TabIndex = 101;
            this.lblTotal1.Text = "Monto";
            this.lblTotal1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.SlateGray;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 17F);
            this.label4.ForeColor = System.Drawing.SystemColors.Control;
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(575, 32);
            this.label4.TabIndex = 109;
            this.label4.Text = "CUENTA 1";
            // 
            // dgvForma2
            // 
            this.dgvForma2.AllowUserToAddRows = false;
            this.dgvForma2.AllowUserToDeleteRows = false;
            this.dgvForma2.AllowUserToOrderColumns = true;
            this.dgvForma2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvForma2.BackgroundColor = System.Drawing.Color.White;
            this.dgvForma2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvForma2.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.LightSlateGray;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvForma2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvForma2.ColumnHeadersHeight = 40;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvForma2.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvForma2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvForma2.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.dgvForma2.EnableHeadersVisualStyles = false;
            this.dgvForma2.GridColor = System.Drawing.Color.WhiteSmoke;
            this.dgvForma2.Location = new System.Drawing.Point(283, 32);
            this.dgvForma2.MultiSelect = false;
            this.dgvForma2.Name = "dgvForma2";
            this.dgvForma2.ReadOnly = true;
            this.dgvForma2.RowHeadersVisible = false;
            this.dgvForma2.RowHeadersWidth = 50;
            this.dgvForma2.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvForma2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvForma2.Size = new System.Drawing.Size(288, 339);
            this.dgvForma2.TabIndex = 329;
            this.dgvForma2.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvForma2_CellClick);
            this.dgvForma2.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvForma2_CellEndEdit);
            this.dgvForma2.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvForma2_CellValueChanged);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.lblTotal2);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Controls.Add(this.txtReciboDesde2);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.txtReciboHasta2);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(0, 32);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(283, 339);
            this.panel4.TabIndex = 0;
            // 
            // lblTotal2
            // 
            this.lblTotal2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal2.ForeColor = System.Drawing.Color.Black;
            this.lblTotal2.Location = new System.Drawing.Point(117, 120);
            this.lblTotal2.Name = "lblTotal2";
            this.lblTotal2.Size = new System.Drawing.Size(152, 21);
            this.lblTotal2.TabIndex = 104;
            this.lblTotal2.Text = "Monto";
            this.lblTotal2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(55, 120);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 21);
            this.label1.TabIndex = 103;
            this.label1.Text = "Monto";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(9, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 21);
            this.label2.TabIndex = 101;
            this.label2.Text = "Recibo desde";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(13, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 21);
            this.label3.TabIndex = 102;
            this.label3.Text = "Recibo hasta";
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.LightSteelBlue;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Dock = System.Windows.Forms.DockStyle.Top;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 17F);
            this.label5.ForeColor = System.Drawing.SystemColors.Control;
            this.label5.Location = new System.Drawing.Point(0, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(571, 32);
            this.label5.TabIndex = 330;
            this.label5.Text = "CUENTA 2";
            // 
            // pnlSuperior
            // 
            this.pnlSuperior.Controls.Add(this.btnGuardar);
            this.pnlSuperior.Controls.Add(this.boton1);
            this.pnlSuperior.Controls.Add(this.cboCobradores);
            this.pnlSuperior.Controls.Add(this.lblCobrador);
            this.pnlSuperior.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSuperior.Location = new System.Drawing.Point(0, 75);
            this.pnlSuperior.Name = "pnlSuperior";
            this.pnlSuperior.Size = new System.Drawing.Size(1150, 48);
            this.pnlSuperior.TabIndex = 331;
            this.pnlSuperior.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlSuperior_Paint);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(84)))), ((int)(((byte)(101)))));
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(84)))), ((int)(((byte)(101)))));
            this.btnGuardar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Image = global::CapaPresentacion.Properties.Resources.Save_32;
            this.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGuardar.Location = new System.Drawing.Point(900, 5);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(116, 35);
            this.btnGuardar.TabIndex = 5;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // boton1
            // 
            this.boton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.boton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.boton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.boton1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(84)))), ((int)(((byte)(101)))));
            this.boton1.FlatAppearance.BorderSize = 0;
            this.boton1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(84)))), ((int)(((byte)(101)))));
            this.boton1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            this.boton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.boton1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.boton1.ForeColor = System.Drawing.Color.White;
            this.boton1.Image = global::CapaPresentacion.Properties.Resources.Data_Edit_32;
            this.boton1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.boton1.Location = new System.Drawing.Point(1022, 5);
            this.boton1.Name = "boton1";
            this.boton1.Size = new System.Drawing.Size(116, 35);
            this.boton1.TabIndex = 108;
            this.boton1.Text = "Editar";
            this.boton1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.boton1.UseVisualStyleBackColor = false;
            this.boton1.Click += new System.EventHandler(this.boton1_Click);
            // 
            // cboCobradores
            // 
            this.cboCobradores.BorderColor = System.Drawing.Color.Gainsboro;
            this.cboCobradores.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCobradores.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboCobradores.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboCobradores.ForeColor = System.Drawing.Color.Black;
            this.cboCobradores.FormattingEnabled = true;
            this.cboCobradores.Location = new System.Drawing.Point(90, 9);
            this.cboCobradores.Name = "cboCobradores";
            this.cboCobradores.Size = new System.Drawing.Size(286, 29);
            this.cboCobradores.TabIndex = 0;
            this.cboCobradores.SelectedValueChanged += new System.EventHandler(this.cboCobradores_SelectedValueChanged);
            // 
            // frmCobradoresPagos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1150, 541);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.pnlSuperior);
            this.Controls.Add(this.pnlInferior);
            this.Controls.Add(this.panel3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frmCobradoresPagos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmCobradoresPagos";
            this.Load += new System.EventHandler(this.frmCobradoresPagos_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmCobradoresPagos_KeyDown);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgReturn)).EndInit();
            this.pnlInferior.ResumeLayout(false);
            this.pnlInferior.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvForma1)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvForma2)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.pnlSuperior.ResumeLayout(false);
            this.pnlSuperior.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox imgReturn;
        private System.Windows.Forms.Label lblTituloHeader;
        private Controles.combo cboCobradores;
        private System.Windows.Forms.Label lblCobrador;
        private System.Windows.Forms.Label lblrecibodesde1;
        private System.Windows.Forms.Label lblrecibohasta1;
        private System.Windows.Forms.Label lblpesos1;
        private System.Windows.Forms.TextBox txtReciboDesde1;
        private System.Windows.Forms.TextBox txtReciboHasta1;
        private System.Windows.Forms.TextBox txtReciboHasta2;
        private System.Windows.Forms.TextBox txtReciboDesde2;
        private System.Windows.Forms.Label lblMontoTotal;
        private Controles.boton btnGuardar;
        private Controles.boton boton1;
        private Controles.dgv dgvForma1;
        private System.Windows.Forms.Panel pnlInferior;
        private Controles.dgv dgvForma2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel pnlSuperior;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblTotal1;
        private System.Windows.Forms.Label lblTotal2;
    }
}