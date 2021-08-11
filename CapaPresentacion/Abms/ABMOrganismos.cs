using CapaNegocios;
using System;
using System.Data;
using System.Threading;
using System.Windows.Forms;

namespace CapaPresentacion.Abms
{
    public partial class ABMOrganismos : Form
    {
        #region METODOS!
        private Thread hilo;
        private delegate void myDel();
        Organismos oOrganismos = new Organismos();
        DataTable dt;
        int Id = 0;
        int RowSelect = 0;
        #endregion
        public ABMOrganismos()
        {
            InitializeComponent();
        }

        private void ComenzarCarga()
        {
            hilo = new Thread(new ThreadStart(CargarDatos));
            hilo.Start();
            HabilitarControles();
            btnCancelar.Enabled = false;
            btnGuardar.Enabled = false;
            txtOrganismo.Enabled = false;
        }

        private void CargarDatos()
        {
            try
            {
                dt = oOrganismos.Listar();

                myDel MD = new myDel(AsignarDatos);

                this.Invoke(MD, new object[] { });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar Informacion" + ex.Message);
            }
        }

        private void AsignarDatos()
        {
            dgvOrganismos.DataSource = dt;

            for (int i = 0; i < dgvOrganismos.ColumnCount; i++)
                dgvOrganismos.Columns[i].Visible = false;

            dgvOrganismos.Columns["Descripcion"].Visible = true;
            dgvOrganismos.Columns["Descripcion"].HeaderText = "Descripcion del Organismo";
            txtOrganismo.Enabled = false;
            AsignarValores();
        }

        private void AsignarValores()
        {
            try
            {
                Id = Convert.ToInt32(dgvOrganismos.SelectedRows[0].Cells["Id"].Value);
            }
            catch { }
        }
        private void RegistroNuevO()
        {
            txtOrganismo.Text = "";
            Id = 0;
            btnGuardar.Enabled = true;
            btnCancelar.Enabled = true;
            if (txtOrganismo.Text.Length == 0)
            {
                txtOrganismo.Enabled = true;
                txtOrganismo.Focus();
            }
        }
        private void guardarRegistro()
        {
            if (txtOrganismo.Text.Length == 0)
            {
                MessageBox.Show("Debe insertar algun registro para poder guardarlo.");
            }
            else
            {
                oOrganismos.Id = Convert.ToInt32(Id);
                oOrganismos.Descripcion = txtOrganismo.Text;
                oOrganismos.Guardar(oOrganismos);
                txtOrganismo.Text = "";
                txtOrganismo.Enabled = false;
                btnGuardar.Enabled = false;
                btnCancelar.Enabled = false;
            }
        }
        private void HabilitarControles()
        {
            btnActualizar.Enabled = true;
            btnEditar.Enabled = true;
            btnEliminar.Enabled = true;
            btnNuevo.Enabled = true;
        }
        private void ABMOrganismos_Load(object sender, EventArgs e)
        {
            ComenzarCarga();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            guardarRegistro();
            ComenzarCarga();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            RegistroNuevO();
            btnActualizar.Enabled = false;
            btnEditar.Enabled = false;
            btnEliminar.Enabled = false;
            btnNuevo.Enabled = false;
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            ComenzarCarga();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            RowSelect = dgvOrganismos.SelectedRows[0].Index;
            txtOrganismo.Enabled = true;
            btnGuardar.Enabled = true;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea eliminar el Registro Seleccionado?", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                oOrganismos.Eliminar(Id);
                ComenzarCarga();
            }
        }

        private void dgvOrganismos_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            AsignarValores();
        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            ComenzarCarga();
        }
    }
}
