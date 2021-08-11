using CapaNegocios;
using System;
using System.Data;
using System.Threading;
using System.Windows.Forms;

namespace CapaPresentacion.Abms
{
    public partial class ABMImpresiones : Form
    {
        private Thread hilo;
        private delegate void myDel();
        private DataTable dtPersonal, dtPuntosdeCobro;
        private Comprobante_impresion oImpresiones = new Comprobante_impresion();
        private Personal oImpresionPersonal = new Personal();
        private Puntos_Cobros oPuntos_cobros = new Puntos_Cobros();
        Int32 id_impresiones = 0;
        private Comprobantes_Tipo oComprobantes_tipo = new Comprobantes_Tipo();


        public ABMImpresiones()
        {
            InitializeComponent();
        }

        #region INICIO DE DATOS.
        private void ComenzarCarga()
        {

            //pgCircular.Start();

            dgvImpresiones.DataSource = null;
            hilo = new Thread(new ThreadStart(cargarDatos));
            hilo.Start();
        }

        private void cargarDatos()
        {
            try
            {
                dtPuntosdeCobro = oImpresiones.Listar_impresionComprobantes();

                myDel MD = new myDel(AsignarDatos);

                this.Invoke(MD, new object[] { });

                //pgCircular.Stop();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar Informacion" + ex.Message);
            }

        }

        private void AsignarDatos()
        {
            dgvImpresiones.DataSource = dtPuntosdeCobro;
            dtPersonal = oImpresiones.ListarPorPersonal(1);
            for (int i = 0; i < dgvImpresiones.ColumnCount; i++)
                dgvImpresiones.Columns[i].Visible = false;
            dgvImpresiones.Columns["Nombre"].Visible = true;
            dgvImpresiones.Columns["Nombre"].HeaderText = "Personal";
            dgvImpresiones.Columns["Letra"].Visible = true;
            dgvImpresiones.Columns["Comprobante"].Visible = true;
            dgvImpresiones.Columns["impresora"].Visible = true;
            dgvImpresiones.Columns["impresora_bandeja"].Visible = true;
            dgvImpresiones.Columns["impresora_bandeja"].HeaderText = "Bandeja";


            cmbPuntoCobro.DataSource = oPuntos_cobros.Listar();
            cmbPuntoCobro.ValueMember = "Id";
            cmbPuntoCobro.DisplayMember = "Descripcion";


        }

        private void AsignarComprobantesPersonal()
        {


            Int32 id_comboPersonal;

            id_comboPersonal = Convert.ToInt32(cboPersonal.SelectedValue.ToString());
            dtPersonal = oImpresiones.ListarPorPersonal(id_comboPersonal);

            dgvComprobantesTipo.DataSource = dtPersonal;
            for (int i = 0; i < dgvComprobantesTipo.ColumnCount; i++)
                dgvComprobantesTipo.Columns[i].Visible = false;

            dgvComprobantesTipo.Columns["tipofactura"].Visible = true;
            dgvComprobantesTipo.Columns["letra"].Visible = true;
            dgvComprobantesTipo.Columns["impresora"].Visible = true;
            dgvComprobantesTipo.Columns["impresora_bandeja"].Visible = true;
            dgvComprobantesTipo.Columns["camino"].Visible = true;
            dgvComprobantesTipo.ReadOnly = false;
            dgvComprobantesTipo.Columns["impresora_bandeja"].ReadOnly = false;
            dgvComprobantesTipo.Columns["impresora"].ReadOnly = true;
            dgvComprobantesTipo.Columns["letra"].ReadOnly = true;
            dgvComprobantesTipo.Columns["tipofactura"].ReadOnly = true;

        }

        private void filtrarDatos()
        {
            dtPuntosdeCobro.DefaultView.RowFilter = String.Format("id_puntos_cobros = {0}", id_impresiones);
        }

        #endregion

        private void ABMImpresiones_Load(object sender, EventArgs e)
        {
            ComenzarCarga();
        }

