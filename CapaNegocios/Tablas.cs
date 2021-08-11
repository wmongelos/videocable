using CapaDatos;
using System;
using System.Configuration;
using System.Data;
using System.Data.Common;

namespace CapaNegocios
{
    public class Tablas
    {
        public static DataTable DataTipoDNI;
        public static DataTable DataCondIVA;
        public static DataTable DataServicios_Estados;
        public static DataTable DataServicios;
        public static DataTable DataServicios_Velocidades_Relacion;
        public static DataTable DataServicios_Velocidades;
        public static DataTable DataServicios_Velocidades_Tipos;
        public static DataTable DataServiciosCategorias;
        public static DataTable DataLocalidades;
        public static DataTable DataCalles;
        public static DataTable DataImpresiones;
        public static DataTable DataServicios_Tipos;
        public static DataTable DataServicios_Modalidades;
        public static DataTable DataSolicitudes;
        public static DataTable DataEquiposTipos;
        public static DataTable DataEquiposMarcas;
        public static DataTable DataEquiposModelos;
        public static DataTable DataTiposFacturacion;
        public static DataTable DataTiposFacturacionServ;
        public static DataTable DataRolesPermisos;
        public static DataTable DataZonas;
        public static DataTable DataEquiposEstados;
        public static DataTable DataAplicionesExternas;
        public static DataTable DataAvisosDetalles;
        public static DataTable DataOrigenComprobantes;
        public static DataTable DataTipoComprobantes;
        public static DataTable DataMeses;
        public static DataTable DataPuntosVenta;
        public static DataTable DataPartesEstados;
        public static DataTable DataCass;
        public static DataTable DataIsp;
        public static DataTable DataPlataformasPagos;

        public static void ActualizarBase() 
        {
            Configuracion Config = new Configuracion();

            String VersionSistema = Config.GetValor_C("VersionSistema");

            if (VersionSistema != Configuracion.VersionSistema)
            {
                CapaDatos.ScriptsSQL ScripsSql = new CapaDatos.ScriptsSQL();
                ScripsSql.ActualizarBase();

                Config.SetValor_C("VersionSistema", Configuracion.VersionSistema);
            }
        }

        public static void LoadData()
        {
            Comprobantes oComprobantes = new Comprobantes();
            Comprobantes_Tipo oComprobantesTipo = new Comprobantes_Tipo();
            Servicios oServicios = new Servicios();
            Usuarios oUsuarios = new Usuarios();
            Comprobantes_Iva oComprobantesIVA = new Comprobantes_Iva();
            Equipos_Tipos oEquiposTipos = new Equipos_Tipos();
            Zonas oZonas = new Zonas();
            Equipos_Estados oEquiposEstados = new Equipos_Estados();
            Servicios_Categorias oServCat = new Servicios_Categorias();
            Aplicaciones_Externas oAplicaciones = new Aplicaciones_Externas();
            Usuarios_Avisos oAvisos = new Usuarios_Avisos();
            Localidades_Calles oCalles = new Localidades_Calles();
            Puntos_Venta oPuntosVentas = new Puntos_Venta();
            DataView dvCass = new DataView();
            DataView dvIsp = new DataView();

            DataServicios_Estados = oServicios.ListarEstados();
            DataTipoDNI = oUsuarios.ListarTipoDoc();
            DataCondIVA = oComprobantesIVA.Listar();
            DataEquiposTipos = oEquiposTipos.Listar();
            DataServicios = oServicios.Listar();
            DataEquiposEstados = oEquiposEstados.Listar();
            DataServiciosCategorias = oServCat.Listar();
            DataZonas = oZonas.Listar(true);
            DataAplicionesExternas = oAplicaciones.Listar();
            DataAvisosDetalles = oAvisos.ListarMensajesServicios();
            DataCalles = oCalles.Listar();
            DataOrigenComprobantes = oComprobantes.ListarOrigenComprobantes();
            DataTipoComprobantes = oComprobantesTipo.Listar();
            DataPuntosVenta = oPuntosVentas.Listar();

            dvCass = Tablas.DataAplicionesExternas.DefaultView;
            dvCass.RowFilter = "nombre = 'CASS'";
            DataCass = dvCass.ToTable();

            dvIsp = Tablas.DataAplicionesExternas.DefaultView;
            dvIsp.RowFilter = "nombre = 'ISP'";
            DataIsp = dvIsp.ToTable();

            LoadVelocidades();
            LoadEquiposMarcas();
            LoadEquiposModelos();
            LoadLocalidades();
            LoadServiciosTipos();
            LoadServiciosModalidades();
            LoadSolicitudes();
            LoadTiposFacturacion();
            LoadRolesPermisos();
            LoadMeses();
            LoadPartesEstados();
            LoadPlataformasPagos();
        }

