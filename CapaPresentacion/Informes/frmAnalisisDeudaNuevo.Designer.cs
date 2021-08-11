
namespace CapaPresentacion.Informes
{
    partial class frmAnalisisDeudaNuevo
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
            this.pnlBotones = new System.Windows.Forms.Panel();
            this.cboAnioDesde = new System.Windows.Forms.ComboBox();
            this.cboMesDesde = new System.Windows.Forms.ComboBox();
            this.btnExportar = new CapaPresentacion.Controles.boton();
            this.btnBuscar = new CapaPresentacion.Controles.boton();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTotalFacturado = new System.Windows.Forms.Label();
            this.lblDeuda = new System.Windows.Forms.Label();
            this.pgCircular = new CapaPresentacion.Controles.progress();
            this.dgvDatos = new CapaPresentacion.Controles.dgv(this.components);
            this.pnlFiltros = new System.Windows.Forms.Panel();
            this.cboLocalidades = new System.Windows.Forms.ComboBox();
            this.cboTipoFac = new System.Windows.Forms.ComboBox();
            this.lblTipoFac = new System.Windows.Forms.Label();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgReturn)).BeginInit();
            this.pnlBotones.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).BeginInit();
            this.pnlFiltros.SuspendLayout();
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
            this.panel3.Size = new System.Drawing.Size(911, 75);
            this.panel3.TabIndex = 37;
            // 
            // imgReturn
            // 
            this.imgReturn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.imgReturn.Image = global::CapaPresentacion.Properties.Resources.Left_Arrow_32;
            this.imgReturn.Location = new System.Drawing.Point(15, 21);
            this.imgReturn.Name = "imgReturn";
            this.imgReturn.Size = new System.Drawing.Size(32, 32);
            this.imgReturn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgReturn.TabIndex = 32;
            this.imgReturn.TabStop = false;
            this.imgReturn.Click += new System.EventHandler(this.imgReturn_Click);
            // 
            // lblTituloHeader
            // 
            this.lblTituloHeader.AutoSize = true;
            this.lblTituloHeader.Font = new System.Drawing.Font("Segoe UI Light", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloHeader.ForeColor = System.Drawing.Color.White;
            this.lblTituloHeader.Location = new System.Drawing.Point(53, 26);
            this.lblTituloHeader.Name = "lblTituloHeader";
            this.lblTituloHeader.Size = new System.Drawing.Size(178, 25);
            this.lblTituloHeader.TabIndex = 31;
            this.lblTituloHeader.Text = "Facturacion / Deudas";
            // 
            // pnlBotones
            // 
            this.pnlBotones.Controls.Add(this.cboAnioDesde);
            this.pnlBotones.Controls.Add(this.cboMesDesde);
            this.pnlBotones.Controls.Add(this.btnExportar);
            this.pnlBotones.Controls.Add(this.btnBuscar);
            this.pnlBotones.Controls.Add(this.label1);
            this.pnlBotones.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBotones.Location = new System.Drawing.Point(0, 75);
            this.pnlBotones.Name = "pnlBotones";
            this.pnlBotones.Size = new System.Drawing.Size(911, 54);
            this.pnlBotones.TabIndex = 38;
            // 
            // cboAnioDesde
            // 
            this.cboAnioDesde.Font = new System.Drawing.Font("Segoe UI Light", 12.25F);
            this.cboAnioDesde.FormattingEnabled = true;
            this.cboAnioDesde.Location = new System.Drawing.Point(162, 15);
            this.cboAnioDesde.Name = "cboAnioDesde";
            this.cboAnioDesde.Size = new System.Drawing.Size(103, 29);
            this.cboAnioDesde.TabIndex = 317;
            // 
            // cboMesDesde
            // 
            this.cboMesDesde.Font = new System.Drawing.Font("Segoe UI Light", 12.25F);
            this.cboMesDesde.FormattingEnabled = true;
            this.cboMesDesde.Location = new System.Drawing.Point(84, 15);
            this.cboMesDesde.Name = "cboMesDesde";
            this.cboMesDesde.Size = new System.Drawing.Size(72, 29);
            this.cboMesDesde.TabIndex = 316;
            // 
            // btnExportar
            // 
            this.btnExportar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportar.AutoSize = true;
            this.btnExportar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnExportar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExportar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnExportar.FlatAppearance.BorderSize = 0;
            this.btnExportar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnExportar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnExportar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportar.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnExportar.ForeColor = System.Drawing.Color.White;
            this.btnExportar.Image = global::CapaPresentacion.Properties.Resources.Save_32;
            this.btnExportar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExportar.Location = new System.Drawing.Point(792, 7);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(107, 38);
            this.btnExportar.TabIndex = 315;
            this.btnExportar.Text = "Exportar";
            this.btnExportar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExportar.UseVisualStyleBackColor = false;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.AutoSize = true;
            this.btnBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnBuscar.FlatAppearance.BorderSize = 0;
            this.btnBuscar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnBuscar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnBuscar.ForeColor = System.Drawing.Color.White;
            this.btnBuscar.Image = global::CapaPresentacion.Properties.Resources.lupa;
            this.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBuscar.Location = new System.Drawing.Point(271, 9);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(89, 39);
            this.btnBuscar.TabIndex = 314;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 21);
            this.label1.TabIndex = 313;
            this.label1.Text = "Periodo:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblTotalFacturado);
            this.panel1.Controls.Add(this.lblDeuda);
            this.panel1.Controls.Add(this.pgCircular);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 469);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(911, 38);
            this.panel1.TabIndex = 119;
            // 
            // lblTotalFacturado
            // 
            this.lblTotalFacturado.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblTotalFacturado.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblTotalFacturado.ForeColor = System.Drawing.Color.Black;
            this.lblTotalFacturado.Location = new System.Drawing.Point(323, 0);
            this.lblTotalFacturado.Name = "lblTotalFacturado";
            this.lblTotalFacturado.Size = new System.Drawing.Size(269, 38);
            this.lblTotalFacturado.TabIndex = 314;
            this.lblTotalFacturado.Text = "Total facturado:";
            this.lblTotalFacturado.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDeuda
            // 
            this.lblDeuda.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblDeuda.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblDeuda.ForeColor = System.Drawing.Color.Black;
            this.lblDeuda.Location = new System.Drawing.Point(592, 0);
            this.lblDeuda.Name = "lblDeuda";
            this.lblDeuda.Size = new System.Drawing.Size(278, 38);
            this.lblDeuda.TabIndex = 315;
            this.lblDeuda.Text = "Total sin cobrar:";
            this.lblDeuda.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pgCircular
            // 
            this.pgCircular.Dock = System.Windows.Forms.DockStyle.Right;
            this.pgCircular.Location = new System.Drawing.Point(870, 0);
            this.pgCircular.Margin = new System.Windows.Forms.Padding(13, 3, 3, 3);
            this.pgCircular.Name = "pgCircular";
            this.pgCircular.Percentage = 0F;
            this.pgCircular.Rotation = CapaPresentacion.Controles.RotationType.CounterClockwise;
            this.pgCircular.Size = new System.Drawing.Size(41, 41);
            this.pgCircular.TabIndex = 302;
            // 
            // dgvDatos
            // 
            this.dgvDatos.AllowUserToAddRows = false;
            this.dgvDatos.AllowUserToDeleteRows = false;
            this.dgvDatos.AllowUserToOrderColumns = true;
            this.dgvDatos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDatos.BackgroundColor = System.Drawing.Color.White;
            this.dgvDatos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvDatos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSlateGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDatos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDatos.ColumnHeadersHeight = 40;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDatos.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDatos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDatos.EnableHeadersVisualStyles = false;
            this.dgvDatos.GridColor = System.Drawing.Color.WhiteSmoke;
            this.dgvDatos.Location = new System.Drawing.Point(0, 171);
            this.dgvDatos.MultiSelect = false;
            this.dgvDatos.Name = "dgvDatos";
            this.dgvDatos.ReadOnly = true;
            this.dgvDatos.RowHeadersVisible = false;
            this.dgvDatos.RowHeadersWidth = 50;
            this.dgvDatos.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvDatos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDatos.Size = new System.Drawing.Size(911, 298);
            this.dgvDatos.TabIndex = 120;
            this.dgvDatos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDatos_CellDoubleClick);
            // 
            // pnlFiltros
            // 
            this.pnlFiltros.Controls.Add(this.cboLocalidades);
            this.pnlFiltros.Controls.Add(this.cboTipoFac);
            this.pnlFiltros.Controls.Add(this.lblTipoFac);
            this.pnlFiltros.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFiltros.Enabled = false;
            this.pnlFiltros.Location = new System.Drawing.Point(0, 129);
            this.pnlFiltros.Name = "pnlFiltros";
            this.pnlFiltros.Size = new System.Drawing.Size(911, 42);
            this.pnlFiltros.TabIndex = 121;
            // 
            // cboLocalidades
            // 
            this.cboLocalidades.Font = new System.Drawing.Font("Segoe UI Light", 12.25F);
            this.cboLocalidades.FormattingEnabled = true;
            this.cboLocalidades.Location = new System.Drawing.Point(297, 6);
            this.cboLocalidades.Name = "cboLocalidades";
            this.cboLocalidades.Size = new System.Drawing.Size(292, 29);
            this.cboLocalidades.TabIndex = 318;
            this.cboLocalidades.Visible = false;
            this.cboLocalidades.SelectionChangeCommitted += new System.EventHandler(this.cboLocalidades_SelectionChangeCommitted);
            // 
            // cboTipoFac
            // 
            this.cboTipoFac.Font = new System.Drawing.Font("Segoe UI Light", 12.25F);
            this.cboTipoFac.FormattingEnabled = true;
            this.cboTipoFac.Location = new System.Drawing.Point(84, 6);
            this.cboTipoFac.Name = "cboTipoFac";
            this.cboTipoFac.Size = new System.Drawing.Size(207, 29);
            this.cboTipoFac.TabIndex = 317;
            this.cboTipoFac.SelectionChangeCommitted += new System.EventHandler(this.cboTipoFac_SelectionChangeCommitted);
            // 
            // lblTipoFac
            // 
            this.lblTipoFac.AutoSize = true;
            this.lblTipoFac.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblTipoFac.ForeColor = System.Drawing.Color.Black;
            this.lblTipoFac.Location = new System.Drawing.Point(30, 9);
            this.lblTipoFac.Name = "lblTipoFac";
            this.lblTipoFac.Size = new System.Drawing.Size(48, 21);
            this.lblTipoFac.TabIndex = 313;
            this.lblTipoFac.Text = "Zona:";
            // 
            // frmAnalisisDeudaNuevo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(911, 507);
            this.Controls.Add(this.dgvDatos);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlFiltros);
            this.Controls.Add(this.pnlBotones);
            this.Controls.Add(this.panel3);
            this.KeyPreview = true;
            this.Name = "frmAnalisisDeudaNuevo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Analisis de deudas";
            this.Load += new System.EventHandler(this.frmAnalisisDeudaNuevo_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmAnalisisDeudaNuevo_KeyDown);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgReturn)).EndInit();
            this.pnlBotones.ResumeLayout(false);
            this.pnlBotones.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).EndInit();
            this.pnlFiltros.ResumeLayout(false);
            this.pnlFiltros.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox imgReturn;
        private System.Windows.Forms.Label lblTituloHeader;
        private System.Windows.Forms.Panel pnlBotones;
        private System.Windows.Forms.Label label1;
        private Controles.boton btnBuscar;
        private Controles.dgv dgvDatos;
        private System.Windows.Forms.Panel panel1;
        private Controles.progress pgCircular;
        private Controles.boton btnExportar;
        private System.Windows.Forms.ComboBox cboAnioDesde;
        private System.Windows.Forms.ComboBox cboMesDesde;
        private System.Windows.Forms.Label lblDeuda;
        private System.Windows.Forms.Label lblTotalFacturado;
        private System.Windows.Forms.Panel pnlFiltros;
        private System.Windows.Forms.ComboBox cboLocalidades;
        private System.Windows.Forms.ComboBox cboTipoFac;
        private System.Windows.Forms.Label lblTipoFac;
    }
}