using CapaNegocios;
using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;


namespace CapaPresentacion.Contabilidad
{
    public partial class frmRecibosVirtuales : Form
    {
        #region PROPIEDADES
        private Thread hilo;
        private delegate void myDel();
        private Caja_Diaria oCajaDiaria = new Caja_Diaria();
        private Puntos_Cobros oPuntosCobros = new Puntos_Cobros();

        private DataTable dtPuntos;
        private DataTable dtCajas;
        private DataTable dtCajasAux;
        private DataTable dtRecibos;

        private decimal totalRecibos;
        private int idPuntoCobro, idCajaDiraria;
        private bool yaCargo;
        #endregion

        #region METODOS
        private void ComenzarCarga()
        {
           
            Controles(false);
            scMain.Panel1Collapsed = true;
            pnlCargando.Visible = true;
            pgCircular.Start();
            hilo = new Thread(new ThreadStart(CargarDatos));
            hilo.Start();
        }

        private void CargarDatos()
        {
            dtCajasAux = oCajaDiaria.ListarCajasDiarias(idPuntoCobro);
            dtPuntos = oPuntosCobros.ListarPorTipoSucursal("VIRTUAL");
            dtRecibos = oCajaDiaria.ListarDetallesRecibosAVC(idPuntoCobro, 0, 1, true);
            Thread.Sleep(3000);
            dtCajas = CopiarDtCajasOriginal();
            dtCajas = AgregarCajaAbierta(dtCajas);
            myDel MD = new myDel(AsignarDatos);
            this.Invoke(MD, new object[] { });
            pgCircular.Stop();
        }

        private void AsignarDatos()
        {
            dgvRecibos.Visible = true;
            dgvCajas.DataSource = dtCajas;
            Controles(true);
            FormatearGrillaCajas();
            flwFiltro.Enabled = true;
            pnlCargando.Visible = false;
            scMain.Panel1Collapsed = false;
            LlenarResultadoCajas();
            yaCargo = true;
            tlpInferior.Visible = true;
            scMain.SplitterDistance = lblCantCajas.Width+30;
            flwBuscar.Visible = true;
            flwBusquedaRecibos.Visible = true;
        }

        private void Controles(bool activado)
        {
            dgvCajas.Enabled = activado;
            imgReturn.Enabled = activado;
            this.KeyPreview = activado;
            btnBuscar.Enabled = activado;
            cboPuntos.Enabled = activado;
        }

