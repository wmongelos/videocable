using CapaNegocios;
using CapaPresentacion.Busquedas;
using CapaPresentacion.Impresiones;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Windows.Forms;


namespace CapaPresentacion.Partes_Trabajo
{
    public partial class frmGenerarParte : Form
    {
        private Usuarios_Servicios oUsuariosServicios = new Usuarios_Servicios();
        private Usuarios oUsuarios = new Usuarios();
        private Partes oPartes = new Partes();
        private Partes_Solicitudes oParte_falla = new Partes_Solicitudes();
        private Thread hilo;
        private delegate void myDel();
        private DataTable dtServiciosActivos = new DataTable();
        private int idUsuario;
        private int idLocacion;
        private int id_Ser_tipo;
        private string fecha = DateTime.Now.ToString("G");
        private dsInformes oDs = new dsInformes();
        private Servicios oServicios = new Servicios();
        private Configuracion oConfig = new Configuracion();
        private Usuarios_Locaciones oUsuLoc = new Usuarios_Locaciones();
        private DataTable dtFallas = new DataTable();
        private DataTable dtLocaciones = new DataTable();
        public DataRow drUsuario_actual;
        private Partes_Equipos oPartesEquipos = new Partes_Equipos();
        private int IdTipoFacturacion;
        private decimal ImporteSolicitud = 0;
        private int IdTarifaActual;
        private int IdServicioSeleccionado;
        private int IdUsuarioServicioSeleccionado;
        private Comprobantes oComprobante = new Comprobantes();
        private Comprobantes_Tipo oComprobante_tipo = new Comprobantes_Tipo();
        private Servicios_Tarifas oServicios_tarifas = new Servicios_Tarifas();
        private Servicios_Tarifas_Sub oServiciosTarifasSub = new Servicios_Tarifas_Sub();
        private Usuarios_CtaCte oUsuario_ctacte = new Usuarios_CtaCte();
        private Usuarios_CtaCte_Det oUsuario_ctactedet = new Usuarios_CtaCte_Det();
        List<Int32> lista_id_partes = new List<Int32>();
        int config_agenda;
        public DataTable dtEquiposACambiar = new DataTable();
        Partes_Historial oPartesHistorial = new Partes_Historial();
        Equipos oEquipo = new Equipos();
        DataTable dtusuarios = new DataTable();
        Impresion oImpresion = new Impresion();
        private Servicios_Estados_Historial oServiciosEstadosHistorial = new Servicios_Estados_Historial();
        string Con_Cargo;
        DataRow drDatosComprobanteVenta = null;
        DataRow DrServicioSeleccionado = null;
        string requiere_equipo;
        int id_partes_operaciones;
        int Num_Comprobante = 0;
        frmAgenda frmAgen = frmAgenda.GetInstancia();
        DataTable DtPartesEquipos = new DataTable();
        DataTable DtEquipoCosto = new DataTable();
        List<decimal> ListaImportesComprobantesDet = new List<decimal>();
        private DataTable DtImportesCtaCteDet = new DataTable();
        private int usuarioServcioSeleccionado, idPartesOperacion, idTipoFacturacion;
        private GPS oGps = new GPS();
        private DataView dtvUsuariosServicios;

        private void comenzarCarga()
        {
            pgCircular.Start();

            hilo = new Thread(new ThreadStart(cargarDatos));
            hilo.IsBackground = true;
            hilo.Start();
        }

        /// <summary>
        /// cargarDatos() traer servicios del usuario y la locacion recibidas
        /// </summary>
        private void cargarDatos()
        {
            if (oUsuLoc.GetLocacion(idLocacion).Activo == Convert.ToInt32(Usuarios_Locaciones.Locacion_Estados.ACTIVA))
            {
                oUsuarios.Codigo = 0;
                oUsuarios.Usuario = "";
                oUsuarios.Calle = "";
                oUsuarios.Altura = 0;
                oUsuarios.Apellido = "";
                oUsuarios.Nombre = "";
                oUsuarios.Depto = "";
                oUsuarios.CUIT = 0;
                oUsuarios.Numero_Documento = 0;
                // dtusuarios = oUsuarios.getDatos_ultimo();
                dtusuarios = oUsuarios.Listar(idUsuario);

                //dtServiciosActivos = oUsuariosServicios.Listar(idUsuario, idLocacion);


                dtServiciosActivos = oUsuariosServicios.Listar_Servicios_Activos(idLocacion, 1);//el segundo parámetro indica si va a listar todos los servicios o no. Por default no los lista. Si va en 1 los lista.

                config_agenda = oConfig.GetValor_N("Agenda_Trabajo");
                myDel MD = new myDel(asignarDatos);
                this.Invoke(MD, new object[] { });
            }
            else
                MessageBox.Show("La locación seleccionada no se encuentra activa.");
            pgCircular.Stop();
        }

