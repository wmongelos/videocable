using CapaDatos;
using System;
using System.Data;

namespace CapaNegocios
{
    public class TipoComprobantes
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string letra { get; set; }
        public int numeracion { get; set; }
        public int codigo_afip { get; set; }
        public string presenta_Venta { get; set; }

        private Conexion oCon = new Conexion();

        public static Int32 Id_Login;
        public static String Name_Login;
        public static Int32 Id_Punto_Login;

        public void Guardar(TipoComprobantes oTipoComprobantes)
        {
            try
            {
                oCon.Conectar();
                if (oTipoComprobantes.id > 0)
                {
                    oCon.CrearComando("UPDATE comprobantes_tipo SET nombre=@nombre, borrado=@borrado, letra=@letra, numeracion=@numeracion, Codigo_Afip=@codigo_afip, presenta_ventas=@presenta_ventas WHERE id=@id");
                    oCon.AsignarParametroEntero("@id", oTipoComprobantes.id);
                }
                else
                    oCon.CrearComando("INSERT INTO comprobantes_tipo (nombre,letra,numeracion,codigo_afip,presenta_ventas,borrado)" +
                       " VALUES(@nombre,@letra,@numeracion,@codigo_afip,@presenta_ventas,@borrado)");
                oCon.AsignarParametroCadena("@nombre", oTipoComprobantes.nombre);
                oCon.AsignarParametroCadena("@letra", oTipoComprobantes.letra);
                oCon.AsignarParametroEntero("@numeracion", oTipoComprobantes.numeracion);
                oCon.AsignarParametroEntero("@codigo_afip", oTipoComprobantes.codigo_afip);
                oCon.AsignarParametroCadena("@presenta_ventas", oTipoComprobantes.presenta_Venta);
                oCon.AsignarParametroEntero("@borrado", 0);
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
            oCon.Conectar();
            oCon.CrearComando("SELECT id,nombre,letra,codigo_afip,Presenta_Ventas FROM comprobantes_tipo WHERE borrado=0 ORDER BY id ASC");
            DataTable dt = oCon.Tabla();
            oCon.DesConectar();
            return dt;
        }

        public void Eliminar(int id)
        {
            try
            {
                oCon.Conectar();
                oCon.ComenzarTransaccion();
                oCon.CrearComando("UPDATE comprobantes_tipo SET Borrado = 1 WHERE Id = @id");
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
