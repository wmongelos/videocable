
namespace CapaPresentacion.PagosExternos.Bapro
{
    partial class frmBaproTxt
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
            this.pnLinea1 = new System.Windows.Forms.Panel();
            this.lbTitulo = new System.Windows.Forms.Label();
            this.imgReturn = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnProcesar = new CapaPresentacion.Controles.boton();
            this.btnExaminar = new CapaPresentacion.Controles.boton();
            this.txtArchivo = new CapaPresentacion.textboxAdv();
            this.btnExcel = new CapaPresentacion.Controles.boton();
            this.btnGeneraTxt = new CapaPresentacion.Controles.boton();
            this.pnLinea1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgReturn)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnLinea1
            // 
            this.pnLinea1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.pnLinea1.Controls.Add(this.lbTitulo);
            this.pnLinea1.Controls.Add(this.imgReturn);
            this.pnLinea1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnLinea1.Location = new System.Drawing.Point(0, 0);
            this.pnLinea1.Name = "pnLinea1";
            this.pnLinea1.Size = new System.Drawing.Size(616, 85);
            this.pnLinea1.TabIndex = 79;
            // 
            // lbTitulo
            // 
            this.lbTitulo.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitulo.ForeColor = System.Drawing.Color.White;
            this.lbTitulo.Location = new System.Drawing.Point(53, 29);
            this.lbTitulo.Name = "lbTitulo";
            this.lbTitulo.Size = new System.Drawing.Size(243, 23);
            this.lbTitulo.TabIndex = 85;
            this.lbTitulo.Text = "BAPRO Pagos - Registrar pagos";
            this.lbTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // imgReturn
            // 
            this.imgReturn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.imgReturn.Image = global::CapaPresentacion.Properties.Resources.Left_Arrow_32;
            this.imgReturn.Location = new System.Drawing.Point(12, 24);
            this.imgReturn.Name = "imgReturn";
            this.imgReturn.Size = new System.Drawing.Size(32, 32);
            this.imgReturn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgReturn.TabIndex = 79;
            this.imgReturn.TabStop = false;
            this.imgReturn.Click += new System.EventHandler(this.imgReturn_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btnProcesar);
            this.groupBox1.Controls.Add(this.btnExaminar);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtArchivo);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 130);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(592, 122);
            this.groupBox1.TabIndex = 334;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cargar archivo";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(18, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(300, 21);
            this.label1.TabIndex = 86;
            this.label1.Text = "Seleccione el archivo devuelto por BAPRO";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnProcesar
            // 
            this.btnProcesar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnProcesar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnProcesar.Enabled = false;
            this.btnProcesar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnProcesar.FlatAppearance.BorderSize = 0;
            this.btnProcesar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnProcesar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnProcesar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProcesar.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnProcesar.ForeColor = System.Drawing.Color.White;
            this.btnProcesar.Image = global::CapaPresentacion.Properties.Resources.Next_32;
            this.btnProcesar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnProcesar.Location = new System.Drawing.Point(428, 59);
            this.btnProcesar.Name = "btnProcesar";
            this.btnProcesar.Size = new System.Drawing.Size(158, 29);
            this.btnProcesar.TabIndex = 335;
            this.btnProcesar.Text = "Procesar pagos";
            this.btnProcesar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProcesar.UseVisualStyleBackColor = false;
            this.btnProcesar.Click += new System.EventHandler(this.btnProcesar_Click);
            // 
            // btnExaminar
            // 
            this.btnExaminar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnExaminar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExaminar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnExaminar.FlatAppearance.BorderSize = 0;
            this.btnExaminar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnExaminar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnExaminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExaminar.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnExaminar.ForeColor = System.Drawing.Color.White;
            this.btnExaminar.Image = global::CapaPresentacion.Properties.Resources.lupa;
            this.btnExaminar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExaminar.Location = new System.Drawing.Point(315, 59);
            this.btnExaminar.Name = "btnExaminar";
            this.btnExaminar.Size = new System.Drawing.Size(107, 29);
            this.btnExaminar.TabIndex = 335;
            this.btnExaminar.Text = "Examinar";
            this.btnExaminar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExaminar.UseVisualStyleBackColor = false;
            this.btnExaminar.Click += new System.EventHandler(this.boton1_Click);
            // 
            // txtArchivo
            // 
            this.txtArchivo.BorderColor = System.Drawing.Color.Empty;
            this.txtArchivo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtArchivo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtArchivo.FocusColor = System.Drawing.Color.Empty;
            this.txtArchivo.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtArchivo.Location = new System.Drawing.Point(22, 59);
            this.txtArchivo.Name = "txtArchivo";
            this.txtArchivo.Numerico = false;
            this.txtArchivo.Size = new System.Drawing.Size(287, 29);
            this.txtArchivo.TabIndex = 0;
            // 
            // btnExcel
            // 
            this.btnExcel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnExcel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExcel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnExcel.FlatAppearance.BorderSize = 0;
            this.btnExcel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnExcel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExcel.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnExcel.ForeColor = System.Drawing.Color.White;
            this.btnExcel.Image = global::CapaPresentacion.Properties.Resources.Data_Export_32;
            this.btnExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExcel.Location = new System.Drawing.Point(148, 91);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(160, 33);
            this.btnExcel.TabIndex = 333;
            this.btnExcel.Text = "Exportar a Excel";
            this.btnExcel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExcel.UseVisualStyleBackColor = false;
            // 
            // btnGeneraTxt
            // 
            this.btnGeneraTxt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(76)))), ((int)(((byte)(100)))));
            this.btnGeneraTxt.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGeneraTxt.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnGeneraTxt.FlatAppearance.BorderSize = 0;
            this.btnGeneraTxt.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(174)))), ((int)(((byte)(170)))));
            this.btnGeneraTxt.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(187)))), ((int)(((byte)(183)))));
            this.btnGeneraTxt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGeneraTxt.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnGeneraTxt.ForeColor = System.Drawing.Color.White;
            this.btnGeneraTxt.Image = global::CapaPresentacion.Properties.Resources.Next_32;
            this.btnGeneraTxt.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGeneraTxt.Location = new System.Drawing.Point(12, 91);
            this.btnGeneraTxt.Name = "btnGeneraTxt";
            this.btnGeneraTxt.Size = new System.Drawing.Size(130, 33);
            this.btnGeneraTxt.TabIndex = 331;
            this.btnGeneraTxt.Text = "Generar TXT";
            this.btnGeneraTxt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGeneraTxt.UseVisualStyleBackColor = false;
            this.btnGeneraTxt.Click += new System.EventHandler(this.btnGeneraTxt_Click);
            // 
            // frmBaproTxt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(616, 259);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnExcel);
            this.Controls.Add(this.btnGeneraTxt);
            this.Controls.Add(this.pnLinea1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmBaproTxt";
            this.Text = "frmBaproTxt";
            this.Load += new System.EventHandler(this.frmBaproTxt_Load);
            this.pnLinea1.ResumeLayout(false);
            this.pnLinea1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgReturn)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnLinea1;
        private System.Windows.Forms.Label lbTitulo;
        private System.Windows.Forms.PictureBox imgReturn;
        private Controles.boton btnGeneraTxt;
        private Controles.boton btnExcel;
        private System.Windows.Forms.GroupBox groupBox1;
        private Controles.boton btnProcesar;
        private Controles.boton btnExaminar;
        private System.Windows.Forms.Label label1;
        private textboxAdv txtArchivo;
    }
}