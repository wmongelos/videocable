namespace CapaPresentacion.Inventario
{
    partial class FrmAgregarArticulos
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
            this.pnlArticulos = new System.Windows.Forms.Panel();
            this.pnlDGVArticulos = new System.Windows.Forms.Panel();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.dgv = new CapaPresentacion.Controles.dgv(this.components);
            this.pnFooter = new System.Windows.Forms.Panel();
            this.lblTotalItems = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pnlSelecArticulo = new System.Windows.Forms.Panel();
            this.btnSiguiente = new CapaPresentacion.Controles.boton();
            this.spImporte = new CapaPresentacion.Controles.spinner(this.components);
            this.btnSacar = new CapaPresentacion.Controles.boton();
            this.btnAgregar = new CapaPresentacion.Controles.boton();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCantidad = new CapaPresentacion.textboxAdv();
            this.label1 = new System.Windows.Forms.Label();
            this.txtArticulosSelec = new CapaPresentacion.textboxAdv();
            this.txtBuscadorArts = new CapaPresentacion.textboxAdv();
            this.btnSelecArt = new CapaPresentacion.Controles.boton();
            this.label2 = new System.Windows.Forms.Label();
            this.spnStock = new CapaPresentacion.Controles.spinner(this.components);
            this.pnlArticulos.SuspendLayout();
            this.pnlDGVArticulos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.pnFooter.SuspendLayout();
            this.pnlSelecArticulo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spImporte)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spnStock)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlArticulos
            // 
            this.pnlArticulos.Controls.Add(this.pnlDGVArticulos);
            this.pnlArticulos.Controls.Add(this.pnFooter);
            this.pnlArticulos.Controls.Add(this.panel2);
            this.pnlArticulos.Controls.Add(this.pnlSelecArticulo);
            this.pnlArticulos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlArticulos.Location = new System.Drawing.Point(0, 0);
            this.pnlArticulos.Name = "pnlArticulos";
            this.pnlArticulos.Size = new System.Drawing.Size(1293, 450);
            this.pnlArticulos.TabIndex = 206;
            // 
            // pnlDGVArticulos
            // 
            this.pnlDGVArticulos.Controls.Add(this.linkLabel1);
            this.pnlDGVArticulos.Controls.Add(this.dgv);
            this.pnlDGVArticulos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDGVArticulos.Location = new System.Drawing.Point(0, 101);
            this.pnlDGVArticulos.Name = "pnlDGVArticulos";
            this.pnlDGVArticulos.Size = new System.Drawing.Size(1293, 319);
            this.pnlDGVArticulos.TabIndex = 74;
            // 
            // linkLabel1
            // 
            this.linkLabel1.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.linkLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.linkLabel1.Location = new System.Drawing.Point(5, 295);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(152, 17);
            this.linkLabel1.TabIndex = 1;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "*Agregar artículo nuevo*";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked_1);
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
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSlateGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI Light", 14F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgv.EnableHeadersVisualStyles = false;
            this.dgv.GridColor = System.Drawing.Color.WhiteSmoke;
            this.dgv.Location = new System.Drawing.Point(7, 20);
            this.dgv.MultiSelect = false;
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersVisible = false;
            this.dgv.RowHeadersWidth = 50;
            this.dgv.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(1278, 270);
            this.dgv.TabIndex = 0;
            this.dgv.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellEnter);
            this.dgv.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgv_RowsAdded);
            // 
            // pnFooter
            // 
            this.pnFooter.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnFooter.Controls.Add(this.lblTotalItems);
            this.pnFooter.Controls.Add(this.lblTotal);
            this.pnFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnFooter.Location = new System.Drawing.Point(0, 420);
            this.pnFooter.Name = "pnFooter";
            this.pnFooter.Size = new System.Drawing.Size(1293, 30);
            this.pnFooter.TabIndex = 73;
            // 
            // lblTotalItems
            // 
            this.lblTotalItems.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalItems.AutoSize = true;
            this.lblTotalItems.Font = new System.Drawing.Font("Segoe UI Light", 12F);
            this.lblTotalItems.ForeColor = System.Drawing.Color.SlateGray;
            this.lblTotalItems.Location = new System.Drawing.Point(1154, 2);
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
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 100);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1293, 1);
            this.panel2.TabIndex = 1;
            // 
            // pnlSelecArticulo
            // 
            this.pnlSelecArticulo.Controls.Add(this.spnStock);
            this.pnlSelecArticulo.Controls.Add(this.label2);
            this.pnlSelecArticulo.Controls.Add(this.btnSiguiente);
            this.pnlSelecArticulo.Controls.Add(this.spImporte);
            this.pnlSelecArticulo.Controls.Add(this.btnSacar);
            this.pnlSelecArticulo.Controls.Add(this.btnAgregar);
            this.pnlSelecArticulo.Controls.Add(this.label3);
            this.pnlSelecArticulo.Controls.Add(this.txtCantidad);
            this.pnlSelecArticulo.Controls.Add(this.label1);
            this.pnlSelecArticulo.Controls.Add(this.txtArticulosSelec);
            this.pnlSelecArticulo.Controls.Add(this.txtBuscadorArts);
            this.pnlSelecArticulo.Controls.Add(this.btnSelecArt);
            this.pnlSelecArticulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSelecArticulo.Location = new System.Drawing.Point(0, 0);
            this.pnlSelecArticulo.Name = "pnlSelecArticulo";
            this.pnlSelecArticulo.Size = new System.Drawing.Size(1293, 100);
            this.pnlSelecArticulo.TabIndex = 0;
            // 
            // btnSiguiente
            // 
            this.btnSiguiente.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSiguiente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnSiguiente.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSiguiente.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnSiguiente.FlatAppearance.BorderSize = 0;
            this.btnSiguiente.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnSiguiente.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnSiguiente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSiguiente.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSiguiente.ForeColor = System.Drawing.Color.White;
            this.btnSiguiente.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSiguiente.Location = new System.Drawing.Point(1177, 69);
            this.btnSiguiente.Name = "btnSiguiente";
            this.btnSiguiente.Size = new System.Drawing.Size(113, 29);
            this.btnSiguiente.TabIndex = 228;
            this.btnSiguiente.Text = "Confirma";
            this.btnSiguiente.UseVisualStyleBackColor = true;
            this.btnSiguiente.Click += new System.EventHandler(this.btnSiguiente_Click);
            // 
            // spImporte
            // 
            this.spImporte.BorderColor = System.Drawing.Color.Empty;
            this.spImporte.DecimalPlaces = 2;
            this.spImporte.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spImporte.Location = new System.Drawing.Point(855, 16);
            this.spImporte.Maximum = new decimal(new int[] {
            1661992959,
            1808227885,
            5,
            131072});
            this.spImporte.Name = "spImporte";
            this.spImporte.Size = new System.Drawing.Size(85, 29);
            this.spImporte.TabIndex = 3;
            this.spImporte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnSacar
            // 
            this.btnSacar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSacar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnSacar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSacar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnSacar.FlatAppearance.BorderSize = 0;
            this.btnSacar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnSacar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnSacar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSacar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSacar.ForeColor = System.Drawing.Color.White;
            this.btnSacar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSacar.Location = new System.Drawing.Point(1177, 38);
            this.btnSacar.Name = "btnSacar";
            this.btnSacar.Size = new System.Drawing.Size(113, 29);
            this.btnSacar.TabIndex = 227;
            this.btnSacar.Text = "Elimina";
            this.btnSacar.UseVisualStyleBackColor = true;
            this.btnSacar.Click += new System.EventHandler(this.btnSacar_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAgregar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnAgregar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnAgregar.FlatAppearance.BorderSize = 0;
            this.btnAgregar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnAgregar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregar.ForeColor = System.Drawing.Color.White;
            this.btnAgregar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAgregar.Location = new System.Drawing.Point(1177, 3);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(113, 29);
            this.btnAgregar.TabIndex = 4;
            this.btnAgregar.Text = "Agrega/Mod";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(588, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 21);
            this.label3.TabIndex = 224;
            this.label3.Text = "Cantidad:";
            // 
            // txtCantidad
            // 
            this.txtCantidad.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtCantidad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCantidad.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCantidad.FocusColor = System.Drawing.Color.Empty;
            this.txtCantidad.Font = new System.Drawing.Font("Segoe UI Light", 12F);
            this.txtCantidad.ForeColor = System.Drawing.Color.DimGray;
            this.txtCantidad.Location = new System.Drawing.Point(669, 16);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Numerico = true;
            this.txtCantidad.Size = new System.Drawing.Size(85, 29);
            this.txtCantidad.TabIndex = 2;
            this.txtCantidad.Tag = "\"\"";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(781, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 21);
            this.label1.TabIndex = 222;
            this.label1.Text = "Importe:";
            // 
            // txtArticulosSelec
            // 
            this.txtArticulosSelec.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtArticulosSelec.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtArticulosSelec.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtArticulosSelec.Enabled = false;
            this.txtArticulosSelec.FocusColor = System.Drawing.Color.Empty;
            this.txtArticulosSelec.Font = new System.Drawing.Font("Segoe UI Light", 12F);
            this.txtArticulosSelec.ForeColor = System.Drawing.Color.DimGray;
            this.txtArticulosSelec.Location = new System.Drawing.Point(281, 14);
            this.txtArticulosSelec.Name = "txtArticulosSelec";
            this.txtArticulosSelec.Numerico = false;
            this.txtArticulosSelec.ReadOnly = true;
            this.txtArticulosSelec.Size = new System.Drawing.Size(301, 29);
            this.txtArticulosSelec.TabIndex = 221;
            this.txtArticulosSelec.Tag = "\"\"";
            // 
            // txtBuscadorArts
            // 
            this.txtBuscadorArts.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtBuscadorArts.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBuscadorArts.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBuscadorArts.FocusColor = System.Drawing.Color.Empty;
            this.txtBuscadorArts.Font = new System.Drawing.Font("Segoe UI Light", 12F);
            this.txtBuscadorArts.ForeColor = System.Drawing.Color.DimGray;
            this.txtBuscadorArts.Location = new System.Drawing.Point(11, 14);
            this.txtBuscadorArts.Name = "txtBuscadorArts";
            this.txtBuscadorArts.Numerico = false;
            this.txtBuscadorArts.Size = new System.Drawing.Size(156, 29);
            this.txtBuscadorArts.TabIndex = 0;
            this.txtBuscadorArts.Tag = "\"\"";
            // 
            // btnSelecArt
            // 
            this.btnSelecArt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnSelecArt.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSelecArt.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnSelecArt.FlatAppearance.BorderSize = 0;
            this.btnSelecArt.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnSelecArt.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnSelecArt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelecArt.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelecArt.ForeColor = System.Drawing.Color.White;
            this.btnSelecArt.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSelecArt.Location = new System.Drawing.Point(173, 14);
            this.btnSelecArt.Name = "btnSelecArt";
            this.btnSelecArt.Size = new System.Drawing.Size(102, 29);
            this.btnSelecArt.TabIndex = 1;
            this.btnSelecArt.Text = "Seleccionar";
            this.btnSelecArt.UseVisualStyleBackColor = true;
            this.btnSelecArt.Click += new System.EventHandler(this.btnSelecArt_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(967, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 21);
            this.label2.TabIndex = 229;
            this.label2.Text = "Stock:";
            // 
            // spnStock
            // 
            this.spnStock.BorderColor = System.Drawing.Color.Empty;
            this.spnStock.DecimalPlaces = 2;
            this.spnStock.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spnStock.Location = new System.Drawing.Point(1023, 16);
            this.spnStock.Maximum = new decimal(new int[] {
            1661992959,
            1808227885,
            5,
            131072});
            this.spnStock.Name = "spnStock";
            this.spnStock.Size = new System.Drawing.Size(85, 29);
            this.spnStock.TabIndex = 230;
            this.spnStock.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // FrmAgregarArticulos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1293, 450);
            this.Controls.Add(this.pnlArticulos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmAgregarArticulos";
            this.Text = "FrmAgregarArticulos";
            this.pnlArticulos.ResumeLayout(false);
            this.pnlDGVArticulos.ResumeLayout(false);
            this.pnlDGVArticulos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.pnFooter.ResumeLayout(false);
            this.pnFooter.PerformLayout();
            this.pnlSelecArticulo.ResumeLayout(false);
            this.pnlSelecArticulo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spImporte)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spnStock)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnlDGVArticulos;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private Controles.dgv dgv;
        private System.Windows.Forms.Panel pnFooter;
        private System.Windows.Forms.Label lblTotalItems;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel pnlSelecArticulo;
        private Controles.spinner spImporte;
        private Controles.boton btnSacar;
        private Controles.boton btnAgregar;
        private System.Windows.Forms.Label label3;
        private textboxAdv txtCantidad;
        private System.Windows.Forms.Label label1;
        private textboxAdv txtArticulosSelec;
        private textboxAdv txtBuscadorArts;
        private Controles.boton btnSelecArt;
        private System.Windows.Forms.Panel pnlArticulos;
        private Controles.boton btnSiguiente;
        private Controles.spinner spnStock;
        private System.Windows.Forms.Label label2;
    }
}