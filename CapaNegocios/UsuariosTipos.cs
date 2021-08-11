using CapaDatos;
using System;
using System.Data;

namespace CapaNegocios
{
    public class UsuariosTipos
    {
        public Int32 Id { get; set; }
        public String Tipo { get; set; }
        public Int32 UF { get; set; }
        public Int32 Servicios { get; set; }

        public static DataTable dtUsuariosTipos;

        private Conexion oCon = new Conexion();

        public DataTable Listar()
        {
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                oCon.CrearComando("SELECT id,Tipo,UF,Servicios FROM usuarios_tipos");
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

        public DataRow Listar(int id)
        {
            DataRow dr = null;
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                oCon.CrearComando("SELECT id,Tipo,UF,Servicios FROM usuarios_tipos WHERE id=@idTipo");
                oCon.AsignarParametroEntero("@idTipo", id);
                dt = oCon.Tabla();
                oCon.DesConectar();
            }
            catch (Exception)
            {
                oCon.DesConectar();
                throw;
            }
            if (dt.Rows.Count > 0)
                dr = dt.Rows[0];
            return dr;
        }
    }
}