        public static void LoadEquiposMarcas()
        {
            Equipos_Marcas oEquiposMarcas = new Equipos_Marcas();
            DataEquiposMarcas = oEquiposMarcas.Listar();

        }        
        public static void LoadPartesEstados()
        {
            Partes_Estados oPartesEstados = new Partes_Estados();
            DataPartesEstados = oPartesEstados.Listar();

        }

        public static void LoadVelocidades()
        {
            Servicios_Velocidades oServiciosVelocidades = new Servicios_Velocidades();
            DataServicios_Velocidades = oServiciosVelocidades.ListarVelocidades();
            DataServicios_Velocidades_Tipos = oServiciosVelocidades.ListarVelocidadesTipos();
        }

        public static void LoadEquiposModelos()
        {
            Equipos_Modelos oEquiposModelos = new Equipos_Modelos();
            DataEquiposModelos = oEquiposModelos.Listar();

        }

        public static void LoadRolesPermisos()
        {
            Roles_Permisos oRP = new Roles_Permisos();
            DataRolesPermisos = oRP.Listar();
        }

        public static void LoadMeses()
        {
            DataMeses = new DataTable();
            DataColumn dcValor = new DataColumn();
            dcValor.ColumnName = "id";
            dcValor.DataType = typeof(int);
            DataColumn dcNombre = new DataColumn();
            dcNombre.ColumnName = "nombre";
            dcNombre.DataType = typeof(string);

            DataMeses.Columns.Add(dcValor);
            DataMeses.Columns.Add(dcNombre);

            DataMeses.Rows.Add(1, "ENERO");
            DataMeses.Rows.Add(2, "FEBRERO");
            DataMeses.Rows.Add(3, "MARZO");
            DataMeses.Rows.Add(4, "ABRIL");
            DataMeses.Rows.Add(5, "MAYO");
            DataMeses.Rows.Add(6, "JUNIO");
            DataMeses.Rows.Add(7, "JULIO");
            DataMeses.Rows.Add(8, "AGOSTO");
            DataMeses.Rows.Add(9, "SEPTIEMBRE");
            DataMeses.Rows.Add(10, "OCTUBRE");
            DataMeses.Rows.Add(11, "NOVIEMBRE");
            DataMeses.Rows.Add(12, "DICIEMBRE");
        }

        public static void LoadLocalidades()
        {
            Localidades oLocalidades = new Localidades();
            DataLocalidades = oLocalidades.Listar();
        }

        public static void LoadImpresiones()
        {
            try
            {
                Conexion oConexion = new Conexion();
                oConexion.Conectar();
                oConexion.CrearComando("SELECT * FROM impresion");
                DataImpresiones = oConexion.Tabla();
                oConexion.DesConectar();
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public static void LoadServiciosTipos()
        {
            Servicios_Tipos oServiciosTipos = new Servicios_Tipos();
            DataServicios_Tipos = oServiciosTipos.Listar();
        }

        public static void LoadServiciosModalidades()
        {
            Servicios oServicios = new Servicios();
            DataServicios_Modalidades = oServicios.ListarModalidades();
        }

        public static void LoadSolicitudes()
        {
            Partes_Solicitudes oSolicitudes = new Partes_Solicitudes();
            DataSolicitudes = oSolicitudes.Listar();
        }

        public static void LoadTiposFacturacion()
        {
            int idConfigTipoFacturacion;
            Servicios_Categorias oServiciosCategorias = new Servicios_Categorias();
            Zonas oZonas = new Zonas();
            Configuracion oConfig = new Configuracion();
            idConfigTipoFacturacion = oConfig.GetValor_N("Id_Tipo_Facturacion");
            if (idConfigTipoFacturacion == System.Convert.ToInt16(Tipo_Facturacion.Id_Tipo_Facturacion.POR_ZONAS))
                DataTiposFacturacion = oZonas.Listar();
            else
                DataTiposFacturacion = oServiciosCategorias.Listar();

            Tipo_Facturacion oTipoFacturacion = new Tipo_Facturacion();

            DataTiposFacturacionServ = oTipoFacturacion.Listar();
        }

        public static DataTable AgregarRegistro(DataTable dt, string nombre,int valor)
        {
            DataTable dtSalida = dt.Copy();
            dtSalida.Rows.Add(valor, nombre.ToUpper());
            return dt;
        }

        public static void LoadPlataformasPagos()
        {
            CapaNegocios.PlataformasPagos oPlataformas = new CapaNegocios.PlataformasPagos() ;
            DataPlataformasPagos = oPlataformas.Listar(1);

        }  
    }
}
