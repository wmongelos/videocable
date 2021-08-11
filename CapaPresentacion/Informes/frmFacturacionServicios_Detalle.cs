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
using CapaPresentacion;
using System.Globalization;

namespace CapaPresentacion.Informes
{
    public partial class frmFacturacionServicios_Detalle : Form
    {
        public frmFacturacionServicios_Detalle()
        {
            InitializeComponent();
        }

        private Thread hilo;
        private delegate void myDel();
        private DataTable dtFinal;
        public DateTime desde;
        public DateTime hasta;
        public int id_Servicio;
        public int Id_Comprobante_Tipo;
        decimal ImporteTotal = 0;
        int FilasTotales = 0;
        Facturacion oFac = new Facturacion();


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
                dtFinal = oFac.getTotalIVAFacturado_Detalle(desde, hasta, id_Servicio, Id_Comprobante_Tipo);
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
            dgv.DataSource = dtFinal;

            for (int i = 0; i < dgv.ColumnCount; i++)
                dgv.Columns[i].Visible = false;
            
            dgv.Columns["Fecha"].Visible = true;
            dgv.Columns["Usuario"].Visible = true;
            dgv.Columns["Factura"].Visible = true;            
            dgv.Columns["Importe"].Visible = true;
            dgv.Columns["Condicion_IVA"].Visible = true;


            dgv.Columns["fecha"].HeaderText = "Fecha";
            dgv.Columns["Usuario"].HeaderText = "Fecha";
            dgv.Columns["factura"].HeaderText = "Factura";
            dgv.Columns["Importe"].HeaderText = "Importe";
            dgv.Columns["Condicion_Iva"].HeaderText = "Condicion IVA";

            dgv.Columns["Importe"].DefaultCellStyle.Format = "C2";
            dgv.Columns["Importe"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            CalcularFilasEImportes();
            lblRegistros.Text = "Total de registros : " + FilasTotales.ToString();
            lblImporteTotal.Text = "Total : $" + ImporteTotal.ToString();

        }

        private void CalcularFilasEImportes() 
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

        private void frmFacturacionServiciosNuevo_Detalle_Load(object sender, EventArgs e)
        {
            comenzarCarga();
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            if (dgv.Rows.Count > 0)
            {
                Tools tools = new Tools();
                this.Cursor = Cursors.WaitCursor;
                try
                {
                    tools.ExportToExcel(dgv, "Facturacion");
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

        private void frmFacturacionServicios_Detalle_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
    }
}
