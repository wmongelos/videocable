namespace CapaPresentacion
{
    partial class frmCuadroTarifario
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
            this.pnHeader = new System.Windows.Forms.Panel();
            this.imgReturn = new System.Windows.Forms.PictureBox();
            this.lblTituloHeader = new System.Windows.Forms.Label();
            this.pnFooter = new System.Windows.Forms.Panel();
            this.lblTotal = new System.Windows.Forms.Label();
            this.pgCircular = new CapaPresentacion.Controles.progress();
            this.lblEstadoServicio = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblRSubServicio = new System.Windows.Forms.Label();
            this.lblRServicio = new System.Windows.Forms.Label();
            this.lblRTipoServ = new System.Windows.Forms.Label();
            this.lblRGrupo = new System.Windows.Forms.Label();
            this.lblReferencias = new System.Windows.Forms.Label();
            this.lblZonaCategoria = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblTarifaSeleccionada = new System.Windows.Forms.Label();
            this.lblZonaCatSeleccionada = new System.Windows.Forms.Label();
            this.dgv = new CapaPresentacion.Controles.dgv(this.components);
            this.cboZonaCategoria = new CapaPresentacion.Controles.combo(this.components);
            this.cboTipos = new CapaPresentacion.Controles.combo(this.components);
            this.cboGrupos = new CapaPresentacion.Controles.combo(this.components);
            this.cboTarifas = new CapaPresentacion.Controles.combo(this.components);
            this.btnConsultar = new CapaPresentacion.Controles.boton();
            this.btnExportar = new CapaPresentacion.Controles.boton();
            this.pnHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgReturn)).BeginInit();
            this.pnFooter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // pnHeader
            // 
            this.pnHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.pnHeader.Controls.Add(this.imgReturn);
            this.pnHeader.Controls.Add(this.lblTituloHeader);
            this.pnHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnHeader.Location = new System.Drawing.Point(0, 0);
            this.pnHeader.Name = "pnHeader";
            this.pnHeader.Size = new System.Drawing.Size(1183, 75);
            this.pnHeader.TabIndex = 47;
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
            this.lblTituloHeader.Size = new System.Drawing.Size(388, 23);
            this.lblTituloHeader.TabIndex = 31;
            this.lblTituloHeader.Text = "Cuadro Tarifario";
            // 
            // pnFooter
            // 
            this.pnFooter.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnFooter.Controls.Add(this.lblTotal);
            this.pnFooter.Controls.Add(this.pgCircular);
            this.pnFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnFooter.Location = new System.Drawing.Point(0, 429);
            this.pnFooter.Name = "pnFooter";
            this.pnFooter.Size = new System.Drawing.Size(1183, 30);
            this.pnFooter.TabIndex = 218;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblTotal.ForeColor = System.Drawing.Color.SlateGray;
            this.lblTotal.Location = new System.Drawing.Point(8, 5);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(148, 21);
            this.lblTotal.TabIndex = 13;
            this.lblTotal.Text = "Total de Registros: 0";
            // 
            // pgCircular
            // 
            this.pgCircular.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pgCircular.Location = new System.Drawing.Point(1147, 2);
            this.pgCircular.Name = "pgCircular";
            this.pgCircular.Percentage = 0F;
            this.pgCircular.Rotation = CapaPresentacion.Controles.RotationType.CounterClockwise;
            this.pgCircular.Size = new System.Drawing.Size(24, 24);
            this.pgCircular.TabIndex = 0;
            // 
            // lblEstadoServicio
            // 
            this.lblEstadoServicio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblEstadoServicio.AutoSize = true;
            this.lblEstadoServicio.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblEstadoServicio.ForeColor = System.Drawing.Color.Black;
            this.lblEstadoServicio.Location = new System.Drawing.Point(230, 89);
            this.lblEstadoServicio.Name = "lblEstadoServicio";
            this.lblEstadoServicio.Size = new System.Drawing.Size(57, 21);
            this.lblEstadoServicio.TabIndex = 231;
            this.lblEstadoServicio.Text = "Tarifas:";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(865, 133);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 21);
            this.label1.TabIndex = 233;
            this.label1.Text = "Grupo:";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(879, 162);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 21);
            this.label2.TabIndex = 235;
            this.label2.Text = "Tipo:";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.Silver;
            this.panel1.Location = new System.Drawing.Point(0, 124);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1202, 1);
            this.panel1.TabIndex = 336;
            // 
            // lblRSubServicio
            // 
            this.lblRSubServicio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRSubServicio.BackColor = System.Drawing.Color.LightGray;
            this.lblRSubServicio.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRSubServicio.ForeColor = System.Drawing.Color.Black;
            this.lblRSubServicio.Location = new System.Drawing.Point(1054, 405);
            this.lblRSubServicio.Name = "lblRSubServicio";
            this.lblRSubServicio.Size = new System.Drawing.Size(118, 21);
            this.lblRSubServicio.TabIndex = 341;
            this.lblRSubServicio.Text = "Sub Servicio";
            this.lblRSubServicio.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblRServicio
            // 
            this.lblRServicio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRServicio.BackColor = System.Drawing.Color.PaleTurquoise;
            this.lblRServicio.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRServicio.ForeColor = System.Drawing.Color.Black;
            this.lblRServicio.Location = new System.Drawing.Point(930, 405);
            this.lblRServicio.Name = "lblRServicio";
            this.lblRServicio.Size = new System.Drawing.Size(118, 21);
            this.lblRServicio.TabIndex = 340;
            this.lblRServicio.Text = "Servicio";
            this.lblRServicio.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblRTipoServ
            // 
            this.lblRTipoServ.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRTipoServ.BackColor = System.Drawing.Color.MediumAquamarine;
            this.lblRTipoServ.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRTipoServ.ForeColor = System.Drawing.Color.Black;
            this.lblRTipoServ.Location = new System.Drawing.Point(806, 405);
            this.lblRTipoServ.Name = "lblRTipoServ";
            this.lblRTipoServ.Size = new System.Drawing.Size(118, 21);
            this.lblRTipoServ.TabIndex = 339;
            this.lblRTipoServ.Text = "Tipo de servicio";
            this.lblRTipoServ.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblRGrupo
            // 
            this.lblRGrupo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRGrupo.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.lblRGrupo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRGrupo.ForeColor = System.Drawing.Color.Black;
            this.lblRGrupo.Location = new System.Drawing.Point(682, 405);
            this.lblRGrupo.Name = "lblRGrupo";
            this.lblRGrupo.Size = new System.Drawing.Size(118, 21);
            this.lblRGrupo.TabIndex = 338;
            this.lblRGrupo.Text = "Grupo";
            this.lblRGrupo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblReferencias
            // 
            this.lblReferencias.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblReferencias.AutoSize = true;
            this.lblReferencias.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReferencias.ForeColor = System.Drawing.Color.Black;
            this.lblReferencias.Location = new System.Drawing.Point(583, 405);
            this.lblReferencias.Name = "lblReferencias";
            this.lblReferencias.Size = new System.Drawing.Size(93, 21);
            this.lblReferencias.TabIndex = 337;
            this.lblReferencias.Text = "Referencias:";
            // 
            // lblZonaCategoria
            // 
            this.lblZonaCategoria.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblZonaCategoria.AutoSize = true;
            this.lblZonaCategoria.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblZonaCategoria.ForeColor = System.Drawing.Color.Black;
            this.lblZonaCategoria.Location = new System.Drawing.Point(593, 89);
            this.lblZonaCategoria.Name = "lblZonaCategoria";
            this.lblZonaCategoria.Size = new System.Drawing.Size(61, 21);
            this.lblZonaCategoria.TabIndex = 342;
            this.lblZonaCategoria.Text = "Zona/C";
            this.lblZonaCategoria.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.Silver;
            this.panel2.Location = new System.Drawing.Point(0, 191);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1202, 1);
            this.panel2.TabIndex = 337;
            // 
            // lblTarifaSeleccionada
            // 
            this.lblTarifaSeleccionada.AutoSize = true;
            this.lblTarifaSeleccionada.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblTarifaSeleccionada.ForeColor = System.Drawing.Color.Black;
            this.lblTarifaSeleccionada.Location = new System.Drawing.Point(8, 133);
            this.lblTarifaSeleccionada.Name = "lblTarifaSeleccionada";
            this.lblTarifaSeleccionada.Size = new System.Drawing.Size(146, 21);
            this.lblTarifaSeleccionada.TabIndex = 344;
            this.lblTarifaSeleccionada.Text = "Tarifa seleccionada: ";
            // 
            // lblZonaCatSeleccionada
            // 
            this.lblZonaCatSeleccionada.AutoSize = true;
            this.lblZonaCatSeleccionada.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblZonaCatSeleccionada.ForeColor = System.Drawing.Color.Black;
            this.lblZonaCatSeleccionada.Location = new System.Drawing.Point(8, 160);
            this.lblZonaCatSeleccionada.Name = "lblZonaCatSeleccionada";
            this.lblZonaCatSeleccionada.Size = new System.Drawing.Size(166, 21);
            this.lblZonaCatSeleccionada.TabIndex = 345;
            this.lblZonaCatSeleccionada.Text = "Zona/cat seleccionada:";
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
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSlateGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgv.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.dgv.EnableHeadersVisualStyles = false;
            this.dgv.GridColor = System.Drawing.Color.WhiteSmoke;
            this.dgv.Location = new System.Drawing.Point(12, 198);
            this.dgv.MultiSelect = false;
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersVisible = false;
            this.dgv.RowHeadersWidth = 50;
            this.dgv.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(1159, 194);
            this.dgv.TabIndex = 346;
            // 
            // cboZonaCategoria
            // 
            this.cboZonaCategoria.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboZonaCategoria.BorderColor = System.Drawing.Color.Gainsboro;
            this.cboZonaCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboZonaCategoria.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboZonaCategoria.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboZonaCategoria.FormattingEnabled = true;
            this.cboZonaCategoria.Location = new System.Drawing.Point(673, 89);
            this.cboZonaCategoria.Name = "cboZonaCategoria";
            this.cboZonaCategoria.Size = new System.Drawing.Size(244, 25);
            this.cboZonaCategoria.TabIndex = 343;
            // 
            // cboTipos
            // 
            this.cboTipos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboTipos.BorderColor = System.Drawing.Color.Gainsboro;
            this.cboTipos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboTipos.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTipos.FormattingEnabled = true;
            this.cboTipos.Location = new System.Drawing.Point(928, 160);
            this.cboTipos.Name = "cboTipos";
            this.cboTipos.Size = new System.Drawing.Size(244, 25);
            this.cboTipos.TabIndex = 234;
            this.cboTipos.SelectedValueChanged += new System.EventHandler(this.cboTipos_SelectedValueChanged);
            // 
            // cboGrupos
            // 
            this.cboGrupos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboGrupos.BorderColor = System.Drawing.Color.Gainsboro;
            this.cboGrupos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGrupos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboGrupos.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboGrupos.FormattingEnabled = true;
            this.cboGrupos.Location = new System.Drawing.Point(928, 131);
            this.cboGrupos.Name = "cboGrupos";
            this.cboGrupos.Size = new System.Drawing.Size(244, 25);
            this.cboGrupos.TabIndex = 232;
            this.cboGrupos.SelectedIndexChanged += new System.EventHandler(this.cboGrupos_SelectedIndexChanged);
            this.cboGrupos.SelectedValueChanged += new System.EventHandler(this.cboGrupos_SelectedValueChanged);
            // 
            // cboTarifas
            // 
            this.cboTarifas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboTarifas.BorderColor = System.Drawing.Color.Gainsboro;
            this.cboTarifas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTarifas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboTarifas.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTarifas.FormattingEnabled = true;
            this.cboTarifas.Location = new System.Drawing.Point(295, 89);
            this.cboTarifas.Name = "cboTarifas";
            this.cboTarifas.Size = new System.Drawing.Size(244, 25);
            this.cboTarifas.TabIndex = 230;
            // 
            // btnConsultar
            // 
            this.btnConsultar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConsultar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnConsultar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConsultar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnConsultar.FlatAppearance.BorderSize = 0;
            this.btnConsultar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnConsultar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnConsultar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConsultar.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnConsultar.ForeColor = System.Drawing.Color.White;
            this.btnConsultar.Image = global::CapaPresentacion.Properties.Resources.lupa;
            this.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnConsultar.Location = new System.Drawing.Point(926, 81);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(109, 37);
            this.btnConsultar.TabIndex = 222;
            this.btnConsultar.Text = "Consultar";
            this.btnConsultar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConsultar.UseVisualStyleBackColor = false;
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // btnExportar
            // 
            this.btnExportar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnExportar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExportar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnExportar.FlatAppearance.BorderSize = 0;
            this.btnExportar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnExportar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnExportar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportar.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnExportar.ForeColor = System.Drawing.Color.White;
            this.btnExportar.Image = global::CapaPresentacion.Properties.Resources.Data_Export_32;
            this.btnExportar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExportar.Location = new System.Drawing.Point(1062, 81);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(109, 37);
            this.btnExportar.TabIndex = 347;
            this.btnExportar.Text = "Exportar";
            this.btnExportar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExportar.UseVisualStyleBackColor = false;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // frmCuadroTarifario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(250)))), ((int)(((byte)(251)))));
            this.ClientSize = new System.Drawing.Size(1183, 459);
            this.Controls.Add(this.btnExportar);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.lblZonaCatSeleccionada);
            this.Controls.Add(this.lblTarifaSeleccionada);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.cboZonaCategoria);
            this.Controls.Add(this.lblZonaCategoria);
            this.Controls.Add(this.lblRSubServicio);
            this.Controls.Add(this.lblRServicio);
            this.Controls.Add(this.lblRTipoServ);
            this.Controls.Add(this.lblRGrupo);
            this.Controls.Add(this.lblReferencias);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cboTipos);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboGrupos);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboTarifas);
            this.Controls.Add(this.lblEstadoServicio);
            this.Controls.Add(this.btnConsultar);
            this.Controls.Add(this.pnFooter);
            this.Controls.Add(this.pnHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "frmCuadroTarifario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmCuadroTarifario";
            this.Load += new System.EventHandler(this.frmCuadroTarifario_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmCuadroTarifario_KeyDown);
            this.pnHeader.ResumeLayout(false);
            this.pnHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgReturn)).EndInit();
            this.pnFooter.ResumeLayout(false);
            this.pnFooter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnHeader;
        private System.Windows.Forms.PictureBox imgReturn;
        private System.Windows.Forms.Label lblTituloHeader;
        private System.Windows.Forms.Panel pnFooter;
        private System.Windows.Forms.Label lblTotal;
        private Controles.progress pgCircular;
        private Controles.boton btnConsultar;
        private Controles.combo cboTarifas;
        private System.Windows.Forms.Label lblEstadoServicio;
        private Controles.combo cboGrupos;
        private System.Windows.Forms.Label label1;
        private Controles.combo cboTipos;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblRSubServicio;
        private System.Windows.Forms.Label lblRServicio;
        private System.Windows.Forms.Label lblRTipoServ;
        private System.Windows.Forms.Label lblRGrupo;
        private System.Windows.Forms.Label lblReferencias;
        private System.Windows.Forms.Label lblZonaCategoria;
        private Controles.combo cboZonaCategoria;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblTarifaSeleccionada;
        private System.Windows.Forms.Label lblZonaCatSeleccionada;
        private Controles.dgv dgv;
        private Controles.boton btnExportar;
    }
}