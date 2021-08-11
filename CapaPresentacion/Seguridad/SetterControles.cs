using CapaNegocios;
using CapaPresentacion.Controles;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace CapaPresentacion.Seguridad
{
    class SetterControles
    {
        private DataTable dtRolesPermisos;
        private frmUsuariosPrincipal frmPrincipal;
        private Panel pnlInferior;

        public void SetearControles(MenuStrip menu, frmUsuariosPrincipal frmPrincipal)
        {
            this.frmPrincipal = frmPrincipal;
            this.pnlInferior = frmPrincipal.pnlInferior;
            dtRolesPermisos = null;
            DataRow[] drs = Tablas.DataRolesPermisos.Select(string.Format("Id_Rol = {0}", Personal.IdRol));
            if (drs.Count() > 0)
                dtRolesPermisos = drs.CopyToDataTable();

            foreach (ToolStripMenuItem item in menu.Items)
            {
                if (item.HasDropDownItems)
                {
                    recorrerMenuItemsSetear(item);
                }
            }
            recorrerPanelInferiorSetear();
        }

        private void recorrerMenuItemsSetear(ToolStripMenuItem menuItem)
        {
            foreach (ToolStripItem item in menuItem.DropDownItems)
            {
                try
                {
                    ToolStripMenuItem mnItem = item as ToolStripMenuItem;

                    if (mnItem != null)
                    {
                        if (dtRolesPermisos == null || dtRolesPermisos.Select(string.Format("Name = '{0}'", mnItem.Name)).Count() <= 0)
                        mnItem.Enabled = false;

                        if (mnItem.HasDropDownItems)
                        {
                            recorrerMenuItemsSetear(mnItem);
                        }
                    }
                }
                catch { }
            }
        }

        private void recorrerPanelInferiorSetear()
        {
            for (int i = 0; i < pnlInferior.Controls.Count; i++)
            {
                bool estadoEnabled = true;
                if (dtRolesPermisos == null || dtRolesPermisos.Select(string.Format("Name = '{0}'", pnlInferior.Controls[i].Name)).Count() <= 0)
                    estadoEnabled = false;

                frmPrincipal.permisoBotones.Add((boton)pnlInferior.Controls[i], estadoEnabled);
                pnlInferior.Controls[i].Enabled = estadoEnabled;
            }
        }
    }
}


