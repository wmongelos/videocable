
namespace CapaPanelTareas
{
    partial class FrmMain
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dgvProcesosProximos = new System.Windows.Forms.DataGridView();
            this.cmDgvProcesosEjecucion = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmActualizarDgv = new System.Windows.Forms.ToolStripMenuItem();
            this.btnCrearProcesoAutomatico = new System.Windows.Forms.Button();
            this.dgvHistorialDeProceso = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblFechaFin = new System.Windows.Forms.Label();
            this.lblFechaInicio = new System.Windows.Forms.Label();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.lblPeriodo = new System.Windows.Forms.Label();
            this.lblProcesoNombre = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblFechaFin2 = new System.Windows.Forms.Label();
            this.lblFechaInicio2 = new System.Windows.Forms.Label();
            this.ssBarra = new System.Windows.Forms.StatusStrip();
            this.tsEstadoServicio = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnCrearProcesoManual = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.procesosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.servicioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.administrarServicioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProcesosProximos)).BeginInit();
            this.cmDgvProcesosEjecucion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorialDeProceso)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.ssBarra.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvProcesosProximos
            // 
            this.dgvProcesosProximos.AllowUserToAddRows = false;
            this.dgvProcesosProximos.AllowUserToDeleteRows = false;
            this.dgvProcesosProximos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvProcesosProximos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProcesosProximos.ContextMenuStrip = this.cmDgvProcesosEjecucion;
            this.dgvProcesosProximos.Location = new System.Drawing.Point(559, 56);
            this.dgvProcesosProximos.MultiSelect = false;
            this.dgvProcesosProximos.Name = "dgvProcesosProximos";
            this.dgvProcesosProximos.ReadOnly = true;
            this.dgvProcesosProximos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProcesosProximos.Size = new System.Drawing.Size(492, 456);
            this.dgvProcesosProximos.TabIndex = 0;
            this.dgvProcesosProximos.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProcesosProximos_CellEnter);
            // 
            // cmDgvProcesosEjecucion
            // 
            this.cmDgvProcesosEjecucion.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmActualizarDgv});
            this.cmDgvProcesosEjecucion.Name = "cmDgvProcesosEjecucion";
            this.cmDgvProcesosEjecucion.Size = new System.Drawing.Size(127, 26);
            // 
            // tsmActualizarDgv
            // 
            this.tsmActualizarDgv.Name = "tsmActualizarDgv";
            this.tsmActualizarDgv.Size = new System.Drawing.Size(126, 22);
            this.tsmActualizarDgv.Text = "Actualizar";
            this.tsmActualizarDgv.Click += new System.EventHandler(this.tsmActualizarDgv_Click);
            // 
            // btnCrearProcesoAutomatico
            // 
            this.btnCrearProcesoAutomatico.Location = new System.Drawing.Point(24, 37);
            this.btnCrearProcesoAutomatico.Name = "btnCrearProcesoAutomatico";
            this.btnCrearProcesoAutomatico.Size = new System.Drawing.Size(165, 23);
            this.btnCrearProcesoAutomatico.TabIndex = 5;
            this.btnCrearProcesoAutomatico.Text = "Crear proceso automatico";
            this.btnCrearProcesoAutomatico.UseVisualStyleBackColor = true;
            this.btnCrearProcesoAutomatico.Click += new System.EventHandler(this.btnCrearProcesoAutomatico_Click);
            // 
            // dgvHistorialDeProceso
            // 
            this.dgvHistorialDeProceso.AllowUserToAddRows = false;
            this.dgvHistorialDeProceso.AllowUserToDeleteRows = false;
            this.dgvHistorialDeProceso.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvHistorialDeProceso.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHistorialDeProceso.Location = new System.Drawing.Point(12, 111);
            this.dgvHistorialDeProceso.MultiSelect = false;
            this.dgvHistorialDeProceso.Name = "dgvHistorialDeProceso";
            this.dgvHistorialDeProceso.ReadOnly = true;
            this.dgvHistorialDeProceso.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHistorialDeProceso.Size = new System.Drawing.Size(514, 318);
            this.dgvHistorialDeProceso.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(556, 38);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(115, 15);
            this.label5.TabIndex = 16;
            this.label5.Text = "Procesos proximos:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 91);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 15);
            this.label1.TabIndex = 17;
            this.label1.Text = "Historial";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Proceso:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "Periodo:";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.lblFechaFin);
            this.groupBox1.Controls.Add(this.lblFechaInicio);
            this.groupBox1.Controls.Add(this.lblDescripcion);
            this.groupBox1.Controls.Add(this.lblPeriodo);
            this.groupBox1.Controls.Add(this.lblProcesoNombre);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.lblFechaFin2);
            this.groupBox1.Controls.Add(this.lblFechaInicio2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.dgvHistorialDeProceso);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 77);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(538, 435);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Informacion de proceso";
            // 
            // lblFechaFin
            // 
            this.lblFechaFin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaFin.Location = new System.Drawing.Point(398, 48);
            this.lblFechaFin.Name = "lblFechaFin";
            this.lblFechaFin.Size = new System.Drawing.Size(128, 13);
            this.lblFechaFin.TabIndex = 27;
            this.lblFechaFin.Text = "-";
            // 
            // lblFechaInicio
            // 
            this.lblFechaInicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaInicio.Location = new System.Drawing.Point(407, 26);
            this.lblFechaInicio.Name = "lblFechaInicio";
            this.lblFechaInicio.Size = new System.Drawing.Size(119, 13);
            this.lblFechaInicio.TabIndex = 26;
            this.lblFechaInicio.Text = "-";
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescripcion.Location = new System.Drawing.Point(84, 70);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(442, 13);
            this.lblDescripcion.TabIndex = 25;
            this.lblDescripcion.Text = "-";
            // 
            // lblPeriodo
            // 
            this.lblPeriodo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPeriodo.Location = new System.Drawing.Point(67, 48);
            this.lblPeriodo.Name = "lblPeriodo";
            this.lblPeriodo.Size = new System.Drawing.Size(255, 13);
            this.lblPeriodo.TabIndex = 24;
            this.lblPeriodo.Text = "-";
            // 
            // lblProcesoNombre
            // 
            this.lblProcesoNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProcesoNombre.Location = new System.Drawing.Point(67, 26);
            this.lblProcesoNombre.Name = "lblProcesoNombre";
            this.lblProcesoNombre.Size = new System.Drawing.Size(255, 13);
            this.lblProcesoNombre.TabIndex = 23;
            this.lblProcesoNombre.Text = "-";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(12, 70);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(78, 13);
            this.label7.TabIndex = 22;
            this.label7.Text = "Descripcion:";
            // 
            // lblFechaFin2
            // 
            this.lblFechaFin2.AutoSize = true;
            this.lblFechaFin2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaFin2.Location = new System.Drawing.Point(328, 48);
            this.lblFechaFin2.Name = "lblFechaFin2";
            this.lblFechaFin2.Size = new System.Drawing.Size(64, 13);
            this.lblFechaFin2.TabIndex = 21;
            this.lblFechaFin2.Text = "Fecha fin:";
            // 
            // lblFechaInicio2
            // 
            this.lblFechaInicio2.AutoSize = true;
            this.lblFechaInicio2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaInicio2.Location = new System.Drawing.Point(328, 26);
            this.lblFechaInicio2.Name = "lblFechaInicio2";
            this.lblFechaInicio2.Size = new System.Drawing.Size(80, 13);
            this.lblFechaInicio2.TabIndex = 20;
            this.lblFechaInicio2.Text = "Fecha inicio:";
            // 
            // ssBarra
            // 
            this.ssBarra.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsEstadoServicio});
            this.ssBarra.Location = new System.Drawing.Point(0, 525);
            this.ssBarra.Name = "ssBarra";
            this.ssBarra.Size = new System.Drawing.Size(1063, 22);
            this.ssBarra.TabIndex = 22;
            this.ssBarra.Text = "statusStrip1";
            // 
            // tsEstadoServicio
            // 
            this.tsEstadoServicio.Name = "tsEstadoServicio";
            this.tsEstadoServicio.Size = new System.Drawing.Size(104, 17);
            this.tsEstadoServicio.Text = "Estado del servicio";
            // 
            // btnCrearProcesoManual
            // 
            this.btnCrearProcesoManual.Location = new System.Drawing.Point(195, 37);
            this.btnCrearProcesoManual.Name = "btnCrearProcesoManual";
            this.btnCrearProcesoManual.Size = new System.Drawing.Size(165, 23);
            this.btnCrearProcesoManual.TabIndex = 23;
            this.btnCrearProcesoManual.Text = "Crear proceso manual";
            this.btnCrearProcesoManual.UseVisualStyleBackColor = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.procesosToolStripMenuItem,
            this.servicioToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1063, 24);
            this.menuStrip1.TabIndex = 24;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // procesosToolStripMenuItem
            // 
            this.procesosToolStripMenuItem.Name = "procesosToolStripMenuItem";
            this.procesosToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.procesosToolStripMenuItem.Text = "Procesos";
            // 
            // servicioToolStripMenuItem
            // 
            this.servicioToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.administrarServicioToolStripMenuItem});
            this.servicioToolStripMenuItem.Name = "servicioToolStripMenuItem";
            this.servicioToolStripMenuItem.Size = new System.Drawing.Size(90, 20);
            this.servicioToolStripMenuItem.Text = "Herramientas";
            // 
            // administrarServicioToolStripMenuItem
            // 
            this.administrarServicioToolStripMenuItem.Name = "administrarServicioToolStripMenuItem";
            this.administrarServicioToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.administrarServicioToolStripMenuItem.Text = "Administrar servicio";
            this.administrarServicioToolStripMenuItem.Click += new System.EventHandler(this.administrarServicioToolStripMenuItem_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1063, 547);
            this.Controls.Add(this.btnCrearProcesoManual);
            this.Controls.Add(this.ssBarra);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnCrearProcesoAutomatico);
            this.Controls.Add(this.dgvProcesosProximos);
            this.MinimumSize = new System.Drawing.Size(1079, 586);
            this.Name = "FrmMain";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gies :: Panel de control";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProcesosProximos)).EndInit();
            this.cmDgvProcesosEjecucion.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorialDeProceso)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ssBarra.ResumeLayout(false);
            this.ssBarra.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvProcesosProximos;
        private System.Windows.Forms.Button btnCrearProcesoAutomatico;
        private System.Windows.Forms.DataGridView dgvHistorialDeProceso;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblFechaFin2;
        private System.Windows.Forms.Label lblFechaInicio2;
        private System.Windows.Forms.Label lblProcesoNombre;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.Label lblPeriodo;
        private System.Windows.Forms.StatusStrip ssBarra;
        private System.Windows.Forms.ToolStripStatusLabel tsEstadoServicio;
        private System.Windows.Forms.ContextMenuStrip cmDgvProcesosEjecucion;
        private System.Windows.Forms.ToolStripMenuItem tsmActualizarDgv;
        private System.Windows.Forms.Button btnCrearProcesoManual;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem procesosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem servicioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem administrarServicioToolStripMenuItem;
        private System.Windows.Forms.Label lblFechaFin;
        private System.Windows.Forms.Label lblFechaInicio;
    }
}

