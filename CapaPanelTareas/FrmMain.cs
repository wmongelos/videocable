using CapaNegocios.Panel_Tareas;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceProcess;
using System.Threading;
using System.Windows.Forms;
using ServicioWindows;

namespace CapaPanelTareas
{
    public partial class FrmMain : Form
    {

        public ServiceController Controller { get; private set; }
        public bool ServicioInstalado { get; private set; }

        private Thread hilo;
        private delegate void myDel();
        private DataTable dtProcesosNoIniciados = new DataTable();
        private DataTable dtProcesosHistorial = new DataTable();

        private static FrmMain frmMain = null;

        public static FrmMain GetInstancia()
        {
            if (frmMain == null)
                frmMain = new FrmMain();

            return frmMain;
        }

        private FrmMain()
        {
            InitializeComponent();
            Controller = new ServiceController(Servicio.NombreServicio);
            if(!ServiceController.GetServices().Any(serviceController => serviceController.ServiceName.Equals(Servicio.NombreServicio)))
            {
                tsEstadoServicio.Text = $"{tsEstadoServicio.Text}: (El servicio '{Servicio.NombreServicio}' no esta instalado)";
                ServicioInstalado = false;
            }
            else
            {
                ServicioInstalado = true;
            }
        }

        private void comenzarCarga()
        {
            UseWaitCursor = true;
            dgvProcesosProximos.DataSource = null;
            hilo = new Thread(new ThreadStart(cargarDatos));
            hilo.Start();
        }

        private void cargarDatos()
        {
            try
            {
                dtProcesosNoIniciados = new Procesos_Ejecucion().ListarNoIniciados();
                dtProcesosHistorial = new Procesos_Ejecucion().ListarHistorial();
                myDel MD = new myDel(asignarDatos);
                this.Invoke(MD, new object[] { });
                UseWaitCursor = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar Informacion" + ex.Message);
            }
        }

        private void asignarDatos()
        {
            ActualizarEstadoServicio();
            dgvProcesosProximos.DataSource = dtProcesosNoIniciados;
            foreach (DataGridViewColumn col in dgvProcesosProximos.Columns)
            {
                col.Visible = false;
            }

            dgvProcesosProximos.Columns["descripcion"].Visible = true;
            dgvProcesosProximos.Columns["descripcion"].HeaderText = "Proceso";
            dgvProcesosProximos.Columns["descripcion"].DisplayIndex = 0;
            dgvProcesosProximos.Columns["descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvProcesosProximos.Columns["id_proceso"].Visible = true;
            dgvProcesosProximos.Columns["id_proceso"].HeaderText = "ID Proceso";
            dgvProcesosProximos.Columns["id_proceso"].DisplayIndex = 1;
            dgvProcesosProximos.Columns["id_proceso"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvProcesosProximos.Columns["id_proceso_automatico"].Visible = true;
            dgvProcesosProximos.Columns["id_proceso_automatico"].HeaderText = "ID Proceso Automatico";
            dgvProcesosProximos.Columns["id_proceso_automatico"].DisplayIndex = 2;
            dgvProcesosProximos.Columns["id_proceso_automatico"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvProcesosProximos.Columns["fecha_ejecucion"].Visible = true;
            dgvProcesosProximos.Columns["fecha_ejecucion"].HeaderText = "Fecha Ejecucion";
            dgvProcesosProximos.Columns["fecha_ejecucion"].DisplayIndex = 3;
            dgvProcesosProximos.Columns["fecha_ejecucion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvProcesosProximos.Columns["fecha_reprogramado"].Visible = true;
            dgvProcesosProximos.Columns["fecha_reprogramado"].HeaderText = "Fecha Programada";
            dgvProcesosProximos.Columns["fecha_reprogramado"].DisplayIndex = 3;
            dgvProcesosProximos.Columns["fecha_reprogramado"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void ActualizarEstadoServicio()
        {
            if (ServicioInstalado)
            {
                Controller.Refresh();
                tsEstadoServicio.Text = $"Estado del servicio: {Controller.Status}";
                if (ServicioInstalado && Controller.Status == ServiceControllerStatus.Running)
                {
                    tsEstadoServicio.BackColor = Color.LightGreen;
                }
                else
                {
                    tsEstadoServicio.BackColor = Color.Tomato;
                }
            }
        }

        private void cargarDatosProceso(int filaSeleccionada)
        {
            int idProcesoSeleccionado = Convert.ToInt32(dtProcesosNoIniciados.Rows[filaSeleccionada]["Id_Proceso"]);

            lblProcesoNombre.Text = dtProcesosNoIniciados.Rows[filaSeleccionada]["descripcion"].ToString();
            lblPeriodo.Text = dtProcesosNoIniciados.Rows[filaSeleccionada]["periodo"].ToString();
            lblFechaInicio.Text = $" {Convert.ToDateTime(dtProcesosNoIniciados.Rows[filaSeleccionada]["fecha_inicio"]):yyyy/MM/dd hh:mm}";
            var fechaFin = Convert.ToDateTime(dtProcesosNoIniciados.Rows[filaSeleccionada]["fecha_fin"]);
            if(fechaFin.Date == DateTime.MaxValue.Date)
                lblFechaFin.Text = " INDETERMINADA";
            else
                lblFechaFin.Text = $" {fechaFin:yyyy/MM/dd hh:mm}";
            lblDescripcion.Text = dtProcesosNoIniciados.Rows[filaSeleccionada]["descripcion_automatico"].ToString();

            dtProcesosHistorial.DefaultView.RowFilter = $"Id_Proceso = {idProcesoSeleccionado}";
            dgvHistorialDeProceso.DataSource = dtProcesosHistorial.DefaultView.ToTable();

            foreach (DataGridViewColumn col in dgvHistorialDeProceso.Columns)
            {
                col.Visible = false;
            }

            dgvHistorialDeProceso.Columns["fecha_ejecucion"].Visible = true;
            dgvHistorialDeProceso.Columns["fecha_ejecucion"].HeaderText = "Fecha de ejecucion";
            dgvHistorialDeProceso.Columns["fecha_ejecucion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvHistorialDeProceso.Columns["estado"].Visible = true;
            dgvHistorialDeProceso.Columns["estado"].HeaderText = "Estado";
            dgvHistorialDeProceso.Columns["estado"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvHistorialDeProceso.Columns["id_personal"].Visible = true;
            dgvHistorialDeProceso.Columns["id_personal"].HeaderText = "ID Personal";
            dgvHistorialDeProceso.Columns["id_personal"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void btnCrearProcesoAutomatico_Click(object sender, EventArgs e)
        {
            frmCrearProcesoAutomatico frmProcesoAuto = new frmCrearProcesoAutomatico();
            if (frmProcesoAuto.ShowDialog() == DialogResult.OK)
            {
                comenzarCarga();
                if (ServicioInstalado && Controller.Status == ServiceControllerStatus.Running)
                    Controller.ExecuteCommand(Convert.ToInt32(Servicio.Comandos.ActualizarEjecucionDeProcesos));
            }
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            comenzarCarga();
        }

        private void dgvProcesosProximos_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            cargarDatosProceso(e.RowIndex);
        }

        private void tsmActualizarDgv_Click(object sender, EventArgs e)
        {
            comenzarCarga();
        }

        private void administrarServicioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmAdministrarServicio().ShowDialog();
            ActualizarEstadoServicio();
        }
    }
}
