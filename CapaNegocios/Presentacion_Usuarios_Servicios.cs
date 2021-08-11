using CapaDatos;
using System;
using System.Data;

namespace CapaNegocios
{
    public class Presentacion_Usuarios_Servicios
    {
        public int Id { get; set; }
        public int Id_Presentacion { get; set; }
        public int Id_Plastico { get; set; }
        public int Id_Usuarios_Servicios { get; set; }
        public decimal Monto_Estimado { get; set; }
        public decimal Monto_Prefacturacion { get; set; }
        public decimal Monto_Deuda_Adelantada { get; set; }
        public decimal Monto_Deuda_Atrasada { get; set; }

        private Conexion oCon = new Conexion();

        public enum TIPO_DEUDA
        {
            DEUDA_ADELANTANDA = 1,
            DEUDA_ATRASADA = 2,
            DEUDA_ADICIONAL = 3,
            DEUDA_PREFACTURACION = 4

        }

        public int Guardar(Presentacion_Usuarios_Servicios oPresentacionUsuariosServicios)
        {
            try
            {
                oCon.Conectar();
                oCon.CrearComando("insert into presentacion_usuarios_servicios(id_presentacion, id_plastico, id_usuarios_servicios, monto_estimado, monto_prefacturacion, monto_deuda_adelantada, monto_deuda_atrasada) VALUES" +
                                       "(@id_presentacion, @id_plastico, @id_usuarios_servicios, @monto_estimado, @monto_prefacturacion, @monto_deuda_adelantada, @monto_deuda_atrasada); SELECT @@IDENTITY");
                oCon.AsignarParametroEntero("@id_presentacion", oPresentacionUsuariosServicios.Id_Presentacion);
                oCon.AsignarParametroEntero("@id_plastico", oPresentacionUsuariosServicios.Id_Plastico);
                oCon.AsignarParametroEntero("@id_usuarios_servicios", oPresentacionUsuariosServicios.Id_Usuarios_Servicios);
                oCon.AsignarParametroDecimal("@monto_estimado", oPresentacionUsuariosServicios.Monto_Estimado);
                oCon.AsignarParametroDecimal("@monto_prefacturacion", oPresentacionUsuariosServicios.Monto_Prefacturacion);
                oCon.AsignarParametroDecimal("@monto_deuda_adelantada", oPresentacionUsuariosServicios.Monto_Deuda_Adelantada);
                oCon.AsignarParametroDecimal("@monto_deuda_atrasada", oPresentacionUsuariosServicios.Monto_Deuda_Atrasada);

                oCon.ComenzarTransaccion();
                oPresentacionUsuariosServicios.Id = oCon.EjecutarScalar();
                oCon.ConfirmarTransaccion();
                oCon.DesConectar();
            }
            catch (Exception)
            {
                oCon.CancelarTransaccion();
                oCon.DesConectar();
                throw;
            }
            return oPresentacionUsuariosServicios.Id;
        }

