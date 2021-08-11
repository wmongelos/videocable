using CapaNegocios;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace CapaPresentacion.Complementarias
{
    public partial class frmComplementarias : Form
    {
        //IDEA: existen diferentes tipos de operaciones las cuales estan enumeradas (con un numero) para identificarlas y diferenciarlas (en el siguiente apartado estan las referencias). Cada operacion puede tener subOperaciones las cuales tambien estan identificadas con un numero.
        //las operaciones en primera instancia se agregar a un datatable interno ('dtinterna') con sus detalles.
        //el datatable 'dtvista' refleja un resumen por operacion ordenado del 'dtinterna', el metodo 'PasarDatatable' se encarga de pasar de 'dtInterna' a 'dtVista'
        //existen formularios auxiliares ligados a este formulario

        #region REFERENCIAS

        //1->Agregar/Quitar Subservicios --> SubTipos 1=Agregar 2=Quitar
        //2->Solicitar Equipo
        //3->Cambio Tarjeta
        //4->Cambio de Velocidad
        //5->Agregar/Quitar IP fija --> SubTipos 1=Unica vez 2=Todos los meses 3=QUITAR ip
        //6->Novedades
        //7->Cambio Unidades Fucionales --> SubTipos 1=AGREGAR BOCAS COMUNES - 2=AGREGAR BOCAS PACTADAS - 3=QUITAR BOCAS COMUNES - 4=QUITAR UNIDADES PACTADAS
        //8->Servicios Extras
        //9->Prepago
        //10->CambioMeses
        #endregion

        #region PROPIEDADES
        private Thread hilo;
        private delegate void myDel();
        //Datatables
        private DataTable dtInterna = new DataTable();
        private DataTable dtVista = new DataTable();
        private DataTable datosUsuariosServicios = new DataTable();
        private DataTable datosUsuariosServiciosSub = new DataTable();
        private DataTable datosServicios = new DataTable();
        private DataTable datosServiciosSub = new DataTable();
        private DataTable datosFallas = new DataTable();
        public DataTable dtServicio = new DataTable();
        private DataTable dataSubservicios = new DataTable();
        private DataTable dataEquiposPosibles = new DataTable();
        private DataTable dataEquipoAsigando = new DataTable();
        private DataTable dtProratear = new DataTable();
        private DataTable dtTarifasEspeciales = new DataTable();
        private DataTable dtEspeciales = new DataTable();
        private DataTable dtCategorias = new DataTable();
        private DataTable dtSubServiciosContratados = new DataTable();

        //Objetos
        private Usuarios_Servicios oUsuariosServicios = new Usuarios_Servicios();
        private Servicios oServicios = new Servicios();
        private Servicios_Sub oServiciosSub = new Servicios_Sub();
        private Servicios_Tarifas oServiciosTarifas = new Servicios_Tarifas();
        private Servicios_Tarifas_Sub oServiciosTarifasSub = new Servicios_Tarifas_Sub();
        private Servicios_Tarifas_Sub_Esp oServiciosTarifasSubEsp = new Servicios_Tarifas_Sub_Esp();
        private Servicios_Velocidades oServiciosVelocidades = new Servicios_Velocidades();
        private Servicios_Ip_Fijas oServiciosIpFija = new Servicios_Ip_Fijas();
        private Configuracion oConfiguracion = new Configuracion();
        private Comprobantes oComprobantes = new Comprobantes();
        private Comprobantes_Tipo oComprobatesTipos = new Comprobantes_Tipo();
        private Usuarios_CtaCte oUsuariosCuentasCorrientes = new Usuarios_CtaCte();
        private Usuarios_CtaCte_Det oUsuariosCuentaCorrienteDet = new Usuarios_CtaCte_Det();
        private Partes_Solicitudes oPartesFallas = new Partes_Solicitudes();
        private Partes oPartes = new Partes();
        private Partes_Historial oPartesHistorial = new Partes_Historial();
        private Usuarios oUsuarios = new Usuarios();
        private Equipos oEqiopos = new Equipos();

        //Variables int
        private int subId = 1, idUsuariosServicios, idServicio, idUsuario, idUsuariosLocaciones, idTarifa, idFormaFacturacion, idTipoFacturacion, idVelocidad, idVelocidadTipo, idTipoOperacion, idTipoSubOperacion, forzarInicioMes;
        private int idTipoServicio, mesesCobro = 0, mesesServicio, idTipoSub, idServicioSub, cantBocasActual, cantBocasComunNueva, cantBocasPacActual, cantBocasPacNueva, cantBocasComunesMenos, oCantidad, idIp, idFalla;
        private int idUsuariosCtacte, numeroComprobante, cantidadSubservicios, requiereIp = 0, idServicioSubTipo, idUsuariosServiciosSub, requiereIpNoVariable = 0, idParte, idZona, idModalidad;
        private int prorrateaHastaDias = 0;
        //Variables decimal
        private decimal precioTarifa, precioTotal, precioTarifaSub, precioTarifaConfiguraion, tarifaActual, precioTodo = 0, montoSaldoActual;
        //Variables bool
        public Boolean huboCambios = false;
        //DataRows
        private DataRow drDatosComprobanteVenta = null;
        private DataRow[] drColeccionRows;
        private DataRow[] drCambioVelocidad;
        private DataRow[] drComplementarias;
        private DataRow[] drIpFija;
        private DataRow[] drSubEliminados;
        private DataRow[] drSubAgregados;

        //Datetime
        private DateTime fechaHasta;
        private DateTime fechaDesde;
        private DateTime fechaHoy = DateTime.Now;
        private DateTime fechaInicio;
        private DateTime periodoDesde;
        private DateTime periodoHasta;
        private DateTime fechaFinCobro;
        private DateTime fechaFactura;
        private DateTime fechaDesdeGlobal;

        //Variables string
        private string requiereEquipo = "", itemDescripcion, nombreSubServicio, requiereVel, nombreServicio, nombreVelocidadActual, requiereTarjeta, nobreSubservicio;
        //Columnas
        private DataGridViewLinkColumn columnaLink = new DataGridViewLinkColumn();
        private DataGridViewLinkColumn columnaLinkModif = new DataGridViewLinkColumn();
        //Formularios
        private frmPopUp oPop;
        private frmCambioVelocidad oCambioVelocidad;
        private frmUnidadesFuncionales oFrmUnidadesFuncionales;
        private frmCambioImporte oFrmCambioImporte;
        private frmAgregarQuitarSub oFrmAgregarQuitarSub;
        private Abms.ABMIpfijas ofrmABMIpFijas;
        private Partes_Trabajo.frmGenerarParte oFrmGenerarParte;
        private Form frmFecha;
        private frmSeleccionarEquipo oFrmSeleccionarEquipo;

        //PROPIEDADES PARA EL CASS
        DataTable dtAplicacionesFiltradas = Tablas.DataCass;
        Cass oCass;

        #endregion

        #region METODOS CONTROLES
        private void frmComplementarias_Load(object sender, EventArgs e)
        {
            AgregarColumnas();
            ComenzarCarga();

        }

        private void lbSolicitaEquipo_Click(object sender, EventArgs e)
        {
            
        }

        private void btAceptarFecha_Click(object sender, EventArgs e)
        {
            fechaDesde = dpFechaDesde.Value;
            fechaDesdeGlobal = dpFechaDesde.Value; ;
            if (forzarInicioMes == 1)
            {
                if (fechaDesde.Day != 1)
                    MessageBox.Show("Este servicio requiere que la fecha sea del comienzo del mes", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                else
                {
                    DateTime fehcaAuxHoy = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                    if (fehcaAuxHoy > fechaDesde)
                        MessageBox.Show("La fecha no puede ser anterior a la de hoy", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    else
                    {
                        pnFechaDesde.Visible = false;
                        frmFecha.DialogResult = DialogResult.OK;
                    }
                }
            }
            else
            {
                pnFechaDesde.Visible = false;
                frmFecha.DialogResult = DialogResult.OK;
            }
        }

        public frmComplementarias(int idUsuariosServicios, decimal montoSaldo)
        {
            InitializeComponent();
            this.idUsuariosServicios = idUsuariosServicios;
            this.montoSaldoActual = montoSaldo;

        }

        private void lblAgregarQuitarIP_Click(object sender, EventArgs e)
        {

        }

        private void lblCambioUnidadesFuncionales_Click(object sender, EventArgs e)
        {
            ComenzarCarga();

            drComplementarias = dtVista.Select("Tipo=4");
            if (drComplementarias.Length > 0)
                MessageBox.Show("Actualmente existe un cambio de velocidad pendiente por realizar", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else
            {
                drComplementarias = dtVista.Select("Tipo=7");
                if (drComplementarias.Length > 0)
                    MessageBox.Show("Actualemte existen cambios en la cantidad de bocas, guarde los cambios para continuar", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                else
                {
                    drComplementarias = dtVista.Select("Tipo=1");
                    if (drComplementarias.Length > 0)
                        MessageBox.Show("Actualemte existen cambios en la cantidad de servicios, guarde los cambios para continuar", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    else
                    {
                        if (SeleccionarFecha() == 1)
                        {
                            UnidadesFuncionales();
                        }
                    }
                }
            }
        }

        private void lblNovedades_Click(object sender, EventArgs e)
        {
            Cuenta_Corriente.frmUsuariosCtaCteNovedades oFrmNovedades = new Cuenta_Corriente.frmUsuariosCtaCteNovedades();
            oPop = new frmPopUp();
            oPop.Formulario = oFrmNovedades;
            oFrmNovedades.StartPosition = FormStartPosition.CenterScreen;
            oPop.ShowDialog();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {

        }

        private void backgroundWorker1_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
        }

        private void lblExtra_Click(object sender, EventArgs e)
        {
            oPop = new frmPopUp();
            frmExtras ofrmExtras = new frmExtras();
            oPop.Formulario = ofrmExtras;
            oPop.Maximizar = false;
            if (oPop.ShowDialog() == DialogResult.OK)
            {
                decimal importeExtra = ofrmExtras.importe;
                string detalleExtra = ofrmExtras.detalle;
                DataRow drExtra = dtInterna.NewRow();
                subId++;
                drExtra["subId"] = subId;
                drExtra["Tipo"] = 8;
                drExtra["SubTipo"] = 0;
                drExtra["Id_Sub"] = 0;
                drExtra["Nombre_Sub"] = detalleExtra;
                drExtra["Tarifa"] = importeExtra;
                drExtra["Id_Velocidad"] = 0;
                drExtra["Id_Velocidad_Tipo"] = 0;
                drExtra["NumBoca"] = 0;
                drExtra["Id_Tipo_Sub"] = 0;
                drExtra["TarifaProrrateada"] = importeExtra;
                drExtra["desde"] = DateTime.Now;
                drExtra["hasta"] = DateTime.Now;

                dtInterna.Rows.Add(drExtra);
                PasarDatatable();
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("Proceso terminado");
        }

        private void pnlMenu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pnlInferior_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblCambioMeses_Click(object sender, EventArgs e)
        {
          
        }

        private void preabrirListado(int operacionSubServicio =0)
        {
            //LA OPERACION EN 1 ES PORQUE AGREGA SUB SERVICIO Y EN 2 ES PORQUE LO QUITA.
            drComplementarias = dtVista.Select("Tipo=7");
            if (drComplementarias.Length > 0)
                MessageBox.Show("Actualemte existen cambios en la cantidad de bocas, guarde los cambios para continuar", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else
            {
               if (SeleccionarFecha() == 1)
               {
                   abrirListado(operacionSubServicio);
               }
            }
        }
        private void abrirListado(int operacionSubServicio)
        {
            oPop = new frmPopUp();
            oFrmAgregarQuitarSub = new frmAgregarQuitarSub();
            if (operacionSubServicio > 0)
                oFrmAgregarQuitarSub.tipoOperacionSubServicio = operacionSubServicio;
            else
                oFrmAgregarQuitarSub.tipoOperacionSubServicio = 1;
            oFrmAgregarQuitarSub.fechaDesde = this.dpFechaDesde.Value;
            oFrmAgregarQuitarSub.fechaFactura = this.fechaFactura;
            oFrmAgregarQuitarSub.idUsuariosServicios = idUsuariosServicios;
            oFrmAgregarQuitarSub.idServicio = idServicio;
            oFrmAgregarQuitarSub.idTipoFacturacion = idTipoFacturacion;
            oFrmAgregarQuitarSub.idTipoServicio = idTipoServicio;
            oServiciosTarifas.Fecha_Actual = fechaDesde;
            oFrmAgregarQuitarSub.idModalidad = this.idModalidad;
            idTarifa = oServiciosTarifas.getTarifa();
            oFrmAgregarQuitarSub.idTarifaVigente = idTarifa;
            oFrmAgregarQuitarSub.requierVelocidad = requiereVel;
            oPop.Maximizar = false;
            oPop.Formulario = oFrmAgregarQuitarSub;
            if (oPop.ShowDialog() == DialogResult.OK)
            {
                try
                {

                    drSubEliminados = oFrmAgregarQuitarSub.drEliminados;
                    drSubAgregados = oFrmAgregarQuitarSub.drAgregados;
                    subId++;
                    foreach (DataRow item in drSubEliminados)
                    {
                        String nombreItem = string.Format("Quita de Subservicio ({0})", item["Nombre"].ToString());
                        idServicioSub = Convert.ToInt32(item["UsuarioServicioId"]);
                        DataRow dr = dtInterna.NewRow();
                        dr["subId"] = subId;
                        dr["Tipo"] = 1;
                        dr["SubTipo"] = 2;
                        dr["Id_Sub"] = idServicioSub;
                        dr["Nombre_Sub"] = nombreItem;
                        dr["Tarifa"] = 0;
                        dr["Id_Velocidad"] = 0;
                        dr["Id_Velocidad_Tipo"] = 0;
                        dr["NumBoca"] = 0;
                        dr["Id_Tipo_Sub"] = 0;
                        dr["TarifaProrrateada"] = 0;
                        dtInterna.Rows.Add(dr);
                        PasarDatatable();
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Hubo un error durante el proceso: QUITAR SUBSERVICIO ", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    throw;
                }
                foreach (DataRow item in drSubAgregados)
                {

                    DateTime fechaHastaSeleccionada = Convert.ToDateTime(item["fechaHasta"]);

                    switch (idModalidad)
                    {
                        case 2:
                            try
                            {

                                fechaHasta = Convert.ToDateTime(datosUsuariosServicios.Rows[0]["fecha_factura"]);
                                fechaInicio = dpFechaDesde.Value;
                                DateTime fecha = fechaInicio;
                                DateTime fechaDesdeAux = fechaDesde;
                                if (fechaHasta != fechaHastaSeleccionada)
                                {
                                    while (fecha <= fechaHastaSeleccionada)
                                    {

                                        DataRow drDatosSub;
                                        String nombreItem = string.Format("Adicion de Subservicio ({0})", item["Nombre"].ToString());
                                        idServicioSub = Convert.ToInt32(item["id"]);
                                        drDatosSub = oServiciosSub.TraerDatosSubServicio(idServicioSub);
                                        idTipoSub = Convert.ToInt32(drDatosSub["Id_servicios_sub_tipos"]);
                                        oServiciosTarifas.Fecha_Actual = fecha;
                                        idTarifa = oServiciosTarifas.getTarifa();
                                        precioTarifa = oServiciosTarifasSub.getPrecio(idTarifa, idServicio, idServicioSub, "S", idTipoFacturacion);
                                        periodoDesde = fecha;
                                        int cantDias = 0;
                                        if ((fecha.Year == fechaHastaSeleccionada.Year) && (fecha.Month == fechaHastaSeleccionada.Month))
                                            cantDias = fechaHastaSeleccionada.Day;
                                        else
                                            cantDias = DateTime.DaysInMonth(fecha.Year, fecha.Month);
                                        periodoHasta = new DateTime(fecha.Year, fecha.Month, cantDias);

                                        DataRow dr = dtInterna.NewRow();
                                        dr["subId"] = subId;
                                        dr["Desde"] = periodoDesde;
                                        dr["Hasta"] = periodoHasta;
                                        dr["Tipo"] = 1;
                                        dr["SubTipo"] = 1;
                                        dr["Id_Sub"] = idServicioSub;
                                        dr["Nombre_Sub"] = nombreItem;
                                        dr["Id_Velocidad"] = 0;
                                        dr["Id_Velocidad_Tipo"] = 0;
                                        dr["NumBoca"] = 0;
                                        dr["Id_Tipo_Sub"] = idTipoSub;
                                        dr["Tarifa"] = precioTarifa;
                                        dr["Id_Ip"] = 0;

                                        fechaDesde = fecha;
                                        DateTime fechaHastaAuxiliar = fechaHasta;
                                        DateTime fechaDesdeAuxiliar = fechaDesde;
                                        decimal tarifaProrrateada = 0;
                                        if (idTipoSub != 4)
                                        {
                                            if (fechaDesde.Day != 1)
                                            {
                                                tarifaProrrateada = ProratearMes(precioTarifa);
                                                dr["TarifaProrrateada"] = tarifaProrrateada;
                                                fecha = new DateTime(fechaDesde.Year, fechaDesde.Month, 1);
                                            }
                                            else
                                                dr["TarifaProrrateada"] = precioTarifa;
                                            if ((fecha.Year == fechaHastaSeleccionada.Year) && (fecha.Month == fechaHastaSeleccionada.Month))
                                            {
                                                prorrateaHastaDias = cantDias;
                                                tarifaProrrateada = ProrratearHastaDiaX(precioTarifa, fechaHastaSeleccionada.Year, fechaHastaSeleccionada.Month, prorrateaHastaDias);
                                                dr["TarifaProrrateada"] = tarifaProrrateada;

                                            }
                                        }
                                        else
                                            dr["TarifaProrrateada"] = precioTarifa;

                                        dtInterna.Rows.Add(dr);
                                        tarifaProrrateada = 0;
                                        fecha = fecha.AddMonths(1);
                                    }

                                }
                                else
                                {

                                    while (fecha <= fechaHasta)
                                    {

                                        DataRow drDatosSub;
                                        String nombreItem = string.Format("Adicion de Subservicio ({0})", item["Nombre"].ToString());
                                        idServicioSub = Convert.ToInt32(item["id"]);
                                        drDatosSub = oServiciosSub.TraerDatosSubServicio(idServicioSub);
                                        idTipoSub = Convert.ToInt32(drDatosSub["Id_servicios_sub_tipos"]);
                                        oServiciosTarifas.Fecha_Actual = fecha;
                                        idTarifa = oServiciosTarifas.getTarifa();
                                        precioTarifa = oServiciosTarifasSub.getPrecio(idTarifa, idServicio, idServicioSub, "S", idTipoFacturacion);
                                        periodoDesde = fecha;
                                        int cantDias = DateTime.DaysInMonth(fecha.Year, fecha.Month);
                                        periodoHasta = new DateTime(fecha.Year, fecha.Month, cantDias);

                                        DataRow dr = dtInterna.NewRow();
                                        dr["subId"] = subId;
                                        dr["Desde"] = periodoDesde;
                                        dr["Hasta"] = periodoHasta;
                                        dr["Tipo"] = 1;
                                        dr["SubTipo"] = 1;
                                        dr["Id_Sub"] = idServicioSub;
                                        dr["Nombre_Sub"] = nombreItem;
                                        dr["Id_Velocidad"] = 0;
                                        dr["Id_Velocidad_Tipo"] = 0;
                                        dr["NumBoca"] = 0;
                                        dr["Id_Tipo_Sub"] = idTipoSub;
                                        dr["Tarifa"] = precioTarifa;
                                        dr["Id_Ip"] = 0;

                                        fechaDesde = fecha;
                                        DateTime fechaHastaAuxiliar = fechaHasta;
                                        DateTime fechaDesdeAuxiliar = fechaDesde;
                                        decimal tarifaProrrateada = 0;
                                        if (idTipoSub != 4)
                                        {
                                            if (fechaDesde.Day != 1)
                                            {
                                                tarifaProrrateada = ProratearMes(precioTarifa);
                                                dr["TarifaProrrateada"] = tarifaProrrateada;
                                                fecha = new DateTime(fechaDesde.Year, fechaDesde.Month, 1);
                                            }
                                            else
                                                dr["TarifaProrrateada"] = precioTarifa;
                                        }
                                        else
                                            dr["TarifaProrrateada"] = precioTarifa;

                                        dtInterna.Rows.Add(dr);
                                        tarifaProrrateada = 0;
                                        fecha = fecha.AddMonths(1);
                                    }
                                }
                                subId++;
                            }
                            catch (Exception)
                            {
                                MessageBox.Show("Hubo un error durante el proceso: AGREGAR SUBSERVICIO MODALIDAD: POR MES", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            break;
                        case 3:
                            try
                            {
                                int mesesServicio = 0;
                                DataTable dtEspeciales = new DataTable();
                                dtEspeciales = oServiciosTarifasSubEsp.GetServicios_Tarifas_Sub_Esp(idTarifa, idServicio, idTipoFacturacion);
                                DataRow[] datosSubservicioEsp = dtEspeciales.Select("tiposub='S' and idtipodesub=1");
                                mesesServicio = Convert.ToInt32(datosSubservicioEsp[0]["meses_servicio"]);
                                mesesCobro = Convert.ToInt32(datosSubservicioEsp[0]["meses_cobro"]);
                                fechaDesde = dpFechaDesde.Value;
                                DateTime fechaDesdeAux = dpFechaDesde.Value;
                                //meses a facturar
                                fechaDesde = dpFechaDesde.Value;
                                DateTime fechaHastaAuxiliarPeriodo = fechaHasta;
                                int r = 1;
                                fechaHasta = Convert.ToDateTime(datosUsuariosServicios.Rows[0]["fecha_factura"]);
                                fechaInicio = dpFechaDesde.Value;
                                DateTime fechaPeriodo = fechaInicio;

                                if (fechaHasta >= fechaHastaSeleccionada)
                                {
                                    while ((r <= mesesCobro) && (fechaPeriodo <= fechaHastaSeleccionada))
                                    {

                                        DataRow drDatosSub;
                                        String nombreItem = string.Format("Adicion de Subservicio ({0})", item["Nombre"].ToString());
                                        idServicioSub = Convert.ToInt32(item["id"]);
                                        drDatosSub = oServiciosSub.TraerDatosSubServicio(idServicioSub);
                                        idTipoSub = Convert.ToInt32(drDatosSub["Id_servicios_sub_tipos"]);
                                        oServiciosTarifas.Fecha_Actual = fechaPeriodo;
                                        idTarifa = oServiciosTarifas.getTarifa();
                                        precioTarifa = oServiciosTarifasSub.getPrecio(idTarifa, idServicio, idServicioSub, "S", idTipoFacturacion);
                                        periodoDesde = fechaPeriodo;
                                        int cantDias = DateTime.DaysInMonth(fechaPeriodo.Year, fechaPeriodo.Month);
                                        periodoHasta = new DateTime(fechaPeriodo.Year, fechaPeriodo.Month, cantDias);

                                        DataRow dr = dtInterna.NewRow();
                                        dr["subId"] = subId;
                                        dr["Desde"] = periodoDesde;
                                        dr["Hasta"] = periodoHasta;
                                        dr["Tipo"] = 1;
                                        dr["SubTipo"] = 1;
                                        dr["Id_Sub"] = idServicioSub;
                                        dr["Nombre_Sub"] = nombreItem;
                                        dr["Id_Velocidad"] = 0;
                                        dr["Id_Velocidad_Tipo"] = 0;
                                        dr["NumBoca"] = 0;
                                        dr["Id_Tipo_Sub"] = idTipoSub;
                                        dr["Tarifa"] = precioTarifa;
                                        dr["Id_Ip"] = 0;

                                        fechaDesde = fechaPeriodo;
                                        DateTime fechaDesdeAuxiliar = fechaDesde;
                                        dr["TarifaProrrateada"] = precioTarifa;
                                        dtInterna.Rows.Add(dr);
                                        fechaFinCobro = fechaPeriodo;
                                        fechaPeriodo = fechaPeriodo.AddMonths(1);
                                        r++;
                                    }
                                }
                                else
                                {
                                    while ((r <= mesesCobro) && (fechaPeriodo <= fechaHasta))
                                    {

                                        DataRow drDatosSub;
                                        String nombreItem = string.Format("Adicion de Subservicio ({0})", item["Nombre"].ToString());
                                        idServicioSub = Convert.ToInt32(item["id"]);
                                        drDatosSub = oServiciosSub.TraerDatosSubServicio(idServicioSub);
                                        idTipoSub = Convert.ToInt32(drDatosSub["Id_servicios_sub_tipos"]);
                                        oServiciosTarifas.Fecha_Actual = fechaPeriodo;
                                        idTarifa = oServiciosTarifas.getTarifa();
                                        precioTarifa = oServiciosTarifasSub.getPrecio(idTarifa, idServicio, idServicioSub, "S", idTipoFacturacion);
                                        periodoDesde = fechaPeriodo;
                                        int cantDias = DateTime.DaysInMonth(fechaPeriodo.Year, fechaPeriodo.Month);
                                        periodoHasta = new DateTime(fechaPeriodo.Year, fechaPeriodo.Month, cantDias);

                                        DataRow dr = dtInterna.NewRow();
                                        dr["subId"] = subId;
                                        dr["Desde"] = periodoDesde;
                                        dr["Hasta"] = periodoHasta;
                                        dr["Tipo"] = 1;
                                        dr["SubTipo"] = 1;
                                        dr["Id_Sub"] = idServicioSub;
                                        dr["Nombre_Sub"] = nombreItem;
                                        dr["Id_Velocidad"] = 0;
                                        dr["Id_Velocidad_Tipo"] = 0;
                                        dr["NumBoca"] = 0;
                                        dr["Id_Tipo_Sub"] = idTipoSub;
                                        dr["Tarifa"] = precioTarifa;
                                        dr["Id_Ip"] = 0;

                                        fechaDesde = fechaPeriodo;
                                        DateTime fechaDesdeAuxiliar = fechaDesde;
                                        dr["TarifaProrrateada"] = precioTarifa;
                                        dtInterna.Rows.Add(dr);
                                        fechaFinCobro = fechaPeriodo;
                                        fechaPeriodo = fechaPeriodo.AddMonths(1);
                                        r++;
                                    }
                                }
                                subId++;
                            }
                            catch (Exception)
                            {
                                MessageBox.Show("Hubo un error durante el proceso: AGREGAR SUBSERVICIO MODALIDAD: POR PERIODO", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            break;
                    }
                    PasarDatatable();
                }
            }
        }

        private void btnAgregarSub_Click(object sender, EventArgs e)
        {
            preabrirListado(1);
        }

        private void btnUnidadesFuncionales_Click(object sender, EventArgs e)
        {
            ComenzarCarga();

            drComplementarias = dtVista.Select("Tipo=4");
            if (drComplementarias.Length > 0)
                MessageBox.Show("Actualmente existe un cambio de velocidad pendiente por realizar", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else
            {
                drComplementarias = dtVista.Select("Tipo=7");
                if (drComplementarias.Length > 0)
                    MessageBox.Show("Actualemte existen cambios en la cantidad de bocas, guarde los cambios para continuar", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                else
                {
                    drComplementarias = dtVista.Select("Tipo=1");
                    if (drComplementarias.Length > 0)
                        MessageBox.Show("Actualemte existen cambios en la cantidad de servicios, guarde los cambios para continuar", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    else
                    {
                        if (SeleccionarFecha() == 1)
                        {
                            UnidadesFuncionales();
                        }
                    }
                }
            }
        }

        private void btnCambioVelocidad_Click(object sender, EventArgs e)
        {
            datosServiciosSub = oServiciosSub.ListarPorServicio(idServicio);
            //Forma de Facturacion

            if (requiereIpNoVariable == 0)
                MessageBox.Show("Este servicio no admite velocidades", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else
            {
                drComplementarias = dtVista.Select("Tipo=4");
                if (drComplementarias.Length > 0)
                    MessageBox.Show("Ya hay un cambio de velocidad pendiente por realizar, guarde los cambios para continuar", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                else
                {
                    drComplementarias = dtVista.Select("Tipo=7");
                    if (drComplementarias.Length > 0)
                        MessageBox.Show("Actualemte existen cambios en la cantidad de bocas, guarde los cambios para continuar", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    else
                    {
                        if (SeleccionarFecha() == 1)
                            CambioVelocidad();
                    }
                }
            }
        }

        private void btnIpFija_Click(object sender, EventArgs e)
        {

            if (requiereIpNoVariable == 0)
                MessageBox.Show("Este servicio no admite IP", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else
            {
                drIpFija = dtInterna.Select("Tipo=5");
                if (drIpFija.Length > 0)
                    MessageBox.Show("Actualmente ya existe una operacion con IP Fija pendiente por realizar", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                else
                {
                    idIp = VerificarTieneIp();
                    if (idIp == 0)
                    {
                        if (SeleccionarFecha() == 1)
                            AgregagrIp();
                    }
                    else
                    {
                        DialogResult Respuesta = MessageBox.Show("Este servicio ya cuenta con un IP fija ¿Desea quitarla?", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (Respuesta == DialogResult.Yes)
                        {
                            DataRow dr2 = dtInterna.NewRow();
                            dr2["subId"] = subId;
                            dr2["Tipo"] = 5;
                            dr2["SubTipo"] = 3;
                            dr2["Id_Sub"] = 0;
                            dr2["Nombre_Sub"] = "QUITAR IP FIJA";
                            dr2["Tarifa"] = 0;
                            dr2["Id_Velocidad"] = 0;
                            dr2["Id_Velocidad_Tipo"] = 0;
                            dr2["NumBoca"] = 0;
                            dr2["Id_Tipo_Sub"] = 0;
                            dr2["Id_Ip"] = idIp;
                            dr2["Desde"] = dpFechaDesde.Value;
                            dr2["Hasta"] = fechaHasta;
                            dr2["TarifaProrrateada"] = 0;

                            dtInterna.Rows.Add(dr2);
                            PasarDatatable();
                        }
                    }
                }
            }
        }

        private void btnMesesSerCob_Click(object sender, EventArgs e)
        {
            oPop = new frmPopUp();
            frmCambioMeses oFrmCambioMeses = new frmCambioMeses();
            oPop.Formulario = oFrmCambioMeses;
            oFrmCambioMeses.idUsuariosServicios = this.idUsuariosServicios;
            oPop.Maximizar = false;
            if (oPop.ShowDialog() == DialogResult.OK)
            {
                DataRow dr = dtInterna.NewRow();
                dr["subId"] = subId++;
                dr["Tipo"] = 10;
                dr["SubTipo"] = 0;
                dr["Id_Sub"] = 0;
                dr["Nombre_Sub"] = "Cambio meses";
                dr["Id_Velocidad"] = oFrmCambioMeses.cantNuevosMesesCobros;
                dr["Id_Velocidad_Tipo"] = oFrmCambioMeses.cantNuevosMesesServicios;
                dr["NumBoca"] = 0;
                dr["Id_Tipo_Sub"] = 0;
                dr["Tarifa"] = 0;
                dr["Id_Ip"] = 0;
                dr["Desde"] = DateTime.Now;
                dr["Hasta"] = DateTime.Now;
                dr["TarifaProrrateada"] = 0;
                dtInterna.Rows.Add(dr);
                PasarDatatable();
            }
        }

        private void btnNovedades_Click(object sender, EventArgs e)
        {
            Cuenta_Corriente.frmUsuariosCtaCteNovedades oFrmNovedades = new Cuenta_Corriente.frmUsuariosCtaCteNovedades();
            oPop = new frmPopUp();
            oPop.Formulario = oFrmNovedades;
            oFrmNovedades.StartPosition = FormStartPosition.CenterScreen;
            oPop.ShowDialog();
        }

        private void btnSolicitarEquipo_Click(object sender, EventArgs e)
        {
            if (requiereEquipo == "SI")
            {
                DataTable dtParteFalla = oPartesFallas.GetFallasPorTipoServYOp(idTipoServicio, Convert.ToInt32(Partes.Partes_Operaciones.ASIGNACION_DE_EQUIPO));
                int idfalla = 0;
                if (dtParteFalla.Rows.Count > 0)
                {
                    idfalla = Convert.ToInt32(dtParteFalla.Rows[0]["id"].ToString());
                    oFrmGenerarParte = new Partes_Trabajo.frmGenerarParte(Usuarios.CurrentUsuario.Id, Usuarios.CurrentUsuario.Id_Usuarios_Locacion, null, idUsuariosServicios, idfalla);
                    oPop = new frmPopUp();
                    oPop.Formulario = oFrmGenerarParte;
                    oPop.Maximizar = true;
                    oPop.ShowDialog();
                }
                else
                    MessageBox.Show("Error al obtener id falla: Solicitar Equipo", "Mesaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("El servicio seleccionado no requiere equipo", "Mesaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
        }

        private void btnCambioTarjeta_Click(object sender, EventArgs e)
        {
            if (requiereTarjeta == "SI")
            {
                oFrmSeleccionarEquipo = new frmSeleccionarEquipo(idUsuariosServicios);
                oFrmSeleccionarEquipo.idUsuario = idUsuario;
                oFrmSeleccionarEquipo.idUsuarioServicio = idUsuariosServicios;
                oFrmSeleccionarEquipo.idServicio = idServicio;
                oFrmSeleccionarEquipo.idZona = idZona;
                oFrmSeleccionarEquipo.idLocacion = idUsuariosLocaciones;
                oFrmSeleccionarEquipo.idTipoServicio = idTipoServicio;

                oPop = new frmPopUp();
                oPop.Formulario = oFrmSeleccionarEquipo;
                oPop.Maximizar = false;
                oPop.ShowDialog();
            }
            else
                MessageBox.Show("El servicio seleccionado no requiere tarjeta", "Mesaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

        }

        private void btnExtras_Click(object sender, EventArgs e)
        {
            oPop = new frmPopUp();
            frmExtras ofrmExtras = new frmExtras();
            oPop.Formulario = ofrmExtras;
            oPop.Maximizar = false;
            if (oPop.ShowDialog() == DialogResult.OK)
            {
                decimal importeExtra = ofrmExtras.importe;
                string detalleExtra = ofrmExtras.detalle;
                DataRow drExtra = dtInterna.NewRow();
                subId++;
                drExtra["subId"] = subId;
                drExtra["Tipo"] = 8;
                drExtra["SubTipo"] = 0;
                drExtra["Id_Sub"] = 0;
                drExtra["Nombre_Sub"] = detalleExtra;
                drExtra["Tarifa"] = importeExtra;
                drExtra["Id_Velocidad"] = 0;
                drExtra["Id_Velocidad_Tipo"] = 0;
                drExtra["NumBoca"] = 0;
                drExtra["Id_Tipo_Sub"] = 0;
                drExtra["TarifaProrrateada"] = importeExtra;
                drExtra["desde"] = DateTime.Now;
                drExtra["hasta"] = DateTime.Now;

                dtInterna.Rows.Add(drExtra);
                PasarDatatable();
            }
        }

        private void btnQuitarSub_Click(object sender, EventArgs e)
        {
            preabrirListado(2);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (frmFecha != null)
            {
                frmFecha.DialogResult = DialogResult.Cancel;
            }

        }

        private void frmComplementarias_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (dtInterna.Rows.Count > 0)
            {
                CalcularTotal();
                if (precioTotal > 0)
                    ActualizarSaldo(precioTotal);
                GuardarTodo();
                huboCambios = true;
            }
        }

        private void dgvPresentacion_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void lblCambioTarjeta_Click(object sender, EventArgs e)
        {
            if (requiereTarjeta == "SI")
            {
                oFrmSeleccionarEquipo = new frmSeleccionarEquipo(idUsuariosServicios);
                oFrmSeleccionarEquipo.idUsuario = idUsuario;
                oFrmSeleccionarEquipo.idUsuarioServicio = idUsuariosServicios;
                oFrmSeleccionarEquipo.idServicio = idServicio;
                oFrmSeleccionarEquipo.idZona = idZona;
                oFrmSeleccionarEquipo.idLocacion = idUsuariosLocaciones;
                oFrmSeleccionarEquipo.idTipoServicio = idTipoServicio;

                oPop = new frmPopUp();
                oPop.Formulario = oFrmSeleccionarEquipo;
                oPop.Maximizar = false;
                oPop.ShowDialog();
            }
            else
                MessageBox.Show("El servicio seleccionado no requiere tarjeta", "Mesaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void lbFacturarServicio_Click(object sender, EventArgs e)
        {

        }

        private void lblSolicitarEquipo_Click(object sender, EventArgs e)
        {
            if (requiereEquipo == "SI")
            {
                DataTable dtParteFalla = oPartesFallas.GetFallasPorTipoServYOp(idTipoServicio, Convert.ToInt32(Partes.Partes_Operaciones.ASIGNACION_DE_EQUIPO));
                int idfalla = 0;
                if (dtParteFalla.Rows.Count > 0)
                {
                    idfalla = Convert.ToInt32(dtParteFalla.Rows[0]["id"].ToString());
                    oFrmGenerarParte = new Partes_Trabajo.frmGenerarParte(Usuarios.CurrentUsuario.Id, Usuarios.CurrentUsuario.Id_Usuarios_Locacion, null, idUsuariosServicios, idfalla);
                    oPop = new frmPopUp();
                    oPop.Formulario = oFrmGenerarParte;
                    oPop.Maximizar = true;
                    oPop.ShowDialog();
                }
                else
                    MessageBox.Show("Error al obtener id falla: Solicitar Equipo", "Mesaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("El servicio seleccionado no requiere equipo", "Mesaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
        }

        private void lblCambioVelocidad_Click(object sender, EventArgs e)
        {
            datosServiciosSub = oServiciosSub.ListarPorServicio(idServicio);
            //Forma de Facturacion

            if (requiereIpNoVariable == 0)
                MessageBox.Show("Este servicio no admite velocidades", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else
            {
                drComplementarias = dtVista.Select("Tipo=4");
                if (drComplementarias.Length > 0)
                    MessageBox.Show("Ya hay un cambio de velocidad pendiente por realizar, guarde los cambios para continuar", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                else
                {
                    drComplementarias = dtVista.Select("Tipo=7");
                    if (drComplementarias.Length > 0)
                        MessageBox.Show("Actualemte existen cambios en la cantidad de bocas, guarde los cambios para continuar", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    else
                    {
                        if (SeleccionarFecha() == 1)
                            CambioVelocidad();
                    }
                }
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

        }

        private void dgvPresentacion_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((dgvPresentacion.Columns[e.ColumnIndex].Name.Equals("cquitar")) && (dgvPresentacion.Rows.Count > 0))
                QuitarComplementaria();
            if ((dgvPresentacion.Columns[e.ColumnIndex].Name.Equals("cmodificar")) && (dgvPresentacion.Rows.Count > 0))
            {
                subId = Convert.ToInt32(dgvPresentacion.SelectedRows[0].Cells["subId"].Value);
                int idTipo = Convert.ToInt32(dgvPresentacion.SelectedRows[0].Cells["Tipo"].Value);
                if (idTipo != 8)
                {

                    drColeccionRows = dtInterna.Select(string.Format("subId={0}", subId));
                    oPop = new frmPopUp();
                    oFrmCambioImporte = new frmCambioImporte();
                    oFrmCambioImporte.filasSubServicios = drColeccionRows;
                    oPop.Formulario = oFrmCambioImporte;
                    oPop.Maximizar = false;
                    if (oPop.ShowDialog() == DialogResult.OK)
                    {
                        foreach (DataRow item in drColeccionRows)
                            dtInterna.Rows.Remove(item);
                        for (int i = 0; i < oFrmCambioImporte.filasSubServiciosActualizos.Length; i++)
                        {
                            DataRow dr = dtInterna.NewRow();
                            dr["subId"] = oFrmCambioImporte.filasSubServiciosActualizos[i]["subId"];
                            dr["Tipo"] = oFrmCambioImporte.filasSubServiciosActualizos[i]["Tipo"];
                            dr["SubTipo"] = oFrmCambioImporte.filasSubServiciosActualizos[i]["SubTipo"];
                            dr["Id_Sub"] = oFrmCambioImporte.filasSubServiciosActualizos[i]["Id_Sub"];
                            dr["Nombre_Sub"] = oFrmCambioImporte.filasSubServiciosActualizos[i]["Nombre_Sub"];
                            dr["Id_Velocidad"] = oFrmCambioImporte.filasSubServiciosActualizos[i]["Id_Velocidad"];
                            dr["Id_Velocidad_Tipo"] = oFrmCambioImporte.filasSubServiciosActualizos[i]["Id_Velocidad_Tipo"];
                            dr["NumBoca"] = oFrmCambioImporte.filasSubServiciosActualizos[i]["NumBoca"];
                            dr["Id_Tipo_Sub"] = oFrmCambioImporte.filasSubServiciosActualizos[i]["Id_Tipo_Sub"];
                            dr["Tarifa"] = oFrmCambioImporte.filasSubServiciosActualizos[i]["Tarifa"];
                            dr["Id_Ip"] = oFrmCambioImporte.filasSubServiciosActualizos[i]["Id_Ip"]; ;
                            dr["Desde"] = oFrmCambioImporte.filasSubServiciosActualizos[i]["Desde"];
                            dr["Hasta"] = oFrmCambioImporte.filasSubServiciosActualizos[i]["Hasta"];
                            dr["TarifaProrrateada"] = oFrmCambioImporte.filasSubServiciosActualizos[i]["TarifaProrrateada"];
                            dtInterna.Rows.Add(dr);

                        }
                        PasarDatatable();
                    }
                }
            }
        }

        private void dgvPresentacion_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            CalcularTotal();
        }

        private void dgvPresentacion_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            CalcularTotal();
        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            if (dtInterna.Rows.Count > 0)
            {
                if (MessageBox.Show("Actualmente hay operaciones sin concretar,¿Desea salir?", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    this.Close();
            }
            else
                this.Close();

        }

        #endregion

        #region METODOS
        private void ActualizarIPFija(int id_ip)
        {
            DataRow[] drSubServicios;
            drSubServicios = datosServiciosSub.Select("Id_Servicios_Sub_Tipos=1 and Requiere_ip=1");
            if (drSubServicios.Length > 0)
            {
                idServicioSub = Convert.ToInt32(drSubServicios[0]["id"]);
                oUsuariosServicios.ActualizarIpFija(idUsuariosServicios, idServicioSub, id_ip);
            }
        }

        private void ActualizarVelocidad()
        {
            oServiciosVelocidades.ActualizarVelocidad(idUsuariosServicios, idVelocidad, idServicioSub);

        }

        private void AgregarColumnas()
        {
            //agregar columna link quitar
            columnaLink.Text = "Quitar";
            columnaLink.DataPropertyName = "Quitar";
            columnaLink.Name = "cquitar";
            columnaLink.LinkColor = Color.Red;
            columnaLink.VisitedLinkColor = Color.Red;
            columnaLink.UseColumnTextForLinkValue = true;
            columnaLink.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            columnaLink.HeaderText = "Quitar";
            columnaLink.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader;
            dgvPresentacion.Columns.Add(columnaLink);
            //agregar columna link modificar
            columnaLinkModif.Text = "Modificar importe";
            columnaLinkModif.DataPropertyName = "Modificar";
            columnaLinkModif.Name = "cmodificar";
            columnaLinkModif.LinkColor = Color.Red;
            columnaLinkModif.VisitedLinkColor = Color.Red;
            columnaLinkModif.UseColumnTextForLinkValue = true;
            columnaLinkModif.HeaderText = "Modificar";
            dgvPresentacion.Columns.Add(columnaLinkModif);
            //Columnas para dtInterna
            DataColumn columnIdpro = new DataColumn
            {
                DataType = System.Type.GetType("System.Int32"),
                AutoIncrement = true,
                AutoIncrementSeed = 1,
                AutoIncrementStep = 1,
                ColumnName = "Id"

            };
            dtInterna.Columns.Add(columnIdpro);
            dtInterna.Columns.Add("subId", typeof(Int32));
            dtInterna.Columns.Add("Tipo", typeof(Int32));
            dtInterna.Columns.Add("SubTipo", typeof(Int32));
            dtInterna.Columns.Add("Id_Sub", typeof(Int32));
            dtInterna.Columns.Add("Nombre_Sub", typeof(String));
            dtInterna.Columns.Add("Tarifa", typeof(decimal));
            dtInterna.Columns.Add("Id_Velocidad", typeof(Int32));
            dtInterna.Columns.Add("Id_Velocidad_Tipo", typeof(decimal));
            dtInterna.Columns.Add("NumBoca", typeof(Int32));
            dtInterna.Columns.Add("Id_Tipo_Sub", typeof(Int32));
            dtInterna.Columns.Add("Id_Ip", typeof(Int32));
            dtInterna.Columns.Add("TarifaProrrateada", typeof(decimal));
            dtInterna.Columns.Add("Desde", typeof(DateTime));
            dtInterna.Columns.Add("Hasta", typeof(DateTime));
            dtInterna.Columns.Add("Id_Usu_Sub", typeof(Int32));




            //Columnas para dtVista
            dtVista.Columns.Add("subId", typeof(Int32));
            dtVista.Columns.Add("Tipo", typeof(Int32));
            dtVista.Columns.Add("SubTipo", typeof(Int32));
            dtVista.Columns.Add("Descripcion", typeof(String));
            dtVista.Columns.Add("Unitario", typeof(decimal));
            dtVista.Columns.Add("Cantidad", typeof(String));
            dtVista.Columns.Add("Final", typeof(decimal));
            dtVista.Columns.Add("FechaDesde", typeof(DateTime));
            dtVista.Columns.Add("FechaHasta", typeof(DateTime));
            dtVista.Columns.Add("Id_Sub", typeof(Int32));

            //columnas para dtProratear
            dtProratear.Columns.Add("Id", typeof(Int32));
            dtProratear.Columns.Add("Tarifa", typeof(decimal));

            dgvPresentacion.DataSource = dtVista;
            LbSaldoCta.Text = montoSaldoActual.ToString();
            PonerDatosUsuarios();
            FormatearGrilla();
        }

        private void AgregagrIp()
        {
            ofrmABMIpFijas = new Abms.ABMIpfijas(1);
            oPop = new frmPopUp();
            oPop.Formulario = ofrmABMIpFijas;
            if (oPop.ShowDialog() == DialogResult.OK)
            {
                try
                {

                    idIp = ofrmABMIpFijas.Id;
                    //Busco los costos de cambio de ip (en parte fallas y en configuracion respectivamente)
                    //busco el subservicio que sea de tipo 1
                    datosServiciosSub = oServiciosSub.ListarPorServicio(idServicio);
                    datosFallas = oPartesFallas.GetFallasPorTipoServYOp(idTipoServicio, Convert.ToInt32(Partes.Partes_Operaciones.ALTA_IP));
                    precioTarifaConfiguraion = oConfiguracion.GetValor_Decimal("Costo_IP");
                    if (datosFallas.Rows.Count == 0)
                        precioTarifa = 0;
                    else
                    {
                        idFalla = Convert.ToInt32(value: datosFallas.Rows[0]["id"]);
                        idServicioSub = Convert.ToInt32(datosFallas.Rows[0]["id"]);
                        precioTarifa = oServiciosTarifasSub.getPrecio(idTarifa, idServicio, idServicioSub, "P", idTipoFacturacion);
                    }

                    //conf
                    fechaHasta = Convert.ToDateTime(datosUsuariosServicios.Rows[0]["fecha_factura"]);
                    fechaInicio = dpFechaDesde.Value;
                    int mesesServicio = 0;
                    DataTable dtEspeciales = new DataTable();
                    dtEspeciales = oServiciosTarifasSubEsp.GetServicios_Tarifas_Sub_Esp(idTarifa, idServicio, idTipoFacturacion);
                    DataRow[] datosSubservicioEsp = dtEspeciales.Select("tiposub='S' and idtipodesub=1");
                    mesesServicio = Convert.ToInt32(datosSubservicioEsp[0]["meses_servicio"]);
                    mesesCobro = Convert.ToInt32(datosSubservicioEsp[0]["meses_cobro"]);
                    int r = 1;
                    DateTime fecha = fechaInicio;
                    subId++;
                    decimal tarifaProrrateada = 0;
                    if (idModalidad != 3)
                    {
                        DataRow dr1 = dtInterna.NewRow();
                        dr1["subId"] = subId;
                        dr1["Tipo"] = 5;
                        dr1["SubTipo"] = 1;
                        dr1["Id_Sub"] = idServicioSub;
                        dr1["Nombre_Sub"] = "COSTO IP FIJA";
                        dr1["Tarifa"] = precioTarifaConfiguraion;
                        dr1["Id_Velocidad"] = 0;
                        dr1["Id_Velocidad_Tipo"] = 0;
                        dr1["NumBoca"] = 0;
                        dr1["Id_Tipo_Sub"] = 1;
                        dr1["Id_Ip"] = idIp;
                        tarifaProrrateada = 0;
                        if (idModalidad != 3)
                        {
                            if (fecha.Day != 1)
                            {
                                tarifaProrrateada = ProratearMes(precioTarifaConfiguraion);
                                dr1["TarifaProrrateada"] = tarifaProrrateada;
                            }
                            else
                                dr1["TarifaProrrateada"] = precioTarifaConfiguraion;
                            dr1["Desde"] = fechaInicio;
                            dr1["Hasta"] = fechaHasta;
                            dtInterna.Rows.Add(dr1);

                        }
                        else
                        {
                            while ((r <= mesesCobro) && (fecha <= fechaHasta))
                            {
                                periodoDesde = fecha;
                                int cantDias = DateTime.DaysInMonth(fecha.Year, fecha.Month);
                                periodoHasta = new DateTime(fecha.Year, fecha.Month, cantDias);
                                decimal precioTarifaConf = oConfiguracion.GetValor_Decimal("Costo_IP");

                                DataRow dr = dtInterna.NewRow();
                                dr["subId"] = subId;
                                dr["Tipo"] = 5;
                                dr["SubTipo"] = 1;
                                dr["Id_Sub"] = idServicioSub;
                                dr["Nombre_Sub"] = "COSTO IP FIJA";
                                dr["Tarifa"] = precioTarifaConf;
                                dr["Id_Velocidad"] = 0;
                                dr["Id_Velocidad_Tipo"] = 0;
                                dr["NumBoca"] = 0;
                                dr["Id_Tipo_Sub"] = 1;
                                dr["Id_Ip"] = idIp;
                                tarifaProrrateada = 0;
                                if (idModalidad != 3)
                                {
                                    if (fecha.Day != 1)
                                    {
                                        tarifaProrrateada = ProratearMes(precioTarifaConf);
                                        dr["TarifaProrrateada"] = tarifaProrrateada;
                                    }
                                    else
                                        dr["TarifaProrrateada"] = precioTarifaConf;
                                }
                                else
                                    dr["TarifaProrrateada"] = precioTarifaConf;

                                dr["Desde"] = periodoDesde;
                                dr["Hasta"] = periodoHasta;
                                fecha = fecha.AddMonths(1);
                                dtInterna.Rows.Add(dr);
                                fecha = new DateTime(fecha.Year, fecha.Month, 1);
                                r++;
                            }
                        }
                    }
                    DataRow dr2 = dtInterna.NewRow();
                    dr2["subId"] = subId;
                    dr2["Tipo"] = 5;
                    dr2["SubTipo"] = 2;
                    dr2["Id_Sub"] = idFalla;
                    dr2["Nombre_Sub"] = "CONEXION IP FIJA";
                    dr2["Tarifa"] = precioTarifa;
                    dr2["Id_Velocidad"] = 0;
                    dr2["Id_Velocidad_Tipo"] = 0;
                    dr2["NumBoca"] = 0;
                    dr2["Id_Tipo_Sub"] = 0;
                    dr2["Id_Ip"] = idIp;
                    dr2["Desde"] = fechaDesde;
                    dr2["Hasta"] = fechaHasta;
                    dr2["TarifaProrrateada"] = precioTarifa;
                    dtInterna.Rows.Add(dr2);


                    PasarDatatable();
                }
                catch (Exception)
                {
                    MessageBox.Show("Hubo un error durante el proceso: AGREGAR IP FIJA", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void CalcularTotal()
        {
            precioTotal = 0;
            foreach (DataGridViewRow item in dgvPresentacion.Rows)
                precioTotal = precioTotal + Convert.ToDecimal(item.Cells["Final"].Value);
            lbltotal_v.Text = precioTotal.ToString("C");
        }

        private void CambioVelocidad()
        {
            decimal tarifaProrrateada = 0;
            //Llamo al formulario de cambio de velocidad y con los datos de retorno lo agrego al dtinterno
            if (datosUsuariosServicios.Rows.Count > 0)
            {
                if (datosServicios.Rows.Count > 0)
                {
                    if (datosServicios.Rows[0]["requiere_velocidad"].ToString() == "SI")
                    {
                        oCambioVelocidad = new frmCambioVelocidad(idUsuariosServicios);
                        oPop = new frmPopUp();
                        oCambioVelocidad.FechaDesde = dpFechaDesde.Value;
                        oPop.Formulario = oCambioVelocidad;

                        if (oPop.ShowDialog() == DialogResult.OK)
                        {
                            this.itemDescripcion = oCambioVelocidad.Descripcion;
                            this.precioTarifa = oCambioVelocidad.precioUnitario;
                            this.idVelocidad = oCambioVelocidad.idVelocidad;
                            this.idVelocidadTipo = oCambioVelocidad.idVelocidadTip;
                            this.idServicioSub = oCambioVelocidad.idSubServicio;
                            this.tarifaActual = oCambioVelocidad.tarifaActual;
                            decimal precioProrateado = ProratearMes(precioTarifa);
                            pnFechaDesde.Visible = true;
                            fechaHoy = dpFechaDesde.Value;
                            precioTodo = precioTarifa - tarifaActual;
                            precioProrateado = Proratear(precioTodo, fechaHoy, fechaHasta);

                            switch (idModalidad)
                            {
                                case 2:
                                    try
                                    {
                                        foreach (DataRow item in datosServiciosSub.Rows)
                                        {
                                            requiereIp = Convert.ToInt32(item["Requiere_ip"]);
                                            idServicioSub = Convert.ToInt32(item["id"]);
                                            nombreSubServicio = item["Descripcion"].ToString();
                                            idServicioSubTipo = Convert.ToInt32(item["Id_Servicios_Sub_Tipos"]);
                                            fechaHasta = Convert.ToDateTime(datosUsuariosServicios.Rows[0]["fecha_factura"]);
                                            fechaInicio = dpFechaDesde.Value;
                                            DateTime fecha = fechaInicio;
                                            if (fecha > fechaHasta)
                                            {
                                                DataRow dr = dtInterna.NewRow();
                                                dr["subId"] = subId;
                                                dr["Desde"] = fechaDesde;
                                                dr["Hasta"] = fechaDesde.AddMonths(1).AddDays(-1);
                                                dr["Tipo"] = 4;
                                                dr["SubTipo"] = 0;
                                                dr["Id_Sub"] = idServicioSub;
                                                dr["Nombre_Sub"] = "CAMBIO DE VELOCIDAD: " + itemDescripcion + " MB";
                                                dr["Tarifa"] = 0;
                                                dr["Id_Velocidad"] = idVelocidad;
                                                dr["Id_Velocidad_Tipo"] = idVelocidadTipo;
                                                dr["NumBoca"] = 0;
                                                dr["Id_Tipo_Sub"] = idServicioSubTipo;
                                                dr["Id_Ip"] = 0;
                                                tarifaProrrateada = 0;
                                                dr["TarifaProrrateada"] = tarifaProrrateada;
                                                dtInterna.Rows.Add(dr);
                                            }
                                            else
                                            {
                                                while (fecha <= fechaHasta)
                                                {
                                                    periodoDesde = fecha;
                                                    int cantDias = DateTime.DaysInMonth(fecha.Year, fecha.Month);
                                                    periodoHasta = new DateTime(fecha.Year, fecha.Month, cantDias);
                                                    precioProrateado = 0;

                                                    if (idServicioSubTipo == 1)
                                                    {
                                                        if (requiereIp == 1)
                                                        {
                                                            this.precioTarifa = oCambioVelocidad.precioUnitario;
                                                            if (precioTodo < 0)
                                                            {
                                                                DataRow dr = dtInterna.NewRow();
                                                                dr["subId"] = subId;
                                                                dr["Desde"] = periodoDesde;
                                                                dr["Hasta"] = periodoHasta;
                                                                dr["Tipo"] = 4;
                                                                dr["SubTipo"] = 0;
                                                                dr["Id_Sub"] = idServicioSub;
                                                                dr["Nombre_Sub"] = "CAMBIO DE VELOCIDAD: " + itemDescripcion + " MB";
                                                                dr["Tarifa"] = 0;
                                                                dr["Id_Velocidad"] = idVelocidad;
                                                                dr["Id_Velocidad_Tipo"] = idVelocidadTipo;
                                                                dr["NumBoca"] = 0;
                                                                dr["Id_Tipo_Sub"] = idServicioSubTipo;
                                                                dr["Id_Ip"] = 0;
                                                                dr["TarifaProrrateada"] = 0;

                                                                dtInterna.Rows.Add(dr);
                                                                tarifaProrrateada = 0;
                                                                fecha = fecha.AddMonths(1);

                                                            }
                                                            else
                                                            {
                                                                DataRow dr = dtInterna.NewRow();
                                                                dr["subId"] = subId;
                                                                dr["Desde"] = periodoDesde;
                                                                dr["Hasta"] = periodoHasta;
                                                                dr["Tipo"] = 4;
                                                                dr["SubTipo"] = 0;
                                                                dr["Id_Sub"] = idServicioSub;
                                                                dr["Nombre_Sub"] = "CAMBIO DE VELOCIDAD: " + itemDescripcion + " MB";
                                                                dr["Tarifa"] = precioTodo;
                                                                dr["Id_Velocidad"] = idVelocidad;
                                                                dr["Id_Velocidad_Tipo"] = idVelocidadTipo;
                                                                dr["NumBoca"] = 0;
                                                                dr["Id_Tipo_Sub"] = idServicioSubTipo;
                                                                dr["Id_Ip"] = 0;
                                                                tarifaProrrateada = 0;
                                                                if (periodoDesde.Day != 1)
                                                                    tarifaProrrateada = ProratearMes(precioTodo);
                                                                else
                                                                    tarifaProrrateada = precioTodo;

                                                                dr["TarifaProrrateada"] = tarifaProrrateada;
                                                                dtInterna.Rows.Add(dr);

                                                                tarifaProrrateada = 0;
                                                                fecha = new DateTime(fecha.Year, fecha.Month, 1);
                                                                fecha = fecha.AddMonths(1);

                                                            }
                                                        }
                                                    }
                                                    else
                                                        fecha = fecha.AddMonths(1);
                                                }

                                            }
                                        }
                                    }
                                    catch (Exception)
                                    {
                                        MessageBox.Show("Hubo un error durante el proceso: CAMBIO DE VELOCIDAD: POR MES", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                    break;
                                case 3:
                                    try
                                    {
                                        foreach (DataRow item in datosServiciosSub.Rows)
                                        {
                                            requiereIp = Convert.ToInt32(item["Requiere_ip"]);
                                            idServicioSub = Convert.ToInt32(item["id"]);
                                            nombreSubServicio = item["Descripcion"].ToString();
                                            idServicioSubTipo = Convert.ToInt32(item["Id_Servicios_Sub_Tipos"]);
                                            fechaHasta = Convert.ToDateTime(datosUsuariosServicios.Rows[0]["fecha_factura"]);
                                            fechaInicio = dpFechaDesde.Value;
                                            int mesesServicio = 0;
                                            DataTable dtEspeciales = new DataTable();
                                            dtEspeciales = oServiciosTarifasSubEsp.GetServicios_Tarifas_Sub_Esp(idTarifa, idServicio, idTipoFacturacion);
                                            DataRow[] datosSubservicioEsp = dtEspeciales.Select("tiposub='S' and idtipodesub=1");
                                            mesesServicio = Convert.ToInt32(datosSubservicioEsp[0]["meses_servicio"]);
                                            mesesCobro = Convert.ToInt32(datosSubservicioEsp[0]["meses_cobro"]);
                                            int r = 1;
                                            DateTime fecha = fechaInicio;

                                            while ((r <= mesesCobro) && (fecha <= fechaHasta))
                                            {
                                                periodoDesde = fecha;
                                                int cantDias = DateTime.DaysInMonth(fecha.Year, fecha.Month);
                                                periodoHasta = new DateTime(fecha.Year, fecha.Month, cantDias);
                                                precioProrateado = 0;

                                                if (idServicioSubTipo == 1)
                                                {
                                                    if (requiereIp == 1)
                                                    {
                                                        this.precioTarifa = oCambioVelocidad.precioUnitario;
                                                        if (precioTodo < 0)
                                                        {
                                                            DataRow dr = dtInterna.NewRow();
                                                            dr["subId"] = subId;
                                                            dr["Desde"] = periodoDesde;
                                                            dr["Hasta"] = periodoHasta;
                                                            dr["Tipo"] = 4;
                                                            dr["SubTipo"] = 0;
                                                            dr["Id_Sub"] = idServicioSub;
                                                            dr["Nombre_Sub"] = "CAMBIO DE VELOCIDAD: " + itemDescripcion + " MB";
                                                            dr["Tarifa"] = 0;
                                                            dr["Id_Velocidad"] = idVelocidad;
                                                            dr["Id_Velocidad_Tipo"] = idVelocidadTipo;
                                                            dr["NumBoca"] = 0;
                                                            dr["Id_Tipo_Sub"] = idServicioSubTipo;
                                                            dr["Id_Ip"] = 0;
                                                            dr["TarifaProrrateada"] = 0;
                                                            dtInterna.Rows.Add(dr);
                                                            tarifaProrrateada = 0;
                                                            fecha = fecha.AddMonths(1);
                                                        }
                                                        else
                                                        {
                                                            DataRow dr = dtInterna.NewRow();
                                                            dr["subId"] = subId;
                                                            dr["Desde"] = periodoDesde;
                                                            dr["Hasta"] = periodoHasta;
                                                            dr["Tipo"] = 4;
                                                            dr["SubTipo"] = 0;
                                                            dr["Id_Sub"] = idServicioSub;
                                                            dr["Nombre_Sub"] = "CAMBIO DE VELOCIDAD: " + itemDescripcion + " MB"; ;
                                                            dr["Tarifa"] = precioTodo;
                                                            dr["Id_Velocidad"] = idVelocidad;
                                                            dr["Id_Velocidad_Tipo"] = idVelocidadTipo;
                                                            dr["NumBoca"] = 0;
                                                            dr["Id_Tipo_Sub"] = idServicioSubTipo;
                                                            dr["Id_Ip"] = 0;
                                                            tarifaProrrateada = precioTodo;
                                                            dr["TarifaProrrateada"] = tarifaProrrateada;
                                                            dtInterna.Rows.Add(dr);
                                                            fecha = new DateTime(fecha.Year, fecha.Month, 1);
                                                            fecha = fecha.AddMonths(1);
                                                        }
                                                    }
                                                }
                                                else
                                                    fecha = fecha.AddMonths(1);

                                                r++;
                                            }
                                        }
                                    }
                                    catch (Exception c)
                                    {
                                        MessageBox.Show("Hubo un error durante el proceso: AGREGAR SUBSERVICIO MODALIDAD: POR PERIODO \n " + c.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                    break;
                            }

                            PasarDatatable();
                        }
                    }
                    else
                        MessageBox.Show("Este servicio no requiere velocidad");
                }
            }
        }

        private void FormatearGrilla()
        {
            dgvPresentacion.Columns["FechaDesde"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvPresentacion.Columns["Tipo"].Visible = false;
            dgvPresentacion.Columns["SubTipo"].Visible = false;
            dgvPresentacion.Columns["Id_Sub"].Visible = false;

            dgvPresentacion.Columns["Unitario"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvPresentacion.Columns["Unitario"].DefaultCellStyle.Format = "c";
            dgvPresentacion.Columns["cquitar"].DisplayIndex = dgvPresentacion.Columns.Count - 1;
            dgvPresentacion.Columns["cmodificar"].DisplayIndex = dgvPresentacion.Columns.Count - 2;
            dgvPresentacion.Columns["cmodificar"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            dgvPresentacion.Columns["cquitar"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvPresentacion.Columns["Final"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvPresentacion.Columns["Final"].DefaultCellStyle.Format = "c";
            columnaLinkModif.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvPresentacion.Columns["Descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvPresentacion.Columns["Descripcion"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvPresentacion.Columns["Cantidad"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            dgvPresentacion.Columns["FechaDesde"].HeaderText = "Fecha desde";
            dgvPresentacion.Columns["FechaHasta"].HeaderText = "Fecha hasta";

            dgvPresentacion.Columns["subId"].Visible = false;


        }

        public void ActualizarSaldo(decimal importeTotal)
        {
            decimal Saldo = 0;
            decimal.TryParse(LbSaldoCta.Text, out Saldo);
            Saldo = Saldo + importeTotal;
            LbSaldoCta.Text = Saldo.ToString();
        }

        private void GuardarIPFija()
        {
            //CASO ADICION IP FIJA
            drIpFija = dtInterna.Select("(Tipo=5 and SubTipo=1) or (Tipo=5 and SubTipo=2)");
            precioTarifa = 0;
            if (drIpFija.Length > 0)
            {
                foreach (DataRow item in dtInterna.Rows)
                {
                    precioTarifa = precioTarifa + Convert.ToDecimal(item["Tarifa"]);
                    idServicio = Convert.ToInt32(datosUsuariosServicios.Rows[0]["id_servicios"]);
                    idVelocidad = Convert.ToInt32(item["Id_Velocidad"]);
                    idServicioSub = Convert.ToInt32(item["Id_Sub"]);
                    datosServiciosSub = oServiciosSub.ListarPorServicio(idServicio);
                    idTipoSub = Convert.ToInt32(datosServiciosSub.Rows[0]["Id_Servicios_sub_tipos"]);
                    idIp = Convert.ToInt32(item["Id_Ip"]);
                }
                DataRow[] drs = datosServiciosSub.Select("id_servicios_sub_tipos=1 and requiere_ip=1");
                if (drs.Length > 0)
                {
                    int idSubServicioMensual = Convert.ToInt32(drs[0]["id"]);
                    if (dgvPresentacion.Rows.Count > 0)
                    {
                        idModalidad = Convert.ToInt32(dtServicio.Rows[0]["id_Servicios_modalidad"]);
                        if (idModalidad == Convert.ToInt32(Servicios._Modalidad.PERIODO))
                        {
                            int mesesServicio = 0;

                            DataTable dtEspeciales = new DataTable();
                            dtEspeciales = oServiciosTarifasSubEsp.GetServicios_Tarifas_Sub_Esp(idTarifa, idServicio, idTipoFacturacion);
                            if (dtEspeciales.Rows.Count > 0)
                            {
                                DataRow[] datosSubservicioEsp = dtEspeciales.Select("tiposub='S' and idtipodesub=1");
                                mesesServicio = Convert.ToInt32(datosSubservicioEsp[0]["meses_servicio"]);
                                mesesCobro = Convert.ToInt32(datosSubservicioEsp[0]["meses_cobro"]);
                                fechaDesde = dpFechaDesde.Value;
                                DateTime fechaDesdeAux = dpFechaDesde.Value;
                                //meses a facturar
                                fechaDesde = dpFechaDesde.Value;
                                DateTime fechaHastaAuxiliar = fechaHasta;
                                int r = 1;
                                foreach (DataRow item in drIpFija)
                                {
                                    idTipoSubOperacion = Convert.ToInt32(item["SubTipo"]);
                                    if (idTipoSubOperacion == 2)
                                    {
                                        while ((r <= mesesCobro) && (fechaDesde <= fechaHastaAuxiliar))
                                        {

                                            idServicioSubTipo = Convert.ToInt32(item["Id_Tipo_Sub"]);
                                            precioTarifa = Convert.ToDecimal(item["TarifaProrrateada"]);
                                            idServicio = Convert.ToInt32(datosUsuariosServicios.Rows[0]["id_servicios"]);
                                            idVelocidad = Convert.ToInt32(item["Id_Velocidad"]);
                                            idServicioSub = Convert.ToInt32(item["Id_Sub"]);
                                            idUsuariosServiciosSub = oUsuariosServicios.Get_Id_Usuarios_Servicios_Sub(idUsuariosServicios, idServicioSub);
                                            oUsuariosCuentaCorrienteDet.Id_Usuarios_CtaCte = idUsuariosCtacte;
                                            oUsuariosCuentaCorrienteDet.Id_Usuarios_Locaciones = idUsuariosLocaciones;
                                            oUsuariosCuentaCorrienteDet.Id_Zonas = 1;
                                            oUsuariosCuentaCorrienteDet.Id_Servicios = idServicio;
                                            oUsuariosCuentaCorrienteDet.Detalles = "IP FIJA";

                                            oUsuariosCuentaCorrienteDet.Id_Tipo = idSubServicioMensual;
                                            oUsuariosCuentaCorrienteDet.Tipo = "S";
                                            oUsuariosCuentaCorrienteDet.Fecha_Desde = fechaDesdeAux;
                                            oUsuariosCuentaCorrienteDet.Importe_Original = Convert.ToDecimal(item["TarifaProrrateada"]);
                                            oUsuariosCuentaCorrienteDet.Importe_Saldo = Convert.ToDecimal(item["TarifaProrrateada"]);
                                            oUsuariosCuentaCorrienteDet.Importe_Final = Convert.ToDecimal(item["TarifaProrrateada"]);
                                            oUsuariosCuentaCorrienteDet.Id_Usuarios_Servicios = idUsuariosServicios;
                                            oUsuariosCuentaCorrienteDet.Id_Velocidades = 0;
                                            oUsuariosCuentaCorrienteDet.Id_Velocidades_Tip = 0;
                                            oUsuariosCuentaCorrienteDet.Requiere_IP = 0;
                                            oUsuariosCuentaCorrienteDet.Cantidad_Periodos = 1;
                                            oUsuariosCuentaCorrienteDet.Id_Usuarios_Servicios_sub = idUsuariosServiciosSub;
                                            oUsuariosCuentaCorrienteDet.Periodo_Ano = fechaDesde.Year;
                                            oUsuariosCuentaCorrienteDet.Periodo_Mes = fechaDesde.Month;
                                            oUsuariosCuentaCorrienteDet.Id_bonificacion_Aplicada = 0;
                                            oUsuariosCuentaCorrienteDet.Importe_Bonificacion = 0;
                                            oUsuariosCuentaCorrienteDet.Nombre_Bonificacion = "";

                                            var cantDiasMes = DateTime.DaysInMonth(fechaDesdeAux.Year, fechaDesdeAux.Month);
                                            fechaHasta = new DateTime(fechaDesdeAux.Year, fechaDesdeAux.Month, cantDiasMes);
                                            oUsuariosCuentaCorrienteDet.Fecha_Hasta = fechaHasta;
                                            if (oComprobantes.Importe > 0)
                                                oUsuariosCuentaCorrienteDet.Guardar(oUsuariosCuentaCorrienteDet);
                                            fechaDesdeAux = fechaDesdeAux.AddMonths(1);
                                            fechaDesde = fechaDesde.AddMonths(1);
                                            r++;
                                        }

                                    }
                                    if (idTipoSubOperacion == 1)

                                    {
                                        idServicioSubTipo = Convert.ToInt32(item["Id_Tipo_Sub"]);
                                        precioTarifa = Convert.ToDecimal(item["TarifaProrrateada"]);
                                        idServicio = Convert.ToInt32(datosUsuariosServicios.Rows[0]["id_servicios"]);
                                        idVelocidad = Convert.ToInt32(item["Id_Velocidad"]);
                                        idServicioSub = Convert.ToInt32(item["Id_Sub"]);
                                        idUsuariosServiciosSub = oUsuariosServicios.Get_Id_Usuarios_Servicios_Sub(idUsuariosServicios, idServicioSub);
                                        oUsuariosCuentaCorrienteDet.Id_Usuarios_CtaCte = idUsuariosCtacte;
                                        oUsuariosCuentaCorrienteDet.Id_Usuarios_Locaciones = idUsuariosLocaciones;
                                        oUsuariosCuentaCorrienteDet.Id_Zonas = 1;
                                        oUsuariosCuentaCorrienteDet.Id_Servicios = idServicio;
                                        oUsuariosCuentaCorrienteDet.Tipo = "P";
                                        oUsuariosCuentaCorrienteDet.Detalles = "ALTA DE IP FIJA";
                                        oUsuariosCuentaCorrienteDet.Id_Tipo = idFalla;
                                        oUsuariosCuentaCorrienteDet.Fecha_Hasta = DateTime.Now;
                                        oUsuariosCuentaCorrienteDet.Importe_Original = Convert.ToDecimal(item["TarifaProrrateada"]); ;
                                        oUsuariosCuentaCorrienteDet.Importe_Saldo = Convert.ToDecimal(item["TarifaProrrateada"]); ;
                                        oUsuariosCuentaCorrienteDet.Importe_Final = Convert.ToDecimal(item["TarifaProrrateada"]); ;
                                        oUsuariosCuentaCorrienteDet.Id_Usuarios_Servicios = idUsuariosServicios;
                                        oUsuariosCuentaCorrienteDet.Id_Velocidades = 0;
                                        oUsuariosCuentaCorrienteDet.Id_Velocidades_Tip = 0;
                                        oUsuariosCuentaCorrienteDet.Requiere_IP = 0;
                                        oUsuariosCuentaCorrienteDet.Cantidad_Periodos = 1;
                                        oUsuariosCuentaCorrienteDet.Id_Usuarios_Servicios_sub = idUsuariosServiciosSub;
                                        oUsuariosCuentaCorrienteDet.Periodo_Ano = fechaDesde.Year;
                                        oUsuariosCuentaCorrienteDet.Periodo_Mes = fechaDesde.Month;
                                        oUsuariosCuentaCorrienteDet.Id_bonificacion_Aplicada = 0;
                                        oUsuariosCuentaCorrienteDet.Importe_Bonificacion = 0;
                                        oUsuariosCuentaCorrienteDet.Nombre_Bonificacion = "";
                                        var cantDiasMes = DateTime.DaysInMonth(fechaDesdeAux.Year, fechaDesdeAux.Month);
                                        fechaHasta = new DateTime(fechaDesdeAux.Year, fechaDesdeAux.Month, cantDiasMes);
                                        oUsuariosCuentaCorrienteDet.Fecha_Hasta = fechaHasta;
                                        if (oComprobantes.Importe > 0)
                                            oUsuariosCuentaCorrienteDet.Guardar(oUsuariosCuentaCorrienteDet);
                                    }
                                }
                            }
                        }
                        else
                        {

                            foreach (DataRow item in drIpFija)
                            {
                                idServicioSubTipo = Convert.ToInt32(item["Id_Tipo_Sub"]);
                                precioTarifa = Convert.ToDecimal(item["TarifaProrrateada"]);
                                idServicio = Convert.ToInt32(datosUsuariosServicios.Rows[0]["id_servicios"]);
                                idVelocidad = Convert.ToInt32(item["Id_Velocidad"]);
                                idServicioSub = Convert.ToInt32(item["Id_Sub"]);
                                idTipoSubOperacion = Convert.ToInt32(item["SubTipo"]);
                                periodoDesde = Convert.ToDateTime(item["Desde"]);
                                periodoHasta = Convert.ToDateTime(item["Hasta"]);
                                idUsuariosServiciosSub = oUsuariosServicios.Get_Id_Usuarios_Servicios_Sub(idUsuariosServicios, idServicioSub);
                                oUsuariosCuentaCorrienteDet.Id_Usuarios_CtaCte = idUsuariosCtacte;
                                oUsuariosCuentaCorrienteDet.Id_Usuarios_Locaciones = idUsuariosLocaciones;
                                oUsuariosCuentaCorrienteDet.Id_Zonas = 1;
                                oUsuariosCuentaCorrienteDet.Id_Servicios = idServicio;
                                if (idTipoSubOperacion == 1)
                                {
                                    oUsuariosCuentaCorrienteDet.Id_Tipo = idSubServicioMensual;
                                    oUsuariosCuentaCorrienteDet.Tipo = "S";
                                    oUsuariosCuentaCorrienteDet.Fecha_Hasta = periodoHasta;
                                    oUsuariosCuentaCorrienteDet.Detalles = "IP FIJA";

                                }
                                else
                                {

                                    oUsuariosCuentaCorrienteDet.Tipo = "P";
                                    oUsuariosCuentaCorrienteDet.Id_Tipo = idFalla;
                                    oUsuariosCuentaCorrienteDet.Fecha_Hasta = periodoHasta;
                                    oUsuariosCuentaCorrienteDet.Detalles = "ALTA DE IP FIJA";


                                }
                                oUsuariosCuentaCorrienteDet.Fecha_Desde = periodoDesde;
                                oUsuariosCuentaCorrienteDet.Importe_Original = Convert.ToDecimal(item["TarifaProrrateada"]); ;
                                oUsuariosCuentaCorrienteDet.Importe_Saldo = Convert.ToDecimal(item["TarifaProrrateada"]); ;
                                oUsuariosCuentaCorrienteDet.Importe_Final = Convert.ToDecimal(item["TarifaProrrateada"]); ;
                                oUsuariosCuentaCorrienteDet.Id_Usuarios_Servicios = idUsuariosServicios;
                                oUsuariosCuentaCorrienteDet.Id_Velocidades = 0;
                                oUsuariosCuentaCorrienteDet.Id_Velocidades_Tip = 0;
                                oUsuariosCuentaCorrienteDet.Requiere_IP = 0;
                                oUsuariosCuentaCorrienteDet.Cantidad_Periodos = 1;
                                oUsuariosCuentaCorrienteDet.Id_Usuarios_Servicios_sub = idUsuariosServiciosSub;
                                oUsuariosCuentaCorrienteDet.Periodo_Ano = periodoDesde.Year;
                                oUsuariosCuentaCorrienteDet.Periodo_Mes = periodoDesde.Month;
                                oUsuariosCuentaCorrienteDet.Id_bonificacion_Aplicada = 0;
                                oUsuariosCuentaCorrienteDet.Importe_Bonificacion = 0;
                                oUsuariosCuentaCorrienteDet.Nombre_Bonificacion = "";
                                if (oComprobantes.Importe > 0)
                                    oUsuariosCuentaCorrienteDet.Guardar(oUsuariosCuentaCorrienteDet);

                            }


                        }
                        ActualizarIPFija(idIp);
                        oServiciosIpFija.ActualizarAsignacion(idIp, 1);
                        if (chkGeneraPartes.Checked)
                            GenerarParteCambioIP(1);

                    }
                }
                else
                    MessageBox.Show("Error al leer informacion: Guardar IP Fija", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void GuardarVelocidad()
        {
            //CASO CAMBIO DE VELOCIDAD
            drCambioVelocidad = dtInterna.Select("Tipo=4");
            precioTarifa = 0;
            int contAux = 0;//para actualizar la velocidad 1 sola vez
            if (drCambioVelocidad.Length > 0)
            {
                foreach (DataRow item in drCambioVelocidad)
                {
                    idServicioSubTipo = Convert.ToInt32(item["Id_Tipo_Sub"]);
                    precioTarifa = Convert.ToDecimal(item["TarifaProrrateada"]);
                    idServicio = Convert.ToInt32(datosUsuariosServicios.Rows[0]["id_servicios"]);
                    idVelocidad = Convert.ToInt32(item["Id_Velocidad"]);
                    idServicioSub = Convert.ToInt32(item["Id_Sub"]);
                    fechaDesde = Convert.ToDateTime(item["Desde"]);
                    fechaHasta = Convert.ToDateTime(item["Hasta"]);
                    idUsuariosServiciosSub = oUsuariosServicios.Get_Id_Usuarios_Servicios_Sub(idUsuariosServicios, idServicioSub);
                    if (contAux == 0)
                        ActualizarVelocidad();
                    contAux++;
                    if (oComprobantes.Importe > 0)
                    {
                        oUsuariosCuentaCorrienteDet.Id_Usuarios_CtaCte = idUsuariosCtacte;
                        oUsuariosCuentaCorrienteDet.Detalles = "CAMBIO DE VELOCIDAD";
                        oUsuariosCuentaCorrienteDet.Id_Usuarios_Locaciones = idUsuariosLocaciones;
                        oUsuariosCuentaCorrienteDet.Id_Zonas = 1;
                        oUsuariosCuentaCorrienteDet.Id_Servicios = idServicio;
                        oUsuariosCuentaCorrienteDet.Id_Tipo = idServicioSub;
                        oUsuariosCuentaCorrienteDet.Tipo = "S";
                        oUsuariosCuentaCorrienteDet.Importe_Original = precioTarifa;
                        oUsuariosCuentaCorrienteDet.Importe_Saldo = precioTarifa;
                        oUsuariosCuentaCorrienteDet.Importe_Final = precioTarifa;
                        oUsuariosCuentaCorrienteDet.Id_Usuarios_Servicios = idUsuariosServicios;
                        oUsuariosCuentaCorrienteDet.Id_Velocidades = 0;
                        oUsuariosCuentaCorrienteDet.Id_Velocidades_Tip = 0;
                        oUsuariosCuentaCorrienteDet.Requiere_IP = 0;
                        oUsuariosCuentaCorrienteDet.Cantidad_Periodos = 1;
                        oUsuariosCuentaCorrienteDet.Id_Usuarios_Servicios_sub = idUsuariosServiciosSub;
                        oUsuariosCuentaCorrienteDet.Fecha_Desde = fechaDesde;
                        oUsuariosCuentaCorrienteDet.Periodo_Ano = fechaDesde.Year;
                        oUsuariosCuentaCorrienteDet.Periodo_Mes = fechaDesde.Month;
                        oUsuariosCuentaCorrienteDet.Fecha_Hasta = fechaHasta;
                        oUsuariosCuentaCorrienteDet.Id_bonificacion_Aplicada = 0;
                        oUsuariosCuentaCorrienteDet.Importe_Bonificacion = 0;
                        oUsuariosCuentaCorrienteDet.Nombre_Bonificacion = "";
                        if (oComprobantes.Importe > 0)
                            oUsuariosCuentaCorrienteDet.Guardar(oUsuariosCuentaCorrienteDet);
                    }

                }
                //if(fecha)
                if (chkGeneraPartes.Checked)
                    GenerarParteCambioVelocidad();
            }
        }

        private void GuardarUnidadesFuncionales()
        {
            //CASO UNIDADES FUNCIONALES
            precioTarifa = 0;
            DataRow[] UnidadesFuncionales;
            UnidadesFuncionales = dtInterna.Select("Tipo=7 and subTipo=2");

            if (UnidadesFuncionales.Length > 0)
            {
                foreach (DataRow item in UnidadesFuncionales)
                {
                    precioTarifa = precioTarifa + Convert.ToDecimal(item["TarifaProrrateada"]);
                    idServicio = Convert.ToInt32(datosUsuariosServicios.Rows[0]["id_servicios"]);
                    idVelocidad = Convert.ToInt32(item["Id_Velocidad"]);
                    idServicioSub = Convert.ToInt32(item["Id_Sub"]);
                }
                if (UnidadesFuncionales.Length > 0)
                {
                    if (idModalidad == Convert.ToInt32(Servicios._Modalidad.PERIODO))
                    {
                        if (dtEspeciales.Rows.Count > 0)
                        {
                            DataRow[] datosSubservicioEsp = dtEspeciales.Select("tiposub='S' and idtipodesub=1");
                            if (oComprobantes.Importe > 0)
                            {
                                int idUsuarioServicioSub;

                                precioTarifa = 0;
                                foreach (DataRow item in UnidadesFuncionales)
                                    precioTarifa = precioTarifa + Convert.ToDecimal(item["tarifa"]);

                                idUsuarioServicioSub = Convert.ToInt32(datosUsuariosServicios.Rows[0]["id"]);
                                idServicio = Convert.ToInt32(datosUsuariosServicios.Rows[0]["id_servicios"]);
                                fechaDesde = dpFechaDesde.Value;
                                fechaHasta = Convert.ToDateTime(datosUsuariosServicios.Rows[0]["fecha_factura"]);
                                oUsuariosCuentaCorrienteDet.Id_Usuarios_Servicios_sub = Convert.ToInt32(dtSubServiciosContratados.Rows[0]["id"]);
                                oUsuariosCuentaCorrienteDet.Id_Usuarios_CtaCte = idUsuariosCtacte;
                                oUsuariosCuentaCorrienteDet.Id_Usuarios_Locaciones = idUsuariosLocaciones;
                                oUsuariosCuentaCorrienteDet.Id_Zonas = 1;
                                oUsuariosCuentaCorrienteDet.Id_Servicios = idServicio;
                                oUsuariosCuentaCorrienteDet.Id_Tipo = idServicioSub;
                                oUsuariosCuentaCorrienteDet.Tipo = "S";
                                oUsuariosCuentaCorrienteDet.Importe_Original = precioTarifa;
                                oUsuariosCuentaCorrienteDet.Importe_Saldo = precioTarifa;
                                oUsuariosCuentaCorrienteDet.Importe_Final = precioTarifa;
                                oUsuariosCuentaCorrienteDet.Id_Usuarios_Servicios = idUsuariosServicios;
                                oUsuariosCuentaCorrienteDet.Id_Velocidades = 0;
                                oUsuariosCuentaCorrienteDet.Id_Velocidades_Tip = 0;
                                oUsuariosCuentaCorrienteDet.Requiere_IP = 0;
                                oUsuariosCuentaCorrienteDet.Cantidad_Periodos = 1;
                                oUsuariosCuentaCorrienteDet.Periodo_Ano = fechaDesde.Year;
                                oUsuariosCuentaCorrienteDet.Periodo_Mes = fechaDesde.Month;
                                oUsuariosCuentaCorrienteDet.Id_bonificacion_Aplicada = 0;
                                oUsuariosCuentaCorrienteDet.Importe_Bonificacion = 0;
                                oUsuariosCuentaCorrienteDet.Nombre_Bonificacion = "";
                                oUsuariosCuentaCorrienteDet.Fecha_Desde = fechaDesde;
                                oUsuariosCuentaCorrienteDet.Fecha_Hasta = fechaHasta;
                                oUsuariosCuentaCorrienteDet.Detalles = "AGREGADO DE UNIDAD FUNCIONAL";

                                oUsuariosCuentaCorrienteDet.Guardar(oUsuariosCuentaCorrienteDet);
                            }
                        }
                    }
                    else
                    {
                        if (oComprobantes.Importe > 0)
                        {

                            foreach (DataRow item in UnidadesFuncionales)
                            {
                                precioTarifa = Convert.ToDecimal(item["TarifaProrrateada"]);
                                idServicio = Convert.ToInt32(datosUsuariosServicios.Rows[0]["id_servicios"]);
                                idVelocidad = Convert.ToInt32(item["Id_Velocidad"]);
                                idServicioSub = Convert.ToInt32(item["Id_Sub"]);
                                idServicioSubTipo = Convert.ToInt32(item["Id_Tipo_Sub"]);
                                periodoDesde = Convert.ToDateTime(item["Desde"]);
                                periodoHasta = Convert.ToDateTime(item["Hasta"]);
                                DataRow dtDatosSub = oServiciosSub.TraerDatosSubServicio(idServicioSub);
                                requiereIp = Convert.ToInt32(dtDatosSub["requiere_ip"]);
                                idUsuariosServiciosSub = Convert.ToInt32(item["Id_Usu_Sub"]);
                                oUsuariosCuentaCorrienteDet.Id_Usuarios_Servicios_sub = idUsuariosServiciosSub;
                                oUsuariosCuentaCorrienteDet.Id_Usuarios_CtaCte = idUsuariosCtacte;
                                oUsuariosCuentaCorrienteDet.Id_Usuarios_Locaciones = idUsuariosLocaciones;
                                oUsuariosCuentaCorrienteDet.Id_Zonas = 1;
                                oUsuariosCuentaCorrienteDet.Id_Servicios = idServicio;
                                oUsuariosCuentaCorrienteDet.Id_Tipo = idServicioSub;
                                oUsuariosCuentaCorrienteDet.Tipo = "S";

                                oUsuariosCuentaCorrienteDet.Importe_Original = precioTarifa;
                                oUsuariosCuentaCorrienteDet.Importe_Saldo = precioTarifa;
                                oUsuariosCuentaCorrienteDet.Importe_Final = precioTarifa;
                                oUsuariosCuentaCorrienteDet.Id_Usuarios_Servicios = idUsuariosServicios;
                                oUsuariosCuentaCorrienteDet.Id_Velocidades = 0;
                                oUsuariosCuentaCorrienteDet.Id_Velocidades_Tip = 0;
                                oUsuariosCuentaCorrienteDet.Requiere_IP = 0;
                                oUsuariosCuentaCorrienteDet.Cantidad_Periodos = 1;
                                oUsuariosCuentaCorrienteDet.Fecha_Desde = periodoDesde;
                                oUsuariosCuentaCorrienteDet.Fecha_Hasta = periodoDesde;
                                oUsuariosCuentaCorrienteDet.Periodo_Ano = periodoDesde.Year;
                                oUsuariosCuentaCorrienteDet.Periodo_Mes = periodoDesde.Month;
                                oUsuariosCuentaCorrienteDet.Id_bonificacion_Aplicada = 0;
                                oUsuariosCuentaCorrienteDet.Importe_Bonificacion = 0;
                                oUsuariosCuentaCorrienteDet.Nombre_Bonificacion = "";
                                oUsuariosCuentaCorrienteDet.Detalles = "AGREGADO DE UNIDAD FUNCIONAL";
                                oUsuariosCuentaCorrienteDet.Guardar(oUsuariosCuentaCorrienteDet);

                                cantBocasPacNueva = Convert.ToInt32(item["NumBoca"]);
                            }
                        }
                    }
                    cantBocasPacNueva = cantBocasPacNueva + cantBocasPacActual;
                    oUsuariosServicios.ActualizarBocas(idUsuariosServicios, cantBocasPacNueva, 'p', 'a');
                    if (chkGeneraPartes.Checked)
                        GenerarParteUnidadesFuncionales();
                }
            }
        }

        private void GenerarParteCambioVelocidad()
        {
            try
            {
                DataTable drParteFalla = oPartesFallas.GetFallasPorTipoServYOp(idTipoServicio, Convert.ToInt32(Partes.Partes_Operaciones.CAMBIO_TECNOLOGIA));
                if (drParteFalla.Rows.Count > 0)
                {
                    oPartes.Id_Usuarios = idUsuario;
                    oPartes.Id_Servicios = idServicio;
                    oPartes.Id_Usuarios_Servicios = idUsuariosServicios;
                    oPartes.Id_Usuarios_Locaciones = idUsuariosLocaciones;
                    oPartes.Id_Zonas = idZona;
                    oPartes.Id_Partes_Fallas = Convert.ToInt32(drParteFalla.Rows[0]["id"].ToString());
                    oPartes.Id_Partes_Soluciones = 0;
                    oPartes.Id_Movil = 0;
                    oPartes.Id_Operadores = Personal.Id_Login;
                    oPartes.Id_Areas = Personal.Id_Area;
                    oPartes.Fecha_Reclamo = DateTime.Now;
                    oPartes.Detalle_Solucion = "."; // txtDetalle.Text;
                    oPartes.Detalle_Falla = drParteFalla.Rows[0]["nombre"].ToString();
                    oPartes.Id_Partes_Estados = Convert.ToInt32(Partes.Partes_Estados.ASIGNADO);
                    oPartes.Id_Tecnico = Personal.Id_Login;
                    oPartes.Fecha_Realizado = DateTime.Now;
                    oPartes.Fecha_Programado = fechaDesde;
                    oPartes.Id_Usuarios_Cuenta_Corriente = 0;
                    idParte = oPartes.Guardar(oPartes, 1);
                    //genero el historial
                    oPartesHistorial.Id_Parte = idParte;
                    oPartesHistorial.Id_Usuarios = idUsuario;
                    oPartesHistorial.Id_Personal = Personal.Id_Login;
                    oPartesHistorial.Fecha_Movimiento = DateTime.Now;
                    oPartesHistorial.Id_area = Personal.Id_Area;
                    oPartesHistorial.Detalles = "CAMBIO DE VELOCIDAD. PARTE PASADO A REALIZADO AUTOMANTICAMENTE.";
                    oPartesHistorial.Id_Partes_Estados = Convert.ToInt32(Partes.Partes_Estados.ASIGNADO);

                    oPartesHistorial.GuardarNuevoDetalle(oPartesHistorial);

                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void GenerarParteCambioIP(int accion)
        {
            //ACCION: 1=ALTA 2:BAJA
            try
            {
                DataTable drParteFalla;
                if (accion == 1)
                {
                    drParteFalla = oPartesFallas.GetFallasPorTipoServYOp(idTipoServicio, Convert.ToInt32(Partes.Partes_Operaciones.ALTA_IP));
                    if (drParteFalla.Rows.Count == 0)
                        MessageBox.Show("No se encontro solicitud relacionada al alta de ip fija", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    drParteFalla = oPartesFallas.GetFallasPorTipoServYOp(idTipoServicio, Convert.ToInt32(Partes.Partes_Operaciones.BAJA_IP));


                if (drParteFalla.Rows.Count > 0)
                {
                    oPartes.Id_Usuarios = idUsuario;
                    oPartes.Id_Servicios = idServicio;
                    oPartes.Id_Usuarios_Servicios = idUsuariosServicios;
                    oPartes.Id_Usuarios_Locaciones = idUsuariosLocaciones;
                    oPartes.Id_Zonas = idZona;
                    oPartes.Id_Partes_Fallas = Convert.ToInt32(drParteFalla.Rows[0]["id"].ToString());
                    oPartes.Id_Partes_Soluciones = 0;
                    oPartes.Id_Movil = 0;
                    oPartes.Id_Operadores = Personal.Id_Login;
                    oPartes.Id_Areas = Personal.Id_Area;
                    oPartes.Fecha_Reclamo = Convert.ToDateTime(DateTime.Now.ToLongTimeString());
                    oPartes.Detalle_Solucion = "."; // txtDetalle.Text;
                    oPartes.Detalle_Falla = drParteFalla.Rows[0]["nombre"].ToString();
                    oPartes.Id_Partes_Estados = Convert.ToInt32(Partes.Partes_Estados.REALIZADO);
                    oPartes.Id_Tecnico = Personal.Id_Login;
                    oPartes.Fecha_Realizado = DateTime.Now;
                    oPartes.Id_Usuarios_Cuenta_Corriente = 0;
                    idParte = oPartes.Guardar(oPartes, 1);
                    //genero el historial
                    oPartesHistorial.Id_Parte = idParte;
                    oPartesHistorial.Id_Usuarios = idUsuario;
                    oPartesHistorial.Id_Personal = Personal.Id_Login;
                    oPartesHistorial.Fecha_Movimiento = DateTime.Now;
                    oPartesHistorial.Id_area = Personal.Id_Area;
                    oPartesHistorial.Detalles = "PARTE PASADO A REALIZADO.";
                    oPartesHistorial.Id_Partes_Estados = Convert.ToInt32(Partes.Partes_Estados.REALIZADO);
                    oPartesHistorial.GuardarNuevoDetalle(oPartesHistorial);

                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void GenerarParteUnidadesFuncionales()
        {
            try
            {
                DataTable drParteFalla;
                drParteFalla = oPartesFallas.GetFallasPorTipoServYOp(idTipoServicio, Convert.ToInt32(Partes.Partes_Operaciones.CAMBIO_BOCAS));
                if (drParteFalla.Rows.Count > 0)
                {
                    oPartes.Id_Usuarios = idUsuario;
                    oPartes.Id_Servicios = idServicio;
                    oPartes.Id_Usuarios_Servicios = idUsuariosServicios;
                    oPartes.Id_Usuarios_Locaciones = idUsuariosLocaciones;
                    oPartes.Id_Zonas = idZona;
                    oPartes.Id_Partes_Fallas = Convert.ToInt32(drParteFalla.Rows[0]["id"].ToString());
                    oPartes.Id_Partes_Soluciones = 0;
                    oPartes.Id_Movil = 0;
                    oPartes.Id_Operadores = Personal.Id_Login;
                    oPartes.Id_Areas = Personal.Id_Area;
                    oPartes.Fecha_Reclamo = Convert.ToDateTime(DateTime.Now.ToLongTimeString());
                    oPartes.Detalle_Solucion = "."; // txtDetalle.Text;
                    oPartes.Detalle_Falla = drParteFalla.Rows[0]["nombre"].ToString();
                    oPartes.Id_Partes_Estados = Convert.ToInt32(Partes.Partes_Estados.REALIZADO);
                    oPartes.Id_Tecnico = Personal.Id_Login;
                    oPartes.Fecha_Realizado = DateTime.Now;
                    oPartes.Id_Usuarios_Cuenta_Corriente = 0;
                    idParte = oPartes.Guardar(oPartes, 1);
                    //genero el historial
                    oPartesHistorial.Id_Parte = idParte;
                    oPartesHistorial.Id_Usuarios = idUsuario;
                    oPartesHistorial.Id_Personal = Personal.Id_Login;
                    oPartesHistorial.Fecha_Movimiento = DateTime.Now;
                    oPartesHistorial.Id_area = Personal.Id_Area;
                    oPartesHistorial.Detalles = "PARTE PASADO A REALIZADO.";
                    oPartesHistorial.Id_Partes_Estados = Convert.ToInt32(Partes.Partes_Estados.REALIZADO);
                    oPartesHistorial.GuardarNuevoDetalle(oPartesHistorial);

                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void GenerarParteSubServicios(int accion,int cantidad, DateTime fecha_programado, int filtroEstadoParte=0, int id_servicio_sub=0)
        {
            //ACCION: 1=ALTA 2=BAJA
            try
            {
                DataTable drParteFalla;
                if (accion == 1)
                    drParteFalla = oPartesFallas.GetFallasPorTipoServYOp(idTipoServicio, Convert.ToInt32(Partes.Partes_Operaciones.AGREGAR_SUBSERVICIO));
                else
                    drParteFalla = oPartesFallas.GetFallasPorTipoServYOp(idTipoServicio, Convert.ToInt32(Partes.Partes_Operaciones.QUITAR_SUBSERVICIO));

                if (drParteFalla.Rows.Count > 0)
                {
                    oPartes.Id_Usuarios = idUsuario;
                    oPartes.Id_Servicios = idServicio;
                    oPartes.Id_Usuarios_Servicios = idUsuariosServicios;
                    oPartes.Id_Usuarios_Locaciones = idUsuariosLocaciones;
                    oPartes.Id_Zonas = idZona;
                    oPartes.Id_Partes_Fallas = Convert.ToInt32(drParteFalla.Rows[0]["id"].ToString());
                    oPartes.Id_Partes_Soluciones = 0;
                    oPartes.Id_Movil = 0;
                    oPartes.Id_Operadores = Personal.Id_Login;
                    oPartes.Id_Areas = Personal.Id_Area;
                    oPartes.Fecha_Reclamo = Convert.ToDateTime(DateTime.Now.ToLongTimeString());
                    oPartes.Detalle_Solucion = "."; // txtDetalle.Text;
                    oPartes.Detalle_Falla = cantidad.ToString() +" " + nombreServicio;
                    oPartes.Fecha_Programado = fecha_programado;
                    if(filtroEstadoParte > 0)
                        oPartes.Id_Partes_Estados = Convert.ToInt32(filtroEstadoParte);
                    else
                        oPartes.Id_Partes_Estados = Convert.ToInt32(Partes.Partes_Estados.REALIZADO);
                    oPartes.Id_Tecnico = Personal.Id_Login;
                    if(filtroEstadoParte == Convert.ToInt32(Partes.Partes_Estados.REALIZADO))
                        oPartes.Fecha_Realizado = DateTime.Now;
                    oPartes.Id_Usuarios_Cuenta_Corriente = 0;
                    idParte = oPartes.Guardar(oPartes, 1, id_servicio_sub);
                    //genero el historial
                    oPartesHistorial.Id_Parte = idParte;
                    oPartesHistorial.Id_Usuarios = idUsuario;
                    oPartesHistorial.Id_Personal = Personal.Id_Login;
                    oPartesHistorial.Fecha_Movimiento = DateTime.Now;
                    oPartesHistorial.Id_area = Personal.Id_Area;
                    oPartesHistorial.Detalles = "PARTE PASADO A REALIZADO.";
                    if (filtroEstadoParte > 0)
                        oPartesHistorial.Id_Partes_Estados = Convert.ToInt32(filtroEstadoParte);
                    else
                        oPartesHistorial.Id_Partes_Estados = Convert.ToInt32(Partes.Partes_Estados.REALIZADO);
                    oPartesHistorial.GuardarNuevoDetalle(oPartesHistorial);

                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void GuardarQuitarSubServicio()
        {
            int idUsuarioSubServicio = 0;
            foreach (DataRow item in dtInterna.Rows)
            {
                idTipoOperacion = Convert.ToInt32(item["Tipo"]);
                idTipoSubOperacion = Convert.ToInt32(item["SubTipo"]);
                if ((idTipoOperacion == 1) && (idTipoSubOperacion == 2))
                {
                    idUsuarioSubServicio = Convert.ToInt32(item["Id_Sub"]);
                    oUsuariosServicios.QuitarSubservicio(idUsuarioSubServicio);
                }
            }
        }

        private void GuardarAgregarSubServicio()
        {
            //CASO AGREGAR QUITAR SUBSERVICIO
            int idUsuarioServicioSub = 0;
            //analizo la cantidad de sub que se agregan 
            DataTable dtSubAgrupados = dtInterna.AsEnumerable()
                .GroupBy(r => new { Col1 = r["nombre_sub"]})
                .Select(g => g.OrderBy(r => r["tipo"]).First())
                .CopyToDataTable();
            DataRow[] drAgregarSubServicio = dtInterna.Select("Tipo=1 and SubTipo=1");
            if (drAgregarSubServicio.Length > 0)
            {
                nombreServicio = drAgregarSubServicio[0]["NOmbre_Sub"].ToString().ToUpper();
                if (idModalidad == Convert.ToInt32(Servicios._Modalidad.PERIODO))
                {
                    int mesesServicio = 0;
                    DataTable dtEspeciales = new DataTable();
                    dtEspeciales = oServiciosTarifasSubEsp.GetServicios_Tarifas_Sub_Esp(idTarifa, idServicio, idTipoFacturacion);
                    if (dtEspeciales.Rows.Count > 0)
                    {
                        DataRow[] datosSubservicioEsp = dtEspeciales.Select("tiposub='S' and idtipodesub=1");
                        mesesServicio = Convert.ToInt32(datosSubservicioEsp[0]["meses_servicio"]);
                        mesesCobro = Convert.ToInt32(datosSubservicioEsp[0]["meses_cobro"]);
                        fechaDesde = dpFechaDesde.Value;
                        DateTime fechaDesdeAux = dpFechaDesde.Value;
                        //meses a facturar
                        fechaDesde = dpFechaDesde.Value;
                        DateTime fechaHastaAuxiliar = fechaHasta;
                        int r = 1;
                        foreach (DataRow item in drAgregarSubServicio)
                        {
                            precioTarifa = Convert.ToDecimal(item["TarifaProrrateada"]);
                            idServicio = Convert.ToInt32(datosUsuariosServicios.Rows[0]["id_servicios"]);
                            idServicioSub = Convert.ToInt32(item["Id_Sub"]);
                            idServicioSubTipo = Convert.ToInt32(item["Id_Tipo_Sub"]);
                            idVelocidad = Convert.ToInt32(item["Id_Velocidad"]);
                            idVelocidadTipo = Convert.ToInt32(item["Id_Velocidad_Tipo"]);
                            if (r == 1)
                            {
                                DataRow drDatosSub = oServiciosSub.TraerDatosSubServicio(idServicioSub);
                                requiereIp = Convert.ToInt32(drDatosSub["requiere_ip"]);
                                if (fechaDesdeGlobal.Date == DateTime.Now.Date)
                                    idUsuarioServicioSub = oUsuariosServicios.Guardar_Subservicios(0, idUsuariosServicios, idServicioSub, idVelocidad, idVelocidadTipo, requiereIp, 0, 0, 0, "", fechaDesde, fechaHasta, (int)Borrados.Estado.Activo);
                            }
                            oUsuariosCuentaCorrienteDet.Id_Usuarios_CtaCte = idUsuariosCtacte;
                            oUsuariosCuentaCorrienteDet.Id_Usuarios_Locaciones = idUsuariosLocaciones;
                            oUsuariosCuentaCorrienteDet.Id_Zonas = 1;
                            oUsuariosCuentaCorrienteDet.Id_Servicios = idServicio;
                            oUsuariosCuentaCorrienteDet.Id_Tipo = idServicioSub;
                            oUsuariosCuentaCorrienteDet.Id_Usuarios_Servicios_sub = idUsuarioServicioSub;
                            oUsuariosCuentaCorrienteDet.Tipo = "S";
                            oUsuariosCuentaCorrienteDet.Importe_Original = precioTarifa;
                            oUsuariosCuentaCorrienteDet.Importe_Saldo = precioTarifa;
                            oUsuariosCuentaCorrienteDet.Importe_Final = precioTarifa;
                            oUsuariosCuentaCorrienteDet.Id_Usuarios_Servicios = idUsuariosServicios;
                            oUsuariosCuentaCorrienteDet.Id_Velocidades = 0;
                            oUsuariosCuentaCorrienteDet.Id_Velocidades_Tip = 0;
                            oUsuariosCuentaCorrienteDet.Requiere_IP = 0;
                            oUsuariosCuentaCorrienteDet.Cantidad_Periodos = 1;
                            oUsuariosCuentaCorrienteDet.Fecha_Desde = fechaDesdeAux;
                            oUsuariosCuentaCorrienteDet.Periodo_Ano = fechaDesde.Year;
                            oUsuariosCuentaCorrienteDet.Periodo_Mes = fechaDesde.Month;
                            oUsuariosCuentaCorrienteDet.Id_bonificacion_Aplicada = 0;
                            oUsuariosCuentaCorrienteDet.Importe_Bonificacion = 0;
                            oUsuariosCuentaCorrienteDet.Detalles = "AGREGADO DE SUBSERVICIO";

                            oUsuariosCuentaCorrienteDet.Nombre_Bonificacion = "";
                            var cantDiasMes = DateTime.DaysInMonth(fechaDesdeAux.Year, fechaDesdeAux.Month);
                            fechaHasta = new DateTime(fechaDesdeAux.Year, fechaDesdeAux.Month, cantDiasMes);
                            oUsuariosCuentaCorrienteDet.Fecha_Hasta = fechaHasta;
                            if (oComprobantes.Importe > 0)
                                oUsuariosCuentaCorrienteDet.Guardar(oUsuariosCuentaCorrienteDet);
                            fechaDesdeAux = fechaDesdeAux.AddMonths(1);
                            fechaDesde = fechaDesde.AddMonths(1);
                            r++;


                        }
                    }
                    else
                        MessageBox.Show("Error al cargar datos");
                }
                else
                {
                    precioTarifa = 0;
                    foreach (DataRow item in drAgregarSubServicio)
                        precioTarifa = precioTarifa + Convert.ToDecimal(item["TarifaProrrateada"]);

                    int idInternoAnterior = 0;
                    int idInterno;
                    int r = 0;
                    foreach (DataRow item in drAgregarSubServicio)
                    {
                        precioTarifa = Convert.ToDecimal(item["TarifaProrrateada"]);
                        idServicio = Convert.ToInt32(datosUsuariosServicios.Rows[0]["id_servicios"]);
                        idServicioSub = Convert.ToInt32(item["Id_Sub"]);
                        idServicioSubTipo = Convert.ToInt32(item["Id_Tipo_Sub"]);
                        idVelocidad = Convert.ToInt32(item["Id_Velocidad"]);
                        idVelocidadTipo = Convert.ToInt32(item["Id_Velocidad_Tipo"]);

                        if (r == 1)
                        {
                            DataRow drDatosSub = oServiciosSub.TraerDatosSubServicio(idServicioSub);
                            requiereIp = Convert.ToInt32(drDatosSub["requiere_ip"]);
                            if (fechaDesdeGlobal.Date == DateTime.Now.Date)
                                idUsuarioServicioSub = oUsuariosServicios.Guardar_Subservicios(0, idUsuariosServicios, idServicioSub, idVelocidad, idVelocidadTipo, requiereIp, 0, 0, 0, "", fechaDesde, fechaHasta, (int)Borrados.Estado.Activo);
                            else
                                idUsuarioServicioSub = oUsuariosServicios.Guardar_Subservicios(0, idUsuariosServicios, idServicioSub, idVelocidad, idVelocidadTipo, requiereIp, 0, 0, 0, "", fechaDesde, fechaHasta, (int)Borrados.Estado.Inactivo);
                        }
                        idInterno = Convert.ToInt32(item["subId"]);
                        if (idInternoAnterior != idInterno)
                        {
                            if (fechaDesdeGlobal.Date == DateTime.Now.Date)
                                idUsuarioServicioSub = oUsuariosServicios.Guardar_Subservicios(0, idUsuariosServicios, Convert.ToInt32(item["Id_Sub"]), 0, 0, 0, 0, 0, 0, string.Empty, fechaDesde, fechaHasta, (int)Borrados.Estado.Activo);
                            else
                                idUsuarioServicioSub = oUsuariosServicios.Guardar_Subservicios(0, idUsuariosServicios, idServicioSub, idVelocidad, idVelocidadTipo, requiereIp, 0, 0, 0, "", fechaDesde, fechaHasta, (int)Borrados.Estado.Inactivo);
                            precioTarifa = Convert.ToDecimal(item["TarifaProrrateada"]);

                        }
                        else
                        {
                            precioTarifa = Convert.ToDecimal(item["TarifaProrrateada"]);

                        }

                        idServicio = Convert.ToInt32(datosUsuariosServicios.Rows[0]["id_servicios"]);
                        idServicioSub = Convert.ToInt32(item["Id_Sub"]);
                        idServicioSubTipo = Convert.ToInt32(item["Id_Tipo_Sub"]);
                        periodoDesde = Convert.ToDateTime(item["desde"]);
                        periodoHasta = Convert.ToDateTime(item["hasta"]);
                        oUsuariosCuentaCorrienteDet.Id_Usuarios_CtaCte = idUsuariosCtacte;
                        oUsuariosCuentaCorrienteDet.Id_Usuarios_Locaciones = idUsuariosLocaciones;
                        oUsuariosCuentaCorrienteDet.Id_Zonas = 1;
                        oUsuariosCuentaCorrienteDet.Id_Servicios = idServicio;
                        oUsuariosCuentaCorrienteDet.Id_Tipo = idServicioSub;
                        oUsuariosCuentaCorrienteDet.Id_Usuarios_Servicios_sub = idUsuarioServicioSub;
                        oUsuariosCuentaCorrienteDet.Tipo = "S";
                        oUsuariosCuentaCorrienteDet.Importe_Original = precioTarifa;
                        oUsuariosCuentaCorrienteDet.Importe_Saldo = precioTarifa;
                        oUsuariosCuentaCorrienteDet.Importe_Final = precioTarifa;
                        oUsuariosCuentaCorrienteDet.Id_Usuarios_Servicios = idUsuariosServicios;
                        oUsuariosCuentaCorrienteDet.Id_Velocidades = 0;
                        oUsuariosCuentaCorrienteDet.Id_Velocidades_Tip = 0;
                        oUsuariosCuentaCorrienteDet.Requiere_IP = 0;
                        oUsuariosCuentaCorrienteDet.Cantidad_Periodos = 1;
                        oUsuariosCuentaCorrienteDet.Fecha_Desde = periodoDesde;
                        oUsuariosCuentaCorrienteDet.Fecha_Hasta = periodoHasta;
                        oUsuariosCuentaCorrienteDet.Periodo_Ano = periodoDesde.Year;
                        oUsuariosCuentaCorrienteDet.Periodo_Mes = periodoDesde.Month;
                        oUsuariosCuentaCorrienteDet.Id_bonificacion_Aplicada = 0;
                        oUsuariosCuentaCorrienteDet.Importe_Bonificacion = 0;
                        oUsuariosCuentaCorrienteDet.Nombre_Bonificacion = "";
                        oUsuariosCuentaCorrienteDet.Detalles = "AGREGADO DE SUBSERVICIO";
                        if (oComprobantes.Importe > 0)
                            oUsuariosCuentaCorrienteDet.Guardar(oUsuariosCuentaCorrienteDet);
                        idInternoAnterior = idInterno;
                        if (chkGeneraPartes.Checked)
                        {
                            if (fechaDesdeGlobal.Date == DateTime.Now.Date)
                                GenerarParteSubServicios(1, 1, fechaDesde, (int)Partes.Partes_Estados.REALIZADO, idUsuarioServicioSub);
                            else
                                GenerarParteSubServicios(1, 1, fechaDesde, (int)Partes.Partes_Estados.PENDIENTE_DE_ASIGNACION_DE_TECNICO, idUsuarioServicioSub);
                        }
                        //item.Delete();
                    }

                }
                int cantidad = 0;
                if (chkGeneraPartes.Checked)
                {
                    foreach (DataRow sub in dtSubAgrupados.Rows)
                    {
                        string nombre = sub["nombre_sub"].ToString();
                        DataView dv = dtVista.DefaultView;
                        dv.RowFilter =string.Format("descripcion  = '{0}'",nombre);
                        DataTable dtAgru = dv.ToTable();
                        cantidad = dtAgru.Rows.Count;
                    }
                   /* if (fechaDesde.Date == DateTime.Now.Date)
                        GenerarParteSubServicios(1, cantidad, fechaDesde ,(int)Partes.Partes_Estados.REALIZADO);
                    else
                        GenerarParteSubServicios(1, cantidad, fechaDesde, (int)Partes.Partes_Estados.PENDIENTE_DE_ASIGNACION_DE_TECNICO);*/
                }
            }
        }

        private void GuardarExtra()
        {
            DataRow[] drExtras = dtInterna.Select("Tipo=8");
            if (drExtras.Length > 0)
            {
                foreach (DataRow item in drExtras)
                {

                    precioTarifa = Convert.ToDecimal(item["TarifaProrrateada"]);
                    idVelocidad = 0;
                    idServicioSub = 0;
                    fechaDesde = Convert.ToDateTime(item["Desde"]);
                    fechaHasta = Convert.ToDateTime(item["Hasta"]);
                    idUsuariosServiciosSub = 0;
                    oUsuariosCuentaCorrienteDet.Id_Usuarios_CtaCte = idUsuariosCtacte;
                    oUsuariosCuentaCorrienteDet.Detalles = item["Nombre_Sub"].ToString();
                    oUsuariosCuentaCorrienteDet.Id_Usuarios_Locaciones = idUsuariosLocaciones;
                    oUsuariosCuentaCorrienteDet.Id_Zonas = idZona;
                    oUsuariosCuentaCorrienteDet.Id_Servicios = idServicio;
                    oUsuariosCuentaCorrienteDet.Id_Tipo = idServicioSub;
                    oUsuariosCuentaCorrienteDet.Tipo = "S";
                    oUsuariosCuentaCorrienteDet.Importe_Original = precioTarifa;
                    oUsuariosCuentaCorrienteDet.Importe_Saldo = precioTarifa;
                    oUsuariosCuentaCorrienteDet.Importe_Final = precioTarifa;
                    oUsuariosCuentaCorrienteDet.Id_Usuarios_Servicios = idUsuariosServicios;
                    oUsuariosCuentaCorrienteDet.Id_Velocidades = 0;
                    oUsuariosCuentaCorrienteDet.Id_Velocidades_Tip = 0;
                    oUsuariosCuentaCorrienteDet.Requiere_IP = 0;
                    oUsuariosCuentaCorrienteDet.Cantidad_Periodos = 1;
                    oUsuariosCuentaCorrienteDet.Id_Usuarios_Servicios_sub = idUsuariosServiciosSub;
                    oUsuariosCuentaCorrienteDet.Fecha_Desde = fechaDesde;
                    oUsuariosCuentaCorrienteDet.Periodo_Ano = fechaDesde.Year;
                    oUsuariosCuentaCorrienteDet.Periodo_Mes = fechaDesde.Month;
                    oUsuariosCuentaCorrienteDet.Fecha_Hasta = fechaHasta;
                    oUsuariosCuentaCorrienteDet.Id_bonificacion_Aplicada = 0;
                    oUsuariosCuentaCorrienteDet.Importe_Bonificacion = 0;
                    oUsuariosCuentaCorrienteDet.Nombre_Bonificacion = "";
                    oUsuariosCuentaCorrienteDet.Id_Iva_Alicuotas = 1;
                    if (oComprobantes.Importe > 0)
                        oUsuariosCuentaCorrienteDet.Guardar(oUsuariosCuentaCorrienteDet);
                }
            }
        }

        private void GuardarTodo()
        {

            //CAMBIOS QUE NO LLEVAN GASTOS (BOCAS COMUNES,QUITAS DE SUBSERVICIOS)

            DataRow[] drQuitarSub = dtInterna.Select("Tipo=1 and SubTipo=2");
            var cantQuitaSub = drQuitarSub.Length;
            DataRow[] drQuitaIP = dtInterna.Select("Tipo=5 and SubTipo=3");
            var cantQuitaIP = drQuitaIP.Length;
            DataRow[] drUnidadesComunes = dtInterna.Select("Tipo=7 and SubTipo=1");
            var cantUnidadesComunes = drUnidadesComunes.Length;
            DataRow[] drUnidadesFuncionalesComunesQuitar = dtInterna.Select("Tipo=7 and SubTipo=3");
            var cantBocasComunesQuitar = drUnidadesFuncionalesComunesQuitar.Length;
            DataRow[] drCambiodeVelocidadMenor = dtInterna.Select("Tipo=4 and Tarifa=0");
            var cantVelocidadMenor = drCambiodeVelocidadMenor.Length;
            DataRow[] drUnidadesFuncionalesPacQuitar = dtInterna.Select("Tipo=7 and SubTipo=4");
            var cantBocasPacQuitar = drUnidadesFuncionalesPacQuitar.Length;
            DataRow[] drCambioMeses = dtInterna.Select("Tipo=10");
            var cantCambioMeses = drCambioMeses.Length;
            if ((cantQuitaIP > 0) || (cantQuitaSub > 0) || (cantUnidadesComunes > 0) || (cantBocasComunesQuitar > 0) || (cantBocasPacQuitar > 0) || (cantVelocidadMenor > 0) || (cantCambioMeses > 0))
            {
                if (drQuitarSub.Length > 0)
                {
                    foreach (DataRow item in drQuitarSub)
                    {
                        int idSubServicio = Convert.ToInt32(item["Id_Sub"]);
                        if (fechaDesdeGlobal.Date == DateTime.Now.Date) { 

                            oUsuariosServicios.QuitarSubservicio(idSubServicio);
                            if (chkGeneraPartes.Checked)
                                GenerarParteSubServicios(2, 0,fechaDesde, (int)Partes.Partes_Estados.REALIZADO,idSubServicio);

                            actualizarCass();
                        }
                        else {
                            if (chkGeneraPartes.Checked)
                                GenerarParteSubServicios(2, 0,fechaDesde, (int)Partes.Partes_Estados.PENDIENTE_DE_ASIGNACION_DE_TECNICO, idSubServicio);

                        }
                    }
                }
                if (drQuitaIP.Length > 0)
                {
                    ActualizarIPFija(0);
                    oServiciosIpFija.ActualizarAsignacion(idIp, 0);
                    if (chkGeneraPartes.Checked)
                        GenerarParteCambioIP(2);
                }
                if (drQuitaIP.Length > 0)
                {
                    ActualizarIPFija(0);
                    oServiciosIpFija.ActualizarAsignacion(idIp, 0);
                    if (chkGeneraPartes.Checked)
                        GenerarParteCambioIP(2);
                }
                if (drUnidadesComunes.Length > 0)
                {
                    var cantBocasComunes = Convert.ToInt32(drUnidadesComunes[0]["NumBoca"]);
                    var cantBocasComunesTotal = cantBocasComunes + cantBocasActual;
                    oUsuariosServicios.ActualizarBocas(idUsuariosServicios, cantBocasComunesTotal, 'c', 'a');
                    if (chkGeneraPartes.Checked)
                        GenerarParteUnidadesFuncionales();
                }
                if (drUnidadesFuncionalesComunesQuitar.Length > 0)
                {
                    var cantQuitar = Convert.ToInt32(drUnidadesFuncionalesComunesQuitar[0]["NumBoca"]);
                    oUsuariosServicios.ActualizarBocas(idUsuariosServicios, cantQuitar, 'c', 'q');
                    if (chkGeneraPartes.Checked)
                        GenerarParteUnidadesFuncionales();
                }
                if (drUnidadesFuncionalesPacQuitar.Length > 0)
                {
                    var cantQuitar = Convert.ToInt32(drUnidadesFuncionalesPacQuitar[0]["NumBoca"]);
                    oUsuariosServicios.ActualizarBocas(idUsuariosServicios, cantQuitar, 'p', 'q');
                    if (chkGeneraPartes.Checked)
                        GenerarParteUnidadesFuncionales();
                }
                if (drCambiodeVelocidadMenor.Length > 0)
                {
                    idVelocidad = Convert.ToInt32(drCambiodeVelocidadMenor[0]["Id_Velocidad"]);
                    idServicioSub = Convert.ToInt32(drCambiodeVelocidadMenor[0]["Id_Sub"]);
                    idUsuariosServiciosSub = oUsuariosServicios.Get_Id_Usuarios_Servicios_Sub(idUsuariosServicios, idServicioSub);
                    ActualizarVelocidad();
                    GenerarParteCambioVelocidad();
                }
                if (drCambioMeses.Length > 0)
                {
                    int cantMesesCobro = Convert.ToInt32(drCambioMeses[0]["id_velocidad"]);
                    int cantMesesServicios = Convert.ToInt32(drCambioMeses[0]["id_velocidad_tipo"]);
                    oUsuariosServicios.ActualizarMesesCobroServicios(this.idUsuariosServicios, cantMesesCobro, cantMesesServicios);
                }

            }

            //SI HAY ITEMS  QUE REQUIEAN ABRIR UN MOVIMIENTO DE CTACTE (ITEMS CON TARIFA>0) SE HACXE
            DataRow[] AgregaSub = dtInterna.Select("Tipo=1 and SubTipo=1");
            var cantAgregaSub = AgregaSub.Length;
            DataRow[] AgregarUnidades = dtInterna.Select("Tipo=7 and SubTipo=2");
            var cantAgregaUnidades = AgregarUnidades.Length;
            DataRow[] Velocidades = dtInterna.Select("Tipo=4 and Tarifa>0");
            var cantVelocidades = Velocidades.Length;
            DataRow[] AgregarIp = dtInterna.Select("Tipo=5 and (SubTipo=1 or SubTipo=2)");
            var cantAgregarIp = AgregarIp.Length;
            DataRow[] Extras = dtInterna.Select("Tipo=8");
            var cantExtras = Extras.Length;

            if ((cantAgregaSub > 0) || (cantAgregaUnidades > 0) || (cantVelocidades > 0) || (cantAgregarIp > 0) || (cantExtras > 0))
            {
                precioTarifa = 0;
                foreach (DataRow item in dtInterna.Rows)
                {
                    precioTarifa = precioTarifa + (Convert.ToDecimal(item["TarifaProrrateada"]));
                }
                //OBTENGO NUMERACION DEL COMPROBANTE
                drDatosComprobanteVenta = oComprobatesTipos.GetNumeracion(Convert.ToInt32(Comprobantes_Tipo.Tipo.COMPROBANTE_DEUDA), Puntos_Cobros.Id_Punto);
                numeroComprobante = Convert.ToInt32(drDatosComprobanteVenta["numComprobante"]);
                //GENERO UN COMPROBANTE
                oComprobatesTipos.SetNumeracion(Convert.ToInt32(drDatosComprobanteVenta["idPuntoVenta"]), Convert.ToInt32(Comprobantes_Tipo.Tipo.COMPROBANTE_DEUDA), Convert.ToInt32(drDatosComprobanteVenta["numComprobante"]));
                oComprobantes.Id_Usuarios = Convert.ToInt32(idUsuario);
                oComprobantes.Fecha = DateTime.Today;
                oComprobantes.Punto_Venta = Convert.ToInt32(drDatosComprobanteVenta["numPuntoVenta"]);
                oComprobantes.Id_Comprobantes_Tipo = Convert.ToInt32(Comprobantes_Tipo.Tipo.COMPROBANTE_DEUDA);
                oComprobantes.Numero = Convert.ToInt32(drDatosComprobanteVenta["numComprobante"]);
                oComprobantes.Importe = precioTarifa;
                oComprobantes.Id_Usuarios_Locaciones = Convert.ToInt32(idUsuariosLocaciones);
                oComprobantes.Id_Personal = Personal.Id_Login;
                if (oComprobantes.Importe > 0)
                {
                    oComprobantes.Id = oComprobantes.Guardar(oComprobantes);

                    //GENERO CUANTA CORRIENTE
                    //DATOS DEL COMPROBANTE
                    oUsuariosCuentasCorrientes.Id_Usuarios = idUsuario;
                    oUsuariosCuentasCorrientes.Id_Comprobantes = oComprobantes.Id;
                    oUsuariosCuentasCorrientes.Fecha_Movimiento = DateTime.Today;
                    oUsuariosCuentasCorrientes.Fecha_Desde = dpFechaDesde.Value;
                    oUsuariosCuentasCorrientes.Fecha_Hasta = fechaHasta;
                    string muestra;
                    char pad = '0';
                    muestra = "COMPROBANTE DE DEUDA " + Convert.ToInt32(drDatosComprobanteVenta["numPuntoVenta"]).ToString().PadLeft(4, pad) + "-" + oComprobantes.Numero.ToString().PadLeft(8, pad);
                    oUsuariosCuentasCorrientes.Descripcion = muestra;
                    oUsuariosCuentasCorrientes.Importe_Original = oComprobantes.Importe;
                    oUsuariosCuentasCorrientes.Importe_Punitorio = 0;
                    oUsuariosCuentasCorrientes.Importe_Bonificacion = 0;

                    oUsuariosCuentasCorrientes.Importe_Final = oComprobantes.Importe;
                    oUsuariosCuentasCorrientes.Importe_Saldo = oComprobantes.Importe;
                    oUsuariosCuentasCorrientes.Id_Usuarios_Locacion = idUsuariosLocaciones;
                    oUsuariosCuentasCorrientes.Numero = oComprobantes.Numero.ToString();
                    oUsuariosCuentasCorrientes.Id_Comprobantes_Tipo = Convert.ToInt32(Comprobantes_Tipo.Tipo.COMPROBANTE_DEUDA);
                    oUsuariosCuentasCorrientes.Id_Comprobantes_Ref = 0;
                    oUsuariosCuentasCorrientes.Id_Facturacion = 0;
                    oUsuariosCuentasCorrientes.Generado_facturacion_mensual = Convert.ToInt32(Usuarios_CtaCte.GENERADO_FACTURACION_MENSUAL.NO);
                    oUsuariosCuentasCorrientes.Id_Personal = Personal.Id_Login;
                    oUsuariosCuentasCorrientes.Id_Origen = (int)Usuarios_CtaCte.ORIGEN.COMPLEMENTARIAS;

                    idUsuariosCtacte = oUsuariosCuentasCorrientes.Guardar(oUsuariosCuentasCorrientes);

                }
                precioTotal = precioTarifa;
                //GUARDO LAS VELOCIDADES y GENERO PARTE
                GuardarVelocidad();
                //GUARDO CAMBIO DE VELOCIDADES
                GuardarUnidadesFuncionales();
                //GUARDO IP FIJA y GENERO PARTE
                GuardarIPFija();
                //AGREGAR SUBSERVICIOS
                if (cantAgregaSub > 0)
                    GuardarAgregarSubServicio();
                //GUARDO EXTRAS
                GuardarExtra();
                //if(fechaFactura)

                if (fechaDesdeGlobal.Date == DateTime.Now.Date)
                    actualizarCass();

            }
            if ((cantAgregaSub > 0) || (cantAgregaUnidades > 0) || (cantVelocidades > 0) || (cantAgregarIp > 0) || (cantQuitaIP > 0) || (cantQuitaSub > 0) || (cantUnidadesComunes > 0) || (cantBocasComunesQuitar > 0) || (cantBocasPacQuitar > 0) || (cantVelocidadMenor > 0) || (cantExtras > 0) || (cantCambioMeses > 0))
            {

                if (MessageBox.Show("Operaciones realizadas correctamente. ¿Desea Realizar Otra Operacion?", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    dtInterna.Clear();
                    dtVista.Clear();
                }
                else
                    Close();

            }
        }

        private void QuitarComplementaria()
        {
            if (dgvPresentacion.CurrentCell.RowIndex > -1)
            {

                subId = Convert.ToInt32(dgvPresentacion.SelectedRows[0].Cells["subId"].Value);
                drColeccionRows = dtInterna.Select(string.Format("subId={0}", subId));
                foreach (DataRow item in drColeccionRows)
                    dtInterna.Rows.Remove(item);
                PasarDatatable();
            }
        }

        private void actualizarCass()
        {
            DataTable dtFullData = new DataTable();
            oCass = new Cass(Convert.ToInt32(dtAplicacionesFiltradas.Rows[0]["Id"]));
            dtFullData = oCass.getFullDataUser(idUsuariosServicios, 0, (int)Cass.FILTROS_GET_DATA.ID_USUARIO_SERVICIO);
            string actualizarCassResultado = "";
            oCass.actualizarCass(dtFullData, idUsuario, out actualizarCassResultado);
        }

        private void PasarDatatable()
        {
            decimal tari = 0, tariPro = 0;

            dtVista.Clear();
            #region CambioMeses
            DataRow[] drCambioMeses = dtInterna.Select("Tipo=10");
            if (drCambioMeses.Length > 0)
            {
                var cant = drCambioMeses[0]["NumBoca"];
                subId = Convert.ToInt32(drCambioMeses[0]["subId"]);

                dtVista.Rows.Add(subId, 10, 0, "Cambio de meses de servicio/cobro", 0, cant, 0, DateTime.Now, DateTime.Now);
            }
            #endregion

            #region Bocas
            //calculo la quita de bocas comunes
            DataRow[] drUnidadesFuncionalesComunesQuitar;
            drUnidadesFuncionalesComunesQuitar = dtInterna.Select("Tipo=7 and SubTipo=3");
            if (drUnidadesFuncionalesComunesQuitar.Length > 0)
            {
                var cant = drUnidadesFuncionalesComunesQuitar[0]["NumBoca"];
                subId = Convert.ToInt32(drUnidadesFuncionalesComunesQuitar[0]["subId"]);

                dtVista.Rows.Add(subId, 7, 3, "Quita de bocas comunes", 0, cant, 0, fechaDesde, fechaHasta);
            }
            //calculo la quita de bocas pactadas
            DataRow[] drUnidadesFuncionalesPacQuitar;
            drUnidadesFuncionalesPacQuitar = dtInterna.Select("Tipo=7 and SubTipo=4");
            if (drUnidadesFuncionalesPacQuitar.Length > 0)
            {
                var cant = drUnidadesFuncionalesPacQuitar[0]["NumBoca"];
                subId = Convert.ToInt32(drUnidadesFuncionalesPacQuitar[0]["subId"]);
                dtVista.Rows.Add(subId, 7, 4, "Quita de bocas pactadas", 0, cant, 0, fechaDesde, fechaHasta);
            }
            //calculo agregado de bocas comunes
            DataRow[] UnidadesFuncionalesComunes;
            UnidadesFuncionalesComunes = dtInterna.Select("Tipo=7 and SubTipo=1");
            if (UnidadesFuncionalesComunes.Length > 0)
            {
                var cant = UnidadesFuncionalesComunes[0]["NumBoca"];
                subId = Convert.ToInt32(UnidadesFuncionalesComunes[0]["subId"]);
                dtVista.Rows.Add(subId, 7, 1, "Agregado de bocas comunes", 0, cant, 0, fechaDesde, fechaHasta);
            }
            //Calculo agregado de las bocas pactadas
            precioTarifa = 0;
            decimal precioTotal = 0;
            DataRow[] UnidadesFuncionales;
            DataTable dtSubServiciosContratados = oUsuariosServicios.ListarServiciosSub(idUsuariosServicios);
            UnidadesFuncionales = dtInterna.Select("Tipo=7 and SubTipo=2");
            if (UnidadesFuncionales.Length > 0)
            {
                oCantidad = 0;
                datosServiciosSub = oServiciosSub.ListarPorServicio(idServicio);
                cantidadSubservicios = dtSubServiciosContratados.Rows.Count;
                foreach (DataRow item in UnidadesFuncionales)
                {
                    subId = Convert.ToInt32(item["subId"]);
                    idTipoOperacion = Convert.ToInt32(item["Tipo"]);
                    idTipoSubOperacion = Convert.ToInt32(item["SubTipo"]);
                    oCantidad++;
                    precioTarifa = precioTarifa + (Convert.ToDecimal(item["Tarifa"]));
                    precioTotal = precioTotal + (Convert.ToDecimal(item["TarifaProrrateada"]));
                }
                oCantidad = oCantidad / cantidadSubservicios;
                //AGREGO TODOS LOS ITEMS "AGREGADOS DE BOCA" A LA TABLA VISTA (DATAGRIDVIEW)
                DataRow dr = dtVista.NewRow();

                dtVista.Rows.Add(subId, 7, 2, "Agregado de bocas pactadas", precioTarifa, cantBocasPacNueva, precioTotal, fechaDesde, fechaHasta);
            }
            #endregion
            #region CambioVelocidad
            //Calculo cambio de velocidades


            DataRow[] drows = dtInterna.Select("tipo=4");
            tari = 0;
            tariPro = 0;
            if (drows.Length > 0)
            {
                foreach (DataRow item2 in drows)
                {
                    tari = tari + Convert.ToDecimal(item2["Tarifa"]);
                    nombreSubServicio = item2["Nombre_Sub"].ToString();
                    idServicioSub = Convert.ToInt32(item2["Id_sub"]);
                    tariPro = tariPro + Convert.ToDecimal(item2["TarifaProrrateada"]);
                    subId = Convert.ToInt32(item2["subId"]);
                    fechaDesde = Convert.ToDateTime(item2["Desde"]);
                    fechaHasta = Convert.ToDateTime(item2["Hasta"]);
                }
                DataRow drVista = dtVista.NewRow();
                drVista["subId"] = subId;
                drVista["Tipo"] = 1;
                drVista["Cantidad"] = 1;

                drVista["SubTipo"] = 1;
                drVista["Descripcion"] = nombreSubServicio;
                drVista["Unitario"] = tari;
                drVista["Final"] = tariPro;
                drVista["FechaDesde"] = fechaDesde;
                drVista["FechaHasta"] = fechaHasta;
                drVista["id_sub"] = idServicioSub;
                dtVista.Rows.Add(drVista);
            }
            #endregion
            #region CambioIp
            //Calcular cambio de ip
            DataRow[] drCambioIP;
            var contadorAgregar = 0;
            var contadorQuitar = 0;
            Decimal precioParte = 0;
            decimal precioConf = 0;
            decimal precioProrateadoTotal = 0;
            precioTotal = 0;
            drCambioIP = dtInterna.Select("(Tipo=5 and SubTipo=3 )or (Tipo=5 and SubTipo=2) or (Tipo=5 and SubTipo=1)");
            if (drCambioIP.Length > 0)
            {
                precioTarifa = 0;
                foreach (DataRow item in drCambioIP)
                {
                    idTipoSub = Convert.ToInt32(item["SubTipo"]);
                    fechaDesde = Convert.ToDateTime(item["Desde"]);
                    fechaHasta = Convert.ToDateTime(item["Hasta"]);
                    if (idTipoSub != 3)
                    {
                        subId = Convert.ToInt32(item["subId"]);
                        idTipoOperacion = Convert.ToInt32(item["Tipo"]);
                        idTipoSubOperacion = Convert.ToInt32(item["SubTipo"]);
                        if (idTipoSub == 1)
                            precioParte = Convert.ToDecimal(item["Tarifa"]);
                        if (idTipoSub == 2)
                            precioConf = Convert.ToDecimal(item["Tarifa"]);
                        precioTarifa = precioTarifa + Convert.ToDecimal(item["Tarifa"]);
                        precioProrateadoTotal = precioProrateadoTotal + Convert.ToDecimal(item["TarifaProrrateada"]);
                        contadorAgregar++;
                    }
                    else
                        contadorQuitar++;
                }
                oCantidad = 1;
                if (contadorAgregar > 0)
                {
                    if (idModalidad != 3)
                        dtVista.Rows.Add(subId, 5, 0, "Agregar IP", precioTarifa, oCantidad, precioProrateadoTotal, fechaDesde, fechaHasta);
                    else
                        dtVista.Rows.Add(subId, 5, 0, "Agregar IP", precioTarifa, oCantidad, precioProrateadoTotal, fechaDesde, fechaHasta);
                }
                if (contadorQuitar > 0)
                    dtVista.Rows.Add(subId, 5, 2, "QUITAR IP", 0, 1, 0, fechaDesde, fechaHasta);

            }
            #endregion
            #region AgregarQuitarSub
            //calcular agregar/quitar subservicios7
            //perimero los que son para quitar
            DataRow[] drquitarSub = dtInterna.Select("Tipo=1 and SubTipo=2");
            if (drquitarSub.Length > 0)
            {
                foreach (DataRow item in drquitarSub)
                {
                    nombreSubServicio = item["Nombre_Sub"].ToString();
                    subId = Convert.ToInt32(item["subId"]);
                    idServicioSub = Convert.ToInt32(item["id_sub"]);
                    dtVista.Rows.Add(subId, 1, 2, nombreSubServicio, 0, 1, 0, fechaDesde, fechaHasta, idServicioSub);
                }
            }
            //subServicios para agregar
            DataRow[] dragregarSub = dtInterna.Select("Tipo=1 and SubTipo=1");
            if (dragregarSub.Length > 0)
            {
                var resultGrupo = from row in dragregarSub.AsEnumerable()
                                  group row by row.Field<Int32>("subId") into grp
                                  select new
                                  {
                                      GrupoServicio = grp.Key,
                                  };

                int idGrupoServicio = 0;
                foreach (var item in resultGrupo)
                {
                    tari = 0;
                    tariPro = 0;
                    if (idGrupoServicio != item.GrupoServicio)
                    {
                        DataRow[] drowServiciosAgreg = dtInterna.Select(string.Format("subId={0}", item.GrupoServicio));
                        if (drowServiciosAgreg.Length > 0)
                        {
                            foreach (DataRow item2 in drowServiciosAgreg)
                            {
                                if (Convert.ToInt32(item2["subId"]) == item.GrupoServicio)
                                {
                                    tari = tari + Convert.ToDecimal(item2["Tarifa"]);
                                    nombreSubServicio = item2["Nombre_Sub"].ToString();
                                    idServicioSub = Convert.ToInt32(item2["Id_sub"]);
                                    tariPro = tariPro + Convert.ToDecimal(item2["TarifaProrrateada"]);
                                    fechaHasta = Convert.ToDateTime(item2["Hasta"]);
                                    fechaDesde = Convert.ToDateTime(item2["Desde"]);
                                }
                            }
                            idGrupoServicio = item.GrupoServicio;
                            DataRow drVista = dtVista.NewRow();
                            drVista["subId"] = item.GrupoServicio;
                            drVista["Tipo"] = 1;
                            drVista["SubTipo"] = 1;
                            drVista["Cantidad"] = 1;
                            drVista["Descripcion"] = nombreSubServicio;
                            drVista["Unitario"] = tari;
                            drVista["Final"] = tariPro;
                            drVista["FechaDesde"] = dpFechaDesde.Value;
                            drVista["FechaHasta"] = fechaHasta;
                            drVista["id_sub"] = idServicioSub;
                            dtVista.Rows.Add(drVista);
                        }
                    }
                }
            }
            #endregion
            #region Extras
            foreach (DataRow item in dtVista.Rows)
            {
                if (Convert.ToInt32(item["Tipo"]) == 8)
                    item.Delete();
            }
            dtVista.AcceptChanges();
            DataRow[] drExtras = dtInterna.Select("Tipo=8");
            if (drExtras.Length > 0)
            {

                DataRow drVista = dtVista.NewRow();
                foreach (DataRow item in drExtras)
                {
                    drVista["subId"] = Convert.ToInt32(item["subId"]);
                    drVista["Tipo"] = 8;
                    drVista["SubTipo"] = Convert.ToInt32(item["SubTipo"]);
                    drVista["Descripcion"] = item["Nombre_Sub"].ToString();
                    drVista["Unitario"] = Convert.ToDecimal(item["tarifa"]);
                    drVista["Cantidad"] = 1;
                    drVista["Final"] = Convert.ToDecimal(item["tarifa"]);
                    drVista["FechaDesde"] = DateTime.Now; ;
                    drVista["FechaHasta"] = DateTime.Now;
                    drVista["Id_Sub"] = 0;
                    dtVista.Rows.Add(drVista);
                }
            }

            #endregion
            dgvPresentacion.DataSource = dtVista;
            //FormatearGrilla();
        }

        private void UnidadesFuncionales()
        {
            dtSubServiciosContratados = oUsuariosServicios.ListarServiciosSub(idUsuariosServicios);
            cantidadSubservicios = datosServiciosSub.Rows.Count;
            if (cantidadSubservicios == 0)
            {
                MessageBox.Show("Error al leer datos del subServicio: Unidades Funcionales", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                switch (idModalidad)
                {
                    case 2:
                        try
                        {
                            precioTarifa = 0;
                            foreach (DataRow item in dtSubServiciosContratados.Rows)
                            {
                                idServicioSub = Convert.ToInt32(item["id_servicios_sub"]);
                                requiereIp = Convert.ToInt32(item["requiere_ip"]);
                                precioTarifaSub = oServiciosTarifasSub.ListarPrecioSub(idTipoServicio, idServicio, idServicioSub, idTarifa, idTipoFacturacion);
                                if (requiereIp == 1)
                                    precioTarifa = BuscarVelocidadActual(idServicioSub, idTarifa, idTipoFacturacion);
                                precioTarifa = precioTarifa + precioTarifaSub;


                            }

                            cantBocasActual = Convert.ToInt32(datosUsuariosServicios.Rows[0]["cant_bocas"]);
                            cantBocasPacActual = Convert.ToInt32(datosUsuariosServicios.Rows[0]["cant_bocas_pac"]);
                            oFrmUnidadesFuncionales = new frmUnidadesFuncionales(cantBocasActual, cantBocasPacActual, precioTarifa);
                            oPop = new frmPopUp();
                            oPop.Formulario = oFrmUnidadesFuncionales;
                            oPop.Maximizar = false;
                            if (oPop.ShowDialog() == DialogResult.OK)
                            {
                                precioTarifa = 0;
                                precioTarifaSub = 0;
                                cantBocasPacNueva = oFrmUnidadesFuncionales.cantidadBocasPactadasP;
                                cantBocasComunNueva = oFrmUnidadesFuncionales.cantidadBocasComunesP;
                                //VERIFICO SI HAY BOCAS COMUNES PARA QUITAR
                                //SI HAY LAS AGREGO A LA DT DE OPERAICONES (dtinterna)
                                if (cantBocasComunNueva < 0)
                                {
                                    cantBocasComunesMenos = cantBocasComunNueva * (-1);
                                    DataRow dr = dtInterna.NewRow();
                                    subId++;
                                    dr["subId"] = subId;
                                    dr["Tipo"] = 7;
                                    dr["SubTipo"] = 3;
                                    dr["Id_Sub"] = 0;
                                    dr["Nombre_Sub"] = "Quitado de bocas comunes";
                                    dr["Id_Velocidad"] = 0;
                                    dr["Id_Velocidad_Tipo"] = 0;
                                    dr["NumBoca"] = cantBocasComunesMenos;
                                    dr["Id_Tipo_Sub"] = 0;
                                    dr["Tarifa"] = 0;
                                    dr["Id_Ip"] = 0;
                                    dr["Desde"] = dpFechaDesde.Value;
                                    dr["Hasta"] = fechaFactura;
                                    dr["Tarifa"] = 0;
                                    dr["TarifaProrrateada"] = 0;
                                    dr["Id_Usu_Sub"] = 0;

                                    dtInterna.Rows.Add(dr);
                                }
                                //VERIFICO SI HAY BOCAS PACTADAS PARA SACAR
                                //SI HAY LAS AGREGO A LA DT DE OPERAICONES (dtinterna)

                                //unidaddes comunachas
                                if (cantBocasComunNueva > 0)
                                {
                                    DataRow dr = dtInterna.NewRow();
                                    subId++;
                                    dr["subId"] = subId;
                                    dr["Tipo"] = 7;
                                    dr["SubTipo"] = 1;
                                    dr["Id_Sub"] = 0;
                                    dr["Nombre_Sub"] = "Agregado de boca comun";
                                    dr["Id_Velocidad"] = 0;
                                    dr["Id_Velocidad_Tipo"] = 0;
                                    dr["NumBoca"] = cantBocasComunNueva;
                                    dr["Id_Tipo_Sub"] = 0;
                                    dr["Tarifa"] = 0;
                                    dr["Id_Ip"] = 0;
                                    dr["Desde"] = dpFechaDesde.Value;
                                    dr["Hasta"] = fechaFactura;
                                    dr["Tarifa"] = 0;
                                    dr["TarifaProrrateada"] = 0;
                                    dr["Id_Usu_Sub"] = 0;

                                    dtInterna.Rows.Add(dr);
                                }


                                //unidades pactadas
                                decimal tarifaProrrateada = 0;
                                if (cantBocasPacNueva >= cantBocasPacActual)
                                {
                                    for (var x = 0; x < cantBocasPacNueva; x++)
                                    {
                                        fechaDesde = dpFechaDesde.Value;
                                        foreach (DataRow item in dtSubServiciosContratados.Rows)
                                        {
                                            fechaHasta = Convert.ToDateTime(datosUsuariosServicios.Rows[0]["fecha_factura"]);
                                            fechaInicio = dpFechaDesde.Value;
                                            DateTime fecha = fechaInicio;
                                            int cantDerecho = 0;
                                            while (fecha <= fechaHasta)
                                            {
                                                idServicioSubTipo = Convert.ToInt32(item["Id_Servicios_Sub_Tipos"]);
                                                idServicioSub = Convert.ToInt32(item["id_servicios_sub"]);
                                                nombreSubServicio = item["Descripcion"].ToString();
                                                requiereIp = Convert.ToInt32(item["requiere_ip"]);
                                                oServiciosTarifas.Fecha_Actual = fecha;
                                                idTarifa = oServiciosTarifas.getTarifa();
                                                precioTarifa = oServiciosTarifasSub.getPrecio(idTarifa, idServicio, idServicioSub, "S", idTipoFacturacion);
                                                periodoDesde = fecha;
                                                int cantDias = DateTime.DaysInMonth(fecha.Year, fecha.Month);
                                                periodoHasta = new DateTime(fecha.Year, fecha.Month, cantDias);
                                                if (fecha <= fechaHasta)
                                                {
                                                    if ((precioTarifa == 0) && (requiereIp == 1))
                                                        precioTarifa = BuscarVelocidadActual(idServicioSub, idTarifa, idTipoFacturacion);

                                                }
                                                else
                                                {
                                                    precioTarifa = 0;
                                                }

                                                //precioTarifa = ProratearMes(precioTarifa + oServiciosTarifasSub.ListarPrecioSub(idTipoServicio, idServicio, idServicioSub, idTarifa, idTipoFacturacion));

                                                DataRow dr = dtInterna.NewRow();
                                                dr["subId"] = subId;
                                                dr["Tipo"] = 7;
                                                dr["SubTipo"] = 2;
                                                dr["Id_Sub"] = idServicioSub;
                                                dr["Nombre_Sub"] = nombreSubServicio;
                                                dr["Id_Velocidad"] = 0;
                                                dr["Id_Velocidad_Tipo"] = 0;
                                                dr["NumBoca"] = (x) + 1;
                                                dr["Id_Tipo_Sub"] = idServicioSubTipo;
                                                dr["Tarifa"] = precioTarifa;
                                                dr["Id_Ip"] = 0;
                                                dr["Desde"] = periodoDesde;
                                                dr["Hasta"] = periodoHasta;
                                                if (periodoDesde.Day != 1)
                                                {
                                                    tarifaProrrateada = ProratearMes(precioTarifa);
                                                    dr["TarifaProrrateada"] = tarifaProrrateada;
                                                }
                                                else
                                                    dr["TarifaProrrateada"] = precioTarifa;

                                                dr["Id_Usu_Sub"] = Convert.ToInt32(item["id"]);
                                                if ((idServicioSubTipo == 4) && (cantDerecho == 0))
                                                {
                                                    dtInterna.Rows.Add(dr);
                                                    cantDerecho++;
                                                }
                                                else
                                                {
                                                    if (idServicioSubTipo != 4)
                                                        dtInterna.Rows.Add(dr);
                                                }
                                                fecha = new DateTime(fecha.Year, fecha.Month, 1);
                                                tarifaProrrateada = 0;
                                                fecha = fecha.AddMonths(1);
                                            }
                                        }
                                    }

                                }
                                else
                                {
                                    if (cantBocasPacNueva < 0)
                                    {
                                        DataRow dr = dtInterna.NewRow();
                                        subId++;
                                        dr["subId"] = subId;
                                        dr["Tipo"] = 7;
                                        dr["SubTipo"] = 4;
                                        dr["Id_Sub"] = 0;
                                        dr["Nombre_Sub"] = "Quitado de bocas pactadas";
                                        dr["Id_Velocidad"] = 0;
                                        dr["Id_Velocidad_Tipo"] = 0;
                                        dr["NumBoca"] = cantBocasPacNueva * (-1);
                                        dr["Id_Tipo_Sub"] = 0;
                                        dr["Tarifa"] = 0;
                                        dr["Id_Ip"] = 0;
                                        dr["Desde"] = dpFechaDesde.Value;
                                        dr["Hasta"] = fechaFactura;
                                        dr["Tarifa"] = 0;
                                        dr["TarifaProrrateada"] = 0;
                                        dr["Id_Usu_Sub"] = 0;

                                        dtInterna.Rows.Add(dr);
                                    }
                                }
                            }
                        }
                        catch (Exception c)
                        {
                            MessageBox.Show("Hubo un error durante el proceso: AGREGAR UNIDADES PACTADAS: POR MES", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        break;
                    case 3:
                        try
                        {
                            precioTarifa = 0;
                            foreach (DataRow item in dtSubServiciosContratados.Rows)
                            {
                                idServicioSub = Convert.ToInt32(item["id_servicios_sub"]);
                                requiereIp = Convert.ToInt32(item["requiere_ip"]);
                                precioTarifaSub = oServiciosTarifasSub.ListarPrecioSub(idTipoServicio, idServicio, idServicioSub, idTarifa, idTipoFacturacion);
                                if (requiereIp == 1)
                                    precioTarifa = BuscarVelocidadActual(idServicioSub, idTarifa, idTipoFacturacion);
                                precioTarifa = precioTarifa + precioTarifaSub;
                            }

                            cantBocasActual = Convert.ToInt32(datosUsuariosServicios.Rows[0]["cant_bocas"]);
                            cantBocasPacActual = Convert.ToInt32(datosUsuariosServicios.Rows[0]["cant_bocas_pac"]);
                            oFrmUnidadesFuncionales = new frmUnidadesFuncionales(cantBocasActual, cantBocasPacActual, precioTarifa);
                            oPop = new frmPopUp();
                            oPop.Formulario = oFrmUnidadesFuncionales;
                            oPop.Maximizar = false;
                            if (oPop.ShowDialog() == DialogResult.OK)
                            {
                                precioTarifa = 0;
                                precioTarifaSub = 0;
                                cantBocasPacNueva = oFrmUnidadesFuncionales.cantidadBocasPactadasP;
                                cantBocasComunNueva = oFrmUnidadesFuncionales.cantidadBocasComunesP;
                                //VERIFICO SI HAY BOCAS COMUNES PARA QUITAR
                                //SI HAY LAS AGREGO A LA DT DE OPERAICONES (dtinterna)
                                if (cantBocasComunNueva < 0)
                                {
                                    cantBocasComunesMenos = cantBocasComunNueva * (-1);
                                    DataRow dr = dtInterna.NewRow();
                                    subId++;
                                    dr["subId"] = subId;
                                    dr["Tipo"] = 7;
                                    dr["SubTipo"] = 3;
                                    dr["Id_Sub"] = 0;
                                    dr["Nombre_Sub"] = "Quitado de bocas comunes";
                                    dr["Id_Velocidad"] = 0;
                                    dr["Id_Velocidad_Tipo"] = 0;
                                    dr["NumBoca"] = cantBocasComunesMenos;
                                    dr["Id_Tipo_Sub"] = 0;
                                    dr["Tarifa"] = 0;
                                    dr["Id_Ip"] = 0;
                                    dr["Desde"] = dpFechaDesde.Value;
                                    dr["Hasta"] = fechaFactura;
                                    dr["Tarifa"] = 0;
                                    dr["TarifaProrrateada"] = 0;

                                    dtInterna.Rows.Add(dr);
                                }
                                //VERIFICO SI HAY BOCAS PACTADAS PARA SACAR
                                //SI HAY LAS AGREGO A LA DT DE OPERAICONES (dtinterna)

                                //unidaddes comunachas
                                if (cantBocasComunNueva > 0)
                                {
                                    DataRow dr = dtInterna.NewRow();
                                    subId++;
                                    dr["subId"] = subId;
                                    dr["Tipo"] = 7;
                                    dr["SubTipo"] = 1;
                                    dr["Id_Sub"] = 0;
                                    dr["Nombre_Sub"] = "Agregado de boca comun";
                                    dr["Id_Velocidad"] = 0;
                                    dr["Id_Velocidad_Tipo"] = 0;
                                    dr["NumBoca"] = cantBocasComunNueva;
                                    dr["Id_Tipo_Sub"] = 0;
                                    dr["Tarifa"] = 0;
                                    dr["Id_Ip"] = 0;
                                    dr["Desde"] = dpFechaDesde.Value;
                                    dr["Hasta"] = fechaFactura;
                                    dr["Tarifa"] = 0;
                                    dr["TarifaProrrateada"] = 0;

                                    dtInterna.Rows.Add(dr);
                                }


                                //unidades pactadas
                                if ((cantBocasPacNueva + cantBocasPacActual) >= cantBocasPacActual)
                                {
                                    for (var x = 0; x < cantBocasPacNueva; x++)
                                    {
                                        fechaDesde = dpFechaDesde.Value;
                                        foreach (DataRow item in dtSubServiciosContratados.Rows)
                                        {
                                            int mesesServicio = 0;
                                            DataTable dtEspeciales = new DataTable();
                                            dtEspeciales = oServiciosTarifasSubEsp.GetServicios_Tarifas_Sub_Esp(idTarifa, idServicio, idTipoFacturacion);
                                            DataRow[] datosSubservicioEsp = dtEspeciales.Select("tiposub='S' and idtipodesub=1");
                                            mesesServicio = Convert.ToInt32(datosSubservicioEsp[0]["meses_servicio"]);
                                            mesesCobro = Convert.ToInt32(datosSubservicioEsp[0]["meses_cobro"]);
                                            int r = 1;
                                            fechaHasta = Convert.ToDateTime(datosUsuariosServicios.Rows[0]["fecha_factura"]);
                                            fechaInicio = dpFechaDesde.Value;
                                            DateTime fecha = fechaInicio;
                                            int cantDerecho = 0;

                                            while (r <= mesesCobro)
                                            {

                                                idServicioSubTipo = Convert.ToInt32(item["Id_Servicios_Sub_Tipos"]);
                                                idServicioSub = Convert.ToInt32(item["id_servicios_sub"]);
                                                nombreSubServicio = item["Descripcion"].ToString();
                                                requiereIp = Convert.ToInt32(item["requiere_ip"]);
                                                oServiciosTarifas.Fecha_Actual = fecha;
                                                idTarifa = oServiciosTarifas.getTarifa();
                                                precioTarifa = oServiciosTarifasSub.getPrecio(idTarifa, idServicio, idServicioSub, "S", idTipoFacturacion);
                                                periodoDesde = fecha;
                                                int cantDias = DateTime.DaysInMonth(fecha.Year, fecha.Month);
                                                periodoHasta = new DateTime(fecha.Year, fecha.Month, cantDias);
                                                if (fecha <= fechaHasta)
                                                {
                                                    if ((precioTarifa == 0) && (requiereIp == 1))
                                                        precioTarifa = BuscarVelocidadActual(idServicioSub, idTarifa, idTipoFacturacion);
                                                }
                                                else
                                                    precioTarifa = 0;
                                                //precioTarifa = ProratearMes(precioTarifa + oServiciosTarifasSub.ListarPrecioSub(idTipoServicio, idServicio, idServicioSub, idTarifa, idTipoFacturacion));

                                                DataRow dr = dtInterna.NewRow();
                                                dr["subId"] = subId;
                                                dr["Tipo"] = 7;
                                                dr["SubTipo"] = 2;
                                                dr["Id_Sub"] = idServicioSub;
                                                dr["Nombre_Sub"] = nombreSubServicio;
                                                dr["Id_Velocidad"] = 0;
                                                dr["Id_Velocidad_Tipo"] = 0;
                                                dr["NumBoca"] = (x) + 1;
                                                dr["Id_Tipo_Sub"] = idServicioSubTipo;
                                                dr["Tarifa"] = precioTarifa;
                                                dr["Id_Ip"] = 0;
                                                dr["Desde"] = periodoDesde;
                                                dr["Hasta"] = periodoHasta;
                                                dr["TarifaProrrateada"] = precioTarifa;
                                                if ((idServicioSubTipo == 4) && (cantDerecho == 0))
                                                {
                                                    dtInterna.Rows.Add(dr);
                                                    cantDerecho++;
                                                }
                                                else
                                                {
                                                    if (idServicioSubTipo != 4)
                                                        dtInterna.Rows.Add(dr);
                                                }
                                                fecha = new DateTime(fecha.Year, fecha.Month, 1);
                                                fecha = fecha.AddMonths(1);
                                                r++;
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    if (cantBocasPacNueva < 0)
                                    {
                                        //lalal
                                        DataRow dr = dtInterna.NewRow();
                                        subId++;
                                        dr["subId"] = subId;
                                        dr["Tipo"] = 7;
                                        dr["SubTipo"] = 4;
                                        dr["Id_Sub"] = 0;
                                        dr["Nombre_Sub"] = "Quitado de bocas pactadas";
                                        dr["Id_Velocidad"] = 0;
                                        dr["Id_Velocidad_Tipo"] = 0;
                                        dr["NumBoca"] = cantBocasPacNueva * -1;
                                        dr["Id_Tipo_Sub"] = 0;
                                        dr["Tarifa"] = 0;
                                        dr["Id_Ip"] = 0;
                                        dr["Desde"] = dpFechaDesde.Value;
                                        dr["Hasta"] = fechaFactura;
                                        dr["Tarifa"] = 0;
                                        dr["TarifaProrrateada"] = 0;
                                        dr["Id_Usu_Sub"] = 0;

                                        dtInterna.Rows.Add(dr);
                                    }
                                }
                            }
                        }
                        catch (Exception c)
                        {
                            MessageBox.Show("Hubo un error durante el proceso: AGREGAR SUBSERVICIO MODALIDAD: POR PERIODO" + c.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        break;
                }
                PasarDatatable();

            }
        }

        private decimal BuscarVelocidadActual(int Id_Sub_Servicio, int Id_Tarifa_Vigante, int idTipoFacturacion)
        {
            DataTable dtVelocidad = new DataTable();
            DataTable dtTarifasVel = new DataTable();
            DataRow[] drVelocidades;
            dtVelocidad = oServiciosVelocidades.ListarVelocidadesUsuarios(idUsuariosServicios);
            if (dtVelocidad.Rows.Count > 0)
            {

                var idVelocidad = 0;
                var idTipoVelocidad = 0;
                decimal TarifaVelActual = 0;
                idVelocidad = Convert.ToInt32(dtVelocidad.Rows[0]["id_servicios_velocidades"]);
                idTipoVelocidad = Convert.ToInt32(dtVelocidad.Rows[0]["id_servicios_velocidades_tip"]);
                dtTarifasVel = oServiciosTarifasSub.ListarTarifasVelocidades(Id_Sub_Servicio, Id_Tarifa_Vigante, idTipoFacturacion, idTipoVelocidad);
                drVelocidades = dtTarifasVel.Select(string.Format("id_servicios_velocidad={0}", idVelocidad));
                TarifaVelActual = Convert.ToDecimal(drVelocidades[0]["importe"]);
                return TarifaVelActual;
            }
            else
            {
                MessageBox.Show("Error al cargar informacion de velocidad", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }

        private decimal Proratear(decimal tarifa, DateTime fechaDesde, DateTime fechaHasta)
        {
            //calcular periodos
            int meses = 0;
            DateTime fechaDesdeAux = fechaDesde;
            while (fechaDesde <= fechaHasta)
            {
                fechaDesde = fechaDesde.AddMonths(1);
                meses++;
            }
            var diaHoy = fechaDesdeAux.Day;
            var mesHoy = fechaDesdeAux.Month;
            var yearHoy = fechaDesdeAux.Year;
            var diasFaltantes = 0;
            decimal tarifaNueva = 0;
            var cantDiasMes = 0;
            cantDiasMes = DateTime.DaysInMonth(yearHoy, mesHoy);

            diasFaltantes = cantDiasMes - diaHoy;
            for (int x = 0; x < meses; x++)
            {
                if ((diaHoy > 1) && (x == 0))
                {
                    tarifaNueva = (tarifa / cantDiasMes);
                    tarifaNueva = tarifaNueva * diasFaltantes;
                    TimeSpan cantDias = (fechaHasta - fechaDesde);
                    int diferencia = cantDias.Days;
                    int diastotales = diferencia - diaHoy;

                }
                else
                    tarifaNueva = tarifaNueva + tarifa;

            }
            return decimal.Round(tarifaNueva, 2, MidpointRounding.AwayFromZero);
        }

        private decimal ProratearMes(decimal tarifa)
        {
            var diaHoy = fechaDesde.Day;
            decimal tarifaNueva = 0;
            if (diaHoy != 1)
            {
                var mesHoy = fechaDesde.Month;
                var yearHoy = fechaDesde.Year;
                var diasFaltantes = 0;
                var cantDiasMes = 0;
                if (prorrateaHastaDias == 0)
                    cantDiasMes = DateTime.DaysInMonth(yearHoy, mesHoy);
                else
                    cantDiasMes = prorrateaHastaDias;
                diasFaltantes = cantDiasMes - diaHoy;
                tarifaNueva = (tarifa / cantDiasMes);
                tarifaNueva = tarifaNueva * diasFaltantes;
            }
            else
                tarifaNueva = tarifa;

            return decimal.Round(tarifaNueva, 2, MidpointRounding.AwayFromZero);
        }

        private decimal ProrratearHastaDiaX(decimal tarifa, int year, int mes, int cantDias)
        {
            decimal tarifaNueva = 0;
            int cantidadDiasMes = DateTime.DaysInMonth(year, mes);

            tarifaNueva = (tarifa / cantidadDiasMes);
            tarifaNueva = tarifaNueva * cantDias;

            return tarifaNueva;
        }

        private int SeleccionarFecha()
        {
            frmFecha = new Form();
            oPop = new frmPopUp();
            frmFecha.Controls.Add(pnFechaDesde);
            pnFechaDesde.Dock = DockStyle.Top;
            pnFechaDesde.Visible = true;
            frmFecha.AutoSize = false;
            frmFecha.StartPosition = FormStartPosition.CenterScreen;
            frmFecha.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            frmFecha.MaximumSize = new System.Drawing.Size(pnFechaDesde.Width, pnFechaDesde.Height);
            frmFecha.MinimumSize = new System.Drawing.Size(pnFechaDesde.Width, pnFechaDesde.Height);
            frmFecha.FormBorderStyle = FormBorderStyle.None;
            oPop.Formulario = frmFecha;
            if (oPop.ShowDialog() == DialogResult.OK)
            {
                fechaDesde = dpFechaDesde.Value;
                return 1;
            }
            else
                return 0;

        }

        private int VerificarTieneIp()
        {
            int idIpFija = 0;
            int vel = 0;
            datosUsuariosServiciosSub = oUsuariosServicios.ListarServiciosSub(idUsuariosServicios);
            foreach (DataRow item in datosUsuariosServiciosSub.Rows)
            {
                idServicioSubTipo = Convert.ToInt32(item["id_servicios_sub_tipos"]);
                vel = Convert.ToInt32(item["id_servicios_velocidades"]);
                if ((idServicioSubTipo == 1) && (vel != 0))
                    idIpFija = Convert.ToInt32(item["Id_Ip_fija"]);
            }
            return idIpFija;
        }
        private void PonerDatosUsuarios()
        {
            LBApellido.Text = Usuarios.CurrentUsuario.Apellido.Trim() + " , " + Usuarios.CurrentUsuario.Nombre.Trim() + " [" + Usuarios.CurrentUsuario.Codigo.ToString().Trim() + "]";
            LBNumero_documento.Text = "Documento : (" + Usuarios.CurrentUsuario.Tipo_Documento + ") Nro " + Usuarios.CurrentUsuario.Numero_Documento;
            lbcuit.Text = "C. Iva : (" + Usuarios.CurrentUsuario.Condicion_Iva + ") Nro " + Usuarios.CurrentUsuario.CUIT;
            lbcorreo.Text = Usuarios.CurrentUsuario.Correo_Electronico;
        }

        #region INICIO

        private void ComenzarCarga()
        {
            if (idUsuariosServicios != 0)
            {
                hilo = new Thread(new ThreadStart(CargarDatos));
                hilo.Start();

            }
            else
            {
                if (MessageBox.Show("Debe seleccionar un servicio del usuario", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Stop) == DialogResult.OK)
                    this.Close();
            }
        }

        private void CargarDatos()
        {
            datosUsuariosServicios = oUsuariosServicios.Traer_datos_usuarios_servicios(idUsuariosServicios);

            if (datosUsuariosServicios.Rows.Count > 0)
            {
                idServicio = Convert.ToInt32(datosUsuariosServicios.Rows[0]["id_servicios"]);
                dtServicio = oServicios.BuscarDatosServicio(idServicio);
                if (dtServicio.Rows.Count > 0)
                {
                    idModalidad = Convert.ToInt32(dtServicio.Rows[0]["id_Servicios_modalidad"]);
                    dataSubservicios = oServiciosVelocidades.ListarVelocidadesUsuarios(idUsuariosServicios);
                    myDel MD = new myDel(AsignarDatos);
                    this.Invoke(MD, new object[] { });
                }
                else
                    MessageBox.Show("Error al leer datos del servicio: Cargar Datos", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("Error al leer datos del servicio del usuario", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }


        private void AsignarDatos()
        {
            try
            {
                if (datosUsuariosServicios.Rows.Count > 0)
                {
                    datosServicios = oServicios.BuscarDatosServicio(idServicio);
                    fechaInicio = Convert.ToDateTime(datosUsuariosServicios.Rows[0]["fecha_inicio"]);
                    if (datosServicios.Rows.Count > 0)
                    {
                        requiereVel = datosServicios.Rows[0]["requiere_velocidad"].ToString();
                        requiereEquipo = datosServicios.Rows[0]["requiere_equipo"].ToString();
                        nombreServicio = dtServicio.Rows[0]["Descripcion"].ToString();
                        idModalidad = Convert.ToInt32(dtServicio.Rows[0]["id_servicios_modalidad"]);
                        DateTime fechaInicioServicio = Convert.ToDateTime(datosUsuariosServicios.Rows[0]["fecha_inicio"]);
                        forzarInicioMes = Convert.ToInt32(datosServicios.Rows[0]["forzar_inicio_mes"]);
                        if (requiereVel == "SI")
                        {
                            if (idModalidad != (int)Servicios._Modalidad.DIA)
                            {
                                nombreVelocidadActual = dataSubservicios.Rows[0]["velocidad"].ToString();
                                lblVelosidad.Text = nombreVelocidadActual + " MB";
                            }
                            else
                                lblVelosidad.Text = "Prepago sin velocidad asignada";
                        }
                        else
                            lblVelosidad.Text = "";

                        if (idModalidad == (int)Servicios._Modalidad.PERIODO || idModalidad == (int)Servicios._Modalidad.PERIODO_CERRADO_POR_MES)
                            btnMesesSerCob.Enabled = true;
                        else
                            btnMesesSerCob.Enabled = false;

                        LblNombreServicio.Text = nombreServicio;
                        requiereTarjeta = datosServicios.Rows[0]["requiere_tarjeta"].ToString();
                        idUsuario = Convert.ToInt32(datosUsuariosServicios.Rows[0]["id_usuarios"]);
                        idUsuariosLocaciones = Convert.ToInt32(datosUsuariosServicios.Rows[0]["id_usuarios_locaciones"]);
                        idTipoServicio = Convert.ToInt32(datosUsuariosServicios.Rows[0]["id_servicios_tipo"]);
                        fechaHasta = Convert.ToDateTime(datosUsuariosServicios.Rows[0]["Fecha_Factura"]);
                        fechaFactura = Convert.ToDateTime(datosUsuariosServicios.Rows[0]["Fecha_Factura"]);
                        datosServiciosSub = oServiciosSub.ListarPorServicio(idServicio);

                        idZona = Convert.ToInt32(datosUsuariosServicios.Rows[0]["id_zonas"]);
                        //Forma de Facturacion
                        idFormaFacturacion = Convert.ToInt32(oConfiguracion.GetValor_Decimal("Id_Tipo_Facturacion"));
                        idTipoFacturacion = Convert.ToInt32(datosUsuariosServicios.Rows[0]["Id_Tipo_Facturacion"]);


                        drCambioVelocidad = datosServiciosSub.Select("requiere_ip=1");
                        if (drCambioVelocidad.Length > 0)
                        {
                            requiereIp = 1;
                            requiereIpNoVariable = 1;
                        }
                        else
                        {
                            requiereIp = 0;
                            requiereIpNoVariable = 0;
                        }
                        if (oConfiguracion.GetValor_N("CobroIp") == 1)
                            btnIpFija.Visible = true;
                        else
                            btnIpFija.Visible = false;


                    }
                    else
                        MessageBox.Show("Error al leer datos del servicio", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                //Tarifa Actual
                oServiciosTarifas.Fecha_Actual = fechaInicio;
                oServiciosTarifas.Fecha_Actual = DateTime.Now;
                idTarifa = oServiciosTarifas.getTarifa();
                if ((idModalidad != (int)Servicios._Modalidad.MENSUAL) || (requiereVel == "SI"))
                {
                    dtEspeciales = oServiciosTarifasSubEsp.GetServicios_Tarifas_Sub_Esp(idTarifa, idServicio, idTipoFacturacion);
                    if (dtEspeciales.Rows.Count > 0)
                    {
                        DataRow[] datosSubservicioEsp = dtEspeciales.Select("tiposub='S' and idtipodesub=1");
                        mesesServicio = Convert.ToInt32(datosSubservicioEsp[0]["meses_servicio"]);
                        mesesCobro = Convert.ToInt32(datosSubservicioEsp[0]["meses_cobro"]);
                    }
                    else
                        MessageBox.Show("Hubo un error al leer datos de tarifas especiales", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            catch (Exception c)
            {
                MessageBox.Show("Hubo un error durante el proceso: ASIGNAR DATOS:" + c.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        #endregion
        #endregion
    }
}
//27112019MAXI CAMPO ID_ORIGEN