using CapaNegocios;
using System;
using System.Data;
using System.Threading;
using System.Windows.Forms;

namespace CapaPresentacion.Abms
{
    public partial class ABMBonificaciones_Repeticion : Form
    {
        private DataTable DtPorcentajes = new DataTable();
        private Bonificaciones_Aplicacion_Condiciones oBonifApCondiciones = new Bonificaciones_Aplicacion_Condiciones();
        private Bonificaciones_Condiciones_Porcentaje oBonifCondPorcentaje = new Bonificaciones_Condiciones_Porcentaje();
        private Thread hilo;
        private delegate void myDel();
        private DataGridViewRow filaGrilla = new DataGridViewRow();
        private int idPorcentaje = 0;

        private void ComenzarCarga()
        {
            pgCircular.Start();
            hilo = new Thread(new ThreadStart(CargarDatos));
            hilo.IsBackground = true;
            hilo.Start();
        }

        private void CargarDatos()
        {
            try
            {
                DtPorcentajes = oBonifCondPorcentaje.ListarPorIdCondicion(oBonifApCondiciones.Id);
                myDel MD = new myDel(AsignarDatos);
                this.Invoke(MD, new object[] { });
                pgCircular.Stop();
            }
            catch (Exception e)
            {
                MessageBox.Show("Error: " + e.Message);
            }
        }

        private void AsignarDatos()
        {
            dgvPorcentajes.DataSource = DtPorcentajes;
            for (int x = 0; x < dgvPorcentajes.Columns.Count; x++)
                dgvPorcentajes.Columns[x].Visible = false;
            dgvPorcentajes.Columns["porcentaje"].Visible = true;
            dgvPorcentajes.Columns["desde"].Visible = true;
            dgvPorcentajes.Columns["hasta"].Visible = true;

            if (oBonifApCondiciones.Id > 0)
            {
                spCantidadAContemplar.Value = oBonifApCondiciones.Cantidad;
                spCantidadAContemplar.Enabled = false;
                Controles(false);
            }
            else
            {
                spCantidadAContemplar.Value = 1;
                spCantidadAContemplar.Enabled = true;
                spCantidadAContemplar.Focus();
                Controles(true);
            }

            spItemDesde.Minimum = spCantidadAContemplar.Minimum;
            spItemDesde.Maximum = spCantidadAContemplar.Value;
            spItemHasta.Minimum = spCantidadAContemplar.Minimum;
            spItemHasta.Maximum = spCantidadAContemplar.Value;
            cboLimiteDesde.SelectedIndex = 0;
            AsignarValores();
            lblTotal.Text = String.Format("Total de Registros: {0}", dgvPorcentajes.Rows.Count);
        }

        private void AsignarValores()
        {
            if (dgvPorcentajes.Rows.Count > 0)
            {
                if (dgvPorcentajes.SelectedRows.Count > 0)
                    filaGrilla = dgvPorcentajes.SelectedRows[0];
                else
                    filaGrilla = dgvPorcentajes.Rows[0];
                spPorcentaje.Value = Convert.ToDecimal(filaGrilla.Cells["porcentaje"].Value);
                cboLimiteDesde.Text = filaGrilla.Cells["limite_desde"].Value.ToString();
                spItemDesde.Value = Convert.ToDecimal(filaGrilla.Cells["item_desde"].Value);
                if (Convert.ToDecimal(filaGrilla.Cells["item_hasta"].Value) == 0)
                    spItemHasta.Value = spItemDesde.Value;
                else
                    spItemHasta.Value = Convert.ToDecimal(filaGrilla.Cells["item_hasta"].Value);
                idPorcentaje = Convert.ToInt32(filaGrilla.Cells["id"].Value);
                if (filaGrilla.Cells["limite_hasta"].Value.ToString() == "0")
                    chkHasta.Checked = false;
                else
                    chkHasta.Checked = true;
            }
        }

