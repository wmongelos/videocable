using CapaNegocios.Panel_Tareas;
using ServicioWindows;
using System;
using System.Data;
using System.Windows.Forms;

namespace CapaPanelTareas
{
    public partial class frmCrearProcesoAutomatico : Form
    {
        private DataTable dtProcesos = new DataTable();
        private TimeSpan horaDesdeSeleccionada = new TimeSpan();
        private TimeSpan horaHastaSeleccionada = new TimeSpan();

        public frmCrearProcesoAutomatico()
        {
            InitializeComponent();
        }

        private void CargarDatos()
        {
            DataTable dtPeriodos = new Procesos_Periodos().Listar();
            cboPeriodos.DataSource = dtPeriodos;
            cboPeriodos.ValueMember = "Id";
            cboPeriodos.DisplayMember = "Descripcion";

            dtProcesos = new Procesos().Listar();
            cboProcesos.DataSource = dtProcesos;
            cboProcesos.ValueMember = "Id";
            cboProcesos.DisplayMember = "Descripcion";
            cboProcesos.SelectedIndexChanged += cboProcesos_SelectedIndexChanged;
            cboProcesos_SelectedIndexChanged(cboProcesos, new EventArgs());
        }

        private void GuardarProcesoAutomatico()
        {
            int idPeriodoEjecucion = Convert.ToInt32(cboPeriodos.SelectedValue);

            if(!(dtpHoraEjecucion.Value.TimeOfDay >= horaDesdeSeleccionada && dtpHoraEjecucion.Value.TimeOfDay <= horaHastaSeleccionada))
            {
                MessageBox.Show("La hora seleccionada esta fuera del rango permitido", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DateTime fechaInicio = new DateTime(
                dtpFechaInicio.Value.Year, 
                dtpFechaInicio.Value.Month, 
                dtpFechaInicio.Value.Day, 
                dtpHoraEjecucion.Value.Hour, 
                dtpHoraEjecucion.Value.Minute,
                0);
            DateTime fechaFin = (cbFechaFinalizacion.Checked) ? dtpFechaFinalizacion.Value.Date : DateTime.MaxValue;
            string descripcion = txtDescripcion.Text.Trim();

            if(cbFechaFinalizacion.Checked && fechaInicio > fechaFin)
            {
                MessageBox.Show("No es posible seleccionar una fecha de finalizacion menor a la fecha de inicio", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (fechaInicio < DateTime.Now)
            {
                MessageBox.Show("La fecha de inicio no puede ser menor al dia y hora actual", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            try
            {
                Procesos_Automaticos oProcesosAutomaticos = new Procesos_Automaticos();
                oProcesosAutomaticos.Id_Proceso = Convert.ToInt32(cboProcesos.SelectedValue);
                oProcesosAutomaticos.Id_Periodo = idPeriodoEjecucion;
                oProcesosAutomaticos.Fecha_Inicio = fechaInicio;
                oProcesosAutomaticos.Fecha_Fin = fechaFin;
                oProcesosAutomaticos.Descripcion = descripcion;
                oProcesosAutomaticos.Guardar(oProcesosAutomaticos);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al generar el proceso: {ex.Message}", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Proceso autormatico configurado y almacenado correctamente", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DialogResult = DialogResult.OK;
        }

        private void frmCrearProcesoAutomatico_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void cbFechaFinalizacion_CheckedChanged(object sender, EventArgs e)
        {
            dtpFechaFinalizacion.Enabled = cbFechaFinalizacion.Checked;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            GuardarProcesoAutomatico();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void cboProcesos_SelectedIndexChanged(object sender, EventArgs e)
        {   
             foreach (DataRow row in dtProcesos.Rows)
             {
                 if(Convert.ToInt32(row["Id"]) == Convert.ToInt32(cboProcesos.SelectedValue))
                 {
                     lblDesde.Text = row["Hora_Ejecucion_Desde"].ToString();
                     lblHasta.Text = row["Hora_Ejecucion_Hasta"].ToString();
                     horaDesdeSeleccionada = TimeSpan.Parse(row["Hora_Ejecucion_Desde"].ToString());
                     horaHastaSeleccionada = TimeSpan.Parse(row["Hora_Ejecucion_Hasta"].ToString());
                 }
             }
        }
    }
}
