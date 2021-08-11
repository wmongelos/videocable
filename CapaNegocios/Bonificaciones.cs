//modificación 130919-12:53
using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace CapaNegocios
{
    public class Bonificaciones
    {
        public Int32 Id { get; set; }
        public String Nombre { get; set; }
        public Decimal Porcentaje { get; set; }
        public DateTime Fecha_Desde { get; set; }
        public DateTime Fecha_Hasta { get; set; }
        public Int32 Tipo_Bonificacion { get; set; }
        public Int32 Mes_desde { get; set; }
        public Int32 Mes_hasta { get; set; }
        public Int32 Por_contratacion { get; set; }
        public Int32 Cantidad_periodos { get; set; }
        public Int32 Contemplar_fecha_completa { get; set; }
        public Int32 Borrado { get; set; }
        public Int32 Modalidad_Venta_Pago { get; set; }
        private Configuracion oConfig = new Configuracion();
        private Servicios_Tarifas_Sub oTarifasSub = new Servicios_Tarifas_Sub();

        public static DataTable dtSubServicios = new DataTable();
        public static DataTable dtSubServiciosDetalles = new DataTable();
        public static DataTable dtDatosNovedades = new DataTable();

        private Conexion oCon = new Conexion();

        public enum NIVEL
        {
            GRUPO = 0,
            TIPO_SERVICIO = 1,
            SERVICIO = 2,
            SUBSERVICIO = 3
        }

        public enum TIPO_BONIFICACION
        {
            COMBINACION = 0,
            REPETICION = 1,
            ESPECIAL = 2
        }

        public enum MODULO_APLICACION
        {
            FACTURACION = 0,
            CONTRATACION = 1
        }

        public enum BONIFICABLE
        {
            NO = 0,
            SI = 1
        }

        public enum MODALIDAD_VENTA_PAGO
        {
            VENTA = 1,
            PAGO = 2
        }

        public enum CONTEMPLAR_FECHA_COMPLETA
        {
            NO = 0,
            SI = 1
        }

        public enum CONTEMPLAR_SOLO_ESPECIALES
        {
            NO = 1,
            SI = 2
        }

        public void Guardar(Bonificaciones oBonificacionServiciosSub)
        {
            try
            {
                oCon.Conectar();
                if (oBonificacionServiciosSub.Id > 0)
                {
                    oCon.CrearComando("UPDATE bonificaciones set nombre=@nombre, porcentaje=@porcentaje, fecha_desde=@fecha_desde, fecha_hasta=@fecha_hasta, tipo_bonificacion=@tipo_bonificacion, mes_desde=@mes_desde, mes_hasta=@mes_hasta, cantidad_periodos=@cantidad_periodos, por_contratacion=@por_contratacion, contemplar_fecha_completa=@contemplar_fecha_completa, modalidad_venta_pago=@modalidad_venta_pago,id_personal=@personal WHERE Id = @id");
                    oCon.AsignarParametroCadena("@nombre", oBonificacionServiciosSub.Nombre);
                    oCon.AsignarParametroDecimal("@porcentaje", oBonificacionServiciosSub.Porcentaje);
                    oCon.AsignarParametroFecha("@fecha_desde", oBonificacionServiciosSub.Fecha_Desde);
                    oCon.AsignarParametroFecha("@fecha_hasta", oBonificacionServiciosSub.Fecha_Hasta);
                    oCon.AsignarParametroEntero("@tipo_bonificacion", oBonificacionServiciosSub.Tipo_Bonificacion);
                    oCon.AsignarParametroEntero("@mes_desde", oBonificacionServiciosSub.Mes_desde);
                    oCon.AsignarParametroEntero("@mes_hasta", oBonificacionServiciosSub.Mes_hasta);
                    oCon.AsignarParametroEntero("@cantidad_periodos", oBonificacionServiciosSub.Cantidad_periodos);
                    oCon.AsignarParametroEntero("@por_contratacion", oBonificacionServiciosSub.Por_contratacion);
                    oCon.AsignarParametroEntero("@contemplar_fecha_completa", oBonificacionServiciosSub.Contemplar_fecha_completa);
                    oCon.AsignarParametroEntero("@modalidad_venta_pago", oBonificacionServiciosSub.Modalidad_Venta_Pago);
                    oCon.AsignarParametroEntero("@personal", Personal.Id_Login);
                    oCon.AsignarParametroEntero("@id", oBonificacionServiciosSub.Id);
                }
                else
                {
                    oCon.CrearComando("INSERT INTO bonificaciones(nombre, porcentaje, fecha_desde, fecha_hasta, tipo_bonificacion, mes_desde, mes_hasta, cantidad_periodos, por_contratacion, contemplar_fecha_completa, modalidad_venta_pago,id_personal) values(@nombre, @porcentaje, @fecha_desde, @fecha_hasta, @tipo_bonificacion, @mes_desde, @mes_hasta, @cantidad_periodos, @por_contratacion, @contemplar_fecha_completa, @modalidad_venta_pago,@personal)");
                    oCon.AsignarParametroCadena("@nombre", oBonificacionServiciosSub.Nombre);
                    oCon.AsignarParametroDecimal("@porcentaje", oBonificacionServiciosSub.Porcentaje);
                    oCon.AsignarParametroFecha("@fecha_desde", oBonificacionServiciosSub.Fecha_Desde);
                    oCon.AsignarParametroFecha("@fecha_hasta", oBonificacionServiciosSub.Fecha_Hasta);
                    oCon.AsignarParametroEntero("@tipo_bonificacion", oBonificacionServiciosSub.Tipo_Bonificacion);
                    oCon.AsignarParametroEntero("@mes_desde", oBonificacionServiciosSub.Mes_desde);
                    oCon.AsignarParametroEntero("@mes_hasta", oBonificacionServiciosSub.Mes_hasta);
                    oCon.AsignarParametroEntero("@cantidad_periodos", oBonificacionServiciosSub.Cantidad_periodos);
                    oCon.AsignarParametroEntero("@por_contratacion", oBonificacionServiciosSub.Por_contratacion);
                    oCon.AsignarParametroEntero("@contemplar_fecha_completa", oBonificacionServiciosSub.Contemplar_fecha_completa);
                    oCon.AsignarParametroEntero("@modalidad_venta_pago", oBonificacionServiciosSub.Modalidad_Venta_Pago);
                    oCon.AsignarParametroEntero("@personal", Personal.Id_Login);

                }


                oCon.ComenzarTransaccion();
                oCon.EjecutarComando();
                oCon.ConfirmarTransaccion();
                oCon.DesConectar();
            }
            catch (Exception)
            {
                oCon.CancelarTransaccion();
                oCon.DesConectar();

                throw;
            }
        }

        public void Eliminar(int id)
        {
            try
            {
                oCon.Conectar();
                oCon.ComenzarTransaccion();
                oCon.CrearComando("UPDATE bonificaciones SET Borrado = 1,id_personal = @personal WHERE Id = @id");
                oCon.AsignarParametroEntero("@personal", Personal.Id_Login);
                oCon.AsignarParametroEntero("@id", id);
                oCon.EjecutarComando();
                oCon.ConfirmarTransaccion();
                oCon.DesConectar();
            }
            catch (Exception)
            {
                oCon.CancelarTransaccion();
                oCon.DesConectar();
                throw;
            }
        }

        public DataTable Listar()
        {
            oCon.Conectar();

            oCon.CrearComando(String.Format("select id, nombre, CASE WHEN tipo_bonificacion=0 THEN 'Combinación' WHEN tipo_bonificacion=1 THEN 'Repetición' WHEN tipo_bonificacion=2 THEN 'Especial' END as tipo_bonif_texto," +
                                            " if (por_contratacion = 1, 'Contratación', 'Facturacion') as modulo_aplicacion, if (contemplar_fecha_completa = 1, 'Fecha completa', 'Número de mes') as fecha_aplicacion," +
                                            " if (contemplar_fecha_completa = 1, convert(date(fecha_desde), char), concat('Mes ', convert(mes_desde, char))) as fecha_desde_texto, if (contemplar_fecha_completa = 1, convert(date(fecha_hasta), char), concat('Mes ', convert(mes_hasta, char))) as fecha_hasta_texto," +
                                            " if (por_contratacion = 1, convert(cantidad_periodos, char), 'No aplica') as cantidad_periodos_texto, case when tipo_bonificacion = 0 then convert(porcentaje, char) when tipo_bonificacion = 1 then 'El porcentaje se determina en condiciones' end as porcentaje_texto," +
                                            " tipo_bonificacion, mes_desde, mes_hasta, porcentaje, por_contratacion,fecha_desde,fecha_hasta, contemplar_fecha_completa, cantidad_periodos, modalidad_venta_pago from bonificaciones where borrado = 0"));
            DataTable dt = oCon.Tabla();
            oCon.DesConectar();
            return dt;
        }

        public DataTable ListarPorId(int IdBonificacion)
        {
            oCon.Conectar();
            oCon.CrearComando(String.Format("select id, nombre, date(fecha_desde) as fecha_desde, date(fecha_hasta) as fecha_hasta, porcentaje, mes_desde, mes_hasta, cantidad_periodos, por_contratacion, contemplar_fecha_completa, tipo_bonificacion, modalidad_venta_pago from bonificaciones where id={0} and borrado=0", IdBonificacion));
            DataTable dt = oCon.Tabla();
            oCon.DesConectar();
            return dt;
        }

        public DataTable ListarPorTipo(int IdTipoBonificacion)
        {
            oCon.Conectar();
            oCon.CrearComando(String.Format("select id, nombre, date(fecha_desde) as fecha_desde, date(fecha_hasta) as fecha_hasta, porcentaje, mes_desde, mes_hasta, cantidad_periodos, por_contratacion, contemplar_fecha_completa, tipo_bonificacion, modalidad_venta_pago from bonificaciones where tipo_bonificacion={0} and borrado=0", IdTipoBonificacion));
            DataTable dt = oCon.Tabla();
            oCon.DesConectar();
            return dt;
        }

        public DataTable GenerarDtSubServicios()
        {
            DataTable DtSubServicios = new DataTable();
            DtSubServicios.Columns.Add("id_usuario_servicio", typeof(string));
            DtSubServicios.Columns.Add("id_usuario_servicio_sub", typeof(string));
            DtSubServicios.Columns.Add("id_tipo_facturacion", typeof(string));
            DtSubServicios.Columns.Add("id_grupo", typeof(string));
            DtSubServicios.Columns.Add("id_servicio_tipo", typeof(string));
            DtSubServicios.Columns.Add("id_servicio", typeof(string));
            DtSubServicios.Columns.Add("id_servicio_sub", typeof(string));
            DtSubServicios.Columns.Add("id_velocidad", typeof(string));
            DtSubServicios.Columns.Add("id_velocidad_tipo", typeof(string));
            DtSubServicios.Columns.Add("tipo_servicio_sub", typeof(string));
            DtSubServicios.Columns.Add("cant_bocas_pac", typeof(string));
            DtSubServicios.Columns.Add("tipofac", typeof(string));
            DtSubServicios.Columns.Add("grupo", typeof(string));
            DtSubServicios.Columns.Add("tipo", typeof(string));
            DtSubServicios.Columns.Add("servicio", typeof(string));
            DtSubServicios.Columns.Add("subservicio", typeof(string));
            DtSubServicios.Columns.Add("velocidad", typeof(string));
            DtSubServicios.Columns.Add("velocidad_tipo", typeof(string));
            DtSubServicios.Columns.Add("tiposub", typeof(string));
            DtSubServicios.Columns.Add("id_relacion", typeof(Int32));
            DtSubServicios.Columns.Add("calle", typeof(string));
            DtSubServicios.Columns.Add("altura", typeof(string));
            DtSubServicios.Columns.Add("piso", typeof(string));
            DtSubServicios.Columns.Add("depto", typeof(string));
            DtSubServicios.Columns.Add("localidad", typeof(string));
            DtSubServicios.Columns.Add("usuario", typeof(string));
            DtSubServicios.Columns.Add("codigo_usuario", typeof(string));
            DtSubServicios.Columns.Add("id_servicios_estados", typeof(string));

            DataColumn DcIpFija = new DataColumn("id_ip_fija", typeof(decimal));
            DcIpFija.DefaultValue = 0;
            DtSubServicios.Columns.Add(DcIpFija);

            DataColumn DcIdTipoDeSub = new DataColumn("id_tipo_de_sub", typeof(decimal));
            DcIdTipoDeSub.DefaultValue = 0;
            DtSubServicios.Columns.Add(DcIdTipoDeSub);

            DataColumn DcImporteOriginal = new DataColumn("importe_original", typeof(decimal));
            DcImporteOriginal.DefaultValue = 0;
            DtSubServicios.Columns.Add(DcImporteOriginal);

            DataColumn DcImporteDescuento = new DataColumn("importe_con_descuento", typeof(decimal));
            DcImporteDescuento.DefaultValue = 0;
            DtSubServicios.Columns.Add(DcImporteDescuento);



            DataColumn DcBonificable = new DataColumn("bonificable", typeof(int));
            DcBonificable.DefaultValue = 1;
            DtSubServicios.Columns.Add(DcBonificable);

            //-------- datos requeridos para la creación de bonificaciones automáticas. A estos datos se adicionan algunos de los que están arriba 
            DataColumn DcPorcentajeContratacion = new DataColumn("porcentaje_contratacion", typeof(decimal));
            DcPorcentajeContratacion.DefaultValue = 0;
            DtSubServicios.Columns.Add(DcPorcentajeContratacion);

            DataColumn DcCantidadPeriodos = new DataColumn("cantidad_periodos", typeof(decimal));
            DcCantidadPeriodos.DefaultValue = 0;
            DtSubServicios.Columns.Add(DcCantidadPeriodos);

            DataColumn DcIdUsuarios = new DataColumn("id_usuarios", typeof(decimal));
            DcIdUsuarios.DefaultValue = 0;
            DtSubServicios.Columns.Add(DcIdUsuarios);

            DataColumn DcIdUsuariosLocaciones = new DataColumn("id_usuarios_locaciones", typeof(decimal));
            DcIdUsuariosLocaciones.DefaultValue = 0;
            DtSubServicios.Columns.Add(DcIdUsuariosLocaciones);

            DataColumn DcFechaDesdeNovedad = new DataColumn("fecha_desde_novedad", typeof(string));
            DcFechaDesdeNovedad.DefaultValue = 0;
            DtSubServicios.Columns.Add(DcFechaDesdeNovedad);

            DataColumn DcFechaHastaNovedad = new DataColumn("fecha_hasta_novedad", typeof(string));
            DcFechaHastaNovedad.DefaultValue = 0;
            DtSubServicios.Columns.Add(DcFechaHastaNovedad);

            DataColumn DcTipoBonificacionContratacion = new DataColumn("nivel_bonificacion_contratacion", typeof(string));
            DcTipoBonificacionContratacion.DefaultValue = 0;
            DtSubServicios.Columns.Add(DcTipoBonificacionContratacion);

            DataColumn DcMesesServicio = new DataColumn("meses_servicio", typeof(string));
            DcMesesServicio.DefaultValue = 0;
            DtSubServicios.Columns.Add(DcMesesServicio);

            DataColumn DcIndiceTabla = new DataColumn("indice_generado", typeof(string));
            DcIndiceTabla.DefaultValue = 0;
            DtSubServicios.Columns.Add(DcIndiceTabla);

            DataColumn DcFechaContratacion = new DataColumn("fecha_contratacion", typeof(string));
            DcFechaContratacion.DefaultValue = 0;
            DtSubServicios.Columns.Add(DcFechaContratacion);

            DataColumn DcFechaFactura = new DataColumn("fecha_factura", typeof(string));
            DcFechaFactura.DefaultValue = 0;
            DtSubServicios.Columns.Add(DcFechaFactura);

            DataColumn DcFechaFacturaServicio = new DataColumn("fecha_factura_servicio", typeof(string));
            DcFechaFacturaServicio.DefaultValue = 0;
            DtSubServicios.Columns.Add(DcFechaFacturaServicio);

            DataColumn DcIdServiciosTarifas = new DataColumn("id_servicios_tarifas", typeof(string));
            DcIdServiciosTarifas.DefaultValue = 0;
            DtSubServicios.Columns.Add(DcIdServiciosTarifas);

            DataColumn DcRequiereIp = new DataColumn("requiere_ip", typeof(string));
            DcRequiereIp.DefaultValue = 0;
            DtSubServicios.Columns.Add(DcRequiereIp);

            DataColumn DcCalculoBonificacion = new DataColumn("calculo_bonificacion", typeof(string));
            DcCalculoBonificacion.DefaultValue = 0;
            DtSubServicios.Columns.Add(DcCalculoBonificacion);

            DataColumn DcCobroUnico = new DataColumn("cobro_unico", typeof(string));
            DcCobroUnico.DefaultValue = 0;
            DtSubServicios.Columns.Add(DcCobroUnico);

            DataColumn DcFechaInicioServicio = new DataColumn("fecha_inicio_servicio", typeof(string));
            DcFechaInicioServicio.DefaultValue = 0;
            DtSubServicios.Columns.Add(DcFechaInicioServicio);

            DataColumn DcMesesCobro = new DataColumn("meses_cobro", typeof(string));
            DcMesesCobro.DefaultValue = 0;
            DtSubServicios.Columns.Add(DcMesesCobro);

            DataColumn DcIdServicioModalidad = new DataColumn("id_servicio_modalidad", typeof(string));
            DcIdServicioModalidad.DefaultValue = 0;
            DtSubServicios.Columns.Add(DcIdServicioModalidad);

            DataColumn DcHeredado = new DataColumn("heredado", typeof(string));
            DcHeredado.DefaultValue = 0;
            DtSubServicios.Columns.Add(DcHeredado);

            DataColumn DcBonificacionEspecial = new DataColumn("id_bonificacion_especial", typeof(string));
            DcBonificacionEspecial.DefaultValue = 0;
            DtSubServicios.Columns.Add(DcBonificacionEspecial);

            DataColumn DcFechaHastaServicio = new DataColumn("fecha_hasta_servicio", typeof(string));
            DcFechaHastaServicio.DefaultValue = 0;
            DtSubServicios.Columns.Add(DcFechaHastaServicio);

            DtSubServicios.Columns.Add("nombre_bonificacion", typeof(string));

            DataColumn DcIdBonificacion = new DataColumn("id_bonificacion", typeof(decimal));
            DcIdBonificacion.DefaultValue = 0;
            DtSubServicios.Columns.Add(DcIdBonificacion);

            DataColumn DcPorcentaje = new DataColumn("porcentaje", typeof(decimal));
            DcPorcentaje.DefaultValue = 0;
            DtSubServicios.Columns.Add(DcPorcentaje);

            DataColumn DcIdLocalidad = new DataColumn("id_localidad", typeof(string));
            DcIdLocalidad.DefaultValue = 0;
            DtSubServicios.Columns.Add(DcIdLocalidad);

            DataColumn DcIdServiciosTarifasSubEsp = new DataColumn("id_servicios_tarifas_sub_esp", typeof(string));
            DcIdServiciosTarifasSubEsp.DefaultValue = 0;
            DtSubServicios.Columns.Add(DcIdServiciosTarifasSubEsp);

            DataColumn DcFacturaMensualmente = new DataColumn("factura_mensualmente", typeof(string));
            DcFacturaMensualmente.DefaultValue = 0;
            DtSubServicios.Columns.Add(DcFacturaMensualmente);

            DataColumn DcCategoria = new DataColumn("tipo_fac", typeof(string));
            DcCategoria.DefaultValue = 0;
            DtSubServicios.Columns.Add(DcCategoria);

            return DtSubServicios;
        }

        public DataTable GenerarDtMesesPorcentajes()
        {
            DataTable dtMesesPorcentajes = new DataTable();

            //usuario_servicio del subservicio al que pertenece el registro
            DataColumn DcIdUsuariosServicios = new DataColumn("id_usuarios_servicios", typeof(string));
            DcIdUsuariosServicios.DefaultValue = 0;
            dtMesesPorcentajes.Columns.Add(DcIdUsuariosServicios);

            //usuarios_servicios_sub al que pertenece el registro
            DataColumn DcIdUsuariosServiciosSub = new DataColumn("id_usuarios_servicios_sub", typeof(string));
            DcIdUsuariosServiciosSub.DefaultValue = 0;
            dtMesesPorcentajes.Columns.Add(DcIdUsuariosServiciosSub);

            //locacion del usuario_servicio_sub al que pertenece el registro
            DataColumn DcIdUsuariosLocaciones = new DataColumn("id_usuarios_locaciones", typeof(string));
            DcIdUsuariosLocaciones.DefaultValue = 0;
            dtMesesPorcentajes.Columns.Add(DcIdUsuariosLocaciones);

            //mes al que pertenece el registro.Si es un servicio por periodo cerrado de mes o día, este campo queda en 0.
            DataColumn DcNroMes = new DataColumn("nro_mes", typeof(string));
            DcNroMes.DefaultValue = 0;
            dtMesesPorcentajes.Columns.Add(DcNroMes);

            //meses de cobro del usuarios_servicio al que pertenece el registro. Si es periodo cerrado queda en 0
            DataColumn DcMesesCobro = new DataColumn("meses_cobro", typeof(string));
            DcMesesCobro.DefaultValue = 0;
            dtMesesPorcentajes.Columns.Add(DcMesesCobro);

            //meses de servicio del usuario al que pertenece el registro, si es periodo cerrado queda en 0
            DataColumn DcMesesServicio = new DataColumn("meses_servicio", typeof(string));
            DcMesesServicio.DefaultValue = 0;
            dtMesesPorcentajes.Columns.Add(DcMesesServicio);

            //fecha inicia del periodo que abarca el registro
            DataColumn DcFechaDesde = new DataColumn("fecha_desde", typeof(string));
            DcFechaDesde.DefaultValue = 0;
            dtMesesPorcentajes.Columns.Add(DcFechaDesde);

            //fecha final del periodo que abarca el registro
            DataColumn DcFechaHasta = new DataColumn("fecha_hasta", typeof(string));
            DcFechaHasta.DefaultValue = 0;
            dtMesesPorcentajes.Columns.Add(DcFechaHasta);

            //id servicio al que pertenece
            dtMesesPorcentajes.Columns.Add("id_servicios", typeof(string));

            //tipo de subservicio del usuariosserviciosub al que pertenece el registro
            DataColumn DcIdUsuariosServiciosSubTipos = new DataColumn("id_usuarios_servicios_sub_tipos", typeof(string));
            DcIdUsuariosServiciosSubTipos.DefaultValue = 0;
            dtMesesPorcentajes.Columns.Add(DcIdUsuariosServiciosSubTipos);

            //tipo de registro de subservicio, S,P o E
            DataColumn DcTipoServicioSub = new DataColumn("tipo_servicio_sub", typeof(string));
            DcTipoServicioSub.DefaultValue = 0;
            dtMesesPorcentajes.Columns.Add(DcTipoServicioSub);

            //si requiere o no ip
            DataColumn DcRequiereIp = new DataColumn("requiere_ip", typeof(string));
            DcRequiereIp.DefaultValue = 0;
            dtMesesPorcentajes.Columns.Add(DcRequiereIp);

            //velocidad a la que pertenece si se es un servicio que requiere velocidad
            dtMesesPorcentajes.Columns.Add("id_servicios_velocidades", typeof(string));

            //tipo de velocidad a la que pertenece si requiere velocidad
            dtMesesPorcentajes.Columns.Add("id_servicios_velocidades_tipos", typeof(string));

            //se usa para tomar o no en cuenta el registro en algún proceso, por defecto está en 0.
            DataColumn DcBorrado = new DataColumn("borrado", typeof(string));
            DcBorrado.DefaultValue = 0;
            dtMesesPorcentajes.Columns.Add(DcBorrado);

            //tipo de registro. Si es de un servicio por dia, mes, periodo o periodo cerrado
            DataColumn DcModalidad = new DataColumn("id_servicios_modalidad", typeof(string));
            DcModalidad.DefaultValue = 1;
            dtMesesPorcentajes.Columns.Add(DcModalidad);

            //datos de bonificación por contratación, algunos ya no se utilizan---------------------------------------------------
            DataColumn DcPorContratacion = new DataColumn("por_contratacion", typeof(string));
            DcPorContratacion.DefaultValue = 0;
            dtMesesPorcentajes.Columns.Add(DcPorContratacion);
            DataColumn DcTipoBonificacionContratacion = new DataColumn("nivel_bonificacion_contratacion", typeof(string));
            DcTipoBonificacionContratacion.DefaultValue = 0;
            dtMesesPorcentajes.Columns.Add(DcTipoBonificacionContratacion);
            DataColumn DcServiciosVelocidades = new DataColumn("id_servicios_velocidades_contratacion", typeof(string));
            DcServiciosVelocidades.DefaultValue = 0;
            dtMesesPorcentajes.Columns.Add(DcServiciosVelocidades);
            DataColumn DcServiciosVelocidadesTipos = new DataColumn("id_servicios_velocidades_tip_contratacion", typeof(string));
            DcServiciosVelocidadesTipos.DefaultValue = 0;
            dtMesesPorcentajes.Columns.Add(DcServiciosVelocidadesTipos);
            DataColumn DcIdBonificacionContratacion = new DataColumn("id_bonificacion_contratacion", typeof(string));
            DcIdBonificacionContratacion.DefaultValue = 0;
            dtMesesPorcentajes.Columns.Add(DcIdBonificacionContratacion);
            dtMesesPorcentajes.Columns.Add("fecha_desde_contratacion", typeof(string));
            dtMesesPorcentajes.Columns.Add("fecha_hasta_contratacion", typeof(string));
            dtMesesPorcentajes.Columns.Add("monto_contratacion", typeof(string));
            dtMesesPorcentajes.Columns.Add("tipo_contratacion", typeof(string));
            dtMesesPorcentajes.Columns.Add("detalle_contratacion", typeof(string));
            dtMesesPorcentajes.Columns.Add("id_usuarios_servicios_contratacion", typeof(string));
            dtMesesPorcentajes.Columns.Add("id_usuarios_servicios_sub_contratacion", typeof(string));
            dtMesesPorcentajes.Columns.Add("finaliza_contratacion", typeof(string));
            dtMesesPorcentajes.Columns.Add("facturable_contratacion", typeof(string));
            dtMesesPorcentajes.Columns.Add("id_tipo_contratacion", typeof(string));
            dtMesesPorcentajes.Columns.Add("imprime_contratacion", typeof(string));
            dtMesesPorcentajes.Columns.Add("cantidad_periodos_contratacion", typeof(string));
            dtMesesPorcentajes.Columns.Add("id_usuarios_contratacion", typeof(string));
            dtMesesPorcentajes.Columns.Add("id_usuarios_locaciones_contratacion", typeof(string));
            dtMesesPorcentajes.Columns.Add("id_servicios_contratacion", typeof(string));
            dtMesesPorcentajes.Columns.Add("id_servicios_sub_contratacion", typeof(string));
            //--------------------------------------------------------------------------------------------------

            //datos de la bonificación que se le aplicó-----------------------------------------
            DataColumn DcIdBonificacion = new DataColumn("id_bonificacion", typeof(string));
            DcIdBonificacion.DefaultValue = 0;
            dtMesesPorcentajes.Columns.Add(DcIdBonificacion);
            DataColumn DcNombreBonificacion = new DataColumn("nombre_bonificacion", typeof(string));
            DcNombreBonificacion.DefaultValue = 0;
            dtMesesPorcentajes.Columns.Add(DcNombreBonificacion);

            //importes y porcentajes-------------
            DataColumn DcImporteOriginal = new DataColumn("importe_original", typeof(string));
            DcImporteOriginal.DefaultValue = 0;
            dtMesesPorcentajes.Columns.Add(DcImporteOriginal);
            DataColumn DcPorcentaje = new DataColumn("porcentaje", typeof(string));
            DcPorcentaje.DefaultValue = 0;
            dtMesesPorcentajes.Columns.Add(DcPorcentaje);
            DataColumn DcImporteConDescuentoParcial = new DataColumn("importe_con_descuento_parcial", typeof(string));
            DcImporteConDescuentoParcial.DefaultValue = 0;
            dtMesesPorcentajes.Columns.Add(DcImporteConDescuentoParcial);
            DataColumn DcPorcentajeParcial = new DataColumn("porcentaje_parcial", typeof(string));
            DcPorcentajeParcial.DefaultValue = 0;
            dtMesesPorcentajes.Columns.Add(DcPorcentajeParcial);
            DataColumn DcPorcentajeContratacion = new DataColumn("porcentaje_contratacion", typeof(string));
            DcPorcentajeContratacion.DefaultValue = 0;
            dtMesesPorcentajes.Columns.Add(DcPorcentajeContratacion);
            DataColumn DcImporteConDescuento = new DataColumn("importe_con_descuento", typeof(string));
            DcImporteConDescuento.DefaultValue = 0;
            dtMesesPorcentajes.Columns.Add(DcImporteConDescuento);
            DataColumn DcIndice = new DataColumn("indice", typeof(Int32));
            DcIndice.DefaultValue = 0;
            dtMesesPorcentajes.Columns.Add(DcIndice);
            DataColumn DcSubServicio = new DataColumn("subservicio", typeof(string));
            DcSubServicio.DefaultValue = "";
            dtMesesPorcentajes.Columns.Add(DcSubServicio);
            DataColumn DcVelocidad = new DataColumn("velocidad", typeof(string));
            DcVelocidad.DefaultValue = "";
            dtMesesPorcentajes.Columns.Add(DcVelocidad);
            DataColumn DcVelocidadTipo = new DataColumn("velocidad_tipo", typeof(string));
            DcVelocidadTipo.DefaultValue = "";
            dtMesesPorcentajes.Columns.Add(DcVelocidadTipo);

            //---------------------------------------------------------------------
            return dtMesesPorcentajes;
        }

        public DataTable GenerarDtDatosNovedades()
        {
            DataTable dtNovedadesAGenerar = new DataTable();

            dtNovedadesAGenerar.Columns.Add("id_usuarios", typeof(string));
            dtNovedadesAGenerar.Columns.Add("id_usuarios_locaciones", typeof(string));
            dtNovedadesAGenerar.Columns.Add("id_servicios", typeof(string));
            dtNovedadesAGenerar.Columns.Add("id_servicios_sub", typeof(string));
            dtNovedadesAGenerar.Columns.Add("id_servicios_velocidades", typeof(string));
            dtNovedadesAGenerar.Columns.Add("id_servicios_velocidades_tip", typeof(string));
            dtNovedadesAGenerar.Columns.Add("fecha_desde", typeof(string));
            dtNovedadesAGenerar.Columns.Add("fecha_hasta", typeof(string));
            dtNovedadesAGenerar.Columns.Add("porcentaje", typeof(string));
            dtNovedadesAGenerar.Columns.Add("monto", typeof(string));
            dtNovedadesAGenerar.Columns.Add("tipo", typeof(string));
            dtNovedadesAGenerar.Columns.Add("detalle", typeof(string));
            dtNovedadesAGenerar.Columns.Add("id_usuarios_servicios", typeof(string));
            dtNovedadesAGenerar.Columns.Add("id_usuarios_servicios_sub", typeof(string));
            dtNovedadesAGenerar.Columns.Add("finaliza", typeof(string));
            dtNovedadesAGenerar.Columns.Add("facturable", typeof(string));
            dtNovedadesAGenerar.Columns.Add("id_tipo", typeof(string));
            dtNovedadesAGenerar.Columns.Add("imprime", typeof(string));
            dtNovedadesAGenerar.Columns.Add("nivel_aplicacion", typeof(string));
            dtNovedadesAGenerar.Columns.Add("id_bonificacion", typeof(string));
            return dtNovedadesAGenerar;
        }

        public bool TraerImportesOriginales(int IdTarifa, DataTable DtSubServicios)
        {
            bool respuesta = false;
            Servicios_Tarifas_Sub oServiciosTarifasSub = new Servicios_Tarifas_Sub();
            decimal importeOriginal = 0;
            decimal MontoIpFija = 0;
            try
            {
                MontoIpFija = oConfig.GetValor_N("Costo_IP");
            }
            catch
            {
                MontoIpFija = 0;
            }


            try
            {
                foreach (DataRow fila in DtSubServicios.Rows)
                {
                    importeOriginal = 0;
                    try
                    {
                        importeOriginal = Decimal.Round(Convert.ToDecimal(oServiciosTarifasSub.ObtienePrecio(IdTarifa, Convert.ToInt32(fila["id_tipo_facturacion"]), Convert.ToInt32(fila["id_servicio"]), Convert.ToInt32(fila["id_servicio_sub"]), Convert.ToInt32(fila["id_velocidad"]), Convert.ToInt32(fila["id_velocidad_tipo"]), fila["tipo_servicio_sub"].ToString(), Convert.ToInt32(fila["id_servicios_tarifas_sub_esp"])).Rows[0]["importe"]), Convert.ToInt16(oConfig.GetValor_N("Cantidad_Decimales")));

                    }
                    catch
                    {
                        importeOriginal = 0;
                    }
                    if (fila["tipo_servicio_sub"].ToString() == "S")
                    {
                        if(oConfig.GetValor_N("CobroIp")==1)//si la ip se cobra un monto fijo, entonces de la tarifa que queda al sub se le suma el importe fijo de la ip
                        {
                            if (Convert.ToInt32(fila["id_tipo_de_sub"]) == Convert.ToInt32(Servicios_Sub.SERVICIO_SUB_TIPOS.SUBSERVICIO) && Convert.ToInt32(fila["id_ip_fija"]) != 0 && Convert.ToInt32(fila["heredado"]) != 1)
                                importeOriginal += MontoIpFija;
                        }
                    }
                    if (fila["tipo_servicio_sub"].ToString() == "S")
                    {
                        if (Convert.ToInt32(fila["id_tipo_de_sub"]) != Convert.ToInt32(Servicios_Sub.SERVICIO_SUB_TIPOS.DERECHO_DE_CONEXION))
                        {
                            if (Convert.ToInt32(fila["id_servicio_modalidad"]) != Convert.ToInt32(Servicios._Modalidad.DIA))
                                fila["importe_original"] = Convert.ToDecimal(importeOriginal) * Convert.ToDecimal(fila["cant_bocas_pac"]);
                            else
                                fila["importe_original"] = 0;
                        }
                        else
                        {
                            fila["importe_original"] = importeOriginal;
                            fila["cant_bocas_pac"] = 1;
                            fila["meses_cobro"] = 1;
                            fila["meses_servicio"] = 1;
                        }
                    }
                    else
                    {
                        if (fila["tipo_servicio_sub"].ToString() == "P")
                        {
                            fila["importe_original"] = importeOriginal;
                            fila["cant_bocas_pac"] = 1;
                        }
                        else
                        {
                            fila["importe_original"] = Convert.ToDecimal(importeOriginal) * Convert.ToDecimal(fila["cant_bocas_pac"]);
                        }
                        fila["meses_cobro"] = 1;
                        fila["meses_servicio"] = 1;
                    }
                    fila["importe_con_descuento"] = fila["importe_original"];
                }
                respuesta = true;
            }
            catch
            {
                respuesta = false;
            }
            DtSubServicios.AcceptChanges();
            return respuesta;
        }

        public bool SetearFechasYModalidadVacios(DataTable dtSubServicios)
        {
            bool respuesta = false;
            string fechaInicioServicio = String.Empty;
            string fechaHastaServicio = String.Empty;
            string idServiciosModalidad = String.Empty;
            List<int> listaUsuariosServicios = new List<int>();
            DataRow[] drUsuariosServiciosSub;
            DataTable dtUsuariosServicios = new DataTable();

            dtUsuariosServicios.Columns.Add("id_usuarios_servicios", typeof(string));
            dtUsuariosServicios.Columns.Add("fecha_inicio_servicio", typeof(string));
            dtUsuariosServicios.Columns.Add("fecha_hasta_servicio", typeof(string));
            dtUsuariosServicios.Columns.Add("id_servicios_modalidad", typeof(string));
            try
            {
                foreach (DataRow fila in dtSubServicios.Rows)
                {
                    if (fila["tipo_servicio_sub"].ToString() != "S" || (fila["tipo_servicio_sub"].ToString() == "S" && Convert.ToInt32(fila["id_tipo_de_sub"]) == Convert.ToInt32(Servicios_Sub.SERVICIO_SUB_TIPOS.DERECHO_DE_CONEXION)))
                    {
                        fila["meses_cobro"] = 1;
                        fila["meses_servicio"] = 1;
                    }

                    if (listaUsuariosServicios.Contains(Convert.ToInt32(fila["id_usuario_servicio"])) == false)
                        listaUsuariosServicios.Add(Convert.ToInt32(fila["id_usuario_servicio"]));
                    dtSubServicios.AcceptChanges();
                }
                foreach (int idUsuariosServicios in listaUsuariosServicios)
                {
                    fechaInicioServicio = String.Empty;
                    fechaHastaServicio = String.Empty;
                    idServiciosModalidad = String.Empty;
                    drUsuariosServiciosSub = dtSubServicios.Select(String.Format("id_usuario_servicio={0}", idUsuariosServicios));
                    foreach (DataRow usuariosServiciosSub in drUsuariosServiciosSub)
                    {
                        if (usuariosServiciosSub["fecha_inicio_servicio"].ToString() != String.Empty)
                            fechaInicioServicio = usuariosServiciosSub["fecha_inicio_servicio"].ToString();
                        if (usuariosServiciosSub["fecha_hasta_servicio"].ToString() != String.Empty)
                            fechaHastaServicio = usuariosServiciosSub["fecha_hasta_servicio"].ToString();
                        if (usuariosServiciosSub["id_servicio_modalidad"].ToString() != String.Empty)
                            idServiciosModalidad = usuariosServiciosSub["id_servicio_modalida"].ToString();
                        if (fechaInicioServicio != String.Empty && fechaHastaServicio != String.Empty && idServiciosModalidad != String.Empty)
                            break;
                    }
                    dtUsuariosServicios.Rows.Add(idUsuariosServicios, fechaInicioServicio, fechaHastaServicio, idServiciosModalidad);
                }

                foreach (DataRow usuarioServicio in dtUsuariosServicios.Rows)
                {
                    foreach (DataRow usuariosServiciosSub in dtSubServicios.Rows)
                    {
                        if (Convert.ToInt32(usuariosServiciosSub["id_usuario_servicio"]) == Convert.ToInt32(usuarioServicio["id"]))
                        {
                            usuariosServiciosSub["fecha_inicio_servicio"] = usuarioServicio["fecha_inicio_servicio"];
                            usuariosServiciosSub["fecha_hasta_servicio"] = usuarioServicio["fecha_inicio_servicio"];
                            usuariosServiciosSub["id_servicio_modalidad"] = usuarioServicio["id_servicios_modalidad"];
                            dtSubServicios.AcceptChanges();
                        }
                    }
                }
                respuesta = true;
            }
            catch
            {
                respuesta = false;
            }
            return respuesta;
        }

        private void ContarCantidadServicios(DataTable dtSubServicios, DataTable dtListadoDeServicios, int cantidadServicios, List<int> listaServiciosEncontrados)
        {
            List<int> listaControl = new List<int>();
            foreach (DataRow fila in dtSubServicios.Rows)
            {
                listaServiciosEncontrados.Clear();
                cantidadServicios = 0;

                if (listaControl.Contains(Convert.ToInt32(fila["id_servicio"])) == false)
                {
                    foreach (DataRow filaSubServicio in dtSubServicios.Rows)
                    {
                        if (Convert.ToInt32(filaSubServicio["id_servicio"]) == Convert.ToInt32(fila["id_servicio"]) && listaServiciosEncontrados.Contains(Convert.ToInt32(filaSubServicio["id_usuario_servicio"])) == false)
                        {
                            listaServiciosEncontrados.Add(Convert.ToInt32(filaSubServicio["id_usuario_servicio"]));
                            if ((Convert.ToInt32(filaSubServicio["cant_bocas_pac"]) == 0) || (Convert.ToInt32(filaSubServicio["cant_bocas_pac"]) == 1))
                                cantidadServicios++;
                            else
                                cantidadServicios = cantidadServicios + Convert.ToInt32(filaSubServicio["cant_bocas_pac"]);
                        }
                    }
                    listaControl.Add(Convert.ToInt32(fila["id_servicio"]));
                    dtListadoDeServicios.Rows.Add(fila["id_grupo"], fila["id_servicio_tipo"], fila["id_servicio"], cantidadServicios);
                }
            }
        }

        private void ControlarCondicionesBonificacion(DataRow[] drBonificacionCondiciones, DataTable dtListadoDeServicios, DataTable dtSubServicios, List<int> listaCondicionesCumplidas, int tipoBonificacion, DataRow filaAplicacion)
        {

            bool cumpleCondicion = false;
            int cantidadItems = 0;
            DataRow[] drServiciosEncontrados;
            listaCondicionesCumplidas.Clear();
            foreach (DataRow filaCondicion in drBonificacionCondiciones)
            {
                cumpleCondicion = false;
                cantidadItems = 0;

                if (Convert.ToInt32(filaCondicion["nivel"]) == Convert.ToInt32(NIVEL.GRUPO))
                {
                    drServiciosEncontrados = dtListadoDeServicios.Select(String.Format("id_grupo='{0}'", filaCondicion["id_item"]));
                    foreach (DataRow servicio in drServiciosEncontrados)
                        cantidadItems = cantidadItems + Convert.ToInt32(servicio["cantidad"]);
                }
                else if (Convert.ToInt32(filaCondicion["nivel"]) == Convert.ToInt32(NIVEL.TIPO_SERVICIO))
                {
                    drServiciosEncontrados = dtListadoDeServicios.Select(String.Format("id_tipo='{0}'", filaCondicion["id_item"]));

                    foreach (DataRow servicio in drServiciosEncontrados)
                        cantidadItems = cantidadItems + Convert.ToInt32(servicio["cantidad"]);
                }
                else if (Convert.ToInt32(filaCondicion["nivel"]) == Convert.ToInt32(NIVEL.SERVICIO))
                {
                    if (dtListadoDeServicios.Select(String.Format("id_servicio='{0}'", filaCondicion["id_item"])).Length > 0 && Convert.ToInt32(dtListadoDeServicios.Select(String.Format("id_servicio='{0}'", filaCondicion["id_item"]))[0]["cantidad"]) >= Convert.ToInt32(filaCondicion["cantidad"]))
                        cantidadItems = Convert.ToInt32(dtListadoDeServicios.Select(String.Format("id_servicio='{0}'", filaCondicion["id_item"]))[0]["cantidad"]);
                }
                else if (Convert.ToInt32(filaCondicion["nivel"]) == Convert.ToInt32(NIVEL.SUBSERVICIO))
                {
                    //MessageBox.Show("id item " + filaCondicion["id_item"].ToString());
                    foreach (DataRow fila in dtSubServicios.Rows)
                    {
                        if (Convert.ToInt32(fila["id_servicio_sub"]) == Convert.ToInt32(filaCondicion["id_item"]) && fila["tipo_servicio_sub"].ToString() == filaCondicion["tipo_servicio_sub"].ToString())
                            cantidadItems += Convert.ToInt32(fila["cant_bocas_pac"]);
                    }
                }

                if (tipoBonificacion == Convert.ToInt32(Bonificaciones.TIPO_BONIFICACION.COMBINACION))
                {
                    //if ((Convert.ToInt32(filaCondicion["nivel"]) == Convert.ToInt32(NIVEL.GRUPO) && Convert.ToInt32(filaCondicion["id_item"]) == Convert.ToInt32(filaAplicacion["id_grupo"]))
                    //   ||
                    //   (Convert.ToInt32(filaCondicion["nivel"]) == Convert.ToInt32(NIVEL.TIPO_SERVICIO) && Convert.ToInt32(filaCondicion["id_item"]) == Convert.ToInt32(filaAplicacion["id_tipo_servicio"]))
                    //   ||
                    //   (Convert.ToInt32(filaCondicion["nivel"]) == Convert.ToInt32(NIVEL.SERVICIO) && Convert.ToInt32(filaCondicion["id_item"]) == Convert.ToInt32(filaAplicacion["id_servicio"]))
                    //   ||
                    //   (Convert.ToInt32(filaCondicion["nivel"]) == Convert.ToInt32(NIVEL.SUBSERVICIO) && Convert.ToInt32(filaCondicion["id_item"]) == Convert.ToInt32(filaAplicacion["id_servicio_sub"]) && filaCondicion["tipo_servicio_sub"].ToString() == filaAplicacion["tipo_servicio_sub"].ToString())
                    //   ) 
                    //{
                    //    if(cantidadItems > Convert.ToInt32(filaCondicion["cantidad"]))
                    //        cumpleCondicion = true;
                    //}
                    //else 

                    if (cantidadItems >= Convert.ToInt32(filaCondicion["cantidad"]))
                        cumpleCondicion = true;
                }
                else if (tipoBonificacion == Convert.ToInt32(Bonificaciones.TIPO_BONIFICACION.REPETICION) && cantidadItems >= Convert.ToInt32(filaCondicion["cantidad"]))
                    cumpleCondicion = true;
                if (cumpleCondicion == true)
                    listaCondicionesCumplidas.Add(Convert.ToInt32(filaCondicion["id"]));
            }
        }

        public DataTable GenerarTablaRegistrosCtaCteDet(DataTable dtSubServicios)
        {
            //debe generar los registros para luego generar los detalles de ctactedet
            int mesesCobro = 0;
            int mesesServicio = 0;
            int idServiciosModalidad = 0;
            DateTime fechaInicio = new DateTime();
            DateTime fechaHasta = new DateTime();
            DataRow filaAgregar;
            DataTable dtRegistros = new DataTable();

            dtRegistros = GenerarDtMesesPorcentajes();

            foreach (DataRow subServicio in dtSubServicios.Rows)
            {
                if (Convert.ToInt32(subServicio["heredado"]) == 0)
                {
                    idServiciosModalidad = 0;
                    mesesCobro = 0;
                    mesesServicio = 0;
                    idServiciosModalidad = Convert.ToInt32(subServicio["id_servicio_modalidad"]);
                    fechaInicio = Convert.ToDateTime(subServicio["fecha_inicio_servicio"]);
                    //fechaHasta= Convert.ToDateTime(subServicio["fecha_hasta_servicio"]);

                    if (idServiciosModalidad == Convert.ToInt32(Servicios._Modalidad.MENSUAL))
                    {
                        filaAgregar = dtRegistros.NewRow();
                        filaAgregar["id_usuarios_servicios"] = subServicio["id_usuario_servicio"];
                        filaAgregar["id_usuarios_servicios_sub"] = subServicio["id_usuario_servicio_sub"];
                        filaAgregar["id_usuarios_locaciones"] = subServicio["id_usuarios_locaciones"];
                        filaAgregar["nro_mes"] = fechaInicio.Month;
                        filaAgregar["meses_cobro"] = subServicio["meses_cobro"];
                        filaAgregar["meses_servicio"] = subServicio["meses_servicio"];
                        filaAgregar["fecha_desde"] = fechaInicio.ToString();
                        if (fechaInicio.Month == 12)
                            filaAgregar["fecha_hasta"] = new DateTime(fechaInicio.Year, 12, 31);
                        else
                            filaAgregar["fecha_hasta"] = new DateTime(fechaInicio.Year, fechaInicio.Month + 1, 1).AddDays(-1);
                        filaAgregar["id_servicios"] = Convert.ToInt32(subServicio["id_servicio"]);
                        filaAgregar["id_usuarios_servicios_sub_tipos"] = Convert.ToInt32(subServicio["id_tipo_de_sub"]);
                        filaAgregar["tipo_servicio_sub"] = subServicio["tipo_servicio_sub"];
                        filaAgregar["requiere_ip"] = Convert.ToInt32(subServicio["requiere_ip"]);
                        filaAgregar["id_servicios_velocidades"] = Convert.ToInt32(subServicio["id_velocidad"]);
                        filaAgregar["id_servicios_velocidades_tipos"] = Convert.ToInt32(subServicio["id_velocidad_tipo"]);
                        filaAgregar["borrado"] = 0;
                        filaAgregar["id_servicios_modalidad"] = subServicio["id_servicio_modalidad"].ToString();

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
                        filaAgregar["id_usuarios_servicios_sub_contratacion"] = 0;
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
                        filaAgregar["importe_original"] = Decimal.Round(Convert.ToDecimal(subServicio["importe_original"]), Convert.ToInt16(oConfig.GetValor_N("Cantidad_Decimales")));
                        filaAgregar["porcentaje"] = 0;
                        filaAgregar["importe_con_descuento_parcial"] = filaAgregar["importe_original"];
                        filaAgregar["porcentaje_parcial"] = 0;
                        filaAgregar["porcentaje_contratacion"] = 0;
                        filaAgregar["importe_con_descuento"] = filaAgregar["importe_original"];
                        dtRegistros.Rows.Add(filaAgregar);
                    }
                    else if (idServiciosModalidad == Convert.ToInt32(Servicios._Modalidad.PERIODO))
                    {
                        DateTime aux;


                        mesesCobro = Convert.ToInt32(subServicio["meses_cobro"]);
                        mesesServicio = Convert.ToInt32(subServicio["meses_servicio"]);

                        for (int x = 0; x < mesesCobro; x++)
                        {
                            filaAgregar = dtRegistros.NewRow();
                            filaAgregar["id_usuarios_servicios"] = subServicio["id_usuario_servicio"];
                            filaAgregar["id_usuarios_servicios_sub"] = subServicio["id_usuario_servicio_sub"];
                            filaAgregar["id_usuarios_locaciones"] = subServicio["id_usuarios_locaciones"];
                            filaAgregar["nro_mes"] = fechaInicio.Month;
                            filaAgregar["meses_cobro"] = subServicio["meses_cobro"];
                            filaAgregar["meses_servicio"] = subServicio["meses_servicio"];
                            filaAgregar["fecha_desde"] = fechaInicio.ToString();
                            if (subServicio["tipo_servicio_sub"].ToString() == "S")
                            {
                                if (x == (mesesCobro - 1))
                                    filaAgregar["fecha_hasta"] = fechaInicio.AddMonths((mesesServicio - mesesCobro) + 1).AddDays(-1);
                                else
                                    filaAgregar["fecha_hasta"] = fechaInicio.AddMonths(1).AddDays(-1);
                            }
                            else
                                filaAgregar["fecha_hasta"] = fechaInicio.AddMonths(1).AddDays(-1);
                            filaAgregar["id_servicios"] = Convert.ToInt32(subServicio["id_servicio"]);
                            filaAgregar["id_usuarios_servicios_sub_tipos"] = Convert.ToInt32(subServicio["id_tipo_de_sub"]);
                            filaAgregar["tipo_servicio_sub"] = subServicio["tipo_servicio_sub"];
                            filaAgregar["requiere_ip"] = Convert.ToInt32(subServicio["requiere_ip"]);
                            filaAgregar["id_servicios_velocidades"] = Convert.ToInt32(subServicio["id_velocidad"]);
                            filaAgregar["id_servicios_velocidades_tipos"] = Convert.ToInt32(subServicio["id_velocidad_tipo"]);
                            filaAgregar["borrado"] = 0;
                            filaAgregar["id_servicios_modalidad"] = subServicio["id_servicio_modalidad"].ToString();

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
                            filaAgregar["id_usuarios_servicios_sub_contratacion"] = 0;
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
                            filaAgregar["importe_original"] = Decimal.Round(Convert.ToDecimal(subServicio["importe_original"]), Convert.ToInt16(oConfig.GetValor_N("Cantidad_Decimales")));
                            filaAgregar["porcentaje"] = 0;
                            filaAgregar["importe_con_descuento_parcial"] = filaAgregar["importe_original"];
                            filaAgregar["porcentaje_parcial"] = 0;
                            filaAgregar["porcentaje_contratacion"] = 0;
                            filaAgregar["importe_con_descuento"] = filaAgregar["importe_original"];
                            dtRegistros.Rows.Add(filaAgregar);
                            fechaInicio = fechaInicio.AddMonths(1);
                        }

                    }
                    else if (idServiciosModalidad == Convert.ToInt32(Servicios._Modalidad.DIA) || idServiciosModalidad == Convert.ToInt32(Servicios._Modalidad.PERIODO_CERRADO_POR_DIA) || idServiciosModalidad == Convert.ToInt32(Servicios._Modalidad.PERIODO_CERRADO_POR_MES))
                    {
                        filaAgregar = dtRegistros.NewRow();
                        filaAgregar["id_usuarios_servicios"] = subServicio["id_usuario_servicio"];
                        filaAgregar["id_usuarios_servicios_sub"] = subServicio["id_usuario_servicio_sub"];
                        filaAgregar["id_usuarios_locaciones"] = subServicio["id_usuarios_locaciones"];
                        filaAgregar["nro_mes"] = fechaInicio.Month;
                        filaAgregar["meses_cobro"] = subServicio["meses_cobro"];
                        filaAgregar["meses_servicio"] = subServicio["meses_servicio"];
                        filaAgregar["fecha_desde"] = fechaInicio.ToString();
                        filaAgregar["fecha_hasta"] = subServicio["fecha_hasta_servicio"];
                        filaAgregar["id_servicios"] = Convert.ToInt32(subServicio["id_servicio"]);
                        filaAgregar["id_usuarios_servicios_sub_tipos"] = Convert.ToInt32(subServicio["id_tipo_de_sub"]);
                        filaAgregar["tipo_servicio_sub"] = subServicio["tipo_servicio_sub"];
                        filaAgregar["requiere_ip"] = Convert.ToInt32(subServicio["requiere_ip"]);
                        filaAgregar["id_servicios_velocidades"] = Convert.ToInt32(subServicio["id_velocidad"]);
                        filaAgregar["id_servicios_velocidades_tipos"] = Convert.ToInt32(subServicio["id_velocidad_tipo"]);
                        filaAgregar["borrado"] = 0;
                        filaAgregar["id_servicios_modalidad"] = subServicio["id_servicio_modalidad"].ToString();

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
                        filaAgregar["id_usuarios_servicios_sub_contratacion"] = 0;
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
                        filaAgregar["importe_original"] = Decimal.Round(Convert.ToDecimal(subServicio["importe_original"]), Convert.ToInt16(oConfig.GetValor_N("Cantidad_Decimales")));
                        filaAgregar["porcentaje"] = 0;
                        filaAgregar["importe_con_descuento_parcial"] = filaAgregar["importe_original"];
                        filaAgregar["porcentaje_parcial"] = 0;
                        filaAgregar["porcentaje_contratacion"] = 0;
                        filaAgregar["importe_con_descuento"] = filaAgregar["importe_original"];
                        dtRegistros.Rows.Add(filaAgregar);
                    }
                }
            }
            return dtRegistros;
        }

        public void AgregarMontoIpFija(DataTable DtSubServicios, DataTable dtMesesPorcentajes)
        {
            decimal MontoIpFija = 0;
            try
            {
                if (oConfig.GetValor_N("CobroIp") == 1)
                    MontoIpFija = oConfig.GetValor_N("Costo_IP");
                else
                    MontoIpFija = 0;
            }
            catch
            {
                MontoIpFija = 0;
            }

            try
            {
                foreach (DataRow SubServicio in DtSubServicios.Rows)
                {
                    if (Convert.ToInt32(SubServicio["id_tipo_de_sub"]) == Convert.ToInt32(Servicios_Sub.SERVICIO_SUB_TIPOS.SUBSERVICIO) && Convert.ToInt32(SubServicio["id_ip_fija"]) != 0 && Convert.ToInt32(SubServicio["heredado"]) != 1)
                    {
                        foreach (DataRow mes in dtMesesPorcentajes.Select(String.Format("id_usuarios_servicios_sub={0}", SubServicio["id_usuario_servicio_sub"].ToString())))
                        {
                            mes["importe_con_descuento"] = Decimal.Round(Convert.ToDecimal(mes["importe_con_descuento"]) + MontoIpFija, Convert.ToInt16(oConfig.GetValor_N("Cantidad_Decimales")));
                            mes["importe_original"] = Decimal.Round(Convert.ToDecimal(mes["importe_original"]) + MontoIpFija, Convert.ToInt16(oConfig.GetValor_N("Cantidad_Decimales")));
                            mes["importe_con_descuento_parcial"] = Decimal.Round(Convert.ToDecimal(mes["importe_con_descuento_parcial"]) + MontoIpFija, Convert.ToInt16(oConfig.GetValor_N("Cantidad_Decimales")));
                            dtMesesPorcentajes.AcceptChanges();
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("Error al adicionar importe de Ip fija.");
            }
        }

        public bool CalcularBonificaciones(DataTable DtSubServicios, int idTarifaRecibida, bool emplearBonificacionesContratacion, int mensajeError = 0, bool facMensual = false)
        {
            int idEnumGrupo, idEnumTipo, idEnumServicio, idEnumSubServicio, CantidadServicios, id_usuario_servicio_sub, idTipoFacturacionConfig, contemplarSoloEspeciales;
            decimal importeOriginalTotal, importeConDescuentoTotal, porcentajeTotal, sumatoriaMontoConDescuento, sumatoriaDescuento;
            bool sinErrores = true, presentaEspeciales = false;
            string consultaBonificacionMemoria = String.Empty;
            List<int> ListaServiciosEncontrados = new List<int>();
            List<int> ListaCondicionesCumplidas = new List<int>();
            List<int> listaUsuariosServiciosSub = new List<int>();
            List<int> listaUsuariosServicios = new List<int>();
            DateTime fechaInicio = new DateTime();
            DateTime fechaInicioAuxiliar = new DateTime();
            DateTime fechaFin = new DateTime();
            DateTime fechaLimiteDesde = new DateTime();
            DateTime fechaLimiteHasta = new DateTime();
            DataRow filaAgregar;
            DataRow filaEliminar;
            DataRow[] drMontosMensualesSubServicio;
            DataRow[] DrBonificacionAplicacion;
            DataRow[] DrBonificacionCondiciones;
            DataRow[] DrCondicionesPorcentajes;
            DataRow[] drFiltro;
            DataTable DtBonificacionAplicacionAuxiliar = new DataTable();
            DataTable DtAplicacionCondicionesAuxiliar = new DataTable();
            DataTable DtListadoDeServicios = new DataTable();
            DataTable dtBonificacionesAuxiliar = new DataTable();
            DataTable dtAplicacionPorcentajes = new DataTable();
            DataTable dtMesesPorcentajes = new DataTable();
            DataTable dtDatosNovedadesInternas = new DataTable();
            Bonificaciones_Aplicacion_Condiciones oBonificacionCondiciones = new Bonificaciones_Aplicacion_Condiciones();
            Bonificaciones_Condiciones_Porcentaje oCondicionesPorcentajes = new Bonificaciones_Condiciones_Porcentaje();
            Configuracion oConfig = new Configuracion();

            idTipoFacturacionConfig = oConfig.GetValor_N("Id_Tipo_Facturacion");
            contemplarSoloEspeciales = oConfig.GetValor_N("BonifSoloEspeciales");

            DtBonificacionAplicacionAuxiliar.Columns.Add("id", typeof(string));
            DtBonificacionAplicacionAuxiliar.Columns.Add("id_tipo_facturacion", typeof(string));
            DtBonificacionAplicacionAuxiliar.Columns.Add("id_localidad", typeof(string));
            DtBonificacionAplicacionAuxiliar.Columns.Add("id_item", typeof(string));
            DtBonificacionAplicacionAuxiliar.Columns.Add("nivel", typeof(string));
            DtBonificacionAplicacionAuxiliar.Columns.Add("id_velocidad", typeof(string));
            DtBonificacionAplicacionAuxiliar.Columns.Add("id_velocidad_tipo", typeof(string));
            DtBonificacionAplicacionAuxiliar.Columns.Add("tipo_servicio_sub", typeof(string));
            DtBonificacionAplicacionAuxiliar.Columns.Add("porcentaje", typeof(string));
            DtBonificacionAplicacionAuxiliar.Columns.Add("tipo_bonificacion", typeof(string));
            DtBonificacionAplicacionAuxiliar.Columns.Add("nombre_bonificacion", typeof(string));
            DtBonificacionAplicacionAuxiliar.Columns.Add("id_bonificacion", typeof(string));
            DtBonificacionAplicacionAuxiliar.Columns.Add("id_grupo", typeof(string));
            DtBonificacionAplicacionAuxiliar.Columns.Add("id_tipo_servicio", typeof(string));
            DtBonificacionAplicacionAuxiliar.Columns.Add("id_servicio", typeof(string));
            DtBonificacionAplicacionAuxiliar.Columns.Add("id_servicio_sub", typeof(string));
            DtBonificacionAplicacionAuxiliar.Columns.Add("por_contratacion", typeof(string));
            DtBonificacionAplicacionAuxiliar.Columns.Add("cantidad_periodos", typeof(string));
            DtBonificacionAplicacionAuxiliar.Columns.Add("fecha_desde", typeof(string));
            DtBonificacionAplicacionAuxiliar.Columns.Add("fecha_hasta", typeof(string));


            DtListadoDeServicios.Columns.Add("id_grupo", typeof(string));
            DtListadoDeServicios.Columns.Add("id_tipo", typeof(string));
            DtListadoDeServicios.Columns.Add("id_servicio", typeof(string));
            DtListadoDeServicios.Columns.Add("cantidad", typeof(string));

            dtAplicacionPorcentajes.Columns.Add("id_usuario_servicio", typeof(string));
            dtAplicacionPorcentajes.Columns.Add("id_usuario_servicio_sub", typeof(string));
            dtAplicacionPorcentajes.Columns.Add("id_tipo_facturacion", typeof(string));
            dtAplicacionPorcentajes.Columns.Add("id_servicio_sub", typeof(string));
            dtAplicacionPorcentajes.Columns.Add("id_velocidad", typeof(string));
            dtAplicacionPorcentajes.Columns.Add("id_velocidad_tipo", typeof(string));
            dtAplicacionPorcentajes.Columns.Add("tipo_servicio_sub", typeof(string));
            dtAplicacionPorcentajes.Columns.Add("nro_item", typeof(string));
            dtAplicacionPorcentajes.Columns.Add("importe_original", typeof(string));
            dtAplicacionPorcentajes.Columns.Add("porcentaje", typeof(string));
            dtAplicacionPorcentajes.Columns.Add("importe_descuento", typeof(string));
            dtAplicacionPorcentajes.Columns.Add("index_subservicio_tabla_principal", typeof(string));

            try
            {
                idEnumGrupo = 0;
                idEnumGrupo = Convert.ToInt32(NIVEL.GRUPO);
                idEnumTipo = Convert.ToInt32(NIVEL.TIPO_SERVICIO);
                idEnumServicio = Convert.ToInt32(NIVEL.SERVICIO);
                idEnumSubServicio = Convert.ToInt32(NIVEL.SUBSERVICIO);
                CantidadServicios = 0;

                SetearFechasYModalidadVacios(DtSubServicios);
                TraerImportesOriginales(idTarifaRecibida, DtSubServicios);
                ContarCantidadServicios(DtSubServicios, DtListadoDeServicios, CantidadServicios, ListaServiciosEncontrados);
                dtMesesPorcentajes = GenerarDtMesesPorcentajes();
                dtMesesPorcentajes = GenerarTablaRegistrosCtaCteDet(DtSubServicios);
                AplicarBonificacionesEspeciales(DtSubServicios, dtMesesPorcentajes);

                if (DtSubServicios.Select("id_bonificacion_especial>0 and heredado<>1").Count() > 0)
                    presentaEspeciales = true;
                else
                    presentaEspeciales = false;


                if ((presentaEspeciales && contemplarSoloEspeciales == Convert.ToInt16(CONTEMPLAR_SOLO_ESPECIALES.NO)) || presentaEspeciales == false)
                {
                    foreach (DataRow fila in DtSubServicios.Rows)
                    {//recorre cada subservicio del datatable recibido
                        foreach (NIVEL nivel in Enum.GetValues(typeof(NIVEL)))
                        {//controlar la existencia de bonificaciones a nivel GRUPO-TIPO-SERVICIO-SUBSERVICIO para el subservicio que está recorriendo
                            consultaBonificacionMemoria = String.Empty;

                            if (Convert.ToInt32(nivel) == idEnumGrupo)
                                consultaBonificacionMemoria = String.Format("id_tipo_facturacion='{0}' and id_item='{1}' and nivel='{2}'", fila["id_tipo_facturacion"], fila["id_grupo"], Convert.ToInt32(NIVEL.GRUPO));
                            else if (Convert.ToInt32(nivel) == idEnumTipo)
                                consultaBonificacionMemoria = String.Format("id_tipo_facturacion='{0}' and id_item='{1}' and nivel='{2}'", fila["id_tipo_facturacion"], fila["id_servicio_tipo"], Convert.ToInt32(NIVEL.TIPO_SERVICIO));
                            else if (Convert.ToInt32(nivel) == idEnumServicio)
                                consultaBonificacionMemoria = String.Format("id_tipo_facturacion='{0}' and id_item='{1}' and nivel='{2}'", fila["id_tipo_facturacion"], fila["id_servicio"], Convert.ToInt32(NIVEL.SERVICIO));
                            else if (Convert.ToInt32(nivel) == idEnumSubServicio)
                                consultaBonificacionMemoria = String.Format("id_tipo_facturacion='{0}' and id_item='{1}' and nivel='{2}' and id_velocidad='{3}' and id_velocidad_tipo='{4}' and tipo_servicio_sub='{5}'", fila["id_tipo_facturacion"], fila["id_servicio_sub"], Convert.ToInt32(NIVEL.SUBSERVICIO), fila["id_velocidad"], fila["id_velocidad_tipo"], fila["tipo_servicio_sub"]);

                            DrBonificacionAplicacion = DtBonificacionAplicacionAuxiliar.Select(consultaBonificacionMemoria);//busca bonificaciones en la tabla en memoria

                            if (DrBonificacionAplicacion.Count() == 0)
                            {//si no están en memoria, las va a buscar a la base, trayendo o no las de contratación también
                                if (Convert.ToInt32(nivel) == idEnumGrupo)
                                    DrBonificacionAplicacion = TraerDatosBonificacionAplicacion(Convert.ToInt32(fila["id_tipo_facturacion"]), Convert.ToInt32(fila["id_grupo"]), Convert.ToInt32(NIVEL.GRUPO), 0, 0, "0", emplearBonificacionesContratacion).Select("id>0");
                                else if (Convert.ToInt32(nivel) == idEnumTipo)
                                    DrBonificacionAplicacion = TraerDatosBonificacionAplicacion(Convert.ToInt32(fila["id_tipo_facturacion"]), Convert.ToInt32(fila["id_servicio_tipo"]), Convert.ToInt32(NIVEL.TIPO_SERVICIO), 0, 0, "0", emplearBonificacionesContratacion).Select("id>0");
                                else if (Convert.ToInt32(nivel) == idEnumServicio)
                                    DrBonificacionAplicacion = TraerDatosBonificacionAplicacion(Convert.ToInt32(fila["id_tipo_facturacion"]), Convert.ToInt32(fila["id_servicio"]), Convert.ToInt32(NIVEL.SERVICIO), 0, 0, "0", emplearBonificacionesContratacion).Select("id>0");
                                else if (Convert.ToInt32(nivel) == idEnumSubServicio)
                                    DrBonificacionAplicacion = TraerDatosBonificacionAplicacion(Convert.ToInt32(fila["id_tipo_facturacion"]), Convert.ToInt32(fila["id_servicio_sub"]), Convert.ToInt32(NIVEL.SUBSERVICIO), Convert.ToInt32(fila["id_velocidad"]), Convert.ToInt32(fila["id_velocidad_tipo"]), fila["tipo_servicio_sub"].ToString(), emplearBonificacionesContratacion).Select("id>0");

                                if (DrBonificacionAplicacion.Count() > 0)
                                {//si están en la base las agrega a la tabla en memoria.
                                    consultaBonificacionMemoria = String.Empty;
                                    foreach (DataRow filaAplicacion in DrBonificacionAplicacion)
                                        DtBonificacionAplicacionAuxiliar.Rows.Add(filaAplicacion["id"], filaAplicacion["id_tipo_facturacion"], filaAplicacion["id_localidad"], filaAplicacion["id_item"], filaAplicacion["nivel"], filaAplicacion["id_velocidad"], filaAplicacion["id_velocidad_tipo"], filaAplicacion["tipo_servicio_sub"], filaAplicacion["porcentaje"], filaAplicacion["tipo_bonificacion"], filaAplicacion["nombre"], filaAplicacion["id_bonificacion"], filaAplicacion["id_grupo"], filaAplicacion["id_tipo_servicio"], filaAplicacion["id_servicio"], filaAplicacion["id_servicio_sub"], filaAplicacion["por_contratacion"], filaAplicacion["cantidad_periodos"], filaAplicacion["fecha_desde"], filaAplicacion["fecha_hasta"]);

                                    if (Convert.ToInt32(nivel) == idEnumGrupo)
                                        consultaBonificacionMemoria = String.Format("id_tipo_facturacion='{0}' and id_item='{1}' and nivel='{2}'", fila["id_tipo_facturacion"], fila["id_grupo"], Convert.ToInt32(NIVEL.GRUPO));
                                    else if (Convert.ToInt32(nivel) == idEnumTipo)
                                        consultaBonificacionMemoria = String.Format("id_tipo_facturacion='{0}' and id_item='{1}' and nivel='{2}'", fila["id_tipo_facturacion"], fila["id_servicio_tipo"], Convert.ToInt32(NIVEL.TIPO_SERVICIO));
                                    else if (Convert.ToInt32(nivel) == idEnumServicio)
                                        consultaBonificacionMemoria = String.Format("id_tipo_facturacion='{0}' and id_item='{1}' and nivel='{2}'", fila["id_tipo_facturacion"], fila["id_servicio"], Convert.ToInt32(NIVEL.SERVICIO));
                                    else if (Convert.ToInt32(nivel) == idEnumSubServicio)
                                        consultaBonificacionMemoria = String.Format("id_tipo_facturacion='{0}' and id_item='{1}' and nivel='{2}' and id_velocidad='{3}' and id_velocidad_tipo='{4}' and tipo_servicio_sub='{5}' and id_servicio='{6}'", fila["id_tipo_facturacion"], fila["id_servicio_sub"], Convert.ToInt32(NIVEL.SUBSERVICIO), fila["id_velocidad"], fila["id_velocidad_tipo"], fila["tipo_servicio_sub"], fila["id_servicio"]);

                                    DrBonificacionAplicacion = DtBonificacionAplicacionAuxiliar.Select(consultaBonificacionMemoria);// las vuelve a tomar de la tabla en memoria con el formato de esa tabla
                                }

                                if (DrBonificacionAplicacion.Count() > 0)
                                {
                                    foreach (DataRow filaAplicacion in DrBonificacionAplicacion)
                                    {//por cada bonificacion asociada al grupo, tipo, servicio o subservicio de la fila que está recorriendo controla que hayan condiciones
                                        DrBonificacionCondiciones = oBonificacionCondiciones.ListarPorIdBonificacionAplicacion(Convert.ToInt32(filaAplicacion["id"])).Select("id>0");
                                        if (DrBonificacionCondiciones.Count() > 0)
                                        {// se controla que la bonificación o aplicación de bonificación tengan condiciones cargadas
                                            ListaServiciosEncontrados.Clear();
                                            ControlarCondicionesBonificacion(DrBonificacionCondiciones, DtListadoDeServicios, DtSubServicios, ListaCondicionesCumplidas, Convert.ToInt32(filaAplicacion["tipo_bonificacion"]), filaAplicacion);

                                            if (((Convert.ToInt32(nivel) == idEnumGrupo || Convert.ToInt32(nivel) == idEnumTipo) && (ListaCondicionesCumplidas.Count() == DrBonificacionCondiciones.Count())) || ((Convert.ToInt32(nivel) == idEnumServicio || Convert.ToInt32(nivel) == idEnumSubServicio) && ((Convert.ToInt32(filaAplicacion["tipo_bonificacion"]) == Convert.ToInt32(Bonificaciones.TIPO_BONIFICACION.COMBINACION) && ListaCondicionesCumplidas.Count() == DrBonificacionCondiciones.Count()) || (Convert.ToInt32(filaAplicacion["tipo_bonificacion"]) == Convert.ToInt32(Bonificaciones.TIPO_BONIFICACION.REPETICION) && ListaCondicionesCumplidas.Count() > 0))))
                                            {
                                                consultaBonificacionMemoria = String.Empty;
                                                if (Convert.ToInt32(nivel) == idEnumGrupo)
                                                    consultaBonificacionMemoria = String.Format("id_tipo_facturacion='{0}' and id_grupo='{1}' and tipo_servicio_sub='{2}' and id_tipo_de_sub<>'{3}'", fila["id_tipo_facturacion"], fila["id_grupo"], 'S', Convert.ToInt32(Servicios_Sub.SERVICIO_SUB_TIPOS.DERECHO_DE_CONEXION));
                                                else if (Convert.ToInt32(nivel) == idEnumTipo)
                                                    consultaBonificacionMemoria = String.Format("id_tipo_facturacion='{0}' and id_servicio_tipo='{1}' and tipo_servicio_sub='{2}' and id_tipo_de_sub<>'{3}'", fila["id_tipo_facturacion"], fila["id_servicio_tipo"], 'S', Convert.ToInt32(Servicios_Sub.SERVICIO_SUB_TIPOS.DERECHO_DE_CONEXION));
                                                else if (Convert.ToInt32(nivel) == idEnumServicio)
                                                    consultaBonificacionMemoria = String.Format("id_tipo_facturacion='{0}' and id_servicio='{1}' and tipo_servicio_sub='{2}' and id_tipo_de_sub<>'{3}'", fila["id_tipo_facturacion"], fila["id_servicio"], 'S', Convert.ToInt32(Servicios_Sub.SERVICIO_SUB_TIPOS.DERECHO_DE_CONEXION));
                                                else if (Convert.ToInt32(nivel) == idEnumSubServicio)
                                                    consultaBonificacionMemoria = String.Format("id_tipo_facturacion='{0}' and id_servicio_sub='{1}' and id_velocidad='{2}' and id_velocidad_tipo='{3}' and tipo_servicio_sub='{4}' and id_servicio='{5}'", fila["id_tipo_facturacion"], fila["id_servicio_sub"], fila["id_velocidad"], fila["id_velocidad_tipo"], fila["tipo_servicio_sub"], fila["id_servicio"]);

                                                DataView dtvFiltradoSubServicios = new DataView(DtSubServicios);
                                                dtvFiltradoSubServicios.RowFilter = consultaBonificacionMemoria;
                                                fechaInicio = new DateTime();
                                                fechaFin = new DateTime();
                                                fechaInicioAuxiliar = new DateTime();

                                                //en cuanto a las bonificaciones especiales, adicionar un campo más a la tabla de subservicios que se llame bonificacion especial y contenga dentro
                                                //el id de esa bonificación


                                                foreach (DataRow subServicio in dtvFiltradoSubServicios.ToTable().Rows)
                                                {
                                                    if (Convert.ToInt32(subServicio["heredado"]) != 1 && Convert.ToInt32(subServicio["id_bonificacion_especial"]) == 0)
                                                    {
                                                        if (
                                                            (idTipoFacturacionConfig == Convert.ToInt32(Tipo_Facturacion.Id_Tipo_Facturacion.POR_CATEGORIAS))
                                                            ||
                                                            (idTipoFacturacionConfig == Convert.ToInt32(Tipo_Facturacion.Id_Tipo_Facturacion.POR_ZONAS) && (Convert.ToInt32(filaAplicacion["id_localidad"]) == 0 || (Convert.ToInt32(filaAplicacion["id_localidad"]) == Convert.ToInt32(subServicio["id_localidad"])))))
                                                        {
                                                            importeOriginalTotal = 0;
                                                            importeConDescuentoTotal = 0;
                                                            porcentajeTotal = 0;
                                                            id_usuario_servicio_sub = 0;
                                                            sumatoriaMontoConDescuento = 0;
                                                            sumatoriaDescuento = 0;
                                                            filaAgregar = dtMesesPorcentajes.NewRow();
                                                            fechaInicio = Convert.ToDateTime(subServicio["fecha_inicio_servicio"]);
                                                            fechaInicioAuxiliar = fechaInicio;

                                                            fechaLimiteDesde = new DateTime();
                                                            fechaLimiteHasta = new DateTime();

                                                            //desde que fecha hasta que fecha se aplica la bonificación
                                                            if (Convert.ToInt32(filaAplicacion["por_contratacion"]) == 1)
                                                            {
                                                                fechaLimiteDesde = fechaInicio;
                                                                fechaLimiteHasta = fechaInicio.AddMonths((Convert.ToInt32(subServicio["meses_cobro"]) * Convert.ToInt32(filaAplicacion["cantidad_periodos"])));
                                                            }
                                                            else
                                                            {
                                                                fechaLimiteDesde = Convert.ToDateTime(filaAplicacion["fecha_desde"]);
                                                                fechaLimiteHasta = Convert.ToDateTime(filaAplicacion["fecha_hasta"]);
                                                            }

                                                            if (Convert.ToInt32(filaAplicacion["tipo_bonificacion"]) == Convert.ToInt32(Bonificaciones.TIPO_BONIFICACION.COMBINACION))
                                                            {
                                                                filaAgregar = dtMesesPorcentajes.NewRow();
                                                                filaAgregar["id_usuarios_locaciones"] = subServicio["id_usuarios_locaciones"];
                                                                filaAgregar["id_usuarios_servicios"] = subServicio["id_usuario_servicio"];
                                                                filaAgregar["id_usuarios_servicios_sub"] = subServicio["id_usuario_servicio_sub"];
                                                                filaAgregar["fecha_desde"] = fechaInicio.ToString();
                                                                filaAgregar["fecha_hasta"] = fechaInicio.ToString();
                                                                filaAgregar["porcentaje"] = filaAplicacion["porcentaje"];
                                                                filaAgregar["importe_original"] = subServicio["importe_original"];
                                                                filaAgregar["importe_con_descuento"] = Decimal.Round(Convert.ToDecimal(subServicio["importe_original"]) - Decimal.Round((Convert.ToDecimal(subServicio["importe_original"]) * Convert.ToDecimal(filaAplicacion["porcentaje"])) / 100, Convert.ToInt16(oConfig.GetValor_N("Cantidad_Decimales"))), Convert.ToInt16(oConfig.GetValor_N("Cantidad_Decimales")));
                                                                filaAgregar["id_bonificacion"] = filaAplicacion["id_bonificacion"];
                                                                filaAgregar["nombre_bonificacion"] = filaAplicacion["nombre_bonificacion"];
                                                                filaAgregar["por_contratacion"] = filaAplicacion["por_contratacion"];
                                                                filaAgregar["nro_mes"] = fechaInicio.Month;
                                                                filaAgregar["meses_cobro"] = subServicio["meses_cobro"];
                                                                filaAgregar["meses_servicio"] = subServicio["meses_servicio"];
                                                                filaAgregar["id_usuarios_servicios_sub_tipos"] = subServicio["id_tipo_de_sub"];
                                                                filaAgregar["tipo_servicio_sub"] = subServicio["tipo_servicio_sub"];
                                                                filaAgregar["requiere_ip"] = subServicio["requiere_ip"];
                                                                filaAgregar["id_servicios"] = Convert.ToInt32(subServicio["id_servicio"]);
                                                                filaAgregar["id_servicios_velocidades"] = Convert.ToInt32(subServicio["id_velocidad"]);
                                                                filaAgregar["id_servicios_velocidades_tipos"] = Convert.ToInt32(subServicio["id_velocidad_tipo"]);
                                                                if (Convert.ToInt32(filaAgregar["por_contratacion"]) == 1)
                                                                {
                                                                    filaAgregar["id_usuarios_contratacion"] = subServicio["id_usuarios"];
                                                                    filaAgregar["id_usuarios_locaciones_contratacion"] = subServicio["id_usuarios_locaciones"];
                                                                    filaAgregar["id_servicios_contratacion"] = subServicio["id_servicio"];
                                                                    filaAgregar["id_servicios_sub_contratacion"] = subServicio["id_servicio_sub"];
                                                                    filaAgregar["id_servicios_velocidades_contratacion"] = subServicio["velocidad"];
                                                                    filaAgregar["id_servicios_velocidades_tip_contratacion"] = subServicio["velocidad_tipo"];
                                                                    filaAgregar["fecha_desde_contratacion"] = filaAplicacion["fecha_desde"];
                                                                    filaAgregar["fecha_hasta_contratacion"] = filaAplicacion["fecha_hasta"];
                                                                    filaAgregar["porcentaje_contratacion"] = filaAplicacion["porcentaje"];
                                                                    filaAgregar["monto_contratacion"] = 0;
                                                                    filaAgregar["tipo_contratacion"] = filaAplicacion["tipo_servicio_sub"];
                                                                    filaAgregar["detalle_contratacion"] = filaAplicacion["nombre_bonificacion"];
                                                                    filaAgregar["id_usuarios_servicios_contratacion"] = subServicio["id_usuario_servicio"];
                                                                    filaAgregar["id_usuarios_servicios_sub_contratacion"] = subServicio["id_usuario_servicio_sub"];
                                                                    filaAgregar["finaliza_contratacion"] = 1;
                                                                    filaAgregar["facturable_contratacion"] = 1;
                                                                    filaAgregar["id_tipo_contratacion"] = 1;
                                                                    filaAgregar["imprime_contratacion"] = 1;
                                                                    filaAgregar["cantidad_periodos_contratacion"] = filaAplicacion["cantidad_periodos"];
                                                                    filaAgregar["nivel_bonificacion_contratacion"] = filaAplicacion["nivel"];
                                                                    filaAgregar["id_bonificacion_contratacion"] = filaAplicacion["id_bonificacion"];
                                                                }
                                                            }
                                                            else if (Convert.ToInt32(filaAplicacion["tipo_bonificacion"]) == Convert.ToInt32(Bonificaciones.TIPO_BONIFICACION.REPETICION))
                                                            {
                                                                foreach (DataRow filaCondicion in DrBonificacionCondiciones)
                                                                {
                                                                    if (ListaCondicionesCumplidas.Contains(Convert.ToInt32(filaCondicion["id"])))
                                                                    {
                                                                        dtAplicacionPorcentajes.Clear();
                                                                        DrCondicionesPorcentajes = oCondicionesPorcentajes.ListarPorIdCondicion(Convert.ToInt32(filaCondicion["id"])).Select("id>0");
                                                                        consultaBonificacionMemoria = String.Empty;
                                                                        if (Convert.ToInt32(nivel) == idEnumServicio)
                                                                            consultaBonificacionMemoria = String.Format("id_tipo_facturacion='{0}' and id_servicio='{1}' and tipo_servicio_sub='{2}' and id_tipo_de_sub<>'{3}' and id_servicio_sub='{4}'", fila["id_tipo_facturacion"], fila["id_servicio"], 'S', Convert.ToInt32(Servicios_Sub.SERVICIO_SUB_TIPOS.DERECHO_DE_CONEXION), subServicio["id_servicio_sub"]);
                                                                        else
                                                                            consultaBonificacionMemoria = String.Format("id_tipo_facturacion='{0}' and id_servicio_sub='{1}' and id_velocidad='{2}' and id_velocidad_tipo='{3}' and tipo_servicio_sub='{4}'", fila["id_tipo_facturacion"], fila["id_servicio_sub"], fila["id_velocidad"], fila["id_velocidad_tipo"], fila["tipo_servicio_sub"]);

                                                                        drFiltro = DtSubServicios.Select(consultaBonificacionMemoria);
                                                                        int z = 0;
                                                                        foreach (DataRow subservicio in drFiltro)
                                                                        {
                                                                            for (int y = 0; y < Convert.ToInt32(subservicio["cant_bocas_pac"]); y++)
                                                                            {
                                                                                z++;
                                                                                dtAplicacionPorcentajes.Rows.Add(subservicio["id_usuario_servicio"], subservicio["id_usuario_servicio_sub"], subservicio["id_tipo_facturacion"], subservicio["id_servicio_sub"], subservicio["id_velocidad"], subservicio["id_velocidad_tipo"], subservicio["tipo_servicio_sub"], Convert.ToString(z), Convert.ToDecimal(subservicio["importe_original"]) / Convert.ToDecimal(subservicio["cant_bocas_pac"]), Convert.ToInt32(filaAplicacion["por_contratacion"]) == 0 ? subservicio["porcentaje"] : subservicio["porcentaje_contratacion"], Convert.ToInt32(subservicio["importe_con_descuento"]) / Convert.ToDecimal(subservicio["cant_bocas_pac"]), subservicio["indice_generado"]);
                                                                            }
                                                                        }

                                                                        foreach (DataRow Porcentaje in DrCondicionesPorcentajes)
                                                                        {
                                                                            int ItemDesde = Convert.ToInt32(Porcentaje["item_desde"]);
                                                                            int ItemHasta = Convert.ToInt32(Porcentaje["item_hasta"]);
                                                                            string LimiteDesde = Porcentaje["limite_desde"].ToString();
                                                                            string LimiteHasta = Porcentaje["limite_hasta"].ToString();

                                                                            foreach (DataRow item in dtAplicacionPorcentajes.Rows)
                                                                            {
                                                                                if (ItemHasta == 0)
                                                                                {
                                                                                    if ((LimiteDesde == "=" && Convert.ToInt32(item["nro_item"]) == ItemDesde) || (LimiteDesde == ">" && Convert.ToInt32(item["nro_item"]) > ItemDesde))
                                                                                    {
                                                                                        if (item["porcentaje"].ToString() == String.Empty || Convert.ToDecimal(item["porcentaje"].ToString()) < Convert.ToDecimal(Porcentaje["porcentaje"]))
                                                                                            item["porcentaje"] = Porcentaje["porcentaje"];
                                                                                    }
                                                                                }
                                                                                else
                                                                                {
                                                                                    if ((LimiteDesde == "=" && Convert.ToInt32(item["nro_item"]) >= ItemDesde && Convert.ToInt32(item["nro_item"]) <= ItemHasta) || (LimiteDesde == ">" && Convert.ToInt32(item["nro_item"]) > ItemDesde && Convert.ToInt32(item["nro_item"]) <= ItemHasta))
                                                                                    {
                                                                                        if (item["porcentaje"].ToString() == String.Empty || Convert.ToDecimal(item["porcentaje"].ToString()) < Convert.ToDecimal(Porcentaje["porcentaje"]))
                                                                                            item["porcentaje"] = Porcentaje["porcentaje"];
                                                                                    }
                                                                                }
                                                                            }
                                                                        }

                                                                        listaUsuariosServiciosSub.Clear();
                                                                        DataRow[] drUsuariosServiciosSub;
                                                                        id_usuario_servicio_sub = 0;
                                                                        sumatoriaMontoConDescuento = 0;
                                                                        sumatoriaDescuento = 0;

                                                                        if (dtAplicacionPorcentajes.Rows.Count > 0)
                                                                        {
                                                                            foreach (DataRow subAplicacion in dtAplicacionPorcentajes.Rows)
                                                                            {
                                                                                id_usuario_servicio_sub = Convert.ToInt32(subServicio["id_usuario_servicio_sub"]);
                                                                                sumatoriaMontoConDescuento = 0;
                                                                                sumatoriaDescuento = 0;

                                                                                if (listaUsuariosServiciosSub.Contains(id_usuario_servicio_sub) == false)
                                                                                {
                                                                                    listaUsuariosServiciosSub.Add(id_usuario_servicio_sub);

                                                                                    drUsuariosServiciosSub = dtAplicacionPorcentajes.Select(String.Format("id_usuario_servicio_sub='{0}'", id_usuario_servicio_sub.ToString()));

                                                                                    decimal porcentajeSumatoria = 0;
                                                                                    foreach (DataRow unidadPactada in drUsuariosServiciosSub)
                                                                                    {
                                                                                        porcentajeSumatoria += Convert.ToDecimal(unidadPactada["porcentaje"]);
                                                                                        sumatoriaMontoConDescuento += Convert.ToDecimal(unidadPactada["importe_original"]) - Decimal.Round(((Convert.ToDecimal(unidadPactada["importe_original"]) * Convert.ToDecimal(unidadPactada["porcentaje"])) / 100), Convert.ToInt16(oConfig.GetValor_N("Cantidad_Decimales")));
                                                                                        sumatoriaDescuento += Decimal.Round(((Convert.ToDecimal(unidadPactada["importe_original"]) * Convert.ToDecimal(unidadPactada["porcentaje"])) / 100), Convert.ToInt16(oConfig.GetValor_N("Cantidad_Decimales")));
                                                                                    }

                                                                                    if (filaAgregar == null || (filaAgregar != null && Convert.ToDecimal(filaAgregar["porcentaje"]) < porcentajeSumatoria))
                                                                                    {

                                                                                        filaAgregar = dtMesesPorcentajes.NewRow();
                                                                                        filaAgregar["id_usuarios_locaciones"] = subServicio["id_usuarios_locaciones"];
                                                                                        filaAgregar["id_usuarios_servicios"] = subServicio["id_usuario_servicio"];
                                                                                        filaAgregar["id_usuarios_servicios_sub"] = subServicio["id_usuario_servicio_sub"];
                                                                                        filaAgregar["fecha_desde"] = fechaInicio.ToString();
                                                                                        filaAgregar["fecha_hasta"] = fechaFin.ToString();
                                                                                        if (Convert.ToDecimal(subServicio["importe_original"]) != 0)
                                                                                            filaAgregar["porcentaje"] = (sumatoriaDescuento * 100) / Convert.ToDecimal(subServicio["importe_original"]);
                                                                                        else
                                                                                            filaAgregar["porcentaje"] = 0;
                                                                                        filaAgregar["importe_original"] = subServicio["importe_original"];
                                                                                        filaAgregar["importe_con_descuento"] = Decimal.Round(sumatoriaMontoConDescuento, Convert.ToInt16(oConfig.GetValor_N("Cantidad_Decimales")));
                                                                                        filaAgregar["id_bonificacion"] = filaAplicacion["id_bonificacion"];
                                                                                        filaAgregar["nombre_bonificacion"] = filaAplicacion["nombre_bonificacion"];
                                                                                        filaAgregar["por_contratacion"] = filaAplicacion["por_contratacion"];
                                                                                        filaAgregar["nro_mes"] = fechaInicio.Month;
                                                                                        filaAgregar["meses_cobro"] = subServicio["meses_cobro"];
                                                                                        filaAgregar["meses_servicio"] = subServicio["meses_servicio"];
                                                                                        filaAgregar["id_usuarios_servicios_sub_tipos"] = subServicio["id_tipo_de_sub"];
                                                                                        filaAgregar["tipo_servicio_sub"] = subServicio["tipo_servicio_sub"];
                                                                                        filaAgregar["requiere_ip"] = subServicio["requiere_ip"];
                                                                                        filaAgregar["id_servicios"] = Convert.ToInt32(subServicio["id_servicio"]);
                                                                                        filaAgregar["id_servicios_velocidades"] = Convert.ToInt32(subServicio["id_velocidad"]);
                                                                                        filaAgregar["id_servicios_velocidades_tipos"] = Convert.ToInt32(subServicio["id_velocidad_tipo"]);
                                                                                        if (Convert.ToInt32(filaAgregar["por_contratacion"]) == 1)
                                                                                        {
                                                                                            filaAgregar["id_usuarios_contratacion"] = subServicio["id_usuarios"];
                                                                                            filaAgregar["id_usuarios_locaciones_contratacion"] = subServicio["id_usuarios_locaciones"];
                                                                                            filaAgregar["id_servicios_contratacion"] = subServicio["id_servicio"];
                                                                                            filaAgregar["id_servicios_sub_contratacion"] = subServicio["id_servicio_sub"];
                                                                                            filaAgregar["id_servicios_velocidades_contratacion"] = subServicio["velocidad"];
                                                                                            filaAgregar["id_servicios_velocidades_tip_contratacion"] = subServicio["velocidad_tipo"];
                                                                                            filaAgregar["fecha_desde_contratacion"] = filaAplicacion["fecha_desde"];
                                                                                            filaAgregar["fecha_hasta_contratacion"] = filaAplicacion["fecha_hasta"];
                                                                                            filaAgregar["porcentaje_contratacion"] = filaAgregar["porcentaje"];
                                                                                            filaAgregar["monto_contratacion"] = 0;
                                                                                            filaAgregar["tipo_contratacion"] = filaAplicacion["tipo_servicio_sub"];
                                                                                            filaAgregar["detalle_contratacion"] = filaAplicacion["nombre_bonificacion"];
                                                                                            filaAgregar["id_usuarios_servicios_contratacion"] = subServicio["id_usuario_servicio"];
                                                                                            filaAgregar["id_usuarios_servicios_sub_contratacion"] = subServicio["id_usuario_servicio_sub"];
                                                                                            filaAgregar["finaliza_contratacion"] = 1;
                                                                                            filaAgregar["facturable_contratacion"] = 1;
                                                                                            filaAgregar["id_tipo_contratacion"] = 1;
                                                                                            filaAgregar["imprime_contratacion"] = 1;
                                                                                            filaAgregar["cantidad_periodos_contratacion"] = filaAplicacion["cantidad_periodos"];
                                                                                            filaAgregar["nivel_bonificacion_contratacion"] = filaAplicacion["nivel"];
                                                                                            filaAgregar["id_bonificacion_contratacion"] = filaAplicacion["id_bonificacion"];
                                                                                        }
                                                                                    }
                                                                                }
                                                                            }
                                                                        }

                                                                    }
                                                                }
                                                            }



                                                            //a partir de este punto comienza a generar los registros de los meses de cada subservicio que recorre
                                                            //si el subservicio pertenece a un servicio que no sea por periodo/dia/mensual, esto se podría articular de otra forma
                                                            //para que pueda ir dentro de la misma tabla o generar otra tabla correspondiente a periodos cerrados, haciendo que la tabla
                                                            //de meses trabaje sólo para los subservicios de servicios por periodo/dia/mes

                                                            if (Convert.ToInt32(subServicio["id_servicio_modalidad"]) == Convert.ToInt32(Servicios._Modalidad.MENSUAL) || Convert.ToInt32(subServicio["id_servicio_modalidad"]) == Convert.ToInt32(Servicios._Modalidad.PERIODO))
                                                            {
                                                                for (int x = 0; x < (Convert.ToInt32(subServicio["meses_cobro"])); x++)
                                                                {
                                                                    if (Convert.ToInt32(subServicio["id_servicio_modalidad"]) == Convert.ToInt32(Servicios._Modalidad.MENSUAL))
                                                                    {
                                                                        fechaFin = fechaInicio.AddMonths(1);
                                                                        fechaFin = new DateTime(fechaFin.Year, fechaFin.Month, 1);
                                                                        fechaFin = fechaFin.AddDays(-1);
                                                                    }
                                                                    else
                                                                    {
                                                                        if (subServicio["tipo_servicio_sub"].ToString() == "S")
                                                                        {
                                                                            if (x == (Convert.ToInt32(subServicio["meses_cobro"]) - 1))
                                                                                fechaFin = fechaInicio.AddMonths((Convert.ToInt32(subServicio["meses_servicio"]) - Convert.ToInt32(subServicio["meses_cobro"])) + 1).AddDays(-1);
                                                                            else
                                                                                fechaFin = fechaInicio.AddMonths(1).AddDays(-1);
                                                                        }
                                                                        else
                                                                            fechaFin = fechaInicio.AddMonths(1).AddDays(-1);
                                                                    }



                                                                    if ((fechaInicio.Date >= fechaLimiteDesde.Date && fechaInicio.Date <= fechaLimiteHasta.Date) || (fechaInicio.Date.Month >= fechaLimiteDesde.Date.Month && fechaInicio.Date.Month <= fechaLimiteHasta.Date.Month))
                                                                    {
                                                                        filaAgregar["fecha_desde"] = fechaInicio.ToString();
                                                                        filaAgregar["fecha_hasta"] = fechaFin.ToString();
                                                                        filaAgregar["nro_mes"] = fechaInicio.Month;
                                                                        filaEliminar = null;

                                                                        if (filaAgregar != null)
                                                                        {
                                                                            if (dtMesesPorcentajes.Select("id_usuarios_servicios_sub='" + filaAgregar["id_usuarios_servicios_sub"].ToString() + "' and nro_mes='" + filaAgregar["nro_mes"].ToString() + "'").Length > 0)
                                                                            {
                                                                                filaEliminar = dtMesesPorcentajes.Select("id_usuarios_servicios_sub='" + filaAgregar["id_usuarios_servicios_sub"].ToString() + "' and nro_mes='" + filaAgregar["nro_mes"].ToString() + "'")[0];

                                                                                if (Convert.ToInt32(filaAgregar["por_contratacion"]) == 1 && Convert.ToDecimal(filaEliminar["porcentaje_contratacion"]) < Convert.ToDecimal(filaAgregar["porcentaje_contratacion"]))
                                                                                {
                                                                                    filaEliminar["porcentaje_contratacion"] = filaAgregar["porcentaje_contratacion"];
                                                                                    filaEliminar["id_bonificacion_contratacion"] = filaAgregar["id_bonificacion_contratacion"];
                                                                                    filaEliminar["id_usuarios_contratacion"] = filaAgregar["id_usuarios_contratacion"];
                                                                                    filaEliminar["id_usuarios_locaciones_contratacion"] = filaAgregar["id_usuarios_locaciones_contratacion"];
                                                                                    filaEliminar["id_servicios_contratacion"] = filaAgregar["id_servicios_contratacion"];
                                                                                    filaEliminar["id_servicios_sub_contratacion"] = filaAgregar["id_servicios_sub_contratacion"];
                                                                                    filaEliminar["id_servicios_velocidades_contratacion"] = filaAgregar["id_servicios_velocidades_contratacion"];
                                                                                    filaEliminar["id_servicios_velocidades_tip_contratacion"] = filaAgregar["id_servicios_velocidades_tip_contratacion"];
                                                                                    filaEliminar["fecha_desde_contratacion"] = filaAgregar["fecha_desde_contratacion"];
                                                                                    filaEliminar["fecha_hasta_contratacion"] = filaAgregar["fecha_hasta_contratacion"];
                                                                                    filaEliminar["monto_contratacion"] = filaAgregar["monto_contratacion"];
                                                                                    filaEliminar["tipo_contratacion"] = filaAgregar["tipo_contratacion"];
                                                                                    filaEliminar["detalle_contratacion"] = filaAgregar["detalle_contratacion"];
                                                                                    filaEliminar["id_usuarios_servicios_contratacion"] = filaAgregar["id_usuarios_servicios_contratacion"];
                                                                                    filaEliminar["id_usuarios_servicios_sub_contratacion"] = filaAgregar["id_usuarios_servicios_sub_contratacion"];
                                                                                    filaEliminar["finaliza_contratacion"] = filaAgregar["finaliza_contratacion"];
                                                                                    filaEliminar["facturable_contratacion"] = filaAgregar["facturable_contratacion"];
                                                                                    filaEliminar["id_tipo_contratacion"] = filaAgregar["id_tipo_contratacion"];
                                                                                    filaEliminar["imprime_contratacion"] = filaAgregar["imprime_contratacion"];
                                                                                    filaEliminar["cantidad_periodos_contratacion"] = filaAgregar["cantidad_periodos_contratacion"];
                                                                                    filaEliminar["nivel_bonificacion_contratacion"] = filaAgregar["nivel_bonificacion_contratacion"];
                                                                                    filaEliminar["por_contratacion"] = filaAgregar["por_contratacion"];
                                                                                }
                                                                                else if (Convert.ToDecimal(filaEliminar["porcentaje"]) < Convert.ToDecimal(filaAgregar["porcentaje"]))
                                                                                {

                                                                                    if (Convert.ToDecimal(filaEliminar["porcentaje_contratacion"]) > 0)
                                                                                    {
                                                                                        filaAgregar["porcentaje_contratacion"] = filaEliminar["porcentaje_contratacion"];
                                                                                        filaAgregar["id_bonificacion_contratacion"] = filaEliminar["id_bonificacion_contratacion"];
                                                                                        filaAgregar["id_usuarios_contratacion"] = filaEliminar["id_usuarios_contratacion"];
                                                                                        filaAgregar["id_usuarios_locaciones_contratacion"] = filaEliminar["id_usuarios_locaciones_contratacion"];
                                                                                        filaAgregar["id_servicios_contratacion"] = filaEliminar["id_servicios_contratacion"];
                                                                                        filaAgregar["id_servicios_sub_contratacion"] = filaEliminar["id_servicios_sub_contratacion"];
                                                                                        filaAgregar["id_servicios_velocidades_contratacion"] = filaEliminar["id_servicios_velocidades_contratacion"];
                                                                                        filaAgregar["id_servicios_velocidades_tip_contratacion"] = filaEliminar["id_servicios_velocidades_tip_contratacion"];
                                                                                        filaAgregar["fecha_desde_contratacion"] = filaEliminar["fecha_desde_contratacion"];
                                                                                        filaAgregar["fecha_hasta_contratacion"] = filaEliminar["fecha_hasta_contratacion"];

                                                                                        filaAgregar["monto_contratacion"] = filaEliminar["monto_contratacion"];
                                                                                        filaAgregar["tipo_contratacion"] = filaEliminar["tipo_contratacion"];
                                                                                        filaAgregar["detalle_contratacion"] = filaEliminar["detalle_contratacion"];
                                                                                        filaAgregar["id_usuarios_servicios_contratacion"] = filaEliminar["id_usuarios_servicios_contratacion"];
                                                                                        filaAgregar["id_usuarios_servicios_sub_contratacion"] = filaEliminar["id_usuarios_servicios_sub_contratacion"];
                                                                                        filaAgregar["finaliza_contratacion"] = filaEliminar["finaliza_contratacion"];
                                                                                        filaAgregar["facturable_contratacion"] = filaEliminar["facturable_contratacion"];
                                                                                        filaAgregar["id_tipo_contratacion"] = filaEliminar["id_tipo_contratacion"];
                                                                                        filaAgregar["imprime_contratacion"] = filaEliminar["imprime_contratacion"];
                                                                                        filaAgregar["cantidad_periodos_contratacion"] = filaEliminar["cantidad_periodos_contratacion"];
                                                                                        filaAgregar["nivel_bonificacion_contratacion"] = filaEliminar["nivel_bonificacion_contratacion"];
                                                                                        filaAgregar["por_contratacion"] = filaEliminar["por_contratacion"];
                                                                                    }
                                                                                    dtMesesPorcentajes.Rows.RemoveAt(dtMesesPorcentajes.Rows.IndexOf(filaEliminar));
                                                                                    DataRow filaFinal = dtMesesPorcentajes.NewRow();

                                                                                    for (int y = 0; y < dtMesesPorcentajes.Columns.Count; y++)
                                                                                        filaFinal[y] = filaAgregar[y];
                                                                                    dtMesesPorcentajes.Rows.Add(filaFinal);
                                                                                }
                                                                            }
                                                                        }
                                                                    }
                                                                    fechaInicio = fechaFin.AddDays(1);
                                                                    dtMesesPorcentajes.AcceptChanges();
                                                                }
                                                            }
                                                            else
                                                            {
                                                                fechaInicio = Convert.ToDateTime(subServicio["fecha_inicio_servicio"]);
                                                                fechaFin = Convert.ToDateTime(subServicio["fecha_hasta_servicio"]);
                                                                if ((fechaInicio.Date >= fechaLimiteDesde.Date && fechaInicio.Date <= fechaLimiteHasta.Date) || (fechaInicio.Date.Month >= fechaLimiteDesde.Date.Month && fechaInicio.Date.Month <= fechaLimiteHasta.Date.Month))
                                                                {
                                                                    filaAgregar["fecha_desde"] = fechaInicio.ToString();
                                                                    filaAgregar["fecha_hasta"] = fechaFin.ToString();
                                                                    filaAgregar["nro_mes"] = fechaInicio.Month;
                                                                    filaEliminar = null;

                                                                    if (filaAgregar != null)
                                                                    {
                                                                        if (dtMesesPorcentajes.Select("id_usuarios_servicios_sub='" + filaAgregar["id_usuarios_servicios_sub"].ToString() + "' and nro_mes='" + filaAgregar["nro_mes"].ToString() + "'").Length > 0)
                                                                        {
                                                                            filaEliminar = dtMesesPorcentajes.Select("id_usuarios_servicios_sub='" + filaAgregar["id_usuarios_servicios_sub"].ToString() + "' and nro_mes='" + filaAgregar["nro_mes"].ToString() + "'")[0];

                                                                            if (Convert.ToInt32(filaAgregar["por_contratacion"]) == 1 && Convert.ToDecimal(filaEliminar["porcentaje_contratacion"]) < Convert.ToDecimal(filaAgregar["porcentaje_contratacion"]))
                                                                            {
                                                                                filaEliminar["porcentaje_contratacion"] = filaAgregar["porcentaje_contratacion"];
                                                                                filaEliminar["id_bonificacion_contratacion"] = filaAgregar["id_bonificacion_contratacion"];
                                                                                filaEliminar["id_usuarios_contratacion"] = filaAgregar["id_usuarios_contratacion"];
                                                                                filaEliminar["id_usuarios_locaciones_contratacion"] = filaAgregar["id_usuarios_locaciones_contratacion"];
                                                                                filaEliminar["id_servicios_contratacion"] = filaAgregar["id_servicios_contratacion"];
                                                                                filaEliminar["id_servicios_sub_contratacion"] = filaAgregar["id_servicios_sub_contratacion"];
                                                                                filaEliminar["id_servicios_velocidades_contratacion"] = filaAgregar["id_servicios_velocidades_contratacion"];
                                                                                filaEliminar["id_servicios_velocidades_tip_contratacion"] = filaAgregar["id_servicios_velocidades_tip_contratacion"];
                                                                                filaEliminar["fecha_desde_contratacion"] = filaAgregar["fecha_desde_contratacion"];
                                                                                filaEliminar["fecha_hasta_contratacion"] = filaAgregar["fecha_hasta_contratacion"];
                                                                                filaEliminar["monto_contratacion"] = filaAgregar["monto_contratacion"];
                                                                                filaEliminar["tipo_contratacion"] = filaAgregar["tipo_contratacion"];
                                                                                filaEliminar["detalle_contratacion"] = filaAgregar["detalle_contratacion"];
                                                                                filaEliminar["id_usuarios_servicios_contratacion"] = filaAgregar["id_usuarios_servicios_contratacion"];
                                                                                filaEliminar["id_usuarios_servicios_sub_contratacion"] = filaAgregar["id_usuarios_servicios_sub_contratacion"];
                                                                                filaEliminar["finaliza_contratacion"] = filaAgregar["finaliza_contratacion"];
                                                                                filaEliminar["facturable_contratacion"] = filaAgregar["facturable_contratacion"];
                                                                                filaEliminar["id_tipo_contratacion"] = filaAgregar["id_tipo_contratacion"];
                                                                                filaEliminar["imprime_contratacion"] = filaAgregar["imprime_contratacion"];
                                                                                filaEliminar["cantidad_periodos_contratacion"] = filaAgregar["cantidad_periodos_contratacion"];
                                                                                filaEliminar["nivel_bonificacion_contratacion"] = filaAgregar["nivel_bonificacion_contratacion"];
                                                                                filaEliminar["por_contratacion"] = filaAgregar["por_contratacion"];
                                                                            }
                                                                            else if (Convert.ToDecimal(filaEliminar["porcentaje"]) < Convert.ToDecimal(filaAgregar["porcentaje"]))
                                                                            {

                                                                                if (Convert.ToDecimal(filaEliminar["porcentaje_contratacion"]) > 0)
                                                                                {
                                                                                    filaAgregar["porcentaje_contratacion"] = filaEliminar["porcentaje_contratacion"];
                                                                                    filaAgregar["id_bonificacion_contratacion"] = filaEliminar["id_bonificacion_contratacion"];
                                                                                    filaAgregar["id_usuarios_contratacion"] = filaEliminar["id_usuarios_contratacion"];
                                                                                    filaAgregar["id_usuarios_locaciones_contratacion"] = filaEliminar["id_usuarios_locaciones_contratacion"];
                                                                                    filaAgregar["id_servicios_contratacion"] = filaEliminar["id_servicios_contratacion"];
                                                                                    filaAgregar["id_servicios_sub_contratacion"] = filaEliminar["id_servicios_sub_contratacion"];
                                                                                    filaAgregar["id_servicios_velocidades_contratacion"] = filaEliminar["id_servicios_velocidades_contratacion"];
                                                                                    filaAgregar["id_servicios_velocidades_tip_contratacion"] = filaEliminar["id_servicios_velocidades_tip_contratacion"];
                                                                                    filaAgregar["fecha_desde_contratacion"] = filaEliminar["fecha_desde_contratacion"];
                                                                                    filaAgregar["fecha_hasta_contratacion"] = filaEliminar["fecha_hasta_contratacion"];

                                                                                    filaAgregar["monto_contratacion"] = filaEliminar["monto_contratacion"];
                                                                                    filaAgregar["tipo_contratacion"] = filaEliminar["tipo_contratacion"];
                                                                                    filaAgregar["detalle_contratacion"] = filaEliminar["detalle_contratacion"];
                                                                                    filaAgregar["id_usuarios_servicios_contratacion"] = filaEliminar["id_usuarios_servicios_contratacion"];
                                                                                    filaAgregar["id_usuarios_servicios_sub_contratacion"] = filaEliminar["id_usuarios_servicios_sub_contratacion"];
                                                                                    filaAgregar["finaliza_contratacion"] = filaEliminar["finaliza_contratacion"];
                                                                                    filaAgregar["facturable_contratacion"] = filaEliminar["facturable_contratacion"];
                                                                                    filaAgregar["id_tipo_contratacion"] = filaEliminar["id_tipo_contratacion"];
                                                                                    filaAgregar["imprime_contratacion"] = filaEliminar["imprime_contratacion"];
                                                                                    filaAgregar["cantidad_periodos_contratacion"] = filaEliminar["cantidad_periodos_contratacion"];
                                                                                    filaAgregar["nivel_bonificacion_contratacion"] = filaEliminar["nivel_bonificacion_contratacion"];
                                                                                    filaAgregar["por_contratacion"] = filaEliminar["por_contratacion"];
                                                                                }
                                                                                dtMesesPorcentajes.Rows.RemoveAt(dtMesesPorcentajes.Rows.IndexOf(filaEliminar));
                                                                                DataRow filaFinal = dtMesesPorcentajes.NewRow();

                                                                                for (int y = 0; y < dtMesesPorcentajes.Columns.Count; y++)
                                                                                    filaFinal[y] = filaAgregar[y];
                                                                                dtMesesPorcentajes.Rows.Add(filaFinal);
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                                dtMesesPorcentajes.AcceptChanges();
                                                            }

                                                            drMontosMensualesSubServicio = dtMesesPorcentajes.Select("id_usuarios_servicios_sub='" + subServicio["id_usuario_servicio_sub"].ToString() + "'");

                                                            importeOriginalTotal = 0;
                                                            importeConDescuentoTotal = 0;
                                                            porcentajeTotal = 0;

                                                            foreach (DataRow montoMensual in drMontosMensualesSubServicio)
                                                            {
                                                                importeOriginalTotal += Convert.ToDecimal(montoMensual["importe_original"]);
                                                                importeConDescuentoTotal += Convert.ToDecimal(montoMensual["importe_con_descuento"]);
                                                            }

                                                            if (importeOriginalTotal != 0)
                                                                porcentajeTotal = ((importeOriginalTotal - importeConDescuentoTotal) * 100) / importeOriginalTotal;

                                                            subServicio["importe_original"] = importeOriginalTotal;
                                                            subServicio["importe_con_descuento"] = importeConDescuentoTotal;
                                                            //subServicio["porcentaje"] =Decimal.Round(porcentajeTotal, Convert.ToInt16(oConfig.GetValor_N("Cantidad_Decimales")));
                                                            subServicio["porcentaje"] = porcentajeTotal;
                                                            DtSubServicios.AcceptChanges();
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        ListaServiciosEncontrados.Clear();
                    }
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;

                sinErrores = false;
                if (mensajeError == 0)
                    MessageBox.Show("Error al calcular bonificaciones.");
            }

            if (sinErrores)
            {
                try
                {
                    Prorratear(DtSubServicios, dtMesesPorcentajes);
                    RecalcularImportes(DtSubServicios, dtMesesPorcentajes, facMensual);
                    SetearPorcentajeImporteParcial(dtMesesPorcentajes);
                    if ((presentaEspeciales && contemplarSoloEspeciales == Convert.ToInt16(CONTEMPLAR_SOLO_ESPECIALES.NO)) || presentaEspeciales == false)
                    {
                        if (emplearBonificacionesContratacion)
                        {
                            dtDatosNovedadesInternas = GenerarDtDatosNovedades();
                            AplicarPorcentajeBonificacionContratacion(DtSubServicios, dtMesesPorcentajes, dtDatosNovedadesInternas);
                            RecalcularImportes(DtSubServicios, dtMesesPorcentajes, facMensual);
                        }
                    }
                    else
                        dtDatosNovedadesInternas = GenerarDtDatosNovedades();
                    //Prorratear(DtSubServicios, dtMesesPorcentajes);

                    RecalcularImportes(DtSubServicios, dtMesesPorcentajes, facMensual);
                }
                catch (Exception C)
                {
                    string error = C.Message;

                    if (mensajeError == 0)
                        MessageBox.Show("Error al calcular bonificaciones.");
                    sinErrores = false;
                }
            }

            if (sinErrores)
            {
                dtSubServicios = DtSubServicios;
                dtSubServiciosDetalles = dtMesesPorcentajes;
                dtDatosNovedades = dtDatosNovedadesInternas;
            }
            return sinErrores;
        }

        public void ActualizarBonificacionesUsuariosServiciosSub(int idUsuariosServiciosSub, int idBonificacion, decimal porcentaje, string nombreBonificacion)
        {
            try
            {
                oCon.Conectar();

                oCon.ComenzarTransaccion();
                oCon.CrearComando("UPDATE usuarios_servicios_sub set id_bonificacion_aplicada=@id_bonificacion_aplicada, porcentaje_bonificacion_aplicada=@porcentaje_bonificacion_aplicada, nombre_bonificacion_aplicacion=@nombre_bonificacion_aplicada WHERE Id = @Id");
                oCon.AsignarParametroEntero("@id_bonificacion_aplicada", idBonificacion);
                oCon.AsignarParametroDecimal("@porcentaje_bonificacion_aplicada", porcentaje);
                oCon.AsignarParametroCadena("@nombre_bonificacion_aplicada", nombreBonificacion);
                oCon.AsignarParametroEntero("@Id", idUsuariosServiciosSub);
                oCon.EjecutarComando();
                oCon.ConfirmarTransaccion();

                oCon.DesConectar();
            }
            catch (Exception)
            {
                oCon.CancelarTransaccion();
                oCon.DesConectar();
                throw;
            }

        }

        public DataTable TraerDatosBonificacionAplicacion(int IdTipoFacturacion, int IdItem, int Nivel, int IdVelocidad, int IdVelocidadTipo, string TipoSubServicio, bool porContratacion)
        {
            oCon.Conectar();
            if (porContratacion)
            {
                if (Nivel == Convert.ToInt32(NIVEL.SUBSERVICIO))
                    oCon.CrearComando(String.Format("select id, id_tipo_facturacion, id_servicio_sub as id_item, nivel, id_velocidad, id_velocidad_tipo, tipo_servicio_sub, porcentaje, tipo_bonificacion, id_bonificacion, nombre, id_grupo, id_tipo_servicio, id_servicio, id_servicio_sub, cantidad_periodos, mes_desde, mes_hasta, por_contratacion, contemplar_fecha_completa, date(fecha_desde) as fecha_desde, date(fecha_hasta) as fecha_hasta, id_localidad from bonificaciones_aplicacion where id_tipo_facturacion={0} and id_servicio_sub={1} and nivel={2} and id_velocidad={3} and id_velocidad_tipo={4} and tipo_servicio_sub='{5}' and borrado=0", IdTipoFacturacion, IdItem, Nivel, IdVelocidad, IdVelocidadTipo, TipoSubServicio));
                else if (Nivel == Convert.ToInt32(NIVEL.SERVICIO))
                    oCon.CrearComando(String.Format("select id, id_tipo_facturacion, id_servicio as id_item, nivel, id_velocidad, id_velocidad_tipo, tipo_servicio_sub, porcentaje, tipo_bonificacion, id_bonificacion, nombre, id_grupo, id_tipo_servicio, id_servicio, id_servicio_sub, cantidad_periodos, mes_desde, mes_hasta, por_contratacion, contemplar_fecha_completa, date(fecha_desde) as fecha_desde, date(fecha_hasta) as fecha_hasta, id_localidad from bonificaciones_aplicacion where id_tipo_facturacion={0} and id_servicio={1} and nivel={2} and borrado=0", IdTipoFacturacion, IdItem, Nivel));
                else if (Nivel == Convert.ToInt32(NIVEL.TIPO_SERVICIO))
                    oCon.CrearComando(String.Format("select id, id_tipo_facturacion, id_tipo_servicio as id_item, nivel, id_velocidad, id_velocidad_tipo, tipo_servicio_sub, porcentaje, tipo_bonificacion, id_bonificacion, nombre, id_grupo, id_tipo_servicio, id_servicio, id_servicio_sub, cantidad_periodos, mes_desde, mes_hasta, por_contratacion, contemplar_fecha_completa, date(fecha_desde) as fecha_desde, date(fecha_hasta) as fecha_hasta, id_localidad from bonificaciones_aplicacion where id_tipo_facturacion={0} and id_tipo_servicio={1} and nivel={2} and borrado=0", IdTipoFacturacion, IdItem, Nivel));
                else if (Nivel == Convert.ToInt32(NIVEL.GRUPO))
                    oCon.CrearComando(String.Format("select id, id_tipo_facturacion, id_grupo as id_item, nivel, id_velocidad, id_velocidad_tipo, tipo_servicio_sub, porcentaje, tipo_bonificacion, id_bonificacion, nombre, id_grupo, id_tipo_servicio, id_servicio, id_servicio_sub, cantidad_periodos, mes_desde, mes_hasta, por_contratacion, contemplar_fecha_completa, date(fecha_desde) as fecha_desde, date(fecha_hasta) as fecha_hasta, id_localidad from bonificaciones_aplicacion where id_tipo_facturacion={0} and id_grupo={1} and nivel={2} and borrado=0", IdTipoFacturacion, IdItem, Nivel));
            }
            else
            {
                if (Nivel == Convert.ToInt32(NIVEL.SUBSERVICIO))
                    oCon.CrearComando(String.Format("select id, id_tipo_facturacion, id_servicio_sub as id_item, nivel, id_velocidad, id_velocidad_tipo, tipo_servicio_sub, porcentaje, tipo_bonificacion, id_bonificacion, nombre, id_grupo, id_tipo_servicio, id_servicio, id_servicio_sub, cantidad_periodos, mes_desde, mes_hasta, por_contratacion, contemplar_fecha_completa, date(fecha_desde) as fecha_desde, date(fecha_hasta) as fecha_hasta, id_localidad from bonificaciones_aplicacion where id_tipo_facturacion={0} and id_servicio_sub={1} and nivel={2} and id_velocidad={3} and id_velocidad_tipo={4} and tipo_servicio_sub='{5}' and por_contratacion=0 and borrado=0", IdTipoFacturacion, IdItem, Nivel, IdVelocidad, IdVelocidadTipo, TipoSubServicio));
                else if (Nivel == Convert.ToInt32(NIVEL.SERVICIO))
                    oCon.CrearComando(String.Format("select id, id_tipo_facturacion, id_servicio as id_item, nivel, id_velocidad, id_velocidad_tipo, tipo_servicio_sub, porcentaje, tipo_bonificacion, id_bonificacion, nombre, id_grupo, id_tipo_servicio, id_servicio, id_servicio_sub, cantidad_periodos, mes_desde, mes_hasta, por_contratacion, contemplar_fecha_completa, date(fecha_desde) as fecha_desde, date(fecha_hasta) as fecha_hasta, id_localidad from bonificaciones_aplicacion where id_tipo_facturacion={0} and id_servicio={1} and nivel={2} and por_contratacion=0 and borrado=0", IdTipoFacturacion, IdItem, Nivel));
                else if (Nivel == Convert.ToInt32(NIVEL.TIPO_SERVICIO))
                    oCon.CrearComando(String.Format("select id, id_tipo_facturacion, id_tipo_servicio as id_item, nivel, id_velocidad, id_velocidad_tipo, tipo_servicio_sub, porcentaje, tipo_bonificacion, id_bonificacion, nombre, id_grupo, id_tipo_servicio, id_servicio, id_servicio_sub, cantidad_periodos, mes_desde, mes_hasta, por_contratacion, contemplar_fecha_completa, date(fecha_desde) as fecha_desde, date(fecha_hasta) as fecha_hasta, id_localidad from bonificaciones_aplicacion where id_tipo_facturacion={0} and id_tipo_servicio={1} and nivel={2} and por_contratacion=0 and borrado=0", IdTipoFacturacion, IdItem, Nivel));
                else if (Nivel == Convert.ToInt32(NIVEL.GRUPO))
                    oCon.CrearComando(String.Format("select id, id_tipo_facturacion, id_grupo as id_item, nivel, id_velocidad, id_velocidad_tipo, tipo_servicio_sub, porcentaje, tipo_bonificacion, id_bonificacion, nombre, id_grupo, id_tipo_servicio, id_servicio, id_servicio_sub, cantidad_periodos, mes_desde, mes_hasta, por_contratacion, contemplar_fecha_completa, date(fecha_desde) as fecha_desde, date(fecha_hasta) as fecha_hasta, id_localidad from bonificaciones_aplicacion where id_tipo_facturacion={0} and id_grupo={1} and nivel={2} and por_contratacion=0 and borrado=0", IdTipoFacturacion, IdItem, Nivel));
            }
            DataTable dt = oCon.Tabla();
            oCon.DesConectar();
            return dt;
        }

        public void ActualizarDatosAplicaciones(int IdBonificacion, decimal Porcentaje, DateTime FechaDesde, DateTime FechaHasta, string NombreBonificacion, int TipoBonificacion, int cantidad_periodo, int mes_desde, int mes_hasta, int por_contratacion, int contemplar_fecha_completa)
        {
            try
            {
                oCon.Conectar();
                oCon.ComenzarTransaccion();
                oCon.CrearComando("UPDATE bonificaciones_aplicacion set porcentaje=@porcentaje, fecha_desde=@fecha_desde, fecha_hasta=@fecha_hasta, nombre=@nombre, tipo_bonificacion=@tipo_bonificacion, cantidad_periodos=@cantidad_periodos, mes_desde=@mes_desde, mes_hasta=@mes_hasta, por_contratacion=@por_contratacion, contemplar_fecha_completa=@contemplar_fecha_completa where id_bonificacion=@id_bonificacion");
                oCon.AsignarParametroDecimal("@porcentaje", Porcentaje);
                oCon.AsignarParametroFecha("@fecha_desde", FechaDesde);
                oCon.AsignarParametroFecha("@fecha_hasta", FechaHasta);
                oCon.AsignarParametroCadena("@nombre", NombreBonificacion);
                oCon.AsignarParametroEntero("@tipo_bonificacion", Tipo_Bonificacion);
                oCon.AsignarParametroEntero("@id_bonificacion", IdBonificacion);
                oCon.AsignarParametroEntero("@cantidad_periodos", cantidad_periodo);
                oCon.AsignarParametroEntero("@mes_desde", mes_desde);
                oCon.AsignarParametroEntero("@mes_hasta", mes_hasta);
                oCon.AsignarParametroEntero("@por_contratacion", por_contratacion);
                oCon.AsignarParametroEntero("@contemplar_fecha_completa", contemplar_fecha_completa);

                oCon.EjecutarComando();
                oCon.ConfirmarTransaccion();
                oCon.DesConectar();
            }
            catch (Exception)
            {
                oCon.CancelarTransaccion();
                oCon.DesConectar();
                throw;
            }
        }

        public void AplicarPorcentajeBonificacionContratacion(DataTable DtSubServicios, DataTable dtMesesPorcentajes, DataTable dtDatosNovedades)
        {
            int mesesAgregar;
            DataRow[] drMontosMensualesSubServicio;
            decimal importeOriginalTotal, importeConDescuentoTotal, porcentajeTotal;
            List<int> listadoIdsBonificacionesContratacion = new List<int>();
            DateTime fechaHastaNovedad = new DateTime();
            DataTable dtControlNovedades = new DataTable();

            dtControlNovedades.Columns.Add("id_bonificacion", typeof(string));
            dtControlNovedades.Columns.Add("id_item", typeof(string));
            dtControlNovedades.Columns.Add("id_item_tipo", typeof(string));


            foreach (DataRow subServicio in DtSubServicios.Rows)
            {
                if (Convert.ToInt32(subServicio["heredado"]) != 1)
                {
                    drMontosMensualesSubServicio = dtMesesPorcentajes.Select("id_usuarios_servicios_sub='" + subServicio["id_usuario_servicio_sub"].ToString() + "' and por_contratacion=1");

                    importeOriginalTotal = 0;
                    importeConDescuentoTotal = 0;
                    porcentajeTotal = 0;
                    listadoIdsBonificacionesContratacion.Clear();

                    foreach (DataRow montoMensual in drMontosMensualesSubServicio)
                    {
                        montoMensual["importe_con_descuento"] = Decimal.Round(Convert.ToDecimal(montoMensual["importe_con_descuento"]) - ((Convert.ToDecimal(montoMensual["importe_con_descuento"]) * Convert.ToDecimal(montoMensual["porcentaje_contratacion"])) / 100), Convert.ToInt16(oConfig.GetValor_N("Cantidad_Decimales")));
                        if (Convert.ToDecimal(montoMensual["importe_original"]) != 0)
                            montoMensual["porcentaje"] = ((Convert.ToDecimal(montoMensual["importe_original"]) - Convert.ToDecimal(montoMensual["importe_con_descuento"])) * 100) / Convert.ToDecimal(montoMensual["importe_original"]);
                        else
                            montoMensual["porcentaje"] = 0;

                        if (dtControlNovedades.Select("id_bonificacion='" + montoMensual["id_bonificacion_contratacion"].ToString() + "' and id_item_tipo='" + montoMensual["nivel_bonificacion_contratacion"].ToString() + "' and (id_item='" + montoMensual["id_usuarios_servicios_contratacion"].ToString() + "' or id_item='" + montoMensual["id_usuarios_servicios_sub_contratacion"].ToString() + "')").Length == 0)
                        {
                            dtControlNovedades.Rows.Add(montoMensual["id_bonificacion_contratacion"], Convert.ToInt32(montoMensual["nivel_bonificacion_contratacion"]) == Convert.ToInt32(Bonificaciones.NIVEL.SUBSERVICIO) ? montoMensual["id_usuarios_servicios_sub_contratacion"] : montoMensual["id_usuarios_servicios_contratacion"], montoMensual["nivel_bonificacion_contratacion"]);
                            fechaHastaNovedad = Convert.ToDateTime(subServicio["fecha_inicio_servicio"]);
                            mesesAgregar = Convert.ToInt32(montoMensual["cantidad_periodos_contratacion"]) * Convert.ToInt32(montoMensual["meses_servicio"]);
                            fechaHastaNovedad = fechaHastaNovedad.AddMonths(mesesAgregar);

                            dtDatosNovedades.Rows.Add(
                                montoMensual["id_usuarios_contratacion"].ToString(),
                                montoMensual["id_usuarios_locaciones_contratacion"].ToString(),
                                montoMensual["id_servicios_contratacion"].ToString(),
                                montoMensual["id_servicios_sub_contratacion"].ToString(),
                                montoMensual["id_servicios_velocidades_contratacion"].ToString(),
                                montoMensual["id_servicios_velocidades_tip_contratacion"].ToString(),
                               subServicio["fecha_inicio_servicio"].ToString(),
                                fechaHastaNovedad.ToString(),
                                montoMensual["porcentaje_contratacion"].ToString(),
                                "0",
                                montoMensual["tipo_contratacion"].ToString(),
                                montoMensual["detalle_contratacion"].ToString(),
                                montoMensual["id_usuarios_servicios_contratacion"].ToString(),
                                montoMensual["id_usuarios_servicios_sub_contratacion"].ToString(),
                                "1",
                                "1",
                                "0",
                                "1",
                                montoMensual["nivel_bonificacion_contratacion"].ToString(),
                                montoMensual["id_bonificacion_contratacion"].ToString()
                          );
                        }
                    }

                    dtMesesPorcentajes.AcceptChanges();
                }
            }

        }

        public void Prorratear(DataTable dtSubServicios, DataTable dtMesesPorcentajes)
        {
            decimal importeOriginalProrrateado, importeDescuentoProrrateado;
            DataRow[] drMesesSubServicio;
            DateTime fechaInicioServicio = new DateTime();

            if (dtSubServicios.Rows.Count > 0)
            {
                foreach (DataRow subServicio in dtSubServicios.Rows)
                {
                    if ((Convert.ToInt32(subServicio["id_servicio_modalidad"]) == Convert.ToInt32(Servicios._Modalidad.MENSUAL) || Convert.ToInt32(subServicio["id_servicio_modalidad"]) == Convert.ToInt32(Servicios._Modalidad.PERIODO)) && Convert.ToInt32(subServicio["heredado"]) != 1)
                    {
                        fechaInicioServicio = Convert.ToDateTime(subServicio["fecha_inicio_servicio"]);

                        if (subServicio["tipo_servicio_sub"].ToString() == "S" && Convert.ToInt32(subServicio["id_tipo_de_sub"]) != Convert.ToInt32(Servicios_Sub.SERVICIO_SUB_TIPOS.DERECHO_DE_CONEXION) && fechaInicioServicio.Day > 1)
                        {
                            drMesesSubServicio = dtMesesPorcentajes.Select("id_usuarios_servicios_sub='" + subServicio["id_usuario_servicio_sub"].ToString() + "' and fecha_desde='" + fechaInicioServicio.ToString() + "'");

                            importeOriginalProrrateado = (Convert.ToDecimal(drMesesSubServicio[0]["importe_original"]) / DateTime.DaysInMonth(fechaInicioServicio.Year, fechaInicioServicio.Month)) * (DateTime.DaysInMonth(fechaInicioServicio.Year, fechaInicioServicio.Month) - fechaInicioServicio.Day);
                            importeDescuentoProrrateado = (Convert.ToDecimal(drMesesSubServicio[0]["importe_con_descuento"]) / DateTime.DaysInMonth(fechaInicioServicio.Year, fechaInicioServicio.Month)) * (DateTime.DaysInMonth(fechaInicioServicio.Year, fechaInicioServicio.Month) - fechaInicioServicio.Day);
                            drMesesSubServicio[0]["importe_original"] = Decimal.Round(importeOriginalProrrateado, Convert.ToInt16(oConfig.GetValor_N("Cantidad_Decimales")));
                            drMesesSubServicio[0]["importe_con_descuento"] = Decimal.Round(importeDescuentoProrrateado, Convert.ToInt16(oConfig.GetValor_N("Cantidad_Decimales")));

                            dtMesesPorcentajes.AcceptChanges();
                        }
                    }
                }
            }
        }

        public void RecalcularImportes(DataTable dtSubServicios, DataTable dtMesesPorcentajes, bool facMensual)
        {
            decimal importeOriginalTotal, importeConDescuentoTotal, porcentajeTotal;
            DataRow[] drMontosMensualesSubServicio;
            if (dtSubServicios.Rows.Count > 0)
            {
                foreach (DataRow subServicio in dtSubServicios.Rows)
                {
                    importeOriginalTotal = 0;
                    importeConDescuentoTotal = 0;
                    porcentajeTotal = 0;
                    if (Convert.ToInt32(subServicio["heredado"]) != 1)
                    {
                        drMontosMensualesSubServicio = dtMesesPorcentajes.Select("id_usuarios_servicios_sub='" + subServicio["id_usuario_servicio_sub"].ToString() + "'");
                        //si viene de facturacion mensual tiene que devolver el monto original y si no (generar comprobante manual por ejemplo), tiene que devolver el monto con la novedad ya descontada
                        foreach (DataRow montoMensual in drMontosMensualesSubServicio)
                        {
                            if (facMensual)
                            {
                                if (!montoMensual["nombre_bonificacion"].ToString().ToLower().Equals("novedades"))
                                {
                                    importeOriginalTotal += Convert.ToDecimal(montoMensual["importe_original"]);
                                    importeConDescuentoTotal += Convert.ToDecimal(montoMensual["importe_con_descuento"]);
                                }
                            }
                            else
                            {
                                importeOriginalTotal += Convert.ToDecimal(montoMensual["importe_original"]);
                                importeConDescuentoTotal += Convert.ToDecimal(montoMensual["importe_con_descuento"]);
                            }
                        }
                        if (importeOriginalTotal != 0)
                            porcentajeTotal = ((importeOriginalTotal - importeConDescuentoTotal) * 100) / importeOriginalTotal;
                        subServicio["importe_original"] = Decimal.Round(importeOriginalTotal, Convert.ToInt16(oConfig.GetValor_N("Cantidad_Decimales")));
                        subServicio["importe_con_descuento"] = Decimal.Round(importeConDescuentoTotal, Convert.ToInt16(oConfig.GetValor_N("Cantidad_Decimales")));
                        //subServicio["porcentaje"] = Decimal.Round(porcentajeTotal, Convert.ToInt16(oConfig.GetValor_N("Cantidad_Decimales")));
                        subServicio["porcentaje"] = porcentajeTotal;
                        dtSubServicios.AcceptChanges();
                    }
                }
            }
        }

        public void SetearPorcentajeImporteParcial(DataTable dtMesesPorcentajes)
        {
            foreach (DataRow fila in dtMesesPorcentajes.Rows)
            {
                fila["porcentaje_parcial"] = fila["porcentaje"];
                fila["importe_con_descuento_parcial"] = Decimal.Round(Convert.ToDecimal(fila["importe_original"]) - ((Convert.ToDecimal(fila["importe_original"]) * Convert.ToDecimal(fila["porcentaje"])) / 100), Convert.ToInt16(oConfig.GetValor_N("Cantidad_Decimales")));
            }
            dtMesesPorcentajes.AcceptChanges();
        }

        public bool AplicarBonificacionesEspeciales(DataTable dtSubServicios, DataTable dtSubServiciosDetalles)
        {
            int idBonificacion = 0;
            decimal montoTotalSubServicio = 0;
            string nombreBonificacion = String.Empty;
            decimal porcentajeBonificacion = 0;
            bool respuesta = true;
            List<int> listaBonificacionesEspeciales = new List<int>();
            DataRow[] drSubServiciosConEspeciales;
            DataRow[] drSubServiciosDetallesFiltrados;
            DataTable dtBonificacionesEspeciales = new DataTable();
            drSubServiciosConEspeciales = dtSubServicios.Select("id_bonificacion_especial>0 and heredado<>1");
            if (drSubServiciosConEspeciales.Count() > 0)
            {

                try
                {
                    foreach (DataRow subServicio in drSubServiciosConEspeciales)
                    {
                        if (listaBonificacionesEspeciales.Contains(Convert.ToInt32(subServicio["id_bonificacion_especial"])) == false)
                            listaBonificacionesEspeciales.Add(Convert.ToInt32(subServicio["id_bonificacion_especial"]));
                    }
                    foreach (int idBonificacionEspecial in listaBonificacionesEspeciales)
                    {
                        if (dtBonificacionesEspeciales.Rows.Count == 0)
                            dtBonificacionesEspeciales = ListarPorId(idBonificacionEspecial);
                        else
                            dtBonificacionesEspeciales.ImportRow(ListarPorId(idBonificacionEspecial).Rows[0]);
                    }
                    if (dtBonificacionesEspeciales.Rows.Count > 0)
                    {
                        foreach (DataRow bonificacionEspecial in dtBonificacionesEspeciales.Rows)
                        {
                            idBonificacion = 0;
                            porcentajeBonificacion = 0;
                            idBonificacion = Convert.ToInt32(bonificacionEspecial["id"]);
                            nombreBonificacion = bonificacionEspecial["nombre"].ToString();
                            //porcentajeBonificacion = Decimal.Round(Convert.ToDecimal(bonificacionEspecial["porcentaje"]), Convert.ToInt16(oConfig.GetValor_N("Cantidad_Decimales")));
                            porcentajeBonificacion = Convert.ToDecimal(bonificacionEspecial["porcentaje"]);
                            foreach (DataRow subServicio in drSubServiciosConEspeciales)
                            {
                                montoTotalSubServicio = 0;
                                if (Convert.ToInt32(subServicio["id_bonificacion_especial"]) == idBonificacion)
                                {
                                    string variable = String.Format("id_usuarios_servicios_sub='{0}' and id_usuarios_servicios_sub_tipos<>'{1}' and tipo_servicio_sub<>'{2}'", subServicio["id_usuario_servicio_sub"].ToString(), Convert.ToInt32(Servicios_Sub.SERVICIO_SUB_TIPOS.DERECHO_DE_CONEXION), "P");
                                    variable.ToString();
                                    try
                                    {
                                        drSubServiciosDetallesFiltrados = dtSubServiciosDetalles.Select(String.Format("id_usuarios_servicios_sub='{0}' and id_usuarios_servicios_sub_tipos<>'{1}' and tipo_servicio_sub<>'{2}'", subServicio["id_usuario_servicio_sub"].ToString(), Convert.ToInt32(Servicios_Sub.SERVICIO_SUB_TIPOS.DERECHO_DE_CONEXION), "P"));
                                        foreach (DataRow detalle in drSubServiciosDetallesFiltrados)
                                        {
                                            if ((Convert.ToInt32(bonificacionEspecial["contemplar_fecha_completa"]) == 0 && (Convert.ToDateTime(bonificacionEspecial["fecha_desde"]).Month <= Convert.ToDateTime(detalle["fecha_desde"]).Month && Convert.ToDateTime(detalle["fecha_desde"]).Month <= Convert.ToDateTime(bonificacionEspecial["fecha_hasta"]).Month)) || (DateTime.Compare(Convert.ToDateTime(bonificacionEspecial["fecha_desde"]), Convert.ToDateTime(detalle["fecha_desde"])) <= 0 && DateTime.Compare(Convert.ToDateTime(detalle["fecha_desde"]), Convert.ToDateTime(bonificacionEspecial["fecha_hasta"])) <= 0))
                                            {
                                                detalle["id_bonificacion"] = idBonificacion;
                                                detalle["nombre_bonificacion"] = nombreBonificacion;
                                                detalle["porcentaje"] = porcentajeBonificacion;
                                                detalle["importe_con_descuento_parcial"] = Decimal.Round((Convert.ToDecimal(detalle["importe_original"]) - ((Convert.ToDecimal(detalle["importe_original"]) * porcentajeBonificacion) / 100)), Convert.ToInt16(oConfig.GetValor_N("Cantidad_Decimales"))).ToString();
                                                detalle["importe_con_descuento"] = detalle["importe_con_descuento_parcial"];
                                            }
                                        }

                                        dtSubServiciosDetalles.AcceptChanges();
                                        subServicio["id_bonificacion"] = idBonificacion;
                                        subServicio["nombre_bonificacion"] = nombreBonificacion;
                                        subServicio["porcentaje"] = porcentajeBonificacion;
                                        drSubServiciosDetallesFiltrados = dtSubServiciosDetalles.Select(String.Format("id_usuarios_servicios_sub='{0}'", subServicio["id_usuario_servicio_sub"].ToString()));
                                        foreach (DataRow detalle in drSubServiciosDetallesFiltrados)
                                            montoTotalSubServicio += Decimal.Round(Convert.ToDecimal(detalle["importe_con_descuento"]), Convert.ToInt16(oConfig.GetValor_N("Cantidad_Decimales")));
                                        subServicio["importe_con_descuento"] = montoTotalSubServicio;
                                    }
                                    catch { }
                                }
                                dtSubServicios.AcceptChanges();
                            }
                        }
                    }
                    respuesta = true;
                }
                catch (Exception)
                {
                    respuesta = false;
                    throw;
                }
            }


            return respuesta;
        }

    }

}