        private void cmbPuntoCobro_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                id_impresiones = Convert.ToInt32(cmbPuntoCobro.SelectedValue.ToString());
                filtrarDatos();



            }
            catch
            {
                // throw;
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            cboPersonal.DataSource = oImpresionPersonal.ListarPorPuntoDeCobro(Convert.ToInt32(cmbPuntoCobro.SelectedValue.ToString()));
            cboPersonal.ValueMember = "Id";
            cboPersonal.DisplayMember = "Nombre";

            cntDatos.Visible = true;
            AsignarComprobantesPersonal();
        }

        private void btnConfirma_Click(object sender, EventArgs e)
        {
            oImpresiones.EliminarPersonal(Convert.ToInt32(cboPersonal.SelectedValue.ToString()));

            foreach (DataGridViewRow drGrillaAgrega in dgvComprobantesTipo.Rows)
            {
                oImpresiones.id_puntos_cobros = Convert.ToInt32(cmbPuntoCobro.SelectedValue.ToString());
                oImpresiones.id_comprobantes_tipo = Convert.ToInt32(drGrillaAgrega.Cells["Id"].Value.ToString());
                oImpresiones.id_personal = Convert.ToInt32(cboPersonal.SelectedValue.ToString());
                oImpresiones.impresora = drGrillaAgrega.Cells["impresora"].Value.ToString();
                oImpresiones.impresora_bandeja = Convert.ToInt32(drGrillaAgrega.Cells["impresora_bandeja"].Value.ToString());
                oImpresiones.camino_reporte = drGrillaAgrega.Cells["camino"].Value.ToString();
                if (oImpresiones.impresora != "...")
                    oImpresiones.Guardar(oImpresiones);
            }
            cargarDatos();
            cntDatos.Visible = false;
        }

        private void btnCancela_Click(object sender, EventArgs e)
        {
            VerificarCambios();

        }

        private void VerificarCambios()
        {
            DataTable dtExtra = new DataTable();
            dtExtra = dtPersonal.GetChanges();
            try
            {

                if (dtExtra != null)
                {

                    if (MessageBox.Show("¿Desea salir sin guardar los cambios?", "Mensaje del Sistema",
                       MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        cntDatos.Visible = false;
                    }

                }
                else
                {
                    cntDatos.Visible = false;
                }
            }
            catch { }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void cboPersonal_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                AsignarComprobantesPersonal();
            }
            catch { }
        }


        private void dgvComprobantesTipo_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgvComprobantesTipo.Columns[e.ColumnIndex].Name == "impresora")
            {
                if (e.Button == MouseButtons.Right)
                {
                    if (MessageBox.Show("¿Desea Eliminar la impresora seleccionada?", "Mensaje del Sistema",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (dgvComprobantesTipo.Columns[e.ColumnIndex].Name == "impresora")
                        {
                            dgvComprobantesTipo.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "...";
                            dgvComprobantesTipo.Rows[e.RowIndex].Cells["impresora_bandeja"].Value = 0;
                        }
                    }

                }
                else
                {

                    PrintDialog printDialog1 = new PrintDialog();
                    //   printDialog1.Document = printDocument1;
                    DialogResult result = printDialog1.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        dgvComprobantesTipo.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = printDialog1.PrinterSettings.PrinterName;

                        //   printDocument1.Print();
                    }
                }



            }

            if (dgvComprobantesTipo.Columns[e.ColumnIndex].Name == "camino")
            {
                FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();

                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    string path = folderBrowserDialog.SelectedPath;
                    path = path.Replace("\\", "\\\\");
                    dgvComprobantesTipo.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = path;
                }
            }
        }

        private void btnElimina_Click(object sender, EventArgs e)
        {
            if (dgvImpresiones.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("¿Desea Eliminar el Articulo Seleccionado?", "Mensaje del Sistema",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    oImpresiones.Eliminar(Convert.ToInt32(dgvImpresiones.SelectedRows[0].Cells["Id"].Value.ToString()));
                    cargarDatos();
                }
            }


        }
    }
}

