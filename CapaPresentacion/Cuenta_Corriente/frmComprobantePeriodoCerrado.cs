using CapaNegocios;
using System;
using System.Data;
using System.Threading;
using System.Windows.Forms;

namespace CapaPresentacion.Cuenta_Corriente
{
    public partial class frmComprobantePeriodoCerrado : Form
    {
        int idTarifa, idTipoFacturacion, idServicio, idServicioSub, idModalidad;
        DateTime fechaFactura;
        DataTable dtPaquetes = new DataTable();
        DataTable dtDatosServicio = new DataTable();
        DataView dtvPaquetes;
        Thread hilo;
        delegate void myDel();
        Servicios_Tarifas_Sub_Esp oServiciosTarifasSubEsp = new Servicios_Tarifas_Sub_Esp();
        Servicios oServicios = new Servicios();
        public DataTable dtPaquetesSeleccionados = new DataTable();

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
                dtDatosServicio = oServicios.BuscarDatosServicio(idServicio);
                dtPaquetes = oServiciosTarifasSubEsp.GetServicios_Tarifas_Sub_Esp(idTarifa, idServicio, idServicioSub, idTipoFacturacion);
                myDel MD = new myDel(AsignarDatos);
                this.Invoke(MD, new object[] { });
                pgCircular.Stop();
            }
            catch (Exception e)
            {
                MessageBox.Show("Error: " + e.Message);
            }
        }

        private void AsignarDatos()
        {
            dtvPaquetes = new DataView(dtPaquetes);
            if (idModalidad == Convert.ToInt16(Servicios._Modalidad.PERIODO_CERRADO_POR_MES))
                dtvPaquetes.RowFilter = String.Format("fecha_hasta>'{0}'", fechaFactura.ToString("yyyy-MM-dd"));
            dgvPaquetes.DataSource = null;
            dgvPaquetes.DataSource = dtvPaquetes;
            for (int x = 0; x < dgvPaquetes.ColumnCount; x++)
                dgvPaquetes.Columns[x].Visible = false;
            if (idModalidad == Convert.ToInt16(Servicios._Modalidad.PERIODO_CERRADO_POR_DIA))
            {
                dgvPaquetes.Columns["dias_hasta"].Visible = true;
                dgvPaquetes.Columns["dias_hasta"].HeaderText = "Cantidad de días";
            }
            else
            {
                dgvPaquetes.Columns["fecha_desde"].Visible = true;
                dgvPaquetes.Columns["fecha_hasta"].Visible = true;
                dgvPaquetes.Columns["fecha_desde"].HeaderText = "Desde";
                dgvPaquetes.Columns["fecha_hasta"].HeaderText = "Hasta";
            }
            dgvPaquetes.Columns["importe"].Visible = true;
            dgvPaquetes.Columns["importe"].HeaderText = "Importe";
            dgvPaquetes.Columns["importe"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            lblServicio.Text = String.Format("Servicio: {0}", dtDatosServicio.Rows[0]["Descripcion"]);
            lblModalidadDeServicio.Text = String.Format("Modalidad de servicio: {0}", dtDatosServicio.Rows[0]["Modalidad"]);
        }

        private void AsignarPaqueteSeleccionado()
        {
            if (dgvPaquetes.SelectedRows.Count > 0)
            {
                dtPaquetesSeleccionados.Clear();
                DataRow drPaquete = dtPaquetesSeleccionados.NewRow();
                drPaquete["id_servicio_sub"] = idServicioSub;
                drPaquete["id_tarifa_sub_especial"] = dgvPaquetes.SelectedRows[0].Cells["id"].Value.ToString();
                drPaquete["importe"] = dgvPaquetes.SelectedRows[0].Cells["importe"].Value.ToString();
                if (idModalidad == Convert.ToInt16(Servicios._Modalidad.PERIODO_CERRADO_POR_DIA))
                {
                    if (chkExtender.Enabled == true && chkExtender.Checked)
                        drPaquete["fecha_desde"] = fechaFactura.AddDays(1);
                    else
                        drPaquete["fecha_desde"] = dtpFechaContratacion.Value;
                    drPaquete["fecha_hasta"] = Convert.ToDateTime(drPaquete["fecha_desde"]).AddDays(Convert.ToInt16(dgvPaquetes.SelectedRows[0].Cells["dias_hasta"].Value) - 1);
                }
                else
                {
                    if (DateTime.Compare(Convert.ToDateTime(dgvPaquetes.SelectedRows[0].Cells["fecha_desde"].Value.ToString()), DateTime.Now) >= 0)
                        drPaquete["fecha_desde"] = dgvPaquetes.SelectedRows[0].Cells["fecha_desde"].Value.ToString();
                    else
                        drPaquete["fecha_desde"] = DateTime.Now.ToString();
                    drPaquete["fecha_hasta"] = dgvPaquetes.SelectedRows[0].Cells["fecha_hasta"].Value.ToString();
                }
                dtPaquetesSeleccionados.Rows.Add(drPaquete);
                this.DialogResult = DialogResult.OK;
            }
            else
                MessageBox.Show("No se ha seleccionado un paquete de la grilla.");
        }

        private void chkExtender_CheckedChanged(object sender, EventArgs e)
        {
            if (chkExtender.Checked == false)
            {
                lblContratarFecha.Enabled = true;
                dtpFechaContratacion.Enabled = true;
            }
            else
            {
                lblContratarFecha.Enabled = false;
                dtpFechaContratacion.Enabled = false;
            }
        }

        private void dtpFechaContratacion_ValueChanged(object sender, EventArgs e)
        {
            if (DateTime.Compare(dtpFechaContratacion.Value, fechaFactura) < 0)
            {
                MessageBox.Show("No se puede contratar en fechas inferiores a la última facturación.");
                dtpFechaContratacion.Value = fechaFactura;
            }
        }

        private void btnAsignar_Click(object sender, EventArgs e)
        {
            AsignarPaqueteSeleccionado();
        }

        private void frmComprobantePeriodoCerrado_Load(object sender, EventArgs e)
        {
            dtPaquetesSeleccionados.Columns.Add("id_servicio_sub", typeof(string));
            dtPaquetesSeleccionados.Columns.Add("id_tarifa_sub_especial", typeof(string));
            dtPaquetesSeleccionados.Columns.Add("fecha_desde", typeof(string));
            dtPaquetesSeleccionados.Columns.Add("fecha_hasta", typeof(string));
            dtPaquetesSeleccionados.Columns.Add("importe", typeof(string));

            if (idModalidad == Convert.ToInt16(Servicios._Modalidad.PERIODO_CERRADO_POR_DIA))
            {
                chkExtender.Visible = true;
                lblContratarFecha.Visible = true;
                dtpFechaContratacion.Visible = true;
                chkExtender.Checked = true;
            }
            else
            {
                chkExtender.Visible = false;
                lblContratarFecha.Visible = false;
                dtpFechaContratacion.Visible = false;
            }
            try
            {
                dtpFechaContratacion.Value = fechaFactura;
            }
            catch { }
            ComenzarCarga();
        }

        public frmComprobantePeriodoCerrado(int idTarifa, int idTipoFacturacion, int idServicio, int idServicioSub, int idModalidad, DateTime fechaFactura)
        {
            this.idTarifa = idTarifa;
            this.idTipoFacturacion = idTipoFacturacion;
            this.idServicio = idServicio;
            this.idServicioSub = idServicioSub;
            this.idModalidad = idModalidad;
            this.fechaFactura = fechaFactura;
            InitializeComponent();
        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}//081019-22:45 fede
