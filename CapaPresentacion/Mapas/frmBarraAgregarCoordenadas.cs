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

namespace CapaPresentacion.Mapas
{
    public partial class frmBarraAgregarCoordenadas : Form
    {
        Mapa oMapa = new Mapa();
        DataTable dtLocaciones = new DataTable();
        private bool cancelado = false;
        public frmBarraAgregarCoordenadas(DataTable dt)
        {
            InitializeComponent();
            this.dtLocaciones = dt;
        }

        private void frmBarraAgregarCoordenadas_Load(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync();
        }
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                oMapa.OnPorcentaje += new PorcentajeHandler(Progreso);
                oMapa.AgregarCoord(dtLocaciones);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage > 100 ? 100 : e.ProgressPercentage;
            lblPorcentaje.Text = $"{e.ProgressPercentage} %";
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (cancelado)
            {
                cancelado = false;
                return;
            }

            if (e.Error != null)
            {
                MessageBox.Show("Hubo un error en la carga de coordenadas", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Las coordenadas se actualizaron correctamente", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
            frmAgregarCoordenadas oForm = frmAgregarCoordenadas.Instance();
            oForm.Comenzar();

        }
        private void Progreso(int porcentaje)
        {
            backgroundWorker1.ReportProgress(porcentaje);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            cancelado = true;
            if (backgroundWorker1.IsBusy)
            {
                oMapa.CancelarCargaDeCoordenadas();
            }

            MessageBox.Show("Cancelado correctamente", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }


    }
}
