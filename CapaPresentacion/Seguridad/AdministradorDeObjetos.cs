using CapaNegocios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace CapaPresentacion
{
    class AdministradorDeObjetos
    {
        private Stack<int> ultimoId = new Stack<int>();
        private DataTable dt = new DataTable();
        private DataTable dtObjetosConfirmados;

        #region Guardar_Menu
        public void ActualizarMenuEnLaBase(MenuStrip menu)
        {
            Objetos obj = new Objetos();
            ultimoId.Clear();
            ultimoId.Push(0);
            crearDataTableObjetos();
            foreach (ToolStripMenuItem item in menu.Items)
            {
                if (item.HasDropDownItems)
                {
                    recorrerMenuItemsGuardar(item, item.Text);
                }
            }
            eliminarObjetosQueNoEstan(1);
        }

        private void recorrerMenuItemsGuardar(ToolStripMenuItem menuItem, string nombreMenu)
        {
            foreach (ToolStripItem item in menuItem.DropDownItems)
            {
                try
                {
                    if (item.GetType() != typeof(ToolStripSeparator))
                    {
                        ToolStripMenuItem mnItem = item as ToolStripMenuItem;
                        Objetos oObj = new Objetos();

                        oObj.Referencia = ultimoId.First();
                        oObj.Text = mnItem.Text;
                        oObj.Name = mnItem.Name;
                        oObj.Tag = nombreMenu;
                        oObj.Tipo = 1;

                        int id = oObj.GetId(oObj.Name);
                        if (id > 0)
                            oObj.Id = id;
                        oObj.Guardar(oObj);
                        Roles_Permisos oRP = new Roles_Permisos();
                        //Se asigna el nuevo objeto al rol administrador
                        oRP.Guardar(1, new List<int> { oObj.Id });
                        confirmarObjetoQueEsta(oObj.Id);

                        if (mnItem.HasDropDownItems)
                        {
                            ultimoId.Push(oObj.Id);
                            recorrerMenuItemsGuardar(mnItem, nombreMenu);
                        }
                    }
                    
                }
                catch { }
            }
            if (ultimoId.Count > 1)
                ultimoId.Pop();
        }
        #endregion

        #region Guardar_PanelBotonesInferior
        public void ActualizarPanelBotones(Panel pnlBotones)
        {
            crearDataTableObjetos();
            for (int i = 0; i < pnlBotones.Controls.Count; i++)
            {
                Objetos oObj = new Objetos();

                oObj.Referencia = 0;
                oObj.Name = pnlBotones.Controls[i].Name;
                oObj.Text = pnlBotones.Controls[i].Text;
                oObj.Tag = "Botonera_Inferior";
                oObj.Tipo = 2;
                int id = oObj.GetId(oObj.Name);
                if (id > 0)
                    oObj.Id = id;
                oObj.Guardar(oObj);
                Roles_Permisos oRP = new Roles_Permisos();
                //Se asigna el nuevo objeto al rol administrador
                oRP.Guardar(1, new List<int> { oObj.Id });
                confirmarObjetoQueEsta(oObj.Id);
            }
            eliminarObjetosQueNoEstan(2);
        }
        #endregion

        #region Funciones_Generales
        private void crearDataTableObjetos()
        {
            dtObjetosConfirmados = new DataTable();
            dtObjetosConfirmados = new Objetos().Listar(Objetos.Tipo_Objeto.TODOS);

            DataColumn dcEsta = new DataColumn();
            dcEsta.ColumnName = "esta";
            dcEsta.DataType = typeof(bool);
            dcEsta.DefaultValue = false;

            dtObjetosConfirmados.Columns.Add(dcEsta);
        }

        private void confirmarObjetoQueEsta(int idObj)
        {
            foreach (DataRow row in dtObjetosConfirmados.Rows)
            {
                if (Convert.ToInt32(row["Id"]) == idObj)
                    row["esta"] = true;
            }
        }

        private void eliminarObjetosQueNoEstan(int tipo)
        {
            Objetos obj = new Objetos();
            foreach (DataRow row in dtObjetosConfirmados.Rows)
            {
                if (!Convert.ToBoolean(row["esta"]) && Convert.ToInt32(row["Tipo"]) == tipo)
                    obj.EliminarObjeto(Convert.ToInt32(row["Id"]));
            }
        }
        #endregion
    }
}
