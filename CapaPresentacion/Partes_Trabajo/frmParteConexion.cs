using CapaNegocios;
using CapaPresentacion.Abms;
using CapaPresentacion.Busquedas;
using CapaPresentacion.General;
using CapaPresentacion.Impresiones;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace CapaPresentacion.Partes_Trabajo
{
    public partial class frmParteConexion : Form
    {
        #region [DECLARACIONES]
        private Thread hilo;
        private delegate void myDel();

        private DataTable dtZonas;
        private DataTable dtCategorias;
        private DataTable dtTipoDoc;
        private DataTable dtCompIVA;
        private DataTable dtCompIVAUsuario;
        private DataTable dtProfesiones;
        private DataTable dtLocalidades;
        private DataTable dtLocalidadesLocacion;
        private DataTable dtProvincias;
        private DataTable dtServicios;
        private DataTable dtSubservicios;
        private DataTable dtServiciosActivos = new DataTable();

        private DataTable dtServAContratar;
        private DataTable dtServContratados = new DataTable();
        private DataTable dtServABonificar;
        private DataTable dtServBonificaciones;
        private DataTable dtServBonificacionesDetalles;
        private DataTable dtDatosNovedades;
        private DataTable dtUsuariosEquipos;
        private DataTable dtDatosExtra = new DataTable();

        private DataRow drDatosTipoUsurio;

        private Provincias oProv = new Provincias();
        private Comprobantes oComprobante = new Comprobantes();
        private Comprobantes_Tipo oComprobante_Tipo = new Comprobantes_Tipo();
        private Usuarios oUsuario = new Usuarios();
        private Usuarios_Profesiones oUsuProf = new Usuarios_Profesiones();
        private Usuarios_Locaciones oUsuLocSer = new Usuarios_Locaciones();
        private Usuarios_Locaciones oUsuLocPos = new Usuarios_Locaciones();
        private Usuarios_Locaciones oUsuarioLocacion = new Usuarios_Locaciones();
        private Usuarios_Servicios oUsuSer = new Usuarios_Servicios();
        private UsuariosTipos oUsuariosTipos = new UsuariosTipos();
        private Servicios oServicio = new Servicios();
        private Servicios_Tarifas_Sub oTarifaSub = new Servicios_Tarifas_Sub();
        private Equipos_Tipos oEquipos_Tipos = new Equipos_Tipos();
        private Equipos oEquipos = new Equipos();
        private Partes_Solicitudes oPartes_Falla = new Partes_Solicitudes();
        private Zonas oZonas = new Zonas();
        private Localidades oLoc = new Localidades();
        private Servicios_Categorias oCat = new Servicios_Categorias();
        private Tipo_Facturacion oTipoFac = new Tipo_Facturacion();
        private Configuracion oConfig = new Configuracion();
        private Servicios_Condiciones oServ_Condiciones = new Servicios_Condiciones();
        private Bonificaciones Bonificacion = new Bonificaciones();
        private Servicios_Tarifas Tarifas = new Servicios_Tarifas();
        private Servicios_Tarifas_Sub_Esp oTarifaEsp = new Servicios_Tarifas_Sub_Esp();
        private Tools Tool = new Tools();
        private Equipos_Tarjetas oEquiposTarjetas = new Equipos_Tarjetas();
        private Usuarios_Servicios_Novedades oUsuariosServiciosNovedades = new Usuarios_Servicios_Novedades();
        private Usuarios_Ctacte_Det_Extra oUsuariosCtaCteDetExtra = new Usuarios_Ctacte_Det_Extra();
        private Usuarios_Servicios_Novedades oNovedades = new Usuarios_Servicios_Novedades();
        private Servicios_Sub oServicioSub = new Servicios_Sub();
        public Usuarios_Locaciones_Uf oUsuariosLocaconesUF = new Usuarios_Locaciones_Uf();

        private Int32 idServicioSel;
        private Int32 Id_Tipo_Usuario;
        private Int32 Id_Tarifa_Vigente = 0;
        private Int32 Id_Tipo_Facturacion = 0;
        private Int32 Id_Servicios_Categorias = 0;
        private Int32 Id_Servicios_Tarifas;
        private Decimal SubTotal;
        private Decimal TotalBonificacion;
        private Decimal ImporteTotal;
        private Decimal ImporteIPFija = 0;
        private Decimal importeTotalSub = 0;
        private int Config_Agenda;
        Tools oTools = new Tools();
        private Tipo_Facturacion.Id_Tipo_Facturacion TipoFacturacion = Tipo_Facturacion.Id_Tipo_Facturacion.POR_ZONAS;

        private DataRow drDatosComprobanteVenta;
        private DataRow drDatosSubServicios;

        Boolean cobrarServicios;

        private Int32 Altura_Desde = 0;
        private Int32 Altura_Hasta = 0;

        private Int32 IdTablaBonificacion = 0;
        private Int32 IdTablaBonificacionSub = 1;
        private Int32 IdTablaServicioUnico = 1;
        private Int32 idLocalidad = 0;
        private List<Int32> Lista_Id_Partes = new List<Int32>();

        private ABMUsuarios_LocacionFiscal frmLocFiscal = new ABMUsuarios_LocacionFiscal(0);

        public Int32 TipoOperacion;
        public Int32 idLocacionEdificio = 0;
        public string usuarioNombre;
        public string usuarioApellido;
        public Int32 idTipoFacturacion = 0;
        public int vieneUnidadesFuncionales = 0, idUsuarioEdificio = 0;

        private bool cambiosEnGrilla = false;
        private bool generarDeudas = true;


        /// <summary>
        /// ID Usuarios
        /// </summary>
        public Int32 IdUsuario
        {
            get { return oUsuario.Id; }
            set
            {
                oUsuario.Id = value;
            }
        }

        public Boolean MismaLocacion;

        #endregion  

        public frmParteConexion(Int32 idTipoUsu = 0)
        {
            InitializeComponent();
            this.Id_Tipo_Usuario = idTipoUsu;
        }

        #region[METODOS]
        private void ComenzarCarga()
        {
            pgCircular.Start();
            foreach (Control oControl in this.Controls)
            {
                if (oControl is PictureBox)
                    oControl.Enabled = true;
                else
                    oControl.Enabled = false;
            }
            hilo = new Thread(new ThreadStart(CargarDatos));
            hilo.Start();
        }

        private void CargarDatos()
        {
            Id_Servicios_Tarifas = Tarifas.getTarifaId();
            drDatosTipoUsurio = oUsuariosTipos.Listar(Id_Tipo_Usuario);
            try
            {
                switch (TipoFacturacion)
                {
                    case Tipo_Facturacion.Id_Tipo_Facturacion.POR_ZONAS:
                        dtZonas = oZonas.Listar();
                        dtLocalidades = oZonas.ListarLocZonas(0);
                        dtServicios = oTipoFac.GetServicios();
                        dtSubservicios = oTarifaSub.Listar(Id_Servicios_Tarifas);

                        dtLocalidades.Rows.Add(0, 0, 0, "[SELECCIONAR]");
                        break;
                    case Tipo_Facturacion.Id_Tipo_Facturacion.POR_CATEGORIAS:
                        dtLocalidades = oLoc.Listar();
                        dtCategorias = oCat.Listar();
                        dtCategorias.Rows.Add(0, "[SELECCIONAR]");

                        DataView dvC = dtCategorias.DefaultView;
                        dvC.Sort = "Nombre ASC";
                        dtCategorias = dvC.ToTable(true);
                        dtServicios = oTipoFac.GetServicios();
                        dtSubservicios = oTarifaSub.Listar(Id_Servicios_Tarifas);
                        dtLocalidades.Rows.Add(0, 0, "[SELECCIONAR]");
                        break;
                }

                ImporteIPFija = Convert.ToDecimal(oConfig.GetValor_Decimal("Costo_IP"));
                Config_Agenda = oConfig.GetValor_N("Agenda_Trabajo");

                DataView dv = dtLocalidades.DefaultView;
                dv.Sort = TipoFacturacion == Tipo_Facturacion.Id_Tipo_Facturacion.POR_ZONAS ? "Localidad ASC" : "Nombre ASC";
                dtLocalidades = dv.ToTable(true);

                dtCompIVA = oComprobante.ListarTipoIVA();
                dtCompIVAUsuario = oComprobante.ListarTipoIVAUsuario(Usuarios.CurrentUsuario.Id);
                dtTipoDoc = oUsuario.ListarTipoDoc();
                dtProvincias = oProv.Listar();
                dtProfesiones = oUsuProf.Listar();

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
                dtServAContratar.Columns.Add("NroTarjeta", typeof(String));
                //---------------------------------

                DataColumn colSel = new DataColumn("Seleccion", typeof(Boolean));
                colSel.DefaultValue = true;
                dtServAContratar.Columns.Add(colSel);

                dtServAContratar.Columns.Add(colId);

                dtServAContratar.Columns.Add("Id_Contador_Servicios", typeof(Int32));

                dtServContratados.Columns.Add("Id_Servicios", typeof(Int32));
                dtServContratados.Columns.Add("Id_Servicios_Categoria", typeof(Int32));
                dtServContratados.Columns.Add("Fecha_Conexion", typeof(DateTime));
                dtServContratados.Columns.Add("Fecha_InicioServ", typeof(DateTime));
                dtServContratados.Columns.Add("Fecha_FinServ", typeof(DateTime));
                dtServContratados.Columns.Add("Id_Servicios_Tipo", typeof(Int32));
                dtServContratados.Columns.Add("Modo", typeof(String));
                dtServContratados.Columns.Add("Cantidad", typeof(Int32));
                dtServContratados.Columns.Add("CantidadPac", typeof(Int32));
                dtServContratados.Columns.Add("Modalidad", typeof(Int32));
                dtServContratados.Columns.Add("Dias_Bonif", typeof(Int32));
                dtServContratados.Columns.Add("Meses", typeof(Int32));
                dtServContratados.Columns.Add("Id_Eliminar", typeof(Int32));
                dtServContratados.Columns.Add("Id_Servicios_Tipo_Sub", typeof(Int32));

                //--agregado por nueva modificación
                dtServContratados.Columns.Add("Meses_Servicio", typeof(Int32));
                //---------------------------------
                DataColumn colIdTarifaEsp = new DataColumn("id_tarifa_sub_esp", typeof(Int32));
                colIdTarifaEsp.DefaultValue = 0;
                dtServAContratar.Columns.Add(colIdTarifaEsp);
                dtServABonificar = Bonificacion.GenerarDtSubServicios();

                myDel MD = new myDel(AsignarDatos);

                this.Invoke(MD, new object[] { });

                pgCircular.Stop();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar Informacion" + ex.Message);
            }
        }

        private void AsignarDatos()
        {
            foreach (Control oControl in this.Controls)
                oControl.Enabled = true;
            if (TipoFacturacion == Tipo_Facturacion.Id_Tipo_Facturacion.POR_ZONAS)
                lblModalidad.Text = "Localidad:";


            cboTipoDoc.DataSource = dtTipoDoc;
            cboTipoDoc.DisplayMember = "Tipo";
            cboTipoDoc.ValueMember = "Id";
            if (Usuarios.CurrentUsuario.Id > 0)
            {
                cboCondIVA.DataSource = dtCompIVAUsuario;
                cboCondIVA.DisplayMember = "Descripcion";
                cboCondIVA.ValueMember = "Id_Comprobantes_Iva";
                cboCondIVA.Enabled = false;
            }
            else
            {
                cboCondIVA.DataSource = dtCompIVA;
                cboCondIVA.DisplayMember = "Descripcion";
                cboCondIVA.ValueMember = "Id";
            }

            cboProfesiones.DataSource = dtProfesiones;
            cboProfesiones.DisplayMember = "Nombre";
            cboProfesiones.ValueMember = "Id";

            dtLocalidadesLocacion = dtLocalidades.Copy();

            cboTipoFacturacion.DataSource = TipoFacturacion == Tipo_Facturacion.Id_Tipo_Facturacion.POR_ZONAS ? dtLocalidades : dtCategorias;
            cboTipoFacturacion.DisplayMember = TipoFacturacion == Tipo_Facturacion.Id_Tipo_Facturacion.POR_ZONAS ? "Localidad" : "Nombre";
            cboTipoFacturacion.ValueMember = TipoFacturacion == Tipo_Facturacion.Id_Tipo_Facturacion.POR_ZONAS ? "Id_Localidad" : "Id";

            cboTipoFacturacion.SelectedValue = idTipoFacturacion;
            if (oConfig.GetValor_N("Id_Tipo_Facturacion") == Convert.ToInt32(Tipo_Facturacion.Id_Tipo_Facturacion.POR_ZONAS) && (vieneUnidadesFuncionales > 0))
                cboTipoFacturacion.Enabled = false;

            if (this.IdUsuario > 0 || (idUsuarioEdificio > 0))
                CargarUsuario();
        }

        private bool VerificarCondicionesServicio(int idservicio)
        {
            DataTable dt = dtServAContratar.Copy();
            int idTipoFac = Convert.ToInt32(cboTipoFacturacion.SelectedValue);

            if (dtServiciosActivos.Rows.Count > 0)
            {
                foreach (DataRow dr in dtServiciosActivos.Rows)
                {
                    if (Convert.ToInt32(dr["id_estado"]) != (int)Servicios.Servicios_Estados.CORTADO && Convert.ToInt32(dr["id_estado"]) != (int)Servicios.Servicios_Estados.RETIRADO &&
                        Convert.ToInt32(dr["id_locacion"]) == Usuarios.CurrentUsuario.Id_Usuarios_Locacion)
                    {
                        DataRow drNueva = dt.NewRow();
                        drNueva["Id_Servicios"] = dr["Id_Servicio"];
                        drNueva["CantidadPac"] = dr["cant_bocas_pac"];
                        drNueva["Id_Servicios_Tipos"] = dr["id_servicio_tipo"];
                        drNueva["Id_Servicios_Grupos"] = dr["Id_Servicios_Grupos"];
                        drNueva["Id_Servicios_Tipo_Sub"] = 1;
                        drNueva["Id_Usuarios_Servicios"] = dr["Id_Usuario_Servicio"];
                        drNueva["id_servicios_categoria"] = dr["id_tipo_facturacion"];
                        dt.Rows.Add(drNueva);
                    }
                }

                dt.AcceptChanges();
            }

            DataView dtv = new DataView();
            dtv = dt.DefaultView;
            dtv.RowFilter = "Seleccion = true";


            dt.DefaultView.RowFilter = "Seleccion = true";
            dt = dtv.ToTable();

            return oServ_Condiciones.Verificar_Condiciones(idservicio, dt, idTipoFac);
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
                btnCalcularBonificaciones.Enabled = false;
                DataRow[] DataServiciosSel = dtServAContratar.Select("Seleccion = true");
                DataRow[] DataServiciosNoSel = dtServAContratar.Select("Seleccion = false");

                foreach (DataRow item in DataServiciosNoSel)
                    item["Importe"] = 0;


                if (oUsuario.Id > 0 || idUsuarioEdificio > 0)
                {
                    foreach (DataRow dr in dtServiciosActivos.Rows)
                    {
                        DataRow dataRow = dtServABonificar.NewRow();
                        dataRow["id_usuario_servicio"] = Convert.ToInt32(dr["id_usuario_servicio"]);
                        dataRow["id_usuario_servicio_sub"] = Convert.ToInt32(dr["id_usuario_servicio_sub"]);
                        dataRow["id_tipo_facturacion"] = this.Id_Tipo_Facturacion;
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
                        int modificaMeses = oConfig.GetValor_N("CambioMeses");
                        if (modificaMeses == Convert.ToInt32(Configuracion.CAMBIO_MESES.NO))
                        {
                            //--agregado por nueva modificación
                            dataRow["meses_cobro"] = Convert.ToUInt32(dr["id_servicio_modalidad"]) == Convert.ToInt32(Servicios._Modalidad.MENSUAL) ? 1 : oTarifaSub.getMesesCobro(Convert.ToInt32(dr["id_servicio"]), Id_Tipo_Facturacion, Id_Servicios_Tarifas, Convert.ToInt32(dr["id_velocidad"]), Convert.ToInt32(dr["id_velocidad_tipo"]));
                            dataRow["meses_servicio"] = Convert.ToUInt32(dr["id_servicio_modalidad"]) == Convert.ToInt32(Servicios._Modalidad.MENSUAL) ? 1 : oTarifaSub.getMesesServicio(Convert.ToInt32(dr["id_servicio"]), Id_Tipo_Facturacion, Id_Servicios_Tarifas, Convert.ToInt32(dr["id_velocidad"]), Convert.ToInt32(dr["id_velocidad_tipo"]));
                        }
                        else
                        {
                            dataRow["meses_cobro"] = Convert.ToUInt32(dr["id_servicio_modalidad"]) == Convert.ToInt32(Servicios._Modalidad.MENSUAL) ? 1 : oTarifaSub.getMesesCobro(Convert.ToInt32(dr["id_servicio"]), Id_Tipo_Facturacion, Id_Servicios_Tarifas, Convert.ToInt32(dr["id_velocidad"]), Convert.ToInt32(dr["id_velocidad_tipo"]));
                            dataRow["meses_servicio"] = Convert.ToUInt32(dr["id_servicio_modalidad"]) == Convert.ToInt32(Servicios._Modalidad.MENSUAL) ? 1 : oTarifaSub.getMesesServicio(Convert.ToInt32(dr["id_servicio"]), Id_Tipo_Facturacion, Id_Servicios_Tarifas, Convert.ToInt32(dr["id_velocidad"]), Convert.ToInt32(dr["id_velocidad_tipo"]));

                        }
                        dataRow["id_servicio_modalidad"] = Convert.ToUInt32(dr["id_servicio_modalidad"]);

                        dataRow["id_ip_fija"] = Convert.ToInt32(dr["id_ip_fija"]);

                        //--agregado por nueva modificación
                        dataRow["meses_cobro"] = Convert.ToUInt32(dr["meses_cobro"]);
                        dataRow["meses_servicio"] = Convert.ToUInt32(dr["meses_servicio"]);
                        dataRow["fecha_inicio_servicio"] = Convert.ToDateTime(dr["fecha_inicio"]);
                        dataRow["id_servicio_modalidad"] = Convert.ToUInt32(dr["id_servicio_modalidad"]);
                        //---------------------------------
                        dataRow["fecha_hasta_servicio"] = Convert.ToDateTime(dr["fecha_factura"]);
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
                            dataRow["id_tipo_facturacion"] = this.Id_Tipo_Facturacion;
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
                        dataRow["id_tipo_facturacion"] = this.Id_Tipo_Facturacion;
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
                        dataRow["fecha_hasta_servicio"] = DataServiciosSel[i]["fecha_finServ"].ToString();
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
                Bonificacion.CalcularBonificaciones(dtSoloSubServicios, Id_Servicios_Tarifas, true, 0, false);
                dtServBonificaciones = Bonificaciones.dtSubServicios;
                dtServBonificacionesDetalles = Bonificaciones.dtSubServiciosDetalles;
                dtDatosNovedades = Bonificaciones.dtDatosNovedades;
                //------------------------------

                //----------cálculo de novedades
                Facturacion oFacturacion = new Facturacion();
                oFacturacion.AplicarNovedades(dtServBonificaciones, dtServBonificacionesDetalles, 0, DateTime.Now, false);
                dtDatosExtra.Clear();
                dtDatosExtra = oFacturacion.dtExtras;
                //-------------------------------------------------------------
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


                        dataRows[0]["id_usuarios_servicios_sub"] = Convert.ToInt32(dr["id_usuario_servicio_sub"]);

                        dtServAContratar.AcceptChanges();
                    }
                }


                CalcularTotales();
                dgvContrato.CommitEdit(DataGridViewDataErrorContexts.Commit);
                btnCalcularBonificaciones.Enabled = true;
            }
            else
                MessageBox.Show("Debe contratar al menos un Servicio", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void AgregarServicio(Int32 IdServicios)
        {
            DataRow[] DrServicios = dtServicios.Select(String.Format("Id_Servicios = {0}", IdServicios));

            if (VerificarCondicionesServicio(IdServicios))
            {
                using (frmPopUp frm = new frmPopUp())
                {
                    frmParteConexion_Auxiliar frmAux = new frmParteConexion_Auxiliar();

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
                        Tarifas.Fecha_Actual = DateTime.Now;
                        Id_Tarifa_Vigente = Id_Servicios_Tarifas;
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
                    frmAux.TipoFacturacion = this.TipoFacturacion;
                    frmAux.IdTipoFacturacion = this.Id_Tipo_Facturacion;
                    frmAux.RequiereEquipo = DrServicios[0]["Requiere_Equipo"].ToString() == "SI" ? true : false;
                    frmAux.RequiereVelocidades = DrServicios[0]["Requiere_Velocidad"].ToString() == "SI" ? true : false;
                    frmAux.IdServiciosModalidad = IdServicioModalidad;
                    frmAux.DiasBonificacion = Convert.ToInt32(DrServicios[0]["Dias_Bonificacion"].ToString());
                    frm.Formulario = frmAux;
                    frm.Maximizar = false;

                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        DataRow DrServContratado = dtServContratados.NewRow();
                        DrServContratado["Id_Servicios"] = IdServicios;
                        DrServContratado["Id_Servicios_Categoria"] = frmAux.IdServiciosCategorias;
                        DrServContratado["Fecha_Conexion"] = frmAux.FechaConexionServicio;
                        if (IdServicioModalidad == Convert.ToInt32(Servicios._Modalidad.PERIODO_CERRADO_POR_MES))
                        {
                            if (DateTime.Compare(frmAux.FechaDesdePeriodoCerrado, DateTime.Now) < 0)
                                DrServContratado["Fecha_InicioServ"] = DateTime.Now.Date;
                            else
                                DrServContratado["Fecha_InicioServ"] = frmAux.FechaDesdePeriodoCerrado;
                            DrServContratado["Fecha_FinServ"] = frmAux.FechaHastaPeriodoCerrado;
                        }
                        else
                        {
                            DrServContratado["Fecha_InicioServ"] = frmAux.FechaInicioServicio;
                            DrServContratado["Fecha_FinServ"] = frmAux.FechaFinServicio;
                        }

                        DrServContratado["Id_Servicios_Tipo"] = IdServicioTipos;
                        DrServContratado["Modo"] = frmAux.Modo;
                        DrServContratado["Cantidad"] = frmAux.Cantidad;
                        DrServContratado["CantidadPac"] = frmAux.CantidadPactada;
                        DrServContratado["Modalidad"] = IdServicioModalidad;
                        DrServContratado["Dias_Bonif"] = 0;

                        //busco en la configuracion del sistema si se pueden modficar los meses cobro y meses servicio, si se puede tomo en cuenta los del frmaux (como avc) sino los que estan en la tarifa (como atcco)
                        Tarifas.Fecha_Actual = frmAux.FechaInicioServicio;
                        Id_Tarifa_Vigente = Id_Servicios_Tarifas;
                        int modificaMeses = oConfig.GetValor_N("CambioMeses");
                        if (modificaMeses == Convert.ToInt32(Configuracion.CAMBIO_MESES.NO))
                        {
                            //--agregado por nueva modificación

                            DrServContratado["Meses"] = Convert.ToUInt32(DrServicios[0]["Id_Servicios_Modalidad"]) == Convert.ToInt32(Servicios._Modalidad.MENSUAL) ? 1 : oTarifaSub.getMesesCobro(IdServicios, Id_Tipo_Facturacion, Id_Tarifa_Vigente, frmAux.IdServiciosVelocidades, frmAux.IdServiciosVelocidadesTipo);
                            //Tarifas.Fecha_Actual = frmAux.FechaInicioServicio;
                            //Id_Tarifa_Vigente = Id_Servicios_Tarifas;
                            DrServContratado["Meses_servicio"] = Convert.ToInt32(DrServicios[0]["Id_Servicios_Modalidad"]) == Convert.ToInt32(Servicios._Modalidad.MENSUAL) ? 1 : oTarifaSub.getMesesServicio(IdServicios, Id_Tipo_Facturacion, Id_Tarifa_Vigente, frmAux.IdServiciosVelocidades, frmAux.IdServiciosVelocidadesTipo);
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

                        dtServContratados.Rows.Add(DrServContratado);
                        dtServContratados.AcceptChanges();

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
                            if (DateTime.Compare(frmAux.FechaDesdePeriodoCerrado, DateTime.Now) < 0)
                                DrServAContratar["Fecha_InicioServ"] = DateTime.Now.Date;
                            else
                                DrServAContratar["Fecha_InicioServ"] = frmAux.FechaDesdePeriodoCerrado;

                        }
                        if (IdServicioModalidad == Convert.ToInt32(Servicios._Modalidad.PERIODO_CERRADO_POR_DIA))
                        {
                            DrServAContratar["Fecha_FinServ"] = frmAux.FechaFinServicio;

                        }
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
                                DataRowSubServicios = dtSubservicios.Select(String.Format("Id_Servicios = {0} AND Id_Tipo_Facturacion = {1} and dias_desde={2}", IdServicios, Id_Tipo_Facturacion, frmAux.CantDiasPeriodoCerrado));
                            else if (IdServicioModalidad == Convert.ToInt32(Servicios._Modalidad.PERIODO_CERRADO_POR_MES) && (requiereVelocidad == "NO"))
                                DataRowSubServicios = dtSubservicios.Select(String.Format("Id_Servicios = {0} AND Id_Tipo_Facturacion = {1} and id_servicios_tarifas_sub_esp={2}", IdServicios, Id_Tipo_Facturacion, frmAux.idTarifaPaquete));
                            else
                                DataRowSubServicios = dtSubservicios.Select(String.Format("Id_Servicios = {0} AND Id_Tipo_Facturacion = {1} ", IdServicios, Id_Tipo_Facturacion));
                        }
                        else
                            DataRowSubServicios = oTipoFac.GetServiciosSubPorTipo(Id_Tipo_Facturacion, IdServicios).Select("Id_Servicios_Sub > 0");

                        DataTable dtServiciosPorTipo = oTipoFac.Listar(Id_Tipo_Facturacion);
     
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
                                {
                                    DrServAContratar["Item"] = DrServAContratar["Item"] + " IP FIJA";

                                }

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
                                    if (DateTime.Compare(frmAux.FechaDesdePeriodoCerrado, DateTime.Now) < 0)
                                        DrServAContratar["Fecha_InicioServ"] = DateTime.Now.Date;
                                    else
                                        DrServAContratar["Fecha_InicioServ"] = frmAux.FechaDesdePeriodoCerrado;
                                    DrServAContratar["Fecha_FinServ"] = frmAux.FechaHastaPeriodoCerrado;
                                }
                                else
                                {
                                    if (IdServicioModalidad == Convert.ToInt32(Servicios._Modalidad.PERIODO_CERRADO_POR_MES))
                                    {
                                        if (DateTime.Compare(frmAux.FechaDesdePeriodoCerrado, DateTime.Now) < 0)
                                            DrServAContratar["Fecha_InicioServ"] = DateTime.Now.Date;
                                        else
                                            DrServAContratar["Fecha_InicioServ"] = frmAux.FechaDesdePeriodoCerrado;
                                    }
                                    else
                                        DrServAContratar["Fecha_InicioServ"] = frmAux.FechaInicioServicio;
                                    DrServAContratar["Fecha_FinServ"] = frmAux.FechaFinServicio;

                                }
                                DrServAContratar["Fecha_Conexion"] = frmAux.FechaConexionServicio;


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
                                    DrServAContratar["Meses"] = Convert.ToUInt32(DrServicios[0]["Id_Servicios_Modalidad"]) == Convert.ToInt32(Servicios._Modalidad.MENSUAL) ? 1 : oTarifaSub.getMesesCobro(IdServicios, Id_Tipo_Facturacion, Id_Tarifa_Vigente, frmAux.IdServiciosVelocidades, frmAux.IdServiciosVelocidadesTipo);
                                    Tarifas.Fecha_Actual = frmAux.FechaInicioServicio;
                                    Id_Tarifa_Vigente = Id_Servicios_Tarifas;
                                    DrServAContratar["Meses_servicio"] = Convert.ToInt32(DrServicios[0]["Id_Servicios_Modalidad"]) == Convert.ToInt32(Servicios._Modalidad.MENSUAL) ? 1 : oTarifaSub.getMesesServicio(IdServicios, Id_Tipo_Facturacion, Id_Tarifa_Vigente, frmAux.IdServiciosVelocidades, frmAux.IdServiciosVelocidadesTipo);
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
                                if(oConfig.GetValor_N("CobroIp")==2)
                                {
                                    //si es dos es porque  la ip esta se toma desde el subservicio, en este caso si tildo ip en el frmaux ya debe aparecer tiltado en servicios a contratar
                                    if (Convert.ToInt32(DataRowSubServicios[i]["idtipodesub"]) == 3 && (frmAux.ContrataIPFija == 1))
                                        DrServAContratar["Seleccion"] = 1;
                                    else
                                        DrServAContratar["Seleccion"] = Convert.ToInt32(DataRowSubServicios[i]["valor_defecto"]);
                                }
                                else
                                    DrServAContratar["Seleccion"] = Convert.ToInt32(DataRowSubServicios[i]["valor_defecto"]);


                                dtServAContratar.Rows.Add(DrServAContratar);
                            }
                        }

                        DataTable DataSolicitudes = TipoOperacion > 1 ? oPartes_Falla.GetDatosServicios(IdServicios, false, Convert.ToInt32(Partes.Partes_Operaciones.FACTIBILIDAD)) : oPartes_Falla.GetDatosServicios(IdServicios, true, Convert.ToInt32(Partes.Partes_Operaciones.CONEXION));

                        if (DataSolicitudes.Rows.Count > 0)
                        {
                            foreach (DataRow dr in DataSolicitudes.Rows)
                            {
                                DrServAContratar = dtServAContratar.NewRow();
                                DrServAContratar["Id_Servicios"] = IdServicios;
                                DrServAContratar["Servicio"] = Servicio;
                                DrServAContratar["Item"] = dr["Nombre"].ToString();
                                DrServAContratar["Importe"] = 0;
                                DrServAContratar["Bonificacion"] = 0;
                                DrServAContratar["Modo"] = frmAux.Modo;
                                DrServAContratar["Cantidad"] = frmAux.Cantidad;
                                DrServAContratar["CantidadPac"] = frmAux.CantidadPactada;
                                DrServAContratar["Total"] = 0;
                                DrServAContratar["Categoria"] = string.Empty;
                                DrServAContratar["Id_Tipo"] = dr["Id"].ToString();
                                DrServAContratar["Tipo"] = "P";
                                DrServAContratar["Fecha_Conexion"] = frmAux.FechaConexionServicio;
                                if (IdServicioModalidad == Convert.ToInt32(Servicios._Modalidad.PERIODO_CERRADO_POR_MES))
                                {
                                    if (DateTime.Compare(frmAux.FechaDesdePeriodoCerrado, DateTime.Now) < 0)
                                        DrServAContratar["Fecha_InicioServ"] = DateTime.Now.Date;
                                    else
                                        DrServAContratar["Fecha_InicioServ"] = frmAux.FechaDesdePeriodoCerrado;
                                    DrServAContratar["Fecha_FinServ"] = frmAux.FechaHastaPeriodoCerrado;
                                }
                                else
                                {
                                    DrServAContratar["Fecha_FinServ"] = frmAux.FechaFinServicio;
                                    DrServAContratar["Fecha_InicioServ"] = frmAux.FechaInicioServicio;
                                }

                                DrServAContratar["Id_Servicios_Velocidad"] = 0;
                                DrServAContratar["Id_Servicios_Velocidad_Tipo"] = 0;
                                DrServAContratar["Requiere_IP"] = frmAux.ContrataIPFija;
                                DrServAContratar["Id_Usuarios_Servicios"] = 0;
                                DrServAContratar["Id_Bonificacion_Esp"] = 0;
                                DrServAContratar["Id_Bonificacion"] = 0;
                                DrServAContratar["Dias_Bonif"] = 0;
                                DrServAContratar["Meses"] = 1;
                                DrServAContratar["Id_Servicios_Tipos"] = IdServicioTipos;
                                DrServAContratar["Id_Servicios_Grupos"] = IdServicioGrupos;
                                DrServAContratar["Id_Eliminar"] = IdTablaServicioUnico;
                                DrServAContratar["Id_servicios_tipo_sub"] = 0;
                                DrServAContratar["Id_Tarjeta"] = 0;

                                //--agregado por nueva modificacion
                                DrServAContratar["Id_Servicios_Modalidad"] = IdServicioModalidad;
                                //-------------------------------------

                                dtServAContratar.Rows.Add(DrServAContratar);
                            }
                        }


                        if (frmAux.DataEquiposSeleccionados.Rows.Count > 0)
                        {
                            foreach (DataRow dr in frmAux.DataEquiposSeleccionados.Rows)
                            {
                                DrServAContratar = dtServAContratar.NewRow();
                                DrServAContratar["Id_Servicios"] = IdServicios;
                                DrServAContratar["Servicio"] = Servicio;
                                DrServAContratar["Item"] = dr["Tipo"].ToString();
                                DrServAContratar["Importe"] = 0;
                                DrServAContratar["Bonificacion"] = 0;
                                DrServAContratar["Modo"] = frmAux.Modo;
                                //DrServAContratar["Cantidad"] = frmAux.Cantidad;
                                //DrServAContratar["CantidadPac"] = frmAux.CantidadPactada;

                                DrServAContratar["Cantidad"] = Convert.ToInt32(dr["Cantidad"]);

                                DrServAContratar["CantidadPac"] = Convert.ToInt32(dr["Cantidad"]);

                                DrServAContratar["Total"] = 0;
                                DrServAContratar["Categoria"] = string.Empty;
                                DrServAContratar["Id_Tipo"] = dr["Id"].ToString();
                                DrServAContratar["Tipo"] = "E";
                                // DrServAContratar["Fecha_Conexion"] = DBNull.Value;
                                // DrServAContratar["Fecha_InicioServ"] = DBNull.Value;
                                DrServAContratar["Fecha_Conexion"] = frmAux.FechaConexionServicio;
                                DrServAContratar["Fecha_InicioServ"] = frmAux.FechaInicioServicio;
                                DrServAContratar["Id_Servicios_Velocidad"] = 0;
                                DrServAContratar["Id_Servicios_Velocidad_Tipo"] = 0;
                                DrServAContratar["Requiere_IP"] = frmAux.ContrataIPFija;
                                DrServAContratar["Id_Usuarios_Servicios"] = 0;
                                DrServAContratar["Id_Bonificacion_Esp"] = 0;
                                DrServAContratar["Id_Bonificacion"] = 0;
                                DrServAContratar["Dias_Bonif"] = 0;
                                DrServAContratar["Meses"] = 1;
                                DrServAContratar["Id_Servicios_Tipos"] = IdServicioTipos;
                                DrServAContratar["Id_Servicios_Grupos"] = IdServicioGrupos;
                                DrServAContratar["Id_Eliminar"] = IdTablaServicioUnico;
                                DrServAContratar["Id_servicios_tipo_sub"] = 0;
                                DrServAContratar["Id_Tarjeta"] = Convert.ToInt32(dr["Id_Tarjeta"]);
                                DrServAContratar["NroTarjeta"] = dr["Tarjeta"].ToString();

                                //---agregado por modificacion
                                if (IdServicioModalidad == Convert.ToInt32(Servicios._Modalidad.PERIODO_CERRADO_POR_MES) && (requiereVelocidad == "NO"))
                                {
                                    if (DateTime.Compare(frmAux.FechaDesdePeriodoCerrado, DateTime.Now) < 0)
                                        DrServAContratar["Fecha_InicioServ"] = DateTime.Now.Date;
                                    else
                                        DrServAContratar["Fecha_InicioServ"] = frmAux.FechaDesdePeriodoCerrado;
                                    DrServAContratar["Fecha_FinServ"] = frmAux.FechaHastaPeriodoCerrado;
                                    DrServAContratar["Id_Servicios_Modalidad"] = IdServicioModalidad;
                                }
                                else
                                {
                                    if (IdServicioModalidad == Convert.ToInt32(Servicios._Modalidad.PERIODO_CERRADO_POR_MES))
                                    {
                                        if (DateTime.Compare(frmAux.FechaDesdePeriodoCerrado, DateTime.Now) < 0)
                                            DrServAContratar["Fecha_InicioServ"] = DateTime.Now.Date;
                                        else
                                            DrServAContratar["Fecha_InicioServ"] = frmAux.FechaDesdePeriodoCerrado;
                                    }
                                    else
                                        DrServAContratar["Fecha_InicioServ"] = frmAux.FechaInicioServicio;
                                    DrServAContratar["Fecha_FinServ"] = frmAux.FechaFinServicio;
                                    DrServAContratar["Id_Servicios_Modalidad"] = IdServicioModalidad;

                                }
                                //-----------------------

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

        private Boolean ValidarLocacion()
        {
            if (oUsuLocSer.Id == 0)
            {
                DataTable dtLocacionesExistentes = new DataTable();
                DialogResult dialogResult;

                if (txtCalleServicio.Text == "")
                {
                    MessageBox.Show("Debe Ingresar una calle.", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    {
                        lblAvisoCalle.Visible = true;
                        BuscarCalle();

                        return false;

                    }
                }
                if (txtAlturaServicio.Text == "")
                {
                    MessageBox.Show("Debe Ingresar la altura de la calle seleccionada.", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    {
                        txtAlturaServicio.Focus();
                        return false;

                    }
                }

                dtLocacionesExistentes = oUsuLocSer.VerificarExistenciaLocacion(Convert.ToInt32(cboLocalidades.SelectedValue), Convert.ToInt32(txtCalleServicio.Tag), Convert.ToInt32(txtAlturaServicio.Text), txtPisoServicio.Text, txtDeptoServicio.Text, txtEntreCalleServicio_1.Text, txtEntreCalleServicio_2.Text, Usuarios_Locaciones.CONTEMPLAR_NOMBRE_LIMITES_CALLES.SI);
                if (dtLocacionesExistentes.Rows.Count > 0)
                {
                    dialogResult = MessageBox.Show("Ya hay locaciones en el sistema que concuerdan con los datos de locación ingresados. ¿Desea verlas?", "", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        frmLocacionesDeServicioExistentes frmLocacionesExistentes = new frmLocacionesDeServicioExistentes(dtLocacionesExistentes, 0, 0, 0, String.Empty, String.Empty, String.Empty, String.Empty);
                        frmPopUp frmPU = new frmPopUp();
                        frmPU.Formulario = frmLocacionesExistentes;
                        frmPU.ShowDialog();
                    }
                    MessageBox.Show("Si quiere cambiar de locación, modifique los datos ingresados.");
                    return true;
                }
            }
            return true;
        }

        private Boolean ValidarUsuario()
        {
            if (txtApellido.Text.Trim() == "")
            {
                MessageBox.Show("Debe Ingresar el Apellido del Usuario", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                txtApellido.Focus();

                return false;
            }

            if (txtNombre.Text.Trim() == "")
            {
                MessageBox.Show("Debe Ingresar el Nombre del Usuario", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                txtNombre.Focus();

                return false;
            }

            if (txtNumero.Text == "")
            {
                MessageBox.Show("Debe Ingresar el Numero de Documento", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                txtNumero.Focus();

                return false;
            }
            try
            {
                if (Convert.ToDecimal(txtNumero.Text) == 0)
                {
                    MessageBox.Show("Debe Ingresar el Numero de Documento", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtNumero.Focus();
                    return false;

                }

            }
            catch
            {

            }

            if (chkAdhesionFac.CheckState == CheckState.Checked)
            {
                if (txtCorreo.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("Debe Ingresar el Correo Electronico", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    txtCorreo.Focus();

                    return false;

                }
                else
                {
                    if (Tool.ComprobarFormatoEmail(txtCorreo.Text) == false)
                    {
                        MessageBox.Show("Formato de Correo Electronico Incorrecto", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                        txtCorreo.Focus();

                        return false;
                    }
                }
            }
            else
            {
                if (txtCorreo.Text != "")
                {
                    if (Tool.ComprobarFormatoEmail(txtCorreo.Text) == false)
                    {
                        MessageBox.Show("Formato de Correo Electronico Incorrecto", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                        txtCorreo.Focus();

                        return false;
                    }
                }
            }


            if (Convert.ToInt32(cboCondIVA.SelectedValue) > 1 && txtCUIT.Text == "")
            {
                MessageBox.Show("Debe Ingresar el Numero de CUIT", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                txtCUIT.Focus();

                return false;
            }
            try
            {
                if ((Convert.ToInt32(cboCondIVA.SelectedValue) > 1) && (Convert.ToDecimal(txtCUIT.Text) == 0))
                {
                    MessageBox.Show("Debe Ingresar el Numero de Documento", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtCUIT.Focus();
                    return false;
                }

            }
            catch
            {

            }
            if (txtTelefono_1.Text == "")
            {
                if (MessageBox.Show("No ha ingresado el Numero de Telefono. ¿Desea Agregarlo?", "Mensaje del Sistema",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    txtTelefono_1.Focus();

                    return false;

                }
            }

            if (txtTelefono_2.Text == "")
            {
                if (MessageBox.Show("No ha ingresado el Numero de Celular. ¿Desea Agregarlo?", "Mensaje del Sistema",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    txtTelefono_2.Focus();

                    return false;
                }

            }
            return true;
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

            SubTotal = sumSub == null || sumSub.ToString() == string.Empty ? 0 : Convert.ToDecimal(sumSub);
            ImporteTotal = Convert.ToDecimal(sumServ) + Convert.ToDecimal(sumEqui) + Convert.ToDecimal(sumCon);
            TotalBonificacion = SubTotal - ImporteTotal;



            txtParte_TotalServicio.Text = txtTotalServicio.Text;
            txtParte_TotalEquipos.Text = txtTotalEquipamiento.Text;
            txtParte_TotalConexion.Text = txtTotalConexion.Text;
            txtParte_Total.Text = txtTotal.Text;
        }

        private void IngresarParte()
        {
            drDatosComprobanteVenta = oComprobante_Tipo.GetNumeracion(Convert.ToInt32(Comprobantes_Tipo.Tipo.COMPROBANTE_DEUDA), Puntos_Cobros.Id_Punto);

            oUsuario.Apellido = txtApellido.Text;
            oUsuario.Nombre = txtNombre.Text;
            oUsuario.Id_Usuarios_TipoDoc = Convert.ToInt32(cboTipoDoc.SelectedValue);
            oUsuario.Numero_Documento = txtNumero.Text == "" ? 0 : Convert.ToDouble(txtNumero.Text);
            oUsuario.Id_Comprobantes_Iva = Convert.ToInt32(cboCondIVA.SelectedValue);
            oUsuario.CUIT = txtCUIT.Text == "" ? 0 : Convert.ToDouble(txtCUIT.Text);
            if (oConfig.GetValor_C("Retencion") == "S")
            {
                oUsuario.Impuesto_Provincial = oTools.NuevoAbonadoPADRONARBA(oUsuario.CUIT.ToString());
                if (oUsuario.Impuesto_Provincial == 0)
                    oUsuario.Exento_Impuesto_Provincial = 1;
                else
                    oUsuario.Exento_Impuesto_Provincial = 0;
            }
            else
                oUsuario.Exento_Impuesto_Provincial = 1;

            oUsuario.Nacimiento = dtpNacimiento.Value;
            oUsuario.Id_Usuarios_Profesiones = Convert.ToInt32(cboProfesiones.SelectedValue);
            oUsuario.Correo_Electronico = txtCorreo.Text;
            oUsuario.Adhesion_FacDigital = chkAdhesionFac.CheckState == CheckState.Checked ? 1 : 0;
            oUsuario.Id_Usuarios_Tipos = Convert.ToInt32(Usuarios.Usuarios_Tipos.ABONADO);
            oUsuLocSer.Id_Localidades = Convert.ToInt32(cboLocalidades.SelectedValue);
            oUsuLocSer.Id_Calle = Convert.ToInt32(txtCalleServicio.Tag);
            oUsuLocSer.Calle = txtCalleServicio.Text;
            oUsuLocSer.Altura = txtAlturaServicio.Text == "" ? 0 : Convert.ToInt32(txtAlturaServicio.Text);
            oUsuLocSer.Piso = txtPisoServicio.Text;
            oUsuLocSer.Depto = txtDeptoServicio.Text;
            oUsuLocSer.Codigo_Postal = txtCPServicio.Text;
            oUsuLocSer.Manzana = txtManzServicio.Text;
            oUsuLocSer.Parcela = txtParcelaServicio.Text;
            oUsuLocSer.Entre_Calle_1 = txtEntreCalleServicio_1.Text;
            oUsuLocSer.Entre_Calle_2 = txtEntreCalleServicio_2.Text;
            oUsuLocSer.Prefijo_1 = txtPrefijo_1.Text == string.Empty ? 0 : Convert.ToInt32(txtPrefijo_1.Text);
            oUsuLocSer.Telefono_1 = txtTelefono_1.Text == string.Empty ? 0 : Convert.ToInt32(txtTelefono_1.Text);
            oUsuLocSer.Prefijo_2 = txtPrefijo_2.Text == string.Empty ? 0 : Convert.ToInt32(txtPrefijo_2.Text);
            oUsuLocSer.Telefono_2 = txtTelefono_2.Text == string.Empty ? 0 : Convert.ToInt32(txtTelefono_2.Text);
            oUsuLocSer.Observacion = txtObservacionLocacion.Text;
            oUsuLocSer.Activo = 0;
            oUsuLocSer.Tipo = "SV";

            int idUsuario = oUsuario.Guardar(oUsuario);
            if (IdUsuario > 0)
            {
                Log.guardarEvento(Log.ACCION.NUEVO_USUARIO, IdUsuario);
            }
            if (vieneUnidadesFuncionales > 0)
            {
                oUsuariosLocaconesUF.Id = vieneUnidadesFuncionales;
                oUsuariosLocaconesUF.IdUsuario = IdUsuario;
                oUsuariosLocaconesUF.Nombre = oUsuario.Nombre;
                oUsuariosLocaconesUF.Apellido = oUsuario.Apellido;
                oUsuariosLocaconesUF.Depto = oUsuLocSer.Depto;
                oUsuariosLocaconesUF.Piso = oUsuLocSer.Piso;
                oUsuariosLocaconesUF.Descripcion = "s";
                oUsuariosLocaconesUF.Guardar(oUsuariosLocaconesUF, idLocacionEdificio);
                Log.guardarEvento(Log.ACCION.NUEVA_UNIDAD_FUNCIONAL, IdUsuario);

            }

            oUsuario.LlenarObjeto(oUsuario.Id);

            Usuarios.CurrentUsuario.Id = idUsuario;
            //Usuarios.CurrentUsuario.Codigo = CurrentUsuario.Codigo;

            if (idUsuario > 0)
            {
                Boolean preguntaCobraServicios = Convert.ToBoolean(drDatosTipoUsurio["Servicios"]);
                cobrarServicios = chCobraServicios.Checked;

                if (txtObsUsuario.Text != String.Empty)
                {
                    oNovedades.Id_Usuarios = idUsuario;
                    oNovedades.Detalle = txtObsUsuario.Text;
                    oNovedades.Fecha_Desde = DateTime.Now;
                    oNovedades.Fecha_Hasta = DateTime.Now;
                    oNovedades.Id_tipo = Convert.ToInt32(Usuarios_Servicios_Novedades.Novedades_Tipos.PARTES);
                    oNovedades.Imprimir = Convert.ToInt32(Usuarios_Servicios_Novedades.Imprime.OPERADOR);
                    oNovedades.Id_Usuarios_Locaciones = 0;
                    oNovedades.Id_Servicios = 0;
                    oNovedades.Id_Origen = Convert.ToInt32(Usuarios_Servicios_Novedades.Origen.SISTEMA);
                    oNovedades.GuardarObsUsuario(oNovedades);
                    Log.guardarEvento(Log.ACCION.NUEVA_NOVEDAD, IdUsuario);

                }

                if (oUsuLocSer.Id == 0)
                {
                    oUsuLocSer.Id = oUsuLocSer.Guardar(idUsuario, oUsuLocSer);
                    Log.guardarEvento(Log.ACCION.NUEVA_LOCACION, IdUsuario, oUsuLocSer.Id);

                }


                if (oUsuariosLocaconesUF.Id > 0)
                {
                    Int32 retorno = 0;
                    oUsuariosLocaconesUF.GuardarRelacion(oUsuLocSer.Id, oUsuariosLocaconesUF.Id);
                    oUsuariosLocaconesUF.EditarRelacionPadre(oUsuLocSer.Id, oUsuariosLocaconesUF.Id, idLocacionEdificio);

                    if (retorno < 0)
                        MessageBox.Show("Ocurrio un error al guardar relacion UF");

                }

                Usuarios.CurrentUsuario.Id_Usuarios_Locacion = oUsuLocSer.Id;

                DateTime fecha_inicio = new DateTime().Date;
                DateTime fecha_fin = new DateTime().Date;

                int contador = 1;

                foreach (DataRow dr in dtServContratados.Rows)
                {
                    Usuarios_Servicios oUsuSer = new Usuarios_Servicios();

                    oUsuSer.Id_Usuarios = idUsuario;
                    oUsuSer.Id_Zonas = this.Id_Tipo_Facturacion;
                    oUsuSer.Id_Usuarios_Locaciones = oUsuLocSer.Id;
                    oUsuSer.Id_Servicios = Convert.ToInt32(dr["Id_Servicios"]);
                    oUsuSer.Id_Servicios_Tipo = Convert.ToInt32(dr["Id_Servicios_Tipo"]);
                    oUsuSer.Id_Servicios_Categorias = Convert.ToInt32(dr["Id_Servicios_Categoria"]);
                    oUsuSer.Id_Servicios_Estados = TipoOperacion == 1 ? Convert.ToInt32(Servicios.Servicios_Estados.SIN_CONECTAR) : Convert.ToInt32(Servicios.Servicios_Estados.CON_FACTIBILIDAD);
                    oUsuSer.Meses_Cobro = Convert.ToInt32(dr["Meses"]);
                    oUsuSer.Meses_Servicio = Convert.ToInt32(dr["Meses_Servicio"]);
                    switch (Convert.ToInt32(dr["Modalidad"]))
                    {
                        case 1: // DIARIO
                            oUsuSer.Fecha_Estado = Convert.ToDateTime(dr["Fecha_InicioServ"]);
                            oUsuSer.Fecha_Inicio = oUsuSer.Fecha_Estado;
                            oUsuSer.Fecha_Fin = Convert.ToDateTime(dr["Fecha_FinServ"]); //DateTime.Today.AddDays(Convert.ToUInt32(dr["Dias_Bonif"]));
                            oUsuSer.Fecha_Factura = oUsuSer.Fecha_Fin;
                            oUsuSer.Fecha_Factura_Desde = oUsuSer.Fecha_Inicio;
                            break;
                        case 2: // MENSUAL
                            oUsuSer.Fecha_Estado = Convert.ToDateTime(dr["Fecha_InicioServ"]).Date;
                            oUsuSer.Fecha_Inicio = oUsuSer.Fecha_Estado;
                            oUsuSer.Fecha_Fin = new DateTime(oUsuSer.Fecha_Inicio.Year, oUsuSer.Fecha_Inicio.Month, 1).AddMonths(Convert.ToInt32(dr["meses_servicio"])).AddDays(-1).Date;
                            oUsuSer.Fecha_Factura = oUsuSer.Fecha_Fin;
                            oUsuSer.Fecha_Factura_Desde = oUsuSer.Fecha_Inicio;
                            break;
                        case 3: // PERIODO
                            oUsuSer.Fecha_Estado = Convert.ToDateTime(dr["Fecha_InicioServ"]).Date;
                            oUsuSer.Fecha_Inicio = oUsuSer.Fecha_Estado;
                            //int meses = oTarifaSub.getMesesServicio(oUsuSer.Id_Servicios, Id_Tipo_Facturacion, Id_Tarifa_Vigente, Convert.);
                            oUsuSer.Fecha_Fin = oUsuSer.Fecha_Inicio.AddMonths(oUsuSer.Meses_Servicio).AddDays(-1).Date;
                            oUsuSer.Fecha_Factura = oUsuSer.Fecha_Fin;
                            oUsuSer.Fecha_Factura_Desde = oUsuSer.Fecha_Inicio;
                            break;
                        case 5: //PERIODO CERRADO MES
                            oUsuSer.Fecha_Estado = Convert.ToDateTime(dr["Fecha_InicioServ"]).Date;
                            oUsuSer.Fecha_Inicio = oUsuSer.Fecha_Estado;
                            oUsuSer.Fecha_Fin = Convert.ToDateTime(dr["Fecha_FinServ"]).Date;
                            oUsuSer.Fecha_Factura = oUsuSer.Fecha_Fin;
                            oUsuSer.Fecha_Factura_Desde = oUsuSer.Fecha_Inicio;

                            break;
                        case 6: //PERIODO CERRADO DIA
                            oUsuSer.Fecha_Estado = Convert.ToDateTime(dr["Fecha_InicioServ"]).Date;
                            oUsuSer.Fecha_Inicio = oUsuSer.Fecha_Estado;
                            oUsuSer.Fecha_Fin = Convert.ToDateTime(dr["Fecha_FinServ"]).Date;
                            oUsuSer.Fecha_Factura = oUsuSer.Fecha_Fin;
                            oUsuSer.Fecha_Factura_Desde = oUsuSer.Fecha_Inicio;
                            break;
                        default:
                            break;
                    }

                    fecha_inicio = oUsuSer.Fecha_Inicio;
                    if (cobrarServicios == false)
                    {
                        oUsuSer.Fecha_Factura_Desde = DateTime.Now;
                        oUsuSer.Fecha_Factura = DateTime.Now;
                        oUsuSer.Fecha_Fin = DateTime.Now;
                    }
                    oUsuSer.Tipo = dr["Modo"].ToString() == "UF" ? "UF" : "BO";
                    oUsuSer.Cant_Bocas = Convert.ToInt32(dr["Cantidad"]);
                    oUsuSer.Cant_Bocas_Pac = Convert.ToInt32(dr["CantidadPac"]);
                    oUsuSer.Id_Tipo_Facturacion = this.Id_Tipo_Facturacion;

                    int dias = DateTime.DaysInMonth(DateTime.Today.Year, DateTime.Today.Month);

                    //oUsuSer.Fecha_Fin = new DateTime(DateTime.Today.Year, DateTime.Today.Month, dias);

                    int idUsuario_Servicios = oUsuSer.Guardar(oUsuSer);
                    if (idUsuario_Servicios > 0)
                        Log.guardarEvento(Log.ACCION.NUEVO_USUARIO_SERVICIO, idUsuario, oUsuLocSer.Id, idUsuario_Servicios);
                    //fecha_fin = fecha_fin.Date < oUsuSer.Fecha_Fin.Date ? oUsuSer.Fecha_Fin : fecha_fin;


                    if (idUsuario > 0)
                    {
                        //DataRow[] drSubservicios = dtServAContratar.Select(String.Format("Id_Servicios = {0} and Seleccion = True and Id_Usuarios_Servicios = 0", oUsuSer.Id_Servicios));

                        DataRow[] drSubservicios = dtServAContratar.Select(String.Format("Id_Contador_Servicios = {0} and Seleccion='True'", contador));
                        int idUsuariosServiciosSub = 0;
                        DataRow[] drSubServicioBonificacion;
                        DataRow[] drSubServicioDetalle;
                        DataRow[] drDatosNovedad;
                        DataRow[] drDatosExtra;
                        string fechaConexion = String.Empty;

                        for (int i = 0; i < drSubservicios.Length; i++)
                        {
                            idUsuariosServiciosSub = 0;
                            if (String.IsNullOrEmpty(drSubservicios[i]["fecha_conexion"].ToString()) == false)
                                fechaConexion = drSubservicios[i]["fecha_conexion"].ToString();

                            if (Convert.ToInt32(drSubservicios[i]["Id_Tipo"]) > 0)
                            {
                                if (drSubservicios[i]["Tipo"].ToString() == "S")
                                    idUsuariosServiciosSub = oUsuSer.Guardar_Subservicios(0, idUsuario_Servicios, Convert.ToInt32(drSubservicios[i]["Id_Tipo"]), Convert.ToInt32(drSubservicios[i]["Id_Servicios_Velocidad"]), Convert.ToInt32(drSubservicios[i]["Id_Servicios_Velocidad_Tipo"]), Convert.ToInt32(drSubservicios[i]["Requiere_IP"]), Convert.ToInt32(drSubservicios[i]["Id_Bonificacion_Esp"]), Convert.ToInt32(drSubservicios[i]["Id_Bonificacion"]), Convert.ToDecimal(drSubservicios[i]["bonificacion"]), "", oUsuSer.Fecha_Inicio, oUsuSer.Fecha_Fin, (int)Borrados.Estado.Activo);
                                //-----actualización de la tabla dtservbonificaciones para luego usarla en la generación de novedades automática
                                drSubServicioBonificacion = dtServBonificaciones.Select(String.Format("id_usuario_servicio_sub='{0}'", drSubservicios[i]["id_usuarios_servicios_sub"].ToString()));

                                if (drSubservicios[i]["Tipo"].ToString() == "S")
                                    drSubServicioBonificacion[0]["id_usuario_servicio_sub"] = idUsuariosServiciosSub;

                                drSubServicioBonificacion[0]["id_usuario_servicio"] = idUsuario_Servicios;
                                drSubServicioBonificacion[0]["importe_con_descuento"] = drSubservicios[i]["total"];
                                drSubServicioBonificacion[0]["id_usuarios"] = idUsuario;
                                drSubServicioBonificacion[0]["id_usuarios_locaciones"] = oUsuLocSer.Id;
                                drSubServicioBonificacion[0]["meses_servicio"] = drSubservicios[i]["meses"];
                                drSubServicioBonificacion[0]["fecha_contratacion"] = fechaConexion;
                                //-------------------------------------------------------------------------------------------
                                //---actualización tabla dtservbonificacionesdetalles
                                drSubServicioDetalle = dtServBonificacionesDetalles.Select(String.Format("id_usuarios_servicios_sub='{0}'", drSubservicios[i]["id_usuarios_servicios_sub"].ToString()));
                                foreach (DataRow detalle in drSubServicioDetalle)
                                {
                                    if (drSubservicios[i]["Tipo"].ToString() == "S")
                                        detalle["id_usuarios_servicios_sub"] = idUsuariosServiciosSub;
                                    detalle["id_usuarios_servicios"] = idUsuario_Servicios;
                                }
                                //------actualización tabla dtdatosnovedades

                                if (drSubservicios[i]["Tipo"].ToString() == "S")
                                {
                                    drDatosNovedad = dtDatosNovedades.Select(String.Format("id_usuarios_servicios_sub='{0}'", drSubservicios[i]["id_usuarios_servicios_sub"].ToString()));
                                    foreach (DataRow novedad in drDatosNovedad)
                                    {
                                        novedad["id_usuarios_servicios_sub"] = idUsuariosServiciosSub;
                                        novedad["id_usuarios_servicios"] = idUsuario_Servicios;
                                        novedad["id_usuarios"] = idUsuario;
                                        novedad["id_usuarios_locaciones"] = oUsuLocSer.Id;
                                    }
                                }

                                drSubservicios[i]["Id_Usuarios_Servicios"] = idUsuario_Servicios;
                                if (drSubservicios[i]["Tipo"].ToString() == "S")
                                    drSubservicios[i]["id_usuarios_servicios_sub"] = idUsuariosServiciosSub;

                                //--- actualización ids usuariosserviciossub tabla extras
                                drDatosExtra = dtDatosExtra.Select(String.Format("id_usuario_servicio_sub='{0}'", drSubservicios[i]["id_usuarios_servicios_sub"].ToString()));
                                foreach (DataRow drExtra in drDatosExtra)
                                    drExtra["id_usuario_servicio_sub"] = idUsuariosServiciosSub.ToString();

                            }


                            dtServAContratar.AcceptChanges();
                            dtServBonificaciones.AcceptChanges();
                            dtServBonificacionesDetalles.AcceptChanges();
                            dtDatosNovedades.AcceptChanges();
                            dtDatosExtra.AcceptChanges();

                            if ((i + 1) < drSubservicios.Length)
                            {
                                if (drSubservicios[i + 1]["item"].ToString() == string.Empty)
                                    break;
                            }

                        }
                    }

                    contador++;
                }

                Usuarios_CtaCte oCtaCte = new Usuarios_CtaCte();

                //verifico el tipo de usuario, si se le tiene que preguntar si se cobra los servicios o no



                //recorro los servicios contratados para ob
                if (generarDeudas)
                {

                    if (TipoOperacion == 1)
                    {
                        //obtengo el valor de la suma total-los subservicios (excepto el derecho de conexion)
                        try
                        {
                            object sumSubServ = dtServAContratar.Compute("sum(Total)", "Seleccion = true and Tipo = 'S' and (Id_Servicios_Tipo_sub=1 or Id_Servicios_Tipo_sub=2 or Id_Servicios_Tipo_sub=3)");
                            importeTotalSub = Convert.ToDecimal(sumSubServ);
                        }
                        catch { importeTotalSub = 0; }

                        oComprobante.Id_Usuarios = idUsuario;
                        oComprobante.Fecha = DateTime.Now;
                        oComprobante.Punto_Venta = Convert.ToInt32(drDatosComprobanteVenta["numPuntoVenta"]);
                        oComprobante.Id_Comprobantes_Tipo = Convert.ToInt32(Comprobantes_Tipo.Tipo.COMPROBANTE_DEUDA);
                        oComprobante.Numero = Convert.ToInt32(drDatosComprobanteVenta["numComprobante"]);
                        oComprobante.Id_Punto_Venta = Convert.ToInt32(drDatosComprobanteVenta["idPuntoVenta"]);
                        if (cobrarServicios == false)
                            oComprobante.Importe = (SubTotal - TotalBonificacion) - importeTotalSub;
                        else
                            oComprobante.Importe = SubTotal - TotalBonificacion;

                        oComprobante.Id_Usuarios_Locaciones = oUsuLocSer.Id;
                        oComprobante.Id_Personal = Personal.Id_Login;
                        oComprobante.Id_Punto_Cobro = Puntos_Cobros.Id_Punto;
                        oComprobante.Id = oComprobante.Guardar(oComprobante);

                        if (oComprobante.Id > 0)
                        {
                            oComprobante_Tipo.SetNumeracion(Convert.ToInt32(drDatosComprobanteVenta["idPuntoVenta"]), Convert.ToInt32(Comprobantes_Tipo.Tipo.COMPROBANTE_DEUDA), oComprobante.Numero);
                            Log.guardarEvento(Log.ACCION.NUEVO_COMPROBANTE, idUsuario, oUsuLocSer.Id);
                        }


                        oCtaCte.Id_Usuarios = oUsuario.Id;
                        oCtaCte.Id_Usuarios_Locacion = oUsuLocSer.Id;
                        oCtaCte.Id_Comprobantes = oComprobante.Id;
                        oCtaCte.Fecha_Movimiento = DateTime.Now;


                        oCtaCte.Fecha_Desde = Convert.ToDateTime(dtServContratados.Compute("MIN(Fecha_InicioServ)", null));
                        oCtaCte.Fecha_Hasta = Convert.ToDateTime(dtServContratados.Compute("MAX(Fecha_FinServ)", null)); ;
                        oCtaCte.Descripcion = String.Format("COMPROBANTE DE DEUDA {0}-{1}", oComprobante.Punto_Venta.ToString().PadLeft(4, '0'), oComprobante.Numero.ToString().PadLeft(8, '0'));
                        //oCtaCte.Importe_Original = oComprobante.Importe;
                        oCtaCte.Importe_Original = SubTotal;


                        oCtaCte.Importe_Bonificacion = TotalBonificacion;
                        oCtaCte.Importe_Punitorio = 0;
                        if (cobrarServicios == false)
                        {
                            oCtaCte.Importe_Original = oComprobante.Importe;
                            oCtaCte.Importe_Final = (SubTotal - TotalBonificacion) - importeTotalSub;

                        }
                        else
                        {
                            oCtaCte.Importe_Original = SubTotal;
                            oCtaCte.Importe_Final = SubTotal - TotalBonificacion;
                        }

                        oCtaCte.Importe_Saldo = oCtaCte.Importe_Final;
                        oCtaCte.Numero = oComprobante.Numero.ToString();
                        oCtaCte.Id_Comprobantes_Tipo = oComprobante.Id_Comprobantes_Tipo;
                        oCtaCte.Id_Facturacion = 0;
                        oCtaCte.Generado_facturacion_mensual = Convert.ToInt32(Usuarios_CtaCte.GENERADO_FACTURACION_MENSUAL.NO);
                        oCtaCte.Id_Personal = Personal.Id_Login;
                        oCtaCte.Id_Origen = (int)Usuarios_CtaCte.ORIGEN.PARTE_CONEXION;
                        oCtaCte.Porcentaje_Percepcion = oUsuario.Impuesto_Provincial;
                        oCtaCte.Percepcion = 1;

                        oCtaCte.Id = oCtaCte.Guardar(oCtaCte);
                        if (oCtaCte.Id > 0)
                        {
                            Log.guardarEvento(Log.ACCION.NUEVO_CTACTE, IdUsuario, oUsuLocSer.Id);
                        }
                    }
                }

                Int32 Cantidad_Periodo = 1;

                Partes oParte = new Partes();

                DataTable dtPartes = oParte.Get_Estructura_Partes();
                DataRow[] drEquipos = null;
                foreach (DataRow dr2 in dtServAContratar.Rows)
                {
                    if (dr2["Item"].ToString() != "")
                    {
                        if (dr2["Tipo"].ToString() == "P" && (Convert.ToBoolean(dr2["Seleccion"]) == true))
                        {
                            var idServicio = Convert.ToInt32(dr2["Id_Servicios"]);
                            DataRow drParte = dtPartes.NewRow();
                            drParte["Id"] = 0;
                            drParte["Id_Usuarios"] = oUsuario.Id;
                            drParte["Id_Servicios"] = Convert.ToInt32(dr2["Id_Servicios"]);
                            drParte["Id_Usuarios_Servicios"] = Convert.ToInt32(dr2["Id_Usuarios_Servicios"]);
                            drParte["Id_Servicios_Tipos"] = Convert.ToInt32(dr2["Id_Servicios_Tipos"]);
                            drParte["Id_Servicios_Grupos"] = Convert.ToInt32(dr2["Id_Servicios_Grupos"]);
                            drParte["Id_Usuarios_Locaciones"] = oUsuLocSer.Id;
                            drParte["Id_Zonas"] = this.Id_Tipo_Facturacion;
                            drParte["Id_Partes_Fallas"] = Convert.ToInt32(dr2["Id_Tipo"]);
                            drParte["Id_Partes_Soluciones"] = 0;
                            drParte["Id_Movil"] = 0;
                            drParte["Id_Tecnico"] = 0;

                            Int32 Id_Partes_Estados = 0;

                            drEquipos = dtServAContratar.Select(String.Format("Id_Servicios = {0} and Tipo = 'E'", idServicio));

                            if (Config_Agenda == Convert.ToInt32(Agenda_Encabezado.Uso_agenda.TRABAJA_CON_AGENDA))
                                Id_Partes_Estados = Convert.ToInt32(Partes.Partes_Estados.PENDIENTE_DE_ASIGNACION_DE_TECNICO);
                            else
                            {
                                if (oServicio.Listar().Select("Id=" + Convert.ToInt32(dr2["Id_Servicios"]) + "")[0]["Requiere_Equipo"].ToString() == "SI")
                                    Id_Partes_Estados = Convert.ToInt32(Partes.Partes_Estados.PENDIENTE_DE_ASIGNACION_DE_EQUIPO);
                                else
                                    Id_Partes_Estados = Convert.ToInt32(Partes.Partes_Estados.PENDIENTE_DE_ASIGNACION_DE_TECNICO);
                            }

                            drParte["Id_Partes_Estados"] = Id_Partes_Estados;

                            drParte["Id_Operadores"] = Personal.Id_Login;
                            drParte["Id_Areas"] = Personal.Id_Area;
                            drParte["Id_Locacion_Anterior"] = 0;
                            drParte["Fecha_Reclamo"] = DateTime.Now;
                            drParte["Fecha_Programado"] = Convert.ToDateTime(dr2["Fecha_Conexion"]).Date;
                            drParte["Detalle_Falla"] = TipoOperacion == 1 ? "CONEXION DE SERVICIO" : "FACTIBILIDAD DE SERVICIO";
                            drParte["Detalle_Solucion"] = "";
                            drParte["Id_Comprobantes"] = oComprobante.Id;
                            drParte["Tipo"] = dr2["Tipo"].ToString();
                            drParte["IdTipoEquipo"] = dr2["Id_Tipo"];

                            dtPartes.Rows.Add(drParte);
                            dtPartes.AcceptChanges();
                        }
                    }
                }
                DataTable dtPartesHechos = new DataTable();
                dtPartesHechos = oParte.AgruparPartesTrabajo(dtPartes);

                foreach (DataRow item in dtPartesHechos.Rows)
                {
                    oParte.SetearEstadoParte(Convert.ToInt32(item["id"]), 0, Config_Agenda == Convert.ToInt32(Agenda_Encabezado.Uso_agenda.TRABAJA_CON_AGENDA) ? Convert.ToInt32(Partes.Partes_Estados.PENDIENTE_DE_ASIGNACION_DE_TECNICO) : 0, DateTime.Now, 0, 0, string.Empty);

                    Partes_Historial _Historial = new Partes_Historial();
                    _Historial.Fecha_Movimiento = DateTime.Now;
                    _Historial.Id_Usuarios = Convert.ToInt32(item["Id_Usuarios"]);
                    _Historial.Id_Parte = Convert.ToInt32(item["Id"]);
                    _Historial.Id_Personal = Personal.Id_Login;
                    _Historial.Id_area = Personal.Id_Area;
                    _Historial.NombreArea = Personal.Area_Login;
                    _Historial.Id_Partes_Estados = Convert.ToInt32(Partes.Partes_Estados.PENDIENTE_DE_ASIGNACION_DE_TECNICO);
                    _Historial.Detalles = "PARTE DE CONEXION";
                    _Historial.GuardarNuevoDetalle(_Historial);
                }

                DataRow[] drEquiposPartes = dtServAContratar.Select("Tipo='E'");

                DataTable dtPartesUsuariosServicios = new DataTable();
                DataTable dtPartesUsuariosServiciosAux = new DataTable();
                Partes_Usuarios_Servicios oPartesUsuariosServicios = new Partes_Usuarios_Servicios();
                foreach (DataRow item in dtPartesHechos.Rows)
                {
                    dtPartesUsuariosServiciosAux = oPartesUsuariosServicios.ListarServiciosPorParte(Convert.ToInt32(item["id"]), Partes_Usuarios_Servicios.CONDICION_REQ_EQUIPOS.TODOS);
                    if (dtPartesUsuariosServicios.Rows.Count == 0)
                        dtPartesUsuariosServicios = dtPartesUsuariosServiciosAux.Clone();

                    foreach (DataRow parteUsuarioServicio in dtPartesUsuariosServiciosAux.Rows)
                        dtPartesUsuariosServicios.ImportRow(parteUsuarioServicio);
                    dtPartesUsuariosServiciosAux.Clear();



                    Servicios_Estados_Historial oServicios_Estados_Historial = new Servicios_Estados_Historial();
                    oServicios_Estados_Historial.id_servicios_estados = Convert.ToInt32(Servicios.Servicios_Estados.SIN_CONECTAR);
                    oServicios_Estados_Historial.id_servicios = Convert.ToInt32(item["id_servicios"]);
                    oServicios_Estados_Historial.id_usuarios = Convert.ToInt32(item["id_usuarios"]);
                    oServicios_Estados_Historial.id_usuarios_servicios = Convert.ToInt32(item["id_usuarios_servicios"]);
                    oServicios_Estados_Historial.fecha = DateTime.Now;
                    oServicios_Estados_Historial.Guardar(oServicios_Estados_Historial);

                }

                Int32 idParte = 0;
                if (drEquiposPartes != null)
                {
                    DataTable dtAppExternas = new DataTable();
                    Aplicaciones_Externas oAppExternas = new Aplicaciones_Externas();
                    int idAppExternaAsociada = 0;
                    DataView dvServicio= dtServicios.DefaultView;
                    DataTable dtServiciosFiltrado = new DataTable();
                    DataTable dtAppExterna = new DataTable();
                    foreach (DataRow dr2 in drEquiposPartes)
                    {
                        for (int i = 0; i < Convert.ToInt32(dr2["Cantidad"]); i++)
                        {
                            Partes_Equipos oParte_Equi = new Partes_Equipos();
                            oParte_Equi.Id_Usuarios = oUsuario.Id;
                            oParte_Equi.Id_Servicios = Convert.ToInt32(dr2["Id_Servicios"]);
                            oParte_Equi.Id_Equipos_Tipos = Convert.ToInt32(dr2["Id_Tipo"]);
                            oParte_Equi.Id_Usuarios_Servicios = Convert.ToInt32(dr2["Id_Usuarios_Servicios"]);
                            oParte_Equi.Id_Tarjeta = Convert.ToInt32(dr2["Id_Tarjeta"]);

                            try
                            {
                                if (oParte_Equi.Id_Tarjeta > 0)
                                {
                                    oEquiposTarjetas.CambiarEstadoTarjeta(oParte_Equi.Id_Tarjeta, Convert.ToInt32(Equipos_Tarjetas.Tarjetas_Estados.ENTREGADA));
                                    
                                    dvServicio.RowFilter =string.Format("id_servicios = {0} and id_aplicaciones_externas > 0", Convert.ToInt32(dr2["Id_Servicios"]));
                                    dtServiciosFiltrado = dvServicio.ToTable();
                                    if(dtServiciosFiltrado.Rows.Count>0)
                                    {
                                        idAppExternaAsociada = Convert.ToInt32(dtServiciosFiltrado.Rows[0]["id_aplicaciones_externas"]);
                                        dtAppExterna = oAppExternas.Listar(idAppExternaAsociada);
                                        if(dtAppExterna.Rows.Count>0)
                                        {
                                            if(dtAppExterna.Rows[0]["nombre"].ToString().ToLower().Equals("cass"))
                                            {
                                                Cass oCass = new Cass(idAppExternaAsociada);
                                            }
                                        }

                                    }
                                   
                                    
                                }


                            }
                            catch { }

                            foreach (DataRow item in dtPartesUsuariosServicios.Rows)
                            {
                                if (Convert.ToInt32(item["Id_Usuarios_Servicios"]) == oParte_Equi.Id_Usuarios_Servicios)
                                    idParte = Convert.ToInt32(item["id_parte"]);
                            }
                            oParte_Equi.Id_Partes = idParte;
                            oParte_Equi.Guardar(oParte_Equi);
                        }

                    }

                }

                DateTime fechaInicial = new DateTime();
                DateTime fechaFinal = new DateTime();
                DateTime fechaDesde = new DateTime();
                DataRow[] drMesesCtaCteDet;

                if (generarDeudas)
                {
                    foreach (DataRow dr2 in dtServAContratar.Rows)
                    {
                        if (dr2["Fecha_InicioServ"].ToString().Length > 0)
                        {
                            fechaInicial = Convert.ToDateTime(dr2["Fecha_InicioServ"]);
                        }
                        if (dr2["Fecha_FinServ"].ToString().Length > 0)
                        {
                            fechaFinal = Convert.ToDateTime(dr2["Fecha_FinServ"]);
                        }

                        fechaDesde = fechaInicial;

                        if (dr2["Item"].ToString() != "")
                        {
                            if (TipoOperacion == 1)
                            {
                                if (Convert.ToBoolean(dr2["Seleccion"]) == true)
                                {
                                    Boolean agregoDerecho = false;

                                    drMesesCtaCteDet = dtServBonificacionesDetalles.Select("id_usuarios_servicios_sub='" + dr2["id_usuarios_servicios_sub"].ToString() + "' and id_usuarios_servicios='" + dr2["id_usuarios_servicios"].ToString() + "' and tipo_servicio_sub='" + dr2["tipo"].ToString() + "'");

                                    foreach (DataRow fila in drMesesCtaCteDet)
                                    {
                                        if (Convert.ToInt32(fila["id_usuarios_servicios_sub_tipos"]) == Convert.ToInt32(Servicios_Sub.SERVICIO_SUB_TIPOS.DERECHO_DE_CONEXION))
                                        {
                                            if (agregoDerecho == true)
                                                continue;
                                        }
                                        //SI NO HAY QUE COBRAR LOS SERVICIOS ("S")...
                                        int idTipoSub = 0;
                                        if (cobrarServicios == false)
                                        {
                                            int idSub = Convert.ToInt32(dr2["id_tipo"]); //con este id de subservicio busco los datos del mismo (para saber de que tipo es:1,2,3 o 4)
                                            if (dr2["tipo"].ToString().Equals("S"))
                                            {
                                                drDatosSubServicios = oServicioSub.TraerDatosSubServicio(idSub);
                                                idTipoSub = Convert.ToInt32(drDatosSubServicios["Id_Servicios_Sub_Tipos"]);
                                            }
                                            if ((!dr2["tipo"].ToString().Equals("S") || ((dr2["tipo"].ToString().Equals("S"))) && (idTipoSub == 4))) //COBRO TODO MENOS LOS "S" (SI SE COBRA EL DERECHO)
                                            {
                                                Usuarios_CtaCte_Det oCtaCteDet = new Usuarios_CtaCte_Det();
                                                oCtaCteDet.Id_Usuarios_CtaCte = oCtaCte.Id;
                                                oCtaCteDet.Id_Usuarios_Locaciones = oUsuLocSer.Id;
                                                oCtaCteDet.Id_Zonas = this.Id_Tipo_Facturacion;
                                                oCtaCteDet.Id_Servicios = Convert.ToInt32(fila["Id_Servicios"]);
                                                oCtaCteDet.Id_Tipo = Convert.ToInt32(dr2["id_tipo"]);
                                                oCtaCteDet.Tipo = dr2["tipo"].ToString();
                                                oCtaCteDet.Importe_Punitorio = 0;
                                                oCtaCteDet.Importe_Original = Convert.ToDecimal(fila["importe_original"]);
                                                oCtaCteDet.Importe_Bonificacion = oCtaCteDet.Importe_Original - Convert.ToDecimal(fila["importe_con_descuento"]);
                                                oCtaCteDet.Importe_Saldo = oCtaCteDet.Importe_Original - oCtaCteDet.Importe_Bonificacion;
                                                oCtaCteDet.Id_Usuarios_Servicios = Convert.ToInt32(fila["Id_Usuarios_Servicios"]);
                                                oCtaCteDet.Id_Velocidades_Tip = Convert.ToInt32(fila["Id_Servicios_Velocidades_Tipos"]);
                                                oCtaCteDet.Id_Velocidades = Convert.ToInt32(fila["Id_Servicios_Velocidades"]);
                                                oCtaCteDet.Requiere_IP = Convert.ToInt32(fila["Requiere_IP"]);
                                                oCtaCteDet.Cantidad_Periodos = Cantidad_Periodo;
                                                if (Convert.ToInt32(dr2["id_Servicios_Modalidad"]) == Convert.ToInt32(Servicios._Modalidad.PERIODO_CERRADO_POR_MES))
                                                {
                                                    oCtaCteDet.Fecha_Desde = Convert.ToDateTime(dr2["Fecha_InicioServ"]);
                                                    oCtaCteDet.Fecha_Hasta = Convert.ToDateTime(dr2["Fecha_FinServ"]);
                                                }
                                                else
                                                {
                                                    if (Convert.ToInt32(dr2["id_Servicios_Modalidad"]) == Convert.ToInt32(Servicios._Modalidad.PERIODO_CERRADO_POR_DIA))
                                                    {
                                                        oCtaCteDet.Fecha_Desde = Convert.ToDateTime(dr2["Fecha_InicioServ"]);
                                                        oCtaCteDet.Fecha_Hasta = fechaFinal;
                                                    }
                                                    else
                                                    {
                                                        oCtaCteDet.Fecha_Desde = Convert.ToDateTime(fila["fecha_desde"]);
                                                        oCtaCteDet.Fecha_Hasta = Convert.ToDateTime(fila["fecha_hasta"]);
                                                    }

                                                }


                                                oCtaCteDet.Periodo_Ano = Convert.ToDateTime(fila["fecha_desde"]).Year;
                                                oCtaCteDet.Periodo_Mes = Convert.ToDateTime(fila["fecha_desde"]).Month;
                                                oCtaCteDet.Porcentaje_Bonificacion = 0;
                                                oCtaCteDet.Nombre_Bonificacion = String.Empty;
                                                oCtaCteDet.Id_bonificacion_Aplicada = 0;

                                                if (oCtaCteDet.Tipo == "S")
                                                    oCtaCteDet.Id_Usuarios_Servicios_sub = oUsuSer.Get_Id_Usuarios_Servicios_Sub(oCtaCteDet.Id_Usuarios_Servicios, oCtaCteDet.Id_Tipo);
                                                oCtaCteDet.Id_Tipo_Registro_Cta_Cte_Det = 0;
                                                oCtaCteDet.Id = oCtaCteDet.Guardar(oCtaCteDet);

                                                if (oCtaCteDet.Id > 0)
                                                {
                                                    if (Convert.ToInt32(fila["id_bonificacion"]) > 0)
                                                    {
                                                        oUsuariosCtaCteDetExtra.Id_Extra = Convert.ToInt32(fila["id_bonificacion"]);
                                                        oUsuariosCtaCteDetExtra.Id_Tipo_Extra = Convert.ToInt32(Usuarios_Ctacte_Det_Extra.TiposExtras.BONIFICACION);
                                                        oUsuariosCtaCteDetExtra.Id_Usuarios_CtaCte_Det = oCtaCteDet.Id;
                                                        oUsuariosCtaCteDetExtra.Porcentaje = Convert.ToDecimal(fila["porcentaje_parcial"]);
                                                        oUsuariosCtaCteDetExtra.Importe_original = Convert.ToDecimal(fila["importe_original"]);
                                                        if (Convert.ToInt32(fila["id_bonificacion_contratacion"]) > 0)
                                                            oUsuariosCtaCteDetExtra.Importe_Nuevo = Convert.ToDecimal(fila["importe_con_descuento_parcial"]);
                                                        else
                                                            oUsuariosCtaCteDetExtra.Importe_Nuevo = Convert.ToDecimal(fila["importe_con_descuento"]);
                                                        oUsuariosCtaCteDetExtra.Detalle = fila["nombre_bonificacion"].ToString();
                                                        oUsuariosCtaCteDetExtra.Extra = String.Empty;
                                                        oUsuariosCtaCteDetExtra.Guardar(oUsuariosCtaCteDetExtra);
                                                    }

                                                    if (Convert.ToInt32(fila["id_bonificacion_contratacion"]) > 0)
                                                    {
                                                        oUsuariosCtaCteDetExtra.Id_Extra = Convert.ToInt32(fila["id_bonificacion_contratacion"]);
                                                        oUsuariosCtaCteDetExtra.Id_Tipo_Extra = Convert.ToInt32(Usuarios_Ctacte_Det_Extra.TiposExtras.NOVEDAD);
                                                        oUsuariosCtaCteDetExtra.Id_Usuarios_CtaCte_Det = oCtaCteDet.Id;
                                                        oUsuariosCtaCteDetExtra.Porcentaje = Convert.ToDecimal(fila["porcentaje_contratacion"]);
                                                        oUsuariosCtaCteDetExtra.Importe_original = Convert.ToDecimal(fila["importe_con_descuento_parcial"]);
                                                        oUsuariosCtaCteDetExtra.Importe_Nuevo = Convert.ToDecimal(fila["importe_con_descuento"]);
                                                        oUsuariosCtaCteDetExtra.Detalle = fila["detalle_contratacion"].ToString();
                                                        oUsuariosCtaCteDetExtra.Extra = String.Empty;
                                                        oUsuariosCtaCteDetExtra.Guardar(oUsuariosCtaCteDetExtra);
                                                    }

                                                    foreach (DataRow drExtra in dtDatosExtra.Select(String.Format("id_usuario_servicio_sub='{0}' and nro_mes='{1}'", fila["id_usuarios_servicios_sub"].ToString(), fila["nro_mes"].ToString())))
                                                    {
                                                        oUsuariosCtaCteDetExtra.Id_Extra = Convert.ToInt32(drExtra["id_extra"]);
                                                        oUsuariosCtaCteDetExtra.Id_Tipo_Extra = Convert.ToInt32(drExtra["id_tipo_extra"]);
                                                        oUsuariosCtaCteDetExtra.Id_Usuarios_CtaCte_Det = oCtaCteDet.Id;
                                                        oUsuariosCtaCteDetExtra.Porcentaje = Convert.ToDecimal(drExtra["porcentaje"]);
                                                        oUsuariosCtaCteDetExtra.Importe_original = Convert.ToDecimal(drExtra["importe_original"]);
                                                        oUsuariosCtaCteDetExtra.Importe_Nuevo = Convert.ToDecimal(drExtra["importe_nuevo"]);
                                                        oUsuariosCtaCteDetExtra.Detalle = drExtra["detalle"].ToString();
                                                        oUsuariosCtaCteDetExtra.Extra = drExtra["descripcion_extra"].ToString();
                                                        oUsuariosCtaCteDetExtra.Guardar(oUsuariosCtaCteDetExtra);
                                                    }
                                                }

                                                if (Convert.ToInt32(fila["Meses_cobro"]) > 1)
                                                    fechaDesde = oCtaCteDet.Fecha_Hasta.AddDays(1);

                                                if (Convert.ToInt32(fila["Id_usuarios_servicios_sub_tipos"]) == Convert.ToInt32(Servicios_Sub.SERVICIO_SUB_TIPOS.DERECHO_DE_CONEXION))
                                                    agregoDerecho = true;
                                            }
                                        }
                                        else //SINO, COBRO TODO
                                        {

                                            Usuarios_CtaCte_Det oCtaCteDet = new Usuarios_CtaCte_Det();
                                            oCtaCteDet.Id_Usuarios_CtaCte = oCtaCte.Id;
                                            oCtaCteDet.Id_Usuarios_Locaciones = oUsuLocSer.Id;
                                            oCtaCteDet.Id_Zonas = this.Id_Tipo_Facturacion;
                                            oCtaCteDet.Id_Servicios = Convert.ToInt32(fila["Id_Servicios"]);
                                            oCtaCteDet.Id_Tipo = Convert.ToInt32(dr2["id_tipo"]);
                                            oCtaCteDet.Tipo = dr2["tipo"].ToString();
                                            oCtaCteDet.Importe_Punitorio = 0;
                                            oCtaCteDet.Importe_Original = Convert.ToDecimal(fila["importe_original"]);
                                            oCtaCteDet.Importe_Bonificacion = oCtaCteDet.Importe_Original - Convert.ToDecimal(fila["importe_con_descuento"]);
                                            oCtaCteDet.Importe_Saldo = oCtaCteDet.Importe_Original - oCtaCteDet.Importe_Bonificacion;
                                            oCtaCteDet.Id_Usuarios_Servicios = Convert.ToInt32(fila["Id_Usuarios_Servicios"]);
                                            oCtaCteDet.Id_Velocidades_Tip = Convert.ToInt32(fila["Id_Servicios_Velocidades_Tipos"]);
                                            oCtaCteDet.Id_Velocidades = Convert.ToInt32(fila["Id_Servicios_Velocidades"]);
                                            oCtaCteDet.Requiere_IP = Convert.ToInt32(fila["Requiere_IP"]);
                                            oCtaCteDet.Cantidad_Periodos = Cantidad_Periodo;
                                            if (Convert.ToInt32(dr2["id_Servicios_Modalidad"]) == Convert.ToInt32(Servicios._Modalidad.PERIODO_CERRADO_POR_MES))
                                            {
                                                oCtaCteDet.Fecha_Desde = Convert.ToDateTime(dr2["Fecha_InicioServ"]);
                                                oCtaCteDet.Fecha_Hasta = fechaFinal;
                                            }
                                            else
                                            {
                                                if (Convert.ToInt32(dr2["id_Servicios_Modalidad"]) == Convert.ToInt32(Servicios._Modalidad.PERIODO_CERRADO_POR_DIA))
                                                {
                                                    oCtaCteDet.Fecha_Desde = Convert.ToDateTime(dr2["Fecha_InicioServ"]);
                                                    oCtaCteDet.Fecha_Hasta = fechaFinal;
                                                }
                                                else
                                                {
                                                    oCtaCteDet.Fecha_Desde = Convert.ToDateTime(fila["fecha_desde"]);
                                                    oCtaCteDet.Fecha_Hasta = Convert.ToDateTime(fila["fecha_hasta"]);
                                                }


                                            }

                                            oCtaCteDet.Periodo_Ano = Convert.ToDateTime(fila["fecha_desde"]).Year;
                                            oCtaCteDet.Periodo_Mes = Convert.ToDateTime(fila["fecha_desde"]).Month;
                                            oCtaCteDet.Porcentaje_Bonificacion = 0;
                                            oCtaCteDet.Nombre_Bonificacion = String.Empty;
                                            oCtaCteDet.Id_bonificacion_Aplicada = 0;

                                            if (oCtaCteDet.Tipo == "S")
                                                oCtaCteDet.Id_Usuarios_Servicios_sub = oUsuSer.Get_Id_Usuarios_Servicios_Sub(oCtaCteDet.Id_Usuarios_Servicios, oCtaCteDet.Id_Tipo);
                                            oCtaCteDet.Id_Tipo_Registro_Cta_Cte_Det = 0;
                                            oCtaCteDet.Id = oCtaCteDet.Guardar(oCtaCteDet);

                                            if (oCtaCteDet.Id > 0)
                                            {
                                                if (Convert.ToInt32(fila["id_bonificacion"]) > 0)
                                                {
                                                    oUsuariosCtaCteDetExtra.Id_Extra = Convert.ToInt32(fila["id_bonificacion"]);
                                                    oUsuariosCtaCteDetExtra.Id_Tipo_Extra = Convert.ToInt32(Usuarios_Ctacte_Det_Extra.TiposExtras.BONIFICACION);
                                                    oUsuariosCtaCteDetExtra.Id_Usuarios_CtaCte_Det = oCtaCteDet.Id;
                                                    oUsuariosCtaCteDetExtra.Porcentaje = Convert.ToDecimal(fila["porcentaje_parcial"]);
                                                    oUsuariosCtaCteDetExtra.Importe_original = Convert.ToDecimal(fila["importe_original"]);
                                                    if (Convert.ToInt32(fila["id_bonificacion_contratacion"]) > 0)
                                                        oUsuariosCtaCteDetExtra.Importe_Nuevo = Convert.ToDecimal(fila["importe_con_descuento_parcial"]);
                                                    else
                                                        oUsuariosCtaCteDetExtra.Importe_Nuevo = Convert.ToDecimal(fila["importe_con_descuento"]);
                                                    oUsuariosCtaCteDetExtra.Detalle = fila["nombre_bonificacion"].ToString();
                                                    oUsuariosCtaCteDetExtra.Extra = String.Empty;
                                                    oUsuariosCtaCteDetExtra.Guardar(oUsuariosCtaCteDetExtra);
                                                }

                                                if (Convert.ToInt32(fila["id_bonificacion_contratacion"]) > 0)
                                                {
                                                    oUsuariosCtaCteDetExtra.Id_Extra = Convert.ToInt32(fila["id_bonificacion_contratacion"]);
                                                    oUsuariosCtaCteDetExtra.Id_Tipo_Extra = Convert.ToInt32(Usuarios_Ctacte_Det_Extra.TiposExtras.NOVEDAD);
                                                    oUsuariosCtaCteDetExtra.Id_Usuarios_CtaCte_Det = oCtaCteDet.Id;
                                                    oUsuariosCtaCteDetExtra.Porcentaje = Convert.ToDecimal(fila["porcentaje_contratacion"]);
                                                    oUsuariosCtaCteDetExtra.Importe_original = Convert.ToDecimal(fila["importe_con_descuento_parcial"]);
                                                    oUsuariosCtaCteDetExtra.Importe_Nuevo = Convert.ToDecimal(fila["importe_con_descuento"]);
                                                    oUsuariosCtaCteDetExtra.Detalle = fila["detalle_contratacion"].ToString();
                                                    oUsuariosCtaCteDetExtra.Extra = String.Empty;
                                                    oUsuariosCtaCteDetExtra.Guardar(oUsuariosCtaCteDetExtra);
                                                }
                                            }

                                            if (Convert.ToInt32(fila["Meses_cobro"]) > 1)
                                                fechaDesde = oCtaCteDet.Fecha_Hasta.AddDays(1);

                                            if (Convert.ToInt32(fila["Id_usuarios_servicios_sub_tipos"]) == Convert.ToInt32(Servicios_Sub.SERVICIO_SUB_TIPOS.DERECHO_DE_CONEXION))
                                                agregoDerecho = true;
                                        }
                                    }
                                }

                                Cantidad_Periodo = 0;
                            }
                        }
                    }
                }

                Usuarios.Current_IdUsuario = oUsuario.Id;
                Usuarios.Current_IdUsuarioLocacion = oUsuLocSer.Id;

                //------------- Código para generar novedades automáticas-----------------------------------------------

                if (dtDatosNovedades.Rows.Count > 0)
                {
                    foreach (DataRow datosNovedadNueva in dtDatosNovedades.Rows)
                    {
                        oUsuariosServiciosNovedades.Detalle = datosNovedadNueva["facturable"].ToString();
                        oUsuariosServiciosNovedades.Facturable = Convert.ToInt32(datosNovedadNueva["facturable"]);
                        oUsuariosServiciosNovedades.Fecha_Desde = Convert.ToDateTime(datosNovedadNueva["fecha_desde"]);
                        oUsuariosServiciosNovedades.Fecha_Hasta = Convert.ToDateTime(datosNovedadNueva["fecha_hasta"]);
                        oUsuariosServiciosNovedades.Finaliza = Convert.ToInt32(datosNovedadNueva["finaliza"]);
                        oUsuariosServiciosNovedades.Id_Servicios = Convert.ToInt32(datosNovedadNueva["id_servicios"]);
                        oUsuariosServiciosNovedades.Id_Servicios_Sub = Convert.ToInt32(datosNovedadNueva["id_servicios_sub"]);
                        try
                        {
                            oUsuariosServiciosNovedades.Id_Servicios_velocidades = Convert.ToInt32(datosNovedadNueva["id_servicios_velocidades"]);
                            oUsuariosServiciosNovedades.Id_Servicios_velocidades_tip = Convert.ToInt32(datosNovedadNueva["id_servicios_velocidades_tip"]);
                        }
                        catch
                        {
                            oUsuariosServiciosNovedades.Id_Servicios_velocidades = 0;
                            oUsuariosServiciosNovedades.Id_Servicios_velocidades_tip = 0;
                        }
                        oUsuariosServiciosNovedades.Id_tipo = Convert.ToInt32(datosNovedadNueva["id_tipo"]);
                        oUsuariosServiciosNovedades.Id_Usuarios = Convert.ToInt32(datosNovedadNueva["id_usuarios"]);
                        oUsuariosServiciosNovedades.Id_Usuarios_Locaciones = Convert.ToInt32(datosNovedadNueva["id_usuarios_locaciones"]);
                        oUsuariosServiciosNovedades.Id_Usuarios_Servicios = Convert.ToInt32(datosNovedadNueva["id_usuarios_servicios"]);
                        if (Convert.ToInt32(datosNovedadNueva["nivel_aplicacion"]) == Convert.ToInt32(Bonificaciones.NIVEL.SUBSERVICIO))
                        {
                            oUsuariosServiciosNovedades.Id_Servicios_Sub = Convert.ToInt32(datosNovedadNueva["id_servicios_sub"]);
                            oUsuariosServiciosNovedades.Id_Usuarios_Servicios_Sub = Convert.ToInt32(datosNovedadNueva["id_usuarios_servicios_sub"]);
                        }
                        else
                        {
                            oUsuariosServiciosNovedades.Id_Servicios_Sub = 0;
                            oUsuariosServiciosNovedades.Id_Usuarios_Servicios_Sub = 0;
                        }
                        oUsuariosServiciosNovedades.Imprimir = Convert.ToInt32(datosNovedadNueva["imprime"]);
                        oUsuariosServiciosNovedades.Monto = Convert.ToDecimal(datosNovedadNueva["monto"]);
                        oUsuariosServiciosNovedades.Porcentaje = Convert.ToDecimal(datosNovedadNueva["porcentaje"]);
                        oUsuariosServiciosNovedades.Tipo = datosNovedadNueva["tipo"].ToString();
                        oUsuariosServiciosNovedades.id_bonificacion_asociada = Convert.ToInt32(datosNovedadNueva["id_bonificacion"]);
                        oUsuariosServiciosNovedades.Id_Origen = Convert.ToInt32(Usuarios_Servicios_Novedades.Origen.SISTEMA);
                        oUsuariosServiciosNovedades.Guardar(oUsuariosServiciosNovedades);
                    }
                }
                //------------------------------------------------------------------------------------------------------
                if (Config_Agenda != Convert.ToInt32(Agenda_Encabezado.Uso_agenda.TRABAJA_CON_AGENDA))
                {
                    GPS oGps = new GPS();
                    //oGps.EnviarParte(oParte.Id);
                    foreach (DataRow item in dtPartesHechos.Rows)
                    {
                        var id = Convert.ToInt32(item["id"]);
                        oGps.EnviarParte(id);
                    }
                }

                if (generarDeudas)
                {
                    if (MessageBox.Show("¿Desea Generar un Plan de Pago?", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        DataTable dtRegistrosSeleccionados = new DataTable();
                        dtRegistrosSeleccionados = oCtaCte.GenerarDtDatosCtaCteAjustes();
                        dtRegistrosSeleccionados.Rows.Add(Convert.ToInt32(Usuarios_CtaCte.TIPO_REGISTRO_CTACTE.COMPROBANTE), oCtaCte.Id, "0", "0");

                        //datos necesarios para cargar la tabla dtdatoscomprobantes, que va como parámetro para el form de planes de pago
                        DataTable dtDatosComprobantes = new DataTable();
                        DataTable dtLocaciones = new DataTable();
                        dtLocaciones = oUsuLocSer.ListarLocacionesServicio(Usuarios.CurrentUsuario.Id);
                        dtDatosComprobantes = oCtaCte.GetDtModelo();
                        dtDatosComprobantes = oCtaCte.LlenarDtModelo(dtLocaciones, "C", oComprobante.Id);
                        //------------------

                        Cuenta_Corriente.frmCtaCtePlanesDePago frmPlanesPago = new Cuenta_Corriente.frmCtaCtePlanesDePago(Usuarios.CurrentUsuario.Id, Usuarios.CurrentUsuario.Id_Usuarios_Locacion, dtRegistrosSeleccionados, dtDatosComprobantes);
                        frmPopUp frmpopup = new frmPopUp();
                        frmpopup.Maximizar = false;
                        frmpopup.Formulario = frmPlanesPago;
                        frmpopup.ShowDialog();
                    }
                }



                if (Config_Agenda == Convert.ToInt32(Agenda_Encabezado.Uso_agenda.TRABAJA_CON_AGENDA))
                {
                    MessageBox.Show("Conexion generada correctamente.", "Mensaje del Sistema", MessageBoxButtons.OK);

                    frmAgenda frmAgen = frmAgenda.GetInstancia();
                    frmAgen.vieneDeParte = true;
                    foreach (DataRow item in dtPartesHechos.Rows)
                    {
                        var id = Convert.ToInt32(item["id"]);
                        Lista_Id_Partes.Add(id);
                    }
                    frmAgen.Id_recibido(Lista_Id_Partes);
                    frmAgenda.pendienteDeAbrir = true;
                    frmAgen.Mostrar();

                }
                else
                {
                    if (MessageBox.Show("¿Desea Imprimir los Partes de Trabajo?", "Mensaje del Sistema",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        foreach (DataRow item in dtPartesHechos.Rows)
                        {
                            var id = Convert.ToInt32(item["id"]);

                            Impresion oImpresion = new Impresion();

                            oImpresion.ImprimirParte(id);

                        }
                    }

                }
            }
        }

        private void CargarServicios()
        {
            if (Convert.ToInt32(cboTipoFacturacion.SelectedValue) > 0)
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
                dgvContrato.Columns["Importe"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvContrato.Columns["Importe"].DefaultCellStyle.Format = "C2";
                dgvContrato.Columns["Bonificacion"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvContrato.Columns["Bonificacion"].DefaultCellStyle.Format = "N2";
                dgvContrato.Columns["Bonificacion"].HeaderText = "Bonif. (%)";
                dgvContrato.Columns["Bonificacion"].Width = 50;
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
        }

        private void Siguiente()
        {
            int position = tabWizard.SelectedIndex;


            switch (position)
            {
                case 0:
                    if (dtServContratados.Rows.Count == 0)
                        return;
                    if (vieneUnidadesFuncionales > 0)
                    {
                        txtApellido.Text = this.usuarioApellido;
                        txtNombre.Text = this.usuarioNombre;

                    }
                    cboTipoFacturacion.Enabled = false;

                    if (tabWizard.TabCount == 1)
                    {
                        if(oUsuario.Id > 0)
                        {
                           bool tieneDebitos = new Presentacion_Debitos().ListarPlasticosAsociadosAlUsuario(Convert.ToInt32(oUsuario.Id)).AsEnumerable().Any();
                            if (tieneDebitos)
                            {
                                new frmAdvertencia("Advertencia", "¡El servicio que se esta dando de alta no se asociara a el debito automatico del usaurio!").ShowDialog();
                            }
                        }

                        tabWizard.TabPages.Add(tabUsuario);

                        cboLocalidades.DataSource = dtLocalidadesLocacion;
                        cboLocalidades.DisplayMember = TipoFacturacion == Tipo_Facturacion.Id_Tipo_Facturacion.POR_ZONAS ? "Localidad" : "Nombre";
                        cboLocalidades.ValueMember = TipoFacturacion == Tipo_Facturacion.Id_Tipo_Facturacion.POR_ZONAS ? "Id_Localidad" : "Id";

                        if (this.TipoFacturacion == Tipo_Facturacion.Id_Tipo_Facturacion.POR_ZONAS)
                        {

                            cboLocalidades.SelectedValue = Convert.ToInt32(cboTipoFacturacion.SelectedValue);
                            cboLocalidades.Enabled = false;
                        }

                        

                        if (ImporteTotal == 0)
                        {
                            MessageBox.Show("El Parte de Conexion se Generara con un Comprobante Sin Valor", "Mensaje del Sistema",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }

                    if (this.TipoFacturacion == Tipo_Facturacion.Id_Tipo_Facturacion.POR_ZONAS)
                        cboLocalidades.SelectedValue = cboTipoFacturacion.SelectedValue;

                    CargarServicios();
                    pnlPaso1.BackgroundImage = Properties.Resources.pasoListo;
                    pnlPaso2.BackgroundImage = Properties.Resources.pasoActual;
                    btnAnterior.Visible = true;

                    if (TipoOperacion == 2)
                    {
                        btnConfirmar.Visible = true;
                        btnSiguiente.Visible = false;
                        btnConfirmar.Left = btnSiguiente.Left;
                    }

                    tabWizard.SelectedTab = tabUsuario;
                    break;
                case 1:
                    if (this.ValidarUsuario() == false)
                        return;
                    if (tabWizard.TabCount == 2)
                        tabWizard.TabPages.Add(tabLocacion);
                    tabWizard.SelectedTab = tabLocacion;

                    if (TipoFacturacion == Tipo_Facturacion.Id_Tipo_Facturacion.POR_ZONAS)
                    {
                        cboLocalidades.DataSource = cboTipoFacturacion.DataSource;
                        cboLocalidades.DisplayMember = "Localidad";
                        cboLocalidades.ValueMember = "id_localidad";

                        cboLocalidades.SelectedValue = cboTipoFacturacion.SelectedValue;

                    }
                    else
                    {
                        cboLocalidades.DataSource = dtLocalidadesLocacion;
                        if (vieneUnidadesFuncionales > 0)
                            cboLocalidades.SelectedValue = idLocalidad;

                        if (this.MismaLocacion)
                            cboLocalidades.SelectedValue = idLocalidad;

                    }

                    pnlPaso2.BackgroundImage = Properties.Resources.pasoListo;
                    pnlPaso3.BackgroundImage = Properties.Resources.pasoActual;

                    if (oUsuariosLocaconesUF.Id > 0)
                    {
                        oUsuarioLocacion = oUsuarioLocacion.GetLocacion(idLocacionEdificio);
                        cboLocalidades.SelectedValue = oUsuarioLocacion.Id_Localidades;
                        txtCalleServicio.Text = oUsuarioLocacion.Calle;
                        txtCalleServicio.Tag = oUsuarioLocacion.Id_Calle.ToString();
                        txtAlturaServicio.Text = oUsuarioLocacion.Altura.ToString();
                        txtPisoServicio.Text = oUsuariosLocaconesUF.Piso.ToString();
                        txtDeptoServicio.Text = oUsuariosLocaconesUF.Depto.ToString();
                        txtCPServicio.Text = oUsuarioLocacion.Codigo_Postal.ToString();
                        txtEntreCalleServicio_1.Text = oUsuarioLocacion.Entre_Calle_1.ToString();
                        txtEntreCalleServicio_2.Text = oUsuarioLocacion.Entre_Calle_2.ToString();
                        txtManzServicio.Text = oUsuarioLocacion.Manzana.ToString();
                        txtParcelaServicio.Text = oUsuarioLocacion.Parcela.ToString();
                        txtObservacionLocacion.Text = oUsuarioLocacion.Observacion;
                        lblAltura.Visible = false;
                        cboLocalidades.Enabled = false;
                        txtCalleServicio.Enabled = false;
                        txtEntreCalleServicio_1.Enabled = false;
                        txtEntreCalleServicio_2.Enabled = false;
                        txtAlturaServicio.Enabled = false;
                        txtPisoServicio.Enabled = false;
                        txtDeptoServicio.Enabled = false;
                        txtManzServicio.Enabled = false;
                        txtParcelaServicio.Enabled = false;
                        txtCPServicio.Enabled = false;
                    }
                    break;
                case 2:
                    if (ValidarLocacion() == false)
                        return;

                    if (tabWizard.TabCount == 3)
                        tabWizard.TabPages.Add(tabParteConexion);

                    if (tabWizard.TabCount == 2)
                        tabWizard.TabPages.Add(tabParteConexion);

                    txtParte_Apellido.Text = txtApellido.Text;
                    txtParte_Nombre.Text = txtNombre.Text;
                    txtParte_Locacion.Text = String.Format("{0} {1} {2} {3}, {4}", txtCalleServicio.Text, txtAlturaServicio.Text, txtPisoServicio.Text, txtDeptoServicio.Text, cboLocalidades.Text);

                    DataTable dtServiciosFinal = new DataTable();
                    dtServiciosFinal.Columns.Add("Servicio", typeof(String));
                    dtServiciosFinal.Columns.Add("Importe", typeof(Decimal));
                    dtServiciosFinal.Columns.Add("Categoria", typeof(String));
                    dtServiciosFinal.Columns.Add("FechaConexion", typeof(DateTime));

                    int idservicio = 0;

                    foreach (DataRow dr in dtServAContratar.Rows)
                    {
                        if (idservicio != Convert.ToInt32(dr["Id_Servicios"]))
                        {
                            idservicio = Convert.ToInt32(dr["Id_Servicios"]);

                            var sum = dtServAContratar.Compute("sum(Total)", String.Format("Id_Servicios = {0} and Seleccion = True", idservicio));

                            if (dr["Tipo"].ToString() == "S")
                                dtServiciosFinal.Rows.Add(dr["Servicio"].ToString(), Convert.ToDecimal(sum), dr["Categoria"].ToString(), Convert.ToDateTime(dr["Fecha_Conexion"]));
                        }
                    }


                    DataView dtv = dtServAContratar.DefaultView;
                    dtv.RowFilter = "Seleccion = true";

                    dgvServiciosContratados.DataSource = dtv.ToTable();
                    for (int i = 0; i < dgvServiciosContratados.ColumnCount; i++)
                        dgvServiciosContratados.Columns[i].Visible = false;

                    dgvServiciosContratados.Columns["Servicio"].Visible = true;
                    dgvServiciosContratados.Columns["Item"].Visible = true;
                    dgvServiciosContratados.Columns["Importe"].Visible = true;
                    dgvServiciosContratados.Columns["Importe"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dgvServiciosContratados.Columns["Importe"].DefaultCellStyle.Format = "C2";
                    dgvServiciosContratados.Columns["Bonificacion"].Visible = true;
                    dgvServiciosContratados.Columns["Bonificacion"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dgvServiciosContratados.Columns["Bonificacion"].DefaultCellStyle.Format = "N2";
                    dgvServiciosContratados.Columns["Bonificacion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;

                    dgvServiciosContratados.Columns["Total"].Visible = true;
                    dgvServiciosContratados.Columns["Total"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dgvServiciosContratados.Columns["Total"].DefaultCellStyle.Format = "C2";
                    dgvServiciosContratados.Columns["Fecha_Conexion"].Visible = true;
                    dgvServiciosContratados.Columns["Fecha_Conexion"].HeaderText = "Fecha de Conexion";
                    dgvServiciosContratados.Columns["Fecha_Conexion"].DefaultCellStyle.Format = "dd/MM/yyyy";
                    dgvServiciosContratados.Columns["Bonificacion"].HeaderText = "Bonificación (%)";
                    dgvServiciosContratados.Columns["Bonificacion"].Width = 140;

                    foreach (DataGridViewRow dr in dgvServiciosContratados.Rows)
                    {
                        int value = Convert.ToInt32(dr.Cells["Id_Tipo"].Value);

                        if (value == 0)
                        {
                            dr.DefaultCellStyle.BackColor = Color.Gainsboro;
                            dr.DefaultCellStyle.Font = new Font("Segoe UI", 8, FontStyle.Bold);
                        }
                    }

                    tabWizard.SelectedTab = tabParteConexion;
                    pnlPaso3.BackgroundImage = Properties.Resources.pasoListo;
                    pnlPaso4.BackgroundImage = Properties.Resources.pasoActual;
                    btnConfirmar.Visible = true;
                    btnSiguiente.Visible = false;
                    btnConfirmar.Left = btnSiguiente.Left;


                    break;
            }
        }

        private void Anterior()
        {
            int position = tabWizard.SelectedIndex;

            switch (position)
            {
                case 1:
                    tabWizard.SelectedTab = tabServicios;
                    pnlPaso1.BackgroundImage = Properties.Resources.pasoActual;
                    pnlPaso2.BackgroundImage = Properties.Resources.pasoSiguiente;
                    pnlPaso3.BackgroundImage = Properties.Resources.pasoSiguiente;
                    pnlPaso4.BackgroundImage = Properties.Resources.pasoSiguiente;

                    //cboTipoFacturacion.Enabled = true;
                    btnAnterior.Visible = false;
                    btnSiguiente.Visible = true;
                    btnConfirmar.Visible = false;
                    break;
                case 2:
                    tabWizard.SelectedTab = tabUsuario;
                    pnlPaso1.BackgroundImage = Properties.Resources.pasoListo;
                    pnlPaso2.BackgroundImage = Properties.Resources.pasoActual;
                    pnlPaso3.BackgroundImage = Properties.Resources.pasoSiguiente;
                    pnlPaso4.BackgroundImage = Properties.Resources.pasoSiguiente;
                    btnAnterior.Visible = true;
                    btnSiguiente.Visible = true;
                    btnConfirmar.Visible = false;
                    break;
                case 3:
                    tabWizard.SelectedTab = tabLocacion;
                    pnlPaso1.BackgroundImage = Properties.Resources.pasoListo;
                    pnlPaso2.BackgroundImage = Properties.Resources.pasoListo;
                    pnlPaso3.BackgroundImage = Properties.Resources.pasoActual;
                    pnlPaso4.BackgroundImage = Properties.Resources.pasoSiguiente;
                    btnAnterior.Visible = true;
                    btnSiguiente.Visible = true;
                    btnConfirmar.Visible = false;
                    break;
                default:
                    break;
            }
        }

        private void CargarUsuario()
        {
            if (this.MismaLocacion)
            {
                chkGenerarDeudas.Visible = true;
                dtServiciosActivos = oUsuSer.ListarServiciosYSubServiciosActivos(Usuarios.CurrentUsuario.Id);
            }
            else
            {
                chkGenerarDeudas.Visible = false;
                if (this.idUsuarioEdificio > 0)
                {
                    dtServiciosActivos = oUsuSer.ListarServiciosYSubServiciosActivos(idUsuarioEdificio);
                    if (dtServiciosActivos.Rows.Count > 0)
                    {
                        foreach (DataRow item in dtServiciosActivos.Rows)
                        {
                            int idTipo = Convert.ToInt32(item["id_tipo"]);
                            if (idTipo == 1)
                            {
                                item["id_tipo"] = 3;
                                item["servicio"] = item["servicio"] + " - HEREDADO";
                            }
                            else
                            {
                                if (idTipo == 2)
                                    item["id_tipo"] = 4;
                            }
                        }
                    }
                    dgvCtaServicios.DataSource = dtServiciosActivos;
                    dtUsuariosEquipos = oEquipos.ListarPorUsuario(idUsuarioEdificio);

                    FormatearGrillaNueva();
                    return;
                }
                else
                    dtServiciosActivos = oUsuSer.ListarServiciosYSubServiciosActivos(0);
            }


            if (dtServiciosActivos.Rows.Count > 0)
            {

                dgvCtaServicios.DataSource = dtServiciosActivos;
                FormatearGrillaNueva();

            }

            txtNombre.Text = Usuarios.CurrentUsuario.Nombre.ToString();
            txtApellido.Text = Usuarios.CurrentUsuario.Apellido.ToString();
            txtNumero.Text = Usuarios.CurrentUsuario.Numero_Documento.ToString();
            cboCondIVA.SelectedValue = Usuarios.CurrentUsuario.Id_Comprobantes_Iva;
            txtCUIT.Text = Usuarios.CurrentUsuario.CUIT.ToString();

            if (Usuarios.CurrentUsuario.Nacimiento.Year > 1)
                dtpNacimiento.Value = Convert.ToDateTime(Usuarios.CurrentUsuario.Nacimiento);

            txtCorreo.Text = Usuarios.CurrentUsuario.Correo_Electronico.ToString();

            oUsuario.Id = Convert.ToInt32(Usuarios.CurrentUsuario.Id);

            dtUsuariosEquipos = oEquipos.ListarPorUsuario(oUsuario.Id);

            if (this.MismaLocacion)
            {
                Usuarios_Locaciones oLoc = new Usuarios_Locaciones();

                oLoc = oLoc.GetLocacion(Convert.ToInt32(Usuarios.CurrentUsuario.Id_Usuarios_Locacion));
                idLocalidad = oLoc.Id_Localidades;

                if (TipoFacturacion == Tipo_Facturacion.Id_Tipo_Facturacion.POR_ZONAS)
                {
                    cboTipoFacturacion.SelectedValue = oLoc.Id_Localidades;
                }
                else
                    cboLocalidades.SelectedValue = oLoc.Id_Localidades;


                cboLocalidades.Enabled = false;
                cboLocalidades.SelectedValue = oLoc.Id_Localidades;
                txtCalleServicio.Text = oLoc.Calle;
                txtCalleServicio.Tag = oLoc.Id_Calle.ToString();
                txtEntreCalleServicio_1.Text = oLoc.Entre_Calle_1;
                txtEntreCalleServicio_1.Tag = oLoc.Id_Calle_Entre_1.ToString();
                txtEntreCalleServicio_2.Text = oLoc.Entre_Calle_2;
                txtEntreCalleServicio_2.Tag = oLoc.Id_Calle_Entre_2.ToString();
                txtAlturaServicio.Text = oLoc.Altura.ToString();
                txtPisoServicio.Text = oLoc.Piso;
                txtDeptoServicio.Text = oLoc.Depto;
                txtCPServicio.Text = oLoc.Codigo_Postal;
                txtManzServicio.Text = oLoc.Manzana;
                txtParcelaServicio.Text = oLoc.Parcela;
                txtPisoServicio.Text = oLoc.Parcela;
                txtPrefijo_1.Text = oLoc.Prefijo_1.ToString();
                txtTelefono_1.Text = oLoc.Telefono_1.ToString();
                txtPrefijo_2.Text = oLoc.Prefijo_2.ToString();
                txtTelefono_2.Text = oLoc.Telefono_2.ToString();
                txtObsUsuario.Text = oLoc.Observacion;

                oUsuLocSer.Id = oLoc.Id;

                txtCalleServicio.Enabled = false;
                txtEntreCalleServicio_1.Enabled = false;
                txtEntreCalleServicio_2.Enabled = false;
                txtAlturaServicio.Enabled = false;
                txtPisoServicio.Enabled = false;
                txtDeptoServicio.Enabled = false;
                txtCPServicio.Enabled = false;
                txtManzServicio.Enabled = false;
                txtParcelaServicio.Enabled = false;
                txtPisoServicio.Enabled = false;
                txtPrefijo_1.Enabled = false;
                txtTelefono_1.Enabled = false;
                txtPrefijo_2.Enabled = false;
                txtTelefono_2.Enabled = false;
                txtObsUsuario.Enabled = false;
                cboTipoFacturacion.Enabled = TipoFacturacion == Tipo_Facturacion.Id_Tipo_Facturacion.POR_ZONAS ? false : true;
            }
        }

        private void FormatearGrillaNueva()
        {
            foreach (DataGridViewColumn item in dgvCtaServicios.Columns)
                item.Visible = false;
            dgvCtaServicios.Columns["servicio"].Visible = true;
            dgvCtaServicios.Columns["servicio"].DisplayIndex = 0;
            dgvCtaServicios.Columns["servicio"].HeaderText = "Servicio";
            dgvCtaServicios.Columns["servicio"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            dgvCtaServicios.Columns["estado"].Visible = true;
            dgvCtaServicios.Columns["estado"].DisplayIndex = 3;
            dgvCtaServicios.Columns["estado"].HeaderText = "Estado";
            dgvCtaServicios.Columns["estado"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvCtaServicios.Columns["fecha_factura"].Visible = true;
            dgvCtaServicios.Columns["fecha_factura"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvCtaServicios.Columns["fecha_factura"].DefaultCellStyle.Format = "d MMM yyyy";
            dgvCtaServicios.Columns["fecha_factura"].HeaderText = "Fin del servicio";

            foreach (DataGridViewRow item in dgvCtaServicios.Rows)
            {
                int idTipo = Convert.ToInt32(item.Cells["id_tipo"].Value);
                if (idTipo != 1 && idTipo != 3)
                    item.Visible = false;
                if (idTipo == 3 || idTipo == 4)
                {
                    item.DefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Italic);
                }
            }


        }

        private bool Validar(int column, int row, DataGridView dataGrid)
        {
            DataGridViewCell celda_1 = dataGrid[column, row];
            DataGridViewCell celda_2 = dataGrid[column, row - 1];

            if (celda_1.Value == null || celda_2.Value == null)
                return false;

            return celda_1.Value.ToString() == celda_2.Value.ToString();
        }

        private void Proratear()
        {
            decimal tarifa = 0;

            DateTime fechaDesde = Convert.ToDateTime(dtServAContratar.Rows[0]["Fecha_InicioServ"]);

            foreach (DataRow item in dtServAContratar.Rows)
            {

                var cell = item["Fecha_InicioServ"];
                string tipo = item["Tipo"].ToString();
                var servicio = item["Servicio"];
                decimal tarifaActual = Convert.ToDecimal(item["Total"]);
                if ((tipo == "S") && (tarifaActual != 0) && Convert.ToInt32(item["id_servicios_tipo_sub"].ToString()) != Convert.ToInt32(Servicios_Sub.SERVICIO_SUB_TIPOS.DERECHO_DE_CONEXION))
                {


                    tarifa = Convert.ToDecimal(item["Total"]);
                    if (fechaDesde.Day > 1)
                    {

                        var diaHoy = fechaDesde.Day;
                        var mesHoy = fechaDesde.Month;
                        var yearHoy = fechaDesde.Year;
                        var diasFaltantes = 0;
                        decimal tarifaNueva = 0;
                        var cantDiasMes = 0;
                        cantDiasMes = DateTime.DaysInMonth(yearHoy, mesHoy);
                        diasFaltantes = cantDiasMes - diaHoy;
                        tarifaNueva = (tarifa / cantDiasMes);
                        tarifaNueva = tarifaNueva * diasFaltantes;

                        item["importe"] = ((Convert.ToDecimal(item["importe"]) / cantDiasMes) * diasFaltantes);

                        item["Total"] = tarifaNueva;
                    }
                }

                if (cell.ToString().Length > 0)
                    fechaDesde = Convert.ToDateTime(item["Fecha_InicioServ"]);

            }

            dtServAContratar.AcceptChanges();
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

        private void BuscarCalle()
        {
            using (frmPopUp frmModal = new frmPopUp())
            {
                frmBusquedaCalles frm = new frmBusquedaCalles();
                frm.Id_Localidad = Convert.ToInt32(cboLocalidades.SelectedValue);
                List<Int32> listLocalidades = new List<Int32>
                    {
                        Convert.ToInt32(cboLocalidades.SelectedValue)
                    };
                frm.lista_id_localidades = listLocalidades;

                frmModal.Formulario = frm;

                if (frmModal.ShowDialog() == DialogResult.OK)
                {

                    txtCalleServicio.Text = frm.Calle;
                    txtCalleServicio.Tag = frm.Id_Calle.ToString();
                    txtEntreCalleServicio_1.Focus();

                    lblAltura.Text = String.Format("Altura Desde {0} Hasta {1}", frm.oCalles.Altura_Desde, frm.oCalles.Altura_Hasta);

                    this.Altura_Desde = frm.oCalles.Altura_Desde;
                    this.Altura_Hasta = frm.oCalles.Altura_Hasta;

                    oUsuLocSer.Id = 0;
                }
                else
                    txtCalleServicio.Text = "";
            }
        }

        #endregion

        private void frmParteConexion_Load(object sender, EventArgs e)
        {
            TipoFacturacion = oConfig.GetValor_N("Id_Tipo_Facturacion") == 1 ? Tipo_Facturacion.Id_Tipo_Facturacion.POR_ZONAS : Tipo_Facturacion.Id_Tipo_Facturacion.POR_CATEGORIAS;

            tabWizard.TabPages.Remove(tabUsuario);
            tabWizard.TabPages.Remove(tabLocacion);

            tabWizard.TabPages.Remove(tabParteConexion);

            lblTitulo.Text = this.TipoOperacion == 1 ? "Conexion de Servicios" : "Factibilidad de Servicios";

            ComenzarCarga();
        }

        private void frmParteConexion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                if (MessageBox.Show("¿Desea salir sin Completar la Operacion?", "Mensaje del Sistema",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    this.Close();
            }
            if (e.KeyCode == Keys.F2)
                Siguiente();

        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            Siguiente();
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            Anterior();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            IngresarParte();


            if (Config_Agenda == Convert.ToInt32(Agenda_Encabezado.Uso_agenda.NO_TRABAJA_CON_AGENDA))
                oUsuario.LlenarObjeto(oUsuario.Id);

            this.Close();
        }

        private void dgvContrato_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            string check = "False";
            if (e.RowIndex > -1)
            {
                if (dgvContrato.Rows[e.RowIndex].Cells["Tipo"].Value.ToString() == "P" && Convert.ToBoolean(dgvContrato.Rows[e.RowIndex].Cells["Seleccion"].Value) == false)
                {
                    MessageBox.Show("El Servicio debe contar con una Solicitud de Conexion", "Mensaje del Sistema");

                    dgvContrato.Rows[e.RowIndex].Cells["Seleccion"].Value = true;
                }

                if (dgvContrato.Rows[e.RowIndex].Cells["Id_Tipo"].Value.ToString() == "0")
                {
                    if (dgvContrato.Rows[e.RowIndex].Cells["Seleccion"].Value.ToString() == "False")
                        check = "False";
                    else
                        check = "True";

                    foreach (DataRow fila in dtServAContratar.Select("id_contador_servicios='" + dgvContrato.Rows[e.RowIndex].Cells["id_contador_servicios"].Value.ToString() + "'"))
                    {
                        if (check == "True")
                            fila["seleccion"] = check;
                        else
                        {
                            dtServAContratar.Rows.Remove(fila);
                        }
                    }

                }
            }
            dtServAContratar.AcceptChanges();
            //if (dtServAContratar.Rows.Count > 0)
            //     CalcularBonificaciones();
            ContadorServicios();
            CalcularTotales();
        }

        private void dgvContrato_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvContrato.Columns[e.ColumnIndex].Name.Equals("Seleccion"))
            {
                bool valorSeleccion = false;
                valorSeleccion = Convert.ToBoolean(dgvContrato.SelectedRows[0].Cells["Seleccion"].Value);
                if (Convert.ToBoolean(dgvContrato.SelectedRows[0].Cells["Seleccion"].Value) == false)
                {
                    int idServicioSeleccionado = Convert.ToInt32(dgvContrato.SelectedRows[0].Cells["id_servicios"].Value);
                    int idSubServicioSeleccionado = Convert.ToInt32(dgvContrato.SelectedRows[0].Cells["id_tipo"].Value);
                    int cantidadServiciosIgual = 0;
                    string nombreServicioSeleccionado = dgvContrato.SelectedRows[0].Cells["servicio"].Value.ToString();
                    foreach (DataGridViewRow item in dgvContrato.Rows)
                    {
                        if (Convert.ToInt32(item.Cells["id_tipo"].Value) == idSubServicioSeleccionado)
                            cantidadServiciosIgual++;
                    }
                    if (cantidadServiciosIgual > 1)
                    {
                        if (MessageBox.Show("¿Desea activar este mismo subservicio en los " + nombreServicioSeleccionado + " restantes?", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            foreach (DataGridViewRow item in dgvContrato.Rows)
                            {
                                if (Convert.ToInt32(item.Cells["id_tipo"].Value) == idSubServicioSeleccionado)
                                {
                                    item.Cells["seleccion"].Value = true;
                                }
                            }
                        }
                    }
                }
                if (valorSeleccion)
                    dgvContrato.SelectedRows[0].Cells["Seleccion"].Value = false;
                else
                    dgvContrato.SelectedRows[0].Cells["Seleccion"].Value = true;
                CalcularBonificaciones();
                CalcularTotales();

                cambiosEnGrilla = true;
            }
            dgvContrato.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void dgvContrato_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 1 || e.ColumnIndex < 0)
                return;

            if (e.ColumnIndex == 1)
            {
                e.AdvancedBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.None;

                if (Validar(e.ColumnIndex, e.RowIndex, dgvContrato))
                {
                    e.AdvancedBorderStyle.Top = DataGridViewAdvancedCellBorderStyle.None;
                }
            }
        }

        private void dgvContrato_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 17)
                    return;

                if (dgvContrato[e.ColumnIndex, e.RowIndex].Value.ToString() == "0")
                {
                    e.Value = "";
                    e.FormattingApplied = true;
                }

                if (e.RowIndex == 0)
                    return;


                if (e.ColumnIndex == 1)
                {
                    if (Validar(e.ColumnIndex, e.RowIndex, dgvContrato))
                    {
                        e.Value = "";
                        e.FormattingApplied = true;
                    }
                }

            }
            catch { }
        }

        private void dgvContrato_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvContrato.SelectedRows.Count > 0)
            {
                if (dgvContrato.SelectedRows[0].Cells["Item"].Value.ToString() == "")
                    btnDeshacer.Enabled = true;
                else
                {
                    btnDeshacer.Enabled = false;

                    if (dgvContrato.SelectedRows[0].Cells["Tipo"].Value.ToString() == "S")
                        btnAgregarSub.Enabled = true;
                    else
                        btnAgregarSub.Enabled = false;
                }
            }
        }

        private void dgvContrato_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.ColumnIndex != 0 && dgvContrato.Columns[e.ColumnIndex].Name != "Seleccion")
                e.Cancel = true;
        }

        private void btnDeshacer_Click(object sender, EventArgs e)
        {
            if (dgvContrato.SelectedRows.Count > 0)
            {
                Int32 idEliminar = Convert.ToInt32(dgvContrato.SelectedRows[0].Cells["id_eliminar"].Value);

                for (int i = dtServAContratar.Rows.Count - 1; i >= 0; i--)
                {
                    DataRow dr = dtServAContratar.Rows[i];
                    if (Convert.ToInt32(dr["id_eliminar"]) == idEliminar)
                        dr.Delete();
                }
                dtServAContratar.AcceptChanges();

                DataRow[] drfilter = dtServContratados.Select(String.Format("Id_Eliminar = {0}", idEliminar));
                drfilter.FirstOrDefault().Delete();
                dtServContratados.AcceptChanges();

                dgvContrato.Refresh();
                CalcularBonificaciones();
                CalcularTotales();
                cambiosEnGrilla = false;

                if (dtServAContratar.Rows.Count == 0)
                {
                    cboTipoFacturacion.Enabled = true;
                }
                ContadorServicios();
            }
        }

        private void btnAgregarSub_Click(object sender, EventArgs e)
        {
            if (dgvContrato.SelectedRows.Count > 0)
            {
                Int32 id = Convert.ToInt32(dgvContrato.SelectedRows[0].Cells["Id_Tipo"].Value);

                DataRow[] dr = dtServAContratar.Select(String.Format("Id_Tipo = {0}", id));

                Int32 idusuarioservicio = Convert.ToInt32(dtServAContratar.Compute("MAX(id_usuarios_servicios_sub)", String.Format("Id_Servicios = {0}", dr[0]["Id_Servicios"]))) + 1;

                //dr[0]["id_usuarios_servicios_sub"] = idusuarioservicio;

                //dtServAContratar.ImportRow(dr[0]);
                //dtServAContratar.Rows[dtServAContratar.Rows.Count - 1]["id_usuarios_servicios_sub"] = idusuarioservicio;

                dtServAContratar.ImportRow(dr[0]);
                dtServAContratar.Rows[dtServAContratar.Rows.Count - 1]["id_usuarios_servicios_sub"] = idusuarioservicio;
                dgvContrato.Refresh();
                CalcularBonificaciones();

                ContadorServicios();
                CalcularTotales();
                cambiosEnGrilla = false;
            }
        }

        private void txtCUIT_Leave(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cboCondIVA.SelectedValue) > 1 && txtCUIT.Text.Length > 0)
            {
                if (Tool.ValidaCuit(txtCUIT.Text) == false)
                {
                    MessageBox.Show("CUIT Invalido", "Mensaje del Sistema", MessageBoxButtons.OK);

                    txtCUIT.Focus();
                }
            }
        }

        private void cboLocalidades_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                int idlocalidad = Convert.ToInt32(cboLocalidades.SelectedValue);

                if (idlocalidad > 0)
                {
                    if (this.TipoFacturacion == Tipo_Facturacion.Id_Tipo_Facturacion.POR_ZONAS)
                    {
                        DataRow[] dr = dtLocalidadesLocacion.Select(String.Format("Id_Localidad = {0}", idlocalidad));

                        if (dr.Length > 0)
                            txtCPServicio.Text = dr[0]["CP"].ToString();

                    }
                    else
                    {
                        DataRow[] dr = dtLocalidadesLocacion.Select(String.Format("Id = {0}", idlocalidad));

                        if (dr.Length > 0)
                            txtCPServicio.Text = dr[0]["Codigo_Postal"].ToString();

                    }
                }
            }
            catch { }
        }

        private void cboTipoFacturacion_SelectedValueChanged(object sender, EventArgs e)
        {

            try
            {
                switch (TipoFacturacion)
                {
                    case Tipo_Facturacion.Id_Tipo_Facturacion.POR_ZONAS:
                        DataRow[] dr = dtLocalidades.Select(String.Format("Id_Localidad = {0}", cboTipoFacturacion.SelectedValue));
                        dtServicios.DefaultView.RowFilter = String.Format("Id_Tipo_Facturacion = {0}", dr[0]["Id_Zona"]);
                        Id_Tipo_Facturacion = Convert.ToInt32(dr[0]["Id_Zona"]);
                        break;
                    case Tipo_Facturacion.Id_Tipo_Facturacion.POR_CATEGORIAS:
                        Id_Servicios_Categorias = Convert.ToInt32(cboTipoFacturacion.SelectedValue);
                        dtServicios.DefaultView.RowFilter = String.Format("Id_Tipo_Facturacion = {0}", Id_Servicios_Categorias);
                        Id_Tipo_Facturacion = Id_Servicios_Categorias;
                        break;
                    default:
                           MessageBox.Show("Hubo un error y no se pudo establecer el tipo de facturacion.", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }

                btnServicios.Enabled = Id_Tipo_Facturacion > 0 ? true : false;

                CargarServicios();
            }
            catch { }
        }

        private void txtAlturaServicio_Validated(object sender, EventArgs e)
        {
            if (txtAlturaServicio.Text != String.Empty)
            {
                int altura = Convert.ToInt32(txtAlturaServicio.Text);

                if (altura >= this.Altura_Desde && altura <= this.Altura_Hasta)
                    txtPisoServicio.Focus();
                else
                {
                    MessageBox.Show("La Altura Ingresada no es Correcta", "Mensaje del Sistema",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    txtAlturaServicio.Focus();
                }
            }

        }

        private void btnServicios_Click(object sender, EventArgs e)
        {
            using (frmPopUp frm = new frmPopUp())
            {
                frmParteConexion_Servicios frmServicios = new frmParteConexion_Servicios();
                DataView dtv = new DataView(dtServicios);

                dtv.RowFilter = String.Format("Id_Tipo_Facturacion = {0}", this.Id_Tipo_Facturacion);
                frmServicios.DataServicios = dtv.ToTable();
                frm.Maximizar = false;
                frm.Formulario = frmServicios;

                if (frm.ShowDialog() == DialogResult.OK)
                {
                    idServicioSel = frmServicios.IdServiciosSeleccionado;
                    AgregarServicio(idServicioSel);
                }

            }
        }

        private void dgvServiciosContratados_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 1 || e.ColumnIndex < 0)
                return;

            if (e.ColumnIndex == 1)
            {
                e.AdvancedBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.None;

                if (Validar(e.ColumnIndex, e.RowIndex, dgvServiciosContratados))
                {
                    e.AdvancedBorderStyle.Top = DataGridViewAdvancedCellBorderStyle.None;
                }
            }
        }

        private void dgvServiciosContratados_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex == 0)
                return;

            if (e.ColumnIndex == 1)
            {
                if (Validar(e.ColumnIndex, e.RowIndex, dgvServiciosContratados))
                {
                    e.Value = "";
                    e.FormattingApplied = true;
                }
            }
        }

        private void btnBuscarCalle_Click(object sender, EventArgs e)
        {
            BuscarCalle();
        }

        private void btnCalcularBonificaciones_Click(object sender, EventArgs e)
        {
            if (dtServAContratar.Rows.Count > 0)
            {
                CalcularBonificaciones();
                CalcularTotales();
                cambiosEnGrilla = false;
            }
            else
                MessageBox.Show("Debe contratar al menos un servicio para poder aplicar bonificaciones.");
        }

        private void dgvContrato_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int idBoni, idBoniCont;
                idBoni = Convert.ToInt32(dgvContrato.SelectedRows[0].Cells["Id_Bonificacion"].Value);
                idBoniCont = Convert.ToInt32(dgvContrato.SelectedRows[0].Cells["Id_Bonificacion_Contratacion"].Value);
                if ((idBoni != 0) || (idBoniCont != 0))
                {
                    using (frmPopUp frm = new frmPopUp())
                    {
                        frmUsuariosCtacteDetExtras oExtras = new frmUsuariosCtacteDetExtras(true);

                        oExtras.idBonificacion = idBoni;
                        oExtras.idBonifContratacion = idBoniCont;
                        frm.Formulario = oExtras;
                        frm.Maximizar = false;
                        frm.ShowDialog();
                    }
                }
            }
            catch { }
        }

        private void tabWizard_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabWizard.SelectedIndex != 0 && cambiosEnGrilla)
            {
                CalcularBonificaciones();
                CalcularTotales();
                cambiosEnGrilla = false;
            }
        }

        private void boton1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("La conexion se cancelará ¿Desea salir de todas formas?", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                this.Close();
        }

        private void dgvContrato_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            foreach (DataGridViewRow item in dgvContrato.Rows)
                item.Height = 30;
        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("La conexion se cancelará ¿Desea salir de todas formas?", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                this.Close();
        }

        private void tabServicios_Enter(object sender, EventArgs e)
        {
            pnlPaso1.BackgroundImage = Properties.Resources.pasoActual;
            pnlPaso2.BackgroundImage = Properties.Resources.pasoSiguiente;
            pnlPaso3.BackgroundImage = Properties.Resources.pasoSiguiente;
            pnlPaso4.BackgroundImage = Properties.Resources.pasoSiguiente;

        }

        private void tabUsuario_Enter(object sender, EventArgs e)
        {
            pnlPaso1.BackgroundImage = Properties.Resources.pasoListo;
            pnlPaso2.BackgroundImage = Properties.Resources.pasoActual;
            pnlPaso3.BackgroundImage = Properties.Resources.pasoSiguiente;
            pnlPaso4.BackgroundImage = Properties.Resources.pasoSiguiente;
        }

        private void tabLocacion_Enter(object sender, EventArgs e)
        {
            pnlPaso1.BackgroundImage = Properties.Resources.pasoListo;
            pnlPaso2.BackgroundImage = Properties.Resources.pasoListo;
            pnlPaso3.BackgroundImage = Properties.Resources.pasoActual;
            pnlPaso4.BackgroundImage = Properties.Resources.pasoSiguiente;
        }

        private void tabParteConexion_Enter(object sender, EventArgs e)
        {
            pnlPaso1.BackgroundImage = Properties.Resources.pasoListo;
            pnlPaso2.BackgroundImage = Properties.Resources.pasoListo;
            pnlPaso3.BackgroundImage = Properties.Resources.pasoListo;
            pnlPaso4.BackgroundImage = Properties.Resources.pasoActual;
        }

        private void pnlPaso2_Click(object sender, EventArgs e)
        {
            if (tabWizard.TabPages.Count >= 2)
                tabWizard.SelectTab(1);
        }

        private void pnlPaso3_Click(object sender, EventArgs e)
        {
            if (tabWizard.TabPages.Count >= 3)
                tabWizard.SelectTab(2);
        }

        private void pnlPaso1_Click(object sender, EventArgs e)
        {
            tabWizard.SelectTab(0);

        }

        private void btnBonificacionesEspeciales_Click(object sender, EventArgs e)
        {
            if (dgvContrato.Rows.Count > 0)
            {
                if (dgvContrato.SelectedRows.Count > 0)
                {
                    if (Convert.ToInt32(dgvContrato.SelectedRows[0].Cells["id_tipo"].Value) != 0)
                    {
                        int idDescuento = 0;
                        DataTable dtDescuentosEspeciales = new DataTable();
                        Bonificaciones oBonificaciones = new Bonificaciones();
                        DataView dtvDecuentosEspeciales;
                        dtDescuentosEspeciales = oBonificaciones.ListarPorTipo(Convert.ToInt32(Bonificaciones.TIPO_BONIFICACION.ESPECIAL));
                        if (dtDescuentosEspeciales.Rows.Count > 0)
                        {
                            if (dtDescuentosEspeciales.Select(String.Format("modalidad_venta_pago={0}", Convert.ToInt32(Bonificaciones.MODALIDAD_VENTA_PAGO.VENTA))).Count() > 0)
                            {
                                dtvDecuentosEspeciales = new DataView(dtDescuentosEspeciales);
                                dtvDecuentosEspeciales.RowFilter = String.Format("modalidad_venta_pago={0}", Convert.ToInt32(Bonificaciones.MODALIDAD_VENTA_PAGO.VENTA));
                                frmBonificacionesEspeciales frmBonificacionesEspeciales = new frmBonificacionesEspeciales(dtvDecuentosEspeciales.ToTable());
                                frmPopUp frmpp = new frmPopUp();
                                frmpp.Formulario = frmBonificacionesEspeciales;
                                frmpp.Maximizar = false;
                                frmpp.ShowDialog();
                                if (frmBonificacionesEspeciales.DialogResult == DialogResult.OK)
                                {
                                    idDescuento = frmBonificacionesEspeciales.idDescuentoSeleccionado;
                                    dtServAContratar.Rows[dgvContrato.SelectedRows[0].Index]["Id_Bonificacion_Esp"] = idDescuento;
                                    dtServAContratar.AcceptChanges();
                                    CalcularBonificaciones();
                                    CalcularTotales();
                                    cambiosEnGrilla = false;
                                }
                            }
                            else
                                MessageBox.Show("No hay descuentos especiales cargados en el sistema.");
                        }
                        else
                            MessageBox.Show("No hay descuentos especiales cargados en el sistema.");
                    }
                    else
                        MessageBox.Show("Debe seleccionar un subservicio para aplicarle un descuento especial.");
                }
                else
                    MessageBox.Show("No ha seleccionado un subservicio.");
            }
            else
                MessageBox.Show("No hay servicios en la grilla.");
        }

        private void boton1_Click_1(object sender, EventArgs e)
        {
            if (idServicioSel > 0)
            {
                frmComprobantePrepago oPre = new frmComprobantePrepago(0, "", idServicioSel, Convert.ToInt32(cboTipoFacturacion.SelectedValue), DateTime.Now);
                oPre.verTarifas = 0;
                frmPopUp oPop = new frmPopUp();
                oPop.Formulario = oPre;
                oPop.ShowDialog();

            }
        }

        private void chkGenerarDeudas_CheckedChanged(object sender, EventArgs e)
        {
            if (chkGenerarDeudas.Checked)
                generarDeudas = false;
            else
                generarDeudas = true;

        }

        private void chCobraServicios_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void txtNumero_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void pnlPaso4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pnlPaso4_Click(object sender, EventArgs e)
        {
            if (tabWizard.TabPages.Count == 4)
                tabWizard.SelectTab(3);
        }
    }
}