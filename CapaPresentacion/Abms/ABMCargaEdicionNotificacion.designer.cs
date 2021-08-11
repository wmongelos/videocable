namespace CapaPresentacion.Abms
{
    partial class ABMCargaEdicionNotificacion
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel4 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblTituloHeader = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblMensaje = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.lblPrioridad = new System.Windows.Forms.Label();
            this.dtpFechaLimite = new System.Windows.Forms.DateTimePicker();
            this.lblFechaLimite = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panelDestinatarios = new System.Windows.Forms.Panel();
            this.btnSeleccionarDestinatario = new CapaPresentacion.Controles.boton();
            this.dgvPosiblesDestinatarios = new CapaPresentacion.Controles.dgv(this.components);
            this.lblTipoAdjunto = new System.Windows.Forms.Label();
            this.boton1 = new CapaPresentacion.Controles.boton();
            this.cboPrioridad = new CapaPresentacion.Controles.combo(this.components);
            this.btnBuscarAdjunto = new CapaPresentacion.Controles.boton();
            this.dgvAdjuntos = new CapaPresentacion.Controles.dgv(this.components);
            this.txtMensaje = new CapaPresentacion.textboxAdv();
            this.btnAgregarDestinatario = new CapaPresentacion.Controles.boton();
            this.dgvDestinatarios = new CapaPresentacion.Controles.dgv(this.components);
            this.btnEnviar = new CapaPresentacion.Controles.boton();
            this.btnEliminar = new CapaPresentacion.Controles.boton();
            this.cboTipoAdjunto = new CapaPresentacion.Controles.combo(this.components);
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panelDestinatarios.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPosiblesDestinatarios)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAdjuntos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDestinatarios)).BeginInit();
            this.SuspendLayout();
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.panel4.Controls.Add(this.pictureBox1);
            this.panel4.Controls.Add(this.lblTituloHeader);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(959, 80);
            this.panel4.TabIndex = 348;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = global::CapaPresentacion.Properties.Resources.Left_Arrow_32;
            this.pictureBox1.Location = new System.Drawing.Point(15, 22);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 32;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // lblTituloHeader
            // 
            this.lblTituloHeader.Font = new System.Drawing.Font("Segoe UI Light", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloHeader.ForeColor = System.Drawing.Color.White;
            this.lblTituloHeader.Location = new System.Drawing.Point(53, 27);
            this.lblTituloHeader.Name = "lblTituloHeader";
            this.lblTituloHeader.Size = new System.Drawing.Size(338, 23);
            this.lblTituloHeader.TabIndex = 31;
            this.lblTituloHeader.Text = "Nueva notificación";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(367, 276);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 21);
            this.label4.TabIndex = 356;
            this.label4.Text = "Adjuntar:";
            // 
            // lblMensaje
            // 
            this.lblMensaje.AutoSize = true;
            this.lblMensaje.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMensaje.ForeColor = System.Drawing.Color.Black;
            this.lblMensaje.Location = new System.Drawing.Point(12, 140);
            this.lblMensaje.Name = "lblMensaje";
            this.lblMensaje.Size = new System.Drawing.Size(71, 21);
            this.lblMensaje.TabIndex = 354;
            this.lblMensaje.Text = "Mensaje:";
            // 
            // panel5
            // 
            this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel5.BackColor = System.Drawing.Color.Silver;
            this.panel5.Location = new System.Drawing.Point(0, 127);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(967, 1);
            this.panel5.TabIndex = 349;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(11, 277);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 21);
            this.label2.TabIndex = 351;
            this.label2.Text = "Destinatarios:";
            // 
            // lblPrioridad
            // 
            this.lblPrioridad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPrioridad.AutoSize = true;
            this.lblPrioridad.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrioridad.ForeColor = System.Drawing.Color.Black;
            this.lblPrioridad.Location = new System.Drawing.Point(310, 140);
            this.lblPrioridad.Name = "lblPrioridad";
            this.lblPrioridad.Size = new System.Drawing.Size(77, 21);
            this.lblPrioridad.TabIndex = 363;
            this.lblPrioridad.Text = "Prioridad:";
            // 
            // dtpFechaLimite
            // 
            this.dtpFechaLimite.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpFechaLimite.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.dtpFechaLimite.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFechaLimite.Location = new System.Drawing.Point(842, 134);
            this.dtpFechaLimite.Name = "dtpFechaLimite";
            this.dtpFechaLimite.Size = new System.Drawing.Size(105, 29);
            this.dtpFechaLimite.TabIndex = 2;
            // 
            // lblFechaLimite
            // 
            this.lblFechaLimite.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFechaLimite.AutoSize = true;
            this.lblFechaLimite.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaLimite.ForeColor = System.Drawing.Color.Black;
            this.lblFechaLimite.Location = new System.Drawing.Point(577, 140);
            this.lblFechaLimite.Name = "lblFechaLimite";
            this.lblFechaLimite.Size = new System.Drawing.Size(259, 21);
            this.lblFechaLimite.TabIndex = 364;
            this.lblFechaLimite.Text = "Fecha límite de respuesta/ejecución:";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.panel2.Controls.Add(this.pictureBox2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(546, 80);
            this.panel2.TabIndex = 349;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox2.Image = global::CapaPresentacion.Properties.Resources.Left_Arrow_32;
            this.pictureBox2.Location = new System.Drawing.Point(15, 22);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(32, 32);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 32;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI Light", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(53, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(338, 23);
            this.label1.TabIndex = 31;
            this.label1.Text = "Seleccione destinatario";
            // 
            // panelDestinatarios
            // 
            this.panelDestinatarios.Controls.Add(this.btnSeleccionarDestinatario);
            this.panelDestinatarios.Controls.Add(this.dgvPosiblesDestinatarios);
            this.panelDestinatarios.Controls.Add(this.panel2);
            this.panelDestinatarios.Location = new System.Drawing.Point(12, 345);
            this.panelDestinatarios.Name = "panelDestinatarios";
            this.panelDestinatarios.Size = new System.Drawing.Size(546, 388);
            this.panelDestinatarios.TabIndex = 365;
            this.panelDestinatarios.Visible = false;
            this.panelDestinatarios.Paint += new System.Windows.Forms.PaintEventHandler(this.panelDestinatarios_Paint);
            // 
            // btnSeleccionarDestinatario
            // 
            this.btnSeleccionarDestinatario.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSeleccionarDestinatario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnSeleccionarDestinatario.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSeleccionarDestinatario.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnSeleccionarDestinatario.FlatAppearance.BorderSize = 0;
            this.btnSeleccionarDestinatario.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnSeleccionarDestinatario.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnSeleccionarDestinatario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSeleccionarDestinatario.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSeleccionarDestinatario.ForeColor = System.Drawing.Color.White;
            this.btnSeleccionarDestinatario.Image = global::CapaPresentacion.Properties.Resources.Arrowhead_Right_32;
            this.btnSeleccionarDestinatario.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSeleccionarDestinatario.Location = new System.Drawing.Point(416, 86);
            this.btnSeleccionarDestinatario.Name = "btnSeleccionarDestinatario";
            this.btnSeleccionarDestinatario.Size = new System.Drawing.Size(115, 35);
            this.btnSeleccionarDestinatario.TabIndex = 357;
            this.btnSeleccionarDestinatario.Text = "Seleccionar";
            this.btnSeleccionarDestinatario.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSeleccionarDestinatario.UseVisualStyleBackColor = false;
            this.btnSeleccionarDestinatario.Click += new System.EventHandler(this.btnSeleccionarDestinatario_Click);
            // 
            // dgvPosiblesDestinatarios
            // 
            this.dgvPosiblesDestinatarios.AllowUserToAddRows = false;
            this.dgvPosiblesDestinatarios.AllowUserToDeleteRows = false;
            this.dgvPosiblesDestinatarios.AllowUserToOrderColumns = true;
            this.dgvPosiblesDestinatarios.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dgvPosiblesDestinatarios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPosiblesDestinatarios.BackgroundColor = System.Drawing.Color.White;
            this.dgvPosiblesDestinatarios.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvPosiblesDestinatarios.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSlateGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 12F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPosiblesDestinatarios.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPosiblesDestinatarios.ColumnHeadersHeight = 40;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 12F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPosiblesDestinatarios.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvPosiblesDestinatarios.EnableHeadersVisualStyles = false;
            this.dgvPosiblesDestinatarios.GridColor = System.Drawing.Color.WhiteSmoke;
            this.dgvPosiblesDestinatarios.Location = new System.Drawing.Point(15, 135);
            this.dgvPosiblesDestinatarios.MultiSelect = false;
            this.dgvPosiblesDestinatarios.Name = "dgvPosiblesDestinatarios";
            this.dgvPosiblesDestinatarios.ReadOnly = true;
            this.dgvPosiblesDestinatarios.RowHeadersVisible = false;
            this.dgvPosiblesDestinatarios.RowHeadersWidth = 50;
            this.dgvPosiblesDestinatarios.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvPosiblesDestinatarios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPosiblesDestinatarios.Size = new System.Drawing.Size(516, 237);
            this.dgvPosiblesDestinatarios.TabIndex = 356;
            // 
            // lblTipoAdjunto
            // 
            this.lblTipoAdjunto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTipoAdjunto.AutoSize = true;
            this.lblTipoAdjunto.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipoAdjunto.ForeColor = System.Drawing.Color.Black;
            this.lblTipoAdjunto.Location = new System.Drawing.Point(646, 268);
            this.lblTipoAdjunto.Name = "lblTipoAdjunto";
            this.lblTipoAdjunto.Size = new System.Drawing.Size(47, 21);
            this.lblTipoAdjunto.TabIndex = 368;
            this.lblTipoAdjunto.Text = "Tipo: ";
            this.lblTipoAdjunto.Click += new System.EventHandler(this.lblTipoAdjunto_Click);
            // 
            // boton1
            // 
            this.boton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.boton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.boton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.boton1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.boton1.FlatAppearance.BorderSize = 0;
            this.boton1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.boton1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.boton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.boton1.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.boton1.ForeColor = System.Drawing.Color.White;
            this.boton1.Image = global::CapaPresentacion.Properties.Resources.Data_Delete_32;
            this.boton1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.boton1.Location = new System.Drawing.Point(912, 264);
            this.boton1.Name = "boton1";
            this.boton1.Size = new System.Drawing.Size(35, 35);
            this.boton1.TabIndex = 369;
            this.boton1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.boton1.UseVisualStyleBackColor = false;
            this.boton1.Click += new System.EventHandler(this.boton1_Click);
            // 
            // cboPrioridad
            // 
            this.cboPrioridad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboPrioridad.BorderColor = System.Drawing.Color.Empty;
            this.cboPrioridad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPrioridad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboPrioridad.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cboPrioridad.ForeColor = System.Drawing.Color.Black;
            this.cboPrioridad.FormattingEnabled = true;
            this.cboPrioridad.Items.AddRange(new object[] {
            "ALTA",
            "MEDIA",
            "BAJA"});
            this.cboPrioridad.Location = new System.Drawing.Point(393, 134);
            this.cboPrioridad.Name = "cboPrioridad";
            this.cboPrioridad.Size = new System.Drawing.Size(166, 29);
            this.cboPrioridad.TabIndex = 1;
            // 
            // btnBuscarAdjunto
            // 
            this.btnBuscarAdjunto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBuscarAdjunto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnBuscarAdjunto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscarAdjunto.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnBuscarAdjunto.FlatAppearance.BorderSize = 0;
            this.btnBuscarAdjunto.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnBuscarAdjunto.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnBuscarAdjunto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarAdjunto.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnBuscarAdjunto.ForeColor = System.Drawing.Color.White;
            this.btnBuscarAdjunto.Image = global::CapaPresentacion.Properties.Resources.lupa;
            this.btnBuscarAdjunto.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBuscarAdjunto.Location = new System.Drawing.Point(871, 264);
            this.btnBuscarAdjunto.Name = "btnBuscarAdjunto";
            this.btnBuscarAdjunto.Size = new System.Drawing.Size(35, 35);
            this.btnBuscarAdjunto.TabIndex = 4;
            this.btnBuscarAdjunto.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscarAdjunto.UseVisualStyleBackColor = false;
            this.btnBuscarAdjunto.Click += new System.EventHandler(this.btnBuscarAdjunto_Click);
            // 
            // dgvAdjuntos
            // 
            this.dgvAdjuntos.AllowUserToAddRows = false;
            this.dgvAdjuntos.AllowUserToDeleteRows = false;
            this.dgvAdjuntos.AllowUserToOrderColumns = true;
            this.dgvAdjuntos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvAdjuntos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAdjuntos.BackgroundColor = System.Drawing.Color.White;
            this.dgvAdjuntos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvAdjuntos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.LightSlateGray;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 12F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAdjuntos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvAdjuntos.ColumnHeadersHeight = 40;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 12F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvAdjuntos.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvAdjuntos.EnableHeadersVisualStyles = false;
            this.dgvAdjuntos.GridColor = System.Drawing.Color.WhiteSmoke;
            this.dgvAdjuntos.Location = new System.Drawing.Point(371, 307);
            this.dgvAdjuntos.MultiSelect = false;
            this.dgvAdjuntos.Name = "dgvAdjuntos";
            this.dgvAdjuntos.ReadOnly = true;
            this.dgvAdjuntos.RowHeadersVisible = false;
            this.dgvAdjuntos.RowHeadersWidth = 50;
            this.dgvAdjuntos.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvAdjuntos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAdjuntos.Size = new System.Drawing.Size(576, 193);
            this.dgvAdjuntos.TabIndex = 359;
            // 
            // txtMensaje
            // 
            this.txtMensaje.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMensaje.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtMensaje.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMensaje.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMensaje.FocusColor = System.Drawing.Color.Empty;
            this.txtMensaje.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMensaje.ForeColor = System.Drawing.Color.DimGray;
            this.txtMensaje.Location = new System.Drawing.Point(16, 169);
            this.txtMensaje.MaxLength = 140;
            this.txtMensaje.Multiline = true;
            this.txtMensaje.Name = "txtMensaje";
            this.txtMensaje.Numerico = false;
            this.txtMensaje.Size = new System.Drawing.Size(931, 74);
            this.txtMensaje.TabIndex = 0;
            this.txtMensaje.Tag = "\"\"";
            this.txtMensaje.TextChanged += new System.EventHandler(this.txtMensaje_TextChanged);
            // 
            // btnAgregarDestinatario
            // 
            this.btnAgregarDestinatario.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAgregarDestinatario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnAgregarDestinatario.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregarDestinatario.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnAgregarDestinatario.FlatAppearance.BorderSize = 0;
            this.btnAgregarDestinatario.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnAgregarDestinatario.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnAgregarDestinatario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarDestinatario.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarDestinatario.ForeColor = System.Drawing.Color.White;
            this.btnAgregarDestinatario.Image = global::CapaPresentacion.Properties.Resources.Data_Add_32;
            this.btnAgregarDestinatario.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAgregarDestinatario.Location = new System.Drawing.Point(276, 264);
            this.btnAgregarDestinatario.Name = "btnAgregarDestinatario";
            this.btnAgregarDestinatario.Size = new System.Drawing.Size(35, 35);
            this.btnAgregarDestinatario.TabIndex = 3;
            this.btnAgregarDestinatario.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgregarDestinatario.UseVisualStyleBackColor = false;
            this.btnAgregarDestinatario.Click += new System.EventHandler(this.btnAgregarDestinatario_Click);
            // 
            // dgvDestinatarios
            // 
            this.dgvDestinatarios.AllowUserToAddRows = false;
            this.dgvDestinatarios.AllowUserToDeleteRows = false;
            this.dgvDestinatarios.AllowUserToOrderColumns = true;
            this.dgvDestinatarios.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dgvDestinatarios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDestinatarios.BackgroundColor = System.Drawing.Color.White;
            this.dgvDestinatarios.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDestinatarios.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.LightSlateGray;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 12F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDestinatarios.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvDestinatarios.ColumnHeadersHeight = 40;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 12F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDestinatarios.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvDestinatarios.EnableHeadersVisualStyles = false;
            this.dgvDestinatarios.GridColor = System.Drawing.Color.WhiteSmoke;
            this.dgvDestinatarios.Location = new System.Drawing.Point(15, 307);
            this.dgvDestinatarios.MultiSelect = false;
            this.dgvDestinatarios.Name = "dgvDestinatarios";
            this.dgvDestinatarios.ReadOnly = true;
            this.dgvDestinatarios.RowHeadersVisible = false;
            this.dgvDestinatarios.RowHeadersWidth = 50;
            this.dgvDestinatarios.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvDestinatarios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDestinatarios.Size = new System.Drawing.Size(337, 193);
            this.dgvDestinatarios.TabIndex = 355;
            // 
            // btnEnviar
            // 
            this.btnEnviar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEnviar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnEnviar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEnviar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnEnviar.FlatAppearance.BorderSize = 0;
            this.btnEnviar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnEnviar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnEnviar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEnviar.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnviar.ForeColor = System.Drawing.Color.White;
            this.btnEnviar.Image = global::CapaPresentacion.Properties.Resources.Arrowhead_Right_32;
            this.btnEnviar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEnviar.Location = new System.Drawing.Point(865, 86);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(82, 35);
            this.btnEnviar.TabIndex = 5;
            this.btnEnviar.Text = "Enviar";
            this.btnEnviar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEnviar.UseVisualStyleBackColor = false;
            this.btnEnviar.Click += new System.EventHandler(this.btnEnviar_Click);
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
            this.btnEliminar.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.ForeColor = System.Drawing.Color.White;
            this.btnEliminar.Image = global::CapaPresentacion.Properties.Resources.Data_Delete_32;
            this.btnEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEliminar.Location = new System.Drawing.Point(317, 264);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(35, 35);
            this.btnEliminar.TabIndex = 366;
            this.btnEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // cboTipoAdjunto
            // 
            this.cboTipoAdjunto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cboTipoAdjunto.BorderColor = System.Drawing.Color.Empty;
            this.cboTipoAdjunto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoAdjunto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboTipoAdjunto.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cboTipoAdjunto.ForeColor = System.Drawing.Color.Black;
            this.cboTipoAdjunto.FormattingEnabled = true;
            this.cboTipoAdjunto.Items.AddRange(new object[] {
            "USUARIO",
            "LOCACIÓN",
            "PARTE"});
            this.cboTipoAdjunto.Location = new System.Drawing.Point(699, 265);
            this.cboTipoAdjunto.Name = "cboTipoAdjunto";
            this.cboTipoAdjunto.Size = new System.Drawing.Size(166, 29);
            this.cboTipoAdjunto.TabIndex = 367;
            this.cboTipoAdjunto.SelectedIndexChanged += new System.EventHandler(this.cboTipoAdjunto_SelectedIndexChanged);
            // 
            // AbmCargaEdicionNotificacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(250)))), ((int)(((byte)(251)))));
            this.ClientSize = new System.Drawing.Size(959, 512);
            this.Controls.Add(this.boton1);
            this.Controls.Add(this.panelDestinatarios);
            this.Controls.Add(this.dtpFechaLimite);
            this.Controls.Add(this.lblFechaLimite);
            this.Controls.Add(this.lblPrioridad);
            this.Controls.Add(this.cboPrioridad);
            this.Controls.Add(this.btnBuscarAdjunto);
            this.Controls.Add(this.dgvAdjuntos);
            this.Controls.Add(this.txtMensaje);
            this.Controls.Add(this.btnAgregarDestinatario);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dgvDestinatarios);
            this.Controls.Add(this.lblMensaje);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.btnEnviar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.lblTipoAdjunto);
            this.Controls.Add(this.cboTipoAdjunto);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "AbmCargaEdicionNotificacion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "AbmCargaEdicionNotificacion";
            this.Load += new System.EventHandler(this.AbmCargaEdicionNotificacion_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AbmCargaEdicionNotificacion_KeyDown);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panelDestinatarios.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPosiblesDestinatarios)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAdjuntos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDestinatarios)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblTituloHeader;
        private System.Windows.Forms.Label label4;
        private Controles.dgv dgvDestinatarios;
        private System.Windows.Forms.Label lblMensaje;
        private System.Windows.Forms.Panel panel5;
        private Controles.boton btnEnviar;
        private System.Windows.Forms.Label label2;
        private Controles.boton btnAgregarDestinatario;
        private textboxAdv txtMensaje;
        private Controles.dgv dgvAdjuntos;
        private Controles.boton btnBuscarAdjunto;
        private System.Windows.Forms.Label lblPrioridad;
        private Controles.combo cboPrioridad;
        private System.Windows.Forms.DateTimePicker dtpFechaLimite;
        private System.Windows.Forms.Label lblFechaLimite;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label1;
        private Controles.dgv dgvPosiblesDestinatarios;
        private System.Windows.Forms.Panel panelDestinatarios;
        private Controles.boton btnSeleccionarDestinatario;
        private Controles.boton btnEliminar;
        private System.Windows.Forms.Label lblTipoAdjunto;
        private Controles.combo cboTipoAdjunto;
        private Controles.boton boton1;
    }
}