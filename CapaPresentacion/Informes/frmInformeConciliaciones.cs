using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CapaNegocios;
using System.Threading;
using System.Globalization;

namespace CapaPresentacion.Informes
{
    public partial class frmInformeConciliaciones : Form
    {
        public frmInformeConciliaciones()
        {
            InitializeComponent();
        }
        #region DECLARACIONES
        private Thread hilo;
        private Usuarios_CtaCte_Recibos oUsuRecibos = new Usuarios_CtaCte_Recibos();
        private delegate void myDel();
        private DataTable dt;
        private DateTime desde, hasta;
        private int Conciliacion;
        Int32 FilasTotales;
        #endregion


        #region METODOS

        private void comenzarCarga()
        {
            pgCircular.Start();

            dgv.DataSource = null;

            hilo = new Thread(new ThreadStart(cargarDatos));
            hilo.Start();

            lblBuscar.Visible = false;
            txtBuscador.Visible = false;
            btnConciliar.Visible = false;
            groupBox2.Visible = false;
            btnBuscar.Enabled = false;
            btnExportarExcel.Enabled = false;
        }

        private void cargarDatos()
        {
            try
            {
                dt = oUsuRecibos.ListarComprobantesAConciliar(desde,hasta,Conciliacion);

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


            
            dgv.Columns["codUsu"].Visible = true;
            dgv.Columns["Usuario"].Visible = true;
            dgv.Columns["recibo"].Visible = true;
            dgv.Columns["importerecibo"].Visible = true;
            dgv.Columns["importedetalle"].Visible = true;
            dgv.Columns["formapago"].Visible = true;
            dgv.Columns["tipoformapago"].Visible = true;
            dgv.Columns["recibo"].Visible = true;
            dgv.Columns["Transferencia"].Visible = true;
            dgv.Columns["titular"].Visible = true;
            dgv.Columns["fechacomprobante"].Visible = true;

            dgv.Columns["recibo"].HeaderText = "Recibo";
            dgv.Columns["codUsu"].HeaderText = "Codigo";
            dgv.Columns["Usuario"].HeaderText = "Usuario";
            dgv.Columns["Transferencia"].HeaderText = "Transferencia / Tarjeta";
            dgv.Columns["titular"].HeaderText = "Titular";
            dgv.Columns["ImporteRecibo"].HeaderText = "Importe Total";
            dgv.Columns["importedetalle"].HeaderText = "Importe a Conciliar";
            dgv.Columns["formapago"].HeaderText = "Forma de Pago";
            dgv.Columns["tipoformapago"].HeaderText = "Tipo Forma de Pago";
            dgv.Columns["fechacomprobante"].HeaderText = "Fecha del Comprobante";

            dgv.Columns["ImporteRecibo"].DefaultCellStyle.Format = "C2";
            dgv.Columns["ImporteRecibo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv.Columns["ImporteRecibo"].DefaultCellStyle.FormatProvider = CultureInfo.GetCultureInfo("en-US");
            dgv.Columns["importedetalle"].DefaultCellStyle.Format = "C2";
            dgv.Columns["importedetalle"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv.Columns["importedetalle"].DefaultCellStyle.FormatProvider = CultureInfo.GetCultureInfo("en-US");

            CalcularFilasTotales();
            lblTotalRegistros.Text = "Total de registros: " + FilasTotales.ToString();
            lblBuscar.Visible = true;
            txtBuscador.Visible = true;
            btnConciliar.Visible = true;

            if (rbConciliado.Checked == true)
                btnConciliar.Enabled = false;
            else
                btnConciliar.Enabled = true;

            btnBuscar.Enabled = true;
            btnExportarExcel.Enabled = true;
            groupBox2.Visible = true;


        }

        private void CalcularFilasTotales()
        {
            FilasTotales = 0;
            if (dgv.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    if (row.Visible)
                    {
                        FilasTotales++;
                    }
                }
            }
        }

        private void generarConsulta()
        {
            desde = dtpDesde.Value;
            hasta = dtpHasta.Value;
            if (rbConciliado.Checked == true)
                Conciliacion = 1;
            else
                Conciliacion = 0;
            comenzarCarga();
        }

        private void GenerarConciliacion()
        {
            int id_Detalle = 0;
            id_Detalle = Convert.ToInt32(dgv.SelectedRows[0].Cells["id_recibo_det"].Value.ToString());
            if(oUsuRecibos.ActualizarConciliacion(id_Detalle))
                MessageBox.Show("Deuda conciliada correctamente.");
            else
                MessageBox.Show("Proceso interrumpido.");
            comenzarCarga();
        }
        #endregion


        #region EVENTOS

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmInformeConciliaciones_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }


        private void frmInformeConciliaciones_Load(object sender, EventArgs e)
        {
            lblBuscar.Visible = false;
            txtBuscador.Visible = false;
            btnConciliar.Visible = false;
            groupBox2.Visible = false;
            dtpDesde.Value = DateTime.Now;
            dtpHasta.Value = DateTime.Now;
        }

        private void txtBuscador_TextChanged(object sender, EventArgs e)
        {
            if (rbDatosRecibo.Checked == true)
                dt.DefaultView.RowFilter = String.Format("Convert([FechaComprobante], System.String) LIKE '%{0}%'  OR formapago LIKE '%{0}%' OR Convert([recibo], System.String) LIKE '%{0}%' OR Convert([tipoformapago], System.String) LIKE '%{0}%'", txtBuscador.Text);
            else if(rbTransferencia.Checked == true)
                dt.DefaultView.RowFilter = String.Format("Convert([Transferencia], System.String) LIKE '%{0}%'", txtBuscador.Text);
            else
                dt.DefaultView.RowFilter = String.Format("Convert([CodUsu], System.String) LIKE '%{0}%' OR usuario LIKE '%{0}%' ", txtBuscador.Text);
        }

        private void btnConciliar_Click(object sender, EventArgs e)
        {
            GenerarConciliacion();
        }

        private void btnExportarExcel_Click(object sender, EventArgs e)
        {
            if (dgv.Rows.Count > 0)
            {
                Tools tools = new Tools();
                this.Cursor = Cursors.WaitCursor;
                try
                {
                    if(rbConciliado.Checked==true) 
                        tools.ExportDataTableToExcel(dt, "Deudas conciliadas");
                    else
                        tools.ExportDataTableToExcel(dt, "Deudas a conciliar");
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

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            generarConsulta();
        }
        #endregion
    }
}
