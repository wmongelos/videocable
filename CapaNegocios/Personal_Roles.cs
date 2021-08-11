using CapaDatos;
using System;
using System.Data;

namespace CapaNegocios
{
    public class Personal_Roles
    {
        public Int32 Id { get; set; }
        public String Nombre { get; set; }
        public Int32 Borrado { get; set; }
        private Conexion oCon = new Conexion();

        public void Guardar(Personal_Roles oPersonal_Roles)
        {
            try
            {
                oCon.Conectar();
                if (oPersonal_Roles.Id > 0)
                {
                    oCon.CrearComando("UPDATE personal_roles set nombre = @nombre WHERE Id = @id");
                    oCon.AsignarParametroEntero("@id", oPersonal_Roles.Id);
                }
                else
                    oCon.CrearComando("INSERT INTO personal_roles (nombre) VALUES(@nombre)");

                oCon.AsignarParametroCadena("@nombre", oPersonal_Roles.Nombre);
                oCon.EjecutarComando();
                oCon.DesConectar();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Eliminar(int id)
        {
            try
            {
                oCon.Conectar();
                oCon.ComenzarTransaccion();
                oCon.CrearComando("UPDATE personal_roles SET Borrado = 1 WHERE Id = @id");
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
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                oCon.CrearComando("SELECT id,nombre FROM personal_roles WHERE Borrado = 0 Order By Nombre");
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

        public bool VerificarSiTienePermiso(Objetos.Acciones accion)
        {
            if(Personal.IdRol == 1)
            {
                return true;
            }

            DataTable dtResult;
            bool tienePermiso;
            try
            {
                oCon.Conectar();
                oCon.CrearComando("SELECT id FROM objetos WHERE name = @accion and tipo = @tipo");
                oCon.AsignarParametroCadena("@accion", accion.ToString());
                oCon.AsignarParametroEntero("@tipo", Convert.ToInt32(Objetos.Tipo_Objeto.ACCION));
                dtResult = oCon.Tabla();
                if (dtResult.Rows.Count == 0)
                {
                    //Si no existe la accion cargarla en la base
                    oCon.CrearComando("INSERT INTO objetos (Text, Name, Tag, Referencia, Tipo) VALUES " +
                        "(@text, @name, @tag, @ref, @tipo)");
                    oCon.AsignarParametroCadena("@text", accion.ToString().Replace('_',' '));
                    oCon.AsignarParametroCadena("@name", accion.ToString());
                    oCon.AsignarParametroCadena("@tag", "Accion");
                    oCon.AsignarParametroEntero("@ref", 0);
                    oCon.AsignarParametroEntero("@tipo", Convert.ToInt32(Objetos.Tipo_Objeto.ACCION));
                    oCon.EjecutarComando();
                    tienePermiso = false;
                }
                else
                {
                    //Si existe en la base verificar si el rol tiene asignado el objeto
                    int idObjetoAccion = Convert.ToInt32(dtResult.Rows[0]["id"]);
                    oCon.CrearComando("SELECT * FROM roles_permisos " +
                            "WHERE id_rol = @idRol AND id_objeto = @idObjeto");
                    oCon.AsignarParametroEntero("@idRol", Personal.IdRol);
                    oCon.AsignarParametroEntero("@idObjeto", idObjetoAccion);
                    tienePermiso = oCon.Tabla().Rows.Count > 0;
                }
                oCon.DesConectar();
            }
            catch (Exception)
            {
                oCon.DesConectar();
                throw;
            }
            return tienePermiso;
        }
    }
}