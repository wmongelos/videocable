using CapaNegocios;
using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class frmActualizarSaldosYPunitorios : Form
    {
        public enum TIPO
        {
            SALDO_PUNITORIO = 0,
            SALDO_LOCACION = 1
        }

        private DataTable dtCtaCteDet = new DataTable();
        private bool elProcesoFueCancelado = false;
        private Punitorio oPuni = new Punitorio();
        private Usuarios_Saldos_Locacion oUsuSaldoLoc = new Usuarios_Saldos_Locacion();
        private TIPO tipo;
        private bool hacerAutomatico;

        public frmActualizarSaldosYPunitorios(TIPO tipo, bool hacerAutomatico = false)
        {
            this.hacerAutomatico = hacerAutomatico;
            this.tipo = tipo;

            InitializeComponent();
        }

        private void frmActualizarSaldosYPunitorios_Load(object sender, EventArgs e)
        {
            if (tipo == TIPO.SALDO_PUNITORIO)
                lblTituloHeader.Text = "Actualizacion de punitorios";
            else if (tipo == TIPO.SALDO_LOCACION)
                lblTituloHeader.Text = "Actualizacion de saldo de locaciones";
            backgroundWorker1.DoWork += Tarea;
            backgroundWorker1.RunWorkerCompleted += ProcesoFinalizado;
            backgroundWorker1.ProgressChanged += ActualizarBarra;

            if (hacerAutomatico)
            {
                PrepararDatos();
                Iniciar();
            }
        }

        private void Tarea(object sender, DoWorkEventArgs e)
        {
            if(dtCtaCteDet.Rows.Count > 0)
            {
                if(tipo == TIPO.SALDO_PUNITORIO)
                {
                    oPuni.OnPorcentaje += new PorcentajeHandler(Progreso);
                    oPuni.ActualizarPunitorios(dtCtaCteDet);
                }
                else if (tipo == TIPO.SALDO_LOCACION)
                {
                    oUsuSaldoLoc.OnPorcentaje += new PorcentajeHandler(Progreso);
                    oUsuSaldoLoc.ActualizarSaldos(dtCtaCteDet);
                }
            }
        }

        private void Iniciar()
        {
            SetEstadoControles(false);
            backgroundWorker1.RunWorkerAsync();
        }

        private void Progreso(int porcentaje)
        {
            backgroundWorker1.ReportProgress(porcentaje);
        }

        private void ActualizarBarra(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage > 100 ? 100 : e.ProgressPercentage;
            lblPorcentaje.Text = $"{e.ProgressPercentage} % del proceso";
        }

        private void CancelarProceso()
        {
            elProcesoFueCancelado = true;
            if (backgroundWorker1.IsBusy)
            {
                if (tipo == TIPO.SALDO_PUNITORIO)
                    oPuni.CancelarActualizacionDePunitorios();
                else if (tipo == TIPO.SALDO_LOCACION)
                    oUsuSaldoLoc.CancelarActualizacionDeSaldos();
            }
            SetEstadoControles(true);
            progressBar1.Value = 0;
            lblPorcentaje.Text = "0 % del proceso";
        }

        private void ProcesoFinalizado(object sender, RunWorkerCompletedEventArgs e)
        {
            if (elProcesoFueCancelado)
            {
                elProcesoFueCancelado = false;
                return;
            }

            if(e.Error != null)
            {
                MessageBox.Show("Hubo un error en la actualizacion de saldos", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!txtCodUsuario.Visible && txtCodUsuario.Text.Length == 0)
            {
                Configuracion oConfig = new Configuracion();
                string variable = this.tipo == TIPO.SALDO_LOCACION ? "UltCalculoSaldos" : "UltCalculoPunitorio";          
                oConfig.SetValor_C(variable, DateTime.Now.ToString("yyyy/MM/dd"));  
            }

            MessageBox.Show("Los saldos se actualizaron correctamente", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnCancelar.Enabled = false;
            this.Close();
        }

        private void SetEstadoControles(bool estado)
        {
            btnIniciar.Enabled = estado;
            btnCancelar.Enabled = !estado;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            CancelarProceso();
        }

        private void frmPunitorios_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (backgroundWorker1.IsBusy)
            {
                if (MessageBox.Show("¿Cancelar proceso de calculo de punitorios?", "Mensaje del sistema", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    CancelarProceso();
                else
                    e.Cancel = true;
            }
        }

        private void PrepararDatos()
        {
            this.Cursor = Cursors.WaitCursor;
            Usuarios_CtaCte_Det oUsuDet = new Usuarios_CtaCte_Det();
            if (tipo == TIPO.SALDO_PUNITORIO)
                dtCtaCteDet = oUsuDet.ListarCtacteDetConSaldo(bonificacion: false);
            else
            {
                if(txtCodUsuario.Visible && txtCodUsuario.Text.Length > 0)
                {
                    Usuarios oUsuario = new Usuarios().traerUsuario(0, Convert.ToInt32(txtCodUsuario.Text));
                    dtCtaCteDet = oUsuDet.ListarCtacteDetParaRecalcular(oUsuario.Id);
                }
                else
                    dtCtaCteDet = oUsuDet.ListarCtacteDetParaRecalcular();
            }
            btnIniciar.Enabled = true;
            btnPrepararDatos.Enabled = false;
            this.Cursor = Cursors.Default;
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            Iniciar();
        }

        private void btnPrepararDatos_Click(object sender, EventArgs e)
        {
            PrepararDatos();
        }

        private void frmPunitorios_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();

            if (e.KeyCode == Keys.F2 && tipo == TIPO.SALDO_LOCACION)
            {
                txtCodUsuario.Visible = !txtCodUsuario.Visible;
            }
        }
        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
