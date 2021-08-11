namespace CapaPresentacion.Cuenta_Corriente
{
    partial class frmUsuariosCtaCteNovedades
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
            this.pnLinea1 = new System.Windows.Forms.Panel();
            this.lbTitulo = new System.Windows.Forms.Label();
            this.imgReturn = new System.Windows.Forms.PictureBox();
            this.lblocalidad = new System.Windows.Forms.Label();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.lblLocaciones = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cboTipoFacturacion = new CapaPresentacion.Controles.combo(this.components);
            this.lblTipoFacturacion = new System.Windows.Forms.Label();
            this.cboUsuario = new CapaPresentacion.Controles.combo(this.components);
            this.lblUsuarioSel = new System.Windows.Forms.Label();
            this.cboLocaciones = new CapaPresentacion.Controles.combo(this.components);
            this.cboServicios = new CapaPresentacion.Controles.combo(this.components);
            this.lblServicios = new System.Windows.Forms.Label();
            this.lblReferencias = new System.Windows.Forms.Label();
            this.pnlRef = new System.Windows.Forms.Panel();
            this.lblTotalReg = new System.Windows.Forms.Label();
            this.lblTodosServicios = new System.Windows.Forms.Label();
            this.lblTodasLocaciones = new System.Windows.Forms.Label();
            this.lblDetalle = new System.Windows.Forms.Label();
            this.btnElimina = new CapaPresentacion.Controles.boton();
            this.btnEdita = new CapaPresentacion.Controles.boton();
            this.btnNuevo = new CapaPresentacion.Controles.boton();
            this.DgvNovedades = new CapaPresentacion.Controles.dgv(this.components);
            this.pgCircular = new CapaPresentacion.Controles.progress();
            this.btnBuscar = new CapaPresentacion.Controles.boton();
            this.pnLinea1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgReturn)).BeginInit();
            this.panel1.SuspendLayout();
            this.pnlRef.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvNovedades)).BeginInit();
            this.SuspendLayout();
            // 
            // pnLinea1
            // 
            this.pnLinea1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.pnLinea1.Controls.Add(this.lbTitulo);
            this.pnLinea1.Controls.Add(this.imgReturn);
            this.pnLinea1.Controls.Add(this.lblocalidad);
            this.pnLinea1.Controls.Add(this.lblUsuario);
            this.pnLinea1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnLinea1.Location = new System.Drawing.Point(0, 0);
            this.pnLinea1.Name = "pnLinea1";
            this.pnLinea1.Size = new System.Drawing.Size(900, 58);
            this.pnLinea1.TabIndex = 42;
            // 
            // lbTitulo
            // 
            this.lbTitulo.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitulo.ForeColor = System.Drawing.Color.White;
            this.lbTitulo.Location = new System.Drawing.Point(52, 19);
            this.lbTitulo.Name = "lbTitulo";
            this.lbTitulo.Size = new System.Drawing.Size(231, 23);
            this.lbTitulo.TabIndex = 85;
            this.lbTitulo.Text = "Novedades Facturables";
            this.lbTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // imgReturn
            // 
            this.imgReturn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.imgReturn.Image = global::CapaPresentacion.Properties.Resources.Left_Arrow_32;
            this.imgReturn.Location = new System.Drawing.Point(11, 14);
            this.imgReturn.Name = "imgReturn";
            this.imgReturn.Size = new System.Drawing.Size(32, 32);
            this.imgReturn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgReturn.TabIndex = 75;
            this.imgReturn.TabStop = false;
            this.imgReturn.Click += new System.EventHandler(this.imgReturn_Click);
            // 
            // lblocalidad
            // 
            this.lblocalidad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblocalidad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblocalidad.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblocalidad.ForeColor = System.Drawing.Color.White;
            this.lblocalidad.Location = new System.Drawing.Point(517, 32);
            this.lblocalidad.Name = "lblocalidad";
            this.lblocalidad.Size = new System.Drawing.Size(369, 19);
            this.lblocalidad.TabIndex = 70;
            this.lblocalidad.Text = "-";
            this.lblocalidad.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblUsuario
            // 
            this.lblUsuario.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUsuario.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuario.ForeColor = System.Drawing.Color.White;
            this.lblUsuario.Location = new System.Drawing.Point(517, 9);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(369, 23);
            this.lblUsuario.TabIndex = 48;
            this.lblUsuario.Text = "-";
            this.lblUsuario.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblLocaciones
            // 
            this.lblLocaciones.AutoSize = true;
            this.lblLocaciones.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLocaciones.ForeColor = System.Drawing.Color.Black;
            this.lblLocaciones.Location = new System.Drawing.Point(11, 52);
            this.lblLocaciones.Name = "lblLocaciones";
            this.lblLocaciones.Size = new System.Drawing.Size(71, 21);
            this.lblLocaciones.TabIndex = 190;
            this.lblLocaciones.Text = "Locacion";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cboTipoFacturacion);
            this.panel1.Controls.Add(this.lblTipoFacturacion);
            this.panel1.Controls.Add(this.cboUsuario);
            this.panel1.Controls.Add(this.lblUsuarioSel);
            this.panel1.Controls.Add(this.cboLocaciones);
            this.panel1.Controls.Add(this.cboServicios);
            this.panel1.Controls.Add(this.lblServicios);
            this.panel1.Controls.Add(this.lblLocaciones);
            this.panel1.Location = new System.Drawing.Point(13, 108);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(873, 90);
            this.panel1.TabIndex = 191;
            // 
            // cboTipoFacturacion
            // 
            this.cboTipoFacturacion.BorderColor = System.Drawing.Color.DimGray;
            this.cboTipoFacturacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoFacturacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboTipoFacturacion.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTipoFacturacion.FormattingEnabled = true;
            this.cboTipoFacturacion.Location = new System.Drawing.Point(475, 14);
            this.cboTipoFacturacion.Name = "cboTipoFacturacion";
            this.cboTipoFacturacion.Size = new System.Drawing.Size(308, 29);
            this.cboTipoFacturacion.TabIndex = 195;
            this.cboTipoFacturacion.SelectedValueChanged += new System.EventHandler(this.cboTipoFacturacion_SelectedValueChanged);
            // 
            // lblTipoFacturacion
            // 
            this.lblTipoFacturacion.AutoSize = true;
            this.lblTipoFacturacion.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipoFacturacion.ForeColor = System.Drawing.Color.Black;
            this.lblTipoFacturacion.Location = new System.Drawing.Point(402, 17);
            this.lblTipoFacturacion.Name = "lblTipoFacturacion";
            this.lblTipoFacturacion.Size = new System.Drawing.Size(43, 21);
            this.lblTipoFacturacion.TabIndex = 196;
            this.lblTipoFacturacion.Text = "zona";
            // 
            // cboUsuario
            // 
            this.cboUsuario.BorderColor = System.Drawing.Color.DimGray;
            this.cboUsuario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboUsuario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboUsuario.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboUsuario.FormattingEnabled = true;
            this.cboUsuario.Location = new System.Drawing.Point(88, 14);
            this.cboUsuario.Name = "cboUsuario";
            this.cboUsuario.Size = new System.Drawing.Size(308, 29);
            this.cboUsuario.TabIndex = 193;
            this.cboUsuario.SelectedIndexChanged += new System.EventHandler(this.cboUsuario_SelectedIndexChanged);
            this.cboUsuario.SelectedValueChanged += new System.EventHandler(this.cboUsuario_SelectedValueChanged);
            // 
            // lblUsuarioSel
            // 
            this.lblUsuarioSel.AutoSize = true;
            this.lblUsuarioSel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuarioSel.ForeColor = System.Drawing.Color.Black;
            this.lblUsuarioSel.Location = new System.Drawing.Point(18, 17);
            this.lblUsuarioSel.Name = "lblUsuarioSel";
            this.lblUsuarioSel.Size = new System.Drawing.Size(64, 21);
            this.lblUsuarioSel.TabIndex = 194;
            this.lblUsuarioSel.Text = "Usuario";
            // 
            // cboLocaciones
            // 
            this.cboLocaciones.BorderColor = System.Drawing.Color.DimGray;
            this.cboLocaciones.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLocaciones.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboLocaciones.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboLocaciones.FormattingEnabled = true;
            this.cboLocaciones.Location = new System.Drawing.Point(88, 49);
            this.cboLocaciones.Name = "cboLocaciones";
            this.cboLocaciones.Size = new System.Drawing.Size(308, 29);
            this.cboLocaciones.TabIndex = 189;
            this.cboLocaciones.SelectedIndexChanged += new System.EventHandler(this.cboLocaciones_SelectedIndexChanged);
            this.cboLocaciones.SelectedValueChanged += new System.EventHandler(this.cboLocaciones_SelectedValueChanged);
            // 
            // cboServicios
            // 
            this.cboServicios.BorderColor = System.Drawing.Color.DimGray;
            this.cboServicios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboServicios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboServicios.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboServicios.FormattingEnabled = true;
            this.cboServicios.Location = new System.Drawing.Point(475, 49);
            this.cboServicios.Name = "cboServicios";
            this.cboServicios.Size = new System.Drawing.Size(308, 29);
            this.cboServicios.TabIndex = 191;
            this.cboServicios.SelectedValueChanged += new System.EventHandler(this.cboServicios_SelectedValueChanged);
            // 
            // lblServicios
            // 
            this.lblServicios.AutoSize = true;
            this.lblServicios.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblServicios.ForeColor = System.Drawing.Color.Black;
            this.lblServicios.Location = new System.Drawing.Point(402, 52);
            this.lblServicios.Name = "lblServicios";
            this.lblServicios.Size = new System.Drawing.Size(65, 21);
            this.lblServicios.TabIndex = 192;
            this.lblServicios.Text = "Servicio";
            // 
            // lblReferencias
            // 
            this.lblReferencias.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblReferencias.AutoSize = true;
            this.lblReferencias.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReferencias.ForeColor = System.Drawing.Color.Black;
            this.lblReferencias.Location = new System.Drawing.Point(453, 9);
            this.lblReferencias.Name = "lblReferencias";
            this.lblReferencias.Size = new System.Drawing.Size(90, 21);
            this.lblReferencias.TabIndex = 193;
            this.lblReferencias.Text = "Referencias";
            // 
            // pnlRef
            // 
            this.pnlRef.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlRef.Controls.Add(this.lblTotalReg);
            this.pnlRef.Controls.Add(this.lblTodosServicios);
            this.pnlRef.Controls.Add(this.lblTodasLocaciones);
            this.pnlRef.Controls.Add(this.lblReferencias);
            this.pnlRef.Location = new System.Drawing.Point(9, 517);
            this.pnlRef.Name = "pnlRef";
            this.pnlRef.Size = new System.Drawing.Size(841, 39);
            this.pnlRef.TabIndex = 194;
            // 
            // lblTotalReg
            // 
            this.lblTotalReg.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblTotalReg.AutoSize = true;
            this.lblTotalReg.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblTotalReg.ForeColor = System.Drawing.Color.Black;
            this.lblTotalReg.Location = new System.Drawing.Point(4, 12);
            this.lblTotalReg.Name = "lblTotalReg";
            this.lblTotalReg.Size = new System.Drawing.Size(121, 19);
            this.lblTotalReg.TabIndex = 196;
            this.lblTotalReg.Text = "Total de registros: ";
            // 
            // lblTodosServicios
            // 
            this.lblTodosServicios.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblTodosServicios.AutoSize = true;
            this.lblTodosServicios.BackColor = System.Drawing.Color.LightBlue;
            this.lblTodosServicios.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTodosServicios.ForeColor = System.Drawing.Color.Black;
            this.lblTodosServicios.Location = new System.Drawing.Point(699, 9);
            this.lblTodosServicios.Name = "lblTodosServicios";
            this.lblTodosServicios.Size = new System.Drawing.Size(138, 21);
            this.lblTodosServicios.TabIndex = 195;
            this.lblTodosServicios.Text = "Todos los servicios";
            // 
            // lblTodasLocaciones
            // 
            this.lblTodasLocaciones.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblTodasLocaciones.AutoSize = true;
            this.lblTodasLocaciones.BackColor = System.Drawing.Color.LightGreen;
            this.lblTodasLocaciones.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTodasLocaciones.ForeColor = System.Drawing.Color.Black;
            this.lblTodasLocaciones.Location = new System.Drawing.Point(549, 9);
            this.lblTodasLocaciones.Name = "lblTodasLocaciones";
            this.lblTodasLocaciones.Size = new System.Drawing.Size(148, 21);
            this.lblTodasLocaciones.TabIndex = 194;
            this.lblTodasLocaciones.Text = "Todas las locaciones";
            // 
            // lblDetalle
            // 
            this.lblDetalle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblDetalle.AutoSize = true;
            this.lblDetalle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblDetalle.ForeColor = System.Drawing.Color.Black;
            this.lblDetalle.Location = new System.Drawing.Point(9, 459);
            this.lblDetalle.Name = "lblDetalle";
            this.lblDetalle.Size = new System.Drawing.Size(58, 19);
            this.lblDetalle.TabIndex = 197;
            this.lblDetalle.Text = "Detalle: ";
            this.lblDetalle.Visible = false;
            // 
            // btnElimina
            // 
            this.btnElimina.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnElimina.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnElimina.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnElimina.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnElimina.FlatAppearance.BorderSize = 0;
            this.btnElimina.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnElimina.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnElimina.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnElimina.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnElimina.ForeColor = System.Drawing.Color.White;
            this.btnElimina.Image = global::CapaPresentacion.Properties.Resources.Data_Delete_32;
            this.btnElimina.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnElimina.Location = new System.Drawing.Point(684, 64);
            this.btnElimina.Name = "btnElimina";
            this.btnElimina.Size = new System.Drawing.Size(98, 36);
            this.btnElimina.TabIndex = 87;
            this.btnElimina.Text = "Elimina";
            this.btnElimina.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnElimina.UseVisualStyleBackColor = false;
            this.btnElimina.Click += new System.EventHandler(this.btnElimina_Click);
            // 
            // btnEdita
            // 
            this.btnEdita.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdita.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnEdita.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEdita.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnEdita.FlatAppearance.BorderSize = 0;
            this.btnEdita.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnEdita.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnEdita.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdita.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdita.ForeColor = System.Drawing.Color.White;
            this.btnEdita.Image = global::CapaPresentacion.Properties.Resources.Data_Edit_32;
            this.btnEdita.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEdita.Location = new System.Drawing.Point(587, 65);
            this.btnEdita.Name = "btnEdita";
            this.btnEdita.Size = new System.Drawing.Size(91, 36);
            this.btnEdita.TabIndex = 86;
            this.btnEdita.Text = "Edita";
            this.btnEdita.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEdita.UseVisualStyleBackColor = false;
            this.btnEdita.Click += new System.EventHandler(this.btnEdita_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNuevo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnNuevo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNuevo.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnNuevo.FlatAppearance.BorderSize = 0;
            this.btnNuevo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnNuevo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevo.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevo.ForeColor = System.Drawing.Color.White;
            this.btnNuevo.Image = global::CapaPresentacion.Properties.Resources.Data_Add_32;
            this.btnNuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNuevo.Location = new System.Drawing.Point(480, 65);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(101, 36);
            this.btnNuevo.TabIndex = 85;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNuevo.UseVisualStyleBackColor = false;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // DgvNovedades
            // 
            this.DgvNovedades.AllowUserToAddRows = false;
            this.DgvNovedades.AllowUserToDeleteRows = false;
            this.DgvNovedades.AllowUserToOrderColumns = true;
            this.DgvNovedades.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DgvNovedades.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DgvNovedades.BackgroundColor = System.Drawing.Color.White;
            this.DgvNovedades.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.DgvNovedades.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSlateGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvNovedades.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DgvNovedades.ColumnHeadersHeight = 40;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DgvNovedades.DefaultCellStyle = dataGridViewCellStyle2;
            this.DgvNovedades.EnableHeadersVisualStyles = false;
            this.DgvNovedades.GridColor = System.Drawing.Color.WhiteSmoke;
            this.DgvNovedades.Location = new System.Drawing.Point(9, 204);
            this.DgvNovedades.MultiSelect = false;
            this.DgvNovedades.Name = "DgvNovedades";
            this.DgvNovedades.ReadOnly = true;
            this.DgvNovedades.RowHeadersVisible = false;
            this.DgvNovedades.RowHeadersWidth = 50;
            this.DgvNovedades.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DgvNovedades.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvNovedades.Size = new System.Drawing.Size(879, 252);
            this.DgvNovedades.TabIndex = 44;
            this.DgvNovedades.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvNovedades_CellClick);
            this.DgvNovedades.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.DgvNovedades_RowPostPaint);
            this.DgvNovedades.Leave += new System.EventHandler(this.DgvNovedades_Leave);
            // 
            // pgCircular
            // 
            this.pgCircular.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pgCircular.Location = new System.Drawing.Point(862, 526);
            this.pgCircular.Name = "pgCircular";
            this.pgCircular.Percentage = 0F;
            this.pgCircular.Rotation = CapaPresentacion.Controles.RotationType.CounterClockwise;
            this.pgCircular.Size = new System.Drawing.Size(24, 24);
            this.pgCircular.TabIndex = 1;
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
            this.btnBuscar.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.ForeColor = System.Drawing.Color.White;
            this.btnBuscar.Image = global::CapaPresentacion.Properties.Resources.lupa;
            this.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBuscar.Location = new System.Drawing.Point(785, 64);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(101, 36);
            this.btnBuscar.TabIndex = 198;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscar.UseVisualStyleBackColor = false;
            // 
            // frmUsuariosCtaCteNovedades
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 565);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.lblDetalle);
            this.Controls.Add(this.pnlRef);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnElimina);
            this.Controls.Add(this.btnEdita);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.DgvNovedades);
            this.Controls.Add(this.pnLinea1);
            this.Controls.Add(this.pgCircular);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "frmUsuariosCtaCteNovedades";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmUsuariosCtaCteNovedades";
            this.Load += new System.EventHandler(this.frmUsuariosCtaCteNovedades_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmUsuariosCtaCteNovedades_KeyDown);
            this.pnLinea1.ResumeLayout(false);
            this.pnLinea1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgReturn)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlRef.ResumeLayout(false);
            this.pnlRef.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvNovedades)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controles.progress pgCircular;
        private System.Windows.Forms.Panel pnLinea1;
        private System.Windows.Forms.PictureBox imgReturn;
        private System.Windows.Forms.Label lblocalidad;
        private System.Windows.Forms.Label lblUsuario;
        private Controles.dgv DgvNovedades;
        private Controles.boton btnNuevo;
        private Controles.boton btnEdita;
        private Controles.boton btnElimina;
        private System.Windows.Forms.Label lbTitulo;
        private Controles.combo cboLocaciones;
        private System.Windows.Forms.Label lblLocaciones;
        private System.Windows.Forms.Panel panel1;
        private Controles.combo cboServicios;
        private System.Windows.Forms.Label lblServicios;
        private System.Windows.Forms.Label lblReferencias;
        private System.Windows.Forms.Panel pnlRef;
        private System.Windows.Forms.Label lblTodosServicios;
        private System.Windows.Forms.Label lblTodasLocaciones;
        private System.Windows.Forms.Label lblTotalReg;
        private System.Windows.Forms.Label lblDetalle;
        private Controles.combo cboUsuario;
        private System.Windows.Forms.Label lblUsuarioSel;
        private Controles.combo cboTipoFacturacion;
        private System.Windows.Forms.Label lblTipoFacturacion;
        private Controles.boton btnBuscar;
    }
}