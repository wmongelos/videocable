using CapaDatos;
using System;
using System.Data;


namespace CapaNegocios
{
    public class Usuarios_Profesiones
    {
        public Int32 Id { get; set; }
        public String Nombre { get; set; }
        public Int32 Borrado { get; set; }

        private Conexion oCon = new Conexion();

        public void Guardar(Usuarios_Profesiones oProfe)
        {
            try
            {
                oCon.Conectar();

                if (oProfe.Id > 0)
                {
                    oCon.CrearComando("UPDATE usuarios_profesiones set Nombre = @nombre WHERE Id = @id");
                    oCon.AsignarParametroEntero("@id", oProfe.Id);
                }
                else
                    oCon.CrearComando("INSERT INTO usuarios_profesiones(Nombre) VALUES(@nombre)");

                oCon.AsignarParametroCadena("@nombre", oProfe.Nombre);

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

        public void Eliminar(int id)
        {
            try
            {
                oCon.Conectar();
                oCon.ComenzarTransaccion();
                oCon.CrearComando("UPDATE usuarios_profesiones SET Borrado = 1 WHERE Id = @id");
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

        public DataTable Listar()
        {
            oCon.Conectar();
            oCon.CrearComando("SELECT * FROM usuarios_profesiones WHERE Borrado = 0 Order By Nombre");

            DataTable dt = oCon.Tabla();

            oCon.DesConectar();

            return dt;
        }

        public Boolean VerificaExistente(int Id)
        {
            Boolean Retorno = false;
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                oCon.CrearComando("SELECT Id FROM usuarios WHERE Id_Usuarios_Profesiones=@id");
                oCon.AsignarParametroEntero("@id", Id);
                dt = oCon.Tabla();
                oCon.DesConectar();
            }
            catch (Exception)
            {

                throw;
            }
            if (dt.Rows.Count > 0)
            {
                Retorno = true;
            }
            else
            {
                Retorno = false;
            }
            return Retorno;
        }
    }
}
