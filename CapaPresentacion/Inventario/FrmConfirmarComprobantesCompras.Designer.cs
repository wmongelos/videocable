namespace CapaPresentacion.Inventario
{
    partial class FrmConfirmarComprobantesCompras
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
            this.pnTitulo = new System.Windows.Forms.Panel();
            this.LbTitulos = new System.Windows.Forms.Label();
            this.imgReturn = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.panel1 = new System.Windows.Forms.Panel();
            this.spImporteTotal = new CapaPresentacion.Controles.spinner(this.components);
            this.btnConfirmar = new CapaPresentacion.Controles.boton();
            this.btnCancelar = new CapaPresentacion.Controles.boton();
            this.cboTipoComprobante = new CapaPresentacion.Controles.combo(this.components);
            this.txtObservacion = new CapaPresentacion.textboxAdv();
            this.txtNumRemito = new CapaPresentacion.textboxAdv();
            this.btnSelecProv = new CapaPresentacion.Controles.boton();
            this.txtSelecProv = new CapaPresentacion.textboxAdv();
            this.pnTitulo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgReturn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spImporteTotal)).BeginInit();
            this.SuspendLayout();
            // 
            // pnTitulo
            // 
            this.pnTitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.pnTitulo.Controls.Add(this.LbTitulos);
            this.pnTitulo.Controls.Add(this.imgReturn);
            this.pnTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnTitulo.Location = new System.Drawing.Point(0, 0);
            this.pnTitulo.Name = "pnTitulo";
            this.pnTitulo.Size = new System.Drawing.Size(632, 83);
            this.pnTitulo.TabIndex = 203;
            // 
            // LbTitulos
            // 
            this.LbTitulos.AutoSize = true;
            this.LbTitulos.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LbTitulos.ForeColor = System.Drawing.Color.Transparent;
            this.LbTitulos.Location = new System.Drawing.Point(53, 31);
            this.LbTitulos.Name = "LbTitulos";
            this.LbTitulos.Size = new System.Drawing.Size(215, 25);
            this.LbTitulos.TabIndex = 172;
            this.LbTitulos.Text = "Confirmar comprobante";
            // 
            // imgReturn
            // 
            this.imgReturn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.imgReturn.Image = global::CapaPresentacion.Properties.Resources.Left_Arrow_32;
            this.imgReturn.Location = new System.Drawing.Point(11, 26);
            this.imgReturn.Name = "imgReturn";
            this.imgReturn.Size = new System.Drawing.Size(32, 32);
            this.imgReturn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgReturn.TabIndex = 76;
            this.imgReturn.TabStop = false;
            this.imgReturn.Click += new System.EventHandler(this.imgReturn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(10, 219);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(142, 21);
            this.label2.TabIndex = 220;
            this.label2.Text = "Numero de remito:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(49, 254);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 21);
            this.label1.TabIndex = 221;
            this.label1.Text = "Importe total:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(52, 289);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 21);
            this.label3.TabIndex = 222;
            this.label3.Text = "Observación:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(12, 184);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(140, 21);
            this.label4.TabIndex = 226;
            this.label4.Text = "Tipo comprobante:";
            // 
            // dtpFecha
            // 
            this.dtpFecha.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(12, 89);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(122, 29);
            this.dtpFecha.TabIndex = 229;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(0, 124);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 1);
            this.panel1.TabIndex = 230;
            // 
            // spImporteTotal
            // 
            this.spImporteTotal.BorderColor = System.Drawing.Color.Empty;
            this.spImporteTotal.DecimalPlaces = 2;
            this.spImporteTotal.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spImporteTotal.Location = new System.Drawing.Point(160, 252);
            this.spImporteTotal.Maximum = new decimal(new int[] {
            1661992959,
            1808227885,
            5,
            131072});
            this.spImporteTotal.Name = "spImporteTotal";
            this.spImporteTotal.Size = new System.Drawing.Size(237, 29);
            this.spImporteTotal.TabIndex = 233;
            this.spImporteTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConfirmar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnConfirmar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConfirmar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnConfirmar.FlatAppearance.BorderSize = 0;
            this.btnConfirmar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnConfirmar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnConfirmar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirmar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirmar.ForeColor = System.Drawing.Color.White;
            this.btnConfirmar.Image = global::CapaPresentacion.Properties.Resources.Save_32;
            this.btnConfirmar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnConfirmar.Location = new System.Drawing.Point(514, 89);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(104, 29);
            this.btnConfirmar.TabIndex = 232;
            this.btnConfirmar.Text = "Guardar";
            this.btnConfirmar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Image = global::CapaPresentacion.Properties.Resources.Data_Delete_32;
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.Location = new System.Drawing.Point(403, 89);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(104, 29);
            this.btnCancelar.TabIndex = 231;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // cboTipoComprobante
            // 
            this.cboTipoComprobante.BorderColor = System.Drawing.Color.Empty;
            this.cboTipoComprobante.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoComprobante.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboTipoComprobante.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTipoComprobante.FormattingEnabled = true;
            this.cboTipoComprobante.Location = new System.Drawing.Point(160, 181);
            this.cboTipoComprobante.Name = "cboTipoComprobante";
            this.cboTipoComprobante.Size = new System.Drawing.Size(237, 29);
            this.cboTipoComprobante.TabIndex = 227;
            // 
            // txtObservacion
            // 
            this.txtObservacion.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtObservacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtObservacion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtObservacion.FocusColor = System.Drawing.Color.Empty;
            this.txtObservacion.Font = new System.Drawing.Font("Segoe UI Light", 12F);
            this.txtObservacion.ForeColor = System.Drawing.Color.DimGray;
            this.txtObservacion.Location = new System.Drawing.Point(160, 287);
            this.txtObservacion.Multiline = true;
            this.txtObservacion.Name = "txtObservacion";
            this.txtObservacion.Numerico = false;
            this.txtObservacion.Size = new System.Drawing.Size(458, 78);
            this.txtObservacion.TabIndex = 225;
            this.txtObservacion.Tag = "\"\"";
            // 
            // txtNumRemito
            // 
            this.txtNumRemito.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtNumRemito.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNumRemito.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNumRemito.FocusColor = System.Drawing.Color.Empty;
            this.txtNumRemito.Font = new System.Drawing.Font("Segoe UI Light", 12F);
            this.txtNumRemito.ForeColor = System.Drawing.Color.DimGray;
            this.txtNumRemito.Location = new System.Drawing.Point(160, 217);
            this.txtNumRemito.Name = "txtNumRemito";
            this.txtNumRemito.Numerico = true;
            this.txtNumRemito.Size = new System.Drawing.Size(237, 29);
            this.txtNumRemito.TabIndex = 223;
            this.txtNumRemito.Tag = "\"\"";
            // 
            // btnSelecProv
            // 
            this.btnSelecProv.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnSelecProv.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSelecProv.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnSelecProv.FlatAppearance.BorderSize = 0;
            this.btnSelecProv.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnSelecProv.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnSelecProv.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelecProv.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelecProv.ForeColor = System.Drawing.Color.White;
            this.btnSelecProv.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSelecProv.Location = new System.Drawing.Point(403, 138);
            this.btnSelecProv.Name = "btnSelecProv";
            this.btnSelecProv.Size = new System.Drawing.Size(102, 29);
            this.btnSelecProv.TabIndex = 219;
            this.btnSelecProv.Text = "Seleccionar";
            this.btnSelecProv.UseVisualStyleBackColor = true;
            this.btnSelecProv.Click += new System.EventHandler(this.btnSelecProv_Click);
            // 
            // txtSelecProv
            // 
            this.txtSelecProv.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtSelecProv.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSelecProv.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSelecProv.Enabled = false;
            this.txtSelecProv.FocusColor = System.Drawing.Color.Empty;
            this.txtSelecProv.Font = new System.Drawing.Font("Segoe UI Light", 12F);
            this.txtSelecProv.ForeColor = System.Drawing.Color.DimGray;
            this.txtSelecProv.Location = new System.Drawing.Point(12, 138);
            this.txtSelecProv.Name = "txtSelecProv";
            this.txtSelecProv.Numerico = false;
            this.txtSelecProv.ReadOnly = true;
            this.txtSelecProv.Size = new System.Drawing.Size(385, 29);
            this.txtSelecProv.TabIndex = 218;
            this.txtSelecProv.Tag = "\"\"";
            this.txtSelecProv.Text = "SELECCIONAR PROVEEDOR";
            // 
            // FrmConfirmarComprobantesCompras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 377);
            this.Controls.Add(this.spImporteTotal);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dtpFecha);
            this.Controls.Add(this.cboTipoComprobante);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtObservacion);
            this.Controls.Add(this.txtNumRemito);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnSelecProv);
            this.Controls.Add(this.txtSelecProv);
            this.Controls.Add(this.pnTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "FrmConfirmarComprobantesCompras";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmConfirmarArticulos";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmConfirmarArticulos_KeyDown);
            this.pnTitulo.ResumeLayout(false);
            this.pnTitulo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgReturn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spImporteTotal)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnTitulo;
        private System.Windows.Forms.Label LbTitulos;
        private System.Windows.Forms.PictureBox imgReturn;
        private textboxAdv txtSelecProv;
        private Controles.boton btnSelecProv;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private textboxAdv txtNumRemito;
        private textboxAdv txtObservacion;
        private System.Windows.Forms.Label label4;
        private Controles.combo cboTipoComprobante;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Panel panel1;
        private Controles.boton btnCancelar;
        private Controles.boton btnConfirmar;
        private Controles.spinner spImporteTotal;
    }
}