using CapaNegocios;
using System;
using System.Data;
using System.Globalization;
using System.Windows.Forms;

namespace CapaPresentacion.Informes
{
    public partial class frmPagosAdelantados : Form
    {
        private DataTable dtPagosAdelantados;
        private string filtroPresentacion;
        private string filtroCuenta;
        private string filtroTipoServicio;

        public frmPagosAdelantados()
        {
            InitializeComponent();
        }

        private void frmPagosAdelantados_Load(object sender, EventArgs e)
        {
            var dtTipoServ = Tablas.DataServicios_Tipos.Copy();

            dtTipoServ.Rows.Add(0, "TODOS", "", 0, 0);

            cboTipoServicio.DataSource = dtTipoServ; 
            cboTipoServicio.DisplayMember = "nombre";
            cboTipoServicio.ValueMember = "id";
            cboTipoServicio.SelectedValue = 0;
            cboTipoServicio.SelectedValueChanged += cboTipoServicio_SelectedValueChanged;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            rbTodasCuenta.Checked = true;
            rbTodosUniverso.Checked = true;
            DateTime desde = new DateTime(dtpFecha.Value.Year, dtpFecha.Value.Month, 1).Date;
            DateTime hasta = new DateTime(dtpFecha.Value.Year, dtpFecha.Value.Month, DateTime.DaysInMonth(dtpFecha.Value.Year, dtpFecha.Value.Month)).Date;
            this.Cursor = Cursors.WaitCursor;
            dtPagosAdelantados = new Usuarios_CtaCte_Recibos().ListarPagosAdelantados(desde, hasta, Convert.ToInt32(cboTipoServicio.SelectedValue));
            dgv.DataSource = dtPagosAdelantados;
            formatearDataGridView();
            this.Cursor = Cursors.Default;
            lblTotal.Text = $"Total de registros: {dtPagosAdelantados.Rows.Count}";
            decimal importeTotal;
            if (dtPagosAdelantados.Rows.Count > 0)
                importeTotal = Convert.ToDecimal(dtPagosAdelantados.Compute("sum(importe_recibo)", "importe_recibo <> 0"));
            else
                importeTotal = 0;
            lblImporteTotal.Text = $"Total: {importeTotal.ToString(CultureInfo.CreateSpecificCulture("es-AR"))}";
            gbCuenta.Enabled = true;
            gbPresentacion.Enabled = true;
        }

