using CapaDatos;
using System;
using System.Data;

namespace CapaNegocios
{
    public class Formulario
    {
        public Int32 id;
        public String Nombre;
        public String Tag;

        Conexion oCon = new Conexion();

        public DataTable Listar()
        {
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                oCon.CrearComando("SELECT id,nombre,tag FROM seguridad_formulario ");
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

        public Int32 Guardar(Formulario aFormulario)
        {
            Int32 retorno = 0;
            try
            {
                oCon.Conectar();
                if (aFormulario.id > 0)
                {
                    oCon.CrearComando("UPDATE seguridad_formulario SET nombre=@nom,tag=@tag1 WHERE id=@idForm");
                    oCon.AsignarParametroEntero("@idForm", aFormulario.id);
                }
                else
                    oCon.CrearComando("INSERT INTO seguridad_formulario (nombre,tag) VALUES (@nom,@tag1)");

                oCon.AsignarParametroCadena("@nom", aFormulario.Nombre);
                oCon.AsignarParametroCadena("@tag1", aFormulario.Nombre.Replace(" ", ""));
                oCon.ComenzarTransaccion();
                oCon.EjecutarComando();
                oCon.ConfirmarTransaccion();
                oCon.DesConectar();
            }
            catch
            {
                oCon.CancelarTransaccion();
                oCon.DesConectar();
                retorno = -1;
            }
            return retorno;
        }

        public Int32 GetIdFormulario(string nombreFormulario)
        {
            Int32 id = -1;
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                oCon.CrearComando("SELECT id FROM seguridad_formulario WHERE tag=@tag1");
                oCon.AsignarParametroCadena("@tag1", nombreFormulario.Replace(" ", ""));
                dt = oCon.Tabla();
                oCon.DesConectar();
            }
            catch
            {
                oCon.DesConectar();

            }
            if (dt.Rows.Count > 0)
                id = Convert.ToInt32(dt.Rows[0]["id"]);
            return id;
        }

    }
}
