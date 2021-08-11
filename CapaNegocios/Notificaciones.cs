using CapaDatos;
using System;
using System.Data;


namespace CapaNegocios
{
    public class Notificaciones
    {
        private Conexion oCon = new Conexion();

        public Int32 Id { get; set; }
        public Int32 Id_Tipo_Notificacion { get; set; }
        public DateTime Fecha_Creacion { get; set; }
        public Int32 Id_Tipo_Emisor { get; set; }
        public String Mensaje { get; set; }
        public Int32 Id_Prioridad { get; set; }
        public DateTime Fecha_Limite { get; set; }
        public Int32 Id_Estado_Notificacion { get; set; }
        public Int32 Id_Area_Emisor { get; set; }
        public Int32 Id_Emisor { get; set; }
        public Int32 Ejecutar { get; set; }
        public Int32 ContemplarFechaLimite { get; set; }
        public Int32 Borrado { get; set; }

        public enum TIPO_EMISOR
        {
            AMBOS = 0,
            SISTEMA = 1,
            USUARIO = 2
        }

        public enum PRIORIDAD
        {
            TODAS = 0,
            ALTA = 1,
            MEDIA = 2,
            BAJA = 3
        }

        public enum ESTADO_NOTIFICACION
        {
            PENDIENTE = 1,
            VISTO = 2,
            RESUELTO = 3,
            VENCIDO = 4,
            CANCELADO = 5
        }

        public enum SITUACION
        {
            AMBAS = 0,
            ENVIADAS = 1,
            RECIBIDAS = 2
        }

        public enum EJECUTAR
        {
            No = 0,
            SI = 1
        }

        public int Guardar(Notificaciones oNotificaciones)
        {
            try
            {
                oCon.Conectar();
                //if (oNotificaciones.Id > 0)
                //{
                //    oCon.CrearComando("UPDATE Notificaciones SET Id_Tipo_Notificacion=@Id_Tipo_Notificacion,Fecha_Creacion=@Fecha_Creacion,Id_Tipo_Emisor=@Id_Tipo_Emisor,Mensaje=@Mensaje,Id_Prioridad=@Id_Prioridad,Fecha_Limite=@Fecha_Limite,Id_Estado_Notificacion=@Id_Estado_Notificacion,Id_Area_Emisor=@Id_Area_Emisor, ejecutar=@ejecutar WHERE Id=@id");
                //    oCon.AsignarParametroEntero("@id", oNotificaciones.Id);
                //}
                //else
                oCon.CrearComando("INSERT INTO notificaciones (fecha_creacion, id_tipo_emisor, id_emisor, mensaje, id_prioridad, fecha_limite, id_estado_notificacion, id_area_emisor, borrado, ejecutar, contemplar_fecha_limite) VALUES (@fecha_creacion, @id_tipo_emisor, @id_emisor, @mensaje, @id_prioridad, @fecha_limite, @id_estado_notificacion, @id_area_emisor, 0, @ejecutar, @contemplar_fecha_limite);SELECT @@IDENTITY");
                oCon.AsignarParametroFecha("@fecha_creacion", oNotificaciones.Fecha_Creacion);
                oCon.AsignarParametroEntero("@id_tipo_emisor", oNotificaciones.Id_Tipo_Emisor);
                oCon.AsignarParametroEntero("@id_emisor", oNotificaciones.Id_Emisor);
                oCon.AsignarParametroCadena("@mensaje", oNotificaciones.Mensaje);
                oCon.AsignarParametroEntero("@id_prioridad", oNotificaciones.Id_Prioridad);
                oCon.AsignarParametroFecha("@fecha_limite", oNotificaciones.Fecha_Limite);
                oCon.AsignarParametroEntero("@id_estado_notificacion", oNotificaciones.Id_Estado_Notificacion);
                oCon.AsignarParametroEntero("@id_area_emisor", oNotificaciones.Id_Area_Emisor);
                oCon.AsignarParametroEntero("@ejecutar", oNotificaciones.Ejecutar);
                oCon.AsignarParametroEntero("@contemplar_fecha_limite", oNotificaciones.ContemplarFechaLimite);
                if (oNotificaciones.Id == 0)
                    oNotificaciones.Id = oCon.EjecutarScalar();
                else
                    oCon.EjecutarComando();

                oCon.ConfirmarTransaccion();
                oCon.DesConectar();
            }
            catch (Exception)
            {
                oCon.CancelarTransaccion();
                oCon.DesConectar();
            }
            return oNotificaciones.Id;
        }

