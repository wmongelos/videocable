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

namespace CapaPresentacion.Informes
{
    public partial class frmFacturacionServicios : Form
    {
        private Thread hilo;
        private delegate void myDel();
        private DataTable dtTotalIVA;
        private DataTable dtGenerado;
        private DateTime desde;
        private DateTime hasta;
        private DataTable dtCompleta = new DataTable();
        private DataTable dtCompleta_Filtrada = new DataTable();
        Facturacion oFac = new Facturacion();
        decimal ImporteTotal = 0;
        int FilasTotales = 0;
        public frmFacturacionServicios()
        {
            InitializeComponent();
        }

        private void comenzarCarga()
        {
            dgvPrincipal.DataSource = null;
            hilo = new Thread(new ThreadStart(cargarDatos));
            hilo.Start();
        }

        private void cargarDatos()
        {
            try
            {
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
            dgvPrincipal.DataSource = dtTotalIVA;

            for (int i = 0; i < dgvPrincipal.ColumnCount; i++)
                dgvPrincipal.Columns[i].Visible = false;

            dgvPrincipal.Columns["factura"].Visible = true;
            dgvPrincipal.Columns["servicio"].Visible = true;
            dgvPrincipal.Columns["importe"].Visible = true;

            dgvPrincipal.Columns["servicio"].HeaderText = "Servicio";
            dgvPrincipal.Columns["factura"].HeaderText = "Factura";
            dgvPrincipal.Columns["Importe"].HeaderText = "Importe";

            dgvPrincipal.Columns["Importe"].DefaultCellStyle.Format = "C2";
            dgvPrincipal.Columns["Importe"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            CalcularFilasEImportes();
            lblRegistros.Text = "Total de registros : " + FilasTotales.ToString();
            lblImporteTotal.Text = "Total : $" + ImporteTotal.ToString();
        }

        private void CalcularFilasEImportes()
        {
            ImporteTotal = 0;
            FilasTotales = 0;
            if (dgvPrincipal.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvPrincipal.Rows)
                {
                    if (row.Visible)
                    {
                        ImporteTotal += Convert.ToDecimal(row.Cells["Importe"].Value);
                        FilasTotales++;
                    }
                }
            }
        }
        private void Cargar_Tablas(DateTime desde, DateTime hasta)
        {
            dtTotalIVA = oFac.getTotalIVAFacturado(desde, hasta);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            desde = dtpDesde.Value;
            hasta = dtpHasta.Value;
            Cargar_Tablas(desde,hasta);
            comenzarCarga();
        }

        private void FrmFacturacionServiciosNuevo_Load(object sender, EventArgs e)
        {
            dtpDesde.Value = DateTime.Now;
            dtpHasta.Value = DateTime.Now;
        }

        private void dgvPrincipal_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            using (frmPopUp frm = new frmPopUp())
            {
                frmFacturacionServicios_Detalle frmDet = new frmFacturacionServicios_Detalle();
                frmDet.id_Servicio = Convert.ToInt32(dgvPrincipal.SelectedRows[0].Cells["id_Servicio"].Value.ToString());
                frmDet.Id_Comprobante_Tipo = Convert.ToInt32(dgvPrincipal.SelectedRows[0].Cells["id_comp_tipo"].Value.ToString());
                frmDet.desde = dtpDesde.Value;
                frmDet.hasta = dtpHasta.Value;
                frm.Formulario = frmDet;
                frm.Maximizar = false;
                frm.Show();
            }
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            if (dgvPrincipal.Rows.Count > 0)
            {
                Tools tools = new Tools();
                this.Cursor = Cursors.WaitCursor;
                try
                {
                    tools.ExportToExcel(dgvPrincipal, "Facturacion por Servicios");
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

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmFacturacionServicios_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
    }
}
