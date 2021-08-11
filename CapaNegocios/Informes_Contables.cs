using CapaDatos;
using System;
using System.Data;

namespace CapaNegocios
{
    public class Informes_Contables
    {
        #region [PROPIEDADES]
        public enum TIPO_INFORME { LIBROIVAA = 1, LIBROIVAB = 2, INTERNETMENSUAL = 3, CABLEMENSUAL = 4 };
        #endregion

        private Conexion oCon = new Conexion();

        public DataTable ListarDatosInforme(int idTipoInforme, string fechaDesde, string fechaHasta)
        {
            DataTable dt = new DataTable();

            try
            {
                oCon.Conectar();
                if (idTipoInforme == Convert.ToInt16(TIPO_INFORME.LIBROIVAA))
                {
                    oCon.CrearComando("select date(comprobantes.fecha) as fecha, comprobantes.descripcion as descripcion_comprobante, usuarios.apellido, usuarios.nombre as usuario_nombre, comprobantes_iva.descripcion, usuarios.cuit, round(montos.importe_neto,2) as importe_neto, round(montos.importe_con_iva,2) importe_iva, iva_ventas.importe_impuesto_provincial, round((montos.importe_neto+montos.importe_con_iva),2) as total" +
                                     " from (select * from comprobantes where borrado = 0 and date(fecha) >= @fechadesde and date(fecha) <= @fechahasta and id_comprobantes_tipo = @tipocomprobante)comprobantes" +
                                     " left join comprobantes_tipo on comprobantes.id_comprobantes_tipo = comprobantes_tipo.id" +
                                     " left join usuarios on comprobantes.id_usuarios = usuarios.id" +
                                     " left join comprobantes_iva on usuarios.id_comprobantes_iva = comprobantes_iva.id" +
                                     " left join usuarios_locaciones on comprobantes.id_usuarios_locaciones = usuarios_locaciones.id" +
                                     " left join usuarios_dom_fiscal on usuarios_locaciones.id_locacion_fiscal_asociada = usuarios_dom_fiscal.id" +
                                     " left join iva_ventas on comprobantes.id = iva_ventas.id_comprobantes" +
                                     " left join (select sum(importe_neto) as importe_neto, sum(importe_con_iva) as importe_con_iva, id_comprobantes" +
                                     " from (select(importe_con_iva - ((importe_con_iva * porcentaje) / 100)) as importe_neto, importe_con_iva, id_comprobantes " +
                                     " from (select usuarios_ctacte_det.id_tipo, usuarios_ctacte_det.tipo, iva_alicuotas.porcentaje, (usuarios_ctacte_det.importe_original - usuarios_ctacte_det.importe_bonificacion) as importe_con_iva, usuarios_ctacte.id_comprobantes " +
                                     " from (select * from usuarios_ctacte_det where borrado = 0)usuarios_ctacte_det left join usuarios_ctacte on usuarios_ctacte_det.id_usuarios_ctacte = usuarios_ctacte.id left join iva_alicuotas on usuarios_ctacte_det.id_iva_alicuotas = iva_alicuotas.id)usuarios_ctacte_det)usuarios_ctacte_det" +
                                     " group by id_comprobantes)montos on comprobantes.id = montos.id_comprobantes");
                    oCon.AsignarParametroCadena("@fechadesde", fechaDesde);
                    oCon.AsignarParametroCadena("@fechahasta", fechaHasta);
                    oCon.AsignarParametroEntero("@tipocomprobante", Convert.ToInt16(Comprobantes_Tipo.Tipo.FACTURA_A));
                }
                else if (idTipoInforme == Convert.ToInt16(TIPO_INFORME.LIBROIVAB))
                {
                    oCon.CrearComando("select fecha, min(descripcion_comprobante) as factura_desde, concat(max(descripcion_comprobante),' ','(',count(id),')') as factura_hasta, descripcion, 0 as cuit, sum(importe_neto) as importe_neto, sum(importe_iva) as importe_iva, sum(total) as total, 1 as tipo_registro" +
                                    "   from(select comprobantes.id, date(comprobantes.fecha) as fecha, comprobantes.descripcion as descripcion_comprobante, usuarios.apellido, usuarios.nombre as usuario_nombre, comprobantes_iva.descripcion, usuarios.cuit, round(montos.importe_neto, 2) as importe_neto, round(montos.importe_con_iva, 2) importe_iva, iva_ventas.importe_impuesto_provincial, round((montos.importe_neto + montos.importe_con_iva), 2) as total" +
                                    "   from(select * from comprobantes where borrado = 0 and date(fecha) >= @fechadesde and date(fecha) <= @fechahasta and id_comprobantes_tipo = @facturab)comprobantes" +
                                    "   left join comprobantes_tipo on comprobantes.id_comprobantes_tipo = comprobantes_tipo.id left join usuarios on comprobantes.id_usuarios = usuarios.id" +
                                    "   left join comprobantes_iva on usuarios.id_comprobantes_iva = comprobantes_iva.id left join usuarios_locaciones on comprobantes.id_usuarios_locaciones = usuarios_locaciones.id" +
                                    "   left join usuarios_dom_fiscal on usuarios_locaciones.id_locacion_fiscal_asociada = usuarios_dom_fiscal.id left join iva_ventas on comprobantes.id = iva_ventas.id_comprobantes" +
                                    "   left join(select sum(importe_neto) as importe_neto, sum(importe_con_iva) as importe_con_iva, id_comprobantes from(select(importe_con_iva - ((importe_con_iva * porcentaje) / 100)) as importe_neto, importe_con_iva, id_comprobantes" +
                                    "   from(select usuarios_ctacte_det.id_tipo, usuarios_ctacte_det.tipo, iva_alicuotas.porcentaje, (usuarios_ctacte_det.importe_original - usuarios_ctacte_det.importe_bonificacion) as importe_con_iva, usuarios_ctacte.id_comprobantes from(select * from usuarios_ctacte_det where borrado = 0)usuarios_ctacte_det" +
                                    "   left join usuarios_ctacte on usuarios_ctacte_det.id_usuarios_ctacte = usuarios_ctacte.id left join iva_alicuotas on usuarios_ctacte_det.id_iva_alicuotas = iva_alicuotas.id)usuarios_ctacte_det)usuarios_ctacte_det" +
                                    "   group by id_comprobantes)montos on comprobantes.id = montos.id_comprobantes)facturasb group by fecha" +
                                    "   union" +
                                    "   select date(comprobantes.fecha) as fecha, comprobantes.descripcion as descripcion_comprobante, concat_ws(usuarios.apellido, usuarios.nombre, ' ') as titular, comprobantes_iva.descripcion, usuarios.cuit, round(montos.importe_neto, 2) as importe_neto, round(montos.importe_con_iva, 2) as importe_iva, round((montos.importe_neto + montos.importe_con_iva), 2) as total, 2 as tipo_registro" +
                                    "   from(select * from comprobantes where borrado = 0 and date(fecha) >= @fechadesdenota and date(fecha) <= @fechahastanota and id_comprobantes_tipo = @notab)comprobantes" +
                                    "   left join comprobantes_tipo on comprobantes.id_comprobantes_tipo = comprobantes_tipo.id left join usuarios on comprobantes.id_usuarios = usuarios.id" +
                                    "   left join comprobantes_iva on usuarios.id_comprobantes_iva = comprobantes_iva.id left join usuarios_locaciones on comprobantes.id_usuarios_locaciones = usuarios_locaciones.id" +
                                    "   left join usuarios_dom_fiscal on usuarios_locaciones.id_locacion_fiscal_asociada = usuarios_dom_fiscal.id left join iva_ventas on comprobantes.id = iva_ventas.id_comprobantes" +
                                    "   left join(select sum(importe_neto) as importe_neto, sum(importe_con_iva) as importe_con_iva, id_comprobantes from(select(importe_con_iva - ((importe_con_iva * porcentaje) / 100)) as importe_neto, importe_con_iva, id_comprobantes from" +
                                    "   (select usuarios_ctacte_det.id_tipo, usuarios_ctacte_det.tipo, iva_alicuotas.porcentaje, (usuarios_ctacte_det.importe_original - usuarios_ctacte_det.importe_bonificacion) as importe_con_iva, usuarios_ctacte.id_comprobantes" +
                                    "   from(select * from usuarios_ctacte_det where borrado = 0)usuarios_ctacte_det left join usuarios_ctacte on usuarios_ctacte_det.id_usuarios_ctacte = usuarios_ctacte.id" +
                                    "   left join iva_alicuotas on usuarios_ctacte_det.id_iva_alicuotas = iva_alicuotas.id)usuarios_ctacte_det)usuarios_ctacte_det group by id_comprobantes)montos on comprobantes.id = montos.id_comprobantes");
                    oCon.AsignarParametroCadena("@fechadesde", fechaDesde);
                    oCon.AsignarParametroCadena("@fechahasta", fechaHasta);
                    oCon.AsignarParametroEntero("@facturab", Convert.ToInt16(Comprobantes_Tipo.Tipo.FACTURA_B));
                    oCon.AsignarParametroCadena("@fechadesdenota", fechaDesde);
                    oCon.AsignarParametroCadena("@fechahastanota", fechaHasta);
                    oCon.AsignarParametroEntero("@notab", Convert.ToInt16(Comprobantes_Tipo.Tipo.NOTA_CREDITO_B));

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

        public DataTable ListarServiciosDeudas2(DateTime fechaHasta)
        {
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                string comando = "SELECT t.*, r.saldocc, r.id_debito_asociado, r.id as id_ctacte_det, r.id_servicios, r.servicio, r.meses_adeudados, r.tipo_ctacte_det, CONVERT(r.estado, SIGNED) AS estado_servicio "
                            + " from(SELECT usuarios.id as id_usuario,usuarios.codigo, CONCAT_WS(', ', usuarios.Nombre, usuarios.Apellido) AS usuario, zonas.id as id_zona,"
                            + " zonas.Nombre AS Zona,localidades.id as id_localidad,localidades.Nombre AS Localidad,CONCAT_WS(' ','Calle:',usuarios_locaciones.Calle,'Altura:',CONVERT(usuarios_locaciones.Altura,CHAR)) as calle,"
                            + " usuarios_locaciones.Piso, usuarios_locaciones.Depto, CONCAT_WS('-',CONVERT(usuarios_locaciones.Prefijo_1,CHAR),CONVERT(usuarios_locaciones.Telefono_1,CHAR)) as telefono1,"
                            + " CONCAT_WS('-',CONVERT(usuarios_locaciones.Prefijo_2,CHAR),CONVERT(usuarios_locaciones.Telefono_2,CHAR)) as telefono2,usuarios.Correo_Electronico , usuarios_locaciones.saldo,"
                            + " usuarios_locaciones.id AS id_usuarios_locaciones"
                            + " FROM usuarios_locaciones"
                            + " LEFT JOIN usuarios ON usuarios.id = usuarios_locaciones.Id_Usuarios"
                            + " LEFT JOIN localidades ON localidades.id = usuarios_locaciones.Id_Localidades"
                            + " LEFT JOIN zonas_localidades ON zonas_localidades.Id_Localidad = usuarios_locaciones.Id_Localidades"
                            + " LEFT JOIN zonas ON zonas.id = zonas_localidades.Id_Zona"
                            + " WHERE saldo != 0 ORDER BY usuarios_locaciones.id) AS t"
                            + " LEFT JOIN("
                            + " select usuarios_ctacte_det.id, usuarios_ctacte_det.id_usuarios_locaciones, sum(importe_saldo) as saldocc, id_debito_asociado, usuarios_ctacte_det.Id_Servicios,"
                            + " servicios.Descripcion AS servicio , count(DISTINCT usuarios_ctacte_det.Fecha_Desde) AS meses_adeudados, usuarios_ctacte_det.tipo as tipo_ctacte_det,"
                            + " GROUP_CONCAT(DISTINCT if (usuarios_servicios.Id_Servicios_Estados IN(1, 2, 3),1 ,0) SEPARATOR '') AS estado"
                            + " FROM usuarios_ctacte_det "
                            + " LEFT JOIN servicios ON servicios.id = usuarios_ctacte_det.Id_Servicios "
                            + " LEFT JOIN usuarios_servicios ON usuarios_servicios.Id = usuarios_ctacte_det.id_usuarios_servicios "
                            + " WHERE importe_saldo != 0 AND usuarios_ctacte_det.borrado = 0 AND usuarios_ctacte_det.fecha_hasta <= @fechaHasta"
                            + " GROUP BY usuarios_ctacte_det.id_usuarios_locaciones ORDER BY usuarios_ctacte_det.id_usuarios_locaciones)"
                            + " AS R ON r.id_usuarios_locaciones = t.id_usuarios_locaciones"
                            + " having r.id is not null";

                oCon.CrearComando(comando);
                oCon.AsignarParametroFecha("@fechaHasta", fechaHasta.Date);
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

        public DataTable ListarUsuariosActivos()
        {
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                oCon.CrearComando("call spUsuariosActivos()");
                dt = oCon.Tabla();
                oCon.DesConectar();
            }
            catch (Exception)
            {
                oCon.DesConectar();

            }
            return dt;
        }

        public DataTable ListarAnalisisDeuda(int mes, int anio)
        {
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                oCon.CrearComando("call spAnalisisDeuda(@mes,@anio)");
                oCon.AsignarParametroEntero("@mes", mes);
                oCon.AsignarParametroEntero("@anio", anio);
                dt = oCon.Tabla();
                oCon.DesConectar();
            }
            catch (Exception)
            {
                oCon.DesConectar();

            }
            return dt;
        }

        public DataTable ListarBalance(DateTime fecha)
        {
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();

                oCon.CrearComando("select codigo, mfact, mpago, fpago, fmovi from(select usuarios.codigo, usuarios_ctacte_det.id, ifnull(usuarios_ctacte_det.importe_original, 0) as mfact"
                + "  , usuarios_ctacte_det.fecha_desde as fmovi,"
               + " ifnull(usuarios_ctacte_relacion.importe_imputa, 0) as mpago, date(usuarios_ctacte_recibos.fecha_movimiento) as fpago"
               + " from usuarios_ctacte_det"
               + " left join usuarios_ctacte_relacion on usuarios_ctacte_relacion.id_usuarios_ctacte_det = usuarios_ctacte_det.id"
               + " left   join usuarios_ctacte_recibos on usuarios_ctacte_recibos.id = usuarios_ctacte_relacion.id_usuarios_ctacte_recibos and cuenta = 1"
               + " inner join usuarios_ctacte on usuarios_ctacte.id = usuarios_ctacte_det.id_usuarios_ctacte and usuarios_ctacte.id_comprobantes_tipo <> 7"
               + " inner join usuarios on usuarios.id = usuarios_ctacte.id_usuarios) as resultado");


                //oCon.CrearComando("SELECT usuarios.Codigo,usuarios.Apellido,usuarios.Nombre,sum(usuarios_ctacte_recibos.Importe_Recibo) AS total"
                //+ " FROM usuarios_ctacte_recibos"
                //+ " LEFT JOIN usuarios_ctacte_relacion ON usuarios_ctacte_relacion.Id_Usuarios_ctacte_recibos = usuarios_ctacte_recibos.id"
                //+ " LEFT JOIN usuarios_ctacte ON usuarios_ctacte.Id = usuarios_ctacte_relacion.Id_Usuarios_ctacte"
                //+ " LEFT JOIN usuarios_ctacte_det ON usuarios_ctacte_det.id = usuarios_ctacte_relacion.Id_Usuarios_ctacte_det"
                //+ " LEFT JOIN usuarios ON usuarios.Id = usuarios_ctacte.Id_Usuarios"
                //+ " WHERE usuarios_ctacte_relacion.Borrado = 0 AND DATE(usuarios_ctacte_recibos.Fecha_movimiento) > DATE(@fecha1) AND"
                //+ "  DATE(usuarios_ctacte_det.Fecha_Hasta) <= DATE(@fecha2) AND usuarios_ctacte.borrado = 0 AND usuarios_ctacte_det.Borrado = 0 AND usuarios_ctacte_recibos.Borrado = 0 and usuarios.borrado = 0 AND usuarios.presentacion = 1 GROUP BY usuarios_ctacte.Id_Usuarios"
                //+ " UNION"
                //+ " SELECT usuarios.Codigo, usuarios.Apellido, usuarios.Nombre, sum(usuarios_ctacte.importe_saldo) AS importe"
                //+ " FROM usuarios_ctacte_det"
                //+ " LEFT JOIN usuarios_ctacte ON usuarios_ctacte.Id = usuarios_ctacte_det.Id_Usuarios_CtaCte"
                //+ " LEFT JOIN usuarios ON usuarios.Id = usuarios_ctacte.Id_Usuarios"
                //+ " WHERE DATE(usuarios_ctacte_det.Fecha_Hasta) < DATE(@fecha3) AND usuarios_ctacte.importe_pago = 0 AND usuarios_ctacte.borrado = 0 AND usuarios_ctacte_det.Borrado = 0 and usuarios.borrado = 0 and usuarios_ctacte.importe_saldo > 0 AND usuarios.presentacion = 1 GROUP BY usuarios_ctacte.Id_Usuarios order by codigo asc");
                //oCon.AsignarParametroFecha("@fecha1", fecha);
                //oCon.AsignarParametroFecha("@fecha2", fecha);
                //oCon.AsignarParametroFecha("@fecha3", fecha);
                //dt = oCon.Tabla();
                oCon.DesConectar();
            }
            catch (Exception c)
            {
                oCon.DesConectar();
                dt.Columns.Add("error", typeof(string));
                dt.Rows.Add(c.ToString());
                dt.AcceptChanges();
            }
            return dt;
        }
    }
}