        /// <summary>
        /// asignarDatos() setear datos del servicio
        /// </summary>
        private void asignarDatos()
        {
            if (dtServiciosActivos.Rows.Count > 0)
            {
                dtServiciosActivos.DefaultView.Sort = "servicio asc";

                if (dtServiciosActivos.Select(String.Format("id_servicios_estados='{0}' or id_servicios_estados='{1}'", Convert.ToInt16(Servicios.Servicios_Estados.CORTADO), Convert.ToInt16(Servicios.Servicios_Estados.RETIRADO))).Length > 0)
                    chkCortadosRetirados.Visible = true;
                else
                    chkCortadosRetirados.Visible = false;
                dtvUsuariosServicios = new DataView(dtServiciosActivos);
                dtvUsuariosServicios.RowFilter = String.Format("id_servicios_estados<>'{0}' and id_servicios_estados<>'{1}'", Convert.ToInt16(Servicios.Servicios_Estados.CORTADO), Convert.ToInt16(Servicios.Servicios_Estados.RETIRADO));
                dgvServiciosContratados.DataSource = dtvUsuariosServicios;
                FormatearGrillaServContratados();
                lblTotal.Text = String.Format("Total de Registros: {0}", dtServiciosActivos.Rows.Count);
                SetearCabeceraUsuario();

                //si ya viene un usuario servicio seleccionado lo marca en el datagridview
                if (usuarioServcioSeleccionado != 0)
                {
                    var idUsuServicio = 0;
                    var index = 0;
                    foreach (DataGridViewRow item in dgvServiciosContratados.Rows)
                    {
                        idUsuServicio = Convert.ToInt32(item.Cells["id_usuario_servicio"].Value);
                        if (idUsuServicio == usuarioServcioSeleccionado)
                            index = item.Index;
                    }
                    dgvServiciosContratados.Rows[index].Selected = true;
                    dgvServiciosContratados.Enabled = false;
                }
                CargarFallas();
                if (usuarioServcioSeleccionado != 0)
                    cbFalla.SelectedValue = Convert.ToInt32(idPartesOperacion);

                btnGenerarParte.Enabled = true;
            }
            else
            {
                MessageBox.Show("El usuario no posee servicios en la locación especificada. Asigne servicios al usuario.");
                btnGenerarParte.Enabled = false;
            }
        }

        /// <summary>
        /// SetearCabeceraUsuario() setear datos del usuario en cabecera
        /// </summary>
        /// 
        private void FormatearGrillaServContratados()
        {
            for (int x = 0; x < dgvServiciosContratados.Columns.Count; x++)
                dgvServiciosContratados.Columns[x].Visible = false;
            dgvServiciosContratados.Columns["servicio"].Visible = true;
            dgvServiciosContratados.Columns["tipo_servicio"].Visible = true;
            dgvServiciosContratados.Columns["estado"].Visible = true;
            dgvServiciosContratados.Columns["fecha_inicio"].Visible = true;

            dgvServiciosContratados.Columns["servicio"].HeaderText = "Servicio";
            dgvServiciosContratados.Columns["tipo_servicio"].HeaderText = "Tipo de servicio";
            dgvServiciosContratados.Columns["estado"].HeaderText = "Estado";
            dgvServiciosContratados.Columns["fecha_inicio"].HeaderText = "Fecha de inicio";

        }
        private void SetearCabeceraUsuario()
        {
            //DataView v1 = dtusuarios.DefaultView;
            //DataTable dt = new DataTable();
            //v1.RowFilter = string.Format("id_usuarios_locaciones = {0} ", idLocacion);
            //dt = v1.ToTable();
            drUsuario_actual = dtusuarios.Rows[0];
            LBApellido.Text = drUsuario_actual["apellido"].ToString().Trim() + " , " + (drUsuario_actual["nombre"].ToString()).ToUpperInvariant() + " [" + drUsuario_actual["codigo"].ToString() + "]";
            //LBNumero_documento.Text = "Documento : (" + drUsuario_actual["tipo_doc"].ToString() + ") Nro " + drUsuario_actual["numero_documento"].ToString();
            //lbcuit.Text = "C. Iva : (" + drUsuario_actual["condicion_iva"].ToString() + ") Nro " + drUsuario_actual["cuit"].ToString();
            //lblLocacion.Text = String.Format("Locación: {0}, {1} {2} ", drUsuario_actual["localidad"], drUsuario_actual["calle"], drUsuario_actual["altura"]);
            //lbcorreo.Text = "Mail: " + drUsuario_actual["Correo_electronico"].ToString();

        }

