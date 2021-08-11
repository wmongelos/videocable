namespace CapaPresentacion.Inventario
{
    partial class FrmAgregarEquipos
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
            this.pnlEquipos = new System.Windows.Forms.Panel();
            this.btnIntroducirEquipos = new CapaPresentacion.Controles.boton();
            this.txtCantidad = new CapaPresentacion.textboxAdv();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.spImporte = new CapaPresentacion.Controles.spinner(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.btnModificar = new CapaPresentacion.Controles.boton();
            this.pnFooter = new System.Windows.Forms.Panel();
            this.lblTotal = new System.Windows.Forms.Label();
            this.btnSiguiente = new CapaPresentacion.Controles.boton();
            this.btnSacar = new CapaPresentacion.Controles.boton();
            this.btnAgregar = new CapaPresentacion.Controles.boton();
            this.dgv = new CapaPresentacion.Controles.dgv(this.components);
            this.llAddMarca = new System.Windows.Forms.LinkLabel();
            this.llAddModelo = new System.Windows.Forms.LinkLabel();
            this.llAddTipo = new System.Windows.Forms.LinkLabel();
            this.cboModeloEquipos = new CapaPresentacion.Controles.combo(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.cboMarcaEquipos = new CapaPresentacion.Controles.combo(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.cboTipoEquipos = new CapaPresentacion.Controles.combo(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.pnlEquipos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spImporte)).BeginInit();
            this.pnFooter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlEquipos
            // 
            this.pnlEquipos.Controls.Add(this.btnIntroducirEquipos);
            this.pnlEquipos.Controls.Add(this.txtCantidad);
            this.pnlEquipos.Controls.Add(this.label4);
            this.pnlEquipos.Controls.Add(this.panel1);
            this.pnlEquipos.Controls.Add(this.spImporte);
            this.pnlEquipos.Controls.Add(this.label6);
            this.pnlEquipos.Controls.Add(this.btnModificar);
            this.pnlEquipos.Controls.Add(this.pnFooter);
            this.pnlEquipos.Controls.Add(this.btnSiguiente);
            this.pnlEquipos.Controls.Add(this.btnSacar);
            this.pnlEquipos.Controls.Add(this.btnAgregar);
            this.pnlEquipos.Controls.Add(this.dgv);
            this.pnlEquipos.Controls.Add(this.llAddMarca);
            this.pnlEquipos.Controls.Add(this.llAddModelo);
            this.pnlEquipos.Controls.Add(this.llAddTipo);
            this.pnlEquipos.Controls.Add(this.cboModeloEquipos);
            this.pnlEquipos.Controls.Add(this.label2);
            this.pnlEquipos.Controls.Add(this.cboMarcaEquipos);
            this.pnlEquipos.Controls.Add(this.label1);
            this.pnlEquipos.Controls.Add(this.cboTipoEquipos);
            this.pnlEquipos.Controls.Add(this.label3);
            this.pnlEquipos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlEquipos.Location = new System.Drawing.Point(0, 0);
            this.pnlEquipos.Name = "pnlEquipos";
            this.pnlEquipos.Size = new System.Drawing.Size(1035, 450);
            this.pnlEquipos.TabIndex = 0;
            // 
            // btnIntroducirEquipos
            // 
            this.btnIntroducirEquipos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnIntroducirEquipos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnIntroducirEquipos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnIntroducirEquipos.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnIntroducirEquipos.FlatAppearance.BorderSize = 0;
            this.btnIntroducirEquipos.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnIntroducirEquipos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnIntroducirEquipos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIntroducirEquipos.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIntroducirEquipos.ForeColor = System.Drawing.Color.White;
            this.btnIntroducirEquipos.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnIntroducirEquipos.Location = new System.Drawing.Point(813, 7);
            this.btnIntroducirEquipos.Name = "btnIntroducirEquipos";
            this.btnIntroducirEquipos.Size = new System.Drawing.Size(100, 29);
            this.btnIntroducirEquipos.TabIndex = 258;
            this.btnIntroducirEquipos.Text = "Serie/Mac";
            this.btnIntroducirEquipos.UseVisualStyleBackColor = true;
            this.btnIntroducirEquipos.Click += new System.EventHandler(this.btnIntroducirEquipos_Click);
            // 
            // txtCantidad
            // 
            this.txtCantidad.BorderColor = System.Drawing.Color.Empty;
            this.txtCantidad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCantidad.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCantidad.FocusColor = System.Drawing.Color.Empty;
            this.txtCantidad.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCantidad.Location = new System.Drawing.Point(522, 9);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Numerico = true;
            this.txtCantidad.Size = new System.Drawing.Size(116, 29);
            this.txtCantidad.TabIndex = 257;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(441, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 21);
            this.label4.TabIndex = 256;
            this.label4.Text = "Cantidad:";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(0, 118);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1035, 1);
            this.panel1.TabIndex = 255;
            // 
            // spImporte
            // 
            this.spImporte.BorderColor = System.Drawing.Color.Empty;
            this.spImporte.DecimalPlaces = 2;
            this.spImporte.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spImporte.Location = new System.Drawing.Point(522, 45);
            this.spImporte.Maximum = new decimal(new int[] {
            1661992959,
            1808227885,
            5,
            131072});
            this.spImporte.Name = "spImporte";
            this.spImporte.Size = new System.Drawing.Size(116, 29);
            this.spImporte.TabIndex = 253;
            this.spImporte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(441, 48);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 21);
            this.label6.TabIndex = 254;
            this.label6.Text = "Importe:";
            // 
            // btnModificar
            // 
            this.btnModificar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnModificar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnModificar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnModificar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnModificar.FlatAppearance.BorderSize = 0;
            this.btnModificar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnModificar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnModificar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModificar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModificar.ForeColor = System.Drawing.Color.White;
            this.btnModificar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnModificar.Location = new System.Drawing.Point(813, 40);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(100, 29);
            this.btnModificar.TabIndex = 252;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // pnFooter
            // 
            this.pnFooter.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnFooter.Controls.Add(this.lblTotal);
            this.pnFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnFooter.Location = new System.Drawing.Point(0, 420);
            this.pnFooter.Name = "pnFooter";
            this.pnFooter.Size = new System.Drawing.Size(1035, 30);
            this.pnFooter.TabIndex = 251;
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
            this.btnSiguiente.Location = new System.Drawing.Point(919, 71);
            this.btnSiguiente.Name = "btnSiguiente";
            this.btnSiguiente.Size = new System.Drawing.Size(95, 29);
            this.btnSiguiente.TabIndex = 250;
            this.btnSiguiente.Text = "Confirma";
            this.btnSiguiente.UseVisualStyleBackColor = true;
            this.btnSiguiente.Click += new System.EventHandler(this.btnSiguiente_Click);
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
            this.btnSacar.Location = new System.Drawing.Point(919, 40);
            this.btnSacar.Name = "btnSacar";
            this.btnSacar.Size = new System.Drawing.Size(95, 29);
            this.btnSacar.TabIndex = 249;
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
            this.btnAgregar.Location = new System.Drawing.Point(919, 8);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(95, 29);
            this.btnAgregar.TabIndex = 248;
            this.btnAgregar.Text = "Agrega";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
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
            this.dgv.Location = new System.Drawing.Point(7, 126);
            this.dgv.MultiSelect = false;
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersVisible = false;
            this.dgv.RowHeadersWidth = 50;
            this.dgv.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(1021, 288);
            this.dgv.TabIndex = 243;
            this.dgv.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellEnter);
            this.dgv.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgv_RowsAdded);
            // 
            // llAddMarca
            // 
            this.llAddMarca.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.llAddMarca.AutoSize = true;
            this.llAddMarca.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llAddMarca.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.llAddMarca.Location = new System.Drawing.Point(399, 48);
            this.llAddMarca.Name = "llAddMarca";
            this.llAddMarca.Size = new System.Drawing.Size(25, 17);
            this.llAddMarca.TabIndex = 242;
            this.llAddMarca.TabStop = true;
            this.llAddMarca.Text = "(+)";
            this.llAddMarca.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llAddMarca_LinkClicked);
            // 
            // llAddModelo
            // 
            this.llAddModelo.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.llAddModelo.AutoSize = true;
            this.llAddModelo.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llAddModelo.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.llAddModelo.Location = new System.Drawing.Point(399, 83);
            this.llAddModelo.Name = "llAddModelo";
            this.llAddModelo.Size = new System.Drawing.Size(25, 17);
            this.llAddModelo.TabIndex = 241;
            this.llAddModelo.TabStop = true;
            this.llAddModelo.Text = "(+)";
            this.llAddModelo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llAddModelo_LinkClicked);
            // 
            // llAddTipo
            // 
            this.llAddTipo.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.llAddTipo.AutoSize = true;
            this.llAddTipo.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llAddTipo.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.llAddTipo.Location = new System.Drawing.Point(399, 12);
            this.llAddTipo.Name = "llAddTipo";
            this.llAddTipo.Size = new System.Drawing.Size(25, 17);
            this.llAddTipo.TabIndex = 240;
            this.llAddTipo.TabStop = true;
            this.llAddTipo.Text = "(+)";
            this.llAddTipo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llAddTipo_LinkClicked);
            // 
            // cboModeloEquipos
            // 
            this.cboModeloEquipos.BorderColor = System.Drawing.Color.Empty;
            this.cboModeloEquipos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboModeloEquipos.Enabled = false;
            this.cboModeloEquipos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboModeloEquipos.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboModeloEquipos.FormattingEnabled = true;
            this.cboModeloEquipos.Location = new System.Drawing.Point(130, 81);
            this.cboModeloEquipos.Name = "cboModeloEquipos";
            this.cboModeloEquipos.Size = new System.Drawing.Size(263, 29);
            this.cboModeloEquipos.TabIndex = 239;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(8, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 21);
            this.label2.TabIndex = 238;
            this.label2.Text = "Modelo equipo:";
            // 
            // cboMarcaEquipos
            // 
            this.cboMarcaEquipos.BorderColor = System.Drawing.Color.Empty;
            this.cboMarcaEquipos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMarcaEquipos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboMarcaEquipos.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboMarcaEquipos.FormattingEnabled = true;
            this.cboMarcaEquipos.Location = new System.Drawing.Point(130, 45);
            this.cboMarcaEquipos.Name = "cboMarcaEquipos";
            this.cboMarcaEquipos.Size = new System.Drawing.Size(263, 29);
            this.cboMarcaEquipos.TabIndex = 237;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(8, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 21);
            this.label1.TabIndex = 236;
            this.label1.Text = "Marca equipo:";
            // 
            // cboTipoEquipos
            // 
            this.cboTipoEquipos.BorderColor = System.Drawing.Color.Empty;
            this.cboTipoEquipos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoEquipos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboTipoEquipos.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTipoEquipos.FormattingEnabled = true;
            this.cboTipoEquipos.Location = new System.Drawing.Point(130, 9);
            this.cboTipoEquipos.Name = "cboTipoEquipos";
            this.cboTipoEquipos.Size = new System.Drawing.Size(263, 29);
            this.cboTipoEquipos.TabIndex = 235;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(8, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 21);
            this.label3.TabIndex = 234;
            this.label3.Text = "Tipo de equipo:";
            // 
            // FrmAgregarEquipos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1035, 450);
            this.Controls.Add(this.pnlEquipos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmAgregarEquipos";
            this.Text = "FrmAgregarEquipos";
            this.pnlEquipos.ResumeLayout(false);
            this.pnlEquipos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spImporte)).EndInit();
            this.pnFooter.ResumeLayout(false);
            this.pnFooter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlEquipos;
        private System.Windows.Forms.LinkLabel llAddMarca;
        private System.Windows.Forms.LinkLabel llAddModelo;
        private System.Windows.Forms.LinkLabel llAddTipo;
        private Controles.combo cboModeloEquipos;
        private System.Windows.Forms.Label label2;
        private Controles.combo cboMarcaEquipos;
        private System.Windows.Forms.Label label1;
        private Controles.combo cboTipoEquipos;
        private System.Windows.Forms.Label label3;
        private Controles.dgv dgv;
        private Controles.boton btnSiguiente;
        private Controles.boton btnSacar;
        private Controles.boton btnAgregar;
        private System.Windows.Forms.Panel pnFooter;
        private System.Windows.Forms.Label lblTotal;
        private Controles.boton btnModificar;
        private System.Windows.Forms.Panel panel1;
        private Controles.spinner spImporte;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private textboxAdv txtCantidad;
        private Controles.boton btnIntroducirEquipos;
    }
}