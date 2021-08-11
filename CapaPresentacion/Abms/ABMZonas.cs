using CapaNegocios;
using System;
using System.Data;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace CapaPresentacion.Abms
{
    public partial class ABMZonas : Form
    {
        #region [PROPIEDADES]
        private Thread hilo;
        private delegate void myDel();
        private DataTable dtLoc;

        private DataTable dtZonas;
        private DataTable dtZonaLoc;
        private DataTable dtZonaLocalidades;

        private Zonas oZona = new Zonas();
        private Localidades oLoc = new Localidades();
        #endregion

        public ABMZonas()
        {
            InitializeComponent();
        }

        #region [METODOS]
        private void comenzarCarga()
        {
            pgCircular.Start();

            dgv.DataSource = null;
            dgvLoc.DataSource = null;

            dgvLoc.Columns.Clear();

            hilo = new Thread(new ThreadStart(cargarDatos));
            hilo.Start();
        }

        private void cargarDatos()
        {
            try
            {
                dtLoc = oLoc.Listar();

                dtZonas = oZona.Listar();
                dtZonaLoc = oZona.ListarLocZonas(0);

                dtZonaLocalidades = dtZonaLoc.Clone();

                foreach (DataRow dr in dtZonaLoc.Rows)
                    dtZonaLocalidades.ImportRow(dr);

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
            dgv.DataSource = dtZonas;

            dgv.Columns["Id"].HeaderText = "Codigo";
            dgv.Columns["Id"].Visible = false;
            dgv.Columns["Id"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns["Nombre"].HeaderText = "Zona";
            dgv.Columns["Borrado"].Visible = false;

            lblTotal.Text = String.Format("Total de Registros: {0}", dtZonas.Rows.Count);

            dgvLoc.DataSource = dtZonaLoc;
            dgvLoc.Columns["Id"].Visible = false;
            dgvLoc.Columns["Id_Zona"].Visible = false;
            dgvLoc.Columns["Id_Localidad"].Visible = false;

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


            if (dtZonas.Rows.Count > 0)
                txtId.Text = dtZonas.Rows[0]["Id"].ToString();

            asignarValores();

            cboLocalidad.DataSource = dtLoc;
            cboLocalidad.ValueMember = "Id";
            cboLocalidad.DisplayMember = "Nombre";
            controles(false);
            if (dtZonas.Rows.Count == 0)
            {
                btnEditar.Enabled = false;
                btnEliminar.Enabled = false;
            }
        }

        private void controles(bool state)
        {
            btnActualizar.Enabled = !state;
            btnNuevo.Enabled = !state;
            btnEditar.Enabled = !state;
            btnEliminar.Enabled = !state;

            dgv.Enabled = !state;

            txtNombre.Enabled = state;
            cboLocalidad.Enabled = state;

            btnAgregarLoc.Enabled = state;

            btnGuardar.Enabled = state;
            btnCancelar.Enabled = state;
        }

        private void limpiarValores()
        {
            txtId.Text = "";
            txtNombre.Text = "";
        }

        private void asignarValores()
        {
            try
            {
                DataView dvLoc = dtZonaLoc.DefaultView;

                int id_zona = 0;

                if (txtId.Text != "0")
                {
                    txtId.Text = dgv.SelectedRows[0].Cells["Id"].Value.ToString();
                    txtNombre.Text = dgv.SelectedRows[0].Cells["Nombre"].Value.ToString();
                    txtNombre.Tag = dgv.SelectedRows[0].Cells["Nombre"].Value.ToString();

                    id_zona = Convert.ToInt32(dgv.SelectedRows[0].Cells["Id"].Value.ToString());
                }

                dvLoc.RowFilter = String.Format("Id_Zona = {0}", id_zona);

                dgvLoc.DataSource = dvLoc.ToTable();
            }
            catch { }
        }

        private void nuevoRegistro()
        {
            dgvLoc.DataSource = null;

            dgvLoc.Columns.Clear();

            txtId.Text = "0";
            txtNombre.Text = "";

            dtZonaLoc.Rows.Clear();

            dgvLoc.DataSource = dtZonaLoc;
            dgvLoc.Columns["Id"].Visible = false;
            dgvLoc.Columns["Id_Zona"].Visible = false;
            dgvLoc.Columns["Id_Localidad"].Visible = false;

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
                    oZona.Eliminar(Convert.ToInt32(txtId.Text));

                    comenzarCarga();
                }
                catch { }
            }
        }

        private void guardarRegistro()
        {
            if (txtNombre.Text.Length == 0)
                txtNombre.Focus();
            else
            {
                if (dtZonaLoc.Rows.Count == 0)
                {
                    MessageBox.Show("Debe Ingresar al Menos una Localidad", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    if (validarDatos())
                    {
                        oZona.Id = Convert.ToInt32(txtId.Text);
                        oZona.Nombre = txtNombre.Text;

                        oZona.Guardar(oZona, dtZonaLoc);

                        comenzarCarga();
                    }
                }
            }
        }

        private void cancelarEdicion()
        {
            controles(false);
        }

        private bool validarDatos()
        {
            //if (txtNombre.Tag.ToString() != txtNombre.Text && txtNombre.Text.Length > 0)
            //{
            //    DataRow[] dr = dtSer.Select(String.Format("Descripcion = '{0}'", txtNombre.Text.ToUpper()));

            //    if (dr.Count() > 0)
            //    {
            //        MessageBox.Show("El Valor ingresado ya Existe", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            //        return false;
            //    }
            //}

            return true;
        }
        #endregion

        private void ABMZonas_Load(object sender, EventArgs e)
        {
            comenzarCarga();
        }

        private void ABMZonas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
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
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            guardarRegistro();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            cancelarEdicion();
        }

        private void btnAgregarLoc_Click(object sender, EventArgs e)
        {
            int id_zona = Convert.ToInt32(txtId.Text);
            int id_localidad = Convert.ToInt32(cboLocalidad.SelectedValue);
            DataRow drDatosLoc = oLoc.TraerDatosLocalidad(id_localidad);
            DataRow[] drFilter = dtZonaLoc.Select(String.Format("Id_Zona = {0} and Id_Localidad = {1}", id_zona, id_localidad));

            if (drFilter.Length > 0)
                MessageBox.Show("La Localidad Seleccionada ya se encuentra ingresada", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else
            {
                DataRow[] drFilterZon = dtZonaLocalidades.Select(String.Format("Id_Localidad = {0}", id_localidad));

                if (drFilterZon.Length > 0)
                    MessageBox.Show("La Localidad Seleccionada ya se encuentra ingresada a otra zona", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                else
                {
                    if (txtId.Text == "0")
                        dtZonaLoc.Rows.Add(0, 0, Convert.ToInt32(cboLocalidad.SelectedValue), cboLocalidad.Text);
                    else
                        dtZonaLoc.Rows.Add(0, id_zona, Convert.ToInt32(cboLocalidad.SelectedValue), cboLocalidad.Text, drDatosLoc["Codigo_Postal"].ToString());

                    dtZonaLoc.AcceptChanges();

                    asignarValores();
                }
            }
        }

        private void dgv_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            asignarValores();
        }

        private void dgv_SelectionChanged(object sender, EventArgs e)
        {
            asignarValores();
        }

        private void dgvLoc_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvLoc.Columns[e.ColumnIndex].GetType() == typeof(DataGridViewLinkColumn))
            {
                if (dgvLoc.Rows[e.RowIndex].Selected == true)
                    ((DataGridViewLinkCell)dgvLoc.Rows[e.RowIndex].Cells[e.ColumnIndex]).LinkColor = Color.White;
                else
                    ((DataGridViewLinkCell)dgvLoc.Rows[e.RowIndex].Cells[e.ColumnIndex]).LinkColor = ((DataGridViewLinkColumn)dgvLoc.Columns[e.ColumnIndex]).LinkColor;
            }
        }

        private void dgvLoc_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                if (MessageBox.Show("¿Desea Eliminar la Localidad Seleccionada?", "Mensaje del Sistema", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    int id = Convert.ToInt32(dgvLoc.SelectedRows[0].Cells["Id"].Value.ToString());
                    int id_localidad = Convert.ToInt32(dgvLoc.SelectedRows[0].Cells["Id_Localidad"].Value.ToString());
                    int id_zona = Convert.ToInt32(dgvLoc.SelectedRows[0].Cells["Id_Zona"].Value.ToString());

                    DataRow[] drFilter = dtZonaLoc.Select(String.Format("Id = {0} and Id_Localidad = {1}", id, id_localidad));

                    foreach (var item in drFilter)
                        item.Delete();

                    dtZonaLoc.AcceptChanges();

                    if (id > 0)
                        oZona.Eliminar_Localidad(id);

                    asignarValores();
                }
            }
        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
