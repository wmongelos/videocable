using CapaNegocios;
using System;
using System.Data;
using System.Threading;
using System.Windows.Forms;


namespace CapaPresentacion.Contabilidad
{
    public partial class frmReciboDetalle : Form
    {
        #region propiedades
        private Thread hilo;
        private delegate void myDel();
        public int idRecibo, idCtacte, idComprobante;
        private Usuarios_CtaCte_Recibos oRecibo = new Usuarios_CtaCte_Recibos();

        private DataTable dtReciboDet = new DataTable();

        #endregion
        #region metodos
        private void comenzarCarga()
        {
            hilo = new Thread(new ThreadStart(cargarDatos));
            hilo.IsBackground = true;
            hilo.Start();
        }
        private void cargarDatos()
        {
            try
            {
                dtReciboDet = oRecibo.ListarDetallesCtaCteDet(idComprobante);
                myDel MD = new myDel(asignarDatos);
                this.Invoke(MD, new object[] { });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar Informacion" + ex.Message);
                throw;
            }
        }
        private void asignarDatos()
        {
            dgvDetalles.DataSource = dtReciboDet;
            foreach (DataGridViewColumn item in dgvDetalles.Columns)
                item.Visible = false;
            dgvDetalles.Columns["importe_imputa"].Visible = true;
            dgvDetalles.Columns["importe_imputa"].HeaderText = "Importe";
            dgvDetalles.Columns["importe_imputa"].DefaultCellStyle.Format = "c";
            dgvDetalles.Columns["importe_imputa"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvDetalles.Columns["importe_imputa"].DisplayIndex = 1;
            dgvDetalles.Columns["sub_servicio"].DisplayIndex = 0;
            dgvDetalles.Columns["sub_servicio"].Visible = true;
            dgvDetalles.Columns["sub_servicio"].HeaderText = "Subservicio";
        }

        #endregion
        public frmReciboDetalle()
        {
            InitializeComponent();
        }

        private void frmReciboDetalle_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmReciboDetalle_Load(object sender, EventArgs e)
        {
            comenzarCarga();
        }
    }
}
