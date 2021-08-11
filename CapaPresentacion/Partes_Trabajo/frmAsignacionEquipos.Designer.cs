namespace CapaPresentacion.Partes_Trabajo
{
    partial class frmAsignacionEquipos
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.imgReturn = new System.Windows.Forms.PictureBox();
            this.lblTituloHeader = new System.Windows.Forms.Label();
            this.lblNParte = new System.Windows.Forms.Label();
            this.lblEquiposAsociados = new System.Windows.Forms.Label();
            this.pnFooter = new System.Windows.Forms.Panel();
            this.lblTotal = new System.Windows.Forms.Label();
            this.pgCircular = new CapaPresentacion.Controles.progress();
            this.lblSinTecnico = new System.Windows.Forms.Label();
            this.lblReferencias = new System.Windows.Forms.Label();
            this.lblAsignado = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblFaltaTarjeta = new System.Windows.Forms.Label();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.txtBuscar = new CapaPresentacion.textboxAdv();
            this.btnAsignarTarjeta = new CapaPresentacion.Controles.boton();
            this.dgvPartes = new CapaPresentacion.Controles.dgv(this.components);
            this.dgvServiciosParte = new CapaPresentacion.Controles.dgv(this.components);
            this.btnAsignarEquipo = new CapaPresentacion.Controles.boton();
            this.btnNuevoEquipo = new CapaPresentacion.Controles.boton();
            this.dgvEquiposAsociados = new CapaPresentacion.Controles.dgv(this.components);
            this.btnBuscar = new CapaPresentacion.Controles.boton();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgReturn)).BeginInit();
            this.pnFooter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPartes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvServiciosParte)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEquiposAsociados)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.panel1.Controls.Add(this.imgReturn);
            this.panel1.Controls.Add(this.lblTituloHeader);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1072, 75);
            this.panel1.TabIndex = 237;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
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
            this.lblTituloHeader.Text = "Asignación de equipos:";
            // 
            // lblNParte
            // 
            this.lblNParte.AutoSize = true;
            this.lblNParte.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNParte.ForeColor = System.Drawing.Color.Black;
            this.lblNParte.Location = new System.Drawing.Point(12, 89);
            this.lblNParte.Name = "lblNParte";
            this.lblNParte.Size = new System.Drawing.Size(92, 21);
            this.lblNParte.TabIndex = 245;
            this.lblNParte.Text = "N° de parte:";
            // 
            // lblEquiposAsociados
            // 
            this.lblEquiposAsociados.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblEquiposAsociados.AutoSize = true;
            this.lblEquiposAsociados.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEquiposAsociados.ForeColor = System.Drawing.Color.Black;
            this.lblEquiposAsociados.Location = new System.Drawing.Point(12, 329);
            this.lblEquiposAsociados.Name = "lblEquiposAsociados";
            this.lblEquiposAsociados.Size = new System.Drawing.Size(203, 21);
            this.lblEquiposAsociados.TabIndex = 251;
            this.lblEquiposAsociados.Text = "Servicios asociados al parte:";
            // 
            // pnFooter
            // 
            this.pnFooter.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnFooter.Controls.Add(this.lblTotal);
            this.pnFooter.Controls.Add(this.pgCircular);
            this.pnFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnFooter.Location = new System.Drawing.Point(0, 512);
            this.pnFooter.Name = "pnFooter";
            this.pnFooter.Size = new System.Drawing.Size(1072, 30);
            this.pnFooter.TabIndex = 289;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblTotal.ForeColor = System.Drawing.Color.SlateGray;
            this.lblTotal.Location = new System.Drawing.Point(12, 5);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(148, 21);
            this.lblTotal.TabIndex = 13;
            this.lblTotal.Text = "Total de Registros: 0";
            // 
            // pgCircular
            // 
            this.pgCircular.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pgCircular.Location = new System.Drawing.Point(1036, 2);
            this.pgCircular.Name = "pgCircular";
            this.pgCircular.Percentage = 0F;
            this.pgCircular.Rotation = CapaPresentacion.Controles.RotationType.CounterClockwise;
            this.pgCircular.Size = new System.Drawing.Size(24, 24);
            this.pgCircular.TabIndex = 0;
            // 
            // lblSinTecnico
            // 
            this.lblSinTecnico.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSinTecnico.BackColor = System.Drawing.Color.Yellow;
            this.lblSinTecnico.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblSinTecnico.Location = new System.Drawing.Point(776, 480);
            this.lblSinTecnico.Name = "lblSinTecnico";
            this.lblSinTecnico.Size = new System.Drawing.Size(139, 25);
            this.lblSinTecnico.TabIndex = 295;
            this.lblSinTecnico.Text = "Requiere equipo";
            this.lblSinTecnico.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblReferencias
            // 
            this.lblReferencias.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblReferencias.AutoSize = true;
            this.lblReferencias.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblReferencias.Location = new System.Drawing.Point(528, 482);
            this.lblReferencias.Name = "lblReferencias";
            this.lblReferencias.Size = new System.Drawing.Size(97, 21);
            this.lblReferencias.TabIndex = 294;
            this.lblReferencias.Text = "Referencias: ";
            // 
            // lblAsignado
            // 
            this.lblAsignado.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAsignado.BackColor = System.Drawing.Color.LightGreen;
            this.lblAsignado.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblAsignado.Location = new System.Drawing.Point(631, 480);
            this.lblAsignado.Name = "lblAsignado";
            this.lblAsignado.Size = new System.Drawing.Size(139, 25);
            this.lblAsignado.TabIndex = 293;
            this.lblAsignado.Text = "Asignado";
            this.lblAsignado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(374, 329);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(213, 21);
            this.label1.TabIndex = 301;
            this.label1.Text = "Equipos asociados al servicio:";
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackColor = System.Drawing.Color.Gainsboro;
            this.panel3.Location = new System.Drawing.Point(0, 124);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1077, 1);
            this.panel3.TabIndex = 304;
            // 
            // lblFaltaTarjeta
            // 
            this.lblFaltaTarjeta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFaltaTarjeta.BackColor = System.Drawing.Color.DarkOrange;
            this.lblFaltaTarjeta.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblFaltaTarjeta.Location = new System.Drawing.Point(921, 480);
            this.lblFaltaTarjeta.Name = "lblFaltaTarjeta";
            this.lblFaltaTarjeta.Size = new System.Drawing.Size(139, 25);
            this.lblFaltaTarjeta.TabIndex = 306;
            this.lblFaltaTarjeta.Text = "Requiere tarjeta";
            this.lblFaltaTarjeta.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblBuscar
            // 
            this.lblBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBuscar.AutoSize = true;
            this.lblBuscar.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblBuscar.ForeColor = System.Drawing.Color.Black;
            this.lblBuscar.Location = new System.Drawing.Point(678, 138);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Size = new System.Drawing.Size(119, 21);
            this.lblBuscar.TabIndex = 308;
            this.lblBuscar.Text = "Buscar en grilla:";
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
            this.txtBuscar.Location = new System.Drawing.Point(803, 130);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Numerico = false;
            this.txtBuscar.Size = new System.Drawing.Size(257, 29);
            this.txtBuscar.TabIndex = 307;
            this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);
            // 
            // btnAsignarTarjeta
            // 
            this.btnAsignarTarjeta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAsignarTarjeta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnAsignarTarjeta.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAsignarTarjeta.Enabled = false;
            this.btnAsignarTarjeta.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnAsignarTarjeta.FlatAppearance.BorderSize = 0;
            this.btnAsignarTarjeta.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnAsignarTarjeta.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnAsignarTarjeta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAsignarTarjeta.Font = new System.Drawing.Font("Segoe UI Light", 12F);
            this.btnAsignarTarjeta.ForeColor = System.Drawing.Color.White;
            this.btnAsignarTarjeta.Image = global::CapaPresentacion.Properties.Resources.Data_Add_32;
            this.btnAsignarTarjeta.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAsignarTarjeta.Location = new System.Drawing.Point(919, 312);
            this.btnAsignarTarjeta.Name = "btnAsignarTarjeta";
            this.btnAsignarTarjeta.Size = new System.Drawing.Size(141, 38);
            this.btnAsignarTarjeta.TabIndex = 305;
            this.btnAsignarTarjeta.Text = "Asignar tarjeta";
            this.btnAsignarTarjeta.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAsignarTarjeta.UseVisualStyleBackColor = false;
            this.btnAsignarTarjeta.Click += new System.EventHandler(this.btnAsignarTarjeta_Click);
            // 
            // dgvPartes
            // 
            this.dgvPartes.AllowUserToAddRows = false;
            this.dgvPartes.AllowUserToDeleteRows = false;
            this.dgvPartes.AllowUserToOrderColumns = true;
            this.dgvPartes.AllowUserToResizeColumns = false;
            this.dgvPartes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPartes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPartes.BackgroundColor = System.Drawing.Color.White;
            this.dgvPartes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvPartes.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.LightSlateGray;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPartes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvPartes.ColumnHeadersHeight = 40;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPartes.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgvPartes.EnableHeadersVisualStyles = false;
            this.dgvPartes.GridColor = System.Drawing.Color.WhiteSmoke;
            this.dgvPartes.Location = new System.Drawing.Point(16, 165);
            this.dgvPartes.MultiSelect = false;
            this.dgvPartes.Name = "dgvPartes";
            this.dgvPartes.ReadOnly = true;
            this.dgvPartes.RowHeadersVisible = false;
            this.dgvPartes.RowHeadersWidth = 50;
            this.dgvPartes.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvPartes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPartes.Size = new System.Drawing.Size(1044, 141);
            this.dgvPartes.TabIndex = 303;
            this.dgvPartes.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPartes_CellEnter);
            this.dgvPartes.Sorted += new System.EventHandler(this.dgvPartes_Sorted);
            // 
            // dgvServiciosParte
            // 
            this.dgvServiciosParte.AllowUserToAddRows = false;
            this.dgvServiciosParte.AllowUserToDeleteRows = false;
            this.dgvServiciosParte.AllowUserToOrderColumns = true;
            this.dgvServiciosParte.AllowUserToResizeColumns = false;
            this.dgvServiciosParte.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dgvServiciosParte.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvServiciosParte.BackgroundColor = System.Drawing.Color.White;
            this.dgvServiciosParte.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvServiciosParte.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.LightSlateGray;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvServiciosParte.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvServiciosParte.ColumnHeadersHeight = 40;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvServiciosParte.DefaultCellStyle = dataGridViewCellStyle10;
            this.dgvServiciosParte.EnableHeadersVisualStyles = false;
            this.dgvServiciosParte.GridColor = System.Drawing.Color.WhiteSmoke;
            this.dgvServiciosParte.Location = new System.Drawing.Point(12, 356);
            this.dgvServiciosParte.MultiSelect = false;
            this.dgvServiciosParte.Name = "dgvServiciosParte";
            this.dgvServiciosParte.ReadOnly = true;
            this.dgvServiciosParte.RowHeadersVisible = false;
            this.dgvServiciosParte.RowHeadersWidth = 50;
            this.dgvServiciosParte.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvServiciosParte.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvServiciosParte.Size = new System.Drawing.Size(345, 130);
            this.dgvServiciosParte.TabIndex = 299;
            this.dgvServiciosParte.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvServiciosParte_CellEnter);
            // 
            // btnAsignarEquipo
            // 
            this.btnAsignarEquipo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAsignarEquipo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnAsignarEquipo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAsignarEquipo.Enabled = false;
            this.btnAsignarEquipo.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnAsignarEquipo.FlatAppearance.BorderSize = 0;
            this.btnAsignarEquipo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnAsignarEquipo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnAsignarEquipo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAsignarEquipo.Font = new System.Drawing.Font("Segoe UI Light", 12F);
            this.btnAsignarEquipo.ForeColor = System.Drawing.Color.White;
            this.btnAsignarEquipo.Image = global::CapaPresentacion.Properties.Resources.Data_Add_32;
            this.btnAsignarEquipo.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAsignarEquipo.Location = new System.Drawing.Point(625, 312);
            this.btnAsignarEquipo.Name = "btnAsignarEquipo";
            this.btnAsignarEquipo.Size = new System.Drawing.Size(141, 38);
            this.btnAsignarEquipo.TabIndex = 297;
            this.btnAsignarEquipo.Text = "Asignar equipo";
            this.btnAsignarEquipo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAsignarEquipo.UseVisualStyleBackColor = false;
            this.btnAsignarEquipo.Click += new System.EventHandler(this.btnAsignarEquipo_Click);
            // 
            // btnNuevoEquipo
            // 
            this.btnNuevoEquipo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNuevoEquipo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnNuevoEquipo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNuevoEquipo.Enabled = false;
            this.btnNuevoEquipo.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnNuevoEquipo.FlatAppearance.BorderSize = 0;
            this.btnNuevoEquipo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnNuevoEquipo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnNuevoEquipo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevoEquipo.Font = new System.Drawing.Font("Segoe UI Light", 12F);
            this.btnNuevoEquipo.ForeColor = System.Drawing.Color.White;
            this.btnNuevoEquipo.Image = global::CapaPresentacion.Properties.Resources.Data_Add_32;
            this.btnNuevoEquipo.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNuevoEquipo.Location = new System.Drawing.Point(772, 312);
            this.btnNuevoEquipo.Name = "btnNuevoEquipo";
            this.btnNuevoEquipo.Size = new System.Drawing.Size(141, 38);
            this.btnNuevoEquipo.TabIndex = 290;
            this.btnNuevoEquipo.Text = "Nuevo equipo";
            this.btnNuevoEquipo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNuevoEquipo.UseVisualStyleBackColor = false;
            this.btnNuevoEquipo.Click += new System.EventHandler(this.btnNuevoEquipo_Click);
            // 
            // dgvEquiposAsociados
            // 
            this.dgvEquiposAsociados.AllowUserToAddRows = false;
            this.dgvEquiposAsociados.AllowUserToDeleteRows = false;
            this.dgvEquiposAsociados.AllowUserToOrderColumns = true;
            this.dgvEquiposAsociados.AllowUserToResizeColumns = false;
            this.dgvEquiposAsociados.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvEquiposAsociados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvEquiposAsociados.BackgroundColor = System.Drawing.Color.White;
            this.dgvEquiposAsociados.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvEquiposAsociados.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.LightSlateGray;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvEquiposAsociados.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.dgvEquiposAsociados.ColumnHeadersHeight = 40;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvEquiposAsociados.DefaultCellStyle = dataGridViewCellStyle12;
            this.dgvEquiposAsociados.EnableHeadersVisualStyles = false;
            this.dgvEquiposAsociados.GridColor = System.Drawing.Color.WhiteSmoke;
            this.dgvEquiposAsociados.Location = new System.Drawing.Point(378, 356);
            this.dgvEquiposAsociados.MultiSelect = false;
            this.dgvEquiposAsociados.Name = "dgvEquiposAsociados";
            this.dgvEquiposAsociados.ReadOnly = true;
            this.dgvEquiposAsociados.RowHeadersVisible = false;
            this.dgvEquiposAsociados.RowHeadersWidth = 50;
            this.dgvEquiposAsociados.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvEquiposAsociados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEquiposAsociados.Size = new System.Drawing.Size(682, 121);
            this.dgvEquiposAsociados.TabIndex = 249;
            this.dgvEquiposAsociados.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEquiposAsociados_CellEnter);
            this.dgvEquiposAsociados.SelectionChanged += new System.EventHandler(this.dgvEquiposAsociados_SelectionChanged);
            this.dgvEquiposAsociados.Sorted += new System.EventHandler(this.dgvEquiposAsociados_Sorted);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnBuscar.FlatAppearance.BorderSize = 0;
            this.btnBuscar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnBuscar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnBuscar.ForeColor = System.Drawing.Color.White;
            this.btnBuscar.Image = global::CapaPresentacion.Properties.Resources.lupa;
            this.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBuscar.Location = new System.Drawing.Point(970, 81);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(90, 37);
            this.btnBuscar.TabIndex = 243;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // frmAsignacionEquipos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(250)))), ((int)(((byte)(251)))));
            this.ClientSize = new System.Drawing.Size(1072, 542);
            this.Controls.Add(this.lblBuscar);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.lblFaltaTarjeta);
            this.Controls.Add(this.btnAsignarTarjeta);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.dgvPartes);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvServiciosParte);
            this.Controls.Add(this.btnAsignarEquipo);
            this.Controls.Add(this.lblSinTecnico);
            this.Controls.Add(this.lblReferencias);
            this.Controls.Add(this.lblAsignado);
            this.Controls.Add(this.btnNuevoEquipo);
            this.Controls.Add(this.pnFooter);
            this.Controls.Add(this.lblEquiposAsociados);
            this.Controls.Add(this.dgvEquiposAsociados);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblNParte);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "frmAsignacionEquipos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmAsignacionEquipos";
            this.Load += new System.EventHandler(this.frmAsignacionEquipos_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmAsignacionEquipos_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgReturn)).EndInit();
            this.pnFooter.ResumeLayout(false);
            this.pnFooter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPartes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvServiciosParte)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEquiposAsociados)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox imgReturn;
        private System.Windows.Forms.Label lblTituloHeader;
        private Controles.boton btnBuscar;
        private System.Windows.Forms.Label lblNParte;
        private Controles.dgv dgvEquiposAsociados;
        private System.Windows.Forms.Label lblEquiposAsociados;
        private System.Windows.Forms.Panel pnFooter;
        private System.Windows.Forms.Label lblTotal;
        private Controles.progress pgCircular;
        private Controles.boton btnNuevoEquipo;
        private System.Windows.Forms.Label lblSinTecnico;
        private System.Windows.Forms.Label lblReferencias;
        private System.Windows.Forms.Label lblAsignado;
        private Controles.boton btnAsignarEquipo;
        private Controles.dgv dgvServiciosParte;
        private System.Windows.Forms.Label label1;
        private Controles.dgv dgvPartes;
        private System.Windows.Forms.Panel panel3;
        private Controles.boton btnAsignarTarjeta;
        private System.Windows.Forms.Label lblFaltaTarjeta;
        private textboxAdv txtBuscar;
        private System.Windows.Forms.Label lblBuscar;
    }
}