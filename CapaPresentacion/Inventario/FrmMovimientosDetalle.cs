using CapaNegocios;
using System;
using System.Data;
using System.Windows.Forms;

namespace CapaPresentacion.Inventario
{
    public partial class FrmMovimientosDetalle : Form
    {
        private Articulos_Mov_Det oArtMovDet = new Articulos_Mov_Det();
        private DataTable dt = new DataTable();
        private int TipoDestino;
        private int Mostrar;

        public FrmMovimientosDetalle()
        {
            InitializeComponent();
        }

        private void FrmConsultaArticulosEntregados_Load(object sender, EventArgs e)
        {
            cboTipoDestino.SelectedIndex = 0;
            cboDestino.SelectedIndex = 0;
            cboMostrar.SelectedIndex = 0;
            cboDestino.DropDownHeight = cboDestino.ItemHeight * 15;
            dtpHasta.Value = DateTime.Now;
        }

        private void FormatearDGV()
        {
            dgv1.Columns["id_art_mov"].Visible = false;
            dgv1.Columns["id_art_mov_det"].Visible = false;
            dgv1.Columns["id_destinatario"].Visible = false;
            dgv1.Columns["destinatario"].Visible = false;
            dgv1.Columns["id_tipo"].Visible = false;
            dgv1.Columns["Producto"].HeaderText = "Articulo";
            dgv1.Columns["cantidad"].HeaderText = "Cantidad";
            dgv1.Columns["cantidad"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv1.Columns["fecha"].HeaderText = "Fecha";
            dgv1.Columns["entrega"].HeaderText = "Responsable";
            dgv1.Columns["Tipo"].HeaderText = "Tipo";
            dgv1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            if (this.Mostrar == 1)
            {
                dgv1.Columns["entrega"].Visible = false;
                dgv1.Columns["fecha"].Visible = false;
            }
            else if (this.Mostrar == 2)
            {
                dgv1.Columns["entrega"].Visible = true;
                dgv1.Columns["fecha"].Visible = true;
            }
        }

        private void cboTipoDestino_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTipoDestino.SelectedIndex == 0)
            {
                cboDestino.Enabled = false;
                cboDestino.SelectedIndex = 0;
            }
            else
                cboDestino.Enabled = true;

            if (cboTipoDestino.SelectedIndex == 1)
            {
                Personal_Areas oAreas = new Personal_Areas();
                cboDestino.DataSource = oAreas.Listar(true);
                cboDestino.DisplayMember = "nombre";
                cboDestino.ValueMember = "id";
            }
            else if (cboTipoDestino.SelectedIndex == 2)
            {
                Personal oPersonal = new Personal();
                cboDestino.DataSource = oPersonal.Listar(true);
                cboDestino.DisplayMember = "nombre";
                cboDestino.ValueMember = "id";
            }
            else if (cboTipoDestino.SelectedIndex == 3)
            {
                Moviles oMovil = new Moviles();
                cboDestino.DataSource = oMovil.Listar(true);
                cboDestino.DisplayMember = "nombre";
                cboDestino.ValueMember = "id";
            }
        }

        private void DeterminarTipoDestino()
        {
            if (cboTipoDestino.SelectedItem.ToString() == "AREAS") this.TipoDestino = 1;
            else if (cboTipoDestino.SelectedItem.ToString() == "PERSONAL") this.TipoDestino = 2;
            else if (cboTipoDestino.SelectedItem.ToString() == "MOVIL") this.TipoDestino = 3;
            else this.TipoDestino = -1;
        }

        private void DeterminarMostrar()
        {
            if (cboMostrar.SelectedIndex == 0)
                this.Mostrar = 1;
            else if (cboMostrar.SelectedIndex == 1)
                this.Mostrar = 2;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            DeterminarTipoDestino();
            DeterminarMostrar();
            dt = oArtMovDet.ListarArticulosDesdeHasta(this.Mostrar, dtpDesde.Value, dtpHasta.Value, this.TipoDestino, Convert.ToInt32(cboDestino.SelectedValue));
            dgv1.DataSource = dt;
            FormatearDGV();
            lblTotal.Text = String.Format("Total de Registros: {0}", dgv1.Rows.Count);
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            if (dgv1.Rows.Count > 0)
            {
                Tools tools = new Tools();
                try
                {
                    this.Cursor = Cursors.WaitCursor;
                    tools.ExportToExcel(dgv1, "movimientos articulos");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally { this.Cursor = Cursors.Default; }
            }
            else
            {
                MessageBox.Show("Tabla vacia", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            try
            {
                dt.DefaultView.RowFilter = String.Format("descripcion like '%{0}%' or entrega like '%{0}%'", txtFiltro.Text);
            }
            catch (Exception) { }
        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmConsultaArticulosEntregados_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void btnReImprimir_Click(object sender, EventArgs e)
        {
            if(dgv1.Rows.Count == 0)
            {
                return;
            }

            if(dgv1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Es necesario seleccionar una fila de la grilla", "Mensaje del sistema");
                return;
            }

            Impresiones.Impresion oImpresion = new Impresiones.Impresion();
            try
            {
                this.Cursor = Cursors.WaitCursor;
                oImpresion.ImprimirDetallesAsignacionMoviles(Convert.ToInt32(dgv1.SelectedRows[0].Cells["id_art_mov"].Value), false);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error en la impresion\n{ex.Message}", "Mensaje del sistema");
            }
            finally { this.Cursor = Cursors.Default; }
        }
    }
}
