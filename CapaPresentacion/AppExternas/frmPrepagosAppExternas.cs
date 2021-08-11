using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocios;
using System.Threading;
using System.Globalization;

namespace CapaPresentacion.AppExternas
{
    public partial class frmPrepagosAppExternas : Form
    {


        private Thread hilo;
        private delegate void myDel();
        private DataTable dtPartesCortesAbiertos = new DataTable();
        private DataTable dtPartesConexionAbiertos = new DataTable();
        private DataRow drDatosServicio;
        private DataRow drDatosUsuario;
        private DataRow drDatosUsuarioServicio;
        private DataRow drDatosCtacte;
        private string resultadoFinal = "", resultadoFinalAccion = "";

        public int id_servicio = 0;
        public int id_tipo_servicio = 0;
        public List<int> prepagosAppExterna = new List<int>();
        public int id_usuario_servicio;
        public int id_usuario;
        public int id_locacion;
        public int id_ctacte_global;
        public string nombreUsuario;
        public DateTime fecha_desde, fecha_hasta, fecha_corte;
        private DateTime fechaDesdeUsuServ, fechaHastaUsuServ;
        public bool vieneDeudas = false, vieneRecibos = false;

        private Partes_Usuarios_Servicios oParteUsuServ = new Partes_Usuarios_Servicios();
        private Partes oParte = new Partes();
        private Partes_Historial oPartesHistorial = new Partes_Historial();
        private Partes_Solicitudes oPartesFallas = new Partes_Solicitudes();
        private Servicios oServicio = new Servicios();
        private Usuarios oUsuario = new Usuarios();
        private Usuarios_CtaCte oUsuariosCtaCte = new Usuarios_CtaCte();
        private Usuarios_Servicios oUsuServ = new Usuarios_Servicios();
        private Configuracion oConfig = new Configuracion();
        private Usuarios_CtaCte oUsuCtacte = new Usuarios_CtaCte();

        public frmPrepagosAppExternas()
        {
            InitializeComponent();
        }


        private void comenzarCarga()
        {
            pgCircular.Start();

            dgv.DataSource = null;

            hilo = new Thread(new ThreadStart(cargarDatos));
            hilo.Start();
        }

