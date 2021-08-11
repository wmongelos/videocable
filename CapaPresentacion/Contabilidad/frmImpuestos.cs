using CapaNegocios;
using CapaPresentacion.Impresiones;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace CapaPresentacion.Impuestos
{
    public partial class frmImpuestos : Form
    {

        #region [PROPIEDADES]
        private Thread hilo;
        SaveFileDialog oSabe = new SaveFileDialog();
        private DataSet dataset = new DataSet();
        private delegate void myDel();
        private Comprobantes_Iva oComprobates_iva = new Comprobantes_Iva();
        private Impresion oImpresion = new Impresion();
        private CapaNegocios.Facturacion oFacturacion = new CapaNegocios.Facturacion();
        private string fecha_desde, fecha_hasta;
        private int punto, Id_comprobante = 0, id_com = 0;
        private decimal Total_Neto_Total = 0, Total_iva_Total = 0, Total_III = 0, Total_Final = 0, Total_provincia = 0, totaltotal = 0;
        private DataTable dtIvaVentas = new DataTable();
        private DataTable dtResumen = new DataTable();
        private DataTable[] dtResultado;
        private Tools oTools = new Tools();
        private Puntos_Venta oPuntos_ventas = new Puntos_Venta();
        private DataTable dtPuntos_ventas = new DataTable();
        private int Flag = 0;
        private decimal Neto_Total = 0, Iva_Total = 0, TotalTotal = 0, NetoXComprobante = 0, ImporteIvaXComprobante = 0, ImporteIIXComprobante = 0, ImporteFinalXComprobante = 0, ImporteProvinvialXComprobante = 0, ImporteTotalXcomprobante = 0;
        string[] lines;
        string rutaCbteVentas, rutaDetallesVentas;

        private void dtpdesde_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }



        private void GenerarDuplicadoElectronico()
        {
            string ruta = string.Empty;
            string ruta2 = string.Empty;
            string ruta3 = string.Empty;
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.FilterIndex = 2;
            saveDialog.Filter = "Archivo de texto (*txt)|*txt";
            saveDialog.FileName = "Duplicado cabecera.txt";
            if (saveDialog.ShowDialog() == DialogResult.OK)
                ruta = saveDialog.FileName;
            saveDialog.FileName = "Duplicado detalle.txt";
            if (saveDialog.ShowDialog() == DialogResult.OK)
                ruta2 = saveDialog.FileName;
            saveDialog.FileName = "Duplicado otras percepciones.txt";
            if (saveDialog.ShowDialog() == DialogResult.OK)
                ruta3 = saveDialog.FileName;

            this.Cursor = Cursors.WaitCursor;
            DuplicadoCabecera(ruta);
            DuplicadoDetalle(ruta2);
            DuplicadoOtrasPercepciones(ruta3);
            this.Cursor = Cursors.Default;

            MessageBox.Show("Ya se generaron los txt", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void DuplicadoOtrasPercepciones(string ruta)
        {
            string campo1FechaDelComprobante;
            string campo2TipoDeComprobante;
            string campo3PuntoDeVenta;
            string campo4NumeroDeComprobante;
            string campo5CodJustificacionIngresosBrutos;
            string campo6ImportePercepcionesPorIngresos;
            string campo7JustificacionImpuestosMunicipales;
            string campo8ImportePercepcionesPorImpuestosMunicipales;

            StringBuilder sb = new StringBuilder();
            List<string> listaRegistros = new List<string>();
            foreach (DataRow row in dtIvaVentas.Rows)
            {
                campo1FechaDelComprobante = Convert.ToDateTime(row["fecha"]).ToString("yyyyMMdd");
                sb.Append(campo1FechaDelComprobante);

                if (Convert.ToInt32(row["id_comprobantes_tipo"]) == (int)Comprobantes_Tipo.Tipo.FACTURA_B)
                    campo2TipoDeComprobante = "006";
                else
                    campo2TipoDeComprobante = "001";
                sb.Append(campo2TipoDeComprobante);

                campo3PuntoDeVenta = row["punto_venta"].ToString().PadLeft(5, '0');
                sb.Append(campo3PuntoDeVenta);

                campo4NumeroDeComprobante = row["numero"].ToString().PadLeft(8, '0');
                sb.Append(campo4NumeroDeComprobante);

                campo5CodJustificacionIngresosBrutos = "02";
                sb.Append(campo5CodJustificacionIngresosBrutos);

                string[] importeSeparado = row["importe_impuesto_provincial"].ToString().Split(',');
                importeSeparado[0] = importeSeparado[0].PadLeft(13, '0');
                importeSeparado[1] = importeSeparado[1].PadLeft(2, '0');
                campo6ImportePercepcionesPorIngresos = $"{importeSeparado[0]}{importeSeparado[1]}";
                sb.Append(campo6ImportePercepcionesPorIngresos);

                campo7JustificacionImpuestosMunicipales = "".PadLeft(40, '0');
                sb.Append(campo7JustificacionImpuestosMunicipales);

                string[] importeSeparado2 = row["importe_impuesto_municipal"].ToString().Split(',');
                importeSeparado2[0] = importeSeparado2[0].PadLeft(13, '0');
                importeSeparado2[1] = importeSeparado2[1].PadLeft(2, '0');
                campo8ImportePercepcionesPorImpuestosMunicipales = $"{importeSeparado2[0]}{importeSeparado2[1]}";
                sb.Append(campo8ImportePercepcionesPorImpuestosMunicipales);

                listaRegistros.Add(sb.ToString());
                sb.Clear();
            }
            System.IO.File.WriteAllLines(ruta, listaRegistros);
        }

        private void DuplicadoDetalle(string ruta)
        {
            string campo1TipoComprobante;
            string campo2ControladorFiscal;
            string campo3FechaComprobante;
            string campo4PuntoDeVenta;
            string campo5NumeroComprobante;
            string campo6NumeroComprobanteRegistrado;
            string campo7Cantidad;
            string campo8UnidadDeMedida;
            string campo9PrecioUnitario;
            string campo10ImporteBonificacion;
            string campo11ImporteAjuste;
            string campo12SubtotalPorRegistro;
            string campo13AlicuotaDeIvaAplicacble;
            string campo14IndicacionExentoOGravadoONoGravado;
            string campo15IndicacionDeAnulacion;
            string campo16DisenioLibre;
            //https://www.ignacioonline.com.ar/rg-3685-afip-regimen-especial-de-emision-y-almacenamiento-de-duplicados-electronicos/

            Facturacion oFacturacion = new Facturacion();
            DataTable dtComprobantesDetalles = new DataTable();
            StringBuilder sb = new StringBuilder();
            List<string> listaRegistros = new List<string>();

            foreach (DataRow row in dtIvaVentas.Rows)
            {
                oFacturacion.Id_Comprobantes = Convert.ToInt32(row["id_comprobantes"]);
                dtComprobantesDetalles = oFacturacion.ListarDetalle();

                foreach (DataRow detalle in dtComprobantesDetalles.Rows)
                {
                    if (Convert.ToInt32(row["id_comprobantes_tipo"]) == (int)Comprobantes_Tipo.Tipo.FACTURA_B)
                        campo1TipoComprobante = "006";
                    else
                        campo1TipoComprobante = "001";
                    sb.Append(campo1TipoComprobante);

                    campo2ControladorFiscal = " ";
                    sb.Append(campo2ControladorFiscal);

                    campo3FechaComprobante = Convert.ToDateTime(row["fecha"]).ToString("yyyyMMdd");
                    sb.Append(campo3FechaComprobante);

                    campo4PuntoDeVenta = row["punto_venta"].ToString().PadLeft(5, '0');
                    sb.Append(campo4PuntoDeVenta);

                    campo5NumeroComprobante = row["numero"].ToString().PadLeft(8, '0');
                    sb.Append(campo5NumeroComprobante);

                    campo6NumeroComprobanteRegistrado = campo5NumeroComprobante;
                    sb.Append(campo6NumeroComprobanteRegistrado);

                    campo7Cantidad = Convert.ToInt32(detalle["cantidad"]).ToString().PadLeft(12, '0'); ;
                    sb.Append(campo7Cantidad);

                    campo8UnidadDeMedida = "00"; //Sin descripcion
                    sb.Append(campo8UnidadDeMedida);

                    string[] importeSeparado = detalle["unitario"].ToString().Split(',');
                    importeSeparado[0] = importeSeparado[0].PadLeft(14, '0');
                    importeSeparado[1] = importeSeparado[1].PadLeft(2, '0');
                    campo9PrecioUnitario = $"{importeSeparado[0]}{importeSeparado[1]}";
                    sb.Append(campo9PrecioUnitario);

                    string[] importeSeparado2 = detalle["bonificaciones"].ToString().Split(',');
                    importeSeparado2[0] = importeSeparado2[0].PadLeft(13, '0');
                    importeSeparado2[1] = importeSeparado2[1].PadLeft(2, '0');
                    campo10ImporteBonificacion = $"{importeSeparado2[0]}{importeSeparado2[1]}";
                    sb.Append(campo10ImporteBonificacion);

                    campo11ImporteAjuste = "0000000000000000";
                    sb.Append(campo11ImporteAjuste);

                    string[] importeSeparado3 = detalle["total"].ToString().Split(',');
                    importeSeparado3[0] = importeSeparado3[0].PadLeft(14, '0');
                    importeSeparado3[1] = importeSeparado3[1].PadLeft(2, '0');
                    campo12SubtotalPorRegistro = $"{importeSeparado3[0]}{importeSeparado3[1]}";
                    sb.Append(campo12SubtotalPorRegistro);

                    campo13AlicuotaDeIvaAplicacble = "".PadLeft(4, '0');
                    sb.Append(campo13AlicuotaDeIvaAplicacble);

                    campo14IndicacionExentoOGravadoONoGravado = "";
                    sb.Append(campo14IndicacionExentoOGravadoONoGravado);

                    campo15IndicacionDeAnulacion = " ";
                    sb.Append(campo15IndicacionDeAnulacion);

                    campo16DisenioLibre = "";
                    sb.Append(campo16DisenioLibre);

                    listaRegistros.Add(sb.ToString());
                    sb.Clear();
                }
            }
            System.IO.File.WriteAllLines(ruta, listaRegistros);
        }

        private void DuplicadoCabecera(string ruta)
        {
            string campo1TipoRegistro;
            string campo2FechaDeFactura;
            string campo3TipoComprobante;
            string campo4ControladorFiscal;
            string campo5PuntoDeVenta;
            string campo6NumeroComprobante;
            string campo7NumeroComprobanteRegistrado;
            string campo8CantidadDeHojas;
            string campo9CodigoDocumentoDelComprador;
            string campo10NumeroDeDoc;
            string campo11RazonSocial;
            string campo12ImporteTotal;
            string campo13ImporteTotalConceptos;
            string campo14ImporteNeto;
            string campo15ImporteIva;
            string campo16ImportePercepcionANoCategorizados;
            string campo17ImporteOperacionesExternas;
            string campo18ImportePercepciones;
            string campo19ImportePercepcionIngresosBrutos;
            string campo20ImportePercepcionMunicipal;
            string campo21ImporteImpuestoInterno;
            string campo22Transporte;
            string campo23TipoResponsable;
            string campo24CodigoDeMoneda;
            string campo25TipoCambio;
            string campo26CantidadAliCuotasDeIva;
            string campo27CodigoDeOperacion;
            string campo28CAE;
            string campo29FechaVencimiento;
            string campo30FechaAnulacionDelComprobante;
            string campo31OtrosTributos;

            string codigoDeMoneda = "PES";
            int longitudPuntoVenta = 5;
            int longitudNumeroComprobante = 8;
            int longitudImporteEntero = 13;
            int longitudImporteDecimal = 2;
            int longitudNumeroDoc = 20;
            int longitudRazonSocial = 30;
            int longitudCAE = 14;

            StringBuilder sb = new StringBuilder();
            List<string> listaRegistros = new List<string>();
            foreach (DataRow row in dtIvaVentas.Rows)
            {
                campo1TipoRegistro = "1";
                sb.Append(campo1TipoRegistro);

                campo2FechaDeFactura = Convert.ToDateTime(row["fecha"]).ToString("yyyyMMdd");
                sb.Append(campo2FechaDeFactura);

                if (Convert.ToInt32(row["id_comprobantes_tipo"]) == (int)Comprobantes_Tipo.Tipo.FACTURA_B)
                    campo3TipoComprobante = "006";
                else
                    campo3TipoComprobante = "001";
                sb.Append(campo3TipoComprobante);

                campo4ControladorFiscal = " ";
                sb.Append(campo4ControladorFiscal);

                campo5PuntoDeVenta = row["punto_venta"].ToString().PadLeft(longitudPuntoVenta, '0');
                sb.Append(campo5PuntoDeVenta);

                campo6NumeroComprobante = row["numero"].ToString().PadLeft(longitudNumeroComprobante, '0');
                sb.Append(campo6NumeroComprobante);

                campo7NumeroComprobanteRegistrado = campo6NumeroComprobante.ToString();
                sb.Append(campo7NumeroComprobanteRegistrado);

                campo8CantidadDeHojas = "001";
                sb.Append(campo8CantidadDeHojas);

                campo9CodigoDocumentoDelComprador = row["documento_afip"].ToString();
                sb.Append(campo9CodigoDocumentoDelComprador);

                campo10NumeroDeDoc = row["numero_documento"].ToString().PadLeft(longitudNumeroDoc, '0');
                sb.Append(campo10NumeroDeDoc);

                campo11RazonSocial = row["razon_social"].ToString().PadLeft(longitudRazonSocial, '0');
                sb.Append(campo11RazonSocial);

                string[] importeSeparado = row["importe_final"].ToString().Split(',');
                importeSeparado[0] = importeSeparado[0].PadLeft(longitudImporteEntero, '0');
                importeSeparado[1] = importeSeparado[1].PadLeft(longitudImporteDecimal, '0');
                campo12ImporteTotal = $"{importeSeparado[0]}{importeSeparado[1]}";
                sb.Append(campo12ImporteTotal);

                campo13ImporteTotalConceptos = "".PadLeft(longitudImporteEntero + longitudImporteDecimal, '0');
                sb.Append(campo13ImporteTotalConceptos);

                string[] importeSeparado2 = row["importe_neto"].ToString().Split(',');
                importeSeparado2[0] = importeSeparado2[0].PadLeft(longitudImporteEntero, '0');
                importeSeparado2[1] = importeSeparado2[1].PadLeft(longitudImporteDecimal, '0');
                campo14ImporteNeto = $"{importeSeparado2[0]}{importeSeparado2[1]}";
                sb.Append(campo14ImporteNeto);

                string[] importeSeparado3 = row["importe_iva"].ToString().Split(',');
                importeSeparado3[0] = importeSeparado3[0].PadLeft(longitudImporteEntero, '0');
                importeSeparado3[1] = importeSeparado3[1].PadLeft(longitudImporteDecimal, '0');
                campo15ImporteIva = $"{importeSeparado3[0]}{importeSeparado3[1]}";
                sb.Append(campo15ImporteIva);

                campo16ImportePercepcionANoCategorizados = "".PadLeft(longitudImporteEntero + longitudImporteDecimal, '0');
                sb.Append(campo16ImportePercepcionANoCategorizados);

                campo17ImporteOperacionesExternas = "".PadLeft(longitudImporteEntero + longitudImporteDecimal, '0');
                sb.Append(campo17ImporteOperacionesExternas);

                string[] importeSeparado4 = row["importe_impuesto_provincial"].ToString().Split(',');
                importeSeparado4[0] = importeSeparado4[0].PadLeft(longitudImporteEntero, '0');
                importeSeparado4[1] = importeSeparado4[1].PadLeft(longitudImporteDecimal, '0');
                campo18ImportePercepciones = $"{importeSeparado4[0]}{importeSeparado4[1]}";
                sb.Append(campo18ImportePercepciones);

                campo19ImportePercepcionIngresosBrutos = "".PadLeft(longitudImporteEntero + longitudImporteDecimal, '0');
                sb.Append(campo19ImportePercepcionIngresosBrutos);

                campo20ImportePercepcionMunicipal = "".PadLeft(longitudImporteEntero + longitudImporteDecimal, '0');
                sb.Append(campo20ImportePercepcionMunicipal);

                campo21ImporteImpuestoInterno = "".PadLeft(longitudImporteEntero + longitudImporteDecimal, '0');
                sb.Append(campo21ImporteImpuestoInterno);

                campo22Transporte = "".PadLeft(longitudImporteEntero + longitudImporteDecimal, '0');
                sb.Append(campo22Transporte);

                campo23TipoResponsable = row["Codigo_afip"].ToString().PadLeft(2, '0');
                sb.Append(campo23TipoResponsable);

                campo24CodigoDeMoneda = codigoDeMoneda;
                sb.Append(campo24CodigoDeMoneda);

                campo25TipoCambio = "0000000000";
                sb.Append(campo25TipoCambio);

                campo26CantidadAliCuotasDeIva = "1";
                sb.Append(campo26CantidadAliCuotasDeIva);

                campo27CodigoDeOperacion = " ";
                sb.Append(campo27CodigoDeOperacion);

                campo28CAE = row["cae"].ToString().PadLeft(longitudCAE, '0');
                sb.Append(campo28CAE);

                campo29FechaVencimiento = Convert.ToDateTime(row["vencimiento"]).ToString("yyyyMMdd");
                sb.Append(campo29FechaVencimiento);

                campo30FechaAnulacionDelComprobante = "00000000";
                sb.Append(campo30FechaAnulacionDelComprobante);

                campo31OtrosTributos = "".PadLeft(15, '0');
                sb.Append(campo31OtrosTributos);

                listaRegistros.Add(sb.ToString());
                sb.Clear();
            }
            System.IO.File.WriteAllLines(ruta, listaRegistros);
        }

        private void btnTxtDuplicadoElectronico_Click(object sender, EventArgs e)
        {
            GenerarDuplicadoElectronico();
        }


        private void btnTxtDuplicadoDigital_Click(object sender, EventArgs e)
        {
            if (dgv.Rows.Count == 0)
                return;

            string ruta1 = string.Empty;
            string ruta2 = string.Empty;
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "Archivo de texto (*txt)|*txt";
            saveDialog.FileName = "Duplicado digital - Iva ventas comprobantes.txt";
            if (saveDialog.ShowDialog() == DialogResult.OK)
                ruta1 = saveDialog.FileName;
            saveDialog.FileName = "Duplicado digital - Alicuotas.txt";
            if (saveDialog.ShowDialog() == DialogResult.OK)
                ruta2 = saveDialog.FileName;

            if(!String.IsNullOrEmpty(ruta1))
                GenerarDuplicadoDigital_IvaVentasComprobantes(ruta1);
            
            if(!String.IsNullOrEmpty(ruta2))
                GenerarDuplicadoDigital_Alicuotas(ruta2);
        }

        private void txtBuscador_TextChanged(object sender, EventArgs e)
        {
            dtIvaVentas.DefaultView.RowFilter = String.Format("Convert([Razon_social], System.String) LIKE '%{0}%' OR Convert([localidad], System.String) LIKE '%{0}%' OR Convert([calle], System.String) LIKE '%{0}%'" +
                " OR Convert([altura], System.String) LIKE '%{0}%' OR Convert([fecha], System.String) LIKE '%{0}%' OR Convert([punto_venta], System.String) LIKE '%{0}%' OR Convert([condicion_iva], System.String) LIKE '%{0}%'" +
                " OR Convert([nombre], System.String) LIKE '%{0}%' OR Convert([letra], System.String) LIKE '%{0}%' OR Convert([cae], System.String) LIKE '%{0}%' OR Convert([numero_documento], System.String) LIKE '%{0}%' " +
                " OR Convert([importe_final], System.String) LIKE '%{0}%'", txtBuscador.Text);
        }

        private void dtpdesde_ValueChanged(object sender, EventArgs e)
        {
            dtphasta.MinDate = dtpdesde.Value.Date;
            dtphasta.Value = new DateTime(dtpdesde.Value.Year, dtpdesde.Value.Month, DateTime.DaysInMonth(dtpdesde.Value.Year, dtpdesde.Value.Month));
        }

        #endregion

        #region METODOS

        private void ComenzarCarga()
        {
            dgv.DataSource = null;
            dgv1.DataSource = null;
            hilo = new Thread(new ThreadStart(cargarDatos));
            hilo.IsBackground = true;
            hilo.Start();
        }

        private void cargarDatos()
        {
            dtPuntos_ventas = oPuntos_ventas.Listar();
            myDel MD = new myDel(asignarDatos);
            this.Invoke(MD, new object[] { });
        }
        private void asignarDatos()
        {
            dtpdesde.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            DataRow row = dtPuntos_ventas.NewRow();
            row["numero"] = 0;
            row["descripcion"] = "TODOS";
            dtPuntos_ventas.Rows.Add(row);
            cboPuntosVenta.DataSource = dtPuntos_ventas;
            cboPuntosVenta.DisplayMember = "Descripcion";
            cboPuntosVenta.ValueMember = "Numero";

            Total_Neto_Total = 0;
            Total_iva_Total = 0;
            Total_III = 0;
            Total_Final = 0;
            Total_provincia = 0;
            totaltotal = 0;
            Neto_Total = 0;
            Iva_Total = 0;
            TotalTotal = 0;
            oSabe.Filter = "xlx |*.xls";
            oSabe.Title = "Guardar archivo excel";
            CalcularTotales();
            if (Flag == 1)
                FormatearGrillaResumen();
        }

        public void ExportarDataGridViewExcel()
        {

        }

        private void CalcularTotales()
        {
            if (Flag == 1)
            {

                decimal total_final = 0;
                decimal total_neto = 0;
                decimal total_iva = 0;
                decimal total_interno = 0;
                decimal total_municipal = 0;
                decimal total_provincial = 0;
                decimal total_nacional = 0;
                try
                {

                    foreach (DataRow item in dtResumen.Rows)
                    {

                        if (Convert.ToUInt32(item["id_comprobantes_tipo"]) == (int)Comprobantes_Tipo.Tipo.NOTA_CREDITO_A)
                        {

                            item["total_final"] = Convert.ToDecimal(item["total_final"]) * -1;
                            item["total_neto"] = Convert.ToDecimal(item["total_neto"]) * -1;
                            item["total_iva"] = Convert.ToDecimal(item["total_iva"]) * -1;
                            item["total_interno"] = Convert.ToDecimal(item["total_interno"]) * -1;
                            item["total_municipal"] = Convert.ToDecimal(item["total_municipal"]) * -1;
                            item["total_provincial"] = Convert.ToDecimal(item["total_provincial"]) * -1;
                            item["total_nacional"] = Convert.ToDecimal(item["total_nacional"]) * -1;
                        }

                        if (Convert.ToUInt32(item["id_comprobantes_tipo"]) == (int)Comprobantes_Tipo.Tipo.NOTA_CREDITO_B)
                        {

                            item["total_final"] = Convert.ToDecimal(item["total_final"]) * -1;
                            item["total_neto"] = Convert.ToDecimal(item["total_neto"]) * -1;
                            item["total_iva"] = Convert.ToDecimal(item["total_iva"]) * -1;
                            item["total_interno"] = Convert.ToDecimal(item["total_interno"]) * -1;
                            item["total_municipal"] = Convert.ToDecimal(item["total_municipal"]) * -1;
                            item["total_provincial"] = Convert.ToDecimal(item["total_provincial"]) * -1;
                            item["total_nacional"] = Convert.ToDecimal(item["total_nacional"]) * -1;
                        }

                    }

                    total_final = dtResumen.AsEnumerable().Sum(r => r.Field<decimal>("total_final"));
                    total_neto = dtResumen.AsEnumerable().Sum(r => r.Field<decimal>("total_neto"));
                    total_iva = dtResumen.AsEnumerable().Sum(r => r.Field<decimal>("total_iva"));
                    total_interno = dtResumen.AsEnumerable().Sum(r => r.Field<decimal>("total_interno"));
                    total_municipal = dtResumen.AsEnumerable().Sum(r => r.Field<decimal>("total_municipal"));
                    total_provincial = dtResumen.AsEnumerable().Sum(r => r.Field<decimal>("total_provincial"));
                    total_nacional = dtResumen.AsEnumerable().Sum(r => r.Field<decimal>("total_nacional"));

                    DataRow dr = dtResumen.NewRow();
                    dr["nombre"] = "TOTALES: ";
                    dr["total_final"] = total_final;
                    dr["total_neto"] = total_neto;
                    dr["total_iva"] = total_iva;
                    dr["total_interno"] = total_interno;
                    dr["total_municipal"] = total_municipal;
                    dr["total_provincial"] = total_provincial;
                    dr["total_nacional"] = total_nacional;

                    dtResumen.Rows.Add(dr);
                    dgv1.DataSource = dtResumen;
                    FormatearDgv();

                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
        #endregion
        private void frmImpuestos_Load(object sender, EventArgs e)
        {
            ComenzarCarga();
        }

        private void btnGenerarTxt_Click(object sender, EventArgs e)
        {
            rutaCbteVentas = string.Empty;
            rutaDetallesVentas = string.Empty;
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "Archivo de texto (*txt)|*txt";
            saveDialog.FilterIndex = 2;
            saveDialog.FileName = "Informe ventas comprobantes.txt";
            MessageBox.Show("Seleccione el destino del archivo de informacion de ventas");
            if (saveDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                rutaCbteVentas = saveDialog.FileName;
            MessageBox.Show("Seleccione el destino del archivo de informacion de detalles de ventas");
            saveDialog.FileName = "Informe ventas detalles alicuotas.txt";

            if (saveDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                rutaDetallesVentas = saveDialog.FileName;
            if (!string.IsNullOrEmpty(rutaDetallesVentas) && !string.IsNullOrEmpty(rutaCbteVentas))
                GenerarLibroIvaTxt();
        }
        private Boolean GenerarLibroIvaTxt()
        {
            // datos para REGINFO_CV_VENTAS_CBTE					

            string fechaComprobanteCbte;
            string tipoComprobanteAfipCbte;
            string puntoVentaCbte;
            string numComprobanteCbte;
            string numComprobanteHastaCbte;
            string idDocTipoAfipCbte;
            string docCuitNumCbte;
            string apellidoNombreCbte;
            string importeTotalCbte;
            string importeNoGravadoCbte;//Importe total de conceptos que no integran el precio neto gravado
            string importeNoCategorizadosCbte;
            string importeOperacionesExentasCbte;
            string importeImpuestoNacCbte;
            string importeImpuestoProvCbte;
            string importeImpuestoMunCbte;
            string importeImpuestoInternoCbte;
            string codigoMonedaCbte;
            string tipoCambioCbte;
            string cantidadAlicuotasIvaCbte;
            string codOperacionCbte;
            string otrosTributosCbte;
            string fechaVencimientoCbte;

            int largoTipoCbtePermitido = 3;//segun normativa de afip
            int largoPtoVetaCbtePermitido = 5;//segun normativa de afip
            int largoNumCompCbtePermitido = 20;//segun normativa de afip
            int largoNumCompCbteHastaPermitido = 20;//segun normativa de afip
            int largoIdDocTipoCbtePermitido = 2;//segun normativa de afip
            int largoDocCuitCbtePermitido = 20;//segun normativa de afip
            int largoApellidoNombreCbtePermitido = 30;//segun normativa de afip
            int largoImporteTotalCbtePermitido = 15;//segun normativa de afip
            int largoImporteNoGravadoCbtePermitido = 15;//segun normativa de afip
            int largoImporteNoCategorizadosCbtePermitido = 15;//segun normativa de afip
            int largoImporteOperacionesExentasCbtePermitido = 15;//segun normativa de afip
            int largoImporteImpuestoNacCbtePermitido = 15;//segun normativa de afip
            int largoImporteImpuestoProvCbtePermitido = 15;//segun normativa de afip
            int largoImporteImpuestoMunCbtePermitido = 15;//segun normativa de afip
            int largoImporteImpuestoInternoCbtePermitido = 15;//segun normativa de afip
            int largoTipoMonedaCbtePermitido = 3;//segun normativa de afip
            int largoTipoCambioCbtePermitido = 10;//segun normativa de afip
            int largoCantAlicuotasCbtePermitido = 1;//segun normativa de afip
            int largoTipoOperacionCbtePermitido = 1;//segun normativa de afip
            int largoOtrosCbtePermitido = 15;//segun normativa de afip
            int largoFechaVencimientoCbtePermitido = 15;//segun normativa de afip

            string lineaTexto = String.Empty;
            DataTable dtAlicuotasComp = new DataTable();
            int contRegistros = 0;
            string[] splitAux;
            foreach (DataRow item in dtIvaVentas.Rows)
            {

                lineaTexto = String.Empty;
                fechaComprobanteCbte = Convert.ToDateTime(item["fecha"]).ToString("yyyyMMdd");

                tipoComprobanteAfipCbte = item["Codigo_Afip"].ToString();
                tipoComprobanteAfipCbte = tipoComprobanteAfipCbte.PadLeft(largoTipoCbtePermitido, '0');

                puntoVentaCbte = item["punto_venta"].ToString();
                puntoVentaCbte = puntoVentaCbte.PadLeft(largoPtoVetaCbtePermitido, '0');

                numComprobanteCbte = item["numero"].ToString();
                numComprobanteCbte = numComprobanteCbte.PadLeft(largoNumCompCbtePermitido, '0');

                numComprobanteHastaCbte = item["numero"].ToString();
                numComprobanteHastaCbte = numComprobanteCbte.PadLeft(largoNumCompCbteHastaPermitido, '0');

                idDocTipoAfipCbte = item["documento_afip"].ToString();
                idDocTipoAfipCbte = idDocTipoAfipCbte.PadLeft(largoIdDocTipoCbtePermitido, '0');

                docCuitNumCbte = item["numero_documento"].ToString();
                docCuitNumCbte = docCuitNumCbte.PadLeft(largoDocCuitCbtePermitido, '0');

                apellidoNombreCbte = item["razon_social"].ToString();
                apellidoNombreCbte = apellidoNombreCbte.PadRight(largoApellidoNombreCbtePermitido, ' ');
                if (apellidoNombreCbte.Length > 30)
                {
                    apellidoNombreCbte = apellidoNombreCbte.Substring(0, 30);
                }
                splitAux = item["importe_final"].ToString().Split(',');
                importeTotalCbte = splitAux[0] + splitAux[1];
                importeTotalCbte = importeTotalCbte.PadLeft(largoImporteTotalCbtePermitido, '0');
                if (Convert.ToDecimal(item["importe_final"]) < 0)
                {
                    importeTotalCbte = importeTotalCbte.Replace('-', '0');
                    importeTotalCbte = importeTotalCbte.Remove(0, 1);
                    importeTotalCbte = "-" + importeTotalCbte;
                }

                importeNoGravadoCbte = "0";
                importeNoGravadoCbte = importeNoGravadoCbte.PadLeft(largoImporteNoGravadoCbtePermitido, '0');

                importeNoCategorizadosCbte = "0";
                importeNoCategorizadosCbte = importeNoCategorizadosCbte.PadLeft(largoImporteNoCategorizadosCbtePermitido, '0');

                importeOperacionesExentasCbte = "0";
                importeOperacionesExentasCbte = importeOperacionesExentasCbte.PadLeft(largoImporteOperacionesExentasCbtePermitido, '0');

                splitAux = item["importe_impuesto_nacional"].ToString().Split(',');
                importeImpuestoNacCbte = splitAux[0] + splitAux[1];
                importeImpuestoNacCbte = importeImpuestoNacCbte.PadLeft(largoImporteImpuestoNacCbtePermitido, '0');

                splitAux = item["importe_impuesto_provincial"].ToString().Split(',');
                importeImpuestoProvCbte = splitAux[0] + splitAux[1];
                importeImpuestoProvCbte = importeImpuestoProvCbte.PadLeft(largoImporteImpuestoProvCbtePermitido, '0');

                splitAux = item["importe_impuesto_municipal"].ToString().Split(',');
                importeImpuestoMunCbte = splitAux[0] + splitAux[1];
                importeImpuestoMunCbte = importeImpuestoMunCbte.PadLeft(largoImporteImpuestoMunCbtePermitido, '0');

                splitAux = item["importe_impuesto_interno"].ToString().Split(',');
                importeImpuestoInternoCbte = splitAux[0] + splitAux[1];
                importeImpuestoInternoCbte = importeImpuestoInternoCbte.PadLeft(largoImporteImpuestoInternoCbtePermitido, '0');

                codigoMonedaCbte = "PES";

                tipoCambioCbte = "0001000000";

                oFacturacion.Id_Comprobantes = Convert.ToInt32(item["id_comprobantes"]);
                dtAlicuotasComp = oFacturacion.ListarIvalicuotas();

                //veo la cantidad de diferentes alicuotas-------------------
                var result = from rows in dtAlicuotasComp.AsEnumerable()
                             group rows by new { Name = rows["id_iva_alicuotas"] } into grp
                             select grp;

                List<DataTable> dts = new List<DataTable>();
                foreach (var item2 in result)
                    dts.Add(item2.CopyToDataTable());
                //----------------------------------------------------------
                if (dts.Count > 0)
                    cantidadAlicuotasIvaCbte = dts[0].Rows.Count.ToString();
                else
                    cantidadAlicuotasIvaCbte = "0";

                cantidadAlicuotasIvaCbte = cantidadAlicuotasIvaCbte.PadLeft(largoCantAlicuotasCbtePermitido, '0');

                codOperacionCbte = " ";
                codOperacionCbte = codOperacionCbte.PadLeft(largoTipoOperacionCbtePermitido, '0');

                otrosTributosCbte = "0";
                otrosTributosCbte = otrosTributosCbte.PadLeft(largoOtrosCbtePermitido, '0');

                fechaVencimientoCbte = Convert.ToDateTime(item["vencimiento"]).ToString("yyyyMMdd");

                lineaTexto = fechaComprobanteCbte + tipoComprobanteAfipCbte + puntoVentaCbte + numComprobanteCbte + numComprobanteHastaCbte + idDocTipoAfipCbte + docCuitNumCbte + apellidoNombreCbte + importeTotalCbte +
                    importeNoGravadoCbte + importeNoCategorizadosCbte + importeOperacionesExentasCbte + importeImpuestoNacCbte + importeImpuestoProvCbte + importeImpuestoMunCbte + importeImpuestoInternoCbte +
                    codigoMonedaCbte + tipoCambioCbte + cantidadAlicuotasIvaCbte + codOperacionCbte + otrosTributosCbte + fechaVencimientoCbte;
                lines[contRegistros] = lineaTexto;
                contRegistros++;


            }

            System.IO.File.WriteAllLines(rutaCbteVentas, lines);


            // datos alicuotas
            string tipoComprobanteAfip;
            string puntoVenta;
            string numComprobante;
            string importeNetoGravado;
            string idAlicuotaIVA;
            string impuestoLiquidado;

            //normativas de afip
            int largoTipoCompPermitido = 3;//segun normativa de afip
            int largoPtoVetaPermitido = 5;//segun normativa de afip
            int largoNumCompPermitido = 20;//segun normativa de afip
            int largoImporteNetoPermitido = 15;//segun normativa de afip
            int largoIdAlicuotaIVA = 4;//segun normativa de afip
            int largoImpuestoLiquidado = 15;//segun normativa de afip

            DataTable dtIvas = new DataTable();
            int contRegistros2 = 0;
            DataTable dtIvasAlicuotas = new DataTable();
            try
            {
                foreach (DataRow item in dtIvaVentas.Rows)
                {
                    tipoComprobanteAfip = item["Codigo_Afip"].ToString();
                    tipoComprobanteAfip = tipoComprobanteAfip.PadLeft(largoTipoCompPermitido, '0');
                    puntoVenta = item["punto_venta"].ToString();
                    puntoVenta = puntoVenta.PadLeft(largoPtoVetaPermitido, '0');
                    numComprobante = item["numero"].ToString();
                    numComprobante = numComprobante.PadLeft(largoNumCompPermitido, '0');
                    oFacturacion.Id_Comprobantes = Convert.ToInt32(item["id_comprobantes"]);
                    dtIvasAlicuotas = oFacturacion.ListarIvaAlicuotasDetalles();
                    foreach (DataRow alicuotaDetalle in dtIvasAlicuotas.Rows)
                    {
                        idAlicuotaIVA = alicuotaDetalle["numero_afip"].ToString();
                        idAlicuotaIVA = idAlicuotaIVA.PadLeft(largoIdAlicuotaIVA, '0');

                        splitAux = alicuotaDetalle["Importe_Neto"].ToString().Split(',');
                        importeNetoGravado = splitAux[0] + splitAux[1];
                        importeNetoGravado = importeNetoGravado.PadLeft(largoImporteNetoPermitido, '0');

                        splitAux = alicuotaDetalle["Importe_iva"].ToString().Split(',');
                        impuestoLiquidado = splitAux[0] + splitAux[1];
                        impuestoLiquidado = impuestoLiquidado.PadLeft(largoImpuestoLiquidado, '0');

                        lineaTexto = tipoComprobanteAfip + puntoVenta + numComprobante + importeNetoGravado + idAlicuotaIVA + impuestoLiquidado;
                        lines[contRegistros2] = lineaTexto;
                        contRegistros2++;
                    }
                }
                System.IO.File.WriteAllLines(rutaDetallesVentas, lines);


                return true;
            }
            catch (Exception c)
            {
                return false;
                throw;
            }
        }

        private void GenerarDuplicadoDigital_IvaVentasComprobantes(string ruta)
        { 
            // datos para REGINFO_CV_VENTAS_CBTE					
            string fechaComprobanteCbte;
            string tipoComprobanteAfipCbte;
            string puntoVentaCbte;
            string numComprobanteCbte;
            string numComprobanteHastaCbte;
            string idDocTipoAfipCbte;
            string docCuitNumCbte;
            string apellidoNombreCbte;
            string importeTotalCbte;
            string importeNoGravadoCbte;//Importe total de conceptos que no integran el precio neto gravado
            string importeNoCategorizadosCbte;
            string importeOperacionesExentasCbte;
            string importeImpuestoNacCbte;
            string importeImpuestoProvCbte;
            string importeImpuestoMunCbte;
            string importeImpuestoInternoCbte;
            string codigoMonedaCbte;
            string tipoCambioCbte;
            string cantidadAlicuotasIvaCbte;
            string codOperacionCbte;
            string otrosTributosCbte;
            string fechaVencimientoCbte;

            int largoTipoCbtePermitido = 3;//segun normativa de afip
            int largoPtoVetaCbtePermitido = 5;//segun normativa de afip
            int largoNumCompCbtePermitido = 20;//segun normativa de afip
            int largoNumCompCbteHastaPermitido = 20;//segun normativa de afip
            int largoIdDocTipoCbtePermitido = 2;//segun normativa de afip
            int largoDocCuitCbtePermitido = 20;//segun normativa de afip
            int largoApellidoNombreCbtePermitido = 30;//segun normativa de afip
            int largoImporteTotalCbtePermitido = 15;//segun normativa de afip
            int largoImporteNoGravadoCbtePermitido = 15;//segun normativa de afip
            int largoImporteNoCategorizadosCbtePermitido = 15;//segun normativa de afip
            int largoImporteOperacionesExentasCbtePermitido = 15;//segun normativa de afip
            int largoImporteImpuestoNacCbtePermitido = 15;//segun normativa de afip
            int largoImporteImpuestoProvCbtePermitido = 15;//segun normativa de afip
            int largoImporteImpuestoMunCbtePermitido = 15;//segun normativa de afip
            int largoImporteImpuestoInternoCbtePermitido = 15;//segun normativa de afip
            int largoCantAlicuotasCbtePermitido = 1;//segun normativa de afip
            int largoTipoOperacionCbtePermitido = 1;//segun normativa de afip
            int largoOtrosCbtePermitido = 15;//segun normativa de afip

            string lineaTexto = String.Empty;
            DataTable dtAlicuotasComp = new DataTable();
            int contRegistros = 0;
            string[] splitAux;
            foreach (DataRow item in dtIvaVentas.Rows)
            {

                lineaTexto = String.Empty;
                fechaComprobanteCbte = Convert.ToDateTime(item["fecha"]).ToString("yyyyMMdd");

                tipoComprobanteAfipCbte = item["Codigo_Afip"].ToString();
                tipoComprobanteAfipCbte = tipoComprobanteAfipCbte.PadLeft(largoTipoCbtePermitido, '0');

                puntoVentaCbte = item["punto_venta"].ToString();
                puntoVentaCbte = puntoVentaCbte.PadLeft(largoPtoVetaCbtePermitido, '0');

                numComprobanteCbte = item["numero"].ToString();
                numComprobanteCbte = numComprobanteCbte.PadLeft(largoNumCompCbtePermitido, '0');

                numComprobanteHastaCbte = item["numero"].ToString();
                numComprobanteHastaCbte = numComprobanteCbte.PadLeft(largoNumCompCbteHastaPermitido, '0');

                idDocTipoAfipCbte = item["documento_afip"].ToString();
                idDocTipoAfipCbte = idDocTipoAfipCbte.PadLeft(largoIdDocTipoCbtePermitido, '0');

                docCuitNumCbte = item["numero_documento"].ToString();
                docCuitNumCbte = docCuitNumCbte.PadLeft(largoDocCuitCbtePermitido, '0');

                apellidoNombreCbte = item["razon_social"].ToString();
                apellidoNombreCbte = apellidoNombreCbte.PadRight(largoApellidoNombreCbtePermitido, ' ');
                if (apellidoNombreCbte.Length > 30)
                {
                    apellidoNombreCbte = apellidoNombreCbte.Substring(0, 30);
                }

                splitAux = item["importe_final"].ToString().Split(',');
                splitAux[0] = splitAux[0].PadLeft(13, '0');
                splitAux[1] = splitAux[1].PadLeft(2, '0');
                importeTotalCbte = $"{splitAux[0]}{splitAux[1]}";

                importeNoGravadoCbte = "0";
                importeNoGravadoCbte = importeNoGravadoCbte.PadLeft(largoImporteNoGravadoCbtePermitido, '0');

                importeNoCategorizadosCbte = "0";
                importeNoCategorizadosCbte = importeNoCategorizadosCbte.PadLeft(largoImporteNoCategorizadosCbtePermitido, '0');

                importeOperacionesExentasCbte = "0";
                importeOperacionesExentasCbte = importeOperacionesExentasCbte.PadLeft(largoImporteOperacionesExentasCbtePermitido, '0');

                splitAux = item["importe_impuesto_nacional"].ToString().Split(',');
                importeImpuestoNacCbte = splitAux[0] + splitAux[1];
                importeImpuestoNacCbte = importeImpuestoNacCbte.PadLeft(largoImporteImpuestoNacCbtePermitido, '0');

                splitAux = item["importe_impuesto_provincial"].ToString().Split(',');
                importeImpuestoProvCbte = splitAux[0] + splitAux[1];
                importeImpuestoProvCbte = importeImpuestoProvCbte.PadLeft(largoImporteImpuestoProvCbtePermitido, '0');

                splitAux = item["importe_impuesto_municipal"].ToString().Split(',');
                importeImpuestoMunCbte = splitAux[0] + splitAux[1];
                importeImpuestoMunCbte = importeImpuestoMunCbte.PadLeft(largoImporteImpuestoMunCbtePermitido, '0');

                splitAux = item["importe_impuesto_interno"].ToString().Split(',');
                importeImpuestoInternoCbte = splitAux[0] + splitAux[1];
                importeImpuestoInternoCbte = importeImpuestoInternoCbte.PadLeft(largoImporteImpuestoInternoCbtePermitido, '0');

                codigoMonedaCbte = "PES";

                tipoCambioCbte = "0001000000";

                oFacturacion.Id_Comprobantes = Convert.ToInt32(item["id_comprobantes"]);
                dtAlicuotasComp = oFacturacion.ListarIvalicuotas();

                //veo la cantidad de diferentes alicuotas-------------------
                var result = from rows in dtAlicuotasComp.AsEnumerable()
                             group rows by new { Name = rows["id_iva_alicuotas"] } into grp
                             select grp;

                List<DataTable> dts = new List<DataTable>();
                foreach (var item2 in result)
                    dts.Add(item2.CopyToDataTable());
                //----------------------------------------------------------
                if (dts.Count > 0)
                    cantidadAlicuotasIvaCbte = dts[0].Rows.Count.ToString();
                else
                    cantidadAlicuotasIvaCbte = "0";

                cantidadAlicuotasIvaCbte = cantidadAlicuotasIvaCbte.PadLeft(largoCantAlicuotasCbtePermitido, '0');

                codOperacionCbte = " ";
                codOperacionCbte = codOperacionCbte.PadLeft(largoTipoOperacionCbtePermitido, '0');

                otrosTributosCbte = "0";
                otrosTributosCbte = otrosTributosCbte.PadLeft(largoOtrosCbtePermitido, '0');

                fechaVencimientoCbte = Convert.ToDateTime(item["vencimiento"]).ToString("yyyyMMdd");

                lineaTexto = fechaComprobanteCbte + tipoComprobanteAfipCbte + puntoVentaCbte + numComprobanteCbte + numComprobanteHastaCbte + idDocTipoAfipCbte + docCuitNumCbte + apellidoNombreCbte + importeTotalCbte +
                    importeNoGravadoCbte + importeNoCategorizadosCbte + importeOperacionesExentasCbte + importeImpuestoNacCbte + importeImpuestoProvCbte + importeImpuestoMunCbte + importeImpuestoInternoCbte +
                    codigoMonedaCbte + tipoCambioCbte + cantidadAlicuotasIvaCbte + codOperacionCbte + otrosTributosCbte + fechaVencimientoCbte;
                lines[contRegistros] = lineaTexto;
                contRegistros++;
            }

            System.IO.File.WriteAllLines(ruta, lines);
        }

        private void GenerarDuplicadoDigital_Alicuotas(string ruta)
        {
            string valor_tipoComprobante;
            string valor_puntoDeVenta;
            string valor_numeroDeComprobante;
            string valor_importeNetoGravado;
            string valor_alicuotaIva;
            string valor_impuestoLiquidado;

            StringBuilder sb = new StringBuilder();
            List<string> listaRegistros = new List<string>();
            foreach (DataRow item in dtIvaVentas.Rows)
            {
                valor_tipoComprobante = item["Codigo_Afip"].ToString();
                valor_tipoComprobante = valor_tipoComprobante.PadLeft(3, '0');
                sb.Append(valor_tipoComprobante);

                valor_puntoDeVenta = item["punto_venta"].ToString();
                valor_puntoDeVenta = valor_puntoDeVenta.PadLeft(5, '0');
                sb.Append(valor_puntoDeVenta);

                valor_numeroDeComprobante = item["numero"].ToString();
                valor_numeroDeComprobante = valor_numeroDeComprobante.PadLeft(20, '0');
                sb.Append(valor_numeroDeComprobante);

                string[] importeSeparado = item["importe_final"].ToString().Split(',');
                importeSeparado[0] = importeSeparado[0].PadLeft(13, '0');
                importeSeparado[1] = importeSeparado[1].PadLeft(2, '0');
                valor_importeNetoGravado = $"{importeSeparado[0]}{importeSeparado[1]}";
                sb.Append(valor_importeNetoGravado);

                valor_alicuotaIva = "5";
                valor_alicuotaIva = valor_alicuotaIva.PadLeft(4, '0');
                sb.Append(valor_tipoComprobante);

                string[] importeSeparado2 = item["importe_iva"].ToString().Split(',');
                importeSeparado2[0] = importeSeparado2[0].PadLeft(13, '0');
                importeSeparado2[1] = importeSeparado2[1].PadLeft(2, '0');
                valor_impuestoLiquidado = $"{importeSeparado2[0]}{importeSeparado2[1]}";
                sb.Append(valor_impuestoLiquidado);

                listaRegistros.Add(sb.ToString());
                sb.Clear();
            }
            System.IO.File.WriteAllLines(ruta, listaRegistros);
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            string[] colDtIvaVentas = new string[] { "Razon_social", "localidad", "calle", "altura", "fecha", "punto_venta", "condicion_iva", "nombre", "letra", "cae", "numero_documento", "importe_neto", "importe_iva", "importe_impuesto_interno", "importe_impuesto_provincial", "importe_final","numero" };
            string[] colDtResumen = new string[] { "nombre", "letra", "punto_venta","total_final", "total_neto", "total_iva", "total_interno", "total_provincial", "total_nacional", "total_municipal" };

            DataTable dtIvaVentasAux = new DataTable();
            DataTable dtResumenAux = new DataTable();

            DataView dvIvaVentas = new DataView();
            dvIvaVentas = dtIvaVentas.DefaultView;
            dtIvaVentasAux = dvIvaVentas.ToTable(false, colDtIvaVentas);

            DataView dvResumen = new DataView();
            dvResumen = dtResumen.DefaultView;
            dtResumenAux = dvResumen.ToTable(false, colDtResumen);

            try 
            { 
                oTools.ExportDataTableToExcel(dtIvaVentasAux, "Impuestos");
                oTools.ExportDataTableToExcel(dtResumenAux, "Impuestos 2");
                MessageBox.Show("Datos exportados correctamente.");
            }
            catch (Exception c)
            {
                throw;
            }

        }

        private void frmImpuestos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }


        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnReimprimeComprobante_Click(object sender, EventArgs e)
        {
            oImpresion.Imprime_factura_RDLC(false, Convert.ToInt32(dgv.CurrentRow.Cells["id_comprobantes"].Value.ToString()));
        }




        public frmImpuestos()
        {
            InitializeComponent();
        }
        private void FormatearDgv()
        {
            foreach (DataGridViewColumn item in dgv.Columns)
                item.Visible = false;

            //dgv.Columns["numero"].Visible = true;
            //dgv.Columns["numero"].HeaderText = "Numero";
            //dgv.Columns["numero"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            //dgv.Columns["numero"].DisplayIndex = 0;

            dgv.Columns["Razon_Social"].Visible = true;
            dgv.Columns["Razon_Social"].HeaderText = "Razon Social";
            dgv.Columns["Razon_Social"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;


            dgv.Columns["condicion_iva"].Visible = true;
            dgv.Columns["condicion_iva"].HeaderText = "Condicion";
            dgv.Columns["condicion_iva"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

            dgv.Columns["Localidad"].Visible = true;
            dgv.Columns["Localidad"].HeaderText = "Localidad";
            dgv.Columns["Localidad"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

            dgv.Columns["Calle"].Visible = true;
            dgv.Columns["Calle"].HeaderText = "Calle";
            dgv.Columns["Calle"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;


            dgv.Columns["Altura"].Visible = true;
            dgv.Columns["Altura"].HeaderText = "Altura";
            dgv.Columns["Altura"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

            dgv.Columns["fecha"].Visible = true;
            dgv.Columns["fecha"].HeaderText = "Fecha";

            dgv.Columns["Punto_Venta"].Visible = true;
            dgv.Columns["Punto_Venta"].HeaderText = "Punto de venta";

            dgv.Columns["numero"].Visible = true;
            dgv.Columns["numero"].HeaderText = "Numero";
            //dgv.Columns["numero"].DisplayIndex = 3;


            dgv.Columns["nombre"].HeaderText = "Tipo";
            dgv.Columns["nombre"].Visible = true;

            dgv.Columns["cae"].HeaderText = "CAE";
            dgv.Columns["cae"].Visible = true;
            dgv.Columns["cae"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

            dgv.Columns["Numero_Documento"].HeaderText = "DNI";
            dgv.Columns["Numero_Documento"].Visible = true;

            dgv.Columns["Letra"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgv.Columns["Letra"].Visible = true;

            dgv.Columns["Importe_Neto"].HeaderText = "Importe neto";
            dgv.Columns["Importe_Neto"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv.Columns["Importe_Neto"].DefaultCellStyle.Format = "c";
            dgv.Columns["Importe_Neto"].Visible = true;

            dgv.Columns["Importe_Iva"].HeaderText = "Importe IVA";
            dgv.Columns["Importe_Iva"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv.Columns["Importe_Iva"].DefaultCellStyle.Format = "c";
            dgv.Columns["Importe_Iva"].Visible = true;


            dgv.Columns["Importe_Impuesto_Interno"].HeaderText = "Importe impuesto interno";
            dgv.Columns["Importe_Impuesto_Interno"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv.Columns["Importe_Impuesto_Interno"].DefaultCellStyle.Format = "c";
            dgv.Columns["Importe_Impuesto_Interno"].Visible = true;

            dgv.Columns["Importe_Final"].HeaderText = "Importe Final";
            dgv.Columns["Importe_Final"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv.Columns["Importe_Final"].DefaultCellStyle.Format = "c";
            dgv.Columns["Importe_Final"].Visible = true;

            dgv.Columns["Importe_Impuesto_Provincial"].HeaderText = "Importe impuesto provincial";
            dgv.Columns["Importe_Impuesto_Provincial"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv.Columns["Importe_Impuesto_Provincial"].DefaultCellStyle.Format = "c";
            dgv.Columns["Importe_Impuesto_Provincial"].Visible = true;

            if (chkMuestraRemito.Checked == false)
            {
                foreach (DataGridViewRow fila in dgv.Rows)
                {
                    if (fila.Cells["id_comprobantes_tipo"].Value.ToString() == "6")
                        fila.Visible = false;
                }
            }
            //*************************
        }

        private void FormatearGrillaResumen()
        {
            foreach (DataGridViewColumn item in dgv1.Columns)
                item.Visible = false;

            dgv1.Columns["nombre"].Visible = true;
            dgv1.Columns["nombre"].HeaderText = "Tipo comprobante";
            dgv1.Columns["nombre"].DisplayIndex = 0;
            dgv1.Columns["nombre"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            dgv1.Columns["letra"].Visible = true;
            dgv1.Columns["letra"].HeaderText = "Letra";
            dgv1.Columns["letra"].DisplayIndex = 1;

            dgv1.Columns["punto_venta"].Visible = true;
            dgv1.Columns["punto_venta"].HeaderText = "Punto de venta";
            dgv1.Columns["punto_venta"].DisplayIndex = 2;


            dgv1.Columns["total_final"].Visible = true;
            dgv1.Columns["total_final"].HeaderText = "Importe final";
            dgv1.Columns["total_final"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv1.Columns["total_final"].DefaultCellStyle.Format = "c";
            dgv1.Columns["total_final"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            dgv1.Columns["total_neto"].Visible = true;
            dgv1.Columns["total_neto"].HeaderText = "Importe neto";
            dgv1.Columns["total_neto"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv1.Columns["total_neto"].DefaultCellStyle.Format = "c";
            dgv1.Columns["total_neto"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            dgv1.Columns["Total_iva"].Visible = true;
            dgv1.Columns["Total_iva"].HeaderText = "Importe IVA";
            dgv1.Columns["Total_iva"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv1.Columns["Total_iva"].DefaultCellStyle.Format = "c";
            dgv1.Columns["Total_iva"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            dgv1.Columns["total_interno"].Visible = true;
            dgv1.Columns["total_interno"].HeaderText = "Importe impuesto interno";
            dgv1.Columns["total_interno"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv1.Columns["total_interno"].DefaultCellStyle.Format = "c";
            dgv1.Columns["total_interno"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            dgv1.Columns["total_provincial"].Visible = true;
            dgv1.Columns["total_provincial"].HeaderText = "Importe impuesto provincial";
            dgv1.Columns["total_provincial"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv1.Columns["total_provincial"].DefaultCellStyle.Format = "c";
            dgv1.Columns["total_provincial"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            dgv1.Columns["total_nacional"].Visible = true;
            dgv1.Columns["total_nacional"].HeaderText = "Importe impuesto nacional";
            dgv1.Columns["total_nacional"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv1.Columns["total_nacional"].DefaultCellStyle.Format = "c";
            dgv1.Columns["total_nacional"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            dgv1.Columns["Total_municipal"].Visible = true;
            dgv1.Columns["Total_municipal"].HeaderText = "Importe impuesto municipal";
            dgv1.Columns["Total_municipal"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv1.Columns["Total_municipal"].DefaultCellStyle.Format = "c";
            dgv1.Columns["Total_municipal"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            foreach (DataGridViewRow item in dgv1.Rows)
            {
                if (item.Cells["nombre"].Value.ToString().Equals("TOTALES: "))
                    item.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", lblDesde.Font.Size, System.Drawing.FontStyle.Bold);
            }

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            lblBuscar.Visible = false;
            txtBuscador.Visible = false;
            ComenzarCarga();
            //quito la hora de las fechas
            fecha_desde = string.Format("{0}-{1}-{2}", dtpdesde.Value.Year, dtpdesde.Value.Month, dtpdesde.Value.Day);
            fecha_hasta = string.Format("{0}-{1}-{2}", dtphasta.Value.Year, dtphasta.Value.Month, dtphasta.Value.Day);
            punto = Convert.ToInt32(cboPuntosVenta.SelectedValue);
            dtResultado = oFacturacion.ListarIvaVentasPorFechayPunto(fecha_desde, fecha_hasta, punto);
            dtIvaVentas = dtResultado[0];
            dtResumen = dtResultado[1];
            Flag = 1;
            dgv.DataSource = dtIvaVentas;
            dgv1.DataSource = dtResumen;
            FormatearDgv();
            lines = new string[dtIvaVentas.Rows.Count];
            lblTotal.Text = string.Format("Cantidad de registros : {0}", Convert.ToInt32(dgv.Rows.Count).ToString());
            lblBuscar.Visible = true;
            txtBuscador.Visible = true;

        }

    }
}
