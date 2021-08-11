using CapaNegocios;
using CapaPresentacion.Busquedas;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Windows.Forms;
using System.Linq;

namespace CapaPresentacion.Partes_Trabajo
{
    public partial class frmConfirmaParte : Form
    {
        #region [PROPIEDADES]
        public enum FUNCIONALIDAD
        {
            CONFIRMAR_ANULAR = 0,
            CONFIRMAR = 1,
            ANULAR = 2,
            NINGUNA = 3
        }

        private Partes oPartes = new Partes();
        private Partes_Soluciones oSolucion = new Partes_Soluciones();
        private Usuarios_Servicios oUsuario_Servicio = new Usuarios_Servicios();
        private Servicios_Estados_Historial oServicios_Estados_Historial = new Servicios_Estados_Historial();
        private DataTable dtSolucion;
        private DataRow drPartes;
        private int IdParte;
        private string mensajeError = string.Empty;
        private Thread hilo;
        private delegate void myDel();
        private Partes_Solicitudes oParte_falla = new Partes_Solicitudes();
        private Comprobantes oComprobante = new Comprobantes();
        private Comprobantes_Tipo oComprobante_tipo = new Comprobantes_Tipo();
        private Servicios_Tarifas oServicios_tarifas = new Servicios_Tarifas();
        private Servicios_Tarifas_Sub oServicios_tarifas_sub = new Servicios_Tarifas_Sub();
        private Usuarios_CtaCte oUsuario_ctacte = new Usuarios_CtaCte();
        private Usuarios_CtaCte_Det oUsuario_ctactedet = new Usuarios_CtaCte_Det();
        private Servicios oServicio = new Servicios();
        private Equipos oEquipo = new Equipos();
        private Usuarios_Locaciones oUsuario_locacion = new Usuarios_Locaciones();
        private List<Int32> lista_estados = new List<int>();
        private DataTable dt_ServiciosLocacion = new DataTable();
        private Partes_Equipos oPartesEquipos = new Partes_Equipos();
        private DataTable dtTecnicos;
        private Agenda_Encabezado oAgenda = new Agenda_Encabezado();
        private Partes_Historial oPartesHistorial = new Partes_Historial();
        private Partes_Usuarios_Servicios oParteUsuarioServicio = new Partes_Usuarios_Servicios();
        private DataTable DtServiciosAsociados = new DataTable();
        private DataTable DtOperaciones = new DataTable();
        private Equipos_Tarjetas oEquiposTarjetas = new Equipos_Tarjetas();
        private Plasticos oPlasticos = new Plasticos();
        public DataTable dtDatosEquipo = new DataTable();
        private FUNCIONALIDAD funcionalidad;
        private DateTime fecha_programadoGlobal = new DateTime();
        DataTable dtFullDataUsuServ = new DataTable();
        #endregion

        public frmConfirmaParte(int id, FUNCIONALIDAD funcionalidad)//recibe id parte
        {
            InitializeComponent();
            IdParte = id;
            this.funcionalidad = funcionalidad;

            switch (funcionalidad)
            {
                case FUNCIONALIDAD.CONFIRMAR_ANULAR:
                    btnConfirmar.Enabled = true;
                    btnAnular.Enabled = true;
                    break;
                case FUNCIONALIDAD.CONFIRMAR:
                    btnConfirmar.Enabled = true;
                    btnAnular.Enabled = false;
                    break;
                case FUNCIONALIDAD.ANULAR:
                    btnConfirmar.Enabled = false;
                    btnAnular.Enabled = true;
                    break;
                case FUNCIONALIDAD.NINGUNA:
                    btnConfirmar.Enabled = false;
                    btnAnular.Enabled = false;
                    break;
                default:
                    btnConfirmar.Enabled = true;
                    btnAnular.Enabled = true;
                    break;
            }
        }
        
