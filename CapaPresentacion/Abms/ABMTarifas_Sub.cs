using CapaNegocios;
using CapaPresentacion.Impresiones;
using System;
using System.Data;
using System.Threading;
using System.Windows.Forms;

namespace CapaPresentacion.Abms
{
    public partial class ABMTarifas_Sub : Form
    {
        #region [VARIABLES]
        private Thread hilo;
        private delegate void myDel();
        private DataTable dtTarifas;
        private DataTable dtServicios_Grupos;
        private DataTable dtServicios;
        private DataTable dtSubServicios;
        private DataTable dtTipo_Facturacion;
        private DataTable dtTarifas_Sub;
        private DataTable dtDtv;

        private Int32 Id_Servicios_Grupos;
        private Int32 Id_Servicios_Tarifa;
        private Int32 Id_Tipo_Facturacion;

        private Servicios_Tarifas oTarifa = new Servicios_Tarifas();
        private Servicios_Tarifas_Sub oTarifa_Sub = new Servicios_Tarifas_Sub();
        private Servicios_Tarifas_Sub_Esp oTarifas_Esp = new Servicios_Tarifas_Sub_Esp();

        private Configuracion oConfig = new Configuracion();
        private Servicios oSer = new Servicios();
        private Servicios_Sub oSub = new Servicios_Sub();
        private Servicios_Categorias oSerCat = new Servicios_Categorias();
        private Zonas oZonas = new Zonas();

        private Partes_Solicitudes oParte_Fallas = new Partes_Solicitudes();
        private Equipos_Tipos oEquipos_Tipos = new Equipos_Tipos();

        private Int32 Id_Current_Servicio;
        private Int32 tipoFacturacion = 0;
        private String Servicio;
        private Int32 Id_Grupo_Servicio;

        private Servicios._Modalidad _ServicioModalidad;
        private Boolean _Requiere_Velocidades;
        private Boolean _Requiere_Servicio_Padre;
        private Boolean _Fecha_Inicio_Servicio;
        private Boolean CambiosRealizados = false;
        private int Id_Servicios_Modalidad;
        private int idTipoFacturacion;
        private int rowselect = 0;
        #endregion

        #region [METODOS]

        public ABMTarifas_Sub()
        {
            InitializeComponent();
        }

        private void comenzarCarga()
        {
            pgCircular.Start();

            Id_Servicios_Grupos = Convert.ToInt32(cboGrupoServicios.SelectedValue);
            Id_Servicios_Tarifa = Convert.ToInt32(cboTarifas.SelectedValue);
            Id_Tipo_Facturacion = Convert.ToInt32(cboTipo_Facturacion.SelectedValue);

            dtTarifas_Sub = new DataTable();
            dtDtv = new DataTable();
            dtTarifas_Sub.Columns.Add("Id", typeof(Int32));
            dtTarifas_Sub.Columns.Add("Id_Servicios", typeof(Int32));
            dtTarifas_Sub.Columns.Add("Id_Tipo_Facturacion", typeof(Int32));
            dtTarifas_Sub.Columns.Add("Descripcion", typeof(String));
            dtTarifas_Sub.Columns.Add("Importe", typeof(Decimal));
            dtTarifas_Sub.Columns.Add("Id_Tabla_Tipo", typeof(Int32));
            dtTarifas_Sub.Columns.Add("Tipo", typeof(String));
            dtTarifas_Sub.Columns.Add("Dias", typeof(Int32));
            dtTarifas_Sub.Columns.Add("Fecha_Desde", typeof(DateTime));
            dtTarifas_Sub.Columns.Add("Fecha_Hasta", typeof(DateTime));
            dtTarifas_Sub.Columns.Add("Descripcion_Tipo", typeof(String));
            dtTarifas_Sub.Columns.Add("Requiere_IP", typeof(String));
            dtTarifas_Sub.Columns.Add("Tipo_SubServicio", typeof(String));
            dtTarifas_Sub.Columns.Add("Especial", typeof(String));

            dgvServicios.DataSource = null;
            dgvSubServicios.DataSource = null;

            hilo = new Thread(new ThreadStart(cargarDatos));
            hilo.Start();
        }

