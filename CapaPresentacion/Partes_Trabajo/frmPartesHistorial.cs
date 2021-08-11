using CapaNegocios;
using CapaPresentacion.Busquedas;
using CapaPresentacion.Impresiones;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace CapaPresentacion.Partes_Trabajo
{
    public partial class frmPartesHistorial : Form
    {
        #region [PROPIEDADES]
        public Boolean huboCambios = false;
        private Thread hilo;
        private delegate void myDel();
        private Partes oPartes = new Partes();
        private Partes_Usuarios_Servicios oPartesUsuariosServicios = new Partes_Usuarios_Servicios();
        private DataTable dtPartes = new DataTable();
        private DateTime fechaDesde, fechaHasta;
        private Partes.Tipo_Fecha oTipoFecha;
        private int idParteEstado = 0;
        private Partes_Equipos oParteEquipo = new Partes_Equipos();
        private Partes_Historial oPartesHistorial = new Partes_Historial();
        private Tools oTools = new Tools();
        private int indexFilaSeleccionada = 0;
        private int configAgenda = 0;
        private string requiereEquipo;
        private int idUsuario;
        private int idLocacion;
        private int idLocElegida;
        private int idParteSeleccionado;
        private int AsignacionIpFija;
        private int idParteOperacion;
        private string requiereTarjeta;

        private List<Int32> lista_id_partes = new List<Int32>();
        private DataView dtvPartes;
        private Usuarios_Locaciones oUsuariosLocaciones = new Usuarios_Locaciones();
        private DataTable dtLocaciones = new DataTable();
        private DataTable dtLoc = new DataTable();

        private Usuarios oUsuarios = new Usuarios();
        private Configuracion oConfiguracion = new Configuracion();
        public DataRow drUsuario_actual;
        private Equipos oEquipos = new Equipos();

        //PROPIEDADES PARA EL CASS
        DataTable dtAplicacionesFiltradas = Tablas.DataCass;
        Cass oCass;

        #endregion

        #region[METODOS CREADOS]

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
                if (idUsuario > 0)
                    dtPartes = oPartes.TraerPartesUsuario(idUsuario);
                else
                    dtPartes = oPartes.ListarPorRangoDeFechas(fechaDesde, fechaHasta, oTipoFecha);

                DataColumn colSeleccion = new DataColumn("colSeleccion", typeof(bool));
                colSeleccion.DefaultValue = false;
                dtPartes.Columns.Add(colSeleccion);
                if (idUsuario > 0 || idLocacion > 0)
                {

                    dtvPartes = new DataView(dtPartes);
                    oUsuarios.Codigo = 0;
                    oUsuarios.Usuario = "";
                    oUsuarios.Calle = "";
                    oUsuarios.Altura = 0;
                    oUsuarios.Apellido = "";
                    oUsuarios.Nombre = "";
                    oUsuarios.Depto = "";
                    oUsuarios.CUIT = 0;
                    oUsuarios.Numero_Documento = 0;

                    if (idLocacion > 0)
                    {
                        //oUsuariosLocaciones = oUsuariosLocaciones.GetLocacion(idLocacion);
                        dtvPartes.RowFilter = String.Format("id_usuarios_locaciones={0}", idLocacion);
                        //if (oUsuariosLocaciones.GetLocacion(idLocacion).Activo == Convert.ToInt32(Usuarios_Locaciones.Locacion_Estados.ACTIVA))
                        //    dtvPartes.RowFilter = String.Format("id_usuarios_locaciones={0}", idLocacion);
                        //else
                        //    MessageBox.Show("La locación seleccionada del usuario que ha buscado no se encuentra activa.");
                    }
                    else
                        dtvPartes.RowFilter = String.Format("id_usuarios={0}", idUsuario);
                    dtPartes = dtvPartes.ToTable();
                    DataRow drVacio = dtPartes.NewRow();
                    drVacio["id_partes_estados"] = -1;
                    dtPartes.Rows.Add(drVacio);
                }
                myDel MD = new myDel(AsignarDatos);
                this.Invoke(MD, new object[] { });
            }
            catch (Exception c)
            {
                //throw;
                MessageBox.Show("Error al cargar información.");
            }
            pgCircular.Stop();
        }
        private void AsignarDatos()
        {


            if (idUsuario > 0)
            {
                //pnlFiltros.Visible = false;
                //pnlLocaciones.Visible = true;
                dtLoc.Rows.Clear();
                CargarLocaciones();
            }



            dgvPartes.DataSource = dtPartes;
            if (cbPartesAnulados.CheckState == CheckState.Unchecked)
                (dgvPartes.DataSource as DataTable).DefaultView.RowFilter = "id_partes_estados <> 8";

            for (int x = 0; x < dgvPartes.Columns.Count; x++)
                dgvPartes.Columns[x].Visible = false;

            dgvPartes.Columns["id"].Visible = true;
            dgvPartes.Columns["id"].DisplayIndex = 0;

            dgvPartes.Columns["solicitud"].Visible = true;
            dgvPartes.Columns["solicitud"].DisplayIndex = 8;

            dgvPartes.Columns["codigo_usuario"].Visible = true;
            dgvPartes.Columns["codigo_usuario"].DisplayIndex = 1;
            dgvPartes.Columns["codigo_usuario"].HeaderText = "Cód. Usuario";

            dgvPartes.Columns["usuario"].Visible = true;
            dgvPartes.Columns["usuario"].DisplayIndex = 2;
            dgvPartes.Columns["usuario"].HeaderText = "Usuario";

            dgvPartes.Columns["codigo_usuario"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;


            dgvPartes.Columns["codigo_usuario"].ReadOnly = true;
            dgvPartes.Columns["usuario"].ReadOnly = true;
            dgvPartes.Columns["calle"].ReadOnly = true;
            dgvPartes.Columns["altura"].ReadOnly = true;
            dgvPartes.Columns["localidad"].ReadOnly = true;


            dgvPartes.Columns["calle"].Visible = true;
            dgvPartes.Columns["calle"].DisplayIndex = 4;
            dgvPartes.Columns["calle"].HeaderText = "Calle";

            dgvPartes.Columns["altura"].Visible = true;
            dgvPartes.Columns["altura"].DisplayIndex = 5;
            dgvPartes.Columns["altura"].HeaderText = "Altura";

            dgvPartes.Columns["localidad"].Visible = true;
            dgvPartes.Columns["localidad"].DisplayIndex = 3;
            dgvPartes.Columns["localidad"].HeaderText = "Localidad";

            dgvPartes.Columns["altura"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvPartes.Columns["localidad"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvPartes.Columns["servicio"].Visible = false;
            dgvPartes.Columns["servicio"].DisplayIndex = 6;
            dgvPartes.Columns["operador"].Visible = true;
            dgvPartes.Columns["operador"].DisplayIndex = 7;
            dgvPartes.Columns["colSeleccion"].Visible = true;

            dgvPartes.Columns["id"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvPartes.Columns["solicitud"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvPartes.Columns["calle"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvPartes.Columns["servicio"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvPartes.Columns["operador"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            dgvPartes.Columns["id"].HeaderText = "Parte";
            dgvPartes.Columns["solicitud"].HeaderText = "Solicitud";
            dgvPartes.Columns["servicio"].HeaderText = "Servicio";
            dgvPartes.Columns["operador"].HeaderText = "Personal";
            dgvPartes.Columns["colSeleccion"].HeaderText = "Reprogramar";
            dgvPartes.Columns["id"].ReadOnly = true;
            dgvPartes.Columns["solicitud"].ReadOnly = true;
            dgvPartes.Columns["servicio"].ReadOnly = true;
            dgvPartes.Columns["operador"].ReadOnly = true;
            dgvPartes.Columns["colSeleccion"].ReadOnly = false;
            dgvPartes.Columns["colSeleccion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            //if (dgvPartes.Rows.Count > 0){
            //    foreach (DataGridViewRow fila in dgvPartes.Rows)
            //        fila.Cells["colSeleccion"].Value = false;
            //}

            AsignarValores();
            try
            {
                if (indexFilaSeleccionada >= 0 && dgvPartes.Rows.Count > 0)
                    dgvPartes.Rows[indexFilaSeleccionada].Selected = true;
            }
            catch { }
            //if (idUsuario > 0 || idLocacion > 0)
            //    SetearCabeceraUsuario();

            lblTotal.Text = String.Format("Total de Registros: {0}", dgvPartes.Rows.Count);


            try
            {
                dgvPartes.Rows[dgvPartes.Rows.Count - 1].Selected = true;
            }
            catch { }
            if (idUsuario> 0 && idLocacion>0)
                Colorear_grilla(dgvPartes);

        }
        private void AsignarValores()
        {
            if (dgvPartes.Rows.Count > 0)
            {
                try
                {
                    idLocacion = Convert.ToInt32(dgvPartes.SelectedRows[0].Cells["id_usuarios_locaciones"].Value);
                    idParteSeleccionado = Convert.ToInt32(dgvPartes.SelectedRows[0].Cells["id"].Value);
                    if (dgvPartes.SelectedRows.Count > 0 && Convert.ToInt32(dgvPartes.SelectedRows[0].Cells["id_partes_estados"].Value) != -1)
                    {
                        lblNparte.Text = String.Format("N° de parte seleccionado: {0}", dgvPartes.SelectedRows[0].Cells["id"].Value);
                        lblEstado.Text = String.Format("Estado: {0}", dgvPartes.SelectedRows[0].Cells["estado"].Value);
                        lblSolicitud.Text = String.Format("Solicitud: {0}", dgvPartes.SelectedRows[0].Cells["solicitud"].Value);
                        lblUsuario.Text = String.Format("Usuario: {0}", dgvPartes.SelectedRows[0].Cells["usuario"].Value);
                        lblLoc.Text = String.Format("Locación: {0} {1}, {2}", dgvPartes.SelectedRows[0].Cells["calle"].Value, dgvPartes.SelectedRows[0].Cells["altura"].Value, dgvPartes.SelectedRows[0].Cells["localidad"].Value);
                        lblFechaRec.Text = String.Format("Fecha de reclamo: {0}", Convert.ToDateTime(dgvPartes.SelectedRows[0].Cells["fecha_reclamo"].Value).ToString("dd/MM/yyyy"));
                        lblFechaProg.Text = String.Format("Programado para: {0}", Convert.ToDateTime(dgvPartes.SelectedRows[0].Cells["fecha_programado"].Value).ToString("dd/MM/yyyy"));
                        if (Convert.ToDateTime(dgvPartes.SelectedRows[0].Cells["fecha_realizado"].Value).Year > 1900)
                        {
                            lblFechaRealizado.Text = String.Format("Fecha de realización: {0}", Convert.ToDateTime(dgvPartes.SelectedRows[0].Cells["fecha_realizado"].Value).ToString("dd/MM/yyyy"));
                            lblLapsoTiempo.Text = String.Format("Duración: {0} días.", Convert.ToDateTime(dgvPartes.SelectedRows[0].Cells["fecha_realizado"].Value).Day - Convert.ToDateTime(dgvPartes.SelectedRows[0].Cells["fecha_reclamo"].Value).Day);
                        }
                        else
                        {
                            lblFechaRealizado.Text = String.Format("Fecha de realización: {0}", "-------");
                            lblLapsoTiempo.Text = String.Format("Duración: {0}", "-------");
                        }
                        lblServicio.Text = string.Format("Servicio: {0}", dgvPartes.SelectedRows[0].Cells["servicio"].Value);

                    }
                    else
                    {
                        if (Convert.ToInt32(dgvPartes.Rows[0].Cells["id_partes_estados"].Value) != -1)
                        {
                            lblNparte.Text = String.Format("N° de parte seleccionado: {0}", dgvPartes.Rows[0].Cells["id"].Value);
                            lblEstado.Text = String.Format("Estado: {0}", dgvPartes.Rows[0].Cells["estado"].Value);
                            lblSolicitud.Text = String.Format("Solicitud: {0}", dgvPartes.Rows[0].Cells["solicitud"].Value);
                            lblUsuario.Text = String.Format("Usuario: {0}", dgvPartes.Rows[0].Cells["usuario"].Value);
                            lblLoc.Text = String.Format("Locación: {0} {1}, {2}", dgvPartes.Rows[0].Cells["calle"].Value, dgvPartes.Rows[0].Cells["altura"].Value, dgvPartes.Rows[0].Cells["localidad"].Value);
                            lblFechaRec.Text = String.Format("Fecha de reclamo: {0}", Convert.ToDateTime(dgvPartes.Rows[0].Cells["fecha_reclamo"].Value).ToString("dd/MM/yyyy"));
                            lblFechaProg.Text = String.Format("Programado para: {0}", Convert.ToDateTime(dgvPartes.Rows[0].Cells["fecha_programado"].Value).ToString("dd/MM/yyyy"));
                            if (Convert.ToDateTime(dgvPartes.Rows[0].Cells["fecha_realizado"].Value).Year > 1900)
                            {
                                lblFechaRealizado.Text = String.Format("Fecha de realización: {0}", Convert.ToDateTime(dgvPartes.Rows[0].Cells["fecha_realizado"].Value).ToString("dd/MM/yyyy"));
                                lblLapsoTiempo.Text = String.Format("Duración: {0} días.", Convert.ToDateTime(dgvPartes.Rows[0].Cells["fecha_realizado"].Value).Day - Convert.ToDateTime(dgvPartes.Rows[0].Cells["fecha_reclamo"].Value).Day);
                            }
                            else
                            {
                                lblFechaRealizado.Text = String.Format("Fecha de realización: {0}", "-------");
                                lblLapsoTiempo.Text = String.Format("Duración: {0}", "-------");
                            }
                            lblServicio.Text = string.Format("Servicio: {0}", dgvPartes.Rows[0].Cells["servicio"].Value);
                        }
                    }

                }
                catch { }
                GestionAccionesMenu();
            }
        }
        private void GestionAccionesMenu()
        {
            try
            {
                if (dgvPartes.SelectedRows[0].Cells["id"].Value.ToString() == string.Empty)
                    return;

                int cantiOpera = 0;
                int opera = 0, operaAux = -1 ;

                operaAux = dgvPartes.SelectedRows[0].Cells["id_partes_operaciones"].Value.ToString() == string.Empty ? 0 : Convert.ToInt32(dgvPartes.SelectedRows[0].Cells["id_partes_operaciones"].Value);
                bool hayDistintos = false;
                foreach (DataGridViewRow item in dgvPartes.SelectedRows)
                {
                    if (item.Cells["id_partes_operaciones"].Value != null && item.Cells["id_partes_operaciones"].Value != DBNull.Value && !String.IsNullOrWhiteSpace(item.Cells["id_partes_operaciones"].Value.ToString()))
                    {
                        opera = Convert.ToInt32(item.Cells["id_partes_operaciones"].Value);
                        if (opera != operaAux)
                            hayDistintos = true;
                    }
                }
                if (hayDistintos == false)
                {
                    if (dgvPartes.SelectedRows.Count > 0)
                    {
                        idParteOperacion = Convert.ToInt32(dgvPartes.SelectedRows[0].Cells["id_partes_operaciones"].Value);
                        idParteEstado = Convert.ToInt32(dgvPartes.SelectedRows[0].Cells["id_partes_estados"].Value);
                        requiereEquipo = dgvPartes.SelectedRows[0].Cells["requiere_equipo"].Value.ToString();
                        requiereTarjeta = dgvPartes.SelectedRows[0].Cells["requiere_tarjeta"].Value.ToString();
                        AsignacionIpFija = Convert.ToInt32(dgvPartes.SelectedRows[0].Cells["Asignacion_Ip_Fija"].Value);
                    }
                    else
                    {
                        idParteOperacion = Convert.ToInt32(dgvPartes.Rows[0].Cells["id_partes_operaciones"].Value);
                        idParteEstado = Convert.ToInt32(dgvPartes.Rows[0].Cells["id_partes_estados"].Value);
                        requiereEquipo = dgvPartes.Rows[0].Cells["requiere_equipo"].Value.ToString();
                        requiereTarjeta = dgvPartes.Rows[0].Cells["requiere_tarjeta"].Value.ToString();
                        AsignacionIpFija = Convert.ToInt32(dgvPartes.Rows[0].Cells["Asignacion_Ip_Fija"].Value);
                    }

                    if (AsignacionIpFija == Convert.ToInt32(Partes_Usuarios_Servicios.CONDICION_IP_FIJA.PENDIENTE_DE_ASIGNACION))
                        mnuIpFija.Enabled = true;
                    else
                        mnuIpFija.Enabled = false;

                    if (idParteEstado == Convert.ToInt32(Partes.Partes_Estados.ASIGNADO))
                    {
                        if (requiereEquipo == "SI")
                            mnuEquipos.Enabled = true;
                        else
                            mnuEquipos.Enabled = false;
                        mnuConfirmar.Enabled = true;
                        mnuTecnico.Enabled = false;
                        mnuTarjeta.Enabled = false;

                    }
                    else if (idParteEstado == Convert.ToInt32(Partes.Partes_Estados.PENDIENTE_DE_ASIGNACION_DE_EQUIPO))
                    {
                        mnuEquipos.Enabled = true;
                        mnuConfirmar.Enabled = false;
                        mnuTecnico.Enabled = false;
                        mnuTarjeta.Enabled = false;
                        asignarToolStripMenuItem.Enabled = true;


                    }
                    else if (idParteEstado == Convert.ToInt32(Partes.Partes_Estados.REALIZADO))
                    {
                        mnuEquipos.Enabled = false;
                        mnuConfirmar.Enabled = false;
                        mnuTecnico.Enabled = false;
                        mnuTarjeta.Enabled = false;

                    }
                    else if (idParteEstado == Convert.ToInt32(Partes.Partes_Estados.PENDIENTE_DE_ASIGNACION_DE_TECNICO))
                    {
                        mnuEquipos.Enabled = false;
                        mnuConfirmar.Enabled = true;
                        mnuTecnico.Enabled = true;
                        mnuTarjeta.Enabled = false;
                        asignarToolStripMenuItem.Enabled = true;


                    }
                    else if (idParteEstado == Convert.ToInt32(Partes.Partes_Estados.PENDIENTE_DE_ASIGNACION_DE_TARJETA))
                    {
                        mnuEquipos.Enabled = false;
                        mnuConfirmar.Enabled = false;
                        mnuTecnico.Enabled = false;
                        mnuTarjeta.Enabled = true;
                        asignarToolStripMenuItem.Enabled = true;


                    }

                }
                else
                {
                    mnuEquipos.Enabled = false;
                    mnuConfirmar.Enabled = false;
                    mnuTecnico.Enabled = false;
                    mnuTarjeta.Enabled = false;
                    mnuIpFija.Enabled = false;
                    mnuAnular.Enabled = true;
                    mnuSeguimiento.Enabled = false;
                    gPSToolStripMenuItem.Enabled = false;
                    mnuVerServicios.Enabled = false;
                    mnuImprimirContrato.Enabled = false;
                }
                mnuImprimir.Enabled = true;
                mnuExportar.Enabled = true;
                int idparteOperacion = 0;
                idparteOperacion = Convert.ToInt32(dgvPartes.SelectedRows[0].Cells["id_partes_operaciones"].Value);
                if (idparteOperacion  == (int)Partes.Partes_Operaciones.CONEXION ||
                    idparteOperacion == (int)Partes.Partes_Operaciones.BAJA ||
                    idparteOperacion == (int)Partes.Partes_Operaciones.RECONEXION ||
                    idparteOperacion == (int)Partes.Partes_Operaciones.CORTE)
                    probarCassToolStripMenuItem.Enabled = true;
                else
                    probarCassToolStripMenuItem.Enabled = false;


            }
            catch (Exception x)
            {
                MessageBox.Show("Error: "+x.ToString(),"Mensaje del Sistema",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }

        }
        private void BuscarPartes()
        {
            string filtroFecha = string.Empty;
            fechaDesde = dtpFechaDesde.Value;
            fechaHasta = dtpFechaHasta.Value;
            if (rbFechaReclamo.Checked == true)
            {
                oTipoFecha = Partes.Tipo_Fecha.FECHA_RECLAMO;
                filtroFecha = $"fecha_reclamo >= '{fechaDesde}' and fecha_reclamo <= '{fechaHasta}'";
            }
            else if (rbFechaProgramado.Checked == true)
            {
                oTipoFecha = Partes.Tipo_Fecha.FECHA_PROGRAMADO;
                filtroFecha = $"fecha_programado >= '{fechaDesde}' and fecha_programado <= '{fechaHasta}'";
            }
            else
            {
                oTipoFecha = Partes.Tipo_Fecha.FECHA_REALIZADO;
                filtroFecha = $"fecha_realizado >= '{fechaDesde}' and fecha_realizado <= '{fechaHasta}'";
            }

            dtPartes.DefaultView.RowFilter = filtroFecha;
            lblTotal.Text = String.Format("Total de Registros: {0}", dtPartes.DefaultView.Count);
        }
        private void BusquedaEnGrillaPartes()
        {
            int Id = 0;
            if (txtBuscar.Text.Length > 0)
            {

                if (Int32.TryParse(txtBuscar.Text, out Id))
                    dtPartes.DefaultView.RowFilter = String.Format("id='" + txtBuscar.Text + "'");
                else
                    dtPartes.DefaultView.RowFilter = String.Format("servicio Like '%" + txtBuscar.Text + "%' or usuario Like '%" + txtBuscar.Text + "%' or solicitud Like '%" + txtBuscar.Text + "%' or estado Like '%" + txtBuscar.Text + "%'  or localidad Like '%" + txtBuscar.Text + "%'");

            }
            else
                dtPartes.DefaultView.RowFilter = "id>0";

            //Colorear_grilla(dgvPartes);
        }
        private void Colorear_grilla(DataGridView dgvPartes)
        {
            try
            {
                if (dgvPartes.Rows.Count > 0)
                {

                        foreach (DataGridViewRow fila in dgvPartes.Rows)
                        {
                            if (Convert.ToInt32(fila.Cells["id_partes_estados"].Value) > 0)
                            {
                                if (Convert.ToInt32(fila.Cells["id"].Value) > 0)
                                {
                                    int EstadoParte = Convert.ToInt32(fila.Cells["id_partes_estados"].Value);

                                    if (EstadoParte == Convert.ToInt32(Partes.Partes_Estados.PENDIENTE_DE_ASIGNACION_DE_EQUIPO))
                                    {
                                        foreach (DataGridViewCell celda in fila.Cells)
                                            celda.Style.BackColor = Color.Yellow;
                                    }
                                    else if (EstadoParte == Convert.ToInt32(Partes.Partes_Estados.PENDIENTE_DE_ASIGNACION_DE_TECNICO))
                                    {
                                        foreach (DataGridViewCell celda in fila.Cells)
                                            celda.Style.BackColor = Color.Tomato;
                                    }
                                    else if (EstadoParte == Convert.ToInt32(Partes.Partes_Estados.ASIGNADO))
                                    {
                                        foreach (DataGridViewCell celda in fila.Cells)
                                            celda.Style.BackColor = Color.LightGreen;
                                    }
                                    else if (EstadoParte == Convert.ToInt32(Partes.Partes_Estados.REALIZADO))
                                    {
                                        foreach (DataGridViewCell celda in fila.Cells)
                                            celda.Style.BackColor = Color.DarkGray;
                                    }
                                    else if (EstadoParte == Convert.ToInt32(Partes.Partes_Estados.PENDIENTE_DE_ASIGNACION_DE_TARJETA))
                                    {
                                        foreach (DataGridViewCell celda in fila.Cells)
                                            celda.Style.BackColor = Color.DarkOrange;
                                    }
                                }

                            }
                            else
                            {
                                if (Convert.ToInt32(fila.Cells["id_partes_estados"].Value) == -1)
                                {
                                    foreach (DataGridViewCell celda in fila.Cells)
                                        celda.Style.BackColor = Color.White;
                                }
                            }
                            fila.Height = 30;
                        }
                    dgvPartes.Columns["id"].DisplayIndex = 0;
                    dgvPartes.Columns["codigo_usuario"].DisplayIndex = dgvPartes.Columns["id"].DisplayIndex + 1;
                    dgvPartes.Columns["usuario"].DisplayIndex = dgvPartes.Columns["id"].DisplayIndex + 2;
                    dgvPartes.Columns["localidad"].DisplayIndex = dgvPartes.Columns["id"].DisplayIndex + 3;
                    dgvPartes.Columns["calle"].DisplayIndex = dgvPartes.Columns["id"].DisplayIndex + 4;
                    dgvPartes.Columns["altura"].DisplayIndex = dgvPartes.Columns["id"].DisplayIndex + 5;
                    dgvPartes.Columns["servicio"].DisplayIndex = dgvPartes.Columns["id"].DisplayIndex + 6;
                    dgvPartes.Columns["operador"].DisplayIndex = dgvPartes.Columns["id"].DisplayIndex + 7;
                    dgvPartes.Columns["solicitud"].DisplayIndex = dgvPartes.Columns["id"].DisplayIndex + 8;

                }
            }
            catch
            {
                throw;
                MessageBox.Show("Error al recargar grilla.");
            }
        }
        private void AsignarTecnico()
        {
            if (configAgenda == Convert.ToInt32(Agenda_Encabezado.Uso_agenda.TRABAJA_CON_AGENDA))
            {

                frmAgenda frmAgen = frmAgenda.GetInstancia();
                lista_id_partes.Clear();
                lista_id_partes.Add(Convert.ToInt32(dgvPartes.SelectedRows[0].Cells["id"].Value));
                frmAgen.Id_recibido(lista_id_partes);
                frmAgen.Mostrar();

                this.huboCambios = true;
                // this.DialogResult = DialogResult.Cancel;

                ComenzarCarga();
            }
            else
            {
                int IdTecnico = 0;
                int IdParte = Convert.ToInt32(dgvPartes.SelectedRows[0].Cells["id"].Value);
                int IdPartesEstados = 0;
                frmBusquedaTecnicos frm1 = new frmBusquedaTecnicos();
                frmPopUp frmpopup = new frmPopUp();
                frmpopup.Maximizar = false;
                frmpopup.Formulario = frm1;

                if (frmpopup.ShowDialog() == DialogResult.OK)
                {
                    IdTecnico = frm1.tecnicoSel;

                    try
                    {
                        oPartes.AsignarTecnico(IdParte, IdTecnico, Convert.ToInt32(dgvPartes.SelectedRows[0].Cells["id_partes_estados"].Value));
                        IdPartesEstados = oPartes.SetearEstadoParte(IdParte, 0, 0, DateTime.Now, 0, 0, "");

                        oPartesHistorial.Id_Partes_Estados = IdPartesEstados;
                        oPartesHistorial.Id_Parte = IdParte;
                        oPartesHistorial.Id_Usuarios = Convert.ToInt32(dgvPartes.SelectedRows[0].Cells["id_usuarios"].Value);
                        oPartesHistorial.Id_Personal = Personal.Id_Login;
                        oPartesHistorial.Fecha_Movimiento = DateTime.Now;
                        oPartesHistorial.Id_area = Personal.Id_Area;
                        oPartesHistorial.Detalles = "TÉCNICO ASIGNADO.";
                        oPartesHistorial.GuardarNuevoDetalle(oPartesHistorial);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Error en la asignación de técnicos.");
                    }
                    ComenzarCarga();
                    huboCambios = true;
                }
            }
        }
        private void ExportarAExcel()
        {
            if (dgvPartes.Rows.Count > 0)
                oTools.ExportToExcel(dgvPartes, "Partes consultados");
            else
                MessageBox.Show("No hay datos en la grilla.");
        }
        private void BuscarUsuario()
        {
            using (frmPopUp frmPop = new frmPopUp())
            {
                frmBusquedaUsuarios frm = new frmBusquedaUsuarios(1, "", "");
                frmPop.Maximizar = true;
                frmPop.Formulario = frm;

                if (frmPop.ShowDialog() == DialogResult.OK)
                {
                    drUsuario_actual = frm.usuario_e;
                    Usuarios.Usuario_Sel = frm.usuario_e;
                    idUsuario = Int32.Parse(drUsuario_actual["id"].ToString());
                    idLocacion = Int32.Parse(drUsuario_actual["id_usuarios_locaciones"].ToString());
                    // idUsuario = Int32.Parse(Usuarios.Usuario_Sel["id"].ToString());
                    // idUsuario = Int32.Parse(Usuarios.Usuario_Sel["id_usuarios_locaciones"].ToString());
                    ComenzarCarga();
                }
            }

        }
        private void CargarLocaciones()
        {
            dtLocaciones = oUsuariosLocaciones.ListarLocacionesServicio(idUsuario);
            dtLoc.Clear();
            dtLoc.Rows.Add(-1, "TODAS LAS LOCACIONES");
            foreach (DataRow item in dtLocaciones.Rows)
            {
                Int32 idLoc = Convert.ToInt32(item["id"]);
                String datosLoc = "Calle: " + item["calle"].ToString().Trim() + " Nro: " + item["altura"].ToString() + " Piso: " + item["piso"].ToString() + " Depto: " + item["depto"] + " " + item["localidad"].ToString();
                dtLoc.Rows.Add(idLoc, datosLoc);
            }


            dtLoc.DefaultView.Sort = "id DESC";

            cboLocacion.DataSource = dtLoc;
            cboLocacion.DisplayMember = "datos";
            cboLocacion.ValueMember = "id";
            cboLocacion.SelectedValue = idLocacion;
            cboLocacion.Focus();
        }
        #endregion

        #region[METODOS CONTROLES]
        public frmPartesHistorial(int IdUsuarioRecibido = 0, int IdLocacionRecibida = 0)
        {
            idUsuario = IdUsuarioRecibido;
            idLocacion = IdLocacionRecibida;
            drUsuario_actual = null;
            InitializeComponent();
            DateTime dia = DateTime.Now;
            dtpFechaDesde.Value = new DateTime(dia.Year, dia.Month, 1);
            dtpFechaHasta.Value = DateTime.Now;
        }
        private void frmConsultaDePartes_Load(object sender, EventArgs e)
        {
            fechaDesde = dtpFechaDesde.Value;
            fechaHasta = dtpFechaHasta.Value;
            rbFechaReclamo.Checked = true;
            oTipoFecha = Partes.Tipo_Fecha.FECHA_RECLAMO;
            dtpFechaDesde.CustomFormat = "dd-MM-yyyy";
            dtpFechaHasta.CustomFormat = "dd-MM-yyyy";
            dgvPartes.ReadOnly = false;
            configAgenda = oConfiguracion.GetValor_N("Agenda_Trabajo");
            if (configAgenda != Convert.ToInt32(Agenda_Encabezado.Uso_agenda.TRABAJA_CON_AGENDA))
                mnuGpsEnviar.Visible = true;
            else
                mnuGpsEnviar.Visible = false;
            dtLoc.Columns.Add("id", typeof(Int32));
            dtLoc.Columns.Add("datos", typeof(string));
            ComenzarCarga();
        }
        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            BusquedaEnGrillaPartes();
        }
        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void frmConsultaDePartes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
        private void dgvPartes_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvPartes.SelectedRows.Count > 0)
                {
                    if (Convert.ToInt32(dgvPartes.SelectedRows[0].Cells["id_partes_estados"].Value) > 0)
                        AsignarValores();
                }

            }
            catch (Exception)
            {
            }
        }
        private void dgvPartes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(dgvPartes.SelectedRows[0].Cells["id_partes_estados"].Value) > 0)
                    indexFilaSeleccionada = dgvPartes.SelectedRows[0].Index;
                if (Convert.ToInt32(dgvPartes.SelectedRows[0].Cells["id_partes_operaciones"].Value) == (int)Partes.Partes_Operaciones.CONEXION ||
                    Convert.ToInt32(dgvPartes.SelectedRows[0].Cells["id_partes_operaciones"].Value) == (int)Partes.Partes_Operaciones.CAMBIO_DE_EQUIPO)
                    btnImprimirContrato.Visible = true;
                else
                    btnImprimirContrato.Visible = false;


            }
            catch { indexFilaSeleccionada = 0; }
            try
            {
                if (dgvPartes.SelectedRows.Count > 0)
                {
                    if (Convert.ToInt32(dgvPartes.SelectedRows[0].Cells["id_partes_estados"].Value) > 0)
                        AsignarValores();
                }

            }
            catch (Exception)
            {
            }

        }
        private void lblAsignado_Click(object sender, EventArgs e)
        {
            if (dtPartes.Rows.Count > 0)
            {
                dtPartes.DefaultView.RowFilter = String.Format("id_partes_estados={0}", Convert.ToInt32(Partes.Partes_Estados.ASIGNADO));
                lblTotal.Text = String.Format("Total de Registros: {0}", dgvPartes.Rows.Count);
            }
        }
        private void lblRealizado_Click(object sender, EventArgs e)
        {
            if (dtPartes.Rows.Count > 0)
            {
                dtPartes.DefaultView.RowFilter = String.Format("id_partes_estados={0}", Convert.ToInt32(Partes.Partes_Estados.REALIZADO));
                lblTotal.Text = String.Format("Total de Registros: {0}", dgvPartes.Rows.Count);
            }
        }
        private void lblSinTecnico_Click(object sender, EventArgs e)
        {
            if (dtPartes.Rows.Count > 0)
            {
                dtPartes.DefaultView.RowFilter = String.Format("id_partes_estados={0}", Convert.ToInt32(Partes.Partes_Estados.PENDIENTE_DE_ASIGNACION_DE_TECNICO));
                lblTotal.Text = String.Format("Total de Registros: {0}", dgvPartes.Rows.Count);
            }
        }
        private void lblSinEquipo_Click(object sender, EventArgs e)
        {
            if (dtPartes.Rows.Count > 0)
            {
                dtPartes.DefaultView.RowFilter = String.Format("id_partes_estados={0}", Convert.ToInt32(Partes.Partes_Estados.PENDIENTE_DE_ASIGNACION_DE_EQUIPO));
                lblTotal.Text = String.Format("Total de Registros: {0}", dgvPartes.Rows.Count);
            }
        }
        private void lblSinTarjeta_Click(object sender, EventArgs e)
        {
            if (dtPartes.Rows.Count > 0)
            {
                dtPartes.DefaultView.RowFilter = String.Format("id_partes_estados={0}", Convert.ToInt32(Partes.Partes_Estados.PENDIENTE_DE_ASIGNACION_DE_TARJETA));
                lblTotal.Text = String.Format("Total de Registros: {0}", dgvPartes.Rows.Count);
            }
        }
        private void cboLocacion_SelectedValueChanged(object sender, EventArgs e)
        {
            if (idUsuario > 0)
            {
                try
                {

                    idLocElegida = Convert.ToInt32(cboLocacion.SelectedValue);
                    if (idLocElegida > 0)
                    {
                        dtvPartes.RowFilter = String.Format("id_usuarios_locaciones={0}", idLocElegida);
                        dgvPartes.Columns["calle"].Visible = false;
                        dgvPartes.Columns["altura"].Visible = false;
                        dgvPartes.Columns["localidad"].Visible = false;
                        dgvPartes.Columns["localidad"].Visible = false;


                    }
                    else
                    {
                        dtvPartes.RowFilter = "";
                        dgvPartes.Columns["calle"].Visible = true;
                        dgvPartes.Columns["calle"].DisplayIndex = 4;
                        dgvPartes.Columns["calle"].HeaderText = "Calle";

                        dgvPartes.Columns["altura"].Visible = true;
                        dgvPartes.Columns["altura"].DisplayIndex = 5;
                        dgvPartes.Columns["altura"].HeaderText = "Altura";

                        dgvPartes.Columns["localidad"].Visible = true;
                        dgvPartes.Columns["localidad"].DisplayIndex = 3;
                        dgvPartes.Columns["localidad"].HeaderText = "Localidad";

                        dgvPartes.Columns["altura"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        dgvPartes.Columns["localidad"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                    }


                    crearNuevoParteToolStripMenuItem.Visible = true;
                    dgvPartes.DataSource = dtvPartes;
                    Colorear_grilla(dgvPartes);

                }
                catch (Exception)
                {
                    //throw;
                }
            }
        }
        private void btnBuscarUsuario_Click(object sender, EventArgs e)
        {
            BuscarUsuario();
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            BuscarPartes();
        }

        private void dgvPartes_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvPartes.Columns[e.ColumnIndex].Name == "id_partes_estados")

            {
                switch (Convert.ToInt32(e.Value))
                {
                    case 3:
                        dgvPartes.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Green;
                        // e.CellStyle.BackColor = Color.Green;
                        break;
                    default:
                        break;
                }
            }

        }
        private void btnImprimirContrato_Click(object sender, EventArgs e)
        {
            Impresion oImp = new Impresion();
            Contrato oContratos = new Contrato();
            int idServicio=0,idTipoFac=0, idUsuarioServicio;
            string nombreArchivoContrato = "";
            DataTable dtServiciosParte = oPartesUsuariosServicios.ListarServiciosPorParte(Convert.ToInt32(dgvPartes.SelectedRows[0].Cells["id"].Value), Partes_Usuarios_Servicios.CONDICION_REQ_EQUIPOS.TODOS);
            foreach (DataRow item in dtServiciosParte.Rows)
            {
                idServicio = Convert.ToInt32(item["id_servicios"]);
                idTipoFac= Convert.ToInt32(item["id_tipo_facturacion"]);
                idUsuarioServicio = Convert.ToInt32(item["id_usuarios_servicios"]);

                DataTable dtContratosServicio = oContratos.ListarPorRelacion(idServicio, idTipoFac);
                if(dtContratosServicio.Rows.Count>0)
                {
                    foreach (DataRow contratos in dtContratosServicio.Rows)
                    {
                        nombreArchivoContrato = contratos["nombre_archivo"].ToString();
                        if(nombreArchivoContrato.ToLower() == "PropuestaAdhesionHotel".ToLower())
                            oImp.imprimirContratoHotel(Convert.ToInt32(dgvPartes.SelectedRows[0].Cells["id"].Value));
                        if (nombreArchivoContrato.ToLower() == "PropuestaDeAdhesionCable".ToLower())
                            oImp.ImprimeReportePropuestaDeAdhesionCable(Usuarios.CurrentUsuario.Id, 1, Usuarios.CurrentUsuario.Id_Usuarios_Locacion);
                        if (nombreArchivoContrato.ToLower() == "PropuestaDeAdhesionInternet".ToLower())
                            oImp.ImprimeReportePropuestaDeAdhesionInternet(Usuarios.CurrentUsuario.Id, Usuarios.CurrentUsuario.Id_Usuarios_Locacion, Convert.ToInt32(dgvPartes.SelectedRows[0].Cells["id"].Value));
                        if (nombreArchivoContrato.ToLower() == "PropuestaDeAdhesionComplejoDeptos".ToLower())
                            oImp.ImprimeReportePropuestaDeAdhesionComplejoDepto(idLocacion); 
                        if (nombreArchivoContrato.ToLower() == "ContratoPlanVacacion".ToLower())
                            oImp.ImprimirContratoVacaciones(idLocacion);
                        if (nombreArchivoContrato.ToLower() == "PropuestaDeAdhesionEdificios".ToLower())
                            oImp.ImprimirContratoEdificios(idParteSeleccionado);
                        if (nombreArchivoContrato.ToLower() == "PropuestaAdhesionDigital".ToLower())
                            oImp.ImprimirPropuestaDigital(Usuarios.CurrentUsuario.Id, idUsuarioServicio, idParteSeleccionado);
                    }
                }

            }

         
   
        }

        private void cbPartesAnulados_CheckedChanged(object sender, EventArgs e)
        {
            if(dgvPartes.Rows.Count > 0)
            {
                if (cbPartesAnulados.CheckState == CheckState.Checked)
                    (dgvPartes.DataSource as DataTable).DefaultView.RowFilter = "";
                else
                    (dgvPartes.DataSource as DataTable).DefaultView.RowFilter = "id_partes_estados <> 8";
            }

            lblTotal.Text = String.Format("Total de Registros: {0}", dtPartes.DefaultView.Count);
        }
        private void dgvPartes_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                try
                {
                    if(dgvPartes.Rows.Count>1)
                    {

                        var hti = dgvPartes.HitTest(e.X, e.Y);
                        dgvPartes.Rows[e.RowIndex].Selected = true;
                        dgvPartes.Focus();
                        GestionAccionesMenu();
                        cmsOpciones.Show(Cursor.Position);
                    }
                    else
                    {
                        var hti = dgvPartes.HitTest(e.X, e.Y);
                        dgvPartes.Rows[e.RowIndex].Selected = true;
                        dgvPartes.Focus();
                        foreach (ToolStripMenuItem item in cmsOpciones.Items)
                            item.Enabled = false;

                        crearNuevoParteToolStripMenuItem.Enabled = true;
                        AsignarValores();
                        cmsOpciones.Show(Cursor.Position);

                    }

                }
                catch
                {

                }
            }
        }
        private void mnuTecnico_Click(object sender, EventArgs e)
        {
            try
            {
                AsignarTecnico();
            }
            catch(Exception x)
            {
                MessageBox.Show("No se puede asignar el técnico: " + x.ToString());
            }
        }
        private void mnuEquipos_Click(object sender, EventArgs e)
        {
            int idParteEnviar = Convert.ToInt32(dgvPartes.SelectedRows[0].Cells["id"].Value);
            List<int> listaTiposEquipos = new List<int>();
            DataTable dtPartesEquipos = new DataTable();
            int equiposDisponibles = 0;

            dtPartesEquipos = oParteEquipo.ListarPorParte(idParteEnviar);//trae partes equipos

            if (dtPartesEquipos.Rows.Count > 0)
            {
                foreach (DataRow parteEquipo in dtPartesEquipos.Rows)//lista tipos de equipos que requiere
                {
                    if (!listaTiposEquipos.Contains(Convert.ToInt32(parteEquipo["id_equipos_tipos"])))
                        listaTiposEquipos.Add(Convert.ToInt32(parteEquipo["id_equipos_tipos"]));
                }

                equiposDisponibles = 0;
                foreach (int idTipoEquipo in listaTiposEquipos)
                {
                    if (oEquipos.ConsultarDisponibilidad(idTipoEquipo, 1))
                        equiposDisponibles++;
                }
            }
            else
            {
                equiposDisponibles++;
            }

            if (equiposDisponibles == 0)
                MessageBox.Show("No hay stock disponible.");
            else
            {
                frmAsignacionEquipos frmAsignacion = new frmAsignacionEquipos(idParteEnviar, frmAsignacionEquipos.TIPO_LLAMADA_FORM.SHOW_DIALOG);
                frmPopUp frmpopup = new frmPopUp();
                frmpopup.Maximizar = false;
                frmpopup.Formulario = frmAsignacion;
                frmpopup.ShowDialog();
                if (frmAsignacion.DialogResult == DialogResult.OK)
                {
                    ComenzarCarga();
                    huboCambios = true;

                }
            }
        }
        private void mnuTarjeta_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(dgvPartes.SelectedRows[0].Cells["id_partes_estados"].Value) > 0)
            {
                frmAsignacionEquipos frmAsignacion = new frmAsignacionEquipos(Convert.ToInt32(dgvPartes.SelectedRows[0].Cells["id"].Value), frmAsignacionEquipos.TIPO_LLAMADA_FORM.SHOW_DIALOG);
                frmPopUp frmpopup = new frmPopUp();
                frmpopup.Maximizar = false;
                frmpopup.Formulario = frmAsignacion;
                frmpopup.ShowDialog();
                if (frmAsignacion.DialogResult == DialogResult.OK)
                {
                    ComenzarCarga();
                    huboCambios = true;
                }
            }
        }
        private void mnuReprogramar_Click(object sender, EventArgs e)
        {
            if (dgvPartes.SelectedRows.Count > 0)
            {
                List<int> listaIdsPartesSeleccionados = new List<int>();
                List<Partes_Historial> listaPartesSeleccionados = new List<Partes_Historial>();
                frmActualizarFechaProgramado frmActualizarProgramado = new frmActualizarFechaProgramado();
                frmAgenda frmAgenda = frmAgenda.GetInstancia();


                foreach (DataGridViewRow fila in dgvPartes.SelectedRows)
                {
                     if (Convert.ToInt32(fila.Cells["id_partes_estados"].Value) != -1)
                     {
                         if (Convert.ToInt32(fila.Cells["id_partes_estados"].Value) != Convert.ToInt32(CapaNegocios.Partes.Partes_Estados.REALIZADO) && Convert.ToInt32(fila.Cells["id_partes_estados"].Value) != Convert.ToInt32(CapaNegocios.Partes.Partes_Estados.ANULADO))
                         {
                             Partes_Historial oParteHistorial = new Partes_Historial();
                             oParteHistorial.Id_Parte = Convert.ToInt32(fila.Cells["id"].Value);
                             oParteHistorial.Id_Personal = Personal.Id_Login;
                             oParteHistorial.Id_area = Personal.Id_Area;
                             oParteHistorial.Id_Usuarios = Convert.ToInt32(fila.Cells["id_usuarios"].Value);
                             oParteHistorial.Id_Partes_Estados = Convert.ToInt32(fila.Cells["id_partes_estados"].Value);
                             oParteHistorial.Fecha_Movimiento = DateTime.Now;
                             listaPartesSeleccionados.Add(oParteHistorial);
                         }
                     }                    
                }

                if (listaPartesSeleccionados.Count > 0)
                {
                    frmPopUp frmpopup = new frmPopUp();
                    frmpopup.Maximizar = false;
                    if (configAgenda == Convert.ToInt32(Agenda_Encabezado.Uso_agenda.TRABAJA_CON_AGENDA))
                    {
                        foreach (Partes_Historial parteHistorial in listaPartesSeleccionados)
                            listaIdsPartesSeleccionados.Add(parteHistorial.Id_Parte);
                        frmAgenda.Id_recibido(listaIdsPartesSeleccionados);
                        frmAgenda.reprogramarParte = true;
                        frmpopup.Formulario = frmAgenda;
                    }
                    else
                    {
                        frmActualizarProgramado.ListaPartesHistorial = listaPartesSeleccionados;
                        frmpopup.Formulario = frmActualizarProgramado;
                    }
                    frmpopup.ShowDialog();

                    if (frmpopup.DialogResult == DialogResult.OK)
                    {
                        huboCambios = true;
                        ComenzarCarga();
                    }
                }
                else
                    MessageBox.Show("No se han seleccionado partes o los partes seleccionados ya se encuentran realizados.");
            }
            else
                MessageBox.Show("No hay partes en esta fecha.");
        }
        private void mnuConfirmar_Click(object sender, EventArgs e)
        {
             if (Convert.ToInt32(dgvPartes.SelectedRows[0].Cells["id_partes_estados"].Value) > 0)
            {
                frmConfirmaParte frm = new frmConfirmaParte(Convert.ToInt32(dgvPartes.SelectedRows[0].Cells["id"].Value), frmConfirmaParte.FUNCIONALIDAD.CONFIRMAR_ANULAR);
                frm.WindowState = FormWindowState.Maximized;
                frm.ShowDialog();
                if (frm.DialogResult == DialogResult.OK)
                {
                    ComenzarCarga();
                    huboCambios = true;

                }
            }
        }
        private void mnuSeguimiento_Click(object sender, EventArgs e)
        {
            if (dgvPartes.SelectedRows.Count > 0 && Convert.ToInt32(dgvPartes.SelectedRows[0].Cells["id_partes_estados"].Value) > 0)
            {
                frmPartesSeguimientoHistorial frmPartesSeguimiento = new frmPartesSeguimientoHistorial();
                frmPartesSeguimiento.oParte.Id = Convert.ToInt32(dgvPartes.SelectedRows[0].Cells["id"].Value);
                frmPopUp frmpopup = new frmPopUp();
                frmpopup.Maximizar = false;
                frmpopup.Formulario = frmPartesSeguimiento;
                frmpopup.ShowDialog();
            }
        }
        private void mnuVerServicios_Click(object sender, EventArgs e)
        {
            if (dgvPartes.SelectedRows.Count > 0 && Convert.ToInt32(dgvPartes.SelectedRows[0].Cells["id_partes_estados"].Value) > 0)
            {
                frmServiciosDelParte frmServiciosParte = new frmServiciosDelParte(Convert.ToInt32(dgvPartes.SelectedRows[0].Cells["id"].Value));
                frmPopUp frmpopup = new frmPopUp();
                frmpopup.Maximizar = false;
                frmpopup.Formulario = frmServiciosParte;
                frmpopup.ShowDialog();
            }
        }
        private void mnuImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                Impresion oImpresiones = new Impresion();
                foreach (DataGridViewRow item in dgvPartes.SelectedRows)
                {
                    if (Convert.ToInt32(item.Cells["id_partes_estados"].Value) > 0)
                        oImpresiones.ImprimirParte(Convert.ToInt32(item.Cells["id"].Value));
                }
               
            }
            catch(Exception C)
            {
                MessageBox.Show("No se puede imprimir:" + C.ToString());
            }
        }
        private void mnuGpsEnviar_Click(object sender, EventArgs e)
        {
            GPS oGps = new GPS();
            oGps.EnviarParte(Convert.ToInt32(dgvPartes.SelectedRows[0].Cells["id"].Value));
        }
        private void mnuImprimirContrato_Click(object sender, EventArgs e)
        {
            Impresion oImp = new Impresion();
            Contrato oContratos = new Contrato();
            int idServicio = 0, idTipoFac = 0, idUsuarioServicio;
            string nombreArchivoContrato = "";
            DataTable dtServiciosParte = oPartesUsuariosServicios.ListarServiciosPorParte(Convert.ToInt32(dgvPartes.SelectedRows[0].Cells["id"].Value), Partes_Usuarios_Servicios.CONDICION_REQ_EQUIPOS.TODOS);
            foreach (DataRow item in dtServiciosParte.Rows)
            {
                idServicio = Convert.ToInt32(item["id_servicios"]);
                idTipoFac = Convert.ToInt32(item["id_tipo_facturacion"]);
                idUsuarioServicio = Convert.ToInt32(item["id_usuarios_servicios"]);

                DataTable dtContratosServicio = oContratos.ListarPorRelacion(idServicio, idTipoFac);
                if (dtContratosServicio.Rows.Count > 0)
                {
                    foreach (DataRow contratos in dtContratosServicio.Rows)
                    {
                        nombreArchivoContrato = contratos["nombre_archivo"].ToString();
                        if (nombreArchivoContrato.ToLower() == "PropuestaAdhesionHotel".ToLower())
                            oImp.imprimirContratoHotel(Convert.ToInt32(dgvPartes.SelectedRows[0].Cells["id"].Value));
                        if (nombreArchivoContrato.ToLower() == "PropuestaDeAdhesionCable".ToLower())
                            oImp.ImprimeReportePropuestaDeAdhesionCable(Usuarios.CurrentUsuario.Id, 1, Usuarios.CurrentUsuario.Id_Usuarios_Locacion);
                        if (nombreArchivoContrato.ToLower() == "PropuestaDeAdhesionInternet".ToLower())
                            oImp.ImprimeReportePropuestaDeAdhesionInternet(Usuarios.CurrentUsuario.Id, Usuarios.CurrentUsuario.Id_Usuarios_Locacion, Convert.ToInt32(dgvPartes.SelectedRows[0].Cells["id"].Value));
                        if (nombreArchivoContrato.ToLower() == "PropuestaDeAdhesionComplejoDeptos".ToLower())
                            oImp.ImprimeReportePropuestaDeAdhesionComplejoDepto(idLocacion);
                        if (nombreArchivoContrato.ToLower() == "ContratoPlanVacacion".ToLower())
                            oImp.ImprimirContratoVacaciones(idLocacion);
                        if (nombreArchivoContrato.ToLower() == "PropuestaDeAdhesionEdificios".ToLower())
                            oImp.ImprimirContratoEdificios(idParteSeleccionado);
                        if (nombreArchivoContrato.ToLower() == "PropuestaAdhesionDigital".ToLower())
                            oImp.ImprimirPropuestaDigital(Usuarios.CurrentUsuario.Id, idUsuarioServicio, idParteSeleccionado);
                    }
                }

            }
        }
        private void mnuGpsObservacion_Click(object sender, EventArgs e)
        {
            if (idParteSeleccionado > 0)
            {
                frmPartes_Obs oFrmObs = new frmPartes_Obs();
                oFrmObs.idParte = idParteSeleccionado;
                frmPopUp oPop = new frmPopUp();
                oPop.Formulario = oFrmObs;
                oPop.Maximizar = false;
                oPop.ShowDialog();
            }
        }
        private void mnuExportar_Click(object sender, EventArgs e)
        {
            try
            {
                ExportarAExcel();
            }
            catch (Exception c) { MessageBox.Show("Hubo un error al intentar exportar, controle que la librería Excel se encuentre instalada." + c.ToString()); }
        }
        private void crearNuevoParteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPopUp oPop = new frmPopUp();
            frmGenerarParte oNuevoParte = new frmGenerarParte(idUsuario, idLocElegida, null, 0, 0);
            oPop.Formulario = oNuevoParte;
            oPop.Maximizar = true;
            oPop.ShowDialog();
            ComenzarCarga();
            huboCambios = true;
        }
        private void mnuAnular_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(dgvPartes.SelectedRows[0].Cells["id_partes_estados"].Value)!=(int)Partes.Partes_Estados.ANULADO)
            {
                if (MessageBox.Show("¿Desea anular el Parte?", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    oPartes.AnularParte(idParteSeleccionado);
                    oPartesHistorial.Id_Parte = idParteSeleccionado;
                    oPartesHistorial.Id_Usuarios = idParteSeleccionado;
                    oPartesHistorial.Id_Personal = Personal.Id_Login;
                    oPartesHistorial.Fecha_Movimiento = DateTime.Now;
                    oPartesHistorial.Id_area = Personal.Id_Area;
                    oPartesHistorial.Detalles = "PARTE ANULADO.";
                    oPartesHistorial.Id_Partes_Estados = Convert.ToInt32(Partes.Partes_Estados.ANULADO);
                    oPartesHistorial.GuardarNuevoDetalle(oPartesHistorial);
                    ComenzarCarga();
                }
            }
            else
            {
                MessageBox.Show("El parte seleccionado ya esta anulado o confirmado, no se puede anular.", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            }
        }
        private void dgvPartes_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvPartes.IsCurrentCellDirty)
            {
                dgvPartes.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void observacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (idParteSeleccionado > 0)
            {
                frmPartes_Obs oFrmObs = new frmPartes_Obs();
                oFrmObs.idParte = idParteSeleccionado;
                frmPopUp oPop = new frmPopUp();
                oPop.Formulario = oFrmObs;
                oPop.Maximizar = false;
                oPop.ShowDialog();
            }
        }

        private void probarCassToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int idParte = 0;
            string resultadoFinal = "", resultadoFinalBajaCass;
            idParte = Convert.ToInt32(dgvPartes.SelectedRows[0].Cells["id"].Value);
            oPartes.gestionarAppExternaIdParte(idParte, out resultadoFinal, out resultadoFinalBajaCass);
            MessageBox.Show($"Operacion concluida: \n{resultadoFinal}");

        }
        #endregion
    }
}
