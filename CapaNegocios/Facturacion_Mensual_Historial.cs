using CapaDatos;
using System;
using System.Data;

namespace CapaNegocios
{
    public class Facturacion_Mensual_Historial
    {
        #region Declaraciones
        public Int32 Id { get; set; }
        public Int32 Periodo_Mes { get; set; }
        public Int32 Periodo_Ano { get; set; }
        public String Periodo { get; set; }
        public DateTime Fecha_Desde { get; set; }
        public DateTime Fecha_Hasta { get; set; }
        public Decimal Monto_Original_Total { get; set; }
        public Decimal Monto_Descuento_Total { get; set; }
        public Int32 Borrado { get; set; }

        private Conexion oCon = new Conexion();
        private Comprobantes oComprobante = new Comprobantes();
        private Usuarios_CtaCte oUsuCtaCte = new Usuarios_CtaCte();
        #endregion

        public Int32 Guardar(Facturacion_Mensual_Historial oFacturacionHistorial)
        {
            try
            {
                oCon.Conectar();
                oCon.CrearComando("insert into facturacion_mensual_historial (periodo, periodo_mes, periodo_ano, monto_original_total, monto_descuento_total, fecha_desde, fecha_hasta) " +
                    "VALUES(@periodo, @periodo_mes, @periodo_ano, @monto_original_total, @monto_descuento_total, @fecha_desde, @fecha_hasta); SELECT @@IDENTITY");

                oCon.AsignarParametroCadena("@periodo", oFacturacionHistorial.Periodo);
                oCon.AsignarParametroEntero("@periodo_mes", oFacturacionHistorial.Periodo_Mes);
                oCon.AsignarParametroEntero("@periodo_ano", oFacturacionHistorial.Periodo_Ano);
                oCon.AsignarParametroDecimal("@monto_original_total", oFacturacionHistorial.Monto_Original_Total);
                oCon.AsignarParametroDecimal("@monto_descuento_total", oFacturacionHistorial.Monto_Descuento_Total);
                oCon.AsignarParametroFecha("@fecha_desde", oFacturacionHistorial.Fecha_Desde);
                oCon.AsignarParametroFecha("@fecha_hasta", oFacturacionHistorial.Fecha_Hasta);

                oCon.ComenzarTransaccion();
                oFacturacionHistorial.Id = oCon.EjecutarScalar();
                oCon.ConfirmarTransaccion();
                oCon.DesConectar();
                //comment
            }
            catch (Exception)
            {
                oCon.CancelarTransaccion();
                oCon.DesConectar();
                throw;
            }
            return oFacturacionHistorial.Id;
        }

        public DataTable ListarHistorial(DateTime? fechaDesde = null, DateTime? fechaHasta = null)
        {
            oCon.Conectar();
            string condicion = "";

            if(fechaDesde != null)
                condicion = " AND fecha_desde>= @fecha_desde ";

            if (fechaHasta != null)
                condicion += " AND fecha_desde<=@fecha_hasta ";

            oCon.CrearComando($"SELECT * FROM facturacion_mensual_historial where borrado=0 {condicion} order by id desc");
            
            if(fechaDesde != null)
                oCon.AsignarParametroCadena("@fecha_desde", fechaDesde.Value.ToString("yyyy-MM-dd"));

            if(fechaHasta != null)
                oCon.AsignarParametroCadena("@fecha_hasta", fechaHasta.Value.ToString("yyyy-MM-dd"));

            DataTable dt = oCon.Tabla();

            oCon.DesConectar();

            return dt;
        }

        public DataTable ListarUsuariosCtaCtePorIdFacturacion(int idFacturacion)
        {
            oCon.Conectar();
            oCon.CrearComando("SELECT id, locacion, usuario, codigo_usuario, fecha_movimiento, fecha_desde, fecha_hasta, numero, comprobante_tipo_nombre, importe_original, importe_bonificacion, importe_final, importe_saldo from vw_usuarios_ctacte where generado_facturacion_mensual=@generado_facturacion_mensual and id_facturacion=@id_facturacion");
            oCon.AsignarParametroEntero("@generado_facturacion_mensual", Convert.ToInt32(Usuarios_CtaCte.GENERADO_FACTURACION_MENSUAL.SI));
            oCon.AsignarParametroEntero("@id_facturacion", idFacturacion);

            DataTable dt = oCon.Tabla();

            oCon.DesConectar();

            return dt;
        }

        public DataTable ListarDetallesCtaCtePorIdUsuariosCtaCte(int idUsuariosCtaCte)
        {
            oCon.Conectar();
            oCon.CrearComando("SELECT * from vw_ventas_cobros where id_usuarios_ctacte=@id_usuarios_ctacte");
            oCon.AsignarParametroEntero("@id_usuarios_ctacte", idUsuariosCtaCte);

            DataTable dt = oCon.Tabla();

            oCon.DesConectar();

            return dt;
        }

