namespace CapaPresentacion.Abms
{
    partial class ABMUnidadesFuncionales
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.imgReturn = new System.Windows.Forms.PictureBox();
            this.lblTituloHeader = new System.Windows.Forms.Label();
            this.spMain = new System.Windows.Forms.SplitContainer();
            this.pnlCampos = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNombre = new CapaPresentacion.textboxAdv();
            this.lblDetalle = new System.Windows.Forms.Label();
            this.txtDetalle = new CapaPresentacion.textboxAdv();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDepto = new CapaPresentacion.textboxAdv();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPiso = new CapaPresentacion.textboxAdv();
            this.pnlInferior = new System.Windows.Forms.Panel();
            this.pgCircular = new CapaPresentacion.Controles.progress();
            this.btnCancelar = new CapaPresentacion.Controles.boton();
            this.btnGuardar = new CapaPresentacion.Controles.boton();
            this.lblContacto = new System.Windows.Forms.Label();
            this.txtApellido = new CapaPresentacion.textboxAdv();
            this.pnlCantUF = new System.Windows.Forms.Panel();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.pnlBotonera = new System.Windows.Forms.Panel();
            this.btnContratar = new CapaPresentacion.Controles.boton();
            this.btnEliminar = new CapaPresentacion.Controles.boton();
            this.btnEditar = new CapaPresentacion.Controles.boton();
            this.btnNuevo = new CapaPresentacion.Controles.boton();
            this.btnActualizar = new CapaPresentacion.Controles.boton();
            this.dgvPresentacion = new CapaPresentacion.Controles.dgv(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgReturn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spMain)).BeginInit();
            this.spMain.Panel1.SuspendLayout();
            this.spMain.Panel2.SuspendLayout();
            this.spMain.SuspendLayout();
            this.pnlCampos.SuspendLayout();
            this.pnlInferior.SuspendLayout();
            this.pnlCantUF.SuspendLayout();
            this.pnlBotonera.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPresentacion)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.panel1.Controls.Add(this.imgReturn);
            this.panel1.Controls.Add(this.lblTituloHeader);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1071, 75);
            this.panel1.TabIndex = 54;
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
            this.lblTituloHeader.AutoSize = true;
            this.lblTituloHeader.Font = new System.Drawing.Font("Calibri", 21.75F);
            this.lblTituloHeader.ForeColor = System.Drawing.Color.White;
            this.lblTituloHeader.Location = new System.Drawing.Point(53, 18);
            this.lblTituloHeader.Name = "lblTituloHeader";
            this.lblTituloHeader.Size = new System.Drawing.Size(270, 36);
            this.lblTituloHeader.TabIndex = 31;
            this.lblTituloHeader.Text = "Unidades Funcionales";
            // 
            // spMain
            // 
            this.spMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spMain.Location = new System.Drawing.Point(0, 121);
            this.spMain.Name = "spMain";
            // 
            // spMain.Panel1
            // 
            this.spMain.Panel1.Controls.Add(this.pnlCampos);
            // 
            // spMain.Panel2
            // 
            this.spMain.Panel2.Controls.Add(this.dgvPresentacion);
            this.spMain.Panel2.Controls.Add(this.pnlCantUF);
            this.spMain.Size = new System.Drawing.Size(1071, 434);
            this.spMain.SplitterDistance = 460;
            this.spMain.TabIndex = 55;
            // 
            // pnlCampos
            // 
            this.pnlCampos.Controls.Add(this.label3);
            this.pnlCampos.Controls.Add(this.txtNombre);
            this.pnlCampos.Controls.Add(this.lblDetalle);
            this.pnlCampos.Controls.Add(this.txtDetalle);
            this.pnlCampos.Controls.Add(this.label2);
            this.pnlCampos.Controls.Add(this.txtDepto);
            this.pnlCampos.Controls.Add(this.label1);
            this.pnlCampos.Controls.Add(this.txtPiso);
            this.pnlCampos.Controls.Add(this.pnlInferior);
            this.pnlCampos.Controls.Add(this.lblContacto);
            this.pnlCampos.Controls.Add(this.txtApellido);
            this.pnlCampos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCampos.Location = new System.Drawing.Point(0, 0);
            this.pnlCampos.Name = "pnlCampos";
            this.pnlCampos.Size = new System.Drawing.Size(460, 434);
            this.pnlCampos.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(12, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 28);
            this.label3.TabIndex = 51;
            this.label3.Text = "Nombre";
            // 
            // txtNombre
            // 
            this.txtNombre.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtNombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNombre.FocusColor = System.Drawing.Color.Empty;
            this.txtNombre.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.txtNombre.ForeColor = System.Drawing.Color.DimGray;
            this.txtNombre.Location = new System.Drawing.Point(16, 132);
            this.txtNombre.MaxLength = 50;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Numerico = false;
            this.txtNombre.Size = new System.Drawing.Size(345, 34);
            this.txtNombre.TabIndex = 1;
            this.txtNombre.Tag = "\"\"";
            // 
            // lblDetalle
            // 
            this.lblDetalle.AutoSize = true;
            this.lblDetalle.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.lblDetalle.ForeColor = System.Drawing.Color.Black;
            this.lblDetalle.Location = new System.Drawing.Point(11, 259);
            this.lblDetalle.Name = "lblDetalle";
            this.lblDetalle.Size = new System.Drawing.Size(77, 28);
            this.lblDetalle.TabIndex = 49;
            this.lblDetalle.Text = "Detalle:";
            // 
            // txtDetalle
            // 
            this.txtDetalle.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtDetalle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDetalle.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDetalle.FocusColor = System.Drawing.Color.Empty;
            this.txtDetalle.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.txtDetalle.ForeColor = System.Drawing.Color.DimGray;
            this.txtDetalle.Location = new System.Drawing.Point(16, 290);
            this.txtDetalle.MaxLength = 50;
            this.txtDetalle.Multiline = true;
            this.txtDetalle.Name = "txtDetalle";
            this.txtDetalle.Numerico = false;
            this.txtDetalle.Size = new System.Drawing.Size(345, 66);
            this.txtDetalle.TabIndex = 3;
            this.txtDetalle.Tag = "\"\"";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(121, 191);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 28);
            this.label2.TabIndex = 47;
            this.label2.Text = "Depto:";
            // 
            // txtDepto
            // 
            this.txtDepto.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtDepto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDepto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDepto.FocusColor = System.Drawing.Color.Empty;
            this.txtDepto.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.txtDepto.ForeColor = System.Drawing.Color.DimGray;
            this.txtDepto.Location = new System.Drawing.Point(126, 222);
            this.txtDepto.MaxLength = 50;
            this.txtDepto.Name = "txtDepto";
            this.txtDepto.Numerico = false;
            this.txtDepto.Size = new System.Drawing.Size(80, 34);
            this.txtDepto.TabIndex = 2;
            this.txtDepto.Tag = "\"\"";
            this.txtDepto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDepto_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(10, 191);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 28);
            this.label1.TabIndex = 45;
            this.label1.Text = "Piso:";
            // 
            // txtPiso
            // 
            this.txtPiso.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtPiso.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPiso.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPiso.FocusColor = System.Drawing.Color.Empty;
            this.txtPiso.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.txtPiso.ForeColor = System.Drawing.Color.DimGray;
            this.txtPiso.Location = new System.Drawing.Point(16, 222);
            this.txtPiso.MaxLength = 50;
            this.txtPiso.Name = "txtPiso";
            this.txtPiso.Numerico = false;
            this.txtPiso.Size = new System.Drawing.Size(80, 34);
            this.txtPiso.TabIndex = 1;
            this.txtPiso.Tag = "\"\"";
            this.txtPiso.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPiso_KeyPress);
            // 
            // pnlInferior
            // 
            this.pnlInferior.Controls.Add(this.pgCircular);
            this.pnlInferior.Controls.Add(this.btnCancelar);
            this.pnlInferior.Controls.Add(this.btnGuardar);
            this.pnlInferior.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlInferior.Location = new System.Drawing.Point(0, 389);
            this.pnlInferior.Name = "pnlInferior";
            this.pnlInferior.Size = new System.Drawing.Size(460, 45);
            this.pnlInferior.TabIndex = 43;
            this.pnlInferior.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlInferior_Paint);
            // 
            // pgCircular
            // 
            this.pgCircular.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pgCircular.Location = new System.Drawing.Point(3, -3);
            this.pgCircular.Name = "pgCircular";
            this.pgCircular.Percentage = 0F;
            this.pgCircular.Rotation = CapaPresentacion.Controles.RotationType.CounterClockwise;
            this.pgCircular.Size = new System.Drawing.Size(45, 45);
            this.pgCircular.TabIndex = 12;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(84)))), ((int)(((byte)(101)))));
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(84)))), ((int)(((byte)(101)))));
            this.btnCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Image = global::CapaPresentacion.Properties.Resources.Command_Redo_32;
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.Location = new System.Drawing.Point(217, 6);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(121, 35);
            this.btnCancelar.TabIndex = 11;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(84)))), ((int)(((byte)(101)))));
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(84)))), ((int)(((byte)(101)))));
            this.btnGuardar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Image = global::CapaPresentacion.Properties.Resources.Save_32;
            this.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGuardar.Location = new System.Drawing.Point(344, 6);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(113, 35);
            this.btnGuardar.TabIndex = 4;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // lblContacto
            // 
            this.lblContacto.AutoSize = true;
            this.lblContacto.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.lblContacto.ForeColor = System.Drawing.Color.Black;
            this.lblContacto.Location = new System.Drawing.Point(11, 30);
            this.lblContacto.Name = "lblContacto";
            this.lblContacto.Size = new System.Drawing.Size(86, 28);
            this.lblContacto.TabIndex = 42;
            this.lblContacto.Text = "Apellido";
            // 
            // txtApellido
            // 
            this.txtApellido.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtApellido.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtApellido.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtApellido.FocusColor = System.Drawing.Color.Empty;
            this.txtApellido.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.txtApellido.ForeColor = System.Drawing.Color.DimGray;
            this.txtApellido.Location = new System.Drawing.Point(15, 61);
            this.txtApellido.MaxLength = 50;
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Numerico = false;
            this.txtApellido.Size = new System.Drawing.Size(345, 34);
            this.txtApellido.TabIndex = 0;
            this.txtApellido.Tag = "\"\"";
            // 
            // pnlCantUF
            // 
            this.pnlCantUF.Controls.Add(this.lblCantidad);
            this.pnlCantUF.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCantUF.Location = new System.Drawing.Point(0, 0);
            this.pnlCantUF.Name = "pnlCantUF";
            this.pnlCantUF.Size = new System.Drawing.Size(607, 44);
            this.pnlCantUF.TabIndex = 187;
            // 
            // lblCantidad
            // 
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.lblCantidad.ForeColor = System.Drawing.Color.Black;
            this.lblCantidad.Location = new System.Drawing.Point(3, 3);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(91, 28);
            this.lblCantidad.TabIndex = 50;
            this.lblCantidad.Text = "Cantidad";
            this.lblCantidad.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlBotonera
            // 
            this.pnlBotonera.Controls.Add(this.btnContratar);
            this.pnlBotonera.Controls.Add(this.btnEliminar);
            this.pnlBotonera.Controls.Add(this.btnEditar);
            this.pnlBotonera.Controls.Add(this.btnNuevo);
            this.pnlBotonera.Controls.Add(this.btnActualizar);
            this.pnlBotonera.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBotonera.Location = new System.Drawing.Point(0, 75);
            this.pnlBotonera.Name = "pnlBotonera";
            this.pnlBotonera.Size = new System.Drawing.Size(1071, 46);
            this.pnlBotonera.TabIndex = 56;
            // 
            // btnContratar
            // 
            this.btnContratar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnContratar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnContratar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnContratar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(84)))), ((int)(((byte)(101)))));
            this.btnContratar.FlatAppearance.BorderSize = 0;
            this.btnContratar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(84)))), ((int)(((byte)(101)))));
            this.btnContratar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            this.btnContratar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnContratar.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.btnContratar.ForeColor = System.Drawing.Color.White;
            this.btnContratar.Image = global::CapaPresentacion.Properties.Resources.Data_Add_32;
            this.btnContratar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnContratar.Location = new System.Drawing.Point(377, 6);
            this.btnContratar.Name = "btnContratar";
            this.btnContratar.Size = new System.Drawing.Size(187, 35);
            this.btnContratar.TabIndex = 15;
            this.btnContratar.Text = "Alta de abonado";
            this.btnContratar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnContratar.UseVisualStyleBackColor = false;
            this.btnContratar.Visible = false;
            this.btnContratar.Click += new System.EventHandler(this.btnContratar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEliminar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnEliminar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminar.Enabled = false;
            this.btnEliminar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(84)))), ((int)(((byte)(101)))));
            this.btnEliminar.FlatAppearance.BorderSize = 0;
            this.btnEliminar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(84)))), ((int)(((byte)(101)))));
            this.btnEliminar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.btnEliminar.ForeColor = System.Drawing.Color.DimGray;
            this.btnEliminar.Image = global::CapaPresentacion.Properties.Resources.Data_Delete_32;
            this.btnEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEliminar.Location = new System.Drawing.Point(939, 6);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(120, 35);
            this.btnEliminar.TabIndex = 12;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEliminar.UseVisualStyleBackColor = false;
            // 
            // btnEditar
            // 
            this.btnEditar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnEditar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditar.Enabled = false;
            this.btnEditar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(84)))), ((int)(((byte)(101)))));
            this.btnEditar.FlatAppearance.BorderSize = 0;
            this.btnEditar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(84)))), ((int)(((byte)(101)))));
            this.btnEditar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            this.btnEditar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditar.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.btnEditar.ForeColor = System.Drawing.Color.DimGray;
            this.btnEditar.Image = global::CapaPresentacion.Properties.Resources.Data_Edit_32__1_;
            this.btnEditar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEditar.Location = new System.Drawing.Point(823, 6);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(110, 35);
            this.btnEditar.TabIndex = 13;
            this.btnEditar.Text = "Editar";
            this.btnEditar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEditar.UseVisualStyleBackColor = false;
            // 
            // btnNuevo
            // 
            this.btnNuevo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNuevo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnNuevo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNuevo.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(84)))), ((int)(((byte)(101)))));
            this.btnNuevo.FlatAppearance.BorderSize = 0;
            this.btnNuevo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(84)))), ((int)(((byte)(101)))));
            this.btnNuevo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            this.btnNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevo.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.btnNuevo.ForeColor = System.Drawing.Color.White;
            this.btnNuevo.Image = global::CapaPresentacion.Properties.Resources.Data_Add_32;
            this.btnNuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNuevo.Location = new System.Drawing.Point(705, 6);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(112, 35);
            this.btnNuevo.TabIndex = 9;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNuevo.UseVisualStyleBackColor = false;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnActualizar
            // 
            this.btnActualizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnActualizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnActualizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnActualizar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(84)))), ((int)(((byte)(101)))));
            this.btnActualizar.FlatAppearance.BorderSize = 0;
            this.btnActualizar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(84)))), ((int)(((byte)(101)))));
            this.btnActualizar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            this.btnActualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActualizar.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.btnActualizar.ForeColor = System.Drawing.Color.White;
            this.btnActualizar.Image = global::CapaPresentacion.Properties.Resources.Command_Refresh_32;
            this.btnActualizar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnActualizar.Location = new System.Drawing.Point(570, 6);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(129, 35);
            this.btnActualizar.TabIndex = 14;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnActualizar.UseVisualStyleBackColor = false;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // dgvPresentacion
            // 
            this.dgvPresentacion.AllowUserToAddRows = false;
            this.dgvPresentacion.AllowUserToDeleteRows = false;
            this.dgvPresentacion.AllowUserToOrderColumns = true;
            this.dgvPresentacion.AllowUserToResizeColumns = false;
            this.dgvPresentacion.AllowUserToResizeRows = false;
            this.dgvPresentacion.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPresentacion.BackgroundColor = System.Drawing.Color.White;
            this.dgvPresentacion.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvPresentacion.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSlateGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 14F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPresentacion.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPresentacion.ColumnHeadersHeight = 50;
            this.dgvPresentacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 14F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPresentacion.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvPresentacion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPresentacion.EnableHeadersVisualStyles = false;
            this.dgvPresentacion.GridColor = System.Drawing.Color.WhiteSmoke;
            this.dgvPresentacion.Location = new System.Drawing.Point(0, 44);
            this.dgvPresentacion.MultiSelect = false;
            this.dgvPresentacion.Name = "dgvPresentacion";
            this.dgvPresentacion.ReadOnly = true;
            this.dgvPresentacion.RowHeadersVisible = false;
            this.dgvPresentacion.RowHeadersWidth = 50;
            this.dgvPresentacion.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvPresentacion.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPresentacion.Size = new System.Drawing.Size(607, 390);
            this.dgvPresentacion.TabIndex = 51;
            this.dgvPresentacion.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPresentacion_CellClick);
            this.dgvPresentacion.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPresentacion_CellDoubleClick);
            this.dgvPresentacion.SelectionChanged += new System.EventHandler(this.dgvPresentacion_SelectionChanged);
            // 
            // ABMUnidadesFuncionales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1071, 555);
            this.Controls.Add(this.spMain);
            this.Controls.Add(this.pnlBotonera);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "ABMUnidadesFuncionales";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ABMUnidadesFuncionales";
            this.Load += new System.EventHandler(this.ABMUnidadesFuncionales_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ABMUnidadesFuncionales_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgReturn)).EndInit();
            this.spMain.Panel1.ResumeLayout(false);
            this.spMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spMain)).EndInit();
            this.spMain.ResumeLayout(false);
            this.pnlCampos.ResumeLayout(false);
            this.pnlCampos.PerformLayout();
            this.pnlInferior.ResumeLayout(false);
            this.pnlCantUF.ResumeLayout(false);
            this.pnlCantUF.PerformLayout();
            this.pnlBotonera.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPresentacion)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox imgReturn;
        private System.Windows.Forms.Label lblTituloHeader;
        private System.Windows.Forms.SplitContainer spMain;
        private System.Windows.Forms.Panel pnlCampos;
        private System.Windows.Forms.Label lblContacto;
        private textboxAdv txtApellido;
        private System.Windows.Forms.Panel pnlBotonera;
        private System.Windows.Forms.Label lblDetalle;
        private textboxAdv txtDetalle;
        private System.Windows.Forms.Label label2;
        private textboxAdv txtDepto;
        private System.Windows.Forms.Label label1;
        private textboxAdv txtPiso;
        private System.Windows.Forms.Panel pnlInferior;
        private Controles.boton btnCancelar;
        private Controles.boton btnGuardar;
        private Controles.boton btnNuevo;
        private Controles.boton btnActualizar;
        private Controles.progress pgCircular;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.Panel pnlCantUF;
        private Controles.boton btnEliminar;
        private Controles.boton btnEditar;
        private Controles.boton btnContratar;
        private System.Windows.Forms.Label label3;
        private textboxAdv txtNombre;
        private Controles.dgv dgvPresentacion;
    }
}