using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using CapaNegocios;


namespace CapaPresentacion.Informes
{
    public partial class frmConsultaBalance : Form
    {
        #region [PROPIEDADES]
        private delegate void myDel();
        private Thread hilo;
        private DataTable dtBalance = new DataTable();
        private Informes_Contables oInformesContables = new Informes_Contables();
        private bool enProceso = false;
        #endregion
        #region METODOS
        private void comenzarCarga()
        {
          

            pgCircular.Start();
            lblEstado.Enabled = true;

            BloquearControles();
            hilo = new Thread(new ThreadStart(cargarDatos));
            hilo.Start();
           
        }
        private void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
        {
            this.Close();
        }
        public void Stop()
        {
            hilo.Interrupt();
        }
        private void cargarDatos()
        {
            try
            {
                enProceso = true;
                dtBalance = oInformesContables.ListarBalance(dtpFechaDesde.Value);
                myDel MD = new myDel(asignarDatos);
                this.Invoke(MD, new object[] { });
                pgCircular.Stop();
                enProceso = false;
            }
            catch (Exception ex)
            {
                enProceso = false;

                MessageBox.Show("Error al cargar Informacion" + ex.Message);
            }
        }

        private void asignarDatos()
        {
            if (dtBalance.Rows.Count > 0)
            {
                dgvDatos.DataSource = dtBalance;
                if (dtBalance.Columns.Count > 1)
                {
                    dgvDatos.Columns["total"].HeaderText = "Total";
                    dgvDatos.Columns["codigo"].HeaderText = "Codigo";
                    dgvDatos.Columns["apellido"].HeaderText = "Apellido";
                    dgvDatos.Columns["nombre"].HeaderText = "Nombre";
                    dgvDatos.Columns["total"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dgvDatos.Columns["total"].DefaultCellStyle.Format = "c2";
                    lblTotal.Text = String.Format("Total de Registros: {0}", dtBalance.Rows.Count);
                    object sumTotal = dtBalance.Compute("sum(total)", "");
                    lblMontoTotal.Text ="Total: " + Convert.ToDecimal(sumTotal).ToString("c2");
                }
                DesBloquearControles();
                btnExportar.Enabled = true;
            }
            else
            {
                DesBloquearControles();
                btnExportar.Enabled = false;
                MessageBox.Show("No se encontraron resultados","Mensaje del Sistema",MessageBoxButtons.OK);
            }
            lblEstado.Visible = false;
            pgCircular.Stop();
            pgCircular.Visible = false;
        }

        private void BloquearControles()
        {
            foreach (Control item in this.Controls)
            {
                if (item.Name != "pgCircular" && item.Name != "lblEstado")
                    item.Enabled = false;
            }
        }

        private void DesBloquearControles()
        {
            foreach (Control item in this.Controls)
                item.Enabled = true;
        }
        #endregion
        public frmConsultaBalance()
        {
            InitializeComponent();
        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            if (enProceso)
            {
                Stop();
                lblEstado.Text = "Cancelando consulta...";
                pgCircular.Stop();
                tmrTimer.Interval = 2000;
                tmrTimer.Enabled = true;
                tmrTimer.Start();
            }
            else
                this.Close();
        }

        private void frmConsultaBalance_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                if (enProceso)
                {
                    Stop();
                    lblEstado.Text = "Cancelando consulta...";
                    pgCircular.Stop();
                    tmrTimer.Interval = 2000;
                    tmrTimer.Enabled = true;
                    tmrTimer.Start();
                }
                else
                    this.Close();
            }
        }

        private void frmConsultaBalance_Load(object sender, EventArgs e)
        {
            
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            lblEstado.Visible = true;
            pgCircular.Visible = true;
            pgCircular.Location = new Point(dgvDatos.Width / 2 - pgCircular.Width / 2, dgvDatos.Location.Y + dgvDatos.Height / 2 - pgCircular.Height / 2);
            lblEstado.Text = "Buscando información...";
            lblEstado.Location = new Point(pgCircular.Location.X - (pgCircular.Width / 2), pgCircular.Location.Y + pgCircular.Height + 15);
            comenzarCarga();
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            BloquearControles();
            Tools oTools = new Tools();
            oTools.ExportDataTableToExcel(dtBalance, "Balance");
            DesBloquearControles();
        }

        private void tmrTimer_Tick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void OnTimedEvent(object sender, EventArgs e)
        {
            this.Close();

        }
    }
}
