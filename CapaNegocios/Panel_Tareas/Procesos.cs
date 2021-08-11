using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CapaNegocios.Panel_Tareas
{
    public class Procesos
    {
        public enum Proceso
        {
            Calculo_Punitorios = 1,
            Lote_Parte_Baja = 2
        }

        public enum Estado_Proceso
        {
            Activo = 0,
            Inactivo = 1
        };

        public int Id { get; set; }
        public string Descripcion { get; set; }
        public TimeSpan Hora_Ejecucion_Desde { get; set; }
        public TimeSpan Hora_Ejecucion_Hasta { get; set; }
        public int Estado { get; set; }

        private readonly Conexion oCon = new Conexion();

        public int Guardar(Procesos oProceso)
        {
            if(!Enum.IsDefined(typeof(Estado_Proceso), oProceso.Estado))
            {
                throw new Exception("valor de estado no definido");
            }

            try
            {
                oCon.Conectar();
                oCon.ComenzarTransaccion();
                oCon.CrearComando("INSERT INTO procesos (Descripcion, Estado)" +
                    "VALUES (@descripcion, @estado); SELECT @@IDENTITY");
                oCon.AsignarParametroCadena("@descripcion", oProceso.Descripcion);
                oCon.AsignarParametroEntero("@estado", oProceso.Estado);
                int idProceso = oCon.EjecutarScalar();
                oCon.ConfirmarTransaccion();
                oCon.DesConectar();
                return idProceso;
            }
            catch (Exception)
            {
                oCon.CancelarTransaccion();
                oCon.DesConectar();
                throw;
            }
        }

        public DataTable Listar()
        {
            try
            {
                oCon.Conectar();
                oCon.CrearComando("SELECT Id, Descripcion, Hora_Ejecucion_Desde, Hora_Ejecucion_Hasta " +
                    "FROM procesos WHERE estado = @estado");
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

        public bool ProcesoDentroDelRango(int idProceso)
        {
            try
            {
                oCon.Conectar();
                oCon.CrearComando("SELECT Id, Descripcion, Hora_Ejecucion_Desde, Hora_Ejecucion_Hasta " +
                    "FROM procesos WHERE id = @id AND estado = @estado");
                oCon.AsignarParametroEntero("@estado", Convert.ToInt32(Procesos.Estado_Proceso.Activo));
                oCon.AsignarParametroEntero("@id", idProceso);
                DataTable dt = oCon.Tabla();
                oCon.DesConectar();

                if (dt.Rows.Count == 0)
                    return false;

                if(TimeSpan.Parse(dt.Rows[0]["Hora_Ejecucion_Desde"].ToString()) <= DateTime.Now.TimeOfDay &&
                   TimeSpan.Parse(dt.Rows[0]["Hora_Ejecucion_Hasta"].ToString()) >= DateTime.Now.TimeOfDay)
                {
                    return true;
                }

                return false;
            }
            catch (Exception)
            {
                oCon.DesConectar();
                throw;
            }
        }
    }
}
