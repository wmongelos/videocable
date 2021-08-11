using CapaNegocios;
using CapaPresentacion.Herramientas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CapaPresentacion.Complementarias
{
    public partial class frmCambioServicio : Form
    {
        private enum FILTRO_SERVICIO
        {
            TIPO = 0,
            GRUPO = 1
        }

        private enum FILTRO_MODALIDAD
        {
            MISMA = 0,
            TODAS = 1
        }

        private readonly Color COLOR_HABILITADO = Color.ForestGreen;
        private readonly Color COLOR_ADVERTENCIA = Color.DarkGoldenrod;
        private readonly Color COLOR_RESTRINGIDO = Color.Tomato;
        private readonly Configuracion oConfig = new Configuracion();
   
        private FILTRO_SERVICIO filtroServicio = FILTRO_SERVICIO.TIPO;
        private FILTRO_MODALIDAD filtroModalidad = FILTRO_MODALIDAD.MISMA;
        private int idUsuarioServicio;
        private DataTable dtDatosServicioActual;
        private DataTable dtConfiguracionCondiciones;
        private DataTable dtUsuarioServicio;
        private DataTable dtUsuarioServicioSub;
        private DataTable dtUsuarioServicioEquipo;
        private DataTable dtServiciosSub;
        private DataTable dtPartesAbiertos;
        private DataTable dtDeudas;
        private int idServicioActual;
        private int idTipoFacturacionActual;
        private int idVelocidadActual;
        private int idTipoVelocidadActual;
        private int idServicioTipoNuevo;
        private bool requiereVelocidadActual;
        private bool estadoDelServicioEsInvalido = false;
        private bool tienePlasticoAsociado = false; 
        private bool tienePartesAbiertos = false;
        private bool tieneDeuda = false;
        private bool asociadoAppExterna = false;
        private bool estadoDeLosEquiposEsInvalido = false;
        private List<Tuple<int, int>> idsServiciosSubs_idsServiciosSubsTipos;
        private Operaciones_Condiciones_Rel.Estados estadoPlasticoAsociado;
        private Operaciones_Condiciones_Rel.Estados estadoPartesAbiertos;
        private Operaciones_Condiciones_Rel.Estados estadoPresentaDeuda;
        private Operaciones_Condiciones_Rel.Estados estadoAsociadoAppExterna;
        private StringBuilder sbAdvertencias;

        private bool servicioOrigenTieneEquipo = false;
        private bool servicioDestinoRequiereEquipo = false;


        public frmCambioServicio(int idUsuarioServicio)
        {
            InitializeComponent();
            this.idUsuarioServicio = idUsuarioServicio;
        }

        private void frmCambioServicio_Load(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            cargarDatos();
            Cursor = Cursors.Default;
        }
               
        private void cargarDatos()
        {
            dtUsuarioServicio = new Usuarios_Servicios().Traer_datos_usuarios_servicios(idUsuarioServicio);
            idServicioActual = Convert.ToInt32(dtUsuarioServicio.Rows[0]["id_servicios"]);
            dtDatosServicioActual = new Servicios().BuscarDatosServicio(idServicioActual);

            if (dtUsuarioServicio.Rows.Count == 0)
            {
                MessageBox.Show("No se encontraron los datos del servicio", "Mensaje del sistema");
                return;
            }

            lblTipoServActual.Text = $"Tipo de servicio actual: {dtUsuarioServicio.Rows[0]["tiposervicio"]}";
            lblServicioActual.Text = $"Servicio actual: {dtUsuarioServicio.Rows[0]["servicio"]}";

            //Datos del servicio actual
            MostrarServiciosSubActuales();
            VerificarDatosDelServicio();
            VerificarSiTieneEquipo();

            //Condiciones configurables
            CargarConfiguracionDeCondiciones();
            VerificarSiEstaAsociadoAUnaAppExterna();
            VerificarSiTienePartesSinCerrar();
            VerificarSiTienePlasticoAsociado();
            VerificarSiTieneDeuda();

            //Seleccion de nuevo servicio
            dtServiciosSub = new Servicios_Sub().Listar();
            dtServiciosSub.Columns.Add(new DataColumn("elegir", typeof(bool)) { DefaultValue = false, ReadOnly = false });
            CargarSeleccionDeServicios();
            CargarFallas();

            if (EsValidoParaCambiar())
            {
                btnCambiar.Enabled = true;
            }
        }

        private void CargarConfiguracionDeCondiciones()
        {
            dtConfiguracionCondiciones = new Operaciones_Condiciones_Rel()
                .Listar(Convert.ToInt32(Partes.Partes_Operaciones.CAMBIO_DE_SERVICIO));
        }

        private void VerificarDatosDelServicio()
        {
            int idServicioEstado = Convert.ToInt32(dtUsuarioServicio.Rows[0]["id_servicios_estados"]);
            DataTable serviciosEstados = Tablas.DataServicios_Estados;
            serviciosEstados.DefaultView.RowFilter = $"id = {Convert.ToInt32(dtUsuarioServicio.Rows[0]["id_servicios_estados"])}";
            string estado = serviciosEstados.DefaultView.ToTable().Rows[0]["Estado"].ToString();

            if (idServicioEstado == Convert.ToInt32(Servicios.Servicios_Estados.CONECTADO) ||
                idServicioEstado == Convert.ToInt32(Servicios.Servicios_Estados.EN_ESPERA) ||
                idServicioEstado == Convert.ToInt32(Servicios.Servicios_Estados.SIN_CONECTAR))
            {
                estadoDelServicioEsInvalido = false;
                lblEstadoServActual.Text = $"Estado del servicio actual: {estado}; habilitado para cambiar";
                lblEstadoServActual.ForeColor = Color.ForestGreen;
                LblEstadoServ.ForeColor = Color.ForestGreen;
            }
            else
            {
                estadoDelServicioEsInvalido = true;
                lblEstadoServActual.Text = $"Estado del servicio actual: {estado}; no habilitado para cambiar";
                lblEstadoServActual.ForeColor = Color.Tomato;
                LblEstadoServ.ForeColor = Color.Tomato;
            }

            DateTime fechaFacturado = Convert.ToDateTime(dtUsuarioServicio.Rows[0]["Fecha_factura"]);
            lblFechaFacturado.Text = $"Facturado hasta: {fechaFacturado.Date.ToString("dd/MM/yyyy")}";
        }

        private void VerificarSiEstaAsociadoAUnaAppExterna()
        {
            estadoAsociadoAppExterna = GetEstadoDeLaCondicion(Operaciones_Condiciones.Condiciones.ASOCIADO_A_UNA_APP_EXTERNA);
            Color colorLabel = GetColorDeEstado(estadoAsociadoAppExterna);
            string icon = GetIconChar(estadoAsociadoAppExterna);

            int idAppExterna = Convert.ToInt32(dtDatosServicioActual.Rows[0]["id_aplicaciones_externas"]);
            if (idAppExterna == Convert.ToInt32(Aplicaciones_Externas.Aplicacion_Externa.ISP) ||
                idAppExterna == Convert.ToInt32(Aplicaciones_Externas.Aplicacion_Externa.CASS))
            {
                asociadoAppExterna = true;
                lblISP.Text = "Asociado a aplicacion externa";
                lblISP.ForeColor = colorLabel;
                LblAsociadoAppExterna.Text = icon;
                LblAsociadoAppExterna.ForeColor = colorLabel;
                //iconAsociadoAppExterna.IconChar = icon;
                //iconAsociadoAppExterna.ForeColor = colorLabel;
            }
            else
            {
                asociadoAppExterna = false;
                lblISP.Text = "No asociado a aplicacion externa";
                lblISP.ForeColor = COLOR_HABILITADO;
            }
        }

        private void VerificarSiTieneEquipo()
        {
            dtUsuarioServicioEquipo = new Usuarios_Servicios_Equipos().Listar(idUsuarioServicio);
            dgvEquipos.DataSource = dtUsuarioServicioEquipo;

            if (dtUsuarioServicioEquipo.Rows.Count == 0)
            {
                lblNoTieneEquipos.Visible = true;
                lblAsignado.Visible = false;
                lblPendienteAsignacion.Visible = false;
                estadoDeLosEquiposEsInvalido = false;
            }
            else
                servicioOrigenTieneEquipo = true;

            foreach (DataGridViewColumn col in dgvEquipos.Columns)
            {
                col.Visible = false;
            }

            dgvEquipos.Columns["serie"].Visible = true;
            dgvEquipos.Columns["serie"].HeaderText = "Serie";
            dgvEquipos.Columns["mac"].Visible = true;
            dgvEquipos.Columns["mac"].HeaderText = "Mac";
            dgvEquipos.Columns["equipo_estado"].Visible = true;
            dgvEquipos.Columns["equipo_estado"].HeaderText = "Equipo estado";
            dgvEquipos.Columns["equipo_marca"].Visible = true;
            dgvEquipos.Columns["equipo_marca"].HeaderText = "Equipo marca";
            dgvEquipos.Columns["equipo_modelo"].Visible = true;
            dgvEquipos.Columns["equipo_modelo"].HeaderText = "Equipo modelo";
            dgvEquipos.Columns["equipo_tipo"].Visible = true;
            dgvEquipos.Columns["equipo_tipo"].HeaderText = "Equipo tipo";
        }

        private void VerificarSiTienePartesSinCerrar()
        {
            int idUsuarioLocacion = Convert.ToInt32(dtUsuarioServicio.Rows[0]["id_usuarios_locaciones"]);
            dtPartesAbiertos = new Partes().ListarPartesAbiertos(idUsuarioLocacion, 0, idUsuarioServicio);

            estadoPartesAbiertos = GetEstadoDeLaCondicion(Operaciones_Condiciones.Condiciones.TIENE_PARTES_ABIERTOS);
            Color colorLabel = GetColorDeEstado(estadoPartesAbiertos);
            string icon = GetIconChar(estadoPartesAbiertos);

            if (dtPartesAbiertos.Rows.Count > 0)
            {
                tienePartesAbiertos = true;
                lblPartesAbiertos.Text = "El usuario tiene partes abiertos";
                lblPartesAbiertos.ForeColor = colorLabel;
                //iconPartesAbiertos.IconChar = icon;
                //iconPartesAbiertos.ForeColor = colorLabel;


                Lbl_PartesAbiertos.Text = icon;
                Lbl_PartesAbiertos.ForeColor = colorLabel;
            }
            else
            {
                lblPartesAbiertos.ForeColor = COLOR_HABILITADO;
                tienePartesAbiertos = false;
                lblPartesAbiertos.Text = "El usuario no tiene partes abiertos";
            }
        }

        private void VerificarSiTienePlasticoAsociado()
        {
            tienePlasticoAsociado = new Plasticos_Usuarios().BuscarPlasticosServicio(idUsuarioServicio).Rows.Count > 0;

            estadoPlasticoAsociado = GetEstadoDeLaCondicion(Operaciones_Condiciones.Condiciones.ASOCIADO_A_UN_PLASTICO);
            Color colorLabel = GetColorDeEstado(estadoPlasticoAsociado);
            string icon = GetIconChar(estadoPlasticoAsociado);

            if (tienePlasticoAsociado)
            {
                lblPlasticos.Text = "El servicio esta asociado a un débito";
                lblPlasticos.ForeColor = colorLabel;
                //iconPlasticoAsociado.IconChar = icon;
                //iconPlasticoAsociado.ForeColor = colorLabel;

                LblPlasticoAsociado.Text = icon;
                LblPlasticoAsociado.ForeColor = colorLabel;
            }
            else
            {
                lblPlasticos.ForeColor = COLOR_HABILITADO;
                lblPlasticos.Text = "Servicio no asociado a ningun débito";
            }
        }

        private void VerificarSiTieneDeuda()
        {
            dtDeudas = new Usuarios_CtaCte().ListarDeudaDeUsuarioServicio(idUsuarioServicio);

            estadoPresentaDeuda = GetEstadoDeLaCondicion(Operaciones_Condiciones.Condiciones.PRESENTA_DEUDA);
            Color colorLabel = GetColorDeEstado(estadoPresentaDeuda);
            var icon = GetIconChar(estadoPresentaDeuda);

            if (dtDeudas.Rows.Count == 0)
            {
                tieneDeuda = false;
                lblPresentaDeuda.Text = "El servicio no tiene deudas";
                lblPresentaDeuda.ForeColor = COLOR_HABILITADO;
            }
            else
            {
                tieneDeuda = true;
                string sumaSaldo = dtDeudas.Compute("sum(importe_saldo)", "importe_saldo > 0").ToString();
                lblPresentaDeuda.Text = $"El servicio presenta deudas: ${sumaSaldo}";
                lblPresentaDeuda.ForeColor = colorLabel;
                //iconPresentaDeuda.IconChar = icon;
                //iconPresentaDeuda.ForeColor = colorLabel;

                Lbl_PresentaDeuda.Text = icon;
                Lbl_PresentaDeuda.ForeColor = colorLabel;
            }
        }

        private void MostrarServiciosSubActuales()
        {
            DataTable dtDatosSubServicios = new Usuarios_Servicios().ListarServiciosSub(idUsuarioServicio, traerInactivos: true);
            dtUsuarioServicioSub = new DataTable();
            DataColumn dcDescripcion = new DataColumn("descripcion", typeof(string));
            dtUsuarioServicioSub.Columns.Add(dcDescripcion);
            DataColumn dcVel = new DataColumn("velocidad", typeof(string)) { DefaultValue = " - " };
            dtUsuarioServicioSub.Columns.Add(dcVel);
            DataColumn dcVelTipo = new DataColumn("tipo_velocidad", typeof(string)) { DefaultValue = " - " };
            dtUsuarioServicioSub.Columns.Add(dcVelTipo);
            DataColumn dcTipo = new DataColumn("id_servicios_sub_tipos", typeof(string)) { DefaultValue = " - " };
            dtUsuarioServicioSub.Columns.Add(dcTipo);
            DataColumn dcEstado = new DataColumn("estado", typeof(int));
            dtUsuarioServicioSub.Columns.Add(dcEstado);
            DataColumn dcServicio = new DataColumn("id_servicio_inactivo", typeof(int)) { DefaultValue = 0 };
            dtUsuarioServicioSub.Columns.Add(dcServicio);

            foreach (DataRow row in dtDatosSubServicios.Rows)
            {
                DataRow newRow = dtUsuarioServicioSub.NewRow();
                newRow["descripcion"] = row["descripcion"];
                newRow["id_servicios_sub_tipos"] = row["id_servicios_sub_tipos"];
                newRow["estado"] = row["borrado"];
                if (Convert.ToInt32(row["id_servicios_velocidades_tip"]) > 0 &&
                    Convert.ToInt32(row["id_servicios_velocidades"]) > 0)
                {
                    DataTable dtDatosVelocidad = new Servicios_Velocidades().ListarDatosVelocidades(Convert.ToInt32(row["id_servicios_velocidades"]), Convert.ToInt32(row["id_servicios_velocidades_tip"]));
                    if(dtDatosVelocidad.Rows.Count > 0)
                    {
                        newRow["velocidad"] = dtDatosVelocidad.Rows[0]["velocidad"];
                        newRow["tipo_velocidad"] = dtDatosVelocidad.Rows[0]["nombre"];
                        idVelocidadActual = Convert.ToInt32(dtDatosVelocidad.Rows[0]["id_velocidad"]);
                        idTipoVelocidadActual = Convert.ToInt32(dtDatosVelocidad.Rows[0]["id_velocidad_tipo"]);
                    }
                }
                if(Convert.ToInt32(row["borrado"]) == Convert.ToInt32(Borrados.Estado.Inactivo))
                {
                    int idServicioSub = Convert.ToInt32(row["id_servicios_sub"]);
                    int idServ = Convert.ToInt32(new Servicios_Sub().TraerDatosSubServicio(idServicioSub)["Id_Servicios"]);
                    newRow["id_servicio_inactivo"] = idServ;
                }
                dtUsuarioServicioSub.Rows.Add(newRow);
            }

            dgvSubServiciosActuales.DataSource = dtUsuarioServicioSub;

            foreach (DataGridViewColumn col in dgvSubServiciosActuales.Columns)
                col.Visible = false;

            dgvSubServiciosActuales.Columns["descripcion"].Visible = true;
            dgvSubServiciosActuales.Columns["velocidad"].Visible = true;
            dgvSubServiciosActuales.Columns["tipo_velocidad"].Visible = true;
            dgvSubServiciosActuales.Columns["descripcion"].HeaderText = "Subservicio";
            dgvSubServiciosActuales.Columns["velocidad"].HeaderText = "Velocidad";
            dgvSubServiciosActuales.Columns["tipo_velocidad"].HeaderText = "Tipo";
        }

        private void CargarSeleccionDeServicios()
        {
            if(oConfig.GetValor_N("Id_Tipo_Facturacion") != Convert.ToInt32(Tipo_Facturacion.Id_Tipo_Facturacion.POR_ZONAS))
            {
                idTipoFacturacionActual = Convert.ToInt32(dtUsuarioServicio.Rows[0]["id_tipo_facturacion"]);
            }
            else
            {
                int idUsuarioLocacion = Convert.ToInt32(dtUsuarioServicio.Rows[0]["id_usuarios_locaciones"]);
                int idLocalidad = new Usuarios_Locaciones().GetLocacion(idUsuarioLocacion).Id_Localidades;
                DataTable dtZonaLocalidad = new Localidades().ListarLocalidad_Zona(idLocalidad);
                if (dtZonaLocalidad.Rows.Count > 0)
                    idTipoFacturacionActual = Convert.ToInt32(new Localidades().ListarLocalidad_Zona(idLocalidad).Rows[0]["Id_zona"]);
                else
                {
                    MessageBox.Show("Error: Datos de la zona y localidad no encontrados", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            int idModalidad = Convert.ToInt32(dtDatosServicioActual.Rows[0]["id_servicios_modalidad"]);
            string reqVelocidad = dtDatosServicioActual.Rows[0]["requiere_velocidad"].ToString();
            DataTable dtServicios = new Servicios().ListarPorTipoFacturacion(idTipoFacturacionActual);
            requiereVelocidadActual = reqVelocidad.ToLower().Equals("si");
            DataView viewServicios = new DataView(dtServicios);

            string filtroSegunModalidad, filtroSegunServicio;
            if (filtroModalidad == FILTRO_MODALIDAD.MISMA)
                filtroSegunModalidad = $"id_servicios_modalidad = {idModalidad} AND";
            else
                filtroSegunModalidad = "";

            if (filtroServicio == FILTRO_SERVICIO.GRUPO)
                filtroSegunServicio = $"id_servicios_grupos = {Convert.ToInt32(dtUsuarioServicio.Rows[0]["id_servicios_grupo"])} AND";
            else
                filtroSegunServicio = $"id_servicios_tipos = {Convert.ToInt32(dtUsuarioServicio.Rows[0]["id_servicios_tipo"])} AND";

            viewServicios.RowFilter = $"{filtroSegunModalidad} {filtroSegunServicio} requiere_velocidad = '{reqVelocidad}'";
            dtServicios = viewServicios.ToTable();

            cboServicios.DataSource = dtServicios;
            cboServicios.DisplayMember = "Descripcion";
            cboServicios.ValueMember = "Id_servicios";
            cboServicios.SelectedIndexChanged += cboSubservicios_SelectedIndexChanged;
            cboSubservicios_SelectedIndexChanged(cboServicios, new EventArgs());
        }

        private void CargarFallas()
        {
            Partes_Solicitudes oPartesSolicitudes = new Partes_Solicitudes();
            cboParteFalla.DataSource = oPartesSolicitudes.GetFallasPorTipoServYOp(Convert.ToInt32(dtUsuarioServicio.Rows[0]["id_servicios_tipo"]),
                Convert.ToInt32(Partes.Partes_Operaciones.CAMBIO_DE_SERVICIO));
            cboParteFalla.ValueMember = "id";
            cboParteFalla.DisplayMember = "Nombre";
        }

        private bool EsValidoParaCambiar()
        {
            sbAdvertencias = new StringBuilder();

            if ((asociadoAppExterna && estadoAsociadoAppExterna == Operaciones_Condiciones_Rel.Estados.Restringido) ||
                (tienePlasticoAsociado && estadoPlasticoAsociado == Operaciones_Condiciones_Rel.Estados.Restringido) ||
                (tieneDeuda && estadoPresentaDeuda == Operaciones_Condiciones_Rel.Estados.Restringido) ||
                (tienePartesAbiertos && estadoPartesAbiertos == Operaciones_Condiciones_Rel.Estados.Restringido))
                return false;

            if (asociadoAppExterna && estadoAsociadoAppExterna == Operaciones_Condiciones_Rel.Estados.Advertencia)
                sbAdvertencias.Append("El servicio actual esta asociado a una aplicacion externa.\n");
            if (tienePlasticoAsociado && estadoPlasticoAsociado == Operaciones_Condiciones_Rel.Estados.Advertencia)
                sbAdvertencias.Append("El servicio actual esta asociado a un debito.\n");
            if (tieneDeuda && estadoPresentaDeuda == Operaciones_Condiciones_Rel.Estados.Advertencia)
                sbAdvertencias.Append("El servicio actual tiene deuda.\n");
            if (tienePartesAbiertos && estadoPartesAbiertos == Operaciones_Condiciones_Rel.Estados.Advertencia)
                sbAdvertencias.Append("El servicio actual tiene partes sin cerrar.\n");

            return true;
        }

        private bool SeleccionarVelocidades(out int idVel, out int idVelTipo)
        {
            int idServVelocidad = 0;
            int idServelocidadTipo = 0;
            int idServicioSub = 0;
            idVel = 0;
            idVelTipo = 0;
            DataTable dtSubs = new Usuarios_Servicios().ListarServiciosSub(idUsuarioServicio);
            foreach (DataRow row in dtSubs.Rows)
            {
                if(Convert.ToInt32(row["id_servicios_velocidades"]) > 0)
                {
                    idServVelocidad = Convert.ToInt32(row["id_servicios_velocidades"]);
                    idServelocidadTipo = Convert.ToInt32(row["id_servicios_velocidades_tip"]);
                    idServicioSub = Convert.ToInt32(row["id_servicios_sub"]);
                }
            }

            int idSubServicioSeleccionado = idsServiciosSubs_idsServiciosSubsTipos
                .Where(val => val.Item2 == Convert.ToInt32(Servicios_Sub.SERVICIO_SUB_TIPOS.SUBSERVICIO))
                .Select(tuple => tuple.Item1)
                .FirstOrDefault();
            //var rows = new Servicios_Tarifas_Sub_Esp().GetServicios_Tarifas_Sub_Esp(new Servicios_Tarifas().getTarifaId(), Convert.ToInt32(cboServicios.SelectedValue), idSubServicioSeleccionado, idTipoFacturacionActual)
            //    .AsEnumerable()
            //    .Where(dr => dr.Field<int>("id_servicios_velocidad") == idServVelocidad &&
            //                 dr.Field<int>("id_servicios_velocidad_tip") == idServelocidadTipo);

            //if (!rows.Any())
            //{
                frmPopUp popUp = new frmPopUp();
                frmSeleccionDeVelocidad frmSelecVelocidad = new frmSeleccionDeVelocidad(Convert.ToInt32(cboServicios.SelectedValue), idSubServicioSeleccionado, idTipoFacturacionActual);
                popUp.Formulario = frmSelecVelocidad;
                popUp.Maximizar = false;
                if (popUp.ShowDialog() == DialogResult.OK)
                {
                    idVel = frmSelecVelocidad.idVelocidad;
                    idVelTipo = frmSelecVelocidad.idVelocidadTipo;
                    return true;
                }
                else
                    return false;
            //}
            //return true;
        }

        private void dgvEquipos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if(Convert.ToInt32(dgvEquipos.Rows[e.RowIndex].Cells["id_equipo_estado"].Value) ==
                Convert.ToInt32(Equipos.Equipos_Estados.ASIGNADO_A_USUARIO))
            {
                e.CellStyle.BackColor = Color.ForestGreen;
            }
            else
            {
                e.CellStyle.BackColor = Color.Tomato;
                estadoDeLosEquiposEsInvalido = true;
            }
        }

        private void cboSubservicios_SelectedIndexChanged(object sender, EventArgs e)
        {
            dtServiciosSub.DefaultView.RowFilter = $"Id_Servicios = {Convert.ToInt32(cboServicios.SelectedValue)}";
            dgvSeleccionDeSubServicios.DataSource = dtServiciosSub.DefaultView.ToTable();
            foreach (DataGridViewColumn col in dgvSeleccionDeSubServicios.Columns)
                col.Visible = false;

            dgvSeleccionDeSubServicios.Columns["elegir"].Visible = true;
            dgvSeleccionDeSubServicios.Columns["elegir"].ReadOnly = false;
            dgvSeleccionDeSubServicios.Columns["elegir"].HeaderText = "Elegir";
            dgvSeleccionDeSubServicios.Columns["Descripcion"].Visible = true;
            dgvSeleccionDeSubServicios.Columns["Descripcion"].HeaderText = "Subservicios";
            
            dgvSubServiciosActuales.CurrentCell = null;
            foreach (DataGridViewRow row in dgvSubServiciosActuales.Rows)
            {
                if (Convert.ToInt32(row.Cells["estado"].Value) == Convert.ToInt32(Borrados.Estado.Inactivo))
                {
                    row.Visible = false;
                    lblSubInactivos.Visible = false;
                    if (Convert.ToInt32(row.Cells["id_servicio_inactivo"].Value) == Convert.ToInt32(cboServicios.SelectedValue))
                    {
                        row.Visible = true;
                        lblSubInactivos.Visible = true;
                    }
                }
            }     
        }

        private void dgvEquipos_SelectionChanged(object sender, EventArgs e)
        {
            (sender as DataGridView).ClearSelection();
        }

        private void btnCambiar_Click(object sender, EventArgs e)
        {
            bool generarParteCambioEquipo = false;
            bool generarParteCambioTecnologia = false;
            int idFallaCambioEquipo = 0, idFallaCambioTecnologia = 0;
            string descFallaCambioEquipo = "", descFallaCambioTecnologia = "";

            try
            {
                if (cboParteFalla.SelectedIndex == -1)
                {
                    string mensaje = "Es necesario seleccionar un motivo por el cual se realiza el cambio de servicio";
                    MessageBox.Show(mensaje, "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                bool selecciono = false;
                foreach (DataGridViewRow row in dgvSeleccionDeSubServicios.Rows)
                    if (Convert.ToBoolean(row.Cells["elegir"].Value))
                        selecciono = true;

                if (!selecciono)
                {
                    MessageBox.Show("Es necesario seleccionar al menos un subservicio de la grila", "Mensaje del sistema");
                    return;
                }

                if (sbAdvertencias.Length > 0)
                {
                    if (MessageBox.Show($"Advertencia(s)\n{sbAdvertencias}\n¿Cambiar de todos modos?", "Mensaje del sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        return;
                }

                idServicioTipoNuevo = Tablas.DataServicios.AsEnumerable()
                        .Where(dr => dr.Field<int>("id") == Convert.ToInt32(cboServicios.SelectedValue))
                        .Select<DataRow, int>(dr => Convert.ToInt32(dr["id_servicios_tipos"])).First();

                servicioDestinoRequiereEquipo = new Servicios()
                    .BuscarDatosServicio(Convert.ToInt32(cboServicios.SelectedValue))
                    .Rows[0]["Requiere_Equipo"].ToString().ToLower() == "si" ? true : false;

                bool generarPartesRelacionadosAlEquipo = false;
                if(servicioOrigenTieneEquipo != servicioDestinoRequiereEquipo)
                {
                    string mensaje;
                    if (servicioOrigenTieneEquipo)
                        mensaje = "El servicio origen requiere un equipo y el nuevo servicio no.\n¿Desea continuar con el cambio de todos modos?";
                    else
                        mensaje = "El servicio seleccionado requiere un equipo y el servicio de origen no requiere o no tiene asignado ninguno.\n¿Desea continuar con el cambio de todos modos?";
                
                    if (MessageBox.Show(mensaje, "Mensaje del sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        return;
                }
                else if (servicioOrigenTieneEquipo && servicioDestinoRequiereEquipo)
                {
                    generarPartesRelacionadosAlEquipo = true;
                }

                idsServiciosSubs_idsServiciosSubsTipos = GetIdsSubserviciosSeleccionados();

                int idVelNuevo = 0, idVelTipoNuevo = 0;
                if (requiereVelocidadActual)
                {
                    if (!SeleccionarVelocidades(out idVelNuevo, out idVelTipoNuevo))
                        return;
                }

                //Los partes asociados al cambio de equipo y velocidad se podran generar solo si el nuevo servicio requiere velocidad 
                //y si el servicio actual tiene asociado algun equipo
                if (generarPartesRelacionadosAlEquipo)
                {
                    using (frmPopUp frmpopup = new frmPopUp())
                    {
                        frmCambioServicioGeneracionPartes frmGeneracionPartes = new frmCambioServicioGeneracionPartes(idServicioTipoNuevo);
                        frmpopup.Formulario = frmGeneracionPartes;
                        frmpopup.Maximizar = false;
                        if(frmpopup.ShowDialog() == DialogResult.OK)
                        {
                            generarParteCambioEquipo = frmGeneracionPartes.CambioEquipo;
                            generarParteCambioTecnologia = frmGeneracionPartes.CambioTecnologia;
                            idFallaCambioEquipo = frmGeneracionPartes.IdFallaCambioEquipo;
                            idFallaCambioTecnologia = frmGeneracionPartes.IdFallaCambioTecnologia;
                            descFallaCambioEquipo = frmGeneracionPartes.DescFallaCambioEquipo;
                            descFallaCambioTecnologia = frmGeneracionPartes.DescFallaCambioTecnologia;
                        }
                        else
                        {
                            return;
                        }
                    }
                }

                //Cambio de servicio
                Cursor = Cursors.WaitCursor;
                Cambio_Servicio oCambioServicio;
                if (idVelNuevo > 0 || idVelTipoNuevo > 0)
                    oCambioServicio = new Cambio_Servicio(idUsuarioServicio, Convert.ToInt32(cboServicios.SelectedValue), idsServiciosSubs_idsServiciosSubsTipos, idVelNuevo, idVelTipoNuevo);
                else
                    oCambioServicio = new Cambio_Servicio(idUsuarioServicio, Convert.ToInt32(cboServicios.SelectedValue), idsServiciosSubs_idsServiciosSubsTipos);
                oCambioServicio.PisarServicioActual();
                GenerarParteDeCambioDeServicio();

                //Generar parte de cambio de equipo
                if (generarParteCambioEquipo)
                {
                    GenerarParteDeCambioDeEquipo(idFallaCambioEquipo, descFallaCambioEquipo);
                }

                //Generar parte de cambio de tecnologia
                if (generarParteCambioTecnologia)
                {
                    GenerarParteCambioTecnologia(idFallaCambioTecnologia, descFallaCambioTecnologia);
                }

                cargarDatos();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error:\n{ex.Message}", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void actualizarCass()
        {
            
        }

        private List<Tuple<int, int>> GetIdsSubserviciosSeleccionados()
        {
            //Retorna una lista de tuplas, el primer valor es el id del subservicio y el segundo el es tipo
            List<Tuple<int,int>> idsServiciosSubs_idsServiciosSubsTipos = new List<Tuple<int, int>>();
            bool tieneSubservicio = false;
            foreach (DataGridViewRow row in dgvSeleccionDeSubServicios.Rows)
            {
                if (Convert.ToBoolean(row.Cells["elegir"].Value))
                {
                    if (Convert.ToInt32(row.Cells["Id_Servicios_Sub_Tipos"].Value) == Convert.ToInt32(Servicios_Sub.SERVICIO_SUB_TIPOS.SUBSERVICIO))
                        tieneSubservicio = true;
                    idsServiciosSubs_idsServiciosSubsTipos.Add(new Tuple<int, int>(Convert.ToInt32(row.Cells["id"].Value), Convert.ToInt32(row.Cells["id_servicios_sub_tipos"].Value)));
                }
            }

            if (!tieneSubservicio)
            {
                throw new Exception("Es necesario seleccionar al menos un item de tipo subservicio");
            }

            return idsServiciosSubs_idsServiciosSubsTipos;
        }

        private void GenerarParteDeCambioDeServicio()
        {
            try
            {
                Partes oPartes = new Partes();
                oPartes.Id_Usuarios = Convert.ToInt32(dtUsuarioServicio.Rows[0]["id_usuarios"]);
                oPartes.Id_Servicios = Convert.ToInt32(cboServicios.SelectedValue);
                oPartes.Id_Usuarios_Locaciones = Convert.ToInt32(dtUsuarioServicio.Rows[0]["id_usuarios_locaciones"]);
                oPartes.Id_Partes_Fallas = Convert.ToInt32(cboParteFalla.SelectedValue);
                oPartes.Id_Partes_Estados = Convert.ToInt32(Partes.Partes_Estados.REALIZADO);
                oPartes.Id_Operadores = Personal.Id_Login;
                oPartes.Id_Areas = Personal.Id_Area;
                oPartes.Id_Usuarios_Servicios = Convert.ToInt32(dtUsuarioServicio.Rows[0]["id"]);
                oPartes.Fecha_Reclamo = DateTime.Now;
                oPartes.Fecha_Programado = DateTime.Now;
                oPartes.Fecha_Realizado = DateTime.Now;
                oPartes.IdAppExterna = Convert.ToInt32(dtDatosServicioActual.Rows[0]["id_aplicaciones_externas"]);
                oPartes.Detalle_Falla = "";
                oPartes.Detalle_Solucion = "";
                int idParte = oPartes.Guardar(oPartes, 1);

                Partes_Historial oParteHistorial = new Partes_Historial();
                oParteHistorial.Id_Parte = idParte;
                oParteHistorial.Id_Personal = Personal.Id_Login;
                oParteHistorial.Id_Usuarios = Convert.ToInt32(dtUsuarioServicio.Rows[0]["id_usuarios"]);
                oParteHistorial.Id_Partes_Estados = Convert.ToInt32(Partes.Partes_Estados.REALIZADO);
                oParteHistorial.Fecha_Movimiento = DateTime.Now;
                oParteHistorial.Detalles = "CAMBIO DE SERVICIO";
                oParteHistorial.GuardarNuevoDetalle(oParteHistorial);

                MessageBox.Show("El servicio se cambio correctamente", "Mensaje del sistema");

                //GENERAMOS EL METODO PARA ACTUALIZAR EN EL CASS.
                DataTable dtAplicacionesFiltradas = Tablas.DataCass;
                Cass oCass;
                oCass = new Cass(Convert.ToInt32(dtAplicacionesFiltradas.Rows[0]["Id"]));
                DataTable dtOperacionesCass = new DataTable();
                DataTable dtFullData = new DataTable();
                string ResultadoOpCass = "";
                dtFullData.Clear();
                dtFullData = oCass.getFullDataUser(idUsuarioServicio, 0, (int)Cass.FILTROS_GET_DATA.ID_USUARIO_SERVICIO);
                if (dtFullData.Rows.Count == 0)
                {
                    dtFullData.Clear();
                    dtFullData = oCass.getFullDataUser(0, idParte, (int)Cass.FILTROS_GET_DATA.ID_PARTE);
                }
                if (oCass.actualizarCass(dtFullData, Usuarios.CurrentUsuario.Id, out ResultadoOpCass))
                    MessageBox.Show("Cass actualizado correctamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hubo un error al generar el parte de cambio de servicio:\n{ex.Message}", "Mensaje del sistema");
            }
        }

        private Operaciones_Condiciones_Rel.Estados GetEstadoDeLaCondicion(Operaciones_Condiciones.Condiciones condicion)
        {
            var resultado = dtConfiguracionCondiciones
                .AsEnumerable()
                .Where(dr => dr.Field<int>("Id_Condicion") == Convert.ToInt32(condicion));

            Operaciones_Condiciones_Rel.Estados estado;
            if (resultado.Any())
            {
                estado = (Operaciones_Condiciones_Rel.Estados)resultado
                    .Select(dr => dr.Field<int>("Estado"))
                    .FirstOrDefault();
            }
            else
                estado = Operaciones_Condiciones_Rel.Estados.Habilitado;

            return estado;
        }

        private Color GetColorDeEstado(Operaciones_Condiciones_Rel.Estados estado)
        {
            Color color;
            switch (estado)
            {
                case Operaciones_Condiciones_Rel.Estados.Habilitado:
                    color = COLOR_HABILITADO;
                    break;
                case Operaciones_Condiciones_Rel.Estados.Advertencia:
                    color = COLOR_ADVERTENCIA;
                    break;
                case Operaciones_Condiciones_Rel.Estados.Restringido:
                    color = COLOR_RESTRINGIDO;
                    break;
                default:
                    color = COLOR_HABILITADO;
                    break;
            }

            return color;
        }

        private String GetIconChar(Operaciones_Condiciones_Rel.Estados estado)
        {
            string icon = "";
            switch (estado)
            {
                case Operaciones_Condiciones_Rel.Estados.Habilitado:
                    icon = "a";
                    break;
                case Operaciones_Condiciones_Rel.Estados.Advertencia:
                    icon = "i";
                    break;
                case Operaciones_Condiciones_Rel.Estados.Restringido:
                    icon = "r";
                    break;
                default:
                    icon = "a";
                    break;
            }

            return icon;
        }

        private void GenerarParteDeCambioDeEquipo(int idFalla, string detalleFalla)
        {
            int idTipoEquipo;
            DataTable dtTiposEquipos = new Equipos_Tipos().ListarPorTipoServicios(idServicioTipoNuevo);

            frmSeleccionValores frmSelecValores = new frmSeleccionValores("Seleccion de tipo de equipo", dtTiposEquipos, "id", "nombre");
            frmSelecValores.SeleccionarAlMenosUno = true;
            frmSelecValores.PermitirSeleccionMultiple = false;
            if (frmSelecValores.ShowDialog() == DialogResult.OK)
            {
                idTipoEquipo = frmSelecValores.valoresSeleccionados[0];
            }
            else
            {
                MessageBox.Show("El parte de cambio de equipo no se pudo realizar", "Mensaje del sistema");
                return;
            }

            int idTipoEquipoSele = idTipoEquipo;
            Partes oPartes = new Partes();
            oPartes.Id_Servicios = Convert.ToInt32(cboServicios.SelectedValue);
            oPartes.Id_Usuarios_Servicios = idUsuarioServicio;
            oPartes.Id_Usuarios = Convert.ToInt32(dtUsuarioServicio.Rows[0]["id_usuarios"]);
            oPartes.Id_Usuarios_Locaciones = Convert.ToInt32(dtUsuarioServicio.Rows[0]["id_usuarios_locaciones"]);
            oPartes.Id_Zonas = idTipoFacturacionActual;
            oPartes.Id_Partes_Fallas = idFalla;
            oPartes.Id_Partes_Soluciones = 0;
            oPartes.Id_Tecnico = 0;
            oPartes.Id_Movil = 0;
            oPartes.Id_Operadores = Personal.Id_Login;
            oPartes.Id_Areas = Personal.Id_Area;
            oPartes.Fecha_Programado = DateTime.Now;
            oPartes.Fecha_Reclamo = DateTime.Now;
            oPartes.Detalle_Falla = detalleFalla;
            oPartes.Detalle_Solucion = "";
            oPartes.Id_Partes_Estados = Convert.ToInt32(Partes.Partes_Estados.PENDIENTE_DE_ASIGNACION_DE_TECNICO);
            oPartes.Id = oPartes.Guardar(oPartes, 1);

            if (oPartes.Id > 0)
            {
                foreach (DataRow dr in dtUsuarioServicioEquipo.Rows)
                {
                    if(Debugger.IsAttached && oConfig.GetValor_N("ParteTrabajaAppExterna") == 1)
                        new GPS().EnviarParte(oPartes.Id);
                    Partes_Equipos oPartesEquipos = new Partes_Equipos();
                    oPartesEquipos.Id_Usuarios = oPartes.Id_Usuarios;
                    oPartesEquipos.Id_Partes = oPartes.Id;
                    oPartesEquipos.Id_Servicios = oPartes.Id_Servicios;
                    oPartesEquipos.Id_Usuarios_Servicios = oPartes.Id_Usuarios_Servicios;
                    oPartesEquipos.Id_Equipos_Tipos = idTipoEquipoSele;
                    oPartesEquipos.Id_equipo_anterior = Convert.ToInt32(dr["id_equipo"]);
                    oPartesEquipos.Id_Tarjeta_Anterior = Convert.ToInt32(dr["id_tarjeta"]);
                    oPartesEquipos.Id_Tarjeta = 0;
                    oPartesEquipos.Guardar(oPartesEquipos);
                }

                Partes_Historial oPartesHistorial = new Partes_Historial();
                oPartesHistorial.Id_Parte = oPartes.Id;
                oPartesHistorial.Id_Usuarios = oPartes.Id_Usuarios;
                oPartesHistorial.Id_Personal = Personal.Id_Login;
                oPartesHistorial.Fecha_Movimiento = DateTime.Now;
                oPartesHistorial.Id_area = Personal.Id_Area;
                oPartesHistorial.Id_Partes_Estados = oPartes.SetearEstadoParte(oPartes.Id, 0, 0, DateTime.Now, 0, 0, "");
                oPartesHistorial.Detalles = detalleFalla;
                oPartesHistorial.GuardarNuevoDetalle(oPartesHistorial);
            }
            MessageBox.Show("El parte de cambio de equipo se ha generado correctamente", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void GenerarParteCambioTecnologia(int idFalla, string detalleFalla)
        {
            Partes oPartes = new Partes();
            oPartes.Id_Servicios = Convert.ToInt32(cboServicios.SelectedValue);
            oPartes.Id_Usuarios_Servicios = idUsuarioServicio;
            oPartes.Id_Usuarios = Convert.ToInt32(dtUsuarioServicio.Rows[0]["id_usuarios"]);
            oPartes.Id_Usuarios_Locaciones = Convert.ToInt32(dtUsuarioServicio.Rows[0]["id_usuarios_locaciones"]);
            oPartes.Id_Zonas = idTipoFacturacionActual;
            oPartes.Id_Partes_Fallas = idFalla;
            oPartes.Id_Partes_Soluciones = 0;
            oPartes.Id_Tecnico = 0;
            oPartes.Id_Movil = 0;
            oPartes.Id_Operadores = Personal.Id_Login;
            oPartes.Id_Areas = Personal.Id_Area;
            oPartes.Fecha_Programado = DateTime.Now;
            oPartes.Fecha_Reclamo = DateTime.Now;
            oPartes.Detalle_Falla = detalleFalla;
            oPartes.Detalle_Solucion = "";
            oPartes.Id_Partes_Estados = Convert.ToInt32(Partes.Partes_Estados.PENDIENTE_DE_ASIGNACION_DE_TECNICO);
            oPartes.Id = oPartes.Guardar(oPartes, 1);

            Partes_Historial oPartesHistorial = new Partes_Historial();
            oPartesHistorial.Id_Parte = oPartes.Id;
            oPartesHistorial.Id_Usuarios = oPartes.Id_Usuarios;
            oPartesHistorial.Id_Personal = Personal.Id_Login;
            oPartesHistorial.Fecha_Movimiento = DateTime.Now;
            oPartesHistorial.Id_area = Personal.Id_Area;
            oPartesHistorial.Id_Partes_Estados = oPartes.SetearEstadoParte(oPartes.Id, 0, 0, DateTime.Now, 0, 0, "");
            oPartesHistorial.Detalles = detalleFalla;
            oPartesHistorial.GuardarNuevoDetalle(oPartesHistorial);

            MessageBox.Show("El parte de cambio de tecnologia se ha generado correctamente", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dgvSeleccionDeSubServicios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvSeleccionDeSubServicios.Columns["elegir"].Index)
            {
                bool estado = Convert.ToBoolean(dgvSeleccionDeSubServicios.Rows[e.RowIndex].Cells["elegir"].Value);
                dgvSeleccionDeSubServicios.Rows[e.RowIndex].Cells["elegir"].Value = !estado;
            }
        }

        private void rb_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = (sender as RadioButton);
            if (rb.Checked)
            {
                Cursor = Cursors.WaitCursor;
                if(rb == rbGrupoServicio)
                {
                    filtroServicio = FILTRO_SERVICIO.GRUPO;
                }
                else if(rb == rbTipoServicio)
                {
                    filtroServicio = FILTRO_SERVICIO.TIPO;
                }
                cargarDatos();
                Cursor = Cursors.Default;
            }
        }

        private void rbModalidad_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = (sender as RadioButton);
            if (rb.Checked)
            {
                Cursor = Cursors.WaitCursor;
                if (rb == rbMismaModalidad && rb.Checked)
                {
                    filtroModalidad = FILTRO_MODALIDAD.MISMA;
                }
                else if (rb == rbTodasModalidad && rb.Checked)
                {
                    filtroModalidad = FILTRO_MODALIDAD.TODAS;
                }
                cargarDatos();
                Cursor = Cursors.Default;
            }
        }

        private void dgvSubServiciosActuales_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataTable dt = ((sender as DataGridView).DataSource as DataTable).DefaultView.ToTable();
            try
            {
                if(Convert.ToInt32(dt.Rows[e.RowIndex]["id_servicios_sub_tipos"])
                    == Convert.ToInt32(Servicios_Sub.SERVICIO_SUB_TIPOS.SUBSERVICIO))
                {
                    e.CellStyle.BackColor = Color.MediumAquamarine;
                }
                else if(Convert.ToInt32(dt.Rows[e.RowIndex]["id_servicios_sub_tipos"])
                    == Convert.ToInt32(Servicios_Sub.SERVICIO_SUB_TIPOS.MANTENIMIENTO))
                {
                    e.CellStyle.BackColor = Color.CornflowerBlue;
                }
                else if (Convert.ToInt32(dt.Rows[e.RowIndex]["id_servicios_sub_tipos"])
                    == Convert.ToInt32(Servicios_Sub.SERVICIO_SUB_TIPOS.COSTO_ADICIONAL))
                {
                    e.CellStyle.BackColor = Color.Coral;
                }
                else if (Convert.ToInt32(dt.Rows[e.RowIndex]["id_servicios_sub_tipos"])
                    == Convert.ToInt32(Servicios_Sub.SERVICIO_SUB_TIPOS.DERECHO_DE_CONEXION))
                {
                    e.CellStyle.BackColor = Color.Silver;
                }

                if (dt.Columns.Contains("estado") && (Convert.ToInt32(dt.Rows[e.RowIndex]["estado"])) == Convert.ToInt32(Borrados.Estado.Inactivo))
                {
                    e.CellStyle.BackColor = Color.LightGray;
                    e.CellStyle.ForeColor = Color.DarkSlateGray;
                }
            }
            catch
            {
            }
        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmCambioServicio_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
            else if (e.KeyCode == Keys.F1)
            {
                gbFiltroServicio.Visible = !gbFiltroServicio.Visible;
                gbFiltroModalidad.Visible = !gbFiltroModalidad.Visible;
            }
            else if (e.KeyCode == Keys.F2)
            {
                frmMain.Instance().openForm(new Herramientas.frmCambioServicio());
            }
        }
    }
}
