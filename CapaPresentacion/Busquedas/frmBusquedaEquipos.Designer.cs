namespace CapaPresentacion.Busquedas
{
    partial class frmBusquedaEquipos
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
            this.pnLinea1 = new System.Windows.Forms.Panel();
            this.pnFooter = new System.Windows.Forms.Panel();
            this.lblTotal = new System.Windows.Forms.Label();
            this.pgCircular = new CapaPresentacion.Controles.progress();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.imgReturn = new System.Windows.Forms.PictureBox();
            this.lblTituloHeader = new System.Windows.Forms.Label();
            this.lblEquipoSeleccionado = new System.Windows.Forms.Label();
            this.lblServicioSeleccionado = new System.Windows.Forms.Label();
            this.lblNParte = new System.Windows.Forms.Label();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.lblLocacion = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBuscar = new CapaPresentacion.textboxAdv();
            this.dgvEquipos = new CapaPresentacion.Controles.dgv(this.components);
            this.btnAsignar = new CapaPresentacion.Controles.boton();
            this.btnCancelar = new CapaPresentacion.Controles.boton();
            this.rbSerie = new System.Windows.Forms.RadioButton();
            this.rbMac = new System.Windows.Forms.RadioButton();
            this.rbTipo = new System.Windows.Forms.RadioButton();
            this.rbMarca = new System.Windows.Forms.RadioButton();
            this.rbModelo = new System.Windows.Forms.RadioButton();
            this.boton1 = new CapaPresentacion.Controles.boton();
            this.txtMac = new System.Windows.Forms.MaskedTextBox();
            this.cmsDerecho = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuCopiarMAC = new System.Windows.Forms.ToolStripMenuItem();
            this.copiarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnFooter.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgReturn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEquipos)).BeginInit();
            this.cmsDerecho.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnLinea1
            // 
            this.pnLinea1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnLinea1.BackColor = System.Drawing.Color.Gainsboro;
            this.pnLinea1.Location = new System.Drawing.Point(0, 125);
            this.pnLinea1.Name = "pnLinea1";
            this.pnLinea1.Size = new System.Drawing.Size(946, 1);
            this.pnLinea1.TabIndex = 16;
            // 
            // pnFooter
            // 
            this.pnFooter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnFooter.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnFooter.Controls.Add(this.lblTotal);
            this.pnFooter.Controls.Add(this.pgCircular);
            this.pnFooter.Location = new System.Drawing.Point(0, 488);
            this.pnFooter.Name = "pnFooter";
            this.pnFooter.Size = new System.Drawing.Size(938, 43);
            this.pnFooter.TabIndex = 14;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblTotal.ForeColor = System.Drawing.Color.SlateGray;
            this.lblTotal.Location = new System.Drawing.Point(7, 12);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(148, 21);
            this.lblTotal.TabIndex = 13;
            this.lblTotal.Text = "Total de Registros: 0";
            // 
            // pgCircular
            // 
            this.pgCircular.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pgCircular.Location = new System.Drawing.Point(892, 3);
            this.pgCircular.Name = "pgCircular";
            this.pgCircular.Percentage = 0F;
            this.pgCircular.Rotation = CapaPresentacion.Controles.RotationType.CounterClockwise;
            this.pgCircular.Size = new System.Drawing.Size(36, 36);
            this.pgCircular.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.Location = new System.Drawing.Point(0, 216);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(946, 1);
            this.panel1.TabIndex = 17;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.Gainsboro;
            this.panel2.Location = new System.Drawing.Point(0, 258);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(946, 1);
            this.panel2.TabIndex = 170;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.panel3.Controls.Add(this.imgReturn);
            this.panel3.Controls.Add(this.lblTituloHeader);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(938, 75);
            this.panel3.TabIndex = 247;
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
            this.lblTituloHeader.Size = new System.Drawing.Size(338, 27);
            this.lblTituloHeader.TabIndex = 31;
            this.lblTituloHeader.Text = "Selección de equipos";
            // 
            // lblEquipoSeleccionado
            // 
            this.lblEquipoSeleccionado.AutoSize = true;
            this.lblEquipoSeleccionado.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblEquipoSeleccionado.ForeColor = System.Drawing.Color.Black;
            this.lblEquipoSeleccionado.Location = new System.Drawing.Point(7, 229);
            this.lblEquipoSeleccionado.Name = "lblEquipoSeleccionado";
            this.lblEquipoSeleccionado.Size = new System.Drawing.Size(154, 21);
            this.lblEquipoSeleccionado.TabIndex = 250;
            this.lblEquipoSeleccionado.Text = "Equipo seleccionado:";
            // 
            // lblServicioSeleccionado
            // 
            this.lblServicioSeleccionado.AutoSize = true;
            this.lblServicioSeleccionado.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblServicioSeleccionado.ForeColor = System.Drawing.Color.Black;
            this.lblServicioSeleccionado.Location = new System.Drawing.Point(8, 192);
            this.lblServicioSeleccionado.Name = "lblServicioSeleccionado";
            this.lblServicioSeleccionado.Size = new System.Drawing.Size(161, 21);
            this.lblServicioSeleccionado.TabIndex = 251;
            this.lblServicioSeleccionado.Text = "Servicio seleccionado:";
            // 
            // lblNParte
            // 
            this.lblNParte.AutoSize = true;
            this.lblNParte.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblNParte.ForeColor = System.Drawing.Color.Black;
            this.lblNParte.Location = new System.Drawing.Point(8, 129);
            this.lblNParte.Name = "lblNParte";
            this.lblNParte.Size = new System.Drawing.Size(96, 21);
            this.lblNParte.TabIndex = 253;
            this.lblNParte.Text = "N° de parte: ";
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblUsuario.ForeColor = System.Drawing.Color.Black;
            this.lblUsuario.Location = new System.Drawing.Point(8, 150);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(67, 21);
            this.lblUsuario.TabIndex = 254;
            this.lblUsuario.Text = "Usuario:";
            // 
            // lblLocacion
            // 
            this.lblLocacion.AutoSize = true;
            this.lblLocacion.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblLocacion.ForeColor = System.Drawing.Color.Black;
            this.lblLocacion.Location = new System.Drawing.Point(8, 171);
            this.lblLocacion.Name = "lblLocacion";
            this.lblLocacion.Size = new System.Drawing.Size(74, 21);
            this.lblLocacion.TabIndex = 255;
            this.lblLocacion.Text = "Locación:";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(256, 229);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 21);
            this.label1.TabIndex = 256;
            this.label1.Text = "Buscar ";
            // 
            // txtBuscar
            // 
            this.txtBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBuscar.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtBuscar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBuscar.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBuscar.FocusColor = System.Drawing.Color.Empty;
            this.txtBuscar.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtBuscar.ForeColor = System.Drawing.Color.Black;
            this.txtBuscar.Location = new System.Drawing.Point(780, 223);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Numerico = false;
            this.txtBuscar.Size = new System.Drawing.Size(123, 29);
            this.txtBuscar.TabIndex = 19;
            this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);
            // 
            // dgvEquipos
            // 
            this.dgvEquipos.AllowUserToAddRows = false;
            this.dgvEquipos.AllowUserToDeleteRows = false;
            this.dgvEquipos.AllowUserToOrderColumns = true;
            this.dgvEquipos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvEquipos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvEquipos.BackgroundColor = System.Drawing.Color.White;
            this.dgvEquipos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvEquipos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSlateGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 12F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvEquipos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvEquipos.ColumnHeadersHeight = 40;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 12F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvEquipos.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvEquipos.EnableHeadersVisualStyles = false;
            this.dgvEquipos.GridColor = System.Drawing.Color.WhiteSmoke;
            this.dgvEquipos.Location = new System.Drawing.Point(12, 265);
            this.dgvEquipos.MultiSelect = false;
            this.dgvEquipos.Name = "dgvEquipos";
            this.dgvEquipos.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 12F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvEquipos.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvEquipos.RowHeadersVisible = false;
            this.dgvEquipos.RowHeadersWidth = 50;
            this.dgvEquipos.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvEquipos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEquipos.Size = new System.Drawing.Size(910, 205);
            this.dgvEquipos.TabIndex = 13;
            this.dgvEquipos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEquipos_CellContentClick);
            this.dgvEquipos.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEquipos_CellEnter);
            this.dgvEquipos.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvEquipos_CellMouseClick);
            this.dgvEquipos.DoubleClick += new System.EventHandler(this.dgvEquipos_DoubleClick);
            this.dgvEquipos.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvEquipos_KeyDown);
            // 
            // btnAsignar
            // 
            this.btnAsignar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAsignar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnAsignar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAsignar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnAsignar.FlatAppearance.BorderSize = 0;
            this.btnAsignar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnAsignar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnAsignar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAsignar.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnAsignar.ForeColor = System.Drawing.Color.White;
            this.btnAsignar.Image = global::CapaPresentacion.Properties.Resources.Data_Add_32;
            this.btnAsignar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAsignar.Location = new System.Drawing.Point(690, 81);
            this.btnAsignar.Name = "btnAsignar";
            this.btnAsignar.Size = new System.Drawing.Size(115, 38);
            this.btnAsignar.TabIndex = 248;
            this.btnAsignar.Text = "Asignar";
            this.btnAsignar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAsignar.UseVisualStyleBackColor = false;
            this.btnAsignar.Click += new System.EventHandler(this.btnAsignar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Image = global::CapaPresentacion.Properties.Resources.Data_Add_32;
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.Location = new System.Drawing.Point(811, 81);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(115, 38);
            this.btnCancelar.TabIndex = 99;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // rbSerie
            // 
            this.rbSerie.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbSerie.AutoSize = true;
            this.rbSerie.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbSerie.Location = new System.Drawing.Point(333, 227);
            this.rbSerie.Name = "rbSerie";
            this.rbSerie.Size = new System.Drawing.Size(63, 25);
            this.rbSerie.TabIndex = 257;
            this.rbSerie.TabStop = true;
            this.rbSerie.Text = "Serie";
            this.rbSerie.UseVisualStyleBackColor = true;
            this.rbSerie.CheckedChanged += new System.EventHandler(this.rbSerie_CheckedChanged);
            // 
            // rbMac
            // 
            this.rbMac.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbMac.AutoSize = true;
            this.rbMac.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbMac.Location = new System.Drawing.Point(402, 227);
            this.rbMac.Name = "rbMac";
            this.rbMac.Size = new System.Drawing.Size(71, 25);
            this.rbMac.TabIndex = 258;
            this.rbMac.TabStop = true;
            this.rbMac.Text = "M.A.C.";
            this.rbMac.UseVisualStyleBackColor = true;
            this.rbMac.CheckedChanged += new System.EventHandler(this.rbMac_CheckedChanged);
            // 
            // rbTipo
            // 
            this.rbTipo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbTipo.AutoSize = true;
            this.rbTipo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbTipo.Location = new System.Drawing.Point(479, 227);
            this.rbTipo.Name = "rbTipo";
            this.rbTipo.Size = new System.Drawing.Size(131, 25);
            this.rbTipo.TabIndex = 259;
            this.rbTipo.TabStop = true;
            this.rbTipo.Text = "Tipo de equipo";
            this.rbTipo.UseVisualStyleBackColor = true;
            // 
            // rbMarca
            // 
            this.rbMarca.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbMarca.AutoSize = true;
            this.rbMarca.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbMarca.Location = new System.Drawing.Point(616, 227);
            this.rbMarca.Name = "rbMarca";
            this.rbMarca.Size = new System.Drawing.Size(71, 25);
            this.rbMarca.TabIndex = 260;
            this.rbMarca.TabStop = true;
            this.rbMarca.Text = "Marca";
            this.rbMarca.UseVisualStyleBackColor = true;
            // 
            // rbModelo
            // 
            this.rbModelo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbModelo.AutoSize = true;
            this.rbModelo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbModelo.Location = new System.Drawing.Point(693, 227);
            this.rbModelo.Name = "rbModelo";
            this.rbModelo.Size = new System.Drawing.Size(81, 25);
            this.rbModelo.TabIndex = 261;
            this.rbModelo.TabStop = true;
            this.rbModelo.Text = "Modelo";
            this.rbModelo.UseVisualStyleBackColor = true;
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
            this.boton1.Image = global::CapaPresentacion.Properties.Resources.lupa;
            this.boton1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.boton1.Location = new System.Drawing.Point(909, 225);
            this.boton1.Name = "boton1";
            this.boton1.Size = new System.Drawing.Size(27, 26);
            this.boton1.TabIndex = 262;
            this.boton1.UseVisualStyleBackColor = false;
            this.boton1.Click += new System.EventHandler(this.boton1_Click);
            // 
            // txtMac
            // 
            this.txtMac.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMac.Location = new System.Drawing.Point(780, 181);
            this.txtMac.Mask = "AA:AA:AA:AA:AA:AA";
            this.txtMac.Name = "txtMac";
            this.txtMac.Size = new System.Drawing.Size(123, 29);
            this.txtMac.TabIndex = 263;
            this.txtMac.Visible = false;
            this.txtMac.TextChanged += new System.EventHandler(this.txtMac_TextChanged);
            // 
            // cmsDerecho
            // 
            this.cmsDerecho.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuCopiarMAC,
            this.copiarToolStripMenuItem});
            this.cmsDerecho.Name = "ctmDerecho";
            this.cmsDerecho.Size = new System.Drawing.Size(181, 70);
            this.cmsDerecho.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.cmsDerecho_ItemClicked);
            // 
            // mnuCopiarMAC
            // 
            this.mnuCopiarMAC.Name = "mnuCopiarMAC";
            this.mnuCopiarMAC.Size = new System.Drawing.Size(180, 22);
            this.mnuCopiarMAC.Text = "Copiar Num. MAC";
            this.mnuCopiarMAC.Click += new System.EventHandler(this.copiarMACToolStripMenuItem_Click);
            // 
            // copiarToolStripMenuItem
            // 
            this.copiarToolStripMenuItem.Name = "copiarToolStripMenuItem";
            this.copiarToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.copiarToolStripMenuItem.Text = "Copiar Num. SERIE";
            // 
            // frmBusquedaEquipos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(250)))), ((int)(((byte)(251)))));
            this.ClientSize = new System.Drawing.Size(938, 531);
            this.Controls.Add(this.txtMac);
            this.Controls.Add(this.boton1);
            this.Controls.Add(this.rbModelo);
            this.Controls.Add(this.rbMarca);
            this.Controls.Add(this.rbTipo);
            this.Controls.Add(this.rbMac);
            this.Controls.Add(this.rbSerie);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblLocacion);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.lblNParte);
            this.Controls.Add(this.lblServicioSeleccionado);
            this.Controls.Add(this.lblEquipoSeleccionado);
            this.Controls.Add(this.btnAsignar);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.pnLinea1);
            this.Controls.Add(this.pnFooter);
            this.Controls.Add(this.dgvEquipos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "frmBusquedaEquipos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmBusquedaEquipos";
            this.Load += new System.EventHandler(this.frmBusquedaEquipos_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmBusquedaEquipamiento_KeyDown);
            this.pnFooter.ResumeLayout(false);
            this.pnFooter.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgReturn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEquipos)).EndInit();
            this.cmsDerecho.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private textboxAdv txtBuscar;
        private System.Windows.Forms.Panel pnLinea1;
        private System.Windows.Forms.Panel pnFooter;
        private System.Windows.Forms.Label lblTotal;
        private Controles.progress pgCircular;
        private Controles.dgv dgvEquipos;
        private Controles.boton btnCancelar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox imgReturn;
        private System.Windows.Forms.Label lblTituloHeader;
        private Controles.boton btnAsignar;
        private System.Windows.Forms.Label lblEquipoSeleccionado;
        private System.Windows.Forms.Label lblServicioSeleccionado;
        private System.Windows.Forms.Label lblNParte;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Label lblLocacion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rbSerie;
        private System.Windows.Forms.RadioButton rbMac;
        private System.Windows.Forms.RadioButton rbTipo;
        private System.Windows.Forms.RadioButton rbMarca;
        private System.Windows.Forms.RadioButton rbModelo;
        private Controles.boton boton1;
        private System.Windows.Forms.MaskedTextBox txtMac;
        private System.Windows.Forms.ContextMenuStrip cmsDerecho;
        private System.Windows.Forms.ToolStripMenuItem mnuCopiarMAC;
        private System.Windows.Forms.ToolStripMenuItem copiarToolStripMenuItem;
    }
}