using CapaNegocios;
using System;
using System.Data;
using System.Windows.Forms;

namespace CapaPresentacion.Abms
{
    public partial class frmCambioEstadoEquipos : Form
    {
        DataTable dtEquiposEstados;
        Equipos_Estados oEquiposEstados = new Equipos_Estados();
        public int idEstadoDevuelto = 0;

        public frmCambioEstadoEquipos()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmCambioEstadoEquipos_Load(object sender, EventArgs e)
        {
            try
            {
                dtEquiposEstados = oEquiposEstados.Listar();

                cboEquiposEstados.DataSource = dtEquiposEstados;
                cboEquiposEstados.DisplayMember = "nombre";
                cboEquiposEstados.ValueMember = "id";
            }
            catch
            {
                MessageBox.Show("Error al traer información.");
            }
        }

        private void btnAsignar_Click(object sender, EventArgs e)
        {
            idEstadoDevuelto = Convert.ToInt32(cboEquiposEstados.SelectedValue);
            this.DialogResult = DialogResult.OK;
        }
    }
}
