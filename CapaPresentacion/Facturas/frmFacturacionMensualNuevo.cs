using BrightIdeasSoftware;
using CapaNegocios;
using CapaPresentacion.General;
using PlataformasPagos.CaptarPagos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using System.Xml.Serialization;
using Excel = Microsoft.Office.Interop.Excel;

namespace CapaPresentacion
{
    public partial class frmFacturacionMensualNuevo : Form
    {

        private Thread hilo;
        private delegate void myDel();
        private Configuracion oConfig = new Configuracion();
        private CapaNegocios.Facturacion oFacturacion = new CapaNegocios.Facturacion();
        private Bonificaciones oBonificaciones = new Bonificaciones();
        private Usuarios_CtaCte oUsuariosCtaCte = new Usuarios_CtaCte();
        private Usuarios_CtaCte_Det oUsuariosCtaCteDet = new Usuarios_CtaCte_Det();
        private Comprobantes oComprobantes = new Comprobantes();
        private ComprobanteFacturacion oPreComprobante = new ComprobanteFacturacion();
        private Comprobantes_Tipo oComprobantesTipo = new Comprobantes_Tipo();
        private Servicios_Tarifas oServiciosTarifas = new Servicios_Tarifas();
        private Usuarios_Servicios_Novedades oUsuariosServiciosNovedades = new Usuarios_Servicios_Novedades();
        private Usuarios_Servicios oUsuariosServicios = new Usuarios_Servicios();
        private Usuarios oUsuario = new Usuarios();
        private Facturacion_Mensual_Historial oFacturacionMensualHistorial = new Facturacion_Mensual_Historial();
        private Tools oTools = new Tools();
        private Plasticos_Usuarios oPlasticosUsuarios = new Plasticos_Usuarios();
        private Presentacion_Debitos oPresentacion = new Presentacion_Debitos();
        private DataRow drDatosComprobanteVenta = null;
        private DataTable dtServiciosSubSinBonificar = new DataTable();
        private DataTable dtDatosPlasticosUsuarios = new DataTable();
        private DataTable dtDeduasAnexadas = new DataTable();
        private DataTable dtServiciosSubListosParaFacturar = new DataTable();
        private DataTable dtServiciosAFacturar = new DataTable();
        private DataTable dtDatosUsuarios = new DataTable();
        private DataTable dtFiltroLocacion = new DataTable();
        private DataTable dtExtras = new DataTable();
        private DataTable dtUsuBonificacionesConfig = new DataTable();
        private DataTable dtMesesPorcentajes = new DataTable();
        private DataTable dtUltimaPresentacion = new DataTable();
        private DataTable dtNovedades = new DataTable();
        private DataTable dtErroresProducidos = new DataTable();
        private DataTable dtUsuariosServicios = new DataTable();
        private DataTable dtFiltroMesesPorcentajes = new DataTable();
        private DateTime fechaDesde = new DateTime();
        private DateTime fechaHasta = new DateTime();
        private DateTime ultimaFechaFacturacion;
        private DataView dtvMesesPorcentajes;
        private CapaNegocios.PagosExternos.PagoExterno oPagoExterno = new CapaNegocios.PagosExternos.PagoExterno();
        private CapaNegocios.PagosExternos.CaptarPagos.CaptarPagosImplement oIm = new CapaNegocios.PagosExternos.CaptarPagos.CaptarPagosImplement();

        private Stopwatch reloj = new Stopwatch();
        private Stopwatch relojDeudas = new Stopwatch();
        private int cantidadErroresGenerales = 0, idTarifaActual = 0, idLocacion = 0, idUsuarioServicio = 0, idUsuarioSubServicio = 0, nComprobante = 0, nMesesCobro = 0, idPlastico = 0, codigoUsuario = 0, idCondicionIva = 0;
        private int total, contadorParcial, idUsuario = 0, idServicio = 0, idServicioSub, idUsuarioServicioSub, idTipoFacturacion, idVelocidad, idVelocidadTipo, mesesCobro, mesesServicio, requiereIp,idServicioEstado;
        private string categoria,numeroPlastico, locacion, usuario, servicio, subservicio, tipoSubServicio;
        private bool GeneraDeudas = false, debitos = false, usuarioSolo = false;
        private decimal montoDescuentoTotalFacturacion = 0, totalDebitado = 0, importeDeudaAnexada = 0, totalAnexado, montoOriginalTotalFacturacion = 0, impuestoProvincial = 0, importeOriginal, importeFinal;
        private decimal importeProvincial = 0, importeProvinLoc = 0, importeNeto = 0, importeNetoLocacion = 0, importeBonificacion = 0;
        private Usuarios_Ctacte_Det_Extra oUsuariosCtaCteDetExtra = new Usuarios_Ctacte_Det_Extra();
        private List<int> ctactes = new List<int>();
        private List<int> anexadas = new List<int>();
        private List<ComprobanteFacturacion> ListaComprobantes = new List<ComprobanteFacturacion>();
        private decimal totalFacturacion;