        private void cargarDatos()
        {
            try
            {
                dtPartesCortesAbiertos = oParte.getPartesUsuarioLocacionPrepagos(id_usuario, id_locacion,id_usuario_servicio ,(int)Partes.Partes_Operaciones.CORTE);
                dtPartesConexionAbiertos = oParte.getPartesUsuarioLocacionPrepagos(id_usuario, id_locacion, id_usuario_servicio, (int)Partes.Partes_Operaciones.RECONEXION);
                drDatosServicio = oServicio.getInfoServicio(id_servicio);
                drDatosUsuario = oUsuario.getDatos(id_usuario);
                drDatosUsuarioServicio = oUsuServ.getInfoUsuServicio(id_usuario_servicio);
                drDatosCtacte = oUsuCtacte.getDatosCtaCteId(id_ctacte_global);
                myDel MD = new myDel(asignarDatos);

                this.Invoke(MD, new object[] { });

                pgCircular.Stop();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar Informacion" + ex.Message);
            }

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void asignarDatos()
        {
            fechaDesdeUsuServ = Convert.ToDateTime(drDatosUsuarioServicio["fecha_desde"]);
            fechaHastaUsuServ = Convert.ToDateTime(drDatosUsuarioServicio["fecha_hasta"]);

            lblDesde.Text = $"Desde: {fecha_desde.Date.ToString("yyyy-MM-dd")}";
            lblHasta.Text = $"Hasta: {fecha_hasta.Date.ToString("yyyy-MM-dd")}";
            lblUsuario.Text = $"Usuario: [{drDatosUsuario["codigo"].ToString()}] {drDatosUsuario["apellido"].ToString() + drDatosUsuario["nombre"].ToString()}";
            lblServicio.Text = $"Servicio: {drDatosServicio["descripcion"].ToString()}";
            lblFechaCorte.Text = $"Corte de Servicio: {fecha_hasta.Date.ToString("yyyy-MM-dd")}";
            lblFechaCorte.ForeColor = Color.Red;
            dgv.DataSource = dtPartesCortesAbiertos;

            for (int i = 0; i < dgv.ColumnCount; i++)
                dgv.Columns[i].Visible = true;

            dgvConexionex.DataSource = dtPartesConexionAbiertos;

            for (int i = 0; i < dgvConexionex.ColumnCount; i++)
                dgvConexionex.Columns[i].Visible = true;
        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConfirmarAcciones_Click(object sender, EventArgs e)
        {
            if(vieneDeudas == true)
            {
                if (dtPartesCortesAbiertos.Rows.Count > 0)
                {
                    if (fecha_desde.AddDays(-1) == fechaHastaUsuServ.Date)
                        actualizarProgramadoParteCorte();
                    else
                    {
                        if (fecha_desde > DateTime.Now)
                            generaParteReconexion();
                        else
                        {
                            if (Convert.ToInt32(oConfig.GetValor_N("CassServPeriodo")) == (int)Aplicaciones_Externas.GENERA_ACCIONES_SERVICIOS_PERIODOS.GENERACION_COMPROBANTES)
                                oUsuariosCtaCte.gestionarAppExternaPrepagos(id_usuario_servicio, out resultadoFinal, out resultadoFinalAccion, true);
                        }             
                        generarParteCorte();
                    }
                }
                else
                {
                    if (fecha_desde > DateTime.Now)
                        generaParteReconexion();
                    else
                        oUsuariosCtaCte.gestionarAppExternaPrepagos(id_usuario_servicio, out resultadoFinal, out resultadoFinalAccion, true);

                    generarParteCorte();
                }
            }
            else if(vieneRecibos == true)
            {
                DataTable dtAux = new DataTable();
                DataView dvParteGenerado;
                dvParteGenerado = dtPartesConexionAbiertos.DefaultView;
                dvParteGenerado.RowFilter = $"idctacte= {id_ctacte_global}";
                dtAux = dvParteGenerado.ToTable();
                if(dtAux.Rows.Count > 0)
                {
                    if (Convert.ToDateTime(dtAux.Rows[0]["programado"]).Date == DateTime.Now.Date)
                        oUsuariosCtaCte.gestionarAppExternaPrepagos(id_usuario_servicio, out resultadoFinal, out resultadoFinalAccion, true);
                    else
                        MessageBox.Show($"No se activaron los paquetes, el servicio esta programado para activarse el dia: {dtAux.Rows[0]["programado"].ToString()}");
                }
                
            }
            MessageBox.Show($"Operaciones realizada correctamente");
            this.Close();
        }

        private void generarParteCorte()
        {
            DataTable drParteFalla;
            drParteFalla = oPartesFallas.GetFallasPorTipoServYOp(id_tipo_servicio, Convert.ToInt32(Partes.Partes_Operaciones.CORTE));

            if (drParteFalla.Rows.Count > 0)
            {
                int idParte = 0;
                oParte.Id_Usuarios = id_usuario;
                oParte.Id_Servicios = id_servicio;
                oParte.Id_Usuarios_Servicios = id_usuario_servicio;
                oParte.Id_Usuarios_Locaciones = id_locacion;
                oParte.Id_Zonas = 0;
                oParte.Id_Partes_Fallas = Convert.ToInt32(drParteFalla.Rows[0]["id"].ToString());
                oParte.Id_Partes_Soluciones = 0;
                oParte.Id_Movil = 0;
                oParte.Id_Operadores = Personal.Id_Login;
                oParte.Id_Areas = Personal.Id_Area;
                oParte.Fecha_Reclamo = Convert.ToDateTime(DateTime.Now.ToLongTimeString());
                oParte.Detalle_Solucion = "."; // txtDetalle.Text;
                oParte.Detalle_Falla = "";
                oParte.Fecha_Programado = fecha_hasta;
                oParte.Id_Partes_Estados = Convert.ToInt32(Partes.Partes_Estados.PENDIENTE_DE_ASIGNACION_DE_TECNICO);
                oParte.Id_Tecnico = Personal.Id_Login;
                oParte.Id_Usuarios_Cuenta_Corriente = 0;
                idParte = oParte.Guardar(oParte, 1);
                //genero el historial
                oPartesHistorial.Id_Parte = idParte;
                oPartesHistorial.Id_Usuarios = id_usuario;
                oPartesHistorial.Id_Personal = Personal.Id_Login;
                oPartesHistorial.Fecha_Movimiento = DateTime.Now;
                oPartesHistorial.Id_area = Personal.Id_Area;
                oPartesHistorial.Detalles = "PARTE PASADO A REALIZADO.";
                oPartesHistorial.Id_Partes_Estados = Convert.ToInt32(Partes.Partes_Estados.PENDIENTE_DE_ASIGNACION_DE_TECNICO);
                oPartesHistorial.GuardarNuevoDetalle(oPartesHistorial);

            }
        }

        private void actualizarProgramadoParteCorte()
        {
            oParte.ActualizarFechaProgramado(Convert.ToInt32(dgv.SelectedRows[0].Cells["idParte"].Value),fecha_corte);
        }

        private void generaParteReconexion()
        {
            DataTable drParteFalla;
            drParteFalla = oPartesFallas.GetFallasPorTipoServYOp(id_tipo_servicio, Convert.ToInt32(Partes.Partes_Operaciones.RECONEXION));

            if (drParteFalla.Rows.Count > 0)
            {
                int idParte = 0;
                oParte.Id_Usuarios = id_usuario;
                oParte.Id_Servicios = id_servicio;
                oParte.Id_Usuarios_Servicios = id_usuario_servicio;
                oParte.Id_Usuarios_Locaciones = id_locacion;
                oParte.Id_Zonas = 0;
                oParte.Id_Partes_Fallas = Convert.ToInt32(drParteFalla.Rows[0]["id"].ToString());
                oParte.Id_Partes_Soluciones = 0;
                oParte.Id_Movil = 0;
                oParte.Id_Operadores = Personal.Id_Login;
                oParte.Id_Areas = Personal.Id_Area;
                oParte.Fecha_Reclamo = Convert.ToDateTime(DateTime.Now.ToLongTimeString());
                oParte.Detalle_Solucion = "."; // txtDetalle.Text;
                oParte.Detalle_Falla = "";
                oParte.Fecha_Programado = fecha_desde;
                oParte.Id_Partes_Estados = Convert.ToInt32(Partes.Partes_Estados.PENDIENTE_DE_ASIGNACION_DE_TECNICO);
                oParte.Id_Tecnico = Personal.Id_Login;
                oParte.Id_Usuarios_Cuenta_Corriente = id_ctacte_global;
                idParte = oParte.Guardar(oParte, 1);
                //genero el historial
                oPartesHistorial.Id_Parte = idParte;
                oPartesHistorial.Id_Usuarios = id_usuario;
                oPartesHistorial.Id_Personal = Personal.Id_Login;
                oPartesHistorial.Fecha_Movimiento = DateTime.Now;
                oPartesHistorial.Id_area = Personal.Id_Area;
                oPartesHistorial.Detalles = "PARTE PASADO A REALIZADO.";
                oPartesHistorial.Id_Partes_Estados = Convert.ToInt32(Partes.Partes_Estados.PENDIENTE_DE_ASIGNACION_DE_TECNICO);
                oPartesHistorial.GuardarNuevoDetalle(oPartesHistorial);

            }
        }


        private void frmPrepagosAppExternas_Load(object sender, EventArgs e)
        {
            comenzarCarga();
        }
    }
}