        public DateTime RetornarUltimaFechaFacturacionMensual()
        {
            DateTime ultimaFecha;
            oCon.Conectar();
            oCon.CrearComando("SELECT max(fecha_hasta) as fecha_hasta FROM facturacion_mensual_historial where borrado=0");
            DataTable dt = oCon.Tabla();

            if (dt.Rows.Count > 0)
            {
                try
                {
                    ultimaFecha = Convert.ToDateTime(dt.Rows[0]["fecha_hasta"]);
                }
                catch
                {
                    ultimaFecha = new DateTime(0001, 01, 01);
                }
            }
            else
                ultimaFecha = new DateTime(0001, 01, 01);
            oCon.DesConectar();

            return ultimaFecha;
        }
        public int GuardarHistorial(int idFacturacion, int idUsuarios, int codigoUsuario, int idLocacion, int idUsuariosServicios, int idUsuariosServiciosSub, int idServicios, int idServiciosSub, int idTipoFacturacion, int idComprobante, int idUsuariosCtaCte, bool debito, int idVelocidad, int idVelocidadTipo)
        {
            int valor = 0;


            try
            {
                oCon.Conectar();
                oCon.CrearComando("insert into facturacion_mensual_detalles(id_facturacion, id_usuarios, codigo_usuario, id_locacion, id_usuarios_servicios, id_usuarios_servicios_sub, id_servicios, id_servicios_sub, id_tipo_facturacion, id_comprobante, id_usuarios_ctacte, fecha_hora ) " +
                    "VALUES(@idfacturacion, @idusuarios, @codigousuario, @idlocacion, @idusuariosservicios, @idusuariosserviciossub, @idservicios, @idserviciossub, @idtipofacturacion, @idcomprobante, @idusuariosctacte, @fechahora); SELECT @@IDENTITY");

                oCon.AsignarParametroEntero("@idfacturacion", idFacturacion);
                oCon.AsignarParametroEntero("@idusuarios", idUsuarios);
                oCon.AsignarParametroEntero("@codigousuario", codigoUsuario);
                oCon.AsignarParametroEntero("@idlocacion", idLocacion);
                oCon.AsignarParametroEntero("@idusuariosservicios", idUsuariosServicios);
                oCon.AsignarParametroEntero("@idusuariosserviciossub", idUsuariosServiciosSub);
                oCon.AsignarParametroEntero("@idservicios", idServicios);
                oCon.AsignarParametroEntero("@idserviciossub", idServiciosSub);
                oCon.AsignarParametroEntero("@idtipofacturacion", idTipoFacturacion);
                oCon.AsignarParametroEntero("@idcomprobante", idComprobante);
                oCon.AsignarParametroEntero("@idusuariosctacte", idUsuariosCtaCte);
                oCon.AsignarParametroCadena("@fechahora", DateTime.Now.ToString());


                oCon.ComenzarTransaccion();
                valor = oCon.EjecutarScalar();
                oCon.ConfirmarTransaccion();
                oCon.DesConectar();
            }
            catch (Exception)
            {
                oCon.CancelarTransaccion();
                oCon.DesConectar();
                throw;
            }
            return valor;
        }

        public DataTable RetornarId(int mes, int ano)
        {
            oCon.Conectar();
            oCon.CrearComando("SELECT * FROM facturacion_mensual_historial where periodo_mes=@mes and periodo_ano=@ano and borrado=0");
            oCon.AsignarParametroEntero("@mes", mes);
            oCon.AsignarParametroEntero("@ano", ano);

            DataTable dt = oCon.Tabla();

            oCon.DesConectar();

            return dt;
        }

        public bool GuardarEstadosServicios()
        {
            try
            {
                oCon.Conectar();
                oCon.CrearComando("INSERT INTO historial_estado_servicios"
                    + " (id_usuario_servicio, id_usuario_servicio_sub,id_servicio, id_servicio_sub, id_velocidad, id_velocidad_tipo,"
                    + " id_servicio_estado, fecha_factura, id_facturacion) "
                    + " SELECT"
                    + " usuarios_servicios.id, usuarios_servicios_sub.id,usuarios_servicios.id_servicios,usuarios_servicios_sub.id_servicios_sub,"
                    + " usuarios_servicios_sub.id_servicios_velocidades, usuarios_servicios_sub.id_servicios_velocidades_tip,usuarios_servicios.id_servicios_estados,"
                    + " usuarios_servicios_sub.fecha_fin,"
                    + " (SELECT MAX(id) FROM facturacion_mensual_historial WHERE facturacion_mensual_historial.borrado = 0) "
                    + " FROM usuarios_servicios_sub "
                    + " LEFT JOIN usuarios_servicios ON usuarios_servicios.id = usuarios_servicios_sub.id_usuarios_servicios");
                oCon.ComenzarTransaccion();
                oCon.EjecutarComando();
                oCon.ConfirmarTransaccion();
                oCon.DesConectar();
                return true;
            }
            catch (Exception)
            {
                oCon.DesConectar();
                return false;

            }
        }
        public bool Eliminar(int id)
        {
            try
            {
                oCon.Conectar();
                oCon.CrearComando("update facturacion_mensual_historial set borrado=1 where id=@id_fac");
                oCon.AsignarParametroEntero("@id_fac", id);
                oCon.ComenzarTransaccion();
                oCon.EjecutarComando();
                oCon.ConfirmarTransaccion();
                oCon.DesConectar();
                return true;
            }
            catch (Exception)
            {
                oCon.CancelarTransaccion();
                oCon.DesConectar();
                return false;
            }
        }
    }
}