        #region MÉTODOS
        private void CargarDatos()
        {
            int controlErrores = 0;
            if (GeneraDeudas == false)
            {
                pgCircular.Start();
                dtServiciosSubSinBonificar.Clear();
                dtUsuBonificacionesConfig.Clear();
                dtServiciosAFacturar.Clear();
                dtFiltroLocacion.Clear();
                try
                {
                    DateTime PrimerDia = new DateTime(dtpFecha.Value.Year, dtpFecha.Value.Month, 1).AddMonths(1);
                    DateTime UltimoDia = PrimerDia.AddDays(-1);
                    if (usuarioSolo)
                        dtServiciosSubSinBonificar = oFacturacion.RetornarSubServiciosFacturacionMensual(idTarifaActual, Convert.ToInt32(spnCantidad.Value), UltimoDia, false, true, debitos, Convert.ToInt32(spnCantidad.Value));
                    else
                        dtServiciosSubSinBonificar = oFacturacion.RetornarSubServiciosFacturacionMensual(idTarifaActual, 0, UltimoDia, false, true, debitos, Convert.ToInt32(spnCantidad.Value));

                }
                catch (Exception x)
                {
                    controlErrores = 1;
                    MessageBox.Show("ERROR: Se produjeron errores al intentar listar subservicios. El proceso no puede continuar.");
                    DataRow drNuevoError = dtErroresProducidos.NewRow();
                    drNuevoError["id_usuario"] = "0";
                    drNuevoError["codigo_usuario"] = "0";
                    drNuevoError["usuario"] = "0";
                    drNuevoError["id_locacion"] = "0";
                    drNuevoError["error"] = "ERROR: Se produjeron errores al intentar listar subservicios. El proceso no puede continuar. Error: " + x.Message;
                    dtErroresProducidos.Rows.Add(drNuevoError);
                    cantidadErroresGenerales++;
                }
                pgCircular.Stop();
                if (controlErrores == 0)
                {

                    if (dtServiciosSubSinBonificar.Rows.Count > 0)
                    {
                        foreach (DataRow subServicios in dtServiciosSubSinBonificar.Rows)
                            subServicios["fecha_inicio_servicio"] = dtpFecha.Value.Date;
                        TraerConfiguracionBonificacionesUsuarios(dtServiciosSubSinBonificar, dtUsuBonificacionesConfig);
                        btnBuscar.Enabled = false;
                        pbProgreso.Visible = true;
                        lblProgreso.Visible = true;
                        pbProgreso.Maximum = dtUsuBonificacionesConfig.Rows.Count;
                        this.KeyPreview = false;
                        Cursor = Cursors.WaitCursor;
                        bgwCalcularMontos.DoWork += CalcularBonificaciones;
                        bgwCalcularMontos.RunWorkerCompleted += Terminado;
                        bgwCalcularMontos.RunWorkerAsync();
                    }
                    else
                    {
                        MessageBox.Show("No se encontraron sub servicios", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    lblPeriodoSeleccionado.Text = String.Format("Periodo seleccionado: Mes {0}  Año {1}", dtpFecha.Value.Month, dtpFecha.Value.Year);
                    lblTotal.Text = String.Format("Total de Registros: {0}", ListaComprobantes.Count);
                    btnBuscar.Enabled = true;
                    btnFacturacion.Enabled = true;

                }
            }
            else
            {
                pbProgreso.Visible = true;
                lblProgreso.Visible = true;
                pbProgreso.Maximum = olvDeudas.Items.Count;
                this.KeyPreview = false;
                Cursor = Cursors.WaitCursor;
                bgwGenerarDeudas.DoWork += GenerarDeudasAsync;
                bgwGenerarDeudas.RunWorkerCompleted += Terminado;
                bgwGenerarDeudas.RunWorkerAsync();
            }
        }
        private void CalcularBonificaciones(object o, DoWorkEventArgs e)
        {
            dtErroresProducidos.Clear();
            int controlErrores = 0;
            DataTable dtTablaFiltroUsuario = new DataTable();
            DataTable dtTablaFiltroLocacion = new DataTable();
            DataTable dtTablaFiltroUsuarioServicio = new DataTable();
            DataView dtvSubServUsuario;
            DataView dtvSubServLocacion = new DataView(dtTablaFiltroUsuario);
            DataView dtvSubServUsuarioServicio;
            DataTable dtMesesPorcentajesAux = new DataTable();
            List<int> listaLocacionesUsuario = new List<int>();
            List<int> listaServiciosUsuario = new List<int>();
            decimal montoOriginalLocacion;
            decimal montoDescuentoLocacion;
            decimal montoOriginalServicio;
            decimal montoDescuentoServicio;
            int cantMaxMesesCobro = 0;
            int cantMaxMesesServicio = 0;

            dtMesesPorcentajes = oBonificaciones.GenerarDtMesesPorcentajes();
            dtMesesPorcentajesAux = oBonificaciones.GenerarDtMesesPorcentajes();
            dtvSubServUsuario = new DataView(dtServiciosSubSinBonificar);
            int x = 0;

            foreach (DataRow UsuConfig in dtUsuBonificacionesConfig.Rows)
            {

                controlErrores = 0;
                DataTable dtSubServiciosUsuarioListosFacturar = new DataTable();
                //selecciona los subservicios del usuario
                dtvSubServUsuario.RowFilter = String.Format("id_usuarios={0}", UsuConfig["id_usuarios"].ToString());
                dtTablaFiltroUsuario = dtvSubServUsuario.ToTable();

                montoOriginalLocacion = 0;
                montoDescuentoLocacion = 0;
                dtMesesPorcentajesAux.Clear();
                //error a nivel usuario
                try
                {

                    bool errorBonificaciones = true;
                    if (Convert.ToInt32(UsuConfig["calculo_bonificacion"]) == Convert.ToInt32(Usuarios._Calculo_Bonificacion.NO_SE_APLICA))
                    {
                        dtMesesPorcentajesAux = oBonificaciones.GenerarTablaRegistrosCtaCteDet(dtTablaFiltroUsuario);
                        //oBonificaciones.AgregarMontoIpFija(dtTablaFiltroUsuario, dtMesesPorcentajesAux);
                        oBonificaciones.RecalcularImportes(dtTablaFiltroUsuario, dtMesesPorcentajesAux, true);
                    }

                    if (Convert.ToInt32(UsuConfig["calculo_bonificacion"]) == Convert.ToInt32(Usuarios._Calculo_Bonificacion.POR_USUARIO))
                    {
                        oFacturacion.AgregarSubServiciosHeredados(dtTablaFiltroUsuario);
                        errorBonificaciones = oBonificaciones.CalcularBonificaciones(dtTablaFiltroUsuario, idTarifaActual, false, 1, true);
                        if (errorBonificaciones)
                        {
                            dtTablaFiltroUsuario = Bonificaciones.dtSubServicios;
                            dtMesesPorcentajesAux = Bonificaciones.dtSubServiciosDetalles;
                        }
                    }

                    if (errorBonificaciones == false)
                    {
                        controlErrores++;
                        DataRow drNuevoError = dtErroresProducidos.NewRow();
                        drNuevoError["id_usuario"] = UsuConfig["id_usuarios"];
                        drNuevoError["codigo_usuario"] = UsuConfig["codigo_usuario"];
                        drNuevoError["usuario"] = UsuConfig["usuario"];
                        drNuevoError["id_locacion"] = "0";
                        drNuevoError["error"] = "Error al calcular bonificaciones del usuario. El usuario no estará en facturación mensual.";
                        dtErroresProducidos.Rows.Add(drNuevoError);
                    }
                }
                catch (Exception c)
                {
                    controlErrores++;
                    DataRow drNuevoError = dtErroresProducidos.NewRow();
                    drNuevoError["id_usuario"] = UsuConfig["id_usuarios"];
                    drNuevoError["codigo_usuario"] = UsuConfig["codigo_usuario"];
                    drNuevoError["usuario"] = UsuConfig["usuario"];
                    drNuevoError["id_locacion"] = "0";
                    drNuevoError["error"] = "Error al calcular bonificaciones del usuario. El usuario no estará en facturación mensual. " + c.Message;
                    dtErroresProducidos.Rows.Add(drNuevoError);
                }

                if (controlErrores == 0)
                {
                    List<Int32> listaAnexadas = new List<int>();//si la deuda todavia no la agrege a dtserviciosafacturar la agrego u la agrego a la lista, esto e spara que no se agrege mas de unja vez la misma deuda 
                    List<Int32> listaAnexadasAux = new List<int>();
                    int idCtacteDet = 0; //el id de det que meto en la lista para que cuando recorra por segunda vez este usuario no vuelva a buscar las mimas deudas anexadas y las vuelva a agregar
                    foreach (DataRow SubServicio in dtTablaFiltroUsuario.Rows)
                    {
                        idLocacion = Convert.ToInt32(SubServicio["id_usuarios_locaciones"]);
                        if (listaLocacionesUsuario.Contains(idLocacion) == false)
                        {
                            //error a nivel locación
                            try
                            {
                                idTipoFacturacion = Convert.ToInt32(SubServicio["id_tipo_facturacion"]);
                                listaLocacionesUsuario.Add(idLocacion);
                                dtTablaFiltroLocacion.Clear();
                                montoOriginalLocacion = 0;
                                montoDescuentoLocacion = 0;
                                cantMaxMesesCobro = 0;
                                cantMaxMesesServicio = 0;
                                dtvSubServLocacion = new DataView(dtTablaFiltroUsuario);
                                dtvSubServLocacion.RowFilter = String.Format("id_usuarios_locaciones={0}", idLocacion);
                                dtTablaFiltroLocacion = dtvSubServLocacion.ToTable();
                                bool errorBonificacion = true;

                                if (Convert.ToInt32(UsuConfig["calculo_bonificacion"]) == Convert.ToInt32(Usuarios._Calculo_Bonificacion.POR_LOCACION))
                                {
                                    oFacturacion.AgregarSubServiciosHeredados(dtTablaFiltroLocacion);
                                    errorBonificacion = oBonificaciones.CalcularBonificaciones(dtTablaFiltroLocacion, idTarifaActual, false, 1, true);
                                    if (errorBonificacion)
                                    {
                                        dtTablaFiltroLocacion = Bonificaciones.dtSubServicios;
                                        dtMesesPorcentajesAux = Bonificaciones.dtSubServiciosDetalles;
                                    }
                                }

                                DataView dtvTablaSinHeredados = new DataView(dtTablaFiltroLocacion);
                                dtvTablaSinHeredados.RowFilter = "heredado=0";
                                dtTablaFiltroLocacion = dtvTablaSinHeredados.ToTable();

                                if (dtMesesPorcentajesAux.Rows.Count > 0)
                                {
                                    oFacturacion.AplicarNovedades(dtTablaFiltroLocacion, dtMesesPorcentajesAux, idLocacion, fechaDesde, true);
                                    if (dtExtras.Rows.Count == 0)
                                        dtExtras = oFacturacion.dtExtras.Copy();
                                    else
                                    {
                                        foreach (DataRow fila in oFacturacion.dtExtras.Rows)
                                            dtExtras.ImportRow(fila);
                                    }
                                }

                                if (errorBonificacion == false)
                                {
                                    controlErrores++;
                                    DataRow drNuevoError = dtErroresProducidos.NewRow();
                                    drNuevoError["id_usuario"] = UsuConfig["id_usuarios"];
                                    drNuevoError["codigo_usuario"] = UsuConfig["codigo_usuario"];
                                    drNuevoError["usuario"] = UsuConfig["usuario"];
                                    drNuevoError["id_locacion"] = "0";
                                    drNuevoError["error"] = "Error al calcular bonificaciones del usuario. El usuario no estará en facturación mensual.";
                                    dtErroresProducidos.Rows.Add(drNuevoError);
                                }
                            }
                            catch (Exception c)
                            {
                                controlErrores++;
                                DataRow drNuevoError = dtErroresProducidos.NewRow();
                                drNuevoError["id_usuario"] = UsuConfig["id_usuarios"];
                                drNuevoError["codigo_usuario"] = UsuConfig["codigo_usuario"];
                                drNuevoError["usuario"] = UsuConfig["usuario"];
                                drNuevoError["id_locacion"] = SubServicio["id_usuarios_locaciones"];
                                drNuevoError["error"] = "Error al calcular bonificaciones para la locación. La locación no estará en facturación mensual.: " + c.Message;
                                dtErroresProducidos.Rows.Add(drNuevoError);
                            }
                            if (controlErrores == 0)
                            {
                                //busca el porcentaje de impuesto provincial
                                dtDatosUsuarios = oUsuario.Buscar_datos_usuario(Convert.ToInt32(SubServicio["id_usuarios"]));
                                impuestoProvincial = Convert.ToDecimal(dtDatosUsuarios.Rows[0]["impuesto_provincial"]);
                                idCondicionIva = Convert.ToInt32(dtDatosUsuarios.Rows[0]["Id_Comprobantes_Iva"]);
                                //si es responsable inscripto o responsable monotributo y el porcentaje del impuesto esta en 0 se le pone el valor configurado
                                if (oConfig.GetValor_C("Retencion").Equals("S"))
                                {
                                    if ((idCondicionIva == 2 || idCondicionIva == 3) && (impuestoProvincial == 0))
                                        impuestoProvincial = oConfig.GetValor_Decimal("Retencion_IIBB");
                                }
                                else
                                    impuestoProvincial = 0;
                                importeNetoLocacion = 0;
                                //filtra los servicios que se facturan mensualmente y/o los servicios que se vence la fecha factura del servicio
                                dtvSubServLocacion = new DataView(dtTablaFiltroLocacion);
                                dtvSubServLocacion.RowFilter = String.Format("fecha_factura<'{0}' and factura_mensualmente='SI'", dtpFecha.Value.ToString("yyyy-MM-dd"));
                                dtTablaFiltroLocacion = dtvSubServLocacion.ToTable();
                                importeNetoLocacion = 0;
                                montoDescuentoLocacion = 0;
                                decimal importeProvAux = 0;
                                decimal importeNetoAux = 0;
                                decimal impoteProvAcu = 0;
                                foreach (DataRow fila in dtMesesPorcentajesAux.Rows)//suma los importes de los subservicios que pertenecen a la locación para calcular el total por locación
                                {
                                    idUsuarioServicio = Convert.ToInt32(fila["id_usuarios_servicios"]);
                                    DataRow[] drSubFechaFac = dtTablaFiltroLocacion.Select(string.Format("id_usuario_servicio='{0}'", idUsuarioServicio.ToString()));
                                    if (drSubFechaFac.Length > 0)
                                    {
                                        //calcula el importe provincial total de la locacion
                                        importeNetoAux = Convert.ToDecimal(fila["importe_con_descuento"]);
                                        importeNetoAux /= 1.21m;
                                        importeProvAux = importeNetoAux * impuestoProvincial / 100;

                                        importeNetoLocacion += importeNetoAux;
                                        impoteProvAcu += importeProvAux;//acumula el importeProvincial total
                                        montoOriginalLocacion += Convert.ToDecimal(fila["importe_original"]);
                                        montoDescuentoLocacion += Convert.ToDecimal(fila["importe_con_descuento"]);

                                        //determina el max y minimo de meses de cobro y meses de servicio
                                        if (Convert.ToInt32(fila["meses_cobro"]) > cantMaxMesesCobro)
                                            cantMaxMesesCobro = Convert.ToInt32(fila["meses_cobro"]);

                                        if (Convert.ToInt32(fila["meses_servicio"]) > cantMaxMesesServicio)
                                            cantMaxMesesServicio = Convert.ToInt32(fila["meses_servicio"]);
                                    }
                                }
                                fechaHasta = fechaDesde.AddMonths(cantMaxMesesServicio).AddDays(-1);
                                ComprobanteFacturacion oPreComprobante = new ComprobanteFacturacion();
                                if (dtTablaFiltroLocacion.Rows.Count > 0)
                                {
                                    if (debitos)
                                    {
                                        dtDatosPlasticosUsuarios = oPlasticosUsuarios.BuscarPlasticosServicio(Convert.ToInt32(SubServicio["id_usuario_servicio"]));
                                        if (dtDatosPlasticosUsuarios.Rows.Count > 0)
                                        {
                                            numeroPlastico = dtDatosPlasticosUsuarios.Rows[0]["numero"].ToString() + "\u2003";
                                            idPlastico = Convert.ToInt32(dtDatosPlasticosUsuarios.Rows[0]["id"]);
                                        }
                                        else
                                        {
                                            idPlastico = 0;
                                            numeroPlastico = "Error al buscar plastico";
                                        }
                                    }
                                    else
                                    {
                                        idPlastico = 0;
                                        numeroPlastico = string.Empty;
                                    }

                                    locacion = String.Format("Calle: {0} {1}, {2}, {3}, {4}", SubServicio["calle"], SubServicio["altura"], SubServicio["piso"], SubServicio["depto"], SubServicio["localidad"]);
                                    servicio = SubServicio["servicio"].ToString();
                                    subservicio = SubServicio["subservicio"].ToString();
                                    codigoUsuario = Convert.ToInt32(SubServicio["codigo_usuario"]);
                                    idCondicionIva = Convert.ToInt32(dtDatosUsuarios.Rows[0]["Id_Comprobantes_Iva"]);
                                    importeBonificacion = montoOriginalLocacion - montoDescuentoLocacion;
                                    usuario = SubServicio["usuario"].ToString();
                                    idUsuario = Convert.ToInt32(SubServicio["id_usuarios"]);
                                    idLocacion = Convert.ToInt32(SubServicio["id_usuarios_locaciones"]);
                                    idServicio = Convert.ToInt32(SubServicio["id_servicio"]);
                                    idServicioSub = Convert.ToInt32(SubServicio["id_servicio_sub"]);
                                    idUsuarioServicio = Convert.ToInt32(SubServicio["id_usuario_servicio"]);
                                    idUsuarioServicioSub = Convert.ToInt32(SubServicio["id_usuario_servicio_sub"]);
                                    //fechaDesdeServicio = Convert.ToDateTime(SubServicio["fecha_desde"]);                 
                                    idServicioEstado = Convert.ToInt32(SubServicio["id_servicios_estados"]);
                                    categoria = SubServicio["tipo_fac"].ToString();
                                    List<Usuarios_CtaCte_Det> listaUCCD = new List<Usuarios_CtaCte_Det>();
                                    if (debitos)//se busca si tiene deudas anexadas y se le suma el importe a la cabeza
                                    {
                                        dtDeduasAnexadas.Clear();
                                        dtDeduasAnexadas = oUsuariosCtaCteDet.ListarCtaCteDetAnexados(dtpFecha.Value.Month, dtpFecha.Value.Year, idPlastico, Convert.ToInt32(SubServicio["id_usuarios"]), Convert.ToInt32(SubServicio["id_usuarios_locaciones"]));

                                        importeDeudaAnexada = 0;
                                        foreach (DataRow fila in dtDeduasAnexadas.Rows)
                                        {
                                            idCtacteDet = Convert.ToInt32(fila["id"]);
                                            if (!listaAnexadas.Contains(idCtacteDet))
                                            {
                                                Usuarios_CtaCte_Det oUccd = new Usuarios_CtaCte_Det();
                                                oUccd.Id = Convert.ToInt32(fila["id"]);
                                                oUccd.Detalles = fila["subservicio"].ToString();
                                                oUccd.Fecha_Desde = Convert.ToDateTime(fila["fecha_desde"]);
                                                oUccd.Importe_Saldo = Convert.ToDecimal(fila["importe_saldo"]);
                                                oUccd.Id_Debito_asociado = idPlastico;
                                                importeDeudaAnexada = importeDeudaAnexada + Convert.ToDecimal(fila["importe_saldo"]);
                                                listaUCCD.Add(oUccd);
                                                listaAnexadas.Add(idCtacteDet);
                                            }

                                        }
                                    }
                                    else
                                        importeDeudaAnexada = 0;

                                    importeNeto = decimal.Round(importeNetoLocacion, 2);
                                    importeProvincial = impoteProvAcu;
                                    importeFinal = montoDescuentoLocacion + importeProvincial;
                                    importeFinal = decimal.Round(importeFinal, 2);


                                    nComprobante = 1;

                                    oPreComprobante.Id_Usuarios = idUsuario;
                                    oPreComprobante.Fecha = DateTime.Now.Date;
                                    oPreComprobante.Punto_Venta = Personal.Id_Punto_Venta;
                                    oPreComprobante.Id_Comprobantes_Tipo = Convert.ToInt32(Comprobantes_Tipo.Tipo.COMPROBANTE_DEUDA);
                                    oPreComprobante.Numero = nComprobante;
                                    oPreComprobante.Importe = importeFinal;
                                    oPreComprobante.Id_Usuarios_Locaciones = idLocacion;
                                    oPreComprobante.Id_Personal = Personal.Id_Login;
                                    oPreComprobante.Id_Punto_Venta = Personal.Id_Punto_Venta;
                                    oPreComprobante.ImporteAnexado = importeDeudaAnexada;
                                    oPreComprobante.ImporteOriginal = montoOriginalLocacion;
                                    oPreComprobante.NumeroPlastico = numeroPlastico;
                                    oPreComprobante.CodigoUsuario = codigoUsuario;
                                    oPreComprobante.Usuario = usuario;
                                    oPreComprobante.Locacion = locacion;
                                    oPreComprobante.ImporteTotal = importeFinal + importeDeudaAnexada;
                                    oPreComprobante.ImporteProvincial = importeProvincial;
                                    oPreComprobante.ImporteBonificacion = importeBonificacion;
                                    oPreComprobante.Categoria = categoria;
                                    string muestra;
                                    char pad = '0';
                                    muestra = "COMPROBANTE DE DEUDA " + "1".PadLeft(4, pad) + "-" + nComprobante.ToString().PadLeft(8, pad);
                                    oPreComprobante.Descripcion = muestra;
                                    if (debitos)
                                        oPreComprobante.TextoMuestra = codigoUsuario.ToString().PadLeft(6, pad) + " | " + usuario + " N° Tarjeta:  " + oPreComprobante.NumeroPlastico + " " + locacion + " ---> Importe final: " + importeFinal.ToString("c2") + " Importe deuda anexada: " + importeDeudaAnexada.ToString("c2") + " Importe final debitado: " + (importeFinal + importeDeudaAnexada).ToString("c2");
                                    else
                                        oPreComprobante.TextoMuestra = codigoUsuario.ToString().PadLeft(6, pad) + " | " + usuario + " " + locacion + " ---> Importe final: " + importeFinal.ToString("c2");
                                    if (idCondicionIva == 2)
                                        oPreComprobante.Responsable = " RI ";
                                    else if (idCondicionIva == 3)
                                        oPreComprobante.Responsable = " RM ";
                                    else if (idCondicionIva == 4)
                                        oPreComprobante.Responsable = " EX ";

                                    oPreComprobante.ListaAmexados = listaUCCD;

                                   
                                    oUsuariosCtaCte = new Usuarios_CtaCte();
                                    oUsuariosCtaCte.Id_Usuarios = idUsuario;
                                    oUsuariosCtaCte.Id_Comprobantes = 0;
                                    oUsuariosCtaCte.Fecha_Movimiento = DateTime.Now;
                                    oUsuariosCtaCte.Fecha_Desde = fechaDesde;
                                    oUsuariosCtaCte.Fecha_Hasta = fechaDesde.AddMonths(cantMaxMesesServicio).AddDays(-1);
                                    oUsuariosCtaCte.Descripcion = muestra;
                                    oUsuariosCtaCte.Importe_Original = montoOriginalLocacion;
                                    oUsuariosCtaCte.Importe_Punitorio = 0;
                                    oUsuariosCtaCte.Importe_Provincial = importeProvincial;
                                    oUsuariosCtaCte.Importe_Bonificacion = importeBonificacion;
                                    oUsuariosCtaCte.Importe_Final = importeFinal;
                                    oUsuariosCtaCte.Importe_Saldo = importeFinal;
                                    oUsuariosCtaCte.Id_Usuarios_Locacion = idLocacion;
                                    oUsuariosCtaCte.Numero = oPreComprobante.Numero.ToString();
                                    oUsuariosCtaCte.Id_Comprobantes_Tipo = Convert.ToInt32(Comprobantes_Tipo.Tipo.COMPROBANTE_DEUDA);
                                    oUsuariosCtaCte.Id_Comprobantes_Ref = 0;
                                    oUsuariosCtaCte.Id_Facturacion = oFacturacionMensualHistorial.Id;
                                    oUsuariosCtaCte.Generado_facturacion_mensual = Convert.ToInt32(Usuarios_CtaCte.GENERADO_FACTURACION_MENSUAL.SI);
                                    oUsuariosCtaCte.Id_Personal = Personal.Id_Login;
                                    if (debitos)
                                    {
                                        oUsuariosCtaCte.Id_Origen = (int)Usuarios_CtaCte.ORIGEN.FACTURACION_MENSUAL_DEBITOS;
                                    }
                                    else
                                        oUsuariosCtaCte.Id_Origen = (int)Usuarios_CtaCte.ORIGEN.FACTURACION_MENSUAL;

                                    oUsuariosCtaCte.Percepcion = 0;
                                    oUsuariosCtaCte.Porcentaje_Percepcion = impuestoProvincial;
                                    montoOriginalTotalFacturacion += montoOriginalLocacion;
                                    montoDescuentoTotalFacturacion += montoDescuentoLocacion;

                                    foreach (DataRow SubServ in dtTablaFiltroLocacion.Rows)
                                    {
                                        if (listaServiciosUsuario.Contains(Convert.ToInt32(SubServ["id_usuario_servicio"])) == false)
                                        {
                                            montoOriginalServicio = 0;
                                            montoDescuentoServicio = 0;
                                            listaServiciosUsuario.Add(Convert.ToInt32(SubServ["id_usuario_servicio"]));
                                            idUsuarioServicio = Convert.ToInt32(SubServ["id_usuario_servicio"]);
                                            dtvSubServUsuarioServicio = new DataView(dtTablaFiltroLocacion);
                                            dtvSubServUsuarioServicio.RowFilter = String.Format("id_usuario_servicio={0}", idUsuarioServicio);
                                            dtTablaFiltroUsuarioServicio = dtvSubServUsuarioServicio.ToTable();

                                            dtvMesesPorcentajes = new DataView(dtMesesPorcentajesAux);
                                            dtvMesesPorcentajes.RowFilter = String.Format("id_usuarios_servicios={0}", idUsuarioServicio);
                                            dtFiltroMesesPorcentajes = dtvMesesPorcentajes.ToTable();

                                            var result = dtFiltroMesesPorcentajes.AsEnumerable().Sum(auxiliar => Convert.ToDecimal(auxiliar["Importe_original"]));
                                            montoOriginalServicio = (decimal)result;
                                            result = dtFiltroMesesPorcentajes.AsEnumerable().Sum(auxiliar => Convert.ToDecimal(auxiliar["importe_con_descuento"]));
                                            montoDescuentoServicio = (decimal)result;

                                            importeNeto = montoDescuentoServicio / 1.21m;
                                            importeProvincial = impuestoProvincial * (importeNeto / 100);
                                            importeDeudaAnexada = 0;

                                            //agregamos los detalles
                                            foreach (DataRow fila in dtTablaFiltroUsuarioServicio.Rows)
                                            {
                                                importeNeto = Convert.ToDecimal(fila["importe_con_descuento"]) / 1.21m;
                                                importeProvincial = impuestoProvincial * (importeNeto / 100);

                                                oUsuariosCtaCteDet = new Usuarios_CtaCte_Det();
                                                oUsuariosCtaCteDet.Id_Usuarios_CtaCte = oUsuariosCtaCte.Id;
                                                oUsuariosCtaCteDet.Id_Usuarios_Locaciones = idLocacion;
                                                //oUsuariosCtaCteDet.Id_Zonas = Convert.ToInt32(subServicio["id_tipo_facturacion"]);
                                                oUsuariosCtaCteDet.Id_Zonas = 0;
                                                oUsuariosCtaCteDet.Id_Servicios = Convert.ToInt32(fila["id_servicio"]);
                                                oUsuariosCtaCteDet.Id_Tipo = Convert.ToInt32(fila["id_servicio_sub"]);
                                                oUsuariosCtaCteDet.Tipo = fila["tipo_servicio_sub"].ToString();
                                                oUsuariosCtaCteDet.Importe_Original = Convert.ToDecimal(fila["importe_original"]);
                                                oUsuariosCtaCteDet.Importe_Punitorio = 0;
                                                oUsuariosCtaCteDet.Importe_Bonificacion = Convert.ToDecimal(fila["importe_original"]) - Convert.ToDecimal(fila["importe_con_descuento"]);
                                                oUsuariosCtaCteDet.Id_Usuarios_Servicios = Convert.ToInt32(fila["id_usuario_servicio"]);
                                                oUsuariosCtaCteDet.Id_Velocidades_Tip = Convert.ToInt32(fila["id_velocidad_tipo"]);
                                                oUsuariosCtaCteDet.Id_Velocidades = Convert.ToInt32(fila["id_velocidad"]);
                                                oUsuariosCtaCteDet.Requiere_IP = Convert.ToInt32(fila["requiere_ip"]);
                                                oUsuariosCtaCteDet.Cantidad_Periodos = 1;
                                                oUsuariosCtaCteDet.Id_Usuarios_Servicios_sub = Convert.ToInt32(fila["id_usuario_servicio_sub"]);
                                                oUsuariosCtaCteDet.Fecha_Desde = Convert.ToDateTime(fechaDesde.ToString("yyyy-MM-dd"));
                                                oUsuariosCtaCteDet.Fecha_Hasta = fechaDesde.AddMonths(Convert.ToInt32(SubServ["meses_servicio"])).AddDays(-1);
                                                oUsuariosCtaCteDet.Id_bonificacion_Aplicada = 0;
                                                oUsuariosCtaCteDet.Nombre_Bonificacion = String.Empty;
                                                oUsuariosCtaCteDet.Porcentaje_Bonificacion = 0;
                                                oUsuariosCtaCteDet.Periodo_Mes = oUsuariosCtaCteDet.Fecha_Desde.Month;
                                                oUsuariosCtaCteDet.Periodo_Ano = oUsuariosCtaCteDet.Fecha_Desde.Year;
                                                oUsuariosCtaCteDet.Detalles = String.Format("{0} {1} {2}", fila["subservicio"], fila["velocidad"], fila["velocidad_tipo"]);
                                                oUsuariosCtaCteDet.Id_Tipo_Registro_Cta_Cte_Det = (int)Usuarios_CtaCte_Det.TIPO_REGISTRO_CTACTEDET.DETALLE;
                                                oUsuariosCtaCteDet.Importe_Provincial = decimal.Round(importeProvincial, 2);
                                                if (debitos)
                                                {
                                                    oUsuariosCtaCteDet.Ano_Presentacion = dtpFecha.Value.Year;
                                                    oUsuariosCtaCteDet.Ano_Presentacion = dtpFecha.Value.Year;
                                                    oUsuariosCtaCteDet.Id_Presentacion = oPresentacion.Id;
                                                    oUsuariosCtaCteDet.Mes_Presentacion = dtpFecha.Value.Month;
                                                    oUsuariosCtaCteDet.Id_Debito_asociado = idPlastico;
                                                }
                                                oUsuariosCtaCteDet.Importe_Saldo = decimal.Round(Convert.ToDecimal(fila["importe_con_descuento"]), 2) + decimal.Round(importeProvincial, 2);
                                                oUsuariosCtaCteDet.Importe_Final = decimal.Round(Convert.ToDecimal(fila["importe_con_descuento"]), 2) + decimal.Round(importeProvincial, 2);
                                                oUsuariosCtaCte.UsuCtaCteDet.Add(oUsuariosCtaCteDet);
                                              
                                                //agregamos las bonificaciones (usuarios_Ctacte_det_extras) 

                                                DataView dvNov = dtMesesPorcentajesAux.DefaultView;
                                                dvNov.RowFilter = string.Format("nombre_bonificacion='Novedades' and id_usuarios_servicios_sub={0}", Convert.ToInt32(fila["id_usuario_servicio_sub"]));
                                                DataTable dtNovBon = dvNov.ToTable();

                                                foreach (DataRow extra in dtMesesPorcentajesAux.Select(string.Format("id_usuarios_locaciones='{0}' and id_usuarios_servicios_sub = '{1}' and nombre_bonificacion<>'Novedades'", idLocacion, Convert.ToInt32(fila["id_usuario_servicio_sub"]))))
                                                {
                                                    if (Convert.ToInt32(extra["id_bonificacion"]) > 0 && extra["nombre_bonificacion"].ToString().ToLower() != "novedades")
                                                    {
                                                        oUsuariosCtaCteDetExtra = new Usuarios_Ctacte_Det_Extra();
                                                        oUsuariosCtaCteDetExtra.Id_Extra = Convert.ToInt32(extra["id_bonificacion"]);
                                                        oUsuariosCtaCteDetExtra.Id_Tipo_Extra = Convert.ToInt32(Usuarios_Ctacte_Det_Extra.TiposExtras.BONIFICACION);
                                                        oUsuariosCtaCteDetExtra.Id_Usuarios_CtaCte_Det = oUsuariosCtaCteDet.Id;
                                                        oUsuariosCtaCteDetExtra.Porcentaje = Convert.ToDecimal(extra["porcentaje_parcial"]);
                                                        oUsuariosCtaCteDetExtra.Importe_original = Convert.ToDecimal(extra["importe_original"]);
                                                        if (Convert.ToInt32(extra["id_bonificacion_contratacion"]) > 0)
                                                            oUsuariosCtaCteDetExtra.Importe_Nuevo = Convert.ToDecimal(extra["importe_con_descuento_parcial"]);
                                                        else
                                                            oUsuariosCtaCteDetExtra.Importe_Nuevo = Convert.ToDecimal(extra["importe_con_descuento"]);
                                                        oUsuariosCtaCteDetExtra.Detalle = extra["nombre_bonificacion"].ToString();
                                                        oUsuariosCtaCteDetExtra.Extra = String.Empty;

                                                        oUsuariosCtaCteDet.ListaExtras.Add(oUsuariosCtaCteDetExtra);
                                                    }
                                                    DataView dvExtras = dtExtras.DefaultView;
                                                    int idUsuSub = oUsuariosCtaCteDet.Id_Usuarios_Servicios_sub;
                                                    int mesaux = oUsuariosCtaCteDet.Periodo_Mes;
                                                    dvExtras.RowFilter = String.Format("id_usuario_servicio_sub={0} and nro_mes={1}", idUsuSub, mesaux);
                                                    DataTable dt = dvExtras.ToTable();
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
                                                        //oUsuariosCtaCteDetExtra.Guardar(oUsuariosCtaCteDetExtra);
                                                        oUsuariosCtaCteDet.ListaExtras.Add(oUsuariosCtaCteDetExtra);

                                                    }
                                                }
                                                //agrego las novedades
                                                foreach (DataRow drNovBon in dtNovBon.Rows)
                                                {
                                                    importeNeto = Convert.ToDecimal(drNovBon["importe_con_descuento"]) / 1.21m;
                                                    importeProvincial = impuestoProvincial * (importeNeto / 100);

                                                    oUsuariosCtaCteDet = new Usuarios_CtaCte_Det();
                                                    oUsuariosCtaCteDet.Id_Usuarios_CtaCte = oUsuariosCtaCte.Id;
                                                    oUsuariosCtaCteDet.Id_Usuarios_Locaciones = idLocacion;
                                                    //oUsuariosCtaCteDet.Id_Zonas = Convert.ToInt32(subServicio["id_tipo_facturacion"]);
                                                    oUsuariosCtaCteDet.Id_Zonas = 0;
                                                    oUsuariosCtaCteDet.Id_Servicios = Convert.ToInt32(fila["id_servicio"]);
                                                    oUsuariosCtaCteDet.Id_Tipo = Convert.ToInt32(fila["id_servicio_sub"]);
                                                    oUsuariosCtaCteDet.Tipo = fila["tipo_servicio_sub"].ToString();
                                                    oUsuariosCtaCteDet.Importe_Original = Convert.ToDecimal(drNovBon["importe_original"]);
                                                    oUsuariosCtaCteDet.Importe_Punitorio = 0;
                                                    oUsuariosCtaCteDet.Importe_Bonificacion = 0;
                                                    oUsuariosCtaCteDet.Id_Usuarios_Servicios = Convert.ToInt32(fila["id_usuario_servicio"]);
                                                    oUsuariosCtaCteDet.Id_Velocidades_Tip = Convert.ToInt32(fila["id_velocidad_tipo"]);
                                                    oUsuariosCtaCteDet.Id_Velocidades = Convert.ToInt32(fila["id_velocidad"]);
                                                    oUsuariosCtaCteDet.Requiere_IP = Convert.ToInt32(fila["requiere_ip"]);
                                                    oUsuariosCtaCteDet.Cantidad_Periodos = 1;
                                                    oUsuariosCtaCteDet.Id_Usuarios_Servicios_sub = Convert.ToInt32(fila["id_usuario_servicio_sub"]);
                                                    oUsuariosCtaCteDet.Fecha_Desde = Convert.ToDateTime(fechaDesde.ToString("yyyy-MM-dd"));
                                                    oUsuariosCtaCteDet.Fecha_Hasta = fechaDesde.AddMonths(Convert.ToInt32(SubServ["meses_servicio"])).AddDays(-1);
                                                    oUsuariosCtaCteDet.Id_bonificacion_Aplicada = 0;
                                                    oUsuariosCtaCteDet.Nombre_Bonificacion = String.Empty;
                                                    oUsuariosCtaCteDet.Porcentaje_Bonificacion = 0;
                                                    oUsuariosCtaCteDet.Periodo_Mes = oUsuariosCtaCteDet.Fecha_Desde.Month;
                                                    oUsuariosCtaCteDet.Periodo_Ano = oUsuariosCtaCteDet.Fecha_Desde.Year;
                                                    oUsuariosCtaCteDet.Id_Tipo_Registro_Cta_Cte_Det = (int)Usuarios_CtaCte_Det.TIPO_REGISTRO_CTACTEDET.NOVEDAD;
                                                    importeProvincial = impuestoProvincial * (Convert.ToDecimal(fila["importe_con_descuento"]) / 100);
                                                    importeNeto = Convert.ToDecimal(drNovBon["importe_original"]) / 1.21m;
                                                    importeProvincial = impuestoProvincial * (importeNeto / 100);
                                                    oUsuariosCtaCteDet.Importe_Provincial = decimal.Round(importeProvincial, 2);
                                                    oUsuariosCtaCteDet.Detalles = "***(NOVEDAD) " + drNovBon["subservicio"].ToString();
                                                    if (debitos)
                                                    {
                                                        oUsuariosCtaCteDet.Ano_Presentacion = dtpFecha.Value.Year;
                                                        oUsuariosCtaCteDet.Ano_Presentacion = dtpFecha.Value.Year;
                                                        oUsuariosCtaCteDet.Id_Presentacion = oPresentacion.Id;
                                                        oUsuariosCtaCteDet.Mes_Presentacion = dtpFecha.Value.Month;
                                                        oUsuariosCtaCteDet.Id_Debito_asociado = idPlastico;
                                                    }
                                                    oUsuariosCtaCteDet.Importe_Saldo = decimal.Round(Convert.ToDecimal(drNovBon["importe_con_descuento"]), 2) + decimal.Round(importeProvincial, 2);
                                                    oUsuariosCtaCteDet.Importe_Final = decimal.Round(Convert.ToDecimal(drNovBon["importe_con_descuento"]), 2) + decimal.Round(importeProvincial, 2);
                                                    oUsuariosCtaCte.UsuCtaCteDet.Add(oUsuariosCtaCteDet);

                                                }
                                            }
                                        }
                                    }

                                    foreach (DataRow fila in dtMesesPorcentajesAux.Select(String.Format("id_usuarios_locaciones={0}", idLocacion)))
                                        dtMesesPorcentajes.ImportRow(fila);
                                    dtMesesPorcentajes.AcceptChanges();

                                    if (dtServiciosSubListosParaFacturar.Rows.Count == 0)
                                        dtServiciosSubListosParaFacturar = dtTablaFiltroLocacion.Copy();
                                    else
                                    {
                                        foreach (DataRow subServicios in dtTablaFiltroLocacion.Rows)
                                            dtServiciosSubListosParaFacturar.ImportRow(subServicios);
                                    }
                                    oPreComprobante.UsuCtacta = oUsuariosCtaCte;
                                    ListaComprobantes.Add(oPreComprobante);
                                }

                            }
                        }
                    }
                }
                dtTablaFiltroUsuario.Clear();
                listaLocacionesUsuario.Clear();
                listaServiciosUsuario.Clear();
                contadorParcial = x;
                total = dtUsuBonificacionesConfig.Rows.Count;
                bgwCalcularMontos.ReportProgress(contadorParcial, total);
                x++;
                cantidadErroresGenerales += controlErrores;

            }

        }

        private void btnExportar_Click(object sender, EventArgs e)
        {

        }

        private async void btnPagosExternos_ClickAsync(object sender, EventArgs e)
        { 
            oIm.SetEntidad();
            oIm.SetHash();
            foreach (ComprobanteFacturacion aComprobante in ListaComprobantes)
            {
                List<BotonResponse> respuesta = await oIm.CrearBotonesAsync(aComprobante.UsuCtacta, "maxi1792@gmail.com");
                if (respuesta.Count > 0)
                {
                    CapaNegocios.PagosExternos.PagoExterno oPago = new CapaNegocios.PagosExternos.PagoExterno();
                    oPago.IdUsuario = aComprobante.Id_Usuarios;
                    oPago.IdPago = respuesta[0].Data[0].Record.IdPago;
                    oPago.IdPlataforma = (int)CapaNegocios.PagosExternos.PagoExterno.Plataforma.CAPTARPAGOS;
                    oPago.IdComprobante = 0;
                    oPago.IdUsuarioCtaCte = aComprobante.UsuCtacta.Id;
                    oPago.ImportePago = 0;
                    oPago.ImporteSaldo = Convert.ToDecimal(aComprobante.UsuCtacta.Importe_Saldo);
                    oPago.Link = respuesta[0].Data[0].Record.Link;
                    oPago.NombrePlataforma = "CAPTARPAGOS";
                    oPago.NombreUsuario = aComprobante.Usuario;
                    oPago.Pagado = false;
                    oPago.FechaEmitido = DateTime.Now;
                    oPago.CodigoUsuario = Usuarios.CurrentUsuario.Codigo;
                    oPago.Guardar(oPago);
                }
            }
            MessageBox.Show("Botones generados");
        }

        private void olvDeudas_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (txtBuscar.Text != "")
            {
                //this.objectListView1.ModelFilter = TextMatchFilter.Contains(this.objectListView1, txtBuscar.Text);
                this.olvDeudas.ModelFilter = new ModelFilter(delegate (object x)
                {
                    var myFile = x as ComprobanteFacturacion;
                    return x != null && (myFile.Usuario.Contains(txtBuscar.Text) || myFile.NumeroPlastico.Contains(txtBuscar.Text));
                });
            }
            else
                this.olvDeudas.ModelFilter = null;
        }

