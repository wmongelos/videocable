using CapaNegocios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class frmPermisos : Form
    {
        #region [PROPIEDADES]
        private List<int> idsObjetos = new List<int>();
        private Objetos oObjetos = new Objetos();
        private Thread hilo;
        private delegate void myDel();
        private bool rolCargado;
        private DataTable dtRolesPermisos;
        #endregion

        public Int32 IdRol;

        public frmPermisos()
        {
            InitializeComponent();
        }

        private void frmPermisos_Load(object sender, EventArgs e)
        {
            comenzarCarga();
        }

        private void comenzarCarga()
        {
            pgCircular.Start();

            hilo = new Thread(new ThreadStart(cargarDatos));
            hilo.Start();
        }

        private void cargarDatos()
        {
            try
            {
                myDel MD = new myDel(cargarValores);
                this.Invoke(MD, new object[] { });
                pgCircular.Stop();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar Informacion" + ex.Message);
            }
        }

        private void cargarValores()
        {
            dtRolesPermisos = Tablas.DataRolesPermisos;
            this.rolCargado = dtRolesPermisos.AsEnumerable().Where(c => c.Field<int>("Id_Rol").Equals(this.IdRol)).Count() > 0;

            if (rolCargado)
            {
                lblInfo.Text = "Cambio de permisos";
                dtRolesPermisos = dtRolesPermisos.Select("Id_Rol = " + this.IdRol).CopyToDataTable();
            }
            else
                lblInfo.Text = "Asignacíon de permisos";

            asignarValoresMenu();
            asginarValorePanelBotonesInferior();
            asginarValoresAcciones();
        }

        private void asignarValoresMenu()
        {
            DataTable dt_objetos = oObjetos.Listar(Objetos.Tipo_Objeto.MENU);
            Stack<int> ultimaReferencia = new Stack<int>();
            ultimaReferencia.Push(0);

            if (dt_objetos.Rows.Count > 0)
            {
                foreach (DataRow row in dt_objetos.Rows)
                {
                    TreeNode tn = new TreeNode();
                    if (Convert.ToInt32(row["Referencia"]) == 0)
                        tn.Text = row["Tag"] + " - " + row["Text"].ToString();
                    else
                        tn.Text = row["Text"].ToString();

                    tn.Name = row["Id"].ToString();
                    if (Convert.ToInt32(row["Referencia"]) == ultimaReferencia.First())
                    {
                        if (Convert.ToInt32(row["Referencia"]) == 0)
                            treeView1.Nodes.Add(tn);
                        else
                            GetUltimoNodo(treeView1.Nodes[treeView1.Nodes.Count - 1]).Parent.Nodes.Add(tn);
                    }
                    else if (Convert.ToInt32(row["Referencia"]) > ultimaReferencia.First())
                    {
                        ultimaReferencia.Push(Convert.ToInt32(row["Referencia"]));
                        GetUltimoNodo(treeView1.Nodes[treeView1.Nodes.Count - 1]).Nodes.Add(tn);
                    }
                    else
                    {
                        TreeNode tnAux = GetUltimoNodo(treeView1.Nodes[treeView1.Nodes.Count - 1]).Parent;
                        while (Convert.ToInt32(row["Referencia"]) < ultimaReferencia.First())
                        {
                            ultimaReferencia.Pop();
                            tnAux = tnAux.Parent;
                        }
                        if (tnAux != null)
                            tnAux.Nodes.Add(tn);
                        else
                            treeView1.Nodes.Add(tn);
                    }
                    if (rolCargado && dtRolesPermisos.AsEnumerable().Where(c => c.Field<int>("Id_Objeto").Equals(Convert.ToInt32(tn.Name))).Count() == 0)
                    {
                        tn.Checked = false;
                        continue;
                    }
                    tn.Checked = true;
                }
                treeView1.ExpandAll();
            }
            else
                MessageBox.Show("No hay objetos del menu cargados", "Mensaje del sistema");

        }

        private void asginarValorePanelBotonesInferior()
        {
            DataTable dt_objetos = oObjetos.Listar(Objetos.Tipo_Objeto.BTN_PANEL_INFERIOR);

            if (dt_objetos.Rows.Count > 0)
            {
                foreach (DataRow row in dt_objetos.Rows)
                {
                    TreeNode tn = new TreeNode();
                    tn.Text = (row["Text"].ToString().Equals(string.Empty)
                        ? "(icono)" + row["Name"].ToString() : row["Text"].ToString());
                    tn.Name = row["Id"].ToString();
                    treeViewBotonesInf.Nodes.Add(tn);
                    if (rolCargado && dtRolesPermisos.AsEnumerable().Where(c => c.Field<int>("Id_Objeto").Equals(Convert.ToInt32(tn.Name))).Count() == 0)
                    {
                        tn.Checked = false;
                        continue;
                    }
                    tn.Checked = true;
                }
            }
            else
                MessageBox.Show("No hay objetos del panel inferior cargados", "Mensaje del sistema");
        }


        private void asginarValoresAcciones()
        {
            DataTable dt_objetos = oObjetos.Listar(Objetos.Tipo_Objeto.ACCION);

            if (dt_objetos.Rows.Count > 0)
            {
                foreach (DataRow row in dt_objetos.Rows)
                {
                    TreeNode tn = new TreeNode();
                    tn.Text = row["Text"].ToString();
                    tn.Name = row["Id"].ToString();
                    treeViewAcciones.Nodes.Add(tn);
                    if (rolCargado && dtRolesPermisos.AsEnumerable().Where(c => c.Field<int>("Id_Objeto").Equals(Convert.ToInt32(tn.Name))).Count() == 0)
                    {
                        tn.Checked = false;
                        continue;
                    }
                    tn.Checked = true;
                }
            }
            else
                MessageBox.Show("No hay acciones cargadas", "Mensaje del sistema");
        }

        private TreeNode GetUltimoNodo(TreeNode node)
        {
            if (node.LastNode != null)
                return GetUltimoNodo(node.Nodes[node.Nodes.Count - 1]);
            else
                return node;
        }

        private void GuardarPermisos()
        {
            if (this.IdRol > 0)
            {
                this.Cursor = Cursors.WaitCursor;
                Roles_Permisos oRP = new Roles_Permisos();
                List<int> objViejos = new List<int>();
                foreach (DataRow row in oRP.Listar(this.IdRol).Rows)
                    objViejos.Add(Convert.ToInt32(row["Id_objeto"]));

                foreach (int obj in idsObjetos)
                    if (objViejos.IndexOf(obj) != -1)
                        objViejos.Remove(obj);

                oRP.Borrar(this.IdRol, objViejos);
                idsObjetos.Sort();
                oRP.Guardar(this.IdRol, idsObjetos);
                if (MessageBox.Show("Los permisos se guardaron correctamente!\nEs necesario reiniciar el sistema para aplicar cambios\n¿Reiniciar sistema ahora?", "Mensaje del sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    Application.Restart();
                    Environment.Exit(0);
                }
                this.Cursor = Cursors.Default;
                this.Close();
            }

        }

        private void ModificarIdsObjetosSeleccionados(TreeNode node)
        {
            if (node.Nodes.Count > 0)
            {
                for (int i = 0; i < node.Nodes.Count; i++)
                {
                    if (node.Checked)
                        idsObjetos.Add(Convert.ToInt32(node.Name));
                    else
                        idsObjetos.Remove(Convert.ToInt32(node.Name));

                    node.Nodes[i].Checked = node.Checked;
                }
            }
            else
            {
                if (node.Checked)
                    idsObjetos.Add(Convert.ToInt32(node.Name));
                else
                    idsObjetos.Remove(Convert.ToInt32(node.Name));
            }
        }

        private void CambiarEstadoTreeView(bool estadoCheckBox)
        {
            TreeView tree;
            if (tabControl1.SelectedTab.Name == "tpMenu")
                tree = treeView1;
            else if (tabControl1.SelectedTab.Name == "tpBtnPanelInf")
                tree = treeViewBotonesInf;
            else
                throw new Exception("TabPage no definida");

            foreach (TreeNode node in tree.Nodes)
            {
                node.Checked = estadoCheckBox;
                ModificarIdsObjetosSeleccionados(node);
            }
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            CambiarEstadoTreeView(true);
        }

        private void btnDeseleccionar_Click(object sender, EventArgs e)
        {
            CambiarEstadoTreeView(false);
        }

        private void treeView_AfterCheck(object sender, TreeViewEventArgs e)
        {
            ModificarIdsObjetosSeleccionados(e.Node);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            GuardarPermisos();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmPermisos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
