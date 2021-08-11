namespace CapaPresentacion.Abms
{
    partial class ABMPersonal
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
            this.pnLine = new System.Windows.Forms.Panel();
            this.pnFooter = new System.Windows.Forms.Panel();
            this.lblTotal = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.chkDoble_turno = new System.Windows.Forms.CheckBox();
            this.label20 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.imgReturn = new System.Windows.Forms.PictureBox();
            this.lblTituloHeader = new System.Windows.Forms.Label();
            this.chkUsuarioSistema = new System.Windows.Forms.CheckBox();
            this.lblUsuarioSistema = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lblAsignaHorarios = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.spHorario1HS_Desde = new System.Windows.Forms.NumericUpDown();
            this.spHorario1MN_Desde = new System.Windows.Forms.NumericUpDown();
            this.spHorario1MN_Hasta = new System.Windows.Forms.NumericUpDown();
            this.spHorario1HS_Hasta = new System.Windows.Forms.NumericUpDown();
            this.label24 = new System.Windows.Forms.Label();
            this.spHorario2MN_Hasta = new System.Windows.Forms.NumericUpDown();
            this.spHorario2HS_Hasta = new System.Windows.Forms.NumericUpDown();
            this.label25 = new System.Windows.Forms.Label();
            this.spHorario2MN_Desde = new System.Windows.Forms.NumericUpDown();
            this.spHorario2HS_Desde = new System.Windows.Forms.NumericUpDown();
            this.label26 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.spRango = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblMinutos = new System.Windows.Forms.Label();
            this.cboRoles = new CapaPresentacion.Controles.combo(this.components);
            this.txtNombre = new CapaPresentacion.textboxAdv();
            this.dgv = new CapaPresentacion.Controles.dgv(this.components);
            this.cboPuntosCobros = new CapaPresentacion.Controles.combo(this.components);
            this.cboAreas = new CapaPresentacion.Controles.combo(this.components);
            this.txtClave = new CapaPresentacion.textboxAdv();
            this.btnCancelar = new CapaPresentacion.Controles.boton();
            this.btnGuardar = new CapaPresentacion.Controles.boton();
            this.btnEliminar = new CapaPresentacion.Controles.boton();
            this.btnEditar = new CapaPresentacion.Controles.boton();
            this.btnNuevo = new CapaPresentacion.Controles.boton();
            this.btnActualizar = new CapaPresentacion.Controles.boton();
            this.pgCircular = new CapaPresentacion.Controles.progress();
            this.pnFooter.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgReturn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spHorario1HS_Desde)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spHorario1MN_Desde)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spHorario1MN_Hasta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spHorario1HS_Hasta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spHorario2MN_Hasta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spHorario2HS_Hasta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spHorario2MN_Desde)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spHorario2HS_Desde)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spRango)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // pnLine
            // 
            this.pnLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.pnLine.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnLine.Location = new System.Drawing.Point(0, 0);
            this.pnLine.Name = "pnLine";
            this.pnLine.Size = new System.Drawing.Size(1187, 1);
            this.pnLine.TabIndex = 0;
            // 
            // pnFooter
            // 
            this.pnFooter.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnFooter.Controls.Add(this.lblTotal);
            this.pnFooter.Controls.Add(this.pgCircular);
            this.pnFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnFooter.Location = new System.Drawing.Point(0, 488);
            this.pnFooter.Name = "pnFooter";
            this.pnFooter.Size = new System.Drawing.Size(1187, 30);
            this.pnFooter.TabIndex = 2;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.ForeColor = System.Drawing.Color.SlateGray;
            this.lblTotal.Location = new System.Drawing.Point(12, 8);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(128, 17);
            this.lblTotal.TabIndex = 13;
            this.lblTotal.Text = "Total de Registros: 0";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.Location = new System.Drawing.Point(3, 128);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1187, 1);
            this.panel1.TabIndex = 6;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.Gainsboro;
            this.panel2.Location = new System.Drawing.Point(3, 333);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1187, 1);
            this.panel2.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(90, 142);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 21);
            this.label1.TabIndex = 13;
            this.label1.Text = "Nombre:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(543, 179);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 21);
            this.label2.TabIndex = 14;
            this.label2.Text = "Clave:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(548, 139);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 21);
            this.label3.TabIndex = 16;
            this.label3.Text = "Area:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(840, 179);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 21);
            this.label4.TabIndex = 18;
            this.label4.Text = "P. Gestion:";
            // 
            // chkDoble_turno
            // 
            this.chkDoble_turno.AutoSize = true;
            this.chkDoble_turno.Enabled = false;
            this.chkDoble_turno.Location = new System.Drawing.Point(126, 252);
            this.chkDoble_turno.Name = "chkDoble_turno";
            this.chkDoble_turno.Size = new System.Drawing.Size(15, 14);
            this.chkDoble_turno.TabIndex = 18;
            this.chkDoble_turno.UseVisualStyleBackColor = true;
            this.chkDoble_turno.CheckedChanged += new System.EventHandler(this.chkDoble_turno_CheckedChanged);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.Color.Black;
            this.label20.Location = new System.Drawing.Point(28, 249);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(91, 21);
            this.label20.TabIndex = 33;
            this.label20.Text = "Doble turno";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.panel3.Controls.Add(this.imgReturn);
            this.panel3.Controls.Add(this.lblTituloHeader);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 1);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1187, 75);
            this.panel3.TabIndex = 32;
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
            this.lblTituloHeader.Text = "Personal";
            // 
            // chkUsuarioSistema
            // 
            this.chkUsuarioSistema.AutoSize = true;
            this.chkUsuarioSistema.Enabled = false;
            this.chkUsuarioSistema.Location = new System.Drawing.Point(167, 185);
            this.chkUsuarioSistema.Name = "chkUsuarioSistema";
            this.chkUsuarioSistema.Size = new System.Drawing.Size(38, 17);
            this.chkUsuarioSistema.TabIndex = 51;
            this.chkUsuarioSistema.Text = "14";
            this.chkUsuarioSistema.UseVisualStyleBackColor = true;
            this.chkUsuarioSistema.CheckStateChanged += new System.EventHandler(this.chkUsuarioSistema_CheckStateChanged);
            // 
            // lblUsuarioSistema
            // 
            this.lblUsuarioSistema.AutoSize = true;
            this.lblUsuarioSistema.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblUsuarioSistema.ForeColor = System.Drawing.Color.Black;
            this.lblUsuarioSistema.Location = new System.Drawing.Point(14, 179);
            this.lblUsuarioSistema.Name = "lblUsuarioSistema";
            this.lblUsuarioSistema.Size = new System.Drawing.Size(147, 21);
            this.lblUsuarioSistema.TabIndex = 50;
            this.lblUsuarioSistema.Text = "Usuario de Sistema:";
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.BackColor = System.Drawing.Color.Gainsboro;
            this.panel4.Location = new System.Drawing.Point(194, 229);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(993, 1);
            this.panel4.TabIndex = 7;
            // 
            // lblAsignaHorarios
            // 
            this.lblAsignaHorarios.AutoSize = true;
            this.lblAsignaHorarios.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAsignaHorarios.ForeColor = System.Drawing.Color.Red;
            this.lblAsignaHorarios.Location = new System.Drawing.Point(839, 142);
            this.lblAsignaHorarios.Name = "lblAsignaHorarios";
            this.lblAsignaHorarios.Size = new System.Drawing.Size(250, 17);
            this.lblAsignaHorarios.TabIndex = 52;
            this.lblAsignaHorarios.Text = "[ Debe ingresar los Horarios de Trabajo ]";
            this.lblAsignaHorarios.Visible = false;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.label21.Location = new System.Drawing.Point(48, 218);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(139, 21);
            this.label21.TabIndex = 53;
            this.label21.Text = "Horario de Trabajo";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.ForeColor = System.Drawing.Color.Black;
            this.label22.Location = new System.Drawing.Point(190, 251);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(74, 21);
            this.label22.TabIndex = 54;
            this.label22.Text = "Horario 1:";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.ForeColor = System.Drawing.Color.Black;
            this.label23.Location = new System.Drawing.Point(274, 251);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(37, 21);
            this.label23.TabIndex = 55;
            this.label23.Text = "HS.:";
            // 
            // spHorario1HS_Desde
            // 
            this.spHorario1HS_Desde.Enabled = false;
            this.spHorario1HS_Desde.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spHorario1HS_Desde.Location = new System.Drawing.Point(317, 247);
            this.spHorario1HS_Desde.Maximum = new decimal(new int[] {
            23,
            0,
            0,
            0});
            this.spHorario1HS_Desde.Name = "spHorario1HS_Desde";
            this.spHorario1HS_Desde.Size = new System.Drawing.Size(54, 29);
            this.spHorario1HS_Desde.TabIndex = 19;
            this.spHorario1HS_Desde.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // spHorario1MN_Desde
            // 
            this.spHorario1MN_Desde.Enabled = false;
            this.spHorario1MN_Desde.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spHorario1MN_Desde.Location = new System.Drawing.Point(377, 247);
            this.spHorario1MN_Desde.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.spHorario1MN_Desde.Name = "spHorario1MN_Desde";
            this.spHorario1MN_Desde.Size = new System.Drawing.Size(54, 29);
            this.spHorario1MN_Desde.TabIndex = 20;
            this.spHorario1MN_Desde.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // spHorario1MN_Hasta
            // 
            this.spHorario1MN_Hasta.Enabled = false;
            this.spHorario1MN_Hasta.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spHorario1MN_Hasta.Location = new System.Drawing.Point(546, 247);
            this.spHorario1MN_Hasta.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.spHorario1MN_Hasta.Name = "spHorario1MN_Hasta";
            this.spHorario1MN_Hasta.Size = new System.Drawing.Size(54, 29);
            this.spHorario1MN_Hasta.TabIndex = 22;
            this.spHorario1MN_Hasta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // spHorario1HS_Hasta
            // 
            this.spHorario1HS_Hasta.Enabled = false;
            this.spHorario1HS_Hasta.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spHorario1HS_Hasta.Location = new System.Drawing.Point(486, 247);
            this.spHorario1HS_Hasta.Maximum = new decimal(new int[] {
            23,
            0,
            0,
            0});
            this.spHorario1HS_Hasta.Name = "spHorario1HS_Hasta";
            this.spHorario1HS_Hasta.Size = new System.Drawing.Size(54, 29);
            this.spHorario1HS_Hasta.TabIndex = 21;
            this.spHorario1HS_Hasta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.ForeColor = System.Drawing.Color.Black;
            this.label24.Location = new System.Drawing.Point(443, 251);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(37, 21);
            this.label24.TabIndex = 58;
            this.label24.Text = "HS.:";
            // 
            // spHorario2MN_Hasta
            // 
            this.spHorario2MN_Hasta.Enabled = false;
            this.spHorario2MN_Hasta.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spHorario2MN_Hasta.Location = new System.Drawing.Point(546, 282);
            this.spHorario2MN_Hasta.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.spHorario2MN_Hasta.Name = "spHorario2MN_Hasta";
            this.spHorario2MN_Hasta.Size = new System.Drawing.Size(54, 29);
            this.spHorario2MN_Hasta.TabIndex = 26;
            this.spHorario2MN_Hasta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // spHorario2HS_Hasta
            // 
            this.spHorario2HS_Hasta.Enabled = false;
            this.spHorario2HS_Hasta.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spHorario2HS_Hasta.Location = new System.Drawing.Point(486, 282);
            this.spHorario2HS_Hasta.Maximum = new decimal(new int[] {
            23,
            0,
            0,
            0});
            this.spHorario2HS_Hasta.Name = "spHorario2HS_Hasta";
            this.spHorario2HS_Hasta.Size = new System.Drawing.Size(54, 29);
            this.spHorario2HS_Hasta.TabIndex = 25;
            this.spHorario2HS_Hasta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.ForeColor = System.Drawing.Color.Black;
            this.label25.Location = new System.Drawing.Point(443, 286);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(37, 21);
            this.label25.TabIndex = 65;
            this.label25.Text = "HS.:";
            // 
            // spHorario2MN_Desde
            // 
            this.spHorario2MN_Desde.Enabled = false;
            this.spHorario2MN_Desde.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spHorario2MN_Desde.Location = new System.Drawing.Point(377, 282);
            this.spHorario2MN_Desde.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.spHorario2MN_Desde.Name = "spHorario2MN_Desde";
            this.spHorario2MN_Desde.Size = new System.Drawing.Size(54, 29);
            this.spHorario2MN_Desde.TabIndex = 24;
            this.spHorario2MN_Desde.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // spHorario2HS_Desde
            // 
            this.spHorario2HS_Desde.Enabled = false;
            this.spHorario2HS_Desde.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spHorario2HS_Desde.Location = new System.Drawing.Point(317, 282);
            this.spHorario2HS_Desde.Maximum = new decimal(new int[] {
            23,
            0,
            0,
            0});
            this.spHorario2HS_Desde.Name = "spHorario2HS_Desde";
            this.spHorario2HS_Desde.Size = new System.Drawing.Size(54, 29);
            this.spHorario2HS_Desde.TabIndex = 23;
            this.spHorario2HS_Desde.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.ForeColor = System.Drawing.Color.Black;
            this.label26.Location = new System.Drawing.Point(274, 286);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(37, 21);
            this.label26.TabIndex = 62;
            this.label26.Text = "HS.:";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.ForeColor = System.Drawing.Color.Black;
            this.label27.Location = new System.Drawing.Point(190, 286);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(76, 21);
            this.label27.TabIndex = 61;
            this.label27.Text = "Horario 2:";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.ForeColor = System.Drawing.Color.Black;
            this.label28.Location = new System.Drawing.Point(806, 251);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(58, 21);
            this.label28.TabIndex = 67;
            this.label28.Text = "Rango:";
            // 
            // spRango
            // 
            this.spRango.Enabled = false;
            this.spRango.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spRango.Location = new System.Drawing.Point(870, 249);
            this.spRango.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.spRango.Name = "spRango";
            this.spRango.Size = new System.Drawing.Size(54, 29);
            this.spRango.TabIndex = 27;
            this.spRango.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(612, 252);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(150, 21);
            this.label5.TabIndex = 69;
            this.label5.Text = "00:00 HS. - 00:00 HS.";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(612, 286);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(150, 21);
            this.label6.TabIndex = 70;
            this.label6.Text = "00:00 HS. - 00:00 HS.";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(188, 179);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 21);
            this.label7.TabIndex = 72;
            this.label7.Text = "Privilegios";
            // 
            // lblMinutos
            // 
            this.lblMinutos.AutoSize = true;
            this.lblMinutos.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMinutos.ForeColor = System.Drawing.Color.Black;
            this.lblMinutos.Location = new System.Drawing.Point(930, 252);
            this.lblMinutos.Name = "lblMinutos";
            this.lblMinutos.Size = new System.Drawing.Size(64, 21);
            this.lblMinutos.TabIndex = 73;
            this.lblMinutos.Text = "Minutos";
            // 
            // cboRoles
            // 
            this.cboRoles.BorderColor = System.Drawing.Color.Gainsboro;
            this.cboRoles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRoles.Enabled = false;
            this.cboRoles.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboRoles.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboRoles.FormattingEnabled = true;
            this.cboRoles.Location = new System.Drawing.Point(270, 176);
            this.cboRoles.Name = "cboRoles";
            this.cboRoles.Size = new System.Drawing.Size(235, 29);
            this.cboRoles.TabIndex = 15;
            // 
            // txtNombre
            // 
            this.txtNombre.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtNombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNombre.Enabled = false;
            this.txtNombre.FocusColor = System.Drawing.Color.Empty;
            this.txtNombre.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.ForeColor = System.Drawing.Color.Black;
            this.txtNombre.Location = new System.Drawing.Point(167, 138);
            this.txtNombre.MaxLength = 50;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Numerico = false;
            this.txtNombre.Size = new System.Drawing.Size(338, 29);
            this.txtNombre.TabIndex = 12;
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AllowUserToOrderColumns = true;
            this.dgv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv.BackgroundColor = System.Drawing.Color.White;
            this.dgv.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv.ColumnHeadersHeight = 40;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgv.Enabled = false;
            this.dgv.EnableHeadersVisualStyles = false;
            this.dgv.GridColor = System.Drawing.Color.WhiteSmoke;
            this.dgv.Location = new System.Drawing.Point(15, 347);
            this.dgv.MultiSelect = false;
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersVisible = false;
            this.dgv.RowHeadersWidth = 50;
            this.dgv.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(1163, 135);
            this.dgv.TabIndex = 29;
            this.dgv.SelectionChanged += new System.EventHandler(this.dgv_SelectionChanged);
            this.dgv.Leave += new System.EventHandler(this.dgv_Leave);
            // 
            // cboPuntosCobros
            // 
            this.cboPuntosCobros.BorderColor = System.Drawing.Color.Gainsboro;
            this.cboPuntosCobros.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPuntosCobros.Enabled = false;
            this.cboPuntosCobros.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboPuntosCobros.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboPuntosCobros.FormattingEnabled = true;
            this.cboPuntosCobros.Location = new System.Drawing.Point(918, 176);
            this.cboPuntosCobros.Name = "cboPuntosCobros";
            this.cboPuntosCobros.Size = new System.Drawing.Size(235, 29);
            this.cboPuntosCobros.TabIndex = 17;
            // 
            // cboAreas
            // 
            this.cboAreas.BorderColor = System.Drawing.Color.Gainsboro;
            this.cboAreas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAreas.Enabled = false;
            this.cboAreas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboAreas.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboAreas.FormattingEnabled = true;
            this.cboAreas.Location = new System.Drawing.Point(599, 135);
            this.cboAreas.Name = "cboAreas";
            this.cboAreas.Size = new System.Drawing.Size(234, 29);
            this.cboAreas.TabIndex = 13;
            this.cboAreas.SelectedValueChanged += new System.EventHandler(this.cboAreas_SelectedValueChanged);
            // 
            // txtClave
            // 
            this.txtClave.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtClave.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtClave.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtClave.Enabled = false;
            this.txtClave.FocusColor = System.Drawing.Color.Empty;
            this.txtClave.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtClave.ForeColor = System.Drawing.Color.Black;
            this.txtClave.Location = new System.Drawing.Point(599, 176);
            this.txtClave.MaxLength = 50;
            this.txtClave.Name = "txtClave";
            this.txtClave.Numerico = false;
            this.txtClave.Size = new System.Drawing.Size(234, 29);
            this.txtClave.TabIndex = 16;
            this.txtClave.Tag = "\"\"";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.Enabled = false;
            this.btnCancelar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Image = global::CapaPresentacion.Properties.Resources.Command_Redo_32;
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.Location = new System.Drawing.Point(1074, 81);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(104, 35);
            this.btnCancelar.TabIndex = 4;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.Enabled = false;
            this.btnGuardar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnGuardar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Image = global::CapaPresentacion.Properties.Resources.Save_32;
            this.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGuardar.Location = new System.Drawing.Point(968, 81);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(100, 35);
            this.btnGuardar.TabIndex = 3;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEliminar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnEliminar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnEliminar.FlatAppearance.BorderSize = 0;
            this.btnEliminar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnEliminar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.ForeColor = System.Drawing.Color.White;
            this.btnEliminar.Image = global::CapaPresentacion.Properties.Resources.Data_Delete_32;
            this.btnEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEliminar.Location = new System.Drawing.Point(866, 81);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(95, 35);
            this.btnEliminar.TabIndex = 2;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnEditar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnEditar.FlatAppearance.BorderSize = 0;
            this.btnEditar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnEditar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnEditar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditar.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditar.ForeColor = System.Drawing.Color.White;
            this.btnEditar.Image = global::CapaPresentacion.Properties.Resources.Data_Edit_32__1_;
            this.btnEditar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEditar.Location = new System.Drawing.Point(773, 81);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(91, 35);
            this.btnEditar.TabIndex = 1;
            this.btnEditar.Text = "Editar";
            this.btnEditar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEditar.UseVisualStyleBackColor = false;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNuevo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnNuevo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNuevo.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnNuevo.FlatAppearance.BorderSize = 0;
            this.btnNuevo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnNuevo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevo.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevo.ForeColor = System.Drawing.Color.White;
            this.btnNuevo.Image = global::CapaPresentacion.Properties.Resources.Data_Add_32;
            this.btnNuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNuevo.Location = new System.Drawing.Point(680, 81);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(91, 35);
            this.btnNuevo.TabIndex = 0;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNuevo.UseVisualStyleBackColor = false;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
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
            this.btnActualizar.Location = new System.Drawing.Point(564, 81);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(107, 35);
            this.btnActualizar.TabIndex = 5;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnActualizar.UseVisualStyleBackColor = false;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // pgCircular
            // 
            this.pgCircular.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pgCircular.Location = new System.Drawing.Point(1151, 2);
            this.pgCircular.Name = "pgCircular";
            this.pgCircular.Percentage = 0F;
            this.pgCircular.Rotation = CapaPresentacion.Controles.RotationType.CounterClockwise;
            this.pgCircular.Size = new System.Drawing.Size(24, 24);
            this.pgCircular.TabIndex = 0;
            // 
            // ABMPersonal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(250)))), ((int)(((byte)(251)))));
            this.ClientSize = new System.Drawing.Size(1187, 518);
            this.ControlBox = false;
            this.Controls.Add(this.lblMinutos);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cboRoles);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.spRango);
            this.Controls.Add(this.label28);
            this.Controls.Add(this.spHorario2MN_Hasta);
            this.Controls.Add(this.spHorario2HS_Hasta);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.spHorario2MN_Desde);
            this.Controls.Add(this.spHorario2HS_Desde);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.label27);
            this.Controls.Add(this.spHorario1MN_Hasta);
            this.Controls.Add(this.spHorario1HS_Hasta);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.spHorario1MN_Desde);
            this.Controls.Add(this.spHorario1HS_Desde);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.lblAsignaHorarios);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.chkUsuarioSistema);
            this.Controls.Add(this.lblUsuarioSistema);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.cboPuntosCobros);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cboAreas);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtClave);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.chkDoble_turno);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.pnFooter);
            this.Controls.Add(this.pnLine);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "ABMPersonal";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "ABMPersonal";
            this.Load += new System.EventHandler(this.ABMPersonal_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ABMPersonal_KeyDown);
            this.pnFooter.ResumeLayout(false);
            this.pnFooter.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgReturn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spHorario1HS_Desde)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spHorario1MN_Desde)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spHorario1MN_Hasta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spHorario1HS_Hasta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spHorario2MN_Hasta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spHorario2HS_Hasta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spHorario2MN_Desde)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spHorario2HS_Desde)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spRango)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnLine;
        private System.Windows.Forms.Panel pnFooter;
        private Controles.progress pgCircular;
        private Controles.boton btnActualizar;
        private Controles.boton btnNuevo;
        private Controles.boton btnEliminar;
        private Controles.boton btnEditar;
        private Controles.boton btnGuardar;
        private System.Windows.Forms.Panel panel1;
        private Controles.boton btnCancelar;
        private textboxAdv txtNombre;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private textboxAdv txtClave;
        private System.Windows.Forms.Label label3;
        private Controles.combo cboAreas;
        private Controles.combo cboPuntosCobros;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox imgReturn;
        private System.Windows.Forms.Label lblTituloHeader;
        private System.Windows.Forms.CheckBox chkDoble_turno;
        private System.Windows.Forms.Label label20;
        private Controles.dgv dgv;
        private System.Windows.Forms.CheckBox chkUsuarioSistema;
        private System.Windows.Forms.Label lblUsuarioSistema;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label lblAsignaHorarios;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.NumericUpDown spHorario1HS_Desde;
        private System.Windows.Forms.NumericUpDown spHorario1MN_Desde;
        private System.Windows.Forms.NumericUpDown spHorario1MN_Hasta;
        private System.Windows.Forms.NumericUpDown spHorario1HS_Hasta;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.NumericUpDown spHorario2MN_Hasta;
        private System.Windows.Forms.NumericUpDown spHorario2HS_Hasta;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.NumericUpDown spHorario2MN_Desde;
        private System.Windows.Forms.NumericUpDown spHorario2HS_Desde;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.NumericUpDown spRango;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private Controles.combo cboRoles;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblMinutos;
    }
}