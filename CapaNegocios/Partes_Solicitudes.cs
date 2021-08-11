using CapaDatos;
using System;
using System.Data;

namespace CapaNegocios
{
    public class Partes_Solicitudes
    {
        public Int32 Id { get; set; }
        public Int32 Id_Servicios_Tipos { get; set; }
        public Int32 Id_Partes_Operaciones { get; set; }
        public String Nombre { get; set; }
        public Int32 Aplica_app_externa { get; set; }
        public Int32 ConCargo { get; set; }
        public Int32 Borrado { get; set; }
        public Int32 Id_Iva_Alicuota { get; set; }
        public Int32 Origen { get; set; }
        public Int32 CodTra { get; set; }
        public Int32 Dias_Resolucion { get; set; }

        private Conexion oCon = new Conexion();


        public enum ORIGEN_SOLICITUD
        {
            SISTEMA = 0,
            USUARIO = 1
        }

        public Int32 Guardar(Partes_Solicitudes oPartes_Falla)
        {

            try
            {
                oCon.Conectar();

                if (oPartes_Falla.Id > 0)
                {
                    oCon.CrearComando("UPDATE partes_fallas set Id_Servicios_Tipos = @serv, Id_Partes_Operaciones = @operacion, Nombre = @nombre, Aplica_app_externa = @can,conCargo=@conCargo, Id_Iva_Alicuotas = @iva, origen=@origen ,Dias_Resolucion=@codtrabajo,id_personal=@personal WHERE Id = @id");
                    oCon.AsignarParametroEntero("@id", oPartes_Falla.Id);
                }
                else
                    oCon.CrearComando("INSERT INTO partes_fallas(Id_Servicios_Tipos, Id_Partes_Operaciones, Nombre, Aplica_app_externa,conCargo, Id_Iva_Alicuotas, Origen,Dias_Resolucion,id_personal) VALUES(@serv, @operacion, @nombre, @can,@conCargo, @iva, @origen,@codtrabajo,@personal); SELECT @@IDENTITY");

                oCon.AsignarParametroCadena("@nombre", oPartes_Falla.Nombre);
                oCon.AsignarParametroEntero("@serv", oPartes_Falla.Id_Servicios_Tipos);
                oCon.AsignarParametroEntero("@operacion", oPartes_Falla.Id_Partes_Operaciones);
                oCon.AsignarParametroEntero("@can", oPartes_Falla.Aplica_app_externa);
                oCon.AsignarParametroEntero("@conCargo", oPartes_Falla.ConCargo);
                oCon.AsignarParametroEntero("@iva", oPartes_Falla.Id_Iva_Alicuota);
                oCon.AsignarParametroEntero("@origen", oPartes_Falla.Origen);
                oCon.AsignarParametroEntero("@codtrabajo", oPartes_Falla.Dias_Resolucion);
                oCon.AsignarParametroEntero("@personal",Personal.Id_Login);

                if (oPartes_Falla.Id == 0)
                    oPartes_Falla.Id = oCon.EjecutarScalar();
                else
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

            return oPartes_Falla.Id;
        }

        public DataTable ListarServicioTipo(int id_Servicios_Tipos, int Id_Servicios_Tarifas, int Id_Servicios, string Tipo_Sub, int Id_Tipo_Facturacion)
        {
            DataTable dt = new DataTable();

            try
            {
                oCon.Conectar();
                if (Id_Servicios_Tarifas == 0 || Id_Servicios == 0 || Id_Tipo_Facturacion == 0)
                    oCon.CrearComando("SELECT partes_fallas.id as id, partes_fallas.nombre as Falla, partes_fallas.id_partes_operaciones, (select ParteTrabajo from partes_operaciones where id=id_partes_operaciones) as ParteTrabajo from partes_fallas where id_servicios_tipos =" + id_Servicios_Tipos + " and borrado=0");
                else
                    oCon.CrearComando(String.Format("SELECT partes_fallas.id as id, partes_fallas.nombre as Falla, partes_fallas.id_partes_operaciones,id_servicios_tipos, " +
                        " (select partes_operaciones.partetrabajo from partes_operaciones where partes_operaciones.id = partes_fallas.id_partes_operaciones) as ParteTrabajo," +
                        " if ((select importe from vw_tarifas where vw_tarifas.id_servicios_tarifas = {1} and vw_tarifas.id_servicios = {2} and vw_tarifas.tiposub = '{3}' and vw_tarifas.id_tipo_facturacion = {4} and vw_tarifas.id_servicios_sub = partes_fallas.id) is null,0.00,(select importe from vw_tarifas where vw_tarifas.id_servicios_tarifas = {1} and vw_tarifas.id_servicios = {2} and vw_tarifas.tiposub = '{3}' and vw_tarifas.id_tipo_facturacion = {4} and vw_tarifas.id_servicios_sub = partes_fallas.id)) as importe,partes_fallas.Dias_Resolucion " +
                        "from partes_fallas where partes_fallas.id_servicios_tipos = {0} and partes_fallas.borrado = 0", id_Servicios_Tipos, Id_Servicios_Tarifas, Id_Servicios, Tipo_Sub, Id_Tipo_Facturacion));
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
                oCon.CrearComando("UPDATE partes_fallas SET Borrado = 1,id_personal=@personal WHERE Id = @id");
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

        public DataTable GetDatosServicios(int idServicio, bool conCargos)
        {
            DataTable dt = new DataTable();

            try
            {
                oCon.Conectar();

                if (conCargos)
                    oCon.CrearComando(String.Format("SELECT * FROM partes_fallas " +
                        "WHERE Borrado = 0 AND ConCargo = 1 AND Id_Servicios_Tipos = (SELECT Id_Servicios_Tipos FROM Servicios WHERE Id = {0})", idServicio.ToString()));
                else
                    oCon.CrearComando(String.Format("SELECT * FROM partes_fallas " +
                        "WHERE Borrado = 0 and ConCargo = 0 AND Id_Servicios_Tipos = (SELECT Id_Servicios_Tipos FROM Servicios WHERE Id = {0})", idServicio.ToString()));

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

        public DataTable GetDatosServicios(int idServicio, bool conCargos, int tipoOperaciones)
        {
            DataTable dt = new DataTable();

            try
            {
                oCon.Conectar();

                if (conCargos)
                {
                    if (tipoOperaciones > 0)
                    {
                        oCon.CrearComando(String.Format("SELECT * FROM partes_fallas " +
                            "WHERE borrado=0 and ConCargo = 1 AND Id_Servicios_Tipos = (SELECT Id_Servicios_Tipos FROM Servicios WHERE Id = {0}) AND " +
                            "Id_Partes_Operaciones = {1}", idServicio.ToString(), tipoOperaciones.ToString()));
                    }
                    else
                    {
                        oCon.CrearComando(String.Format("SELECT * FROM partes_fallas " +
                            "WHERE ConCargo = 1 AND Id_Servicios_Tipos = (SELECT Id_Servicios_Tipos FROM Servicios WHERE Id = {0}) AND  " +
                            "Id_Partes_Operaciones = 1", idServicio.ToString()));

                    }
                }
                else if (tipoOperaciones > 0)
                {
                    oCon.CrearComando(String.Format("SELECT * FROM partes_fallas " +
                        "WHERE ConCargo = 0 AND Id_Servicios_Tipos = (SELECT Id_Servicios_Tipos FROM Servicios WHERE Id = {0}) AND " +
                        "Id_Partes_Operaciones = {1}", idServicio.ToString(), tipoOperaciones.ToString()));
                }
                else
                {
                    oCon.CrearComando(String.Format("SELECT * FROM partes_fallas " +
                        "WHERE ConCargo = 0 AND Id_Servicios_Tipos = (SELECT Id_Servicios_Tipos FROM Servicios WHERE Id = {0}) AND  " +
                        "Id_Partes_Operaciones = 1", idServicio.ToString()));

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

        public DataTable Traer_Por_Tipo_Servicio(int id_tipo_servicio)
        {
            DataTable dt = new DataTable();

            try
            {
                oCon.Conectar();
                oCon.CrearComando("SELECT * from partes_fallas where Id_Servicios_Tipos=@id_servicio_tipo");
                oCon.AsignarParametroEntero("@id_servicio_tipo", id_tipo_servicio);
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

        public DataTable GetFallasPorTipoServYOp(int idTipoServicio, int idTipoOperaciones)
        {
            DataTable dt = new DataTable();

            try
            {
                oCon.Conectar();

                oCon.CrearComando(String.Format("SELECT * FROM partes_fallas WHERE Id_Servicios_Tipos = {0} AND Id_Partes_Operaciones = {1}", idTipoServicio.ToString(), idTipoOperaciones.ToString()));

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

        public DataTable Listar()
        {
            DataTable dt = new DataTable();

            try
            {
                oCon.Conectar();
                oCon.CrearComando("SELECT partes_fallas.id, partes_fallas.id_Servicios_tipos, partes_fallas.id_partes_operaciones, partes_fallas.nombre, IF(partes_fallas.Aplica_app_externa = 0, 'NO', 'SI') as app_externa, partes_fallas.Aplica_app_externa, partes_fallas.id_iva_alicuotas, partes_fallas.borrado, partes_fallas.conCargo, IF(conCargo = 1, 'SI', 'NO') AS Cargo,Servicios_Tipos.nombre as ServicioTipo, partes_fallas.origen, partes_fallas.Dias_Resolucion FROM partes_fallas inner join Servicios_Tipos on Servicios_Tipos.Id = partes_fallas.id_servicios_tipos WHERE Servicios_Tipos.borrado = 0 and partes_fallas.borrado = 0 ORDER BY partes_fallas.Nombre");
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

        public DataTable Busca_operacion_basica(int id_tipo_servicio, int id_operacion, string nombre)
        {
            DataTable dt;
            oCon.Conectar();
            oCon.CrearComando("SELECT * FROM partes_fallas where id_Servicios_tipos=@idserviciotipo and id_partes_operaciones=@idoperacion and nombre=@nombre");
            oCon.AsignarParametroEntero("@idserviciotipo", id_tipo_servicio);
            oCon.AsignarParametroEntero("@idoperacion", id_operacion);
            oCon.AsignarParametroCadena("@nombre", nombre);
            dt = oCon.Tabla();
            oCon.DesConectar();
            return dt;
        }

        public DataTable ListarDatosFalla(int idFalla)
        {
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                oCon.CrearComando("SELECT * FROM partes_fallas where id=@idfalla");
                oCon.AsignarParametroEntero("@idfalla", idFalla);
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

        public void Insertar_Operaciones_Basicas()
        {
            Servicios_Tipos oServicios_Tipos = new Servicios_Tipos();
            Partes oPartes = new Partes();
            DataTable dt_tipos_servicios = oServicios_Tipos.Listar();
            DataTable dt_partes_fallas = this.Listar();
            DataTable dt_partes_operaciones = oPartes.ListarOperaciones();

            int id_tipo_servicio, id_operacion;
            string nombre_operacion;

            foreach (DataRow item_tipos_servicios in dt_tipos_servicios.Rows)
            {
                id_tipo_servicio = Convert.ToInt32(item_tipos_servicios["id"]);

                foreach (DataRow item_operaciones in dt_partes_operaciones.Rows)
                {
                    id_operacion = Convert.ToInt32(item_operaciones["id"]);
                    nombre_operacion = item_operaciones["nombre"].ToString();
                    dt_partes_fallas = this.Busca_operacion_basica(id_tipo_servicio, id_operacion, nombre_operacion);

                    if (dt_partes_fallas.Rows.Count == 0)
                    {
                        Partes_Solicitudes oPartes_Solicitudes = new Partes_Solicitudes();
                        oPartes_Solicitudes.Id = 0;
                        oPartes_Solicitudes.Nombre = nombre_operacion;
                        oPartes_Solicitudes.Id_Servicios_Tipos = id_tipo_servicio;
                        oPartes_Solicitudes.Id_Partes_Operaciones = id_operacion;
                        oPartes_Solicitudes.Guardar(oPartes_Solicitudes);
                    }
                }
            }
        }

        public DataTable GetSolicitudesConCargo() 
        {
            DataTable dt = new DataTable();

            try
            {
                oCon.Conectar();
                oCon.CrearComando("SELECT * from partes_fallas where ConCargo = 1 and borrado = 0 group by id_partes_operaciones");
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

        public DataTable GetSolicitudesPorOperacion(Partes.Partes_Operaciones operacion)
        {
            DataTable dt = new DataTable();

            try
            {
                oCon.Conectar();
                oCon.CrearComando(string.Format("SELECT * from partes_fallas where borrado = 0 and partes_fallas.id_partes_operaciones = {0} ", (int)operacion));
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
