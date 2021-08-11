using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CapaNegocios;
using CapaPresentacion;
using System.Threading;
using System.Globalization;

namespace CapaPresentacion.Informes
{
    public partial class frmARBA_Detalle : Form
    {

        public int id_Ctacte = 0;
        private Thread hilo;
        private delegate void myDel();
        private DataTable dt_Detalle = new DataTable();
        Usuarios_CtaCte_Det oUsu_CtacteDet = new Usuarios_CtaCte_Det();
        int FilasTotales = 0;
        decimal ImporteTotal = 0;

        public frmARBA_Detalle()
        {
            InitializeComponent();
        }

        #region Metodos
        private void comenzarCarga()
        {
            dgv.DataSource = null;

            hilo = new Thread(new ThreadStart(cargarDatos));
            hilo.Start();
        }

        private void cargarDatos()
        {
            try
            {
                dt_Detalle = oUsu_CtacteDet.Listado_ARBA_Cuatrimestral_Detalle(id_Ctacte);

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
            dgv.DataSource = dt_Detalle;

            for (int i = 0; i < dgv.ColumnCount; i++)
                dgv.Columns[i].Visible = false;

            dgv.Columns["Importe_pago"].Visible = true;
            dgv.Columns["Servicio"].Visible = true;
            dgv.Columns["Usuario"].Visible = true;

            dgv.Columns["Importe_pago"].HeaderText = "Importe Pago";
            dgv.Columns["Servicio"].HeaderText = "Servicio";
            dgv.Columns["Usuario"].HeaderText = "Usuario";

            dgv.Columns["Importe_pago"].DefaultCellStyle.Format = "C2";
            dgv.Columns["Importe_pago"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv.Columns["Importe_pago"].DefaultCellStyle.FormatProvider = CultureInfo.GetCultureInfo("en-US");


            CalcularImporteYFilasTotales();
            lblTotalRegistros.Text = "Total registros : " + FilasTotales.ToString();
            lblImporteTotal.Text = "Total : $" + ImporteTotal.ToString();

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
                        ImporteTotal += Convert.ToDecimal(row.Cells["Importe_Pago"].Value);
                        FilasTotales++;
                    }
                }
            }
        }

        #endregion

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmARBA_Detalle_Load(object sender, EventArgs e)
        {
            comenzarCarga();
        }

        private void btnExportarExcel_Click(object sender, EventArgs e)
        {
            if (dgv.Rows.Count > 0)
            {
                Tools tools = new Tools();
                this.Cursor = Cursors.WaitCursor;
                try
                {
                    tools.ExportToExcel(dgv, "ARBA Detalle");
                }
                catch (Exception)
                {
                    MessageBox.Show("Error al exportar a excel");
                }
                finally { this.Cursor = Cursors.Default; }
            }
            else
                MessageBox.Show("Grilla vacia");

        }

        private void frmARBA_Detalle_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
    }
}
