using CapaDatos;
using System;
using System.Data;

namespace CapaNegocios
{
    public class Bonificaciones_Aplicacion
    {
        public Int32 Id { get; set; }
        public Int32 Id_Grupo { get; set; }
        public Int32 Id_Tipo_Servicio { get; set; }
        public Int32 Id_Servicio { get; set; }
        public Int32 Id_Servicio_Sub { get; set; }
        public Int32 Id_Velocidad { get; set; }
        public Int32 Id_Velocidad_Tipo { get; set; }
        public Decimal Porcentaje { get; set; }
        public Int32 Borrado { get; set; }
        public String Tipo_Servicio_Sub { get; set; }
        public Int32 Id_Tipo_Facturacion { get; set; }
        public DateTime Fecha_Desde { get; set; }
        public DateTime Fecha_Hasta { get; set; }
        public String Nombre { get; set; }
        public Int32 Nivel { get; set; }
        public Int32 Id_Bonificacion { get; set; }
        public Int32 Tipo_Bonificacion { get; set; }
        public Int32 Requiere_Condiciones { get; set; }
        public Int32 Cantidad_Periodos { get; set; }
        public Int32 Mes_Desde { get; set; }
        public Int32 Mes_Hasta { get; set; }
        public Int32 Por_Contratacion { get; set; }
        public Int32 Contemplar_Fecha_Completa { get; set; }
        public Int32 Id_Localidad { get; set; }

        public enum NIVEL
        {
            GRUPO = 0,
            TIPO_SERVICIO = 1,
            SERVICIO = 2,
            SUBSERVICIO = 3
        }

        public enum SELECCION
        {
            GRUPO = 0,
            TIPO_SERVICIO = 1,
            SERVICIO = 2,
            SUBSERVICIO = 3,
            TODOS = 4,
            SERVICIOS_Y_SUBSERVICIOS = 5,
            GRUPOS_TIPOS_SERVICIOS = 6
        }

        public enum REQUIERE_CONDICIONES
        {
            NO_REQUIERE = 0,
            REQUIERE = 1
        }

        private Conexion oCon = new Conexion();

