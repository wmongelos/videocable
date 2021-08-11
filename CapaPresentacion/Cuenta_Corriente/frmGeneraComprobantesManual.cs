using CapaNegocios;
using CapaPresentacion.Impresiones;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;

namespace CapaPresentacion
{

    public partial class frmGeneraComprobantesManual : Form
    {
        #region Declaraciones 
        private int contServiciosUnicos = 0;
        private int contUsuariosServiciosUnicos = 0;
        private int idUsuario = Usuarios.CurrentUsuario.Id;
        private int idTarifaActual = 0;
        int idServicioUnicoSeleccionado = 0;
        private int idCtaCteGlobal = 0;
        private int nComprobante = 0;
        private int idModulo = 0;
        private int indexUsuariosServiciosFilaSeleccionadas = 0;
        private int idUsuarioRecibido, idLocacionRecibidaSeleccionada;
        private decimal ImporteTotal;
        private decimal TotalFinal = 0;
        decimal ValorTxtTotal;
        private Int32 idModalidad;
        private Int32 idUsuarioServicio;
        private Int32 idServicio;
        private Int32 idTipoFac;
        private Int32 idTipoServicio;
        private Decimal importeFinal;
        private List<int> listaRegistrosDetallesEliminar = new List<int>();
        private List<int> listaSubServicios = new List<int>();
        private String servicioNombre;
        private String servicioGrupo;
        private String servicioTipo;
        private Boolean notificar = false;
        private Boolean generarParte = false;
        private Boolean generarNotificacionCorte = false;
        bool GeneraDeudas = false;
        DateTime fechaComenzarMovimiento = new DateTime();
        private DateTime fechaDesde, fechaHasta, fechaFactura;
        DataColumn DcElige, DcImporteSubServicioUnico;
        private DataRow drDatosComprobanteVenta = null;
        DataTable dtServiciosModalidades, dtUsuariosServicios, dtMovimientosAGenerar, dtLocaciones, dtServiciosUnicos, dtServiciosUnicosSub, dtUsuariosServiciosSub, dtRegistrosSubServCtaCteDetalle, dtDatosUsuario;
        private DataTable dtDestinatarios = new DataTable();
        private DataTable dtModulos = new DataTable();
        private DataTable dtMesesPorcentajes = new DataTable();
        private DataTable dtSubServicios = new DataTable();
        DataTable dtDatosVelocidadesUsuaServicios = new DataTable();
        private DataTable dtDatosUsuSer = new DataTable();
        private Servicios_Tarifas_Sub oTarifasSub = new Servicios_Tarifas_Sub();
        private Servicios_Tarifas oServiciosTarifas = new Servicios_Tarifas();
        private Usuarios_Servicios_Novedades oNovedades = new Usuarios_Servicios_Novedades();
        private Comprobantes oComprobantes = new Comprobantes();
        private Comprobantes_Tipo oComprobantesTipo = new Comprobantes_Tipo();
        private Usuarios_Servicios oUsuariosServicios = new Usuarios_Servicios();
        private Servicios oServicios = new Servicios();
        private Servicios_Sub oServiciosSub = new Servicios_Sub();
        private Tipo_Facturacion oTipoFacturacion = new Tipo_Facturacion();
        private Usuarios oUsuarios = new Usuarios();
        private Configuracion oConfig = new Configuracion();
        private Facturacion oFacturacion = new Facturacion();
        private Bonificaciones oBonificaciones = new Bonificaciones();
        private Usuarios_CtaCte oUsuariosCtaCte = new Usuarios_CtaCte();
        private Usuarios_CtaCte_Det oUsuariosCtaCteDet = new Usuarios_CtaCte_Det();
        private Usuarios_Ctacte_Det_Extra oUsuariosCtaCteDetExtra = new Usuarios_Ctacte_Det_Extra();
        private Thread hilo;
        private delegate void myDel();
        private Servicios_Velocidades oServiciosVelocidades = new Servicios_Velocidades();
        private Servicios_Tipos oServicioTipo = new Servicios_Tipos();
        private Notificaciones oNotificacion = new Notificaciones();
        private Notificaciones_Adjuntos oNotificacionAdjuntos = new Notificaciones_Adjuntos();
        private Notificaciones_Destinatarios oNotificacionesDestino = new Notificaciones_Destinatarios();
        private Partes oPartes = new Partes();
        private Servicios_Velocidades oVelocidad = new Servicios_Velocidades();
        private Partes_Solicitudes oFallas = new Partes_Solicitudes();
        private DataTable dtUpdateFechasServiciosSub = new DataTable();
        private Notificaciones_Destinatarios_Aut oNotificacionesDestinatariosAut = new Notificaciones_Destinatarios_Aut();
        private Servicios_Tarifas_Sub_Esp oServiciosTarifasSubEsp = new Servicios_Tarifas_Sub_Esp();
        private int idEstadoServicio = 0, configAgenda = 0;
        private DataTable dtExtras = new DataTable();
        private int contadorRegistroAgregados = 0;

        DialogResult dialogResult;
        private DataTable dtDatosAuxiliaresServicio = new DataTable();
        #endregion

        #region Métodos creados

        private void ComenzarCarga()
        {
            pgCircular.Start();
            hilo = new Thread(new ThreadStart(CargarDatos));
            hilo.IsBackground = true;
            hilo.Start();
        }

