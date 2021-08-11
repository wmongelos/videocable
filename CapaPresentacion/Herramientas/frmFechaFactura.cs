using CapaNegocios;
using System;
using System.Windows.Forms;

namespace CapaPresentacion.Herramientas
{
    public partial class frmFechaFactura : Form
    {
        public Int32 Id_Usuarios_Servicios;
        public DateTime Fecha_Factura;
        public String Servicio;

        public frmFechaFactura()
        {
            InitializeComponent();
        }

        private void frmFechaFactura_Load(object sender, EventArgs e)
        {
            this.dtpFecha_Factura.Value = Fecha_Factura;
        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void frmFechaFactura_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.DialogResult = DialogResult.Cancel;
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea confirmar el cambio de Fecha?", "Mensaje del Sistema",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Usuarios_Servicios oUsuServicios = new Usuarios_Servicios();
                oUsuServicios.ActualizarFechaFactura(this.Id_Usuarios_Servicios, dtpFecha_Factura.Value);
                this.DialogResult = DialogResult.OK;
            }
        }
    }
}
