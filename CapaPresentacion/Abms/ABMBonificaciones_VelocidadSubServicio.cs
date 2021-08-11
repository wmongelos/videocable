using System;
using System.Data;
using System.Windows.Forms;

namespace CapaPresentacion.Abms
{
    public partial class ABMBonificaciones_VelocidadSubServicio : Form
    {
        public int IdVelocidad = 0;
        public int IdVelocidadTipo = 0;
        private string SubServicio;
        private DataGridViewRow dr;
        private DataTable DtSeleccionVelocidades = new DataTable();
        public ABMBonificaciones_VelocidadSubServicio(DataTable DtVelocidades, String NombreSubServicio)
        {
            DtSeleccionVelocidades = DtVelocidades;
            SubServicio = NombreSubServicio;
            InitializeComponent();
        }

        private void frmVelocidadSubServicio_Load(object sender, EventArgs e)
        {
            dr = null;
            dgvDatos.DataSource = DtSeleccionVelocidades;
            for (int x = 0; x < dgvDatos.Columns.Count; x++)
                dgvDatos.Columns[x].Visible = false;
            dgvDatos.Columns["velocidad"].Visible = true;
            dgvDatos.Columns["velocidad_tipo"].Visible = true;
            dgvDatos.Columns["velocidad"].HeaderText = "Velocidad";
            dgvDatos.Columns["velocidad_tipo"].HeaderText = "Tipo";
            lblSubServicio.Text = String.Format("Sub servicio: {0}", SubServicio);
            lblTotal.Text = String.Format("Total de Registros: {0}", dgvDatos.Rows.Count);
        }

        private void btnAsignar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count > 0)
                dr = dgvDatos.SelectedRows[0];
            else
                dr = dgvDatos.Rows[0];
            IdVelocidad = Convert.ToInt32(dr.Cells["id_velocidad"].Value);
            IdVelocidadTipo = Convert.ToInt32(dr.Cells["id_velocidad_tipo"].Value);
            this.DialogResult = DialogResult.OK;
        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            if (dr == null)
                MessageBox.Show("Debe seleccionar una velocidad.");
            else
                this.DialogResult = DialogResult.OK;
        }
    }
}
