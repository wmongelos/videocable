using CapaNegocios;
using System;
using System.Data;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace CapaPresentacion.Abms
{
    public partial class ABMPuntosGestion : Form
    {
        private Puntos_Cobros oPuntos_Cobros = new Puntos_Cobros();
        private Thread hilo;
        private delegate void myDel();
        private DataTable dt;
        private DataTable dtCompHabilitados = new DataTable();
        private Puntos_Venta_Comp oPuntosVentaComp = new Puntos_Venta_Comp();
        private int Id;
        public ABMPuntosGestion()
        {
            InitializeComponent();
        }

        private void ABMPuntosCobros_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
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
                dt = oPuntos_Cobros.Listar();
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
            DataGridViewLinkColumn colComprobantesHab = new DataGridViewLinkColumn();
            colComprobantesHab.HeaderText = "Comprobantes habilitados";
            colComprobantesHab.Text = "Asignar";
            colComprobantesHab.UseColumnTextForLinkValue = true;
            colComprobantesHab.Name = "colComprobantesHab";
            int control = 0;

            foreach (DataGridViewColumn columna in dgv.Columns)
            {
                if (columna.Index == dgv.Columns["colComprobantesHab"].Index)
                {
                    control = 1;
                    break;
                }
            }
            if (control == 1)
                dgv.Columns.RemoveAt(dgv.Columns["colComprobantesHab"].Index);

            dgv.DataSource = dt;
            dgv.Columns.Add(colComprobantesHab);
            dgv.Columns["id"].Visible = false;
            dgv.Columns["Descripcion"].HeaderText = "Descripcion";
            dgv.Columns["punto"].Visible = false;
            dgv.Columns["numero_factura_a"].Visible = false;
            dgv.Columns["numero_factura_b"].Visible = false;
            dgv.Columns["tipo_sucursal"].HeaderText = "Tipo Sucursal";
            dgv.Columns["tipo_facturacion"].Visible = false;
            dgv.Columns["colComprobantesHab"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            lblTotal.Text = String.Format("Total de Registros: {0}", dt.Rows.Count);
            controles(false);
            asignarValores();
        }

        private void controles(bool state)
        {
            btnActualizar.Enabled = !state;
            btnNuevo.Enabled = !state;
            btnEditar.Enabled = dt.Rows.Count == 0 ? false : !state;
            btnEliminar.Enabled = dt.Rows.Count == 0 ? false : !state;
            dgv.Enabled = !state;
            txtDescripcion.Enabled = state;
            btnGuardar.Enabled = state;
            btnCancelar.Enabled = state;
            cbTipoSucu.Enabled = state;
        }

        private void asignarValores()
        {
            try
            {
                Id = Convert.ToInt32(dgv.SelectedRows[0].Cells["id"].Value);
                txtDescripcion.Text = dgv.SelectedRows[0].Cells["Descripcion"].Value.ToString();
                txtDescripcion.Tag = dgv.SelectedRows[0].Cells["Descripcion"].Value.ToString();
                cbTipoSucu.Text = dgv.SelectedRows[0].Cells["Tipo_Sucursal"].Value.ToString();
                dtCompHabilitados = oPuntosVentaComp.ListarPorPtoCobro(Convert.ToInt32(dgv.SelectedRows[0].Cells["id"].Value));
                dgvCompHabilitados.DataSource = dtCompHabilitados;
                dgvCompHabilitados.Columns["numPuntoVenta"].HeaderText = "Punto de venta";
                dgvCompHabilitados.Columns["numPtoVentaComp"].HeaderText = "Numeración del comprobante";
                dgvCompHabilitados.Columns["predeterminado"].HeaderText = "Predeterminado";
                dgvCompHabilitados.Columns["Id_Punto_Cobro"].Visible = false;
                dgvCompHabilitados.Columns["IdTipoComprobante"].Visible = false;
                dgvCompHabilitados.Columns["idPuntoVenta"].Visible = false;
                dgvCompHabilitados.Columns["id_Punto_Vta_Comp"].Visible = false;
                dgvCompHabilitados.Columns["numPuntoVenta"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvCompHabilitados.Columns["numPtoVentaComp"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvCompHabilitados.Columns["predeterminado"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvCompHabilitados.Columns["Letra"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            catch { }
        }

        private void LimpiarValores()
        {
            Id = 0;
            txtDescripcion.Text = "";
        }

        private void nuevoRegistro()
        {
            Id = 0;
            txtDescripcion.Text = "";
            cbTipoSucu.SelectedIndex = 0;
            txtDescripcion.Focus();
        }

        private void editarRegistro()
        {
            txtDescripcion.Enabled = true;
            cbTipoSucu.Enabled = true;
            txtDescripcion.Focus();
        }

        private void eliminarRegistro()
        {
            if (MessageBox.Show("¿Desea eliminar el Registro Seleccionado?", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                oPuntos_Cobros.Eliminar(Id);
                comenzarCarga();
            }
        }

        private void guardarRegistro()
        {
            if (txtDescripcion.Text.Length == 0)
            {
                MessageBox.Show("Ingrese una descripcion", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtDescripcion.Focus();
            }
            else
            {
                if (validarDatos())
                {
                    oPuntos_Cobros.Id = Id;
                    oPuntos_Cobros.Descripcion = txtDescripcion.Text.ToUpper();
                    oPuntos_Cobros.Punto = 0;
                    oPuntos_Cobros.Numero_Factura_A = 0;
                    oPuntos_Cobros.Numero_Factura_B = 0;
                    oPuntos_Cobros.Tipo_Facturacion = "";
                    oPuntos_Cobros.Tipo_Sucursal = cbTipoSucu.Text.ToString();
                    oPuntos_Cobros.Guardar(oPuntos_Cobros);

                    if (Id == 0)
                    {
                        ABMPuntosGestion_CompHabilitados ABMCompHabilitados = new ABMPuntosGestion_CompHabilitados(oPuntos_Cobros.Id, oPuntos_Cobros.Tipo_Sucursal, oPuntos_Cobros.Descripcion);
                        frmPopUp frmpopup = new frmPopUp();
                        frmpopup.Maximizar = false;
                        frmpopup.Formulario = ABMCompHabilitados;
                        frmpopup.ShowDialog();
                    }
                    comenzarCarga();
                }
            }
        }

        private bool validarDatos()
        {
            if (txtDescripcion.Tag.ToString() != txtDescripcion.Text && txtDescripcion.Text.Length > 0)
            {
                DataRow[] dr = dt.Select(String.Format("Descripcion = '{0}'", txtDescripcion.Text.ToUpper()));
                if (dr.Count() > 0)
                {
                    MessageBox.Show("El Valor ingresado ya Existe", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
            }
            return true;
        }

        private void cancelarEdicion()
        {
            controles(false);
        }

        private void ABMPuntosCobros_Load(object sender, System.EventArgs e)
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
            limpiarValores();
            controles(true);

            nuevoRegistro();
        }

        private void limpiarValores()
        {
            txtDescripcion.Text = "";
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
            controles(true);
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

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == dgv.SelectedRows[0].Cells["colComprobantesHab"].ColumnIndex)
                {
                    ABMPuntosGestion_CompHabilitados ABMCompHab = new ABMPuntosGestion_CompHabilitados(Convert.ToInt32(dgv.SelectedRows[0].Cells["id"].Value), dgv.SelectedRows[0].Cells["Tipo_Sucursal"].Value.ToString(), dgv.SelectedRows[0].Cells["descripcion"].Value.ToString());
                    frmPopUp frmpopup = new frmPopUp();
                    frmpopup.Maximizar = false;
                    frmpopup.Formulario = ABMCompHab;
                    frmpopup.ShowDialog();
                    if (ABMCompHab.DialogResult == DialogResult.OK)
                        comenzarCarga();
                }
            }
            catch
            {

            }
        }
    }
}
