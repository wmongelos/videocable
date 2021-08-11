using CapaNegocios;
using System;
using System.Data;
using System.Threading;
using System.Windows.Forms;

namespace CapaPresentacion.Complementarias
{
    public partial class frmCambioMeses : Form
    {
        #region PROPIEDADES
        public int idUsuariosServicios, cantNuevosMesesServicios, cantNuevosMesesCobros;
        private Thread hilo;
        private delegate void myDel();
        private DataTable dtSubServiciosActuales = new DataTable();
        private Usuarios_Servicios oUsuariosServicios = new Usuarios_Servicios();
        #endregion
        #region METODOS

        private void ComenzarCarga()
        {
            hilo = new Thread(new ThreadStart(CargarDatos));
            hilo.Start();
        }
        private void CargarDatos()
        {
            dtSubServiciosActuales = oUsuariosServicios.Traer_datos_usuarios_servicios(idUsuariosServicios);

            myDel MD = new myDel(AsignarDatos);
            this.Invoke(MD, new object[] { });
        }
        private void AsignarDatos()
        {
            dgvSubServiciosActuales.DataSource = dtSubServiciosActuales;
            foreach (DataGridViewColumn item in dgvSubServiciosActuales.Columns)
                item.Visible = false;

            dgvSubServiciosActuales.Columns["servicio"].Visible = true;
            dgvSubServiciosActuales.Columns["servicio"].HeaderText = "Servicio";

            dgvSubServiciosActuales.Columns["meses_cobro"].Visible = true;
            dgvSubServiciosActuales.Columns["meses_cobro"].HeaderText = "Meses de cobro";

            dgvSubServiciosActuales.Columns["meses_servicio"].Visible = true;
            dgvSubServiciosActuales.Columns["meses_servicio"].HeaderText = "Meses de servicio";

            spnCobro.Value = Convert.ToInt32(dgvSubServiciosActuales.Rows[0].Cells["meses_cobro"].Value);
            spnServicio.Value = Convert.ToInt32(dgvSubServiciosActuales.Rows[0].Cells["meses_servicio"].Value);

        }
        #endregion

        public frmCambioMeses()
        {
            InitializeComponent();
        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if ((Convert.ToInt32(dgvSubServiciosActuales.Rows[0].Cells["meses_cobro"].Value) != spnCobro.Value) || (Convert.ToInt32(dgvSubServiciosActuales.Rows[0].Cells["meses_servicio"].Value) != spnServicio.Value))
            {
                this.cantNuevosMesesCobros = Convert.ToInt32(spnCobro.Value);
                this.cantNuevosMesesServicios = Convert.ToInt32(spnServicio.Value);
                this.DialogResult = DialogResult.OK;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void frmCambioMeses_Load(object sender, EventArgs e)
        {
            ComenzarCarga();
        }
    }
}
