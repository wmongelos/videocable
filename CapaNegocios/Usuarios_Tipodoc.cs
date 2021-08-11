using CapaDatos;
using System;
using System.Data;
using System.Windows.Forms;

namespace CapaNegocios
{
    public class Usuarios_Tipodoc
    {
        public Int32 Id { get; set; }
        public String Tipo { get; set; }

        private Conexion oCon = new Conexion();

        public DataTable Listar()
        {
            DataTable dt = new DataTable();

            try
            {
                oCon.Conectar();

                oCon.CrearComando("SELECT * from usuarios_tipodoc");

                dt = oCon.Tabla();
                oCon.DesConectar();
            }
            catch (Exception j)
            {
                oCon.DesConectar();
                MessageBox.Show(j.Message);
                throw;
            }

            return dt;
        }
    }
}
