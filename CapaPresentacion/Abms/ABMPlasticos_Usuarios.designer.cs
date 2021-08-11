namespace CapaPresentacion.Abms
{
    partial class ABMPlasticos_Usuarios
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel3 = new System.Windows.Forms.Panel();
            this.imgReturn = new System.Windows.Forms.PictureBox();
            this.lblTituloHeader = new System.Windows.Forms.Label();
            this.lblPlasticoSeleccionado = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pnFooter = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.lblImpago = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.pgCircular = new CapaPresentacion.Controles.progress();
            this.lblServicioSeleccionado = new System.Windows.Forms.Label();
            this.lblNumPlastico = new System.Windows.Forms.Label();
            this.lblTitular = new System.Windows.Forms.Label();
            this.lblServicio = new System.Windows.Forms.Label();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.dgvServiciosAsociados = new CapaPresentacion.Controles.dgv(this.components);
            this.btnReactivar = new CapaPresentacion.Controles.boton();
            this.btnAdd = new CapaPresentacion.Controles.boton();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgReturn)).BeginInit();
            this.pnFooter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvServiciosAsociados)).BeginInit();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.panel3.Controls.Add(this.imgReturn);
            this.panel3.Controls.Add(this.lblTituloHeader);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1239, 75);
            this.panel3.TabIndex = 154;
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
            this.lblTituloHeader.Size = new System.Drawing.Size(338, 23);
            this.lblTituloHeader.TabIndex = 31;
            this.lblTituloHeader.Text = "Servicios del plástico:";
            // 
            // lblPlasticoSeleccionado
            // 
            this.lblPlasticoSeleccionado.AutoSize = true;
            this.lblPlasticoSeleccionado.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblPlasticoSeleccionado.ForeColor = System.Drawing.Color.Black;
            this.lblPlasticoSeleccionado.Location = new System.Drawing.Point(12, 83);
            this.lblPlasticoSeleccionado.Name = "lblPlasticoSeleccionado";
            this.lblPlasticoSeleccionado.Size = new System.Drawing.Size(159, 21);
            this.lblPlasticoSeleccionado.TabIndex = 247;
            this.lblPlasticoSeleccionado.Text = "Plástico seleccionado:";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.Silver;
            this.panel1.Location = new System.Drawing.Point(0, 149);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1269, 1);
            this.panel1.TabIndex = 232;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.Silver;
            this.panel2.Location = new System.Drawing.Point(0, 225);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1269, 1);
            this.panel2.TabIndex = 233;
            // 
            // pnFooter
            // 
            this.pnFooter.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnFooter.Controls.Add(this.label3);
            this.pnFooter.Controls.Add(this.lblImpago);
            this.pnFooter.Controls.Add(this.lblTotal);
            this.pnFooter.Controls.Add(this.pgCircular);
            this.pnFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnFooter.Location = new System.Drawing.Point(0, 532);
            this.pnFooter.Name = "pnFooter";
            this.pnFooter.Size = new System.Drawing.Size(1239, 30);
            this.pnFooter.TabIndex = 248;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(1086, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 335;
            this.label3.Text = "[ INACTIVO ]";
            // 
            // lblImpago
            // 
            this.lblImpago.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblImpago.AutoSize = true;
            this.lblImpago.BackColor = System.Drawing.Color.Tomato;
            this.lblImpago.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblImpago.ForeColor = System.Drawing.Color.Black;
            this.lblImpago.Location = new System.Drawing.Point(1161, 7);
            this.lblImpago.Name = "lblImpago";
            this.lblImpago.Size = new System.Drawing.Size(32, 17);
            this.lblImpago.TabIndex = 334;
            this.lblImpago.Text = "      ";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI Light", 12F);
            this.lblTotal.ForeColor = System.Drawing.Color.SlateGray;
            this.lblTotal.Location = new System.Drawing.Point(9, 2);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(141, 21);
            this.lblTotal.TabIndex = 13;
            this.lblTotal.Text = "Total de Registros: 0";
            // 
            // pgCircular
            // 
            this.pgCircular.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pgCircular.Location = new System.Drawing.Point(1203, 2);
            this.pgCircular.Name = "pgCircular";
            this.pgCircular.Percentage = 0F;
            this.pgCircular.Rotation = CapaPresentacion.Controles.RotationType.CounterClockwise;
            this.pgCircular.Size = new System.Drawing.Size(24, 24);
            this.pgCircular.TabIndex = 0;
            // 
            // lblServicioSeleccionado
            // 
            this.lblServicioSeleccionado.AutoSize = true;
            this.lblServicioSeleccionado.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblServicioSeleccionado.ForeColor = System.Drawing.Color.Black;
            this.lblServicioSeleccionado.Location = new System.Drawing.Point(12, 153);
            this.lblServicioSeleccionado.Name = "lblServicioSeleccionado";
            this.lblServicioSeleccionado.Size = new System.Drawing.Size(161, 21);
            this.lblServicioSeleccionado.TabIndex = 249;
            this.lblServicioSeleccionado.Text = "Servicio seleccionado:";
            // 
            // lblNumPlastico
            // 
            this.lblNumPlastico.AutoSize = true;
            this.lblNumPlastico.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblNumPlastico.ForeColor = System.Drawing.Color.Black;
            this.lblNumPlastico.Location = new System.Drawing.Point(12, 104);
            this.lblNumPlastico.Name = "lblNumPlastico";
            this.lblNumPlastico.Size = new System.Drawing.Size(71, 21);
            this.lblNumPlastico.TabIndex = 250;
            this.lblNumPlastico.Text = "Número:";
            // 
            // lblTitular
            // 
            this.lblTitular.AutoSize = true;
            this.lblTitular.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblTitular.ForeColor = System.Drawing.Color.Black;
            this.lblTitular.Location = new System.Drawing.Point(12, 125);
            this.lblTitular.Name = "lblTitular";
            this.lblTitular.Size = new System.Drawing.Size(57, 21);
            this.lblTitular.TabIndex = 251;
            this.lblTitular.Text = "Titular:";
            // 
            // lblServicio
            // 
            this.lblServicio.AutoSize = true;
            this.lblServicio.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblServicio.ForeColor = System.Drawing.Color.Black;
            this.lblServicio.Location = new System.Drawing.Point(12, 174);
            this.lblServicio.Name = "lblServicio";
            this.lblServicio.Size = new System.Drawing.Size(68, 21);
            this.lblServicio.TabIndex = 254;
            this.lblServicio.Text = "Servicio:";
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblUsuario.ForeColor = System.Drawing.Color.Black;
            this.lblUsuario.Location = new System.Drawing.Point(11, 196);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(67, 21);
            this.lblUsuario.TabIndex = 255;
            this.lblUsuario.Text = "Usuario:";
            // 
            // dgvServiciosAsociados
            // 
            this.dgvServiciosAsociados.AllowUserToAddRows = false;
            this.dgvServiciosAsociados.AllowUserToDeleteRows = false;
            this.dgvServiciosAsociados.AllowUserToOrderColumns = true;
            this.dgvServiciosAsociados.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvServiciosAsociados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvServiciosAsociados.BackgroundColor = System.Drawing.Color.White;
            this.dgvServiciosAsociados.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvServiciosAsociados.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSlateGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI Light", 12F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvServiciosAsociados.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvServiciosAsociados.ColumnHeadersHeight = 40;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Light", 12F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvServiciosAsociados.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvServiciosAsociados.EnableHeadersVisualStyles = false;
            this.dgvServiciosAsociados.GridColor = System.Drawing.Color.WhiteSmoke;
            this.dgvServiciosAsociados.Location = new System.Drawing.Point(12, 232);
            this.dgvServiciosAsociados.MultiSelect = false;
            this.dgvServiciosAsociados.Name = "dgvServiciosAsociados";
            this.dgvServiciosAsociados.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI Light", 12F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvServiciosAsociados.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvServiciosAsociados.RowHeadersVisible = false;
            this.dgvServiciosAsociados.RowHeadersWidth = 50;
            this.dgvServiciosAsociados.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvServiciosAsociados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvServiciosAsociados.Size = new System.Drawing.Size(1215, 283);
            this.dgvServiciosAsociados.TabIndex = 233;
            this.dgvServiciosAsociados.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvServiciosAsociados_CellEnter);
            this.dgvServiciosAsociados.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvServiciosAsociados_CellFormatting);
            this.dgvServiciosAsociados.SelectionChanged += new System.EventHandler(this.dgvServiciosAsociados_SelectionChanged);
            // 
            // btnReactivar
            // 
            this.btnReactivar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnReactivar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnReactivar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReactivar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnReactivar.FlatAppearance.BorderSize = 0;
            this.btnReactivar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnReactivar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnReactivar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReactivar.Font = new System.Drawing.Font("Segoe UI Light", 12F);
            this.btnReactivar.ForeColor = System.Drawing.Color.White;
            this.btnReactivar.Image = global::CapaPresentacion.Properties.Resources.Command_Refresh_32;
            this.btnReactivar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnReactivar.Location = new System.Drawing.Point(1070, 164);
            this.btnReactivar.Name = "btnReactivar";
            this.btnReactivar.Size = new System.Drawing.Size(157, 40);
            this.btnReactivar.TabIndex = 369;
            this.btnReactivar.Text = "Reactivar servicio";
            this.btnReactivar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReactivar.UseVisualStyleBackColor = false;
            this.btnReactivar.Click += new System.EventHandler(this.btnReactivar_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdd.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnAdd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI Light", 12F);
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Image = global::CapaPresentacion.Properties.Resources.Data_Add_32;
            this.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAdd.Location = new System.Drawing.Point(907, 164);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(157, 40);
            this.btnAdd.TabIndex = 368;
            this.btnAdd.Text = "Agregar servicio";
            this.btnAdd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // ABMPlasticos_Usuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(250)))), ((int)(((byte)(251)))));
            this.ClientSize = new System.Drawing.Size(1239, 562);
            this.Controls.Add(this.btnReactivar);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.lblServicio);
            this.Controls.Add(this.lblTitular);
            this.Controls.Add(this.lblNumPlastico);
            this.Controls.Add(this.lblServicioSeleccionado);
            this.Controls.Add(this.pnFooter);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblPlasticoSeleccionado);
            this.Controls.Add(this.dgvServiciosAsociados);
            this.Controls.Add(this.panel3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Name = "ABMPlasticos_Usuarios";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Servicios del plastico";
            this.Load += new System.EventHandler(this.ABMPlasticosUsuarios_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ABMPlasticosUsuarios_KeyDown);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgReturn)).EndInit();
            this.pnFooter.ResumeLayout(false);
            this.pnFooter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvServiciosAsociados)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox imgReturn;
        private System.Windows.Forms.Label lblTituloHeader;
        private Controles.dgv dgvServiciosAsociados;
        private System.Windows.Forms.Label lblPlasticoSeleccionado;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel pnFooter;
        private System.Windows.Forms.Label lblTotal;
        private Controles.progress pgCircular;
        private System.Windows.Forms.Label lblServicioSeleccionado;
        private System.Windows.Forms.Label lblNumPlastico;
        private System.Windows.Forms.Label lblTitular;
        private System.Windows.Forms.Label lblServicio;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblImpago;
        private Controles.boton btnReactivar;
        private Controles.boton btnAdd;
    }
}