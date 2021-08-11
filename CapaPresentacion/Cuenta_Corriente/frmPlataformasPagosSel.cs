using System;
using System.Drawing;
using System.Windows.Forms;

namespace CapaPresentacion.Cuenta_Corriente
{
    public partial class frmPlataformasPagosSel : Form
    {
        public int IdPlataformaSeleccionada { get; set; }

        public frmPlataformasPagosSel()
        {
            InitializeComponent();
        }

        private void pcCaptar_Click(object sender, EventArgs e)
        {
            pnlMp.BackColor = this.BackColor;
            pnlCp.BackColor = pnlTituloEmail.BackColor;
            IdPlataformaSeleccionada = (int)CapaNegocios.PagosExternos.PagoExterno.Plataforma.CAPTARPAGOS;
        }

        private void pcMp_Click(object sender, EventArgs e)
        {
            pnlCp.BackColor = this.BackColor;
            pnlMp.BackColor = pnlTituloEmail.BackColor;
            IdPlataformaSeleccionada = (int)CapaNegocios.PagosExternos.PagoExterno.Plataforma.MERCADOPAGO;

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;

        }

        private void pnReturnCorreo_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;

        }

        private void pcMp_Paint(object sender, PaintEventArgs e)
        {

            var pict = sender as PictureBox;
            if (pict != null && (!pict.Enabled))
            {
                using (var img = new Bitmap(pict.Image, pict.ClientSize))
                {
                    ControlPaint.DrawImageDisabled(e.Graphics, img, 0, 0, pict.BackColor);
                }
            }
        }
    }
}
