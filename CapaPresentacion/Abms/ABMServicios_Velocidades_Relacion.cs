using CapaNegocios;
using System;
using System.Data;
using System.Threading;
using System.Windows.Forms;

namespace CapaPresentacion.Abms
{
    public partial class ABMServicios_Velocidades_Relacion : Form
    {
        #region DECLARACIONES
        public Int32 idSubServicio;
        public Int32 idServicio;

        private Servicios_Velocidades oSerVelocidades = new Servicios_Velocidades();
        private DataTable dtVelocidadesDisponibles = new DataTable();
        private DataTable dtVelocidadesRelacionadas = new DataTable();
        private Thread hilo;
        private delegate void myDel();
        #endregion

        #region METODOS
        private void ComenzarCarga()
        {
            pgCircular.Start();

            dgvVelocidadesDisponibles.DataSource = null;
            dgvVelocidadesRelacionadas.DataSource = null;

            hilo = new Thread(new ThreadStart(CargarDatos));
            hilo.Start();
        }

        private void CargarDatos()
        {
            try
            {
                dtVelocidadesRelacionadas = null;
                dtVelocidadesDisponibles = Tablas.DataServicios_Velocidades_Relacion;
                dtVelocidadesRelacionadas = oSerVelocidades.ListarVelocidadesServicioSub(idSubServicio);
                DataColumn clm = new DataColumn
                {
                    ColumnName = "accion",
                    DataType = typeof(Int32),
                    DefaultValue = 0
                };
                DataColumn clmId = new DataColumn
                {
                    ColumnName = "idInterno",
                    DataType = typeof(Int32),
                    AutoIncrement = true,
                    AutoIncrementSeed = 1,
                    AutoIncrementStep = 1
                };
                dtVelocidadesRelacionadas.Columns.Add(clm);
                dtVelocidadesRelacionadas.Columns.Add(clmId);
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
            dgvVelocidadesDisponibles.DataSource = dtVelocidadesDisponibles;
            FormatearGrillaVelDispo();
            dgvVelocidadesRelacionadas.DataSource = dtVelocidadesRelacionadas;
            FormatearGrillaVelRelacion();

        }

        private void FormatearGrillaVelDispo()
        {
            foreach (DataGridViewColumn item in dgvVelocidadesDisponibles.Columns)
                item.Visible = false;

            dgvVelocidadesDisponibles.Columns["velocidad"].Visible = true;
            dgvVelocidadesDisponibles.Columns["velocidad"].HeaderText = "Velocidad";

            dgvVelocidadesDisponibles.Columns["velocidad_tipo"].Visible = true;
            dgvVelocidadesDisponibles.Columns["velocidad_tipo"].HeaderText = "Tipo de Velocidad";

        }

        private void FormatearGrillaVelRelacion()
        {
            foreach (DataGridViewColumn item in dgvVelocidadesRelacionadas.Columns)
                item.Visible = false;

            dgvVelocidadesRelacionadas.Columns["velocidad"].Visible = true;
            dgvVelocidadesRelacionadas.Columns["velocidad"].HeaderText = "Velocidad";

            dgvVelocidadesRelacionadas.Columns["velocidad_tipo"].Visible = true;
            dgvVelocidadesRelacionadas.Columns["velocidad_tipo"].HeaderText = "Tipo de Velocidad";

            foreach (DataGridViewRow item in dgvVelocidadesRelacionadas.Rows)
            {
                if (Convert.ToInt32(item.Cells["accion"].Value) == 2 || Convert.ToInt32(item.Cells["accion"].Value) == 3)
                    item.Visible = false;
                else
                    item.Visible = true;
            }
        }

        #endregion
        public ABMServicios_Velocidades_Relacion()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ABMServicios_Velocidades_Relacion_Load(object sender, EventArgs e)
        {
            ComenzarCarga();
        }

        private void dgvVelocidadesDisponibles_SelectionChanged(object sender, EventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            DataRow dr = dtVelocidadesRelacionadas.NewRow();
            dr["id"] = 0;
            dr["id_servicio"] = idServicio;
            dr["id_servicio_sub"] = idSubServicio;
            dr["id_velocidad_relacion"] = Convert.ToInt32(dgvVelocidadesDisponibles.SelectedRows[0].Cells["id_velocidad_relacion"].Value);
            dr["id_velocidad"] = Convert.ToInt32(dgvVelocidadesDisponibles.SelectedRows[0].Cells["id_velocidad"].Value);
            dr["id_velocidad_tipo"] = Convert.ToInt32(dgvVelocidadesDisponibles.SelectedRows[0].Cells["id_velocidad_tipo"].Value);
            dr["velocidad"] = dgvVelocidadesDisponibles.SelectedRows[0].Cells["velocidad"].Value.ToString();
            dr["velocidad_tipo"] = dgvVelocidadesDisponibles.SelectedRows[0].Cells["velocidad_tipo"].Value.ToString();
            dr["accion"] = 1;
            dtVelocidadesRelacionadas.Rows.Add(dr);
            dgvVelocidadesRelacionadas.DataSource = dtVelocidadesRelacionadas;
            FormatearGrillaVelRelacion();



        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvVelocidadesRelacionadas.SelectedRows.Count > 0)
            {
                //si el id es mayor a 0 quiere decir que la velocidad seleccionada se encuentra actualmente en la base entonces le ponemos accion 3 que quiere decir: eliminar de la base, si el id es 0 quiere decir que solo se tiene que sacar del dgv (accion=2)
                if (Convert.ToInt32(dgvVelocidadesRelacionadas.SelectedRows[0].Cells["id"].Value) > 0)
                    dgvVelocidadesRelacionadas.SelectedRows[0].Cells["accion"].Value = 3;
                else
                    dgvVelocidadesRelacionadas.SelectedRows[0].Cells["accion"].Value = 2;
                FormatearGrillaVelRelacion();
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            foreach (DataRow item in dtVelocidadesRelacionadas.Rows)
            {
                int salida = 0;
                int accion = Convert.ToInt32(item["accion"]);
                int idVelocidadRelacion = Convert.ToInt32(item["id_velocidad_relacion"]);
                switch (accion)
                {
                    case 1:
                        salida = oSerVelocidades.GuardarRelacion(this.idServicio, this.idSubServicio, idVelocidadRelacion);
                        break;
                    case 3:
                        salida = oSerVelocidades.EliminarRelacion(Convert.ToInt32(item["id"]));
                        break;
                    default:
                        break;
                }
            }
            ComenzarCarga();
        }
    }
}
