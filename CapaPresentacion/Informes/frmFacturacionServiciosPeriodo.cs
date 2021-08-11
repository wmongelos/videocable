using CapaNegocios;
using System;
using System.Data;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class frmFacturacionServiciosPeriodo : Form
    {
        private Thread hilo;
        private delegate void myDel();
        private DataTable[] dt;
        private Facturacion oFacturacion;
        private int agrupacion;
        private int presentacion;
        private Usuarios_CtaCte oUsuCtaCte = new Usuarios_CtaCte();
        private DataTable dtExtras;
       

        public frmFacturacionServiciosPeriodo()
        {
            InitializeComponent();
            oFacturacion = new Facturacion();
            dt = new DataTable[3];
        }

        private void frmFacturacionServiciosPeriodo_Load(object sender, EventArgs e)
        {
            establecerDataTimePicker();
            cboAgrupacion.SelectedIndex = 0;
        }

        private void comenzarCarga()
        {
            pgCircular.Start();

            dgvServicios.DataSource = null;
            dgvEquipos.DataSource = null;
            dgvPartes.DataSource = null;

            hilo = new Thread(new ThreadStart(cargarDatos));

            hilo.Start();
        }

        private void cargarDatos()
        {
            try
            {
                dtExtras = oUsuCtaCte.get_Extras(dtpDesde.Value, dtpHasta.Value);
                myDel MD = new myDel(cargarDGV);

                this.Invoke(MD, new object[] { });

                pgCircular.Stop();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar Informacion" + ex.Message);
            }
        }

        private void cargarDGV()
        {

            this.Cursor = Cursors.WaitCursor;
            dt = oFacturacion.ListarFacturacionServicio(1, presentacion, agrupacion, 1, dtpDesde.Value.ToString("yyyy-MM-dd HH:mm:ss"), dtpHasta.Value.ToString("yyyy-MM-dd HH:mm:ss"));
            foreach (DataRow drExtra in dtExtras.Rows)
                dt[0].Rows.Add("EXTRAS", "EXTRAS", Convert.ToDecimal(drExtra["extras"]), 0, 0, 0);
            dgvServicios.DataSource = dt[0];

            decimal netoTotal = dt[0].AsEnumerable().Sum(x => x.Field<decimal>("neto"));
            decimal importeTotal = dt[0].AsEnumerable().Sum(x => x.Field<decimal>("importe"));

            lblNetoTotal.Text = $"Neto total: {string.Format("{0:C}", netoTotal)}";
            lblImporteTotal.Text = $"Importe total: {string.Format("{0:C}", importeTotal)}";

            if (agrupacion == 1) dgvServicios.Columns["Subservicio"].Visible = false;
            dgvServicios.Columns["importe_original"].Visible = false;
            dgvServicios.Columns["bonificacion"].Visible = false;

            dgvServicios.Columns["Importe"].DefaultCellStyle.Format = "c2";
            dgvServicios.Columns["Importe"].DefaultCellStyle.FormatProvider = Thread.CurrentThread.CurrentCulture;
            dgvServicios.Columns["Importe"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvServicios.Columns["Bonificacion"].DefaultCellStyle.Format = "c2";
            dgvServicios.Columns["Bonificacion"].DefaultCellStyle.FormatProvider = Thread.CurrentThread.CurrentCulture;
            dgvServicios.Columns["Bonificacion"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvServicios.Columns["Cantidad"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvServicios.Columns["Velocidad_megas"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvServicios.Columns["Neto"].DefaultCellStyle.Format = "c2";
            dgvServicios.Columns["Neto"].DefaultCellStyle.FormatProvider = Thread.CurrentThread.CurrentCulture;
            dgvServicios.Columns["Neto"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;


            dgvServicios.Columns["Servicios"].HeaderText = "Servicio";
            dgvServicios.Columns["Importe"].HeaderText = "Importe";
            dgvServicios.Columns["Neto"].HeaderText = "Neto";
            dgvServicios.Columns["Bonificacion"].HeaderText = "Bonificacion";
            dgvServicios.Columns["Cantidad"].HeaderText = "Cantidad";
            dgvServicios.Columns["Tipo_Internet"].HeaderText = "Tipo / Internet";
            dgvServicios.Columns["velocidad_megas"].HeaderText = "Megas / Velocidad";


            dgvEquipos.DataSource = dt[1];

            dgvEquipos.Columns["Importe"].DefaultCellStyle.Format = "c2";
            dgvEquipos.Columns["Importe"].DefaultCellStyle.FormatProvider = Thread.CurrentThread.CurrentCulture;
            dgvEquipos.Columns["Importe"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvEquipos.Columns["Bonificacion"].DefaultCellStyle.Format = "c2";
            dgvEquipos.Columns["Bonificacion"].DefaultCellStyle.FormatProvider = Thread.CurrentThread.CurrentCulture;
            dgvEquipos.Columns["Bonificacion"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvEquipos.Columns["Cantidad"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvPartes.DataSource = dt[2];

            dgvPartes.Columns["Importe"].DefaultCellStyle.Format = "c2";
            dgvPartes.Columns["Importe"].DefaultCellStyle.FormatProvider = Thread.CurrentThread.CurrentCulture;
            dgvPartes.Columns["Importe"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvPartes.Columns["Bonificacion"].DefaultCellStyle.Format = "c2";
            dgvPartes.Columns["Bonificacion"].DefaultCellStyle.FormatProvider = Thread.CurrentThread.CurrentCulture;
            dgvPartes.Columns["Bonificacion"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvPartes.Columns["Cantidad"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;


            actualizarLabelTotal();
            this.Cursor = Cursors.Default;
        }

        private void establecerDataTimePicker()
        {
            dtpDesde.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 01);
            dtpHasta.Value = DateTime.Now;
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
            if (cboAgrupacion.SelectedIndex != -1)
                comenzarCarga();
            else
            {
                MessageBox.Show("Seleccionar como mostrar la tabla", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboAgrupacion.Focus();
            }
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            if (dgvServicios.Rows.Count > 0)
            {
                try
                {
                    Tools tools = new Tools();
                    if (tabControl1.SelectedIndex == 0)
                        tools.ExportToExcel(dgvServicios, "Facturacion");
                    if (tabControl1.SelectedIndex == 1)
                        tools.ExportToExcel(dgvEquipos, "Facturacion");
                    if (tabControl1.SelectedIndex == 2)
                        tools.ExportToExcel(dgvPartes, "Facturacion");
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

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            actualizarLabelTotal();
            actualizarTitulo();
        }

        private void actualizarLabelTotal()
        {
            if (dgvEquipos != null)
            {
                if (tabControl1.SelectedIndex == 0)
                    lblTotal.Text = String.Format("Total de Registros: {0}", dgvServicios.Rows.Count);
                else if (tabControl1.SelectedIndex == 1)
                    lblTotal.Text = String.Format("Total de Registros: {0}", dgvEquipos.Rows.Count);
                else if (tabControl1.SelectedIndex == 2)
                    lblTotal.Text = String.Format("Total de registros: {0}", dgvPartes.Rows.Count);
            }
        }

        private void actualizarTitulo()
        {
            if (tabControl1.SelectedIndex == 0)
                lblFS.Text = "Facturacion Servicios por periodo";
            else if (tabControl1.SelectedIndex == 1)
                lblFS.Text = "Facturacion Equipos por periodo";
            else if (tabControl1.SelectedIndex == 2)
                lblFS.Text = "Facturacion Partes por periodo";
        }

        private void imgReturn_Click(object sender, EventArgs e) => this.Close();

        private void frmFacturacionServiciosPeriodo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
    }
}