        #region [METODOS]
        private void Limpiar()
        {
            txtNumParte.Text = String.Format("0");
            lblSolicitud.Text = String.Format("Solicitud:");
            lblTipoOperacion.Text = String.Format("Tipo de operación:");
            lblFechaReclamo.Text = String.Format("Fecha de reclamo:");
            lblFechaProgramacion.Text = String.Format("Programado para:");
            lblTecnico.Text = String.Format("Técnico:");
            lblUsuario.Text = String.Format("Usuario");
            lblDomicilio.Text = String.Format("Domicilio:");
            lblEntreCalles.Text = String.Format("Entre las calles:");
            lblLocalidad.Text = String.Format("Localidad:");
            lblTelefono.Text = String.Format("Teléfono:");
            dpFechaConfirmacion.Value = DateTime.Now;
            txtDetalleSolucion.Text = String.Format("");
            drPartes = null;
        }

        private void comenzarCarga()
        {
            hilo = new Thread(new ThreadStart(cargarDatos));
            hilo.Start();
        }

        private void cargarDatos()
        {
            try
            {
                if (IdParte > 0)
                {
                    drPartes = oPartes.TraerParteRow(IdParte);
                    if (drPartes != null)
                    {
                        dtTecnicos = oAgenda.Buscar_tecnico();
                        dtSolucion = oSolucion.Listar();
                        DtOperaciones = oPartes.ListarOperaciones();
                        DtServiciosAsociados = oParteUsuarioServicio.ListarServiciosPorParte(IdParte, Partes_Usuarios_Servicios.CONDICION_REQ_EQUIPOS.TODOS);
                    }
                    else
                        MessageBox.Show("No se ha encontrado el parte.");
                }
                myDel MD = new myDel(asignarDatos);
                this.Invoke(MD, new object[] { });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar Informacion" + ex.Message);
            }
        }

        private void asignarDatos()
        {
            if (drPartes != null && Convert.ToInt32(drPartes["id"]) > 0)
            {
                if (Convert.ToInt32(drPartes["id_partes_estados"]) == Convert.ToInt32(Partes.Partes_Estados.ASIGNADO) || Convert.ToInt32(drPartes["id_partes_estados"]) == Convert.ToInt32(Partes.Partes_Estados.PENDIENTE_DE_ASIGNACION_DE_TECNICO))
                {
                    fecha_programadoGlobal = Convert.ToDateTime(drPartes["fecha_programado"]);
                    txtNumParte.Text = drPartes["id"].ToString();
                    lblSolicitud.Text = String.Format("Solicitud: {0}", drPartes["solicitud"].ToString());
                    lblTipoOperacion.Text = String.Format("Tipo de operación: {0}", drPartes["operacion"].ToString());
                    lblFechaReclamo.Text = String.Format("Fecha de reclamo: {0}", drPartes["fecha_reclamo"].ToString());
                    lblFechaProgramacion.Text = String.Format("Programado para: {0}", drPartes["fecha_programado"].ToString());
                    lblTecnico.Text = String.Format("Técnico: {0}", drPartes["tecnico"].ToString());
                    lblUsuario.Text = String.Format("Usuario: {0} {1}", drPartes["apellido"].ToString(), drPartes["nombre"].ToString());
                    lblDomicilio.Text = String.Format("Domicilio: {0} {1}, Piso: {2}, Depto.:{3}", drPartes["calle"].ToString(), drPartes["altura"].ToString(), drPartes["piso"].ToString(), drPartes["depto"].ToString());
                    lblEntreCalles.Text = String.Format("Entre las calles: {0} y {1}", drPartes["entre_calle_1"].ToString(), drPartes["entre_calle_2"].ToString());
                    lblLocalidad.Text = String.Format("Localidad: {0}", drPartes["localidad"].ToString());
                    lblTelefono.Text = String.Format("Teléfono: {0}", drPartes["telefono_1"].ToString());
                    dgvServiciosAsociados.DataSource = DtServiciosAsociados;
                    for (int x = 0; x < dgvServiciosAsociados.Columns.Count; x++)
                        dgvServiciosAsociados.Columns[x].Visible = false;

                    dgvServiciosAsociados.Columns["servicio"].Visible = true;
                    dgvServiciosAsociados.Columns["tiposervicio"].Visible = true;
                    dgvServiciosAsociados.Columns["servicio"].HeaderText = "Servicio";
                    dgvServiciosAsociados.Columns["tiposervicio"].HeaderText = "Tipo de servicio";

                    dtSolucion.DefaultView.RowFilter = string.Format("id_falla=" + Convert.ToInt32(drPartes["id_partes_fallas"]) + "");
                    cboSolucion.DataSource = dtSolucion;
                    cboSolucion.DisplayMember = "nombre";
                    cboSolucion.ValueMember = "id";
                    if (dtSolucion.Rows.Count > 0)
                        cboSolucion.SelectedValue = Convert.ToInt32(dtSolucion.Rows[0]["id"]);

                    if (Convert.ToInt32(drPartes["requiere_tecnico"]) == 1) //1 requiere tecnico - 0 no requiere tecnico
                    {
                        cboTecnicos.DataSource = dtTecnicos;
                        cboTecnicos.DisplayMember = "nombre";
                        cboTecnicos.ValueMember = "id";
                        cboTecnicos.SelectedValue = Convert.ToInt32(drPartes["id_tecnicos"]);
                    }
                    else
                    {
                        cboTecnicos.Enabled = false;
                    }

                    cboProblema.DataSource = Enum.GetValues(typeof(Partes.TipoProblemas));
                    txtNumParte.Enabled = false;
                }
                else
                {
                    SetearControles();
                    MessageBox.Show("El parte no puede confirmarse. Puede que ya haya sido confirmado o se encuentre pendiente de alguna asignación.");
                }
            }
            else
            {
                SetearControles();
                txtNumParte.Enabled = true;
            }
            txtNumParte.Focus();
            if (DtServiciosAsociados.Rows.Count > 0)
                SetearInfoUsuario();

        }
        private void SetearInfoUsuario()
        {
            dtFullDataUsuServ = oUsuario_Servicio.getFullDataUserServ(Convert.ToInt32(DtServiciosAsociados.Rows[0]["id_usuarios"]));
        }

