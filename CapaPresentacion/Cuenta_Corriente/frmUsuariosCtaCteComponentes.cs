using CapaNegocios;
using System;
using System.Data;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace CapaPresentacion.Cuenta_Corriente
{
    public partial class frmUsuariosCtaCteComponentes : Form
    {
        private int idComprobante = 0;
        private Thread hilo;
        private delegate void myDel();
        private DataTable dtMovimientosCtaCte = new DataTable();
        private DataTable dtComprobantes = new DataTable();
        private Comprobantes oComprobantes = new Comprobantes();
        private int cargado = 0;
        private Impresiones.Impresion oImpresion = new Impresiones.Impresion();

        private void ComenzarCarga()
        {
            pgCircular.Start();
            hilo = new Thread(new ThreadStart(CargarDatos));
            hilo.IsBackground = true;
            hilo.Start();
        }

        private void CargarDatos()
        {
            try
            {
                dtMovimientosCtaCte = oComprobantes.ListarMovimientosCtaCte(idComprobante);
                myDel MD = new myDel(AsignarDatos);
                this.Invoke(MD, new object[] { });
                pgCircular.Stop();
            }
            catch (Exception e)
            {
                MessageBox.Show("Error: " + e.Message);
            }
        }

        private void AsignarDatos()
        {
            dgvMovimientos.DataSource = null;
            dgvMovimientos.DataSource = dtMovimientosCtaCte;
            for (int x = 0; x < dgvMovimientos.ColumnCount; x++)
                dgvMovimientos.Columns[x].Visible = false;

            dgvMovimientos.Columns["descripcion"].Visible = true;
            dgvMovimientos.Columns["importe_original"].Visible = true;
            dgvMovimientos.Columns["importe_bonificacion"].Visible = true;
            dgvMovimientos.Columns["importe_saldo"].Visible = true;
            dgvMovimientos.Columns["fecha_desde"].Visible = true;
            dgvMovimientos.Columns["fecha_hasta"].Visible = true;

            dgvMovimientos.Columns["id"].HeaderText = "Id";
            dgvMovimientos.Columns["descripcion"].HeaderText = "Descripción";
            dgvMovimientos.Columns["importe_original"].HeaderText = "Importe original";
            dgvMovimientos.Columns["importe_bonificacion"].HeaderText = "Importe bonificación";
            dgvMovimientos.Columns["importe_saldo"].HeaderText = "Saldo";
            dgvMovimientos.Columns["fecha_desde"].HeaderText = "Desde";
            dgvMovimientos.Columns["fecha_hasta"].HeaderText = "Hasta";

            lblTotal.Text = String.Format("Registros.", dgvMovimientos.Rows.Count);
            AsignarValores();

        }

        private void AsignarValores()
        {

            dgvComprobantes.DataSource = null;
            if (dgvMovimientos.Rows.Count > 0)
            {
                if (dgvMovimientos.SelectedRows.Count > 0)
                {
                    dtComprobantes.Clear();
                    dtComprobantes = oComprobantes.ListarComprobantes(Convert.ToInt32(dgvMovimientos.SelectedRows[0].Cells["id"].Value));
                    dgvComprobantes.DataSource = null;
                    dgvComprobantes.DataSource = dtComprobantes;
                }
                else
                {
                    dtComprobantes.Clear();
                    dtComprobantes = oComprobantes.ListarComprobantes(Convert.ToInt32(dgvMovimientos.Rows[0].Cells["id"].Value));
                    dgvComprobantes.DataSource = null;
                    dgvComprobantes.DataSource = dtComprobantes;
                }
                dgvComprobantes.Columns["id_comprobantes"].Visible = false;
                dgvComprobantes.Columns["fecha_emision"].HeaderText = "Fecha de emisión";
                dgvComprobantes.Columns["descripcion"].HeaderText = "Descripción";
                dgvComprobantes.Columns["comprobantes_tipo_nombre"].HeaderText = "Tipo de comprobante";
                dgvComprobantes.Columns["comprobantes_tipo_letra"].HeaderText = "Letra";
                dgvComprobantes.Columns["punto_gestion"].HeaderText = "Punto de gestión";
                dgvComprobantes.Columns["importe"].HeaderText = "Importe";
                dgvComprobantes.Columns["descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvComprobantes.Columns["fecha_emision"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvComprobantes.Columns["punto_gestion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                DataGridViewLinkColumn dgvColImprime = new DataGridViewLinkColumn();
                dgvColImprime.Name = "imprimir";
                dgvColImprime.LinkColor = Color.Blue;
                dgvColImprime.VisitedLinkColor = Color.Blue;
                dgvColImprime.UseColumnTextForLinkValue = true;
                dgvColImprime.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvColImprime.DataPropertyName = "imprimir";
                dgvColImprime.Text = "imprimir";
                dgvColImprime.HeaderText = "Imprimir";
                dgvComprobantes.Columns.Add(dgvColImprime);
                dgvComprobantes.Columns["imprimir"].DisplayIndex = dgvComprobantes.Columns.Count - 1;
            }
        }





        public frmUsuariosCtaCteComponentes(int idComprobanteRecibido)
        {
            idComprobante = idComprobanteRecibido;
            InitializeComponent();
        }

        private void lblTituloHeader_Click(object sender, EventArgs e)
        {

        }

        private void dgvNotificacionesRecibidas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmUsuariosCtaCteComponentes_Load(object sender, EventArgs e)
        {
            ComenzarCarga();
        }

        private void frmUsuariosCtaCteComponentes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {

                this.Close();
            }
        }

        private void lblPrioridad_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dgvMovimientos_CellEnter(object sender, DataGridViewCellEventArgs e)
        {


        }

        private void dgvComprobantes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvComprobantes.Columns[e.ColumnIndex].HeaderText == "Imprimir")
                {
                    if (dgvComprobantes.SelectedRows[0].Cells["comprobantes_tipo_letra"].Value.ToString() == "A" ||
                        dgvComprobantes.SelectedRows[0].Cells["comprobantes_tipo_letra"].Value.ToString() == "B")

                        oImpresion.Imprime_factura_RDLC(false, Convert.ToInt32(dgvComprobantes.SelectedRows[0].Cells["id_comprobantes"].Value.ToString()));
                }



                //if (e.ColumnIndex == dgvComprobantes.Columns.Count - 1)
                //{
                //    try
                //    {
                //        oImpresion.Imprime_Recibo(Convert.ToInt32(dgvComprobantes.SelectedRows[0].Cells["id_comprobantes"].Value.ToString()));
                //    }
                //    catch (Exception){
                //        throw;
                //    }
                //}

            }
            catch { }
        }

        private void dgvMovimientos_SelectionChanged(object sender, EventArgs e)
        {
            if (cargado > 0)
                AsignarValores();

        }
    }
}
