using CapaNegocios;
using System;
using System.Data;
using System.Threading;
using System.Windows.Forms;
namespace CapaPresentacion.Contabilidad
{
    public partial class frmInformesContables : Form
    {
        int idTipoInforme;
        string fechaDesde, fechaHasta;
        private Informes_Contables oInformesContables = new Informes_Contables();
        private Thread hilo;
        private delegate void myDel();
        private DataTable dtDatos = new DataTable();
        private Tools oTools = new Tools();


        private void ComenzarCarga()
        {
            idTipoInforme = Convert.ToInt16(Informes_Contables.TIPO_INFORME.LIBROIVAA);
            fechaDesde = dtpFechaDesdeLibroIvaA.Value.ToString("yyyy-MM-dd");
            fechaHasta = dtpFechaHastaLibroIvaA.Value.ToString("yyyy-MM-dd");
            pgCircular.Start();
            hilo = new Thread(new ThreadStart(CargarDatos));
            hilo.Start();
        }

        private void CargarDatos()
        {
            dtDatos = oInformesContables.ListarDatosInforme(idTipoInforme, fechaDesde, fechaHasta);
            myDel MD = new myDel(AsignarDatos);
            this.Invoke(MD, new object[] { });
            pgCircular.Stop();
        }

        private void AsignarDatos()
        {
            decimal neto = 0, iva = 0;
            if (dtDatos.Rows.Count > 0)
            {
                neto = Convert.ToDecimal(dtDatos.Compute("Sum(importe_neto)", string.Empty));
                iva = Convert.ToDecimal(dtDatos.Compute("Sum(importe_iva)", string.Empty));
            }
            dgvLibroIvaA.DataSource = dtDatos;
            dgvLibroIvaA.Columns["fecha"].HeaderText = "Fecha";
            dgvLibroIvaA.Columns["descripcion_comprobante"].HeaderText = "Comprobantes";
            dgvLibroIvaA.Columns["apellido"].HeaderText = "Titular";
            dgvLibroIvaA.Columns["usuario_nombre"].HeaderText = "";
            dgvLibroIvaA.Columns["descripcion"].HeaderText = "Cond. IVA";
            dgvLibroIvaA.Columns["cuit"].HeaderText = "CUIT";
            dgvLibroIvaA.Columns["importe_neto"].HeaderText = "Neto";
            dgvLibroIvaA.Columns["importe_iva"].HeaderText = "IVA";
            dgvLibroIvaA.Columns["total"].HeaderText = "Total";

            dgvLibroIvaA.Columns["importe_neto"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvLibroIvaA.Columns["importe_iva"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvLibroIvaA.Columns["total"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            lblTotalesLibroIvaA.Text = String.Format("Total neto:${0}  Total iva:${1}  Total:${2}", neto, iva, neto + iva);
        }

        private void Buscar()
        {

            if (gestorTabs.SelectedTab.Name == "infLibroIvaA")
            {
                dtDatos = oInformesContables.ListarDatosInforme(Convert.ToInt16(Informes_Contables.TIPO_INFORME.LIBROIVAA), dtpFechaDesdeLibroIvaA.Value.ToString("yyyy-MM-dd"), dtpFechaHastaLibroIvaA.Value.ToString("yyyy-MM-dd"));
            }
        }

        private void Exportar()
        {
            oTools.ExportToExcel(dgvLibroIvaA, "Libro de IVA facturas A");
        }
        public frmInformesContables()
        {
            InitializeComponent();
        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            ComenzarCarga();
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            Exportar();
        }

        private void infLibroIvaA_Click(object sender, EventArgs e)
        {

        }
    }
}//04112019fede
