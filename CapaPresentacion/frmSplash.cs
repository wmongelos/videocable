using CapaNegocios;
using System;
using System.Threading;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class frmSplash : Form
    {
        private Thread hilo;
        private delegate void myDel();

        public frmSplash()
        {
            InitializeComponent();
        }

        private void comenzarCarga()
        {
            pgCircular.Start();
            hilo = new Thread(new ThreadStart(cargarDatos));
            hilo.Start();
        }

        private void cargarDatos()
        {
            try
            {
                Configuracion oConfig = new Configuracion();
                oConfig.LoadConfiguracion();
                Tablas.LoadData();
                
                Tablas.LoadImpresiones();

                myDel MD = new myDel(finishSplash);
                this.Invoke(MD, new object[] { });
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void finishSplash()
        {
            pgCircular.Stop();

            this.DialogResult = DialogResult.OK;
        }

        private void frmSplash_Load(object sender, EventArgs e)
        {
            this.comenzarCarga();
        }
    }
}
