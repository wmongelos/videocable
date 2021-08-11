using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using CapaNegocios;
using CapaPresentacion;

namespace CapaPresentacion.Cuenta_Corriente
{
    public partial class frmActualizaPercepciones : Form
    {
        public frmActualizaPercepciones()
        {
            InitializeComponent();
        }

        #region Metodos

        private Thread hilo;
        private delegate void myDel();
        private DataTable dt;
        Usuarios_CtaCte_Det oUsu_ctacte_det = new Usuarios_CtaCte_Det();
        DataTable dtFinal = new DataTable();

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
                dt = oUsu_ctacte_det.ListarCtaCte_Det_Inconcluencias_Percepciones();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar Informacion" + ex.Message);
            }

        }
        #endregion

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            cargarDatos();
            oUsu_ctacte_det.Actualizar_Provincial_Ctactedet(dt);
            pgCircular.Stop();
            MessageBox.Show("Percepciones de Cuenta Corriente actualizadas correctamente.");
        }
    }
}
