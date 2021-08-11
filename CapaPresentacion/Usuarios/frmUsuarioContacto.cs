using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class frmUsuarioContacto : Form
    {
        public frmUsuarioContacto(string usuario, string locacion, string tel1, string tel2, string correo)
        {
            InitializeComponent();
            lblUsuario.Text = usuario;
            lblLocacion.Text = locacion;
            lblTel1.Text = tel1;
            lblTel2.Text = tel2;
            lblCorreo.Text = correo;
        }
    }
}
