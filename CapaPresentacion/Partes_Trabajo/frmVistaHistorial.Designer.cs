namespace CapaPresentacion.Partes_Trabajo
{
    partial class frmVistaHistorial
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
            this.pnFooter = new System.Windows.Forms.Panel();
            this.lblTotal = new System.Windows.Forms.Label();
            this.pgCircular = new CapaPresentacion.Controles.progress();
            this.imgReturn = new System.Windows.Forms.PictureBox();
            this.panelOpciones = new System.Windows.Forms.Panel();
            this.lblTituloHeader = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelFiltro = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBuscador = new CapaPresentacion.textboxAdv();
            this.btnExportar = new CapaPresentacion.Controles.boton();
            this.btnImprimir = new CapaPresentacion.Controles.boton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panelCampos = new System.Windows.Forms.Panel();
            this.checkedListBoxCampos = new System.Windows.Forms.CheckedListBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.pnlOpciones = new System.Windows.Forms.Panel();
            this.btnAnular = new CapaPresentacion.Controles.boton();
            this.btnVerServicios = new CapaPresentacion.Controles.boton();
            this.btnSeguimiento = new CapaPresentacion.Controles.boton();
            this.btnConfirmar = new CapaPresentacion.Controles.boton();
            this.btnReprogramar = new CapaPresentacion.Controles.boton();
            this.btnAsignarTarjeta = new CapaPresentacion.Controles.boton();
            this.btnAsignarEquipo = new CapaPresentacion.Controles.boton();
            this.btnAsignarTecnico = new CapaPresentacion.Controles.boton();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dgvPartes = new CapaPresentacion.Controles.dgv(this.components);
            this.dgvObservaciones = new CapaPresentacion.Controles.dgv(this.components);
            this.lblObservacionesGPS = new System.Windows.Forms.Label();
            this.pdSelectPrinter = new System.Windows.Forms.PrintDialog();
            this.pnFooter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgReturn)).BeginInit();
            this.panelOpciones.SuspendLayout();
            this.panelFiltro.SuspendLayout();
            this.panelCampos.SuspendLayout();
            this.pnlOpciones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPartes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvObservaciones)).BeginInit();
            this.SuspendLayout();
            // 
            // pnFooter
            // 
            this.pnFooter.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnFooter.Controls.Add(this.lblTotal);
            this.pnFooter.Controls.Add(this.pgCircular);
            this.pnFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnFooter.Location = new System.Drawing.Point(0, 509);
            this.pnFooter.Name = "pnFooter";
            this.pnFooter.Size = new System.Drawing.Size(1284, 30);
            this.pnFooter.TabIndex = 356;
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
            this.pgCircular.Location = new System.Drawing.Point(1244, 2);
            this.pgCircular.Name = "pgCircular";
            this.pgCircular.Percentage = 0F;
            this.pgCircular.Rotation = CapaPresentacion.Controles.RotationType.CounterClockwise;
            this.pgCircular.Size = new System.Drawing.Size(24, 24);
            this.pgCircular.TabIndex = 0;
            // 
            // imgReturn
            // 
            this.imgReturn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.imgReturn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.imgReturn.Image = global::CapaPresentacion.Properties.Resources.Left_Arrow_32;
            this.imgReturn.Location = new System.Drawing.Point(16, 15);
            this.imgReturn.Name = "imgReturn";
            this.imgReturn.Size = new System.Drawing.Size(32, 32);
            this.imgReturn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgReturn.TabIndex = 33;
            this.imgReturn.TabStop = false;
            this.imgReturn.Click += new System.EventHandler(this.imgReturn_Click);
            // 
            // panelOpciones
            // 
            this.panelOpciones.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.panelOpciones.Controls.Add(this.lblTituloHeader);
            this.panelOpciones.Controls.Add(this.imgReturn);
            this.panelOpciones.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelOpciones.Location = new System.Drawing.Point(0, 0);
            this.panelOpciones.Name = "panelOpciones";
            this.panelOpciones.Size = new System.Drawing.Size(1284, 63);
            this.panelOpciones.TabIndex = 357;
            // 
            // lblTituloHeader
            // 
            this.lblTituloHeader.Font = new System.Drawing.Font("Segoe UI Light", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloHeader.ForeColor = System.Drawing.Color.White;
            this.lblTituloHeader.Location = new System.Drawing.Point(60, 18);
            this.lblTituloHeader.Name = "lblTituloHeader";
            this.lblTituloHeader.Size = new System.Drawing.Size(338, 27);
            this.lblTituloHeader.TabIndex = 35;
            this.lblTituloHeader.Text = "Vista de historial de partes";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 508);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1284, 1);
            this.panel1.TabIndex = 362;
            // 
            // panelFiltro
            // 
            this.panelFiltro.Controls.Add(this.label1);
            this.panelFiltro.Controls.Add(this.txtBuscador);
            this.panelFiltro.Controls.Add(this.btnExportar);
            this.panelFiltro.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelFiltro.Location = new System.Drawing.Point(0, 63);
            this.panelFiltro.Name = "panelFiltro";
            this.panelFiltro.Size = new System.Drawing.Size(1284, 51);
            this.panelFiltro.TabIndex = 366;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI Light", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 27);
            this.label1.TabIndex = 38;
            this.label1.Text = "Filtrar:";
            // 
            // txtBuscador
            // 
            this.txtBuscador.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBuscador.BorderColor = System.Drawing.Color.Empty;
            this.txtBuscador.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBuscador.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBuscador.FocusColor = System.Drawing.Color.Empty;
            this.txtBuscador.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscador.Location = new System.Drawing.Point(81, 11);
            this.txtBuscador.Name = "txtBuscador";
            this.txtBuscador.Numerico = false;
            this.txtBuscador.Size = new System.Drawing.Size(924, 29);
            this.txtBuscador.TabIndex = 36;
            this.txtBuscador.TextChanged += new System.EventHandler(this.txtBuscador_TextChanged);
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
            this.btnExportar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportar.ForeColor = System.Drawing.Color.White;
            this.btnExportar.Image = global::CapaPresentacion.Properties.Resources.Data_Export_32;
            this.btnExportar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExportar.Location = new System.Drawing.Point(1162, 11);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(106, 29);
            this.btnExportar.TabIndex = 34;
            this.btnExportar.Text = "Exportar";
            this.btnExportar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExportar.UseVisualStyleBackColor = true;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // btnImprimir
            // 
            this.btnImprimir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnImprimir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnImprimir.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnImprimir.FlatAppearance.BorderSize = 0;
            this.btnImprimir.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnImprimir.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImprimir.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImprimir.ForeColor = System.Drawing.Color.White;
            this.btnImprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnImprimir.Location = new System.Drawing.Point(1049, 6);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(126, 29);
            this.btnImprimir.TabIndex = 39;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 114);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1284, 1);
            this.panel3.TabIndex = 368;
            // 
            // panelCampos
            // 
            this.panelCampos.Controls.Add(this.checkedListBoxCampos);
            this.panelCampos.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelCampos.Location = new System.Drawing.Point(1, 158);
            this.panelCampos.Name = "panelCampos";
            this.panelCampos.Padding = new System.Windows.Forms.Padding(5);
            this.panelCampos.Size = new System.Drawing.Size(168, 350);
            this.panelCampos.TabIndex = 370;
            // 
            // checkedListBoxCampos
            // 
            this.checkedListBoxCampos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.checkedListBoxCampos.CheckOnClick = true;
            this.checkedListBoxCampos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkedListBoxCampos.Font = new System.Drawing.Font("Segoe UI Light", 12F);
            this.checkedListBoxCampos.FormattingEnabled = true;
            this.checkedListBoxCampos.HorizontalScrollbar = true;
            this.checkedListBoxCampos.Location = new System.Drawing.Point(5, 5);
            this.checkedListBoxCampos.Name = "checkedListBoxCampos";
            this.checkedListBoxCampos.Size = new System.Drawing.Size(158, 340);
            this.checkedListBoxCampos.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(0, 115);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1, 393);
            this.panel4.TabIndex = 372;
            // 
            // pnlOpciones
            // 
            this.pnlOpciones.Controls.Add(this.btnImprimir);
            this.pnlOpciones.Controls.Add(this.btnAnular);
            this.pnlOpciones.Controls.Add(this.btnVerServicios);
            this.pnlOpciones.Controls.Add(this.btnSeguimiento);
            this.pnlOpciones.Controls.Add(this.btnConfirmar);
            this.pnlOpciones.Controls.Add(this.btnReprogramar);
            this.pnlOpciones.Controls.Add(this.btnAsignarTarjeta);
            this.pnlOpciones.Controls.Add(this.btnAsignarEquipo);
            this.pnlOpciones.Controls.Add(this.btnAsignarTecnico);
            this.pnlOpciones.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlOpciones.Location = new System.Drawing.Point(1, 115);
            this.pnlOpciones.Name = "pnlOpciones";
            this.pnlOpciones.Size = new System.Drawing.Size(1283, 41);
            this.pnlOpciones.TabIndex = 374;
            // 
            // btnAnular
            // 
            this.btnAnular.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnAnular.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAnular.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnAnular.FlatAppearance.BorderSize = 0;
            this.btnAnular.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnAnular.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnAnular.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAnular.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAnular.ForeColor = System.Drawing.Color.White;
            this.btnAnular.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAnular.Location = new System.Drawing.Point(919, 6);
            this.btnAnular.Name = "btnAnular";
            this.btnAnular.Size = new System.Drawing.Size(124, 29);
            this.btnAnular.TabIndex = 47;
            this.btnAnular.Text = "Anular";
            this.btnAnular.UseVisualStyleBackColor = true;
            this.btnAnular.Click += new System.EventHandler(this.btnAnular_Click);
            // 
            // btnVerServicios
            // 
            this.btnVerServicios.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnVerServicios.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVerServicios.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnVerServicios.FlatAppearance.BorderSize = 0;
            this.btnVerServicios.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnVerServicios.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnVerServicios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVerServicios.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVerServicios.ForeColor = System.Drawing.Color.White;
            this.btnVerServicios.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnVerServicios.Location = new System.Drawing.Point(789, 6);
            this.btnVerServicios.Name = "btnVerServicios";
            this.btnVerServicios.Size = new System.Drawing.Size(124, 29);
            this.btnVerServicios.TabIndex = 46;
            this.btnVerServicios.Text = "Ver servicios";
            this.btnVerServicios.UseVisualStyleBackColor = true;
            this.btnVerServicios.Click += new System.EventHandler(this.btnVerServicios_Click);
            // 
            // btnSeguimiento
            // 
            this.btnSeguimiento.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnSeguimiento.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSeguimiento.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnSeguimiento.FlatAppearance.BorderSize = 0;
            this.btnSeguimiento.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnSeguimiento.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnSeguimiento.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSeguimiento.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSeguimiento.ForeColor = System.Drawing.Color.White;
            this.btnSeguimiento.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSeguimiento.Location = new System.Drawing.Point(659, 6);
            this.btnSeguimiento.Name = "btnSeguimiento";
            this.btnSeguimiento.Size = new System.Drawing.Size(124, 29);
            this.btnSeguimiento.TabIndex = 45;
            this.btnSeguimiento.Text = "Seguimiento";
            this.btnSeguimiento.UseVisualStyleBackColor = true;
            this.btnSeguimiento.Click += new System.EventHandler(this.btnSeguimiento_Click);
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnConfirmar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConfirmar.Enabled = false;
            this.btnConfirmar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnConfirmar.FlatAppearance.BorderSize = 0;
            this.btnConfirmar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnConfirmar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnConfirmar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirmar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirmar.ForeColor = System.Drawing.Color.White;
            this.btnConfirmar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnConfirmar.Location = new System.Drawing.Point(528, 6);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(124, 29);
            this.btnConfirmar.TabIndex = 44;
            this.btnConfirmar.Text = "Confirmar";
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // btnReprogramar
            // 
            this.btnReprogramar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnReprogramar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReprogramar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnReprogramar.FlatAppearance.BorderSize = 0;
            this.btnReprogramar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnReprogramar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnReprogramar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReprogramar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReprogramar.ForeColor = System.Drawing.Color.White;
            this.btnReprogramar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnReprogramar.Location = new System.Drawing.Point(397, 6);
            this.btnReprogramar.Name = "btnReprogramar";
            this.btnReprogramar.Size = new System.Drawing.Size(124, 29);
            this.btnReprogramar.TabIndex = 43;
            this.btnReprogramar.Text = "Reprogramar";
            this.btnReprogramar.UseVisualStyleBackColor = true;
            this.btnReprogramar.Click += new System.EventHandler(this.btnReprogramar_Click);
            // 
            // btnAsignarTarjeta
            // 
            this.btnAsignarTarjeta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnAsignarTarjeta.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAsignarTarjeta.Enabled = false;
            this.btnAsignarTarjeta.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnAsignarTarjeta.FlatAppearance.BorderSize = 0;
            this.btnAsignarTarjeta.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnAsignarTarjeta.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnAsignarTarjeta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAsignarTarjeta.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAsignarTarjeta.ForeColor = System.Drawing.Color.White;
            this.btnAsignarTarjeta.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAsignarTarjeta.Location = new System.Drawing.Point(267, 6);
            this.btnAsignarTarjeta.Name = "btnAsignarTarjeta";
            this.btnAsignarTarjeta.Size = new System.Drawing.Size(124, 29);
            this.btnAsignarTarjeta.TabIndex = 42;
            this.btnAsignarTarjeta.Text = "Asignar tarjeta";
            this.btnAsignarTarjeta.UseVisualStyleBackColor = true;
            this.btnAsignarTarjeta.Click += new System.EventHandler(this.btnAsignarTarjeta_Click);
            // 
            // btnAsignarEquipo
            // 
            this.btnAsignarEquipo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnAsignarEquipo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAsignarEquipo.Enabled = false;
            this.btnAsignarEquipo.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnAsignarEquipo.FlatAppearance.BorderSize = 0;
            this.btnAsignarEquipo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnAsignarEquipo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnAsignarEquipo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAsignarEquipo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAsignarEquipo.ForeColor = System.Drawing.Color.White;
            this.btnAsignarEquipo.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAsignarEquipo.Location = new System.Drawing.Point(137, 6);
            this.btnAsignarEquipo.Name = "btnAsignarEquipo";
            this.btnAsignarEquipo.Size = new System.Drawing.Size(124, 29);
            this.btnAsignarEquipo.TabIndex = 41;
            this.btnAsignarEquipo.Text = "Asignar equipo";
            this.btnAsignarEquipo.UseVisualStyleBackColor = true;
            this.btnAsignarEquipo.Click += new System.EventHandler(this.btnAsignarEquipo_Click);
            // 
            // btnAsignarTecnico
            // 
            this.btnAsignarTecnico.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnAsignarTecnico.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAsignarTecnico.Enabled = false;
            this.btnAsignarTecnico.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnAsignarTecnico.FlatAppearance.BorderSize = 0;
            this.btnAsignarTecnico.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnAsignarTecnico.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnAsignarTecnico.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAsignarTecnico.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAsignarTecnico.ForeColor = System.Drawing.Color.White;
            this.btnAsignarTecnico.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAsignarTecnico.Location = new System.Drawing.Point(7, 6);
            this.btnAsignarTecnico.Name = "btnAsignarTecnico";
            this.btnAsignarTecnico.Size = new System.Drawing.Size(124, 29);
            this.btnAsignarTecnico.TabIndex = 40;
            this.btnAsignarTecnico.Text = "Asignar técnico";
            this.btnAsignarTecnico.UseVisualStyleBackColor = true;
            this.btnAsignarTecnico.Click += new System.EventHandler(this.btnAsignarTecnico_Click);
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(1, 156);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1283, 1);
            this.panel5.TabIndex = 375;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(1, 157);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1283, 1);
            this.panel2.TabIndex = 377;
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(169, 158);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dgvPartes);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgvObservaciones);
            this.splitContainer1.Panel2.Controls.Add(this.lblObservacionesGPS);
            this.splitContainer1.Size = new System.Drawing.Size(1115, 350);
            this.splitContainer1.SplitterDistance = 227;
            this.splitContainer1.TabIndex = 378;
            // 
            // dgvPartes
            // 
            this.dgvPartes.AllowUserToAddRows = false;
            this.dgvPartes.AllowUserToDeleteRows = false;
            this.dgvPartes.AllowUserToOrderColumns = true;
            this.dgvPartes.AllowUserToResizeRows = false;
            this.dgvPartes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPartes.BackgroundColor = System.Drawing.Color.White;
            this.dgvPartes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvPartes.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI Light", 14F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPartes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPartes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPartes.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvPartes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPartes.EnableHeadersVisualStyles = false;
            this.dgvPartes.GridColor = System.Drawing.Color.WhiteSmoke;
            this.dgvPartes.Location = new System.Drawing.Point(0, 0);
            this.dgvPartes.MultiSelect = false;
            this.dgvPartes.Name = "dgvPartes";
            this.dgvPartes.ReadOnly = true;
            this.dgvPartes.RowHeadersVisible = false;
            this.dgvPartes.RowHeadersWidth = 50;
            this.dgvPartes.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvPartes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPartes.Size = new System.Drawing.Size(1111, 223);
            this.dgvPartes.TabIndex = 374;
            this.dgvPartes.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPartes_CellClick);
            this.dgvPartes.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPartes_CellContentClick);
            this.dgvPartes.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPartes_CellEnter);
            this.dgvPartes.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvPartes_CellFormatting);
            // 
            // dgvObservaciones
            // 
            this.dgvObservaciones.AllowUserToAddRows = false;
            this.dgvObservaciones.AllowUserToDeleteRows = false;
            this.dgvObservaciones.AllowUserToOrderColumns = true;
            this.dgvObservaciones.AllowUserToResizeRows = false;
            this.dgvObservaciones.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvObservaciones.BackgroundColor = System.Drawing.Color.White;
            this.dgvObservaciones.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvObservaciones.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI Light", 14F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvObservaciones.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvObservaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvObservaciones.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvObservaciones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvObservaciones.EnableHeadersVisualStyles = false;
            this.dgvObservaciones.GridColor = System.Drawing.Color.WhiteSmoke;
            this.dgvObservaciones.Location = new System.Drawing.Point(0, 27);
            this.dgvObservaciones.MultiSelect = false;
            this.dgvObservaciones.Name = "dgvObservaciones";
            this.dgvObservaciones.ReadOnly = true;
            this.dgvObservaciones.RowHeadersVisible = false;
            this.dgvObservaciones.RowHeadersWidth = 50;
            this.dgvObservaciones.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvObservaciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvObservaciones.Size = new System.Drawing.Size(1111, 88);
            this.dgvObservaciones.TabIndex = 377;
            // 
            // lblObservacionesGPS
            // 
            this.lblObservacionesGPS.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblObservacionesGPS.Font = new System.Drawing.Font("Segoe UI Light", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblObservacionesGPS.ForeColor = System.Drawing.Color.Black;
            this.lblObservacionesGPS.Location = new System.Drawing.Point(0, 0);
            this.lblObservacionesGPS.Name = "lblObservacionesGPS";
            this.lblObservacionesGPS.Size = new System.Drawing.Size(1111, 27);
            this.lblObservacionesGPS.TabIndex = 376;
            this.lblObservacionesGPS.Text = "GPS Observaciones:";
            // 
            // pdSelectPrinter
            // 
            this.pdSelectPrinter.UseEXDialog = true;
            // 
            // frmVistaHistorial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1284, 539);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panelCampos);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.pnlOpciones);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panelFiltro);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelOpciones);
            this.Controls.Add(this.pnFooter);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "frmVistaHistorial";
            this.Text = "frmVistaHistorial";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmVistaHistorial_KeyDown);
            this.pnFooter.ResumeLayout(false);
            this.pnFooter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgReturn)).EndInit();
            this.panelOpciones.ResumeLayout(false);
            this.panelOpciones.PerformLayout();
            this.panelFiltro.ResumeLayout(false);
            this.panelFiltro.PerformLayout();
            this.panelCampos.ResumeLayout(false);
            this.pnlOpciones.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPartes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvObservaciones)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnFooter;
        private System.Windows.Forms.Label lblTotal;
        private Controles.progress pgCircular;
        private System.Windows.Forms.PictureBox imgReturn;
        private System.Windows.Forms.Panel panelOpciones;
        private System.Windows.Forms.Label lblTituloHeader;
        private System.Windows.Forms.Panel panel1;
        private Controles.boton btnExportar;
        private textboxAdv txtBuscador;
        private System.Windows.Forms.Panel panelFiltro;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panelCampos;
        private System.Windows.Forms.CheckedListBox checkedListBoxCampos;
        private System.Windows.Forms.Panel panel4;
        private Controles.boton btnImprimir;
        private System.Windows.Forms.Panel pnlOpciones;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private Controles.dgv dgvPartes;
        private Controles.boton btnAsignarTecnico;
        private Controles.boton btnAsignarEquipo;
        private Controles.boton btnAsignarTarjeta;
        private Controles.boton btnReprogramar;
        private Controles.boton btnConfirmar;
        private Controles.boton btnSeguimiento;
        private Controles.boton btnVerServicios;
        private Controles.dgv dgvObservaciones;
        private System.Windows.Forms.Label lblObservacionesGPS;
        private Controles.boton btnAnular;
        private System.Windows.Forms.PrintDialog pdSelectPrinter;
    }
}