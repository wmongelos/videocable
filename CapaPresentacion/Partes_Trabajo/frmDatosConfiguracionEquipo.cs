using CapaNegocios;
using System;
using System.Windows.Forms;

namespace CapaPresentacion.Partes_Trabajo
{
    public partial class frmDatosConfiguracionEquipo : Form
    {
        private int idEquipo = 0;
        private string usuario, clave, ip;
        private Equipos oEquipos = new Equipos();

        private bool ControlDatos()
        {
            if (String.IsNullOrEmpty(txtUsuario.Text))
            {
                MessageBox.Show("Debe ingresar un nombre de usuario.");
                txtUsuario.Focus();
                return false;
            }
            else if (String.IsNullOrEmpty(txtPass.Text))
            {
                MessageBox.Show("Debe ingresar una contraseña.");
                txtPass.Focus();
                return false;
            }
            return true;
        }


        private void GuardarDatos()
        {
            if (ControlDatos())
            {
                if (oEquipos.ActualizarDatosConfig(idEquipo, txtUsuario.Text, txtPass.Text, txtIp.Text) > 0)
                    MessageBox.Show("Datos de configuración asignados correctamente.");
                else
                    MessageBox.Show("Error al guardar los datos de configuración.");
                this.DialogResult = DialogResult.OK;
            }
        }


        public frmDatosConfiguracionEquipo(int idEquipo, string usuario, string clave, string ip)
        {
            this.idEquipo = idEquipo;
            this.usuario = usuario;
            this.clave = clave;
            this.ip = ip;
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void boton1_Click(object sender, EventArgs e)
        {
            GuardarDatos();
        }

        private void frmDatosConfiguracionEquipo_Load(object sender, EventArgs e)
        {
            txtUsuario.Text = usuario;
            txtPass.Text = clave;
            txtIp.Text = ip;
        }

        private void frmDatosConfiguracionEquipo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
    }
}
