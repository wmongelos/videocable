using CapaNegocios;
using System;
using System.Data;
using System.Windows.Forms;

namespace CapaPresentacion.Herramientas
{
    public partial class frmCargaNroCai : Form
    {
        private DataTable DataComprobantes = new DataTable();
        private Iva_Ventas IvaVentas = new Iva_Ventas();
        public frmCargaNroCai()
        {
            InitializeComponent();
        }

        private void CargarDatos()
        {
            DataComprobantes = IvaVentas.GetComprobantes(Convert.ToInt32(cboPuntosVenta.SelectedValue),
                Convert.ToInt32(CboTipoComprobante.SelectedValue), Convert.ToInt32(TxtNroDesde.Text), Convert.ToInt32(TxtNroHasta.Text));

            DataGrid.DataSource = DataComprobantes;
            DataGrid.Columns["Id"].Visible = false;
            DataGrid.Columns["fecha"].HeaderText = "Fecha";
            DataGrid.Columns["fecha"].Width = 100;
            DataGrid.Columns["numero"].HeaderText = "Número";
            DataGrid.Columns["numero"].Width = 100;
            DataGrid.Columns["numero"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            DataGrid.Columns["punto_venta"].HeaderText = "Pto. Venta";
            DataGrid.Columns["punto_venta"].Width = 100;
            DataGrid.Columns["punto_venta"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            DataGrid.Columns["letra"].HeaderText = "Letra";
            DataGrid.Columns["letra"].Width = 100;
            DataGrid.Columns["letra"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            DataGrid.Columns["razon_social"].HeaderText = "Razón Social";
            DataGrid.Columns["razon_social"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DataGrid.Columns["importe_final"].HeaderText = "Imp. Final";
            DataGrid.Columns["importe_final"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            DataGrid.Columns["importe_final"].DefaultCellStyle.Format = "C2";
            DataGrid.Columns["importe_final"].Width = 100;
            DataGrid.Columns["cae"].HeaderText = "Nro. CAI";
            DataGrid.Columns["cae"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            DataGrid.Columns["cae"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            txtNroCai.Focus();
        }

        private void frmCargaNroCai_Load(object sender, EventArgs e)
        {
            DataView dataView = Tablas.DataPuntosVenta.DefaultView;
            dataView.RowFilter = "Id_Modalidad_Fact < 3";

            cboPuntosVenta.DataSource = dataView.ToTable(true);
            cboPuntosVenta.DisplayMember = "Descripcion";
            cboPuntosVenta.ValueMember = "Numero";

            DataView dataViewTipo = Tablas.DataTipoComprobantes.DefaultView;
            dataViewTipo.RowFilter = "codigo_afip > 0";

            CboTipoComprobante.DataSource = dataViewTipo.ToTable(true);
            CboTipoComprobante.DisplayMember = "Nombre";
            CboTipoComprobante.ValueMember = "Id";
        }

        private void frmCargaNroCai_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (txtNroCai.Text == String.Empty)
                txtNroCai.Focus();
            else {
                if (MessageBox.Show("¿Desea Confirmar la Actualización de Datos?", "Mensaje del Sistema",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (DataComprobantes.Rows.Count > 0)
                    {
                        if(IvaVentas.ActualizarNroCAI(DataComprobantes, txtNroCai.Text.ToString(), DtpVencimiento.Value)) { 
                            MessageBox.Show("Actualización Exitosa");

                            CargarDatos();
                        } 
                        else {
                            MessageBox.Show("Error en la Actualización de Datos");
                        }
                    }  
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
      
    }
}
