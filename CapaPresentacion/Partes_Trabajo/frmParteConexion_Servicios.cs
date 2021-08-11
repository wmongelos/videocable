using System;
using System.Data;
using System.Windows.Forms;

namespace CapaPresentacion.Partes_Trabajo
{
    public partial class frmParteConexion_Servicios : Form
    {
        public DataTable DataServicios;
        public Int32 IdServiciosSeleccionado;
        public frmParteConexion_Servicios()
        {
            InitializeComponent();
        }

        private void frmParteConexion_Servicios_Load(object sender, System.EventArgs e)
        {
            DataServicios.DefaultView.RowFilter = "";
            dgv.DataSource = DataServicios;

            for (int i = 0; i < dgv.ColumnCount; i++)
                dgv.Columns[i].Visible = false;
            foreach (DataGridViewRow item in dgv.Rows)
            {
                if (item.Cells["modalidad"].Value.ToString() == "UNICO")
                    item.Visible = false;
                item.Height = 30;
            }
            dgv.Columns["Descripcion"].Visible = true;
            dgv.Columns["Grupo"].Visible = true;

            dgv.ClearSelection();
        }

        private void frmParteConexion_Servicios_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                cancela();

            if (e.KeyCode == Keys.Enter)
                confirma();
        }

        private void txtBuscar_TextChanged(object sender, System.EventArgs e)
        {
            DataServicios.DefaultView.RowFilter = String.Format("Descripcion LIKE '%{0}%' OR Grupo LIKE '%{0}%'", txtBuscar.Text);
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            confirma();
        }
        private void confirma()
        {
            if (dgv.SelectedRows.Count > 0)
            {
                this.IdServiciosSeleccionado = Convert.ToInt32(dgv.SelectedRows[0].Cells["Id_Servicios"].Value);
                this.DialogResult = DialogResult.OK;
            }
        }

        private void cancela()
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnCancela_Click(object sender, EventArgs e)
        {
            cancela();
        }

        private void dgv_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            confirma();
        }
    }
}
