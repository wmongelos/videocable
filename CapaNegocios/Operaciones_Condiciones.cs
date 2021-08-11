using CapaDatos;
using System;
using System.Data;

namespace CapaNegocios
{
    public class Operaciones_Condiciones
    {
        public enum Condiciones
        {
            ASOCIADO_A_UN_PLASTICO = 1,
            TIENE_PARTES_ABIERTOS = 2,
            PRESENTA_DEUDA = 3,
            ASOCIADO_A_UNA_APP_EXTERNA = 4,
            SERVICIO_NO_DISPONIBLE=5
        }

        public int Id { get; set; }
        public string Descripcion { get; set; }

        private Conexion oCon = new Conexion();

        public DataTable Listar()
        {
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                oCon.CrearComando("SELECT * FROM Operaciones_Condiciones");
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
