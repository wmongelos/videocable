using CapaNegocios;
using System;
using System.Data;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace CapaPresentacion.Abms
{
    public partial class ABMEquipos_Marcas : Form
    {
        private Thread hilo;
        private delegate void myDel();
        private DataTable dt, dtEquiposMarcas;
        private Equipos_Tipos oEquipo_Tipo = new Equipos_Tipos();
        private Equipos_Marcas oEquipo_Marca = new Equipos_Marcas();
        private int Id = 0;
        public bool AgregaExistente = false;
        public string NombreMarca = "";
        public ABMEquipos_Marcas()
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

                dt = oEquipo_Marca.Listar();

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

            dgv.Columns["Nombre"].Visible = true;
            dgv.Columns["Nombre"].HeaderText = "Marca de Equipos";
            lblTotal.Text = String.Format("Total de Registros: {0}", dt.Rows.Count);

            asignarValores();
            if (AgregaExistente)
            {
                txtNombre.Text = NombreMarca;
                controles(true);
                btnGuardar.Focus();

            }
            else
                controles(false);

        }

        private void DesabilitarControles()
        {
            btnActualizar.Enabled = false;
            btnNuevo.Enabled = false;
            btnEliminar.Enabled = false;
            btnEditar.Enabled = false;
            btnGuardar.Enabled = false;
            btnCancelar.Enabled = false;
        }
        private void controles(bool state)
        {
            btnActualizar.Enabled = !state;
            btnNuevo.Enabled = !state;
            btnEditar.Enabled = !state;
            btnEliminar.Enabled = !state;

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
                Id = Convert.ToInt32(dgv.SelectedRows[0].Cells["Id"].Value);
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
            int idEquipoMarca = Convert.ToInt32(dgv.SelectedRows[0].Cells["id"].Value);
            dtEquiposMarcas = oEquipo_Marca.VerificaMarcaNula(idEquipoMarca);
            if (dtEquiposMarcas.Rows.Count == 0)
            {
                if (MessageBox.Show("¿Desea eliminar el Registro Seleccionado?", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    oEquipo_Marca.Eliminar(Id);
                    comenzarCarga();
                }
            }
            else
            {
                if (MessageBox.Show("¡HAY EQUIPO/S ASIGNADO/S A ESTA MARCA!¿Desea eliminar el Registro Seleccionado de cualquier forma? ", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    oEquipo_Marca.EliminaidMarca(Id);
                    oEquipo_Marca.Eliminar(Id);
                    comenzarCarga();
                }
                else
                {
                    MessageBox.Show("No se puede eliminar. Hay equipos asignados a esta marca!");
                }
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

                    oEquipo_Marca.Id = Convert.ToInt32(Id);
                    oEquipo_Marca.Nombre = txtNombre.Text.ToUpper();
                    if (oEquipo_Marca.Guardar(oEquipo_Marca))
                    {
                        MessageBox.Show("Marca guardada correctamente","Mensaje del Sistema",MessageBoxButtons.OK,MessageBoxIcon.Information);
                        if (AgregaExistente)
                            this.DialogResult = DialogResult.OK;
                        else
                            comenzarCarga();

                    }
                    else
                        MessageBox.Show("Hubo un error al intentar guardar la marca del equipo", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);


                }
            }
        }

        private void cancelarEdicion()
        {
            controles(false);
        }

        private bool validarDatos()
        {
            if (txtNombre.Text.Length > 0)
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

        private void ABMEquipos_Marcas_Load(object sender, EventArgs e)
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
            if (AgregaExistente)
                this.DialogResult = DialogResult.OK;
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

        private void dgv_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            asignarValores();
        }

        private void ABMEquipos_Marcas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
