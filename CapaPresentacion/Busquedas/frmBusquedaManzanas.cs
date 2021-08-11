using CapaNegocios;
using System;
using System.Data;
using System.Threading;
using System.Windows.Forms;

namespace CapaPresentacion.Busquedas
{
    public partial class frmBusquedaManzanas : Form
    {
        #region[PROPIEDADES]
        private Thread hilo;
        private delegate void myDel();
        public Manzanas oManzanas = new Manzanas();
        private Manzanas_Calles oManzanas_calles = new Manzanas_Calles();
        private DataTable dt_manzanas;
        private DataTable dt_manzanas_calles;
        public int id_barrio = 0;
        public int id_calle = 0;
        public int altura = 0;
        #endregion

        #region [METODOS]
        private void comenzarCarga()
        {
            pgCircular.Start();

            dgvManzanas.DataSource = null;

            hilo = new Thread(new ThreadStart(cargarDatos));
            hilo.Start();
        }

        private void cargarDatos()
        {
            try
            {
                if (id_barrio > 0)
                    dt_manzanas = oManzanas.Listar(id_barrio, 0);
                else if (id_calle > 0)
                    dt_manzanas = oManzanas.Listar(0, id_calle);
                else
                    dt_manzanas = oManzanas.Listar(0, 0);

                dt_manzanas_calles = oManzanas_calles.Traer_Calles(0);

                myDel MD = new myDel(asignarDatos);

                this.Invoke(MD, new object[] { });

                pgCircular.Stop();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar Información" + ex.Message);
            }

        }

        private void asignarDatos()
        {
            if (dt_manzanas.Rows.Count > 0)
            {
                dgvManzanas.DataSource = dt_manzanas;

                dgvManzanas.Columns["id_manzana"].HeaderText = "Código";
                dgvManzanas.Columns["nro_manzana"].HeaderText = "Nro";

                dt_manzanas_calles.DefaultView.RowFilter = "id_manzana='" + dt_manzanas.Rows[0]["id_manzana"] + "'";
                dgv1.DataSource = dt_manzanas_calles;

                dgv1.Columns["id_manzana"].Visible = false;
                dgv1.Columns["paridadsql"].Visible = false;
                dgv1.Columns["id_calle"].HeaderText = "Código";
                dgv1.Columns["nombre_calle"].HeaderText = "Nro/Nombre";
                dgv1.Columns["altura_desde"].HeaderText = "Desde";
                dgv1.Columns["altura_hasta"].HeaderText = "Hasta";
                dgv1.Columns["paridad"].HeaderText = "Paridad";

            }
            else
            {
                if (id_calle > 0)
                    MessageBox.Show("La calle recibida no posee manzanas asociadas.");
                else
                    MessageBox.Show("Los datos geográficos solicitados no se encuentran en el sistema.");
            }

            lblTotal.Text = String.Format("Total de Registros: {0}", dt_manzanas.Rows.Count);
        }
        #endregion

        public frmBusquedaManzanas()
        {
            InitializeComponent();
        }

        private void frmBusquedaManzanas_Load(object sender, EventArgs e)
        {
            comenzarCarga();
        }

        private void frmBusquedaManzanas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            dgvManzanas.DataSource = null;
            dgv1.DataSource = null;

            comenzarCarga();
        }

        private void dgvManzanas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvManzanas.SelectedRows.Count > 0)
            {
                dt_manzanas_calles.DefaultView.RowFilter = "";
                dt_manzanas_calles.DefaultView.RowFilter = "id_manzana='" + dgvManzanas.SelectedRows[0].Cells["id_manzana"].Value.ToString() + "'";
                dgv1.DataSource = dt_manzanas_calles;
            }
        }

        private void txtNombreNro_TextChanged(object sender, EventArgs e)
        {
            DataView dtv = new DataView(dt_manzanas);
            dtv.RowFilter = string.Format("nro_manzana LIKE '%{0}%'", txtNombreNro.Text.Trim());

            dgvManzanas.DataSource = dtv;
        }

        private void btnAsignar_Click(object sender, EventArgs e)
        {
            if (dgvManzanas.SelectedRows.Count > 0)
            {
                oManzanas.Id_Manzana = Convert.ToInt32(dgvManzanas.SelectedRows[0].Cells["id_manzana"].Value);
                oManzanas.Nro_Manzana = dgvManzanas.SelectedRows[0].Cells["nro_manzana"].Value.ToString();

                int x = 0;
                foreach (DataGridViewRow fila in dgv1.Rows)
                {
                    Manzanas_Calles nuevo_item = new Manzanas_Calles();
                    nuevo_item.Id_Calle = Convert.ToInt32(fila.Cells["id_calle"].Value);
                    nuevo_item.Nombre_calle = fila.Cells["nombre_calle"].Value.ToString();

                    oManzanas.lista_manzanas_calles.Add(nuevo_item);

                    x++;
                }

                this.DialogResult = DialogResult.OK;
            }
            else
                MessageBox.Show("No se ha seleccionado una manzana.");
        }

        private void dgvManzanas_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvManzanas.SelectedRows.Count > 0)
            {

                dt_manzanas_calles.DefaultView.RowFilter = "id_manzana='" + dgvManzanas.SelectedRows[0].Cells["id_manzana"].Value.ToString() + "'";
                dgv1.DataSource = dt_manzanas_calles;
            }
        }
    }
}
