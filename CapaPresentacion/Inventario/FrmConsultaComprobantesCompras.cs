using CapaNegocios;
using System;
using System.Data;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace CapaPresentacion.Inventario
{
    public partial class FrmConsultaComprobantesCompras : Form
    {
        #region [PROPIEDADES]
        private Thread hilo;
        private delegate void myDel();
        private DataTable dt = new DataTable();
        private DataTable dtActual = new DataTable();
        private Comprobantes_Compras oComp = new Comprobantes_Compras();
        private bool mostrarProvedores;
        #endregion

        public FrmConsultaComprobantesCompras()
        {
            InitializeComponent();
            DateTime diaHoy = DateTime.Now;
            dtpDesde.Value = new DateTime(diaHoy.Year, diaHoy.Month, 1);
            dtpHasta.Value = diaHoy;
            mostrarProvedores = true;
            CargarCombo();
        }

        #region [METODOS]
        private void CargarCombo()
        {
            Proveedores oProv = new Proveedores();
            DataTable dtAux = oProv.Listar();
            DataRow dr = dtAux.NewRow();
            dr["Razon_Social"] = "TODOS";
            dr["Id"] = "0";
            dtAux.Rows.Add(dr);
            dtAux.DefaultView.Sort = "Id ASC";
            cboProveedores.DataSource = dtAux;
            cboProveedores.DisplayMember = "Razon_Social";
            cboProveedores.ValueMember = "Id";
        }

        private void FrmConsultaComprobantesCompras_Load(object sender, EventArgs e)
        {
            comenzarCarga();
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
                dt = oComp.Listar();
                dtActual = dt.Copy();
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
            dgv.DataSource = dtActual;
            foreach (DataGridViewColumn col in dgv.Columns)
                col.Visible = false;

            if (mostrarProvedores)
                dgv.Columns["razon_social"].Visible = true;
            dgv.Columns["fecha"].Visible = true;
            dgv.Columns["importe"].Visible = true;
            dgv.Columns["personal"].Visible = true;
            dgv.Columns["tipo_comprobante"].Visible = true;

            dgv.Columns["razon_social"].HeaderText = "Proveedor";
            dgv.Columns["fecha"].HeaderText = "Fecha";
            dgv.Columns["importe"].HeaderText = "Importe";
            dgv.Columns["personal"].HeaderText = "Operador";
            dgv.Columns["tipo_comprobante"].HeaderText = "Tipo de comprobante";

            dgv.Columns["importe"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv.Columns["importe"].DefaultCellStyle.FormatProvider = Thread.CurrentThread.CurrentCulture;

            dgv.Columns["razon_social"].DisplayIndex = 0;
            dgv.Columns["fecha"].DisplayIndex = 1;
            dgv.Columns["tipo_comprobante"].DisplayIndex = 2;
            dgv.Columns["importe"].DisplayIndex = 3;
            dgv.Columns["personal"].DisplayIndex = 4;

            lblTotal.Text = String.Format("Total de Registros: {0}", dt.Rows.Count);
        }

        private void filtrarRegistros()
        {
            mostrarProvedores = true;
            DataRow[] rowsFechas = dt.Select(string.Format("fecha >= #{0}# and fecha <= #{1}#", dtpDesde.Value.ToString("yyyy-MM-dd HH:mm:ss.fff"), dtpHasta.Value.ToString("yyyy-MM-dd HH:mm:ss.fff")));
            if (rowsFechas.Count() > 0)
            {
                dtActual = rowsFechas.CopyToDataTable();
                if (cboProveedores.SelectedIndex != 0)
                {
                    mostrarProvedores = false;
                    int prov = Convert.ToInt32(cboProveedores.SelectedValue);
                    DataRow[] rows = dtActual.Select(string.Format("id_prov = {0}", prov));
                    if (rows.Count() > 0)
                        dtActual = rows.CopyToDataTable();
                    else
                        dtActual.Clear();
                }
            }
            else
                dtActual.Clear();

            asignarDatos();
        }

        private void exportarAExcel()
        {
            if (dgv.Rows.Count > 0)
            {
                Tools tools = new Tools();
                this.Cursor = Cursors.WaitCursor;
                try
                {
                    tools.ExportToExcel(dgv, "Consulta comprobantes compras");
                }
                catch (Exception)
                {
                    MessageBox.Show("Error al exportar a excel");
                }
                finally { this.Cursor = Cursors.Default; }
            }
            else
                MessageBox.Show("Grilla vacia", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        #endregion

        #region [METODOS DE CONTROLES]
        private void btnExportarExcel_Click(object sender, EventArgs e)
        {
            exportarAExcel();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            filtrarRegistros();
        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmConsultaComprobantesCompras_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
        #endregion
    }
}
