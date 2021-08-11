using CapaNegocios;
using System;
using System.Data;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class frmUpdates : Form
    {
        private DataTable dtActualizaciones = new DataTable();
        private Updates oUpdate = new Updates();

        public frmUpdates()
        {
            InitializeComponent();
        }

        private void frmUpdates_Load(object sender, EventArgs e)
        {
            lblVersion.Text = "Version " + Application.ProductVersion.ToString();
            dtActualizaciones = oUpdate.ListarUpdates(Application.ProductVersion.ToString());
            if (dtActualizaciones.Rows.Count > 0)
            {
                foreach (DataRow item in dtActualizaciones.Rows)
                    textBox1.Text = this.textBox1.Text.Insert(this.textBox1.TextLength, item["Detalle"].ToString() + "\r\n");
            }
            textBox1.SelectionStart = 0;
            textBox1.SelectionLength = 0;
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
