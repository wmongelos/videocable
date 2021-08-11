using CapaNegocios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace CapaPresentacion.Contabilidad
{
    public partial class frmConsultaCobranzas : Form
    {
        private int idTipoFacturacion;
        private int idTipoFacturacionSeleccionada, idTipoServicioSeleccionado, idModalidadSeleccionada, idCajaDesdeSeleccionada, idCajaHastaSeleccionada;
        private List<int> listaModalidadesSeleccionadas = new List<int>();
        private Thread hilo;
        private delegate void myDel();
        private Zonas oZonas = new Zonas();
        private Servicios_Categorias oServiciosCategorias = new Servicios_Categorias();
        private Configuracion oConfig = new Configuracion();
        private Usuarios_CtaCte_Recibos oUsuariosCtaCteRecibos = new Usuarios_CtaCte_Recibos();
        private DataTable dtCobranzas = new DataTable();
        private DataTable dtDetallesCeldaConsultada = new DataTable();
        private Tools oTools = new Tools();
        private string tipoServicio, modalidad, facturacion, desde, hasta;
        private int consultaIndividual = 0;
        private int idColumnaSeleccionada = 0;
        private int idPuntoConbroSeleccionado = 0;

        public enum CONCEPTO_CONSULTA { ORDENES = 1, ATRASADO = 2, MENSUAL = 3, SPA = 4, PUNITORIOS = 5, PDP = 6, ESPECIALES = 7 };

        private void ComenzarCarga()
        {
            if (consultaIndividual == 0)
            {
                idTipoFacturacionSeleccionada = Convert.ToInt16(cboTipoFacturacion.SelectedValue);
                idTipoServicioSeleccionado = Convert.ToInt16(cboTipoServicio.SelectedValue);
                idModalidadSeleccionada = Convert.ToInt16(cboModalidadServicio.SelectedValue);
                if (chkConsultarPorCajas.Checked == true)
                    idCajaDesdeSeleccionada = (int)spIdCajaDesde.Value;
                else
                    idCajaDesdeSeleccionada = 0;
                idCajaHastaSeleccionada = (int)spIdCajaHasta.Value;
            }
            else
            {
                idColumnaSeleccionada = 0;
                if (dgvCobranzas.SelectedCells[0].OwningColumn.Name == "TOTAL_ORDENES")
                {
                    idColumnaSeleccionada = Convert.ToInt16(CONCEPTO_CONSULTA.ORDENES);
                    lblColumnaConsultada.Text = "Columna consultada: ORDENES";
                }
                else if (dgvCobranzas.SelectedCells[0].OwningColumn.Name == "TOTAL_ATRASADO")
                {
                    idColumnaSeleccionada = Convert.ToInt16(CONCEPTO_CONSULTA.ATRASADO);
                    lblColumnaConsultada.Text = "Columna consultada: ATRASADO";
                }
                else if (dgvCobranzas.SelectedCells[0].OwningColumn.Name == "TOTAL_MENSUAL")
                {
                    idColumnaSeleccionada = Convert.ToInt16(CONCEPTO_CONSULTA.MENSUAL);
                    lblColumnaConsultada.Text = "Columna consultada: MENSUAL";
                }
                else if (dgvCobranzas.SelectedCells[0].OwningColumn.Name == "TOTAL_SPA")
                {
                    idColumnaSeleccionada = Convert.ToInt16(CONCEPTO_CONSULTA.SPA);
                    lblColumnaConsultada.Text = "Columna consultada: PAGOS ADELANTADOS";
                }
                else if (dgvCobranzas.SelectedCells[0].OwningColumn.Name == "TOTAL_PUNITORIOS")
                {
                    idColumnaSeleccionada = Convert.ToInt16(CONCEPTO_CONSULTA.PUNITORIOS);
                    lblColumnaConsultada.Text = "Columna consultada: PUNITORIOS";
                }
                else if (dgvCobranzas.SelectedCells[0].OwningColumn.Name == "TOTAL_PDP")
                {
                    idColumnaSeleccionada = Convert.ToInt16(CONCEPTO_CONSULTA.PDP);
                    lblColumnaConsultada.Text = "Columna consultada: PLAN DE PAGO";
                }
                else if (dgvCobranzas.SelectedCells[0].OwningColumn.Name == "TOTAL_ESPECIALES")
                {
                    idColumnaSeleccionada = Convert.ToInt16(CONCEPTO_CONSULTA.ESPECIALES);
                    lblColumnaConsultada.Text = "Columna consultada: ESPECIALES";
                }
                idPuntoConbroSeleccionado = Convert.ToInt32(dgvCobranzas.SelectedCells[0].OwningRow.Cells["id_punto_cobro"].Value);
            }
            btnBuscar.Enabled = false;
            btnExportar.Enabled = false;
            pgCircular.Start();
            hilo = new Thread(new ThreadStart(CargarDatos));
            hilo.Start();
        }

        private void chkConsultarPorCajas_CheckedChanged(object sender, EventArgs e)
        {
            if (chkConsultarPorCajas.Checked)
            {
                dtpFechaDesde.Enabled = false;
                dtpFechaHasta.Enabled = false;
                spIdCajaDesde.Enabled = true;
                spIdCajaHasta.Enabled = true;
            }
            else
            {
                dtpFechaDesde.Enabled = true;
                dtpFechaHasta.Enabled = true;
                spIdCajaDesde.Enabled = false;
                spIdCajaHasta.Enabled = false;
            }
        }

        private void dgvCobranzas_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvCobranzas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvCobranzas.SelectedCells.Count > 0)
                {
                    if (dgvCobranzas.SelectedCells[0].RowIndex != 0 && dgvCobranzas.SelectedCells[0].ColumnIndex != 0)
                    {
                        consultaIndividual = 1;
                        ComenzarCarga();

                    }
                }
            }
            catch
            {
                MessageBox.Show("Error al consultar. Vuelva a intentarlo.");
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            pnlDetalles.Visible = false;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void CargarDatos()
        {
            if (consultaIndividual == 0)
            {
                listaModalidadesSeleccionadas.Clear();
                listaModalidadesSeleccionadas.Add(idModalidadSeleccionada);
                dtCobranzas = oUsuariosCtaCteRecibos.ListarCobranzas(idTipoServicioSeleccionado, listaModalidadesSeleccionadas, idTipoFacturacionSeleccionada, dtpFechaDesde.Value, dtpFechaHasta.Value, idCajaDesdeSeleccionada, idCajaHastaSeleccionada, 0, 0);
            }
            else
            {
                listaModalidadesSeleccionadas.Clear();
                listaModalidadesSeleccionadas.Add(idModalidadSeleccionada);
                dtDetallesCeldaConsultada = oUsuariosCtaCteRecibos.ListarCobranzas(idTipoServicioSeleccionado, listaModalidadesSeleccionadas, idTipoFacturacionSeleccionada, dtpFechaDesde.Value, dtpFechaHasta.Value, idCajaDesdeSeleccionada, idCajaHastaSeleccionada, idColumnaSeleccionada, idPuntoConbroSeleccionado);
            }
            myDel MD = new myDel(AsignarDatos);
            this.Invoke(MD, new object[] { });
            pgCircular.Stop();
        }

        private void boton1_Click(object sender, EventArgs e)
        {
            dtDetallesCeldaConsultada.DefaultView.RowFilter = String.Format("id_usuarios_ctacte_det>0");
            ExportarAExcelDetalles();
        }

        private void AsignarDatos()
        {
            if (consultaIndividual == 0)
            {
                if (dtCobranzas.Rows.Count > 0)
                {
                    DataRow cabecera = dtCobranzas.NewRow();
                    cabecera["id_punto_cobro"] = -1;
                    cabecera["punto_cobro"] = String.Format("Tipo de servicio:'{0}', modalidad:'{1}', tipo de facturación:'{2}', desde:'{3}', hasta:'{4}'", tipoServicio, modalidad, facturacion, desde, hasta);

                    dtCobranzas.Rows.InsertAt(cabecera, 0);
                }

                dgvCobranzas.DataSource = dtCobranzas;
                dgvCobranzas.Columns["id_punto_cobro"].Visible = false;
                dgvCobranzas.Columns["punto_cobro"].HeaderText = "Punto de cobro";
                dgvCobranzas.Columns["TOTAL_ORDENES"].HeaderText = "Ordenes (conexiones y otras)";
                dgvCobranzas.Columns["TOTAL_ATRASADO"].HeaderText = "Atrasado";
                dgvCobranzas.Columns["TOTAL_MENSUAL"].HeaderText = "Mensual";
                dgvCobranzas.Columns["TOTAL_SPA"].HeaderText = "Pago adelantado";
                dgvCobranzas.Columns["TOTAL_PUNITORIOS"].HeaderText = "Punitorios";
                dgvCobranzas.Columns["TOTAL_PDP"].HeaderText = "Plan de pago";
                dgvCobranzas.Columns["TOTAL_ESPECIALES"].HeaderText = "Especiales";

                dgvCobranzas.Columns["TOTAL_ORDENES"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvCobranzas.Columns["TOTAL_ATRASADO"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvCobranzas.Columns["TOTAL_MENSUAL"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvCobranzas.Columns["TOTAL_SPA"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvCobranzas.Columns["TOTAL_PUNITORIOS"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvCobranzas.Columns["TOTAL_PDP"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvCobranzas.Columns["TOTAL_ESPECIALES"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;


                lblTotal.Text = String.Format("Total de Registros: {0}", dtCobranzas.Rows.Count);
            }
            else
            {
                decimal totalMonto = 0;
                dgvDetalles.DataSource = dtDetallesCeldaConsultada;
                lblPuntoCobro.Text = String.Format("Punto de cobro: {0}", dgvCobranzas.SelectedCells[0].OwningRow.Cells["punto_cobro"].Value.ToString());
                lblTotalRegistroDetalles.Text = String.Format("Total de registros: {0}", dtDetallesCeldaConsultada.Rows.Count);

                if (idColumnaSeleccionada == Convert.ToInt16(CONCEPTO_CONSULTA.PUNITORIOS))
                {
                    foreach (DataRow fila in dtDetallesCeldaConsultada.Rows)
                        totalMonto += Convert.ToDecimal(fila["importe_punitorio"]);
                }
                else
                {
                    foreach (DataRow fila in dtDetallesCeldaConsultada.Rows)
                        totalMonto += Convert.ToDecimal(fila["resta_imputacion_punitorios"]);
                }
                lblSumatoriaMontos.Text = String.Format("Sumatoria de montos de detalles: {0}", totalMonto);
                for (int x = 0; x < dgvDetalles.ColumnCount; x++)
                    dgvDetalles.Columns[x].Visible = false;
                dgvDetalles.Columns["subservicio"].Visible = true;
                dgvDetalles.Columns["codigo_usuario"].Visible = true;
                dgvDetalles.Columns["importe_imputa"].Visible = true;
                dgvDetalles.Columns["importe_punitorio"].Visible = true;
                dgvDetalles.Columns["resta_imputacion_punitorios"].Visible = true;
                pnlDetalles.Location = new Point(
                    this.ClientSize.Width / 2 - pnlDetalles.Size.Width / 2,
                    this.ClientSize.Height / 2 - pnlDetalles.Size.Height / 2);
                pnlDetalles.Anchor = AnchorStyles.None;
                pnlDetalles.Visible = true;
                consultaIndividual = 0;
            }
            btnBuscar.Enabled = true;
            btnExportar.Enabled = true;
        }

        private void ExportarAExcel()
        {
            if (dgvCobranzas.Rows.Count > 0)
                oTools.ExportToExcel(dgvCobranzas, "Cobranza");
            else
                MessageBox.Show("No hay datos en la grilla.");
        }

        private void ExportarAExcelDetalles()
        {
            if (dgvDetalles.Rows.Count > 0)
                oTools.ExportToExcel(dgvDetalles, "DetallesDeCobranza");
            else
                MessageBox.Show("No hay datos en la grilla.");
        }


        public frmConsultaCobranzas()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            tipoServicio = cboTipoServicio.Text;
            modalidad = cboModalidadServicio.Text;
            facturacion = cboTipoFacturacion.Text;
            desde = dtpFechaDesde.Value.ToString();
            hasta = dtpFechaHasta.Value.ToString();
            idCajaDesdeSeleccionada = (int)spIdCajaDesde.Value;
            idCajaHastaSeleccionada = (int)spIdCajaHasta.Value;
            ComenzarCarga();
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            dtCobranzas.DefaultView.RowFilter = String.Format("id_punto_cobro>-2");
            ExportarAExcel();
        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmConsultaCobranzas_Load(object sender, EventArgs e)
        {
            cboTipoServicio.DataSource = Tablas.DataServicios_Tipos;
            cboTipoServicio.DisplayMember = "nombre";
            cboTipoServicio.ValueMember = "id";

            cboModalidadServicio.DataSource = Tablas.DataServicios_Modalidades;
            cboModalidadServicio.DisplayMember = "nombre";
            cboModalidadServicio.ValueMember = "id";

            idTipoFacturacion = oConfig.GetValor_N("Id_Tipo_Facturacion");
            if (idTipoFacturacion == Convert.ToInt32(Tipo_Facturacion.Id_Tipo_Facturacion.POR_CATEGORIAS))
            {
                cboTipoFacturacion.DataSource = oServiciosCategorias.Listar();
                lblTipoFacturacion.Text = String.Format("Categoría:");
            }
            else
            {
                cboTipoFacturacion.DataSource = oZonas.Listar();
                lblTipoFacturacion.Text = String.Format("Zona:");
            }
            cboTipoFacturacion.DisplayMember = "nombre";
            cboTipoFacturacion.ValueMember = "id";
            chkConsultarPorCajas.Checked = true;
            dtpFechaDesde.Enabled = false;
            dtpFechaHasta.Enabled = false;
            spIdCajaDesde.Enabled = true;
            spIdCajaHasta.Enabled = true;
        }

        private void frmConsultaCobranzas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
    }
}//241019fede
