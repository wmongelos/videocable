using CapaNegocios;
using System;
using System.Data;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class ABMTipoComprobantes : Form
    {
        private Thread hilo;
        private delegate void myDel();
        private DataTable dt;
        private TipoComprobantes oTipoComprobantes = new TipoComprobantes();

        public ABMTipoComprobantes()
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
                dt = oTipoComprobantes.Listar();
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
            dgv.Columns["Nombre"].HeaderText = "Tipo de Comprobante";
            dgv.Columns["Letra"].HeaderText = "Letra";
            dgv.Columns["Codigo_Afip"].HeaderText = "Codigo AFIP";
            dgv.Columns["Presenta_Ventas"].HeaderText = "Presenta Venta";
            dgv.Columns["Presenta_Ventas"].Visible = false;
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
            txtLetra.Enabled = state;
            txtCodAFIP.Enabled = state;

            checkPreVenta.Enabled = state;
            btnGuardar.Enabled = state;
            btnCancelar.Enabled = state;
        }

        private void asignarValores()
        {
            try
            {
                txtId.Text = dgv.SelectedRows[0].Cells["Id"].Value.ToString();
                txtNombre.Text = dgv.SelectedRows[0].Cells["Nombre"].Value.ToString();

                txtLetra.Text = dgv.SelectedRows[0].Cells["Letra"].Value.ToString();

                txtCodAFIP.Text = dgv.SelectedRows[0].Cells["codigo_Afip"].Value.ToString();
                txtCodAFIP.Tag = txtCodAFIP.Text;

                if (Convert.ToInt32(dgv.SelectedRows[0].Cells["presenta_Ventas"].Value) == 1)
                    checkPreVenta.Checked = true;
                else
                    checkPreVenta.Checked = false;
            }
            catch
            {
            }
        }

        private void nuevoRegistro()
        {
            txtId.Text = "0";
            txtNombre.Text = "";
            checkPreVenta.Enabled = true;
            txtNombre.Enabled = true;
            txtNombre.Focus();
        }

        private void editarRegistro()
        {
            checkPreVenta.Enabled = true;
            txtNombre.Enabled = true;
            txtLetra.Enabled = true;

            txtCodAFIP.Enabled = true;
            txtNombre.Focus();
        }

        private void eliminarRegistro()
        {
            if (MessageBox.Show("¿Desea eliminar el Registro Seleccionado?", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                oTipoComprobantes.Eliminar(Convert.ToInt32(txtId.Text));

                comenzarCarga();
            }
        }
        private void guardarRegistro()
        {
            if (txtNombre.Text.Length == 0)
                txtNombre.Focus();
            else if (checkPreVenta.Checked)
            {
                if (ValidarCodAfipLetra())
                {
                    oTipoComprobantes.id = Convert.ToInt32(txtId.Text);
                    oTipoComprobantes.nombre = txtNombre.Text.ToUpper();
                    oTipoComprobantes.letra = txtLetra.Text.ToUpper();

                    try
                    {
                        oTipoComprobantes.codigo_afip = Convert.ToInt32(txtCodAFIP.Text);
                    }
                    catch { oTipoComprobantes.codigo_afip = 0; }

                    if (checkPreVenta.Checked)
                        oTipoComprobantes.presenta_Venta = "1";
                    else
                        oTipoComprobantes.presenta_Venta = "0";
                    oTipoComprobantes.Guardar(oTipoComprobantes);
                    comenzarCarga();
                }
            }
            else
            {
                if (validarDatos())
                {
                    oTipoComprobantes.id = Convert.ToInt32(txtId.Text);
                    oTipoComprobantes.nombre = txtNombre.Text.ToUpper();
                    oTipoComprobantes.letra = txtLetra.Text.ToUpper();

                    try
                    {
                        oTipoComprobantes.codigo_afip = Convert.ToInt32(txtCodAFIP.Text);
                    }
                    catch { oTipoComprobantes.codigo_afip = 0; }

                    if (checkPreVenta.Checked)
                        oTipoComprobantes.presenta_Venta = "1";
                    else
                        oTipoComprobantes.presenta_Venta = "0";
                    oTipoComprobantes.Guardar(oTipoComprobantes);
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
            if (txtCodAFIP.Tag.ToString() != txtCodAFIP.Text && txtCodAFIP.Text.Length > 0)
            {
                DataRow[] dr = dt.Select(String.Format("Codigo_Afip = '{0}'", txtCodAFIP.Text.ToUpper()));

                if (dr.Count() > 0)
                {
                    MessageBox.Show("El Valor ingresado ya Existe", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtCodAFIP.Focus();
                    return false;
                }

            }

            return true;

        }


        private bool ValidarCodAfipLetra()
        {
            if (txtLetra.Text.Length == 0)
            {
                MessageBox.Show("El dato Letra se encuentra en blanco.");
                txtLetra.Focus();
                return false;
            }

            if (txtCodAFIP.Text.Length == 0)
            {
                MessageBox.Show("El dato Código AFIP se encuentra en blanco.");
                txtCodAFIP.Focus();
                return false;
            }
            else
            {
                if (!validarDatos())
                    return false;
            }

            return true;
        }

        private void ABMTipoComprobantes_Load(object sender, System.EventArgs e)
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

        private void limpiarValores()
        {
            txtId.Text = "";
            txtNombre.Text = "";
            txtLetra.Text = "";

            txtCodAFIP.Text = "";
            checkPreVenta.Checked = false;
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

        private void dgv_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            asignarValores();
        }

        private void ABMTipoComprobantes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void lblNombre_Click(object sender, EventArgs e)
        {

        }
    }
}
