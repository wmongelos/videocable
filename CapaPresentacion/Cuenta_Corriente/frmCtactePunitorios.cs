using CapaNegocios;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class frmCtactePunitorios : Form
    {
        public enum TIPO_MODIFICACION_PUNITORIO
        {
            PORCENTAJE_FECHA_PAGO = 0,
            FIJA = 1
        }

        public DateTime fechaPago { get; private set; }
        public DateTime fechaDesde { get; private set; }
        public decimal porcentaje { get; private set; }
        public bool CambioFechaPago { get; private set; }
        public bool CambioFechaDesde { get; private set; }

        public TIPO_MODIFICACION_PUNITORIO tipoModificacion { get; private set; }
        private Configuracion oConfig;
        private DataTable dt = new DataTable();
        private decimal ValorViejoPunitorio;
        private decimal ValorNuevoPunitorio;

        public frmCtactePunitorios(DataTable dt)
        {
            InitializeComponent();
            this.dt = dt;
            dt.AcceptChanges();
            FormatearDataGridView();
            oConfig = new Configuracion();
            fechaPago = DateTime.Now;
            porcentaje = oConfig.GetValor_N("Punitorios_Porcentaje");
        }

        private void ComenzarCarga()
        {
            updownPorcentaje.Value = porcentaje;
            dtpFechaPago.Value = fechaPago;
        }

        private void FormatearDataGridView()
        {
            dgv.DataSource = dt;
            this.dgv.ReadOnly = false;
            foreach (DataGridViewColumn col in dgv.Columns)
            {
                col.Visible = false;
                col.ReadOnly = true;
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            dgv.Columns["Servicio"].Visible = true;
            dgv.Columns["Servicio"].Width = 80;
            dgv.Columns["expande"].Visible = true;
            dgv.Columns["expande"].Width = 80;
            dgv.Columns["expande"].HeaderText = "+/-";

            dgv.Columns["elige"].Visible = true;
            dgv.Columns["elige"].Width = 80;
            dgv.Columns["elige"].HeaderText = "Ok";

            dgv.Columns["Fecha_desde"].Visible = true;
            dgv.Columns["Fecha_desde"].HeaderText = "Desde";
            dgv.Columns["Fecha_desde"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgv.Columns["Fecha_Hasta"].Visible = true;
            dgv.Columns["Fecha_Hasta"].HeaderText = "Hasta";
            dgv.Columns["Fecha_Hasta"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgv.Columns["Importe_saldo"].Visible = true;
            dgv.Columns["Importe_saldo"].DefaultCellStyle.Format = "c2";
            dgv.Columns["Importe_saldo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv.Columns["importe_saldo"].HeaderText = "Deuda Original";

            dgv.Columns["Importe_punitorio"].Visible = true;
            dgv.Columns["Importe_punitorio"].DefaultCellStyle.Format = "c2";
            dgv.Columns["Importe_punitorio"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv.Columns["importe_punitorio"].HeaderText = "Punitorio";

            dgv.Columns["Importe_total"].Visible = true;
            dgv.Columns["Importe_total"].DefaultCellStyle.Format = "c2";
            dgv.Columns["Importe_total"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv.Columns["Importe_total"].HeaderText = "Deuda Actualizada";

            dgv.Columns["expande"].Visible = false;
            dgv.Columns["elige"].Visible = false;
            dgv.Columns["importe_punitorio"].ReadOnly = false;

        }

        private void frmCtactePunitorios_Load(object sender, EventArgs e)
        {
            ComenzarCarga();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            fechaPago = dtpFechaPago.Value;
            porcentaje = updownPorcentaje.Value;
            fechaDesde = dtpFechaDesde.Value;

            if (tabControl1.SelectedIndex == 0)
                tipoModificacion = TIPO_MODIFICACION_PUNITORIO.PORCENTAJE_FECHA_PAGO;
            else
                tipoModificacion = TIPO_MODIFICACION_PUNITORIO.FIJA;

            dt.AcceptChanges();
            DialogResult = DialogResult.OK;
        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            dt.RejectChanges();
            this.Close();
        }

        private void frmCtactePunitorios_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                dt.RejectChanges();
                this.Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            dt.RejectChanges();
            this.Close();
        }

        private void dgv_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if ((int)dgv.Rows[e.RowIndex].Cells["encabezado"].Value == 2)
            {
                dgv.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.CornflowerBlue;
            }
            else if ((int)dgv.Rows[e.RowIndex].Cells["encabezado"].Value == 1)
            {
                dgv.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Azure;
            }
            else
            {
                dgv.Rows[e.RowIndex].Visible = false;
            }
        }

        private void dgv_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.ValorNuevoPunitorio = Convert.ToDecimal(dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
                decimal porcentajePunitorioCambiado = ((ValorNuevoPunitorio * 100) / ValorViejoPunitorio);
                ActualizarPunitorios(porcentajePunitorioCambiado, Convert.ToInt32(dgv.Rows[e.RowIndex].Cells["id_comprobantes"].Value));
            }
            catch { }
        }

        private void dgv_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if ((int)dgv.Rows[e.RowIndex].Cells["encabezado"].Value == 2)
                this.ValorViejoPunitorio = Convert.ToDecimal(dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
            else
                e.Cancel = true;
        }

        private void ActualizarPunitorios(decimal porcentaje, int idComprobante)
        {
            foreach (DataGridViewRow row in dgv.Rows)
            {
                if ((int)row.Cells["encabezado"].Value != 2 && Convert.ToInt32(row.Cells["id_comprobantes"].Value) == idComprobante)
                {
                    row.Cells["importe_punitorio"].Value = Math.Round(porcentaje * Convert.ToDecimal(row.Cells["importe_punitorio"].Value) / 100, 2);
                }
            }
        }

        private void cbFechaPago_CheckedChanged(object sender, EventArgs e)
        {
            if (cbFechaPago.Checked)
            {
                dtpFechaPago.Enabled = true;
                CambioFechaPago = true;
            }
            else
            {
                CambioFechaPago = false;
                dtpFechaPago.Enabled = false;
            }
        }

        private void cbInicioCalculo_CheckedChanged(object sender, EventArgs e)
        {
            if (cbInicioCalculo.Checked)
            {
                dtpFechaDesde.Enabled = true;
                CambioFechaDesde = true;
            }
            else
            {
                dtpFechaDesde.Enabled = false;
                CambioFechaDesde = false;
            }
        }
    }
}
