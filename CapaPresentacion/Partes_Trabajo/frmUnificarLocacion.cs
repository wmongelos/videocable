using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using CapaNegocios;
using System.Globalization;

namespace CapaPresentacion.Partes_Trabajo
{
    public partial class frmUnificarLocacion : Form
    {
        #region DECLARACIONES
        Usuarios_CtaCte oCtacte = new Usuarios_CtaCte();
        Partes oParte = new Partes();
        Usuarios_Servicios oUsuServ = new Usuarios_Servicios();
        Usuarios_Locaciones oUsuLoc = new Usuarios_Locaciones();
        Partes_Usuarios_Servicios oParteUsuServ = new Partes_Usuarios_Servicios();
        Configuracion oConfig = new Configuracion();
        private Thread hilo;
        private delegate void myDel();
        DataTable dtPartes = new DataTable();
        DataTable dtUsuServ = new DataTable();
        DataTable dtCtaCte = new DataTable();
        DataTable dtLocO = new DataTable();
        DataTable dtLocD = new DataTable();
        DataTable dtCtacteOrigen;
        DataTable dtParteOrigen;
        DataTable dtUsuServOrigen;
        DataTable dtPartesAbiertos = new DataTable();
        DataTable dtDeudas = new DataTable();
        DataTable dtFallas = new DataTable();
        public bool yaCargo = false;
        DataTable dtConfiguracionesCond = new DataTable();
        private Operaciones_Condiciones_Rel.Estados estadoPartesAbiertos;
        private Operaciones_Condiciones_Rel.Estados estadoPresentaDeuda;
        private Operaciones_Condiciones_Rel.Estados estadoServicioNoDisponible;
        private readonly Color COLOR_HABILITADO = Color.ForestGreen;
        private readonly Color COLOR_ADVERTENCIA = Color.DarkGoldenrod;
        private readonly Color COLOR_RESTRINGIDO = Color.Tomato;
        private bool tienePartesAbiertos = false;
        private bool tieneDeuda = false;
        private bool servicionoHabilitado = false;
        private bool partesOk = false, deudaOk = false, serviciosOk = false;
        int id_Tipo_facturacion = 0;
        #endregion

        public frmUnificarLocacion()
        {
            InitializeComponent();
        }
        #region METODOS
        private void comenzarCarga()
        {

            InicializarDgvs();

            hilo = new Thread(new ThreadStart(cargarDatos));
            hilo.Start();
        }

