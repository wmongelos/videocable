namespace CapaPresentacion.Cuenta_Corriente
{
    partial class FrmUsuariosCtaCteDetalles
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
            this.imgReturn = new System.Windows.Forms.PictureBox();
            this.pnLinea1 = new System.Windows.Forms.Panel();
            this.lbTitulo = new System.Windows.Forms.Label();
            this.lblocalidad = new System.Windows.Forms.Label();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.lbtexto1 = new System.Windows.Forms.Label();
            this.lbtexto2 = new System.Windows.Forms.Label();
            this.pnlDatos = new System.Windows.Forms.Panel();
            this.lblFechaHastaDato = new System.Windows.Forms.Label();
            this.lblFechaHasta = new System.Windows.Forms.Label();
            this.lblFechaDesdeDato = new System.Windows.Forms.Label();
            this.lblFechaDesde = new System.Windows.Forms.Label();
            this.splMain = new System.Windows.Forms.SplitContainer();
            this.dgvDetalles = new CapaPresentacion.Controles.dgv(this.components);
            this.pnlTotales = new System.Windows.Forms.Panel();
            this.btnDetalles = new CapaPresentacion.Controles.boton();
            this.lblTotalDato = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.dgvRelacion = new CapaPresentacion.Controles.dgv(this.components);
            this.pnlDatos2 = new System.Windows.Forms.Panel();
            this.pnlFoot = new System.Windows.Forms.Panel();
            this.pgCircular = new CapaPresentacion.Controles.progress();
            ((System.ComponentModel.ISupportInitialize)(this.imgReturn)).BeginInit();
            this.pnLinea1.SuspendLayout();
            this.pnlDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splMain)).BeginInit();
            this.splMain.Panel1.SuspendLayout();
            this.splMain.Panel2.SuspendLayout();
            this.splMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalles)).BeginInit();
            this.pnlTotales.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRelacion)).BeginInit();
            this.pnlDatos2.SuspendLayout();
            this.pnlFoot.SuspendLayout();
            this.SuspendLayout();
            // 
            // imgReturn
            // 
            this.imgReturn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.imgReturn.Image = global::CapaPresentacion.Properties.Resources.Left_Arrow_32;
            this.imgReturn.Location = new System.Drawing.Point(19, 17);
            this.imgReturn.Name = "imgReturn";
            this.imgReturn.Size = new System.Drawing.Size(32, 32);
            this.imgReturn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgReturn.TabIndex = 79;
            this.imgReturn.TabStop = false;
            this.imgReturn.Click += new System.EventHandler(this.ImgReturn_Click);
            // 
            // pnLinea1
            // 
            this.pnLinea1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.pnLinea1.Controls.Add(this.lbTitulo);
            this.pnLinea1.Controls.Add(this.imgReturn);
            this.pnLinea1.Controls.Add(this.lblocalidad);
            this.pnLinea1.Controls.Add(this.lblUsuario);
            this.pnLinea1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnLinea1.Location = new System.Drawing.Point(0, 0);
            this.pnLinea1.Name = "pnLinea1";
            this.pnLinea1.Size = new System.Drawing.Size(1024, 67);
            this.pnLinea1.TabIndex = 78;
            // 
            // lbTitulo
            // 
            this.lbTitulo.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitulo.ForeColor = System.Drawing.Color.White;
            this.lbTitulo.Location = new System.Drawing.Point(61, 23);
            this.lbTitulo.Name = "lbTitulo";
            this.lbTitulo.Size = new System.Drawing.Size(231, 23);
            this.lbTitulo.TabIndex = 84;
            this.lbTitulo.Text = "Consulta de comprobantes";
            this.lbTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblocalidad
            // 
            this.lblocalidad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblocalidad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblocalidad.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblocalidad.ForeColor = System.Drawing.Color.White;
            this.lblocalidad.Location = new System.Drawing.Point(646, 32);
            this.lblocalidad.Name = "lblocalidad";
            this.lblocalidad.Size = new System.Drawing.Size(369, 19);
            this.lblocalidad.TabIndex = 70;
            this.lblocalidad.Text = "-";
            this.lblocalidad.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblUsuario
            // 
            this.lblUsuario.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUsuario.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuario.ForeColor = System.Drawing.Color.White;
            this.lblUsuario.Location = new System.Drawing.Point(646, 8);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(369, 23);
            this.lblUsuario.TabIndex = 48;
            this.lblUsuario.Text = "-";
            this.lblUsuario.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbtexto1
            // 
            this.lbtexto1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbtexto1.AutoSize = true;
            this.lbtexto1.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbtexto1.ForeColor = System.Drawing.Color.Black;
            this.lbtexto1.Location = new System.Drawing.Point(942, 12);
            this.lbtexto1.Name = "lbtexto1";
            this.lbtexto1.Size = new System.Drawing.Size(70, 23);
            this.lbtexto1.TabIndex = 82;
            this.lbtexto1.Text = "Usuario";
            this.lbtexto1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbtexto2
            // 
            this.lbtexto2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbtexto2.AutoSize = true;
            this.lbtexto2.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbtexto2.ForeColor = System.Drawing.Color.Black;
            this.lbtexto2.Location = new System.Drawing.Point(942, 12);
            this.lbtexto2.Name = "lbtexto2";
            this.lbtexto2.Size = new System.Drawing.Size(70, 23);
            this.lbtexto2.TabIndex = 83;
            this.lbtexto2.Text = "Usuario";
            this.lbtexto2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pnlDatos
            // 
            this.pnlDatos.Controls.Add(this.lblFechaHastaDato);
            this.pnlDatos.Controls.Add(this.lblFechaHasta);
            this.pnlDatos.Controls.Add(this.lblFechaDesdeDato);
            this.pnlDatos.Controls.Add(this.lblFechaDesde);
            this.pnlDatos.Controls.Add(this.lbtexto1);
            this.pnlDatos.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlDatos.Location = new System.Drawing.Point(0, 67);
            this.pnlDatos.Name = "pnlDatos";
            this.pnlDatos.Size = new System.Drawing.Size(1024, 46);
            this.pnlDatos.TabIndex = 84;
            // 
            // lblFechaHastaDato
            // 
            this.lblFechaHastaDato.AutoSize = true;
            this.lblFechaHastaDato.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaHastaDato.ForeColor = System.Drawing.Color.Black;
            this.lblFechaHastaDato.Location = new System.Drawing.Point(346, 12);
            this.lblFechaHastaDato.Name = "lblFechaHastaDato";
            this.lblFechaHastaDato.Size = new System.Drawing.Size(110, 23);
            this.lblFechaHastaDato.TabIndex = 86;
            this.lblFechaHastaDato.Text = "Fecha desde:";
            this.lblFechaHastaDato.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblFechaHasta
            // 
            this.lblFechaHasta.AutoSize = true;
            this.lblFechaHasta.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaHasta.ForeColor = System.Drawing.Color.Black;
            this.lblFechaHasta.Location = new System.Drawing.Point(244, 12);
            this.lblFechaHasta.Name = "lblFechaHasta";
            this.lblFechaHasta.Size = new System.Drawing.Size(106, 23);
            this.lblFechaHasta.TabIndex = 85;
            this.lblFechaHasta.Text = "Fecha hasta:";
            this.lblFechaHasta.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblFechaDesdeDato
            // 
            this.lblFechaDesdeDato.AutoSize = true;
            this.lblFechaDesdeDato.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaDesdeDato.ForeColor = System.Drawing.Color.Black;
            this.lblFechaDesdeDato.Location = new System.Drawing.Point(119, 12);
            this.lblFechaDesdeDato.Name = "lblFechaDesdeDato";
            this.lblFechaDesdeDato.Size = new System.Drawing.Size(110, 23);
            this.lblFechaDesdeDato.TabIndex = 84;
            this.lblFechaDesdeDato.Text = "Fecha desde:";
            this.lblFechaDesdeDato.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblFechaDesde
            // 
            this.lblFechaDesde.AutoSize = true;
            this.lblFechaDesde.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaDesde.ForeColor = System.Drawing.Color.Black;
            this.lblFechaDesde.Location = new System.Drawing.Point(12, 12);
            this.lblFechaDesde.Name = "lblFechaDesde";
            this.lblFechaDesde.Size = new System.Drawing.Size(110, 23);
            this.lblFechaDesde.TabIndex = 83;
            this.lblFechaDesde.Text = "Fecha desde:";
            this.lblFechaDesde.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // splMain
            // 
            this.splMain.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.splMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splMain.Location = new System.Drawing.Point(0, 113);
            this.splMain.Name = "splMain";
            this.splMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splMain.Panel1
            // 
            this.splMain.Panel1.Controls.Add(this.dgvDetalles);
            this.splMain.Panel1.Controls.Add(this.pnlTotales);
            // 
            // splMain.Panel2
            // 
            this.splMain.Panel2.Controls.Add(this.dgvRelacion);
            this.splMain.Panel2.Controls.Add(this.pnlDatos2);
            this.splMain.Size = new System.Drawing.Size(1024, 655);
            this.splMain.SplitterDistance = 340;
            this.splMain.SplitterWidth = 10;
            this.splMain.TabIndex = 85;
            // 
            // dgvDetalles
            // 
            this.dgvDetalles.AllowUserToAddRows = false;
            this.dgvDetalles.AllowUserToDeleteRows = false;
            this.dgvDetalles.AllowUserToOrderColumns = true;
            this.dgvDetalles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDetalles.BackgroundColor = System.Drawing.Color.White;
            this.dgvDetalles.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvDetalles.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSlateGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDetalles.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDetalles.ColumnHeadersHeight = 40;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDetalles.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDetalles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDetalles.EnableHeadersVisualStyles = false;
            this.dgvDetalles.GridColor = System.Drawing.Color.WhiteSmoke;
            this.dgvDetalles.Location = new System.Drawing.Point(0, 0);
            this.dgvDetalles.MultiSelect = false;
            this.dgvDetalles.Name = "dgvDetalles";
            this.dgvDetalles.ReadOnly = true;
            this.dgvDetalles.RowHeadersVisible = false;
            this.dgvDetalles.RowHeadersWidth = 50;
            this.dgvDetalles.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI Light", 10F);
            this.dgvDetalles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetalles.Size = new System.Drawing.Size(1024, 293);
            this.dgvDetalles.TabIndex = 79;
            // 
            // pnlTotales
            // 
            this.pnlTotales.BackColor = System.Drawing.SystemColors.Control;
            this.pnlTotales.Controls.Add(this.btnDetalles);
            this.pnlTotales.Controls.Add(this.lblTotalDato);
            this.pnlTotales.Controls.Add(this.lblTotal);
            this.pnlTotales.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlTotales.Location = new System.Drawing.Point(0, 293);
            this.pnlTotales.Name = "pnlTotales";
            this.pnlTotales.Size = new System.Drawing.Size(1024, 47);
            this.pnlTotales.TabIndex = 80;
            // 
            // btnDetalles
            // 
            this.btnDetalles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDetalles.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnDetalles.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDetalles.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnDetalles.FlatAppearance.BorderSize = 0;
            this.btnDetalles.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnDetalles.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnDetalles.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDetalles.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDetalles.ForeColor = System.Drawing.Color.White;
            this.btnDetalles.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDetalles.Location = new System.Drawing.Point(738, 8);
            this.btnDetalles.Name = "btnDetalles";
            this.btnDetalles.Size = new System.Drawing.Size(129, 30);
            this.btnDetalles.TabIndex = 86;
            this.btnDetalles.Text = "Ver detalles";
            this.btnDetalles.UseVisualStyleBackColor = false;
            this.btnDetalles.Click += new System.EventHandler(this.BtnDetalles_Click);
            // 
            // lblTotalDato
            // 
            this.lblTotalDato.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalDato.AutoSize = true;
            this.lblTotalDato.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalDato.ForeColor = System.Drawing.Color.Black;
            this.lblTotalDato.Location = new System.Drawing.Point(952, 11);
            this.lblTotalDato.Name = "lblTotalDato";
            this.lblTotalDato.Size = new System.Drawing.Size(45, 23);
            this.lblTotalDato.TabIndex = 85;
            this.lblTotalDato.Text = "0,00";
            this.lblTotalDato.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTotal
            // 
            this.lblTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.ForeColor = System.Drawing.Color.Black;
            this.lblTotal.Location = new System.Drawing.Point(873, 11);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(51, 23);
            this.lblTotal.TabIndex = 84;
            this.lblTotal.Text = "Total:";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dgvRelacion
            // 
            this.dgvRelacion.AllowUserToAddRows = false;
            this.dgvRelacion.AllowUserToDeleteRows = false;
            this.dgvRelacion.AllowUserToOrderColumns = true;
            this.dgvRelacion.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRelacion.BackgroundColor = System.Drawing.Color.White;
            this.dgvRelacion.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvRelacion.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.LightSlateGray;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRelacion.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvRelacion.ColumnHeadersHeight = 40;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvRelacion.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvRelacion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRelacion.EnableHeadersVisualStyles = false;
            this.dgvRelacion.GridColor = System.Drawing.Color.WhiteSmoke;
            this.dgvRelacion.Location = new System.Drawing.Point(0, 45);
            this.dgvRelacion.MultiSelect = false;
            this.dgvRelacion.Name = "dgvRelacion";
            this.dgvRelacion.ReadOnly = true;
            this.dgvRelacion.RowHeadersVisible = false;
            this.dgvRelacion.RowHeadersWidth = 50;
            this.dgvRelacion.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvRelacion.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRelacion.Size = new System.Drawing.Size(1024, 260);
            this.dgvRelacion.TabIndex = 80;
            // 
            // pnlDatos2
            // 
            this.pnlDatos2.BackColor = System.Drawing.SystemColors.Control;
            this.pnlDatos2.Controls.Add(this.lbtexto2);
            this.pnlDatos2.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlDatos2.Location = new System.Drawing.Point(0, 0);
            this.pnlDatos2.Name = "pnlDatos2";
            this.pnlDatos2.Size = new System.Drawing.Size(1024, 45);
            this.pnlDatos2.TabIndex = 0;
            // 
            // pnlFoot
            // 
            this.pnlFoot.Controls.Add(this.pgCircular);
            this.pnlFoot.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFoot.Location = new System.Drawing.Point(0, 736);
            this.pnlFoot.Name = "pnlFoot";
            this.pnlFoot.Size = new System.Drawing.Size(1024, 32);
            this.pnlFoot.TabIndex = 86;
            // 
            // pgCircular
            // 
            this.pgCircular.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pgCircular.Location = new System.Drawing.Point(988, 5);
            this.pgCircular.Name = "pgCircular";
            this.pgCircular.Percentage = 0F;
            this.pgCircular.Rotation = CapaPresentacion.Controles.RotationType.CounterClockwise;
            this.pgCircular.Size = new System.Drawing.Size(24, 24);
            this.pgCircular.TabIndex = 81;
            // 
            // FrmUsuariosCtaCteDetalles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(1024, 768);
            this.Controls.Add(this.pnlFoot);
            this.Controls.Add(this.splMain);
            this.Controls.Add(this.pnlDatos);
            this.Controls.Add(this.pnLinea1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "FrmUsuariosCtaCteDetalles";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmUsuariosCtaCteDetalles_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmUsuariosCtaCteDetalles_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.imgReturn)).EndInit();
            this.pnLinea1.ResumeLayout(false);
            this.pnLinea1.PerformLayout();
            this.pnlDatos.ResumeLayout(false);
            this.pnlDatos.PerformLayout();
            this.splMain.Panel1.ResumeLayout(false);
            this.splMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splMain)).EndInit();
            this.splMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalles)).EndInit();
            this.pnlTotales.ResumeLayout(false);
            this.pnlTotales.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRelacion)).EndInit();
            this.pnlDatos2.ResumeLayout(false);
            this.pnlDatos2.PerformLayout();
            this.pnlFoot.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox imgReturn;
        private System.Windows.Forms.Panel pnLinea1;
        private System.Windows.Forms.Label lblocalidad;
        private System.Windows.Forms.Label lblUsuario;
        private Controles.dgv dgvDetalles;
        private Controles.dgv dgvRelacion;
        private Controles.progress pgCircular;
        private System.Windows.Forms.Label lbtexto1;
        private System.Windows.Forms.Label lbtexto2;
        private System.Windows.Forms.Label lbTitulo;
        private System.Windows.Forms.Panel pnlDatos;
        private System.Windows.Forms.SplitContainer splMain;
        private System.Windows.Forms.Panel pnlDatos2;
        private System.Windows.Forms.Panel pnlFoot;
        private System.Windows.Forms.Label lblFechaHastaDato;
        private System.Windows.Forms.Label lblFechaHasta;
        private System.Windows.Forms.Label lblFechaDesdeDato;
        private System.Windows.Forms.Label lblFechaDesde;
        private System.Windows.Forms.Panel pnlTotales;
        private System.Windows.Forms.Label lblTotalDato;
        private System.Windows.Forms.Label lblTotal;
        private Controles.boton btnDetalles;
    }
}