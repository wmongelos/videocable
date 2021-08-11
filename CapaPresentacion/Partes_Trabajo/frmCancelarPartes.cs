using System;
using System.Windows.Forms;

namespace CapaPresentacion.Partes_Trabajo
{
    public partial class frmCancelarPartes : Form
    {
        public frmCancelarPartes()
        {
            InitializeComponent();
        }

        private void boton1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSi_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;

        }
    }
}
