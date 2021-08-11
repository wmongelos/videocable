using CapaDatos;
using System;
using System.Data;

namespace CapaNegocios
{
    public class Funcion
    {
        private Conexion oCon = new Conexion();

        public Int32 GuardarFuncion(int idFormulario, string funcion)
        {
            Int32 retorno = 0;
            try
            {
                oCon.Conectar();
                oCon.CrearComando("INSERT INTO seguridad_formulario_funciones (id_formulario,nombre) VALUES (@idForm,@nombreFuncion)");
                oCon.AsignarParametroEntero("@idForm", idFormulario);
                oCon.AsignarParametroCadena("@nombreFuncion", funcion);
                oCon.ComenzarTransaccion();
                oCon.EjecutarComando();
                oCon.ConfirmarTransaccion();
                oCon.DesConectar();
            }
            catch (Exception)
            {
                oCon.CancelarTransaccion();
                oCon.DesConectar();

                retorno = -1;
                throw;
            }
            return retorno;
        }

        public DataTable ListarFunciones()
        {
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                oCon.CrearComando("SELECT id,id_formulario,nombre FROM seguridad_formulario_funciones");
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

        public Int32 GetFuncionId(string nombreFuncion)
        {
            Int32 retorno = 0;
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                oCon.CrearComando("SELECT id,nombre FROM seguridad_formulario_funciones WHERE nombre=@nom");
                oCon.AsignarParametroCadena("@nom", nombreFuncion);
                dt = oCon.Tabla();
                oCon.DesConectar();
            }
            catch (Exception)
            {
                oCon.DesConectar();
            }
            if (dt.Rows.Count > 0)
                retorno = Convert.ToInt32(dt.Rows[0]["id"]);
            else
                retorno = -1;

            return retorno;

        }
    }
}
