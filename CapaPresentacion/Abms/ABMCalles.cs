using CapaNegocios;
using System;
using System.Data;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace CapaPresentacion.Abms
{
    public partial class ABMCalles : Form
    {
        private Thread hilo;
        private delegate void myDel();
        private DataTable dt;
        private DataTable dtLocalidades;
        private Localidades_Calles oCalle = new Localidades_Calles();
        private Localidades oLoc = new Localidades();
        public string Consulta { get; set; }
        public string Campo { get; set; }
        private int Id;
        private void comenzarCarga()
        {
            pgCircular.Start();

            dgv.DataSource = null;

            hilo = new Thread(new ThreadStart(cargarDatos));
            hilo.IsBackground = true;
            hilo.Start();
        }

        private void cargarDatos()
        {
            try
            {
                dtLocalidades = oLoc.Listar();

                if (dtLocalidades.Rows.Count > 0)
                {
                    DataView dtvLocs = dtLocalidades.DefaultView;
                    dtvLocs.Sort = "nombre ASC";
                    dtLocalidades = dtvLocs.ToTable();

                    dt = oCalle.Listar();
                    if (dt.Rows.Count > 0)
                    {
                        DataView dtvCalles = dt.DefaultView;
                        dtvCalles.Sort = "id_localidades ASC";
                        dt = dtvCalles.ToTable();
                    }
                }

                myDel MD = new myDel(asignarDatos);

                this.Invoke(MD, new object[] { });

                pgCircular.Stop();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar Información" + ex.Message);
            }
        }

        private void asignarDatos()
        {
            if (dtLocalidades.Rows.Count > 0)
            {
                dgv.DataSource = dt;

                dgv.Columns["Id"].HeaderText = "Código";
                dgv.Columns["Id"].Visible = false;
                dgv.Columns["Id"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgv.Columns["Nombre"].HeaderText = "Calle";

                dgv.Columns["Altura_Desde"].HeaderText = "Desde";
                dgv.Columns["Altura_Hasta"].HeaderText = "Hasta";
                dgv.Columns["Nombre_Localidad"].HeaderText = "Localidad";

                dgv.Columns["Id_Localidades"].Visible = false;

                cboLocalidades.DataSource = dtLocalidades;
                cboLocalidades.ValueMember = "Id";
                cboLocalidades.DisplayMember = "Nombre";

                lblTotal.Text = String.Format("Total de Registros: {0}", dt.Rows.Count);

                controles(false);

                asignarValores();
            }
            else
            {
                MessageBox.Show("Debe cargar localidades antes de ingresar calles.");
                DesabilitarControles();
            }
        }

        private void controles(bool state)
        {
            btnActualizar.Enabled = !state;
            btnNuevo.Enabled = !state;
            btnEditar.Enabled = dt.Rows.Count == 0 ? false : !state;
            btnEliminar.Enabled = dt.Rows.Count == 0 ? false : !state;

            dgv.Enabled = !state;

            txtNombre.Enabled = state;
            cboLocalidades.Enabled = state;

            btnGuardar.Enabled = state;
            spnAlturaDesde.Enabled = state;
            spnAlturaHasta.Enabled = state;

            btnCancelar.Enabled = state;

        }

        private void DesabilitarControles()
        {
            btnActualizar.Enabled = false;
            btnNuevo.Enabled = false;
            btnEliminar.Enabled = false;
            btnEditar.Enabled = false;
            btnGuardar.Enabled = false;
            btnCancelar.Enabled = false;
            txtBuscar.Enabled = false;
        }

        private void limpiarValores()
        {
            Id = 0;
            spnAlturaDesde.Value = spnAlturaDesde.Minimum;
            spnAlturaHasta.Value = spnAlturaHasta.Minimum;
            txtNombre.Text = "";
        }

        private void asignarValores()
        {
            try
            {
                Id = Convert.ToInt32(dgv.SelectedRows[0].Cells["Id"].Value);
                txtNombre.Text = dgv.SelectedRows[0].Cells["Nombre"].Value.ToString();
                txtNombre.Tag = dgv.SelectedRows[0].Cells["Nombre"].Value.ToString();
                spnAlturaDesde.Value = Convert.ToInt32(dgv.SelectedRows[0].Cells["Altura_Desde"].Value);
                spnAlturaHasta.Value = Convert.ToInt32(dgv.SelectedRows[0].Cells["Altura_Hasta"].Value);
                cboLocalidades.SelectedValue = Convert.ToInt32(dgv.SelectedRows[0].Cells["Id_Localidades"].Value);
            }
            catch { }
        }

        private void nuevoRegistro()
        {
            Id = 0;
            txtNombre.Text = "";
            cboLocalidades.Enabled = true;
            txtNombre.Enabled = true;
            spnAlturaDesde.Enabled = true;
            spnAlturaHasta.Enabled = true;
            txtNombre.Focus();
        }

        private void editarRegistro()
        {
            txtNombre.Enabled = true;
            spnAlturaDesde.Enabled = true;
            spnAlturaHasta.Enabled = true;
            cboLocalidades.Enabled = true;
            txtNombre.Focus();
        }

        private void eliminarRegistro()
        {
            if (MessageBox.Show("¿Desea eliminar el Registro Seleccionado?", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                oCalle.Eliminar(Id);

                comenzarCarga();
            }
        }

        private void guardarRegistro()
        {
            if (txtNombre.Text.Trim().Length == 0)
            {
                MessageBox.Show("Ingrese el nombre de la calle.", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtNombre.Focus();
            }
            else
            {
                if ((spnAlturaHasta.Value == 0) || (spnAlturaDesde.Value == 0) || (spnAlturaDesde.Value == spnAlturaHasta.Value))
                    MessageBox.Show("Ingrese una altura valida", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                else
                {
                    if (validarDatos())
                    {
                        oCalle.Id = Id;
                        oCalle.Nombre = txtNombre.Text.ToUpper();
                        oCalle.Id_Localidades = Convert.ToInt32(cboLocalidades.SelectedValue);
                        oCalle.Altura_Desde = Convert.ToInt32(spnAlturaDesde.Value);
                        oCalle.Altura_Hasta = Convert.ToInt32(spnAlturaHasta.Value);
                        oCalle.Guardar(oCalle);
                        comenzarCarga();
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
                DataRow[] dr = dt.Select(String.Format("Nombre = '{0}' and id_localidades='{1}'", txtNombre.Text.ToUpper(), cboLocalidades.SelectedValue));

                if (dr.Count() > 0)
                {
                    MessageBox.Show("El Valor ingresado ya Existe", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    return false;
                }
            }

            return true;
        }

        public ABMCalles()
        {
            InitializeComponent();
        }

        private void ABMCalles_Load(object sender, EventArgs e)
        {
            comenzarCarga();
        }

        private void ABMCalles_KeyDown(object sender, KeyEventArgs e)
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

        private void btnAsignarCalle_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgv_SelectionChanged(object sender, EventArgs e)
        {
            asignarValores();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            dt.DefaultView.RowFilter = String.Format("Nombre LIKE '%{0}%' OR Nombre_Localidad LIKE '%{0}%'", txtBuscar.Text);
        }


    }
}
