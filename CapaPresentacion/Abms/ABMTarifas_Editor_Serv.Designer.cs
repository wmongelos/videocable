namespace CapaPresentacion.Abms
{
    partial class ABMTarifas_Editor_Serv
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
            this.panel3 = new System.Windows.Forms.Panel();
            this.imgReturn = new System.Windows.Forms.PictureBox();
            this.lblTituloHeader = new System.Windows.Forms.Label();
            this.pnFooter = new System.Windows.Forms.Panel();
            this.pnBotones = new System.Windows.Forms.Panel();
            this.lblTarifaNueva = new System.Windows.Forms.Label();
            this.lblTarifaNuevaDato = new System.Windows.Forms.Label();
            this.splContenedor = new System.Windows.Forms.SplitContainer();
            this.pnlReferencias = new System.Windows.Forms.Panel();
            this.lblServicio = new System.Windows.Forms.Label();
            this.lblTipoSer = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvZonasCategorias = new CapaPresentacion.Controles.dgv(this.components);
            this.dgvServicios = new CapaPresentacion.Controles.dgv(this.components);
            this.btnActualizar = new CapaPresentacion.Controles.boton();
            this.pgCircular = new CapaPresentacion.Controles.progress();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgReturn)).BeginInit();
            this.pnFooter.SuspendLayout();
            this.pnBotones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splContenedor)).BeginInit();
            this.splContenedor.Panel1.SuspendLayout();
            this.splContenedor.Panel2.SuspendLayout();
            this.splContenedor.SuspendLayout();
            this.pnlReferencias.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvZonasCategorias)).BeginInit();
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
            this.panel3.Size = new System.Drawing.Size(891, 75);
            this.panel3.TabIndex = 58;
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
            // pnFooter
            // 
            this.pnFooter.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnFooter.Controls.Add(this.pgCircular);
            this.pnFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnFooter.Location = new System.Drawing.Point(0, 420);
            this.pnFooter.Name = "pnFooter";
            this.pnFooter.Size = new System.Drawing.Size(891, 30);
            this.pnFooter.TabIndex = 53;
            // 
            // pnBotones
            // 
            this.pnBotones.Controls.Add(this.lblTarifaNueva);
            this.pnBotones.Controls.Add(this.lblTarifaNuevaDato);
            this.pnBotones.Controls.Add(this.btnActualizar);
            this.pnBotones.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnBotones.Location = new System.Drawing.Point(0, 75);
            this.pnBotones.Name = "pnBotones";
            this.pnBotones.Size = new System.Drawing.Size(891, 49);
            this.pnBotones.TabIndex = 60;
            // 
            // lblTarifaNueva
            // 
            this.lblTarifaNueva.AutoSize = true;
            this.lblTarifaNueva.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTarifaNueva.ForeColor = System.Drawing.Color.Black;
            this.lblTarifaNueva.Location = new System.Drawing.Point(10, 15);
            this.lblTarifaNueva.Name = "lblTarifaNueva";
            this.lblTarifaNueva.Size = new System.Drawing.Size(50, 21);
            this.lblTarifaNueva.TabIndex = 55;
            this.lblTarifaNueva.Text = "Tarifa:";
            // 
            // lblTarifaNuevaDato
            // 
            this.lblTarifaNuevaDato.AutoSize = true;
            this.lblTarifaNuevaDato.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTarifaNuevaDato.ForeColor = System.Drawing.Color.Black;
            this.lblTarifaNuevaDato.Location = new System.Drawing.Point(66, 15);
            this.lblTarifaNuevaDato.Name = "lblTarifaNuevaDato";
            this.lblTarifaNuevaDato.Size = new System.Drawing.Size(98, 21);
            this.lblTarifaNuevaDato.TabIndex = 56;
            this.lblTarifaNuevaDato.Text = "Nueva tarifa:";
            // 
            // splContenedor
            // 
            this.splContenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splContenedor.Location = new System.Drawing.Point(0, 124);
            this.splContenedor.Name = "splContenedor";
            // 
            // splContenedor.Panel1
            // 
            this.splContenedor.Panel1.Controls.Add(this.dgvZonasCategorias);
            this.splContenedor.Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel1_Paint);
            // 
            // splContenedor.Panel2
            // 
            this.splContenedor.Panel2.Controls.Add(this.dgvServicios);
            this.splContenedor.Panel2.Controls.Add(this.pnlReferencias);
            this.splContenedor.Size = new System.Drawing.Size(891, 296);
            this.splContenedor.SplitterDistance = 297;
            this.splContenedor.SplitterWidth = 9;
            this.splContenedor.TabIndex = 61;
            // 
            // pnlReferencias
            // 
            this.pnlReferencias.Controls.Add(this.lblServicio);
            this.pnlReferencias.Controls.Add(this.lblTipoSer);
            this.pnlReferencias.Controls.Add(this.label1);
            this.pnlReferencias.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlReferencias.Location = new System.Drawing.Point(0, 257);
            this.pnlReferencias.Name = "pnlReferencias";
            this.pnlReferencias.Size = new System.Drawing.Size(585, 39);
            this.pnlReferencias.TabIndex = 36;
            // 
            // lblServicio
            // 
            this.lblServicio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblServicio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lblServicio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblServicio.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblServicio.ForeColor = System.Drawing.Color.Black;
            this.lblServicio.Location = new System.Drawing.Point(465, 6);
            this.lblServicio.Name = "lblServicio";
            this.lblServicio.Size = new System.Drawing.Size(111, 27);
            this.lblServicio.TabIndex = 59;
            this.lblServicio.Text = "Servicio";
            this.lblServicio.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTipoSer
            // 
            this.lblTipoSer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTipoSer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.lblTipoSer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTipoSer.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipoSer.ForeColor = System.Drawing.Color.White;
            this.lblTipoSer.Location = new System.Drawing.Point(327, 6);
            this.lblTipoSer.Name = "lblTipoSer";
            this.lblTipoSer.Size = new System.Drawing.Size(132, 27);
            this.lblTipoSer.TabIndex = 58;
            this.lblTipoSer.Text = "Tipo de servicio";
            this.lblTipoSer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(228, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 21);
            this.label1.TabIndex = 57;
            this.label1.Text = "Referencias:";
            // 
            // dgvZonasCategorias
            // 
            this.dgvZonasCategorias.AllowUserToAddRows = false;
            this.dgvZonasCategorias.AllowUserToDeleteRows = false;
            this.dgvZonasCategorias.AllowUserToOrderColumns = true;
            this.dgvZonasCategorias.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvZonasCategorias.BackgroundColor = System.Drawing.Color.White;
            this.dgvZonasCategorias.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvZonasCategorias.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvZonasCategorias.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvZonasCategorias.ColumnHeadersHeight = 40;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvZonasCategorias.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvZonasCategorias.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvZonasCategorias.EnableHeadersVisualStyles = false;
            this.dgvZonasCategorias.GridColor = System.Drawing.Color.WhiteSmoke;
            this.dgvZonasCategorias.Location = new System.Drawing.Point(0, 0);
            this.dgvZonasCategorias.MultiSelect = false;
            this.dgvZonasCategorias.Name = "dgvZonasCategorias";
            this.dgvZonasCategorias.ReadOnly = true;
            this.dgvZonasCategorias.RowHeadersVisible = false;
            this.dgvZonasCategorias.RowHeadersWidth = 50;
            this.dgvZonasCategorias.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvZonasCategorias.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvZonasCategorias.Size = new System.Drawing.Size(297, 296);
            this.dgvZonasCategorias.TabIndex = 34;
            this.dgvZonasCategorias.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvZonasCategorias_CellClick);
            this.dgvZonasCategorias.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvZonasCategorias_CellEnter);
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
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvServicios.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvServicios.ColumnHeadersHeight = 40;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvServicios.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvServicios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvServicios.EnableHeadersVisualStyles = false;
            this.dgvServicios.GridColor = System.Drawing.Color.WhiteSmoke;
            this.dgvServicios.Location = new System.Drawing.Point(0, 0);
            this.dgvServicios.MultiSelect = false;
            this.dgvServicios.Name = "dgvServicios";
            this.dgvServicios.ReadOnly = true;
            this.dgvServicios.RowHeadersVisible = false;
            this.dgvServicios.RowHeadersWidth = 50;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White;
            this.dgvServicios.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvServicios.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvServicios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvServicios.Size = new System.Drawing.Size(585, 257);
            this.dgvServicios.TabIndex = 35;
            this.dgvServicios.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvServicios_CellClick);
            this.dgvServicios.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvServicios_CellDoubleClick);
            this.dgvServicios.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvServicios_KeyDown);
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
            this.btnActualizar.Location = new System.Drawing.Point(728, 8);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(151, 35);
            this.btnActualizar.TabIndex = 54;
            this.btnActualizar.Text = "Actualizar tarifa";
            this.btnActualizar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnActualizar.UseVisualStyleBackColor = false;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click_1);
            // 
            // pgCircular
            // 
            this.pgCircular.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pgCircular.Location = new System.Drawing.Point(855, 2);
            this.pgCircular.Name = "pgCircular";
            this.pgCircular.Percentage = 0F;
            this.pgCircular.Rotation = CapaPresentacion.Controles.RotationType.CounterClockwise;
            this.pgCircular.Size = new System.Drawing.Size(24, 24);
            this.pgCircular.TabIndex = 0;
            // 
            // ABMTarifas_Editor_Serv
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(891, 450);
            this.Controls.Add(this.splContenedor);
            this.Controls.Add(this.pnBotones);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.pnFooter);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "ABMTarifas_Editor_Serv";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmTarifasListado";
            this.Load += new System.EventHandler(this.frmTarifasListado_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ABMTarifas_Editor_Serv_KeyDown);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgReturn)).EndInit();
            this.pnFooter.ResumeLayout(false);
            this.pnBotones.ResumeLayout(false);
            this.pnBotones.PerformLayout();
            this.splContenedor.Panel1.ResumeLayout(false);
            this.splContenedor.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splContenedor)).EndInit();
            this.splContenedor.ResumeLayout(false);
            this.pnlReferencias.ResumeLayout(false);
            this.pnlReferencias.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvZonasCategorias)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvServicios)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox imgReturn;
        private System.Windows.Forms.Label lblTituloHeader;
        private Controles.boton btnActualizar;
        private System.Windows.Forms.Panel pnFooter;
        private Controles.progress pgCircular;
        private System.Windows.Forms.Panel pnBotones;
        private System.Windows.Forms.SplitContainer splContenedor;
        private Controles.dgv dgvZonasCategorias;
        private Controles.dgv dgvServicios;
        private System.Windows.Forms.Label lblTarifaNueva;
        private System.Windows.Forms.Label lblTarifaNuevaDato;
        private System.Windows.Forms.Panel pnlReferencias;
        private System.Windows.Forms.Label lblServicio;
        private System.Windows.Forms.Label lblTipoSer;
        private System.Windows.Forms.Label label1;
    }
}