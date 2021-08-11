using CapaNegocios;
using System;
using System.Data;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace CapaPresentacion.Abms
{
    public partial class ABMPuntosVenta : Form
    {
        #region [PROPIEDADES]
        private Thread hilo;
        private delegate void myDel();
        Puntos_Venta oPuntos_Venta = new Puntos_Venta();
        Comprobantes_Tipo oComprobantes_Tipo = new Comprobantes_Tipo();
        Modalidad_Facturacion oModalidad_Facturacion = new Modalidad_Facturacion();
        DataTable dtPuntos_Venta = new DataTable();
        DataTable dtModalidad_Facturacion = new DataTable();
        private int Id;
        #endregion
        private void comenzarCarga()
        {
            pgCircular.Start();
            dgvPuntosVenta.DataSource = null;
            hilo = new Thread(new ThreadStart(cargarDatos));
            hilo.Start();
        }

        private void cargarDatos()
        {
            try
            {
                dtPuntos_Venta = oPuntos_Venta.Listar();
                dtModalidad_Facturacion = oModalidad_Facturacion.Listar();
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
            cboModalidad_Facturacion.DataSource = dtModalidad_Facturacion;
            cboModalidad_Facturacion.DisplayMember = "descripcion";
            cboModalidad_Facturacion.ValueMember = "Id";
            DataGridViewLinkColumn colComprobantes = new DataGridViewLinkColumn();
            colComprobantes.HeaderText = "Comprobantes asociados";
            colComprobantes.Text = "Ver";
            colComprobantes.UseColumnTextForLinkValue = true;
            colComprobantes.Name = "colComprobantes";
            int control = 0;

            foreach (DataGridViewColumn columna in dgvPuntosVenta.Columns)
            {
                if (columna.Index == dgvPuntosVenta.Columns["colComprobantes"].Index)
                {
                    control = 1;
                    break;
                }
            }
            if (control == 1)
                dgvPuntosVenta.Columns.RemoveAt(dgvPuntosVenta.Columns["colComprobantes"].Index);

            dgvPuntosVenta.DataSource = dtPuntos_Venta;
            dgvPuntosVenta.Columns.Add(colComprobantes);
            dgvPuntosVenta.Columns["id_modalidad_fact"].Visible = false;
            dgvPuntosVenta.Columns["id"].Visible = false;
            dgvPuntosVenta.Columns["numero"].HeaderText = "Número";
            dgvPuntosVenta.Columns["numero"].Visible = false;
            dgvPuntosVenta.Columns["descripcion"].HeaderText = "Descripción";
            dgvPuntosVenta.Columns["colComprobantes"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvPuntosVenta.Enabled = true;
            controles(true);
            if (dtPuntos_Venta.Rows.Count == 0)
            {
                btnEditar.Enabled = false;
                btnEliminar.Enabled = false;
            }


            limpiarValores();
            asignarValores();

        }

        private void controles(bool state)
        {
            btnActualizar.Enabled = state;
            btnNuevo.Enabled = state;
            btnEliminar.Enabled = state;
            btnEditar.Enabled = state;
            btnGuardar.Enabled = !state;
            btnCancelar.Enabled = !state;
            txtNumero.Enabled = !state;
            txtDescripcion.Enabled = !state;
            cboModalidad_Facturacion.Enabled = !state;
        }

        private void limpiarValores()
        {
            Id = 0;
            txtDescripcion.Text = "";
            txtNumero.Text = "";
            cboModalidad_Facturacion.SelectedValue = Convert.ToInt32(dtModalidad_Facturacion.Rows[0]["id"]);
        }

        private void asignarValores()
        {
            try
            {
                Id = Convert.ToInt32(dgvPuntosVenta.SelectedRows[0].Cells["id"].Value);
                txtNumero.Text = dgvPuntosVenta.SelectedRows[0].Cells["numero"].Value.ToString();
                txtNumero.Tag = dgvPuntosVenta.SelectedRows[0].Cells["numero"].Value.ToString();
                txtDescripcion.Text = dgvPuntosVenta.SelectedRows[0].Cells["descripcion"].Value.ToString();
                cboModalidad_Facturacion.SelectedValue = Convert.ToInt32(dgvPuntosVenta.SelectedRows[0].Cells["id_modalidad_fact"].Value);
            }
            catch { }
        }

        public void Eliminar()
        {
            oPuntos_Venta.Eliminar(Convert.ToInt32(dgvPuntosVenta.SelectedRows[0].Cells["id"].Value));
            comenzarCarga();
        }

        public void Guardar()
        {
            oPuntos_Venta.Id = Id;
            oPuntos_Venta.Numero = Convert.ToInt32(txtNumero.Text);
            oPuntos_Venta.Descripcion = txtDescripcion.Text;
            oPuntos_Venta.Id_Modalidad_Fact = Convert.ToInt32(cboModalidad_Facturacion.SelectedValue);
            oPuntos_Venta.Guardar(oPuntos_Venta);
            controles(false);
            comenzarCarga();
        }

        private bool ControlarTxt()
        {
            bool resultado = true;

            if (txtNumero.Text.Length == 0)
            {
                txtNumero.Focus();
                resultado = false;
            }

            if (txtDescripcion.Text.Length == 0)
            {
                txtDescripcion.Focus();
                resultado = false;
            }
            return resultado;
        }

        private bool ValidadDatos()
        {
            bool resultado = true;
            if (txtNumero.Text.Length > 0 && txtNumero.Text != txtNumero.Tag.ToString())
            {
                DataRow[] dr = dtPuntos_Venta.Select(String.Format("numero = '{0}'", txtNumero.Text.ToUpper()));
                if (dr.Count() > 0)
                {
                    MessageBox.Show("El Valor ingresado ya Existe", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtNumero.Focus();
                    resultado = false;
                }
            }
            return resultado;
        }

        public ABMPuntosVenta()
        {
            InitializeComponent();
        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ABMPuntosVenta_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            comenzarCarga();
        }

        private void ABMPuntosVenta_Load(object sender, EventArgs e)
        {
            comenzarCarga();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            controles(false);
            limpiarValores();
            txtDescripcion.Focus();

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            controles(false);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("¿Está seguro que desea eliminar el punto de venta?", "", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
                Eliminar();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (ControlarTxt() == true && ValidadDatos() == true)
            {
                Guardar();

                if (Id == 0)
                {
                    ABMPuntosVenta_AsignacionCompTipos ABMAsignacion_Comprobantes = new ABMPuntosVenta_AsignacionCompTipos(oPuntos_Venta.Id);
                    frmPopUp frmpopup = new frmPopUp();
                    frmpopup.Maximizar = false;
                    frmpopup.Formulario = ABMAsignacion_Comprobantes;
                    frmpopup.ShowDialog();
                }
            }
        }

        private void dgvPuntosVenta_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            asignarValores();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            controles(true);
            dgvPuntosVenta.Enabled = true;
        }

        private void dgvPuntosVenta_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == dgvPuntosVenta.SelectedRows[0].Cells["colComprobantes"].ColumnIndex)
                {
                    ABMPuntosVenta_AsignacionCompTipos ABMAsignacion_Comprobantes = new ABMPuntosVenta_AsignacionCompTipos(Convert.ToInt32(dgvPuntosVenta.SelectedRows[0].Cells["id"].Value));
                    frmPopUp frmpopup = new frmPopUp();
                    frmpopup.Maximizar = false;
                    frmpopup.Formulario = ABMAsignacion_Comprobantes;
                    frmpopup.ShowDialog();
                }
            }
            catch
            { }
        }
    }
}
