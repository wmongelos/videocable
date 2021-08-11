using CapaNegocios;
using System;
using System.Data;
using System.Threading;
using System.Windows.Forms;
namespace CapaPresentacion
{
    public partial class frmDebitosPresentacion : Form
    {
        public frmDebitosPresentacion()
        {
            InitializeComponent();
        }
        private delegate void myDel();
        private Thread hilo;
        private DataTable dt_formasPago = new DataTable();
        private DataTable dt_plasticos = new DataTable();
        private Formas_de_pago Oformas = new Formas_de_pago();
        private Plasticos oPlasticos = new Plasticos();
        private Tools oTols = new Tools();
        private Servicios_Tarifas oServicios_Tarifas = new Servicios_Tarifas();
        private int IdFormaPago = 0;
        private Boolean Buscar = false;

        private int idtarifa;

        private void comenzarCarga()
        {
            pgCircular.Start();
            dgv.DataSource = null;
            hilo = new Thread(new ThreadStart(cargarDatos));
            hilo.IsBackground = true;
            hilo.Start();
        }

        private void cargarDatos()
        {
            if (dt_formasPago.Rows.Count == 0)
            {
                dt_formasPago = Oformas.ListarFormasDePagoConPresentacion();
                IdFormaPago = Convert.ToInt32(dt_formasPago.Rows[0]["id"]);
            }

            if (dt_formasPago.Rows.Count > 0)
                dt_plasticos = oPlasticos.ListarPresentacionDebitos("S", idtarifa, IdFormaPago);

            myDel MD = new myDel(asignarDatos);
            this.Invoke(MD, new object[] { });
            pgCircular.Stop();
        }

        private void asignarDatos()
        {
            if (Buscar == false)
            {
                cboEmpresa.DataSource = dt_formasPago;
                cboEmpresa.DisplayMember = "nombre";
                cboEmpresa.ValueMember = "id";
                cboEmpresa.SelectedIndex = 0;
            }
            dgv.DataSource = dt_plasticos;
            formatearGrilla();
            lblTotal.Text = "Total de Registros:" + dt_plasticos.DefaultView.Count;
        }

        private void FrmDebitosPresentacion(object sender, EventArgs e)
        {
            oServicios_Tarifas.Fecha_Actual = DateTime.Now;
            idtarifa = oServicios_Tarifas.getTarifa();
            comenzarCarga();
        }

        private void formatearGrilla()
        {
            dgv.Columns["id"].Visible = false;
            dgv.Columns["id_forma_de_pago"].Visible = false;
            dgv.Columns["borrado"].Visible = false;
            dgv.Columns["id_usuarios_servicios"].Visible = false;
            dgv.Columns["importe"].Visible = false;
            dgv.Columns["activoTexto"].Visible = false;
            dgv.Columns["id_servicios_sub"].Visible = false;
            dgv.Columns["tiposub"].Visible = false;
            dgv.Columns["activo"].Visible = false;
            dgv.Columns["id_servicios_tarifas"].Visible = false;
            dgv.Columns["Id_Zonas"].Visible = false;
            dgv.Columns["Id_Servicios_Categorias"].Visible = false;
            dgv.Columns["id_tipo_facturacion"].Visible = false;

            dgv.Columns["titular"].HeaderText = "Titular";
            dgv.Columns["numero"].HeaderText = "Numero";
            dgv.Columns["vencimiento"].HeaderText = "Vencimiento";
            dgv.Columns["formapago"].HeaderText = "Tarjeta";
            dgv.Columns["suma"].HeaderText = "Total";
            dgv.Columns["suma"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv.Columns["suma"].DefaultCellStyle.Format = "c";

        }

        private void btnexportar_Click(object sender, EventArgs e)
        {
            oTols.ExportToExcel(dgv, "Debitos");
        }

        private void txtBusca_TextChanged(object sender, EventArgs e)
        {
            if (txtBusca.Text.Trim() != "")
            {
                string texto = Convert.ToString(txtBusca.Text);
                dt_plasticos.DefaultView.RowFilter = String.Format("titular Like '%{0}%' OR formapago Like '%{0}%' OR numero Like '%{0}%'  OR formapago Like '%{0}%'", texto);
                lblTotal.Text = "Total de Registros:" + dt_plasticos.DefaultView.Count;
            }
            else
            {
                comenzarCarga();
                asignarDatos();

            }
        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgv_ColumnSortModeChanged(object sender, DataGridViewColumnEventArgs e)
        {
            if (txtBusca.Text.Trim() != "")
            {
                string texto = Convert.ToString(txtBusca.Text);
                dt_plasticos.DefaultView.RowFilter = String.Format("titular Like '%{0}%' OR formapago Like '%{1}%' OR numero Like '%{2}%'", texto, texto, texto);
                lblTotal.Text = "Total de Registros:" + dt_plasticos.DefaultView.Count;

            }
            else
            {
                comenzarCarga();
                asignarDatos();

            }
        }

        private void frmDebitosPresentacion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Buscar = true;
            comenzarCarga();
        }

        private void cboEmpresa_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                IdFormaPago = Convert.ToInt32(cboEmpresa.SelectedValue);
            }
            catch { }
        }
    }
}