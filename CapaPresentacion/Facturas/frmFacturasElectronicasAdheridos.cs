using CapaNegocios;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using System.Linq;

namespace CapaPresentacion.Facturas
{
    public partial class frmFacturasElectronicasAdheridos : Form
    {
        private Thread hilo;
        private delegate void myDel();

        private static DataTable dtResultados = new DataTable();
        private DataTable dtComprobantes;
        private DataTable dtComprobantesDebitos;
        private DataTable dtLocaciones = new DataTable();
        private DataTable dtSalidasCae = new DataTable();
        private DataTable dtFacturaciones = new DataTable();

        private Usuarios_CtaCte oUsuarioCtaCte = new Usuarios_CtaCte();
        private Facturacion oFacturacion = new Facturacion();
        private Usuarios_Locaciones oUsuLoc = new Usuarios_Locaciones();
        private Usuarios_Dom_Fiscal oUsuLocFiscal = new Usuarios_Dom_Fiscal();
        private Comprobantes oComprobantes = new Comprobantes();
        private Facturacion_Mensual_Historial oFacHistorial = new Facturacion_Mensual_Historial();
        private Color oColor = new Color();
        frmPopUp oPop = new frmPopUp();
        private Int32 idFacturacionSeleccionada = 0, unitario = 0;
        private DateTime fechaDesdeSeleccionada = new DateTime();
        private DateTime fechaHastaSeleccionada = new DateTime();
        private Int32 contador = 0;
        private Int32 codigoRetorno = 0;
        private decimal porcentajeHecho;
        private string mensajeSalida = "", cae = "", localidad, codigoPostal, altura, piso, depto, calle;
        private int corrioFacturacion;
        private bool facturarDebitos = false;
        private decimal totalFacturar = 0;
       
        public frmFacturasElectronicasAdheridos()
        {
            InitializeComponent();
            CargarComboDeFacturaciones();
        }

        private void comenzarCarga()
        {
            int x, y;
            x = (spMain.Width / 2) - (pnlCargando.Width / 2);
            y = (spMain.Height / 2) - (pnlCargando.Height / 2);
            //asignamos la nueva ubicación
            pnlCargando.Location = new Point(x, y);
            dgvServiciosAFacturar.DataSource = null;
            pgCircular.Start();
            spMain.Panel1Collapsed = false;
            spMain.Panel2Collapsed = true;
            dgvServiciosAFacturar.DataSource = null;
            hilo = new Thread(new ThreadStart(cargarDatos));
            hilo.Start();
        }

        private void cargarDatos()
        {
            try
            { 
                dtComprobantes = oComprobantes.ListarAdheridosFacElectronica(idFacturacionSeleccionada, fechaDesdeSeleccionada, fechaHastaSeleccionada);
                dtComprobantes.Columns.Add("mensaje", typeof(string));
                myDel MD = new myDel(AsignarDatos);
                this.Invoke(MD, new object[] { });
                pgCircular.Stop();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar Información" + ex.Message);
            }
        }

