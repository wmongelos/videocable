using CapaNegocios;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;


namespace CapaPresentacion.Partes_Trabajo
{
    public partial class frmListadoCortes : Form
    {
        private Usuarios_Servicios oUsuarioServicio = new Usuarios_Servicios();
        private Tipo_Facturacion oTipoFac = new Tipo_Facturacion();
        private Zonas oZona = new Zonas();
        private Servicios_Categorias oServicioCategoria = new Servicios_Categorias();
        private Servicios oServicio = new Servicios();
        private Configuracion oConfig = new Configuracion();
        private Servicios_Tipos oServiciosTipos = new Servicios_Tipos();
        private Partes oPartes = new Partes();
        private Partes_Usuarios_Servicios oPartesCorteExterna = new Partes_Usuarios_Servicios();
        private Partes_Solicitudes oParteFalla = new Partes_Solicitudes();
        private Partes_Equipos oPartesEquipos = new Partes_Equipos();
        private Equipos oEquipo = new Equipos();
        private Partes_Equipos oParteEquipo = new Partes_Equipos();
        private Thread hilo;
        private delegate void myDel();
        private Int32 contadorPartes;
        private Int32 contadorPartesEquipos;
        private Int32 flagTodoCargado = 0;
        private static Boolean bajandoServicios = false;
        private Int32 idTipoFacturacion;
        private Int32 idFormaFacturacion;
        private Int32 idTipoServicio;
        private Int32 idServicio;
        private DateTime fechaDesde;
        private DataTable dtZonasCategorias = new DataTable();
        private DataTable dtTiposServicios = new DataTable();
        private DataTable dtServicios = new DataTable();
        private DataTable dtX = new DataTable();
        private DataView oDv;
        private Panel oPanelTrabajo = new Panel();
        private Label oLabelTitulo = new Label();
        private Label oLabelProgreso = new Label();
        private Button oBotonCancelar = new Button();
        private string filtro = "";
        private DataRow[] DrTiposServicioElegidos;
        private DataTable dtCortes = new DataTable();
        private int flag = 0;

        private decimal porcentajeHecho = 0;

        private DataTable dtUsuariosServicios = new DataTable();

        private void comenzarCarga()
        {
            pgCircular.Start();
            dgvServiciosCortados.DataSource = null;
            hilo = new Thread(new ThreadStart(cargarDatos));
            hilo.Start();
        }

        private void cargarDatos()
        {
            try
            {
                idFormaFacturacion = oConfig.GetValor_N("Id_Tipo_Facturacion");
                if (idFormaFacturacion == 1)
                    dtZonasCategorias = oZona.Listar();
                else
                    dtZonasCategorias = oServicioCategoria.Listar();

                dtTiposServicios = oServiciosTipos.Listar();
                DataColumn clmSel = new DataColumn
                {
                    ColumnName = "seleccionado",
                    DataType = typeof(Boolean),
                    DefaultValue = false
                };

                dtTiposServicios.Columns.Add(clmSel);
                DataRow drTipoTodos = dtTiposServicios.NewRow();
                drTipoTodos["id"] = 0;
                drTipoTodos["nombre"] = "SELECCIONAR TODOS";
                drTipoTodos["seleccionado"] = false;
                dtTiposServicios.Rows.Add(drTipoTodos);
                dtServicios = oServicio.Listar();

                dtUsuariosServicios = oUsuarioServicio.ListarServiciosBaja(DateTime.Now);
                DataColumn clmDias = new DataColumn
                {
                    ColumnName = "DIAS CORTADOS",
                    DataType = typeof(Int32),
                    DefaultValue = 0
                };
                dtUsuariosServicios.Columns.Add(clmDias);
                oDv = new DataView(dtUsuariosServicios);
                myDel MD = new myDel(asignarDatos);
                this.Invoke(MD, new object[] { });
                pgCircular.Stop();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar Informacion" + ex.Message);
            }

        }
        private void DiasCortados()
        {
            foreach (DataRow item in dtUsuariosServicios.Rows)
            {
                DateTime fechaDesde;
                fechaDesde = Convert.ToDateTime(item["desde"]);
                TimeSpan tiempo = DateTime.Now - fechaDesde;
                int cantDias = tiempo.Days;
                item["DIAS CORTADOS"] = cantDias;
            }
        }
        private void asignarDatos()
        {
            if (flag == 0)
                dtCortes.Columns.Add("id", typeof(Int32));
            flag++;
            DiasCortados();
            FormatearGrillaTiposServicios();
            dgvServiciosCortados.DataSource = dtUsuariosServicios;
            FormatearGrilla();
            lblTotal.Text = "Total de registros: ";
            lblTotal.Text += dgvServiciosCortados.Rows.Count;
            flagTodoCargado = 1;
        }

