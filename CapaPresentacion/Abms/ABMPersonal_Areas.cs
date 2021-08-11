using CapaNegocios;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace CapaPresentacion.Abms
{
    public partial class ABMPersonal_Areas : Form
    {
        #region [PROPIEDADES]
        private Thread hilo;
        private delegate void myDel();
        private DataTable dt, dtPersonal_Area;
        private Personal_Areas oPer_Areas = new Personal_Areas();
        private int Id;
        private int rowselect = 0;
        #endregion

        public ABMPersonal_Areas()
        {
            InitializeComponent();
        }

        #region[METODOS]
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
                dt = oPer_Areas.Listar();

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

            foreach (DataRow fila in dt.Rows)
            {
                if (fila["Req_horario"].ToString() == "1")
                    fila["Req_horario"] = "SI";
                else
                    fila["Req_horario"] = "NO";
            }

            dgv.DataSource = dt;

            dgv.Columns["Id"].Visible = false;
            dgv.Columns["Nombre"].HeaderText = "Area";
            dgv.Columns["Req_horario"].HeaderText = "Asignación horaria";
            dgv.Columns["Borrado"].Visible = false;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Light", 14, FontStyle.Regular);
            cmb_AsignacionH.SelectedIndex = 1;

            lblTotal.Text = String.Format("Total de Registros: {0}", dt.Rows.Count);

            controles(false);

            if (dt.Rows.Count > 0)
                dgv.CurrentCell = dgv.Rows[rowselect].Cells[1];

            asignarValores();
        }

        private void controles(bool state)
        {
            btnActualizar.Enabled = !state;
            btnNuevo.Enabled = !state;
            btnEditar.Enabled = dt.Rows.Count == 0 ? false : !state;
            btnEliminar.Enabled = dt.Rows.Count == 0 ? false : !state;

            dgv.Enabled = !state;

            txtArea.Enabled = state;
            cmb_AsignacionH.Enabled = state;
            btnGuardar.Enabled = state;
            btnCancelar.Enabled = state;

        }

        private void limpiarValores()
        {
            txtArea.Text = "";
            txtArea.Tag = "";
        }

        private void asignarValores()
        {
            try
            {
                Id = Convert.ToInt32(dgv.SelectedRows[0].Cells["Id"].Value);
                txtArea.Text = dgv.SelectedRows[0].Cells["Nombre"].Value.ToString();
                txtArea.Tag = dgv.SelectedRows[0].Cells["Nombre"].Value.ToString();
                cmb_AsignacionH.SelectedItem = dgv.SelectedRows[0].Cells["Req_horario"].Value.ToString();

            }
            catch { }
        }

        private void nuevoRegistro()
        {
            Id = 0;
            txtArea.Text = "";
            txtArea.Enabled = true;
            cmb_AsignacionH.Enabled = true;
            txtArea.Focus();
        }

        private void editarRegistro()
        {
            rowselect = dgv.SelectedRows[0].Index;

            txtArea.Enabled = true;
            cmb_AsignacionH.Enabled = true;
            txtArea.Focus();
        }

        private void eliminarRegistro()
        {
            int idArea = Convert.ToInt32(dgv.SelectedRows[0].Cells["id"].Value);
            dtPersonal_Area = oPer_Areas.ListarPersonalAreas(idArea);
            if (dtPersonal_Area.Rows.Count == 0)
            {
                if (MessageBox.Show("¿Desea eliminar el Registro Seleccionado?", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    oPer_Areas.Eliminar(Id);
                    rowselect = 0;
                    comenzarCarga();
                }
            }
            else
            {
                if (MessageBox.Show("¡HAY PERSONAL ASIGNADA AL AREA!¿Desea eliminar el Registro Seleccionado de cualquier forma? ", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    oPer_Areas.EliminaidPersonalAreas(Id);
                    oPer_Areas.Eliminar(Id);
                    rowselect = 0;
                    comenzarCarga();
                }
                else
                {
                    MessageBox.Show("Este area esta asignado a algun personal, por ende no puede eliminarse.");
                }
            }
        }

        private void guardarRegistro()
        {
            if (txtArea.Text.Length == 0)
                txtArea.Focus();
            else
            {
                if (validarDatos())
                {
                    oPer_Areas.Id = Id;
                    oPer_Areas.Nombre = txtArea.Text.ToUpper();

                    if (cmb_AsignacionH.SelectedItem == null || cmb_AsignacionH.SelectedItem.ToString() == "NO")
                        oPer_Areas.Req_horario = "0";
                    else
                        oPer_Areas.Req_horario = "1";

                    oPer_Areas.Guardar(oPer_Areas);


                    if (oPer_Areas.Id == 0)
                        rowselect = dgv.Rows.Count;

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
            bool resultado = false;

            if (txtArea.Text.Trim().Length > 0)
            {
                DataRow[] dr = null;

                if (Id != 0)
                    dr = dt.Select(String.Format("Nombre = '{0}' AND Id<>'{1}'", txtArea.Text.ToUpper(), Id));
                else
                    dr = dt.Select(String.Format("Nombre = '{0}'", txtArea.Text.ToUpper()));

                if (dr.Count() > 0)
                {
                    MessageBox.Show("El area '" + txtArea.Text.ToUpper() + "' ya existe", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    resultado = false;
                    txtArea.Focus();
                }
                else
                    resultado = true;
            }
            else
            {
                MessageBox.Show("Hay campos en blanco.", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtArea.Focus();
            }

            return resultado;
        }
        #endregion  

        private void ABMPersonal_Areas_Load(object sender, EventArgs e)
        {
            comenzarCarga();
            cmb_AsignacionH.Items.Add("SI");
            cmb_AsignacionH.Items.Add("NO");
        }

        private void ABMPersonal_Areas_KeyDown(object sender, KeyEventArgs e)
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

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
