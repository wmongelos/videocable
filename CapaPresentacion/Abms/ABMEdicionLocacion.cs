using CapaNegocios;
using System;
using System.Data;
using System.Windows.Forms;

namespace CapaPresentacion.Abms
{
    public partial class ABMEdicionLocacion : Form
    {
        private int idLocacion;
        private DataTable dtDatosLocacion = new DataTable();
        private Usuarios_Locaciones oUsuariosLocaciones = new Usuarios_Locaciones();

        public ABMEdicionLocacion(int idLocacionRecibida)
        {
            idLocacion = idLocacionRecibida;
            InitializeComponent();
        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmEdicionDatosLocacion_Load(object sender, EventArgs e)
        {
            dtDatosLocacion = oUsuariosLocaciones.ListarDatosLocacion(idLocacion);
            if (dtDatosLocacion.Rows.Count > 0)
            {
                prefijo1.Text = dtDatosLocacion.Rows[0]["prefijo_1"].ToString();
                prefijo2.Text = dtDatosLocacion.Rows[0]["prefijo_2"].ToString();
                txtTel1.Text = dtDatosLocacion.Rows[0]["telefono_1"].ToString();
                txtTel2.Text = dtDatosLocacion.Rows[0]["telefono_2"].ToString();
                txtObservacion.Text = dtDatosLocacion.Rows[0]["observacion"].ToString();
            }
            else
                MessageBox.Show("No se encontraron datos de la locación.");
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                oUsuariosLocaciones.ActualizarTelefonosObservacion(idLocacion, Convert.ToInt32(prefijo1.Text), Convert.ToDouble(txtTel1.Text), Convert.ToInt32(prefijo2.Text), Convert.ToDouble(txtTel2.Text), txtObservacion.Text);
                MessageBox.Show("Operación realizada correctamente.");
                this.Close();
            }
            catch
            {
                MessageBox.Show("Error al guardar datos.");
            }
        }

        private void frmEdicionDatosLocacion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
    }
}
//200919-13:39 fede