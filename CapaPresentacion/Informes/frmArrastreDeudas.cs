using CapaNegocios;
using System;
using System.Data;
using System.Threading;
using System.Windows.Forms;

namespace CapaPresentacion.Informes
{
    public partial class frmArrastreDeudas : Form
    {
        #region Variables
        private Thread hilo;
        private delegate void myDel();
        private DataTable dt;
        Usuarios_CtaCte oUsuCtaCte = new Usuarios_CtaCte();
        #endregion

        #region Metodos
        public frmArrastreDeudas()
        {
            InitializeComponent();
        }

        private void comenzarCarga()
        {
            dgvArrastreDeudas.DataSource = null;
            hilo = new Thread(new ThreadStart(cargarDatos));
            hilo.Start();
            btnBuscar.Enabled = false;
        }

        private void cargarDatos()
        {
            try
            {
                dt = oUsuCtaCte.ListarArrastreDeudas(Convert.ToInt32(spnMes.Value), Convert.ToInt32(spnAnio.Value));
                dt.Columns.Add("Porcentaje", typeof(decimal));
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    try
                    {
                        dt.Rows[i]["Porcentaje"] = Convert.ToDecimal(dt.Rows[i]["Deuda"]) * 100 / Convert.ToDecimal(dt.Rows[i]["Facturado"]);
                        dt.Rows[i]["Porcentaje"] = Decimal.Round(Convert.ToDecimal(dt.Rows[i]["Porcentaje"]), 2);
                    }
                    catch
                    {

                    }
                }
                myDel MD = new myDel(asignarDatos);
                this.Invoke(MD, new object[] { });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar Informacion" + ex.Message);
            }
        }

        private void asignarDatos()
        {
            dgvArrastreDeudas.DataSource = dt;
            for (int i = 0; i < dgvArrastreDeudas.ColumnCount; i++)
                dgvArrastreDeudas.Columns[i].Visible = false;
            dgvArrastreDeudas.Columns["Zona"].Visible = true;
            dgvArrastreDeudas.Columns["Localidad"].Visible = true;
            dgvArrastreDeudas.Columns["Tipo"].Visible = true;
            dgvArrastreDeudas.Columns["Servicio"].Visible = true;
            dgvArrastreDeudas.Columns["Facturado"].Visible = true;
            dgvArrastreDeudas.Columns["Deuda"].Visible = true;
            dgvArrastreDeudas.Columns["Porcentaje"].Visible = true;

            dgvArrastreDeudas.Columns["Facturado"].DefaultCellStyle.Format = "c2";
            dgvArrastreDeudas.Columns["Facturado"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvArrastreDeudas.Columns["Deuda"].DefaultCellStyle.Format = "c2";
            dgvArrastreDeudas.Columns["Deuda"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvArrastreDeudas.Columns["Porcentaje"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            int deuda = 0, facturado = 0;

            foreach (DataGridViewRow fila in dgvArrastreDeudas.Rows)
            {
                deuda += Convert.ToInt32(fila.Cells["Deuda"].Value);
                facturado += Convert.ToInt32(fila.Cells["Facturado"].Value);
            }

            lblTotalDeudas.Text = String.Format("Deudas Total:{0}", deuda);
            lblFacturado.Text = String.Format("Facturado:{0}", facturado);
            lblTotal.Text = String.Format("Total de registros:{0}", dt.Rows.Count);

            txtBuscar.Enabled = true;
            btnBuscar.Enabled = true;

        }

        #endregion

        #region Eventos
        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmArrastreDeudas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
        #endregion

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            comenzarCarga();
        }

        private void frmArrastreDeudas_Load(object sender, EventArgs e)
        {
            txtBuscar.Enabled = false;
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            dt.DefaultView.RowFilter = String.Format("Zona LIKE '%{0}%' OR Localidad LIKE '%{0}%' OR Tipo LIKE '%{0}%' OR Servicio LIKE '%{0}%' OR Convert([Facturado], System.String) LIKE '%{0}%' OR Convert([Deuda], System.String) LIKE '%{0}%'", txtBuscar.Text);
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            if (dgvArrastreDeudas.Rows.Count > 0)
            {
                Tools tools = new Tools();
                try
                {
                    this.Cursor = Cursors.WaitCursor;
                    tools.ExportToExcel(dgvArrastreDeudas, "Arrastre de Deudas");
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
    }
}
