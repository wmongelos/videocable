using CapaNegocios;
using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;

namespace CapaPresentacion.Abms
{
    public partial class ABMArticulos : Form
    {
        private Thread hilo;
        private delegate void myDel();
        private DataTable dt;
        private Articulos oArticulos = new Articulos();
        private Articulos_Rubros oArticulos_Rubros = new Articulos_Rubros();
        public DataRow dr_rubros;
        Int32 id_rubros = 0;
        Decimal ImporteTotal;
        Int32 FilasTotales;

        public ABMArticulos()
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
                dt = oArticulos.Listar();

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

            for (int i = 0; i < dgv.ColumnCount; i++)
                dgv.Columns[i].Visible = false;

            dgv.Columns["Descripcion"].Visible = true;
            dgv.Columns["Stock"].Visible = true;
            dgv.Columns["Stock_Minimo"].Visible = true;
            dgv.Columns["Importe"].Visible = true;
            dgv.Columns["importe_total"].Visible = true;

            dgv.Columns["Descripcion"].HeaderText = "Articulo";
            dgv.Columns["Stock"].HeaderText = "Stock";
            dgv.Columns["Stock_Minimo"].HeaderText = "Stock Minimo";
            dgv.Columns["Importe"].HeaderText = "Importe unitario";
            dgv.Columns["importe_total"].HeaderText = "Sub total";

            dgv.Columns["Descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgv.Columns["Stock"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv.Columns["Stock_Minimo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv.Columns["Importe"].DefaultCellStyle.Format = "C2";
            dgv.Columns["Importe"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv.Columns["Importe"].DefaultCellStyle.FormatProvider = CultureInfo.GetCultureInfo("en-US");
            dgv.Columns["importe_total"].DefaultCellStyle.Format = "C2";
            dgv.Columns["importe_total"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv.Columns["importe_total"].DefaultCellStyle.FormatProvider = CultureInfo.GetCultureInfo("en-US");

            CalcularImporteYFilasTotales();
            lblTotal.Text = String.Format("Total de Registros: {0}", FilasTotales);
            lblImporteTotal.Text = String.Format("Total: {0}", ImporteTotal);

            DataTable dtRubros = oArticulos_Rubros.Listar();
            dtRubros.Rows.Add(0, "SIN RUBROS");
            dtRubros.Rows.Add(-1, "TODOS");
            cboArticulos_Rubros.DataSource = dtRubros;
            cboArticulos_Rubros.ValueMember = "Id";
            cboArticulos_Rubros.DisplayMember = "Descripcion";
            cboArticulos_Rubros.SelectedIndex = dtRubros.Rows.Count - 1;
        }

        private void ABMArticulos_Load(object sender, EventArgs e)
        {
            comenzarCarga();

        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            comenzarCarga();
        }

        private void CalcularImporteYFilasTotales()
        {
            ImporteTotal = 0;
            FilasTotales = 0;
            if (dgv.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    if (row.Visible)
                    {
                        ImporteTotal += Convert.ToDecimal(row.Cells["Importe_Total"].Value);
                        FilasTotales++;
                    }
                }
            }
        }

        private void filtrarDatos()
        {
            if (id_rubros == -1)
                dt.DefaultView.RowFilter = String.Format("Descripcion LIKE '%{0}%'", txtBuscador.Text);
            else
                dt.DefaultView.RowFilter = String.Format("Descripcion LIKE '%{0}%' and Id_Articulos_Rubros = {1}", txtBuscador.Text, id_rubros);

            CalcularImporteYFilasTotales();
            lblTotal.Text = String.Format("Total de Registros: {0}", FilasTotales);
            lblImporteTotal.Text = String.Format("Total: {0}", ImporteTotal);
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            using (frmPopUp frm = new frmPopUp())
            {
                frm.Formulario = new ABMArticulos_Ficha();
                frm.Maximizar = false;

                if (frm.ShowDialog() == DialogResult.OK)
                    cargarDatos();
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count == 0)
                dgv.Focus();

            DataRow[] dr = dt.Select(String.Format("Id = {0}", dgv.SelectedRows[0].Cells["Id"].Value.ToString()));


            using (frmPopUp frm = new frmPopUp())
            {
                ABMArticulos_Ficha frmABM = new ABMArticulos_Ficha();
                frmABM.DataRow = dr[0];
                frm.Formulario = frmABM;
                frm.Maximizar = false;

                if (frm.ShowDialog() == DialogResult.OK)
                    cargarDatos();
            }

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("¿Desea Eliminar el Articulo Seleccionado?", "Mensaje del Sistema",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    oArticulos.Eliminar(Convert.ToInt32(dgv.SelectedRows[0].Cells["Id"].Value.ToString()));
                    cargarDatos();
                }
            }
            else
                MessageBox.Show("Debe Seleccionar un Registro");
        }

        private void dgv_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void ABMArticulos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtBuscador_KeyPress(object sender, KeyPressEventArgs e)
        {
            filtrarDatos();
        }

        private void cboArticulos_Rubros_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                id_rubros = Convert.ToInt32(cboArticulos_Rubros.SelectedValue.ToString());
                filtrarDatos();
            }
            catch { }
        }

        private void dgv_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (Convert.ToInt32(dgv.Rows[e.RowIndex].Cells["Stock"].Value) <
                Convert.ToInt32(dgv.Rows[e.RowIndex].Cells["Stock_Minimo"].Value))
            {
                e.CellStyle.BackColor = Color.Tomato;
            }
        }
    }
}
