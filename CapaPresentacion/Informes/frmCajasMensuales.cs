using CapaNegocios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Windows.Forms;
using System.ComponentModel;

namespace CapaPresentacion.Informes
{
    public partial class frmCajasMensuales : Form
    {
        private InformeCajasMensual oInforme = new InformeCajasMensual();
        private Thread hilo;
        private delegate void myDel();
        private static List<int> serviciosSeleccionados = new List<int>();
        private Caja_general oCajaGeneral = new Caja_general();
        private DataTable dtCajas = new DataTable();
        private DataTable dtBase = new DataTable();
        private DataTable dtInformes = new DataTable();
        private bool prepago = false;
        private int idInformeSeleccionado, contador = 0;
        private int cuenta;
        int idCajaDesde = 0;
        int idCajaHasta = 0;
        string servicios = "";

        private DataTable filtro;
        private string punto;
        private InformeCajasMensual.TipoInforme tipo;
        public frmCajasMensuales()
        {
            InitializeComponent();
        }
        #region Metodos

        private void comenzarCarga()
        {

            hilo = new Thread(new ThreadStart(cargarDatos));
            hilo.Start();
        }

        private void cargarDatos()
        {
            try
            {
                dtInformes = oInforme.ListarInfomes();
                dtCajas = oCajaGeneral.Listar();
                myDel MD = new myDel(asignarDatos);
                this.Invoke(MD, new object[] { });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar Informacion" + ex.Message);
            }
        }

        private void asignarDatos()
        {
            dtCajas.Columns.Add("FullName",typeof(string),"id + ' ' + fecha");
            cboDesde.DataSource = dtCajas;
            cboDesde.DisplayMember = "FullName";
            cboDesde.ValueMember = "id";

            cboHasta.DataSource = dtCajas.Copy();
            cboHasta.DisplayMember = "FullName";
            cboHasta.ValueMember = "id";

            cboInformes.DataSource = dtInformes;
            cboInformes.DisplayMember = "nombre";
            cboInformes.ValueMember = "id";

            cboCuenta.SelectedIndex = 0;
        }
        
        #endregion


        private void frmCajasMensuales_Load(object sender, EventArgs e)
        {
            comenzarCarga();
        }

