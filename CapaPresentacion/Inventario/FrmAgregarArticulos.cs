using CapaPresentacion.Abms;
using System;
using System.Data;
using System.Windows.Forms;

namespace CapaPresentacion.Inventario
{
    public partial class FrmAgregarArticulos : Form
    {
        private int totalItems;
        private int idArticulo;
        private int stockPrevio;
        private DataTable dtArtSelec;

        public FrmAgregarArticulos()
        {
            InitializeComponent();
            CrearDataTable();
            InicializarDGV();
        }

        private void CrearDataTable()
        {
            dtArtSelec = new DataTable();

            DataColumn dcIdArt = new DataColumn
            {
                DataType = typeof(Int32),
                ColumnName = "id",
                Unique = true
            };
            dtArtSelec.Columns.Add(dcIdArt);

            DataColumn dcArticulo = new DataColumn
            {
                DataType = typeof(String),
                ColumnName = "articulo"
            };
            dtArtSelec.Columns.Add(dcArticulo);

            DataColumn dcCantidad = new DataColumn
            {
                DataType = typeof(Int32),
                ColumnName = "cantidad"
            };
            dtArtSelec.Columns.Add(dcCantidad);

            DataColumn dcImporte = new DataColumn
            {
                DataType = typeof(Decimal),
                ColumnName = "importe"
            };
            dtArtSelec.Columns.Add(dcImporte);

            DataColumn dcStock = new DataColumn
            {
                DataType = typeof(Int32),
                ColumnName = "stockPrevio"
            };
            dtArtSelec.Columns.Add(dcStock);
        }

