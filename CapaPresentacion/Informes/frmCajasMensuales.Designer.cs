
namespace CapaPresentacion.Informes
{
    partial class frmCajasMensuales
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
            this.flyHead = new System.Windows.Forms.FlowLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.cboInformes = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cboCuenta = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cboDesde = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboHasta = new System.Windows.Forms.ComboBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.lnkConfig = new System.Windows.Forms.LinkLabel();
            this.bgwWorker = new System.ComponentModel.BackgroundWorker();
            this.pgProgreso = new System.Windows.Forms.ProgressBar();
            this.pnlEstado = new System.Windows.Forms.Panel();
            this.lblEstado2 = new System.Windows.Forms.Label();
            this.lblEstado = new System.Windows.Forms.Label();
            this.pgCircular = new CapaPresentacion.Controles.progress();
            this.dgvInforme = new CapaPresentacion.Controles.dgv(this.components);
            this.btnBuscar = new CapaPresentacion.Controles.boton();
            this.boton2 = new CapaPresentacion.Controles.boton();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgReturn)).BeginInit();
            this.flyHead.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.pnlEstado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInforme)).BeginInit();
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
            this.panel3.Size = new System.Drawing.Size(1266, 75);
            this.panel3.TabIndex = 195;
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
            this.lblTituloHeader.Text = "Informes caja mensuales";
            // 
            // flyHead
            // 
            this.flyHead.Controls.Add(this.label3);
            this.flyHead.Controls.Add(this.cboInformes);
            this.flyHead.Controls.Add(this.label4);
            this.flyHead.Controls.Add(this.cboCuenta);
            this.flyHead.Controls.Add(this.label1);
            this.flyHead.Controls.Add(this.cboDesde);
            this.flyHead.Controls.Add(this.label2);
            this.flyHead.Controls.Add(this.cboHasta);
            this.flyHead.Controls.Add(this.btnBuscar);
            this.flyHead.Controls.Add(this.boton2);
            this.flyHead.Dock = System.Windows.Forms.DockStyle.Top;
            this.flyHead.Location = new System.Drawing.Point(0, 75);
            this.flyHead.Name = "flyHead";
            this.flyHead.Size = new System.Drawing.Size(1266, 41);
            this.flyHead.TabIndex = 196;
            this.flyHead.Paint += new System.Windows.Forms.PaintEventHandler(this.flyHead_Paint);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 5);
            this.label3.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 21);
            this.label3.TabIndex = 390;
            this.label3.Text = "Informe";
            // 
            // cboInformes
            // 
            this.cboInformes.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboInformes.FormattingEnabled = true;
            this.cboInformes.Location = new System.Drawing.Point(74, 3);
            this.cboInformes.Name = "cboInformes";
            this.cboInformes.Size = new System.Drawing.Size(143, 29);
            this.cboInformes.TabIndex = 391;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(223, 5);
            this.label4.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 21);
            this.label4.TabIndex = 393;
            this.label4.Text = "Cuenta";
            // 
            // cboCuenta
            // 
            this.cboCuenta.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboCuenta.FormattingEnabled = true;
            this.cboCuenta.Items.AddRange(new object[] {
            "1",
            "2"});
            this.cboCuenta.Location = new System.Drawing.Point(288, 3);
            this.cboCuenta.Name = "cboCuenta";
            this.cboCuenta.Size = new System.Drawing.Size(59, 29);
            this.cboCuenta.TabIndex = 394;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(353, 5);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 21);
            this.label1.TabIndex = 385;
            this.label1.Text = "Caja Desde";
            // 
            // cboDesde
            // 
            this.cboDesde.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboDesde.FormattingEnabled = true;
            this.cboDesde.Location = new System.Drawing.Point(446, 3);
            this.cboDesde.Name = "cboDesde";
            this.cboDesde.Size = new System.Drawing.Size(236, 29);
            this.cboDesde.TabIndex = 386;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(688, 5);
            this.label2.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 21);
            this.label2.TabIndex = 387;
            this.label2.Text = "Caja Hasta";
            // 
            // cboHasta
            // 
            this.cboHasta.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboHasta.FormattingEnabled = true;
            this.cboHasta.Location = new System.Drawing.Point(777, 3);
            this.cboHasta.Name = "cboHasta";
            this.cboHasta.Size = new System.Drawing.Size(274, 29);
            this.cboHasta.TabIndex = 388;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.lnkConfig);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 467);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1266, 30);
            this.flowLayoutPanel1.TabIndex = 197;
            // 
            // lnkConfig
            // 
            this.lnkConfig.AutoSize = true;
            this.lnkConfig.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkConfig.Location = new System.Drawing.Point(3, 0);
            this.lnkConfig.Name = "lnkConfig";
            this.lnkConfig.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.lnkConfig.Size = new System.Drawing.Size(141, 23);
            this.lnkConfig.TabIndex = 0;
            this.lnkConfig.TabStop = true;
            this.lnkConfig.Text = "Configurar informes";
            this.lnkConfig.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkConfig_LinkClicked);
            this.lnkConfig.Click += new System.EventHandler(this.lnkConfig_Click);
            // 
            // bgwWorker
            // 
            this.bgwWorker.WorkerReportsProgress = true;
            this.bgwWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgwWorker_ProgressChanged);
            // 
            // pgProgreso
            // 
            this.pgProgreso.Location = new System.Drawing.Point(14, 81);
            this.pgProgreso.Name = "pgProgreso";
            this.pgProgreso.Size = new System.Drawing.Size(497, 22);
            this.pgProgreso.TabIndex = 199;
            // 
            // pnlEstado
            // 
            this.pnlEstado.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pnlEstado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlEstado.Controls.Add(this.lblEstado2);
            this.pnlEstado.Controls.Add(this.pgCircular);
            this.pnlEstado.Controls.Add(this.lblEstado);
            this.pnlEstado.Controls.Add(this.pgProgreso);
            this.pnlEstado.Location = new System.Drawing.Point(274, 208);
            this.pnlEstado.Name = "pnlEstado";
            this.pnlEstado.Size = new System.Drawing.Size(560, 122);
            this.pnlEstado.TabIndex = 200;
            this.pnlEstado.Visible = false;
            // 
            // lblEstado2
            // 
            this.lblEstado2.AutoSize = true;
            this.lblEstado2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstado2.Location = new System.Drawing.Point(168, 48);
            this.lblEstado2.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.lblEstado2.Name = "lblEstado2";
            this.lblEstado2.Size = new System.Drawing.Size(121, 21);
            this.lblEstado2.TabIndex = 388;
            this.lblEstado2.Text = "Puntos de venta";
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstado.Location = new System.Drawing.Point(168, 22);
            this.lblEstado.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(206, 21);
            this.lblEstado.TabIndex = 386;
            this.lblEstado.Text = "Recopilando cajas cerradas...";
            // 
            // pgCircular
            // 
            this.pgCircular.Location = new System.Drawing.Point(517, 78);
            this.pgCircular.Name = "pgCircular";
            this.pgCircular.Percentage = 0F;
            this.pgCircular.Size = new System.Drawing.Size(26, 26);
            this.pgCircular.TabIndex = 387;
            this.pgCircular.Text = "progress1";
            // 
            // dgvInforme
            // 
            this.dgvInforme.AllowUserToAddRows = false;
            this.dgvInforme.AllowUserToDeleteRows = false;
            this.dgvInforme.AllowUserToOrderColumns = true;
            this.dgvInforme.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvInforme.BackgroundColor = System.Drawing.Color.White;
            this.dgvInforme.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvInforme.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSlateGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvInforme.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvInforme.ColumnHeadersHeight = 40;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvInforme.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvInforme.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvInforme.EnableHeadersVisualStyles = false;
            this.dgvInforme.GridColor = System.Drawing.Color.WhiteSmoke;
            this.dgvInforme.Location = new System.Drawing.Point(0, 116);
            this.dgvInforme.MultiSelect = false;
            this.dgvInforme.Name = "dgvInforme";
            this.dgvInforme.ReadOnly = true;
            this.dgvInforme.RowHeadersVisible = false;
            this.dgvInforme.RowHeadersWidth = 50;
            this.dgvInforme.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvInforme.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvInforme.Size = new System.Drawing.Size(1266, 351);
            this.dgvInforme.TabIndex = 198;
            this.dgvInforme.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvInforme_CellDoubleClick);
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnBuscar.FlatAppearance.BorderSize = 0;
            this.btnBuscar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnBuscar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.ForeColor = System.Drawing.Color.White;
            this.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBuscar.Location = new System.Drawing.Point(1057, 3);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(83, 30);
            this.btnBuscar.TabIndex = 389;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.boton1_Click);
            // 
            // boton2
            // 
            this.boton2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.boton2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.boton2.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.boton2.FlatAppearance.BorderSize = 0;
            this.boton2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.boton2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.boton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.boton2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.boton2.ForeColor = System.Drawing.Color.White;
            this.boton2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.boton2.Location = new System.Drawing.Point(1146, 3);
            this.boton2.Name = "boton2";
            this.boton2.Size = new System.Drawing.Size(93, 30);
            this.boton2.TabIndex = 392;
            this.boton2.Text = "Exportar";
            this.boton2.UseVisualStyleBackColor = true;
            this.boton2.Click += new System.EventHandler(this.boton2_Click);
            // 
            // frmCajasMensuales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1266, 497);
            this.Controls.Add(this.pnlEstado);
            this.Controls.Add(this.dgvInforme);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.flyHead);
            this.Controls.Add(this.panel3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmCajasMensuales";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cajas mensuales";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmCajasMensuales_Load);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgReturn)).EndInit();
            this.flyHead.ResumeLayout(false);
            this.flyHead.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.pnlEstado.ResumeLayout(false);
            this.pnlEstado.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInforme)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox imgReturn;
        private System.Windows.Forms.Label lblTituloHeader;
        private System.Windows.Forms.FlowLayoutPanel flyHead;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private Controles.dgv dgvInforme;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboDesde;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboHasta;
        private Controles.boton btnBuscar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboInformes;
        private Controles.boton boton2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboCuenta;
        private System.ComponentModel.BackgroundWorker bgwWorker;
        private System.Windows.Forms.ProgressBar pgProgreso;
        private System.Windows.Forms.Panel pnlEstado;
        private Controles.progress pgCircular;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.Label lblEstado2;
        private System.Windows.Forms.LinkLabel lnkConfig;
    }
}