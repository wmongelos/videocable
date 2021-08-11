namespace CapaPresentacion.Abms
{
    partial class ABMEquipos_Tecnologias
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
            this.pnLine = new System.Windows.Forms.Panel();
            this.imgReturn = new System.Windows.Forms.PictureBox();
            this.lblTituloHeader = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTotal2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblTotal1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.chkEquipo = new System.Windows.Forms.RadioButton();
            this.chkServicio = new System.Windows.Forms.RadioButton();
            this.btnEliminar = new CapaPresentacion.Controles.boton();
            this.dgvTipoTecnologia = new CapaPresentacion.Controles.dgv(this.components);
            this.btnAgregar = new CapaPresentacion.Controles.boton();
            this.cboTecnologias = new CapaPresentacion.Controles.combo(this.components);
            this.btnActualizar = new CapaPresentacion.Controles.boton();
            this.dgvTipoEquipos = new CapaPresentacion.Controles.dgv(this.components);
            this.txtTipoEquipo = new CapaPresentacion.textboxAdv();
            this.pnLine.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgReturn)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTipoTecnologia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTipoEquipos)).BeginInit();
            this.SuspendLayout();
            // 
            // pnLine
            // 
            this.pnLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.pnLine.Controls.Add(this.imgReturn);
            this.pnLine.Controls.Add(this.lblTituloHeader);
            this.pnLine.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnLine.Location = new System.Drawing.Point(0, 0);
            this.pnLine.Name = "pnLine";
            this.pnLine.Size = new System.Drawing.Size(1009, 75);
            this.pnLine.TabIndex = 22;
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
            // 
            // lblTituloHeader
            // 
            this.lblTituloHeader.Font = new System.Drawing.Font("Segoe UI Light", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloHeader.ForeColor = System.Drawing.Color.White;
            this.lblTituloHeader.Location = new System.Drawing.Point(53, 27);
            this.lblTituloHeader.Name = "lblTituloHeader";
            this.lblTituloHeader.Size = new System.Drawing.Size(338, 27);
            this.lblTituloHeader.TabIndex = 31;
            this.lblTituloHeader.Text = "Tecnologias de Equipos";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.ForeColor = System.Drawing.Color.Black;
            this.lblNombre.Location = new System.Drawing.Point(12, 139);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(43, 21);
            this.lblNombre.TabIndex = 23;
            this.lblNombre.Text = "Tipo:";
            this.lblNombre.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.Location = new System.Drawing.Point(0, 124);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1000, 1);
            this.panel1.TabIndex = 26;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(8, 358);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 21);
            this.label1.TabIndex = 64;
            this.label1.Text = "Tipo de Tecnologias:";
            // 
            // lblTotal2
            // 
            this.lblTotal2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTotal2.AutoSize = true;
            this.lblTotal2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal2.ForeColor = System.Drawing.Color.Black;
            this.lblTotal2.Location = new System.Drawing.Point(12, 550);
            this.lblTotal2.Name = "lblTotal2";
            this.lblTotal2.Size = new System.Drawing.Size(128, 17);
            this.lblTotal2.TabIndex = 67;
            this.lblTotal2.Text = "Total de Registros: 0";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.Gainsboro;
            this.panel2.Location = new System.Drawing.Point(0, 348);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1000, 1);
            this.panel2.TabIndex = 68;
            // 
            // lblTotal1
            // 
            this.lblTotal1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTotal1.AutoSize = true;
            this.lblTotal1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal1.ForeColor = System.Drawing.Color.Black;
            this.lblTotal1.Location = new System.Drawing.Point(12, 319);
            this.lblTotal1.Name = "lblTotal1";
            this.lblTotal1.Size = new System.Drawing.Size(128, 17);
            this.lblTotal1.TabIndex = 70;
            this.lblTotal1.Text = "Total de Registros: 0";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.chkEquipo);
            this.panel3.Controls.Add(this.chkServicio);
            this.panel3.Location = new System.Drawing.Point(598, 138);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(166, 28);
            this.panel3.TabIndex = 71;
            // 
            // chkEquipo
            // 
            this.chkEquipo.AutoSize = true;
            this.chkEquipo.Location = new System.Drawing.Point(89, 5);
            this.chkEquipo.Name = "chkEquipo";
            this.chkEquipo.Size = new System.Drawing.Size(58, 17);
            this.chkEquipo.TabIndex = 1;
            this.chkEquipo.Text = "Equipo";
            this.chkEquipo.UseVisualStyleBackColor = true;
            // 
            // chkServicio
            // 
            this.chkServicio.AutoSize = true;
            this.chkServicio.Checked = true;
            this.chkServicio.Location = new System.Drawing.Point(20, 5);
            this.chkServicio.Name = "chkServicio";
            this.chkServicio.Size = new System.Drawing.Size(63, 17);
            this.chkServicio.TabIndex = 0;
            this.chkServicio.TabStop = true;
            this.chkServicio.Text = "Servicio";
            this.chkServicio.UseVisualStyleBackColor = true;
            this.chkServicio.CheckedChanged += new System.EventHandler(this.chkServicio_CheckedChanged);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEliminar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnEliminar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnEliminar.FlatAppearance.BorderSize = 0;
            this.btnEliminar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnEliminar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.ForeColor = System.Drawing.Color.White;
            this.btnEliminar.Image = global::CapaPresentacion.Properties.Resources.Data_Delete_32;
            this.btnEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEliminar.Location = new System.Drawing.Point(554, 355);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(35, 30);
            this.btnEliminar.TabIndex = 69;
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // dgvTipoTecnologia
            // 
            this.dgvTipoTecnologia.AllowUserToAddRows = false;
            this.dgvTipoTecnologia.AllowUserToDeleteRows = false;
            this.dgvTipoTecnologia.AllowUserToOrderColumns = true;
            this.dgvTipoTecnologia.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTipoTecnologia.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTipoTecnologia.BackgroundColor = System.Drawing.Color.White;
            this.dgvTipoTecnologia.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvTipoTecnologia.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTipoTecnologia.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvTipoTecnologia.ColumnHeadersHeight = 40;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTipoTecnologia.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvTipoTecnologia.EnableHeadersVisualStyles = false;
            this.dgvTipoTecnologia.GridColor = System.Drawing.Color.WhiteSmoke;
            this.dgvTipoTecnologia.Location = new System.Drawing.Point(12, 395);
            this.dgvTipoTecnologia.MultiSelect = false;
            this.dgvTipoTecnologia.Name = "dgvTipoTecnologia";
            this.dgvTipoTecnologia.ReadOnly = true;
            this.dgvTipoTecnologia.RowHeadersVisible = false;
            this.dgvTipoTecnologia.RowHeadersWidth = 50;
            this.dgvTipoTecnologia.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvTipoTecnologia.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTipoTecnologia.Size = new System.Drawing.Size(981, 142);
            this.dgvTipoTecnologia.TabIndex = 66;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAgregar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnAgregar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnAgregar.FlatAppearance.BorderSize = 0;
            this.btnAgregar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnAgregar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregar.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregar.ForeColor = System.Drawing.Color.White;
            this.btnAgregar.Image = global::CapaPresentacion.Properties.Resources.Download_32;
            this.btnAgregar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAgregar.Location = new System.Drawing.Point(513, 355);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(35, 30);
            this.btnAgregar.TabIndex = 65;
            this.btnAgregar.UseVisualStyleBackColor = false;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // cboTecnologias
            // 
            this.cboTecnologias.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cboTecnologias.BorderColor = System.Drawing.Color.Gainsboro;
            this.cboTecnologias.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTecnologias.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboTecnologias.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTecnologias.FormattingEnabled = true;
            this.cboTecnologias.Location = new System.Drawing.Point(162, 355);
            this.cboTecnologias.Name = "cboTecnologias";
            this.cboTecnologias.Size = new System.Drawing.Size(345, 29);
            this.cboTecnologias.TabIndex = 63;
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
            this.btnActualizar.Location = new System.Drawing.Point(883, 81);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(110, 35);
            this.btnActualizar.TabIndex = 27;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnActualizar.UseVisualStyleBackColor = false;
            // 
            // dgvTipoEquipos
            // 
            this.dgvTipoEquipos.AllowUserToAddRows = false;
            this.dgvTipoEquipos.AllowUserToDeleteRows = false;
            this.dgvTipoEquipos.AllowUserToOrderColumns = true;
            this.dgvTipoEquipos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTipoEquipos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTipoEquipos.BackgroundColor = System.Drawing.Color.White;
            this.dgvTipoEquipos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvTipoEquipos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTipoEquipos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvTipoEquipos.ColumnHeadersHeight = 40;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTipoEquipos.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvTipoEquipos.EnableHeadersVisualStyles = false;
            this.dgvTipoEquipos.GridColor = System.Drawing.Color.WhiteSmoke;
            this.dgvTipoEquipos.Location = new System.Drawing.Point(13, 172);
            this.dgvTipoEquipos.MultiSelect = false;
            this.dgvTipoEquipos.Name = "dgvTipoEquipos";
            this.dgvTipoEquipos.ReadOnly = true;
            this.dgvTipoEquipos.RowHeadersVisible = false;
            this.dgvTipoEquipos.RowHeadersWidth = 50;
            this.dgvTipoEquipos.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvTipoEquipos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTipoEquipos.Size = new System.Drawing.Size(985, 132);
            this.dgvTipoEquipos.TabIndex = 25;
            this.dgvTipoEquipos.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTipoEquipos_CellEnter);
            // 
            // txtTipoEquipo
            // 
            this.txtTipoEquipo.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtTipoEquipo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTipoEquipo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTipoEquipo.Enabled = false;
            this.txtTipoEquipo.FocusColor = System.Drawing.Color.Empty;
            this.txtTipoEquipo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTipoEquipo.ForeColor = System.Drawing.Color.DimGray;
            this.txtTipoEquipo.Location = new System.Drawing.Point(61, 137);
            this.txtTipoEquipo.Name = "txtTipoEquipo";
            this.txtTipoEquipo.Numerico = false;
            this.txtTipoEquipo.Size = new System.Drawing.Size(531, 29);
            this.txtTipoEquipo.TabIndex = 24;
            this.txtTipoEquipo.Tag = "\"\"";
            // 
            // ABMEquiposTecnologias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1009, 583);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.lblTotal1);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.lblTotal2);
            this.Controls.Add(this.dgvTipoTecnologia);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboTecnologias);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgvTipoEquipos);
            this.Controls.Add(this.txtTipoEquipo);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.pnLine);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ABMEquiposTecnologias";
            this.Text = "ABMEquiposTecnologias";
            this.Load += new System.EventHandler(this.ABMEquiposTecnologias_Load);
            this.pnLine.ResumeLayout(false);
            this.pnLine.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgReturn)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTipoTecnologia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTipoEquipos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnLine;
        private System.Windows.Forms.PictureBox imgReturn;
        private System.Windows.Forms.Label lblTituloHeader;
        private textboxAdv txtTipoEquipo;
        private System.Windows.Forms.Label lblNombre;
        private Controles.dgv dgvTipoEquipos;
        private System.Windows.Forms.Panel panel1;
        private Controles.boton btnActualizar;
        private Controles.boton btnAgregar;
        private System.Windows.Forms.Label label1;
        private Controles.combo cboTecnologias;
        private Controles.dgv dgvTipoTecnologia;
        private System.Windows.Forms.Label lblTotal2;
        private System.Windows.Forms.Panel panel2;
        private Controles.boton btnEliminar;
        private System.Windows.Forms.Label lblTotal1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.RadioButton chkEquipo;
        private System.Windows.Forms.RadioButton chkServicio;
    }
}