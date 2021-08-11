namespace CapaPresentacion
{
    partial class frmFacturaManual
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblUsuarioLoc = new System.Windows.Forms.Label();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.imgReturn = new System.Windows.Forms.PictureBox();
            this.lblTituloHeader = new System.Windows.Forms.Label();
            this.pnlControles = new System.Windows.Forms.Panel();
            this.cboSubservicios = new CapaPresentacion.Controles.combo(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.cboServUnicos = new CapaPresentacion.Controles.combo(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.btnGuardar = new CapaPresentacion.Controles.boton();
            this.btnAgregarAGrilla = new CapaPresentacion.Controles.boton();
            this.txtCantidad = new CapaPresentacion.textboxAdv();
            this.txtPrecioUnitario = new CapaPresentacion.textboxAdv();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.txtDescripcion = new CapaPresentacion.textboxAdv();
            this.pnFooter = new System.Windows.Forms.Panel();
            this.lblTotal = new System.Windows.Forms.Label();
            this.pgCircular = new CapaPresentacion.Controles.progress();
            this.dgv = new CapaPresentacion.Controles.dgv(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgReturn)).BeginInit();
            this.pnlControles.SuspendLayout();
            this.pnFooter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.panel1.Controls.Add(this.lblUsuarioLoc);
            this.panel1.Controls.Add(this.lblUsuario);
            this.panel1.Controls.Add(this.imgReturn);
            this.panel1.Controls.Add(this.lblTituloHeader);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1226, 87);
            this.panel1.TabIndex = 273;
            // 
            // lblUsuarioLoc
            // 
            this.lblUsuarioLoc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUsuarioLoc.AutoSize = true;
            this.lblUsuarioLoc.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblUsuarioLoc.ForeColor = System.Drawing.Color.White;
            this.lblUsuarioLoc.Location = new System.Drawing.Point(855, 33);
            this.lblUsuarioLoc.Name = "lblUsuarioLoc";
            this.lblUsuarioLoc.Size = new System.Drawing.Size(74, 21);
            this.lblUsuarioLoc.TabIndex = 318;
            this.lblUsuarioLoc.Text = "Locacion:";
            // 
            // lblUsuario
            // 
            this.lblUsuario.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblUsuario.ForeColor = System.Drawing.Color.White;
            this.lblUsuario.Location = new System.Drawing.Point(855, 9);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(67, 21);
            this.lblUsuario.TabIndex = 317;
            this.lblUsuario.Text = "Usuario:";
            // 
            // imgReturn
            // 
            this.imgReturn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.imgReturn.Image = global::CapaPresentacion.Properties.Resources.Left_Arrow_32;
            this.imgReturn.Location = new System.Drawing.Point(13, 27);
            this.imgReturn.Name = "imgReturn";
            this.imgReturn.Size = new System.Drawing.Size(32, 32);
            this.imgReturn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgReturn.TabIndex = 209;
            this.imgReturn.TabStop = false;
            this.imgReturn.Click += new System.EventHandler(this.imgReturn_Click);
            // 
            // lblTituloHeader
            // 
            this.lblTituloHeader.Font = new System.Drawing.Font("Segoe UI Light", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloHeader.ForeColor = System.Drawing.Color.White;
            this.lblTituloHeader.Location = new System.Drawing.Point(51, 30);
            this.lblTituloHeader.Name = "lblTituloHeader";
            this.lblTituloHeader.Size = new System.Drawing.Size(181, 27);
            this.lblTituloHeader.TabIndex = 208;
            this.lblTituloHeader.Text = "Factura manual";
            // 
            // pnlControles
            // 
            this.pnlControles.Controls.Add(this.cboSubservicios);
            this.pnlControles.Controls.Add(this.label4);
            this.pnlControles.Controls.Add(this.cboServUnicos);
            this.pnlControles.Controls.Add(this.label3);
            this.pnlControles.Controls.Add(this.btnGuardar);
            this.pnlControles.Controls.Add(this.btnAgregarAGrilla);
            this.pnlControles.Controls.Add(this.txtCantidad);
            this.pnlControles.Controls.Add(this.txtPrecioUnitario);
            this.pnlControles.Controls.Add(this.label2);
            this.pnlControles.Controls.Add(this.label1);
            this.pnlControles.Controls.Add(this.lblBuscar);
            this.pnlControles.Controls.Add(this.txtDescripcion);
            this.pnlControles.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlControles.Location = new System.Drawing.Point(0, 87);
            this.pnlControles.Name = "pnlControles";
            this.pnlControles.Size = new System.Drawing.Size(1226, 104);
            this.pnlControles.TabIndex = 274;
            // 
            // cboSubservicios
            // 
            this.cboSubservicios.BorderColor = System.Drawing.Color.LightGray;
            this.cboSubservicios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSubservicios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboSubservicios.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboSubservicios.FormattingEnabled = true;
            this.cboSubservicios.Location = new System.Drawing.Point(588, 16);
            this.cboSubservicios.Name = "cboSubservicios";
            this.cboSubservicios.Size = new System.Drawing.Size(300, 29);
            this.cboSubservicios.TabIndex = 325;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(489, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 21);
            this.label4.TabIndex = 324;
            this.label4.Text = "Subservicio:";
            // 
            // cboServUnicos
            // 
            this.cboServUnicos.BorderColor = System.Drawing.Color.LightGray;
            this.cboServUnicos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboServUnicos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboServUnicos.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboServUnicos.FormattingEnabled = true;
            this.cboServUnicos.Location = new System.Drawing.Point(128, 16);
            this.cboServUnicos.Name = "cboServUnicos";
            this.cboServUnicos.Size = new System.Drawing.Size(347, 29);
            this.cboServUnicos.TabIndex = 323;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(12, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 21);
            this.label3.TabIndex = 316;
            this.label3.Text = "Servicio unico:";
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
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI Light", 12F);
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Image = global::CapaPresentacion.Properties.Resources.Save_32;
            this.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGuardar.Location = new System.Drawing.Point(1113, 11);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(101, 37);
            this.btnGuardar.TabIndex = 315;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnAgregarAGrilla
            // 
            this.btnAgregarAGrilla.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAgregarAGrilla.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnAgregarAGrilla.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregarAGrilla.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnAgregarAGrilla.FlatAppearance.BorderSize = 0;
            this.btnAgregarAGrilla.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnAgregarAGrilla.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnAgregarAGrilla.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarAGrilla.Font = new System.Drawing.Font("Segoe UI Light", 12F);
            this.btnAgregarAGrilla.ForeColor = System.Drawing.Color.White;
            this.btnAgregarAGrilla.Image = global::CapaPresentacion.Properties.Resources.Data_Add_32;
            this.btnAgregarAGrilla.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAgregarAGrilla.Location = new System.Drawing.Point(1113, 54);
            this.btnAgregarAGrilla.Name = "btnAgregarAGrilla";
            this.btnAgregarAGrilla.Size = new System.Drawing.Size(101, 37);
            this.btnAgregarAGrilla.TabIndex = 314;
            this.btnAgregarAGrilla.Text = "Agregar ";
            this.btnAgregarAGrilla.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgregarAGrilla.UseVisualStyleBackColor = false;
            this.btnAgregarAGrilla.Click += new System.EventHandler(this.btnAgregarAGrilla_Click);
            // 
            // txtCantidad
            // 
            this.txtCantidad.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtCantidad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCantidad.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCantidad.FocusColor = System.Drawing.Color.Empty;
            this.txtCantidad.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtCantidad.ForeColor = System.Drawing.Color.Black;
            this.txtCantidad.Location = new System.Drawing.Point(787, 58);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Numerico = false;
            this.txtCantidad.Size = new System.Drawing.Size(101, 29);
            this.txtCantidad.TabIndex = 313;
            // 
            // txtPrecioUnitario
            // 
            this.txtPrecioUnitario.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtPrecioUnitario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPrecioUnitario.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPrecioUnitario.FocusColor = System.Drawing.Color.Empty;
            this.txtPrecioUnitario.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtPrecioUnitario.ForeColor = System.Drawing.Color.Black;
            this.txtPrecioUnitario.Location = new System.Drawing.Point(600, 58);
            this.txtPrecioUnitario.Name = "txtPrecioUnitario";
            this.txtPrecioUnitario.Numerico = false;
            this.txtPrecioUnitario.Size = new System.Drawing.Size(101, 29);
            this.txtPrecioUnitario.TabIndex = 312;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(709, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 21);
            this.label2.TabIndex = 311;
            this.label2.Text = "Cantidad:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(481, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 21);
            this.label1.TabIndex = 310;
            this.label1.Text = "Precio unitario: ";
            // 
            // lblBuscar
            // 
            this.lblBuscar.AutoSize = true;
            this.lblBuscar.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblBuscar.ForeColor = System.Drawing.Color.Black;
            this.lblBuscar.Location = new System.Drawing.Point(12, 62);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Size = new System.Drawing.Size(98, 21);
            this.lblBuscar.TabIndex = 309;
            this.lblBuscar.Text = "Descripción: ";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtDescripcion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescripcion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescripcion.FocusColor = System.Drawing.Color.Empty;
            this.txtDescripcion.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtDescripcion.ForeColor = System.Drawing.Color.Black;
            this.txtDescripcion.Location = new System.Drawing.Point(110, 58);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Numerico = false;
            this.txtDescripcion.Size = new System.Drawing.Size(365, 29);
            this.txtDescripcion.TabIndex = 1;
            // 
            // pnFooter
            // 
            this.pnFooter.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnFooter.Controls.Add(this.lblTotal);
            this.pnFooter.Controls.Add(this.pgCircular);
            this.pnFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnFooter.Location = new System.Drawing.Point(0, 420);
            this.pnFooter.Name = "pnFooter";
            this.pnFooter.Size = new System.Drawing.Size(1226, 30);
            this.pnFooter.TabIndex = 357;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblTotal.ForeColor = System.Drawing.Color.SlateGray;
            this.lblTotal.Location = new System.Drawing.Point(12, 5);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(148, 21);
            this.lblTotal.TabIndex = 13;
            this.lblTotal.Text = "Total de Registros: 0";
            // 
            // pgCircular
            // 
            this.pgCircular.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pgCircular.Location = new System.Drawing.Point(1186, 2);
            this.pgCircular.Name = "pgCircular";
            this.pgCircular.Percentage = 0F;
            this.pgCircular.Rotation = CapaPresentacion.Controles.RotationType.CounterClockwise;
            this.pgCircular.Size = new System.Drawing.Size(24, 24);
            this.pgCircular.TabIndex = 0;
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AllowUserToOrderColumns = true;
            this.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv.BackgroundColor = System.Drawing.Color.White;
            this.dgv.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgv.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSlateGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv.ColumnHeadersHeight = 40;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv.EnableHeadersVisualStyles = false;
            this.dgv.GridColor = System.Drawing.Color.WhiteSmoke;
            this.dgv.Location = new System.Drawing.Point(0, 191);
            this.dgv.MultiSelect = false;
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersVisible = false;
            this.dgv.RowHeadersWidth = 50;
            this.dgv.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(1226, 229);
            this.dgv.TabIndex = 376;
            this.dgv.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellContentClick);
            // 
            // frmFacturaManual
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1226, 450);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.pnFooter);
            this.Controls.Add(this.pnlControles);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "frmFacturaManual";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmFacturaManual";
            this.Load += new System.EventHandler(this.frmFacturaManual_Load);
            this.Shown += new System.EventHandler(this.frmFacturaManual_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmFacturaManual_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgReturn)).EndInit();
            this.pnlControles.ResumeLayout(false);
            this.pnlControles.PerformLayout();
            this.pnFooter.ResumeLayout(false);
            this.pnFooter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox imgReturn;
        private System.Windows.Forms.Label lblTituloHeader;
        private System.Windows.Forms.Panel pnlControles;
        private textboxAdv txtDescripcion;
        private System.Windows.Forms.Label lblBuscar;
        private textboxAdv txtPrecioUnitario;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private textboxAdv txtCantidad;
        private Controles.boton btnAgregarAGrilla;
        private System.Windows.Forms.Panel pnFooter;
        private System.Windows.Forms.Label lblTotal;
        private Controles.progress pgCircular;
        private Controles.dgv dgv;
        private Controles.boton btnGuardar;
        private System.Windows.Forms.Label label3;
        private Controles.combo cboServUnicos;
        private System.Windows.Forms.Label lblUsuarioLoc;
        private System.Windows.Forms.Label lblUsuario;
        private Controles.combo cboSubservicios;
        private System.Windows.Forms.Label label4;
    }
}