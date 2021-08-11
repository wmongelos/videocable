using CapaDatos;
using System;
using System.Data;

namespace CapaNegocios
{
    public class Caja_Diaria
    {
        public Int32 Id { get; set; }
        public Decimal Importe_cuenta1 { get; set; }
        public Decimal Importe_cuenta2 { get; set; }
        public Int32 Recibo_cuenta1_desde { get; set; }
        public Int32 Recibo_cuenta1_hasta { get; set; }
        public Int32 Recibo_cuenta2_desde { get; set; }
        public Int32 Recibo_cuenta2_hasta { get; set; }
        public Int32 Numero { get; set; }
        public DateTime Fecha { get; set; }
        public Int32 Id_Cierre_General { get; set; }
        public Int32 Id_Puntos_cobros { get; set; }
        public Int32 Id_Personal { get; set; }

        private Conexion oCon = new Conexion();

        public Int32 Guardar(Caja_Diaria ocaja_diaria,out string salida)
        {
            int idCaja = 0;
            try
            {
                oCon.Conectar();
                if (ocaja_diaria.Id > 0)
                {
                    oCon.CrearComando("UPDATE caja_diaria set Importe_cuenta1 = @Importe_cuenta1, Importe_cuenta2 = @Importe_cuenta2,recibo_cuenta1_desde=@recibo_cuenta1_desde,recibo_cuenta1_hasta=@recibo_cuenta1_hasta,recibo_cuenta2_desde=@recibo_cuenta2_desde,recibo_cuenta2_hasta=@recibo_cuenta2_hasta,numero=@numero,fecha=@fecha,id_cierre_general= @cierre_general,id_puntos_cobros=@puntos_cobros,id_personal=@personal WHERE Id = @id");
                    oCon.AsignarParametroEntero("@id", ocaja_diaria.Id);
                }
                else
                    oCon.CrearComando("INSERT INTO caja_diaria (importe_cuenta1,importe_cuenta2,numero,fecha,id_cierre_general,id_puntos_cobros,id_personal,recibo_cuenta1_desde,recibo_cuenta1_hasta,recibo_cuenta2_desde,recibo_cuenta2_hasta) " +
                        "VALUES(@Importe_cuenta1,@Importe_cuenta2,@numero,@fecha,@cierre_general,@puntos_cobros,@personal,@recibo_cuenta1_desde,@recibo_cuenta1_hasta,@recibo_cuenta2_desde,@recibo_cuenta2_hasta); SELECT @@IDENTITY");

                oCon.AsignarParametroDecimal("@Importe_cuenta1", ocaja_diaria.Importe_cuenta1);
                oCon.AsignarParametroDecimal("@Importe_cuenta2", ocaja_diaria.Importe_cuenta2);
                oCon.AsignarParametroDecimal("@recibo_cuenta1_desde", ocaja_diaria.Recibo_cuenta1_desde);
                oCon.AsignarParametroDecimal("@recibo_cuenta1_hasta", ocaja_diaria.Recibo_cuenta1_hasta);

                oCon.AsignarParametroDecimal("@recibo_cuenta2_desde", ocaja_diaria.Recibo_cuenta2_desde);
                oCon.AsignarParametroDecimal("@recibo_cuenta2_hasta", ocaja_diaria.Recibo_cuenta2_hasta);

                oCon.AsignarParametroEntero("@numero", ocaja_diaria.Numero);
                oCon.AsignarParametroFecha("@fecha", ocaja_diaria.Fecha);
                oCon.AsignarParametroEntero("@cierre_general", ocaja_diaria.Id_Cierre_General);
                oCon.AsignarParametroEntero("@puntos_cobros", ocaja_diaria.Id_Puntos_cobros);
                oCon.AsignarParametroEntero("@personal", ocaja_diaria.Id_Personal);

                oCon.ComenzarTransaccion();
                if (ocaja_diaria.Id > 0)
                    oCon.EjecutarComando();
                else
                    idCaja = oCon.EjecutarScalar();
                oCon.ConfirmarTransaccion();
                oCon.DesConectar();
                salida = "";
            }
            catch (Exception c)
            {
                oCon.CancelarTransaccion();
                oCon.DesConectar();
                salida = c.ToString();

            }
            return idCaja;
        }

