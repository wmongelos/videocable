
namespace CapaPresentacion.PagosExternos.MercadoPagoCh
{
    partial class frmListaPagos
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
            this.IdCliente = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.pnlSuperior = new System.Windows.Forms.Panel();
            this.imgReturn = new System.Windows.Forms.PictureBox();
            this.lblTitulos = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnBuscar = new CapaPresentacion.Controles.boton();
            this.btnExportar = new CapaPresentacion.Controles.boton();
            this.btnPasarPagos = new CapaPresentacion.Controles.boton();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.lblCantidades = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.bgWorker = new System.ComponentModel.BackgroundWorker();
            this.tlvLista = new BrightIdeasSoftware.TreeListView();
            this.FechaEmitido = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.IdPago = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.DescripcionUCC = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.CodigoUsuario = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.NombreUsuario = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.ImporteSaldo = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.ImportePago = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.FechaPago = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.FechaVencimiento = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.pnlSuperior.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgReturn)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tlvLista)).BeginInit();
            this.SuspendLayout();
            // 
            // IdCliente
            // 
            this.IdCliente.AspectName = "IdCliente";
            this.IdCliente.DisplayIndex = 3;
            this.IdCliente.IsVisible = false;
            this.IdCliente.Text = "IdCliente";
            // 
            // pnlSuperior
            // 
            this.pnlSuperior.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.pnlSuperior.Controls.Add(this.imgReturn);
            this.pnlSuperior.Controls.Add(this.lblTitulos);
            this.pnlSuperior.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSuperior.Location = new System.Drawing.Point(0, 0);
            this.pnlSuperior.Name = "pnlSuperior";
            this.pnlSuperior.Size = new System.Drawing.Size(1307, 71);
            this.pnlSuperior.TabIndex = 175;
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
            this.lblTitulos.Size = new System.Drawing.Size(267, 25);
            this.lblTitulos.TabIndex = 172;
            this.lblTitulos.Text = "Lista de pagos - MercadoPago";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnBuscar);
            this.flowLayoutPanel1.Controls.Add(this.btnExportar);
            this.flowLayoutPanel1.Controls.Add(this.btnPasarPagos);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.BottomUp;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 71);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1307, 40);
            this.flowLayoutPanel1.TabIndex = 176;
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
            this.btnBuscar.Location = new System.Drawing.Point(3, 5);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(3, 3, 3, 7);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(106, 28);
            this.btnBuscar.TabIndex = 211;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_ClickAsync);
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
            this.btnExportar.Location = new System.Drawing.Point(115, 5);
            this.btnExportar.Margin = new System.Windows.Forms.Padding(3, 3, 3, 7);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(124, 28);
            this.btnExportar.TabIndex = 206;
            this.btnExportar.Text = "Exportar";
            this.btnExportar.UseVisualStyleBackColor = false;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // btnPasarPagos
            // 
            this.btnPasarPagos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPasarPagos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnPasarPagos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPasarPagos.Enabled = false;
            this.btnPasarPagos.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnPasarPagos.FlatAppearance.BorderSize = 0;
            this.btnPasarPagos.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnPasarPagos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnPasarPagos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPasarPagos.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPasarPagos.ForeColor = System.Drawing.Color.White;
            this.btnPasarPagos.Image = global::CapaPresentacion.Properties.Resources.Command_Refresh_32;
            this.btnPasarPagos.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPasarPagos.Location = new System.Drawing.Point(245, 5);
            this.btnPasarPagos.Margin = new System.Windows.Forms.Padding(3, 3, 3, 7);
            this.btnPasarPagos.Name = "btnPasarPagos";
            this.btnPasarPagos.Size = new System.Drawing.Size(175, 28);
            this.btnPasarPagos.TabIndex = 215;
            this.btnPasarPagos.Text = "Guardar pagos";
            this.btnPasarPagos.UseVisualStyleBackColor = false;
            this.btnPasarPagos.Click += new System.EventHandler(this.btnPasarPagos_Click);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.lblCantidades);
            this.flowLayoutPanel2.Controls.Add(this.label4);
            this.flowLayoutPanel2.Controls.Add(this.label3);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(0, 554);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.flowLayoutPanel2.Size = new System.Drawing.Size(1307, 35);
            this.flowLayoutPanel2.TabIndex = 177;
            // 
            // lblCantidades
            // 
            this.lblCantidades.AutoSize = true;
            this.lblCantidades.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCantidades.Location = new System.Drawing.Point(3, 8);
            this.lblCantidades.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.lblCantidades.Name = "lblCantidades";
            this.lblCantidades.Size = new System.Drawing.Size(83, 21);
            this.lblCantidades.TabIndex = 218;
            this.lblCantidades.Text = "Cantiadad:";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.ForestGreen;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(92, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 25);
            this.label4.TabIndex = 3;
            this.label4.Text = "PAGO";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Red;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(161, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "IMPAGO";
            // 
            // bgWorker
            // 
            this.bgWorker.WorkerReportsProgress = true;
            this.bgWorker.WorkerSupportsCancellation = true;
            // 
            // tlvLista
            // 
            this.tlvLista.AllColumns.Add(this.FechaEmitido);
            this.tlvLista.AllColumns.Add(this.IdPago);
            this.tlvLista.AllColumns.Add(this.DescripcionUCC);
            this.tlvLista.AllColumns.Add(this.CodigoUsuario);
            this.tlvLista.AllColumns.Add(this.NombreUsuario);
            this.tlvLista.AllColumns.Add(this.ImporteSaldo);
            this.tlvLista.AllColumns.Add(this.ImportePago);
            this.tlvLista.AllColumns.Add(this.FechaPago);
            this.tlvLista.AllColumns.Add(this.FechaVencimiento);
            this.tlvLista.CellEditUseWholeCell = false;
            this.tlvLista.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.FechaEmitido,
            this.IdPago,
            this.DescripcionUCC,
            this.CodigoUsuario,
            this.NombreUsuario,
            this.ImporteSaldo,
            this.ImportePago,
            this.FechaPago,
            this.FechaVencimiento});
            this.tlvLista.Cursor = System.Windows.Forms.Cursors.Default;
            this.tlvLista.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlvLista.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tlvLista.GridLines = true;
            this.tlvLista.HideSelection = false;
            this.tlvLista.Location = new System.Drawing.Point(0, 111);
            this.tlvLista.Name = "tlvLista";
            this.tlvLista.ShowGroups = false;
            this.tlvLista.Size = new System.Drawing.Size(1307, 443);
            this.tlvLista.TabIndex = 180;
            this.tlvLista.UseCompatibleStateImageBehavior = false;
            this.tlvLista.View = System.Windows.Forms.View.Details;
            this.tlvLista.VirtualMode = true;
            this.tlvLista.FormatRow += new System.EventHandler<BrightIdeasSoftware.FormatRowEventArgs>(this.tlvLista_FormatRow);
            // 
            // FechaEmitido
            // 
            this.FechaEmitido.AspectName = "FechaEmitido";
            this.FechaEmitido.Text = "Fecha Emitido";
            this.FechaEmitido.Width = 96;
            // 
            // IdPago
            // 
            this.IdPago.AspectName = "IdPago";
            this.IdPago.Text = "Codigo de pago";
            this.IdPago.Width = 118;
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
            this.NombreUsuario.Width = 134;
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
            // frmListaPagos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1307, 589);
            this.Controls.Add(this.tlvLista);
            this.Controls.Add(this.flowLayoutPanel2);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.pnlSuperior);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmListaPagos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ordenes de pago";
            this.pnlSuperior.ResumeLayout(false);
            this.pnlSuperior.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgReturn)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tlvLista)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private BrightIdeasSoftware.OLVColumn IdCliente;
        private System.Windows.Forms.Panel pnlSuperior;
        private System.Windows.Forms.PictureBox imgReturn;
        private System.Windows.Forms.Label lblTitulos;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private Controles.boton btnExportar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private Controles.boton btnBuscar;
        private Controles.boton btnPasarPagos;
        private System.ComponentModel.BackgroundWorker bgWorker;
        private BrightIdeasSoftware.TreeListView tlvLista;
        private BrightIdeasSoftware.OLVColumn FechaEmitido;
        private BrightIdeasSoftware.OLVColumn IdPago;
        private BrightIdeasSoftware.OLVColumn DescripcionUCC;
        private BrightIdeasSoftware.OLVColumn CodigoUsuario;
        private BrightIdeasSoftware.OLVColumn NombreUsuario;
        private BrightIdeasSoftware.OLVColumn ImporteSaldo;
        private BrightIdeasSoftware.OLVColumn ImportePago;
        private BrightIdeasSoftware.OLVColumn FechaPago;
        private BrightIdeasSoftware.OLVColumn FechaVencimiento;
        private System.Windows.Forms.Label lblCantidades;
    }
}