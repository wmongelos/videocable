using CapaNegocios;
using System;
using System.Data;
using System.Threading;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class frmConsultaEquiposUsu : frmUsuarioLocacion
    {
        private Thread hilo;
        private delegate void myDel();
        Equipos oEquipos = new Equipos();
        DataTable dtEquipos = new DataTable();
        int usuario;
        int servicio;
        int locacion;

        public frmConsultaEquiposUsu()
        {
            InitializeComponent();

        }
        private void comenzarCarga()
        {

            dgvEquipos.DataSource = null;
            hilo = new Thread(new ThreadStart(cargarDatos));
            hilo.Start();
        }

        private void cargarDatos()
        {
            try
            {
                dtEquipos = oEquipos.ListarPorUsuario(usuario);
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
            dgvEquipos.DataSource = dtEquipos;

            dgvEquipos.Columns["Id"].Visible = false;
            dgvEquipos.Columns["Id_Usuarios"].Visible = false;
            dgvEquipos.Columns["Id_Usuarios_servicios"].Visible = false;
            dgvEquipos.Columns["Id_Usuarios_servicios1"].Visible = false;
            dgvEquipos.Columns["Id_equipos_Estados"].Visible = false;

            dgvEquipos.Columns["Id_equipos_modelos"].Visible = false;

            dgvEquipos.Columns["Id_equipos_marcas"].Visible = false;

            dgvEquipos.Columns["Id_equipos_tipos"].Visible = false;
            dgvEquipos.Columns["Id_locacion"].Visible = false;

            dgvEquipos.Columns["nombre"].Visible = false;
            dgvEquipos.Columns["apellido"].Visible = false;

            dgvServicios.Columns["id"].Visible = false;
            dgvServicios.Columns["Id_servicios_tipos"].Visible = false;

            locacion = Convert.ToInt32(dgvLocaciones.SelectedRows[0].Cells["id"].Value);
            servicio = Convert.ToInt32(dgvServicios.SelectedRows[0].Cells["id"].Value);
            dtEquipos.DefaultView.RowFilter = string.Format("id_locacion=" + locacion + " and id_usuarios_servicios=" + servicio + "");
            dgvEquipos.DataSource = dtEquipos;
            try
            {


                //txtParte_Nombre.Text = dgvEquipos.SelectedRows[0].Cells["nombre"].Value.ToString();
                //txtParte_Apellido.Text = dgvEquipos.SelectedRows[0].Cells["apellido"].Value.ToString();

            }
            catch (Exception)
            {


            }

        }
        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frmConsultaPartesUsu_Load(object sender, EventArgs e)
        {
            usuario = this.Usuario_Id;
            servicio = this.Usuario_Servicio_Id;
            locacion = this.Usuario_Locacon_Id;
            comenzarCarga();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            dtEquipos.DefaultView.RowFilter = string.Empty;
            locacion = Convert.ToInt32(dgvLocaciones.SelectedRows[0].Cells["id"].Value);
            servicio = Convert.ToInt32(dgvServicios.SelectedRows[0].Cells["id"].Value);
            dtEquipos.DefaultView.RowFilter = string.Format("id_locacion=" + locacion + " and id_servicios=" + servicio + "");
            dgvEquipos.DataSource = dtEquipos;

        }

        private void frmConsultaPartesUsu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
    }
}
