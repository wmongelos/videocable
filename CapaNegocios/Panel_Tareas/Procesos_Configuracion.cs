using CapaDatos;
using System;
using System.Data;

namespace CapaNegocios.Panel_Tareas
{
    public class Procesos_Configuracion
    {
        public int Id { get; set; }
        public int Id_Proceso { get; set; }
        public int Id_Periodo { get; set; }
        public DateTime Fecha_Inicio { get; set; }
        public DateTime Fecha_Siguiente_Ejecucion { get; set; }
        public DateTime Fecha_Fin { get; set; }
        public string Descripcion { get; set; }

        private readonly Conexion oCon = new Conexion();

        public void Guardar(Procesos_Configuracion oProcesoConfig)
        {
            try
            {
                oCon.Conectar();
                oCon.ComenzarTransaccion();
                oCon.CrearComando("INSERT INTO procesos_configuracion (Id_Proceso, Id_Periodo, Fecha_Inicio, Fecha_Siguiente_Ejecucion, Fecha_Fin, Descripcion)" +
                    "VALUES (@idProceso, @idPeriodo, @FechaInicio, @FechaSiguiente, @FechaFin, @Descripcion)");
                oCon.AsignarParametroEntero("@idProceso", oProcesoConfig.Id_Proceso);
                oCon.AsignarParametroEntero("@idPeriodo", oProcesoConfig.Id_Periodo);
                oCon.AsignarParametroFecha("@FechaInicio", oProcesoConfig.Fecha_Inicio);
                oCon.AsignarParametroFecha("@FechaSiguiente", oProcesoConfig.Fecha_Siguiente_Ejecucion);
                oCon.AsignarParametroFecha("@FechaFin", oProcesoConfig.Fecha_Fin);
                oCon.AsignarParametroCadena("@Descripcion", oProcesoConfig.Descripcion);
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

        public Procesos_Configuracion GetProcesoConfiguracion(int idProceso)
        {
            try
            {
                Procesos_Configuracion oProcesoConfig = new Procesos_Configuracion();
                oCon.Conectar();
                oCon.CrearComando("SELECT * FROM procesos_configuracion WHERE id = @id");
                oCon.AsignarParametroEntero("@id", idProceso);
                DataTable dt = oCon.Tabla();
                oCon.DesConectar();

                if(dt.Rows.Count > 0)
                {
                    oProcesoConfig.Id = Convert.ToInt32(dt.Rows[0]["id"]);
                    oProcesoConfig.Id_Proceso = idProceso;
                    oProcesoConfig.Id_Periodo = Convert.ToInt32(dt.Rows[0]["id_periodo"]);
                    oProcesoConfig.Fecha_Inicio = Convert.ToDateTime(dt.Rows[0]["Fecha_Inicio"]);
                    oProcesoConfig.Fecha_Siguiente_Ejecucion = Convert.ToDateTime(dt.Rows[0]["Fecha_Siguiente_ejecucion"]);
                    oProcesoConfig.Fecha_Fin = Convert.ToDateTime(dt.Rows[0]["Fecha_Fin"]);
                    oProcesoConfig.Descripcion = dt.Rows[0]["descripcion"].ToString();
                }

                return oProcesoConfig;
            }
            catch (Exception)
            {
                oCon.DesConectar();
                throw;
            }
        }

        public void ActualizarFechaDeSiguienteEjecucion(Procesos_Configuracion oProcesoConfig)
        {

        }
    }
}
