using CapaNegocios;
using System;
using System.Data;
using System.Threading;
using System.Windows.Forms;

namespace CapaPresentacion.Contabilidad
{
    public partial class frmRetiros : Form
    {
        public Decimal monto, efectivoActual;
        private Int32 accion, idCaja;
        private Thread hilo;
        private delegate void myDel();
        private DataTable dt;
        private Caja_Egreso oEgresos = new Caja_Egreso();
        private bool huboRetiro = false;

        private void comenzarCarga()
        {
            pgCircular.Start();
            dgvPresentacion.DataSource = null;
            hilo = new Thread(new ThreadStart(cargarDatos));
            hilo.Start();
        }

        private void cargarDatos()
        {
            try
            {
                dt = oEgresos.Listar(this.idCaja, Puntos_Cobros.Id_Punto);
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
            if (this.accion == 1)
            {
                btnConfirmar.Visible = true;
                cboTipo.DataSource = Enum.GetValues(typeof(Caja_Egreso.TiposEgresos));

            }
            else
            {
                spMain.Panel2Collapsed = false;
                spMain.Panel1Collapsed = true;
                btnConfirmar.Visible = false;
            }
            dgvPresentacion.DataSource = dt;
            if (this.idCaja > 0)
                btnEliminar.Enabled = false;
            FormatearGrilla();

        }
        public frmRetiros(int accion, decimal efectivoActual, int id_Caja = 0)
        {
            // 1 ingresa un nuevo retiro
            // 2 lee los retiros de una caja en particular, por defecto la caja actual
            this.accion = accion;
            this.idCaja = id_Caja;
            this.efectivoActual = efectivoActual;
            InitializeComponent();
        }

        private void FormatearGrilla()
        {
            dgvPresentacion.Columns["Id"].Visible = false;
            dgvPresentacion.Columns["id_punto_gestion"].Visible = false;
            dgvPresentacion.Columns["id_personal"].Visible = false;
            dgvPresentacion.Columns["id_caja"].Visible = false;
            dgvPresentacion.Columns["fecha"].HeaderText = "FECHA";
            dgvPresentacion.Columns["fecha"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            dgvPresentacion.Columns["TIPO"].HeaderText = "TIPO";
            dgvPresentacion.Columns["monto"].HeaderText = "MONTO";
            dgvPresentacion.Columns["monto"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            dgvPresentacion.Columns["descripcion"].HeaderText = "PUNTO GESTION";
            dgvPresentacion.Columns["nombre"].HeaderText = "USUARIO";
            dgvPresentacion.Columns["numero_comprobante"].HeaderText = "N° COMPROBANTE";
            dgvPresentacion.Columns["detalle"].HeaderText = "DETALLE";
        }

        private void btnConfirmar_Click(object sender, System.EventArgs e)
        {
            if (huboRetiro)
            {
                this.DialogResult = DialogResult.OK;
            }
            else if ((txtImporte.Text.Trim().Equals("")) || (txtNumComprobante.Text.Trim().Equals("")))
                MessageBox.Show("Complete los datos necesarios", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else
            {
                if (Convert.ToDecimal(txtImporte.Text) > efectivoActual)
                    MessageBox.Show("El monto a retirar no puede ser superior al monto actual de la caja", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                {
                    Caja_Egreso.TiposEgresos tipoEgreso;
                    Enum.TryParse<Caja_Egreso.TiposEgresos>(cboTipo.SelectedValue.ToString(), out tipoEgreso);
                    oEgresos.id = 0;
                    oEgresos.idCaja = 0;
                    oEgresos.monto = Convert.ToDecimal(txtImporte.Text);
                    oEgresos.fecha = DateTime.Now;
                    oEgresos.idPersonal = Personal.Id_Login;
                    oEgresos.idPuntoGestion = Puntos_Cobros.Id_Punto;
                    oEgresos.idTipo = (int)tipoEgreso;
                    oEgresos.NumeroComprobante = txtNumComprobante.Text;
                    oEgresos.Detalle = txtDetalle.Text;
                    oEgresos.Guardar(oEgresos);
                    MessageBox.Show("" + cboTipo.Text.ToLower() + " guardado correctamente", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                }
            }
        }

        private void btnCancelar_Click(object sender, System.EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;

        }

        private void frmRetiros_Load(object sender, EventArgs e)
        {
            comenzarCarga();


        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtNumComprobante_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtImporte_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
                     && !char.IsDigit(e.KeyChar)
                     && e.KeyChar != '.' && e.KeyChar != ',')
            {
                e.Handled = true;
            }
            else
                e.Handled = false;


        }

        private void txtImporte_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvPresentacion.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("Esta a punto de eliminar un retiro, ¿Desea continuar?", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (oEgresos.ElininarEgreso(Convert.ToInt32(dgvPresentacion.SelectedRows[0].Cells["id"].Value)) == 0)
                    {
                        //MessageBox.Show("Retiro eliminado correctamente");
                        huboRetiro = true;
                        comenzarCarga();
                    }
                }
            }
        }
    }
}
