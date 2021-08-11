using CapaNegocios;
using System;
using System.Data;
using System.Threading;
using System.Windows.Forms;

namespace CapaPresentacion.Abms
{
    public partial class ABMServicios_Velocidades : Form
    {
        private Thread hilo;
        private delegate void myDel();
        DataTable dtVelocidades = new DataTable();
        DataTable dtTiposVelocidades = new DataTable();
        Servicios_Velocidades oServiciosVelocidades = new Servicios_Velocidades();
        private int Id;

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
                dtVelocidades = oServiciosVelocidades.ListarVelocidades();

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
            dgv.DataSource = dtVelocidades;

            for (int x = 0; x < dgv.Columns.Count; x++)
                dgv.Columns[x].Visible = false;

            dgv.Columns["id"].Visible = false;
            dgv.Columns["velocidad"].Visible = true;
            dgv.Columns["velocidad"].HeaderText = "Velocidad";


            lblTotal.Text = String.Format("Total de registros: {0}", dgv.Rows.Count);
            AsignarValores();
            controles(true);
        }

        private void AsignarValores()
        {
            try
            {
                Id = Convert.ToInt32(dgv.SelectedRows[0].Cells["id"].Value);
                try
                {
                    spnVelocidad.Value = Convert.ToInt32(dgv.SelectedRows[0].Cells["velocidad"].Value);
                }
                catch
                {
                    spnVelocidad.Value = spnVelocidad.Minimum;
                }
            }
            catch { }

        }

        private void controles(bool state)
        {
            btnActualizar.Enabled = state;
            btnNuevo.Enabled = state;

            btnEliminar.Enabled = state;
            btnEditar.Enabled = state;


            btnGuardar.Enabled = !state;
            btnCancelar.Enabled = !state;


            spnVelocidad.Enabled = !state;
        }


        private void limpiarValores()
        {
            Id = 0; ;
            spnVelocidad.Value = spnVelocidad.Minimum;
        }

        private void Guardar()
        {
            try
            {
                oServiciosVelocidades.Id = Id;
                oServiciosVelocidades.Velocidad = Convert.ToInt32(spnVelocidad.Value);
                oServiciosVelocidades.Guardar(oServiciosVelocidades);

                comenzarCarga();
            }
            catch
            {
                MessageBox.Show("Error al guardar datos de velocidad.");
            }
        }

        private void Eliminar()
        {
            int IdVelocidades = Convert.ToInt32(dgv.SelectedRows[0].Cells["id"].Value);
            dtTiposVelocidades = oServiciosVelocidades.ListarServicioVelocidades(IdVelocidades);
            try
            {
                if (dtTiposVelocidades.Rows.Count == 0)
                    oServiciosVelocidades.Eliminar(IdVelocidades);
                else
                    MessageBox.Show("Hay servicios activos, no se puede eliminar la velocidad.");

                comenzarCarga();
                if (dgv.Rows.Count == 0)
                    limpiarValores();
            }
            catch
            {
                MessageBox.Show("Error al intentar eliminar registro.");
            }
        }

        public ABMServicios_Velocidades()
        {
            InitializeComponent();
        }

        private void ABMVelocidades_Load(object sender, EventArgs e)
        {
            comenzarCarga();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            comenzarCarga();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            controles(false);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            controles(true);
            dgv.Enabled = true;
        }

        private void btnNuevo_Click_1(object sender, EventArgs e)
        {
            controles(false);
            limpiarValores();
        }

        private void btnActualizar_Click_1(object sender, EventArgs e)
        {
            comenzarCarga();
        }

        private void btnEditar_Click_1(object sender, EventArgs e)
        {
            if (dgv.Rows.Count > 0)
                controles(false);
        }

        private void btnCancelar_Click_1(object sender, EventArgs e)
        {
            controles(true);
            dgv.Enabled = true;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            DataRow[] drFilter = dtVelocidades.Select(String.Format("Velocidad = {0}", Convert.ToInt32(spnVelocidad.Value)));

            if (drFilter.Length > 0)
            {
                MessageBox.Show("La velocidad ya fue ingresada", "Mensaje del Sistema");
                spnVelocidad.Focus();
            }
            else
                Guardar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgv.Rows.Count > 0)
            {
                DialogResult dialogResult = MessageBox.Show("¿Está seguro que desea eliminar?", "", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                    Eliminar();
            }
        }

        private void dgv_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            AsignarValores();
        }

        private void ABMVelocidades_Load_1(object sender, EventArgs e)
        {
            comenzarCarga();
        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ABMVelocidades_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
    }
}