        private void FormatearGrillaCajas()
        {
            dgvCajas.Columns["id"].Visible = false;
            dgvCajas.Columns["fecha"].HeaderText = "Fecha";
            dgvCajas.Columns["importe_cuenta1"].Visible = false;
            dgvCajas.Columns["importe_cuenta2"].Visible = false;
            dgvCajas.Columns["recibo_cuenta1_desde"].HeaderText = "Desde";
            dgvCajas.Columns["recibo_cuenta1_desde"].AutoSizeMode =  DataGridViewAutoSizeColumnMode.AllCells;
            dgvCajas.Columns["recibo_cuenta1_hasta"].HeaderText = "Hasta";
            dgvCajas.Columns["recibo_cuenta1_hasta"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvCajas.Columns["recibo_cuenta2_desde"].Visible = false;
            dgvCajas.Columns["recibo_cuenta2_hasta"].Visible = false;
            dgvCajas.Columns["total"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvCajas.Columns["total"].DefaultCellStyle.Format = "c2";
            dgvCajas.Columns["total"].HeaderText = "Total";
            dgvCajas.Columns["personal"].HeaderText = "Personal";
        }

        private DataTable AgregarCajaAbierta(DataTable dt)
        {

            DataRow drCajaAbierta = dt.NewRow();
            idCajaDiraria = 0;
            if (dtRecibos.Rows.Count > 0)
            {
                object suma = dtRecibos.Compute("sum(Importe_recibo)", "");
                drCajaAbierta["total"] = (decimal)suma;
            }
            else
                drCajaAbierta["total"] =0;
            drCajaAbierta["importe_cuenta1"] = 0;
            drCajaAbierta["importe_cuenta2"] = 0;
            drCajaAbierta["id"] = 0;
            drCajaAbierta["fecha"] = "SIN CERRAR";
            dt.Rows.InsertAt(drCajaAbierta, 0);
            return dt;
        }

        private void FormatearGrillRecibos()
        {
            dgvRecibos.Columns["id_comprobantes"].Visible = false;
            dgvRecibos.Columns["id_comprobantes1"].Visible = false;
            dgvRecibos.Columns["id"].Visible = false;
            dgvRecibos.Columns["id_usuarios_locaciones"].Visible = false;
            dgvRecibos.Columns["numero"].Visible = false;
            dgvRecibos.Columns["numero_hasta"].Visible = false;
            dgvRecibos.Columns["id_usuarios"].Visible = false;
            dgvRecibos.Columns["cuenta"].Visible = false;
            dgvRecibos.Columns["id_personal"].Visible = false;
            dgvRecibos.Columns["id_comprobantes_tipo"].Visible = false;
            dgvRecibos.Columns["borrado"].Visible = false;
            dgvRecibos.Columns["fecha_movimiento"].HeaderText = "Fecha";
            dgvRecibos.Columns["fecha_movimiento"].DisplayIndex =0;
            dgvRecibos.Columns["codigo"].HeaderText = "Código";
            dgvRecibos.Columns["codigo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvRecibos.Columns["codigo"].DisplayIndex = 1;
            dgvRecibos.Columns["nomape"].HeaderText = "Abonado";
            dgvRecibos.Columns["nomape"].DisplayIndex = 2;
            dgvRecibos.Columns["numero_muestra"].HeaderText = "Número de recibo";
            dgvRecibos.Columns["numero_muestra"].DisplayIndex = 3;
            dgvRecibos.Columns["importe_recibo"].HeaderText = "Importe";
            dgvRecibos.Columns["importe_recibo"].DefaultCellStyle.Format = "c2";
            dgvRecibos.Columns["importe_recibo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvRecibos.Columns["importe_recibo"].DisplayIndex = 4;
            dgvRecibos.Columns["nombrepersonal"].HeaderText = "Personal";
            dgvRecibos.Columns["nombrepersonal"].DisplayIndex = 5;
        }

        private DataTable CopiarDtCajasOriginal()
        {
            DataTable dt;
            dt = dtCajasAux.Clone();
            dt.Columns["fecha"].DataType = typeof(string);
            foreach (DataRow row in dtCajasAux.Rows)
                dt.ImportRow(row);
            return dt;
        }

        private void Filtrar()
        {
            DateTime desde = dtpDesde.Value;
            DateTime hasta = dtpHasta.Value;
            DataView dv = CopiarDtCajasOriginal().DefaultView;
            dv.RowFilter = String.Format(CultureInfo.InvariantCulture.DateTimeFormat, "fecha >= #{0}# and fecha <= #{1}#", new DateTime(desde.Year, desde.Month, desde.Day, 0, 0, 0), new DateTime(hasta.Year, hasta.Month, hasta.Day, 23, 59, 59));
            dtCajas = dv.ToTable();
            dtCajas = AgregarCajaAbierta(dtCajas);
            dgvCajas.DataSource = dtCajas;
            FormatearGrillaCajas();
            LlenarResultadoCajas();
        }
        private void LlenarResultadoCajas(){
            object sumaImportesCajaC1 = dtCajas.Compute("sum(importe_cuenta1)", "");
            object sumaImportesCajaC2 = dtCajas.Compute("sum(importe_cuenta2)", "");
            decimal totalCuenta1 = (decimal)sumaImportesCajaC1;
            decimal totalCuenta2 = (decimal)sumaImportesCajaC2;
            decimal totalImporteCajas = totalCuenta1 + totalCuenta2;
            lblCantCajas.Text = $"Cantidad de cajas: {dtCajas.Rows.Count - 1} - Cuenta 1 {totalCuenta1.ToString("c2")} - Cuenta 2: {totalCuenta2.ToString("c2")} - Total: {totalImporteCajas.ToString("c2")}";
        }
        #endregion
        public frmRecibosVirtuales()
        {
            InitializeComponent();
        }

        private void dgvCajas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Controles(false);
                idCajaDiraria = Convert.ToInt32(dgvCajas.Rows[e.RowIndex].Cells["id"].Value);
                dtRecibos = oCajaDiaria.ListarDetallesRecibosAVC(idPuntoCobro, idCajaDiraria, 1,true);
                if (dtRecibos.Rows.Count > 0)
                {
                    object sumImporte = dtRecibos.Compute("sum(Importe_recibo)", "");
                    totalRecibos = (decimal)sumImporte;
                    lblCantRecibos.Text = $"Cantidad de recibos: {dtRecibos.Rows.Count} - Importe total: {totalRecibos.ToString("c2")}";
                    dgvRecibos.DataSource = dtRecibos;
                    btnCerrar.Enabled = true;
                    FormatearGrillRecibos();
                }
                else
                {
                    dgvRecibos.DataSource = null;
                    btnCerrar.Enabled = false;
                }
                Controles(true);
            }
            catch (Exception c){
                //MessageBox.Show(c.ToString());
                Controles(true);
                dgvRecibos.DataSource = null;
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            flwBuscar.Visible = false;
            flwBusquedaRecibos.Visible = false;
            yaCargo = false;
            dgvRecibos.Visible = false;
            scMain.Panel1Collapsed = true;
            tlpInferior.Visible = false;

            idPuntoCobro = Convert.ToInt32(cboPuntos.SelectedValue);
            ComenzarCarga();
        }

        private void frmRecibosVirtuales_Load(object sender, EventArgs e)
        {
            scMain.Panel1Collapsed = true;
            int x, y;
            x = (scMain.Panel2.Width / 2) - (pnlCargando.Width / 2);
            y = (scMain.Panel2.Height / 2) - (pnlCargando.Height / 2);
            //asignamos la nueva ubicación
            pnlCargando.Location = new Point(x, y);
            dtPuntos = oPuntosCobros.ListarPorTipoSucursal("VIRTUAL");
            if (dtPuntos.Rows.Count > 0)
            {
                cboPuntos.DataSource = dtPuntos;
                cboPuntos.DisplayMember = "descripcion";
                cboPuntos.ValueMember = "id";
                cboPuntos.SelectedIndex = 0;
            }
            else
            {
                MessageBox.Show("No hay ningun punto de gestion que sea de tipo virtual.", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                btnBuscar.Enabled = false;
            }
            dtpDesde.Value = DateTime.Now.AddDays(-5);
        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmRecibosVirtuales_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            if(dgvRecibos.Rows.Count>0)
            {
                object sumOri = dtRecibos.Compute("sum(Importe_recibo)","");
                decimal importeTotal = (decimal) sumOri;

                oCajaDiaria.Id = 0;
                oCajaDiaria.Id_Puntos_cobros = idPuntoCobro;
                oCajaDiaria.Fecha = DateTime.Now;
                oCajaDiaria.Id_Personal = Personal.Id_Login;
                oCajaDiaria.Importe_cuenta1 = importeTotal;
                oCajaDiaria.Importe_cuenta2 = 0;
                oCajaDiaria.Id_Cierre_General = 0;
                oCajaDiaria.Recibo_cuenta1_desde = Convert.ToInt32(dtRecibos.Rows[0]["numero"]);
                oCajaDiaria.Recibo_cuenta1_hasta = Convert.ToInt32(dtRecibos.Rows[dtRecibos.Rows.Count-1]["numero"]);
                oCajaDiaria.Recibo_cuenta2_desde = 0;
                oCajaDiaria.Recibo_cuenta2_hasta = 0;
                string salida = "";
                int idCajaNueva = oCajaDiaria.Guardar(oCajaDiaria, out salida);
                if (idCajaNueva > 0)
                {
                    if (!oCajaDiaria.Asignar_Numero_Recibos(dtRecibos, idCajaNueva, out salida))
                    {
                        MessageBox.Show($"Error al asignar número de caja a los recibos (cuenta número uno).\n {salida}", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        ComenzarCarga();
                    }
                    else
                    {
                        MessageBox.Show("Caja cerrada correctamente", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Impresiones.Impresion oImpresion = new Impresiones.Impresion();
                        DataTable dtformasCta1;
                        DataTable dtPagosCuenta1;
                        DataTable dtDatosCaja = oCajaDiaria.GetEstructuraDatosCajaDiariaImpresion();
                        DataTable dtDatosFormasPago = oCajaDiaria.GetEstructuraDatosFormasPagoImpresion();
                        DataRow drAux = dtDatosCaja.NewRow();
                        drAux["recibo_desde"] = 0;
                        drAux["recibo_hasta"] = 0;
                        drAux["cant_total_recibos"] = 0;
                        drAux["monto_total_recibos"] = 0;
                        drAux["cant_total_anulados"] = 0;
                        drAux["monto_total_anulados"] = 0;
                        drAux["cant_final_recibos"] = 0;
                        drAux["monto_final_recibos"] = 0;
                        drAux["id_personal"] = Personal.Id_Login;
                        drAux["personal"] = Personal.Name_Login;
                        drAux["punto_cobro"] = idPuntoCobro;
                        drAux["numero_caja"] = "Caja Virtual";
                        if (dtRecibos.Rows.Count > 0)
                        {
                            drAux["recibo_desde"] = dtRecibos.Compute("MIN(numero)", string.Empty);
                            drAux["recibo_hasta"] = dtRecibos.Compute("MAX(numero)", string.Empty);
                            drAux["cant_total_recibos"] = dtRecibos.Compute("count(Importe_recibo)", string.Empty);
                            drAux["monto_total_recibos"] = dtRecibos.Compute("SUM(importe_recibo)", string.Empty);
                            drAux["cant_total_anulados"] = dtRecibos.Compute("count(Importe_recibo)", "borrado=1");
                            if (Convert.ToInt32(drAux["cant_total_anulados"]) > 0)
                                drAux["monto_total_anulados"] = dtRecibos.Compute("sum(Importe_recibo)", "borrado=1");
                            else
                                drAux["monto_total_anulados"] = 0;
                            drAux["cant_final_recibos"] = Convert.ToInt32(drAux["cant_total_recibos"]) - Convert.ToInt32(drAux["cant_total_anulados"]);
                            drAux["monto_final_recibos"] = Convert.ToDecimal(drAux["monto_total_recibos"]) - Convert.ToDecimal(drAux["monto_total_anulados"]);
                        }
                        dtDatosCaja.Rows.Add(drAux);
                        dtformasCta1 = oCajaDiaria.Listar_Recibos_Det(idPuntoCobro, 1, idCajaNueva, 1); ////ocaja_diaria.trae_ultimo_recibos(1, 1);
                        dtPagosCuenta1 = oCajaDiaria.ListarDetallesCtaCteDetPagos(idPuntoCobro, idCajaNueva, 1);
                        if (dtformasCta1.Rows.Count > 0)
                        {
                            foreach (DataRow formaPago in dtformasCta1.Rows)
                            {
                                drAux = dtDatosFormasPago.NewRow();
                                drAux["monto"] = 0;
                                drAux["forma_pago"] = formaPago["forma"];
                                drAux["cantidad"] = dtPagosCuenta1.Select(String.Format("id_formas_de_pago={0}", formaPago["id_formas_de_pago"].ToString())).Length;
                                if (Convert.ToInt32(drAux["cantidad"]) > 0)
                                    drAux["monto"] = formaPago["importe"];
                                dtDatosFormasPago.Rows.Add(drAux);
                            }
                        }
                        oImpresion.ImprimirInformeCajaDiaria(dtDatosCaja, dtDatosFormasPago);
                        ComenzarCarga();
                    }
                }
            }
        }

        private void dgvCajas_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                Controles(false);
                idCajaDiraria = Convert.ToInt32(dgvCajas.SelectedRows[0].Cells["id"].Value);
                dtRecibos = oCajaDiaria.ListarDetallesRecibosAVC(idPuntoCobro, idCajaDiraria, 1, true);
                if (dtRecibos.Rows.Count > 0)
                {
                    object sumImporte = dtRecibos.Compute("sum(Importe_recibo)", "");
                    totalRecibos = (decimal)sumImporte;
                    lblCantRecibos.Text = $"Cantidad de recibos: {dtRecibos.Rows.Count} - Total: {totalRecibos.ToString("c2")}";
                    dgvRecibos.DataSource = dtRecibos;
                    btnCerrar.Enabled = true;
                    FormatearGrillRecibos();
                    
                }
                else
                {
                    dgvRecibos.DataSource = null;
                    btnCerrar.Enabled = false;
                }
                Controles(true);
            }
            catch (Exception c)
            {
                //MessageBox.Show(c.ToString());
                Controles(true);
                dgvRecibos.DataSource = null;
            }
        }

        private void dtpDesde_ValueChanged(object sender, EventArgs e)
        {
            if(yaCargo)
                Filtrar();
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            Tools oTools = new Tools();
            if (dtCajas.Rows.Count > 1) { }
                oTools.ExportDataTableToExcel(dtCajas, "Lista de cajas");
            if (dtRecibos.Rows.Count > 0) { }
                oTools.ExportDataTableToExcel(dtRecibos, "Lista de recibos");
        }

        private void txtBuscador_TextChanged(object sender, EventArgs e)
        {
            string filtro = txtBuscador.Text;
            int numero = 0;
            DataView dv = dtRecibos.DefaultView;
            if (!string.IsNullOrEmpty(filtro))
            {
                if(int.TryParse(filtro,out numero))
                {
                    dv.RowFilter = "Convert([codigo], System.String) LIKE '%"+filtro+ "%' or Convert([numero_muestra], System.String)  LIKE '%" + filtro + "%'";

                }
                else
                    dv.RowFilter = $"nomape LIKE '%{filtro}%' or numero_muestra LIKE '%{filtro}%' or plataforma LIKE '%{filtro}%'";

                DataTable dt = dv.ToTable();
            }
            else
            {
                dv.RowFilter = "";
            }
        }

        private void dtpHasta_ValueChanged(object sender, EventArgs e)
        {
            if(yaCargo)
                Filtrar();
        }
    }
}