        private void GenerarDeudasAsync(object o, DoWorkEventArgs e)
        {
            relojDeudas.Start();
            int controlErrores = 0;
            DataTable dtDatosPresentacionExistente = new DataTable();
            Presentacion_Usuarios_Servicios oPresentacionUsuariosServicios = new Presentacion_Usuarios_Servicios();
            DataTable dtDatosUsuarioServicioSubPresentacion = new DataTable();
            try
            {

                if (debitos == false)
                {
                    oFacturacionMensualHistorial.Id = 0;
                    oFacturacionMensualHistorial.Periodo_Mes = dtpFecha.Value.Month;
                    oFacturacionMensualHistorial.Periodo_Ano = dtpFecha.Value.Year;
                    oFacturacionMensualHistorial.Periodo = dtpFecha.Text;
                    oFacturacionMensualHistorial.Monto_Original_Total = montoOriginalTotalFacturacion;
                    oFacturacionMensualHistorial.Monto_Descuento_Total = montoDescuentoTotalFacturacion;
                    oFacturacionMensualHistorial.Fecha_Desde = fechaDesde;
                    oFacturacionMensualHistorial.Fecha_Hasta = fechaDesde.AddDays(DateTime.DaysInMonth(fechaDesde.Year, fechaDesde.Month) - 1);
                    oFacturacionMensualHistorial.Id = oFacturacionMensualHistorial.Guardar(oFacturacionMensualHistorial);
                    if (oFacturacionMensualHistorial.Id > 0)
                    {
                        if (oFacturacionMensualHistorial.GuardarEstadosServicios() == true)
                        {
                            oUsuariosCtaCteDet.ActualizarIdFacDebitos(oFacturacionMensualHistorial.Id, oFacturacionMensualHistorial.Periodo_Mes, oFacturacionMensualHistorial.Periodo_Ano);
                        }
                        else
                        {
                            oFacturacionMensualHistorial.Eliminar(oFacturacionMensualHistorial.Id);
                            throw new System.ArgumentException("No se pudo guardar el estado actual de los servicios.");
                        }
                    }

                }
                else
                {
                    oFacturacionMensualHistorial.Id = 0;
                    oPresentacion.Id = 0;
                    oPresentacion.Id_Estado = (int)Presentacion_Debitos.ESTADO.ARCHIVO_PENDIENTE;
                    oPresentacion.Id_Forma_De_Pago = 2;
                    oPresentacion.Monto_Pagado = 0;
                    oPresentacion.Monto_Total = totalFacturacion + ListaComprobantes.Sum(item => item.ImporteAnexado);
                    oPresentacion.Periodo = dtpFecha.Text;
                    oPresentacion.Id_Primer_Recibo = 0;
                    oPresentacion.Id_Ultimo_Recibo = 0;
                    oPresentacion.Fecha_Presentacion = dtpFecha.Value;
                    oPresentacion.Fecha_Creacion = DateTime.Now;
                    oPresentacion.Cantidad_Total_Plasticos = ListaComprobantes.Count;
                    oPresentacion.Id = oPresentacion.Guardar(oPresentacion);

                }
            }
            catch (Exception c)
            {
                controlErrores++;
                MessageBox.Show("ERROR: Se produjo error al intentar guardar registro del historial de facturación. " + c.Message);
                DataRow drNuevoError = dtErroresProducidos.NewRow();
                drNuevoError["id_usuario"] = "0";
                drNuevoError["codigo_usuario"] = "0";
                drNuevoError["usuario"] = "0";
                drNuevoError["id_locacion"] = "0";
                drNuevoError["error"] = "ERROR: Se produjo error al intentar guardar registro del historial de facturación.";
                dtErroresProducidos.Rows.Add(drNuevoError);
                cantidadErroresGenerales += controlErrores;
            }
            if (controlErrores == 0)
            {
                if (debitos == false)
                {
                    try
                    {
                        oUsuariosCtaCteDet.ActualizarFacturacionDebitos(oFacturacionMensualHistorial.Id, dtpFecha.Value.Month, dtpFecha.Value.Year);
                    }
                    catch
                    {
                        controlErrores++;
                        MessageBox.Show("ERROR: Se produjo error al intentar listar datos de presentación de débitos para la generación de deudas de los mismos.");
                        DataRow drNuevoError = dtErroresProducidos.NewRow();
                        drNuevoError["id_usuario"] = "0";
                        drNuevoError["codigo_usuario"] = "0";
                        drNuevoError["usuario"] = "0";
                        drNuevoError["id_locacion"] = "0";
                        drNuevoError["error"] = "ERROR: Se produjo error al intentar listar datos de presentación de débitos para la generación de deudas de los mismos.";
                        dtErroresProducidos.Rows.Add(drNuevoError);
                        cantidadErroresGenerales += controlErrores;
                    }
                }
                if (controlErrores == 0 && ListaComprobantes.Count > 0)
                {
                    int x = 0;

                    int idComprobante = 0;
                    int idCtacte = 0;
                    string muestra;

                    drDatosComprobanteVenta = oComprobantesTipo.GetNumeracion(Convert.ToInt32(Comprobantes_Tipo.Tipo.COMPROBANTE_DEUDA), Puntos_Cobros.Id_Punto);
                    nComprobante = Convert.ToInt32(drDatosComprobanteVenta["numComprobante"]);
                    int idPuntoVenta = Convert.ToInt32(drDatosComprobanteVenta["idpuntoventa"]);
                    int puntoVenta = Convert.ToInt32(drDatosComprobanteVenta["numpuntoventa"]);
                    if (nComprobante > 0 && idPuntoVenta > 0)
                    {
                        foreach (ComprobanteFacturacion aComprobante in ListaComprobantes)//los facturables=0 son deudas anexadas
                        {
                            idComprobante = 0;
                            nComprobante++;
                            controlErrores = 0;
                            aComprobante.Numero = nComprobante;
                            aComprobante.Id_Punto_Venta = idPuntoVenta;
                            aComprobante.Punto_Venta = puntoVenta;
                            muestra = "COMPROBANTE DE DEUDA " + puntoVenta.ToString().PadLeft(4, '0') + "-" + nComprobante.ToString().PadLeft(8, '0');
                            aComprobante.Descripcion = muestra;
                            idComprobante = aComprobante.Guardar(aComprobante);
                            foreach (Usuarios_CtaCte_Det anexadas in aComprobante.ListaAmexados)
                                anexadas.ActualizarDebitoPresentacion(aComprobante.UsuCtacta.Id, anexadas.Id_Usuarios_Servicios, anexadas.Id, anexadas.Id_Debito_asociado, oPresentacion.Fecha_Presentacion.Month, oPresentacion.Fecha_Presentacion.Year,oPresentacion.Id);
                            aComprobante.UsuCtacta.Id_Comprobantes = idComprobante;
                            aComprobante.UsuCtacta.Descripcion = muestra;
                            aComprobante.UsuCtacta.Numero = nComprobante.ToString();
                            if (idComprobante > 0)
                            {
                                aComprobante.UsuCtacta.Id_Facturacion = oFacturacionMensualHistorial.Id;
                                idCtacte = aComprobante.UsuCtacta.Guardar(aComprobante.UsuCtacta);
                                if (idCtacte > 0)
                                {
                                    
                                    foreach (Usuarios_CtaCte_Det aDet in aComprobante.UsuCtacta.UsuCtaCteDet)
                                    {

                                        aDet.Id_Usuarios_CtaCte = idCtacte;
                                        aDet.Id_Facturacion = oFacturacionMensualHistorial.Id;
                                        aDet.Id_Presentacion = oPresentacion.Id;

                                        aDet.Id = aDet.Guardar(aDet);
                                        if (aDet.Id > 0)
                                        {
                                            foreach (Usuarios_Ctacte_Det_Extra aExtras in aDet.ListaExtras)
                                            {
                                                aExtras.Id_Usuarios_CtaCte_Det = aDet.Id;
                                                aExtras.Guardar(aExtras);
                                            }
                                            if (aDet.Id_Tipo_Registro_Cta_Cte_Det == (int)Usuarios_CtaCte_Det.TIPO_REGISTRO_CTACTEDET.DETALLE)
                                            {
                                                oFacturacion.ActualizarFechaFacturaSubServicio(aDet.Id_Usuarios_Servicios_sub, aDet.Fecha_Hasta);
                                                oUsuariosServicios.ActualizarFechaFactura(aDet.Id_Usuarios_Servicios, aDet.Fecha_Hasta);
                                            }
                                        }
                                        else
                                        {
                                            string error = aDet.Detalles.Split('|')[1];
                                            error = aDet.Detalles.Split('|')[1] + " " + error.Replace((char)39, ' ');
                                            aComprobante.UsuCtacta.Eliminar(idCtacte, error);
                                            aComprobante.Eliminar(aComprobante.Id, error);
                                            nComprobante--;

                                        }
                                        oFacturacionMensualHistorial.GuardarHistorial(oFacturacionMensualHistorial.Id, aComprobante.Id_Usuarios, aComprobante.CodigoUsuario, aComprobante.Id_Usuarios_Locaciones, aDet.Id_Usuarios_Servicios, aDet.Id_Usuarios_Servicios_sub, aDet.Id_Servicios, aDet.Id_Usuarios_Servicios_sub, aDet.Id_Facturacion, aComprobante.Id, aDet.Id_Usuarios_CtaCte, debitos, idVelocidad, idVelocidadTipo);

                                    }
                                }
                                else
                                {
                                    string error = aComprobante.UsuCtacta.Descripcion;
                                    error = aComprobante.UsuCtacta.Descripcion.Split('|')[1];
                                    error = error.Replace((char)39, ' ');
                                    nComprobante--;
                                    aComprobante.Eliminar(aComprobante.Id, error);
                                }
                            }
                            else
                                nComprobante--;

                            contadorParcial = x;
                            total = ListaComprobantes.Count;
                            bgwGenerarDeudas.ReportProgress(contadorParcial, total);
                            x++;

                            //cantidadErroresGenerales += controlErrores;
                            cantidadErroresGenerales = ListaComprobantes.Count(item => item.Id <= 0);
                        }
                    }
                    if (nComprobante > 0)
                        oComprobantesTipo.SetNumeracion(Convert.ToInt32(drDatosComprobanteVenta["idPuntoVenta"]), Convert.ToInt32(Comprobantes_Tipo.Tipo.COMPROBANTE_DEUDA),0, nComprobante);
                }
                if (controlErrores == 0)
                {
                    try
                    {
                        //if (dtDatosPresentacionExistente.Rows.Count > 0)
                        //    oPresentacionDebitos.ActualizarMontosPrefacturacionPresentacion(Convert.ToInt32(dtDatosPresentacionExistente.Rows[0]["id"]));
                    }
                    catch
                    {
                        MessageBox.Show("ERROR: Se produjo error al intentar correr proceso de actualización relacionado con débitos.");
                        DataRow drNuevoError = dtErroresProducidos.NewRow();
                        drNuevoError["id_usuario"] = "0";
                        drNuevoError["codigo_usuario"] = "0";
                        drNuevoError["usuario"] = "0";
                        drNuevoError["id_locacion"] = "0";
                        drNuevoError["error"] = "ERROR: Se produjo error al intentar correr proceso de actualización relacionado con débitos.";
                        dtErroresProducidos.Rows.Add(drNuevoError);
                        cantidadErroresGenerales += controlErrores;
                    }
                }
            }

        }
        private void AjustarListView()
        {
            this.olvDeudas.RowHeight = 30;
            this.olvDeudas.SetObjects(ListaComprobantes, false);
            //this.olvDeudas.RefreshObjects(ListaComprobantes);
            //this.olvDeudas.BuildList();
            //this.olvDeudas.RedrawItems(0, olvDeudas.Items.Count -1, true);
            //si es debito quita la columna de plastico
            if(!debitos)
                this.olvDeudas.Columns.RemoveAt(5);

            this.olvDeudas.RefreshObjects(ListaComprobantes);
            this.olvDeudas.RefreshOverlays();

        }
        private void AsignarDatos()
        {
            try
            {
                totalDebitado = 0;
                totalAnexado = 0;
                lblReloj.Location = new Point(pgCircular.Location.X - lblReloj.Width - 10, lblReloj.Location.Y);
                AjustarListView();
                lblPeriodoSeleccionado.Text = String.Format("Periodo seleccionado: Mes {0}  Año {1}", dtpFecha.Value.Month, dtpFecha.Value.Year);
                lblTotal.Text = String.Format("Total de Registros: {0}", ListaComprobantes.Count);
                btnBuscar.Enabled = true;
                btnFacturacion.Enabled = true;


                totalFacturacion = ListaComprobantes.Sum(c => c.Importe);

                lblMontoTotal.Text = totalFacturacion.ToString("c2");
                lblTotalAnexado.Text = ListaComprobantes.Sum(item => item.ImporteAnexado).ToString();
                lblTotalAnexado.Location = new Point(lblmonto.Location.X - lblTotalAnexado.Width - 10, lblmonto.Location.Y);             
                lblMontoTotalTotal.Text = (totalFacturacion + ListaComprobantes.Sum(item => item.ImporteAnexado)).ToString("c2");             
                btnExportarPdf.Enabled = true;
                if (debitos)
                {
                    var grupoPlasticos = ListaComprobantes.GroupBy(lolo => lolo.NumeroPlastico).Select(grupo => grupo.ToList()).ToList();
                    lblCantidadPalsticos.Text = "Cantidad de plasticos: " + grupoPlasticos.Count;
                    btnGenerarArchivo.Enabled = true;
                }

            }
            catch (Exception c)
            {
                MessageBox.Show("ERROR: Se produjo un error en la visualización de información." + c.Message);
                DataRow drNuevoError = dtErroresProducidos.NewRow();
                drNuevoError["id_usuario"] = "0";
                drNuevoError["codigo_usuario"] = "0";
                drNuevoError["usuario"] = "0";
                drNuevoError["id_locacion"] = "0";
                drNuevoError["error"] = "ERROR: Se produjo un error en la visualización de información.";
                dtErroresProducidos.Rows.Add(drNuevoError);
                cantidadErroresGenerales++;
                lblPeriodoSeleccionado.Text = String.Format("Periodo seleccionado: Mes {0}  Año {1}", dtpFecha.Value.Month, dtpFecha.Value.Year);
                lblTotal.Text = String.Format("Total de Registros: {0}", ListaComprobantes.Count);
                btnBuscar.Enabled = true;
                btnFacturacion.Enabled = true;
            }
            if (cantidadErroresGenerales > 0)
            {
                MessageBox.Show("Se produjeron errores en el proceso.");
                btnListadoErrores.Text = String.Format("Listado de errores ({0})", cantidadErroresGenerales);
            }

        }
        private void FinalizarGeneracionDeudas()
        {
            if (cantidadErroresGenerales > 0)
            {
                MessageBox.Show("Se produjeron errores en el proceso.");
                btnListadoErrores.Text = String.Format("Listado de errores ({0})", cantidadErroresGenerales);
            }
            if (debitos)
            {
                DataTable dtPlasticos = generarEstructuraDebitosTxt();
                DataRow drPlastico;

                string plastico = string.Empty;
                decimal total = 0;
                var compAgrupados = ListaComprobantes.GroupBy(compro => compro.NumeroPlastico);
                var compAgrupados2 = ListaComprobantes.GroupBy(d => d.NumeroPlastico)
                                    .Select(
                                        g => new
                                        {
                                            Key = g.Key,
                                            Value = g.Sum(s => s.ImporteTotal),
                                            plastico = g.First().NumeroPlastico,
                                            codigo = g.First().CodigoUsuario,
                                            idUsu = g.First().Id_Usuarios
                                        });
                totalDebitado = 0;
                foreach (var grupo in compAgrupados2)
                {

                    DataRow dr = dtPlasticos.NewRow();
                    dr["id"] = 0;
                    dr["id_presentacion"] = oPresentacion.Id;
                    dr["numero"] = grupo.plastico.Trim();
                    dr["total"] = grupo.Value;
                    dr["id_usuario"] = grupo.idUsu;
                    dr["codigo_usuario"] = grupo.codigo;
                    totalDebitado = totalDebitado + grupo.Value;
                    dtPlasticos.Rows.Add(dr);
                }
                DataView dv = dtPlasticos.DefaultView;
                dv.Sort = "codigo_usuario asc";
                dtPlasticos = dv.ToTable();
                Formas_de_pago oFormaPago = new Formas_de_pago();
                DataTable dtFormasPago = oFormaPago.Listar();
                DataView dvDebito = dtFormasPago.DefaultView;
                dvDebito.RowFilter = "Codigo_Empresa_Tarjeta<>''";
                dtFormasPago = dvDebito.ToTable();
                if(dtFormasPago.Rows.Count>0)
                {
                    int idFormaDepago = Convert.ToInt32(dtFormasPago.Rows[0]["Id"]);
                    oPresentacion.Id_Forma_De_Pago = idFormaDepago;
                    oPresentacion.Monto_Total = totalDebitado;
                    if (oPresentacion.GenerarArchivoPresentacion(dtPlasticos, oPresentacion.Id_Forma_De_Pago, oPresentacion))
                        MessageBox.Show("Presentación generada correctamente.");
                }
                else
                    MessageBox.Show("No se encontro una forma de paga configurada para generar debitos automaticos.","Mensaje del Sistema",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                //dtServiciosAFacturar.Clear();
            }
            btnBuscar.Enabled = true;
            btnFacturacion.Enabled = true;

            if (!Debugger.IsAttached)
            {
                new frmAdvertencia("Advertencia", "A continuacion se procedera a actualizar los saldos, en caso de cancelar el proceso se puede reanudar desde el menu -> Utilidades -> Actualizar saldos").ShowDialog();
                frmPopUp popUp = new frmPopUp();
                popUp.Formulario = new frmActualizarSaldosYPunitorios(frmActualizarSaldosYPunitorios.TIPO.SALDO_LOCACION, hacerAutomatico: true);
                popUp.Maximizar = false;
                popUp.ShowDialog();
            }
        }
        private DataTable generarEstructuraDebitosTxt()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("id", typeof(int));
            dt.Columns.Add("id_presentacion", typeof(int));
            dt.Columns.Add("id_plastico", typeof(int));
            dt.Columns.Add("id_estado", typeof(int));
            dt.Columns.Add("titular", typeof(string));
            dt.Columns.Add("numero", typeof(string));
            dt.Columns.Add("monto_deauda_atras", typeof(decimal));
            dt.Columns.Add("monto_estimado", typeof(decimal));
            dt.Columns.Add("monto_prefacturacion", typeof(decimal));
            dt.Columns.Add("monto_deauda_adelantada", typeof(decimal));
            dt.Columns.Add("total", typeof(decimal));
            dt.Columns.Add("id_usuario", typeof(int));
            dt.Columns.Add("codigo_usuario", typeof(int));
            return dt;
        }
        private void Terminado(object o, RunWorkerCompletedEventArgs e)
        {
            pbProgreso.Value = pbProgreso.Maximum;
            this.Cursor = Cursors.Arrow;
            pbProgreso.Visible = false;
            lblProgreso.Visible = false;
            lblReloj2.Text = "Tiempo generar deudas: " + relojDeudas.Elapsed.ToString();
            WriteToXmlFile(@"c:\GIES\pre_fac.xml", ListaComprobantes);

            if (GeneraDeudas)
                FinalizarGeneracionDeudas();
            else
                AsignarDatos();
        }
        private void BuscarDatos()
        {
            GeneraDeudas = false;
            lblPeriodoSeleccionado.Text = String.Format("Periodo seleccionado:");
            btnBuscar.Enabled = false;
            btnFacturacion.Enabled = false;
            dtpFecha.Value = new DateTime(dtpFecha.Value.Date.Year, dtpFecha.Value.Date.Month, 1);
            fechaDesde = dtpFecha.Value;
            oServiciosTarifas.Fecha_Actual = fechaDesde;
            idTarifaActual = oServiciosTarifas.getTarifa();
            CargarDatos();
        }
        private void TraerConfiguracionBonificacionesUsuarios(DataTable dtSubServicios, DataTable dtDatosUsuarioBonificacion)
        {
            List<int> listaUsuariosEncontrados = new List<int>();

            foreach (DataRow SubServicio in dtSubServicios.Rows)
            {
                if (listaUsuariosEncontrados.Contains(Convert.ToInt32(SubServicio["id_usuarios"])) == false)
                {
                    listaUsuariosEncontrados.Add(Convert.ToInt32(SubServicio["id_usuarios"]));
                    dtDatosUsuarioBonificacion.Rows.Add(SubServicio["id_usuarios"], SubServicio["calculo_bonificacion"], SubServicio["codigo_usuario"], SubServicio["usuario"]);
                }
            }
            listaUsuariosEncontrados.Clear();
        }
        private void ActualizarFechaFacturacion(DataTable dtUsuariosServicios)
        {
            foreach (DataRow fila in dtUsuariosServicios.Rows)
            {
                oUsuariosServicios.Fecha_Factura = Convert.ToDateTime(fila["fecha_hasta"]);
                oUsuariosServicios.Fecha_Factura_Desde = Convert.ToDateTime(fila["fecha_hasta"]);
                oUsuariosServicios.Actualizar_fecha_facturado(Convert.ToInt32(fila["id_usuario_servicio"]));
            }
        }
        public static List<ComprobanteFacturacion> ReadFromXmlFile<T>(string filePath) where T : new()
        {
            TextReader reader = null;
            try
            {
                var serializer = new XmlSerializer(typeof(T));
                reader = new StreamReader(filePath);
                return (List<ComprobanteFacturacion>)serializer.Deserialize(reader);
            }
            finally
            {
                if (reader != null)
                    reader.Close();
            }
        }
        public static void WriteToXmlFile<ComprobanteFacturacion>(string filePath, ComprobanteFacturacion objectToWrite, bool append = false)
        {
            TextWriter writer = null;
            try
            {
                var serializer = new XmlSerializer(typeof(ComprobanteFacturacion));
                writer = new StreamWriter(filePath, append);
                serializer.Serialize(writer, objectToWrite);
            }
            finally
            {
                if (writer != null)
                    writer.Close();
            }
        }

