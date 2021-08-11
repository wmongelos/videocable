using CapaNegocios;
using System;
using System.Data;
using System.Threading;
using System.Windows.Forms;

namespace CapaPresentacion.Herramientas
{
    public partial class frmSeleccionPuntoVirtual : Form
    {
        #region PROPIEDADES
        private Thread hilo;
        private delegate void myDel();
        private Puntos_Cobros oPuntosCobros = new Puntos_Cobros();
        private DataTable dtPuntos;
        public int idPuntoCobro;
        public string descripcionPuntoCobro;
        #endregion

        #region Metodos

        private void comenzarCarga()
        {

            hilo = new Thread(new ThreadStart(cargarDatos));
            hilo.Start();
        }

        private void cargarDatos()
        {
            try
            {
                dtPuntos = oPuntosCobros.ListarPorTipoSucursal("VIRTUAL");
                myDel MD = new myDel(asignarDatos);
                this.Invoke(MD, new object[] { });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar Informacion" + ex.Message);
            }
        }

        private void asignarDatos()
        {
            cboPuntos.DataSource = dtPuntos;
            cboPuntos.DisplayMember = "descripcion";
            cboPuntos.ValueMember = "id";
            cboPuntos.SelectedIndex = 0;
        }

        #endregion
        public frmSeleccionPuntoVirtual()
        {
            InitializeComponent();
        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void frmSeleccionPuntoVirtual_Load(object sender, EventArgs e)
        {
            comenzarCarga();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.idPuntoCobro = Convert.ToInt32(cboPuntos.SelectedValue);
            descripcionPuntoCobro = cboPuntos.Text;
            this.DialogResult = DialogResult.OK;
        }
    }
}
