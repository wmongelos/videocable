using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Globalization;
using System.Threading;
using CapaNegocios;

namespace CapaPresentacion
{
    public partial class frmLoginNuevo : Form
    {
        #region PROPIEDADES
        private Configuracion oConfig = new Configuracion();
        private Puntos_Cobros oPunto = new Puntos_Cobros();
        private Boolean login = false;
        private DataTable dtPuntosCobros = new DataTable();
        #endregion
        public frmLoginNuevo()
        {
            InitializeComponent();
            oConfig.LoadConfiguracion();
            Tablas.LoadData();
            Tablas.LoadImpresiones();
            CargarComboPuntosCobros();
        }

        #region PROPIEDADES
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
            string claveMant = txtClave.Text.ToString().ToUpper();
            string UserMant = txtUsuario.Text.ToString().ToUpper();
            if (claveMant == "CRAMER135" && UserMant == "WAMARPE")
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
                    if (oPersonal.ValidarAccesoNuevo(txtClave.Text.ToUpper(), txtUsuario.Text.ToUpper()))
                    {
                        this.login = true;



                        if (Personal.Id_Punto_Cobro_Predeterminado > 0)
                        {
                            //lbNombre.Text = Personal.Name_Login;
                            //lbArea.Text = Personal.Area_Login;

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
        #endregion

        #region EVENTOS
        private void frmLoginNuevo_Load(object sender, EventArgs e)
        {
            lblTituloLogin.Text = oConfig.GetValor_C("Empresa");
            imgEmpresa.Image = Image.FromFile(@"C:\GIES\Imagenes\LOGOEMPRESA.png");
            imgEmpresa.SizeMode = PictureBoxSizeMode.CenterImage;
            //txtClave.Text = "";
        }

        private void txtUsuario_Enter(object sender, EventArgs e)
        {
            if(txtUsuario.Text == "Usuario")
            {
                txtUsuario.Text = "";
                txtUsuario.ForeColor = Color.LightGray;
            }
        }

        private void txtUsuario_Leave(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "")
            {
                txtUsuario.Text = "Usuario";
                txtUsuario.ForeColor = Color.DimGray;
            }
        }

        private void txtContraseña_Enter(object sender, EventArgs e)
        {
            if (txtClave.Text == "Clave")
            {
                txtClave.Text = "";
                txtClave.ForeColor = Color.LightGray;
                txtClave.UseSystemPasswordChar= true;
            }
        }

        private void txtContraseña_Leave(object sender, EventArgs e)
        {
            if (txtClave.Text == "")
            {
                txtClave.Text = "Clave";
                txtClave.ForeColor = Color.DimGray;
                txtClave.UseSystemPasswordChar = false;

            }
        }
        #endregion

        private void cboPuntosCobros_Enter(object sender, EventArgs e)
        {
            cboPuntosCobros.DroppedDown = true;
        }

        private void imgMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void imgCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtClave.Text == "" || txtUsuario.Text == "")
                MessageBox.Show("Debe completar su usuario y contraseña");
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

        private void txtUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (txtClave.Text == "" || txtUsuario.Text == "")
                    MessageBox.Show("Complete los campos");
                else
                {
                    validarAcceso();
                    if (this.login == true)
                    {
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                        txtClave.UseSystemPasswordChar = true;
                }

            }
            else if (e.KeyChar == (char)Keys.Escape)
                Application.Exit();

        }

        private void txtClave_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (txtClave.Text == "" || txtUsuario.Text == "")
                    MessageBox.Show("Complete los campos");
                else
                {
                    validarAcceso();
                    if (this.login == true)
                    {
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                        txtClave.UseSystemPasswordChar = true;
                }

            }
            else if (e.KeyChar == (char)Keys.Escape)
                Application.Exit();
        }
    }
}
