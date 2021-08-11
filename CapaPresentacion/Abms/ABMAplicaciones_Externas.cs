using CapaNegocios;
using System;
using System.Data;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using CapaPresentacion;

namespace CapaPresentacion
{
    public partial class ABMAplicaciones_Externas : Form
    {
        #region
        private Thread hilo;
        private delegate void myDel();
        private Aplicaciones_Externas oAplicacionesExternas = new Aplicaciones_Externas();
        private DataTable dt_app = new DataTable();
        private frmPopUp oFrmPopUp;
        private frmAplicaciones_Externas_Acciones oFrmAppExternas_Acciones;
        private DataGridViewColumn col = new DataGridViewColumn();
        private DataGridViewLinkColumn collink = new DataGridViewLinkColumn();
        private bool Conectado;
        #endregion

        private void comenzarCarga()
        {
            dgv.DataSource = null;
            hilo = new Thread(new ThreadStart(cargarDatos));
            hilo.Start();
        }
        private void cargarDatos()
        {
            try
            {
                dt_app = oAplicacionesExternas.Listar();
                myDel MD = new myDel(asignarDatos);
                this.Invoke(MD, new object[] { });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar Información" + ex.Message);
            }
        }
        private void asignarDatos()
        {
            dgv.Columns.Clear();
            dgv.DataSource = dt_app;
            if (dt_app.Rows.Count > 0)
            {

                dgv.Columns["id"].HeaderText = "ID";
                dgv.Columns["nombre"].HeaderText = "Nombre";
                dgv.Columns["string_conexion"].HeaderText = "Conexion";
                dgv.Columns["parametros"].HeaderText = "Parametros";
                dgv.Columns["borrado"].Visible = false;
                col = collink;
                col.HeaderText = "Asignar aplicacion";
                col.Name = "colasignar";
                col.Width = 120;
                collink.Text = "Asignar";
                collink.UseColumnTextForLinkValue = true;
                dgv.Columns.Add(col);
                dgv.Columns["colasignar"].DisplayIndex = dgv.Columns.Count - 1;
            }

            if (dgv.Rows.Count > 0)
                dgv.SelectedRows[0].Selected = true;

            btnActualizar.Enabled = true;
            btnNuevo.Enabled = true;
            btnEditar.Enabled = false;
            btnEliminar.Enabled = false;
            btnCancelar.Enabled = false;
            btnGuardar.Enabled = false;
        }

