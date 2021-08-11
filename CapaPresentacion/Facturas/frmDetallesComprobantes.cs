using CapaNegocios;
using System;
using System.Data;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class frmDetallesComprobantes : Form
    {
        private DataTable dtComprobantesTipo = new DataTable();
        private DataTable dtComprobatesDetalle = new DataTable();
        private Thread hilo;
        private int idComprobanteTipoSelec;

        private delegate void myDel();

        public frmDetallesComprobantes()
        {
            InitializeComponent();
        }

        private void ComenzarCarga()
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
                dtComprobantesTipo = new Comprobantes_Tipo().Listar();
                dtComprobatesDetalle = new Comprobantes_Detalle_Impresion().Listar();           

                myDel MD = new myDel(asignarDatos);

                this.Invoke(MD, new object[] { });

                pgCircular.Stop();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar Informacion " + ex.Message);
            }
        }

        private void asignarDatos()
        {
            dgv.DataSource = dtComprobantesTipo;

            foreach (DataGridViewColumn col in dgv.Columns)
            {
                col.Visible = false;
            }

            dgv.Columns["nombre"].Visible = true;
            dgv.Columns["letra"].Visible = true;
            dgv.Columns["nombre"].HeaderText = "Comprobante";
            dgv.Columns["nombre"].HeaderText = "Tipo";
        }

        private void GuardarDetalles()
        {
            this.Cursor = Cursors.WaitCursor;
            Comprobantes_Detalle_Impresion comDetImp = new Comprobantes_Detalle_Impresion();
            comDetImp.Guardar(idComprobanteTipoSelec, txtDet1.Text.Trim(), txtDet2.Text.Trim());
            txtDet1.Text = string.Empty;
            txtDet2.Text = string.Empty;
            ComenzarCarga();
            this.Cursor = Cursors.Default;
        }

        private void SeleccionarFilaDataGrid(int indexFila)
        {
            idComprobanteTipoSelec = Convert.ToInt32(dgv.Rows[indexFila].Cells["id"].Value);
            bool existia = false;
            foreach (DataRow row in dtComprobatesDetalle.Rows)
            {
                if(Convert.ToInt32(row["id_comprobante_tipo"]) == idComprobanteTipoSelec)
                {
                    string detalle1 = row["detalle1"].ToString();
                    string detalle2 = row["detalle2"].ToString();
                    lblDetActual1.Text = detalle1;
                    lblDetActual2.Text = detalle2;
                    existia = true;
                }
            }

            if (!existia)
            {
                lblDetActual1.Text = string.Empty;
                lblDetActual2.Text = string.Empty;
            }

            lblTipoComp.Text = $"{dtComprobantesTipo.Rows[indexFila]["nombre"]} - {dtComprobantesTipo.Rows[indexFila]["letra"]}";
        }

        private void frmDetallesComprobantes_Load(object sender, EventArgs e)
        {
            ComenzarCarga();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            GuardarDetalles();
        }

        private void dgvComprobantes_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            SeleccionarFilaDataGrid(e.RowIndex);
        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmDetallesComprobantes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
