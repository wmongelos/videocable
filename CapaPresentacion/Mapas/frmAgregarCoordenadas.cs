using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocios.Mapas;
using CapaPresentacion;

namespace CapaPresentacion.Mapas
{
    public partial class frmAgregarCoordenadas : Form
    {
        Mapa oMapa = new Mapa();
        DataTable dtLocaciones = new DataTable();
        
        public frmAgregarCoordenadas()
        {
            InitializeComponent();
        }

        private static frmAgregarCoordenadas aForm = null;

        public static frmAgregarCoordenadas Instance()
        {
            if (aForm == null)
                aForm = new frmAgregarCoordenadas();

            return aForm;
        }

        public void Comenzar()
        {
            dtLocaciones = oMapa.TablaLocaciones();
            dgvLocaciones.DataSource = dtLocaciones;
        }

        private void frmAgregarCoordenadas_Load(object sender, EventArgs e)
        {
            Comenzar();
        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAgregarCoord_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea iniciar la carga de coordenadas?\n Este proceso puede tardar mucho tiempo", "Mensaje del sistema", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                Mapas.frmBarraAgregarCoordenadas oFormulario = new Mapas.frmBarraAgregarCoordenadas(dtLocaciones);
                oFormulario.ShowDialog();
            }
        }
    }
}