        private void AsignarDatos()
        {
            CboFiltro.Enabled = true;
            CboFiltro.SelectedIndex = 0;
            cboFacturacion.SelectedIndex = 0;
            if (idFacturacionSeleccionada > 0)
            {
                dgvServiciosAFacturar.DataSource = dtComprobantes;
                dtComprobantes.Columns.Add("cae", typeof(string));
                dtComprobantes.Columns.Add("salida", typeof(string));          
                CalcularTotales();
            }
            else
            {
                if (idFacturacionSeleccionada == 0)
                    MessageBox.Show("No se hizo ninguna facturacion mensual todavia", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (idFacturacionSeleccionada == -1)
                    MessageBox.Show("Hubo un error al obtener la ultima facturacion mensual", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            spMain.Panel1Collapsed = true;
            spMain.Panel2Collapsed = false;
            if (idFacturacionSeleccionada <= 0)
                btnFacturacion.Enabled = false;
            else
                FormatearGrilla(dgvServiciosAFacturar);

        }

        private void CargarComboDeFacturaciones()
        {
            dtFacturaciones = oFacHistorial.ListarHistorial();
            idFacturacionSeleccionada = Convert.ToInt32(dtFacturaciones.Rows[dtFacturaciones.Rows.Count - 1]["id"]);
            fechaDesdeSeleccionada = Convert.ToDateTime(dtFacturaciones.Rows[dtFacturaciones.Rows.Count - 1]["fecha_desde"]);
            fechaHastaSeleccionada = Convert.ToDateTime(dtFacturaciones.Rows[dtFacturaciones.Rows.Count - 1]["fecha_hasta"]);

            cboFacturacion.DataSource = dtFacturaciones;
            cboFacturacion.DisplayMember = "periodo";
            cboFacturacion.ValueMember = "id";
            cboFacturacion.SelectedValue = idFacturacionSeleccionada;
        }

        private void CalcularTotales()
        {
            if (dtComprobantes == null)
                return;

            lblTotal.Text = string.Format("Total de Registros: {0}", dtComprobantes.DefaultView.Count);
            decimal total = 0;
            foreach (DataGridViewRow item in dgvServiciosAFacturar.Rows)
                total += Convert.ToDecimal(item.Cells["importe_final"].Value);
            lblTotalImporte.Text = "Total: " + total.ToString("c2");
            lblTotalImporte.Location = new Point(lblTotal.Location.X + lblTotal.Width + 10, lblTotalImporte.Location.Y);
            spHasta.Maximum = total;
            spHasta.Value = total;
            spHasta.Tag = total.ToString();
        }

        private void FormatearGrilla(DataGridView dgv)
        {

            foreach (DataGridViewColumn item in dgv.Columns)
                item.Visible = false;

            dgv.Columns["descripcion"].Visible = true;
            dgv.Columns["descripcion"].HeaderText = "Descripcion";
            dgv.Columns["descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgv.Columns["usuario"].Visible = true;
            dgv.Columns["usuario"].HeaderText = "Usuario";
            dgv.Columns["importe_original"].Visible = true;
            dgv.Columns["importe_original"].HeaderText = "Importe Original";
            dgv.Columns["importe_original"].DefaultCellStyle.Format = "C";
            dgv.Columns["importe_original"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv.Columns["importe_bonificacion"].Visible = true;
            dgv.Columns["importe_bonificacion"].HeaderText = "Importe Bonificado";
            dgv.Columns["importe_bonificacion"].DefaultCellStyle.Format = "C";
            dgv.Columns["importe_bonificacion"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv.Columns["importe_provincial"].Visible = true;
            dgv.Columns["importe_provincial"].HeaderText = "Importe Provincial";
            dgv.Columns["importe_provincial"].DefaultCellStyle.Format = "C";
            dgv.Columns["importe_provincial"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv.Columns["importe_final"].Visible = true;
            dgv.Columns["importe_final"].HeaderText = "Importe Final";
            dgv.Columns["importe_final"].DefaultCellStyle.Format = "C";
            dgv.Columns["importe_final"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv.Columns["mensaje"].Visible = true;
            dgv.Columns["mensaje"].HeaderText = "Salida";

            if (facturarDebitos)
            {
                foreach (DataGridViewRow item in dgvServiciosAFacturar.Rows)
                {
                    item.DefaultCellStyle.BackColor = Color.LightSteelBlue;
                }
            }

        }


        private void frmFacturasElectronicasAdheridos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
        private void Terminado(object o, RunWorkerCompletedEventArgs e)
        {
            oPop.Formulario = null;
            oPop.pnlPanel = this.pnlErrores;

            pgBar.Value = pgBar.Maximum;
            this.Cursor = Cursors.Arrow;
            MessageBox.Show("Facturas generadas.", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (dtResultados.Rows.Count > 0)
            {
                btnVerErrores.Visible = true;
                dgvErrores.DataSource = dtResultados;
                FormatearGrilla(dgvErrores);
                MessageBox.Show("Hubo errores al generar (" + dtResultados.Rows.Count + " ) facturas.", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                // pnlErrores.Visible = true;
                oPop.Maximizar = false;
                oPop.ShowDialog();
            }
        }



        private void GenerarFacturas(object o, DoWorkEventArgs e)
        {
            if (dtResultados.Columns.Count == 0)
            {
                dtResultados = dtComprobantes.Clone();
                dtResultados.Columns.Add("idComprobante", typeof(Int32));
                dtResultados.Columns.Add("idError", typeof(Int32));

            }
            int idLocacion = 0, idUsuario = 0, idComprobante = 0;
            Facturacion.facturacionElectronicaMensual = 1;
            corrioFacturacion = 1;
            DataTable dtComprobantesFiltrados = dtComprobantes.DefaultView.ToTable();

            foreach (DataRow item in dtComprobantesFiltrados.Rows)
            {
                try
                {
                    idUsuario = Convert.ToInt32(item["id_usuarios"]);
                    idComprobante = Convert.ToInt32(item["idComprobantes"]);
                    idLocacion = Convert.ToInt32(item["id_usuarios_locaciones"]);
                    localidad = item["localidad"].ToString();
                    calle = item["calle"].ToString();
                    altura = item["altura"].ToString();
                    piso = item["piso"].ToString();
                    codigoPostal = item["codigo_postal"].ToString();
                    depto = item["depto"].ToString();
                    Usuarios.CurrentUsuario.Id = idUsuario;
                    Usuarios.Current_IdUsuario = idUsuario;
                    Usuarios oUsu = new Usuarios();
                    oUsu.LlenarObjeto(idUsuario);
                    Usuarios.CurrentUsuario.localidad = this.localidad;
                    Usuarios.CurrentUsuario.Calle = this.calle;
                    Usuarios.CurrentUsuario.piso = this.piso;
                    Usuarios.CurrentUsuario.Altura = Convert.ToInt32(this.altura);
                    Usuarios.CurrentUsuario.Cod_postal = this.codigoPostal;
                    Usuarios.CurrentUsuario.Depto = this.depto;


                    Usuarios.CurrentUsuarioDomFiscal = oUsuLocFiscal.LlenarDatosLocFiscal(idLocacion);
                    dtLocaciones = oUsuLoc.ListarLocacionesDeServicio(idUsuario);
                    DataTable dtCtaCteDetfinal = oUsuarioCtaCte.LlenarDtModelo(dtLocaciones, "C", idComprobante);
                    bool calcularPercepcion = false;

                    foreach (DataRow Dr in dtCtaCteDetfinal.Rows)
                    {
                        Dr["elige"] = true;
                        Dr["importe_pago"] = 1;
                        Dr["importe_total"] = Convert.ToDecimal(Dr["importe_saldo"].ToString());
                        Dr["importe_saldo"] = Convert.ToDecimal(Dr["importe_saldo"].ToString()) - Convert.ToDecimal(Dr["importe_bonificacion"].ToString());
                    }
                    Percepciones.CalcularPercepcionesEnDtFinal(dtCtaCteDetfinal, modificarImportesPagos: false);

                    dtSalidasCae.Clear();
                    dtSalidasCae = oFacturacion.Comprobante_a_Factura(oFacturacion, dtCtaCteDetfinal, idLocacion, Personal.Id_Punto_Venta, permitirHacerRemito: false, facturaDeCredito: false);
                    codigoRetorno = Convert.ToInt16(dtSalidasCae.Rows[dtSalidasCae.Rows.Count - 1]["respuesta_codigo"]);

                    if (codigoRetorno != 0)
                    {
                        DataRow dr = dtResultados.NewRow();
                        dr["idComprobante"] = idComprobante;
                        dr["idError"] = codigoRetorno;
                        dr["usuario"] = item["usuario"].ToString();
                        dr["descripcion"] = item["descripcion"].ToString();
                        dr["importe_original"] = Convert.ToDecimal(item["importe_original"]);
                        dr["importe_bonificacion"] = Convert.ToDecimal(item["importe_bonificacion"]);
                        dr["importe_final"] = Convert.ToDecimal(item["importe_final"]);
                        mensajeSalida = dtSalidasCae.Rows[0]["respuesta_descripcion"].ToString();
                        dr["mensaje"] = mensajeSalida;
                        dtResultados.Rows.Add(dr);
                        oColor = Color.LightCoral;
                    }
                    else
                    {
                        mensajeSalida = "APROBADO";
                        oColor = Color.PaleGreen;
                    }
                }
                catch (Exception C)
                {
                    DataRow dr = dtResultados.NewRow();
                    dr["idComprobante"] = idComprobante;
                    dr["idError"] = codigoRetorno;
                    dr["usuario"] = item["usuario"].ToString();
                    dr["descripcion"] = item["descripcion"].ToString();
                    dr["importe_original"] = Convert.ToDecimal(item["importe_original"]);
                    dr["importe_bonificacion"] = Convert.ToDecimal(item["importe_bonificacion"]);
                    dr["importe_final"] = Convert.ToDecimal(item["importe_final"]);
                    mensajeSalida = C.Message;
                    dr["mensaje"] = "error";
                    dtResultados.Rows.Add(dr);
                    oColor = Color.LightCoral;
                }


                tarea.ReportProgress(contador, dtComprobantesFiltrados.Rows.Count);
                contador++;
            }
        }


        private void btnFacturacion_Click(object sender, EventArgs e)
        {
            if((dtComprobantes.DefaultView.Count>0 || dtComprobantes.Rows.Count > 0) && MessageBox.Show("Esta por comenzar convertir los comprobantes de deuda a factura. ¿Desea continuar?","Mensaje del Sistema",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
            {
                if (unitario == 0)
                {
                    if (dtComprobantes.Rows.Count > 0)
                    {
                        decimal totalAux = 0;
                        int cantidad = dtComprobantes.Rows.Count;
                        totalFacturar = spHasta.Value;
                        DataTable dtAux = dtComprobantes.Clone();
                        if (spHasta.Value != Convert.ToDecimal(spHasta.Tag))
                        {
                            foreach (DataRow item in dtComprobantes.Rows)
                            {
                
                                if (totalAux < spHasta.Value)
                                {
                                    dtAux.ImportRow(item);
                                    dtAux.AcceptChanges();
                                    totalAux += Convert.ToDecimal(Convert.ToDecimal(item["importe_final"]));
                                }
                            }
                            dtComprobantes = dtAux.Copy();
                        }
                        pgBar.Maximum = dtComprobantes.Rows.Count;
                        imgReturn.Enabled = false;
                        this.KeyPreview = false;
                        Cursor = Cursors.WaitCursor;
                        btnFacturacion.Enabled = false;
                        tarea.DoWork += GenerarFacturas;
                        tarea.RunWorkerCompleted += Terminado;
                        tarea.RunWorkerAsync();
                    }
                }
                else
                {
                    int idUsuario = Convert.ToInt32(dgvServiciosAFacturar.SelectedRows[0].Cells["id_usuarios"].Value);
                    int idComprobante = Convert.ToInt32(dgvServiciosAFacturar.SelectedRows[0].Cells["idComprobantes"].Value);
                    int idLocacion = 0;
                    dtLocaciones.Clear();
                    dtLocaciones = oUsuLoc.ListarLocacionesServicio(idUsuario);
                    idLocacion = Convert.ToInt32(dtLocaciones.Rows[0]["id"]);
                    Usuarios.CurrentUsuario.Id = idUsuario;
                    Usuarios.Current_IdUsuario = idUsuario;
                    Usuarios oUsu = new Usuarios();
                    oUsu.LlenarObjeto(idUsuario);
                    DataTable dtCtaCteDetfinal = oUsuarioCtaCte.LlenarDtModelo(dtLocaciones, "C", idComprobante);
                    foreach (DataRow Dr in dtCtaCteDetfinal.Rows)
                    {
                        Dr["importe_pago"] = 1;
                        Dr["importe_total"] = Convert.ToDecimal(Dr["importe_saldo"].ToString());
                        Dr["importe_saldo"] = Convert.ToDecimal(Dr["importe_saldo"].ToString()) - Convert.ToDecimal(Dr["importe_bonificacion"].ToString());
                
                    }
                    codigoRetorno = Convert.ToInt16(oFacturacion.Comprobante_a_Factura(oFacturacion, dtCtaCteDetfinal, idLocacion, Personal.Id_Punto_Venta, permitirHacerRemito: false, facturaDeCredito: false).Rows[0]["respuesta_codigo"]);
                    if (codigoRetorno != 0)
                    {
                        dtResultados.Rows.Add(idComprobante, codigoRetorno);
                        oColor = Color.LightCoral;
                    }
                    else
                        oColor = Color.PaleGreen;
                    dgvServiciosAFacturar.SelectedRows[0].DefaultCellStyle.BackColor = oColor;
                }
            }
         

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
        }

        private void btnVerErrores_Click(object sender, EventArgs e)
        {

            oPop.Formulario = null;
            oPop.pnlPanel = this.pnlErrores;

            if (dtResultados.Rows.Count > 0)
            {
                dgvErrores.DataSource = dtResultados;
                FormatearGrilla(dgvErrores);
                oPop.Maximizar = false;
                oPop.ShowDialog();
            }
        }

        private void FiltrarDebitos()
        {
            facturarDebitos = true;
            dtComprobantesDebitos = dtComprobantes.Copy();
            DataView dv = dtComprobantesDebitos.DefaultView;

            dv.RowFilter = "id_origen=8";
            facturarDebitos = true;
            dtComprobantes = dv.ToTable();

            dgvServiciosAFacturar.DataSource = dtComprobantes;
            FormatearGrilla(dgvServiciosAFacturar);
            CalcularTotales();
            spHasta.Visible = false;
            lblHasta.Visible = false;
        }
        private void lblDebitos_Click(object sender, EventArgs e)
        {
            FiltrarDebitos();

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void lblDebitosColor_Click(object sender, EventArgs e)
        {
            FiltrarDebitos();

        }

        private void dgvErrores_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnSeleccionarFacturacion_Click(object sender, EventArgs e)
        {
            idFacturacionSeleccionada = Convert.ToInt32(cboFacturacion.SelectedValue);
            DataRow rowSelec = (from row in dtFacturaciones.AsEnumerable()
                                where row.Field<int>("id") == idFacturacionSeleccionada
                                select row).ToArray()[0];
            fechaDesdeSeleccionada = Convert.ToDateTime(rowSelec["fecha_desde"]);
            fechaHastaSeleccionada = Convert.ToDateTime(rowSelec["fecha_hasta"]);
            comenzarCarga();
        }

        private void cboFacturacion_SelectionChangeCommitted(object sender, EventArgs e)
        {
            CboFiltro.Enabled = false;
        }

        private void CboFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dtComprobantes == null)
                return;

            this.Cursor = Cursors.WaitCursor;

            string Filtro = "";

            switch (CboFiltro.SelectedIndex)
            {
                case 0:
                    Filtro = $"presentacion = 1 and id_comprobantes_tipo = {(int)Comprobantes_Tipo.Tipo.COMPROBANTE_DEUDA}";
                    break;
                case 1: 
                    Filtro = $"Adhesion_FacDigital = 1 and id_comprobantes_tipo = {(int)Comprobantes_Tipo.Tipo.COMPROBANTE_DEUDA}";
                    break;
                case 2:
                    Filtro = $"id_comprobantes_tipo = {(int)Comprobantes_Tipo.Tipo.REMITO}";
                    break;
                case 3:
                    Filtro = $"id_debito_asociado > 0 and id_comprobantes_tipo = {(int)Comprobantes_Tipo.Tipo.COMPROBANTE_DEUDA}";
                    break;
            }

            dtComprobantes.DefaultView.RowFilter = Filtro;

            CalcularTotales();
            this.Cursor = Cursors.Default;
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {

        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmFacturasElectronicasAdheridos_Load(object sender, EventArgs e)
        {
            comenzarCarga();
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tarea_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pgBar.Value = e.ProgressPercentage;
            porcentajeHecho = (contador * 100) / dtComprobantes.DefaultView.ToTable().Rows.Count;
            lblCuanto.Text = string.Format("Procesando: {0} de {1} ({2} %)", contador, dtComprobantes.DefaultView.ToTable().Rows.Count, porcentajeHecho.ToString());
            pnlProgreso.Visible = true;

            try
            {
                dgvServiciosAFacturar.Rows[contador - 1].DefaultCellStyle.BackColor = oColor;
                dgvServiciosAFacturar.Rows[contador].Selected = true;
                dgvServiciosAFacturar.Rows[contador - 1].Cells["mensaje"].Value = mensajeSalida;
            }
            catch { }
        }

        private void btnCerrarErrores_Click(object sender, EventArgs e)
        {
            pnlErrores.Visible = false;
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            Tools oTools = new Tools();
            oTools.ExportToExcel(dgvErrores, "Comprobantes rechazados afip");
        }

        private void tarea_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            pgBar.Value = pgBar.Maximum;
            lblCuanto.Text = string.Format("Procesando: {0} de {1} ({2} %)", dtComprobantes.DefaultView.ToTable().Rows.Count, dtComprobantes.DefaultView.ToTable().Rows.Count, "100");
            this.Cursor = Cursors.Arrow;
            imgReturn.Enabled = true;
            this.KeyPreview = true;
            dgvServiciosAFacturar.Cursor = Cursors.Arrow;
        }

        private void dgvServiciosAFacturar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (corrioFacturacion == 1)
            {
                if (dgvServiciosAFacturar.SelectedRows[0].DefaultCellStyle.BackColor == Color.LightCoral)
                {
                    btnFacturacion.Enabled = true;
                    btnFacturacion.Text = "Intentar de nuevo";
                    unitario = 1;
                }
                else
                {
                    unitario = 0;
                    btnFacturacion.Enabled = false;
                    btnFacturacion.Text = "Generar facturas";
                }
            }
        }
    }
}