using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using System.Threading;
using CapaNegocios;
using CapaPresentacion;
using System.IO;

namespace CapaPresentacion.Contabilidad
{
    public partial class frmComprobantesEmitidos : Form
    {
        public frmComprobantesEmitidos()
        {
            InitializeComponent();
        }

        private Thread hilo;
        private delegate void myDel();
        private DataTable dt_Detalles;
        private Impresiones.Impresion oImpresion = new Impresiones.Impresion();
        private Facturacion oFacturacion = new Facturacion();
        public int id_usuario;
        decimal importe_total=0;
        int filas_totales;

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
                dt_Detalles = oFacturacion.Listar_Comprobantes_Emitidos(id_usuario);

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
            dgv.DataSource = dt_Detalles;

            for (int i = 0; i < dgv.ColumnCount; i++)
                dgv.Columns[i].Visible = false;

            dgv.Columns["Fecha"].Visible = true;
            dgv.Columns["Usuario"].Visible = true;
            dgv.Columns["Comprobante"].Visible = true;
            dgv.Columns["Importe"].Visible = true;

            dgv.Columns["Fecha"].HeaderText = "Fecha";
            dgv.Columns["Usuario"].HeaderText = "Usuario";
            dgv.Columns["Comprobante"].HeaderText = "Comprobante";
            dgv.Columns["Importe"].HeaderText = "Importe";

            dgv.Columns["Importe"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv.Columns["Importe"].DefaultCellStyle.Format = "c2";

            lblCodigo.Text = "Codigo: "+ Convert.ToString(dt_Detalles.Rows[0]["Codigo_Usuario"]);
            lblUsuario.Text = "Usuario: "+ Convert.ToString(dt_Detalles.Rows[0]["Usuario"]);


            if (dgv.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    if (row.Visible)
                    {
                        importe_total += Convert.ToDecimal(row.Cells["Importe"].Value);
                        filas_totales++;
                    }
                }
            }
            lblTotal.Text = "Total de Registros: " + filas_totales.ToString();
            lblImporte.Text = "Importe total : $ " + importe_total.ToString();
        }


        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmComprobantesEmitidos_Load(object sender, EventArgs e)
        {
            comenzarCarga();
        }

        private void btnReimprimeComprobante_Click(object sender, EventArgs e)
        {
            if (dgv.Rows.Count > 0)
            {
                 try
                 {
                   oImpresion.Imprime_factura_RDLC(false, Convert.ToInt32(dgv.SelectedRows[0].Cells["id_comprobantes"].Value.ToString()));
                 }
                 catch(Exception ex)
                 {
                    MessageBox.Show("Error: " + ex);
                 }
            }
        }

        private void btnDetalle_Click(object sender, EventArgs e)
        {
            if (dgv.Rows.Count > 0)
            {
                Cuenta_Corriente.frmUsuariosCtaCteComponentes frmComponentes = new Cuenta_Corriente.frmUsuariosCtaCteComponentes(Convert.ToInt32(dgv.SelectedRows[0].Cells["id_comprobantes"].Value));
                frmPopUp frmPU = new frmPopUp();
                frmPU.Formulario = frmComponentes;
                frmPU.ShowDialog();
            }
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            if (dgv.Rows.Count > 0)
            {
                Tools tools = new Tools();
                this.Cursor = Cursors.WaitCursor;
                try
                {
                    tools.ExportToExcel(dgv, "Comprobantes Emitidos");
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

        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            dt_Detalles.DefaultView.RowFilter = String.Format("Usuario LIKE '%{0}%' OR Convert([fecha], System.String) LIKE '%{0}%' OR Convert([importe], System.String) LIKE '%{0}%' OR Convert([comprobante], System.String) LIKE '%{0}%'", txtFiltro.Text);
        }
    }
}
