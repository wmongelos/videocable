using CapaDatos;
using System;
using System.Data;

namespace CapaNegocios
{
    public class Equipos_Estados
    {
        private Conexion oCon = new Conexion();

        public DataTable Listar()
        {
            DataTable dt = new DataTable();

            try
            {
                oCon.Conectar();
                oCon.CrearComando("SELECT id,nombre from equipos_estados order by nombre ASC");
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

        public DataTable Listar_EstadosEnStock()
        {
            DataTable dt = new DataTable();

            try
            {
                oCon.Conectar();
                oCon.CrearComando("SELECT equipos_tipos.Id AS id_Tipo, " +
                    "equipos_tipos.Nombre AS Tipo, COUNT(equipos_estados.Id) AS Cantidad, equipos_estados.Nombre AS Estado " +
                    "FROM equipos " +
                    "LEFT JOIN equipos_tipos ON equipos.Id_Equipos_Tipos = equipos_tipos.id " +
                    "LEFT JOIN equipos_estados ON equipos.Id_Equipos_Estados = equipos_estados.Id " +
                    "WHERE equipos.borrado = 0 AND equipos_tipos.borrado = 0 " +
                    "GROUP BY equipos_estados.id; ");
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
