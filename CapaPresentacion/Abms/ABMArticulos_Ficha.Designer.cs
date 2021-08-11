namespace CapaPresentacion.Abms
{
    partial class ABMArticulos_Ficha
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
            this.pnLine = new System.Windows.Forms.Panel();
            this.pnLinea1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.lblServicio = new System.Windows.Forms.Label();
            this.label43 = new System.Windows.Forms.Label();
            this.lblTipoServ = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.cboArticulos_Rubros = new CapaPresentacion.Controles.combo(this.components);
            this.txtDescripcion = new CapaPresentacion.textboxAdv();
            this.btnCancelar = new CapaPresentacion.Controles.boton();
            this.btnConfirmar = new CapaPresentacion.Controles.boton();
            this.label1 = new System.Windows.Forms.Label();
            this.spStock = new CapaPresentacion.Controles.spinner(this.components);
            this.spStock_Minimo = new CapaPresentacion.Controles.spinner(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.spImporte = new CapaPresentacion.Controles.spinner(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.spStock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spStock_Minimo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spImporte)).BeginInit();
            this.SuspendLayout();
            // 
            // pnLine
            // 
            this.pnLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.pnLine.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnLine.Location = new System.Drawing.Point(0, 0);
            this.pnLine.Name = "pnLine";
            this.pnLine.Size = new System.Drawing.Size(573, 1);
            this.pnLine.TabIndex = 52;
            // 
            // pnLinea1
            // 
            this.pnLinea1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnLinea1.BackColor = System.Drawing.Color.Gainsboro;
            this.pnLinea1.Location = new System.Drawing.Point(2, 42);
            this.pnLinea1.Name = "pnLinea1";
            this.pnLinea1.Size = new System.Drawing.Size(570, 1);
            this.pnLinea1.TabIndex = 55;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1, 320);
            this.panel2.TabIndex = 56;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.Location = new System.Drawing.Point(572, 1);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1, 320);
            this.panel4.TabIndex = 57;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(1, 320);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(571, 1);
            this.panel5.TabIndex = 53;
            // 
            // lblServicio
            // 
            this.lblServicio.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblServicio.ForeColor = System.Drawing.Color.Black;
            this.lblServicio.Location = new System.Drawing.Point(13, 9);
            this.lblServicio.Name = "lblServicio";
            this.lblServicio.Size = new System.Drawing.Size(940, 23);
            this.lblServicio.TabIndex = 62;
            this.lblServicio.Text = "[ SERVICIO ]";
            this.lblServicio.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label43.ForeColor = System.Drawing.Color.Black;
            this.label43.Location = new System.Drawing.Point(28, 68);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(94, 21);
            this.label43.TabIndex = 64;
            this.label43.Text = "Descripción:";
            // 
            // lblTipoServ
            // 
            this.lblTipoServ.AutoSize = true;
            this.lblTipoServ.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipoServ.ForeColor = System.Drawing.Color.Black;
            this.lblTipoServ.Location = new System.Drawing.Point(66, 105);
            this.lblTipoServ.Name = "lblTipoServ";
            this.lblTipoServ.Size = new System.Drawing.Size(56, 21);
            this.lblTipoServ.TabIndex = 65;
            this.lblTipoServ.Text = "Rubro:";
            // 
            // panel6
            // 
            this.panel6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel6.BackColor = System.Drawing.Color.Gainsboro;
            this.panel6.Location = new System.Drawing.Point(19, 271);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(563, 1);
            this.panel6.TabIndex = 87;
            // 
            // cboArticulos_Rubros
            // 
            this.cboArticulos_Rubros.BorderColor = System.Drawing.Color.Gainsboro;
            this.cboArticulos_Rubros.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboArticulos_Rubros.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboArticulos_Rubros.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboArticulos_Rubros.FormattingEnabled = true;
            this.cboArticulos_Rubros.Location = new System.Drawing.Point(122, 101);
            this.cboArticulos_Rubros.Name = "cboArticulos_Rubros";
            this.cboArticulos_Rubros.Size = new System.Drawing.Size(432, 29);
            this.cboArticulos_Rubros.TabIndex = 1;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtDescripcion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescripcion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescripcion.FocusColor = System.Drawing.Color.Empty;
            this.txtDescripcion.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescripcion.ForeColor = System.Drawing.Color.Black;
            this.txtDescripcion.Location = new System.Drawing.Point(122, 66);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Numerico = false;
            this.txtDescripcion.Size = new System.Drawing.Size(432, 29);
            this.txtDescripcion.TabIndex = 0;
            this.txtDescripcion.Tag = "\"\"";
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
            this.btnCancelar.Location = new System.Drawing.Point(462, 278);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(100, 35);
            this.btnCancelar.TabIndex = 6;
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
            this.btnConfirmar.Location = new System.Drawing.Point(332, 278);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(126, 35);
            this.btnConfirmar.TabIndex = 5;
            this.btnConfirmar.Text = "Confirmar";
            this.btnConfirmar.UseVisualStyleBackColor = false;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(72, 145);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 21);
            this.label1.TabIndex = 88;
            this.label1.Text = "Stock:";
            // 
            // spStock
            // 
            this.spStock.BorderColor = System.Drawing.Color.Empty;
            this.spStock.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spStock.Location = new System.Drawing.Point(122, 143);
            this.spStock.Maximum = new decimal(new int[] {
            -1486618625,
            232830643,
            0,
            0});
            this.spStock.Name = "spStock";
            this.spStock.Size = new System.Drawing.Size(135, 29);
            this.spStock.TabIndex = 2;
            this.spStock.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // spStock_Minimo
            // 
            this.spStock_Minimo.BorderColor = System.Drawing.Color.Empty;
            this.spStock_Minimo.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spStock_Minimo.Location = new System.Drawing.Point(419, 145);
            this.spStock_Minimo.Maximum = new decimal(new int[] {
            -1486618625,
            232830643,
            0,
            0});
            this.spStock_Minimo.Name = "spStock_Minimo";
            this.spStock_Minimo.Size = new System.Drawing.Size(135, 29);
            this.spStock_Minimo.TabIndex = 3;
            this.spStock_Minimo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(307, 150);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 21);
            this.label2.TabIndex = 160;
            this.label2.Text = "Stock Minimo:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(54, 202);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 21);
            this.label3.TabIndex = 161;
            this.label3.Text = "Importe:";
            // 
            // spImporte
            // 
            this.spImporte.BorderColor = System.Drawing.Color.Empty;
            this.spImporte.DecimalPlaces = 2;
            this.spImporte.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spImporte.Location = new System.Drawing.Point(122, 200);
            this.spImporte.Maximum = new decimal(new int[] {
            1661992959,
            1808227885,
            5,
            131072});
            this.spImporte.Name = "spImporte";
            this.spImporte.Size = new System.Drawing.Size(135, 29);
            this.spImporte.TabIndex = 4;
            this.spImporte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // ABMArticulos_Ficha
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(573, 321);
            this.Controls.Add(this.spImporte);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.spStock_Minimo);
            this.Controls.Add(this.spStock);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboArticulos_Rubros);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.lblTipoServ);
            this.Controls.Add(this.label43);
            this.Controls.Add(this.lblServicio);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pnLinea1);
            this.Controls.Add(this.pnLine);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "ABMArticulos_Ficha";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ABMArticulos_Ficha";
            this.Load += new System.EventHandler(this.ABMArticulos_Ficha_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ABMArticulos_Ficha_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.spStock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spStock_Minimo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spImporte)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel pnLine;
        private System.Windows.Forms.Panel pnLinea1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private Controles.boton btnConfirmar;
        private Controles.boton btnCancelar;
        private System.Windows.Forms.Label lblServicio;
        private textboxAdv txtDescripcion;
        private System.Windows.Forms.Label label43;
        private Controles.combo cboArticulos_Rubros;
        private System.Windows.Forms.Label lblTipoServ;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label1;
        private Controles.spinner spStock;
        private Controles.spinner spStock_Minimo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private Controles.spinner spImporte;
    }
}