using ServicioWindows;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPanelTareas
{
    public partial class frmAdministrarServicio : Form
    {
        public frmAdministrarServicio()
        {
            InitializeComponent();
        }

        private void cargarDatos()
        {
            lblNombre.Text = $"Servicio: {Servicio.NombreDisplay}";
            lblDescripcion.Text = $"Descripcion: {Servicio.DescripcionServicio}";
            if (FrmMain.GetInstancia().ServicioInstalado)
            {
                lblEstado.Text = $"Estado: {FrmMain.GetInstancia().Controller.Status}";
                if (FrmMain.GetInstancia().Controller.Status == ServiceControllerStatus.Running)
                {
                    btnIniciar.Enabled = false;
                    btnParar.Enabled = true;
                }
                else
                {
                    btnIniciar.Enabled = true;
                    btnParar.Enabled = false;
                }
            }
            else
            {
                lblEstado.Text = "Estado: Servicio no instalado";
            }

            if (!EsAdministrador())
            {
                gbOperacion.Text = $"Operaciones (Solo para administrador)";
                gbOperacion.Enabled = false;
                btnIniciar.Enabled = false;
                btnParar.Enabled = false;
            }
        }

        private void frmAdministrarServicio_Load(object sender, EventArgs e)
        {
            cargarDatos();
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            FrmMain.GetInstancia().Controller.Start();
            FrmMain.GetInstancia().Controller.Refresh();
            cargarDatos();
        }

        private void btnParar_Click(object sender, EventArgs e)
        {
            FrmMain.GetInstancia().Controller.Close();
            FrmMain.GetInstancia().Controller.Refresh();
            cargarDatos();
        }

        private bool EsAdministrador()
        {
            Thread.GetDomain().SetPrincipalPolicy(PrincipalPolicy.WindowsPrincipal);
            WindowsPrincipal myUser = (WindowsPrincipal)Thread.CurrentPrincipal;
            return myUser.IsInRole(WindowsBuiltInRole.Administrator);
        }
    }
}
