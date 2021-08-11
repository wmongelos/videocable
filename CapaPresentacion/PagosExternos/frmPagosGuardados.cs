using BrightIdeasSoftware;
using CapaNegocios;
using CapaNegocios.PagosExternos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace CapaPresentacion.PagosExternos
{
    public partial class frmPagosGuardados : Form
    {
        private CapaNegocios.PagosExternos.PagoExterno oPagos;
        private Thread hilo;
        private delegate void myDel();
        private DateTime fechaDesde, fechaHasta;
        private DataTable dtPlataformas = new DataTable();
        private bool cargado;
        private List<PagoExterno> oListaPagos;
        private string punto;
        private int estadoPago,idPunto,IdPlataformaSeleccionada,cantiadRecibos, cantidadCreditoACuenta;
        private decimal sumaRecibos, sumaCreditos;
        private Configuracion oConfi = new Configuracion();
        private Usuarios_CtaCte oCtacte = new Usuarios_CtaCte();
        private DataTable dtLocaciones = new DataTable();
        private Usuarios_Locaciones oUsuloc = new Usuarios_Locaciones();
        private Puntos_Venta oPuntoVemta = new Puntos_Venta();
        private Puntos_Cobros oCobro = new Puntos_Cobros();
        private DataTable dtDatosPuntoCobro;
        private DataTable dtPuntosVenta;
        private Usuarios_CtaCte oCtacteCredito = new Usuarios_CtaCte();
        private Usuarios_CtaCte_Det oDet = new Usuarios_CtaCte_Det();
        private Usuarios_Locaciones oUsuLoc = new Usuarios_Locaciones();
        private DataTable dtDatosCtaCte = new DataTable();
        private DataTable dtModelo = new DataTable();
        private string muestra;
        private string NumeroString;
        private int NroRecibo, PtoRecibo, codigoRetorno;
        private bool selRecibos, selRecibosX, selCredito, selTodo;
        List<CapaNegocios.PagosExternos.PagoExterno> oListaSeleccionados = new List<PagoExterno>();

        public frmPagosGuardados()
        {
            InitializeComponent();
       
        }

        #region METODOS
        private void ComenzarCarga()
        {
            SetearBotones(false);
            InicializarCMenu();

            oListaPagos = new List<PagoExterno>();
            this.tlvLista.SetObjects(oListaPagos);
            fechaDesde = dtpDesde.Value;
            fechaHasta = dtpHasta.Value;
            IdPlataformaSeleccionada = Convert.ToInt32(cboPlataforma.SelectedValue);
            int x, y;
            x = (tlvLista.Width / 2) - (pnlCargando.Width / 2);
            y = (tlvLista.Height / 2) - (pnlCargando.Height / 2);
            //asignamos la nueva ubicación
            pnlCargando.Location = new Point(x, y);
            pnlCargando.Visible = true;
            pgCircular.Start();
            hilo = new Thread(new ThreadStart(CargarDatos));
            hilo.Start();
        }

        private void CargarDatos()
        {
            

            oPagos = new PagoExterno();
            oListaPagos = new List<PagoExterno>();
            oListaPagos = oPagos.Listar(fechaDesde, fechaHasta, IdPlataformaSeleccionada);

            if (oListaPagos.Count > 0)
            {

                cantiadRecibos = oListaPagos.Count(n => n.Pagado == false && n.ImportePago > 0);
                var listaAux = oListaPagos.Where(n => n.Pagado == false && n.ImportePago > 0).ToList();
                sumaRecibos = listaAux.Sum(x => x.ImportePago);


                cantidadCreditoACuenta = oListaPagos.Count(n => n.Pagado == true && n.ImportePago > 0);
                listaAux = oListaPagos.Where(n => n.Pagado == true && n.ImportePago > 0).ToList();
                sumaCreditos = listaAux.Sum(x => x.ImportePago);
            }

            myDel MD = new myDel(AsignarDatos);
            this.Invoke(MD, new object[] { });
            pgCircular.Stop();
        }

        private void AsignarDatos()
        {
            if(oListaPagos.Count == 0)
            {
                this.tlvLista.EmptyListMsg = "No se encontraron resultados.";
                this.tlvLista.EmptyListMsgFont = new Font("Tahoma", 14);
                TextOverlay textOverlay = this.tlvLista.EmptyListMsgOverlay as TextOverlay;
                textOverlay.TextColor = pnlSuperior.BackColor;
                textOverlay.BackColor = tlvLista.BackColor;
                textOverlay.BorderColor = pnlSuperior.BackColor;
                textOverlay.BorderWidth = 1.0f;
                textOverlay.Font = new Font("Tahoma", 20);
                textOverlay.Rotation = 0;
                lblCantidades.Visible = false;
            }
            else
            {
                this.tlvLista.SetObjects(oListaPagos);
                this.tlvLista.CheckBoxes = true;
                this.tlvLista.TriStateCheckBoxes = true;
                btnGenerarRecibos.Enabled = true;
                btnGenerarFac.Enabled = true;
                btnCredito.Enabled = true;
                btnGeneraRecibosX.Enabled = true;
                lblCantidades.Visible = true;
                lblCantidades.Text = $"Cantidad de registros encontrados: {oListaPagos.Count} - Recibos a generar: {cantiadRecibos}/{sumaRecibos.ToString("c2")} - Créditos a cuenta a generar: {cantidadCreditoACuenta}/{sumaCreditos.ToString("c2")}";
            }
            pnlCargando.Visible = false;
            SetearBotones(true);
            
        }

        private bool SeleccionarPunto()
        {
            frmPopUp oPop = new frmPopUp();
            CapaPresentacion.Herramientas.frmSeleccionPuntoVirtual ofrmPuntos = new Herramientas.frmSeleccionPuntoVirtual();
            oPop.Formulario = ofrmPuntos;
            oPop.Maximizar = false;
            if (oPop.ShowDialog() == DialogResult.OK)
            {
                this.idPunto = ofrmPuntos.idPuntoCobro;
                this.punto = ofrmPuntos.descripcionPuntoCobro;
                return true;
            }
            else
                return false;
        }

        private void SetearBotones(bool estado)
        {
            btnBuscar.Enabled = estado;
            btnCredito.Enabled = estado;
            btnGenerarFac.Enabled = estado;
            btnGenerarRecibos.Enabled = estado;
            btnGeneraRecibosX.Enabled = estado;
        }

        private void InicializarCMenu()
        {
            selCredito = false;
            selRecibos = false;
            selRecibosX = false;
            selTodo = false;
            foreach (ToolStripMenuItem item in mnuContextual.Items)
                item.Text = item.Text.Replace("Deseleccionar", "Seleccionar");
        }

        private void GenerarRecibos()
        {
            oConfi.LoadConfiguracion();
            int estadoActual = oConfi.GetValor_N("ReciboVirtualEstado");
            if (estadoActual == 0)
            {
                oConfi.SetValor_N("ReciboVirtualEstado", 1);
                if (SeleccionarPunto())
                {
                    List<Error> listaErrores = new List<Error>();

                    Comprobantes_Tipo oComprobante_Tipo = new Comprobantes_Tipo();
                    DataRow drDatosComprobanteRecibo;
                    DataRow drDatosComprobanteCredito;
                    Comprobantes oComprobante = new Comprobantes();
                    
                    foreach (CapaNegocios.PagosExternos.PagoExterno item in oListaSeleccionados)
                    {
                        CapaNegocios.PlataformasPagos oPlataformas = new CapaNegocios.PlataformasPagos();
                        Formas_de_pago oForma = oPlataformas.GetIdFormaPago(item.IdPlataforma);

                        if (item.ImportePago > 0 && item.IdComprobante == 0 && oForma != null && !item.ComprobanteAGenerar.ToLower().Contains("x"))
                        {
                            muestra = "";
                            NumeroString = "";
                            NroRecibo = 0;
                            PtoRecibo = 0;
                            //SI EL CTACTE YA ESTA PAGO (PORQUE LO PAGO PERSONALMENTE O LO PAGO DESDE MAS DE UNA PLATAFORMA SE HACE UN CREDITO A CUENTA
                            //POR EL CONTRARIO, SE HACE UN RECIBO
                            if (!item.Pagado)
                            {

                                drDatosComprobanteRecibo = oComprobante_Tipo.GetNumeracion(Convert.ToInt32(Comprobantes_Tipo.Tipo.RECIBO), this.idPunto);
                                if (drDatosComprobanteRecibo != null)
                                {
                                    NroRecibo = Convert.ToInt32(drDatosComprobanteRecibo["numComprobante"]);
                                    PtoRecibo = Convert.ToInt32(drDatosComprobanteRecibo["numPuntoVenta"]);
                                    NumeroString = PtoRecibo.ToString().PadLeft(4, '0') + "-" + NroRecibo.ToString().PadLeft(8, '0');

                                    //crea un recibo
                                    dtLocaciones = oUsuLoc.ListarLocacionesServicio(item.IdUsuario);
                                    dtModelo = oCtacte.LlenarDtModelo(dtLocaciones, "U", 0, item.IdUsuario);
                                    if (dtModelo.Rows.Count > 0)
                                    {
                                        DataView dvFiltroCtacte = dtModelo.DefaultView;
                                        dvFiltroCtacte.RowFilter = "id_usuarios_ctacte=" + item.IdUsuarioCtaCte;
                                        dtModelo = dvFiltroCtacte.ToTable();
                                        if (dtModelo.Rows.Count > 0)
                                        {
                                            foreach (DataRow deuda in dtModelo.Rows)
                                            {
                                                deuda["elige"] = true;
                                                deuda["importe_pago"] = deuda["importe_total"];

                                            }

                                            dtDatosCtaCte = oCtacte.ListarDatosCtaCte(item.IdUsuarioCtaCte);
                                            if (dtDatosCtaCte.Rows.Count > 0)
                                            {

                                                oComprobante.Id_Comprobantes_Tipo = (int)Comprobantes_Tipo.Tipo.RECIBO;
                                                oComprobante.Id_Usuarios = item.IdUsuario;
                                                oComprobante.Id_Personal = Personal.Id_Login;
                                                oComprobante.Id_Punto_Cobro = this.idPunto;
                                                oComprobante.Id_Punto_Venta = PtoRecibo;
                                                oComprobante.Id_Usuarios_Locaciones = Convert.ToInt32(dtDatosCtaCte.Rows[0]["id_usuarios_locacion"]);
                                                oComprobante.Importe = item.ImportePago;
                                                oComprobante.Numero = NroRecibo;
                                                oComprobante.Punto_Venta = this.idPunto;
                                                oComprobante.Descripcion = NumeroString;
                                                oComprobante.Fecha = DateTime.Now;
                                                if (oComprobante.Guardar(oComprobante) > 0)
                                                {
                                                    NroRecibo++;
                                                    Usuarios_CtaCte_Recibos oRecibo = new Usuarios_CtaCte_Recibos();
                                                    oRecibo.Id_Usuarios = item.IdUsuario;
                                                    oRecibo.Importe_Final = item.ImportePago;
                                                    oRecibo.Importe_Original = item.ImportePago;
                                                    oRecibo.Id_Usuarios_Locacion = Convert.ToInt32(dtModelo.Rows[0]["id_usuarios_locaciones"]);
                                                    oRecibo.Importe_Bonificacion = 0;
                                                    oRecibo.Importe_Provincial = 0;
                                                    oRecibo.Importe_Punitorio = 0;
                                                    oRecibo.Importe_Rendido = item.ImportePago;
                                                    oRecibo.Importe_Saldo = 0;
                                                    oRecibo.Id_Personal = Personal.Id_Login;
                                                    oRecibo.Id_Cobrador = 0;
                                                    oRecibo.Id_Caja_Diaria = 0;
                                                    oRecibo.Id_Usuarios_CtaCte = item.IdUsuarioCtaCte;
                                                    oRecibo.Id_Comprobantes = oComprobante.Id;
                                                    oRecibo.Id_Comprobantes_Tipo = oComprobante.Id_Comprobantes_Tipo;
                                                    oRecibo.Id_Presentacion_Deb = 0;
                                                    oRecibo.Numero = NroRecibo;
                                                    oRecibo.Numero_Muestra = NumeroString;
                                                    oRecibo.Recibo_Tipo = (int)Comprobantes_Tipo.Tipo.RECIBO;
                                                    oRecibo.Fecha_Movimiento = DateTime.Now;
                                                    oRecibo.Id_Puntos_Cobro = idPunto;

                                                    DataTable dtDetalleRecibo = new DataTable();
                                                    dtDetalleRecibo = new DataTable();
                                                    dtDetalleRecibo.Columns.Add("Nombre", typeof(String));
                                                    dtDetalleRecibo.Columns.Add("Importe", typeof(Decimal));
                                                    dtDetalleRecibo.Columns.Add("Cliente", typeof(string));
                                                    dtDetalleRecibo.Columns.Add("Cuenta", typeof(string));
                                                    dtDetalleRecibo.Columns.Add("Cuit", typeof(string));
                                                    dtDetalleRecibo.Columns.Add("Banco", typeof(string));
                                                    dtDetalleRecibo.Columns.Add("Sucursal", typeof(string));
                                                    dtDetalleRecibo.Columns.Add("Fecha_Comprobante", typeof(string));
                                                    dtDetalleRecibo.Columns.Add("Fecha_Acreditacion", typeof(string));
                                                    dtDetalleRecibo.Columns.Add("Numero", typeof(Int32));
                                                    dtDetalleRecibo.Columns.Add("Id_formas_de_pago", typeof(Int32));
                                                    dtDetalleRecibo.Columns.Add("Id_usuarios_locaciones", typeof(Int32));

                                                    DataRow drForma = dtDetalleRecibo.NewRow();
                                                    drForma["Nombre"] = oForma.Nombre;
                                                    drForma["Importe"] = item.ImportePago;
                                                    drForma["Cliente"] = "";
                                                    drForma["Cuenta"] = "1";
                                                    drForma["Cuit"] = "";
                                                    drForma["Banco"] = "";
                                                    drForma["Sucursal"] = "";
                                                    drForma["Fecha_Comprobante"] = DateTime.Now.ToString();
                                                    drForma["Fecha_Acreditacion"] = DateTime.Now.ToString();
                                                    drForma["Numero"] = 0;
                                                    drForma["Id_formas_de_pago"] = oForma.Id;
                                                    drForma["Id_usuarios_locaciones"] = oRecibo.Id_Usuarios_Locacion;

                                                    dtDetalleRecibo.Rows.Add(drForma);
                                                    dtDetalleRecibo.AcceptChanges();
                                                    string salida = "";
                                                    if (oRecibo.guardar(oRecibo, dtDetalleRecibo, dtModelo, 1, out salida))
                                                    {
                                                        dtDatosPuntoCobro = oCobro.PuntoDatos(idPunto);
                                                        int punto = Convert.ToInt32(dtDatosPuntoCobro.Rows[0]["punto"]);
                                                        Comprobantes_Habilitados oHabolitados = new Comprobantes_Habilitados();
                                                        dtPuntosVenta = oHabolitados.GetDatosPuntoVenta(oComprobante.Id_Comprobantes_Tipo, idPunto);
                                                        int idPuntoVenta = Convert.ToInt32(dtPuntosVenta.Rows[0]["id_punto_venta"]);
                                                        oComprobante_Tipo.SetNumeracion(idPuntoVenta, oComprobante.Id_Comprobantes_Tipo, NroRecibo);
                                                        item.IdComprobante = oRecibo.Id;
                                                        List<CapaNegocios.PagosExternos.PagoExterno> listaPago = new List<PagoExterno>();
                                                        item.IdComprobanteTipo = (int)Comprobantes_Tipo.Tipo.RECIBO;
                                                        listaPago.Add(item);
                                                        

                                                        //si pago de mas tiene que hacer un credito a cuenta
                                                        if(item.ImportePago > item.ImporteSaldo)
                                                        {
                                                            decimal importeCreditoCuenta = item.ImportePago - item.ImporteSaldo;
                                                            drDatosComprobanteCredito = oComprobante_Tipo.GetNumeracion(Convert.ToInt32(Comprobantes_Tipo.Tipo.CREDITO_A_CUENTA), idPunto);
                                                            dtDatosCtaCte = oCtacte.ListarDatosCtaCte(item.IdUsuarioCtaCte);
                                                            if (dtDatosCtaCte.Rows.Count > 0)
                                                            {
                                                                oComprobante.Id_Usuarios = item.IdUsuario;
                                                                oComprobante.Fecha = DateTime.Now;
                                                                oComprobante.Punto_Venta = Convert.ToInt32(drDatosComprobanteCredito["numPuntoVenta"]);
                                                                oComprobante.Id_Comprobantes_Tipo = Convert.ToInt32(Comprobantes_Tipo.Tipo.CREDITO_A_CUENTA);
                                                                oComprobante.Numero = Convert.ToInt32(drDatosComprobanteCredito["numComprobante"]);
                                                                oComprobante.Importe = importeCreditoCuenta;
                                                                oComprobante.Id_Usuarios_Locaciones = Convert.ToInt32(dtDatosCtaCte.Rows[0]["id_usuarios_locacion"]);
                                                                oComprobante.Id_Personal = Personal.Id_Login;
                                                                oComprobante.Id = oComprobante.Guardar(oComprobante);
                                                                if (oComprobante.Id > 0)
                                                                {
                                                                    oCtacteCredito.Id_Usuarios = oComprobante.Id_Usuarios;
                                                                    oCtacteCredito.Id_Comprobantes = oComprobante.Id;
                                                                    oCtacteCredito.Fecha_Movimiento = DateTime.Now;
                                                                    oCtacteCredito.Fecha_Desde = DateTime.Today;
                                                                    oCtacteCredito.Fecha_Hasta = DateTime.Today;
                                                                    muestra = "CREDITO A CUENTA " + 0.ToString().PadLeft(4, '0') + "-" + oCtacteCredito.Id_Comprobantes.ToString().PadLeft(8, '0');
                                                                    oCtacteCredito.Descripcion = muestra;
                                                                    oCtacteCredito.Importe_Original = importeCreditoCuenta;
                                                                    oCtacteCredito.Importe_Punitorio = 0;
                                                                    oCtacteCredito.Importe_Bonificacion = 0;
                                                                    oCtacteCredito.Importe_Final = importeCreditoCuenta;
                                                                    oCtacteCredito.Importe_Saldo = 0;
                                                                    oCtacteCredito.Id_Usuarios_Locacion = oComprobante.Id_Usuarios_Locaciones;
                                                                    oCtacteCredito.Numero = oComprobante.Numero.ToString();
                                                                    oCtacteCredito.Id_Comprobantes_Tipo = Convert.ToInt32(Comprobantes_Tipo.Tipo.CREDITO_A_CUENTA);
                                                                    oCtacteCredito.Id_Comprobantes_Ref = oComprobante.Id;
                                                                    oCtacteCredito.Id_Facturacion = 0;
                                                                    oCtacteCredito.Generado_facturacion_mensual = Convert.ToInt32(Usuarios_CtaCte.GENERADO_FACTURACION_MENSUAL.NO);
                                                                    oCtacteCredito.Id_Personal = Personal.Id_Login;
                                                                    oCtacteCredito.Id_Origen = (int)Usuarios_CtaCte.ORIGEN.PAGOS_EXTERNOS;
                                                                    if (oCtacteCredito.Guardar(oCtacteCredito) > 0)
                                                                    {
                                                                        Usuarios_CtaCte_Det oDet = new Usuarios_CtaCte_Det();
                                                                        oDet.Id_Usuarios_CtaCte = oCtacteCredito.Id;
                                                                        oDet.Id_Usuarios_Locaciones = oComprobante.Id_Usuarios_Locaciones;
                                                                        oDet.Id_Zonas = 0;
                                                                        oDet.Id_Servicios = 0;
                                                                        oDet.Id_Tipo = 1;
                                                                        oDet.Tipo = "S";
                                                                        oDet.Importe_Original = oComprobante.Importe;
                                                                        oDet.Importe_Saldo = oComprobante.Importe;
                                                                        oDet.Importe_Bonificacion = 0;
                                                                        oDet.Importe_Punitorio = 0;
                                                                        oDet.Fecha_Desde = DateTime.Now;
                                                                        oDet.Fecha_Hasta = DateTime.Now;
                                                                        oDet.Id_Usuarios_Servicios = 0;
                                                                        oDet.Id_Velocidades = 0;
                                                                        oDet.Id_Velocidades_Tip = 0;
                                                                        oDet.Requiere_IP = 0;
                                                                        oDet.Cantidad_Periodos = 0;
                                                                        oDet.Id_bonificacion_Aplicada = 0;
                                                                        oDet.Nombre_Bonificacion = String.Empty;
                                                                        oDet.Periodo_Ano = oDet.Fecha_Desde.Year;
                                                                        oDet.Periodo_Mes = oDet.Fecha_Desde.Month;
                                                                        oDet.Porcentaje_Bonificacion = 0;
                                                                        oDet.Detalles = " Credito ";
                                                                        List<Usuarios_CtaCte_Det> oListaDet = new List<Usuarios_CtaCte_Det>();
                                                                        oListaDet.Add(oDet);
                                                                        if (oDet.Guardar(oDet) > 0)
                                                                        {
                                                                            Usuarios_Locaciones.ActualizarSaldo(oComprobante.Id_Usuarios_Locaciones);
                                                                            oComprobante_Tipo.SetNumeracion(Convert.ToInt32(drDatosComprobanteCredito["idPuntoVenta"]), Convert.ToInt32(Comprobantes_Tipo.Tipo.CREDITO_A_CUENTA), Convert.ToInt32(drDatosComprobanteCredito["numComprobante"]));
                                                                            
                                                                        }
                                                                        else
                                                                            listaErrores.Add(new Error(item.Id, "Error al intentar guardar el detalle del Crédito a cuenta."));
                                                                    }
                                                                    else
                                                                        listaErrores.Add(new Error(item.Id, "Error al intentar guardar el Crédito a cuenta."));
                                                                }
                                                            }
                                                        }
                                                        
                                                        
                                                        
                                                        
                                                        
                                                        
                                                        
                                                        
                                                        
                                                        if (oPagos.AsignarComprobante(listaPago))
                                                        {
                                                            if (item.IdPlataforma == (int)CapaNegocios.PagosExternos.PagoExterno.Plataforma.MERCADOPAGO)
                                                            {
                                                                CapaNegocios.PagosExternos.MercadoPagoCh.MPCh oMercadoPagoCH = new CapaNegocios.PagosExternos.MercadoPagoCh.MPCh();
                                                                string salidaMPCH = "";
                                                                if (!oMercadoPagoCH.MarcarDeudaPagada(item.IdPago, out salidaMPCH))
                                                                {
                                                                    MessageBox.Show("Hubo un error al intentar actualizar los datos en MercadoPago.\n El recibo fue generado correctamente pero no se pudo marcar como pagado en la base de datos externa.\n" + salidaMPCH, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                                                }
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        oComprobante.Eliminar(oComprobante.Id, "pago externo fallido");
                                                        NroRecibo--;
                                                        listaErrores.Add(new Error(item.Id, "Error al generar el recibo. \n " + salida));
                                                    }
                                                }
                                                else
                                                    listaErrores.Add(new Error(item.Id, "Error al generar el comprobante."));
                                            }
                                            else
                                                listaErrores.Add(new Error(item.Id, "Error. No se encontraron datos de la deuda a cancelar."));
                                        }
                                        else
                                            listaErrores.Add(new Error(item.Id, "Error. No se encontraron datos de la deuda a cancelar."));

                                    }
                                    else
                                        listaErrores.Add(new Error(item.Id, "Error. No se encontraron datos de la deuda a cancelar."));
                                }
                            }
                        }
                    }
                    if (listaErrores.Count > 0)
                    {
                        MessageBox.Show("Hubo errores durante el proceso","Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        WriteToXmlFile(@"c:\GIES\error_pago_externos.xml", listaErrores);
                        ComenzarCarga();

                    }
                    else
                    {
                        if (MessageBox.Show("Recibos generados correctamente. ¿Desea seguir generando recibos o comprobantes de credito a cuenta?", "Mensaje del Sisema", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No)
                        {
                            Contabilidad.frmRecibosVirtuales frm = new Contabilidad.frmRecibosVirtuales();
                            frmMain.Instance().openForm(frm);
                        }
                    }

                    oConfi.SetValor_N("ReciboVirtualEstado", 0);
                }
                else
                {
                    // PONGO EN 0 LA VARIABLE PARA QUE OTRO PUEDA GENERAR RECIBOS O COMPORBNATES
                    oConfi.SetValor_N("ReciboVirtualEstado", 0);
                }

            }
            else
            {
                MessageBox.Show("Otra terminal se encuentra realizando esta operación, por favor intente más tarde.", "Mnesaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                ComenzarCarga();
            }

        }

        private void GenerarRecibosX()
        {
            SetearBotones(false);


            oConfi.LoadConfiguracion();
            int estadoActual = oConfi.GetValor_N("ReciboVirtualEstado");
            if (estadoActual == 0)
            {
                oConfi.SetValor_N("ReciboVirtualEstado", 1);
                if (SeleccionarPunto())
                {
                    List<Error> listaErrores = new List<Error>();

                    Comprobantes_Tipo oComprobante_Tipo = new Comprobantes_Tipo();
                    DataRow drDatosComprobanteRecibo;
                    DataRow drDatosComprobanteCredito;

                    Comprobantes oComprobante = new Comprobantes();



                    var checkedObjects = tlvLista.CheckedObjects;
                    List<CapaNegocios.PagosExternos.PagoExterno> oListaSeleccionados = new List<PagoExterno>(); ;
                    foreach (PagoExterno itemSeleccionado in checkedObjects)
                        oListaSeleccionados.Add(itemSeleccionado);

                    // -----------------------------  CONVIERTE A FACTURA


                    foreach (CapaNegocios.PagosExternos.PagoExterno item in oListaSeleccionados)
                    {
                        CapaNegocios.PlataformasPagos oPlataformas = new CapaNegocios.PlataformasPagos();
                        Formas_de_pago oForma = oPlataformas.GetIdFormaPago(item.IdPlataforma);

                        if (item.ImportePago > 0 && item.IdComprobante == 0 && item.ComprobanteAGenerar.ToLower().Trim().Equals("recibo x") && oForma != null)
                        {
                            muestra = "";
                            NumeroString = "";
                            NroRecibo = 0;
                            PtoRecibo = 0;
                            //SI EL CTACTE YA ESTA PAGO (PORQUE LO PAGO PERSONALMENTE O LO PAGO DESDE MAS DE UNA PLATAFORMA SE HACE UN CREDITO A CUENTA
                            //POR EL CONTRARIO, SE HACE UN RECIBO
                            if (!item.Pagado)
                            {

                                drDatosComprobanteRecibo = oComprobante_Tipo.GetNumeracion(Convert.ToInt32(Comprobantes_Tipo.Tipo.RECIBO_INTERNO), this.idPunto);
                                if (drDatosComprobanteRecibo != null)
                                {
                                    NroRecibo = Convert.ToInt32(drDatosComprobanteRecibo["numComprobante"]);
                                    PtoRecibo = Convert.ToInt32(drDatosComprobanteRecibo["numPuntoVenta"]);
                                    NumeroString = PtoRecibo.ToString().PadLeft(4, '0') + "-" + NroRecibo.ToString().PadLeft(8, '0');

                                    //crea un recibo
                                    dtLocaciones = oUsuLoc.ListarLocacionesServicio(item.IdUsuario);
                                    dtModelo = oCtacte.LlenarDtModelo(dtLocaciones, "U", 0, item.IdUsuario);
                                    if (dtModelo.Rows.Count > 0)
                                    {
                                        DataView dvFiltroCtacte = dtModelo.DefaultView;
                                        dvFiltroCtacte.RowFilter = "id_usuarios_ctacte=" + item.IdUsuarioCtaCte;
                                        dtModelo = dvFiltroCtacte.ToTable();
                                        if (dtModelo.Rows.Count > 0)
                                        {
                                            foreach (DataRow deuda in dtModelo.Rows)
                                            {
                                                deuda["elige"] = true;
                                                deuda["importe_pago"] = deuda["importe_total"];

                                            }

                                            dtDatosCtaCte = oCtacte.ListarDatosCtaCte(item.IdUsuarioCtaCte);
                                            if (dtDatosCtaCte.Rows.Count > 0)
                                            {

                                                oComprobante.Id_Comprobantes_Tipo = (int)Comprobantes_Tipo.Tipo.RECIBO_INTERNO;
                                                oComprobante.Id_Usuarios = item.IdUsuario;
                                                oComprobante.Id_Personal = Personal.Id_Login;
                                                oComprobante.Id_Punto_Cobro = this.idPunto;
                                                oComprobante.Id_Punto_Venta = PtoRecibo;
                                                oComprobante.Id_Usuarios_Locaciones = Convert.ToInt32(dtDatosCtaCte.Rows[0]["id_usuarios_locacion"]);
                                                oComprobante.Importe = item.ImportePago;
                                                oComprobante.Numero = NroRecibo;
                                                oComprobante.Punto_Venta = this.idPunto;
                                                oComprobante.Descripcion = NumeroString;
                                                oComprobante.Fecha = DateTime.Now;
                                                if (oComprobante.Guardar(oComprobante) > 0)
                                                {
                                                    NroRecibo++;
                                                    Usuarios_CtaCte_Recibos oRecibo = new Usuarios_CtaCte_Recibos();
                                                    oRecibo.Id_Usuarios = item.IdUsuario;
                                                    oRecibo.Importe_Final = item.ImportePago;
                                                    oRecibo.Importe_Original = item.ImportePago;
                                                    oRecibo.Id_Usuarios_Locacion = Convert.ToInt32(dtModelo.Rows[0]["id_usuarios_locaciones"]);
                                                    oRecibo.Importe_Bonificacion = 0;
                                                    oRecibo.Importe_Provincial = 0;
                                                    oRecibo.Importe_Punitorio = 0;
                                                    oRecibo.Importe_Rendido = item.ImportePago;
                                                    oRecibo.Importe_Saldo = 0;
                                                    oRecibo.Id_Personal = Personal.Id_Login;
                                                    oRecibo.Id_Cobrador = 0;
                                                    oRecibo.Id_Caja_Diaria = 0;
                                                    oRecibo.Id_Usuarios_CtaCte = item.IdUsuarioCtaCte;
                                                    oRecibo.Id_Comprobantes = oComprobante.Id;
                                                    oRecibo.Id_Comprobantes_Tipo = oComprobante.Id_Comprobantes_Tipo;
                                                    oRecibo.Id_Presentacion_Deb = 0;
                                                    oRecibo.Numero = NroRecibo;
                                                    oRecibo.Numero_Muestra = NumeroString;
                                                    oRecibo.Recibo_Tipo = (int)Comprobantes_Tipo.Tipo.RECIBO_INTERNO;
                                                    oRecibo.Fecha_Movimiento = DateTime.Now;
                                                    oRecibo.Id_Puntos_Cobro = idPunto;

                                                    DataTable dtDetalleRecibo = new DataTable();
                                                    dtDetalleRecibo = new DataTable();
                                                    dtDetalleRecibo.Columns.Add("Nombre", typeof(String));
                                                    dtDetalleRecibo.Columns.Add("Importe", typeof(Decimal));
                                                    dtDetalleRecibo.Columns.Add("Cliente", typeof(string));
                                                    dtDetalleRecibo.Columns.Add("Cuenta", typeof(string));
                                                    dtDetalleRecibo.Columns.Add("Cuit", typeof(string));
                                                    dtDetalleRecibo.Columns.Add("Banco", typeof(string));
                                                    dtDetalleRecibo.Columns.Add("Sucursal", typeof(string));
                                                    dtDetalleRecibo.Columns.Add("Fecha_Comprobante", typeof(string));
                                                    dtDetalleRecibo.Columns.Add("Fecha_Acreditacion", typeof(string));
                                                    dtDetalleRecibo.Columns.Add("Numero", typeof(Int32));
                                                    dtDetalleRecibo.Columns.Add("Id_formas_de_pago", typeof(Int32));
                                                    dtDetalleRecibo.Columns.Add("Id_usuarios_locaciones", typeof(Int32));

                                                    DataRow drForma = dtDetalleRecibo.NewRow();
                                                    drForma["Nombre"] = oForma.Nombre;
                                                    drForma["Importe"] = item.ImportePago;
                                                    drForma["Cliente"] = "";
                                                    drForma["Cuenta"] = "1";
                                                    drForma["Cuit"] = "";
                                                    drForma["Banco"] = "";
                                                    drForma["Sucursal"] = "";
                                                    drForma["Fecha_Comprobante"] = DateTime.Now.ToString();
                                                    drForma["Fecha_Acreditacion"] = DateTime.Now.ToString();
                                                    drForma["Numero"] = 0;
                                                    drForma["Id_formas_de_pago"] = oForma.Id;
                                                    drForma["Id_usuarios_locaciones"] = oRecibo.Id_Usuarios_Locacion;

                                                    dtDetalleRecibo.Rows.Add(drForma);
                                                    dtDetalleRecibo.AcceptChanges();
                                                    string salida = "";
                                                    if (oRecibo.guardar(oRecibo, dtDetalleRecibo, dtModelo, 1, out salida))
                                                    {
                                                        dtDatosPuntoCobro = oCobro.PuntoDatos(idPunto);
                                                        int punto = Convert.ToInt32(dtDatosPuntoCobro.Rows[0]["punto"]);
                                                        Comprobantes_Habilitados oHabolitados = new Comprobantes_Habilitados();
                                                        dtPuntosVenta = oHabolitados.GetDatosPuntoVenta(oComprobante.Id_Comprobantes_Tipo, idPunto);
                                                        int idPuntoVenta = Convert.ToInt32(dtPuntosVenta.Rows[0]["id_punto_venta"]);
                                                        oComprobante_Tipo.SetNumeracion(idPuntoVenta, oComprobante.Id_Comprobantes_Tipo, NroRecibo);
                                                        item.IdComprobante = oRecibo.Id;
                                                        List<CapaNegocios.PagosExternos.PagoExterno> listaPago = new List<PagoExterno>();
                                                        item.IdComprobanteTipo = (int)Comprobantes_Tipo.Tipo.RECIBO_INTERNO;
                                                        listaPago.Add(item);
                                                        if (oPagos.AsignarComprobante(listaPago))
                                                        {
                                                            if (item.IdPlataforma == (int)CapaNegocios.PagosExternos.PagoExterno.Plataforma.MERCADOPAGO)
                                                            {
                                                                CapaNegocios.PagosExternos.MercadoPagoCh.MPCh oMercadoPagoCH = new CapaNegocios.PagosExternos.MercadoPagoCh.MPCh();
                                                                string salidaMPCH = "";
                                                                if (!oMercadoPagoCH.MarcarDeudaPagada(item.IdPago, out salidaMPCH))
                                                                {
                                                                    MessageBox.Show("Hubo un error al intentar actualizar los datos en MercadoPago.\n El recibo fue generado correctamente pero no se pudo marcar como pagado en la base de datos externa.\n" + salidaMPCH, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                                                }
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        oComprobante.Eliminar(oComprobante.Id, "pago externo fallido");
                                                        NroRecibo--;
                                                        listaErrores.Add(new Error(item.Id, "Error al generar el recibo. \n " + salida));
                                                    }
                                                }
                                                else
                                                    listaErrores.Add(new Error(item.Id, "Error al generar el comprobante."));
                                            }
                                            else
                                                listaErrores.Add(new Error(item.Id, "Error. No se encontraron datos de la deuda a cancelar."));
                                        }
                                        else
                                            listaErrores.Add(new Error(item.Id, "Error. No se encontraron datos de la deuda a cancelar."));

                                    }
                                    else
                                        listaErrores.Add(new Error(item.Id, "Error. No se encontraron datos de la deuda a cancelar."));
                                }
                            }
                        }
                    }
                    if (listaErrores.Count > 0)
                    {
                        MessageBox.Show("Hubo errores durante el proceso", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        WriteToXmlFile(@"c:\GIES\error_pago_externos.xml", listaErrores);
                        ComenzarCarga();

                    }
                    else
                    {
                        if (MessageBox.Show("Recibos generados correctamente. ¿Desea seguir generando recibos o comprobantes de credito a cuenta?", "Mensaje del Sisema", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No)
                        {
                            Contabilidad.frmRecibosVirtuales frm = new Contabilidad.frmRecibosVirtuales();
                            frmMain.Instance().openForm(frm);
                        }
                        else
                        {
                            SetearBotones(true);
                        }
                    }
                    oConfi.SetValor_N("ReciboVirtualEstado", 0);
                }
                else
                {
                    oConfi.SetValor_N("ReciboVirtualEstado", 0);
                }
            }
            else
            {
                MessageBox.Show("Otra terminal se encuentra realizando esta operación, por favor intente más tarde.", "Mnesaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                ComenzarCarga();

            }
        }

        #endregion

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmPagosGuardados_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.DialogResult = DialogResult.Cancel;
        }

        private void btnCredito_Click(object sender, EventArgs e)
        {
            oConfi.LoadConfiguracion();
            int estadoActual = oConfi.GetValor_N("ReciboVirtualEstado");
            if (estadoActual == 0)
            {
                oConfi.SetValor_N("ReciboVirtualEstado", 1);
                if (SeleccionarPunto())
                {
                    List<Error> listaErrores = new List<Error>();
                    bool reciboHecho = false;
                    Comprobantes_Tipo oComprobante_Tipo = new Comprobantes_Tipo();
                    DataRow drDatosComprobanteRecibo;
                    DataRow drDatosComprobanteCredito;

                    Comprobantes oComprobante = new Comprobantes();

                    Puntos_Venta oPuntoVemta = new Puntos_Venta();
                    Puntos_Cobros oCobro = new Puntos_Cobros();
                    DataTable dtDatosPuntoCobro;
                    DataTable dtPuntosVenta;
                    Usuarios_CtaCte oCtacte = new Usuarios_CtaCte();
                    Usuarios_CtaCte oCtacteCredito = new Usuarios_CtaCte();
                    Usuarios_Locaciones oUsuLoc = new Usuarios_Locaciones();
                    DataTable dtDatosCtaCte = new DataTable();
                    DataTable dtModelo = new DataTable();
                    DataTable dtLocaciones = new DataTable();
                    string muestra;
                    string NumeroString;
                    int NroRecibo, PtoRecibo;
                    var checkedObjects = tlvLista.CheckedObjects;
                    List<CapaNegocios.PagosExternos.PagoExterno> oListaSeleccionados = new List<PagoExterno>(); ;
                    foreach (PagoExterno itemSeleccionado in checkedObjects)
                        oListaSeleccionados.Add(itemSeleccionado);

                    foreach (CapaNegocios.PagosExternos.PagoExterno item in oListaSeleccionados)
                    {
                        CapaNegocios.PlataformasPagos oPlataformas = new CapaNegocios.PlataformasPagos();
                        Formas_de_pago oForma = oPlataformas.GetIdFormaPago(item.IdPlataforma);
                        reciboHecho = false;
                        if (item.ImportePago > 0 && item.IdComprobante == 0 && oForma != null)
                        {
                            Usuarios_CtaCte_Recibos oRecibo = new Usuarios_CtaCte_Recibos();
                            muestra = "";
                            NumeroString = "";
                            NroRecibo = 0;
                            PtoRecibo = 0;
                            //SI EL CTACTE YA ESTA PAGO (PORQUE LO PAGO PERSONALMENTE O LO PAGO DESDE MAS DE UNA PLATAFORMA SE HACE UN CREDITO A CUENTA
                            //POR EL CONTRARIO, SE HACE UN RECIBO
                            if (item.Pagado)
                            {
                                try
                                {
                                    drDatosComprobanteRecibo = oComprobante_Tipo.GetNumeracion(Convert.ToInt32(Comprobantes_Tipo.Tipo.RECIBO), this.idPunto);
                                    if (drDatosComprobanteRecibo != null)
                                    {
                                        NroRecibo = Convert.ToInt32(drDatosComprobanteRecibo["numComprobante"]);
                                        PtoRecibo = Convert.ToInt32(drDatosComprobanteRecibo["numPuntoVenta"]);
                                        NumeroString = PtoRecibo.ToString().PadLeft(4, '0') + "-" + NroRecibo.ToString().PadLeft(8, '0');
                                        DataRow dr = oCtacte.getDatosCtaCte(0, item.IdUsuarioCtaCte);

                                        //crea un recibo
                                        dtLocaciones = oUsuLoc.ListarLocacionesServicio(item.IdUsuario);
                                        dtModelo = oCtacte.LlenarDtModelo(dtLocaciones, "C", Convert.ToInt32(dr["id_comprobantes"]));
                                        if (dtModelo.Rows.Count > 0)
                                        {
                                            DataView dvFiltroCtacte = dtModelo.DefaultView;
                                            dvFiltroCtacte.RowFilter = "id_usuarios_ctacte=" + item.IdUsuarioCtaCte;
                                            dtModelo = dvFiltroCtacte.ToTable();
                                            if (dtModelo.Rows.Count > 0)
                                            {
                                                foreach (DataRow deuda in dtModelo.Rows)
                                                {
                                                    deuda["elige"] = true;
                                                    deuda["importe_pago"] = deuda["importe_total"];

                                                }

                                                dtDatosCtaCte = oCtacte.ListarDatosCtaCte(item.IdUsuarioCtaCte);
                                                if (dtDatosCtaCte.Rows.Count > 0)
                                                {

                                                    oComprobante.Id_Comprobantes_Tipo = (int)Comprobantes_Tipo.Tipo.RECIBO;
                                                    oComprobante.Id_Usuarios = item.IdUsuario;
                                                    oComprobante.Id_Personal = Personal.Id_Login;
                                                    oComprobante.Id_Punto_Cobro = this.idPunto;
                                                    oComprobante.Id_Punto_Venta = PtoRecibo;
                                                    oComprobante.Id_Usuarios_Locaciones = Convert.ToInt32(dtDatosCtaCte.Rows[0]["id_usuarios_locacion"]);
                                                    oComprobante.Importe = item.ImportePago;
                                                    oComprobante.Numero = NroRecibo;
                                                    oComprobante.Punto_Venta = this.idPunto;
                                                    oComprobante.Descripcion = NumeroString;
                                                    oComprobante.Fecha = DateTime.Now;
                                                    if (oComprobante.Guardar(oComprobante) > 0)
                                                    {
                                                        NroRecibo++;
                                                        oRecibo = new Usuarios_CtaCte_Recibos();
                                                        oRecibo.Id_Usuarios = item.IdUsuario;
                                                        oRecibo.Importe_Final = item.ImportePago;
                                                        oRecibo.Importe_Original = item.ImportePago;
                                                        oRecibo.Id_Usuarios_Locacion = Convert.ToInt32(dtModelo.Rows[0]["id_usuarios_locaciones"]);
                                                        oRecibo.Importe_Bonificacion = 0;
                                                        oRecibo.Importe_Provincial = 0;
                                                        oRecibo.Importe_Punitorio = 0;
                                                        oRecibo.Importe_Rendido = item.ImportePago;
                                                        oRecibo.Importe_Saldo = 0;
                                                        oRecibo.Id_Personal = Personal.Id_Login;
                                                        oRecibo.Id_Cobrador = 0;
                                                        oRecibo.Id_Caja_Diaria = 0;
                                                        oRecibo.Id_Usuarios_CtaCte = item.IdUsuarioCtaCte;
                                                        oRecibo.Id_Comprobantes = oComprobante.Id;
                                                        oRecibo.Id_Comprobantes_Tipo = oComprobante.Id_Comprobantes_Tipo;
                                                        oRecibo.Id_Presentacion_Deb = 0;
                                                        oRecibo.Numero = NroRecibo;
                                                        oRecibo.Numero_Muestra = NumeroString;
                                                        oRecibo.Recibo_Tipo = (int)Comprobantes_Tipo.Tipo.RECIBO;
                                                        oRecibo.Fecha_Movimiento = DateTime.Now;
                                                        oRecibo.Id_Puntos_Cobro = idPunto;

                                                        DataTable dtDetalleRecibo = new DataTable();
                                                        dtDetalleRecibo = new DataTable();
                                                        dtDetalleRecibo.Columns.Add("Nombre", typeof(String));
                                                        dtDetalleRecibo.Columns.Add("Importe", typeof(Decimal));
                                                        dtDetalleRecibo.Columns.Add("Cliente", typeof(string));
                                                        dtDetalleRecibo.Columns.Add("Cuenta", typeof(string));
                                                        dtDetalleRecibo.Columns.Add("Cuit", typeof(string));
                                                        dtDetalleRecibo.Columns.Add("Banco", typeof(string));
                                                        dtDetalleRecibo.Columns.Add("Sucursal", typeof(string));
                                                        dtDetalleRecibo.Columns.Add("Fecha_Comprobante", typeof(string));
                                                        dtDetalleRecibo.Columns.Add("Fecha_Acreditacion", typeof(string));
                                                        dtDetalleRecibo.Columns.Add("Numero", typeof(Int32));
                                                        dtDetalleRecibo.Columns.Add("Id_formas_de_pago", typeof(Int32));
                                                        dtDetalleRecibo.Columns.Add("Id_usuarios_locaciones", typeof(Int32));

                                                        DataRow drForma = dtDetalleRecibo.NewRow();
                                                        drForma["Nombre"] = oForma.Nombre;
                                                        drForma["Importe"] = item.ImportePago;
                                                        drForma["Cliente"] = "";
                                                        drForma["Cuenta"] = "1";
                                                        drForma["Cuit"] = "";
                                                        drForma["Banco"] = "";
                                                        drForma["Sucursal"] = "";
                                                        drForma["Fecha_Comprobante"] = DateTime.Now.ToString();
                                                        drForma["Fecha_Acreditacion"] = DateTime.Now.ToString();
                                                        drForma["Numero"] = 0;
                                                        drForma["Id_formas_de_pago"] = oForma.Id;
                                                        drForma["Id_usuarios_locaciones"] = oRecibo.Id_Usuarios_Locacion;

                                                        dtDetalleRecibo.Rows.Add(drForma);
                                                        dtDetalleRecibo.AcceptChanges();
                                                        string salida = "";
                                                        if (oRecibo.guardar(oRecibo, dtDetalleRecibo, dtModelo, 1, out salida))
                                                        {
                                                            dtDatosPuntoCobro = oCobro.PuntoDatos(idPunto);
                                                            int punto = Convert.ToInt32(dtDatosPuntoCobro.Rows[0]["punto"]);
                                                            Comprobantes_Habilitados oHabolitados = new Comprobantes_Habilitados();
                                                            dtPuntosVenta = oHabolitados.GetDatosPuntoVenta(oComprobante.Id_Comprobantes_Tipo, idPunto);
                                                            int idPuntoVenta = Convert.ToInt32(dtPuntosVenta.Rows[0]["id_punto_venta"]);
                                                            oComprobante_Tipo.SetNumeracion(idPuntoVenta, oComprobante.Id_Comprobantes_Tipo, NroRecibo);
                                                            item.IdComprobante = oRecibo.Id;
                                                            List<CapaNegocios.PagosExternos.PagoExterno> listaPago = new List<PagoExterno>();
                                                            item.IdComprobanteTipo = (int)Comprobantes_Tipo.Tipo.RECIBO;
                                                            listaPago.Add(item);
                                                            if (oPagos.AsignarComprobante(listaPago))
                                                            {
                                                                if (item.IdPlataforma == (int)CapaNegocios.PagosExternos.PagoExterno.Plataforma.MERCADOPAGO)
                                                                {
                                                                    CapaNegocios.PagosExternos.MercadoPagoCh.MPCh oMercadoPagoCH = new CapaNegocios.PagosExternos.MercadoPagoCh.MPCh();
                                                                    string salidaMPCH = "";
                                                                    if (!oMercadoPagoCH.MarcarDeudaPagada(item.IdPago, out salidaMPCH))
                                                                    {
                                                                        MessageBox.Show("Hubo un error al intentar actualizar los datos en MercadoPago.\n El recibo fue generado correctamente pero no se pudo marcar como pagado en la base de datos externa.\n" + salidaMPCH, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                                                    }
                                                                }
                                                            }

                                                            reciboHecho = true;
                                                        }
                                                        else
                                                        {
                                                            reciboHecho = false;
                                                            oComprobante.Eliminar(oComprobante.Id, "pago externo fallido");
                                                            NroRecibo--;
                                                            listaErrores.Add(new Error(item.Id, "Error al generar el recibo. \n " + salida));
                                                        }
                                                    }
                                                    else
                                                    {
                                                        reciboHecho = false;
                                                        listaErrores.Add(new Error(item.Id, "Error al generar el comprobante."));
                                                    }
                                                }
                                                else
                                                {
                                                    reciboHecho = false;
                                                    listaErrores.Add(new Error(item.Id, "Error. No se encontraron datos de la deuda a cancelar."));
                                                }
                                            }
                                            else
                                            {
                                                reciboHecho = false;
                                                listaErrores.Add(new Error(item.Id, "Error. No se encontraron datos de la deuda a cancelar."));
                                            }
                                        }
                                        else
                                        {
                                            reciboHecho = false;
                                            listaErrores.Add(new Error(item.Id, "Error. No se encontraron datos de la deuda a cancelar."));
                                        }
                                    }
                                    else
                                    {
                                        reciboHecho = false;
                                    }

                                    if (reciboHecho)
                                    {
                                        drDatosComprobanteCredito = oComprobante_Tipo.GetNumeracion(Convert.ToInt32(Comprobantes_Tipo.Tipo.CREDITO_A_CUENTA), idPunto);
                                        dtDatosCtaCte = oCtacte.ListarDatosCtaCte(item.IdUsuarioCtaCte);
                                        if (dtDatosCtaCte.Rows.Count > 0)
                                        {
                                            oComprobante.Id_Usuarios = item.IdUsuario;
                                            oComprobante.Fecha = DateTime.Now;
                                            oComprobante.Punto_Venta = Convert.ToInt32(drDatosComprobanteCredito["numPuntoVenta"]);
                                            oComprobante.Id_Comprobantes_Tipo = Convert.ToInt32(Comprobantes_Tipo.Tipo.CREDITO_A_CUENTA);
                                            oComprobante.Numero = Convert.ToInt32(drDatosComprobanteCredito["numComprobante"]);
                                            oComprobante.Importe = item.ImportePago * -1;
                                            oComprobante.Id_Usuarios_Locaciones = Convert.ToInt32(dtDatosCtaCte.Rows[0]["id_usuarios_locacion"]);
                                            oComprobante.Id_Personal = Personal.Id_Login;
                                            oComprobante.Id = oComprobante.Guardar(oComprobante);
                                            if (oComprobante.Id > 0)
                                            {
                                                oCtacteCredito.Id_Usuarios = oComprobante.Id_Usuarios;
                                                oCtacteCredito.Id_Comprobantes = oComprobante.Id;
                                                oCtacteCredito.Fecha_Movimiento = DateTime.Now;
                                                oCtacteCredito.Fecha_Desde = DateTime.Today;
                                                oCtacteCredito.Fecha_Hasta = DateTime.Today;
                                                muestra = "CREDITO A CUENTA " + 0.ToString().PadLeft(4, '0') + "-" + oCtacteCredito.Id_Comprobantes.ToString().PadLeft(8, '0');
                                                oCtacteCredito.Descripcion = muestra;
                                                oCtacteCredito.Importe_Original = oComprobante.Importe;
                                                oCtacteCredito.Importe_Punitorio = 0;
                                                oCtacteCredito.Importe_Bonificacion = 0;
                                                oCtacteCredito.Importe_Final = oComprobante.Importe;
                                                oCtacteCredito.Importe_Saldo = oComprobante.Importe;
                                                oCtacteCredito.Id_Usuarios_Locacion = oComprobante.Id_Usuarios_Locaciones;
                                                oCtacteCredito.Numero = oComprobante.Numero.ToString();
                                                oCtacteCredito.Id_Comprobantes_Tipo = Convert.ToInt32(Comprobantes_Tipo.Tipo.CREDITO_A_CUENTA);
                                                oCtacteCredito.Id_Comprobantes_Ref = oComprobante.Id;
                                                oCtacteCredito.Id_Facturacion = 0;
                                                oCtacteCredito.Generado_facturacion_mensual = Convert.ToInt32(Usuarios_CtaCte.GENERADO_FACTURACION_MENSUAL.NO);
                                                oCtacteCredito.Id_Personal = Personal.Id_Login;
                                                oCtacteCredito.Id_Origen = (int)Usuarios_CtaCte.ORIGEN.PAGOS_EXTERNOS;
                                                if (oCtacteCredito.Guardar(oCtacteCredito) > 0)
                                                {
                                                    Usuarios_CtaCte_Det oDet = new Usuarios_CtaCte_Det();
                                                    oDet.Id_Usuarios_CtaCte = oCtacteCredito.Id;
                                                    oDet.Id_Usuarios_Locaciones = oComprobante.Id_Usuarios_Locaciones;
                                                    oDet.Id_Zonas = 0;
                                                    oDet.Id_Servicios = 0;
                                                    oDet.Id_Tipo = 1;
                                                    oDet.Tipo = "S";
                                                    oDet.Importe_Original = oComprobante.Importe;
                                                    oDet.Importe_Saldo = oComprobante.Importe;
                                                    oDet.Importe_Bonificacion = 0;
                                                    oDet.Importe_Punitorio = 0;
                                                    oDet.Fecha_Desde = DateTime.Now;
                                                    oDet.Fecha_Hasta = DateTime.Now;
                                                    oDet.Id_Usuarios_Servicios = 0;
                                                    oDet.Id_Velocidades = 0;
                                                    oDet.Id_Velocidades_Tip = 0;
                                                    oDet.Requiere_IP = 0;
                                                    oDet.Cantidad_Periodos = 0;
                                                    oDet.Id_bonificacion_Aplicada = 0;
                                                    oDet.Nombre_Bonificacion = String.Empty;
                                                    oDet.Periodo_Ano = oDet.Fecha_Desde.Year;
                                                    oDet.Periodo_Mes = oDet.Fecha_Desde.Month;
                                                    oDet.Porcentaje_Bonificacion = 0;
                                                    oDet.Detalles = " Credito ";
                                                    List<Usuarios_CtaCte_Det> oListaDet = new List<Usuarios_CtaCte_Det>();
                                                    oListaDet.Add(oDet);
                                                    if (oDet.Guardar(oDet) > 0)
                                                    {
                                                        Usuarios_Locaciones.ActualizarSaldo(oComprobante.Id_Usuarios_Locaciones);
                                                        oComprobante_Tipo.SetNumeracion(Convert.ToInt32(drDatosComprobanteCredito["idPuntoVenta"]), Convert.ToInt32(Comprobantes_Tipo.Tipo.CREDITO_A_CUENTA), Convert.ToInt32(drDatosComprobanteCredito["numComprobante"]));
                                                        item.IdComprobante = oCtacteCredito.Id;
                                                        item.IdComprobanteTipo = (int)Comprobantes_Tipo.Tipo.CREDITO_A_CUENTA;
                                                        List<CapaNegocios.PagosExternos.PagoExterno> listaPago = new List<PagoExterno>();
                                                        listaPago.Add(item);
                                                        if (oPagos.AsignarComprobante(listaPago))
                                                        {
                                                            string salidaRelacion = "";
                                                            // guarda la relacion del ctacte del credito a cuenta y el recibo
                                                            oRecibo.GuardarRelacionReciboAjuste(oRecibo.Id, item.IdUsuarioCtaCte, oListaDet, 0, out salidaRelacion);
                                                            if (item.IdPlataforma == (int)CapaNegocios.PagosExternos.PagoExterno.Plataforma.MERCADOPAGO)
                                                            {
                                                                CapaNegocios.PagosExternos.MercadoPagoCh.MPCh oMercadoPagoCH = new CapaNegocios.PagosExternos.MercadoPagoCh.MPCh();
                                                                string salidaMPCH = "";
                                                                if (!oMercadoPagoCH.MarcarDeudaPagada(item.IdPago, out salidaMPCH))
                                                                    MessageBox.Show("Hubo un error al intentar actualizar los datos en MercadoPago.\n El recibo fue generado correctamente pero no se pudo marcar como pagado en la base de datos externa.\n" + salidaMPCH, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
             
                                                            }
                                                        }
                                                        else
                                                            listaErrores.Add(new Error(item.Id, "Error al asignar Crédito a cuenta."));
                                                    }
                                                    else
                                                        listaErrores.Add(new Error(item.Id, "Error al intentar guardar el detalle del Crédito a cuenta."));
                                                }
                                                else
                                                    listaErrores.Add(new Error(item.Id, "Error al intentar guardar el Crédito a cuenta."));
                                            }
                                        }
                                        else
                                            listaErrores.Add(new Error(item.Id, "Ocurrio un error y no se encontraron datos de la deuda, puede ser que la deuda no exista o haya sido eliminada."));
                                    }
                                }
                                catch (Exception salida)
                                {
                                    listaErrores.Add(new Error(item.Id, "Error al generar el Crédito a cuenta. \n " + salida.ToString()));
                                }
                            }
                        }
                    }
                    if (listaErrores.Count > 0)
                    {
                        MessageBox.Show("Hubo errores durante el proceso", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        WriteToXmlFile(@"c:\GIES\error_pago_externos.xml", listaErrores);
                        ComenzarCarga();
                    }
                    else
                    {
                        if (MessageBox.Show("Créditos a cuenta generados correctamente. ¿Desea seguir generando recibos o comprobantes de credito a cuenta?", "Mensaje del Sisema", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No)
                        {
                            Contabilidad.frmRecibosVirtuales frm = new Contabilidad.frmRecibosVirtuales();
                            frmMain.Instance().openForm(frm);
                        }
                        else
                        {
                            ComenzarCarga();
                        }
                    }
                    oConfi.SetValor_N("ReciboVirtualEstado", 0);
                }else
                    oConfi.SetValor_N("ReciboVirtualEstado", 0);
            }
            else
            {
                MessageBox.Show("Otra terminal se encuentra realizando esta operación, por favor intente más tarde.", "Mnesaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                ComenzarCarga();
            }
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {

           
        }

        private void seleccionarRecibosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (selRecibos == false)
            {
                tlvLista.CheckObjects(oListaPagos.Where(x => x.ComprobanteAGenerar.ToLower().Equals("recibo")));
                selRecibos = true;
                seleccionarRecibosToolStripMenuItem.Text = "Deseleccionar recibos";
            }
            else
            {
                tlvLista.UncheckObjects(oListaPagos.Where(x => x.ComprobanteAGenerar.ToLower().Equals("recibo")));
                selRecibos = false;
                seleccionarRecibosToolStripMenuItem.Text = "Seleccionar recibos";

            }

        }

        private void btnExportar_Click(object sender, EventArgs e)
        {

        }

        private void txtBuscador_TextChanged(object sender, EventArgs e)
        {
            //if(txtBuscador.Text.Trim().Length > 0)
            //{
            //    TextMatchFilter filter = TextMatchFilter.Contains(this.tlvLista, txtBuscador.Text);
            //    this.tlvLista.ModelFilter = filter;
            //    this.tlvLista.DefaultRenderer = new HighlightTextRenderer(filter);
            //}
        }

        private void tlvLista_FormatCell(object sender, FormatCellEventArgs e)
        {
            PagoExterno p = (PagoExterno)e.Model;

            // Put a love heart next to Nicola's name :)
           
        }

        private void btnGeneraRecibosX_Click(object sender, EventArgs e)
        {
            var checkedObjects = tlvLista.CheckedObjects;
            List<CapaNegocios.PagosExternos.PagoExterno> oListaSeleccionados = new List<PagoExterno>(); ;
            foreach (PagoExterno itemSeleccionado in checkedObjects)
                oListaSeleccionados.Add(itemSeleccionado);

            var cantReciboXSel = oListaSeleccionados.Where(x => x.ComprobanteAGenerar.ToLower().Contains("x")).ToList().Count;

            if (cantReciboXSel > 0)
            {
                SetearBotones(false);
                GenerarRecibosX();
            }
            else
            {
                MessageBox.Show("No seleccionó ningun pago que corresponda con recibos x.", "Mensaje del Sistema",MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void seleccionarTodoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (selTodo == false)
            {
                this.tlvLista.CheckAll();

                selTodo = true;
                seleccionarTodoToolStripMenuItem.Text = "Deseleccionar todo";

                selCredito = true;
                seleccionarCreditosACuentaToolStripMenuItem.Text = "Deseleccionar Creditos a cuenta";
                
                selRecibos = true;
                seleccionarRecibosToolStripMenuItem.Text = "Deseleccionar recibo";

                selRecibosX = true;
                seleccionarRecibosXToolStripMenuItem.Text = "Deseleccionar recibo X";

            }
            else
            {
                this.tlvLista.UncheckAll();

                selTodo = false;
                seleccionarTodoToolStripMenuItem.Text = "Seleccionar todo";

                selCredito = false;
                seleccionarCreditosACuentaToolStripMenuItem.Text = "Seleccionar Creditos a cuenta";

                selRecibos = false;
                seleccionarRecibosToolStripMenuItem.Text = "Seleccionar recibo";

                selRecibosX = false;
                seleccionarRecibosXToolStripMenuItem.Text = "Seleccionar recibo X";
            }
        }

        private void seleccionarRecibosXToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (selRecibosX == false)
            {
                tlvLista.CheckObjects(oListaPagos.Where(x => x.ComprobanteAGenerar.ToLower().Equals("recibo x")));
                selRecibosX = true;
                seleccionarRecibosXToolStripMenuItem.Text = "Deseleccionar recibos x";

            }
            else
            {
                tlvLista.UncheckObjects(oListaPagos.Where(x => x.ComprobanteAGenerar.ToLower().Equals("recibo x")));
                selRecibosX = false;
                seleccionarRecibosXToolStripMenuItem.Text = "Seleccionar recibos x";

            }

        }

        private void seleccionarCreditosACuentaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (selCredito == false)
            {
                tlvLista.CheckObjects(oListaPagos.Where(x => x.ComprobanteAGenerar.ToLower().Equals("recibo y credito a cuenta")));
                selCredito = true;
                seleccionarCreditosACuentaToolStripMenuItem.Text = "Deseleccionar creditos a cuenta";

            }
            else
            {
                tlvLista.UncheckObjects(oListaPagos.Where(x => x.ComprobanteAGenerar.ToLower().Equals("recibo y credito a cuenta")));
                selCredito = false;
                seleccionarCreditosACuentaToolStripMenuItem.Text = "Seleccionar creditos a cuenta";

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnGenerarFac_Click(object sender, EventArgs e)
        {
            SetearBotones(false);
            int idUsuario, idComprobante, idLocacion, altura;
            string calle;
            string localidad, piso, codigoPostal, depto, mensajeSalida;
            Usuarios_Dom_Fiscal oUsuLocFiscal = new Usuarios_Dom_Fiscal();
            Facturacion oFacturacion = new Facturacion();
            DataTable dtSalidasCae = new DataTable();
            Comprobantes oComprobantes = new Comprobantes();
            var checkedObjects = tlvLista.CheckedObjects;

            List<CapaNegocios.PagosExternos.PagoExterno> oListaSeleccionados = new List<PagoExterno>(); ;
            foreach (PagoExterno itemSeleccionado in checkedObjects)
                oListaSeleccionados.Add(itemSeleccionado);

            foreach (CapaNegocios.PagosExternos.PagoExterno item2 in oListaSeleccionados)
            {
                DataRow dr = oCtacte.getDatosCtaCte(0, item2.IdUsuarioCtaCte);
                if (Convert.ToInt32(dr["id_comprobantes_tipo"]) == (int)Comprobantes_Tipo.Tipo.COMPROBANTE_DEUDA && !item2.ComprobanteAGenerar.ToLower().Contains('x'))
                {
                    //crea un recibo
                    dtLocaciones = oUsuloc.ListarLocacionesServicio(item2.IdUsuario);
                    dtModelo = oCtacte.LlenarDtModelo(dtLocaciones, "C", Convert.ToInt32(dr["id_comprobantes"]),0);

                    DataView dvCtacte = dtModelo.DefaultView;
                    dvCtacte.RowFilter = $"id_usuarios_ctacte={item2.IdUsuarioCtaCte}";
                    DataTable dtCta = dvCtacte.ToTable();

                    if (dtCta.Rows.Count > 0)
                    {
                        idUsuario = item2.IdUsuario;
                        idLocacion = Convert.ToInt32(dtCta.Rows[0]["id_usuarios_locaciones"]);
                        idComprobante = Convert.ToInt32(dtCta.Rows[0]["id_comprobantes"]);
                        oUsuloc = oUsuloc.GetLocacion(idLocacion);
                        localidad = oUsuloc.Localidad;
                        calle = oUsuloc.Calle;
                        altura = oUsuloc.Altura;
                        piso = oUsuloc.Piso;
                        codigoPostal = oUsuloc.Codigo_Postal;
                        depto = oUsuloc.Depto;

                        Usuarios.CurrentUsuario.Id = idUsuario;
                        Usuarios.Current_IdUsuario = idUsuario;
                        Usuarios oUsu = new Usuarios();
                        oUsu.LlenarObjeto(idUsuario);
                        Usuarios.CurrentUsuario.localidad = localidad;
                        Usuarios.CurrentUsuario.Calle = calle;
                        Usuarios.CurrentUsuario.piso = piso;
                        Usuarios.CurrentUsuario.Altura = altura;
                        Usuarios.CurrentUsuario.Cod_postal = codigoPostal;
                        Usuarios.CurrentUsuario.Depto = depto;

                        Usuarios.CurrentUsuarioDomFiscal = oUsuLocFiscal.LlenarDatosLocFiscal(idLocacion);
                        dtLocaciones = oUsuLoc.ListarLocacionesDeServicio(idUsuario);
                        DataTable dtCtaCteDetfinal = oCtacte.LlenarDtModelo(dtLocaciones, "C", idComprobante);
                        bool calcularPercepcion = false;
                        foreach (DataRow Dr in dtCtaCteDetfinal.Rows)
                        {
                            Dr["elige"] = true;
                            Dr["importe_pago"] = 1;
                            Dr["importe_total"] = Convert.ToDecimal(Dr["importe_saldo"].ToString());
                            Dr["importe_saldo"] = Convert.ToDecimal(Dr["importe_saldo"].ToString()) - Convert.ToDecimal(Dr["importe_bonificacion"].ToString());
                        }
                        Punitorio oPunitorio = new Punitorio();
                        DataTable dtCtaCteDet = oDet.ListarCtacteDetConSaldo(bonificacion: false, idUsuarioLocacion: idLocacion);
                        DataTable dtResultados = new DataTable();
                        if (dtResultados.Columns.Count == 0)
                        {
                            dtResultados.Columns.Add("idComprobante", typeof(Int32));
                            dtResultados.Columns.Add("idError", typeof(Int32));
                            dtResultados.Columns.Add("usuario", typeof(string));
                            dtResultados.Columns.Add("descripcion", typeof(string));

                        }
                        oPunitorio.RecalcularPunitorio(dtCtaCteDet, item2.IdUsuarioCtaCte, bonificar: false, item2.FechaPago);
                        dtCtaCteDetfinal = oCtacte.LlenarDtModelo(dtLocaciones, "C", idComprobante);
                        foreach (DataRow Dr in dtCtaCteDetfinal.Rows)
                        {
                            Dr["elige"] = true;
                            Dr["importe_pago"] = 1;
                            Dr["importe_total"] = Convert.ToDecimal(Dr["importe_saldo"].ToString());
                            Dr["importe_saldo"] = Convert.ToDecimal(Dr["importe_saldo"].ToString()) - Convert.ToDecimal(Dr["importe_bonificacion"].ToString());
                        }
                        dtSalidasCae.Clear();
                        dtSalidasCae = oFacturacion.Comprobante_a_Factura(oFacturacion, dtCtaCteDetfinal, idLocacion, Personal.Id_Punto_Venta, permitirHacerRemito: false, facturaDeCredito: false);
                        codigoRetorno = Convert.ToInt16(dtSalidasCae.Rows[dtSalidasCae.Rows.Count - 1]["respuesta_codigo"]);

                        if (codigoRetorno != 0)
                        {
                            DataRow dr2 = dtResultados.NewRow();
                            dr2["idComprobante"] = idComprobante;
                            dr2["idError"] = codigoRetorno;
                            dr2["descripcion"] = dtSalidasCae.Rows[dtSalidasCae.Rows.Count - 1]["respuesta_descripcion"].ToString();
                            //dr["importe_original"] = Convert.ToDecimal(item["importe_original"]);
                            //dr["importe_bonificacion"] = Convert.ToDecimal(item["importe_bonificacion"]);
                            //dr["importe_final"] = Convert.ToDecimal(item["importe_final"]);
                            //mensajeSalida = dtSalidasCae.Rows[0]["respuesta_descripcion"].ToString();
                            //dr2["mensaje"] = mensajeSalida;
                            dtResultados.Rows.Add(dr2);
                        }
                        else
                        {
                            mensajeSalida = "APROBADO";
                        }
                    }

                }
            }
            ComenzarCarga();
            // ----------------------------- FIN CONVIERTE A FACTURA
        }

        private void cboPlataforma_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cargado)
                IdPlataformaSeleccionada = Convert.ToInt32(cboPlataforma.SelectedValue);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            ComenzarCarga();
        }

        private void tlvLista_FormatRow(object sender, BrightIdeasSoftware.FormatRowEventArgs e)
        {
            PagoExterno customer = (PagoExterno)e.Model;
            if (customer.ImportePago == 0)
            {
                e.Item.BackColor = Color.Tomato;
            }
            else if (customer.ImportePago == customer.ImporteSaldo)
            {
                if(customer.Pagado==true)
                    e.Item.BackColor = Color.YellowGreen;
                else
                {
                    if (customer.ComprobanteAGenerar.Contains("X"))
                    {
                        e.Item.BackColor = Color.DarkSlateGray;
                        e.Item.ForeColor = Color.White;

                    }
                    else
                    {
                        e.Item.BackColor = Color.DarkGreen;
                        e.Item.ForeColor = Color.White;
                    }
                }

            }
            else
                e.Item.BackColor = Color.Orange;

           


        }

        private void btnGenerarRecibos_Click(object sender, EventArgs e)
        {
            var checkedObjects = tlvLista.CheckedObjects;
            foreach (PagoExterno itemSeleccionado in checkedObjects)
                oListaSeleccionados.Add(itemSeleccionado);
            var cantReciboSel = oListaSeleccionados.Where(x => x.ComprobanteAGenerar.ToLower().Equals("recibo") && x.DescripcionUCC.ToLower().Contains("factura")).ToList().Count;

            if (cantReciboSel > 0)
            {
                SetearBotones(false);
                GenerarRecibos();
            }
            else
            {
                MessageBox.Show("No seleccionó ningun pago que corresponda con recibos.", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public static void WriteToXmlFile<Error>(string filePath, Error objectToWrite, bool append = false)
        {
            TextWriter writer = null;
            try
            {
                var serializer = new XmlSerializer(typeof(Error));
                writer = new StreamWriter(filePath, append);
                serializer.Serialize(writer, objectToWrite);
            }
            finally
            {
                if (writer != null)
                    writer.Close();
            }
        }


        private void frmPagosGuardados_Load(object sender, EventArgs e)
        {
            dtPlataformas = Tablas.DataPlataformasPagos;
            cboPlataforma.DataSource = dtPlataformas;
            cboPlataforma.ValueMember = "id";
            cboPlataforma.DisplayMember = "nombre";

            cargado = true;
        }

        
    }

    public class Error
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }

        public Error(int id, string descripcion)
        {
            this.Id = id;
            this.Descripcion = descripcion;
        }
        public Error()
        {

        }
    }
}
