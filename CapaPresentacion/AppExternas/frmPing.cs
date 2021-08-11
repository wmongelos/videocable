using System;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class frmPing : Form
    {
        private IPAddress ip;
        private Ping oPing = new Ping();
        private Tools oTool = new Tools();
        private StringBuilder estado = new StringBuilder();
        public frmPing(string ip)
        {
            InitializeComponent();
            if (!string.IsNullOrEmpty(ip))
            {
                txtIp.Text = ip;
                HacerPing(ip);
            }
            else
            {
                MessageBox.Show(new Form() { TopMost = true }, "IP invalida", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void HacerPing(string ip)
        {
            try
            {

                btnOtraVez.Enabled = false;
                this.Cursor = Cursors.WaitCursor;
                lblEstado.Text = String.Empty;
                estado.Clear();
                this.ip = IPAddress.Parse(ip);
                for (int i = 0; i < 4; i++)
                {
                    PingReply pr = oPing.Send(ip);
                    estado.Append(string.Format("\n *Respuesta desde {0}: bytes:{1} tiempo={2} ({3})",
                                                pr.Address, pr.Buffer.Length, pr.RoundtripTime,
                                                pr.Status.ToString()));
                    lblEstado.Text = estado.ToString();
                }
                btnOtraVez.Enabled = true;
                this.Cursor = Cursors.Arrow;
            }
            catch (Exception c)
            {
                MessageBox.Show("Error: " + c.Message);
                btnOtraVez.Enabled = true;
                this.Cursor = Cursors.Arrow;
            }

        }

        private void btnOtraVez_Click(object sender, EventArgs e)
        {
            HacerPing(txtIp.ToString());
        }

        private void boton2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