        public ABMAplicaciones_Externas()
        {
            InitializeComponent();
        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnexportar_Click(object sender, EventArgs e)
        {
            if (rbRequiereRelacion.Checked == true)
                oAplicacionesExternas.Requiere_relacion = 1;
            else
                oAplicacionesExternas.Requiere_relacion = 0;
            oAplicacionesExternas.Nombre_App = txtNombreApp.Text.ToString();
            oAplicacionesExternas.StringConexion = txtStringConexion.Text.ToString();
           // oAplicacionesExternas.Parametros = txtParam.Text.ToString();

            if ((oAplicacionesExternas.Nombre_App == "") || (oAplicacionesExternas.StringConexion == ""))
            {
                MessageBox.Show("Completar los campos varios", "Mensaje del Sistema");
            }
            else
            {
                oAplicacionesExternas.Id_App = oAplicacionesExternas.Guardar(oAplicacionesExternas);
                if (MessageBox.Show("Datos guardados correctamente, ¿Desea asignarle un ejecutable?", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    oFrmAppExternas_Acciones = new frmAplicaciones_Externas_Acciones();
                    oFrmPopUp = new frmPopUp();
                    oFrmAppExternas_Acciones.oApExt = oAplicacionesExternas;
                    oFrmPopUp.Formulario = oFrmAppExternas_Acciones;
                    oFrmPopUp.ShowDialog();
                }
                else
                {
                    comenzarCarga();
                }
                btnCancelar.Enabled = false;
                btnEditar.Enabled = false;
                btnEliminar.Enabled = false;
                btnGuardar.Enabled = false;
                btnNuevo.Enabled = true;
            }
        }

        private void ABMAplicaciones_Externas_Load(object sender, EventArgs e)
        {
            comenzarCarga();
        }

        private void ABMAplicaciones_Externas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            oAplicacionesExternas.Id_App = Convert.ToInt32(dgv.Rows[dgv.SelectedRows[0].Index].Cells["id"].Value);
            oAplicacionesExternas.Nombre_App = dgv.Rows[dgv.SelectedRows[0].Index].Cells["nombre"].Value.ToString();
            oAplicacionesExternas.StringConexion = dgv.Rows[dgv.SelectedRows[0].Index].Cells["string_conexion"].Value.ToString();
            oAplicacionesExternas.Parametros = dgv.Rows[dgv.SelectedRows[0].Index].Cells["Parametros"].Value.ToString();

            if (e.ColumnIndex == dgv.Columns["colasignar"].Index)
            {
                oFrmAppExternas_Acciones = new frmAplicaciones_Externas_Acciones();
                oFrmPopUp = new frmPopUp();
                oFrmAppExternas_Acciones.oApExt = oAplicacionesExternas;
                oFrmPopUp.Formulario = oFrmAppExternas_Acciones;
                oFrmPopUp.ShowDialog();
            }
            else
            {
                txtid.Text = oAplicacionesExternas.Id_App.ToString();
                txtNombreApp.Text = oAplicacionesExternas.Nombre_App.ToString();
                txtStringConexion.Text = oAplicacionesExternas.StringConexion.ToString();
                //txtParam.Text = oAplicacionesExternas.Parametros.ToString();
                btnEditar.Enabled = true;
                btnEliminar.Enabled = true;
            }

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            btnCancelar.Enabled = true;
            txtNombreApp.ReadOnly = false;
            txtStringConexion.ReadOnly = false;
            btnGuardar.Enabled = true;
            btnEliminar.Enabled = false;
            txtNombreApp.Focus();

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            btnNuevo.Enabled = true;
            btnEditar.Enabled = false;
            btnEliminar.Enabled = false;
            btnCancelar.Enabled = false;
            btnGuardar.Enabled = false;
            txtNombreApp.Text = "";
            txtStringConexion.Text = "";
            txtNombreApp.ReadOnly = true;
            txtStringConexion.ReadOnly = true;
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            comenzarCarga();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            txtid.Text = "0";
            txtNombreApp.Text = "";
            txtStringConexion.Text = "";
            txtNombreApp.ReadOnly = false;
            txtStringConexion.ReadOnly = false;
            btnGuardar.Enabled = true;
            btnCancelar.Enabled = true;
            btnEliminar.Enabled = false;
            btnEditar.Enabled = false;
            txtNombreApp.Focus();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                oAplicacionesExternas.Eliminar(oAplicacionesExternas);
            }
            catch (Exception)
            {

                throw;
            }
            MessageBox.Show("Aplicacion eliminada correctamente", "Mensaje del sistema");
            comenzarCarga();
        }

        private void btnBuscarApps_Click(object sender, EventArgs e)
        {
            oFrmAppExternas_Acciones = new frmAplicaciones_Externas_Acciones();
            oFrmAppExternas_Acciones.oApExt = new Aplicaciones_Externas();
            oFrmPopUp = new frmPopUp();
            oFrmPopUp.Formulario = oFrmAppExternas_Acciones;
            oFrmPopUp.ShowDialog();
        }

        private void boton1_Click(object sender, EventArgs e)
        {

            Conectado = oAplicacionesExternas.ProbrarConexion(txtStringConexion.Text);
            if (Conectado == true)
            {
                tmrTimer.Stop();
                btnProbar.BackColor = Color.LimeGreen;
                MessageBox.Show("Conexion exitosa", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tmrTimer.Start();
            }
            else
            {
                tmrTimer.Stop();
                btnProbar.BackColor = Color.Firebrick;
                MessageBox.Show("No se pudo establecer la conexion", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tmrTimer.Start();

            }
        }

        private void tmrTimer_Tick(object sender, EventArgs e)
        {
            btnProbar.BackColor = Color.FromArgb(15, 76, 100);
        }

        private void btnParametros_Click(object sender, EventArgs e)
        {
            using (frmPopUp frm = new frmPopUp())
            {
               Abms.ABMAplicaciones_Externas_Parametros frmABM = new Abms.ABMAplicaciones_Externas_Parametros();
                frm.Formulario = frmABM;
                frmABM.Id_App_Externa = Convert.ToInt32(dgv.Rows[dgv.SelectedRows[0].Index].Cells["id"].Value);
                frm.Maximizar = true;
                frmABM.Show();
            }
        }
    }
}
