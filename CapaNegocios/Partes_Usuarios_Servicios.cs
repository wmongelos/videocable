using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;

namespace CapaNegocios
{
    public class Partes_Usuarios_Servicios
    {
        public Int32 Id { get; set; }
        public Int32 Id_Parte { get; set; }
        public Int32 Id_Usuario_Servicio { get; set; }
        public Int32 Id_Servicio { get; set; }
        public Int32 Borrado { get; set; }
        public Int32 idParteFalla { get; set; }
        public Int32 idAppExterna { get; set; } = 0;
        public Int32 IdPlastico = 0;
        public Int32 idTipoServicio = 0;
        public Int32 idGrupoServicio = 0;
        public Int32 Asignacion_Ip_Fija { get; private set; } = 0;
        public Int32 AplicoExterna { get; set; }
        public Int32 id_usuarios_servicios_sub { get; set; }
        private Conexion oCon = new Conexion();

        public enum CONDICION_REQ_EQUIPOS
        {
            TODOS = 1,
            REQUIEREN_EQUIPOS = 2,
            NO_REQUIEREN_EQUIPOS = 3
        }

        public enum CONDICION_IP_FIJA
        {
            PENDIENTE_DE_ASIGNACION = 1,
            NO_NECESITA = 2,
            ASIGNADA = 3
        }

