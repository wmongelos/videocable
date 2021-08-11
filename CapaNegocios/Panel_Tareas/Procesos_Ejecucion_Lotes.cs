using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocios.Panel_Tareas
{
    public class Procesos_Ejecucion_Lotes
    {
        private Conexion oCon = new Conexion();

        public void AgregarRegistroALote(int idProcesoEjecucion, int idRegistro)
        {
            try
            {
                oCon.Conectar();
                oCon.CrearComando("INSERT INTO procesos_ejecucion_lotes (Id_Proceso_Ejecucion, Id_Registro) VALUES (@procEjec, @registro)");
                oCon.AsignarParametroEntero("@procEjec", idProcesoEjecucion);
                oCon.AsignarParametroEntero("@registro", idRegistro);
                oCon.EjecutarComando();
                oCon.DesConectar();
            }
            catch (Exception ex)
            {
                oCon.DesConectar();
                throw ex;
            }
        }

        public Procesos_Ejecucion ObtenerProcesoEjecucion(DateTime fechaProgramacion, Procesos.Proceso proceso, Procesos_Ejecucion.Tipo_De_Ejecucion tipoEjecucion)
        {
            try
            {
                DataTable dt = new DataTable();
                Procesos_Ejecucion oProEjecucion = new Procesos_Ejecucion();
                oCon.Conectar();
                oCon.CrearComando("SELECT procesos_ejecucion.* FROM procesos_ejecucion"
                        + " INNER JOIN procesos ON procesos.Id = procesos_ejecucion.Id_Proceso"
                        + " WHERE date(procesos_ejecucion.Fecha_Ejecucion) = @fecha AND procesos.Estado = @proest AND"
                        + " procesos.Id = @proid AND procesos_ejecucion.estado = @estadoProEjec AND "
                        + " procesos_ejecucion.Tipo_Proceso = @tipoEjec");
                oCon.AsignarParametroFecha("@fecha", fechaProgramacion);
                oCon.AsignarParametroEntero("@proest", Convert.ToInt32(Procesos.Estado_Proceso.Activo));
                oCon.AsignarParametroEntero("@proid", Convert.ToInt32(Procesos.Proceso.Lote_Parte_Baja));
                oCon.AsignarParametroEntero("@estadoProEjec", Convert.ToInt32(Procesos_Ejecucion.Estados_Ejecucion_Proceso.No_Iniciado));
                oCon.AsignarParametroEntero("@tipoEjec", Convert.ToInt32(tipoEjecucion));
                dt = oCon.Tabla();

                if(dt.Rows.Count > 0)
                {
                    oProEjecucion.Id = Convert.ToInt32(dt.Rows[0]["id"]);
                    oProEjecucion.Id_Proceso = Convert.ToInt32(dt.Rows[0]["id_proceso"]);
                    oProEjecucion.Id_Proceso_Automatico = Convert.ToInt32(dt.Rows[0]["id_proceso_automatico"]);
                    oProEjecucion.Fecha_Ejecucion = Convert.ToDateTime(dt.Rows[0]["fecha_ejecucion"]);
                    object value = dt.Rows[0]["Fecha_Reprogramado"];
                    if (value == DBNull.Value)
                        oProEjecucion.Fecha_Reprogramado = null;
                    else
                        oProEjecucion.Fecha_Reprogramado = Convert.ToDateTime(dt.Rows[0]["Fecha_Reprogramado"]);
                    oProEjecucion.Estado = Convert.ToInt32(dt.Rows[0]["estado"]);
                    oProEjecucion.Id_Personal = Convert.ToInt32(dt.Rows[0]["id_personal"]);
                }
                else
                {
                    oProEjecucion = null;
                }

                oCon.DesConectar();
                return oProEjecucion;
            }
            catch (Exception ex)
            {
                oCon.DesConectar();
                throw ex;
            }
        }

        public List<int> GetPartesDeLote(int idProcesoEjecucion)
        {
            try
            {
                oCon.Conectar();
                oCon.CrearComando("SELECT Id_Registro FROM procesos_ejecucion_lotes WHERE id_proceso_ejecucion = @idProcesoEjecucion;");
                oCon.AsignarParametroEntero("@idProcesoEjecucion", idProcesoEjecucion);
                List<int> partesDelLote = oCon.Tabla()
                    .AsEnumerable()
                    .Select<DataRow, int>(x => x.Field<int>("Id_Registro"))
                    .ToList();

                oCon.DesConectar();
                return partesDelLote;

            }
            catch (Exception ex)
            {
                oCon.DesConectar();
                throw ex;
            }
        }
    }
}