        public DataTable Listar(int idNotificacion, int idTipoEmisor, int idPrioridad, DateTime fechaDesde, DateTime fechaHasta)
        {
            string query = String.Empty;
            DataTable dt = new DataTable();
            if (idNotificacion > 0)
                query = "SELECT * from vw_notificaciones WHERE id = @id";
            else
            {
                query = String.Format("SELECT * from vw_notificaciones WHERE fecha_limite>='{0}' and fecha_limite<='{1}'", fechaDesde.ToString("yyyy-MM-dd"), fechaHasta.ToString("yyyy-MM-dd"));
                if (idTipoEmisor != Convert.ToInt32(TIPO_EMISOR.AMBOS))
                    query = String.Format("{0} and id_tipo_emisor={1}", query, idTipoEmisor);
                if (idPrioridad != Convert.ToInt32(PRIORIDAD.TODAS))
                    query = String.Format("{0} and id_prioridad={1}", query, idPrioridad);
            }

            try
            {
                oCon.Conectar();
                oCon.CrearComando(query);
                dt = oCon.Tabla();
                oCon.DesConectar();
            }
            catch (Exception)
            {
                oCon.DesConectar();
                throw;
            }
            query = String.Empty;
            return dt;
        }

        public DataTable ListarParaPersonalEspecifico(int idAreaPersonal, int idPersonal, int idTipoPersonal, int idTipoEmisor, int idPrioridad, DateTime fechaDesde, DateTime fechaHasta)
        {
            string query = String.Empty;
            DataTable dt = new DataTable();

            query = String.Format("SELECT vw_notificaciones.*, 1 as enviadarecibida, 0 as id_notificacion_origen, 0 as id_estado_notificacion_destinatario, 0 as id_destinatario from vw_notificaciones WHERE id_area_emisor={0} and id_emisor={1} and date(fecha_limite)>='{2}' and date(fecha_limite)<='{3}'", idAreaPersonal, idPersonal, fechaDesde.ToString("yyyy-MM-dd"), fechaHasta.ToString("yyyy-MM-dd"), Convert.ToInt32(ESTADO_NOTIFICACION.CANCELADO));

            if (idPrioridad != Convert.ToInt32(PRIORIDAD.TODAS))
                query = String.Format("{0} and id_prioridad={1}", query, idPrioridad);

            query = String.Format("{0} union select vw_notificaciones.*, 2 as enviadarecibida, notificaciones_recibidas.id_notificacion_origen, notificaciones_recibidas.id_estado_notificacion_destinatario, notificaciones_recibidas.id_destinatario from vw_notificaciones inner join (select id_notificacion_origen, id_estado_notificacion_destinatario, id as id_destinatario from vw_notificaciones_destinatarios where (id_tipo_destinatario = {1} and id_destinatario = {2}) or (id_tipo_destinatario = {5} and id_destinatario = {6}) or (id_tipo_destinatario = {7} and id_destinatario = {8}))notificaciones_recibidas on vw_notificaciones.id=notificaciones_recibidas.id_notificacion_origen where date(fecha_limite)>='{3}' and date(fecha_limite)<='{4}'", query, idTipoPersonal, idPersonal, fechaDesde.ToString("yyyy-MM-dd"), fechaHasta.ToString("yyyy-MM-dd"), Convert.ToInt32(Notificaciones_Destinatarios.Tipo_Destinatario.AREA), idAreaPersonal, Convert.ToInt32(Notificaciones_Destinatarios.Tipo_Destinatario.PUNTO_GESTION), Puntos_Cobros.Id_Punto, Convert.ToInt32(ESTADO_NOTIFICACION.CANCELADO));
            if (idTipoEmisor != Convert.ToInt32(TIPO_EMISOR.AMBOS))
                query = String.Format("{0} and id_tipo_emisor={1}", query, idTipoEmisor);
            if (idPrioridad != Convert.ToInt32(PRIORIDAD.TODAS))
                query = String.Format("{0} and id_prioridad={1}", query, idPrioridad);

            query = String.Format("{0} group by id, enviadarecibida", query);

            try
            {
                oCon.Conectar();
                oCon.CrearComando(query);
                dt = oCon.Tabla();
                oCon.DesConectar();
            }
            catch (Exception)
            {
                oCon.DesConectar();
                throw;
            }
            query = String.Empty;
            return dt;
        }

