using CapaNegocios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Windows.Forms;

namespace CapaPresentacion.Busquedas
{
    public partial class frmBusquedaCalles : Form
    {
        #region [PROPIEADES]
        private Thread hilo;
        private delegate void myDel();
        private DataTable dt;
        private DataTable dt_localidades;
        public Localidades_Calles oCalles = new Localidades_Calles();
        public Manzanas_Calles oManzanasCalles = new Manzanas_Calles();
        public List<int> lista_id_localidades = new List<int>();
        public Int32 Id_Calle { get; set; }
        public Int32 Id_Localidad { get; set; }
        public Int32 Id_Manzana { get; set; }
        public Int32 Altura_Desde { get; set; }
        public Int32 Altura_Hasta { get; set; }
        private Localidades oLocalidades = new Localidades();
        private string calle;
        public String Calle
        {
            get
            {
                return calle;
            }
            set
            {
                calle = value;
                txtBuscar.Text = value;

            }
        }
        #endregion

        public frmBusquedaCalles()
        {
            InitializeComponent();

            this.Width = Screen.PrimaryScreen.WorkingArea.Width - 100;
            this.Height = Screen.PrimaryScreen.WorkingArea.Height - 100;
        }

        #region [METODOS]
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
                if (Id_Manzana > 0)
                    dt = oCalles.ListarPorManzana(Id_Manzana);
                else
                    dt = oCalles.Listar();

                dt_localidades = oLocalidades.Listar();
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

            if (lista_id_localidades.Count > 0)
            {
                cboLocalidades.Enabled = false;
                string row_filter = "";
                int x = 0;

                foreach (int id_localidad in lista_id_localidades)
                {
                    x++;
                    if (x != lista_id_localidades.Count)
                        row_filter += "Id_Localidades=" + id_localidad.ToString() + " or ";
                    else
                        row_filter += "Id_Localidades=" + id_localidad.ToString();
                }

                DataView vista_calles_filtradas = new DataView(dt, row_filter, "Nombre_Localidad ASC", DataViewRowState.CurrentRows);
                dt = vista_calles_filtradas.ToTable();


                row_filter = "";
                x = 0;
                foreach (int id_localidad in lista_id_localidades)
                {
                    x++;
                    if (x != lista_id_localidades.Count)
                        row_filter += "Id=" + id_localidad.ToString() + " or ";
                    else
                        row_filter += "Id=" + id_localidad.ToString();
                }

                DataView vista_localidades_filtradas = new DataView(dt_localidades, row_filter, "Nombre ASC", DataViewRowState.CurrentRows);
                dt_localidades = vista_localidades_filtradas.ToTable();
            }


            dgv.DataSource = dt;
            //dgv.Columns["Id"].HeaderText = "Código";
            dgv.Columns["Id"].Visible = false;
            dgv.Columns["Altura_Desde"].HeaderText = "Desde";
            dgv.Columns["Altura_Hasta"].HeaderText = "Hasta";
            dgv.Columns["Id_Localidades"].Visible = false;
            dgv.Columns["Nombre_Localidad"].HeaderText = "Localidad";

            foreach (DataGridViewRow item in dgv.Rows)
                item.Height = 30;
            cboLocalidades.DataSource = dt_localidades;
            cboLocalidades.DisplayMember = "Nombre";
            cboLocalidades.ValueMember = "Id";

            lblTotal.Text = String.Format("Total de Registros: {0}", dt.Rows.Count);
            dgv.Focus();
            if (dt.Rows.Count > 0)
                dgv.Rows[0].Selected = true;
        }

        private void asignarValores()
        {
            try
            {
                Id_Calle = Convert.ToInt32(dgv.SelectedRows[0].Cells["Id"].Value.ToString());
                calle = dgv.SelectedRows[0].Cells["Nombre"].Value.ToString();
            }
            catch { }
        }

