using CapaNegocios;
using System;
using System.ComponentModel;
using System.Data;
using System.Threading;
using System.Windows.Forms;
namespace CapaPresentacion.Impuestos
{
    public partial class frmImpuestosProvincial : Form
    {
        private Thread hilo;

        private delegate void myDel();
        private Comprobantes_Iva oComprobates_iva = new Comprobantes_Iva();
        private Facturacion oFacturacion = new Facturacion();
        private DataTable dtImpuestos;
        private DataTable[] dtResultados;
        private DataTable dtPuntos_ventas = new DataTable();
        private int punto;
        decimal Neto_Total, total_prov, TotalTotal;
        private string fecha_desde, fecha_hasta;
        private Puntos_Venta oPuntos_ventas = new Puntos_Venta();
        private Tools oTools = new Tools();
        private string ruta;


        public frmImpuestosProvincial()
        {
            InitializeComponent();
        }
        private void LoadData()
        {
            Neto_Total = 0;
            total_prov = 0;
            punto = Convert.ToInt32(cboPuntosVenta.SelectedValue);
            fecha_desde = string.Format("{0}-{1}-{2}", dtpdesde.Value.Year, dtpdesde.Value.Month, dtpdesde.Value.Day);
            fecha_hasta = string.Format("{0}-{1}-{2}", dtphasta.Value.Year, dtphasta.Value.Month, dtphasta.Value.Day);
            hilo = new Thread(new ThreadStart(cargarDatos));
            hilo.Start();
        }
        private void cargarDatos()
        {
            try
            {

                dtResultados = oFacturacion.ListarIvaVentasPorFechayPunto(fecha_desde, fecha_hasta, punto);
                dtImpuestos = dtResultados[0];
                myDel MD = new myDel(Calcular);
                this.Invoke(MD, new object[] { });

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar Informacion" + ex.Message);
            }
        }
        private void imgReturn_Click(object sender, EventArgs e)
        {

            this.Close();
        }