        private void BuscarParte()
        {
            try
            {
                lista_estados.Add(Convert.ToInt32(Partes.Partes_Estados.ASIGNADO));

                frmBusquedaPartes frmBuscarParte = new frmBusquedaPartes();
                frmBuscarParte.AsignarListaEstados(lista_estados);
                frmPopUp frmpopup = new frmPopUp();
                frmpopup.Formulario = frmBuscarParte;
                frmpopup.Maximizar = false;

                frmpopup.ShowDialog();

                if (frmpopup.DialogResult == DialogResult.OK)
                {
                    IdParte = frmBuscarParte.id_parte_seleccionado;

                    comenzarCarga();

                    dpFechaConfirmacion.Focus();

                }

            }
            catch (Exception)
            {
                Limpiar();

            }
        }

        private void SetearControles()
        {
            drPartes = null;
            txtNumParte.Enabled = true;
            txtNumParte.Focus();
        }

        private void AsignarEquipos(DataRow drParte, int id_operacion)
        {
            try
            {
                DataTable dtEquiposPorActivar = oPartesEquipos.ListarPorParte(Convert.ToInt32(drPartes["id"]));
                DataTable dtUse = new DataTable();//usuario serviicio equipo
                if (dtEquiposPorActivar.Rows.Count > 0)
                {

                    if (id_operacion == Convert.ToInt32(Partes.Partes_Operaciones.CAMBIO_DE_EQUIPO))
                    {
                        foreach (DataRow EquipoActivar in dtEquiposPorActivar.Rows)
                        {
                            oEquipo.PasarEquipoReparacion(Convert.ToInt32(EquipoActivar["id_equipo_anterior"]), Convert.ToInt32(EquipoActivar["id_usuarios_servicios"]));
                            dtUse = oEquipo.ListarDatosUsuariosServiciosEquipos(Convert.ToInt32(EquipoActivar["id_usuarios_servicios"]), Convert.ToInt32(EquipoActivar["id_equipo_anterior"]));
                            if (dtUse.Rows.Count > 0)
                                oEquipo.BajaUsuarioServicioEquipo(Convert.ToInt32(dtUse.Rows[0]["id"]));
                            if (Convert.ToInt32(EquipoActivar["id_tarjeta_anterior"]) > 0)
                            {
                                oEquiposTarjetas.QuitarTarjetaEquipo(Convert.ToInt32(EquipoActivar["id_equipo_anterior"]));
                                if (Convert.ToInt32(EquipoActivar["id_tarjeta"]) != Convert.ToInt32(EquipoActivar["id_tarjeta_anterior"]))
                                    oEquiposTarjetas.CambiarEstadoTarjeta(Convert.ToInt32(EquipoActivar["id_tarjeta_anterior"]), Convert.ToInt32(Equipos_Tarjetas.Tarjetas_Estados.CON_FALLA));
                                else
                                    oEquiposTarjetas.AsignarTarjetaEquipo(Convert.ToInt32(EquipoActivar["id_equipos"]), Convert.ToInt32(EquipoActivar["id_tarjeta"]));
                            }

                            if (Convert.ToInt32(EquipoActivar["id_parte_equipo_anterior"]) > 0)
                                oPartesEquipos.Eliminar(Convert.ToInt32(EquipoActivar["id_parte_equipo_anterior"]));

                            //si ya esta asignado a usuario no lo vuelvo a cambiarle el estado 
                            DataTable dtDatosEquipo = new DataTable();
                            dtDatosEquipo = oEquipo.BuscarDatosEquipo(Convert.ToInt32(EquipoActivar["id_equipos"]));
                            string salida;
                            if (dtDatosEquipo.Rows.Count > 0)
                            {
                                if (Convert.ToInt32(dtDatosEquipo.Rows[0]["id_equipos_Estados"]) != (int)Equipos.Equipos_Estados.ASIGNADO_A_USUARIO)
                                    oEquipo.CambiarEstado(Convert.ToInt32(EquipoActivar["id_equipos"]), Convert.ToInt32(Equipos.Equipos_Estados.ASIGNADO_A_USUARIO), out salida);

                            }
                        }
                    }
                    else
                    {
                        string salida;
                        foreach (DataRow EquipoActivar in dtEquiposPorActivar.Rows)
                        {
                            oPartesEquipos.ActivarRegistroParteEquipo(Convert.ToInt32(EquipoActivar["id"]), out salida);
                            dtDatosEquipo = oEquipo.BuscarDatosEquipo(Convert.ToInt32(EquipoActivar["id_equipos"]));
                            if (dtDatosEquipo.Rows.Count > 0)
                            {
                                if (Convert.ToInt32(dtDatosEquipo.Rows[0]["id_equipos_Estados"]) != (int)Equipos.Equipos_Estados.ASIGNADO_A_USUARIO)
                                    oEquipo.CambiarEstado(Convert.ToInt32(EquipoActivar["id_equipos"]), Convert.ToInt32(Equipos.Equipos_Estados.ASIGNADO_A_USUARIO), out salida);
                            }

                        }
                    }
                }
            }
            catch (Exception c)
            {
                MessageBox.Show("Faltan algunos datos en los registros de equipos." + c.Message);
            }


        }

