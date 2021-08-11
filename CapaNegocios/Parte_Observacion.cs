using CapaDatos;
using System;
using System.Data;

namespace CapaNegocios
{
    public class Parte_Observacion
    {
        public Int32 Id { get; set; }
        public Int32 IdParte { get; set; }
        public Int32 IdArea { get; set; }
        public Int32 IdPersonal { get; set; }
        public DateTime Fecha { get; set; }
        public String Texto { get; set; }
        public Int32 Borrado { get; set; }

        private Conexion oCon = new Conexion();

        public Int32 Guardar(Parte_Observacion oParteObs)
        {
            Int32 salida = 0;
            try
            {
                oCon.Conectar();
                oCon.CrearComando("insert into partes_observaciones (id_parte,id_area,id_personal,fecha,observacion) VALUES (@parte_id,@area_id,@personal_id,@fecha,@obs)");
                oCon.AsignarParametroEntero("@parte_id", oParteObs.IdParte);
                oCon.AsignarParametroEntero("@area_id", oParteObs.IdArea);
                oCon.AsignarParametroEntero("@personal_id", oParteObs.IdPersonal);
                oCon.AsignarParametroFecha("@fecha", oParteObs.Fecha);
                oCon.AsignarParametroCadena("@obs", oParteObs.Texto);
                oCon.ComenzarTransaccion();
                oCon.EjecutarComando();
                oCon.ConfirmarTransaccion();
                oCon.DesConectar();
            }
            catch (Exception)
            {
                oCon.CancelarTransaccion();
                oCon.DesConectar();
                salida = -1;
                throw;
            }
            return salida;
        }

        public DataTable Listar(int idParte)
        {
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                oCon.CrearComando("SELECT partes_observaciones.id,partes_observaciones.id_parte,personal_areas.nombre as area,personal.nombre as personal," +
                    "partes_observaciones.fecha,partes_observaciones.id_area,partes_observaciones.id_personal,partes_observaciones.observacion " +
                    "from partes_observaciones " +
                    "inner join personal_areas on personal_areas.id=partes_observaciones.id_area " +
                    "inner join personal on personal.id=partes_observaciones.id_personal " +
                    "where id_parte=@id order by partes_observaciones.id asc");
                oCon.AsignarParametroEntero("@id", idParte);
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

        public DataTable ConsultarDetalleFallaYDetalleSolucion(int idParte)
        {
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                string consulta = "SELECT partes.id AS id_parte, partes.Id_Tecnicos as id_tecnico, personal_tec.Nombre AS tecnico,  partes.Fecha_Realizado,"
                                  + " partes.Id_Operadores AS id_operadores, personal_ope.Nombre AS operador, partes.Fecha_Reclamo,"
                                  + " partes_fallas.Nombre AS tipo_falla, partes.Detalle_Falla,"
                                  + " partes_soluciones.Nombre AS tipo_solucion, partes.Detalle_Solucion FROM partes"
                                  + " LEFT JOIN personal AS personal_tec ON personal_tec.Id = partes.id_tecnicos"
                                  + " LEFT JOIN personal AS personal_ope ON personal_ope.Id = partes.Id_Operadores"
                                  + " LEFT JOIN partes_fallas ON partes_fallas.Id = partes.Id_Partes_Fallas"
                                  + " LEFT JOIN partes_soluciones ON partes_soluciones.Id = partes.Id_Partes_Soluciones"
                                  + " WHERE partes.borrado = 0 AND partes.id = @idParte";
                oCon.CrearComando(consulta);
                oCon.AsignarParametroEntero("@idParte", idParte);
                dt = oCon.Tabla();
                oCon.DesConectar();
            }
            catch (Exception)
            {
                oCon.DesConectar();
            }
            return dt;
        }

        public DataTable ConsultarDetalleObservaciones(int idParte)
        {
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                string consulta = "SELECT partes_observaciones.observacion, partes_observaciones.fecha, personal.Nombre AS personal"
                                + " FROM partes_observaciones"
                                + " LEFT JOIN personal ON personal.Id = partes_observaciones.id_personal"
                                + " WHERE partes_observaciones.borrado = 0"
                                + " AND partes_observaciones.id_parte = @idParte";
                oCon.CrearComando(consulta);
                oCon.AsignarParametroEntero("@idParte", idParte);
                dt = oCon.Tabla();
                oCon.DesConectar();
            }
            catch (Exception)
            {
                oCon.DesConectar();
            }
            return dt;
        }

    }
}
