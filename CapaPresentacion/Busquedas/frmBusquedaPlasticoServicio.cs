using CapaNegocios;
using CapaPresentacion.Abms;
using System;
using System.Data;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace CapaPresentacion.Busquedas
{
    public partial class frmBusquedaPlasticoServicio : Form
    {
        #region Propiedades
        private bool verDetalles = false;
        private Thread hilo;
        private delegate void myDel();
        public DataTable dtServiciosContratados = new DataTable();
        public DataTable dtDebitos = new DataTable();
        private Presentacion_Debitos oPresentacionDebitos = new Presentacion_Debitos();
        private Usuarios_Servicios oUsuariosServicios = new Usuarios_Servicios();

        #endregion

        #region Metodos

        private void ComenzarCarga()
        {
            BloquearControles();
            pgCircular.Start();
            hilo = new Thread(new ThreadStart(CargarDatos));
            hilo.IsBackground = true;
            hilo.Start();
        }

        private void CargarDatos()
        {

            myDel MD = new myDel(AsignarDatos);
            this.Invoke(MD, new object[] { });
            pgCircular.Stop();
        }

        private void AsignarDatos()
        {
            DataGridViewLinkColumn colVerDetalle = new DataGridViewLinkColumn();
            colVerDetalle.Name = "colVerDetalles";
            colVerDetalle.HeaderText = "Detalles";
            colVerDetalle.Text = "Ver";
            colVerDetalle.UseColumnTextForLinkValue = true;
            dgv.DataSource = Usuarios.Current_dtServicios_Debitos;
            dgv.Columns.Add(colVerDetalle);
            FormatearGrilla();
            lblTotal.Text = String.Format("Total de Registros: {0}", dgv.Rows.Count);
            DesBloquearControles();
        }

        private void FormatearGrilla()
        {
            foreach (DataGridViewColumn item in dgv.Columns)
            {
                item.Visible = false;
            }
            dgv.Columns["servicio"].Visible = true;
            dgv.Columns["servicio"].HeaderText = "Servicio";

            dgv.Columns["fecha_baja"].Visible = true;
            dgv.Columns["fecha_baja"].HeaderText = "Fecha de baja";

            dgv.Columns["fecha_inicio"].Visible = true;
            dgv.Columns["fecha_inicio"].HeaderText = "Fecha de inicio";


            dgv.Columns["fecha_solicitud"].Visible = true;
            dgv.Columns["fecha_solicitud"].HeaderText = "Fecha de solicitud";

            dgv.Columns["numero"].Visible = true;
            dgv.Columns["numero"].HeaderText = "Tarjeta";

            dgv.Columns["titular"].Visible = true;
            dgv.Columns["titular"].HeaderText = "Titular";

            dgv.Columns["ColVerDetalles"].Visible = true;


            foreach (DataGridViewRow item in dgv.Rows)
            {
                if (Convert.ToInt32(item.Cells["activo"].Value) == 1)
                    item.DefaultCellStyle.BackColor = Color.LightGreen;
                else
                    item.DefaultCellStyle.BackColor = Color.Tomato;

                item.Selected = false;
            }

        }

        private void BloquearControles()
        {
            foreach (Control item in this.Controls)
            {
                if (item.Name != "pgCircular")
                    item.Enabled = false;
            }
        }

        private void DesBloquearControles()
        {
            foreach (Control item in this.Controls)
                item.Enabled = true;
        }

        #endregion


        public frmBusquedaPlasticoServicio()
        {
            InitializeComponent();
        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmBonificacionItem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void frmBusquedaPlasticoServicio_Load(object sender, EventArgs e)
        {
            ComenzarCarga();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Usuarios oUsuarios = new Usuarios();
            DataTable dt = new DataTable();
            int x = 0;
            dt = oUsuarios.listar();
            int id = 0;
            foreach (DataRow item in dt.Rows)
            {
                id = Convert.ToInt32(item["id_usuarios"]);
                if (oUsuarios.ActualizarUniverso(id) == -1)
                {
                    x++;
                }
            }
            oUsuarios.ActualizarUniverso(id);
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv.Columns[e.ColumnIndex].Name.Equals("colVerDetalles"))
            {
                DataGridViewRow dgvrow;
                if (dgv.SelectedRows.Count > 0)
                    dgvrow = dgv.SelectedRows[0];
                else
                    dgvrow = dgv.Rows[0];
                ABMPlasticos_Usuarios ABMPlasticosUsuario = new ABMPlasticos_Usuarios(Convert.ToInt32(dgvrow.Cells["id"].Value), dgvrow.Cells["numero"].Value.ToString(), dgvrow.Cells["titular"].Value.ToString());

                if (ABMPlasticosUsuario.ShowDialog() == DialogResult.OK)
                    ComenzarCarga();
            }
        }
    }
}//041119fede
