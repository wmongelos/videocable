using CapaNegocios;
using System;
using System.Data;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace CapaPresentacion.Partes_Trabajo
{
    public partial class frmListadoPartesCortesAbierto : Form
    {
        private delegate void myDel();
        private Thread hilo;
        private int idUsuario;
        private DataTable dtPartesDeCorteAbiertos;

        public frmListadoPartesCortesAbierto(int idUsuario)
        {
            InitializeComponent();
            this.idUsuario = idUsuario;
        }

        private void frmListadoPartesCortesAbierto_Load(object sender, System.EventArgs e)
        {
            ComenzarCarga();
        }

        private void ComenzarCarga()
        {
            pgCircular.Start();
            dgvPartes.DataSource = null;
            hilo = new Thread(new ThreadStart(CargarDatos));
            hilo.IsBackground = true;
            hilo.Start();
        }

        private void CargarDatos()
        {
            try
            {
                dtPartesDeCorteAbiertos = new Partes().TraerPartesUsuario(idUsuario);

                if(dtPartesDeCorteAbiertos.Rows.Count > 0)
                {
                    var rows = dtPartesDeCorteAbiertos.AsEnumerable()
                        .Where(dr => dr.Field<int>("id_partes_estados") != Convert.ToInt32(Partes.Partes_Estados.REALIZADO) &&
                               dr.Field<int>("id_partes_estados") != Convert.ToInt32(Partes.Partes_Estados.ANULADO) &&
                               dr.Field<int>("id_partes_operaciones") == Convert.ToInt32(Partes.Partes_Operaciones.CORTE));

                    if (rows.Any()) 
                    {
                        dtPartesDeCorteAbiertos = rows.CopyToDataTable();
                    }
                    else
                    {
                        dtPartesDeCorteAbiertos.Clear();
                    }
                }

                myDel MD = new myDel(AsignarDatos);
                this.Invoke(MD, new object[] { });
            }
            catch
            {
                MessageBox.Show("Error al cargar información.", "Mensaje del sistema");
            }
            pgCircular.Stop();
        }

        private void AsignarDatos()
        {
            if (dtPartesDeCorteAbiertos.Rows.Count == 0)
                return;

            lblUsuario.Text = $"{dtPartesDeCorteAbiertos.Rows[0]["usuario"]} - [{dtPartesDeCorteAbiertos.Rows[0]["codigo_usuario"]}]";

            dgvPartes.DataSource = dtPartesDeCorteAbiertos;

            foreach (DataGridViewColumn col in dgvPartes.Columns)
                col.Visible = false;

            dgvPartes.Columns["id"].Visible = true;
            dgvPartes.Columns["id"].HeaderText = "Numero de parte";
            dgvPartes.Columns["id"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvPartes.Columns["fecha_reclamo"].Visible = true;
            dgvPartes.Columns["fecha_reclamo"].HeaderText = "Fecha reclamo";
            dgvPartes.Columns["fecha_reclamo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvPartes.Columns["fecha_programado"].Visible = true;
            dgvPartes.Columns["fecha_programado"].HeaderText = "Fecha programado";
            dgvPartes.Columns["fecha_programado"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvPartes.Columns["servicio"].Visible = true;
            dgvPartes.Columns["servicio"].HeaderText = "Servicio";
            dgvPartes.Columns["servicio"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvPartes.Columns["estado"].Visible = true;
            dgvPartes.Columns["estado"].HeaderText = "Estado";
            dgvPartes.Columns["estado"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvPartes.Columns["calle"].Visible = true;
            dgvPartes.Columns["calle"].HeaderText = "Calle";
            dgvPartes.Columns["calle"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvPartes.Columns["altura"].Visible = true;
            dgvPartes.Columns["altura"].HeaderText = "Altura";
            dgvPartes.Columns["altura"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            lblTotal.Text = $"Total de Registros: {dgvPartes.Rows.Count}";
        }

        private void btnAnular_Click(object sender, EventArgs e)
        {
            if(dgvPartes.Rows.Count == 0)
            {
                MessageBox.Show("La grilla se encuentra vacia", "Mensaje del sistema");
            }

            if(dgvPartes.SelectedRows.Count == 0)
            {
                MessageBox.Show("No se selecciono ningun parte", "Mensaje del sistema");
            }

            frmConfirmaParte frm = new frmConfirmaParte(Convert.ToInt32(dgvPartes.SelectedRows[0].Cells["id"].Value), frmConfirmaParte.FUNCIONALIDAD.ANULAR);
            frm.WindowState = FormWindowState.Maximized;
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
            {
                ComenzarCarga();
            }
        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmListadoPartesCortesAbierto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
    }
}