        static DataTable ListaADatatable<ComprobanteFacturacion>(List<ComprobanteFacturacion> models, bool detallado)
        {
            // creating a data table instance and typed it as our incoming model   
            // as I make it generic, if you want, you can make it the model typed you want.  
            DataTable dataTable = new DataTable(typeof(ComprobanteFacturacion).Name);

            //Get all the properties of that model  
            PropertyInfo[] Props = typeof(ComprobanteFacturacion).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            PropertyInfo[] PropsDet = typeof(Usuarios_CtaCte_Det).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            // Loop through all the properties              
            // Adding Column name to our datatable  
            foreach (PropertyInfo prop in Props)
            {
                //Setting column names as Property names    
                dataTable.Columns.Add(prop.Name);
            }
            // Adding Row and its value to our dataTable  
            int indice = 0;
            foreach (ComprobanteFacturacion item in models)
            {
                indice++;
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    //inserting property values to datatable rows    
                    values[i] = Props[i].GetValue(item, null);
                    if (Props[i].GetType() == typeof(Usuarios_CtaCte))
                    {
                        Usuarios_CtaCte oCtacte = new Usuarios_CtaCte();
                        foreach (Usuarios_CtaCte_Det detalle in oCtacte.UsuCtaCteDet)
                        {
                            DataRow dr = dataTable.NewRow();
                            dr["importe"] = detalle.Importe_Original;
                            dr["importeAnexado"] = 0;
                            dr["importeTotal"] = detalle.Importe_Final;
                            dr["importeprovincial"] = detalle.Importe_Provincial;
                            dr["importebonificacion"] = detalle.Importe_Bonificacion;
                            dr["usuario"] = detalle.Detalles;
                            dataTable.Rows.Add(dr);

                        }
                    }
                    else
                    {
                        dataTable.Rows.Add(values);

                    }
                }
                // Finally add value to datatable    



            }
            return dataTable;
        }