        private void CargarFallas()
        {
            if (dgvServiciosContratados.Rows.Count > 0)
            {
                IdUsuarioServicioSeleccionado = Convert.ToInt32(dgvServiciosContratados.SelectedRows[0].Cells["id_usuario_servicio"].Value);
                id_Ser_tipo = Convert.ToInt32(dtServiciosActivos.Select("id_usuario_servicio=" + IdUsuarioServicioSeleccionado)[0]["id_servicio_tipo"]);
                IdServicioSeleccionado = Convert.ToInt32(dtServiciosActivos.Select("id_usuario_servicio=" + IdUsuarioServicioSeleccionado)[0]["id_servicios"]);
                IdTipoFacturacion = Convert.ToInt32(dtServiciosActivos.Select("id_usuario_servicio=" + IdUsuarioServicioSeleccionado)[0]["id_tipo_facturacion"]);
                dtFallas.Clear();
                dtFallas = oParte_falla.ListarServicioTipo(id_Ser_tipo, IdTarifaActual, IdServicioSeleccionado, "P", IdTipoFacturacion);
                dtFallas.DefaultView.Sort = "falla asc";
                DataView DtvFalla = dtFallas.DefaultView;
                DtvFalla.RowFilter = "ParteTrabajo=1";

                try
                {
                    ImporteSolicitud = Convert.ToDecimal(DtvFalla[0]["importe"]);
                }
                catch { ImporteSolicitud = 0; }
                if (DtvFalla.Count > 0)
                    btnGenerarParte.Enabled = true;
                else
                    btnGenerarParte.Enabled = false;
                cbFalla.DataSource = DtvFalla.ToTable();
                cbFalla.DisplayMember = "Falla";
                cbFalla.ValueMember = "id";
            }
        }

        private void Buscar()
        {
            oUsuarios.Codigo = 0;
            oUsuarios.Usuario = "";
            oUsuarios.Calle = "";
            oUsuarios.Altura = 0;


            Int32 opcion = 0;
            if (bUsuario.Checked == true) { opcion = 1; }
            if (bNombre.Checked == true) { opcion = 2; }
            if (Bdomicilio.Checked == true) { opcion = 3; }
            if (bDocumento.Checked == true) { opcion = 4; }
            if (txtbuscaraltura.Visible == false) { txtbuscaraltura.Text = ""; }

            using (frmPopUp frmpopup = new frmPopUp())
            {
                frmBusquedaUsuarios frm = new frmBusquedaUsuarios(opcion, txtbusca.Text, txtbuscaraltura.Text);

                frmpopup.Formulario = frm;
                frmpopup.Maximizar = false;
                if (frmpopup.ShowDialog() == DialogResult.OK)
                {
                    drUsuario_actual = frm.usuario_e;
                    Usuarios.Usuario_Sel = frm.usuario_e;
                    idUsuario = Int32.Parse(drUsuario_actual["id"].ToString());
                    idLocacion = Int32.Parse(drUsuario_actual["id_usuarios_locaciones"].ToString());
                    comenzarCarga();
                }
            }
        }

        private void Limpiar()
        {
            txtId.Text = string.Empty;
        }

        public void ImprimirParte()
        {
            oImpresion.ImprimirParte(oPartes.Id);
        }

