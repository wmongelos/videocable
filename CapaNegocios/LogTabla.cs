using CapaDatos;
using System;

namespace CapaNegocios
{
    public class LogTabla
    {
        private Conexion oCon = new Conexion();

        public void Guardar(string tabla, int clavePrimaria, string campo, string valorAntiguo, string valorNuevo)
        {
            try
            {
                oCon.Conectar();
                oCon.CrearComando("INSERT INTO log (fecha,tabla,clave_primaria,campo,valor_antiguo,valor_nuevo,id_personal) VALUES (@fecha,@tabla,@clave,@campo,@valor_a,@valor_n,@idpersonal)");
                oCon.AsignarParametroFecha("@fecha", DateTime.Now);
                oCon.AsignarParametroCadena("@tabla", tabla);
                oCon.AsignarParametroEntero("@clave", clavePrimaria);
                oCon.AsignarParametroCadena("@campo", campo);
                oCon.AsignarParametroCadena("@valor_a", valorAntiguo);
                oCon.AsignarParametroCadena("@valor_n", valorNuevo);
                oCon.AsignarParametroEntero("@idpersonal", Personal.Id_Login);
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
    }
}
