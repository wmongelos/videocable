using CapaNegocios;
using System;
using System.Data;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace CapaPresentacion.Abms
{
    public partial class ABMTarifas : Form
    {
        private Thread hilo;
        private delegate void myDel();
        private DataTable dt;
        private Servicios_Tarifas oTarifa = new Servicios_Tarifas();
        private Int32 Posicion = 0;
        private frmPopUp oPop;
        private ABMTarifas_Editor_Serv oTarifasEditor;

        public ABMTarifas()
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
                dt = oTarifa.Listar();

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
            dt.Columns.Add("Vigente", typeof(String));
            foreach (DataRow item in dt.Rows)
            {
                int idTarifa = Convert.ToInt32(item["id"]);
                Boolean vigente = oTarifa.tarifaEsVigente(idTarifa);
                if (vigente == true)
                    item["Vigente"] = "VIGENTE";
                else
                    item["Vigente"] = "";
            }
            dgv.DataSource = dt;

            dgv.Columns["Id_Personal_Create"].Visible = false;
            dgv.Columns["Fecha_Create"].Visible = false;
            dgv.Columns["Id_Personal_Update"].Visible = false;
            dgv.Columns["Fecha_Update"].Visible = false;
            dgv.Columns["Id"].HeaderText = "Codigo";
            dgv.Columns["Id"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns["Nombre"].HeaderText = "Tarifa";
            dgv.Columns["Fecha_Desde"].HeaderText = "Desde";
            dgv.Columns["Fecha_Hasta"].HeaderText = "Hasta";
            dgv.Columns["Borrado"].Visible = false;
            dgv.Columns["Vigente"].Visible = true;
            dgv.Columns["Vigente"].HeaderText = "";


            if (Posicion > 0)
                dgv.Rows[Posicion].Selected = true;

            lblTotal.Text = String.Format("Total de Registros: {0}", dt.Rows.Count);

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
            dtpFechaDesde.Enabled = state;
            dtpFechaHasta.Enabled = state;

            btnGuardar.Enabled = state;
            btnCancelar.Enabled = state;

        }

        private void limpiarValores()
        {
            txtId.Text = "";
            txtNombre.Text = "";
            dtpFechaDesde.Value = DateTime.Now;
            dtpFechaHasta.Value = DateTime.Now;
        }

        private void asignarValores()
        {
            if (Posicion > 0)
                dgv.Rows[Posicion].Selected = true;

            try
            {
                txtId.Text = dgv.SelectedRows[0].Cells["Id"].Value.ToString();
                txtNombre.Text = dgv.SelectedRows[0].Cells["Nombre"].Value.ToString();
                txtNombre.Tag = dgv.SelectedRows[0].Cells["Nombre"].Value.ToString();
                dtpFechaDesde.Value = Convert.ToDateTime(dgv.SelectedRows[0].Cells["Fecha_Desde"].Value);
                dtpFechaHasta.Value = Convert.ToDateTime(dgv.SelectedRows[0].Cells["Fecha_Hasta"].Value);
            }
            catch { }
        }

        private void nuevoRegistro()
        {
            txtId.Text = "0";
            txtNombre.Text = "";
            dtpFechaDesde.Value = DateTime.Now;
            dtpFechaHasta.Value = DateTime.Now;
            txtNombre.Enabled = true;
            Posicion = 0;
            txtNombre.Focus();
            oTarifa.Id = 0;

        }

        private void editarRegistro()
        {

            txtNombre.Enabled = true;
            dtpFechaDesde.Enabled = true;
            dtpFechaHasta.Enabled = true;
            txtNombre.Focus();
            oTarifa.Id = Convert.ToInt32(dgv.SelectedRows[0].Cells["id"].Value);
        }

        private void eliminarRegistro()
        {
            if (MessageBox.Show("¿Desea eliminar el Registro Seleccionado?", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Posicion = 0;
                oTarifa.Eliminar(Convert.ToInt32(txtId.Text));

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
                    oTarifa.Id = Convert.ToInt32(txtId.Text);
                    oTarifa.Nombre = txtNombre.Text.ToUpper();
                    oTarifa.Fecha_Desde = dtpFechaDesde.Value;
                    oTarifa.Fecha_Hasta = dtpFechaHasta.Value;
                    oTarifa.Guardar(oTarifa, Personal.Id_Login);
                    comenzarCarga();

                }
            }
        }
        public bool IsDate(object inValue)
        {
            bool bValid;
            try
            {
                DateTime myDT = DateTime.Parse(inValue.ToString());
                bValid = true;
            }
            catch
            {
                bValid = false;
            }
            return bValid;
        }

        private void cancelarEdicion()
        {
            limpiarValores();
            controles(false);
            comenzarCarga();
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

            var resultadoCompraracion = DateTime.Compare(dtpFechaDesde.Value, dtpFechaHasta.Value);
            if (resultadoCompraracion == 0)
            {
                MessageBox.Show("La fecha desde no puede ser igual a la fecha hasta", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            else
            {
                if (resultadoCompraracion > 0)
                {
                    MessageBox.Show("La fecha desde no puede ser posterior a la fecha hasta", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        private void ABMTarifas_Load(object sender, EventArgs e)
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
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            DateTime fechaDesde = dtpFechaDesde.Value;
            DateTime fechaHasta = dtpFechaHasta.Value;
            DateTime fechaAux;
            //int idTarifaSeleccionada = Convert.ToInt32(Convert.ToInt32(dgv.SelectedRows[0].Cells["id"].Value));
            int idTarifa;
            int i = 0;
            string vigente;

            guardarRegistro();
            ABMTarifas_Editor_Serv ofrm = new ABMTarifas_Editor_Serv();
            frmPopUp oPop = new frmPopUp();
            oPop.Formulario = ofrm;
            oPop.Maximizar = false;
            oPop.ShowDialog();
            this.Close();
         }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            cancelarEdicion();
        }

        private void dgv_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            asignarValores();
        }

        private void ABMTarifas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgv_SelectionChanged(object sender, EventArgs e)
        {
            this.asignarValores();
        }

        private void btnVer_Click(object sender, EventArgs e)
        {
            oPop = new frmPopUp();
            oTarifasEditor = new ABMTarifas_Editor_Serv();
            oTarifasEditor.idTarifa = Convert.ToInt32(txtId.Text);
            oTarifasEditor.nombreTarifa = txtNombre.Text;
            oPop.Maximizar = true;
            oPop.Formulario = oTarifasEditor;
            oPop.ShowDialog();

        }
    }
}