        public static void GenerateExcel(DataTable dataTable, string path)
        {
            DataSet dataSet = new DataSet();
            dataSet.Tables.Add(dataTable);

            // create a excel app along side with workbook and worksheet and give a name to it
            Excel.Application excelApp = new Excel.Application();
            Excel.Workbook excelWorkBook = excelApp.Workbooks.Add();
            Excel._Worksheet xlWorksheet = excelWorkBook.Sheets[1];
            Excel.Range xlRange = xlWorksheet.UsedRange;
            foreach (DataTable table in dataSet.Tables)
            {
                //Add a new worksheet to workbook with the Datatable name
                Excel.Worksheet excelWorkSheet = excelWorkBook.Sheets.Add();
                excelWorkSheet.Name = table.TableName;
                // add all the columns
                for (int i = 1; i < table.Columns.Count + 1; i++)
                {
                    excelWorkSheet.Cells[1, i] = table.Columns[i - 1].ColumnName;
                }
                // add all the rows
                for (int j = 0; j < table.Rows.Count; j++)
                {
                    for (int k = 0; k < table.Columns.Count; k++)
                    {
                        excelWorkSheet.Cells[j + 2, k + 1] = table.Rows[j].ItemArray[k].ToString();
                    }
                }
            }
            // excelWorkBook.Save(); -> this will save to its default location
            excelWorkBook.SaveAs(path); // -> this will do the custom
            excelWorkBook.Close();
            excelApp.Quit();
        }
        #endregion