        public frmListadoCortes()
        {
            InitializeComponent();
        }

        private void frmListadoCortes_Load(object sender, EventArgs e)
        {
            comenzarCarga();
        }

        private void cboTipoServicio_SelectedValueChanged(object sender, EventArgs e)
        {
            if (flagTodoCargado == 1)
                FiltrarGrilla();
        }

        private void FormatearGrilla()
        {
            for (int x = 0; x < dgvServiciosCortados.Columns.Count; x++)
                dgvServiciosCortados.Columns[x].Visible = false;

            dgvServiciosCortados.Columns["servicio"].Visible = true;

            dgvServiciosCortados.Columns["servicio"].Visible = true;
            dgvServiciosCortados.Columns["tipo_servicio"].Visible = true;

            dgvServiciosCortados.Columns["Servicio"].HeaderText = "Servicio";
            dgvServiciosCortados.Columns["Tipo_servicio"].HeaderText = "Tipo de servicio";
            dgvServiciosCortados.Columns["Tipo_servicio"].DisplayIndex = 1;

            dgvServiciosCortados.Columns["nombre_usuario"].Visible = true;
            dgvServiciosCortados.Columns["nombre_usuario"].HeaderText = "Usuario";

            dgvServiciosCortados.Columns["calle"].Visible = true;
            dgvServiciosCortados.Columns["calle"].HeaderText = "Calle";

            dgvServiciosCortados.Columns["altura"].Visible = true;
            dgvServiciosCortados.Columns["altura"].HeaderText = "Altura";

            dgvServiciosCortados.Columns["localidad"].Visible = true;
            dgvServiciosCortados.Columns["localidad"].HeaderText = "Localidad";

            dgvServiciosCortados.Columns["desde"].Visible = true;
            dgvServiciosCortados.Columns["desde"].HeaderText = "Cortado desde";
            if (idFormaFacturacion == 1)
                dgvServiciosCortados.Columns["tipofac"].HeaderText = "Zona";
            else
                dgvServiciosCortados.Columns["tipofac"].HeaderText = "Categoria";

            dgvServiciosCortados.Columns["tipofac"].Visible = true;
            dgvServiciosCortados.Columns["tipofac"].DisplayIndex = 0;
            dgvServiciosCortados.Columns["DIAS CORTADOS"].Visible = true;
            dgvServiciosCortados.Columns["DIAS CORTADOS"].HeaderText = "Dias cortados";
            dgvServiciosCortados.Columns["DIAS CORTADOS"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            foreach (DataGridViewRow item in dgvServiciosCortados.Rows)
            {
                if (Convert.ToInt32(item.Cells["DIAS CORTADOS"].Value) >= 90)
                    item.DefaultCellStyle.BackColor = Color.Tomato;
                if ((Convert.ToInt32(item.Cells["DIAS CORTADOS"].Value) >= 60) && (Convert.ToInt32(item.Cells["DIAS CORTADOS"].Value)) < 90)
                    item.DefaultCellStyle.BackColor = Color.LightSalmon;
                if (Convert.ToInt32(item.Cells["DIAS CORTADOS"].Value) < 60)
                    item.DefaultCellStyle.BackColor = Color.PeachPuff;

                item.Height = 30;
            }
        }

        private void CambioTipoFacturacion(object sender, EventArgs e)
        {
            if (flagTodoCargado == 1)
            {
                FormatearGrillaTiposServicios();
                FiltrarGrilla();
            }

        }

        private void FormatearGrillaTiposServicios()
        {


            dgvTiposServicio.DataSource = dtTiposServicios;
            foreach (DataGridViewColumn item in dgvTiposServicio.Columns)
            {
                item.Visible = false;
            }
            dgvTiposServicio.Columns["nombre"].Visible = true;
            dgvTiposServicio.Columns["seleccionado"].Visible = true;
            dgvTiposServicio.Columns["seleccionado"].HeaderText = "Seleccionar";

            foreach (DataGridViewRow item in dgvTiposServicio.Rows)
            {
                item.Height = 30;
                if (item.Cells["nombre"].Value.ToString() == "SELECCIONAR TODOS")
                {
                    item.DefaultCellStyle.BackColor = Color.SlateGray;
                    item.DefaultCellStyle.ForeColor = Color.White;
                }
            }

        }

        private void FiltrarGrilla()
        {
            oDv = null;
            oDv = dtUsuariosServicios.DefaultView;
            dgvServiciosCortados.DataSource = oDv;
            FormatearGrilla();
            if (oDv.Count > 0)
                btnGenerarPartes.Enabled = true;
            else
                btnGenerarPartes.Enabled = false;
            lblTotal.Text = "Total de registros: ";
            lblTotal.Text += dgvServiciosCortados.Rows.Count;
        }

        private void oBotonCancelar_Click(object sender, EventArgs e)
        {
            tarea.CancelAsync();
        }


        private void btnGenerarPartes_Click(object sender, EventArgs e)
        {
            if (dgvServiciosCortados.Rows.Count > 0)
            {
                imgReturn.Enabled = false;
                oPanelTrabajo.BackColor = Color.White;
                oPanelTrabajo.BorderStyle = BorderStyle.FixedSingle;
                oPanelTrabajo.Width = dgvServiciosCortados.Width / 2;
                oPanelTrabajo.Height = (dgvServiciosCortados.Height / 4) + 50;
                oPanelTrabajo.Location = new Point(dgvServiciosCortados.Width / 4, dgvServiciosCortados.Height / 4);
                oPanelTrabajo.Visible = true;
                spcMain.Panel2.Controls.Add(oPanelTrabajo);
                oLabelTitulo.Text = "Procesando bajas de servicio";
                oLabelTitulo.AutoSize = true;
                oLabelTitulo.Font = lblTituloHeader.Font;
                oLabelTitulo.Location = new Point(oPanelTrabajo.Width / 3, 20);
                oPanelTrabajo.Controls.Add(oLabelTitulo);
                pbrTrabajo.Location = new Point(10, oLabelTitulo.Location.Y + 50);
                pbrTrabajo.Width = oPanelTrabajo.Width - 20;
                oPanelTrabajo.Controls.Add(pbrTrabajo);
                dgvServiciosCortados.SendToBack();
                pbrTrabajo.Visible = true;
                Controles(false);
                oBotonCancelar.BackColor = btnBuscarPartes.BackColor;
                oBotonCancelar.Text = "Cancelar baja de servicios";
                oBotonCancelar.AutoSize = false;
                oBotonCancelar.Width = 200;
                oBotonCancelar.Height = btnBuscarPartes.Height;
                oBotonCancelar.ForeColor = Color.White;
                oBotonCancelar.Font = btnBuscarPartes.Font;
                oPanelTrabajo.Controls.Add(oBotonCancelar);
                oBotonCancelar.Location = new Point((oPanelTrabajo.Width - oBotonCancelar.Width) - 10, (oPanelTrabajo.Height - oBotonCancelar.Height) - 10);
                oBotonCancelar.Click += new System.EventHandler(this.oBotonCancelar_Click);
                lblProgreso.Location = new Point(10, oBotonCancelar.Location.Y + 5);
                oPanelTrabajo.Controls.Add(lblProgreso);
                lblProgreso.Visible = true;
                pbrTrabajo.Maximum = dgvServiciosCortados.Rows.Count;
                tarea.DoWork += GenerarPartesBajasServicios;
                tarea.RunWorkerCompleted += BajasTerminadas;
                tarea.RunWorkerAsync();

            }
        }

        private void BajasTerminadas(object o, RunWorkerCompletedEventArgs e)
        {
            lblProgreso.Text = string.Format("Procesando: {0} de {1} ({2} %)", dgvServiciosCortados.Rows.Count, dgvServiciosCortados.Rows.Count, 100);
            pbrTrabajo.Value = pbrTrabajo.Maximum;
            MessageBox.Show("Servicios dados de baja.", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (contadorPartes > 0)
                MessageBox.Show("Equipos dados de baja: " + contadorPartesEquipos, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
            tmrTiempo.Interval = 1000;
            tmrTiempo.Tick += new EventHandler(timer_Tick);
            tmrTiempo.Start();
            Controles(true);
            btnGenerarPartes.Enabled = false;
            oPanelTrabajo.Visible = false;
            spcMain.Panel2.Controls.Remove(oPanelTrabajo);
            imgReturn.Enabled = true;
        }

        private void GenerarPartesBajasServicios(object o, DoWorkEventArgs e)
        {
            try
            {

                bajandoServicios = true;
                contadorPartes = 0;
                Int32 idParte;
                DataTable dt_partes_fallas = new DataTable();
                foreach (DataRowView item in oDv)
                {
                    oPartes.Id = 0;
                    oPartes.Id_Usuarios = Convert.ToInt32(item["id_usuarios"]);
                    oPartes.Id_Servicios = Convert.ToInt32(item["id_servicios"]);
                    oPartes.Id_Usuarios_Locaciones = Convert.ToInt32(item["id_usuarios_locaciones"]);
                    oPartes.Id_Usuarios_Servicios = Convert.ToInt32(item["id"]);
                    oPartes.Id_Zonas = Convert.ToInt32(item["id_tipo_facturacion"]);
                    if (oParteFalla.Listar().Rows.Count > 0)
                    {
                        dt_partes_fallas = oParteFalla.Traer_Por_Tipo_Servicio(Convert.ToInt32(item["id_servicios_tipo"]));
                        oPartes.Id_Partes_Fallas = Convert.ToInt32(dt_partes_fallas.Select("Nombre='BAJA DE SERVICIO'")[0]["Id"].ToString());
                    }
                    else
                    {
                        oPartes.Id_Partes_Fallas = 0;
                    }
                    oPartes.Id_Partes_Soluciones = 0;
                    oPartes.Id_Movil = 0;
                    oPartes.Id_Tecnico = 0;
                    oPartes.Id_Partes_Estados = Convert.ToInt32(Partes.Partes_Estados.PENDIENTE_DE_ASIGNACION_DE_TECNICO);
                    oPartes.Id_Operadores = Personal.Id_Login;
                    oPartes.Id_Areas = Personal.Id_Area;
                    oPartes.Fecha_Reclamo = DateTime.Now;
                    oPartes.Fecha_Realizado = DateTime.Now;
                    oPartes.Fecha_Movil = DateTime.Now;
                    oPartes.Fecha_Recibido = DateTime.Now;
                    oPartes.Fecha_Programado = DateTime.Now;
                    oPartes.Detalle_Falla = "";
                    oPartes.Detalle_Solucion = "";
                    oPartes.Id_Locacion_Anterior = 0;
                    oPartes.Id_Comprobantes = 0;

                    oPartes.Id_Servicios_Grupos = Convert.ToInt32(item["id_servicios_grupo"]);
                    oPartes.Id_Servicios_Tipos = Convert.ToInt32(item["id_servicios_tipo"]);
                    oPartes.Fecha_tipo = 1;
                    oPartes.Id_Usuarios_Cuenta_Corriente = 0;
                    idParte = oPartes.Guardar(oPartes, 1);
                    DataView dvDatosServicios = Tablas.DataServicios.DefaultView;
                    dvDatosServicios.RowFilter = string.Format("id={0}", oPartes.Id_Servicios);

                    if (Convert.ToInt32(dvDatosServicios[0]["aplicacion_externa"]) == 1)
                    {
                        oPartesCorteExterna = new Partes_Usuarios_Servicios();
                        oPartesCorteExterna.Id_Servicio = oPartes.Id_Servicios;
                        oPartesCorteExterna.Id_Parte = idParte;
                        oPartesCorteExterna.Id_Usuario_Servicio = oPartes.Id_Usuarios_Servicios;
                        oPartesCorteExterna.idParteFalla = Convert.ToInt32(dt_partes_fallas.Select("Nombre='CORTE DE SERVICIO'")[0]["Id"].ToString());
                        oPartesCorteExterna.idGrupoServicio = oPartes.Id_Servicios_Grupos;
                        oPartesCorteExterna.idTipoServicio = oPartes.Id_Servicios_Tipos;
                        oPartesCorteExterna.id_usuarios_servicios_sub = 0;
                        oPartesCorteExterna.Guardar(oPartesCorteExterna);
                    }
                    tarea.ReportProgress(contadorPartes, oDv.Count);

                    //verifico si tiene equipo
                    DataTable dtEquipos = oEquipo.BuscarEquipoPorUsuarioServicio(Convert.ToInt32(item["id"]));
                    if (dtEquipos.Rows.Count > 0)
                    {
                        foreach (DataRow itemEquipos in dtEquipos.Rows)
                        {
                            oParteEquipo.Id = 0;
                            oParteEquipo.Id_Equipos = Convert.ToInt32(itemEquipos["id"]);
                            oParteEquipo.Id_Equipos_Tipos = Convert.ToInt32(itemEquipos["id_equipos_tipos"]);
                            oParteEquipo.Id_equipo_anterior = 0;
                            oParteEquipo.Id_Servicios = Convert.ToInt32(item["id_servicios"]);
                            oParteEquipo.Id_Tarjeta = Convert.ToInt32(itemEquipos["id_tarjeta"]);
                            oParteEquipo.Id_Tarjeta_Anterior = 0;
                            oParteEquipo.Id_Usuarios = Convert.ToInt32(item["id_usuarios"]);
                            oParteEquipo.Id_Usuarios_Servicios = Convert.ToInt32(item["id"]);
                            oParteEquipo.Id_Partes = idParte;
                            oParteEquipo.Guardar(oParteEquipo);
                            contadorPartesEquipos++;
                        }
                    }
                    contadorPartes++;
                    if (tarea.CancellationPending == true)
                    {
                        e.Cancel = true;
                        break;
                    }
                }
            }
            catch (Exception excepcion)
            {
                MessageBox.Show("Ocurrio un error al generar partes." + excepcion, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvServiciosCortados_DataSourceChanged(object sender, EventArgs e)
        {
            if (dgvServiciosCortados.Rows.Count > 0)
                btnGenerarPartes.Enabled = true;
            else
                btnGenerarPartes.Enabled = false;

            lblTotal.Text = "Total de registros: ";
            lblTotal.Text += oDv.Count;
        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            Cerrar();
        }

        private void frmListadoCortes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Cerrar();
        }

        private void pbrTrabajo_Click(object sender, EventArgs e)
        {

        }

        private void tarea_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pbrTrabajo.Value = e.ProgressPercentage;
            porcentajeHecho = (contadorPartes * 100) / dgvServiciosCortados.Rows.Count;
            lblProgreso.Text = string.Format("Procesando: {0} de {1} ({2} %)", contadorPartes + 1, dgvServiciosCortados.Rows.Count, porcentajeHecho.ToString());
        }

        private void tarea_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            pbrTrabajo.Value = 0;
            bajandoServicios = false;
        }

        private void boton1_Click(object sender, EventArgs e)
        {
            DateTime fechaHoy;
            if (rbSesenta.Checked)
            {
                fechaHoy = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                fechaHoy = fechaHoy.AddDays(-60);
                dtUsuariosServicios = oUsuarioServicio.ListarServiciosBaja(fechaHoy);
                DataColumn clmDias = new DataColumn
                {
                    ColumnName = "DIAS CORTADOS",
                    DataType = typeof(Int32),
                    DefaultValue = 0
                };
                dtUsuariosServicios.Columns.Add(clmDias);
                DiasCortados();
            }
            else
            {
                if (rbNoventa.Checked)
                {
                    fechaHoy = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                    fechaHoy = fechaHoy.AddDays(-90);
                    dtUsuariosServicios = oUsuarioServicio.ListarServiciosBaja(fechaHoy);
                    DataColumn clmDias = new DataColumn
                    {
                        ColumnName = "DIAS CORTADOS",
                        DataType = typeof(Int32),
                        DefaultValue = 0
                    };
                    dtUsuariosServicios.Columns.Add(clmDias);
                    DiasCortados();
                }
                else
                {
                    DateTime fecha = new DateTime(dtpFechaDesde.Value.Year, dtpFechaDesde.Value.Month, dtpFechaDesde.Value.Day);
                    dtUsuariosServicios = oUsuarioServicio.ListarServiciosBaja(fecha);
                    DataColumn clmDias = new DataColumn
                    {
                        ColumnName = "DIAS CORTADOS",
                        DataType = typeof(Int32),
                        DefaultValue = 0
                    };
                    dtUsuariosServicios.Columns.Add(clmDias);
                    DiasCortados();

                }
            }

            dgvServiciosCortados.DataSource = dtUsuariosServicios;
            FormatearGrilla();
            lblTotal.Text = "Total de registros: ";
            lblTotal.Text += dgvServiciosCortados.Rows.Count;
        }

        private void Cerrar()
        {
            if (bajandoServicios)
            {
                if (MessageBox.Show("En este moemento se encuentran servicios dandose de baja. ¿Desea cancelar la operacion y salir?", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    tarea.CancelAsync();
                    this.Close();
                }
            }
            else
                this.Close();
        }

        private void tmrTiempo_Tick(object sender, EventArgs e)
        {


        }

        void timer_Tick(object sender, EventArgs e)
        {
            pnlProceso.Visible = false;
            dgvServiciosCortados.Enabled = true;
            comenzarCarga();
            tmrTiempo.Stop();
        }

        private void cboServicios_SelectedValueChanged(object sender, EventArgs e)
        {
            if (flagTodoCargado == 1)
                FiltrarGrilla();
        }

        private void Controles(Boolean estado)
        {
            dtpFechaDesde.Enabled = estado;
            dgvServiciosCortados.Enabled = estado;
            btnGenerarPartes.Enabled = estado;
            btnBuscarPartes.Enabled = estado;

        }

        private void dgvTiposServicio_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvTiposServicio_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvTiposServicio.SelectedRows[0].Cells["nombre"].Value.ToString() == "SELECCIONAR TODOS")
            {
                foreach (DataGridViewRow item in dgvTiposServicio.Rows)
                {
                    item.Cells["seleccionado"].Value = true;
                }
            }
            else
            {

                if (dgvTiposServicio.Columns[e.ColumnIndex].Name == "seleccionado")
                {
                    if (Convert.ToBoolean(dgvTiposServicio.CurrentRow.Cells["seleccionado"].Value) == false)
                        dgvTiposServicio.SelectedRows[0].Cells["seleccionado"].Value = true;
                    else
                        dgvTiposServicio.SelectedRows[0].Cells["seleccionado"].Value = false;
                }
            }
        }

        private void FiltrarPorTipoServicio()
        {
            dtUsuariosServicios.DefaultView.RowFilter = "id>0";
            DrTiposServicioElegidos = dtTiposServicios.Select("seleccionado=true");
            if (DrTiposServicioElegidos.Length > 0)
            {
                for (int x = 0; x < DrTiposServicioElegidos.Length; x++)
                {
                    if (x != (DrTiposServicioElegidos.Length - 1))
                        filtro += String.Format("id_servicios_tipo={0} or ", DrTiposServicioElegidos[x]["id"]);
                    else
                        filtro += String.Format("id_servicios_tipo={0}", DrTiposServicioElegidos[x]["id"]);
                }
                dtUsuariosServicios.DefaultView.RowFilter = filtro;
            }
            else
                dtUsuariosServicios.DefaultView.RowFilter = "id>0";

            oDv = dtUsuariosServicios.DefaultView;
            dgvServiciosCortados.DataSource = dtUsuariosServicios;
            lblTotal.Text = String.Format("Total de Registros: {0}", dgvServiciosCortados.Rows.Count);
            filtro = String.Empty;
        }

        private void boton1_Click_1(object sender, EventArgs e)
        {
            FiltrarPorTipoServicio();
            FormatearGrilla();
        }

        private void dgvTiposServicio_CellBorderStyleChanged(object sender, EventArgs e)
        {

        }
    }
}
