using CapaNegocios;
using System;
using System.Data;
using System.Threading;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class frmBusquedaTecnicos : Form
    {
        private Thread hilo;
        private delegate void myDel();
        private DataTable dt;
        private Personal oPersonal = new Personal();
        int idTec;
        public frmBusquedaTecnicos()
        {
            InitializeComponent();
        }

        public int tecnicoSel { get; set; }

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
                dt = oPersonal.ConsultarTecnicos();
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
            if (dt.Rows.Count > 0)
            {
                dgv.DataSource = dt;

                for (int i = 0; i < dgv.Columns.Count; i++)
                    dgv.Columns[i].Visible = false;

                dgv.Columns["nombre"].Visible = true;
                lblTotal.Text = String.Format("Total de Registros: {0}", dt.Rows.Count);
                asignarValores();
            }
            else
            {
                MessageBox.Show("No hay técnicos registrados en el sistema.");
                btnAsignar.Enabled = false;
            }
        }

        private void asignarValores()
        {
            try
            {
                txtId.Text = dgv.SelectedRows[0].Cells["Id"].Value.ToString();
                txtTecnico.Text = dgv.SelectedRows[0].Cells["nombre"].Value.ToString();
            }
            catch
            {
            }
        }

        public void Asignar()
        {
            if (txtId.Text.Length > 0)
            {
                this.idTec = Convert.ToInt32(txtId.Text);
                this.tecnicoSel = this.idTec;
                this.DialogResult = DialogResult.OK;
            }
            else
                MessageBox.Show("No se ha seleccionado técnico.");
        }

        private void FiltroGeneral()
        {
            dt.DefaultView.RowFilter = String.Format("nombre Like '%" + txtBuscar.Text + "%'");
        }

        private void frmBusquedaTecnicos_Load(object sender, EventArgs e)
        {
            comenzarCarga();
            this.ActiveControl = txtBuscar;
        }

        private void frmBusquedaTecnicos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void dgv_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            asignarValores();
        }

        private void btnAsignar_Click(object sender, EventArgs e)
        {
            Asignar();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (txtBuscar.Text.Length == 0)
                dt.DefaultView.RowFilter = "id>0";
        }

        private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnAsignar_Click(null, null);
        }



        private void btnBuscar_Click(object sender, EventArgs e)
        {
            FiltroGeneral();
        }
    }
}
