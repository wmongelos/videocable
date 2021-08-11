using System;
using System.Windows.Forms;

namespace CapaPresentacion.Complementarias
{
    public partial class frmExtras : Form
    {
        public Decimal importe;
        public String detalle;

        public frmExtras()
        {
            InitializeComponent();
        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmExtras_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            importe = spnImporte.Value;
            detalle = txtDetalle.Text;
            if ((importe != 0) && (detalle.Trim() != ""))
                this.DialogResult = DialogResult.OK;
            else
                MessageBox.Show("Llene los campos detalle y monto", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

        }
    }
}
