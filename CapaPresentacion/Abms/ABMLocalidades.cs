using CapaNegocios;
using System;
using System.Data;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace CapaPresentacion.Abms
{
    public partial class ABMLocalidades : Form
    {
        #region [PROPIEDADES]
        private Thread hilo;
        private delegate void myDel();
        private DataTable dt;
        private DataTable dtProvincias;
        private DataTable dtFiltroId;
        private Localidades oLoc = new Localidades();
        private Provincias oPro = new Provincias();
        private int Id;
        #endregion

        public ABMLocalidades()
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
                dtProvincias = oPro.Listar();
                if (dtProvincias.Rows.Count > 0)
                    dt = oLoc.Listar();
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

            if (dtProvincias.Rows.Count > 0)
            {
                dgv.Columns["Id"].Visible = false;
                dgv.Columns["Nombre"].HeaderText = "Localidad";
                dgv.Columns["Abreviatura"].HeaderText = "Abreviatura";
                dgv.Columns["Codigo_Postal"].HeaderText = "Código Postal";
                dgv.Columns["Borrado"].Visible = false;
                dgv.Columns["Id_Provincias"].Visible = false;
                cboProvincias.DataSource = dtProvincias;
                cboProvincias.ValueMember = "Id";
                cboProvincias.DisplayMember = "Nombre";
                lblTotal.Text = String.Format("Total de Registros: {0}", dt.Rows.Count);
                controles(false);
                asignarValores();
            }
            else
            {
                MessageBox.Show("Debe cargar provincias para poder comenzar a cargar localidades.");
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
            btnEditar.Enabled = dt.Rows.Count == 0 ? false : !state;
            btnEliminar.Enabled = dt.Rows.Count == 0 ? false : !state;
            dgv.Enabled = !state;
            txtNombre.Enabled = state;
            cboProvincias.Enabled = state;
            txtAbreviatura.Enabled = state;
            txtCP.Enabled = state;
            btnGuardar.Enabled = state;
            btnCancelar.Enabled = state;

        }

        private void limpiarValores()
        {
            Id = 0;
            txtNombre.Text = "";
            txtCP.Text = "";
            txtAbreviatura.Text = "";
        }

        private void asignarValores()
        {
            try
            {
                Id = Convert.ToInt32(dgv.SelectedRows[0].Cells["Id"].Value);
                txtNombre.Text = dgv.SelectedRows[0].Cells["Nombre"].Value.ToString();
                txtNombre.Tag = dgv.SelectedRows[0].Cells["Nombre"].Value.ToString();
                txtAbreviatura.Text = dgv.SelectedRows[0].Cells["Abreviatura"].Value.ToString();
                txtAbreviatura.Tag = dgv.SelectedRows[0].Cells["Abreviatura"].Value.ToString();
                txtCP.Text = dgv.SelectedRows[0].Cells["Codigo_Postal"].Value.ToString();
                txtCP.Tag = dgv.SelectedRows[0].Cells["Codigo_Postal"].Value.ToString();
                cboProvincias.SelectedValue = Convert.ToInt32(dgv.SelectedRows[0].Cells["Id_Provincias"].Value);
            }
            catch { }
        }

        private void nuevoRegistro()
        {
            Id = 0;
            txtNombre.Text = "";
            txtAbreviatura.Text = "";
            txtCP.Text = "";
            cboProvincias.Enabled = true;
            txtNombre.Enabled = true;
            txtNombre.Focus();
        }

        private void editarRegistro()
        {
            txtNombre.Enabled = true;
            txtAbreviatura.Enabled = true;
            txtCP.Enabled = true;
            cboProvincias.Enabled = true;
            txtNombre.Focus();
        }

        private void eliminarRegistro()
        {
            int Id_Localidad = Convert.ToInt32(dgv.SelectedRows[0].Cells["id"].Value);
            dtFiltroId = oLoc.ListarLocalidad_Zona(Id_Localidad);

            if (dtFiltroId.Rows.Count == 0)
            {
                if (MessageBox.Show("¿Desea eliminar el Registro Seleccionado?", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    oLoc.Eliminar(Id);
                    comenzarCarga();
                }
            }
            else
            {
                MessageBox.Show("No se puede eliminar la provincia ya que pertenece a una Zona.");
            }


        }

        private void guardarRegistro()
        {
            if (txtNombre.Text.Trim().Length == 0 || txtAbreviatura.Text.Trim().Length == 0 || txtCP.Text.Trim().Length == 0)
            {
                if (txtNombre.Text.Trim().Length == 0)
                    txtNombre.Focus();
                else if (txtAbreviatura.Text.Trim().Length == 0)
                    txtAbreviatura.Focus();
                else
                    txtCP.Focus();
            }
            else
            {
                if (validarDatos())
                {
                    oLoc.Id = Id;
                    oLoc.Nombre = txtNombre.Text.ToUpper();
                    oLoc.Abreviatura = txtAbreviatura.Text.ToUpper();
                    oLoc.Codigo_Postal = txtCP.Text.ToUpper();
                    oLoc.Id_Provincias = Convert.ToInt32(cboProvincias.SelectedValue);
                    oLoc.Guardar(oLoc);
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
            if (txtNombre.Text.Trim().Length > 0 && txtNombre.Text != txtNombre.Tag.ToString())
            {
                DataRow[] dr = dt.Select(String.Format("Nombre = '{0}'", txtNombre.Text.ToUpper()));
                if (dr.Count() > 0)
                {
                    MessageBox.Show("El Valor ingresado ya Existe", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtNombre.Focus();
                    return false;
                }
            }

            if (txtAbreviatura.Text.Length > 0 && txtAbreviatura.Text != txtAbreviatura.Tag.ToString())
            {
                DataRow[] dr = dt.Select(String.Format("Abreviatura = '{0}'", txtAbreviatura.Text.ToUpper()));

                if (dr.Count() > 0)
                {
                    MessageBox.Show("El Valor ingresado ya Existe", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtAbreviatura.Focus();
                    return false;
                }
            }

            if (String.IsNullOrEmpty(cboProvincias.Text))
            {
                MessageBox.Show("No se ha seleccionado una provincia.", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboProvincias.Focus();
                return false;
            }
            return true;
        }
        #endregion

        private void ABMLocalidades_Load(object sender, EventArgs e)
        {
            comenzarCarga();
        }

        private void ABMLocalidades_KeyDown(object sender, KeyEventArgs e)
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
