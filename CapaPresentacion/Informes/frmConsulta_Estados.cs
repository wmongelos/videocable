using CapaNegocios;
using System;
using System.Data;
using System.Threading;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class frmConsulta_Estados : Form
    {
        private Thread hilo;
        private delegate void myDel();
        private DataTable dt;
        private Equipos oEquipos = new Equipos();
        public frmConsulta_Estados()
        {
            InitializeComponent();
        }
        private void comenzarCarga()
        {
            pgCircular.Start();

            dgv.DataSource = null;

            hilo = new Thread(new ThreadStart(cargarDatos));
            hilo.Start();
        }

        private void cargarDatos()
        {
            try
            {
                dt = oEquipos.ListarCantidad();
                myDel MD = new myDel(asignarDatos);
                this.Invoke(MD, new object[] { });
                pgCircular.Stop();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar Informacion" + ex.Message);
            }
        }

        private void asignarDatos()
        {
            dgv.DataSource = dt;
            dgv.Columns["estado"].HeaderText = "Estado de los Equipos";
            dgv.Columns["estado"].Width = 250;
            dgv.Columns["cantidad"].HeaderText = "Cantidad de Equipos";
            dgv.Columns["cantidad"].Width = 100;
            dgv.Columns["cantidad"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv.Enabled = true;

            int cantidad = 0;

            foreach (DataGridViewRow fila in dgv.Rows)
                cantidad += Convert.ToInt32(fila.Cells["cantidad"].Value);

            lblTotalEquipos.Text = String.Format("Cantidad total: {0}", cantidad);
            lblTotal.Text = String.Format("Total de Registros: {0}", dt.Rows.Count);
        }

        private void frmConsulta_Estados_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void frmConsulta_Estados_Load(object sender, EventArgs e)
        {
            comenzarCarga();
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
