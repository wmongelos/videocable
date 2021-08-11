using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using CapaNegocios;
using System.Globalization;

namespace CapaPresentacion.Cobradores
{
    public partial class frmCobradoresConsultaDetalle : Form
    {
        private Thread hilo;
        private delegate void myDel();
        private DataTable dtReciboDetalle;
        Decimal ImporteTotal;
        Int32 FilasTotales;
        public int id_Referencia_Recibo = 0;
        Puntos_Cobros oPuntoCobro = new Puntos_Cobros();
        public frmCobradoresConsultaDetalle()
        {
            InitializeComponent();
        }

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
                dtReciboDetalle = oPuntoCobro.Listar_Cobradores_Consulta_Pagos_Detalle(id_Referencia_Recibo);

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
            dgv.DataSource = dtReciboDetalle;

            for (int i = 0; i < dgv.ColumnCount; i++)
                dgv.Columns[i].Visible = false;

            dgv.Columns["codUsu"].Visible = true;
            dgv.Columns["usuario"].Visible = true;
            dgv.Columns["recibo"].Visible = true;
            dgv.Columns["importe"].Visible = true;

            dgv.Columns["codUsu"].HeaderText = "Codigo Usuario";
            dgv.Columns["usuario"].HeaderText = "Usuario";
            dgv.Columns["recibo"].HeaderText = "Recibo";
            dgv.Columns["importe"].HeaderText = "Importe";

            dgv.Columns["importe"].DefaultCellStyle.Format = "C2";
            dgv.Columns["importe"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv.Columns["importe"].DefaultCellStyle.FormatProvider = CultureInfo.GetCultureInfo("en-US");
            CalcularImporteYFilasTotales();
            
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
                        ImporteTotal += Convert.ToDecimal(row.Cells["Importe"].Value);
                        FilasTotales++;
                    }
                }
            }
        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmCobradoresConsultaDetalle_Load(object sender, EventArgs e)
        {
            comenzarCarga();
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            if (dgv.Rows.Count > 0)
            {
                Tools oTools = new Tools();
                oTools.ExportDataTableToExcel(dtReciboDetalle, "Recibos por Cobrador");
                MessageBox.Show("Datos exportados correctamente.");
            }
            else
                MessageBox.Show("No hay registros para exportar");
        }
    }
}
