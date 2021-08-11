using CapaNegocios;
using System;
using System.Data;
using System.Windows.Forms;

namespace CapaPresentacion.Partes_Trabajo
{
    public partial class frmSeleccionarCuentasAccesoISP : Form
    {
        private int codUsuario;
        private int idCustomer;
        private DataTable dtAccountAccess = new DataTable();

        public int idAccountSeleccionado { get; private set; }

        public frmSeleccionarCuentasAccesoISP(int codUsuario)
        {
            InitializeComponent();
            this.codUsuario = codUsuario;
        }

        private void frmSeleccionarCuentasAccesoISP_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void CargarDatos()
        {
            Isp oIsp = new Isp();
            DataTable dtDatosAppExterna = new Aplicaciones_Externas().Listar(Convert.ToInt32(Aplicaciones_Externas.Aplicacion_Externa.ISP));
            Isp.cadenaConexion = dtDatosAppExterna.Rows[0]["string_conexion"].ToString();
            idCustomer = oIsp.VerificarExisteUsuario(this.codUsuario);
            dtAccountAccess = oIsp.ListarAccessAccount(idCustomer);
            AsignarDatos();
        }

        private void AsignarDatos()
        {
            dgvCuentasAcceso.DataSource = dtAccountAccess;
            foreach (DataGridViewColumn col in dgvCuentasAcceso.Columns)
            {
                col.Visible = false;
            }

            dgvCuentasAcceso.Columns["name"].Visible = true;
            dgvCuentasAcceso.Columns["name"].HeaderText = "Producto";
        }

        private void dgvCuentasAcceso_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            idAccountSeleccionado = Convert.ToInt32(dgvCuentasAcceso.Rows[e.RowIndex].Cells["account_id"].Value);
        }

        private void frmSeleccionarCuentasAccesoISP_Shown(object sender, EventArgs e)
        {
            idAccountSeleccionado = Convert.ToInt32(dgvCuentasAcceso.Rows[0].Cells["account_id"].Value);
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void frmSeleccionarCuentasAccesoISP_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }
    }
}
