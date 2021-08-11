namespace CapaPresentacion
{
    partial class frmSubserviciosDelUsuario
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.imgReturn = new System.Windows.Forms.PictureBox();
            this.lblTituloHeader = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pnFooter = new System.Windows.Forms.Panel();
            this.lblTotal = new System.Windows.Forms.Label();
            this.pgCircular = new CapaPresentacion.Controles.progress();
            this.lblServiciosContratados = new System.Windows.Forms.Label();
            this.lblSubServiciosContratados = new System.Windows.Forms.Label();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.lblLocacion = new System.Windows.Forms.Label();
            this.dgvSubServContratados = new CapaPresentacion.Controles.dgv(this.components);
            this.dgvServiciosContratados = new CapaPresentacion.Controles.dgv(this.components);
            this.btnAgregarSubServ = new CapaPresentacion.Controles.boton();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgReturn)).BeginInit();
            this.pnFooter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSubServContratados)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvServiciosContratados)).BeginInit();
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
            this.panel1.Size = new System.Drawing.Size(1050, 75);
            this.panel1.TabIndex = 238;
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
            this.lblTituloHeader.Text = "Subservicios del usuario:";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.Gainsboro;
            this.panel2.Location = new System.Drawing.Point(0, 129);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1059, 1);
            this.panel2.TabIndex = 251;
            // 
            // pnFooter
            // 
            this.pnFooter.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnFooter.Controls.Add(this.lblTotal);
            this.pnFooter.Controls.Add(this.pgCircular);
            this.pnFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnFooter.Location = new System.Drawing.Point(0, 441);
            this.pnFooter.Name = "pnFooter";
            this.pnFooter.Size = new System.Drawing.Size(1050, 30);
            this.pnFooter.TabIndex = 302;
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
            this.pgCircular.Location = new System.Drawing.Point(1014, 2);
            this.pgCircular.Name = "pgCircular";
            this.pgCircular.Percentage = 0F;
            this.pgCircular.Rotation = CapaPresentacion.Controles.RotationType.CounterClockwise;
            this.pgCircular.Size = new System.Drawing.Size(24, 24);
            this.pgCircular.TabIndex = 0;
            // 
            // lblServiciosContratados
            // 
            this.lblServiciosContratados.AutoSize = true;
            this.lblServiciosContratados.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblServiciosContratados.ForeColor = System.Drawing.Color.Black;
            this.lblServiciosContratados.Location = new System.Drawing.Point(12, 147);
            this.lblServiciosContratados.Name = "lblServiciosContratados";
            this.lblServiciosContratados.Size = new System.Drawing.Size(161, 21);
            this.lblServiciosContratados.TabIndex = 303;
            this.lblServiciosContratados.Text = "Servicios contratados:";
            // 
            // lblSubServiciosContratados
            // 
            this.lblSubServiciosContratados.AutoSize = true;
            this.lblSubServiciosContratados.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubServiciosContratados.ForeColor = System.Drawing.Color.Black;
            this.lblSubServiciosContratados.Location = new System.Drawing.Point(376, 147);
            this.lblSubServiciosContratados.Name = "lblSubServiciosContratados";
            this.lblSubServiciosContratados.Size = new System.Drawing.Size(100, 21);
            this.lblSubServiciosContratados.TabIndex = 304;
            this.lblSubServiciosContratados.Text = "Subservicios:";
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuario.ForeColor = System.Drawing.Color.Black;
            this.lblUsuario.Location = new System.Drawing.Point(12, 84);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(67, 21);
            this.lblUsuario.TabIndex = 306;
            this.lblUsuario.Text = "Usuario:";
            // 
            // lblLocacion
            // 
            this.lblLocacion.AutoSize = true;
            this.lblLocacion.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLocacion.ForeColor = System.Drawing.Color.Black;
            this.lblLocacion.Location = new System.Drawing.Point(12, 105);
            this.lblLocacion.Name = "lblLocacion";
            this.lblLocacion.Size = new System.Drawing.Size(166, 21);
            this.lblLocacion.TabIndex = 308;
            this.lblLocacion.Text = "Locación seleccionada:";
            // 
            // dgvSubServContratados
            // 
            this.dgvSubServContratados.AllowUserToAddRows = false;
            this.dgvSubServContratados.AllowUserToDeleteRows = false;
            this.dgvSubServContratados.AllowUserToOrderColumns = true;
            this.dgvSubServContratados.AllowUserToResizeColumns = false;
            this.dgvSubServContratados.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSubServContratados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSubServContratados.BackgroundColor = System.Drawing.Color.White;
            this.dgvSubServContratados.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvSubServContratados.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSlateGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSubServContratados.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvSubServContratados.ColumnHeadersHeight = 40;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSubServContratados.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvSubServContratados.EnableHeadersVisualStyles = false;
            this.dgvSubServContratados.GridColor = System.Drawing.Color.WhiteSmoke;
            this.dgvSubServContratados.Location = new System.Drawing.Point(380, 180);
            this.dgvSubServContratados.MultiSelect = false;
            this.dgvSubServContratados.Name = "dgvSubServContratados";
            this.dgvSubServContratados.ReadOnly = true;
            this.dgvSubServContratados.RowHeadersVisible = false;
            this.dgvSubServContratados.RowHeadersWidth = 50;
            this.dgvSubServContratados.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvSubServContratados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSubServContratados.Size = new System.Drawing.Size(658, 255);
            this.dgvSubServContratados.TabIndex = 301;
            this.dgvSubServContratados.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSubServContratados_CellContentClick);
            // 
            // dgvServiciosContratados
            // 
            this.dgvServiciosContratados.AllowUserToAddRows = false;
            this.dgvServiciosContratados.AllowUserToDeleteRows = false;
            this.dgvServiciosContratados.AllowUserToOrderColumns = true;
            this.dgvServiciosContratados.AllowUserToResizeColumns = false;
            this.dgvServiciosContratados.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgvServiciosContratados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvServiciosContratados.BackgroundColor = System.Drawing.Color.White;
            this.dgvServiciosContratados.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvServiciosContratados.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.LightSlateGray;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvServiciosContratados.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvServiciosContratados.ColumnHeadersHeight = 40;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvServiciosContratados.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvServiciosContratados.EnableHeadersVisualStyles = false;
            this.dgvServiciosContratados.GridColor = System.Drawing.Color.WhiteSmoke;
            this.dgvServiciosContratados.Location = new System.Drawing.Point(15, 180);
            this.dgvServiciosContratados.MultiSelect = false;
            this.dgvServiciosContratados.Name = "dgvServiciosContratados";
            this.dgvServiciosContratados.ReadOnly = true;
            this.dgvServiciosContratados.RowHeadersVisible = false;
            this.dgvServiciosContratados.RowHeadersWidth = 50;
            this.dgvServiciosContratados.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvServiciosContratados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvServiciosContratados.Size = new System.Drawing.Size(345, 255);
            this.dgvServiciosContratados.TabIndex = 300;
            this.dgvServiciosContratados.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvServiciosContratados_CellEnter);
            // 
            // btnAgregarSubServ
            // 
            this.btnAgregarSubServ.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAgregarSubServ.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnAgregarSubServ.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregarSubServ.Enabled = false;
            this.btnAgregarSubServ.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnAgregarSubServ.FlatAppearance.BorderSize = 0;
            this.btnAgregarSubServ.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnAgregarSubServ.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnAgregarSubServ.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarSubServ.Font = new System.Drawing.Font("Segoe UI Light", 12F);
            this.btnAgregarSubServ.ForeColor = System.Drawing.Color.White;
            this.btnAgregarSubServ.Image = global::CapaPresentacion.Properties.Resources.Data_Add_32;
            this.btnAgregarSubServ.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAgregarSubServ.Location = new System.Drawing.Point(864, 138);
            this.btnAgregarSubServ.Name = "btnAgregarSubServ";
            this.btnAgregarSubServ.Size = new System.Drawing.Size(174, 38);
            this.btnAgregarSubServ.TabIndex = 305;
            this.btnAgregarSubServ.Text = "Agregar subservicio";
            this.btnAgregarSubServ.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgregarSubServ.UseVisualStyleBackColor = false;
            this.btnAgregarSubServ.Click += new System.EventHandler(this.btnAgregarSubServ_Click);
            // 
            // frmSubserviciosDelUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(250)))), ((int)(((byte)(251)))));
            this.ClientSize = new System.Drawing.Size(1050, 471);
            this.Controls.Add(this.lblLocacion);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.btnAgregarSubServ);
            this.Controls.Add(this.lblSubServiciosContratados);
            this.Controls.Add(this.lblServiciosContratados);
            this.Controls.Add(this.pnFooter);
            this.Controls.Add(this.dgvSubServContratados);
            this.Controls.Add(this.dgvServiciosContratados);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmSubserviciosDelUsuario";
            this.Text = "frmServiciosDelUsuario";
            this.Load += new System.EventHandler(this.frmServiciosDelUsuario_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmSubserviciosDelUsuario_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgReturn)).EndInit();
            this.pnFooter.ResumeLayout(false);
            this.pnFooter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSubServContratados)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvServiciosContratados)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox imgReturn;
        private System.Windows.Forms.Label lblTituloHeader;
        private System.Windows.Forms.Panel panel2;
        private Controles.dgv dgvServiciosContratados;
        private Controles.dgv dgvSubServContratados;
        private System.Windows.Forms.Panel pnFooter;
        private System.Windows.Forms.Label lblTotal;
        private Controles.progress pgCircular;
        private System.Windows.Forms.Label lblServiciosContratados;
        private System.Windows.Forms.Label lblSubServiciosContratados;
        private Controles.boton btnAgregarSubServ;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Label lblLocacion;
    }
}