using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;

namespace CapaNegocios
{
    public class Roles_Permisos
    {
        private Conexion oCon = new Conexion();

        public int Id_Rol;
        public int Id_Objeto;

        public void Guardar(int id_rol, List<int> ids_objetos)
        {
            try
            {
                oCon.Conectar();

                foreach (int i in ids_objetos)
                {
                    int id = GetIdRolPermiso(id_rol, i);
                    if (id == 0)
                    {
                        oCon.CrearComando("REPLACE INTO roles_permisos ( id_rol, id_objeto) VALUES (@rol, @obj)");

                        oCon.AsignarParametroEntero("@rol", id_rol);
                        oCon.AsignarParametroEntero("@obj", i);

                        oCon.ComenzarTransaccion();
                        oCon.EjecutarComando();
                        oCon.ConfirmarTransaccion();
                    }
                }
                oCon.DesConectar();
            }
            catch (Exception)
            {
                oCon.CancelarTransaccion();
                oCon.DesConectar();
                throw;
            }
        }


        private int GetIdRolPermiso(int id_rol, int id_objeto)
        {
            DataTable dt = new DataTable();
            try
            {
                oCon.CrearComando("SELECT IFNULL((select id from roles_permisos WHERE id_rol = @rol and id_objeto = @obj) ,0) as id;");
                oCon.AsignarParametroEntero("@rol", id_rol);
                oCon.AsignarParametroEntero("@obj", id_objeto);
                dt = oCon.Tabla();

                return Convert.ToInt32(dt.Rows[0]["Id"]);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable Listar(int id_rol = 0)
        {
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                string comando = "SELECT roles_permisos.Id_Rol, roles_permisos.Id_Objeto, objetos.Name FROM roles_permisos " +
                                "LEFT JOIN objetos ON objetos.id = roles_permisos.id_objeto";
                if (id_rol > 0)
                    comando = string.Format("{0} WHERE roles_permisos.id_rol = {1}", comando, id_rol);

                oCon.CrearComando(comando);
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

        public void Borrar(int id_rol, List<int> ids_objetos)
        {
            try
            {
                oCon.Conectar();
                foreach (int idObj in ids_objetos)
                {
                    oCon.CrearComando("DELETE FROM roles_permisos WHERE id_rol = @rol and id_objeto = @objeto");
                    oCon.AsignarParametroEntero("@rol", id_rol);
                    oCon.AsignarParametroEntero("@objeto", idObj);
                    oCon.ComenzarTransaccion();
                    oCon.EjecutarComando();
                    oCon.ConfirmarTransaccion();
                }
                oCon.DesConectar();
            }
            catch (Exception)
            {
                oCon.CancelarTransaccion();
                oCon.DesConectar();
                throw;
            }
        }

        public void BorrarObjeto(int id_objeto)
        {
            try
            {
                oCon.Conectar();
                oCon.CrearComando("DELETE FROM roles_permisos WHERE roles_permisos.Id_Objeto = @objeto");
                oCon.AsignarParametroEntero("@objeto", id_objeto);
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
