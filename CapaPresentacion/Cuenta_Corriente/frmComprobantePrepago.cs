using CapaNegocios;
using System;
using System.Data;
using System.Threading;
using System.Windows.Forms;

namespace CapaPresentacion
{

    public partial class frmComprobantePrepago : Form
    {
        #region Declaraciones 

        private Servicios_Tarifas_Sub oTarifasSub = new Servicios_Tarifas_Sub();
        private Servicios_Tarifas oServiciosTarifas = new Servicios_Tarifas();

        private Thread hilo;
        private delegate void myDel();
        private Int32 idTarifaActual = 0;
        private Int32 idServicio, idTipoFacturacion, idSub;
        private String nombreServicio;
        private DateTime fechaFactura = new DateTime();
        private DataTable dtSub = new DataTable();
        private DataTable dtDatosServicio = new DataTable();
        private DataTable dtDatosUsuarioServicioSub = new DataTable();
        private Servicios_Sub oServiciosSub = new Servicios_Sub();
        private Servicios oServicio = new Servicios();
        private Usuarios_Servicios oUsuarioServicio = new Usuarios_Servicios();
        private Servicios_Velocidades oServicioVelocidad = new Servicios_Velocidades();
        public DateTime fechaDesdeFinal = new DateTime();
        public DateTime fechaHastaFinal = new DateTime();
        public Decimal importeFinal = 0;
        public Int32 verTarifas;
        public Int32 idUsuarioServicio = 0, idVelocidad = 0, idVelocidadTipo = 0, cantDiasFinal = 0;
        public String nombreVelocidad = "", nombreVelocidadTipo = "", requiereVelocidad = "";
        public Boolean notificacion = false;
        private DataTable dtDatosUsuarioServicio = new DataTable();
        public bool generarNotificacionCorte = false;
        //las variables a continuación son utilizadas para posicionarse en uno u otro monto dependiendo de la cantidad de días contratada la última vez.
        private int cantDiasAnteriores = 0;
        public int gestionarMontos = 0;
        private DateTime fechaFacturaDesde = new DateTime();
        //-------------------------------------------
        #endregion

        #region Métodos creados

        private void ComenzarCarga()
        {
            hilo = new Thread(new ThreadStart(CargarDatos));
            hilo.IsBackground = true;
            hilo.Start();
        }

        private void CargarDatos()
        {
            try
            {
                dtDatosServicio = oServicio.BuscarDatosServicio(idServicio);
                if (this.verTarifas == 1)
                {
                    dtDatosUsuarioServicioSub = oUsuarioServicio.ListarServiciosSub(idUsuarioServicio);
                    dtDatosUsuarioServicio = oUsuarioServicio.Traer_datos_usuarios_servicios(idUsuarioServicio);
                }
                idSub = Convert.ToInt32(dtDatosUsuarioServicioSub.Rows[0]["id_servicios_sub"]);

                dtSub = oTarifasSub.Listar(idServicio, idTipoFacturacion, idSub);
                myDel MD = new myDel(AsignarDatos);
                this.Invoke(MD, new object[] { });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar Informacion" + ex.Message);
            }
        }

