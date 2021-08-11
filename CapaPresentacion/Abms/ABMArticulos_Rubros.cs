using CapaNegocios;
using System;
using System.Data;
using System.Threading;
using System.Windows.Forms;

namespace CapaPresentacion.Abms
{
    public partial class ABMArticulos_Rubros : Form
    {
        private Thread hilo;
        private delegate void myDel();
        DataTable dt = new DataTable();

        Articulos_Rubros oArtRubro = new Articulos_Rubros();

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
                dt = oArtRubro.Listar();

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

            for (int x = 0; x < dgv.Columns.Count; x++)
                dgv.Columns[x].Visible = false;

            dgv.Columns["Id"].Visible = false;
            dgv.Columns["Descripcion"].Visible = true;

            lblTotal.Text = String.Format("Total de registros: {0}", dgv.Rows.Count);
            AsignarValores();
            controles(true);
        }

        private void AsignarValores()
        {
            try
            {
                Id = Convert.ToInt32(dgv.SelectedRows[0].Cells["id"].Value);
                txtNombre.Text = dgv.SelectedRows[0].Cells["Descripcion"].Value.ToString();
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


            txtNombre.Enabled = !state;
        }


        private void limpiarValores()
        {
            Id = 0; ;
            txtNombre.Text = "";
        }

        private void Guardar()
        {
            try
            {
                oArtRubro.Id = Id;
                oArtRubro.Descripcion = txtNombre.Text;
                oArtRubro.Guardar(oArtRubro);

                comenzarCarga();
            }
            catch
            {
                MessageBox.Show("Error al guardar datos de velocidad.");
            }
        }

        private void Eliminar()
        {
            try
            {
                oArtRubro.Eliminar(Convert.ToInt32(dgv.SelectedRows[0].Cells["id"].Value));
                comenzarCarga();
                if (dgv.Rows.Count == 0)
                    limpiarValores();
            }
            catch
            {
                MessageBox.Show("Error al intentar eliminar registro.");
            }
        }

        public ABMArticulos_Rubros()
        {
            InitializeComponent();
        }

        private void ABMArticulos_Rubros_Load(object sender, EventArgs e)
        {
            comenzarCarga();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            comenzarCarga();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            controles(true);
            dgv.Enabled = true;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            controles(false);
            limpiarValores();
        }



        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgv.Rows.Count > 0)
                controles(false);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            DataRow[] drFilter = dt.Select(String.Format("Descripcion = '{0}'", txtNombre.Text));

            if (drFilter.Length > 0)
            {
                MessageBox.Show("El Rubro ya fue ingresado", "Mensaje del Sistema");
                txtNombre.Focus();
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


        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ABMArticulos_Rubros_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                dt.DefaultView.RowFilter = String.Format("Descripcion LIKE '%{0}%'", txtNombre.Text);
        }
    }
}
