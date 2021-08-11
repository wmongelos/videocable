using CapaNegocios;
using System;
using System.Data;
using System.Threading;
using System.Windows.Forms;

namespace CapaPresentacion.Informes
{
    public partial class frmConsultaRecibos : Form
    {

        #region [PROPIEDADES]
        private Thread hilo;
        private delegate void myDel();
        private Usuarios_CtaCte oUsuariosCtaCte = new Usuarios_CtaCte();
        private DataTable dtDatos = new DataTable();
        private int movimientoSeleccionado;
        private DateTime fechaDesde = new DateTime();
        private DateTime fechaHasta = new DateTime();
        private Formas_de_pago oFormasDePago = new Formas_de_pago();
        private Caja_Diaria oCajaDiaria = new Caja_Diaria();
        private DataView dtvRecibos;
        private DataTable dtTipoFormasPago = new DataTable();
        private decimal Total = 0;
        #endregion

        #region [METODOS]
        private void ComenzarCarga()
        {
            pgCircular.Start();
            hilo = new Thread(new ThreadStart(CargarDatos));
            hilo.IsBackground = true;
            hilo.Start();
            btnBuscar.Enabled = false;
            btnExportar.Enabled = false;
        }

        private void CargarDatos()
        {
            try
            {
                dtDatos = oCajaDiaria.ListarDetallesCtaCteDetPagos(0, 0, 0);
                dtvRecibos = new DataView(dtDatos);
                dtvRecibos.RowFilter = String.Format("fecha_acreditacion>='{0}' and fecha_acreditacion<='{1}' and id_formas_de_pago={2}", fechaDesde.Date.ToString("yyyy-MM-dd"), fechaHasta.Date.ToString("yyyy-MM-dd"), movimientoSeleccionado);
                dtDatos = dtvRecibos.ToTable();
                myDel MD = new myDel(AsignarDatos);
                this.Invoke(MD, new object[] { });
            }
            catch
            {
                MessageBox.Show("Error al cargar información.");
            }
            pgCircular.Stop();
        }

        private void AsignarDatos()
        {
            dgvDatos.DataSource = null;
            dgvDatos.DataSource = dtDatos;
            FormatearGrilla();
            Total = 0;
            foreach (DataRow fila in dtDatos.Rows)
            {
                try
                {
                    Total += Convert.ToDecimal(fila["importe"]);
                }
                catch
                {

                }
            }
            lblTotalMonto.Text = String.Format("Total: ${0}", Total);
            btnBuscar.Enabled = true;
            btnExportar.Enabled = true;
        }

        private void FormatearGrilla()
        {
            for (int x = 0; x < dgvDatos.Columns.Count; x++)
                dgvDatos.Columns[x].Visible = false;

            dgvDatos.Columns["codigo"].Visible = true;
            dgvDatos.Columns["nomape"].Visible = true;
            dgvDatos.Columns["numero_muestra"].Visible = true;
            dgvDatos.Columns["fecha_acreditacion"].Visible = true;
            dgvDatos.Columns["importe"].Visible = true;
            dgvDatos.Columns["nombre"].Visible = true;
            dgvDatos.Columns["importe"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvDatos.Columns["importe"].DefaultCellStyle.Format = "C2";
            dgvDatos.Columns["codigo"].HeaderText = "Código";
            dgvDatos.Columns["nomape"].HeaderText = "Usuario";
            dgvDatos.Columns["numero_muestra"].HeaderText = "Número";
            dgvDatos.Columns["fecha_acreditacion"].HeaderText = "Fecha de acreditación";
            dgvDatos.Columns["importe"].HeaderText = "Importe";
            dgvDatos.Columns["nombre"].HeaderText = "Tipo de forma de pago";


            lblTotal.Text = String.Format("{0}", dgvDatos.Rows.Count);
        }
        #endregion

        public frmConsultaRecibos()
        {
            InitializeComponent();
        }

        private void frmConsultaVentasCobros_Load(object sender, EventArgs e)
        {

            dtTipoFormasPago = oFormasDePago.ListarTiposFormasPagos();
            cmbTipo.DataSource = dtTipoFormasPago;
            cmbTipo.DisplayMember = "nombre";
            cmbTipo.ValueMember = "id";

            cmbTipo.SelectedIndex = 0;
            movimientoSeleccionado = Convert.ToInt32(cmbTipo.SelectedValue);
            dtpDesde.Value = DateTime.Now;
            dtpHasta.Value = DateTime.Now;
            fechaDesde = dtpDesde.Value;
            fechaHasta = dtpHasta.Value;
 
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            fechaDesde = dtpDesde.Value;
            fechaHasta = dtpHasta.Value;
            movimientoSeleccionado = Convert.ToInt32(cmbTipo.SelectedValue);
            if (DateTime.Compare(fechaDesde, fechaHasta) <= 0)
                ComenzarCarga();
            else
                MessageBox.Show("La fecha hasta debe ser mayor que la fecha desde.");
        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                movimientoSeleccionado = Convert.ToInt32(cmbTipo.SelectedValue);
            }
            catch
            {
                movimientoSeleccionado = Convert.ToInt32(dtTipoFormasPago.Rows[0]["id"]);
            }
        }

        private void frmConsultaVentasCobros_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.Rows.Count > 0)
            {
                Tools tools = new Tools();
                try
                {
                    this.Cursor = Cursors.WaitCursor;
                    tools.ExportToExcel(dgvDatos, "Consulta Recibos");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally { this.Cursor = Cursors.Default; }
            }
            else
            {
                MessageBox.Show("Tabla vacia", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
