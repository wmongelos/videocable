using CapaNegocios;
using CapaPresentacion.Busquedas;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;


namespace CapaPresentacion.Abms
{
    public partial class ABMManzanas : Form
    {
        private Thread hilo;
        public int Id_Barrio_manzana;
        public string nombre_barrio;
        public Barrios oBarrio = new Barrios();
        public Manzanas oManzanas = new Manzanas();
        public Manzanas_Calles oManzanas_calles = new Manzanas_Calles();
        private delegate void myDel();
        private DataTable dt_manzanas;
        private DataTable dt_manzanas_calles;
        private DataTable dt_localidades;
        private int Id;
        #region MÉTODOS
        public void Recibe_Id_Barrio(int Id_Barrio)
        {
            Id_Barrio_manzana = Id_Barrio;

        }

        private void comenzarCarga()
        {
            pgCircular.Start();

            dgv.DataSource = null;
            dgv1.DataSource = null;
            hilo = new Thread(new ThreadStart(cargarDatos));
            hilo.IsBackground = true;
            hilo.Start();
        }

        private void cargarDatos()
        {
            try
            {
                dt_manzanas = oManzanas.Listar(Id_Barrio_manzana, 0);
                dt_manzanas_calles = oManzanas_calles.Traer_Calles(0);
                dt_localidades = oBarrio.Traer_Localidades(Id_Barrio_manzana);
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
            dgv.Columns.Clear();
            dgv1.Columns.Clear();


            dgv.DataSource = dt_manzanas;
            dgv1.DataSource = dt_manzanas_calles;

            dgv.Columns["Id_Manzana"].Visible = false;
            dgv.Columns["Nro_Manzana"].HeaderText = "Nro/Nombre";
            dgv.Columns["Id_Barrio"].Visible = false;
            dgv.Columns["Borrado"].Visible = false;
            dgv1.Columns["id_calle"].Visible = false;
            dgv1.Columns["id_manzana"].Visible = false;
            dgv1.Columns["paridadsql"].Visible = false;
            dgv1.Columns["nombre_calle"].HeaderText = "Nro/Nombre";
            dgv1.Columns["altura_desde"].HeaderText = "Altura desde";
            dgv1.Columns["altura_hasta"].HeaderText = "Altura hasta";
            dgv1.Columns["paridad"].HeaderText = "Paridad";

            if (dgv.SelectedRows.Count > 0)
            {
                DataView vista_calles_filtradas;

                vista_calles_filtradas = new DataView(dt_manzanas_calles, "id_manzana=" + dgv.Rows[0].Cells["Id_manzana"].Value.ToString() + "", "nombre_calle ASC", DataViewRowState.CurrentRows);

                dgv1.DataSource = vista_calles_filtradas;

                if (dgv.Columns.Count == dt_manzanas.Columns.Count && dgv1.Columns.Count == dt_manzanas_calles.Columns.Count)
                {
                    DataGridViewLinkColumn col = new DataGridViewLinkColumn();
                    dgv1.Columns.Add(col);
                    col.Text = "Eliminar";
                    col.DataPropertyName = "Eliminar";
                    col.Name = "Acción";
                    col.LinkColor = Color.Blue;
                    col.VisitedLinkColor = Color.Blue;
                    col.UseColumnTextForLinkValue = true;
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    col.Width = 100;
                }

            }


            lblTotal.Text = String.Format("Total de Registros: {0}", dt_manzanas.Rows.Count);

            controles(false);
            asignarValores();
        }

        private void controles(bool state)
        {
            btnActualizar.Enabled = !state;
            btnNuevo.Enabled = !state;
            btnEditar.Enabled = dt_manzanas.Rows.Count == 0 ? false : !state;
            btnEliminar.Enabled = dt_manzanas.Rows.Count == 0 ? false : !state;
            dgv.Enabled = !state;
            txtNombre.Enabled = state;
            btnGuardar.Enabled = state;
            btnCancelar.Enabled = state;

        }

        private void limpiarValores()
        {
            Id = 0;
            txtNombre.Text = "";

        }

        private void asignarValores()
        {
            try
            {
                Id = Convert.ToInt32(dgv.SelectedRows[0].Cells["Id_Manzana"].Value);
                txtNombre.Text = dgv.SelectedRows[0].Cells["Nro_Manzana"].Value.ToString();
                txtNombre.Tag = dgv.SelectedRows[0].Cells["Nro_Manzana"].Value.ToString();
            }
            catch { }
        }

        private void nuevoRegistro()
        {
            Id = 0;
            txtNombre.Text = "";
            txtNombre.Enabled = true;
            txtNombre.Focus();
        }

        private void editarRegistro()
        {
            txtNombre.Enabled = true;
            txtNombre.Focus();
        }

        private void eliminarRegistro()
        {
            if (dgv.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("¿Desea eliminar el Registro Seleccionado?", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        oManzanas.Eliminar(Convert.ToInt32(dgv.SelectedRows[0].Cells["id_manzana"].Value));
                        oManzanas_calles.Eliminar_Manzana_Calle(Convert.ToInt32(dgv.SelectedRows[0].Cells["id_manzana"].Value), 0);
                        comenzarCarga();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Error al intentar eliminar la manzana.");
                    }
                }
            }
            else
                MessageBox.Show("No se ha seleccionado una manzana.");

        }

