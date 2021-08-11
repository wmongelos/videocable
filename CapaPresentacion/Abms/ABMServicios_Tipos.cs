using CapaNegocios;
using System;
using System.Data;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace CapaPresentacion.Abms
{
    public partial class ABMServicios_Tipos : Form
    {
        private Thread hilo;
        private delegate void myDel();
        private DataTable dt;
        private DataTable dtServicios_Grupos;
        private Tablas oTablas = new Tablas();
        DataTable dtIdServicioTipo = new DataTable();
        private Servicios_Tipos oSerTipo = new Servicios_Tipos();
        private Servicios oSer = new Servicios();
        private Partes oPartes = new Partes();

        public ABMServicios_Tipos()
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
                dt = oSerTipo.Listar();
                dtServicios_Grupos = oSer.ListarGrupos();


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

            dgv.Columns["Id"].HeaderText = "Codigo";
            dgv.Columns["Id"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns["Id_Servicios_Grupos"].Visible = false;
            dgv.Columns["Nombre"].HeaderText = "Tipo de Servicios";
            dgv.Columns["Grupo"].HeaderText = "Grupo de Servicios";
            dgv.Columns["Borrado"].Visible = false;




            dgv.Columns["Id"].Visible = false;
            dgv.Columns["Borrado"].Visible = false;



            lblTotal.Text = String.Format("Total de Registros: {0}", dt.Rows.Count);

            cboServicios_Grupos.DataSource = dtServicios_Grupos;
            cboServicios_Grupos.DisplayMember = "Nombre";
            cboServicios_Grupos.ValueMember = "Id";

            controles(false);
            asignarValores();
        }

        private void controles(bool state)
        {
            btnActualizar.Enabled = !state;
            btnNuevo.Enabled = !state;
            btnEditar.Enabled = !state;
            btnEliminar.Enabled = !state;

            dgv.Enabled = !state;

            txtNombre.Enabled = state;
            cboServicios_Grupos.Enabled = state;

            btnGuardar.Enabled = state;
            btnCancelar.Enabled = state;

        }

        private void limpiarValores()
        {
            txtId.Text = "";
            txtId.Tag = "";
            txtNombre.Text = "";
        }

        private void asignarValores()
        {
            try
            {
                txtId.Text = dgv.SelectedRows[0].Cells["Id"].Value.ToString();
                txtNombre.Text = dgv.SelectedRows[0].Cells["Nombre"].Value.ToString();
                txtNombre.Tag = dgv.SelectedRows[0].Cells["Nombre"].Value.ToString();

                cboServicios_Grupos.SelectedValue = Convert.ToInt32(dgv.SelectedRows[0].Cells["Id_Servicios_Grupos"].Value);
            }
            catch { }
        }

        private void nuevoRegistro()
        {
            txtId.Text = "0";
            txtNombre.Text = "";
            txtNombre.Enabled = true;
            cboServicios_Grupos.Enabled = true;
            txtNombre.Focus();
        }

        private void editarRegistro()
        {
            txtNombre.Enabled = true;
            cboServicios_Grupos.Enabled = true;
            txtNombre.Focus();
        }

        private void eliminarRegistro()
        {
            if (dgv.Rows.Count > 0)
            {
                int ServTipo = Convert.ToInt32(txtId.Text);
                dtIdServicioTipo = oSerTipo.ListarIdServicioTipo(ServTipo);
                if (dtIdServicioTipo.Rows.Count == 0)
                {
                    if (MessageBox.Show("¿Desea eliminar el Registro Seleccionado?", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        oSerTipo.Eliminar(ServTipo);
                        comenzarCarga();
                    }
                }
                else
                {
                    MessageBox.Show("No se puede eliminar el servicio, tiene servicios asociados.");
                }
            }
            else
                MessageBox.Show("No hay datos en la grilla.");
        }

        private void guardarRegistro()
        {
            if (txtNombre.Text.Length == 0)
                txtNombre.Focus();
            else
            {
                if (validarDatos())
                {
                    oSerTipo.Id = Convert.ToInt32(txtId.Text);
                    oSerTipo.Id_Servicios_Grupos = Convert.ToInt32(cboServicios_Grupos.SelectedValue);
                    oSerTipo.Nombre = txtNombre.Text.ToUpper();
                    oSerTipo.Guardar(oSerTipo);
                    Tablas.LoadServiciosTipos();
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
                DataRow[] dr = dt.Select(String.Format("Nombre = '{0}'", txtNombre.Text.ToUpper()));

                if (dr.Count() > 0)
                {
                    MessageBox.Show("El Valor ingresado ya Existe", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    return false;
                }
            }

            return true;
        }

        private void ABMServicios_Tipos_Load(object sender, EventArgs e)
        {
            comenzarCarga();
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



        private void ABMServicios_Tipos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgv_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            asignarValores();
        }
    }
}//171019-12:48fede
