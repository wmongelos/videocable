using CapaNegocios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CapaPresentacion.Informes
{
    public partial class frmConsultaPeriodosPagos : Form
    {
        private DataTable dtResultado = new DataTable();

        public frmConsultaPeriodosPagos()
        {
            InitializeComponent();
        }

        private void frmConsultaPeriodosPagos_Load(object sender, EventArgs e)
        {
            dtpPagoDesde.Value = DateTime.Now;
            dtpPagoHasta.Value = DateTime.Now;
            dtpFacturadoHasta.Value = DateTime.Now;

            DataTable dtSubServicios = new Servicios_Sub()
                                        .Listar()
                                        .Select($"Id_Servicios_Sub_Tipos = {Convert.ToInt32(Servicios_Sub.SERVICIO_SUB_TIPOS.SUBSERVICIO)}")
                                        .CopyToDataTable();
        }

        private void ConsultarUsuarios()
        {
            if(dtpPagoDesde.Value.Date < dtpPagoHasta.Value.Date && 
               dtpPagoHasta.Value.Date < dtpFacturadoHasta.Value.Date)
            {
                dtResultado = new Usuarios_CtaCte_Recibos().ListarUsuariosConPeriodosFacturadosDesde(dtpPagoDesde.Value, dtpPagoHasta.Value, dtpFacturadoHasta.Value);
                dgv.DataSource = dtResultado;

                foreach (DataGridViewColumn col in dgv.Columns)
                    col.Visible = false;

                dgv.Columns["codigo"].HeaderText = "Codigo";
                dgv.Columns["codigo"].Visible = true;
                dgv.Columns["locacion"].HeaderText = "Locacion";
                dgv.Columns["locacion"].Visible = true;

                lblTotal.Text = $"Total de registros: {dgv.Rows.Count}";
            }
            else
            {
                MessageBox.Show("Error, las fechas son incopatibles, la fecha del pago 'hasta' debe ser mayor a la fecha del pago 'desde'", "Mensaje del sistema");
                return;
            }
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            ConsultarUsuarios();
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            if (dgv.Rows.Count > 0)
            {
                Tools tools = new Tools();
                try
                {
                    tools.ExportDataTableToExcel(dtResultado.DefaultView.ToTable(false, "codigo"), "informe", this);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error el exportar a excel: {ex.Message}");
                }
            }
        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmConsultaPeriodosPagos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
    }
}