        private void btnSelecServicios_Click(object sender, EventArgs e)
        {

        }
        private void BuscarImportes(object o, DoWorkEventArgs e)
        {

            DataTable dtAux;
           
            decimal importeConexion = 0;
            decimal importeAtrasado = 0;
            decimal importeMensual = 0;
            decimal importeAdelantado = 0;
            decimal importePunitorios = 0;
            decimal importePDP = 0;
            decimal importePreConexion = 0;
            decimal importePreRecarga = 0;
            decimal importeGeneral = 0;
            int idpunto = 0;
            foreach (int item in serviciosSeleccionados)
                servicios = servicios + item.ToString() + ",";
            servicios = servicios.Remove(servicios.Length - 1);

            try
            {
                foreach (DataRow item in dtBase.Rows)
                {
                    idpunto = Convert.ToInt32(item["id"]);
                    switch (tipo)
                    {
                        
                        case InformeCajasMensual.TipoInforme.PERIODO: //12*9 y todos los por periodos
                            importeGeneral = 0;
                            dtAux = oInforme.ListarEspecial(idpunto, idCajaDesde, idCajaHasta, servicios, cuenta,false);
                            if (dtAux.Rows.Count > 0)
                                importeGeneral = Convert.ToDecimal(dtAux.Rows[0]["importe"]);
                            item["Importe"] = importeGeneral;
                            break;

                        case InformeCajasMensual.TipoInforme.PLAN_VERANO: //PLAN VERANO CERRADO, PLAN VERANO CERRADO POR DIA, PLAN VERANO POR DIA
                            importeGeneral = 0;
                            dtAux = oInforme.ListarEspecial(idpunto, idCajaDesde, idCajaHasta, servicios, cuenta,false);
                            if (dtAux.Rows.Count > 0)
                                importeGeneral = Convert.ToDecimal(dtAux.Rows[0]["importe"]);
                            item["Importe"] = importeGeneral;
                            break;

                        case InformeCajasMensual.TipoInforme.SERVICIOS_NO_TIC: //PLAN VERANO CERRADO, PLAN VERANO CERRADO POR DIA, PLAN VERANO POR DIA
                            importeGeneral = 0;
                            dtAux = oInforme.ListarEspecial(idpunto, idCajaDesde, idCajaHasta, servicios, cuenta,false);
                            if (dtAux.Rows.Count > 0)
                                importeGeneral = Convert.ToDecimal(dtAux.Rows[0]["importe"]);
                            item["Importe"] = importeGeneral;
                            break;

                        default:
                            importeConexion = 0;
                            dtAux = oInforme.ListarConexiones(idpunto, idCajaDesde, idCajaHasta, servicios, cuenta,false);
                            if (dtAux.Rows.Count > 0)
                                importeConexion = Convert.ToDecimal(dtAux.Rows[0]["importe_conexiones"]);
                            item["conexion"] = importeConexion;
                            importeAtrasado = 0;
                            dtAux = oInforme.ListarMovimientos(idpunto, idCajaDesde, idCajaHasta, servicios, "atrasado", cuenta,false);
                            if (dtAux.Rows.Count > 0)
                                importeAtrasado = Convert.ToDecimal(dtAux.Rows[0]["importe"]);
                            item["atrasado"] = importeAtrasado;

                            importeMensual = 0;
                            dtAux = oInforme.ListarMovimientos(idpunto, idCajaDesde, idCajaHasta, servicios, "mensual", cuenta,false);
                            if (dtAux.Rows.Count > 0)
                                importeMensual = Convert.ToDecimal(dtAux.Rows[0]["importe"]);
                            item["mensual"] = importeMensual;

                            importeAdelantado = 0;
                            dtAux = oInforme.ListarMovimientos(idpunto, idCajaDesde, idCajaHasta, servicios, "adelantado", cuenta, false);
                            if (dtAux.Rows.Count > 0)
                                importeAdelantado = Convert.ToDecimal(dtAux.Rows[0]["importe"]);
                            item["adelantado"] = importeAdelantado;

                            importePunitorios = 0;
                            dtAux = oInforme.ListarPunitorios(idpunto, idCajaDesde, idCajaHasta, servicios, cuenta,false);
                            if (dtAux.Rows.Count > 0)
                                importePunitorios = Convert.ToDecimal(dtAux.Rows[0]["Importe_Punitorio"]);
                            item["punitorio"] = importePunitorios;

                            importePDP = 0;
                            dtAux = oInforme.ListarPlanesDePago(idpunto, idCajaDesde, idCajaHasta, servicios, cuenta,false);
                            if (dtAux.Rows.Count > 0)
                                importePDP = Convert.ToDecimal(dtAux.Rows[0]["Importe_planes"]);
                            item["plan_de_pago"] = importePDP;

                            importePDP = 0;
                            dtAux = oInforme.ListarMovimientosEspeciales(idpunto, idCajaDesde, idCajaHasta, servicios, cuenta,false);
                            if (dtAux.Rows.Count > 0)
                                importePDP = Convert.ToDecimal(dtAux.Rows[0]["Importe_especiales"]);
                            item["especiales"] = importePDP;

                            if (Convert.ToBoolean(filtro.Rows[0]["prepagos"]))
                            {
                                importePreConexion = 0;
                                dtAux = oInforme.ListarPrepagosConexiones(idpunto, idCajaDesde, idCajaHasta, servicios, cuenta,false);
                                if (dtAux.Rows.Count > 0)
                                    importePreConexion = Convert.ToDecimal(dtAux.Rows[0]["Importe_prepago"]);
                                item["Conexion_pre"] = importePreConexion;

                                importePreRecarga = 0;
                                dtAux = oInforme.ListarPrepagosRecargas(idpunto, idCajaDesde, idCajaHasta, servicios, cuenta,false);
                                if (dtAux.Rows.Count > 0)
                                    importePreRecarga = Convert.ToDecimal(dtAux.Rows[0]["importe_prepago_recarga"]);
                                item["Recarga_pre"] = importePreRecarga;
                            }
                            break;
                    }
                    
                    contador++;
                    punto = item["descripcion"].ToString();
                    bgwWorker.ReportProgress(contador, dtBase.Rows.Count);
                }

            }
            catch (Exception c)
            {
                MessageBox.Show("Error: " + c.ToString(), "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
            dtBase.AcceptChanges();
        }
        private void Terminado(object o, RunWorkerCompletedEventArgs e)
        {
            decimal totalImporteConexion = 0;
            decimal totalImporteAtrasado = 0;
            decimal totalImporteMensual = 0;
            decimal totalImporteAdelantado = 0;
            decimal totalImportePunitorios = 0;
            decimal totalImportePDP = 0;
            decimal totalImporteEspeciales = 0;
            decimal totalImporteConPrepago = 0;
            decimal totalImporteRecargaPrepago = 0;
            decimal totalImporteGeneral = 0;

            foreach (DataRow item in dtBase.Rows)
            {
                if(tipo == InformeCajasMensual.TipoInforme.CABLE 
                    || tipo == InformeCajasMensual.TipoInforme.INTERNET 
                    || tipo == InformeCajasMensual.TipoInforme.CODIFICADO
                    || tipo == InformeCajasMensual.TipoInforme.MMDS)
                {
                    totalImporteConexion = totalImporteConexion + Convert.ToDecimal(item["conexion"]);
                    totalImporteAtrasado = totalImporteAtrasado + Convert.ToDecimal(item["atrasado"]);
                    totalImporteMensual = totalImporteMensual + Convert.ToDecimal(item["mensual"]);
                    totalImporteAdelantado = totalImporteAdelantado + Convert.ToDecimal(item["adelantado"]);
                    totalImportePunitorios = totalImportePunitorios + Convert.ToDecimal(item["punitorio"]);
                    totalImportePDP = totalImportePDP + Convert.ToDecimal(item["plan_de_pago"]);
                    totalImporteEspeciales = totalImporteEspeciales + Convert.ToDecimal(item["especiales"]);
                    if (prepago)
                    {
                        totalImporteConPrepago = totalImporteConPrepago + Convert.ToDecimal(item["Conexion_pre"]);
                        totalImporteRecargaPrepago = totalImporteRecargaPrepago + Convert.ToDecimal(item["recarga_pre"]);
                    }
                }
                else
                {
                    if (tipo == InformeCajasMensual.TipoInforme.PERIODO
                        || tipo == InformeCajasMensual.TipoInforme.PLAN_VERANO
                        || tipo == InformeCajasMensual.TipoInforme.SERVICIOS_NO_TIC)
                    {
                        totalImporteGeneral = totalImporteGeneral + Convert.ToDecimal(item["importe"]);

                    }
                }

            }
            dtBase.Rows.Add();
            DataRow drTotales = dtBase.NewRow();
            if (tipo == InformeCajasMensual.TipoInforme.CABLE
                    || tipo == InformeCajasMensual.TipoInforme.INTERNET
                    || tipo == InformeCajasMensual.TipoInforme.CODIFICADO
                    || tipo == InformeCajasMensual.TipoInforme.MMDS)
            {
                drTotales["descripcion"] = "TOTALES";
                drTotales["conexion"] = totalImporteConexion;
                drTotales["atrasado"] = totalImporteAtrasado;
                drTotales["mensual"] = totalImporteMensual;
                drTotales["adelantado"] = totalImporteAdelantado;
                drTotales["punitorio"] = totalImportePunitorios;
                drTotales["plan_de_pago"] = totalImportePDP;
                drTotales["especiales"] = totalImporteEspeciales;
                if (prepago)
                {
                    drTotales["Conexion_pre"] = totalImporteConPrepago;
                    drTotales["recarga_pre"] = totalImporteRecargaPrepago;
                }
            }
            else
            {
                if (tipo == InformeCajasMensual.TipoInforme.PERIODO)
                {
                    drTotales["descripcion"] = "TOTALES";
                    drTotales["importe"] = totalImporteGeneral;
                }
                if (tipo == InformeCajasMensual.TipoInforme.PLAN_VERANO)
                {
                    drTotales["descripcion"] = "TOTALES";
                    drTotales["plan_verano"] = totalImporteGeneral;
                }
            }
           if(dtBase.Rows.Count<13)
            dtBase.Rows.Add(drTotales);
            dtBase.AcceptChanges();
            dgvInforme.DataSource = dtBase;
            cboInformes.SelectedValue = idInformeSeleccionado;
            pnlEstado.Visible = false;
            Cursor = Cursors.Default;
            contador = 0;
            btnBuscar.Enabled = true;
            pgCircular.Stop();
        }

        private void boton2_Click(object sender, EventArgs e)
        {
            Tools oTools = new Tools();
            oTools.ExportDataTableToExcel(dtBase, "Informe");
        }

        private void bgwWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pgProgreso.Value = e.ProgressPercentage;
            lblEstado2.Text =  $"Puntos de venta  ({contador}/{dtBase.Rows.Count}) {punto}";
        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void flyHead_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lnkConfig_Click(object sender, EventArgs e)
        {
            
        }

        private void lnkConfig_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmPopUp oPop = new frmPopUp();
            Abms.ABMInformeServicioRelacion oFrmRelaciones = new Abms.ABMInformeServicioRelacion();
            oPop.Formulario = oFrmRelaciones;
            if (oPop.ShowDialog() == DialogResult.OK)
            {
                comenzarCarga();
            }
        }

        private void dgvInforme_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int idPunto = Convert.ToInt32(dgvInforme.SelectedRows[0].Cells["id"].Value);
                DataTable dtDetalles = new DataTable();
                foreach (Control item in this.Controls)
                    item.Enabled = false;
                this.Cursor = Cursors.WaitCursor;
                if(dgvInforme.Columns[e.ColumnIndex].Name== "Conexion")
                {
                    dtDetalles = oInforme.ListarConexiones(idPunto, idCajaDesde, idCajaHasta, servicios, cuenta, true);
                }

                if (dgvInforme.Columns[e.ColumnIndex].Name == "Atrasado")
                {
                    dtDetalles = oInforme.ListarMovimientos(idPunto, idCajaDesde, idCajaHasta, servicios,"atrasado", cuenta, true);
                }

                if (dgvInforme.Columns[e.ColumnIndex].Name == "Mensual")
                {
                    dtDetalles = oInforme.ListarMovimientos(idPunto, idCajaDesde, idCajaHasta, servicios,"mensual", cuenta, true);
                }

                if (dgvInforme.Columns[e.ColumnIndex].Name == "Adelantado")
                {
                    dtDetalles = oInforme.ListarMovimientos(idPunto, idCajaDesde, idCajaHasta, servicios, "adelantado", cuenta, true);
                }

                if (dgvInforme.Columns[e.ColumnIndex].Name == "Punitorio")
                {
                    dtDetalles = oInforme.ListarPunitorios(idPunto, idCajaDesde, idCajaHasta, servicios, cuenta, true);
                }

                if (dgvInforme.Columns[e.ColumnIndex].Name == "Plan_de_pago")
                {
                    dtDetalles = oInforme.ListarPlanesDePago(idPunto, idCajaDesde, idCajaHasta, servicios, cuenta, true);
                }

                if (dgvInforme.Columns[e.ColumnIndex].Name == "Especiales")
                {
                    dtDetalles = oInforme.ListarEspecial(idPunto, idCajaDesde, idCajaHasta, servicios, cuenta, true);
                }

                if (prepago)
                {
                    if (dgvInforme.Columns[e.ColumnIndex].Name == "Conexion_pre")
                    {
                        dtDetalles = oInforme.ListarPrepagosConexiones(idPunto, idCajaDesde, idCajaHasta, servicios, cuenta, true);
                    }

                    if (dgvInforme.Columns[e.ColumnIndex].Name == "Recarga_pre")
                    {
                        dtDetalles = oInforme.ListarPrepagosRecargas(idPunto, idCajaDesde, idCajaHasta, servicios, cuenta, true);
                    }
                }


                foreach (Control item in this.Controls)
                    item.Enabled = true;
                this.Cursor = Cursors.Arrow;

                if (dtDetalles.Rows.Count > 0)
                {
                    frmCajasMensualesDetalle oFrm = new frmCajasMensualesDetalle();
                    oFrm.dtDetalles = dtDetalles;
                    frmPopUp oPop = new frmPopUp();
                    oPop.Formulario = oFrm;
                    oPop.ShowDialog();
                }
            }
            catch (Exception x)
            {
                MessageBox.Show("Hubo un error: " + x.ToString(), "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void boton1_Click(object sender, EventArgs e)
        {

            pgCircular.Start();
            dgvInforme.DataSource = null;
            dtBase.Rows.Clear();
            dtBase.Columns.Clear();
            idInformeSeleccionado = Convert.ToInt32(cboInformes.SelectedValue);
            DataView dv = dtInformes.DefaultView;
            dv.RowFilter = $"id = {idInformeSeleccionado}";
            filtro = dv.ToTable();
            prepago = Convert.ToBoolean(filtro.Rows[0]["prepagos"]);
            tipo = (InformeCajasMensual.TipoInforme)idInformeSeleccionado;
            dtBase = oInforme.GenerarEstructura(prepago,tipo);
            pgProgreso.Maximum = dtBase.Rows.Count;
            pgProgreso.Minimum = 0;
            try
            {
                idCajaDesde = Convert.ToInt32(cboDesde.SelectedValue);
                idCajaHasta = Convert.ToInt32(cboHasta.SelectedValue);
                cuenta = Convert.ToInt32(cboCuenta.Text);
                serviciosSeleccionados = oInforme.ListarServiciosInforme(Convert.ToInt32(cboInformes.SelectedValue));
                if(serviciosSeleccionados.Count>0)
                {
                    pnlEstado.Visible = true;
                    idInformeSeleccionado = Convert.ToInt32(cboInformes.SelectedValue);
                    Cursor = Cursors.WaitCursor;
                    btnBuscar.Enabled = false;
                    bgwWorker.DoWork += BuscarImportes;
                    bgwWorker.RunWorkerCompleted += Terminado;
                    bgwWorker.RunWorkerAsync();
                }
                else
                {
                    MessageBox.Show("No se encontraron servicios relacionados al informe seleccionado", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Exception c)
            {
                MessageBox.Show(c.ToString());
            }
        }
    }
}