        #region CONTROLES
        public frmFacturacionMensualNuevo(bool debitos)
        {
            InitializeComponent();
            dtpFecha.Value = DateTime.Now.AddMonths(1);
            this.debitos = debitos;
        }
        private void FrmFacturacionMensual_Load(object sender, EventArgs e)
        {
            dtUsuBonificacionesConfig.Columns.Add("id_usuarios", typeof(string));
            dtUsuBonificacionesConfig.Columns.Add("calculo_bonificacion", typeof(string));
            dtUsuBonificacionesConfig.Columns.Add("codigo_usuario", typeof(string));
            dtUsuBonificacionesConfig.Columns.Add("usuario", typeof(string));

            dtErroresProducidos.Columns.Add("id_usuario", typeof(string));
            dtErroresProducidos.Columns.Add("codigo_usuario", typeof(string));
            dtErroresProducidos.Columns.Add("usuario", typeof(string));
            dtErroresProducidos.Columns.Add("id_locacion", typeof(string));
            dtErroresProducidos.Columns.Add("error", typeof(string));

            lblCantidadPalsticos.Visible = debitos;
            lblAnexado.Visible = debitos;
            lblTotalAnexado.Visible = debitos;
            if (debitos)
                lblTituloHeader.Text = "Facturación mensual - Débitos Automáticos";
        }
        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            reloj.Start();
            dtExtras.Clear();
            dtServiciosAFacturar.Clear();
            dtErroresProducidos.Clear();
            cantidadErroresGenerales = 0;
            if (debitos)
            {
                dtUltimaPresentacion = oPresentacion.ListarUltimaPresentacion();
                if (dtUltimaPresentacion.Rows.Count > 0)
                    ultimaFechaFacturacion = Convert.ToDateTime(dtUltimaPresentacion.Rows[0]["Fecha_Presentacion"]);
            }
            else
                ultimaFechaFacturacion = oFacturacionMensualHistorial.RetornarUltimaFechaFacturacionMensual();
            if (ultimaFechaFacturacion.Year == 0001 || (dtpFecha.Value.Year == ultimaFechaFacturacion.Year && dtpFecha.Value.Month == (ultimaFechaFacturacion.Month + 1)) || (dtpFecha.Value.Year == (ultimaFechaFacturacion.Year + 1) && ultimaFechaFacturacion.Month == 12 && dtpFecha.Value.Month == 1))
                BuscarDatos();
            else
                MessageBox.Show(String.Format("Sólo se puede facturar el mes siguiente a la última fecha de facturación, siendo ésta: {0}", ultimaFechaFacturacion.ToString("dd/MM/yyyy")));
        }
        private void btnFacturacion_Click(object sender, EventArgs e)
        {

            ultimaFechaFacturacion = oFacturacionMensualHistorial.RetornarUltimaFechaFacturacionMensual();
            if (ultimaFechaFacturacion.Year == 0001 || (dtpFecha.Value.Year == ultimaFechaFacturacion.Year && dtpFecha.Value.Month == (ultimaFechaFacturacion.Month + 1)) || (dtpFecha.Value.Year == (ultimaFechaFacturacion.Year + 1) && ultimaFechaFacturacion.Month == 12 && dtpFecha.Value.Month == 1))
            {
                if (ListaComprobantes.Count > 0)
                {
                    if (String.IsNullOrEmpty(txtBuscar.Text))
                    {
                        DialogResult dialogResult = MessageBox.Show("A continuación se procederá a generar las deudas de las locaciones presentes en la grilla. ¿Desea continuar?", "", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            GeneraDeudas = true;
                            btnBuscar.Enabled = false;
                            btnFacturacion.Enabled = false;
                            CargarDatos();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Verifique que el filtro de búsqueda se encuentre vacío.");
                        txtBuscar.Focus();
                    }
                }
                else
                    MessageBox.Show("No hay datos para generar deudas.");
            }
            else
                MessageBox.Show(String.Format("Sólo se puede facturar el mes siguiente a la última fecha de facturación, siendo ésta: {0}", ultimaFechaFacturacion.ToString("dd/MM/yyyy")));
        }
        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void frmFacturacionMensual_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                if (pnlErrores.Visible == true)
                    pnlErrores.Visible = false;
                else
                    this.Close();
            }
            if (e.KeyCode == Keys.F1)
            {
                spnCantidad.Visible = true;
                usuarioSolo = false;
                spnCantidad.BackColor = Color.GhostWhite;
                spnCantidad.ForeColor = Color.Black;
                btnPagosExternos.Visible = true;
            }
            if (e.KeyCode == Keys.F2)
            {
                spnCantidad.Visible = true;
                spnCantidad.BackColor = Color.Cyan;
                spnCantidad.ForeColor = Color.Red;
                usuarioSolo = true;
                btnPagosExternos.Visible = true;
            }
            if (e.KeyCode == Keys.F3)
            {
                btnCargar.Visible = !btnCargar.Visible;
                btnPreGuardar.Visible = !btnPreGuardar.Visible;
            }
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            pnlErrores.Visible = false;

        }
        private void boton1_Click(object sender, EventArgs e)
        {
            if (dgvErrores.Rows.Count > 0)
                oTools.ExportToExcel(dgvErrores, fechaDesde.ToString("yyyy-MM-dd"));
            else
                MessageBox.Show("No hay datos en la grilla.");
        }
        private void btnListadoErrores_Click(object sender, EventArgs e)
        {
            if (dtErroresProducidos.Rows.Count > 0)
            {
                dgvErrores.DataSource = dtErroresProducidos;
                dgvErrores.Columns["id_usuario"].Visible = false;
                dgvErrores.Columns["codigo_usuario"].HeaderText = "Código usuario";
                dgvErrores.Columns["usuario"].HeaderText = "Usuario";
                dgvErrores.Columns["id_locacion"].HeaderText = "Código locación";
                dgvErrores.Columns["error"].HeaderText = "Error";
                pnlErrores.Location = new Point(
                        this.ClientSize.Width / 2 - pnlErrores.Size.Width / 2,
                        this.ClientSize.Height / 2 - pnlErrores.Size.Height / 2);
                pnlErrores.Anchor = AnchorStyles.None;
                pnlErrores.Visible = true;
            }
            else
                MessageBox.Show("No se han producido errores en el proceso.");
        }
        private void bgwCalcularMontos_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            pbProgreso.Value = pbProgreso.Maximum;
            this.Cursor = Cursors.Arrow;
            imgReturn.Enabled = true;
            reloj.Stop();
            lblReloj.Text = " Tiempo para calcular montos " + reloj.Elapsed.ToString();
        }
        private void bgwCalcularMontos_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            double porcentajeHecho = 0;
            pbProgreso.Value = e.ProgressPercentage;
            porcentajeHecho = (contadorParcial * 100) / total;
            lblProgreso.Text = String.Format("Calculando montos {0}%", porcentajeHecho);
        }
        private void bgwGenerarDeudas_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            double porcentajeHecho = 0;
            pbProgreso.Value = e.ProgressPercentage;
            porcentajeHecho = (contadorParcial * 100) / total;
            lblProgreso.Text = String.Format("Generando deudas {0}%", porcentajeHecho);
        }
        private void boton2_Click_2(object sender, EventArgs e)
        {
            DataSet datasetAbrir = new DataSet();
            OpenFileDialog oPen = new OpenFileDialog();
            oPen.InitialDirectory = @"c:\\GIES\\";
            oPen.Filter = "xml files (*.xml)|*.xml";
            if (oPen.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    datasetAbrir.ReadXml(oPen.FileName);
                    dtServiciosAFacturar.Clear();
                    dtServiciosAFacturar = datasetAbrir.Tables[0];
                    AsignarDatos();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            SaveFileDialog oSave = new SaveFileDialog();
            DataSet datasetGuardar = new DataSet();
            datasetGuardar.Tables.Add(dtServiciosAFacturar.Copy());
            oSave.Filter = "xml files (*.xml)|*.xml";

            if (oSave.ShowDialog() == DialogResult.OK)
                datasetGuardar.WriteXml(oSave.FileName);
        }
        private void boton2_Click_1(object sender, EventArgs e)
        {

            FinalizarGeneracionDeudas();
        }
        private void bgwGenerarDeudas_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            pbProgreso.Value = pbProgreso.Maximum;
            this.Cursor = Cursors.Arrow;
            imgReturn.Enabled = true;
        }
        private void btnExportarPdf_Click(object sender, EventArgs e)
        {
            Usuarios Usu = new Usuarios();
            olvDeudas.Enabled = false;
            int cantidad = 0;
            string[] contenidoFianl = new string[100000];
            string[] contenidoFinalResumen = new string[100000];
            contenidoFianl[0] = "Presentacion;Codigo;Tipo;Usuario;Tipo Facturacion;Locacion;Importe Original;Importe Bonificacion;Importe Provincial;Importe Final;Fecha Desde;Fecha Hasta";
            contenidoFinalResumen[0] = "Presentacion;Codigo;Tipo;Usuario;Tipo Facturacion;Locacion;Importe Original;Importe Bonificacion;Importe Provincial;Importe Final;Importe Anexado";
            cantidad++;
            foreach (ComprobanteFacturacion item in ListaComprobantes)
            {           
                 Usu = oUsuario.traerUsuario(0,item.CodigoUsuario);
                contenidoFinalResumen[cantidad] = Usu.Presentacion.ToString() + ";" + item.CodigoUsuario.ToString() + ";" + item.Responsable + ";" + item.Usuario.Replace(',', ' ') + ";" + item.Categoria + ";" + item.Locacion.Replace(',', ' ') + ";" + item.ImporteOriginal + ";" + item.ImporteBonificacion + ";" + item.ImporteProvincial + ";" + item.ImporteTotal + ";" + item.ImporteAnexado;
                foreach (Usuarios_CtaCte_Det detalle in item.UsuCtacta.UsuCtaCteDet)
                {
                    contenidoFianl[cantidad] = Usu.Presentacion.ToString() + ";" +  item.CodigoUsuario.ToString() + ";" + item.Responsable + ";" + item.Usuario.Replace(',', ' ') + ";" + item.Categoria + ";" + detalle.Detalles + ";" + detalle.Importe_Original + ";" + detalle.Importe_Bonificacion + ";" + detalle.Importe_Provincial + ";" + detalle.Importe_Final + ";" + detalle.Fecha_Desde.Date.ToShortDateString() + ";" + detalle.Fecha_Hasta.Date.ToShortDateString();
                    cantidad++;
                }
                foreach (Usuarios_CtaCte_Det detalle in item.ListaAmexados)
                {
                    contenidoFianl[cantidad] = Usu.Presentacion.ToString() + ";" + item.CodigoUsuario.ToString() + ";" + item.Responsable + ";" + item.Usuario.Replace(',', ' ') + ";"+ item.Categoria + ";" + "(***ANEXADO)" + detalle.Detalles + ";" + detalle.Importe_Original + ";" + detalle.Importe_Bonificacion + ";" + detalle.Importe_Provincial + ";" + detalle.Importe_Saldo + ";" + detalle.Fecha_Desde.Date.ToShortDateString() + ";" + detalle.Fecha_Hasta.Date.ToShortDateString();
                    cantidad++;
                }
            }
            SaveFileDialog oSave = new SaveFileDialog();
            oSave.Filter = ".csv files (*.csv)|*.csv";
            oSave.FileName = "detallado.csv";
            if (oSave.ShowDialog() == DialogResult.OK)
            {
                string ruta = oSave.FileName;
                if (oTools.ExportarCvs(ruta, 1, contenidoFianl))
                    MessageBox.Show("Exportado correctamente", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Hubo un error al intentar exportar el archivo", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);


            }
            SaveFileDialog oSave2 = new SaveFileDialog();
            oSave2.Filter = ".csv files (*.csv)|*.csv";
            oSave2.FileName = "simple.csv";

            if (oSave2.ShowDialog() == DialogResult.OK)
            {
                string[] contenidoSinNull = contenidoFinalResumen.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                string ruta = oSave2.FileName;

                if (oTools.ExportarCvs(ruta, 1, contenidoSinNull))
                    MessageBox.Show("Exportado correctamente", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Hubo un error al intentar exportar el archivo", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            olvDeudas.Enabled = true;

        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            ListaComprobantes = ReadFromXmlFile<List<ComprobanteFacturacion>>(@"c:\GIES\pre_fac.xml");
            AsignarDatos();
        }
        private void btnPreGuardar_Click(object sender, EventArgs e)
        {
            WriteToXmlFile(@"c:\GIES\pre_fac.xml", ListaComprobantes);

        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            pnlDetalles.Visible = false;
        }
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            pnlDetalles.Visible = false;

        }
        private void verDetallesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ComprobanteFacturacion oSeleccionado = (ComprobanteFacturacion)olvDeudas.SelectedObject;
            DataTable dtDetalles = new DataTable();

            DataColumn dcItem = new DataColumn();
            dcItem.ColumnName = "item";
            dcItem.DataType = typeof(string);
            dcItem.DefaultValue = "";
            dtDetalles.Columns.Add(dcItem);

            DataColumn dcImporte = new DataColumn();
            dcImporte.ColumnName = "importe";
            dcImporte.DataType = typeof(decimal);
            dcImporte.DefaultValue = 0;
            dtDetalles.Columns.Add(dcImporte);

            DataColumn dcImporteBonif = new DataColumn();
            dcImporteBonif.ColumnName = "importe_bonificado";
            dcImporteBonif.DataType = typeof(decimal);
            dcImporteBonif.DefaultValue = 0;
            dtDetalles.Columns.Add(dcImporteBonif);

            DataColumn dcImportePro = new DataColumn();
            dcImportePro.ColumnName = "importe_provincial";
            dcImportePro.DataType = typeof(decimal);
            dcImportePro.DefaultValue = 0;
            dtDetalles.Columns.Add(dcImportePro);

            DataColumn dcImporteAnex = new DataColumn();
            dcImporteAnex.ColumnName = "importe_anexado";
            dcImporteAnex.DataType = typeof(decimal);
            dcImporteAnex.DefaultValue = 0;
            dtDetalles.Columns.Add(dcImporteAnex);

            DataColumn dcImporteTotal = new DataColumn();
            dcImporteTotal.ColumnName = "importe_total";
            dcImporteTotal.DataType = typeof(decimal);
            dcImporteTotal.DefaultValue = 0;
            dtDetalles.Columns.Add(dcImporteTotal);

            foreach (Usuarios_CtaCte_Det item in oSeleccionado.UsuCtacta.UsuCtaCteDet)
                dtDetalles.Rows.Add(item.Detalles, item.Importe_Original, item.Importe_Bonificacion, item.Importe_Provincial, 0, item.Importe_Final);

            foreach (Usuarios_CtaCte_Det item in oSeleccionado.ListaAmexados)
                dtDetalles.Rows.Add("ANEXADO) " + item.Detalles, 0, 0, 0, item.Importe_Saldo, 0);

            dgvDetalles.DataSource = dtDetalles;
            dgvDetalles.Columns["importe"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvDetalles.Columns["importe"].DefaultCellStyle.Format = "C2";
            dgvDetalles.Columns["importe_bonificado"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvDetalles.Columns["importe_bonificado"].DefaultCellStyle.Format = "C2";
            dgvDetalles.Columns["importe_provincial"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvDetalles.Columns["importe_provincial"].DefaultCellStyle.Format = "C2";
            dgvDetalles.Columns["importe_anexado"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvDetalles.Columns["importe_anexado"].DefaultCellStyle.Format = "C2";
            dgvDetalles.Columns["importe_total"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvDetalles.Columns["importe_total"].DefaultCellStyle.Format = "C2";
            lblUsuarioDetalles.Text = oSeleccionado.CodigoUsuario + "- " + oSeleccionado.Usuario + " " + oSeleccionado.NumeroPlastico;
            pnlDetalles.Width = olvDeudas.Width;
            pnlDetalles.Height = olvDeudas.Height;
            pnlDetalles.Location = new Point(olvDeudas.Location.X, olvDeudas.Location.Y);
            pnlDetalles.Visible = true;
        }
        private void verCuentaCorrienteDelUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ComprobanteFacturacion oSeleccionado = (ComprobanteFacturacion)olvDeudas.SelectedObject;

            int idUsuario = oSeleccionado.Id_Usuarios;
            int idLocacion = oSeleccionado.Id_Usuarios_Locaciones;
            Usuarios oUsu = new Usuarios();
            oUsu.LlenarObjeto(idUsuario);
            frmUsuariosCtaCteConsultaNuevo oCtacte = new frmUsuariosCtaCteConsultaNuevo(idUsuario, idLocacion);
            oCtacte.SoloVer = true;
            oCtacte.FormBorderStyle = FormBorderStyle.FixedDialog;
            oCtacte.Size = new Size(Screen.PrimaryScreen.WorkingArea.Width - 100, Screen.PrimaryScreen.WorkingArea.Height - 100);
            oCtacte.ShowDialog();
        }
        private void olvDeudas_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                try
                {
                    var hti = olvDeudas.HitTest(e.X, e.Y);
                    // Add this

                    foreach (ToolStripMenuItem item in cmsOpciones.Items)
                        item.Enabled = true;
                    cmsOpciones.Show(Cursor.Position);

                }
                catch { }
            }
        }
        #endregion
        public partial class ComprobanteFacturacion : Comprobantes
        {
            public string TextoMuestra { set; get; }
            public decimal ImporteAnexado { set; get; }
            public decimal ImporteProvincial { set; get; }

            public decimal ImporteOriginal { set; get; }
            public decimal ImporteBonificacion { get; set; }
            public decimal ImporteTotal { get; set; }
            public string NumeroPlastico { get; set; }
            public string Usuario { get; set; }
            public string Locacion { get; set; }
            public int CodigoUsuario { set; get; }

            public List<Usuarios_CtaCte_Det> ListaAmexados = new List<Usuarios_CtaCte_Det>();

            public string Responsable { get; set; }

            public string Categoria { get; set; }

        }
    }
}