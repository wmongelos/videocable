using CapaNegocios;
using CapaPresentacion.Busquedas;
using CapaPresentacion.Impresiones;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace CapaPresentacion.Partes_Trabajo
{
    public partial class frmEquiposCambio : Form
    {
        private GPS oGps = new GPS();
        private Thread hilo;
        private delegate void myDel();
        private Usuarios_Locaciones oUsuariosLocaciones = new Usuarios_Locaciones();
        private Usuarios_Servicios oUsuariosServicios = new Usuarios_Servicios();
        private Configuracion oConfiguracion = new Configuracion();
        private Partes_Solicitudes oPartesSolicitudes = new Partes_Solicitudes();
        private Partes oPartes = new Partes();
        private Partes_Equipos oPartesEquipos = new Partes_Equipos();
        private Partes_Historial oPartesHistorial = new Partes_Historial();
        private Comprobantes oComprobantes = new Comprobantes();
        private Usuarios_CtaCte oUsuariosCtaCte = new Usuarios_CtaCte();
        private Usuarios_CtaCte_Det oUsuariosCtaCteDet = new Usuarios_CtaCte_Det();
        private Usuarios oUsuarios = new Usuarios();
        private Servicios_Tarifas oServiciosTarifas = new Servicios_Tarifas();
        private Comprobantes_Tipo oComprobantesTipo = new Comprobantes_Tipo();
        private Servicios_Tarifas_Sub oServiciosTarifasSub = new Servicios_Tarifas_Sub();
        private Impresion oImpresion = new Impresion();
        private Equipos oEquipos = new Equipos();


        private DataTable DtUsuarios = new DataTable();
        private DataTable DtServiciosConEquipos = new DataTable();
        private DataTable DtEquipos = new DataTable();
        private DataTable DtSolicitudes = new DataTable();

        private DataRow drDatosComprobanteVenta = null;
        private DataView DtvServicios;

        private int IdLocacion = 0;
        private int IdUsuario = 0;
        private int IdTipoFacturacionDb = 0;
        private int IdServicios = 0;
        private int IdTipoFacturacion = 0;
        private int IdTarifaActual = 0;
        private int IdUsuariosServicios = 0;
        private int IdServiciosTipos = 0;
        private int idTipoEquipoNuevo = 0;

        private decimal ImporteSolicitud = 0;
        private int NumComprobante = 0;
        private bool realizarCambio = false;

        public DataTable dtServiciosContratados;
        public int idUsuarioServicio;

        public DataRow drUsuario_actual;
        private List<Int32> ListaIdPartes = new List<Int32>();

        private int trabajaAgenda { get; set; }

        private void comenzarCarga()
        {
            pgCircular.Start();
            hilo = new Thread(new ThreadStart(cargarDatos));
            hilo.IsBackground = true;
            hilo.Start();
        }

        private void cargarDatos()
        {
            try
            {
                trabajaAgenda = oConfiguracion.GetValor_N("Agenda_Trabajo");
                if (realizarCambio == false)
                {
                    dtServiciosContratados = oUsuariosServicios.ListarServiciosYSubServiciosActivos(Usuarios.CurrentUsuario.Id);
                    DtEquipos = oEquipos.BuscarEquipoPorUsuario(Usuarios.CurrentUsuario.Id);
                    oUsuariosLocaciones = oUsuariosLocaciones.GetLocacion(IdLocacion);
                    if (oUsuariosLocaciones.GetLocacion(IdLocacion).Activo == Convert.ToInt32(Usuarios_Locaciones.Locacion_Estados.ACTIVA))
                    {
                        IdTarifaActual = Convert.ToInt32(oServiciosTarifas.TraerDatosTarifaActual().Rows[0]["id"]);
                        IdTipoFacturacionDb = oConfiguracion.GetValor_N("Id_Tipo_Facturacion");
                        DtServiciosConEquipos = oEquipos.BuscarEquipoPorUsuarioServicio(idUsuarioServicio);
                    }
                    else
                        MessageBox.Show("La locación seleccionada del usuario que ha buscado no se encuentra activa.");
                }
                else
                {
                    int idTipoFacturacion = Convert.ToInt32(dgvServiciosConEquipos.SelectedRows[0].Cells["id_tipo_facturacion"].Value);
                    int idServicio = Convert.ToInt32(dgvServiciosConEquipos.SelectedRows[0].Cells["id_servicio"].Value);
                    int idUsuarioServicio = Convert.ToInt32(dgvServiciosConEquipos.SelectedRows[0].Cells["id_usuario_servicio"].Value);
                    int idUsuario = Convert.ToInt32(dgvServiciosConEquipos.SelectedRows[0].Cells["id_usuarios"].Value);
                    int idLocacion = Convert.ToInt32(dgvServiciosConEquipos.SelectedRows[0].Cells["id_locacion"].Value);
                    int idEquipoTipo = Convert.ToInt32(dgvEquipos.SelectedRows[0].Cells["id_equipos_tipos"].Value);
                    int idEquipo = Convert.ToInt32(dgvEquipos.SelectedRows[0].Cells["id"].Value);
                    int idEquipoTarjeta = Convert.ToInt32(dgvEquipos.SelectedRows[0].Cells["id_tarjeta"].Value);
                    int idServicioTipo = Convert.ToInt32(dgvServiciosConEquipos.SelectedRows[0].Cells["id_servicio_tipo"].Value);
                    DtSolicitudes = oPartesSolicitudes.ListarServicioTipo(idServicioTipo, IdTarifaActual, IdServicios, "P", IdTipoFacturacion);
                    DataView dv = Tablas.DataEquiposTipos.DefaultView;
                    dv.RowFilter = string.Format("id={0}", idEquipoTipo);
                    DataTable dtEquipoTipo = dv.ToTable();
                    if (Convert.ToInt32(dtEquipoTipo.Rows[0]["requiere_tarjeta"]) == 1)
                    {
                        if (idEquipoTarjeta > 0)
                        {
                            if (MessageBox.Show("¿Desea cambiar tambien la tarjeta?", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                GenerarCambioEquipo(idTipoFacturacion, idServicio, idUsuarioServicio, idUsuario, idLocacion, idTipoEquipoNuevo, idEquipo, idEquipoTarjeta, chkCobrar.Checked, 0);
                            else
                                GenerarCambioEquipo(idTipoFacturacion, idServicio, idUsuarioServicio, idUsuario, idLocacion, idTipoEquipoNuevo, idEquipo, idEquipoTarjeta, chkCobrar.Checked, idEquipoTarjeta);
                        }
                    }
                    else
                    {
                        GenerarCambioEquipo(idTipoFacturacion, idServicio, idUsuarioServicio, idUsuario, idLocacion, idTipoEquipoNuevo, idEquipo, idEquipoTarjeta, chkCobrar.Checked, 0);

                    }

                    if (trabajaAgenda == Convert.ToInt32(Agenda_Encabezado.Uso_agenda.TRABAJA_CON_AGENDA))
                        EnviarParte();
                }
                myDel MD = new myDel(asignarDatos);
                this.Invoke(MD, new object[] { });
                pgCircular.Stop();
            }
            catch (Exception ex)
            {
                if (realizarCambio == false)
                    MessageBox.Show("Error al cargar Informacion" + ex.Message);
                else
                {
                    MessageBox.Show("Error al generar cambio de equipo.");
                    throw;
                }

            }
        }

        private void asignarDatos()
        {
            if (realizarCambio == false)
            {
                if (DtServiciosConEquipos.Rows.Count > 0)
                {
                    dgvServiciosConEquipos.DataSource = dtServiciosContratados;

                    FormatearGrillas();
                    btnGenerarCambio.Enabled = true;
                    SetearImporteSolicitud("GrillaServicios");
                    //lblTotal.Text = String.Format("Total de Registros: {0}", dtServiciosActivos.Rows.Count);
                }
                else
                    MessageBox.Show("El usuario no posee servicios con equipos en la locación especificada. Asigne servicios al usuario.");
            }
            else
            {
                MessageBox.Show("Cambio de equipo generado correctamente.");

                if (oConfiguracion.GetValor_N("Agenda_Trabajo") == Convert.ToInt32(Agenda_Encabezado.Uso_agenda.TRABAJA_CON_AGENDA))
                {
                    ListaIdPartes.Add(oPartes.Id);
                    frmAgenda frmAgenda = frmAgenda.GetInstancia();
                    frmAgenda.Id_recibido(ListaIdPartes);
                    frmAgenda.Mostrar();
                }
                else
                {
                    DialogResult dialogResult = MessageBox.Show("¿Desea imprimir el parte generado?", "", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                        oImpresion.ImprimirParte(oPartes.Id);
                }
                realizarCambio = false;
            }

        }
        private void FormatearGrillas()
        {
            foreach (DataGridViewColumn item in dgvServiciosConEquipos.Columns)
            {
                item.Visible = false;
                item.SortMode = DataGridViewColumnSortMode.NotSortable;

            }
            dgvServiciosConEquipos.Columns["servicio"].Visible = true;
            dgvServiciosConEquipos.Columns["servicio"].DisplayIndex = 0;
            dgvServiciosConEquipos.Columns["servicio"].HeaderText = "Servicio";
            dgvServiciosConEquipos.Columns["categoria"].Visible = true;
            dgvServiciosConEquipos.Columns["categoria"].DisplayIndex = 1;
            dgvServiciosConEquipos.Columns["categoria"].HeaderText = "Categoria";
            dgvServiciosConEquipos.Columns["fecha_inicio"].Visible = true;
            dgvServiciosConEquipos.Columns["fecha_inicio"].DisplayIndex = 2;
            dgvServiciosConEquipos.Columns["fecha_inicio"].HeaderText = "Conexion";
            dgvServiciosConEquipos.Columns["fecha_inicio"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvServiciosConEquipos.Columns["estado"].Visible = true;
            dgvServiciosConEquipos.Columns["estado"].DisplayIndex = 3;
            dgvServiciosConEquipos.Columns["estado"].HeaderText = "Estado";
            dgvServiciosConEquipos.Columns["estado"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvServiciosConEquipos.Columns["fecha_estado"].Visible = true;
            dgvServiciosConEquipos.Columns["fecha_estado"].DisplayIndex = 4;
            dgvServiciosConEquipos.Columns["fecha_estado"].HeaderText = "Ult. Cambio";
            dgvServiciosConEquipos.Columns["fecha_estado"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvServiciosConEquipos.Columns["fecha_factura"].Visible = true;
            dgvServiciosConEquipos.Columns["fecha_factura"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvServiciosConEquipos.Columns["fecha_factura"].DefaultCellStyle.Format = "d MMM yyyy";
            dgvServiciosConEquipos.Columns["fecha_factura"].HeaderText = "Fin del servicio";
            dgvServiciosConEquipos.Columns["fecha_factura"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

            int contador = 0;
            int indice = 0;
            foreach (DataGridViewRow item in dgvServiciosConEquipos.Rows)
            {
                item.Height = 30;
                if (item.Cells["requiere_equipo"].Value.ToString() == "NO")
                    item.Visible = false;
                int idTipo = Convert.ToInt32(item.Cells["id_tipo"].Value);
                if (idTipo != 1 && idTipo != 3)
                    item.Visible = false;
                if (idTipo == 3 || idTipo == 4)
                {
                    item.DefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Italic);

                }
                if (idTipo == 1 && contador == 0)
                {
                    indice = item.Index;
                    contador++;
                }

            }
        }

        private void Buscar()
        {
            lblCosto.Text = "";
            DtEquipos.Clear();
            DtServiciosConEquipos.Clear();
            frmBusquedaUsuarios frm = new frmBusquedaUsuarios(1, "", "");
            if (frm.ShowDialog() == DialogResult.OK)
            {
                drUsuario_actual = frm.usuario_e;
                Usuarios.Usuario_Sel = frm.usuario_e;
                IdUsuario = Int32.Parse(drUsuario_actual["id"].ToString());
                IdLocacion = Int32.Parse(drUsuario_actual["id_usuarios_locaciones"].ToString());
                comenzarCarga();
            }
        }

        private void SetearImporteSolicitud(string grillaSeleccionada)
        {
            if (dgvServiciosConEquipos.SelectedRows.Count > 0)
            {
                IdUsuariosServicios = Convert.ToInt32(dgvServiciosConEquipos.SelectedRows[0].Cells["id_usuario_servicio"].Value);
                IdServiciosTipos = Convert.ToInt32(dgvServiciosConEquipos.SelectedRows[0].Cells["id_servicio_tipo"].Value);
                IdServicios = Convert.ToInt32(dgvServiciosConEquipos.SelectedRows[0].Cells["id_servicio"].Value);
            }
            else
            {
                IdUsuariosServicios = Convert.ToInt32(dgvServiciosConEquipos.Rows[0].Cells["id_usuario_servicio"].Value);
                IdServiciosTipos = Convert.ToInt32(dgvServiciosConEquipos.Rows[0].Cells["id_servicio_tipo"].Value);
                IdServicios = Convert.ToInt32(dgvServiciosConEquipos.Rows[0].Cells["id_servicio"].Value);
            }
            int d = 19;
            IdTipoFacturacion = Convert.ToInt32(dgvServiciosConEquipos.Rows[0].Cells["id_tipo_facturacion"].Value);
            if (dgvEquipos.Rows.Count > 0)
            {



                if (grillaSeleccionada == "GrillaServicios")
                {
                    DtSolicitudes.Clear();
                    DtSolicitudes = oPartesSolicitudes.ListarServicioTipo(IdServiciosTipos, IdTarifaActual, IdServicios, "P", IdTipoFacturacion);

                    try
                    {
                        DataTable dt = oServiciosTarifasSub.ObtienePrecio(IdTarifaActual, IdTipoFacturacion, IdServicios, Convert.ToInt32(dgvEquipos.SelectedRows[0].Cells["Id_Equipos_Tipos"].Value), 0, 0, "E");
                        int idOperacion = Convert.ToInt32(Partes.Partes_Operaciones.CAMBIO_DE_EQUIPO);
                        DataView dv = DtSolicitudes.DefaultView;
                        dv.RowFilter = $"id_partes_operaciones={ idOperacion }";
                        DataTable dtTemp = dv.ToTable();
                        decimal importeSolicitudSola = 0;
                        decimal importeEquipo = 0;
                        if (dtTemp.Rows.Count > 0)
                            importeSolicitudSola = Convert.ToDecimal(dtTemp.Rows[0]["importe"]);
                        if (dt.Rows.Count > 0)
                            importeEquipo = Convert.ToDecimal(dt.Rows[0]["importe"]);

                        ImporteSolicitud = importeEquipo + importeSolicitudSola;

                    }
                    catch (Exception c)
                    {
                        throw;
                    }
                }
                else
                {
                    try
                    {
                        ImporteSolicitud = Convert.ToDecimal(oServiciosTarifasSub.ObtienePrecio(IdTarifaActual, IdTipoFacturacion, IdServicios, Convert.ToInt32(dgvEquipos.SelectedRows[0].Cells["Id_Equipos_Tipos"].Value), 0, 0, "E").Rows[0]["importe"]);
                    }
                    catch (Exception c)
                    {
                        throw;
                    }
                }
            }
            lblCosto.Text = String.Format("${0}", ImporteSolicitud);
        }

        private void GenerarCambioEquipo(int idTipoFacturacion, int idServicios, int idUsuariosServicios, int idUsuarios, int idUsuariosLocaciones, int idEquiposTipos, int idEquipo, int idTarjeta, bool cobrar, int idTarjetaNueva)
        {
            oPartes.Id_Servicios = idServicios;
            oPartes.Id_Usuarios_Servicios = idUsuariosServicios;
            oPartes.Id_Usuarios = idUsuarios;
            oPartes.Id_Usuarios_Locaciones = idUsuariosLocaciones;
            oPartes.Id_Zonas = idTipoFacturacion;
            oPartes.Id_Partes_Fallas = Convert.ToInt32(DtSolicitudes.Select(String.Format("id_partes_operaciones={0}", Convert.ToInt32(Partes.Partes_Operaciones.CAMBIO_DE_EQUIPO)))[0]["id"]);
            oPartes.Id_Partes_Soluciones = 0;
            oPartes.Id_Tecnico = 0;
            oPartes.Id_Movil = 0;
            oPartes.Id_Operadores = Personal.Id_Login;
            oPartes.Id_Areas = Personal.Id_Area;
            oPartes.Fecha_Programado = DateTime.Now;
            oPartes.Fecha_Reclamo = DateTime.Now;
            oPartes.Detalle_Falla = DtSolicitudes.Select(String.Format("id_partes_operaciones={0}", Convert.ToInt32(Partes.Partes_Operaciones.CAMBIO_DE_EQUIPO)))[0]["falla"].ToString();
            oPartes.Detalle_Solucion = "";
            oPartes.Id_Partes_Estados = Convert.ToInt32(Partes.Partes_Estados.PENDIENTE_DE_ASIGNACION_DE_TECNICO);
            oPartes.Id_Usuarios_Cuenta_Corriente = 0;
            oPartes.Id = oPartes.Guardar(oPartes, 1);

            if (oPartes.Id > 0)
            {
                oGps.EnviarParte(oPartes.Id);
                oPartesEquipos.Id_Usuarios = oPartes.Id_Usuarios;
                oPartesEquipos.Id_Partes = oPartes.Id;
                oPartesEquipos.Id_Servicios = oPartes.Id_Servicios;
                oPartesEquipos.Id_Usuarios_Servicios = oPartes.Id_Usuarios_Servicios;
                oPartesEquipos.Id_Equipos_Tipos = idEquiposTipos;
                oPartesEquipos.Id_equipo_anterior = idEquipo;
                oPartesEquipos.Id_Tarjeta_Anterior = idTarjeta;
                if (idTarjetaNueva > 0)
                {
                    oPartesEquipos.Id_Tarjeta = idTarjetaNueva;
                }
                oPartesEquipos.Guardar(oPartesEquipos);

                oPartes.Id_Partes_Estados = oPartes.SetearEstadoParte(oPartes.Id, 0, 0, DateTime.Now, 0, 0, "");
                oPartesHistorial.Id_Parte = oPartes.Id;
                oPartesHistorial.Id_Usuarios = oPartes.Id_Usuarios;
                oPartesHistorial.Id_Personal = Personal.Id_Login;
                oPartesHistorial.Fecha_Movimiento = DateTime.Now;
                oPartesHistorial.Id_area = Personal.Id_Area;
                oPartesHistorial.Id_Partes_Estados = oPartes.Id_Partes_Estados;
                oPartesHistorial.Detalles = DtSolicitudes.Select(String.Format("id_partes_operaciones={0}", Convert.ToInt32(Partes.Partes_Operaciones.CAMBIO_DE_EQUIPO)))[0]["falla"].ToString();
                oPartesHistorial.GuardarNuevoDetalle(oPartesHistorial);

                if (cobrar == true)
                {
                    if (ImporteSolicitud > 0)
                    {
                        drDatosComprobanteVenta = oComprobantesTipo.GetNumeracion(Convert.ToInt32(Comprobantes_Tipo.Tipo.COMPROBANTE_DEUDA), Puntos_Cobros.Id_Punto);
                        NumComprobante = Convert.ToInt32(drDatosComprobanteVenta["numComprobante"]);
                        if (NumComprobante > 0)
                            oComprobantesTipo.SetNumeracion(Convert.ToInt32(drDatosComprobanteVenta["idPuntoVenta"]), Convert.ToInt32(Comprobantes_Tipo.Tipo.COMPROBANTE_DEUDA), Convert.ToInt32(drDatosComprobanteVenta["numComprobante"]));

                        oComprobantes.Id_Usuarios = Convert.ToInt32(oPartes.Id_Usuarios);
                        oComprobantes.Fecha = DateTime.Now;
                        oComprobantes.Punto_Venta = Convert.ToInt32(drDatosComprobanteVenta["numPuntoVenta"]);
                        oComprobantes.Id_Comprobantes_Tipo = Convert.ToInt32(Comprobantes_Tipo.Tipo.COMPROBANTE_DEUDA);
                        oComprobantes.Numero = Convert.ToInt32(drDatosComprobanteVenta["numComprobante"]);
                        oComprobantes.Importe = ImporteSolicitud;
                        oComprobantes.Id_Usuarios_Locaciones = Convert.ToInt32(oPartes.Id_Usuarios_Locaciones);
                        oComprobantes.Id = oComprobantes.Guardar(oComprobantes);

                        oUsuariosCtaCte.Id_Usuarios = oPartes.Id_Usuarios;
                        oUsuariosCtaCte.Id_Comprobantes = oComprobantes.Id;
                        oUsuariosCtaCte.Fecha_Movimiento = DateTime.Now;
                        oUsuariosCtaCte.Fecha_Desde = DateTime.Now;
                        oUsuariosCtaCte.Fecha_Hasta = DateTime.Now;
                        string muestra;
                        char pad = '0';
                        muestra = "COMPROBANTE DE DEUDA " + Convert.ToInt32(drDatosComprobanteVenta["numPuntoVenta"]).ToString().PadLeft(4, pad) + "-" + oUsuariosCtaCte.Id_Comprobantes.ToString().PadLeft(8, pad);
                        oUsuariosCtaCte.Descripcion = muestra;
                        oUsuariosCtaCte.Importe_Original = oComprobantes.Importe;
                        oUsuariosCtaCte.Importe_Punitorio = 0;
                        oUsuariosCtaCte.Importe_Bonificacion = 0;
                        oUsuariosCtaCte.Importe_Final = oComprobantes.Importe;
                        oUsuariosCtaCte.Importe_Saldo = oComprobantes.Importe;
                        oUsuariosCtaCte.Id_Usuarios_Locacion = oPartes.Id_Usuarios_Locaciones;
                        oUsuariosCtaCte.Numero = oComprobantes.Numero.ToString();
                        oUsuariosCtaCte.Id_Comprobantes_Tipo = Convert.ToInt32(Comprobantes_Tipo.Tipo.COMPROBANTE_DEUDA);
                        oUsuariosCtaCte.Id_Comprobantes_Ref = 0;
                        oUsuariosCtaCte.Id_Facturacion = 0;
                        oUsuariosCtaCte.Generado_facturacion_mensual = Convert.ToInt32(Usuarios_CtaCte.GENERADO_FACTURACION_MENSUAL.NO);
                        oUsuariosCtaCte.Id_Personal = Personal.Id_Login;
                        oUsuariosCtaCte.Guardar(oUsuariosCtaCte);

                        oUsuariosCtaCteDet.Id_Usuarios_CtaCte = oUsuariosCtaCte.Id;
                        oUsuariosCtaCteDet.Id_Usuarios_Locaciones = oPartes.Id_Usuarios_Locaciones;
                        oUsuariosCtaCteDet.Id_Zonas = oPartes.Id_Zonas;
                        oUsuariosCtaCteDet.Id_Servicios = oPartes.Id_Servicios;
                        oUsuariosCtaCteDet.Id_Tipo = oPartes.Id_Partes_Fallas;
                        oUsuariosCtaCteDet.Tipo = "P";
                        oUsuariosCtaCteDet.Importe_Original = oComprobantes.Importe;
                        oUsuariosCtaCteDet.Importe_Saldo = oComprobantes.Importe;
                        oUsuariosCtaCteDet.Importe_Final = oComprobantes.Importe;
                        oUsuariosCtaCteDet.Id_Usuarios_Servicios = oPartes.Id_Usuarios_Servicios;
                        oUsuariosCtaCteDet.Id_Velocidades = 0;
                        oUsuariosCtaCteDet.Id_Velocidades_Tip = 0;
                        oUsuariosCtaCteDet.Requiere_IP = 0;
                        oUsuariosCtaCteDet.Cantidad_Periodos = 1;
                        oUsuariosCtaCteDet.Fecha_Desde = DateTime.Now;
                        oUsuariosCtaCteDet.Fecha_Hasta = DateTime.Now;
                        oUsuariosCtaCteDet.Id_bonificacion_Aplicada = 0;
                        oUsuariosCtaCteDet.Nombre_Bonificacion = String.Empty;
                        oUsuariosCtaCteDet.Periodo_Ano = oUsuariosCtaCteDet.Fecha_Desde.Year;
                        oUsuariosCtaCteDet.Periodo_Mes = oUsuariosCtaCteDet.Fecha_Desde.Month;
                        oUsuariosCtaCteDet.Porcentaje_Bonificacion = 0;
                        oUsuariosCtaCteDet.Guardar(oUsuariosCtaCteDet);

                    }
                }
            }
        }

        public frmEquiposCambio(int IdUsuarioRecibido, int IdLocacionRecibida)
        {
            InitializeComponent();
            IdUsuario = IdUsuarioRecibido;
            IdLocacion = IdLocacionRecibida;
            drUsuario_actual = null;
        }

        private void frmEquiposCambio_Load(object sender, EventArgs e)
        {
            chkCobrar.Checked = true;
            if (IdLocacion > 0)
                comenzarCarga();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmEquiposCambio_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }


        private void BuscarEquipos()
        {
            DataView dvEquipos = DtEquipos.DefaultView;

            if (dgvServiciosConEquipos.SelectedRows.Count > 0)
                idUsuarioServicio = Convert.ToInt32(dgvServiciosConEquipos.SelectedRows[0].Cells["id_usuario_servicio"].Value);
            else
                idUsuarioServicio = Convert.ToInt32(dgvServiciosConEquipos.Rows[0].Cells["id_usuario_servicio"].Value);

            if (DtEquipos.Rows.Count > 0)
            {
                dvEquipos = DtEquipos.DefaultView;
                dvEquipos.RowFilter = string.Format("id_usuario_servicio={0}", idUsuarioServicio);

            }


            dgvEquipos.DataSource = dvEquipos.ToTable();
            foreach (DataGridViewColumn item in dgvEquipos.Columns)
                item.Visible = false;

            dgvEquipos.Columns["marca"].Visible = true;
            dgvEquipos.Columns["marca"].DisplayIndex = 0;

            dgvEquipos.Columns["modelo"].Visible = true;
            dgvEquipos.Columns["modelo"].DisplayIndex = 1;

            dgvEquipos.Columns["mac"].Visible = true;
            dgvEquipos.Columns["mac"].DisplayIndex = 2;

            dgvEquipos.Columns["serie"].Visible = true;
            dgvEquipos.Columns["serie"].DisplayIndex = 3;


            dgvEquipos.Columns["equipo_clave"].Visible = true;
            dgvEquipos.Columns["equipo_clave"].DisplayIndex = 4;

            dgvEquipos.Columns["equipo_usuario"].Visible = true;
            dgvEquipos.Columns["equipo_usuario"].DisplayIndex = 5;

            dgvEquipos.Columns["equipo_ip"].Visible = true;
            dgvEquipos.Columns["equipo_ip"].DisplayIndex = 6;


            SetearImporteSolicitud("GrillaServicios");
        }

        private void dgvServiciosConEquipos_CellEnter(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnGenerarCambio_Click(object sender, EventArgs e)
        {
            Equipos_Tipos oEquipoTipo = new Equipos_Tipos();
            DataTable dtTiposEquipos = new DataTable();
            dtTiposEquipos = oEquipoTipo.ListarPorTipoServicios(Convert.ToInt32(dgvServiciosConEquipos.SelectedRows[0].Cells["id_servicio_tipo"].Value));
            cboTiposEquipos.DataSource = dtTiposEquipos;
            cboTiposEquipos.ValueMember = "id";
            cboTiposEquipos.DisplayMember = "nombre";
            pnlTipoEquipos.Visible = true;
            cboTiposEquipos.Focus();

        }

        private void dgvEquipos_CellEnter(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvEquipos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvServiciosConEquipos_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void EnviarParte()
        {
            GPS oGPS = new GPS();
            try
            {
                oGPS.EnviarParte(oPartes.Id);
            }
            catch (Exception C)
            {
                MessageBox.Show("Error al intentar enviar parte al gps" + C.Message);
            }
        }

        private void btnAceptarTipoEquipo_Click(object sender, EventArgs e)
        {
            idTipoEquipoNuevo = Convert.ToInt32(cboTiposEquipos.SelectedValue);
            if (dgvEquipos.SelectedRows.Count > 0)
            {
                realizarCambio = true;
                pnlTipoEquipos.Visible = false;

                comenzarCarga();
            }
            else
                MessageBox.Show("No se ha seleccionado un equipo para realizar el cambio.");
        }

        private void btnCanelar_Click(object sender, EventArgs e)
        {
            pnlTipoEquipos.Visible = false;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            pnlTipoEquipos.Visible = false;
        }

        private void dgvServiciosConEquipos_SelectionChanged(object sender, EventArgs e)
        {
            BuscarEquipos();
        }
    }
}
