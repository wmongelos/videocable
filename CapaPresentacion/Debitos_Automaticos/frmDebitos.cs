using CapaNegocios;
using System;
using System.Data;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace CapaPresentacion.Impuestos
{
    public partial class frmDebitos : Form
    {
        private delegate void myDel();
        private Thread hilo;
        private Plasticos_Usuarios oPlasticosUsuarios = new Plasticos_Usuarios();
        private Usuarios oUsuarios = new Usuarios();
        private Servicios oServicios = new Servicios();
        private DataTable dt_plasticosUsuarios = new DataTable();
        private DateTime fechaHoy = DateTime.Today;
        private Tools oTools = new Tools();
        public int buscar;
        public Plasticos oPlasticos = new Plasticos();

        private void ComenzarCarga()
        {
            pgCircular.Start();
            txtBusca.Enabled = false;
            btnexportar.Enabled = false;
            dgv.DataSource = null;
            hilo = new Thread(new ThreadStart(CargarDatos));
            hilo.IsBackground = true;
            hilo.Start();
        }

        private void CargarDatos()
        {

            dt_plasticosUsuarios = oPlasticosUsuarios.Listar_Plasticos();
            myDel MD = new myDel(AsignarDatos);
            this.Invoke(MD, new object[] { });
            pgCircular.Stop();

        }

        private void AsignarDatos()
        {
            if (dt_plasticosUsuarios.Rows.Count > 0)
            {
                dgv.DataSource = dt_plasticosUsuarios;

                for (int x = 0; x < dgv.Columns.Count; x++)
                    dgv.Columns[x].Visible = false;
                dgv.Columns["titular"].Visible = true;
                dgv.Columns["numero"].Visible = true;
                dgv.Columns["vencimiento"].Visible = true;
                dgv.Columns["fecha_inicio"].Visible = true;
                dgv.Columns["fecha_baja"].Visible = true;
                dgv.Columns["usuario"].Visible = true;
                dgv.Columns["descripcion"].Visible = true;
                dgv.Columns["activo_texto"].Visible = true;

                dgv.Columns["titular"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgv.Columns["numero"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgv.Columns["usuario"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

                dgv.Columns["titular"].HeaderText = "Titular";
                dgv.Columns["numero"].HeaderText = "Numero";
                dgv.Columns["vencimiento"].HeaderText = "Vencimiento";
                dgv.Columns["fecha_inicio"].HeaderText = "Fecha Inicio";
                dgv.Columns["fecha_baja"].HeaderText = "Fecha Baja";
                dgv.Columns["usuario"].HeaderText = "Usuario";
                dgv.Columns["descripcion"].HeaderText = "Servicio";
                dgv.Columns["activo_texto"].HeaderText = "Estado";

                lblTotal.Text = String.Format("Total de Registros: {0}", dt_plasticosUsuarios.DefaultView.Count);
                ColorearGrilla();
            }
            else
            {
                MessageBox.Show("Debe cargar datos.");
            }
            txtBusca.Enabled = true;
            btnexportar.Enabled = true;
        }

        private void ColorearGrilla()
        {
            foreach (DataGridViewRow item in dgv.Rows)
            {
                if (Convert.ToInt32(item.Cells["activo"].Value) == 1)
                {
                    if (Convert.ToDateTime(item.Cells["vencimiento"].Value) < fechaHoy)
                        item.DefaultCellStyle.BackColor = Color.Tomato;
                    else
                        item.DefaultCellStyle.BackColor = Color.LightGreen;
                }
                else
                    item.DefaultCellStyle.BackColor = Color.DarkGray;
            }
        }

        public frmDebitos()
        {
            InitializeComponent();
        }

        private void frmDebitos_Load(object sender, EventArgs e)
        {
            ComenzarCarga();
            txtBusca.Focus();
        }

        private void txttitular_TextChanged(object sender, EventArgs e)
        {
            if (txtBusca.Text.Trim() != "")
            {
                string texto = Convert.ToString(txtBusca.Text);
                dt_plasticosUsuarios.DefaultView.RowFilter = String.Format("titular Like '%" + texto + "%' OR numero Like '%" + texto + "%' OR usuario like '%" + texto + "%' OR descripcion like '%" + texto + "%'");
                AsignarDatos();
                ColorearGrilla();
            }
            else
            {
                dt_plasticosUsuarios.DefaultView.RowFilter = "id>0";
                ColorearGrilla();

            }

        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnexportar_Click(object sender, EventArgs e)
        {
            oTools.ExportToExcel(dgv, "Debitos");
        }

        private void frmDebitos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv.SelectedRows.Count > 0 & buscar == 1)
            {
                oPlasticos.Id = Convert.ToInt32(dgv.SelectedRows[0].Cells["id"].Value);
                DialogResult = DialogResult.OK;
            }
        }
    }
}
