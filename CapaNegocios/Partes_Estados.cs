using CapaDatos;
using System;
using System.Data;

namespace CapaNegocios
{
    public class Partes_Estados
    {
        public Int32 Id { get; set; }
        public String Nombre { get; set; }

        private Conexion oCon = new Conexion();

        public DataTable Listar()
        {
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                oCon.CrearComando("SELECT id,nombre FROM Partes_Estados WHERE Nombre <> 'SELECCIONAR PARTE' ORDER BY Id");
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
