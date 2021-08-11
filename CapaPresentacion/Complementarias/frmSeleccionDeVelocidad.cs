using CapaNegocios;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace CapaPresentacion.Complementarias
{
    public partial class frmSeleccionDeVelocidad : Form
    {
        private int idServicio;
        private int idServicioSub;
        private int idTipoFacturacion;
        private DataTable dtSubserviciosDisponibles;

        public int idVelocidad { get; private set; }
        public int idVelocidadTipo { get; private set; }

        public frmSeleccionDeVelocidad(int idServicio, int idServicioSub, int idTipoFacturacion)
        {
            InitializeComponent();
            this.idServicio = idServicio;
            this.idServicioSub = idServicioSub;
            this.idTipoFacturacion = idTipoFacturacion;
        }

        private void frmSeleccionDeVelocidad_Load(object sender, EventArgs e)
        {
            dtSubserviciosDisponibles = new Usuarios_Servicios()
                .ListarSubserviciosDisponibles(new Servicios_Tarifas().getTarifaId(), idServicio, idTipoFacturacion)
                .AsEnumerable()
                .Where(dr => dr.Field<dynamic>("idtipodesub") == 1 &&
                             dr.Field<dynamic>("id_servicios_sub") == idServicioSub)
                .CopyToDataTable();
            formatearDGV();
        }

        private void formatearDGV()
        {
            dgv.DataSource = dtSubserviciosDisponibles;

            foreach (DataGridViewColumn col in dgv.Columns)
            {
                col.Visible = false;
            }

            dgv.Columns["modalidad"].HeaderText = "Modalidad";
            dgv.Columns["modalidad"].Visible = true;
            dgv.Columns["velocidad"].HeaderText = "Velocidad";
            dgv.Columns["velocidad"].Visible = true;
            dgv.Columns["velocidad_tipo"].HeaderText = "Velocidad tipo";
            dgv.Columns["velocidad_tipo"].Visible = true;
        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmSeleccionDeVelocidad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            if(dgv.Rows.Count == 0)
            {
                MessageBox.Show("El servicio seleccionado no tiene tarifas cargadas0", "Mensaje del sistema");
                return;
            }

            if(dgv.SelectedRows.Count == 0)
            {
                MessageBox.Show("No se ha seleccionado ninguna velocidad", "Mensaje del sistema");
                return;
            }

            idVelocidad = Convert.ToInt32(dgv.SelectedRows[0].Cells["id_servicios_velocidad"].Value);
            idVelocidadTipo = Convert.ToInt32(dgv.SelectedRows[0].Cells["id_servicio_velocidad_tip"].Value);

            this.DialogResult = DialogResult.OK;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
