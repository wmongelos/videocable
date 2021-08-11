using CapaNegocios;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;


namespace CapaPresentacion.Abms
{
    public partial class ABMBarrios : Form
    {
        private Thread hilo;
        private delegate void myDel();
        private DataTable dt_barrios;
        private DataTable dt_localidades_barrios;
        public Barrios oBarrio = new Barrios();
        public Localidades oLocalidad = new Localidades();
        public Manzanas_Calles oManzanas_calles = new Manzanas_Calles();
        private Manzanas oManzanas = new Manzanas();
        private int Id;
        #region MÉTODOS

        private void comenzarCarga()
        {
            pgCircular.Start();
            dgv.DataSource = null;
            dgvLoc.DataSource = null;
            hilo = new Thread(new ThreadStart(cargarDatos));
            hilo.Start();
        }


        /// <summary>
        /// cargaDatos() trae datos de barrios y localidades que tienen asignadas
        /// </summary>


        private void cargarDatos()
        {
            try
            {
                dt_barrios = oBarrio.Listar();
                dt_localidades_barrios = oBarrio.Traer_Localidades(0);
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
            dgv.DataSource = null;
            dgvLoc.DataSource = null;
            dgv.Columns.Clear();
            dgvLoc.Columns.Clear();
            dgv.DataSource = dt_barrios;
            dgvLoc.DataSource = dt_localidades_barrios;

            dgv.Columns["Id_Barrio"].HeaderText = "Código";
            dgv.Columns["Id_Barrio"].Visible = false;
            dgv.Columns["Id_Barrio"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns["Nombre"].HeaderText = "Nombre";
            dgv.Columns["cant_manzanas"].HeaderText = "Cant. manzanas";
            dgv.Columns["cant_manzanas"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvLoc.Columns["id_localidad"].HeaderText = "Código";
            dgvLoc.Columns["id_localidad"].Visible = false;
            dgvLoc.Columns["nombre_localidad"].HeaderText = "Localidad";
            dgvLoc.Columns["id_barrio"].Visible = false;
            dgvLoc.Columns["id_barrio_localidad"].Visible = false;
            dgvLoc.Columns["borrado"].Visible = false;

            if (dgv.Rows.Count > 0)
            {
                DataView vista_localidades_filtradas;
                vista_localidades_filtradas = new DataView(dt_localidades_barrios, "Id_Barrio=" + dgv.Rows[0].Cells["Id_Barrio"].Value.ToString() + "", "Nombre_Localidad ASC", DataViewRowState.CurrentRows);
                dgvLoc.DataSource = vista_localidades_filtradas;
                if (dgv.Columns.Count == dt_barrios.Columns.Count && dgvLoc.Columns.Count == dt_localidades_barrios.Columns.Count)
                {
                    DataGridViewLinkColumn colAgregar = new DataGridViewLinkColumn();
                    dgv.Columns.Add(colAgregar);
                    colAgregar.Text = "Agregar";
                    colAgregar.DataPropertyName = "Agregar";
                    colAgregar.Name = "Manzanas";
                    colAgregar.LinkColor = Color.Blue;
                    colAgregar.VisitedLinkColor = Color.Blue;
                    colAgregar.UseColumnTextForLinkValue = true;
                    colAgregar.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    colAgregar.Width = 100;

                    DataGridViewLinkColumn col = new DataGridViewLinkColumn();
                    dgvLoc.Columns.Add(col);
                    col.Text = "Eliminar";
                    col.DataPropertyName = "Eliminar";
                    col.Name = "Accion";
                    col.LinkColor = Color.Blue;
                    col.VisitedLinkColor = Color.Blue;
                    col.UseColumnTextForLinkValue = true;
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    col.Width = 100;
                }
            }
            cboLocalidades.DataSource = oLocalidad.Listar();
            cboLocalidades.DisplayMember = "Nombre";
            cboLocalidades.ValueMember = "Id";
            asignarValores();
            lblTotal.Text = String.Format("Total de Registros: {0}", dt_barrios.Rows.Count);
            controles(false);
        }

        private void controles(bool state)
        {
            btnActualizar.Enabled = !state;
            btnNuevo.Enabled = !state;
            btnEditar.Enabled = dt_barrios.Rows.Count == 0 ? false : !state;
            btnEliminar.Enabled = dt_barrios.Rows.Count == 0 ? false : !state;
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
                Id = Convert.ToInt32(dgv.SelectedRows[0].Cells["Id_Barrio"].Value);
                txtNombre.Text = dgv.SelectedRows[0].Cells["Nombre"].Value.ToString();
                txtNombre.Tag = dgv.SelectedRows[0].Cells["Nombre"].Value.ToString();
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
            if (MessageBox.Show("¿Desea eliminar el Registro Seleccionado?", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    DataTable dt = new DataTable();
                    dt = oManzanas.Listar(Convert.ToInt32(dgv.SelectedRows[0].Cells["id_barrio"].Value), 0);
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow fila in dt.Rows)
                        {
                            oManzanas_calles.Eliminar_Manzana_Calle(Convert.ToInt32(fila["id_manzana"]), 0);
                            oBarrio.Borrar_manzanas(Convert.ToInt32(fila["id_manzana"]));
                        }
                    }
                    oBarrio.Borrar_asignacion_localidades(Convert.ToInt32(dgv.SelectedRows[0].Cells["id_barrio"].Value));
                    oBarrio.Eliminar(Convert.ToInt32(dgv.SelectedRows[0].Cells["id_barrio"].Value));
                    //comenzarCarga();                    
                }
                catch (Exception)
                {
                    MessageBox.Show("Error al borrar los datos del barrio.");
                }
                comenzarCarga();
            }
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
                    oBarrio.Id_Barrio = Id;
                    oBarrio.Nombre = txtNombre.Text.ToString();
                    oBarrio.Guardar(oBarrio);
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
                DataRow[] dr = dt_barrios.Select(String.Format("Nombre = '{0}'", txtNombre.Text.ToUpper()));

                if (dr.Count() > 0)
                {
                    MessageBox.Show("El Valor ingresado ya Existe", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    return false;
                }
            }

            return true;
        }

        private void AgregarLoc()
        {
            if (dgv.SelectedRows.Count > 0)
            {
                if (dt_localidades_barrios.Select("id_localidad=" + cboLocalidades.SelectedValue + " and id_barrio=" + dgv.SelectedRows[0].Cells["id_barrio"].Value.ToString() + " and borrado=0").Count() == 0)
                {
                    try
                    {
                        oBarrio.Agregar_Localidad_Barrio(Convert.ToInt32(dgv.SelectedRows[0].Cells["id_barrio"].Value), Convert.ToInt32(cboLocalidades.SelectedValue));
                        comenzarCarga();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Error al asignar la localidad.");
                    }

                }
                else
                    MessageBox.Show("Esta localidad ya se encuentra asignada al barrio");
            }
            else
                MessageBox.Show("No hay un barrio seleccionado");
        }


        #endregion


        public ABMBarrios()
        {
            InitializeComponent();
        }

        private void ABMBarrios_Load(object sender, EventArgs e)
        {
            comenzarCarga();
        }

        private void dgv_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            asignarValores();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            controles(false);
            comenzarCarga();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            controles(true);

            limpiarValores();

            nuevoRegistro();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            controles(true);
            editarRegistro();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            eliminarRegistro();
            if (dgv.Rows.Count == 0)
                limpiarValores();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            guardarRegistro();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            cancelarEdicion();
        }

