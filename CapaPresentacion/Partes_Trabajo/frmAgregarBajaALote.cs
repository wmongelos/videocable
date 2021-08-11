using CapaNegocios;
using CapaNegocios.Panel_Tareas;
using CapaPresentacion.Controles;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion.Partes_Trabajo
{
    public partial class frmAgregarBajaALote : Form
    {
        private int idParte;
        private DataRow datosParte;
        private DataTable dtProcesosParaEjecutar;
        private bool cerrarForm;
        private Procesos_Ejecucion.Tipo_De_Ejecucion tipoEjecucionDeLote;

        public frmAgregarBajaALote(int idParte)
        {
            InitializeComponent();
            this.cerrarForm = false;
            this.idParte = idParte;
            ComenzarCarga();
        }

        private void ComenzarCarga()
        {
            this.datosParte = new Partes().TraerParteRow(idParte);

            if(Convert.ToInt32(datosParte["id_partes_operaciones"]) != Convert.ToInt32(Partes.Partes_Operaciones.BAJA))
            {
                MessageBox.Show("El parte debe ser de baja de servicio para poder programar su baja", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cerrarForm = true;
                return;
            }

            this.calendario1.FechaPreseleccionada = Convert.ToDateTime(datosParte["fecha_programado"]);

            DataTable dtPartesUsuariosServicios = new Partes_Usuarios_Servicios().ListarServiciosPorParte(idParte, Partes_Usuarios_Servicios.CONDICION_REQ_EQUIPOS.TODOS);
            if (!VerificarBajaAMasDeUnServicio(dtPartesUsuariosServicios)) return;

            int idServicio = Convert.ToInt32(datosParte["id_servicios"]);
            DataTable datosServicio = new Servicios().BuscarDatosServicio(idServicio);
            this.tipoEjecucionDeLote = Convert.ToInt32(datosServicio.Rows[0]["id_aplicaciones_externas"]) > 0 ? Procesos_Ejecucion.Tipo_De_Ejecucion.Automatico : Procesos_Ejecucion.Tipo_De_Ejecucion.Manual;

            List<Calendario.CalendarioFecha> fechasCargadas = new List<Calendario.CalendarioFecha>();
            //Lista el doble de registros
            dtProcesosParaEjecutar = new Procesos_Ejecucion().ListarNoIniciados();
            if(dtProcesosParaEjecutar.Rows.Count > 0)
            {
                foreach (DataRow row in dtProcesosParaEjecutar.Rows)
                {
                    //Verificar si tiene fecha de reprogramado
                    Calendario.CalendarioFecha cf = 
                        new Calendario.CalendarioFecha(Convert.ToDateTime(row["Fecha_Ejecucion"]), row["descripcion"].ToString());
                    fechasCargadas.Add(cf);
                }
                calendario1.FechasCargadas = fechasCargadas;
            }
        }

        private void calendario1_Confirmacion(DateTime fechaSeleccionada, int cantidadProgramaciones)
        {
            Procesos_Ejecucion oProcesoEjec = new Procesos_Ejecucion_Lotes()
                            .ObtenerProcesoEjecucion(
                                fechaSeleccionada,
                                Procesos.Proceso.Lote_Parte_Baja,
                                tipoEjecucionDeLote
                            );

            if (cantidadProgramaciones > 0 && oProcesoEjec != null)
            {
                //solo va a poder haaber 1 proceso de baja por dia, y se va a asignar a ese
                Procesos_Ejecucion_Lotes oProEjecLotes = new Procesos_Ejecucion_Lotes();
                oProEjecLotes.AgregarRegistroALote(oProcesoEjec.Id, idParte);
            }
            else
            {
                oProcesoEjec = new Procesos_Ejecucion();
                oProcesoEjec.Id_Proceso = Convert.ToInt32(Procesos.Proceso.Lote_Parte_Baja);
                oProcesoEjec.Estado = Convert.ToInt32(Procesos_Ejecucion.Estados_Ejecucion_Proceso.No_Iniciado);
                oProcesoEjec.Id_Proceso_Automatico = 0;
                oProcesoEjec.Fecha_Ejecucion = fechaSeleccionada; //agregar la hora
                oProcesoEjec.Id_Personal = Personal.Id_Login;
                oProcesoEjec.Tipo_Proceso = Convert.ToInt32(tipoEjecucionDeLote);
                int idProcesoEjecucion = oProcesoEjec.Guardar(oProcesoEjec);

                Procesos_Ejecucion_Lotes oProEjecLotes = new Procesos_Ejecucion_Lotes();
                oProEjecLotes.AgregarRegistroALote(idProcesoEjecucion, idParte);
            }

            Partes_Historial oParteHistorial = new Partes_Historial()
            {
                Id_Parte = idParte,
                Id_Personal = Personal.Id_Login,
                Id_area = Personal.Id_Area,
                Id_Usuarios = Convert.ToInt32(datosParte["id_usuarios"]),
                Id_Partes_Estados = Convert.ToInt32(datosParte["id_partes_estados"]),
                Fecha_Movimiento = DateTime.Now
            };

            new Partes().ActualizarFechaProgramado(oParteHistorial.Id_Parte, fechaSeleccionada);
            oParteHistorial.Detalles = "Reprogramacion de baja";
            oParteHistorial.GuardarNuevoDetalle(oParteHistorial);

            MessageBox.Show($"Baja asignada correctamente al dia {fechaSeleccionada.ToString("dd 'de' MMMM 'del' yyyy")}", "Mensaje del sistema");
            this.DialogResult = DialogResult.OK;
        }

        private bool VerificarBajaAMasDeUnServicio(DataTable dtPartesUsuariosServicios)
        {
            if (dtPartesUsuariosServicios.Rows.Count != 1)
            {
                MessageBox.Show("Parte de cero o mas de un servicio", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                return true;
            }
        }

        private void frmAgregarBajaALote_Shown(object sender, EventArgs e)
        {
            if (cerrarForm)
                this.Close();
        }

        private void CerrarFormulario()
        {
            if(MessageBox.Show(
                "Si no se selecciona una fecha de programacion la baja quedara programada para el dia de hoy\n¿Cerrar calendario de todas formas?", 
                "Mensaje del sistema",
                MessageBoxButtons.YesNo, 
                MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void calendario1_SeleccionFechaPasada(DateTime fechaSeleccionada, int cantidadProgramaciones)
        {
            MessageBox.Show("La fecha de programacion no puede ser menor a la fecha actual", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            return;
        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.CerrarFormulario();
        }

        private void frmAgregarBajaALote_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.CerrarFormulario();
        }
    }
}
