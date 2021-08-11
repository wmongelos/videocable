using CapaNegocios;
using CapaPresentacion.Busquedas;
using System;
using System.Data;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace CapaPresentacion.Partes_Trabajo
{
    public partial class frmParteConexion_Auxiliar : Form
    {
        #region [PROPIEDADES]
        public Int32 IdServicios;
        public Int32 IdServiciosTipos;
        public String Servicio;
        public Boolean ForzarInicioMes;
        public Boolean ForzarFechaInicioServicio;
        public Boolean RequiereEquipo;
        public Boolean RequiereVelocidades;
        public Tipo_Facturacion.Id_Tipo_Facturacion TipoFacturacion;
        public Int32 IdTipoFacturacion;
        public DateTime FechaInicioServicio;
        public DateTime FechaConexionServicio;
        public DateTime FechaFinServicio;
        public DateTime FechaDesdePeriodoCerrado;
        public DateTime FechaHastaPeriodoCerrado;
        public Int32 IdServiciosCategorias;
        public String Modo = "BO";
        public Int32 Cantidad;
        public Int32 CantidadPactada;
        public String VelocidadSeleccionada;
        public Int32 IdServiciosVelocidades;
        public String VelocidadTipoSeleccionada;
        public Int32 IdServiciosVelocidadesTipo;
        public Int32 ContrataIPFija;
        public DataTable DataEquiposSeleccionados;
        public String CategoriaSeleccionada;
        public Int32 IdServiciosModalidad;
        public Int32 DiasBonificacion;
        public Int32 MesesServicio;
        public Int32 MesesCobro;
        public Int32 CantDiasPeriodoCerrado;
        public Int32 idTarifaPaquete;

        public Int32 vieneCambioServicio;

        private Thread Hilo;
        private delegate void myDel();

        private Servicios_Categorias ServiciosCategorias = new Servicios_Categorias();
        private Servicios_Tarifas ServiciosTarifas = new Servicios_Tarifas();
        private Servicios_Velocidades ServiciosVelocidades = new Servicios_Velocidades();
        private Equipos_Tipos EquiposTipos = new Equipos_Tipos();
        private Configuracion Config = new Configuracion();
        private Servicios_Tarifas_Sub_Esp oServiciosTarifasEsp = new Servicios_Tarifas_Sub_Esp();
        private DataTable DataServiciosCategorias;
        private DataTable DataEquipos;
        private DataTable DataVelocidades;
        private DataTable DataEspeciales;
        private int modificarMeses;

        #endregion

        public frmParteConexion_Auxiliar()
        {
            InitializeComponent();
        }

        private void ComenzarCarga()
        {
            Hilo = new Thread(new ThreadStart(CargarDatos));
            Hilo.Start();
        }

        private void CargarDatos()
        {
            try
            {
                DataServiciosCategorias = ServiciosCategorias.Listar();

                if (this.RequiereEquipo)
                    DataEquipos = EquiposTipos.ListarPorTipoServicios(this.IdServiciosTipos);

                if (this.RequiereVelocidades)
                {
                    int idtarifa = ServiciosTarifas.getTarifaId();

                    DataVelocidades = ServiciosVelocidades.ListarPrecios(idtarifa, this.IdTipoFacturacion, this.IdServicios);

                    if (this.IdServiciosModalidad == Convert.ToInt32(Servicios._Modalidad.DIA))
                    {
                        DataView vista = new DataView(DataVelocidades);
                        DataVelocidades = vista.ToTable(true, "Tipo", "Velocidad", "Id_Servicios_Velocidad", "Id_Servicios_Velocidad_Tip");
                    }
                    if (this.IdServiciosModalidad == Convert.ToInt32(Servicios._Modalidad.PERIODO_CERRADO_POR_MES))
                    {
                        if (DataVelocidades.Rows.Count > 0)
                        {
                            FechaDesdePeriodoCerrado = Convert.ToDateTime(DataVelocidades.Rows[0]["Fecha_Desde"]);
                            FechaHastaPeriodoCerrado = Convert.ToDateTime(DataVelocidades.Rows[0]["Fecha_Hasta"]);

                        }
                    }
                }

                DataEquiposSeleccionados = new DataTable();
                DataEquiposSeleccionados.Columns.Add("Tipo", typeof(String));
                DataEquiposSeleccionados.Columns.Add("Cantidad", typeof(Int32));
                DataEquiposSeleccionados.Columns.Add("Tarjeta", typeof(String));
                DataEquiposSeleccionados.Columns.Add("Id", typeof(Int32));
                DataEquiposSeleccionados.Columns.Add("Id_Tarjeta", typeof(Int32));
                DataEquiposSeleccionados.AcceptChanges();
                modificarMeses = Config.GetValor_N("CambioMeses");
                myDel MD = new myDel(AsignarDatos);

                this.Invoke(MD, new object[] { });
            }
            catch
            {
                MessageBox.Show("Error al Cargar la Informacion", "Mensaje del Sistema");
            }
        }

        private void AsignarDatos()
        {
            lblModalidadCantidad.Text = "U. Funcional";
            lblModalidadCantidad.Location = new Point(365, lblModalidadCantidad.Location.Y);
            lblModalidadCantidadPac.Text = "U.F. Pactadas";

            this.Modo = "UF";
            cboServicios_Categ.DataSource = DataServiciosCategorias;
            cboServicios_Categ.DisplayMember = "Nombre";
            cboServicios_Categ.ValueMember = "Id";
            lblServicio.Text = this.Servicio;

            if (this.TipoFacturacion == Tipo_Facturacion.Id_Tipo_Facturacion.POR_CATEGORIAS)
            {
                cboServicios_Categ.SelectedValue = IdTipoFacturacion;
                cboServicios_Categ.Enabled = false;
            }

            if (IdServiciosModalidad == Convert.ToInt32(Servicios._Modalidad.PERIODO_CERRADO_POR_MES))
            {
                dtpFechaConexion.MinDate = FechaDesdePeriodoCerrado;
                dtpFechaInicioServ.MinDate = FechaDesdePeriodoCerrado;
            }
            if (IdServiciosModalidad != Convert.ToInt32(Servicios._Modalidad.PERIODO))
            {
                lblMesesCobro.Visible = false;
                lblMesesServicio.Visible = false;
                spMesesCobro.Visible = false;
                spMesesServicio.Visible = false;
            }
            else
            {
                if (modificarMeses == Convert.ToInt32(Configuracion.CAMBIO_MESES.NO))
                {
                    lblMesesCobro.Visible = false;
                    lblMesesServicio.Visible = false;
                    spMesesCobro.Visible = false;
                    spMesesServicio.Visible = false;
                }
                else
                {
                    lblMesesCobro.Visible = true;
                    lblMesesServicio.Visible = true;
                    spMesesCobro.Visible = true;
                    spMesesServicio.Visible = true;
                }
            }
            if (this.ForzarInicioMes)
            {
                DateTime date = DateTime.Today;

                dtpFechaInicioServ.Value = date.Day < 15 ? new DateTime(date.Year, date.Month, 1) : new DateTime(date.Year, date.Month, 1).AddMonths(1);
                dtpFechaConexion.Value = dtpFechaInicioServ.Value;
            }
            else
            {
                dtpFechaInicioServ.Value = FechaInicioServicio;
                dtpFechaConexion.Value = FechaConexionServicio;
            }
            if ((this.RequiereEquipo == false) && (this.RequiereVelocidades == false) && (IdServiciosModalidad != Convert.ToInt32(Servicios._Modalidad.PERIODO_CERRADO_POR_MES)) && (IdServiciosModalidad != Convert.ToInt32(Servicios._Modalidad.PERIODO_CERRADO_POR_DIA)))
            {
                this.Height = pnlSuperior.Height + pnlFechas.Height + pnlBotones.Height;
                this.Top = (Screen.PrimaryScreen.WorkingArea.Height - this.Height) / 2;
            }
            else
            {
                if (this.RequiereEquipo)
                {

                    cboEquipos.DataSource = DataEquipos;
                    cboEquipos.ValueMember = "Id";
                    cboEquipos.DisplayMember = "Nombre";
                    if (cboEquipos.Items.Count == 0)
                        btnAgregarEquipo.Enabled = false;
                    dgvEquipos.DataSource = DataEquiposSeleccionados;
                    dgvEquipos.Columns["Id"].Visible = false;
                    dgvEquipos.Columns["Id_Tarjeta"].Visible = false;
                    DataGridViewLinkColumn col = new DataGridViewLinkColumn();
                    dgvEquipos.Columns.Add(col);
                    col.Text = "Eliminar";
                    col.DataPropertyName = "Eliminar";
                    col.Name = "Accion";
                    col.LinkColor = Color.Blue;
                    col.VisitedLinkColor = Color.Blue;
                    col.UseColumnTextForLinkValue = true;
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    col.Width = 100;
                    dgvEquipos.ColumnHeadersHeight = 35;

                }
                else
                    tabControl1.TabPages.RemoveAt(1);


                if (this.RequiereVelocidades)
                {
                    tabControl1.TabPages.RemoveAt(2);
                    dgvVelocidades.DataSource = DataVelocidades;

                    for (int i = 0; i < dgvVelocidades.Columns.Count; i++)
                        dgvVelocidades.Columns[i].Visible = false;

                    if (IdServiciosModalidad == Convert.ToInt32(Servicios._Modalidad.DIA))
                    {
                        dgvVelocidades.Columns["Tipo"].Visible = true;
                        dgvVelocidades.Columns["Velocidad"].Visible = true;
                        dgvVelocidades.Columns["Id_Servicios_Velocidad"].Visible = false;
                        dgvVelocidades.Columns["Id_Servicios_Velocidad_Tip"].Visible = false;
                    }
                    else
                    {
                        if (IdServiciosModalidad == Convert.ToInt32(Servicios._Modalidad.PERIODO_CERRADO_POR_DIA))
                        {
                            dgvVelocidades.Columns["Tipo"].Visible = true;
                            dgvVelocidades.Columns["Velocidad"].Visible = true;
                            dgvVelocidades.Columns["Importe"].Visible = true;
                            dgvVelocidades.Columns["dias_desde"].Visible = true;


                            dgvVelocidades.Columns["Tipo"].DisplayIndex = 1;
                            dgvVelocidades.Columns["Velocidad"].DisplayIndex = 2;
                            dgvVelocidades.Columns["dias_desde"].DisplayIndex = 3;
                            dgvVelocidades.Columns["Importe"].DisplayIndex = 4;

                            dgvVelocidades.Columns["dias_desde"].HeaderText = "Dias";
                            dgvVelocidades.Columns["dias_desde"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                            dgvVelocidades.Columns["Importe"].DefaultCellStyle.Format = "C2";
                            dgvVelocidades.Columns["Importe"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                        }
                        else
                        {

                            dgvVelocidades.Columns["Tipo"].Visible = true;
                            dgvVelocidades.Columns["Velocidad"].Visible = true;
                            dgvVelocidades.Columns["Importe"].Visible = true;
                            dgvVelocidades.Columns["Tipo"].DisplayIndex = 1;
                            dgvVelocidades.Columns["Velocidad"].DisplayIndex = 2;
                            dgvVelocidades.Columns["Importe"].DisplayIndex = 3;
                            dgvVelocidades.Columns["Importe"].DefaultCellStyle.Format = "C2";
                            dgvVelocidades.Columns["Importe"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        }
                    }
                    foreach (DataGridViewRow item in dgvVelocidades.Rows)
                        item.Height = 30;
                    dgvVelocidades.ColumnHeadersHeight = 35;


                }
                else
                {
                    tabControl1.TabPages.RemoveAt(0);
                    if (IdServiciosModalidad == Convert.ToInt32(Servicios._Modalidad.PERIODO_CERRADO_POR_MES) || (IdServiciosModalidad == Convert.ToInt32(Servicios._Modalidad.PERIODO_CERRADO_POR_DIA)))
                    {
                        DataTable dtPaquetes = new DataTable();
                        ServiciosTarifas.Fecha_Actual = dtpFechaInicioServ.Value;
                        int idTarifa = ServiciosTarifas.getTarifa();
                        Servicios_Sub oSerSub = new Servicios_Sub();
                        DataTable dtSubServicios = oSerSub.ListarPorServicio(IdServicios);
                        DataView dv1 = new DataView(dtSubServicios);
                        dv1.RowFilter = "Id_Servicios_Sub_Tipos=1";
                        DataTable dtSubFiltrados = dv1.ToTable();
                        int idSub = Convert.ToInt32(dtSubFiltrados.Rows[0]["id"]);




                        dtPaquetes = oServiciosTarifasEsp.GetServicios_Tarifas_Sub_Esp(idTarifa, IdServicios, idSub, IdTipoFacturacion);
                        //dtPaquetes = oServiciosTarifasEsp.GetServicios_Tarifas_Sub_Esp(idTarifa, IdServicios, IdTipoFacturacion);

                        if (IdServiciosModalidad == Convert.ToInt32(Servicios._Modalidad.PERIODO_CERRADO_POR_DIA))
                        {
                            dgvPaquetes.DataSource = dtPaquetes;
                            foreach (DataGridViewColumn item in dgvPaquetes.Columns)
                                item.Visible = false;
                            dgvPaquetes.Columns["dias_hasta"].Visible = true;
                            dgvPaquetes.Columns["dias_hasta"].HeaderText = "Dias";
                        }
                        else
                        {
                            dgvPaquetes.DataSource = dtPaquetes;
                            foreach (DataGridViewColumn item in dgvPaquetes.Columns)
                                item.Visible = false;
                            dgvPaquetes.Columns["fecha_Desde"].Visible = true;
                            dgvPaquetes.Columns["fecha_hasta"].Visible = true;
                        }
                        dgvPaquetes.Columns["importe"].Visible = true;
                        dgvPaquetes.Columns["importe"].HeaderText = "Importe";
                    }
                }
            }
        }

        private void frmParteConexion_Auxiliar_Load(object sender, EventArgs e)
        {
            idTarifaPaquete = 0;
            this.ComenzarCarga();
        }

        private void dgvVelocidades_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.RequiereVelocidades)
                {
                    this.IdServiciosVelocidades = Convert.ToInt32(dgvVelocidades.SelectedRows[0].Cells["Id_Servicios_Velocidad"].Value);
                    this.IdServiciosVelocidadesTipo = Convert.ToInt32(dgvVelocidades.SelectedRows[0].Cells["Id_Servicios_Velocidad_Tip"].Value);
                    this.VelocidadSeleccionada = dgvVelocidades.SelectedRows[0].Cells["Velocidad"].Value.ToString();
                    this.VelocidadTipoSeleccionada = dgvVelocidades.SelectedRows[0].Cells["Tipo"].Value.ToString();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                if (spUFuncional.Value < spUFuncionalPac.Value)
                {
                    MessageBox.Show("La cantidad de unidades funcionales pactadas no puede ser mayor a la cantidad de unidades funcionales",
                        "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    spUFuncionalPac.Focus();
                    return;
                }


                this.FechaInicioServicio = dtpFechaInicioServ.Value;
                this.FechaConexionServicio = dtpFechaConexion.Value;
                this.MesesCobro = Convert.ToInt32(spMesesCobro.Value);
                this.MesesServicio = Convert.ToInt32(spMesesServicio.Value);


                if (this.ForzarInicioMes == false)
                {
                    if (FechaConexionServicio > FechaInicioServicio)
                    {
                        MessageBox.Show("La fecha de Conexion del Servicio no debe ser posterior a la fecha de Inicio de Servicio",
                            "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                        dtpFechaConexion.Focus();
                        return;
                    }

                    if (FechaConexionServicio < DateTime.Today)
                    {
                        MessageBox.Show("La fecha de Conexion del Servicio no debe ser anterior a la fecha de hoy",
                           "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                        dtpFechaConexion.Focus();
                        return;
                    }
                }
                if (this.RequiereEquipo)
                {
                    if (DataEquiposSeleccionados.Rows.Count == 0)
                    {
                        if (MessageBox.Show("No ha Seleccionado Ningun Tipo de Equipo. ¿Desea Continuar?",
                            "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        {
                            tabControl1.SelectTab(tabEquipos);
                            cboEquipos.Focus();
                            return;
                        }
                    }
                }

                if ((this.FechaInicioServicio.Day != 1) && (this.ForzarInicioMes == true))
                {
                    MessageBox.Show("La fecha de inicio de servicio no puede ser distinta a 1 ", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    if (IdServiciosModalidad == Convert.ToInt32(Servicios._Modalidad.DIA))
                        this.FechaFinServicio = this.FechaInicioServicio.AddDays(this.DiasBonificacion);

                    if (IdServiciosModalidad == Convert.ToInt32(Servicios._Modalidad.MENSUAL))
                    {
                        if (this.FechaInicioServicio.Month < 12)
                            this.FechaFinServicio = new DateTime(this.FechaInicioServicio.Year, this.FechaInicioServicio.Month + 1, 1).AddDays(-1);
                        else
                            this.FechaFinServicio = new DateTime(this.FechaInicioServicio.Year + 1, 1, 1).AddDays(-1);
                    }

                    if (IdServiciosModalidad == Convert.ToInt32(Servicios._Modalidad.PERIODO))
                    {
                        Servicios_Tarifas_Sub oTarifaSub = new Servicios_Tarifas_Sub();
                        ServiciosTarifas.Fecha_Actual = dtpFechaInicioServ.Value;
                        int idTarifa = ServiciosTarifas.getTarifa();
                        int meses = 0;
                        if (modificarMeses == Convert.ToInt16(Configuracion.CAMBIO_MESES.NO))
                            meses = oTarifaSub.getMesesServicio(this.IdServicios, IdTipoFacturacion, idTarifa, this.IdServiciosVelocidades, this.IdServiciosVelocidadesTipo);
                        else
                            meses = Convert.ToInt16(spMesesServicio.Value);
                        this.FechaFinServicio = this.FechaInicioServicio.AddMonths(meses).AddDays(-1).Date;
                    }
                    if (IdServiciosModalidad == Convert.ToInt32(Servicios._Modalidad.PERIODO_CERRADO_POR_DIA))
                    {
                        Servicios_Tarifas_Sub oTarifaSub = new Servicios_Tarifas_Sub();
                        ServiciosTarifas.Fecha_Actual = dtpFechaInicioServ.Value;
                        int idTarifa = ServiciosTarifas.getTarifa();
                        int meses = oTarifaSub.getMesesServicio(this.IdServicios, IdTipoFacturacion, idTarifa, this.IdServiciosVelocidades, this.IdServiciosVelocidadesTipo);
                        if (RequiereVelocidades == true)
                            CantDiasPeriodoCerrado = Convert.ToInt32(dgvVelocidades.SelectedRows[0].Cells["dias_desde"].Value);
                        else
                            CantDiasPeriodoCerrado = Convert.ToInt32(dgvPaquetes.SelectedRows[0].Cells["dias_desde"].Value);

                        this.FechaFinServicio = this.FechaInicioServicio.AddDays(CantDiasPeriodoCerrado);
                        this.idTarifaPaquete = Convert.ToInt32(dgvPaquetes.SelectedRows[0].Cells["id"].Value);

                    }
                    if (IdServiciosModalidad == Convert.ToInt32(Servicios._Modalidad.PERIODO_CERRADO_POR_MES))
                    {
                        Servicios_Tarifas_Sub oTarifaSub = new Servicios_Tarifas_Sub();
                        ServiciosTarifas.Fecha_Actual = dtpFechaInicioServ.Value;
                        int idTarifa = ServiciosTarifas.getTarifa();
                        int meses = oTarifaSub.getMesesServicio(this.IdServicios, IdTipoFacturacion, idTarifa, this.IdServiciosVelocidades, this.IdServiciosVelocidadesTipo);
                        this.idTarifaPaquete = Convert.ToInt32(dgvPaquetes.SelectedRows[0].Cells["id"].Value);
                        if (RequiereVelocidades == true)
                            FechaHastaPeriodoCerrado = Convert.ToDateTime(dgvVelocidades.SelectedRows[0].Cells["fecha_hasta"].Value);
                        else
                        {
                            FechaDesdePeriodoCerrado = Convert.ToDateTime(dgvPaquetes.SelectedRows[0].Cells["fecha_desde"].Value);
                            FechaHastaPeriodoCerrado = Convert.ToDateTime(dgvPaquetes.SelectedRows[0].Cells["fecha_hasta"].Value);
                        }

                        this.FechaFinServicio = FechaHastaPeriodoCerrado;
                    }

                    this.IdServiciosCategorias = Convert.ToInt32(cboServicios_Categ.SelectedValue);
                    this.Cantidad = Convert.ToInt32(spUFuncional.Value);
                    this.CantidadPactada = Convert.ToInt32(spUFuncionalPac.Value);
                    this.CategoriaSeleccionada = cboServicios_Categ.Text;
                    this.ContrataIPFija = chkIPFija.CheckState == CheckState.Checked ? 1 : 0;

                    this.DialogResult = DialogResult.OK;
                }
            }
            catch { MessageBox.Show("Error en parte auxiliar."); }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnAgregarEquipo_Click(object sender, EventArgs e)
        {
            DataRow[] DrTipoEquipo = DataEquipos.Select(String.Format("Id = {0}", cboEquipos.SelectedValue.ToString()));
            Int32 cantidad = Convert.ToInt32(spCantidadEquipos.Value);


            if (Convert.ToInt32(DrTipoEquipo[0]["Requiere_Tarjeta"]) == 1 && cantidad > 1)
            {
                MessageBox.Show("No se permite agregar mas de un equipo con asignacion de tarjeta", "Mensaje del Sistema");

                spCantidadEquipos.Focus();

                return;
            }

            if (Convert.ToInt32(DrTipoEquipo[0]["Requiere_Tarjeta"]) == 1)
            {
                if (Config.GetValor_N("Solicita_Tarjeta_Parte") == 1)
                {
                    if (MessageBox.Show("¿Desea Asignar el Nro. de Tarjeta?", "Mensaje del Sistema",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        using (frmPopUp frm = new frmPopUp())
                        {
                            frmBusquedaTarjetasEquipos frmBusquedaTarjetas = new frmBusquedaTarjetasEquipos(Convert.ToInt32(cboEquipos.SelectedValue), Convert.ToInt32(Equipos_Tarjetas.Tarjetas_Estados.DISPONIBLE));
                            frmBusquedaTarjetas.id_usuario_actual = 0;
                            frm.Maximizar = false;
                            frm.Formulario = frmBusquedaTarjetas;
                            
                            if (frm.ShowDialog() == DialogResult.OK)
                                DataEquiposSeleccionados.Rows.Add(cboEquipos.Text, cantidad, frmBusquedaTarjetas.NumeroTarjeta, Convert.ToInt32(cboEquipos.SelectedValue), frmBusquedaTarjetas.IdTarjeta);
                        }
                    }
                    else
                        DataEquiposSeleccionados.Rows.Add(cboEquipos.Text, cantidad, string.Empty, Convert.ToInt32(cboEquipos.SelectedValue), 0);
                }
                else
                    DataEquiposSeleccionados.Rows.Add(cboEquipos.Text, cantidad, string.Empty, Convert.ToInt32(cboEquipos.SelectedValue), 0);
            }
            else
                DataEquiposSeleccionados.Rows.Add(cboEquipos.Text, cantidad, string.Empty, Convert.ToInt32(cboEquipos.SelectedValue), 0);

            spCantidadEquipos.Value = 1;
        }

        private void dgvEquipos_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            foreach (DataGridViewRow item in dgvEquipos.Rows)
                item.Height = 30;
        }

        private void rbBocas_CheckedChanged(object sender, EventArgs e)
        {
            if (rbBocas.Checked == true)
            {
                lblModalidadCantidad.Text = "Bocas";
                lblModalidadCantidad.Location = new Point(419, 166);
                lblModalidadCantidadPac.Text = "Bocas Pactadas";

                this.Modo = "BO";
            }
            else
            {
                lblModalidadCantidad.Text = "U. Funcional";
                lblModalidadCantidad.Location = new Point(365, lblModalidadCantidad.Location.Y);
                lblModalidadCantidadPac.Text = "U.F. Pactadas";

                this.Modo = "UF";
            }
        }

        private void dgvEquipos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                dgvEquipos.Rows.Remove(dgvEquipos.Rows[e.RowIndex]);
            }
        }

        private void frmParteConexion_Auxiliar_Shown(object sender, EventArgs e)
        {
            if (this.IdServiciosModalidad == Convert.ToInt32(Servicios._Modalidad.PERIODO_CERRADO_POR_MES))
            {
                dtpFechaInicioServ.Enabled = false;
            }
        }
    }
}//111119fede
