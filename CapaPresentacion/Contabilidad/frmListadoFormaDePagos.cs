using CapaNegocios;
using System;
using System.Data;
using System.Windows.Forms;



namespace CapaPresentacion.Informes
{
    public partial class frmListadoFormaDePagos : Form
    {
        private Formas_de_pago oFormadePago = new Formas_de_pago();
        private Formas_de_pago oSumaImporte = new Formas_de_pago();
        private Formas_de_pago oDetalleFormaPago = new Formas_de_pago();
        private DataTable dtHistorialFormaPago, dtDetalladoFormaPago;
        private Int32 counter;


        public frmListadoFormaDePagos()
        {
            InitializeComponent();
        }

        private void ComenzarCarga()
        {
            CargarDatos();
        }

        private void CargarDatos()
        {
            cboFormaPago.DataSource = oFormadePago.ListarFormaPago();
            dtHistorialFormaPago = oFormadePago.ListarPorFechaDetalle(dtpDesde.Value, dtpHasta.Value, cboFormaPago.SelectedValue.ToString());
            AsignarDatos();
        }

        private void AsignarDatos()
        {
            dgvFechas.DataSource = dtHistorialFormaPago;

            for (int j = 0; j < dgvFechas.ColumnCount; j++)
                dgvFechas.Columns[j].Visible = true;

            dgvFechas.Columns["cuit"].Visible = false;
            dgvFechas.Columns["nombre"].Visible = false;
            dgvFechas.Columns["banco"].Visible = false;
            dgvFechas.Columns["sucursal"].Visible = false;
            dgvFechas.Columns["cajadiaria"].Visible = false;
            dgvFechas.Columns["numeromuestra"].Visible = false;
            dgvFechas.Columns["fechamovimiento"].Visible = false;
            dgvFechas.Columns["id_recibo"].Visible = false;

            dgvFechas.Columns["codigo"].HeaderText = "Código";
            dgvFechas.Columns["usuario"].HeaderText = "Usuario";
            dgvFechas.Columns["localidad"].HeaderText = "Localidad";
            dgvFechas.Columns["formapago"].HeaderText = "Forma de Pago";
            dgvFechas.Columns["fecha_comprobante"].HeaderText = "Fecha de Comprobante";
            dgvFechas.Columns["puntocobro"].HeaderText = "Punto de Cobro";
            dgvFechas.Columns["empleado"].HeaderText = "Personal";
            dgvFechas.Columns["importe"].HeaderText = "Importe";

            dgvFechas.Visible = false;
            OcultarControles();

            cboFormaPago.Enabled = true;
            cboFormaPago.ValueMember = "Id";
            cboFormaPago.DisplayMember = "Nombre";
            dtpHasta.Value = DateTime.Now;
            dtpDesde.Value = DateTime.Now.AddDays(-30);
            dtpDesde.Format = DateTimePickerFormat.Custom;
            dtpDesde.CustomFormat = "ddd dd MMM yyyy";
            dtpHasta.Format = DateTimePickerFormat.Custom;
            dtpHasta.CustomFormat = "ddd dd MMM yyyy";


        }


        private void AsignarDatosDetalles()
        {
            dgvDetalladoFormaPago.DataSource = dtDetalladoFormaPago;
            for (int x = 0; x < dgvDetalladoFormaPago.ColumnCount; x++)
            {
                dgvDetalladoFormaPago.Columns[x].Visible = true;
            }

            dgvDetalladoFormaPago.Columns["id_comprobantes"].Visible = false;
        }

        private void FiltrarDatos()
        {
            string texto = Convert.ToString(txtBusca.Text);
            Decimal Impdesde, Imphasta;
            Impdesde = Convert.ToDecimal(spnImporteDesde.Value);
            Imphasta = Convert.ToDecimal(spnImporteHasta.Value);
            dtHistorialFormaPago.DefaultView.RowFilter = String.Format("(usuario Like '%{0}%' OR localidad Like '%{0}%' OR formapago Like '%{0}%' OR PuntoCobro Like '%{0}%' OR empleado Like '%{0}%') and ( importe >= {1} and importe<={2})", texto, Impdesde, Imphasta);
        }

