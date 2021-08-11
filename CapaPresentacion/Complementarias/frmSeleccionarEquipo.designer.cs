namespace CapaPresentacion.Complementarias
{
    partial class frmSeleccionarEquipo
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
            this.LbTitulos = new System.Windows.Forms.Label();
            this.imgReturn = new System.Windows.Forms.PictureBox();
            this.dgvPresentacion = new CapaPresentacion.Controles.dgv(this.components);
            this.pnlPie = new System.Windows.Forms.Panel();
            this.pgCircular = new CapaPresentacion.Controles.progress();
            this.pnLinea1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgReturn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPresentacion)).BeginInit();
            this.pnlPie.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnLinea1
            // 
            this.pnLinea1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.pnLinea1.Controls.Add(this.LbTitulos);
            this.pnLinea1.Controls.Add(this.imgReturn);
            this.pnLinea1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnLinea1.Location = new System.Drawing.Point(0, 0);
            this.pnLinea1.Name = "pnLinea1";
            this.pnLinea1.Size = new System.Drawing.Size(800, 83);
            this.pnLinea1.TabIndex = 171;
            // 
            // LbTitulos
            // 
            this.LbTitulos.AutoSize = true;
            this.LbTitulos.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LbTitulos.ForeColor = System.Drawing.Color.Transparent;
            this.LbTitulos.Location = new System.Drawing.Point(53, 31);
            this.LbTitulos.Name = "LbTitulos";
            this.LbTitulos.Size = new System.Drawing.Size(173, 25);
            this.LbTitulos.TabIndex = 172;
            this.LbTitulos.Text = "Seleccionar equipo";
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
            // dgvPresentacion
            // 
            this.dgvPresentacion.AllowUserToAddRows = false;
            this.dgvPresentacion.AllowUserToDeleteRows = false;
            this.dgvPresentacion.AllowUserToOrderColumns = true;
            this.dgvPresentacion.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPresentacion.BackgroundColor = System.Drawing.Color.White;
            this.dgvPresentacion.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvPresentacion.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSlateGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPresentacion.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPresentacion.ColumnHeadersHeight = 40;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPresentacion.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvPresentacion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPresentacion.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.dgvPresentacion.EnableHeadersVisualStyles = false;
            this.dgvPresentacion.GridColor = System.Drawing.Color.WhiteSmoke;
            this.dgvPresentacion.Location = new System.Drawing.Point(0, 83);
            this.dgvPresentacion.MultiSelect = false;
            this.dgvPresentacion.Name = "dgvPresentacion";
            this.dgvPresentacion.ReadOnly = true;
            this.dgvPresentacion.RowHeadersVisible = false;
            this.dgvPresentacion.RowHeadersWidth = 50;
            this.dgvPresentacion.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvPresentacion.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPresentacion.Size = new System.Drawing.Size(800, 367);
            this.dgvPresentacion.TabIndex = 185;
            this.dgvPresentacion.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPresentacion_CellContentClick);
            this.dgvPresentacion.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPresentacion_CellEnter);
            // 
            // pnlPie
            // 
            this.pnlPie.Controls.Add(this.pgCircular);
            this.pnlPie.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlPie.Location = new System.Drawing.Point(0, 413);
            this.pnlPie.Name = "pnlPie";
            this.pnlPie.Size = new System.Drawing.Size(800, 37);
            this.pnlPie.TabIndex = 187;
            // 
            // pgCircular
            // 
            this.pgCircular.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pgCircular.Location = new System.Drawing.Point(762, 5);
            this.pgCircular.Name = "pgCircular";
            this.pgCircular.Percentage = 0F;
            this.pgCircular.Rotation = CapaPresentacion.Controles.RotationType.CounterClockwise;
            this.pgCircular.Size = new System.Drawing.Size(27, 27);
            this.pgCircular.TabIndex = 206;
            // 
            // frmSeleccionarEquipo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pnlPie);
            this.Controls.Add(this.dgvPresentacion);
            this.Controls.Add(this.pnLinea1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "frmSeleccionarEquipo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmSeleccionarEquipo";
            this.Load += new System.EventHandler(this.frmSeleccionarEquipo_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmSeleccionarEquipo_KeyDown);
            this.pnLinea1.ResumeLayout(false);
            this.pnLinea1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgReturn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPresentacion)).EndInit();
            this.pnlPie.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnLinea1;
        private System.Windows.Forms.Label LbTitulos;
        private System.Windows.Forms.PictureBox imgReturn;
        private Controles.dgv dgvPresentacion;
        private System.Windows.Forms.Panel pnlPie;
        private Controles.progress pgCircular;
    }
}