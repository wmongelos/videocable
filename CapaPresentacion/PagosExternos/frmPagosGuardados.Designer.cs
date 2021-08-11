
using System.Drawing;

namespace CapaPresentacion.PagosExternos
{
    partial class frmPagosGuardados
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
            this.pnlSuperior = new System.Windows.Forms.Panel();
            this.imgReturn = new System.Windows.Forms.PictureBox();
            this.lblTitulos = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.lblDesde = new System.Windows.Forms.Label();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.lblHasta = new System.Windows.Forms.Label();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.rbtPago = new System.Windows.Forms.RadioButton();
            this.rbtImpago = new System.Windows.Forms.RadioButton();
            this.rbTodos = new System.Windows.Forms.RadioButton();
            this.lblPlataforma = new System.Windows.Forms.Label();
            this.cboPlataforma = new CapaPresentacion.Controles.combo(this.components);
            this.btnBuscar = new CapaPresentacion.Controles.boton();
            this.btnExportar = new CapaPresentacion.Controles.boton();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.lblCantidades = new System.Windows.Forms.Label();
            this.tlvLista = new BrightIdeasSoftware.TreeListView();
            this.FechaEmitido = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.Id = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.DescripcionUCC = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.CodigoUsuario = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.NombreUsuario = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.ImporteSaldo = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.ImportePago = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.FechaPago = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.FechaVencimiento = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.ComprobanteAGenerar = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.NombrePlataforma = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.mnuContextual = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.seleccionarRecibosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.seleccionarRecibosXToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.seleccionarCreditosACuentaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.seleccionarTodoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel5 = new System.Windows.Forms.FlowLayoutPanel();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.flowLayoutPanel4 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnGeneraRecibosX = new CapaPresentacion.Controles.boton();
            this.btnGenerarRecibos = new CapaPresentacion.Controles.boton();
            this.btnCredito = new CapaPresentacion.Controles.boton();
            this.btnGenerarFac = new CapaPresentacion.Controles.boton();
            this.pnlCargando = new System.Windows.Forms.Panel();
            this.lblCargando = new System.Windows.Forms.Label();
            this.pgCircular = new CapaPresentacion.Controles.progress();
            this.pnlSuperior.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgReturn)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tlvLista)).BeginInit();
            this.mnuContextual.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel5.SuspendLayout();
            this.flowLayoutPanel4.SuspendLayout();
            this.pnlCargando.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlSuperior
            // 
            this.pnlSuperior.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.pnlSuperior.Controls.Add(this.imgReturn);
            this.pnlSuperior.Controls.Add(this.lblTitulos);
            this.pnlSuperior.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSuperior.Location = new System.Drawing.Point(0, 0);
            this.pnlSuperior.Name = "pnlSuperior";
            this.pnlSuperior.Size = new System.Drawing.Size(1386, 71);
            this.pnlSuperior.TabIndex = 176;
            // 
            // imgReturn
            // 
            this.imgReturn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.imgReturn.Image = global::CapaPresentacion.Properties.Resources.Left_Arrow_32;
            this.imgReturn.Location = new System.Drawing.Point(12, 19);
            this.imgReturn.Name = "imgReturn";
            this.imgReturn.Size = new System.Drawing.Size(32, 32);
            this.imgReturn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgReturn.TabIndex = 76;
            this.imgReturn.TabStop = false;
            this.imgReturn.Click += new System.EventHandler(this.imgReturn_Click);
            // 
            // lblTitulos
            // 
            this.lblTitulos.AutoSize = true;
            this.lblTitulos.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulos.ForeColor = System.Drawing.Color.Transparent;
            this.lblTitulos.Location = new System.Drawing.Point(45, 23);
            this.lblTitulos.Name = "lblTitulos";
            this.lblTitulos.Size = new System.Drawing.Size(156, 25);
            this.lblTitulos.TabIndex = 172;
            this.lblTitulos.Text = "Pagos generados";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.lblDesde);
            this.flowLayoutPanel1.Controls.Add(this.dtpDesde);
            this.flowLayoutPanel1.Controls.Add(this.lblHasta);
            this.flowLayoutPanel1.Controls.Add(this.dtpHasta);
            this.flowLayoutPanel1.Controls.Add(this.rbtPago);
            this.flowLayoutPanel1.Controls.Add(this.rbtImpago);
            this.flowLayoutPanel1.Controls.Add(this.rbTodos);
            this.flowLayoutPanel1.Controls.Add(this.lblPlataforma);
            this.flowLayoutPanel1.Controls.Add(this.cboPlataforma);
            this.flowLayoutPanel1.Controls.Add(this.btnBuscar);
            this.flowLayoutPanel1.Controls.Add(this.btnExportar);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.BottomUp;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 71);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1386, 40);
            this.flowLayoutPanel1.TabIndex = 177;
            // 
            // lblDesde
            // 
            this.lblDesde.AutoSize = true;
            this.lblDesde.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDesde.Location = new System.Drawing.Point(3, 10);
            this.lblDesde.Margin = new System.Windows.Forms.Padding(3, 3, 3, 9);
            this.lblDesde.Name = "lblDesde";
            this.lblDesde.Size = new System.Drawing.Size(56, 21);
            this.lblDesde.TabIndex = 207;
            this.lblDesde.Text = "Desde:";
            // 
            // dtpDesde
            // 
            this.dtpDesde.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDesde.Location = new System.Drawing.Point(65, 5);
            this.dtpDesde.Margin = new System.Windows.Forms.Padding(3, 3, 3, 6);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(131, 29);
            this.dtpDesde.TabIndex = 208;
            // 
            // lblHasta
            // 
            this.lblHasta.AutoSize = true;
            this.lblHasta.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHasta.Location = new System.Drawing.Point(202, 10);
            this.lblHasta.Margin = new System.Windows.Forms.Padding(3, 3, 3, 9);
            this.lblHasta.Name = "lblHasta";
            this.lblHasta.Size = new System.Drawing.Size(52, 21);
            this.lblHasta.TabIndex = 209;
            this.lblHasta.Text = "Hasta:";
            // 
            // dtpHasta
            // 
            this.dtpHasta.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHasta.Location = new System.Drawing.Point(260, 5);
            this.dtpHasta.Margin = new System.Windows.Forms.Padding(3, 3, 3, 6);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(131, 29);
            this.dtpHasta.TabIndex = 210;
            // 
            // rbtPago
            // 
            this.rbtPago.AutoSize = true;
            this.rbtPago.Checked = true;
            this.rbtPago.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.rbtPago.Location = new System.Drawing.Point(397, 7);
            this.rbtPago.Margin = new System.Windows.Forms.Padding(3, 3, 3, 8);
            this.rbtPago.Name = "rbtPago";
            this.rbtPago.Size = new System.Drawing.Size(62, 25);
            this.rbtPago.TabIndex = 212;
            this.rbtPago.TabStop = true;
            this.rbtPago.Text = "Pago";
            this.rbtPago.UseVisualStyleBackColor = true;
            this.rbtPago.Visible = false;
            // 
            // rbtImpago
            // 
            this.rbtImpago.AutoSize = true;
            this.rbtImpago.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.rbtImpago.Location = new System.Drawing.Point(465, 7);
            this.rbtImpago.Margin = new System.Windows.Forms.Padding(3, 3, 3, 8);
            this.rbtImpago.Name = "rbtImpago";
            this.rbtImpago.Size = new System.Drawing.Size(81, 25);
            this.rbtImpago.TabIndex = 213;
            this.rbtImpago.Text = "Impago";
            this.rbtImpago.UseVisualStyleBackColor = true;
            this.rbtImpago.Visible = false;
            // 
            // rbTodos
            // 
            this.rbTodos.AutoSize = true;
            this.rbTodos.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbTodos.Location = new System.Drawing.Point(552, 7);
            this.rbTodos.Margin = new System.Windows.Forms.Padding(3, 3, 3, 8);
            this.rbTodos.Name = "rbTodos";
            this.rbTodos.Size = new System.Drawing.Size(68, 25);
            this.rbTodos.TabIndex = 214;
            this.rbTodos.Text = "Todos";
            this.rbTodos.UseVisualStyleBackColor = true;
            this.rbTodos.Visible = false;
            // 
            // lblPlataforma
            // 
            this.lblPlataforma.AutoSize = true;
            this.lblPlataforma.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlataforma.Location = new System.Drawing.Point(626, 10);
            this.lblPlataforma.Margin = new System.Windows.Forms.Padding(3, 3, 3, 9);
            this.lblPlataforma.Name = "lblPlataforma";
            this.lblPlataforma.Size = new System.Drawing.Size(89, 21);
            this.lblPlataforma.TabIndex = 216;
            this.lblPlataforma.Text = "Plataforma:";
            // 
            // cboPlataforma
            // 
            this.cboPlataforma.BorderColor = System.Drawing.Color.Empty;
            this.cboPlataforma.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPlataforma.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboPlataforma.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboPlataforma.FormattingEnabled = true;
            this.cboPlataforma.Location = new System.Drawing.Point(721, 5);
            this.cboPlataforma.Margin = new System.Windows.Forms.Padding(3, 0, 3, 6);
            this.cboPlataforma.Name = "cboPlataforma";
            this.cboPlataforma.Size = new System.Drawing.Size(171, 29);
            this.cboPlataforma.TabIndex = 215;
            this.cboPlataforma.SelectedValueChanged += new System.EventHandler(this.cboPlataforma_SelectedValueChanged);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
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
            this.btnBuscar.Location = new System.Drawing.Point(898, 5);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(3, 3, 3, 7);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(97, 28);
            this.btnBuscar.TabIndex = 211;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnExportar
            // 
            this.btnExportar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnExportar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExportar.Enabled = false;
            this.btnExportar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnExportar.FlatAppearance.BorderSize = 0;
            this.btnExportar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnExportar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnExportar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportar.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportar.ForeColor = System.Drawing.Color.White;
            this.btnExportar.Image = global::CapaPresentacion.Properties.Resources.Data_Export_32;
            this.btnExportar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExportar.Location = new System.Drawing.Point(1001, 5);
            this.btnExportar.Margin = new System.Windows.Forms.Padding(3, 3, 3, 7);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(124, 28);
            this.btnExportar.TabIndex = 206;
            this.btnExportar.Text = "Exportar";
            this.btnExportar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExportar.UseVisualStyleBackColor = false;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel2.Controls.Add(this.lblCantidades);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.flowLayoutPanel2.Size = new System.Drawing.Size(972, 35);
            this.flowLayoutPanel2.TabIndex = 178;
            // 
            // lblCantidades
            // 
            this.lblCantidades.AutoSize = true;
            this.lblCantidades.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCantidades.Location = new System.Drawing.Point(3, 8);
            this.lblCantidades.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.lblCantidades.Name = "lblCantidades";
            this.lblCantidades.Size = new System.Drawing.Size(83, 21);
            this.lblCantidades.TabIndex = 217;
            this.lblCantidades.Text = "Cantiadad:";
            // 
            // tlvLista
            // 
            this.tlvLista.AllColumns.Add(this.FechaEmitido);
            this.tlvLista.AllColumns.Add(this.Id);
            this.tlvLista.AllColumns.Add(this.DescripcionUCC);
            this.tlvLista.AllColumns.Add(this.CodigoUsuario);
            this.tlvLista.AllColumns.Add(this.NombreUsuario);
            this.tlvLista.AllColumns.Add(this.ImporteSaldo);
            this.tlvLista.AllColumns.Add(this.ImportePago);
            this.tlvLista.AllColumns.Add(this.FechaPago);
            this.tlvLista.AllColumns.Add(this.FechaVencimiento);
            this.tlvLista.AllColumns.Add(this.ComprobanteAGenerar);
            this.tlvLista.AllColumns.Add(this.NombrePlataforma);
            this.tlvLista.CellEditUseWholeCell = false;
            this.tlvLista.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.FechaEmitido,
            this.Id,
            this.DescripcionUCC,
            this.CodigoUsuario,
            this.NombreUsuario,
            this.ImporteSaldo,
            this.ImportePago,
            this.FechaPago,
            this.FechaVencimiento,
            this.ComprobanteAGenerar,
            this.NombrePlataforma});
            this.tlvLista.ContextMenuStrip = this.mnuContextual;
            this.tlvLista.Cursor = System.Windows.Forms.Cursors.Default;
            this.tlvLista.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlvLista.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tlvLista.GridLines = true;
            this.tlvLista.HideSelection = false;
            this.tlvLista.Location = new System.Drawing.Point(0, 111);
            this.tlvLista.Name = "tlvLista";
            this.tlvLista.RowHeight = 30;
            this.tlvLista.ShowGroups = false;
            this.tlvLista.Size = new System.Drawing.Size(1386, 382);
            this.tlvLista.TabIndex = 179;
            this.tlvLista.UseCompatibleStateImageBehavior = false;
            this.tlvLista.View = System.Windows.Forms.View.Details;
            this.tlvLista.VirtualMode = true;
            this.tlvLista.FormatCell += new System.EventHandler<BrightIdeasSoftware.FormatCellEventArgs>(this.tlvLista_FormatCell);
            this.tlvLista.FormatRow += new System.EventHandler<BrightIdeasSoftware.FormatRowEventArgs>(this.tlvLista_FormatRow);
            // 
            // FechaEmitido
            // 
            this.FechaEmitido.AspectName = "FechaEmitido";
            this.FechaEmitido.Text = "Fecha Emitido";
            this.FechaEmitido.Width = 166;
            // 
            // Id
            // 
            this.Id.AspectName = "Id";
            this.Id.Text = "Codigo de pago";
            this.Id.Width = 118;
            // 
            // DescripcionUCC
            // 
            this.DescripcionUCC.AspectName = "DescripcionUCC";
            this.DescripcionUCC.Text = "Item";
            this.DescripcionUCC.Width = 169;
            // 
            // CodigoUsuario
            // 
            this.CodigoUsuario.AspectName = "CodigoUsuario";
            this.CodigoUsuario.Text = "Codigo";
            this.CodigoUsuario.Width = 81;
            // 
            // NombreUsuario
            // 
            this.NombreUsuario.AspectName = "NombreUsuario";
            this.NombreUsuario.Text = "Nombre";
            this.NombreUsuario.Width = 192;
            // 
            // ImporteSaldo
            // 
            this.ImporteSaldo.AspectName = "ImporteSaldo";
            this.ImporteSaldo.Text = "Importe ";
            this.ImporteSaldo.Width = 132;
            // 
            // ImportePago
            // 
            this.ImportePago.AspectName = "ImportePago";
            this.ImportePago.Text = "Importe Pago";
            this.ImportePago.Width = 145;
            // 
            // FechaPago
            // 
            this.FechaPago.AspectName = "FechaPago";
            this.FechaPago.Text = "Fecha Pago";
            this.FechaPago.Width = 134;
            // 
            // FechaVencimiento
            // 
            this.FechaVencimiento.AspectName = "FechaVencimiento";
            this.FechaVencimiento.Text = "Fecha Vencimiento";
            this.FechaVencimiento.Width = 133;
            // 
            // ComprobanteAGenerar
            // 
            this.ComprobanteAGenerar.AspectName = "ComprobanteAGenerar";
            this.ComprobanteAGenerar.Text = "Tipo de comprobante a generar";
            this.ComprobanteAGenerar.Width = 250;
            // 
            // NombrePlataforma
            // 
            this.NombrePlataforma.AspectName = "NombrePlataforma";
            this.NombrePlataforma.Text = "Plataforma";
            this.NombrePlataforma.Width = 97;
            // 
            // mnuContextual
            // 
            this.mnuContextual.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.seleccionarRecibosToolStripMenuItem,
            this.seleccionarRecibosXToolStripMenuItem,
            this.seleccionarCreditosACuentaToolStripMenuItem,
            this.seleccionarTodoToolStripMenuItem});
            this.mnuContextual.Name = "mnuContextual";
            this.mnuContextual.Size = new System.Drawing.Size(228, 92);
            // 
            // seleccionarRecibosToolStripMenuItem
            // 
            this.seleccionarRecibosToolStripMenuItem.Name = "seleccionarRecibosToolStripMenuItem";
            this.seleccionarRecibosToolStripMenuItem.Size = new System.Drawing.Size(227, 22);
            this.seleccionarRecibosToolStripMenuItem.Text = "Seleccionar recibos";
            this.seleccionarRecibosToolStripMenuItem.Click += new System.EventHandler(this.seleccionarRecibosToolStripMenuItem_Click);
            // 
            // seleccionarRecibosXToolStripMenuItem
            // 
            this.seleccionarRecibosXToolStripMenuItem.Name = "seleccionarRecibosXToolStripMenuItem";
            this.seleccionarRecibosXToolStripMenuItem.Size = new System.Drawing.Size(227, 22);
            this.seleccionarRecibosXToolStripMenuItem.Text = "Seleccionar recibos X";
            this.seleccionarRecibosXToolStripMenuItem.Click += new System.EventHandler(this.seleccionarRecibosXToolStripMenuItem_Click);
            // 
            // seleccionarCreditosACuentaToolStripMenuItem
            // 
            this.seleccionarCreditosACuentaToolStripMenuItem.Name = "seleccionarCreditosACuentaToolStripMenuItem";
            this.seleccionarCreditosACuentaToolStripMenuItem.Size = new System.Drawing.Size(227, 22);
            this.seleccionarCreditosACuentaToolStripMenuItem.Text = "Seleccionar creditos a cuenta";
            this.seleccionarCreditosACuentaToolStripMenuItem.Click += new System.EventHandler(this.seleccionarCreditosACuentaToolStripMenuItem_Click);
            // 
            // seleccionarTodoToolStripMenuItem
            // 
            this.seleccionarTodoToolStripMenuItem.Name = "seleccionarTodoToolStripMenuItem";
            this.seleccionarTodoToolStripMenuItem.Size = new System.Drawing.Size(227, 22);
            this.seleccionarTodoToolStripMenuItem.Text = "Seleccionar todo";
            this.seleccionarTodoToolStripMenuItem.Click += new System.EventHandler(this.seleccionarTodoToolStripMenuItem_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70.63492F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 29.36508F));
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel5, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 530);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1386, 41);
            this.tableLayoutPanel1.TabIndex = 180;
            // 
            // flowLayoutPanel5
            // 
            this.flowLayoutPanel5.Controls.Add(this.label6);
            this.flowLayoutPanel5.Controls.Add(this.label7);
            this.flowLayoutPanel5.Controls.Add(this.label5);
            this.flowLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel5.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel5.Location = new System.Drawing.Point(981, 3);
            this.flowLayoutPanel5.Name = "flowLayoutPanel5";
            this.flowLayoutPanel5.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.flowLayoutPanel5.Size = new System.Drawing.Size(402, 35);
            this.flowLayoutPanel5.TabIndex = 180;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.YellowGreen;
            this.label6.Dock = System.Windows.Forms.DockStyle.Right;
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(215, 5);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(184, 25);
            this.label6.TabIndex = 2;
            this.label6.Text = "CREDITO A CUENTA";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.DarkSlateGray;
            this.label7.Dock = System.Windows.Forms.DockStyle.Right;
            this.label7.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(104, 5);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(105, 25);
            this.label7.TabIndex = 218;
            this.label7.Text = "RECIBOS X";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.DarkGreen;
            this.label5.Dock = System.Windows.Forms.DockStyle.Right;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(20, 5);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 25);
            this.label5.TabIndex = 3;
            this.label5.Text = "RECIBO";
            // 
            // flowLayoutPanel4
            // 
            this.flowLayoutPanel4.Controls.Add(this.btnGeneraRecibosX);
            this.flowLayoutPanel4.Controls.Add(this.btnGenerarRecibos);
            this.flowLayoutPanel4.Controls.Add(this.btnCredito);
            this.flowLayoutPanel4.Controls.Add(this.btnGenerarFac);
            this.flowLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel4.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel4.Location = new System.Drawing.Point(0, 493);
            this.flowLayoutPanel4.Name = "flowLayoutPanel4";
            this.flowLayoutPanel4.Size = new System.Drawing.Size(1386, 37);
            this.flowLayoutPanel4.TabIndex = 181;
            // 
            // btnGeneraRecibosX
            // 
            this.btnGeneraRecibosX.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnGeneraRecibosX.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGeneraRecibosX.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnGeneraRecibosX.FlatAppearance.BorderSize = 0;
            this.btnGeneraRecibosX.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnGeneraRecibosX.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnGeneraRecibosX.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGeneraRecibosX.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGeneraRecibosX.ForeColor = System.Drawing.Color.White;
            this.btnGeneraRecibosX.Image = global::CapaPresentacion.Properties.Resources.Data_Add_32;
            this.btnGeneraRecibosX.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGeneraRecibosX.Location = new System.Drawing.Point(1226, 3);
            this.btnGeneraRecibosX.Margin = new System.Windows.Forms.Padding(3, 3, 3, 7);
            this.btnGeneraRecibosX.Name = "btnGeneraRecibosX";
            this.btnGeneraRecibosX.Size = new System.Drawing.Size(157, 28);
            this.btnGeneraRecibosX.TabIndex = 220;
            this.btnGeneraRecibosX.Text = "Generar recibos x";
            this.btnGeneraRecibosX.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGeneraRecibosX.UseVisualStyleBackColor = false;
            this.btnGeneraRecibosX.Click += new System.EventHandler(this.btnGeneraRecibosX_Click);
            // 
            // btnGenerarRecibos
            // 
            this.btnGenerarRecibos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnGenerarRecibos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGenerarRecibos.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnGenerarRecibos.FlatAppearance.BorderSize = 0;
            this.btnGenerarRecibos.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnGenerarRecibos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnGenerarRecibos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerarRecibos.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerarRecibos.ForeColor = System.Drawing.Color.White;
            this.btnGenerarRecibos.Image = global::CapaPresentacion.Properties.Resources.Data_Add_32;
            this.btnGenerarRecibos.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGenerarRecibos.Location = new System.Drawing.Point(1063, 3);
            this.btnGenerarRecibos.Margin = new System.Windows.Forms.Padding(3, 3, 3, 7);
            this.btnGenerarRecibos.Name = "btnGenerarRecibos";
            this.btnGenerarRecibos.Size = new System.Drawing.Size(157, 28);
            this.btnGenerarRecibos.TabIndex = 217;
            this.btnGenerarRecibos.Text = "Generar recibos";
            this.btnGenerarRecibos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGenerarRecibos.UseVisualStyleBackColor = false;
            this.btnGenerarRecibos.Click += new System.EventHandler(this.btnGenerarRecibos_Click);
            // 
            // btnCredito
            // 
            this.btnCredito.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnCredito.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCredito.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnCredito.FlatAppearance.BorderSize = 0;
            this.btnCredito.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnCredito.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnCredito.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCredito.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCredito.ForeColor = System.Drawing.Color.White;
            this.btnCredito.Image = global::CapaPresentacion.Properties.Resources.Data_Add_32;
            this.btnCredito.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCredito.Location = new System.Drawing.Point(832, 3);
            this.btnCredito.Margin = new System.Windows.Forms.Padding(3, 3, 3, 7);
            this.btnCredito.Name = "btnCredito";
            this.btnCredito.Size = new System.Drawing.Size(225, 28);
            this.btnCredito.TabIndex = 218;
            this.btnCredito.Text = "Generar créditos a cuenta";
            this.btnCredito.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCredito.UseVisualStyleBackColor = false;
            this.btnCredito.Click += new System.EventHandler(this.btnCredito_Click);
            // 
            // btnGenerarFac
            // 
            this.btnGenerarFac.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnGenerarFac.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGenerarFac.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnGenerarFac.FlatAppearance.BorderSize = 0;
            this.btnGenerarFac.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnGenerarFac.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnGenerarFac.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerarFac.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerarFac.ForeColor = System.Drawing.Color.White;
            this.btnGenerarFac.Image = global::CapaPresentacion.Properties.Resources.Data_Add_32;
            this.btnGenerarFac.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGenerarFac.Location = new System.Drawing.Point(669, 3);
            this.btnGenerarFac.Margin = new System.Windows.Forms.Padding(3, 3, 3, 7);
            this.btnGenerarFac.Name = "btnGenerarFac";
            this.btnGenerarFac.Size = new System.Drawing.Size(157, 28);
            this.btnGenerarFac.TabIndex = 219;
            this.btnGenerarFac.Text = "Generar facturas";
            this.btnGenerarFac.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGenerarFac.UseVisualStyleBackColor = false;
            this.btnGenerarFac.Click += new System.EventHandler(this.btnGenerarFac_Click);
            // 
            // pnlCargando
            // 
            this.pnlCargando.BackColor = System.Drawing.SystemColors.Control;
            this.pnlCargando.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCargando.Controls.Add(this.lblCargando);
            this.pnlCargando.Controls.Add(this.pgCircular);
            this.pnlCargando.Location = new System.Drawing.Point(615, 212);
            this.pnlCargando.Name = "pnlCargando";
            this.pnlCargando.Size = new System.Drawing.Size(157, 147);
            this.pnlCargando.TabIndex = 317;
            this.pnlCargando.Visible = false;
            // 
            // lblCargando
            // 
            this.lblCargando.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.lblCargando.ForeColor = System.Drawing.Color.Black;
            this.lblCargando.Location = new System.Drawing.Point(38, 93);
            this.lblCargando.Name = "lblCargando";
            this.lblCargando.Size = new System.Drawing.Size(90, 25);
            this.lblCargando.TabIndex = 15;
            this.lblCargando.Text = "Cargando";
            // 
            // pgCircular
            // 
            this.pgCircular.Location = new System.Drawing.Point(43, 14);
            this.pgCircular.Name = "pgCircular";
            this.pgCircular.Percentage = 0F;
            this.pgCircular.Rotation = CapaPresentacion.Controles.RotationType.CounterClockwise;
            this.pgCircular.Size = new System.Drawing.Size(76, 76);
            this.pgCircular.TabIndex = 314;
            // 
            // frmPagosGuardados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1386, 571);
            this.Controls.Add(this.pnlCargando);
            this.Controls.Add(this.tlvLista);
            this.Controls.Add(this.flowLayoutPanel4);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.pnlSuperior);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "frmPagosGuardados";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pagos generados";
            this.Load += new System.EventHandler(this.frmPagosGuardados_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmPagosGuardados_KeyDown);
            this.pnlSuperior.ResumeLayout(false);
            this.pnlSuperior.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgReturn)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tlvLista)).EndInit();
            this.mnuContextual.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel5.ResumeLayout(false);
            this.flowLayoutPanel5.PerformLayout();
            this.flowLayoutPanel4.ResumeLayout(false);
            this.pnlCargando.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlSuperior;
        private System.Windows.Forms.PictureBox imgReturn;
        private System.Windows.Forms.Label lblTitulos;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label lblDesde;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.RadioButton rbtPago;
        private System.Windows.Forms.RadioButton rbtImpago;
        private System.Windows.Forms.RadioButton rbTodos;
        private System.Windows.Forms.Label lblHasta;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private Controles.boton btnBuscar;
        private Controles.boton btnExportar;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private BrightIdeasSoftware.TreeListView tlvLista;
        private BrightIdeasSoftware.OLVColumn FechaEmitido;
        private BrightIdeasSoftware.OLVColumn Id;
        private BrightIdeasSoftware.OLVColumn DescripcionUCC;
        private BrightIdeasSoftware.OLVColumn CodigoUsuario;
        private BrightIdeasSoftware.OLVColumn NombreUsuario;
        private BrightIdeasSoftware.OLVColumn ImporteSaldo;
        private System.Windows.Forms.Label lblPlataforma;
        private System.Windows.Forms.Label lblCantidades;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private BrightIdeasSoftware.OLVColumn ImportePago;
        private BrightIdeasSoftware.OLVColumn FechaPago;
        private BrightIdeasSoftware.OLVColumn FechaVencimiento;
        private Controles.combo cboPlataforma;
        private Controles.boton btnGenerarRecibos;
        private BrightIdeasSoftware.OLVColumn ComprobanteAGenerar;
        private BrightIdeasSoftware.OLVColumn NombrePlataforma;
        private Controles.boton btnCredito;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel4;
        private System.Windows.Forms.ContextMenuStrip mnuContextual;
        private System.Windows.Forms.ToolStripMenuItem seleccionarRecibosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem seleccionarCreditosACuentaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem seleccionarTodoToolStripMenuItem;
        private Controles.boton btnGenerarFac;
        private System.Windows.Forms.ToolStripMenuItem seleccionarRecibosXToolStripMenuItem;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel pnlCargando;
        private System.Windows.Forms.Label lblCargando;
        private Controles.progress pgCircular;
        private Controles.boton btnGeneraRecibosX;
    }
}