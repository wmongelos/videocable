using CapaNegocios;
using System;
using System.Data;
using System.Threading;
using System.Windows.Forms;

namespace CapaPresentacion.Busquedas
{
    public partial class frmHistorialAsignacionEquipos : Form
    {
        public DataRow DataRow;
        private Thread hilo;
        private delegate void myDel();
        private Equipos oEquipo = new Equipos();
        DataTable dtHistorial;
        public frmHistorialAsignacionEquipos()
        {
            InitializeComponent();
        }

        private void ComenzarCarga()
        {
            pgCircular.Start();
            dgv.DataSource = null;
            hilo = new Thread(new ThreadStart(CargarDatos));
            hilo.Start();
        }

        private void CargarDatos()
        {
            try
            {
                int IdEquipo = Convert.ToInt32(this.DataRow["Id"]);
                dtHistorial = oEquipo.ListarHistorialEquipos(IdEquipo);
                myDel MD = new myDel(AsignarDatos);
                this.Invoke(MD, new object[] { });
                pgCircular.Stop();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar Informacion" + ex.Message);
            }
        }

        private void AsignarDatos()
        {
            dgv.DataSource = dtHistorial;
            for (int i = 0; i < dgv.ColumnCount; i++)
                dgv.Columns[i].Visible = false;
            dgv.Columns["Usuario"].Visible = true;
            dgv.Columns["Equipo"].Visible = true;
            dgv.Columns["Personal"].Visible = true;
            dgv.Columns["Usuario"].HeaderText = "Usuarios";
            dgv.Columns["Equipo"].HeaderText = "Equipo";
            dgv.Columns["Personal"].HeaderText = "Personal";


        }

        private void frmHistorialAsignacionEquipos_Load(object sender, EventArgs e)
        {
            ComenzarCarga();
        }

        private void btnSale_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