        private void AsignarDatos()
        {


            requiereVelocidad = dtDatosServicio.Rows[0]["Requiere_Velocidad"].ToString();
            DataView dv = dtSub.DefaultView;
            if (requiereVelocidad == "SI" && verTarifas == 1)
            {
                Int32 idVelocidadActual = Convert.ToInt32(dtDatosUsuarioServicioSub.Rows[0]["Id_Servicios_Velocidades"]);
                Int32 idTipoVelocidadActual = Convert.ToInt32(dtDatosUsuarioServicioSub.Rows[0]["Id_Servicios_Velocidades_Tip"]);
                DataTable dtDatosVel = oServicioVelocidad.ListarDatosVelocidades(idVelocidadActual, idTipoVelocidadActual);
                lblServicio.Text = nombreServicio + " " + dtDatosVel.Rows[0]["velocidad"].ToString() + " " + dtDatosVel.Rows[0]["nombre"].ToString();
                dv.RowFilter = string.Format("id_servicios_velocidad={0} and id_servicio_velocidad_tip={1}", idVelocidadActual, idTipoVelocidadActual);
            }
            else
            {
                dv.RowFilter = string.Format("idtipodesub>0");

                lblServicio.Text = nombreServicio;

            }
            if (verTarifas == 0)
            {
                chkPosdatado.Visible = false;
                btnGuardar.Visible = false;
                LbTitulos.Text = "Tarifas";

            }
            dgvSub.Enabled = true;

            if (dv.Count > 0)
            {
                int max = 0;
                foreach (DataRow fila in dv.ToTable().Rows)
                {
                    if (Convert.ToInt32(fila["dias_hasta"]) > max)
                        max = Convert.ToInt32(fila["dias_hasta"]);
                }
                if (max > 1000)
                    spCantDias.Maximum = max;
                else
                    spCantDias.Maximum = 1000;
            }
            else
                spCantDias.Maximum = 1000;


            dgvSub.DataSource = dv;
            FormatearGrilla();
            if (DateTime.Compare(fechaFactura, DateTime.Now) < 0)
            {
                dtpDesde.MinDate = DateTime.Now;
                dtpDesde.Value = DateTime.Now;
            }
            else
            {
                dtpDesde.MinDate = fechaFactura;
                dtpDesde.Value = fechaFactura;
            }



            dpHasta.Value = dtpDesde.Value.AddDays((int)spCantDias.Minimum);

            if (dtDatosUsuarioServicio.Rows.Count > 0 && verTarifas == 0)
            {
                if (Convert.ToInt32(dtDatosUsuarioServicio.Rows[0]["id_servicios_estados"]) == Convert.ToInt32(Servicios.Servicios_Estados.CORTADO))
                {
                    chkPosdatado.Visible = true;
                    generarNotificacionCorte = false;
                }
                else
                {
                    chkPosdatado.Visible = false;
                    generarNotificacionCorte = true;
                }
            }
        }
        private void FormatearGrilla()
        {
            foreach (DataGridViewColumn item in dgvSub.Columns)
            {
                item.Visible = false;
            }
            dgvSub.Columns["servicio"].Visible = true;
            dgvSub.Columns["servicio"].HeaderText = "Servicio";
            if (requiereVelocidad == "SI")
            {
                dgvSub.Columns["velocidad"].Visible = true;
                dgvSub.Columns["velocidad"].HeaderText = "Velocidad";
                dgvSub.Columns["velocidad"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvSub.Columns["velocidad_tipo"].Visible = true;
                dgvSub.Columns["velocidad_tipo"].HeaderText = "Tipo de Velocidad";
                dgvSub.Columns["velocidad_tipo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            dgvSub.Columns["dias_desde"].Visible = true;
            dgvSub.Columns["dias_desde"].HeaderText = "DESDE";
            dgvSub.Columns["dias_desde"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvSub.Columns["dias_hasta"].Visible = true;
            dgvSub.Columns["dias_hasta"].HeaderText = "HASTA";
            dgvSub.Columns["dias_hasta"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvSub.Columns["importe"].Visible = true;
            dgvSub.Columns["importe"].HeaderText = "Importe";
            dgvSub.Columns["importe"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvSub.Columns["importe"].DefaultCellStyle.Format = "C";

            dgvSub.Columns["porcentaje"].Visible = true;
            dgvSub.Columns["porcentaje"].HeaderText = "%";
            dgvSub.Columns["porcentaje"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;



        }
        private void ActualizarImporte()
        {
            lblDescuentoDato.Text = Convert.ToDecimal(dgvSub.SelectedRows[0].Cells["porcentaje"].Value).ToString();
            Decimal importeFinal = Convert.ToDecimal(dgvSub.SelectedRows[0].Cells["importe"].Value) * Convert.ToInt32(spCantDias.Value);
            lblImporteDato.Text = importeFinal.ToString();
        }
        #endregion

        #region Métodos controles
        public frmComprobantePrepago(Int32 idUsuarioSer, String nombreServicio, Int32 idServicio, Int32 idTipoFacturacion, DateTime fechaFactura)
        {
            InitializeComponent();
            this.idUsuarioServicio = idUsuarioSer;
            this.nombreServicio = nombreServicio;
            this.idServicio = idServicio;
            this.idTipoFacturacion = idTipoFacturacion;
            this.fechaFactura = fechaFactura;
        }

        #endregion

        private void dpHasta_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (dtpDesde.Value < dpHasta.Value)
                {
                    DateTime fechaDesde = dtpDesde.Value;
                    fechaDesde.AddDays(-1);
                    DateTime fechaHasta = dpHasta.Value;
                    TimeSpan diferencia = fechaHasta.Subtract(fechaDesde);
                    Int32 cantDias = diferencia.Days;
                    spCantDias.Value = Convert.ToDecimal(cantDias);

                    foreach (DataGridViewRow item in dgvSub.Rows)
                    {
                        int diasDesde = Convert.ToInt32(item.Cells["dias_desde"].Value);
                        int diasHasta = Convert.ToInt32(item.Cells["dias_hasta"].Value);
                        int cant = diasHasta - diasDesde;
                        if (((cantDias >= diasDesde) && (cantDias <= diasHasta)) || ((cantDias >= diasDesde) && (cantDias > diasHasta)))
                        {
                            item.Selected = true;
                        }
                    }
                    ActualizarImporte();
                }
            }
            catch { }
        }

        private void spCantDias_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                int cantDias = Convert.ToInt32(spCantDias.Value);
                dpHasta.Value = dtpDesde.Value.AddDays(cantDias);
                ActualizarImporte();

            }
            catch { }
        }

        private void txtCantDias_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int cantDias = Convert.ToInt32(spCantDias.Value);
                dpHasta.Value = dtpDesde.Value.AddDays(cantDias);
                ActualizarImporte();

            }
            catch { }
        }

        private void spCantDias_Enter(object sender, EventArgs e)
        {
            try
            {
                int cantDias = Convert.ToInt32(spCantDias.Value);
                dpHasta.Value = dtpDesde.Value.AddDays(cantDias);
                ActualizarImporte();

            }
            catch { }
        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(spCantDias.Value) > 0)
            {
                notificacion = chkPosdatado.Checked;
                fechaDesdeFinal = dtpDesde.Value;
                fechaHastaFinal = dpHasta.Value;
                try
                {
                    importeFinal = Convert.ToDecimal(lblImporteDato.Text);
                    this.DialogResult = DialogResult.OK;
                }
                catch
                {
                    MessageBox.Show("Controle el importe.");
                }

            }
            else
            {
                MessageBox.Show("La cantidad de dias no puede ser inferior a cero", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                spCantDias.Focus();
            }
        }

        private void dtpDesde_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (dtpDesde.Value < fechaFactura)
                {
                    MessageBox.Show("La fecha seleccionada no puede ser menor a la ultima fecha facturada", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    if (DateTime.Compare(fechaFactura, DateTime.Now) < 0)
                        dtpDesde.Value = DateTime.Now;
                    else
                        dtpDesde.Value = fechaFactura;
                }
                dpHasta.MinDate = dtpDesde.Value.AddDays((int)spCantDias.Minimum);

                spCantDias.Value = RetornarCantidadDias(dtpDesde.Value, dpHasta.Value);
            }
            catch { }
        }

