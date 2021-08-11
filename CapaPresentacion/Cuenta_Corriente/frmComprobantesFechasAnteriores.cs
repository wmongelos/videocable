using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CapaPresentacion.Cuenta_Corriente
{
    public partial class frmComprobantesFechasAnteriores : Form
    {
        public DataTable dtServicios;
        public frmComprobantesFechasAnteriores()
        {
            InitializeComponent();
        }

        private void frmComprobantesFechasAnteriores_Load(object sender, EventArgs e)
        {
            dgvServicios.DataSource = dtServicios;
        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;

        }

        private void boton1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;

        }
    }
}
