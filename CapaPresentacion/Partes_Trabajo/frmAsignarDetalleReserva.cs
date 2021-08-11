using System;
using System.Windows.Forms;

namespace CapaPresentacion.Partes_Trabajo
{
    public partial class frmAsignarDetalleReserva : Form
    {
        public string detalle;
        public frmAsignarDetalleReserva()
        {
            InitializeComponent();
        }

        private void btnAsignar_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtDetalle.Text))
            {
                DialogResult dialogResult = MessageBox.Show("¿Desea retornar un detalle vacío?", "", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    detalle = txtDetalle.Text;
                    this.DialogResult = DialogResult.OK;
                }

            }
            else
            {
                detalle = txtDetalle.Text;
                this.DialogResult = DialogResult.OK;
            }

        }

        private void frmAsignarDetalleReserva_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
    }
}