        public void Guardar(Partes_Usuarios_Servicios oParteUsuarioServicio)
        {
            try
            {
                if (oParteUsuarioServicio.Id_Usuario_Servicio != 0)
                    oParteUsuarioServicio.Asignacion_Ip_Fija = GetEstadoDeIpFija(oParteUsuarioServicio.Id_Usuario_Servicio);
                oCon.Conectar();
                if (oParteUsuarioServicio.Id == 0)
                {
                    oCon.CrearComando("INSERT INTO partes_usuarios_servicios(Id_parte, Id_usuarios_servicios, Id_servicio,id_parte_falla,id_servicio_grupo,id_servicio_tipo,id_plastico,Asignacion_Ip_Fija,id_aplicacion_externa,id_personal,id_usuarios_servicios_Sub ) " +
                        "VALUES(@id_parte, @id_usuario_servicio, @id_servicio,@id_falla,@id_grupo,@id_tipo,@id_plastico,@asigIpFija,@id_app_externa,@personal,@id_usu_serv_sub )");
                    oCon.AsignarParametroEntero("@id_parte", oParteUsuarioServicio.Id_Parte);
                    oCon.AsignarParametroEntero("@id_usuario_servicio", oParteUsuarioServicio.Id_Usuario_Servicio);
                    oCon.AsignarParametroEntero("@id_servicio", oParteUsuarioServicio.Id_Servicio);
                    oCon.AsignarParametroEntero("@id_falla", oParteUsuarioServicio.idParteFalla);
                    oCon.AsignarParametroEntero("@id_grupo", oParteUsuarioServicio.idGrupoServicio);
                    oCon.AsignarParametroEntero("@id_tipo", oParteUsuarioServicio.idTipoServicio);
                    oCon.AsignarParametroEntero("@id_plastico", oParteUsuarioServicio.IdPlastico);
                    oCon.AsignarParametroEntero("@asigIpFija", oParteUsuarioServicio.Asignacion_Ip_Fija);
                    oCon.AsignarParametroEntero("@id_app_externa", oParteUsuarioServicio.idAppExterna);
                    oCon.AsignarParametroEntero("@id_usu_serv_sub", oParteUsuarioServicio.id_usuarios_servicios_sub);
                    oCon.AsignarParametroEntero("@personal", Personal.Id_Login);
                }
                else
                {
                    oCon.CrearComando("update partes_usuarios_servicios set Id_parte=@id_parte, Id_usuarios_servicios=@id_usuario_servicio, Id_servicio=@id_servicio,id_parte_falla=@id_falla, Asignacion_Ip_Fija = @asigIpFija, id_aplicacion_externa=id_app_externa where Id=@id");
                    oCon.AsignarParametroEntero("@id_parte", oParteUsuarioServicio.Id_Parte);
                    oCon.AsignarParametroEntero("@id_usuario_servicio", oParteUsuarioServicio.Id_Usuario_Servicio);
                    oCon.AsignarParametroEntero("@id_servicio", oParteUsuarioServicio.Id_Servicio);
                    oCon.AsignarParametroEntero("@id_falla", oParteUsuarioServicio.idParteFalla);
                    oCon.AsignarParametroEntero("@id", oParteUsuarioServicio.Id);
                    oCon.AsignarParametroEntero("@asigIpFija", oParteUsuarioServicio.Asignacion_Ip_Fija);
                    oCon.AsignarParametroEntero("@id_app_externa", oParteUsuarioServicio.idAppExterna);

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

        public DataTable ListarServiciosPorParte(int Id_parte, CONDICION_REQ_EQUIPOS Condicion)
        {
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                switch (Condicion)
                {
                    case CONDICION_REQ_EQUIPOS.TODOS:
                        oCon.CrearComando("select partes_usuarios_servicios.id, id_parte, partes_usuarios_servicios.id_usuarios_servicios, usuarios_servicios.id_usuarios, usuarios_servicios.id_servicios,usuarios_servicios.id_tipo_facturacion, " +
                                          " if (servicios.requiere_velocidad = 'SI',concat(servicios.descripcion, ' ', cast(servicios_velocidades.velocidad as char(4)), ' MB ', servicios_velocidades_tip.nombre),servicios.descripcion) as servicio," +
                                          " servicios.requiere_equipo, servicios.requiere_tarjeta, servicios.requiere_velocidad, servicios_tipos.nombre as tiposervicio, servicios_tipos.id as id_servicios_tipos," +
                                          " servicios_estados.estado as estado, servicios.id_parte_corte as id_Corte ,usuarios_locaciones.id, usuarios_locaciones.calle,usuarios_locaciones.altura, localidades.nombre as localidad," +
                                          " partes_usuarios_servicios.id_plastico,partes_usuarios_servicios.id_parte_falla, partes_usuarios_servicios.Asignacion_Ip_Fija,usuarios_servicios.id_usuarios_locaciones,partes_fallas.id_partes_operaciones,partes_operaciones.requiere_tecnico,partes_fallas.nombre as falla, servicios.Id_Aplicaciones_Externas as id_app_ext,partes_usuarios_servicios.id_usuarios_servicios_sub as id_usu_serv_sub,date(partes.Fecha_Programado )AS Programado, servicios_sub.descripcion as SubServicio,  " +
                                          " equipos_tipos.nombre as equipo_tipo, equipos_marcas.nombre as equipo_marca, equipos.serie, equipos.mac" +
                                          " from partes_usuarios_servicios " +
                                          " left join partes ON partes_usuarios_servicios.Id_parte = partes.id " +
                                          " left join usuarios_servicios on partes_usuarios_servicios.id_usuarios_servicios = usuarios_servicios.id" +
                                          " left join servicios_estados ON servicios_estados.id = usuarios_servicios.id_servicios_estados" +
                                          " left join servicios on usuarios_servicios.id_servicios = servicios.id left join servicios_tipos on servicios.id_servicios_tipos = servicios_tipos.id" +
                                          " left join usuarios_locaciones on usuarios_servicios.id_usuarios_locaciones = usuarios_locaciones.id " +
                                          " left join localidades on usuarios_locaciones.id_localidades = localidades.id" +
                                          " left join usuarios_servicios_sub on usuarios_servicios.id = usuarios_servicios_sub.id_usuarios_servicios" +
                                          " left join servicios_sub on usuarios_servicios_sub.id_servicios_sub = servicios_sub.id" +
                                          " left join servicios_velocidades on usuarios_servicios_sub.id_servicios_velocidades = servicios_velocidades.id " +
                                          " left join servicios_velocidades_tip on usuarios_servicios_sub.id_servicios_velocidades_tip = servicios_velocidades_tip.id" +
                                          " left join partes_fallas on partes_fallas.id = partes_usuarios_servicios.id_parte_falla" +
                                          " left join partes_operaciones on partes_operaciones.id = partes_fallas.id_partes_operaciones" +
                                          " left join usuarios_servicios_equipos on usuarios_servicios_equipos.id_usuario_servicio = usuarios_servicios.id" +
                                          " left join equipos on equipos.id = usuarios_servicios_equipos.id_equipo" +
                                          " left join equipos_tipos on equipos_tipos.id = equipos.id_equipos_tipos" +
                                          " left join equipos_marcas on equipos_marcas.id = equipos.id_equipos_marcas" +
                                          " where partes_usuarios_servicios.id_parte = @id_parte and partes_usuarios_servicios.borrado = 0 and servicios_sub.id_servicios_sub_tipos = @id_servicios_sub_tipos group by partes_usuarios_servicios.id_usuarios_servicios");
                        oCon.AsignarParametroEntero("@id_servicios_sub_tipos", Convert.ToInt32(Servicios_Sub.SERVICIO_SUB_TIPOS.SUBSERVICIO));
                        break;
                    case CONDICION_REQ_EQUIPOS.REQUIEREN_EQUIPOS:
                        oCon.CrearComando("select partes_usuarios_servicios.id, id_parte, partes_usuarios_servicios.id_usuarios_servicios, usuarios_servicios.id_usuarios,usuarios_locaciones.id,partes_usuarios_servicios.id_parte_falla,usuarios_servicios.id_servicios, if (servicios.requiere_velocidad = 'SI',concat(servicios.descripcion, ' ', cast(servicios_velocidades.velocidad as char(4)), ' MB ', servicios_velocidades_tip.nombre),servicios.descripcion) as servicio, servicios.requiere_equipo, servicios.requiere_tarjeta, servicios.requiere_velocidad, servicios_tipos.nombre as tiposervicio, servicios_tipos.id as id_servicios_tipos,partes_usuarios_servicios.id_plastico, servicios.Id_Aplicaciones_Externas as id_app_ext " +
                                            " from partes_usuarios_servicios " +
                                            " left join usuarios_servicios on partes_usuarios_servicios.id_usuarios_servicios = usuarios_servicios.id " +
                                            " left join servicios on usuarios_servicios.id_servicios = servicios.id " +
                                            " left join servicios_tipos on servicios.id_servicios_tipos = servicios_tipos.id " +
                                            " left join usuarios_locaciones on usuarios_servicios.id_usuarios_locaciones = usuarios_locaciones.id " +
                                            " left join localidades on usuarios_locaciones.id_localidades = localidades.id " +
                                            " left join usuarios_servicios_sub on usuarios_servicios.id = usuarios_servicios_sub.id_usuarios_servicios" +
                                            " left join partes on partes.id = partes_usuarios_servicios.id_parte" +
                                            " left join servicios_sub on usuarios_servicios_sub.id_servicios_sub = servicios_sub.id " +
                                            " left join servicios_velocidades on usuarios_servicios_sub.id_servicios_velocidades = servicios_velocidades.id " +
                                            " left join servicios_velocidades_tip on usuarios_servicios_sub.id_servicios_velocidades_tip = servicios_velocidades_tip.id" +
                                            " where partes_usuarios_servicios.id_parte = @id_parte and partes_usuarios_servicios.borrado = 0  and servicios.requiere_equipo = 'SI' group by partes_usuarios_servicios.id_usuarios_servicios");                      
                         break;
                    case CONDICION_REQ_EQUIPOS.NO_REQUIEREN_EQUIPOS:
                        oCon.CrearComando("select partes_usuarios_servicios.id,servicios.id_parte_corte as id_Corte , id_parte, id_usuarios_servicios, usuarios_servicios.id_usuarios, usuarios_servicios.id_servicios,partes_usuarios_servicios.id_parte_falla," +
                                          " servicios.descripcion as servicio, servicios.requiere_equipo, servicios.requiere_tarjeta, servicios.requiere_velocidad,usuarios_locaciones.id," +
                                          " servicios_tipos.nombre as tiposervicio, servicios_tipos.id as id_servicios_tipos,partes_usuarios_servicios.id_plastico, servicios.Id_Aplicaciones_Externas as id_app_ext  from partes_usuarios_servicios" +
                                          " left join partes on partes.id = partes_usuarios_servicios.id_parte" +
                                          " left join usuarios_servicios on partes_usuarios_servicios.id_usuarios_servicios = usuarios_servicios.id" +
                                          " left join servicios on usuarios_servicios.id_servicios = servicios.id " +
                                          " left join servicios_tipos on servicios.id_servicios_tipos = servicios_tipos.id" +
                                          " left join usuarios_locaciones on usuarios_locaciones.id = partes.id_usuarios_locaciones " +
                                          " where partes_usuarios_servicios.id_parte = @id_parte and servicios.requiere_equipo != 'SI' and partes_usuarios_servicios.borrado = 0 group by partes_usuarios_servicios.id_usuarios_servicios");
                        break;
                }
                oCon.AsignarParametroEntero("@id_parte", Id_parte);

                dt = oCon.Tabla();
                oCon.DesConectar();
            }
            catch (Exception e )
            {
                string msg = e.Message.ToString();
                oCon.DesConectar();
                throw;
            }
            return dt;
        }

        public DataTable BuscarPorParteEquipo(int Id_parte_equipo)
        {
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                oCon.CrearComando("select partes_equipos.id,partes_equipos.id_partes,partes_equipos.id_servicios,partes_equipos.id_tarjeta,partes_equipos.id_usuarios_servicios, servicios.descripcion as servicio, servicios_tipos.nombre as tiposervicio, servicios_tipos.id as id_servicios_tipo from partes_equipos left join servicios on partes_equipos.id_servicios=servicios.id left join servicios_tipos on servicios.id_servicios_tipos=servicios_tipos.id where partes_equipos.id=@id_parte_equipo");
                oCon.AsignarParametroEntero("@id_parte_equipo", Id_parte_equipo);
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

        public void GuardarPartesUsuariosSericios(DataTable dt)
        {
            Servicios oServicios = new Servicios();
            DataTable dtDatosServicios = new DataTable();
            foreach (DataRow item in dt.Rows)
            {
                int asig_ip_fija = GetEstadoDeIpFija(Convert.ToInt32(item["Id_Usuarios_Servicios"]));
                int idTipoServicio = Convert.ToInt32(item["Id_Servicios"]);
                int requiere_conf = 0;
                var idParte = Convert.ToInt32(item["Id"]);
                var idUsuarioServicio = Convert.ToInt32(item["Id_Usuarios_Servicios"]);
                var idServicio = Convert.ToInt32(item["Id_Servicios"]);
                int idParteFalla = Convert.ToInt32(item["Id_partes_Fallas"]);
                dtDatosServicios = oServicios.BuscarDatosServicio(idServicio);
                var id_aplicacion_externa = Convert.ToInt32(dtDatosServicios.Rows[0]["id_aplicaciones_externas"]);
                if (id_aplicacion_externa > 0)
                    requiere_conf = 1;
                else
                    requiere_conf = 0;

                try
                {
                    oCon.Conectar();
                    oCon.CrearComando("INSERT INTO partes_usuarios_servicios (id_parte,id_usuarios_servicios,id_servicio,id_aplicacion_externa,configurado,id_parte_falla,Asignacion_Ip_Fija) VALUES (@idParte,@idUsuariosServicios,@idServicios,@id_aplicacion,@conf,@id_falla,@asigIpFija)");
                    oCon.AsignarParametroEntero("@idParte", idParte);
                    oCon.AsignarParametroEntero("@idUsuariosServicios", idUsuarioServicio);
                    oCon.AsignarParametroEntero("@idServicios", idServicio);
                    oCon.AsignarParametroEntero("@id_aplicacion", id_aplicacion_externa);
                    oCon.AsignarParametroEntero("@conf", 0);
                    oCon.AsignarParametroEntero("@id_falla", idParteFalla);
                    oCon.AsignarParametroEntero("@asigIpFija", asig_ip_fija);
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

        public DataTable[] ListarPartesAConfigurar(DateTime fecha, Partes.Partes_Operaciones oOperacion, Partes.Partes_Estados oEstado, int id_app_externa,out List<Partes_Usuarios_Servicios>oListaPartesServicios)
        {
            DataTable[] dtSalida = new DataTable[2];
            DataTable dt = new DataTable();
            DataTable dt2 = new DataTable();

            try
            {
                oCon.Conectar();
                if (oOperacion == Partes.Partes_Operaciones.PARTE_INTERNO)
                {
                    oCon.CrearComando("select partes_usuarios_servicios.configurado,partes_usuarios_servicios.id as id_parte_us,partes_usuarios_servicios.id_parte,partes.fecha_programado,partes.id_partes_estados,partes_usuarios_servicios.id_parte_falla, servicios.id_aplicaciones_externas, partes_fallas.nombre as falla, usuarios_servicios.id_usuarios, usuarios.codigo, usuarios.nombre, concat(usuarios.apellido, ', ', usuarios.nombre) as usuario, usuarios.apellido, usuarios.correo_electronico,"
                   + " partes_usuarios_servicios.id_usuarios_servicios, partes_usuarios_servicios.id_servicio,"
                   + " usuarios_servicios.id_usuarios_locaciones,"
                   + " servicios.descripcion as servicio,"
                   + " concat('calle: ', usuarios_locaciones.calle, ' nro: ', cast(usuarios_locaciones.altura as char(6)), ' piso: ', usuarios_locaciones.piso, ' depto: ', usuarios_locaciones.depto) as locacion, usuarios_locaciones.calle, usuarios_locaciones.entre_calle_1, usuarios_locaciones.altura, usuarios_locaciones.entre_calle_2,"
                   + " usuarios_locaciones.codigo_postal, usuarios_locaciones.prefijo_1, usuarios_locaciones.prefijo_2, usuarios_locaciones.telefono_1, usuarios_locaciones.telefono_2, usuarios_locaciones.id_localidades, localidades.nombre as localidad,"
                   + " usuarios_servicios_sub.id_servicios_velocidades,"
                   + " usuarios_servicios_sub.id_servicios_velocidades_tip, servicios_velocidades.velocidad, servicios_velocidades_tip.nombre as velocidad_tipo, partes_fallas.id_partes_operaciones"
                   + " from partes_usuarios_servicios"
                   + " left join partes on partes.id = partes_usuarios_servicios.id_parte"
                   + " left join usuarios_servicios on usuarios_servicios.id = partes_usuarios_servicios.id_usuarios_servicios"
                   + " left join partes_fallas on partes_fallas.id = partes_usuarios_servicios.id_parte_falla"
                   + " left join servicios on servicios.id = partes_usuarios_servicios.id_servicio"
                   + " left join usuarios on usuarios.id = usuarios_servicios.id_usuarios"
                   + " left join usuarios_locaciones on usuarios_locaciones.id = usuarios_servicios.id_usuarios_locaciones"
                   + " left join usuarios_servicios_sub on usuarios_servicios_sub.id_usuarios_servicios = partes_usuarios_servicios.id_usuarios_servicios"
                   + " left join servicios_sub on servicios_sub.id = usuarios_servicios_sub.id_servicios_sub"
                   + " left join servicios_velocidades on servicios_velocidades.id = usuarios_servicios_sub.id_servicios_velocidades"
                   + " left join servicios_velocidades_tip on servicios_velocidades_tip.id = usuarios_servicios_sub.id_servicios_velocidades_tip"
                   + " left join localidades on localidades.id = usuarios_locaciones.id_localidades"
                   + " where servicios_sub.id_servicios_sub_tipos = 1 and partes_fallas.id_partes_operaciones=@idoperacion1 and partes.id_partes_Estados=@estado1 and date(partes.fecha_programado) <= date(@fecha) order by partes.fecha_programado asc ");
                    oCon.AsignarParametroEntero("@idoperacion1", (int)oOperacion);
                    oCon.AsignarParametroEntero("@estado1", (int)oEstado);
                    oCon.AsignarParametroFecha("@fecha", fecha);
                    dt = oCon.Tabla();
                }
                else
                {
                    oCon.CrearComando("select partes_usuarios_servicios.configurado,partes_usuarios_servicios.id as id_parte_us,partes_usuarios_servicios.id_parte,partes.fecha_programado,partes.id_partes_estados,partes_usuarios_servicios.id_parte_falla, servicios.id_aplicaciones_externas, partes_fallas.nombre as falla, usuarios_servicios.id_usuarios, usuarios.codigo, usuarios.nombre, concat(usuarios.apellido, ', ', usuarios.nombre) as usuario, usuarios.apellido, usuarios.correo_electronico,"
                    + " partes_usuarios_servicios.id_usuarios_servicios, partes_usuarios_servicios.id_servicio,"
                    + " usuarios_servicios.id_usuarios_locaciones,"
                    + " servicios.descripcion as servicio,"
                    + " concat('calle: ', usuarios_locaciones.calle, ' nro: ', cast(usuarios_locaciones.altura as char(6)), ' piso: ', usuarios_locaciones.piso, ' depto: ', usuarios_locaciones.depto) as locacion, usuarios_locaciones.calle, usuarios_locaciones.entre_calle_1, usuarios_locaciones.altura, usuarios_locaciones.entre_calle_2,"
                    + " usuarios_locaciones.codigo_postal, usuarios_locaciones.prefijo_1, usuarios_locaciones.prefijo_2, usuarios_locaciones.telefono_1, usuarios_locaciones.telefono_2, usuarios_locaciones.id_localidades, localidades.nombre as localidad,"
                    + " usuarios_servicios_sub.id_servicios_velocidades,"
                    + " usuarios_servicios_sub.id_servicios_velocidades_tip, servicios_velocidades.velocidad, servicios_velocidades_tip.nombre as velocidad_tipo, partes_fallas.id_partes_operaciones, servicios_sub.id as id_servicio_sub"
                    + " from partes_usuarios_servicios"
                    + " left join partes on partes.id = partes_usuarios_servicios.id_parte"
                    + " left join usuarios_servicios on usuarios_servicios.id = partes_usuarios_servicios.id_usuarios_servicios"
                    + " left join partes_fallas on partes_fallas.id = partes_usuarios_servicios.id_parte_falla"
                    + " left join servicios on servicios.id = partes_usuarios_servicios.id_servicio"
                    + " left join usuarios on usuarios.id = usuarios_servicios.id_usuarios"
                    + " left join usuarios_locaciones on usuarios_locaciones.id = usuarios_servicios.id_usuarios_locaciones"
                    + " left join usuarios_servicios_sub on usuarios_servicios_sub.id_usuarios_servicios = partes_usuarios_servicios.id_usuarios_servicios"
                    + " left join servicios_sub on servicios_sub.id = usuarios_servicios_sub.id_servicios_sub"
                    + " left join servicios_velocidades on servicios_velocidades.id = usuarios_servicios_sub.id_servicios_velocidades"
                    + " left join servicios_velocidades_tip on servicios_velocidades_tip.id = usuarios_servicios_sub.id_servicios_velocidades_tip"
                    + " left join localidades on localidades.id = usuarios_locaciones.id_localidades"
                    + " left join aplicaciones_externas on aplicaciones_externas.id = servicios.id_aplicaciones_externas"
                    + " where servicios_sub.id_servicios_sub_tipos = 1 and (partes_fallas.id_partes_operaciones=@idoperacion1 or partes_fallas.id_partes_operaciones=@idoperacion2 or partes_fallas.id_partes_operaciones=@idoperacion3  or partes_fallas.id_partes_operaciones=@idoperacion4  or partes_fallas.id_partes_operaciones=@idoperacion5 or partes_fallas.id_partes_operaciones=@idoperacion6 or partes_fallas.id_partes_operaciones=@idoperacion7) and id_aplicaciones_externas=@appExterna and partes.id_partes_Estados<>@estado1 and partes.id_partes_Estados<>@estado2 and partes_usuarios_servicios.configurado=0 and date(partes.fecha_programado) <= date(@fecha) and usuarios_servicios.borrado=0 order by partes.fecha_programado asc ");
                    oCon.AsignarParametroEntero("@idoperacion1", Convert.ToInt32(Partes.Partes_Operaciones.CONEXION));
                    oCon.AsignarParametroEntero("@idoperacion2", Convert.ToInt32(Partes.Partes_Operaciones.BAJA));
                    oCon.AsignarParametroEntero("@idoperacion3", Convert.ToInt32(Partes.Partes_Operaciones.CAMBIO_DE_EQUIPO));
                    oCon.AsignarParametroEntero("@idoperacion4", Convert.ToInt32(Partes.Partes_Operaciones.RECONEXION));
                    oCon.AsignarParametroEntero("@idoperacion5", Convert.ToInt32(Partes.Partes_Operaciones.CORTE));
                    oCon.AsignarParametroEntero("@idoperacion6", Convert.ToInt32(Partes.Partes_Operaciones.CAMBIO_TECNOLOGIA));
                    oCon.AsignarParametroEntero("@idoperacion7", Convert.ToInt32(Partes.Partes_Operaciones.ASIGNACION_DE_EQUIPO));
                    oCon.AsignarParametroEntero("@estado1", Convert.ToInt32(Partes.Partes_Estados.REALIZADO));
                    oCon.AsignarParametroEntero("@estado2", Convert.ToInt32(Partes.Partes_Estados.ANULADO));
                    oCon.AsignarParametroEntero("@appExterna", id_app_externa);
                    oCon.AsignarParametroFecha("@fecha", fecha);

                    dt = oCon.Tabla();
                    oCon.DesConectar();

                    oCon.Conectar();
                    oCon.CrearComando("select partes_usuarios_servicios.configurado,partes_usuarios_servicios.id as id_parte_us,partes.fecha_programado"
                  + " from partes_usuarios_servicios"
                  + " left join partes on partes.id = partes_usuarios_servicios.id_parte"
                  + " left join usuarios_servicios on usuarios_servicios.id = partes_usuarios_servicios.id_usuarios_servicios"
                  + " left join partes_fallas on partes_fallas.id = partes_usuarios_servicios.id_parte_falla"
                  + " left join servicios on servicios.id = partes_usuarios_servicios.id_servicio"
                  + " left join usuarios on usuarios.id = usuarios_servicios.id_usuarios"
                  + " left join usuarios_locaciones on usuarios_locaciones.id = usuarios_servicios.id_usuarios_locaciones"
                  + " left join usuarios_servicios_sub on usuarios_servicios_sub.id_usuarios_servicios = partes_usuarios_servicios.id_usuarios_servicios"
                  + " left join servicios_sub on servicios_sub.id = usuarios_servicios_sub.id_servicios_sub"
                  + " where servicios.id_aplicaciones_externas > 0 and servicios.id_servicios_tipos=4 and servicios_sub.id_servicios_sub_tipos = 1 and (partes_fallas.id_partes_operaciones=@idoperacion1 or partes_fallas.id_partes_operaciones=@idoperacion2 or partes_fallas.id_partes_operaciones=@idoperacion3  or partes_fallas.id_partes_operaciones=@idoperacion4  or partes_fallas.id_partes_operaciones=@idoperacion5 or partes_fallas.id_partes_operaciones=@idoperacion6 or partes_fallas.id_partes_operaciones=@idoperacion7) and id_aplicaciones_externas=1 and partes.id_partes_Estados<>@estado1 and partes.id_partes_Estados<>@estado2 and partes_usuarios_servicios.configurado=0 and date(partes.fecha_programado) > date(@fecha) order by partes.fecha_programado desc ");
                    oCon.AsignarParametroEntero("@idoperacion1", Convert.ToInt32(Partes.Partes_Operaciones.CONEXION));
                    oCon.AsignarParametroEntero("@idoperacion2", Convert.ToInt32(Partes.Partes_Operaciones.BAJA));
                    oCon.AsignarParametroEntero("@idoperacion3", Convert.ToInt32(Partes.Partes_Operaciones.CAMBIO_DE_EQUIPO));
                    oCon.AsignarParametroEntero("@idoperacion4", Convert.ToInt32(Partes.Partes_Operaciones.RECONEXION));
                    oCon.AsignarParametroEntero("@idoperacion5", Convert.ToInt32(Partes.Partes_Operaciones.CORTE));
                    oCon.AsignarParametroEntero("@idoperacion6", Convert.ToInt32(Partes.Partes_Operaciones.CAMBIO_TECNOLOGIA));
                    oCon.AsignarParametroEntero("@idoperacion7", Convert.ToInt32(Partes.Partes_Operaciones.ASIGNACION_DE_EQUIPO));

                    oCon.AsignarParametroEntero("@estado1", Convert.ToInt32(Partes.Partes_Estados.REALIZADO));
                    oCon.AsignarParametroEntero("@estado2", Convert.ToInt32(Partes.Partes_Estados.ANULADO));
                    oCon.AsignarParametroFecha("@fecha", fecha);
                    dt2 = oCon.Tabla();

                }
                oCon.DesConectar();

            }
            catch (Exception x)
            {

                oCon.DesConectar();
                throw;
            }
            dtSalida[0] = dt;
            dtSalida[1] = dt2;

            oListaPartesServicios = new List<Partes_Usuarios_Servicios>();
            return dtSalida;
        }

        public DataTable aux()
        {
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                oCon.CrearComando("SELECT * from partes_usuarios_servicios");
                dt = oCon.Tabla();
                oCon.DesConectar();

            }
            catch (Exception)
            {

                throw;
            }
            return dt;
        }

        public Int32 actualizarFalla(int idParte, int idUsuarioSer, int idfalla)
        {
            Int32 retorno = 0;
            try
            {
                oCon.Conectar();
                oCon.CrearComando("UPDATE partes_usuarios_servicios SET id_parte_falla=@idfalla where id_parte=@idparte and id_usuarios_servicios=@idususer");
                oCon.AsignarParametroEntero("@idfalla", idfalla);
                oCon.AsignarParametroEntero("@idparte", idParte);
                oCon.AsignarParametroEntero("@idususer", idUsuarioSer);
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
            return retorno;
        }

        public Int32 PasarAConfigurado(int idParteUsuarioServicio)
        {
            Int32 salida = 0;
            try
            {
                oCon.Conectar();
                oCon.CrearComando("UPDATE partes_usuarios_servicios SET configurado=1 WHERE id=@id");
                oCon.AsignarParametroEntero("@id", idParteUsuarioServicio);
                oCon.ComenzarTransaccion();
                oCon.EjecutarComando();
                oCon.ConfirmarTransaccion();
                oCon.DesConectar();

            }
            catch (Exception)
            {
                oCon.DesConectar();
                salida = -1;
                throw;
            }
            return salida;
        }

        private int GetEstadoDeIpFija(int id_usuario_servicio)
        {
            DataTable dtIpFija;
            int ipFija;
            try
            {
                oCon.Conectar();
                string comando = "SELECT usuarios_servicios_sub.id_ip_fija FROM usuarios_servicios_sub LEFT JOIN"
                                + " usuarios_servicios ON usuarios_servicios.id = usuarios_servicios_sub.id_usuarios_servicios"
                                + " WHERE usuarios_servicios.id = @idUsuarioServicio";
                oCon.CrearComando(comando);
                oCon.AsignarParametroEntero("@idUsuarioServicio", id_usuario_servicio);
                oCon.ComenzarTransaccion();
                dtIpFija = oCon.Tabla();
                oCon.ConfirmarTransaccion();
                oCon.DesConectar();
            }
            catch (Exception)
            {
                oCon.CancelarTransaccion();
                oCon.DesConectar();
                throw;
            }

            if (dtIpFija.Rows.Count == 0)
                ipFija = 0;
            else
                ipFija = Convert.ToInt32(dtIpFija.Rows[0][0]);

            if (ipFija > 0)
                return Convert.ToInt32(CONDICION_IP_FIJA.ASIGNADA);
            else if (ipFija == -1)
                return Convert.ToInt32(CONDICION_IP_FIJA.PENDIENTE_DE_ASIGNACION);
            else
                return Convert.ToInt32(CONDICION_IP_FIJA.NO_NECESITA);
        }
    }
}
