using CapaDatos;
using System;

namespace CapaNegocios
{
    public class Log_Acciones
    {
        public static void Guardar(int id_responsable, int id_objeto_accion, DateTime fecha, int id_entidad, int id_registro)
        {
            Conexion oCon = new Conexion();
            try
            {
                oCon.Conectar();
                oCon.CrearComando("INSERT INTO log_acciones (id_responsable, id_objeto_accion, fecha, id_entidad, id_registro)" +
                    " VALUES (@resp, @objeto, @fecha, @entidad, @registro)");
                oCon.AsignarParametroEntero("@resp", id_responsable);
                oCon.AsignarParametroEntero("@objeto", id_objeto_accion);
                oCon.AsignarParametroFecha("@fecha", fecha);
                oCon.AsignarParametroEntero("@entidad", id_entidad);
                oCon.AsignarParametroEntero("@registro", id_registro);
                oCon.ComenzarTransaccion();
                oCon.EjecutarComando();
                oCon.ConfirmarTransaccion();
                oCon.DesConectar();
            }
            catch (Exception)
            {
                oCon.CancelarTransaccion();
                oCon.ConfirmarTransaccion();
                throw;
            }
        }
    }
}
