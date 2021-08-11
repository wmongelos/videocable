using CapaNegocios;
using System;
using System.Data;
using System.Linq;

namespace CapaPresentacion
{
    class AdministradorDeRolesPermisos
    {
        private DataTable dtRolesPermisos;
        private DataTable dtObjetos;

        public void ActualizarRolesPermisosEnLaBase()
        {
            dtRolesPermisos = new Roles_Permisos().Listar();
            dtObjetos = new Objetos().Listar(Objetos.Tipo_Objeto.TODOS);
            Roles_Permisos oRP = new Roles_Permisos();

            foreach (DataRow row in dtRolesPermisos.Rows)
            {
                if (dtObjetos.Select("Id = " + Convert.ToInt32(row["Id_Objeto"])).Count() == 0)
                {
                    oRP.BorrarObjeto(Convert.ToInt32(row["Id_Objeto"]));
                }
            }
        }
    }
}
