using CapaNegocios;
using System;
using System.Data;
using System.Threading;
using System.Windows.Forms;


namespace CapaPresentacion.Partes_Trabajo
{
    public partial class frmServiciosDelParte : Form
    {
        private Thread hilo;
        private delegate void myDel();
        Partes oPartes = new Partes();
        Partes_Usuarios_Servicios oPartesUsuariosServicios = new Partes_Usuarios_Servicios();
        private DataTable DtServiciosAsociados = new DataTable();
        private int IdParte = 0;
        Partes_Equipos oParteEquipo = new Partes_Equipos();

        private void ComenzarCarga()
        {
            pgCircular.Start();
            hilo = new Thread(new ThreadStart(CargarDatos));
            hilo.IsBackground = true;
            hilo.Start();
        }

        private void CargarDatos()
        {
            try
            {
                DtServiciosAsociados = oPartesUsuariosServicios.ListarServiciosPorParte(IdParte, Partes_Usuarios_Servicios.CONDICION_REQ_EQUIPOS.TODOS);
                myDel MD = new myDel(AsignarDatos);
                this.Invoke(MD, new object[] { });
            }
            catch
            {
                MessageBox.Show("Error al cargar información.");
            }
            pgCircular.Stop();
        }


        private void AsignarDatos()
        {
            dgvServicios.DataSource = DtServiciosAsociados;
            for (int x = 0; x < dgvServicios.Columns.Count; x++)
                dgvServicios.Columns[x].Visible = false;

            dgvServicios.Columns["servicio"].Visible = true;
            dgvServicios.Columns["tiposervicio"].Visible = true;
            dgvServicios.Columns["requiere_equipo"].Visible = true;
            dgvServicios.Columns["requiere_tarjeta"].Visible = true;
            dgvServicios.Columns["requiere_velocidad"].Visible = true;
            dgvServicios.Columns["equipo_tipo"].Visible = true;
            dgvServicios.Columns["equipo_marca"].Visible = true;
            dgvServicios.Columns["serie"].Visible = true;
            dgvServicios.Columns["mac"].Visible = true;
            dgvServicios.Columns["SubServicio"].Visible = true;
            dgvServicios.Columns["Servicio"].HeaderText = "Servicio";
            dgvServicios.Columns["SubServicio"].HeaderText = "Sub Servicio";
            dgvServicios.Columns["tiposervicio"].HeaderText = "Tipo de servicio";
            dgvServicios.Columns["requiere_equipo"].HeaderText = "Requiere equipo";
            dgvServicios.Columns["requiere_tarjeta"].HeaderText = "Requiere tarjeta";
            dgvServicios.Columns["requiere_velocidad"].HeaderText = "Requiere velocidad";
            dgvServicios.Columns["equipo_tipo"].HeaderText = "Equipo Tipo";
            dgvServicios.Columns["equipo_marca"].HeaderText = "Equipo Marca";
            dgvServicios.Columns["serie"].HeaderText = "Equipo Serie";
            dgvServicios.Columns["mac"].HeaderText = "Equipo Mac";
            lblTotal.Text = String.Format("Total de Registros: {0}", dgvServicios.Rows.Count);
        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmServiciosDelParte_Load(object sender, EventArgs e)
        {
            lblNparte.Text = String.Format("N° de parte seleccionado: {0}", IdParte);
            ComenzarCarga();
        }

        private void frmServiciosDelParte_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        public frmServiciosDelParte(int IdParteRecibido)
        {
            IdParte = IdParteRecibido;
            InitializeComponent();
        }
    }
}
