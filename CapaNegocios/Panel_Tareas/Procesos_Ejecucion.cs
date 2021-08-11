using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CapaNegocios.Panel_Tareas
{
    public class Procesos_Ejecucion
    {
        private const int TIEMPO_DE_REPROGRAMACION = 3;

        public enum Estados_Ejecucion_Proceso
        {
            /*Finalizado correctamente*/
            Finalizado = 0,
            /*Todavia no llego su dia y hora de ejecucion*/
            No_Iniciado = 1,
            /*Se inicio y hubo un error en el proceso*/
            Error = 2,
            /*Paso la fecha de ejecucion sin iniciarse*/
            Reprogramado = 3,
            /*Paso su dia y hora sin realizar y sin poderse reprogramar*/
            No_Realizado = 4
        }

        public enum Tipo_De_Ejecucion
        {
            Automatico = 1,
            Manual = 2
        }

        public int Id { get; set; }
        public int Id_Proceso { get; set; }
        public int Id_Proceso_Automatico { get; set; }
        public DateTime Fecha_Ejecucion { get; set; }
        public DateTime? Fecha_Reprogramado { get; set; }
        public int Estado { get; set; }
        public int Id_Personal { get; set; }
        public int Tipo_Proceso { get; set; }

        private readonly Conexion oCon = new Conexion();

        public DataTable ListarNoIniciados()
        {
            try
            {
                oCon.Conectar();
                oCon.CrearComando("SELECT procesos.descripcion, procesos_ejecucion.Id, procesos_ejecucion.Id_Proceso, " +
                    " procesos_ejecucion.Fecha_Ejecucion, procesos_ejecucion.Fecha_Reprogramado, procesos_ejecucion.Estado, procesos_ejecucion.Id_Personal, procesos_ejecucion.Id_Proceso_Automatico, " +
                    " procesos_automaticos.fecha_inicio, procesos_automaticos.fecha_fin, procesos_automaticos.descripcion as descripcion_automatico, " +
                    " procesos_periodos.descripcion as periodo " +
                    " FROM procesos_ejecucion " +
                    " INNER JOIN procesos ON procesos.id = procesos_ejecucion.id_proceso " +
                    " LEFT JOIN procesos_automaticos ON procesos_automaticos.id_proceso = procesos_ejecucion.id_proceso " +
                    " LEFT JOIN procesos_periodos ON procesos_periodos.Id = procesos_automaticos.id_periodo " +
                    " WHERE procesos_ejecucion.estado = @estadoEjecucion AND " +
                    " procesos.estado = @estadoProceso " +
                    " ORDER BY Fecha_Ejecucion ASC");
                oCon.AsignarParametroEntero("@estadoEjecucion", Convert.ToInt32(Estados_Ejecucion_Proceso.No_Iniciado));
                oCon.AsignarParametroEntero("@estadoProceso", Convert.ToInt32(Procesos.Estado_Proceso.Activo));
                DataTable dt = oCon.Tabla();
                oCon.DesConectar();
                return dt;
            }
            catch (Exception)
            {
                oCon.DesConectar();
                throw;
            }
        }

        public DataTable ListarHistorial()
        {
            try
            {
                oCon.Conectar();
                oCon.CrearComando("SELECT procesos_ejecucion.Id, procesos_ejecucion.Id_Proceso, procesos_ejecucion.Id_Proceso_Automatico, " +
                    " procesos_ejecucion.Fecha_Ejecucion, procesos_ejecucion.Fecha_Reprogramado, procesos_ejecucion.Estado, procesos_ejecucion.Id_Personal" +
                    " FROM procesos_ejecucion " +
                    " INNER JOIN procesos ON procesos.id = procesos_ejecucion.id_proceso " +
                    " WHERE procesos.estado = @estado " +
                    " ORDER BY Fecha_Ejecucion ASC");
                oCon.AsignarParametroEntero("@estado", Convert.ToInt32(Procesos.Estado_Proceso.Activo));
                DataTable dt = oCon.Tabla();
                oCon.DesConectar();
                return dt;
            }
            catch (Exception)
            {
                oCon.DesConectar();
                throw;
            }
        }

        public List<Procesos_Ejecucion> ListarProcesosParaEjecutar()
        {
            try
            {
                oCon.Conectar();
                oCon.CrearComando("SELECT procesos_ejecucion.Id, procesos_ejecucion.Id_Proceso, procesos_ejecucion.Id_Proceso_Automatico," +
                    " procesos_ejecucion.Id_Proceso_Automatico, procesos_ejecucion.Fecha_Ejecucion, procesos_ejecucion.Fecha_Reprogramado, " +
                    " procesos_ejecucion.Estado, procesos_ejecucion.Id_Personal " +
                    " FROM procesos_ejecucion " +
                    " INNER JOIN procesos ON procesos.id = procesos_ejecucion.id_proceso " +
                    " WHERE procesos.estado = @proest AND " +
                    " (procesos_ejecucion.estado = @estuno or procesos_ejecucion.estado = @estdos) " +
                    " ORDER BY IF(procesos_ejecucion.estado=3, fecha_reprogramado, fecha_ejecucion) ASC");
                oCon.AsignarParametroEntero("@estuno", Convert.ToInt32(Estados_Ejecucion_Proceso.No_Iniciado));
                oCon.AsignarParametroEntero("@estdos", Convert.ToInt32(Estados_Ejecucion_Proceso.Reprogramado));
                oCon.AsignarParametroEntero("@proest", Convert.ToInt32(Procesos.Estado_Proceso.Activo));
                DataTable dt = oCon.Tabla();
                oCon.DesConectar();
                List<Procesos_Ejecucion> procesosEjecucion = new List<Procesos_Ejecucion>();
                foreach (DataRow row in dt.Rows)
                {
                    Procesos_Ejecucion oProcesosEjecucion = new Procesos_Ejecucion();
                    oProcesosEjecucion.Id = Convert.ToInt32(row["Id"]);
                    oProcesosEjecucion.Id_Proceso = Convert.ToInt32(row["Id_Proceso"]);
                    oProcesosEjecucion.Fecha_Ejecucion = Convert.ToDateTime(row["Fecha_Ejecucion"]);
                    object value = row["Fecha_Reprogramado"];
                    if (value == DBNull.Value)
                        oProcesosEjecucion.Fecha_Reprogramado = null;
                    else
                        oProcesosEjecucion.Fecha_Reprogramado = Convert.ToDateTime(row["Fecha_Reprogramado"]);
                    oProcesosEjecucion.Estado = Convert.ToInt32(row["Estado"]);
                    oProcesosEjecucion.Id_Personal = Convert.ToInt32(row["Id_Personal"]);
                    oProcesosEjecucion.Id_Proceso_Automatico = Convert.ToInt32(row["Id_Proceso_Automatico"]);
                    procesosEjecucion.Add(oProcesosEjecucion);
                }
                return procesosEjecucion;
            }
            catch (Exception ex)
            {
                oCon.DesConectar();
                throw ex;
            }
        }

        public List<Procesos_Ejecucion> ListarProcesosParaEjecutarPasados(DateTime fecha)
        {
            try
            {
                oCon.Conectar();
                oCon.CrearComando("SELECT procesos_ejecucion.Id, procesos_ejecucion.Id_Proceso, procesos_ejecucion.Id_Proceso_Automatico," +
                    " procesos_ejecucion.Id_Proceso_Automatico, procesos_ejecucion.Fecha_Ejecucion, procesos_ejecucion.Fecha_Reprogramado, " +
                    " procesos_ejecucion.Estado, procesos_ejecucion.Id_Personal " +
                    " FROM procesos_ejecucion " +
                    " INNER JOIN procesos ON procesos.id = procesos_ejecucion.id_proceso " +
                    " WHERE procesos_ejecucion.Fecha_Ejecucion <= @fecha AND procesos.estado = @proest AND " +
                    " (procesos_ejecucion.estado = @estuno or procesos_ejecucion.estado = @estdos) " +
                    " ORDER BY IF(procesos_ejecucion.estado=3, fecha_reprogramado, fecha_ejecucion) ASC");
                oCon.AsignarParametroFecha("@fecha", fecha);
                oCon.AsignarParametroEntero("@estuno", Convert.ToInt32(Estados_Ejecucion_Proceso.No_Iniciado));
                oCon.AsignarParametroEntero("@estdos", Convert.ToInt32(Estados_Ejecucion_Proceso.Reprogramado));
                oCon.AsignarParametroEntero("@proest", Convert.ToInt32(Procesos.Estado_Proceso.Activo));
                DataTable dt = oCon.Tabla();
                oCon.DesConectar();
                List<Procesos_Ejecucion> procesosEjecucion = new List<Procesos_Ejecucion>();
                foreach (DataRow row in dt.Rows)
                {
                    Procesos_Ejecucion oProcesosEjecucion = new Procesos_Ejecucion();
                    oProcesosEjecucion.Id = Convert.ToInt32(row["Id"]);
                    oProcesosEjecucion.Id_Proceso = Convert.ToInt32(row["Id_Proceso"]);
                    oProcesosEjecucion.Fecha_Ejecucion = Convert.ToDateTime(row["Fecha_Ejecucion"]);
                    object value = row["Fecha_Reprogramado"];
                    if (value == DBNull.Value)
                        oProcesosEjecucion.Fecha_Reprogramado = null;
                    else
                        oProcesosEjecucion.Fecha_Reprogramado = Convert.ToDateTime(row["Fecha_Reprogramado"]);
                    oProcesosEjecucion.Estado = Convert.ToInt32(row["Estado"]);
                    oProcesosEjecucion.Id_Personal = Convert.ToInt32(row["Id_Personal"]);
                    oProcesosEjecucion.Id_Proceso_Automatico = Convert.ToInt32(row["Id_Proceso_Automatico"]);
                    procesosEjecucion.Add(oProcesosEjecucion);
                }
                return procesosEjecucion;
            }
            catch (Exception ex)
            {
                oCon.DesConectar();
                throw ex;
            }
        }

        public List<Procesos_Ejecucion> ListarProcesosParaEjecutarProximos(DateTime fecha)
        {
            try
            {
                oCon.Conectar();
                oCon.CrearComando("SELECT procesos_ejecucion.Id, procesos_ejecucion.Id_Proceso, procesos_ejecucion.Id_Proceso_Automatico," +
                    " procesos_ejecucion.Id_Proceso_Automatico, procesos_ejecucion.Fecha_Ejecucion, procesos_ejecucion.Fecha_Reprogramado, " +
                    " procesos_ejecucion.Estado, procesos_ejecucion.Id_Personal " +
                    " FROM procesos_ejecucion " +
                    " INNER JOIN procesos ON procesos.id = procesos_ejecucion.id_proceso " +
                    " WHERE procesos_ejecucion.Fecha_Ejecucion >= @fecha AND procesos_ejecucion.Fecha_Ejecucion <= @fechaActual AND procesos.estado = @proest AND " +
                    " (procesos_ejecucion.estado = @estuno or procesos_ejecucion.estado = @estdos) " +
                    " ORDER BY IF(procesos_ejecucion.estado=3, fecha_reprogramado, fecha_ejecucion) ASC");
                oCon.AsignarParametroFecha("@fecha", fecha);
                oCon.AsignarParametroEntero("@estuno", Convert.ToInt32(Estados_Ejecucion_Proceso.No_Iniciado));
                oCon.AsignarParametroEntero("@estdos", Convert.ToInt32(Estados_Ejecucion_Proceso.Reprogramado));
                oCon.AsignarParametroEntero("@proest", Convert.ToInt32(Procesos.Estado_Proceso.Activo));
                DataTable dt = oCon.Tabla();
                oCon.DesConectar();
                List<Procesos_Ejecucion> procesosEjecucion = new List<Procesos_Ejecucion>();
                foreach (DataRow row in dt.Rows)
                {
                    Procesos_Ejecucion oProcesosEjecucion = new Procesos_Ejecucion();
                    oProcesosEjecucion.Id = Convert.ToInt32(row["Id"]);
                    oProcesosEjecucion.Id_Proceso = Convert.ToInt32(row["Id_Proceso"]);
                    oProcesosEjecucion.Fecha_Ejecucion = Convert.ToDateTime(row["Fecha_Ejecucion"]);
                    object value = row["Fecha_Reprogramado"];
                    if (value == DBNull.Value)
                        oProcesosEjecucion.Fecha_Reprogramado = null;
                    else
                        oProcesosEjecucion.Fecha_Reprogramado = Convert.ToDateTime(row["Fecha_Reprogramado"]);
                    oProcesosEjecucion.Estado = Convert.ToInt32(row["Estado"]);
                    oProcesosEjecucion.Id_Personal = Convert.ToInt32(row["Id_Personal"]);
                    oProcesosEjecucion.Id_Proceso_Automatico = Convert.ToInt32(row["Id_Proceso_Automatico"]);
                    procesosEjecucion.Add(oProcesosEjecucion);
                }
                return procesosEjecucion;
            }
            catch (Exception ex)
            {
                oCon.DesConectar();
                throw ex;
            }
        }

        public void ActualizarEstado(int idProcesoEjecucion, Estados_Ejecucion_Proceso estado)
        {
            try
            {
                oCon.Conectar();
                oCon.CrearComando("UPDATE procesos_ejecucion SET estado = @estado WHERE id = @id");
                oCon.AsignarParametroEntero("@estado", Convert.ToInt32(estado));
                oCon.AsignarParametroEntero("@id", idProcesoEjecucion);
                oCon.EjecutarComando();
                oCon.DesConectar();
            }
            catch (Exception ex)
            {
                oCon.DesConectar();
                throw ex;
            }
        }

        public int Guardar(Procesos_Ejecucion oProcesoEjecucion)
        {
            try
            {
                oCon.Conectar();
                oCon.ComenzarTransaccion();

                oCon.CrearComando("INSERT INTO procesos_ejecucion (Id_Proceso, Id_Proceso_Automatico, Fecha_Ejecucion, Fecha_Reprogramado, Estado, Id_Personal, Tipo_Proceso)" +
                    "VALUES (@idProceso, @idProcesoAutomatico, @fechaEjecucion, @fechaReprogramado, @estado, @idPersonal, @tipoProceso);SELECT @@IDENTITY;");
                oCon.AsignarParametroEntero("@idProceso", oProcesoEjecucion.Id_Proceso);
                oCon.AsignarParametroEntero("@idProcesoAutomatico", oProcesoEjecucion.Id_Proceso_Automatico);
                oCon.AsignarParametroFecha("@fechaEjecucion", oProcesoEjecucion.Fecha_Ejecucion);
                if (oProcesoEjecucion.Fecha_Reprogramado.HasValue)
                    oCon.AsignarParametroFecha("@fechaReprogramado", oProcesoEjecucion.Fecha_Reprogramado.Value);
                else
                    oCon.AsignarParametroNulo("@fechaReprogramado");
                oCon.AsignarParametroEntero("@estado", oProcesoEjecucion.Estado);
                oCon.AsignarParametroEntero("@idPersonal", oProcesoEjecucion.Id_Personal);
                oCon.AsignarParametroEntero("@tipoProceso", oProcesoEjecucion.Tipo_Proceso);
                int id = oCon.EjecutarScalar();

                oCon.ConfirmarTransaccion();
                oCon.DesConectar();
                return id;
            }
            catch (Exception ex)
            {
                oCon.CancelarTransaccion();
                oCon.DesConectar();
                throw ex;
            }
        }

        public DataRow GetProcesoEjecucion(int idProcesoEjecucion)
        {
            try
            {
                oCon.Conectar();
                oCon.CrearComando("SELECT procesos.descripcion, procesos.Hora_Ejecucion_Desde, procesos.Hora_Ejecucion_Hasta, procesos_ejecucion.Id," +
                    " procesos_ejecucion.Id_Proceso, " +
                    " procesos_ejecucion.Fecha_Ejecucion, procesos_ejecucion.Fecha_Reprogramado, procesos_ejecucion.Estado, procesos_ejecucion.Id_Personal, procesos_ejecucion.Id_Proceso_Automatico, " +
                    " procesos_automaticos.fecha_inicio, procesos_automaticos.fecha_fin, procesos_automaticos.descripcion as descripcion_automatico, " +
                    " procesos_periodos.descripcion as periodo " +
                    " FROM procesos_ejecucion " +
                    " INNER JOIN procesos ON procesos.id = procesos_ejecucion.id_proceso " +
                    " INNER JOIN procesos_automaticos ON procesos_automaticos.id_proceso = procesos_ejecucion.id_proceso " +
                    " INNER JOIN procesos_periodos ON procesos_periodos.Id = procesos_automaticos.id_periodo " +
                    " WHERE procesos.estado = @estadoProceso AND procesos_ejecucion.id = @idProcesoEje" +
                    " ORDER BY Fecha_Ejecucion ASC");
                oCon.AsignarParametroEntero("@idProcesoEje", idProcesoEjecucion);
                oCon.AsignarParametroEntero("@estadoProceso", Convert.ToInt32(Procesos.Estado_Proceso.Activo));
                DataRow dr = oCon.Tabla().Rows[0];
                oCon.DesConectar();

                return dr;
            }
            catch (Exception)
            {
                oCon.DesConectar();
                throw;
            }
        }

        public void Reprogramar2(int idProcesoEjecucion, List<Procesos_Ejecucion> procesosProximos)
        {
            /*Si el proceso se ejecuta diariamente no se tiene que reprogramar para el dia siguiente*/
            try
            {
                bool reintentar;
                DataRow drDatosProcesoEjecucion = GetProcesoEjecucion(idProcesoEjecucion);

                TimeSpan horaDesde = TimeSpan.Parse(drDatosProcesoEjecucion["Hora_Ejecucion_Desde"].ToString());
                TimeSpan horaHasta = TimeSpan.Parse(drDatosProcesoEjecucion["Hora_Ejecucion_Hasta"].ToString());
                DateTime Desde = new DateTime();
                DateTime Hasta = new DateTime();

                if (DateTime.Now.TimeOfDay >= horaDesde && DateTime.Now.TimeOfDay <= horaHasta)
                {
                    Desde = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.TimeOfDay.Hours, DateTime.Now.TimeOfDay.Minutes, 0);
                    Hasta = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, horaHasta.Hours, horaHasta.Minutes, 0);
                    reintentar = true;
                }
                else
                {
                    Desde = new DateTime(DateTime.Now.AddDays(1).Year, DateTime.Now.AddDays(1).Month, DateTime.Now.AddDays(1).Day, horaDesde.Hours, horaDesde.Minutes, 0);
                    Hasta = new DateTime(DateTime.Now.AddDays(1).Year, DateTime.Now.AddDays(1).Month, DateTime.Now.AddDays(1).Day, horaHasta.Hours, horaHasta.Minutes, 0);
                    reintentar = false;
                }

                List<Procesos_Ejecucion> procesosProximosEnRango = FiltrarPorProcesosEntreRango(procesosProximos, Desde, Hasta);

                if (procesosProximosEnRango.Count == 0)
                {
                    ActualizarFechaDeEjecucion(idProcesoEjecucion, Desde.AddMinutes(1));
                    return;
                }

                bool reprogramado = VerificarProcesosProximosYActualizarEjecucion(procesosProximosEnRango, Desde, horaHasta, idProcesoEjecucion);

                if (!reprogramado && reintentar)
                {
                    Desde = new DateTime(DateTime.Now.AddDays(1).Year, DateTime.Now.AddDays(1).Month, DateTime.Now.AddDays(1).Day, horaDesde.Hours, horaDesde.Minutes, 0);
                    Hasta = new DateTime(DateTime.Now.AddDays(1).Year, DateTime.Now.AddDays(1).Month, DateTime.Now.AddDays(1).Day, horaHasta.Hours, horaHasta.Minutes, 0);

                    procesosProximosEnRango = FiltrarPorProcesosEntreRango(procesosProximos, Desde, Hasta);

                    reprogramado = VerificarProcesosProximosYActualizarEjecucion(procesosProximosEnRango, Desde, horaHasta, idProcesoEjecucion);
                }

                if (!reprogramado)
                {
                    ActualizarEstado(idProcesoEjecucion, Estados_Ejecucion_Proceso.No_Realizado);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Reprogramar(int idProcesoEjecucion, List<Procesos_Ejecucion> procesosProximos)
        {
            /*Si el proceso se ejecuta diariamente no se tiene que reprogramar para el dia siguiente*/
            try
            {
                bool reintentar;
                DataRow drDatosProcesoEjecucion = GetProcesoEjecucion(idProcesoEjecucion);

                TimeSpan horaDesde = TimeSpan.Parse(drDatosProcesoEjecucion["Hora_Ejecucion_Desde"].ToString());
                TimeSpan horaHasta = TimeSpan.Parse(drDatosProcesoEjecucion["Hora_Ejecucion_Hasta"].ToString());
                DateTime Desde = new DateTime();
                DateTime Hasta = new DateTime();

                if(DateTime.Now.TimeOfDay >= horaDesde && DateTime.Now.TimeOfDay <= horaHasta)
                {
                    Desde = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.TimeOfDay.Hours, DateTime.Now.TimeOfDay.Minutes, 0);
                    Hasta = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, horaHasta.Hours, horaHasta.Minutes, 0);
                    reintentar = true;
                }
                else
                {
                    Desde = new DateTime(DateTime.Now.AddDays(1).Year, DateTime.Now.AddDays(1).Month, DateTime.Now.AddDays(1).Day, horaDesde.Hours, horaDesde.Minutes, 0);
                    Hasta = new DateTime(DateTime.Now.AddDays(1).Year, DateTime.Now.AddDays(1).Month, DateTime.Now.AddDays(1).Day, horaHasta.Hours, horaHasta.Minutes, 0);
                    reintentar = false;
                }

                List<Procesos_Ejecucion> procesosOrdenados = procesosProximos.ToList();
                procesosOrdenados.RemoveAt(0);
                List<Procesos_Ejecucion> procesosProximosEnRango = FiltrarPorProcesosEntreRango(procesosOrdenados, Desde, Hasta);

                if (procesosProximosEnRango.Count == 0)
                {
                    ActualizarFechaDeEjecucion(idProcesoEjecucion, Desde.AddMinutes(1));
                    return;
                }

                bool reprogramado = VerificarProcesosProximosYActualizarEjecucion(procesosProximosEnRango, Desde, horaHasta, idProcesoEjecucion);

                if (!reprogramado && reintentar)
                {
                    Desde = new DateTime(DateTime.Now.AddDays(1).Year, DateTime.Now.AddDays(1).Month, DateTime.Now.AddDays(1).Day, horaDesde.Hours, horaDesde.Minutes, 0);
                    Hasta = new DateTime(DateTime.Now.AddDays(1).Year, DateTime.Now.AddDays(1).Month, DateTime.Now.AddDays(1).Day, horaHasta.Hours, horaHasta.Minutes, 0);

                    procesosOrdenados = procesosProximos.ToList();
                    procesosOrdenados.RemoveAt(0);
                    procesosProximosEnRango = FiltrarPorProcesosEntreRango(procesosOrdenados, Desde, Hasta);

                    reprogramado = VerificarProcesosProximosYActualizarEjecucion(procesosProximosEnRango, Desde, horaHasta, idProcesoEjecucion);
                }

                if (!reprogramado)
                {
                    ActualizarEstado(idProcesoEjecucion, Estados_Ejecucion_Proceso.No_Realizado);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private bool VerificarProcesosProximosYActualizarEjecucion(List<Procesos_Ejecucion> procesosProximosEnRango, DateTime Desde, TimeSpan horaHasta, int idProcesoEjecucion)
        {
            try
            {
                bool reprogramado = false;
                if (procesosProximosEnRango.Count > 0)
                {
                    for (int i = 0; i <= procesosProximosEnRango.Count; i++)
                    {
                        if (i == procesosProximosEnRango.Count)
                        {
                            if (GetDateTimeEjecucion(procesosProximosEnRango[i - 1]).AddMinutes(TIEMPO_DE_REPROGRAMACION).TimeOfDay <= horaHasta)
                            {
                                ActualizarFechaDeEjecucion(idProcesoEjecucion, GetDateTimeEjecucion(procesosProximosEnRango[i - 1]).AddMinutes(TIEMPO_DE_REPROGRAMACION));
                                reprogramado = true;
                                break;
                            }
                        }
                        else
                        {
                            DateTime dateTimeComparacion = GetDateTimeEjecucion(procesosProximosEnRango[i]);

                            if (i == 0)
                            {
                                if ((dateTimeComparacion - Desde).TotalMinutes >= TIEMPO_DE_REPROGRAMACION)
                                {
                                    ActualizarFechaDeEjecucion(idProcesoEjecucion, Desde);
                                    reprogramado = true;
                                    break;
                                }
                            }
                            else
                            {
                                if (GetDateTimeEjecucion(procesosProximosEnRango[i - 1]).AddMinutes(TIEMPO_DE_REPROGRAMACION * 2) <=
                                   dateTimeComparacion)
                                {
                                    if (dateTimeComparacion.AddMinutes(TIEMPO_DE_REPROGRAMACION).TimeOfDay <= horaHasta)
                                    {
                                        ActualizarFechaDeEjecucion(idProcesoEjecucion, GetDateTimeEjecucion(procesosProximosEnRango[i - 1]).AddMinutes(TIEMPO_DE_REPROGRAMACION));
                                        reprogramado = true;
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }

                return reprogramado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void ActualizarFechaDeEjecucion(int idProcesoEjecucion, DateTime fechaReprogramado)
        {
            try
            {
                oCon.Conectar();
                oCon.CrearComando("UPDATE procesos_ejecucion SET Fecha_Reprogramado = @fechaReprogramado, Estado = @estado WHERE id = @id");
                oCon.AsignarParametroFecha("@fechaReprogramado", fechaReprogramado);
                oCon.AsignarParametroEntero("@estado", Convert.ToInt32(Estados_Ejecucion_Proceso.Reprogramado));
                oCon.AsignarParametroEntero("@id", idProcesoEjecucion);
                oCon.EjecutarComando();
                oCon.DesConectar();
            }
            catch (Exception ex)
            {
                oCon.CancelarTransaccion();
                oCon.DesConectar();
                throw ex;
            }
        }

        private List<Procesos_Ejecucion> FiltrarPorProcesosEntreRango(List<Procesos_Ejecucion> procesos, DateTime desde, DateTime hasta)
        {
            try
            {
                List<Procesos_Ejecucion> procesosFiltrados = new List<Procesos_Ejecucion>();

                foreach (Procesos_Ejecucion proceso in procesos)
                {
                    if(proceso.Estado == Convert.ToInt32(Procesos_Ejecucion.Estados_Ejecucion_Proceso.Reprogramado))
                    {
                        if (proceso.Fecha_Reprogramado >= desde && proceso.Fecha_Reprogramado <= hasta)
                        {
                            procesosFiltrados.Add(proceso);
                        }
                    }
                    else
                    {
                        if (proceso.Fecha_Ejecucion >= desde && proceso.Fecha_Ejecucion <= hasta)
                        {
                            procesosFiltrados.Add(proceso);
                        }
                    }

                }

                return procesosFiltrados;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static DateTime GetDateTimeEjecucion(Procesos_Ejecucion proceso)
        {
            try
            {
                DateTime dateTimeComparacion;
                if (proceso.Estado == Convert.ToInt32(Procesos_Ejecucion.Estados_Ejecucion_Proceso.Reprogramado) &&
                    proceso.Fecha_Reprogramado.HasValue)
                {
                    dateTimeComparacion = proceso.Fecha_Reprogramado.Value;
                }
                else
                {
                    dateTimeComparacion = proceso.Fecha_Ejecucion;
                }

                return dateTimeComparacion;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
