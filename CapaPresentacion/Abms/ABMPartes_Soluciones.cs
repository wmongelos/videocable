using CapaNegocios;
using System;
using System.Data;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace CapaPresentacion.Abms
{
    public partial class ABMPartes_Soluciones : Form
    {
        private Thread hilo;
        private delegate void myDel();
        private DataTable dtFallas;
        private DataTable dtSoluciones;
        private DataTable dtServicios_Tipos;
        private Servicios_Tipos oSer = new Servicios_Tipos();
        private Partes oPartes = new Partes();
        private Partes_Solicitudes oPartes_Falla = new Partes_Solicitudes();
        private Partes_Soluciones oPartes_Soluciones = new Partes_Soluciones();
        private int IdSolucion = 0, PosicionSeleccionada = -1, Flag = 0, indexcbo, id_tipo_servicio;
        private int Id = 0;

        public ABMPartes_Soluciones()
        {
            InitializeComponent();
        }

        private void comenzarCarga()
        {
            pgCircular.Start();
            dgvFallas.DataSource = null;
            hilo = new Thread(new ThreadStart(cargarDatos));
            hilo.Start();
        }

        private void cargarDatos()
        {
            try
            {
                dtFallas = oPartes_Falla.Listar();
                dtServicios_Tipos = oSer.Listar();
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

            if (Flag == 0)
            {
                dtFallas.DefaultView.RowFilter = "id_servicios_tipos='" + dtServicios_Tipos.Rows[0]["id"].ToString() + "'";
            }
            else
            {
                dtFallas.DefaultView.RowFilter = "id_servicios_tipos='" + id_tipo_servicio + "'";
            }
            dgvFallas.DataSource = dtFallas;
            dgvFallas.Columns["Id"].Visible = false;
            dgvFallas.Columns["Id"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvFallas.Columns["Id_Servicios_Tipos"].Visible = false;
            dgvFallas.Columns["Id_Partes_Operaciones"].Visible = false;
            dgvFallas.Columns["Nombre"].HeaderText = "Descripcion";
            dgvFallas.Columns["Aplica_app_externa"].Visible = false;
            dgvFallas.Columns["ServicioTipo"].Visible = false;
            dgvFallas.Columns["Cargo"].Visible = false;
            dgvFallas.Columns["Borrado"].Visible = false;
            dgvFallas.Columns["conCargo"].Visible = false;
            dgvFallas.Columns["origen"].Visible = false;
            dgvFallas.Columns["Dias_Resolucion"].Visible = false;
            dgvFallas.Columns["id_iva_alicuotas"].Visible = false;

            dgvFallas.Sort(dgvFallas.Columns["nombre"], System.ComponentModel.ListSortDirection.Ascending);



            if (Flag == 1)
            {
                dgvFallas.Rows[PosicionSeleccionada].Selected = true;

            }
            else
            {
                cboServicios_Tipos.DataSource = dtServicios_Tipos;
                cboServicios_Tipos.ValueMember = "Id";
                cboServicios_Tipos.DisplayMember = "Nombre";
            }

            controles(false);
            AsignarSoluciones();

        }

        public void AsignarSoluciones()
        {
            if (dgvFallas.SelectedRows.Count > 0)
            {
                dtSoluciones = oPartes_Soluciones.ListarSolucionesPorFalla(Convert.ToInt32(dgvFallas.SelectedRows[0].Cells["id"].Value));

                dgvSoluciones.DataSource = dtSoluciones;
                dgvSoluciones.Columns["Id"].Visible = false;
                dgvSoluciones.Columns["Id"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvSoluciones.Columns["Id_Falla"].Visible = false;
                dgvSoluciones.Columns["Id_Servicios"].Visible = false;
                dgvSoluciones.Columns["Id_Partes_Operaciones"].Visible = false;
                dgvSoluciones.Columns["Nombre"].HeaderText = "Descripcion";
                dgvSoluciones.Columns["Nombre"].Width = 500;
                dgvSoluciones.Columns["importe"].Visible = false;
                dgvSoluciones.Sort(dgvSoluciones.Columns["nombre"], System.ComponentModel.ListSortDirection.Ascending);
                lblTotal.Text = String.Format("Total de Registros: {0}", dgvSoluciones.Rows.Count);

                if (dtSoluciones.Rows.Count > 0)
                {

                    controles(false);
                    asignarValores();

                }

            }

        }

        private void controles(bool state)
        {
            btnActualizar.Enabled = !state;
            btnNuevo.Enabled = !state;
            btnEditar.Enabled = !state;
            btnEliminar.Enabled = !state;
            dgvFallas.Enabled = !state;
            dgvSoluciones.Enabled = !state;
            txtNombre.Enabled = state;

            btnGuardar.Enabled = state;
            btnCancelar.Enabled = state;
        }

        private void limpiarValores()
        {
            txtNombre.Text = "";
            txtNombre.Tag = "";
            IdSolucion = 0;
            Id = 0;
        }

        private void asignarValores()
        {
            try
            {
                Id = Convert.ToInt32(dgvFallas.SelectedRows[0].Cells["Id"].Value);

                if (dgvSoluciones.SelectedRows.Count > 0)
                {
                    IdSolucion = Convert.ToInt32(dgvSoluciones.SelectedRows[0].Cells["Id"].Value);
                    txtNombre.Text = dgvSoluciones.SelectedRows[0].Cells["Nombre"].Value.ToString();
                    txtNombre.Tag = dgvSoluciones.SelectedRows[0].Cells["Nombre"].Value.ToString();
                }

            }
            catch { }
        }

        private void nuevoRegistro()
        {
            IdSolucion = 0;
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
                oPartes_Soluciones.Eliminar(IdSolucion);
                PosicionSeleccionada = dgvFallas.SelectedRows[0].Index;
                indexcbo = Convert.ToInt32(cboServicios_Tipos.SelectedValue);
                limpiarValores();
                Flag = 1;
                comenzarCarga();
            }
        }

        private void guardarRegistro()
        {
            if (txtNombre.Text.Length == 0)
                txtNombre.Focus();
            else
            {
                if (validarDatos())
                {

                    oPartes_Soluciones.Id = Convert.ToInt32(IdSolucion);
                    oPartes_Soluciones.Id_Falla = Convert.ToInt32(Id);
                    oPartes_Soluciones.Nombre = txtNombre.Text.ToUpper();

                    oPartes_Soluciones.Id_Partes_Operaciones = Convert.ToInt32(dtFallas.Select("id=" + oPartes_Soluciones.Id_Falla + "")[0]["id_partes_operaciones"]);
                    oPartes_Soluciones.Id_Servicios = Convert.ToInt32(cboServicios_Tipos.SelectedValue);

                    id_tipo_servicio = Convert.ToInt32(cboServicios_Tipos.SelectedValue);
                    PosicionSeleccionada = dgvFallas.SelectedRows[0].Index;
                    oPartes_Soluciones.Guardar(oPartes_Soluciones);
                    limpiarValores();
                    Flag = 1;
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
                if (dtSoluciones != null && dtSoluciones.Rows.Count > 0)
                {
                    DataRow[] dr = dtSoluciones.Select(String.Format("Nombre = '{0}'", txtNombre.Text.ToUpper()));
                    if (dr.Count() > 0)
                    {
                        MessageBox.Show("El Valor ingresado ya Existe", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return false;
                    }
                }
            }
            return true;
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            controles(false);
            Flag = 0;
            comenzarCarga();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            if (dgvFallas.SelectedRows.Count > 0)
            {
                controles(true);
                limpiarValores();
                asignarValores();
                nuevoRegistro();
            }
            else
                MessageBox.Show("No ha seleccionado una falla.");
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvSoluciones.Rows.Count > 0)
            {
                controles(true);
                asignarValores();
                editarRegistro();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvSoluciones.Rows.Count > 0)
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

        public void dgv_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            limpiarValores();
            AsignarSoluciones();
        }

        private void ABMPartes_Soluciones_Load(object sender, EventArgs e)
        {
            comenzarCarga();
        }

        private void ABMPartes_Soluciones_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void dgvSoluciones_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            asignarValores();
        }

        private void cboServicios_Tipos_SelectedIndexChanged(object sender, EventArgs e)
        {
            dtFallas.DefaultView.RowFilter = "ServicioTipo = '" + Convert.ToString(cboServicios_Tipos.Text) + "'";
            lblTotal.Text = String.Format("Total de Registros: {0}", dtFallas.Rows.Count);
            dgvFallas.DataSource = dtFallas;
            if (dgvFallas.Rows.Count > 0)
                AsignarSoluciones();
            else
                dgvSoluciones.DataSource = null;

        }


        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvFallas_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void CargarFallas(int id_tipo_servicio, int posicion)
        {
            dtFallas = oPartes_Falla.Listar();
            dtFallas.DefaultView.RowFilter = "id_servicios_tipos='" + id_tipo_servicio + "'";
            dgvFallas.DataSource = dtFallas;
            dgvFallas.Columns["Id"].Visible = false;
            dgvFallas.Columns["Id"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvFallas.Columns["Id_Servicios_Tipos"].Visible = false;
            dgvFallas.Columns["Id_Partes_Operaciones"].Visible = false;
            dgvFallas.Columns["Nombre"].HeaderText = "Descripcion";
            dgvFallas.Columns["Aplica_app_externa"].Visible = false;
            dgvFallas.Columns["ServicioTipo"].Visible = false;
            dgvFallas.Columns["Cargo"].Visible = false;
            dgvFallas.Columns["Borrado"].Visible = false;
            dgvFallas.Columns["conCargo"].Visible = false;
            dgvFallas.Sort(dgvFallas.Columns["nombre"], System.ComponentModel.ListSortDirection.Ascending);
            dgvFallas.Rows[posicion].Selected = true;
            limpiarValores();
            AsignarSoluciones();


        }
    }
}
