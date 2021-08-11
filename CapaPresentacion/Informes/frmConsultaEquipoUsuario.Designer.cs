
namespace CapaPresentacion.Informes
{
    partial class frmConsultaEquipoUsuario
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
            this.panel3 = new System.Windows.Forms.Panel();
            this.imgReturn = new System.Windows.Forms.PictureBox();
            this.lblTituloHeader = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.grupoEquipo = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboEstado = new CapaPresentacion.Controles.combo(this.components);
            this.cboMarca = new CapaPresentacion.Controles.combo(this.components);
            this.cboTipoEquipo = new CapaPresentacion.Controles.combo(this.components);
            this.cboModelo = new CapaPresentacion.Controles.combo(this.components);
            this.grupoLocacion = new System.Windows.Forms.GroupBox();
            this.cboAltura = new CapaPresentacion.Controles.combo(this.components);
            this.spnAltura = new CapaPresentacion.Controles.spinner(this.components);
            this.cboCalle = new CapaPresentacion.Controles.combo(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.cboLocalidad = new CapaPresentacion.Controles.combo(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.grupoServicio = new System.Windows.Forms.GroupBox();
            this.cboModalidad = new CapaPresentacion.Controles.combo(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.cboServicio = new CapaPresentacion.Controles.combo(this.components);
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cboTipoServicio = new CapaPresentacion.Controles.combo(this.components);
            this.grupoCategoria = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cboTipoFacturacion = new CapaPresentacion.Controles.combo(this.components);
            this.btnBuscar = new CapaPresentacion.Controles.boton();
            this.label10 = new System.Windows.Forms.Label();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgReturn)).BeginInit();
            this.grupoEquipo.SuspendLayout();
            this.grupoLocacion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spnAltura)).BeginInit();
            this.grupoServicio.SuspendLayout();
            this.grupoCategoria.SuspendLayout();
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
            this.panel3.Size = new System.Drawing.Size(1244, 75);
            this.panel3.TabIndex = 53;
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
            this.lblTituloHeader.Font = new System.Drawing.Font("Segoe UI Light", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloHeader.ForeColor = System.Drawing.Color.White;
            this.lblTituloHeader.Location = new System.Drawing.Point(53, 27);
            this.lblTituloHeader.Name = "lblTituloHeader";
            this.lblTituloHeader.Size = new System.Drawing.Size(160, 25);
            this.lblTituloHeader.TabIndex = 31;
            this.lblTituloHeader.Text = "Equipos asignados";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.ForeColor = System.Drawing.Color.Black;
            this.lblNombre.Location = new System.Drawing.Point(42, 39);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(116, 21);
            this.lblNombre.TabIndex = 10;
            this.lblNombre.Text = "Tipo de equipo:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(763, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 21);
            this.label1.TabIndex = 421;
            this.label1.Text = "Modelo:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(422, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 21);
            this.label2.TabIndex = 423;
            this.label2.Text = "Marca:";
            // 
            // grupoEquipo
            // 
            this.grupoEquipo.Controls.Add(this.label3);
            this.grupoEquipo.Controls.Add(this.cboEstado);
            this.grupoEquipo.Controls.Add(this.cboMarca);
            this.grupoEquipo.Controls.Add(this.lblNombre);
            this.grupoEquipo.Controls.Add(this.cboTipoEquipo);
            this.grupoEquipo.Controls.Add(this.cboModelo);
            this.grupoEquipo.Controls.Add(this.label1);
            this.grupoEquipo.Controls.Add(this.label2);
            this.grupoEquipo.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.grupoEquipo.Location = new System.Drawing.Point(12, 87);
            this.grupoEquipo.Name = "grupoEquipo";
            this.grupoEquipo.Size = new System.Drawing.Size(1232, 128);
            this.grupoEquipo.TabIndex = 427;
            this.grupoEquipo.TabStop = false;
            this.grupoEquipo.Text = "Equipo";
            this.grupoEquipo.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(99, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 21);
            this.label3.TabIndex = 425;
            this.label3.Text = "Estado:";
            // 
            // cboEstado
            // 
            this.cboEstado.BorderColor = System.Drawing.Color.Empty;
            this.cboEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEstado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboEstado.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cboEstado.ForeColor = System.Drawing.Color.Black;
            this.cboEstado.FormattingEnabled = true;
            this.cboEstado.Items.AddRange(new object[] {
            "TODAS",
            "ALTA",
            "MEDIA",
            "BAJA"});
            this.cboEstado.Location = new System.Drawing.Point(164, 82);
            this.cboEstado.Name = "cboEstado";
            this.cboEstado.Size = new System.Drawing.Size(242, 29);
            this.cboEstado.TabIndex = 426;
            this.cboEstado.SelectionChangeCommitted += new System.EventHandler(this.cboEstado_SelectionChangeCommitted);
            // 
            // cboMarca
            // 
            this.cboMarca.BorderColor = System.Drawing.Color.Empty;
            this.cboMarca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMarca.Enabled = false;
            this.cboMarca.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboMarca.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cboMarca.ForeColor = System.Drawing.Color.Black;
            this.cboMarca.FormattingEnabled = true;
            this.cboMarca.Items.AddRange(new object[] {
            "TODAS",
            "ALTA",
            "MEDIA",
            "BAJA"});
            this.cboMarca.Location = new System.Drawing.Point(484, 36);
            this.cboMarca.Name = "cboMarca";
            this.cboMarca.Size = new System.Drawing.Size(273, 29);
            this.cboMarca.TabIndex = 422;
            this.cboMarca.SelectionChangeCommitted += new System.EventHandler(this.cboMarca_SelectionChangeCommitted);
            // 
            // cboTipoEquipo
            // 
            this.cboTipoEquipo.BorderColor = System.Drawing.Color.Empty;
            this.cboTipoEquipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoEquipo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboTipoEquipo.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cboTipoEquipo.ForeColor = System.Drawing.Color.Black;
            this.cboTipoEquipo.FormattingEnabled = true;
            this.cboTipoEquipo.Items.AddRange(new object[] {
            "TODAS",
            "ALTA",
            "MEDIA",
            "BAJA"});
            this.cboTipoEquipo.Location = new System.Drawing.Point(164, 36);
            this.cboTipoEquipo.Name = "cboTipoEquipo";
            this.cboTipoEquipo.Size = new System.Drawing.Size(242, 29);
            this.cboTipoEquipo.TabIndex = 420;
            this.cboTipoEquipo.SelectionChangeCommitted += new System.EventHandler(this.cboTipoEquipo_SelectionChangeCommitted);
            // 
            // cboModelo
            // 
            this.cboModelo.BorderColor = System.Drawing.Color.Empty;
            this.cboModelo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboModelo.Enabled = false;
            this.cboModelo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboModelo.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cboModelo.ForeColor = System.Drawing.Color.Black;
            this.cboModelo.FormattingEnabled = true;
            this.cboModelo.Items.AddRange(new object[] {
            "TODAS",
            "ALTA",
            "MEDIA",
            "BAJA"});
            this.cboModelo.Location = new System.Drawing.Point(835, 36);
            this.cboModelo.Name = "cboModelo";
            this.cboModelo.Size = new System.Drawing.Size(273, 29);
            this.cboModelo.TabIndex = 424;
            this.cboModelo.SelectionChangeCommitted += new System.EventHandler(this.cboModelo_SelectionChangeCommitted);
            // 
            // grupoLocacion
            // 
            this.grupoLocacion.Controls.Add(this.cboAltura);
            this.grupoLocacion.Controls.Add(this.spnAltura);
            this.grupoLocacion.Controls.Add(this.cboCalle);
            this.grupoLocacion.Controls.Add(this.label4);
            this.grupoLocacion.Controls.Add(this.cboLocalidad);
            this.grupoLocacion.Controls.Add(this.label6);
            this.grupoLocacion.Controls.Add(this.label7);
            this.grupoLocacion.Enabled = false;
            this.grupoLocacion.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.grupoLocacion.Location = new System.Drawing.Point(12, 221);
            this.grupoLocacion.Name = "grupoLocacion";
            this.grupoLocacion.Size = new System.Drawing.Size(1226, 98);
            this.grupoLocacion.TabIndex = 428;
            this.grupoLocacion.TabStop = false;
            this.grupoLocacion.Text = "Locación";
            // 
            // cboAltura
            // 
            this.cboAltura.BorderColor = System.Drawing.Color.Empty;
            this.cboAltura.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAltura.Enabled = false;
            this.cboAltura.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboAltura.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cboAltura.ForeColor = System.Drawing.Color.Black;
            this.cboAltura.FormattingEnabled = true;
            this.cboAltura.Items.AddRange(new object[] {
            "TODAS",
            "ALTA",
            "MEDIA",
            "BAJA"});
            this.cboAltura.Location = new System.Drawing.Point(913, 39);
            this.cboAltura.Name = "cboAltura";
            this.cboAltura.Size = new System.Drawing.Size(65, 29);
            this.cboAltura.TabIndex = 427;
            this.cboAltura.SelectionChangeCommitted += new System.EventHandler(this.cboAltura_SelectionChangeCommitted);
            // 
            // spnAltura
            // 
            this.spnAltura.BorderColor = System.Drawing.Color.Empty;
            this.spnAltura.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.spnAltura.Location = new System.Drawing.Point(984, 39);
            this.spnAltura.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.spnAltura.Name = "spnAltura";
            this.spnAltura.Size = new System.Drawing.Size(78, 29);
            this.spnAltura.TabIndex = 427;
            // 
            // cboCalle
            // 
            this.cboCalle.BorderColor = System.Drawing.Color.Empty;
            this.cboCalle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCalle.Enabled = false;
            this.cboCalle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboCalle.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cboCalle.ForeColor = System.Drawing.Color.Black;
            this.cboCalle.FormattingEnabled = true;
            this.cboCalle.Items.AddRange(new object[] {
            "TODAS",
            "ALTA",
            "MEDIA",
            "BAJA"});
            this.cboCalle.Location = new System.Drawing.Point(484, 39);
            this.cboCalle.Name = "cboCalle";
            this.cboCalle.Size = new System.Drawing.Size(362, 29);
            this.cboCalle.TabIndex = 422;
            this.cboCalle.SelectionChangeCommitted += new System.EventHandler(this.cboCalle_SelectionChangeCommitted);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(79, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 21);
            this.label4.TabIndex = 10;
            this.label4.Text = "Localidad:";
            // 
            // cboLocalidad
            // 
            this.cboLocalidad.BorderColor = System.Drawing.Color.Empty;
            this.cboLocalidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLocalidad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboLocalidad.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cboLocalidad.ForeColor = System.Drawing.Color.Black;
            this.cboLocalidad.FormattingEnabled = true;
            this.cboLocalidad.Items.AddRange(new object[] {
            "TODAS",
            "ALTA",
            "MEDIA",
            "BAJA"});
            this.cboLocalidad.Location = new System.Drawing.Point(164, 39);
            this.cboLocalidad.Name = "cboLocalidad";
            this.cboLocalidad.Size = new System.Drawing.Size(252, 29);
            this.cboLocalidad.TabIndex = 420;
            this.cboLocalidad.SelectionChangeCommitted += new System.EventHandler(this.cboLocalidad_SelectionChangeCommitted);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(852, 42);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 21);
            this.label6.TabIndex = 421;
            this.label6.Text = "Altura:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(422, 42);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 21);
            this.label7.TabIndex = 423;
            this.label7.Text = "Calle:";
            // 
            // grupoServicio
            // 
            this.grupoServicio.Controls.Add(this.cboModalidad);
            this.grupoServicio.Controls.Add(this.label5);
            this.grupoServicio.Controls.Add(this.cboServicio);
            this.grupoServicio.Controls.Add(this.label8);
            this.grupoServicio.Controls.Add(this.label9);
            this.grupoServicio.Controls.Add(this.cboTipoServicio);
            this.grupoServicio.Enabled = false;
            this.grupoServicio.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.grupoServicio.Location = new System.Drawing.Point(12, 424);
            this.grupoServicio.Name = "grupoServicio";
            this.grupoServicio.Size = new System.Drawing.Size(1226, 108);
            this.grupoServicio.TabIndex = 429;
            this.grupoServicio.TabStop = false;
            this.grupoServicio.Text = "Servicio";
            // 
            // cboModalidad
            // 
            this.cboModalidad.BorderColor = System.Drawing.Color.Empty;
            this.cboModalidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboModalidad.Enabled = false;
            this.cboModalidad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboModalidad.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cboModalidad.ForeColor = System.Drawing.Color.Black;
            this.cboModalidad.FormattingEnabled = true;
            this.cboModalidad.Items.AddRange(new object[] {
            "TODAS",
            "ALTA",
            "MEDIA",
            "BAJA"});
            this.cboModalidad.Location = new System.Drawing.Point(515, 39);
            this.cboModalidad.Name = "cboModalidad";
            this.cboModalidad.Size = new System.Drawing.Size(242, 29);
            this.cboModalidad.TabIndex = 428;
            this.cboModalidad.SelectionChangeCommitted += new System.EventHandler(this.cboModalidad_SelectionChangeCommitted);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(422, 42);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 21);
            this.label5.TabIndex = 427;
            this.label5.Text = "Modalidad:";
            // 
            // cboServicio
            // 
            this.cboServicio.BorderColor = System.Drawing.Color.Empty;
            this.cboServicio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboServicio.Enabled = false;
            this.cboServicio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboServicio.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cboServicio.ForeColor = System.Drawing.Color.Black;
            this.cboServicio.FormattingEnabled = true;
            this.cboServicio.Items.AddRange(new object[] {
            "TODAS",
            "ALTA",
            "MEDIA",
            "BAJA"});
            this.cboServicio.Location = new System.Drawing.Point(837, 39);
            this.cboServicio.Name = "cboServicio";
            this.cboServicio.Size = new System.Drawing.Size(242, 29);
            this.cboServicio.TabIndex = 426;
            this.cboServicio.SelectionChangeCommitted += new System.EventHandler(this.cboServicio_SelectionChangeCommitted);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(42, 42);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(121, 21);
            this.label8.TabIndex = 10;
            this.label8.Text = "Tipo de servicio:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(763, 42);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(68, 21);
            this.label9.TabIndex = 425;
            this.label9.Text = "Servicio:";
            // 
            // cboTipoServicio
            // 
            this.cboTipoServicio.BorderColor = System.Drawing.Color.Empty;
            this.cboTipoServicio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoServicio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboTipoServicio.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cboTipoServicio.ForeColor = System.Drawing.Color.Black;
            this.cboTipoServicio.FormattingEnabled = true;
            this.cboTipoServicio.Items.AddRange(new object[] {
            "TODAS",
            "ALTA",
            "MEDIA",
            "BAJA"});
            this.cboTipoServicio.Location = new System.Drawing.Point(169, 39);
            this.cboTipoServicio.Name = "cboTipoServicio";
            this.cboTipoServicio.Size = new System.Drawing.Size(242, 29);
            this.cboTipoServicio.TabIndex = 420;
            this.cboTipoServicio.SelectionChangeCommitted += new System.EventHandler(this.cboTipoServicio_SelectionChangeCommitted);
            // 
            // grupoCategoria
            // 
            this.grupoCategoria.Controls.Add(this.label11);
            this.grupoCategoria.Controls.Add(this.cboTipoFacturacion);
            this.grupoCategoria.Enabled = false;
            this.grupoCategoria.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.grupoCategoria.Location = new System.Drawing.Point(12, 325);
            this.grupoCategoria.Name = "grupoCategoria";
            this.grupoCategoria.Size = new System.Drawing.Size(1226, 93);
            this.grupoCategoria.TabIndex = 430;
            this.grupoCategoria.TabStop = false;
            this.grupoCategoria.Text = "Categoria/Zona";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(77, 42);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(86, 21);
            this.label11.TabIndex = 10;
            this.label11.Text = "Cartegoria:";
            // 
            // cboTipoFacturacion
            // 
            this.cboTipoFacturacion.BorderColor = System.Drawing.Color.Empty;
            this.cboTipoFacturacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoFacturacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboTipoFacturacion.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cboTipoFacturacion.ForeColor = System.Drawing.Color.Black;
            this.cboTipoFacturacion.FormattingEnabled = true;
            this.cboTipoFacturacion.Items.AddRange(new object[] {
            "TODAS",
            "ALTA",
            "MEDIA",
            "BAJA"});
            this.cboTipoFacturacion.Location = new System.Drawing.Point(169, 39);
            this.cboTipoFacturacion.Name = "cboTipoFacturacion";
            this.cboTipoFacturacion.Size = new System.Drawing.Size(315, 29);
            this.cboTipoFacturacion.TabIndex = 420;
            this.cboTipoFacturacion.SelectionChangeCommitted += new System.EventHandler(this.cboTipoFacturacion_SelectionChangeCommitted);
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
            this.btnBuscar.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.ForeColor = System.Drawing.Color.White;
            this.btnBuscar.Image = global::CapaPresentacion.Properties.Resources.lupa;
            this.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBuscar.Location = new System.Drawing.Point(1140, 538);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(92, 35);
            this.btnBuscar.TabIndex = 431;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(12, 552);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(368, 21);
            this.label10.TabIndex = 429;
            this.label10.Text = "Presione F1 para buscar todos los quipos asignados";
            // 
            // frmConsultaEquipoUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1244, 585);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.grupoCategoria);
            this.Controls.Add(this.grupoServicio);
            this.Controls.Add(this.grupoLocacion);
            this.Controls.Add(this.grupoEquipo);
            this.Controls.Add(this.panel3);
            this.KeyPreview = true;
            this.Name = "frmConsultaEquipoUsuario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consulta de equipos";
            this.Load += new System.EventHandler(this.frmConsultaEquipoUsuario_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmConsultaEquipoUsuario_KeyDown);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgReturn)).EndInit();
            this.grupoEquipo.ResumeLayout(false);
            this.grupoEquipo.PerformLayout();
            this.grupoLocacion.ResumeLayout(false);
            this.grupoLocacion.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spnAltura)).EndInit();
            this.grupoServicio.ResumeLayout(false);
            this.grupoServicio.PerformLayout();
            this.grupoCategoria.ResumeLayout(false);
            this.grupoCategoria.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox imgReturn;
        private System.Windows.Forms.Label lblTituloHeader;
        private System.Windows.Forms.Label lblNombre;
        private Controles.combo cboModelo;
        private System.Windows.Forms.Label label2;
        private Controles.combo cboMarca;
        private System.Windows.Forms.Label label1;
        private Controles.combo cboTipoEquipo;
        private System.Windows.Forms.GroupBox grupoEquipo;
        private System.Windows.Forms.GroupBox grupoLocacion;
        private Controles.combo cboCalle;
        private System.Windows.Forms.Label label4;
        private Controles.combo cboLocalidad;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox grupoServicio;
        private Controles.combo cboServicio;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private Controles.combo cboTipoServicio;
        private Controles.spinner spnAltura;
        private Controles.combo cboModalidad;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox grupoCategoria;
        private System.Windows.Forms.Label label11;
        private Controles.combo cboTipoFacturacion;
        private Controles.boton btnBuscar;
        private Controles.combo cboAltura;
        private System.Windows.Forms.Label label3;
        private Controles.combo cboEstado;
        private System.Windows.Forms.Label label10;
    }
}