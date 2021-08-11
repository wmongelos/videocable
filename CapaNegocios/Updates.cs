using CapaDatos;
using System;
using System.Data;

namespace CapaNegocios
{
    public class Updates
    {
        private ConexionCloud oCon = new ConexionCloud();

        public DataTable ListarUpdates(String version)
        {
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                oCon.CrearComando("SELECT id,Detalle,Version,Fecha FROM updates WHERE version=@ver");
                oCon.AsignarParametroCadena("@ver", version);
                dt = oCon.Tabla();
                oCon.DesConectar();
            }
            catch
            {

                oCon.DesConectar();
                throw;
            }
            return dt;
        }
    }
}
