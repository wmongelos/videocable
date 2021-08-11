using System;
using System.Windows.Forms;

namespace CapaPresentacion.General
{
    public partial class frmSeleccionarFecha : Form
    {
        public DateTime FechaSeleccionada { get; private set; }

        public frmSeleccionarFecha(string subtitulo)
        {
            InitializeComponent();
            this.lblSubtitulo.Text = subtitulo;
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            this.FechaSeleccionada = dtpFecha.Value;
            this.DialogResult = DialogResult.OK;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void frmSeleccionarFecha_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
