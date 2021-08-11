using CapaNegocios;
using System;
using System.Data;
using System.Windows.Forms;

namespace CapaPresentacion.Abms
{
    public partial class ABMAplicaciones_Externas_Relacion : Form
    {
        private Aplicaciones_Externas oAppExternas = new Aplicaciones_Externas();
        private DataTable dt = new DataTable();

        public ABMAplicaciones_Externas_Relacion()
        {
            InitializeComponent();
        }

        private void CargarDatos()
        {
            dt = oAppExternas.ListarServicios(Convert.ToInt32(cboApliciones_Externas.SelectedValue));
            dgv.DataSource = dt;
            dgv.ReadOnly = false;
            dgv.Columns["Servicio"].ReadOnly = true;
            dgv.Columns["SubServicios"].ReadOnly = true;
            dgv.Columns["Id_Servicios"].Visible = false;
            dgv.Columns["Id_Servicios_Sub"].Visible = false;

            btnGuardar.Enabled = dt.Rows.Count > 0 ? true : false;
        }

        private void ABMAplicaciones_Externas_Relacion_Load(object sender, EventArgs e)
        {
            cboApliciones_Externas.DataSource = oAppExternas.Listar();
            cboApliciones_Externas.ValueMember = "Id";
            cboApliciones_Externas.DisplayMember = "Nombre";
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea Guardar la Compabilidad de la Aplicacion Externa?", "Mensaje del Sistema",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                oAppExternas.GuardarServiciosCompatibilidad(Convert.ToInt32(cboApliciones_Externas.SelectedValue), dt);
                oAppExternas.ListarServicios(Convert.ToInt32(cboApliciones_Externas.SelectedValue));
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ABMAplicaciones_Externas_Relacion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
    }
}