        private void ABMBarrios_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void dgv1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 5)
            {
                if (dgvLoc.Rows.Count > 0)
                {
                    oBarrio.Eliminar_Localidad_Barrio(Convert.ToInt32(dgvLoc.SelectedRows[0].Cells["id_barrio_localidad"].Value));
                    MessageBox.Show("Localidad eliminada");
                    comenzarCarga();
                }
                else
                    MessageBox.Show("No se ha seleccionado localidad");
            }
        }


        private void btnAgregarLocalidad_Click(object sender, EventArgs e)
        {
            AgregarLoc();
        }

        private void dgv_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                DataView vista_localidades_filtradas;

                vista_localidades_filtradas = new DataView(dt_localidades_barrios, "Id_Barrio=" + dgv.SelectedRows[0].Cells["Id_Barrio"].Value.ToString() + "", "Nombre_Localidad ASC", DataViewRowState.CurrentRows);


                dgvLoc.DataSource = vista_localidades_filtradas;

            }
            catch { }

        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                if (dt_localidades_barrios.Select("id_barrio=" + dgv.SelectedRows[0].Cells["id_barrio"].Value.ToString()).Count() > 0)
                {
                    ABMManzanas frmManzanas = new ABMManzanas();
                    frmManzanas.Recibe_Id_Barrio(Convert.ToInt32(dgv.SelectedRows[0].Cells["id_barrio"].Value));
                    frmManzanas.nombre_barrio = dgv.SelectedRows[0].Cells["nombre"].Value.ToString();
                    frmPopUp frmpopup = new frmPopUp();
                    frmpopup.Maximizar = false;
                    frmpopup.Formulario = frmManzanas;

                    if (frmpopup.ShowDialog() == DialogResult.OK)
                        comenzarCarga();
                }
                else
                    MessageBox.Show("El barrio debe poseer al menos una localidad asignada para poder agregar manzanas.");
            }
        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
