using CapaNegocios;
using System;
using System.Data;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;


namespace CapaPresentacion.Abms
{
    //referencia campo especial: 0=subservicio comun - 1:velocidades - 2:modalidad x periodo
    public partial class ABMTarifas_Editor : Form
    {
        //publico 
        public Int32 idServicio, idTipoServicio, requiereVelocidad, idModalidad, idServicioSub, idTipoFacturacion, idTarifa;
        public String nombreServicio, nombreTipoServicio;
        public Boolean especial;
        public Boolean aumentoTipoServicio;
        public Boolean velocidad;
        public Decimal importeTotal;

        private delegate void myDel();
        private Thread hilo;


        private Int32 error, idNuevaTarifa, idUltimaTarifa, idGrupoServicio, mesesCobro, mesesServicio, idServicioBase, requiereServicioPadre, fechaInicioServicio;
        private Boolean CambiosRealizados = false;
        private Boolean espcial;
        private Boolean primeraTarifa = false;
        private Boolean aumSub, aumEquipos, aumPartes;
        private Boolean vigente = false;
        private DateTime fechaDesdeUltimaTarifa, fechaHastaUltimaTarifa;
        private DataTable dtTarifas = new DataTable();
        private DataTable dtTarifas_Sub = new DataTable();
        private DataTable dtDtv;
        private DataTable dtSubServicios = new DataTable();
        private DataRow drDatosNuevaTarifa;
        private DataRow drDatosUltimaTarifa;
        private Servicios._Modalidad _ServicioModalidad;
        private Servicios_Tarifas oTarifas = new Servicios_Tarifas();
        private Servicios_Sub oSub = new Servicios_Sub();
        private Servicios_Tarifas_Sub oServiciosTarifasSub = new Servicios_Tarifas_Sub();
        private Servicios oServicios = new Servicios();
        private Partes_Solicitudes oPartesFallas = new Partes_Solicitudes();
        private Equipos_Tipos oEquiposTipos = new Equipos_Tipos();
        private Servicios_Velocidades oVelocidades = new Servicios_Velocidades();
        private frmPopUp oPop;
        private DataTable dtVelocidades;
        private DataTable dtDatosServicio = new DataTable();
        private Decimal totalSubservicios;
        private decimal valorTemp;
        private void dgvServicios_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            //
        }

        private void btnRestablecer_Click(object sender, EventArgs e)
        {
            comenzarCarga();
        }

        private void dgvServicios_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvServicios_CellEnter(object sender, DataGridViewCellEventArgs e)
        {

            if ((Convert.ToInt32(dgvServicios.CurrentCell.ColumnIndex) == 25) && (Convert.ToInt32(dgvServicios.CurrentRow.Cells["id"].Value) == -1))
            {
                dgvServicios.CurrentCell.ReadOnly = true;

            }
        }