        public void ActualizarEstado(int idNotificacion, int idEstado)
        {
            int cantidadResueltos = 0;
            DataTable dt = new DataTable();

            try
            {
                oCon.Conectar();

                oCon.CrearComando("UPDATE Notificaciones SET id_estado_notificacion=@idEstadoNotificacion WHERE id=@idNotificacion");
                oCon.AsignarParametroEntero("@idEstadoNotificacion", idEstado);
                oCon.AsignarParametroEntero("@idNotificacion", idNotificacion);
                oCon.EjecutarComando();
                oCon.DesConectar();
            }
            catch (Exception)
            {
                oCon.DesConectar();
                throw;
            }
        }

        public int ActualizarEstadoDestinatarios(int idPersonal)
        {
            int respuesta = 1;
            DataTable dtNotificaciones = new DataTable();
            DataTable dtDestinatarios = new DataTable();
            DataTable dtAdjuntos = new DataTable();
            try
            {
                oCon.Conectar();
                oCon.CrearComando(String.Format("select * from vw_notificaciones where id_emisor={0} and borrado=0 and date(fecha_limite)>='{6}' and date(fecha_limite)<='{7}' union select vw_notificaciones.* from vw_notificaciones inner join (select id_notificacion_origen, id_estado_notificacion_destinatario from vw_notificaciones_destinatarios " +
                " where (id_tipo_destinatario = {1} and id_destinatario ={0}) or(id_tipo_destinatario ={2} and id_destinatario = {3}) or(id_tipo_destinatario = {4} and id_destinatario = {5}))notificaciones_recibidas on vw_notificaciones.id = notificaciones_recibidas.id_notificacion_origen where date(fecha_limite)>='{6}' and date(fecha_limite)<='{7}'", idPersonal, Convert.ToInt32(Notificaciones_Destinatarios.Tipo_Destinatario.PERSONAL), Convert.ToInt32(Notificaciones_Destinatarios.Tipo_Destinatario.AREA), Personal.Id_Area, Convert.ToInt32(Notificaciones_Destinatarios.Tipo_Destinatario.PUNTO_GESTION), Puntos_Cobros.Id_Punto, DateTime.Now.AddDays(-7).ToString("yyyy-MM-dd"), DateTime.Now.AddDays(7).ToString("yyyy-MM-dd")));
                dtNotificaciones = oCon.Tabla();
                if (dtNotificaciones.Rows.Count > 0)
                {
                    foreach (DataRow notificacion in dtNotificaciones.Rows)
                    {
                        dtDestinatarios.Clear();
                        dtAdjuntos.Clear();
                        oCon.CrearComando(String.Format("select * from vw_notificaciones_adjuntos where id_notificacion={0}", Convert.ToInt32(notificacion["id"])));
                        dtAdjuntos = oCon.Tabla();
                        oCon.CrearComando(String.Format("select * from vw_notificaciones_destinatarios where id_notificacion_origen={0}", Convert.ToInt32(notificacion["id"])));
                        dtDestinatarios = oCon.Tabla();
                        bool fueraDeTiempo = false;
                        int cantidadRealizados = 0;

                        if (dtAdjuntos.Rows.Count > 0)
                        {

                            foreach (DataRow adjunto in dtAdjuntos.Rows)
                            {
                                if ((Convert.ToInt32(adjunto["id_estado_realizacion"]) == Convert.ToInt32(Notificaciones_Adjuntos.ESTADO.PENDIENTE) && DateTime.Compare(Convert.ToDateTime(notificacion["fecha_limite"]), Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"))) < 0) || (Convert.ToInt32(adjunto["id_estado_realizacion"]) == Convert.ToInt32(Notificaciones_Adjuntos.ESTADO.REALIZADO) && DateTime.Compare(Convert.ToDateTime(adjunto["fecha_realizado"]), Convert.ToDateTime(notificacion["fecha_limite"])) > 0))
                                {//notificacion vencida
                                    fueraDeTiempo = true;
                                    break;
                                }
                                else if (Convert.ToInt32(adjunto["id_estado_realizacion"]) == Convert.ToInt32(Notificaciones_Adjuntos.ESTADO.REALIZADO))
                                    cantidadRealizados++;
                            }

                            if (fueraDeTiempo)
                            {
                                oCon.CrearComando("UPDATE notificaciones SET id_estado_notificacion=@idEstadoNotificacion WHERE id=@id");
                                oCon.AsignarParametroEntero("@idEstadoNotificacion", Convert.ToInt32(ESTADO_NOTIFICACION.VENCIDO));
                                oCon.AsignarParametroEntero("@id", Convert.ToInt32(notificacion["id"]));
                                oCon.EjecutarComando();

                                //foreach (DataRow destinatario in dtDestinatarios.Rows)
                                //{
                                //    oCon.CrearComando("UPDATE notificaciones_destinatarios SET id_estado_notificacion_destinatario=@idEstadoNotificacion WHERE id=@id");
                                //    oCon.AsignarParametroEntero("@idEstadoNotificacion", Convert.ToInt32(ESTADO_NOTIFICACION.VENCIDO));
                                //    oCon.AsignarParametroEntero("@id", Convert.ToInt32(destinatario["id"]));
                                //    oCon.EjecutarComando();
                                //}
                            }
                            else
                            {
                                if (cantidadRealizados == dtAdjuntos.Rows.Count)
                                {
                                    oCon.CrearComando("UPDATE notificaciones SET id_estado_notificacion=@idEstadoNotificacion WHERE id=@id");
                                    oCon.AsignarParametroEntero("@idEstadoNotificacion", Convert.ToInt32(ESTADO_NOTIFICACION.RESUELTO));
                                    oCon.AsignarParametroEntero("@id", Convert.ToInt32(notificacion["id"]));
                                    oCon.EjecutarComando();
                                }
                            }
                            cantidadRealizados = 0;
                        }
                        else
                        {
                            int cantidadVencidos = 0;
                            cantidadRealizados = 0;
                            foreach (DataRow destinatario in dtDestinatarios.Rows)
                            {
                                if ((Convert.ToInt32(destinatario["id_estado_notificacion_destinatario"]) == Convert.ToInt32(ESTADO_NOTIFICACION.PENDIENTE) && DateTime.Compare(Convert.ToDateTime(notificacion["fecha_limite"]), Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"))) < 0) || (Convert.ToInt32(destinatario["id_estado_notificacion_destinatario"]) == Convert.ToInt32(ESTADO_NOTIFICACION.VISTO) && DateTime.Compare(Convert.ToDateTime(destinatario["fecha_visto"]), Convert.ToDateTime(notificacion["fecha_limite"])) > 0))
                                {
                                    oCon.CrearComando("UPDATE notificaciones_destinatarios SET id_estado_notificacion_destinatario=@idEstadoNotificacion WHERE id=@id");
                                    oCon.AsignarParametroEntero("@idEstadoNotificacion", Convert.ToInt32(ESTADO_NOTIFICACION.VENCIDO));
                                    oCon.AsignarParametroEntero("@id", Convert.ToInt32(destinatario["id"]));
                                    oCon.EjecutarComando();
                                    cantidadVencidos++;
                                }
                                else if (Convert.ToInt32(destinatario["id_estado_notificacion_destinatario"]) == Convert.ToInt32(Notificaciones_Destinatarios.Estado_Notificacion.VISTO))
                                    cantidadRealizados++;
                            }

                            if (cantidadVencidos > 0)
                            {
                                oCon.CrearComando("UPDATE notificaciones SET id_estado_notificacion=@idEstadoNotificacion WHERE id=@id");
                                oCon.AsignarParametroEntero("@idEstadoNotificacion", Convert.ToInt32(ESTADO_NOTIFICACION.VENCIDO));
                                oCon.AsignarParametroEntero("@id", Convert.ToInt32(notificacion["id"]));
                                oCon.EjecutarComando();
                            }
                            else
                            {
                                if (cantidadRealizados == dtDestinatarios.Rows.Count)
                                {
                                    oCon.CrearComando("UPDATE notificaciones SET id_estado_notificacion=@idEstadoNotificacion WHERE id=@id");
                                    oCon.AsignarParametroEntero("@idEstadoNotificacion", Convert.ToInt32(ESTADO_NOTIFICACION.VISTO));
                                    oCon.AsignarParametroEntero("@id", Convert.ToInt32(notificacion["id"]));
                                    oCon.EjecutarComando();
                                }
                            }

                        }



                        //if (Convert.ToInt32(notificacion["ejecutar"]) == Convert.ToInt32(EJECUTAR.No)){

                        //}
                        //else{
                        //    bool fueraDeTiempo = false;
                        //    oCon.CrearComando(String.Format("select * from vw_notificaciones_adjuntos where id_notificacion={0}", Convert.ToInt32(notificacion["id"])));
                        //    dtAdjuntos= oCon.Tabla();
                        //    foreach(DataRow adjunto in dtAdjuntos.Rows){
                        //        if((Convert.ToInt32(adjunto["id_estado_realizacion"])==Convert.ToInt32(Notificaciones_Adjuntos.ESTADO.PENDIENTE) && DateTime.Compare(Convert.ToDateTime(notificacion["fecha_limite"]), Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"))) < 0) || (Convert.ToInt32(adjunto["id_estado_realizacion"]) == Convert.ToInt32(Notificaciones_Adjuntos.ESTADO.REALIZADO) && DateTime.Compare(Convert.ToDateTime(adjunto["fecha_realizado"]), Convert.ToDateTime(notificacion["fecha_limite"])) > 0)){
                        //            fueraDeTiempo = true;
                        //            break;
                        //        }
                        //    }
                        //    if (fueraDeTiempo){
                        //        foreach (DataRow destinatario in dtDestinatarios.Rows){
                        //            oCon.CrearComando("UPDATE notificaciones_destinatarios SET id_estado_notificacion_destinatario=@idEstadoNotificacion WHERE id=@id");
                        //            oCon.AsignarParametroEntero("@idEstadoNotificacion", Convert.ToInt32(ESTADO_NOTIFICACION.VENCIDO));
                        //            oCon.AsignarParametroEntero("@id", Convert.ToInt32(destinatario["id"]));
                        //            oCon.EjecutarComando();
                        //        }
                        //    }
                        //}
                    }
                }
                oCon.DesConectar();
            }
            catch (Exception)
            {
                oCon.DesConectar();
                respuesta = -1;
                throw;
            }

            return respuesta;
        }

        public DataTable RetornarUltimaNotificacionPendiente(int idTipoDestinatario, int idDestinatario)
        {
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                oCon.CrearComando(String.Format("select max(fecha_limite) as fecha_limite from vw_notificaciones_destinatarios where id_tipo_destinatario={0} and id_destinatario={1} and id_estado_notificacion_destinatario={2}", idTipoDestinatario.ToString(), idDestinatario.ToString(), Convert.ToInt32(Notificaciones_Destinatarios.Estado_Notificacion.PENDIENTE).ToString()));
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
