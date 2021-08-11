namespace CapaPresentacion.Inventario
{
    partial class FrmMovimientosArt
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
            this.pnLine = new System.Windows.Forms.Panel();
            this.imgReturn = new System.Windows.Forms.PictureBox();
            this.lblTituloHeader = new System.Windows.Forms.Label();
            this.lblTipoServ = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pnFooter = new System.Windows.Forms.Panel();
            this.lblTotalItems = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblDestinatario = new System.Windows.Forms.Label();
            this.lblArticulo = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSacar = new CapaPresentacion.Controles.boton();
            this.btnReiniciar = new CapaPresentacion.Controles.boton();
            this.btnGuardar = new CapaPresentacion.Controles.boton();
            this.btnAgregar = new CapaPresentacion.Controles.boton();
            this.txtCantidad = new CapaPresentacion.textboxAdv();
            this.txtBuscadorArts = new CapaPresentacion.textboxAdv();
            this.btnBuscarArt = new CapaPresentacion.Controles.boton();
            this.dgv = new CapaPresentacion.Controles.dgv(this.components);
            this.btnBuscarDest = new CapaPresentacion.Controles.boton();
            this.cboTipoDestino = new CapaPresentacion.Controles.combo(this.components);
            this.rbAsignar = new System.Windows.Forms.RadioButton();
            this.rbDevolver = new System.Windows.Forms.RadioButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.rbEquipo = new System.Windows.Forms.RadioButton();
            this.rbArticulo = new System.Windows.Forms.RadioButton();
            this.pnLine.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgReturn)).BeginInit();
            this.pnFooter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnLine
            // 
            this.pnLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.pnLine.Controls.Add(this.imgReturn);
            this.pnLine.Controls.Add(this.lblTituloHeader);
            this.pnLine.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnLine.Location = new System.Drawing.Point(0, 0);
            this.pnLine.Name = "pnLine";
            this.pnLine.Size = new System.Drawing.Size(1364, 75);
            this.pnLine.TabIndex = 23;
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
            this.lblTituloHeader.Size = new System.Drawing.Size(338, 27);
            this.lblTituloHeader.TabIndex = 31;
            this.lblTituloHeader.Text = "Asignación de articulos";
            // 
            // lblTipoServ
            // 
            this.lblTipoServ.AutoSize = true;
            this.lblTipoServ.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipoServ.ForeColor = System.Drawing.Color.Black;
            this.lblTipoServ.Location = new System.Drawing.Point(30, 89);
            this.lblTipoServ.Name = "lblTipoServ";
            this.lblTipoServ.Size = new System.Drawing.Size(100, 21);
            this.lblTipoServ.TabIndex = 67;
            this.lblTipoServ.Text = "Tipo Destino:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(327, 89);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 21);
            this.label1.TabIndex = 68;
            this.label1.Text = "Destino:";
            // 
            // pnFooter
            // 
            this.pnFooter.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnFooter.Controls.Add(this.lblTotalItems);
            this.pnFooter.Controls.Add(this.lblTotal);
            this.pnFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnFooter.Location = new System.Drawing.Point(0, 544);
            this.pnFooter.Name = "pnFooter";
            this.pnFooter.Size = new System.Drawing.Size(1364, 30);
            this.pnFooter.TabIndex = 72;
            // 
            // lblTotalItems
            // 
            this.lblTotalItems.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalItems.AutoSize = true;
            this.lblTotalItems.Font = new System.Drawing.Font("Segoe UI Light", 12F);
            this.lblTotalItems.ForeColor = System.Drawing.Color.SlateGray;
            this.lblTotalItems.Location = new System.Drawing.Point(1225, 2);
            this.lblTotalItems.Name = "lblTotalItems";
            this.lblTotalItems.Size = new System.Drawing.Size(95, 21);
            this.lblTotalItems.TabIndex = 14;
            this.lblTotalItems.Text = "Total items: 0";
            // 
            // lblTotal
            // 
            this.lblTotal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI Light", 12F);
            this.lblTotal.ForeColor = System.Drawing.Color.SlateGray;
            this.lblTotal.Location = new System.Drawing.Point(4, 2);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(141, 21);
            this.lblTotal.TabIndex = 13;
            this.lblTotal.Text = "Total de Registros: 0";
            // 
            // lblDestinatario
            // 
            this.lblDestinatario.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDestinatario.ForeColor = System.Drawing.Color.Black;
            this.lblDestinatario.Location = new System.Drawing.Point(399, 89);
            this.lblDestinatario.Name = "lblDestinatario";
            this.lblDestinatario.Size = new System.Drawing.Size(133, 21);
            this.lblDestinatario.TabIndex = 74;
            this.lblDestinatario.Text = "[ SELECCIONAR ]";
            this.lblDestinatario.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblArticulo
            // 
            this.lblArticulo.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblArticulo.ForeColor = System.Drawing.Color.Black;
            this.lblArticulo.Location = new System.Drawing.Point(397, 167);
            this.lblArticulo.Name = "lblArticulo";
            this.lblArticulo.Size = new System.Drawing.Size(130, 21);
            this.lblArticulo.TabIndex = 90;
            this.lblArticulo.Text = "[ SELECCIONAR ]";
            this.lblArticulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(11, 166);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(118, 21);
            this.label3.TabIndex = 75;
            this.label3.Text = "Articulo/Equipo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(694, 137);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 21);
            this.label2.TabIndex = 91;
            this.label2.Text = "Cantidad:";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(0, 216);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1386, 1);
            this.panel1.TabIndex = 93;
            // 
            // btnSacar
            // 
            this.btnSacar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSacar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnSacar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSacar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(84)))), ((int)(((byte)(101)))));
            this.btnSacar.FlatAppearance.BorderSize = 0;
            this.btnSacar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(84)))), ((int)(((byte)(101)))));
            this.btnSacar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            this.btnSacar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSacar.Font = new System.Drawing.Font("Segoe UI Light", 12F);
            this.btnSacar.ForeColor = System.Drawing.Color.White;
            this.btnSacar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSacar.Location = new System.Drawing.Point(1212, 114);
            this.btnSacar.Name = "btnSacar";
            this.btnSacar.Size = new System.Drawing.Size(140, 30);
            this.btnSacar.TabIndex = 92;
            this.btnSacar.Text = "Eliminar";
            this.btnSacar.UseVisualStyleBackColor = false;
            this.btnSacar.Click += new System.EventHandler(this.btnSacar_Click);
            // 
            // btnReiniciar
            // 
            this.btnReiniciar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReiniciar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnReiniciar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReiniciar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(84)))), ((int)(((byte)(101)))));
            this.btnReiniciar.FlatAppearance.BorderSize = 0;
            this.btnReiniciar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(84)))), ((int)(((byte)(101)))));
            this.btnReiniciar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            this.btnReiniciar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReiniciar.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReiniciar.ForeColor = System.Drawing.Color.White;
            this.btnReiniciar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnReiniciar.Location = new System.Drawing.Point(1212, 184);
            this.btnReiniciar.Name = "btnReiniciar";
            this.btnReiniciar.Size = new System.Drawing.Size(140, 30);
            this.btnReiniciar.TabIndex = 85;
            this.btnReiniciar.Text = "Actualizar";
            this.btnReiniciar.UseVisualStyleBackColor = false;
            this.btnReiniciar.Click += new System.EventHandler(this.btnReiniciar_Click);
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
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI Light", 12F);
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGuardar.Location = new System.Drawing.Point(1212, 80);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(140, 30);
            this.btnGuardar.TabIndex = 84;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAgregar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnAgregar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregar.Enabled = false;
            this.btnAgregar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnAgregar.FlatAppearance.BorderSize = 0;
            this.btnAgregar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnAgregar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregar.Font = new System.Drawing.Font("Segoe UI Light", 12F);
            this.btnAgregar.ForeColor = System.Drawing.Color.White;
            this.btnAgregar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAgregar.Location = new System.Drawing.Point(1212, 148);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(140, 30);
            this.btnAgregar.TabIndex = 5;
            this.btnAgregar.Text = "Agregar/Modificar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // txtCantidad
            // 
            this.txtCantidad.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtCantidad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCantidad.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCantidad.FocusColor = System.Drawing.Color.Empty;
            this.txtCantidad.Font = new System.Drawing.Font("Segoe UI Light", 12F);
            this.txtCantidad.ForeColor = System.Drawing.Color.DimGray;
            this.txtCantidad.Location = new System.Drawing.Point(775, 135);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Numerico = true;
            this.txtCantidad.Size = new System.Drawing.Size(100, 29);
            this.txtCantidad.TabIndex = 4;
            this.txtCantidad.Tag = "\"\"";
            // 
            // txtBuscadorArts
            // 
            this.txtBuscadorArts.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtBuscadorArts.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBuscadorArts.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBuscadorArts.FocusColor = System.Drawing.Color.Empty;
            this.txtBuscadorArts.Font = new System.Drawing.Font("Segoe UI Light", 12F);
            this.txtBuscadorArts.ForeColor = System.Drawing.Color.DimGray;
            this.txtBuscadorArts.Location = new System.Drawing.Point(135, 164);
            this.txtBuscadorArts.Name = "txtBuscadorArts";
            this.txtBuscadorArts.Numerico = false;
            this.txtBuscadorArts.Size = new System.Drawing.Size(256, 29);
            this.txtBuscadorArts.TabIndex = 2;
            this.txtBuscadorArts.Tag = "\"\"";
            this.txtBuscadorArts.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBuscadorArts_KeyDown);
            // 
            // btnBuscarArt
            // 
            this.btnBuscarArt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnBuscarArt.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscarArt.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(84)))), ((int)(((byte)(101)))));
            this.btnBuscarArt.FlatAppearance.BorderSize = 0;
            this.btnBuscarArt.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(84)))), ((int)(((byte)(101)))));
            this.btnBuscarArt.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            this.btnBuscarArt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarArt.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscarArt.ForeColor = System.Drawing.Color.White;
            this.btnBuscarArt.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBuscarArt.Location = new System.Drawing.Point(573, 161);
            this.btnBuscarArt.Name = "btnBuscarArt";
            this.btnBuscarArt.Size = new System.Drawing.Size(93, 30);
            this.btnBuscarArt.TabIndex = 3;
            this.btnBuscarArt.Text = "Seleccionar";
            this.btnBuscarArt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscarArt.UseVisualStyleBackColor = false;
            this.btnBuscarArt.Click += new System.EventHandler(this.btnBuscarArt_Click);
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AllowUserToOrderColumns = true;
            this.dgv.AllowUserToResizeRows = false;
            this.dgv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv.BackgroundColor = System.Drawing.Color.White;
            this.dgv.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.LightSlateGray;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgv.ColumnHeadersHeight = 40;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgv.EnableHeadersVisualStyles = false;
            this.dgv.GridColor = System.Drawing.Color.WhiteSmoke;
            this.dgv.Location = new System.Drawing.Point(8, 223);
            this.dgv.MultiSelect = false;
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersVisible = false;
            this.dgv.RowHeadersWidth = 50;
            this.dgv.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(1355, 315);
            this.dgv.TabIndex = 71;
            this.dgv.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellEnter);
            // 
            // btnBuscarDest
            // 
            this.btnBuscarDest.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnBuscarDest.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscarDest.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(84)))), ((int)(((byte)(101)))));
            this.btnBuscarDest.FlatAppearance.BorderSize = 0;
            this.btnBuscarDest.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(84)))), ((int)(((byte)(101)))));
            this.btnBuscarDest.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            this.btnBuscarDest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarDest.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscarDest.ForeColor = System.Drawing.Color.White;
            this.btnBuscarDest.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBuscarDest.Location = new System.Drawing.Point(573, 88);
            this.btnBuscarDest.Name = "btnBuscarDest";
            this.btnBuscarDest.Size = new System.Drawing.Size(93, 30);
            this.btnBuscarDest.TabIndex = 1;
            this.btnBuscarDest.Text = "Seleccionar";
            this.btnBuscarDest.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscarDest.UseVisualStyleBackColor = false;
            this.btnBuscarDest.Click += new System.EventHandler(this.btnBuscarDest_Click);
            // 
            // cboTipoDestino
            // 
            this.cboTipoDestino.BorderColor = System.Drawing.Color.Gainsboro;
            this.cboTipoDestino.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoDestino.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboTipoDestino.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTipoDestino.FormattingEnabled = true;
            this.cboTipoDestino.Items.AddRange(new object[] {
            "AREAS",
            "PERSONAL",
            "MOVIL"});
            this.cboTipoDestino.Location = new System.Drawing.Point(135, 85);
            this.cboTipoDestino.Name = "cboTipoDestino";
            this.cboTipoDestino.Size = new System.Drawing.Size(186, 29);
            this.cboTipoDestino.TabIndex = 0;
            this.cboTipoDestino.SelectedIndexChanged += new System.EventHandler(this.cboTipoDestino_SelectedIndexChanged);
            // 
            // rbAsignar
            // 
            this.rbAsignar.AutoSize = true;
            this.rbAsignar.Checked = true;
            this.rbAsignar.Location = new System.Drawing.Point(698, 104);
            this.rbAsignar.Name = "rbAsignar";
            this.rbAsignar.Size = new System.Drawing.Size(81, 25);
            this.rbAsignar.TabIndex = 94;
            this.rbAsignar.TabStop = true;
            this.rbAsignar.Text = "Asignar";
            this.rbAsignar.UseVisualStyleBackColor = true;
            // 
            // rbDevolver
            // 
            this.rbDevolver.AutoSize = true;
            this.rbDevolver.Location = new System.Drawing.Point(785, 104);
            this.rbDevolver.Name = "rbDevolver";
            this.rbDevolver.Size = new System.Drawing.Size(90, 25);
            this.rbDevolver.TabIndex = 95;
            this.rbDevolver.Text = "Devolver";
            this.rbDevolver.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.rbEquipo);
            this.panel2.Controls.Add(this.rbArticulo);
            this.panel2.Location = new System.Drawing.Point(136, 120);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(185, 38);
            this.panel2.TabIndex = 96;
            // 
            // rbEquipo
            // 
            this.rbEquipo.AutoSize = true;
            this.rbEquipo.Location = new System.Drawing.Point(91, 3);
            this.rbEquipo.Name = "rbEquipo";
            this.rbEquipo.Size = new System.Drawing.Size(76, 25);
            this.rbEquipo.TabIndex = 1;
            this.rbEquipo.Text = "Equipo";
            this.rbEquipo.UseVisualStyleBackColor = true;
            this.rbEquipo.CheckedChanged += new System.EventHandler(this.rbEquipo_CheckedChanged);
            // 
            // rbArticulo
            // 
            this.rbArticulo.AutoSize = true;
            this.rbArticulo.Checked = true;
            this.rbArticulo.Location = new System.Drawing.Point(3, 3);
            this.rbArticulo.Name = "rbArticulo";
            this.rbArticulo.Size = new System.Drawing.Size(82, 25);
            this.rbArticulo.TabIndex = 0;
            this.rbArticulo.TabStop = true;
            this.rbArticulo.Text = "Articulo";
            this.rbArticulo.UseVisualStyleBackColor = true;
            this.rbArticulo.CheckedChanged += new System.EventHandler(this.rbArticulo_CheckedChanged);
            // 
            // FrmMovimientosArt
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1364, 574);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.rbDevolver);
            this.Controls.Add(this.rbAsignar);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnSacar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnReiniciar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.txtCantidad);
            this.Controls.Add(this.txtBuscadorArts);
            this.Controls.Add(this.lblArticulo);
            this.Controls.Add(this.btnBuscarArt);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblDestinatario);
            this.Controls.Add(this.pnFooter);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.btnBuscarDest);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboTipoDestino);
            this.Controls.Add(this.lblTipoServ);
            this.Controls.Add(this.pnLine);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "FrmMovimientosArt";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.FrmMovimientosArt_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmMovimientosArt_KeyDown);
            this.pnLine.ResumeLayout(false);
            this.pnLine.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgReturn)).EndInit();
            this.pnFooter.ResumeLayout(false);
            this.pnFooter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnLine;
        private System.Windows.Forms.PictureBox imgReturn;
        private System.Windows.Forms.Label lblTituloHeader;
        private Controles.combo cboTipoDestino;
        private System.Windows.Forms.Label lblTipoServ;
        private System.Windows.Forms.Label label1;
        private Controles.boton btnBuscarDest;
        private System.Windows.Forms.Panel pnFooter;
        private System.Windows.Forms.Label lblTotal;
        private Controles.dgv dgv;
        private System.Windows.Forms.Label lblDestinatario;
        private System.Windows.Forms.Label lblArticulo;
        private Controles.boton btnBuscarArt;
        private System.Windows.Forms.Label label3;
        private textboxAdv txtBuscadorArts;
        private Controles.boton btnAgregar;
        private textboxAdv txtCantidad;
        private Controles.boton btnGuardar;
        private Controles.boton btnReiniciar;
        private System.Windows.Forms.Label label2;
        private Controles.boton btnSacar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblTotalItems;
        private System.Windows.Forms.RadioButton rbAsignar;
        private System.Windows.Forms.RadioButton rbDevolver;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton rbEquipo;
        private System.Windows.Forms.RadioButton rbArticulo;
    }
}