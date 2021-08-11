using CapaDatos;
using System;
using System.Data;

namespace CapaNegocios
{
    public class Organismos
    {
        public Int32 Id { get; set; }
        public String Descripcion { get; set; }
        public Int32 Borrado { get; set; }
        private Conexion oCon = new Conexion();

        public void Guardar(Organismos oOrganismo)
        {
            try
            {
                oCon.Conectar();
                if (oOrganismo.Id > 0)
                {
                    oCon.CrearComando("UPDATE organismos set Descripcion = @desc WHERE Id = @id");
                    oCon.AsignarParametroEntero("@id", oOrganismo.Id);
                }
                else
                    oCon.CrearComando("INSERT INTO organismos(Descripcion) VALUES(@desc)");
                oCon.AsignarParametroCadena("@desc", oOrganismo.Descripcion);
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

        public DataTable Listar()
        {
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                oCon.CrearComando("SELECT Id, Descripcion FROM organismos WHERE borrado=0 ORDER BY Descripcion");
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
                oCon.CrearComando("UPDATE organismos SET Borrado = 1 WHERE Id = @id");
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

    }
}
