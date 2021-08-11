using CapaNegocios;
using System;
using System.Data;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class frmFacturacionServiciosPorPeriodo : Form
    {
        private Thread hilo;
        private delegate void myDel();
        private Facturacion_Mensual_Historial fmh;
        private DataTable dtPeriodos;
        private DataTable[] dtPrincipal;
        private Facturacion oFacturacion;
        private int id_facturacion;
        private int presentacion;
        private int agrupacion;

        public frmFacturacionServiciosPorPeriodo()
        {
            InitializeComponent();
            fmh = new Facturacion_Mensual_Historial();
            dtPeriodos = new DataTable();
            dtPrincipal = new DataTable[1];
            oFacturacion = new Facturacion();
        }

        private void frmFacturacionServicios_Load(object sender, EventArgs e)
        {
            cargarDGVPeriodos();
            controles(true);
        }

        private void comenzarCarga()
        {
            pgCircular.Start();

            dgvPrincipal.DataSource = null;

            hilo = new Thread(new ThreadStart(cargarDatos));

            hilo.Start();
        }

        private void cargarDatos()
        {
            try
            {
                myDel MD = new myDel(cargarDGVPrincipal);

                this.Invoke(MD, new object[] { });

                pgCircular.Stop();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar Informacion" + ex.Message);
            }
        }

        private void cargarDGVPeriodos()
        {
            dtPeriodos = fmh.ListarHistorial();
            dgvPeriodos.DataSource = dtPeriodos;

            foreach (DataGridViewColumn row in dgvPeriodos.Columns)
            {
                row.Visible = false;
            }

            dgvPeriodos.Columns["periodo"].Visible = true;
            dgvPeriodos.Columns["periodo"].HeaderText = "Periodo";
        }

        private void cargarDGVPrincipal()
        {
            this.Cursor = Cursors.WaitCursor;
            dtPrincipal = oFacturacion.ListarFacturacionServicio(0, presentacion, agrupacion, id_facturacion);

            decimal netoTotal = dtPrincipal[0].AsEnumerable().Sum(x => x.Field<decimal>("neto"));
            decimal importeTotal = dtPrincipal[0].AsEnumerable().Sum(x => x.Field<decimal>("importe"));

            lblNetoTotal.Text = $"Neto total: {string.Format("{0:C}", netoTotal)}";
            lblImporteTotal.Text = $"Importe total: {string.Format("{0:C}", importeTotal)}";

            dgvPrincipal.DataSource = dtPrincipal[0];

            if (agrupacion == 1) dgvPrincipal.Columns["Subservicio"].Visible = false;
            dgvPrincipal.Columns["importe_original"].Visible = false;
            dgvPrincipal.Columns["bonificacion"].Visible = false;

            dgvPrincipal.Columns["Importe"].DefaultCellStyle.Format = "c2";
            dgvPrincipal.Columns["Importe"].HeaderText = "Importe";
            dgvPrincipal.Columns["Importe"].DefaultCellStyle.FormatProvider = Thread.CurrentThread.CurrentCulture;
            dgvPrincipal.Columns["Importe"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvPrincipal.Columns["Bonificacion"].DefaultCellStyle.Format = "c2";
            dgvPrincipal.Columns["Bonificacion"].HeaderText = "Bonificacion";
            dgvPrincipal.Columns["Bonificacion"].DefaultCellStyle.FormatProvider = Thread.CurrentThread.CurrentCulture;
            dgvPrincipal.Columns["Bonificacion"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvPrincipal.Columns["neto"].DefaultCellStyle.Format = "c2";
            dgvPrincipal.Columns["neto"].HeaderText = "Neto";
            dgvPrincipal.Columns["neto"].DefaultCellStyle.FormatProvider = Thread.CurrentThread.CurrentCulture;
            dgvPrincipal.Columns["neto"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvPrincipal.Columns["Cantidad"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvPrincipal.Columns["Cantidad"].HeaderText = "Cantidad";
            dgvPrincipal.Columns["Velocidad_megas"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvPrincipal.Columns["Velocidad_megas"].HeaderText = "Megas de velocidad";
            dgvPrincipal.Columns["tipo_internet"].HeaderText = "Tipo de internet";

            lblTotal.Text = String.Format("Total de Registros: {0}", dgvPrincipal.Rows.Count);
            this.Cursor = Cursors.Default;
        }

        private void controles(bool state)
        {
            groupBox1.Enabled = state;
            btnBuscar.Enabled = state;
            labelPeriodoSelec.Enabled = state;
            btnExportar.Enabled = state;
            cboAgrupacion.Enabled = state;
            labelMostrar.Enabled = state;
        }

        private void establecerAgrupacion()
        {
            if (cboAgrupacion.SelectedIndex == 0)
                agrupacion = 1;
            else if (cboAgrupacion.SelectedIndex == 1)
                agrupacion = 2;
        }

        private void establecerPresentacion()
        {
            if (radioButtonTodos.Checked)
                presentacion = -1;
            else if (radioButtonUniverso.Checked)
                presentacion = 1;
            else if (radioButtonEspeciales.Checked)
                presentacion = 0;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            establecerAgrupacion();
            establecerPresentacion();
            if (dgvPeriodos.Rows.Count > 0)
            {
                if (cboAgrupacion.SelectedIndex != -1)
                    comenzarCarga();
                else
                {
                    MessageBox.Show("Seleccionar una agrupacion", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cboAgrupacion.Focus();
                }
            }
            else
                MessageBox.Show("No hay periodos disponibles entre esas fechas", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            if (dgvPrincipal.Rows.Count > 0)
            {
                try
                {
                    Tools tools = new Tools();
                    tools.ExportToExcel(dgvPrincipal, "Facturacion");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Tabla vacia", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dgvPeriodos_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            txtPeriodoSeleccionado.Text = dgvPeriodos.Rows[e.RowIndex].Cells["periodo"].Value.ToString();
            id_facturacion = Convert.ToInt32(dgvPeriodos.Rows[e.RowIndex].Cells["id"].Value);
        }

        private void imgReturn_Click(object sender, EventArgs e) => this.Close();

        private void frmFacturacionServicios_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
    }
}
