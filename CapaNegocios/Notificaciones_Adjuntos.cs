using CapaDatos;
using System;
using System.Data;

namespace CapaNegocios
{
    public class Notificaciones_Adjuntos
    {
        private Conexion oCon = new Conexion();

        public Int32 Id { get; set; }
        public Int32 Id_Notificacion { get; set; }
        public Int32 Id_Tipo_Modulo_Sistema { get; set; }
        public Int32 Id_Item_Modulo { get; set; }
        public Int32 Id_Estado_Realizacion { get; set; }
        public Int32 Id_Accion { get; set; }
        public Int32 Borrado { get; set; }

        public enum TIPO_ADJUNTOS
        {
            USUARIO = 1,
            LOCACION = 2,
            PARTE = 3,
            USUARIO_SERVICIO = 4
        }

        public enum ACCION_EJECUTAR
        {
            CORTE_SERVICIO = 1
        }

        public enum ESTADO
        {
            PENDIENTE = 1,
            REALIZADO = 2
        }

        public void Guardar(Notificaciones_Adjuntos oNotAdjunta)
        {
            try
            {
                oCon.Conectar();
                //if (oNotAdjunta.Id > 0)
                //{
                //    oCon.CrearComando("UPDATE Notificaciones_Adjuntos SET Id_Notificacion=@idNotificacion,Id_Tipo_Modulo_Sistema=@IdTipoModuloSistema,id_adjunto=@IdItemModulo,Id_Estado_Realizacion=@IdEstadoRealizacion WHERE id=@id1");
                //    oCon.AsignarParametroEntero("@id1", oNotAdjunta.Id);
                //}
                //else
                oCon.CrearComando("INSERT INTO Notificaciones_Adjuntos(Id_Notificacion,Id_Tipo_Modulo_Sistema,id_adjunto,Id_Estado_Realizacion, id_accion,borrado) VALUES (@IdNotificacion,@IdTipoModuloSistema,@IdItemModulo,@IdEstadoRealizacion, @IdAccion,0)");
                oCon.AsignarParametroEntero("@IdNotificacion", oNotAdjunta.Id_Notificacion);
                oCon.AsignarParametroEntero("@IdTipoModuloSistema", oNotAdjunta.Id_Tipo_Modulo_Sistema);
                oCon.AsignarParametroEntero("@IdItemModulo", oNotAdjunta.Id_Item_Modulo);
                oCon.AsignarParametroEntero("@IdEstadoRealizacion", oNotAdjunta.Id_Estado_Realizacion);
                oCon.AsignarParametroEntero("@IdAccion", oNotAdjunta.Id_Accion);

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

        public DataTable Listar(int idNot)
        {
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                oCon.CrearComando("SELECT vw_notificaciones_adjuntos.* from vw_notificaciones_adjuntos WHERE Id_Notificacion=@idNot");
                oCon.AsignarParametroEntero("@idNot", idNot);
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

        public int EjecutarAdjuntos(DataTable dtAdjuntosRecibidos)
        {
            int respuesta = -1;
            int idAdjunto = 0;
            int idNotificacion = 0;
            DataRow drDatosAdjunto;
            DataTable dtDatosAuxiliar = new DataTable();
            try
            {
                oCon.Conectar();
                foreach (DataRow adjunto in dtAdjuntosRecibidos.Rows)
                {
                    idAdjunto = 0;
                    idNotificacion = 0;
                    drDatosAdjunto = null;
                    dtDatosAuxiliar.Clear();
                    idAdjunto = Convert.ToInt32(adjunto["idAdjunto"]);
                    idNotificacion = Convert.ToInt32(adjunto["idNotificacion"]);
                    if (Convert.ToInt32(adjunto["idTipoAdjunto"]) == Convert.ToInt32(TIPO_ADJUNTOS.USUARIO_SERVICIO))
                        oCon.CrearComando(String.Format("SELECT usuarios_servicios.id_servicios_tipo,usuarios_servicios.Id_usuarios,usuarios_servicios.id_servicios,usuarios_servicios.id,"
                            + " servicios_tipos.Id_servicios_Grupos, usuarios_servicios.id_usuarios_locaciones, usuarios_servicios.Id_tipo_facturacion,"
                            + " servicios.CorteAutomatico"
                            + " from usuarios_servicios"
                            + " left join servicios_tipos on servicios_tipos.id = usuarios_servicios.id_servicios_tipo"
                            + " left join servicios on servicios.id = usuarios_Servicios.id_servicios where usuarios_Servicios.id ={0}", idAdjunto));
                    dtDatosAuxiliar = oCon.Tabla();
                    drDatosAdjunto = dtDatosAuxiliar.NewRow();
                    drDatosAdjunto = dtDatosAuxiliar.Rows[0];
                    if (Convert.ToInt32(adjunto["idTipoAdjunto"]) == Convert.ToInt32(TIPO_ADJUNTOS.USUARIO_SERVICIO))
                    {
                        if (Convert.ToInt32(adjunto["idAccion"]) == Convert.ToInt32(ACCION_EJECUTAR.CORTE_SERVICIO))
                        {
                            DataRow drParte;
                            DataTable dtPartesFallas;
                            DataTable dtPartesAGenerar = new DataTable();
                            DataTable dtPartesGenerados = new DataTable();
                            Partes_Solicitudes oPartesSolicitudes = new Partes_Solicitudes();
                            Partes oPartes = new Partes();

                            dtPartesAGenerar = oPartes.Get_Estructura_Partes();
                            drParte = dtPartesAGenerar.NewRow();
                            dtPartesFallas = oPartesSolicitudes.GetFallasPorTipoServYOp(Convert.ToInt32(drDatosAdjunto["id_servicio_tipo"].ToString()), Convert.ToInt32(Partes.Partes_Operaciones.CORTE));
                            drParte["Id"] = 0;
                            drParte["Id_Usuarios"] = Convert.ToInt32(drDatosAdjunto["Id_usuarios"]);
                            drParte["Id_Servicios"] = Convert.ToInt32(drDatosAdjunto["id_servicio"]);
                            drParte["Id_Usuarios_Servicios"] = Convert.ToInt32(drDatosAdjunto["Id"]);
                            drParte["Id_Servicios_Tipos"] = Convert.ToInt32(drDatosAdjunto["Id_Servicio_Tipo"]);
                            drParte["Id_Servicios_Grupos"] = Convert.ToInt32(drDatosAdjunto["Id_Grupo"]);
                            drParte["Id_Usuarios_Locaciones"] = Convert.ToInt32(drDatosAdjunto["Id_Locacion"]);
                            drParte["Id_Zonas"] = Convert.ToInt32(drDatosAdjunto["Id_tipo_facturacion"]);
                            try
                            {
                                drParte["Id_Partes_Fallas"] = Convert.ToInt32(dtPartesFallas.Rows[0]["id"]);
                            }
                            catch { drParte["Id_Partes_Fallas"] = 0; }
                            drParte["Id_Partes_Soluciones"] = 0;
                            drParte["Id_Movil"] = 0;
                            drParte["Fecha_Programado"] = DateTime.Now;
                            if (Convert.ToInt32(drDatosAdjunto["CorteAutomatico"]) == Convert.ToInt32(Servicios._CorteAutomatico.SI))
                            {
                                drParte["Id_Partes_Estados"] = Convert.ToInt32(Partes.Partes_Estados.REALIZADO);
                                drParte["Id_Tecnico"] = Personal.Id_Login;
                                drParte["Fecha_Realizado"] = DateTime.Now;
                            }
                            else
                            {
                                drParte["Id_Partes_Estados"] = Convert.ToInt32(Partes.Partes_Estados.PENDIENTE_DE_ASIGNACION_DE_TECNICO);
                                drParte["Id_Tecnico"] = 0;
                            }

                            drParte["Id_Operadores"] = Personal.Id_Login;
                            drParte["Id_Areas"] = Personal.Id_Area;
                            drParte["Fecha_Reclamo"] = DateTime.Today.Date;
                            try
                            {
                                drParte["Detalle_Falla"] = dtPartesFallas.Rows[0]["nombre"].ToString();
                            }
                            catch { drParte["Detalle_Falla"] = ""; }

                            drParte["Detalle_Solucion"] = "";
                            drParte["CorteAutomatico"] = Convert.ToInt32(drDatosAdjunto["CorteAutomatico"]);
                            dtPartesAGenerar.Rows.Add(drParte);
                            if (dtPartesAGenerar.Rows.Count > 0)
                            {
                                dtPartesGenerados = oPartes.GenerarLotePartes(dtPartesAGenerar, Convert.ToInt32(Partes.Partes_Operaciones.CORTE));
                                if (dtPartesGenerados.Rows.Count > 0)
                                {
                                    oPartes.GenerarHistorialPartes(dtPartesGenerados);
                                    respuesta = 1;
                                }
                                else
                                    respuesta = -1;
                            }
                        }
                    }
                    if (respuesta > 0)
                    {
                        oCon.CrearComando("UPDATE notificaciones_adjuntos SET id_estado_realizacion=@idEstadoRealizacion, fecha_realizado=@fecha WHERE id=@id");
                        oCon.AsignarParametroEntero("@idEstadoRealizacion", Convert.ToInt32(ESTADO.REALIZADO));
                        oCon.AsignarParametroFecha("@fecha", DateTime.Now);
                        oCon.AsignarParametroEntero("@id", Convert.ToInt32(adjunto["id"]));
                        oCon.EjecutarComando();

                        oCon.CrearComando("UPDATE Notificaciones_Destinatarios SET id_estado_notificacion_destinatario=@idEstadoNotificacion, fecha_visto=@fecha WHERE id_notificacion_origen=@idNotificacionOrigen");
                        oCon.AsignarParametroEntero("@idEstadoNotificacion", Convert.ToInt32(Notificaciones_Destinatarios.Estado_Notificacion.RESUELTO));
                        oCon.AsignarParametroFecha("@fecha", DateTime.Now);
                        oCon.AsignarParametroEntero("@idNotificacionOrigen", idNotificacion);
                        oCon.EjecutarComando();
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

        public DataTable GetTablaModeloDatosAdjuntos()
        {
            DataTable dtAdjuntos = new DataTable();
            dtAdjuntos.Columns.Add("id", typeof(string));
            dtAdjuntos.Columns.Add("idAdjunto", typeof(string));
            dtAdjuntos.Columns.Add("idTipoAdjunto", typeof(string));
            dtAdjuntos.Columns.Add("idAccion", typeof(string));
            dtAdjuntos.Columns.Add("idNotificacion", typeof(string));
            return dtAdjuntos;
        }

        public void ActualizarEstado(int idNotificacionAdjunto, int idEstado)
        {
            try
            {
                oCon.Conectar();
                oCon.CrearComando("UPDATE Notificaciones_Adjuntos SET id_estado_realizacion=@idEstado, fecha_realizado=@fecha WHERE id=@idNotificacionAdjunto");
                oCon.AsignarParametroEntero("@idEstado", idEstado);
                oCon.AsignarParametroFecha("@fecha", DateTime.Now);
                oCon.AsignarParametroEntero("@idNotificacionAdjunto", idNotificacionAdjunto);
                oCon.EjecutarComando();
                oCon.DesConectar();
            }
            catch (Exception)
            {
                oCon.DesConectar();
                throw;
            }
        }

        public void ActualizarObservacion(int idNotificacionAdjunto, string observacion)
        {
            try
            {
                oCon.Conectar();
                oCon.CrearComando("UPDATE Notificaciones_Adjuntos SET observacion=@observacion WHERE id=@idNotificacionAdjunto");
                oCon.AsignarParametroCadena("@observacion", observacion);
                oCon.AsignarParametroEntero("@idNotificacionAdjunto", idNotificacionAdjunto);
                oCon.EjecutarComando();
                oCon.DesConectar();
            }
            catch (Exception)
            {
                oCon.DesConectar();
                throw;
            }
        }
    }
}
