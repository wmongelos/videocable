
namespace CapaPresentacion.Partes_Trabajo
{
    partial class frmUnificarLocacion
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
            this.panel3 = new System.Windows.Forms.Panel();
            this.imgReturn = new System.Windows.Forms.PictureBox();
            this.lblTituloHeader = new System.Windows.Forms.Label();
            this.gbLocacionDestino = new System.Windows.Forms.GroupBox();
            this.lblCp = new System.Windows.Forms.Label();
            this.lblAltura = new System.Windows.Forms.Label();
            this.lblCalle = new System.Windows.Forms.Label();
            this.lblLocalidad = new System.Windows.Forms.Label();
            this.btnTraslada = new CapaPresentacion.Controles.boton();
            this.cboDestino = new System.Windows.Forms.ComboBox();
            this.tbCtaParteServicios = new System.Windows.Forms.TableLayoutPanel();
            this.gbPartes = new System.Windows.Forms.GroupBox();
            this.dgvParte = new CapaPresentacion.Controles.dgv(this.components);
            this.gbServicios = new System.Windows.Forms.GroupBox();
            this.dgvServicio = new CapaPresentacion.Controles.dgv(this.components);
            this.gbCtaCte = new System.Windows.Forms.GroupBox();
            this.dgvCtaCte = new CapaPresentacion.Controles.dgv(this.components);
            this.cboOrigen = new System.Windows.Forms.ComboBox();
            this.tbGeneral = new System.Windows.Forms.TableLayoutPanel();
            this.gbLocacionOrigen = new System.Windows.Forms.GroupBox();
            this.gbCondiciones = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.lblPendienteAsignacion = new System.Windows.Forms.Label();
            this.lblAsignado = new System.Windows.Forms.Label();
            this.lblServicioHabilitado = new System.Windows.Forms.Label();
            this.lblDeudas = new System.Windows.Forms.Label();
            this.lblPartes = new System.Windows.Forms.Label();
            this.cboFalla = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgReturn)).BeginInit();
            this.gbLocacionDestino.SuspendLayout();
            this.tbCtaParteServicios.SuspendLayout();
            this.gbPartes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvParte)).BeginInit();
            this.gbServicios.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvServicio)).BeginInit();
            this.gbCtaCte.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCtaCte)).BeginInit();
            this.tbGeneral.SuspendLayout();
            this.gbLocacionOrigen.SuspendLayout();
            this.gbCondiciones.SuspendLayout();
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
            this.panel3.Size = new System.Drawing.Size(1556, 75);
            this.panel3.TabIndex = 316;
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
            this.lblTituloHeader.Text = "Unificar Locaciones";
            // 
            // gbLocacionDestino
            // 
            this.gbLocacionDestino.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbLocacionDestino.Controls.Add(this.label3);
            this.gbLocacionDestino.Controls.Add(this.cboFalla);
            this.gbLocacionDestino.Controls.Add(this.lblCp);
            this.gbLocacionDestino.Controls.Add(this.lblAltura);
            this.gbLocacionDestino.Controls.Add(this.lblCalle);
            this.gbLocacionDestino.Controls.Add(this.lblLocalidad);
            this.gbLocacionDestino.Controls.Add(this.btnTraslada);
            this.gbLocacionDestino.Controls.Add(this.cboDestino);
            this.gbLocacionDestino.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbLocacionDestino.Location = new System.Drawing.Point(309, 355);
            this.gbLocacionDestino.Name = "gbLocacionDestino";
            this.gbLocacionDestino.Size = new System.Drawing.Size(1220, 145);
            this.gbLocacionDestino.TabIndex = 325;
            this.gbLocacionDestino.TabStop = false;
            this.gbLocacionDestino.Text = "Locacion Destino";
            // 
            // lblCp
            // 
            this.lblCp.AutoSize = true;
            this.lblCp.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCp.Location = new System.Drawing.Point(312, 119);
            this.lblCp.Name = "lblCp";
            this.lblCp.Size = new System.Drawing.Size(102, 21);
            this.lblCp.TabIndex = 324;
            this.lblCp.Text = "Codigo Postal";
            // 
            // lblAltura
            // 
            this.lblAltura.AutoSize = true;
            this.lblAltura.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAltura.Location = new System.Drawing.Point(312, 93);
            this.lblAltura.Name = "lblAltura";
            this.lblAltura.Size = new System.Drawing.Size(50, 21);
            this.lblAltura.TabIndex = 323;
            this.lblAltura.Text = "Altura";
            // 
            // lblCalle
            // 
            this.lblCalle.AutoSize = true;
            this.lblCalle.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCalle.Location = new System.Drawing.Point(312, 68);
            this.lblCalle.Name = "lblCalle";
            this.lblCalle.Size = new System.Drawing.Size(42, 21);
            this.lblCalle.TabIndex = 322;
            this.lblCalle.Text = "Calle";
            // 
            // lblLocalidad
            // 
            this.lblLocalidad.AutoSize = true;
            this.lblLocalidad.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLocalidad.Location = new System.Drawing.Point(11, 68);
            this.lblLocalidad.Name = "lblLocalidad";
            this.lblLocalidad.Size = new System.Drawing.Size(73, 21);
            this.lblLocalidad.TabIndex = 321;
            this.lblLocalidad.Text = "Localidad";
            // 
            // btnTraslada
            // 
            this.btnTraslada.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTraslada.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnTraslada.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTraslada.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnTraslada.FlatAppearance.BorderSize = 0;
            this.btnTraslada.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnTraslada.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnTraslada.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTraslada.Font = new System.Drawing.Font("Segoe UI Light", 12F);
            this.btnTraslada.ForeColor = System.Drawing.Color.White;
            this.btnTraslada.Image = global::CapaPresentacion.Properties.Resources.Arrowhead_Right_32;
            this.btnTraslada.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnTraslada.Location = new System.Drawing.Point(927, 102);
            this.btnTraslada.Name = "btnTraslada";
            this.btnTraslada.Size = new System.Drawing.Size(281, 38);
            this.btnTraslada.TabIndex = 320;
            this.btnTraslada.Text = "Trasladar a Locacion Destino";
            this.btnTraslada.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTraslada.UseVisualStyleBackColor = false;
            this.btnTraslada.Click += new System.EventHandler(this.btnTraslada_Click);
            // 
            // cboDestino
            // 
            this.cboDestino.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboDestino.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboDestino.FormattingEnabled = true;
            this.cboDestino.Location = new System.Drawing.Point(9, 24);
            this.cboDestino.Name = "cboDestino";
            this.cboDestino.Size = new System.Drawing.Size(1199, 29);
            this.cboDestino.TabIndex = 317;
            this.cboDestino.SelectedIndexChanged += new System.EventHandler(this.cboDestino_SelectedIndexChanged);
            // 
            // tbCtaParteServicios
            // 
            this.tbCtaParteServicios.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbCtaParteServicios.ColumnCount = 3;
            this.tbCtaParteServicios.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tbCtaParteServicios.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tbCtaParteServicios.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tbCtaParteServicios.Controls.Add(this.gbPartes, 1, 0);
            this.tbCtaParteServicios.Controls.Add(this.gbServicios, 2, 0);
            this.tbCtaParteServicios.Controls.Add(this.gbCtaCte, 0, 0);
            this.tbCtaParteServicios.Location = new System.Drawing.Point(6, 56);
            this.tbCtaParteServicios.Name = "tbCtaParteServicios";
            this.tbCtaParteServicios.RowCount = 1;
            this.tbCtaParteServicios.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tbCtaParteServicios.Size = new System.Drawing.Size(1205, 284);
            this.tbCtaParteServicios.TabIndex = 318;
            // 
            // gbPartes
            // 
            this.gbPartes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbPartes.Controls.Add(this.dgvParte);
            this.gbPartes.Location = new System.Drawing.Point(485, 3);
            this.gbPartes.Name = "gbPartes";
            this.gbPartes.Size = new System.Drawing.Size(476, 278);
            this.gbPartes.TabIndex = 322;
            this.gbPartes.TabStop = false;
            this.gbPartes.Text = "Partes";
            // 
            // dgvParte
            // 
            this.dgvParte.AllowUserToAddRows = false;
            this.dgvParte.AllowUserToDeleteRows = false;
            this.dgvParte.AllowUserToOrderColumns = true;
            this.dgvParte.AllowUserToResizeColumns = false;
            this.dgvParte.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvParte.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvParte.BackgroundColor = System.Drawing.Color.White;
            this.dgvParte.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvParte.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSlateGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvParte.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvParte.ColumnHeadersHeight = 40;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvParte.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvParte.EnableHeadersVisualStyles = false;
            this.dgvParte.GridColor = System.Drawing.Color.WhiteSmoke;
            this.dgvParte.Location = new System.Drawing.Point(6, 24);
            this.dgvParte.MultiSelect = false;
            this.dgvParte.Name = "dgvParte";
            this.dgvParte.ReadOnly = true;
            this.dgvParte.RowHeadersVisible = false;
            this.dgvParte.RowHeadersWidth = 50;
            this.dgvParte.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvParte.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvParte.Size = new System.Drawing.Size(464, 248);
            this.dgvParte.TabIndex = 319;
            this.dgvParte.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvParte_CellContentClick);
            // 
            // gbServicios
            // 
            this.gbServicios.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbServicios.Controls.Add(this.dgvServicio);
            this.gbServicios.Location = new System.Drawing.Point(967, 3);
            this.gbServicios.Name = "gbServicios";
            this.gbServicios.Size = new System.Drawing.Size(235, 278);
            this.gbServicios.TabIndex = 323;
            this.gbServicios.TabStop = false;
            this.gbServicios.Text = "Servicios";
            // 
            // dgvServicio
            // 
            this.dgvServicio.AllowUserToAddRows = false;
            this.dgvServicio.AllowUserToDeleteRows = false;
            this.dgvServicio.AllowUserToOrderColumns = true;
            this.dgvServicio.AllowUserToResizeColumns = false;
            this.dgvServicio.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvServicio.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvServicio.BackgroundColor = System.Drawing.Color.White;
            this.dgvServicio.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvServicio.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.LightSlateGray;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvServicio.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvServicio.ColumnHeadersHeight = 40;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvServicio.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvServicio.EnableHeadersVisualStyles = false;
            this.dgvServicio.GridColor = System.Drawing.Color.WhiteSmoke;
            this.dgvServicio.Location = new System.Drawing.Point(6, 24);
            this.dgvServicio.MultiSelect = false;
            this.dgvServicio.Name = "dgvServicio";
            this.dgvServicio.ReadOnly = true;
            this.dgvServicio.RowHeadersVisible = false;
            this.dgvServicio.RowHeadersWidth = 50;
            this.dgvServicio.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvServicio.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvServicio.Size = new System.Drawing.Size(223, 248);
            this.dgvServicio.TabIndex = 320;
            this.dgvServicio.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvServicio_CellContentClick);
            // 
            // gbCtaCte
            // 
            this.gbCtaCte.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbCtaCte.Controls.Add(this.dgvCtaCte);
            this.gbCtaCte.Location = new System.Drawing.Point(3, 3);
            this.gbCtaCte.Name = "gbCtaCte";
            this.gbCtaCte.Size = new System.Drawing.Size(476, 278);
            this.gbCtaCte.TabIndex = 321;
            this.gbCtaCte.TabStop = false;
            this.gbCtaCte.Text = "Cuenta Corriente";
            // 
            // dgvCtaCte
            // 
            this.dgvCtaCte.AllowUserToAddRows = false;
            this.dgvCtaCte.AllowUserToDeleteRows = false;
            this.dgvCtaCte.AllowUserToOrderColumns = true;
            this.dgvCtaCte.AllowUserToResizeRows = false;
            this.dgvCtaCte.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCtaCte.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCtaCte.BackgroundColor = System.Drawing.Color.White;
            this.dgvCtaCte.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvCtaCte.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvCtaCte.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.LightSlateGray;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCtaCte.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvCtaCte.ColumnHeadersHeight = 40;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCtaCte.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvCtaCte.EnableHeadersVisualStyles = false;
            this.dgvCtaCte.GridColor = System.Drawing.Color.WhiteSmoke;
            this.dgvCtaCte.Location = new System.Drawing.Point(6, 21);
            this.dgvCtaCte.MultiSelect = false;
            this.dgvCtaCte.Name = "dgvCtaCte";
            this.dgvCtaCte.ReadOnly = true;
            this.dgvCtaCte.RowHeadersVisible = false;
            this.dgvCtaCte.RowHeadersWidth = 50;
            this.dgvCtaCte.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvCtaCte.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCtaCte.Size = new System.Drawing.Size(464, 251);
            this.dgvCtaCte.TabIndex = 318;
            this.dgvCtaCte.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCtaCte_CellContentClick);
            // 
            // cboOrigen
            // 
            this.cboOrigen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboOrigen.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboOrigen.FormattingEnabled = true;
            this.cboOrigen.Location = new System.Drawing.Point(3, 21);
            this.cboOrigen.Name = "cboOrigen";
            this.cboOrigen.Size = new System.Drawing.Size(1214, 29);
            this.cboOrigen.TabIndex = 317;
            this.cboOrigen.SelectedIndexChanged += new System.EventHandler(this.cboOrigen_SelectedIndexChanged);
            // 
            // tbGeneral
            // 
            this.tbGeneral.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbGeneral.ColumnCount = 2;
            this.tbGeneral.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tbGeneral.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tbGeneral.Controls.Add(this.gbLocacionOrigen, 1, 0);
            this.tbGeneral.Controls.Add(this.gbLocacionDestino, 1, 1);
            this.tbGeneral.Controls.Add(this.gbCondiciones, 0, 0);
            this.tbGeneral.Location = new System.Drawing.Point(12, 81);
            this.tbGeneral.Name = "tbGeneral";
            this.tbGeneral.RowCount = 2;
            this.tbGeneral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tbGeneral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tbGeneral.Size = new System.Drawing.Size(1532, 503);
            this.tbGeneral.TabIndex = 324;
            // 
            // gbLocacionOrigen
            // 
            this.gbLocacionOrigen.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbLocacionOrigen.Controls.Add(this.tbCtaParteServicios);
            this.gbLocacionOrigen.Controls.Add(this.cboOrigen);
            this.gbLocacionOrigen.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbLocacionOrigen.Location = new System.Drawing.Point(309, 3);
            this.gbLocacionOrigen.Name = "gbLocacionOrigen";
            this.gbLocacionOrigen.Size = new System.Drawing.Size(1220, 346);
            this.gbLocacionOrigen.TabIndex = 320;
            this.gbLocacionOrigen.TabStop = false;
            this.gbLocacionOrigen.Text = "Locacion Origen";
            // 
            // gbCondiciones
            // 
            this.gbCondiciones.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbCondiciones.Controls.Add(this.label2);
            this.gbCondiciones.Controls.Add(this.panel1);
            this.gbCondiciones.Controls.Add(this.label1);
            this.gbCondiciones.Controls.Add(this.lblPendienteAsignacion);
            this.gbCondiciones.Controls.Add(this.lblAsignado);
            this.gbCondiciones.Controls.Add(this.lblServicioHabilitado);
            this.gbCondiciones.Controls.Add(this.lblDeudas);
            this.gbCondiciones.Controls.Add(this.lblPartes);
            this.gbCondiciones.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbCondiciones.Location = new System.Drawing.Point(3, 3);
            this.gbCondiciones.Name = "gbCondiciones";
            this.gbCondiciones.Size = new System.Drawing.Size(300, 346);
            this.gbCondiciones.TabIndex = 326;
            this.gbCondiciones.TabStop = false;
            this.gbCondiciones.Text = "Condiciones";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 266);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 21);
            this.label2.TabIndex = 329;
            this.label2.Text = "Referencias";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Location = new System.Drawing.Point(0, 253);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(301, 1);
            this.panel1.TabIndex = 328;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.DarkGoldenrod;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Location = new System.Drawing.Point(198, 314);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 17);
            this.label1.TabIndex = 327;
            this.label1.Text = "ADVERTENCIA";
            // 
            // lblPendienteAsignacion
            // 
            this.lblPendienteAsignacion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblPendienteAsignacion.AutoSize = true;
            this.lblPendienteAsignacion.BackColor = System.Drawing.Color.Tomato;
            this.lblPendienteAsignacion.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPendienteAsignacion.ForeColor = System.Drawing.Color.White;
            this.lblPendienteAsignacion.Location = new System.Drawing.Point(99, 314);
            this.lblPendienteAsignacion.Name = "lblPendienteAsignacion";
            this.lblPendienteAsignacion.Size = new System.Drawing.Size(93, 17);
            this.lblPendienteAsignacion.TabIndex = 326;
            this.lblPendienteAsignacion.Text = "RESTRINGIDO";
            // 
            // lblAsignado
            // 
            this.lblAsignado.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblAsignado.AutoSize = true;
            this.lblAsignado.BackColor = System.Drawing.Color.ForestGreen;
            this.lblAsignado.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAsignado.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblAsignado.Location = new System.Drawing.Point(7, 314);
            this.lblAsignado.Name = "lblAsignado";
            this.lblAsignado.Size = new System.Drawing.Size(86, 17);
            this.lblAsignado.TabIndex = 325;
            this.lblAsignado.Text = "HABILITADO";
            // 
            // lblServicioHabilitado
            // 
            this.lblServicioHabilitado.AutoSize = true;
            this.lblServicioHabilitado.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblServicioHabilitado.Location = new System.Drawing.Point(6, 187);
            this.lblServicioHabilitado.Name = "lblServicioHabilitado";
            this.lblServicioHabilitado.Size = new System.Drawing.Size(239, 21);
            this.lblServicioHabilitado.TabIndex = 324;
            this.lblServicioHabilitado.Text = "Servicio habilitado en destino";
            // 
            // lblDeudas
            // 
            this.lblDeudas.AutoSize = true;
            this.lblDeudas.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeudas.Location = new System.Drawing.Point(6, 56);
            this.lblDeudas.Name = "lblDeudas";
            this.lblDeudas.Size = new System.Drawing.Size(146, 21);
            this.lblDeudas.TabIndex = 323;
            this.lblDeudas.Text = "Locacion deudora";
            // 
            // lblPartes
            // 
            this.lblPartes.AutoSize = true;
            this.lblPartes.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPartes.Location = new System.Drawing.Point(6, 120);
            this.lblPartes.Name = "lblPartes";
            this.lblPartes.Size = new System.Drawing.Size(123, 21);
            this.lblPartes.TabIndex = 322;
            this.lblPartes.Text = "Partes abiertos";
            // 
            // cboFalla
            // 
            this.cboFalla.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboFalla.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboFalla.FormattingEnabled = true;
            this.cboFalla.Location = new System.Drawing.Point(927, 59);
            this.cboFalla.Name = "cboFalla";
            this.cboFalla.Size = new System.Drawing.Size(281, 29);
            this.cboFalla.TabIndex = 325;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(861, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 21);
            this.label3.TabIndex = 326;
            this.label3.Text = "Motivo:";
            // 
            // frmUnificarLocacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1556, 596);
            this.Controls.Add(this.tbGeneral);
            this.Controls.Add(this.panel3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmUnificarLocacion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmUnificarLocacion";
            this.Load += new System.EventHandler(this.frmUnificarLocacion_Load);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgReturn)).EndInit();
            this.gbLocacionDestino.ResumeLayout(false);
            this.gbLocacionDestino.PerformLayout();
            this.tbCtaParteServicios.ResumeLayout(false);
            this.gbPartes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvParte)).EndInit();
            this.gbServicios.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvServicio)).EndInit();
            this.gbCtaCte.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCtaCte)).EndInit();
            this.tbGeneral.ResumeLayout(false);
            this.gbLocacionOrigen.ResumeLayout(false);
            this.gbCondiciones.ResumeLayout(false);
            this.gbCondiciones.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox imgReturn;
        private System.Windows.Forms.Label lblTituloHeader;
        private System.Windows.Forms.GroupBox gbLocacionDestino;
        private System.Windows.Forms.ComboBox cboDestino;
        private Controles.boton btnTraslada;
        private Controles.dgv dgvCtaCte;
        private System.Windows.Forms.ComboBox cboOrigen;
        private System.Windows.Forms.TableLayoutPanel tbGeneral;
        private Controles.dgv dgvServicio;
        private Controles.dgv dgvParte;
        private System.Windows.Forms.GroupBox gbCtaCte;
        private System.Windows.Forms.GroupBox gbPartes;
        private System.Windows.Forms.TableLayoutPanel tbCtaParteServicios;
        private System.Windows.Forms.GroupBox gbServicios;
        private System.Windows.Forms.GroupBox gbLocacionOrigen;
        private System.Windows.Forms.Label lblAltura;
        private System.Windows.Forms.Label lblCalle;
        private System.Windows.Forms.Label lblLocalidad;
        private System.Windows.Forms.Label lblCp;
        private System.Windows.Forms.GroupBox gbCondiciones;
        private System.Windows.Forms.Label lblDeudas;
        private System.Windows.Forms.Label lblPartes;
        private System.Windows.Forms.Label lblServicioHabilitado;
        private System.Windows.Forms.Label lblPendienteAsignacion;
        private System.Windows.Forms.Label lblAsignado;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboFalla;
        private System.Windows.Forms.Label label3;
    }
}