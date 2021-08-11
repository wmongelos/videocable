using CapaDatos;
using System;
using System.Data;

namespace CapaNegocios
{
    public class Articulos_Rubros
    {
        public Int32 Id;
        public String Descripcion;

        private Conexion oCon = new Conexion();

        public void Guardar(Articulos_Rubros oArticuloRubro)
        {

            try
            {
                oCon.Conectar();

                if (oArticuloRubro.Id > 0)
                {
                    oCon.CrearComando("UPDATE Articulos_Rubros SET Descripcion = @des WHERE Id = @id");

                    oCon.AsignarParametroEntero("@id", oArticuloRubro.Id);
                }
                else
                    oCon.CrearComando("INSERT INTO Articulos_Rubros(Descripcion) VALUES(@des)");

                oCon.AsignarParametroCadena("@des", oArticuloRubro.Descripcion);

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

        public void Eliminar(Int32 Id)
        {
            try
            {
                oCon.Conectar();
                oCon.CrearComando(String.Format("UPDATE Articulos_Rubros SET Borrado = 1 WHERE Id = {0}", Id));
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

        public DataTable Listar(bool condicion = false)
        {
            DataTable dt = new DataTable();

            try
            {
                if (condicion == true)
                {
                    oCon.Conectar();
                    oCon.CrearComando("SELECT 0 AS Id,' SIN RUBRO' AS Descripcion " +
                        "UNION ALL " +
                        "SELECT Id, Descripcion FROM Articulos_Rubros WHERE Borrado = 0 ORDER BY Descripcion");
                    dt = oCon.Tabla();
                    oCon.DesConectar();
                }
                else
                {
                    oCon.Conectar();
                    oCon.CrearComando("SELECT Id, Descripcion FROM Articulos_Rubros WHERE Borrado = 0 ORDER BY Descripcion");
                    dt = oCon.Tabla();
                    oCon.DesConectar();
                }
            }
            catch (Exception)
            {

                throw;
            }


            return dt;

        }
    }
}
