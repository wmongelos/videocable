using System;
using System.Windows.Forms;

namespace CapaPresentacion.Abms
{
    public partial class ABMBonificaciones_CantidadCondiciones : Form
    {
        public int Cantidad;
        public ABMBonificaciones_CantidadCondiciones()
        {
            InitializeComponent();
        }

        private void btnAsignar_Click(object sender, EventArgs e)
        {
            Cantidad = Convert.ToInt32(spCantidad.Value);
            this.DialogResult = DialogResult.OK;
        }
    }
}
