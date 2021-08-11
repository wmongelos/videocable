
using System;
using System.Data;
using System.Threading;
using System.Windows.Forms;
using CapaNegocios.PagosExternos;

namespace CapaPresentacion.PagosExternos
{
    public partial class frmConfiguracion : Form
    {
        private Thread hilo;
        private delegate void myDel();
        private DataTable dtVencimientos = new DataTable();
        private ConfiguracionPagos oConfiguracion = new ConfiguracionPagos();
        private string CPHash;
        private string MPCServidor,MPCUsuario,MPCPass,MPCBase;
        private int CPIdEntidad;
        private bool huboCambios = false;
        private string valorAnterior = "";

        public frmConfiguracion()
        {
            InitializeComponent();
        }

        private void comenzarCarga()
        {
            hilo = new Thread(new ThreadStart(cargarDatos));
            hilo.IsBackground = true;
            hilo.Start();
        }
        private void cargarDatos()
        {
            try
            {
                //dtVencimientos = oEquipos.ListarInformeAsignados(this.filtro, this.asignados);
                this.CPHash = (string)oConfiguracion.Get("hash", (int)PagoExterno.Plataforma.CAPTARPAGOS, TypeCode.String);
                this.CPIdEntidad = (int)oConfiguracion.Get("identidad", (int)PagoExterno.Plataforma.CAPTARPAGOS, TypeCode.Int32);
                this.MPCServidor = (string)oConfiguracion.Get("servidor", (int)PagoExterno.Plataforma.MERCADOPAGO, TypeCode.String);
                this.MPCUsuario = (string)oConfiguracion.Get("usuario", (int)PagoExterno.Plataforma.MERCADOPAGO, TypeCode.String);
                this.MPCPass = (string)oConfiguracion.Get("clave", (int)PagoExterno.Plataforma.MERCADOPAGO, TypeCode.String);
                this.MPCBase = (string)oConfiguracion.Get("base", (int)PagoExterno.Plataforma.MERCADOPAGO, TypeCode.String);
                myDel MD = new myDel(asignarDatos);
                this.Invoke(MD, new object[] { });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar Informacion" + ex.Message);
            }
        }

        private void asignarDatos()
        {
            txtCPHash.Text = this.CPHash == null ? "" : this.CPHash;
            txtCPIdEntidad.Text = this.CPIdEntidad == 0 ? "" : this.CPIdEntidad.ToString();
            txtMPCUsuario.Text = this.MPCUsuario == null ? "" : this.MPCUsuario;
            txtMPCServer.Text = this.MPCServidor == null ? "" : this.MPCServidor;
            txtMPCPass.Text = this.MPCPass == null ? "" : this.MPCPass;
            txtMPCBase.Text = this.txtMPCBase == null ? "" : this.MPCBase;
        }

        private void frmConfiguracion_Load(object sender, System.EventArgs e)
        {
            comenzarCarga();
        }

        private void btnAceptar_Click(object sender, System.EventArgs e)
        {
            if(huboCambios)
            {
                oConfiguracion.Guardar("hash", txtCPHash.Text,(int)PagoExterno.Plataforma.CAPTARPAGOS);
                oConfiguracion.Guardar("IdEntidad",Convert.ToDecimal(txtCPIdEntidad.Text), (int)PagoExterno.Plataforma.CAPTARPAGOS);
                oConfiguracion.Guardar("servidor",txtMPCServer.Text, (int)PagoExterno.Plataforma.MERCADOPAGO);
                oConfiguracion.Guardar("usuario",txtMPCUsuario.Text, (int)PagoExterno.Plataforma.MERCADOPAGO);
                oConfiguracion.Guardar("clave",txtMPCPass.Text, (int)PagoExterno.Plataforma.MERCADOPAGO);
                oConfiguracion.Guardar("base",txtMPCBase.Text, (int)PagoExterno.Plataforma.MERCADOPAGO);
            }
        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmConfiguracion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void txtCPIdEntidad_Enter(object sender, EventArgs e)
        {
           
        }

        private void txtCPIdEntidad_TextChanged(object sender, EventArgs e)
        {
            huboCambios = true;
        }

        private void txtCPHash_TextChanged(object sender, EventArgs e)
        {
            huboCambios = true;

        }

        private void txtServer_TextChanged(object sender, EventArgs e)
        {
            huboCambios = true;

        }

        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {
            huboCambios = true;

        }

        private void txtPass_TextChanged(object sender, EventArgs e)
        {
            huboCambios = true;

        }
    }
}
