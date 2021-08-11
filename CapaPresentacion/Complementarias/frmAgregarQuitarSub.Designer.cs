namespace CapaPresentacion.Complementarias
{
    partial class frmAgregarQuitarSub
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
            this.pnTitulo = new System.Windows.Forms.Panel();
            this.LbTitulos = new System.Windows.Forms.Label();
            this.imgReturn = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlSeleccionar = new System.Windows.Forms.Panel();
            this.lblFechaDesdeDato = new System.Windows.Forms.Label();
            this.btnAgregarConfirmar = new CapaPresentacion.Controles.boton();
            this.btnFecha = new CapaPresentacion.Controles.boton();
            this.lblFechaMaximaDato = new System.Windows.Forms.Label();
            this.lblFechaMaxima = new System.Windows.Forms.Label();
            this.lblFechaHasta = new System.Windows.Forms.Label();
            this.dtpFechaHasta = new System.Windows.Forms.DateTimePicker();
            this.lblFechaDesde = new System.Windows.Forms.Label();
            this.pnlTitulo2 = new System.Windows.Forms.Panel();
            this.lblSubtitulo = new System.Windows.Forms.Label();
            this.imgReturn2 = new System.Windows.Forms.PictureBox();
            this.lblCarga = new System.Windows.Forms.Label();
            this.pgCircular = new CapaPresentacion.Controles.progress();
            this.dgvSubServiciosDisponibles = new CapaPresentacion.Controles.dgv(this.components);
            this.btnCancel = new CapaPresentacion.Controles.boton();
            this.btnConfirmar = new CapaPresentacion.Controles.boton();
            this.btnQuitar = new CapaPresentacion.Controles.boton();
            this.btnAgregar = new CapaPresentacion.Controles.boton();
            this.dgvSubServiciosActuales = new CapaPresentacion.Controles.dgv(this.components);
            this.pnTitulo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgReturn)).BeginInit();
            this.pnlSeleccionar.SuspendLayout();
            this.pnlTitulo2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgReturn2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSubServiciosDisponibles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSubServiciosActuales)).BeginInit();
            this.SuspendLayout();
            // 
            // pnTitulo
            // 
            this.pnTitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.pnTitulo.Controls.Add(this.LbTitulos);
            this.pnTitulo.Controls.Add(this.imgReturn);
            this.pnTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnTitulo.Location = new System.Drawing.Point(0, 0);
            this.pnTitulo.Name = "pnTitulo";
            this.pnTitulo.Size = new System.Drawing.Size(911, 83);
            this.pnTitulo.TabIndex = 200;
            // 
            // LbTitulos
            // 
            this.LbTitulos.AutoSize = true;
            this.LbTitulos.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LbTitulos.ForeColor = System.Drawing.Color.Transparent;
            this.LbTitulos.Location = new System.Drawing.Point(53, 31);
            this.LbTitulos.Name = "LbTitulos";
            this.LbTitulos.Size = new System.Drawing.Size(249, 25);
            this.LbTitulos.TabIndex = 172;
            this.LbTitulos.Text = "Agregar/Quitar Subservicios";
            // 
            // imgReturn
            // 
            this.imgReturn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.imgReturn.Image = global::CapaPresentacion.Properties.Resources.Left_Arrow_32;
            this.imgReturn.Location = new System.Drawing.Point(11, 26);
            this.imgReturn.Name = "imgReturn";
            this.imgReturn.Size = new System.Drawing.Size(32, 32);
            this.imgReturn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgReturn.TabIndex = 76;
            this.imgReturn.TabStop = false;
            this.imgReturn.Click += new System.EventHandler(this.imgReturn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(9, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(217, 25);
            this.label1.TabIndex = 173;
            this.label1.Text = "Subservicios disponibles";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(514, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(190, 25);
            this.label2.TabIndex = 202;
            this.label2.Text = "Subservicios actuales";
            // 
            // pnlSeleccionar
            // 
            this.pnlSeleccionar.Controls.Add(this.lblFechaDesdeDato);
            this.pnlSeleccionar.Controls.Add(this.btnAgregarConfirmar);
            this.pnlSeleccionar.Controls.Add(this.btnFecha);
            this.pnlSeleccionar.Controls.Add(this.lblFechaMaximaDato);
            this.pnlSeleccionar.Controls.Add(this.lblFechaMaxima);
            this.pnlSeleccionar.Controls.Add(this.lblFechaHasta);
            this.pnlSeleccionar.Controls.Add(this.dtpFechaHasta);
            this.pnlSeleccionar.Controls.Add(this.lblFechaDesde);
            this.pnlSeleccionar.Controls.Add(this.pnlTitulo2);
            this.pnlSeleccionar.Location = new System.Drawing.Point(164, 176);
            this.pnlSeleccionar.Name = "pnlSeleccionar";
            this.pnlSeleccionar.Size = new System.Drawing.Size(624, 188);
            this.pnlSeleccionar.TabIndex = 210;
            this.pnlSeleccionar.Visible = false;
            // 
            // lblFechaDesdeDato
            // 
            this.lblFechaDesdeDato.AutoSize = true;
            this.lblFechaDesdeDato.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblFechaDesdeDato.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblFechaDesdeDato.ForeColor = System.Drawing.Color.Black;
            this.lblFechaDesdeDato.Location = new System.Drawing.Point(193, 75);
            this.lblFechaDesdeDato.Name = "lblFechaDesdeDato";
            this.lblFechaDesdeDato.Size = new System.Drawing.Size(142, 21);
            this.lblFechaDesdeDato.TabIndex = 210;
            this.lblFechaDesdeDato.Text = "Fecha de comienzo";
            // 
            // btnAgregarConfirmar
            // 
            this.btnAgregarConfirmar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAgregarConfirmar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnAgregarConfirmar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregarConfirmar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnAgregarConfirmar.FlatAppearance.BorderSize = 0;
            this.btnAgregarConfirmar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnAgregarConfirmar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnAgregarConfirmar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarConfirmar.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarConfirmar.ForeColor = System.Drawing.Color.White;
            this.btnAgregarConfirmar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAgregarConfirmar.Location = new System.Drawing.Point(521, 144);
            this.btnAgregarConfirmar.Name = "btnAgregarConfirmar";
            this.btnAgregarConfirmar.Size = new System.Drawing.Size(94, 32);
            this.btnAgregarConfirmar.TabIndex = 209;
            this.btnAgregarConfirmar.Text = "Agregar";
            this.btnAgregarConfirmar.UseVisualStyleBackColor = false;
            this.btnAgregarConfirmar.Click += new System.EventHandler(this.btnAgregarConfirmar_Click);
            // 
            // btnFecha
            // 
            this.btnFecha.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnFecha.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFecha.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnFecha.FlatAppearance.BorderSize = 0;
            this.btnFecha.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnFecha.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnFecha.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFecha.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFecha.ForeColor = System.Drawing.Color.White;
            this.btnFecha.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFecha.Location = new System.Drawing.Point(476, 106);
            this.btnFecha.Name = "btnFecha";
            this.btnFecha.Size = new System.Drawing.Size(120, 28);
            this.btnFecha.TabIndex = 208;
            this.btnFecha.Text = "Fecha factura";
            this.btnFecha.UseVisualStyleBackColor = false;
            this.btnFecha.Click += new System.EventHandler(this.btnFecha_Click);
            // 
            // lblFechaMaximaDato
            // 
            this.lblFechaMaximaDato.AutoSize = true;
            this.lblFechaMaximaDato.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblFechaMaximaDato.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblFechaMaximaDato.ForeColor = System.Drawing.Color.Red;
            this.lblFechaMaximaDato.Location = new System.Drawing.Point(252, 147);
            this.lblFechaMaximaDato.Name = "lblFechaMaximaDato";
            this.lblFechaMaximaDato.Size = new System.Drawing.Size(56, 15);
            this.lblFechaMaximaDato.TabIndex = 207;
            this.lblFechaMaximaDato.Text = "Maximo: ";
            // 
            // lblFechaMaxima
            // 
            this.lblFechaMaxima.AutoSize = true;
            this.lblFechaMaxima.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblFechaMaxima.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblFechaMaxima.ForeColor = System.Drawing.Color.Red;
            this.lblFechaMaxima.Location = new System.Drawing.Point(190, 147);
            this.lblFechaMaxima.Name = "lblFechaMaxima";
            this.lblFechaMaxima.Size = new System.Drawing.Size(56, 15);
            this.lblFechaMaxima.TabIndex = 206;
            this.lblFechaMaxima.Text = "Maximo: ";
            // 
            // lblFechaHasta
            // 
            this.lblFechaHasta.AutoSize = true;
            this.lblFechaHasta.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblFechaHasta.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblFechaHasta.ForeColor = System.Drawing.Color.Black;
            this.lblFechaHasta.Location = new System.Drawing.Point(29, 110);
            this.lblFechaHasta.Name = "lblFechaHasta";
            this.lblFechaHasta.Size = new System.Drawing.Size(158, 21);
            this.lblFechaHasta.TabIndex = 205;
            this.lblFechaHasta.Text = "Fecha de terminacion";
            // 
            // dtpFechaHasta
            // 
            this.dtpFechaHasta.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.dtpFechaHasta.Location = new System.Drawing.Point(193, 104);
            this.dtpFechaHasta.Name = "dtpFechaHasta";
            this.dtpFechaHasta.Size = new System.Drawing.Size(277, 29);
            this.dtpFechaHasta.TabIndex = 204;
            this.dtpFechaHasta.ValueChanged += new System.EventHandler(this.dtpFechaHasta_ValueChanged);
            // 
            // lblFechaDesde
            // 
            this.lblFechaDesde.AutoSize = true;
            this.lblFechaDesde.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblFechaDesde.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblFechaDesde.ForeColor = System.Drawing.Color.Black;
            this.lblFechaDesde.Location = new System.Drawing.Point(45, 75);
            this.lblFechaDesde.Name = "lblFechaDesde";
            this.lblFechaDesde.Size = new System.Drawing.Size(142, 21);
            this.lblFechaDesde.TabIndex = 203;
            this.lblFechaDesde.Text = "Fecha de comienzo";
            // 
            // pnlTitulo2
            // 
            this.pnlTitulo2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.pnlTitulo2.Controls.Add(this.lblSubtitulo);
            this.pnlTitulo2.Controls.Add(this.imgReturn2);
            this.pnlTitulo2.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTitulo2.Location = new System.Drawing.Point(0, 0);
            this.pnlTitulo2.Name = "pnlTitulo2";
            this.pnlTitulo2.Size = new System.Drawing.Size(624, 52);
            this.pnlTitulo2.TabIndex = 201;
            // 
            // lblSubtitulo
            // 
            this.lblSubtitulo.AutoSize = true;
            this.lblSubtitulo.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubtitulo.ForeColor = System.Drawing.Color.Transparent;
            this.lblSubtitulo.Location = new System.Drawing.Point(56, 16);
            this.lblSubtitulo.Name = "lblSubtitulo";
            this.lblSubtitulo.Size = new System.Drawing.Size(114, 25);
            this.lblSubtitulo.TabIndex = 172;
            this.lblSubtitulo.Text = "Seleccionar ";
            // 
            // imgReturn2
            // 
            this.imgReturn2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.imgReturn2.Image = global::CapaPresentacion.Properties.Resources.Left_Arrow_32;
            this.imgReturn2.Location = new System.Drawing.Point(14, 11);
            this.imgReturn2.Name = "imgReturn2";
            this.imgReturn2.Size = new System.Drawing.Size(32, 32);
            this.imgReturn2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgReturn2.TabIndex = 76;
            this.imgReturn2.TabStop = false;
            this.imgReturn2.Click += new System.EventHandler(this.imgReturn2_Click);
            // 
            // lblCarga
            // 
            this.lblCarga.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblCarga.AutoSize = true;
            this.lblCarga.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCarga.ForeColor = System.Drawing.Color.SlateGray;
            this.lblCarga.Location = new System.Drawing.Point(40, 466);
            this.lblCarga.Name = "lblCarga";
            this.lblCarga.Size = new System.Drawing.Size(186, 13);
            this.lblCarga.TabIndex = 212;
            this.lblCarga.Text = "Cargando subservicios disponibles";
            // 
            // pgCircular
            // 
            this.pgCircular.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pgCircular.Location = new System.Drawing.Point(10, 459);
            this.pgCircular.Name = "pgCircular";
            this.pgCircular.Percentage = 0F;
            this.pgCircular.Rotation = CapaPresentacion.Controles.RotationType.CounterClockwise;
            this.pgCircular.Size = new System.Drawing.Size(24, 24);
            this.pgCircular.TabIndex = 211;
            // 
            // dgvSubServiciosDisponibles
            // 
            this.dgvSubServiciosDisponibles.AllowUserToAddRows = false;
            this.dgvSubServiciosDisponibles.AllowUserToDeleteRows = false;
            this.dgvSubServiciosDisponibles.AllowUserToOrderColumns = true;
            this.dgvSubServiciosDisponibles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSubServiciosDisponibles.BackgroundColor = System.Drawing.Color.White;
            this.dgvSubServiciosDisponibles.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvSubServiciosDisponibles.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSlateGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSubServiciosDisponibles.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvSubServiciosDisponibles.ColumnHeadersHeight = 40;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSubServiciosDisponibles.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvSubServiciosDisponibles.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.dgvSubServiciosDisponibles.EnableHeadersVisualStyles = false;
            this.dgvSubServiciosDisponibles.GridColor = System.Drawing.Color.WhiteSmoke;
            this.dgvSubServiciosDisponibles.Location = new System.Drawing.Point(11, 121);
            this.dgvSubServiciosDisponibles.MultiSelect = false;
            this.dgvSubServiciosDisponibles.Name = "dgvSubServiciosDisponibles";
            this.dgvSubServiciosDisponibles.ReadOnly = true;
            this.dgvSubServiciosDisponibles.RowHeadersVisible = false;
            this.dgvSubServiciosDisponibles.RowHeadersWidth = 50;
            this.dgvSubServiciosDisponibles.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvSubServiciosDisponibles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSubServiciosDisponibles.Size = new System.Drawing.Size(390, 327);
            this.dgvSubServiciosDisponibles.TabIndex = 201;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Image = global::CapaPresentacion.Properties.Resources.Command_Redo_32;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.Location = new System.Drawing.Point(800, 454);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(105, 35);
            this.btnCancel.TabIndex = 209;
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.boton1_Click);
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConfirmar.BackColor = System.Drawing.Color.SteelBlue;
            this.btnConfirmar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConfirmar.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
            this.btnConfirmar.FlatAppearance.BorderSize = 0;
            this.btnConfirmar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SteelBlue;
            this.btnConfirmar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SteelBlue;
            this.btnConfirmar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirmar.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirmar.ForeColor = System.Drawing.Color.White;
            this.btnConfirmar.Image = global::CapaPresentacion.Properties.Resources.Save_32;
            this.btnConfirmar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnConfirmar.Location = new System.Drawing.Point(668, 454);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(120, 35);
            this.btnConfirmar.TabIndex = 208;
            this.btnConfirmar.Text = "Confirmar";
            this.btnConfirmar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConfirmar.UseVisualStyleBackColor = false;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // btnQuitar
            // 
            this.btnQuitar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnQuitar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnQuitar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnQuitar.FlatAppearance.BorderSize = 0;
            this.btnQuitar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnQuitar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnQuitar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuitar.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuitar.ForeColor = System.Drawing.Color.White;
            this.btnQuitar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnQuitar.Location = new System.Drawing.Point(407, 254);
            this.btnQuitar.Name = "btnQuitar";
            this.btnQuitar.Size = new System.Drawing.Size(106, 35);
            this.btnQuitar.TabIndex = 205;
            this.btnQuitar.Text = "Quitar";
            this.btnQuitar.UseVisualStyleBackColor = false;
            this.btnQuitar.Click += new System.EventHandler(this.btnQuitar_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnAgregar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnAgregar.FlatAppearance.BorderSize = 0;
            this.btnAgregar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnAgregar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregar.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregar.ForeColor = System.Drawing.Color.White;
            this.btnAgregar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAgregar.Location = new System.Drawing.Point(407, 212);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(106, 35);
            this.btnAgregar.TabIndex = 204;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = false;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // dgvSubServiciosActuales
            // 
            this.dgvSubServiciosActuales.AllowUserToAddRows = false;
            this.dgvSubServiciosActuales.AllowUserToDeleteRows = false;
            this.dgvSubServiciosActuales.AllowUserToOrderColumns = true;
            this.dgvSubServiciosActuales.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSubServiciosActuales.BackgroundColor = System.Drawing.Color.White;
            this.dgvSubServiciosActuales.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvSubServiciosActuales.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.LightSlateGray;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSubServiciosActuales.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvSubServiciosActuales.ColumnHeadersHeight = 40;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSubServiciosActuales.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvSubServiciosActuales.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.dgvSubServiciosActuales.EnableHeadersVisualStyles = false;
            this.dgvSubServiciosActuales.GridColor = System.Drawing.Color.WhiteSmoke;
            this.dgvSubServiciosActuales.Location = new System.Drawing.Point(519, 121);
            this.dgvSubServiciosActuales.MultiSelect = false;
            this.dgvSubServiciosActuales.Name = "dgvSubServiciosActuales";
            this.dgvSubServiciosActuales.ReadOnly = true;
            this.dgvSubServiciosActuales.RowHeadersVisible = false;
            this.dgvSubServiciosActuales.RowHeadersWidth = 50;
            this.dgvSubServiciosActuales.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvSubServiciosActuales.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSubServiciosActuales.Size = new System.Drawing.Size(380, 327);
            this.dgvSubServiciosActuales.TabIndex = 203;
            // 
            // frmAgregarQuitarSub
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(911, 501);
            this.Controls.Add(this.pnlSeleccionar);
            this.Controls.Add(this.lblCarga);
            this.Controls.Add(this.pgCircular);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.btnQuitar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pnTitulo);
            this.Controls.Add(this.dgvSubServiciosDisponibles);
            this.Controls.Add(this.dgvSubServiciosActuales);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "frmAgregarQuitarSub";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmAgregarQuitarSub";
            this.Load += new System.EventHandler(this.frmAgregarQuitarSub_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmAgregarQuitarSub_KeyDown);
            this.pnTitulo.ResumeLayout(false);
            this.pnTitulo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgReturn)).EndInit();
            this.pnlSeleccionar.ResumeLayout(false);
            this.pnlSeleccionar.PerformLayout();
            this.pnlTitulo2.ResumeLayout(false);
            this.pnlTitulo2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgReturn2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSubServiciosDisponibles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSubServiciosActuales)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnTitulo;
        private System.Windows.Forms.Label LbTitulos;
        private System.Windows.Forms.PictureBox imgReturn;
        private Controles.dgv dgvSubServiciosDisponibles;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private Controles.dgv dgvSubServiciosActuales;
        private Controles.boton btnAgregar;
        private Controles.boton btnQuitar;
        private Controles.boton btnConfirmar;
        private Controles.boton btnCancel;
        private System.Windows.Forms.Panel pnlSeleccionar;
        private System.Windows.Forms.Panel pnlTitulo2;
        private System.Windows.Forms.Label lblSubtitulo;
        private System.Windows.Forms.PictureBox imgReturn2;
        private System.Windows.Forms.Label lblFechaDesde;
        private System.Windows.Forms.Label lblFechaMaxima;
        private System.Windows.Forms.Label lblFechaHasta;
        private System.Windows.Forms.DateTimePicker dtpFechaHasta;
        private System.Windows.Forms.Label lblFechaMaximaDato;
        private Controles.boton btnFecha;
        private Controles.boton btnAgregarConfirmar;
        private System.Windows.Forms.Label lblFechaDesdeDato;
        private Controles.progress pgCircular;
        private System.Windows.Forms.Label lblCarga;
    }
}