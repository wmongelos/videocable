namespace CapaPresentacion.Abms
{
    partial class ABMDebitosPresentacionDetalles
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle25 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle26 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle27 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel3 = new System.Windows.Forms.Panel();
            this.imgReturn = new System.Windows.Forms.PictureBox();
            this.lblTituloHeader = new System.Windows.Forms.Label();
            this.lblPrioridad = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblTotalPlasticos = new System.Windows.Forms.Label();
            this.lblNroPlasticos = new System.Windows.Forms.Label();
            this.lblPendienteDePago = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.lblPeriodoPresentacion = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.bgwListarDebitosYServiciosAdheridos = new System.ComponentModel.BackgroundWorker();
            this.pbProgreso = new System.Windows.Forms.ProgressBar();
            this.bgwListarSubservicios = new System.ComponentModel.BackgroundWorker();
            this.lblProgreso = new System.Windows.Forms.Label();
            this.bgwListarDeudasAdelantadas = new System.ComponentModel.BackgroundWorker();
            this.bgwCalcularBonificaciones = new System.ComponentModel.BackgroundWorker();
            this.bgwCalcularMontosFinales = new System.ComponentModel.BackgroundWorker();
            this.bgwCargarPresentacionExistente = new System.ComponentModel.BackgroundWorker();
            this.btnExportar = new CapaPresentacion.Controles.boton();
            this.dgvDeudasAnexadas = new CapaPresentacion.Controles.dgv(this.components);
            this.pgCircular = new CapaPresentacion.Controles.progress();
            this.btnConfirmarPresentacion = new CapaPresentacion.Controles.boton();
            this.dgvServicios = new CapaPresentacion.Controles.dgv(this.components);
            this.btnBuscar = new CapaPresentacion.Controles.boton();
            this.txtBuscar = new CapaPresentacion.textboxAdv();
            this.dgvPlasticos = new CapaPresentacion.Controles.dgv(this.components);
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgReturn)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDeudasAnexadas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvServicios)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlasticos)).BeginInit();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.panel3.Controls.Add(this.imgReturn);
            this.panel3.Controls.Add(this.lblTituloHeader);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1207, 80);
            this.panel3.TabIndex = 48;
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
            this.lblTituloHeader.Text = "Detalles de la presentación";
            // 
            // lblPrioridad
            // 
            this.lblPrioridad.AutoSize = true;
            this.lblPrioridad.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrioridad.ForeColor = System.Drawing.Color.Black;
            this.lblPrioridad.Location = new System.Drawing.Point(8, 144);
            this.lblPrioridad.Name = "lblPrioridad";
            this.lblPrioridad.Size = new System.Drawing.Size(274, 21);
            this.lblPrioridad.TabIndex = 343;
            this.lblPrioridad.Text = "Plásticos que integran la presentación:";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(8, 328);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(256, 21);
            this.label1.TabIndex = 354;
            this.label1.Text = "Servicios que componen al plástico:";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.Silver;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(0, 127);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1213, 1);
            this.panel1.TabIndex = 391;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.Silver;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1213, 1);
            this.panel2.TabIndex = 392;
            // 
            // lblTotalPlasticos
            // 
            this.lblTotalPlasticos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalPlasticos.AutoSize = true;
            this.lblTotalPlasticos.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalPlasticos.ForeColor = System.Drawing.Color.Black;
            this.lblTotalPlasticos.Location = new System.Drawing.Point(970, 515);
            this.lblTotalPlasticos.Name = "lblTotalPlasticos";
            this.lblTotalPlasticos.Size = new System.Drawing.Size(56, 25);
            this.lblTotalPlasticos.TabIndex = 393;
            this.lblTotalPlasticos.Text = "Total:";
            // 
            // lblNroPlasticos
            // 
            this.lblNroPlasticos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNroPlasticos.AutoSize = true;
            this.lblNroPlasticos.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNroPlasticos.ForeColor = System.Drawing.Color.Black;
            this.lblNroPlasticos.Location = new System.Drawing.Point(690, 516);
            this.lblNroPlasticos.Name = "lblNroPlasticos";
            this.lblNroPlasticos.Size = new System.Drawing.Size(128, 21);
            this.lblNroPlasticos.TabIndex = 396;
            this.lblNroPlasticos.Text = "Nro. de plásticos:";
            // 
            // lblPendienteDePago
            // 
            this.lblPendienteDePago.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblPendienteDePago.BackColor = System.Drawing.Color.CadetBlue;
            this.lblPendienteDePago.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblPendienteDePago.Location = new System.Drawing.Point(104, 516);
            this.lblPendienteDePago.Name = "lblPendienteDePago";
            this.lblPendienteDePago.Size = new System.Drawing.Size(96, 25);
            this.lblPendienteDePago.TabIndex = 397;
            this.lblPendienteDePago.Text = "Servicio";
            this.lblPendienteDePago.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.BackColor = System.Drawing.Color.LightBlue;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label2.Location = new System.Drawing.Point(206, 516);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 25);
            this.label2.TabIndex = 398;
            this.label2.Text = "Subservicio";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(5, 516);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 21);
            this.label3.TabIndex = 399;
            this.label3.Text = "Referencias:";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(690, 328);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(214, 21);
            this.label4.TabIndex = 405;
            this.label4.Text = "Deudas adicionales anexadas:";
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.BackColor = System.Drawing.Color.Silver;
            this.panel4.Location = new System.Drawing.Point(0, 509);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1213, 1);
            this.panel4.TabIndex = 406;
            // 
            // panel5
            // 
            this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel5.BackColor = System.Drawing.Color.Silver;
            this.panel5.Controls.Add(this.panel6);
            this.panel5.Location = new System.Drawing.Point(0, 314);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1213, 1);
            this.panel5.TabIndex = 393;
            // 
            // panel6
            // 
            this.panel6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel6.BackColor = System.Drawing.Color.Silver;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(1213, 1);
            this.panel6.TabIndex = 392;
            // 
            // lblPeriodoPresentacion
            // 
            this.lblPeriodoPresentacion.AutoSize = true;
            this.lblPeriodoPresentacion.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPeriodoPresentacion.ForeColor = System.Drawing.Color.Black;
            this.lblPeriodoPresentacion.Location = new System.Drawing.Point(7, 99);
            this.lblPeriodoPresentacion.Name = "lblPeriodoPresentacion";
            this.lblPeriodoPresentacion.Size = new System.Drawing.Size(458, 25);
            this.lblPeriodoPresentacion.TabIndex = 407;
            this.lblPeriodoPresentacion.Text = "Datos de la presentación correspondiente al periodo:";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(8, 289);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 21);
            this.label5.TabIndex = 410;
            this.label5.Text = "Referencias:";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.BackColor = System.Drawing.Color.Tomato;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label6.Location = new System.Drawing.Point(209, 285);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(96, 25);
            this.label6.TabIndex = 409;
            this.label6.Text = "Rechazado";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label7.BackColor = System.Drawing.Color.LightGreen;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label7.Location = new System.Drawing.Point(107, 285);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(96, 25);
            this.label7.TabIndex = 408;
            this.label7.Text = "Pagado";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // bgwListarDebitosYServiciosAdheridos
            // 
            this.bgwListarDebitosYServiciosAdheridos.WorkerReportsProgress = true;
            this.bgwListarDebitosYServiciosAdheridos.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgwListarServicios_ProgressChanged);
            this.bgwListarDebitosYServiciosAdheridos.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwListarServicios_RunWorkerCompleted);
            // 
            // pbProgreso
            // 
            this.pbProgreso.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pbProgreso.Location = new System.Drawing.Point(902, 287);
            this.pbProgreso.Name = "pbProgreso";
            this.pbProgreso.Size = new System.Drawing.Size(293, 23);
            this.pbProgreso.TabIndex = 412;
            this.pbProgreso.Visible = false;
            // 
            // bgwListarSubservicios
            // 
            this.bgwListarSubservicios.WorkerReportsProgress = true;
            this.bgwListarSubservicios.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgwListarSubservicios_ProgressChanged);
            this.bgwListarSubservicios.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwListarSubservicios_RunWorkerCompleted);
            // 
            // lblProgreso
            // 
            this.lblProgreso.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblProgreso.AutoSize = true;
            this.lblProgreso.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProgreso.ForeColor = System.Drawing.Color.Black;
            this.lblProgreso.Location = new System.Drawing.Point(645, 289);
            this.lblProgreso.Name = "lblProgreso";
            this.lblProgreso.Size = new System.Drawing.Size(117, 21);
            this.lblProgreso.TabIndex = 413;
            this.lblProgreso.Text = "Datos progreso";
            this.lblProgreso.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblProgreso.Visible = false;
            // 
            // bgwListarDeudasAdelantadas
            // 
            this.bgwListarDeudasAdelantadas.WorkerReportsProgress = true;
            this.bgwListarDeudasAdelantadas.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgwListarDeudasAdelantadas_ProgressChanged);
            this.bgwListarDeudasAdelantadas.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwListarDeudasAdelantadas_RunWorkerCompleted);
            // 
            // bgwCalcularBonificaciones
            // 
            this.bgwCalcularBonificaciones.WorkerReportsProgress = true;
            this.bgwCalcularBonificaciones.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgwCalcularBonificaciones_ProgressChanged);
            this.bgwCalcularBonificaciones.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwCalcularBonificaciones_RunWorkerCompleted);
            // 
            // bgwCalcularMontosFinales
            // 
            this.bgwCalcularMontosFinales.WorkerReportsProgress = true;
            this.bgwCalcularMontosFinales.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgwCalcularMontosFinales_ProgressChanged);
            this.bgwCalcularMontosFinales.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwCalcularMontosFinales_RunWorkerCompleted);
            // 
            // bgwCargarPresentacionExistente
            // 
            this.bgwCargarPresentacionExistente.WorkerReportsProgress = true;
            this.bgwCargarPresentacionExistente.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgwCargarPresentacionExistente_ProgressChanged);
            this.bgwCargarPresentacionExistente.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwCargarPresentacionExistente_RunWorkerCompleted);
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
            this.btnExportar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExportar.Location = new System.Drawing.Point(1033, 87);
            this.btnExportar.Margin = new System.Windows.Forms.Padding(2);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(162, 35);
            this.btnExportar.TabIndex = 411;
            this.btnExportar.Text = "Exportar a Excel";
            this.btnExportar.UseVisualStyleBackColor = false;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click_1);
            // 
            // dgvDeudasAnexadas
            // 
            this.dgvDeudasAnexadas.AllowUserToAddRows = false;
            this.dgvDeudasAnexadas.AllowUserToDeleteRows = false;
            this.dgvDeudasAnexadas.AllowUserToOrderColumns = true;
            this.dgvDeudasAnexadas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDeudasAnexadas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDeudasAnexadas.BackgroundColor = System.Drawing.Color.White;
            this.dgvDeudasAnexadas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDeudasAnexadas.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle19.BackColor = System.Drawing.Color.LightSlateGray;
            dataGridViewCellStyle19.Font = new System.Drawing.Font("Segoe UI", 12F);
            dataGridViewCellStyle19.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle19.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle19.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle19.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDeudasAnexadas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle19;
            this.dgvDeudasAnexadas.ColumnHeadersHeight = 50;
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle20.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle20.Font = new System.Drawing.Font("Segoe UI", 12F);
            dataGridViewCellStyle20.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle20.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            dataGridViewCellStyle20.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle20.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDeudasAnexadas.DefaultCellStyle = dataGridViewCellStyle20;
            this.dgvDeudasAnexadas.EnableHeadersVisualStyles = false;
            this.dgvDeudasAnexadas.GridColor = System.Drawing.Color.WhiteSmoke;
            this.dgvDeudasAnexadas.Location = new System.Drawing.Point(694, 352);
            this.dgvDeudasAnexadas.MultiSelect = false;
            this.dgvDeudasAnexadas.Name = "dgvDeudasAnexadas";
            this.dgvDeudasAnexadas.ReadOnly = true;
            this.dgvDeudasAnexadas.RowHeadersVisible = false;
            this.dgvDeudasAnexadas.RowHeadersWidth = 50;
            dataGridViewCellStyle21.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDeudasAnexadas.RowsDefaultCellStyle = dataGridViewCellStyle21;
            this.dgvDeudasAnexadas.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvDeudasAnexadas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvDeudasAnexadas.Size = new System.Drawing.Size(501, 151);
            this.dgvDeudasAnexadas.TabIndex = 404;
            // 
            // pgCircular
            // 
            this.pgCircular.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pgCircular.BackColor = System.Drawing.Color.White;
            this.pgCircular.Location = new System.Drawing.Point(542, 199);
            this.pgCircular.Name = "pgCircular";
            this.pgCircular.Percentage = 0F;
            this.pgCircular.Rotation = CapaPresentacion.Controles.RotationType.CounterClockwise;
            this.pgCircular.Size = new System.Drawing.Size(49, 49);
            this.pgCircular.TabIndex = 0;
            this.pgCircular.Visible = false;
            // 
            // btnConfirmarPresentacion
            // 
            this.btnConfirmarPresentacion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConfirmarPresentacion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnConfirmarPresentacion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConfirmarPresentacion.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnConfirmarPresentacion.FlatAppearance.BorderSize = 0;
            this.btnConfirmarPresentacion.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnConfirmarPresentacion.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnConfirmarPresentacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirmarPresentacion.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirmarPresentacion.ForeColor = System.Drawing.Color.White;
            this.btnConfirmarPresentacion.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnConfirmarPresentacion.Location = new System.Drawing.Point(866, 87);
            this.btnConfirmarPresentacion.Name = "btnConfirmarPresentacion";
            this.btnConfirmarPresentacion.Size = new System.Drawing.Size(162, 35);
            this.btnConfirmarPresentacion.TabIndex = 395;
            this.btnConfirmarPresentacion.Text = "Generar presentación";
            this.btnConfirmarPresentacion.UseVisualStyleBackColor = false;
            this.btnConfirmarPresentacion.Visible = false;
            this.btnConfirmarPresentacion.Click += new System.EventHandler(this.btnConfirmarPresentacion_Click);
            // 
            // dgvServicios
            // 
            this.dgvServicios.AllowUserToAddRows = false;
            this.dgvServicios.AllowUserToDeleteRows = false;
            this.dgvServicios.AllowUserToOrderColumns = true;
            this.dgvServicios.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvServicios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvServicios.BackgroundColor = System.Drawing.Color.White;
            this.dgvServicios.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvServicios.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle22.BackColor = System.Drawing.Color.LightSlateGray;
            dataGridViewCellStyle22.Font = new System.Drawing.Font("Segoe UI", 12F);
            dataGridViewCellStyle22.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle22.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle22.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle22.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvServicios.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle22;
            this.dgvServicios.ColumnHeadersHeight = 50;
            dataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle23.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle23.Font = new System.Drawing.Font("Segoe UI", 12F);
            dataGridViewCellStyle23.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle23.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            dataGridViewCellStyle23.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle23.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvServicios.DefaultCellStyle = dataGridViewCellStyle23;
            this.dgvServicios.EnableHeadersVisualStyles = false;
            this.dgvServicios.GridColor = System.Drawing.Color.WhiteSmoke;
            this.dgvServicios.Location = new System.Drawing.Point(12, 352);
            this.dgvServicios.MultiSelect = false;
            this.dgvServicios.Name = "dgvServicios";
            this.dgvServicios.ReadOnly = true;
            this.dgvServicios.RowHeadersVisible = false;
            this.dgvServicios.RowHeadersWidth = 50;
            dataGridViewCellStyle24.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvServicios.RowsDefaultCellStyle = dataGridViewCellStyle24;
            this.dgvServicios.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvServicios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvServicios.Size = new System.Drawing.Size(665, 151);
            this.dgvServicios.TabIndex = 352;
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
            this.btnBuscar.Location = new System.Drawing.Point(1109, 130);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(86, 35);
            this.btnBuscar.TabIndex = 351;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txtBuscar
            // 
            this.txtBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBuscar.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtBuscar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBuscar.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBuscar.FocusColor = System.Drawing.Color.Empty;
            this.txtBuscar.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscar.ForeColor = System.Drawing.Color.DimGray;
            this.txtBuscar.Location = new System.Drawing.Point(866, 136);
            this.txtBuscar.MaxLength = 50;
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Numerico = false;
            this.txtBuscar.Size = new System.Drawing.Size(237, 29);
            this.txtBuscar.TabIndex = 347;
            this.txtBuscar.Tag = "\"\"";
            this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);
            // 
            // dgvPlasticos
            // 
            this.dgvPlasticos.AllowUserToAddRows = false;
            this.dgvPlasticos.AllowUserToDeleteRows = false;
            this.dgvPlasticos.AllowUserToOrderColumns = true;
            this.dgvPlasticos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPlasticos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPlasticos.BackgroundColor = System.Drawing.Color.White;
            this.dgvPlasticos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvPlasticos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle25.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle25.BackColor = System.Drawing.Color.LightSlateGray;
            dataGridViewCellStyle25.Font = new System.Drawing.Font("Segoe UI", 12F);
            dataGridViewCellStyle25.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle25.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle25.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle25.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPlasticos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle25;
            this.dgvPlasticos.ColumnHeadersHeight = 50;
            dataGridViewCellStyle26.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle26.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle26.Font = new System.Drawing.Font("Segoe UI", 12F);
            dataGridViewCellStyle26.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle26.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            dataGridViewCellStyle26.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle26.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPlasticos.DefaultCellStyle = dataGridViewCellStyle26;
            this.dgvPlasticos.EnableHeadersVisualStyles = false;
            this.dgvPlasticos.GridColor = System.Drawing.Color.WhiteSmoke;
            this.dgvPlasticos.Location = new System.Drawing.Point(12, 171);
            this.dgvPlasticos.MultiSelect = false;
            this.dgvPlasticos.Name = "dgvPlasticos";
            this.dgvPlasticos.ReadOnly = true;
            this.dgvPlasticos.RowHeadersVisible = false;
            this.dgvPlasticos.RowHeadersWidth = 50;
            dataGridViewCellStyle27.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPlasticos.RowsDefaultCellStyle = dataGridViewCellStyle27;
            this.dgvPlasticos.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvPlasticos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPlasticos.Size = new System.Drawing.Size(1183, 110);
            this.dgvPlasticos.TabIndex = 342;
            this.dgvPlasticos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPlasticos_CellClick);
            this.dgvPlasticos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPlasticos_CellContentClick);
            // 
            // ABMDebitosPresentacionDetalles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(250)))), ((int)(((byte)(251)))));
            this.ClientSize = new System.Drawing.Size(1207, 546);
            this.Controls.Add(this.lblProgreso);
            this.Controls.Add(this.pbProgreso);
            this.Controls.Add(this.btnExportar);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblPeriodoPresentacion);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dgvDeudasAnexadas);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblPendienteDePago);
            this.Controls.Add(this.pgCircular);
            this.Controls.Add(this.lblNroPlasticos);
            this.Controls.Add(this.btnConfirmarPresentacion);
            this.Controls.Add(this.lblTotalPlasticos);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvServicios);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.lblPrioridad);
            this.Controls.Add(this.dgvPlasticos);
            this.Controls.Add(this.panel3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ABMDebitosPresentacionDetalles";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ABMDebitosPresentacionDetalles";
            this.Load += new System.EventHandler(this.ABMDebitosPresentacionDetalles_Load);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgReturn)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDeudasAnexadas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvServicios)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlasticos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox imgReturn;
        private System.Windows.Forms.Label lblTituloHeader;
        private Controles.dgv dgvPlasticos;
        private System.Windows.Forms.Label lblPrioridad;
        private Controles.progress pgCircular;
        private textboxAdv txtBuscar;
        private Controles.boton btnBuscar;
        private Controles.dgv dgvServicios;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblTotalPlasticos;
        private Controles.boton btnConfirmarPresentacion;
        private System.Windows.Forms.Label lblNroPlasticos;
        private System.Windows.Forms.Label lblPendienteDePago;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private Controles.dgv dgvDeudasAnexadas;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label lblPeriodoPresentacion;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private Controles.boton btnExportar;
        private System.ComponentModel.BackgroundWorker bgwListarDebitosYServiciosAdheridos;
        private System.Windows.Forms.ProgressBar pbProgreso;
        private System.ComponentModel.BackgroundWorker bgwListarSubservicios;
        private System.Windows.Forms.Label lblProgreso;
        private System.ComponentModel.BackgroundWorker bgwListarDeudasAdelantadas;
        private System.ComponentModel.BackgroundWorker bgwCalcularBonificaciones;
        private System.ComponentModel.BackgroundWorker bgwCalcularMontosFinales;
        private System.ComponentModel.BackgroundWorker bgwCargarPresentacionExistente;
    }
}