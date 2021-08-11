using CapaNegocios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace CapaPresentacion.Facturas
{
    public partial class frmEnviaFacturasElectronicas : Form
    {
        private Thread hilo;
        private delegate void myDel();

        private Comprobantes oComprobantes = new Comprobantes();
        private Usuarios oUsuario = new Usuarios();
        private Tools oTools = new Tools();

        private DataTable dtComprobantes;
        private DataTable dtDatosUsuarios = new DataTable();
        private DataTable dtDatosDocYArchivos = new DataTable();
        private DataTable dtFacturasConErrores;

        private Int32 cantSeleccionado = 0;
        private Int32 contador = 0;
        private Decimal porcentajeHecho;
        private Comprobantes.Estado_Factura estadoFactura;

        private String ruta;
        private int i = 0;
        private int indicePrimeroSel = 0;

        public frmEnviaFacturasElectronicas()
        {
            InitializeComponent();
            dtpDesde.Value = DateTime.Now;
            dtpHasta.Value = DateTime.Now;
        }
        #region INICIO

        private void comenzarCarga()
        {
            btnGuardar.Enabled = true;
            btnSeleccionarTodo.Enabled = true;
            int x, y;
            x = (spMain.Width / 2) - (pnlCargando.Width / 2);
            y = (spMain.Height / 2) - (pnlCargando.Height / 2);
            //asignamos la nueva ubicación
            pnlCargando.Location = new Point(x, y);
            dgvFacturas.DataSource = null;
            pgCircular.Start();
            if (rbNoEnviados.Checked) { estadoFactura = Comprobantes.Estado_Factura.NO_ENVIADA; }
            else if (rbEnviados.Checked) { estadoFactura = Comprobantes.Estado_Factura.ENVIADA; }
            else { estadoFactura = Comprobantes.Estado_Factura.TODAS; }
            spMain.Panel1Collapsed = false;
            spMain.Panel2Collapsed = true;
            dgvFacturas.DataSource = null;
            hilo = new Thread(new ThreadStart(cargarDatos));
            hilo.Start();
        }
        private void cargarDatos()
        {
            dtDatosDocYArchivos = new DataTable();
            dtFacturasConErrores = new DataTable();
            dtFacturasConErrores.Columns.Add(new DataColumn("id_comprobante", typeof(string)));
            dtComprobantes = new DataTable();
            dtComprobantes = oComprobantes.ListarFacturasElectronicasSinEnviar(dtpDesde.Value.Date, dtpHasta.Value.Date, estadoFactura);
            DataColumn dcColumnaSel = new DataColumn("select", typeof(bool));
            dcColumnaSel.ColumnName = "select";
            dcColumnaSel.ReadOnly = false;
            dcColumnaSel.Caption = "Seleccionar";
            dcColumnaSel.DefaultValue = false;
            dtComprobantes.Columns.Add(dcColumnaSel);
            dtComprobantes.Columns.Add(new DataColumn("pathFactura", typeof(string)) { DefaultValue = ""});
            myDel MD = new myDel(AsignarDatos);
            this.Invoke(MD, new object[] { });
            pgCircular.Stop();
        }

        private void AsignarDatos()
        {

            if (dtComprobantes.Rows.Count > 0)
            {
                dgvFacturas.DataSource = dtComprobantes;
                dgvFacturas.ReadOnly = false;
                lblTotal.Text = string.Format("Total de Registros: {0}", dtComprobantes.Rows.Count);
                FormatearGrilla();
            }
            else
                MessageBox.Show("No se encontraron facturas sin enviar", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);

            spMain.Panel1Collapsed = true;
            spMain.Panel2Collapsed = false;
            dtDatosDocYArchivos.Columns.Add("nombre_archivo", typeof(String));

        }
        #endregion

        private void FormatearGrilla()
        {
            foreach (DataGridViewColumn item in dgvFacturas.Columns)
                item.Visible = false;

            dgvFacturas.Columns["select"].Visible = true;
            dgvFacturas.Columns["select"].HeaderText = "Seleccionar";

            dgvFacturas.Columns["codigo_usuario"].Visible = true;
            dgvFacturas.Columns["codigo_usuario"].HeaderText = "Codigo";
            dgvFacturas.Columns["codigo_usuario"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            dgvFacturas.Columns["descripcion"].Visible = true;
            dgvFacturas.Columns["descripcion"].HeaderText = "Detalle";
            dgvFacturas.Columns["descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            dgvFacturas.Columns["usuario"].Visible = true;
            dgvFacturas.Columns["usuario"].HeaderText = "Usuario";
            dgvFacturas.Columns["usuario"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            dgvFacturas.Columns["importe_original"].Visible = true;
            dgvFacturas.Columns["importe_original"].HeaderText = "Importe original";
            dgvFacturas.Columns["importe_original"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvFacturas.Columns["importe_original"].DefaultCellStyle.Format = "c2";

            dgvFacturas.Columns["importe_bonificacion"].Visible = true;
            dgvFacturas.Columns["importe_bonificacion"].HeaderText = "Importe bonificado";
            dgvFacturas.Columns["importe_bonificacion"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvFacturas.Columns["importe_bonificacion"].DefaultCellStyle.Format = "c2";

            dgvFacturas.Columns["importe_final"].Visible = true;
            dgvFacturas.Columns["importe_final"].HeaderText = "Importe final";
            dgvFacturas.Columns["importe_final"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvFacturas.Columns["importe_final"].DefaultCellStyle.Format = "c2";

            dgvFacturas.Columns["correo_electronico"].Visible = true;
            dgvFacturas.Columns["correo_electronico"].HeaderText = "Correo electronico";
            dgvFacturas.Columns["correo_electronico"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;


            foreach (DataGridViewColumn item in dgvFacturas.Columns)
            {
               item.ReadOnly = false;

            }
        }

        private void frmEnviaFacturasElectronicas_Load(object sender, EventArgs e)
        {
            //comenzarCarga();
        }

        private void dgvFacturas_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void dgvFacturas_CellEnter(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvFacturas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int columnIndex = dgvFacturas.CurrentCell.ColumnIndex;
            string columnName = dgvFacturas.Columns[columnIndex].Name;
            if (columnName == "select")
            {
                DataGridViewRow dr;
                dr = dgvFacturas.CurrentRow;
                if (Convert.ToBoolean(dr.Cells["select"].Value) == true)
                {
                    dgvFacturas.CurrentCell.Value = false;
                    cantSeleccionado--;
                }
                else
                {
                    dgvFacturas.CurrentCell.Value = true;
                    cantSeleccionado++;
                }
            }

        }

        private void TerminardoEnviar(object o, RunWorkerCompletedEventArgs e)
        {
            pgBar.Value = pgBar.Maximum;
            MessageBox.Show("Los archivos se han enviado correctamente", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.KeyPreview = true;
            imgReturn.Enabled = true;
            this.Cursor = Cursors.Arrow;
            pgCircular2.Stop();
        }

        private void EnviarArchivos(object o, DoWorkEventArgs e)
        {
            foreach (DataRow row in dtComprobantes.Rows)
            {
                if (oTools.EnviarFacturaElectronica(row["correo_electronico"].ToString(), row["pathFactura"].ToString()) != -1)
                {
                    oComprobantes.ActualizarEnviado(Convert.ToInt32(row["IdComprobante"]));
                }

                tarea2.ReportProgress(contador, i);
                contador++;
            }
        }

        private void btnFacturacion_Click(object sender, EventArgs e)
        {
            contador = 0;
            pgCircular2.Start();
            pgBar.Value = 0;
            pgBar.Maximum = cantSeleccionado;
            imgReturn.Enabled = false;
            this.KeyPreview = false;
            Cursor = Cursors.WaitCursor;
            btnFacturacion.Enabled = false;

            tarea2.DoWork += EnviarArchivos;
            tarea2.RunWorkerCompleted += TerminardoEnviar;
            tarea2.RunWorkerAsync();

        }


        private void GenerarReportes(object o, DoWorkEventArgs e)
        {
            Boolean seleccionado = false;
            if (cantSeleccionado > 0)
            {
                foreach (DataRow item in dtComprobantes.Rows)
                {
                    seleccionado = Convert.ToBoolean(item["select"]);
                    if (seleccionado == true)
                    {
                        try
                        {
                            Impresiones.Impresion oIMpresion = new Impresiones.Impresion();
                            int idComprobante = Convert.ToInt32(item["idComprobante"]);
                            int idUsuario = Convert.ToInt32(item["id_usuarios"]);
                            int idLocacion = Convert.ToInt32(item["id_usuarios_locaciones"]);
                            string calle = item["calle"].ToString();
                            int altura = Convert.ToInt32(item["altura"]);
                            string piso = item["piso"].ToString();
                            string depto = item["depto"].ToString();
                            string codigo_postal = item["codigo_postal"].ToString();
                            string localidad = item["localidad"].ToString();
                            string entre_Calle_1 = item["entre_calle_1"].ToString();
                            string entre_calle_2 = item["entre_calle_2"].ToString();

                            oUsuario.LlenarObjeto(idUsuario);
                            Usuarios.CurrentUsuario.piso = piso;
                            Usuarios.CurrentUsuario.Depto = depto;
                            Usuarios.CurrentUsuario.Calle = calle;
                            Usuarios.CurrentUsuario.Entre1 = entre_Calle_1;
                            Usuarios.CurrentUsuario.Entre2 = entre_calle_2;
                            Usuarios.CurrentUsuario.localidad = localidad;
                            Usuarios.CurrentUsuario.Cod_postal = codigo_postal;
                            Usuarios.CurrentUsuario.Altura = altura;
                            string nombreArchivo = oIMpresion.Imprime_factura_RDLC(false, idComprobante, true, ruta);
                            item["pathFactura"] = $"{ruta}\\{nombreArchivo}";
                            tarea.ReportProgress(contador, dtComprobantes.Rows.Count);
                            contador++;

                        }
                        catch (Exception ex)
                        {
                           // MessageBox.Show("Ocurrio un error al gerenerar el reporte", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            DataRow dr = dtFacturasConErrores.NewRow();
                            dr["id_comprobante"] = item["idComprobante"].ToString();
                            dtFacturasConErrores.Rows.Add(dr);
                            tarea.ReportProgress(contador, dtComprobantes.Rows.Count);
                            contador++;
                        }
                    }
                }
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            indicePrimeroSel = 0;
            int contadorAux = 0;
            foreach (DataGridViewRow item in dgvFacturas.Rows)
            {
                if (Convert.ToBoolean(item.Cells["select"].Value) == true)
                {
                    if (indicePrimeroSel == 0 && contadorAux==0)
                        indicePrimeroSel = contadorAux;
                }
                contadorAux++;
            }
            if (cantSeleccionado > 0)
            {
                this.KeyPreview = false;
                imgReturn.Enabled = false;
                FolderBrowserDialog fb = new FolderBrowserDialog();
                fb.Description = "Seleccione el Directorio donde se guardaran las facturas";
                DialogResult dirSelected = fb.ShowDialog(this);
                if (dirSelected == DialogResult.OK)
                {
                    if (Directory.EnumerateFiles(fb.SelectedPath).Any())
                    {
                        DialogResult dr = MessageBox.Show("La carpeta seleccionada ya contiene archivos, en el caso que el nombre del pdf de la factura generada se igual a un archivo existente lo remplazara. ¿Continuar de todos modos?", "Mensaje del sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (dr == DialogResult.No)
                            return;
                    }
                    ruta = fb.SelectedPath;
                    pgCircular2.Start();
                    pgBar.Maximum = cantSeleccionado;
                    imgReturn.Enabled = false;
                    this.KeyPreview = false;
                    Cursor = Cursors.WaitCursor;
                    btnFacturacion.Enabled = false;
                    tarea.DoWork += GenerarReportes;
                    tarea.RunWorkerCompleted += Terminado;
                    tarea.RunWorkerAsync();
                }
            }
        }

        private void Terminado(object o, RunWorkerCompletedEventArgs e)
        {
            pgBar.Value = pgBar.Maximum;
            this.Cursor = Cursors.Arrow;
            MessageBox.Show("Facturas exportadas.", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.KeyPreview = true;
            imgReturn.Enabled = true;
            btnFacturacion.Enabled = true;

            btnSeleccionarTodo.Enabled = false;
            btnGuardar.Enabled = false;
        }

        private void tarea_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void tarea_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            pgBar.Value = pgBar.Maximum;
            lblCuanto.Text = string.Format("Procesando: {0} de {1} ({2} %)", cantSeleccionado, cantSeleccionado, "100");
            this.Cursor = Cursors.Arrow;
            pgCircular2.Stop();
            imgReturn.Enabled = true;
            this.KeyPreview = true;
            dgvFacturas.Cursor = Cursors.Arrow;
        }

        private void tarea_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pgBar.Value = e.ProgressPercentage;
            porcentajeHecho = (contador * 100) / cantSeleccionado;
            lblCuanto.Text = string.Format("Procesando: {0} de {1} ({2} %)", contador, cantSeleccionado, porcentajeHecho.ToString());
            pnlProgreso.Visible = true;
            try
            {
                dgvFacturas.Rows[indicePrimeroSel + (contador - 1)].DefaultCellStyle.BackColor = Color.SkyBlue;
                dgvFacturas.Rows[indicePrimeroSel + (contador - 1)].Selected = true;
            }
            catch (Exception c){
                MessageBox.Show("  vv : "+c.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dtpDesde.Value >= dtpHasta.Value)
            {
                MessageBox.Show("La fecha desde no puede ser mayor o igual a la fecha hasta", "Mensaje del sistema");
                return;
            }
            comenzarCarga();
        }

        private void btnSeleccionarTodo_Click(object sender, EventArgs e)
        {
            cantSeleccionado = 0;
            foreach (DataGridViewRow item in dgvFacturas.Rows)
            {
                item.Cells["select"].Value = true;
                cantSeleccionado++;
            }
        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmEnviaFacturasElectronicas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void pnlControles_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tarea2_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pgBar.Value = e.ProgressPercentage;
            porcentajeHecho = (contador * 100) / cantSeleccionado;
            lblCuanto.Text = string.Format("Procesando: {0} de {1} ({2} %)", contador, cantSeleccionado, porcentajeHecho.ToString());
            pnlProgreso.Visible = true;
            try
            {
                dgvFacturas.Rows[indicePrimeroSel + (contador - 1)].DefaultCellStyle.BackColor = Color.SteelBlue;
                dgvFacturas.Rows[indicePrimeroSel + (contador - 1)].DefaultCellStyle.ForeColor = Color.White;

                dgvFacturas.Rows[indicePrimeroSel + contador].Selected = true;
            }
            catch { }
        }

        private void tarea2_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void tarea2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (dtpDesde.Value >= dtpHasta.Value)
            {
                MessageBox.Show("La fecha desde no puede ser mayor o igual a la fecha hasta", "Mensaje del sistema");
                return;
            }
            comenzarCarga();
        }

        private void txtbusca_TextChanged(object sender, EventArgs e)
        {
            int cod=0;
            if (dtComprobantes.Rows.Count > 0 && txtbusca.Text.Trim().Length > 0)
            {
                DataView dv = dtComprobantes.DefaultView;

                string texto = txtbusca.Text.Trim();
                if(int.TryParse(texto, out cod))
                    dtComprobantes.DefaultView.RowFilter = String.Format("codigo_usuario ={0} ", cod);
                else
                    dtComprobantes.DefaultView.RowFilter = String.Format("descripcion Like '%{0}%' OR usuario Like '%{0}%'  OR correo_electronico Like '%{0}%'", texto);

            }
            else
                dtComprobantes.DefaultView.RowFilter = "";
        }
    }
}
