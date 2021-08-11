using CapaNegocios;
using System;
using System.Data;
using System.Windows.Forms;

namespace CapaPresentacion.Herramientas
{
    public partial class frmCambioServicioVelSel : Form
    {
        public DataTable dataTableVel;

        public Int32 Id_Velocidad_Sel;
        public Int32 Id_Tarifa_Sel;

        public frmCambioServicioVelSel()
        {
            InitializeComponent();
        }

        private void CargarTarifa()
        {
            Servicios_Tarifas oTarifa = new Servicios_Tarifas();
            DataTable dtTarifas = oTarifa.Listar();
            cboTarifas.DataSource = dtTarifas;
            cboTarifas.DisplayMember = "Nombre";
            cboTarifas.ValueMember = "Id";
        }

        private void frmCambioServicioVelSel_Load(object sender, EventArgs e)
        {
            cboServicios_Vel.DataSource = dataTableVel;
            cboServicios_Vel.DisplayMember = "Velocidad";
            cboServicios_Vel.ValueMember = "Id_Servicios_Velocidad";

            CargarTarifa();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnCambioVel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Confirma que desea Realizar el Cambio de Velocidad?", "Mensaje del Sistema",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Id_Velocidad_Sel = Convert.ToInt32(cboServicios_Vel.SelectedValue);
                this.Id_Tarifa_Sel = chkTarifa.CheckState == CheckState.Checked ? Convert.ToInt32(cboTarifas.SelectedValue) : 0;
                this.DialogResult = DialogResult.OK;
            }
        }
    }
}
