using CapaNegocios;
using System;
using System.Data;
using System.Windows.Forms;

namespace CapaPresentacion.Partes_Trabajo
{
    public partial class frmBonificacionesEspeciales : Form
    {
        public int idDescuentoSeleccionado = 0;
        DataView dtvDescuentosEspecialesPorVenta;
        DataTable dtDescuentosEspeciales = new DataTable();
        Bonificaciones oBonificaciones = new Bonificaciones();

        public frmBonificacionesEspeciales(DataTable dtDescuentosEspeciales)
        {
            this.dtDescuentosEspeciales = dtDescuentosEspeciales;
            InitializeComponent();
        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmBonificacionesEspeciales_Load(object sender, EventArgs e)
        {
            dgvDescuentosEspeciales.DataSource = null;
            if (dtDescuentosEspeciales.Rows.Count == 0)
            {
                dtDescuentosEspeciales = oBonificaciones.ListarPorTipo(Convert.ToInt32(Bonificaciones.TIPO_BONIFICACION.ESPECIAL));
                dtvDescuentosEspecialesPorVenta = new DataView(dtDescuentosEspeciales);
                dtvDescuentosEspecialesPorVenta.RowFilter = String.Format("modalidad_venta_pago={0}", Convert.ToInt32(Bonificaciones.MODALIDAD_VENTA_PAGO.VENTA));
                dtDescuentosEspeciales = dtvDescuentosEspecialesPorVenta.ToTable();
            }

            dgvDescuentosEspeciales.DataSource = dtDescuentosEspeciales;
            for (int x = 0; x < dgvDescuentosEspeciales.ColumnCount; x++)
                dgvDescuentosEspeciales.Columns[x].Visible = false;
            dgvDescuentosEspeciales.Columns["nombre"].Visible = true;
            dgvDescuentosEspeciales.Columns["fecha_desde"].Visible = true;
            dgvDescuentosEspeciales.Columns["fecha_hasta"].Visible = true;
            dgvDescuentosEspeciales.Columns["porcentaje"].Visible = true;
            dgvDescuentosEspeciales.Columns["nombre"].HeaderText = "Nombre";
            dgvDescuentosEspeciales.Columns["fecha_desde"].HeaderText = "Válido desde";
            dgvDescuentosEspeciales.Columns["fecha_hasta"].HeaderText = "Válido hasta";
            dgvDescuentosEspeciales.Columns["porcentaje"].HeaderText = "Descuento (%)";
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            if (dgvDescuentosEspeciales.SelectedRows.Count > 0)
            {
                idDescuentoSeleccionado = Convert.ToInt32(dgvDescuentosEspeciales.SelectedRows[0].Cells["id"].Value);
                this.DialogResult = DialogResult.OK;
            }
            else
                MessageBox.Show("Debe seleccionar un descuento.");
        }
    }
}