        public int GuardarPresentacionUsuariosServiciosSub(int idPresentacion, int idPlastico, int idUsuariosServicios, int idUsuariosServiciosSub, decimal montoEstimado, decimal montoPrefacturacion, decimal montoDeudaAdelantada, decimal montoDeudaAtrasada)
        {
            int idPresentacionUsuariosServiciosSub = 0;
            try
            {

                oCon.Conectar();
                oCon.CrearComando("insert into presentacion_usuarios_servicios_sub(id_presentacion, id_plastico, id_usuarios_servicios, id_usuarios_servicios_sub, monto_estimado, monto_prefacturacion, monto_deuda_adelantada, monto_deuda_atrasada) VALUES" +
                                       "(@id_presentacion, @id_plastico, @id_usuarios_servicios, @id_usuarios_servicios_sub, @monto_estimado, @monto_prefacturacion, @monto_deuda_adelantada, @monto_deuda_atrasada); SELECT @@IDENTITY");
                oCon.AsignarParametroEntero("@id_presentacion", idPresentacion);
                oCon.AsignarParametroEntero("@id_plastico", idPlastico);
                oCon.AsignarParametroEntero("@id_usuarios_servicios", idUsuariosServicios);
                oCon.AsignarParametroEntero("@id_usuarios_servicios_sub", idUsuariosServiciosSub);

                oCon.AsignarParametroDecimal("@monto_estimado", montoEstimado);
                oCon.AsignarParametroDecimal("@monto_prefacturacion", montoPrefacturacion);
                oCon.AsignarParametroDecimal("@monto_deuda_adelantada", montoDeudaAdelantada);
                oCon.AsignarParametroDecimal("@monto_deuda_atrasada", Monto_Deuda_Atrasada);

                oCon.ComenzarTransaccion();
                idPresentacionUsuariosServiciosSub = oCon.EjecutarScalar();
                oCon.ConfirmarTransaccion();
                oCon.DesConectar();
            }
            catch (Exception)
            {
                oCon.CancelarTransaccion();
                oCon.DesConectar();
                throw;
            }
            return idPresentacionUsuariosServiciosSub;
        }