        private void frmImpuestosProvincial_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void frmImpuestosProvincial_Load(object sender, EventArgs e)
        {
            dtPuntos_ventas = oPuntos_ventas.Listar();
            DataRow row = dtPuntos_ventas.NewRow();
            row["numero"] = 0;
            row["descripcion"] = "TODOS";
            dtPuntos_ventas.Rows.Add(row);
            cboPuntosVenta.DataSource = dtPuntos_ventas;
            cboPuntosVenta.DisplayMember = "Descripcion";
            cboPuntosVenta.ValueMember = "Numero";
            //dtpdesde.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month - 1, 1);
            dtpdesde.Value = DateTime.Now.AddMonths(-1);
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            oTools.ExportToExcel(dgv, "Impuestos");
            this.Cursor = Cursors.Arrow;
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnGenerarTxt_Click(object sender, EventArgs e)
        {
            Configuracion oConf = new Configuracion();
            string nombreArchivo = "ar-" + oConf.GetValor_C("cuit") + "-" + dtpdesde.Value.Year.ToString() + dtpdesde.Value.Month.ToString() + "0" + "7-lote1.txt";
            ruta = string.Empty;
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "Archivo de texto (*txt)|*txt";
            saveDialog.FilterIndex = 2;
            saveDialog.FileName = nombreArchivo;
            MessageBox.Show("Seleccione el destino del archivo de informacion de ventas");
            if (saveDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                ruta = saveDialog.FileName;
                tarea.DoWork += GenerarLibroProvincial;
                barProgreso.Maximum = dtImpuestos.Rows.Count;

                tarea.RunWorkerCompleted += Terminado;
                tarea.RunWorkerAsync();

                imgReturn.Enabled = false;
                this.KeyPreview = false;
                Cursor = Cursors.WaitCursor;
                btnBuscar.Enabled = false;
                btnExportar.Enabled = false;
                btnGenerarTxt.Enabled = false;
                btnReimprimeComprobante.Enabled = false;

                pnlProgreso.Visible = true;
                pnlProgreso.Location = new System.Drawing.Point((dgv.Width / 2) - pnlProgreso.Width / 2, dgv.Height / 2);
                pnlProgreso.BringToFront();
            }

        }

        private void Terminado(object o, RunWorkerCompletedEventArgs e)
        {

            barProgreso.Value = barProgreso.Maximum;
            this.Cursor = Cursors.Arrow;
            pnlProgreso.Visible = false;
            MessageBox.Show("Archivos generados correctamente", "Mensaje del Sistema");
            imgReturn.Enabled = true;
            this.KeyPreview = true;
            btnBuscar.Enabled = true;
            btnExportar.Enabled = true;
            btnGenerarTxt.Enabled = true;
            btnReimprimeComprobante.Enabled = true;
        }

        private void GenerarLibroProvincial(object o, DoWorkEventArgs e)
        {
            int contador = 0;
            // datos para REGINFO_CV_VENTAS_CBTE					


            string docCuitNumCbte;
            string fechaComprobanteCbte;

            string puntoVentaCbte;
            string numComprobanteCbte;
            string importeNeto;//Importe total de conceptos que no integran el precio neto gravado
            string importeprovincial;
            string tipo = "A"; //alta
            string letraComprobante;

            int largoPtoVetaCbtePermitido = 4;//segun normativa de afip
            int largoNumCompCbtePermitido = 8;//segun normativa de afip

            int largoImporteNeto = 12;//segun normativa de afip
            int largoImporteProvincial = 11;//segun normativa de afip
            string[] lines = new string[dtImpuestos.Rows.Count];


            string lineaTexto = String.Empty;
            DataTable dtAlicuotasComp = new DataTable();
            int contRegistros = 0;
            string[] splitAux;
            foreach (DataRow item in dtImpuestos.Rows)
            {

                lineaTexto = String.Empty;

                docCuitNumCbte = item["numero_documento"].ToString();

                if (docCuitNumCbte.Length > 1)
                    docCuitNumCbte = docCuitNumCbte.Insert(2, "-");

                docCuitNumCbte = docCuitNumCbte.Insert(docCuitNumCbte.Length - 1, "-");

                fechaComprobanteCbte = Convert.ToDateTime(item["fecha"]).ToString("dd/MM/yyyy");


                if (Convert.ToInt32(item["codigo_afip"]) == (int)Comprobantes_Tipo.Tipo.FACTURA_A || Convert.ToInt32(item["codigo_afip"]) == (int)Comprobantes_Tipo.Tipo.FACTURA_B)
                    tipo = "F";
                else
                    tipo = "C";

                letraComprobante = item["letra"].ToString();

                puntoVentaCbte = item["punto_venta"].ToString();
                puntoVentaCbte = puntoVentaCbte.PadLeft(largoPtoVetaCbtePermitido, '0');

                numComprobanteCbte = item["numero"].ToString();
                numComprobanteCbte = numComprobanteCbte.PadLeft(largoNumCompCbtePermitido, '0');

                importeNeto = "0";
                importeprovincial = "0";

                if (Convert.ToInt32(item["codigo_afip"]) == (int)Comprobantes_Tipo.Tipo.NOTA_CREDITO_A || Convert.ToInt32(item["codigo_afip"]) == (int)Comprobantes_Tipo.Tipo.NOTA_CREDITO_B)
                {
                    importeNeto = item["importe_final"].ToString();
                    importeNeto = importeNeto.Replace(',', '.');
                    importeNeto = importeNeto.PadLeft(largoImporteNeto - 1, '0');
                    importeNeto = "-" + importeNeto;

                    importeprovincial = item["importe_impuesto_provincial"].ToString();
                    importeprovincial = importeprovincial.Replace(',', '.');
                    importeprovincial = importeprovincial.PadLeft(largoImporteProvincial - 1, '0');
                    importeprovincial = "-" + importeprovincial;
                }
                else
                {
                    importeNeto = item["importe_final"].ToString();
                    importeNeto = importeNeto.Replace(',', '.');
                    importeNeto = importeNeto.PadLeft(largoImporteNeto, '0');

                    importeprovincial = item["importe_impuesto_provincial"].ToString();
                    importeprovincial = importeprovincial.Replace(',', '.');
                    importeprovincial = importeprovincial.PadLeft(largoImporteProvincial, '0');
                }

                lineaTexto = docCuitNumCbte + fechaComprobanteCbte + tipo + letraComprobante + puntoVentaCbte + numComprobanteCbte + importeNeto + importeprovincial + "A";
                lines[contRegistros] = lineaTexto;
                contRegistros++;

                tarea.ReportProgress(contRegistros, dtImpuestos.Rows.Count);

            }
            System.IO.File.WriteAllLines(ruta, lines);

        }

        private void tarea_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            barProgreso.Value = e.ProgressPercentage;
        }

