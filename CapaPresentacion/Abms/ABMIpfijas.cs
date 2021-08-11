using CapaNegocios;
using System;
using System.Data;
using System.Net;
using System.Threading;
using System.Windows.Forms;
namespace CapaPresentacion.Abms
{
    public partial class ABMIpfijas : Form
    {
        #region PROPIEDADES
        public string Ip;
        public int Id;
        private delegate void myDel();
        private Thread hilo;
        private int Existe = 0, par1A = 0, par1B = 0, par1C = 0, par1D = 0, Seleccionar, Asignada, CargaFinalizada;
        private string IpDesde, IpHasta, ipnueva;
        private String[] substrings;
        private DataTable dt_ip = new DataTable();
        private Servicios_Ip_Fijas oServicios_ip = new Servicios_Ip_Fijas();
        #endregion

        public ABMIpfijas(int Seleccionar)
        {
            InitializeComponent();
            this.Seleccionar = Seleccionar;
        }
        private void comenzarCarga()
        {
            pgCircular.Start();
            dgvIPs.DataSource = null;
            hilo = new Thread(new ThreadStart(cargarDatos));
            hilo.IsBackground = true;
            hilo.Start();
            btnActualizar.Enabled = false;
            btnCancelar.Enabled = false;
            btnEliminar.Enabled = false;
            btnNuevo.Enabled = false;
        }

        private void cargarDatos()
        {
            try
            {
                dt_ip = oServicios_ip.ListarIpFijas();
                myDel MD = new myDel(asignarDatos);
                this.Invoke(MD, new object[] { });
                pgCircular.Stop();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar Información" + ex.Message);
            }
        }

        private void asignarDatos()
        {
            MaskedTextBox txtIpDesdeMascara = new MaskedTextBox();

            if (dt_ip.Rows.Count > 0)
            {
                DataView dtvista = new DataView(dt_ip);
                dtvista.RowFilter = "Asignada='NO'";
                if (Seleccionar == 1)
                    dgvIPs.DataSource = dtvista;
                else
                    dgvIPs.DataSource = dt_ip;

                dgvIPs.Columns["Id"].Visible = false;
                dgvIPs.Columns["Asignada"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvIPs.Columns["Nombre"].HeaderText = "Nombre";
                dgvIPs.Columns["Ip"].HeaderText = "IP";
                dgvIPs.Columns["Asignada"].HeaderText = "¿Asignada?";
                dgvIPs.Columns["Servicio"].HeaderText = "Servicio";
                dgvIPs.Columns["SubServicio"].HeaderText = "SubServicio";

                lblTotal.Text = String.Format("Total de Registros: {0}", dt_ip.Rows.Count);
            }
            dgvIPs.ClearSelection();
            if (Seleccionar == 1)

                btnSeleccionar.Visible = true;
            else
                btnSeleccionar.Visible = false;
            CargaFinalizada = 1;

            btnActualizar.Enabled = true;
            btnCancelar.Enabled = true;
            btnEliminar.Enabled = true;
            btnNuevo.Enabled = true;
        }
        private void txtDesde_Leave(object sender, EventArgs e)
        {
            if (pnIp.Visible == true)
            {
                IpDesde = txtDesde.Text;
                substrings = IpDesde.Split('.');
                par1A = Convert.ToInt32(substrings[0]);
                par1B = Convert.ToInt32(substrings[1]);
                par1C = Convert.ToInt32(substrings[2]);
                par1D = Convert.ToInt32(substrings[3]);
                txtHasta.Text = par1A.ToString() + "." + par1B.ToString() + "." + par1C.ToString();
            }
        }

        private void boton2_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in dgvGeneranIP.Rows)
            {
                Ip = item.Cells["Ips"].Value.ToString();
                Existe = oServicios_ip.VerificarExistencia(Ip);
                if (Existe == 0)
                {
                    oServicios_ip.Ip = Ip;
                    oServicios_ip.Id = 0;
                    oServicios_ip.Guardar(oServicios_ip);
                }
                else
                    MessageBox.Show("Esta IP ya esta agregada", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            MessageBox.Show("Numeros de Ip guardadas correctamente", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void ABMIpfijas_Load(object sender, EventArgs e)
        {
            comenzarCarga();
            pnIp.Visible = false;
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            if (Int32.Parse(txthasta2.Text) <= 255)
            {
                if (GenerarIPS())
                {
                    if (dgvGeneranIP.Rows.Count > 0)
                    {
                        btnGuardar.Enabled = true;
                        btnGenerar.Enabled = false;
                    }
                }
            }
            else
            {
                MessageBox.Show("Los valores de ip no pueden ser mayor a 255", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }


        private void dgvIPs_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            seleccionarDatos();
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Asignada = oServicios_ip.VerificarAsignacion(Id);
            try
            {
                if (Asignada == 1)
                    MessageBox.Show("Esta IP actualmente se encuentra asignada, no es posible borrar", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    oServicios_ip.Eliminar(Id);
                    MessageBox.Show("IP eliminada correctamente");
                    comenzarCarga();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error al eliminar la IP");
                throw;
            }
        }

        private void dgvIPs_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) && (Seleccionar == 1))
                this.DialogResult = DialogResult.OK;
        }

        private void dgvIPs_SelectionChanged(object sender, EventArgs e)
        {
            seleccionarDatos();
        }

        private void dgvIPs_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void btnCancelar2_Click(object sender, EventArgs e)
        {
            dgvGeneranIP.DataSource = null;
            txthasta2.Text = "";
            txtDesde.Text = "";
            txtHasta.Text = "";
            pnIp.Visible = false;
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            comenzarCarga();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            pnIp.Visible = true;
        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ABMIpfijas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            IpHasta = txtHasta.Text;
            IPAddress ip = new IPAddress(new byte[] { 0, 0, 0, 0 });
            if (!IPAddress.TryParse(IpDesde, out ip))
                MessageBox.Show("Ip Invalida");
            else
                GenerarIPS();
        }
        private Boolean GenerarIPS()
        {
            try
            {
                IpHasta = txtHasta.Text + txthasta2.Text;
                DataTable dt_ips = new DataTable();
                dt_ips.Columns.Add("Ips", typeof(string));
                ipnueva = par1A.ToString() + "." + par1B.ToString() + "." + par1C.ToString() + "." + par1D.ToString();
                while (par1D < Convert.ToInt32(txthasta2.Text))
                {
                    par1D++;
                    ipnueva = par1A.ToString() + "." + par1B.ToString() + "." + par1C.ToString() + "." + par1D.ToString();
                    dt_ips.Rows.Add(ipnueva);
                }
                dgvGeneranIP.DataSource = dt_ips;
                MessageBox.Show("Numeros de Ip generadas correctamente", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;

            }
            catch (Exception)
            {
                MessageBox.Show("Error al generar numeros de ip", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        private void seleccionarDatos()
        {
            if (CargaFinalizada == 1)
            {
                try
                {
                    Id = Convert.ToInt32(dgvIPs.SelectedRows[0].Cells["id"].Value);
                    Ip = dgvIPs.SelectedRows[0].Cells["ip"].Value.ToString();
                    txtIP.Text = Ip;
                }
                catch (Exception)
                { }
            }
        }
    }
}
