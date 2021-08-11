
namespace CapaPresentacion.AppExternas
{
    partial class frmRelacionVelocidades
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlSuperior = new System.Windows.Forms.Panel();
            this.imgReturn = new System.Windows.Forms.PictureBox();
            this.lblTituloHeader = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.lblOperacionDato = new System.Windows.Forms.Label();
            this.cboVelocidad = new CapaPresentacion.Controles.combo(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.cboVelocidadTipo = new CapaPresentacion.Controles.combo(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.cboPaquetes = new CapaPresentacion.Controles.combo(this.components);
            this.btnAsociar = new CapaPresentacion.Controles.boton();
            this.btnEliminar = new CapaPresentacion.Controles.boton();
            this.pnlTotales = new System.Windows.Forms.Panel();
            this.pgCircular = new CapaPresentacion.Controles.progress();
            this.lblTotal = new System.Windows.Forms.Label();
            this.dgvRelaciones = new CapaPresentacion.Controles.dgv(this.components);
            this.pnlSuperior.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgReturn)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.pnlTotales.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRelaciones)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlSuperior
            // 
            this.pnlSuperior.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.pnlSuperior.Controls.Add(this.imgReturn);
            this.pnlSuperior.Controls.Add(this.lblTituloHeader);
            this.pnlSuperior.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSuperior.Location = new System.Drawing.Point(0, 0);
            this.pnlSuperior.Name = "pnlSuperior";
            this.pnlSuperior.Size = new System.Drawing.Size(1274, 75);
            this.pnlSuperior.TabIndex = 53;
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
            this.lblTituloHeader.Size = new System.Drawing.Size(446, 23);
            this.lblTituloHeader.TabIndex = 31;
            this.lblTituloHeader.Text = "Relacion Velocidad - Paquetes externos ISP";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.lblOperacionDato);
            this.flowLayoutPanel1.Controls.Add(this.cboVelocidad);
            this.flowLayoutPanel1.Controls.Add(this.label1);
            this.flowLayoutPanel1.Controls.Add(this.cboVelocidadTipo);
            this.flowLayoutPanel1.Controls.Add(this.label2);
            this.flowLayoutPanel1.Controls.Add(this.cboPaquetes);
            this.flowLayoutPanel1.Controls.Add(this.btnAsociar);
            this.flowLayoutPanel1.Controls.Add(this.btnEliminar);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 75);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1274, 42);
            this.flowLayoutPanel1.TabIndex = 338;
            // 
            // lblOperacionDato
            // 
            this.lblOperacionDato.AutoSize = true;
            this.lblOperacionDato.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblOperacionDato.Location = new System.Drawing.Point(3, 0);
            this.lblOperacionDato.Name = "lblOperacionDato";
            this.lblOperacionDato.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.lblOperacionDato.Size = new System.Drawing.Size(77, 26);
            this.lblOperacionDato.TabIndex = 331;
            this.lblOperacionDato.Text = "Velocidad";
            // 
            // cboVelocidad
            // 
            this.cboVelocidad.BorderColor = System.Drawing.Color.Gainsboro;
            this.cboVelocidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboVelocidad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboVelocidad.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboVelocidad.FormattingEnabled = true;
            this.cboVelocidad.Location = new System.Drawing.Point(86, 3);
            this.cboVelocidad.Name = "cboVelocidad";
            this.cboVelocidad.Size = new System.Drawing.Size(67, 29);
            this.cboVelocidad.TabIndex = 68;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label1.Location = new System.Drawing.Point(159, 0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.label1.Size = new System.Drawing.Size(131, 26);
            this.label1.TabIndex = 333;
            this.label1.Text = "Tipo de velocidad";
            // 
            // cboVelocidadTipo
            // 
            this.cboVelocidadTipo.BorderColor = System.Drawing.Color.Gainsboro;
            this.cboVelocidadTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboVelocidadTipo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboVelocidadTipo.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboVelocidadTipo.FormattingEnabled = true;
            this.cboVelocidadTipo.Location = new System.Drawing.Point(296, 3);
            this.cboVelocidadTipo.Name = "cboVelocidadTipo";
            this.cboVelocidadTipo.Size = new System.Drawing.Size(164, 29);
            this.cboVelocidadTipo.TabIndex = 332;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label2.Location = new System.Drawing.Point(466, 0);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.label2.Size = new System.Drawing.Size(121, 26);
            this.label2.TabIndex = 335;
            this.label2.Text = "Paquete externo";
            // 
            // cboPaquetes
            // 
            this.cboPaquetes.BorderColor = System.Drawing.Color.Gainsboro;
            this.cboPaquetes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPaquetes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboPaquetes.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboPaquetes.FormattingEnabled = true;
            this.cboPaquetes.Location = new System.Drawing.Point(593, 3);
            this.cboPaquetes.Name = "cboPaquetes";
            this.cboPaquetes.Size = new System.Drawing.Size(405, 29);
            this.cboPaquetes.TabIndex = 334;
            // 
            // btnAsociar
            // 
            this.btnAsociar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAsociar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnAsociar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAsociar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnAsociar.FlatAppearance.BorderSize = 0;
            this.btnAsociar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnAsociar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnAsociar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAsociar.Font = new System.Drawing.Font("Segoe UI Light", 12F);
            this.btnAsociar.ForeColor = System.Drawing.Color.White;
            this.btnAsociar.Image = global::CapaPresentacion.Properties.Resources.Data_Add_32;
            this.btnAsociar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAsociar.Location = new System.Drawing.Point(1004, 3);
            this.btnAsociar.Name = "btnAsociar";
            this.btnAsociar.Size = new System.Drawing.Size(100, 29);
            this.btnAsociar.TabIndex = 336;
            this.btnAsociar.Text = "Asociar";
            this.btnAsociar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAsociar.UseVisualStyleBackColor = false;
            this.btnAsociar.Click += new System.EventHandler(this.btnAsociar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEliminar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnEliminar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnEliminar.FlatAppearance.BorderSize = 0;
            this.btnEliminar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnEliminar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.Font = new System.Drawing.Font("Segoe UI Light", 12F);
            this.btnEliminar.ForeColor = System.Drawing.Color.White;
            this.btnEliminar.Image = global::CapaPresentacion.Properties.Resources.Data_Delete_32;
            this.btnEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEliminar.Location = new System.Drawing.Point(1110, 3);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(100, 29);
            this.btnEliminar.TabIndex = 337;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // pnlTotales
            // 
            this.pnlTotales.Controls.Add(this.pgCircular);
            this.pnlTotales.Controls.Add(this.lblTotal);
            this.pnlTotales.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlTotales.Location = new System.Drawing.Point(0, 476);
            this.pnlTotales.Name = "pnlTotales";
            this.pnlTotales.Size = new System.Drawing.Size(1274, 32);
            this.pnlTotales.TabIndex = 380;
            // 
            // pgCircular
            // 
            this.pgCircular.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pgCircular.Location = new System.Drawing.Point(1238, 5);
            this.pgCircular.Name = "pgCircular";
            this.pgCircular.Percentage = 0F;
            this.pgCircular.Rotation = CapaPresentacion.Controles.RotationType.CounterClockwise;
            this.pgCircular.Size = new System.Drawing.Size(24, 24);
            this.pgCircular.TabIndex = 337;
            // 
            // lblTotal
            // 
            this.lblTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblTotal.ForeColor = System.Drawing.Color.Black;
            this.lblTotal.Location = new System.Drawing.Point(3, 5);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(158, 21);
            this.lblTotal.TabIndex = 336;
            this.lblTotal.Text = "Cantidad de registros";
            // 
            // dgvRelaciones
            // 
            this.dgvRelaciones.AllowUserToAddRows = false;
            this.dgvRelaciones.AllowUserToDeleteRows = false;
            this.dgvRelaciones.AllowUserToOrderColumns = true;
            this.dgvRelaciones.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRelaciones.BackgroundColor = System.Drawing.Color.White;
            this.dgvRelaciones.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvRelaciones.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.LightSlateGray;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRelaciones.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvRelaciones.ColumnHeadersHeight = 40;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvRelaciones.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgvRelaciones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRelaciones.EnableHeadersVisualStyles = false;
            this.dgvRelaciones.GridColor = System.Drawing.Color.WhiteSmoke;
            this.dgvRelaciones.Location = new System.Drawing.Point(0, 117);
            this.dgvRelaciones.MultiSelect = false;
            this.dgvRelaciones.Name = "dgvRelaciones";
            this.dgvRelaciones.ReadOnly = true;
            this.dgvRelaciones.RowHeadersVisible = false;
            this.dgvRelaciones.RowHeadersWidth = 50;
            this.dgvRelaciones.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvRelaciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRelaciones.Size = new System.Drawing.Size(1274, 359);
            this.dgvRelaciones.TabIndex = 337;
            // 
            // frmRelacionVelocidades
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1274, 508);
            this.Controls.Add(this.dgvRelaciones);
            this.Controls.Add(this.pnlTotales);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.pnlSuperior);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "frmRelacionVelocidades";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Relacion Velocidades";
            this.Load += new System.EventHandler(this.frmRelacionVelocidades_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmRelacionVelocidades_KeyDown);
            this.pnlSuperior.ResumeLayout(false);
            this.pnlSuperior.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgReturn)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.pnlTotales.ResumeLayout(false);
            this.pnlTotales.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRelaciones)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlSuperior;
        private System.Windows.Forms.PictureBox imgReturn;
        private System.Windows.Forms.Label lblTituloHeader;
        private Controles.dgv dgvRelaciones;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private Controles.combo cboVelocidad;
        private System.Windows.Forms.Label lblOperacionDato;
        private System.Windows.Forms.Label label1;
        private Controles.combo cboVelocidadTipo;
        private System.Windows.Forms.Label label2;
        private Controles.combo cboPaquetes;
        private Controles.boton btnAsociar;
        private System.Windows.Forms.Panel pnlTotales;
        private System.Windows.Forms.Label lblTotal;
        private Controles.progress pgCircular;
        private Controles.boton btnEliminar;
    }
}