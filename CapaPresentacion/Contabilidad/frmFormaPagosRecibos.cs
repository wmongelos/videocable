using System;
using System.Data;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace CapaPresentacion.Contabilidad
{
    public partial class frmFormaPagosRecibos : Form
    {

        #region declarciones 
        private Thread hilo;
        private delegate void myDel();
        public DataTable dtRecibos = new DataTable();
        public string nombreForma = "";
        public decimal monto = 0;
        #endregion

        #region METODOS

        private void AsignarDatos()
        {
            lblForma.Text = this.nombreForma;
            lblForma.Location = new Point(pnlTitulo.Width - lblForma.Width - 10, lblForma.Location.Y);
            dgvRecibos.DataSource = dtRecibos;
            lblMonto.Text = monto.ToString("c");
            FormatearGrilla();
        }

        private void FormatearGrilla()
        {
            foreach (DataGridViewColumn item in dgvRecibos.Columns)
                item.Visible = false;

            dgvRecibos.Columns["codigo"].Visible = true;
            dgvRecibos.Columns["codigo"].HeaderText = "Codigo";

            dgvRecibos.Columns["nomape"].Visible = true;
            dgvRecibos.Columns["nomape"].HeaderText = "Usuario";

            dgvRecibos.Columns["numero_muestra"].Visible = true;
            dgvRecibos.Columns["numero_muestra"].HeaderText = "Usuario";

            dgvRecibos.Columns["fecha_acreditacion"].Visible = true;
            dgvRecibos.Columns["fecha_acreditacion"].HeaderText = "Fecha acreditacion";

            dgvRecibos.Columns["importe"].Visible = true;
            dgvRecibos.Columns["importe"].HeaderText = "Importe";
            dgvRecibos.Columns["importe"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }
        #endregion

        public frmFormaPagosRecibos()
        {
            InitializeComponent();
        }

        private void frmFormaPagosRecibos_Load(object sender, EventArgs e)
        {
            AsignarDatos();

        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmFormaPagosRecibos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
    }
}