        private void AsignarDatosDetalladosUsuario()
        {
            lblTotalBanco.Text = dgvFechas.SelectedRows[0].Cells["Banco"].Value.ToString();
            lblTotalCajaDiaria.Text = dgvFechas.SelectedRows[0].Cells["CajaDiaria"].Value.ToString();
            lblTotalCuit.Text = dgvFechas.SelectedRows[0].Cells["cuit"].Value.ToString();
            lblTotalFechaMov.Text = dgvFechas.SelectedRows[0].Cells["FechaMovimiento"].Value.ToString();
            lblTotalNombre.Text = dgvFechas.SelectedRows[0].Cells["Nombre"].Value.ToString();
            lblTotalNumMuestra.Text = dgvFechas.SelectedRows[0].Cells["NumeroMuestra"].Value.ToString();
            lblTotalSucursal.Text = dgvFechas.SelectedRows[0].Cells["Sucursal"].Value.ToString();
        }
        private void CalculaTotal()
        {
            decimal SumaImporte = 0;
            foreach (DataGridViewRow dr in dgvFechas.Rows)
            {
                SumaImporte = SumaImporte + Convert.ToDecimal(dr.Cells["Importe"].Value);
            }
            lblTotal.Text = "$" + Convert.ToString(SumaImporte);

        }

        private void CalculaTotalMovimientos()
        {
            for (counter = 0; counter < (dgvFechas.SelectedCells.Count); counter++)
            {

            }
            lblTotalMov.Text = dtHistorialFormaPago.Rows.Count.ToString();
        }

        private void frmListadoFormaDePagos_Load(object sender, EventArgs e)
        {
            ComenzarCarga();
        }

        private void VerControles()
        {
            dgvFechas.Visible = true;
            lblResultado.Visible = true;
            lblTotal.Visible = true;
            txtBusca.Visible = true;
            lblBuscar.Visible = true;
            lblImporteDesde.Visible = true;
            lblImporteHasta.Visible = true;
            spnImporteDesde.Visible = true;
            spnImporteHasta.Visible = true;
            btnFiltraImporte.Visible = true;
        }

        private void OcultarControles()
        {
            dgvFechas.Visible = false;
            lblResultado.Visible = false;
            lblTotal.Visible = false;
            txtBusca.Visible = false;
            lblBuscar.Visible = false;
            lblImporteDesde.Visible = false;
            lblImporteHasta.Visible = false;
            spnImporteDesde.Visible = false;
            spnImporteHasta.Visible = false;
            btnFiltraImporte.Visible = false;
            cntDetalladoFormaPago.Visible = false;
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {

            AsignarDatos();
            VerControles();
        }

        private void imgReturn_Click(object sender, EventArgs e)
        {

            if (dgvFechas.Visible == true)
            {
                dgvFechas.Visible = false;
            }
            else
            {
                this.Close();
            }
            OcultarControles();
        }

        private void txtBusca_TextChanged(object sender, EventArgs e)
        {
            if (txtBusca.Text.Trim() != "")
            {
                FiltrarDatos();
            }
            else if (txtBusca.Text.Trim() == "")
            {
                AsignarDatos();
                VerControles();
                txtBusca.Focus();
            }
        }

        private void dgvFechas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvFechas.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                Int32 id_recibo;
                id_recibo = Convert.ToInt32(dgvFechas.SelectedRows[0].Cells["id_recibo"].Value.ToString());
                dtDetalladoFormaPago = oDetalleFormaPago.ListadoDetalladoFormaPago(id_recibo);
                AsignarDatosDetalles();
                cntDetalladoFormaPago.Visible = true;
                //  cntDetalladoFormaPago.location = new point(this.Width / 2, this.Height / 2);
                AsignarDatosDetalladosUsuario();
            }
        }

        private void cntDetalladoFormaPago_Paint(object sender, PaintEventArgs e)
        {
            dgvDetalladoFormaPago.Visible = true;
        }

        private void btnSale_Click(object sender, EventArgs e)
        {
            cntDetalladoFormaPago.Visible = false;

            VerControles();
            CalculaTotal();
            CalculaTotalMovimientos();

        }

        private void btnFiltraImporte_Click(object sender, EventArgs e)
        {
            FiltrarDatos();
        }

        private void frmListadoFormaDePagos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

            dtHistorialFormaPago = oFormadePago.ListarPorFechaDetalle(dtpDesde.Value, dtpHasta.Value, cboFormaPago.SelectedValue.ToString());
            AsignarDatos();
            VerControles();
            CalculaTotal();
            CalculaTotalMovimientos();

        }
    }




}
