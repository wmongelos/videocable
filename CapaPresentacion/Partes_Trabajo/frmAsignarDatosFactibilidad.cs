using CapaNegocios;
using System;
using System.Windows.Forms;

namespace CapaPresentacion.Partes_Trabajo
{
    public partial class frmAsignarDatosFactibilidad : Form
    {
        Notificaciones oNotificacion = new Notificaciones();
        Notificaciones_Destinatarios oNotificacionesDestino = new Notificaciones_Destinatarios();
        Notificaciones_Adjuntos oNotificacionAdjuntos = new Notificaciones_Adjuntos();
        public int idItem;
        public int idTipoItem;
        public int idServicio;
        public int idNotificacionGuardada = 0;
        private Servicios oServicios = new Servicios();

        public frmAsignarDatosFactibilidad()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAsignar_Click(object sender, EventArgs e)
        {
            try
            {

                if (DateTime.Compare(dtpFecha.Value.Date, DateTime.Now.Date) >= 0)
                {
                    oNotificacion.Id = 0;
                    oNotificacion.Fecha_Creacion = DateTime.Now;
                    oNotificacion.Fecha_Limite = dtpFecha.Value;
                    oNotificacion.Id_Emisor = Personal.Id_Login;
                    oNotificacion.Id_Area_Emisor = Personal.Id_Area;
                    oNotificacion.Id_Estado_Notificacion = Convert.ToInt32(Notificaciones.ESTADO_NOTIFICACION.PENDIENTE);
                    if (chkPrioridad.Checked == true)
                        oNotificacion.Id_Prioridad = Convert.ToInt32(Notificaciones.PRIORIDAD.ALTA);
                    else
                        oNotificacion.Id_Prioridad = Convert.ToInt32(Notificaciones.PRIORIDAD.MEDIA);

                    oNotificacion.Mensaje = "Factibilidad";
                    oNotificacion.Id_Tipo_Emisor = Convert.ToInt32(Notificaciones.TIPO_EMISOR.SISTEMA);
                    oNotificacion.Ejecutar = Convert.ToInt32(Notificaciones.EJECUTAR.No);
                    idNotificacionGuardada = oNotificacion.Guardar(oNotificacion);

                    oNotificacionesDestino.Id = 0;
                    oNotificacionesDestino.Id_Notificacion_Origen = idNotificacionGuardada;
                    oNotificacionesDestino.Id_Tipo_Destinatario = Convert.ToInt32(Notificaciones_Destinatarios.Tipo_Destinatario.AREA);
                    oNotificacionesDestino.Id_Destinatario = Personal.Id_Area;
                    oNotificacionesDestino.Id_Estado_Notificacion_Destinatario = Convert.ToInt32(Notificaciones.ESTADO_NOTIFICACION.PENDIENTE);
                    oNotificacionesDestino.Guardar(oNotificacionesDestino);

                    oNotificacionAdjuntos.Id = 0;
                    oNotificacionAdjuntos.Id_Notificacion = oNotificacion.Id;
                    oNotificacionAdjuntos.Id_Tipo_Modulo_Sistema = Convert.ToInt32(Notificaciones_Adjuntos.TIPO_ADJUNTOS.PARTE);
                    oNotificacionAdjuntos.Id_Item_Modulo = idItem;
                    oNotificacionAdjuntos.Id_Estado_Realizacion = Convert.ToInt32(Notificaciones_Adjuntos.ESTADO.PENDIENTE);
                    oNotificacionAdjuntos.Id_Accion = 0;
                    oNotificacionAdjuntos.Guardar(oNotificacionAdjuntos);
                    this.DialogResult = DialogResult.OK;
                }
                else
                    MessageBox.Show("La fecha seleccionada debe ser mayor o igual a la fecha de hoy.");
            }
            catch
            {
                MessageBox.Show("Error al asignar factibilidad.");
                this.Close();
            }
        }

        private void btnAsignarTiposEquipos_Click(object sender, EventArgs e)
        {
            frmAsignacionTiposEquipos frmAsignacionTiposEquipos = new frmAsignacionTiposEquipos(idItem);
            frmPopUp frmpopup = new frmPopUp();
            frmpopup.Maximizar = false;
            frmpopup.Formulario = frmAsignacionTiposEquipos;
            frmpopup.ShowDialog();

        }

        private void frmAsignarDatosFactibilidad_Load(object sender, EventArgs e)
        {
            try
            {
                if (oServicios.BuscarDatosServicio(idServicio).Rows[0]["requiere_equipo"].ToString() == "SI")
                    btnAsignarTiposEquipos.Enabled = true;
                else
                    btnAsignarTiposEquipos.Enabled = false;
            }
            catch
            {
                btnAsignarTiposEquipos.Enabled = false;
            }
        }
    }
}
