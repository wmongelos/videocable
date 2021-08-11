using CapaNegocios;
using System;
using System.Data;
using System.Threading;
using System.Windows.Forms;


namespace CapaPresentacion.Abms
{
    public partial class ABMTecnologias_Tipos : Form
    {
        #region PROPIEDADES
        private Thread hilo;
        private delegate void myDel();
        private DataTable dt;
        Tecnologias_Tipos oTecno = new Tecnologias_Tipos();
        #endregion

        #region METODOS
        public ABMTecnologias_Tipos()
        {
            InitializeComponent();
        }

        private void comenzarCarga()
        {
            dgvTecnologias.DataSource = null;

            hilo = new Thread(new ThreadStart(cargarDatos));
            hilo.Start();
        }

        private void cargarDatos()
        {
            try
            {
                dt = oTecno.Listar();
                myDel MD = new myDel(asignarDatos);
                this.Invoke(MD, new object[] { });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar Informacion" + ex.Message);
            }

        }

        private void asignarDatos()
        {
            dgvTecnologias.DataSource = dt;

            for (int i = 0; i < dgvTecnologias.ColumnCount; i++)
                dgvTecnologias.Columns[i].Visible = false;

            dgvTecnologias.Columns["tecnologia"].Visible = true;
            dgvTecnologias.Columns["tecnologia"].HeaderText = "Tecnologias";

            if (dgvTecnologias.Rows.Count == 0)
            {
                btnEliminar.Enabled = false;
                btnEditar.Enabled = false;
            }
            else
            {
                btnEliminar.Enabled = true;
                btnEditar.Enabled = true;
            }
        }

        private void guardarRegistro()
        {
            oTecno.Descripcion = txtTecnologia.Text;
            oTecno.Guardar(oTecno);
        }

        private void HabilitarControles()
        {
            txtTecnologia.Enabled = true;
            btnCancelar.Enabled = true;
            btnGuardar.Enabled = true;
        }

        private void DeshabilitarControles()
        {
            btnGuardar.Enabled = false;
            btnCancelar.Enabled = false;
            txtTecnologia.Enabled = false;
            txtTecnologia.Text = "";
        }

        private void eliminarRegistro()
        {
            if (dgvTecnologias.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("¿Desea Eliminar el Articulo Seleccionado?", "Mensaje del Sistema",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    oTecno.Eliminar(Convert.ToInt32(dgvTecnologias.SelectedRows[0].Cells["Id"].Value.ToString()));
                    cargarDatos();
                }
            }
            else
                MessageBox.Show("Debe Seleccionar un Registro");
        }

        private void editarRegistro()
        {
            txtTecnologia.Enabled = true;
            int id_tecno = Convert.ToInt32(dgvTecnologias.SelectedRows[0].Cells["id"].Value);
            string Descripcion = Convert.ToString(dgvTecnologias.SelectedRows[0].Cells["descripcion"].Value.ToString());
            if (id_tecno != 0)
            {
                oTecno.Id = Convert.ToInt32(id_tecno);
                txtTecnologia.Text = Descripcion;
            }

        }
        #endregion

        private void ABMTecnologias_Tipos_Load(object sender, EventArgs e)
        {
            comenzarCarga();
            DeshabilitarControles();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            guardarRegistro();
            DeshabilitarControles();
            comenzarCarga();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            HabilitarControles();
            txtTecnologia.Text = "";
            txtTecnologia.Focus();
        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ABMTecnologias_Tipos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DeshabilitarControles();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            eliminarRegistro();
            comenzarCarga();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            HabilitarControles();
            editarRegistro();
            comenzarCarga();
        }
    }
}
