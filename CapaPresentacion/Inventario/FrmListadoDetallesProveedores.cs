using CapaNegocios;
using System;
using System.Data;
using System.Windows.Forms;


namespace CapaPresentacion.Inventario
{
    public partial class FrmListadoDetallesProveedores : Form
    {

        public Proveedores oProveedores = new Proveedores();
        public Comprobantes_Compras_Det oDetallesComprasProveedores = new Comprobantes_Compras_Det();
        public Comprobantes_Compras_Det oComprobanteCompra = new Comprobantes_Compras_Det();
        private DataTable dtListadoProveedores, dtComprobanteCompra;

        public FrmListadoDetallesProveedores()
        {
            InitializeComponent();
        }

        private void ComenzarCarga()
        {
            CargarDatos();
        }

        private void CargarDatos()
        {
            cboProveedores.DataSource = oProveedores.Listar();
            AsignarDatos();
        }

        private void AsignarDatos()
        {


            dgvComprobantes.DataSource = dtComprobanteCompra;
            for (int x = 0; x < dgvComprobantes.ColumnCount; x++)
                dgvComprobantes.Columns[x].Visible = true;

            dtpHasta.Value = DateTime.Now;
            dtpDesde.Value = DateTime.Now.AddDays(-30);
            cboProveedores.Enabled = true;
            cboProveedores.ValueMember = "Id";
            cboProveedores.DisplayMember = "Razon_Social";
            OcultarControles();
        }

        private void asignarDatosDetalles()
        {
            dgvDetalleProveedores.DataSource = dtListadoProveedores;
            for (int j = 0; j < dgvDetalleProveedores.ColumnCount; j++)
                dgvDetalleProveedores.Columns[j].Visible = true;

        }


        private void OcultarCeldaID()
        {
            dgvComprobantes.Columns["id"].Visible = false;
        }

        private void MostrarControles()
        {
            cntDetallesCompras.Visible = true;
        }

        private void OcultarControles()
        {
            cntDetallesCompras.Visible = false;
        }


        private void ModificarGrillaComprobantes()
        {
            dgvComprobantes.Columns["numero_remito"].HeaderText = "Numero Remito";
            dgvComprobantes.Columns["numero_remito"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }


        private void ModificacionesGrillaDetalle()
        {
            dgvDetalleProveedores.Visible = true;

            dgvDetalleProveedores.Columns["producto"].HeaderText = "Producto";
            dgvDetalleProveedores.Columns["fecha"].HeaderText = "Fecha y Hora de la Compra";
            dgvDetalleProveedores.Columns["fecha"].Visible = false;
            dgvDetalleProveedores.Columns["importe"].HeaderText = "Precio";
            dgvDetalleProveedores.Columns["importe"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvDetalleProveedores.Columns["importe"].DefaultCellStyle.Format = "c2";
            dgvDetalleProveedores.Columns["cantidad"].HeaderText = "Cantidad";
            dgvDetalleProveedores.Columns["cantidad"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvDetalleProveedores.Columns["id"].Visible = false;
            dgvDetalleProveedores.Columns["id_tipo"].Visible = false;
            dgvDetalleProveedores.Columns["total"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvDetalleProveedores.Columns["total"].DefaultCellStyle.Format = "c2";


        }

        private void FrmListadoDetallesProveedores_Load(object sender, EventArgs e)
        {
            ComenzarCarga();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

            //dtListadoProveedores = oDetallesComprasProveedores.ListarDetalleComprobanteCompra(dtpDesde.Value, dtpHasta.Value, Convert.ToInt32(cboProveedores.SelectedValue));
            dtComprobanteCompra = oComprobanteCompra.ComprobantesComprasDetalle(dtpDesde.Value, dtpHasta.Value, Convert.ToInt32(cboProveedores.SelectedValue));
            AsignarDatos();
            MostrarControles();
            OcultarCeldaID();
            ModificarGrillaComprobantes();
        }

        private void dgvComprobantes_SelectionChanged(object sender, EventArgs e)
        {
            Int32 id_Comprobante;
            if (dgvComprobantes.Rows[0].Cells["id"].Value != null)
            {
                id_Comprobante = Convert.ToInt32(dgvComprobantes.SelectedRows[0].Cells["id"].Value.ToString());
                dtListadoProveedores = oDetallesComprasProveedores.ListarDetalleComprobanteCompra(dtpDesde.Value, dtpHasta.Value, Convert.ToInt32(cboProveedores.SelectedValue), id_Comprobante);
                asignarDatosDetalles();
                ModificacionesGrillaDetalle();
            }
        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
