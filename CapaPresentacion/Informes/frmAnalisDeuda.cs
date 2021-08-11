using CapaNegocios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Windows.Forms;

namespace CapaPresentacion.Informes
{
    public partial class frmAnalisDeuda : Form
    {
        #region [PROPIEDADES]
        private delegate void myDel();
        private DataTable dtServicios = new DataTable();
        private DataTable dtDeudas = new DataTable();
        private DataTable dtDeudasDetalles = new DataTable();
        private Informes_Contables oInformesContables = new Informes_Contables();
        private DataTable dtLocalidades = new DataTable();
        private DataTable dtTiposServicios = new DataTable();
        private DataView dvFiltros;
        private String filtroZona, filtroLocalidad, filtroServicio, filtroTipoCtacteDet;
        private Int32 idLocalidadSeleccionada, idLocalidadBuscada, idZonaSeleccionada,
            idZonaBuscada, idServicioSeleccionado, idServicioBuscado;
        private string tipoCtacteDetSeleccionado, tipoCtacteDetBuscado;
        private Double deudaTotal;
        private Servicios oServicios = new Servicios();

        #endregion

        public frmAnalisDeuda()
        {
            InitializeComponent();
        }

        private void frmAnalisDeuda_Load(object sender, EventArgs e)
        {
            comenzarCarga();
        }

        private void comenzarCarga()
        {
            asignarDatos();
        }

        private void asignarDatos()
        {
            cboZonas.DataSource = Tablas.DataZonas;
            cboZonas.ValueMember = "id";
            cboZonas.DisplayMember = "nombre";
            cboZonas.SelectedValue = 0;
            cboZonas.Enabled = false;
            dtLocalidades = new Localidades().ListarLocalidadesConZona();
            dtLocalidades.Rows.Add(0, "TODAS", 0);
            cboLocalidades.DataSource = dtLocalidades;
            cboLocalidades.DisplayMember = "localidad";
            cboLocalidades.ValueMember = "id_localidad";
            cboLocalidades.SelectedValue = 0;
            cboLocalidades.Enabled = false;
            dtTiposServicios = Tablas.DataServicios_Tipos.Copy();
            dtTiposServicios.Rows.Add(0, "TODOS");

            dtServicios = Tablas.DataServicios.Copy();
            List<DataColumn> columnasAEliminar = new List<DataColumn>();
            foreach (DataColumn col in dtServicios.Columns)
            {
                if (col.ColumnName != "id" && col.ColumnName != "descripcion")
                    columnasAEliminar.Add(col);
            }
            foreach (DataColumn col in columnasAEliminar)
            {
                dtServicios.Columns.Remove(col);
            }
            dtServicios.Rows.Add(0, "TODOS");

            cboServicios.DataSource = dtServicios;
            cboServicios.DisplayMember = "descripcion";
            cboServicios.ValueMember = "id";
            cboServicios.SelectedValue = dtServicios.Rows.Count - 1;
            cboServicios.Enabled = false;

            calcularTotales();

            btnBuscar.Enabled = true;
        }

        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int idUsuarioSeleccionado = Convert.ToInt32(dgv.Rows[e.RowIndex].Cells["id_usuario"].Value);
            AbrirConsultaCtaCte(idUsuarioSeleccionado);
        }



