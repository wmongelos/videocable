using CapaNegocios;
using System;
using System.Data;
using System.Threading;
using System.Windows.Forms;

namespace CapaPresentacion.Abms
{
    public partial class ABMProveedores : Form
    {
        private Thread hilo;
        private delegate void myDel();
        private DataTable dt;
        private Proveedores oProveedores = new Proveedores();

        public ABMProveedores()
        {
            InitializeComponent();
        }

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

                dt = oProveedores.Listar();

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
            dgv.DataSource = dt;

            for (int i = 0; i < dgv.ColumnCount; i++)
                dgv.Columns[i].Visible = false;

            dgv.Columns["Razon_Social"].Visible = true;
            dgv.Columns["Razon_Social"].HeaderText = "Razon Social";

            lblTotal.Text = String.Format("Total de Registros: {0}", dt.Rows.Count);
        }



        private void ABMProveedores_Load(object sender, EventArgs e)
        {
            comenzarCarga();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            comenzarCarga();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            using (frmPopUp frm = new frmPopUp())
            {
                frm.Formulario = new ABMProveedores_Ficha();
                frm.Maximizar = false;

                if (frm.ShowDialog() == DialogResult.OK)
                    cargarDatos();
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count == 0)
                dgv.Focus();

            DataRow[] dr = dt.Select(String.Format("Id = {0}", dgv.SelectedRows[0].Cells["Id"].Value.ToString()));


            using (frmPopUp frm = new frmPopUp())
            {
                ABMProveedores_Ficha frmABM = new ABMProveedores_Ficha();
                frmABM.DataRow = dr[0];
                frm.Formulario = frmABM;
                frm.Maximizar = false;

                if (frm.ShowDialog() == DialogResult.OK)
                    cargarDatos();
            }

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

        }

        private void dgv_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
        }


        private void ABMProveedores_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtBuscador_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                dt.DefaultView.RowFilter = String.Format("Descripcion LIKE '%{0}%'", txtBuscador.Text);
        }
    }
}
