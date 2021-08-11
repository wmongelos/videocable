using CapaDatos;
using System;
using System.Data;

namespace CapaNegocios
{
    public class Caja_general
    {
        public Int32 Id { get; set; }
        public decimal Importe_cuenta1 { get; set; }
        public decimal Importe_cuenta2 { get; set; }
        public decimal importe_total { get; set; }
        public Int32 Numero { get; set; }
        public DateTime Fecha { get; set; }
        public Int32 Id_Cierre_General { get; set; }
        public Int32 Id_Puntos_cobros { get; set; }
        public Int32 Id_Personal { get; set; }
        private Conexion oCon = new Conexion();

        public int Guardar(Caja_general ocaja_general)
        {
            int id = 0;
            try
            {
                oCon.Conectar();

                if (ocaja_general.Id > 0)
                {

                    oCon.CrearComando("UPDATE caja_general set Importe_cuenta1 = @importe_cuenta1, Importe_cuenta2 = @Importe_cuenta2,id_personal=@personal WHERE Id = @id");
                    oCon.AsignarParametroDecimal("@Importe_cuenta1", ocaja_general.Importe_cuenta1);
                    oCon.AsignarParametroDecimal("@Importe_cuenta2", ocaja_general.Importe_cuenta2); 
                    oCon.AsignarParametroEntero("@personal", Personal.Id_Login);
                    oCon.AsignarParametroEntero("@id", ocaja_general.Id);
                }
                else
                {
                    oCon.CrearComando("INSERT INTO caja_general (importe_cuenta1,importe_cuenta2,fecha,importe_total,id_personal) " +
                        "VALUES(@Importe_cuenta1,@Importe_cuenta2,@fecha,@importe_total,@id_personal); SELECT @@IDENTITY");

                    oCon.AsignarParametroDecimal("@Importe_cuenta1", ocaja_general.Importe_cuenta1);
                    oCon.AsignarParametroDecimal("@Importe_cuenta2", ocaja_general.Importe_cuenta2);
                    oCon.AsignarParametroFecha("@fecha", ocaja_general.Fecha);
                    oCon.AsignarParametroDecimal("@importe_total", ocaja_general.importe_total);
                    oCon.AsignarParametroEntero("@id_personal", ocaja_general.Id_Personal);
                }


                oCon.ComenzarTransaccion();
                id = oCon.EjecutarScalar();
                oCon.ConfirmarTransaccion();
                oCon.DesConectar();
            }
            catch (Exception)
            {
                oCon.CancelarTransaccion();
                oCon.DesConectar();

                throw;
            }
            return id;
        }


        public void Asignar_Numero_De_Caja(DataTable dt, int idCajaGeneral)
        {
            oCon.Conectar();
            oCon.ComenzarTransaccion();
            try
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Int32 IdCajaDiaria = Convert.ToInt32(dr["id"].ToString());
                    oCon.CrearComando("UPDATE caja_diaria set Id_cierre_general = @Idcajageneral WHERE id = @Idcaja");

                    oCon.AsignarParametroEntero("@Idcajageneral", idCajaGeneral);
                    oCon.AsignarParametroEntero("@Idcaja", IdCajaDiaria);
                    oCon.EjecutarComando();
                }

            }
            catch (Exception)
            {

                throw;
            }

