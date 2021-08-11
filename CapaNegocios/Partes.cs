using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CapaNegocios
{
    public class Partes
    {
        #region [PROPIEDADES]
        public Int32 Id { get; set; }
        public Int32 Id_Usuarios { get; set; }
        public Int32 Id_Usuarios_Servicios { get; set; }
        public Int32 Id_Servicios { get; set; }
        public Int32 Id_Servicios_Tipos { get; set; }
        public Int32 Id_Servicios_Grupos { get; set; }

        public Int32 Id_Usuarios_Locaciones { get; set; }
        public Int32 Id_Zonas { get; set; }
        public Int32 Id_Partes_Fallas { get; set; }
        public Int32 Id_Partes_Soluciones { get; set; }
        public Int32 Id_Movil { get; set; }
        public Int32 Id_Tecnico { get; set; }
        public Int32 Id_Partes_Estados { get; set; }
        public Int32 Id_Operadores { get; set; }
        public Int32 Id_Areas { get; set; }
        public DateTime Fecha_Reclamo { get; set; }
        public DateTime Fecha_Realizado { get; set; }
        public DateTime Fecha_Movil { get; set; }
        public DateTime Fecha_Recibido { get; set; }
        public DateTime Fecha_Programado { get; set; }
        public String Detalle_Falla { get; set; }
        public String Detalle_Solucion { get; set; }
        public String Usuario { get; set; }
        public String Servicio { get; set; }
        public String Direccion { get; set; }
        public String Localidad { get; set; }
        public String Estado { get; set; }
        public Int32 Cantidad { get; set; }
        public String Telefono { get; set; }
        public String Piso { get; set; }
        public String Depto { get; set; }
        public String Entre_Calle_1 { get; set; }
        public String Entre_Calle_2 { get; set; }
        public String Observacion { get; set; }
        public String Area { get; set; }
        public Int32 Manzana { get; set; }
        public Int32 Id_Locacion_Anterior { get; set; }
        public Int32 Fecha_tipo { get; set; }
        public Int32 Traspasa { get; set; }
        public Int32 Id_Comprobantes { get; set; }
        public Int32 Id_Usuarios_Cuenta_Corriente { get; set; }

        public Int32 Operaciones_Id;
        public Int32 Operacion_ParteFallas;
        public Int32 Opercion_ParteTrabajo;
        public Int32 Operacion_conCargo;
        public String Operacion_Nombre;
        public Int32 IdAppExterna { get; set; }



        public DataTable DtPartes;
        public Configuracion oConfiguracion = new Configuracion();
        private Conexion oCon = new Conexion();

        private Partes_Usuarios_Servicios oParteUsuariosServicios = new Partes_Usuarios_Servicios();
        private Usuarios_Servicios oUsuarioServicio = new Usuarios_Servicios();
        private Isp oIsp = new Isp();
        Aplicaciones_Externas oAppExterna = new Aplicaciones_Externas();
        GPS oGps = new GPS();

        public enum Partes_Estados
        {
            PENDIENTE_DE_ASIGNACION_DE_EQUIPO = 1,
            PENDIENTE_DE_ASIGNACION_DE_TECNICO = 2,
            ASIGNADO = 3,
            EN_TRATAMIENTO = 4,
            REALIZADO = 5,
            DERIVADO = 6,
            TODOS = 7,
            ANULADO = 8,
            PENDIENTE_DE_ASIGNACION_DE_TARJETA = 10
        }

        public enum Partes_Operaciones
        {
            CONEXION = 1,
            RECONEXION = 2,
            CORTE = 3,
            BAJA = 4,
            PARTE_DE_TRABAJO = 5,
            CAMBIO_DE_EQUIPO = 6,
            CAMBIO_DE_DOMICILIO = 7,
            FACTIBILIDAD = 8,
            ASIGNACION_DE_EQUIPO = 9,
            PARTE_INTERNO = 10,
            PARTE_PROGRAMADO = 11,
            INFRAESTRUCTURA = 12,
            ALTA_IP = 13,
            CAMBIO_TECNOLOGIA = 14,
            BAJA_IP = 15,
            CAMBIO_BOCAS = 16,
            AGREGAR_SUBSERVICIO = 17,
            QUITAR_SUBSERVICIO = 18,
            ASIGNACION_DE_TARJETA = 19,
            BAJA_DE_DEBITO = 20,
            CAMBIO_DE_SERVICIO = 21,
            UNIFICACION_LOCACION=22,
            RECUPERACION_EQUIPO=23

        }

        public enum Tipo_Fecha
        {
            FECHA_RECLAMO = 1,
            FECHA_PROGRAMADO = 2,
            FECHA_RECIBIDO = 3,
            FECHA_REALIZADO = 4,
            FECHA_MOVIL = 5
        }

        public enum Traspaso
        {
            NADA = 0,
            PARTES = 1,
            CUENTA_CORRIENTE = 2,
            TODO = 3

        }

        public enum Origen
        {
            GIES = 1,
            GPS = 2
        }

        public enum TipoProblemas
        {
            DE_LA_EMPRESA = 1,
            DEL_USUARIO = 2,
            EXTERNO = 3,
            OTRO = 4
        }

        #endregion

        public Int32 SetearEstadoParte(int IdParte, int IdUsuariosServicios, int IdParteEstadoRecibido, DateTime FechaRealizado, int IdSolucionRealizado, int IdProblemaRealizado, string DetalleRealizado)
        {
            DataTable DtDatosDelParte = new DataTable();
            DataTable DtDatosUsuariosServicios = new DataTable();
            DataTable DtDatosPartesUsuariosServicios = new DataTable();
            DataTable DtPartesEquipos = new DataTable();
            int IdParteEstado = 0;
            int IdPartesOperaciones = 0;

            try
            {
                oCon.Conectar();
                if (IdParte == 0 && IdUsuariosServicios > 0 && IdParteEstadoRecibido > 0)
                {
                    oCon.CrearComando(String.Format("SELECT usuarios_servicios.id ,servicios.requiere_equipo from usuarios_servicios left join servicios on servicios.id=usuarios_servicios.id_servicios WHERE servicios.id = {0}", IdUsuariosServicios));
                    DtDatosUsuariosServicios = oCon.Tabla();
                    if (DtDatosUsuariosServicios.Rows[0]["requiere_equipo"].ToString() == "SI")
                    {
                        oCon.CrearComando(String.Format("SELECT * from partes_equipos WHERE id_partes = {0} and borrado!=1", IdParte));
                        DtPartesEquipos = oCon.Tabla();
                    }

                    if (IdParteEstadoRecibido == Convert.ToInt32(Partes.Partes_Estados.PENDIENTE_DE_ASIGNACION_DE_TECNICO))
                        IdParteEstado = IdParteEstadoRecibido;
                    else if (IdParteEstadoRecibido == Convert.ToInt32(Partes.Partes_Estados.PENDIENTE_DE_ASIGNACION_DE_EQUIPO))
                    {
                        if (DtPartesEquipos.Rows.Count > 0)
                            IdParteEstado = IdParteEstadoRecibido;
                        else
                            IdParteEstado = Convert.ToInt32(Partes.Partes_Estados.PENDIENTE_DE_ASIGNACION_DE_TECNICO);
                    }
                }
                else if (IdParte > 0 && IdUsuariosServicios == 0 && IdParteEstadoRecibido == 0)
                {
                    oCon.CrearComando(String.Format("CALL spPartes({0});", IdParte));// trae datos del parte
                    DtDatosDelParte = oCon.Tabla();

                    oCon.CrearComando(String.Format("SELECT partes_usuarios_servicios.*, servicios.requiere_equipo, servicios.requiere_tarjeta" +
                                     " from partes_usuarios_servicios left join usuarios_servicios on partes_usuarios_servicios.id_usuarios_servicios = usuarios_servicios.id" +
                                     " left join servicios on usuarios_servicios.id_servicios = servicios.id where id_parte = {0} and partes_usuarios_servicios.borrado = 0", IdParte)); // trae datos de la tabla partes_usuarios_servicios que pertenecen al parte
                    DtDatosPartesUsuariosServicios = oCon.Tabla();

                    oCon.CrearComando(String.Format("SELECT * from partes_equipos WHERE id_partes = {0} and borrado!=1", IdParte)); //traer todos los partes_equipos asociados al parte
                    DtPartesEquipos = oCon.Tabla();

                    if (Convert.ToInt32(DtDatosDelParte.Rows[0]["id_tecnicos"]) == 0)
                        IdParteEstado = Convert.ToInt32(Partes.Partes_Estados.PENDIENTE_DE_ASIGNACION_DE_TECNICO);
                    else
                    {
                        IdPartesOperaciones = Convert.ToInt32(DtDatosDelParte.Rows[0]["id_partes_operaciones"]);
                        if (IdPartesOperaciones == Convert.ToInt32(Partes.Partes_Operaciones.CONEXION) || IdPartesOperaciones == Convert.ToInt32(Partes.Partes_Operaciones.CAMBIO_DE_EQUIPO) || IdPartesOperaciones == Convert.ToInt32(Partes.Partes_Operaciones.ASIGNACION_DE_EQUIPO) || IdPartesOperaciones == Convert.ToInt32(Partes.Partes_Operaciones.ASIGNACION_DE_TARJETA))
                        {
                            DataRow[] drPartesEquiposConEquipos;
                            DataRow[] drPartesEquiposConEquiposYTarjetas;

                            foreach (DataRow parteUsuarioServicio in DtDatosPartesUsuariosServicios.Rows)
                            {
                                drPartesEquiposConEquipos = null;
                                drPartesEquiposConEquiposYTarjetas = null;
                                if (parteUsuarioServicio["requiere_equipo"].ToString() == "SI")
                                {
                                    drPartesEquiposConEquipos = DtPartesEquipos.Select(String.Format("id_usuarios_servicios={0} and id_equipos>0", Convert.ToInt32(parteUsuarioServicio["id_usuarios_servicios"])));
                                    drPartesEquiposConEquiposYTarjetas = DtPartesEquipos.Select(String.Format("id_usuarios_servicios={0} and id_equipos>0 and id_tarjeta>0", Convert.ToInt32(parteUsuarioServicio["id_usuarios_servicios"])));

                                    if (DtPartesEquipos.Select(String.Format("id_usuarios_servicios={0}", Convert.ToInt32(parteUsuarioServicio["id_usuarios_servicios"]))).Count() > 0)
                                    {


                                        if (drPartesEquiposConEquipos.Count() == DtPartesEquipos.Select(String.Format("id_usuarios_servicios={0}", Convert.ToInt32(parteUsuarioServicio["id_usuarios_servicios"]))).Count())
                                        {
                                            if (parteUsuarioServicio["requiere_tarjeta"].ToString() == "SI")
                                            {
                                                if (drPartesEquiposConEquiposYTarjetas.Count() == drPartesEquiposConEquipos.Count())
                                                    IdParteEstado = Convert.ToInt32(Partes.Partes_Estados.ASIGNADO);
                                                else
                                                {
                                                    IdParteEstado = Convert.ToInt32(Partes.Partes_Estados.PENDIENTE_DE_ASIGNACION_DE_TARJETA);
                                                    break;
                                                }
                                            }
                                            else
                                                IdParteEstado = Convert.ToInt32(Partes.Partes_Estados.ASIGNADO);
                                        }
                                        else
                                        {
                                            IdParteEstado = Convert.ToInt32(Partes.Partes_Estados.PENDIENTE_DE_ASIGNACION_DE_EQUIPO);
                                            break;
                                        }
                                    }
                                    else
                                    {
                                        IdParteEstado = Convert.ToInt32(Partes.Partes_Estados.PENDIENTE_DE_ASIGNACION_DE_EQUIPO);
                                        break;
                                    }
                                }
                                else
                                    IdParteEstado = Convert.ToInt32(Partes.Partes_Estados.ASIGNADO);
                            }
                        }
                        else
                            IdParteEstado = Convert.ToInt32(Partes.Partes_Estados.ASIGNADO);
                    }
                    oCon.CrearComando("UPDATE partes SET Id_Partes_Estados=@IdPartesEstados WHERE id=@id");
                    oCon.AsignarParametroEntero("@IdPartesEstados", IdParteEstado);
                    oCon.AsignarParametroEntero("@id", IdParte);
                    oCon.ComenzarTransaccion();
                    oCon.EjecutarComando();
                    oCon.ConfirmarTransaccion();
                }
                else if (IdParte > 0 && IdUsuariosServicios == 0 && IdParteEstadoRecibido > 0)
                {
                    IdParteEstado = IdParteEstadoRecibido;
                    if (IdParteEstadoRecibido == Convert.ToInt32(Partes.Partes_Estados.REALIZADO))
                    {
                        oCon.CrearComando("UPDATE partes SET Id_Partes_Estados=@id_parte_estado, fecha_realizado=@fecRealizado, Id_Partes_Soluciones=@partes_solucion, Detalle_Solucion=@detalle, Id_Tipo_Problema=@tipo_problema WHERE id=@id");

                        oCon.AsignarParametroEntero("@id_parte_estado", IdParteEstado);
                        oCon.AsignarParametroFecha("@fecRealizado", FechaRealizado);
                        oCon.AsignarParametroEntero("@partes_solucion", IdSolucionRealizado);
                        oCon.AsignarParametroCadena("@detalle", DetalleRealizado);
                        oCon.AsignarParametroEntero("@tipo_problema", IdProblemaRealizado);
                        oCon.AsignarParametroEntero("@id", IdParte);
                        oCon.ComenzarTransaccion();
                        oCon.EjecutarComando();
                        oCon.ConfirmarTransaccion();
                    }
                    else if (IdParteEstadoRecibido != Convert.ToInt32(Partes.Partes_Estados.REALIZADO))
                    {
                        oCon.CrearComando("UPDATE partes SET Id_Partes_Estados=@IdPartesEstados WHERE id=@id");
                        oCon.AsignarParametroEntero("@IdPartesEstados", IdParteEstado);
                        oCon.AsignarParametroEntero("@id", IdParte);
                        oCon.ComenzarTransaccion();
                        oCon.EjecutarComando();
                        oCon.ConfirmarTransaccion();
                    }
                    else
                        IdParteEstado = Convert.ToInt32(Partes.Partes_Estados.PENDIENTE_DE_ASIGNACION_DE_TECNICO);
                }
                else
                    IdParteEstado = Convert.ToInt32(Partes.Partes_Estados.PENDIENTE_DE_ASIGNACION_DE_TECNICO);
                oCon.DesConectar();
            }
            catch (Exception)
            {
                oCon.CancelarTransaccion();
                oCon.DesConectar();
                IdParteEstado = Convert.ToInt32(Partes.Partes_Estados.PENDIENTE_DE_ASIGNACION_DE_TECNICO);
                throw;
            }
            return IdParteEstado;
            //081019fede
        }

        public Int32 Guardar(Partes oParte, int GuardaParteUsuarios, int id_servicio_sub = 0)
        {
            int GuardarParteUsuarioServicio = GuardaParteUsuarios;
            try
            {
                oCon.Conectar();
                oCon.CrearComando("INSERT INTO Partes(Id_Usuarios, Id_Servicios, Id_Usuarios_Servicios, Id_Usuarios_Locaciones, Id_Zonas, Id_Partes_Fallas, Id_Partes_Soluciones,Id_Moviles,Id_Tecnicos, Id_Partes_Estados, Id_Operadores, Id_Areas, Fecha_Reclamo, Fecha_Realizado, Fecha_Movil, Fecha_Recibido,Fecha_Programado,Detalle_Falla, Detalle_Solucion, Id_Locacion_Anterior, Id_Comprobantes,traspasa,id_usuarios_ctacte) " +
                    "VALUES(  @usuario, @servicio, @serid, @locacion, @zona, @falla, @solucion, @movil,@tecnico, @estado, @operador, @area, @fecha_reclamo, @fecha_realizado, @fecha_movil,@fecha_recibido,@fecha_programado, @detalle_falla, @detalle_solucion, @id_locacion_anterior, @id_comp,@traspasa,@idCtaCte); SELECT @@IDENTITY");
                oCon.AsignarParametroEntero("@usuario", oParte.Id_Usuarios);
                oCon.AsignarParametroEntero("@servicio", oParte.Id_Servicios);
                oCon.AsignarParametroEntero("@serid", oParte.Id_Usuarios_Servicios);
                oCon.AsignarParametroEntero("@locacion", oParte.Id_Usuarios_Locaciones);
                oCon.AsignarParametroEntero("@zona", oParte.Id_Zonas);
                oCon.AsignarParametroEntero("@falla", oParte.Id_Partes_Fallas);
                oCon.AsignarParametroEntero("@solucion", oParte.Id_Partes_Soluciones);
                oCon.AsignarParametroEntero("@movil", oParte.Id_Movil);
                oCon.AsignarParametroEntero("@tecnico", oParte.Id_Tecnico);
                oCon.AsignarParametroEntero("@estado", oParte.Id_Partes_Estados);
                oCon.AsignarParametroEntero("@operador", oParte.Id_Operadores);
                oCon.AsignarParametroEntero("@area", oParte.Id_Areas);
                oCon.AsignarParametroFecha("@fecha_reclamo", oParte.Fecha_Reclamo);
                oCon.AsignarParametroFecha("@fecha_realizado", oParte.Fecha_Realizado.Date);
                oCon.AsignarParametroFecha("@fecha_movil", oParte.Fecha_Movil.Date);
                oCon.AsignarParametroFecha("@fecha_recibido", oParte.Fecha_Recibido.Date);
                oCon.AsignarParametroFecha("@fecha_programado", oParte.Fecha_Programado);
                oCon.AsignarParametroCadena("@detalle_falla", oParte.Detalle_Falla);
                oCon.AsignarParametroCadena("@detalle_solucion", oParte.Detalle_Solucion);
                oCon.AsignarParametroEntero("@id_locacion_anterior", oParte.Id_Locacion_Anterior);
                oCon.AsignarParametroEntero("@id_comp", oParte.Id_Comprobantes);
                oCon.AsignarParametroEntero("@traspasa", oParte.Traspasa);
                oCon.AsignarParametroEntero("@idCtaCte", oParte.Id_Usuarios_Cuenta_Corriente); 
                oCon.ComenzarTransaccion();
                oParte.Id = oCon.EjecutarScalar();
                oCon.ConfirmarTransaccion();
                oCon.DesConectar();


                if (GuardarParteUsuarioServicio == 1)
                {
                    oParteUsuariosServicios.Id_Parte = oParte.Id;
                    oParteUsuariosServicios.Id_Servicio = oParte.Id_Servicios;
                    oParteUsuariosServicios.Id_Usuario_Servicio = oParte.Id_Usuarios_Servicios;
                    oParteUsuariosServicios.idParteFalla = oParte.Id_Partes_Fallas;
                    oParteUsuariosServicios.idAppExterna = oParte.IdAppExterna;
                    oParteUsuariosServicios.id_usuarios_servicios_sub = id_servicio_sub;
                    oParteUsuariosServicios.Guardar(oParteUsuariosServicios);
                }
            }
            catch (Exception)
            {
                oCon.CancelarTransaccion();
                oCon.DesConectar();
                throw;
            }

            return oParte.Id;
        }

        public void AsignarTecnico(int id, int tecnico, int id_estado)
        {
            try
            {
                oCon.Conectar();
                oCon.CrearComando("UPDATE partes SET Id_Partes_Estados=@id_estado,id_Tecnicos=@tecnico WHERE id=@id");
                oCon.AsignarParametroEntero("@id_estado", id_estado);
                oCon.AsignarParametroEntero("@id", id);
                oCon.AsignarParametroEntero("@tecnico", tecnico);
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

        public void ActualizarFechaProgramado(int id_parte, DateTime fecha_nueva)
        {
            try
            {
                oCon.Conectar();
                oCon.CrearComando("UPDATE partes SET Fecha_Programado=@fecha_programado WHERE id=@id_parte");
                oCon.AsignarParametroFecha("@fecha_programado", fecha_nueva);
                oCon.AsignarParametroEntero("@id_parte", id_parte);

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

        public bool ContarPartesPorEstado(Int32 idUsuario, Int32 idEstado, int idEstado2)
        {
            Boolean Variable = false;
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                oCon.CrearComando("select count(id)  as cantidad from partes where id_usuarios =@idusu and id_partes_estados<>@idest and id_partes_estados<>@idest2");
                oCon.AsignarParametroEntero("@idusu", idUsuario);
                oCon.AsignarParametroEntero("@idest", idEstado);
                oCon.AsignarParametroEntero("@idest2", idEstado2);
                dt = oCon.Tabla();
                oCon.DesConectar();
                if (Convert.ToInt32(dt.Rows[0]["cantidad"].ToString()) > 0)
                    Variable = true;
            }
            catch (Exception)
            {
                oCon.CancelarTransaccion();
                oCon.DesConectar();
                throw;
            }
            return Variable;
            /*180919-10:37
            líneas modificadas: 413,416
            */
        }

        public void Guardar_Operacion(Partes oOperaciones)
        {
            try
            {
                oCon.Conectar();
                if (oOperaciones.Operaciones_Id > 0)
                {
                    oCon.CrearComando("UPDATE partes_operaciones set nombre=@nombre,parte_fallas=@parte_fallas,concargo=@concargo,partetrabajo=@partetrabajo WHERE id=@id");
                    oCon.AsignarParametroEntero("@id", oOperaciones.Operaciones_Id);
                }
                else
                {
                    oCon.CrearComando("INSERT INTO partes_operaciones (nombre,Parte_Fallas,conCargo,ParteTrabajo) VALUES (@nombre,@parte_fallas,@concargo,@partetrabajo)");
                }
                oCon.AsignarParametroCadena("@nombre", oOperaciones.Operacion_Nombre);
                oCon.AsignarParametroEntero("@parte_fallas", oOperaciones.Operacion_ParteFallas);
                oCon.AsignarParametroEntero("@concargo", oOperaciones.Operacion_conCargo);
                oCon.AsignarParametroEntero("@partetrabajo", oOperaciones.Opercion_ParteTrabajo);
                oCon.EjecutarComando();
                oCon.DesConectar();
            }
            catch (Exception)
            {
                oCon.DesConectar();
                throw;
            }
        }

        public void Eliminar_Operacion(int id)
        {
            try
            {
                oCon.Conectar();
                oCon.CrearComando("UPDATE partes_operaciones SET borrado=1 WHERE id=@id");
                oCon.AsignarParametroEntero("@id", id);
                oCon.EjecutarComando();
                oCon.DesConectar();
            }
            catch (Exception)
            {
                oCon.DesConectar();
                throw;
            }

        }

        public void AnularParte(int id)
        {
            try
            {
                oCon.Conectar();
                oCon.CrearComando("UPDATE partes SET Id_Partes_Estados=@estado , borrado=1 WHERE id=@id");
                oCon.AsignarParametroEntero("@estado", Convert.ToInt32(Partes.Partes_Estados.ANULADO));
                oCon.AsignarParametroEntero("@id", id);
                oCon.ComenzarTransaccion();
                oCon.EjecutarComando();
                oCon.ConfirmarTransaccion();
                oCon.DesConectar();

                if(Convert.ToInt32(oConfiguracion.GetValor_N("ParteTrabajaAppExterna")) == 1)
                {
                    oGps.AnularParte(id);
                }
            }
            catch (Exception)
            {
                oCon.CancelarTransaccion();
                oCon.DesConectar();
                throw;
            }
        }

        public void ParteRealizado(int id, DateTime fecha_Realizado, int id_solucion, int id_problema, string detalle)
        {
            try
            {
                oCon.Conectar();
                oCon.CrearComando("UPDATE partes SET Id_Partes_Estados=5, fecha_realizado=@fecRealizado, Id_Partes_Soluciones=@partes_solucion, Detalle_Solucion=@detalle, Id_Tipo_Problema=@tipo_problema WHERE id=@id");
                oCon.AsignarParametroEntero("@id", id);
                oCon.AsignarParametroFecha("@fecRealizado", fecha_Realizado);
                oCon.AsignarParametroEntero("@partes_solucion", id_solucion);
                oCon.AsignarParametroCadena("@detalle", detalle);
                oCon.AsignarParametroEntero("@tipo_problema", id_problema);
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

        public void GenerarHistorialPartes(DataTable dtPartes)
        {
            Partes_Historial oPartesHistorial = new Partes_Historial();
            Usuarios_Servicios oUsuariosServicios = new Usuarios_Servicios();
            Servicios_Estados_Historial oServiciosEstadosHistorial = new Servicios_Estados_Historial();
            if (dtPartes.Rows.Count > 0)
            {
                foreach (DataRow parte in dtPartes.Rows)
                {
                    oPartesHistorial.Id_Parte = Convert.ToInt32(parte["Id"]);
                    oPartesHistorial.Id_Usuarios = Convert.ToInt32(parte["Id_Usuarios"]);
                    oPartesHistorial.Id_Personal = Convert.ToInt32(parte["Id_Operadores"]);
                    oPartesHistorial.Fecha_Movimiento = DateTime.Now;
                    oPartesHistorial.Id_area = Convert.ToInt32(parte["Id_Areas"]);

                    int configAgenda = oConfiguracion.GetValor_N("Agenda_Trabajo");
                    if (configAgenda == Convert.ToInt32(Agenda_Encabezado.Uso_agenda.TRABAJA_CON_AGENDA))
                    {
                        if (Convert.ToInt32(parte["CorteAutomatico"]) == Convert.ToInt32(Servicios._CorteAutomatico.SI))
                        {
                            oPartesHistorial.Detalles = "PARTE PASADO A REALIZADO.";
                            oPartesHistorial.Id_Partes_Estados = Convert.ToInt32(Partes.Partes_Estados.REALIZADO);
                        }
                        else
                        {
                            oPartesHistorial.Detalles = "PENDIENTE DE ASIGNACIÓN DE TÉCNICO.";
                            oPartesHistorial.Id_Partes_Estados = Convert.ToInt32(Partes.Partes_Estados.PENDIENTE_DE_ASIGNACION_DE_TECNICO);
                        }
                        oPartesHistorial.GuardarNuevoDetalle(oPartesHistorial);

                        if (Convert.ToInt32(parte["CorteAutomatico"]) == Convert.ToInt32(Servicios._CorteAutomatico.SI))
                        {
                            oUsuariosServicios.ActualizarEstado(Convert.ToInt32(parte["id_usuarios_servicios"].ToString()), Convert.ToInt32(Servicios.Servicios_Estados.CORTADO));
                            oServiciosEstadosHistorial.id_servicios_estados = Convert.ToInt32(Servicios.Servicios_Estados.CORTADO);
                            oServiciosEstadosHistorial.id_servicios = Convert.ToInt32(parte["id_servicios"]);
                            oServiciosEstadosHistorial.id_usuarios = Convert.ToInt32(parte["Id_usuarios"]);
                            oServiciosEstadosHistorial.id_usuarios_servicios = Convert.ToInt32(parte["id_usuarios_servicios"]);
                            oServiciosEstadosHistorial.fecha = DateTime.Now;
                            oServiciosEstadosHistorial.Guardar(oServiciosEstadosHistorial);
                        }
                        oUsuariosServicios.Actualizar_avisos(2, 1, Convert.ToInt32(parte["id_usuarios_servicios"].ToString()));
                    }
                    else
                    {
                        oPartesHistorial.Detalles = "PENDIENTE DE ASIGNACIÓN DE TÉCNICO.";
                        oPartesHistorial.Id_Partes_Estados = Convert.ToInt32(Partes.Partes_Estados.PENDIENTE_DE_ASIGNACION_DE_TECNICO);

                        oPartesHistorial.GuardarNuevoDetalle(oPartesHistorial);


                        oUsuariosServicios.Actualizar_avisos(2, 1, Convert.ToInt32(parte["id_usuarios_servicios"].ToString()));
                    }
                }
            }
        }

        public void Impreso(Int32 IdParte, Boolean Error = false)
        {

            try
            {
                oCon.Conectar();

                if (Error)
                    oCon.CrearComando("UPDATE partes SET Impreso=0 WHERE id=@id");
                else
                    oCon.CrearComando("UPDATE partes SET Impreso=1 WHERE id=@id");

                oCon.AsignarParametroEntero("@id", IdParte);
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

        public DataTable Get_Estructura_Partes()
        {
            DataTable dt = new DataTable();
            DataColumn clmId = new DataColumn
            {
                ColumnName = "Id",
                DataType = typeof(Int32),
                DefaultValue = 0
            };
            DataColumn clmIdUsuarios = new DataColumn
            {
                ColumnName = "Id_Usuarios",
                DataType = typeof(Int32),
                DefaultValue = 0
            };
            DataColumn clmIdUsuariosServicios = new DataColumn
            {
                ColumnName = "Id_Usuarios_Servicios",
                DataType = typeof(Int32),
                DefaultValue = 0
            };

            DataColumn clmIdServicios = new DataColumn
            {
                ColumnName = "Id_Servicios",
                DataType = typeof(Int32),
                DefaultValue = 0
            };

            DataColumn clmIdServiciosTipos = new DataColumn
            {
                ColumnName = "Id_Servicios_Tipos",
                DataType = typeof(Int32),
                DefaultValue = 0
            };

            DataColumn clmIdServiciosGrupos = new DataColumn
            {
                ColumnName = "Id_Servicios_Grupos",
                DataType = typeof(Int32),
                DefaultValue = 0
            };
            DataColumn clmIdUsuariosLocaciones = new DataColumn
            {
                ColumnName = "Id_Usuarios_Locaciones",
                DataType = typeof(Int32),
                DefaultValue = 0
            };
            DataColumn clmIdZonas = new DataColumn
            {
                ColumnName = "Id_Zonas",
                DataType = typeof(Int32),
                DefaultValue = 0
            };
            DataColumn clmIdPartesFallas = new DataColumn
            {
                ColumnName = "Id_Partes_Fallas",
                DataType = typeof(Int32),
                DefaultValue = 0
            };
            DataColumn clmIdPartesSoluciones = new DataColumn
            {
                ColumnName = "Id_Partes_Soluciones",
                DataType = typeof(Int32),
                DefaultValue = 0
            };

            DataColumn clmIdMovil = new DataColumn
            {
                ColumnName = "Id_Movil",
                DataType = typeof(Int32),
                DefaultValue = 0
            };
            DataColumn clmIdTecnico = new DataColumn
            {
                ColumnName = "Id_Tecnico",
                DataType = typeof(Int32),
                DefaultValue = 0
            };


            DataColumn clmIdPartesEstados = new DataColumn
            {
                ColumnName = "Id_Partes_Estados",
                DataType = typeof(Int32),
                DefaultValue = 0
            };
            DataColumn clmIdOperadores = new DataColumn
            {
                ColumnName = "Id_Operadores",
                DataType = typeof(Int32),
                DefaultValue = 0
            };

            DataColumn clmIdAreas = new DataColumn
            {
                ColumnName = "Id_Areas",
                DataType = typeof(Int32),
                DefaultValue = 0
            };


            DataColumn clmIdLocacionAnterior = new DataColumn
            {
                ColumnName = "Id_Locacion_Anterior",
                DataType = typeof(Int32),
                DefaultValue = 0
            };
            DataColumn clmFechatipo = new DataColumn
            {
                ColumnName = "Fecha_tipo",
                DataType = typeof(Int32),
                DefaultValue = 0
            };
            DataColumn clmIdComprobantes = new DataColumn
            {
                ColumnName = "Id_Comprobantes",
                DataType = typeof(Int32),
                DefaultValue = 0
            };
            DataColumn clmFechaReclamo = new DataColumn
            {
                ColumnName = "Fecha_Reclamo",
                DataType = typeof(DateTime),
                DefaultValue = new DateTime(0001, 01, 01)
            };
            DataColumn clmFechaMovil = new DataColumn
            {
                ColumnName = "Fecha_Movil",
                DataType = typeof(DateTime),
                DefaultValue = new DateTime(0001, 01, 01)
            };
            DataColumn clmFechaRecibido = new DataColumn
            {
                ColumnName = "Fecha_Recibido",
                DataType = typeof(DateTime),
                DefaultValue = new DateTime(0001, 01, 01)
            };
            DataColumn clmFechaProgramado = new DataColumn
            {
                ColumnName = "Fecha_Programado",
                DataType = typeof(DateTime),
                DefaultValue = new DateTime(0001, 01, 01)
            };
            DataColumn clmDetalleFalla = new DataColumn
            {
                ColumnName = "Detalle_Falla",
                DataType = typeof(string),
                DefaultValue = 0
            };
            DataColumn clmDetalleSolucion = new DataColumn
            {
                ColumnName = "Detalle_Solucion",
                DataType = typeof(string),
                DefaultValue = 0
            };

            DataColumn clmIdTipos = new DataColumn
            {
                ColumnName = "Tipo",
                DataType = typeof(String),
                DefaultValue = string.Empty
            };

            DataColumn clmIdTipoEquipo = new DataColumn
            {
                ColumnName = "IdTipoEquipo",
                DataType = typeof(Int32),
                DefaultValue = 0
            };

            DataColumn clmCorteAutomatico = new DataColumn
            {
                ColumnName = "CorteAutomatico",
                DataType = typeof(Int32),
                DefaultValue = 0
            };

            DataColumn clmFechaRealizado = new DataColumn
            {
                ColumnName = "Fecha_Realizado",
                DataType = typeof(DateTime),
                DefaultValue = new DateTime(0001, 01, 01)
            };
            DataColumn clmTraspasa = new DataColumn
            {
                ColumnName = "traspasa",
                DataType = typeof(Int32),
                DefaultValue = 0
            };
            DataColumn clmIdAppExterna= new DataColumn
            {
                ColumnName = "id_aplicacion_externa",
                DataType = typeof(Int32),
                DefaultValue = 0
            };

            dt.Columns.Add(clmId);
            dt.Columns.Add(clmIdUsuarios);
            dt.Columns.Add(clmIdUsuariosServicios);
            dt.Columns.Add(clmIdServicios);
            dt.Columns.Add(clmIdServiciosTipos);
            dt.Columns.Add(clmIdServiciosGrupos);
            dt.Columns.Add(clmIdUsuariosLocaciones);
            dt.Columns.Add(clmIdZonas);
            dt.Columns.Add(clmIdPartesFallas);
            dt.Columns.Add(clmIdPartesSoluciones);
            dt.Columns.Add(clmIdMovil);
            dt.Columns.Add(clmIdTecnico);
            dt.Columns.Add(clmIdPartesEstados);
            dt.Columns.Add(clmIdOperadores);
            dt.Columns.Add(clmIdAreas);
            dt.Columns.Add(clmIdLocacionAnterior);
            dt.Columns.Add(clmFechatipo);
            dt.Columns.Add(clmIdComprobantes);

            dt.Columns.Add(clmFechaReclamo);
            dt.Columns.Add(clmFechaMovil);
            dt.Columns.Add(clmFechaRecibido);
            dt.Columns.Add(clmFechaProgramado);

            dt.Columns.Add(clmDetalleFalla);
            dt.Columns.Add(clmDetalleSolucion);


            dt.Columns.Add(clmIdTipos);
            dt.Columns.Add(clmIdTipoEquipo);
            dt.Columns.Add(clmCorteAutomatico);
            dt.Columns.Add(clmFechaRealizado);
            dt.Columns.Add(clmTraspasa);
            dt.Columns.Add(clmIdAppExterna);

            return dt;
        }

        public DataTable ListarOperaciones(bool conTodas = false)
        {
            DataTable dt = new DataTable();

            try
            {
                oCon.Conectar();
                if (conTodas)
                    oCon.CrearComando("SELECT 0 as Id, UPPER('TODAS') as Nombre UNION ALL SELECT Id, Nombre FROM Partes_Operaciones ORDER BY Id");
                else
                    oCon.CrearComando("SELECT * FROM Partes_Operaciones ORDER BY Id");

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

        public DataRow TraerParteRow(Int32 Id)
        {
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                oCon.CrearComando(String.Format("CALL spPartes({0});", Id));

                dt = oCon.Tabla();

                oCon.DesConectar();
            }
            catch (Exception)
            {

                oCon.DesConectar();
                throw;
            }

            if (dt.Rows.Count > 0)
                return dt.Rows[0];
            else
                return null;
        }

        public DataTable Listar(Partes_Estados oEstado)
        {
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                oCon.CrearComando("SELECT partes.id,partes.Id_Usuarios_Locaciones,partes.Id_Partes_Soluciones,partes.id_zonas,partes_usuarios_servicios.id_parte_falla as Id_Partes_Fallas,servicios.Descripcion as Servicio, partes_fallas.Nombre as Falla, partes.fecha_Reclamo as Fecha, partes_estados.Nombre as Estado, CONCAT(usuarios.nombre, ' ', usuarios.apellido) as Usuario, CONCAT(usuarios_locaciones.Calle, ' ', CONVERT(usuarios_locaciones.Altura, char(10))) as Direccion, usuarios_locaciones.piso, usuarios_locaciones.Depto, usuarios_locaciones.Manzana,localidades.Nombre as Localidad,"
                + " partes_usuarios_servicios.id_usuarios_servicios, partes.id_usuarios, COUNT(partes_equipos.Id) as cantidad, partes_usuarios_servicios.Id_servicio AS id_servicios, servicios.Id_Servicios_Tipos, partes.id_usuarios_locaciones as id_locacion, usuarios_locaciones.Telefono_1 as telefono,"
                + " usuarios_locaciones.Entre_Calle_1, usuarios_locaciones.Entre_Calle_2, usuarios_locaciones.Observacion, personal.Nombre as Tecnico, partes.id_partes_estados, partes.Detalle_Solucion, servicios_tipos.Nombre as tiposervicio, partes_fallas.Id_Partes_Operaciones"
                + " from partes_usuarios_servicios"
                + " LEFT JOIN partes ON partes.Id = partes_usuarios_servicios.Id_parte"
                + " LEFT JOIN servicios ON servicios.id = partes_usuarios_servicios.Id_servicio"
                + " LEFT JOIN partes_fallas ON partes_fallas.id = partes_usuarios_servicios.id_parte_falla"
                + " LEFT JOIN partes_estados ON partes_estados.id = partes.Id_Partes_Estados"
                + " LEFT JOIN usuarios ON usuarios.id = partes.Id_Usuarios"
                + " LEFT JOIN usuarios_locaciones ON usuarios_locaciones.id = partes.Id_Usuarios_Locaciones"
                + " LEFT JOIN localidades ON localidades.id = usuarios_locaciones.Id_Localidades"
                + " LEFT JOIN servicios_Tipos ON servicios_Tipos.id = partes_usuarios_servicios.id_servicio_tipo"
                + " LEFT JOIN personal ON personal.id = partes.Id_Operadores"
                + " LEFT JOIN partes_equipos ON partes_equipos.Id_Partes = partes.Id_Partes_Estados"
                + " WHERE partes.id_partes_estados = @estado GROUP BY partes_usuarios_servicios.Id");
                oCon.AsignarParametroEntero("@estado", (Int32)oEstado);
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

        public DataTable TraerPartesUsuario(Int32 IdUsuario)
        {
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();

                oCon.CrearComando(String.Format("SELECT partes.Id AS id, partes.Fecha_Reclamo AS fecha_reclamo, partes.Fecha_Programado AS fecha_programado, partes.Fecha_Realizado AS fecha_realizado, " +
                   "partes.Fecha_Movil AS fecha_movil, partes.Fecha_Recibido AS fecha_recibido, partes.Detalle_Falla AS detalle_falla, partes.Detalle_Solucion AS detalle_solucion, " +
                   "usuarios.Codigo AS codigo_usuario, CONCAT_WS(',', usuarios.Nombre, usuarios.Apellido) AS usuario, usuarios.Nombre AS nombre, usuarios.Apellido AS apellido, servicios.Descripcion AS servicio, servicios.Requiere_Equipo AS requiere_equipo, " +
                   "servicios.Requiere_Tarjeta AS requiere_tarjeta, servicios_tipos.Nombre AS servicio_tipo, servicios_grupos.Nombre AS servicio_grupo, localidades_calles.Nombre AS calle, " +
                   "usuarios_locaciones.Altura AS altura, usuarios_locaciones.Piso AS piso, usuarios_locaciones.Depto AS depto, usuarios_locaciones.Manzana AS manzana, usuarios_locaciones.Parcela AS parcela, " +
                   "usuarios_locaciones.Id_Calle_Entre_1 AS id_calle_entre_1, usuarios_locaciones.Entre_Calle_1 AS entre_calle_1, usuarios_locaciones.Id_Calle_Entre_2 AS id_calle_entre_2, " +
                   "usuarios_locaciones.Entre_Calle_2 AS entre_calle_2, usuarios_locaciones.Observacion AS observacion, usuarios_locaciones.Id_Calle AS id_calle, usuarios_locaciones.Telefono_1 AS telefono_1, " +
                   "partes_fallas.Nombre AS solicitud, partes_soluciones.Nombre AS solucion, personal.Nombre AS tecnico, (SELECT personal.Nombre FROM personal WHERE(personal.Id = partes.Id_Operadores)) AS operador, " +
                   "moviles.nombre AS movil, personal_areas.Nombre AS area, localidades.Nombre AS localidad, partes_estados.Nombre AS estado, partes_operaciones.Nombre AS operacion, partes.Id_Usuarios AS id_usuarios, " +
                   "partes.Id_Servicios AS id_servicios, partes.Id_Usuarios_Locaciones AS id_usuarios_locaciones, partes.Id_Locacion_Anterior AS id_locacion_anterior, partes.Id_Zonas AS id_zonas, " +
                   "localidades.Id AS id_localidad, partes.Id_Partes_Fallas AS id_partes_fallas, partes.Id_Partes_Soluciones AS id_partes_soluciones, partes.Id_Tecnicos AS id_tecnicos, " +
                   "partes.Id_Moviles AS id_moviles, partes.Id_Partes_Estados AS id_partes_estados, partes.Id_Operadores AS id_operadores, partes.Id_Areas AS id_areas, " +
                   "partes.Id_Usuarios_Servicios AS id_usuarios_servicios, servicios.Id_Servicios_Tipos AS id_servicios_tipos, servicios_tipos.Id_Servicios_Grupos AS id_servicios_grupos, " +
                   "partes.Id_Tipo_Problema AS id_tipo_problema, partes_fallas.Id_Partes_Operaciones AS id_partes_operaciones, " +
                   "(SELECT COUNT(*) FROM partes_equipos WHERE partes_equipos.Id_Partes = partes.Id) AS total_equipos, " +
                   "partes_fallas.Codtra AS codtra, partes.NumOrd AS numord, partes.Impreso AS impreso, partes_usuarios_servicios.asignacion_ip_fija " +
                   "FROM partes_usuarios_servicios " +
                         "LEFT JOIN partes ON partes.Id = partes_usuarios_servicios.id_parte " +
                         "LEFT JOIN usuarios ON usuarios.Id = partes.Id_Usuarios " +
                         "LEFT JOIN servicios ON servicios.Id = partes_usuarios_servicios.Id_Servicio " +
                         "LEFT JOIN servicios_tipos ON servicios.Id_Servicios_Tipos = servicios_tipos.Id " +
                         "LEFT JOIN servicios_grupos ON servicios_grupos.Id = servicios_tipos.Id_Servicios_Grupos " +
                         "LEFT JOIN usuarios_locaciones ON usuarios_locaciones.Id = partes.Id_Usuarios_Locaciones " +
                         "LEFT JOIN zonas ON zonas.Id = partes.Id_Zonas " +
                         "LEFT JOIN partes_fallas ON partes_fallas.Id = partes.Id_Partes_Fallas " +
                         "LEFT JOIN partes_operaciones ON partes_operaciones.Id = partes_fallas.Id_Partes_Operaciones " +
                         "LEFT JOIN partes_soluciones ON partes_soluciones.Id = partes.Id_Partes_Soluciones " +
                         "LEFT JOIN personal ON personal.Id = partes.Id_Tecnicos " +
                         "LEFT JOIN personal_areas ON personal_areas.Id = partes.Id_Areas " +
                         "LEFT JOIN moviles ON moviles.id = partes.Id_Moviles " +
                         "LEFT JOIN partes_estados ON partes_estados.Id = partes.Id_Partes_Estados " +
                         "LEFT JOIN localidades ON localidades.Id = usuarios_locaciones.Id_Localidades " +
                         "LEFT JOIN localidades_calles ON localidades_calles.Id = usuarios_locaciones.Id_Calle WHERE partes.id_usuarios = {0} and partes.Id_Partes_Estados != 0 group by partes.id order by partes.id DESC", IdUsuario));



                dt = oCon.Tabla();
                oCon.DesConectar();
            }
            catch (Exception ex)
            {
                oCon.DesConectar();
                throw;
            }
            return dt;
        }

        public DataTable ListarPorRangoDeFechas(DateTime FechaDesde, DateTime FechaHasta, Tipo_Fecha TipoFecha, int idTipoServicio = 0, bool filtrarRealizadosYAnulados = false )
        {
            DataTable dt = new DataTable();
            StringBuilder consulta = new StringBuilder();
            string tipoFecha = "";
            if (TipoFecha == Tipo_Fecha.FECHA_RECLAMO)
                tipoFecha = "partes.fecha_reclamo";
            else if (TipoFecha == Tipo_Fecha.FECHA_REALIZADO)
                tipoFecha = "partes.fecha_realizado";
            else if (TipoFecha == Tipo_Fecha.FECHA_PROGRAMADO)
                tipoFecha = "partes.fecha_programado";
            else if (TipoFecha == Tipo_Fecha.FECHA_RECIBIDO)
                tipoFecha = "partes.fecha_recibido";
            else if (TipoFecha == Tipo_Fecha.FECHA_MOVIL)
                tipoFecha = "partes.fecha_movil";
            try
            {
                oCon.Conectar();
                consulta.Append("select partes.Id,partes.id_usuarios_locaciones,servicios.Descripcion as servicio,partes_fallas.Nombre as solicitud,partes_estados.Nombre as estado,usuarios.codigo as codigo_usuario, CONCAT(usuarios.apellido, ' ', usuarios.nombre) as usuario,usuarios_locaciones.Calle,usuarios_locaciones.altura,localidades.Nombre as localidad,personal.Nombre as operador,"
                 + " personal_areas.Nombre AS area, DATE(partes.fecha_reclamo) as fecha_reclamo, TIME(partes.fecha_reclamo) as hora_reclamo, DATE(partes.fecha_realizado) as fecha_realizado, TIME(partes.fecha_realizado) as hora_realizado, DATE(partes.fecha_programado) as fecha_programado,"
                 + " partes.id_partes_estados, partes_usuarios_servicios.Id_servicio AS id_servicios, partes.id_usuarios, partes_usuarios_servicios.Id_usuarios_servicios, if(partes.requiere_equipo=0,'SI','NO') AS requiere_equipo, servicios.Requiere_Tarjeta, partes_fallas.id_partes_operaciones, partes.impreso, partes_usuarios_servicios.Asignacion_Ip_Fija"
                 + " FROM partes_usuarios_servicios"
                 + " LEFT JOIN partes ON partes.id = partes_usuarios_servicios.id_parte"
                 + " left JOIN servicios on servicios.id = partes_usuarios_servicios.Id_servicio"
                 + " left join partes_fallas on partes_fallas.Id = partes_usuarios_servicios.id_parte_falla"
                 + " left join partes_estados on partes_estados.Id = partes.id_partes_estados"
                 + " left JOIN usuarios on usuarios.id = partes.Id_usuarios"
                 + " left JOIN usuarios_locaciones on usuarios_locaciones.id = partes.id_usuarios_locaciones"
                 + " left JOIN personal on personal.id = partes.id_operadores"
                 + " left JOIN personal_areas on personal_areas.id = partes.id_areas"
                 + " left JOIN localidades on localidades.id = usuarios_locaciones.Id_Localidades"
                 + " WHERE partes_estados.id != 0");

                if (idTipoServicio > 0)
                {
                    consulta.Append(string.Format(" and servicios.id_servicios_tipos = {0} ", idTipoServicio));
                    consulta.Append(string.Format("and DATE({0})>=date('{1}') and DATE({0})<=date('{2}') ", tipoFecha, FechaDesde.Date.ToString("yyyy-MM-dd"), FechaHasta.Date.ToString("yyyy-MM-dd")));
                }
                else
                    consulta.Append(string.Format(" and DATE({0})>=date('{1}') and DATE({0})<=date('{2}') ", tipoFecha, FechaDesde.Date.ToString("yyyy-MM-dd"), FechaHasta.Date.ToString("yyyy-MM-dd")));

                if (filtrarRealizadosYAnulados)
                {
                    consulta.Append(string.Format(" and partes_estados.id not in (5,8) "));
                }

                consulta.Append(" order by partes.id DESC");

                oCon.CrearComando(consulta.ToString());
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

        public DataTable AgruparPartesTrabajo(DataTable partes)
        {
            DataTable dt = partes;
            Partes aParte = new Partes();
            DataTable dtPartesHechos = new DataTable();
            dtPartesHechos = Get_Estructura_Partes();
            int TipoAgrupacion = 0;
            TipoAgrupacion = oConfiguracion.GetValor_N("TipoGestionPartes");

            switch (TipoAgrupacion)
            {
                case 1:
                    aParte.Id_Usuarios = Convert.ToInt32(dt.Rows[0]["Id_Usuarios"]);
                    aParte.Id_Usuarios_Servicios = Convert.ToInt32(dt.Rows[0]["Id_Usuarios_Servicios"]);
                    aParte.Id_Servicios_Tipos = Convert.ToInt32(dt.Rows[0]["Id_Servicios_Tipos"]);
                    aParte.Id_Servicios_Grupos = Convert.ToInt32(dt.Rows[0]["Id_Servicios_Grupos"]);
                    aParte.Id_Servicios = Convert.ToInt32(dt.Rows[0]["Id_Servicios"]);

                    aParte.Id_Usuarios_Locaciones = Convert.ToInt32(dt.Rows[0]["Id_Usuarios_Locaciones"]);
                    aParte.Id_Zonas = Convert.ToInt32(dt.Rows[0]["Id_Zonas"]);
                    aParte.Id_Partes_Fallas = Convert.ToInt32(dt.Rows[0]["Id_Partes_Fallas"]);
                    aParte.Id_Partes_Soluciones = Convert.ToInt32(dt.Rows[0]["Id_Partes_Soluciones"]);
                    aParte.Id_Movil = Convert.ToInt32(dt.Rows[0]["Id_Movil"]);
                    aParte.Id_Tecnico = Convert.ToInt32(dt.Rows[0]["Id_Tecnico"]);

                    aParte.Id_Partes_Estados = Convert.ToInt32(dt.Rows[0]["Id_Partes_Estados"]);
                    aParte.Id_Operadores = Convert.ToInt32(dt.Rows[0]["Id_Operadores"]);
                    aParte.Id_Areas = Convert.ToInt32(dt.Rows[0]["Id_Areas"]);
                    aParte.Id_Locacion_Anterior = Convert.ToInt32(dt.Rows[0]["Id_Locacion_Anterior"]);
                    aParte.Fecha_tipo = Convert.ToInt32(dt.Rows[0]["Fecha_tipo"]);

                    aParte.Fecha_Reclamo = Convert.ToDateTime(dt.Rows[0]["Fecha_Reclamo"]);
                    aParte.Fecha_Programado = Convert.ToDateTime(dt.Rows[0]["Fecha_Programado"]);

                    aParte.Detalle_Falla = dt.Rows[0]["Detalle_Falla"].ToString();
                    aParte.Detalle_Solucion = dt.Rows[0]["Detalle_Solucion"].ToString();
                    aParte.Id_Comprobantes = Convert.ToInt32(dt.Rows[0]["Id_Comprobantes"]);
                    aParte.Traspasa = Convert.ToInt32(dt.Rows[0]["traspasa"]);
                    aParte.IdAppExterna = Convert.ToInt32(dt.Rows[0]["id_aplicacion_externa"]);
                    aParte.Id_Usuarios_Cuenta_Corriente = 0;
                    aParte.Id = Guardar(aParte, 0);

                    oParteUsuariosServicios.Id_Parte = aParte.Id;

                    DataRow drParteGeneral = dtPartesHechos.NewRow();

                    drParteGeneral["Id"] = aParte.Id;
                    drParteGeneral["Id_Usuarios"] = aParte.Id_Usuarios;
                    drParteGeneral["Id_Servicios"] = aParte.Id_Servicios;
                    drParteGeneral["Id_Usuarios_Servicios"] = aParte.Id_Usuarios_Servicios;
                    drParteGeneral["Id_Servicios_Tipos"] = aParte.Id_Servicios_Tipos;
                    drParteGeneral["Id_Servicios_Grupos"] = aParte.Id_Servicios_Grupos;
                    drParteGeneral["Id_Usuarios_Locaciones"] = aParte.Id_Usuarios_Locaciones;
                    drParteGeneral["Id_Zonas"] = aParte.Id_Zonas;
                    drParteGeneral["Id_Partes_Fallas"] = aParte.Id_Partes_Fallas;
                    drParteGeneral["Id_Partes_Soluciones"] = aParte.Id_Partes_Soluciones;
                    drParteGeneral["Id_Movil"] = aParte.Id_Movil;
                    drParteGeneral["Id_Tecnico"] = aParte.Id_Tecnico; ;

                    drParteGeneral["Id_Partes_Estados"] = aParte.Id_Partes_Estados;

                    drParteGeneral["Id_Operadores"] = aParte.Id_Operadores;
                    drParteGeneral["Id_Areas"] = aParte.Id_Areas; ;
                    drParteGeneral["Id_Locacion_Anterior"] = aParte.Id_Locacion_Anterior;
                    drParteGeneral["Fecha_Reclamo"] = aParte.Fecha_Reclamo;
                    drParteGeneral["Fecha_Programado"] = aParte.Fecha_Programado;
                    drParteGeneral["Detalle_Falla"] = aParte.Detalle_Falla;
                    drParteGeneral["Detalle_Solucion"] = aParte.Detalle_Solucion;
                    drParteGeneral["Id_Comprobantes"] = aParte.Id_Comprobantes;
                    drParteGeneral["traspasa"] = aParte.Traspasa;
                    drParteGeneral["id_aplicacion_externa"] = aParte.IdAppExterna;

                    dtPartesHechos.Rows.Add(drParteGeneral);
                    foreach (DataRow item2 in dt.Rows)
                    {
                        if (Convert.ToInt32(item2["id"]) == 0)
                        {
                            item2["id"] = aParte.Id;
                        }
                    }
                    oParteUsuariosServicios.GuardarPartesUsuariosSericios(dt);
                    break;

                case 2:
                    var resultGrupo = from row in dt.AsEnumerable()
                                      group row by row.Field<int>("Id_Servicios_Grupos") into grp
                                      select new
                                      {
                                          GrupoServicio = grp.Key,
                                      };

                    int idGrupoServicio = 0;

                    foreach (var item in resultGrupo)
                    {

                        if (idGrupoServicio != item.GrupoServicio)
                        {
                            DataRow[] lastRows = dt.Select(String.Format("Id_Servicios_Grupos = {0}", item.GrupoServicio));

                            if (lastRows.Length > 0)
                            {
                                aParte.Id_Usuarios_Locaciones = Convert.ToInt32(lastRows[0]["Id_Usuarios_Locaciones"]);
                                aParte.Id_Usuarios = Convert.ToInt32(lastRows[0]["Id_Usuarios"]);
                                aParte.Id_Usuarios_Servicios = Convert.ToInt32(lastRows[0]["Id_Usuarios_Servicios"]);
                                aParte.Id_Servicios_Tipos = Convert.ToInt32(lastRows[0]["Id_Servicios_Tipos"]);
                                aParte.Id_Servicios_Grupos = Convert.ToInt32(lastRows[0]["Id_Servicios_Grupos"]);
                                aParte.Id_Servicios = Convert.ToInt32(lastRows[0]["Id_Servicios"]);

                                aParte.Id_Usuarios_Locaciones = Convert.ToInt32(lastRows[0]["Id_Usuarios_Locaciones"]);
                                aParte.Id_Zonas = Convert.ToInt32(lastRows[0]["Id_Zonas"]);
                                aParte.Id_Partes_Fallas = Convert.ToInt32(lastRows[0]["Id_Partes_Fallas"]);
                                aParte.Id_Partes_Soluciones = Convert.ToInt32(lastRows[0]["Id_Partes_Soluciones"]);
                                aParte.Id_Movil = Convert.ToInt32(lastRows[0]["Id_Movil"]);
                                aParte.Id_Tecnico = Convert.ToInt32(lastRows[0]["Id_Tecnico"]);

                                aParte.Id_Partes_Estados = Convert.ToInt32(lastRows[0]["Id_Partes_Estados"]);
                                aParte.Id_Operadores = Convert.ToInt32(lastRows[0]["Id_Operadores"]);
                                aParte.Id_Areas = Convert.ToInt32(lastRows[0]["Id_Areas"]);
                                aParte.Id_Locacion_Anterior = Convert.ToInt32(lastRows[0]["Id_Locacion_Anterior"]);
                                aParte.Fecha_tipo = Convert.ToInt32(lastRows[0]["Fecha_tipo"]);

                                aParte.Fecha_Reclamo = Convert.ToDateTime(lastRows[0]["Fecha_Reclamo"]);
                                aParte.Fecha_Programado = Convert.ToDateTime(lastRows[0]["Fecha_Programado"]);

                                aParte.Detalle_Falla = lastRows[0]["Detalle_Falla"].ToString();
                                aParte.Detalle_Solucion = lastRows[0]["Detalle_Solucion"].ToString();
                                aParte.Id_Comprobantes = Convert.ToInt32(lastRows[0]["Id_Comprobantes"]);
                                aParte.Traspasa = Convert.ToInt32(dt.Rows[0]["traspasa"]);
                                aParte.IdAppExterna = Convert.ToInt32(dt.Rows[0]["id_aplicacion_externa"]);
                                aParte.Id_Usuarios_Cuenta_Corriente = 0;
                                aParte.Id = Guardar(aParte, 0);

                                oParteUsuariosServicios.Id_Parte = aParte.Id;

                                DataRow drParte = dtPartesHechos.NewRow();

                                drParte["Id"] = aParte.Id;
                                drParte["Id_Usuarios"] = aParte.Id_Usuarios;
                                drParte["Id_Servicios"] = aParte.Id_Servicios;
                                drParte["Id_Usuarios_Servicios"] = aParte.Id_Usuarios_Servicios;
                                drParte["Id_Servicios_Tipos"] = aParte.Id_Servicios_Tipos;
                                drParte["Id_Servicios_Grupos"] = aParte.Id_Servicios_Grupos;
                                drParte["Id_Usuarios_Locaciones"] = aParte.Id_Usuarios_Locaciones;
                                drParte["Id_Zonas"] = aParte.Id_Zonas;
                                drParte["Id_Partes_Fallas"] = aParte.Id_Partes_Fallas;
                                drParte["Id_Partes_Soluciones"] = aParte.Id_Partes_Soluciones;
                                drParte["Id_Movil"] = aParte.Id_Movil;
                                drParte["Id_Tecnico"] = aParte.Id_Tecnico; ;

                                drParte["Id_Partes_Estados"] = aParte.Id_Partes_Estados;

                                drParte["Id_Operadores"] = aParte.Id_Operadores;
                                drParte["Id_Areas"] = aParte.Id_Areas; ;
                                drParte["Id_Locacion_Anterior"] = aParte.Id_Locacion_Anterior;
                                drParte["Fecha_Reclamo"] = aParte.Fecha_Reclamo;
                                drParte["Fecha_Programado"] = aParte.Fecha_Programado;
                                drParte["Detalle_Falla"] = aParte.Detalle_Falla;
                                drParte["Detalle_Solucion"] = aParte.Detalle_Solucion;
                                drParte["Id_Comprobantes"] = aParte.Id_Comprobantes;
                                drParte["traspasa"] = aParte.Traspasa;
                                drParte["id_aplicacion_externa"] = aParte.IdAppExterna;

                                dtPartesHechos.Rows.Add(drParte);

                                idGrupoServicio = item.GrupoServicio;
                                foreach (DataRow item2 in dt.Rows)
                                {
                                    if (Convert.ToInt32(item2["id"]) == 0)
                                    {
                                        int idgruposer = Convert.ToInt32(item2["Id_Servicios_Grupos"]);
                                        if (idgruposer == idGrupoServicio)
                                            item2["id"] = aParte.Id;
                                    }
                                }
                            }
                        }
                    }
                    oParteUsuariosServicios.GuardarPartesUsuariosSericios(dt);

                    break;
                case 3:
                    var resultTipo = from row in dt.AsEnumerable()
                                     group row by row.Field<int>("Id_Servicios_Tipos") into grp
                                     select new
                                     {
                                         TipoServicio = grp.Key,
                                         cantidad = grp.Count()
                                     };

                    int idTipoServicio = 0;

                    foreach (var item in resultTipo)
                    {
                        if (idTipoServicio != item.TipoServicio)
                        {
                            DataRow[] lastRows = dt.Select(String.Format("Id_Servicios_Tipos = {0}", item.TipoServicio));

                            if (lastRows.Length > 0)
                            {
                                aParte.Id_Usuarios = Convert.ToInt32(lastRows[0]["Id_Usuarios"]);
                                aParte.Id_Usuarios_Servicios = Convert.ToInt32(lastRows[0]["Id_Usuarios_Servicios"]);
                                aParte.Id_Servicios_Tipos = Convert.ToInt32(lastRows[0]["Id_Servicios_Tipos"]);
                                aParte.Id_Servicios_Grupos = Convert.ToInt32(lastRows[0]["Id_Servicios_Grupos"]);
                                aParte.Id_Servicios = Convert.ToInt32(lastRows[0]["Id_Servicios"]);

                                aParte.Id_Usuarios_Locaciones = Convert.ToInt32(lastRows[0]["Id_Usuarios_Locaciones"]);
                                aParte.Id_Zonas = Convert.ToInt32(lastRows[0]["Id_Zonas"]);
                                aParte.Id_Partes_Fallas = Convert.ToInt32(lastRows[0]["Id_Partes_Fallas"]);
                                aParte.Id_Partes_Soluciones = Convert.ToInt32(lastRows[0]["Id_Partes_Soluciones"]);
                                aParte.Id_Movil = Convert.ToInt32(lastRows[0]["Id_Movil"]);
                                aParte.Id_Tecnico = Convert.ToInt32(lastRows[0]["Id_Tecnico"]);

                                aParte.Id_Partes_Estados = Convert.ToInt32(lastRows[0]["Id_Partes_Estados"]);
                                aParte.Id_Operadores = Convert.ToInt32(lastRows[0]["Id_Operadores"]);
                                aParte.Id_Areas = Convert.ToInt32(lastRows[0]["Id_Areas"]);
                                aParte.Id_Locacion_Anterior = Convert.ToInt32(lastRows[0]["Id_Locacion_Anterior"]);
                                aParte.Fecha_tipo = Convert.ToInt32(lastRows[0]["Fecha_tipo"]);

                                aParte.Fecha_Reclamo = Convert.ToDateTime(lastRows[0]["Fecha_Reclamo"]);
                                aParte.Fecha_Programado = Convert.ToDateTime(lastRows[0]["Fecha_Programado"]);

                                aParte.Detalle_Falla = lastRows[0]["Detalle_Falla"].ToString();
                                aParte.Detalle_Solucion = lastRows[0]["Detalle_Solucion"].ToString();
                                aParte.Id_Comprobantes = Convert.ToInt32(lastRows[0]["Id_Comprobantes"]);
                                aParte.Traspasa = Convert.ToInt32(lastRows[0]["traspasa"]);
                                aParte.IdAppExterna = Convert.ToInt32(dt.Rows[0]["id_aplicacion_externa"]);
                                aParte.Id_Usuarios_Cuenta_Corriente = 0;
                                aParte.Id = Guardar(aParte, 0);

                                oParteUsuariosServicios.Id_Parte = aParte.Id;

                                DataRow drParte = dtPartesHechos.NewRow();

                                drParte["Id"] = aParte.Id;
                                drParte["Id_Usuarios"] = aParte.Id_Usuarios;
                                drParte["Id_Servicios"] = aParte.Id_Servicios;
                                drParte["Id_Usuarios_Servicios"] = aParte.Id_Usuarios_Servicios;
                                drParte["Id_Servicios_Tipos"] = aParte.Id_Servicios_Tipos;
                                drParte["Id_Servicios_Grupos"] = aParte.Id_Servicios_Grupos;
                                drParte["Id_Usuarios_Locaciones"] = aParte.Id_Usuarios_Locaciones;
                                drParte["Id_Zonas"] = aParte.Id_Zonas;
                                drParte["Id_Partes_Fallas"] = aParte.Id_Partes_Fallas;
                                drParte["Id_Partes_Soluciones"] = aParte.Id_Partes_Soluciones;
                                drParte["Id_Movil"] = aParte.Id_Movil;
                                drParte["Id_Tecnico"] = aParte.Id_Tecnico; ;

                                drParte["Id_Partes_Estados"] = aParte.Id_Partes_Estados;

                                drParte["Id_Operadores"] = aParte.Id_Operadores;
                                drParte["Id_Areas"] = aParte.Id_Areas; ;
                                drParte["Id_Locacion_Anterior"] = aParte.Id_Locacion_Anterior;
                                drParte["Fecha_Reclamo"] = aParte.Fecha_Reclamo;
                                drParte["Fecha_Programado"] = aParte.Fecha_Programado;
                                drParte["Detalle_Falla"] = aParte.Detalle_Falla;
                                drParte["Detalle_Solucion"] = aParte.Detalle_Solucion;
                                drParte["Id_Comprobantes"] = aParte.Id_Comprobantes;
                                drParte["traspasa"] = aParte.Traspasa;
                                drParte["id_aplicacion_externa"] = aParte.IdAppExterna;

                                dtPartesHechos.Rows.Add(drParte);
                                idTipoServicio = item.TipoServicio;

                                foreach (DataRow item2 in dt.Rows)
                                {
                                    if (Convert.ToInt32(item2["id"]) == 0)
                                    {
                                        int idtiposer = Convert.ToInt32(item2["Id_Servicios_Tipos"]);
                                        if (idtiposer == idTipoServicio)
                                            item2["id"] = aParte.Id;
                                    }
                                }

                            }
                        }
                    }
                    oParteUsuariosServicios.GuardarPartesUsuariosSericios(dt);

                    break;
                case 4:

                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow item in dt.Rows)
                        {
                            aParte.Id_Usuarios_Locaciones = Convert.ToInt32(item["Id_Usuarios_Locaciones"]);
                            aParte.Id_Usuarios = Convert.ToInt32(item["Id_Usuarios"]);
                            aParte.Id_Usuarios_Servicios = Convert.ToInt32(item["Id_Usuarios_Servicios"]);
                            aParte.Id_Servicios_Tipos = Convert.ToInt32(item["Id_Servicios_Tipos"]);
                            aParte.Id_Servicios_Grupos = Convert.ToInt32(item["Id_Servicios_Grupos"]);
                            aParte.Id_Servicios = Convert.ToInt32(item["Id_Servicios"]);

                            aParte.Id_Usuarios_Locaciones = Convert.ToInt32(item["Id_Usuarios_Locaciones"]);
                            aParte.Id_Zonas = Convert.ToInt32(item["Id_Zonas"]);
                            aParte.Id_Partes_Fallas = Convert.ToInt32(item["Id_Partes_Fallas"]);
                            aParte.Id_Partes_Soluciones = Convert.ToInt32(item["Id_Partes_Soluciones"]);
                            aParte.Id_Movil = Convert.ToInt32(item["Id_Movil"]);
                            aParte.Id_Tecnico = Convert.ToInt32(item["Id_Tecnico"]);

                            aParte.Id_Partes_Estados = Convert.ToInt32(item["Id_Partes_Estados"]);
                            aParte.Id_Operadores = Convert.ToInt32(item["Id_Operadores"]);
                            aParte.Id_Areas = Convert.ToInt32(item["Id_Areas"]);
                            aParte.Id_Locacion_Anterior = Convert.ToInt32(item["Id_Locacion_Anterior"]);
                            aParte.Fecha_tipo = Convert.ToInt32(item["Fecha_tipo"]);

                            aParte.Fecha_Reclamo = Convert.ToDateTime(item["Fecha_Reclamo"]);
                            aParte.Fecha_Programado = Convert.ToDateTime(item["Fecha_Programado"]);

                            aParte.Detalle_Falla = item["Detalle_Falla"].ToString();
                            aParte.Detalle_Solucion = item["Detalle_Solucion"].ToString();
                            aParte.Id_Comprobantes = Convert.ToInt32(item["Id_Comprobantes"]);
                            aParte.Traspasa = Convert.ToInt32(item["traspasa"]);
                            aParte.IdAppExterna = Convert.ToInt32(dt.Rows[0]["id_aplicacion_externa"]);
                            aParte.Id_Usuarios_Cuenta_Corriente = 0;
                            aParte.Id = Guardar(aParte, 1);

                            oParteUsuariosServicios.Id_Parte = aParte.Id;

                            DataRow drParte = dtPartesHechos.NewRow();

                            drParte["Id"] = aParte.Id;
                            drParte["Id_Usuarios"] = aParte.Id_Usuarios;
                            drParte["Id_Servicios"] = aParte.Id_Servicios;
                            drParte["Id_Usuarios_Servicios"] = aParte.Id_Usuarios_Servicios;
                            drParte["Id_Servicios_Tipos"] = aParte.Id_Servicios_Tipos;
                            drParte["Id_Servicios_Grupos"] = aParte.Id_Servicios_Grupos;
                            drParte["Id_Usuarios_Locaciones"] = aParte.Id_Usuarios_Locaciones;
                            drParte["Id_Zonas"] = aParte.Id_Zonas;
                            drParte["Id_Partes_Fallas"] = aParte.Id_Partes_Fallas;
                            drParte["Id_Partes_Soluciones"] = aParte.Id_Partes_Soluciones;
                            drParte["Id_Movil"] = aParte.Id_Movil;
                            drParte["Id_Tecnico"] = aParte.Id_Tecnico; ;

                            drParte["Id_Partes_Estados"] = aParte.Id_Partes_Estados;

                            drParte["Id_Operadores"] = aParte.Id_Operadores;
                            drParte["Id_Areas"] = aParte.Id_Areas; ;
                            drParte["Id_Locacion_Anterior"] = aParte.Id_Locacion_Anterior;
                            drParte["Fecha_Reclamo"] = aParte.Fecha_Reclamo;
                            drParte["Fecha_Programado"] = aParte.Fecha_Programado;
                            drParte["Detalle_Falla"] = aParte.Detalle_Falla;
                            drParte["Detalle_Solucion"] = aParte.Detalle_Solucion;
                            drParte["Id_Comprobantes"] = aParte.Id_Comprobantes;
                            drParte["traspasa"] = aParte.Traspasa;
                            drParte["id_aplicacion_externa"] = aParte.IdAppExterna;

                            dtPartesHechos.Rows.Add(drParte);


                        }
                    }
                    break;

                default:
                    break;
            }

            return dtPartesHechos;
        }

        public DataTable GenerarLotePartes(DataTable dtPartes, int TipoOperacion, int postdatado = 0)
        {

            List<int> listaUsuariosPartes = new List<int>();
            List<int> listaPartesCorteAutomatico = new List<int>();
            int idUsuario = 0;
            DataView dtvPartesPorUsuario = new DataView(dtPartes);
            DataTable dtPartesRealizados = dtPartes.Clone();
            Partes_Historial oPartesHistorial = new Partes_Historial();
            Partes oPartes = new Partes();
            DataTable dtPartesRestantes = dtPartes.Clone();
            DataTable dtPartesConCorteAut = dtPartes.Clone();
            DataTable dtAuxiliarPartesRestantes = new DataTable();

            if (dtPartes.Rows.Count > 0)
            {
                foreach (DataRow parte in dtPartes.Rows)
                {
                    idUsuario = Convert.ToInt32(parte["Id_Usuarios"]);
                    dtPartesConCorteAut.Clear();
                    dtPartesRestantes.Clear();
                    dtAuxiliarPartesRestantes.Clear();

                    if (listaUsuariosPartes.Contains(idUsuario) == false)
                    {
                        listaUsuariosPartes.Add(idUsuario);
                        dtvPartesPorUsuario.RowFilter = String.Format("id_usuarios={0}", idUsuario);

                        if (TipoOperacion == Convert.ToInt32(Partes.Partes_Operaciones.CORTE) || TipoOperacion == Convert.ToInt32(Partes.Partes_Operaciones.RECONEXION))
                        {
                            foreach (DataRow parte1 in dtvPartesPorUsuario.ToTable().Rows)
                            {
                                if (Convert.ToInt32(parte1["CorteAutomatico"]) == Convert.ToInt32(Servicios._CorteAutomatico.SI))
                                    dtPartesConCorteAut.ImportRow(parte1);
                                else
                                    dtPartesRestantes.ImportRow(parte1);
                            }
                        }
                        else
                            dtPartesRestantes = dtvPartesPorUsuario.ToTable();


                        if (dtPartesConCorteAut.Rows.Count > 0)
                        {
                            foreach (DataRow parteConCorteAut in dtPartesConCorteAut.Rows)
                            {
                                oPartes.Id_Usuarios = Convert.ToInt32(parteConCorteAut["Id_usuarios"]);
                                oPartes.Id_Servicios = Convert.ToInt32(parteConCorteAut["Id_Servicios"]);
                                oPartes.Id_Usuarios_Servicios = Convert.ToInt32(parteConCorteAut["Id_Usuarios_Servicios"]);
                                oPartes.Id_Usuarios_Locaciones = Convert.ToInt32(parteConCorteAut["Id_usuarios_locaciones"]);
                                oPartes.Id_Zonas = Convert.ToInt32(parteConCorteAut["Id_zonas"]);
                                oPartes.Id_Partes_Fallas = Convert.ToInt32(parteConCorteAut["Id_Partes_Fallas"]);
                                oPartes.Id_Partes_Soluciones = Convert.ToInt32(parteConCorteAut["Id_Partes_Soluciones"]);
                                oPartes.Id_Movil = Convert.ToInt32(parteConCorteAut["Id_Movil"]);
                                oPartes.Id_Operadores = Convert.ToInt32(parteConCorteAut["Id_Operadores"]);
                                oPartes.Id_Areas = Convert.ToInt32(parteConCorteAut["Id_Areas"]);
                                oPartes.Fecha_Reclamo = Convert.ToDateTime(parteConCorteAut["Fecha_Reclamo"]);
                                oPartes.Detalle_Solucion = parteConCorteAut["Detalle_Solucion"].ToString();
                                oPartes.Detalle_Falla = parteConCorteAut["Detalle_Falla"].ToString();
                                oPartes.Id_Partes_Estados = Convert.ToInt32(parteConCorteAut["Id_Partes_Estados"]);
                                oPartes.Id_Tecnico = Convert.ToInt32(parteConCorteAut["Id_Tecnico"]);
                                oPartes.IdAppExterna = Convert.ToInt32(parteConCorteAut["id_aplicacion_externa"]);
                                int configAgenda = oConfiguracion.GetValor_N("Agenda_Trabajo");
                                if (configAgenda == Convert.ToInt32(Agenda_Encabezado.Uso_agenda.TRABAJA_CON_AGENDA))
                                    oPartes.Fecha_Realizado = Convert.ToDateTime(parteConCorteAut["Fecha_Realizado"]);
                                oPartes.Fecha_Programado = Convert.ToDateTime(parteConCorteAut["fecha_programado"]);
                                oPartes.Id_Usuarios_Cuenta_Corriente = 0;
                                parteConCorteAut["id"] = oPartes.Guardar(oPartes, 1);

                                dtPartesRealizados.ImportRow(parteConCorteAut);
                            }
                        }

                        if (dtPartesRestantes.Rows.Count > 0)
                        {
                            dtAuxiliarPartesRestantes = AgruparPartesTrabajo(dtPartesRestantes);
                            foreach (DataRow fila in dtAuxiliarPartesRestantes.Rows)
                                dtPartesRealizados.ImportRow(fila);
                        }
                    }
                }
            }
            else
                dtPartesRealizados = dtPartes;

            return dtPartesRealizados;
            //101019fede
        }

        //Borrados
        public DataTable ListarPartesAbiertos(int idLocacion, int idOperacion, int idUsuarioServicio = 0)
        {
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();

                string comando = "select partes_usuarios_servicios.id as id_parte_us, partes.id,partes_usuarios_servicios.id_parte_falla as id_partes_fallas, partes.id_partes_estados, partes_fallas.id_partes_operaciones" +
                    " from partes_usuarios_servicios " +
                    " left join partes on partes.id = partes_usuarios_servicios.id_parte " +
                    " left join partes_fallas on partes.id_partes_fallas = partes_fallas.id " +
                    " where partes.id_usuarios_locaciones = @idLocacion and (partes.id_partes_estados <> @idEstado and partes.id_partes_estados <> @idEstado2)";

                string condicionOperacion = "";
                if (idOperacion > 0)
                {
                    condicionOperacion = " and partes_fallas.id_partes_operaciones = @idOperacion";
                }

                string filtroUsuarioServicio = "";
                if (idUsuarioServicio > 0)
                {
                    filtroUsuarioServicio = " and partes_usuarios_servicios.id_usuarios_servicios = @idUsuarioServicio";
                }

                comando = $"{comando} {condicionOperacion} {filtroUsuarioServicio}";

                oCon.CrearComando(comando);
                oCon.AsignarParametroEntero("@idLocacion", idLocacion);
                oCon.AsignarParametroEntero("@idEstado", (int)Partes.Partes_Estados.REALIZADO);
                oCon.AsignarParametroEntero("@idEstado2", (int)Partes.Partes_Estados.ANULADO);
                if (idOperacion > 0)
                    oCon.AsignarParametroEntero("@idOperacion", idOperacion);

                if (idUsuarioServicio > 0)
                    oCon.AsignarParametroEntero("@idUsuarioServicio", idUsuarioServicio);
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

        public bool GuardarOrigen(int idParte)
        {
            try
            {
                oCon.Conectar();
                string comando = "update partes set id_origen = @origen where partes.id = @idParte";
                oCon.CrearComando(comando);
                oCon.AsignarParametroEntero("@idParte", idParte);
                oCon.AsignarParametroEntero("@origen", (int)Origen.GIES);
                oCon.ComenzarTransaccion();
                oCon.EjecutarComando();
                oCon.ConfirmarTransaccion();
                oCon.DesConectar();
                return true;
            }
            catch (Exception)
            {
                oCon.CancelarTransaccion();
                oCon.DesConectar();
                return false;
            }
        }

        public void RestrablecerCortes()
        {
            try
            {
                oCon.Conectar();
                oCon.ComenzarTransaccion();
                oCon.CrearComando("spRestablecerCortes()");
                oCon.EjecutarComando();
                oCon.ConfirmarTransaccion();
                oCon.DesConectar();
            }
            catch (Exception)
            {
                oCon.CancelarTransaccion();
                oCon.DesConectar();
            }
        }

        public void CambiarServiciosEnEsperaSiEstanVencidos()
        {
            try
            {
                oCon.Conectar();
                string comando = "update usuarios_servicios"
                                 + " set id_servicios_estados = 2"
                                 + " where id_servicios_estados = 3 and fecha_estado<CURDATE()";
                oCon.CrearComando(comando);
                oCon.EjecutarComando();
                oCon.DesConectar();
            }
            catch (Exception)
            {
                oCon.DesConectar();
            }
        }
    
        public bool ConfirmarParte(int idParte,int idSolucion, string problema,DateTime fechaConfirma,Partes.TipoProblemas tipoPproblema,string detalleSolucion,int idTecnicoSeleccionado, out int tipoSalida,out string salida)
        {
            //tipoSalida: 1 SIN ERRORES, 2 CON ERRORES
            if (idParte > 0)
            {
                GuardarOrigen(idParte);
                Servicios_Estados_Historial oServicioEstadoHistorial = new Servicios_Estados_Historial();
                Partes_Usuarios_Servicios oPartesUsuSer = new Partes_Usuarios_Servicios();
                Partes_Equipos oParteEquipo = new Partes_Equipos();
                Equipos oEquipo = new Equipos();
                Equipos_Tarjetas oEquipoTarjeta = new Equipos_Tarjetas();
                Usuarios_Servicios oUsuSer = new Usuarios_Servicios();
                DataTable dtEquiposAsociados, dtDatosEquipo, dtPartesEquipos;
                DataRow drDatosDelParte;
                drDatosDelParte = TraerParteRow(idParte);
                DataTable dtPartesUsuSer = oPartesUsuSer.ListarServiciosPorParte(idParte, Partes_Usuarios_Servicios.CONDICION_REQ_EQUIPOS.TODOS);
                //Declaro las variables que voy a usar 
                int idUsuario, idServicio, idParteUsuSer, idOperacion, idUsuarioServicio, idEquipo, idEquipoEstado, idCorte, idFalla, requiereTecnico, idLocacion, idLocacionAnterior, idTecnico;
                string resultado,parteOperacion,requiereEquipoString="NO";
                Boolean requiereEquipo = false,faltaEquipo=false;
                idUsuario = Convert.ToInt32(drDatosDelParte["id_usuarios"]);
                idTecnico = Convert.ToInt32(drDatosDelParte["id_tecnicos"]);
                idLocacion = Convert.ToInt32(drDatosDelParte["id_usuarios_locaciones"]);

                //Primero recorre todos los partes_usuarios_servicios y corrobora si requiere_tecnico, si requiere tecnico verifica que tenga un tecnico asignado
                //Tambien verifica de la misma forma si el servicio_requiere equipo y si le falta asignar el metodo confirmarParte devolvera falso
                //Si requiere tecnico lo determina el parte_operacion
                //Si requiere equipo lo determina el servicio
                foreach (DataRow parteUsuSer in dtPartesUsuSer.Rows)
                {
                    parteOperacion = parteUsuSer["falla"].ToString().ToUpper();
                    requiereTecnico = Convert.ToInt32(parteUsuSer["requiere_tecnico"]);
                    requiereEquipoString = parteUsuSer["requiere_equipo"].ToString().ToUpper();
                    if (requiereEquipoString == "SI")
                        requiereEquipo = true;

                    if (idTecnico==0 && requiereTecnico == 1 && idTecnicoSeleccionado==0)
                    {
                        tipoSalida = 2;
                        salida = "La operacion: " + parteOperacion + ", requiere la asignación de un técnico.";
                        return false;
                    }
                }
                foreach (DataRow parteUsuSer in dtPartesUsuSer.Rows)
                {
                    idParteUsuSer = Convert.ToInt32(parteUsuSer["id"]);
                    idServicio = Convert.ToInt32(parteUsuSer["id_Servicios"]);
                    idOperacion = Convert.ToInt32(parteUsuSer["id_partes_operaciones"]);
                    idUsuarioServicio = Convert.ToInt32(parteUsuSer["id_usuarios_servicios"]);
                    idCorte = Convert.ToInt32(parteUsuSer["id_corte"]);
                    idFalla = Convert.ToInt32(parteUsuSer["id_parte_falla"]);
                    dtEquiposAsociados = oEquipo.BuscarEquipoPorUsuarioServicio(idUsuarioServicio);
                    
                    switch (idOperacion)
                    {
                        case (int)Partes.Partes_Operaciones.CONEXION:
                            if(oUsuSer.ActivarServicio(idUsuarioServicio, fechaConfirma,out resultado) == true)
                            {
                                foreach (DataRow equipo in dtEquiposAsociados.Rows)
                                {
                                    idEquipo = Convert.ToInt32(equipo["id"]);
                                    if(oParteEquipo.ActivarRegistroParteEquipo(idEquipo,out resultado) == true)
                                    {
                                        idEquipoEstado = Convert.ToInt32(equipo["id_equipos_Estados"]);
                                        if (idEquipoEstado != (int)Equipos.Equipos_Estados.ASIGNADO_A_USUARIO)
                                        {
                                            if(oEquipo.CambiarEstado(idEquipo, Convert.ToInt32(Equipos.Equipos_Estados.ASIGNADO_A_USUARIO),out resultado) == false)
                                            {
                                                salida = resultado;
                                                tipoSalida = 2;
                                                return false;
                                            }
                                            oServicioEstadoHistorial.id_servicios_estados = Convert.ToInt32(Servicios.Servicios_Estados.CONECTADO);

                                        }
                                    }
                                    else
                                    {
                                        salida = resultado;
                                        tipoSalida = 2;
                                        return false;
                                    }

                                }

                            }
                            else
                            {
                                tipoSalida = 2;
                                salida = resultado;
                            }
                            break;
                        case (int)Partes.Partes_Operaciones.RECONEXION:
                            if (!oUsuSer.ActivarServicio(idUsuarioServicio, fechaConfirma, out resultado) == true)
                            {
                                tipoSalida = 2;
                                salida = resultado;
                            }
                            break;
                        case (int)Partes.Partes_Operaciones.CORTE:
                            oUsuSer.ActualizarEstadoCorte(idUsuarioServicio, idCorte);
                            oUsuSer.Actualizar_avisos(3, 0, idUsuarioServicio);
                            oUsuSer.ActualizarConCorte(idUsuarioServicio, 0);
                            oServicioEstadoHistorial.id_servicios_estados = Convert.ToInt32(Servicios.Servicios_Estados.CORTADO);

                            break;
                        case (int)Partes.Partes_Operaciones.BAJA:
                            oUsuSer.ActualizarEstado(idUsuarioServicio, Convert.ToInt32(Servicios.Servicios_Estados.RETIRADO));//pasa a retirado                          
                            oServicioEstadoHistorial.id_servicios_estados = Convert.ToInt32(Servicios.Servicios_Estados.RETIRADO);

                            break;
                        case (int)Partes.Partes_Operaciones.CAMBIO_DE_EQUIPO:
                            if(oEquipo.AsignarEquipo(idParte, Partes.Partes_Operaciones.CAMBIO_DE_EQUIPO, out resultado) == false)
                            {
                                salida = resultado;
                                tipoSalida = 2;
                                return false;
                            }
                            break;
                        case (int)Partes.Partes_Operaciones.CAMBIO_DE_DOMICILIO:
                            Usuarios_Locaciones oLocacion = new Usuarios_Locaciones();
                            idLocacionAnterior = Convert.ToInt32(drDatosDelParte["id_locacion_anterior"]);
                            oLocacion.Realizar_Cambio_Domicilio(idParte, dtPartesUsuSer,idLocacion, idLocacionAnterior, Convert.ToInt32(drDatosDelParte["Id_usuarios"]), Convert.ToInt32(drDatosDelParte["traspasa"]));
                            break;
                        case (int)Partes.Partes_Operaciones.BAJA_DE_DEBITO:
                            Plasticos oPlastico = new Plasticos();
                            oPlastico.DesactivarServiciosDebito(dtPartesUsuSer);
                            break;
                        case (int)Partes.Partes_Operaciones.FACTIBILIDAD:
                            Partes_Soluciones oSoluciones = new Partes_Soluciones();
                            DataTable dtSoluciones = oSoluciones.Listar();
                            DataView dvSolucionesFiltro = dtSoluciones.DefaultView;
                            dvSolucionesFiltro.RowFilter = "id = " + idSolucion;
                            DataTable dtDAtoSolucion = dvSolucionesFiltro.ToTable();
                            if (dtDAtoSolucion.Rows[0]["nombre"].ToString().ToUpper() == "FACTIBILIDAD POSITIVA")
                            {
                                oUsuSer.ActualizarEstado(idUsuarioServicio, Convert.ToInt32(Servicios.Servicios_Estados.FACTIBILIDAD_POSITIVA));//pasa a retirado
                                oServicioEstadoHistorial.id_servicios_estados = Convert.ToInt32(Servicios.Servicios_Estados.FACTIBILIDAD_POSITIVA);

                            }
                            else
                            {
                                oUsuSer.ActualizarEstado(idUsuarioServicio, Convert.ToInt32(Servicios.Servicios_Estados.FACTIBILIDAD_NEGATIVA));//pasa a retirado
                                oServicioEstadoHistorial.id_servicios_estados = Convert.ToInt32(Servicios.Servicios_Estados.FACTIBILIDAD_NEGATIVA);

                            }
                            break;
                        case (int)Partes.Partes_Operaciones.ASIGNACION_DE_EQUIPO:
                            oEquipo.AsignarEquipo(idParte, Partes.Partes_Operaciones.ASIGNACION_DE_EQUIPO,out resultado);
                            break;
                       case (int)Partes.Partes_Operaciones.RECUPERACION_EQUIPO:
                            if (dtEquiposAsociados.Rows.Count > 0)
                            {
                                foreach (DataRow Equipo in dtEquiposAsociados.Rows)
                                {
                                    if (Convert.ToInt32(Equipo["id_tarjeta"]) != 0)
                                        oEquipoTarjeta.CambiarEstadoTarjeta(Convert.ToInt32(Equipo["id_tarjeta"]), Convert.ToInt32(Equipos_Tarjetas.Tarjetas_Estados.CON_FALLA));
                                    oEquipo.PasarEquipoReparacion(Convert.ToInt32(Equipo["id"]), 0);
                                }
                            }
                            break;
                    }
                    oUsuSer.ActualizarFechaEstado(idUsuarioServicio, DateTime.Now);
                    Agenda_Encabezado oAgenda = new Agenda_Encabezado();
                    Partes_Historial oHistorial = new Partes_Historial();
                    Id_Partes_Estados = SetearEstadoParte(idParte, 0, Convert.ToInt32(Partes.Partes_Estados.REALIZADO), fechaConfirma, idSolucion,(int)tipoPproblema, detalleSolucion);
                    oHistorial.Id_Parte = idParte;
                    oHistorial.Id_Usuarios = idUsuario;
                    oHistorial.Id_Personal = Personal.Id_Login;
                    oHistorial.Fecha_Movimiento = DateTime.Now;
                    oHistorial.Id_area = Personal.Id_Area;
                    oHistorial.Detalles = "PARTE PASADO A REALIZADO.";
                    oHistorial.Id_Partes_Estados = Id_Partes_Estados;
                    oHistorial.GuardarNuevoDetalle(oHistorial);

                    oServicioEstadoHistorial.id_servicios = idServicio;
                    oServicioEstadoHistorial.id_usuarios =idUsuario;
                    oServicioEstadoHistorial.id_usuarios_servicios = idUsuarioServicio;
                    oServicioEstadoHistorial.fecha = fechaConfirma;
                    oServicioEstadoHistorial.Guardar(oServicioEstadoHistorial);
                }
                salida = "";
                tipoSalida = 1;
                return true;
            }
            else
            {
                salida = "El id de parte no puede ser cero.";
                tipoSalida = 2;
                return false;
            }
        }

        //ESTE METODO DEBE SER LLAMADO CUANDO YA SE ENCUENTRA ABIERTA LA CONEXION PARA OBTENER DATOS DEL PARTE.
        public DataTable getDatosParte(int id_parte)
        {
            DataTable dt = new DataTable();

            try
            {
                oCon.Conectar();
                oCon.CrearComando("SELECT partes.id AS idParte, usuarios_servicios.id AS idUsuServ, ifnull(partes_usuarios_servicios.id_usuarios_servicios_Sub,0) AS idUsuServSub, " +
                    "servicios.id AS idServicio, usuarios.id AS idUsuario, usuarios.Codigo AS codUsuario, usuarios_servicios.Id_Tipo_Facturacion AS idTipoFac, " +
                    "servicios.Id_Aplicaciones_Externas AS idAppExterna, partes_operaciones.Id AS idOperacion, partes_operaciones.Nombre AS Operacion, " +
                    "partes.Fecha_Reclamo AS fechaReclamo, partes.Fecha_Programado AS fechaProgramado, partes.Fecha_Realizado AS fechaRealizado, " +
                    "CONCAT(usuarios.Apellido, ' , ', usuarios.Nombre) AS Usuario " +
                    "FROM partes " +
                    "LEFT JOIN partes_usuarios_servicios ON partes_usuarios_servicios.Id_parte = partes.id " +
                    "LEFT JOIN usuarios_servicios ON partes_usuarios_servicios.Id_usuarios_servicios = usuarios_servicios.id " +
                    "LEFT JOIN usuarios_servicios_sub ON partes_usuarios_servicios.id_usuarios_servicios_Sub = usuarios_servicios_sub.id " +
                    "LEFT JOIN servicios ON partes_usuarios_servicios.Id_servicio = servicios.id " +
                    "LEFT JOIN usuarios ON partes.Id_Usuarios = usuarios.id " +
                    "LEFT JOIN partes_fallas ON partes.Id_Partes_Fallas = partes_fallas.Id " +
                    "LEFT JOIN partes_operaciones ON partes_fallas.Id_Partes_Operaciones = partes_operaciones.id " +
                    $"WHERE partes.id = {id_parte} AND partes.borrado = 0 AND usuarios_servicios.borrado = 0 ");
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

        public DataTable gestionarAppExternasLista(List<int> id_partes, out string resultadoFinal)
        {
            //DECLARACIONES DE VARIABLES INTERNAS DEL METODO
            Partes_Usuarios_Servicios oParteUsuarioServicio = new Partes_Usuarios_Servicios();
            DataTable dtDatosParte = new DataTable();
            DataTable DtServiciosAsociados = new DataTable();
            DataTable dtResultado = new DataTable();
            dtResultado.Columns.Add("idParte", typeof(int));
            dtResultado.Columns.Add("codOperacion", typeof(int));
            dtResultado.Columns.Add("Resultado", typeof(string));

            //DECLARACIONES PARA EL CASS
            DataTable dtAplicacionesFiltradas = Tablas.DataCass;
            Cass oCass;
            oCass = new Cass(Convert.ToInt32(dtAplicacionesFiltradas.Rows[0]["Id"]));
            DataTable dtOperacionesCass = new DataTable();
            DataTable dtFullData = new DataTable();
            string ResultadoOpCass = "";
            string ResultadoTotal = "";

            //DECLARACIONES PARA EL ISP
            string ResultadoOpIsp = "";
            string ResultadoTotalIsp = "";
            int estadoOpIsp = 0;
            try 
            {
                foreach (var idParteActual in id_partes)
                {
                    dtDatosParte = this.getDatosParte(idParteActual);
                    if(dtDatosParte.Rows.Count > 0)
                    {
                        foreach(DataRow drParte in dtDatosParte.Rows)
                        {
                            ResultadoOpCass = "";
                            if (Convert.ToInt32(drParte["idAppExterna"]) == (int)Aplicaciones_Externas.Aplicacion_Externa.CASS)
                            {
                                if (Convert.ToInt32(drParte["idOperacion"]) == (int)Partes_Operaciones.CONEXION)
                                {
                                    DtServiciosAsociados.Clear();
                                    dtOperacionesCass.Clear();
                                    DtServiciosAsociados = oParteUsuarioServicio.ListarServiciosPorParte(Convert.ToInt32(drParte["idParte"]), Partes_Usuarios_Servicios.CONDICION_REQ_EQUIPOS.TODOS);
                                    dtOperacionesCass = oCass.GenerarDtTarjetas(DtServiciosAsociados);
                                    if (dtOperacionesCass.Rows.Count > 0)
                                    {
                                        if(oCass.GenerarActivacion(dtOperacionesCass, Convert.ToInt32(drParte["idUsuario"]), out ResultadoOpCass))
                                        {
                                            dtResultado.Rows.Add(idParteActual, (int)Aplicaciones_Externas.Estado_Acciones.EXITOSA, "Conexion generada correctamente");
                                        }
                                        else
                                        {
                                            dtResultado.Rows.Add(idParteActual, (int)Aplicaciones_Externas.Estado_Acciones.EXITOSA, "Error al realizar la conexion");
                                        }

                                    }

                                }
                                else if (Convert.ToInt32(drParte["idOperacion"]) == (int)Partes_Operaciones.RECONEXION)
                                {
                                    if (oCass.ReactivarPaquetesAbonado(Convert.ToInt32(drParte["idUsuario"]), out ResultadoOpCass))
                                    {
                                        dtResultado.Rows.Add(idParteActual, (int)Aplicaciones_Externas.Estado_Acciones.EXITOSA, "Abonado reanudado correctamente");
                                    }
                                    else
                                    {
                                        dtResultado.Rows.Add(idParteActual, (int)Aplicaciones_Externas.Estado_Acciones.EXITOSA, "Error al reanudar abonado");
                                    }
                                }

                                else if (Convert.ToInt32(drParte["idOperacion"]) == (int)Partes_Operaciones.CORTE)
                                {
                                    if(oCass.PausarPaquetesAbonado(Convert.ToInt32(drParte["idUsuario"]), out ResultadoOpCass))
                                    {
                                        dtResultado.Rows.Add(idParteActual, (int)Aplicaciones_Externas.Estado_Acciones.EXITOSA, "Abonado pausado correctamente");
                                    }
                                    else
                                    {
                                        dtResultado.Rows.Add(idParteActual, (int)Aplicaciones_Externas.Estado_Acciones.FALLIDA, "Error al pausar abonado");
                                    }
                                }
                                else if(Convert.ToInt32(drParte["idOperacion"]) == (int)Partes_Operaciones.QUITAR_SUBSERVICIO)
                                {
                                    dtFullData.Clear();
                                    dtFullData = oCass.getFullDataUser(Convert.ToInt32(drParte["idUsuServ"]), 0, (int)Cass.FILTROS_GET_DATA.ID_USUARIO_SERVICIO);
                                    if (dtFullData.Rows.Count == 0)
                                    {
                                        dtFullData.Clear();
                                        dtFullData = oCass.getFullDataUser(0, Convert.ToInt32(drParte["idParte"]), (int)Cass.FILTROS_GET_DATA.ID_PARTE);
                                    }
                                    if (dtFullData.Rows.Count > 0)
                                    {
                                        if(oCass.actualizarCass(dtFullData, Convert.ToInt32(drParte["idUsuario"]), out ResultadoOpCass))
                                        {
                                            dtResultado.Rows.Add(idParteActual, (int)Aplicaciones_Externas.Estado_Acciones.EXITOSA, "Baja subservicio realizada");
                                        }
                                        else
                                        {
                                            dtResultado.Rows.Add(idParteActual, (int)Aplicaciones_Externas.Estado_Acciones.FALLIDA, "Error al bajar sub servicio");
                                        }
                                    }

                                }
                                else if(Convert.ToInt32(drParte["idOperacion"]) == (int)Partes_Operaciones.BAJA)
                                {
                                    dtFullData = oCass.getFullDataUser(Convert.ToInt32(drParte["idUsuServ"]), 0, (int)Cass.FILTROS_GET_DATA.ID_USUARIO_SERVICIO);
                                    if (dtFullData.Rows.Count == 0)
                                    {
                                        dtFullData.Clear();
                                        dtFullData = oCass.getFullDataUser(0, Convert.ToInt32(drParte["idParte"]), (int)Cass.FILTROS_GET_DATA.ID_PARTE);
                                    }
                                    dtOperacionesCass = oCass.GenerarDtTarjetas(dtFullData);
                                    //ENVIO LA TABLA DE TARJETAS CON EL ID_TIPO FACTURACION QUE SIEMPRE VA A SER EL MISMO EN CASO DE UN PARTE
                                    if (dtOperacionesCass.Rows.Count > 0)
                                    {
                                       if(oCass.GenerarDesactivacionDePaquetes(dtOperacionesCass, Convert.ToInt32(drParte["idUsuario"]), out ResultadoOpCass))
                                       {
                                          if(oCass.GenerarEliminacionUsuario(dtOperacionesCass, Convert.ToInt32(drParte["idUsuario"]), out ResultadoOpCass))
                                          {
                                              dtResultado.Rows.Add(idParteActual, (int)Aplicaciones_Externas.Estado_Acciones.EXITOSA, "Operaciones realizadas correctamente");
                                          }
                                          else
                                          {
                                              dtResultado.Rows.Add(idParteActual, (int)Aplicaciones_Externas.Estado_Acciones.FALLIDA, "Desactivo paquetes pero no elimino usuario");
                                          }
                                       }
                                       else
                                       {
                                          dtResultado.Rows.Add(idParteActual, (int)Aplicaciones_Externas.Estado_Acciones.FALLIDA, "Falla al bajar los paquetes y eliminar el usuario");
                                       }

                                    }
                                }
                                //LIMPIO la tabla de paquete de cass
                                oCass.LimpiarDtPaquetesCass();
                                //LIMPIO LA TABLA DE INFORMACION ESTATICA
                                dtOperacionesCass.Clear();
                            }
                            else if(Convert.ToInt32(drParte["idAppExterna"]) == (int)Aplicaciones_Externas.Aplicacion_Externa.ISP)
                            {
                                DtServiciosAsociados.Clear();
                                DtServiciosAsociados = oUsuarioServicio.getFullDataUserServ(Convert.ToInt32(drParte["idUsuario"]));
                                if (Convert.ToInt32(drParte["idOperacion"]) == (int)Partes_Operaciones.CONEXION)
                                {
                                    if (DtServiciosAsociados.Rows.Count > 0)
                                    {
                                        oIsp.GenerarActivacion(DtServiciosAsociados, out ResultadoOpIsp, out estadoOpIsp);
                                        dtResultado.Rows.Add(idParteActual, (int)estadoOpIsp, ResultadoOpIsp);
                                        ResultadoOpIsp = "ISP Activado correctamente";
                                    }
                                    else
                                    {
                                        dtResultado.Rows.Add(idParteActual, (int)Aplicaciones_Externas.Estado_Acciones.FALLIDA, "No hay servicios asocaidos al ISP para este parte.");
                                        ResultadoOpIsp = "No hay servicios asocaidos al ISP para este parte.";
                                        resultadoFinal = ResultadoOpIsp;
                                    }
                                }
                                else if (Convert.ToInt32(drParte["idOperacion"]) == (int)Partes_Operaciones.AGREGAR_SUBSERVICIO)
                                {

                                }
                                else if (Convert.ToInt32(drParte["idOperacion"]) == (int)Partes_Operaciones.RECONEXION)
                                {
                                    if (DtServiciosAsociados.Rows.Count > 0)
                                    {
                                        oIsp.generarReactivaciondeServicioIsp(DtServiciosAsociados, out ResultadoOpIsp, out estadoOpIsp);
                                        dtResultado.Rows.Add(idParteActual, (int)estadoOpIsp, ResultadoOpIsp);
                                        ResultadoOpIsp = "ISP reactivado correctamente";
                                    }
                                    else
                                    {
                                        dtResultado.Rows.Add(idParteActual, (int)Aplicaciones_Externas.Estado_Acciones.FALLIDA, "No hay servicios asocaidos al ISP para este parte.");
                                        ResultadoOpIsp = "No hay servicios asocaidos al ISP para este parte.";
                                        resultadoFinal = ResultadoOpIsp;
                                    }
                                }
                                else if (Convert.ToInt32(drParte["idOperacion"]) == (int)Partes_Operaciones.CORTE)
                                {
                                    if (DtServiciosAsociados.Rows.Count > 0)
                                    {
                                        oIsp.GenerarCorteDeServicioIsp(DtServiciosAsociados, out ResultadoOpIsp, out estadoOpIsp);
                                        dtResultado.Rows.Add(idParteActual, (int)estadoOpIsp, ResultadoOpIsp);
                                        ResultadoOpIsp = "ISP reactivado correctamente";
                                    }
                                    else
                                    {
                                        dtResultado.Rows.Add(idParteActual, (int)Aplicaciones_Externas.Estado_Acciones.FALLIDA, "No hay servicios asocaidos al ISP para este parte.");
                                        ResultadoOpIsp = "No hay servicios asocaidos al ISP para este parte.";
                                        resultadoFinal = ResultadoOpIsp;
                                    }
                                }
                                else if (Convert.ToInt32(drParte["idOperacion"]) == (int)Partes_Operaciones.QUITAR_SUBSERVICIO)
                                {

                                }
                                else if (Convert.ToInt32(drParte["idOperacion"]) == (int)Partes_Operaciones.BAJA)
                                {
                                    if (DtServiciosAsociados.Rows.Count > 0)
                                    {
                                        oIsp.generarBajaISP(DtServiciosAsociados, out ResultadoOpIsp, out estadoOpIsp);
                                        dtResultado.Rows.Add(idParteActual, (int)estadoOpIsp, ResultadoOpIsp);
                                        ResultadoOpIsp = "ISP reactivado correctamente";
                                    }
                                    else
                                    {
                                        dtResultado.Rows.Add(idParteActual, (int)Aplicaciones_Externas.Estado_Acciones.FALLIDA, "No hay servicios asocaidos al ISP para este parte.");
                                        ResultadoOpIsp = "No hay servicios asocaidos al ISP para este parte.";
                                        resultadoFinal = ResultadoOpIsp;
                                    }
                                }
                            }
                            ResultadoTotal += $"{ResultadoOpCass}";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                oCon.DesConectar();
                throw ex;
            }
            resultadoFinal = ResultadoTotal;
            return dtResultado;
        }

        public Int32 gestionarAppExternaIdParte(int idParte, out string resultadoFinal, out string resultadoFinalAccion, DateTime? fecha_programado = null)
        {
            //DECLARACIONES DE VARIABLES INTERNAS DEL METODO
            Partes_Usuarios_Servicios oParteUsuarioServicio = new Partes_Usuarios_Servicios();
            DataTable dtDatosParte = new DataTable();
            DataTable DtServiciosAsociados = new DataTable();
            bool generoAccionCorrectamente = false;
            
            //DECLARACIONES PARA EL CASS
            DataTable dtAplicacionesFiltradas = Tablas.DataCass;
            Cass oCass;
            oCass = new Cass(Convert.ToInt32(dtAplicacionesFiltradas.Rows[0]["Id"]));
            DataTable dtOperacionesCass = new DataTable();
            DataTable dtFullData = new DataTable();
            string ResultadoOpCass = "";
            string resultadoBajasCass = "";
            string ResultadoTotal = "";

            //DECLARACIONES PARA EL ISP
            string ResultadoOpIsp = "";
            string ResultadoTotalIsp = "";
            int estadoOpIsp = 0;
            try
            {
                dtDatosParte = this.getDatosParte(idParte);
                if (dtDatosParte.Rows.Count > 0)
                {
                    foreach (DataRow drParte in dtDatosParte.Rows)
                    {
                        ResultadoOpCass = "";
                        resultadoBajasCass = "";
                        if (Convert.ToInt32(drParte["idAppExterna"]) == (int)Aplicaciones_Externas.Aplicacion_Externa.CASS)
                        {
                            if (Convert.ToInt32(drParte["idOperacion"]) == (int)Partes_Operaciones.CONEXION)
                            {
                                DtServiciosAsociados.Clear();
                                dtOperacionesCass.Clear();
                                DtServiciosAsociados = oParteUsuarioServicio.ListarServiciosPorParte(Convert.ToInt32(drParte["idParte"]), Partes_Usuarios_Servicios.CONDICION_REQ_EQUIPOS.TODOS);
                                dtOperacionesCass = oCass.GenerarDtTarjetas(DtServiciosAsociados);
                                if(dtOperacionesCass.Rows.Count == 0)
                                {
                                    dtOperacionesCass.Clear();
                                    dtOperacionesCass = oCass.GenerarDtPreAsignacion(DtServiciosAsociados);
                                }
                                if (dtOperacionesCass.Rows.Count > 0)
                                {
                                    bool contieneServicioPrepago = false;
                                    bool realizoOk = false;

                                    //VERIFICO QUE TENGA SERVICIOS PREPAGOS PARA VER SI LO ACTIVA EN EL MOMENTO O NO.
                                    foreach (DataRow drOperacion in dtOperacionesCass.Rows)
                                    {
                                        if(Convert.ToInt32(drOperacion["idmodalidad"]) == (int)Servicios._Modalidad.DIA)
                                        {
                                            contieneServicioPrepago = true;
                                            break;
                                        }
                                    }

                                    //SI CONTIENE SERVICIOS PREPAGOS CREO UNA TABLA PARA LOS PREPAGOS Y OTRA PARA LOS SERVICIOS NO PREPAGOS
                                    //POR LO CUAL VA A GENERAR LA ACTIVACION POR SEPARADO.
                                    if (contieneServicioPrepago)
                                    {
                                        DataTable dtAuxPrepago = new DataTable();
                                        DataView dvServicioPrepago = new DataView();

                                        DataTable dtAuxOtrasModalidades = new DataTable();
                                        DataView dvOtrasModalidades = new DataView();

                                        dvServicioPrepago = dtOperacionesCass.DefaultView;
                                        dvServicioPrepago.RowFilter = String.Format("idModalidad = {0}", (int)Servicios._Modalidad.DIA);
                                        dtAuxPrepago = dvServicioPrepago.ToTable();

                                        dvOtrasModalidades = dtOperacionesCass.DefaultView;
                                        dvOtrasModalidades.RowFilter = String.Format("idModalidad <> {0}", (int)Servicios._Modalidad.DIA);
                                        dtAuxOtrasModalidades = dvOtrasModalidades.ToTable(); 

                                        if (dtAuxPrepago.Rows.Count > 0)
                                        {
                                            if (fecha_programado.HasValue)
                                            {
                                                foreach(DataRow drAux in dtAuxPrepago.Rows)
                                                {
                                                    DateTime fecha_inicio_subser;
                                                    fecha_inicio_subser = Convert.ToDateTime(drAux["fecha_inicio"]);
                                                    if(fecha_inicio_subser.Date <= fecha_programado.Value.Date)
                                                    {
                                                        if (oCass.GenerarActivacion(dtAuxPrepago, Convert.ToInt32(drParte["idUsuario"]), out ResultadoOpCass, true))
                                                            realizoOk = true;
                                                    }
                                                }

                                            }
                                        }
                                        if(dtAuxOtrasModalidades.Rows.Count > 0)
                                        {
                                            if (oCass.GenerarActivacion(dtAuxOtrasModalidades, Convert.ToInt32(drParte["idUsuario"]), out ResultadoOpCass))
                                                realizoOk = true;
                                        }
                                    }
                                    else
                                    {
                                        if (oCass.GenerarActivacion(dtOperacionesCass, Convert.ToInt32(drParte["idUsuario"]), out ResultadoOpCass))
                                            realizoOk = true;
                                    }

                                    if(realizoOk == true)
                                    {
                                        generoAccionCorrectamente = true;
                                        resultadoBajasCass = "Cass activado correctamente.";
                                    }
                                    else
                                        resultadoBajasCass = "Falla al activar en el cass.";
                                }
                            }
                            else if(Convert.ToInt32(drParte["idOperacion"]) == (int)Partes_Operaciones.AGREGAR_SUBSERVICIO)
                            {
                                dtFullData.Clear();
                                dtFullData = oCass.getFullDataUser(Convert.ToInt32(drParte["idUsuServ"]), 0, (int)Cass.FILTROS_GET_DATA.ID_USUARIO_SERVICIO);
                                if (dtFullData.Rows.Count == 0)
                                {
                                    dtFullData.Clear();
                                    dtFullData = oCass.getFullDataUser(0, Convert.ToInt32(drParte["idParte"]), (int)Cass.FILTROS_GET_DATA.ID_PARTE);
                                }
                                if (dtFullData.Rows.Count > 0)
                                {
                                    if (oCass.actualizarCass(dtFullData, Convert.ToInt32(drParte["idUsuario"]), out ResultadoOpCass))
                                    {
                                        generoAccionCorrectamente = true;
                                        resultadoBajasCass = "Paquete agregado correctamente.";
                                    }
                                    else
                                        resultadoBajasCass = "Falla al agregar en cass el paquete.";

                                }
                            }
                            else if (Convert.ToInt32(drParte["idOperacion"]) == (int)Partes_Operaciones.RECONEXION)
                            {

                                DtServiciosAsociados.Clear();
                                dtOperacionesCass.Clear();
                                DtServiciosAsociados = oParteUsuarioServicio.ListarServiciosPorParte(Convert.ToInt32(drParte["idParte"]), Partes_Usuarios_Servicios.CONDICION_REQ_EQUIPOS.TODOS);
                                dtOperacionesCass = oCass.GenerarDtTarjetas(DtServiciosAsociados);
                                if (dtOperacionesCass.Rows.Count == 0)
                                {
                                    dtOperacionesCass.Clear();
                                    dtOperacionesCass = oCass.GenerarDtPreAsignacion(DtServiciosAsociados);
                                }
                                if (dtOperacionesCass.Rows.Count > 0)
                                {
                                    bool contieneServicioPrepago = false;
                                    bool realizoOk = false;

                                    //VERIFICO QUE TENGA SERVICIOS PREPAGOS PARA VER SI LO ACTIVA EN EL MOMENTO O NO.
                                    foreach (DataRow drOperacion in dtOperacionesCass.Rows)
                                    {
                                        if (Convert.ToInt32(drOperacion["idmodalidad"]) == (int)Servicios._Modalidad.DIA)
                                        {
                                            contieneServicioPrepago = true;
                                        }
                                    }

                                    //SI CONTIENE SERVICIOS PREPAGOS CREO UNA TABLA PARA LOS PREPAGOS Y OTRA PARA LOS SERVICIOS NO PREPAGOS
                                    //POR LO CUAL VA A GENERAR LA ACTIVACION POR SEPARADO.
                                    if (contieneServicioPrepago)
                                    {
                                        DataTable dtAuxPrepago = new DataTable();
                                        DataView dvServicioPrepago = new DataView();

                                        DataTable dtAuxOtrasModalidades = new DataTable();
                                        DataView dvOtrasModalidades = new DataView();

                                        dvServicioPrepago = dtOperacionesCass.DefaultView;
                                        dvServicioPrepago.RowFilter = String.Format("idModalidad = {0}", (int)Servicios._Modalidad.DIA);
                                        dtAuxPrepago = dvServicioPrepago.ToTable();

                                        dvOtrasModalidades = dtOperacionesCass.DefaultView;
                                        dvOtrasModalidades.RowFilter = String.Format("idModalidad <> {0}", (int)Servicios._Modalidad.DIA);
                                        dtAuxOtrasModalidades = dvOtrasModalidades.ToTable();

                                        if (dtAuxPrepago.Rows.Count > 0)
                                        {
                                            if (fecha_programado.HasValue)
                                            {
                                                foreach (DataRow drAux in dtAuxPrepago.Rows)
                                                {
                                                    DateTime fecha_inicio_subser;
                                                    fecha_inicio_subser = Convert.ToDateTime(drAux["fecha_inicio"]);
                                                    if (fecha_inicio_subser.Date <= fecha_programado.Value.Date)
                                                    {
                                                        if (oCass.GenerarActivacion(dtAuxPrepago, Convert.ToInt32(drParte["idUsuario"]), out ResultadoOpCass, true))
                                                            realizoOk = true;
                                                    }
                                                }

                                            }
                                        }
                                        if (dtAuxOtrasModalidades.Rows.Count > 0)
                                        {
                                            if (oCass.GenerarActivacion(dtAuxOtrasModalidades, Convert.ToInt32(drParte["idUsuario"]), out ResultadoOpCass))
                                                realizoOk = true;
                                        }
                                    }
                                    else
                                    {
                                        if (oCass.ReactivarPaquetesAbonado(Convert.ToInt32(drParte["idUsuario"]), out ResultadoOpCass))
                                            realizoOk = true;
                                    }

                                    if (realizoOk == true)
                                    {
                                        generoAccionCorrectamente = true;
                                        resultadoBajasCass = "Abonado reanudado correctamente.";
                                    }
                                    else
                                        resultadoBajasCass = "Falla al reanudar en el cass.";
                                }
                            }
                            else if (Convert.ToInt32(drParte["idOperacion"]) == (int)Partes_Operaciones.CORTE)
                            {

                                DtServiciosAsociados.Clear();
                                dtOperacionesCass.Clear();
                                DtServiciosAsociados = oParteUsuarioServicio.ListarServiciosPorParte(Convert.ToInt32(drParte["idParte"]), Partes_Usuarios_Servicios.CONDICION_REQ_EQUIPOS.TODOS);
                                dtOperacionesCass = oCass.GenerarDtTarjetas(DtServiciosAsociados);
                                if (dtOperacionesCass.Rows.Count == 0)
                                {
                                    dtOperacionesCass.Clear();
                                    dtOperacionesCass = oCass.GenerarDtPreAsignacion(DtServiciosAsociados);
                                }
                                if (dtOperacionesCass.Rows.Count > 0)
                                {
                                    bool contieneServicioPrepago = false;
                                    bool realizoOk = false;

                                    //VERIFICO QUE TENGA SERVICIOS PREPAGOS PARA VER SI LO ACTIVA EN EL MOMENTO O NO.
                                    foreach (DataRow drOperacion in dtOperacionesCass.Rows)
                                    {
                                        if (Convert.ToInt32(drOperacion["idmodalidad"]) == (int)Servicios._Modalidad.DIA)
                                        {
                                            contieneServicioPrepago = true;
                                        }
                                    }

                                    //SI CONTIENE SERVICIOS PREPAGOS CREO UNA TABLA PARA LOS PREPAGOS Y OTRA PARA LOS SERVICIOS NO PREPAGOS
                                    //POR LO CUAL VA A GENERAR LA ACTIVACION POR SEPARADO.
                                    if (contieneServicioPrepago)
                                    {
                                        DataTable dtAuxPrepago = new DataTable();
                                        DataView dvServicioPrepago = new DataView();

                                        DataTable dtAuxOtrasModalidades = new DataTable();
                                        DataView dvOtrasModalidades = new DataView();

                                        dvServicioPrepago = dtOperacionesCass.DefaultView;
                                        dvServicioPrepago.RowFilter = String.Format("idModalidad = {0}", (int)Servicios._Modalidad.DIA);
                                        dtAuxPrepago = dvServicioPrepago.ToTable();

                                        dvOtrasModalidades = dtOperacionesCass.DefaultView;
                                        dvOtrasModalidades.RowFilter = String.Format("idModalidad <> {0}", (int)Servicios._Modalidad.DIA);
                                        dtAuxOtrasModalidades = dvOtrasModalidades.ToTable();

                                        if (dtAuxPrepago.Rows.Count > 0)
                                        {
                                            if (fecha_programado.HasValue)
                                            {
                                                foreach (DataRow drAux in dtAuxPrepago.Rows)
                                                {
                                                    DateTime fecha_inicio_subser;
                                                    fecha_inicio_subser = Convert.ToDateTime(drAux["fecha_inicio"]);
                                                    if (fecha_inicio_subser.Date <= fecha_programado.Value.Date)
                                                    {
                                                        if (oCass.GenerarDesactivacionDePaquetes(dtAuxPrepago, Convert.ToInt32(drParte["idUsuario"]), out ResultadoOpCass))
                                                            realizoOk = true;
                                                    }
                                                }

                                            }
                                        }
                                        if(dtAuxOtrasModalidades.Rows.Count > 0)
                                        {
                                            if (oCass.PausarPaquetesAbonado(Convert.ToInt32(drParte["idUsuario"]), out ResultadoOpCass))
                                                realizoOk = true;
                                        }
                                    }
                                    else
                                    {
                                        if (oCass.PausarPaquetesAbonado(Convert.ToInt32(drParte["idUsuario"]), out ResultadoOpCass))
                                            realizoOk = true;
                                    }

                                    if (realizoOk == true)
                                    {
                                        generoAccionCorrectamente = true;
                                        resultadoBajasCass = "Cass Pausado correctamente.";
                                    }
                                    else
                                        resultadoBajasCass = "Falla al pausar en el cass.";
                                }

                            }
                            else if (Convert.ToInt32(drParte["idOperacion"]) == (int)Partes_Operaciones.QUITAR_SUBSERVICIO)
                            {
                                dtFullData.Clear();
                                dtFullData = oCass.getFullDataUser(Convert.ToInt32(drParte["idUsuServ"]), 0, (int)Cass.FILTROS_GET_DATA.ID_USUARIO_SERVICIO);
                                if (dtFullData.Rows.Count == 0)
                                {
                                    dtFullData.Clear();
                                    dtFullData = oCass.getFullDataUser(0, Convert.ToInt32(drParte["idParte"]), (int)Cass.FILTROS_GET_DATA.ID_PARTE);
                                }
                                if (dtFullData.Rows.Count > 0)
                                {
                                    if (oCass.actualizarCass(dtFullData, Convert.ToInt32(drParte["idUsuario"]), out ResultadoOpCass))
                                    {
                                        generoAccionCorrectamente = true;
                                        resultadoBajasCass = "Paquete eliminado correctamente del cass.";
                                    }
                                    else
                                        resultadoBajasCass = "No se pudo quitar el paquete del cass.";
                                }
                            }
                            else if (Convert.ToInt32(drParte["idOperacion"]) == (int)Partes_Operaciones.BAJA)
                            {
                                dtFullData.Clear();
                                dtFullData = oCass.getFullDataUser(Convert.ToInt32(drParte["idUsuServ"]), 0, (int)Cass.FILTROS_GET_DATA.ID_USUARIO_SERVICIO);
                                if (dtFullData.Rows.Count == 0)
                                {
                                    dtFullData.Clear();
                                    dtFullData = oCass.getFullDataUser(0, Convert.ToInt32(drParte["idParte"]), (int)Cass.FILTROS_GET_DATA.ID_PARTE);
                                }
                                dtOperacionesCass = oCass.GenerarDtTarjetas(dtFullData);
                                //ENVIO LA TABLA DE TARJETAS CON EL ID_TIPO FACTURACION QUE SIEMPRE VA A SER EL MISMO EN CASO DE UN PARTE
                                if (dtOperacionesCass.Rows.Count > 0)
                                {

                                    if (oCass.GenerarDesactivacionDePaquetes(dtOperacionesCass, Convert.ToInt32(drParte["idUsuario"]), out ResultadoOpCass))
                                    {
                                        generoAccionCorrectamente = true;
                                        if (oCass.GenerarEliminacionUsuario(dtOperacionesCass, Convert.ToInt32(drParte["idUsuario"]), out ResultadoOpCass))
                                        {
                                            generoAccionCorrectamente = true;
                                            resultadoBajasCass = "Baja realizada correctamente en el cass.";
                                        }
                                        else
                                        {
                                            generoAccionCorrectamente = false;
                                            resultadoBajasCass = "Desactivo paquetes pero no elimino el usuario del cass.";
                                        }
                                    }
                                    else
                                    {
                                        generoAccionCorrectamente = false;
                                        resultadoBajasCass = "No se pudo realizar la baja correctamente en el cass.";
                                    }
                                }
                            }
                            //LIMPIO la tabla de paquete de cass
                            oCass.LimpiarDtPaquetesCass();
                            //LIMPIO LA TABLA DE INFORMACION ESTATICA
                            dtOperacionesCass.Clear();
                        }
                        else if (Convert.ToInt32(drParte["idAppExterna"]) == (int)Aplicaciones_Externas.Aplicacion_Externa.ISP)
                        {
                            DtServiciosAsociados.Clear();
                            DtServiciosAsociados = oUsuarioServicio.getFullDataUserServ(Convert.ToInt32(drParte["idUsuario"]));
                            if (Convert.ToInt32(drParte["idOperacion"]) == (int)Partes_Operaciones.CONEXION)
                            {
                                if (DtServiciosAsociados.Rows.Count > 0)
                                {
                                    if (oIsp.GenerarActivacion(DtServiciosAsociados, out ResultadoOpIsp, out estadoOpIsp))
                                    {
                                        generoAccionCorrectamente = true;
                                        ResultadoOpIsp = "ISP Activado correctamente";
                                        
                                    }
                                    else
                                    {
                                        generoAccionCorrectamente = false;
                                        ResultadoOpIsp = "Hubo una falla al activar en el ISP";
                                    }
                                }
                                else
                                {
                                    generoAccionCorrectamente = false;
                                    ResultadoOpIsp = "No hay servicios asocaidos al ISP para este parte.";
                                    resultadoFinal = ResultadoOpIsp;
                                }
                            }
                            else if (Convert.ToInt32(drParte["idOperacion"]) == (int)Partes_Operaciones.RECONEXION)
                            {
                                if (DtServiciosAsociados.Rows.Count > 0)
                                {
                                    if (oIsp.generarReactivaciondeServicioIsp(DtServiciosAsociados, out ResultadoOpIsp, out estadoOpIsp))
                                    {
                                        generoAccionCorrectamente = true;
                                        ResultadoOpIsp = "ISP reactivado correctamente";
                                    }
                                    else
                                    {
                                        generoAccionCorrectamente = false;
                                        ResultadoOpIsp = "Hubo una falla al reactivar en el ISP";
                                    }
                                }
                                else
                                {
                                    generoAccionCorrectamente = false;
                                    ResultadoOpIsp = "No hay servicios asocaidos al ISP para este parte.";
                                    resultadoFinal = ResultadoOpIsp;
                                }
                            }
                            else if (Convert.ToInt32(drParte["idOperacion"]) == (int)Partes_Operaciones.CORTE)
                            {
                                if (DtServiciosAsociados.Rows.Count > 0)
                                {
                                    if (oIsp.GenerarCorteDeServicioIsp(DtServiciosAsociados, out ResultadoOpIsp, out estadoOpIsp))
                                    {
                                        generoAccionCorrectamente = true;
                                        ResultadoOpIsp = "ISP cortado correctamente";
                                    }
                                    else
                                    {
                                        generoAccionCorrectamente = false;
                                        ResultadoOpIsp = "Hubo una falla al cortar en el ISP";
                                    }
                                }
                                else
                                {
                                    generoAccionCorrectamente = false;
                                    ResultadoOpIsp = "No hay servicios asocaidos al ISP para este parte.";
                                    resultadoFinal = ResultadoOpIsp;
                                }
                            }
                            else if (Convert.ToInt32(drParte["idOperacion"]) == (int)Partes_Operaciones.BAJA)
                            {
                                if (DtServiciosAsociados.Rows.Count > 0)
                                {
                                    if (oIsp.generarBajaISP(DtServiciosAsociados, out ResultadoOpIsp, out estadoOpIsp))
                                    {
                                        generoAccionCorrectamente = true;
                                        ResultadoOpIsp = "ISP cortado correctamente";
                                    }
                                    else
                                    {
                                        generoAccionCorrectamente = false;
                                        ResultadoOpIsp = "Hubo una falla al cortar en el ISP";
                                    }
                                }
                                else
                                {
                                    generoAccionCorrectamente = false;
                                    ResultadoOpIsp = "No hay servicios asocaidos al ISP para este parte.";
                                    resultadoFinal = ResultadoOpIsp;
                                }
                            }
                        }                   
                        ResultadoTotal += $"\n{ResultadoOpIsp}";

                    }
                }
                
            }
            catch (Exception)
            {
                oCon.DesConectar();
                throw;
            }
            resultadoFinal = ResultadoTotal;
            resultadoFinalAccion = resultadoBajasCass;
            if (generoAccionCorrectamente == true)
                return 1;
            else
                return 0;
        }
        
        public Int32 getFallaPorIdServicioTipoYOperacion(int id_operacion , int id_servicio_tipo)
        {
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                oCon.CrearComando($"SELECT id FROM partes_fallas WHERE id_servicios_tipos = {id_servicio_tipo} and id_partes_operaciones={id_operacion} and borrado=0");
                dt = oCon.Tabla();
                oCon.DesConectar();
            }
            catch (Exception)
            {
                oCon.DesConectar();
                throw;
            }
            if (dt.Rows.Count > 0)
                return Convert.ToInt32(dt.Rows[0]["id"]);
            else
                return 0;
        }

        public DataTable getPartesUsuarioLocacionPrepagos(int id_usuario, int id_locacion, int id_usuario_servicio ,int parteOperacion)
        {
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                oCon.CrearComando("SELECT partes.Id_Usuarios AS id_usu, partes.id AS idParte, partes.Id_Usuarios_Locaciones AS id_usu_locacion, " +
                    "partes.Id_Partes_Estados AS idParteEstado, partes_operaciones.id AS idOperacion, " +
                    "partes_operaciones.Nombre AS Operacion, partes.Fecha_Programado AS Programado, partes.id_usuarios_ctacte as IdCtaCte " +
                    "FROM partes_usuarios_servicios " +
                    "LEFT JOIN partes ON partes_usuarios_servicios.Id_parte = partes.id " +
                    "LEFT JOIN usuarios ON partes.Id_Usuarios = usuarios.id " +
                    "LEFT JOIN usuarios_locaciones ON partes.Id_Usuarios_Locaciones = usuarios_locaciones.id " +
                    "LEFT JOIN partes_fallas ON partes.Id_Partes_Fallas = partes_fallas.id " +
                    "LEFT JOIN partes_operaciones ON partes_fallas.Id_Partes_Operaciones = partes_operaciones.id " +
                    "LEFT JOIN usuarios_servicios ON partes_usuarios_servicios.Id_usuarios_servicios = usuarios_servicios.id " +
                    "LEFT JOIN servicios ON usuarios_servicios.Id_Servicios = servicios.id " +
                    $"WHERE partes.borrado = 0 AND usuarios.id = {id_usuario} AND usuarios_locaciones.Id = {id_locacion} AND partes_operaciones.Id ={parteOperacion} " +
                    $"AND usuarios_servicios.borrado = 0 AND servicios.Id_Servicios_Modalidad = {(int)Servicios._Modalidad.DIA} AND usuarios_servicios.id = {id_usuario_servicio} and partes.id_partes_estados IN ({(int)Partes.Partes_Estados.PENDIENTE_DE_ASIGNACION_DE_TECNICO,(int)Partes.Partes_Estados.ASIGNADO}); ");
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

