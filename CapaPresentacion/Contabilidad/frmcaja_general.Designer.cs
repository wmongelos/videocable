namespace CapaPresentacion
{
    partial class frmCaja_General
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.imgReturn = new System.Windows.Forms.PictureBox();
            this.lbTitulo = new System.Windows.Forms.Label();
            this.dgv1 = new CapaPresentacion.Controles.dgv(this.components);
            this.txtsuma1 = new CapaPresentacion.textboxAdv();
            this.txtsuma2 = new CapaPresentacion.textboxAdv();
            this.txtcierretotal = new CapaPresentacion.textboxAdv();
            this.txttotal1 = new CapaPresentacion.textboxAdv();
            this.txttotal2 = new CapaPresentacion.textboxAdv();
            this.txttotal = new CapaPresentacion.textboxAdv();
            this.txtprimerrecibo2 = new CapaPresentacion.textboxAdv();
            this.txtprimerrecibo1 = new CapaPresentacion.textboxAdv();
            this.dgvCajas_diarias = new CapaPresentacion.Controles.dgv(this.components);
            this.btnVer = new CapaPresentacion.Controles.boton();
            this.txtultimorecibo2 = new CapaPresentacion.textboxAdv();
            this.txtultimorecibo1 = new CapaPresentacion.textboxAdv();
            this.btnSeleccionarTodo = new CapaPresentacion.Controles.boton();
            this.btnConsultaDeCaja = new CapaPresentacion.Controles.boton();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgReturn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCajas_diarias)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(225, 523);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 21);
            this.label1.TabIndex = 86;
            this.label1.Text = "Recibo desde";
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(333, 523);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(98, 21);
            this.label12.TabIndex = 84;
            this.label12.Text = "Recibo hasta";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(519, 529);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(13, 13);
            this.label2.TabIndex = 94;
            this.label2.Text = "$";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(373, 607);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 21);
            this.label3.TabIndex = 95;
            this.label3.Text = "TOTAL :";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(899, 569);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(128, 21);
            this.label4.TabIndex = 97;
            this.label4.Text = "IMPORTE TOTAL :";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(942, 493);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 21);
            this.label5.TabIndex = 101;
            this.label5.Text = "CUENTA 1:";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(943, 524);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 21);
            this.label6.TabIndex = 102;
            this.label6.Text = "CUENTA 2:";
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.panel4.Controls.Add(this.imgReturn);
            this.panel4.Controls.Add(this.lbTitulo);
            this.panel4.Location = new System.Drawing.Point(12, 8);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1386, 89);
            this.panel4.TabIndex = 110;
            // 
            // imgReturn
            // 
            this.imgReturn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.imgReturn.Image = global::CapaPresentacion.Properties.Resources.Left_Arrow_32;
            this.imgReturn.Location = new System.Drawing.Point(14, 28);
            this.imgReturn.Name = "imgReturn";
            this.imgReturn.Size = new System.Drawing.Size(32, 32);
            this.imgReturn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgReturn.TabIndex = 101;
            this.imgReturn.TabStop = false;
            this.imgReturn.Click += new System.EventHandler(this.imgReturn_Click);
            // 
            // lbTitulo
            // 
            this.lbTitulo.AutoSize = true;
            this.lbTitulo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitulo.ForeColor = System.Drawing.Color.White;
            this.lbTitulo.Location = new System.Drawing.Point(52, 32);
            this.lbTitulo.Name = "lbTitulo";
            this.lbTitulo.Size = new System.Drawing.Size(118, 21);
            this.lbTitulo.TabIndex = 99;
            this.lbTitulo.Text = "CAJA GENERAL";
            // 
            // dgv1
            // 
            this.dgv1.AllowUserToAddRows = false;
            this.dgv1.AllowUserToDeleteRows = false;
            this.dgv1.AllowUserToOrderColumns = true;
            this.dgv1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv1.BackgroundColor = System.Drawing.Color.White;
            this.dgv1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.LightSlateGray;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgv1.ColumnHeadersHeight = 40;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv1.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgv1.EnableHeadersVisualStyles = false;
            this.dgv1.GridColor = System.Drawing.Color.WhiteSmoke;
            this.dgv1.Location = new System.Drawing.Point(669, 143);
            this.dgv1.MultiSelect = false;
            this.dgv1.Name = "dgv1";
            this.dgv1.ReadOnly = true;
            this.dgv1.RowHeadersVisible = false;
            this.dgv1.RowHeadersWidth = 50;
            this.dgv1.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgv1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv1.Size = new System.Drawing.Size(555, 330);
            this.dgv1.TabIndex = 111;
            this.dgv1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv1_CellClick);
            this.dgv1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv1_CellValueChanged);
            this.dgv1.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgv1_DataBindingComplete);
            // 
            // txtsuma1
            // 
            this.txtsuma1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtsuma1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtsuma1.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtsuma1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtsuma1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtsuma1.FocusColor = System.Drawing.Color.Empty;
            this.txtsuma1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtsuma1.ForeColor = System.Drawing.Color.Black;
            this.txtsuma1.Location = new System.Drawing.Point(1031, 488);
            this.txtsuma1.Name = "txtsuma1";
            this.txtsuma1.Numerico = true;
            this.txtsuma1.ReadOnly = true;
            this.txtsuma1.Size = new System.Drawing.Size(193, 29);
            this.txtsuma1.TabIndex = 100;
            this.txtsuma1.Tag = "\"\"";
            this.txtsuma1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtsuma2
            // 
            this.txtsuma2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtsuma2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtsuma2.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtsuma2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtsuma2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtsuma2.FocusColor = System.Drawing.Color.Empty;
            this.txtsuma2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtsuma2.ForeColor = System.Drawing.Color.Black;
            this.txtsuma2.Location = new System.Drawing.Point(1031, 520);
            this.txtsuma2.Name = "txtsuma2";
            this.txtsuma2.Numerico = true;
            this.txtsuma2.ReadOnly = true;
            this.txtsuma2.Size = new System.Drawing.Size(193, 29);
            this.txtsuma2.TabIndex = 99;
            this.txtsuma2.Tag = "\"\"";
            this.txtsuma2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtcierretotal
            // 
            this.txtcierretotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtcierretotal.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtcierretotal.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtcierretotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtcierretotal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtcierretotal.FocusColor = System.Drawing.Color.Empty;
            this.txtcierretotal.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtcierretotal.ForeColor = System.Drawing.Color.Black;
            this.txtcierretotal.Location = new System.Drawing.Point(1031, 565);
            this.txtcierretotal.Name = "txtcierretotal";
            this.txtcierretotal.Numerico = true;
            this.txtcierretotal.ReadOnly = true;
            this.txtcierretotal.Size = new System.Drawing.Size(193, 29);
            this.txtcierretotal.TabIndex = 96;
            this.txtcierretotal.Tag = "\"\"";
            this.txtcierretotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txttotal1
            // 
            this.txttotal1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txttotal1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txttotal1.BorderColor = System.Drawing.Color.Gainsboro;
            this.txttotal1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txttotal1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txttotal1.FocusColor = System.Drawing.Color.Empty;
            this.txttotal1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txttotal1.ForeColor = System.Drawing.Color.DimGray;
            this.txttotal1.Location = new System.Drawing.Point(439, 547);
            this.txttotal1.Name = "txttotal1";
            this.txttotal1.Numerico = true;
            this.txttotal1.ReadOnly = true;
            this.txttotal1.Size = new System.Drawing.Size(93, 22);
            this.txttotal1.TabIndex = 93;
            this.txttotal1.Tag = "\"\"";
            this.txttotal1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txttotal2
            // 
            this.txttotal2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txttotal2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txttotal2.BorderColor = System.Drawing.Color.Gainsboro;
            this.txttotal2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txttotal2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txttotal2.FocusColor = System.Drawing.Color.Empty;
            this.txttotal2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txttotal2.ForeColor = System.Drawing.Color.DimGray;
            this.txttotal2.Location = new System.Drawing.Point(439, 575);
            this.txttotal2.Name = "txttotal2";
            this.txttotal2.Numerico = true;
            this.txttotal2.ReadOnly = true;
            this.txttotal2.Size = new System.Drawing.Size(93, 22);
            this.txttotal2.TabIndex = 92;
            this.txttotal2.Tag = "\"\"";
            this.txttotal2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txttotal
            // 
            this.txttotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txttotal.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txttotal.BorderColor = System.Drawing.Color.Gainsboro;
            this.txttotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txttotal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txttotal.FocusColor = System.Drawing.Color.Empty;
            this.txttotal.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txttotal.ForeColor = System.Drawing.Color.DimGray;
            this.txttotal.Location = new System.Drawing.Point(439, 606);
            this.txttotal.Name = "txttotal";
            this.txttotal.Numerico = true;
            this.txttotal.ReadOnly = true;
            this.txttotal.Size = new System.Drawing.Size(93, 22);
            this.txttotal.TabIndex = 91;
            this.txttotal.Tag = "\"\"";
            this.txttotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtprimerrecibo2
            // 
            this.txtprimerrecibo2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtprimerrecibo2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtprimerrecibo2.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtprimerrecibo2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtprimerrecibo2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtprimerrecibo2.FocusColor = System.Drawing.Color.Empty;
            this.txtprimerrecibo2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtprimerrecibo2.ForeColor = System.Drawing.Color.DimGray;
            this.txtprimerrecibo2.Location = new System.Drawing.Point(229, 575);
            this.txtprimerrecibo2.Name = "txtprimerrecibo2";
            this.txtprimerrecibo2.Numerico = true;
            this.txtprimerrecibo2.ReadOnly = true;
            this.txtprimerrecibo2.Size = new System.Drawing.Size(93, 22);
            this.txtprimerrecibo2.TabIndex = 90;
            this.txtprimerrecibo2.Tag = "\"\"";
            this.txtprimerrecibo2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtprimerrecibo1
            // 
            this.txtprimerrecibo1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtprimerrecibo1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtprimerrecibo1.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtprimerrecibo1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtprimerrecibo1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtprimerrecibo1.FocusColor = System.Drawing.Color.Empty;
            this.txtprimerrecibo1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtprimerrecibo1.ForeColor = System.Drawing.Color.DimGray;
            this.txtprimerrecibo1.Location = new System.Drawing.Point(229, 547);
            this.txtprimerrecibo1.Name = "txtprimerrecibo1";
            this.txtprimerrecibo1.Numerico = true;
            this.txtprimerrecibo1.ReadOnly = true;
            this.txtprimerrecibo1.Size = new System.Drawing.Size(93, 22);
            this.txtprimerrecibo1.TabIndex = 89;
            this.txtprimerrecibo1.Tag = "\"\"";
            this.txtprimerrecibo1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // dgvCajas_diarias
            // 
            this.dgvCajas_diarias.AllowUserToAddRows = false;
            this.dgvCajas_diarias.AllowUserToDeleteRows = false;
            this.dgvCajas_diarias.AllowUserToOrderColumns = true;
            this.dgvCajas_diarias.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgvCajas_diarias.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCajas_diarias.BackgroundColor = System.Drawing.Color.White;
            this.dgvCajas_diarias.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvCajas_diarias.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.LightSlateGray;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCajas_diarias.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvCajas_diarias.ColumnHeadersHeight = 40;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCajas_diarias.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgvCajas_diarias.EnableHeadersVisualStyles = false;
            this.dgvCajas_diarias.GridColor = System.Drawing.Color.WhiteSmoke;
            this.dgvCajas_diarias.Location = new System.Drawing.Point(14, 143);
            this.dgvCajas_diarias.MultiSelect = false;
            this.dgvCajas_diarias.Name = "dgvCajas_diarias";
            this.dgvCajas_diarias.ReadOnly = true;
            this.dgvCajas_diarias.RowHeadersVisible = false;
            this.dgvCajas_diarias.RowHeadersWidth = 50;
            this.dgvCajas_diarias.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvCajas_diarias.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCajas_diarias.Size = new System.Drawing.Size(518, 330);
            this.dgvCajas_diarias.TabIndex = 88;
            this.dgvCajas_diarias.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCajas_diarias_CellClick);
            this.dgvCajas_diarias.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCajas_diarias_CellContentClick);
            this.dgvCajas_diarias.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCajas_diarias_CellEndEdit);
            this.dgvCajas_diarias.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCajas_diarias_CellEnter);
            this.dgvCajas_diarias.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvCajas_diarias_CellMouseClick);
            this.dgvCajas_diarias.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCajas_diarias_CellValueChanged);
            this.dgvCajas_diarias.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvCajas_diarias_CurrentCellDirtyStateChanged);
            // 
            // btnVer
            // 
            this.btnVer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnVer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnVer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVer.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnVer.FlatAppearance.BorderSize = 0;
            this.btnVer.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnVer.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnVer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVer.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVer.ForeColor = System.Drawing.Color.White;
            this.btnVer.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnVer.Location = new System.Drawing.Point(1028, 597);
            this.btnVer.Name = "btnVer";
            this.btnVer.Size = new System.Drawing.Size(196, 34);
            this.btnVer.TabIndex = 87;
            this.btnVer.Text = "Confirma Cierre";
            this.btnVer.UseVisualStyleBackColor = false;
            this.btnVer.Click += new System.EventHandler(this.btnVer_Click);
            // 
            // txtultimorecibo2
            // 
            this.txtultimorecibo2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtultimorecibo2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtultimorecibo2.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtultimorecibo2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtultimorecibo2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtultimorecibo2.FocusColor = System.Drawing.Color.Empty;
            this.txtultimorecibo2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtultimorecibo2.ForeColor = System.Drawing.Color.DimGray;
            this.txtultimorecibo2.Location = new System.Drawing.Point(334, 575);
            this.txtultimorecibo2.Name = "txtultimorecibo2";
            this.txtultimorecibo2.Numerico = true;
            this.txtultimorecibo2.ReadOnly = true;
            this.txtultimorecibo2.Size = new System.Drawing.Size(93, 22);
            this.txtultimorecibo2.TabIndex = 85;
            this.txtultimorecibo2.Tag = "\"\"";
            this.txtultimorecibo2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtultimorecibo1
            // 
            this.txtultimorecibo1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtultimorecibo1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtultimorecibo1.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtultimorecibo1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtultimorecibo1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtultimorecibo1.FocusColor = System.Drawing.Color.Empty;
            this.txtultimorecibo1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtultimorecibo1.ForeColor = System.Drawing.Color.DimGray;
            this.txtultimorecibo1.Location = new System.Drawing.Point(334, 547);
            this.txtultimorecibo1.Name = "txtultimorecibo1";
            this.txtultimorecibo1.Numerico = true;
            this.txtultimorecibo1.ReadOnly = true;
            this.txtultimorecibo1.Size = new System.Drawing.Size(93, 22);
            this.txtultimorecibo1.TabIndex = 83;
            this.txtultimorecibo1.Tag = "\"\"";
            this.txtultimorecibo1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnSeleccionarTodo
            // 
            this.btnSeleccionarTodo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnSeleccionarTodo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSeleccionarTodo.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnSeleccionarTodo.FlatAppearance.BorderSize = 0;
            this.btnSeleccionarTodo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnSeleccionarTodo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnSeleccionarTodo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSeleccionarTodo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSeleccionarTodo.ForeColor = System.Drawing.Color.White;
            this.btnSeleccionarTodo.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSeleccionarTodo.Location = new System.Drawing.Point(214, 103);
            this.btnSeleccionarTodo.Name = "btnSeleccionarTodo";
            this.btnSeleccionarTodo.Size = new System.Drawing.Size(156, 34);
            this.btnSeleccionarTodo.TabIndex = 112;
            this.btnSeleccionarTodo.Text = "Seleccionar todas";
            this.btnSeleccionarTodo.UseVisualStyleBackColor = false;
            this.btnSeleccionarTodo.Click += new System.EventHandler(this.btnSeleccionarTodo_Click);
            // 
            // btnConsultaDeCaja
            // 
            this.btnConsultaDeCaja.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnConsultaDeCaja.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConsultaDeCaja.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnConsultaDeCaja.FlatAppearance.BorderSize = 0;
            this.btnConsultaDeCaja.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnConsultaDeCaja.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnConsultaDeCaja.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConsultaDeCaja.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConsultaDeCaja.ForeColor = System.Drawing.Color.White;
            this.btnConsultaDeCaja.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnConsultaDeCaja.Location = new System.Drawing.Point(376, 103);
            this.btnConsultaDeCaja.Name = "btnConsultaDeCaja";
            this.btnConsultaDeCaja.Size = new System.Drawing.Size(156, 34);
            this.btnConsultaDeCaja.TabIndex = 113;
            this.btnConsultaDeCaja.Text = "Consulta";
            this.btnConsultaDeCaja.UseVisualStyleBackColor = false;
            this.btnConsultaDeCaja.Click += new System.EventHandler(this.btnConsultaDeCaja_Click);
            // 
            // frmCaja_General
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1236, 643);
            this.Controls.Add(this.btnConsultaDeCaja);
            this.Controls.Add(this.btnSeleccionarTodo);
            this.Controls.Add(this.dgv1);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtsuma1);
            this.Controls.Add(this.txtsuma2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtcierretotal);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txttotal1);
            this.Controls.Add(this.txttotal2);
            this.Controls.Add(this.txttotal);
            this.Controls.Add(this.txtprimerrecibo2);
            this.Controls.Add(this.txtprimerrecibo1);
            this.Controls.Add(this.dgvCajas_diarias);
            this.Controls.Add(this.btnVer);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtultimorecibo2);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtultimorecibo1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "frmCaja_General";
            this.Text = "frmcajageneral";
            this.Load += new System.EventHandler(this.frmcaja_general_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmCaja_General_KeyDown);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgReturn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCajas_diarias)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controles.boton btnVer;
        private System.Windows.Forms.Label label1;
        private textboxAdv txtultimorecibo2;
        private System.Windows.Forms.Label label12;
        private textboxAdv txtultimorecibo1;
        private Controles.dgv dgvCajas_diarias;
        private textboxAdv txtprimerrecibo2;
        private textboxAdv txtprimerrecibo1;
        private textboxAdv txttotal;
        private textboxAdv txttotal2;
        private textboxAdv txttotal1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private textboxAdv txtcierretotal;
        private System.Windows.Forms.Label label4;
        private textboxAdv txtsuma2;
        private textboxAdv txtsuma1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.PictureBox imgReturn;
        private System.Windows.Forms.Label lbTitulo;
        private Controles.dgv dgv1;
        private Controles.boton btnSeleccionarTodo;
        private Controles.boton btnConsultaDeCaja;
    }
}