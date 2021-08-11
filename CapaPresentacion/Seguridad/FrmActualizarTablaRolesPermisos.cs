using System;
using System.Threading;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class FrmActualizarTablaRolesPermisos : Form
    {
        private Thread hilo;
        private delegate void myDel();

        public FrmActualizarTablaRolesPermisos()
        {
            InitializeComponent();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            comenzarCarga();
        }


        private void comenzarCarga()
        {
            hilo = new Thread(new ThreadStart(iniciarActualizacion));
            hilo.Start();
        }


        private void iniciarActualizacion()
        {
            myDel MD = new myDel(actualizarRolesPermisos);
            this.Invoke(MD, new object[] { });
        }

        private void actualizarRolesPermisos()
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                AdministradorDeObjetos oAdObj = new AdministradorDeObjetos();
                CapaPresentacion.frmMain frmMain = CapaPresentacion.frmMain.Instance();
                oAdObj.ActualizarMenuEnLaBase(frmMain.mnuPrincipal);

                CapaPresentacion.frmUsuariosPrincipal frmUs = CapaPresentacion.frmUsuariosPrincipal.Instance();
                oAdObj.ActualizarPanelBotones(frmUs.pnlInferior);

                AdministradorDeRolesPermisos oAdRP = new AdministradorDeRolesPermisos();
                oAdRP.ActualizarRolesPermisosEnLaBase();

                MessageBox.Show("Actualizacion de seguridad completada");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un error en la actualizacion: " + ex.Message);
            }
            finally { this.Cursor = Cursors.Default; this.DialogResult = DialogResult.OK; }
        }

        private void lblVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmActualizarTablaRolesPermisos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
    }
}