        private void Controles(bool state)
        {
            btnActualizar.Enabled = !state;
            btnNuevo.Enabled = !state;
            btnGuardar.Enabled = state;
            btnCancelar.Enabled = state;
            btnEditar.Enabled = DtPorcentajes.Rows.Count == 0 ? false : !state;
            btnEliminar.Enabled = DtPorcentajes.Rows.Count == 0 ? false : !state;
            dgvPorcentajes.Enabled = !state;
            panelControles.Enabled = state;
        }

        private void LimpiarDatos()
        {
            spPorcentaje.Value = spPorcentaje.Minimum;
            cboLimiteDesde.SelectedIndex = 0;
            spItemDesde.Value = spItemDesde.Minimum;
            spItemHasta.Value = spItemHasta.Minimum;
            spItemHasta.Enabled = false;
            chkHasta.Checked = false;
            idPorcentaje = 0;
        }

        private void GuardarRegistro()
        {
            oBonifApCondiciones.Cantidad = Convert.ToInt32(spCantidadAContemplar.Value);
            if (oBonifApCondiciones.Id == 0)
                oBonifApCondiciones.Id = oBonifApCondiciones.Guardar(oBonifApCondiciones);
            if (oBonifApCondiciones.Id > 0)
            {
                oBonifCondPorcentaje.Id = idPorcentaje;
                oBonifCondPorcentaje.Id_Condicion = oBonifApCondiciones.Id;
                oBonifCondPorcentaje.Porcentaje = spPorcentaje.Value;
                oBonifCondPorcentaje.Item_Desde = spItemDesde.Value.ToString();
                oBonifCondPorcentaje.Limite_Desde = cboLimiteDesde.Text.ToString();

                if (chkHasta.Checked == true)
                {
                    oBonifCondPorcentaje.Item_Hasta = spItemHasta.Value.ToString();
                    oBonifCondPorcentaje.Limite_Hasta = "=";
                }
                else
                {
                    oBonifCondPorcentaje.Item_Hasta = "0";
                    oBonifCondPorcentaje.Limite_Hasta = "0";
                }
                oBonifCondPorcentaje.Guardar(oBonifCondPorcentaje);

                MessageBox.Show("Datos cargados correctamente.");
                ComenzarCarga();
            }
        }

        private void EliminarRegistro()
        {
            oBonifCondPorcentaje.Eliminar(Convert.ToInt32(dgvPorcentajes.SelectedRows[0].Cells["id"].Value));
            ComenzarCarga();
        }

        private void EditarRegistro()
        {
            LimpiarDatos();
            AsignarValores();
        }

        public ABMBonificaciones_Repeticion(Bonificaciones_Aplicacion_Condiciones oBonificacionAplicacionCondiciones)
        {
            oBonifApCondiciones = oBonificacionAplicacionCondiciones;
            InitializeComponent();
        }

        private void frmRepeticion_Load(object sender, EventArgs e)
        {
            lblBonificacion.Text = String.Format("Bonificación: {0}", oBonifApCondiciones.Bonificacion_Nombre);
            lblAplicacion.Text = oBonifApCondiciones.Aplicacion;
            ComenzarCarga();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmRepeticion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            GuardarRegistro();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            LimpiarDatos();
            Controles(true);
        }

        private void chkHasta_CheckedChanged(object sender, EventArgs e)
        {
            if (chkHasta.Checked == true)
                spItemHasta.Enabled = true;
            else
                spItemHasta.Enabled = false;
        }

        private void spCantidadAContemplar_ValueChanged(object sender, EventArgs e)
        {
            spItemDesde.Minimum = spCantidadAContemplar.Minimum;
            spItemDesde.Maximum = spCantidadAContemplar.Value;
            spItemHasta.Minimum = spCantidadAContemplar.Minimum;
            spItemHasta.Maximum = spCantidadAContemplar.Value;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            EliminarRegistro();
        }

        private void dgvPorcentajes_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvPorcentajes.Rows.Count > 0)
                btnEliminar.Enabled = true;
            else
                btnEliminar.Enabled = false;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            AsignarValores();
            Controles(true);
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            ComenzarCarga();
        }

        private void dgvPorcentajes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            AsignarValores();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarDatos();
            Controles(false);
        }
    }
}