        /// <summary>
        /// Asigna el Numero de Caja a los Recibos Seleccionados
        /// </summary>
        /// <param name="dt">DataTable con los Recibos</param>
        /// <param name="id">Id de Caja</param>
        public bool Asignar_Numero_Recibos(DataTable dt, int id,out string salida)
        {
            try
            {
                oCon.Conectar();
                oCon.ComenzarTransaccion();
                foreach (DataRow dr in dt.Rows)
                {
                    var id_recibos = Int32.Parse(dr["id"].ToString());
                    oCon.CrearComando("UPDATE usuarios_ctacte_recibos set Id_caja_diaria = @Id WHERE id = @Id_recibos");
                    oCon.AsignarParametroEntero("@Id", id);
                    oCon.AsignarParametroEntero("@Id_recibos", id_recibos);
                    oCon.EjecutarComando();
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id_puntos_cobros">puntos de cobro</param>
        /// <param name="cuenta">cuanta 1 bco 2 negro</param>
        /// <param name="id_caja_general">caja general</param>
        /// <returns></returns>

        public DataTable Listar(int idCaja)
        {
            DataTable dtDatosCaja = new DataTable();
            try
            {
                oCon.Conectar();
                if (idCaja > 0)
                {
                    oCon.CrearComando("SELECT caja_diaria.id,caja_diaria.fecha,caja_diaria.importe_cuenta1,caja_diaria.importe_cuenta2,caja_diaria.id_cierre_general,caja_diaria.id_puntos_cobros,caja_diaria.id_personal,caja_diaria.borrado,caja_diaria.recibo_cuenta1_desde,caja_diaria.recibo_cuenta1_hasta,caja_diaria.recibo_cuenta2_desde,caja_diaria.recibo_cuenta2_hasta,personal.nombre as personal FROM caja_diaria left join personal on personal.id=caja_diaria.id_personal WHERE caja_diaria.id=@caja");
                    oCon.AsignarParametroEntero("@caja", idCaja);
                }
                else
                    oCon.CrearComando("SELECT caja_diaria.id,caja_diaria.fecha,caja_diaria.importe_cuenta1,caja_diaria.importe_cuenta2,caja_diaria.id_cierre_general,caja_diaria.id_puntos_cobros,caja_diaria.id_personal,caja_diaria.borrado,caja_diaria.recibo_cuenta1_desde,caja_diaria.recibo_cuenta1_hasta,caja_diaria.recibo_cuenta2_desde,caja_diaria.recibo_cuenta2_hasta,personal.nombre as personal FROM caja_diaria left join personal on personal.id=caja_diaria.id_personal WHERE caja_diaria.borrado=0");

                dtDatosCaja = oCon.Tabla();
                oCon.DesConectar();
            }
            catch (Exception)
            {
                oCon.DesConectar();

                throw;
            }
            return dtDatosCaja;
        }
        public DataTable Listar_Caja_Diaria(int id_puntos_cobros, int cuenta, int id_caja_general)
        {

            DataTable dt = new DataTable();

            try
            {
                oCon.Conectar();
                oCon.CrearComando(" select caja_diaria.id,caja_diaria.fecha,puntos_cobros.id as id_punto_cobro, puntos_cobros.descripcion as pto_cobro ,caja_diaria.importe_cuenta1,caja_diaria.importe_cuenta2,caja_diaria.recibo_cuenta1_desde,caja_diaria.recibo_cuenta1_hasta,caja_diaria.recibo_cuenta2_desde,caja_diaria.recibo_cuenta2_hasta,(caja_diaria.importe_cuenta1+caja_diaria.importe_cuenta2) as total from caja_diaria inner join puntos_cobros on puntos_cobros.id = caja_diaria.id_puntos_cobros WHERE caja_diaria.id_cierre_general=@id_caja_general and caja_diaria.borrado=@borrado ;");
                oCon.AsignarParametroEntero("@borrado", 0);
                oCon.AsignarParametroEntero("@id_caja_general", id_caja_general);
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

        public DataTable ListarCajasDiarias(int idPunto)
        {

            DataTable dt = new DataTable();

            try
            {
                oCon.Conectar();
                oCon.CrearComando("select caja_diaria.id,caja_diaria.fecha,personal.nombre as personal, caja_diaria.importe_cuenta1,caja_diaria.importe_cuenta2,caja_diaria.recibo_cuenta1_desde,caja_diaria.recibo_cuenta1_hasta,caja_diaria.recibo_cuenta2_desde,caja_diaria.recibo_cuenta2_hasta,(caja_diaria.importe_cuenta1+caja_diaria.importe_cuenta2) as total from caja_diaria inner join puntos_cobros on puntos_cobros.id = caja_diaria.id_puntos_cobros LEFT JOIN personal on personal.id=caja_diaria.id_personal WHERE caja_diaria.id_puntos_cobros=@punto and caja_diaria.borrado=0 order by caja_diaria.id desc limit 10");
                oCon.AsignarParametroEntero("@punto", idPunto);
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

        public DataTable Listar_Recibos_Det(int id_puntos_cobros, int cuenta, int id_caja_diaria, int idcuenta)
        {
            oCon.Conectar();

            oCon.CrearComando("select(select nombre from formas_de_pago where formas_de_pago.id = usuarios_ctacte_recibos_det.id_formas_de_pago ) as forma ,sum(usuarios_ctacte_recibos_det.importe) as importe,usuarios_ctacte_recibos.borrado," +
            " usuarios_ctacte_recibos.id_caja_diaria,usuarios_ctacte_recibos_det.id_formas_de_pago,usuarios_ctacte_recibos.id_comprobantes from usuarios_ctacte_recibos " +
            " left join usuarios_ctacte_recibos_det  on usuarios_ctacte_recibos_det.id_usuarios_ctacte_recibos = usuarios_ctacte_recibos.id " +
            " left join comprobantes on comprobantes.id=usuarios_ctacte_recibos.id_comprobantes" +
            " where usuarios_ctacte_recibos.id_caja_diaria = @id_caja_diaria  and usuarios_ctacte_recibos.borrado = @borrado and usuarios_ctacte_recibos.id_puntos_cobros=@id_puntos_cobros and comprobantes.id_comprobantes_tipo!=@tipoPlan and usuarios_ctacte_recibos_det.borrado=@borrado1 and usuarios_ctacte_recibos.cuenta = @cuenta " +
            " group by usuarios_ctacte_recibos_det.id_formas_de_pago");

            oCon.AsignarParametroEntero("@id_puntos_cobros", id_puntos_cobros);
            oCon.AsignarParametroEntero("@id_caja_diaria", id_caja_diaria);
            oCon.AsignarParametroEntero("@borrado", 0);
            oCon.AsignarParametroEntero("@borrado1", 0);
            oCon.AsignarParametroEntero("@tipoPlan", Convert.ToInt32(Comprobantes_Tipo.Tipo.PLAN_DE_PAGO));
            oCon.AsignarParametroEntero("@cuenta", idcuenta);


            DataTable dt = oCon.Tabla();

            oCon.DesConectar();

            return dt;
        }

        public DataTable ListarDetallesRecibos(int idpunto, int idcaja, int cuenta)
        {
            DataTable dt = new DataTable();

            try
            {
                oCon.Conectar();
                oCon.CrearComando("select vw_usuarios_ctacte_recibos.id_comprobantes, vw_usuarios_ctacte_recibos.cuenta,vw_usuarios_ctacte_recibos.id,vw_usuarios_ctacte_recibos.id_usuarios_locaciones,vw_usuarios_ctacte_recibos.numero,vw_usuarios_ctacte_recibos.id_usuarios,usuarios.codigo,if (usuarios.codigo is not null, concat(usuarios.apellido,', ',usuarios.nombre),'COBRADOR') as nomape,vw_usuarios_ctacte_recibos.numero_muestra,vw_usuarios_ctacte_recibos.fecha_movimiento,vw_usuarios_ctacte_recibos.importe_recibo,usuarios_ctacte.importe_final as importe_comprobante,"
                    + " vw_usuarios_ctacte_recibos.id_comprobantes,vw_usuarios_ctacte_recibos.id_personal,personal.nombre as nombrePersonal,comprobantes.id_comprobantes_tipo, usuarios_ctacte.descripcion as factura,vw_usuarios_ctacte_recibos.borrado,usuarios_ctacte_relacion.id_usuarios_ctacte_recibos,usuarios_ctacte_relacion.id_usuarios_ctacte, usuarios_ctacte_relacion.nuevo "
                    + " from  vw_usuarios_ctacte_recibos"
                    + " inner join personal on personal.id=vw_usuarios_ctacte_recibos.id_personal"
                    + " left join usuarios on usuarios.id=vw_usuarios_ctacte_recibos.id_usuarios "
                    + " inner join comprobantes on comprobantes.id=vw_usuarios_ctacte_recibos.id_comprobantes"
                    + " inner join usuarios_ctacte_relacion on usuarios_ctacte_relacion.id_usuarios_ctacte_recibos=vw_usuarios_ctacte_recibos.id"
                    + " left join usuarios_ctacte on usuarios_ctacte.id = usuarios_ctacte_relacion.id_usuarios_ctacte "
                    + " where vw_usuarios_ctacte_recibos.id_Caja_diaria=@idcaja and vw_usuarios_ctacte_recibos.id_puntos_cobros=@idpunto and comprobantes.id_comprobantes_tipo!=@tipoPlan and vw_usuarios_ctacte_recibos.cuenta=@cuenta"
                    + " group by usuarios_ctacte.id, usuarios_ctacte_relacion.nuevo order BY vw_usuarios_ctacte_recibos.id,personal.id,usuarios_ctacte_relacion.nuevo ASC");
                oCon.AsignarParametroEntero("@idcaja", idcaja);
                oCon.AsignarParametroEntero("@idpunto", idpunto);
                oCon.AsignarParametroEntero("@tipoPlan", Convert.ToInt32(Comprobantes_Tipo.Tipo.PLAN_DE_PAGO));
                oCon.AsignarParametroEntero("@cuenta", cuenta);

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

        public DataTable ListarDetallesRecibos(int idpunto, int idcaja, int cuenta, int borrado = 0)
        {
            DataTable dt = new DataTable();

            try
            {
                oCon.Conectar();
                oCon.CrearComando("select vw_usuarios_ctacte_recibos.id_comprobantes, vw_usuarios_ctacte_recibos.cuenta,vw_usuarios_ctacte_recibos.id,vw_usuarios_ctacte_recibos.id_usuarios_locaciones,vw_usuarios_ctacte_recibos.numero,vw_usuarios_ctacte_recibos.id_usuarios,usuarios.codigo,if (usuarios.codigo is not null, concat(usuarios.apellido,', ',usuarios.nombre),'COBRADOR') as nomape,vw_usuarios_ctacte_recibos.numero_muestra,vw_usuarios_ctacte_recibos.fecha_movimiento,vw_usuarios_ctacte_recibos.importe_recibo,usuarios_ctacte.importe_final as importe_comprobante,"
                    + " vw_usuarios_ctacte_recibos.id_comprobantes,vw_usuarios_ctacte_recibos.id_personal,personal.nombre as nombrePersonal,comprobantes.id_comprobantes_tipo, usuarios_ctacte.descripcion as factura,vw_usuarios_ctacte_recibos.borrado,usuarios_ctacte_relacion.id_usuarios_ctacte_recibos,usuarios_ctacte_relacion.id_usuarios_ctacte, usuarios_ctacte_relacion.nuevo "
                    + " from  vw_usuarios_ctacte_recibos"
                    + " inner join personal on personal.id=vw_usuarios_ctacte_recibos.id_personal"
                    + " left join usuarios on usuarios.id=vw_usuarios_ctacte_recibos.id_usuarios "
                    + " inner join comprobantes on comprobantes.id=vw_usuarios_ctacte_recibos.id_comprobantes"
                    + " inner join usuarios_ctacte_relacion on usuarios_ctacte_relacion.id_usuarios_ctacte_recibos=vw_usuarios_ctacte_recibos.id"
                    + " left join usuarios_ctacte on usuarios_ctacte.id = usuarios_ctacte_relacion.id_usuarios_ctacte "
                    + $" where vw_usuarios_ctacte_recibos.borrado = {borrado} and vw_usuarios_ctacte_recibos.id_Caja_diaria=@idcaja and vw_usuarios_ctacte_recibos.id_puntos_cobros=@idpunto and comprobantes.id_comprobantes_tipo!=@tipoPlan and vw_usuarios_ctacte_recibos.cuenta=@cuenta" //vw_usuarios_ctacte_recibos.borrado = 0 and
                    + " group by usuarios_ctacte.id, usuarios_ctacte_relacion.nuevo order BY vw_usuarios_ctacte_recibos.id,personal.id,usuarios_ctacte_relacion.nuevo ASC");
                oCon.AsignarParametroEntero("@idcaja", idcaja);
                oCon.AsignarParametroEntero("@idpunto", idpunto);
                oCon.AsignarParametroEntero("@tipoPlan", Convert.ToInt32(Comprobantes_Tipo.Tipo.PLAN_DE_PAGO));
                oCon.AsignarParametroEntero("@cuenta", cuenta);

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

        public DataTable ListarDetallesRecibosAVC(int idpunto, int idcaja, int cuenta, bool pagoExternos)
        {
            DataTable dt = new DataTable();

            try
            {
                oCon.Conectar();
                string campos = "select vw_usuarios_ctacte_recibos.id_comprobantes, vw_usuarios_ctacte_recibos.cuenta,vw_usuarios_ctacte_recibos.id,vw_usuarios_ctacte_recibos.id_usuarios_locaciones,vw_usuarios_ctacte_recibos.numero,vw_usuarios_ctacte_recibos.numero_hasta,vw_usuarios_ctacte_recibos.id_usuarios,usuarios.codigo,if (usuarios.codigo is not null, concat(usuarios.apellido,', ',usuarios.nombre),'COBRADOR') as nomape,vw_usuarios_ctacte_recibos.numero_muestra,vw_usuarios_ctacte_recibos.fecha_movimiento,vw_usuarios_ctacte_recibos.importe_recibo,"
                    + " vw_usuarios_ctacte_recibos.id_comprobantes,vw_usuarios_ctacte_recibos.id_personal,personal.nombre as nombrePersonal,comprobantes.id_comprobantes_tipo, vw_usuarios_ctacte_recibos.borrado";
                if (pagoExternos)
                    campos = campos + ", formas_de_pago.nombre as Plataforma";
                string left = " from vw_usuarios_ctacte_recibos"
                    + " inner join personal on personal.id=vw_usuarios_ctacte_recibos.id_personal"
                    + " left join usuarios on usuarios.id=vw_usuarios_ctacte_recibos.id_usuarios "
                    + " inner join comprobantes on comprobantes.id=vw_usuarios_ctacte_recibos.id_comprobantes";
                if (pagoExternos)
                    left = left + " left join usuarios_ctacte_recibos_det on usuarios_ctacte_recibos_det.id_usuarios_ctacte_recibos=vw_usuarios_ctacte_recibos.id "
                        + " left join formas_de_pago on formas_de_pago.id = usuarios_ctacte_recibos_det.id_Formas_de_pago ";

                string consulta = campos + left + " where vw_usuarios_ctacte_recibos.id_Caja_diaria=@idcaja and vw_usuarios_ctacte_recibos.id_puntos_cobros=@idpunto and vw_usuarios_ctacte_recibos.borrado=0 and comprobantes.id_comprobantes_tipo!=@tipoPlan and vw_usuarios_ctacte_recibos.cuenta=@cuenta"
                    + " order by vw_usuarios_ctacte_recibos.numero ASC";

                oCon.CrearComando(consulta);
                oCon.AsignarParametroEntero("@idcaja", idcaja);
                oCon.AsignarParametroEntero("@idpunto", idpunto);
                oCon.AsignarParametroEntero("@tipoPlan", Convert.ToInt32(Comprobantes_Tipo.Tipo.PLAN_DE_PAGO));
                oCon.AsignarParametroEntero("@cuenta", cuenta);

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

        public DataTable ListarDetallesCtaCteDetSubServicios(int idpunto, int idcaja, int cuenta)
        {
            DataTable dt = new DataTable();

            try
            {
                oCon.Conectar();
                oCon.CrearComando("select usuarios_ctacte_recibos.id_puntos_cobros,usuarios_ctacte_recibos.id_caja_diaria,usuarios_ctacte_relacion.id_usuarios_ctacte_det,usuarios_ctacte_relacion.Id_Usuarios_ctacte_recibos,usuarios_ctacte_det.tipo,usuarios_ctacte_det.id_tipo,usuarios_ctacte_det.id_usuarios_servicios_sub,usuarios_ctacte_relacion.importe_imputa, "
                + " if(usuarios_ctacte_det.id_tipo>0,case usuarios_ctacte_det.tipo"
                + "  WHEN 'S' THEN(SELECT Descripcion FROM servicios_sub WHERE Id = usuarios_ctacte_det.id_tipo)"
                + "  WHEN 'E' THEN(SELECT nombre FROM equipos_tipos WHERE Id = usuarios_ctacte_det.Id_Tipo)"
                + "  WHEN 'P' THEN(SELECT nombre from partes_fallas where id = usuarios_ctacte_det.Id_Tipo)"
                + " END,usuarios_ctacte_Det.detalles) AS sub_servicio,usuarios_ctacte_recibos.id_comprobantes,comprobantes.id_comprobantes_tipo,servicios_sub.id_servicios,servicios.descripcion as servicio,servicios.id_servicios_Tipos,servicios_tipos.Nombre AS servicio_Tipo,personal.nombre as personal "
                + " from usuarios_ctacte_recibos"
                + " inner join usuarios_ctacte_relacion on usuarios_ctacte_recibos.id = usuarios_ctacte_relacion.id_usuarios_ctacte_recibos"
                + " inner join usuarios_ctacte_det on usuarios_ctacte_det.id = usuarios_ctacte_relacion.id_usuarios_ctacte_det"
                + " inner join comprobantes on comprobantes.id=usuarios_ctacte_recibos.id_comprobantes"
                + " left join usuarios_servicios_sub on usuarios_Servicios_sub.id = usuarios_ctacte_det.id_usuarios_servicios_sub"
                + " left join servicios_sub on servicios_sub.id = usuarios_Servicios_sub.id_servicios_sub"
                + " left join servicios on servicios.id = servicios_sub.id_servicios"
                + " left join servicios_tipos ON servicios_tipos.Id = servicios.Id_Servicios_Tipos"
                + " left join personal ON personal.Id = usuarios_ctacte_recibos.id_personal"
                + " where usuarios_ctacte_recibos.id_caja_diaria = @idcaja and usuarios_ctacte_recibos.id_puntos_cobros=@idpunto and usuarios_ctacte_recibos.borrado=0 and usuarios_ctacte_relacion.borrado=0 and usuarios_ctacte_det.borrado=0 and comprobantes.id_comprobantes_tipo!=@tipoPlan and usuarios_ctacte_recibos.cuenta=@cuenta");
                oCon.AsignarParametroEntero("@idcaja", idcaja);
                oCon.AsignarParametroEntero("@idpunto", idpunto);
                oCon.AsignarParametroEntero("@tipoPlan", Convert.ToInt32(Comprobantes_Tipo.Tipo.PLAN_DE_PAGO));
                oCon.AsignarParametroEntero("@cuenta", cuenta);


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

        public DataTable ListarDetallesCtaCteDetPagos(int idpunto, int idcaja, int cuenta)
        {
            DataTable dt = new DataTable();

            try
            {
                oCon.Conectar();
                if (idpunto > 0 && idcaja > 0)
                {
                    oCon.CrearComando("select usuarios_ctacte_recibos_det.id_usuarios_ctacte_recibos,usuarios_ctacte_recibos.id_usuarios,usuarios.codigo,concat(usuarios.apellido,', ',usuarios.nombre) as nomape,usuarios_ctacte_recibos.numero_muestra,usuarios_ctacte_Recibos_Det.fecha_acreditacion,usuarios_ctacte_Recibos_Det.importe,usuarios_ctacte_Recibos_Det.id_formas_De_pago,Formas_de_pago.nombre,usuarios_ctacte_recibos_det.id_comprobantes,comprobantes.id_comprobantes_tipo,usuarios_ctacte_recibos_det.borrado,personal.nombre as personal"
                        + " from usuarios_ctacte_recibos_det"
                        + " inner join usuarios_ctacte_recibos on usuarios_Ctacte_recibos.id = usuarios_Ctacte_recibos_det.id_usuarios_ctacte_recibos"
                        + " inner join formas_de_pago on formas_De_pago.id = usuarios_ctacte_recibos_det.id_formas_De_pago "
                        + " left join usuarios on usuarios.id=usuarios_ctacte_recibos.id_usuarios"
                        + " inner join comprobantes on comprobantes.id=usuarios_ctacte_recibos_det.id_comprobantes"
                        + " inner join personal on personal.id=usuarios_ctacte_recibos.id_personal"
                        + " WHERE comprobantes.id_comprobantes_tipo!= @tipoPlan and usuarios_Ctacte_recibos.id_caja_diaria=@idcaja and usuarios_ctacte_recibos.id_puntos_cobros=@idpunto and usuarios_ctacte_recibos_det.borrado=0 and usuarios_ctacte_recibos.cuenta=@cuenta");
                    oCon.AsignarParametroEntero("@tipoPlan", Convert.ToInt32(Comprobantes_Tipo.Tipo.PLAN_DE_PAGO));
                    oCon.AsignarParametroEntero("@idcaja", idcaja);
                    oCon.AsignarParametroEntero("@idpunto", idpunto);
                    oCon.AsignarParametroEntero("@cuenta", cuenta);
                }
                else
                {
                    string consulta;
                    if (idpunto == 0 && idcaja == 0 && cuenta == 0)
                    {
                        consulta = "select usuarios_ctacte_recibos_det.id_usuarios_ctacte_recibos,usuarios_ctacte_recibos.id_usuarios,usuarios.codigo,concat(usuarios.apellido,', ',usuarios.nombre) as nomape, " +
                       "usuarios_ctacte_recibos.numero_muestra,usuarios_ctacte_Recibos_Det.fecha_acreditacion,usuarios_ctacte_Recibos_Det.importe,usuarios_ctacte_Recibos_Det.id_formas_De_pago,Formas_de_pago.nombre,usuarios_ctacte_recibos_det.borrado from usuarios_ctacte_recibos_det"
                       + " inner join usuarios_ctacte_recibos on usuarios_Ctacte_recibos.id = usuarios_Ctacte_recibos_det.id_usuarios_ctacte_recibos"
                       + " inner join formas_de_pago on formas_De_pago.id = usuarios_ctacte_recibos_det.id_formas_De_pago "
                       + " left join usuarios on usuarios.id=usuarios_ctacte_recibos.id_usuarios WHERE  usuarios_Ctacte_recibos.id_caja_diaria = 0 and usuarios_ctacte_Recibos_Det.borrado = 0 ";

                        oCon.CrearComando(consulta);
                    }
                    else
                    {
                        consulta = "select usuarios_ctacte_recibos_det.id_usuarios_ctacte_recibos,usuarios_ctacte_recibos.id_usuarios,usuarios.codigo,concat(usuarios.apellido,', ',usuarios.nombre) as nomape, " +
                       "usuarios_ctacte_recibos.numero_muestra,usuarios_ctacte_Recibos_Det.fecha_acreditacion,usuarios_ctacte_Recibos_Det.importe,usuarios_ctacte_Recibos_Det.id_formas_De_pago,Formas_de_pago.nombre,usuarios_ctacte_recibos_det.borrado, personal.nombre as personal from usuarios_ctacte_recibos_det"
                       + " inner join usuarios_ctacte_recibos on usuarios_Ctacte_recibos.id = usuarios_Ctacte_recibos_det.id_usuarios_ctacte_recibos"
                       + " inner join formas_de_pago on formas_De_pago.id = usuarios_ctacte_recibos_det.id_formas_De_pago "
                       + " left join usuarios on usuarios.id=usuarios_ctacte_recibos.id_usuarios "
                       + " left join personal on personal.id = usuarios_ctacte_recibos.id_personal WHERE usuarios_Ctacte_recibos.id_caja_diaria = 0 and usuarios_ctacte_recibos.id_puntos_cobros=@idpunto and usuarios_ctacte_Recibos_Det.borrado = 0 ";
                        if (cuenta > 0)
                            consulta = consulta + "and usuarios_ctacte_recibos.cuenta=@cuenta";
                        oCon.CrearComando(consulta);
                        if (cuenta > 0)
                            oCon.AsignarParametroEntero("@cuenta", cuenta);


                        oCon.AsignarParametroEntero("@idpunto", idpunto);
                    }

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

        public DataTable UltimaCajaPuntoCobro(int idPunto)
        {
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                oCon.CrearComando("SELECT id,fecha,numero,importe_cuenta1,importe_cuenta2,id_cierre_general,id_puntos_cobros,id_personal,borrado,recibo_cuenta1_desde,recibo_cuenta1_hasta,recibo_cuenta2_desde,recibo_cuenta2_hasta FROM caja_diaria WHERE id_puntos_cobros=@idPunto and borrado=0 order by numero asc limit 1");
                oCon.AsignarParametroEntero("@idPunto", idPunto);
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

        public DataTable GetEstructuraDatosCajaDiariaImpresion()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("id_personal", typeof(string));
            dt.Columns.Add("personal", typeof(string));
            dt.Columns.Add("punto_cobro", typeof(string));
            dt.Columns.Add("numero_caja", typeof(string));
            dt.Columns.Add("recibo_desde", typeof(string));
            dt.Columns.Add("recibo_hasta", typeof(string));
            dt.Columns.Add("cant_total_recibos", typeof(string));
            dt.Columns.Add("monto_total_recibos", typeof(string));
            dt.Columns.Add("cant_total_anulados", typeof(string));
            dt.Columns.Add("monto_total_anulados", typeof(string));
            dt.Columns.Add("cant_final_recibos", typeof(string));
            dt.Columns.Add("monto_final_recibos", typeof(string));
            return dt;
        }

        public DataTable GetEstructuraDatosFormasPagoImpresion()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("forma_pago", typeof(string));
            dt.Columns.Add("cantidad", typeof(string));
            dt.Columns.Add("monto", typeof(string));
            return dt;
        }

        public DataTable ListarCajasIdCajaGeneral(int idCaja_Generales)
        {
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                oCon.CrearComando("SELECT caja_diaria.id as id_Diaria,puntos_cobros.Descripcion AS Punto_Cobro, caja_diaria.Fecha AS Fecha_Caja, " +
                    "caja_diaria.Importe_Cuenta1 AS ImpCuenta1, caja_diaria.importe_Cuenta2 AS ImpCuenta2, (caja_diaria.Importe_Cuenta1 + caja_diaria.Importe_Cuenta2) AS Total, " +
                    "personal.Nombre AS Personales " +
                    "FROM caja_diaria " +
                    "LEFT JOIN puntos_cobros ON caja_diaria.id_puntos_cobros = puntos_cobros.id " +
                    "LEFT JOIN personal ON caja_diaria.id_personal = personal.id " +
                    "WHERE id_Cierre_General = @idCierre AND caja_diaria.borrado = 0; ");
                oCon.AsignarParametroEntero("@idCierre", idCaja_Generales);
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

        public DataTable ListarDetallesCajaDiaria(int id_CajaDiaria, int Filtro)
        {
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                if (Filtro == 1)
                {
                    oCon.CrearComando("SELECT servicios.Descripcion AS Servicio, " +
                        "sum(usuarios_ctacte_relacion.Importe_imputa + usuarios_ctacte_relacion.Importe_Punitorio + usuarios_ctacte_relacion.Importe_provincial - usuarios_ctacte_relacion.Importe_Bonificacion) AS Importe, " +
                        "SUM(usuarios_ctacte_det.Importe_Final) AS ImporteDet " +
                        "FROM usuarios_ctacte_recibos " +
                        "LEFT JOIN caja_diaria ON usuarios_ctacte_recibos.Id_Caja_Diaria = caja_diaria.id " +
                        "LEFT JOIN usuarios_ctacte_recibos_det ON usuarios_ctacte_recibos_det.Id_Usuarios_Ctacte_recibos = usuarios_ctacte_recibos.id " +
                        "LEFT JOIN usuarios_ctacte_relacion ON usuarios_ctacte_relacion.Id_Usuarios_ctacte_recibos = usuarios_ctacte_recibos.id " +
                        "LEFT JOIN usuarios_ctacte_det ON usuarios_ctacte_relacion.Id_Usuarios_ctacte_det = usuarios_ctacte_det.Id " +
                        "LEFT JOIN servicios ON usuarios_ctacte_det.Id_Servicios = servicios.id " +
                        "WHERE caja_diaria.id = @id_Caja and usuarios_ctacte_det.borrado= 0 AND usuarios_ctacte_recibos.borrado=0 AND usuarios_ctacte_recibos_Det.borrado=0 " +
                        "AND usuarios_ctacte_relacion.Borrado = 0 AND servicios.borrado = 0 " +
                        "GROUP BY servicios.id;");
                }
                else if (Filtro == 2)
                {
                    oCon.CrearComando("SELECT formas_de_pago.Nombre AS FormaPago, " +
                        "sum(usuarios_ctacte_relacion.Importe_imputa + usuarios_ctacte_relacion.Importe_Punitorio + usuarios_ctacte_relacion.Importe_provincial - usuarios_ctacte_relacion.Importe_Bonificacion) AS Importe, " +
                        "SUM(usuarios_ctacte_det.Importe_Final) AS ImporteDet " +
                        "FROM usuarios_ctacte_recibos " +
                        "LEFT JOIN caja_diaria ON usuarios_ctacte_recibos.Id_Caja_Diaria = caja_diaria.id " +
                        "LEFT JOIN usuarios_ctacte_recibos_det ON usuarios_ctacte_recibos_det.Id_Usuarios_Ctacte_recibos = usuarios_ctacte_recibos.id " +
                        "LEFT JOIN formas_de_pago ON usuarios_ctacte_recibos_det.Id_Formas_de_Pago = formas_de_pago.id " +
                        "LEFT JOIN usuarios_ctacte_relacion ON usuarios_ctacte_relacion.Id_Usuarios_ctacte_recibos = usuarios_ctacte_recibos.id " +
                        "LEFT JOIN usuarios_ctacte_det ON usuarios_ctacte_relacion.Id_Usuarios_ctacte_det = usuarios_ctacte_det.Id " +
                        "LEFT JOIN servicios ON usuarios_ctacte_det.Id_Servicios = servicios.id " +
                        "WHERE caja_diaria.id = @id_Caja and usuarios_ctacte_det.borrado= 0 AND usuarios_ctacte_recibos.borrado=0 AND usuarios_ctacte_recibos_Det.borrado=0 " +
                        "AND usuarios_ctacte_relacion.Borrado = 0 AND servicios.borrado = 0 " +
                        "GROUP BY formas_de_pago.id; ");
                }
                else 
                {
                    oCon.CrearComando("SELECT usuarios_ctacte_recibos.id AS Id_recibo, usuarios_ctacte_recibos.Fecha_movimiento AS FechaRecibo, " +
                        "usuarios_ctacte_recibos.Importe_Recibo AS Importe, usuarios_ctacte_recibos.Importe_Rendido AS ImportePago, " +
                        "usuarios_ctacte_recibos.Numero_Muestra AS Recibo, " +
                        "CONCAT(usuarios.Apellido, ' , ', usuarios.Nombre) AS Usuario " +
                        "FROM usuarios_ctacte_recibos " +
                        "LEFT JOIN usuarios ON usuarios_ctacte_recibos.id_usuarios = usuarios.id " +
                        "WHERE usuarios_ctacte_recibos.Id_Caja_Diaria = @id_Caja AND usuarios_ctacte_recibos.borrado = 0; ");
                }

                oCon.AsignarParametroEntero("@id_Caja", id_CajaDiaria);
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
