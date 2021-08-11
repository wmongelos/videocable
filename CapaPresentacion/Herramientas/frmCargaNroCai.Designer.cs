
namespace CapaPresentacion.Herramientas
{
    partial class frmCargaNroCai
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnTitle = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.imgReturn = new System.Windows.Forms.PictureBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.DtpVencimiento = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnBuscar = new CapaPresentacion.Controles.boton();
            this.DataGrid = new CapaPresentacion.Controles.dgv(this.components);
            this.TxtNroHasta = new CapaPresentacion.textboxAdv();
            this.TxtNroDesde = new CapaPresentacion.textboxAdv();
            this.txtNroCai = new CapaPresentacion.textboxAdv();
            this.CboTipoComprobante = new CapaPresentacion.Controles.combo(this.components);
            this.cboPuntosVenta = new CapaPresentacion.Controles.combo(this.components);
            this.btnCancelar = new CapaPresentacion.Controles.boton();
            this.btnConfirmar = new CapaPresentacion.Controles.boton();
            this.pnTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgReturn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // pnTitle
            // 
            this.pnTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.pnTitle.Controls.Add(this.label1);
            this.pnTitle.Controls.Add(this.imgReturn);
            this.pnTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnTitle.Location = new System.Drawing.Point(0, 0);
            this.pnTitle.Name = "pnTitle";
            this.pnTitle.Size = new System.Drawing.Size(1207, 80);
            this.pnTitle.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(58, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 25);
            this.label1.TabIndex = 124;
            this.label1.Text = "Numeración CAI";
            // 
            // imgReturn
            // 
            this.imgReturn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.imgReturn.Image = global::CapaPresentacion.Properties.Resources.Left_Arrow_32;
            this.imgReturn.Location = new System.Drawing.Point(12, 23);
            this.imgReturn.Name = "imgReturn";
            this.imgReturn.Size = new System.Drawing.Size(32, 32);
            this.imgReturn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgReturn.TabIndex = 33;
            this.imgReturn.TabStop = false;
            this.imgReturn.Click += new System.EventHandler(this.imgReturn_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.label11.Location = new System.Drawing.Point(12, 102);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(149, 25);
            this.label11.TabIndex = 121;
            this.label11.Text = "Puntos de Venta";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.label4.Location = new System.Drawing.Point(13, 163);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(196, 25);
            this.label4.TabIndex = 127;
            this.label4.Text = "Tipo de Comprobante";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.label5.Location = new System.Drawing.Point(688, 91);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 25);
            this.label5.TabIndex = 129;
            this.label5.Text = "Nro de CAI";
            // 
            // DtpVencimiento
            // 
            this.DtpVencimiento.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DtpVencimiento.Location = new System.Drawing.Point(693, 190);
            this.DtpVencimiento.Name = "DtpVencimiento";
            this.DtpVencimiento.Size = new System.Drawing.Size(365, 33);
            this.DtpVencimiento.TabIndex = 131;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.label6.Location = new System.Drawing.Point(689, 160);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(197, 25);
            this.label6.TabIndex = 130;
            this.label6.Text = "Fecha de Vencimiento";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.label7.Location = new System.Drawing.Point(318, 103);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(105, 25);
            this.label7.TabIndex = 133;
            this.label7.Text = "Nro. Desde";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.label8.Location = new System.Drawing.Point(318, 164);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(100, 25);
            this.label8.TabIndex = 135;
            this.label8.Text = "Nro. Hasta";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnBuscar.FlatAppearance.BorderSize = 0;
            this.btnBuscar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnBuscar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnBuscar.ForeColor = System.Drawing.Color.White;
            this.btnBuscar.Image = global::CapaPresentacion.Properties.Resources.lupa;
            this.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBuscar.Location = new System.Drawing.Point(504, 119);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(111, 46);
            this.btnBuscar.TabIndex = 358;
            this.btnBuscar.Text = "Consultar";
            this.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // DataGrid
            // 
            this.DataGrid.AllowUserToAddRows = false;
            this.DataGrid.AllowUserToDeleteRows = false;
            this.DataGrid.AllowUserToOrderColumns = true;
            this.DataGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DataGrid.BackgroundColor = System.Drawing.Color.White;
            this.DataGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DataGrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.LightSlateGray;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 12F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.DataGrid.ColumnHeadersHeight = 40;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 12F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DataGrid.DefaultCellStyle = dataGridViewCellStyle5;
            this.DataGrid.EnableHeadersVisualStyles = false;
            this.DataGrid.GridColor = System.Drawing.Color.WhiteSmoke;
            this.DataGrid.Location = new System.Drawing.Point(17, 247);
            this.DataGrid.MultiSelect = false;
            this.DataGrid.Name = "DataGrid";
            this.DataGrid.ReadOnly = true;
            this.DataGrid.RowHeadersVisible = false;
            this.DataGrid.RowHeadersWidth = 50;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGrid.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.DataGrid.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.DataGrid.Size = new System.Drawing.Size(1178, 328);
            this.DataGrid.TabIndex = 343;
            // 
            // TxtNroHasta
            // 
            this.TxtNroHasta.BorderColor = System.Drawing.Color.Gainsboro;
            this.TxtNroHasta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtNroHasta.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtNroHasta.FocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            this.TxtNroHasta.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.TxtNroHasta.ForeColor = System.Drawing.Color.DimGray;
            this.TxtNroHasta.Location = new System.Drawing.Point(314, 190);
            this.TxtNroHasta.Name = "TxtNroHasta";
            this.TxtNroHasta.Numerico = true;
            this.TxtNroHasta.Size = new System.Drawing.Size(172, 31);
            this.TxtNroHasta.TabIndex = 134;
            this.TxtNroHasta.Text = "1";
            this.TxtNroHasta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // TxtNroDesde
            // 
            this.TxtNroDesde.BorderColor = System.Drawing.Color.Gainsboro;
            this.TxtNroDesde.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtNroDesde.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtNroDesde.FocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            this.TxtNroDesde.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.TxtNroDesde.ForeColor = System.Drawing.Color.DimGray;
            this.TxtNroDesde.Location = new System.Drawing.Point(314, 129);
            this.TxtNroDesde.Name = "TxtNroDesde";
            this.TxtNroDesde.Numerico = true;
            this.TxtNroDesde.Size = new System.Drawing.Size(172, 31);
            this.TxtNroDesde.TabIndex = 132;
            this.TxtNroDesde.Text = "1";
            this.TxtNroDesde.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtNroCai
            // 
            this.txtNroCai.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtNroCai.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNroCai.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNroCai.FocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            this.txtNroCai.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.txtNroCai.ForeColor = System.Drawing.Color.DimGray;
            this.txtNroCai.Location = new System.Drawing.Point(691, 119);
            this.txtNroCai.Name = "txtNroCai";
            this.txtNroCai.Numerico = true;
            this.txtNroCai.Size = new System.Drawing.Size(365, 31);
            this.txtNroCai.TabIndex = 128;
            // 
            // CboTipoComprobante
            // 
            this.CboTipoComprobante.BorderColor = System.Drawing.Color.Empty;
            this.CboTipoComprobante.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CboTipoComprobante.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CboTipoComprobante.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CboTipoComprobante.FormattingEnabled = true;
            this.CboTipoComprobante.Location = new System.Drawing.Point(18, 190);
            this.CboTipoComprobante.Name = "CboTipoComprobante";
            this.CboTipoComprobante.Size = new System.Drawing.Size(270, 29);
            this.CboTipoComprobante.TabIndex = 126;
            // 
            // cboPuntosVenta
            // 
            this.cboPuntosVenta.BorderColor = System.Drawing.Color.Empty;
            this.cboPuntosVenta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPuntosVenta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboPuntosVenta.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboPuntosVenta.FormattingEnabled = true;
            this.cboPuntosVenta.Location = new System.Drawing.Point(17, 129);
            this.cboPuntosVenta.Name = "cboPuntosVenta";
            this.cboPuntosVenta.Size = new System.Drawing.Size(271, 29);
            this.cboPuntosVenta.TabIndex = 120;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Image = global::CapaPresentacion.Properties.Resources.Command_Redo_32;
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.Location = new System.Drawing.Point(1069, 181);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(126, 45);
            this.btnCancelar.TabIndex = 15;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConfirmar.BackColor = System.Drawing.Color.SteelBlue;
            this.btnConfirmar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConfirmar.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
            this.btnConfirmar.FlatAppearance.BorderSize = 0;
            this.btnConfirmar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SteelBlue;
            this.btnConfirmar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SteelBlue;
            this.btnConfirmar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirmar.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirmar.ForeColor = System.Drawing.Color.White;
            this.btnConfirmar.Image = global::CapaPresentacion.Properties.Resources.Task_03_32;
            this.btnConfirmar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnConfirmar.Location = new System.Drawing.Point(1069, 115);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(126, 45);
            this.btnConfirmar.TabIndex = 14;
            this.btnConfirmar.Text = "Confirmar";
            this.btnConfirmar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConfirmar.UseVisualStyleBackColor = false;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // frmCargaNroCai
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1207, 598);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.DataGrid);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.TxtNroHasta);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.TxtNroDesde);
            this.Controls.Add(this.DtpVencimiento);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtNroCai);
            this.Controls.Add(this.CboTipoComprobante);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cboPuntosVenta);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.pnTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "frmCargaNroCai";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmCargaNroCai";
            this.Load += new System.EventHandler(this.frmCargaNroCai_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmCargaNroCai_KeyDown);
            this.pnTitle.ResumeLayout(false);
            this.pnTitle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgReturn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnTitle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox imgReturn;
        private Controles.boton btnCancelar;
        private Controles.boton btnConfirmar;
        private Controles.combo cboPuntosVenta;
        private System.Windows.Forms.Label label11;
        private Controles.combo CboTipoComprobante;
        private System.Windows.Forms.Label label4;
        private textboxAdv txtNroCai;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker DtpVencimiento;
        private System.Windows.Forms.Label label6;
        private textboxAdv TxtNroDesde;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private textboxAdv TxtNroHasta;
        private Controles.dgv DataGrid;
        private Controles.boton btnBuscar;
    }
}