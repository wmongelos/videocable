namespace CapaPresentacion.Cuenta_Corriente
{
    partial class frmCtaCteAjustesBonificaciones
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblTituloForm = new System.Windows.Forms.Label();
            this.imgServicios_Unicos = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblDetalles = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.rdPorcentaje2 = new System.Windows.Forms.RadioButton();
            this.rdPorcentaje1 = new System.Windows.Forms.RadioButton();
            this.panel5 = new System.Windows.Forms.Panel();
            this.rdnivelsubservicio = new System.Windows.Forms.RadioButton();
            this.rdnivelservicio = new System.Windows.Forms.RadioButton();
            this.rdnivelcomprobante = new System.Windows.Forms.RadioButton();
            this.lbImporteCOmprobante = new System.Windows.Forms.Label();
            this.lbimporteBonificado = new System.Windows.Forms.Label();
            this.pgCircular = new CapaPresentacion.Controles.progress();
            this.txtDetalle = new CapaPresentacion.textboxAdv();
            this.dgvDatos = new CapaPresentacion.Controles.dgv(this.components);
            this.btnGuardar = new CapaPresentacion.Controles.boton();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgServicios_Unicos)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.panel2.Controls.Add(this.lblTituloForm);
            this.panel2.Controls.Add(this.imgServicios_Unicos);
            this.panel2.Location = new System.Drawing.Point(-7, -5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1158, 80);
            this.panel2.TabIndex = 176;
            // 
            // lblTituloForm
            // 
            this.lblTituloForm.AutoSize = true;
            this.lblTituloForm.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.lblTituloForm.ForeColor = System.Drawing.Color.Transparent;
            this.lblTituloForm.Location = new System.Drawing.Point(57, 29);
            this.lblTituloForm.Name = "lblTituloForm";
            this.lblTituloForm.Size = new System.Drawing.Size(338, 25);
            this.lblTituloForm.TabIndex = 173;
            this.lblTituloForm.Text = "Ajuste de importes de cuenta corriente";
            // 
            // imgServicios_Unicos
            // 
            this.imgServicios_Unicos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.imgServicios_Unicos.Image = global::CapaPresentacion.Properties.Resources.Left_Arrow_32;
            this.imgServicios_Unicos.Location = new System.Drawing.Point(19, 22);
            this.imgServicios_Unicos.Name = "imgServicios_Unicos";
            this.imgServicios_Unicos.Size = new System.Drawing.Size(32, 32);
            this.imgServicios_Unicos.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgServicios_Unicos.TabIndex = 173;
            this.imgServicios_Unicos.TabStop = false;
            this.imgServicios_Unicos.Click += new System.EventHandler(this.imgServicios_Unicos_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Silver;
            this.panel1.Location = new System.Drawing.Point(1, 117);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1141, 1);
            this.panel1.TabIndex = 328;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Silver;
            this.panel3.Location = new System.Drawing.Point(0, 216);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1159, 1);
            this.panel3.TabIndex = 329;
            // 
            // lblDetalles
            // 
            this.lblDetalles.AutoSize = true;
            this.lblDetalles.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblDetalles.Location = new System.Drawing.Point(16, 185);
            this.lblDetalles.Name = "lblDetalles";
            this.lblDetalles.Size = new System.Drawing.Size(61, 21);
            this.lblDetalles.TabIndex = 336;
            this.lblDetalles.Text = "Detalle:";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.rdPorcentaje2);
            this.panel4.Controls.Add(this.rdPorcentaje1);
            this.panel4.Location = new System.Drawing.Point(13, 130);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(233, 38);
            this.panel4.TabIndex = 337;
            // 
            // rdPorcentaje2
            // 
            this.rdPorcentaje2.AutoSize = true;
            this.rdPorcentaje2.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdPorcentaje2.Location = new System.Drawing.Point(126, 7);
            this.rdPorcentaje2.Name = "rdPorcentaje2";
            this.rdPorcentaje2.Size = new System.Drawing.Size(84, 22);
            this.rdPorcentaje2.TabIndex = 1;
            this.rdPorcentaje2.Text = "Aumento";
            this.rdPorcentaje2.UseVisualStyleBackColor = true;
            this.rdPorcentaje2.CheckedChanged += new System.EventHandler(this.rdPorcentaje2_CheckedChanged);
            // 
            // rdPorcentaje1
            // 
            this.rdPorcentaje1.AutoSize = true;
            this.rdPorcentaje1.Checked = true;
            this.rdPorcentaje1.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdPorcentaje1.Location = new System.Drawing.Point(12, 7);
            this.rdPorcentaje1.Name = "rdPorcentaje1";
            this.rdPorcentaje1.Size = new System.Drawing.Size(92, 22);
            this.rdPorcentaje1.TabIndex = 0;
            this.rdPorcentaje1.TabStop = true;
            this.rdPorcentaje1.Text = "Descuento";
            this.rdPorcentaje1.UseVisualStyleBackColor = true;
            this.rdPorcentaje1.CheckedChanged += new System.EventHandler(this.rdPorcentaje1_CheckedChanged);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.rdnivelsubservicio);
            this.panel5.Controls.Add(this.rdnivelservicio);
            this.panel5.Controls.Add(this.rdnivelcomprobante);
            this.panel5.Location = new System.Drawing.Point(320, 129);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(333, 38);
            this.panel5.TabIndex = 338;
            // 
            // rdnivelsubservicio
            // 
            this.rdnivelsubservicio.AutoSize = true;
            this.rdnivelsubservicio.Checked = true;
            this.rdnivelsubservicio.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdnivelsubservicio.Location = new System.Drawing.Point(235, 9);
            this.rdnivelsubservicio.Name = "rdnivelsubservicio";
            this.rdnivelsubservicio.Size = new System.Drawing.Size(89, 19);
            this.rdnivelsubservicio.TabIndex = 2;
            this.rdnivelsubservicio.TabStop = true;
            this.rdnivelsubservicio.Text = "Subservicio";
            this.rdnivelsubservicio.UseVisualStyleBackColor = true;
            this.rdnivelsubservicio.CheckedChanged += new System.EventHandler(this.rdnivelsubservicio_CheckedChanged);
            // 
            // rdnivelservicio
            // 
            this.rdnivelservicio.AutoSize = true;
            this.rdnivelservicio.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdnivelservicio.Location = new System.Drawing.Point(123, 9);
            this.rdnivelservicio.Name = "rdnivelservicio";
            this.rdnivelservicio.Size = new System.Drawing.Size(69, 19);
            this.rdnivelservicio.TabIndex = 1;
            this.rdnivelservicio.Text = "Servicio";
            this.rdnivelservicio.UseVisualStyleBackColor = true;
            this.rdnivelservicio.CheckedChanged += new System.EventHandler(this.rdnivelservicio_CheckedChanged);
            // 
            // rdnivelcomprobante
            // 
            this.rdnivelcomprobante.AutoSize = true;
            this.rdnivelcomprobante.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdnivelcomprobante.Location = new System.Drawing.Point(10, 10);
            this.rdnivelcomprobante.Name = "rdnivelcomprobante";
            this.rdnivelcomprobante.Size = new System.Drawing.Size(99, 19);
            this.rdnivelcomprobante.TabIndex = 0;
            this.rdnivelcomprobante.Text = "Comprobante";
            this.rdnivelcomprobante.UseVisualStyleBackColor = true;
            this.rdnivelcomprobante.CheckedChanged += new System.EventHandler(this.rdnivelcomprobante_CheckedChanged);
            // 
            // lbImporteCOmprobante
            // 
            this.lbImporteCOmprobante.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbImporteCOmprobante.AutoSize = true;
            this.lbImporteCOmprobante.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.lbImporteCOmprobante.ForeColor = System.Drawing.Color.DimGray;
            this.lbImporteCOmprobante.Location = new System.Drawing.Point(802, 119);
            this.lbImporteCOmprobante.Name = "lbImporteCOmprobante";
            this.lbImporteCOmprobante.Size = new System.Drawing.Size(338, 25);
            this.lbImporteCOmprobante.TabIndex = 339;
            this.lbImporteCOmprobante.Text = "Ajuste de importes de cuenta corriente";
            this.lbImporteCOmprobante.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lbimporteBonificado
            // 
            this.lbimporteBonificado.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbimporteBonificado.AutoSize = true;
            this.lbimporteBonificado.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.lbimporteBonificado.ForeColor = System.Drawing.Color.DimGray;
            this.lbimporteBonificado.Location = new System.Drawing.Point(801, 148);
            this.lbimporteBonificado.Name = "lbimporteBonificado";
            this.lbimporteBonificado.Size = new System.Drawing.Size(338, 25);
            this.lbimporteBonificado.TabIndex = 340;
            this.lbimporteBonificado.Text = "Ajuste de importes de cuenta corriente";
            this.lbimporteBonificado.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // pgCircular
            // 
            this.pgCircular.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pgCircular.Location = new System.Drawing.Point(1108, 520);
            this.pgCircular.Name = "pgCircular";
            this.pgCircular.Percentage = 0F;
            this.pgCircular.Rotation = CapaPresentacion.Controles.RotationType.CounterClockwise;
            this.pgCircular.Size = new System.Drawing.Size(24, 24);
            this.pgCircular.TabIndex = 0;
            // 
            // txtDetalle
            // 
            this.txtDetalle.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtDetalle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDetalle.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDetalle.FocusColor = System.Drawing.Color.Empty;
            this.txtDetalle.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtDetalle.ForeColor = System.Drawing.Color.Black;
            this.txtDetalle.Location = new System.Drawing.Point(85, 183);
            this.txtDetalle.Multiline = true;
            this.txtDetalle.Name = "txtDetalle";
            this.txtDetalle.Numerico = false;
            this.txtDetalle.Size = new System.Drawing.Size(1050, 25);
            this.txtDetalle.TabIndex = 335;
            // 
            // dgvDatos
            // 
            this.dgvDatos.AllowUserToAddRows = false;
            this.dgvDatos.AllowUserToDeleteRows = false;
            this.dgvDatos.AllowUserToOrderColumns = true;
            this.dgvDatos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDatos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDatos.BackgroundColor = System.Drawing.Color.White;
            this.dgvDatos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDatos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.LightSlateGray;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDatos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvDatos.ColumnHeadersHeight = 40;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDatos.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvDatos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.dgvDatos.EnableHeadersVisualStyles = false;
            this.dgvDatos.GridColor = System.Drawing.Color.WhiteSmoke;
            this.dgvDatos.Location = new System.Drawing.Point(12, 230);
            this.dgvDatos.MultiSelect = false;
            this.dgvDatos.Name = "dgvDatos";
            this.dgvDatos.ReadOnly = true;
            this.dgvDatos.RowHeadersVisible = false;
            this.dgvDatos.RowHeadersWidth = 50;
            this.dgvDatos.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvDatos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvDatos.Size = new System.Drawing.Size(1120, 286);
            this.dgvDatos.TabIndex = 331;
            this.dgvDatos.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDatos_CellEndEdit);
            this.dgvDatos.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDatos_CellEnter);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnGuardar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Image = global::CapaPresentacion.Properties.Resources.Next_32;
            this.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGuardar.Location = new System.Drawing.Point(1038, 79);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(99, 33);
            this.btnGuardar.TabIndex = 330;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // frmCtaCteAjustesBonificaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(250)))), ((int)(((byte)(251)))));
            this.ClientSize = new System.Drawing.Size(1144, 545);
            this.Controls.Add(this.lbimporteBonificado);
            this.Controls.Add(this.lbImporteCOmprobante);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.lblDetalles);
            this.Controls.Add(this.pgCircular);
            this.Controls.Add(this.txtDetalle);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgvDatos);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "frmCtaCteAjustesBonificaciones";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmCtaCteAjustesBonificaciones";
            this.Load += new System.EventHandler(this.frmCtaCteAjustesBonificaciones_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmCtaCteAjustesBonificaciones_KeyDown);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgServicios_Unicos)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblTituloForm;
        private System.Windows.Forms.PictureBox imgServicios_Unicos;
        private Controles.boton btnGuardar;
        private Controles.dgv dgvDatos;
        private Controles.progress pgCircular;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private textboxAdv txtDetalle;
        private System.Windows.Forms.Label lblDetalles;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.RadioButton rdPorcentaje2;
        private System.Windows.Forms.RadioButton rdPorcentaje1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.RadioButton rdnivelservicio;
        private System.Windows.Forms.RadioButton rdnivelcomprobante;
        private System.Windows.Forms.RadioButton rdnivelsubservicio;
        private System.Windows.Forms.Label lbImporteCOmprobante;
        private System.Windows.Forms.Label lbimporteBonificado;
    }
}