        private void FiltroGeneral()
        {
            try
            {

                if (txtBuscar.Text.Length > 0)
                {
                    string texto = txtBuscar.Text;
                    int resultado;
                    bool respuesta = int.TryParse(texto, out resultado);

                    if (respuesta)
                        dt.DefaultView.RowFilter = String.Format("nombre='{0}'  and id_localidades={1}", txtBuscar.Text, Convert.ToInt32(cboLocalidades.SelectedValue));
                    else
                        dt.DefaultView.RowFilter = String.Format("nombre Like '%{0}%'  and id_localidades={1}", txtBuscar.Text, Convert.ToInt32(cboLocalidades.SelectedValue));
                }
            }
            catch { MessageBox.Show("Error al realizar búsqueda"); }
        }
        #endregion

        private void frmBusquedaCalles_Load(object sender, EventArgs e)
        {
            comenzarCarga();
        }

        private void frmBusquedaCalles_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void dgv_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            asignarValores();
        }

        private void dgv_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (dgv.SelectedRows.Count > 0)
                {

                    oCalles.Id = Convert.ToInt32(dgv.SelectedRows[0].Cells["Id"].Value);
                    oCalles.Nombre = dgv.SelectedRows[0].Cells["Nombre"].Value.ToString();
                    oCalles.Altura_Desde = Convert.ToInt32(dgv.SelectedRows[0].Cells["Altura_Desde"].Value);
                    oCalles.Altura_Hasta = Convert.ToInt32(dgv.SelectedRows[0].Cells["Altura_Hasta"].Value);
                    oCalles.Id_Localidades = Convert.ToInt32(dgv.SelectedRows[0].Cells["id_localidades"].Value);

                    //this.Id_Calle = Convert.ToInt32(dgv.SelectedRows[0].Cells["Id"].Value);
                    //this.Calle = dgv.SelectedRows[0].Cells["Nombre"].Value.ToString();

                    e.SuppressKeyPress = true;

                    this.DialogResult = DialogResult.OK;

                }
                else
                    MessageBox.Show("No se ha seleccionado una calle.");
            }
            else
            {
                FiltroGeneral();

            }


        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (txtBuscar.Text.Length == 0)
                dt.DefaultView.RowFilter = String.Format("id>0 or nombre_localidad Like '%" + cboLocalidades.Text + "%'");
            else
                FiltroGeneral();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            comenzarCarga();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            FiltroGeneral();
        }

        private void btnAsignar_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count > 0)
            {


                oCalles.Id = Convert.ToInt32(dgv.SelectedRows[0].Cells["Id"].Value);
                oCalles.Nombre = dgv.SelectedRows[0].Cells["Nombre"].Value.ToString();
                oCalles.Altura_Desde = Convert.ToInt32(dgv.SelectedRows[0].Cells["Altura_Desde"].Value);
                oCalles.Altura_Hasta = Convert.ToInt32(dgv.SelectedRows[0].Cells["Altura_Hasta"].Value);
                oCalles.Id_Localidades = Convert.ToInt32(dgv.SelectedRows[0].Cells["id_localidades"].Value);
                this.DialogResult = DialogResult.OK;
            }
            else
                MessageBox.Show("No se ha seleccionado una calle.");
        }

        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            FiltroGeneral();

        }

        private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            FiltroGeneral();

        }

        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            if (dgv.SelectedRows.Count > 0)
            {

                oCalles.Id = Convert.ToInt32(dgv.Rows[e.RowIndex].Cells["Id"].Value);
                oCalles.Nombre = dgv.Rows[e.RowIndex].Cells["Nombre"].Value.ToString();
                oCalles.Altura_Desde = Convert.ToInt32(dgv.Rows[e.RowIndex].Cells["Altura_Desde"].Value);
                oCalles.Altura_Hasta = Convert.ToInt32(dgv.Rows[e.RowIndex].Cells["Altura_Hasta"].Value);
                oCalles.Id_Localidades = Convert.ToInt32(dgv.Rows[e.RowIndex].Cells["id_localidades"].Value);

                //this.Id_Calle = Convert.ToInt32(dgv.Rows[e.RowIndex].Cells["Id"].Value);
                //this.Calle = dgv.Rows[e.RowIndex].Cells["Nombre"].Value.ToString();

                //this.Id_Calle = oCalles.Id;
                //this.Calle = oCalles.Nombre;

                this.DialogResult = DialogResult.OK;

            }
        }
    }
}
