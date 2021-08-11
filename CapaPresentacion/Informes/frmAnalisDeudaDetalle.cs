using System;
using System.Data;
using System.Windows.Forms;

namespace CapaPresentacion.Informes
{
    public partial class frmAnalisDeudaDetalle : Form
    {
        private DataTable dtDeudasDetalles;
        private Double facturacionTotal, deudaTotal;

        public frmAnalisDeudaDetalle(DataTable dtDeudasDetalles, string zona = "", string localidad = "", string tipoServicio = "", string servicio = "")
        {
            InitializeComponent();
            this.dtDeudasDetalles = dtDeudasDetalles;
            lblZona.Text += $" {zona.Trim()}";
            lblLocalidad.Text += $" {localidad.Trim()}";
            lblTipo.Text += $" {tipoServicio.Trim()}";
            lblServicio.Text += $" {servicio.Trim()}";
        }

        private void frmAnalisDeudaDetalle_Load(object sender, EventArgs e)
        {
            dgvDetalle.DataSource = dtDeudasDetalles;
            formatearDataGridView();
            calcularTotales();
            lblTotal.Text = String.Format("Total de Registros: {0}", dgvDetalle.Rows.Count);
        }

        private void formatearDataGridView()
        {
            foreach (DataGridViewColumn col in dgvDetalle.Columns)
            {
                col.Visible = false;
            }

            dgvDetalle.Columns["codigo"].Visible = true;
            dgvDetalle.Columns["usuario"].Visible = true;
            dgvDetalle.Columns["Subservicio"].Visible = true;
            dgvDetalle.Columns["Facturado"].Visible = true;
            dgvDetalle.Columns["Deuda"].Visible = true;

            dgvDetalle.Columns["codigo"].HeaderText = "Codigo de usuario";
            dgvDetalle.Columns["usuario"].HeaderText = "Nombre y Apellido";
            dgvDetalle.Columns["Subservicio"].HeaderText = "SubServicio";
            dgvDetalle.Columns["Facturado"].HeaderText = "Facturado";
            dgvDetalle.Columns["Deuda"].HeaderText = "Deuda";

            dgvDetalle.Columns["Facturado"].DefaultCellStyle.Format = "C2";
            dgvDetalle.Columns["Facturado"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvDetalle.Columns["Deuda"].DefaultCellStyle.Format = "C2";
            dgvDetalle.Columns["Deuda"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        private void calcularTotales()
        {
            facturacionTotal = 0;
            deudaTotal = 0;
            if (dgvDetalle.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvDetalle.Rows)
                {
                    this.facturacionTotal += Convert.ToDouble(row.Cells["Facturado"].Value);
                    this.deudaTotal += Convert.ToDouble(row.Cells["Deuda"].Value);
                }
            }
            lblFacturacion.Text = $"Facturacion total: {facturacionTotal}";
            lblDeuda.Text = $"Deuda total: {deudaTotal}";
        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtFiltrar_TextChanged(object sender, EventArgs e)
        {

            dtDeudasDetalles.DefaultView.RowFilter = String.Format("usuario like '%{0}%' or Subservicio like '%{0}%' or " +
                "Convert([codigo], System.String) LIKE '{0}%'", txtFiltrar.Text);

            calcularTotales();
            lblTotal.Text = String.Format("Total de Registros: {0}", dgvDetalle.Rows.Count);
        }

        private void frmAnalisDeudaDetalle_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }


    }
}
