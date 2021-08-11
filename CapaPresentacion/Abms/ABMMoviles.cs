using CapaNegocios;
using System;
using System.Data;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace CapaPresentacion.Abms
{
    public partial class ABMMoviles : Form
    {
        private Thread hilo;
        private delegate void myDel();
        private DataTable dt;
        private Moviles oMoviles = new Moviles();

        public ABMMoviles()
        {
            InitializeComponent();
        }

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
                dt = oMoviles.Listar();

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
            try
            {
                dgv.DataSource = dt;

                dgv.Columns["id"].HeaderText = "Codigo";
                dgv.Columns["id"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgv.Columns["nombre"].HeaderText = "Nombre";
                dgv.Columns["dominio"].HeaderText = "Dominio";
                dgv.Columns["borrado"].Visible = false;

                lblTotal.Text = String.Format("Total de Registros: {0}", dt.Rows.Count);

                controles(false);
                asignarValores();
            }
            catch (Exception)
            {

            }
        }

        private void controles(bool state)
        {
            btnActualizar.Enabled = !state;
            btnNuevo.Enabled = !state;
            btnEditar.Enabled = !state;
            btnEliminar.Enabled = !state;

            dgv.Enabled = !state;

            txtNombre.Enabled = state;
            txtDominio.Enabled = state;
            btnGuardar.Enabled = state;
            btnCancelar.Enabled = state;

        }

        private void limpiarValores()
        {
            txtId.Text = "";
            txtNombre.Text = "";
            txtDominio.Text = "";
        }

        private void asignarValores()
        {
            try
            {
                txtId.Text = dgv.SelectedRows[0].Cells["id"].Value.ToString();
                txtNombre.Text = dgv.SelectedRows[0].Cells["nombre"].Value.ToString();
                txtNombre.Tag = dgv.SelectedRows[0].Cells["nombre"].Value.ToString();
                txtDominio.Text = dgv.SelectedRows[0].Cells["dominio"].Value.ToString();
            }
            catch { }
        }

        private void nuevoRegistro()
        {
            txtId.Text = "0";
            txtNombre.Text = "";
            txtDominio.Text = "";
            txtNombre.Enabled = true;
            txtDominio.Enabled = true;
            txtNombre.Focus();
        }

        private void editarRegistro()
        {
            txtNombre.Enabled = true;
            txtDominio.Enabled = true;
            txtNombre.Focus();
        }

        private void eliminarRegistro()
        {
            if (MessageBox.Show("¿Desea eliminar el Registro Seleccionado?", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                oMoviles.Eliminar(Convert.ToInt32(txtId.Text));

                comenzarCarga();
            }
        }

        private void guardarRegistro()
        {
            if (txtNombre.Text.Length == 0)
                txtNombre.Focus();
            else
            {
                if (validarDatos())
                {
                    oMoviles.Id = Convert.ToInt32(txtId.Text);
                    oMoviles.Nombre = txtNombre.Text.ToUpper();
                    oMoviles.Dominio = txtDominio.Text.ToUpper();
                    oMoviles.Borrado = 0;
                    oMoviles.Guardar(oMoviles);

                    comenzarCarga();
                    controles(false);
                }
            }
        }

        private void cancelarEdicion()
        {
            controles(false);
        }

        private bool validarDatos()
        {
            if (txtNombre.Tag.ToString() != txtNombre.Text && txtNombre.Text.Length > 0)
            {
                DataRow[] dr = dt.Select(String.Format("Nombre = '{0}'", txtNombre.Text.ToUpper()));

                if (dr.Count() > 0)
                {
                    MessageBox.Show("El Valor ingresado ya Existe", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    return false;
                }
            }

            return true;
        }

        private void ABMMoviles_Load(object sender, EventArgs e)
        {
            comenzarCarga();
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

        private void ABMMoviles_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
    }
}
