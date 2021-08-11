namespace CapaPresentacion.Cuenta_Corriente
{
    partial class frmCtaCtePlanesDePago
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblLocacion = new System.Windows.Forms.Label();
            this.lbcorreo = new System.Windows.Forms.Label();
            this.lbcuit = new System.Windows.Forms.Label();
            this.LBNumero_documento = new System.Windows.Forms.Label();
            this.LBApellido = new System.Windows.Forms.Label();
            this.lblTituloForm = new System.Windows.Forms.Label();
            this.imgServicios_Unicos = new System.Windows.Forms.PictureBox();
            this.lblComprobantesSeleccionados = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblDefinicionPlanDePago = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblAnticipo = new System.Windows.Forms.Label();
            this.lblMontoRestante = new System.Windows.Forms.Label();
            this.lblRecargo = new System.Windows.Forms.Label();
            this.lblMontoRecargo = new System.Windows.Forms.Label();
            this.lblPorcentaje = new System.Windows.Forms.Label();
            this.lblCantidadCuotas = new System.Windows.Forms.Label();
            this.lblFechaComienzoPlanPago = new System.Windows.Forms.Label();
            this.dpFechaComienzoPago = new System.Windows.Forms.DateTimePicker();
            this.spCantidadCuotas = new CapaPresentacion.Controles.spinner(this.components);
            this.pgCircular = new CapaPresentacion.Controles.progress();
            this.btnVistaPrevia = new CapaPresentacion.Controles.boton();
            this.spRecargo = new CapaPresentacion.Controles.spinner(this.components);
            this.dgvComprobantesPlanDePago = new CapaPresentacion.Controles.dgv(this.components);
            this.spAnticipo = new CapaPresentacion.Controles.spinner(this.components);
            this.btnGenerarComprobantes = new CapaPresentacion.Controles.boton();
            this.dgvComprobantesAdeudados = new CapaPresentacion.Controles.dgv(this.components);
            this.lblMontoTotalOriginal = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgServicios_Unicos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spCantidadCuotas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spRecargo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvComprobantesPlanDePago)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spAnticipo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvComprobantesAdeudados)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.panel2.Controls.Add(this.lblLocacion);
            this.panel2.Controls.Add(this.lbcorreo);
            this.panel2.Controls.Add(this.lbcuit);
            this.panel2.Controls.Add(this.LBNumero_documento);
            this.panel2.Controls.Add(this.LBApellido);
            this.panel2.Controls.Add(this.lblTituloForm);
            this.panel2.Controls.Add(this.imgServicios_Unicos);
            this.panel2.Location = new System.Drawing.Point(-1, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1102, 96);
            this.panel2.TabIndex = 177;
            // 
            // lblLocacion
            // 
            this.lblLocacion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLocacion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.lblLocacion.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblLocacion.ForeColor = System.Drawing.Color.White;
            this.lblLocacion.Location = new System.Drawing.Point(776, 40);
            this.lblLocacion.Name = "lblLocacion";
            this.lblLocacion.Size = new System.Drawing.Size(301, 23);
            this.lblLocacion.TabIndex = 215;
            this.lblLocacion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbcorreo
            // 
            this.lbcorreo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbcorreo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.lbcorreo.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lbcorreo.ForeColor = System.Drawing.Color.White;
            this.lbcorreo.Location = new System.Drawing.Point(630, 63);
            this.lbcorreo.Name = "lbcorreo";
            this.lbcorreo.Size = new System.Drawing.Size(447, 22);
            this.lbcorreo.TabIndex = 214;
            this.lbcorreo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbcuit
            // 
            this.lbcuit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbcuit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.lbcuit.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lbcuit.ForeColor = System.Drawing.Color.White;
            this.lbcuit.Location = new System.Drawing.Point(530, 40);
            this.lbcuit.Name = "lbcuit";
            this.lbcuit.Size = new System.Drawing.Size(230, 23);
            this.lbcuit.TabIndex = 213;
            this.lbcuit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LBNumero_documento
            // 
            this.LBNumero_documento.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LBNumero_documento.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.LBNumero_documento.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.LBNumero_documento.ForeColor = System.Drawing.Color.White;
            this.LBNumero_documento.Location = new System.Drawing.Point(602, 9);
            this.LBNumero_documento.Name = "LBNumero_documento";
            this.LBNumero_documento.Size = new System.Drawing.Size(220, 23);
            this.LBNumero_documento.TabIndex = 212;
            this.LBNumero_documento.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LBApellido
            // 
            this.LBApellido.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LBApellido.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.LBApellido.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.LBApellido.ForeColor = System.Drawing.Color.White;
            this.LBApellido.Location = new System.Drawing.Point(860, 9);
            this.LBApellido.Name = "LBApellido";
            this.LBApellido.Size = new System.Drawing.Size(217, 23);
            this.LBApellido.TabIndex = 211;
            this.LBApellido.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTituloForm
            // 
            this.lblTituloForm.AutoSize = true;
            this.lblTituloForm.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.lblTituloForm.ForeColor = System.Drawing.Color.Transparent;
            this.lblTituloForm.Location = new System.Drawing.Point(57, 38);
            this.lblTituloForm.Name = "lblTituloForm";
            this.lblTituloForm.Size = new System.Drawing.Size(141, 25);
            this.lblTituloForm.TabIndex = 173;
            this.lblTituloForm.Text = "Planes de pago";
            // 
            // imgServicios_Unicos
            // 
            this.imgServicios_Unicos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.imgServicios_Unicos.Image = global::CapaPresentacion.Properties.Resources.Left_Arrow_32;
            this.imgServicios_Unicos.Location = new System.Drawing.Point(19, 31);
            this.imgServicios_Unicos.Name = "imgServicios_Unicos";
            this.imgServicios_Unicos.Size = new System.Drawing.Size(32, 32);
            this.imgServicios_Unicos.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgServicios_Unicos.TabIndex = 173;
            this.imgServicios_Unicos.TabStop = false;
            this.imgServicios_Unicos.Click += new System.EventHandler(this.imgServicios_Unicos_Click);
            // 
            // lblComprobantesSeleccionados
            // 
            this.lblComprobantesSeleccionados.AutoSize = true;
            this.lblComprobantesSeleccionados.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblComprobantesSeleccionados.Location = new System.Drawing.Point(8, 147);
            this.lblComprobantesSeleccionados.Name = "lblComprobantesSeleccionados";
            this.lblComprobantesSeleccionados.Size = new System.Drawing.Size(369, 21);
            this.lblComprobantesSeleccionados.TabIndex = 333;
            this.lblComprobantesSeleccionados.Text = "Comprobantes de deuda seleccionados para el plan:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Silver;
            this.panel1.Location = new System.Drawing.Point(-1, 143);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1141, 1);
            this.panel1.TabIndex = 334;
            // 
            // lblDefinicionPlanDePago
            // 
            this.lblDefinicionPlanDePago.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblDefinicionPlanDePago.AutoSize = true;
            this.lblDefinicionPlanDePago.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblDefinicionPlanDePago.Location = new System.Drawing.Point(9, 368);
            this.lblDefinicionPlanDePago.Name = "lblDefinicionPlanDePago";
            this.lblDefinicionPlanDePago.Size = new System.Drawing.Size(154, 21);
            this.lblDefinicionPlanDePago.TabIndex = 336;
            this.lblDefinicionPlanDePago.Text = "Definir plan de pago:";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Silver;
            this.panel3.Location = new System.Drawing.Point(-1, 364);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1141, 1);
            this.panel3.TabIndex = 335;
            // 
            // lblAnticipo
            // 
            this.lblAnticipo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblAnticipo.AutoSize = true;
            this.lblAnticipo.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblAnticipo.Location = new System.Drawing.Point(8, 420);
            this.lblAnticipo.Name = "lblAnticipo";
            this.lblAnticipo.Size = new System.Drawing.Size(83, 21);
            this.lblAnticipo.TabIndex = 338;
            this.lblAnticipo.Text = "Anticipo: $";
            // 
            // lblMontoRestante
            // 
            this.lblMontoRestante.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblMontoRestante.AutoSize = true;
            this.lblMontoRestante.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblMontoRestante.Location = new System.Drawing.Point(8, 461);
            this.lblMontoRestante.Name = "lblMontoRestante";
            this.lblMontoRestante.Size = new System.Drawing.Size(119, 21);
            this.lblMontoRestante.TabIndex = 340;
            this.lblMontoRestante.Text = "Monto restante:";
            // 
            // lblRecargo
            // 
            this.lblRecargo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblRecargo.AutoSize = true;
            this.lblRecargo.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblRecargo.Location = new System.Drawing.Point(9, 497);
            this.lblRecargo.Name = "lblRecargo";
            this.lblRecargo.Size = new System.Drawing.Size(70, 21);
            this.lblRecargo.TabIndex = 342;
            this.lblRecargo.Text = "Recargo:";
            // 
            // lblMontoRecargo
            // 
            this.lblMontoRecargo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblMontoRecargo.AutoSize = true;
            this.lblMontoRecargo.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMontoRecargo.Location = new System.Drawing.Point(8, 541);
            this.lblMontoRecargo.Name = "lblMontoRecargo";
            this.lblMontoRecargo.Size = new System.Drawing.Size(269, 25);
            this.lblMontoRecargo.TabIndex = 344;
            this.lblMontoRecargo.Text = "Monto final a pagar en cuotas:";
            // 
            // lblPorcentaje
            // 
            this.lblPorcentaje.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblPorcentaje.AutoSize = true;
            this.lblPorcentaje.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblPorcentaje.Location = new System.Drawing.Point(196, 497);
            this.lblPorcentaje.Name = "lblPorcentaje";
            this.lblPorcentaje.Size = new System.Drawing.Size(23, 21);
            this.lblPorcentaje.TabIndex = 347;
            this.lblPorcentaje.Text = "%";
            // 
            // lblCantidadCuotas
            // 
            this.lblCantidadCuotas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCantidadCuotas.AutoSize = true;
            this.lblCantidadCuotas.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblCantidadCuotas.Location = new System.Drawing.Point(457, 383);
            this.lblCantidadCuotas.Name = "lblCantidadCuotas";
            this.lblCantidadCuotas.Size = new System.Drawing.Size(145, 21);
            this.lblCantidadCuotas.TabIndex = 348;
            this.lblCantidadCuotas.Text = "Cantidad de cuotas:";
            // 
            // lblFechaComienzoPlanPago
            // 
            this.lblFechaComienzoPlanPago.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFechaComienzoPlanPago.AutoSize = true;
            this.lblFechaComienzoPlanPago.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblFechaComienzoPlanPago.Location = new System.Drawing.Point(733, 383);
            this.lblFechaComienzoPlanPago.Name = "lblFechaComienzoPlanPago";
            this.lblFechaComienzoPlanPago.Size = new System.Drawing.Size(99, 21);
            this.lblFechaComienzoPlanPago.TabIndex = 350;
            this.lblFechaComienzoPlanPago.Text = "Primer pago:";
            // 
            // dpFechaComienzoPago
            // 
            this.dpFechaComienzoPago.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dpFechaComienzoPago.CalendarForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(84)))), ((int)(((byte)(101)))));
            this.dpFechaComienzoPago.CalendarTitleForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(84)))), ((int)(((byte)(101)))));
            this.dpFechaComienzoPago.CustomFormat = "";
            this.dpFechaComienzoPago.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.dpFechaComienzoPago.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dpFechaComienzoPago.Location = new System.Drawing.Point(838, 380);
            this.dpFechaComienzoPago.Name = "dpFechaComienzoPago";
            this.dpFechaComienzoPago.Size = new System.Drawing.Size(109, 29);
            this.dpFechaComienzoPago.TabIndex = 3;
            // 
            // spCantidadCuotas
            // 
            this.spCantidadCuotas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.spCantidadCuotas.BorderColor = System.Drawing.Color.Empty;
            this.spCantidadCuotas.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.spCantidadCuotas.Location = new System.Drawing.Point(605, 380);
            this.spCantidadCuotas.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.spCantidadCuotas.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spCantidadCuotas.Name = "spCantidadCuotas";
            this.spCantidadCuotas.Size = new System.Drawing.Size(78, 29);
            this.spCantidadCuotas.TabIndex = 2;
            this.spCantidadCuotas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.spCantidadCuotas.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // pgCircular
            // 
            this.pgCircular.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pgCircular.Location = new System.Drawing.Point(1054, 568);
            this.pgCircular.Name = "pgCircular";
            this.pgCircular.Percentage = 0F;
            this.pgCircular.Rotation = CapaPresentacion.Controles.RotationType.CounterClockwise;
            this.pgCircular.Size = new System.Drawing.Size(24, 24);
            this.pgCircular.TabIndex = 346;
            // 
            // btnVistaPrevia
            // 
            this.btnVistaPrevia.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnVistaPrevia.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnVistaPrevia.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVistaPrevia.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnVistaPrevia.FlatAppearance.BorderSize = 0;
            this.btnVistaPrevia.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnVistaPrevia.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnVistaPrevia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVistaPrevia.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVistaPrevia.ForeColor = System.Drawing.Color.White;
            this.btnVistaPrevia.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnVistaPrevia.Location = new System.Drawing.Point(953, 380);
            this.btnVistaPrevia.Name = "btnVistaPrevia";
            this.btnVistaPrevia.Size = new System.Drawing.Size(123, 32);
            this.btnVistaPrevia.TabIndex = 4;
            this.btnVistaPrevia.Text = "Generar cuotas";
            this.btnVistaPrevia.UseVisualStyleBackColor = false;
            this.btnVistaPrevia.Click += new System.EventHandler(this.btnVistaPrevia_Click);
            // 
            // spRecargo
            // 
            this.spRecargo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.spRecargo.BorderColor = System.Drawing.Color.Empty;
            this.spRecargo.DecimalPlaces = 2;
            this.spRecargo.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.spRecargo.Location = new System.Drawing.Point(98, 495);
            this.spRecargo.Name = "spRecargo";
            this.spRecargo.Size = new System.Drawing.Size(99, 29);
            this.spRecargo.TabIndex = 1;
            this.spRecargo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.spRecargo.ValueChanged += new System.EventHandler(this.spRecargo_ValueChanged);
            // 
            // dgvComprobantesPlanDePago
            // 
            this.dgvComprobantesPlanDePago.AllowUserToAddRows = false;
            this.dgvComprobantesPlanDePago.AllowUserToDeleteRows = false;
            this.dgvComprobantesPlanDePago.AllowUserToOrderColumns = true;
            this.dgvComprobantesPlanDePago.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvComprobantesPlanDePago.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvComprobantesPlanDePago.BackgroundColor = System.Drawing.Color.White;
            this.dgvComprobantesPlanDePago.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvComprobantesPlanDePago.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSlateGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvComprobantesPlanDePago.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvComprobantesPlanDePago.ColumnHeadersHeight = 40;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvComprobantesPlanDePago.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvComprobantesPlanDePago.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.dgvComprobantesPlanDePago.EnableHeadersVisualStyles = false;
            this.dgvComprobantesPlanDePago.GridColor = System.Drawing.Color.WhiteSmoke;
            this.dgvComprobantesPlanDePago.Location = new System.Drawing.Point(461, 420);
            this.dgvComprobantesPlanDePago.MultiSelect = false;
            this.dgvComprobantesPlanDePago.Name = "dgvComprobantesPlanDePago";
            this.dgvComprobantesPlanDePago.ReadOnly = true;
            this.dgvComprobantesPlanDePago.RowHeadersVisible = false;
            this.dgvComprobantesPlanDePago.RowHeadersWidth = 50;
            this.dgvComprobantesPlanDePago.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvComprobantesPlanDePago.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvComprobantesPlanDePago.Size = new System.Drawing.Size(617, 142);
            this.dgvComprobantesPlanDePago.TabIndex = 341;
            // 
            // spAnticipo
            // 
            this.spAnticipo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.spAnticipo.BorderColor = System.Drawing.Color.Empty;
            this.spAnticipo.DecimalPlaces = 2;
            this.spAnticipo.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.spAnticipo.Location = new System.Drawing.Point(98, 418);
            this.spAnticipo.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.spAnticipo.Name = "spAnticipo";
            this.spAnticipo.Size = new System.Drawing.Size(99, 29);
            this.spAnticipo.TabIndex = 0;
            this.spAnticipo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.spAnticipo.ValueChanged += new System.EventHandler(this.spValor_ValueChanged);
            // 
            // btnGenerarComprobantes
            // 
            this.btnGenerarComprobantes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGenerarComprobantes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnGenerarComprobantes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGenerarComprobantes.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnGenerarComprobantes.FlatAppearance.BorderSize = 0;
            this.btnGenerarComprobantes.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnGenerarComprobantes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnGenerarComprobantes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerarComprobantes.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnGenerarComprobantes.ForeColor = System.Drawing.Color.White;
            this.btnGenerarComprobantes.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGenerarComprobantes.Location = new System.Drawing.Point(892, 102);
            this.btnGenerarComprobantes.Name = "btnGenerarComprobantes";
            this.btnGenerarComprobantes.Size = new System.Drawing.Size(184, 33);
            this.btnGenerarComprobantes.TabIndex = 5;
            this.btnGenerarComprobantes.Text = "Generar comprobantes";
            this.btnGenerarComprobantes.UseVisualStyleBackColor = false;
            this.btnGenerarComprobantes.Click += new System.EventHandler(this.btnAsignarItem_Click);
            // 
            // dgvComprobantesAdeudados
            // 
            this.dgvComprobantesAdeudados.AllowUserToAddRows = false;
            this.dgvComprobantesAdeudados.AllowUserToDeleteRows = false;
            this.dgvComprobantesAdeudados.AllowUserToOrderColumns = true;
            this.dgvComprobantesAdeudados.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvComprobantesAdeudados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvComprobantesAdeudados.BackgroundColor = System.Drawing.Color.White;
            this.dgvComprobantesAdeudados.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvComprobantesAdeudados.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.LightSlateGray;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvComprobantesAdeudados.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvComprobantesAdeudados.ColumnHeadersHeight = 40;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvComprobantesAdeudados.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvComprobantesAdeudados.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.dgvComprobantesAdeudados.EnableHeadersVisualStyles = false;
            this.dgvComprobantesAdeudados.GridColor = System.Drawing.Color.WhiteSmoke;
            this.dgvComprobantesAdeudados.Location = new System.Drawing.Point(12, 171);
            this.dgvComprobantesAdeudados.MultiSelect = false;
            this.dgvComprobantesAdeudados.Name = "dgvComprobantesAdeudados";
            this.dgvComprobantesAdeudados.ReadOnly = true;
            this.dgvComprobantesAdeudados.RowHeadersVisible = false;
            this.dgvComprobantesAdeudados.RowHeadersWidth = 50;
            this.dgvComprobantesAdeudados.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvComprobantesAdeudados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvComprobantesAdeudados.Size = new System.Drawing.Size(1064, 166);
            this.dgvComprobantesAdeudados.TabIndex = 332;
            this.dgvComprobantesAdeudados.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvComprobantesAdeudados_CellContentClick);
            // 
            // lblMontoTotalOriginal
            // 
            this.lblMontoTotalOriginal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMontoTotalOriginal.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblMontoTotalOriginal.Location = new System.Drawing.Point(793, 340);
            this.lblMontoTotalOriginal.Name = "lblMontoTotalOriginal";
            this.lblMontoTotalOriginal.Size = new System.Drawing.Size(283, 21);
            this.lblMontoTotalOriginal.TabIndex = 351;
            this.lblMontoTotalOriginal.Text = "Monto total original:";
            this.lblMontoTotalOriginal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frmCtaCtePlanesDePago
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(250)))), ((int)(((byte)(251)))));
            this.ClientSize = new System.Drawing.Size(1088, 594);
            this.Controls.Add(this.lblMontoTotalOriginal);
            this.Controls.Add(this.dpFechaComienzoPago);
            this.Controls.Add(this.lblFechaComienzoPlanPago);
            this.Controls.Add(this.spCantidadCuotas);
            this.Controls.Add(this.lblCantidadCuotas);
            this.Controls.Add(this.lblPorcentaje);
            this.Controls.Add(this.pgCircular);
            this.Controls.Add(this.btnVistaPrevia);
            this.Controls.Add(this.lblMontoRecargo);
            this.Controls.Add(this.spRecargo);
            this.Controls.Add(this.lblRecargo);
            this.Controls.Add(this.dgvComprobantesPlanDePago);
            this.Controls.Add(this.lblMontoRestante);
            this.Controls.Add(this.spAnticipo);
            this.Controls.Add(this.lblAnticipo);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.lblDefinicionPlanDePago);
            this.Controls.Add(this.btnGenerarComprobantes);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblComprobantesSeleccionados);
            this.Controls.Add(this.dgvComprobantesAdeudados);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "frmCtaCtePlanesDePago";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmCtaCtePlanesDePago";
            this.Load += new System.EventHandler(this.frmCtaCtePlanesDePago_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmCtaCtePlanesDePago_KeyDown);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgServicios_Unicos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spCantidadCuotas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spRecargo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvComprobantesPlanDePago)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spAnticipo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvComprobantesAdeudados)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblTituloForm;
        private System.Windows.Forms.PictureBox imgServicios_Unicos;
        private Controles.dgv dgvComprobantesAdeudados;
        private System.Windows.Forms.Label lblComprobantesSeleccionados;
        private System.Windows.Forms.Panel panel1;
        private Controles.boton btnGenerarComprobantes;
        private System.Windows.Forms.Label lblDefinicionPlanDePago;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblAnticipo;
        private Controles.spinner spAnticipo;
        private System.Windows.Forms.Label lblMontoRestante;
        private Controles.dgv dgvComprobantesPlanDePago;
        private System.Windows.Forms.Label lblRecargo;
        private Controles.spinner spRecargo;
        private System.Windows.Forms.Label lblMontoRecargo;
        private Controles.boton btnVistaPrevia;
        private Controles.progress pgCircular;
        private System.Windows.Forms.Label lblPorcentaje;
        private System.Windows.Forms.Label lblCantidadCuotas;
        private Controles.spinner spCantidadCuotas;
        private System.Windows.Forms.Label lblFechaComienzoPlanPago;
        private System.Windows.Forms.DateTimePicker dpFechaComienzoPago;
        private System.Windows.Forms.Label lblLocacion;
        private System.Windows.Forms.Label lbcorreo;
        private System.Windows.Forms.Label lbcuit;
        private System.Windows.Forms.Label LBNumero_documento;
        private System.Windows.Forms.Label LBApellido;
        private System.Windows.Forms.Label lblMontoTotalOriginal;
    }
}