using CapaDatos;
using System;
using System.Data;

namespace CapaNegocios
{
    public class Notificaciones_Destinatarios
    {
        private Conexion oCon = new Conexion();

        public Int32 Id { get; set; }
        public Int32 Id_Notificacion_Origen { get; set; }
        public Int32 Id_Tipo_Destinatario { get; set; }
        public Int32 Id_Destinatario { get; set; }
        public Int32 Id_Notificacion_Respusta { get; set; }
        public Int32 Id_Estado_Notificacion_Destinatario { get; set; }
        public Int32 Borrado { get; set; }

        public enum Tipo_Destinatario
        {
            AREA = 1,
            PERSONAL = 2,
            PUNTO_GESTION = 3,
            CAJA = 4
        }

        public enum Estado_Notificacion
        {
            PENDIENTE = 1,
            VISTO = 2,
            RESUELTO = 3,
            VENCIDO = 4
        }

        public void Guardar(Notificaciones_Destinatarios oNotDestinatarios)
        {
            try
            {
                oCon.Conectar();

                oCon.CrearComando("INSERT INTO Notificaciones_Destinatarios (Id_Notificacion_Origen,Id_Tipo_Destinatario,Id_Destinatario,Id_Estado_Notificacion_Destinatario) VALUES (@IdNotificacionOrigen,@IdTipoDestinatario,@IdDestinatario,@IdEstadoNotificacionDestinatario)");
                oCon.AsignarParametroEntero("@IdNotificacionOrigen", oNotDestinatarios.Id_Notificacion_Origen);
                oCon.AsignarParametroEntero("@IdTipoDestinatario", oNotDestinatarios.Id_Tipo_Destinatario);
                oCon.AsignarParametroEntero("@IdDestinatario", oNotDestinatarios.Id_Destinatario);
                oCon.AsignarParametroEntero("@IdEstadoNotificacionDestinatario", oNotDestinatarios.Id_Estado_Notificacion_Destinatario);

                oCon.ComenzarTransaccion();
                oCon.EjecutarComando();
                oCon.ConfirmarTransaccion();
                oCon.DesConectar();

            }
            catch (Exception)
            {
                oCon.DesConectar();
                throw;
            }
        }

        public DataTable Listar(int idNot)
        {
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                oCon.CrearComando("SELECT vw_notificaciones_destinatarios.* from vw_notificaciones_destinatarios WHERE Id_Notificacion_Origen=@idOrigen");
                oCon.AsignarParametroEntero("@idOrigen", idNot);
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

        public DataTable ListarPosiblesDestinatarios()
        {
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                oCon.CrearComando("SELECT * from vw_destinatarios");
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

        public void ActualizarEstado(int idNotificacionDestinatario, int idEstado)
        {
            try
            {
                oCon.Conectar();
                oCon.CrearComando("UPDATE Notificaciones_Destinatarios SET id_estado_notificacion_destinatario=@idEstadoNotificacion, fecha_visto=@fecha WHERE id=@idNotificacionDestinatario");
                oCon.AsignarParametroEntero("@idEstadoNotificacion", idEstado);
                oCon.AsignarParametroFecha("@fecha", DateTime.Now);
                oCon.AsignarParametroEntero("@idNotificacionDestinatario", idNotificacionDestinatario);
                oCon.EjecutarComando();
                oCon.DesConectar();
            }
            catch (Exception)
            {
                oCon.DesConectar();
                throw;
            }
        }

        public int ControlarNotificacionesActivas(int idPersonal, int idArea, int idPuntoGestion)
        {
            int respuesta = 0;
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                oCon.CrearComando(String.Format("select id, (select id_prioridad from notificaciones where id=vw_notificaciones_destinatarios.id_notificacion_origen)as idprioridad from vw_notificaciones_destinatarios where ((id_tipo_destinatario={0} and id_destinatario={1}) or (id_tipo_destinatario={2} and id_destinatario={3}) or ((id_tipo_destinatario={4} or id_tipo_destinatario={5}) and id_destinatario={6})) and id_estado_notificacion_destinatario={7} and id_estado_notificacion_origen!={8}", Convert.ToInt32(Tipo_Destinatario.PERSONAL), idPersonal, Convert.ToInt32(Tipo_Destinatario.AREA), idArea, Convert.ToInt32(Tipo_Destinatario.PUNTO_GESTION), Convert.ToInt32(Tipo_Destinatario.CAJA), idPuntoGestion, Convert.ToInt32(Estado_Notificacion.PENDIENTE), Convert.ToInt32(Notificaciones.ESTADO_NOTIFICACION.CANCELADO)));
                dt = oCon.Tabla();
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow notificacion in dt.Rows)
                    {
                        if (Convert.ToInt32(notificacion["idprioridad"]) == Convert.ToInt32(Notificaciones.PRIORIDAD.ALTA))
                        {
                            respuesta = Convert.ToInt32(Notificaciones.PRIORIDAD.ALTA);
                            break;
                        }
                    }
                    if (respuesta == 0)
                    {
                        foreach (DataRow notificacion in dt.Rows)
                        {
                            if (Convert.ToInt32(notificacion["idprioridad"]) == Convert.ToInt32(Notificaciones.PRIORIDAD.MEDIA))
                            {
                                respuesta = Convert.ToInt32(Notificaciones.PRIORIDAD.MEDIA);
                                break;
                            }
                        }
                    }

                    if (respuesta == 0)
                        respuesta = Convert.ToInt32(Notificaciones.PRIORIDAD.BAJA);
                }
                else
                    respuesta = 0;
                oCon.DesConectar();
            }
            catch (Exception)
            {
                respuesta = 0;
                oCon.DesConectar();
                throw;
            }
            return respuesta;
        }

    }
}
