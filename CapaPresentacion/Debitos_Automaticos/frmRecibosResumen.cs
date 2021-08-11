using CapaNegocios;
using System;
using System.Data;
using System.Threading;
using System.Windows.Forms;

namespace CapaPresentacion.Debitos_Automaticos
{
    public partial class frmRecibosResumen : Form
    {
        #region PROPIEDADES
        private Thread hilo;
        private delegate void myDel();
        private DataTable dtRecibos = new DataTable();
        private Usuarios_CtaCte_Recibos oRecibos = new Usuarios_CtaCte_Recibos();
        private Presentacion_Debitos oPresentacionDeb = new Presentacion_Debitos();
        private DataTable dtUltimasPresentaciones = new DataTable();
        private int idPresentacion;
        #endregion

        #region METODOS
        private void ComenzarCarga()
        {
            hilo = new Thread(new ThreadStart(CargarDatos));
            hilo.IsBackground = true;
            hilo.Start();
        }

        private void CargarDatos()
        {
            try
            {
                dtUltimasPresentaciones = oPresentacionDeb.ListarUltimasPresentacion();
                idPresentacion = Convert.ToInt32(dtUltimasPresentaciones.Rows[0]["id"]);
                dtRecibos = oRecibos.ListarRecibosPresentacionDeb(idPresentacion);
                myDel MD = new myDel(AsignarDatos);
                this.Invoke(MD, new object[] { });
            }
            catch
            {
                //throw;
                MessageBox.Show("Error al cargar información.");
            }
        }

        private void AsignarDatos()
        {
            cboPeriodos.DataSource = dtUltimasPresentaciones;
            cboPeriodos.DisplayMember = "periodo";
            cboPeriodos.ValueMember = "id";
            cboPeriodos.SelectedValue = Convert.ToInt32(dtUltimasPresentaciones.Rows[0]["id"]);

            dgvRecibos.DataSource = dtRecibos;

            foreach (DataGridViewColumn item in dgvRecibos.Columns)
                item.Visible = false;


            dgvRecibos.Columns["cont"].Visible = true;
            dgvRecibos.Columns["cont"].HeaderText = "Cantidad de recibos";
            dgvRecibos.Columns["cont"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvRecibos.Columns["cont"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvRecibos.Columns["importe_total"].Visible = true;
            dgvRecibos.Columns["importe_total"].HeaderText = "Importe total";
            dgvRecibos.Columns["importe_total"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvRecibos.Columns["importe_total"].DefaultCellStyle.Format = "c";
            dgvRecibos.Columns["menor"].Visible = true;
            dgvRecibos.Columns["menor"].HeaderText = "Desde";
            dgvRecibos.Columns["mayor"].Visible = true;
            dgvRecibos.Columns["mayor"].HeaderText = "Hasta";


        }
        #endregion
        public frmRecibosResumen()
        {
            InitializeComponent();
        }

        private void btnGenerarRecibo_Click(object sender, EventArgs e)
        {
            try
            {
                idPresentacion = Convert.ToInt32(dtUltimasPresentaciones.Rows[0]["id"]);
                dtRecibos = oRecibos.ListarRecibosPresentacionDeb(idPresentacion);
                AsignarDatos();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void frmRecibosResumen_Load(object sender, EventArgs e)
        {
            ComenzarCarga();
        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmRecibosResumen_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            Impresiones.Impresion oImpresion = new Impresiones.Impresion();
            oImpresion.ImprimirRecibosDeb(dtRecibos);
        }
    }
}
