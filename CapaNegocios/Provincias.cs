using CapaDatos;
using System;
using System.Data;

namespace CapaNegocios
{
    public class Provincias
    {
        public Int32 Id { get; set; }
        public String Nombre { get; set; }
        public Int32 Borrado { get; set; }

        private Conexion oCon = new Conexion();

        public void Guardar(Provincias oProv)
        {
            try
            {
                oCon.Conectar();

                if (oProv.Id > 0)
                {
                    oCon.CrearComando("UPDATE provincias set Nombre = @nombre WHERE Id = @id");
                    oCon.AsignarParametroEntero("@id", oProv.Id);
                }
                else
                    oCon.CrearComando("INSERT INTO provincias(Nombre) VALUES(@nombre)");

                oCon.AsignarParametroCadena("@nombre", oProv.Nombre);

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

        public void Eliminar(int id)
        {
            try
            {
                oCon.Conectar();
                oCon.ComenzarTransaccion();
                oCon.CrearComando("UPDATE provincias SET Borrado = 1 WHERE Id = @id");
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

        public void EliminaidProvincia(int id)
        {
            try
            {
                oCon.Conectar();
                oCon.ComenzarTransaccion();
                oCon.CrearComando("UPDATE localidades SET Id_Provincias = 0 WHERE Id_Provincias = @id");
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

        public DataTable Listar()
        {
            oCon.Conectar();
            oCon.CrearComando("SELECT * FROM provincias WHERE Borrado = 0 Order By Nombre");
            DataTable dt = oCon.Tabla();
            oCon.DesConectar();

            return dt;
        }

        public DataTable ListarCantidadLocalidadesPorProvincia()
        {
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                oCon.CrearComando("SELECT *,(SELECT COUNT(*) " +
                    "FROM localidades " +
                    "WHERE Id_Provincias = Provincias.Id) AS TotalLoc " +
                    "FROM provincias " +
                    "WHERE Borrado = 0 ORDER BY Nombre");
                dt = oCon.Tabla();
                oCon.DesConectar();
            }
            catch (Exception)
            {

                throw;
            }

            return dt;

        }
    }
}