        private void CargarDatos()
        {
            try
            {
                if (GeneraDeudas == false)
                {
                    dtDatosUsuario = oUsuarios.Listar(idUsuarioRecibido);
                    contUsuariosServiciosUnicos = 0;
                    DataView dtv = dtUsuariosServicios.DefaultView;
                    dtv.RowFilter = String.Format("id_tipo={0}", Convert.ToInt32(Usuarios_Servicios._TipoItemServicio.SERVICIO_PROPIO));

                    dtUsuariosServicios = dtv.ToTable();
                    if (dtUsuariosServicios.Columns.IndexOf("elige") == -1)
                    {
                        DcElige = new DataColumn("Elige", typeof(bool));
                        DcElige.DefaultValue = false;
                        dtUsuariosServicios.Columns.Add(DcElige);
                    }
                    dtMesesPorcentajes = oBonificaciones.GenerarDtMesesPorcentajes();

                    dtServiciosModalidades = oServicios.ListarModalidades();

                    dtServiciosUnicos = oServicios.ListarPorModalidad(Servicios._Modalidad.UNICO);

                    if (dtUsuariosServicios.Rows.Count > 0)
                    {
                        foreach (DataRow usuarioServicio in dtUsuariosServicios.Rows)
                        {
                            if (Convert.ToInt32(usuarioServicio["id_usuario_servicio"]) > contUsuariosServiciosUnicos)
                                contUsuariosServiciosUnicos = Convert.ToInt32(usuarioServicio["id_usuario_servicio"]);
                        }
                        contUsuariosServiciosUnicos++;
                    }

                    if (dtServiciosUnicos.Rows.Count > 0)
                    {
                        foreach (DataRow servicioUnico in dtServiciosUnicos.Rows)
                        {
                            contUsuariosServiciosUnicos++;
                            DataRow drUsuarioServicio = dtUsuariosServicios.NewRow();
                            drUsuarioServicio["id_tipo"] = 5;
                            drUsuarioServicio["tipo"] = "";
                            drUsuarioServicio["id_usuarios"] = idUsuario;
                            drUsuarioServicio["id_usuario_servicio"] = contUsuariosServiciosUnicos;
                            drUsuarioServicio["id_locacion"] = 0;
                            drUsuarioServicio["servicio"] = servicioUnico["descripcion"].ToString();
                            drUsuarioServicio["servicio_sub"] = "";
                            drUsuarioServicio["servicio_sub_tipo"] = "";
                            drUsuarioServicio["Fecha_Estado"] = DateTime.Now;
                            drUsuarioServicio["Fecha_Inicio"] = DateTime.Now;
                            drUsuarioServicio["Fecha_Fin"] = DateTime.Now;
                            drUsuarioServicio["Fecha_Saldado"] = DateTime.Now;
                            drUsuarioServicio["Fecha_Factura"] = DateTime.Now;
                            drUsuarioServicio["Con_Aviso"] = 0;
                            drUsuarioServicio["Con_Corte"] = 0;
                            drUsuarioServicio["Con_Alarma"] = 0;
                            drUsuarioServicio["cant_bocas"] = 1;
                            drUsuarioServicio["Cant_Bocas_Pac"] = 1;
                            drUsuarioServicio["Meses_Servicio"] = 0;
                            drUsuarioServicio["Meses_Cobro"] = 0;
                            drUsuarioServicio["requiere_equipo"] = "";
                            drUsuarioServicio["requiere_tarjeta"] = "";
                            drUsuarioServicio["requiere_velocidad"] = "";
                            drUsuarioServicio["categoria"] = "";
                            drUsuarioServicio["servicio_tipo"] = servicioUnico["Tipo"].ToString();
                            drUsuarioServicio["estado"] = "";
                            drUsuarioServicio["grupo"] = "";
                            drUsuarioServicio["id_localidad"] = 0;
                            drUsuarioServicio["id_usuarios"] = idUsuario;
                            drUsuarioServicio["id_zona"] = 0;
                            drUsuarioServicio["id_servicio"] = Convert.ToInt32(servicioUnico["id"]);
                            drUsuarioServicio["id_servicio_tipo"] = Convert.ToInt32(servicioUnico["id_servicios_tipos"]);
                            drUsuarioServicio["id_estado"] = 0;
                            drUsuarioServicio["id_tipo_facturacion"] = 0;
                            drUsuarioServicio["id_servicio_sub"] = 0;
                            drUsuarioServicio["id_servicio_sub_tipo"] = 0;
                            drUsuarioServicio["id_usuario_servicio_sub"] = 0;
                            drUsuarioServicio["id_velocidad"] = 0;
                            drUsuarioServicio["id_velocidad_tipo"] = 0;
                            drUsuarioServicio["Id_bonificacion_aplicada"] = 0;
                            drUsuarioServicio["Id_bonificacion_esp"] = 0;
                            drUsuarioServicio["genera_deuda_cortado"] = 0;
                            drUsuarioServicio["genera_deuda_retirado"] = 0;
                            drUsuarioServicio["id_servicio_modalidad"] = servicioUnico["id_servicios_modalidad"];
                            dtUsuariosServicios.Rows.Add(drUsuarioServicio);
                        }
                    }



                    myDel MD = new myDel(AsignarDatos);
                    this.Invoke(MD, new object[] { });
                }
                else
                {
                    myDel MD = new myDel(GenerarDeudas);
                    this.Invoke(MD, new object[] { });
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar Informacion" + ex.Message);
            }
            pgCircular.Stop();
        }

        private void BloquearServiciosCorRet()
        {
            foreach (DataGridViewRow item in dgvUsuariosServicios.Rows)
            {
                if (Convert.ToInt32(item.Cells["genera_deuda_cortado"].Value) == 0 && (Convert.ToInt32(item.Cells["id_estado"].Value) == (int)Servicios.Servicios_Estados.CORTADO))
                {
                    item.DefaultCellStyle.BackColor = Color.WhiteSmoke;
                    item.DefaultCellStyle.ForeColor = Color.DimGray;
                    item.ReadOnly = true;
                    item.Frozen = true;
                    item.Cells["Elige"].Value = false;
                    item.Cells["seleccion"].Value = false;
                }
                if (Convert.ToInt32(item.Cells["genera_deuda_retirado"].Value) == 0 && (Convert.ToInt32(item.Cells["id_estado"].Value) == (int)Servicios.Servicios_Estados.RETIRADO))
                {
                    item.DefaultCellStyle.BackColor = Color.WhiteSmoke;
                    item.DefaultCellStyle.ForeColor = Color.DimGray;
                    item.ReadOnly = true;
                    item.Frozen = true;
                    item.Cells["Elige"].Value = false;
                    item.Cells["seleccion"].Value = false;


                }
            }
        }

        private void AsignarDatos()
        {
            dgvUsuariosServicios.DataSource = null;

            DataColumn DcSeleccion = new DataColumn("seleccion", typeof(bool));
            DcSeleccion.DefaultValue = true;
            dtUsuariosServicios.Columns.Add(DcSeleccion);

            dgvUsuariosServicios.DataSource = dtUsuariosServicios;
            dgvLocaciones.DataSource = dtLocaciones;
            for (int x = 0; x < dgvLocaciones.Columns.Count; x++)
                dgvLocaciones.Columns[x].Visible = false;

            dgvLocaciones.Columns["Calle"].Visible = true;
            dgvLocaciones.Columns["Altura"].Visible = true;
            dgvLocaciones.Columns["Piso"].Visible = true;
            dgvLocaciones.Columns["Depto"].Visible = true;
            dgvLocaciones.Columns["Localidad"].Visible = true;
            if (dgvLocaciones.Rows.Count > 0)
            {
                if (idLocacionRecibidaSeleccionada > 0)
                {
                    int indiceAux = 0;
                    foreach (DataGridViewRow fila in dgvLocaciones.Rows)
                    {
                        if (Convert.ToInt32(dgvLocaciones.Rows[indiceAux].Cells["id"].Value) == idLocacionRecibidaSeleccionada)
                            break;
                        indiceAux++;
                    }
                    dgvLocaciones.Rows[indiceAux].Selected = true;
                }
                else
                    dgvLocaciones.Rows[0].Selected = true;
            }

            ResetearGrillaUsuariosServicios();

            cboServicios_Modalidad.DataSource = dtServiciosModalidades;
            cboServicios_Modalidad.ValueMember = "Id";
            cboServicios_Modalidad.DisplayMember = "Nombre";
            cboServicios_Modalidad.SelectedValue = Servicios._Modalidad.MENSUAL;

            lblTotal.Text = String.Format("Total: ${0}", decimal.Round(TotalFinal));

            try
            {
                dtUsuariosServicios.DefaultView.RowFilter = String.Format("id_locacion={0} and id_servicio_modalidad={1}", idLocacionRecibidaSeleccionada, Convert.ToInt32(Servicios._Modalidad.MENSUAL));
            }
            catch
            {

            }
            lblDatosUsuario.Text = String.Format("{0}, {1} [{2}]{3}Documento: ({4}) Nro.: {5}{6}C.IVA: ({7}) Nro.:{8}", dtDatosUsuario.Rows[0]["apellido"], dtDatosUsuario.Rows[0]["nombre"], dtDatosUsuario.Rows[0]["codigo"], Environment.NewLine, dtDatosUsuario.Rows[0]["tipodoc"], dtDatosUsuario.Rows[0]["numero_documento"], Environment.NewLine, dtDatosUsuario.Rows[0]["descripcion_comprobante"], dtDatosUsuario.Rows[0]["cuit"]);

            BloquearServiciosCorRet();
            lblTotal.Text = String.Format("Total: ${0}", 0);
        }

        private void AgregarServicioMensualOPeriodo()
        {
            decimal importeOriginal = 0;
            decimal importeConDescuento = 0;
            int indexUltimo = -1;
            int mesSiguiente = 0;
            int añoSiguiente = 0;
            int calculoBonificacion;
            int idUsuarioServicio = 0;
            int mesesServicio = 0;
            int mesesCobro = 0;
            int indexUsuarioServicio = 0;
            int idEstadoServicio = 0;
            DataRow drUsuarioServicioSeleccionado;
            DateTime fechaDesde;
            DateTime fechaFactura;
            DataTable dtSubServiciosFiltro = new DataTable();
            DataTable dtImportesRetornados = new DataTable();
            DataTable dtSubFiltroAux = new DataTable();
            DataTable dtMesesPorcentajesAux = oBonificaciones.GenerarDtMesesPorcentajes();
            DataView dtvSubServicios;
            dtUsuariosServiciosSub.Clear();
            if (dgvUsuariosServicios.SelectedRows.Count > 0)
            {
                btnAgregarServicio.Enabled = false;
                importeOriginal = 0;
                importeConDescuento = 0;
                idUsuarioServicio = this.idUsuarioServicio;
                idEstadoServicio = this.idEstadoServicio;
                drUsuarioServicioSeleccionado = dtUsuariosServicios.NewRow();
                fechaFactura = this.fechaFactura;
                dtMesesPorcentajesAux.Clear();
                int y = 0;

                //  for ( int i =0; i<dtUsuariosServicios.Rows.Count; i++)
                //  {
                //      idUsuarioServicio = Convert.ToInt32(dtUsuariosServicios.Rows[i]["id_usuario_servicio"]);
                //  }

                foreach (DataRow usuariosServicios in dtUsuariosServicios.Rows)
                {
                    if (Convert.ToInt32(usuariosServicios["id_usuario_servicio"]) == idUsuarioServicio && Convert.ToInt32(usuariosServicios["id_tipo"]) == Convert.ToInt32(Usuarios_Servicios._TipoItemServicio.SERVICIO_PROPIO) && usuariosServicios["seleccion"].ToString() == "True")
                    {
                        drUsuarioServicioSeleccionado = usuariosServicios;
                        indexUsuarioServicio = y;
                        break;
                    }
                    y++;
                }

                mesesCobro = Convert.ToInt32(drUsuarioServicioSeleccionado["meses_cobro"]);
                if (mesesCobro == 0)
                    mesesCobro = 1;
                mesesServicio = Convert.ToInt32(drUsuarioServicioSeleccionado["meses_servicio"]);
                if (mesesServicio == 0)
                    mesesServicio = 1;

                fechaComenzarMovimiento = fechaFactura.AddDays(1);
                fechaDesde = fechaComenzarMovimiento;
                if (DateTime.Compare(fechaDesde, DateTime.Now.Date) >= 0)
                    oServiciosTarifas.Fecha_Actual = DateTime.Now;
                else
                    oServiciosTarifas.Fecha_Actual = fechaComenzarMovimiento;


                idTarifaActual = oServiciosTarifas.getTarifa();

                if (idTarifaActual > 0)
                {
                    dtUsuariosServiciosSub.Clear();
                    if (idEstadoServicio == Convert.ToInt16(Servicios.Servicios_Estados.CONECTADO) || idEstadoServicio == Convert.ToInt16(Servicios.Servicios_Estados.SIN_CONECTAR) || idEstadoServicio == Convert.ToInt16(Servicios.Servicios_Estados.EN_ESPERA))
                        dtUsuariosServiciosSub = oFacturacion.RetornarSubServicios(idTarifaActual, idUsuario, fechaComenzarMovimiento, false, true);//trae los subservicios del usuario     
                    else
                        dtUsuariosServiciosSub = oFacturacion.RetornarSubServicios(idTarifaActual, idUsuario, fechaComenzarMovimiento, true, true);

                    oBonificaciones.TraerImportesOriginales(idTarifaActual, dtUsuariosServiciosSub);//actualiza la tabla dtusuarioserviciossub con datos de importes originales, meses de cobro y meses de servicio

                    try
                    {
                        if (idEstadoServicio == Convert.ToInt16(Servicios.Servicios_Estados.CONECTADO) || idEstadoServicio == Convert.ToInt16(Servicios.Servicios_Estados.SIN_CONECTAR) || idEstadoServicio == Convert.ToInt16(Servicios.Servicios_Estados.EN_ESPERA))
                            calculoBonificacion = oUsuarios.traerUsuario(idUsuario).Calculo_Bonificacion;
                        else
                            calculoBonificacion = Convert.ToUInt16(Usuarios._Calculo_Bonificacion.NO_SE_APLICA);
                    }
                    catch
                    {
                        calculoBonificacion = Convert.ToUInt16(Usuarios._Calculo_Bonificacion.NO_SE_APLICA);
                    }//determina si para el usuario del usuario_servicio seleccionado se aplica o no el cálculo de bonificaciones



                    for (int x = 0; x < Convert.ToInt32(cmbcantperiodos.Text); x++)
                    {
                        dtMesesPorcentajesAux.Clear();
                        DataView dtvAuxilar;
                        foreach (DataRow subServicio in dtUsuariosServiciosSub.Rows)//setea la fecha a partir de la cual se generarán las nuevas deudas
                            subServicio["fecha_inicio_servicio"] = fechaComenzarMovimiento;

                        if (calculoBonificacion == Convert.ToUInt16(Usuarios._Calculo_Bonificacion.NO_SE_APLICA))
                        {
                            dtvAuxilar = new DataView(dtUsuariosServiciosSub);
                            dtvAuxilar.RowFilter = String.Format("fecha_factura<'{0}' and id_usuario_servicio={1}", fechaComenzarMovimiento.Date.ToString("yyyy-MM-dd"), idUsuarioServicio);
                            dtUsuariosServiciosSub = dtvAuxilar.ToTable();//sólo deja en la tabla de subservicios, aquellos cuya fecha_factura es menor a la fecha consultada
                            oBonificaciones.TraerImportesOriginales(idTarifaActual, dtUsuariosServiciosSub);
                            oBonificaciones.SetearFechasYModalidadVacios(dtUsuariosServiciosSub);
                            dtMesesPorcentajesAux = oBonificaciones.GenerarTablaRegistrosCtaCteDet(dtUsuariosServiciosSub);//genera los meses de cobro por cada subservicio
                            oBonificaciones.SetearPorcentajeImporteParcial(dtMesesPorcentajesAux);
                            //oBonificaciones.AgregarMontoIpFija(dtUsuariosServiciosSub, dtMesesPorcentajesAux);
                            oBonificaciones.RecalcularImportes(dtUsuariosServiciosSub, dtMesesPorcentajesAux, false);
                        }
                        else
                        {
                            oFacturacion.AgregarSubServiciosHeredados(dtUsuariosServiciosSub);//agrega los subservicios heredados correspondientes
                            if (calculoBonificacion == Convert.ToInt32(Usuarios._Calculo_Bonificacion.POR_LOCACION))
                            {
                                dtvAuxilar = new DataView(dtUsuariosServiciosSub);
                                dtvAuxilar.RowFilter = String.Format("id_usuarios_locaciones={0}", Convert.ToInt32(dgvUsuariosServicios.SelectedRows[0].Cells["id_locacion"].Value));
                                dtUsuariosServiciosSub = dtvAuxilar.ToTable();
                            }

                            if (oBonificaciones.CalcularBonificaciones(dtUsuariosServiciosSub, idTarifaActual, false, 0, false))
                            {
                                dtUsuariosServiciosSub = Bonificaciones.dtSubServicios;
                                dtMesesPorcentajesAux = Bonificaciones.dtSubServiciosDetalles;
                            }

                        }

                        dtImportesRetornados.Clear();

                        if (dtUsuariosServiciosSub.Rows.Count > 0)
                        {
                            dtvAuxilar = new DataView(dtUsuariosServiciosSub);
                            dtvAuxilar.RowFilter = String.Format("fecha_factura<'{0}' and id_usuario_servicio={1}", fechaComenzarMovimiento.Date.ToString("yyyy-MM-dd"), idUsuarioServicio);
                            dtImportesRetornados = oFacturacion.AplicarNovedades(dtvAuxilar.ToTable(), dtMesesPorcentajesAux, Convert.ToInt32(dgvLocaciones.SelectedRows[0].Cells["id"].Value), fechaComenzarMovimiento, false);
                            if (dtExtras.Rows.Count == 0)
                                dtExtras = oFacturacion.dtExtras.Copy();
                            else
                            {
                                foreach (DataRow fila in oFacturacion.dtExtras.Rows)
                                    dtExtras.ImportRow(fila);
                            }


                            try
                            {
                                importeOriginal = importeOriginal + Convert.ToDecimal(dtImportesRetornados.Rows[0]["importe_original_total"]);
                                importeConDescuento = importeConDescuento + Convert.ToDecimal(dtImportesRetornados.Rows[0]["importe_con_descuento_total"]);
                            }
                            catch
                            {
                                importeOriginal += 0;
                                importeConDescuento += 0;
                            }
                            fechaComenzarMovimiento = fechaComenzarMovimiento.AddMonths(mesesCobro);
                            foreach (DataRow fila in dtMesesPorcentajesAux.Select("id_usuarios_servicios='" + idUsuarioServicio + "'"))
                            {
                                for (int i = 0; i < dtUsuariosServiciosSub.Rows.Count; i++) //asignacion de subservicio
                                {
                                    if (Convert.ToInt32(fila["id_usuarios_servicios_sub"]) == Convert.ToInt32(dtUsuariosServiciosSub.Rows[i]["id_usuario_servicio_sub"]))
                                        fila["subservicio"] = dtUsuariosServiciosSub.Rows[i]["subservicio"].ToString();
                                }
                                fila["indice"] = contadorRegistroAgregados;
                                dtMesesPorcentajes.ImportRow(fila);
                            }

                            dtMesesPorcentajes.AcceptChanges();
                            if (dtSubServicios.Rows.Count == 0)
                                dtSubServicios = dtUsuariosServiciosSub.Copy();
                            else
                            {
                                foreach (DataRow fila in dtUsuariosServiciosSub.Rows)
                                    dtSubServicios.ImportRow(fila);
                            }

                        }
                        else
                            MessageBox.Show("El servicio no se encuentra definido para la tarifa consultada.");
                    }

                    if (importeOriginal == 0)
                        dialogResult = MessageBox.Show("El importe del movimiento a generar es de $0. Puede que esto se deba a tarifas no definidas. ¿Quiere agregarlo de todas formas?.", "", MessageBoxButtons.YesNo);

                    if (importeOriginal > 0 || dialogResult == DialogResult.Yes)
                    {
                        DateTime datetimeAux = new DateTime();
                        foreach (DataRow fila in dtMesesPorcentajesAux.Select("id_usuarios_servicios='" + idUsuarioServicio + "'"))
                        {
                            if (datetimeAux.Year < 1900)
                                datetimeAux = Convert.ToDateTime(fila["fecha_hasta"]);
                            else
                            {
                                if (DateTime.Compare(datetimeAux, Convert.ToDateTime(fila["fecha_hasta"])) == -1)
                                    datetimeAux = Convert.ToDateTime(fila["fecha_hasta"]);
                            }
                        }
                        dtDatosAuxiliaresServicio.Clear();
                        dtDatosAuxiliaresServicio = oUsuariosServicios.Traer_datos_usuarios_servicios(idUsuarioServicio);
                        dtMovimientosAGenerar.Rows.Add(servicioNombre, idUsuario, dgvLocaciones.SelectedRows[0].Cells["id"].Value.ToString(), decimal.Round(importeOriginal, 2), decimal.Round(importeConDescuento, 2), fechaDesde.ToString("dd/MM/yyyy"), datetimeAux.ToString("dd/MM/yyyy"), cmbcantperiodos.Text.ToString(), idUsuarioServicio.ToString(), idModalidad.ToString(), "0", dtDatosAuxiliaresServicio.Rows[0]["corteautomatico"], idEstadoServicio.ToString(), contadorRegistroAgregados);
                        contadorRegistroAgregados++;
                        indexUltimo = dtMovimientosAGenerar.Rows.Count - 1;
                        dtUsuariosServicios.Rows[indexUsuarioServicio]["fecha_factura"] = datetimeAux.ToString("dd/MM/yyyy");
                        //dgvUsuariosServicios.SelectedRows[0].Cells["fecha_factura"].Value = fechaDesde.AddMonths((mesesServicio * Convert.ToInt32(cmbcantperiodos.Text))).AddDays(-1).ToString("dd/MM/yyyy");
                        dtUsuariosServicios.AcceptChanges();
                        SetearUltimoRegistroMovimientoGrilla(idUsuarioServicio);
                        ActualizarImporteTotal();
                        ResetearGrillaMovimientos();
                    }
                    ResetearGrillaUsuariosServicios();
                }
                else
                    MessageBox.Show("No hay tarifas asignadas en el rango de fechas del servicio.");
                btnAgregarServicio.Enabled = true;
            }
            else
                MessageBox.Show("No ha seleccionado un servicio.");
        }

        private void ResetearGrillaMovimientos()
        {
            dgvMovimientosAGenerar.DataSource = null;
            dgvMovimientosAGenerar.DataSource = dtMovimientosAGenerar;

            for (int x = 0; x < dgvMovimientosAGenerar.Columns.Count; x++)
                dgvMovimientosAGenerar.Columns[x].Visible = false;

            dgvMovimientosAGenerar.Columns["Servicio"].Visible = true;
            dgvMovimientosAGenerar.Columns["importe_original"].Visible = true;
            dgvMovimientosAGenerar.Columns["importe_con_descuento"].Visible = true;
            dgvMovimientosAGenerar.Columns["fecha_desde"].Visible = true;
            dgvMovimientosAGenerar.Columns["fecha_hasta"].Visible = true;
            dgvMovimientosAGenerar.Columns["cantidad_periodos"].Visible = true;

            dgvMovimientosAGenerar.Columns["importe_original"].HeaderText = "Importe original";
            dgvMovimientosAGenerar.Columns["importe_con_descuento"].HeaderText = "Importe con descuento";
            dgvMovimientosAGenerar.Columns["fecha_desde"].HeaderText = "Desde";
            dgvMovimientosAGenerar.Columns["fecha_hasta"].HeaderText = "Hasta";
            dgvMovimientosAGenerar.Columns["cantidad_periodos"].HeaderText = "Cantidad de periodos";

            dgvMovimientosAGenerar.Columns["importe_original"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvMovimientosAGenerar.Columns["importe_con_descuento"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvMovimientosAGenerar.Columns["cantidad_periodos"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvMovimientosAGenerar.Columns["fecha_desde"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvMovimientosAGenerar.Columns["fecha_hasta"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void GenerarDeudas()
        {
            int reconexionGenerada = 0;
            idModulo = 0;
            drDatosComprobanteVenta = oComprobantesTipo.GetNumeracion(Convert.ToInt32(Comprobantes_Tipo.Tipo.COMPROBANTE_DEUDA), Puntos_Cobros.Id_Punto);
            nComprobante = Convert.ToInt32(drDatosComprobanteVenta["numComprobante"]);

            if (nComprobante > 0)
                oComprobantesTipo.SetNumeracion(Convert.ToInt32(drDatosComprobanteVenta["idPuntoVenta"]), Convert.ToInt32(Comprobantes_Tipo.Tipo.COMPROBANTE_DEUDA), nComprobante);

            oComprobantes.Id_Usuarios = idUsuario;
            oComprobantes.Fecha = DateTime.Today;
            oComprobantes.Punto_Venta = Convert.ToInt32(drDatosComprobanteVenta["numPuntoVenta"]);
            oComprobantes.Id_Comprobantes_Tipo = Convert.ToInt32(Comprobantes_Tipo.Tipo.COMPROBANTE_DEUDA);
            oComprobantes.Numero = nComprobante;
            oComprobantes.Importe = 0;

            foreach (DataRow detalle in dtMovimientosAGenerar.Rows)
                oComprobantes.Importe += Convert.ToDecimal(detalle["importe_con_descuento"]);

            oComprobantes.Id_Usuarios_Locaciones = Convert.ToInt32(dtMovimientosAGenerar.Rows[0]["id_locacion"]);
            oComprobantes.Id_Personal = Personal.Id_Login;
            oComprobantes.Id = oComprobantes.Guardar(oComprobantes);

            oUsuariosCtaCte.Id_Usuarios = oComprobantes.Id_Usuarios;
            oUsuariosCtaCte.Id_Comprobantes = oComprobantes.Id;
            oUsuariosCtaCte.Fecha_Movimiento = DateTime.Today;
            oUsuariosCtaCte.Numero = oComprobantes.Numero.ToString();
            oUsuariosCtaCte.Fecha_Desde = Convert.ToDateTime(dtMovimientosAGenerar.Rows[0]["fecha_desde"]);
            oUsuariosCtaCte.Fecha_Hasta = Convert.ToDateTime(dtMovimientosAGenerar.Rows[dtMovimientosAGenerar.Rows.Count - 1]["fecha_hasta"]);
            string muestra;
            char pad = '0';
            muestra = "COMPROBANTE DE DEUDA " + Convert.ToInt32(drDatosComprobanteVenta["numPuntoVenta"]).ToString().PadLeft(4, pad) + "-" + oUsuariosCtaCte.Numero.ToString().PadLeft(8, pad);
            oUsuariosCtaCte.Descripcion = muestra;
            oUsuariosCtaCte.Importe_Original = 0;
            foreach (DataRow detalle in dtMovimientosAGenerar.Rows)
                oUsuariosCtaCte.Importe_Original += Convert.ToDecimal(detalle["importe_original"]);
            oUsuariosCtaCte.Importe_Punitorio = 0;
            oUsuariosCtaCte.Importe_Bonificacion = oUsuariosCtaCte.Importe_Original - oComprobantes.Importe;
            oUsuariosCtaCte.Importe_Final = oComprobantes.Importe;
            oUsuariosCtaCte.Importe_Saldo = oUsuariosCtaCte.Importe_Final;
            oUsuariosCtaCte.Id_Usuarios_Locacion = oComprobantes.Id_Usuarios_Locaciones;
            oUsuariosCtaCte.Numero = oComprobantes.Numero.ToString();
            oUsuariosCtaCte.Id_Comprobantes_Tipo = Convert.ToInt32(Comprobantes_Tipo.Tipo.COMPROBANTE_DEUDA);
            oUsuariosCtaCte.Id_Comprobantes_Ref = 0;
            oUsuariosCtaCte.Id_Facturacion = 0;
            oUsuariosCtaCte.Generado_facturacion_mensual = Convert.ToInt32(Usuarios_CtaCte.GENERADO_FACTURACION_MENSUAL.NO);
            oUsuariosCtaCte.Id_Personal = Personal.Id_Login;
            oUsuariosCtaCte.Id_Origen = (int)Usuarios_CtaCte.ORIGEN.COMPROBANTE_MANUAL;
            oUsuariosCtaCte.Percepcion = 1;
            idCtaCteGlobal = oUsuariosCtaCte.Guardar(oUsuariosCtaCte);

            DataRow drDatosSubServicio = dtSubServicios.NewRow();
            int indiceRegistros = 0;
            foreach (DataRow detalle in dtMovimientosAGenerar.Rows)
            {
                indiceRegistros++;
                listaSubServicios.Clear();
                dtUpdateFechasServiciosSub.Clear();

                foreach (DataRow mes in dtMesesPorcentajes.Rows)
                {
                    Int32 usuServicioDetalle = Convert.ToInt32(detalle["id_usuario_servicio"]);
                    Int32 usuServicioMes = Convert.ToInt32(mes["id_usuarios_servicios"]);
                    Int32 borradoMes = Convert.ToInt32(mes["borrado"]);
                    DateTime fechaDesdeMes = Convert.ToDateTime(mes["fecha_desde"]);
                    DateTime fechaDesdeDetalle = Convert.ToDateTime(detalle["fecha_desde"]);
                    DateTime fechaHastaMes = Convert.ToDateTime(mes["fecha_desde"]);
                    DateTime fechaHastaDetalle = Convert.ToDateTime(detalle["fecha_hasta"]);
                    if (Convert.ToInt32(mes["id_servicios_modalidad"]) != Convert.ToInt32(Servicios._Modalidad.UNICO))
                    {
                        if ((usuServicioMes == usuServicioDetalle) && (borradoMes == 0) && (fechaDesdeMes >= fechaDesdeDetalle) && (fechaHastaMes <= fechaHastaDetalle))
                        {
                            drDatosSubServicio = dtSubServicios.Select("id_usuario_servicio_sub='" + mes["id_usuarios_servicios_sub"] + "'")[0];
                            listaSubServicios.Add(Convert.ToInt32(mes["id_usuarios_servicios"]));
                            oUsuariosCtaCteDet.Id_Usuarios_CtaCte = oUsuariosCtaCte.Id;
                            oUsuariosCtaCteDet.Id_Usuarios_Locaciones = oUsuariosCtaCte.Id_Usuarios_Locacion;
                            oUsuariosCtaCteDet.Id_Zonas = Convert.ToInt32(drDatosSubServicio["id_tipo_facturacion"]);
                            oUsuariosCtaCteDet.Id_Servicios = Convert.ToInt32(drDatosSubServicio["id_servicio"]);
                            oUsuariosCtaCteDet.Id_Tipo = Convert.ToInt32(drDatosSubServicio["id_servicio_sub"]);
                            oUsuariosCtaCteDet.Tipo = drDatosSubServicio["tipo_servicio_sub"].ToString();
                            oUsuariosCtaCteDet.Importe_Original = Convert.ToDecimal(mes["importe_original"]);
                            oUsuariosCtaCteDet.Importe_Punitorio = 0;
                            oUsuariosCtaCteDet.Importe_Saldo = Convert.ToDecimal(mes["importe_con_descuento"]);
                            oUsuariosCtaCteDet.Importe_Final = Convert.ToDecimal(mes["importe_con_descuento"]);
                            oUsuariosCtaCteDet.Importe_Bonificacion = oUsuariosCtaCteDet.Importe_Original - Convert.ToDecimal(mes["importe_con_descuento"]);
                            oUsuariosCtaCteDet.Id_Usuarios_Servicios = Convert.ToInt32(mes["id_usuarios_servicios"]);
                            oUsuariosCtaCteDet.Id_Velocidades_Tip = Convert.ToInt32(drDatosSubServicio["id_velocidad_tipo"]);
                            oUsuariosCtaCteDet.Id_Velocidades = Convert.ToInt32(drDatosSubServicio["id_velocidad"]);
                            oUsuariosCtaCteDet.Requiere_IP = Convert.ToInt32(drDatosSubServicio["requiere_ip"]);
                            oUsuariosCtaCteDet.Cantidad_Periodos = Convert.ToInt32(cmbcantperiodos.Text);
                            oUsuariosCtaCteDet.Id_Usuarios_Servicios_sub = Convert.ToInt32(drDatosSubServicio["id_usuario_servicio_sub"]);
                            oUsuariosCtaCteDet.Fecha_Desde = Convert.ToDateTime(mes["fecha_desde"]);
                            oUsuariosCtaCteDet.Fecha_Hasta = Convert.ToDateTime(mes["fecha_hasta"]);
                            if (mes["nombre_bonificacion"].ToString().ToLower() == "novedades")
                                oUsuariosCtaCteDet.Id_Tipo_Registro_Cta_Cte_Det = (int)Usuarios_CtaCte_Det.TIPO_REGISTRO_CTACTEDET.NOVEDAD;
                            else
                                oUsuariosCtaCteDet.Id_Tipo_Registro_Cta_Cte_Det = (int)Usuarios_CtaCte_Det.TIPO_REGISTRO_CTACTEDET.DETALLE;
                            oUsuariosCtaCteDet.Id_bonificacion_Aplicada = Convert.ToInt32(mes["id_bonificacion"].ToString());
                            oUsuariosCtaCteDet.Porcentaje_Bonificacion = Convert.ToDecimal(mes["porcentaje"].ToString());
                            oUsuariosCtaCteDet.Nombre_Bonificacion = Convert.ToString(mes["nombre_bonificacion"]);
                            oUsuariosCtaCteDet.Periodo_Mes = Convert.ToDateTime(mes["fecha_desde"]).Month;
                            oUsuariosCtaCteDet.Periodo_Ano = Convert.ToDateTime(mes["fecha_desde"]).Year;

                            if (mes["nombre_bonificacion"].Equals("Novedades"))
                            {
                                oUsuariosCtaCteDet.Detalles = mes["detalle_contratacion"].ToString();
                                oUsuariosCtaCteDet.Id_Tipo_Registro_Cta_Cte_Det = (int)Usuarios_CtaCte_Det.TIPO_REGISTRO_CTACTEDET.NOVEDAD;
                            }
                            else
                                oUsuariosCtaCteDet.Detalles = "";
                            oUsuariosCtaCteDet.Guardar(oUsuariosCtaCteDet);

                            if (dtUpdateFechasServiciosSub.Select(String.Format("idUsuarioServicioSub={0}", oUsuariosCtaCteDet.Id_Usuarios_Servicios_sub)).Length == 0)
                                dtUpdateFechasServiciosSub.Rows.Add(oUsuariosCtaCteDet.Id_Usuarios_Servicios_sub.ToString(), oUsuariosCtaCteDet.Fecha_Desde.ToString(), oUsuariosCtaCteDet.Fecha_Hasta.ToString());
                            else
                            {
                                foreach (DataRow fila in dtUpdateFechasServiciosSub.Rows)
                                {
                                    if (Convert.ToInt32(fila["idUsuarioServicioSub"]) == oUsuariosCtaCteDet.Id_Usuarios_Servicios_sub)
                                        fila["fechafin"] = oUsuariosCtaCteDet.Fecha_Hasta.ToString();
                                }
                            }

                            if (oUsuariosCtaCteDet.Id > 0)
                            {
                                if (Convert.ToInt32(mes["id_bonificacion"]) > 0)
                                {
                                    oUsuariosCtaCteDetExtra.Id_Extra = Convert.ToInt32(mes["id_bonificacion"]);
                                    oUsuariosCtaCteDetExtra.Id_Tipo_Extra = Convert.ToInt32(Usuarios_Ctacte_Det_Extra.TiposExtras.BONIFICACION);
                                    oUsuariosCtaCteDetExtra.Id_Usuarios_CtaCte_Det = oUsuariosCtaCteDet.Id;
                                    oUsuariosCtaCteDetExtra.Porcentaje = Convert.ToDecimal(mes["porcentaje_parcial"]);
                                    oUsuariosCtaCteDetExtra.Importe_original = Convert.ToDecimal(mes["importe_original"]);
                                    if (Convert.ToInt32(mes["id_bonificacion_contratacion"]) > 0)
                                        oUsuariosCtaCteDetExtra.Importe_Nuevo = Convert.ToDecimal(mes["importe_con_descuento_parcial"]);
                                    else
                                        oUsuariosCtaCteDetExtra.Importe_Nuevo = Convert.ToDecimal(mes["importe_con_descuento"]);
                                    oUsuariosCtaCteDetExtra.Detalle = mes["nombre_bonificacion"].ToString();
                                    oUsuariosCtaCteDetExtra.Extra = String.Empty;
                                    oUsuariosCtaCteDetExtra.Guardar(oUsuariosCtaCteDetExtra);
                                }
                                if (dtExtras != null && dtExtras.Rows.Count > 0)
                                {
                                    DataView dv = dtExtras.DefaultView;
                                    int idUsuSub = Convert.ToInt32(mes["id_usuarios_servicios_sub"]);
                                    int mesaux = Convert.ToInt32(mes["nro_mes"]);
                                    dv.RowFilter = String.Format("id_usuario_servicio_sub={0} and nro_mes={1}", idUsuSub, mesaux);
                                    DataTable dt = dv.ToTable();

                                    foreach (DataRow drExtra in dt.Rows)
                                    {
                                        oUsuariosCtaCteDetExtra.Id_Extra = Convert.ToInt32(drExtra["id_extra"]);
                                        oUsuariosCtaCteDetExtra.Id_Tipo_Extra = Convert.ToInt32(drExtra["id_tipo_extra"]);
                                        oUsuariosCtaCteDetExtra.Id_Usuarios_CtaCte_Det = oUsuariosCtaCteDet.Id;
                                        oUsuariosCtaCteDetExtra.Porcentaje = Convert.ToDecimal(drExtra["porcentaje"]);
                                        oUsuariosCtaCteDetExtra.Importe_original = Convert.ToDecimal(drExtra["importe_original"]);
                                        oUsuariosCtaCteDetExtra.Importe_Nuevo = Convert.ToDecimal(drExtra["importe_nuevo"]);
                                        oUsuariosCtaCteDetExtra.Detalle = drExtra["detalle"].ToString();
                                        oUsuariosCtaCteDetExtra.Extra = drExtra["descripcion_extra"].ToString();
                                        oUsuariosCtaCteDetExtra.Guardar(oUsuariosCtaCteDetExtra);
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        if (Convert.ToInt32(mes["id_usuarios_servicios"]) == Convert.ToInt32(detalle["id_usuario_servicio"]) && Convert.ToInt32(mes["id_usuarios_servicios_sub_contratacion"]) == indiceRegistros)
                        {

                            oUsuariosCtaCteDet.Id_Usuarios_CtaCte = oUsuariosCtaCte.Id;
                            oUsuariosCtaCteDet.Id_Usuarios_Locaciones = oUsuariosCtaCte.Id_Usuarios_Locacion;
                            oUsuariosCtaCteDet.Id_Zonas = 0;
                            oUsuariosCtaCteDet.Id_Servicios = Convert.ToInt32(mes["id_servicios"]);
                            oUsuariosCtaCteDet.Id_Tipo = Convert.ToInt32(mes["id_usuarios_servicios_sub"]);
                            oUsuariosCtaCteDet.Tipo = "S";
                            oUsuariosCtaCteDet.Importe_Original = Convert.ToDecimal(mes["importe_original"]);
                            oUsuariosCtaCteDet.Importe_Punitorio = 0;
                            oUsuariosCtaCteDet.Importe_Saldo = Convert.ToDecimal(mes["importe_con_descuento"]);
                            oUsuariosCtaCteDet.Importe_Final = Convert.ToDecimal(mes["importe_con_descuento"]);
                            oUsuariosCtaCteDet.Importe_Bonificacion = oUsuariosCtaCteDet.Importe_Original - Convert.ToDecimal(mes["importe_con_descuento"]);
                            oUsuariosCtaCteDet.Id_Usuarios_Servicios = Convert.ToInt32(mes["id_usuarios_servicios"]);
                            oUsuariosCtaCteDet.Id_Velocidades_Tip = 0;
                            oUsuariosCtaCteDet.Id_Velocidades = 0;
                            oUsuariosCtaCteDet.Requiere_IP = 0;
                            oUsuariosCtaCteDet.Cantidad_Periodos = Convert.ToInt32(cmbcantperiodos.Text);
                            oUsuariosCtaCteDet.Id_Usuarios_Servicios_sub = 0;
                            oUsuariosCtaCteDet.Fecha_Desde = Convert.ToDateTime(mes["fecha_desde"]);
                            oUsuariosCtaCteDet.Fecha_Hasta = Convert.ToDateTime(mes["fecha_hasta"]);
                            oUsuariosCtaCteDet.Detalles = mes["detalle_contratacion"].ToString();
                            if (mes["nombre_bonificacion"].ToString().ToLower() == "novedades")
                                oUsuariosCtaCteDet.Id_Tipo_Registro_Cta_Cte_Det = (int)Usuarios_CtaCte_Det.TIPO_REGISTRO_CTACTEDET.NOVEDAD;
                            else
                                oUsuariosCtaCteDet.Id_Tipo_Registro_Cta_Cte_Det = (int)Usuarios_CtaCte_Det.TIPO_REGISTRO_CTACTEDET.DETALLE;
                            oUsuariosCtaCteDet.Id_bonificacion_Aplicada = Convert.ToInt32(mes["id_bonificacion"].ToString());
                            oUsuariosCtaCteDet.Porcentaje_Bonificacion = Convert.ToDecimal(mes["porcentaje"].ToString());
                            oUsuariosCtaCteDet.Nombre_Bonificacion = Convert.ToString(mes["nombre_bonificacion"]);
                            oUsuariosCtaCteDet.Periodo_Mes = Convert.ToDateTime(mes["fecha_desde"]).Month;
                            oUsuariosCtaCteDet.Periodo_Ano = Convert.ToDateTime(mes["fecha_desde"]).Year;
                            //oUsuariosCtaCteDet.Detalles = mes["detalle"].ToString();
                            oUsuariosCtaCteDet.Guardar(oUsuariosCtaCteDet);
                        }
                    }
                }
                configAgenda = oConfig.GetValor_N("Agenda_Trabajo");

                int idModalidad = Convert.ToInt32(detalle["id_modalidad"]);
                int idEstado = Convert.ToInt32(detalle["estado_servicio"]);
                int postdatado = 0;

                int idUsuarioServicio = Convert.ToInt32(detalle["id_usuario_servicio"]);

                int idServicio = Convert.ToInt32(dtUsuariosServicios.Select(String.Format("id_usuario_servicio='{0}'", idUsuarioServicio.ToString()))[0]["id_servicio"]);
                string servicioNombre = dtUsuariosServicios.Select(String.Format("id_usuario_servicio='{0}'", idUsuarioServicio.ToString()))[0]["servicio"].ToString();
                int idTipoServicio = Convert.ToInt32(dtUsuariosServicios.Select(String.Format("id_usuario_servicio='{0}'", idUsuarioServicio.ToString()))[0]["id_servicio_tipo"]);
                idModalidad = Convert.ToInt32(dtUsuariosServicios.Select(String.Format("id_usuario_servicio='{0}'", idUsuarioServicio.ToString()))[0]["id_servicio_modalidad"]);
                int idTipoFac = Convert.ToInt32(dtUsuariosServicios.Select(String.Format("id_usuario_servicio='{0}'", idUsuarioServicio.ToString()))[0]["id_tipo_facturacion"]);

                generaGestionAppexternas();

                if (idModalidad != Convert.ToInt32(Servicios._Modalidad.UNICO))
                {
                    oUsuariosServicios.Fecha_Factura = oUsuariosCtaCte.Fecha_Hasta;
                    oUsuariosServicios.Fecha_Factura_Desde = oUsuariosCtaCte.Fecha_Desde;
                    oUsuariosServicios.Actualizar_fecha_facturado(Convert.ToInt32(detalle["id_usuario_servicio"]));
                    foreach (DataRow usuarioServicioSub in dtUpdateFechasServiciosSub.Rows)
                    {                           
                        if(idModalidad == (int)Servicios._Modalidad.DIA)
                            oFacturacion.ActualizarFechaFacturaSubServicioPrepago(Convert.ToInt32(usuarioServicioSub["idUsuarioServicioSub"]), Convert.ToDateTime(usuarioServicioSub["fechaFin"]),Convert.ToDateTime(usuarioServicioSub["fechainicio"]));
                        else
                            oFacturacion.ActualizarFechaFacturaSubServicio(Convert.ToInt32(usuarioServicioSub["idUsuarioServicioSub"]), Convert.ToDateTime(usuarioServicioSub["fechaFin"]));
                    }
                       
                }

                if ((idModalidad == Convert.ToInt32(Servicios._Modalidad.DIA) || idModalidad == Convert.ToInt32(Servicios._Modalidad.PERIODO_CERRADO_POR_DIA) || idModalidad == Convert.ToInt32(Servicios._Modalidad.PERIODO_CERRADO_POR_MES)) && (idEstado == Convert.ToInt16(Servicios.Servicios_Estados.CORTADO) || idEstado == Convert.ToInt16(Servicios.Servicios_Estados.RETIRADO)))
                {
                    if (Convert.ToInt16(detalle["corte_automatico"]) == 0)
                    {
                        DataTable dtFallas = new DataTable();
                        dtFallas = oFallas.Traer_Por_Tipo_Servicio(idTipoServicio);
                        DataRow[] drFalla = dtFallas.Select("id_partes_operaciones=2");
                        int idFalla = Convert.ToInt32(drFalla[0]["id"]);
                        oPartes.Id_Servicios = idServicio;
                        oPartes.Id_Usuarios_Servicios = idUsuarioServicio;
                        oPartes.Id_Usuarios = idUsuario;
                        oPartes.Id_Usuarios_Locaciones = Convert.ToInt32(dgvLocaciones.SelectedRows[0].Cells["id"].Value);

                        oPartes.Id_Zonas = idTipoFac;
                        oPartes.Id_Partes_Fallas = idFalla;
                        oPartes.Id_Partes_Soluciones = 0;
                        oPartes.Id_Partes_Estados = Convert.ToInt32(Partes.Partes_Estados.PENDIENTE_DE_ASIGNACION_DE_TECNICO);
                        oPartes.Id_Tecnico = 0;

                        oPartes.Id_Movil = 0;
                        oPartes.Id_Operadores = Personal.Id_Login;
                        oPartes.Id_Areas = Personal.Id_Area;
                        oPartes.Fecha_Programado = fechaDesde;
                        oPartes.Fecha_Reclamo = DateTime.Now;
                        oPartes.Detalle_Falla = drFalla[0]["nombre"].ToString();
                        oPartes.Detalle_Solucion = "";
                        oPartes.Id_Usuarios_Cuenta_Corriente = 0;
                        oPartes.Id = oPartes.Guardar(oPartes, 1);
                        oUsuariosServicios.ActualizarEstado(idUsuarioServicio, Convert.ToInt32(Servicios.Servicios_Estados.SIN_CONECTAR));
                    }
                    else
                    {
                        DataTable dtPartesParaHacer = oPartes.Get_Estructura_Partes();
                        DataTable dtPartesGenerados = new DataTable();
                        DataTable dtFallas = new DataTable();
                        dtFallas = oFallas.Traer_Por_Tipo_Servicio(idTipoServicio);
                        DataRow[] drFalla = dtFallas.Select("id_partes_operaciones=2");
                        int idFalla = Convert.ToInt32(drFalla[0]["id"]);
                        DataRow drParte = dtPartesParaHacer.NewRow();
                        drParte["Id_Usuarios"] = idUsuario;
                        drParte["Id_Usuarios_Servicios"] = idUsuarioServicio;
                        drParte["Id_Servicios"] = idServicio;
                        drParte["Id_Usuarios_Locaciones"] = Convert.ToInt32(dgvLocaciones.SelectedRows[0].Cells["id"].Value);
                        drParte["Id_Zonas"] = idTipoFac;
                        drParte["Id_Partes_Fallas"] = idFalla;
                        drParte["Id_Partes_Soluciones"] = 0;
                        drParte["Id_Movil"] = 0;
                        drParte["Id_Tecnico"] = 0;
                        if (configAgenda == Convert.ToInt32(Agenda_Encabezado.Uso_agenda.TRABAJA_CON_AGENDA))
                        {
                            if ((idModalidad == Convert.ToInt32(Servicios._Modalidad.DIA) || idModalidad == Convert.ToInt32(Servicios._Modalidad.PERIODO_CERRADO_POR_DIA)))
                            {
                                if (DateTime.Compare(DateTime.Now, Convert.ToDateTime(detalle["fecha_desde"])) < 0)
                                {
                                    drParte["Id_Partes_Estados"] = Convert.ToInt16(Partes.Partes_Estados.PENDIENTE_DE_ASIGNACION_DE_TECNICO);
                                    postdatado = 1;
                                    drParte["Fecha_Programado"] = fechaDesde;
                                }
                                else
                                {
                                    drParte["Id_Partes_Estados"] = Convert.ToInt16(Partes.Partes_Estados.REALIZADO);
                                    drParte["Fecha_Programado"] = DateTime.Now;
                                }
                            }
                            else
                            {
                                drParte["Id_Partes_Estados"] = Convert.ToInt16(Partes.Partes_Estados.REALIZADO);
                                drParte["Fecha_Programado"] = DateTime.Now;
                            }
                        }
                        else
                        {
                            drParte["Id_Partes_Estados"] = Convert.ToInt16(Partes.Partes_Estados.PENDIENTE_DE_ASIGNACION_DE_TECNICO);
                            drParte["Fecha_Programado"] = fechaDesde;
                        }
                        drParte["Id_Operadores"] = Personal.Id_Login;
                        drParte["Id_Areas"] = Personal.Id_Area;
                        drParte["Id_Locacion_Anterior"] = 0;
                        drParte["Id_Comprobantes"] = 0;
                        drParte["Fecha_Reclamo"] = DateTime.Now;
                        drParte["Fecha_Movil"] = new DateTime();
                        drParte["Fecha_Recibido"] = DateTime.Now;

                        drParte["Detalle_Falla"] = drFalla[0]["nombre"].ToString();
                        drParte["Detalle_Solucion"] = "";
                        drParte["Tipo"] = "";
                        drParte["IdTipoEquipo"] = 0;
                        drParte["CorteAutomatico"] = 1;
                        drParte["Fecha_Realizado"] = DateTime.Now;

                        dtPartesParaHacer.Rows.Add(drParte);
                        if (dtPartesParaHacer.Rows.Count > 0)
                        {
                            dtPartesGenerados = oPartes.GenerarLotePartes(dtPartesParaHacer, Convert.ToInt32(Partes.Partes_Operaciones.RECONEXION));
                            if (dtPartesGenerados.Rows.Count > 0)
                            {
                                GPS oGps = new GPS();
                                oPartes.GenerarHistorialPartes(dtPartesGenerados);

                                foreach (DataRow parte in dtPartesGenerados.Rows)
                                {
                                    //if (postdatado == 0)
                                    //    oUsuariosServicios.ActualizarEstado(Convert.ToInt32(parte["id_usuarios_servicios"].ToString()), Convert.ToInt32(Servicios.Servicios_Estados.CONECTADO));
                                    //else
                                    oUsuariosServicios.ActualizarEstado(idUsuarioServicio, Convert.ToInt32(Servicios.Servicios_Estados.SIN_CONECTAR));
                                    oPartes.Id = Convert.ToInt32(parte["id"]);
                                    if (configAgenda != Convert.ToInt32(Agenda_Encabezado.Uso_agenda.TRABAJA_CON_AGENDA))
                                        oGps.EnviarParte(oPartes.Id);
                                }
                            }
                        }
                    }
                    reconexionGenerada = 1;
                }

                if (notificar)
                {
                    int notificacionGuardada;
                    oNotificacion.Id = 0;
                    oNotificacion.Fecha_Creacion = DateTime.Now;
                    oNotificacion.Fecha_Limite = fechaHasta;
                    oNotificacion.Id_Emisor = Personal.Id_Login;
                    oNotificacion.Id_Area_Emisor = Personal.Id_Area;
                    oNotificacion.Id_Estado_Notificacion = Convert.ToInt32(Notificaciones.ESTADO_NOTIFICACION.PENDIENTE);
                    oNotificacion.Id_Prioridad = Convert.ToInt32(Notificaciones.PRIORIDAD.ALTA);
                    oNotificacion.Mensaje = "RECONECTAR SERVICIO";
                    oNotificacion.Id_Tipo_Emisor = Convert.ToInt32(Notificaciones.TIPO_EMISOR.SISTEMA);
                    oNotificacion.Ejecutar = Convert.ToInt32(Notificaciones.EJECUTAR.No);
                    notificacionGuardada = oNotificacion.Guardar(oNotificacion);

                    oNotificacionesDestino.Id = 0;
                    oNotificacionesDestino.Id_Notificacion_Origen = notificacionGuardada;
                    oNotificacionesDestino.Id_Tipo_Destinatario = Convert.ToInt32(Notificaciones_Destinatarios.Tipo_Destinatario.AREA);
                    oNotificacionesDestino.Id_Destinatario = Personal.Id_Area;
                    oNotificacionesDestino.Id_Estado_Notificacion_Destinatario = Convert.ToInt32(Notificaciones.ESTADO_NOTIFICACION.PENDIENTE);
                    oNotificacionesDestino.Guardar(oNotificacionesDestino);

                    oNotificacionAdjuntos.Id = 0;
                    oNotificacionAdjuntos.Id_Notificacion = notificacionGuardada;
                    oNotificacionAdjuntos.Id_Tipo_Modulo_Sistema = Convert.ToInt32(Notificaciones_Adjuntos.TIPO_ADJUNTOS.PARTE);
                    oNotificacionAdjuntos.Id_Item_Modulo = oPartes.Id;
                    oNotificacionAdjuntos.Id_Estado_Realizacion = Convert.ToInt32(Notificaciones_Adjuntos.ESTADO.PENDIENTE);
                    oNotificacionAdjuntos.Id_Accion = 0;
                    oNotificacionAdjuntos.Guardar(oNotificacionAdjuntos);
                }

                if (generarNotificacionCorte)
                {
                    dtDestinatarios.Clear();
                    dtModulos.Clear();
                    dtModulos = oNotificacionesDestinatariosAut.GetModulosPorForm(this.Name);
                    if (dtModulos.Rows.Count > 0)
                    {

                        try
                        {
                            idModulo = Convert.ToInt32(dtModulos.Select(String.Format("id={0}", Convert.ToInt32(Notificaciones_Adjuntos.ACCION_EJECUTAR.CORTE_SERVICIO)))[0]["id"]);
                        }
                        catch { idModulo = Convert.ToInt32(Notificaciones_Adjuntos.ACCION_EJECUTAR.CORTE_SERVICIO); }
                    }

                    dtDestinatarios = oNotificacionesDestinatariosAut.GetDestinos(idModulo);

                    oNotificacion.Id = 0;
                    oNotificacion.Fecha_Creacion = DateTime.Now;
                    oNotificacion.Fecha_Limite = fechaHasta;
                    oNotificacion.Id_Emisor = Personal.Id_Login;
                    oNotificacion.Id_Area_Emisor = Personal.Id_Area;
                    oNotificacion.Id_Estado_Notificacion = Convert.ToInt32(Notificaciones.ESTADO_NOTIFICACION.PENDIENTE);
                    oNotificacion.Id_Prioridad = Convert.ToInt32(Notificaciones.PRIORIDAD.ALTA);
                    oNotificacion.Mensaje = "Corte servicio";
                    oNotificacion.Id_Tipo_Emisor = Convert.ToInt32(Notificaciones.TIPO_EMISOR.SISTEMA);
                    oNotificacion.Ejecutar = Convert.ToInt32(Notificaciones.EJECUTAR.SI);
                    oNotificacion.Id = oNotificacion.Guardar(oNotificacion);



                    if (dtDestinatarios.Rows.Count > 0)
                    {
                        foreach (DataRow destinatario in dtDestinatarios.Rows)
                        {
                            oNotificacionesDestino.Id = 0;
                            oNotificacionesDestino.Id_Notificacion_Origen = oNotificacion.Id;
                            oNotificacionesDestino.Id_Tipo_Destinatario = Convert.ToInt32(destinatario["id_tipo_destinatario"]);
                            oNotificacionesDestino.Id_Destinatario = Convert.ToInt32(destinatario["id_destinatario"]);
                            oNotificacionesDestino.Id_Estado_Notificacion_Destinatario = Convert.ToInt32(Notificaciones.ESTADO_NOTIFICACION.PENDIENTE);
                            oNotificacionesDestino.Guardar(oNotificacionesDestino);
                        }

                    }
                    else
                    {
                        oNotificacionesDestino.Id = 0;
                        oNotificacionesDestino.Id_Notificacion_Origen = oNotificacion.Id;
                        oNotificacionesDestino.Id_Tipo_Destinatario = Convert.ToInt32(Notificaciones_Destinatarios.Tipo_Destinatario.PERSONAL);
                        oNotificacionesDestino.Id_Destinatario = Personal.Id_Login;
                        oNotificacionesDestino.Id_Estado_Notificacion_Destinatario = Convert.ToInt32(Notificaciones.ESTADO_NOTIFICACION.PENDIENTE);
                        oNotificacionesDestino.Guardar(oNotificacionesDestino);
                    }

                    oNotificacionAdjuntos.Id = 0;
                    oNotificacionAdjuntos.Id_Notificacion = oNotificacion.Id;
                    oNotificacionAdjuntos.Id_Tipo_Modulo_Sistema = Convert.ToInt32(Notificaciones_Adjuntos.TIPO_ADJUNTOS.USUARIO_SERVICIO);
                    oNotificacionAdjuntos.Id_Item_Modulo = Convert.ToInt32(detalle["id_usuario_servicio"]);
                    oNotificacionAdjuntos.Id_Estado_Realizacion = Convert.ToInt32(Notificaciones_Adjuntos.ESTADO.PENDIENTE);
                    oNotificacionAdjuntos.Id_Accion = Convert.ToInt32(Notificaciones_Adjuntos.ACCION_EJECUTAR.CORTE_SERVICIO);
                    oNotificacionAdjuntos.Guardar(oNotificacionAdjuntos);
                }
            }
            MessageBox.Show("Deudas generadas correctamente.");
            dtMovimientosAGenerar.Clear();
            dtRegistrosSubServCtaCteDetalle.Clear();
            dgvMovimientosAGenerar.DataSource = dtMovimientosAGenerar;
            lblTotal.Text = String.Format("Total: ${0}", 0);
            btnGuardar.Enabled = true;
            DialogResult dialogResult;

            
            dialogResult = MessageBox.Show("¿Desea pagar los comprobantes generados?", "", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                frmUsuariosCtaCte frm = new frmUsuariosCtaCte(Usuarios.CurrentUsuario.Id, Usuarios.CurrentUsuario.Id_Usuarios_Locacion);
                frmPopUp frmpp = new frmPopUp();
                frmpp.Formulario = frm;
                frmpp.Maximizar = true;

                if (frmpp.ShowDialog() == DialogResult.OK)
                    this.dialogResult = DialogResult.OK;

                this.Close();
            }
            else
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void AgregarServicioUnico()
        {
            dtServiciosUnicosSub.Clear();
            idUsuarioServicio = Convert.ToInt32(dgvUsuariosServicios.SelectedRows[0].Cells["id_usuario_servicio"].Value);
            dtServiciosUnicosSub = oServiciosSub.ListarPorServicio(Convert.ToInt32(dgvUsuariosServicios.SelectedRows[0].Cells["id_servicio"].Value));
            txttotal.Text = "0";
            if (dtServiciosUnicosSub.Rows.Count > 0)
            {
                if (dtServiciosUnicosSub.Columns.IndexOf("Importe") == -1)
                {
                    DcImporteSubServicioUnico = new DataColumn("Importe", typeof(decimal));
                    DcImporteSubServicioUnico.DefaultValue = 0;
                    dtServiciosUnicosSub.Columns.Add(DcImporteSubServicioUnico);
                }
                oServiciosTarifas.Fecha_Actual = fechaComenzarMovimiento;
                idTarifaActual = oServiciosTarifas.getTarifa();

                dgvServiciosUnicosSub.DataSource = null;
                dgvServiciosUnicosSub.DataSource = dtServiciosUnicosSub;

                for (int x = 0; x < dgvServiciosUnicosSub.Columns.Count; x++)
                    dgvServiciosUnicosSub.Columns[x].Visible = false;

                dgvServiciosUnicosSub.ReadOnly = false;
                dgvServiciosUnicosSub.Columns["Descripcion"].Visible = true;
                dgvServiciosUnicosSub.Columns["Importe"].Visible = true;

                dgvServiciosUnicosSub.Columns["Descripcion"].ReadOnly = true;
                dgvServiciosUnicosSub.Columns["Importe"].ReadOnly = false;
                dgvServiciosUnicosSub.Columns["Importe"].DefaultCellStyle.Format = "c2";


                pnServicios_Unicos.Visible = true;
                lblServicioUnico.Text = String.Format("Servicio único:");
                idServicioUnicoSeleccionado = 0;
                lblServicioUnico.Text = String.Format("Servicio único: {0}", dgvUsuariosServicios.SelectedRows[0].Cells["Servicio"].Value.ToString());
                idServicioUnicoSeleccionado = Convert.ToInt32(dgvUsuariosServicios.SelectedRows[0].Cells["id_servicio"].Value);
            }
            else
                MessageBox.Show("El servicio único seleccionado no posee sub servicios asignados.");
        }

        private void AgregarServicioUnicoAMovimientos()
        {
            ImporteTotal = 0;
            ValorTxtTotal = 0;
            //txtdetalle.Text = "";
            ValorTxtTotal = Convert.ToDecimal(txttotal.Text);
            if (ValorTxtTotal == 0)
                dialogResult = MessageBox.Show("El importe del movimiento a generar es de $0. ¿Quiere agregarlo de todas formas?.", "", MessageBoxButtons.YesNo);

            if (ValorTxtTotal != 0 || dialogResult == DialogResult.Yes)
            {
                contServiciosUnicos++;
                dtMovimientosAGenerar.Rows.Add(dgvUsuariosServicios.SelectedRows[0].Cells["Servicio"].Value.ToString(), idUsuario, dgvLocaciones.SelectedRows[0].Cells["id"].Value.ToString(), txttotal.Text, txttotal.Text, dtpDesde.Value.ToString("dd/MM/yyyy"), dtpHasta.Value.ToString("dd/MM/yyyy"), "1", dgvUsuariosServicios.SelectedRows[0].Cells["id_usuario_servicio"].Value.ToString(), dgvUsuariosServicios.SelectedRows[0].Cells["id_servicio_modalidad"].Value.ToString(), "1", "0", "0");
                idUsuarioServicio = Convert.ToInt32(dgvUsuariosServicios.SelectedRows[0].Cells["id_usuario_servicio"].Value);
                foreach (DataRow importeSubServicioUnico in dtServiciosUnicosSub.Rows)
                {
                    try
                    {
                        if (Convert.ToDecimal(importeSubServicioUnico["importe"]) != 0)
                        {
                            //ImporteTotal += Convert.ToDecimal(importeSubServicioUnico["Importe"]);
                            DataRow filaAgregar = dtMesesPorcentajes.NewRow();
                            filaAgregar["id_usuarios_servicios"] = dgvUsuariosServicios.SelectedRows[0].Cells["id_usuario_servicio"].Value.ToString();
                            filaAgregar["id_usuarios_servicios_sub"] = Convert.ToInt32(importeSubServicioUnico["id"]);
                            filaAgregar["id_usuarios_locaciones"] = dgvLocaciones.SelectedRows[0].Cells["id"].Value.ToString();
                            filaAgregar["nro_mes"] = 0;
                            filaAgregar["meses_cobro"] = 0;
                            filaAgregar["meses_servicio"] = 0;
                            filaAgregar["fecha_desde"] = dtpDesde.Value.ToString();
                            filaAgregar["fecha_hasta"] = dtpHasta.Value.ToString();
                            filaAgregar["id_servicios"] = Convert.ToInt32(importeSubServicioUnico["id_servicios"]);
                            filaAgregar["id_usuarios_servicios_sub_tipos"] = 0;
                            filaAgregar["tipo_servicio_sub"] = "S";
                            filaAgregar["requiere_ip"] = 0;
                            filaAgregar["id_servicios_velocidades"] = 0;
                            filaAgregar["id_servicios_velocidades_tipos"] = 0;
                            filaAgregar["borrado"] = 0;
                            filaAgregar["id_servicios_modalidad"] = Convert.ToInt32(Servicios._Modalidad.UNICO).ToString();

                            //----------datos por contratación----------------------------------------------------------------
                            filaAgregar["por_contratacion"] = 0;
                            filaAgregar["nivel_bonificacion_contratacion"] = 0;
                            filaAgregar["id_servicios_velocidades_contratacion"] = 0;
                            filaAgregar["id_servicios_velocidades_tip_contratacion"] = 0;
                            filaAgregar["id_bonificacion_contratacion"] = 0;
                            filaAgregar["fecha_desde_contratacion"] = 0;
                            filaAgregar["fecha_hasta_contratacion"] = 0;
                            filaAgregar["monto_contratacion"] = 0;
                            filaAgregar["tipo_contratacion"] = 0;
                            filaAgregar["detalle_contratacion"] = 0;
                            filaAgregar["id_usuarios_servicios_contratacion"] = 0;
                            filaAgregar["id_usuarios_servicios_sub_contratacion"] = contServiciosUnicos;
                            filaAgregar["finaliza_contratacion"] = 0;
                            filaAgregar["facturable_contratacion"] = 0;
                            filaAgregar["id_tipo_contratacion"] = 0;
                            filaAgregar["imprime_contratacion"] = 0;
                            filaAgregar["cantidad_periodos_contratacion"] = 0;
                            filaAgregar["id_usuarios_contratacion"] = 0;
                            filaAgregar["id_usuarios_locaciones_contratacion"] = 0;
                            filaAgregar["id_servicios_contratacion"] = 0;
                            filaAgregar["id_servicios_sub_contratacion"] = 0;
                            //------------------------------------------------------------

                            filaAgregar["id_bonificacion"] = 0;
                            filaAgregar["nombre_bonificacion"] = "";
                            filaAgregar["importe_original"] = Decimal.Round(Convert.ToDecimal(importeSubServicioUnico["Importe"]), 2);
                            filaAgregar["porcentaje"] = 0;
                            filaAgregar["importe_con_descuento_parcial"] = filaAgregar["importe_original"];
                            filaAgregar["porcentaje_parcial"] = 0;
                            filaAgregar["porcentaje_contratacion"] = 0;
                            filaAgregar["importe_con_descuento"] = filaAgregar["importe_original"];
                            filaAgregar["detalle_contratacion"] = txtdetalle.Text;
                            dtMesesPorcentajes.Rows.Add(filaAgregar);
                        }
                    }
                    catch
                    {

                    }
                }
                SetearUltimoRegistroMovimientoGrilla(idUsuarioServicio);
                ResetearGrillaMovimientos();
                ActualizarImporteTotal();
                ResetearGrillaUsuariosServicios();

            }
            pnServicios_Unicos.Visible = false;

        }

        private void ResetearGrillaUsuariosServicios()
        {
            dgvUsuariosServicios.DataSource = null;
            dgvUsuariosServicios.DataSource = dtUsuariosServicios;
            for (int x = 0; x < dgvUsuariosServicios.Columns.Count; x++)
                dgvUsuariosServicios.Columns[x].Visible = false;
            dgvUsuariosServicios.ReadOnly = false;
            dgvUsuariosServicios.Columns["Servicio"].Visible = true;
            dgvUsuariosServicios.Columns["Estado"].Visible = true;
            dgvUsuariosServicios.Columns["fecha_factura"].Visible = true;
            //dgvUsuariosServicios.Columns["Elige"].Visible = false;
            dgvUsuariosServicios.Columns["seleccion"].Visible = true;

            dgvUsuariosServicios.Columns["Servicio"].ReadOnly = true;
            dgvUsuariosServicios.Columns["Estado"].ReadOnly = true;
            dgvUsuariosServicios.Columns["fecha_factura"].ReadOnly = true;
            dgvUsuariosServicios.Columns["fecha_factura"].HeaderText = "Última facturación";
            dgvUsuariosServicios.Columns["seleccion"].HeaderText = "Seleccionar";

            foreach (DataGridViewRow item in dgvUsuariosServicios.Rows)
            {
                int idTipo = Convert.ToInt32(item.Cells["id_tipo"].Value);
                if (idTipo != 1 && idTipo != 3)
                    item.Visible = false;
                if (idTipo == 3 || idTipo == 4)
                {
                    item.DefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Regular);
                }
            }
            try
            {
                if (Convert.ToInt32(cboServicios_Modalidad.SelectedValue) == Convert.ToInt32(Servicios._Modalidad.MENSUAL) || Convert.ToInt32(cboServicios_Modalidad.SelectedValue) == Convert.ToInt32(Servicios._Modalidad.PERIODO))
                    dgvUsuariosServicios.Columns["seleccion"].Visible = true;
                else
                    dgvUsuariosServicios.Columns["seleccion"].Visible = false;
            }
            catch { }
        }

        private void QuitarMovimiento()
        {
            listaRegistrosDetallesEliminar.Clear();
            if (dgvUsuariosServicios.SelectedRows.Count > 0 && dgvMovimientosAGenerar.Rows.Count > 0)
            {
                int idUsuarioServicio = Convert.ToInt32(dgvMovimientosAGenerar.SelectedRows[0].Cells["id_usuario_servicio"].Value);
                int indexEliminar = -1;
                int indexEliminarAux = -1;
                DateTime fechaInicio = new DateTime();
                DateTime fechaFin = new DateTime();

                //if (Convert.ToInt32(dgvMovimientosAGenerar.SelectedRows[0].Cells["id_modalidad"].Value) != Convert.ToInt32(Servicios._Modalidad.UNICO))
                //{
                for (int x = 0; x < dtMovimientosAGenerar.Rows.Count; x++)
                {
                    if (Convert.ToInt32(dtMovimientosAGenerar.Rows[x]["id_usuario_servicio"]) == idUsuarioServicio && dtMovimientosAGenerar.Rows[x]["ultimo"].ToString() == "1")
                    {
                        fechaInicio = Convert.ToDateTime(dtMovimientosAGenerar.Rows[x]["fecha_desde"]);
                        fechaFin = Convert.ToDateTime(dtMovimientosAGenerar.Rows[x]["fecha_hasta"]);
                        indexEliminar = x;
                        indexEliminarAux = Convert.ToInt32(dtMovimientosAGenerar.Rows[x]["indice_inicial"]);

                    }
                }
                //}
                //else
                //{
                //    fechaInicio = Convert.ToDateTime(dgvMovimientosAGenerar.SelectedRows[0].Cells["fecha_desde"].Value);
                //    fechaFin = Convert.ToDateTime(dgvMovimientosAGenerar.SelectedRows[0].Cells["fecha_hasta"].Value);
                //    indexEliminar = dgvMovimientosAGenerar.SelectedRows[0].Index;
                //}

                idModalidad = Convert.ToInt32(dtMovimientosAGenerar.Rows[indexEliminar]["id_modalidad"]);

                if (Convert.ToInt32(dgvMovimientosAGenerar.SelectedRows[0].Cells["id_modalidad"].Value) != Convert.ToInt32(Servicios._Modalidad.UNICO))
                {
                    for (int x = 0; x < dtMesesPorcentajes.Rows.Count; x++)
                    {
                        //if (Convert.ToInt32(dtMesesPorcentajes.Rows[x]["id_usuarios_servicios"]) == idUsuarioServicio && Convert.ToDateTime(dtMesesPorcentajes.Rows[x]["fecha_desde"]) >= fechaInicio && Convert.ToDateTime(dtMesesPorcentajes.Rows[x]["fecha_hasta"]) <= fechaFin)
                        if (Convert.ToInt32(dtMesesPorcentajes.Rows[x]["indice"]) == indexEliminarAux)

                        {
                            int idUsuSub = Convert.ToInt32(dtMesesPorcentajes.Rows[x]["id_usuarios_servicios_sub"]);
                            int mesaux = Convert.ToInt32(dtMesesPorcentajes.Rows[x]["nro_mes"]);

                            foreach (DataRow drex in dtExtras.Rows)
                            {
                                if (Convert.ToInt32(drex["id_usuario_servicio_sub"].ToString()) == idUsuSub && Convert.ToInt32(drex["nro_mes"].ToString()) == mesaux)
                                    drex["nro_mes"] = 18;
                            }

                            dtMesesPorcentajes.Rows[x]["borrado"] = 1;

                        }
                    }
                }
                else
                {
                    DataTable mm = new DataTable();
                    mm = dtExtras;
                    for (int x = 0; x < dtMesesPorcentajes.Rows.Count; x++)
                    {
                        if (Convert.ToInt32(dtMesesPorcentajes.Rows[x]["id_usuarios_servicios"]) == idUsuarioServicio && Convert.ToDateTime(dtMesesPorcentajes.Rows[x]["fecha_desde"]).ToString("yyyy-MM-dd") == fechaInicio.ToString("yyyy-MM-dd") && Convert.ToDateTime(dtMesesPorcentajes.Rows[x]["fecha_hasta"]).ToString("yyyy-MM-dd") == fechaFin.ToString("yyyy-MM-dd"))
                            dtMesesPorcentajes.Rows[x]["borrado"] = 1;
                    }
                }
                dtMovimientosAGenerar.Rows.RemoveAt(indexEliminar);


                DataView dtvMesesPorcentajes = new DataView(dtMesesPorcentajes);
                dtvMesesPorcentajes.RowFilter = String.Format("borrado=0");
                dtMesesPorcentajes = dtvMesesPorcentajes.ToTable();

                foreach (DataRow fila in dtUsuariosServicios.Rows)
                {
                    if (Convert.ToInt32(fila["id_usuario_servicio"]) == idUsuarioServicio)
                    {
                        if (idModalidad == Convert.ToInt32(Servicios._Modalidad.DIA) || idModalidad == Convert.ToInt32(Servicios._Modalidad.PERIODO_CERRADO_POR_MES) || idModalidad == Convert.ToInt32(Servicios._Modalidad.PERIODO_CERRADO_POR_DIA))
                            fila["fecha_factura"] = fila["fecha_fin"];
                        else
                            fila["fecha_factura"] = fechaInicio.AddDays(-1);

                    }
                }

                dtUsuariosServicios.AcceptChanges();

                SetearUltimoRegistroMovimientoGrilla(idUsuarioServicio);
                //foreach (DataGridViewRow fila in dgvUsuariosServicios.Rows)
                //{
                //    if (Convert.ToInt32(fila.Cells["id_usuario_servicio"].Value) == idUsuarioServicio)
                //        fila.Cells["fecha_factura"].Value = fechaInicio.AddDays(-1);
                //}

                ResetearGrillaMovimientos();
                ResetearGrillaUsuariosServicios();
                SetearDGVSub();
            }
            else
                MessageBox.Show("No se ha seleccionado un movimiento de la grilla.");

        }

        private void SetearUltimoRegistroMovimientoGrilla(int idUsuarioServicio)
        {
            int indexUltimo = 0;
            for (int x = 0; x < dtMovimientosAGenerar.Rows.Count; x++)
            {
                if (Convert.ToInt32(dtMovimientosAGenerar.Rows[x]["id_usuario_servicio"]) == idUsuarioServicio)
                {
                    indexUltimo = x;
                    dtMovimientosAGenerar.Rows[x]["ultimo"] = 0;
                }
            }
            try
            {
                dtMovimientosAGenerar.Rows[indexUltimo]["ultimo"] = 1;
            }
            catch { }
        }

        private void ActualizarImporteTotal()
        {
            TotalFinal = 0;
            foreach (DataRow fila in dtMovimientosAGenerar.Rows)
            {
                try
                {
                    TotalFinal += Convert.ToDecimal(fila["importe_con_descuento"]);
                }
                catch
                {
                    TotalFinal += 0;
                }

            }
            lblTotal.Text = String.Format("Total: ${0}", decimal.Round(TotalFinal, 2));
        }

        private void AgregarServicioCerrado(int idModalidad)
        {
            int idServicio = 0;
            int idServicioSub = 0;
            int idTipoFacturacion = 0;
            int cantFechasErroneasCerradoMes = 0;
            int calculoBonificacion = 0;
            int indexUltimo = 0;
            int idUsuarioServicio = 0;
            int indexUsuarioServicio = 0;
            decimal importeOriginal = 0;
            decimal importeConDescuento = 0;
            bool fechasErroneas = false;
            idServicio = Convert.ToInt32(dgvUsuariosServicios.SelectedRows[0].Cells["id_servicio"].Value);
            idTipoFacturacion = Convert.ToInt32(dgvUsuariosServicios.SelectedRows[0].Cells["id_tipo_facturacion"].Value);
            idUsuarioServicio = Convert.ToInt32(dgvUsuariosServicios.SelectedRows[0].Cells["id_usuario_servicio"].Value);
            DateTime fechaFactura = Convert.ToDateTime(dgvUsuariosServicios.SelectedRows[0].Cells["fecha_factura"].Value);
            int idEstadoServicio = Convert.ToInt32(dgvUsuariosServicios.SelectedRows[0].Cells["id_estado"].Value);
            DataTable dtSubServiciosCerrado = new DataTable();
            DataTable dtPaquetes = new DataTable();
            DataTable dtMesesPorcentajesAux = oBonificaciones.GenerarDtMesesPorcentajes();
            DataTable dtImportesRetornados = new DataTable();
            if (ControlarExistenciaServicio(idUsuarioServicio, idModalidad) == false)
            {

                dtSubServiciosCerrado = oServiciosSub.ListarPorServicio(idServicio);
                if (idModalidad == Convert.ToInt32(Servicios._Modalidad.PERIODO_CERRADO_POR_DIA))
                    oServiciosTarifas.Fecha_Actual = fechaFactura;
                else
                    oServiciosTarifas.Fecha_Actual = DateTime.Now;
                idTarifaActual = oServiciosTarifas.getTarifa();
                if (idTarifaActual > 0)
                {
                    foreach (DataRow subServicio in dtSubServiciosCerrado.Rows)
                    {
                        if (Convert.ToInt32(subServicio["id_servicios_sub_tipos"]) == Convert.ToInt32(Servicios_Sub.SERVICIO_SUB_TIPOS.SUBSERVICIO))
                            idServicioSub = Convert.ToInt32(subServicio["id"]);
                    }
                    dtPaquetes = oServiciosTarifasSubEsp.GetServicios_Tarifas_Sub_Esp(idTarifaActual, idServicio, idServicioSub, idTipoFacturacion);
                    if (dtPaquetes.Rows.Count > 0)
                    {
                        if (idModalidad == Convert.ToInt32(Servicios._Modalidad.PERIODO_CERRADO_POR_MES))
                        {
                            cantFechasErroneasCerradoMes = 0;
                            foreach (DataRow paquete in dtPaquetes.Rows)
                            {
                                if (DateTime.Compare(Convert.ToDateTime(paquete["fecha_desde"]), fechaFactura) < 0)
                                    cantFechasErroneasCerradoMes++;
                            }
                            if (cantFechasErroneasCerradoMes == dtPaquetes.Rows.Count)
                                fechasErroneas = true;
                        }
                        if (idModalidad == Convert.ToInt32(Servicios._Modalidad.PERIODO_CERRADO_POR_MES) && fechasErroneas)
                            MessageBox.Show("Las fechas de los paquetes del servicio seleccionado son anteriores a la última fecha de facturación.");
                        else
                        {
                            if (idServicioSub > 0)
                            {
                                frmPopUp frmpp = new frmPopUp();
                                Cuenta_Corriente.frmComprobantePeriodoCerrado frmPaquetesPeriodoCerrado = new Cuenta_Corriente.frmComprobantePeriodoCerrado(idTarifaActual, idTipoFacturacion, idServicio, idServicioSub, idModalidad, oServiciosTarifas.Fecha_Actual);
                                frmpp.Formulario = frmPaquetesPeriodoCerrado;
                                frmpp.Maximizar = false;
                                frmpp.ShowDialog();
                                if (frmpp.DialogResult == DialogResult.OK)
                                {
                                    int y = 0;
                                    foreach (DataRow usuariosServicios in dtUsuariosServicios.Rows)
                                    {
                                        if (Convert.ToInt32(usuariosServicios["id_usuario_servicio"]) == idUsuarioServicio && Convert.ToInt32(usuariosServicios["id_tipo"]) == Convert.ToInt32(Usuarios_Servicios._TipoItemServicio.SERVICIO_PROPIO))
                                        {
                                            indexUsuarioServicio = y;
                                            break;
                                        }
                                        y++;
                                    }
                                    fechaComenzarMovimiento = Convert.ToDateTime(frmPaquetesPeriodoCerrado.dtPaquetesSeleccionados.Rows[0]["fecha_desde"]);
                                    dtUsuariosServiciosSub.Clear();

                                    if (idEstadoServicio == Convert.ToInt16(Servicios.Servicios_Estados.CONECTADO) || idEstadoServicio == Convert.ToInt16(Servicios.Servicios_Estados.SIN_CONECTAR) || idEstadoServicio == Convert.ToInt16(Servicios.Servicios_Estados.EN_ESPERA))
                                        dtUsuariosServiciosSub = oFacturacion.RetornarSubServicios(idTarifaActual, idUsuario, fechaComenzarMovimiento, false, true);//trae los subservicios del usuario     
                                    else
                                        dtUsuariosServiciosSub = oFacturacion.RetornarSubServicios(idTarifaActual, idUsuario, fechaComenzarMovimiento, true, true);


                                    oBonificaciones.TraerImportesOriginales(idTarifaActual, dtUsuariosServiciosSub);//actualiza la tabla dtusuarioserviciossub con datos de importes originales, meses de cobro y meses de servicio

                                    try
                                    {
                                        if (idEstadoServicio == Convert.ToInt16(Servicios.Servicios_Estados.CONECTADO) || idEstadoServicio == Convert.ToInt16(Servicios.Servicios_Estados.SIN_CONECTAR) || idEstadoServicio == Convert.ToInt16(Servicios.Servicios_Estados.EN_ESPERA))
                                            calculoBonificacion = oUsuarios.traerUsuario(idUsuario).Calculo_Bonificacion;
                                        else
                                            calculoBonificacion = Convert.ToUInt16(Usuarios._Calculo_Bonificacion.NO_SE_APLICA);
                                    }
                                    catch
                                    {
                                        calculoBonificacion = Convert.ToUInt16(Usuarios._Calculo_Bonificacion.NO_SE_APLICA);
                                    }//determina si para el usuario del usuario_servicio seleccionado se aplica o no el cálculo de bonificaciones
                                    dtMesesPorcentajesAux.Clear();
                                    DataView dtvAuxilar;
                                    foreach (DataRow subServicio in dtUsuariosServiciosSub.Rows)//setea la fecha a partir de la cual se generarán las nuevas deudas
                                        subServicio["fecha_inicio_servicio"] = fechaComenzarMovimiento;
                                    foreach (DataRow subServicioPeriodoCerrado in dtUsuariosServiciosSub.Select(String.Format("id_usuario_servicio={0}", idUsuarioServicio)))
                                    {
                                        subServicioPeriodoCerrado["fecha_hasta_servicio"] = frmPaquetesPeriodoCerrado.dtPaquetesSeleccionados.Rows[0]["fecha_hasta"];
                                        subServicioPeriodoCerrado["id_servicios_tarifas_sub_esp"] = frmPaquetesPeriodoCerrado.dtPaquetesSeleccionados.Rows[0]["id_tarifa_sub_especial"];
                                        dtUsuariosServiciosSub.AcceptChanges();
                                    }

                                    if (calculoBonificacion == Convert.ToUInt16(Usuarios._Calculo_Bonificacion.NO_SE_APLICA))
                                    {
                                        dtvAuxilar = new DataView(dtUsuariosServiciosSub);
                                        dtvAuxilar.RowFilter = String.Format("fecha_factura<'{0}' and id_usuario_servicio={1}", fechaComenzarMovimiento.Date.ToString("yyyy-MM-dd"), idUsuarioServicio);
                                        dtUsuariosServiciosSub = dtvAuxilar.ToTable();//sólo deja en la tabla de subservicios, aquellos cuya fecha_factura es menor a la fecha consultada
                                        oBonificaciones.TraerImportesOriginales(idTarifaActual, dtUsuariosServiciosSub);
                                        oBonificaciones.SetearFechasYModalidadVacios(dtUsuariosServiciosSub);
                                        dtMesesPorcentajesAux = oBonificaciones.GenerarTablaRegistrosCtaCteDet(dtUsuariosServiciosSub);//genera los meses de cobro por cada subservicio
                                        oBonificaciones.SetearPorcentajeImporteParcial(dtMesesPorcentajesAux);
                                        //oBonificaciones.AgregarMontoIpFija(dtUsuariosServiciosSub, dtMesesPorcentajesAux);
                                        oBonificaciones.RecalcularImportes(dtUsuariosServiciosSub, dtMesesPorcentajesAux, false);
                                    }
                                    else
                                    {
                                        oFacturacion.AgregarSubServiciosHeredados(dtUsuariosServiciosSub);//agrega los subservicios heredados correspondientes
                                        if (calculoBonificacion == Convert.ToInt32(Usuarios._Calculo_Bonificacion.POR_LOCACION))
                                        {
                                            dtvAuxilar = new DataView(dtUsuariosServiciosSub);
                                            dtvAuxilar.RowFilter = String.Format("id_locacion={0}", Convert.ToInt32(dgvUsuariosServicios.SelectedRows[0].Cells["id_usuarios_locaciones"].Value));
                                            dtUsuariosServiciosSub = dtvAuxilar.ToTable();
                                        }
                                        if (oBonificaciones.CalcularBonificaciones(dtUsuariosServiciosSub, idTarifaActual, false, 0, false))
                                        {
                                            dtUsuariosServiciosSub = Bonificaciones.dtSubServicios;
                                            dtMesesPorcentajesAux = Bonificaciones.dtSubServiciosDetalles;
                                        }
                                    }

                                    dtImportesRetornados.Clear();
                                    dtExtras.Clear();
                                    if (dtUsuariosServiciosSub.Rows.Count > 0)
                                    {
                                        dtvAuxilar = new DataView(dtUsuariosServiciosSub);
                                        dtvAuxilar.RowFilter = String.Format("fecha_factura<'{0}' and id_usuario_servicio={1}", fechaComenzarMovimiento.Date.ToString("yyyy-MM-dd"), idUsuarioServicio);
                                        dtImportesRetornados = oFacturacion.AplicarNovedades(dtvAuxilar.ToTable(), dtMesesPorcentajesAux, Convert.ToInt32(dgvLocaciones.SelectedRows[0].Cells["id"].Value), fechaComenzarMovimiento, false);
                                        if (dtExtras.Rows.Count == 0)
                                            dtExtras = oFacturacion.dtExtras.Copy();
                                        else
                                        {
                                            foreach (DataRow fila in oFacturacion.dtExtras.Rows)
                                                dtExtras.ImportRow(fila);
                                        }


                                        try
                                        {
                                            importeOriginal = importeOriginal + Convert.ToDecimal(dtImportesRetornados.Rows[0]["importe_original_total"]);
                                            importeConDescuento = importeConDescuento + Convert.ToDecimal(dtImportesRetornados.Rows[0]["importe_con_descuento_total"]);
                                        }
                                        catch
                                        {
                                            importeOriginal += 0;
                                            importeConDescuento += 0;
                                        }
                                        foreach (DataRow fila in dtMesesPorcentajesAux.Select("id_usuarios_servicios='" + idUsuarioServicio + "'"))
                                            dtMesesPorcentajes.ImportRow(fila);
                                        dtMesesPorcentajes.AcceptChanges();
                                        if (dtSubServicios.Rows.Count == 0)
                                            dtSubServicios = dtUsuariosServiciosSub.Copy();
                                        else
                                        {
                                            foreach (DataRow fila in dtUsuariosServiciosSub.Rows)
                                                dtSubServicios.ImportRow(fila);
                                        }

                                    }
                                    else
                                        MessageBox.Show("El servicio no se encuentra definido para la tarifa consultada.");


                                    if (importeOriginal == 0)
                                        dialogResult = MessageBox.Show("El importe del movimiento a generar es de $0. ¿Quiere agregarlo de todas formas?.", "", MessageBoxButtons.YesNo);

                                    if (importeOriginal > 0 || dialogResult == DialogResult.Yes)
                                    {
                                        dtDatosAuxiliaresServicio.Clear();
                                        dtDatosAuxiliaresServicio = oUsuariosServicios.Traer_datos_usuarios_servicios(Convert.ToInt32(dgvUsuariosServicios.SelectedRows[0].Cells["id_usuario_servicio"].Value));
                                        dtMovimientosAGenerar.Rows.Add(dgvUsuariosServicios.SelectedRows[0].Cells["Servicio"].Value.ToString(), dgvUsuariosServicios.SelectedRows[0].Cells["id_usuarios"].Value.ToString(), dgvLocaciones.SelectedRows[0].Cells["id"].Value.ToString(), decimal.Round(importeOriginal, 2), decimal.Round(importeConDescuento, 2), Convert.ToDateTime(frmPaquetesPeriodoCerrado.dtPaquetesSeleccionados.Rows[0]["fecha_desde"]).ToString("dd/MM/yyyy"), Convert.ToDateTime(frmPaquetesPeriodoCerrado.dtPaquetesSeleccionados.Rows[0]["fecha_hasta"]).ToString("dd/MM/yyyy"), cmbcantperiodos.Text.ToString(), dgvUsuariosServicios.SelectedRows[0].Cells["id_usuario_servicio"].Value.ToString(), dgvUsuariosServicios.SelectedRows[0].Cells["id_servicio_modalidad"].Value.ToString(), "0", dtDatosAuxiliaresServicio.Rows[0]["corteautomatico"].ToString(), dgvUsuariosServicios.SelectedRows[0].Cells["id_estado"].Value.ToString());
                                        indexUltimo = dtMovimientosAGenerar.Rows.Count - 1;
                                        dtUsuariosServicios.Rows[indexUsuarioServicio]["fecha_factura"] = Convert.ToDateTime(frmPaquetesPeriodoCerrado.dtPaquetesSeleccionados.Rows[0]["fecha_hasta"]).ToString("dd/MM/yyyy");
                                        //dgvUsuariosServicios.SelectedRows[0].Cells["fecha_factura"].Value = fechaDesde.AddMonths((mesesServicio * Convert.ToInt32(cmbcantperiodos.Text))).AddDays(-1).ToString("dd/MM/yyyy");
                                        dtUsuariosServicios.AcceptChanges();
                                        SetearUltimoRegistroMovimientoGrilla(idUsuarioServicio);
                                        ActualizarImporteTotal();
                                        ResetearGrillaMovimientos();
                                    }
                                    ResetearGrillaUsuariosServicios();
                                }
                            }
                        }
                    }
                    else
                        MessageBox.Show("No hay paquetes cargados en el sistema.");
                }
                else
                    MessageBox.Show(String.Format("No hay tarifas vigentes en el sistema para la fecha consultada: {0}", oServiciosTarifas.Fecha_Actual));
            }
            else
                MessageBox.Show("En la grilla de movimientos ya se encuentra generado un movimiento para el servicio por periodo cerrado seleccionado.");
        }

        private void AgregarServicioPrepago()
        {
            if (ControlarExistenciaServicio(idUsuarioServicio, idModalidad) == false)
            {
                frmPopUp oPop = new frmPopUp();
                frmComprobantePrepago oPre = new frmComprobantePrepago(idUsuarioServicio, servicioNombre, idServicio, idTipoFac, fechaFactura.AddDays(1));
                oPre.gestionarMontos = 1;

                oPre.verTarifas = 1;
                oPop.Formulario = oPre;
                oPop.Maximizar = false;
                if (oPop.ShowDialog() == DialogResult.OK)
                {
                    notificar = oPre.notificacion;
                    generarNotificacionCorte = oPre.generarNotificacionCorte;
                    importeFinal = oPre.importeFinal;
                    fechaDesde = oPre.fechaDesdeFinal;
                    fechaHasta = oPre.fechaHastaFinal;
                    Int32 idVelocidad = oPre.idVelocidad;
                    Int32 idVelocidadTipo = oPre.idVelocidadTipo;
                    String nombreVelocidad = oPre.nombreVelocidad;
                    String nombreTipoVelocidad = oPre.nombreVelocidadTipo;
                    DataRow drMoviemientosAGenerar = dtMovimientosAGenerar.NewRow();
                    drMoviemientosAGenerar["servicio"] = servicioNombre;
                    drMoviemientosAGenerar["id_usuario"] = idUsuario.ToString();
                    drMoviemientosAGenerar["id_locacion"] = dgvLocaciones.SelectedRows[0].Cells["id"].Value.ToString();
                    drMoviemientosAGenerar["importe_original"] = importeFinal.ToString();
                    drMoviemientosAGenerar["importe_con_descuento"] = importeFinal.ToString();
                    drMoviemientosAGenerar["fecha_desde"] = fechaDesde.ToString("dd/MM/yyyy");
                    drMoviemientosAGenerar["fecha_hasta"] = fechaHasta.ToString("dd/MM/yyyy");
                    drMoviemientosAGenerar["cantidad_periodos"] = "0";
                    drMoviemientosAGenerar["id_usuario_servicio"] = dgvUsuariosServicios.SelectedRows[0].Cells["id_usuario_servicio"].Value.ToString();
                    drMoviemientosAGenerar["id_modalidad"] = idModalidad.ToString(); ;
                    drMoviemientosAGenerar["ultimo"] = "0";

                    dtDatosAuxiliaresServicio.Clear();
                    dtDatosAuxiliaresServicio = oUsuariosServicios.Traer_datos_usuarios_servicios(Convert.ToInt32(dgvUsuariosServicios.SelectedRows[0].Cells["id_usuario_servicio"].Value));

                    drMoviemientosAGenerar["corte_automatico"] = dtDatosAuxiliaresServicio.Rows[0]["corteautomatico"].ToString();
                    drMoviemientosAGenerar["estado_servicio"] = dgvUsuariosServicios.SelectedRows[0].Cells["id_estado"].Value.ToString();

                    dtMovimientosAGenerar.Rows.Add(drMoviemientosAGenerar);

                    dtSubServicios = oBonificaciones.GenerarDtSubServicios();
                    DataTable dtSub = oUsuariosServicios.ListarServiciosSub(Convert.ToInt32(dgvUsuariosServicios.SelectedRows[0].Cells["id_usuario_servicio"].Value));
                    DataTable dtDatosServicio = oServicios.BuscarDatosServicio(idServicio);
                    foreach (DataRow item in dtSub.Rows)
                    {

                        dtMesesPorcentajes = oBonificaciones.GenerarDtMesesPorcentajes();
                        DataRow dtDatosSub = oServiciosSub.TraerDatosSubServicio(Convert.ToInt32(item["id_servicios_sub"]));
                        DataRow dr = dtMesesPorcentajes.NewRow();
                        dr["id_usuarios_servicios"] = dgvUsuariosServicios.SelectedRows[0].Cells["id_usuario_servicio"].Value.ToString();
                        dr["id_usuarios_servicios_sub"] = Convert.ToInt32(item["id"]).ToString();
                        dr["fecha_desde"] = fechaDesde.ToString("dd/MM/yyyy");
                        dr["fecha_hasta"] = fechaHasta.ToString("dd/MM/yyyy");
                        dr["id_bonificacion_contratacion"] = "0";
                        dr["id_bonificacion"] = "0";
                        dr["id_usuarios_locaciones"] = dgvLocaciones.SelectedRows[0].Cells["id"].Value.ToString();

                        dr["nombre_bonificacion"] = "";
                        dr["por_contratacion"] = "";
                        dr["nro_mes"] = "";
                        dr["meses_cobro"] = "0";
                        dr["meses_servicio"] = "0";
                        dr["nivel_bonificacion_contratacion"] = "";
                        dr["id_usuarios_contratacion"] = "";
                        dr["id_usuarios_locaciones_contratacion"] = "";
                        dr["id_servicios_contratacion"] = "";
                        dr["id_servicios_sub_contratacion"] = "";
                        dr["id_servicios_velocidades_contratacion"] = "";
                        dr["id_servicios_velocidades_tip_contratacion"] = "";
                        dr["fecha_desde_contratacion"] = "";
                        dr["fecha_hasta_contratacion"] = "";
                        dr["monto_contratacion"] = "";
                        dr["tipo_contratacion"] = "";
                        dr["detalle_contratacion"] = "";
                        dr["id_usuarios_servicios_contratacion"] = "";
                        dr["id_usuarios_servicios_sub_contratacion"] = "";
                        dr["finaliza_contratacion"] = "";
                        dr["facturable_contratacion"] = "";
                        dr["id_tipo_contratacion"] = "";
                        dr["imprime_contratacion"] = "";
                        dr["cantidad_periodos_contratacion"] = "";

                        dr["id_usuarios_servicios_sub_tipos"] = Convert.ToInt32(item["id_servicios_sub_tipos"]).ToString();
                        dr["tipo_servicio_sub"] = "S";
                        dr["requiere_ip"] = Convert.ToInt32(item["requiere_ip"]).ToString();
                        dr["id_servicios"] = idServicio.ToString();
                        dr["id_servicios_velocidades"] = Convert.ToInt32(item["id_servicios_velocidades"]).ToString();
                        dr["id_servicios_velocidades_tipos"] = Convert.ToInt32(item["id_servicios_velocidades_tip"]).ToString();
                        dr["importe_original"] = importeFinal.ToString();

                        dr["porcentaje_parcial"] = "0";
                        dr["importe_con_descuento_parcial"] = importeFinal.ToString();
                        dr["porcentaje_contratacion"] = "0";
                        dr["importe_con_descuento"] = importeFinal.ToString();
                        dr["porcentaje"] = "0";
                        dr["borrado"] = "0";

                        dtMesesPorcentajes.Rows.Add(dr);
                        dtMesesPorcentajes.AcceptChanges();

                        DataRow drSub = dtSubServicios.NewRow();
                        drSub["id_usuario_servicio"] = dgvUsuariosServicios.SelectedRows[0].Cells["id_usuario_servicio"].Value.ToString();
                        drSub["id_usuario_servicio_sub"] = Convert.ToInt32(item["id"]).ToString();
                        drSub["id_tipo_facturacion"] = idTipoFac.ToString();
                        drSub["id_grupo"] = dtDatosServicio.Rows[0]["id_servicios_grupos"].ToString();
                        drSub["id_servicio_tipo"] = dtDatosServicio.Rows[0]["id_servicios_tipos"].ToString(); ;
                        drSub["id_servicio"] = idServicio.ToString();
                        drSub["id_servicio_sub"] = item["id_servicios_sub"].ToString();
                        drSub["id_velocidad"] = idVelocidad.ToString();
                        drSub["id_velocidad_tipo"] = idVelocidadTipo.ToString();

                        drSub["tipo_servicio_sub"] = "S";
                        drSub["cant_bocas_pac"] = dtDatosUsuSer.Rows[0]["cant_bocas_pac"].ToString();
                        drSub["tipofac"] = 5;
                        drSub["grupo"] = servicioGrupo;
                        drSub["tipo"] = servicioTipo;
                        drSub["servicio"] = servicioNombre;
                        drSub["subservicio"] = item["descripcion"].ToString();
                        drSub["velocidad"] = nombreVelocidad;
                        drSub["velocidad_tipo"] = nombreTipoVelocidad;
                        drSub["tiposub"] = "S";
                        drSub["nombre_bonificacion"] = "0";
                        drSub["id_relacion"] = "0";
                        drSub["calle"] = dgvLocaciones.SelectedRows[0].Cells["calle"].Value.ToString();
                        drSub["altura"] = dgvLocaciones.SelectedRows[0].Cells["altura"].Value.ToString();
                        drSub["piso"] = dgvLocaciones.SelectedRows[0].Cells["piso"].Value.ToString();
                        drSub["depto"] = dgvLocaciones.SelectedRows[0].Cells["depto"].Value.ToString();
                        drSub["localidad"] = dgvLocaciones.SelectedRows[0].Cells["localidad"].Value.ToString(); ;
                        // drSub["usuario"] = dgvUsuariosServicios.SelectedRows[0].Cells["usuario"].Value.ToString();
                        drSub["codigo_usuario"] = dgvUsuariosServicios.SelectedRows[0].Cells["id_usuarios"].Value.ToString(); ;
                        drSub["id_servicios_estados"] = dgvUsuariosServicios.SelectedRows[0].Cells["estado"].Value.ToString();
                        drSub["porcentaje"] = "0";
                        dtSubServicios.Rows.Add(drSub);
                    }
                    generarParte = true;
                    int indexUltimo = dtMovimientosAGenerar.Rows.Count - 1;
                    // dtUsuariosServicios.Rows[dgvUsuariosServicios.SelectedRows[0].Index]["fecha_factura"] = fechaHasta.ToString("dd/MM/yyyy");

                    dgvUsuariosServicios.SelectedRows[0].Cells["fecha_factura"].Value = fechaHasta.ToString("dd/MM/yyyy");
                    dtUsuariosServicios.AcceptChanges();
                    SetearUltimoRegistroMovimientoGrilla(Convert.ToInt32(dgvUsuariosServicios.SelectedRows[0].Cells["id_usuario_servicio"].Value));
                    ResetearGrillaMovimientos();
                    ActualizarImporteTotal();
                    



                }
                ResetearGrillaUsuariosServicios();
            }
            else
                MessageBox.Show("En la grilla de movimientos ya se encuentra generado un movimiento para el servicio prepago seleccionado.");
        }

        private void generaGestionAppexternas()
        {
            List<int> serviciosPrepagos = new List<int>();
            serviciosPrepagos.Add(idUsuarioServicio);
            using (frmPopUp frm = new frmPopUp())
            {
                AppExternas.frmPrepagosAppExternas oExterna = new AppExternas.frmPrepagosAppExternas();
                oExterna.id_servicio = idServicio;
                oExterna.id_tipo_servicio = idTipoServicio;
                oExterna.prepagosAppExterna = serviciosPrepagos;
                oExterna.vieneDeudas = true;
                oExterna.id_usuario = idUsuario;
                oExterna.fecha_desde = fechaDesde;
                oExterna.id_ctacte_global = idCtaCteGlobal;
                oExterna.fecha_hasta = fechaHasta;
                oExterna.fecha_corte = fechaHasta;
                oExterna.id_locacion = idLocacionRecibidaSeleccionada;
                oExterna.id_usuario_servicio = idUsuarioServicio;
                frm.Formulario = oExterna;
                frm.Maximizar = false;
                frm.ShowDialog();
            }
        }

        private bool ControlarExistenciaServicio(int idUsuariosServicios, int idModalidad)
        {
            foreach (DataRow movimiento in dtMovimientosAGenerar.Rows)
            {
                if (Convert.ToInt32(movimiento["id_usuario_servicio"]) == idUsuariosServicios && Convert.ToInt32(movimiento["id_modalidad"]) == idModalidad)
                    return true;
            }
            return false;
        }

        #endregion

        #region Métodos controles
        public frmGeneraComprobantesManual(int idUsuarioRecibido, int idLocacionRecibida, DataTable dtUsuariosServiciosRecibidos, DataTable dtLocacionesRecibidas)
        {
            InitializeComponent();
            dtLocaciones = dtLocacionesRecibidas;
            this.idUsuarioRecibido = idUsuarioRecibido;
            this.idLocacionRecibidaSeleccionada = idLocacionRecibida;
            dtRegistrosSubServCtaCteDetalle = new DataTable();
            dtMovimientosAGenerar = new DataTable();
            dtUsuariosServicios = new DataTable();
            dtUsuariosServiciosSub = new DataTable();
            dtServiciosUnicosSub = new DataTable();
            dtDatosUsuario = new DataTable();


            dtRegistrosSubServCtaCteDetalle.Columns.Add("id_locacion", typeof(string));
            dtRegistrosSubServCtaCteDetalle.Columns.Add("id_tipo_facturacion", typeof(string));
            dtRegistrosSubServCtaCteDetalle.Columns.Add("id_servicio", typeof(string));
            dtRegistrosSubServCtaCteDetalle.Columns.Add("id_servicio_sub", typeof(string));
            dtRegistrosSubServCtaCteDetalle.Columns.Add("tipo_servicio_sub", typeof(string));
            dtRegistrosSubServCtaCteDetalle.Columns.Add("id_velocidad_tipo", typeof(string));
            dtRegistrosSubServCtaCteDetalle.Columns.Add("id_velocidad", typeof(string));
            dtRegistrosSubServCtaCteDetalle.Columns.Add("id_usuario_servicio", typeof(string));
            dtRegistrosSubServCtaCteDetalle.Columns.Add("id_usuario_servicio_sub", typeof(string));
            dtRegistrosSubServCtaCteDetalle.Columns.Add("importe_original", typeof(string));
            dtRegistrosSubServCtaCteDetalle.Columns.Add("importe_con_descuento", typeof(string));
            dtRegistrosSubServCtaCteDetalle.Columns.Add("requiere_ip", typeof(string));
            dtRegistrosSubServCtaCteDetalle.Columns.Add("fecha_desde", typeof(string));
            dtRegistrosSubServCtaCteDetalle.Columns.Add("fecha_hasta", typeof(string));
            dtRegistrosSubServCtaCteDetalle.Columns.Add("id_bonificacion", typeof(string));
            dtRegistrosSubServCtaCteDetalle.Columns.Add("nombre_bonificacion", typeof(string));
            dtRegistrosSubServCtaCteDetalle.Columns.Add("porcentaje_bonificacion", typeof(string));
            dtRegistrosSubServCtaCteDetalle.Columns.Add("detalle", typeof(string));
            dtRegistrosSubServCtaCteDetalle.Columns.Add("borrado", typeof(string));

            dtMovimientosAGenerar.Columns.Add("servicio", typeof(string));
            dtMovimientosAGenerar.Columns.Add("id_usuario", typeof(string));
            dtMovimientosAGenerar.Columns.Add("id_locacion", typeof(string));
            dtMovimientosAGenerar.Columns.Add("importe_original", typeof(string));
            dtMovimientosAGenerar.Columns.Add("importe_con_descuento", typeof(string));
            dtMovimientosAGenerar.Columns.Add("fecha_desde", typeof(string));
            dtMovimientosAGenerar.Columns.Add("fecha_hasta", typeof(string));
            dtMovimientosAGenerar.Columns.Add("cantidad_periodos", typeof(string));
            dtMovimientosAGenerar.Columns.Add("id_usuario_servicio", typeof(string));
            dtMovimientosAGenerar.Columns.Add("id_modalidad", typeof(string));
            dtMovimientosAGenerar.Columns.Add("ultimo", typeof(string));
            dtMovimientosAGenerar.Columns.Add("corte_automatico", typeof(string));
            dtMovimientosAGenerar.Columns.Add("estado_servicio", typeof(string));
            DataColumn dcIndice = new DataColumn("indice_inicial", typeof(Int32));
            dcIndice.DefaultValue = -1;
            /**/
            dtMovimientosAGenerar.Columns.Add(dcIndice);
            dtUsuariosServicios = dtUsuariosServiciosRecibidos;
        }

        private void dgvMovimientosAGenerar_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvMovimientosAGenerar.SelectedRows.Count > 0)
            {
                if (Convert.ToDecimal(dgvMovimientosAGenerar.SelectedRows[0].Cells["importe_original"].Value) != Convert.ToDecimal(dgvMovimientosAGenerar.SelectedRows[0].Cells["importe_con_descuento"].Value))
                {
                    List<int> listadoBonificaciones = new List<int>();
                    foreach (DataRow fila in dtMesesPorcentajes.Select(String.Format("id_usuarios_servicios={0} and id_bonificacion<>0", dgvMovimientosAGenerar.SelectedRows[0].Cells["id_usuario_servicio"].Value)))
                    {
                        if (listadoBonificaciones.Contains(Convert.ToInt32(fila["id_bonificacion"])) == false)
                            listadoBonificaciones.Add(Convert.ToInt32(fila["id_bonificacion"]));
                    }
                    if (listadoBonificaciones.Count > 0)
                    {
                        using (frmPopUp frm = new frmPopUp())
                        {
                            frmUsuariosCtacteDetExtras oExtras = new frmUsuariosCtacteDetExtras(true);
                            oExtras.listadoBonificaciones = listadoBonificaciones;
                            frm.Formulario = oExtras;
                            frm.Maximizar = false;
                            frm.ShowDialog();
                        }
                    }
                }
            }
        }

        private void cboServicios_Modalidad_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dgvUsuariosServicios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string mensaje = string.Empty;

            if (Convert.ToInt32(dgvUsuariosServicios.SelectedRows[0].Cells["genera_deuda_cortado"].Value) == 0 && (Convert.ToInt32(dgvUsuariosServicios.SelectedRows[0].Cells["id_estado"].Value) == (int)Servicios.Servicios_Estados.CORTADO))
            {
                mensaje = string.Format("Este servicio esta configurado para que no se pueda generar deuda estando '{0}'.", dgvUsuariosServicios.SelectedRows[0].Cells["Estado"].Value.ToString());
                MessageBox.Show(mensaje, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                dgvUsuariosServicios.ClearSelection();
            }
            else if (Convert.ToInt32(dgvUsuariosServicios.SelectedRows[0].Cells["genera_deuda_retirado"].Value) == 0 && (Convert.ToInt32(dgvUsuariosServicios.SelectedRows[0].Cells["id_estado"].Value) == (int)Servicios.Servicios_Estados.RETIRADO))
            {
                mensaje = string.Format("Este servicio esta configurado para que no se pueda generar deuda estando '{0}'.", dgvUsuariosServicios.SelectedRows[0].Cells["Estado"].Value.ToString());
                MessageBox.Show(mensaje, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                dgvUsuariosServicios.ClearSelection();

            }
        }

        private void dgvMovimientosAGenerar_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvMovimientosAGenerar_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void copiar(Control sourceControl, Control targetControl)
        {
            // make sure these are the same
            if (sourceControl.GetType() != targetControl.GetType())
            {
                throw new Exception("Incorrect control types");
            }

            foreach (PropertyInfo sourceProperty in sourceControl.GetType().GetProperties())
            {
                object newValue = sourceProperty.GetValue(sourceControl, null);

                MethodInfo mi = sourceProperty.GetSetMethod(true);
                if (mi != null)
                {
                    sourceProperty.SetValue(targetControl, newValue, null);
                }
            }
        }

        private void pnServicios_Unicos_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmGeneraComprobantesManual_Load(object sender, EventArgs e)
        {
            dtUpdateFechasServiciosSub.Columns.Add("idUsuarioServicioSub", typeof(string));
            dtUpdateFechasServiciosSub.Columns.Add("fechaInicio", typeof(string));
            dtUpdateFechasServiciosSub.Columns.Add("fechaFin", typeof(string));
            contServiciosUnicos = 0;
            ComenzarCarga();
        }

        private void btnquita_Click(object sender, EventArgs e)
        {
            QuitarMovimiento();
            ActualizarImporteTotal();
            //ActualizarGrillaServicios();
        }


        private void dgvLocaciones_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvMovimientosAGenerar.Rows.Count > 0)
            {
                DialogResult dialogResult = MessageBox.Show("Al cambiar de locación, los movimientos que ha colocado en la grilla de movimientos se borrarán. ¿Desea continuar?", "", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    dtExtras.Clear();
                    dtUsuariosServicios = oUsuariosServicios.ListarServiciosYSubServiciosActivos(idUsuario);
                    if (dtUsuariosServicios.Columns.IndexOf("seleccion") == -1)
                    {
                        DcElige = new DataColumn("seleccion", typeof(bool));
                        DcElige.DefaultValue = true;
                        dtUsuariosServicios.Columns.Add(DcElige);
                    }

                    dtServiciosUnicos = oServicios.ListarPorModalidad(Servicios._Modalidad.UNICO);

                    //if (dtServiciosUnicos.Rows.Count > 0) {
                    //    foreach (DataRow servicioUnico in dtServiciosUnicos.Rows) {
                    //        DataRow dr = dtUsuariosServicios.NewRow();
                    //        dr["id_tipo"] = 1;
                    //        dr["id_usuarios"] = idUsuario;
                    //        dr["servicio"] = servicioUnico["descripcion"].ToString();
                    //        dr["servicio_tipo"] = servicioUnico["Tipo"].ToString();
                    //        dr["id_servicio"] = servicioUnico["id"].ToString();
                    //        dr["id_servicio_tipo"] = servicioUnico["id_servicios_tipos"].ToString();
                    //        dr["id_servicio_modalidad"] = servicioUnico["id_servicios_modalidad"].ToString();
                    //    }
                    //}
                    contUsuariosServiciosUnicos = 0;
                    if (dtUsuariosServicios.Rows.Count > 0)
                    {
                        foreach (DataRow usuarioServicio in dtUsuariosServicios.Rows)
                        {
                            if (Convert.ToInt32(usuarioServicio["id_usuario_servicio"]) > contUsuariosServiciosUnicos)
                                contUsuariosServiciosUnicos = Convert.ToInt32(usuarioServicio["id_usuario_servicio"]);
                        }
                        contUsuariosServiciosUnicos++;
                    }

                    if (dtServiciosUnicos.Rows.Count > 0)
                    {
                        foreach (DataRow servicioUnico in dtServiciosUnicos.Rows)
                        {
                            contUsuariosServiciosUnicos++;
                            DataRow drUsuarioServicio = dtUsuariosServicios.NewRow();
                            drUsuarioServicio["id_tipo"] = 5;
                            drUsuarioServicio["tipo"] = "";
                            drUsuarioServicio["id_usuarios"] = idUsuario;
                            drUsuarioServicio["id_usuario_servicio"] = contUsuariosServiciosUnicos;
                            drUsuarioServicio["id_locacion"] = 0;
                            drUsuarioServicio["servicio"] = servicioUnico["descripcion"].ToString();
                            drUsuarioServicio["servicio_sub"] = "";
                            drUsuarioServicio["servicio_sub_tipo"] = "";
                            drUsuarioServicio["Fecha_Estado"] = DateTime.Now;
                            drUsuarioServicio["Fecha_Inicio"] = DateTime.Now;
                            drUsuarioServicio["Fecha_Fin"] = DateTime.Now;
                            drUsuarioServicio["Fecha_Saldado"] = DateTime.Now;
                            drUsuarioServicio["Fecha_Factura"] = DateTime.Now;
                            drUsuarioServicio["Con_Aviso"] = 0;
                            drUsuarioServicio["Con_Corte"] = 0;
                            drUsuarioServicio["Con_Alarma"] = 0;
                            drUsuarioServicio["cant_bocas"] = 1;
                            drUsuarioServicio["Cant_Bocas_Pac"] = 1;
                            drUsuarioServicio["Meses_Servicio"] = 0;
                            drUsuarioServicio["Meses_Cobro"] = 0;
                            drUsuarioServicio["requiere_equipo"] = "";
                            drUsuarioServicio["requiere_tarjeta"] = "";
                            drUsuarioServicio["requiere_velocidad"] = "";
                            drUsuarioServicio["categoria"] = "";
                            drUsuarioServicio["servicio_tipo"] = servicioUnico["Tipo"].ToString();
                            drUsuarioServicio["estado"] = "";
                            drUsuarioServicio["grupo"] = "";
                            drUsuarioServicio["id_localidad"] = 0;
                            drUsuarioServicio["id_usuarios"] = idUsuario;
                            drUsuarioServicio["id_zona"] = 0;
                            drUsuarioServicio["id_servicio"] = Convert.ToInt32(servicioUnico["id"]);
                            drUsuarioServicio["id_servicio_tipo"] = Convert.ToInt32(servicioUnico["id_servicios_tipos"]);
                            drUsuarioServicio["id_estado"] = 0;
                            drUsuarioServicio["id_tipo_facturacion"] = 0;
                            drUsuarioServicio["id_servicio_sub"] = 0;
                            drUsuarioServicio["id_servicio_sub_tipo"] = 0;
                            drUsuarioServicio["id_usuario_servicio_sub"] = 0;
                            drUsuarioServicio["id_velocidad"] = 0;
                            drUsuarioServicio["id_velocidad_tipo"] = 0;
                            drUsuarioServicio["Id_bonificacion_aplicada"] = 0;
                            drUsuarioServicio["Id_bonificacion_esp"] = 0;
                            drUsuarioServicio["genera_deuda_cortado"] = 0;
                            drUsuarioServicio["genera_deuda_cortado"] = 0;
                            drUsuarioServicio["id_servicio_modalidad"] = servicioUnico["id_servicios_modalidad"];
                            dtUsuariosServicios.Rows.Add(drUsuarioServicio);
                        }
                    }


                    dtMovimientosAGenerar.Clear();
                    ActualizarImporteTotal();
                    cboServicios_Modalidad.SelectedValue = Convert.ToInt32(Servicios._Modalidad.MENSUAL);
                    int idLocacion = Convert.ToInt32(dgvLocaciones.SelectedRows[0].Cells["id"].Value);
                    int modalidad = Convert.ToInt32(cboServicios_Modalidad.SelectedValue);
                    dtUsuariosServicios.DefaultView.RowFilter = String.Format("id_locacion={0} and id_servicio_modalidad={1}", idLocacion, modalidad);
                    DataView dvFiltro = new DataView(dtUsuariosServicios);
                    dvFiltro.RowFilter = String.Format("id_locacion={0} and id_servicio_modalidad={1}", idLocacion, modalidad);
                    DataTable dtFiltrada = dvFiltro.ToTable();
                    dgvUsuariosServicios.DataSource = dtFiltrada;
                    CurrencyManager cm = (CurrencyManager)BindingContext[dgvUsuariosServicios.DataSource];
                    cm.SuspendBinding();
                    foreach (DataGridViewRow item in dgvUsuariosServicios.Rows)
                    {
                        int idTipo = Convert.ToInt32(item.Cells["id_tipo"].Value);
                        if (idTipo != 1 && idTipo != 3)
                            item.Visible = false;
                        if (idTipo == 3 || idTipo == 4)
                        {
                            item.DefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Regular);

                        }
                    }
                    dtMovimientosAGenerar.Clear();
                    dtMesesPorcentajes.Clear();
                    ResetearGrillaMovimientos();
                    ResetearGrillaUsuariosServicios();
                }
                btnAgregarServicio.Enabled = true;
            }


        }

        private void btnAgregarUnicoManual_Click(object sender, EventArgs e)
        {
            frmPopUp popUp = new frmPopUp();
            popUp.Formulario = new frmFacturaManual(Usuarios.CurrentUsuario.Id, Usuarios.CurrentUsuario.Id_Usuarios_Locacion);
            popUp.ShowDialog();
        }

        private void dgvUsuariosServicios_SelectionChanged(object sender, EventArgs e)
        {
            try
            {

                idUsuarioServicio = Convert.ToInt32(dgvUsuariosServicios.SelectedRows[0].Cells["id_usuario_servicio"].Value);
                idServicio = Convert.ToInt32(dgvUsuariosServicios.SelectedRows[0].Cells["id_servicio"].Value);
                servicioNombre = dgvUsuariosServicios.SelectedRows[0].Cells["Servicio"].Value.ToString();
                idTipoServicio = Convert.ToInt32(dgvUsuariosServicios.SelectedRows[0].Cells["id_servicio_tipo"].Value);
                idModalidad = Convert.ToInt32(dgvUsuariosServicios.SelectedRows[0].Cells["id_servicio_modalidad"].Value);
                idTipoFac = Convert.ToInt32(dgvUsuariosServicios.SelectedRows[0].Cells["id_tipo_facturacion"].Value);
                fechaFactura = Convert.ToDateTime(dgvUsuariosServicios.SelectedRows[0].Cells["fecha_factura"].Value);
                idEstadoServicio = Convert.ToInt32(dgvUsuariosServicios.SelectedRows[0].Cells["id_estado"].Value);
                int idTipo = Convert.ToInt32(dgvUsuariosServicios.SelectedRows[0].Cells["id_tipo"].Value);
                if (idTipo != 1 && idTipo != 5)
                {
                    btnAgregarServicio.Enabled = false;
                    cmbcantperiodos.Enabled = false;
                }
                else
                {
                    btnAgregarServicio.Enabled = true;
                    cmbcantperiodos.Enabled = true;
                }
            }
            catch
            {
            }
        }

        private void frmGeneraComprobantesManual_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                if (pnServicios_Unicos.Visible == true)
                    pnServicios_Unicos.Visible = false;
                else
                    this.Close();
            }
        }

        private void cboServicios_Modalidad_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                dtExtras.Clear();
                if (Convert.ToInt32(cboServicios_Modalidad.SelectedValue) != Convert.ToInt32(Servicios._Modalidad.UNICO))
                {
                    dtUsuariosServicios.DefaultView.RowFilter = String.Format("id_locacion={0} and id_servicio_modalidad={1}", dgvLocaciones.SelectedRows[0].Cells["id"].Value.ToString(), Convert.ToInt32(cboServicios_Modalidad.SelectedValue));

                    if (idModalidad != Convert.ToInt32(Servicios._Modalidad.MENSUAL) && idModalidad != Convert.ToInt32(Servicios._Modalidad.PERIODO))
                    {
                        cmbcantperiodos.SelectedIndex = 0;
                        cmbcantperiodos.Enabled = false;
                    }
                    else
                        cmbcantperiodos.Enabled = true;
                    ResetearGrillaUsuariosServicios();
                }
                else
                {
                    dtUsuariosServicios.DefaultView.RowFilter = String.Format("id_servicio_modalidad={0}", Convert.ToInt16(Servicios._Modalidad.UNICO));

                    cmbcantperiodos.Enabled = false;
                }


                if (Convert.ToInt32(cboServicios_Modalidad.SelectedValue) == Convert.ToInt32(Servicios._Modalidad.MENSUAL) || Convert.ToInt32(cboServicios_Modalidad.SelectedValue) == Convert.ToInt32(Servicios._Modalidad.PERIODO))
                    dgvUsuariosServicios.Columns["seleccion"].Visible = true;
                else
                    dgvUsuariosServicios.Columns["seleccion"].Visible = false;
            }
            catch (Exception)
            {
            }

        }

        private void dgvServiciosUnicosSub_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            ImporteTotal = 0;
            foreach (DataRow importeSubServicioUnico in dtServiciosUnicosSub.Rows)
            {
                try
                {
                    ImporteTotal += Convert.ToDecimal(importeSubServicioUnico["Importe"]);
                }
                catch
                {

                }
            }
            txttotal.Text = ImporteTotal.ToString();
        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void imgServicios_Unicos_Click(object sender, EventArgs e)
        {
            splitContainer1.Panel1Collapsed = false;
            splitContainer1.Panel2Collapsed = true;
            pnServicios_Unicos.Visible = false;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (dgvMovimientosAGenerar.Rows.Count > 0)
            {
                DialogResult dialogResult = MessageBox.Show("A continuación se procederá a generar las deudas presentes en la grilla. ¿Desea continuar?", "", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    GeneraDeudas = true;
                    btnGuardar.Enabled = false;

                    ComenzarCarga();
                }
            }
            else
                MessageBox.Show("No hay datos para generar deudas.");
        }

        private void SetearDGVSub(int index = -1)
        {
            try
            {
                if (dtMesesPorcentajes.Rows.Count > 0)
                {
                    if (index == -1)
                        index = Convert.ToInt32(dtMesesPorcentajes.Rows[0]["indice"]);

                    DataTable aux = dtMesesPorcentajes.Copy();
                    DataView dv = new DataView(aux);
                    dv.RowFilter = String.Format("indice = {0}", index);
                    aux = dv.ToTable();
                    DataTable dtDatosVelocidad = new DataTable();
                    if (aux.Select("id_servicios_velocidades>0").Length > 0)
                    {
                        foreach (DataRow item in aux.Rows)
                        {
                            if (Convert.ToInt32(item["id_usuarios_servicios_sub_tipos"]) == 1)
                            {
                                dtDatosVelocidad = oVelocidad.ListarDatosVelocidades(Convert.ToInt32(item["id_servicios_velocidades"]), Convert.ToInt32(item["id_servicios_velocidades_tipos"]));
                                if (dtDatosVelocidad.Rows.Count > 0)
                                    item["subservicio"] = item["subservicio"].ToString() + " " + dtDatosVelocidad.Rows[0]["velocidad"] + " MB " + dtDatosVelocidad.Rows[0]["nombre"];
                            }
                        }
                    }
                    dgvSub.DataSource = aux;
                    foreach (DataGridViewColumn col in dgvSub.Columns)
                        col.Visible = false;
                    dgvSub.Columns["subservicio"].Visible = true;
                    dgvSub.Columns["subservicio"].DisplayIndex = 0;
                    dgvSub.Columns["subservicio"].HeaderText = "Subservicio";
                    dgvSub.Columns["subservicio"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                    dgvSub.Columns["importe_original"].Visible = true;
                    dgvSub.Columns["importe_original"].DisplayIndex = 1;
                    dgvSub.Columns["importe_original"].HeaderText = "Importe Original";
                    dgvSub.Columns["importe_original"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dgvSub.Columns["importe_original"].DefaultCellStyle.Format = "C2";
                    dgvSub.Columns["importe_con_descuento"].Visible = true;
                    dgvSub.Columns["importe_con_descuento"].DisplayIndex = 2;
                    dgvSub.Columns["importe_con_descuento"].HeaderText = "Importe con descuento";
                    dgvSub.Columns["importe_con_descuento"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dgvSub.Columns["importe_con_descuento"].DefaultCellStyle.Format = "C2";


                    dgvSub.Columns["nombre_bonificacion"].Visible = true;
                    dgvSub.Columns["nombre_bonificacion"].DisplayIndex = 3;
                    dgvSub.Columns["nombre_bonificacion"].HeaderText = "Bonificacion";

                    dgvSub.ColumnHeadersDefaultCellStyle.Padding = new Padding(5, 5, 5, 5);

                }
                else
                    dgvSub.DataSource = null;
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }

        private void dgvMovimientosAGenerar_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            SetearDGVSub(Convert.ToInt32(dgvMovimientosAGenerar.Rows[e.RowIndex].Cells["indice_inicial"].Value));
        }

        private void btnAgregarServicio_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt16(cboServicios_Modalidad.SelectedValue) == Convert.ToInt32(Servicios._Modalidad.MENSUAL) || Convert.ToInt16(cboServicios_Modalidad.SelectedValue) == Convert.ToInt32(Servicios._Modalidad.PERIODO))
            {
                if (dgvUsuariosServicios.Rows.Count > 0)
                {
                    if (dgvUsuariosServicios.SelectedRows.Count > 0)
                    {
                        foreach (DataGridViewRow fila in dgvUsuariosServicios.Rows)
                        {
                            if (Convert.ToInt16(fila.Cells["id_tipo"].Value) == Convert.ToInt16(Usuarios_Servicios._TipoItemServicio.SERVICIO_PROPIO) && fila.Cells["seleccion"].Value.ToString() == "True")
                            {
                                idUsuarioServicio = Convert.ToInt32(fila.Cells["id_usuario_servicio"].Value);
                                idServicio = Convert.ToInt32(fila.Cells["id_servicio"].Value);
                                servicioNombre = fila.Cells["Servicio"].Value.ToString();
                                idTipoServicio = Convert.ToInt32(fila.Cells["id_servicio_tipo"].Value);
                                idModalidad = Convert.ToInt32(fila.Cells["id_servicio_modalidad"].Value);
                                idTipoFac = Convert.ToInt32(fila.Cells["id_tipo_facturacion"].Value);
                                fechaFactura = Convert.ToDateTime(fila.Cells["fecha_factura"].Value);
                                idEstadoServicio = Convert.ToInt32(fila.Cells["id_estado"].Value);
                                int idTipo = Convert.ToInt32(fila.Cells["id_tipo"].Value);
                                int idModalidadVigente = 0;
                                if (dtMovimientosAGenerar.Rows.Count > 0)
                                    idModalidadVigente = Convert.ToInt16(dtMovimientosAGenerar.Rows[0]["id_modalidad"]);
                                if (idModalidadVigente == 0 || idModalidadVigente == idModalidad)
                                {
                                    dtDatosVelocidadesUsuaServicios = oServiciosVelocidades.ListarVelocidadesUsuarios(idUsuarioServicio);
                                    DataRow drDatosTipoServicio = oServicioTipo.ListarDatosTipoServicio(idTipoServicio);
                                    servicioGrupo = drDatosTipoServicio["nombre"].ToString();
                                    servicioTipo = drDatosTipoServicio["nombre1"].ToString();
                                    dtDatosUsuSer = oUsuariosServicios.Traer_datos_usuarios_servicios(idUsuarioServicio);
                                    if (idModalidad == Convert.ToInt32(Servicios._Modalidad.DIA))
                                        AgregarServicioPrepago();
                                    else if (idModalidad == Convert.ToInt32(Servicios._Modalidad.MENSUAL) || idModalidad == Convert.ToInt32(Servicios._Modalidad.PERIODO))
                                        AgregarServicioMensualOPeriodo();
                                    else if (idModalidad == Convert.ToInt32(Servicios._Modalidad.PERIODO_CERRADO_POR_DIA) || idModalidad == Convert.ToInt32(Servicios._Modalidad.PERIODO_CERRADO_POR_MES))
                                        AgregarServicioCerrado(idModalidad);
                                    else if (idModalidad == Convert.ToInt32(Servicios._Modalidad.UNICO))
                                        AgregarServicioUnico();
                                    else
                                        MessageBox.Show("La modalidad del servicio no se encuentra registrada en el sistema.");
                                }
                                else
                                    MessageBox.Show("La modalidad del servicio seleccionado es distinta a la modalidad presente en la grilla de movimientos. Para generar movimientos para servicios de una nueva modalidad, cancele o genere los movimientos existentes.");
                            }
                        }
                    }
                    else
                        MessageBox.Show("No se ha seleccionado un servicio de la grilla.");
                }
            }
            else
            {
                if (dgvUsuariosServicios.Rows.Count > 0)
                {
                    if (dgvUsuariosServicios.SelectedRows.Count > 0)
                    {
                        int idModalidadVigente = 0;
                        if (dtMovimientosAGenerar.Rows.Count > 0)
                        {
                            idModalidadVigente = Convert.ToInt16(dtMovimientosAGenerar.Rows[0]["id_modalidad"]);
                        }

                        if (idModalidadVigente == 0 || idModalidadVigente == idModalidad)
                        {
                            dtDatosVelocidadesUsuaServicios = oServiciosVelocidades.ListarVelocidadesUsuarios(idUsuarioServicio);
                            DataRow drDatosTipoServicio = oServicioTipo.ListarDatosTipoServicio(idTipoServicio);
                            int x = 19;
                            servicioGrupo = drDatosTipoServicio["nombre"].ToString();
                            servicioTipo = drDatosTipoServicio["nombre1"].ToString();
                            dtDatosUsuSer = oUsuariosServicios.Traer_datos_usuarios_servicios(idUsuarioServicio);


                            if (idModalidad == Convert.ToInt32(Servicios._Modalidad.DIA))
                                AgregarServicioPrepago();
                            else if (idModalidad == Convert.ToInt32(Servicios._Modalidad.PERIODO))
                                AgregarServicioMensualOPeriodo();
                            else if (idModalidad == Convert.ToInt32(Servicios._Modalidad.PERIODO_CERRADO_POR_DIA) || idModalidad == Convert.ToInt32(Servicios._Modalidad.PERIODO_CERRADO_POR_MES))
                                AgregarServicioCerrado(idModalidad);
                            else if (idModalidad == Convert.ToInt32(Servicios._Modalidad.UNICO))
                                AgregarServicioUnico();
                            else
                                MessageBox.Show("La modalidad del servicio no se encuentra registrada en el sistema.");
                        }
                        else
                            MessageBox.Show("La modalidad del servicio seleccionado es distinta a la modalidad presente en la grilla de movimientos. Para generar movimientos para servicios de una nueva modalidad, cancele o genere los movimientos existentes.");
                    }
                    else
                        MessageBox.Show("No se ha seleccionado un servicio de la grilla.");
                }
            }
        }

        private void AgregarSubServicioADtMesesPorcentaje()
        {

        }

        private void dgvMovimientosAGenerar_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            e.Column.SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        private void btnConfirmaUnicos_Click(object sender, EventArgs e)
        {
            AgregarServicioUnicoAMovimientos();
        }
        #endregion
    }
}//291119fede