        private void GenerarParte()
        {
            LimpiarDatos();
            pgCircular.Start();
            DrServicioSeleccionado = dtServiciosActivos.Select("id_usuario_servicio=" + dgvServiciosContratados.SelectedRows[0].Cells["id_usuario_servicio"].Value)[0];
            requiere_equipo = oServicios.Listar().Select("Id=" + Convert.ToInt32(DrServicioSeleccionado["id_servicios"]) + "")[0]["Requiere_Equipo"].ToString();
            id_partes_operaciones = Convert.ToInt32(dtFallas.Select(String.Format("id={0}", cbFalla.SelectedValue))[0]["id_partes_operaciones"]);

            if (
                       (id_partes_operaciones == Convert.ToInt32(Partes.Partes_Operaciones.ASIGNACION_DE_EQUIPO))
                       ||
                       id_partes_operaciones == Convert.ToInt32(Partes.Partes_Operaciones.RECONEXION)
                       ||
                        id_partes_operaciones == Convert.ToInt32(Partes.Partes_Operaciones.PARTE_DE_TRABAJO)
                        ||
                        id_partes_operaciones == Convert.ToInt32(Partes.Partes_Operaciones.BAJA)
                        ||
                        id_partes_operaciones == Convert.ToInt32(Partes.Partes_Operaciones.CORTE)
                        ||
                        id_partes_operaciones == Convert.ToInt32(Partes.Partes_Operaciones.PARTE_INTERNO)

                     )
            {
                if (requiere_equipo == "no" && id_partes_operaciones == Convert.ToInt32(Partes.Partes_Operaciones.ASIGNACION_DE_EQUIPO))
                    MessageBox.Show("El servicio seleccionado no requiere equipo, seleccione otra solicitud.");
                else
                {

                    Con_Cargo = oParte_falla.Listar().Select("Id=" + Convert.ToInt32(cbFalla.SelectedValue) + "")[0]["Cargo"].ToString();

                    if (Con_Cargo == "si")
                    {
                        drDatosComprobanteVenta = oComprobante_tipo.GetNumeracion(Convert.ToInt32(Comprobantes_Tipo.Tipo.COMPROBANTE_DEUDA), Puntos_Cobros.Id_Punto);
                        Num_Comprobante = Convert.ToInt32(drDatosComprobanteVenta["numComprobante"]);
                        if (Num_Comprobante > 0)
                            oComprobante_tipo.SetNumeracion(Convert.ToInt32(drDatosComprobanteVenta["idPuntoVenta"]), Convert.ToInt32(Comprobantes_Tipo.Tipo.COMPROBANTE_DEUDA), Convert.ToInt32(drDatosComprobanteVenta["numComprobante"]));
                    }

                    if ((Con_Cargo == "si" && Num_Comprobante != 0) || Con_Cargo == "no")
                    {
                        oPartes.Id_Servicios = Convert.ToInt32(DrServicioSeleccionado["id_servicios"]);
                        oPartes.Id_Usuarios_Servicios = Convert.ToInt32(DrServicioSeleccionado["id_usuario_servicio"]);
                        oPartes.Id_Usuarios = Convert.ToInt32(DrServicioSeleccionado["id_usuarios"]);
                        oPartes.Id_Usuarios_Locaciones = Convert.ToInt32(DrServicioSeleccionado["id_usuarios_locaciones"]);
                        oPartes.Id_Zonas = Convert.ToInt32(DrServicioSeleccionado["id_tipo_facturacion"]);
                        oPartes.Id_Partes_Fallas = Convert.ToInt32(cbFalla.SelectedValue);
                        oPartes.Id_Partes_Soluciones = 0;
                        int configAgenda = oConfig.GetValor_N("Agenda_Trabajo");
                        if (configAgenda == Convert.ToInt32(Agenda_Encabezado.Uso_agenda.TRABAJA_CON_AGENDA))
                        {
                            if (id_partes_operaciones == Convert.ToInt32(Partes.Partes_Operaciones.CORTE) && Convert.ToInt32(DrServicioSeleccionado["CorteAutomatico"]) == Convert.ToInt32(Servicios._CorteAutomatico.SI))
                            {
                                oPartes.Id_Partes_Estados = Convert.ToInt32(Partes.Partes_Estados.REALIZADO);
                                oPartes.Id_Tecnico = Personal.Id_Login;
                                oPartes.Fecha_Realizado = DateTime.Now;
                            }
                            else
                            {
                                oPartes.Id_Tecnico = 0;
                                oPartes.Id_Partes_Estados = Convert.ToInt32(Partes.Partes_Estados.PENDIENTE_DE_ASIGNACION_DE_TECNICO);
                            }
                        }
                        else
                        {
                            oPartes.Id_Tecnico = 0;
                            oPartes.Id_Partes_Estados = Convert.ToInt32(Partes.Partes_Estados.PENDIENTE_DE_ASIGNACION_DE_TECNICO);
                        }

                        oPartes.Id_Movil = 0;
                        oPartes.Id_Operadores = Personal.Id_Login;
                        oPartes.Id_Areas = Personal.Id_Area;
                        oPartes.Fecha_Programado = DateTime.Now.Date;
                        oPartes.Fecha_Reclamo = Convert.ToDateTime(dpFecha.Value);
                        oPartes.Detalle_Falla = txtDetalle.Text;
                        oPartes.Detalle_Solucion = "";
                        oPartes.Id_Usuarios_Cuenta_Corriente = 0;
                        oPartes.Id = oPartes.Guardar(oPartes, 1);
                        if (id_partes_operaciones == (int)Partes.Partes_Operaciones.RECONEXION && (configAgenda != Convert.ToInt32(Agenda_Encabezado.Uso_agenda.TRABAJA_CON_AGENDA)))
                        {
                            oGps.EnviarParte(oPartes.Id);
                        }
                        if (id_partes_operaciones == Convert.ToInt32(Partes.Partes_Operaciones.ASIGNACION_DE_EQUIPO))
                        {
                            frmAsignacionEquipos frmAsignacionEquipos = new frmAsignacionEquipos(oPartes.Id, frmAsignacionEquipos.TIPO_LLAMADA_FORM.SHOW_DIALOG);
                            frmPopUp frmpopup = new frmPopUp();
                            frmpopup.Maximizar = false;
                            frmpopup.Formulario = frmAsignacionEquipos;
                            frmpopup.ShowDialog();
                            if (frmAsignacionEquipos.DialogResult == DialogResult.OK)
                                DtPartesEquipos = oPartesEquipos.ListarPorParte(oPartes.Id);
                        }

                        if (
                            (id_partes_operaciones == Convert.ToInt32(Partes.Partes_Operaciones.ASIGNACION_DE_EQUIPO) && DtPartesEquipos.Rows.Count > 0)
                            ||
                            id_partes_operaciones == Convert.ToInt32(Partes.Partes_Operaciones.RECONEXION)
                            ||
                             id_partes_operaciones == Convert.ToInt32(Partes.Partes_Operaciones.PARTE_DE_TRABAJO)
                             ||
                             id_partes_operaciones == Convert.ToInt32(Partes.Partes_Operaciones.BAJA)
                             ||
                             id_partes_operaciones == Convert.ToInt32(Partes.Partes_Operaciones.CORTE)
                             ||
                             id_partes_operaciones == Convert.ToInt32(Partes.Partes_Operaciones.PARTE_INTERNO)

                          )
                        {
                            if (Con_Cargo == "si")
                            {
                                oComprobante.Id_Usuarios = Convert.ToInt32(oPartes.Id_Usuarios);
                                oComprobante.Fecha = DateTime.Today;
                                oComprobante.Punto_Venta = Convert.ToInt32(drDatosComprobanteVenta["numPuntoVenta"]);
                                oComprobante.Id_Comprobantes_Tipo = Convert.ToInt32(Comprobantes_Tipo.Tipo.COMPROBANTE_DEUDA);
                                oComprobante.Numero = Convert.ToInt32(drDatosComprobanteVenta["numComprobante"]);

                                DtImportesCtaCteDet.Rows.Add(ImporteSolicitud, "P");
                                if (id_partes_operaciones == Convert.ToInt32(Partes.Partes_Operaciones.ASIGNACION_DE_EQUIPO))
                                {
                                    DtEquipoCosto = oServiciosTarifasSub.ObtienePrecio(IdTarifaActual, IdTipoFacturacion, oPartes.Id_Servicios, Convert.ToInt32(DtPartesEquipos.Rows[0]["id_equipos_tipos"]), 0, 0, "E");
                                    if (DtEquipoCosto.Rows.Count > 0)
                                    {
                                        for (int x = 0; x < DtPartesEquipos.Rows.Count; x++)
                                            DtImportesCtaCteDet.Rows.Add(Convert.ToDecimal(DtEquipoCosto.Rows[0]["importe"]), "E");
                                    }

                                }

                                foreach (DataRow Importe in DtImportesCtaCteDet.Rows)
                                    oComprobante.Importe += Convert.ToDecimal(Importe["importe"]);

                                lblCosto.Text = String.Format("Costo: ${0}", oComprobante.Importe.ToString());
                                if (oComprobante.Importe > 0)
                                {
                                    oComprobante.Id_Usuarios_Locaciones = Convert.ToInt32(oPartes.Id_Usuarios_Locaciones);
                                    oComprobante.Id = oComprobante.Guardar(oComprobante);
                                    oUsuario_ctacte.Id_Usuarios = oPartes.Id_Usuarios;
                                    oUsuario_ctacte.Id_Comprobantes = oComprobante.Id;
                                    oUsuario_ctacte.Fecha_Movimiento = DateTime.Today;
                                    oUsuario_ctacte.Fecha_Desde = DateTime.Today;
                                    oUsuario_ctacte.Fecha_Hasta = DateTime.Today;
                                    string muestra;
                                    char pad = '0';
                                    muestra = "COMPROBANTE DE DEUDA " + Convert.ToInt32(drDatosComprobanteVenta["numPuntoVenta"]).ToString().PadLeft(4, pad) + "-" + oUsuario_ctacte.Id_Comprobantes.ToString().PadLeft(8, pad);
                                    oUsuario_ctacte.Descripcion = muestra;
                                    oUsuario_ctacte.Importe_Original = oComprobante.Importe;
                                    oUsuario_ctacte.Importe_Punitorio = 0;
                                    oUsuario_ctacte.Importe_Bonificacion = 0;

                                    oUsuario_ctacte.Importe_Final = oComprobante.Importe;
                                    oUsuario_ctacte.Importe_Saldo = oComprobante.Importe;
                                    oUsuario_ctacte.Id_Usuarios_Locacion = oPartes.Id_Usuarios_Locaciones;
                                    oUsuario_ctacte.Numero = oComprobante.Numero.ToString();
                                    oUsuario_ctacte.Id_Comprobantes_Tipo = Convert.ToInt32(Comprobantes_Tipo.Tipo.COMPROBANTE_DEUDA);
                                    oUsuario_ctacte.Id_Comprobantes_Ref = 0;
                                    oUsuario_ctacte.Id_Facturacion = 0;
                                    oUsuario_ctacte.Generado_facturacion_mensual = Convert.ToInt32(Usuarios_CtaCte.GENERADO_FACTURACION_MENSUAL.NO);
                                    oUsuario_ctacte.Id_Personal = Personal.Id_Login;
                                    oUsuario_ctacte.Id_Origen = (int)Usuarios_CtaCte.ORIGEN.OTROS;
                                    oUsuario_ctacte.Guardar(oUsuario_ctacte);

                                    foreach (DataRow importe in DtImportesCtaCteDet.Rows)
                                    {
                                        oUsuario_ctactedet.Id_Usuarios_CtaCte = oUsuario_ctacte.Id;
                                        oUsuario_ctactedet.Id_Usuarios_Locaciones = oPartes.Id_Usuarios_Locaciones;
                                        oUsuario_ctactedet.Id_Zonas = oPartes.Id_Zonas;
                                        oUsuario_ctactedet.Id_Servicios = oPartes.Id_Servicios;
                                        oUsuario_ctactedet.Id_Tipo = oPartes.Id_Partes_Fallas;
                                        oUsuario_ctactedet.Tipo = importe["tiposub"].ToString();
                                        oUsuario_ctactedet.Importe_Original = Convert.ToDecimal(importe["importe"]);
                                        oUsuario_ctactedet.Importe_Saldo = oUsuario_ctactedet.Importe_Original;
                                        oUsuario_ctactedet.Importe_Final = oUsuario_ctactedet.Importe_Original;
                                        oUsuario_ctactedet.Id_Usuarios_Servicios = oPartes.Id_Usuarios_Servicios;
                                        oUsuario_ctactedet.Fecha_Desde = DateTime.Today;
                                        oUsuario_ctactedet.Fecha_Hasta = DateTime.Today;
                                        oUsuario_ctactedet.Id_Velocidades = 0;
                                        oUsuario_ctactedet.Id_Velocidades_Tip = 0;
                                        oUsuario_ctactedet.Requiere_IP = 0;
                                        oUsuario_ctactedet.Cantidad_Periodos = 1;
                                        oUsuario_ctactedet.Id_bonificacion_Aplicada = 0;
                                        oUsuario_ctactedet.Nombre_Bonificacion = String.Empty;
                                        oUsuario_ctactedet.Periodo_Ano = oUsuario_ctactedet.Fecha_Desde.Year;
                                        oUsuario_ctactedet.Periodo_Mes = oUsuario_ctactedet.Fecha_Desde.Month;
                                        oUsuario_ctactedet.Porcentaje_Bonificacion = 0;
                                        oUsuario_ctactedet.Guardar(oUsuario_ctactedet);
                                    }
                                }
                            }


                            MessageBox.Show("Parte Generado! ");

                            if (id_partes_operaciones != Convert.ToInt32(Partes.Partes_Operaciones.CORTE) || Convert.ToInt32(DrServicioSeleccionado["CorteAutomatico"]) == Convert.ToInt32(Servicios._CorteAutomatico.NO))
                                oPartes.Id_Partes_Estados = oPartes.SetearEstadoParte(oPartes.Id, 0, 0, DateTime.Now, 0, 0, "");

                            if (config_agenda == Convert.ToInt32(Agenda_Encabezado.Uso_agenda.TRABAJA_CON_AGENDA))
                            {
                                if (id_partes_operaciones == Convert.ToInt32(Partes.Partes_Operaciones.CORTE) && Convert.ToInt32(DrServicioSeleccionado["CorteAutomatico"]) == Convert.ToInt32(Servicios._CorteAutomatico.SI))
                                {
                                    oUsuariosServicios.ActualizarEstado(Convert.ToInt32(DrServicioSeleccionado["id_usuario_servicio"].ToString()), Convert.ToInt32(Servicios.Servicios_Estados.CORTADO));
                                    oServiciosEstadosHistorial.id_servicios_estados = Convert.ToInt32(Servicios.Servicios_Estados.CORTADO);
                                    oServiciosEstadosHistorial.id_servicios = Convert.ToInt32(DrServicioSeleccionado["id_servicios"]);
                                    oServiciosEstadosHistorial.id_usuarios = Convert.ToInt32(DrServicioSeleccionado["id_usuarios"]);
                                    oServiciosEstadosHistorial.id_usuarios_servicios = Convert.ToInt32(DrServicioSeleccionado["id_usuario_servicio"]);
                                    oServiciosEstadosHistorial.fecha = DateTime.Now;
                                    oServiciosEstadosHistorial.Guardar(oServiciosEstadosHistorial);
                                }
                            }

                            oPartesHistorial.Id_Parte = oPartes.Id;
                            oPartesHistorial.Id_Usuarios = oPartes.Id_Usuarios;
                            oPartesHistorial.Id_Personal = Personal.Id_Login;
                            oPartesHistorial.Fecha_Movimiento = DateTime.Now;
                            oPartesHistorial.Id_area = Personal.Id_Area;
                            oPartesHistorial.Id_Partes_Estados = oPartes.Id_Partes_Estados;
                            oPartesHistorial.Detalles = cbFalla.Text;
                            oPartesHistorial.GuardarNuevoDetalle(oPartesHistorial);

                            if (config_agenda == Convert.ToInt32(Agenda_Encabezado.Uso_agenda.TRABAJA_CON_AGENDA))
                            {
                                if (id_partes_operaciones != Convert.ToInt32(Partes.Partes_Operaciones.CORTE) || Convert.ToInt32(DrServicioSeleccionado["CorteAutomatico"]) == Convert.ToInt32(Servicios._CorteAutomatico.NO))
                                {
                                    lista_id_partes.Add(oPartes.Id);
                                    frmAgen = frmAgenda.GetInstancia();
                                    frmAgen.Id_recibido(lista_id_partes);
                                    frmAgen.Mostrar();
                                }
                            }
                            else
                            {
                                GPS oGps = new GPS();
                                oGps.EnviarParte(oPartes.Id);

                                DialogResult dialogResult = MessageBox.Show("¿Desea imprimir el parte generado?", "", MessageBoxButtons.YesNo);
                                if (dialogResult == DialogResult.Yes)
                                    ImprimirParte();


                            }

                        }
                        else
                        {
                            oPartes.Id_Partes_Estados = Convert.ToInt32(Partes.Partes_Estados.ANULADO);
                            oPartes.SetearEstadoParte(oPartes.Id, 0, oPartes.Id_Partes_Estados, DateTime.Now, 0, 0, "");
                            oPartesHistorial.Id_Parte = oPartes.Id;
                            oPartesHistorial.Id_Usuarios = oPartes.Id_Usuarios;
                            oPartesHistorial.Id_Personal = Personal.Id_Login;
                            oPartesHistorial.Fecha_Movimiento = DateTime.Now;
                            oPartesHistorial.Id_area = Personal.Id_Area;
                            oPartesHistorial.Id_Partes_Estados = oPartes.Id_Partes_Estados;
                            oPartesHistorial.Detalles = cbFalla.Text;
                            oPartesHistorial.GuardarNuevoDetalle(oPartesHistorial);
                        }
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                        MessageBox.Show("Error al generar parte de trabajo.");

                }
            }
            else
                MessageBox.Show("La solicitud seleccionada no se encuentra dentro de las operaciones a realizar.");
            pgCircular.Stop();
        }

        private void LimpiarDatos()
        {
            lblCosto.Text = String.Format("Costo:");
            lista_id_partes.Clear();
            DrServicioSeleccionado = null;
            requiere_equipo = String.Empty;
            id_partes_operaciones = 0;
            Con_Cargo = String.Empty;
            ListaImportesComprobantesDet.Clear();
            drDatosComprobanteVenta = null;
            Num_Comprobante = 0;
            DtImportesCtaCteDet.Clear();
            oComprobante.Importe = 0;
            oPartes.Id = 0;
            DtPartesEquipos.Clear();
            oUsuario_ctacte.Id = 0;
            oUsuario_ctactedet.Id = 0;
        }

        public frmGenerarParte(int usu, int loc, DataRow usuSel, int idUsuarioServicio, int idOperacion)
        {
            InitializeComponent();
            this.idUsuario = usu;
            this.idLocacion = loc;
            this.drUsuario_actual = usuSel;
            this.usuarioServcioSeleccionado = idUsuarioServicio;
            this.idPartesOperacion = idOperacion;

        }

        private void frmCrearParte_Load(object sender, EventArgs e)
        {
            try
            {
                IdTarifaActual = Convert.ToInt32(oServicios_tarifas.TraerDatosTarifaActual().Rows[0]["id"]);
                dpFecha.CustomFormat = "dd-MM-yyyy";
                DtImportesCtaCteDet.Columns.Add("importe", typeof(decimal));
                DtImportesCtaCteDet.Columns.Add("tiposub", typeof(string));
                Limpiar();
                if (idUsuario != 0 && idLocacion != 0)
                    comenzarCarga();
            }
            catch { MessageBox.Show("Error al traer los datos de la tarifa. Verifique las tarifas cargadas."); }
        }

        private void frmCrearParte_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void btnGenerarParte_Click(object sender, EventArgs e)
        {
            GenerarParte();
            this.Close();
        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chkCortadosRetirados_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCortadosRetirados.Checked)
                dtvUsuariosServicios.RowFilter = "id>0";
            else
                dtvUsuariosServicios.RowFilter = String.Format("id_servicios_estados<>'{0}' and id_servicios_estados<>'{1}'", Convert.ToInt16(Servicios.Servicios_Estados.CORTADO), Convert.ToInt16(Servicios.Servicios_Estados.RETIRADO));
            CargarFallas();
        }

        private void cbFalla_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (dtFallas.Rows.Count > 0)
                {
                    lblCosto.Text = String.Format("Costo: ${0}", dtFallas.Select(String.Format("id={0}", cbFalla.SelectedValue))[0]["importe"].ToString());
                    ImporteSolicitud = Convert.ToDecimal(dtFallas.Select(String.Format("id={0}", cbFalla.SelectedValue))[0]["importe"]);
                }

            }
            catch { ImporteSolicitud = 0; };
        }

        private void dgvServiciosContratados_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                CargarFallas();
            }
            catch { }

        }
    }
}
//27112019 MAXI ADD CAMPO ID_ORIGEN CTACTE