        private void cargarDatos()
        {

            dtTarifas = oTarifa.Listar();

            dtTarifas_Sub.Clear();

            dtServicios_Grupos = oSer.ListarGrupos();
            dtServicios = oSer.ListarPorTipoFacturacion(Id_Tipo_Facturacion);

            dtSubServicios = oSub.Listar(Id_Tipo_Facturacion);

            switch (oConfig.GetValor_N("Id_Tipo_Facturacion"))
            {
                case 1:
                    dtTipo_Facturacion = oZonas.Listar();   // ZONAS
                    break;
                case 2:
                    dtTipo_Facturacion = oSerCat.Listar();  // CATEGORIAS

                    break;
                default:
                    break;
            }

            DataRow[] drTarifa = dtTarifas.Select(String.Format("Id = {0}", Id_Servicios_Tarifa));

            dtServicios.Columns.Add("Importe", typeof(Decimal));
            dtServicios.Columns.Add("Importe_Total", typeof(Decimal));

            foreach (DataRow dr in dtSubServicios.Rows)
            {
                Decimal importe = 0;
                try
                {
                    importe = Convert.ToDecimal(oTarifa_Sub.ObtienePrecio(Id_Servicios_Tarifa, Id_Tipo_Facturacion, Convert.ToInt32(dr["Id_Servicios"]), Convert.ToInt32(dr["Id"]), 0, 0, "S").Rows[0]["importe"]);
                }
                catch { }
                dtTarifas_Sub.Rows.Add(Convert.ToInt32(dr["Id"]), Convert.ToInt32(dr["Id_Servicios"]), Id_Tipo_Facturacion, dr["Descripcion"].ToString(), importe, Convert.ToInt32(dr["Id"]), "S", 0, Convert.ToDateTime(drTarifa[0]["Fecha_Desde"]), Convert.ToDateTime(drTarifa[0]["Fecha_Hasta"]), "SUBSERVICIOS", dr["Requiere_IP"].ToString(), dr["Id_Servicios_Sub_Tipos"].ToString(), "0");
            }

            foreach (DataRow item in dtServicios.Rows)
            {
                item["Importe"] = 0;
                item["Importe_Total"] = 0;

                Int32 Id = Convert.ToInt32(item["Id_Servicios"].ToString());
                Int32 Id_Servicios_Tipo = Convert.ToInt32(item["Id_Servicios_Tipos"].ToString());

                foreach (DataRow dr in oParte_Fallas.GetDatosServicios(Id, true).Rows)
                {
                    Decimal importe = 0;
                    try
                    {
                        importe = Convert.ToDecimal(oTarifa_Sub.ObtienePrecio(Id_Servicios_Tarifa, Id_Tipo_Facturacion, Id, Convert.ToInt32(dr["Id"]), 0, 0, "P").Rows[0]["importe"]);
                    }
                    catch { }
                    dtTarifas_Sub.Rows.Add(Convert.ToInt32(dr["Id"]), Id, Id_Tipo_Facturacion, dr["Nombre"].ToString(), importe, Convert.ToInt32(dr["Id"]), "P", 0, Convert.ToDateTime(drTarifa[0]["Fecha_Desde"]), Convert.ToDateTime(drTarifa[0]["Fecha_Hasta"]), "PARTE DE TRABAJO", 0, "0", "0");
                }

                foreach (DataRow dr in oEquipos_Tipos.ListarPorTipoServicios(Id_Servicios_Tipo).Rows)
                {
                    Decimal importe = 0;
                    try
                    {
                        importe = Convert.ToDecimal(oTarifa_Sub.ObtienePrecio(Id_Servicios_Tarifa, Id_Tipo_Facturacion, Id, Convert.ToInt32(dr["Id"]), 0, 0, "E").Rows[0]["importe"]);
                    }
                    catch { }
                    dtTarifas_Sub.Rows.Add(Convert.ToInt32(dr["Id"]), Id, Id_Tipo_Facturacion, dr["Nombre"].ToString(), importe, Convert.ToInt32(dr["Id"]), "E", 0, Convert.ToDateTime(drTarifa[0]["Fecha_Desde"]), Convert.ToDateTime(drTarifa[0]["Fecha_Hasta"]), "EQUIPOS", 0, "0", "0");
                }
            }

            dtServicios.AcceptChanges();

            if (dtServicios.Rows.Count > 0)
                Id_Current_Servicio = Convert.ToInt32(dtServicios.Rows[0]["Id_Servicios"]);

            myDel MD = new myDel(asignarDatos);

            this.Invoke(MD, new object[] { });

            pgCircular.Stop();

        }

