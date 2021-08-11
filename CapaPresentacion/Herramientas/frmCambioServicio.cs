using CapaNegocios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace CapaPresentacion.Herramientas
{
    public partial class frmCambioServicio : Form
    {
        #region PROPIEDADES

        public Boolean huboCambios = false;

        private Servicios oServicio = new Servicios();
        private Tipo_Facturacion oTipoFac = new Tipo_Facturacion();
        private Configuracion oConfiguracion = new Configuracion();
        private Zonas oZonas = new Zonas();
        private Servicios_Categorias oCategorias = new Servicios_Categorias();
        private Servicios_Tarifas oServicioTarifa = new Servicios_Tarifas();
        private Servicios_Tarifas_Sub oServiciosTarifasSub = new Servicios_Tarifas_Sub();
        private Localidades oLocalidades = new Localidades();
        private Comprobantes oComprobantes = new Comprobantes();
        private Comprobantes_Tipo oComprobantesTipo = new Comprobantes_Tipo();
        private Usuarios_Ctacte_Det_Extra oUsuariosCtaCteDetExtra = new Usuarios_Ctacte_Det_Extra();
        private Provincias oProvincias = new Provincias();
        private Bonificaciones oBonificaciones = new Bonificaciones();
        private Usuarios_Servicios oUsuariosServicios = new Usuarios_Servicios();
        private Servicios_Condiciones oServiciosCondiciones = new Servicios_Condiciones();
        private Partes_Solicitudes oPartesFallas = new Partes_Solicitudes();
        private Equipos_Tarjetas oEquiposTarjetas = new Equipos_Tarjetas();
        private Usuarios_Servicios_Novedades oUsuariosServiciosNovedades = new Usuarios_Servicios_Novedades();
        private Usuarios_Locaciones oUsuariosLocaciones = new Usuarios_Locaciones();
        private Plasticos_Usuarios oPlasticosUsuarios = new Plasticos_Usuarios();
        private Equipos oEquipos = new Equipos();
        private Thread hilo;
        private delegate void myDel();

        private DataTable dtServicios = new DataTable();
        private DataTable dtZonas = new DataTable();
        private DataTable dtCategorias = new DataTable();
        private DataTable dtLocalidades = new DataTable();
        private DataTable dtSubServicios = new DataTable();
        private DataTable dtComprobantesIva = new DataTable();
        private DataTable dtTiposDoc = Tablas.DataTipoDNI;
        private DataTable dtProvincias = new DataTable();
        private DataTable dtServAContratar = new DataTable();
        private DataTable dtServiciosContratados = new DataTable();
        private DataTable dtServABonificar = new DataTable();
        private DataTable dtServiciosActivos = new DataTable();
        private DataTable dtPartesFallas = new DataTable();
        private DataTable dtUsuariosEquipos = new DataTable();
        private DataTable dtServBonificaciones = new DataTable();
        private DataTable dtServBonificacionesDetalles = new DataTable();
        private DataTable dtDatosNovedades = new DataTable();

        private DataRow drDatosComprobanteVenta;
        private DataRow drDatosSubServicios;

        private List<Int32> Lista_Id_Partes = new List<Int32>();

        private Tipo_Facturacion.Id_Tipo_Facturacion tipoFacturacion;

        private decimal ImporteIPFija, subTotal, importeTotal, totalBonificacion, cantBocas, cantBocasPactadas;
        private int Config_Agenda;
        private int idTipoFacturacion;
        private int idServicioSeleccionado = 0;
        private int idServiciosTarifas;
        private int IdTablaServicioUnico = 1;
        private int IdTablaBonificacionSub;
        private int IdTablaBonificacion;
        private int idTipoServicioViejo;
        private DateTime fechaFactura, fechaInicio, fechaFin, fechaConexion;
        private bool agregaServicio = false,pasaEquipos=false;
        #endregion

        public frmCambioServicio()
        {
            InitializeComponent();
        }
        #region [METODOS]
        private void bloquearControles()
        {
            foreach (Control item in spMain.Panel1.Controls)
                item.Enabled = false;

        }

        private void desbloquearControles()
        {
            foreach (Control item in spMain.Panel1.Controls)
                item.Enabled = true;

        }

        private void comenzarCarga()
        {
            dgvContrato.DataSource = null;
            dgvServiciosContratados.DataSource = null;
            dgvServiciosContratados.Columns.Clear();
            bloquearControles();
            hilo = new Thread(new ThreadStart(cargarDatos));
            hilo.Start();
        }

        private void cargarDatos()
        {
            try
            {
                idServiciosTarifas = oServicioTarifa.getTarifaId();
                tipoFacturacion = (Tipo_Facturacion.Id_Tipo_Facturacion)oConfiguracion.GetValor_N("id_tipo_facturacion");
                ImporteIPFija = Convert.ToDecimal(oConfiguracion.GetValor_Decimal("Costo_IP"));
                Config_Agenda = oConfiguracion.GetValor_N("Agenda_Trabajo");

                switch (tipoFacturacion)
                {
                    case Tipo_Facturacion.Id_Tipo_Facturacion.POR_ZONAS:
                        dtZonas = oZonas.Listar();
                        dtLocalidades = oZonas.ListarLocZonas(0);
                        dtServicios = oTipoFac.GetServicios();
                        dtSubServicios = oServiciosTarifasSub.Listar(idServiciosTarifas);

                        dtLocalidades.Rows.Add(0, 0, 0, "[SELECCIONAR]");
                        break;
                    case Tipo_Facturacion.Id_Tipo_Facturacion.POR_CATEGORIAS:
                        dtLocalidades = oLocalidades.Listar();
                        dtCategorias = oCategorias.Listar();
                        dtCategorias.Rows.Add(0, "[SELECCIONAR]");

                        DataView dvC = dtCategorias.DefaultView;
                        dvC.Sort = "Nombre ASC";
                        dtCategorias = dvC.ToTable(true);
                        dtServicios = oTipoFac.GetServicios();
                        dtSubServicios = oServiciosTarifasSub.Listar(idServiciosTarifas);
                        dtLocalidades.Rows.Add(0, 0, "[SELECCIONAR]");
                        break;
                }

                DataView dv = dtLocalidades.DefaultView;
                dv.Sort = tipoFacturacion == Tipo_Facturacion.Id_Tipo_Facturacion.POR_ZONAS ? "Localidad ASC" : "Nombre ASC";
                dtLocalidades = dv.ToTable(true);

                dtComprobantesIva = oComprobantes.ListarTipoIVA();
                dtProvincias = oProvincias.Listar();

                dtServAContratar = new DataTable();
                DataColumn colId = new DataColumn("Id", typeof(Int32));
                colId.AutoIncrement = true;
                colId.AutoIncrementSeed = 1;
                colId.AutoIncrementStep = 1;

                dtServAContratar.Columns.Add("Id_Servicios", typeof(Int32));
                dtServAContratar.Columns.Add("Servicio", typeof(String));
                dtServAContratar.Columns.Add("Item", typeof(String));
                dtServAContratar.Columns.Add("Importe", typeof(Decimal));
                dtServAContratar.Columns.Add("Nombre", typeof(String));
                dtServAContratar.Columns.Add("Bonificacion", typeof(Decimal));
                dtServAContratar.Columns.Add("Modo", typeof(String));
                dtServAContratar.Columns.Add("Cantidad", typeof(Int32));
                dtServAContratar.Columns.Add("CantidadPac", typeof(Int32));
                dtServAContratar.Columns.Add("Total", typeof(Decimal));
                dtServAContratar.Columns.Add("Id_Servicios_Categoria", typeof(Int32));
                dtServAContratar.Columns.Add("Categoria", typeof(String));
                dtServAContratar.Columns.Add("Id_Tipo", typeof(Int32));
                dtServAContratar.Columns.Add("Tipo", typeof(String));
                dtServAContratar.Columns.Add("Fecha_Conexion", typeof(DateTime));
                dtServAContratar.Columns.Add("Fecha_InicioServ", typeof(DateTime));
                dtServAContratar.Columns.Add("Fecha_FinServ", typeof(DateTime));
                dtServAContratar.Columns.Add("Id_Servicios_Velocidad", typeof(Int32));
                dtServAContratar.Columns.Add("Id_Servicios_Velocidad_Tipo", typeof(Int32));
                dtServAContratar.Columns.Add("Requiere_IP", typeof(Int32));
                dtServAContratar.Columns.Add("Id_Usuarios_Servicios", typeof(Int32));
                dtServAContratar.Columns.Add("Id_Bonificacion_Esp", typeof(Int32));
                dtServAContratar.Columns.Add("Id_Bonificacion", typeof(Int32));
                dtServAContratar.Columns.Add("Dias_Bonif", typeof(Int32));
                dtServAContratar.Columns.Add("Meses", typeof(Int32));
                dtServAContratar.Columns.Add("Id_Servicios_Tipos", typeof(Int32));
                dtServAContratar.Columns.Add("Id_Servicios_Grupos", typeof(Int32));
                dtServAContratar.Columns.Add("Id_Eliminar", typeof(Int32));
                dtServAContratar.Columns.Add("Id_Servicios_Tipo_Sub", typeof(Int32));
                dtServAContratar.Columns.Add("Id_Tarjeta", typeof(Int32));
                dtServAContratar.Columns.Add("Id_Usuarios_Servicios_Sub", typeof(Int32));
                dtServAContratar.Columns.Add("Id_Bonificacion_contratacion", typeof(Int32));

                //--agregado por nueva modificación
                dtServAContratar.Columns.Add("Meses_Servicio", typeof(Int32));
                dtServAContratar.Columns.Add("Id_Servicios_Modalidad", typeof(Int32));
                //---------------------------------

                DataColumn colSel = new DataColumn("Seleccion", typeof(Boolean));
                colSel.DefaultValue = true;
                dtServAContratar.Columns.Add(colSel);

                dtServAContratar.Columns.Add(colId);

                dtServAContratar.Columns.Add("Id_Contador_Servicios", typeof(Int32));

                dtServiciosContratados = new DataTable();
                dtServiciosContratados.Columns.Add("Id_Servicios", typeof(Int32));
                dtServiciosContratados.Columns.Add("Id_Servicios_Categoria", typeof(Int32));
                dtServiciosContratados.Columns.Add("Fecha_Conexion", typeof(DateTime));
                dtServiciosContratados.Columns.Add("Fecha_InicioServ", typeof(DateTime));
                dtServiciosContratados.Columns.Add("Fecha_FinServ", typeof(DateTime));
                dtServiciosContratados.Columns.Add("Id_Servicios_Tipo", typeof(Int32));
                dtServiciosContratados.Columns.Add("Modo", typeof(String));
                dtServiciosContratados.Columns.Add("Cantidad", typeof(Int32));
                dtServiciosContratados.Columns.Add("CantidadPac", typeof(Int32));
                dtServiciosContratados.Columns.Add("Modalidad", typeof(Int32));
                dtServiciosContratados.Columns.Add("Dias_Bonif", typeof(Int32));
                dtServiciosContratados.Columns.Add("Meses", typeof(Int32));
                dtServiciosContratados.Columns.Add("Id_Eliminar", typeof(Int32));
                dtServiciosContratados.Columns.Add("Id_Servicios_Tipo_Sub", typeof(Int32));

                //--agregado por nueva modificación
                dtServiciosContratados.Columns.Add("Meses_Servicio", typeof(Int32));

                //---------------------------------
                DataColumn colIdTarifaEsp = new DataColumn("id_tarifa_sub_esp", typeof(Int32));
                colIdTarifaEsp.DefaultValue = 0;
                dtServAContratar.Columns.Add(colIdTarifaEsp);
                dtServABonificar = oBonificaciones.GenerarDtSubServicios();



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
            if (tipoFacturacion == Tipo_Facturacion.Id_Tipo_Facturacion.POR_ZONAS)
                lblModalidad.Text = "Localidad:";

            cboTipoFacturacion.DataSource = tipoFacturacion == Tipo_Facturacion.Id_Tipo_Facturacion.POR_ZONAS ? dtLocalidades : dtCategorias;
            cboTipoFacturacion.DisplayMember = tipoFacturacion == Tipo_Facturacion.Id_Tipo_Facturacion.POR_ZONAS ? "Localidad" : "Nombre";
            cboTipoFacturacion.ValueMember = tipoFacturacion == Tipo_Facturacion.Id_Tipo_Facturacion.POR_ZONAS ? "Id_Localidad" : "Id";



            // cboTipoFacturacion.SelectedValue = ;

            //CARGA LOS SERVICIOS QUE YA TIENE EL USUARIO
            dtServiciosActivos = oUsuariosServicios.ListarServiciosYSubServiciosActivos(Usuarios.CurrentUsuario.Id);
            if (dtServiciosActivos.Rows.Count > 0)
            {
                DataColumn dcTieneDeb = new DataColumn();
                dcTieneDeb.DataType = typeof(int);
                dcTieneDeb.ColumnName = "debito";
                dcTieneDeb.DefaultValue = 0;
                dtServiciosActivos.Columns.Add(dcTieneDeb);
                int deb = 0;
                int usuSer = 0;
                Plasticos_Usuarios oPlasticosUsuarios = new Plasticos_Usuarios();
                DataTable dtDatosPlasticoUsuario;
                
                foreach (DataRow item in dtServiciosActivos.Rows)
                {
                    usuSer = Convert.ToInt32(item["id_usuario_servicio"]);
                    dtDatosPlasticoUsuario = oPlasticosUsuarios.BuscarPlasticosServicio(usuSer);
                    if (dtDatosPlasticoUsuario.Rows.Count > 0)
                    {
                        item["debito"] = Convert.ToInt32(dtDatosPlasticoUsuario.Rows[0]["id"]);
                    }
                }

                dgvServiciosContratados.DataSource = dtServiciosActivos;
                DataGridViewLinkColumn columnaCambiar = new DataGridViewLinkColumn();
                columnaCambiar.Text = "Cambiar servicio";
                columnaCambiar.DataPropertyName = "cambiar";
                columnaCambiar.Name = "cambiar";
                columnaCambiar.LinkColor = Color.Red;
                columnaCambiar.VisitedLinkColor = Color.Red;
                columnaCambiar.UseColumnTextForLinkValue = true;
                columnaCambiar.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                columnaCambiar.HeaderText = "";
                columnaCambiar.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader;
                dgvServiciosContratados.Columns.Add(columnaCambiar);
                FormatearGrillaNueva();
            }

            spMain.Panel2.Enabled = false;

            llenarDatos();
            if(oConfiguracion.GetValor_N("Id_Tipo_Facturacion")==(int)Tipo_Facturacion.Id_Tipo_Facturacion.POR_CATEGORIAS)
                cboTipoFacturacion.Enabled = true;
        }

        private void llenarDatos()
        {
            try
            {
                Usuarios.Current_IdUsuarioLocacion = Convert.ToInt32(dgvServiciosContratados.SelectedRows[0].Cells["id_locacion"].Value);

                oUsuariosLocaciones = oUsuariosLocaciones.GetLocacion(Usuarios.Current_IdUsuarioLocacion);

                // cboTipoFacturacion.SelectedValue = Convert.ToInt32(dgvServiciosContratados.SelectedRows[0].Cells["id_tipo_facturacion"].Value);
                if(oConfiguracion.GetValor_N("Id_Tipo_Facturacion") ==(int)Tipo_Facturacion.Id_Tipo_Facturacion.POR_CATEGORIAS)
                    cboTipoFacturacion.SelectedValue = Convert.ToInt32(dgvServiciosContratados.SelectedRows[0].Cells["id_tipo_facturacion"].Value);
                else
                    cboTipoFacturacion.SelectedValue = oUsuariosLocaciones.Id_Localidades;

                idTipoServicioViejo = Convert.ToInt32(dgvServiciosContratados.SelectedRows[0].Cells["id_servicio_tipo"].Value);
                fechaFactura = Convert.ToDateTime(dgvServiciosContratados.SelectedRows[0].Cells["fecha_factura"].Value);
                fechaInicio = Convert.ToDateTime(dgvServiciosContratados.SelectedRows[0].Cells["fecha_inicio"].Value);
                fechaFin = Convert.ToDateTime(dgvServiciosContratados.SelectedRows[0].Cells["fecha_fin"].Value);
                cantBocas = Convert.ToInt32(dgvServiciosContratados.SelectedRows[0].Cells["cant_bocas"].Value);
                cantBocasPactadas = Convert.ToInt32(dgvServiciosContratados.SelectedRows[0].Cells["cant_bocas_pac"].Value);
                fechaConexion = Convert.ToDateTime(dgvServiciosContratados.SelectedRows[0].Cells["fecha_conexion"].Value);
            }
            catch
            {
            }
        }

        private void FormatearGrillaNueva()
        {

            foreach (DataGridViewColumn item in dgvServiciosContratados.Columns)
                item.Visible = false;

            dgvServiciosContratados.Columns["servicio_tipo"].Visible = true;
            dgvServiciosContratados.Columns["servicio"].Visible = true;
            dgvServiciosContratados.Columns["fecha_Factura"].Visible = true;
            dgvServiciosContratados.Columns["estado"].Visible = true;
            dgvServiciosContratados.Columns["cambiar"].Visible = true;
            dgvServiciosContratados.Columns["categoria"].Visible = true;

            foreach (DataGridViewRow item in dgvServiciosContratados.Rows)
            {
                if (Convert.ToInt32(item.Cells["id_usuario_servicio_sub"].Value) > 0)
                    item.Visible = false;
                item.Height = 30;
            }
            desbloquearControles();
        }

        private void AgregarServicio(Int32 IdServicios)
        {


            DataRow[] DrServicios = dtServicios.Select(String.Format("Id_Servicios = {0}", IdServicios));
            if (agregaServicio == false)
            {

                if (VerificarCondicionesServicio(IdServicios))
                {
                    using (frmPopUp frm = new frmPopUp())
                    {
                        Partes_Trabajo.frmParteConexion_Auxiliar frmAux = new Partes_Trabajo.frmParteConexion_Auxiliar();

                        int IdServicioModalidad = Convert.ToInt32(DrServicios[0]["Id_Servicios_Modalidad"]);
                        int IdServicioGrupos = Convert.ToInt32(DrServicios[0]["Id_Servicios_Grupos"]);
                        int IdServicioTipos = Convert.ToInt32(DrServicios[0]["Id_Servicios_Tipos"]);
                        int IdServicioTipoSub = Convert.ToInt32(DrServicios[0]["Id_Servicios_Tipos"]); //MARCELO

                        string Servicio = DrServicios[0]["Descripcion"].ToString();
                        bool ForzarInicioServicio = DrServicios[0]["Fecha_Inicio_Servicio"].ToString() == "1" ? true : false;
                        bool ForzarInicioMes = DrServicios[0]["Forzar_Inicio_Mes"].ToString() == "1" ? true : false; ;


                        //si el servicio es por periordo mes cerrado busco en los datos de las tarifas la fecha hasta
                        DateTime FechaHastaPeriodoCerrado;
                        if (IdServicioModalidad == Convert.ToInt32(Servicios._Modalidad.PERIODO_CERRADO_POR_MES))
                        {
                            oServicioTarifa.Fecha_Actual = DateTime.Now;
                            //DataTable dtDatosTarifaPadre = oTarifaEsp.GetServicios_Tarifas_Sub_Esp(Id_Tarifa_Vigente, IdServicios, idSubServicioPadre, idTipoFacturacion);

                        }

                        DateTime fecha;
                        if (dgvContrato.Rows.Count > 0)
                            fecha = Convert.ToDateTime(dgvContrato.Rows[0].Cells["Fecha_InicioServ"].Value);
                        else
                            fecha = DateTime.Now;
                        frmAux.FechaConexionServicio = fecha;
                        frmAux.FechaInicioServicio = fecha;
                        frmAux.IdServicios = IdServicios;
                        frmAux.IdServiciosTipos = IdServicioTipos;
                        frmAux.Servicio = Servicio;
                        frmAux.ForzarFechaInicioServicio = ForzarInicioServicio;
                        frmAux.ForzarInicioMes = ForzarInicioMes;
                        frmAux.TipoFacturacion = this.tipoFacturacion;
                        frmAux.IdTipoFacturacion = idTipoFacturacion;
                        frmAux.RequiereEquipo = DrServicios[0]["Requiere_Equipo"].ToString() == "SI" ? true : false;
                        frmAux.RequiereVelocidades = DrServicios[0]["Requiere_Velocidad"].ToString() == "SI" ? true : false;
                        frmAux.IdServiciosModalidad = IdServicioModalidad;
                        frmAux.DiasBonificacion = Convert.ToInt32(DrServicios[0]["Dias_Bonificacion"].ToString());
                        frm.Formulario = frmAux;
                        frm.Maximizar = false;

                        if (frm.ShowDialog() == DialogResult.OK)
                        {
                            frmAux.FechaConexionServicio = fechaConexion;
                            frmAux.FechaInicioServicio = fechaInicio;
                            frmAux.FechaFinServicio = Convert.ToDateTime(dgvServiciosContratados.SelectedRows[0].Cells["fecha_factura"].Value);
                            DataRow DrServContratado = dtServiciosContratados.NewRow();
                            DrServContratado["Id_Servicios"] = IdServicios;
                            DrServContratado["Id_Servicios_Categoria"] = frmAux.IdServiciosCategorias;
                            DrServContratado["Fecha_Conexion"] = frmAux.FechaConexionServicio;
                            if (IdServicioModalidad == Convert.ToInt32(Servicios._Modalidad.PERIODO_CERRADO_POR_MES))
                            {
                                DrServContratado["Fecha_InicioServ"] = frmAux.FechaDesdePeriodoCerrado;
                                DrServContratado["Fecha_FinServ"] = frmAux.FechaHastaPeriodoCerrado;
                            }
                            else
                            {
                                DrServContratado["Fecha_InicioServ"] = fechaInicio;
                                DrServContratado["Fecha_FinServ"] = fechaFin;
                            }
                            DrServContratado["Fecha_FinServ"] = Convert.ToDateTime(dgvServiciosContratados.SelectedRows[0].Cells["fecha_factura"].Value);

                            DrServContratado["Id_Servicios_Tipo"] = IdServicioTipos;
                            DrServContratado["Modo"] = frmAux.Modo;
                            DrServContratado["Cantidad"] = frmAux.Cantidad;
                            DrServContratado["CantidadPac"] = cantBocas;
                            DrServContratado["Modalidad"] = cantBocasPactadas;
                            DrServContratado["Dias_Bonif"] = 0;

                            //busco en la configuracion del sistema si se pueden modficar los meses cobro y meses servicio, si se puede tomo en cuenta los del frmaux (como avc) sino los que estan en la tarifa (como atcco)
                            oServicioTarifa.Fecha_Actual = frmAux.FechaInicioServicio;
                            idServiciosTarifas = oServicioTarifa.getTarifaId();
                            int modificaMeses = oConfiguracion.GetValor_N("CambioMeses");
                            if (modificaMeses == Convert.ToInt32(Configuracion.CAMBIO_MESES.NO))
                            {
                                //--agregado por nueva modificación

                                DrServContratado["Meses"] = Convert.ToUInt32(DrServicios[0]["Id_Servicios_Modalidad"]) == Convert.ToInt32(Servicios._Modalidad.MENSUAL) ? 1 : oServiciosTarifasSub.getMesesCobro(IdServicios, idTipoFacturacion, idServiciosTarifas, frmAux.IdServiciosVelocidades, frmAux.IdServiciosVelocidadesTipo);
                                //Tarifas.Fecha_Actual = frmAux.FechaInicioServicio;
                                //Id_Tarifa_Vigente = Id_Servicios_Tarifas;
                                DrServContratado["Meses_servicio"] = Convert.ToInt32(DrServicios[0]["Id_Servicios_Modalidad"]) == Convert.ToInt32(Servicios._Modalidad.MENSUAL) ? 1 : oServiciosTarifasSub.getMesesServicio(IdServicios, idTipoFacturacion, idServiciosTarifas, frmAux.IdServiciosVelocidades, frmAux.IdServiciosVelocidadesTipo);
                            }
                            else
                            {
                                DrServContratado["Meses"] = Convert.ToUInt32(DrServicios[0]["Id_Servicios_Modalidad"]) == Convert.ToInt32(Servicios._Modalidad.MENSUAL) ? 1 : frmAux.MesesCobro;
                                //Tarifas.Fecha_Actual = frmAux.FechaInicioServicio;
                                //Id_Tarifa_Vigente = Id_Servicios_Tarifas;
                                DrServContratado["Meses_servicio"] = Convert.ToInt32(DrServicios[0]["Id_Servicios_Modalidad"]) == Convert.ToInt32(Servicios._Modalidad.MENSUAL) ? 1 : frmAux.MesesServicio;
                            }
                            //----------------------------------

                            DrServContratado["Id_Eliminar"] = IdTablaServicioUnico;

                            dtServiciosContratados.Rows.Add(DrServContratado);
                            dtServiciosContratados.AcceptChanges();

                            DataRow DrServAContratar = dtServAContratar.NewRow();
                            DrServAContratar["Id_Servicios"] = IdServicios;
                            DrServAContratar["Servicio"] = Servicio;
                            DrServAContratar["Item"] = string.Empty;
                            DrServAContratar["Importe"] = 0;
                            DrServAContratar["Bonificacion"] = 0;
                            DrServAContratar["Modo"] = string.Empty;
                            DrServAContratar["Cantidad"] = 0;
                            DrServAContratar["CantidadPac"] = 0;
                            DrServAContratar["Total"] = 0;
                            DrServAContratar["Categoria"] = frmAux.CategoriaSeleccionada;
                            DrServAContratar["Id_Tipo"] = 0;
                            DrServAContratar["Tipo"] = "S";
                            DrServAContratar["Fecha_Conexion"] = frmAux.FechaConexionServicio;
                            DrServAContratar["Fecha_InicioServ"] = frmAux.FechaInicioServicio;
                            //DrServAContratar["Fecha_FinServ"] = Convert.ToInt32(DrServContratado["Meses_servicio"]) > 1 ? Convert.ToDateTime(frmAux.FechaFinServicio).AddMonths(Convert.ToInt32(DrServContratado["Meses_servicio"])).AddDays(-1) : frmAux.FechaFinServicio;
                            try
                            {
                                if (Convert.ToInt32(DrServContratado["Meses_servicio"]) > 1)
                                    DrServAContratar["Fecha_FinServ"] = frmAux.FechaInicioServicio.AddMonths(Convert.ToInt32(DrServContratado["Meses_servicio"])).AddDays(-1);
                                else
                                    DrServAContratar["Fecha_FinServ"] = frmAux.FechaFinServicio;
                            }
                            catch { DrServAContratar["Fecha_FinServ"] = frmAux.FechaFinServicio; }
                            if (IdServicioModalidad == Convert.ToInt32(Servicios._Modalidad.PERIODO_CERRADO_POR_MES))
                            {
                                DrServAContratar["Fecha_FinServ"] = frmAux.FechaHastaPeriodoCerrado;
                                DrServAContratar["Fecha_InicioServ"] = frmAux.FechaDesdePeriodoCerrado;

                            }
                            if (IdServicioModalidad == Convert.ToInt32(Servicios._Modalidad.PERIODO_CERRADO_POR_DIA))
                            {
                                DrServAContratar["Fecha_FinServ"] = frmAux.FechaFinServicio;

                            }
                            DrServContratado["Fecha_FinServ"] = Convert.ToDateTime(dgvServiciosContratados.SelectedRows[0].Cells["fecha_factura"].Value);

                            DrServAContratar["Id_Servicios_Velocidad"] = 0;
                            DrServAContratar["Id_Servicios_Velocidad_Tipo"] = 0;
                            DrServAContratar["Requiere_IP"] = 0;
                            DrServAContratar["Id_Usuarios_Servicios"] = 0;
                            DrServAContratar["Id_Bonificacion_Esp"] = 0;
                            DrServAContratar["Id_Bonificacion"] = 0;
                            DrServAContratar["Dias_Bonif"] = 0;
                            DrServAContratar["Meses"] = 0;
                            DrServAContratar["Id_Servicios_Tipos"] = IdServicioTipos;
                            DrServAContratar["Id_Servicios_Grupos"] = IdServicioGrupos;
                            DrServAContratar["Id_Eliminar"] = IdTablaServicioUnico;

                            //--agregado por nueva modificación
                            DrServAContratar["Id_Servicios_Modalidad"] = IdServicioModalidad;
                            //----------------------------------------

                            dtServAContratar.Rows.Add(DrServAContratar);

                            DataRow[] DataRowSubServicios;
                            string requiereVelocidad = "NO";
                            //si la modalidad del servicio es por dia y no requiere internet tengo que filtrar, en el dt subservicios, por canti dias
                            if (IdServicioModalidad != Convert.ToInt32(Servicios._Modalidad.DIA))
                            {
                                DataTable dtDatosServicio = oServicio.BuscarDatosServicio(IdServicios);
                                if (dtDatosServicio.Rows.Count > 0)
                                    requiereVelocidad = dtDatosServicio.Rows[0]["Requiere_Velocidad"].ToString();

                                if (IdServicioModalidad == Convert.ToInt32(Servicios._Modalidad.PERIODO_CERRADO_POR_DIA) && (requiereVelocidad == "NO"))
                                    DataRowSubServicios = dtSubServicios.Select(String.Format("Id_Servicios = {0} AND Id_Tipo_Facturacion = {1} and dias_desde={2}", IdServicios, idTipoFacturacion, frmAux.CantDiasPeriodoCerrado));
                                else if (IdServicioModalidad == Convert.ToInt32(Servicios._Modalidad.PERIODO_CERRADO_POR_MES) && (requiereVelocidad == "NO"))
                                    DataRowSubServicios = dtSubServicios.Select(String.Format("Id_Servicios = {0} AND Id_Tipo_Facturacion = {1} and id_servicios_tarifas_sub_esp={2}", IdServicios, idTipoFacturacion, frmAux.idTarifaPaquete));
                                else
                                    DataRowSubServicios = dtSubServicios.Select(String.Format("Id_Servicios = {0} AND Id_Tipo_Facturacion = {1} ", IdServicios, idTipoFacturacion));
                            }
                            else
                                DataRowSubServicios = oTipoFac.GetServiciosSubPorTipo(idTipoFacturacion, IdServicios).Select("Id_Servicios_Sub > 0");

                            DataTable dtServiciosPorTipo = oTipoFac.Listar(idTipoFacturacion);


                            if (DataRowSubServicios.Length > 0)
                            {
                                for (int i = 0; i < DataRowSubServicios.Length; i++)
                                {
                                    DataRow[] drSubTipo = dtServiciosPorTipo.Select(String.Format("Id_Servicios_Sub = {0}", Convert.ToInt32(DataRowSubServicios[i]["Id_Servicios_Sub"])));

                                    if (drSubTipo.Length == 0)
                                        continue;


                                    if (IdServicioModalidad != Convert.ToInt32(Servicios._Modalidad.DIA))
                                        if (frmAux.RequiereVelocidades == true && Convert.ToInt32(DataRowSubServicios[i]["velocidad"]) > 0 && (Convert.ToInt32(DataRowSubServicios[i]["Id_Servicios_Velocidad"]) != frmAux.IdServiciosVelocidades || Convert.ToInt32(DataRowSubServicios[i]["Id_Servicio_Velocidad_Tip"]) != frmAux.IdServiciosVelocidadesTipo))
                                            continue;

                                    DrServAContratar = dtServAContratar.NewRow();
                                    DrServAContratar["Id_Servicios"] = IdServicios;
                                    DrServAContratar["Servicio"] = Servicio;

                                    if (IdServicioModalidad != Convert.ToInt32(Servicios._Modalidad.DIA))
                                        DrServAContratar["Item"] = frmAux.RequiereVelocidades == true ? String.Format("{0} {1} MB {2}", DataRowSubServicios[i]["SubServicio"].ToString(), frmAux.VelocidadSeleccionada, frmAux.VelocidadTipoSeleccionada) : DataRowSubServicios[i]["SubServicio"].ToString();
                                    else
                                        DrServAContratar["Item"] = String.Format("{0} {1} MB {2}", DataRowSubServicios[i]["servicios_sub"], frmAux.VelocidadSeleccionada, frmAux.VelocidadTipoSeleccionada);

                                    if (frmAux.ContrataIPFija == 1)
                                        DrServAContratar["Item"] = DrServAContratar["Item"] + " IP FIJA";

                                    DrServAContratar["Importe"] = 0;
                                    DrServAContratar["Bonificacion"] = 0;
                                    DrServAContratar["Modo"] = frmAux.Modo;
                                    DrServAContratar["Cantidad"] = frmAux.Cantidad;
                                    DrServAContratar["CantidadPac"] = frmAux.CantidadPactada;
                                    DrServAContratar["Total"] = 0;
                                    DrServAContratar["Categoria"] = string.Empty;
                                    DrServAContratar["Id_Tipo"] = DataRowSubServicios[i]["Id_Servicios_Sub"].ToString(); ;
                                    DrServAContratar["Tipo"] = "S";
                                    // DrServAContratar["Fecha_Conexion"] = DBNull.Value;
                                    // DrServAContratar["Fecha_InicioServ"] = DBNull.Value;
                                    if (IdServicioModalidad == Convert.ToInt32(Servicios._Modalidad.PERIODO_CERRADO_POR_MES) && (requiereVelocidad == "NO"))
                                    {
                                        DrServAContratar["Fecha_InicioServ"] = frmAux.FechaDesdePeriodoCerrado;
                                        DrServAContratar["Fecha_FinServ"] = frmAux.FechaHastaPeriodoCerrado;
                                    }
                                    else
                                    {
                                        DrServAContratar["Fecha_InicioServ"] = frmAux.FechaInicioServicio;
                                        DrServAContratar["Fecha_FinServ"] = frmAux.FechaFinServicio;

                                    }
                                    DrServAContratar["Fecha_Conexion"] = frmAux.FechaConexionServicio;
                                    DrServContratado["Fecha_FinServ"] = Convert.ToDateTime(dgvServiciosContratados.SelectedRows[0].Cells["fecha_factura"].Value);


                                    DrServAContratar["Id_Servicios_Velocidad"] = Convert.ToInt32(DataRowSubServicios[i]["Requiere_IP"]) == 1 ? frmAux.IdServiciosVelocidades : 0;
                                    DrServAContratar["Id_Servicios_Velocidad_Tipo"] = Convert.ToInt32(DataRowSubServicios[i]["Requiere_IP"]) == 1 ? frmAux.IdServiciosVelocidadesTipo : 0;
                                    DrServAContratar["Requiere_IP"] = frmAux.ContrataIPFija;

                                    DrServAContratar["Id_Usuarios_Servicios"] = 0;
                                    DrServAContratar["Id_Bonificacion_Esp"] = 0;
                                    DrServAContratar["Id_Bonificacion"] = 0;
                                    DrServAContratar["Dias_Bonif"] = 0;

                                    //--agregado por nueva modificacion

                                    if (modificaMeses == Convert.ToInt32(Configuracion.CAMBIO_MESES.NO)) //modificaMeses=configuracion del sistema
                                    {
                                        //--agregado por nueva modificación
                                        DrServAContratar["Meses"] = Convert.ToUInt32(DrServicios[0]["Id_Servicios_Modalidad"]) == Convert.ToInt32(Servicios._Modalidad.MENSUAL) ? 1 : oServiciosTarifasSub.getMesesCobro(IdServicios, idTipoFacturacion, idServiciosTarifas, frmAux.IdServiciosVelocidades, frmAux.IdServiciosVelocidadesTipo);
                                        oServicioTarifa.Fecha_Actual = frmAux.FechaInicioServicio;
                                        DrServAContratar["Meses_servicio"] = Convert.ToInt32(DrServicios[0]["Id_Servicios_Modalidad"]) == Convert.ToInt32(Servicios._Modalidad.MENSUAL) ? 1 : oServiciosTarifasSub.getMesesServicio(IdServicios, idTipoFacturacion, idServiciosTarifas, frmAux.IdServiciosVelocidades, frmAux.IdServiciosVelocidadesTipo);
                                    }
                                    else
                                    {
                                        DrServAContratar["Meses"] = Convert.ToUInt32(DrServicios[0]["Id_Servicios_Modalidad"]) == Convert.ToInt32(Servicios._Modalidad.MENSUAL) ? 1 : frmAux.MesesCobro;
                                        DrServAContratar["Meses_servicio"] = Convert.ToInt32(DrServicios[0]["Id_Servicios_Modalidad"]) == Convert.ToInt32(Servicios._Modalidad.MENSUAL) ? 1 : frmAux.MesesServicio;
                                    }
                                    //----------------------------

                                    DrServAContratar["Id_Servicios_Tipos"] = IdServicioTipos;
                                    DrServAContratar["Id_Servicios_Grupos"] = IdServicioGrupos;
                                    DrServAContratar["Id_Eliminar"] = IdTablaServicioUnico;
                                    DrServAContratar["Id_servicios_tipo_sub"] = Convert.ToInt32(DataRowSubServicios[i]["idtipodesub"]);
                                    DrServAContratar["Id_Tarjeta"] = 0;
                                    //--agregado por nueva modificacion
                                    DrServAContratar["Id_Servicios_Modalidad"] = IdServicioModalidad;
                                    //-------------------------

                                    DrServAContratar["id_tarifa_sub_esp"] = frmAux.idTarifaPaquete;

                                    DrServAContratar["Seleccion"] = Convert.ToInt32(DataRowSubServicios[i]["valor_defecto"]);

                                    dtServAContratar.Rows.Add(DrServAContratar);
                                }
                            }

                            dtServAContratar.AcceptChanges();
                            IdTablaServicioUnico++;
                            dgvContrato.CommitEdit(DataGridViewDataErrorContexts.Commit);
                            this.CalcularBonificaciones();
                            this.CalcularTotales();

                            cboTipoFacturacion.Enabled = dtServAContratar.Rows.Count > 0 ? false : true;
                            ContadorServicios();

                            foreach (DataGridViewRow dr in dgvContrato.Rows)
                            {
                                int value = Convert.ToInt32(dr.Cells["Id_Tipo"].Value);

                                if (value == 0)
                                {
                                    dr.DefaultCellStyle.BackColor = Color.Gainsboro;
                                    dr.DefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                                }
                            }
                        }
                    }
                }
                else
                    MessageBox.Show("El Servicio Seleccionado Requiere Cumplir Condiciones", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            else
            {
                if (VerificarCondicionesServicio(IdServicios))
                {
                    using (frmPopUp frm = new frmPopUp())
                    {
                        Partes_Trabajo.frmParteConexion_Auxiliar frmAux = new Partes_Trabajo.frmParteConexion_Auxiliar();

                        int IdServicioModalidad = Convert.ToInt32(DrServicios[0]["Id_Servicios_Modalidad"]);
                        int IdServicioGrupos = Convert.ToInt32(DrServicios[0]["Id_Servicios_Grupos"]);
                        int IdServicioTipos = Convert.ToInt32(DrServicios[0]["Id_Servicios_Tipos"]);
                        int IdServicioTipoSub = Convert.ToInt32(DrServicios[0]["Id_Servicios_Tipos"]); //MARCELO

                        string Servicio = DrServicios[0]["Descripcion"].ToString();
                        bool ForzarInicioServicio = DrServicios[0]["Fecha_Inicio_Servicio"].ToString() == "1" ? true : false;
                        bool ForzarInicioMes = DrServicios[0]["Forzar_Inicio_Mes"].ToString() == "1" ? true : false; ;


                        //si el servicio es por periordo mes cerrado busco en los datos de las tarifas la fecha hasta
                        DateTime FechaHastaPeriodoCerrado;
                        if (IdServicioModalidad == Convert.ToInt32(Servicios._Modalidad.PERIODO_CERRADO_POR_MES))
                        {
                            oServicioTarifa.Fecha_Actual = DateTime.Now;
                            //DataTable dtDatosTarifaPadre = oTarifaEsp.GetServicios_Tarifas_Sub_Esp(Id_Tarifa_Vigente, IdServicios, idSubServicioPadre, idTipoFacturacion);

                        }

                        DateTime fecha;
                        if (dgvContrato.Rows.Count > 0)
                            fecha = Convert.ToDateTime(dgvContrato.Rows[0].Cells["Fecha_InicioServ"].Value);
                        else
                            fecha = DateTime.Now;

                        frmAux.FechaInicioServicio = DateTime.Now;
                        frmAux.FechaConexionServicio = DateTime.Now;
                        frmAux.FechaFinServicio = DateTime.Now;

                        frmAux.IdServicios = IdServicios;
                        frmAux.IdServiciosTipos = IdServicioTipos;
                        frmAux.Servicio = Servicio;
                        frmAux.ForzarFechaInicioServicio = ForzarInicioServicio;
                        frmAux.ForzarInicioMes = ForzarInicioMes;
                        frmAux.TipoFacturacion = this.tipoFacturacion;
                        frmAux.IdTipoFacturacion = idTipoFacturacion;
                        frmAux.RequiereEquipo = DrServicios[0]["Requiere_Equipo"].ToString() == "SI" ? true : false;
                        frmAux.RequiereVelocidades = DrServicios[0]["Requiere_Velocidad"].ToString() == "SI" ? true : false;
                        frmAux.IdServiciosModalidad = IdServicioModalidad;
                        frmAux.DiasBonificacion = Convert.ToInt32(DrServicios[0]["Dias_Bonificacion"].ToString());
                        frm.Formulario = frmAux;
                        frm.Maximizar = false;

                        if (frm.ShowDialog() == DialogResult.OK)
                        {
                            frmAux.FechaFinServicio = Convert.ToDateTime(dgvServiciosContratados.SelectedRows[0].Cells["fecha_factura"].Value);
                            DataRow DrServContratado = dtServiciosContratados.NewRow();
                            DrServContratado["Id_Servicios"] = IdServicios;
                            DrServContratado["Id_Servicios_Categoria"] = frmAux.IdServiciosCategorias;
                            DrServContratado["Fecha_Conexion"] = frmAux.FechaConexionServicio;
                            if (IdServicioModalidad == Convert.ToInt32(Servicios._Modalidad.PERIODO_CERRADO_POR_MES))
                            {
                                DrServContratado["Fecha_InicioServ"] = frmAux.FechaDesdePeriodoCerrado;
                                DrServContratado["Fecha_FinServ"] = frmAux.FechaHastaPeriodoCerrado;
                            }
                            else
                            {
                                DrServContratado["Fecha_InicioServ"] = fechaInicio;
                                DrServContratado["Fecha_FinServ"] = fechaFin;
                            }
                            DrServContratado["Fecha_FinServ"] = Convert.ToDateTime(dgvServiciosContratados.SelectedRows[0].Cells["fecha_factura"].Value);

                            DrServContratado["Id_Servicios_Tipo"] = IdServicioTipos;
                            DrServContratado["Modo"] = frmAux.Modo;
                            DrServContratado["Cantidad"] = frmAux.Cantidad;
                            DrServContratado["CantidadPac"] = cantBocas;
                            DrServContratado["Modalidad"] = cantBocasPactadas;
                            DrServContratado["Dias_Bonif"] = 0;

                            //busco en la configuracion del sistema si se pueden modficar los meses cobro y meses servicio, si se puede tomo en cuenta los del frmaux (como avc) sino los que estan en la tarifa (como atcco)
                            oServicioTarifa.Fecha_Actual = frmAux.FechaInicioServicio;
                            idServiciosTarifas = oServicioTarifa.getTarifaId();
                            int modificaMeses = oConfiguracion.GetValor_N("CambioMeses");
                            if (modificaMeses == Convert.ToInt32(Configuracion.CAMBIO_MESES.NO))
                            {
                                //--agregado por nueva modificación

                                DrServContratado["Meses"] = Convert.ToUInt32(DrServicios[0]["Id_Servicios_Modalidad"]) == Convert.ToInt32(Servicios._Modalidad.MENSUAL) ? 1 : oServiciosTarifasSub.getMesesCobro(IdServicios, idTipoFacturacion, idServiciosTarifas, frmAux.IdServiciosVelocidades, frmAux.IdServiciosVelocidadesTipo);
                                //Tarifas.Fecha_Actual = frmAux.FechaInicioServicio;
                                //Id_Tarifa_Vigente = Id_Servicios_Tarifas;
                                DrServContratado["Meses_servicio"] = Convert.ToInt32(DrServicios[0]["Id_Servicios_Modalidad"]) == Convert.ToInt32(Servicios._Modalidad.MENSUAL) ? 1 : oServiciosTarifasSub.getMesesServicio(IdServicios, idTipoFacturacion, idServiciosTarifas, frmAux.IdServiciosVelocidades, frmAux.IdServiciosVelocidadesTipo);
                            }
                            else
                            {
                                DrServContratado["Meses"] = Convert.ToUInt32(DrServicios[0]["Id_Servicios_Modalidad"]) == Convert.ToInt32(Servicios._Modalidad.MENSUAL) ? 1 : frmAux.MesesCobro;
                                //Tarifas.Fecha_Actual = frmAux.FechaInicioServicio;
                                //Id_Tarifa_Vigente = Id_Servicios_Tarifas;
                                DrServContratado["Meses_servicio"] = Convert.ToInt32(DrServicios[0]["Id_Servicios_Modalidad"]) == Convert.ToInt32(Servicios._Modalidad.MENSUAL) ? 1 : frmAux.MesesServicio;
                            }
                            //----------------------------------

                            DrServContratado["Id_Eliminar"] = IdTablaServicioUnico;

                            dtServiciosContratados.Rows.Add(DrServContratado);
                            dtServiciosContratados.AcceptChanges();

                            DataRow DrServAContratar = dtServAContratar.NewRow();
                            DrServAContratar["Id_Servicios"] = IdServicios;
                            DrServAContratar["Servicio"] = Servicio;
                            DrServAContratar["Item"] = string.Empty;
                            DrServAContratar["Importe"] = 0;
                            DrServAContratar["Bonificacion"] = 0;
                            DrServAContratar["Modo"] = string.Empty;
                            DrServAContratar["Cantidad"] = 0;
                            DrServAContratar["CantidadPac"] = 0;
                            DrServAContratar["Total"] = 0;
                            DrServAContratar["Categoria"] = frmAux.CategoriaSeleccionada;
                            DrServAContratar["Id_Tipo"] = 0;
                            DrServAContratar["Tipo"] = "S";
                            DrServAContratar["Fecha_Conexion"] = frmAux.FechaConexionServicio;
                            DrServAContratar["Fecha_InicioServ"] = frmAux.FechaInicioServicio;
                            //DrServAContratar["Fecha_FinServ"] = Convert.ToInt32(DrServContratado["Meses_servicio"]) > 1 ? Convert.ToDateTime(frmAux.FechaFinServicio).AddMonths(Convert.ToInt32(DrServContratado["Meses_servicio"])).AddDays(-1) : frmAux.FechaFinServicio;
                            try
                            {
                                if (Convert.ToInt32(DrServContratado["Meses_servicio"]) > 1)
                                    DrServAContratar["Fecha_FinServ"] = frmAux.FechaInicioServicio.AddMonths(Convert.ToInt32(DrServContratado["Meses_servicio"])).AddDays(-1);
                                else
                                    DrServAContratar["Fecha_FinServ"] = frmAux.FechaFinServicio;
                            }
                            catch { DrServAContratar["Fecha_FinServ"] = frmAux.FechaFinServicio; }
                            if (IdServicioModalidad == Convert.ToInt32(Servicios._Modalidad.PERIODO_CERRADO_POR_MES))
                            {
                                DrServAContratar["Fecha_FinServ"] = frmAux.FechaHastaPeriodoCerrado;
                                DrServAContratar["Fecha_InicioServ"] = frmAux.FechaDesdePeriodoCerrado;

                            }
                            if (IdServicioModalidad == Convert.ToInt32(Servicios._Modalidad.PERIODO_CERRADO_POR_DIA))
                            {
                                DrServAContratar["Fecha_FinServ"] = frmAux.FechaFinServicio;

                            }
                            DrServContratado["Fecha_FinServ"] = Convert.ToDateTime(dgvServiciosContratados.SelectedRows[0].Cells["fecha_factura"].Value);

                            DrServAContratar["Id_Servicios_Velocidad"] = 0;
                            DrServAContratar["Id_Servicios_Velocidad_Tipo"] = 0;
                            DrServAContratar["Requiere_IP"] = 0;
                            DrServAContratar["Id_Usuarios_Servicios"] = 0;
                            DrServAContratar["Id_Bonificacion_Esp"] = 0;
                            DrServAContratar["Id_Bonificacion"] = 0;
                            DrServAContratar["Dias_Bonif"] = 0;
                            DrServAContratar["Meses"] = 0;
                            DrServAContratar["Id_Servicios_Tipos"] = IdServicioTipos;
                            DrServAContratar["Id_Servicios_Grupos"] = IdServicioGrupos;
                            DrServAContratar["Id_Eliminar"] = IdTablaServicioUnico;

                            //--agregado por nueva modificación
                            DrServAContratar["Id_Servicios_Modalidad"] = IdServicioModalidad;
                            //----------------------------------------

                            dtServAContratar.Rows.Add(DrServAContratar);

                            DataRow[] DataRowSubServicios;
                            string requiereVelocidad = "NO";
                            //si la modalidad del servicio es por dia y no requiere internet tengo que filtrar, en el dt subservicios, por canti dias
                            if (IdServicioModalidad != Convert.ToInt32(Servicios._Modalidad.DIA))
                            {
                                DataTable dtDatosServicio = oServicio.BuscarDatosServicio(IdServicios);
                                if (dtDatosServicio.Rows.Count > 0)
                                    requiereVelocidad = dtDatosServicio.Rows[0]["Requiere_Velocidad"].ToString();

                                if (IdServicioModalidad == Convert.ToInt32(Servicios._Modalidad.PERIODO_CERRADO_POR_DIA) && (requiereVelocidad == "NO"))
                                    DataRowSubServicios = dtSubServicios.Select(String.Format("Id_Servicios = {0} AND Id_Tipo_Facturacion = {1} and dias_desde={2}", IdServicios, idTipoFacturacion, frmAux.CantDiasPeriodoCerrado));
                                else if (IdServicioModalidad == Convert.ToInt32(Servicios._Modalidad.PERIODO_CERRADO_POR_MES) && (requiereVelocidad == "NO"))
                                    DataRowSubServicios = dtSubServicios.Select(String.Format("Id_Servicios = {0} AND Id_Tipo_Facturacion = {1} and id_servicios_tarifas_sub_esp={2}", IdServicios, idTipoFacturacion, frmAux.idTarifaPaquete));
                                else
                                    DataRowSubServicios = dtSubServicios.Select(String.Format("Id_Servicios = {0} AND Id_Tipo_Facturacion = {1} ", IdServicios, idTipoFacturacion));
                            }
                            else
                                DataRowSubServicios = oTipoFac.GetServiciosSubPorTipo(idTipoFacturacion, IdServicios).Select("Id_Servicios_Sub > 0");

                            DataTable dtServiciosPorTipo = oTipoFac.Listar(idTipoFacturacion);


                            if (DataRowSubServicios.Length > 0)
                            {
                                for (int i = 0; i < DataRowSubServicios.Length; i++)
                                {
                                    DataRow[] drSubTipo = dtServiciosPorTipo.Select(String.Format("Id_Servicios_Sub = {0}", Convert.ToInt32(DataRowSubServicios[i]["Id_Servicios_Sub"])));

                                    if (drSubTipo.Length == 0)
                                        continue;


                                    if (IdServicioModalidad != Convert.ToInt32(Servicios._Modalidad.DIA))
                                        if (frmAux.RequiereVelocidades == true && Convert.ToInt32(DataRowSubServicios[i]["velocidad"]) > 0 && (Convert.ToInt32(DataRowSubServicios[i]["Id_Servicios_Velocidad"]) != frmAux.IdServiciosVelocidades || Convert.ToInt32(DataRowSubServicios[i]["Id_Servicio_Velocidad_Tip"]) != frmAux.IdServiciosVelocidadesTipo))
                                            continue;

                                    DrServAContratar = dtServAContratar.NewRow();
                                    DrServAContratar["Id_Servicios"] = IdServicios;
                                    DrServAContratar["Servicio"] = Servicio;

                                    if (IdServicioModalidad != Convert.ToInt32(Servicios._Modalidad.DIA))
                                        DrServAContratar["Item"] = frmAux.RequiereVelocidades == true ? String.Format("{0} {1} MB {2}", DataRowSubServicios[i]["SubServicio"].ToString(), frmAux.VelocidadSeleccionada, frmAux.VelocidadTipoSeleccionada) : DataRowSubServicios[i]["SubServicio"].ToString();
                                    else
                                        DrServAContratar["Item"] = String.Format("{0} {1} MB {2}", DataRowSubServicios[i]["servicios_sub"], frmAux.VelocidadSeleccionada, frmAux.VelocidadTipoSeleccionada);

                                    if (frmAux.ContrataIPFija == 1)
                                        DrServAContratar["Item"] = DrServAContratar["Item"] + " IP FIJA";

                                    DrServAContratar["Importe"] = 0;
                                    DrServAContratar["Bonificacion"] = 0;
                                    DrServAContratar["Modo"] = frmAux.Modo;
                                    DrServAContratar["Cantidad"] = frmAux.Cantidad;
                                    DrServAContratar["CantidadPac"] = frmAux.CantidadPactada;
                                    DrServAContratar["Total"] = 0;
                                    DrServAContratar["Categoria"] = string.Empty;
                                    DrServAContratar["Id_Tipo"] = DataRowSubServicios[i]["Id_Servicios_Sub"].ToString(); ;
                                    DrServAContratar["Tipo"] = "S";
                                    // DrServAContratar["Fecha_Conexion"] = DBNull.Value;
                                    // DrServAContratar["Fecha_InicioServ"] = DBNull.Value;
                                    if (IdServicioModalidad == Convert.ToInt32(Servicios._Modalidad.PERIODO_CERRADO_POR_MES) && (requiereVelocidad == "NO"))
                                    {
                                        DrServAContratar["Fecha_InicioServ"] = frmAux.FechaDesdePeriodoCerrado;
                                        DrServAContratar["Fecha_FinServ"] = frmAux.FechaHastaPeriodoCerrado;
                                    }
                                    else
                                    {
                                        DrServAContratar["Fecha_InicioServ"] = frmAux.FechaInicioServicio;
                                        DrServAContratar["Fecha_FinServ"] = frmAux.FechaFinServicio;

                                    }
                                    DrServAContratar["Fecha_Conexion"] = frmAux.FechaConexionServicio;
                                    DrServContratado["Fecha_FinServ"] = Convert.ToDateTime(dgvServiciosContratados.SelectedRows[0].Cells["fecha_factura"].Value);


                                    DrServAContratar["Id_Servicios_Velocidad"] = Convert.ToInt32(DataRowSubServicios[i]["Requiere_IP"]) == 1 ? frmAux.IdServiciosVelocidades : 0;
                                    DrServAContratar["Id_Servicios_Velocidad_Tipo"] = Convert.ToInt32(DataRowSubServicios[i]["Requiere_IP"]) == 1 ? frmAux.IdServiciosVelocidadesTipo : 0;
                                    DrServAContratar["Requiere_IP"] = frmAux.ContrataIPFija;

                                    DrServAContratar["Id_Usuarios_Servicios"] = 0;
                                    DrServAContratar["Id_Bonificacion_Esp"] = 0;
                                    DrServAContratar["Id_Bonificacion"] = 0;
                                    DrServAContratar["Dias_Bonif"] = 0;

                                    //--agregado por nueva modificacion

                                    if (modificaMeses == Convert.ToInt32(Configuracion.CAMBIO_MESES.NO)) //modificaMeses=configuracion del sistema
                                    {
                                        //--agregado por nueva modificación
                                        DrServAContratar["Meses"] = Convert.ToUInt32(DrServicios[0]["Id_Servicios_Modalidad"]) == Convert.ToInt32(Servicios._Modalidad.MENSUAL) ? 1 : oServiciosTarifasSub.getMesesCobro(IdServicios, idTipoFacturacion, idServiciosTarifas, frmAux.IdServiciosVelocidades, frmAux.IdServiciosVelocidadesTipo);
                                        oServicioTarifa.Fecha_Actual = frmAux.FechaInicioServicio;
                                        DrServAContratar["Meses_servicio"] = Convert.ToInt32(DrServicios[0]["Id_Servicios_Modalidad"]) == Convert.ToInt32(Servicios._Modalidad.MENSUAL) ? 1 : oServiciosTarifasSub.getMesesServicio(IdServicios, idTipoFacturacion, idServiciosTarifas, frmAux.IdServiciosVelocidades, frmAux.IdServiciosVelocidadesTipo);
                                    }
                                    else
                                    {
                                        DrServAContratar["Meses"] = Convert.ToUInt32(DrServicios[0]["Id_Servicios_Modalidad"]) == Convert.ToInt32(Servicios._Modalidad.MENSUAL) ? 1 : frmAux.MesesCobro;
                                        DrServAContratar["Meses_servicio"] = Convert.ToInt32(DrServicios[0]["Id_Servicios_Modalidad"]) == Convert.ToInt32(Servicios._Modalidad.MENSUAL) ? 1 : frmAux.MesesServicio;
                                    }
                                    //----------------------------

                                    DrServAContratar["Id_Servicios_Tipos"] = IdServicioTipos;
                                    DrServAContratar["Id_Servicios_Grupos"] = IdServicioGrupos;
                                    DrServAContratar["Id_Eliminar"] = IdTablaServicioUnico;
                                    DrServAContratar["Id_servicios_tipo_sub"] = Convert.ToInt32(DataRowSubServicios[i]["idtipodesub"]);
                                    DrServAContratar["Id_Tarjeta"] = 0;
                                    //--agregado por nueva modificacion
                                    DrServAContratar["Id_Servicios_Modalidad"] = IdServicioModalidad;
                                    //-------------------------

                                    DrServAContratar["id_tarifa_sub_esp"] = frmAux.idTarifaPaquete;

                                    DrServAContratar["Seleccion"] = Convert.ToInt32(DataRowSubServicios[i]["valor_defecto"]);

                                    dtServAContratar.Rows.Add(DrServAContratar);
                                }
                            }

                            dtServAContratar.AcceptChanges();
                            IdTablaServicioUnico++;
                            dgvContrato.CommitEdit(DataGridViewDataErrorContexts.Commit);
                            this.CalcularBonificaciones();
                            this.CalcularTotales();

                            cboTipoFacturacion.Enabled = dtServAContratar.Rows.Count > 0 ? false : true;
                            ContadorServicios();

                            foreach (DataGridViewRow dr in dgvContrato.Rows)
                            {
                                int value = Convert.ToInt32(dr.Cells["Id_Tipo"].Value);

                                if (value == 0)
                                {
                                    dr.DefaultCellStyle.BackColor = Color.Gainsboro;
                                    dr.DefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                                }
                            }

                            btnConfirmar.Enabled = true;
                            spMain.Panel2.Enabled = true;
                        }
                    }
                }
                else
                    MessageBox.Show("El Servicio Seleccionado Requiere Cumplir Condiciones", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
        }

        private bool VerificarCondicionesServicio(int idservicio)
        {
            DataTable dt = dtServAContratar.Copy();


            if (dtServiciosActivos.Rows.Count > 0)
            {
                foreach (DataRow dr in dtServiciosActivos.Rows)
                {
                    DataRow drNueva = dt.NewRow();
                    drNueva["Id_Servicios"] = dr["Id_Servicio"];
                    drNueva["CantidadPac"] = dr["cant_bocas_pac"];
                    drNueva["Id_Servicios_Tipos"] = dr["id_servicio_tipo"];
                    drNueva["Id_Servicios_Grupos"] = dr["Id_Servicios_Grupos"];
                    drNueva["Id_Servicios_Tipo_Sub"] = 1;
                    drNueva["Id_Usuarios_Servicios"] = dr["Id_Usuario_Servicio"];

                    dt.Rows.Add(drNueva);
                }

                dt.AcceptChanges();
            }

            DataView dtv = new DataView();
            dtv = dt.DefaultView;
            dtv.RowFilter = "Seleccion = true";


            dt.DefaultView.RowFilter = "Seleccion = true";
            dt = dtv.ToTable();

            return oServiciosCondiciones.Verificar_Condiciones(idservicio, dt, Convert.ToInt32(cboTipoFacturacion.SelectedValue));
        }

        private void CalcularBonificaciones()
        {
            int ultimoIdUsuarioServicio = 0;
            int ultimoIdUsuarioServicioSub = 0;

            IdTablaBonificacionSub = 1;
            IdTablaBonificacion = 0;
            ContadorServicios();
            dtServABonificar.Rows.Clear();

            if (dtServAContratar.Rows.Count > 0)
            {
                DataRow[] DataServiciosSel = dtServAContratar.Select("Seleccion = true");
                DataRow[] DataServiciosNoSel = dtServAContratar.Select("Seleccion = false");

                foreach (DataRow item in DataServiciosNoSel)
                    item["Importe"] = 0;



                foreach (DataRow dr in dtServiciosActivos.Rows)
                {
                    DataRow dataRow = dtServABonificar.NewRow();
                    dataRow["id_usuario_servicio"] = Convert.ToInt32(dr["id_usuario_servicio"]);
                    dataRow["id_usuario_servicio_sub"] = Convert.ToInt32(dr["id_usuario_servicio_sub"]);
                    dataRow["id_tipo_facturacion"] = idTipoFacturacion;
                    dataRow["id_grupo"] = Convert.ToInt32(dr["id_servicios_grupos"]);
                    dataRow["id_servicio_tipo"] = Convert.ToInt32(dr["id_servicio_tipo"]);
                    dataRow["id_servicio"] = Convert.ToInt32(dr["id_servicio"]);
                    dataRow["id_servicio_sub"] = Convert.ToInt32(dr["id_servicio_sub"]);
                    dataRow["id_velocidad"] = Convert.ToInt32(dr["id_velocidad"]);
                    dataRow["id_velocidad_tipo"] = Convert.ToInt32(dr["id_velocidad_tipo"]);
                    //dataRow["tipo_servicio_sub"] = dr["Nombre"].ToString().Substring(0, 1);
                    dataRow["tipo_servicio_sub"] = "S";
                    dataRow["id_tipo_de_sub"] = Convert.ToInt32(dr["Id_servicio_sub_tipo"]);
                    dataRow["cant_bocas_pac"] = Convert.ToInt32(dr["Cant_Bocas_Pac"]);
                    dataRow["Id_Relacion"] = 0;

                    //--agregado por nueva modificación
                    int modificaMeses = oConfiguracion.GetValor_N("CambioMeses");
                    if (modificaMeses == Convert.ToInt32(Configuracion.CAMBIO_MESES.NO))
                    {
                        //--agregado por nueva modificación
                        dataRow["meses_cobro"] = Convert.ToUInt32(dr["id_servicio_modalidad"]) == Convert.ToInt32(Servicios._Modalidad.MENSUAL) ? 1 : oServiciosTarifasSub.getMesesCobro(Convert.ToInt32(dr["id_servicio"]), idTipoFacturacion, idServiciosTarifas, Convert.ToInt32(dr["id_velocidad"]), Convert.ToInt32(dr["id_velocidad_tipo"]));
                        dataRow["meses_servicio"] = Convert.ToUInt32(dr["id_servicio_modalidad"]) == Convert.ToInt32(Servicios._Modalidad.MENSUAL) ? 1 : oServiciosTarifasSub.getMesesServicio(Convert.ToInt32(dr["id_servicio"]), idTipoFacturacion, idServiciosTarifas, Convert.ToInt32(dr["id_velocidad"]), Convert.ToInt32(dr["id_velocidad_tipo"]));
                    }
                    else
                    {
                        dataRow["meses_cobro"] = Convert.ToUInt32(dr["id_servicio_modalidad"]) == Convert.ToInt32(Servicios._Modalidad.MENSUAL) ? 1 : oServiciosTarifasSub.getMesesCobro(Convert.ToInt32(dr["id_servicio"]), idTipoFacturacion, idServiciosTarifas, Convert.ToInt32(dr["id_velocidad"]), Convert.ToInt32(dr["id_velocidad_tipo"]));
                        dataRow["meses_servicio"] = Convert.ToUInt32(dr["id_servicio_modalidad"]) == Convert.ToInt32(Servicios._Modalidad.MENSUAL) ? 1 : oServiciosTarifasSub.getMesesServicio(Convert.ToInt32(dr["id_servicio"]), idTipoFacturacion, idServiciosTarifas, Convert.ToInt32(dr["id_velocidad"]), Convert.ToInt32(dr["id_velocidad_tipo"]));

                    }
                    dataRow["id_servicio_modalidad"] = Convert.ToUInt32(dr["id_servicio_modalidad"]);

                    dataRow["id_ip_fija"] = Convert.ToInt32(dr["id_ip_fija"]);

                    //--agregado por nueva modificación
                    dataRow["meses_cobro"] = Convert.ToUInt32(dr["meses_cobro"]);
                    dataRow["meses_servicio"] = Convert.ToUInt32(dr["meses_servicio"]);
                    dataRow["fecha_inicio_servicio"] = Convert.ToDateTime(dr["fecha_inicio"]);
                    dataRow["id_servicio_modalidad"] = Convert.ToUInt32(dr["id_servicio_modalidad"]);
                    //---------------------------------
                    dataRow["fecha_hasta_servicio"] = Convert.ToDateTime(dgvServiciosContratados.SelectedRows[0].Cells["fecha_factura"].Value);

                    dataRow["heredado"] = 1;
                    dataRow["id_bonificacion_especial"] = Convert.ToUInt32(dr["Id_bonificacion_esp"]);
                    dataRow["id_localidad"] = Convert.ToUInt32(dr["Id_localidad"]);

                    try
                    {
                        dataRow["id_servicios_tarifas_sub_esp"] = Convert.ToUInt32(dr["id_tarifa_Sub_esp"]);
                    }
                    catch
                    {
                        dataRow["id_servicios_tarifas_sub_esp"] = 0;
                    }

                    dtServABonificar.Rows.Add(dataRow);



                    if (Convert.ToInt32(dr["id_usuario_servicio"]) > ultimoIdUsuarioServicio)
                        ultimoIdUsuarioServicio = Convert.ToInt32(dr["id_usuario_servicio"]);

                    if (Convert.ToInt32(dr["id_usuario_servicio_sub"]) > ultimoIdUsuarioServicioSub)
                        ultimoIdUsuarioServicioSub = Convert.ToInt32(dr["id_usuario_servicio_sub"]);
                }

                if (dtUsuariosEquipos.Rows.Count > 0)
                {
                    ultimoIdUsuarioServicioSub = ultimoIdUsuarioServicioSub + 1;
                    foreach (DataRow dr in dtUsuariosEquipos.Rows)
                    {
                        DataRow dataRow = dtServABonificar.NewRow();
                        dataRow["id_usuario_servicio"] = Convert.ToInt32(dr["id_usuarios_servicios"]);
                        dataRow["id_usuario_servicio_sub"] = ultimoIdUsuarioServicioSub;
                        dataRow["id_tipo_facturacion"] = (int)this.tipoFacturacion;
                        dataRow["id_grupo"] = Convert.ToInt32(dr["id_servicios_grupos"]);
                        dataRow["id_servicio_tipo"] = Convert.ToInt32(dr["id_servicios_tipos"]);
                        dataRow["id_servicio"] = Convert.ToInt32(dr["id_servicios"]);
                        dataRow["id_servicio_sub"] = Convert.ToInt32(dr["id_equipos_tipos"]);
                        dataRow["id_velocidad"] = 0;
                        dataRow["id_velocidad_tipo"] = 0;
                        dataRow["tipo_servicio_sub"] = "E";
                        dataRow["id_tipo_de_sub"] = 0;
                        dataRow["cant_bocas_pac"] = 0;
                        dataRow["Id_Relacion"] = 0;

                        //--agregado por nueva modificación
                        dataRow["meses_cobro"] = 1;
                        dataRow["meses_servicio"] = 1;
                        dataRow["fecha_inicio_servicio"] = DateTime.Now;
                        dataRow["fecha_hasta_servicio"] = DateTime.Now;
                        //---------------------------------
                        dataRow["id_localidad"] = Convert.ToInt32(dr["id_localidades"]);
                        dtServABonificar.Rows.Add(dataRow);
                        ultimoIdUsuarioServicioSub = ultimoIdUsuarioServicioSub + 1;
                    }


                }

                IdTablaBonificacion = ultimoIdUsuarioServicio;
                IdTablaBonificacionSub = ultimoIdUsuarioServicioSub + 1;


                for (int i = 0; i < DataServiciosSel.Length; i++)
                {
                    if (Convert.ToInt32(DataServiciosSel[i]["Id_Tipo"]) == 0)
                        IdTablaBonificacion++;//se incrementa por cada servicio
                    else
                    {
                        DataRow dataRow = dtServABonificar.NewRow();
                        dataRow["id_usuario_servicio"] = IdTablaBonificacion;
                        dataRow["id_usuario_servicio_sub"] = IdTablaBonificacionSub++;
                        dataRow["id_tipo_facturacion"] = this.idTipoFacturacion;
                        dataRow["id_grupo"] = DataServiciosSel[i]["Id_Servicios_Grupos"];
                        dataRow["id_servicio_tipo"] = DataServiciosSel[i]["Id_Servicios_Tipos"];
                        dataRow["id_servicio"] = DataServiciosSel[i]["Id_Servicios"];
                        dataRow["id_servicio_sub"] = DataServiciosSel[i]["Id_Tipo"];
                        dataRow["id_velocidad"] = DataServiciosSel[i]["Id_Servicios_Velocidad"];
                        dataRow["id_velocidad_tipo"] = DataServiciosSel[i]["Id_Servicios_Velocidad_Tipo"];
                        dataRow["tipo_servicio_sub"] = DataServiciosSel[i]["Tipo"];
                        dataRow["id_tipo_de_sub"] = DataServiciosSel[i]["Id_Servicios_Tipo_Sub"];
                        dataRow["cant_bocas_pac"] = DataServiciosSel[i]["CantidadPac"];
                        int id_rela = Convert.ToInt32(DataServiciosSel[i]["Id"]);
                        dataRow["Id_Relacion"] = id_rela;
                        dataRow["id_ip_fija"] = DataServiciosSel[i]["Requiere_IP"];

                        //--agregado por nueva modificación
                        dataRow["meses_cobro"] = DataServiciosSel[i]["meses"];
                        dataRow["meses_servicio"] = DataServiciosSel[i]["meses_servicio"];
                        dataRow["fecha_inicio_servicio"] = DataServiciosSel[i]["Fecha_InicioServ"];
                        dataRow["id_servicio_modalidad"] = DataServiciosSel[i]["Id_Servicios_Modalidad"];
                        //---------------------------------
                        dataRow["fecha_hasta_servicio"] = Convert.ToDateTime(dgvServiciosContratados.SelectedRows[0].Cells["fecha_factura"].Value);

                        dataRow["heredado"] = 0.ToString();
                        dataRow["id_bonificacion_especial"] = DataServiciosSel[i]["id_bonificacion_esp"].ToString();

                        dataRow["id_localidad"] = cboTipoFacturacion.SelectedValue.ToString();
                        dataRow["id_servicios_tarifas_sub_esp"] = Convert.ToUInt32(DataServiciosSel[i]["id_tarifa_Sub_esp"]);

                        dtServABonificar.Rows.Add(dataRow);

                    }
                }


                DataView dvSoloSubServicios = new DataView(dtServABonificar);
                dvSoloSubServicios.RowFilter = "id_usuario_servicio_sub>0";
                DataTable dtSoloSubServicios = dvSoloSubServicios.ToTable();
                //---agregado por nueva modificación
                oBonificaciones.CalcularBonificaciones(dtSoloSubServicios, idServiciosTarifas, true, 0, false);
                dtServBonificaciones = Bonificaciones.dtSubServicios;
                dtServBonificacionesDetalles = Bonificaciones.dtSubServiciosDetalles;
                dtDatosNovedades = Bonificaciones.dtDatosNovedades;
                //------------------------------

                foreach (DataRow dr in dtServBonificaciones.Rows)
                {
                    if (Convert.ToInt32(dr["Id_Relacion"]) > 0)
                    {
                        DataRow[] dataRows = dtServAContratar.Select(String.Format("Id = {0}", dr["Id_Relacion"]));

                        dataRows[0]["id_bonificacion"] = dr["id_bonificacion"];

                        //if (Convert.ToInt32(dr["id_tipo_de_sub"]) == Convert.ToInt32(Servicios_Sub.SERVICIO_SUB_TIPOS.DERECHO_DE_CONEXION))
                        //    dataRows[0]["importe"] = Convert.ToDecimal(dr["importe_original"]);
                        //else
                        //    dataRows[0]["Importe"] = Convert.ToBoolean(dataRows[0]["Seleccion"]) == false ? 0 : Convert.ToDecimal(dr["importe_original"]) * Convert.ToDecimal(dataRows[0]["Meses"]);

                        dataRows[0]["importe"] = Convert.ToDecimal(dr["importe_original"]);
                        dataRows[0]["Nombre"] = dr["nombre_bonificacion"].ToString();
                        dataRows[0]["Bonificacion"] = dr["porcentaje"].ToString() == string.Empty ? 0 : Decimal.Round(Convert.ToDecimal(dr["porcentaje"]), 2);
                        dataRows[0]["Total"] = Convert.ToDecimal(dr["importe_con_descuento"]);

                        int idBonificacionContratacion, idBonificacion, idUsuarioServicio, idUsuarioServicioSub;
                        idUsuarioServicio = Convert.ToInt32(dr["id_usuario_servicio"]);
                        idUsuarioServicioSub = Convert.ToInt32(dr["id_usuario_servicio_sub"]);
                        DataRow[] drBonificaicones = dtServBonificacionesDetalles.Select("id_usuarios_servicios='" + idUsuarioServicio + "' and id_usuarios_servicios_sub='" + idUsuarioServicioSub + "'");
                        idBonificacionContratacion = drBonificaicones.Length == 0 ? 0 : Convert.ToInt32(drBonificaicones[0]["id_bonificacion_contratacion"]);
                        idBonificacion = drBonificaicones.Length == 0 ? 0 : Convert.ToInt32(drBonificaicones[0]["id_bonificacion"]);
                        dataRows[0]["Id_Bonificacion_Contratacion"] = idBonificacionContratacion;
                        dataRows[0]["Id_Bonificacion"] = idBonificacion;

                        //if (Convert.ToInt32(dr["id_tipo_de_sub"]) == Convert.ToInt32(Servicios_Sub.SERVICIO_SUB_TIPOS.DERECHO_DE_CONEXION))
                        //{
                        //    if (Convert.ToDecimal(dr["importe_con_descuento"]) == 0)
                        //        dataRows[0]["Total"] = (Convert.ToInt32(dr["porcentaje"]) == 100 ? 0 : Convert.ToDecimal(dr["importe_original"]));
                        //    else
                        //        dataRows[0]["Total"] = Convert.ToDecimal(dr["importe_con_descuento"]);
                        //}
                        //else
                        //{
                        //    if (Convert.ToDecimal(dr["importe_con_descuento"]) == 0)
                        //        dataRows[0]["Total"] = (Convert.ToInt32(dr["porcentaje"]) == 100 ? 0 : Convert.ToDecimal(dr["importe_original"]));
                        //    else
                        //        dataRows[0]["Total"] = Convert.ToDecimal(dr["importe_con_descuento"]);

                        //}

                        dataRows[0]["id_usuarios_servicios_sub"] = Convert.ToInt32(dr["id_usuario_servicio_sub"]);

                        dtServAContratar.AcceptChanges();
                    }
                }


                CalcularTotales();
                dgvContrato.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        #endregion
        private void btnServicios_Click(object sender, EventArgs e)
        {
            if (agregaServicio == true)
            {
                dtServicios = oTipoFac.GetServicios();
                agregaServicio = true;
                using (frmPopUp frm = new frmPopUp())
                {
                    Partes_Trabajo.frmParteConexion_Servicios frmServicios = new Partes_Trabajo.frmParteConexion_Servicios();
                    DataView dtv = new DataView(dtServicios);

                    dtv.RowFilter = String.Format("Id_Tipo_Facturacion = {0}", this.idTipoFacturacion);
                    frmServicios.DataServicios = dtv.ToTable();
                    frm.Maximizar = false;
                    frm.Formulario = frmServicios;

                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        idServicioSeleccionado = frmServicios.IdServiciosSeleccionado;
                        AgregarServicio(idServicioSeleccionado);
                    }
                }
            }
            else
            {

                dtServicios = oTipoFac.GetServicios();
                using (frmPopUp frm = new frmPopUp())
                {
                    Partes_Trabajo.frmParteConexion_Servicios frmServicios = new Partes_Trabajo.frmParteConexion_Servicios();
                    DataView dtv = new DataView(dtServicios);

                    dtv.RowFilter = String.Format("Id_Tipo_Facturacion = {0} and id_servicios_tipos={1}", this.idTipoFacturacion, idTipoServicioViejo);
                    frmServicios.DataServicios = dtv.ToTable();
                    frm.Maximizar = false;
                    frm.Formulario = frmServicios;

                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        idServicioSeleccionado = frmServicios.IdServiciosSeleccionado;
                        AgregarServicio(idServicioSeleccionado);
                    }
                }
            }
        }

        private void cboTipoFacturacion_SelectedValueChanged(object sender, EventArgs e)
        {

            try
            {
                switch (tipoFacturacion)
                {
                    case Tipo_Facturacion.Id_Tipo_Facturacion.POR_ZONAS:
                        DataRow[] dr = dtLocalidades.Select(String.Format("Id_Localidad = {0}", cboTipoFacturacion.SelectedValue));
                        dtServicios.DefaultView.RowFilter = String.Format("Id_Tipo_Facturacion = {0}", dr[0]["Id_Zona"]);
                        idTipoFacturacion = Convert.ToInt32(dr[0]["Id_Zona"]);
                        break;
                    case Tipo_Facturacion.Id_Tipo_Facturacion.POR_CATEGORIAS:
                        idTipoFacturacion = Convert.ToInt32(cboTipoFacturacion.SelectedValue);
                        dtServicios.DefaultView.RowFilter = String.Format("Id_Tipo_Facturacion = {0}", idTipoFacturacion);
                        break;
                    default:
                        break;
                }

                btnServicios.Enabled = idTipoFacturacion > 0 ? true : false;

                CargarServicios();
            }
            catch { }
        }

        private void frmCambioServicio_Load(object sender, EventArgs e)
        {
            comenzarCarga();
        }

        private void lblServiciosContratados_Click(object sender, EventArgs e)
        {

        }

        private void dgvContrato_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            CalcularBonificaciones();
            CalcularTotales();

        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (oPlasticosUsuarios.BuscarPlasticosServicio(Convert.ToInt32(dgvServiciosContratados.SelectedRows[0].Cells["id_usuario_servicio"].Value)).Rows.Count > 0)
                MessageBox.Show("Este servicio esta adherido a debito automatico, para cambiarlo/eliminarlo, debe desafectarlo", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else
            {
                huboCambios = true;
                string nombreServicioViejo = dgvServiciosContratados.SelectedRows[0].Cells["servicio"].Value.ToString();
                string nombreServicioNuevoo = dgvContrato.SelectedRows[0].Cells["servicio"].Value.ToString();
                string mensaje = "";
                if (agregaServicio == false)
                    mensaje = string.Format("Se cambiara el servicio {0} por el servicio {1}, ¿Desea continuar?", nombreServicioViejo, nombreServicioNuevoo);
                else
                    mensaje = string.Format("Se agregara el servicio {0}, ¿Desea continuar?", nombreServicioNuevoo);

                DataTable dtEquiposUSOriginal = new DataTable();

                dtEquiposUSOriginal = oEquipos.ListarEquipoPorUsuariosServicio(Convert.ToInt32(dgvServiciosContratados.SelectedRows[0].Cells["id_usuario_servicio"].Value));

                if(dtEquiposUSOriginal.Rows.Count>0)
                {
                    if(MessageBox.Show("El servicio tiene asociado equipos, ¿Desea pasarlos al nuevo servicio?","Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        pasaEquipos = true;
                    }
                }

                if (MessageBox.Show(mensaje, "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        IngresarParte();
                        if (agregaServicio == false)
                        {
                            if (oUsuariosServicios.EliminarUsuarioServicio(Convert.ToInt32(dgvServiciosContratados.SelectedRows[0].Cells["id_usuario_servicio"].Value)) == 0)
                                MessageBox.Show("Servicio cambiado conrrectamente", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            else
                                MessageBox.Show("Hubo un error: se ha agrenado el nuevo servicio pero no se ha eliminado el servicio actual", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }
                        else
                        {
                            MessageBox.Show("Servicio agregado correctamente", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                    }
                    catch (Exception c)
                    {
                        MessageBox.Show("Hubo un error durante el proceso de cambio de servicio. Error: " + c.Message);
                    }
                    this.DialogResult = DialogResult.OK;
                }
            }
        }

        private void dgvServiciosContratados_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                Usuarios.Current_IdUsuarioLocacion = Convert.ToInt32(dgvServiciosContratados.SelectedRows[0].Cells["id_locacion"].Value);
                cboTipoFacturacion.SelectedValue = Convert.ToInt32(dgvServiciosContratados.SelectedRows[0].Cells["id_tipo_facturacion"].Value);
                idTipoServicioViejo = Convert.ToInt32(dgvServiciosContratados.Rows[0].Cells["id_servicio_tipo"].Value);
            }
            catch
            {
            }
        }

        private void dgvServiciosContratados_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            spMain.Panel1.Enabled = false;
            agregaServicio = true;
            btnServicios.Focus();
            spMain.Panel2.Enabled = true;

        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvServiciosContratados_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            llenarDatos();
            if (dgvServiciosContratados.Columns[e.ColumnIndex].Name == "cambiar")
            {
                if (Convert.ToInt32(dgvServiciosContratados.SelectedRows[0].Cells["debito"].Value) == 0)
                    spMain.Panel2.Enabled = true;
                else
                {
                    MessageBox.Show("El servicio seleccionado esta adherido a debito automático. Para cambiar el servicio primero debe generar un parte de baja de debito y confirmarlo.", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    spMain.Panel2.Enabled = false;

                }
            }
        }

        private void IngresarParte()
        {

            drDatosComprobanteVenta = oComprobantesTipo.GetNumeracion(Convert.ToInt32(Comprobantes_Tipo.Tipo.COMPROBANTE_DEUDA), Puntos_Cobros.Id_Punto);
            frmUsuariosPrincipal.Instance().comenzarCarga();


            DateTime fecha_inicio = new DateTime().Date;
            DateTime fecha_fin = new DateTime().Date;

            int contador = 1;

            foreach (DataRow dr in dtServiciosContratados.Rows)
            {
                Usuarios_Servicios oUsuSer = new Usuarios_Servicios();

                oUsuSer.Id_Usuarios = Usuarios.CurrentUsuario.Id;
                oUsuSer.Id_Zonas = Convert.ToInt32(cboTipoFacturacion.SelectedValue);
                oUsuSer.Id_Usuarios_Locaciones = Usuarios.Current_IdUsuarioLocacion;
                oUsuSer.Id_Servicios = Convert.ToInt32(dr["Id_Servicios"]);
                oUsuSer.Id_Servicios_Tipo = Convert.ToInt32(dr["Id_Servicios_Tipo"]);
                oUsuSer.Id_Servicios_Categorias = Convert.ToInt32(cboTipoFacturacion.SelectedValue);
                oUsuSer.Id_Servicios_Estados = Convert.ToInt32(dgvServiciosContratados.SelectedRows[0].Cells["id_estado"].Value);
                oUsuSer.Meses_Cobro = Convert.ToInt32(dr["Meses"]);
                oUsuSer.Meses_Servicio = Convert.ToInt32(dr["Meses_Servicio"]);
                switch (Convert.ToInt32(dr["Modalidad"]))
                {
                    case 1: // DIARIO
                        oUsuSer.Fecha_Estado = Convert.ToDateTime(dr["Fecha_InicioServ"]);
                        oUsuSer.Fecha_Inicio = oUsuSer.Fecha_Estado;
                        oUsuSer.Fecha_Fin = Convert.ToDateTime(dr["Fecha_FinServ"]); //DateTime.Today.AddDays(Convert.ToUInt32(dr["Dias_Bonif"]));
                        break;
                    case 2: // MENSUAL
                        oUsuSer.Fecha_Estado = Convert.ToDateTime(dr["Fecha_InicioServ"]).Date;
                        oUsuSer.Fecha_Inicio = oUsuSer.Fecha_Estado;
                        oUsuSer.Fecha_Fin = new DateTime(oUsuSer.Fecha_Inicio.Year, oUsuSer.Fecha_Inicio.Month, 1).AddMonths(Convert.ToInt32(dr["meses_servicio"])).AddDays(-1).Date;
                        break;
                    case 3: // PERIODO
                        oUsuSer.Fecha_Estado = Convert.ToDateTime(dr["Fecha_InicioServ"]).Date;
                        oUsuSer.Fecha_Inicio = oUsuSer.Fecha_Estado;
                        //int meses = oTarifaSub.getMesesServicio(oUsuSer.Id_Servicios, Id_Tipo_Facturacion, Id_Tarifa_Vigente, Convert.);
                        oUsuSer.Fecha_Fin = oUsuSer.Fecha_Inicio.AddMonths(oUsuSer.Meses_Servicio).AddDays(-1).Date;
                        break;
                    case 5: //PERIODO CERRADO MES
                        oUsuSer.Fecha_Estado = Convert.ToDateTime(dr["Fecha_InicioServ"]).Date;
                        oUsuSer.Fecha_Inicio = oUsuSer.Fecha_Estado;
                        oUsuSer.Fecha_Fin = Convert.ToDateTime(dr["Fecha_FinServ"]).Date;

                        break;
                    case 6: //PERIODO CERRADO DIA
                        oUsuSer.Fecha_Estado = Convert.ToDateTime(dr["Fecha_InicioServ"]).Date;
                        oUsuSer.Fecha_Inicio = oUsuSer.Fecha_Estado;
                        oUsuSer.Fecha_Fin = Convert.ToDateTime(dr["Fecha_FinServ"]).Date;
                        break;
                    default:
                        break;
                }

                fecha_inicio = oUsuSer.Fecha_Inicio;

                oUsuSer.Fecha_Factura = oUsuSer.Fecha_Fin;
                oUsuSer.Tipo = dr["Modo"].ToString() == "UF" ? "UF" : "BO";
                oUsuSer.Cant_Bocas = Convert.ToInt32(dr["Cantidad"]);
                oUsuSer.Cant_Bocas_Pac = Convert.ToInt32(dr["CantidadPac"]);
                DataRow[] drZon;
                int Id_Tipo_Facturacion = 0;
                if (Convert.ToInt32(oConfiguracion.GetValor_N("Id_Tipo_Facturacion")) == 1)
                {
                    drZon = dtLocalidades.Select(String.Format("Id_Localidad = {0}", cboTipoFacturacion.SelectedValue));
                    dtServicios.DefaultView.RowFilter = String.Format("Id_Tipo_Facturacion = {0}", drZon[0]["Id_Zona"]);
                    Id_Tipo_Facturacion = Convert.ToInt32(drZon[0]["Id_Zona"]);

                }
                else
                {
                    //drZon = dtLocalidades.Select(String.Format("id = {0}", cboTipoFacturacion.SelectedValue));
                    //dtServicios.DefaultView.RowFilter = String.Format("Id_Tipo_Facturacion = {0}", drZon[0]["id"]);
                    Id_Tipo_Facturacion = Convert.ToInt32(cboTipoFacturacion.SelectedValue);

                }


                oUsuSer.Id_Tipo_Facturacion = Id_Tipo_Facturacion;
                oUsuSer.Id_Zonas = Id_Tipo_Facturacion;
                // oUsuSer.Id_Tipo_Facturacion = Convert.ToInt32(cboTipoFacturacion.SelectedValue);

                int dias = DateTime.DaysInMonth(DateTime.Today.Year, DateTime.Today.Month);

                int idUsuario_Servicios = oUsuSer.Guardar(oUsuSer);
                if (idUsuario_Servicios > 0)
                {
                    Log.guardarEvento(Log.ACCION.NUEVO_USUARIO_SERVICIO, Usuarios.CurrentUsuario.Id, Usuarios.Current_IdUsuarioLocacion, idUsuario_Servicios);
                    if(pasaEquipos)
                    {
                        string salidaMudaEquipo = "";
                        if(oEquipos.MudarEquiposUsuarioServicio(Convert.ToInt32(dgvServiciosContratados.SelectedRows[0].Cells["id_usuario_servicio"].Value),idUsuario_Servicios,out salidaMudaEquipo)==-1)
                            MessageBox.Show("Hubo un error al intentar actualizar los equipos al nuevo servicio \n " + salidaMudaEquipo, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }


                DataRow[] drSubservicios = dtServAContratar.Select(String.Format("Id_Contador_Servicios = {0} and Seleccion='True'", contador));
                int idUsuariosServiciosSub = 0;

                string fechaConexion = String.Empty;

                for (int i = 0; i < drSubservicios.Length; i++)
                {
                    idUsuariosServiciosSub = 0;
                    if (String.IsNullOrEmpty(drSubservicios[i]["fecha_conexion"].ToString()) == false)
                        fechaConexion = drSubservicios[i]["fecha_conexion"].ToString();

                    if (Convert.ToInt32(drSubservicios[i]["Id_Tipo"]) > 0)
                    {
                        if (drSubservicios[i]["Tipo"].ToString() == "S")
                            idUsuariosServiciosSub = oUsuSer.Guardar_Subservicios(0, idUsuario_Servicios, Convert.ToInt32(drSubservicios[i]["Id_Tipo"]), Convert.ToInt32(drSubservicios[i]["Id_Servicios_Velocidad"]), Convert.ToInt32(drSubservicios[i]["Id_Servicios_Velocidad_Tipo"]), Convert.ToInt32(drSubservicios[i]["Requiere_IP"]), Convert.ToInt32(drSubservicios[i]["Id_Bonificacion_Esp"]), Convert.ToInt32(drSubservicios[i]["Id_Bonificacion"]), Convert.ToDecimal(drSubservicios[i]["bonificacion"]), "", oUsuSer.Fecha_Inicio, oUsuSer.Fecha_Fin,(int)Borrados.Estado.Activo);
                        if (Convert.ToInt32(drSubservicios[i]["id_servicios_tipo_sub"]) == 1 && Convert.ToInt32(drSubservicios[i]["requiere_ip"]) == 1)
                        {
                            frmPopUp oPop = new frmPopUp();
                            Abms.ABMIpfijas frmIp = new Abms.ABMIpfijas(1);
                            oPop.Formulario = frmIp;
                            oPop.Maximizar = false;
                            if (oPop.ShowDialog() == DialogResult.OK)
                                oUsuSer.ActualizarIpFija(idUsuario_Servicios, Convert.ToInt32(drSubservicios[i]["Id_Tipo"]), frmIp.Id);
                            else
                                oUsuSer.ActualizarIpFija(idUsuario_Servicios, Convert.ToInt32(drSubservicios[i]["Id_Tipo"]), 1);
                        }
                    }

                    dtServAContratar.AcceptChanges();
                    dtServBonificaciones.AcceptChanges();
                    dtServBonificacionesDetalles.AcceptChanges();
                    dtDatosNovedades.AcceptChanges();

                    if ((i + 1) < drSubservicios.Length)
                    {
                        if (drSubservicios[i + 1]["item"].ToString() == string.Empty)
                            break;
                    }

                }

                contador++;
            }
        }

        private void boton1_Click(object sender, EventArgs e)
        {
            spMain.Panel1.Enabled = true;
            spMain.Panel2.Enabled = false;
            comenzarCarga();
        }

        private void CargarServicios()
        {
            if (Convert.ToInt32(cboTipoFacturacion.SelectedValue) > 0)
            {
                formatearGrillaNuevosServicios();
            }
        }

        private void formatearGrillaNuevosServicios()
        {
            dgvContrato.DataSource = dtServAContratar;
            dgvContrato.Columns["Id"].Visible = false;
            dgvContrato.Columns["Id_Contador_Servicios"].Visible = false;
            dgvContrato.Columns["Id_Servicios"].Visible = false;
            dgvContrato.Columns["Id_Servicios_Categoria"].Visible = false;
            dgvContrato.Columns["Id_Tipo"].Visible = false;
            dgvContrato.Columns["Servicio"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvContrato.Columns["Item"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvContrato.Columns["Modo"].HeaderText = "Tipo";
            dgvContrato.Columns["Modo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvContrato.Columns["Modo"].Width = 20;
            dgvContrato.Columns["Cantidad"].HeaderText = "Cant.";
            dgvContrato.Columns["Cantidad"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvContrato.Columns["Cantidad"].Width = 30;
            dgvContrato.Columns["CantidadPac"].HeaderText = "Cant.P.";
            dgvContrato.Columns["CantidadPac"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvContrato.Columns["CantidadPac"].Width = 30;
            dgvContrato.Columns["Tipo"].Visible = false;
            dgvContrato.Columns["Id_Usuarios_Servicios"].Visible = false;
            dgvContrato.Columns["Fecha_Conexion"].HeaderText = "F. Conexion";
            dgvContrato.Columns["Fecha_Conexion"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvContrato.Columns["Fecha_Conexion"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvContrato.Columns["Fecha_InicioServ"].HeaderText = "F. Inicio Serv.";
            dgvContrato.Columns["Fecha_InicioServ"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvContrato.Columns["Fecha_InicioServ"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvContrato.Columns["Fecha_FinServ"].HeaderText = "F. Fin Serv.";
            dgvContrato.Columns["Fecha_FinServ"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvContrato.Columns["Fecha_FinServ"].DefaultCellStyle.Format = "dd/MM/yyyy";

            dgvContrato.Columns["Importe"].Visible = false;
            dgvContrato.Columns["Importe"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvContrato.Columns["Importe"].DefaultCellStyle.Format = "C2";

            dgvContrato.Columns["Bonificacion"].Visible = false;
            dgvContrato.Columns["Bonificacion"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvContrato.Columns["Bonificacion"].DefaultCellStyle.Format = "N2";
            dgvContrato.Columns["Bonificacion"].HeaderText = "Bonif. (%)";
            dgvContrato.Columns["Bonificacion"].Width = 50;


            dgvContrato.Columns["Total"].Visible = false;
            dgvContrato.Columns["Total"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvContrato.Columns["Total"].DefaultCellStyle.Format = "C2";
            dgvContrato.ReadOnly = false;
            dgvContrato.Columns["Seleccion"].ReadOnly = false;
            dgvContrato.Columns["Id_Servicios_Velocidad"].Visible = false;
            dgvContrato.Columns["Id_Servicios_Velocidad_Tipo"].Visible = false;
            dgvContrato.Columns["Requiere_IP"].Visible = false;
            dgvContrato.Columns["Id_Bonificacion_Esp"].Visible = false;
            dgvContrato.Columns["Id_Bonificacion"].Visible = false;
            dgvContrato.Columns["Dias_Bonif"].Visible = false;
            dgvContrato.Columns["Meses"].Visible = false;
            dgvContrato.Columns["Id_Servicios_Tipos"].Visible = false;
            dgvContrato.Columns["Id_Servicios_Grupos"].Visible = false;
            dgvContrato.Columns["Id_Eliminar"].Visible = false;
            dgvContrato.Columns["Id_Servicios_Tipo_Sub"].Visible = false;
            dgvContrato.Columns["Id_Tarjeta"].Visible = false;
            dgvContrato.Columns["meses"].Visible = false;
            dgvContrato.Columns["meses_servicio"].Visible = false;
            dgvContrato.Columns["Id_Servicios_Modalidad"].Visible = false;
            dgvContrato.Columns["Id_usuarios_servicios_sub"].Visible = false;
            dgvContrato.Columns["Nombre"].Visible = false;
            dgvContrato.Columns["Id_Bonificacion_contratacion"].Visible = false;
            dgvContrato.Columns["id_tarifa_sub_esp"].Visible = false;

            foreach (DataGridViewColumn column in dgvContrato.Columns)
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        private void CalcularTotales()
        {
            object sumServ = dtServAContratar.Compute("sum(Total)", "Seleccion = true and Tipo = 'S'");

            object sumEqui = dtServAContratar.Compute("sum(Total)", "Seleccion = true and Tipo = 'E'");
            object sumCon = dtServAContratar.Compute("sum(Total)", "Seleccion = true and Tipo = 'P'");

            object sumSub = dtServAContratar.Compute("sum(Importe)", "Seleccion = true");

            sumServ = sumServ.ToString() == "" ? 0 : sumServ;
            sumEqui = sumEqui.ToString() == "" ? 0 : sumEqui;
            sumCon = sumCon.ToString() == "" ? 0 : sumCon;

            txtTotalServicio.Text = Convert.ToDecimal(sumServ).ToString("C2");
            txtTotalEquipamiento.Text = Convert.ToDecimal(sumEqui).ToString("C2");
            txtTotalConexion.Text = Convert.ToDecimal(sumCon).ToString("C2");

            txtTotal.Text = (Convert.ToDecimal(sumServ) + Convert.ToDecimal(sumEqui) + Convert.ToDecimal(sumCon)).ToString("C2");

            subTotal = sumSub == null || sumSub.ToString() == string.Empty ? 0 : Convert.ToDecimal(sumSub);
            importeTotal = Convert.ToDecimal(sumServ) + Convert.ToDecimal(sumEqui) + Convert.ToDecimal(sumCon);
            totalBonificacion = subTotal - importeTotal;



            //txtParte_TotalServicio.Text = txtTotalServicio.Text;
            //txtParte_TotalEquipos.Text = txtTotalEquipamiento.Text;
            //txtParte_TotalConexion.Text = txtTotalConexion.Text;
            //txtParte_Total.Text = txtTotal.Text;
        }

        private void ContadorServicios()
        {
            if (dtServAContratar.Rows.Count > 0)
            {
                int contador = 0;
                foreach (DataRow fila in dtServAContratar.Rows)
                {
                    if (fila["id_tipo"].ToString() == "0")
                        contador++;
                    fila["id_contador_servicios"] = contador;
                }
                dtServAContratar.AcceptChanges();
            }
        }
    }
}
