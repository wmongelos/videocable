using CapaDatos;
using System;
using System.Data;

namespace CapaNegocios
{
    public class Usuarios_Servicios_Novedades
    {
        public Int32 Id { get; set; }
        public Int32 Id_Usuarios { get; set; }
        public Int32 Id_Usuarios_Locaciones { get; set; }
        public Int32 Id_Servicios { get; set; }
        public Int32 Id_Servicios_Sub { get; set; }
        public Int32 Id_Servicios_velocidades { get; set; }
        public Int32 Id_Servicios_velocidades_tip { get; set; }
        public DateTime Fecha_Desde { get; set; }
        public DateTime Fecha_Hasta { get; set; }
        public Decimal Porcentaje { get; set; }
        public Decimal Monto { get; set; }
        public String Tipo { get; set; }
        public String Detalle { get; set; }
        public Int32 Id_Usuarios_Servicios { get; set; }
        public Int32 Id_Usuarios_Servicios_Sub { get; set; }
        public Int32 Finaliza { get; set; }
        public String Tipo_Busqueda { get; set; }
        public Int32 Id_tipo { get; set; }
        public Int32 Facturable { get; set; }
        public Int32 Imprimir { get; set; }
        public Int32 id_tipo_facturacion { get; set; }
        public Int32 id_bonificacion_asociada { get; set; }
        public Int32 Id_Origen { get; set; }

        private Conexion oCon = new Conexion();
        public enum Origen
        {
            OPERADOR = 1, //MANUAL
            SISTEMA = 2  //AUTOMATICO (PJ:PARTE_CONEXION)
        }
        public enum Imprime
        {
            USUARIO = 1,
            OPERADOR = 2,
            AMBOS = 3
        }

        public enum Novedades_Tipos
        {
            PARTES = 1,
            CUENTA_CORRIENTE = 2,
            OTROS = 3
        }

