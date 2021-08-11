using CapaNegocios;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
namespace CapaPresentacion.Abms
{
    public partial class ABMPersonal_Roles : Form
    {
        #region [PROPIEDADES]
        private DataTable dt;
        private Personal_Roles oRoles = new Personal_Roles();
        private int Id;
        #endregion

        public ABMPersonal_Roles()
        {
            InitializeComponent();
        }

        #region [METODOS]

        private void comenzarCarga()
        {
            dt = oRoles.Listar();
            foreach (DataRow row in dt.Rows)
                if (Convert.ToInt32(row["id"]) == 1)
                    row.Delete();
            dgv.DataSource = dt;
            dgv.Columns["Id"].Visible = false;
            dgv.Columns["Nombre"].HeaderText = "Rol";
            controles(false);

        }

        private void DesabilitarControles()
        {
            btnActualizar.Enabled = false;
            btnNuevo.Enabled = false;
            btnEliminar.Enabled = false;
            btnEditar.Enabled = false;
            btnGuardar.Enabled = false;
            btnCancelar.Enabled = false;
        }

        private void controles(bool state)
        {
            btnActualizar.Enabled = !state;
            btnNuevo.Enabled = !state;
            btnEditar.Enabled = dt.Rows.Count == 0 ? false : !state;
            btnEliminar.Enabled = dt.Rows.Count == 0 ? false : !state;
            dgv.Enabled = !state;
            txtNombre.Enabled = state;
            btnGuardar.Enabled = state;
            btnCancelar.Enabled = state;
        }

        private void limpiarValores()
        {
            Id = 0;
            txtNombre.Text = "";
        }

        private void asignarValores()
        {
            try
            {
                Id = Convert.ToInt32(dgv.SelectedRows[0].Cells["Id"].Value);
                txtNombre.Text = dgv.SelectedRows[0].Cells["Nombre"].Value.ToString();
                txtNombre.Tag = dgv.SelectedRows[0].Cells["Nombre"].Value.ToString();
            }
            catch { }
        }

        private void nuevoRegistro()
        {
            Id = 0;
            txtNombre.Text = "";
            txtNombre.Enabled = true;
            txtNombre.Focus();
        }

        private void editarRegistro()
        {
            txtNombre.Enabled = true;
            txtNombre.Focus();
        }
        private Boolean ValidarDatos()
        {
            if (txtNombre.Text.Trim().Length == 0)
            {
                MessageBox.Show("Ingrese el nombre del Rol", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtNombre.Focus();
                return false;
            }
            else
            {
                DataRow[] dr = null;
                dr = dt.Select(string.Format("nombre='{0}'", txtNombre.Text.ToString().ToUpper()));
                if (dr.Length == 0)
                    return true;
                else
                {
                    MessageBox.Show("Ya quexiste un Rol con el nombre '" + txtNombre.Text.ToString().ToUpper() + "'", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtNombre.Focus();
                    return false;
                }
            }
        }

        private void eliminarRegistro()
        {
            if (MessageBox.Show("¿Desea eliminar el Registro Seleccionado?", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Personal oPersonal = new Personal();
                DataTable dtPersonal = oPersonal.Listar();
                int idRolSeleccionado = Convert.ToInt32(dgv.SelectedRows[0].Cells["Id"].Value);
                bool rolEnUso = dtPersonal.AsEnumerable().Where(c => c.Field<int>("Id_Roles").Equals(idRolSeleccionado)).Count() > 0;

                if (rolEnUso)
                {
                    if (MessageBox.Show("Hay personal asignado con este Rol\n¿Desea continuar de todos modos?", "Mensaje del sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                        return;
                    else
                        oPersonal.ActualizarRol(idRolSeleccionado, 0);
                }

                oRoles.Eliminar(Id);
                comenzarCarga();
            }
        }

        private void guardarRegistro()
        {

            if (ValidarDatos())
            {
                oRoles.Id = Id;
                oRoles.Nombre = txtNombre.Text.ToUpper();
                oRoles.Guardar(oRoles);
                comenzarCarga();
                btnPermisos.Focus();
            }

        }

        private void cancelarEdicion()
        {
            controles(false);
        }
        #endregion

        private void ABMPersonalRoles_Load(object sender, EventArgs e)
        {
            comenzarCarga();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            controles(true);
            limpiarValores();
            nuevoRegistro();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            controles(false);
            comenzarCarga();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            controles(true);
            editarRegistro();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            eliminarRegistro();
            comenzarCarga();

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            guardarRegistro();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            cancelarEdicion();
        }

        private void dgv_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            asignarValores();
        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPermisos_Click(object sender, EventArgs e)
        {
            using (frmPopUp frm = new frmPopUp())
            {
                frmPermisos frmP = new frmPermisos();
                frmP.IdRol = Convert.ToInt32(dgv.SelectedRows[0].Cells["Id"].Value);
                frm.Formulario = frmP;
                frm.Maximizar = false;

                frm.ShowDialog();
            }
        }

        private void ABMPersonal_Roles_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void dgv_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count > 0)
            {
                btnPermisos.Enabled = true;
                btnEditar.Enabled = true;
                btnEliminar.Enabled = true;
            }
            else
            {
                btnPermisos.Enabled = false;
                btnEditar.Enabled = false;
                btnEliminar.Enabled = false;

            }
        }
    }
}
