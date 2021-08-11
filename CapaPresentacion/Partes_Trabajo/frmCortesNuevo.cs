using CapaNegocios;
using CapaPresentacion.Busquedas;
using CapaPresentacion.Cuenta_Corriente;
using CapaPresentacion.Impresiones;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using CapaPresentacion.Mapas;

namespace CapaPresentacion.Partes_Trabajo
{
    public partial class frmCortesNuevo : Form
    {
        public enum Tipo
        {
            CORTES = 0,
            AVISOS = 1
        }

        #region Propiedades
        private Tipo tipo;
        private Servicios oServicio = new Servicios();
        private Zonas oZonas = new Zonas();
        private Servicios_Categorias oCategorias = new Servicios_Categorias();
        private Servicios_Tipos oServicios_Tipos = new Servicios_Tipos();
        private Usuarios_Servicios oUsuarios_Servicios = new Usuarios_Servicios();
        private Usuarios_Avisos oUsuarios_Avisos = new Usuarios_Avisos();
        private Usuarios_Locaciones oLocaciones = new Usuarios_Locaciones();
        private Usuarios_CtaCte_Det oUsuarios_CtaCte_Det = new Usuarios_CtaCte_Det();
        private Partes oPartes = new Partes();
        private Partes_Solicitudes oPartes_Fallas = new Partes_Solicitudes();
        private Partes_Usuarios_Servicios oParteUsuarioServicio = new Partes_Usuarios_Servicios();
        Cass oCass;
        DataTable dtAplicacionesFiltradas = Tablas.DataCass;
        private DataTable dtServicios_Tipo = new DataTable();
        private DataTable dtCortes = new DataTable();
        private DataTable dtCortesFiltrados = new DataTable();
        private DataView dvCortesFiltrados;

        private dsInformes oDs = new dsInformes();
        private Thread hilo;
        private delegate void myDel();
        private delegate void myDelBool(bool condicion);
        private int TipoBusqueda,idTipoFacturacion;
        private DataRow[] DrTiposServicioElegidos;
        private string CadenaFiltro;
        public List<Int32> ListaCtasCtesPostergar = new List<int>();
        public List<Int32> ListaUsuariosServiciosEspera = new List<int>();
        frmPostergarFechaCorteServ frmPostergar;
        DataTable DtCortesAPostergar = new DataTable();
        Partes_Historial oPartesHistorial = new Partes_Historial();
        Servicios_Estados_Historial oServiciosEstadosHistorial = new Servicios_Estados_Historial();
        DataTable dtPartesCortesAGenerar;
        DataTable drParteFalla = new DataTable();
        private int cantErroresProducidos;
        private int cantAvisosGenerados;
        private bool seleccionados = false;
        private DataTable dtPartesGenerados = new DataTable();
        private DataTable dtErrorIsp = new DataTable();
        private Tools oTools = new Tools();
        private Configuracion oConfig = new Configuracion();
        private Thread hiloPrincipal;
        private string mensaje = "";
        DataTable DtServiciosAsociados = new DataTable();
        private bool yaCargo = false;
        #endregion

        #region Métodos

        private void ComenzarCarga()
        {
            cboFiltro.SelectedIndex = 0;
            btnBuscar.Enabled = false;
            dtCortes.Clear();
            dgvCortes.DataSource = null;
            controles(false);
            hiloPrincipal = Thread.CurrentThread;
            pgCircular.Start();
            hilo = new Thread(new ThreadStart(CargarDatos));
            hilo.Start();
        }

        private void CargarDatos()
        {
            DateTime fecha = dtpFecha.Value;
            Int32 cantidadPeriodos = Convert.ToInt32(spPeriodosAdeudados.Value);
            Decimal importeAdeudado = Convert.ToDecimal(spImporte.Value);
            StringBuilder filtroTipoServicios = new StringBuilder("(");
            List<string> idsServiciosSeleccionados = new List<string>();

            foreach (DataRow dr in dtServicios_Tipo.Rows)
            {
                if (Convert.ToBoolean(dr["Elige"]))
                    idsServiciosSeleccionados.Add(dr["Id"].ToString());
            }

            for (int i = 0; i < idsServiciosSeleccionados.Count; i++)
            {
                filtroTipoServicios.Append(idsServiciosSeleccionados[i]);
                if (i < idsServiciosSeleccionados.Count - 1)
                    filtroTipoServicios.Append(",");
                else
                    filtroTipoServicios.Append(")");
            }

            if (idsServiciosSeleccionados.Count > 0)
            {
                if (TipoBusqueda == Convert.ToInt32(Servicios.TipoCorte.FALTA_PAGO))
                    dtCortes = oUsuarios_CtaCte_Det.ListarDeudaPorPeriodosNuevo(filtroTipoServicios.ToString(), false, fecha,idTipoFacturacion);
                else
                    dtCortes = oUsuarios_CtaCte_Det.ListarDeudaPorPeriodosNuevo(filtroTipoServicios.ToString(), true, fecha, idTipoFacturacion);

                myDel MD = new myDel(AsignarDatos);
                this.Invoke(MD, new object[] { });
            }
            else
            {
                myDelBool MDB = new myDelBool(controles);
                this.Invoke(MDB, new object[] { true });
            }
            pgCircular.Stop();
        }

