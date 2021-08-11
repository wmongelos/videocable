using CapaNegocios;
using System;
using System.Data;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace CapaPresentacion.Debitos_Automaticos
{
    public partial class frmDebitosDeudasAnexadas : Form
    {
        string nroDebito = string.Empty;
        private DataTable dtDeudas = new DataTable();
        private DataTable dtPresentaciones = new DataTable();
        Thread hilo;
        private delegate void myDel();
        private Usuarios_CtaCte_Det oUsuariosCtaCteDet = new Usuarios_CtaCte_Det();
        private Presentacion_Debitos oPresentacion = new Presentacion_Debitos();
        private Tools oTools = new Tools();
        private int Ultimas, Todas;
        private DataTable dtYears = new DataTable();

        public frmDebitosDeudasAnexadas()
        {
            InitializeComponent();
        }

        private void frmDebitosDeudasAnexadas_Load(object sender, EventArgs e)
        {
            pgCircular.Location = new Point(
                        this.ClientSize.Width / 2 - pgCircular.Size.Width / 2,
                        this.ClientSize.Height / 2 - pgCircular.Size.Height / 2);
            pgCircular.Anchor = AnchorStyles.None;
            cboMeses.DataSource = Tablas.DataMeses;
            cboMeses.DisplayMember = "nombre";
            cboMeses.ValueMember = "id";

            dtYears.Columns.Add("year", typeof(string));
            dtYears.Columns.Add("year_id", typeof(int));
            int cantYaears = 5;
            int actualYear = DateTime.Now.Year;

            for (int i = actualYear; i < actualYear + cantYaears; i++)
                dtYears.Rows.Add(i.ToString(), i);//el string es para lo que se ve y el int es para el valor que puede leer de la base en caso que el plastico ya exista

            cboAnio.DataSource = dtYears;
            cboAnio.DisplayMember = "year";
            cboAnio.ValueMember = "year_id";

            dtPresentaciones= oPresentacion.ListarTodas();
            cboPresentaciones.DataSource = dtPresentaciones;
            cboPresentaciones.DisplayMember = "Periodo";
            cboPresentaciones.ValueMember = "Id";
        }

        private void Buscar()
        {
            int idPresentacionSeleccionada;
            int anioSeleccionado, mesSeleccionado;
            this.Cursor = Cursors.WaitCursor;
            if (rbExistente.Checked)
            {
                idPresentacionSeleccionada = Convert.ToInt32(cboPresentaciones.SelectedValue);
                dtDeudas = oUsuariosCtaCteDet.ListarDeudasAnexadasDebitos(idPresentacionSeleccionada);
                btnLiberar.Enabled = false;
            }
            else
            {
                mesSeleccionado = Convert.ToInt32(cboMeses.SelectedValue);
                anioSeleccionado = Convert.ToInt32(cboAnio.SelectedValue);
                dtDeudas = oPresentacion.ListarAnexadas(mesSeleccionado, anioSeleccionado);
                btnLiberar.Enabled = true;


            }
            this.Cursor = Cursors.Default;

            ComenzarCarga();
        }

        private void ComenzarCarga()
        {
            pgCircular.Visible = true;
            pgCircular.Start();
            hilo = new Thread(new ThreadStart(CargarDatos));
            hilo.IsBackground = true;
            hilo.Start();
        }

        private void CargarDatos()
        {
            try
            {
                myDel MD = new myDel(AsignarDatos);
                this.Invoke(MD, new object[] { });
            }
            catch
            {
                MessageBox.Show("Error al cargar información.");
            }
            pgCircular.Stop();
        }

        private void AsignarDatos()
        {
            pgCircular.Visible = false;
            dgvDeudas.DataSource = dtDeudas;
            object suma;
            if (dtDeudas.Rows.Count > 0)
            {
                suma = dtDeudas.Compute("Sum(importe_final)", string.Empty);
                lblAnexado.Text = string.Format("Total anexado: {0}", Convert.ToDecimal(suma).ToString("c2"));
            }
            FormatearGrilla();
            lblTotal.Text = String.Format("Total de Registros: {0}", dgvDeudas.Rows.Count);

            try
            {
                dgvDeudas.Rows[dgvDeudas.Rows.Count - 1].Selected = true;
            }
            catch { }

            if(rbExistente.Checked)
                btnLiberar.Enabled = false;
            else
                btnLiberar.Enabled = true;

        }

        private void FormatearGrilla()
        {
           for (int x = 0; x < dgvDeudas.Columns.Count; x++)
               dgvDeudas.Columns[x].Visible = false;
            dgvDeudas.Columns["codigo"].Visible = true;
            dgvDeudas.Columns["descripcion"].Visible = true;
            dgvDeudas.Columns["usuario"].Visible = true;
            dgvDeudas.Columns["fecha_movimiento"].Visible = true;
            dgvDeudas.Columns["importe_final"].Visible = true;
            dgvDeudas.Columns["debito_asociado"].Visible = true;
            dgvDeudas.Columns["titular"].Visible = true;
            dgvDeudas.Columns["codigo"].HeaderText = "Codigo";
            dgvDeudas.Columns["codigo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvDeudas.Columns["descripcion"].HeaderText = "Descripción";
            dgvDeudas.Columns["usuario"].HeaderText = "Usuario";
            dgvDeudas.Columns["fecha_movimiento"].HeaderText = "Fecha";
            dgvDeudas.Columns["fecha_movimiento"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvDeudas.Columns["importe_final"].HeaderText = "Importe";
            dgvDeudas.Columns["importe_final"].DefaultCellStyle.Alignment =  DataGridViewContentAlignment.MiddleRight;
            dgvDeudas.Columns["importe_final"].DefaultCellStyle.Format = "c2";
            dgvDeudas.Columns["importe_final"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvDeudas.Columns["debito_asociado"].HeaderText = "Débito asociado";
            dgvDeudas.Columns["titular"].HeaderText = "Titular";
            txtBuscador.Enabled = true;
        }

        void contextMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Text == "Copiar" && dgvDeudas.CurrentCell.Value != null)
            {
                Clipboard.SetDataObject(dgvDeudas.CurrentCell.Value.ToString(), false);
            }
        }

        void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.ColumnIndex != -1 && e.RowIndex != -1)
            {
                dgvDeudas.Rows[e.RowIndex].Cells[e.ColumnIndex].ContextMenuStrip = contextMenu;
                dgvDeudas.CurrentCell = dgvDeudas.Rows[e.RowIndex].Cells[e.ColumnIndex];
            }
        } 

        private void btnLiberar_Click(object sender, EventArgs e)
        {
           
            if (dgvDeudas.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("¿Desea liberar la deuda seleccionada?", "Mensaje del sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;

                if (oUsuariosCtaCteDet.LiberarDeudaAnexada(Convert.ToInt32(dgvDeudas.SelectedRows[0].Cells["id"].Value)) == 0)
                {
                    MessageBox.Show("La deuda se ha liberado correctamente.");
                    Buscar();
                    txtBuscarPlastico_TextChanged(txtBuscador, new EventArgs());
                }
                else
                    MessageBox.Show("Error al liberar deuda anexada.");
            }
        }

        private void txtBuscarPlastico_TextChanged(object sender, EventArgs e)
        {

            dtDeudas.DefaultView.RowFilter = String.Format("convert(codigo, System.String) like '%{0}%' or usuario like '%{0}%' " +
                    "or convert(debito_asociado, System.String) like '%{0}%' or titular like '%{0}%'", txtBuscador.Text);

            lblTotal.Text = String.Format("Total de Registros: {0}", dgvDeudas.Rows.Count);
        }

        private void ExportarAExcel()
        {
            if (dgvDeudas.Rows.Count > 0)
            {
                oTools.ExportDataTableToExcel(dtDeudas, "Deudas_Anexadas " + cboMeses.Text + "_" + cboAnio.Text);
            }
            else
                MessageBox.Show("No hay datos en la grilla.");
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (rbFuturas.Checked)
            {
                int mes = Convert.ToInt32(cboMeses.SelectedValue);
                int anio = Convert.ToInt32(cboAnio.SelectedValue);
                DateTime fechaSeleccionada = new DateTime(anio, mes, 1);
                DataView dvPresentacion = dtPresentaciones.DefaultView;
                dvPresentacion.RowFilter = $"fecha_presentacion ='{fechaSeleccionada}'";
                if (dvPresentacion.Count > 0)
                {
                    MessageBox.Show("La fecha seleccionada ya pertenece a una presentacion, para buscar deudas ya presentadas, seleccione la opcion 'Presentado'","Mensaje del Sistema",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                }
                else
                {
                    Buscar();

                }
            }
            else
                Buscar();
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            ExportarAExcel();
        }

        private void frmDebitosDeudasAnexadas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void rbTodas_CheckedChanged(object sender, EventArgs e)
        {
            cboPresentaciones.Visible = true;
            //btnBuscar.Enabled = true;
            //if (rbTodas.Checked == true) 
            //{
            //    Todas = 1;
            //    Ultimas = 0;
            //    if (Todas == 1)
            //    {                    
            //        cboPresentaciones.DataSource = oPresentacion.ListarTodas();
            //        cboPresentaciones.DisplayMember = "Periodo";
            //        cboPresentaciones.ValueMember = "Id";
            //    }
            //}
        }

        private void rbUltimas_CheckedChanged(object sender, EventArgs e)
        {
            //cboPresentaciones.Enabled = true;
            //btnBuscar.Enabled = true;
            //if (rbFuturas.Checked == true)
            //{
            //    Todas = 0;
            //    Ultimas = 1;
            //    if (Ultimas == 1)
            //    {
            //        cboPresentaciones.DataSource = oPresentacion.ListarUltimasPresentacion();
            //        cboPresentaciones.DisplayMember = "Periodo";
            //        cboPresentaciones.ValueMember = "Id";
            //    }
            //}

            if (rbExistente.Checked)
            {
                cboPresentaciones.Visible = true;

                lblMeses.Visible = false;
                lblAnios.Visible = false;
                cboMeses.Visible = false;
                cboAnio.Visible = false;
            }
            else
            {
                cboPresentaciones.Visible = false;
                lblMeses.Visible = true;
                lblAnios.Visible = true;
                cboMeses.Visible = true;
                cboAnio.Visible = true;
            }


        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}//111911fede