        private void asignarDatos()
        {
            tipoFacturacion = oConfig.GetValor_N("Id_Tipo_Facturacion");
            lblTipo_Facturacion.Text = tipoFacturacion == Convert.ToInt32(Tipo_Facturacion.Id_Tipo_Facturacion.POR_ZONAS) ? "Zonas" : "Categorias";
            lblsubservicios.Text = String.Format("Seleccione y edite los montos de los sub servicios para la tarifa y {0} seleccionadas:", tipoFacturacion == Convert.ToInt32(Tipo_Facturacion.Id_Tipo_Facturacion.POR_ZONAS) ? "zona" : "categoria");
            DataView dv = dtServicios.DefaultView;
            dv.RowFilter = String.Format("Id_Servicios_Grupos = {0}", Id_Servicios_Grupos);

            dgvServicios.Enabled = true;
            dgvServicios.DataSource = dv.Table;
            dgvServicios.Columns["Id_Servicios"].Visible = false;
            dgvServicios.Columns["Id_Servicios_Tipos"].Visible = false;
            dgvServicios.Columns["Id_Tipo_Facturacion"].Visible = false;
            dgvServicios.Columns["Requiere_Equipo"].Visible = false;
            dgvServicios.Columns["Requiere_Velocidad"].Visible = false;
            dgvServicios.Columns["Requiere_Tarjeta"].Visible = false;
            dgvServicios.Columns["Tipo"].Visible = false;
            dgvServicios.Columns["Id_Servicios_Modalidad"].Visible = false;
            dgvServicios.Columns["Id_Servicios_Grupos"].Visible = false;
            dgvServicios.Columns["Dias_Bonificacion"].Visible = false;
            dgvServicios.Columns["Fecha_Inicio_Servicio"].Visible = false;
            dgvServicios.Columns["Requiere_Servicio_Padre"].Visible = false;
            dgvServicios.Columns["origenmeses"].Visible = false;
            dgvServicios.Columns["id_servicios_grupos1"].Visible = false;

            if (dgvServicios.Rows.Count > 0)
                dgvServicios.CurrentCell = dgvServicios.Rows[rowselect].Cells[1];

            dgvServicios.Columns["descripcion"].HeaderText = "Servicio";
            dgvServicios.Columns["Importe"].Visible = false;
            dgvServicios.Columns["Importe"].HeaderText = "Importe Mensual";
            dgvServicios.Columns["Importe"].DefaultCellStyle.Format = "N2";
            dgvServicios.Columns["Importe"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvServicios.Columns["Importe_Total"].Visible = false;
            dgvServicios.Columns["Importe_Total"].HeaderText = "Importe de Conexion";
            dgvServicios.Columns["Importe_Total"].DefaultCellStyle.Format = "N2";
            dgvServicios.Columns["Importe_Total"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            lblTotal.Text = String.Format("Total de Registros: {0}", dtTarifas.Rows.Count);

            cboTarifas.DataSource = dtTarifas;
            cboTarifas.DisplayMember = "Nombre";
            cboTarifas.ValueMember = "Id";

            txtDesde.Text = string.Empty;
            txtHasta.Text = string.Empty;

            if (Id_Servicios_Tarifa > 0)
            {
                cboTarifas.SelectedValue = Id_Servicios_Tarifa;

                DataRow[] drFilter = dtTarifas.Select(String.Format("Id = {0}", Id_Servicios_Tarifa));

                txtDesde.Text = drFilter[0]["Fecha_Desde"].ToString();
                txtHasta.Text = drFilter[0]["Fecha_Hasta"].ToString();
            }
            else
            {
                if (dtTarifas.Rows.Count > 0)
                {
                    txtDesde.Text = Convert.ToDateTime(dtTarifas.Rows[0]["Fecha_Desde"]).Date.ToString("dd/MM/yyyy");
                    txtHasta.Text = Convert.ToDateTime(dtTarifas.Rows[0]["Fecha_Hasta"]).Date.ToString("dd/MM/yyyy");
                }
            }

            cboGrupoServicios.DataSource = dtServicios_Grupos;
            cboGrupoServicios.DisplayMember = "Nombre";
            cboGrupoServicios.ValueMember = "Id";

            if (Id_Servicios_Grupos > 0)
                cboGrupoServicios.SelectedValue = Id_Servicios_Grupos;

            cboTipo_Facturacion.DataSource = dtTipo_Facturacion;
            cboTipo_Facturacion.DisplayMember = "Nombre";
            cboTipo_Facturacion.ValueMember = "Id";

            if (Id_Tipo_Facturacion > 0)
                cboTipo_Facturacion.SelectedValue = Id_Tipo_Facturacion;

            cargarImportes();
            CambiosRealizados = false;
            if (dgvServicios.Rows.Count > 0 && dgvSubServicios.Rows.Count > 0)
                btnGuardar.Enabled = true;

            //SELECCIONA LA TARIFA VIGENTE
            Int32 idTarifaVigente = 0;
            foreach (DataRow item in dtTarifas.Rows)
            {
                int id;
                id = Convert.ToInt32(item["id"]);
                if (oTarifa.tarifaEsVigente(id) == true)
                {
                    idTarifaVigente = id;
                    item["nombre"] = item["nombre"] + " (VIGENTE)";
                }
            }

            //cboTarifas.SelectedValue = idTarifaVigente;
        }

        private void ImprimirCuadroTarifario()
        {
            dsInformes oDs = new dsInformes();
            frmReportViewer frm = new frmReportViewer();
            frm.oViewer.ReportSource = null;
            rptCuadroTarifario rpt = new rptCuadroTarifario();

            DataTable dtTarifa;
            DataTable dtServiciosPorTarifa;
            int control = 0;
            dtTarifa = oTarifa.TraerDatosTarifaActual();

            if (dtTarifa.Rows.Count > 0)
            {



                dtServiciosPorTarifa = oTarifa.TraerServiciosPorTarifa(Convert.ToInt32(dtTarifa.Rows[0]["id"]));

                if (dtServiciosPorTarifa.Rows.Count > 0)
                {
                    try
                    {
                        foreach (DataRow fila in dtTipo_Facturacion.Rows)
                        {
                            oDs.Tables["CuadroTarifario"].Rows.Add(new object[] { "CATEGORÍA:", fila["nombre"].ToString(), "" });
                            oDs.Tables["CuadroTarifario"].Rows.Add(new object[] { "SERVICIOS", "MONTO", "" });

                            foreach (DataRow fila_servicio in dtServiciosPorTarifa.Rows)
                            {
                                if (fila_servicio["categoria"].ToString() == fila["nombre"].ToString())
                                {
                                    control = 1;
                                    oDs.Tables["CuadroTarifario"].Rows.Add(new object[] { "  " + fila_servicio["servicio"].ToString().ToLower(), "$" + fila_servicio["total_importe"].ToString(), "" });
                                }
                            }

                            if (control == 0)
                                oDs.Tables["CuadroTarifario"].Rows.Add(new object[] { "   SIN SERVICIOS", "--------", "" });
                            oDs.Tables["CuadroTarifario"].Rows.Add(new object[] { "---------------------------------", "---------------------------------", "" });
                            control = 0;
                        }




                        rpt.SetDataSource(oDs.Tables["CuadroTarifario"]);
                        rpt.SetParameterValue("FechaVigenciaDesde", dtTarifa.Rows[0]["Fecha_Desde"].ToString());
                        rpt.SetParameterValue("FechaVigenciaHasta", dtTarifa.Rows[0]["Fecha_Hasta"].ToString());

                        frm.oViewer.ReportSource = rpt;
                        frm.ShowDialog();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Se produjo un error durante la creación del reporte.");
                    }
                }
                else
                    MessageBox.Show("No hay servicios asociados a la tarifa vigente.");


            }
            else
                MessageBox.Show("No hay una tarifa vigente cargada.");



        }

        private void cargarImportes()
        {
            foreach (DataRow dr in dtServicios.Rows)
            {
                Int32 Id = Convert.ToInt32(dr["Id_Servicios"]);

                object sumMensual = dtTarifas_Sub.Compute("sum(Importe)", String.Format("Id_Servicios = {0} and Tipo = 'S'", Id));

                object sumTotal = dtTarifas_Sub.Compute("sum(Importe)", String.Format("Id_Servicios = {0} and Tipo <> 'S'", Id));

                if (sumTotal.ToString() == string.Empty)
                    sumTotal = 0;

                dr["Importe"] = sumMensual.ToString() == string.Empty ? 0 : Convert.ToDecimal(sumMensual.ToString());
                dr["Importe_Total"] = Convert.ToDecimal(dr["Importe"]) + Convert.ToDecimal(sumTotal.ToString());
            }

            dtServicios.AcceptChanges();

            dgvServicios.Refresh();

            dgvServicios.ClearSelection();
        }

        #endregion

        private void ABMTarifas_Sub_Load(object sender, EventArgs e)
        {
            comenzarCarga();
        }

        private void ABMTarifas_Sub_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                if (CambiosRealizados == false)
                    this.Close();
                else
                {
                    DialogResult dialogResult = MessageBox.Show("Hay cambios en los importes de sub servicios pendientes de ser guardados en el sistema. ¿Desea salir de todas formas?", "", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                        this.Close();
                }
            }
        }

        private void dgvSubServicios_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                CambiosRealizados = true;
                Int32 id = Convert.ToInt32(dgvSubServicios.Rows[e.RowIndex].Cells["Id"].Value.ToString());
                String tipo = dgvSubServicios.Rows[e.RowIndex].Cells["Tipo"].Value.ToString();

                DataRow[] curImporte = dtTarifas_Sub.Select(String.Format("Id = {0} and Tipo = '{1}' and Id_Servicios = {2}", id, tipo, Id_Current_Servicio));

                curImporte[0]["Importe"] = Convert.ToDecimal(dgvSubServicios.Rows[e.RowIndex].Cells["Importe"].Value.ToString());

                dtTarifas_Sub.AcceptChanges();

                cargarImportes();

            }
            catch { }

        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            this.comenzarCarga();
        }

