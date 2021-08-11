using CapaDatos;
using System;
using System.Data;

namespace CapaNegocios
{
    public class Moviles
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Dominio { get; set; }
        public int Borrado { get; set; }

        Conexion oConexion = new Conexion();

        public void Guardar(Moviles oMoviles)
        {
            try
            {
                oConexion.Conectar();

                if (oMoviles.Id > 0)
                {
                    oConexion.CrearComando("UPDATE moviles set nombre = @nom, dominio = @dom WHERE id = @id");
                    oConexion.AsignarParametroEntero("@id", oMoviles.Id);
                }
                else
                    oConexion.CrearComando("INSERT moviles (nombre,dominio) VALUES(@nom, @dom)");

                oConexion.AsignarParametroCadena("@nom", oMoviles.Nombre);
                oConexion.AsignarParametroCadena("@dom", oMoviles.Dominio);

                oConexion.ComenzarTransaccion();
                oConexion.EjecutarComando();
                oConexion.ConfirmarTransaccion();
                oConexion.DesConectar();
            }
            catch (Exception)
            {
                oConexion.CancelarTransaccion();
                oConexion.DesConectar();

                throw;
            }
        }

        public DataTable Listar(bool paraCombo = false)
        {
            DataTable dt = new DataTable();

            try
            {
                oConexion.Conectar();
                if (paraCombo)
                    oConexion.CrearComando("select 0 as id, 'TODOS' as nombre UNION ALL select moviles.id, moviles.nombre FROM moviles where moviles.borrado = 0");
                else
                    oConexion.CrearComando("select id,nombre,dominio from moviles where borrado=0");
                dt = oConexion.Tabla();
                oConexion.DesConectar();
            }
            catch (Exception)
            {
                oConexion.DesConectar();
                throw;
            }

            return dt;
        }

        public void Eliminar(int id)
        {
            try
            {
                oConexion.Conectar();
                oConexion.ComenzarTransaccion();
                oConexion.CrearComando("UPDATE moviles SET borrado = 1 WHERE id = @id");
                oConexion.AsignarParametroEntero("@id", id);
                oConexion.EjecutarComando();
                oConexion.ConfirmarTransaccion();
                oConexion.DesConectar();
            }
            catch (Exception)
            {
                oConexion.CancelarTransaccion();
                oConexion.DesConectar();
                throw;
            }
        }
    }
}
