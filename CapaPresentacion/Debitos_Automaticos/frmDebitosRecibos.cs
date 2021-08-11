using CapaNegocios;
using CapaPresentacion.Cuenta_Corriente;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace CapaPresentacion.Debitos_Automaticos
{
    public partial class frmDebitosRecibos : Form
    {
        private Thread hilo;
        private delegate void myDel();
        private DataTable dtDeudas = new DataTable();
        private DataTable dtDeudasAgrupadas = new DataTable();
        private DataTable dtUltimaPresentacion = new DataTable();
        private DataTable dtPuntosVentas = new DataTable();
        private Presentacion_Usuarios_Servicios oPresentacionUS = new Presentacion_Usuarios_Servicios();
        private Presentacion_Debitos oPresentacionDeb = new Presentacion_Debitos();
        private Usuarios_CtaCte oCtaCte = new Usuarios_CtaCte();
        private Comprobantes_Tipo oComprobanteTipo = new Comprobantes_Tipo();
        private Usuarios_CtaCte oCtacte = new Usuarios_CtaCte();
        private Usuarios_Locaciones oUsuLoc = new Usuarios_Locaciones();
        private Usuarios_CtaCte_Det oDet = new Usuarios_CtaCte_Det();
        private Facturacion oFactura = new Facturacion();
        private Tools oTool = new Tools();
        private Puntos_Venta oPuntoVenta = new Puntos_Venta();
        private DataTable dtLocaciones;
        private DataTable[] dtResultados = new DataTable[2];
        private DataTable dtComprobantesErrores = new DataTable();
        private DataTable dtCtaCteDetfinal = new DataTable();
        private DataTable dtSeleccionados = new DataTable();
        private DataView dv;
        private DataRow dr;
        private Int32 contador = 0, idPresentacion, columnasCargadas = 0, idCtaCte = 0, deRechazar = 0, idPresentacionDebito = 0, idCtaCteDet = 0;
        private Color oColor;

        private Int32 idUltimaPresentacionDeb = 0, flag = 0, flag2 = 0;
        #region METODOS
        private void BloquearControles()
        {
            foreach (Control item in this.Controls)
            {
                if (item.Name != "pgCircular")
                    item.Enabled = false;
            }
        }
        private void DesbloquearControles()
        {
            foreach (Control item in this.Controls)
                item.Enabled = true;
        }
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
                int mes = 0, anio = 0;
                if (flag == 0)
                {

                    dtPuntosVentas = oPuntoVenta.Listar();
                    dtUltimaPresentacion = oPresentacionDeb.ListarUltimasPresentacion();
                    idUltimaPresentacionDeb = Convert.ToInt32(dtUltimaPresentacion.Rows[0]["id"]);
                    mes = Convert.ToDateTime(dtUltimaPresentacion.Rows[0]["fecha_presentacion"]).Date.Month;
                    anio = Convert.ToDateTime(dtUltimaPresentacion.Rows[0]["fecha_presentacion"]).Date.Year;
                }
                else
                {
                    DataView dv = dtUltimaPresentacion.DefaultView;
                    dv.RowFilter = "id=" + idPresentacionDebito;
                    DataTable dt = dv.ToTable();
                    DateTime fecha = Convert.ToDateTime(dt.Rows[0]["fecha_presentacion"]);
                    mes = fecha.Date.Month;
                    anio = fecha.Date.Year;
                }

                dtResultados = oPresentacionUS.ListarDeudasPorPlasticos(idUltimaPresentacionDeb, mes, anio);
                dtDeudas = dtResultados[0];
                dtDeudasAgrupadas = dtResultados[1];
                myDel MD = new myDel(AsignarDatos);
                this.Invoke(MD, new object[] { });
            }
            catch (Exception c)
            {
                MessageBox.Show("Error al cargar información: " + c.Message);
            }
            pgCircular.Stop();
        }

        private void AsignarDatos()
        {


            splitContainer1.Panel2Collapsed = true;
            DataColumn clnEstado = new DataColumn()
            {
                ColumnName = "estado",
                DataType = typeof(Int32),
                DefaultValue = 0

            };
            dtDeudas.Columns.Add(clnEstado);

            dtComprobantesErrores.Clear();
            dtComprobantesErrores.Columns.Clear();
            dtComprobantesErrores.Columns.Add("id_comprobante", typeof(Int32));
            dtComprobantesErrores.Columns.Add("error", typeof(string));
            DataRow dr = dtComprobantesErrores.NewRow();

            cboPeriodos.DataSource = dtUltimaPresentacion;
            cboPeriodos.DisplayMember = "periodo";
            cboPeriodos.ValueMember = "id";
            cboPeriodos.SelectedValue = Convert.ToInt32(dtUltimaPresentacion.Rows[0]["id"]);


            DataColumn clnRecibo = new DataColumn()
            {
                ColumnName = "num_recibo",
                DataType = typeof(Int32),
                DefaultValue = 0

            };
            dtDeudas.Columns.Add(clnRecibo);
            DataColumn clnRecibo2 = new DataColumn()
            {
                ColumnName = "num_recibo",
                DataType = typeof(Int32),
                DefaultValue = 0

            };
            dtDeudasAgrupadas.Columns.Add(clnRecibo2);

            dgvDeudasAnexadas.DataSource = dtDeudas;
            dgvDeudasAnexadas.ReadOnly = false;

            FormatearGrilla(dgvDeudasAnexadas);

            lblTotal.Text = String.Format("Total de Registros: {0}", dgvDeudasAnexadas.Rows.Count);
            marcarRechazados();
            CalcularTotales();
            DesbloquearControles();
            if (flag == 1)
                cboPeriodos.SelectedValue = idPresentacionDebito;
            flag = 1;

        }
        private void FormatearGrilla(DataGridView dgv)
        {

            for (int x = 0; x < dgv.Columns.Count; x++)
            {
                dgv.Columns[x].Visible = false;
                dgv.Columns[x].ReadOnly = true;
            }

            dgv.Columns["titular"].Visible = true;
            dgv.Columns["plastico"].Visible = true;
            dgv.Columns["plastico"].HeaderText = "Num plastico";

            dgv.Columns["codigo"].Visible = true;
            dgv.Columns["codigo"].HeaderText = "Codigo abonado";
            dgv.Columns["codigo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgv.Columns["codigo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns["usuario"].Visible = true;
            dgv.Columns["usuario"].HeaderText = "Nombre abonado";
            dgv.Columns["descripcion"].Visible = true;
            dgv.Columns["total1"].Visible = true;
            dgv.Columns["total1"].HeaderText = "Importe";
            dgv.Columns["total1"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgv.Columns["total1"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns["total1"].ReadOnly = false;

            dgv.Columns["importe_presentado"].Visible = true;
            dgv.Columns["importe_presentado"].HeaderText = "Importe presentado";
            dgv.Columns["importe_presentado"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgv.Columns["importe_presentado"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgv.Columns["num_recibo"].HeaderText = "Recibo";
            dgv.Columns["num_recibo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgv.Columns["num_recibo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            lblTotal.Text = String.Format("Total de Registros: {0}", dgv.Rows.Count);
        }

        private void marcarRechazados()
        {
            foreach (DataGridViewRow item in dgvDeudasAnexadas.Rows)
            {
                if (Convert.ToInt32(item.Cells["rechazado"].Value) == 1)
                    item.DefaultCellStyle.BackColor = Color.LightSalmon;
                if (Convert.ToInt32(item.Cells["rechazado"].Value) == 2)
                    item.DefaultCellStyle.BackColor = Color.LightGreen;
                if (Convert.ToInt32(item.Cells["rechazado"].Value) == 0)
                    item.DefaultCellStyle.BackColor = Color.LightBlue;
                item.Cells["plastico"].Value = item.Cells["plastico"].Value.ToString() + "\u2003";
            }
        }
        private void GenerarLoteRecibos(object o, DoWorkEventArgs e)
        {
            Usuarios_CtaCte_Recibos oRecibo;
            DataTable dtCtacteRef = new DataTable();
            //genero estructura dtRecibosDet

            DataTable dtDetalleRecibo = new DataTable();
            dtDetalleRecibo.Columns.Add("Nombre", typeof(String));
            dtDetalleRecibo.Columns.Add("Importe", typeof(Decimal));
            dtDetalleRecibo.Columns.Add("Cliente", typeof(string));
            dtDetalleRecibo.Columns.Add("Cuenta", typeof(string));
            dtDetalleRecibo.Columns.Add("Cuit", typeof(string));
            dtDetalleRecibo.Columns.Add("Banco", typeof(string));
            dtDetalleRecibo.Columns.Add("Sucursal", typeof(string));
            dtDetalleRecibo.Columns.Add("Fecha_Comprobante", typeof(string));
            dtDetalleRecibo.Columns.Add("Fecha_Acreditacion", typeof(string));
            dtDetalleRecibo.Columns.Add("Numero", typeof(Int32));
            dtDetalleRecibo.Columns.Add("Id_formas_de_pago", typeof(Int32));
            dtDetalleRecibo.Columns.Add("Id_usuarios_locaciones", typeof(Int32));

            contador = 0;
            string NumeroString, pagoNombre, pagoCuit, pagoSucursal, pagoBanco, pagoCliente, pagoCuenta;
            int idCtacteDet, NroRecibo, PtoRecibo, idFormaPago = 2, idUsuario = 0, idComprobante = 0, idComprobanteTipo = 0, idUsuarioCtaCte = 0, idRecibo = 0, idUsuarioLocacion = 0, pagoNumero = 0;
            decimal pagoImporte = 0, importeAux = 0;
            DateTime pagoFechaComprobante, pagoFechaAcredita;
            foreach (DataRow item in dtSeleccionados.Rows)
            {
                dtDetalleRecibo.Rows.Clear();
                contador++;
                importeAux = 0;
                idUsuario = 0;
                idCtacteDet = 0;
                pagoImporte = Convert.ToDecimal(item["total1"]);
                idUsuario = Convert.ToInt32(item["id_usuarios"]);
                idComprobante = Convert.ToInt32(item["id_comprobantes"]);
                idCtaCte = Convert.ToInt32(item["id"]);
                idComprobanteTipo = Convert.ToInt32(item["id_comprobantes_tipo"]);
                idUsuarioLocacion = Convert.ToInt32(item["id_usuarios_locaciones"]);
                idCtacteDet = Convert.ToInt32(item["id_det"]);
                dtLocaciones = oUsuLoc.ListarLocacionesServicio(idUsuario, idUsuarioLocacion);
                importeAux = Convert.ToDecimal(item["total1"]);
                try
                {
                    //genero el comprobante tipo recibo
                    Comprobantes oComprobante = new Comprobantes();
                    oComprobante.Id_Usuarios = idUsuario;
                    oComprobante.Id_Comprobantes_Tipo = (int)Comprobantes_Tipo.Tipo.RECIBO;

                    //duda
                    DataRow drDatosComprobante;
                    drDatosComprobante = oComprobanteTipo.GetNumeracion(Convert.ToInt32(Comprobantes_Tipo.Tipo.RECIBO), Puntos_Cobros.Id_Punto);
                    NroRecibo = Convert.ToInt32(drDatosComprobante["numComprobante"]);
                    PtoRecibo = Convert.ToInt32(drDatosComprobante["numPuntoVenta"]);
                    NumeroString = PtoRecibo.ToString().PadLeft(4, '0') + "-" + NroRecibo.ToString().PadLeft(8, '0');

                    oComprobante.Fecha = DateTime.Now;
                    oComprobante.Id_Personal = Personal.Id_Login;
                    oComprobante.Punto_Venta = Convert.ToInt32(drDatosComprobante["numPuntoVenta"]);
                    oComprobanteTipo.SetNumeracion(Convert.ToInt32(drDatosComprobante["idPuntoVenta"]), Convert.ToInt32(Comprobantes_Tipo.Tipo.RECIBO), NroRecibo);
                    oComprobante.Descripcion = "Recibo débito automatático";
                    oComprobante.Importe = pagoImporte;
                    oComprobante.Numero = NroRecibo;
                    oComprobante.Id_Usuarios_Locaciones = idUsuarioLocacion;
                    oComprobante.Id_Punto_Venta = Convert.ToInt32(drDatosComprobante["idpuntoventa"]);
                    oComprobante.Id = oComprobante.Guardar(oComprobante);

                    //genero el recibo
                    oRecibo = new Usuarios_CtaCte_Recibos();
                    oRecibo.Id_Comprobantes_Ref = idComprobante;
                    oRecibo.Id_Personal = Personal.Id_Login;
                    oRecibo.Descripcion = "Recibo débito automatático";
                    oRecibo.Id_Usuarios = idUsuario;
                    oRecibo.Id_Usuarios_Locacion = idUsuarioLocacion;
                    oRecibo.Fecha_Movimiento = DateTime.Now;
                    oRecibo.Importe_Final = pagoImporte;
                    oRecibo.Id_Comprobantes = oComprobante.Id;
                    oRecibo.Numero_Muestra = "Recibo Nro " + NumeroString;
                    oRecibo.Numero = NroRecibo;
                    oRecibo.Id_Presentacion_Deb = idPresentacion;
                    oRecibo.Id_Puntos_Cobro = Puntos_Cobros.Id_Punto;
                    //agrego los pagos (uno solo ya que es debito automatico
                    pagoCuenta = "cuenta";
                    pagoCliente = item["usuario"].ToString();
                    pagoNombre = item["usuario"].ToString();
                    pagoImporte = Convert.ToInt32(item["total1"]);
                    pagoCuit = "CUIT";
                    pagoBanco = "BANCO";
                    pagoSucursal = "SUCURSAL";
                    pagoFechaComprobante = DateTime.Now;
                    pagoFechaAcredita = DateTime.Now;
                    pagoNumero = 99;
                    idFormaPago = 2;
                    dtDetalleRecibo.Rows.Add(pagoNombre, pagoImporte, pagoCliente, pagoCuenta, pagoCuit, pagoBanco, pagoSucursal, pagoFechaAcredita, pagoFechaComprobante, pagoNumero, idFormaPago, idUsuarioLocacion);
                    Usuarios oUSU = new Usuarios();
                    oUSU.LlenarObjeto(idUsuario);
                    dtCtaCteDetfinal = oCtaCte.LlenarDtModelo(dtLocaciones, "C", idComprobante, idUsuario); ////.get oUsuCtaCte.GetDtModelo();
                    foreach (DataRow drDeuda in dtCtaCteDetfinal.Rows)
                        drDeuda["importe_pago"] = drDeuda["importe_total"];
                    dtCtaCteDetfinal.AcceptChanges();
                    string salida = "";
                    if (oRecibo.guardar(oRecibo, dtDetalleRecibo, dtCtaCteDetfinal, 1, out salida))
                        oColor = Color.LightGreen;
                    else
                    {
                        oColor = Color.Tomato;
                        dr["id_comprobante"] = idComprobante;
                        dr["error"] = "Error al asignar el recibo a la facura: id_usaurio: " + idUsuario + ", id_recibo: " + oRecibo.Id + " Error: " + salida;
                        dtComprobantesErrores.Rows.Add(dr);
                    }
                }
                catch (Exception c)
                {
                    dr = dtComprobantesErrores.NewRow();
                    dr["id_comprobante"] = idComprobante;
                    dr["error"] = c.Message;
                    dtComprobantesErrores.Rows.Add(dr);
                    oColor = Color.Tomato;
                }
                tarea.ReportProgress(contador, dtSeleccionados.Rows.Count);
            }
        }
        #endregion
        public frmDebitosRecibos()
        {
            InitializeComponent();
        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmDebitosRecibos_Load(object sender, EventArgs e)
        {
            BloquearControles();
            ComenzarCarga();
        }

        private void btnGenerarRecibo_Click(object sender, EventArgs e)
        {

            DataView dv = dtDeudas.DefaultView;
            dv.RowFilter = "rechazado=0";
            dtSeleccionados = dv.ToTable();
            lblProgreso.Text = string.Format("Procesando {0} de {1}", contador + 1, dtSeleccionados.Rows.Count);
            lblProgreso.Visible = true;
            idPresentacion = Convert.ToInt32(cboPeriodos.SelectedValue);
            pgBar.Maximum = dtSeleccionados.Rows.Count + 1;
            imgReturn.Enabled = false;
            this.KeyPreview = false;
            Cursor = Cursors.WaitCursor;
            btnGenerarRecibo.Enabled = false;
            btnRechazados.Enabled = false;
            tarea.DoWork += GenerarLoteRecibos;
            tarea.RunWorkerCompleted += Terminado;
            tarea.RunWorkerAsync();
        }
        private void Terminado(object o, RunWorkerCompletedEventArgs e)
        {
            pgBar.Value = pgBar.Maximum;
            MessageBox.Show("Proceso completado", "Mensajde del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
            pgBar.Maximum = dtSeleccionados.Rows.Count;
            imgReturn.Enabled = true;
            this.KeyPreview = true;
            Cursor = Cursors.Arrow;
            btnGenerarRecibo.Enabled = true;
            btnRechazados.Enabled = true;
            if (dtComprobantesErrores.Rows.Count > 0)
            {
                MessageBox.Show("Hubo errores durante el proceso, a continuacion se mostrara informacion que podra guardar/exportar y ser evaluada", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                splitContainer1.Panel1Collapsed = true;
                splitContainer1.Panel2Collapsed = false;

                dgvErrores.DataSource = dtComprobantesErrores;
            }
            pgBar.Value = pgBar.Minimum;

        }

        private void tarea_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pgBar.Value = e.ProgressPercentage - 1;
            try
            {
                dgvDeudasAnexadas.Rows[contador - 1].DefaultCellStyle.BackColor = oColor;
                dgvDeudasAnexadas.Rows[contador - 1].Selected = true;
                lblProgreso.Text = string.Format("Procesando {0} de {1}", contador, dtSeleccionados.Rows.Count);

            }
            catch (Exception c)
            {
                throw;
            }
        }

        private void btnRechazados_Click(object sender, EventArgs e)
        {
            int idCtacteDet = 0, idPlastico = 0;
            if (deRechazar == 0)
            {
                if (oCtaCte.ActualizarRechazoDebito(Convert.ToInt32(dgvDeudasAnexadas.SelectedRows[0].Cells["id"].Value), 1, Convert.ToInt32(dgvDeudasAnexadas.SelectedRows[0].Cells["id_presentacion"].Value)) == 0)
                {
                    dgvDeudasAnexadas.SelectedRows[0].Cells["estado"].Value = 1;
                    dgvDeudasAnexadas.SelectedRows[0].Cells["rechazado"].Value = 1;
                    dgvDeudasAnexadas.SelectedRows[0].DefaultCellStyle.BackColor = Color.Tomato;
                    btnRechazados.Text = "Deshacer Rechazo";

                }
                else
                    MessageBox.Show("Error al procesar el rechazo del debito");
            }
            else
            {
                if (oCtaCte.ActualizarRechazoDebito(Convert.ToInt32(dgvDeudasAnexadas.SelectedRows[0].Cells["id"].Value), 0, Convert.ToInt32(dgvDeudasAnexadas.SelectedRows[0].Cells["id_presentacion"].Value)) == 0)
                {
                    dgvDeudasAnexadas.SelectedRows[0].Cells["estado"].Value = 0;
                    dgvDeudasAnexadas.SelectedRows[0].Cells["rechazado"].Value = 0;
                    dgvDeudasAnexadas.SelectedRows[0].DefaultCellStyle.BackColor = Color.White;
                    btnRechazados.Text = "Rechazar";

                }
                else
                    MessageBox.Show("Error al procesar el rechazo del debito");
            }
            dtDeudas.AcceptChanges();
            marcarRechazados();
            CalcularTotales();

        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            oTool.ExportToExcel(dgvErrores, "Error recibos debitos");

        }

        private void dgvDeudasAnexadas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            marcarRechazados();
        }

        private void lblRechazado_Click(object sender, EventArgs e)
        {
            try
            {

                DataView dv = new DataView();
                dv = dtDeudas.DefaultView;
                dv.RowFilter = string.Format(String.Format("rechazado=true"));

                DataTable dtFiltrada = dv.ToTable();
                dgvDeudasAnexadas.DataSource = dtFiltrada;
                FormatearGrilla(dgvDeudasAnexadas);
            }
            catch (Exception)
            {

            }
        }

        private void lblTotalTotal_Click(object sender, EventArgs e)
        {
            try
            {

                DataView dv = new DataView();
                dv = dtDeudas.DefaultView;
                dv.RowFilter = string.Format(String.Format("rechazado=0"));

                DataTable dtFiltrada = dv.ToTable();
                dgvDeudasAnexadas.DataSource = dtFiltrada;
                FormatearGrilla(dgvDeudasAnexadas);
            }
            catch (Exception)
            {

            }
        }

        private void lblCompronteDeuda_Click(object sender, EventArgs e)
        {
            try
            {

                DataView dv = new DataView();
                dv = dtDeudas.DefaultView;
                dv.RowFilter = string.Format(String.Format("rechazado=0"));

                DataTable dtFiltrada = dv.ToTable();
                dgvDeudasAnexadas.DataSource = dtFiltrada;
                FormatearGrilla(dgvDeudasAnexadas);
            }
            catch (Exception)
            {

            }
            marcarRechazados();
        }

        private void lblImpago_Click(object sender, EventArgs e)
        {
            try
            {

                DataView dv = new DataView();
                dv = dtDeudas.DefaultView;
                dv.RowFilter = string.Format(String.Format("rechazado=true"));

                DataTable dtFiltrada = dv.ToTable();
                dgvDeudasAnexadas.DataSource = dtFiltrada;
                FormatearGrilla(dgvDeudasAnexadas);
            }
            catch (Exception)
            {

            }
            marcarRechazados();
        }

        private void btnExportar2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Seleccione el destino del archivo Excel con las deudas agrupadas por comprobante/factura", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);

            dgv1.DataSource = dtDeudasAgrupadas;
            FormatearGrilla(dgv1);
            foreach (DataGridViewColumn item in dgv1.Columns)
                item.Visible = false;
            foreach (DataGridViewRow item in dgv1.Rows)
                item.Cells["plastico"].Value = item.Cells["plastico"].Value.ToString() + "\u2003";
            dgv1.Columns["codigo"].Visible = true;
            dgv1.Columns["plastico"].Visible = true;
            dgv1.Columns["total1"].Visible = true;
            dgv1.Columns["usuario"].Visible = true;


            this.Cursor = Cursors.WaitCursor;
            oTool.ExportToExcel(dgvDeudasAnexadas, "Recibos debitos");
            this.Cursor = Cursors.Arrow;

            MessageBox.Show("Seleccione el destino del archivo Excel con las deudas agrupadas por tarjeta", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);

            foreach (DataGridViewColumn item in dgvDeudasAnexadas.Columns)
                item.Visible = false;
            foreach (DataGridViewRow item in dgvDeudasAnexadas.Rows)
                item.Cells["plastico"].Value = item.Cells["plastico"].Value.ToString() + "\u2003";

            dgvDeudasAnexadas.Columns["codigo"].Visible = true;
            dgvDeudasAnexadas.Columns["plastico"].Visible = true;
            dgvDeudasAnexadas.Columns["total1"].Visible = true;
            dgvDeudasAnexadas.Columns["usuario"].Visible = true;

            this.Cursor = Cursors.WaitCursor;

            oTool.ExportToExcel(dgv1, "Recibos debitos");
            this.Cursor = Cursors.Arrow;

            FormatearGrilla(dgvDeudasAnexadas);
            marcarRechazados();

        }

        private void chkNombre_CheckedChanged(object sender, EventArgs e)
        {
            if (chkNombre.Checked)
                txtFitro.Numerico = false;
            else
                txtFitro.Numerico = true;

        }

        private void dgvDeudasAnexadas_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            dtDeudas.AcceptChanges();
        }

        private void dgvDeudasAnexadas_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Control && e.KeyCode == Keys.E)
                {
                    frmPopUp oPop = new frmPopUp();
                    frmResponsable frmre = new frmResponsable();
                    oPop.Formulario = frmre;
                    oPop.Maximizar = false;
                    if (oPop.ShowDialog() == DialogResult.OK)
                    {
                        frmPopUp frmPop = new frmPopUp();
                        frmUsuariosCtaCteDetEdicion frmEdita = new frmUsuariosCtaCteDetEdicion();
                        frmEdita.Id_CtaCte = Convert.ToInt32(dgvDeudasAnexadas.SelectedRows[0].Cells["iD"].Value);
                        frmEdita.Id_Comprobantes = Convert.ToInt32(dgvDeudasAnexadas.SelectedRows[0].Cells["id_comprobantes"].Value);
                        frmEdita.Comprobante = dgvDeudasAnexadas.SelectedRows[0].Cells["descripcion"].Value.ToString();
                        frmPop.Formulario = frmEdita;
                        frmPop.Maximizar = false;

                        if (frmPop.ShowDialog() == DialogResult.OK)
                            ComenzarCarga();

                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("No se puede editar el movimiento", "Baja de Movimiento", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboPtoVenta_MouseDoubleClick(object sender, MouseEventArgs e)
        {
        }

        private void cboPtoVenta_Leave(object sender, EventArgs e)
        {
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {

                idPresentacionDebito = Convert.ToInt32(cboPeriodos.SelectedValue);
                ComenzarCarga();
            }
            catch
            {

            }
        }

        private void txtFitro_TextChanged(object sender, EventArgs e)
        {

            DataView dv = new DataView();
            DataTable dtFiltrada;
            dv = dtDeudas.DefaultView;
            try
            {
                if (chkCodigo.Checked)
                    dv.RowFilter = string.Format(String.Format("codigo =" + txtFitro.Text));
                else
                    if (chkTarjeta.Checked)
                    dv.RowFilter = string.Format(String.Format("plastico Like '%" + txtFitro.Text + "%'"));
                else
                     if (chkNombre.Checked)
                    dv.RowFilter = string.Format(String.Format("usuario Like '%" + txtFitro.Text + "%'"));

                dtFiltrada = dv.ToTable();
                dgvDeudasAnexadas.DataSource = dtFiltrada;
                FormatearGrilla(dgvDeudasAnexadas);
                marcarRechazados();
            }
            catch (Exception)
            {
                dv.RowFilter = string.Format(String.Format("codigo>0"));

                dtFiltrada = dv.ToTable();
                dgvDeudasAnexadas.DataSource = dtDeudas;
                FormatearGrilla(dgvDeudasAnexadas);
                marcarRechazados();
            }

        }

        private void dgvDeudasAnexadas_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(dgvDeudasAnexadas.SelectedRows[0].Cells["rechazado"].Value) == 1)
                {
                    btnRechazados.Text = "Deshacer Rechazo";
                    deRechazar = 1;
                }
                else
                {
                    btnRechazados.Text = "Rechazado";
                    deRechazar = 0;
                }

            }
            catch
            {

            }

        }

        private void boton1_Click(object sender, EventArgs e)
        {
            splitContainer1.Panel2Collapsed = true;
            splitContainer1.Panel1Collapsed = false;

            dtComprobantesErrores.Rows.Clear();
            dtComprobantesErrores.Clear();

        }

        private void cboPeriodos_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                idUltimaPresentacionDeb = Convert.ToInt32(cboPeriodos.SelectedValue);

            }
            catch { }
        }

        private void frmDebitosRecibos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();


        }

        private void btnSel_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in dgvDeudasAnexadas.Rows)
            {
                item.Cells["sel"].Value = true;
            }
        }
        private void CalcularTotales()
        {
            decimal total = 0, totalRechazado = 0, totalNoRechazado = 0;
            foreach (DataRow item in dtDeudas.Rows)
            {
                if (Convert.ToInt32(item["rechazado"]) == 1)
                    totalRechazado = totalRechazado + Convert.ToDecimal(item["total1"]);
                else
                    totalNoRechazado = totalNoRechazado + Convert.ToDecimal(item["total1"]);
            }
            total = totalNoRechazado + totalRechazado;
            lblTotalTotal.Text = string.Format("Total: ${0}", total);
            lblRechazado.Text = string.Format("Total rechazado: ${0}", totalRechazado);
            lblTotalNoRechazado.Text = string.Format("Total no rechazado: ${0}", totalNoRechazado);
            lblTotalNoRechazado.Location = new Point(pnlTotales.Width - lblTotalNoRechazado.Width - 10, lblTotalNoRechazado.Location.Y);
            lblRechazado.Location = new Point(lblTotalNoRechazado.Location.X - lblRechazado.Width - 10, lblTotalNoRechazado.Location.Y);
            lblTotalTotal.Location = new Point(lblRechazado.Location.X - lblTotalTotal.Width - 10, lblTotalNoRechazado.Location.Y);
        }
    }
}
