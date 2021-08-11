using CapaNegocios;
using System;
using System.Data;
using System.Threading;
using System.Windows.Forms;


namespace CapaPresentacion
{
    public partial class frmServiciosHistorial : Form
    {

        Thread hilo;
        private delegate void myDel();
        Servicios_Estados_Historial oServiciosHistorial = new Servicios_Estados_Historial();
        Usuarios_Servicios oUsuariosServicios = new Usuarios_Servicios();
        Servicios oServicios = new Servicios();
        DataTable dtHistorial = new DataTable();
        DataTable dtDatosServicio = new DataTable();
        DataTable dtEstadosServicios = new DataTable();
        private int idUsuariosServicios;

        private void comenzarCarga()
        {
            pgCircular.Start();

            dgvHistorial.DataSource = null;

            hilo = new Thread(new ThreadStart(cargarDatos));
            hilo.IsBackground = true;
            hilo.Start();
        }

        private void cargarDatos()
        {
            dtEstadosServicios = oServicios.ListarEstados();

            if (idUsuariosServicios > 0)
            {
                dtDatosServicio = oServiciosHistorial.ListarDatosUsuarioServicio(idUsuariosServicios);

                if (dtDatosServicio.Rows.Count > 0)
                    dtHistorial = oServiciosHistorial.ListarPorUsuarioSevicio(idUsuariosServicios);
            }

            myDel MD = new myDel(asignarDatos);
            this.Invoke(MD, new object[] { });
            pgCircular.Stop();
        }

        private void asignarDatos()
        {

            lblServicio.Text = String.Format("Servicio: {0}", dtDatosServicio.Rows[0]["servicio"]);
            lblUsuario.Text = String.Format("Usuario: {0}", dtDatosServicio.Rows[0]["usuario"]);
            lblLocacion.Text = String.Format("Locación: {0}, {1}", dtDatosServicio.Rows[0]["Direccion"], dtDatosServicio.Rows[0]["localidad"]);

            cboEstados.DataSource = dtEstadosServicios;
            cboEstados.DisplayMember = "estado";
            cboEstados.ValueMember = "id";

            if (dtHistorial.Rows.Count > 0)
            {
                dgvHistorial.DataSource = dtHistorial;

                for (int x = 0; x < dgvHistorial.Columns.Count; x++)
                    dgvHistorial.Columns[x].Visible = false;

                dgvHistorial.Columns["fecha"].Visible = true;
                dgvHistorial.Columns["estado"].Visible = true;

            }
            else
                MessageBox.Show("El servicio aún no posee un historial.");

        }

        public frmServiciosHistorial(int idUsuariosServicios)
        {
            this.idUsuariosServicios = idUsuariosServicios;
            InitializeComponent();
        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmServiciosHistorial_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void frmServiciosHistorial_Load(object sender, EventArgs e)
        {
            comenzarCarga();
        }

        private void btnBuscar_Click_1(object sender, EventArgs e)
        {
            dtHistorial.DefaultView.RowFilter = "estado='" + cboEstados.Text + "'";
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            if (dgvHistorial.Rows.Count > 0)
            {
                Tools tools = new Tools();
                try
                {
                    this.Cursor = Cursors.WaitCursor;
                    tools.ExportToExcel(dgvHistorial, "Servicios Historial");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally { this.Cursor = Cursors.Default; }
            }
            else
            {
                MessageBox.Show("Tabla vacia", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