        private void dtpdesde_ValueChanged(object sender, EventArgs e)
        {
            dtphasta.Value = DateTime.Now;

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void Calcular()
        {
            Neto_Total = 0;
            total_prov = 0;
            //creo columna de total y la agrego
            DataColumn ColumnaTotalFinal = new DataColumn();
            ColumnaTotalFinal.ColumnName = "Total_Final";
            ColumnaTotalFinal.DataType = System.Type.GetType("System.Decimal");
            dtImpuestos.Columns.Add(ColumnaTotalFinal);

            //calculo el total por cada fila
            foreach (DataRow fila in dtImpuestos.Rows)
            {
                if (Convert.ToDecimal(fila["Importe_Impuesto_Provincial"]) > 0)
                {
                    fila["Importe_FinAL"] = Convert.ToDecimal(fila["Importe_FinAL"]) - Convert.ToDecimal(fila["Importe_Impuesto_Provincial"]);
                    TotalTotal = Convert.ToDecimal(fila["Importe_FinAL"]) + Convert.ToDecimal(fila["Importe_Impuesto_Provincial"]);
                    fila["Total_Final"] = TotalTotal;
                    Neto_Total = Neto_Total + Convert.ToDecimal(fila["Importe_Neto"]);

                    total_prov = total_prov + Convert.ToDecimal(fila["Importe_Impuesto_Provincial"]);

                }
            }

            DataView dv;
            dv = new DataView(dtImpuestos, "Importe_Impuesto_Provincial> 0 ", "Id_comprobantes ASC", DataViewRowState.CurrentRows);
            dtImpuestos = dv.ToTable();
            dgv.DataSource = dtImpuestos;
            txtTotalProvincial.Text = total_prov.ToString("c2");
            txtTotalNeto.Text = Neto_Total.ToString("c2");
            FormatearDgv();
            lblTotal.Text = string.Format("Cantidad de registros: {0}", dgv.Rows.Count);

        }
        private void FormatearDgv()
        {
            dgv.Columns["Razon_Social"].HeaderText = "Razon Social";
            dgv.Columns["Razon_Social"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgv.Columns["Id_comprobantes_tipo"].Visible = false;
            dgv.Columns["fecha"].HeaderText = "Fecha";
            dgv.Columns["Punto_Venta"].HeaderText = "Punto de venta";
            dgv.Columns["nombre"].HeaderText = "Tipo";
            dgv.Columns["Codigo_Afip"].Visible = false;
            dgv.Columns["cae"].HeaderText = "CAE";
            dgv.Columns["cae"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgv.Columns["letra"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgv.Columns["Numero_Documento"].HeaderText = "DNI";
            dgv.Columns["Importe_Neto"].HeaderText = "Importe neto";
            dgv.Columns["Importe_Neto"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv.Columns["Importe_Neto"].DefaultCellStyle.Format = "c";
            dgv.Columns["Importe_Iva"].HeaderText = "Importe IVA";
            dgv.Columns["Importe_Iva"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv.Columns["Importe_Iva"].DefaultCellStyle.Format = "c";
            dgv.Columns["Importe_Impuesto_Interno"].HeaderText = "Importe impuesto interno";
            dgv.Columns["Importe_Impuesto_Interno"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv.Columns["Importe_Impuesto_Interno"].DefaultCellStyle.Format = "c";
            dgv.Columns["Importe_Final"].HeaderText = "Importe Final";
            dgv.Columns["Importe_Final"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv.Columns["Importe_Final"].DefaultCellStyle.Format = "c";
            dgv.Columns["Importe_Impuesto_Provincial"].HeaderText = "Importe impuesto provincial";
            dgv.Columns["Importe_Impuesto_Provincial"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv.Columns["Importe_Impuesto_Provincial"].DefaultCellStyle.Format = "c";
            dgv.Columns["Id_comprobantes"].Visible = false;
            dgv.Columns["Id_comprobantes_iva"].Visible = false;
            dgv.Columns["Total_Final"].HeaderText = "Total";
            dgv.Columns["Total_Final"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv.Columns["Total_Final"].DefaultCellStyle.Format = "c";
        }
    }
}