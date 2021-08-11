using CapaNegocios;
using System;
using System.Data;
using System.Threading;
using System.Windows.Forms;

namespace CapaPresentacion.Complementarias
{
    public partial class frmAgregarQuitarSub : Form
    {
        public int idServicio, idUsuariosServicios, idTarifaVigente, idTipoFacturacion, idTipoServicio;
        public DataRow[] drEliminados = null;
        public DataRow[] drAgregados = null;
        public DateTime fechaDesde;
        public DateTime fechaHasta;
        public DateTime fechaFactura;
        private int requiereIpAux, idSubAux, propio;
        public int idModalidad;
        public string requierVelocidad;
        private string nombreSubAux;
        private decimal importeAux;

        private DataTable dtSubServiciosDisponibles = new DataTable();
        private DataTable dtSubServiciosActuales = new DataTable();
        private DataTable dtSubDisponiblesFinal = new DataTable();
        private DataTable dtSubActuaesFinal = new DataTable();
        private DataTable datosSubServicio = new DataTable();
        private DataTable dtAgregdos = new DataTable();
        private DataTable dtEliminados = new DataTable();
        private Thread hilo;
        private delegate void myDel();
        private Servicios_Sub oServicios = new Servicios_Sub();
        private Usuarios_Servicios oUsuariosServicios = new Usuarios_Servicios();
        private Servicios_Tarifas_Sub oServiciosTarifasSub = new Servicios_Tarifas_Sub();
        private Tipo_Facturacion oTipoFacturacion = new Tipo_Facturacion();
        public int tipoOperacionSubServicio = 0; //1 AGREGAR SUBSERVICIO, 2 QUITAR SUBSERVICIO