        private void guardarRegistro()
        {
            if (txtNombre.Text.Length == 0)
            {
                txtNombre.Focus();
            }
            else
            {
                if (validarDatos())
                {
                    oManzanas.Id_Manzana = Id;
                    oManzanas.Nro_Manzana = txtNombre.Text.ToString();
                    oManzanas.Id_Barrio = Id_Barrio_manzana;
                    oManzanas.Guardar(oManzanas);
                    comenzarCarga();
                }
            }

        }

        private void cancelarEdicion()
        {
            controles(false);
        }

        private bool validarDatos()
        {
            if (txtNombre.Tag.ToString() != txtNombre.Text && txtNombre.Text.Length > 0)
            {
                DataRow[] dr = dt_manzanas.Select(String.Format("Nro_Manzana = '{0}'", txtNombre.Text.ToUpper()));
                if (dr.Count() > 0)
                {
                    MessageBox.Show("El Valor ingresado ya Existe", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
            }
            return true;
        }

        private void AgregarCalle()
        {
            if (dgv.SelectedRows.Count > 0)
            {
                frmBusquedaCalles frm_BusquedaCalles = new frmBusquedaCalles();
                foreach (DataRow fila in dt_localidades.Rows)
                {
                    frm_BusquedaCalles.lista_id_localidades.Add(Convert.ToInt32(fila["id_localidad"]));
                }
                frmPopUp frmpopup = new frmPopUp();
                frmpopup.Maximizar = false;
                frmpopup.Formulario = frm_BusquedaCalles;
                frmpopup.ShowDialog();
                if (frmpopup.DialogResult == DialogResult.OK)
                {
                    if (dt_manzanas_calles.Select("id_manzana=" + dgv.SelectedRows[0].Cells["id_manzana"].Value.ToString() + " and id_calle=" + frm_BusquedaCalles.oCalles.Id.ToString()).Count() > 0)
                        MessageBox.Show("La calle ya se encuentra asignada a la manzana.");
                    else
                    {
                        ABMManzanas_DatosAsignacionCalle frm_asignacion_calle = new ABMManzanas_DatosAsignacionCalle();
                        frm_asignacion_calle.recibir_id_calle_id_manzana(frm_BusquedaCalles.oCalles.Id, Convert.ToInt32(dgv.SelectedRows[0].Cells[0].Value));
                        frm_asignacion_calle.ShowDialog();
                        if (frm_asignacion_calle.DialogResult == DialogResult.OK)
                        {
                            comenzarCarga();
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("No se ha seleccionado manzana.");
            }
        }

        private void EliminarCalle()
        {

            if (dgv1.Rows.Count > 0)
            {
                try
                {
                    oManzanas_calles.Eliminar_Manzana_Calle(Convert.ToInt32(dgv1.CurrentRow.Cells["id_manzana"].Value), Convert.ToInt32(dgv1.CurrentRow.Cells["id_calle"].Value));
                    MessageBox.Show("Asignación de calle eliminada.");
                    comenzarCarga();
                }
                catch (Exception)
                {
                    MessageBox.Show("Error al querer elimina la asignación de calle.");
                }
            }
            else
                MessageBox.Show("No se ha seleccionado calle.");
        }

        #endregion

        public ABMManzanas()
        {
            InitializeComponent();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            controles(true);
            limpiarValores();
            nuevoRegistro();
        }

        private void ABMManzanas_Load(object sender, EventArgs e)
        {
            lblBarrio.Text = string.Format("{0} {1}", "Barrio:", nombre_barrio);
            comenzarCarga();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            controles(false);
            comenzarCarga();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            controles(true);
            editarRegistro();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            eliminarRegistro();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Id == 0)
            {
                guardarRegistro();
            }
            else
            {
                oManzanas.Editar(Id, txtNombre.Text.ToString());
                comenzarCarga();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            cancelarEdicion();
        }

        private void dgv_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            asignarValores();
        }

        private void btnAgregarLoc_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count > 0)
            {
                DataTable dt = new DataTable();
                frmBusquedaCalles frm_Calles = new frmBusquedaCalles();
                dt = oBarrio.Traer_Localidades(Id_Barrio_manzana);
                foreach (DataRow fila in dt.Rows)
                {
                    frm_Calles.lista_id_localidades.Add(Convert.ToInt32(fila["id_localidad"]));
                }
                frmPopUp frmpopup = new frmPopUp();
                frmpopup.Maximizar = false;
                frmpopup.Formulario = frm_Calles;
                frmpopup.ShowDialog();
                if (frmpopup.DialogResult == DialogResult.OK)
                {
                    int x = 0;
                    foreach (DataGridViewRow fila in dgv1.Rows)
                    {
                        if (fila.Cells[1].Value.ToString() == frm_Calles.oCalles.Id.ToString())
                        {
                            x = 1;
                            break;
                        }
                    }

                    if (x == 1)
                    {
                        MessageBox.Show("La calle seleccionada ya está asignada");
                    }
                    else
                    {
                        ABMManzanas_DatosAsignacionCalle frm_asignacion_calle = new ABMManzanas_DatosAsignacionCalle();
                        frm_asignacion_calle.recibir_id_calle_id_manzana(frm_Calles.oCalles.Id, Convert.ToInt32(dgv.SelectedRows[0].Cells[0].Value));
                        frm_asignacion_calle.ShowDialog();
                        if (frm_asignacion_calle.DialogResult == DialogResult.OK)
                        {
                            comenzarCarga();
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("No se ha seleccionado manzana.");
            }

        }

        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgv1.DataSource = oManzanas_calles.Traer_Calles(Convert.ToInt32(dgv.SelectedRows[0].Cells[0].Value));

            dgv1.Columns["id_calle"].Visible = false;
            dgv1.Columns["id_manzana"].Visible = false;
            dgv1.Columns["paridadsql"].Visible = false;
            dgv1.Columns["nombre_calle"].HeaderText = "Nro/Nombre";
            dgv1.Columns["altura_desde"].HeaderText = "Altura desde";
            dgv1.Columns["altura_hasta"].HeaderText = "Altura hasta";
            dgv1.Columns["Paridad"].HeaderText = "Paridad";
        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void dgv1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 7)
                EliminarCalle();
        }

        private void btnAgregarCalle_Click(object sender, EventArgs e)
        {
            AgregarCalle();
        }

        private void ABMManzanas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
    }
}