        public DataTable Listar(int idPresentacion, int idPlastico)
        {
            DataTable dt = new DataTable();

            try
            {
                oCon.Conectar();
                oCon.CrearComando(String.Format("select * from vw_presentacion_usuarios_servicios where id_presentacion={0}", idPresentacion));
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

        public DataTable GetEstructuraPresentacionUsuariosServiciosSub()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("id", typeof(int));
            dt.Columns.Add("id_presentacion", typeof(int));
            dt.Columns.Add("id_plastico", typeof(int));
            dt.Columns.Add("id_usuarios_servicios", typeof(int));
            dt.Columns.Add("id_usuarios_servicios_sub", typeof(int));
            dt.Columns.Add("servicio_sub", typeof(string));
            dt.Columns.Add("monto_deuda_atrasada", typeof(decimal));
            dt.Columns.Add("monto_estimado", typeof(decimal));
            dt.Columns.Add("monto_prefacturacion", typeof(decimal));
            dt.Columns.Add("monto_deuda_adelantada", typeof(decimal));
            dt.Columns.Add("total", typeof(decimal));
            return dt;
        }

        public int GuardarPresentacionDeudasAnexadas(int idPresentacion, int idPlastico, int idUsuariosLocaciones, int idUsuariosServicios, int idUsuariosServiciosSub, int idComprobante, int idUsuariosCtaCte, int idUsuariosCtaCteDet, int tipoDeuda, decimal total, int idUsuario)
        {
            int idPresentacionUsuariosServiciosSub = 0;
            try
            {
                oCon.Conectar();
                oCon.CrearComando("insert into presentacion_deudas_anexadas(id_presentacion, id_plastico, id_usuarios_locaciones, id_usuarios_servicios, id_usuarios_servicios_sub, id_comprobante, id_usuarios_ctacte, id_usuarios_ctacte_det, tipo_deuda, total, id_usuarios) VALUES" +
                                       "(@id_presentacion, @id_plastico, @id_usuarios_locaciones,@id_usuarios_servicios, @id_usuarios_servicios_sub, @id_comprobante, @id_usuarios_ctacte, @id_usuarios_ctacte_det, @tipo_deuda, @total, @id_usuario); SELECT @@IDENTITY");
                oCon.AsignarParametroEntero("@id_presentacion", idPresentacion);
                oCon.AsignarParametroEntero("@id_plastico", idPlastico);
                oCon.AsignarParametroEntero("@id_usuarios_locaciones", idUsuariosLocaciones);
                oCon.AsignarParametroEntero("@id_usuarios_servicios", idUsuariosServicios);
                oCon.AsignarParametroEntero("@id_usuarios_servicios_sub", idUsuariosServiciosSub);
                oCon.AsignarParametroEntero("@id_comprobante", idComprobante);
                oCon.AsignarParametroEntero("@id_usuarios_ctacte", idUsuariosCtaCte);
                oCon.AsignarParametroEntero("@id_usuarios_ctacte_det", idUsuariosCtaCteDet);
                oCon.AsignarParametroEntero("@tipo_deuda", tipoDeuda);
                oCon.AsignarParametroDecimal("@total", total);
                oCon.AsignarParametroEntero("@id_usuario", idUsuario);

                oCon.ComenzarTransaccion();
                idPresentacionUsuariosServiciosSub = oCon.EjecutarScalar();
                oCon.ConfirmarTransaccion();
                oCon.DesConectar();
            }
            catch (Exception)
            {
                oCon.CancelarTransaccion();
                oCon.DesConectar();
                throw;
            }
            return idPresentacionUsuariosServiciosSub;
        }

        public DataTable ListarDeudasAnexadas(int idPresentacion)
        {
            DataTable dt = new DataTable();

            try
            {
                oCon.Conectar();
                oCon.CrearComando(String.Format("select * from vw_presentacion_deudas_anexadas where id_presentacion={0}", idPresentacion));
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

        public DataTable[] ListarDeudasPorPlasticos(int idPresentacion, int mes, int anio)
        {
            DataTable[] dt = new DataTable[2];
            DataTable dt1 = new DataTable();
            DataTable dt2 = new DataTable();

            try
            {
                oCon.Conectar();
                oCon.CrearComando(String.Format("select usuarios_ctacte.*,usuarios_ctacte_det.id as id_det, usuarios_ctacte_det.id_presentacion,usuarios_ctacte_det.id_debito_asociado, plasticos.titular,usuarios.codigo,comprobantes.Id_Comprobantes_Tipo,"
                + " concat(usuarios.apellido, ', ', usuarios.nombre) as usuario,plasticos.numero as plastico, SUM(usuarios_Ctacte_det.importe_saldo) AS total1,usuarios_ctacte_det.id_usuarios_locaciones,SUM(usuarios_ctacte_det.importe_presentado) as importe_presentado"
                + " from usuarios_ctacte"
                + " left join usuarios_Ctacte_det on usuarios_ctacte.id = usuarios_ctacte_det.id_usuarios_ctacte"
                + " left join plasticos on plasticos.id = usuarios_ctacte_det.id_debito_asociado"
                + " left join usuarios on usuarios.id = usuarios_ctacte.id_usuarios"
                + " LEFT JOIN comprobantes ON comprobantes.Id = usuarios_ctacte.id_comprobantes"
                + " where usuarios_ctacte_det.borrado=0 and (usuarios_ctacte_det.id_presentacion={0} and (usuarios_ctacte_det.mes_presentacion={1} and usuarios_ctacte_det.ano_presentacion={2})) and usuarios_ctacte.id_usuarios_ctacte_recibos=0 GROUP BY usuarios_ctacte_det.id_usuarios_ctacte,usuarios_ctacte.id_usuarios order by codigo ", idPresentacion, mes, anio));
                dt[0] = oCon.Tabla();

                oCon.CrearComando(String.Format("select usuarios_ctacte.*,usuarios_ctacte_det.id as id_det, usuarios_ctacte_det.id_presentacion,usuarios_ctacte_det.id_debito_asociado, plasticos.titular,usuarios.codigo,comprobantes.Id_Comprobantes_Tipo,"
             + " concat(usuarios.apellido, ', ', usuarios.nombre) as usuario,plasticos.numero as plastico, SUM(usuarios_Ctacte_det.importe_saldo) AS total1,usuarios_ctacte_det.id_usuarios_locaciones,SUM(usuarios_ctacte_det.importe_presentado) as importe_presentado"
             + " from usuarios_ctacte"
             + " left join usuarios_Ctacte_det on usuarios_ctacte.id = usuarios_ctacte_det.id_usuarios_ctacte"
             + " left join plasticos on plasticos.id = usuarios_ctacte_det.id_debito_asociado"
             + " left join usuarios on usuarios.id = usuarios_ctacte.id_usuarios"
             + " LEFT JOIN comprobantes ON comprobantes.Id = usuarios_ctacte.id_comprobantes"
             + " where usuarios_ctacte_det.borrado=0 and usuarios_ctacte_det.id_presentacion={0} and usuarios_ctacte.id_usuarios_ctacte_recibos=0 GROUP BY usuarios_ctacte_det.id_debito_asociado order by codigo ", idPresentacion));
                dt[1] = oCon.Tabla();
                oCon.DesConectar();
            }
            catch (Exception)
            {
                oCon.DesConectar();
                throw;
            }

            return dt;
        }

        public DataTable ListarPlasticosSubServicios(int idPresentacion, int idUsuariosServiciosSub)
        {
            DataTable dt = new DataTable();

            try
            {
                oCon.Conectar();
                if (idUsuariosServiciosSub == 0)
                    oCon.CrearComando(String.Format("SELECT presentacion_usuarios_servicios_sub.Id AS id, presentacion_usuarios_servicios_sub.id_presentacion, presentacion_usuarios_servicios_sub.id_plastico," +
                " presentacion_usuarios_servicios_sub.id_usuarios_servicios, presentacion_usuarios_servicios_sub.id_usuarios_servicios_sub, uss.descripcion as servicio_sub," +
                " presentacion_usuarios_servicios_sub.monto_deuda_atrasada, presentacion_usuarios_servicios_sub.monto_estimado, presentacion_usuarios_servicios_sub.monto_prefacturacion," +
                " presentacion_usuarios_servicios_sub.monto_deuda_adelantada," +
                " (SELECT((presentacion_usuarios_servicios_sub.monto_deuda_atrasada + presentacion_usuarios_servicios_sub.monto_estimado) + presentacion_usuarios_servicios_sub.monto_deuda_adelantada)) AS total" +
                " FROM presentacion_usuarios_servicios_sub left join (select usuarios_servicios_sub.*, servicios_sub.descripcion from usuarios_servicios_sub left join servicios_sub on usuarios_servicios_sub.id_servicios_sub=servicios_sub.id)uss on presentacion_usuarios_servicios_sub.id_usuarios_servicios_sub=uss.id where presentacion_usuarios_servicios_sub.id_presentacion = {0}", idPresentacion));
                else
                    oCon.CrearComando(String.Format("SELECT presentacion_usuarios_servicios_sub.Id AS id, presentacion_usuarios_servicios_sub.id_presentacion, presentacion_usuarios_servicios_sub.id_plastico," +
                        " presentacion_usuarios_servicios_sub.id_usuarios_servicios, presentacion_usuarios_servicios_sub.id_usuarios_servicios_sub, servicios_sub.descripcion as servicio_sub," +
                        " presentacion_usuarios_servicios_sub.monto_deuda_atrasada, presentacion_usuarios_servicios_sub.monto_estimado, presentacion_usuarios_servicios_sub.monto_prefacturacion," +
                        " presentacion_usuarios_servicios_sub.monto_deuda_adelantada," +
                        " (SELECT((presentacion_usuarios_servicios_sub.monto_deuda_atrasada + presentacion_usuarios_servicios_sub.monto_estimado) + presentacion_usuarios_servicios_sub.monto_deuda_adelantada)) AS total" +
                        " FROM presentacion_usuarios_servicios_sub left join usuarios_servicios_sub on presentacion_usuarios_servicios_sub.id_usuarios_servicios_sub = usuarios_servicios_sub.id" +
                        " left join servicios_sub on usuarios_servicios_sub.id_servicios_sub where presentacion_usuarios_servicios_sub.id_presentacion = {0} and presentacion_usuarios_servicios_sub.id_usuarios_servicios_sub = {1}", idPresentacion, idUsuariosServiciosSub));
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

    }
}