        public void Guardar(Bonificaciones_Aplicacion oBonificacionAplicacion)
        {
            try
            {
                oCon.Conectar();

                if (oBonificacionAplicacion.Id > 0)
                {
                    oCon.CrearComando("UPDATE bonificaciones_aplicacion set id_grupo=@id_grupo, id_tipo_servicio=@id_tipo_servicio, id_servicio=@id_servicio, id_servicio_sub=@id_servicio_sub, id_velocidad=@id_velocidad, id_velocidad_tipo=@id_velocidad_tipo, porcentaje=@porcentaje, tipo_servicio_sub=@tipo_servicio_sub, id_tipo_facturacion=@id_tipo_facturacion, fecha_desde=@fecha_desde, fecha_hasta=@fecha_hasta, nombre=@nombre, nivel=@nivel, id_bonificacion=@id_bonificacion, requiere_condiciones=@requiere_condiciones, cantidad_periodos=@cantidad_periodos, mes_desde=@mes_desde, mes_hasta=@mes_hasta, por_contratacion=@por_contratacion, contemplar_fecha_completa=@contemplar_fecha_completa, id_localidad=@id_localidad,id_personal=@personal WHERE Id = @id");
                    oCon.AsignarParametroEntero("@id_grupo", oBonificacionAplicacion.Id_Grupo);
                    oCon.AsignarParametroEntero("@id_tipo_servicio", oBonificacionAplicacion.Id_Tipo_Servicio);
                    oCon.AsignarParametroEntero("@id_servicio", oBonificacionAplicacion.Id_Servicio);
                    oCon.AsignarParametroEntero("@id_servicio_sub", oBonificacionAplicacion.Id_Servicio_Sub);
                    oCon.AsignarParametroEntero("@id_velocidad", oBonificacionAplicacion.Id_Velocidad);
                    oCon.AsignarParametroEntero("@id_velocidad_tipo", oBonificacionAplicacion.Id_Velocidad_Tipo);
                    oCon.AsignarParametroDecimal("@porcentaje", oBonificacionAplicacion.Porcentaje);
                    oCon.AsignarParametroCadena("@tipo_servicio_sub", oBonificacionAplicacion.Tipo_Servicio_Sub);
                    oCon.AsignarParametroEntero("@id_tipo_facturacion", oBonificacionAplicacion.Id_Tipo_Facturacion);
                    oCon.AsignarParametroEntero("@id_grupo", oBonificacionAplicacion.Id_Grupo);
                    oCon.AsignarParametroFecha("@fecha_desde", oBonificacionAplicacion.Fecha_Desde);
                    oCon.AsignarParametroFecha("@fecha_hasta", oBonificacionAplicacion.Fecha_Hasta);
                    oCon.AsignarParametroCadena("@nombre", oBonificacionAplicacion.Nombre);
                    oCon.AsignarParametroEntero("@nivel", oBonificacionAplicacion.Nivel);
                    oCon.AsignarParametroEntero("@id_bonificacion", oBonificacionAplicacion.Id_Bonificacion);
                    oCon.AsignarParametroEntero("@requiere_condiciones", oBonificacionAplicacion.Requiere_Condiciones);
                    oCon.AsignarParametroEntero("@cantidad_periodos", oBonificacionAplicacion.Cantidad_Periodos);
                    oCon.AsignarParametroEntero("@mes_desde", oBonificacionAplicacion.Mes_Desde);
                    oCon.AsignarParametroEntero("@mes_hasta", oBonificacionAplicacion.Mes_Hasta);
                    oCon.AsignarParametroEntero("@por_contratacion", oBonificacionAplicacion.Por_Contratacion);
                    oCon.AsignarParametroEntero("@contemplar_fecha_completa", oBonificacionAplicacion.Contemplar_Fecha_Completa);
                    oCon.AsignarParametroEntero("@id_localidad", oBonificacionAplicacion.Id_Localidad);
                    oCon.AsignarParametroEntero("@personal", Personal.Id_Login);
                    oCon.AsignarParametroEntero("@id", oBonificacionAplicacion.Id);
                }
                else
                {
                    oCon.CrearComando("INSERT INTO bonificaciones_aplicacion(id_grupo, id_tipo_servicio, id_servicio, id_servicio_sub, id_velocidad, id_velocidad_tipo, porcentaje, tipo_servicio_sub, id_tipo_facturacion, fecha_desde, fecha_hasta, nombre, nivel, id_bonificacion, tipo_bonificacion, requiere_condiciones, cantidad_periodos, mes_desde, mes_hasta, por_contratacion, contemplar_fecha_completa, id_localidad,id_personal) values(@id_grupo, @id_tipo_servicio, @id_servicio, @id_servicio_sub, @id_velocidad, @id_velocidad_tipo, @porcentaje, @tipo_servicio_sub, @id_tipo_facturacion, @fecha_desde, @fecha_hasta, @nombre, @nivel, @id_bonificacion, @tipo_bonificacion, @requiere_condiciones, @cantidad_periodos, @mes_desde, @mes_hasta, @por_contratacion, @contemplar_fecha_completa, @id_localidad,@personal)");
                    oCon.AsignarParametroEntero("@id_grupo", oBonificacionAplicacion.Id_Grupo);
                    oCon.AsignarParametroEntero("@id_tipo_servicio", oBonificacionAplicacion.Id_Tipo_Servicio);
                    oCon.AsignarParametroEntero("@id_servicio", oBonificacionAplicacion.Id_Servicio);
                    oCon.AsignarParametroEntero("@id_servicio_sub", oBonificacionAplicacion.Id_Servicio_Sub);
                    oCon.AsignarParametroEntero("@id_velocidad", oBonificacionAplicacion.Id_Velocidad);
                    oCon.AsignarParametroEntero("@id_velocidad_tipo", oBonificacionAplicacion.Id_Velocidad_Tipo);
                    oCon.AsignarParametroDecimal("@porcentaje", oBonificacionAplicacion.Porcentaje);
                    oCon.AsignarParametroCadena("@tipo_servicio_sub", oBonificacionAplicacion.Tipo_Servicio_Sub);
                    oCon.AsignarParametroEntero("@id_tipo_facturacion", oBonificacionAplicacion.Id_Tipo_Facturacion);
                    oCon.AsignarParametroFecha("@fecha_desde", oBonificacionAplicacion.Fecha_Desde);
                    oCon.AsignarParametroFecha("@fecha_hasta", oBonificacionAplicacion.Fecha_Hasta);
                    oCon.AsignarParametroCadena("@nombre", oBonificacionAplicacion.Nombre);
                    oCon.AsignarParametroEntero("@nivel", oBonificacionAplicacion.Nivel);
                    oCon.AsignarParametroEntero("@id_bonificacion", oBonificacionAplicacion.Id_Bonificacion);
                    oCon.AsignarParametroEntero("@tipo_bonificacion", oBonificacionAplicacion.Tipo_Bonificacion);
                    oCon.AsignarParametroEntero("@requiere_condiciones", oBonificacionAplicacion.Requiere_Condiciones);
                    oCon.AsignarParametroEntero("@cantidad_periodos", oBonificacionAplicacion.Cantidad_Periodos);
                    oCon.AsignarParametroEntero("@mes_desde", oBonificacionAplicacion.Mes_Desde);
                    oCon.AsignarParametroEntero("@mes_hasta", oBonificacionAplicacion.Mes_Hasta);
                    oCon.AsignarParametroEntero("@por_contratacion", oBonificacionAplicacion.Por_Contratacion);
                    oCon.AsignarParametroEntero("@contemplar_fecha_completa", oBonificacionAplicacion.Contemplar_Fecha_Completa);
                    oCon.AsignarParametroEntero("@id_localidad", oBonificacionAplicacion.Id_Localidad);
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
                oCon.CrearComando("UPDATE bonificaciones_aplicacion SET Borrado = 1,id_personal=@personal WHERE Id = @id");
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

        public void EliminarCondiciones(int id)
        {
            try
            {
                oCon.Conectar();
                oCon.ComenzarTransaccion();
                oCon.CrearComando("UPDATE bonificaciones_aplicacion_condiciones SET Borrado = 1,id_personal=@personal WHERE id_bonificacion_aplicacion= @id");
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

        public DataTable Listar(int TipoFacturacionConfiguracion, int IdBonificacion)
        {
            oCon.Conectar();
            if (TipoFacturacionConfiguracion == Convert.ToInt32(CapaNegocios.Tipo_Facturacion.Id_Tipo_Facturacion.POR_CATEGORIAS))
                oCon.CrearComando(String.Format("select id, id_grupo, id_tipo_servicio, id_servicio, id_servicio_sub, id_velocidad, id_velocidad_tipo, id_tipo_facturacion, requiere_condiciones, nombre, porcentaje, tipo_bonificacion,case when nivel=0 then 'Grupo de servicio' when nivel=1 then 'Tipo de servicio' when nivel=2 then 'Servicio' else 'Sub servicio' end as nivel," +
                                                "(select nombre from servicios_categorias where id = bonificaciones_aplicacion.id_tipo_facturacion) as catzona, (select nombre from servicios_grupos where id = bonificaciones_aplicacion.id_grupo) as grupo, (select nombre from servicios_tipos where id = bonificaciones_aplicacion.id_tipo_servicio) as tipo_servicio,(select descripcion from servicios where id=bonificaciones_aplicacion.id_servicio) as servicio," +
                                                " CASE WHEN tipo_servicio_sub = 'S' THEN(select descripcion from servicios_sub where id = bonificaciones_aplicacion.id_servicio_sub)  WHEN tipo_servicio_sub = 'P' THEN(select nombre from partes_fallas where id = bonificaciones_aplicacion.id_servicio_sub) WHEN tipo_servicio_sub = 'E' THEN(select nombre from equipos_tipos where id = bonificaciones_aplicacion.id_servicio_sub) ELSE '' END as subservicio," +
                                                " (select velocidad from servicios_velocidades where id = bonificaciones_aplicacion.id_velocidad) as velocidad,(select nombre from servicios_velocidades_tip where id = bonificaciones_aplicacion.id_velocidad_tipo) as velocidad_tipo, CASE WHEN tipo_servicio_sub = 'S' THEN 'Servicio' WHEN tipo_servicio_sub = 'P' THEN 'Solicitud' WHEN tipo_servicio_sub = 'E' THEN 'Equipo' ELSE '' END as tipo_servicio_sub, DATE(fecha_desde), date(fecha_hasta), (select count(id) from bonificaciones_aplicacion_condiciones where id_bonificacion_aplicacion=bonificaciones_aplicacion.id and borrado=0) as cantidad_condiciones, requiere_condiciones, cantidad_periodos, mes_desde, mes_hasta, por_contratacion, contemplar_fecha_completa  from bonificaciones_aplicacion where id_bonificacion = {0} and borrado = 0", IdBonificacion));
            else
                oCon.CrearComando(String.Format("select id, id_grupo, id_tipo_servicio, id_servicio, id_servicio_sub, id_velocidad, id_velocidad_tipo, id_tipo_facturacion, id_localidad,requiere_condiciones, nombre, porcentaje, tipo_bonificacion, case when nivel=0 then 'Grupo de servicio' when nivel=1 then 'Tipo de servicio' when nivel=2 then 'Servicio' else 'Sub servicio' end as nivel," +
                                  "(select nombre from zonas where id=bonificaciones_aplicacion.id_tipo_facturacion) as catzona, (select nombre from localidades where id=bonificaciones_aplicacion.id_localidad) as localidad," +
                                  "(select nombre from servicios_grupos where id=bonificaciones_aplicacion.id_grupo) as grupo, (select nombre from servicios_tipos where id=bonificaciones_aplicacion.id_tipo_servicio) as tipo_servicio, " +
                                  "(select descripcion from servicios where id=bonificaciones_aplicacion.id_servicio) as servicio, CASE WHEN tipo_servicio_sub = 'S' THEN(select descripcion from servicios_sub where id = bonificaciones_aplicacion.id_servicio_sub)  WHEN tipo_servicio_sub = 'P' THEN(select nombre from partes_fallas where id = bonificaciones_aplicacion.id_servicio_sub) WHEN tipo_servicio_sub = 'E' THEN(select nombre from equipos_tipos where id = bonificaciones_aplicacion.id_servicio_sub) ELSE '' END as subservicio, " +
                                  "(select velocidad from servicios_velocidades where id=bonificaciones_aplicacion.id_velocidad) as velocidad," +
                                  "(select nombre from servicios_velocidades_tip where id=bonificaciones_aplicacion.id_velocidad_tipo) as velocidad_tipo, CASE WHEN tipo_servicio_sub='S' THEN 'Servicio' WHEN tipo_servicio_sub='P' THEN 'Solicitud' WHEN tipo_servicio_sub='E' THEN 'Equipo' ELSE '' END as tipo_servicio_sub, DATE(fecha_desde), date(fecha_hasta), (select count(id) from bonificaciones_aplicacion_condiciones where id_bonificacion_aplicacion=bonificaciones_aplicacion.id and borrado=0) as cantidad_condiciones, requiere_condiciones, cantidad_periodos, mes_desde, mes_hasta, por_contratacion, contemplar_fecha_completa from bonificaciones_aplicacion where id_bonificacion={0} and borrado=0", IdBonificacion));
            DataTable dt = oCon.Tabla();
            oCon.DesConectar();
            return dt;
        }

        public DataTable ListarServiciosPorTipoYFacturacion(int IdTipoServicio, int IdFacturacion, int idTarifaActual)
        {
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                oCon.CrearComando(String.Format("select id_servicios, servicio, id_servicios_tipos as id_tipo_servicio, id_servicios_grupos  from vw_tarifas where id_tipo_facturacion ={0} and id_servicios_tipos={1} and id_servicios_tarifas={2} group by id_servicios", IdFacturacion, IdTipoServicio, idTarifaActual));
                dt = oCon.Tabla();
                oCon.DesConectar();
            }
            catch
            {
                oCon.DesConectar();
            }

            return dt;
        }

        public DataTable ListarSubServiciosPorServicioYFacturacion(int IdServicio, int IdFacturacion, int idTarifaActual)
        {
            DataTable dt = new DataTable();

            try
            {
                oCon.Conectar();
                oCon.CrearComando(String.Format("select id_servicios_sub, subservicio, servicio, id_servicios, id_servicios_tipos, id_servicios_grupos, tiposub, (select requiere_velocidad from servicios where id=vw_tarifas.id_servicios) as requiere_velocidad, idtipodesub from  vw_tarifas where id_tipo_facturacion ={0} and id_servicios ={1} and id_servicios_tarifas={2} group by id_servicios_sub, tiposub", IdFacturacion, IdServicio, idTarifaActual));
                dt = oCon.Tabla();
                oCon.DesConectar();
            }
            catch
            {
                oCon.DesConectar();
            }

            return dt;
        }

        public DataTable ListarVelocidadesSubServicio(int IdTarifaActual, int IdTipoFacturacion, int IdSubServicio)
        {
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                oCon.CrearComando(String.Format("select id_servicios_velocidad as id_velocidad, id_servicios_velocidad_tip as id_velocidad_tipo, (select velocidad from servicios_velocidades where id=id_servicios_velocidad) as velocidad, (select nombre from servicios_velocidades_tip where id=id_servicios_velocidad_tip) as velocidad_tipo from servicios_tarifas_sub_esp where id_servicios_tarifas={0}" +
                    " and id_tipo_facturacion ={1} and id_servicios_sub = {2}", IdTarifaActual, IdTipoFacturacion, IdSubServicio));
                dt = oCon.Tabla();
                oCon.DesConectar();
            }
            catch
            {
                oCon.DesConectar();
            }

            return dt;
        }

        public DataTable ListarPorId(int IdBonificacionAplicacion)
        {
            oCon.Conectar();

            oCon.CrearComando(String.Format("select id, id_grupo,nivel, id_tipo_servicio, id_servicio, id_servicio_sub, id_velocidad, id_velocidad_tipo, id_tipo_facturacion, nombre, porcentaje, tipo_bonificacion," +
                              "(select nombre from servicios_categorias where id=id_tipo_facturacion) as catzona,(select nombre from servicios_grupos where id=id_grupo) as grupo, (select nombre from servicios_tipos where id=id_tipo_servicio) as tipo_servicio, " +
                              "(select descripcion from servicios where id=id_servicio) as servicio, CASE WHEN tipo_servicio_sub='S' THEN (select descripcion from servicios_sub where id=id_servicio_sub) WHEN tipo_servicio_sub='P' THEN (select nombre from partes_fallas where id=id_servicio_sub) WHEN tipo_servicio_sub='E' THEN (select nombre from equipos_tipos where id=id_servicio_sub) ELSE '' END as subservicio, " +
                              "(select velocidad from servicios_velocidades where id=id_velocidad) as velocidad," +
                              "(select nombre from servicios_velocidades_tip where id=id_velocidad_tipo) as velocidad_tipo, tipo_servicio_sub as tipo_sub, CASE WHEN tipo_servicio_sub='S' THEN 'Servicio' WHEN tipo_servicio_sub='P' THEN 'Solicitud' WHEN tipo_servicio_sub='E' THEN 'Equipo' ELSE '' END as tipo_servicio_sub, DATE(fecha_desde), date(fecha_hasta), requiere_condiciones, cantidad_periodos, mes_desde, mes_hasta, por_contratacion, contemplar_fecha_completa from bonificaciones_aplicacion where id={0} and borrado=0", IdBonificacionAplicacion));

            DataTable dt = oCon.Tabla();
            oCon.DesConectar();
            return dt;
        }

    }
}
