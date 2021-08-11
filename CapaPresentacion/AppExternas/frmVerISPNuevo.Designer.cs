
namespace CapaPresentacion.AppExternas
{
    partial class frmVerISPNuevo
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlSuperior = new System.Windows.Forms.Panel();
            this.imgReturn = new System.Windows.Forms.PictureBox();
            this.lblTituloHeader = new System.Windows.Forms.Label();
            this.tableGeneral = new System.Windows.Forms.TableLayoutPanel();
            this.gpEquiposGIES = new System.Windows.Forms.GroupBox();
            this.dgvEquiposGies = new CapaPresentacion.Controles.dgv(this.components);
            this.gpEquiposISP = new System.Windows.Forms.GroupBox();
            this.dgvEquiposISP = new CapaPresentacion.Controles.dgv(this.components);
            this.tableDatosISP = new System.Windows.Forms.TableLayoutPanel();
            this.gpServiciosISP = new System.Windows.Forms.GroupBox();
            this.btnEstablecerRelacion = new CapaPresentacion.Controles.boton();
            this.dgvServiciosISP = new CapaPresentacion.Controles.dgv(this.components);
            this.gpOperaciones = new System.Windows.Forms.GroupBox();
            this.btnReconectar = new CapaPresentacion.Controles.boton();
            this.btnCortar = new CapaPresentacion.Controles.boton();
            this.btnActualizar = new CapaPresentacion.Controles.boton();
            this.btnPing = new CapaPresentacion.Controles.boton();
            this.dgvOperaciones = new CapaPresentacion.Controles.dgv(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.lblServicio = new System.Windows.Forms.Label();
            this.pnlSuperior.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgReturn)).BeginInit();
            this.tableGeneral.SuspendLayout();
            this.gpEquiposGIES.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEquiposGies)).BeginInit();
            this.gpEquiposISP.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEquiposISP)).BeginInit();
            this.tableDatosISP.SuspendLayout();
            this.gpServiciosISP.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvServiciosISP)).BeginInit();
            this.gpOperaciones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOperaciones)).BeginInit();
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
            this.pnlSuperior.Size = new System.Drawing.Size(1212, 75);
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
            this.lblTituloHeader.Text = "ISP";
            // 
            // tableGeneral
            // 
            this.tableGeneral.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableGeneral.ColumnCount = 1;
            this.tableGeneral.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableGeneral.Controls.Add(this.gpEquiposGIES, 0, 0);
            this.tableGeneral.Controls.Add(this.gpEquiposISP, 0, 1);
            this.tableGeneral.Controls.Add(this.tableDatosISP, 0, 2);
            this.tableGeneral.Location = new System.Drawing.Point(12, 106);
            this.tableGeneral.Name = "tableGeneral";
            this.tableGeneral.RowCount = 3;
            this.tableGeneral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.tableGeneral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.tableGeneral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 34F));
            this.tableGeneral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableGeneral.Size = new System.Drawing.Size(1188, 555);
            this.tableGeneral.TabIndex = 54;
            // 
            // gpEquiposGIES
            // 
            this.gpEquiposGIES.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gpEquiposGIES.Controls.Add(this.dgvEquiposGies);
            this.gpEquiposGIES.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpEquiposGIES.Location = new System.Drawing.Point(3, 3);
            this.gpEquiposGIES.Name = "gpEquiposGIES";
            this.gpEquiposGIES.Size = new System.Drawing.Size(1182, 177);
            this.gpEquiposGIES.TabIndex = 0;
            this.gpEquiposGIES.TabStop = false;
            this.gpEquiposGIES.Text = "Equipos Asignados al Usuario en GIES";
            // 
            // dgvEquiposGies
            // 
            this.dgvEquiposGies.AllowUserToAddRows = false;
            this.dgvEquiposGies.AllowUserToDeleteRows = false;
            this.dgvEquiposGies.AllowUserToOrderColumns = true;
            this.dgvEquiposGies.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvEquiposGies.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvEquiposGies.BackgroundColor = System.Drawing.Color.White;
            this.dgvEquiposGies.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvEquiposGies.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSlateGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvEquiposGies.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvEquiposGies.ColumnHeadersHeight = 40;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvEquiposGies.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvEquiposGies.EnableHeadersVisualStyles = false;
            this.dgvEquiposGies.GridColor = System.Drawing.Color.WhiteSmoke;
            this.dgvEquiposGies.Location = new System.Drawing.Point(3, 28);
            this.dgvEquiposGies.MultiSelect = false;
            this.dgvEquiposGies.Name = "dgvEquiposGies";
            this.dgvEquiposGies.ReadOnly = true;
            this.dgvEquiposGies.RowHeadersVisible = false;
            this.dgvEquiposGies.RowHeadersWidth = 50;
            this.dgvEquiposGies.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvEquiposGies.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvEquiposGies.Size = new System.Drawing.Size(1173, 143);
            this.dgvEquiposGies.TabIndex = 337;
            // 
            // gpEquiposISP
            // 
            this.gpEquiposISP.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gpEquiposISP.Controls.Add(this.dgvEquiposISP);
            this.gpEquiposISP.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpEquiposISP.Location = new System.Drawing.Point(3, 186);
            this.gpEquiposISP.Name = "gpEquiposISP";
            this.gpEquiposISP.Size = new System.Drawing.Size(1182, 177);
            this.gpEquiposISP.TabIndex = 1;
            this.gpEquiposISP.TabStop = false;
            this.gpEquiposISP.Text = "Equipos Asignados al Usuario en Isp";
            // 
            // dgvEquiposISP
            // 
            this.dgvEquiposISP.AllowUserToAddRows = false;
            this.dgvEquiposISP.AllowUserToDeleteRows = false;
            this.dgvEquiposISP.AllowUserToOrderColumns = true;
            this.dgvEquiposISP.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvEquiposISP.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvEquiposISP.BackgroundColor = System.Drawing.Color.White;
            this.dgvEquiposISP.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvEquiposISP.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.LightSlateGray;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvEquiposISP.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvEquiposISP.ColumnHeadersHeight = 40;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvEquiposISP.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvEquiposISP.EnableHeadersVisualStyles = false;
            this.dgvEquiposISP.GridColor = System.Drawing.Color.WhiteSmoke;
            this.dgvEquiposISP.Location = new System.Drawing.Point(8, 28);
            this.dgvEquiposISP.MultiSelect = false;
            this.dgvEquiposISP.Name = "dgvEquiposISP";
            this.dgvEquiposISP.ReadOnly = true;
            this.dgvEquiposISP.RowHeadersVisible = false;
            this.dgvEquiposISP.RowHeadersWidth = 50;
            this.dgvEquiposISP.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvEquiposISP.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvEquiposISP.Size = new System.Drawing.Size(1168, 143);
            this.dgvEquiposISP.TabIndex = 338;
            // 
            // tableDatosISP
            // 
            this.tableDatosISP.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableDatosISP.ColumnCount = 2;
            this.tableDatosISP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableDatosISP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableDatosISP.Controls.Add(this.gpServiciosISP, 0, 0);
            this.tableDatosISP.Controls.Add(this.gpOperaciones, 1, 0);
            this.tableDatosISP.Location = new System.Drawing.Point(3, 369);
            this.tableDatosISP.Name = "tableDatosISP";
            this.tableDatosISP.RowCount = 1;
            this.tableDatosISP.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableDatosISP.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 183F));
            this.tableDatosISP.Size = new System.Drawing.Size(1182, 183);
            this.tableDatosISP.TabIndex = 2;
            // 
            // gpServiciosISP
            // 
            this.gpServiciosISP.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gpServiciosISP.Controls.Add(this.btnEstablecerRelacion);
            this.gpServiciosISP.Controls.Add(this.dgvServiciosISP);
            this.gpServiciosISP.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpServiciosISP.Location = new System.Drawing.Point(3, 3);
            this.gpServiciosISP.Name = "gpServiciosISP";
            this.gpServiciosISP.Size = new System.Drawing.Size(348, 177);
            this.gpServiciosISP.TabIndex = 0;
            this.gpServiciosISP.TabStop = false;
            this.gpServiciosISP.Text = "Servicios asociados en ISP";
            // 
            // btnEstablecerRelacion
            // 
            this.btnEstablecerRelacion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEstablecerRelacion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnEstablecerRelacion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEstablecerRelacion.Enabled = false;
            this.btnEstablecerRelacion.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnEstablecerRelacion.FlatAppearance.BorderSize = 0;
            this.btnEstablecerRelacion.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnEstablecerRelacion.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnEstablecerRelacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEstablecerRelacion.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnEstablecerRelacion.ForeColor = System.Drawing.Color.White;
            this.btnEstablecerRelacion.Image = global::CapaPresentacion.Properties.Resources.Data_Add_32;
            this.btnEstablecerRelacion.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEstablecerRelacion.Location = new System.Drawing.Point(169, 28);
            this.btnEstablecerRelacion.Name = "btnEstablecerRelacion";
            this.btnEstablecerRelacion.Size = new System.Drawing.Size(173, 35);
            this.btnEstablecerRelacion.TabIndex = 335;
            this.btnEstablecerRelacion.Text = "Asignar Productos";
            this.btnEstablecerRelacion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEstablecerRelacion.UseVisualStyleBackColor = false;
            // 
            // dgvServiciosISP
            // 
            this.dgvServiciosISP.AllowUserToAddRows = false;
            this.dgvServiciosISP.AllowUserToDeleteRows = false;
            this.dgvServiciosISP.AllowUserToOrderColumns = true;
            this.dgvServiciosISP.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvServiciosISP.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvServiciosISP.BackgroundColor = System.Drawing.Color.White;
            this.dgvServiciosISP.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvServiciosISP.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.LightSlateGray;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvServiciosISP.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvServiciosISP.ColumnHeadersHeight = 40;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvServiciosISP.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvServiciosISP.EnableHeadersVisualStyles = false;
            this.dgvServiciosISP.GridColor = System.Drawing.Color.WhiteSmoke;
            this.dgvServiciosISP.Location = new System.Drawing.Point(6, 69);
            this.dgvServiciosISP.MultiSelect = false;
            this.dgvServiciosISP.Name = "dgvServiciosISP";
            this.dgvServiciosISP.ReadOnly = true;
            this.dgvServiciosISP.RowHeadersVisible = false;
            this.dgvServiciosISP.RowHeadersWidth = 50;
            this.dgvServiciosISP.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvServiciosISP.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvServiciosISP.Size = new System.Drawing.Size(336, 101);
            this.dgvServiciosISP.TabIndex = 339;
            // 
            // gpOperaciones
            // 
            this.gpOperaciones.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gpOperaciones.Controls.Add(this.btnReconectar);
            this.gpOperaciones.Controls.Add(this.btnCortar);
            this.gpOperaciones.Controls.Add(this.btnActualizar);
            this.gpOperaciones.Controls.Add(this.btnPing);
            this.gpOperaciones.Controls.Add(this.dgvOperaciones);
            this.gpOperaciones.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpOperaciones.Location = new System.Drawing.Point(357, 3);
            this.gpOperaciones.Name = "gpOperaciones";
            this.gpOperaciones.Size = new System.Drawing.Size(822, 177);
            this.gpOperaciones.TabIndex = 1;
            this.gpOperaciones.TabStop = false;
            this.gpOperaciones.Text = "Operaciones y Datos de la Conexion";
            // 
            // btnReconectar
            // 
            this.btnReconectar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReconectar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnReconectar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReconectar.Enabled = false;
            this.btnReconectar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnReconectar.FlatAppearance.BorderSize = 0;
            this.btnReconectar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnReconectar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnReconectar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReconectar.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnReconectar.ForeColor = System.Drawing.Color.White;
            this.btnReconectar.Image = global::CapaPresentacion.Properties.Resources.Arrowhead_up_32;
            this.btnReconectar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnReconectar.Location = new System.Drawing.Point(364, 135);
            this.btnReconectar.Name = "btnReconectar";
            this.btnReconectar.Size = new System.Drawing.Size(120, 35);
            this.btnReconectar.TabIndex = 343;
            this.btnReconectar.Text = "Reconectar";
            this.btnReconectar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReconectar.UseVisualStyleBackColor = false;
            // 
            // btnCortar
            // 
            this.btnCortar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCortar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnCortar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCortar.Enabled = false;
            this.btnCortar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnCortar.FlatAppearance.BorderSize = 0;
            this.btnCortar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnCortar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnCortar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCortar.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnCortar.ForeColor = System.Drawing.Color.White;
            this.btnCortar.Image = global::CapaPresentacion.Properties.Resources.Arrowhead_down_32;
            this.btnCortar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCortar.Location = new System.Drawing.Point(238, 135);
            this.btnCortar.Name = "btnCortar";
            this.btnCortar.Size = new System.Drawing.Size(120, 35);
            this.btnCortar.TabIndex = 342;
            this.btnCortar.Text = "Cortar";
            this.btnCortar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCortar.UseVisualStyleBackColor = false;
            // 
            // btnActualizar
            // 
            this.btnActualizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnActualizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnActualizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnActualizar.Enabled = false;
            this.btnActualizar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnActualizar.FlatAppearance.BorderSize = 0;
            this.btnActualizar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnActualizar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnActualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActualizar.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnActualizar.ForeColor = System.Drawing.Color.White;
            this.btnActualizar.Image = global::CapaPresentacion.Properties.Resources.Command_Refresh_32;
            this.btnActualizar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnActualizar.Location = new System.Drawing.Point(112, 135);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(120, 35);
            this.btnActualizar.TabIndex = 341;
            this.btnActualizar.Text = "Refrescar";
            this.btnActualizar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnActualizar.UseVisualStyleBackColor = false;
            // 
            // btnPing
            // 
            this.btnPing.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPing.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnPing.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPing.Enabled = false;
            this.btnPing.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnPing.FlatAppearance.BorderSize = 0;
            this.btnPing.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnPing.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnPing.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPing.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnPing.ForeColor = System.Drawing.Color.White;
            this.btnPing.Image = global::CapaPresentacion.Properties.Resources.Command_Redo_32;
            this.btnPing.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPing.Location = new System.Drawing.Point(6, 135);
            this.btnPing.Name = "btnPing";
            this.btnPing.Size = new System.Drawing.Size(100, 35);
            this.btnPing.TabIndex = 340;
            this.btnPing.Text = "Ping";
            this.btnPing.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPing.UseVisualStyleBackColor = false;
            // 
            // dgvOperaciones
            // 
            this.dgvOperaciones.AllowUserToAddRows = false;
            this.dgvOperaciones.AllowUserToDeleteRows = false;
            this.dgvOperaciones.AllowUserToOrderColumns = true;
            this.dgvOperaciones.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvOperaciones.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvOperaciones.BackgroundColor = System.Drawing.Color.White;
            this.dgvOperaciones.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvOperaciones.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.LightSlateGray;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvOperaciones.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvOperaciones.ColumnHeadersHeight = 40;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvOperaciones.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgvOperaciones.EnableHeadersVisualStyles = false;
            this.dgvOperaciones.GridColor = System.Drawing.Color.WhiteSmoke;
            this.dgvOperaciones.Location = new System.Drawing.Point(6, 29);
            this.dgvOperaciones.MultiSelect = false;
            this.dgvOperaciones.Name = "dgvOperaciones";
            this.dgvOperaciones.ReadOnly = true;
            this.dgvOperaciones.RowHeadersVisible = false;
            this.dgvOperaciones.RowHeadersWidth = 50;
            this.dgvOperaciones.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvOperaciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvOperaciones.Size = new System.Drawing.Size(810, 100);
            this.dgvOperaciones.TabIndex = 339;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 25);
            this.label1.TabIndex = 55;
            this.label1.Text = "Servicio:";
            // 
            // lblServicio
            // 
            this.lblServicio.AutoSize = true;
            this.lblServicio.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblServicio.Location = new System.Drawing.Point(103, 78);
            this.lblServicio.Name = "lblServicio";
            this.lblServicio.Size = new System.Drawing.Size(177, 25);
            this.lblServicio.TabIndex = 56;
            this.lblServicio.Text = "ServicioContratado";
            // 
            // frmVerISPNuevo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1212, 673);
            this.Controls.Add(this.lblServicio);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tableGeneral);
            this.Controls.Add(this.pnlSuperior);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmVerISPNuevo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmVerISPNuevo";
            this.Load += new System.EventHandler(this.frmVerISPNuevo_Load);
            this.pnlSuperior.ResumeLayout(false);
            this.pnlSuperior.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgReturn)).EndInit();
            this.tableGeneral.ResumeLayout(false);
            this.gpEquiposGIES.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEquiposGies)).EndInit();
            this.gpEquiposISP.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEquiposISP)).EndInit();
            this.tableDatosISP.ResumeLayout(false);
            this.gpServiciosISP.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvServiciosISP)).EndInit();
            this.gpOperaciones.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOperaciones)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlSuperior;
        private System.Windows.Forms.PictureBox imgReturn;
        private System.Windows.Forms.Label lblTituloHeader;
        private System.Windows.Forms.TableLayoutPanel tableGeneral;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblServicio;
        private System.Windows.Forms.GroupBox gpEquiposGIES;
        private System.Windows.Forms.GroupBox gpEquiposISP;
        private System.Windows.Forms.TableLayoutPanel tableDatosISP;
        private System.Windows.Forms.GroupBox gpServiciosISP;
        private System.Windows.Forms.GroupBox gpOperaciones;
        private Controles.dgv dgvEquiposGies;
        private Controles.dgv dgvEquiposISP;
        private Controles.dgv dgvServiciosISP;
        private Controles.dgv dgvOperaciones;
        private Controles.boton btnEstablecerRelacion;
        private Controles.boton btnActualizar;
        private Controles.boton btnPing;
        private Controles.boton btnReconectar;
        private Controles.boton btnCortar;
    }
}