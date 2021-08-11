namespace CapaPresentacion.Partes_Trabajo
{
    partial class frmEsperas
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
            this.dtFecha = new System.Windows.Forms.DateTimePicker();
            this.btnCancela = new CapaPresentacion.Controles.boton();
            this.btnGenerarEspera = new CapaPresentacion.Controles.boton();
            this.lbFecha = new System.Windows.Forms.Label();
            this.lbTitulo = new System.Windows.Forms.Label();
            this.dgvCambios = new CapaPresentacion.Controles.dgv(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCambios)).BeginInit();
            this.SuspendLayout();
            // 
            // dtFecha
            // 
            this.dtFecha.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dtFecha.Location = new System.Drawing.Point(87, 544);
            this.dtFecha.Name = "dtFecha";
            this.dtFecha.Size = new System.Drawing.Size(321, 21);
            this.dtFecha.TabIndex = 132;
            // 
            // btnCancela
            // 
            this.btnCancela.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancela.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnCancela.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancela.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnCancela.FlatAppearance.BorderSize = 0;
            this.btnCancela.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnCancela.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnCancela.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancela.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancela.ForeColor = System.Drawing.Color.White;
            this.btnCancela.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancela.Location = new System.Drawing.Point(783, 538);
            this.btnCancela.Name = "btnCancela";
            this.btnCancela.Size = new System.Drawing.Size(108, 31);
            this.btnCancela.TabIndex = 138;
            this.btnCancela.Text = "Sale";
            this.btnCancela.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancela.UseVisualStyleBackColor = false;
            this.btnCancela.Click += new System.EventHandler(this.btnCancela_Click);
            // 
            // btnGenerarEspera
            // 
            this.btnGenerarEspera.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGenerarEspera.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnGenerarEspera.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGenerarEspera.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnGenerarEspera.FlatAppearance.BorderSize = 0;
            this.btnGenerarEspera.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnGenerarEspera.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnGenerarEspera.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerarEspera.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerarEspera.ForeColor = System.Drawing.Color.White;
            this.btnGenerarEspera.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGenerarEspera.Location = new System.Drawing.Point(673, 538);
            this.btnGenerarEspera.Name = "btnGenerarEspera";
            this.btnGenerarEspera.Size = new System.Drawing.Size(108, 31);
            this.btnGenerarEspera.TabIndex = 137;
            this.btnGenerarEspera.Text = "Confirma";
            this.btnGenerarEspera.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGenerarEspera.UseVisualStyleBackColor = false;
            this.btnGenerarEspera.Click += new System.EventHandler(this.btnGenerarAviso_Click);
            // 
            // lbFecha
            // 
            this.lbFecha.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbFecha.AutoSize = true;
            this.lbFecha.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbFecha.ForeColor = System.Drawing.Color.DimGray;
            this.lbFecha.Location = new System.Drawing.Point(16, 546);
            this.lbFecha.Name = "lbFecha";
            this.lbFecha.Size = new System.Drawing.Size(41, 17);
            this.lbFecha.TabIndex = 139;
            this.lbFecha.Text = "Fecha";
            // 
            // lbTitulo
            // 
            this.lbTitulo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbTitulo.AutoSize = true;
            this.lbTitulo.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitulo.ForeColor = System.Drawing.Color.DimGray;
            this.lbTitulo.Location = new System.Drawing.Point(437, 105);
            this.lbTitulo.Name = "lbTitulo";
            this.lbTitulo.Size = new System.Drawing.Size(203, 19);
            this.lbTitulo.TabIndex = 140;
            this.lbTitulo.Text = "FECHAS DE ESPERAS PEDIDOS";
            // 
            // dgvCambios
            // 
            this.dgvCambios.AllowUserToAddRows = false;
            this.dgvCambios.AllowUserToDeleteRows = false;
            this.dgvCambios.AllowUserToOrderColumns = true;
            this.dgvCambios.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCambios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCambios.BackgroundColor = System.Drawing.Color.White;
            this.dgvCambios.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvCambios.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSlateGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCambios.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCambios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCambios.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvCambios.EnableHeadersVisualStyles = false;
            this.dgvCambios.GridColor = System.Drawing.Color.WhiteSmoke;
            this.dgvCambios.Location = new System.Drawing.Point(432, 131);
            this.dgvCambios.MultiSelect = false;
            this.dgvCambios.Name = "dgvCambios";
            this.dgvCambios.ReadOnly = true;
            this.dgvCambios.RowHeadersVisible = false;
            this.dgvCambios.RowHeadersWidth = 50;
            this.dgvCambios.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvCambios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCambios.Size = new System.Drawing.Size(453, 395);
            this.dgvCambios.TabIndex = 141;
            // 
            // frmEsperas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(905, 573);
            this.Controls.Add(this.dgvCambios);
            this.Controls.Add(this.lbTitulo);
            this.Controls.Add(this.lbFecha);
            this.Controls.Add(this.btnCancela);
            this.Controls.Add(this.btnGenerarEspera);
            this.Controls.Add(this.dtFecha);
            this.Name = "frmEsperas";
            this.Text = "frmEsperas";
            this.Load += new System.EventHandler(this.frmEsperas_Load);
            this.Controls.SetChildIndex(this.dtFecha, 0);
            this.Controls.SetChildIndex(this.btnGenerarEspera, 0);
            this.Controls.SetChildIndex(this.btnCancela, 0);
            this.Controls.SetChildIndex(this.lbFecha, 0);
            this.Controls.SetChildIndex(this.lbTitulo, 0);
            this.Controls.SetChildIndex(this.dgvCambios, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCambios)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtFecha;
        private Controles.boton btnCancela;
        private Controles.boton btnGenerarEspera;
        private System.Windows.Forms.Label lbFecha;
        private System.Windows.Forms.Label lbTitulo;
        private Controles.dgv dgvCambios;
    }
}