        private void InicializarDGV()
        {
            dgv.DataSource = dtArtSelec;

            foreach (DataGridViewColumn col in dgv.Columns)
                col.Visible = false;

            dgv.Columns["articulo"].HeaderText = "Artículo";
            dgv.Columns["articulo"].Visible = true;
            dgv.Columns["importe"].HeaderText = "Importe unitario";
            dgv.Columns["importe"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv.Columns["importe"].Visible = true;
            dgv.Columns["cantidad"].HeaderText = "Cantidad";
            dgv.Columns["cantidad"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv.Columns["cantidad"].Visible = true;
            spnStock.Enabled = false;
        }

        private void SeleccionarArticulo()
        {
            using (frmPopUp frm = new frmPopUp())
            {
                FrmBuscadorGen frmBuscar = new FrmBuscadorGen(txtBuscadorArts.Text.Trim().ToUpper());
                frmBuscar.List = FrmBuscadorGen.Tipo.ARTICULOS;

                frm.Formulario = frmBuscar;
                frm.Maximizar = false;

                if (frm.ShowDialog() == DialogResult.OK)
                {
                    txtArticulosSelec.Text = frmBuscar.Value;
                    this.idArticulo = frmBuscar.Id;
                    this.stockPrevio = frmBuscar.Stock;
                    this.spImporte.Value = Convert.ToDecimal(frmBuscar.ImporteArt);
                    this.spnStock.Value = frmBuscar.Stock;
                    foreach (DataGridViewRow row in dgv.Rows)
                        if (Convert.ToInt32(row.Cells["id"].Value) == this.idArticulo)
                        {
                            row.Selected = true;
                            break;
                        }
                }
            }
        }

        private void AgregarArticulo()
        {
            if (!String.IsNullOrEmpty(txtArticulosSelec.Text))
            {
                if (!String.IsNullOrEmpty(txtCantidad.Text))
                {
                    DataRow dr = dtArtSelec.NewRow();
                    DataRow[] drs = dtArtSelec.Select("id = " + this.idArticulo);

                    if (drs.Length == 0) //Agregar
                    {
                        dr["id"] = this.idArticulo;
                        dr["articulo"] = txtArticulosSelec.Text;
                        dr["cantidad"] = Convert.ToInt32(txtCantidad.Text);
                        dr["importe"] = spImporte.Value;
                        dr["stockPrevio"] = this.stockPrevio;

                        dtArtSelec.Rows.Add(dr);

                        this.totalItems += Convert.ToInt32(txtCantidad.Text);
                    }
                    else //Modificar
                    {
                        if (dgv.SelectedRows.Count > 0)
                        {
                            int cantiPrevia = Convert.ToInt32(drs[0]["cantidad"]);
                            drs[0]["cantidad"] = Convert.ToInt32(txtCantidad.Text);
                            drs[0]["importe"] = spImporte.Value;

                            this.totalItems = (totalItems - cantiPrevia) + Convert.ToInt32(txtCantidad.Text);
                        }
                    }

                    txtBuscadorArts.Focus();
                    txtBuscadorArts.SelectAll();
                    lblTotal.Text = String.Format("Total de Registros: {0}", dgv.Rows.Count);
                    lblTotalItems.Text = String.Format("Total de items: {0}", this.totalItems);
                }
                else
                {
                    MessageBox.Show("Poner la cantidad de artículos", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtCantidad.Focus();
                }
            }
            else
            {
                MessageBox.Show("Seleccionar artículo", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                SeleccionarArticulo();
            }
        }

        private void ConfirmarArticulos()
        {
            if (dgv.Rows.Count > 0)
            {
                using (frmPopUp frm = new frmPopUp())
                {
                    FrmConfirmarComprobantesCompras frmConf = new FrmConfirmarComprobantesCompras(dtArtSelec, 1);
                    frm.Formulario = frmConf;
                    frm.Maximizar = false;
                    if (frm.ShowDialog() == DialogResult.OK)
                        Reset();
                }
            }
            else
                MessageBox.Show("Grilla vacia", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void SacarRegistro()
        {
            if (dgv.Rows.Count > 0 && dgv.SelectedRows.Count > 0)
            {
                this.totalItems -= Convert.ToInt32(dgv.SelectedRows[0].Cells["cantidad"].Value);
                dgv.Rows.Remove(dgv.SelectedRows[0]);
                lblTotal.Text = String.Format("Total de Registros: {0}", dgv.Rows.Count);
                lblTotalItems.Text = String.Format("Total de items: {0}", this.totalItems);
                if (dgv.Rows.Count == 0)
                    Reset();
            }
        }

        private void dgv_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            txtArticulosSelec.Text = dgv.Rows[e.RowIndex].Cells["articulo"].Value.ToString();
            txtCantidad.Text = dgv.Rows[e.RowIndex].Cells["cantidad"].Value.ToString();
            spImporte.Value = Convert.ToDecimal(dgv.Rows[e.RowIndex].Cells["importe"].Value);
            this.idArticulo = Convert.ToInt32(dgv.Rows[e.RowIndex].Cells["id"].Value);
            this.stockPrevio = Convert.ToInt32(dgv.Rows[e.RowIndex].Cells["stockPrevio"].Value);
        }

        private void Reset()
        {
            dtArtSelec.Clear();
            dgv.DataSource = dtArtSelec;
            dgv.Refresh();
            txtArticulosSelec.Text = string.Empty;
            txtBuscadorArts.Text = string.Empty;
            txtCantidad.Text = string.Empty;
            spImporte.Value = Decimal.Zero;
        }

        private void LlamarABMArticulos()
        {
            using (frmPopUp frm = new frmPopUp())
            {
                ABMArticulos frmAbm = new ABMArticulos();

                frm.Formulario = frmAbm;
                frm.Maximizar = false;
                frm.ShowDialog();
            }
        }

        private void dgv_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            dgv.Rows[e.RowIndex].Selected = true;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            AgregarArticulo();
        }

        private void btnSelecArt_Click(object sender, EventArgs e)
        {
            SeleccionarArticulo();
        }

        private void btnSacar_Click(object sender, EventArgs e)
        {
            SacarRegistro();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            ConfirmarArticulos();
        }

        private void linkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LlamarABMArticulos();
        }

        public Panel GetPanel()
        {
            return this.pnlArticulos;
        }

    }
}