        private void btnGuardar2_Click(object sender, EventArgs e)
        {
            aumSub = chkSub.Checked;
            aumEquipos = chkEquipos.Checked;
            aumPartes = chkPartes.Checked;
            Decimal importeTipo;
            Decimal porcentajeTipo;
            Decimal.TryParse(txtImporteTipo.Text, out importeTipo);
            Decimal.TryParse(txtPorcentajeTipo.Text, out porcentajeTipo);
            if ((importeTipo > 0) || (porcentajeTipo > 0))
            {
                try
                {
                    oServiciosTarifasSub.GuardarAumentoTipoServicio(idTarifa, idTipoServicio, idTipoFacturacion, porcentajeTipo, importeTipo, aumSub, aumEquipos, aumPartes, Personal.Id_Login);
                }
                catch (Exception)
                {
                    MessageBox.Show("Hubo un problema al intentar cambiar el importe de las tarifas", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void pnlAumentoTipoServicio_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comenzarCarga()
        {
            hilo = new Thread(new ThreadStart(cargarDatos));
            hilo.Start();
        }

        private void cargarDatos()
        {
            try
            {
                dtDatosServicio = oServicios.BuscarDatosServicio(this.idServicio);
                if (idTarifa == 0)
                    dtTarifas = oTarifas.Listar();
                else
                {
                    dtTarifas = oTarifas.TraerDatosTarifa(idTarifa);
                    vigente = oTarifas.tarifaEsVigente(idTarifa);
                }

                switch (dtTarifas.Rows.Count)
                {
                    case 0:
                        MessageBox.Show("No hay ninguna tarifa cargada", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        error = 1;
                        break;
                    case 1:
                        primeraTarifa = true;
                        drDatosNuevaTarifa = dtTarifas.Rows[0];

                        break;
                    default:
                        DataRow[] drs = dtTarifas.Select(string.Format("id={0}", idNuevaTarifa));
                        drDatosNuevaTarifa = drs[0];
                        break;
                }
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
            if (error == 1)
                this.Close();
            else
            {
                if (aumentoTipoServicio != true)
                {
                    spcMain.Panel1Collapsed = false;
                    spcMain.Panel2Collapsed = true;
                    switch (idModalidad)
                    {
                        /// POR DIA
                        case 1:
                            this._ServicioModalidad = Servicios._Modalidad.DIA;
                            break;
                        /// POR MES
                        case 2:
                            this._ServicioModalidad = Servicios._Modalidad.MENSUAL;
                            break;
                        /// POR PERIODO
                        case 3:
                            this._ServicioModalidad = Servicios._Modalidad.PERIODO;
                            break;
                        case 5:
                            this._ServicioModalidad = Servicios._Modalidad.PERIODO_CERRADO_POR_MES;
                            break;
                        case 6:
                            this._ServicioModalidad = Servicios._Modalidad.PERIODO_CERRADO_POR_DIA;
                            break;
                    }
                    //DATOS DEL SERVICIO
                    idGrupoServicio = Convert.ToInt32(dtDatosServicio.Rows[0]["id_servicios_grupos"]);
                    requiereServicioPadre = Convert.ToInt32(dtDatosServicio.Rows[0]["requiere_servicio_padre"]);
                    fechaInicioServicio = Convert.ToInt32(dtDatosServicio.Rows[0]["fecha_inicio_servicio"]);
                    dgvServicios.ReadOnly = false;
                    lblTarifaNuevaDato.Text = drDatosNuevaTarifa["Nombre"].ToString();
                    lblDesdeDato2.Text = Convert.ToDateTime(drDatosNuevaTarifa["Fecha_Desde"]).ToShortDateString();
                    lblHastaDato2.Text = Convert.ToDateTime(drDatosNuevaTarifa["Fecha_Hasta"]).ToShortDateString();
                    totalSubservicios = 0;

                    if (this.velocidad == true)
                        btnAgregarVelocidad.Visible = true;
                    else
                        btnAgregarVelocidad.Visible = false;


                    if (idTarifa != 0)
                        btnEspeciales.Enabled = false;
                    //DATOS DE LA TARIFA
                    idNuevaTarifa = Convert.ToInt32(drDatosNuevaTarifa["id"]);
                    lblServicioDato.Text = nombreServicio;
                    //ESTRUCTURA DE LA TABLA PRINCIPAL
                    dtDtv = new DataTable();
                    dtTarifas_Sub.Clear();
                    dtTarifas_Sub.Columns.Clear();
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
                    dtTarifas_Sub.Columns.Add("Requiere_IP", typeof(Int32));
                    dtTarifas_Sub.Columns.Add("Tipo_SubServicio", typeof(Int32));
                    dtTarifas_Sub.Columns.Add("id_servicio_base", typeof(Int32));
                    dtTarifas_Sub.Columns.Add("id_velocidad", typeof(Int32));
                    dtTarifas_Sub.Columns.Add("id_velocidad_tipo", typeof(Int32));
                    dtTarifas_Sub.Columns.Add("dias_desde", typeof(Int32));
                    dtTarifas_Sub.Columns.Add("dias_hasta", typeof(Int32));
                    dtTarifas_Sub.Columns.Add("mes_facturacion", typeof(Int32));
                    dtTarifas_Sub.Columns.Add("meses_servicio", typeof(Int32));
                    dtTarifas_Sub.Columns.Add("meses_cobro", typeof(Int32));
                    dtTarifas_Sub.Columns.Add("mes_inicio", typeof(Int32));
                    dtTarifas_Sub.Columns.Add("mes_fin", typeof(Int32));
                    dtTarifas_Sub.Columns.Add("Especial", typeof(Int32));
                    dtTarifas_Sub.Columns.Add("Porcentaje", typeof(Decimal));
                    dtTarifas_Sub.Columns.Add("ImporteNuevo", typeof(Decimal));
                    dtTarifas_Sub.Columns.Add("total", typeof(Decimal));
                    dtTarifas_Sub.Clear();
                    if (idModalidad == Convert.ToInt32(Servicios._Modalidad.PERIODO) || (idModalidad == Convert.ToInt32(Servicios._Modalidad.PERIODO_CERRADO_POR_MES)) || (idModalidad == Convert.ToInt32(Servicios._Modalidad.PERIODO_CERRADO_POR_DIA)))
                        especial = true;
                    if (velocidad == false)
                        dtSubServicios = oSub.ListarPorServicio(idServicio);
                    else
                    {
                        dtVelocidades = oServiciosTarifasSub.ListarTarifasVel(idNuevaTarifa, idServicio, idTipoFacturacion, "S");
                        btnGuardar.Visible = true;
                    }

                    btnEspeciales.Visible = true;
                    //cabecera
                    DataRow drGeneral = dtTarifas_Sub.NewRow();
                    drGeneral["id"] = -2;
                    drGeneral["id_servicios"] = 0;
                    drGeneral["Id_Tipo_Facturacion"] = 0;
                    drGeneral["Descripcion"] = "APLICAR A TODOS LOS ITEMS";
                    //drGeneral["Importe"] = 0;
                    drGeneral["Id_Tabla_Tipo"] = 0;
                    drGeneral["Tipo"] = "";
                    drGeneral["Dias"] = 0;
                    drGeneral["Fecha_Desde"] = new DateTime();
                    drGeneral["Fecha_Hasta"] = new DateTime();
                    drGeneral["Descripcion_Tipo"] = 0;
                    drGeneral["Requiere_IP"] = 0;
                    drGeneral["Tipo_SubServicio"] = 0;
                    drGeneral["id_servicio_base"] = 0;
                    drGeneral["id_velocidad"] = 0;
                    drGeneral["id_velocidad_tipo"] = 0;
                    drGeneral["dias_desde"] = 0;
                    drGeneral["dias_hasta"] = 0;
                    drGeneral["mes_facturacion"] = 0;
                    drGeneral["meses_servicio"] = 0;
                    drGeneral["meses_cobro"] = 0;
                    drGeneral["mes_inicio"] = 0;
                    drGeneral["mes_fin"] = 0;
                    drGeneral["Fecha_Desde"] = fechaDesdeUltimaTarifa;
                    drGeneral["Fecha_Hasta"] = fechaHastaUltimaTarifa;
                    drGeneral["Especial"] = 0;
                    drGeneral["Porcentaje"] = 0;
                    //drGeneral["ImporteNuevo"] = 0;
                    dtTarifas_Sub.Rows.Add(drGeneral);

                    //traigo el importe de los subservicios 
                    //si velocidad==true quiere decir que estoy buscando velocidades,sino, subservicios comunes
                    if (velocidad == true)
                    {
                        if (dtVelocidades.Rows.Count > 0)
                        {
                            foreach (DataRow dr in dtVelocidades.Rows)
                            {
                                Decimal importe = 0;
                                try
                                {
                                    importe = Convert.ToDecimal(dr["Importe"]);
                                    totalSubservicios = totalSubservicios + importe;

                                }
                                catch
                                {
                                }
                                DataRow drVelocidad = dtTarifas_Sub.NewRow();
                                drVelocidad["id"] = Convert.ToInt32(dr["id_servicios_sub"]);
                                drVelocidad["id_servicios"] = idServicio;
                                drVelocidad["Id_Tipo_Facturacion"] = idTipoFacturacion;
                                drVelocidad["Descripcion"] = dr["velocidad"].ToString() + " " + dr["velocidad_tipo"].ToString();
                                drVelocidad["Importe"] = importe;
                                drVelocidad["Id_Tabla_Tipo"] = Convert.ToInt32(dr["id_servicios_sub"]);
                                drVelocidad["Tipo"] = "S";
                                drVelocidad["Dias"] = 0;
                                drVelocidad["Fecha_Desde"] = new DateTime();
                                drVelocidad["Fecha_Hasta"] = new DateTime();
                                drVelocidad["Descripcion_Tipo"] = "S";
                                drVelocidad["Requiere_IP"] = Convert.ToInt32(dr["requiere_ip"]);
                                drVelocidad["Tipo_SubServicio"] = Convert.ToInt32(dr["idtipodesub"]); ;
                                drVelocidad["id_servicio_base"] = Convert.ToInt32(dr["id_servicios_base"]);
                                drVelocidad["id_velocidad"] = Convert.ToInt32(dr["id_servicios_velocidad"]);
                                drVelocidad["id_velocidad_tipo"] = Convert.ToInt32(dr["id_servicio_velocidad_tip"]);
                                drVelocidad["dias_desde"] = 0;
                                drVelocidad["dias_hasta"] = 0;
                                drVelocidad["mes_facturacion"] = 0;
                                drVelocidad["meses_servicio"] = 0;
                                drVelocidad["meses_cobro"] = 0;
                                drVelocidad["mes_inicio"] = 0;
                                drVelocidad["mes_fin"] = 0;
                                drVelocidad["Fecha_Desde"] = fechaDesdeUltimaTarifa;
                                drVelocidad["Fecha_Hasta"] = fechaHastaUltimaTarifa;
                                drVelocidad["Especial"] = 1;
                                drVelocidad["Porcentaje"] = 0;
                                drVelocidad["ImporteNuevo"] = importe;
                                drVelocidad["total"] = this.importeTotal + importe;

                                dtTarifas_Sub.Rows.Add(drVelocidad);
                            }
                        }
                        else
                        {
                            DataRow drVelocidad = dtTarifas_Sub.NewRow();
                            drVelocidad["id"] = 0;
                            drVelocidad["id_servicios"] = 0;
                            drVelocidad["Id_Tipo_Facturacion"] = 0;
                            drVelocidad["Descripcion"] = "No hay tarifas de velocidades cargadas";
                            drVelocidad["Importe"] = 0;
                            drVelocidad["Id_Tabla_Tipo"] = 0;
                            drVelocidad["Tipo"] = "";
                            drVelocidad["Dias"] = 0;
                            drVelocidad["Fecha_Desde"] = new DateTime();
                            drVelocidad["Fecha_Hasta"] = new DateTime();
                            drVelocidad["Descripcion_Tipo"] = "";
                            drVelocidad["Requiere_IP"] = 0;
                            drVelocidad["Tipo_SubServicio"] = 0;
                            drVelocidad["id_servicio_base"] = 0;
                            drVelocidad["id_velocidad"] = 0;
                            drVelocidad["id_velocidad_tipo"] = 0;
                            drVelocidad["dias_desde"] = 0;
                            drVelocidad["dias_hasta"] = 0;
                            drVelocidad["mes_facturacion"] = 0;
                            drVelocidad["meses_servicio"] = 0;
                            drVelocidad["meses_cobro"] = 0;
                            drVelocidad["mes_inicio"] = 0;
                            drVelocidad["mes_fin"] = 0; ;
                            drVelocidad["Especial"] = 1;
                            drVelocidad["Porcentaje"] = 0;
                            drVelocidad["ImporteNuevo"] = 0;
                            drVelocidad["total"] = 0;
                            dtTarifas_Sub.Rows.Add(drVelocidad);
                        }
                    }
                    else
                    {
                        if (especial == true)
                        {

                            foreach (DataRow dr in dtSubServicios.Rows)
                            {
                                Decimal importe = 0;
                                try
                                {
                                    DataTable dtDatosTarifasEsp = oServiciosTarifasSub.ListarTarifasEsp(this.idNuevaTarifa, this.idServicio, Convert.ToInt32(dr["Id"]), this.idTipoFacturacion);
                                    if (dtDatosTarifasEsp.Rows.Count > 0)
                                    {

                                        importe = Convert.ToDecimal(dtDatosTarifasEsp.Rows[0]["importe"]);
                                        mesesCobro = Convert.ToInt32(dtDatosTarifasEsp.Rows[0]["meses_cobro"]);
                                        mesesServicio = Convert.ToInt32(dtDatosTarifasEsp.Rows[0]["meses_servicio"]);
                                        idServicioBase = Convert.ToInt32(dtDatosTarifasEsp.Rows[0]["id_servicios_base"]);
                                        totalSubservicios = totalSubservicios + importe;

                                    }
                                    else
                                    {
                                        importe = 0;
                                        mesesCobro = 0;
                                        mesesServicio = 0;
                                        idServicioBase = 0;
                                    }


                                }
                                catch
                                {
                                }
                                DataRow drSubservicio = dtTarifas_Sub.NewRow();
                                drSubservicio["id"] = Convert.ToInt32(dr["Id"]);
                                drSubservicio["id_servicios"] = idServicio;
                                drSubservicio["Id_Tipo_Facturacion"] = idTipoFacturacion;
                                drSubservicio["Descripcion"] = dr["Descripcion"].ToString();
                                drSubservicio["Importe"] = importe;
                                drSubservicio["Id_Tabla_Tipo"] = Convert.ToInt32(dr["Id"]);
                                drSubservicio["Tipo"] = "S";
                                drSubservicio["Dias"] = 0;
                                drSubservicio["Fecha_Desde"] = new DateTime();
                                drSubservicio["Fecha_Hasta"] = new DateTime();
                                drSubservicio["Descripcion_Tipo"] = "S";
                                if (dr["requiere_ip"].ToString() == "SI")
                                    drSubservicio["Requiere_IP"] = 1;
                                else
                                    drSubservicio["Requiere_IP"] = 0;
                                drSubservicio["Tipo_SubServicio"] = Convert.ToInt32(dr["id_servicios_sub_tipos"]);
                                drSubservicio["id_servicio_base"] = idServicioBase;
                                drSubservicio["id_velocidad"] = 0;
                                drSubservicio["id_velocidad_tipo"] = 0;
                                drSubservicio["dias_desde"] = 0;
                                drSubservicio["dias_hasta"] = 0;
                                drSubservicio["mes_facturacion"] = 0;
                                drSubservicio["meses_servicio"] = mesesServicio;
                                drSubservicio["meses_cobro"] = mesesCobro;
                                drSubservicio["mes_inicio"] = 0;
                                drSubservicio["mes_fin"] = 0;
                                drSubservicio["Fecha_Desde"] = fechaDesdeUltimaTarifa;
                                drSubservicio["Fecha_Hasta"] = fechaHastaUltimaTarifa;
                                drSubservicio["Especial"] = 0;
                                drSubservicio["Porcentaje"] = 0;
                                drSubservicio["ImporteNuevo"] = importe;
                                drSubservicio["total"] = importeTotal + importe;

                                dtTarifas_Sub.Rows.Add(drSubservicio);
                            }
                        }
                        else
                        {
                            if ((velocidad == false) && (especial == false))
                            {
                                foreach (DataRow dr in dtSubServicios.Rows)
                                {
                                    Decimal importe = 0;
                                    try
                                    {
                                        importe = Convert.ToDecimal(oServiciosTarifasSub.ObtienePrecio(idNuevaTarifa, idTipoFacturacion, idServicio, Convert.ToInt32(dr["Id"]), 0, 0, "S").Rows[0]["importe"]);
                                        totalSubservicios = totalSubservicios + importe;
                                    }
                                    catch
                                    {
                                    }
                                    DataRow drSubservicio = dtTarifas_Sub.NewRow();
                                    drSubservicio["id"] = Convert.ToInt32(dr["Id"]);
                                    drSubservicio["id_servicios"] = idServicio;
                                    drSubservicio["Id_Tipo_Facturacion"] = idTipoFacturacion;
                                    drSubservicio["Descripcion"] = dr["Descripcion"].ToString();
                                    drSubservicio["Importe"] = importe;
                                    drSubservicio["Id_Tabla_Tipo"] = Convert.ToInt32(dr["Id"]);
                                    drSubservicio["Tipo"] = "S";
                                    drSubservicio["Dias"] = 0;
                                    drSubservicio["Fecha_Desde"] = new DateTime();
                                    drSubservicio["Fecha_Hasta"] = new DateTime();
                                    drSubservicio["Descripcion_Tipo"] = "S";
                                    drSubservicio["Requiere_IP"] = Convert.ToInt32(dr["requiere_ip"]);
                                    drSubservicio["Tipo_SubServicio"] = Convert.ToInt32(dr["id_servicios_sub_tipos"]);
                                    if ((Convert.ToInt32(dr["id_servicios_sub_tipos"]) == 1) && (Convert.ToInt32(dr["requiere_ip"]) == 1))
                                        requiereVelocidad = 1;
                                    drSubservicio["id_servicio_base"] = 0;
                                    drSubservicio["id_velocidad"] = 0;
                                    drSubservicio["id_velocidad_tipo"] = 0;
                                    drSubservicio["dias_desde"] = 0;
                                    drSubservicio["dias_hasta"] = 0;
                                    drSubservicio["mes_facturacion"] = 0;
                                    drSubservicio["meses_servicio"] = 0;
                                    drSubservicio["meses_cobro"] = 0;
                                    drSubservicio["mes_inicio"] = 0;
                                    drSubservicio["mes_fin"] = 0;
                                    drSubservicio["Fecha_Desde"] = fechaDesdeUltimaTarifa;
                                    drSubservicio["Fecha_Hasta"] = fechaHastaUltimaTarifa;
                                    drSubservicio["Especial"] = 0;
                                    drSubservicio["Porcentaje"] = 0;
                                    drSubservicio["ImporteNuevo"] = importe;
                                    dtTarifas_Sub.Rows.Add(drSubservicio);
                                }
                                if (requiereVelocidad != 1)
                                {
                                    //AGREGO TOTAL DE SUBSERVICIOS
                                    DataRow drSubservicioTotal = dtTarifas_Sub.NewRow();
                                    drSubservicioTotal["id"] = -1;
                                    drSubservicioTotal["id_servicios"] = 0;
                                    drSubservicioTotal["Id_Tipo_Facturacion"] = 0;
                                    drSubservicioTotal["Descripcion"] = "TOTAL SUBSERVICIOS";
                                    drSubservicioTotal["Importe"] = totalSubservicios;
                                    drSubservicioTotal["Id_Tabla_Tipo"] = 0;
                                    drSubservicioTotal["Tipo"] = "";
                                    drSubservicioTotal["Dias"] = 0;
                                    drSubservicioTotal["Fecha_Desde"] = new DateTime();
                                    drSubservicioTotal["Fecha_Hasta"] = new DateTime();
                                    drSubservicioTotal["Descripcion_Tipo"] = "";
                                    drSubservicioTotal["Requiere_IP"] = 0;
                                    drSubservicioTotal["Tipo_SubServicio"] = 0;
                                    drSubservicioTotal["id_servicio_base"] = 0;
                                    drSubservicioTotal["id_velocidad"] = 0;
                                    drSubservicioTotal["id_velocidad_tipo"] = 0;
                                    drSubservicioTotal["dias_desde"] = 0;
                                    drSubservicioTotal["dias_hasta"] = 0;
                                    drSubservicioTotal["mes_facturacion"] = 0;
                                    drSubservicioTotal["meses_servicio"] = 0;
                                    drSubservicioTotal["meses_cobro"] = 0;
                                    drSubservicioTotal["mes_inicio"] = 0;
                                    drSubservicioTotal["mes_fin"] = 0;
                                    drSubservicioTotal["Especial"] = 0;
                                    drSubservicioTotal["Porcentaje"] = 0;
                                    drSubservicioTotal["ImporteNuevo"] = totalSubservicios;
                                    dtTarifas_Sub.Rows.Add(drSubservicioTotal);
                                }
                            }
                        }
                    }





                    //si no es algo especial, como por ejemplo velocidades, cargo los importe de los partesFallas y Equipos
                    if (this.velocidad == false)
                    {
                        foreach (DataRow dr in oPartesFallas.GetDatosServicios(idServicio, true).Rows)
                        {
                            Decimal importe = 0;
                            try
                            {
                                importe = Convert.ToDecimal(oServiciosTarifasSub.ObtienePrecio(idNuevaTarifa, idTipoFacturacion, idServicio, Convert.ToInt32(dr["Id"]), 0, 0, "P").Rows[0]["importe"]);
                            }
                            catch { }
                            DataRow drFallas = dtTarifas_Sub.NewRow();
                            drFallas["id"] = Convert.ToInt32(dr["Id"]);
                            drFallas["id_servicios"] = idServicio;
                            drFallas["Id_Tipo_Facturacion"] = idTipoFacturacion;
                            drFallas["Descripcion"] = dr["Nombre"].ToString();
                            drFallas["Importe"] = importe;
                            drFallas["Id_Tabla_Tipo"] = Convert.ToInt32(dr["Id"]);
                            drFallas["Tipo"] = "P";
                            drFallas["Dias"] = 0;
                            drFallas["Fecha_Desde"] = new DateTime();
                            drFallas["Fecha_Hasta"] = new DateTime();
                            drFallas["Descripcion_Tipo"] = "P";
                            drFallas["Requiere_IP"] = 0;
                            drFallas["Tipo_SubServicio"] = 0;
                            drFallas["id_servicio_base"] = 0;
                            drFallas["id_velocidad"] = 0;
                            drFallas["id_velocidad_tipo"] = 0;
                            drFallas["dias_desde"] = 0;
                            drFallas["dias_hasta"] = 0;
                            drFallas["mes_facturacion"] = 0;
                            drFallas["meses_servicio"] = 0;
                            drFallas["meses_cobro"] = 0;
                            drFallas["mes_inicio"] = 0;
                            drFallas["mes_fin"] = 0;
                            drFallas["Fecha_Desde"] = fechaDesdeUltimaTarifa;
                            drFallas["Fecha_Hasta"] = fechaHastaUltimaTarifa;
                            drFallas["Especial"] = 0;
                            drFallas["Porcentaje"] = 0;
                            drFallas["ImporteNuevo"] = importe;
                            dtTarifas_Sub.Rows.Add(drFallas);
                        }

                        foreach (DataRow dr in oEquiposTipos.ListarPorTipoServicios(idTipoServicio).Rows)
                        {
                            Decimal importe = 0;
                            try
                            {
                                importe = Convert.ToDecimal(oServiciosTarifasSub.ObtienePrecio(idNuevaTarifa, idTipoFacturacion, idServicio, Convert.ToInt32(dr["Id"]), 0, 0, "E").Rows[0]["importe"]);
                            }
                            catch { }
                            DataRow drEquiposTipos = dtTarifas_Sub.NewRow();
                            drEquiposTipos["id"] = Convert.ToInt32(dr["Id"]);
                            drEquiposTipos["id_servicios"] = idServicio;
                            drEquiposTipos["Id_Tipo_Facturacion"] = idTipoFacturacion;
                            drEquiposTipos["Descripcion"] = dr["Nombre"].ToString();
                            drEquiposTipos["Importe"] = importe;
                            drEquiposTipos["Id_Tabla_Tipo"] = Convert.ToInt32(dr["Id"]);
                            drEquiposTipos["Tipo"] = "E";
                            drEquiposTipos["Dias"] = 0;
                            drEquiposTipos["Fecha_Desde"] = new DateTime();
                            drEquiposTipos["Fecha_Hasta"] = new DateTime();
                            drEquiposTipos["Descripcion_Tipo"] = "E";
                            drEquiposTipos["Requiere_IP"] = 0;
                            drEquiposTipos["Tipo_SubServicio"] = 0;
                            drEquiposTipos["id_servicio_base"] = 0;
                            drEquiposTipos["id_velocidad"] = 0;
                            drEquiposTipos["id_velocidad_tipo"] = 0;
                            drEquiposTipos["dias_desde"] = 0;
                            drEquiposTipos["dias_hasta"] = 0;
                            drEquiposTipos["mes_facturacion"] = 0;
                            drEquiposTipos["meses_servicio"] = 0;
                            drEquiposTipos["meses_cobro"] = 0;
                            drEquiposTipos["mes_inicio"] = 0;
                            drEquiposTipos["mes_fin"] = 0;
                            drEquiposTipos["Fecha_Desde"] = fechaDesdeUltimaTarifa;
                            drEquiposTipos["Fecha_Hasta"] = fechaHastaUltimaTarifa;
                            drEquiposTipos["Especial"] = 0;
                            drEquiposTipos["Porcentaje"] = 0;
                            drEquiposTipos["ImporteNuevo"] = importe;
                            dtTarifas_Sub.Rows.Add(drEquiposTipos);
                        }
                    }
                    dtTarifas_Sub.AcceptChanges();
                    //lleno la grilla y la formateo
                    FormatearGrilla();

                    //aplico cual columna se puede editar
                    foreach (DataGridViewColumn item in dgvServicios.Columns)
                    {
                        if (((item.Name == "Porcentaje") || (item.Name == "ImporteNuevo")) && (idModalidad != 3) || (requiereVelocidad != 1))
                            item.ReadOnly = false;
                        else
                            item.ReadOnly = true;

                        if (this.velocidad == true) /// trae solo velocidades por lo tanto puede modificar
                            item.ReadOnly = false;

                    }
                }
                else
                {
                    //DATOS DEL SERVICIO
                    dgvServicios.ReadOnly = false;
                    lblTarifaNuevaDato.Text = drDatosNuevaTarifa["Nombre"].ToString();
                    lblDesdeDato2.Text = Convert.ToDateTime(drDatosNuevaTarifa["Fecha_Desde"]).ToShortDateString();
                    lblHastaDato2.Text = Convert.ToDateTime(drDatosNuevaTarifa["Fecha_Hasta"]).ToShortDateString();
                    lblTipoServicioDato.Text = this.nombreTipoServicio;
                    spcMain.Panel1Collapsed = true;
                    spcMain.Panel2Collapsed = false;
                }
            }
        }

        private void frmTarifasServicios_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            DataTable dtGuardar = dtTarifas_Sub.Copy();
            foreach (DataRow item in dtGuardar.Rows)
            {
                Int32 id = Convert.ToInt32(item["id"]);
                Int32 requiereIp = Convert.ToInt32(item["requiere_ip"]);
                Int32 meses_cobro = Convert.ToInt32(item["meses_cobro"]);
                if (((id == -2) || (id == -1)) || (requiereIp == 1) || (meses_cobro > 0))
                    item.Delete();
                else
                {
                    Decimal importeNuevo = Convert.ToDecimal(item["importeNuevo"]);
                    item["importe"] = importeNuevo;
                }
            }
            dtGuardar.AcceptChanges();
            if (velocidad == true)
            {
                DataTable dtGuardar2 = dtTarifas_Sub.Copy();
                foreach (DataRow item in dtGuardar2.Rows)
                {
                    Int32 id = Convert.ToInt32(item["id"]);
                    Int32 requiereIp = Convert.ToInt32(item["requiere_ip"]);
                    Int32 meses_cobro = Convert.ToInt32(item["meses_cobro"]);
                    if (((id == -2) || (id == -1)) || (meses_cobro > 0))
                        item.Delete();
                    else
                    {
                        Decimal importeNuevo = Convert.ToDecimal(item["importeNuevo"]);
                        item["importe"] = importeNuevo;
                    }
                }
                dtGuardar2.AcceptChanges();
                oServiciosTarifasSub.Guardar(dtGuardar2, idNuevaTarifa, idTipoFacturacion, 1, Personal.Id_Login);
            }
            if (especial == true)
            {
                DataTable dtGuardar3 = dtTarifas_Sub.Copy();
                foreach (DataRow item in dtGuardar3.Rows)
                {
                    Int32 id = Convert.ToInt32(item["id"]);
                    Int32 requiereIp = Convert.ToInt32(item["requiere_ip"]);
                    Int32 meses_cobro = Convert.ToInt32(item["meses_cobro"]);
                    if (((id == -2) || (id == -1)) || (meses_cobro > 0))
                        item.Delete();
                    else
                    {
                        Decimal importeNuevo = Convert.ToDecimal(item["importeNuevo"]);
                        item["importe"] = importeNuevo;
                    }
                }
                dtGuardar3.AcceptChanges();
                oServiciosTarifasSub.Guardar(dtGuardar3, idNuevaTarifa, idTipoFacturacion, 0, Personal.Id_Login);
            }
            if ((especial == false) || (velocidad == false))
                oServiciosTarifasSub.Guardar(dtGuardar, idNuevaTarifa, idTipoFacturacion, 0, Personal.Id_Login);


            CambiosRealizados = false;
            MessageBox.Show("Datos alamacenados correctamente.", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
            comenzarCarga();
        }

        private void dgvServicios_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                Decimal porcentajeAplicado = 0;
                Decimal importeViejo = 0;
                Decimal importeNew = 0;
                if (Convert.ToInt32(dgvServicios.CurrentRow.Cells["id"].Value) == -2)
                {
                    porcentajeAplicado = Convert.ToDecimal(dgvServicios.CurrentRow.Cells["porcentaje"].Value);
                    foreach (DataGridViewRow item in dgvServicios.Rows)
                    {
                        String idTipoSubServicio = item.Cells["Tipo_SubServicio"].Value.ToString();

                        if ((idTipoSubServicio == "1") && (requiereVelocidad != 1))
                        {
                            item.Cells["porcentaje"].Value = porcentajeAplicado;
                            importeViejo = Convert.ToDecimal(item.Cells["Importe"].Value);
                            importeNew = ((porcentajeAplicado * importeViejo) / 100) + importeViejo;
                            item.Cells["importeNuevo"].Value = importeNew;
                        }
                        else
                        {
                            if ((idTipoSubServicio == "1") && (idModalidad != Convert.ToInt32(Servicios._Modalidad.PERIODO)))
                            {
                                item.Cells["porcentaje"].Value = porcentajeAplicado;
                                importeViejo = Convert.ToDecimal(item.Cells["Importe"].Value);
                                importeNew = ((porcentajeAplicado * importeViejo) / 100) + importeViejo;
                                item.Cells["importeNuevo"].Value = importeNew;
                            }
                            else
                            {
                                if ((idTipoSubServicio != "1") && ((Convert.ToInt32(item.Cells["id"].Value) != -2)))
                                {
                                    item.Cells["porcentaje"].Value = porcentajeAplicado;
                                    importeViejo = Convert.ToDecimal(item.Cells["Importe"].Value);
                                    importeNew = ((porcentajeAplicado * importeViejo) / 100) + importeViejo;
                                    item.Cells["importeNuevo"].Value = importeNew;


                                }

                            }
                        }
                        if ((idTipoSubServicio == "1") && (requiereVelocidad == 1))
                        {
                            item.Cells["porcentaje"].Value = 0;
                            importeViejo = 0;
                            item.Cells["importeNuevo"].Value = 0;
                        }
                        else
                        {
                            if ((idTipoSubServicio == "1") && (idModalidad == Convert.ToInt32(Servicios._Modalidad.PERIODO)))
                            {
                                item.Cells["porcentaje"].Value = 0;
                                importeViejo = 0;
                                item.Cells["importeNuevo"].Value = 0;
                            }

                        }
                    }
                }
                else
                {
                    porcentajeAplicado = Convert.ToDecimal(dgvServicios.CurrentRow.Cells["porcentaje"].Value);
                    importeViejo = Convert.ToDecimal(dgvServicios.CurrentRow.Cells["importe"].Value);
                    if (porcentajeAplicado != 0)
                        dgvServicios.CurrentRow.Cells["importeNuevo"].Value = ((porcentajeAplicado * importeViejo) / 100) + importeViejo;


                }

                try
                {
                    CambiosRealizados = true;
                    Int32 id = Convert.ToInt32(dgvServicios.Rows[e.RowIndex].Cells["Id"].Value.ToString());
                    String tipo = dgvServicios.Rows[e.RowIndex].Cells["Tipo"].Value.ToString();

                    DataRow[] curImporte = dtTarifas_Sub.Select(String.Format("Id = {0} and Tipo = '{1}' and Id_Servicios = {2}", id, tipo, idServicio));
                    //if (curImporte.Length>0)
                    //    curImporte[0]["Importe"] = Convert.ToDecimal(dgvServicios.Rows[e.RowIndex].Cells["ImporteNuevo"].Value.ToString());

                    //dtTarifas_Sub.AcceptChanges();

                }
                catch (Exception x)
                {
                    throw;
                }

            }
            catch (Exception)
            {
                throw;

            }

            if ((especial == false) && (requiereVelocidad == 0))
            {
                foreach (DataGridViewRow item in dgvServicios.Rows)
                {
                    if (Convert.ToInt32(item.Cells["id"].Value) == -1)
                        item.DefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                }
            }
        }

        private void btnAgregarVelocidad_Click(object sender, EventArgs e)
        {
            ABMTarifas_Sub_Esp oFrmTarifaNuevaVelocidad = new ABMTarifas_Sub_Esp();
            oFrmTarifaNuevaVelocidad.Servicio = nombreServicio;
            oFrmTarifaNuevaVelocidad.SubServicio = nombreServicio;
            oFrmTarifaNuevaVelocidad.Id_Servicios = this.idServicio;
            oFrmTarifaNuevaVelocidad.Id_Tarifas = this.idNuevaTarifa;
            oFrmTarifaNuevaVelocidad.Id_Servicios_Sub = this.idServicioSub;
            oFrmTarifaNuevaVelocidad.Id_Grupo_Servicio = this.idGrupoServicio;
            oFrmTarifaNuevaVelocidad.Fecha_Inicio_Servicio = false;
            oFrmTarifaNuevaVelocidad.Requiere_Servicio_Padre = true;
            Servicios._Modalidad modalidad = (Servicios._Modalidad)idModalidad;

            oFrmTarifaNuevaVelocidad.Servicio_Modalidad = modalidad;
            oFrmTarifaNuevaVelocidad.Id_Tipo_Facturacion = this.idTipoFacturacion;
            oFrmTarifaNuevaVelocidad.Requiere_Velocidades = true;
            if (fechaInicioServicio == 0)
                oFrmTarifaNuevaVelocidad.Fecha_Inicio_Servicio = false;
            else
                oFrmTarifaNuevaVelocidad.Fecha_Inicio_Servicio = true;

            oFrmTarifaNuevaVelocidad.ImporteDiario = 0;
            oPop = new frmPopUp();
            oPop.Formulario = oFrmTarifaNuevaVelocidad;
            oPop.Maximizar = false;
            if (oPop.ShowDialog() == DialogResult.OK)
            {
                comenzarCarga();
            }
        }

        private void btnEspeciales_Click(object sender, EventArgs e)
        {
            if ((especial == false) && (requiereVelocidad == 1))
            {
                ABMTarifas_Editor oFrmTarifasEspeciales = new ABMTarifas_Editor();
                oFrmTarifasEspeciales.especial = false;
                oFrmTarifasEspeciales.idServicio = this.idServicio;
                oFrmTarifasEspeciales.idServicioSub = Convert.ToInt32(dgvServicios.CurrentRow.Cells["id"].Value);
                oFrmTarifasEspeciales.idTipoFacturacion = this.idTipoFacturacion;
                oFrmTarifasEspeciales.idTipoServicio = this.idTipoServicio;
                oFrmTarifasEspeciales.idNuevaTarifa = this.idNuevaTarifa;
                oFrmTarifasEspeciales.idUltimaTarifa = this.idUltimaTarifa;
                oFrmTarifasEspeciales.idModalidad = this.idModalidad;
                oFrmTarifasEspeciales.idServicioSub = this.idServicioSub;
                oFrmTarifasEspeciales.nombreServicio = this.nombreServicio;
                oFrmTarifasEspeciales.importeTotal = totalSubservicios;
                oFrmTarifasEspeciales.velocidad = true;
                oPop = new frmPopUp();
                oPop.Formulario = oFrmTarifasEspeciales;
                oPop.Maximizar = false;
                oPop.ShowDialog();
            }
            else
            {
                if ((especial == true) && (velocidad == false))
                {
                    ABMTarifas_Sub_Esp oFrmTarifaNuevaVelocidad = new ABMTarifas_Sub_Esp();
                    oFrmTarifaNuevaVelocidad.Servicio = nombreServicio;
                    oFrmTarifaNuevaVelocidad.SubServicio = nombreServicio;
                    oFrmTarifaNuevaVelocidad.Id_Servicios = this.idServicio;
                    oFrmTarifaNuevaVelocidad.Id_Tarifas = this.idNuevaTarifa;
                    oFrmTarifaNuevaVelocidad.Id_Servicios_Sub = this.idServicioSub;
                    oFrmTarifaNuevaVelocidad.Id_Grupo_Servicio = this.idGrupoServicio;
                    oFrmTarifaNuevaVelocidad.Fecha_Inicio_Servicio = false;
                    if (requiereServicioPadre == 0)
                        oFrmTarifaNuevaVelocidad.Requiere_Servicio_Padre = false;
                    else
                        oFrmTarifaNuevaVelocidad.Requiere_Servicio_Padre = true;
                    if (idModalidad == 3)
                        oFrmTarifaNuevaVelocidad.Servicio_Modalidad = Servicios._Modalidad.PERIODO;
                    if (idModalidad == 5)
                        oFrmTarifaNuevaVelocidad.Servicio_Modalidad = Servicios._Modalidad.PERIODO_CERRADO_POR_MES;
                    oFrmTarifaNuevaVelocidad.Id_Tipo_Facturacion = this.idTipoFacturacion;
                    if (requiereVelocidad == 0)
                        oFrmTarifaNuevaVelocidad.Requiere_Velocidades = false;
                    else
                        oFrmTarifaNuevaVelocidad.Requiere_Velocidades = true;
                    if (fechaInicioServicio == 0)
                        oFrmTarifaNuevaVelocidad.Fecha_Inicio_Servicio = false;
                    else
                        oFrmTarifaNuevaVelocidad.Fecha_Inicio_Servicio = true;

                    oFrmTarifaNuevaVelocidad.Id_Servicios_Sub = idServicioSub;

                    oFrmTarifaNuevaVelocidad.ImporteDiario = 0;
                    oPop = new frmPopUp();
                    oPop.Formulario = oFrmTarifaNuevaVelocidad;
                    oPop.Maximizar = false;
                    if (oPop.ShowDialog() == DialogResult.OK)
                    {
                        comenzarCarga();
                    }
                }
                else
                {
                    if ((especial == true) && (velocidad == true))
                    {
                        ABMTarifas_Editor oFrmTarifasEspeciales = new ABMTarifas_Editor();
                        oFrmTarifasEspeciales.especial = true;
                        oFrmTarifasEspeciales.idServicio = this.idServicio;
                        oFrmTarifasEspeciales.idServicioSub = Convert.ToInt32(dgvServicios.CurrentRow.Cells["id"].Value);
                        oFrmTarifasEspeciales.idTipoFacturacion = this.idTipoFacturacion;
                        oFrmTarifasEspeciales.idTipoServicio = this.idTipoServicio;
                        oFrmTarifasEspeciales.idNuevaTarifa = this.idNuevaTarifa;
                        oFrmTarifasEspeciales.idUltimaTarifa = this.idUltimaTarifa;
                        oFrmTarifasEspeciales.idModalidad = this.idModalidad;
                        oFrmTarifasEspeciales.idServicioSub = this.idServicioSub;
                        oFrmTarifasEspeciales.nombreServicio = this.nombreServicio;
                        oFrmTarifasEspeciales.velocidad = true;
                        oFrmTarifasEspeciales.importeTotal = totalSubservicios;

                        oPop = new frmPopUp();
                        oPop.Formulario = oFrmTarifasEspeciales;
                        oPop.Maximizar = false;
                        oPop.ShowDialog();
                    }
                }

            }
        }

        private void dgvServicios_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void AplicarPorcentaje(decimal porcentajeX)
        {
            foreach (DataGridViewRow item in dgvServicios.Rows)
            {
                int id = Convert.ToInt32(item.Cells["id"].Value);
                if (id != -2)
                {
                    item.Cells["porcentaje"].Value = porcentajeX;
                }
            }
        }

        private void dgvServicios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            String nameColumna = dgvServicios.Columns[e.ColumnIndex].Name.ToString();
            idServicioSub = Convert.ToInt32(dgvServicios.CurrentRow.Cells["id"].Value);
            if (dgvServicios.SelectedCells.Count > 0)
            {
                int idTipoSub = Convert.ToInt32(dgvServicios.CurrentRow.Cells["Tipo_SubServicio"].Value);
                if ((idTipoSub == 1) && ((requiereVelocidad == 1) || (idModalidad == Convert.ToInt32(Servicios._Modalidad.PERIODO)) || (idModalidad == Convert.ToInt32(Servicios._Modalidad.PERIODO_CERRADO_POR_DIA)) || (idModalidad == Convert.ToInt32(Servicios._Modalidad.PERIODO_CERRADO_POR_MES))))
                    btnEspeciales.Enabled = true;
                else
                    btnEspeciales.Enabled = false;
            }
            ValidarEdicion(nameColumna);

        }

        public ABMTarifas_Editor()
        {
            InitializeComponent();
        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmTarifasServicios_Load(object sender, EventArgs e)
        {
            comenzarCarga();
        }
        private void FormatearGrilla()
        {
            dgvServicios.DataSource = dtTarifas_Sub;
            foreach (DataGridViewColumn item in dgvServicios.Columns)
                item.Visible = false;
            dgvServicios.Columns["Descripcion"].Visible = true;
            dgvServicios.Columns["Importe"].Visible = true;
            dgvServicios.Columns["Porcentaje"].Visible = true;
            dgvServicios.Columns["ImporteNuevo"].Visible = true;
            if ((especial == true) || (velocidad == true))
            {
                dgvServicios.Columns["total"].Visible = false;
                dgvServicios.Columns["total"].HeaderText = "Valor total";
            }
            dgvServicios.Columns["Importe"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvServicios.Columns["Importe"].DefaultCellStyle.Format = "C";

            dgvServicios.Columns["Porcentaje"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvServicios.Columns["ImporteNuevo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvServicios.Columns["total"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvServicios.Columns["total"].DefaultCellStyle.Format = "C";


            foreach (DataGridViewRow item in dgvServicios.Rows)
            {
                if ((especial == false) && (requiereVelocidad != 1))
                {
                    if (Convert.ToInt32(item.Cells["id"].Value) == -1)
                        item.DefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                }
                if (Convert.ToInt32(item.Cells["id"].Value) == -2)
                {
                    item.DefaultCellStyle.BackColor = Color.FromArgb(45, 120, 120);
                    item.DefaultCellStyle.ForeColor = Color.White;
                }
                item.Height = 30;
            }


        }
        private void ValidarEdicion(string nombreColumna)
        {
            if ((vigente == true) || (DateTime.Now < Convert.ToDateTime(drDatosNuevaTarifa["Fecha_Desde"])))
            {

                int idTipoSubServicio = Convert.ToInt32(dgvServicios.CurrentRow.Cells["Tipo_SubServicio"].Value);
                idServicioBase = Convert.ToInt32(dgvServicios.CurrentRow.Cells["id_servicio_base"].Value);
                if ((idTipoSubServicio == 1) && ((idModalidad == Convert.ToInt32(Servicios._Modalidad.PERIODO) || (idModalidad == Convert.ToInt32(Servicios._Modalidad.PERIODO_CERRADO_POR_MES) || (idModalidad == Convert.ToInt32(Servicios._Modalidad.PERIODO_CERRADO_POR_DIA) || (requiereVelocidad == 1))))))
                {
                    if (((nombreColumna == "Porcentaje") || (nombreColumna == "ImporteNuevo")))
                    {
                        MessageBox.Show("Este importe pertenece a un servicio con modalidad no mensual o es un servicio de internet. Para editarlo vaya al botón Especiales.", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        btnEspeciales.Enabled = true;
                        btnEspeciales.Visible = true;
                        btnEspeciales.Focus();
                        idServicioSub = Convert.ToInt32(dgvServicios.CurrentRow.Cells["id"].Value);
                    }
                }
                else
                {
                    btnEspeciales.Enabled = false;
                    foreach (DataGridViewColumn item in dgvServicios.Columns)
                    {


                        if ((nombreColumna == "Porcentaje") || (nombreColumna == "ImporteNuevo"))
                        {
                            item.ReadOnly = false;

                        }
                        else
                            item.ReadOnly = true;



                    }
                }

            }
            else
            {
                if (this.velocidad == false)
                {
                    foreach (DataGridViewColumn item in dgvServicios.Columns)
                        item.ReadOnly = true;
                }
            }
        }
    }
}