        private void ComenzarCarga()
        {
            pgCircular.Start();
            hilo = new Thread(new ThreadStart(CargarDatos));
            hilo.Start();
        }
        private void CargarDatos()
        {
            dtSubServiciosDisponibles = oServicios.ListarPorServicio(idServicio);
            DataTable dtServiciosPorZonas = new DataTable();
            dtServiciosPorZonas = oTipoFacturacion.Listar(idTipoFacturacion);
            DataTable dt = new DataTable();
            dt.Columns.Add("id", typeof(Int32));
            dt.Columns.Add("id_servicios", typeof(Int32));
            dt.Columns.Add("id_servicios_sub_tipos", typeof(Int32));
            dt.Columns.Add("descripcion", typeof(String));
            dt.Columns.Add("requiere_ip", typeof(Int32));
            dt.Columns.Add("valor_defecto", typeof(Int32));
            dt.Columns.Add("id_iva_alicuotas", typeof(Int32));


            DataRow drSubServicio;
            DataRow datosSub;
            foreach (DataRow item in dtServiciosPorZonas.Rows)
            {
                var idSer = Convert.ToInt32(item["id_Servicios"]);
                var idSub = Convert.ToInt32(item["id_Servicios_sub"]);
                if (idSer == idServicio)
                {
                    drSubServicio = oServicios.TraerDatosSubServicio(idSub);
                    datosSub = oServicios.TraerDatosSubServicio(idSub);
                    if (datosSub.ItemArray.Length > 0)
                    {
                        dt.ImportRow(drSubServicio);
                    }
                }
            }
            dtSubServiciosActuales = oUsuariosServicios.ListarServiciosSub(idUsuariosServicios);
            dtSubDisponiblesFinal = ArmaTarifas(dt, 0);
            dtSubActuaesFinal = ArmaTarifas(dtSubServiciosActuales, 1);

            myDel MD = new myDel(AsignarDatos);
            this.Invoke(MD, new object[] { });
            pgCircular.Stop();
        }
        private void AsignarDatos()
        {
            AgregarColumnas();
            if (dtSubServiciosDisponibles.Rows.Count > 0)
            {
                dgvSubServiciosDisponibles.DataSource = dtSubDisponiblesFinal;
                dgvSubServiciosActuales.DataSource = dtSubActuaesFinal;
            }
            dgvSubServiciosDisponibles.Columns["id"].Visible = false;
            dgvSubServiciosActuales.Columns["id"].Visible = false;
            dgvSubServiciosDisponibles.Columns["Propio"].Visible = false;
            dgvSubServiciosActuales.Columns["Propio"].Visible = false;
            dgvSubServiciosDisponibles.Columns["AgreQuita"].Visible = false;
            dgvSubServiciosActuales.Columns["AgreQuita"].Visible = false;
            dgvSubServiciosDisponibles.Columns["RequiereIp"].Visible = false;
            dgvSubServiciosActuales.Columns["RequiereIp"].Visible = false;
            dgvSubServiciosDisponibles.Columns["UsuarioServicioId"].Visible = false;
            dgvSubServiciosActuales.Columns["UsuarioServicioId"].Visible = false;
            dgvSubServiciosActuales.Columns["fechaHasta"].Visible = false;
            dgvSubServiciosDisponibles.Columns["fechaHasta"].Visible = false;
            dgvSubServiciosActuales.Columns["Tarifa"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvSubServiciosActuales.Columns["Tarifa"].DefaultCellStyle.Format = "c";
            dgvSubServiciosActuales.Columns["Tarifa"].HeaderText = "Tarifa";

            dgvSubServiciosDisponibles.Columns["Tarifa"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvSubServiciosDisponibles.Columns["Tarifa"].DefaultCellStyle.Format = "c";
            dgvSubServiciosDisponibles.Columns["Tarifa"].HeaderText = "Tarifa";
            lblFechaDesdeDato.Text = fechaDesde.ToShortDateString();
            lblFechaMaximaDato.Text = fechaFactura.ToShortDateString();
            lblCarga.Visible = false;
            if (tipoOperacionSubServicio == 1)
                btnQuitar.Enabled = false;
            else
                btnAgregar.Enabled = false;
        }
        public frmAgregarQuitarSub()
        {
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {

        }

        private void frmAgregarQuitarSub_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            drEliminados = dtEliminados.Select("Propio=5");
            drAgregados = dtSubActuaesFinal.Select("Propio=6");
            this.DialogResult = DialogResult.OK;
        }

        private void boton1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;

        }

        private void dtpFechaHasta_ValueChanged(object sender, EventArgs e)
        {
            DateTime fechaSeleccionada = new DateTime(dtpFechaHasta.Value.Year, dtpFechaHasta.Value.Month, dtpFechaHasta.Value.Day);

            if (DateTime.Compare(fechaSeleccionada, fechaFactura) > 0)
            {
                MessageBox.Show("La fecha de terminacion no puede ser posterior a la fecha que el usuario tiene facturada", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                dtpFechaHasta.Focus();
            }
            else
            {
                if ((fechaSeleccionada.Year == fechaDesde.Year) && (fechaSeleccionada.Month == fechaDesde.Month))
                {
                    MessageBox.Show("La fecha de terminacion debe ser por lo menos un mes posterior a la fecha de iniciacion", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    dtpFechaHasta.Focus();
                }
            }
        }

        private void btnFecha_Click(object sender, EventArgs e)
        {
            dtpFechaHasta.Value = fechaFactura;
        }

        private void btnAgregarConfirmar_Click(object sender, EventArgs e)
        {
            fechaHasta = dtpFechaHasta.Value;
            pnlSeleccionar.Visible = false;
            idSubAux = Convert.ToInt32(dgvSubServiciosDisponibles.SelectedRows[0].Cells["id"].Value);
            nombreSubAux = dgvSubServiciosDisponibles.SelectedRows[0].Cells["Nombre"].Value.ToString();
            importeAux = Convert.ToDecimal(dgvSubServiciosDisponibles.SelectedRows[0].Cells["Tarifa"].Value);
            requiereIpAux = Convert.ToInt32(dgvSubServiciosDisponibles.SelectedRows[0].Cells["RequiereIp"].Value);
            dtSubActuaesFinal.Rows.Add(idSubAux, nombreSubAux, importeAux, requiereIpAux, 1, 6, 0, fechaHasta);
            dgvSubServiciosActuales.DataSource = dtSubActuaesFinal;
        }

        private void imgReturn2_Click(object sender, EventArgs e)
        {
            pnlSeleccionar.Visible = false;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            pnlSeleccionar.Visible = true;
            fechaHasta = dtpFechaHasta.Value;
            dgvSubServiciosDisponibles.SendToBack();

        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            var index = 0;
            var idususersub = 0;
            index = dgvSubServiciosActuales.SelectedRows[0].Index;
            requiereIpAux = Convert.ToInt32(dgvSubServiciosActuales.SelectedRows[0].Cells["RequiereIp"].Value);
            if ((requiereIpAux == 1) && (requierVelocidad == "SI"))
            {
                MessageBox.Show("Este subservicio es fundamental, no se puede quitar", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                if (dgvSubServiciosActuales.Rows.Count > 1)
                {
                    idSubAux = Convert.ToInt32(dgvSubServiciosActuales.SelectedRows[0].Cells["Id"].Value);
                    nombreSubAux = dgvSubServiciosActuales.SelectedRows[0].Cells["Nombre"].Value.ToString();
                    importeAux = Convert.ToDecimal(dgvSubServiciosActuales.SelectedRows[0].Cells["Tarifa"].Value);
                    requiereIpAux = Convert.ToInt32(dgvSubServiciosActuales.SelectedRows[0].Cells["RequiereIp"].Value);
                    propio = Convert.ToInt32(dgvSubServiciosActuales.SelectedRows[0].Cells["Propio"].Value);
                    if (propio == 5)
                        idususersub = Convert.ToInt32(dgvSubServiciosActuales.SelectedRows[0].Cells["UsuarioServicioId"].Value);

                    dtEliminados.Rows.Add(idSubAux, nombreSubAux, importeAux, requiereIpAux, 2, propio, idususersub, new DateTime());
                    dgvSubServiciosActuales.Rows.RemoveAt(index);
                    dgvSubServiciosActuales.DataSource = dtSubActuaesFinal;
                    dgvSubServiciosActuales.Rows[dgvSubServiciosActuales.Rows.Count - 1].Selected = true;
                }
                else
                    MessageBox.Show("No se pueden quitar todos los subservicios", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }

        }


        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void frmAgregarQuitarSub_Load(object sender, EventArgs e)
        {
            ComenzarCarga();
        }
        private void AgregarColumnas()
        {
            //Columnas para dtSubDisponiblesFinal

            dtEliminados.Columns.Add("Id", typeof(Int32));
            dtEliminados.Columns.Add("Nombre", typeof(String));
            dtEliminados.Columns.Add("Tarifa", typeof(decimal));
            dtEliminados.Columns.Add("RequiereIp", typeof(Int32));
            dtEliminados.Columns.Add("AgreQuita", typeof(Int32));
            dtEliminados.Columns.Add("Propio", typeof(Int32));
            dtEliminados.Columns.Add("UsuarioServicioId", typeof(Int32));
            dtEliminados.Columns.Add("fechaHasta", typeof(DateTime));

            dtAgregdos.Columns.Add("Id", typeof(Int32));
            dtAgregdos.Columns.Add("Nombre", typeof(String));
            dtAgregdos.Columns.Add("Tarifa", typeof(decimal));
            dtAgregdos.Columns.Add("RequiereIp", typeof(Int32));
            dtAgregdos.Columns.Add("AgreQuita", typeof(Int32));
            dtAgregdos.Columns.Add("Propio", typeof(Int32));
            dtAgregdos.Columns.Add("fechaHasta", typeof(DateTime));

        }
        private DataTable ArmaTarifas(DataTable dtSubServicios, int actual)
        {
            DataTable dt = new DataTable();
            DataTable dtTarifas = new DataTable();
            dt.Columns.Add("Id", typeof(Int32));
            dt.Columns.Add("Nombre", typeof(String));
            dt.Columns.Add("Tarifa", typeof(decimal));
            dt.Columns.Add("RequiereIp", typeof(Int32));
            dt.Columns.Add("AgreQuita", typeof(Int32));
            dt.Columns.Add("Propio", typeof(Int32));
            dt.Columns.Add("UsuarioServicioId", typeof(Int32));
            dt.Columns.Add("FechaHasta", typeof(DateTime));

            var idSub = 0;
            var nombre = "";
            var requiereIp = 0;
            decimal importe = 0;
            var idVelocidadTip = 0;
            var idVelocidad = 0;
            var otroId = 0;
            switch (idModalidad)
            {
                case 2:
                    if (dtSubServicios.Rows.Count > 0)
                    {
                        foreach (DataRow item in dtSubServicios.Rows)
                        {
                            if (actual == 0)
                                idSub = Convert.ToInt32(item["id"]);
                            else
                            {
                                idSub = Convert.ToInt32(item["id_servicios_sub"]);
                                otroId = Convert.ToInt32(item["id"]);
                            }

                            nombre = item["descripcion"].ToString();
                            requiereIp = Convert.ToInt32(item["requiere_ip"]);
                            if (actual == 1)
                            {
                                if (requiereIp == 0)
                                {
                                    dtTarifas = oServiciosTarifasSub.ObtienePrecio(idTarifaVigente, idTipoFacturacion, idServicio, idSub, 0, 0, "S");
                                    if (dtTarifas.Rows.Count > 0)
                                        importe = Convert.ToDecimal(dtTarifas.Rows[0]["importe"]);
                                    else
                                        importe = 0;

                                    dt.Rows.Add(idSub, nombre, importe, requiereIp, 0, 5, otroId, new DateTime());
                                }
                                else
                                {
                                    idVelocidad = Convert.ToInt32(item["id_servicios_velocidades"]);
                                    idVelocidadTip = Convert.ToInt32(item["id_servicios_velocidades_tip"]);
                                    dtTarifas = oServiciosTarifasSub.ObtienePrecio(idTarifaVigente, idTipoFacturacion, idServicio, idSub, idVelocidad, idVelocidadTip, "S");
                                    if (dtTarifas.Rows.Count != 0)
                                        importe = Convert.ToDecimal(dtTarifas.Rows[0]["importe"]);
                                    else
                                        importe = 0;
                                    dt.Rows.Add(idSub, nombre, importe, requiereIp, 0, 5, idUsuariosServicios, new DateTime());

                                }
                            }
                            else
                            {
                                if (requiereIp != 1)
                                {
                                    dtTarifas = oServiciosTarifasSub.ObtienePrecio(idTarifaVigente, idTipoFacturacion, idServicio, idSub, 0, 0, "S");
                                    if (dtTarifas.Rows.Count > 0)
                                        importe = Convert.ToDecimal(dtTarifas.Rows[0]["importe"]);
                                    else
                                        importe = 0;
                                    dt.Rows.Add(idSub, nombre, importe, requiereIp, 2, 6, idUsuariosServicios, new DateTime());
                                }
                            }
                        }
                    }

                    break;
                case 3:
                    if (dtSubServicios.Rows.Count > 0)
                    {
                        foreach (DataRow item in dtSubServicios.Rows)
                        {
                            if (actual == 0)
                                idSub = Convert.ToInt32(item["id"]);
                            else
                            {
                                idSub = Convert.ToInt32(item["id_servicios_sub"]);
                                otroId = Convert.ToInt32(item["id"]);
                            }

                            nombre = item["descripcion"].ToString();
                            importe = oServiciosTarifasSub.getImporte(idTarifaVigente, idServicio, idSub, "S", idTipoFacturacion);
                            requiereIp = Convert.ToInt32(item["requiere_ip"]);
                            if (actual == 1)
                            {
                                if (requiereIp == 0)
                                {
                                    dtTarifas = oServiciosTarifasSub.ObtienePrecio(idTarifaVigente, idTipoFacturacion, idServicio, idSub, idVelocidad, idVelocidadTip, "S");
                                    if (dtTarifas.Rows.Count != 0)
                                        importe = Convert.ToDecimal(dtTarifas.Rows[0]["importe"]);
                                    else
                                        importe = 0;

                                    dt.Rows.Add(idSub, nombre, importe, requiereIp, 0, 5, idUsuariosServicios, new DateTime());
                                }
                                else
                                {
                                    idVelocidad = Convert.ToInt32(item["id_servicios_velocidades"]);
                                    idVelocidadTip = Convert.ToInt32(item["id_servicios_velocidades_tip"]);
                                    dtTarifas = oServiciosTarifasSub.ObtienePrecio(idTarifaVigente, idTipoFacturacion, idServicio, idSub, idVelocidad, idVelocidadTip, "S");
                                    if (dtTarifas.Rows.Count != 0)
                                        importe = Convert.ToDecimal(dtTarifas.Rows[0]["importe"]);
                                    else
                                        importe = 0;

                                    dt.Rows.Add(idSub, nombre, importe, requiereIp, 0, 5, idUsuariosServicios, new DateTime());

                                }
                            }
                            else
                            {
                                if (requiereIp != 1)
                                {
                                    dtTarifas = oServiciosTarifasSub.ObtienePrecio(idTarifaVigente, idTipoFacturacion, idServicio, idSub, 0, 0, "S");
                                    if (dtTarifas.Rows.Count > 0)
                                        importe = Convert.ToDecimal(dtTarifas.Rows[0]["importe"]);
                                    else
                                        importe = 0;

                                    dt.Rows.Add(idSub, nombre, importe, requiereIp, 2, 6, idUsuariosServicios, new DateTime());
                                }
                            }
                        }
                    }
                    break;
            }
            return dt;
        }
    }
}