        private void dgvServicios_SelectionChanged(object sender, EventArgs e)
        {

            try
            {
                DataGridView dgv = sender as DataGridView;

                if (dgv.SelectedRows.Count <= 0)
                    return;

                rowselect = dgv.SelectedRows[0].Index;

                DataGridViewRow row = dgv.SelectedRows[0];

                DataView dv = dtTarifas_Sub.DefaultView;


                Id_Current_Servicio = Convert.ToInt32(row.Cells["Id_Servicios"].Value.ToString());
                Servicio = row.Cells["Descripcion"].Value.ToString();
                Id_Grupo_Servicio = Convert.ToInt32(row.Cells["Id_Servicios_Grupos"].Value);

                Id_Servicios_Modalidad = Convert.ToInt32(row.Cells["Id_Servicios_Modalidad"].Value.ToString());
                idTipoFacturacion = Convert.ToInt32(row.Cells["Id_Tipo_Facturacion"].Value);
                //btnTarifas.Enabled = true;

                this._Requiere_Velocidades = row.Cells["Requiere_Velocidad"].Value.ToString() == "SI" ? true : false;
                this._Requiere_Servicio_Padre = row.Cells["Requiere_Servicio_Padre"].Value.ToString() == "1" ? true : false;
                this._Fecha_Inicio_Servicio = row.Cells["Fecha_Inicio_Servicio"].Value.ToString() == "1" ? true : false;

                lblServicioSeleccinado.Text = Servicio;

                switch (Id_Servicios_Modalidad)
                {
                    /// POR DIA
                    case 1:
                        this._ServicioModalidad = Servicios._Modalidad.DIA;
                        btnEspeciales.Enabled = true;
                        break;
                    /// POR MES
                    case 2:
                        this._ServicioModalidad = Servicios._Modalidad.MENSUAL;
                        btnEspeciales.Enabled = this._Requiere_Velocidades;
                        break;
                    /// POR PERIODO
                    case 3:
                        this._ServicioModalidad = Servicios._Modalidad.PERIODO;
                        btnEspeciales.Enabled = true;
                        break;
                    case 5:
                        this._ServicioModalidad = Servicios._Modalidad.PERIODO_CERRADO_POR_MES;
                        btnEspeciales.Enabled = true;
                        break;
                    case 6:
                        this._ServicioModalidad = Servicios._Modalidad.PERIODO_CERRADO_POR_DIA;
                        btnEspeciales.Enabled = true;
                        break;
                }

                dv.RowFilter = String.Format("Id_Servicios = {0}", Id_Current_Servicio);

                dtDtv = dv.ToTable();

                foreach (DataRow subServicio in dtDtv.Rows)
                {
                    if (Convert.ToInt32(subServicio["Tipo_SubServicio"]) == Convert.ToInt32(Servicios_Sub.SERVICIO_SUB_TIPOS.SUBSERVICIO) && (Id_Servicios_Modalidad != Convert.ToInt32(Servicios._Modalidad.MENSUAL) || (Id_Servicios_Modalidad == Convert.ToInt32(Servicios._Modalidad.MENSUAL) && this._Requiere_Velocidades == true)))
                        subServicio["Especial"] = "1";
                }


                dgvSubServicios.DataSource = dtDtv;
                dgvSubServicios.ReadOnly = false;
                dgvSubServicios.Columns["Id"].Visible = false;
                dgvSubServicios.Columns["Id_Servicios"].Visible = false;
                dgvSubServicios.Columns["Id_Tipo_Facturacion"].Visible = false;
                dgvSubServicios.Columns["Id_Tabla_Tipo"].Visible = false;
                dgvSubServicios.Columns["Tipo"].Visible = false;
                dgvSubServicios.Columns["Dias"].Visible = false;
                dgvSubServicios.Columns["Requiere_IP"].Visible = false;
                dgvSubServicios.Columns["Fecha_Desde"].Visible = false;
                dgvSubServicios.Columns["Fecha_Hasta"].Visible = false;
                dgvSubServicios.Columns["Tipo_SubServicio"].Visible = false;
                dgvSubServicios.Columns["Especial"].Visible = false;
                dgvSubServicios.Columns["Importe"].ReadOnly = false;
                dgvSubServicios.Columns["Importe"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvSubServicios.Columns["Descripcion_Tipo"].HeaderText = "Tipo";
                dgvSubServicios.Columns["Descripcion_Tipo"].DisplayIndex = 0;

                dgvSubServicios.Columns["Descripcion_Tipo"].ReadOnly = true;
                dgvSubServicios.Columns["Descripcion_Tipo"].Selected = false;
                dgvSubServicios.Columns["Descripcion"].ReadOnly = true;
                dgvSubServicios.Columns["Descripcion"].Selected = false;


                foreach (DataGridViewRow subServicio in dgvSubServicios.Rows)
                {
                    if (Convert.ToInt32(subServicio.Cells["Tipo_SubServicio"].Value) == Convert.ToInt32(Servicios_Sub.SERVICIO_SUB_TIPOS.SUBSERVICIO) && (Id_Servicios_Modalidad != Convert.ToInt32(Servicios._Modalidad.MENSUAL) || (Id_Servicios_Modalidad == Convert.ToInt32(Servicios._Modalidad.MENSUAL) && this._Requiere_Velocidades == true)))
                        subServicio.ReadOnly = true;
                }

                dgvSubServicios.CurrentCell = dgvSubServicios.Rows[0].Cells["Importe"];

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            //si el servicio es por periodo entonces primero tengo que buscar los datos del sub servicio 1 para traer las fechas desde y hasta
            int idSubServicioPadre = 0;
            if (Id_Servicios_Modalidad == Convert.ToInt32(Servicios._Modalidad.PERIODO_CERRADO_POR_MES))
            {
                DataView dvSubPadre = new DataView(dtDtv);
                dvSubPadre.RowFilter = "Tipo_SubServicio=" + 1;
                idSubServicioPadre = Convert.ToInt32(dvSubPadre[0]["id"]);
                DataTable dtDatosTarifaPadre = oTarifas_Esp.GetServicios_Tarifas_Sub_Esp(Convert.ToInt32(cboTarifas.SelectedValue), Id_Current_Servicio, idSubServicioPadre, idTipoFacturacion);
                if (dtDatosTarifaPadre.Rows.Count > 0)
                {
                    foreach (DataRow item in dtTarifas_Sub.Rows)
                    {
                        int idServicioItem = Convert.ToInt32(item["id_servicios"]);
                        if (idServicioItem == Id_Current_Servicio)
                        {
                            item["Fecha_Desde"] = Convert.ToDateTime(dtDatosTarifaPadre.Rows[0]["fecha_desde"]);
                            item["Fecha_Hasta"] = Convert.ToDateTime(dtDatosTarifaPadre.Rows[0]["fecha_hasta"]);
                        }
                    }
                }
            }

            oTarifa_Sub.Guardar(dtTarifas_Sub, Convert.ToInt32(cboTarifas.SelectedValue), Id_Tipo_Facturacion, Personal.Id_Login);
            CambiosRealizados = false;
            MessageBox.Show("Datos almacenados correctamente.");

            foreach (DataGridViewRow item in dgvServicios.Rows)
            {
                if (Convert.ToInt32(item.Cells["id_servicios"].Value) == Id_Current_Servicio)
                    item.Selected = true;
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            ImprimirCuadroTarifario();
        }

        private void cboTarifas_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //Id_Servicios_Tarifa = Convert.ToInt32(cboTarifas.SelectedValue);

                //DataRow[] drFilter = dtTarifas.Select(String.Format("Id = {0}", Id_Servicios_Tarifa));

                //txtDesde.Text = drFilter[0]["Fecha_Desde"].ToString();
                //txtHasta.Text = drFilter[0]["Fecha_Hasta"].ToString();
            }
            catch { }
        }

        private void btnTarifas_Click(object sender, EventArgs e)
        {
            if(dgvServicios.SelectedRows.Count>0)
            {
                using (frmPopUp frm = new frmPopUp())
                {
                    ABMTarifas_Sub_Esp frmEsp = new ABMTarifas_Sub_Esp();

                    frmEsp.Id_Servicios = this.Id_Current_Servicio;
                    frmEsp.Id_Tarifas = this.Id_Servicios_Tarifa;
                    frmEsp.Id_Tipo_Facturacion = Convert.ToInt32(cboTipo_Facturacion.SelectedValue);
                    frmEsp.Id_Servicios_Sub = Convert.ToInt32(dgvSubServicios.Rows[dgvSubServicios.SelectedCells[0].RowIndex].Cells["Id_Tabla_Tipo"].Value);
                    frmEsp.Servicio_Modalidad = this._ServicioModalidad;
                    frmEsp.Requiere_Velocidades = this._Requiere_Velocidades;
                    frmEsp.Requiere_Servicio_Padre = this._Requiere_Servicio_Padre;
                    frmEsp.Fecha_Inicio_Servicio = this._Fecha_Inicio_Servicio;
                    frmEsp.Servicio = this.Servicio;
                    frmEsp.SubServicio = dgvSubServicios.Rows[dgvSubServicios.SelectedCells[0].RowIndex].Cells["descripcion"].Value.ToString();
                    frmEsp.ImporteDiario = Convert.ToDecimal(dgvSubServicios.Rows[dgvSubServicios.SelectedCells[0].RowIndex].Cells["importe"].Value);
                    frmEsp.Id_Grupo_Servicio = this.Id_Grupo_Servicio;
                    frmEsp.OrigenMeses = Convert.ToInt32(dgvServicios.Rows[dgvServicios.SelectedCells[0].RowIndex].Cells["origenmeses"].Value);
                    frm.Maximizar = false;
                    frm.Formulario = frmEsp;
                    frm.ShowDialog();
                }
            }
        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            if (CambiosRealizados == false)
                this.Close();
            else
            {
                DialogResult dialogResult = MessageBox.Show("Hay cambios en los importes de sub servicios pendientes de ser guardados en el sistema. ¿Desea salir de todas formas?", "", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                    this.Close();
            }
        }

        private void dgvSubServicios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvSubServicios.Columns[e.ColumnIndex].Name.Equals("Importe") && dgvSubServicios.Rows[e.RowIndex].Cells["Especial"].Value.ToString() == "1")
            {
                MessageBox.Show("Este importe pertenece a un servicio con modalidad no mensual o es un servicio de internet. Para editarlo vaya al botón Especiales.");
            }
        }
    }
}
