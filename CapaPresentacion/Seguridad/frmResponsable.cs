using CapaNegocios;
using System;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class frmResponsable : Form
    {
        public frmResponsable()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void txtClave_Enter(object sender, EventArgs e)
        {
            btnIngresar.Enabled = false;
        }

        private void txtClave_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (txtClave.Text == "")
                    return;
                else
                    validarclave();
            }
        }

        private void validarclave()
        {
            Configuracion oConfig = new Configuracion();

            if (txtClave.Text == oConfig.GetValor_C("ClaveResp"))
                btnIngresar.Enabled = true;
        }
    }
}
