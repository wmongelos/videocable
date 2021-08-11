using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CapaNegocios.Panel_Tareas
{
    public class Procesos_Automaticos
    {
        public int Id { get; set; }
        public int Id_Proceso { get; set; }
        public int Id_Periodo { get; set; }
        public DateTime Fecha_Inicio { get; set; }
        public DateTime Fecha_Fin { get; set; }
        public string Descripcion { get; set; }

        private readonly Conexion oCon = new Conexion();

        public void Guardar(Procesos_Automaticos oProcesoAutomatico)
        {
            try
            {
                oCon.Conectar();
                oCon.ComenzarTransaccion();

                oCon.CrearComando("INSERT INTO procesos_automaticos (Id_Proceso, Id_Periodo, Fecha_Inicio, Fecha_Fin, Descripcion)" +
                    "VALUES (@idProceso, @idPeriodo, @FechaInicio, @FechaFin, @Descripcion); SELECT @@IDENTITY");
                oCon.AsignarParametroEntero("@idProceso", oProcesoAutomatico.Id_Proceso);
                oCon.AsignarParametroEntero("@idPeriodo", oProcesoAutomatico.Id_Periodo);
                oCon.AsignarParametroFecha("@FechaInicio", oProcesoAutomatico.Fecha_Inicio);
                oCon.AsignarParametroFecha("@FechaFin", oProcesoAutomatico.Fecha_Fin);
                oCon.AsignarParametroCadena("@Descripcion", oProcesoAutomatico.Descripcion);
                int idProcesoAutomatico = oCon.EjecutarScalar();

                oCon.CrearComando("INSERT INTO procesos_ejecucion (Id_Proceso, Id_Proceso_Automatico, Fecha_Ejecucion, Estado, Id_Personal)" +
                    "VALUES (@idProceso, @idProsAuto, @fechaEjecucion, @estado, @idPersonal)");
                oCon.AsignarParametroEntero("@idProceso", oProcesoAutomatico.Id_Proceso);
                oCon.AsignarParametroEntero("@idProsAuto", idProcesoAutomatico); 
                oCon.AsignarParametroFecha("@fechaEjecucion", oProcesoAutomatico.Fecha_Inicio);
                oCon.AsignarParametroEntero("@estado", Convert.ToInt32(Procesos_Ejecucion.Estados_Ejecucion_Proceso.No_Iniciado));
                oCon.AsignarParametroEntero("@idPersonal", Personal.Id_Login);
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

        public Procesos_Automaticos GetProcesoAutomatico(int idProcesoAutomatico)
        {
            try
            {
                oCon.Conectar();
                oCon.CrearComando(" SELECT procesos_automaticos.Id, Id_Proceso, Id_Periodo, " +
                    " Fecha_Inicio, Fecha_Fin, procesos_automaticos.Descripcion " +
                    " FROM procesos_automaticos " +
                    " INNER JOIN procesos ON procesos.id = procesos_automaticos.Id_Proceso " +
                    " WHERE procesos_automaticos.id = @id and procesos.estado = @estado");
                oCon.AsignarParametroEntero("@id", idProcesoAutomatico);
                oCon.AsignarParametroEntero("@estado", Convert.ToInt32(Procesos.Estado_Proceso.Activo));
                DataTable dt = oCon.Tabla();
                oCon.DesConectar();
                Procesos_Automaticos oProcesoAutomatico = new Procesos_Automaticos();
                oProcesoAutomatico.Id = Convert.ToInt32(dt.Rows[0]["Id"]);
                oProcesoAutomatico.Id_Proceso = Convert.ToInt32(dt.Rows[0]["Id_Proceso"]);
                oProcesoAutomatico.Id_Periodo = Convert.ToInt32(dt.Rows[0]["Id_Periodo"]);
                oProcesoAutomatico.Fecha_Inicio = Convert.ToDateTime(dt.Rows[0]["Fecha_Inicio"]);
                oProcesoAutomatico.Fecha_Fin = Convert.ToDateTime(dt.Rows[0]["Fecha_Fin"]);
                oProcesoAutomatico.Descripcion = dt.Rows[0]["Descripcion"].ToString();

                return oProcesoAutomatico;
            }
            catch (Exception)
            {
                oCon.DesConectar();
                throw;
            }
        }

        public void AgregarProximaEjecucion(int idProcesoAutomatico, DateTime fechaUltimaEjecucion)
        {
            Procesos_Automaticos oProcesoAutomatico = GetProcesoAutomatico(idProcesoAutomatico);

            if (!Enum.IsDefined(typeof(Procesos_Periodos.Periodos), oProcesoAutomatico.Id_Periodo))
            {
                throw new Exception("Periodo no definido en el enum");
            }

            Procesos_Periodos.Periodos periodo = (Procesos_Periodos.Periodos)oProcesoAutomatico.Id_Periodo;

            DateTime proximaEjecucion = new DateTime();
            switch (periodo)
            {
                case Procesos_Periodos.Periodos.Todos_Los_Dias:
                    proximaEjecucion = fechaUltimaEjecucion.AddDays(1);
                    break;
                case Procesos_Periodos.Periodos.Una_Vez_Por_Semana:
                    proximaEjecucion = fechaUltimaEjecucion.AddDays(7);
                    break;
                case Procesos_Periodos.Periodos.Una_Vez_Por_Mes:
                    proximaEjecucion = fechaUltimaEjecucion.AddMonths(1);
                    break;
            }

            Procesos_Ejecucion oProcesoEjecucion = new Procesos_Ejecucion();
            oProcesoEjecucion.Id_Proceso = oProcesoAutomatico.Id_Proceso;
            oProcesoEjecucion.Id_Proceso_Automatico = oProcesoAutomatico.Id;
            oProcesoEjecucion.Fecha_Ejecucion = proximaEjecucion;
            oProcesoEjecucion.Id_Personal = Personal.Id_Login;
            oProcesoEjecucion.Estado = Convert.ToInt32(Procesos_Ejecucion.Estados_Ejecucion_Proceso.No_Iniciado);
            oProcesoEjecucion.Tipo_Proceso = Convert.ToInt32(Procesos_Ejecucion.Tipo_De_Ejecucion.Automatico);

            try
            {
                oProcesoEjecucion.Guardar(oProcesoEjecucion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
