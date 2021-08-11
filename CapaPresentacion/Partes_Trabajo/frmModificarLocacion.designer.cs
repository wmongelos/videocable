namespace CapaPresentacion.Partes_Trabajo
{
    partial class frmModificarLocacion
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblLocalidad = new System.Windows.Forms.Label();
            this.lblYCalle = new System.Windows.Forms.Label();
            this.lblEntreCalle = new System.Windows.Forms.Label();
            this.lblParcela = new System.Windows.Forms.Label();
            this.lblCodigoPostal = new System.Windows.Forms.Label();
            this.lblDepto = new System.Windows.Forms.Label();
            this.lblPiso = new System.Windows.Forms.Label();
            this.lblAltura = new System.Windows.Forms.Label();
            this.lblCalle = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblLocacion = new System.Windows.Forms.Label();
            this.lbcorreo = new System.Windows.Forms.Label();
            this.lbcuit = new System.Windows.Forms.Label();
            this.LBNumero_documento = new System.Windows.Forms.Label();
            this.LBApellido = new System.Windows.Forms.Label();
            this.imgReturn = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pnFooter = new System.Windows.Forms.Panel();
            this.lblTotal = new System.Windows.Forms.Label();
            this.pgCircular = new CapaPresentacion.Controles.progress();
            this.lblLocacionActual = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.lblServiciosAsociados = new System.Windows.Forms.Label();
            this.dgvServicios = new System.Windows.Forms.DataGridView();
            this.lblLocacionNueva = new System.Windows.Forms.Label();
            this.btnBuscarLocacion = new CapaPresentacion.Controles.boton();
            this.btnLocacionNueva = new CapaPresentacion.Controles.boton();
            this.txtEntreCalle2 = new CapaPresentacion.textboxAdv();
            this.txtEntreCalle1 = new CapaPresentacion.textboxAdv();
            this.btnCancelar = new CapaPresentacion.Controles.boton();
            this.btnGuardarLocacion = new CapaPresentacion.Controles.boton();
            this.txtDeptoServicio = new CapaPresentacion.textboxAdv();
            this.txtPisoServicio = new CapaPresentacion.textboxAdv();
            this.txtParcelaServicio = new CapaPresentacion.textboxAdv();
            this.txtCalle = new CapaPresentacion.textboxAdv();
            this.txtCPServicio = new CapaPresentacion.textboxAdv();
            this.cboLocalidades = new CapaPresentacion.Controles.combo(this.components);
            this.btnBuscarcalle = new CapaPresentacion.Controles.boton();
            this.spAltura = new CapaPresentacion.Controles.spinner(this.components);
            this.lblMonto = new System.Windows.Forms.Label();
            this.chkTraspasoPartes = new System.Windows.Forms.CheckBox();
            this.chkTraspasoCtaCte = new System.Windows.Forms.CheckBox();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgReturn)).BeginInit();
            this.pnFooter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvServicios)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spAltura)).BeginInit();
            this.SuspendLayout();
            // 
            // lblLocalidad
            // 
            this.lblLocalidad.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLocalidad.AutoSize = true;
            this.lblLocalidad.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblLocalidad.ForeColor = System.Drawing.Color.Black;
            this.lblLocalidad.Location = new System.Drawing.Point(15, 234);
            this.lblLocalidad.Name = "lblLocalidad";
            this.lblLocalidad.Size = new System.Drawing.Size(79, 21);
            this.lblLocalidad.TabIndex = 158;
            this.lblLocalidad.Text = "Localidad:";
            // 
            // lblYCalle
            // 
            this.lblYCalle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblYCalle.AutoSize = true;
            this.lblYCalle.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblYCalle.ForeColor = System.Drawing.Color.Black;
            this.lblYCalle.Location = new System.Drawing.Point(678, 267);
            this.lblYCalle.Name = "lblYCalle";
            this.lblYCalle.Size = new System.Drawing.Size(60, 21);
            this.lblYCalle.TabIndex = 154;
            this.lblYCalle.Text = "Y Calle:";
            // 
            // lblEntreCalle
            // 
            this.lblEntreCalle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblEntreCalle.AutoSize = true;
            this.lblEntreCalle.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblEntreCalle.ForeColor = System.Drawing.Color.Black;
            this.lblEntreCalle.Location = new System.Drawing.Point(651, 234);
            this.lblEntreCalle.Name = "lblEntreCalle";
            this.lblEntreCalle.Size = new System.Drawing.Size(87, 21);
            this.lblEntreCalle.TabIndex = 153;
            this.lblEntreCalle.Text = "Entre Calle:";
            // 
            // lblParcela
            // 
            this.lblParcela.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblParcela.AutoSize = true;
            this.lblParcela.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblParcela.ForeColor = System.Drawing.Color.Black;
            this.lblParcela.Location = new System.Drawing.Point(226, 305);
            this.lblParcela.Name = "lblParcela";
            this.lblParcela.Size = new System.Drawing.Size(62, 21);
            this.lblParcela.TabIndex = 152;
            this.lblParcela.Text = "Parcela:";
            // 
            // lblCodigoPostal
            // 
            this.lblCodigoPostal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCodigoPostal.AutoSize = true;
            this.lblCodigoPostal.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblCodigoPostal.ForeColor = System.Drawing.Color.Black;
            this.lblCodigoPostal.Location = new System.Drawing.Point(629, 304);
            this.lblCodigoPostal.Name = "lblCodigoPostal";
            this.lblCodigoPostal.Size = new System.Drawing.Size(108, 21);
            this.lblCodigoPostal.TabIndex = 150;
            this.lblCodigoPostal.Text = "Codigo Postal:";
            // 
            // lblDepto
            // 
            this.lblDepto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDepto.AutoSize = true;
            this.lblDepto.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblDepto.ForeColor = System.Drawing.Color.Black;
            this.lblDepto.Location = new System.Drawing.Point(467, 305);
            this.lblDepto.Name = "lblDepto";
            this.lblDepto.Size = new System.Drawing.Size(55, 21);
            this.lblDepto.TabIndex = 149;
            this.lblDepto.Text = "Depto:";
            // 
            // lblPiso
            // 
            this.lblPiso.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPiso.AutoSize = true;
            this.lblPiso.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblPiso.ForeColor = System.Drawing.Color.Black;
            this.lblPiso.Location = new System.Drawing.Point(357, 305);
            this.lblPiso.Name = "lblPiso";
            this.lblPiso.Size = new System.Drawing.Size(42, 21);
            this.lblPiso.TabIndex = 148;
            this.lblPiso.Text = "Piso:";
            // 
            // lblAltura
            // 
            this.lblAltura.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAltura.AutoSize = true;
            this.lblAltura.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblAltura.ForeColor = System.Drawing.Color.Black;
            this.lblAltura.Location = new System.Drawing.Point(39, 303);
            this.lblAltura.Name = "lblAltura";
            this.lblAltura.Size = new System.Drawing.Size(55, 21);
            this.lblAltura.TabIndex = 142;
            this.lblAltura.Text = "Altura:";
            // 
            // lblCalle
            // 
            this.lblCalle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCalle.AutoSize = true;
            this.lblCalle.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblCalle.ForeColor = System.Drawing.Color.Black;
            this.lblCalle.Location = new System.Drawing.Point(47, 266);
            this.lblCalle.Name = "lblCalle";
            this.lblCalle.Size = new System.Drawing.Size(47, 21);
            this.lblCalle.TabIndex = 140;
            this.lblCalle.Text = "Calle:";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.Silver;
            this.panel1.Location = new System.Drawing.Point(0, 152);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1095, 1);
            this.panel1.TabIndex = 162;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackColor = System.Drawing.Color.Silver;
            this.panel3.Location = new System.Drawing.Point(1, 338);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1095, 1);
            this.panel3.TabIndex = 163;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.panel2.Controls.Add(this.lblLocacion);
            this.panel2.Controls.Add(this.lbcorreo);
            this.panel2.Controls.Add(this.lbcuit);
            this.panel2.Controls.Add(this.LBNumero_documento);
            this.panel2.Controls.Add(this.LBApellido);
            this.panel2.Controls.Add(this.imgReturn);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1074, 105);
            this.panel2.TabIndex = 185;
            // 
            // lblLocacion
            // 
            this.lblLocacion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLocacion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.lblLocacion.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblLocacion.ForeColor = System.Drawing.Color.White;
            this.lblLocacion.Location = new System.Drawing.Point(768, 41);
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
            this.lbcorreo.Location = new System.Drawing.Point(655, 72);
            this.lbcorreo.Name = "lbcorreo";
            this.lbcorreo.Size = new System.Drawing.Size(414, 22);
            this.lbcorreo.TabIndex = 214;
            this.lbcorreo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbcuit
            // 
            this.lbcuit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbcuit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.lbcuit.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lbcuit.ForeColor = System.Drawing.Color.White;
            this.lbcuit.Location = new System.Drawing.Point(520, 41);
            this.lbcuit.Name = "lbcuit";
            this.lbcuit.Size = new System.Drawing.Size(235, 23);
            this.lbcuit.TabIndex = 213;
            this.lbcuit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LBNumero_documento
            // 
            this.LBNumero_documento.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LBNumero_documento.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.LBNumero_documento.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.LBNumero_documento.ForeColor = System.Drawing.Color.White;
            this.LBNumero_documento.Location = new System.Drawing.Point(519, 7);
            this.LBNumero_documento.Name = "LBNumero_documento";
            this.LBNumero_documento.Size = new System.Drawing.Size(289, 23);
            this.LBNumero_documento.TabIndex = 212;
            this.LBNumero_documento.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LBApellido
            // 
            this.LBApellido.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LBApellido.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.LBApellido.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.LBApellido.ForeColor = System.Drawing.Color.White;
            this.LBApellido.Location = new System.Drawing.Point(814, 7);
            this.LBApellido.Name = "LBApellido";
            this.LBApellido.Size = new System.Drawing.Size(255, 23);
            this.LBApellido.TabIndex = 211;
            this.LBApellido.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // imgReturn
            // 
            this.imgReturn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.imgReturn.Image = global::CapaPresentacion.Properties.Resources.Left_Arrow_32;
            this.imgReturn.Location = new System.Drawing.Point(16, 32);
            this.imgReturn.Name = "imgReturn";
            this.imgReturn.Size = new System.Drawing.Size(32, 32);
            this.imgReturn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgReturn.TabIndex = 32;
            this.imgReturn.TabStop = false;
            this.imgReturn.Click += new System.EventHandler(this.imgReturn_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI Light", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(54, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(338, 23);
            this.label1.TabIndex = 31;
            this.label1.Text = "Cambio de domicilio";
            // 
            // pnFooter
            // 
            this.pnFooter.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnFooter.Controls.Add(this.lblTotal);
            this.pnFooter.Controls.Add(this.pgCircular);
            this.pnFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnFooter.Location = new System.Drawing.Point(0, 596);
            this.pnFooter.Name = "pnFooter";
            this.pnFooter.Size = new System.Drawing.Size(1074, 30);
            this.pnFooter.TabIndex = 186;
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
            // pgCircular
            // 
            this.pgCircular.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pgCircular.Location = new System.Drawing.Point(1038, 2);
            this.pgCircular.Name = "pgCircular";
            this.pgCircular.Percentage = 0F;
            this.pgCircular.Rotation = CapaPresentacion.Controles.RotationType.CounterClockwise;
            this.pgCircular.Size = new System.Drawing.Size(24, 24);
            this.pgCircular.TabIndex = 0;
            // 
            // lblLocacionActual
            // 
            this.lblLocacionActual.AutoSize = true;
            this.lblLocacionActual.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblLocacionActual.ForeColor = System.Drawing.Color.Black;
            this.lblLocacionActual.Location = new System.Drawing.Point(11, 156);
            this.lblLocacionActual.Name = "lblLocacionActual";
            this.lblLocacionActual.Size = new System.Drawing.Size(148, 21);
            this.lblLocacionActual.TabIndex = 199;
            this.lblLocacionActual.Text = "Locación de origen: ";
            // 
            // panel5
            // 
            this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel5.BackColor = System.Drawing.Color.Silver;
            this.panel5.Location = new System.Drawing.Point(1, 180);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1095, 1);
            this.panel5.TabIndex = 163;
            // 
            // lblServiciosAsociados
            // 
            this.lblServiciosAsociados.AutoSize = true;
            this.lblServiciosAsociados.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblServiciosAsociados.ForeColor = System.Drawing.Color.Black;
            this.lblServiciosAsociados.Location = new System.Drawing.Point(13, 351);
            this.lblServiciosAsociados.Name = "lblServiciosAsociados";
            this.lblServiciosAsociados.Size = new System.Drawing.Size(693, 21);
            this.lblServiciosAsociados.TabIndex = 201;
            this.lblServiciosAsociados.Text = "Seleccione aquellos servicios de la locación de origen que quiere trasladar a la " +
    "localidad de destino:";
            // 
            // dgvServicios
            // 
            this.dgvServicios.AllowUserToAddRows = false;
            this.dgvServicios.AllowUserToDeleteRows = false;
            this.dgvServicios.AllowUserToOrderColumns = true;
            this.dgvServicios.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvServicios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvServicios.BackgroundColor = System.Drawing.Color.White;
            this.dgvServicios.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvServicios.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.LightSlateGray;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvServicios.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvServicios.ColumnHeadersHeight = 40;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvServicios.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvServicios.EnableHeadersVisualStyles = false;
            this.dgvServicios.GridColor = System.Drawing.Color.WhiteSmoke;
            this.dgvServicios.Location = new System.Drawing.Point(16, 375);
            this.dgvServicios.Name = "dgvServicios";
            this.dgvServicios.RowHeadersVisible = false;
            this.dgvServicios.RowHeadersWidth = 50;
            this.dgvServicios.Size = new System.Drawing.Size(1046, 184);
            this.dgvServicios.TabIndex = 8;
            this.dgvServicios.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvServicios_CellContentClick);
            this.dgvServicios.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvServicios_CellEndEdit);
            this.dgvServicios.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvServicios_CellValueChanged);
            // 
            // lblLocacionNueva
            // 
            this.lblLocacionNueva.AutoSize = true;
            this.lblLocacionNueva.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblLocacionNueva.ForeColor = System.Drawing.Color.Black;
            this.lblLocacionNueva.Location = new System.Drawing.Point(11, 194);
            this.lblLocacionNueva.Name = "lblLocacionNueva";
            this.lblLocacionNueva.Size = new System.Drawing.Size(150, 21);
            this.lblLocacionNueva.TabIndex = 200;
            this.lblLocacionNueva.Text = "Locación de destino:";
            // 
            // btnBuscarLocacion
            // 
            this.btnBuscarLocacion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBuscarLocacion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnBuscarLocacion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscarLocacion.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnBuscarLocacion.FlatAppearance.BorderSize = 0;
            this.btnBuscarLocacion.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnBuscarLocacion.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnBuscarLocacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarLocacion.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscarLocacion.ForeColor = System.Drawing.Color.White;
            this.btnBuscarLocacion.Image = global::CapaPresentacion.Properties.Resources.lupa;
            this.btnBuscarLocacion.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBuscarLocacion.Location = new System.Drawing.Point(896, 187);
            this.btnBuscarLocacion.Name = "btnBuscarLocacion";
            this.btnBuscarLocacion.Size = new System.Drawing.Size(166, 35);
            this.btnBuscarLocacion.TabIndex = 208;
            this.btnBuscarLocacion.Text = "Locacion existente";
            this.btnBuscarLocacion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscarLocacion.UseVisualStyleBackColor = false;
            this.btnBuscarLocacion.Click += new System.EventHandler(this.btnBuscarLocacion_Click);
            // 
            // btnLocacionNueva
            // 
            this.btnLocacionNueva.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLocacionNueva.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnLocacionNueva.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLocacionNueva.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnLocacionNueva.FlatAppearance.BorderSize = 0;
            this.btnLocacionNueva.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnLocacionNueva.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnLocacionNueva.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLocacionNueva.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLocacionNueva.ForeColor = System.Drawing.Color.White;
            this.btnLocacionNueva.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLocacionNueva.Location = new System.Drawing.Point(744, 187);
            this.btnLocacionNueva.Name = "btnLocacionNueva";
            this.btnLocacionNueva.Size = new System.Drawing.Size(146, 35);
            this.btnLocacionNueva.TabIndex = 207;
            this.btnLocacionNueva.Text = "Nueva locacion";
            this.btnLocacionNueva.UseVisualStyleBackColor = false;
            this.btnLocacionNueva.Click += new System.EventHandler(this.btnLocacionNueva_Click);
            // 
            // txtEntreCalle2
            // 
            this.txtEntreCalle2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEntreCalle2.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtEntreCalle2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEntreCalle2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtEntreCalle2.Enabled = false;
            this.txtEntreCalle2.FocusColor = System.Drawing.Color.Empty;
            this.txtEntreCalle2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEntreCalle2.ForeColor = System.Drawing.Color.DimGray;
            this.txtEntreCalle2.Location = new System.Drawing.Point(744, 267);
            this.txtEntreCalle2.Name = "txtEntreCalle2";
            this.txtEntreCalle2.Numerico = false;
            this.txtEntreCalle2.Size = new System.Drawing.Size(318, 29);
            this.txtEntreCalle2.TabIndex = 7;
            this.txtEntreCalle2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtEntreCalle1
            // 
            this.txtEntreCalle1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEntreCalle1.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtEntreCalle1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEntreCalle1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtEntreCalle1.Enabled = false;
            this.txtEntreCalle1.FocusColor = System.Drawing.Color.Empty;
            this.txtEntreCalle1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEntreCalle1.ForeColor = System.Drawing.Color.DimGray;
            this.txtEntreCalle1.Location = new System.Drawing.Point(744, 232);
            this.txtEntreCalle1.Name = "txtEntreCalle1";
            this.txtEntreCalle1.Numerico = false;
            this.txtEntreCalle1.Size = new System.Drawing.Size(318, 29);
            this.txtEntreCalle1.TabIndex = 6;
            this.txtEntreCalle1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
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
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Image = global::CapaPresentacion.Properties.Resources.Command_Redo_32;
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.Location = new System.Drawing.Point(962, 111);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(100, 35);
            this.btnCancelar.TabIndex = 10;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click_1);
            // 
            // btnGuardarLocacion
            // 
            this.btnGuardarLocacion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGuardarLocacion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnGuardarLocacion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardarLocacion.Enabled = false;
            this.btnGuardarLocacion.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnGuardarLocacion.FlatAppearance.BorderSize = 0;
            this.btnGuardarLocacion.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnGuardarLocacion.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnGuardarLocacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardarLocacion.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardarLocacion.ForeColor = System.Drawing.Color.White;
            this.btnGuardarLocacion.Image = global::CapaPresentacion.Properties.Resources.Save_32;
            this.btnGuardarLocacion.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGuardarLocacion.Location = new System.Drawing.Point(856, 111);
            this.btnGuardarLocacion.Name = "btnGuardarLocacion";
            this.btnGuardarLocacion.Size = new System.Drawing.Size(100, 35);
            this.btnGuardarLocacion.TabIndex = 9;
            this.btnGuardarLocacion.Text = "Guardar";
            this.btnGuardarLocacion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuardarLocacion.UseVisualStyleBackColor = false;
            this.btnGuardarLocacion.Click += new System.EventHandler(this.btnGuardarLocacion_Click);
            // 
            // txtDeptoServicio
            // 
            this.txtDeptoServicio.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtDeptoServicio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDeptoServicio.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDeptoServicio.FocusColor = System.Drawing.Color.Empty;
            this.txtDeptoServicio.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDeptoServicio.ForeColor = System.Drawing.Color.DimGray;
            this.txtDeptoServicio.Location = new System.Drawing.Point(528, 303);
            this.txtDeptoServicio.Name = "txtDeptoServicio";
            this.txtDeptoServicio.Numerico = false;
            this.txtDeptoServicio.Size = new System.Drawing.Size(56, 29);
            this.txtDeptoServicio.TabIndex = 5;
            this.txtDeptoServicio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtDeptoServicio.TextChanged += new System.EventHandler(this.txtDeptoServicio_TextChanged);
            // 
            // txtPisoServicio
            // 
            this.txtPisoServicio.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtPisoServicio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPisoServicio.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPisoServicio.FocusColor = System.Drawing.Color.Empty;
            this.txtPisoServicio.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPisoServicio.ForeColor = System.Drawing.Color.DimGray;
            this.txtPisoServicio.Location = new System.Drawing.Point(405, 302);
            this.txtPisoServicio.Name = "txtPisoServicio";
            this.txtPisoServicio.Numerico = false;
            this.txtPisoServicio.Size = new System.Drawing.Size(56, 29);
            this.txtPisoServicio.TabIndex = 4;
            this.txtPisoServicio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPisoServicio.TextChanged += new System.EventHandler(this.txtPisoServicio_TextChanged);
            // 
            // txtParcelaServicio
            // 
            this.txtParcelaServicio.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtParcelaServicio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtParcelaServicio.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtParcelaServicio.FocusColor = System.Drawing.Color.Empty;
            this.txtParcelaServicio.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtParcelaServicio.ForeColor = System.Drawing.Color.DimGray;
            this.txtParcelaServicio.Location = new System.Drawing.Point(295, 302);
            this.txtParcelaServicio.Name = "txtParcelaServicio";
            this.txtParcelaServicio.Numerico = false;
            this.txtParcelaServicio.Size = new System.Drawing.Size(56, 29);
            this.txtParcelaServicio.TabIndex = 3;
            this.txtParcelaServicio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtParcelaServicio.TextChanged += new System.EventHandler(this.txtParcelaServicio_TextChanged);
            // 
            // txtCalle
            // 
            this.txtCalle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCalle.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtCalle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCalle.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCalle.Enabled = false;
            this.txtCalle.FocusColor = System.Drawing.Color.Empty;
            this.txtCalle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCalle.ForeColor = System.Drawing.Color.DimGray;
            this.txtCalle.Location = new System.Drawing.Point(100, 266);
            this.txtCalle.Name = "txtCalle";
            this.txtCalle.Numerico = false;
            this.txtCalle.Size = new System.Drawing.Size(443, 29);
            this.txtCalle.TabIndex = 1;
            this.txtCalle.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCalle.TextChanged += new System.EventHandler(this.txtCalle_TextChanged);
            // 
            // txtCPServicio
            // 
            this.txtCPServicio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCPServicio.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtCPServicio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCPServicio.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCPServicio.Enabled = false;
            this.txtCPServicio.FocusColor = System.Drawing.Color.Empty;
            this.txtCPServicio.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCPServicio.ForeColor = System.Drawing.Color.DimGray;
            this.txtCPServicio.Location = new System.Drawing.Point(744, 302);
            this.txtCPServicio.Name = "txtCPServicio";
            this.txtCPServicio.Numerico = false;
            this.txtCPServicio.Size = new System.Drawing.Size(88, 29);
            this.txtCPServicio.TabIndex = 192;
            this.txtCPServicio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cboLocalidades
            // 
            this.cboLocalidades.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboLocalidades.BorderColor = System.Drawing.Color.Gainsboro;
            this.cboLocalidades.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLocalidades.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboLocalidades.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboLocalidades.FormattingEnabled = true;
            this.cboLocalidades.Location = new System.Drawing.Point(100, 231);
            this.cboLocalidades.Name = "cboLocalidades";
            this.cboLocalidades.Size = new System.Drawing.Size(484, 29);
            this.cboLocalidades.TabIndex = 0;
            this.cboLocalidades.SelectedIndexChanged += new System.EventHandler(this.cboLocalidades_SelectedIndexChanged);
            // 
            // btnBuscarcalle
            // 
            this.btnBuscarcalle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBuscarcalle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnBuscarcalle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscarcalle.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnBuscarcalle.FlatAppearance.BorderSize = 0;
            this.btnBuscarcalle.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnBuscarcalle.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnBuscarcalle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarcalle.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscarcalle.ForeColor = System.Drawing.Color.White;
            this.btnBuscarcalle.Image = global::CapaPresentacion.Properties.Resources.lupa;
            this.btnBuscarcalle.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBuscarcalle.Location = new System.Drawing.Point(549, 266);
            this.btnBuscarcalle.Name = "btnBuscarcalle";
            this.btnBuscarcalle.Size = new System.Drawing.Size(35, 30);
            this.btnBuscarcalle.TabIndex = 175;
            this.btnBuscarcalle.UseVisualStyleBackColor = false;
            this.btnBuscarcalle.Click += new System.EventHandler(this.btnBuscarcalle_Click);
            // 
            // spAltura
            // 
            this.spAltura.BorderColor = System.Drawing.Color.Empty;
            this.spAltura.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.spAltura.Location = new System.Drawing.Point(100, 301);
            this.spAltura.Name = "spAltura";
            this.spAltura.Size = new System.Drawing.Size(103, 29);
            this.spAltura.TabIndex = 2;
            this.spAltura.ValueChanged += new System.EventHandler(this.spinner1_ValueChanged);
            // 
            // lblMonto
            // 
            this.lblMonto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMonto.AutoSize = true;
            this.lblMonto.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblMonto.ForeColor = System.Drawing.Color.Black;
            this.lblMonto.Location = new System.Drawing.Point(740, 351);
            this.lblMonto.Name = "lblMonto";
            this.lblMonto.Size = new System.Drawing.Size(120, 21);
            this.lblMonto.TabIndex = 209;
            this.lblMonto.Text = "Monto a cobrar:";
            // 
            // chkTraspasoPartes
            // 
            this.chkTraspasoPartes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkTraspasoPartes.AutoSize = true;
            this.chkTraspasoPartes.Enabled = false;
            this.chkTraspasoPartes.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkTraspasoPartes.Location = new System.Drawing.Point(921, 565);
            this.chkTraspasoPartes.Name = "chkTraspasoPartes";
            this.chkTraspasoPartes.Size = new System.Drawing.Size(141, 25);
            this.chkTraspasoPartes.TabIndex = 14;
            this.chkTraspasoPartes.Text = "Tansladar partes";
            this.chkTraspasoPartes.UseVisualStyleBackColor = true;
            // 
            // chkTraspasoCtaCte
            // 
            this.chkTraspasoCtaCte.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkTraspasoCtaCte.AutoSize = true;
            this.chkTraspasoCtaCte.Enabled = false;
            this.chkTraspasoCtaCte.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkTraspasoCtaCte.Location = new System.Drawing.Point(705, 565);
            this.chkTraspasoCtaCte.Name = "chkTraspasoCtaCte";
            this.chkTraspasoCtaCte.Size = new System.Drawing.Size(210, 25);
            this.chkTraspasoCtaCte.TabIndex = 15;
            this.chkTraspasoCtaCte.Text = "Tansladar cuenta corriente";
            this.chkTraspasoCtaCte.UseVisualStyleBackColor = true;
            // 
            // frmModificarLocacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(250)))), ((int)(((byte)(251)))));
            this.ClientSize = new System.Drawing.Size(1074, 626);
            this.Controls.Add(this.chkTraspasoCtaCte);
            this.Controls.Add(this.lblMonto);
            this.Controls.Add(this.chkTraspasoPartes);
            this.Controls.Add(this.btnBuscarLocacion);
            this.Controls.Add(this.btnLocacionNueva);
            this.Controls.Add(this.txtEntreCalle2);
            this.Controls.Add(this.txtEntreCalle1);
            this.Controls.Add(this.dgvServicios);
            this.Controls.Add(this.lblServiciosAsociados);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.lblLocacionNueva);
            this.Controls.Add(this.lblLocacionActual);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardarLocacion);
            this.Controls.Add(this.txtDeptoServicio);
            this.Controls.Add(this.txtPisoServicio);
            this.Controls.Add(this.txtParcelaServicio);
            this.Controls.Add(this.txtCalle);
            this.Controls.Add(this.txtCPServicio);
            this.Controls.Add(this.cboLocalidades);
            this.Controls.Add(this.lblEntreCalle);
            this.Controls.Add(this.lblYCalle);
            this.Controls.Add(this.pnFooter);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btnBuscarcalle);
            this.Controls.Add(this.spAltura);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblLocalidad);
            this.Controls.Add(this.lblParcela);
            this.Controls.Add(this.lblCodigoPostal);
            this.Controls.Add(this.lblDepto);
            this.Controls.Add(this.lblPiso);
            this.Controls.Add(this.lblAltura);
            this.Controls.Add(this.lblCalle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "frmModificarLocacion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmModificarLocacion";
            this.Load += new System.EventHandler(this.frmModificarLocacion_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmModificarLocacion_KeyDown);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgReturn)).EndInit();
            this.pnFooter.ResumeLayout(false);
            this.pnFooter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvServicios)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spAltura)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblLocalidad;
        private System.Windows.Forms.Label lblYCalle;
        private System.Windows.Forms.Label lblEntreCalle;
        private System.Windows.Forms.Label lblParcela;
        private System.Windows.Forms.Label lblCodigoPostal;
        private System.Windows.Forms.Label lblDepto;
        private System.Windows.Forms.Label lblPiso;
        private System.Windows.Forms.Label lblAltura;
        private System.Windows.Forms.Label lblCalle;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private Controles.spinner spAltura;
        private Controles.boton btnBuscarcalle;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox imgReturn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnFooter;
        private System.Windows.Forms.Label lblTotal;
        private Controles.progress pgCircular;
        private Controles.combo cboLocalidades;
        private textboxAdv txtCPServicio;
        private textboxAdv txtCalle;
        private textboxAdv txtParcelaServicio;
        private textboxAdv txtPisoServicio;
        private textboxAdv txtDeptoServicio;
        private Controles.boton btnCancelar;
        private Controles.boton btnGuardarLocacion;
        private System.Windows.Forms.Label lblLocacionActual;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label lblServiciosAsociados;
        private System.Windows.Forms.DataGridView dgvServicios;
        private textboxAdv txtEntreCalle1;
        private textboxAdv txtEntreCalle2;
        private Controles.boton btnLocacionNueva;
        private Controles.boton btnBuscarLocacion;
        private System.Windows.Forms.Label lblLocacionNueva;
        private System.Windows.Forms.Label lblLocacion;
        private System.Windows.Forms.Label lbcorreo;
        private System.Windows.Forms.Label lbcuit;
        private System.Windows.Forms.Label LBNumero_documento;
        private System.Windows.Forms.Label LBApellido;
        private System.Windows.Forms.Label lblMonto;
        private System.Windows.Forms.CheckBox chkTraspasoPartes;
        private System.Windows.Forms.CheckBox chkTraspasoCtaCte;
    }
}