            oCon.ConfirmarTransaccion();
            oCon.DesConectar();
        }

        public DataTable Listar(int id = 0)
        {
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                string consulta = "SELECT id,fecha, importe_cuenta1,importe_cuenta2,controlada,id_personal,importe_total FROM caja_general where borrado=0";
                if (id == 0)
                    consulta = consulta + " and id>0";
                else
                    consulta = consulta + $" and id={id}";

                consulta = consulta + " order by id desc";
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
        
        public DataTable ListarCajasCerradas(DateTime desde, DateTime hasta)
        {
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                oCon.CrearComando("SELECT id,fecha,importe_cuenta1,importe_cuenta2,IF(controlada=0,'NO','SI')AS controlada,id_personal,importe_total FROM caja_general WHERE borrado=0 and fecha BETWEEN DATE(@desde) and DATE(@hasta)");
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


        public DataTable TraerFormasdePago(Int32 idCajaGeneral)
        {
            DataTable dt = new DataTable();
            oCon.Conectar();

            oCon.CrearComando(String.Format("select* from(select usuarios_ctacte_recibos_det.id, usuarios_ctacte_recibos_det.importe, usuarios_ctacte_recibos_det.id_formas_de_pago, "
            + " usuarios_ctacte_recibos.cuenta, usuarios_ctacte_recibos.borrado, ifnull(caja_general.id, 0) as cajageneral "
            + " from usuarios_ctacte_recibos_det "
            + " left join usuarios_ctacte_recibos on usuarios_ctacte_recibos.id = usuarios_ctacte_recibos_det.id_usuarios_ctacte_recibos "
            + " left join caja_diaria on caja_diaria.id = usuarios_ctacte_recibos.id_caja_diaria "
            + " left join caja_general on caja_general.id = caja_diaria.id_cierre_general) as t where t.cajageneral = {0} ", idCajaGeneral));


            dt = oCon.Tabla();
            oCon.DesConectar();

            return dt;

        }

        public DataTable ListarCajaGeneral(DateTime desde, DateTime hasta)
        {
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                oCon.CrearComando("SELECT 'GENERAL' AS CajaGeneral, caja_general.* " +
                "FROM caja_general " +
                "WHERE DATE(caja_general.Fecha) >= @desde AND DATE(caja_general.Fecha) <= @hasta AND borrado = 0;");
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

        public DataTable ListarDetalleCajaGeneral(int id_cajaGeneral, int Filtro)
        {
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                if(Filtro == 1) 
                { 
                    oCon.CrearComando("SELECT servicios.Descripcion AS Servicio, " +
                        "sum(usuarios_ctacte_relacion.Importe_imputa + usuarios_ctacte_relacion.Importe_Punitorio + usuarios_ctacte_relacion.Importe_provincial - usuarios_ctacte_relacion.Importe_Bonificacion) AS Importe " +
                        "FROM usuarios_ctacte_recibos " +
                        "LEFT JOIN caja_diaria ON usuarios_ctacte_recibos.Id_Caja_Diaria = caja_diaria.id " +
                        "LEFT JOIN usuarios_ctacte_relacion ON usuarios_ctacte_relacion.Id_Usuarios_ctacte_recibos = usuarios_ctacte_recibos.id " +
                        "LEFT JOIN usuarios_ctacte_det ON usuarios_ctacte_relacion.Id_Usuarios_ctacte_det = usuarios_ctacte_det.Id " +
                        "LEFT JOIN servicios ON usuarios_ctacte_det.Id_Servicios = servicios.id " +
                        "WHERE caja_diaria.Id_Cierre_General = @idGeneral AND usuarios_ctacte_det.borrado = 0 " +
                        "GROUP BY servicios.id; ");
                }
                else 
                {
                    oCon.CrearComando("SELECT formas_de_pago.Nombre AS FormaPago, " +
                        "sum(usuarios_ctacte_relacion.Importe_imputa + usuarios_ctacte_relacion.Importe_Punitorio + usuarios_ctacte_relacion.Importe_provincial - usuarios_ctacte_relacion.Importe_Bonificacion) AS Importe " +
                        "FROM usuarios_ctacte_recibos " +
                        "LEFT JOIN caja_diaria ON usuarios_ctacte_recibos.Id_Caja_Diaria = caja_diaria.id " +
                        "LEFT JOIN usuarios_ctacte_recibos_det ON usuarios_ctacte_recibos_det.Id_Usuarios_Ctacte_recibos = usuarios_ctacte_recibos.id " +
                        "LEFT JOIN formas_de_pago ON usuarios_ctacte_recibos_det.Id_Formas_de_Pago = formas_de_pago.id " +
                        "LEFT JOIN usuarios_ctacte_relacion ON usuarios_ctacte_relacion.Id_Usuarios_ctacte_recibos = usuarios_ctacte_recibos.id " +
                        "LEFT JOIN usuarios_ctacte_det ON usuarios_ctacte_relacion.Id_Usuarios_ctacte_det = usuarios_ctacte_det.Id " +
                        "LEFT JOIN servicios ON usuarios_ctacte_det.Id_Servicios = servicios.id " +
                        "WHERE caja_diaria.Id_Cierre_General = @idGeneral AND usuarios_ctacte_det.borrado = 0 " +
                        "GROUP BY formas_de_pago.id; ");

                }
                oCon.AsignarParametroEntero("@idGeneral", id_cajaGeneral);

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

        public DataTable ListarDiscriminadoPuntos(int idCajaGeneral)
        {
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                oCon.CrearComando("SELECT puntos_cobros.id, descripcion,"
                + " ifnull((SELECT SUM(Importe_cuenta1) FROM caja_diaria WHERE id_puntos_cobros = puntos_cobros.id and caja_diaria.Id_Cierre_General = @general1), 0) as Importe_cuenta1,"
                + " ifnull((SELECT SUM(Importe_cuenta2) FROM caja_diaria WHERE id_puntos_cobros = puntos_cobros.id and caja_diaria.Id_Cierre_General = @general2),0) as Importe_cuenta2, puntos_cobros.orden_caja_general"
                + " FROM puntos_cobros where borrado = 0 order by puntos_cobros.orden_caja_general asc");
                oCon.AsignarParametroEntero("@general1", idCajaGeneral);
                oCon.AsignarParametroEntero("@general2", idCajaGeneral);
                dt = oCon.Tabla();
                oCon.DesConectar();
            }
            catch (Exception c)
            {
                oCon.DesConectar();
            }
            return dt;
        }
    
        public DataTable ListarFormaPago(int idCajaGeneral)
        {
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                oCon.CrearComando("SELECT formas_de_pago.Nombre as forma, SUM(usuarios_ctacte_recibos_det.Importe) as importe from usuarios_ctacte_recibos"
                    + " left join usuarios_ctacte_recibos_det on usuarios_ctacte_recibos_det.Id_Usuarios_Ctacte_Recibos = usuarios_ctacte_recibos.Id"
                    + " left join formas_de_pago on formas_de_pago.id = usuarios_ctacte_recibos_det.Id_Formas_de_Pago"
                    + " left join caja_diaria on caja_diaria.Id_Cierre_General = @caja"
                    + " where usuarios_ctacte_recibos.Id_Caja_Diaria = caja_diaria.Id and usuarios_ctacte_recibos.borrado = 0 and formas_de_pago.Borrado = 0 and caja_diaria.borrado = 0 and usuarios_ctacte_recibos_det.borrado = 0 GROUP BY formas_de_pago.id"
                    + " union"
                    + " select 'GASTOS' as forma, IF(SUM(caja_egresos.Monto) > 0, SUM(caja_egresos.Monto), 0) as importe from caja_egresos"
                    + " left join caja_diaria on caja_diaria.id = caja_egresos.Id_Caja"
                    + " where caja_diaria.Id_Cierre_General = @caja1");
                oCon.AsignarParametroEntero("@caja", idCajaGeneral);
                oCon.AsignarParametroEntero("@caja1", idCajaGeneral);
                dt = oCon.Tabla();
                oCon.DesConectar();
            }
            catch (Exception)
            {
                oCon.DesConectar();
            }
            return dt;
        }
    }

}
