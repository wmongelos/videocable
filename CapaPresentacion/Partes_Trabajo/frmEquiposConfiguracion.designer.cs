namespace CapaPresentacion.Partes_Trabajo
{
    partial class frmEquiposConfiguracion
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlSuperior = new System.Windows.Forms.Panel();
            this.imgReturn = new System.Windows.Forms.PictureBox();
            this.lblTituloHeader = new System.Windows.Forms.Label();
            this.pnlInfo = new System.Windows.Forms.Panel();
            this.pnlEquiposISP = new System.Windows.Forms.Panel();
            this.dgvEquipments = new CapaPresentacion.Controles.dgv(this.components);
            this.lblEquiposISP = new System.Windows.Forms.Label();
            this.pnlAccount = new System.Windows.Forms.Panel();
            this.dgvAccounts = new CapaPresentacion.Controles.dgv(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.pnlEquiposGIES = new System.Windows.Forms.Panel();
            this.dgvEquipos = new CapaPresentacion.Controles.dgv(this.components);
            this.lblEquipos = new System.Windows.Forms.Label();
            this.pnlInfoCabecera = new System.Windows.Forms.Panel();
            this.btnCambioProducto = new CapaPresentacion.Controles.boton();
            this.lblUsuarioDato = new System.Windows.Forms.Label();
            this.lblLocacionDato = new System.Windows.Forms.Label();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.lblServicioDato = new System.Windows.Forms.Label();
            this.lblLocacion = new System.Windows.Forms.Label();
            this.lblOperacion = new System.Windows.Forms.Label();
            this.lblServicio = new System.Windows.Forms.Label();
            this.lblOperacionDato = new System.Windows.Forms.Label();
            this.pnlConfirmar = new System.Windows.Forms.Panel();
            this.btnTerminar = new CapaPresentacion.Controles.boton();
            this.btnGuardar = new CapaPresentacion.Controles.boton();
            this.spMain = new System.Windows.Forms.SplitContainer();
            this.dgvProductos = new CapaPresentacion.Controles.dgv(this.components);
            this.pnlSeleccion = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSeleccionar = new CapaPresentacion.Controles.boton();
            this.lblServicioDato1 = new System.Windows.Forms.Label();
            this.pnlSuperior.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgReturn)).BeginInit();
            this.pnlInfo.SuspendLayout();
            this.pnlEquiposISP.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEquipments)).BeginInit();
            this.pnlAccount.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAccounts)).BeginInit();
            this.pnlEquiposGIES.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEquipos)).BeginInit();
            this.pnlInfoCabecera.SuspendLayout();
            this.pnlConfirmar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spMain)).BeginInit();
            this.spMain.Panel1.SuspendLayout();
            this.spMain.Panel2.SuspendLayout();
            this.spMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).BeginInit();
            this.pnlSeleccion.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlSuperior
            // 
            this.pnlSuperior.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.pnlSuperior.Controls.Add(this.imgReturn);
            this.pnlSuperior.Controls.Add(this.lblTituloHeader);
            this.pnlSuperior.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSuperior.Location = new System.Drawing.Point(0, 0);
            this.pnlSuperior.Name = "pnlSuperior";
            this.pnlSuperior.Size = new System.Drawing.Size(1171, 75);
            this.pnlSuperior.TabIndex = 52;
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
            this.lblTituloHeader.Size = new System.Drawing.Size(349, 23);
            this.lblTituloHeader.TabIndex = 31;
            this.lblTituloHeader.Text = "Configuracion de equipos / servicios";
            this.lblTituloHeader.Click += new System.EventHandler(this.lblTituloHeader_Click);
            // 
            // pnlInfo
            // 
            this.pnlInfo.BackColor = System.Drawing.SystemColors.Control;
            this.pnlInfo.Controls.Add(this.pnlEquiposISP);
            this.pnlInfo.Controls.Add(this.pnlAccount);
            this.pnlInfo.Controls.Add(this.pnlEquiposGIES);
            this.pnlInfo.Controls.Add(this.pnlInfoCabecera);
            this.pnlInfo.Controls.Add(this.pnlConfirmar);
            this.pnlInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlInfo.Location = new System.Drawing.Point(0, 0);
            this.pnlInfo.Name = "pnlInfo";
            this.pnlInfo.Size = new System.Drawing.Size(1171, 451);
            this.pnlInfo.TabIndex = 336;
            this.pnlInfo.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlInfo_Paint);
            // 
            // pnlEquiposISP
            // 
            this.pnlEquiposISP.Controls.Add(this.dgvEquipments);
            this.pnlEquiposISP.Controls.Add(this.lblEquiposISP);
            this.pnlEquiposISP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlEquiposISP.Location = new System.Drawing.Point(414, 170);
            this.pnlEquiposISP.Margin = new System.Windows.Forms.Padding(13, 13, 3, 3);
            this.pnlEquiposISP.Name = "pnlEquiposISP";
            this.pnlEquiposISP.Padding = new System.Windows.Forms.Padding(5, 0, 5, 5);
            this.pnlEquiposISP.Size = new System.Drawing.Size(757, 236);
            this.pnlEquiposISP.TabIndex = 344;
            // 
            // dgvEquipments
            // 
            this.dgvEquipments.AllowUserToAddRows = false;
            this.dgvEquipments.AllowUserToDeleteRows = false;
            this.dgvEquipments.AllowUserToOrderColumns = true;
            this.dgvEquipments.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvEquipments.BackgroundColor = System.Drawing.Color.White;
            this.dgvEquipments.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvEquipments.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSlateGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvEquipments.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvEquipments.ColumnHeadersHeight = 40;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvEquipments.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvEquipments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvEquipments.EnableHeadersVisualStyles = false;
            this.dgvEquipments.GridColor = System.Drawing.Color.WhiteSmoke;
            this.dgvEquipments.Location = new System.Drawing.Point(5, 21);
            this.dgvEquipments.Margin = new System.Windows.Forms.Padding(13, 13, 13, 3);
            this.dgvEquipments.MultiSelect = false;
            this.dgvEquipments.Name = "dgvEquipments";
            this.dgvEquipments.ReadOnly = true;
            this.dgvEquipments.RowHeadersVisible = false;
            this.dgvEquipments.RowHeadersWidth = 50;
            this.dgvEquipments.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvEquipments.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEquipments.Size = new System.Drawing.Size(747, 210);
            this.dgvEquipments.TabIndex = 341;
            this.dgvEquipments.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEquipments_CellClick);
            // 
            // lblEquiposISP
            // 
            this.lblEquiposISP.AutoSize = true;
            this.lblEquiposISP.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblEquiposISP.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblEquiposISP.Location = new System.Drawing.Point(5, 0);
            this.lblEquiposISP.Name = "lblEquiposISP";
            this.lblEquiposISP.Size = new System.Drawing.Size(247, 21);
            this.lblEquiposISP.TabIndex = 342;
            this.lblEquiposISP.Text = "Equipos asignados al usuario (ISP)";
            // 
            // pnlAccount
            // 
            this.pnlAccount.Controls.Add(this.dgvAccounts);
            this.pnlAccount.Controls.Add(this.label1);
            this.pnlAccount.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlAccount.Location = new System.Drawing.Point(0, 170);
            this.pnlAccount.Name = "pnlAccount";
            this.pnlAccount.Padding = new System.Windows.Forms.Padding(5, 0, 5, 5);
            this.pnlAccount.Size = new System.Drawing.Size(414, 236);
            this.pnlAccount.TabIndex = 343;
            // 
            // dgvAccounts
            // 
            this.dgvAccounts.AllowUserToAddRows = false;
            this.dgvAccounts.AllowUserToDeleteRows = false;
            this.dgvAccounts.AllowUserToOrderColumns = true;
            this.dgvAccounts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAccounts.BackgroundColor = System.Drawing.Color.White;
            this.dgvAccounts.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvAccounts.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.LightSlateGray;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAccounts.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvAccounts.ColumnHeadersHeight = 40;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvAccounts.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvAccounts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAccounts.EnableHeadersVisualStyles = false;
            this.dgvAccounts.GridColor = System.Drawing.Color.WhiteSmoke;
            this.dgvAccounts.Location = new System.Drawing.Point(5, 21);
            this.dgvAccounts.MultiSelect = false;
            this.dgvAccounts.Name = "dgvAccounts";
            this.dgvAccounts.ReadOnly = true;
            this.dgvAccounts.RowHeadersVisible = false;
            this.dgvAccounts.RowHeadersWidth = 50;
            this.dgvAccounts.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvAccounts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAccounts.Size = new System.Drawing.Size(404, 210);
            this.dgvAccounts.TabIndex = 339;
            this.dgvAccounts.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAccounts_CellClick);
            this.dgvAccounts.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAccounts_CellDoubleClick);
            this.dgvAccounts.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvAccounts_DataBindingComplete);
            this.dgvAccounts.SelectionChanged += new System.EventHandler(this.dgvAccounts_SelectionChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label1.Location = new System.Drawing.Point(5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(170, 21);
            this.label1.TabIndex = 340;
            this.label1.Text = "Servicios ISP asociados";
            // 
            // pnlEquiposGIES
            // 
            this.pnlEquiposGIES.Controls.Add(this.dgvEquipos);
            this.pnlEquiposGIES.Controls.Add(this.lblEquipos);
            this.pnlEquiposGIES.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlEquiposGIES.Location = new System.Drawing.Point(0, 49);
            this.pnlEquiposGIES.Name = "pnlEquiposGIES";
            this.pnlEquiposGIES.Padding = new System.Windows.Forms.Padding(5, 0, 5, 5);
            this.pnlEquiposGIES.Size = new System.Drawing.Size(1171, 121);
            this.pnlEquiposGIES.TabIndex = 345;
            // 
            // dgvEquipos
            // 
            this.dgvEquipos.AllowUserToAddRows = false;
            this.dgvEquipos.AllowUserToDeleteRows = false;
            this.dgvEquipos.AllowUserToOrderColumns = true;
            this.dgvEquipos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvEquipos.BackgroundColor = System.Drawing.Color.White;
            this.dgvEquipos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvEquipos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.LightSlateGray;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvEquipos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvEquipos.ColumnHeadersHeight = 40;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvEquipos.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvEquipos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvEquipos.EnableHeadersVisualStyles = false;
            this.dgvEquipos.GridColor = System.Drawing.Color.WhiteSmoke;
            this.dgvEquipos.Location = new System.Drawing.Point(5, 21);
            this.dgvEquipos.MultiSelect = false;
            this.dgvEquipos.Name = "dgvEquipos";
            this.dgvEquipos.ReadOnly = true;
            this.dgvEquipos.RowHeadersVisible = false;
            this.dgvEquipos.RowHeadersWidth = 50;
            this.dgvEquipos.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvEquipos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvEquipos.Size = new System.Drawing.Size(1161, 95);
            this.dgvEquipos.TabIndex = 336;
            this.dgvEquipos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEquipos_CellContentClick);
            this.dgvEquipos.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEquipos_CellEndEdit);
            // 
            // lblEquipos
            // 
            this.lblEquipos.AutoSize = true;
            this.lblEquipos.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblEquipos.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblEquipos.Location = new System.Drawing.Point(5, 0);
            this.lblEquipos.Name = "lblEquipos";
            this.lblEquipos.Size = new System.Drawing.Size(257, 21);
            this.lblEquipos.TabIndex = 337;
            this.lblEquipos.Text = "Equipos asigandos al usuario (GIES)";
            this.lblEquipos.Click += new System.EventHandler(this.lblEquipos_Click);
            // 
            // pnlInfoCabecera
            // 
            this.pnlInfoCabecera.Controls.Add(this.btnCambioProducto);
            this.pnlInfoCabecera.Controls.Add(this.lblUsuarioDato);
            this.pnlInfoCabecera.Controls.Add(this.lblLocacionDato);
            this.pnlInfoCabecera.Controls.Add(this.lblUsuario);
            this.pnlInfoCabecera.Controls.Add(this.lblServicioDato);
            this.pnlInfoCabecera.Controls.Add(this.lblLocacion);
            this.pnlInfoCabecera.Controls.Add(this.lblOperacion);
            this.pnlInfoCabecera.Controls.Add(this.lblServicio);
            this.pnlInfoCabecera.Controls.Add(this.lblOperacionDato);
            this.pnlInfoCabecera.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlInfoCabecera.Location = new System.Drawing.Point(0, 0);
            this.pnlInfoCabecera.Name = "pnlInfoCabecera";
            this.pnlInfoCabecera.Size = new System.Drawing.Size(1171, 49);
            this.pnlInfoCabecera.TabIndex = 338;
            this.pnlInfoCabecera.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlInfoCabecera_Paint);
            // 
            // btnCambioProducto
            // 
            this.btnCambioProducto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCambioProducto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnCambioProducto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCambioProducto.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnCambioProducto.FlatAppearance.BorderSize = 0;
            this.btnCambioProducto.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnCambioProducto.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnCambioProducto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCambioProducto.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnCambioProducto.ForeColor = System.Drawing.Color.White;
            this.btnCambioProducto.Image = global::CapaPresentacion.Properties.Resources.Data_Add_32;
            this.btnCambioProducto.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCambioProducto.Location = new System.Drawing.Point(968, 5);
            this.btnCambioProducto.Name = "btnCambioProducto";
            this.btnCambioProducto.Size = new System.Drawing.Size(186, 38);
            this.btnCambioProducto.TabIndex = 332;
            this.btnCambioProducto.Text = "Cambiar producto";
            this.btnCambioProducto.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCambioProducto.UseVisualStyleBackColor = false;
            this.btnCambioProducto.Click += new System.EventHandler(this.btnCambioProducto_Click);
            // 
            // lblUsuarioDato
            // 
            this.lblUsuarioDato.AutoSize = true;
            this.lblUsuarioDato.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblUsuarioDato.Location = new System.Drawing.Point(78, 14);
            this.lblUsuarioDato.Name = "lblUsuarioDato";
            this.lblUsuarioDato.Size = new System.Drawing.Size(64, 21);
            this.lblUsuarioDato.TabIndex = 326;
            this.lblUsuarioDato.Text = "Usuario";
            // 
            // lblLocacionDato
            // 
            this.lblLocacionDato.AutoSize = true;
            this.lblLocacionDato.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblLocacionDato.Location = new System.Drawing.Point(561, 14);
            this.lblLocacionDato.Name = "lblLocacionDato";
            this.lblLocacionDato.Size = new System.Drawing.Size(71, 21);
            this.lblLocacionDato.TabIndex = 329;
            this.lblLocacionDato.Text = "Locacion";
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblUsuario.Location = new System.Drawing.Point(11, 14);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(67, 21);
            this.lblUsuario.TabIndex = 322;
            this.lblUsuario.Text = "Usuario:";
            // 
            // lblServicioDato
            // 
            this.lblServicioDato.AutoSize = true;
            this.lblServicioDato.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblServicioDato.Location = new System.Drawing.Point(223, 14);
            this.lblServicioDato.Name = "lblServicioDato";
            this.lblServicioDato.Size = new System.Drawing.Size(65, 21);
            this.lblServicioDato.TabIndex = 319;
            this.lblServicioDato.Text = "Servicio";
            // 
            // lblLocacion
            // 
            this.lblLocacion.AutoSize = true;
            this.lblLocacion.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblLocacion.Location = new System.Drawing.Point(484, 14);
            this.lblLocacion.Name = "lblLocacion";
            this.lblLocacion.Size = new System.Drawing.Size(74, 21);
            this.lblLocacion.TabIndex = 328;
            this.lblLocacion.Text = "Locacion:";
            // 
            // lblOperacion
            // 
            this.lblOperacion.AutoSize = true;
            this.lblOperacion.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblOperacion.Location = new System.Drawing.Point(301, 14);
            this.lblOperacion.Name = "lblOperacion";
            this.lblOperacion.Size = new System.Drawing.Size(85, 21);
            this.lblOperacion.TabIndex = 331;
            this.lblOperacion.Text = "Operacion:";
            // 
            // lblServicio
            // 
            this.lblServicio.AutoSize = true;
            this.lblServicio.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblServicio.Location = new System.Drawing.Point(152, 14);
            this.lblServicio.Name = "lblServicio";
            this.lblServicio.Size = new System.Drawing.Size(68, 21);
            this.lblServicio.TabIndex = 323;
            this.lblServicio.Text = "Servicio:";
            // 
            // lblOperacionDato
            // 
            this.lblOperacionDato.AutoSize = true;
            this.lblOperacionDato.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblOperacionDato.Location = new System.Drawing.Point(385, 14);
            this.lblOperacionDato.Name = "lblOperacionDato";
            this.lblOperacionDato.Size = new System.Drawing.Size(82, 21);
            this.lblOperacionDato.TabIndex = 330;
            this.lblOperacionDato.Text = "Operacion";
            // 
            // pnlConfirmar
            // 
            this.pnlConfirmar.Controls.Add(this.btnTerminar);
            this.pnlConfirmar.Controls.Add(this.btnGuardar);
            this.pnlConfirmar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlConfirmar.Location = new System.Drawing.Point(0, 406);
            this.pnlConfirmar.Name = "pnlConfirmar";
            this.pnlConfirmar.Size = new System.Drawing.Size(1171, 45);
            this.pnlConfirmar.TabIndex = 346;
            this.pnlConfirmar.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlConfirmar_Paint);
            // 
            // btnTerminar
            // 
            this.btnTerminar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTerminar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnTerminar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTerminar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnTerminar.FlatAppearance.BorderSize = 0;
            this.btnTerminar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnTerminar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnTerminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTerminar.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnTerminar.ForeColor = System.Drawing.Color.White;
            this.btnTerminar.Image = global::CapaPresentacion.Properties.Resources.Data_Add_32;
            this.btnTerminar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnTerminar.Location = new System.Drawing.Point(948, 9);
            this.btnTerminar.Margin = new System.Windows.Forms.Padding(2);
            this.btnTerminar.Name = "btnTerminar";
            this.btnTerminar.Size = new System.Drawing.Size(206, 31);
            this.btnTerminar.TabIndex = 335;
            this.btnTerminar.Text = "Terminar";
            this.btnTerminar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTerminar.UseVisualStyleBackColor = false;
            this.btnTerminar.Visible = false;
            this.btnTerminar.Click += new System.EventHandler(this.btnTerminar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnGuardar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Image = global::CapaPresentacion.Properties.Resources.Data_Add_32;
            this.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGuardar.Location = new System.Drawing.Point(738, 9);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(2);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(206, 31);
            this.btnGuardar.TabIndex = 334;
            this.btnGuardar.Text = "Guardar en ISP";
            this.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // spMain
            // 
            this.spMain.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.spMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spMain.Location = new System.Drawing.Point(0, 75);
            this.spMain.Name = "spMain";
            this.spMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // spMain.Panel1
            // 
            this.spMain.Panel1.Controls.Add(this.pnlInfo);
            // 
            // spMain.Panel2
            // 
            this.spMain.Panel2.Controls.Add(this.dgvProductos);
            this.spMain.Panel2.Controls.Add(this.pnlSeleccion);
            this.spMain.Size = new System.Drawing.Size(1171, 642);
            this.spMain.SplitterDistance = 451;
            this.spMain.SplitterWidth = 10;
            this.spMain.TabIndex = 55;
            // 
            // dgvProductos
            // 
            this.dgvProductos.AllowUserToAddRows = false;
            this.dgvProductos.AllowUserToDeleteRows = false;
            this.dgvProductos.AllowUserToOrderColumns = true;
            this.dgvProductos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProductos.BackgroundColor = System.Drawing.Color.White;
            this.dgvProductos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvProductos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.LightSlateGray;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvProductos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvProductos.ColumnHeadersHeight = 40;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvProductos.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgvProductos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvProductos.EnableHeadersVisualStyles = false;
            this.dgvProductos.GridColor = System.Drawing.Color.WhiteSmoke;
            this.dgvProductos.Location = new System.Drawing.Point(0, 55);
            this.dgvProductos.MultiSelect = false;
            this.dgvProductos.Name = "dgvProductos";
            this.dgvProductos.ReadOnly = true;
            this.dgvProductos.RowHeadersVisible = false;
            this.dgvProductos.RowHeadersWidth = 50;
            this.dgvProductos.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvProductos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProductos.Size = new System.Drawing.Size(1171, 126);
            this.dgvProductos.TabIndex = 54;
            // 
            // pnlSeleccion
            // 
            this.pnlSeleccion.BackColor = System.Drawing.SystemColors.Control;
            this.pnlSeleccion.Controls.Add(this.label4);
            this.pnlSeleccion.Controls.Add(this.btnSeleccionar);
            this.pnlSeleccion.Controls.Add(this.lblServicioDato1);
            this.pnlSeleccion.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSeleccion.Location = new System.Drawing.Point(0, 0);
            this.pnlSeleccion.Name = "pnlSeleccion";
            this.pnlSeleccion.Size = new System.Drawing.Size(1171, 55);
            this.pnlSeleccion.TabIndex = 338;
            this.pnlSeleccion.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label4.Location = new System.Drawing.Point(3, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 21);
            this.label4.TabIndex = 337;
            this.label4.Text = "Servicio:";
            // 
            // btnSeleccionar
            // 
            this.btnSeleccionar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSeleccionar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnSeleccionar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSeleccionar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnSeleccionar.FlatAppearance.BorderSize = 0;
            this.btnSeleccionar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnSeleccionar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnSeleccionar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSeleccionar.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnSeleccionar.ForeColor = System.Drawing.Color.White;
            this.btnSeleccionar.Image = global::CapaPresentacion.Properties.Resources.Data_Add_32;
            this.btnSeleccionar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSeleccionar.Location = new System.Drawing.Point(948, 16);
            this.btnSeleccionar.Margin = new System.Windows.Forms.Padding(2);
            this.btnSeleccionar.Name = "btnSeleccionar";
            this.btnSeleccionar.Size = new System.Drawing.Size(206, 31);
            this.btnSeleccionar.TabIndex = 336;
            this.btnSeleccionar.Text = "Seleccionar producto";
            this.btnSeleccionar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSeleccionar.UseVisualStyleBackColor = false;
            this.btnSeleccionar.Click += new System.EventHandler(this.btnSeleccionar_Click_1);
            // 
            // lblServicioDato1
            // 
            this.lblServicioDato1.AutoSize = true;
            this.lblServicioDato1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblServicioDato1.Location = new System.Drawing.Point(77, 20);
            this.lblServicioDato1.Name = "lblServicioDato1";
            this.lblServicioDato1.Size = new System.Drawing.Size(65, 21);
            this.lblServicioDato1.TabIndex = 336;
            this.lblServicioDato1.Text = "Servicio";
            // 
            // frmEquiposConfiguracion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1171, 717);
            this.Controls.Add(this.spMain);
            this.Controls.Add(this.pnlSuperior);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmEquiposConfiguracion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmEquiposConfiguracion";
            this.Load += new System.EventHandler(this.frmEquiposConfiguracion_Load);
            this.pnlSuperior.ResumeLayout(false);
            this.pnlSuperior.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgReturn)).EndInit();
            this.pnlInfo.ResumeLayout(false);
            this.pnlEquiposISP.ResumeLayout(false);
            this.pnlEquiposISP.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEquipments)).EndInit();
            this.pnlAccount.ResumeLayout(false);
            this.pnlAccount.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAccounts)).EndInit();
            this.pnlEquiposGIES.ResumeLayout(false);
            this.pnlEquiposGIES.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEquipos)).EndInit();
            this.pnlInfoCabecera.ResumeLayout(false);
            this.pnlInfoCabecera.PerformLayout();
            this.pnlConfirmar.ResumeLayout(false);
            this.spMain.Panel1.ResumeLayout(false);
            this.spMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spMain)).EndInit();
            this.spMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).EndInit();
            this.pnlSeleccion.ResumeLayout(false);
            this.pnlSeleccion.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlSuperior;
        private System.Windows.Forms.PictureBox imgReturn;
        private System.Windows.Forms.Label lblTituloHeader;
        private Controles.dgv dgvProductos;
        private System.Windows.Forms.Label lblUsuarioDato;
        private System.Windows.Forms.Label lblServicio;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Label lblServicioDato;
        private System.Windows.Forms.Label lblOperacion;
        private System.Windows.Forms.Label lblOperacionDato;
        private System.Windows.Forms.Label lblLocacionDato;
        private System.Windows.Forms.Label lblLocacion;
        private Controles.boton btnGuardar;
        private System.Windows.Forms.Panel pnlInfo;
        private System.Windows.Forms.Label lblEquipos;
        private Controles.dgv dgvEquipos;
        private System.Windows.Forms.SplitContainer spMain;
        private System.Windows.Forms.Panel pnlInfoCabecera;
        private System.Windows.Forms.Label label1;
        private Controles.dgv dgvAccounts;
        private System.Windows.Forms.Label lblEquiposISP;
        private Controles.dgv dgvEquipments;
        private System.Windows.Forms.Panel pnlEquiposISP;
        private System.Windows.Forms.Panel pnlAccount;
        private System.Windows.Forms.Panel pnlEquiposGIES;
        private System.Windows.Forms.Panel pnlConfirmar;
        private Controles.boton btnTerminar;
        private System.Windows.Forms.Panel pnlSeleccion;
        private Controles.boton btnSeleccionar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblServicioDato1;
        private Controles.boton btnCambioProducto;
    }
}