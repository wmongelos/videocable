
namespace CapaPresentacion.Cuenta_Corriente
{
    partial class FrmDatosReciboTipoAjuste
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
            this.pnLine = new System.Windows.Forms.Panel();
            this.imgReturn = new System.Windows.Forms.PictureBox();
            this.lblTituloHeader = new System.Windows.Forms.Label();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpFechaAjuste = new System.Windows.Forms.DateTimePicker();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblMovimiento = new System.Windows.Forms.Label();
            this.lblHasta = new System.Windows.Forms.Label();
            this.lblDesde = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblImporte = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblComprobante = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCancelar = new CapaPresentacion.Controles.boton();
            this.btnConfirmar = new CapaPresentacion.Controles.boton();
            this.txtImporteAjuste = new CapaPresentacion.textboxAdv();
            this.pnlImporte = new System.Windows.Forms.Panel();
            this.rbAjusteSaldoCompleto = new System.Windows.Forms.RadioButton();
            this.rbImporteFactura = new System.Windows.Forms.RadioButton();
            this.pnlFecha = new System.Windows.Forms.Panel();
            this.rbFechaComprobante = new System.Windows.Forms.RadioButton();
            this.rbFechaActual = new System.Windows.Forms.RadioButton();
            this.pnLine.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgReturn)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.pnlImporte.SuspendLayout();
            this.pnlFecha.SuspendLayout();
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
            this.pnLine.Size = new System.Drawing.Size(823, 75);
            this.pnLine.TabIndex = 24;
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
            this.lblTituloHeader.Size = new System.Drawing.Size(338, 32);
            this.lblTituloHeader.TabIndex = 31;
            this.lblTituloHeader.Text = "Datos recibo tipo Ajuste.";
            // 
            // lblBuscar
            // 
            this.lblBuscar.AutoSize = true;
            this.lblBuscar.Font = new System.Drawing.Font("Segoe UI Light", 12F);
            this.lblBuscar.ForeColor = System.Drawing.Color.SlateGray;
            this.lblBuscar.Location = new System.Drawing.Point(59, 270);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Size = new System.Drawing.Size(125, 21);
            this.lblBuscar.TabIndex = 305;
            this.lblBuscar.Text = "Importe Ajuste: $";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Light", 12F);
            this.label1.ForeColor = System.Drawing.Color.SlateGray;
            this.label1.Location = new System.Drawing.Point(16, 367);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(168, 21);
            this.label1.TabIndex = 307;
            this.label1.Text = "Fecha de Recibo Ajuste:";
            // 
            // dtpFechaAjuste
            // 
            this.dtpFechaAjuste.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaAjuste.Location = new System.Drawing.Point(189, 367);
            this.dtpFechaAjuste.Name = "dtpFechaAjuste";
            this.dtpFechaAjuste.Size = new System.Drawing.Size(356, 29);
            this.dtpFechaAjuste.TabIndex = 308;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.lblMovimiento);
            this.groupBox2.Controls.Add(this.lblHasta);
            this.groupBox2.Controls.Add(this.lblDesde);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.lblImporte);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.lblComprobante);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(42, 81);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(769, 169);
            this.groupBox2.TabIndex = 309;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Datos del Comprobante";
            // 
            // lblMovimiento
            // 
            this.lblMovimiento.AutoSize = true;
            this.lblMovimiento.Location = new System.Drawing.Point(549, 34);
            this.lblMovimiento.Name = "lblMovimiento";
            this.lblMovimiento.Size = new System.Drawing.Size(167, 21);
            this.lblMovimiento.TabIndex = 9;
            this.lblMovimiento.Text = "DatosFechaMovimiento";
            // 
            // lblHasta
            // 
            this.lblHasta.AutoSize = true;
            this.lblHasta.Location = new System.Drawing.Point(120, 127);
            this.lblHasta.Name = "lblHasta";
            this.lblHasta.Size = new System.Drawing.Size(87, 21);
            this.lblHasta.TabIndex = 8;
            this.lblHasta.Text = "DatosHasta";
            // 
            // lblDesde
            // 
            this.lblDesde.AutoSize = true;
            this.lblDesde.Location = new System.Drawing.Point(120, 96);
            this.lblDesde.Name = "lblDesde";
            this.lblDesde.Size = new System.Drawing.Size(91, 21);
            this.lblDesde.TabIndex = 7;
            this.lblDesde.Text = "DatosDesde";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(407, 34);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(136, 21);
            this.label6.TabIndex = 6;
            this.label6.Text = "Fecha Movimiento:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(19, 127);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 21);
            this.label5.TabIndex = 5;
            this.label5.Text = "Fecha Hasta:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 21);
            this.label4.TabIndex = 4;
            this.label4.Text = "Fecha Desde:";
            // 
            // lblImporte
            // 
            this.lblImporte.AutoSize = true;
            this.lblImporte.Location = new System.Drawing.Point(120, 65);
            this.lblImporte.Name = "lblImporte";
            this.lblImporte.Size = new System.Drawing.Size(103, 21);
            this.lblImporte.TabIndex = 3;
            this.lblImporte.Text = "DatosImporte";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(34, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 21);
            this.label3.TabIndex = 2;
            this.label3.Text = "Importe: $";
            // 
            // lblComprobante
            // 
            this.lblComprobante.AutoSize = true;
            this.lblComprobante.Location = new System.Drawing.Point(120, 34);
            this.lblComprobante.Name = "lblComprobante";
            this.lblComprobante.Size = new System.Drawing.Size(143, 21);
            this.lblComprobante.TabIndex = 1;
            this.lblComprobante.Text = "DatosComprobante";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 21);
            this.label2.TabIndex = 0;
            this.label2.Text = "Comprobante:";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel1.Location = new System.Drawing.Point(12, 256);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(799, 1);
            this.panel1.TabIndex = 314;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Image = global::CapaPresentacion.Properties.Resources.Command_Redo_32;
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.Location = new System.Drawing.Point(711, 412);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(100, 35);
            this.btnCancelar.TabIndex = 311;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConfirmar.BackColor = System.Drawing.Color.SteelBlue;
            this.btnConfirmar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConfirmar.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
            this.btnConfirmar.FlatAppearance.BorderSize = 0;
            this.btnConfirmar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SteelBlue;
            this.btnConfirmar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SteelBlue;
            this.btnConfirmar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirmar.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirmar.ForeColor = System.Drawing.Color.White;
            this.btnConfirmar.Image = global::CapaPresentacion.Properties.Resources.Task_03_32;
            this.btnConfirmar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnConfirmar.Location = new System.Drawing.Point(581, 412);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(126, 35);
            this.btnConfirmar.TabIndex = 310;
            this.btnConfirmar.Text = "Confirmar";
            this.btnConfirmar.UseVisualStyleBackColor = false;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // txtImporteAjuste
            // 
            this.txtImporteAjuste.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtImporteAjuste.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtImporteAjuste.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtImporteAjuste.Enabled = false;
            this.txtImporteAjuste.FocusColor = System.Drawing.Color.Empty;
            this.txtImporteAjuste.Font = new System.Drawing.Font("Segoe UI Light", 12F);
            this.txtImporteAjuste.ForeColor = System.Drawing.Color.DimGray;
            this.txtImporteAjuste.Location = new System.Drawing.Point(189, 268);
            this.txtImporteAjuste.Name = "txtImporteAjuste";
            this.txtImporteAjuste.Numerico = false;
            this.txtImporteAjuste.Size = new System.Drawing.Size(356, 29);
            this.txtImporteAjuste.TabIndex = 306;
            this.txtImporteAjuste.Tag = "\"\"";
            // 
            // pnlImporte
            // 
            this.pnlImporte.Controls.Add(this.rbAjusteSaldoCompleto);
            this.pnlImporte.Controls.Add(this.rbImporteFactura);
            this.pnlImporte.Location = new System.Drawing.Point(189, 307);
            this.pnlImporte.Name = "pnlImporte";
            this.pnlImporte.Size = new System.Drawing.Size(356, 37);
            this.pnlImporte.TabIndex = 317;
            // 
            // rbAjusteSaldoCompleto
            // 
            this.rbAjusteSaldoCompleto.AutoSize = true;
            this.rbAjusteSaldoCompleto.Checked = true;
            this.rbAjusteSaldoCompleto.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbAjusteSaldoCompleto.Location = new System.Drawing.Point(143, 7);
            this.rbAjusteSaldoCompleto.Name = "rbAjusteSaldoCompleto";
            this.rbAjusteSaldoCompleto.Size = new System.Drawing.Size(201, 25);
            this.rbAjusteSaldoCompleto.TabIndex = 1;
            this.rbAjusteSaldoCompleto.TabStop = true;
            this.rbAjusteSaldoCompleto.Text = "Ajuste de Saldo Completo";
            this.rbAjusteSaldoCompleto.UseVisualStyleBackColor = true;
            this.rbAjusteSaldoCompleto.CheckedChanged += new System.EventHandler(this.rbAjusteSaldoCompleto_CheckedChanged);
            // 
            // rbImporteFactura
            // 
            this.rbImporteFactura.AutoSize = true;
            this.rbImporteFactura.Enabled = false;
            this.rbImporteFactura.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbImporteFactura.Location = new System.Drawing.Point(3, 7);
            this.rbImporteFactura.Name = "rbImporteFactura";
            this.rbImporteFactura.Size = new System.Drawing.Size(134, 25);
            this.rbImporteFactura.TabIndex = 0;
            this.rbImporteFactura.Text = "Importe Factura";
            this.rbImporteFactura.UseVisualStyleBackColor = true;
            this.rbImporteFactura.CheckedChanged += new System.EventHandler(this.rbImporteFactura_CheckedChanged);
            // 
            // pnlFecha
            // 
            this.pnlFecha.Controls.Add(this.rbFechaComprobante);
            this.pnlFecha.Controls.Add(this.rbFechaActual);
            this.pnlFecha.Location = new System.Drawing.Point(189, 402);
            this.pnlFecha.Name = "pnlFecha";
            this.pnlFecha.Size = new System.Drawing.Size(356, 37);
            this.pnlFecha.TabIndex = 318;
            // 
            // rbFechaComprobante
            // 
            this.rbFechaComprobante.AutoSize = true;
            this.rbFechaComprobante.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbFechaComprobante.Location = new System.Drawing.Point(122, 7);
            this.rbFechaComprobante.Name = "rbFechaComprobante";
            this.rbFechaComprobante.Size = new System.Drawing.Size(189, 25);
            this.rbFechaComprobante.TabIndex = 1;
            this.rbFechaComprobante.Text = "Fecha del Comprobante";
            this.rbFechaComprobante.UseVisualStyleBackColor = true;
            this.rbFechaComprobante.CheckedChanged += new System.EventHandler(this.rbFechaComprobante_CheckedChanged);
            // 
            // rbFechaActual
            // 
            this.rbFechaActual.AutoSize = true;
            this.rbFechaActual.Checked = true;
            this.rbFechaActual.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbFechaActual.Location = new System.Drawing.Point(3, 7);
            this.rbFechaActual.Name = "rbFechaActual";
            this.rbFechaActual.Size = new System.Drawing.Size(113, 25);
            this.rbFechaActual.TabIndex = 0;
            this.rbFechaActual.TabStop = true;
            this.rbFechaActual.Text = "Fecha Actual";
            this.rbFechaActual.UseVisualStyleBackColor = true;
            this.rbFechaActual.CheckedChanged += new System.EventHandler(this.rbFechaActual_CheckedChanged);
            // 
            // FrmDatosReciboTipoAjuste
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(823, 459);
            this.Controls.Add(this.pnlFecha);
            this.Controls.Add(this.pnlImporte);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.dtpFechaAjuste);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtImporteAjuste);
            this.Controls.Add(this.lblBuscar);
            this.Controls.Add(this.pnLine);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "FrmDatosReciboTipoAjuste";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmDatosReciboTipoAjuste";
            this.Load += new System.EventHandler(this.FrmDatosReciboTipoAjuste_Load);
            this.pnLine.ResumeLayout(false);
            this.pnLine.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgReturn)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.pnlImporte.ResumeLayout(false);
            this.pnlImporte.PerformLayout();
            this.pnlFecha.ResumeLayout(false);
            this.pnlFecha.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnLine;
        private System.Windows.Forms.PictureBox imgReturn;
        private System.Windows.Forms.Label lblTituloHeader;
        private textboxAdv txtImporteAjuste;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpFechaAjuste;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblComprobante;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblImporte;
        private System.Windows.Forms.Label label3;
        private Controles.boton btnCancelar;
        private Controles.boton btnConfirmar;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblHasta;
        private System.Windows.Forms.Label lblDesde;
        private System.Windows.Forms.Label lblMovimiento;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pnlImporte;
        private System.Windows.Forms.RadioButton rbAjusteSaldoCompleto;
        private System.Windows.Forms.RadioButton rbImporteFactura;
        private System.Windows.Forms.Panel pnlFecha;
        private System.Windows.Forms.RadioButton rbFechaComprobante;
        private System.Windows.Forms.RadioButton rbFechaActual;
    }
}