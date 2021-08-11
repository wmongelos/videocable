using CapaNegocios;
using System;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class frmUsuariosTipo : Form
    {
        public Int32 idTipo;


        public frmUsuariosTipo()
        {
            InitializeComponent();
        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmUsuariosTipo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        public void ComenzarCarga()
        {
            dgvPresentacion.DataSource = UsuariosTipos.dtUsuariosTipos;
            foreach (DataGridViewColumn item in dgvPresentacion.Columns)
                item.Visible = false;
            dgvPresentacion.Columns["Tipo"].Visible = true;
            foreach (DataGridViewRow item in dgvPresentacion.Rows)
                item.Height = 40;

        }

        private void frmUsuariosTipo_Load(object sender, EventArgs e)
        {
            ComenzarCarga();
        }

        private void dgvPresentacion_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            idTipo = Convert.ToInt32(dgvPresentacion.SelectedRows[0].Cells["id"].Value);
            this.DialogResult = DialogResult.OK;
        }

        private void dgvPresentacion_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                idTipo = Convert.ToInt32(dgvPresentacion.SelectedRows[0].Cells["id"].Value);
            }
            catch { }
        }
    }
}
