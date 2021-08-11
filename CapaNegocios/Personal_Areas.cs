using CapaDatos;
using System;
using System.Data;

namespace CapaNegocios
{
    public class Personal_Areas
    {
        public Int32 Id { get; set; }
        public String Nombre { get; set; }
        public String Req_horario { get; set; }
        public Int32 Borrado { get; set; }

        private Conexion oCon = new Conexion();

        public void Guardar(Personal_Areas oPersonal_Area)
        {
            try
            {
                oCon.Conectar();

                if (oPersonal_Area.Id > 0)
                {
                    oCon.CrearComando("UPDATE personal_areas set Nombre = @nombre, Req_horario=@req_horario WHERE Id = @id");
                    oCon.AsignarParametroEntero("@id", oPersonal_Area.Id);
                }
                else
                    oCon.CrearComando("INSERT INTO personal_areas(Nombre,Req_horario) VALUES(@nombre,@req_horario)");

                oCon.AsignarParametroCadena("@nombre", oPersonal_Area.Nombre);
                oCon.AsignarParametroCadena("@req_horario", oPersonal_Area.Req_horario);

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

        public DataTable Listar(bool conTodas = false)
        {
            DataTable dt = new DataTable();

            try
            {
                oCon.Conectar();
                if (conTodas)
                    oCon.CrearComando("SELECT 0 as Id, UPPER('TODAS') as nombre UNION ALL SELECT id, nombre FROM personal_areas WHERE Borrado = 0  ORDER BY Id");
                else
                    oCon.CrearComando("SELECT * FROM personal_areas WHERE Borrado = 0 ORDER BY Nombre");
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

        public void Eliminar(int id)
        {
            try
            {
                oCon.Conectar();
                oCon.ComenzarTransaccion();
                oCon.CrearComando("UPDATE personal_areas SET Borrado = 1 WHERE Id = @id");
                oCon.AsignarParametroEntero("@id", id);
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

        public void EliminaidPersonalAreas(int id)
        {
            try
            {
                oCon.Conectar();
                oCon.ComenzarTransaccion();
                oCon.CrearComando("UPDATE personal SET Id_Personal_Areas = 0 WHERE Id_PErsonal_Areas = @id");
                oCon.AsignarParametroEntero("@id", id);
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

        public DataTable ListarPersonalAreas(int idArea)
        {
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                oCon.CrearComando("SELECT personal.id,personal.nombre, personal.clave, personal.Id_Personal_Areas, personal_areas.Nombre " +
                    "FROM personal " +
                    "LEFT JOIN personal_areas ON personal.Id_Personal_Areas = personal_areas.Id " +
                    "WHERE personal.borrado = 0 AND Id_Personal_Areas = @AreaID ");
                oCon.AsignarParametroEntero("@AreaID", idArea);
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
