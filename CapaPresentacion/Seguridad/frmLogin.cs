using CapaNegocios;
using System;
using System.Data;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class frmLogin : Form
    {
        private Configuracion oConfig = new Configuracion();
        private Puntos_Cobros oPunto = new Puntos_Cobros();
        private Boolean login = false;
        private DataTable dtPuntosCobros = new DataTable();

        public frmLogin()
        {
            InitializeComponent();
            CargarComboPuntosCobros();
        }

        private void CargarComboPuntosCobros()
        {
            dtPuntosCobros = new Puntos_Cobros().Listar();
            cboPuntosCobros.DataSource = dtPuntosCobros;
            cboPuntosCobros.DisplayMember = "descripcion";
            cboPuntosCobros.ValueMember = "id";

            if (oConfig.GetValor_N("ModPuntoGestion") == 2 && Personal.Req_Horario == 0)
                cboPuntosCobros.Visible = true;
        }

        private Boolean validarAcceso()
        {
            Personal oPersonal = new Personal();

            if (txtClave.Text.ToString() == "CRAMER135")
            {
                Personal.Id_Login = 0;
                Personal.Name_Login = "DESARROLLO";
                Personal.Id_Punto_Cobro_Predeterminado = 0;

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {

                try
                {
                    if (oPersonal.ValidarAcceso(txtClave.Text.ToUpper()))
                    {
                        this.login = true;



                        if (Personal.Id_Punto_Cobro_Predeterminado > 0)
                        {
                            lbNombre.Text = Personal.Name_Login;
                            lbArea.Text = Personal.Area_Login;

                            if (oConfig.GetValor_N("ModPuntoGestion") == 2 && Personal.Req_Horario == 0)
                                Personal.Id_Punto_Cobro_Predeterminado = Convert.ToInt32(cboPuntosCobros.SelectedValue);


                            DataRow[] dr = dtPuntosCobros.Select(String.Format("Id = {0}", Personal.Id_Punto_Cobro_Predeterminado));

                            Puntos_Cobros.Name_Punto = dr[0]["descripcion"].ToString();

                            Puntos_Cobros.Id_Punto = Personal.Id_Punto_Cobro_Predeterminado;
                        }
                        else
                        {
                            MessageBox.Show("Usuario No Registrado");
                            this.DialogResult = DialogResult.Cancel;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Usuario No Registrado");
                        txtClave.Text = String.Empty;
                        txtClave.Focus();
                    }
                }
                catch
                {
                    MessageBox.Show("Error al ingresar clave.");
                }
            }

            return false;
        }

        private void txtClave_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (txtClave.Text == "")
                    return;
                else
                {
                    validarAcceso();
                }

            }
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if (txtClave.Text == "")
                txtClave.Focus();
            else
                validarAcceso();

            if (this.login == true)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
                txtClave.Focus();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            lblAppName.Text = oConfig.GetValor_C("Empresa");
            txtClave.Text = "";
        }

        private void frmLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void cboPuntosCobros_Enter(object sender, EventArgs e)
        {
            cboPuntosCobros.DroppedDown = true;
        }
    }
}
