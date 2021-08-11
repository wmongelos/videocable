using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
namespace CapaNegocios
{
    public class Objetos
    {
        public int Id;
        public string Text;
        public string Name;
        public string Tag;
        public int Referencia;
        public int Tipo;

        private Conexion oCon = new Conexion();

        public enum Tipo_Objeto
        {
            TODOS = 0,
            MENU = 1,
            BTN_PANEL_INFERIOR = 2,
            ACCION = 3
        }

        public enum Acciones
        {
            Bonificar_Punitorios = 1,
            Recalcular_Punitorios = 2,
            Eliminar_Comprobante = 3,
            Acceder_Frm_Recibos = 4
        }

        public void Guardar(Objetos oObj)
        {
            try
            {
                bool identity = true;
                oCon.Conectar();

                if (oObj.Id > 0)
                {
                    oCon.CrearComando("REPLACE INTO objetos (Id, Text, Name, Tag, Referencia, Tipo) VALUES (@id, @text, @name, @tag, @ref, @tipo); SELECT @@IDENTITY");
                    oCon.AsignarParametroEntero("@id", oObj.Id);
                    identity = false;
                }
                else
                    oCon.CrearComando("REPLACE INTO objetos(Text, Name, Tag, Referencia, Tipo) VALUES(@text, @name, @tag, @ref, @tipo); SELECT @@IDENTITY");

                oCon.AsignarParametroCadena("@text", oObj.Text);
                oCon.AsignarParametroCadena("@name", oObj.Name);
                oCon.AsignarParametroCadena("@tag", oObj.Tag);
                oCon.AsignarParametroEntero("@ref", oObj.Referencia);
                oCon.AsignarParametroEntero("@tipo", oObj.Tipo);

                oCon.ComenzarTransaccion();
                if (identity)
                    oObj.Id = oCon.EjecutarScalar();
                else
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

        public DataTable Listar(Tipo_Objeto tipo)
        {
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                if (tipo == Tipo_Objeto.TODOS)
                    oCon.CrearComando("SELECT Id, Text, Name, tag, Referencia, Tipo FROM objetos");
                else if (tipo == Tipo_Objeto.MENU)
                    oCon.CrearComando($"SELECT  Id, Text, Name, tag, Referencia, Tipo FROM objetos WHERE tipo = {Convert.ToInt32(Tipo_Objeto.MENU)} ORDER BY Tag,IF(Referencia = 0,ID, referencia)");
                else if (tipo == Tipo_Objeto.BTN_PANEL_INFERIOR)
                    oCon.CrearComando($"SELECT Id, Text, Name, tag, Referencia, Tipo FROM objetos WHERE Tipo = {Convert.ToInt32(Tipo_Objeto.BTN_PANEL_INFERIOR)}");
                else if (tipo == Tipo_Objeto.ACCION)
                    oCon.CrearComando($"SELECT Id, Text, Name, tag, Referencia, Tipo FROM objetos WHERE Tipo = {Convert.ToInt32(Tipo_Objeto.ACCION)}");
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

        public void EliminarObjeto(int id_obj)
        {
            try
            {
                oCon.Conectar();
                oCon.CrearComando("DELETE FROM objetos WHERE objetos.id = @idObj");
                oCon.AsignarParametroEntero("@idObj", id_obj);
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

        public int GetId(string name)
        {
            DataTable dt = new DataTable();
            int result;
            try
            {
                oCon.Conectar();
                oCon.CrearComando("SELECT objetos.id from objetos where objetos.name = @name");
                oCon.AsignarParametroCadena("@name", name);
                dt = oCon.Tabla();

                if (dt.Rows.Count == 1)
                    result = Convert.ToInt32(dt.Rows[0][0]);
                else if (dt.Rows.Count == 0)
                    result = -1;
                else
                    throw new Exception("Error, mas de un objeto con el mismo nombre");

                oCon.DesConectar();
            }
            catch (Exception)
            {
                oCon.DesConectar();
                throw;
            }
            return result;
        }
    }
}
