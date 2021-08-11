namespace CapaPresentacion.Busquedas
{
    partial class frmBusquedaUsuarios
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
            this.chkDocumento = new System.Windows.Forms.RadioButton();
            this.chkDomicilio = new System.Windows.Forms.RadioButton();
            this.chkNombre = new System.Windows.Forms.RadioButton();
            this.chkUsuario = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTotal = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkGeneral = new System.Windows.Forms.RadioButton();
            this.lblBuscador = new System.Windows.Forms.Label();
            this.lblTituloHeader = new System.Windows.Forms.Label();
            this.imgReturn = new System.Windows.Forms.PictureBox();
            this.pnlTitulo = new System.Windows.Forms.Panel();
            this.lblAltura = new System.Windows.Forms.Label();
            this.lblCalle = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbProspecto = new System.Windows.Forms.RadioButton();
            this.rbAbonado = new System.Windows.Forms.RadioButton();
            this.rbCliente = new System.Windows.Forms.RadioButton();
            this.lblLocalidad = new System.Windows.Forms.Label();
            this.txtAltura = new CapaPresentacion.textboxAdv();
            this.txtCalle = new CapaPresentacion.textboxAdv();
            this.pgCircular = new CapaPresentacion.Controles.progress();
            this.btnConfirma = new CapaPresentacion.Controles.boton();
            this.dgvResultado = new CapaPresentacion.Controles.dgv(this.components);
            this.btnBuscar = new CapaPresentacion.Controles.boton();
            this.txtBuscar = new CapaPresentacion.textboxAdv();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgReturn)).BeginInit();
            this.pnlTitulo.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResultado)).BeginInit();
            this.SuspendLayout();
            // 
            // chkDocumento
            // 
            this.chkDocumento.AutoSize = true;
            this.chkDocumento.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.chkDocumento.ForeColor = System.Drawing.Color.Black;
            this.chkDocumento.Location = new System.Drawing.Point(107, 58);
            this.chkDocumento.Name = "chkDocumento";
            this.chkDocumento.Size = new System.Drawing.Size(113, 25);
            this.chkDocumento.TabIndex = 2;
            this.chkDocumento.Text = "Dni,Cuit,Cuil";
            this.chkDocumento.UseVisualStyleBackColor = true;
            // 
            // chkDomicilio
            // 
            this.chkDomicilio.AutoSize = true;
            this.chkDomicilio.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.chkDomicilio.ForeColor = System.Drawing.Color.Black;
            this.chkDomicilio.Location = new System.Drawing.Point(6, 58);
            this.chkDomicilio.Name = "chkDomicilio";
            this.chkDomicilio.Size = new System.Drawing.Size(94, 25);
            this.chkDomicilio.TabIndex = 3;
            this.chkDomicilio.Text = "Domicilio";
            this.chkDomicilio.UseVisualStyleBackColor = true;
            // 
            // chkNombre
            // 
            this.chkNombre.AutoSize = true;
            this.chkNombre.Checked = true;
            this.chkNombre.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.chkNombre.ForeColor = System.Drawing.Color.Black;
            this.chkNombre.Location = new System.Drawing.Point(107, 29);
            this.chkNombre.Name = "chkNombre";
            this.chkNombre.Size = new System.Drawing.Size(159, 25);
            this.chkNombre.TabIndex = 1;
            this.chkNombre.TabStop = true;
            this.chkNombre.Text = "Apellido y Nombre";
            this.chkNombre.UseVisualStyleBackColor = true;
            // 
            // chkUsuario
            // 
            this.chkUsuario.AutoSize = true;
            this.chkUsuario.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.chkUsuario.ForeColor = System.Drawing.Color.Black;
            this.chkUsuario.Location = new System.Drawing.Point(6, 29);
            this.chkUsuario.Name = "chkUsuario";
            this.chkUsuario.Size = new System.Drawing.Size(82, 25);
            this.chkUsuario.TabIndex = 0;
            this.chkUsuario.Text = "Código ";
            this.chkUsuario.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.Location = new System.Drawing.Point(1, 188);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1196, 1);
            this.panel1.TabIndex = 204;
            // 
            // lblTotal
            // 
            this.lblTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblTotal.ForeColor = System.Drawing.Color.SlateGray;
            this.lblTotal.Location = new System.Drawing.Point(8, 493);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(148, 21);
            this.lblTotal.TabIndex = 13;
            this.lblTotal.Text = "Total de Registros: 0";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.chkGeneral);
            this.groupBox1.Controls.Add(this.chkUsuario);
            this.groupBox1.Controls.Add(this.chkNombre);
            this.groupBox1.Controls.Add(this.chkDomicilio);
            this.groupBox1.Controls.Add(this.chkDocumento);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(615, 93);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(321, 89);
            this.groupBox1.TabIndex = 208;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tipo de Busqueda";
            // 
            // chkGeneral
            // 
            this.chkGeneral.AutoSize = true;
            this.chkGeneral.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.chkGeneral.ForeColor = System.Drawing.Color.Black;
            this.chkGeneral.Location = new System.Drawing.Point(226, 58);
            this.chkGeneral.Name = "chkGeneral";
            this.chkGeneral.Size = new System.Drawing.Size(82, 25);
            this.chkGeneral.TabIndex = 4;
            this.chkGeneral.Text = "General";
            this.chkGeneral.UseVisualStyleBackColor = true;
            // 
            // lblBuscador
            // 
            this.lblBuscador.AutoSize = true;
            this.lblBuscador.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBuscador.Location = new System.Drawing.Point(8, 125);
            this.lblBuscador.Name = "lblBuscador";
            this.lblBuscador.Size = new System.Drawing.Size(78, 21);
            this.lblBuscador.TabIndex = 209;
            this.lblBuscador.Text = "Busqueda";
            // 
            // lblTituloHeader
            // 
            this.lblTituloHeader.Font = new System.Drawing.Font("Segoe UI Light", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloHeader.ForeColor = System.Drawing.Color.White;
            this.lblTituloHeader.Location = new System.Drawing.Point(51, 30);
            this.lblTituloHeader.Name = "lblTituloHeader";
            this.lblTituloHeader.Size = new System.Drawing.Size(295, 23);
            this.lblTituloHeader.TabIndex = 205;
            this.lblTituloHeader.Text = "Búsqueda de usuarios";
            // 
            // imgReturn
            // 
            this.imgReturn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.imgReturn.Image = global::CapaPresentacion.Properties.Resources.Left_Arrow_32;
            this.imgReturn.Location = new System.Drawing.Point(13, 25);
            this.imgReturn.Name = "imgReturn";
            this.imgReturn.Size = new System.Drawing.Size(32, 32);
            this.imgReturn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgReturn.TabIndex = 206;
            this.imgReturn.TabStop = false;
            this.imgReturn.Click += new System.EventHandler(this.imgReturn_Click);
            // 
            // pnlTitulo
            // 
            this.pnlTitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.pnlTitulo.Controls.Add(this.imgReturn);
            this.pnlTitulo.Controls.Add(this.lblTituloHeader);
            this.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTitulo.Location = new System.Drawing.Point(0, 0);
            this.pnlTitulo.Name = "pnlTitulo";
            this.pnlTitulo.Size = new System.Drawing.Size(1193, 80);
            this.pnlTitulo.TabIndex = 1;
            // 
            // lblAltura
            // 
            this.lblAltura.AutoSize = true;
            this.lblAltura.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAltura.Location = new System.Drawing.Point(231, 217);
            this.lblAltura.Name = "lblAltura";
            this.lblAltura.Size = new System.Drawing.Size(52, 21);
            this.lblAltura.TabIndex = 218;
            this.lblAltura.Text = "Altura";
            this.lblAltura.Visible = false;
            // 
            // lblCalle
            // 
            this.lblCalle.AutoSize = true;
            this.lblCalle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCalle.Location = new System.Drawing.Point(24, 217);
            this.lblCalle.Name = "lblCalle";
            this.lblCalle.Size = new System.Drawing.Size(44, 21);
            this.lblCalle.TabIndex = 216;
            this.lblCalle.Text = "Calle";
            this.lblCalle.Visible = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.rbProspecto);
            this.groupBox2.Controls.Add(this.rbAbonado);
            this.groupBox2.Controls.Add(this.rbCliente);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(948, 93);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(236, 89);
            this.groupBox2.TabIndex = 209;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tipo de Usuario";
            // 
            // rbProspecto
            // 
            this.rbProspecto.AutoSize = true;
            this.rbProspecto.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.rbProspecto.ForeColor = System.Drawing.Color.Black;
            this.rbProspecto.Location = new System.Drawing.Point(134, 28);
            this.rbProspecto.Name = "rbProspecto";
            this.rbProspecto.Size = new System.Drawing.Size(97, 25);
            this.rbProspecto.TabIndex = 4;
            this.rbProspecto.Text = "Prospecto";
            this.rbProspecto.UseVisualStyleBackColor = true;
            this.rbProspecto.CheckedChanged += new System.EventHandler(this.rbProspecto_CheckedChanged);
            // 
            // rbAbonado
            // 
            this.rbAbonado.AutoSize = true;
            this.rbAbonado.Checked = true;
            this.rbAbonado.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.rbAbonado.ForeColor = System.Drawing.Color.Black;
            this.rbAbonado.Location = new System.Drawing.Point(6, 29);
            this.rbAbonado.Name = "rbAbonado";
            this.rbAbonado.Size = new System.Drawing.Size(91, 25);
            this.rbAbonado.TabIndex = 0;
            this.rbAbonado.TabStop = true;
            this.rbAbonado.Text = "Abonado";
            this.rbAbonado.UseVisualStyleBackColor = true;
            this.rbAbonado.CheckedChanged += new System.EventHandler(this.rbAbonado_CheckedChanged);
            // 
            // rbCliente
            // 
            this.rbCliente.AutoSize = true;
            this.rbCliente.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.rbCliente.ForeColor = System.Drawing.Color.Black;
            this.rbCliente.Location = new System.Drawing.Point(6, 58);
            this.rbCliente.Name = "rbCliente";
            this.rbCliente.Size = new System.Drawing.Size(76, 25);
            this.rbCliente.TabIndex = 3;
            this.rbCliente.Text = "Cliente";
            this.rbCliente.UseVisualStyleBackColor = true;
            this.rbCliente.CheckedChanged += new System.EventHandler(this.rbCliente_CheckedChanged);
            // 
            // lblLocalidad
            // 
            this.lblLocalidad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLocalidad.AutoSize = true;
            this.lblLocalidad.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLocalidad.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.lblLocalidad.Location = new System.Drawing.Point(486, 493);
            this.lblLocalidad.Name = "lblLocalidad";
            this.lblLocalidad.Size = new System.Drawing.Size(0, 21);
            this.lblLocalidad.TabIndex = 210;
            // 
            // txtAltura
            // 
            this.txtAltura.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAltura.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtAltura.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAltura.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAltura.FocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.txtAltura.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtAltura.ForeColor = System.Drawing.Color.Black;
            this.txtAltura.Location = new System.Drawing.Point(286, 213);
            this.txtAltura.Name = "txtAltura";
            this.txtAltura.Numerico = true;
            this.txtAltura.Size = new System.Drawing.Size(181, 29);
            this.txtAltura.TabIndex = 219;
            this.txtAltura.Visible = false;
            this.txtAltura.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAltura_KeyDown);
            // 
            // txtCalle
            // 
            this.txtCalle.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtCalle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCalle.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCalle.FocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.txtCalle.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtCalle.ForeColor = System.Drawing.Color.Black;
            this.txtCalle.Location = new System.Drawing.Point(74, 213);
            this.txtCalle.Name = "txtCalle";
            this.txtCalle.Numerico = false;
            this.txtCalle.Size = new System.Drawing.Size(151, 29);
            this.txtCalle.TabIndex = 217;
            this.txtCalle.Visible = false;
            // 
            // pgCircular
            // 
            this.pgCircular.BackColor = System.Drawing.Color.White;
            this.pgCircular.Location = new System.Drawing.Point(480, 295);
            this.pgCircular.Name = "pgCircular";
            this.pgCircular.Percentage = 0F;
            this.pgCircular.Rotation = CapaPresentacion.Controles.RotationType.CounterClockwise;
            this.pgCircular.Size = new System.Drawing.Size(76, 76);
            this.pgCircular.TabIndex = 207;
            // 
            // btnConfirma
            // 
            this.btnConfirma.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConfirma.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnConfirma.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConfirma.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnConfirma.FlatAppearance.BorderSize = 0;
            this.btnConfirma.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnConfirma.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnConfirma.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirma.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnConfirma.ForeColor = System.Drawing.Color.White;
            this.btnConfirma.Image = global::CapaPresentacion.Properties.Resources.Next_32;
            this.btnConfirma.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnConfirma.Location = new System.Drawing.Point(1051, 485);
            this.btnConfirma.Name = "btnConfirma";
            this.btnConfirma.Size = new System.Drawing.Size(133, 37);
            this.btnConfirma.TabIndex = 8;
            this.btnConfirma.Text = "Confirmar";
            this.btnConfirma.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConfirma.UseVisualStyleBackColor = false;
            this.btnConfirma.Click += new System.EventHandler(this.btnConfirma_Click);
            // 
            // dgvResultado
            // 
            this.dgvResultado.AllowUserToAddRows = false;
            this.dgvResultado.AllowUserToDeleteRows = false;
            this.dgvResultado.AllowUserToOrderColumns = true;
            this.dgvResultado.AllowUserToResizeColumns = false;
            this.dgvResultado.AllowUserToResizeRows = false;
            this.dgvResultado.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvResultado.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvResultado.BackgroundColor = System.Drawing.Color.White;
            this.dgvResultado.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvResultado.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSlateGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvResultado.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvResultado.ColumnHeadersHeight = 40;
            this.dgvResultado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvResultado.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvResultado.EnableHeadersVisualStyles = false;
            this.dgvResultado.GridColor = System.Drawing.Color.WhiteSmoke;
            this.dgvResultado.Location = new System.Drawing.Point(12, 195);
            this.dgvResultado.MultiSelect = false;
            this.dgvResultado.Name = "dgvResultado";
            this.dgvResultado.ReadOnly = true;
            this.dgvResultado.RowHeadersVisible = false;
            this.dgvResultado.RowHeadersWidth = 50;
            this.dgvResultado.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvResultado.RowTemplate.Height = 35;
            this.dgvResultado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvResultado.Size = new System.Drawing.Size(1172, 280);
            this.dgvResultado.TabIndex = 1;
            this.dgvResultado.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvResultado_CellDoubleClick);
            this.dgvResultado.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvResultado_CellFormatting);
            this.dgvResultado.SelectionChanged += new System.EventHandler(this.dgvResultado_SelectionChanged);
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
            this.btnBuscar.Image = global::CapaPresentacion.Properties.Resources.Business_Man_Search_32;
            this.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBuscar.Location = new System.Drawing.Point(458, 117);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(98, 36);
            this.btnBuscar.TabIndex = 1;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txtBuscar
            // 
            this.txtBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBuscar.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtBuscar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBuscar.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBuscar.FocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.txtBuscar.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtBuscar.ForeColor = System.Drawing.Color.Black;
            this.txtBuscar.Location = new System.Drawing.Point(98, 121);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Numerico = false;
            this.txtBuscar.Size = new System.Drawing.Size(353, 29);
            this.txtBuscar.TabIndex = 0;
            this.txtBuscar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBuscar_KeyDown);
            // 
            // frmBusquedaUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(250)))), ((int)(((byte)(251)))));
            this.ClientSize = new System.Drawing.Size(1193, 529);
            this.Controls.Add(this.lblLocalidad);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.txtAltura);
            this.Controls.Add(this.lblBuscador);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblAltura);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.txtCalle);
            this.Controls.Add(this.lblCalle);
            this.Controls.Add(this.pgCircular);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnConfirma);
            this.Controls.Add(this.dgvResultado);
            this.Controls.Add(this.pnlTitulo);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.txtBuscar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "frmBusquedaUsuarios";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "6";
            this.Load += new System.EventHandler(this.frmBusquedaUsuarios_Load);
            this.Shown += new System.EventHandler(this.frmBusquedaUsuarios_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmBusquedaAbonados_KeyDown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgReturn)).EndInit();
            this.pnlTitulo.ResumeLayout(false);
            this.pnlTitulo.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResultado)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Controles.boton btnBuscar;
        private System.Windows.Forms.RadioButton chkDocumento;
        private System.Windows.Forms.RadioButton chkDomicilio;
        private System.Windows.Forms.RadioButton chkNombre;
        private System.Windows.Forms.RadioButton chkUsuario;
        private Controles.dgv dgvResultado;
        private Controles.boton btnConfirma;
        private System.Windows.Forms.Panel panel1;
        private textboxAdv txtBuscar;
        private Controles.progress pgCircular;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblBuscador;
        private System.Windows.Forms.Label lblTituloHeader;
        private System.Windows.Forms.PictureBox imgReturn;
        private System.Windows.Forms.Panel pnlTitulo;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rbProspecto;
        private System.Windows.Forms.RadioButton rbAbonado;
        private System.Windows.Forms.RadioButton rbCliente;
        private System.Windows.Forms.Label lblLocalidad;
        private textboxAdv txtAltura;
        private System.Windows.Forms.Label lblAltura;
        private textboxAdv txtCalle;
        private System.Windows.Forms.Label lblCalle;
        private System.Windows.Forms.RadioButton chkGeneral;
    }
}