        private void formatearDataGridView()
        {
            foreach (DataGridViewColumn col in dgv.Columns)
            {
                col.Visible = false;
            }

            dgv.Columns["codigo"].Visible = true;
            dgv.Columns["codigo"].HeaderText = "Codigo";

            dgv.Columns["usuario"].Visible = true;
            dgv.Columns["usuario"].HeaderText = "Nombre usuario";
            dgv.Columns["usuario"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            dgv.Columns["locacion"].Visible = true;
            dgv.Columns["locacion"].HeaderText = "Locacion";
            dgv.Columns["locacion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            dgv.Columns["fecha_pago"].Visible = true;
            dgv.Columns["fecha_pago"].HeaderText = "Fecha pago";

            dgv.Columns["fecha_desde"].Visible = true;
            dgv.Columns["fecha_desde"].HeaderText = "Fecha desde";

            dgv.Columns["servicio_grupo"].Visible = true;
            dgv.Columns["servicio_grupo"].HeaderText = "Servicio grupo";

            dgv.Columns["servicio_tipo"].Visible = true;
            dgv.Columns["servicio_tipo"].HeaderText = "Servicio tipo";

            dgv.Columns["servicio"].Visible = true;
            dgv.Columns["servicio"].HeaderText = "Servicio";

            dgv.Columns["importe_recibo"].Visible = true;
            dgv.Columns["importe_recibo"].HeaderText = "Importe";
            dgv.Columns["importe_recibo"].DefaultCellStyle.Format = "C2";
            dgv.Columns["importe_recibo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        private void rbPresentacion_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            if (rb.Checked)
            {
                if(rb.Name == rbTodosUniverso.Name)
                {
                    filtroPresentacion = "";
                }
                else if(rb.Name == rbUniverso.Name)
                {
                    filtroPresentacion = "presentacion = 1";
                }
                else if(rb.Name == rbEspeciales.Name)
                {
                    filtroPresentacion = "presentacion = 0";
                }
                armarFiltro();
            }
        }

        private void rbCuenta_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            if (rb.Checked)
            {
                if (rb.Name == rbTodasCuenta.Name)
                {
                    filtroCuenta = "";
                }
                else if (rb.Name == rbCuenta1.Name)
                {
                    filtroCuenta = $"cuenta = {Convert.ToInt32(Usuarios_CtaCte_Recibos.CAJAS.BLANCO)}";
                }
                else if (rb.Name == rbCuenta2.Name)
                {
                    filtroCuenta = $"cuenta = {Convert.ToInt32(Usuarios_CtaCte_Recibos.CAJAS.NEGRO)}";
                }
                armarFiltro();
            }
        }

        private void armarFiltro()
        {
            string filtroFinal;
            if (String.IsNullOrEmpty(filtroPresentacion) && String.IsNullOrEmpty(filtroCuenta))
            {
                filtroFinal = "";
            }
            else if(String.IsNullOrEmpty(filtroPresentacion))
            {
                filtroFinal = filtroCuenta;
            }
            else if(String.IsNullOrEmpty(filtroCuenta))
            {
                filtroFinal = filtroPresentacion;
            }
            else
            {
                filtroFinal = $"{filtroCuenta} and {filtroPresentacion}";
            }

            if(Convert.ToInt32(cboTipoServicio.SelectedValue) > 0)
            {
                if (String.IsNullOrEmpty(filtroFinal))
                {
                    filtroFinal = filtroTipoServicio;
                }
                else
                {
                    filtroFinal = $"{filtroFinal} AND {filtroTipoServicio}";
                }
            }
            dtPagosAdelantados.DefaultView.RowFilter = filtroFinal;
            lblTotal.Text = $"Total de registros: {dtPagosAdelantados.DefaultView.ToTable().Rows.Count}";
            decimal importeTotal;
            if (dtPagosAdelantados.DefaultView.ToTable().Rows.Count > 0)
                importeTotal = Convert.ToDecimal(dtPagosAdelantados.DefaultView.ToTable().Compute("sum(importe_recibo)", "importe_recibo <> 0"));
            else
                importeTotal = 0;
            lblImporteTotal.Text = $"Total: {importeTotal.ToString(CultureInfo.CreateSpecificCulture("es-AR"))}";
        }

        private void cboTipoServicio_SelectedValueChanged(object sender, EventArgs e)
        {
            if(Convert.ToInt32(cboTipoServicio.SelectedValue) == 0)
            {
                filtroTipoServicio = "";
            }
            else
            {
                filtroTipoServicio = $"id_servicio_tipo = {Convert.ToInt32(cboTipoServicio.SelectedValue)}";
            }
            armarFiltro();
        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmPagosAdelantados_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            if(dgv.Rows.Count > 0)
            {
                Tools tools = new Tools();
                try
                {
                    tools.ExportDataTableToExcel(dtPagosAdelantados.DefaultView.ToTable(), "informe", this);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error el exportar a excel: {ex.Message}");
                }
            }
        }

        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            frmPopUp popUp = new frmPopUp();
            popUp.Formulario = new frmUsuariosCtaCteConsultaNuevo(Convert.ToInt32(dgv.SelectedRows[0].Cells["Id_Usuario"].Value.ToString()), Convert.ToInt32(dgv.SelectedRows[0].Cells["Id_Locacion"].Value.ToString()));
            popUp.Maximizar = true;
            popUp.ShowDialog();
        }
    }
}