        private void dgvSub_SelectionChanged(object sender, EventArgs e)
        {
            if (verTarifas == 0)
            {
                try
                {
                    idVelocidad = Convert.ToInt32(dgvSub.SelectedRows[0].Cells["id_servicios_velocidad"].Value);
                    idVelocidadTipo = Convert.ToInt32(dgvSub.SelectedRows[0].Cells["id_servicio_velocidad_tip"].Value);
                    nombreVelocidad = dgvSub.SelectedRows[0].Cells["velocidad"].Value.ToString();
                    nombreVelocidadTipo = dgvSub.SelectedRows[0].Cells["velocidad_tipo"].Value.ToString();

                }
                catch { }
            }

        }

        private void frmComprobantePrepago_Load(object sender, EventArgs e)
        {
            try
            {
                if (gestionarMontos > 0)
                {
                    fechaFacturaDesde = Convert.ToDateTime(oUsuarioServicio.RetornarFechasDelServicio(idUsuarioServicio).Rows[0]["fecha_factura_desde"]);
                    TimeSpan calculoDias = ((fechaFactura.AddDays(-1)) - fechaFacturaDesde);
                    cantDiasAnteriores = (int)calculoDias.TotalDays;
                    if (cantDiasAnteriores > 0)
                    {
                        lblCantDiasAnteriores.Visible = true;
                        lblCantDiasAnteriores.Text = String.Format("Cant. días de la última contratación: {0}", cantDiasAnteriores);
                    }
                }
            }
            catch { }
            ComenzarCarga();
            oServiciosTarifas.Fecha_Actual = DateTime.Now;
            idTarifaActual = oServiciosTarifas.getTarifa();

        }

        private void frmComprobantePrepago_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private int RetornarCantidadDias(DateTime fechaDesde, DateTime fechaHasta)
        {
            int cantDias = 0;
            TimeSpan calculoDias = (fechaHasta - fechaDesde);
            cantDias = (int)calculoDias.TotalDays;
            return cantDias;
        }
    }
}//111119fede
