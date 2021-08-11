using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CapaNegocios
{
    public class Usuarios_CtaCte_Det
    {
        #region Propiedades
        public Int32 Id { get; set; }
        public Int32 Id_Usuarios { get; set; }
        public Int32 Id_Usuarios_CtaCte { get; set; }
        public Int32 Id_Usuarios_Locaciones { get; set; }
        public Int32 Id_Usuarios_Servicios { get; set; }
        public Int32 Id_Usuarios_Servicios_sub { get; set; }
        public Int32 Id_Zonas { get; set; }
        public Int32 Id_Servicios { get; set; }
        public Int32 Id_Tipo { get; set; }
        public String Tipo { get; set; }
        public Decimal Importe_Original { get; set; }
        public Decimal Importe_Punitorio { get; set; }
        public Decimal Importe_Saldo { get; set; }
        public Decimal Importe_Bonificacion { get; set; }
        public Decimal Importe_Final { get; set; }
        public Int32 Id_Velocidades_Tip { get; set; }
        public Int32 Id_Velocidades { get; set; }
        public Int32 Requiere_IP { get; set; }
        public Int32 Cantidad_Periodos { get; set; }
        public DateTime Fecha_Desde { get; set; }
        public DateTime Fecha_Hasta { get; set; }
        public Int32 Periodo_Mes { get; set; }
        public Int32 Periodo_Ano { get; set; }
        public Int32 Id_bonificacion_Aplicada { get; set; }
        public Decimal Porcentaje_Bonificacion { get; set; }
        public String Nombre_Bonificacion { get; set; }
        public String Detalles { get; set; }
        public Int32 Id_Tipo_Registro_Cta_Cte_Det { get; set; }
        public Int32 Id_Iva_Alicuotas { get; set; }
        public Int32 Id_Facturacion { get; set; }
        public Int32 Id_Presentacion { get; set; }
        public Int32 Ano_Presentacion { get; set; }
        public Int32 Mes_Presentacion { get; set; }
        public Int32 Id_Debito_asociado { get; set; } = 0;
        public decimal Importe_Provincial { get; set; } = 0;
        public decimal Importe_Presentado { get; set; } = 0;
        public decimal Cantidad { get; set; } = 1;
        public Int32 Id_Debito_Estado { get; set; } = 0;

        public Int32 Id_Tipo_Facturacion { get; set; }
        private Conexion oCon = new Conexion();

        public List<Usuarios_Ctacte_Det_Extra> ListaExtras = new List<Usuarios_Ctacte_Det_Extra>();

        public enum TIPO_REGISTRO_CTACTEDET
        {
            DETALLE = 0,
            BONIFICACION_MANUAL = 1,
            DEUDA_ANEXADA = 2,
            NOVEDAD = 3
        }

        public enum TIPO_CONSULTA_CTACTE_DET
        {
            CON_DEUDA = 0,
            ID_CTACTE = 1,
            PAGA = 2
        }
        public enum TIPO_LISTAR
        {
            PERIODO = 0,
            FECHA_MOVIMIENTO = 1,
            FECHA_INICIO_SERVICIO = 2
        }
        public enum DEBITO_ESTADO
        {
            PRESENTADO = 1,
            RECHAZADO = 2,
        }
        #endregion


        public DataTable ListaCompletaDeServicios(TIPO_LISTAR tipo, int idFacturacion, DateTime fecha)
        {
            DateTime fechaHasta = new DateTime(fecha.Year, fecha.Month, DateTime.DaysInMonth(fecha.Year, fecha.Month));
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                string condicion = "";
                if (tipo == TIPO_LISTAR.PERIODO)
                {
                    condicion = " usuarios_ctacte.id_facturacion = @idFacturacion ";
                }
                else if (tipo == TIPO_LISTAR.FECHA_MOVIMIENTO)
                {
                    condicion = " usuarios_ctacte.fecha_movimiento BETWEEN @fechaDesde AND @fechaHasta ";
                }
                else if (tipo == TIPO_LISTAR.FECHA_INICIO_SERVICIO)
                {
                    condicion = " usuarios_ctacte_det.fecha_desde BETWEEN @fechaDesde AND @fechaHasta ";
                }

                string consulta = "select usuarios.codigo as codigo_usuarios, concat_ws(', ', usuarios.apellido, usuarios.nombre) as nombre_usuario , "
                                + " usuarios_ctacte.id_usuarios, usuarios_ctacte.id_comprobantes, usuarios_ctacte.id_comprobantes_tipo, "
                                + " comprobantes_tipo.nombre as tipo_comprobante , usuarios_ctacte_det.id_usuarios_locaciones, usuarios_ctacte_det.id_usuarios_ctacte,"
                                + " servicios_grupos.id as id_servicio_grupo, servicios_grupos.nombre as servicio_grupo,"
                                + " servicios_tipos.id as id_servicio_tipo, servicios_tipos.nombre as servicio_tipo"
                                + " ,servicios.id as id_servicio , servicios.descripcion as servicio, usuarios_ctacte_det.id_tipo as id_sub,"
                                + " CASE usuarios_ctacte_det.Tipo"
                                + " WHEN 'S' THEN(SELECT Descripcion FROM servicios_sub WHERE Id = usuarios_ctacte_det.Id_Tipo)"
                                + " WHEN 'E' THEN(SELECT nombre FROM equipos_tipos WHERE Id = usuarios_ctacte_det.Id_Tipo)"
                                + " WHEN 'P' THEN(SELECT nombre from partes_fallas where id = usuarios_ctacte_det.Id_Tipo)"
                                + " END AS sub_servicio,"
                                + " usuarios_ctacte.descripcion, usuarios_ctacte_det.importe_original,usuarios_ctacte_det.importe_punitorio,  "
                                + " usuarios_ctacte_det.importe_saldo, usuarios_ctacte_det.importe_bonificacion,  usuarios_ctacte_det.importe_pago, "
                                + " usuarios_ctacte_det.importe_provincial, cast(usuarios_ctacte_det.fecha_desde as char(20)) as fecha_desde, "
                                + " cast(usuarios_ctacte_det.fecha_hasta as char(20)) as fecha_hasta,usuarios_ctacte_det.id_bonificacion_aplicada, "
                                + " usuarios_ctacte_det.nombre_bonificacion ,  usuarios_ctacte_det.id_tipo_facturacion, usuarios_ctacte.id_facturacion, "
                                + " usuarios_ctacte.id_origen, usuarios.presentacion"
                                + " from usuarios_ctacte_det"
                                + " left join usuarios_ctacte on usuarios_ctacte.id = usuarios_ctacte_det.id_usuarios_ctacte"
                                + " left join comprobantes_tipo on comprobantes_tipo.id = usuarios_ctacte.id_comprobantes_tipo"
                                + " left join usuarios on usuarios.id = usuarios_ctacte.id_usuarios"
                                + " left join servicios on usuarios_ctacte_det.id_servicios = servicios.id"
                                + " left join servicios_tipos on servicios_tipos.id = servicios.id_servicios_tipos"
                                + " left join servicios_grupos on servicios_grupos.id = servicios_tipos.id_servicios_grupos"
                                + $" WHERE usuarios_ctacte_det.borrado = 0 and usuarios_ctacte.borrado = 0 and {condicion}";
                oCon.CrearComando(consulta);

                if (tipo == TIPO_LISTAR.PERIODO)
                {
                    oCon.AsignarParametroEntero("@idFacturacion", idFacturacion);
                }
                else if (tipo == TIPO_LISTAR.FECHA_INICIO_SERVICIO || tipo == TIPO_LISTAR.FECHA_MOVIMIENTO)
                {
                    oCon.AsignarParametroFecha("@fechaDesde", fecha);
                    oCon.AsignarParametroFecha("@fechaHasta", fechaHasta);
                }

                dt = oCon.Tabla();
                oCon.DesConectar();
            }
            catch (Exception)
            {
                oCon.DesConectar();
                throw;
            }
            return dt;
        }

        public Int32 Guardar(Usuarios_CtaCte_Det oCtaCteDet)
        {
            try
            {
                oCon.Conectar();
                int Id_Tipo_Facturacion;
                try
                {
                    oCon.CrearComando($"SELECT usuarios_servicios.Id_Tipo_Facturacion FROM usuarios_servicios WHERE id = {oCtaCteDet.Id_Usuarios_Servicios}");
                    Id_Tipo_Facturacion = oCon.EjecutarScalar();
                }
                catch
                {
                    Id_Tipo_Facturacion = 0;
                }

                oCon.CrearComando("INSERT INTO Usuarios_CtaCte_Det(Id_Usuarios_CtaCte, Id_Usuarios_Locaciones, Id_Zonas, " +
                  "Id_Servicios, Id_Tipo, Tipo, Importe_Original, Importe_Punitorio, Importe_Saldo, Importe_Bonificacion, " +
                  "Id_Usuarios_Servicios, Id_Velocidades_Tip, Id_Velocidades, Requiere_IP, Cantidad_Periodos,id_usuarios_servicios_sub, " +
                  "fecha_desde, fecha_hasta,periodo_mes,periodo_ano,id_bonificacion_aplicada,Porcentaje_Bonificacion,Nombre_Bonificacion, Detalles, " +
                  "IdTipoRegistroCtaCteDet, importe_ajuste_manual, id_iva_alicuotas,id_presentacion,id_facturacion,ano_presentacion,mes_presentacion,id_debito_asociado,importe_provincial,importe_presentado,importe_final, id_tipo_facturacion, Cantidad) " +
                  "VALUES(@ctacte, @locacion, @zona, @servicio, @idtipo, @tipo, @original, @punitorio, @saldo, @bonificacion, " +
                  "@ususer, @velocidad_tip, @velocidad, @requiere_ip, @cantidad,@id_usu_ser_sub, @fecha_desde, @fecha_hasta, " +
                  "@periodo_mes, @periodo_ano,@id_bonificacion_aplicada,@porcentaje_bonificacion,@nombre_bonificacion, @detalles, @id_tipo_cta_cte_det, @importe_ajuste_manual, @id_iva_alicuotas,@id_presentacion,@id_facturacion,@ano_presentacion,@mes_presentacion,@id_debito,@importe_provincial,@importe_presentado,@importe_final, @tipoFac, @cant_unidades) ; SELECT @@IDENTITY");

                oCon.AsignarParametroEntero("@ctacte", oCtaCteDet.Id_Usuarios_CtaCte);
                oCon.AsignarParametroEntero("@locacion", oCtaCteDet.Id_Usuarios_Locaciones);
                oCon.AsignarParametroEntero("@zona", oCtaCteDet.Id_Zonas);
                oCon.AsignarParametroEntero("@servicio", oCtaCteDet.Id_Servicios);
                oCon.AsignarParametroEntero("@idtipo", oCtaCteDet.Id_Tipo);
                oCon.AsignarParametroCadena("@tipo", oCtaCteDet.Tipo);
                oCon.AsignarParametroDecimal("@original", oCtaCteDet.Importe_Original);
                oCon.AsignarParametroDecimal("@punitorio", oCtaCteDet.Importe_Punitorio);
                oCon.AsignarParametroDecimal("@saldo", oCtaCteDet.Importe_Saldo);
                oCon.AsignarParametroDecimal("@bonificacion", oCtaCteDet.Importe_Bonificacion);
                oCon.AsignarParametroEntero("@ususer", oCtaCteDet.Id_Usuarios_Servicios);
                oCon.AsignarParametroEntero("@velocidad_tip", oCtaCteDet.Id_Velocidades_Tip);
                oCon.AsignarParametroEntero("@velocidad", oCtaCteDet.Id_Velocidades);
                oCon.AsignarParametroEntero("@requiere_ip", oCtaCteDet.Requiere_IP);
                oCon.AsignarParametroEntero("@cantidad", oCtaCteDet.Cantidad_Periodos);
                oCon.AsignarParametroDecimal("@id_usu_ser_sub", oCtaCteDet.Id_Usuarios_Servicios_sub);
                oCon.AsignarParametroFecha("@fecha_desde", oCtaCteDet.Fecha_Desde);
                oCon.AsignarParametroFecha("@fecha_hasta", oCtaCteDet.Fecha_Hasta);
                oCon.AsignarParametroEntero("@periodo_mes", oCtaCteDet.Periodo_Mes);
                oCon.AsignarParametroEntero("@periodo_ano", oCtaCteDet.Periodo_Ano);
                oCon.AsignarParametroEntero("@id_bonificacion_aplicada", oCtaCteDet.Id_bonificacion_Aplicada);
                oCon.AsignarParametroDecimal("@porcentaje_bonificacion", oCtaCteDet.Porcentaje_Bonificacion);
                oCon.AsignarParametroCadena("@nombre_bonificacion", oCtaCteDet.Nombre_Bonificacion);
                oCon.AsignarParametroEntero("@tipoFac", Id_Tipo_Facturacion);
                oCon.AsignarParametroDecimal("@cant_unidades", Cantidad);

                if (String.IsNullOrEmpty(oCtaCteDet.Detalles))
                    oCon.AsignarParametroCadena("@detalles", String.Empty);
                else
                    oCon.AsignarParametroCadena("@detalles", oCtaCteDet.Detalles);

                if (String.IsNullOrEmpty(oCtaCteDet.Id_Tipo_Registro_Cta_Cte_Det.ToString()))
                    oCon.AsignarParametroEntero("@id_tipo_cta_cte_det", 0);
                else
                    oCon.AsignarParametroEntero("@id_tipo_cta_cte_det", oCtaCteDet.Id_Tipo_Registro_Cta_Cte_Det);

                if (String.IsNullOrEmpty(oCtaCteDet.Id_Iva_Alicuotas.ToString()) || oCtaCteDet.Id_Iva_Alicuotas.ToString() == "0")
                    oCon.AsignarParametroEntero("@id_iva_alicuotas", Convert.ToInt32(Iva_Alicuotas.IVA_ALICUOTAS.IVA21));
                else
                    oCon.AsignarParametroEntero("@id_iva_alicuotas", oCtaCteDet.Id_Iva_Alicuotas);

                oCon.AsignarParametroDecimal("@importe_ajuste_manual", oCtaCteDet.Importe_Saldo);

                oCon.AsignarParametroDecimal("@id_presentacion", oCtaCteDet.Id_Presentacion);
                oCon.AsignarParametroDecimal("@id_facturacion", oCtaCteDet.Id_Facturacion);
                oCon.AsignarParametroDecimal("@ano_presentacion", oCtaCteDet.Ano_Presentacion);
                oCon.AsignarParametroDecimal("@mes_presentacion", oCtaCteDet.Mes_Presentacion);
                oCon.AsignarParametroEntero("@id_debito", oCtaCteDet.Id_Debito_asociado);
                oCon.AsignarParametroDecimal("@importe_provincial", oCtaCteDet.Importe_Provincial);
                oCon.AsignarParametroDecimal("@importe_presentado", oCtaCteDet.Importe_Presentado);
                oCon.AsignarParametroDecimal("@importe_final", oCtaCteDet.Importe_Final);

                oCon.ComenzarTransaccion();
                oCtaCteDet.Id = oCon.EjecutarScalar();
                oCon.ConfirmarTransaccion();
                oCon.DesConectar();
            }
            catch (Exception)
            {
                oCon.CancelarTransaccion();
                oCon.DesConectar();
                throw;
            }
            return oCtaCteDet.Id;
        }

        public bool Guardar(List<Usuarios_CtaCte_Det> detalles, out string salida)
        {
            try
            {
                oCon.Conectar();
                oCon.ComenzarTransaccion();

                foreach (Usuarios_CtaCte_Det item in detalles)
                {
                    oCon.CrearComando("INSERT INTO Usuarios_CtaCte_Det(Id_Usuarios_CtaCte, Id_Usuarios_Locaciones, Id_Zonas, " +
                      "Id_Servicios, Id_Tipo, Tipo, Importe_Original, Importe_Punitorio, Importe_Saldo, Importe_Bonificacion, " +
                      "Id_Usuarios_Servicios, Id_Velocidades_Tip, Id_Velocidades, Requiere_IP, Cantidad_Periodos,id_usuarios_servicios_sub, " +
                      "fecha_desde, fecha_hasta,periodo_mes,periodo_ano,id_bonificacion_aplicada,Porcentaje_Bonificacion,Nombre_Bonificacion, Detalles, " +
                      "IdTipoRegistroCtaCteDet, importe_ajuste_manual, id_iva_alicuotas,id_presentacion,id_facturacion,ano_presentacion,mes_presentacion,id_debito_asociado,importe_provincial,importe_presentado,importe_final, id_tipo_facturacion, Cantidad) " +
                      "VALUES(@ctacte, @locacion, @zona, @servicio, @idtipo, @tipo, @original, @punitorio, @saldo, @bonificacion, " +
                      "@ususer, @velocidad_tip, @velocidad, @requiere_ip, @cantidad,@id_usu_ser_sub, @fecha_desde, @fecha_hasta, " +
                      "@periodo_mes, @periodo_ano,@id_bonificacion_aplicada,@porcentaje_bonificacion,@nombre_bonificacion, @detalles, @id_tipo_cta_cte_det, @importe_ajuste_manual, @id_iva_alicuotas,@id_presentacion,@id_facturacion,@ano_presentacion,@mes_presentacion,@id_debito,@importe_provincial,@importe_presentado,@importe_final, @tipoFac, @cant_unidades) ; SELECT @@IDENTITY");

                    oCon.AsignarParametroEntero("@ctacte", item.Id_Usuarios_CtaCte);
                    oCon.AsignarParametroEntero("@locacion", item.Id_Usuarios_Locaciones);
                    oCon.AsignarParametroEntero("@zona", item.Id_Zonas);
                    oCon.AsignarParametroEntero("@servicio", item.Id_Servicios);
                    oCon.AsignarParametroEntero("@idtipo", item.Id_Tipo);
                    oCon.AsignarParametroCadena("@tipo", item.Tipo);
                    oCon.AsignarParametroDecimal("@original", item.Importe_Original);
                    oCon.AsignarParametroDecimal("@punitorio", item.Importe_Punitorio);
                    oCon.AsignarParametroDecimal("@saldo", item.Importe_Saldo);
                    oCon.AsignarParametroDecimal("@bonificacion", item.Importe_Bonificacion);
                    oCon.AsignarParametroEntero("@ususer", item.Id_Usuarios_Servicios);
                    oCon.AsignarParametroEntero("@velocidad_tip", item.Id_Velocidades_Tip);
                    oCon.AsignarParametroEntero("@velocidad", item.Id_Velocidades);
                    oCon.AsignarParametroEntero("@requiere_ip", item.Requiere_IP);
                    oCon.AsignarParametroEntero("@cantidad", item.Cantidad_Periodos);
                    oCon.AsignarParametroDecimal("@id_usu_ser_sub", item.Id_Usuarios_Servicios_sub);
                    oCon.AsignarParametroFecha("@fecha_desde", item.Fecha_Desde);
                    oCon.AsignarParametroFecha("@fecha_hasta", item.Fecha_Hasta);
                    oCon.AsignarParametroEntero("@periodo_mes", item.Periodo_Mes);
                    oCon.AsignarParametroEntero("@periodo_ano", item.Periodo_Ano);
                    oCon.AsignarParametroEntero("@id_bonificacion_aplicada", item.Id_bonificacion_Aplicada);
                    oCon.AsignarParametroDecimal("@porcentaje_bonificacion", item.Porcentaje_Bonificacion);
                    oCon.AsignarParametroCadena("@nombre_bonificacion", item.Nombre_Bonificacion);
                    oCon.AsignarParametroEntero("@tipoFac", item.Id_Tipo_Facturacion);
                    oCon.AsignarParametroDecimal("@cant_unidades", Cantidad);

                    if (String.IsNullOrEmpty(item.Detalles))
                        oCon.AsignarParametroCadena("@detalles", String.Empty);
                    else
                        oCon.AsignarParametroCadena("@detalles", item.Detalles);

                    if (String.IsNullOrEmpty(item.Id_Tipo_Registro_Cta_Cte_Det.ToString()))
                        oCon.AsignarParametroEntero("@id_tipo_cta_cte_det", 0);
                    else
                        oCon.AsignarParametroEntero("@id_tipo_cta_cte_det", item.Id_Tipo_Registro_Cta_Cte_Det);

                    if (String.IsNullOrEmpty(item.Id_Iva_Alicuotas.ToString()) || item.Id_Iva_Alicuotas.ToString() == "0")
                        oCon.AsignarParametroEntero("@id_iva_alicuotas", Convert.ToInt32(Iva_Alicuotas.IVA_ALICUOTAS.IVA21));
                    else
                        oCon.AsignarParametroEntero("@id_iva_alicuotas", item.Id_Iva_Alicuotas);

                    oCon.AsignarParametroDecimal("@importe_ajuste_manual", item.Importe_Saldo);

                    oCon.AsignarParametroDecimal("@id_presentacion", item.Id_Presentacion);
                    oCon.AsignarParametroDecimal("@id_facturacion", item.Id_Facturacion);
                    oCon.AsignarParametroDecimal("@ano_presentacion", item.Ano_Presentacion);
                    oCon.AsignarParametroDecimal("@mes_presentacion", item.Mes_Presentacion);
                    oCon.AsignarParametroEntero("@id_debito", item.Id_Debito_asociado);
                    oCon.AsignarParametroDecimal("@importe_provincial", item.Importe_Provincial);
                    oCon.AsignarParametroDecimal("@importe_presentado", item.Importe_Presentado);
                    oCon.AsignarParametroDecimal("@importe_final", item.Importe_Final);

                    item.Id = oCon.EjecutarScalar();
                    
                }
                oCon.ConfirmarTransaccion();
                oCon.DesConectar();
                salida = "";
                return true;
            }
            catch (Exception c)
            {
                oCon.CancelarTransaccion();
                oCon.DesConectar();
                salida = c.ToString();
                return false;
            }
           
        }

        public DataTable ListarCtacteDetConSaldo(bool bonificacion, int idUsuarioLocacion = 0, int idUsuario = 0)
        {
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                string condicion;

                if (idUsuarioLocacion > 0)
                    condicion = string.Format(" AND usuarios_locaciones.id = {0} ", idUsuarioLocacion);
                else if (idUsuario > 0)
                    condicion = string.Format(" AND usuarios_locaciones.id_usuarios = {0} ", idUsuario);
                else
                    condicion = "";

                if (bonificacion)
                {
                    oCon.CrearComando(string.Format("SELECT usuarios_ctacte.id AS id_ctacte, usuarios_locaciones.id_usuarios, usuarios_ctacte_det.Id AS id_ctacte_det, usuarios_ctacte_det.Id_Servicios,"
                        + " usuarios_ctacte_det.Importe_Saldo AS importe_saldo_det, usuarios_ctacte_det.Importe_Punitorio,"
                        + " usuarios_ctacte_det.Fecha_Desde,"
                        + " usuarios_ctacte_det.Fecha_hasta, usuarios_locaciones.id AS id_usu_locacion, usuarios_ctacte_det.id_debito_asociado, usuarios_ctacte.id_comprobantes_tipo"
                        + " FROM usuarios_ctacte_det"
                        + " INNER JOIN usuarios_ctacte ON usuarios_ctacte.Id = usuarios_ctacte_det.Id_Usuarios_CtaCte"
                        + " INNER JOIN usuarios_locaciones ON usuarios_locaciones.Id = usuarios_ctacte.Id_Usuarios_Locacion"
                        + " WHERE usuarios_ctacte_det.importe_saldo != 0 AND usuarios_ctacte.importe_saldo != 0 "
                        + " AND usuarios_ctacte_det.borrado = 0 AND usuarios_ctacte.borrado = 0 {0}"
                        + " ORDER BY id_usu_locacion, id_ctacte ASC", condicion));
                }
                else
                {
                    oCon.CrearComando(string.Format("SELECT usuarios_ctacte.id AS id_ctacte, usuarios_locaciones.id_usuarios, usuarios_ctacte_det.Id AS id_ctacte_det, usuarios_ctacte_det.Id_Servicios,"
                        + " usuarios_ctacte_det.Importe_Saldo AS importe_saldo_det, usuarios_ctacte_det.Importe_Punitorio,"
                        + " usuarios_ctacte_det.Fecha_Desde,"
                        + " usuarios_ctacte_det.Fecha_hasta, usuarios_servicios.Id_Servicios_Categorias, usuarios_locaciones.id AS id_usu_locacion, usuarios_ctacte_det.id_debito_asociado, usuarios_ctacte.id_comprobantes_tipo"
                        + " FROM usuarios_ctacte_det"
                        + " INNER JOIN usuarios_ctacte ON usuarios_ctacte.Id = usuarios_ctacte_det.Id_Usuarios_CtaCte"
                        + " LEFT JOIN usuarios_servicios ON usuarios_servicios.Id = usuarios_ctacte_det.Id_Usuarios_Servicios"
                        + " INNER JOIN usuarios_locaciones ON usuarios_locaciones.Id = usuarios_ctacte.Id_Usuarios_Locacion"
                        + " WHERE usuarios_ctacte_det.importe_saldo != 0 AND usuarios_ctacte.importe_saldo != 0"
                        + " AND usuarios_ctacte_det.borrado = 0 AND usuarios_ctacte.borrado = 0 {0}"
                        + " ORDER BY id_usu_locacion, id_ctacte ASC", condicion));
                }
                dt = oCon.Tabla();
                oCon.DesConectar();
            }
            catch (Exception ex)
            {
                oCon.DesConectar();
                throw ex;
            }
            return dt;
        }

        public int LiberarDeudaAnexada(int idUsuariosCtaCte)
        {
            DataTable dt = new DataTable();
            int codigoRetorno = 0;
            try
            {
                oCon.Conectar();
                oCon.CrearComando("UPDATE usuarios_ctacte_det SET id_debito_asociado=0, mes_presentacion=0, ano_presentacion=0 WHERE id_usuarios_ctacte=@id");
                oCon.AsignarParametroEntero("@id", idUsuariosCtaCte);
                oCon.ComenzarTransaccion();
                oCon.EjecutarComando();
                oCon.ConfirmarTransaccion();
                oCon.DesConectar();
            }
            catch (Exception)
            {
                codigoRetorno = -1;
                oCon.CancelarTransaccion();
                oCon.DesConectar();
                throw;
            }
            return codigoRetorno;
        }

        public int ActualizarFacturacionDebitos(int idFacturacionMensual, int mes, int anio)
        {
            int resu = 0;
            try
            {
                oCon.Conectar();
                oCon.CrearComando("UPDATE usuarios_ctacte_det SET id_facturacion=@id where id_facturacion=0 and mes_presentacion=@mes and ano_presentacion=@anio");
                oCon.AsignarParametroEntero("@id", idFacturacionMensual);
                oCon.AsignarParametroEntero("@mes", mes);
                oCon.AsignarParametroEntero("@anio", anio);
                oCon.ComenzarTransaccion();
                oCon.EjecutarComando();
                oCon.ConfirmarTransaccion();
                resu = 0;
            }
            catch (Exception)
            {
                oCon.DesConectar();
                resu = -1;

            }
            if (resu == 0)
            {
                try
                {
                    DataTable dt = new DataTable();
                    oCon.CrearComando("SELECT id from presentacion_debitos where borrado =0 order by id desc limit 1");
                    dt = oCon.Tabla();
                    int idUltimaPresentacion = Convert.ToInt32(dt.Rows[0]["id"]);
                    oCon.CrearComando("update usuarios_ctacte"
                        + " LEFT JOIN usuarios_Ctacte_det ON usuarios_Ctacte_det.id_usuarios_ctacte = usuarios_ctacte.Id"
                        + " set usuarios_Ctacte.id_facturacion = @idfacturacion"
                        + " WHERE usuarios_ctacte_det.id_presentacion = @idUltimaPresentacion");
                    oCon.AsignarParametroEntero("@idfacturacion", idFacturacionMensual);
                    oCon.AsignarParametroEntero("@idUltimaPresentacion", idUltimaPresentacion);
                    oCon.ComenzarTransaccion();
                    oCon.EjecutarComando();
                    oCon.ConfirmarTransaccion();
                    oCon.DesConectar();
                    return 0;
                }
                catch (Exception)
                {
                    oCon.DesConectar();
                    return -1;
                }
            }
            else
                return -1;
        }

        public bool Edicion(DataTable dataCtaCteDet, Int32 idComprobante, Int32 idCtaCte)
        {
            string resultado;
            try
            {
                oCon.Conectar();
                foreach (DataRow dr in dataCtaCteDet.Rows)
                {
                    oCon.CrearComando("UPDATE usuarios_ctacte_det SET importe_original = @original, importe_punitorio = @punitorio, importe_bonificacion = @bonificacion, importe_provincial = @provincia," +
                        "importe_saldo = @saldo WHERE id = @id");

                    oCon.AsignarParametroDecimal("@original", Convert.ToDecimal(dr["importe_original"]));
                    oCon.AsignarParametroDecimal("@punitorio", Convert.ToDecimal(dr["importe_punitorio"]));
                    oCon.AsignarParametroDecimal("@bonificacion", Convert.ToDecimal(dr["importe_bonificacion"]));
                    oCon.AsignarParametroDecimal("@provincia", Convert.ToDecimal(dr["importe_provincial"]));
                    oCon.AsignarParametroDecimal("@saldo", Convert.ToDecimal(dr["importe_saldo"]));
                    oCon.AsignarParametroDecimal("@id", Convert.ToDecimal(dr["id"]));
                    oCon.EjecutarComando();
                }
                oCon.DesConectar();

            }
            catch (Exception c)
            {
                oCon.DesConectar();
                return false;
            }
            if (ActualizarImportesCtaCte(idComprobante, idCtaCte, out resultado))
            {
                object sumObject;
                sumObject = dataCtaCteDet.Compute("Sum(importe_provincial)", string.Empty);
                if ((decimal)sumObject != 0)
                    ActulizarPercepcion(idCtaCte, 0, out resultado);
                else
                    ActulizarPercepcion(idCtaCte, 1, out resultado);

                return true;
            }
            else
                return false;

        }

        public bool ActualizarDetallesConRecibos(int idCtaCteDet, decimal importePago, decimal importeProvincial, decimal importeSaldo, out string salida)
        {
            try
            {
                oCon.Conectar();
                oCon.CrearComando("UPDATE usuarios_ctacte_det set importe_pago =@importepago,importe_provincial = @importeii ,importe_saldo=@importesaldo WHERE Id = @id");
                oCon.AsignarParametroEntero("@id", idCtaCteDet);
                oCon.AsignarParametroDecimal("@importepago", importePago);
                oCon.AsignarParametroDecimal("@importeii", importeProvincial);
                oCon.AsignarParametroDecimal("@importesaldo", importeSaldo);
                oCon.ComenzarTransaccion();
                oCon.EjecutarComando();
                oCon.ConfirmarTransaccion();
                oCon.DesConectar();
                salida = "";
                return true;
            }
            catch (Exception x)
            {
                oCon.CancelarTransaccion();
                oCon.DesConectar();
                salida = x.Message;
                return false;

            }
        }

        public bool ActualizarImportesCtaCte(int idComprobante, int idCtaCte, out string mensaje)
        {
            try
            {
                oCon.Conectar();
                oCon.CrearComando("call ActualizarImportesCtaCte(@idComprobante, @idUsuariosCtaCte)");
                oCon.AsignarParametroEntero("@idComprobante", idComprobante);
                oCon.AsignarParametroEntero("@idUsuariosCtaCte", idCtaCte);
                oCon.EjecutarComando();
                oCon.DesConectar();
                mensaje = "";
                return true;
            }
            catch (Exception c)
            {
                oCon.DesConectar();
                mensaje = c.Message;
                return false;
            }
        }

        public bool ActulizarPercepcion(int idCtaCte, int percepcion, out string mensaje)
        {
            try
            {
                oCon.Conectar();
                oCon.CrearComando("UPDATE usuarios_ctacte set percepcion=@percepcion WHERE id=@idCta");
                oCon.AsignarParametroEntero("@percepcion", percepcion);
                oCon.AsignarParametroEntero("@idCta", idCtaCte);
                oCon.ComenzarTransaccion();
                oCon.EjecutarComando();
                oCon.ConfirmarTransaccion();
                oCon.DesConectar();
                mensaje = "";
                return true;
            }
            catch (Exception c)
            {
                oCon.CancelarTransaccion();
                oCon.DesConectar();
                mensaje = c.Message;
                return false;
            }
        }

        public void ActualizarDebitoPresentacion(int idUsuariosCtaCte, int idUsuariosServicios, int idUsuariosCtaCteDet, int idDebito, int mes, int año)
        {
            try
            {
                string consulta = String.Empty;
                if (idUsuariosCtaCteDet > 0)
                    consulta = String.Format("UPDATE usuarios_ctacte_det SET id_debito_asociado={0}, mes_presentacion={1}, ano_presentacion={2} WHERE id={3}", idDebito, mes, año, idUsuariosCtaCteDet);
                else if (idUsuariosServicios > 0)
                    consulta = String.Format("UPDATE usuarios_ctacte_det SET id_debito_asociado={0}, mes_presentacion={1}, ano_presentacion={2} WHERE id_usuarios_ctacte={3} and id_usuarios_servicios={4}", idDebito, mes, año, idUsuariosCtaCte, idUsuariosServicios);
                else
                    consulta = String.Format("UPDATE usuarios_ctacte_det SET id_debito_asociado={0}, mes_presentacion={1}, ano_presentacion={2} WHERE id_usuarios_ctacte={3}", idDebito, mes, año, idUsuariosCtaCte);

                oCon.Conectar();
                oCon.CrearComando(consulta);
                oCon.ComenzarTransaccion();
                oCon.EjecutarComando();
                oCon.ConfirmarTransaccion();

                oCon.CrearComando("UPDATE usuarios_ctacte SET rechazado=0 WHERE id=@idctacte");
                oCon.AsignarParametroEntero("@idctacte", idUsuariosCtaCte);
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

        public void ActualizarDebitoPresentacion(int idUsuariosCtaCte, int idUsuariosServicios, int idUsuariosCtaCteDet, int idDebito, int mes, int año, int id_presentacion = 0)
        {
            try
            {
                string consulta = String.Empty;
                if (idUsuariosCtaCteDet > 0)
                    consulta = String.Format("UPDATE usuarios_ctacte_det SET id_debito_asociado={0}, mes_presentacion={1}, ano_presentacion={2}, id_presentacion={3} WHERE id={4}", idDebito, mes, año, id_presentacion, idUsuariosCtaCteDet);
                else if (idUsuariosServicios > 0)
                    consulta = String.Format("UPDATE usuarios_ctacte_det SET id_debito_asociado={0}, mes_presentacion={1}, ano_presentacion={2}, id_presentacion={3} WHERE id_ctacte={4} and id_usuarios_servicios={5}", idDebito, mes, año, id_presentacion, idUsuariosCtaCte, idUsuariosServicios);
                else
                    consulta = String.Format("UPDATE usuarios_ctacte_det SET id_debito_asociado={0}, mes_presentacion={1}, ano_presentacion={2}, id_presentacion={3} WHERE id_ctacte={4}", idDebito, mes, año, id_presentacion, idUsuariosCtaCte);

                oCon.Conectar();
                oCon.CrearComando(consulta);
                oCon.ComenzarTransaccion();
                oCon.EjecutarComando();
                oCon.ConfirmarTransaccion();

                oCon.CrearComando("UPDATE usuarios_ctacte SET rechazado=0 WHERE id=@idctacte");
                oCon.AsignarParametroEntero("@idctacte", idUsuariosCtaCte);
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
        public Int32 ActualizarIdFacDebitos(int idFacturacion, int mes, int anio)
        {
            try
            {
                oCon.Conectar();

                oCon.CrearComando("UPDATE usuarios_ctacte_Det set id_facturacion=@id_Fac where mes_presentacion=@mes and ano_presentacion=@ano");
                oCon.AsignarParametroEntero("@id_fac", idFacturacion);
                oCon.AsignarParametroEntero("@mes", mes);
                oCon.AsignarParametroEntero("@ano", anio);
                oCon.ComenzarTransaccion();
                oCon.EjecutarComando();
                oCon.ConfirmarTransaccion();

                oCon.CrearComando("UPDATE usuarios_ctacte  " +
                    "LEFT JOIN usuarios_ctacte_det ON usuarios_ctacte_det.Id_Usuarios_CtaCte = usuarios_ctacte.id " +
                    "set usuarios_ctacte.id_facturacion = @id_fac " +
                    "where usuarios_ctacte_det.mes_presentacion = @mes and usuarios_ctacte_det.ano_presentacion = @ano");
                oCon.AsignarParametroEntero("@id_fac", idFacturacion);
                oCon.AsignarParametroEntero("@mes", mes);
                oCon.AsignarParametroEntero("@ano", anio);
                oCon.ComenzarTransaccion();
                oCon.EjecutarComando();
                oCon.ConfirmarTransaccion();


                oCon.DesConectar();
                return 0;
            }
            catch (Exception)
            {
                oCon.CancelarTransaccion();
                oCon.DesConectar();
                return -1;
                throw;
            }

        }

        public DataTable ListarDetalle(Int32 id)
        {
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                oCon.CrearComando(String.Format("SELECT servicios.descripcion as Servicio, vw_usuarios_ctacte_det.id_tipo," 
                    + " vw_usuarios_ctacte_det.Id_Usuarios_Servicios, " 
                    + " CASE Tipo " 
                    + " WHEN 'S' THEN(SELECT Descripcion FROM servicios_sub WHERE Id = Id_Tipo) " 
                    + " WHEN 'E' THEN(SELECT nombre FROM equipos_tipos WHERE Id = vw_usuarios_ctacte_det.Id_Tipo) " 
                    + " WHEN 'P' THEN(select nombre from partes_fallas where id = vw_usuarios_ctacte_det.Id_Tipo) "
                    + " END AS sub_servicio, vw_usuarios_ctacte_det.id, vw_usuarios_ctacte_det.id_usuarios_ctacte, " 
                    + " vw_usuarios_ctacte_det.id_servicios, if (isnull(servicios_velocidades.velocidad),'', " 
                    + " cast(servicios_velocidades.velocidad as char))  as velocidad,  if (isnull(servicios_velocidades_tip.nombre),''," 
                    + " servicios_velocidades_tip.nombre) as velocidad_tipo, vw_usuarios_ctacte_det.Importe_Original, " 
                    + " vw_usuarios_ctacte_det.importe_punitorio, " 
                    + " vw_usuarios_ctacte_det.importe_bonificacion,vw_usuarios_ctacte_det.importe_provincial, " 
                    + " vw_usuarios_ctacte_det.importe_saldo, vw_usuarios_ctacte_det.detalles,vw_usuarios_ctacte_det.fecha_desde," 
                    + " vw_usuarios_ctacte_det.fecha_hasta,vw_usuarios_ctacte_det.detalles, servicios.id_contrato," 
                    + " vw_usuarios_ctacte_det.id,vw_usuarios_ctacte_det.id_debito_asociado,vw_usuarios_ctacte_det.rechazado, usuarios_ctacte.percepcion,usuarios_ctacte.id_plan_recibo "
                    + " from vw_usuarios_ctacte_det"
                    + " left join usuarios_ctacte on vw_usuarios_ctacte_det.Id_Usuarios_CtaCte = usuarios_ctacte.Id"
                    + " left join servicios on vw_usuarios_ctacte_det.id_servicios = servicios.id"
                    + " left join servicios_velocidades on vw_usuarios_ctacte_det.id_velocidades = servicios_velocidades.id"
                    + " left join servicios_velocidades_tip on vw_usuarios_ctacte_det.id_velocidades_tip = servicios_velocidades_tip.id"
                    + " where vw_usuarios_ctacte_det.Id_comprobantes =  {0}   and vw_usuarios_ctacte_det.borrado = {1}", id, 0));

                dt = oCon.Tabla();
                oCon.DesConectar();
            }
            catch (Exception)
            {
                oCon.DesConectar();
                throw;
            }

            return dt;
        }

        public DataTable Listar(Int32 id, int sald, int tipoConsulta)
        {
            string Consulta = string.Empty;
            string Filtro = string.Empty;
            DataTable dt = new DataTable();
            try
            {
                if (tipoConsulta == (int)Usuarios_CtaCte_Det.TIPO_CONSULTA_CTACTE_DET.CON_DEUDA)
                    Filtro = String.Format("where usuarios_ctacte.Id_usuarios = {0} and usuarios_ctacte_det.importe_saldo <> {1} and  usuarios_ctacte_det.borrado={2} order by usuarios_ctacte_det.fecha_desde,usuarios_ctacte_det.id_servicios ", id, sald, 0);
                if (tipoConsulta == (int)Usuarios_CtaCte_Det.TIPO_CONSULTA_CTACTE_DET.ID_CTACTE)
                    Filtro = String.Format("where usuarios_ctacte.id_comprobantes = {0} and  usuarios_ctacte_det.borrado={1} order by usuarios_ctacte_det.fecha_desde,usuarios_ctacte_det.id_servicios ", id, 0);
                oCon.Conectar();
                oCon.CrearComando(String.Format("SELECT IFNULL(servicios.Descripcion, '-') as Servicio, IFNULL(servicios_tipos.nombre, '-') as servicio_tipo,IFNULL(servicios_tipos.id, 0) as serviciostipoid," +
                    " usuarios_ctacte_det.id_tipo,usuarios_ctacte_det.Id_Usuarios_Servicios ," +
                     "CASE usuarios_ctacte_det.Tipo " +
                         "WHEN 'S' THEN(SELECT Descripcion FROM servicios_sub WHERE Id =  usuarios_ctacte_det.Id_Tipo) " +
                         "WHEN 'E' THEN(SELECT nombre FROM equipos_tipos WHERE Id =  usuarios_ctacte_det.Id_Tipo) " +
                         "WHEN 'P' THEN(SELECT nombre from partes_fallas where id = usuarios_ctacte_det.Id_Tipo) " +
                         "END AS sub_servicio , " +
                     "CASE usuarios_ctacte_det.Tipo " +
                         "WHEN 'S' THEN(SELECT id_iva_alicuotas FROM servicios_sub WHERE Id =  usuarios_ctacte_det.Id_Tipo) " +
                         "WHEN 'E' THEN(SELECT id_iva_alicuotas FROM equipos_tipos WHERE Id =  usuarios_ctacte_det.Id_Tipo) " +
                         "WHEN 'P' THEN(SELECT id_iva_alicuotas from partes_fallas where id = usuarios_ctacte_det.Id_Tipo) " +
                         "END AS id_iva , " +
                      " usuarios_ctacte_det.tipo,usuarios_ctacte_det.id, id_usuarios_ctacte , usuarios_ctacte_det.id_servicios, " +
                     " (select velocidad FROM servicios_velocidades WHERE Id = id_velocidades) as velocidad,(select nombre FROM servicios_velocidades_tip WHERE Id = id_velocidades_tip) as velocidad_tipo, " +
                     " usuarios_ctacte_det.Importe_Original,usuarios_ctacte_det.importe_punitorio,usuarios_ctacte_det.importe_bonificacion,usuarios_ctacte_det.importe_Provincial, usuarios_ctacte_det.importe_saldo, " +
                     " usuarios_ctacte.id_comprobantes_tipo,usuarios_ctacte.id_comprobantes,usuarios_ctacte_det.id_bonificacion_aplicada,0 as porcentaje,usuarios_ctacte_det.nombre_bonificacion,usuarios_ctacte_det.fecha_desde ," +
                     " usuarios_ctacte_det.fecha_hasta, usuarios_ctacte_det.detalles ,id_iva_alicuotas, usuarios_ctacte_det.idTipoRegistroCtaCteDet, " +
                     " usuarios_servicios.fecha_estado, usuarios_servicios.id_servicios_estados,iva_alicuotas.porcentaje_divide,iva_alicuotas.porcentaje as porcentaje_iva, IFNULL(servicios.cuenta, 1) as cuenta,usuarios_ctacte_det.id_debito_asociado,usuarios_ctacte_Det.id_presentacion,usuarios_ctacte_Det.id_facturacion, usuarios_ctacte_det.Cantidad " +
                     " from usuarios_ctacte_det  " +
                     " left join servicios on servicios.id = usuarios_ctacte_det.Id_servicios " +
                     " left join servicios_tipos on servicios_tipos.id = servicios.Id_servicios_tipos " +
                     " left join usuarios_ctacte on usuarios_ctacte.Id = usuarios_ctacte_det.Id_Usuarios_CtaCte " +
                     " left join usuarios_servicios_sub on usuarios_servicios_sub.id = usuarios_ctacte_det.Id_usuarios_servicios_sub " +
                     " left join usuarios_servicios on usuarios_servicios.id = usuarios_ctacte_det.Id_usuarios_servicios " +
                     " left join iva_alicuotas on iva_alicuotas.id =usuarios_ctacte_det.id_iva_alicuotas " +
                    Filtro));
                dt = oCon.Tabla();

                oCon.DesConectar();

                foreach (DataRow Dr in dt.Rows) ///// recorre todos los comprobantes de deuda. Genera los comprobantes_detalle 
                {
                    try { Dr["id_iva_alicuotas"] = Convert.ToInt32(Dr["id_iva"].ToString()); }
                    catch { Dr["id_iva_alicuotas"] = 1; }

                }
                //// usuarios_ctacte_det.id_iva_alicuotas
            }
            catch (Exception)
            {
                oCon.DesConectar();
                throw;
            }
            return dt;
        }

        public DataTable ListarDeudasAnexadasDebitos(int id_Presentacion)
        {
            DataTable dt = new DataTable();
            string consulta = "";
            try
            {

                oCon.Conectar();
                consulta = string.Format("select usuarios_ctacte_det.id as id_ctacte_det,usuarios_ctacte.id,usuarios_ctacte.descripcion, " +
                    "usuarios_ctacte.fecha_movimiento, usuarios_ctacte.importe_final, usuarios.codigo, " +
                    "convert(usuarios.codigo, char(16)) as codigo_char, concat(usuarios.apellido, ', ', usuarios.nombre) as usuario, " +
                    "plasticos.numero as debito_asociado, plasticos.titular, usuarios_ctacte.importe_final, " +
                    "usuarios_ctacte.importe_saldo " +
                    "from usuarios_ctacte_det " +
                    "left join usuarios_ctacte on usuarios_ctacte.id = usuarios_ctacte_det.id_usuarios_ctacte " +
                    "left join plasticos on plasticos.id = usuarios_ctacte_det.id_debito_asociado " +
                    "left join usuarios on usuarios.id = usuarios_ctacte.id_usuarios " +
                    "where usuarios_ctacte.borrado = 0 and usuarios_ctacte_det.borrado = 0 " +
                    "AND usuarios_ctacte_det.id_presentacion = {0} " +
                    "group by usuarios_ctacte.id", id_Presentacion);
                oCon.CrearComando(consulta);
                dt = oCon.Tabla();
                oCon.DesConectar();
            }
            catch (Exception)
            {
                oCon.DesConectar();
            }
            return dt;
        }

        public DataTable ListarCtaCteDetAnexados(int mes, int ano, int idDebito, int idUsuario, int idLocacion)
        {
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                oCon.CrearComando("SELECT usuarios_Ctacte_det.id,usuarios_Ctacte_det.Id_Usuarios_CtaCte,usuarios_Ctacte_det.Id_Usuarios_Locaciones,usuarios_Ctacte_det.id_usuarios_servicios, usuarios_Ctacte_det.importe_saldo,usuarios_Ctacte_det.importe_provincial,usuarios_Ctacte_det.importe_bonificacion,usuarios_Ctacte_det.id_Servicios,usuarios_ctacte_det.id_tipo,usuarios_ctacte_det.tipo, CASE Tipo WHEN 'S' THEN(SELECT Descripcion FROM servicios_sub WHERE Id = Id_Tipo) WHEN 'E' THEN(SELECT nombre FROM equipos_tipos WHERE Id = usuarios_ctacte_det.Id_Tipo) WHEN 'P' THEN(select nombre from partes_fallas where id = usuarios_ctacte_det.Id_Tipo) END AS subservicio,usuarios_Ctacte_det.id_velocidades,usuarios_ctacte_det.id_velocidades_Tip,usuarios_Ctacte_det.requiere_ip,usuarios_ctacte.id_usuarios,usuarios_Ctacte_Det.id_debito_asociado,usuarios_ctacte_det.fecha_desde "
                    + " FROM usuarios_ctacte_det"
                    + " LEFT JOIN servicios on servicios.id=usuarios_ctacte_det.id_servicios"
                    + " LEFT JOIN usuarios_ctacte on usuarios_Ctacte_det.id_usuarios_ctacte=usuarios_ctacte.id"
                    + " where id_debito_asociado=@iddeb and mes_presentacion=@mes and ano_presentacion=@ano and usuarios_ctacte.id_usuarios=@idusu and usuarios_ctacte.id_usuarios_locacion=@idlocacion and usuarios_Ctacte_det.borrado=0");
                oCon.AsignarParametroEntero("@iddeb", idDebito);
                oCon.AsignarParametroEntero("@mes", mes);
                oCon.AsignarParametroEntero("@ano", ano);
                oCon.AsignarParametroEntero("@idusu", idUsuario);
                oCon.AsignarParametroEntero("@idlocacion", idLocacion);
                dt = oCon.Tabla();
                oCon.DesConectar();
            }
            catch (Exception)
            {
                oCon.DesConectar();
                throw;
            }
            return dt;
        }

        public DataTable ListarDeudaPorPeriodosNuevo(String FiltroIdTipoServicios, bool finServicio, DateTime fecha, int idTipoFacturacion)
        {
            DataTable dt = new DataTable();
            string consulta = "";
            if (finServicio)
            {
                consulta = "SELECT usuarios_locaciones.lat, usuarios_locaciones.lng, usuarios.Codigo, CONCAT(usuarios.Apellido, ', ' , usuarios.Nombre) AS usuario, "
                        + " usuarios.id as Id_Usuarios, 0 as 'saldo', 0 as meses_adeudados,"
                        + " usuarios_locaciones.saldo as saldoctacte,"
                        + " date(usuarios_servicios.fecha_factura) as fecha_fin, '1900-01-01' as fecha_desde, usuarios.Correo_Electronico,"
                        + " concat(usuarios_locaciones.Prefijo_1, ' ', usuarios_locaciones.Telefono_1) AS telefono1,"
                        + " concat(usuarios_locaciones.Prefijo_2, ' ', usuarios_locaciones.Telefono_2) AS telefono2, usuarios_servicios.Ultimo_Aviso,servicios.descripcion as servicio, "
                        + " localidades.nombre as localidad, usuarios_servicios.id as id_usuarios_servicios, concat(usuarios_locaciones.Calle, ' nro: ', usuarios_locaciones.Altura, ' PISO: ', usuarios_locaciones.piso, ' DEPTO: ', usuarios_locaciones.Depto, ' ', localidades.Nombre) AS locacion,"
                        + " usuarios_locaciones.id as id_locacion,servicios.id_servicios_tipos,usuarios_servicios.id_servicios,servicios_tipos.id_servicios_grupos,servicios.corteautomatico,Id_Servicios_Estados,usuarios_servicios.id_zonas, "
                        + " servicios_estados.estado as estado_servicio, usuarios_servicios.con_corte,servicios.id_aplicaciones_externas, usuarios_locaciones.fecha_ultimo_aviso as aviso_locacion"
                        + " FROM usuarios_servicios"
                        + " LEFT JOIN usuarios_locaciones ON usuarios_locaciones.Id = usuarios_Servicios.Id_Usuarios_Locaciones"
                        + " LEFT JOIN usuarios ON usuarios.Id = usuarios_locaciones.Id_Usuarios"
                        + " LEFT JOIN servicios ON servicios.Id = usuarios_servicios.Id_servicios"
                        + " LEFT JOIN localidades ON localidades.Id = usuarios_locaciones.id_localidades"
                        + " LEFT JOIN servicios_tipos ON servicios_tipos.Id = servicios.id_servicios_tipos"
                        + " LEFT JOIN servicios_estados ON servicios_estados.Id = usuarios_servicios.id_servicios_estados";
            }
            else
            {
                consulta = string.Format(" SELECT usuarios_locaciones.lat, usuarios_locaciones.lng, usuarios.Codigo, CONCAT(usuarios.Apellido, ', ' , usuarios.Nombre) AS usuario, usuarios_ctacte.Id_Usuarios, "
                        + " sum(usuarios_ctacte_det.Importe_Saldo) AS saldo, count(DISTINCT usuarios_ctacte_det.Fecha_Desde) AS meses_adeudados,usuarios_locaciones.saldo as saldoctacte,"
                        + " usuarios_ctacte_det.Fecha_Desde,date(usuarios_servicios.fecha_factura) as fecha_fin,usuarios.Correo_Electronico,"
                        + " concat(usuarios_locaciones.Prefijo_1, ' ', usuarios_locaciones.Telefono_1) AS telefono1,"
                        + " concat(usuarios_locaciones.Prefijo_2, ' ', usuarios_locaciones.Telefono_2) AS telefono2,usuarios_servicios.Ultimo_Aviso,servicios.descripcion as servicio, "
                        + " localidades.nombre as localidad,usuarios_ctacte_det.id_usuarios_servicios, concat(usuarios_locaciones.Calle,' nro: ',usuarios_locaciones.Altura,' PISO: ',usuarios_locaciones.piso,' DEPTO: ',usuarios_locaciones.Depto,' ',localidades.Nombre) AS locacion,"
                        + " usuarios_locaciones.id as id_locacion,servicios.id_servicios_tipos,usuarios_servicios.id_servicios,servicios_tipos.id_servicios_grupos,servicios.corteautomatico,Id_Servicios_Estados,usuarios_servicios.id_zonas, " +
                        "  servicios_estados.estado as estado_servicio, usuarios_servicios.con_corte,servicios.id_aplicaciones_externas, usuarios_locaciones.fecha_ultimo_aviso as aviso_locacion, usuarios_servicios.fecha_estado "
                        + " FROM usuarios_ctacte_det"
                        + " LEFT JOIN usuarios_locaciones ON usuarios_locaciones.Id = usuarios_ctacte_det.Id_Usuarios_Locaciones"
                        + " LEFT JOIN usuarios_ctacte ON usuarios_ctacte.id = usuarios_ctacte_det.Id_Usuarios_CtaCte"
                        + " LEFT JOIN usuarios ON usuarios.Id = usuarios_ctacte.Id_Usuarios"
                        + " LEFT JOIN servicios ON servicios.Id = usuarios_ctacte_det.Id_servicios"
                        + " LEFT JOIN localidades ON localidades.Id = usuarios_locaciones.id_localidades"
                        + " LEFT JOIN servicios_tipos ON servicios_tipos.Id = servicios.id_servicios_tipos"
                        + " LEFT JOIN usuarios_servicios ON usuarios_servicios.Id = usuarios_ctacte_det.Id_Usuarios_Servicios and usuarios_servicios.Id_Servicios_Estados IN(1, 2, 3) and usuarios_servicios.borrado=0"
                        + " LEFT JOIN servicios_estados ON servicios_estados.Id = usuarios_servicios.id_servicios_estados");
            }
            string condicionTipoFacturacion = "";
            if (idTipoFacturacion > 0)
            {
                condicionTipoFacturacion = $"AND usuarios_Servicios.id_tipo_facturacion = {idTipoFacturacion}";
            }
            if (finServicio)
            {
                consulta = consulta + string.Format(" WHERE usuarios_Servicios.Id_Servicios in {0} AND usuarios_servicios.Id_Servicios_Estados IN(1, 2, 3)"
                + " AND date(usuarios_servicios.Fecha_factura) < DATE('{1}')"
                + " AND usuarios_Servicios.Borrado = 0"
                + " {2} GROUP by usuarios.id ,usuarios_Servicios.id_servicios"
                + " ORDER BY usuarios.codigo; ", FiltroIdTipoServicios, fecha.ToString("yyyy-MM-dd"), condicionTipoFacturacion);
            }
            else
            {
                consulta = consulta + string.Format(" WHERE usuarios_ctacte_det.Id_Servicios in {0} AND usuarios_servicios.Id_Servicios_Estados IN(1, 2, 3)"
                  + " AND usuarios_ctacte_det.Importe_Saldo <> 0 AND usuarios_ctacte_det.Importe_Pago = 0 "
                  + " AND date(usuarios_ctacte_det.Fecha_desde) < DATE('{1}')"
                  + " AND usuarios_ctacte_det.Borrado = 0 AND usuarios_ctacte_det.id_debito_asociado = 0 AND usuarios_ctacte_det.tipo='S' "
                  + " {2} GROUP by usuarios_ctacte.Id_Usuarios,usuarios_ctacte_det.id_servicios"
                  + " having SUM(usuarios_ctacte_det.Importe_Saldo) > 0"
                  + " ORDER BY usuarios.codigo; ", FiltroIdTipoServicios, fecha.ToString("yyyy-MM-dd"), condicionTipoFacturacion);
            }
            try
            {
                oCon.Conectar();
                oCon.CrearComando(consulta);
                dt = oCon.Tabla();
                oCon.DesConectar();
            }
            catch (Exception)
            {
                oCon.DesConectar();
            }
            return dt;
        }

        public DataTable ListarDeudaPorServicio(int idUsuario, int idServicio, DateTime fechaHasta)
        {
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                oCon.CrearComando("SELECT usuarios_ctacte_det.fecha_desde,usuarios_ctacte_det.fecha_hasta,"
                + "(CASE `usuarios_ctacte_det`.`Tipo` WHEN 'S' THEN (SELECT `servicios_sub`.`Descripcion` FROM `servicios_sub` WHERE (`servicios_sub`.`Id` = `usuarios_ctacte_det`.`Id_Tipo`)) WHEN 'E' THEN (SELECT `equipos`.`Descripcion` FROM `equipos` WHERE (`equipos`.`Id` = `usuarios_ctacte_det`.`Id_Tipo`)) WHEN 'P' THEN (SELECT `partes_fallas`.`Nombre` FROM `partes_fallas` WHERE (`partes_fallas`.`Id` = `usuarios_ctacte_det`.`Id_Tipo`)) END) AS 'sub_servicio',"
                + "usuarios_ctacte_det.detalles,usuarios_ctacte_det.importe_original,usuarios_ctacte_det.importe_bonificacion,usuarios_ctacte_det.importe_provincial,usuarios_ctacte_det.importe_punitorio,usuarios_ctacte_det.importe_final,usuarios_ctacte_det.importe_saldo  "
                + " FROM usuarios_ctacte_det"
                + " LEFT JOIN usuarios_ctacte ON usuarios_ctacte.Id = usuarios_ctacte_det.Id_Usuarios_CtaCte"
                + " LEFT JOIN servicios ON servicios.id = usuarios_ctacte_det.id_servicios"
                + " WHERE usuarios_ctacte_det.importe_saldo>0 and usuarios_ctacte.Id_Usuarios =@id_usu AND date(usuarios_ctacte_det.Fecha_Desde) < DATE(@fecha) AND usuarios_ctacte_det.Id_Servicios =@id_ser and usuarios_ctacte.borrado=0 and usuarios_ctacte_det.borrado=0");
                oCon.AsignarParametroEntero("@id_usu", idUsuario);
                oCon.AsignarParametroFecha("@fecha", fechaHasta);
                oCon.AsignarParametroEntero("@id_ser", idServicio);
                dt = oCon.Tabla();
                oCon.DesConectar();
            }
            catch (Exception)
            {
                oCon.DesConectar();
                throw;
            }
            return dt;
        }

        public DataTable ListarCtaCte_Det_Inconcluencias_Percepciones()
        {
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                oCon.CrearComando("SELECT usuarios_ctacte.Id AS Id_ctacte, usuarios_ctacte_det.Id AS Id_ctacte_det, usuarios_ctacte.Descripcion AS Comprobante, " +
                    "usuarios_ctacte.Fecha_Movimiento, " +
                    "usuarios_ctacte.Importe_Original AS Original_ctacte, usuarios_ctacte_det.Importe_Original AS Original_ctacte_det, " +
                    "usuarios_ctacte.Importe_Bonificacion AS Bonificacion_ctacte, usuarios_ctacte_det.Importe_Bonificacion AS Bonificacion_ctacte_det, " +
                    "(usuarios_ctacte.Importe_Original - usuarios_ctacte.Importe_Bonificacion) / 1.21 AS Neto_ctacte, " +
                    "(usuarios_ctacte_det.Importe_Original - usuarios_ctacte_det.Importe_Bonificacion) / 1.21 AS Neto_ctacte_det, " +
                    "usuarios_ctacte.Importe_Provincial AS Provincial_Ctacte, " +
                    "usuarios_ctacte_det.Importe_Provincial AS Provincial_Ctacte_det " +
                    "FROM usuarios_ctacte_det " +
                    "LEFT JOIN usuarios_ctacte ON usuarios_ctacte_det.Id_Usuarios_CtaCte = usuarios_ctacte.id " +
                    "WHERE usuarios_ctacte.Importe_Provincial > 0 AND usuarios_ctacte.borrado = 0 " +
                    "AND usuarios_ctacte_det.borrado = 0");
                dt = oCon.Tabla();
                oCon.DesConectar();
            }
            catch (Exception)
            {
                oCon.DesConectar();
                throw;
            }
            return dt;
        }

        public void Actualizar_Provincial_Ctactedet(DataTable dt)
        {
            int id_Ctacte = 0;
            int id_Ctacte_det = 0;
            decimal provincial_ctacte_det = 0;
            decimal Porcentaje_Ctacte = 0;
            try
            {
                oCon.Conectar();
                foreach (DataRow drOriginal in dt.Rows)
                {
                    id_Ctacte = Convert.ToInt32(drOriginal["id_ctacte"]);
                    id_Ctacte_det = Convert.ToInt32(drOriginal["id_ctacte_det"]);
                    if (Convert.ToDecimal(drOriginal["Provincial_Ctacte"]) > 0 && Convert.ToDecimal(drOriginal["Neto_Ctacte"]) > 0)
                        Porcentaje_Ctacte = (Convert.ToDecimal(drOriginal["Provincial_Ctacte"]) * 100) / Convert.ToDecimal(drOriginal["Neto_Ctacte"]);
                    provincial_ctacte_det = (Convert.ToDecimal(drOriginal["neto_ctacte_det"]) * Porcentaje_Ctacte) / 100;

                    oCon.CrearComando("UPDATE usuarios_ctacte_Det set Importe_provincial=@prov_ctacte_det where id_usuarios_ctacte=@id_ctacte and id=@id_ctacte_det");
                    oCon.AsignarParametroDecimal("@prov_ctacte_det", provincial_ctacte_det);
                    oCon.AsignarParametroEntero("@id_ctacte", id_Ctacte);
                    oCon.AsignarParametroEntero("@id_ctacte_det", id_Ctacte_det);
                    oCon.ComenzarTransaccion();
                    oCon.EjecutarComando();
                    oCon.ConfirmarTransaccion();
                }
                oCon.DesConectar();
            }
            catch (Exception)
            {
                oCon.CancelarTransaccion();
                oCon.DesConectar();
                throw;
            }



        }

        public DataTable Listado_ARBA_Cuatrimestral(DateTime desde, DateTime hasta, int id_Grupo, decimal Importe)
        {
            string condicion = string.Empty;
            string consulta = string.Empty;
            string Consulta_Total = string.Empty;
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                consulta = " select servicios_grupos.id as Id_Grupo,usuarios_ctacte_det.id_usuarios_servicios as id_usu_serv, usuarios_ctacte_det.id as id_ctactedet, " +
                    "usuarios_ctacte.id as id_ctacte, usuarios_ctacte.id_usuarios as id_usuario, date(usuarios_ctacte.fecha_movimiento) as fecha, " +
                    "usuarios_ctacte.descripcion as comprobante, concat(usuarios.apellido, '-', usuarios.nombre) as usuario, CONCAT(usuarios_ctacte.Fecha_Desde, '/', usuarios_ctacte.Fecha_hasta) AS Periodo, " +
                    "usuarios_ctacte.importe_pago as importe, servicios_grupos.nombre as grupo , usuarios.Cuit AS Cuit,usuarios_tipodoc.Id AS id_Tipo_doc,usuarios_tipodoc.Tipo AS TipoDoc, usuarios.Numero_Documento AS Documento, " +
                    " 1 AS Tipo_prestacion, 'A' AS EstadoAbonado, " +
                    "servicios_modalidad.Id AS id_modalidad, servicios_modalidad.Nombre AS Modalidad, " +
                    "usuarios_locaciones.Telefono_1 AS Celular, usuarios_locaciones.Telefono_2 AS Telefono, " +
                    "usuarios_locaciones.Calle AS Calle, usuarios_locaciones.Altura AS Altura,usuarios_locaciones.depto,usuarios_locaciones.piso, localidades.Codigo_Postal AS CodigoPostal, " +
                    "localidades.Id AS Id_Localidad, localidades.Nombre AS Localidad, usuarios.Correo_Electronico AS Email " +
                    "from usuarios_ctacte_det " +
                    "left join usuarios_ctacte on usuarios_ctacte_det.id_usuarios_ctacte = usuarios_ctacte.id and usuarios_ctacte.borrado = 0 " +
                    "left join usuarios on usuarios_ctacte.id_usuarios = usuarios.id and usuarios.borrado = 0 " +
                    "LEFT JOIN usuarios_tipodoc ON usuarios.Id_Usuarios_TipoDoc = usuarios_tipodoc.id " +
                    "LEFT JOIN usuarios_locaciones ON usuarios_locaciones.Id_Usuarios = usuarios.id " +
                    "LEFT JOIN localidades ON usuarios_locaciones.Id_Localidades = localidades.id " +
                    "left join servicios on usuarios_ctacte_det.id_servicios = servicios.id and servicios.borrado = 0 " +
                    "LEFT JOIN servicios_modalidad ON servicios.Id_Servicios_Modalidad = servicios_modalidad.id " +
                    "left join servicios_tipos on servicios.id_servicios_tipos = servicios_tipos.id " +
                    "left join servicios_grupos on servicios_tipos.id_servicios_grupos = servicios_grupos.id " +
                    "left join comprobantes_tipo on comprobantes_tipo.id = usuarios_ctacte.Id_comprobantes_tipo " +
                    "WHERE usuarios_ctacte_det.borrado = 0 AND servicios.id > 0 AND usuarios_ctacte.Importe_Pago >= @importe " +
                    "AND(usuarios_ctacte.Fecha_Movimiento  between @desde AND @hasta) AND comprobantes_tipo.presenta_ventas=1 ";
                if (id_Grupo == 3)
                {
                    condicion = " AND servicios_grupos.Id IN (1,2) " +
                    "GROUP BY usuarios.id , usuarios_ctacte.id " +
                    "ORDER BY usuarios.id;";
                    Consulta_Total = string.Format("{0}{1}", consulta, condicion);
                    oCon.CrearComando(Consulta_Total);
                }
                else
                {
                    condicion = " AND servicios_grupos.Id = @grupo " +
                    "GROUP BY usuarios.id , usuarios_ctacte.id " +
                    "ORDER BY usuarios.id;";
                    Consulta_Total = string.Format("{0}{1}", consulta, condicion);
                    oCon.CrearComando(Consulta_Total);
                    oCon.AsignarParametroEntero("@grupo", id_Grupo);
                }
                oCon.AsignarParametroFecha("@desde", desde);
                oCon.AsignarParametroFecha("@hasta", hasta);
                oCon.AsignarParametroDecimal("@importe", Importe);
                dt = oCon.Tabla();
                oCon.DesConectar();
            }
            catch (Exception)
            {
                oCon.DesConectar();
                throw;
            }
            return dt;
        }

        public DataTable Listado_ARBA_Cuatrimestral_Detalle(int id_ctacte)
        {
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                oCon.CrearComando("SELECT usuarios_ctacte_det.id AS Id_Det, servicios.id AS Id_serv, " +
                    "usuarios_ctacte_det.Importe_Pago AS importe_Pago, servicios.Descripcion AS Servicio, " +
                    "CONCAT(usuarios.Apellido, ' , ', usuarios.Nombre) AS Usuario " +
                    "FROM usuarios_ctacte_det " +
                    "LEFT JOIN usuarios_ctacte ON usuarios_ctacte_det.Id_Usuarios_CtaCte = usuarios_ctacte.id " +
                    "LEFT JOIN servicios ON usuarios_ctacte_det.Id_Servicios = servicios.id " +
                    "LEFT JOIN usuarios ON usuarios_ctacte.Id_Usuarios = usuarios.id " +
                    "WHERE usuarios_ctacte_det.borrado = 0 AND servicios.borrado = 0 and " +
                    "usuarios_ctacte.borrado = 0 AND usuarios.borrado = 0 AND usuarios_ctacte.id = @id_ctacte ");
                oCon.AsignarParametroEntero("@id_ctacte", id_ctacte);
                dt = oCon.Tabla();
                oCon.DesConectar();
            }
            catch (Exception)
            {
                oCon.DesConectar();
                throw;
            }
            return dt;
        }

        public DataTable ListarCtacteDetParaRecalcular(int idUsuario = 0)
        {
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                string condicion = "";
                if(idUsuario > 0)
                    condicion = $" AND usuarios_ctacte.id_usuarios = {idUsuario}";
                
                oCon.CrearComando(string.Format("SELECT usuarios_ctacte.id AS id_ctacte, usuarios_locaciones.id_usuarios, usuarios_ctacte_det.Id AS id_ctacte_det, usuarios_ctacte_det.Id_Servicios,"
                                    + " usuarios_ctacte_det.Importe_Saldo AS importe_saldo_det, usuarios_ctacte_det.Importe_Punitorio,"
                                    + " usuarios_ctacte_det.Fecha_Desde,"
                                    + " usuarios_ctacte_det.Fecha_hasta, usuarios_locaciones.id AS id_usu_locacion, usuarios_ctacte_det.id_debito_asociado, usuarios_ctacte.id_comprobantes_tipo"
                                    + " FROM usuarios_ctacte_det"
                                    + " INNER JOIN usuarios_ctacte ON usuarios_ctacte.Id = usuarios_ctacte_det.Id_Usuarios_CtaCte"
                                    + " INNER JOIN usuarios_locaciones ON usuarios_locaciones.Id = usuarios_ctacte.Id_Usuarios_Locacion"
                                    + $" WHERE usuarios_ctacte_det.borrado = 0 AND usuarios_ctacte.borrado = 0 {condicion} "
                                    + " ORDER BY id_usu_locacion, id_ctacte ASC"));
                dt = oCon.Tabla();
                oCon.DesConectar();
            }
            catch (Exception)
            {
                oCon.DesConectar();
                throw;
            }
            return dt;
        }

        public void ActualizarCtaCteDet_FacturasSinRecibo(int id_Ctacte)
        {
            try
            {
                oCon.Conectar();
                string comando = "UPDATE usuarios_ctacte_det SET importe_saldo = 0 , importe_pago = importe_original WHERE id_usuarios_ctacte = @id";
                oCon.CrearComando(comando);
                oCon.AsignarParametroEntero("@id", id_Ctacte);
                oCon.EjecutarComando();
                oCon.DesConectar();
            }
            catch (Exception)
            {
                oCon.DesConectar();
                throw;
            }
        }

        public DataTable ListarDetalleDeCtaCte(int id_Ctacte)
        {
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                oCon.CrearComando("SELECT * FROM usuarios_ctacte_det where id_usuarios_ctacte = @idCtacte and borrado = 0");
                oCon.AsignarParametroEntero("@idCtacte", id_Ctacte);
                dt = oCon.Tabla();
                oCon.DesConectar();
            }
            catch (Exception)
            {
                oCon.DesConectar();
                throw;
            }
            return dt;
        }

        public string ListaToString<T>(List<T> lista)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("(");
            for (int i = 0; i < lista.Count; i++)
            {
                sb.Append(lista[i].ToString());
                if (i < (lista.Count - 1))
                    sb.Append(", ");
                else
                    sb.Append(")");
            }
            return sb.ToString();
        }

        public DataTable ListarComprobantesEmitidosYFacturas(DateTime desde, DateTime hasta, List<int> origenes)
        {
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                oCon.CrearComando("select id_serv, Desde, Hasta, Servicio, sum(Importe_Final) as Importe_Final, count(*) as CantidadServicios from("
                   + " SELECT servicios.id as id_servicios, ifnull(servicios.id, 0) AS id_serv,"
                   + " MIN(usuarios_ctacte.Fecha_Desde) AS Desde, MAX(usuarios_ctacte.Fecha_Hasta) AS Hasta, ifnull(servicios.Descripcion, 'EXTRAS/COMPLEMENTARIAS')  AS Servicio,"
                   + " COUNT(servicios.id) AS CantidadServicios,"
                   + " SUM(usuarios_ctacte_det.Importe_Original + usuarios_ctacte_det.Importe_Punitorio +"
                   + " usuarios_ctacte_det.Importe_Provincial - usuarios_ctacte_det.Importe_Bonificacion) AS Importe_Final,"
                   + " usuarios_ctacte.id_origen"
                   + " FROM usuarios_ctacte_det"
                   + " LEFT JOIN servicios ON usuarios_ctacte_det.Id_Servicios = servicios.id"
                   + " LEFT JOIN usuarios_ctacte ON usuarios_ctacte_det.Id_Usuarios_CtaCte = usuarios_ctacte.Id"
                   //+ $" WHERE usuarios_ctacte.borrado = 0 AND usuarios_ctacte_det.borrado = 0 AND id_origen in {ListaToString<int>(origenes)} AND"
                   + " WHERE usuarios_ctacte.borrado = 0 AND usuarios_ctacte_det.borrado = 0 AND"
                   + " (DATE(usuarios_ctacte_det.Fecha_Desde) >= DATE(@desde)) AND(DATE(usuarios_ctacte_det.Fecha_Hasta) <= DATE(@hasta))"
                   + " GROUP BY servicios.id, usuarios_ctacte.id"
                   + " ) as t group by id_servicios");
                oCon.AsignarParametroFecha("@desde", desde);
                oCon.AsignarParametroFecha("@hasta", hasta);
                dt = oCon.Tabla();
                oCon.DesConectar();
            }
            catch (Exception)
            {
                oCon.DesConectar();
                throw;
            }
            return dt;
        }

        public DataTable ListarCantidadUsuariosComprobantesEmitidosFacturados(int id_Servicio,DateTime desde, DateTime hasta)
        {
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                oCon.CrearComando("(SELECT COUNT(*) AS CantUsu  " +
                    "FROM(" +
                    "        SELECT usuarios_ctacte.Id_Usuarios, COUNT(*)" +
                    "        FROM usuarios_ctacte_det" +
                    "        LEFT JOIN usuarios_ctacte ON usuarios_ctacte_det.id_usuarios_ctacte = usuarios_ctacte.id" +
                    "        WHERE usuarios_ctacte.borrado = 0 AND usuarios_ctacte_det.borrado = 0 AND usuarios_ctacte_det.id_servicios = @idServ " +
                    "        AND(DATE(usuarios_ctacte.Fecha_Desde) >= DATE(@desde)) AND(DATE(usuarios_ctacte.Fecha_Hasta) <= DATE(@hasta))" +
                    "        GROUP BY usuarios_ctacte.Id_Usuarios ) " +
                    "AS e)");
                oCon.AsignarParametroEntero("@idServ", id_Servicio);
                oCon.AsignarParametroFecha("@desde", desde);
                oCon.AsignarParametroFecha("@hasta", hasta);
                dt = oCon.Tabla();
                oCon.DesConectar();
            }
            catch (Exception)
            {
                oCon.DesConectar();
                throw;
            }
            return dt;
        }

        public List<Usuarios_CtaCte_Det> Get(int idCtaCte)
        {
            List<Usuarios_CtaCte_Det> oCtaLista = new List<Usuarios_CtaCte_Det>();
            Usuarios_CtaCte_Det oCtaDet = new Usuarios_CtaCte_Det();
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                oCon.CrearComando("SELECT * FROM usuarios_ctacte_det WHERE id_usuarios_ctacte = @ctacte and borrado = 0");
                oCon.AsignarParametroEntero("@ctacte", idCtaCte);
                dt = oCon.Tabla();
                oCon.DesConectar();
            }
            catch (Exception x)
            {
                oCon.DesConectar();

                throw;
            }
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow item in dt.Rows)
                {
                    oCtaDet = new Usuarios_CtaCte_Det();
                    oCtaDet.Id = Convert.ToInt32(item["id"]);
                    oCtaDet.Id_Usuarios_CtaCte = Convert.ToInt32(item["Id_Usuarios_CtaCte"]);
                    oCtaDet.Id_Usuarios_Locaciones = Convert.ToInt32(item["Id_Usuarios_Locaciones"]);
                    oCtaDet.Fecha_Desde = Convert.ToDateTime(item["Fecha_Desde"]);
                    oCtaDet.Fecha_Hasta = Convert.ToDateTime(item["Fecha_Hasta"]);
                    oCtaDet.Tipo = item["Tipo"].ToString();
                    oCtaDet.Importe_Original = Convert.ToDecimal(item["Importe_Original"]);
                    oCtaDet.Importe_Punitorio = Convert.ToDecimal(item["Importe_Punitorio"]);
                    oCtaDet.Importe_Bonificacion = Convert.ToDecimal(item["Importe_Bonificacion"]);
                    oCtaDet.Importe_Final = Convert.ToDecimal(item["Importe_Final"]);
                    oCtaDet.Importe_Saldo = Convert.ToDecimal(item["Importe_Saldo"]);
                    oCtaDet.Importe_Provincial = Convert.ToDecimal(item["Importe_Provincial"]);
                    oCtaDet.Importe_Presentado = Convert.ToDecimal(item["importe_presentado"]);
                    oCtaDet.Id_Usuarios_Servicios_sub = Convert.ToInt32(item["Id_Usuarios_Servicios_sub"]);
                    oCtaDet.Id_Velocidades = Convert.ToInt32(item["Id_Velocidades"]);
                    oCtaDet.Id_Velocidades_Tip = Convert.ToInt32(item["Id_Velocidades_Tip"]);
                    oCtaDet.Id_Facturacion = Convert.ToInt32(item["id_facturacion"]);
                    oCtaDet.Ano_Presentacion = Convert.ToInt32(item["ano_presentacion"]);
                    oCtaDet.Mes_Presentacion = Convert.ToInt32(item["Mes_Presentacion"]);
                    oCtaDet.Cantidad = Convert.ToInt32(item["Cantidad"]);
                    oCtaDet.Cantidad_Periodos = Convert.ToInt32(item["Cantidad_periodos"]);
                    oCtaDet.Detalles = item["detalles"].ToString();
                    oCtaDet.Id_Tipo_Registro_Cta_Cte_Det = Convert.ToInt32(item["idTipoRegistroCtaCteDet"]);
                    oCtaDet.Id_bonificacion_Aplicada = Convert.ToInt32(item["Id_bonificacion_Aplicada"]);
                    oCtaDet.Id_Debito_asociado = Convert.ToInt32(item["id_debito_asociado"]);
                    oCtaDet.Id_Debito_Estado = Convert.ToInt32(item["id_estado_debito"]);
                    oCtaDet.Id_Iva_Alicuotas = Convert.ToInt32(item["Id_Iva_Alicuotas"]);
                    oCtaDet.Id_Presentacion = Convert.ToInt32(item["Id_Presentacion"]);
                    oCtaDet.Id_Servicios = Convert.ToInt32(item["Id_Servicios"]);
                    oCtaDet.Id_Tipo = Convert.ToInt32(item["Id_Tipo"]);
                    oCtaDet.Id_Tipo_Facturacion = Convert.ToInt32(item["id_tipo_facturacion"]);
                    oCtaDet.Id_Usuarios_Servicios = Convert.ToInt32(item["Id_Usuarios_Servicios"]);
                    oCtaDet.Id_Zonas = Convert.ToInt32(item["Id_Zonas"]);
                    oCtaDet.Periodo_Ano = Convert.ToInt32(item["Periodo_Ano"]);
                    oCtaDet.Periodo_Mes = Convert.ToInt32(item["Periodo_Mes"]);
                    oCtaDet.Requiere_IP = Convert.ToInt32(item["Requiere_IP"]);
                    oCtaDet.Nombre_Bonificacion = item["Periodo_Ano"].ToString();
                    oCtaLista.Add(oCtaDet);
                }
                return oCtaLista;

            }
            return oCtaLista;
        }
    }
}

