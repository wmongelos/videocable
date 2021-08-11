using System;
using System.Windows.Forms;

namespace CapaPresentacion.Complementarias
{
    public partial class frmUnidadesFuncionales : Form
    {
        //INT 
        private int cantidadBocasActuales, cantidadBocasPactadasActuales;
        public int cantidadBocasPactadasP, cantidadBocasComunesP;
        //DECIMAL
        private decimal Tarifa = 0, TarifaX;

        private void btnAceptar_Click(object sender, EventArgs e)
        {


            cantidadBocasPactadasP = (Convert.ToInt32(spnBocasPactadas.Value) - cantidadBocasPactadasActuales);
            cantidadBocasComunesP = (Convert.ToInt32(spnBocas.Value) - cantidadBocasActuales);
            //      if (cantidadBocasPactadasP > cantidadBocasComunesP)
            if (Convert.ToInt32(spnBocasPactadas.Value) > Convert.ToInt32(spnBocas.Value))
            {
                MessageBox.Show("La cantidad de bocas pactadas no puede ser mayor a la cantidad de bocas comunes.", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                spnBocasPactadas.Focus();
            }
            else
                DialogResult = DialogResult.OK;
        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void spnBocasPactadas_ValueChanged(object sender, EventArgs e)
        {
            TarifaX = (Tarifa * spnBocasPactadas.Value);
            lblImporte2.Text = TarifaX.ToString("C");
        }

        private void frmUnidades_Funcionales_Load(object sender, EventArgs e)
        {
            lblBocasActuales.Text = cantidadBocasActuales.ToString();
            lblBocasPacActuales.Text = cantidadBocasPactadasActuales.ToString();
            spnBocas.Value = cantidadBocasActuales;
            spnBocasPactadas.Value = cantidadBocasPactadasActuales;
            lblImporte2.Text = (Tarifa * cantidadBocasPactadasActuales).ToString("C");
        }

        public frmUnidadesFuncionales(int Cant_bocas, int Cant_bocas_pac, decimal Tarifa)
        {
            InitializeComponent();
            this.cantidadBocasActuales = Cant_bocas;
            this.cantidadBocasPactadasActuales = Cant_bocas_pac;
            this.Tarifa = Tarifa;

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmUnidades_Funcionales_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
    }
}
