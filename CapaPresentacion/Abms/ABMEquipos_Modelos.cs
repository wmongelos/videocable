using CapaNegocios;
using System;
using System.Data;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace CapaPresentacion.Abms
{
    public partial class ABMEquipos_Modelos : Form
    {
        private Thread hilo;
        private delegate void myDel();
        private DataTable dt;
        private DataTable dtEqupos_Marcas;
        private Equipos_Modelos oEqu_Model = new Equipos_Modelos();
        private Equipos_Marcas oEquipo_Marca = new Equipos_Marcas();
        private Equipos_Tipos oEquiposTipos = new Equipos_Tipos();
        public bool AgregaExistente = false;
        public string NombreModelo = "";
        public int idMarca = 0;
        public ABMEquipos_Modelos()
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
                dtEqupos_Marcas = oEquipo_Marca.Listar();
                dt = oEqu_Model.Listar();

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

            if (dtEqupos_Marcas.Rows.Count > 0)
            {
                for (int i = 0; i < dgv.ColumnCount; i++)
                    dgv.Columns[i].Visible = false;

                dgv.Columns["Nombre"].Visible = true;
                dgv.Columns["Marca"].Visible = true;
                dgv.Columns["Nombre"].HeaderText = "Modelo";
                dgv.Columns["marca"].HeaderText = "Marca";

                lblTotal.Text = String.Format("Total de Registros: {0}", dt.Rows.Count);

                cboEquipos_Marcas.DataSource = dtEqupos_Marcas;
                cboEquipos_Marcas.DisplayMember = "Nombre";
                cboEquipos_Marcas.ValueMember = "id";

                asignarValores();

                if (AgregaExistente)
                {
                    cboEquipos_Marcas.SelectedValue = idMarca;
                    txtNombre.Text = NombreModelo;
                    controles(true);
                    btnGuardar.Focus();

                }
                else
                    controles(false);

            }
            else
            {
                MessageBox.Show("Debe cargar marcas de equipos antes de ingresar modelos.");
                DesabilitarControles();
            }
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
            btnEditar.Enabled = !state;
            btnEliminar.Enabled = !state;
            cboEquipos_Marcas.Enabled = state;
            dgv.Enabled = !state;
            txtNombre.Enabled = state;

            btnGuardar.Enabled = state;
            btnCancelar.Enabled = state;

        }

        private void limpiarValores()
        {
            txtId.Text = "";
            txtId.Tag = "";
            txtNombre.Text = "";
        }

        private void asignarValores()
        {
            try
            {
                txtId.Text = dgv.SelectedRows[0].Cells["Id"].Value.ToString();
                txtNombre.Text = dgv.SelectedRows[0].Cells["Nombre"].Value.ToString();
                txtNombre.Tag = dgv.SelectedRows[0].Cells["Nombre"].Value.ToString();

                cboEquipos_Marcas.SelectedValue = Convert.ToInt32(dgv.SelectedRows[0].Cells["Id_Equipos_Marcas"].Value);
            }
            catch { }
        }

        private void nuevoRegistro()
        {
            txtId.Text = "0";
            txtNombre.Text = "";
            txtNombre.Tag = "";
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
            if (MessageBox.Show("¿Desea eliminar el Registro Seleccionado?", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                oEqu_Model.Eliminar(Convert.ToInt32(txtId.Text));

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
                    oEqu_Model.Id = Convert.ToInt32(txtId.Text);
                    oEqu_Model.Id_Equipos_Marcas = Convert.ToInt32(cboEquipos_Marcas.SelectedValue);
                    oEqu_Model.Nombre = txtNombre.Text.ToUpper();
                    if (oEqu_Model.Guardar(oEqu_Model))
                    {
                        if(MessageBox.Show("Modelo cargado correctamente", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK){
                            if (AgregaExistente)
                                this.DialogResult = DialogResult.OK;
                            else
                                comenzarCarga();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Hubo un error al intentar guardar el modelo", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

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

        private void ABMEquipos_Modelos_Load(object sender, EventArgs e)
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

        private void ABMEquipos_Modelos_KeyDown(object sender, KeyEventArgs e)
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
