using CapaNegocios;
using System;
using System.Data;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace CapaPresentacion.Abms
{
    public partial class ABMFormasDePago : Form
    {
        private Thread Hilo;
        private delegate void myDel();
        private DataTable DtFormasPago;
        private DataTable DtTipoFormasPago;
        private Formas_de_pago oFormasDePago;
        private int Id;

        private void comenzarCarga()
        {
            pgCircular.Start();
            dgvFormasPago.DataSource = null;
            Hilo = new Thread(new ThreadStart(cargarDatos));
            Hilo.Start();
        }

        private void cargarDatos()
        {
            DtFormasPago = oFormasDePago.Listar();
            DtTipoFormasPago = oFormasDePago.ListarTiposFormasPagos();
            myDel MD = new myDel(asignarDatos);
            this.Invoke(MD, new object[] { });
            pgCircular.Stop();
        }

        private void asignarDatos()
        {
            cboTipos_Formas_Pagos.DataSource = DtTipoFormasPago;
            cboTipos_Formas_Pagos.DisplayMember = "nombre";
            cboTipos_Formas_Pagos.ValueMember = "id";
            dgvFormasPago.DataSource = DtFormasPago;
            dgvFormasPago.Columns["id_tipo_de_forma"].Visible = false;
            dgvFormasPago.Columns["requiere_presentacion"].Visible = false;
            dgvFormasPago.Columns["id"].Visible = false;
            dgvFormasPago.Columns["nombre"].HeaderText = "Nombre";
            dgvFormasPago.Columns["tipo_de_forma"].HeaderText = "Tipo";
            dgvFormasPago.Columns["codigo_empresa_tarjeta"].HeaderText = "Código de la empresa para la tarjeta";
            dgvFormasPago.Columns["codigo_empresa_banco"].HeaderText = "Código de la empresa para el banco";
            lblTotal.Text = String.Format("Total de registros: {0}", dgvFormasPago.Rows.Count);
            AsignarValores();
            controles(true);
        }

        private void AsignarValores()
        {
            try
            {
                Id = Convert.ToInt32(dgvFormasPago.SelectedRows[0].Cells["id"].Value);
                cboTipos_Formas_Pagos.SelectedValue = Convert.ToInt32(dgvFormasPago.SelectedRows[0].Cells["id_tipo_de_forma"].Value);
                txtNombre.Text = dgvFormasPago.SelectedRows[0].Cells["nombre"].Value.ToString();
                txtCodigoBanco.Text = dgvFormasPago.SelectedRows[0].Cells["codigo_empresa_banco"].Value.ToString();
                txtCodigoTarjeta.Text = dgvFormasPago.SelectedRows[0].Cells["codigo_empresa_tarjeta"].Value.ToString();
                chkRequierePresentacion.Checked = (Convert.ToInt32(dgvFormasPago.SelectedRows[0].Cells["requiere_presentacion"].Value) == Convert.ToInt32(Formas_de_pago.Presentacion.SI)) ? true : false;
            }
            catch { }
        }

        private void controles(bool state)
        {
            btnActualizar.Enabled = state;
            btnNuevo.Enabled = state;
            btnEliminar.Enabled = state;
            btnEditar.Enabled = state;
            btnGuardar.Enabled = !state;
            btnCancelar.Enabled = !state;
            txtNombre.Enabled = !state;
            txtCodigoBanco.Enabled = !state;
            txtCodigoTarjeta.Enabled = !state;
            chkRequierePresentacion.Enabled = !state;
            cboTipos_Formas_Pagos.Enabled = !state;
            dgvFormasPago.Enabled = state;
            if (dgvFormasPago.Rows.Count == 0)
            {
                btnEditar.Enabled = false;
                btnEliminar.Enabled = false;
            }
        }
        private void limpiarValores()
        {
            Id = 0;
            txtNombre.Text = "";
            chkRequierePresentacion.Checked = false;
        }

        private void Eliminar()
        {
            oFormasDePago.Eliminar(Convert.ToInt32(dgvFormasPago.SelectedRows[0].Cells["id"].Value));
            comenzarCarga();
        }

        private void Guardar()
        {
            oFormasDePago.Id = Id;
            oFormasDePago.Nombre = txtNombre.Text;
            oFormasDePago.Tipo_De_Forma = Convert.ToInt32(cboTipos_Formas_Pagos.SelectedValue);
            oFormasDePago.Requiere_Presentacion = (chkRequierePresentacion.Checked == true) ? 1 : 0;
            oFormasDePago.Codigo_Empresa_Banco = txtCodigoBanco.Text;
            oFormasDePago.Codigo_Empresa_Tarjeta = txtCodigoTarjeta.Text;
            oFormasDePago.Guardar(oFormasDePago);
            comenzarCarga();
        }

        public ABMFormasDePago()
        {
            InitializeComponent();
        }

        private void ABMFormasDePago_Load(object sender, EventArgs e)
        {
            DtFormasPago = new DataTable();
            DtTipoFormasPago = new DataTable();
            oFormasDePago = new Formas_de_pago();
            chkRequierePresentacion.Checked = false;
            comenzarCarga();
            btnNuevo.Focus();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            comenzarCarga();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            controles(false);
            limpiarValores();
            txtNombre.Focus();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            controles(false);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("¿Está seguro que desea eliminar el registro seleccionado?", "", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    Eliminar();
                }
                catch
                {
                    MessageBox.Show("Error al eliminar.");
                }
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text.Length > 0)
            {
                if (DtFormasPago.Select(String.Format("nombre='{0}' and id<>{1}", txtNombre.Text, Id)).Count() == 0)
                    Guardar();
                else
                    MessageBox.Show("Ya existe.");
            }
            else
            {
                MessageBox.Show("Datos en blanco.");
                txtNombre.Focus();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            controles(true);
            dgvFormasPago.Enabled = true;
        }

        private void dgvFormasPago_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            AsignarValores();
        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ABMFormasDePago_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void cboTipos_Formas_Pagos_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(cboTipos_Formas_Pagos.SelectedValue) == Convert.ToInt32(Formas_de_pago.Tipos_Formas_Pagos.DEBITO_AUTOMATICO))
                {
                    txtCodigoBanco.Enabled = true;
                    txtCodigoTarjeta.Enabled = true;
                    chkRequierePresentacion.Enabled = true;
                }
                else
                {
                    txtCodigoBanco.Enabled = false;
                    txtCodigoTarjeta.Enabled = false;
                    chkRequierePresentacion.Enabled = false;
                }
            }
            catch { }
        }
    }
}
