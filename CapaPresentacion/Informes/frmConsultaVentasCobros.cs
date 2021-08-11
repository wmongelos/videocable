using CapaNegocios;
using System;
using System.Data;
using System.Threading;
using System.Windows.Forms;

namespace CapaPresentacion.Informes
{
    public partial class frmConsultaVentasCobros : Form
    {
        private Thread hilo;
        private delegate void myDel();
        private Usuarios_CtaCte oUsuariosCtaCte = new Usuarios_CtaCte();
        private DataTable dtDatos = new DataTable();
        private int movimientoSeleccionado, idServicio;
        private DateTime fechaDesde = new DateTime();
        private DateTime fechaHasta = new DateTime();
        private DataTable dtServicios = new DataTable();
        private DataTable dtTotales = new DataTable();

        public frmConsultaVentasCobros()
        {
            InitializeComponent();
        }
        private void ComenzarCarga()
        {
            pgCircular.Start();
            hilo = new Thread(new ThreadStart(CargarDatos));
            hilo.IsBackground = true;
            hilo.Start();
            btnBuscar.Enabled = false;
            btnExportar.Enabled = false;
        }

        private void CargarDatos()
        {
            try
            {
                dtDatos = oUsuariosCtaCte.ListarMovimiento(0, 0, 0, movimientoSeleccionado, fechaDesde, fechaHasta, Usuarios_CtaCte.FECHA_CONSULTA_MOVIMIENTOS_CTACTE.FECHA_MOVIMIENTO);
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
            dtTotales.Clear();
            dtTotales.Columns.Clear();
            dtTotales.Columns.Add("tipo", typeof(string));
            dtTotales.Columns.Add("servicio", typeof(string));
            dtTotales.Columns.Add("total_registros", typeof(Int32));
            dtTotales.Columns.Add("total_original", typeof(decimal));
            dtTotales.Columns.Add("total_bonificado", typeof(decimal));
            dtTotales.Columns.Add("total_punitorio", typeof(decimal));
            dtTotales.Columns.Add("total_final", typeof(decimal));
            dtTotales.Columns.Add("total_provincial", typeof(decimal));
            dtTotales.Columns.Add("total_imputa", typeof(decimal));


            dtServicios = Tablas.DataServicios.Copy();
            DataRow dr = dtServicios.NewRow();
            dr["id"] = 0;
            dr["descripcion"] = "TODOS";
            dtServicios.Rows.Add(dr);
            dtServicios.AcceptChanges();

            cboServicios.DataSource = dtServicios;
            cboServicios.DisplayMember = "Descripcion";
            cboServicios.ValueMember = "id";
            cboServicios.SelectedValue = 0;
            dgvDatos.DataSource = null;
            dgvDatos.DataSource = dtDatos;
            CalcularTotales();
            FormatearGrilla();
            desbloquearControles();
            btnBuscar.Enabled = true;
            btnExportar.Enabled = true;
        }


        private void CalcularTotales()
        {
            try
            {

                dtTotales.Rows.Clear();
                DataRow dr = dtTotales.NewRow();

                decimal total_original = 0;
                decimal total_bonificado = 0;
                decimal total_punitorio = 0;
                decimal total_final = 0;
                decimal total_provincial = 0;
                decimal total_imputa = 0;

                idServicio = Convert.ToInt32(cboServicios.SelectedValue);
                if (idServicio == 0)
                {
                    total_original = Convert.ToDecimal(dtDatos.Compute("SUM(importe_original)", "id_servicios > 0"));
                    total_bonificado = Convert.ToDecimal(dtDatos.Compute("SUM(importe_bonificacion)", "id_servicios > 0"));
                    total_punitorio = Convert.ToDecimal(dtDatos.Compute("SUM(importe_punitorio)", "id_servicios > 0"));
                    total_provincial = Convert.ToDecimal(dtDatos.Compute("SUM(importe_provincial)", "id_servicios > 0"));
                    total_imputa = Convert.ToDecimal(dtDatos.Compute("SUM(importe_imputa)", "id_servicios > 0"));

                }
                else
                {
                    total_original = Convert.ToDecimal(dtDatos.Compute("SUM(importe_original)", string.Format("id_servicios = {0}", idServicio)));
                    total_bonificado = Convert.ToDecimal(dtDatos.Compute("SUM(importe_bonificacion)", string.Format("id_servicios = {0}", idServicio)));
                    total_punitorio = Convert.ToDecimal(dtDatos.Compute("SUM(importe_punitorio)", string.Format("id_servicios = {0}", idServicio)));
                    total_provincial = Convert.ToDecimal(dtDatos.Compute("SUM(importe_provincial)", string.Format("id_servicios = {0}", idServicio)));
                    total_imputa = Convert.ToDecimal(dtDatos.Compute("SUM(importe_imputa)", string.Format("id_servicios = {0}", idServicio)));
                }
                dr["servicio"] = cboServicios.Text;
                dr["tipo"] = cmbTipo.Text;
                dr["total_registros"] = dgvDatos.Rows.Count;
                dr["total_original"] = total_original;
                dr["total_bonificado"] = total_bonificado;
                dr["total_punitorio"] = total_punitorio;
                dr["total_final"] = (total_original - total_bonificado) + total_punitorio;
                dr["total_provincial"] = total_provincial;
                dr["total_imputa"] = total_imputa;
                dtTotales.Rows.Add(dr);
                dgvTotales.DataSource = dtTotales;
                FormatearGrilla();
            }
            catch
            {

            }

        }


        private void FormatearGrillaTotales()
        {
            dgvTotales.Columns["tipo"].HeaderText = "Tipo";
            dgvTotales.Columns["servicio"].HeaderText = "Servicio";
            dgvTotales.Columns["total_registros"].HeaderText = "Total registros";
            dgvTotales.Columns["total_original"].HeaderText = "Total original";
            dgvTotales.Columns["total_bonificado"].HeaderText = "Total bonificado";
            dgvTotales.Columns["total_punitorio"].HeaderText = "Total punitorio";
            dgvTotales.Columns["total_final"].HeaderText = "Total de final";
            dgvTotales.Columns["total_provincial"].HeaderText = "Total provincial";
            dgvTotales.Columns["total_imputa"].HeaderText = "Total imputa";

        }
        private void frmConsultaVentasCobros_Load(object sender, EventArgs e)
        {

            cmbTipo.SelectedIndex = 0;
            movimientoSeleccionado = Convert.ToInt32(cmbTipo.SelectedIndex);
            dtpDesde.Value = DateTime.Now;
            dtpHasta.Value = DateTime.Now;
            fechaDesde = dtpDesde.Value;
            fechaHasta = dtpHasta.Value;
            bloquearControles();
            ComenzarCarga();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            fechaDesde = dtpDesde.Value;
            fechaHasta = dtpHasta.Value;
            if (DateTime.Compare(fechaDesde, fechaHasta) <= 0)
                ComenzarCarga();
            else
                MessageBox.Show("La fecha hasta debe ser mayor que la fecha desde.");
        }
        private void FormatearGrilla()
        {
            for (int x = 0; x < dgvDatos.Columns.Count; x++)
            {
                dgvDatos.Columns[x].Visible = false;

                dgvDatos.Columns[x].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                dgvDatos.Columns[x].Frozen = false;
            }

            dgvDatos.Columns["usuario"].Visible = true;
            dgvDatos.Columns["codigo_usuario"].Visible = true;
            dgvDatos.Columns["localidad"].Visible = true;
            dgvDatos.Columns["calle"].Visible = true;
            dgvDatos.Columns["altura"].Visible = true;
            dgvDatos.Columns["piso"].Visible = true;
            dgvDatos.Columns["depto"].Visible = true;
            dgvDatos.Columns["fecha_movimiento"].Visible = true;
            dgvDatos.Columns["fecha_desde"].Visible = true;
            dgvDatos.Columns["fecha_hasta"].Visible = true;
            dgvDatos.Columns["importe_original"].Visible = true;
            dgvDatos.Columns["importe_original"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvDatos.Columns["importe_original"].DefaultCellStyle.Format = "c";
            dgvDatos.Columns["importe_punitorio"].Visible = true;
            dgvDatos.Columns["importe_punitorio"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvDatos.Columns["importe_punitorio"].DefaultCellStyle.Format = "c";

            dgvDatos.Columns["importe_saldo"].Visible = true;
            dgvDatos.Columns["importe_saldo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvDatos.Columns["importe_saldo"].DefaultCellStyle.Format = "c";

            dgvDatos.Columns["importe_bonificacion"].Visible = true;
            dgvDatos.Columns["importe_bonificacion"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvDatos.Columns["importe_bonificacion"].DefaultCellStyle.Format = "c";
            dgvDatos.Columns["cantidad_periodos"].Visible = true;
            dgvDatos.Columns["subservicio"].Visible = true;
            dgvDatos.Columns["servicio"].Visible = true;
            dgvDatos.Columns["servicio_tipo"].Visible = true;
            dgvDatos.Columns["grupo"].Visible = true;
            dgvDatos.Columns["periodo_mes"].Visible = true;
            dgvDatos.Columns["periodo_ano"].Visible = true;
            dgvDatos.Columns["punto_venta"].Visible = true;
            dgvDatos.Columns["num_comprobante"].Visible = true;
            dgvDatos.Columns["comprobante_tipo_nombre"].Visible = true;
            dgvDatos.Columns["letra"].Visible = true;
            dgvDatos.Columns["codigo_afip"].Visible = true;
            dgvDatos.Columns["tipo_facturacion"].Visible = true;
            dgvDatos.Columns["concepto"].Visible = true;
            dgvDatos.Columns["tipo_sub_servicio"].Visible = true;
            dgvDatos.Columns["velocidad"].Visible = true;
            dgvDatos.Columns["velocidad_tipo"].Visible = true;
            dgvDatos.Columns["nombre_bonificacion"].Visible = true;
            dgvDatos.Columns["porcentaje_bonificacion"].Visible = true;
            dgvDatos.Columns["importe_provincial"].Visible = true;
            dgvDatos.Columns["importe_punitorio"].Visible = true;
            dgvDatos.Columns["importe_imputa"].Visible = true;
            dgvDatos.Columns["importe_provincial"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvDatos.Columns["importe_provincial"].DefaultCellStyle.Format = "c";

            dgvDatos.Columns["usuario"].HeaderText = "Usuario";
            dgvDatos.Columns["codigo_usuario"].HeaderText = "Código de usuario";
            dgvDatos.Columns["localidad"].HeaderText = "Localidad";
            dgvDatos.Columns["calle"].HeaderText = "Calle";
            dgvDatos.Columns["altura"].HeaderText = "Altura";
            dgvDatos.Columns["piso"].HeaderText = "Piso";
            dgvDatos.Columns["depto"].HeaderText = "Depto";
            dgvDatos.Columns["fecha_movimiento"].HeaderText = "Fecha de movimiento";
            dgvDatos.Columns["fecha_desde"].HeaderText = "Desde";
            dgvDatos.Columns["fecha_hasta"].HeaderText = "Hasta";
            dgvDatos.Columns["importe_original"].HeaderText = "Importe original";
            dgvDatos.Columns["importe_punitorio"].HeaderText = "Importe punitorio";
            dgvDatos.Columns["importe_saldo"].HeaderText = "Saldo";
            dgvDatos.Columns["importe_bonificacion"].HeaderText = "Importe de bonificación";
            dgvDatos.Columns["cantidad_periodos"].HeaderText = "Cantidad de periodos";
            dgvDatos.Columns["subservicio"].HeaderText = "Subservicio";
            dgvDatos.Columns["servicio"].HeaderText = "Servicio";
            dgvDatos.Columns["servicio_tipo"].HeaderText = "Tipo de servicio";
            dgvDatos.Columns["grupo"].HeaderText = "Grupo";
            dgvDatos.Columns["periodo_mes"].HeaderText = "Periodo mes";
            dgvDatos.Columns["periodo_ano"].HeaderText = "Periodo año";
            dgvDatos.Columns["punto_venta"].HeaderText = "Punto de venta";
            dgvDatos.Columns["num_comprobante"].HeaderText = "N° de comprobante";
            dgvDatos.Columns["comprobante_tipo_nombre"].HeaderText = "Tipo de comprobante";
            dgvDatos.Columns["letra"].HeaderText = "Letra";
            dgvDatos.Columns["codigo_afip"].HeaderText = "Código AFIP";
            dgvDatos.Columns["tipo_facturacion"].HeaderText = "Tipo de facturación";
            dgvDatos.Columns["concepto"].HeaderText = "Concepto";
            dgvDatos.Columns["tipo_sub_servicio"].HeaderText = "Tipo de subservicio";
            dgvDatos.Columns["velocidad"].HeaderText = "Velocidad";
            dgvDatos.Columns["velocidad_tipo"].HeaderText = "Tipo de velocidad";
            dgvDatos.Columns["nombre_bonificacion"].HeaderText = "Bonificación";
            dgvDatos.Columns["porcentaje_bonificacion"].HeaderText = "Porcentaje de bonificación";
            dgvDatos.Columns["importe_provincial"].HeaderText = "Importe provincial";
            dgvDatos.Columns["importe_imputa"].HeaderText = "Importe imputa";

            for (int x = 0; x < dgvDatos.Columns.Count; x++)
            {
                if (dgvDatos.Columns[x].Name != "importe_original" && dgvDatos.Columns[x].Name != "importe_punitorio" && dgvDatos.Columns[x].Name != "importe_saldo" && dgvDatos.Columns[x].Name != "importe_bonificacion")
                {
                    if (dgvDatos.Columns[x].Name == "fecha_movimiento" || dgvDatos.Columns[x].Name == "fecha_desde" || dgvDatos.Columns[x].Name == "fecha_hasta" || dgvDatos.Columns[x].Name == "cantidad_periodos" || dgvDatos.Columns[x].Name == "periodo_mes" || dgvDatos.Columns[x].Name == "periodo_ano" || dgvDatos.Columns[x].Name == "num_comprobante" || dgvDatos.Columns[x].Name == "letra" || dgvDatos.Columns[x].Name == "codigo_usuario" || dgvDatos.Columns[x].Name == "fecha_desde" || dgvDatos.Columns[x].Name == "calle" || dgvDatos.Columns[x].Name == "altura" || dgvDatos.Columns[x].Name == "piso" || dgvDatos.Columns[x].Name == "depto")
                        dgvDatos.Columns[x].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }

            }
            lblTotal.Text = String.Format("{0}", dgvDatos.Rows.Count);
        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                movimientoSeleccionado = Convert.ToInt32(cmbTipo.SelectedIndex);
            }
            catch
            {
                movimientoSeleccionado = 2;
            }
        }

        private void frmConsultaVentasCobros_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            int Id = 0;
            if (txtBuscar.Text.Length > 0)
            {

                if (Int32.TryParse(txtBuscar.Text, out Id))
                    dtDatos.DefaultView.RowFilter = String.Format("id='" + txtBuscar.Text + "'");
                else
                    dtDatos.DefaultView.RowFilter = String.Format("usuario Like '%" + txtBuscar.Text + "%' or localidad Like '%" + txtBuscar.Text + "%' or calle Like '%" + txtBuscar.Text + "%'  or  subservicio Like '%" + txtBuscar.Text + "%' or servicio Like '%" + txtBuscar.Text + "%' or servicio_tipo Like '%" + txtBuscar.Text + "%' or grupo Like '%" + txtBuscar.Text + "%' or comprobante_tipo_nombre Like '%" + txtBuscar.Text + "%'");

            }
            else
                dtDatos.DefaultView.RowFilter = "id>0";

            CalcularTotales();
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            Tools tools = new Tools();
            tools.ExportToExcel(dgvDatos, "Informe");
            tools.ExportToExcel(dgvTotales, "Totales");
        }
        private void bloquearControles()
        {
            foreach (Control item in this.Controls)
                item.Enabled = false;
            pgCircular.Enabled = true;

        }
        private void desbloquearControles()
        {
            foreach (Control item in this.Controls)
                item.Enabled = true;
        }
        private void cboServicios_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                int idServicio = Convert.ToInt32(cboServicios.SelectedValue);
                if (idServicio == 0)
                    dtDatos.DefaultView.RowFilter = "id_servicios>0";
                else
                    dtDatos.DefaultView.RowFilter = string.Format("id_Servicios={0}", idServicio);


            }
            catch
            {
            }

            CalcularTotales();

        }
    }
}