        private void AsignarDatos()
        {
            dgvCortes.DataSource = null;

            DataColumn dcElige = new DataColumn();
            dcElige.ColumnName = "Elige";
            dcElige.DataType = System.Type.GetType("System.Boolean");
            dcElige.DefaultValue = false;

            dtCortes.Columns.Add(dcElige);

            dgvCortes.DataSource = dtCortes;
            for (int i = 0; i < dgvCortes.Columns.Count; i++)
                dgvCortes.Columns[i].Visible = false;

            dgvCortes.Columns["codigo"].Visible = true;
            dgvCortes.Columns["usuario"].Visible = true;
            dgvCortes.Columns["fecha_fin"].Visible = true;
            dgvCortes.Columns["estado_servicio"].Visible = true;
            dgvCortes.Columns["estado_servicio"].HeaderText = "Estado";

            dgvCortes.Columns["estado_servicio"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvCortes.Columns["codigo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvCortes.Columns["usuario"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            if (TipoBusqueda == Convert.ToInt32(Servicios.TipoCorte.FALTA_PAGO))
            {
                dgvCortes.Columns["saldo"].Visible = true;
                dgvCortes.Columns["saldo"].HeaderText = "Saldo servicio";
                dgvCortes.Columns["saldo"].DefaultCellStyle.Format = "c2";
                dgvCortes.Columns["saldo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                dgvCortes.Columns["meses_adeudados"].Visible = true;
                dgvCortes.Columns["meses_adeudados"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvCortes.Columns["meses_adeudados"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvCortes.Columns["meses_adeudados"].HeaderText = "Meses adeudados";

                dgvCortes.Columns["saldoctacte"].Visible = true;
                dgvCortes.Columns["saldoctacte"].DefaultCellStyle.Format = "c2";
                dgvCortes.Columns["saldoctacte"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                dgvCortes.Columns["fecha_estado"].Visible = true;
                dgvCortes.Columns["fecha_estado"].HeaderText = "En espera hasta";
            }

            dgvCortes.Columns["Localidad"].Visible = true;
            dgvCortes.Columns["Elige"].Visible = true;
            dgvCortes.Columns["servicio"].Visible = true;
            dgvCortes.Columns["aviso_locacion"].Visible = true;
            dgvCortes.Columns["aviso_locacion"].HeaderText = "Ultimo aviso";

            //FiltrarPorTipoServicio();
            dgvCortes.ReadOnly = false;
            dgvCortes.Columns["codigo"].ReadOnly = true;
            dgvCortes.Columns["usuario"].ReadOnly = true;
            dgvCortes.Columns["servicio"].ReadOnly = true;
            dgvCortes.Focus();
            controles(true);
            lblTotal.Text = String.Format("Total de Registros: {0}", dgvCortes.Rows.Count);
            lblParciales.Text = String.Format("Registros parciales: {0}", dgvCortes.Rows.Count);

            if(yaCargo == false)
            {
                if (dtErrorIsp.Columns.Count == 0)
                {
                    dtErrorIsp.Columns.Add("idParte", typeof(int));
                    dtErrorIsp.Columns.Add("idEquipment", typeof(int));
                    dtErrorIsp.Columns.Add("idAccesAccount", typeof(int));
                    dtErrorIsp.Columns.Add("idProduct", typeof(int));
                }
                yaCargo = true;
            }
        }

        private void ComenzarProcesoCortes()
        {
            cantErroresProducidos = 0;
            controles(false);
            //pgCircular.Start();
            //hilo = new Thread(new ThreadStart(ProcesarCortes));
            //hilo.Start();
            ProcesarCortes();
        }

        private void ProcesarCortes()
        {
            try
            {
                dtPartesCortesAGenerar.Clear();
                DataTable dtElegidos;
                DataView dv = new DataView(dtCortes);
                DataTable dtFiltroPeriodos = dtCortes.DefaultView.ToTable();

                //misteriosamente la aforma de arriba que usamos siempre para filtrar no funciona, deja afuera el primer registro
                DataTable tblFiltered = dtFiltroPeriodos.AsEnumerable()
                .Where(row => row.Field<Boolean>("elige") == true && row.Field<UInt32>("con_corte") == 0 && row.Field<Int32>("id_servicios_estados") != (int)Servicios.Servicios_Estados.EN_ESPERA)
                   .OrderBy(row => row.Field<int>("codigo"))
                   .CopyToDataTable();

                dtElegidos = tblFiltered.Copy();

                if (dtElegidos.Rows.Count == 0)
                {
                    MessageBox.Show("No hay cortes para generar", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ComenzarCarga();
                    return;
                }

                foreach (DataRow dr_cortes in dtElegidos.Rows)
                {
                    try
                    {
                        DataRow drParte = dtPartesCortesAGenerar.NewRow();
                        drParteFalla = oPartes_Fallas.GetFallasPorTipoServYOp(Convert.ToInt32(dr_cortes["id_servicios_tipos"].ToString()), Convert.ToInt32(Partes.Partes_Operaciones.CORTE));
                        drParte["Id"] = 0;
                        drParte["Id_Usuarios"] = Convert.ToInt32(dr_cortes["Id_usuarios"]);
                        drParte["Id_Servicios"] = Convert.ToInt32(dr_cortes["id_servicios"]);
                        drParte["Id_Usuarios_Servicios"] = Convert.ToInt32(dr_cortes["Id_Usuarios_Servicios"]);
                        drParte["Id_Servicios_Tipos"] = Convert.ToInt32(dr_cortes["Id_Servicios_Tipos"]);
                        drParte["Id_Servicios_Grupos"] = Convert.ToInt32(dr_cortes["Id_Servicios_Grupos"]);
                        drParte["Id_Usuarios_Locaciones"] = Convert.ToInt32(dr_cortes["Id_locacion"]);
                        drParte["Id_Zonas"] = Convert.ToInt32(dr_cortes["Id_zonas"]);
                        try
                        {
                            drParte["Id_Partes_Fallas"] = Convert.ToInt32(drParteFalla.Rows[0]["id"]);
                        }
                        catch { drParte["Id_Partes_Fallas"] = 0; }
                        drParte["Id_Partes_Soluciones"] = 0;
                        drParte["Id_Movil"] = 0;
                        drParte["Fecha_Programado"] = DateTime.Now;
                        int configAgenda = oConfig.GetValor_N("Agenda_Trabajo");
                        if (configAgenda == Convert.ToInt32(Agenda_Encabezado.Uso_agenda.TRABAJA_CON_AGENDA))
                        {
                            if (Convert.ToInt32(dr_cortes["CorteAutomatico"]) == Convert.ToInt32(Servicios._CorteAutomatico.SI))
                            {
                                drParte["Id_Partes_Estados"] = Convert.ToInt32(Partes.Partes_Estados.REALIZADO);
                                drParte["Id_Tecnico"] = Personal.Id_Login;
                                drParte["Fecha_Realizado"] = DateTime.Now;
                            }
                            else
                            {
                                drParte["Id_Partes_Estados"] = Convert.ToInt32(Partes.Partes_Estados.PENDIENTE_DE_ASIGNACION_DE_TECNICO);
                                drParte["Id_Tecnico"] = 0;
                            }
                        }
                        else
                        {
                            drParte["Id_Partes_Estados"] = Convert.ToInt32(Partes.Partes_Estados.PENDIENTE_DE_ASIGNACION_DE_TECNICO);
                            drParte["Id_Tecnico"] = 0;
                        }
                        drParte["Id_Operadores"] = Personal.Id_Login;
                        drParte["Id_Areas"] = Personal.Id_Area;
                        drParte["Fecha_Reclamo"] = DateTime.Today.Date;
                        try
                        {
                            drParte["Detalle_Falla"] = drParteFalla.Rows[0]["nombre"].ToString();
                        }
                        catch { drParte["Detalle_Falla"] = ""; }

                        drParte["Detalle_Solucion"] = "";
                        drParte["CorteAutomatico"] = Convert.ToInt32(dr_cortes["CorteAutomatico"]);
                        drParte["id_aplicacion_externa"] = Convert.ToInt32(dr_cortes["id_aplicaciones_externas"]);


                        dtPartesCortesAGenerar.Rows.Add(drParte);

                    }
                    catch (Exception c)
                    {
                        cantErroresProducidos++;
                        MessageBox.Show(c.Message);
                    }

                }

                if (dtPartesCortesAGenerar.Rows.Count > 0)
                {
                    int Parte_ID = 0;
                    bool Requiere_App_Externa = false;
                    dtPartesGenerados = oPartes.GenerarLotePartes(dtPartesCortesAGenerar, Convert.ToInt32(Partes.Partes_Operaciones.CORTE));
                    foreach (DataRow parte in dtPartesGenerados.Rows)
                    {
                        if (Convert.ToInt32(parte["id"]) > 0)
                          if(oUsuarios_Servicios.ActualizarConCorte(Convert.ToInt32(parte["Id_Usuarios_Servicios"]), 1) == 0)
                          {
                              Parte_ID = Convert.ToInt32(parte["id"]);
                              DtServiciosAsociados = oParteUsuarioServicio.ListarServiciosPorParte(Parte_ID, Partes_Usuarios_Servicios.CONDICION_REQ_EQUIPOS.TODOS);
                              foreach (DataRow drServicio in DtServiciosAsociados.Rows)
                              {
                                  Requiere_App_Externa = false;
                                  if (Convert.ToInt32(drServicio["id_app_ext"]) == (int)Aplicaciones_Externas.Aplicacion_Externa.CASS)
                                  {
                                      Requiere_App_Externa = true;
                                      break;
                                  }
                              }
                              if (Requiere_App_Externa == true)
                                    desactivarCass(Convert.ToInt32(parte["id_usuarios"]));
                          }
                            
                    }
                    if (dtPartesGenerados.Rows.Count > 0)
                    {
                        oPartes.GenerarHistorialPartes(dtPartesGenerados);
                    }
                    else
                        cantErroresProducidos++;

                }


                int idParte = 0;
                int idUsuarioServicio = 0;
                int idUsuario = 0;
                int idServicio = 0;
                int idApp = 0;
                string nombreApp = "";
                int idEquipo = 0;
                string mac = "";
                int idEquipment = 0, idAccessAccount = 0, idProduct = 0;
                int idUSE;
                Isp oISP = new Isp();
                Equipos oEquipos = new Equipos();
                Aplicaciones_Externas oApp = new Aplicaciones_Externas();

                DataTable dtEquipos = new DataTable();
                DataTable dtDatosServicios = new DataTable();
                DataTable dtDatosApp = new DataTable();
                DataTable dtDatosEquipo = new DataTable();
                DataTable dtDatosAccessAccount = new DataTable();

                foreach (DataRow item in dtPartesGenerados.Rows)
                {
                    idParte = Convert.ToInt32(item["id"]);
                    idServicio = Convert.ToInt32(item["id_servicios"]);
                    dtDatosServicios = oServicio.BuscarDatosServicio(idServicio);


                    if (oConfig.GetValor_N("Agenda_Trabajo") != Convert.ToInt32(Agenda_Encabezado.Uso_agenda.TRABAJA_CON_AGENDA))
                    {
                        idApp = Convert.ToInt32(dtDatosServicios.Rows[0]["id_aplicaciones_externas"]);
                        dtDatosApp = oApp.Listar(idApp);
                        if (dtDatosApp.Rows.Count > 0)
                        {
                            nombreApp = dtDatosApp.Rows[0]["nombre"].ToString();
                            if (nombreApp == "ISP")
                            {
                                idUsuario = Convert.ToInt32(item["id_usuarios"]);
                                idUsuarioServicio = Convert.ToInt32(item["id_usuarios_servicios"]);
                                dtEquipos = oEquipos.ListarEquipoPorUsuariosServicio(idUsuarioServicio);
                                foreach (DataRow itemEquipo in dtEquipos.Rows)
                                {
                                    idEquipment = 0;
                                    idProduct = 0;
                                    idAccessAccount = 0;
                                    try
                                    {
                                        idUSE = Convert.ToInt32(itemEquipo["id"]);
                                        idEquipo = Convert.ToInt32(itemEquipo["id_equipo"]);
                                        dtDatosEquipo = oEquipos.BuscarDatosEquipo(idEquipo);
                                        mac = dtDatosEquipo.Rows[0]["mac"].ToString();
                                        Isp.cadenaConexion = dtDatosApp.Rows[0]["string_conexion"].ToString();
                                        idEquipment = oISP.VerificarExisteEquipo(mac, "");
                                        if (idEquipment > 0)
                                        {
                                            idAccessAccount = oISP.obtenerIdAccesAccount(idEquipment);
                                            if (idAccessAccount > 0)
                                            {
                                                dtDatosAccessAccount = oISP.ListarDatosAccoun(idAccessAccount);
                                                if (dtDatosAccessAccount.Rows.Count > 0)
                                                {
                                                    idProduct = Convert.ToInt32(dtDatosAccessAccount.Rows[0]["product_id"]);
                                                    oEquipos.ActualizarProductoAux(idUSE, idProduct);
                                                    oISP.CortarServicio(idAccessAccount);
                                                }
                                            }
                                        }

                                    }
                                    catch (Exception)
                                    {
                                        dtErrorIsp.Rows.Add(idParte, idEquipment, idAccessAccount, idProduct);
                                    }

                                }
                            }
                        }
                    }

                }
                cerrarProcesoGeneracionCortes();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar Informacion" + ex.Message);
                controles(true);
            }
        }

        private void desactivarCass(int id_usu)
        {
            string Salida = "";
            oCass = new Cass(Convert.ToInt32(dtAplicacionesFiltradas.Rows[0]["Id"]));
            oCass.PausarPaquetesAbonado(id_usu, out Salida);
        }
        private void ComenzarProcesoAvisos()
        {
            cantErroresProducidos = 0;
            controles(false);
            pgCircular.Start();
            hilo = new Thread(new ThreadStart(ProcesarAvisos));
            hilo.Start();
        }

        private void ProcesarAvisos()
        {
            try
            {
                List<string> salidas = new List<string>() ;
                int numParte = oPartes.Id;
                cantAvisosGenerados = 0;
                int mesUltimoAviso = 0;
                int anioUltimoAviso = 0;
                int idServicio = 0;
                int idLocacion = 0;
                decimal saldoTotal = 0;
                DateTime fechaUltimoAviso;
                foreach (DataRow dr_cortes in dtCortes.Rows)
                {
                    fechaUltimoAviso = new DateTime(2000, 1, 1);
                    try
                    {
                        idServicio = Convert.ToInt32(dr_cortes["id_servicios"]);
                        saldoTotal = Convert.ToDecimal(dr_cortes["saldoctacte"].ToString());
                        idLocacion = Convert.ToInt32(dr_cortes["Id_locacion"]);
                        mesUltimoAviso = Convert.ToDateTime(dr_cortes["ultimo_aviso"]).Month;
                        anioUltimoAviso = Convert.ToDateTime(dr_cortes["ultimo_aviso"]).Year;
                        DataView dv = Tablas.DataAvisosDetalles.DefaultView;
                        DataTable dtAvisoMensaje = new DataTable();

                        DateTime fechaTolerancia = DateTime.Now.AddDays(Convert.ToInt32(spTolerancia.Value));
                        if (Convert.ToBoolean(dr_cortes["Elige"]))
                        {
                            fechaUltimoAviso = oUsuarios_Avisos.getFechaUltimoAviso(idLocacion);
                            if(fechaUltimoAviso.Date!=DateTime.Today)
                            {
                                oUsuarios_Avisos.EliminarAvisosAnteriores(idLocacion);
                                oUsuarios_Avisos.id_usuarios = Convert.ToInt32(dr_cortes["Id_usuarios"].ToString());
                                oUsuarios_Avisos.id_usuarios_locaciones = Convert.ToInt32(dr_cortes["Id_locacion"].ToString());
                                oUsuarios_Avisos.id_usuarios_servicios = Convert.ToInt32(dr_cortes["id_usuarios_servicios"].ToString());
                                oUsuarios_Avisos.id_avisos_tipo = 1;
                                oUsuarios_Avisos.id_personal = Personal.Id_Login;
                                oUsuarios_Avisos.fecha = DateTime.Now;
                                oUsuarios_Avisos.descripcion = "Aviso de Corte";
                                oUsuarios_Avisos.receptor = "";
                                oUsuarios_Avisos.importe = Convert.ToDecimal(dr_cortes["saldoctacte"].ToString());
                                oUsuarios_Avisos.tipo_de_comunicacion = "Correspondencia";
                                oUsuarios_Avisos.Telefono = dr_cortes["telefono1"].ToString();
                                if (Tablas.DataAvisosDetalles.Rows.Count > 0)
                                {
                                    oUsuarios_Avisos.Mensaje = mensaje;
                                    if (mensaje != "")
                                    {         
                                        oUsuarios_Avisos.Mensaje = oUsuarios_Avisos.Mensaje.Replace("#", fechaTolerancia.ToString("dd/MM/yyyy"));
                                        oUsuarios_Avisos.Mensaje = oUsuarios_Avisos.Mensaje.Replace("@", oUsuarios_Avisos.importe.ToString("C", CultureInfo.GetCultureInfo("es-AR")));
                                    }
                                }
                                else
                                    oUsuarios_Avisos.Mensaje = "";

                                oUsuarios_Avisos.Guardar(oUsuarios_Avisos);
                                oUsuarios_Servicios.Actualizar_avisos(1, 1, Convert.ToInt32(dr_cortes["id_usuarios_servicios"].ToString()));
                                cantAvisosGenerados++;
                                oUsuarios_Servicios.ActualizarFechaUltimoAviso(Convert.ToInt32(dr_cortes["id_usuarios_servicios"].ToString()));
                                oLocaciones.ActualizarUltimoAviso(idLocacion);
                            }
                            
                        }
                    }
                    catch (Exception c)
                    {
                        cantErroresProducidos++;
                        salidas.Add(c.Message);
                    }
                }
                myDel MD = new myDel(genera_avisos);
                this.Invoke(MD, new object[] { });
                pgCircular.Stop();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar Informacion" + ex.Message);
            }
        }

        private void elige_servicio()
        {
            if (Convert.ToBoolean(dgvTipos.CurrentRow.Cells["Elige"].Value) == false)
                dgvTipos.SelectedRows[0].Cells["elige"].Value = true;
            else
                dgvTipos.SelectedRows[0].Cells["elige"].Value = false;
        }

        private void FiltrarPorTipoServicio()
        {
            dtCortes.DefaultView.RowFilter = "id_usuarios_servicios>0";
            DrTiposServicioElegidos = dtServicios_Tipo.Select("elige=true");
            if (DrTiposServicioElegidos.Length > 0)
            {
                for (int x = 0; x < DrTiposServicioElegidos.Length; x++)
                {
                    if (x != (DrTiposServicioElegidos.Length - 1))
                        CadenaFiltro += String.Format("id_servicios_tipos={0} or ", DrTiposServicioElegidos[x]["id"]);
                    else
                        CadenaFiltro += String.Format("id_servicios_tipos={0}", DrTiposServicioElegidos[x]["id"]);
                }
                dtCortes.DefaultView.RowFilter = CadenaFiltro;
                dvCortesFiltrados = dtCortes.DefaultView;
                dtCortesFiltrados = dvCortesFiltrados.ToTable();

                dgvCortes.DataSource = dtCortesFiltrados;
            }
            else
                dtCortes.DefaultView.RowFilter = "id_usuarios_servicios>0";
            lblTotal.Text = String.Format("Total de Registros: {0}", dgvCortes.Rows.Count);
            lblParciales.Text = String.Format("Registros parciales: {0}", dgvCortes.Rows.Count);
            CadenaFiltro = String.Empty;
        }

        private void genera_avisos()
        {
            if (cantAvisosGenerados == 0)
                MessageBox.Show("No se ha generado ningun aviso, ya sea porque no se selecciono ninguno o porque los seleccionados ya se han generado", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else if (cantErroresProducidos == 0)
                MessageBox.Show("Avisos generados correctamente.");
            else
                MessageBox.Show("Hubo errores en la generación de avisos.");
            cantErroresProducidos = 0;
            foreach (Control item in this.Controls)
                item.Enabled = true;
            ComenzarCarga();
        }

        private void cerrarProcesoGeneracionCortes()
        {
            if (cantErroresProducidos > 0)
                MessageBox.Show("Se han producido errores al generar algunos cortes.");
            else
                MessageBox.Show("Se han generado cortes correctamente.");
            cantErroresProducidos = 0;

            if (dtErrorIsp.Rows.Count > 0)
            {
                //si hay errores los mando a un archivito
                foreach (DataRow dr in dtErrorIsp.Rows)
                {
                    StreamWriter sw = new StreamWriter("C:\\GIES\\ERROR.txt");
                    string line = "id_parte:" + dr["idParte"].ToString() + ";";
                    line += "id_equipment:" + dr["idEquipment"].ToString() + ";";
                    line += "id_access_account:" + dr["idAccesAccount"].ToString() + ";";
                    line += "id_product:" + dr["idProduct"].ToString() + ";";
                    sw.WriteLine(line); //write data
                    sw.Close();
                }
            }

            ComenzarCarga();
        }

        private void PostergarCortes()
        {
            frmPostergar = new frmPostergarFechaCorteServ(Convert.ToInt32(dgvCortes.SelectedRows[0].Cells["id_usuarios"].Value), Convert.ToInt32(dgvCortes.SelectedRows[0].Cells["id_locacion"].Value));
            frmPopUp frmpopup = new frmPopUp();
            frmpopup.Maximizar = false;
            frmpopup.Formulario = frmPostergar;
            frmpopup.ShowDialog();
            if (frmPostergar.DialogResult == DialogResult.OK)
                ComenzarCarga();
        }

        private void controles(bool estado)
        {
            btnExportar.Enabled = estado;
            btnPostergar.Enabled = estado;
            btnBuscar.Enabled = estado;
            btnGenera.Enabled = estado;
            btnAvisos.Enabled = estado;
            spImporte.Enabled = estado;
            spPeriodosAdeudados.Enabled = estado;
            dtpFecha.Enabled = estado;
            btnFiltro.Enabled = estado;
            cboFiltro.Enabled = estado;
            spTolerancia.Enabled = estado;
            btnTildar.Enabled = estado;
            btnMapa.Enabled = estado;
        }

        private bool AvisoGenerado(int mes, int anio)
        {
            int mesActual = DateTime.Now.Month;
            int anioActual = DateTime.Now.Year;
            if (mes == mesActual && anio == anioActual)
                return true;
            return false;
        }
        #endregion


        public frmCortesNuevo(Tipo tipo)
        {
            InitializeComponent();
            this.tipo = tipo;
            formatearControlesSegunElTipo();
        }

        private void formatearControlesSegunElTipo()
        {
            if(tipo == Tipo.CORTES)
            {
                btnAvisos.Visible = false;
                lblDiasTolerancia.Visible = false;
                spTolerancia.Visible = false;
                lblTipo.Text = "Corte por:";
                lblHeader.Text = "Cortes de servicio";
            }
            else if(tipo == Tipo.AVISOS)
            {
                btnGenera.Visible = false;
                lblTipo.Text = "Aviso por:";
                lblHeader.Text = "Avisos de cortes";
            }
        }

        private void dgvServicios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            String columnName = this.dgvTipos.Columns[e.ColumnIndex].Name;

            if (e.RowIndex == -1 && columnName == "Elige")
            {
                foreach (DataRow item in dtServicios_Tipo.Rows)
                    item["Elige"] = !seleccionados;
                seleccionados = !seleccionados;
            }
            else
            {
                if (dgvTipos.Columns[e.ColumnIndex].Name == "Elige")
                    elige_servicio();
            }
        }

        private void btnGenera_Click(object sender, EventArgs e)
        {
            if (dgvCortes.Rows.Count > 0)
            {
                DialogResult result = MessageBox.Show("Genera cortes de servicio?", "Cortes de servicio", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                    ComenzarProcesoCortes();
            }
            else
                MessageBox.Show("No hay datos en la grilla.");
        }

        private void btnAvisos_Click(object sender, EventArgs e)
        {
            if (dgvCortes.Rows.Count == 0)
            {
                MessageBox.Show("No hay datos en la grilla.", "Mensaje del sistema");
                return;
            }

            foreach (Control item in this.Controls)
            {
                if (!item.Name.Equals("pcCircular"))
                    item.Enabled = false;
                else
                    item.Enabled = true;
            }

            if(oConfig.GetValor_N("Agenda_Trabajo")==2)
            {
                frmAvisosTipos ofrmTiposAvisos = new frmAvisosTipos();
                frmPopUp opop = new frmPopUp();
                opop.Formulario = ofrmTiposAvisos;
                opop.Maximizar = false;
                if (opop.ShowDialog() == DialogResult.OK)
                {
                    mensaje = ofrmTiposAvisos.mensaje;
                    ComenzarProcesoAvisos();
                }
                else
                    controles(true);

            }
            else
            {
                ComenzarProcesoAvisos();
            }
        }

        private void frmCortesNuevo_Load(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            new Partes().CambiarServiciosEnEsperaSiEstanVencidos();
            new Partes().RestrablecerCortes();
            cboFiltro.SelectedIndex = 0;
            rbFaltaPago.Checked = true;
            spPeriodosAdeudados.Enabled = true;
            dtpFecha.CustomFormat = "dd-MM-yyyy";
            TipoBusqueda = Convert.ToInt32(Servicios.TipoCorte.FALTA_PAGO);
            DtCortesAPostergar.Columns.Add("id_usuarios_servicios", typeof(string));
            DtCortesAPostergar.Columns.Add("id_usuarios_ctacte", typeof(string));
            DtCortesAPostergar.Columns.Add("id_servicios", typeof(string));
            DtCortesAPostergar.Columns.Add("id_usuarios", typeof(string));
            dtPartesCortesAGenerar = oPartes.Get_Estructura_Partes();

            dtServicios_Tipo = oServicio.Listar();

            DataView dtv = new DataView(dtServicios_Tipo);
            dtv.RowFilter = "Id_Servicios_Modalidad <> 4";

            dtServicios_Tipo = dtv.ToTable();

            dtServicios_Tipo.Columns.Add("Elige", typeof(Boolean));
            foreach (DataRow dr in dtServicios_Tipo.Rows)
                dr["elige"] = false;

            dgvTipos.DataSource = dtServicios_Tipo;

            for (int i = 0; i < dgvTipos.ColumnCount; i++)
                dgvTipos.Columns[i].Visible = false;

            dgvTipos.Columns["Tipo"].Visible = true;
            dgvTipos.Columns["Descripcion"].Visible = true;
            dgvTipos.Columns["Elige"].Visible = true;
            if (oConfig.GetValor_N("Id_Tipo_Facturacion") == 1)
                cboTipoFacturacion.DataSource = Tablas.DataZonas;
            else
            {
                cboTipoFacturacion.DataSource = Tablas.DataServiciosCategorias;
                (cboTipoFacturacion.DataSource as DataTable).Rows.Add(0, "TODAS");
            }

            cboTipoFacturacion.DisplayMember = "nombre";
            cboTipoFacturacion.ValueMember = "id";
            controles(false);
            btnBuscar.Enabled = true;
            dtpFecha.Enabled = true;
            this.Cursor = Cursors.Default;
        }

        private void btnRefrescarDatos_Click(object sender, EventArgs e)
        {
            if (dgvCortes.Rows.Count > 0)
                FiltrarPorTipoServicio();
            else
                MessageBox.Show("No hay registros en la grilla.");
        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmCortesNuevo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            idTipoFacturacion = Convert.ToInt32(cboTipoFacturacion.SelectedValue);
            ComenzarCarga();
        }

        private void rbFaltaPago_CheckedChanged(object sender, EventArgs e)
        {
            spPeriodosAdeudados.Enabled = true;
            spImporte.Enabled = true;
            btnPostergar.Enabled = true;
            TipoBusqueda = Convert.ToInt32(Servicios.TipoCorte.FALTA_PAGO);
        }

        private void rbFinalizacionServicio_CheckedChanged(object sender, EventArgs e)
        {
            spPeriodosAdeudados.Enabled = false;
            spImporte.Enabled = false;
            spImporte.Value = spImporte.Minimum;
            btnPostergar.Enabled = false;
            TipoBusqueda = Convert.ToInt32(Servicios.TipoCorte.FIN_DE_CONTRATO);
        }

        private void btnPostergar_Click(object sender, EventArgs e)
        {
            if (dgvCortes.SelectedRows.Count > 0)
                PostergarCortes();
            else
                MessageBox.Show("No hay datos en la grilla.");

        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            int Id = 0;
            if (txtBuscar.Text.Length > 0)
            {
                dtCortesFiltrados = dtCortes;
                if (Int32.TryParse(txtBuscar.Text, out Id))
                    dtCortesFiltrados.DefaultView.RowFilter = String.Format("codigo='" + txtBuscar.Text + "'");
                else
                    dtCortesFiltrados.DefaultView.RowFilter = String.Format("servicio Like '%" + txtBuscar.Text + "%' or usuario Like '%" + txtBuscar.Text + "%' or localidad Like '%" + txtBuscar.Text + "%'");

            }
            else
                dtCortes.DefaultView.RowFilter = "id_usuarios_servicios>0";
        }

        private void btnTildar_Click(object sender, EventArgs e)
        {
            if (btnTildar.Text == "Tildar")
            {
                foreach (DataGridViewRow item in dgvCortes.Rows)
                {
                    if (item.Visible == true)
                    {
                        if((Convert.ToInt32(item.Cells["id_servicios_estados"].Value) != Convert.ToInt32(Servicios.Servicios_Estados.EN_ESPERA)) &&
                           (Convert.ToInt32(item.Cells["con_corte"].Value)) != 1) 
                            item.Cells["Elige"].Value = true;
                    }
                }

                btnTildar.Text = "Destildar";
            }
            else
            {
                foreach (DataGridViewRow item in dgvCortes.Rows)
                {
                    item.Cells["Elige"].Value = false;
                }

                btnTildar.Text = "Tildar";
            }

            dtCortesFiltrados.AcceptChanges();
        }
        private void dgvCortes_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            int mesUltimoAviso = Convert.ToDateTime(dgvCortes.Rows[e.RowIndex].Cells["aviso_locacion"].Value).Month;
            int anioUltimoAviso = Convert.ToDateTime(dgvCortes.Rows[e.RowIndex].Cells["aviso_locacion"].Value).Year;

            if(Convert.ToInt32(dgvCortes.Rows[e.RowIndex].Cells["id_servicios_estados"].Value) == Convert.ToInt32(Servicios.Servicios_Estados.EN_ESPERA))
            {
                e.CellStyle.BackColor = Color.LightSkyBlue;
            }
            else
            {
                if (AvisoGenerado(mesUltimoAviso, anioUltimoAviso))
                {
                    e.CellStyle.BackColor = Color.Gold;
                }

                if (Convert.ToInt32(dgvCortes.Rows[e.RowIndex].Cells["con_corte"].Value) == 1)
                {
                    e.CellStyle.BackColor = Color.Tomato;
                }

                if (TipoBusqueda == Convert.ToInt32(Servicios.TipoCorte.FALTA_PAGO))
                {
                    dgvCortes.Rows[e.RowIndex].Cells["fecha_estado"].Style.ForeColor = Color.White;
                }
            }
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            if (dgvCortes.Rows.Count > 0)
            {
                this.Cursor = Cursors.WaitCursor;
                try
                {
                    string[] colnames = new string[] 
                    { 
                        "codigo", 
                        "usuario", 
                        "saldo", 
                        "meses_adeudados", 
                        "saldoctacte", 
                        "fecha_desde", 
                        "fecha_fin", 
                        "correo_electronico", 
                        "telefono1", 
                        "telefono2", 
                        "ultimo_aviso", 
                        "servicio", 
                        "localidad", 
                        "locacion", 
                        "estado_servicio" 
                    };
                    DataTable dtExportar = (dgvCortes.DataSource as DataTable).DefaultView.ToTable(false, colnames);
                    Tools tools = new Tools();
                    tools.ExportDataTableToExcel(dtExportar, "Corte de Servicios");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    this.Cursor = Cursors.Default;
                }
                MessageBox.Show("Datos exportados correctamente", "Mensaje del sistema");
            }
            else
            {
                MessageBox.Show("No hay Registros para Exportar", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void spImporte_ValueChanged(object sender, EventArgs e)
        {
            decimal cantImporte = spImporte.Value;
            if (cantImporte > 0)
                dtCortes.DefaultView.RowFilter = "saldo >= " + cantImporte.ToString();
            else
                dtCortes.DefaultView.RowFilter = "saldo > 0";
            lblParciales.Text = String.Format("Registros parciales: {0}", dgvCortes.Rows.Count);
        }

        private void spPeriodosAdeudados_ValueChanged(object sender, EventArgs e)
        {
            decimal cantPeriodos = spPeriodosAdeudados.Value;
            if(dtCortes.Rows.Count>0)
            {
                if (cantPeriodos > 0)
                {

                    dtCortes.DefaultView.RowFilter = "meses_adeudados >= " + cantPeriodos.ToString();
                }
                else
                {

                    dtCortes.DefaultView.RowFilter = "meses_adeudados > 0";
                }
                lblParciales.Text = String.Format("Registros parciales: {0}", dgvCortes.Rows.Count);
            }
        }

        private void dgvCortes_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                try
                {
                    var hti = dgvCortes.HitTest(e.X, e.Y);
                    // Add this
                    dgvCortes.CurrentCell = dgvCortes.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    // Can leave these here - doesn't hurt
                    dgvCortes.Rows[e.RowIndex].Selected = true;
                    dgvCortes.Focus();
                    foreach (ToolStripMenuItem item in cmsOpciones.Items)
                        item.Enabled = true;
                    cmsOpciones.Show(Cursor.Position);

                }
                catch { }
            }
        }

        private void verCuentaCorrienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int idUsuario = Convert.ToInt32(dgvCortes.SelectedRows[0].Cells["id_usuarios"].Value);
            int idLocacion = Convert.ToInt32(dgvCortes.SelectedRows[0].Cells["id_locacion"].Value);
            Usuarios oUsu = new Usuarios();
            oUsu.LlenarObjeto(idUsuario);
            frmUsuariosCtaCteConsultaNuevo oCtacte = new frmUsuariosCtaCteConsultaNuevo(idUsuario, idLocacion);
            oCtacte.FormBorderStyle = FormBorderStyle.FixedDialog;
            oCtacte.Size = new Size(Screen.PrimaryScreen.WorkingArea.Width - 100, Screen.PrimaryScreen.WorkingArea.Height - 100);
            oCtacte.ShowDialog();
        }

        private void verDatosDeContactoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUsuarioContacto oContacto = new frmUsuarioContacto(
               dgvCortes.SelectedRows[0].Cells["usuario"].Value.ToString(),
               dgvCortes.SelectedRows[0].Cells["locacion"].Value.ToString(),
               dgvCortes.SelectedRows[0].Cells["telefono1"].Value.ToString(),
               dgvCortes.SelectedRows[0].Cells["telefono2"].Value.ToString(),
               dgvCortes.SelectedRows[0].Cells["correo_electronico"].Value.ToString());
            oContacto.ShowDialog();
        }

        private void irAlUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int idUsuario = Convert.ToInt32(dgvCortes.SelectedRows[0].Cells["id_usuarios"].Value);
            int idLocacion = Convert.ToInt32(dgvCortes.SelectedRows[0].Cells["id_locacion"].Value);
            Usuarios oUsu = new Usuarios();
            oUsu.LlenarObjeto(idUsuario);
            this.Close();
        }

        private void btnFiltro_Click(object sender, EventArgs e)
        {
            if (dgvCortes.Rows.Count == 0)
                return;

            foreach (DataGridViewRow row in dgvCortes.Rows)
            {
               // this.dgvCortes.CurrentCell = null;
                CurrencyManager cm = (CurrencyManager)BindingContext[dgvCortes.DataSource];
                cm.SuspendBinding();

                if (cboFiltro.SelectedIndex == 0)
                {
                    row.Visible = true;
                }
                else if (cboFiltro.SelectedIndex == 3)
                {
                    if (Convert.ToInt32(row.Cells["con_corte"].Value) == 1)
                        row.Visible = true;
                    else
                        row.Visible = false;
                }
                else if (cboFiltro.SelectedIndex == 1)
                {
                    int mesUltimoAviso = Convert.ToDateTime(row.Cells["ultimo_aviso"].Value).Month;
                    int anioUltimoAviso = Convert.ToDateTime(row.Cells["ultimo_aviso"].Value).Year;
                    if (AvisoGenerado(mesUltimoAviso, anioUltimoAviso) && Convert.ToInt32(row.Cells["con_corte"].Value) == 0)
                        row.Visible = true;
                    else
                        row.Visible = false;
                }
                else if (cboFiltro.SelectedIndex == 2)
                {
                    int mesUltimoAviso = Convert.ToDateTime(row.Cells["ultimo_aviso"].Value).Month;
                    int anioUltimoAviso = Convert.ToDateTime(row.Cells["ultimo_aviso"].Value).Year;
                    if (!AvisoGenerado(mesUltimoAviso, anioUltimoAviso) && Convert.ToInt32(row.Cells["con_corte"].Value) == 0)
                        row.Visible = true;
                    else
                        row.Visible = false;
                }
                else if (cboFiltro.SelectedIndex == 4)
                {
                    if (Convert.ToInt32(row.Cells["con_corte"].Value) == 0)
                        row.Visible = true;
                    else
                        row.Visible = false;
                }
            }
        }

        private void dgvCortes_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvCortes.Columns[e.ColumnIndex].Name == "Elige")
            {
                if (Convert.ToInt32(dgvCortes.Rows[e.RowIndex].Cells["id_servicios_estados"].Value) == Convert.ToInt32(Servicios.Servicios_Estados.EN_ESPERA))
                {
                    dgvCortes.Rows[e.RowIndex].Cells["Elige"].Value = false;
                }
            }
        }

        private void dgvCortes_CellStateChanged(object sender, DataGridViewCellStateChangedEventArgs e)
        {
            MessageBox.Show("d");
        }

        private void dgvCortes_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (TipoBusqueda == Convert.ToInt32(Servicios.TipoCorte.FALTA_PAGO))
            {
                if (Convert.ToInt32(dgvCortes.Rows[e.RowIndex].Cells["id_servicios_estados"].Value) != Convert.ToInt32(Servicios.Servicios_Estados.EN_ESPERA))
                {
                    dgvCortes.Rows[e.RowIndex].Cells["fecha_estado"].Style.SelectionForeColor = SystemColors.Highlight;
                }
                else
                {
                    dgvCortes.Rows[e.RowIndex].Cells["fecha_estado"].Style.SelectionForeColor = Color.White;
                }
            }
        }

        private void btnMapa_Click(object sender, EventArgs e)
        {

            frmCortesMapa oFormulario = new frmCortesMapa(dtCortes);
            frmPopUp frmpopup = new frmPopUp();
            frmpopup.Maximizar = true;
            frmpopup.Formulario = oFormulario;
            frmpopup.ShowDialog();
            if (frmpopup.DialogResult == DialogResult.OK)
            {
                dtCortes = oFormulario.dtCortes;
                dgvCortes.DataSource = dtCortes;
            }

        }

        private void verDetalleDeDeudaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int idUsuario = Convert.ToInt32(dgvCortes.SelectedRows[0].Cells["id_usuarios"].Value);
            int idServicio = Convert.ToInt32(dgvCortes.SelectedRows[0].Cells["id_servicios"].Value);
            frmDetalleDeudaServicio oDeudaDetalle = new frmDetalleDeudaServicio();
            oDeudaDetalle.idServicio = idServicio;
            oDeudaDetalle.idUsuario = idUsuario;
            oDeudaDetalle.fecha = dtpFecha.Value;
            oDeudaDetalle.ShowDialog();
        }
    }
}
//101019fede
