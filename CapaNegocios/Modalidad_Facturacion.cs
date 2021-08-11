using CapaDatos;
using System;
using System.Data;

namespace CapaNegocios
{
    public class Modalidad_Facturacion
    {
        Conexion oCon = new Conexion();

        public enum TIPO
        {
            MANUAL = 1,
            PREIMPRESOS = 2,
            ELECTRONICA = 3,
            AUTOIMPRESOR = 4,
            CESP = 5
        }

        public DataTable Listar()
        {
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                oCon.CrearComando("SELECT id, descripcion FROM modalidad_facturacion ORDER BY Id");
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
