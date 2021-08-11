using CapaNegocios;
using System;
using System.Data;
using System.Windows.Forms;

namespace CapaPresentacion.Partes_Trabajo
{
    public partial class frmConsultaPartesInfraestructura : Form
    {
        private DataTable dtPartes = new DataTable();

        public frmConsultaPartesInfraestructura()
        {
            InitializeComponent();
            dtpDesde.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpHasta.Value = DateTime.Now;
        }

        private void TraerPartes()
        {
            dtPartes = new Partes_Informes().ListarPartesInfraestructura(dtpDesde.Value, dtpHasta.Value, SeleccionTipoFecha());
            dgv.DataSource = dtPartes;
            if(dgv.Rows.Count > 0)
                lblDetalle.Text = $"Detalle: {dgv.SelectedRows[0].Cells["descripcion_falla"].Value}";
            formatearDGV();
            lblTotal.Text = $"Total de Registros: {dgv.Rows.Count}";
        }

        private void formatearDGV()
        {
            foreach (DataGridViewColumn col in dgv.Columns)
                col.Visible = false;

            dgv.Columns["servicio_grupo"].Visible = true;
            dgv.Columns["servicio_tipo"].Visible = true;
            dgv.Columns["fecha_reclamo"].Visible = true;
            dgv.Columns["fecha_programado"].Visible = true;
            dgv.Columns["fecha_realizado"].Visible = true;
            dgv.Columns["parte_estado"].Visible = true;
            dgv.Columns["personal"].Visible = true;
            dgv.Columns["area"].Visible = true;
            dgv.Columns["localidad"].Visible = true;
            dgv.Columns["calle"].Visible = true;
            dgv.Columns["altura"].Visible = true;

            dgv.Columns["servicio_grupo"].HeaderText = "Grupo";
            dgv.Columns["servicio_tipo"].HeaderText = "Tipo";
            dgv.Columns["fecha_reclamo"].HeaderText = "Fecha reclamo";
            dgv.Columns["fecha_programado"].HeaderText = "Fecha programado";
            dgv.Columns["fecha_realizado"].HeaderText = "Fecha realizado";
            dgv.Columns["parte_estado"].HeaderText = "Estado";
            dgv.Columns["personal"].HeaderText = "Personal";
            dgv.Columns["area"].HeaderText = "Area";
            dgv.Columns["localidad"].HeaderText = "Localidad";
            dgv.Columns["calle"].HeaderText = "Calle";
            dgv.Columns["altura"].HeaderText = "Altura";

            dgv.Columns["servicio_grupo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgv.Columns["servicio_tipo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgv.Columns["fecha_reclamo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgv.Columns["fecha_programado"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgv.Columns["fecha_realizado"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgv.Columns["parte_estado"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgv.Columns["personal"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns["area"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns["localidad"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgv.Columns["calle"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgv.Columns["altura"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }

        private int SeleccionTipoFecha()
        {
            if (rbReclamo.Checked) return 0;
            else if (rbProgramado.Checked) return 1;
            else return 3;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            TraerPartes();
            this.Cursor = Cursors.Default;
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            if (dgv.Rows.Count > 0)
            {
                this.Cursor = Cursors.WaitCursor;
                try
                {
                    Tools tools = new Tools();
                    tools.ExportDataTableToExcel(dtPartes, "Partes de infraestructura");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    this.Cursor = Cursors.Default;
                }
                MessageBox.Show("Datos exportados correctamente", "Mensaje del sistema");
            }
            else
            {
                MessageBox.Show("No hay Registros para Exportar", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dgv_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if(dgv.Rows.Count > 0 && dgv.SelectedRows.Count > 0)
            {
                lblDetalle.Text = $"Detalle: {dgv.SelectedRows[0].Cells["descripcion_falla"].Value}";
            }
        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmConsultaPartesInfraestructura_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
    }
}