        private void calcularTotales()
        {
            deudaTotal = 0;
            if (dgv.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    if (row.Cells["saldocc"].Value != DBNull.Value)
                        this.deudaTotal += Convert.ToDouble(row.Cells["saldocc"].Value);
                }
            }
            lblDeuda.Text = $"Deuda total: {String.Format("{0:0.00}", deudaTotal)}";
        }

        private void btnAbonado_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            dtDeudas = oInformesContables.ListarServiciosDeudas2(dtpFechaDesde.Value);

            dvFiltros = dtDeudas.DefaultView;
            dgv.DataSource = dvFiltros;
            foreach (DataGridViewColumn item in dgv.Columns)
                item.Visible = false;
            foreach (Control item in pnlFiltros.Controls)
                item.Enabled = true;

            dgv.Columns["codigo"].Visible = true;
            dgv.Columns["usuario"].Visible = true;
            dgv.Columns["Zona"].Visible = true;
            dgv.Columns["Localidad"].Visible = true;
            dgv.Columns["calle"].Visible = true;
            dgv.Columns["saldocc"].Visible = true;
            dgv.Columns["telefono1"].Visible = true;
            dgv.Columns["telefono2"].Visible = true;
            dgv.Columns["Correo_Electronico"].Visible = true;
            dgv.Columns["meses_adeudados"].Visible = true;

            dgv.Columns["codigo"].HeaderText = "Codigo";
            dgv.Columns["usuario"].HeaderText = "Usuario";
            dgv.Columns["Zona"].HeaderText = "Zona";
            dgv.Columns["Localidad"].HeaderText = "Localidad";
            dgv.Columns["telefono1"].HeaderText = "Telefono 1";
            dgv.Columns["telefono2"].HeaderText = "Telefono 2";
            dgv.Columns["Correo_Electronico"].HeaderText = "Correo electronico";
            dgv.Columns["saldocc"].HeaderText = "Saldo";
            dgv.Columns["meses_adeudados"].HeaderText = "Periodos";
            dgv.Columns["meses_adeudados"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv.Columns["saldocc"].DefaultCellStyle.Format = "C2";
            dgv.Columns["saldocc"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            cboZonas.SelectedValue = 0;
            cboLocalidades.SelectedValue = 0;
            dvFiltros.RowFilter = "id_debito_asociado=0 and estado_servicio>=0";

            lblInfoDetalle.Visible = true;

            calcularTotales();
            lblTotal.Text = String.Format("Total de Registros: {0}", dgv.Rows.Count);
            this.Cursor = Cursors.Default;
        }

        private void cboZonas_SelectedValueChanged(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            if (dtDeudas.Rows.Count > 0)
            {
                if (cboZonas.SelectedIndex > 0)
                {
                    try
                    {
                        cboLocalidades.DataSource = dtLocalidades.Select($"id_zona = {cboZonas.SelectedValue} or id_localidad = 0").CopyToDataTable();
                        cboLocalidades.SelectedValue = 0;
                    }
                    catch { }
                }
                else
                {
                    cboLocalidades.DataSource = dtLocalidades;
                    cboLocalidades.SelectedValue = 0;
                }

                bool estaba = false;
                try
                {
                    idZonaSeleccionada = Convert.ToInt32(cboZonas.SelectedValue);
                    if (string.IsNullOrEmpty(filtroZona))
                        estaba = false;
                    else
                        estaba = true;
                    if (idZonaSeleccionada > 0)
                    {
                        filtroZona = "id_zona=" + idZonaSeleccionada;
                        if (estaba)
                            dvFiltros.RowFilter = dvFiltros.RowFilter.Replace("id_zona=" + idZonaBuscada, "id_zona=" + idZonaSeleccionada);
                        else
                        {
                            dvFiltros.RowFilter = dvFiltros.RowFilter + " and " + filtroZona;
                        }
                        idZonaBuscada = idZonaSeleccionada;
                    }
                    else
                    {
                        filtroZona = "";
                        if (dvFiltros.RowFilter.Contains("and id_zona"))
                            dvFiltros.RowFilter = dvFiltros.RowFilter.Replace(" and id_zona=" + idZonaBuscada, " ");
                        else
                            dvFiltros.RowFilter = dvFiltros.RowFilter.Replace("id_zona=" + idZonaBuscada, " ");
                    }
                }
                catch (Exception c)
                {
                    throw c;
                }
            }
            calcularTotales();
            lblTotal.Text = String.Format("Total de Registros: {0}", dgv.Rows.Count);
            Cursor = Cursors.Default;
        }

        private void cboLocalidades_SelectedValueChanged(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            if (dtDeudas.Rows.Count > 0)
            {
                bool estaba = false;
                try
                {
                    idLocalidadSeleccionada = Convert.ToInt32(cboLocalidades.SelectedValue);
                    if (string.IsNullOrEmpty(filtroLocalidad))
                        estaba = false;
                    else
                        estaba = true;
                    if (idLocalidadSeleccionada > 0)
                    {
                        filtroLocalidad = "id_localidad=" + idLocalidadSeleccionada;
                        if (estaba)
                            dvFiltros.RowFilter = dvFiltros.RowFilter.Replace("id_localidad=" + idLocalidadBuscada, "id_localidad=" + idLocalidadSeleccionada);
                        else
                        {
                            dvFiltros.RowFilter = dvFiltros.RowFilter + " and " + filtroLocalidad;
                        }
                        idLocalidadBuscada = idLocalidadSeleccionada;
                    }
                    else
                    {
                        filtroLocalidad = "";
                        if (dvFiltros.RowFilter.Contains("and id_localidad"))
                            dvFiltros.RowFilter = dvFiltros.RowFilter.Replace(" and id_localidad=" + idLocalidadBuscada, " ");
                        else
                            dvFiltros.RowFilter = dvFiltros.RowFilter.Replace("id_localidad=" + idLocalidadBuscada, " ");
                    }
                }
                catch (Exception)
                {

                }
            }
            calcularTotales();
            lblTotal.Text = String.Format("Total de Registros: {0}", dgv.Rows.Count);
            Cursor = Cursors.Default;
        }

        private void cboServicios_SelectedValueChanged_1(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            if (dtDeudas.Rows.Count > 0)
            {
                string filtroActual = dvFiltros.RowFilter;
                bool estaba = false;
                try
                {
                    idServicioSeleccionado = Convert.ToInt32(cboServicios.SelectedValue);
                    if (string.IsNullOrEmpty(filtroServicio))
                        estaba = false;
                    else
                        estaba = true;
                    if (idServicioSeleccionado > 0)
                    {
                        filtroServicio = "id_servicios=" + idServicioSeleccionado;
                        if (estaba)
                            dvFiltros.RowFilter = dvFiltros.RowFilter.Replace("id_servicios=" + idServicioBuscado, "id_servicios=" + idServicioSeleccionado);
                        else
                        {
                            dvFiltros.RowFilter = dvFiltros.RowFilter + " and " + filtroServicio;
                        }
                        idServicioBuscado = idServicioSeleccionado;
                    }
                    else
                    {
                        filtroServicio = "";
                        if (dvFiltros.RowFilter.Contains("and id_servicios"))
                            dvFiltros.RowFilter = dvFiltros.RowFilter.Replace(" and id_servicios=" + idServicioBuscado, " ");
                        else
                            dvFiltros.RowFilter = dvFiltros.RowFilter.Replace("id_servicios=" + idServicioBuscado, " ");
                    }
                }
                catch (Exception)
                {

                }
            }
            calcularTotales();
            lblTotal.Text = String.Format("Total de Registros: {0}", dgv.Rows.Count);
            Cursor = Cursors.Default;
        }

        private void CambiarTipoCtacteDet(string tipoCtacteDetSelec = "")
        {
            Cursor = Cursors.WaitCursor;
            if (dtDeudas.Rows.Count > 0)
            {
                string filtroActual = dvFiltros.RowFilter;
                bool estaba = false;
                try
                {
                    tipoCtacteDetSeleccionado = tipoCtacteDetSelec;
                    if (string.IsNullOrEmpty(filtroTipoCtacteDet))
                        estaba = false;
                    else
                        estaba = true;
                    if (!String.IsNullOrEmpty(tipoCtacteDetSeleccionado))
                    {
                        filtroTipoCtacteDet = "tipo_ctacte_det='" + tipoCtacteDetSeleccionado + "'";
                        if (estaba)
                            dvFiltros.RowFilter = dvFiltros.RowFilter.Replace("tipo_ctacte_det='" + tipoCtacteDetBuscado + "'", "tipo_ctacte_det='" + tipoCtacteDetSeleccionado + "'");
                        else
                        {
                            dvFiltros.RowFilter = dvFiltros.RowFilter + " and " + filtroTipoCtacteDet;
                        }
                        tipoCtacteDetBuscado = tipoCtacteDetSeleccionado;
                    }
                    else
                    {
                        filtroTipoCtacteDet = "";
                        if (dvFiltros.RowFilter.Contains("and tipo_ctacte_det"))
                            dvFiltros.RowFilter = dvFiltros.RowFilter.Replace(" and tipo_ctacte_det='" + tipoCtacteDetBuscado + "'", " ");
                        else
                            dvFiltros.RowFilter = dvFiltros.RowFilter.Replace("tipo_ctacte_det='" + tipoCtacteDetBuscado + "'", " ");
                    }
                }
                catch (Exception)
                {

                }
            }
            string filtroActuasl = dvFiltros.RowFilter;
            calcularTotales();
            lblTotal.Text = String.Format("Total de Registros: {0}", dgv.Rows.Count);
            Cursor = Cursors.Default;
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            if (dgv.Rows.Count > 0)
            {
                Tools tools = new Tools();
                this.Cursor = Cursors.WaitCursor;
                try
                {
                    tools.ExportToExcel(dgv, "Deudas usuarios");
                }
                catch (Exception)
                {
                    MessageBox.Show("Error al exportar a excel");
                }
                finally { this.Cursor = Cursors.Default; }
            }
            else
                MessageBox.Show("Grilla vacia");
        }

        private void AbrirConsultaCtaCte(int id_usuario)
        {
            frmPopUp popUp = new frmPopUp();
            popUp.Formulario = new frmUsuariosCtaCteConsultaNuevo(id_usuario, 0);
            popUp.Maximizar = true;
            popUp.ShowDialog();
        }

        private void chkDebitosAsociados_CheckedChanged(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            if (chkDebitosAsociados.Checked)
                dvFiltros.RowFilter = dvFiltros.RowFilter.Replace("id_debito_asociado=0", "id_debito_asociado>=0");
            else
                dvFiltros.RowFilter = dvFiltros.RowFilter.Replace("id_debito_asociado>=0", "id_debito_asociado=0");

            calcularTotales();
            lblTotal.Text = String.Format("Total de Registros: {0}", dgv.Rows.Count);
            Cursor = Cursors.Default;
        }

        private void chkServiciosActivos_CheckedChanged(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            if (chkServiciosActivos.Checked)
                dvFiltros.RowFilter = dvFiltros.RowFilter.Replace("estado_servicio>=0", "estado_servicio>0");
            else
                dvFiltros.RowFilter = dvFiltros.RowFilter.Replace("estado_servicio>0", "estado_servicio>=0");

            calcularTotales();
            lblTotal.Text = String.Format("Total de Registros: {0}", dgv.Rows.Count);
            Cursor = Cursors.Default;
        }

        private void rbs_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            if (rb.Checked)
            {
                if (rbServicios.Checked)
                {
                    CambiarTipoCtacteDet("S");
                }
                else
                {
                    CambiarTipoCtacteDet();
                }
            }
        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAnalisDeuda_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

    }
}