        public void Guardar(Usuarios_Servicios_Novedades oNovedad)
        {
            try
            {

                oCon.Conectar();
                oCon.ComenzarTransaccion();
                if (oNovedad.Id > 0)
                {
                    oCon.CrearComando("UPDATE usuarios_servicios_novedades SET fecha_desde=@fechaDesde, fecha_hasta=@fechaHasta, finaliza=@finaliza1, detalle=@detalle1, imprime=@imprime1, porcentaje=@porcentaje1, monto=@monto1  WHERE id=@idNovedad and id_tipo_facturacion=@idtipofac");
                    oCon.AsignarParametroEntero("@idNovedad", oNovedad.Id);
                    oCon.AsignarParametroFecha("@fechaDesde", oNovedad.Fecha_Desde);
                    oCon.AsignarParametroFecha("@fechaHasta", oNovedad.Fecha_Hasta);
                    oCon.AsignarParametroCadena("@detalle1", oNovedad.Detalle);
                    oCon.AsignarParametroEntero("@finaliza1", oNovedad.Finaliza);
                    oCon.AsignarParametroEntero("@imprime1", oNovedad.Imprimir);
                    oCon.AsignarParametroDecimal("@porcentaje1", oNovedad.Porcentaje);
                    oCon.AsignarParametroDecimal("@monto1", oNovedad.Monto);
                    oCon.AsignarParametroEntero("@idtipofac", oNovedad.id_tipo_facturacion);


                }
                else
                {
                    oCon.CrearComando("INSERT INTO usuarios_servicios_novedades(Id_Usuarios,Id_Usuarios_Locaciones,Id_Servicios,Id_Servicios_Sub,Id_Servicios_velocidades,Id_Servicios_velocidades_tip,Fecha_Desde,Fecha_Hasta,Porcentaje,Monto,Tipo,Detalle,Id_Usuarios_Servicios,Id_Usuarios_Servicios_Sub,Finaliza,facturable,id_tipo,imprime,id_tipo_facturacion, id_bonificacion_asociada,id_origen) " +
                    "VALUES(@Id_Usuarios1,@Id_Usuarios_Locaciones1,@Id_Servicios1,@Id_Servicios_Sub1,@Id_Servicios_velocidades1,@Id_Servicios_velocidades_tip1,@Fecha_Desde1,@Fecha_Hasta1,@Porcentaje1,@Monto1,@Tipo1,@Detalle1,@Id_Usuarios_Servicios1,@Id_Usuarios_Servicios_Sub1,@Finaliza1,1,0,@imprime1,@idtipofac, @idbonificacionasociada,@idorigen)");
                    oCon.AsignarParametroEntero("@Id_Usuarios1", Id_Usuarios);
                    oCon.AsignarParametroEntero("@Id_Usuarios_Locaciones1", Id_Usuarios_Locaciones);
                    oCon.AsignarParametroEntero("@Id_Servicios1", Id_Servicios);
                    oCon.AsignarParametroEntero("@Id_Servicios_Sub1", Id_Servicios_Sub);
                    oCon.AsignarParametroEntero("@Id_Servicios_velocidades1", Id_Servicios_velocidades);
                    oCon.AsignarParametroEntero("@Id_Servicios_velocidades_tip1", Id_Servicios_velocidades_tip);
                    oCon.AsignarParametroFecha("@Fecha_Desde1", Fecha_Desde);
                    oCon.AsignarParametroFecha("@Fecha_Hasta1", Fecha_Hasta);
                    oCon.AsignarParametroDecimal("@Porcentaje1", Porcentaje);
                    oCon.AsignarParametroDecimal("@Monto1", Monto);
                    oCon.AsignarParametroCadena("@Tipo1", Tipo);
                    oCon.AsignarParametroCadena("@Detalle1", Detalle);
                    oCon.AsignarParametroEntero("@Id_Usuarios_Servicios1", Id_Usuarios_Servicios);
                    oCon.AsignarParametroEntero("@Id_Usuarios_Servicios_Sub1", Id_Usuarios_Servicios_Sub);
                    oCon.AsignarParametroEntero("@Finaliza1", Finaliza);
                    oCon.AsignarParametroEntero("@imprime1", Imprimir);
                    oCon.AsignarParametroEntero("@idtipofac", oNovedad.id_tipo_facturacion);
                    if (String.IsNullOrEmpty(oNovedad.id_bonificacion_asociada.ToString()) || oNovedad.id_bonificacion_asociada.ToString() == "0")
                        oCon.AsignarParametroEntero("@idbonificacionasociada", 0);
                    else
                        oCon.AsignarParametroEntero("@idbonificacionasociada", oNovedad.id_bonificacion_asociada);

                    oCon.AsignarParametroEntero("@idorigen", oNovedad.Id_Origen);
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
                oCon.CrearComando("UPDATE usuarios_servicios_novedades SET Borrado = 1 WHERE Id = @id");
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
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();

                String Condicion = "select usuarios_servicios_novedades.id as ids,usuarios_servicios_novedades.id_servicios,usuarios_servicios_novedades.id_usuarios,usuarios_servicios_novedades.id_tipo_facturacion,"
                    + "if((isnull(servicios.descripcion)=1),'TODOS',servicios.descripcion)as servicio_nombre,CONCAT (usuarios.apellido,', ',usuarios.nombre) AS usuario,usuarios_servicios_novedades.id_usuarios_locaciones,"
                    + " IF((ISNULL(CONCAT('CALLE: ', usuarios_locaciones.calle,' NRO: ', cast(usuarios_locaciones.altura as char), ' PISO: ', cast(usuarios_locaciones.piso as char), ' DEPTO: ', usuarios_locaciones.depto, ', ', localidades.nombre)) = 1), 'GENERAL', CONCAT('CALLE: ', usuarios_locaciones.calle, ' NRO: ', cast(usuarios_locaciones.altura as char), ' PISO: ', cast(usuarios_locaciones.piso as char), ' DEPTO: ', usuarios_locaciones.depto, ', ' , localidades.nombre)) as locacion,usuarios_locaciones.id_localidades,"
                    + " IF((ISNULL(servicios_sub.descripcion) = 1), 'TODOS', servicios_sub.descripcion) as Sub_Servicio_Nombre,"
                    + " servicios_velocidades.velocidad,servicios_velocidades_tip.nombre as velocidad_t,"
                    + " fecha_desde,fecha_hasta,porcentaje,monto,usuarios_servicios_novedades.id_usuarios_servicios_sub,usuarios_servicios_novedades.id_usuarios_servicios, "
                    + " usuarios_servicios_novedades.finaliza,usuarios_servicios_novedades.id_servicios_sub,usuarios_servicios_novedades.detalle, usuarios_servicios_novedades.id_usuarios, usuarios_servicios_novedades.id_servicios_velocidades, usuarios_servicios_novedades.id_servicios_velocidades_tip, usuarios_servicios_novedades.tipo,usuarios_servicios_novedades.imprime as idimprime,IF(usuarios_servicios_novedades.imprime=1,'USUARIO','OPERADOR')AS imprime, usuarios_servicios_novedades.id_bonificacion_asociada,usuarios_servicios_novedades.id_origen"
                    + " from usuarios_servicios_novedades"
                    + " left join servicios on servicios.id = usuarios_servicios_novedades.id_servicios"
                    + " left join servicios_sub on servicios_sub.id = usuarios_servicios_novedades.id_servicios_sub"
                    + " left join servicios_velocidades on servicios_velocidades.id = usuarios_servicios_novedades.id_servicios_velocidades"
                    + " left join servicios_velocidades_tip on servicios_velocidades_tip.id = usuarios_servicios_novedades.id_servicios_velocidades_tip"
                    + " left join usuarios on usuarios.id = usuarios_servicios_novedades.id_usuarios"
                    + " left join usuarios_locaciones on usuarios_locaciones.id = usuarios_servicios_novedades.id_usuarios_locaciones"
                    + " left join localidades on localidades.id = usuarios_locaciones.id_localidades ";

                switch (Tipo_Busqueda)
                {
                    case "I":    // Por id
                        oCon.CrearComando(Condicion + "WHERE usuarios_servicios_novedades.id = @id and usuarios_servicios_novedades.borrado=0 and usuarios_servicios_novedades.facturable=1 ");
                        oCon.AsignarParametroEntero("@id", Id);
                        break;
                    case "S"://Por servicio
                        oCon.CrearComando(Condicion + "WHERE usuarios_servicios_novedades.id_servicios = @id and usuarios_servicios_novedades.borrado=0 and usuarios_servicios_novedades.facturable=1 and usuarios_servicios_novedades.id_tipo_facturacion=@idTipoFac and usuarios_servicios_novedades.id_usuarios=0");
                        oCon.AsignarParametroEntero("@id", Id_Servicios);
                        oCon.AsignarParametroEntero("@idTipoFac", id_tipo_facturacion);
                        break;
                    case "SSUB"://Por servicio
                        oCon.CrearComando(Condicion + "WHERE usuarios_servicios_novedades.id_servicios_sub = @id and usuarios_servicios_novedades.borrado=0 and usuarios_servicios_novedades.facturable=1 and usuarios_servicios_novedades.id_tipo_facturacion=@idTipoFac and usuarios_servicios_novedades.id_usuarios=0");
                        oCon.AsignarParametroEntero("@id", Id_Servicios_Sub);
                        oCon.AsignarParametroEntero("@idTipoFac", id_tipo_facturacion);
                        break;
                    case "U":    // Por usuario
                        oCon.CrearComando(Condicion + "WHERE usuarios_servicios_novedades.id_usuarios = @id and usuarios_servicios_novedades.borrado=0 and usuarios_servicios_novedades.facturable=1 ");
                        oCon.AsignarParametroEntero("@id", Id_Usuarios);
                        break;
                    case "L":    // Por Locacion
                        oCon.CrearComando(Condicion + "WHERE usuarios_servicios_novedades.id_usuarios_Locaciones = @id and usuarios_servicios_novedades.borrado=0 and usuarios_servicios_novedades.facturable=1 ");
                        oCon.AsignarParametroEntero("@id", Id_Usuarios_Locaciones);
                        break;
                    case "US"://Por usuarioservicio
                        oCon.CrearComando(Condicion + "WHERE usuarios_servicios_novedades.id_usuarios_servicios = @id and usuarios_servicios_novedades.borrado=0 and usuarios_servicios_novedades.facturable=1");
                        oCon.AsignarParametroEntero("@id", Id_Usuarios_Servicios);
                        break;
                    case "USSUB"://Por usuarioserviciosub
                        oCon.CrearComando(Condicion + "WHERE usuarios_servicios_novedades.id_usuarios_servicios_sub = @id and usuarios_servicios_novedades.borrado=0 and usuarios_servicios_novedades.facturable=1");
                        oCon.AsignarParametroEntero("@id", Id_Usuarios_Servicios_Sub);
                        break;
                    case "T"://todo:
                        oCon.CrearComando(Condicion + "WHERE usuarios_servicios_novedades.borrado=0 and usuarios_servicios_novedades.facturable=1");
                        break;
                    default:
                        break;


                }

                dt = oCon.Tabla();
                oCon.DesConectar();
                return dt;
            }
            catch (Exception)
            {
                oCon.DesConectar();
                throw;
            }
        }
        public DataTable ListarTipos()
        {
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                oCon.CrearComando("SELECT id,descripcion FROM novedades_tipos");
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
        public DataTable ListarObservaciones(int idUsuario)
        {
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                oCon.CrearComando("SELECT usuarios_servicios_novedades.id,usuarios_servicios_novedades.detalle,usuarios_servicios_novedades.id_tipo,usuarios_servicios_novedades.fecha_desde,usuarios_servicios_novedades.fecha_hasta, novedades_tipos.descripcion,(CASE WHEN (imprime=1)THEN 'USUARIO' WHEN (imprime=2) THEN 'OPERADOR' WHEN (imprime=3) THEN 'AMBOS' END) AS imprimir,usuarios_servicios_novedades.id_usuarios_locaciones,"
                + " IF(usuarios_servicios_novedades.id_usuarios_locaciones = 0, 'GENERAL', CONCAT(usuarios_locaciones.Calle,CAST(usuarios_locaciones.Altura AS char(10)),' PISO: ', usuarios_locaciones.Piso, ' DEPTO: ', usuarios_locaciones.Depto, ', ', localidades.nombre)) as locacion, usuarios_servicios_novedades.id_servicios,if (usuarios_servicios_novedades.id_servicios=0,'GENERAL',servicios.descripcion) AS servicio"
                + " FROM usuarios_servicios_novedades"
                + " left join novedades_tipos on novedades_tipos.id = usuarios_servicios_novedades.id_tipo"
                + " left join usuarios_locaciones on usuarios_locaciones.id = usuarios_servicios_novedades.id_usuarios_locaciones"
                + " left join localidades on localidades.id = usuarios_locaciones.id_localidades"
                + " left join servicios on servicios.id=usuarios_servicios_novedades.id_Servicios"
                + " WHERE usuarios_servicios_novedades.id_usuarios = @id and usuarios_servicios_novedades.facturable = 0 and usuarios_servicios_novedades.borrado = 0");
                oCon.AsignarParametroEntero("@id", idUsuario);
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
        public void GuardarObsUsuario(Usuarios_Servicios_Novedades oNov)
        {
            try
            {
                oCon.Conectar();
                if (oNov.Id > 0)
                {
                    oCon.CrearComando("UPDATE usuarios_servicios_novedades SET id_usuarios=@IdUsuarios,Fecha_Desde=@FechaDesde,Fecha_Hasta=@FechaHasta,Detalle=@Detalle,facturable=1,id_tipo=@idtipo,imprime=@imprime1,id_usuarios_locaciones=@idlocacion " +
                        "WHERE id=@id1");
                    oCon.AsignarParametroEntero("@id1", oNov.Id);

                }
                else
                {
                    oCon.CrearComando("INSERT INTO usuarios_servicios_novedades (Id_Usuarios,Fecha_Desde,Fecha_Hasta,Detalle,facturable,id_tipo,imprime,id_usuarios_locaciones,id_servicios)" +
                        "VALUES(@IdUsuarios,@FechaDesde,@FechaHasta,@Detalle,0,@idtipo,@imprime1,@idlocacion,@idservicio)");
                }

                oCon.AsignarParametroEntero("@IdUsuarios", oNov.Id_Usuarios);
                oCon.AsignarParametroFecha("@FechaDesde", oNov.Fecha_Desde);
                oCon.AsignarParametroFecha("@FechaHasta", oNov.Fecha_Hasta);
                oCon.AsignarParametroCadena("@Detalle", oNov.Detalle);
                oCon.AsignarParametroEntero("@idtipo", oNov.Id_tipo);
                oCon.AsignarParametroEntero("@imprime1", oNov.Imprimir);
                oCon.AsignarParametroEntero("@idlocacion", oNov.Id_Usuarios_Locaciones);
                oCon.AsignarParametroEntero("@idservicio", oNov.Id_Servicios);


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
        public Boolean HayObservaciones(int idUsuario)
        {
            DataTable dt;
            DateTime hoy = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            try
            {

                oCon.Conectar();
                oCon.CrearComando("SELECT id FROM usuarios_servicios_novedades where fecha_hasta>=@fecha and usuarios_servicios_novedades.facturable = 0 and usuarios_servicios_novedades.id_usuarios=@usuario and borrado=0");
                oCon.AsignarParametroFecha("@fecha", hoy);
                oCon.AsignarParametroEntero("@usuario", idUsuario);
                dt = oCon.Tabla();
                oCon.DesConectar();
            }
            catch (Exception)
            {
                oCon.DesConectar();
                throw;
            }

            if (dt.Rows.Count > 0)
                return true;
            else
                return false;

        }
        public Boolean HayNovedades(int idUsuario)
        {
            DataTable dt;
            DateTime hoy = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            try
            {

                oCon.Conectar();
                oCon.CrearComando("SELECT id FROM usuarios_servicios_novedades where fecha_hasta>=@fecha and usuarios_servicios_novedades.facturable = 1 and usuarios_servicios_novedades.id_usuarios=@usuario and borrado=0");
                oCon.AsignarParametroFecha("@fecha", hoy);
                oCon.AsignarParametroEntero("@usuario", idUsuario);
                dt = oCon.Tabla();
                oCon.DesConectar();
            }
            catch (Exception)
            {
                oCon.DesConectar();
                throw;
            }

            if (dt.Rows.Count > 0)
                return true;
            else
                return false;

        }
        public void ELiminar(int id)
        {
            try
            {
                oCon.Conectar();
                oCon.CrearComando("UPDATE usuarios_servicios_novedades SET borrado=1 WHERE id=@id");
                oCon.AsignarParametroEntero("@id", id);
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
    }
}