        #endregion

        #region [EVENTOS]
        private void frmConfirmaParte_Load(object sender, EventArgs e)
        {
            this.ActiveControl = txtNumParte;
            dpFechaConfirmacion.Format = DateTimePickerFormat.Custom;
            dpFechaConfirmacion.CustomFormat = "dd/MM/yyyy hh:mm:ss tt";
            Limpiar();
            comenzarCarga();
        }

        private void frmConfirmaParte_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void txtNumParte_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (String.IsNullOrEmpty(txtNumParte.Text) == false)
                {
                    IdParte = Convert.ToInt32(txtNumParte.Text);
                    comenzarCarga();
                }
                else
                    MessageBox.Show("Hay datos en blanco.");
            }

            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void txtDetalleSolucion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnConfirmar.Focus();
        }

        private void dpFecha_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                cboProblema.Focus();
        }

        private void cbSolucion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtDetalleSolucion.Focus();
        }

        private void cbProblema_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                cboSolucion.Focus();
        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            BuscarParte();
        }

        private void btnAnular_Click(object sender, EventArgs e)
        {
            if (drPartes != null && Convert.ToInt32(drPartes["id"]) > 0)
            {
                if (MessageBox.Show("¿Desea anular el Parte?", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    oPartes.AnularParte(Convert.ToInt32(drPartes["id"]));

                    oPartesHistorial.Id_Parte = Convert.ToInt32(drPartes["id"]);
                    oPartesHistorial.Id_Usuarios = Convert.ToInt32(drPartes["Id_usuarios"]);
                    oPartesHistorial.Id_Personal = Personal.Id_Login;
                    oPartesHistorial.Fecha_Movimiento = DateTime.Now;
                    oPartesHistorial.Id_area = Personal.Id_Area;
                    oPartesHistorial.Detalles = "PARTE ANULADO.";
                    oPartesHistorial.Id_Partes_Estados = Convert.ToInt32(Partes.Partes_Estados.ANULADO);
                    oPartesHistorial.GuardarNuevoDetalle(oPartesHistorial);
                    //oPartes.ActualizarAreaPersonal(IdParte, Personal.Id_Area,Personal.Id_Login);


                    SetearControles();

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            else
                MessageBox.Show("No se ha seleccionado un parte para anular.");
        }

        private void btnConfirmar_Click_1(object sender, EventArgs e)
        {
            if (drPartes == null)
                return;

            if (dpFechaConfirmacion.Value.Date < Convert.ToDateTime(drPartes["fecha_reclamo"]).Date)
            {
                MessageBox.Show("La fecha de confirmacion del parte no puede ser menor a la fecha del reclamo", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            if (dpFechaConfirmacion.Value.Date < Convert.ToDateTime(drPartes["fecha_programado"]).Date)
            {
                MessageBox.Show("La fecha de confirmacion del parte no puede ser menor a la fecha de programado", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            DataTable dtPartesEquipos = new Partes_Equipos().ListarPorParte(IdParte);
            if (dtPartesEquipos.Rows.Count > 0 &&
                Convert.ToInt32(dtPartesEquipos.Rows[0]["id_equipos"]) == 0)
            {
                MessageBox.Show("Antes de confirmar el parte es necesario asignar el equipo", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int idSolucion = Convert.ToInt32(cboSolucion.SelectedValue);
            int idTecnico = Convert.ToInt32(cboTecnicos.SelectedValue);
            string detalleSolucion = txtDetalleSolucion.Text;
            int tipoSalida = 0;
            string salida = "";
            Partes.TipoProblemas problema;
            Enum.TryParse<Partes.TipoProblemas>(cboProblema.SelectedValue.ToString(), out problema);
            if (Convert.ToInt32(drPartes["requiere_tecnico"]) == 1) //1 requiere tecnico - 0 no requiere tecnico
            {
                int Condicion = Convert.ToInt32(cboTecnicos.SelectedValue);

                if (Condicion != 0)
                {
                    if (oPartes.ConfirmarParte(IdParte, idSolucion, cboProblema.Text, dpFechaConfirmacion.Value, problema, detalleSolucion, idTecnico, out tipoSalida, out salida) == true) 
                    {
                        bool contieneAppExternaCass = false;
                        bool contieneAppExternaIsp = false;
                        string resultadoFinalOperaciones = "";
                        string resultadoFinalOperacionesAcciones = "";
                        foreach(DataRow drServicio in DtServiciosAsociados.Rows)
                        {
                            if(Convert.ToInt32(drServicio["id_app_ext"]) == (int)Aplicaciones_Externas.Aplicacion_Externa.CASS)
                            {
                                contieneAppExternaCass = true;
                                break;
                            }
                        }

                        foreach (DataRow drServicio in DtServiciosAsociados.Rows)
                        {
                            if (Convert.ToInt32(drServicio["id_app_ext"]) == (int)Aplicaciones_Externas.Aplicacion_Externa.ISP)
                            {
                                contieneAppExternaIsp = true;
                                break;
                            }
                        }

                        List<int> idPartes = new List<int>();
                        idPartes.Add(IdParte);

                        if (contieneAppExternaCass == true || contieneAppExternaIsp == true) 
                        {
                            // oPartes.gestionarAppExternasLista(idPartes, out resultadoFinalOperaciones);
                            oPartes.gestionarAppExternaIdParte(IdParte, out resultadoFinalOperaciones, out resultadoFinalOperacionesAcciones, fecha_programadoGlobal);
                        }

                        if (MessageBox.Show($"{resultadoFinalOperaciones} \nParte confirmado Correctamente. ¿Desea seguir confirmando partes?","Mensaje del Sistema",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.No)
                            this.DialogResult = DialogResult.OK;
                        else
                        {
                            IdParte = 0;
                            this.ActiveControl = txtNumParte;
                            dpFechaConfirmacion.Format = DateTimePickerFormat.Custom;
                            dpFechaConfirmacion.CustomFormat = "dd/MM/yyyy hh:mm:ss tt";
                            Limpiar();
                            comenzarCarga();
                        }
                    }
                    else
                        MessageBox.Show(salida, "Mensaje del Sistema",MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    MessageBox.Show("Debe seleccionar un tecnico.");
                }
            }
            else
            {

                if (oPartes.ConfirmarParte(IdParte, idSolucion, cboProblema.Text, dpFechaConfirmacion.Value, Partes.TipoProblemas.DE_LA_EMPRESA, detalleSolucion, idTecnico, out tipoSalida, out salida) == true)
                {
                    MessageBox.Show("Parte confirmado correctamente", "Mensaje del Sistema");
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show(salida, "Mensaje del Sistema");

                }

            }
        }


        private void boton1_Click(object sender, EventArgs e)
        {
            if (dpFechaConfirmacion.Value.Date < Convert.ToDateTime(drPartes["fecha_reclamo"]).Date)
            {
                MessageBox.Show("La fecha de confirmacion del parte no puede ser menor a la fecha del reclamo", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            int idSolucion = Convert.ToInt32(cboSolucion.SelectedValue);
            int idTecnico = Convert.ToInt32(cboTecnicos.SelectedValue);
            string detalleSolucion = txtDetalleSolucion.Text;
            int tipoSalida = 0;
            string salida = "";
            Partes.TipoProblemas problema;
            Enum.TryParse<Partes.TipoProblemas>(cboProblema.SelectedValue.ToString(), out problema);
            if (Convert.ToInt32(drPartes["requiere_tecnico"]) == 1) //1 requiere tecnico - 0 no requiere tecnico
            {
                int Condicion = Convert.ToInt32(cboTecnicos.SelectedValue);
              
                if (Condicion != 0)
                {
                    if (oPartes.ConfirmarParte(IdParte, idSolucion, cboProblema.Text, dpFechaConfirmacion.Value, problema, detalleSolucion, idTecnico, out tipoSalida, out salida) == true)
                    {
                        MessageBox.Show("Parte confirmado correctamente", "Mensaje del Sistema");
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        MessageBox.Show(salida, "Mensaje del Sistema");

                    }
                }
                else
                {
                    MessageBox.Show("Debe seleccionar un tecnico.");
                }
            }
            else
            {
               
                if(oPartes.ConfirmarParte(IdParte,idSolucion,cboProblema.Text,dpFechaConfirmacion.Value,Partes.TipoProblemas.DE_LA_EMPRESA, detalleSolucion, idTecnico,out tipoSalida, out salida) == true)
                {
                    MessageBox.Show("Parte confirmado correctamente", "Mensaje del Sistema");
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show(salida, "Mensaje del Sistema");

                }

            }
        }
        #endregion
    }
}//301019fede
