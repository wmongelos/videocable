using CapaNegocios;
using System;
using System.Data;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class frmCobradoresFormasPagos : Form
    {
        public DataTable dtDetalles = new DataTable();
        public Int32 idForma;
        public string forma;
        private int idActual;
        private int errores = 0;
        private Usuarios oUsu = new Usuarios();

        public frmCobradoresFormasPagos()
        {
            InitializeComponent();
        }

        private void ComenzarCarga()
        {
            lblTituloHeader.Text = lblTituloHeader.Text + " - " + forma;
            dgvDetallesPagos.DataSource = dtDetalles;
            FormatearDetalle();
        }

        private void frmCobradoresFormasPagos_Load(object sender, EventArgs e)
        {
            ComenzarCarga();
        }

        private void FormatearDetalle()
        {
            CurrencyManager cm = (CurrencyManager)BindingContext[dgvDetallesPagos.DataSource];
            cm.SuspendBinding();
            this.dgvDetallesPagos.CurrentCell = null;
            foreach (DataGridViewColumn item in dgvDetallesPagos.Columns)
            {
                item.Visible = false;
            }
            dgvDetallesPagos.Visible = true;
            dgvDetallesPagos.ReadOnly = false;
            //dgvDetallesPagos.Columns["id"].Visible = true;

            dgvDetallesPagos.Columns["cod_usu"].HeaderText = "Cod. Usuario";
            dgvDetallesPagos.Columns["cod_usu"].Visible = true;

            dgvDetallesPagos.Columns["forma"].HeaderText = "Forma de pago";
            dgvDetallesPagos.Columns["forma"].Visible = true;

            dgvDetallesPagos.Columns["monto"].HeaderText = "Monto";
            dgvDetallesPagos.Columns["monto"].Visible = true;

            foreach (DataGridViewRow item in dgvDetallesPagos.Rows)
            {
                if (Convert.ToInt32(item.Cells["borrado"].Value) == 1)
                    item.Visible = false;
                else
                    item.Visible = true;
                if (Convert.ToInt32(item.Cells["id_forma_pago"].Value) != idForma)
                    item.Visible = false;
            }



        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void btnBusca_Click(object sender, EventArgs e)
        {
            if (dgvDetallesPagos.SelectedCells.Count > 0)
            {
                frmPopUp oPop = new frmPopUp();
                Busquedas.frmBusquedaUsuarios oBuscaUsu = new Busquedas.frmBusquedaUsuarios(1, "", "");
                oPop.Formulario = oBuscaUsu;
                if (oPop.ShowDialog() == DialogResult.OK)
                {
                    foreach (DataGridViewRow item in dgvDetallesPagos.Rows)
                    {
                        if (Convert.ToInt32(item.Cells["id"].Value) == idActual)
                        {
                            item.Cells["cod_usu"].Value = Usuarios.CurrentUsuario.Codigo;
                            item.Cells["id_usu"].Value = Usuarios.CurrentUsuario.Id;
                        }
                    }
                    FormatearDetalle();
                }
            }
            else
                MessageBox.Show("Seleccione un pago");


        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            DataRow dr = dtDetalles.NewRow();
            dr["id"] = dtDetalles.Rows.Count + 1;

            dr["id_forma_pago"] = this.idForma;
            dr["cod_usu"] = 0;
            dr["forma"] = forma;
            dr["monto"] = 0;
            dr["borrado"] = 0;
            dr["id_usu"] = 0;
            dr["activo"] = 0;
            dr["banco"] = "";
            dr["sucursal"] = "";
            dr["numero"] = "";
            dr["fecha_comp"] = DateTime.Now;
            dr["fecha_acre"] = DateTime.Now;
            dr["titular"] = "";
            dr["cuenta"] = "";
            dr["cuit"] = "";
            dtDetalles.Rows.Add(dr);

            dgvDetallesPagos.DataSource = dtDetalles;
            FormatearDetalle();
            pnPagos.Visible = true;

        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dtDetalleAux = dtDetalles.Clone();
                int id = Convert.ToInt32(dgvDetallesPagos.CurrentRow.Cells["id"].Value);
                int indice = dgvDetallesPagos.CurrentRow.Index;
                dgvDetallesPagos.ReadOnly = false;

                dtDetalles.Rows.RemoveAt(indice);
                dgvDetallesPagos.DataSource = dtDetalles;
                FormatearDetalle();
            }
            catch { }
        }

        private void dgvDetallesPagos_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (dgvDetallesPagos.CurrentCell.ColumnIndex != 2)
            {
                pnPagos.Visible = true;
                try
                {
                    spImporte.Value = Convert.ToDecimal(dgvDetallesPagos.CurrentRow.Cells["monto"].Value);
                    txtcliente.Text = dgvDetallesPagos.CurrentRow.Cells["titular"].Value.ToString();
                    txtcuit.Text = dgvDetallesPagos.CurrentRow.Cells["cuit"].Value.ToString();
                    txtbanco.Text = dgvDetallesPagos.CurrentRow.Cells["banco"].Value.ToString();
                    txtsucursal.Text = dgvDetallesPagos.CurrentRow.Cells["sucursal"].Value.ToString();
                    txtcuenta.Text = dgvDetallesPagos.CurrentRow.Cells["cuenta"].Value.ToString();
                    dtpFechaCom.Value = Convert.ToDateTime(dgvDetallesPagos.CurrentRow.Cells["fecha_comp"].Value);
                    dtpFechaAcre.Value = Convert.ToDateTime(dgvDetallesPagos.CurrentRow.Cells["fecha_acre"].Value);
                    txtbanco.Text = dgvDetallesPagos.CurrentRow.Cells["banco"].Value.ToString();
                }
                catch
                {

                }

            }

        }

        private void dgvDetallesPagos_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                idActual = Convert.ToInt32(dgvDetallesPagos.CurrentRow.Cells["id"].Value);
            }
            catch { }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            decimal montos = 0;
            foreach (DataGridViewRow item in dgvDetallesPagos.Rows)
            {
                montos = Convert.ToDecimal(item.Cells["monto"].Value);
                if (montos == 0)
                {
                    item.Cells["borrado"].Value = 1;
                }

            }
            errores = 0;
            foreach (DataGridViewRow row in dgvDetallesPagos.Rows)
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if ((Convert.ToInt32(row.Cells["cod_usu"].Value) == 0) && (cell.ColumnIndex == 2))
                    {
                        cell.ErrorText = "Ingrese codigo de usuario";
                        cell.Selected = true;
                        errores++;
                    }
                    else
                        cell.ErrorText = "";

                }
            if (errores == 0)
            {
                this.DialogResult = DialogResult.OK;
            }
        }

        private void btnConfirma_Click(object sender, EventArgs e)
        {
            if (spImporte.Value > 0)
            {
                dgvDetallesPagos.Rows[dgvDetallesPagos.Rows.Count - 1].Cells["monto"].Value = spImporte.Value;
                dgvDetallesPagos.Rows[dgvDetallesPagos.Rows.Count - 1].Cells["banco"].Value = txtbanco.Text;
                dgvDetallesPagos.Rows[dgvDetallesPagos.Rows.Count - 1].Cells["cuit"].Value = txtcuit.Text;
                dgvDetallesPagos.Rows[dgvDetallesPagos.Rows.Count - 1].Cells["cuenta"].Value = txtcuenta.Text;
                dgvDetallesPagos.Rows[dgvDetallesPagos.Rows.Count - 1].Cells["fecha_comp"].Value = dtpFechaCom.Value;
                dgvDetallesPagos.Rows[dgvDetallesPagos.Rows.Count - 1].Cells["fecha_acre"].Value = dtpFechaAcre.Value;
                dgvDetallesPagos.Rows[dgvDetallesPagos.Rows.Count - 1].Cells["numero"].Value = txtnumero.Text;
                dgvDetallesPagos.Rows[dgvDetallesPagos.Rows.Count - 1].Cells["sucursal"].Value = txtsucursal.Text;
                dgvDetallesPagos.Rows[dgvDetallesPagos.Rows.Count - 1].Cells["titular"].Value = txtcliente.Text;
                dgvDetallesPagos.Rows[dgvDetallesPagos.Rows.Count - 1].Cells["borrado"].Value = 0;
                dtDetalles.AcceptChanges();
                FormatearDetalle();

                pnPagos.Visible = false;
                int x = dtDetalles.Rows.Count;
            }
        }

        private void imgCancelaPago_Click(object sender, EventArgs e)
        {
            pnPagos.Visible = false;
        }

        private void frmCobradoresFormasPagos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void dgvDetallesPagos_CellValidated(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvDetallesPagos_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                oUsu = new Usuarios();
                int codUsu = Convert.ToInt32(dgvDetallesPagos.CurrentCell.Value);
                oUsu = oUsu.traerUsuario(codUsu);
                if (oUsu == null)
                {
                    dgvDetallesPagos.CurrentCell.ErrorText = "Codigo de usuario no valido";
                    dgvDetallesPagos.CurrentCell.Selected = true;
                    errores++;
                }
                else
                {
                    dgvDetallesPagos.CurrentCell.ErrorText = "";
                    dgvDetallesPagos.CurrentCell.Selected = false;


                }

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
