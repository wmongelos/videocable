namespace CapaPresentacion
{
    partial class frmAgregarSubservicio
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.imgReturn = new System.Windows.Forms.PictureBox();
            this.lblTituloHeader = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblServicio = new System.Windows.Forms.Label();
            this.lblSubServSeleccionado = new System.Windows.Forms.Label();
            this.btnAgregarSubServ = new CapaPresentacion.Controles.boton();
            this.dgvSubServDisponibles = new CapaPresentacion.Controles.dgv(this.components);
            this.pnFooter = new System.Windows.Forms.Panel();
            this.lblTotal = new System.Windows.Forms.Label();
            this.pgCircular = new CapaPresentacion.Controles.progress();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.lblFechaInicioServicio = new System.Windows.Forms.Label();
            this.chkGenerarDeuda = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgReturn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSubServDisponibles)).BeginInit();
            this.pnFooter.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.panel1.Controls.Add(this.imgReturn);
            this.panel1.Controls.Add(this.lblTituloHeader);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(951, 75);
            this.panel1.TabIndex = 239;
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
            this.lblTituloHeader.Size = new System.Drawing.Size(338, 27);
            this.lblTituloHeader.TabIndex = 31;
            this.lblTituloHeader.Text = "Agregar subservicio:";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.Gainsboro;
            this.panel2.Location = new System.Drawing.Point(0, 133);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(956, 1);
            this.panel2.TabIndex = 252;
            // 
            // lblServicio
            // 
            this.lblServicio.AutoSize = true;
            this.lblServicio.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblServicio.ForeColor = System.Drawing.Color.Black;
            this.lblServicio.Location = new System.Drawing.Point(11, 87);
            this.lblServicio.Name = "lblServicio";
            this.lblServicio.Size = new System.Drawing.Size(68, 21);
            this.lblServicio.TabIndex = 307;
            this.lblServicio.Text = "Servicio:";
            // 
            // lblSubServSeleccionado
            // 
            this.lblSubServSeleccionado.AutoSize = true;
            this.lblSubServSeleccionado.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubServSeleccionado.ForeColor = System.Drawing.Color.Black;
            this.lblSubServSeleccionado.Location = new System.Drawing.Point(12, 108);
            this.lblSubServSeleccionado.Name = "lblSubServSeleccionado";
            this.lblSubServSeleccionado.Size = new System.Drawing.Size(186, 21);
            this.lblSubServSeleccionado.TabIndex = 308;
            this.lblSubServSeleccionado.Text = "Subservicio seleccionado:";
            // 
            // btnAgregarSubServ
            // 
            this.btnAgregarSubServ.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAgregarSubServ.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnAgregarSubServ.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregarSubServ.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnAgregarSubServ.FlatAppearance.BorderSize = 0;
            this.btnAgregarSubServ.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnAgregarSubServ.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnAgregarSubServ.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarSubServ.Font = new System.Drawing.Font("Segoe UI Light", 12F);
            this.btnAgregarSubServ.ForeColor = System.Drawing.Color.White;
            this.btnAgregarSubServ.Image = global::CapaPresentacion.Properties.Resources.Data_Add_32;
            this.btnAgregarSubServ.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAgregarSubServ.Location = new System.Drawing.Point(841, 91);
            this.btnAgregarSubServ.Name = "btnAgregarSubServ";
            this.btnAgregarSubServ.Size = new System.Drawing.Size(98, 38);
            this.btnAgregarSubServ.TabIndex = 309;
            this.btnAgregarSubServ.Text = "Agregar";
            this.btnAgregarSubServ.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgregarSubServ.UseVisualStyleBackColor = false;
            this.btnAgregarSubServ.Click += new System.EventHandler(this.btnAgregarSubServ_Click);
            // 
            // dgvSubServDisponibles
            // 
            this.dgvSubServDisponibles.AllowUserToAddRows = false;
            this.dgvSubServDisponibles.AllowUserToDeleteRows = false;
            this.dgvSubServDisponibles.AllowUserToOrderColumns = true;
            this.dgvSubServDisponibles.AllowUserToResizeColumns = false;
            this.dgvSubServDisponibles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSubServDisponibles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSubServDisponibles.BackgroundColor = System.Drawing.Color.White;
            this.dgvSubServDisponibles.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvSubServDisponibles.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.LightSlateGray;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSubServDisponibles.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvSubServDisponibles.ColumnHeadersHeight = 40;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSubServDisponibles.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvSubServDisponibles.EnableHeadersVisualStyles = false;
            this.dgvSubServDisponibles.GridColor = System.Drawing.Color.WhiteSmoke;
            this.dgvSubServDisponibles.Location = new System.Drawing.Point(15, 140);
            this.dgvSubServDisponibles.MultiSelect = false;
            this.dgvSubServDisponibles.Name = "dgvSubServDisponibles";
            this.dgvSubServDisponibles.ReadOnly = true;
            this.dgvSubServDisponibles.RowHeadersVisible = false;
            this.dgvSubServDisponibles.RowHeadersWidth = 50;
            this.dgvSubServDisponibles.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvSubServDisponibles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSubServDisponibles.Size = new System.Drawing.Size(924, 274);
            this.dgvSubServDisponibles.TabIndex = 310;
            this.dgvSubServDisponibles.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSubServDisponibles_CellEnter);
            // 
            // pnFooter
            // 
            this.pnFooter.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnFooter.Controls.Add(this.lblTotal);
            this.pnFooter.Controls.Add(this.pgCircular);
            this.pnFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnFooter.Location = new System.Drawing.Point(0, 420);
            this.pnFooter.Name = "pnFooter";
            this.pnFooter.Size = new System.Drawing.Size(951, 30);
            this.pnFooter.TabIndex = 311;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblTotal.ForeColor = System.Drawing.Color.SlateGray;
            this.lblTotal.Location = new System.Drawing.Point(12, 5);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(150, 21);
            this.lblTotal.TabIndex = 13;
            this.lblTotal.Text = "Total de Registros: 0";
            // 
            // pgCircular
            // 
            this.pgCircular.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pgCircular.Location = new System.Drawing.Point(915, 2);
            this.pgCircular.Name = "pgCircular";
            this.pgCircular.Percentage = 0F;
            this.pgCircular.Rotation = CapaPresentacion.Controles.RotationType.CounterClockwise;
            this.pgCircular.Size = new System.Drawing.Size(24, 24);
            this.pgCircular.TabIndex = 0;
            // 
            // dtpFecha
            // 
            this.dtpFecha.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpFecha.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFecha.Location = new System.Drawing.Point(570, 99);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(117, 29);
            this.dtpFecha.TabIndex = 315;
            // 
            // lblFechaInicioServicio
            // 
            this.lblFechaInicioServicio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFechaInicioServicio.AutoSize = true;
            this.lblFechaInicioServicio.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblFechaInicioServicio.ForeColor = System.Drawing.Color.Black;
            this.lblFechaInicioServicio.Location = new System.Drawing.Point(392, 105);
            this.lblFechaInicioServicio.Name = "lblFechaInicioServicio";
            this.lblFechaInicioServicio.Size = new System.Drawing.Size(172, 21);
            this.lblFechaInicioServicio.TabIndex = 314;
            this.lblFechaInicioServicio.Text = "Fecha de inicio servicio:";
            // 
            // chkGenerarDeuda
            // 
            this.chkGenerarDeuda.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkGenerarDeuda.AutoSize = true;
            this.chkGenerarDeuda.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.chkGenerarDeuda.Location = new System.Drawing.Point(703, 104);
            this.chkGenerarDeuda.Name = "chkGenerarDeuda";
            this.chkGenerarDeuda.Size = new System.Drawing.Size(132, 25);
            this.chkGenerarDeuda.TabIndex = 316;
            this.chkGenerarDeuda.Text = "Generar deuda";
            this.chkGenerarDeuda.UseVisualStyleBackColor = true;
            // 
            // frmAgregarSubservicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(250)))), ((int)(((byte)(251)))));
            this.ClientSize = new System.Drawing.Size(951, 450);
            this.Controls.Add(this.chkGenerarDeuda);
            this.Controls.Add(this.dtpFecha);
            this.Controls.Add(this.lblFechaInicioServicio);
            this.Controls.Add(this.pnFooter);
            this.Controls.Add(this.dgvSubServDisponibles);
            this.Controls.Add(this.btnAgregarSubServ);
            this.Controls.Add(this.lblSubServSeleccionado);
            this.Controls.Add(this.lblServicio);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "frmAgregarSubservicio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmAgregarSubservicio";
            this.Load += new System.EventHandler(this.frmAgregarSubservicio_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmAgregarSubservicio_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgReturn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSubServDisponibles)).EndInit();
            this.pnFooter.ResumeLayout(false);
            this.pnFooter.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox imgReturn;
        private System.Windows.Forms.Label lblTituloHeader;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblServicio;
        private System.Windows.Forms.Label lblSubServSeleccionado;
        private Controles.boton btnAgregarSubServ;
        private Controles.dgv dgvSubServDisponibles;
        private System.Windows.Forms.Panel pnFooter;
        private System.Windows.Forms.Label lblTotal;
        private Controles.progress pgCircular;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Label lblFechaInicioServicio;
        private System.Windows.Forms.CheckBox chkGenerarDeuda;
    }
}