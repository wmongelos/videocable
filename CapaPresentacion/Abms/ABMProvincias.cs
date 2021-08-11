using CapaNegocios;
using System;
using System.Data;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace CapaPresentacion.Abms
{
    public partial class ABMProvincias : Form
    {
        #region [PROPIEDADES]
        private Thread hilo;
        private delegate void myDel();
        private DataTable dt;
        private Provincias oProv = new Provincias();
        private int Id;
        #endregion

        public ABMProvincias()
        {
            InitializeComponent();
        }

        #region [METODOS]
        private void comenzarCarga()
        {
            pgCircular.Start();
            dgv.DataSource = null;
            hilo = new Thread(new ThreadStart(cargarDatos));
            hilo.Start();
        }

        private void cargarDatos()
        {
            try
            {
                dt = oProv.ListarCantidadLocalidadesPorProvincia();
                myDel MD = new myDel(asignarDatos);
                this.Invoke(MD, new object[] { });
                pgCircular.Stop();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar Informacion" + ex.Message);
            }
        }

        private void asignarDatos()
        {
            dgv.DataSource = dt;
            dgv.Columns["Id"].Visible = false;
            dgv.Columns["TotalLoc"].Visible = false;
            dgv.Columns["Nombre"].HeaderText = "Provincia";
            dgv.Columns["Borrado"].Visible = false;
            lblTotal.Text = String.Format("Total de Registros: {0}", dt.Rows.Count);
            controles(false);
            asignarValores();
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

        private void eliminarRegistro()
        {
            int CantLocaciones = Convert.ToInt32(dgv.SelectedRows[0].Cells["TotalLoc"].Value);

            if (CantLocaciones == 0)
            {
                if (MessageBox.Show("¿Desea eliminar el Registro Seleccionado?", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    oProv.Eliminar(Id);
                    comenzarCarga();
                }
            }
            else
            {
                if (MessageBox.Show("¡PROVINCIA CON LOCACIONES ASIGNADAS!¿Desea eliminar el Registro Seleccionado de cualquier forma? ", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    oProv.EliminaidProvincia(Id);
                    oProv.Eliminar(Id);
                    comenzarCarga();
                }
                else
                {
                    MessageBox.Show("Esta provincia tiene locacion asignada, proceso de eliminacion cancelado.");
                }
            }
        }

        private void guardarRegistro()
        {
            if (txtNombre.Text.Trim().Length == 0)
                txtNombre.Focus();
            else
            {
                if (validarDatos())
                {
                    oProv.Id = Id;
                    oProv.Nombre = txtNombre.Text.ToUpper();
                    oProv.Guardar(oProv);
                    comenzarCarga();
                }
            }
        }

        private void cancelarEdicion()
        {
            controles(false);
        }

        private bool validarDatos()
        {
            if (txtNombre.Text.Length > 0)
            {
                DataRow[] dr = dt.Select(String.Format("Nombre = '{0}' AND Id<>'{1}'", txtNombre.Text.ToUpper(), Id));
                if (dr.Count() > 0)
                {
                    MessageBox.Show("El Valor ingresado ya Existe", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
            }
            return true;
        }
        #endregion

        private void ABMProvincias_Load(object sender, EventArgs e)
        {
            comenzarCarga();
        }

        private void ABMProvincias_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            controles(false);
            comenzarCarga();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            controles(true);
            limpiarValores();
            nuevoRegistro();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            controles(true);
            editarRegistro();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            eliminarRegistro();
            if (dgv.Rows.Count == 0)
                limpiarValores();
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
    }
}