        private void cargarDatos()
        {
            try
            {

                //SE LLENAN DATATBLES CON LA CUENTA CORRIENTE ENTERA, LOS PARTES Y LOS SERVICIOS INCLUYENDO LOCACION ORIGEN Y LOCACION DESTINO
                dtCtaCte = oCtacte.GetCtaCteCompleta(Usuarios.CurrentUsuario.Id);
                dtPartes = oParte.TraerPartesUsuario(Usuarios.CurrentUsuario.Id);
                dtUsuServ = oUsuServ.ListarServiciosYSubServiciosActivos(Usuarios.CurrentUsuario.Id);
                dtLocO = oUsuLoc.ListarLocacionesServicio(Usuarios.CurrentUsuario.Id);
                dtLocD = oUsuLoc.ListarLocacionesServicio(Usuarios.CurrentUsuario.Id);
                dtFallas = new Partes_Solicitudes().GetSolicitudesPorOperacion(Partes.Partes_Operaciones.UNIFICACION_LOCACION);

                //LLENAMOS DATATABLE PARA LA CONFIGURACION DE CONDICIONES
                dtConfiguracionesCond = new Operaciones_Condiciones_Rel().Listar(Convert.ToInt32(Partes.Partes_Operaciones.UNIFICACION_LOCACION));

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

            if (yaCargo == false) 
            {

                if (dtLocO.Rows.Count > 0 && dtLocD.Rows.Count > 0)
                {
                    cboOrigen.DataSource = dtLocO;
                    cboOrigen.ValueMember = "Id";
                    cboOrigen.DisplayMember = "Locacion";
                    cboDestino.DataSource = dtLocD;
                    cboDestino.ValueMember = "Id";
                    cboDestino.DisplayMember = "Locacion";
                }
                if (dtFallas.Rows.Count > 0)
                {
                    cboFalla.DataSource = dtFallas;
                    cboFalla.ValueMember = "Id";
                    cboFalla.DisplayMember = "Nombre";
                }
                DataColumn colSeleccion = new DataColumn("OK", typeof(bool));
                colSeleccion.DefaultValue = true;
                dtCtaCte.Columns.Add(colSeleccion);

                DataColumn colSeleccion2 = new DataColumn("OK", typeof(bool));
                colSeleccion2.DefaultValue = true;
                dtPartes.Columns.Add(colSeleccion2);

                DataColumn colSeleccion3 = new DataColumn("OK", typeof(bool));
                colSeleccion3.DefaultValue = true;
                dtUsuServ.Columns.Add(colSeleccion3);
            }
            SetDgvCtaCte();
            SetDgvPartes();
            SetDgvServicios();





            yaCargo = true;
        }

        private Operaciones_Condiciones_Rel.Estados GetEstadoDeLaCondicion(Operaciones_Condiciones.Condiciones condicion)
        {
            var resultado = dtConfiguracionesCond
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

        private Boolean VerificarPartes()
        {
            int Check = 0;
            int idUsuarioLocacion = Convert.ToInt32(cboOrigen.SelectedValue);
            dtPartesAbiertos = new Partes().ListarPartesAbiertos(idUsuarioLocacion, 0, 0);
            estadoPartesAbiertos = GetEstadoDeLaCondicion(Operaciones_Condiciones.Condiciones.TIENE_PARTES_ABIERTOS);
            Color colorLabel = GetColorDeEstado(estadoPartesAbiertos);



            foreach (DataRow dr in dtParteOrigen.Rows)
            {
                if (Convert.ToBoolean(dr["OK"]) == true)
                {
                    Check++;
                    break;
                }
            }
            if(Check > 0) { 
                if (dtPartesAbiertos.Rows.Count > 0)
                {
                    tienePartesAbiertos = true;
                    lblPartes.Text = "Posee partes abiertos";
                    lblPartes.ForeColor = colorLabel;
                    return true;
                }
                else
                {
                    tienePartesAbiertos = false;
                    lblPartes.ForeColor = COLOR_HABILITADO;
                    lblPartes.Text = "No posee partes abiertos";
                    if (estadoPartesAbiertos == Operaciones_Condiciones_Rel.Estados.Advertencia)
                        return true;
                    else
                        return false;
                }
            }
            else 
            {
                tienePartesAbiertos = false;
                lblPartes.Text = "Sin seleccion de Partes";
                lblPartes.ForeColor = COLOR_HABILITADO;
                return true;
            }
        }

        private Boolean VerificarDeuda()
        {
            int Check = 0;
            decimal SaldoLoc = 0;
            SaldoLoc = new Usuarios_Locaciones().listardeudaLocacion(Convert.ToInt32(cboOrigen.SelectedValue));
            estadoPresentaDeuda = GetEstadoDeLaCondicion(Operaciones_Condiciones.Condiciones.PRESENTA_DEUDA);
            Color colorLabel = GetColorDeEstado(estadoPresentaDeuda);

            foreach(DataRow dr in dtCtacteOrigen.Rows)
            {
                if (Convert.ToBoolean(dr["OK"]) == true)
                { 
                    Check++;
                    break;
                }
            }
            if(Check > 0) 
            { 
                if(SaldoLoc == 0)
                {
                    tieneDeuda = false;
                    lblDeudas.Text = "No presenta deudas";
                    lblDeudas.ForeColor = COLOR_HABILITADO;
                    return true;
                }
                else
                {
                    tieneDeuda = true;
                    lblDeudas.Text = $"Presenta deudas: $ {SaldoLoc}";
                    lblDeudas.ForeColor = colorLabel;
                    if (estadoPresentaDeuda == Operaciones_Condiciones_Rel.Estados.Advertencia)
                        return true;
                    else
                        return false;
                }
            }
            else
            {
                tieneDeuda = false;
                lblDeudas.Text = "Sin seleccion de Deudas";
                lblDeudas.ForeColor = COLOR_HABILITADO;
                return true;
            }
        }

        private Boolean VerificarDisponibilidadServicio()
        {
            DataTable dtFacturacionTipo = new DataTable();
            DataView dvFiltrado = new DataView();
            DataTable dtFiltradoServiciosNoHabilitados = new DataTable();
            dtFacturacionTipo = new Tipo_Facturacion().Listar();
            int idLocacion = Convert.ToInt32(cboDestino.SelectedValue);
            DataTable dtGetIdTipoFac = new DataTable();

            if (id_Tipo_facturacion == (int)Tipo_Facturacion.Id_Tipo_Facturacion.POR_ZONAS)
                dtGetIdTipoFac = new Tipo_Facturacion().getZonaLocacion(idLocacion);
            else
                dtGetIdTipoFac = new Tipo_Facturacion().getCategoryLocacion(idLocacion);

            int id_TipoFac = 0;
            if (dtGetIdTipoFac.Rows.Count > 0)
                id_TipoFac = Convert.ToInt32(dtGetIdTipoFac.Rows[0]["idTipoFac"]);
            
            List<int> id_Servicios = new List<int>();
            List<int> ListIdTipoFac = new List<int>();
            id_Servicios.Clear();
            ListIdTipoFac.Clear();
            ListIdTipoFac.Add(id_TipoFac);
            foreach (DataRow dr in dtUsuServOrigen.Rows)
            {
                if (Convert.ToBoolean(dr["OK"]) == true)
                    id_Servicios.Add(Convert.ToInt32(dr["id_servicio"]));
            }


            if (id_Servicios.Count > 0)
            {

                String MuestraHab = string.Empty;
                String Muestra = string.Empty;

                dtFacturacionTipo = dtFacturacionTipo.AsEnumerable()
                .Where(dr => id_Servicios.Contains(Convert.ToInt32(dr["id_servicios"].ToString())))
                .CopyToDataTable();
           
                dvFiltrado = new DataView();
                dvFiltrado = dtFacturacionTipo.DefaultView;
                dvFiltrado.RowFilter = string.Format("id_tipo_facturacion = {0} ", id_TipoFac);
                dtFacturacionTipo = dvFiltrado.ToTable();

                if(dtFacturacionTipo.Rows.Count > 0) 
                { 
                    dtFacturacionTipo = dtFacturacionTipo.AsEnumerable()
                        .GroupBy(r => new { Col1 = r["id_servicios"] })
                        .Select(g => g.OrderBy(r => r["id_servicioS"]).First())
                        .CopyToDataTable();
                }

                estadoServicioNoDisponible = GetEstadoDeLaCondicion(Operaciones_Condiciones.Condiciones.SERVICIO_NO_DISPONIBLE);
                Color colorLabel = GetColorDeEstado(estadoServicioNoDisponible);

                if (id_Servicios.Count == dtFacturacionTipo.Rows.Count)
                {
                    servicionoHabilitado = false;
                    lblServicioHabilitado.Text = "Servicio/s habilitado/s";
                    lblServicioHabilitado.ForeColor = COLOR_HABILITADO;
                    return true;
                }
                else
                {
                    servicionoHabilitado = true;
                    lblServicioHabilitado.Text = $"Servicio/s no habilitado/s \n {Muestra}";
                    lblServicioHabilitado.ForeColor = colorLabel;
                    if (estadoServicioNoDisponible == Operaciones_Condiciones_Rel.Estados.Advertencia)
                        return true;
                    else 
                        return false;                   
                }
            }
            else 
            {
                lblServicioHabilitado.Text = $"Sin servicios. ";
                return true;
            }


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

        private void InicializarDgvs()
        {
            yaCargo = false;
            this.dgvCtaCte.DataSource = null;
            this.dgvParte.DataSource = null;
            this.dgvServicio.DataSource = null;
        } 

        private void SetDgvCtaCte()
        {
            //GENERA LISTA CON LA ID_LOCACION
            if(Convert.ToInt32(cboDestino.SelectedValue) > 0 && Convert.ToInt32(cboOrigen.SelectedValue) > 0)
            {
                List<int> idLocacionOrigen = new List<int>();
                foreach (DataRow dr in dtCtaCte.Rows)
                {
                    if(Convert.ToInt32(dr["id_usuarios_locacion"]) == Convert.ToInt32(cboOrigen.SelectedValue))
                    {
                        int id_Locacion = Convert.ToInt32(dr["id_usuarios_locacion"]);
                        idLocacionOrigen.Add(id_Locacion);
                    }

                }

                //CREAMOS DATATABLE DE LOCACION ORIGEN DE CTACTE
                dtCtacteOrigen = new DataTable();
                dtCtacteOrigen = dtCtaCte.Copy();


                //FILTRAMOS EL DATATABLE DE LA CUENTA CORRIENTE origen PARa SABER QUE CONTIENE DICHA LOCACION EN LA CUENTA CORRIENTE
                if (idLocacionOrigen.Count > 0)
                {
                    dtCtacteOrigen = dtCtacteOrigen.AsEnumerable()
                    .Where(dr => idLocacionOrigen.Contains(Convert.ToInt32(dr["id_usuarios_locacion"].ToString())))
                    .CopyToDataTable();
                }
                else
                    dtCtacteOrigen.Clear();

                dgvCtaCte.DataSource = null;
                dgvCtaCte.DataSource = dtCtacteOrigen;

                for (int i = 0; i < dgvCtaCte.ColumnCount; i++) { 
                    dgvCtaCte.Columns[i].Visible = false;
                    dgvCtaCte.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                }

                dgvCtaCte.Columns["Fecha_desde"].Visible = true;
                dgvCtaCte.Columns["Fecha_desde"].HeaderText = "Desde";

                dgvCtaCte.Columns["Fecha_hasta"].Visible = true;
                dgvCtaCte.Columns["Fecha_hasta"].HeaderText = "Hasta";

                dgvCtaCte.Columns["descripcion"].Visible = true;
                dgvCtaCte.Columns["descripcion"].HeaderText = "Comprobante";

                dgvCtaCte.Columns["importe_final"].Visible = true;
                dgvCtaCte.Columns["importe_final"].HeaderText = "Final";

                dgvCtaCte.Columns["importe_saldo"].Visible = true;
                dgvCtaCte.Columns["importe_saldo"].HeaderText = "Saldo";

                dgvCtaCte.Columns["OK"].Visible = true;
                dgvCtaCte.Columns["OK"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                setHeaderColorDgvCtaCte();

            }
            else
            {
                MessageBox.Show("Error al cargar las locaciones");
            }
        }

        private void SetDgvPartes()
        {
            if (Convert.ToInt32(cboDestino.SelectedValue) > 0 && Convert.ToInt32(cboOrigen.SelectedValue) > 0)
            {
                List<int> idLocacionOrigen = new List<int>();

                foreach (DataRow dr in dtPartes.Rows)
                {
                    if (Convert.ToInt32(dr["id_usuarios_locaciones"]) == Convert.ToInt32(cboOrigen.SelectedValue))
                    {
                        int id_Locacion = Convert.ToInt32(dr["id_usuarios_locaciones"]);
                        idLocacionOrigen.Add(id_Locacion);
                    }

                }

                //CREAMOS DATATABLE DE LOCACION ORIGEN DE PARTES
                dtParteOrigen = new DataTable();
                dtParteOrigen = dtPartes.Copy();

                //FILTRAMOS EL DATATABLE DE LOS PARTES ORIGEN PARA SABER LOS PARTES DE DICHA LOCACION
                if (idLocacionOrigen.Count > 0)
                {
                    dtParteOrigen = dtParteOrigen.AsEnumerable()
                    .Where(dr => idLocacionOrigen.Contains(Convert.ToInt32(dr["id_usuarios_locaciones"].ToString())))
                    .CopyToDataTable();
                }
                else
                    dtParteOrigen.Clear();

                dgvParte.DataSource = null;
                dgvParte.DataSource = dtParteOrigen;

                for (int i = 0; i < dgvParte.ColumnCount; i++) {
                    dgvParte.Columns[i].Visible = false;
                    dgvParte.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells; 
                }
                  
                dgvParte.Columns["Fecha_Reclamo"].Visible = true;
                dgvParte.Columns["Fecha_reclamo"].HeaderText = "Reclamo";

                dgvParte.Columns["Solicitud"].Visible = true;
                dgvParte.Columns["Solicitud"].HeaderText = "Solicitud";

                dgvParte.Columns["Fecha_Realizado"].Visible = true;
                dgvParte.Columns["Fecha_realizado"].HeaderText = "Realizado";

                dgvParte.Columns["OK"].Visible = true;
                dgvParte.Columns["OK"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            setHeaderColorDgvPartes();
        }

        private void SetDgvServicios()
        {
            if (Convert.ToInt32(cboDestino.SelectedValue) > 0 && Convert.ToInt32(cboOrigen.SelectedValue) > 0)
            {
                List<int> idLocacionOrigen = new List<int>();

                foreach (DataRow dr in dtUsuServ.Rows)
                {
                    if (Convert.ToInt32(dr["id_locacion"]) == Convert.ToInt32(cboOrigen.SelectedValue))
                    {
                        int id_Locacion = Convert.ToInt32(dr["id_locacion"]);
                        idLocacionOrigen.Add(id_Locacion);
                    }

                }

                //CREAMOS DATATABLE CON LOS SERVICIOS DE ORIGEN
                dtUsuServOrigen = new DataTable();
                dtUsuServOrigen = dtUsuServ.Copy();


                //FILTRAMOS LOS SERVICIOS PARA LA LOCACION DE ORIGEN , LO AGRUPAMOS POR SERVICIO Y ORDENAMOS POR ID_SERVICIO
                if (idLocacionOrigen.Count > 0)
                {
                    dtUsuServOrigen = dtUsuServOrigen.AsEnumerable()
                    .Where(dr => idLocacionOrigen.Contains(Convert.ToInt32(dr["id_locacion"].ToString())))
                    .CopyToDataTable();

                    dtUsuServOrigen = dtUsuServOrigen.AsEnumerable()
                    .GroupBy(r => new { Col1 = r["id_servicio"]})
                    .Select(g => g.OrderBy(r => r["id_servicio"]).First())
                    .CopyToDataTable();
                }
                else
                    dtUsuServOrigen.Clear();

                dgvServicio.DataSource = null;
                dgvServicio.DataSource = dtUsuServOrigen;

                for (int i = 0; i < dgvServicio.ColumnCount; i++) { 
                    dgvServicio.Columns[i].Visible = false;
                    dgvServicio.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }


                dgvServicio.Columns["Servicio"].Visible = true;
                dgvServicio.Columns["Servicio"].HeaderText = "Servicio";

                dgvServicio.Columns["Servicio_tipo"].Visible = true;
                dgvServicio.Columns["servicio_tipo"].HeaderText = "Tipo";

                dgvServicio.Columns["OK"].Visible = true;
                dgvServicio.Columns["OK"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                setHeaderColorDgvServicios();

            }
        }

        private void setHeaderColorDgvServicios()
        {
            if (VerificarDisponibilidadServicio())
            {
                serviciosOk = true;
                if (estadoServicioNoDisponible == Operaciones_Condiciones_Rel.Estados.Advertencia)
                {
                    dgvServicio.ColumnHeadersDefaultCellStyle.BackColor = COLOR_ADVERTENCIA;
                    lblServicioHabilitado.ForeColor = COLOR_ADVERTENCIA;
                }
                else
                {
                    dgvServicio.ColumnHeadersDefaultCellStyle.BackColor = COLOR_HABILITADO;
                    lblServicioHabilitado.ForeColor = COLOR_HABILITADO;
                }
            }
            else
            {
                serviciosOk = false;
                dgvServicio.ColumnHeadersDefaultCellStyle.BackColor = COLOR_RESTRINGIDO;
                lblServicioHabilitado.ForeColor = COLOR_RESTRINGIDO;
            }
        }

        private void setHeaderColorDgvCtaCte()
        {
            if (VerificarDeuda())
            {
                deudaOk = true;
                if (estadoPresentaDeuda == Operaciones_Condiciones_Rel.Estados.Advertencia && tieneDeuda == true)
                {
                    dgvCtaCte.ColumnHeadersDefaultCellStyle.BackColor = COLOR_ADVERTENCIA;
                    lblDeudas.ForeColor = COLOR_ADVERTENCIA;
                }
                else if(estadoPresentaDeuda == Operaciones_Condiciones_Rel.Estados.Advertencia && tieneDeuda == false)
                {
                    dgvCtaCte.ColumnHeadersDefaultCellStyle.BackColor = COLOR_HABILITADO;
                    lblDeudas.ForeColor = COLOR_HABILITADO;
                }
                else
                {
                    dgvCtaCte.ColumnHeadersDefaultCellStyle.BackColor = COLOR_HABILITADO;
                    lblDeudas.ForeColor = COLOR_HABILITADO;
                }
            }
            else
            {
                deudaOk = false;
                dgvCtaCte.ColumnHeadersDefaultCellStyle.BackColor = COLOR_RESTRINGIDO;
                lblDeudas.ForeColor = COLOR_RESTRINGIDO;
            }
        }

        private void setHeaderColorDgvPartes()
        {
            if (VerificarPartes())
            {
                partesOk = true;
                if (estadoPartesAbiertos == Operaciones_Condiciones_Rel.Estados.Advertencia && tienePartesAbiertos == true)
                {
                    dgvParte.ColumnHeadersDefaultCellStyle.BackColor = COLOR_ADVERTENCIA;
                    lblPartes.ForeColor = COLOR_ADVERTENCIA;
                }
                else if (estadoPartesAbiertos == Operaciones_Condiciones_Rel.Estados.Advertencia && tienePartesAbiertos == false)
                {
                    dgvParte.ColumnHeadersDefaultCellStyle.BackColor = COLOR_HABILITADO;
                    lblPartes.ForeColor = COLOR_HABILITADO;
                }
                else
                {
                    dgvParte.ColumnHeadersDefaultCellStyle.BackColor = COLOR_HABILITADO;
                    lblPartes.ForeColor = COLOR_HABILITADO;
                }
            }
            else
            {
                partesOk = false;
                dgvParte.ColumnHeadersDefaultCellStyle.BackColor = COLOR_RESTRINGIDO;
                lblPartes.ForeColor = COLOR_RESTRINGIDO;
            }
        }

        private Boolean GenerarParte()
        {
            try 
            { 
                oParte = new Partes();
                 oParte.Id_Usuarios = Convert.ToInt32(dtUsuServOrigen.Rows[0]["id_usuarios"]);
                 oParte.Id_Servicios = Convert.ToInt32(dtUsuServOrigen.Rows[0]["id_servicio"]);
                 oParte.Id_Usuarios_Locaciones = Convert.ToInt32(cboDestino.SelectedValue);
                 oParte.Id_Partes_Fallas = Convert.ToInt32(cboFalla.SelectedValue);
                 oParte.Id_Partes_Estados = Convert.ToInt32(Partes.Partes_Estados.REALIZADO);
                 oParte.Id_Operadores = Personal.Id_Login;
                 oParte.Id_Areas = Personal.Id_Area;
                 oParte.Id_Usuarios_Servicios = Convert.ToInt32(dtUsuServOrigen.Rows[0]["id_usuario_servicio"]);
                 oParte.Fecha_Reclamo = DateTime.Now;
                 oParte.Fecha_Programado = DateTime.Now;
                 oParte.Fecha_Realizado = DateTime.Now;
                 oParte.IdAppExterna = 0;
                 oParte.Detalle_Falla = "";
                 oParte.Detalle_Solucion = "";
                oParte.Id_Usuarios_Cuenta_Corriente = 0;
                int idParte = oParte.Guardar(oParte, 0);
                if (idParte > 0) 
                {
                    if (GeneraParteUsuServ(idParte))
                        return true;
                    else
                        return false;
                }
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }

        private Boolean GeneraParteUsuServ(int idParte)
        {
            try
            {
                foreach(DataRow dr in dtUsuServOrigen.Rows)
                {
                    oParteUsuServ = new Partes_Usuarios_Servicios();
                    oParteUsuServ.Id_Parte = idParte;
                    oParteUsuServ.Id_Usuario_Servicio = Convert.ToInt32(dr["id_usuario_servicio"]);
                    oParteUsuServ.Id_Servicio = Convert.ToInt32(dr["id_servicio"]);
                    oParteUsuServ.idGrupoServicio= Convert.ToInt32(dr["id_servicios_grupos"]);
                    oParteUsuServ.idTipoServicio = Convert.ToInt32(dr["id_servicio_tipo"]);
                    oParteUsuServ.IdPlastico = 0;
                    oParteUsuServ.idAppExterna = 0;
                    oParteUsuServ.id_usuarios_servicios_sub = 0;
                    oParteUsuServ.Guardar(oParteUsuServ);

                }
                return true;
            }
            catch          
            {
                return false;
            }
        }
        #endregion


        #region EVENTOS

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void frmUnificarLocacion_Load(object sender, EventArgs e)
        {

            id_Tipo_facturacion = oConfig.GetValor_N("Id_Tipo_Facturacion");
            comenzarCarga();
        }

        private void cboOrigen_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(yaCargo == true) 
            { 
                SetDgvCtaCte();
                SetDgvPartes();
                SetDgvServicios();
            }
        }

        private void cboDestino_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(yaCargo == true) 
            {
                DataTable dtActual = new DataTable();
                DataView filter = new DataView();
                dtActual = dtLocD.Copy();
                filter = dtActual.DefaultView;
                filter.RowFilter = String.Format("id = {0}", Convert.ToInt32(cboDestino.SelectedValue));
                dtActual = filter.ToTable();

                lblLocalidad.Text = "Localidad : " + dtActual.Rows[0]["localidad"].ToString();
                lblAltura.Text = "Altura : " + dtActual.Rows[0]["altura"].ToString();
                lblCalle.Text = "Calle : " + dtActual.Rows[0]["calle"].ToString();
                lblCp.Text = "Codigo Postal : " + dtActual.Rows[0]["codigo_postal"].ToString();

                setHeaderColorDgvServicios();
                setHeaderColorDgvCtaCte();
                setHeaderColorDgvPartes();
            }
        }

        private void dgvServicio_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvServicio.Columns["OK"].Index)
            {
                dgvServicio.EndEdit(); 
                if ((bool)dgvServicio.Rows[e.RowIndex].Cells["OK"].Value)
                {
                    dgvServicio.Rows[e.RowIndex].Cells["OK"].Value = false;
                    dtUsuServOrigen.Rows[e.RowIndex]["OK"] = false;
                }
                else
                {
                    dgvServicio.Rows[e.RowIndex].Cells["OK"].Value = true;
                    dtUsuServOrigen.Rows[e.RowIndex]["OK"] = true;
                }
                setHeaderColorDgvServicios();
            }
        }

        private void btnTraslada_Click(object sender, EventArgs e)
        {
            int id_Locacion = 0;
            if (Convert.ToInt32(cboOrigen.SelectedValue) == Convert.ToInt32(cboDestino.SelectedValue))
                MessageBox.Show("No se pueden trasladar datos entre Locaciones iguales, modifique la locacion de Origen o Destino por favor.");
            else
            { 
                if (Convert.ToInt32(cboDestino.SelectedValue) > 0)
                    id_Locacion = Convert.ToInt32(cboDestino.SelectedValue);

                if (partesOk == true && deudaOk == true && serviciosOk == true)
                {
                    if (Convert.ToInt32(cboFalla.SelectedValue) > 0)
                    { 
                        if (MessageBox.Show("¿Esta segura/o que desea trasladar esta informacion?", "Mnesaje del Sisyema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            if (GenerarParte())
                            {
                                if (oUsuLoc.UnificarLocacion(dtUsuServOrigen, dtCtacteOrigen, dtParteOrigen, id_Locacion))  
                                {
                                   MessageBox.Show("Datos actualizados");
                                   comenzarCarga();
                                }
                                else
                                    MessageBox.Show("No hay datos de Servicios , Cuenta Corriente o Partes para Unificar la Locacion.");
                            }
                            else
                                MessageBox.Show("Error al crear los Partes.");
                        }
                    }
                    else
                        MessageBox.Show("Seleccione el motivo de la ejecucion de esta Accion.");
                }
                else
                   MessageBox.Show("Verifique si se cumplen todas las condiciones.");
            }
        }

        private void dgvParte_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvParte.Columns["OK"].Index)
            {
                dgvParte.EndEdit(); 
                if ((bool)dgvParte.Rows[e.RowIndex].Cells["OK"].Value)
                {
                    dgvParte.Rows[e.RowIndex].Cells["OK"].Value = false;
                    dtParteOrigen.Rows[e.RowIndex]["OK"] = false;
                }
                else
                {
                    dgvParte.Rows[e.RowIndex].Cells["OK"].Value = true;
                    dtParteOrigen.Rows[e.RowIndex]["OK"] = true;
                }

                setHeaderColorDgvPartes();
            }
        }

        private void dgvCtaCte_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvCtaCte.Columns["OK"].Index)
            {
                dgvCtaCte.EndEdit(); 
                if ((bool)dgvCtaCte.Rows[e.RowIndex].Cells["OK"].Value)
                { 
                    dgvCtaCte.Rows[e.RowIndex].Cells["OK"].Value = false;
                    dtCtacteOrigen.Rows[e.RowIndex]["OK"] = false;
                }
                else 
                { 
                    dgvCtaCte.Rows[e.RowIndex].Cells["OK"].Value = true;
                    dtCtacteOrigen.Rows[e.RowIndex]["OK"] = true;
                }

                setHeaderColorDgvCtaCte();
            }
        }
        #endregion
    }
}
