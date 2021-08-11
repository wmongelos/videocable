using CapaNegocios;
using System;
using System.Data;
using System.Threading;
using System.Windows.Forms;

namespace CapaPresentacion.Busquedas
{
    public partial class frmBusquedaVelocidad : Form
    {
        #region declaraciones
        private Thread hilo;
        private delegate void myDel();
        private DataTable dtVelocidades = new DataTable();
        private Servicios_Velocidades oVelocidades = new Servicios_Velocidades();
        #endregion

        #region METODOS
        public frmBusquedaVelocidad()
        {
            InitializeComponent();
        }

        private void ComenzarCarga()
        {
            pgCircular.Start();
            dgvVelocidades.DataSource = null;
            hilo = new Thread(new ThreadStart(CargarDatos));
            hilo.Start();
        }

        private void CargarDatos()
        {
            try
            {
                dtVelocidades = oVelocidades.ListarVelocidadesRelacion();
            }
            catch (Exception c)
            {
                MessageBox.Show("Error al cargar las velocidades." + c.Message, "Mensjae del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void AsignarDatos()
        {

        }

        #endregion
        private void frmBusquedaVelocidad_Load(object sender, EventArgs e)
        {

        }

        private void frmBusquedaVelocidad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
    }
}
