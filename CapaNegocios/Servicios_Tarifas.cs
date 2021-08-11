using CapaDatos;
using System;
using System.Data;

namespace CapaNegocios
{
    public class Servicios_Tarifas
    {
        public Int32 Id { get; set; }
        public String Nombre { get; set; }
        public DateTime Fecha_Desde { get; set; }
        public DateTime Fecha_Hasta { get; set; }
        public DateTime Fecha_Actual { get; set; }
        private int id_nueva_tarifa, id_antigua_tarifa;
        private DataTable dt_nueva_tarifa = new DataTable();
        private DateTime Nueva_Fecha_Desde, Nueva_Fecha_Hasta;
        public static Int32 Tarifa_Vigente;

        private Conexion oCon = new Conexion();

        public void Guardar(Servicios_Tarifas oTarifa, int id_personal)
        {
            try
            {
                oCon.Conectar();

                if (oTarifa.Id > 0)
                {
                    oCon.CrearComando("UPDATE servicios_tarifas SET Nombre = @nombre, Fecha_Desde = @desde, Fecha_Hasta = @hasta, Id_Personal = @personal WHERE Id = @id");
                    oCon.AsignarParametroEntero("@id", oTarifa.Id);
                }
                else
                {
                    oCon.CrearComando("INSERT INTO servicios_tarifas(Nombre, Fecha_Desde, Fecha_Hasta, Id_Personal) VALUES(@nombre, @desde, @hasta, @personal)");
                }

                oCon.AsignarParametroCadena("@nombre", oTarifa.Nombre);
                oCon.AsignarParametroFecha("@desde", oTarifa.Fecha_Desde.Date);
                oCon.AsignarParametroFecha("@hasta", oTarifa.Fecha_Hasta.Date);
                oCon.AsignarParametroEntero("@personal", Personal.Id_Login);

                oCon.ComenzarTransaccion();
                oCon.EjecutarComando();
                oCon.ConfirmarTransaccion();
                oCon.DesConectar();
                if (oTarifa.Id == 0)//maxi 27/09/2019
                    ActualizarTarifas();
                oCon.Conectar();
                if (oTarifa.Id > 0)
                {
                    oCon.CrearComando("UPDATE servicios_tarifas_sub SET  Fecha_Desde = @desde, Fecha_Hasta = @hasta WHERE Id_servicios_tarifas = @id");
                    oCon.AsignarParametroEntero("@id", oTarifa.Id);
                    oCon.AsignarParametroFecha("@desde", oTarifa.Fecha_Desde.Date);
                    oCon.AsignarParametroFecha("@hasta", oTarifa.Fecha_Hasta.Date);
                    oCon.ComenzarTransaccion();
                    oCon.EjecutarComando();
                    oCon.ConfirmarTransaccion();

                    oCon.CrearComando("UPDATE servicios_tarifas_sub_esp SET  Fecha_Desde = @desde, Fecha_Hasta = @hasta WHERE Id_servicios_tarifas = @id");
                    oCon.AsignarParametroEntero("@id", oTarifa.Id);
                    oCon.AsignarParametroFecha("@desde", oTarifa.Fecha_Desde.Date);
                    oCon.AsignarParametroFecha("@hasta", oTarifa.Fecha_Hasta.Date);
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
            }

        }

        private bool ActualizarTarifas()
        {
            DataTable dtResul = new DataTable();
            //********************** VERIFICO QUE NO SEA LA PRIMER TARIFA (EN CASO QUE SEA LA PRIMER O UNICA TARIFA NO DEBE REPLICAR NADA
            try
            {
                oCon.Conectar();
                oCon.CrearComando("SELECT ID FROM servicios_tarifas where borrado=0");
                dtResul = oCon.Tabla();
                oCon.DesConectar();
            }
            catch (Exception)
            {
                oCon.DesConectar();
                throw;
            }
            if (dtResul.Rows.Count > 1)
            {

                //*********************obtengo los ultimos dos id tarifas y las nuevas fechas
                try
                {
                    oCon.Conectar();
                    oCon.CrearComando("SELECT id,Fecha_Desde,Fecha_Hasta FROM servicios_tarifas WHERE borrado=0 order by id desc LIMIT 2");
                    dt_nueva_tarifa = oCon.Tabla();
                    oCon.DesConectar();

                    id_nueva_tarifa = Convert.ToInt32(dt_nueva_tarifa.Rows[0]["id"]);
                    id_antigua_tarifa = Convert.ToInt32(dt_nueva_tarifa.Rows[1]["id"]);
                    Nueva_Fecha_Desde = Convert.ToDateTime(dt_nueva_tarifa.Rows[0]["Fecha_Desde"]);
                    Nueva_Fecha_Hasta = Convert.ToDateTime(dt_nueva_tarifa.Rows[0]["Fecha_Hasta"]);
                }
                catch (Exception)
                {
                    oCon.DesConectar();
                    return false;
                }
                try
                {
                    oCon.Conectar();
                    oCon.CrearComando("DROP TABLE IF EXISTS temp;"
                    + " CREATE TEMPORARY TABLE temp(Id int, Id_Servicios_Tarifas int, Id_Servicios int, Id_Tipo_Facturacion  int, Id_Tabla_Tipo int, Tipo varchar(1), Importe numeric(10, 2), Fecha_Desde date, Fecha_Hasta date,idPersonalCreado int ,fecha_creado date, idPersonalMod int , fecha_modif date,id_personal int);"
                    + " INSERT INTO temp SELECT Id,Id_Servicios_Tarifas,Id_Servicios,Id_Tipo_Facturacion ,Id_Tabla_Tipo,Tipo,Importe,Fecha_Desde,Fecha_Hasta,id_personal_create,fecha_create,id_personal_update,fecha_update,id_personal FROM servicios_tarifas_sub WHERE Id_servicios_Tarifas = @antiguo_id;"
                    + " UPDATE temp SET Id_Servicios_Tarifas = @nuevo_id, Fecha_desde = @fecha_desde, Fecha_Hasta = @fecha_hasta WHERE Id_Servicios_Tarifas = @antiguo_id;"
                    + " INSERT INTO servicios_tarifas_sub SELECT Id = Null, Id_Servicios_Tarifas,Id_Servicios,Id_Tipo_Facturacion ,Id_Tabla_Tipo,Tipo,Importe,Fecha_Desde,Fecha_Hasta,1,'2021-01-01 00:00',1,'2021-01-01 00:00',id_personal FROM temp;"
                    + " DROP TABLE temp;"
                    + " drop table if exists temp_servicios_tarifas_sub_esp;"
                    + " CREATE  TABLE temp_servicios_tarifas_sub_esp(Id int(11) NOT NULL, Id_Servicios_Tarifas int(11) NOT NULL DEFAULT '0', Id_Servicios int(11) NOT NULL DEFAULT '0', Id_Servicios_Sub int(11) NOT NULL DEFAULT '0', Id_Servicios_Base int(11) NOT NULL DEFAULT '0', Id_Tipo_Facturacion int(11) NOT NULL DEFAULT '0',Id_Servicios_Velocidad int(11) DEFAULT '0',Id_Servicios_Velocidad_Tip int(11) DEFAULT '0', Dias_Desde int(11) NOT NULL DEFAULT '0', Dias_Hasta int(11) NOT NULL DEFAULT '0', Porcentaje decimal(10, 2) NOT NULL DEFAULT '0.00', Mes_Facturacion int(11) NOT NULL DEFAULT '0', Meses_Servicio int(11) NOT NULL DEFAULT '0', Meses_Cobro int(11) NOT NULL DEFAULT '0', Mes_Inicio int(11) NOT NULL DEFAULT '0', Mes_Fin int(11) NOT NULL DEFAULT '0',Fecha_Desde date, Fecha_Hasta date, Importe decimal(10, 2) NOT NULL DEFAULT '0.00',idPersonalCreado int ,fecha_creado date, idPersonalMod int , fecha_modif date,id_personal int);"
                    + " INSERT INTO temp_servicios_tarifas_sub_esp SELECT Id,Id_Servicios_Tarifas,Id_Servicios,Id_Servicios_Sub,Id_Servicios_Base,Id_Tipo_Facturacion,Id_Servicios_Velocidad,Id_Servicios_Velocidad_Tip,Dias_Desde,Dias_Hasta,Porcentaje,Mes_Facturacion,Meses_Servicio,Meses_Cobro,Mes_Inicio,Mes_Fin,Fecha_Desde, Fecha_Hasta ,Importe ,1,'2021-01-01 00:00',1,'2021-01-01 00:00',id_personal FROM servicios_tarifas_sub_esp where Id_Servicios_Tarifas = @antiguo_id;"
                    + " UPDATE temp_servicios_tarifas_sub_esp SET Id_Servicios_Tarifas = @nuevo_id WHERE Id_Servicios_Tarifas = @antiguo_id;"
                    + " INSERT INTO servicios_tarifas_sub_esp SELECT id = null,Id_Servicios_Tarifas,Id_Servicios,Id_Servicios_Sub,Id_Servicios_Base,Id_Tipo_Facturacion,Id_Servicios_Velocidad,Id_Servicios_Velocidad_Tip,Dias_Desde,Dias_Hasta,Porcentaje,Mes_Facturacion,Meses_Servicio,Meses_Cobro,Mes_Inicio,Mes_Fin,Fecha_Desde,Fecha_Hasta,Importe,1,'2021-01-01 00:00',1,'2021-01-01 00:00',id_personal FROM temp_servicios_tarifas_sub_esp;"
                    + " drop table temp_servicios_tarifas_sub_esp;");
                    oCon.AsignarParametroEntero("@antiguo_id", id_antigua_tarifa);
                    oCon.AsignarParametroEntero("@nuevo_id", id_nueva_tarifa);
                    oCon.AsignarParametroFecha("@fecha_desde", Nueva_Fecha_Desde);
                    oCon.AsignarParametroFecha("@fecha_hasta", Nueva_Fecha_Hasta);
                    oCon.AsignarParametroEntero("@antiguo_id", id_antigua_tarifa);

                    oCon.AsignarParametroEntero("@antiguo_id", id_antigua_tarifa);
                    oCon.AsignarParametroEntero("@nuevo_id", id_nueva_tarifa);
                    oCon.AsignarParametroEntero("@antiguo_id", id_antigua_tarifa);
                    oCon.ComenzarTransaccion();
                    oCon.EjecutarComando();
                    oCon.ConfirmarTransaccion();
                    oCon.DesConectar();
                    return true;
                }
                catch (Exception c)
                {
                    oCon.CancelarTransaccion();
                    oCon.DesConectar();
                    return false;
                }
            }
            else
                return true;
        }

        public DataTable Listar()
        {
            DataTable dt = new DataTable();

            try
            {
                oCon.Conectar();
                oCon.CrearComando("SELECT * FROM servicios_tarifas WHERE Borrado = 0 ORDER BY fecha_desde desc ");
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

        public void Eliminar(int id)
        {
            try
            {
                oCon.Conectar();
                oCon.ComenzarTransaccion();
                oCon.CrearComando("UPDATE servicios_tarifas SET Borrado = 1 WHERE Id = @id");
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

        public int getTarifaId()
        {
            DataTable dt = new DataTable();
            int id;
            try
            {
                oCon.Conectar();
                oCon.CrearComando("SELECT * FROM servicios_tarifas WHERE DATE(NOW()) BETWEEN Fecha_Desde AND Fecha_Hasta and borrado=0");
                dt = oCon.Tabla();
                oCon.DesConectar();
            }
            catch (Exception)
            {
                oCon.DesConectar();
                throw;
            }

            id = dt.Rows.Count == 0 ? 0 : Convert.ToInt32(dt.Rows[0]["Id"]);
            return id;
        }

        public int getTarifa()
        {
            DataTable dt = new DataTable();
            int id;
            try
            {
                oCon.Conectar();
                oCon.CrearComando("SELECT * FROM servicios_tarifas WHERE date(@fecha_actual) BETWEEN Fecha_Desde AND Fecha_Hasta and borrado=0");
                oCon.AsignarParametroFecha("@fecha_actual", Fecha_Actual);
                dt = oCon.Tabla();
                oCon.DesConectar();
            }
            catch (Exception)
            {
                oCon.DesConectar();
                throw;
            }

            id = dt.Rows.Count == 0 ? 0 : Convert.ToInt32(dt.Rows[0]["Id"]);
            return id;
        }

        public DataTable TraerDatosTarifaActual()
        {
            DataTable dt = new DataTable();

            try
            {
                oCon.Conectar();
                oCon.CrearComando("SELECT * FROM servicios_tarifas WHERE DATE(NOW()) BETWEEN Fecha_Desde AND Fecha_Hasta and borrado=0");
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

        public DataTable TraerDatosTarifa(int idTarifa)
        {
            DataTable dt = new DataTable();

            try
            {
                oCon.Conectar();
                oCon.CrearComando("SELECT * FROM servicios_tarifas WHERE  id=@id1 and borrado=0");
                oCon.AsignarParametroEntero("@id1", idTarifa);
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

        public DataTable TraerServiciosPorTarifa(int id_tarifa)
        {
            DataTable dt = new DataTable();

            try
            {
                oCon.Conectar();
                oCon.CrearComando("SELECT *,sum(importe) as total_importe from vw_tarifas where id=@id_tarifa group by id_servicios ");
                oCon.AsignarParametroEntero("@id_tarifa", id_tarifa);
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

        public Boolean tarifaEsVigente(int idTarifa)
        {
            DataTable dt = new DataTable();
            try
            {
                oCon.CrearComando("SELECT id FROM servicios_tarifas WHERE fecha_desde<=date(@fechadesde) and fecha_hasta>=date(@fechahasta) and id=@idtarifa");
                oCon.AsignarParametroFecha("@fechadesde", DateTime.Now);
                oCon.AsignarParametroFecha("@fechahasta", DateTime.Now);
                oCon.AsignarParametroEntero("@idtarifa", idTarifa);
                dt = oCon.Tabla();
            }
            catch (Exception)
            {

                throw;
            }
            if (dt.Rows.Count == 0)
                return false;
            else
                return true;
        }
    }
}
