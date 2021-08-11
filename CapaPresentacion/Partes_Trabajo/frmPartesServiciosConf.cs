using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using CapaNegocios;

namespace CapaPresentacion.Partes_Trabajo
{
    public partial class frmPartesServiciosConf : Form
    {
        #region DECLARACIONES
        private Partes_Equipos oParteEquipo = new Partes_Equipos();
        private Partes_Usuarios_Servicios oPartes = new Partes_Usuarios_Servicios();
        private Partes oParteComun = new Partes();
        private Aplicaciones_Externas oAppExterna = new Aplicaciones_Externas();
        private Isp oISP = new Isp();
        private Cass oCass;
        private GPS oGps = new GPS();
        private Partes_Historial oParteHistorial = new Partes_Historial();
        private Servicios oServicios = new Servicios();
        private Usuarios_Servicios oUsuarioServicio = new Usuarios_Servicios();
       
        private Servicios_Velocidades oVelocidad = new Servicios_Velocidades();
        private Tools oTools = new Tools();
        private DataTable dtPartes = new DataTable();
        private DataTable dtPartesInternos = new DataTable();

        private DataTable[] dtPartes3 = new DataTable[2];
        private DataTable[] dtPartes2 = new DataTable[2];

        private DataTable dtOperaciones = new DataTable();
        private DataTable dtAccesAccounts = new DataTable();
        private DataTable dtDatosUsuarioServiciosSub = new DataTable();
        private DataTable dtDatosServicio = new DataTable();
        private DataTable dtFiltrada = new DataTable();
        private DataTable dtDatosUsuarioServicioExterno = new DataTable();
        private DataTable dtDatosAplicacionExterna = new DataTable();
        private DataTable dtErrores = new DataTable();
        private DataTable dtMultiplesCuentasAcceso = new DataTable();

        private Equipos oEquipos = new Equipos();
        private Thread hilo;
        private Impresiones.Impresion oImpresiones = new Impresiones.Impresion();
        private DateTime fechaParte = new DateTime();

        private delegate void myDel();

        private Partes.Partes_Operaciones accion;
        private Int32 idFalla,comparaFecha,seleccionar=0,numParteBusca,idEquipoViejo,idEquipoNuevo,idParteSeleccionado=0,idOperacionSeleccionado=0,idParteEstado=0,codUsuarioBusca = 0, codParte=0, reconectar, idProductoAux=0,idServicio, idUsuarioServicio,codUsuario,idUsuario,idLocacion,idParte,idEquipo,idParteOperacion,idEquipment,idParteUsuarioServicio;
        private string mensaje,userName,ipRedacct,codPostal,requiereEquipo,requiereTarjeta,usuarioCalle1, usuarioCalle2,tel2,ciudad, servicio, usuario, equipo, locacion,equipo_serie,equipo_mac,velocidad,velocidad_tipo,operacion,parteFalla,equipoUsuario,equipoClave,equipoIp,nombreUsuario,apellidoUsuario,correoUsuario,telefonoUsuario,equipoMarca,equipoModelo;
        private int comboAppValueSelected;
        private int idAppExterna;

        private string comboAppStringValueSelected;

        private void comboAppExternas_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboAppValueSelected = Convert.ToInt32(comboAppExternas.SelectedValue);
            comboAppStringValueSelected = comboAppExternas.Text.ToString();
        }

        private void frmPartesServiciosConf_Load(object sender, EventArgs e)
        {
            dtMultiplesCuentasAcceso.Columns.Add("idUsuario", typeof(int));
            dtMultiplesCuentasAcceso.Columns.Add("codUsuario", typeof(int));
            dtMultiplesCuentasAcceso.Columns.Add("idParte", typeof(int));
            dtMultiplesCuentasAcceso.Columns.Add("idCustomer", typeof(int));
            dtMultiplesCuentasAcceso.Columns.Add("cuentasAcceso", typeof(List<int>));

            comboAppExternas.DataSource = oAppExterna.Listar();
            comboAppExternas.DisplayMember = "nombre";
            comboAppExternas.ValueMember = "id";
            this.comboAppExternas.SelectedIndexChanged += new System.EventHandler(this.comboAppExternas_SelectedIndexChanged);
            comboAppExternas.SelectedIndex = 0;
            comboAppValueSelected = Convert.ToInt32(comboAppExternas.SelectedValue);
            comboAppStringValueSelected = comboAppExternas.Text.ToString();

            dtOperaciones = oParteComun.ListarOperaciones();
            cboOperaciones.DataSource = dtOperaciones;
            cboOperaciones.DisplayMember = "nombre";
            cboOperaciones.ValueMember = "id";
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            btnConectar.Text = $"Conectar con {comboAppStringValueSelected}";
            lblListoParaConfg.Text = $"Lista para configurar {comboAppStringValueSelected}";
            comenzarCarga();
        }

        private void tmrTimer_Tick(object sender, EventArgs e)
        {

        }

        private void boton5_Click(object sender, EventArgs e)
        {
            oParteComun.AsignarTecnico(Convert.ToInt32(dgvPartesInternos.SelectedRows[0].Cells["id_parte"].Value), Personal.Id_Login, Convert.ToInt32(Partes.Partes_Estados.REALIZADO));
            MessageBox.Show("Parte confirmado", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
            yaCargoInternos = false;
            comenzarCarga();
        }

        private void boton2_Click(object sender, EventArgs e)
        {
            oImpresiones.ImprimirParte(Convert.ToInt32(dgvPartes.SelectedRows[0].Cells["id_parte"].Value));

        }

        private Boolean yaCargoInternos = false;

        private void tabMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabMain.SelectedTab.Name.Equals("tabPartesInternos"))
            {
                if (yaCargoInternos == false)
                {
         //           dgvPartesInternos.DataSource = dtPartesInternos;
                    FormatearGrilla(dgvPartesInternos);
                    yaCargoInternos = true;
                }
            }
        }


        private void tabMain_TabIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void tabPage2_RegionChanged(object sender, EventArgs e)
        {
        }

        private void pnlBotones_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void txtParte_TextChanged(object sender, EventArgs e)
        {
            if (txtParte.Text.Length == 0)
            {
                txtParte.Text = "0";
                FiltrarParte();
            }
            else
                FiltrarParte();

        }

        private DateTime fecha = DateTime.Now.Date;

        private void dtpFecha_ValueChanged(object sender, EventArgs e)
        {
            this.fecha = dtpFecha.Value;
        //    comenzarCarga();
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            if(seleccionar==0)
            {
                foreach (DataGridViewRow item in dgvPartes.Rows)
                {
                    comparaFecha = fechaParte.CompareTo(DateTime.Now.Date);
                    if (comparaFecha <= 0)
                        item.Cells["seleccionar"].Value = true;
                }
                seleccionar = 1;
            }
            else
            {
                foreach (DataGridViewRow item in dgvPartes.Rows)
                    item.Cells["seleccionar"].Value = false;
                seleccionar = 0;
            }

            dtPartes.AcceptChanges();
        }

        private void pnlBotones_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textboxAdv1_TextChanged(object sender, EventArgs e)
        {
            if (txtCodigo.Text.Length == 0)
            {
                txtCodigo.Text = "0";
                FiltrarUsuario();
            }
            else
                FiltrarUsuario();
        }

        private void btnPaasarAconf_Click(object sender, EventArgs e)
        {

            if (oPartes.PasarAConfigurado(idParteUsuarioServicio) == 0)
            {
                //comenzarCarga();
                MessageBox.Show("Pasado");

            }
            else
            {
                MessageBox.Show("Error");
            }
        }

        private void dgvPartes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cboOperaciones_SelectedValueChanged(object sender, EventArgs e)
        {
            FiltrarOpercion();
        }


        private void FiltrarOpercion()
        {
            try
            {
                int idOperacionFiltro = Convert.ToInt32(cboOperaciones.SelectedValue);
                DataView dvFiltroOperacion = dtPartes.DefaultView;
                dvFiltroOperacion.RowFilter = string.Format("id_partes_operaciones={0}", idOperacionFiltro);
                DataTable dtFiltrada = dvFiltroOperacion.ToTable();
                dgvPartes.DataSource = dtFiltrada;
                FormatearGrilla(dgvPartes);
          //      ColorearGrilla();

                if ((Convert.ToInt32(cboOperaciones.SelectedValue) == (int)Partes.Partes_Operaciones.BAJA) || ((Convert.ToInt32(cboOperaciones.SelectedValue) == (int)Partes.Partes_Operaciones.RECONEXION) || (Convert.ToInt32(cboOperaciones.SelectedValue) == (int)Partes.Partes_Operaciones.CORTE)))
                {
                    btnSeleccionar.Enabled = true;
                    dgvPartes.ReadOnly = false;
                    foreach (DataGridViewColumn item in dgvPartes.Columns)
                        item.ReadOnly = true;
                    dgvPartes.Columns["seleccionar"].ReadOnly = false;
                }
                else
                    btnSeleccionar.Enabled = false;
            }
            catch (Exception)
            {

            }
        }

        private void dgvPartes_Sorted(object sender, EventArgs e)
        {
            ColorearGrilla();

        }

        private void dgvPartes_ColumnSortModeChanged(object sender, DataGridViewColumnEventArgs e)
        {
        }
        #endregion

        #region METODOS
        private void comenzarCarga()
        {
            pgCircular.Start();
            txtParte.Enabled = true;
            txtCodigo.Enabled = true;
            cboOperaciones.Enabled = true;
            dgvPartes.DataSource = null;
            hilo = new Thread(new ThreadStart(CargarDatos));
            hilo.IsBackground = true;
            hilo.Start();
        }

        private void CargarDatos()
        {
            try
            {
                List<Partes_Usuarios_Servicios> lista = new List<Partes_Usuarios_Servicios>();
                dtPartes2 = oPartes.ListarPartesAConfigurar(fecha,Partes.Partes_Operaciones.ALTA_IP,Partes.Partes_Estados.TODOS, comboAppValueSelected,out lista);
         //       dtPartes3 = oPartes.ListarPartesAConfigurar(fecha, Partes.Partes_Operaciones.PARTE_INTERNO, Partes.Partes_Estados.PENDIENTE_DE_ASIGNACION_DE_TECNICO, comboAppValueSelected);
                dtPartes = dtPartes2[0];
        //        dtPartesInternos = dtPartes3[0];       
                myDel MD = new myDel(AsignarDatos);
                this.Invoke(MD, new object[] { });
                pgCircular.Stop();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar Información" + ex.Message);
            }
        }

        private void AsignarDatos()
        {
            dtOperaciones.Clear();
            dtOperaciones.Rows.Add((int)Partes.Partes_Operaciones.CONEXION, "CONEXION DE SERVICIO");
            dtOperaciones.Rows.Add((int)Partes.Partes_Operaciones.CAMBIO_DE_EQUIPO, "CAMBIO DE EQUIPO");
            dtOperaciones.Rows.Add((int)Partes.Partes_Operaciones.BAJA, "BAJA DE SERVICIO");
            dtOperaciones.Rows.Add((int)Partes.Partes_Operaciones.CORTE, "CORTE DE SERVICIO");
            dtOperaciones.Rows.Add((int)Partes.Partes_Operaciones.RECONEXION, "RECONEXION DE SERVICIO");
            dtOperaciones.Rows.Add((int)Partes.Partes_Operaciones.CAMBIO_TECNOLOGIA, "CAMBIO DE VELOCIDAD");
            dtOperaciones.Rows.Add((int)Partes.Partes_Operaciones.ASIGNACION_DE_EQUIPO, "ASIGNACION DE EQUIPO");

            DataColumn dtSel = new DataColumn();
            dtSel.DataType = typeof(Boolean);
            dtSel.DefaultValue = false;
            dtSel.ColumnName = "seleccionar";
            dtPartes.Columns.Add(dtSel);
            dgvPartes.DataSource = dtPartes;        
         
            FormatearGrilla(dgvPartes);
            ColorearGrilla();
            if (idOperacionSeleccionado > 0)  
                cboOperaciones.SelectedValue = idOperacionSeleccionado;
            if(idParteSeleccionado!=0)
            {
                foreach (DataGridViewRow item in dgvPartes.Rows)
                {
                    if (Convert.ToInt32(item.Cells["id_parte"].Value) == idParteSeleccionado)
                    {
                        item.Selected = true;
                        dgvPartes.FirstDisplayedScrollingRowIndex = dgvPartes.SelectedRows[0].Index;
                    }
                }
            }


            try
            {
                lblTotal.Text = string.Format("Total de partes para la fecha {0}/{1}/{2} o antes:", dtpFecha.Value.Day, dtpFecha.Value.Month, dtpFecha.Value.Year);

                lblTotalDato.Text = string.Format("{0}", dtPartes.Rows.Count);
                lblTotalDato.Location = new Point(lblTotal.Location.X + lblTotal.Width + 5, lblTotal.Location.Y);

                lbCantPosteriores.Text = string.Format("Total de partes para despues de {0}/{1}/{2}:", dtpFecha.Value.Day, dtpFecha.Value.Month, dtpFecha.Value.Year);
                lbCantPosteriores.Location = new Point(lblTotalDato.Location.X + lblTotalDato.Width + 10, lblTotal.Location.Y);

                lbCantPosterioresDato.Text = string.Format("{0}", dtPartes2[1].Rows.Count);
                lbCantPosterioresDato.Location = new Point(lbCantPosteriores.Location.X + lbCantPosteriores.Width + 5, lbCantPosterioresDato.Location.Y);


                lblFechaUltimo.Text = "Ultima fecha programado:";
                lblFechaUltimo.Location = new Point(lbCantPosterioresDato.Location.X + lbCantPosterioresDato.Width + 10, lblFechaUltimo.Location.Y);

                lblFechaUltimoDato.Text = string.Format("{0}/{1}/{2}", Convert.ToDateTime(dtPartes2[1].Rows[0]["fecha_programado"]).Date.Day, Convert.ToDateTime(dtPartes2[1].Rows[0]["fecha_programado"]).Date.Month, Convert.ToDateTime(dtPartes2[1].Rows[0]["fecha_programado"]).Date.Year);
                lblFechaUltimoDato.Location = new Point(lblFechaUltimo.Location.X + lblFechaUltimo.Width + 5, lblFechaUltimo.Location.Y);

            }
            catch { }

            FiltrarOpercion();
        }

        private void FormatearGrilla(DataGridView dgv)
        {
            try
            {

                foreach (DataGridViewColumn item in dgv.Columns)
                    item.Visible = false;

                dgv.Columns["id_parte"].DisplayIndex = 0;
                dgv.Columns["id_parte"].Visible = true;
                dgv.Columns["id_parte"].HeaderText = "N° de parte";
                dgv.Columns["id_parte"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgv.Columns["codigo"].Visible = true;
                dgv.Columns["codigo"].DisplayIndex = 1;
                dgv.Columns["codigo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                dgv.Columns["usuario"].Visible = true;
                dgv.Columns["usuario"].DisplayIndex = 2;
                dgv.Columns["locacion"].Visible = true;
                dgv.Columns["locacion"].DisplayIndex = 3;
                dgv.Columns["servicio"].Visible = true;
                dgv.Columns["servicio"].DisplayIndex = 4;
                dgv.Columns["velocidad"].Visible = true;
                dgv.Columns["velocidad"].DisplayIndex = 5;
                dgv.Columns["velocidad"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                dgv.Columns["velocidad_tipo"].Visible = true;
                dgv.Columns["velocidad_tipo"].DisplayIndex = 6;
                dgv.Columns["velocidad_tipo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                dgv.Columns["falla"].Visible = true;
                dgv.Columns["falla"].DisplayIndex = 7;
                dgv.Columns["fecha_programado"].Visible = true;
                dgv.Columns["fecha_programado"].DisplayIndex = 8;
                dgv.Columns["fecha_programado"].HeaderText = "Fecha programada";
                dgv.Columns["fecha_programado"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                if ((Convert.ToInt32(cboOperaciones.SelectedValue) == (int)Partes.Partes_Operaciones.BAJA) || ((Convert.ToInt32(cboOperaciones.SelectedValue) == (int)Partes.Partes_Operaciones.RECONEXION) || (Convert.ToInt32(cboOperaciones.SelectedValue) == (int)Partes.Partes_Operaciones.CORTE)))
                {

                    dgv.Columns["seleccionar"].Visible = true;
                    dgv.Columns["seleccionar"].DisplayIndex =9;
                    dgv.Columns["seleccionar"].HeaderText = "Seleccionar";
                    dgv.Columns["seleccionar"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                }

            }
            catch 
            {

            }
        }

        private void ColorearGrilla()
        {
            int idEstado;
            
            foreach (DataGridViewRow item in dgvPartes.Rows)
            {
                idEstado = Convert.ToInt32(item.Cells["id_partes_estados"].Value);
                if (idEstado == (int)Partes.Partes_Estados.ASIGNADO)
                    item.DefaultCellStyle.BackColor = Color.LightGreen;
                if (idEstado == (int)Partes.Partes_Estados.PENDIENTE_DE_ASIGNACION_DE_EQUIPO)
                    item.DefaultCellStyle.BackColor = Color.Yellow;
                if (idEstado == (int)Partes.Partes_Estados.PENDIENTE_DE_ASIGNACION_DE_TECNICO)
                    item.DefaultCellStyle.BackColor = Color.Tomato;

                item.Height = 30;
            }
        }

        private void SeleccionarRegistro()
        {
            if (dgvPartes.SelectedRows.Count>0)
            {
                try
                {
                    this.idServicio = Convert.ToInt32(dgvPartes.SelectedRows[0].Cells["id_servicio"].Value);
                    this.idFalla= Convert.ToInt32(dgvPartes.SelectedRows[0].Cells["id_parte_falla"].Value);
                    this.idUsuarioServicio = Convert.ToInt32(dgvPartes.SelectedRows[0].Cells["id_usuarios_servicios"].Value);
                    this.idUsuario = Convert.ToInt32(dgvPartes.SelectedRows[0].Cells["id_usuarios"].Value);
                    this.idLocacion = Convert.ToInt32(dgvPartes.SelectedRows[0].Cells["id_usuarios_locaciones"].Value);
                    this.codUsuario = Convert.ToInt32(dgvPartes.SelectedRows[0].Cells["codigo"].Value);
                    this.servicio = dgvPartes.SelectedRows[0].Cells["servicio"].Value.ToString();
                    this.locacion = dgvPartes.SelectedRows[0].Cells["locacion"].Value.ToString();
                    this.velocidad= dgvPartes.SelectedRows[0].Cells["velocidad"].Value.ToString();
                    this.velocidad_tipo = dgvPartes.SelectedRows[0].Cells["velocidad_tipo"].Value.ToString();
                    this.operacion= dgvPartes.SelectedRows[0].Cells["falla"].Value.ToString();
                    this.usuario= dgvPartes.SelectedRows[0].Cells["usuario"].Value.ToString();
                    this.idParte = Convert.ToInt32(dgvPartes.SelectedRows[0].Cells["id_parte"].Value);
                    this.apellidoUsuario= dgvPartes.SelectedRows[0].Cells["apellido"].Value.ToString();
                    this.nombreUsuario = dgvPartes.SelectedRows[0].Cells["nombre"].Value.ToString();
                    this.telefonoUsuario = dgvPartes.SelectedRows[0].Cells["telefono_1"].Value.ToString();
                    this.tel2 = dgvPartes.SelectedRows[0].Cells["telefono_2"].Value.ToString();
                    this.correoUsuario = dgvPartes.SelectedRows[0].Cells["correo_electronico"].Value.ToString();
                    this.usuarioCalle1= dgvPartes.SelectedRows[0].Cells["calle"].Value.ToString()+" "+ dgvPartes.SelectedRows[0].Cells["altura"].Value.ToString();
                    this.usuarioCalle2 = dgvPartes.SelectedRows[0].Cells["calle"].Value.ToString() + " " + dgvPartes.SelectedRows[0].Cells["altura"].Value.ToString();
                    this.ciudad = dgvPartes.SelectedRows[0].Cells["localidad"].Value.ToString();
                    this.codPostal = dgvPartes.SelectedRows[0].Cells["codigo_postal"].Value.ToString();
                    this.idParteOperacion = Convert.ToInt32(dgvPartes.SelectedRows[0].Cells["id_partes_operaciones"].Value);
                    this.idParteUsuarioServicio = Convert.ToInt32(dgvPartes.SelectedRows[0].Cells["id_parte_us"].Value);
                    this.idParteSeleccionado = this.idParte;
                    if (idParteOperacion == (int)Partes.Partes_Operaciones.CONEXION)
                        btnConectar.Text = "Conexion";
                    else  if (idParteOperacion == (int)Partes.Partes_Operaciones.CAMBIO_DE_EQUIPO)
                            btnConectar.Text = "Cambio de Equipo";
                        else if (idParteOperacion == (int)Partes.Partes_Operaciones.RECONEXION)
                            btnConectar.Text = "Reconectar";
                        else if (idParteOperacion == (int)Partes.Partes_Operaciones.CORTE)
                            btnConectar.Text = "Cortar";
                        else if (idParteOperacion == (int)Partes.Partes_Operaciones.ASIGNACION_DE_EQUIPO)
                        btnConectar.Text = "Asignar equipo";

                }
                catch {
                }
            }
        }



        #endregion

        public frmPartesServiciosConf()
        {
            InitializeComponent();
            CrearDataTableErrores();
        }

        private void CrearDataTableErrores()
        {
            dtErrores.Columns.Add("Tipo_Error", typeof(string));
            dtErrores.Columns.Add("Usuario", typeof(string));
            dtErrores.Columns.Add("Id_Usuario_Servicio", typeof(string));
        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void boton1_Click(object sender, EventArgs e)
        {
            DataTable dtPartesUsuariosServicios = new DataTable();
            DataTable dtDatosFalla = new DataTable();
            DataRow dtDatosParte;
            Partes_Solicitudes oSolicitud = new Partes_Solicitudes();
            Servicios oServicio = new Servicios();
            DataTable dtDatosFallasOperaciones = new DataTable();
            DataTable dtDatosServicios = new DataTable();

            dtPartesUsuariosServicios = oPartes.aux();
            if (dtPartesUsuariosServicios.Rows.Count > 0)
            {
                int idParteUsuarioServicio;
                int idfalla, idFallaNuevo;
                int idParte;
                int idTipoServicio;
                int idOperacion;
                int idUsuarioServicio;

                foreach (DataRow item in dtPartesUsuariosServicios.Rows)
                {
                    idParteUsuarioServicio = Convert.ToInt32(item["id"]);
                    idParte = Convert.ToInt32(item["id_parte"]);
                    idServicio = Convert.ToInt32(item["id_servicio"]);
                    idUsuarioServicio= Convert.ToInt32(item["id_usuarios_servicios"]);
                    dtDatosParte = oParteComun.TraerParteRow(idParte);
                    if (dtDatosParte!=null)
                    {
                        idfalla = Convert.ToInt32(dtDatosParte["id_partes_fallas"]);
                        dtDatosFalla = oSolicitud.ListarDatosFalla(idfalla);
                        if (dtDatosFalla.Rows.Count>0)
                        {
                            idOperacion = Convert.ToInt32(dtDatosFalla.Rows[0]["id_partes_operaciones"]);
                            dtDatosServicios = oServicio.BuscarDatosServicio(idServicio);
                            if (dtDatosServicios.Rows.Count>0)
                            {
                                idTipoServicio = Convert.ToInt32(dtDatosServicios.Rows[0]["id_Servicios_tipos"]);
                                dtDatosFallasOperaciones = oSolicitud.GetFallasPorTipoServYOp(idTipoServicio, idOperacion);
                                if (dtDatosFallasOperaciones.Rows.Count > 0)
                                {
                                    idFallaNuevo = Convert.ToInt32(dtDatosFallasOperaciones.Rows[0]["id"]);
                                    oPartes.actualizarFalla(idParte, idUsuarioServicio, idFallaNuevo);
                                }
                            }

                        }
                    }
                }
            }
        }

        private void dgvPartes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvPartes.SelectedRows.Count > 0)
                {
                    idParteEstado = Convert.ToInt32(dgvPartes.SelectedRows[0].Cells["id_partes_estados"].Value);
                }
                else
                {
                    idParteEstado = Convert.ToInt32(dgvPartes.Rows[0].Cells["id_partes_estados"].Value);
                }

                if (idParteEstado == Convert.ToInt32(Partes.Partes_Estados.ASIGNADO))
                {
                    btnAsignarEquipos.Enabled = false;
                    btnAsignarTecnico.Enabled = false;
                    btnConectar.Enabled = true;

                }
                else if (idParteEstado == Convert.ToInt32(Partes.Partes_Estados.PENDIENTE_DE_ASIGNACION_DE_EQUIPO))
                {
                    btnAsignarEquipos.Enabled = true;
                    btnConectar.Enabled = false;
                    btnAsignarTecnico.Enabled = false;

                }
                else if (idParteEstado == Convert.ToInt32(Partes.Partes_Estados.PENDIENTE_DE_ASIGNACION_DE_TECNICO))
                {
                    if ((this.idParteOperacion == (int)Partes.Partes_Operaciones.RECONEXION)||(this.idParteOperacion==(int)Partes.Partes_Operaciones.BAJA)|| (this.idParteOperacion == (int)Partes.Partes_Operaciones.CORTE))
                    {
                        btnAsignarEquipos.Enabled = false;
                        btnConectar.Enabled = true;
                        btnAsignarTecnico.Enabled = false;
                    }
                    else
                    {

                        btnAsignarEquipos.Enabled = true;
                        btnConectar.Enabled = false;
                        btnAsignarTecnico.Enabled = true;
                    }
                        

                }
                
            }
            catch (Exception)
            {
                throw;
            }
            SeleccionarRegistro();
        }

        private void dgvPartes_SelectionChanged(object sender, EventArgs e)
        {
            SeleccionarRegistro();
        }

        private void dgvPartes_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            SeleccionarRegistro();
        }

        private void frmPartesServiciosConf_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
            if (e.Control && e.KeyCode == Keys.S)       // Ctrl-S Save
                btnPaasarAconf.Visible = true;
        }

        private void FiltrarParte()
        {
            int aux = 0;
            try
            {
                DataView dv1 = dtPartes.DefaultView;
                codParte = Convert.ToInt32(txtParte.Text);
                if (codParte > 0)
                {
                    dv1 = dtPartes.DefaultView;
                    dv1.RowFilter = string.Format("id_parte={0}", codParte);

                }
                else
                {
                    dv1.RowFilter = string.Format("id_parte>{0}", 0);
                    aux++;
                }
                dgvPartes.DataSource = dv1;
                FormatearGrilla(dgvPartes);
                ColorearGrilla();
                if (aux > 0)
                    FiltrarOpercion();
            }
            catch
            {

            }
        }


        private void FiltrarUsuario()
        {
            int aux = 0;
            try
            {
                DataView dv=dtPartes.DefaultView;
                codUsuarioBusca = Convert.ToInt32(txtCodigo.Text);
                if (codUsuarioBusca>0)
                {
                    dv = dtPartes.DefaultView;
                    dv.RowFilter = string.Format("codigo={0}", codUsuarioBusca);
                }
                else
                {
                    dv.RowFilter = string.Format("codigo>{0}", 0);
                    aux++;
                }
                dgvPartes.DataSource = dv;
                FormatearGrilla(dgvPartes);
                ColorearGrilla();
                if (aux > 0)
                    FiltrarOpercion();
            }
            catch
            {

            }
        }

        private bool EsAdministrador()
        {
            //Thread.GetDomain().SetPrincipalPolicy(PrincipalPolicy.WindowsPrincipal);

            //WindowsPrincipal myUser = (WindowsPrincipal)Thread.CurrentPrincipal;
            //return myUser.IsInRole(WindowsBuiltInRole.Administrator);
            return true;
        }

        private void btnParteNuevo_Click(object sender, EventArgs e)
        {
            if(this.comboAppValueSelected == Convert.ToInt32(Aplicaciones_Externas.Aplicacion_Externa.ISP))
            {
                funcionISP();
            }
            else if(this.comboAppValueSelected == Convert.ToInt32(Aplicaciones_Externas.Aplicacion_Externa.CASS))
            {
                funcionCASS();
            }
        }

        private void funcionCASS()
        {         
            if (dgvPartes.Rows.Count == 0)
            {
                MessageBox.Show("No hay registros en la grilla", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (idParteOperacion == (int)Partes.Partes_Operaciones.CORTE)
            {
                DataView dvPartesSeleccionados = ((DataTable)dgvPartes.DataSource).DefaultView;
                dvPartesSeleccionados.RowFilter = string.Format("Seleccionar={0}", true);
                DataTable dtPartesSelec = dvPartesSeleccionados.ToTable();
                dtErrores.Clear();
                //Se recorren los partes seleccionados
                foreach (DataRow row in dtPartesSelec.Rows)
                {
                    idUsuario= Convert.ToInt32(row["id_usuarios"]);
                    int id_usuario_servicio = Convert.ToInt32(row["id_usuarios_servicios"]);
                    string usuario = row["usuario"].ToString();
                    idAppExterna = Convert.ToInt32(row["id_aplicaciones_externas"]);
                    DataTable dtEquiposPorUsuarioServicio = new Equipos().BuscarEquipoPorUsuarioServicio(id_usuario_servicio);

                    if(dtEquiposPorUsuarioServicio.Rows.Count == 0)
                    {
                        AgregarError("El el servicio no contiene equipo asignado", usuario, id_usuario_servicio);
                        continue;
                    }

                    //Se recorren los equipos por usuario servicio
                    foreach (DataRow rowEquipo in dtEquiposPorUsuarioServicio.Rows)
                    {
                        string numTarjeta = rowEquipo["numtarjeta"].ToString();

                        if (String.IsNullOrEmpty(numTarjeta))
                        {
                            AgregarError("El equipo no tiene numero de tarjeta asignado", usuario, id_usuario_servicio);
                            continue;
                        }
                        dtDatosAplicacionExterna = oAppExterna.Listar(idAppExterna);
                        if(dtDatosAplicacionExterna.Rows.Count>0)
                        {
                            if(dtDatosAplicacionExterna.Rows[0]["nombre"].ToString().ToLower().Equals("cass"))
                            {
                                oCass = new Cass(idAppExterna);
                                DataTable dtPaquetes = oCass.ListarPaquetesTarjeta(Convert.ToDouble(numTarjeta));

                                if(dtPaquetes.Rows.Count == 0)
                                {
                                    AgregarError($"No hay paquetes asignados a la tarjeta {numTarjeta}", usuario, id_usuario_servicio);
                                    continue;
                                }

                                //Se recorren los paquetes por numero de tarjeta
                                foreach (DataRow rowPaquete in dtPaquetes.Rows)
                                {
                                    string salida;
                                    bool seDesactivo = oCass.DesactivarPaquete(idUsuario,numTarjeta, rowPaquete["paquete"].ToString(), out salida);      

                                    if (!seDesactivo)
                                    {
                                        MessageBox.Show(salida);
                                    }
                                }
                            }
                        }
                    }
                    DataTable dtax = dtErrores.Copy();
                }
            }
        }

        private void funcionISP()
        {
            dtMultiplesCuentasAcceso.Clear();
            if (dgvPartes.SelectedRows.Count > 0)
            {
                if (idParteOperacion == (int)Partes.Partes_Operaciones.CONEXION)
                {
                    fechaParte = Convert.ToDateTime(dgvPartes.SelectedRows[0].Cells["fecha_programado"].Value);
                    fechaParte = fechaParte.Date;
                    comparaFecha = fechaParte.CompareTo(DateTime.Now.Date);

                    if (comparaFecha <= 0)
                    {
                        frmVerISP frmEquipoConfiguracion = new frmVerISP();
                        frmEquipoConfiguracion.codUsuario = this.codUsuario;
                        frmEquipoConfiguracion.usuario = this.usuario;
                        frmEquipoConfiguracion.locacion = this.locacion;
                        frmEquipoConfiguracion.servicio = this.servicio;
                        frmEquipoConfiguracion.velocidad = this.velocidad;
                        frmEquipoConfiguracion.velocidad_tipo = this.velocidad_tipo;
                        frmEquipoConfiguracion.nombreOperacion = this.operacion;
                        frmEquipoConfiguracion.emailUsuario = this.correoUsuario;
                        frmEquipoConfiguracion.apellidoUsuario = this.apellidoUsuario;
                        frmEquipoConfiguracion.nombreUsuario = this.nombreUsuario;
                        frmEquipoConfiguracion.telefonoUsuario = this.telefonoUsuario;
                        frmEquipoConfiguracion.telefonoUsuario2 = this.tel2;
                        frmEquipoConfiguracion.codPostal = this.codPostal;
                        frmEquipoConfiguracion.direccion1 = this.usuarioCalle1;
                        frmEquipoConfiguracion.ciudadUsuario = this.ciudad;
                        frmEquipoConfiguracion.idServicio = this.idServicio;
                        frmEquipoConfiguracion.idUsuarioServicio = this.idUsuarioServicio;
                        frmEquipoConfiguracion.idUsuario = this.idUsuario;
                        frmEquipoConfiguracion.idLocacion = this.idLocacion;
                        frmEquipoConfiguracion.idParte = this.idParte;
                        frmEquipoConfiguracion.idParteUsuarioServicio = this.idParteUsuarioServicio;
                        frmEquipoConfiguracion.idOperacion = this.idParteOperacion;
                        frmEquipoConfiguracion.idAccion = (int)frmVerISP.acciones.CONEXION;
                        if (frmEquipoConfiguracion.ShowDialog() == DialogResult.OK)
                            comenzarCarga();
                    }
                    else
                    {
                        if (MessageBox.Show("Este parte esta progrmado para una fecha posterior. Desea realizarlo de todos modos", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                        {
                            frmVerISP frmEquipoConfiguracion = new frmVerISP();
                            frmEquipoConfiguracion.codUsuario = this.codUsuario;
                            frmEquipoConfiguracion.usuario = this.usuario;
                            frmEquipoConfiguracion.locacion = this.locacion;
                            frmEquipoConfiguracion.servicio = this.servicio;
                            frmEquipoConfiguracion.velocidad = this.velocidad;
                            frmEquipoConfiguracion.velocidad_tipo = this.velocidad_tipo;
                            frmEquipoConfiguracion.nombreOperacion = this.operacion;
                            frmEquipoConfiguracion.emailUsuario = this.correoUsuario;
                            frmEquipoConfiguracion.apellidoUsuario = this.apellidoUsuario;
                            frmEquipoConfiguracion.nombreUsuario = this.nombreUsuario;
                            frmEquipoConfiguracion.telefonoUsuario = this.telefonoUsuario;
                            frmEquipoConfiguracion.telefonoUsuario2 = this.tel2;
                            frmEquipoConfiguracion.codPostal = this.codPostal;
                            frmEquipoConfiguracion.direccion1 = this.usuarioCalle1;
                            frmEquipoConfiguracion.ciudadUsuario = this.ciudad;
                            frmEquipoConfiguracion.idServicio = this.idServicio;
                            frmEquipoConfiguracion.idUsuarioServicio = this.idUsuarioServicio;
                            frmEquipoConfiguracion.idUsuario = this.idUsuario;
                            frmEquipoConfiguracion.idLocacion = this.idLocacion;
                            frmEquipoConfiguracion.idParte = this.idParte;
                            frmEquipoConfiguracion.idParteUsuarioServicio = this.idParteUsuarioServicio;
                            frmEquipoConfiguracion.idOperacion = this.idParteOperacion;
                            frmEquipoConfiguracion.idAccion = (int)frmVerISP.acciones.CONEXION;
                            if (frmEquipoConfiguracion.ShowDialog() == DialogResult.OK)
                                comenzarCarga();
                        }
                    }
                }
                else if (idParteOperacion == (int)Partes.Partes_Operaciones.CAMBIO_DE_EQUIPO)
                {

                    fechaParte = Convert.ToDateTime(dgvPartes.SelectedRows[0].Cells["fecha_programado"].Value);
                    fechaParte = fechaParte.Date;
                    comparaFecha = fechaParte.CompareTo(DateTime.Now.Date);
                    if (comparaFecha <= 0)
                    {
                        frmVerISP frmEquipoConfiguracion = new frmVerISP();
                        frmEquipoConfiguracion.cambioEquipo = true;
                        frmEquipoConfiguracion.seleccionarProducto = false;

                        frmEquipoConfiguracion.codUsuario = this.codUsuario;
                        frmEquipoConfiguracion.usuario = this.usuario;
                        frmEquipoConfiguracion.locacion = this.locacion;
                        frmEquipoConfiguracion.servicio = this.servicio;
                        frmEquipoConfiguracion.velocidad = this.velocidad;
                        frmEquipoConfiguracion.velocidad_tipo = this.velocidad_tipo;
                        frmEquipoConfiguracion.nombreOperacion = this.operacion;
                        frmEquipoConfiguracion.emailUsuario = this.correoUsuario;
                        frmEquipoConfiguracion.apellidoUsuario = this.apellidoUsuario;
                        frmEquipoConfiguracion.nombreUsuario = this.nombreUsuario;
                        frmEquipoConfiguracion.telefonoUsuario = this.telefonoUsuario;
                        frmEquipoConfiguracion.telefonoUsuario2 = this.tel2;
                        frmEquipoConfiguracion.codPostal = this.codPostal;
                        frmEquipoConfiguracion.direccion1 = this.usuarioCalle1;
                        frmEquipoConfiguracion.ciudadUsuario = this.ciudad;
                        frmEquipoConfiguracion.idServicio = this.idServicio;
                        frmEquipoConfiguracion.idUsuarioServicio = this.idUsuarioServicio;
                        frmEquipoConfiguracion.idUsuario = this.idUsuario;
                        frmEquipoConfiguracion.idLocacion = this.idLocacion;
                        frmEquipoConfiguracion.idParte = this.idParte;
                        frmEquipoConfiguracion.idParteUsuarioServicio = this.idParteUsuarioServicio;
                        frmEquipoConfiguracion.idEquipoViejo = this.idEquipoViejo;
                        frmEquipoConfiguracion.idEquipoNuevo = this.idEquipoNuevo;
                        frmEquipoConfiguracion.idAccion = (int)frmVerISP.acciones.CAMBIO_EQUIPO;

                        if (frmEquipoConfiguracion.ShowDialog() == DialogResult.OK)
                            comenzarCarga();
                    }
                    else
                    {
                        if (MessageBox.Show("Este parte esta progrmado para una fecha posterior. Desea realizarlo de todos modos", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.OK)
                        {
                            frmVerISP frmEquipoConfiguracion = new frmVerISP();
                            frmEquipoConfiguracion.cambioEquipo = true;
                            frmEquipoConfiguracion.seleccionarProducto = false;

                            frmEquipoConfiguracion.codUsuario = this.codUsuario;
                            frmEquipoConfiguracion.usuario = this.usuario;
                            frmEquipoConfiguracion.locacion = this.locacion;
                            frmEquipoConfiguracion.servicio = this.servicio;
                            frmEquipoConfiguracion.velocidad = this.velocidad;
                            frmEquipoConfiguracion.velocidad_tipo = this.velocidad_tipo;
                            frmEquipoConfiguracion.nombreOperacion = this.operacion;
                            frmEquipoConfiguracion.emailUsuario = this.correoUsuario;
                            frmEquipoConfiguracion.apellidoUsuario = this.apellidoUsuario;
                            frmEquipoConfiguracion.nombreUsuario = this.nombreUsuario;
                            frmEquipoConfiguracion.telefonoUsuario = this.telefonoUsuario;
                            frmEquipoConfiguracion.telefonoUsuario2 = this.tel2;
                            frmEquipoConfiguracion.codPostal = this.codPostal;
                            frmEquipoConfiguracion.direccion1 = this.usuarioCalle1;
                            frmEquipoConfiguracion.ciudadUsuario = this.ciudad;
                            frmEquipoConfiguracion.idServicio = this.idServicio;
                            frmEquipoConfiguracion.idUsuarioServicio = this.idUsuarioServicio;
                            frmEquipoConfiguracion.idUsuario = this.idUsuario;
                            frmEquipoConfiguracion.idLocacion = this.idLocacion;
                            frmEquipoConfiguracion.idParte = this.idParte;
                            frmEquipoConfiguracion.idParteUsuarioServicio = this.idParteUsuarioServicio;
                            frmEquipoConfiguracion.idEquipoViejo = this.idEquipoViejo;
                            frmEquipoConfiguracion.idEquipoNuevo = this.idEquipoNuevo;
                            frmEquipoConfiguracion.idAccion = (int)frmVerISP.acciones.CAMBIO_EQUIPO;


                            if (frmEquipoConfiguracion.ShowDialog() == DialogResult.OK)
                                comenzarCarga();
                        }
                    }
                }
                else if (idParteOperacion == (int)Partes.Partes_Operaciones.BAJA)
                {

                    int idCustomer = 0, idLocation, idAccountAccess = 0, idAppExterna = 0, cantidadHechos = 0, cantidadErrores = 0, cantidadSeleccionados = 0;
                    dtAccesAccounts = new DataTable();
                    dtDatosUsuarioServiciosSub = new DataTable();
                    dtDatosServicio = new DataTable();
                    dtFiltrada = new DataTable();
                    dtDatosUsuarioServicioExterno = new DataTable();
                    dtDatosAplicacionExterna = new DataTable();

                    foreach (DataGridViewRow row in dgvPartes.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells["seleccionar"].Value) == true)
                            cantidadSeleccionados++;
                    }

                    foreach (DataGridViewRow item in dgvPartes.Rows)
                    {
                        if (Convert.ToBoolean(item.Cells["seleccionar"].Value) == true)
                        {
                            fechaParte = Convert.ToDateTime(item.Cells["fecha_programado"].Value);
                            fechaParte = fechaParte.Date;
                            comparaFecha = fechaParte.CompareTo(DateTime.Now.Date);

                            if (comparaFecha <= 0)
                            {
                                try
                                {
                                    this.idServicio = Convert.ToInt32(item.Cells["id_servicio"].Value);
                                    this.idUsuarioServicio = Convert.ToInt32(item.Cells["id_usuarios_servicios"].Value);
                                    this.idUsuario = Convert.ToInt32(item.Cells["id_usuarios"].Value);
                                    this.idLocacion = Convert.ToInt32(item.Cells["id_usuarios_locaciones"].Value);
                                    this.codUsuario = Convert.ToInt32(item.Cells["codigo"].Value);
                                    this.servicio = item.Cells["servicio"].Value.ToString();
                                    this.locacion = item.Cells["locacion"].Value.ToString();
                                    this.velocidad = item.Cells["velocidad"].Value.ToString();
                                    this.velocidad_tipo = item.Cells["velocidad_tipo"].Value.ToString();
                                    this.operacion = item.Cells["falla"].Value.ToString();
                                    this.usuario = item.Cells["usuario"].Value.ToString();
                                    this.idParte = Convert.ToInt32(item.Cells["id_parte"].Value);
                                    this.apellidoUsuario = item.Cells["apellido"].Value.ToString();
                                    this.nombreUsuario = item.Cells["nombre"].Value.ToString();
                                    this.telefonoUsuario = item.Cells["telefono_1"].Value.ToString();
                                    this.tel2 = item.Cells["telefono_2"].Value.ToString();
                                    this.correoUsuario = item.Cells["correo_electronico"].Value.ToString();
                                    this.usuarioCalle1 = item.Cells["calle"].Value.ToString() + " " + item.Cells["altura"].Value.ToString();
                                    this.usuarioCalle2 = item.Cells["calle"].Value.ToString() + " " + item.Cells["altura"].Value.ToString();
                                    this.ciudad = item.Cells["localidad"].Value.ToString();
                                    this.codPostal = item.Cells["codigo_postal"].Value.ToString();
                                    this.idParteOperacion = Convert.ToInt32(item.Cells["id_partes_operaciones"].Value);
                                    this.idParteUsuarioServicio = Convert.ToInt32(item.Cells["id_parte_us"].Value);
                                    this.idParteSeleccionado = this.idParte;

                                    dtDatosServicio = oServicios.BuscarDatosServicio(this.idServicio);
                                    idAppExterna = Convert.ToInt32(dtDatosServicio.Rows[0]["id_aplicaciones_Externas"]);
                                    dtDatosAplicacionExterna = oAppExterna.Listar(idAppExterna);
                                    Isp.cadenaConexion = dtDatosAplicacionExterna.Rows[0]["string_conexion"].ToString();
                                    idCustomer = oISP.VerificarExisteUsuario(this.codUsuario);

                                    if (idCustomer > 0)
                                    {
                                        idLocation = oISP.VerificarExisteLocacion(this.idLocacion);
                                        dtAccesAccounts = oISP.ListarAccessAccount(idCustomer, 0);
                                        if (dtAccesAccounts.Rows.Count > 0)
                                        {
                                            if (dtAccesAccounts.Rows.Count > 1)
                                            {
                                                if(cantidadSeleccionados == 1)
                                                {
                                                    MessageBox.Show("El usuario cuenta con mas de una cuenta de acceso, seleccione la cuenta que desea dar de baja el servicio", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                    frmSeleccionarCuentasAccesoISP frmSelecCtaAcceso = new frmSeleccionarCuentasAccesoISP(this.codUsuario);
                                                    frmPopUp popUp = new frmPopUp();
                                                    popUp.Formulario = frmSelecCtaAcceso;
                                                    popUp.Maximizar = false;

                                                    if (popUp.ShowDialog() == DialogResult.OK)
                                                    {
                                                        idAccountAccess = frmSelecCtaAcceso.idAccountSeleccionado;
                                                        dtDatosUsuarioServicioExterno = oAppExterna.ListarDatosCuentaAcceso(idAccountAccess);
                                                        if (dtDatosUsuarioServicioExterno.Rows.Count > 0)
                                                        {
                                                            idProductoAux = Convert.ToInt32(dtDatosUsuarioServicioExterno.Rows[0]["id_producto"]);
                                                        }
                                                        if (oISP.BajarServicio(idAccountAccess) == 0)
                                                        {
                                                            if (oAppExterna.CambiarProducto(idAccountAccess, 123, idProductoAux) == 0)
                                                            {
                                                                if (cantidadSeleccionados == 1)
                                                                    MessageBox.Show("Servicio dado de baja correctamente", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                                oPartes.PasarAConfigurado(idParteUsuarioServicio);
                                                                oUsuarioServicio.ActualizarEstado(idUsuarioServicio, (int)Servicios.Servicios_Estados.RETIRADO);

                                                                cantidadHechos++;
                                                            }
                                                            else
                                                            {
                                                                string msjError = $"Error al intentar realizar la baja del servicio en el GIES";
                                                                GuardarErrorDeAplicacionExterna("BAJA", msjError, idCustomer, 0, idAccountAccess, idProductoAux);
                                                            }
                                                        }
                                                        else
                                                        {
                                                            string msjError = $"Error al intentar hacer la baja del servicio (producto que se intento dar de baja [{idProductoAux}])";
                                                            GuardarErrorDeAplicacionExterna("BAJA", msjError, idCustomer, 0, idAccountAccess, idProductoAux);
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    DataRow dr = dtMultiplesCuentasAcceso.NewRow();
                                                    dr["idUsuario"] = this.idUsuario;
                                                    dr["codUsuario"] = this.codUsuario;
                                                    dr["idParte"] = this.idParte;
                                                    dr["idCustomer"] = idCustomer;
                                                    List<int> listaCtasAcceso = new List<int>();
                                                    foreach (DataRow row in dtAccesAccounts.Rows)
                                                    {
                                                        listaCtasAcceso.Add(Convert.ToInt32(row["account_id"]));
                                                    }
                                                    dr["cuentasAcceso"] = listaCtasAcceso;
                                                    dtMultiplesCuentasAcceso.Rows.Add(dr);
                                                }
                                            }
                                            else
                                            {
                                                idAccountAccess = Convert.ToInt32(dtAccesAccounts.Rows[0]["account_id"]);
                                                dtDatosUsuarioServicioExterno = oAppExterna.ListarDatosCuentaAcceso(idAccountAccess);
                                                if (dtDatosUsuarioServicioExterno.Rows.Count > 0)
                                                {
                                                    idProductoAux = Convert.ToInt32(dtDatosUsuarioServicioExterno.Rows[0]["id_producto"]);
                                                }
                                                if (oISP.BajarServicio(idAccountAccess) == 0)
                                                {
                                                    if (oAppExterna.CambiarProducto(idAccountAccess, 123, idProductoAux) == 0)
                                                    {
                                                        if (cantidadSeleccionados == 1)
                                                            MessageBox.Show("Servicio dado de baja correctamente", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                        oPartes.PasarAConfigurado(idParteUsuarioServicio);
                                                        oUsuarioServicio.ActualizarEstado(idUsuarioServicio, (int)Servicios.Servicios_Estados.RETIRADO);

                                                        cantidadHechos++;
                                                    }
                                                    else
                                                    {
                                                        string msjError = $"Error al intentar realizar la baja del servicio en el GIES";
                                                        GuardarErrorDeAplicacionExterna("BAJA", msjError, idCustomer, 0, idAccountAccess, idProductoAux);
                                                    }
                                                }
                                                else
                                                {
                                                    string msjError = $"Error al intentar hacer la baja del servicio (producto que se intento dar de baja [{idProductoAux}])";
                                                    GuardarErrorDeAplicacionExterna("BAJA", msjError, idCustomer, 0, idAccountAccess, idProductoAux);
                                                }
                                            }
                                        }
                                        else
                                        {
                                            string msjError = $"Account access del usuario externo no encontrada (Id_Usuario_Externo: {idCustomer})";
                                            GuardarErrorDeAplicacionExterna("BAJA", msjError, idCustomer);

                                            if (cantidadSeleccionados == 1)
                                                MessageBox.Show(string.Format("Error al reconectar servicio en el ISP. No se encontraron datos de cuenta de acceso en ISP. ID CUSTOMER: {0}", idCustomer), "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            cantidadErrores++;
                                        }
                                    }
                                    else
                                    {
                                        string msjError = $"Usuario (Id_Usuario: {this.idUsuario}) del gies no encontrado en aplicacion externa";
                                        GuardarErrorDeAplicacionExterna("BAJA", msjError);
                                    }
                                }
                                catch (Exception c)
                                {
                                    mensaje = c.Message;
                                    cantidadErrores++;
                                }
                            }
                        }
                    }
                    if (dtMultiplesCuentasAcceso.Rows.Count > 0)
                    {
                        frmPopUp popUp = new frmPopUp();
                        popUp.Formulario = new frmPartesConMultiplesCtasAcceso(dtMultiplesCuentasAcceso, "Estos partes de baja de servicio no se pudieron realizar. Manualmente se deberan seleccionar por separado e indicar que producto se desea dar de baja");
                        popUp.Maximizar = false;
                        popUp.ShowDialog();
                    }

                    if (cantidadSeleccionados > 0 && cantidadErrores > 0)
                    {
                        MessageBox.Show(string.Format("Hubo {0} errores de {1} partes procesados: {2}", cantidadErrores, cantidadSeleccionados, mensaje), "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        if (cantidadHechos > 0)
                        {
                            idOperacionSeleccionado = Convert.ToInt32(cboOperaciones.SelectedValue);
                            comenzarCarga();
                        }
                    }

                    if (cantidadHechos > 0)
                    {
                        idOperacionSeleccionado = Convert.ToInt32(cboOperaciones.SelectedValue);
                        comenzarCarga();
                    }
                }
                else if (idParteOperacion == (int)Partes.Partes_Operaciones.RECONEXION)
                {
                    if (EsAdministrador() != true)
                    {
                        MessageBox.Show("No se pueden realizar los cortes o reconexiones si no eejecuta el sistema como usuario administrado", "Mensaje del Sisema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        int contador = 0, cantidadHechos = 0, cantidadErrores = 0, cantidadSeleccionados = 0;
                        dtDatosServicio = new DataTable();
                        dtDatosAplicacionExterna = new DataTable();
                        dtAccesAccounts = new DataTable();
                        dtDatosUsuarioServicioExterno = new DataTable();

                        oServicios = new Servicios();
                        dtDatosServicio = oServicios.BuscarDatosServicio(idServicio);
                        int idAplicacionExterna = 0;
                        int idCustomer = 0, idLocation, idAccountAccess = 0;

                        foreach (DataGridViewRow item in dgvPartes.Rows)
                        {
                            if (Convert.ToBoolean(item.Cells["seleccionar"].Value) == true)
                                cantidadSeleccionados++;
                        }
                        foreach (DataGridViewRow item in dgvPartes.Rows)
                        {
                            if (Convert.ToBoolean(item.Cells["seleccionar"].Value) == true)
                            {
                                fechaParte = Convert.ToDateTime(item.Cells["fecha_programado"].Value);
                                fechaParte = fechaParte.Date;
                                comparaFecha = fechaParte.CompareTo(DateTime.Now.Date);

                                if (comparaFecha <= 0)
                                {

                                    try
                                    {
                                        this.idServicio = Convert.ToInt32(item.Cells["id_servicio"].Value);
                                        this.idUsuarioServicio = Convert.ToInt32(item.Cells["id_usuarios_servicios"].Value);
                                        this.idUsuario = Convert.ToInt32(item.Cells["id_usuarios"].Value);
                                        this.idLocacion = Convert.ToInt32(item.Cells["id_usuarios_locaciones"].Value);
                                        this.codUsuario = Convert.ToInt32(item.Cells["codigo"].Value);
                                        this.servicio = item.Cells["servicio"].Value.ToString();
                                        this.locacion = item.Cells["locacion"].Value.ToString();
                                        this.velocidad = item.Cells["velocidad"].Value.ToString();
                                        this.velocidad_tipo = item.Cells["velocidad_tipo"].Value.ToString();
                                        this.operacion = item.Cells["falla"].Value.ToString();
                                        this.usuario = item.Cells["usuario"].Value.ToString();
                                        this.idParte = Convert.ToInt32(item.Cells["id_parte"].Value);
                                        this.apellidoUsuario = item.Cells["apellido"].Value.ToString();
                                        this.nombreUsuario = item.Cells["nombre"].Value.ToString();
                                        this.telefonoUsuario = item.Cells["telefono_1"].Value.ToString();
                                        this.tel2 = item.Cells["telefono_2"].Value.ToString();
                                        this.correoUsuario = item.Cells["correo_electronico"].Value.ToString();
                                        this.usuarioCalle1 = item.Cells["calle"].Value.ToString() + " " + item.Cells["altura"].Value.ToString();
                                        this.usuarioCalle2 = item.Cells["calle"].Value.ToString() + " " + item.Cells["altura"].Value.ToString();
                                        this.ciudad = item.Cells["localidad"].Value.ToString();
                                        this.codPostal = item.Cells["codigo_postal"].Value.ToString();
                                        this.idParteOperacion = Convert.ToInt32(item.Cells["id_partes_operaciones"].Value);
                                        this.idParteUsuarioServicio = Convert.ToInt32(item.Cells["id_parte_us"].Value);
                                        this.idParteSeleccionado = this.idParte;
                                        if (Convert.ToInt32(dtDatosServicio.Rows[0]["id_servicios_modalidad"]) == (int)Servicios._Modalidad.DIA)
                                        {
                                            if (contador == 0)
                                            {
                                                idAplicacionExterna = Convert.ToInt32(dtDatosServicio.Rows[0]["id_aplicaciones_externas"]);
                                                dtDatosAplicacionExterna = oAppExterna.Listar(idAplicacionExterna);
                                                Isp.cadenaConexion = dtDatosAplicacionExterna.Rows[0]["string_conexion"].ToString();

                                            }
                                            if (dtDatosAplicacionExterna.Rows[0]["nombre"].ToString().Equals("ISP"))
                                            {
                                                idCustomer = oISP.VerificarExisteUsuario(this.codUsuario);
                                                if (idCustomer > 0)
                                                {
                                                    idLocation = oISP.VerificarExisteLocacion(this.idLocacion);
                                                    dtAccesAccounts = oISP.ListarAccessAccount(idCustomer, 0);
                                                    if (dtAccesAccounts.Rows.Count > 0)
                                                    {
                                                        idAccountAccess = Convert.ToInt32(dtAccesAccounts.Rows[0]["account_id"]);
                                                        dtDatosUsuarioServicioExterno = oAppExterna.ListarDatosCuentaAcceso(idAccountAccess);
                                                        idProductoAux = 153;//internet prepago 8mb
                                                        if (dtDatosUsuarioServicioExterno.Rows.Count == 0)
                                                        {
                                                            Aplicaciones_Externas oAppExternas = new Aplicaciones_Externas();
                                                            oAppExternas.GuardarUsuarioProducto(idUsuario, idLocacion, idProductoAux, idAccountAccess, Convert.ToInt32(dtAccesAccounts.Rows[0]["customer_id"]), Convert.ToInt32(dtAccesAccounts.Rows[0]["location_id"]), Personal.Id_Login);
                                                            dtDatosUsuarioServicioExterno = oAppExterna.ListarDatosCuentaAcceso(idAccountAccess);
                                                        }
                                                        if (oISP.CambiarProducto(idAccountAccess, idProductoAux) == 0)
                                                        {
                                                            //correr script
                                                            Desconectar(idAccountAccess);

                                                            if (cantidadSeleccionados == 1)
                                                                MessageBox.Show("Servicio reconectado en ISP correctamente", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                            if (oAppExterna.CambiarProducto(idAccountAccess, idProductoAux, 0) == 0)
                                                            {
                                                                if (cantidadSeleccionados == 1)
                                                                    MessageBox.Show("Servicio reconectado en GIES correctamente", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                                oPartes.PasarAConfigurado(idParteUsuarioServicio);
                                                                oParteComun.ParteRealizado(idParte, DateTime.Now, 0, 0, "RECONECTADO AUTOMATICAMENTE");
                                                                oUsuarioServicio.ActualizarEstado(idUsuarioServicio, (int)Servicios.Servicios_Estados.CONECTADO,0);
                                                                oParteHistorial.Id_Partes_Estados = (int)Partes.Partes_Estados.REALIZADO;
                                                                oParteHistorial.Id_Parte = idParte;
                                                                oParteHistorial.Id_Usuarios = Convert.ToInt32(dgvPartes.SelectedRows[0].Cells["id_usuarios"].Value);
                                                                oParteHistorial.Id_Personal = Personal.Id_Login;
                                                                oParteHistorial.Fecha_Movimiento = DateTime.Now;
                                                                oParteHistorial.Id_area = Personal.Id_Area;
                                                                oParteHistorial.Detalles = "SERVICIO RECONECTADO.";
                                                                oParteHistorial.GuardarNuevoDetalle(oParteHistorial);
                                                                oGps.EnviarParte(idParte);
                                                                cantidadHechos++;
                                                                //comenzarCarga();
                                                            }
                                                            else
                                                            {
                                                                string msjError = $"Error al intentar realizar la reconexion en el GIES";
                                                                GuardarErrorDeAplicacionExterna("RECONEXION", msjError, idCustomer, Convert.ToInt32(dtAccesAccounts.Rows[0]["location_id"]), idAccountAccess, idProductoAux);
                                                            }
                                                        }
                                                        else
                                                        {
                                                            string msjError = $"Error al intentar hacer la reconexion del servicio (producto que se intento reconectar [{idProductoAux}])";
                                                            GuardarErrorDeAplicacionExterna("RECONEXION", msjError, idCustomer, Convert.ToInt32(dtAccesAccounts.Rows[0]["location_id"]), idAccountAccess, idProductoAux);
                                                        }
                                                    }
                                                    else
                                                    {
                                                        string msjError = $"Account access del usuario externo no encontrada (Id_Usuario_Externo: {idCustomer})";
                                                        GuardarErrorDeAplicacionExterna("RECONEXION", msjError, idCustomer);

                                                        if (cantidadSeleccionados == 1)
                                                            MessageBox.Show(string.Format("Error al reconectar servicio en el ISP. No se encontraron datos de cuenta de acceso en ISP. ID CUSTOMER: {0}", idCustomer), "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                        cantidadErrores++;
                                                    }

                                                }
                                                else
                                                {
                                                    string msjError = $"Usuario (Id_Usuario: {this.idUsuario}) del gies no encontrado en aplicacion externa";
                                                    GuardarErrorDeAplicacionExterna("RECONEXION", msjError);

                                                    if (cantidadSeleccionados == 1)
                                                        MessageBox.Show("Error al reconectar servicio en el ISP. No se encontro ID CUSTOMER", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                    cantidadErrores++;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            if (contador == 0)
                                            {
                                                idAplicacionExterna = Convert.ToInt32(dtDatosServicio.Rows[0]["id_aplicaciones_externas"]);
                                                dtDatosAplicacionExterna = oAppExterna.Listar(idAplicacionExterna);
                                                Isp.cadenaConexion = dtDatosAplicacionExterna.Rows[0]["string_conexion"].ToString();
                                            }
                                            if (dtDatosAplicacionExterna.Rows[0]["nombre"].ToString().Equals("ISP"))
                                            {
                                                idCustomer = oISP.VerificarExisteUsuario(this.codUsuario);
                                                if (idCustomer > 0)
                                                {
                                                    idLocation = oISP.VerificarExisteLocacion(this.idLocacion);
                                                    dtAccesAccounts = oISP.ListarAccessAccount(idCustomer, 0);
                                                    if (dtAccesAccounts.Rows.Count > 0)
                                                    {
                                                        if (dtAccesAccounts.Rows.Count > 1)
                                                        {
                                                            if (cantidadSeleccionados == 1)
                                                            {
                                                                MessageBox.Show("El usuario cuenta con mas de una cuenta de acceso, seleccione la cuenta que desea reconectar", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                                frmSeleccionarCuentasAccesoISP frmSelecCtaAcceso = new frmSeleccionarCuentasAccesoISP(this.codUsuario);
                                                                frmPopUp popUp = new frmPopUp();
                                                                popUp.Formulario = frmSelecCtaAcceso;
                                                                popUp.Maximizar = false;

                                                                if (popUp.ShowDialog() == DialogResult.OK)
                                                                {
                                                                    idAccountAccess = frmSelecCtaAcceso.idAccountSeleccionado;
                                                                    dtDatosUsuarioServicioExterno = oAppExterna.ListarDatosCuentaAcceso(idAccountAccess);

                                                                    if (dtDatosUsuarioServicioExterno.Rows.Count > 0)
                                                                        idProductoAux = Convert.ToInt32(dtDatosUsuarioServicioExterno.Rows[0]["id_producto_aux"]);
                                                                    else
                                                                    {
                                                                        Aplicaciones_Externas oAppExternas = new Aplicaciones_Externas();
                                                                        oAppExternas.GuardarUsuarioProducto(idUsuario, idLocacion, 0, idAccountAccess, idCustomer, idLocation, Personal.Id_Login);
                                                                        dtDatosUsuarioServicioExterno = oAppExterna.ListarDatosCuentaAcceso(idAccountAccess);
                                                                    }

                                                                    if (idProductoAux == 0)
                                                                    {
                                                                        MessageBox.Show("No se encontro producto de ISP,seleccione uno.", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                                        frmVerISP frmEquipoConfiguracion2 = new frmVerISP();
                                                                        frmEquipoConfiguracion2.seleccionarProducto = true;
                                                                        frmEquipoConfiguracion2.codUsuario = this.codUsuario;
                                                                        frmEquipoConfiguracion2.usuario = this.usuario;
                                                                        frmEquipoConfiguracion2.locacion = this.locacion;
                                                                        frmEquipoConfiguracion2.servicio = this.servicio;
                                                                        frmEquipoConfiguracion2.velocidad = this.velocidad;
                                                                        frmEquipoConfiguracion2.velocidad_tipo = this.velocidad_tipo;
                                                                        frmEquipoConfiguracion2.nombreOperacion = this.operacion;
                                                                        frmEquipoConfiguracion2.emailUsuario = this.correoUsuario;
                                                                        frmEquipoConfiguracion2.apellidoUsuario = this.apellidoUsuario;
                                                                        frmEquipoConfiguracion2.nombreUsuario = this.nombreUsuario;
                                                                        frmEquipoConfiguracion2.telefonoUsuario = this.telefonoUsuario;
                                                                        frmEquipoConfiguracion2.telefonoUsuario2 = this.tel2;
                                                                        frmEquipoConfiguracion2.codPostal = this.codPostal;
                                                                        frmEquipoConfiguracion2.direccion1 = this.usuarioCalle1;
                                                                        frmEquipoConfiguracion2.ciudadUsuario = this.ciudad;
                                                                        frmEquipoConfiguracion2.idServicio = this.idServicio;
                                                                        frmEquipoConfiguracion2.idUsuarioServicio = this.idUsuarioServicio;
                                                                        frmEquipoConfiguracion2.idUsuario = this.idUsuario;
                                                                        frmEquipoConfiguracion2.idLocacion = this.idLocacion;
                                                                        frmEquipoConfiguracion2.idParte = this.idParte;
                                                                        frmEquipoConfiguracion2.idParteUsuarioServicio = this.idParteUsuarioServicio;
                                                                        frmEquipoConfiguracion2.idEquipoViejo = this.idEquipoViejo;
                                                                        frmEquipoConfiguracion2.idEquipoNuevo = this.idEquipoNuevo;
                                                                        frmEquipoConfiguracion2.idAccion = (int)frmVerISP.acciones.SELECCIONAR_PRODUCTO;

                                                                        if (frmEquipoConfiguracion2.ShowDialog() == DialogResult.OK)
                                                                            idProductoAux = frmEquipoConfiguracion2.idProductoSeleccionado;
                                                                    }

                                                                    if (oISP.CambiarProducto(idAccountAccess, idProductoAux) == 0)
                                                                    {
                                                                        //correr script
                                                                        Desconectar(idAccountAccess);

                                                                        MessageBox.Show("Servicio reconectado en ISP correctamente", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                                        if (oAppExterna.CambiarProducto(idAccountAccess, idProductoAux, 0) == 0)
                                                                        {
                                                                            MessageBox.Show("Servicio reconectado en GIES correctamente", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                                            oPartes.PasarAConfigurado(idParteUsuarioServicio);
                                                                            oUsuarioServicio.ActualizarEstado(idUsuarioServicio, (int)Servicios.Servicios_Estados.CONECTADO, 0);
                                                                            oParteComun.ParteRealizado(idParte, DateTime.Now, 0, 0, "RECONECTADO AUTOMATICAMENTE");
                                                                            oParteHistorial.Id_Partes_Estados = (int)Partes.Partes_Estados.REALIZADO;
                                                                            oParteHistorial.Id_Parte = idParte;
                                                                            oParteHistorial.Id_Usuarios = Convert.ToInt32(dgvPartes.SelectedRows[0].Cells["id_usuarios"].Value);
                                                                            oParteHistorial.Id_Personal = Personal.Id_Login;
                                                                            oParteHistorial.Fecha_Movimiento = DateTime.Now;
                                                                            oParteHistorial.Id_area = Personal.Id_Area;
                                                                            oParteHistorial.Detalles = "SERVICIO RECONECTADO.";
                                                                            oParteHistorial.GuardarNuevoDetalle(oParteHistorial);
                                                                            oGps.EnviarParte(idParte);
                                                                            cantidadHechos++;
                                                                        }
                                                                        else
                                                                        {
                                                                            string msjError = $"Error al intentar realizar la reconexion en el GIES";
                                                                            GuardarErrorDeAplicacionExterna("RECONEXION", msjError, idCustomer, idLocation, idAccountAccess, idProductoAux);
                                                                        }
                                                                    }
                                                                    else
                                                                    {
                                                                        string msjError = $"Error al intentar hacer la reconexion del servicio (producto que se intento reconectar [{idProductoAux}])";
                                                                        GuardarErrorDeAplicacionExterna("RECONEXION", msjError, idCustomer, idLocation, idAccountAccess, idProductoAux);
                                                                    }
                                                                }
                                                            }
                                                            else
                                                            {
                                                                DataRow dr = dtMultiplesCuentasAcceso.NewRow();
                                                                dr["idUsuario"] = this.idUsuario;
                                                                dr["codUsuario"] = this.codUsuario;
                                                                dr["idParte"] = this.idParte;
                                                                dr["idCustomer"] = idCustomer;
                                                                List<int> listaCtasAcceso = new List<int>();
                                                                foreach (DataRow row in dtAccesAccounts.Rows)
                                                                {
                                                                    listaCtasAcceso.Add(Convert.ToInt32(row["account_id"]));
                                                                }
                                                                dr["cuentasAcceso"] = listaCtasAcceso;
                                                                dtMultiplesCuentasAcceso.Rows.Add(dr);
                                                            }
                                                        }
                                                        else
                                                        {
                                                            idAccountAccess = Convert.ToInt32(dtAccesAccounts.Rows[0]["account_id"]);
                                                            dtDatosUsuarioServicioExterno = oAppExterna.ListarDatosCuentaAcceso(idAccountAccess);

                                                            if (dtDatosUsuarioServicioExterno.Rows.Count > 0)
                                                                idProductoAux = Convert.ToInt32(dtDatosUsuarioServicioExterno.Rows[0]["id_producto_aux"]);
                                                            else
                                                            {
                                                                Aplicaciones_Externas oAppExternas = new Aplicaciones_Externas();
                                                                oAppExternas.GuardarUsuarioProducto(idUsuario, idLocacion, 0, idAccountAccess, idCustomer, idLocation, Personal.Id_Login);
                                                                dtDatosUsuarioServicioExterno = oAppExterna.ListarDatosCuentaAcceso(idAccountAccess);
                                                            }

                                                            if( idProductoAux == 0 && cantidadSeleccionados > 1)
                                                            {
                                                                DataRow dr = dtMultiplesCuentasAcceso.NewRow();
                                                                dr["idUsuario"] = this.idUsuario;
                                                                dr["codUsuario"] = this.codUsuario;
                                                                dr["idParte"] = this.idParte;
                                                                dr["idCustomer"] = idCustomer;
                                                                List<int> listaCtasAcceso = new List<int>();
                                                                foreach (DataRow row in dtAccesAccounts.Rows)
                                                                {
                                                                    listaCtasAcceso.Add(Convert.ToInt32(row["account_id"]));
                                                                }
                                                                dr["cuentasAcceso"] = listaCtasAcceso;
                                                                dtMultiplesCuentasAcceso.Rows.Add(dr);
                                                            }
                                                            else
                                                            {
                                                                if (idProductoAux == 0)
                                                                {
                                                                    MessageBox.Show("No se encontro producto de ISP,seleccione uno.", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                                    frmVerISP frmEquipoConfiguracion2 = new frmVerISP();
                                                                    frmEquipoConfiguracion2.seleccionarProducto = true;
                                                                    frmEquipoConfiguracion2.codUsuario = this.codUsuario;
                                                                    frmEquipoConfiguracion2.usuario = this.usuario;
                                                                    frmEquipoConfiguracion2.locacion = this.locacion;
                                                                    frmEquipoConfiguracion2.servicio = this.servicio;
                                                                    frmEquipoConfiguracion2.velocidad = this.velocidad;
                                                                    frmEquipoConfiguracion2.velocidad_tipo = this.velocidad_tipo;
                                                                    frmEquipoConfiguracion2.nombreOperacion = this.operacion;
                                                                    frmEquipoConfiguracion2.emailUsuario = this.correoUsuario;
                                                                    frmEquipoConfiguracion2.apellidoUsuario = this.apellidoUsuario;
                                                                    frmEquipoConfiguracion2.nombreUsuario = this.nombreUsuario;
                                                                    frmEquipoConfiguracion2.telefonoUsuario = this.telefonoUsuario;
                                                                    frmEquipoConfiguracion2.telefonoUsuario2 = this.tel2;
                                                                    frmEquipoConfiguracion2.codPostal = this.codPostal;
                                                                    frmEquipoConfiguracion2.direccion1 = this.usuarioCalle1;
                                                                    frmEquipoConfiguracion2.ciudadUsuario = this.ciudad;
                                                                    frmEquipoConfiguracion2.idServicio = this.idServicio;
                                                                    frmEquipoConfiguracion2.idUsuarioServicio = this.idUsuarioServicio;
                                                                    frmEquipoConfiguracion2.idUsuario = this.idUsuario;
                                                                    frmEquipoConfiguracion2.idLocacion = this.idLocacion;
                                                                    frmEquipoConfiguracion2.idParte = this.idParte;
                                                                    frmEquipoConfiguracion2.idParteUsuarioServicio = this.idParteUsuarioServicio;
                                                                    frmEquipoConfiguracion2.idEquipoViejo = this.idEquipoViejo;
                                                                    frmEquipoConfiguracion2.idEquipoNuevo = this.idEquipoNuevo;
                                                                    frmEquipoConfiguracion2.idAccion = (int)frmVerISP.acciones.SELECCIONAR_PRODUCTO;

                                                                    if (frmEquipoConfiguracion2.ShowDialog() == DialogResult.OK)
                                                                        idProductoAux = frmEquipoConfiguracion2.idProductoSeleccionado;
                                                                }

                                                                if (oISP.CambiarProducto(idAccountAccess, idProductoAux) == 0)
                                                                {
                                                                    //correr script
                                                                    Desconectar(idAccountAccess);

                                                                    if(cantidadSeleccionados == 1)
                                                                        MessageBox.Show("Servicio reconectado en ISP correctamente", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                                    if (oAppExterna.CambiarProducto(idAccountAccess, idProductoAux, 0) == 0)
                                                                    {
                                                                        if(cantidadSeleccionados == 1)
                                                                            MessageBox.Show("Servicio reconectado en GIES correctamente", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                                        oPartes.PasarAConfigurado(idParteUsuarioServicio);
                                                                        oUsuarioServicio.ActualizarEstado(idUsuarioServicio, (int)Servicios.Servicios_Estados.CONECTADO, 0);
                                                                        oParteComun.ParteRealizado(idParte, DateTime.Now, 0, 0, "RECONECTADO AUTOMATICAMENTE");
                                                                        oParteHistorial.Id_Partes_Estados = (int)Partes.Partes_Estados.REALIZADO;
                                                                        oParteHistorial.Id_Parte = idParte;
                                                                        oParteHistorial.Id_Usuarios = Convert.ToInt32(dgvPartes.SelectedRows[0].Cells["id_usuarios"].Value);
                                                                        oParteHistorial.Id_Personal = Personal.Id_Login;
                                                                        oParteHistorial.Fecha_Movimiento = DateTime.Now;
                                                                        oParteHistorial.Id_area = Personal.Id_Area;
                                                                        oParteHistorial.Detalles = "SERVICIO RECONECTADO.";
                                                                        oParteHistorial.GuardarNuevoDetalle(oParteHistorial);
                                                                        oGps.EnviarParte(idParte);
                                                                        cantidadHechos++;
                                                                    }
                                                                    else
                                                                    {
                                                                        string msjError = $"Error al intentar realizar la reconexion en el GIES";
                                                                        GuardarErrorDeAplicacionExterna("RECONEXION", msjError, idCustomer, idLocation, idAccountAccess, idProductoAux);
                                                                    }
                                                                }
                                                                else
                                                                {
                                                                    string msjError = $"Error al intentar hacer la reconexion del servicio (producto que se intento reconectar [{idProductoAux}])";
                                                                    GuardarErrorDeAplicacionExterna("RECONEXION", msjError, idCustomer, idLocation, idAccountAccess, idProductoAux);
                                                                }
                                                            }
                                                        }
                                                    }
                                                    else
                                                    { 
                                                        string msjError = $"Account access del usuario externo no encontrada (Id_Usuario_Externo: {idCustomer})";
                                                        GuardarErrorDeAplicacionExterna("RECONEXION", msjError, idCustomer);

                                                        if (cantidadSeleccionados == 1)
                                                            MessageBox.Show(string.Format("Error al reconectar servicio en el ISP. No se encontraron datos de cuenta de acceso en ISP. ID CUSTOMER: {0}", idCustomer), "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                        cantidadErrores++;
                                                    }
                                                }
                                                else
                                                {
                                                    string msjError = $"Usuario (Id_Usuario: {this.idUsuario}) del gies no encontrado en aplicacion externa";
                                                    GuardarErrorDeAplicacionExterna("RECONEXION", msjError);

                                                    if (cantidadSeleccionados == 1)
                                                        MessageBox.Show("Error al reconectar servicio en el ISP. No se encontro ID CUSTOMER", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                    cantidadErrores++;
                                                }
                                            }
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        string msjError = $"Mensaje error: {ex.Message}, Tipo error: {ex.GetType().Name}";
                                        GuardarErrorDeAplicacionExterna("RECONEXION", msjError);
                                        cantidadErrores++;
                                    }
                                }
                            }
                        }
                        if (dtMultiplesCuentasAcceso.Rows.Count > 0)
                        {
                            frmPopUp popUp = new frmPopUp();
                            popUp.Formulario = new frmPartesConMultiplesCtasAcceso(dtMultiplesCuentasAcceso, "La reconexion de estos partes no se pudo realizar.Manualmente se deberan seleccionar por separado e indicar que producto se desea reconectar");
                            popUp.Maximizar = false;
                            popUp.ShowDialog();
                        }

                        if (cantidadSeleccionados > 0 && cantidadErrores > 0)
                        {
                            MessageBox.Show(string.Format("Hubo {0} errores de {1} partes procesados", cantidadErrores, cantidadSeleccionados), "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            if (cantidadHechos > 0)
                            {
                                idOperacionSeleccionado = Convert.ToInt32(cboOperaciones.SelectedValue);
                                comenzarCarga();
                            }
                        }
                        if (cantidadHechos > 0)
                        {
                            idOperacionSeleccionado = Convert.ToInt32(cboOperaciones.SelectedValue);
                            comenzarCarga();
                        }
                    }
                }
                else if (idParteOperacion == (int)Partes.Partes_Operaciones.CORTE)
                {
                    if (EsAdministrador() != true)
                    {
                        MessageBox.Show("No se pueden realizar los cortes o reconexiones si no eejecuta el sistema como usuario administrado", "Mensaje del Sisema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        int idCustomer = 0, idAplicacionExterna = 0, idLocation, idAccountAccess = 0, idAppExterna = 0, cantidadHechos = 0, cantidadErrores = 0, cantidadSeleccionados = 0, contador = 0;
                        cantidadHechos = 0;
                        cantidadErrores = 0;
                        cantidadSeleccionados = 0;

                        dtAccesAccounts = new DataTable();
                        dtDatosUsuarioServiciosSub = new DataTable();
                        dtDatosServicio = new DataTable();
                        dtFiltrada = new DataTable();
                        dtDatosUsuarioServicioExterno = new DataTable();
                        dtDatosAplicacionExterna = new DataTable();
                        dtDatosServicio = oServicios.BuscarDatosServicio(idServicio);

                        foreach (DataGridViewRow item in dgvPartes.Rows)
                        {
                            if (Convert.ToBoolean(item.Cells["seleccionar"].Value) == true)
                                cantidadSeleccionados++;
                        }

                        foreach (DataGridViewRow item in dgvPartes.Rows)
                        {
                            if (Convert.ToBoolean(item.Cells["seleccionar"].Value) == true)
                            {
                                fechaParte = Convert.ToDateTime(item.Cells["fecha_programado"].Value);
                                fechaParte = fechaParte.Date;
                                comparaFecha = fechaParte.CompareTo(DateTime.Now.Date);
                                if (comparaFecha <= 0)
                                {

                                    try
                                    {
                                        this.idServicio = Convert.ToInt32(item.Cells["id_servicio"].Value);
                                        this.idUsuarioServicio = Convert.ToInt32(item.Cells["id_usuarios_servicios"].Value);
                                        this.idUsuario = Convert.ToInt32(item.Cells["id_usuarios"].Value);
                                        this.idLocacion = Convert.ToInt32(item.Cells["id_usuarios_locaciones"].Value);
                                        this.codUsuario = Convert.ToInt32(item.Cells["codigo"].Value);
                                        this.servicio = item.Cells["servicio"].Value.ToString();
                                        this.locacion = item.Cells["locacion"].Value.ToString();
                                        this.velocidad = item.Cells["velocidad"].Value.ToString();
                                        this.velocidad_tipo = item.Cells["velocidad_tipo"].Value.ToString();
                                        this.operacion = item.Cells["falla"].Value.ToString();
                                        this.usuario = item.Cells["usuario"].Value.ToString();
                                        this.idParte = Convert.ToInt32(item.Cells["id_parte"].Value);
                                        this.apellidoUsuario = item.Cells["apellido"].Value.ToString();
                                        this.nombreUsuario = item.Cells["nombre"].Value.ToString();
                                        this.telefonoUsuario = item.Cells["telefono_1"].Value.ToString();
                                        this.tel2 = item.Cells["telefono_2"].Value.ToString();
                                        this.correoUsuario = item.Cells["correo_electronico"].Value.ToString();
                                        this.usuarioCalle1 = item.Cells["calle"].Value.ToString() + " " + item.Cells["altura"].Value.ToString();
                                        this.usuarioCalle2 = item.Cells["calle"].Value.ToString() + " " + item.Cells["altura"].Value.ToString();
                                        this.ciudad = item.Cells["localidad"].Value.ToString();
                                        this.codPostal = item.Cells["codigo_postal"].Value.ToString();
                                        this.idParteOperacion = Convert.ToInt32(item.Cells["id_partes_operaciones"].Value);
                                        this.idParteUsuarioServicio = Convert.ToInt32(item.Cells["id_parte_us"].Value);
                                        this.idParteSeleccionado = this.idParte;

                                        if (contador == 0)
                                        {
                                            idAplicacionExterna = Convert.ToInt32(dtDatosServicio.Rows[0]["id_aplicaciones_externas"]);
                                            dtDatosAplicacionExterna = oAppExterna.Listar(idAplicacionExterna);
                                            Isp.cadenaConexion = dtDatosAplicacionExterna.Rows[0]["string_conexion"].ToString();
                                            contador++;
                                        }
                                        if (dtDatosAplicacionExterna.Rows[0]["nombre"].ToString().Equals("ISP"))
                                        {
                                            idCustomer = oISP.VerificarExisteUsuario(this.codUsuario);
                                            if (idCustomer > 0)
                                            {
                                                idLocation = oISP.VerificarExisteLocacion(this.idLocacion);
                                                dtAccesAccounts = oISP.ListarAccessAccount(idCustomer, 0);
                                                if (dtAccesAccounts.Rows.Count > 0)
                                                {
                                                    if (dtAccesAccounts.Rows.Count > 1)
                                                    {
                                                        if (cantidadSeleccionados == 1)
                                                        {
                                                            MessageBox.Show("El usuario cuenta con mas de una cuenta de acceso, seleccione la cuenta que desea cortar el servicio", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                            frmSeleccionarCuentasAccesoISP frmSelecCtaAcceso = new frmSeleccionarCuentasAccesoISP(this.codUsuario);
                                                            frmPopUp popUp = new frmPopUp();
                                                            popUp.Formulario = frmSelecCtaAcceso;
                                                            popUp.Maximizar = false;
                                                            if (frmSelecCtaAcceso.ShowDialog() == DialogResult.OK)
                                                            {
                                                                idAccountAccess = frmSelecCtaAcceso.idAccountSeleccionado;
                                                                dtDatosUsuarioServicioExterno = oAppExterna.ListarDatosCuentaAcceso(idAccountAccess);
                                                                if (dtDatosUsuarioServicioExterno.Rows.Count > 0)
                                                                {
                                                                    idProductoAux = Convert.ToInt32(dtDatosUsuarioServicioExterno.Rows[0]["id_producto"]);
                                                                }
                                                                if (oISP.CortarServicio(idAccountAccess) == 0)
                                                                {
                                                                    //--------aca se corren los script
                                                                    if (cantidadSeleccionados == 1)
                                                                    {
                                                                        if (MessageBox.Show("¿Desconectar de isp?", "Mensaje del Sistema", MessageBoxButtons.YesNo) == DialogResult.Yes)
                                                                            Desconectar(idAccountAccess);
                                                                    }
                                                                    else
                                                                        Desconectar(idAccountAccess);
                                                                    //--------

                                                                    MessageBox.Show("Servicio cortado en ISP correctamente", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                                    if (oAppExterna.CambiarProducto(idAccountAccess, 103, idProductoAux) == 0)
                                                                    {
                                                                        MessageBox.Show("Servicio cortado en GIES correctamente", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                                        oPartes.PasarAConfigurado(idParteUsuarioServicio);
                                                                        oUsuarioServicio.ActualizarEstado(idUsuarioServicio, (int)Servicios.Servicios_Estados.CORTADO,0);
                                                                        oParteComun.ParteRealizado(idParte, DateTime.Now, 0, 0, "CORTADO AUTOMATICO");
                                                                        oParteHistorial.Id_Partes_Estados = (int)Partes.Partes_Estados.REALIZADO;
                                                                        oParteHistorial.Id_Parte = idParte;
                                                                        oParteHistorial.Id_Usuarios = Convert.ToInt32(dgvPartes.SelectedRows[0].Cells["id_usuarios"].Value);
                                                                        oParteHistorial.Id_Personal = Personal.Id_Login;
                                                                        oParteHistorial.Fecha_Movimiento = DateTime.Now;
                                                                        oParteHistorial.Id_area = Personal.Id_Area;
                                                                        oParteHistorial.Detalles = "SERVICIO CORTADO.";
                                                                        oParteHistorial.GuardarNuevoDetalle(oParteHistorial);
                                                                        cantidadHechos++;
                                                                        //comenzarCarga();
                                                                    }
                                                                    else
                                                                    {
                                                                        string msjError = $"Error al intentar realizar el corte en el GIES";
                                                                        GuardarErrorDeAplicacionExterna("CORTE", msjError, idCustomer, 0, idAccountAccess, idProductoAux);
                                                                    }
                                                                }
                                                                else
                                                                {
                                                                    string msjError = $"Error al intentar cortar el servicio (producto que se intento cortar [{idProductoAux}])";
                                                                    GuardarErrorDeAplicacionExterna("CORTE", msjError, idCustomer, 0, idAccountAccess, idProductoAux);
                                                                }                   
                                                            }
                                                        }
                                                        else
                                                        {
                                                            DataRow dr = dtMultiplesCuentasAcceso.NewRow();
                                                            dr["idUsuario"] = this.idUsuario;
                                                            dr["codUsuario"] = this.codUsuario;
                                                            dr["idParte"] = this.idParte;
                                                            dr["idCustomer"] = idCustomer;
                                                            List<int> listaCtasAcceso = new List<int>();
                                                            foreach (DataRow row in dtAccesAccounts.Rows)
                                                            {
                                                                listaCtasAcceso.Add(Convert.ToInt32(row["account_id"]));
                                                            }
                                                            dr["cuentasAcceso"] = listaCtasAcceso;
                                                            dtMultiplesCuentasAcceso.Rows.Add(dr);
                                                        }
                                                    }
                                                    else
                                                    {
                                                        idAccountAccess = Convert.ToInt32(dtAccesAccounts.Rows[0]["account_id"]);
                                                        dtDatosUsuarioServicioExterno = oAppExterna.ListarDatosCuentaAcceso(idAccountAccess);
                                                        if (dtDatosUsuarioServicioExterno.Rows.Count > 0)
                                                        {
                                                            idProductoAux = Convert.ToInt32(dtDatosUsuarioServicioExterno.Rows[0]["id_producto"]);
                                                        }
                                                        if (oISP.CortarServicio(idAccountAccess) == 0)
                                                        {
                                                            //--------aca se corren los script

                                                            Desconectar(idAccountAccess);
                                                            //--------
                                                            if (cantidadSeleccionados == 1)
                                                                MessageBox.Show("Servicio cortado en ISP correctamente. ", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                            if (oAppExterna.CambiarProducto(idAccountAccess, 103, idProductoAux) == 0)
                                                            {
                                                                if (cantidadSeleccionados == 1)
                                                                    MessageBox.Show("Servicio cortado en GIES correctamente", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                                oPartes.PasarAConfigurado(idParteUsuarioServicio);

                                                                oUsuarioServicio.ActualizarEstado(idUsuarioServicio, (int)Servicios.Servicios_Estados.CORTADO,0);
                                                                oParteComun.ParteRealizado(idParte, DateTime.Now, 0, 0, "CORTADO AUTOMATICO");

                                                                oParteHistorial.Id_Partes_Estados = (int)Partes.Partes_Estados.REALIZADO;
                                                                oParteHistorial.Id_Parte = idParte;
                                                                oParteHistorial.Id_Usuarios = Convert.ToInt32(dgvPartes.SelectedRows[0].Cells["id_usuarios"].Value);
                                                                oParteHistorial.Id_Personal = Personal.Id_Login;
                                                                oParteHistorial.Fecha_Movimiento = DateTime.Now;
                                                                oParteHistorial.Id_area = Personal.Id_Area;
                                                                oParteHistorial.Detalles = "SERVICIO CORTADO.";
                                                                oParteHistorial.GuardarNuevoDetalle(oParteHistorial);
                                                                cantidadHechos++;
                                                                //comenzarCarga();
                                                            }
                                                            else
                                                            {
                                                                string msjError = $"Error al intentar realizar el corte en el GIES";
                                                                GuardarErrorDeAplicacionExterna("CORTE", msjError, idCustomer, 0, idAccountAccess, idProductoAux);
                                                            }
                                                        }
                                                        else
                                                        {
                                                            string msjError = $"Error al intentar cortar el servicio (producto que se intento cortar [{idProductoAux}])";
                                                            GuardarErrorDeAplicacionExterna("CORTE", msjError, idCustomer, 0, idAccountAccess, idProductoAux);
                                                        }                                               
                                                    }
                                                }
                                                else
                                                {
                                                    string msjError = $"Account access del usuario externo no encontrada (Id_Usuario_Externo: {idCustomer})";
                                                    GuardarErrorDeAplicacionExterna("CORTE", msjError, idCustomer);

                                                    if (cantidadSeleccionados == 1)
                                                        MessageBox.Show(string.Format("Error al reconectar servicio en el ISP. No se encontraron datos de cuenta de acceso en ISP. ID CUSTOMER: {0}", idCustomer), "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                    cantidadErrores++;
                                                }

                                            }
                                            else
                                            {
                                                string msjError = $"Usuario (Id_Usuario: {this.idUsuario}) del gies no encontrado en aplicacion externa";
                                                GuardarErrorDeAplicacionExterna("CORTE", msjError);

                                                if (cantidadSeleccionados == 1)
                                                    MessageBox.Show("Error al reconectar servicio en el ISP. No se encontro ID CUSTOMER", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                cantidadErrores++;
                                            }
                                        }

                                    }
                                    catch (Exception ex)
                                    {
                                        cantidadErrores++;
                                        string msjError = $"Mensaje error: {ex.Message}, Tipo error: {ex.GetType().Name}, InnerException: {ex.InnerException?.Source}, {ex.InnerException?.Message}";
                                        GuardarErrorDeAplicacionExterna("CORTE", msjError);
                                    }

                                }
                            }
                        }
                        if(dtMultiplesCuentasAcceso.Rows.Count > 0)
                        {
                            frmPopUp popUp = new frmPopUp();
                            popUp.Formulario = new frmPartesConMultiplesCtasAcceso(dtMultiplesCuentasAcceso, "El corte de estos partes no se pudo realizar. Manualmente se deberan seleccionar por separado e indicar que producto se desea cortar");
                            popUp.Maximizar = false;
                            popUp.ShowDialog();
                        }

                        if (cantidadSeleccionados > 0 && cantidadErrores > 0)
                        {
                            MessageBox.Show(string.Format("Hubo {0} errores de {1} partes procesados", cantidadErrores, cantidadSeleccionados), "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            if (cantidadHechos > 0)
                            {
                                idOperacionSeleccionado = Convert.ToInt32(cboOperaciones.SelectedValue);
                                comenzarCarga();
                            }
                        }
                        if (cantidadHechos > 0)
                        {
                            idOperacionSeleccionado = Convert.ToInt32(cboOperaciones.SelectedValue);
                            comenzarCarga();
                        }
                    }
                }
                else if (idParteOperacion == (int)Partes.Partes_Operaciones.CAMBIO_TECNOLOGIA)
                {
                    frmVerISP frmEquipoConfiguracion = new frmVerISP();
                    frmEquipoConfiguracion.codUsuario = this.codUsuario;
                    frmEquipoConfiguracion.usuario = this.usuario;
                    frmEquipoConfiguracion.locacion = this.locacion;
                    frmEquipoConfiguracion.servicio = this.servicio;
                    frmEquipoConfiguracion.velocidad = this.velocidad;
                    frmEquipoConfiguracion.velocidad_tipo = this.velocidad_tipo;
                    frmEquipoConfiguracion.nombreOperacion = this.operacion;
                    frmEquipoConfiguracion.emailUsuario = this.correoUsuario;
                    frmEquipoConfiguracion.apellidoUsuario = this.apellidoUsuario;
                    frmEquipoConfiguracion.nombreUsuario = this.nombreUsuario;
                    frmEquipoConfiguracion.telefonoUsuario = this.telefonoUsuario;
                    frmEquipoConfiguracion.telefonoUsuario2 = this.tel2;
                    frmEquipoConfiguracion.codPostal = this.codPostal;
                    frmEquipoConfiguracion.direccion1 = this.usuarioCalle1;
                    frmEquipoConfiguracion.ciudadUsuario = this.ciudad;
                    frmEquipoConfiguracion.idServicio = this.idServicio;
                    frmEquipoConfiguracion.idUsuarioServicio = this.idUsuarioServicio;
                    frmEquipoConfiguracion.idUsuario = this.idUsuario;
                    frmEquipoConfiguracion.idLocacion = this.idLocacion;
                    frmEquipoConfiguracion.idParte = this.idParte;
                    frmEquipoConfiguracion.idParteUsuarioServicio = this.idParteUsuarioServicio;
                    frmEquipoConfiguracion.idOperacion = this.idParteOperacion;
                    frmEquipoConfiguracion.cambiarProdcuto = true;
                    if (frmEquipoConfiguracion.ShowDialog() == DialogResult.OK)
                        comenzarCarga();
                }
                else if (idParteOperacion == (int)Partes.Partes_Operaciones.ASIGNACION_DE_EQUIPO)
                {
                    fechaParte = Convert.ToDateTime(dgvPartes.SelectedRows[0].Cells["fecha_programado"].Value);
                    fechaParte = fechaParte.Date;
                    comparaFecha = fechaParte.CompareTo(DateTime.Now.Date);

                    if (comparaFecha <= 0)
                    {
                        frmVerISP frmEquipoConfiguracion = new frmVerISP();
                        frmEquipoConfiguracion.codUsuario = this.codUsuario;
                        frmEquipoConfiguracion.usuario = this.usuario;
                        frmEquipoConfiguracion.locacion = this.locacion;
                        frmEquipoConfiguracion.servicio = this.servicio;
                        frmEquipoConfiguracion.velocidad = this.velocidad;
                        frmEquipoConfiguracion.velocidad_tipo = this.velocidad_tipo;
                        frmEquipoConfiguracion.nombreOperacion = this.operacion;
                        frmEquipoConfiguracion.emailUsuario = this.correoUsuario;
                        frmEquipoConfiguracion.apellidoUsuario = this.apellidoUsuario;
                        frmEquipoConfiguracion.nombreUsuario = this.nombreUsuario;
                        frmEquipoConfiguracion.telefonoUsuario = this.telefonoUsuario;
                        frmEquipoConfiguracion.telefonoUsuario2 = this.tel2;
                        frmEquipoConfiguracion.codPostal = this.codPostal;
                        frmEquipoConfiguracion.direccion1 = this.usuarioCalle1;
                        frmEquipoConfiguracion.ciudadUsuario = this.ciudad;
                        frmEquipoConfiguracion.idServicio = this.idServicio;
                        frmEquipoConfiguracion.idUsuarioServicio = this.idUsuarioServicio;
                        frmEquipoConfiguracion.idUsuario = this.idUsuario;
                        frmEquipoConfiguracion.idLocacion = this.idLocacion;
                        frmEquipoConfiguracion.idParte = this.idParte;
                        frmEquipoConfiguracion.idParteUsuarioServicio = this.idParteUsuarioServicio;
                        frmEquipoConfiguracion.idOperacion = this.idParteOperacion;
                        frmEquipoConfiguracion.idAccion = (int)frmVerISP.acciones.ASIGNACION_EQUIPO;
                        if (frmEquipoConfiguracion.ShowDialog() == DialogResult.OK)
                            comenzarCarga();
                    }
                }
            }
        }

        private void GuardarErrorDeAplicacionExterna(string operacion, string mensajeError, int? idCustomer = 0, int? idLocation = 0, int? idAccountAccess = 0, int? idProducto = 0)
        {
            try
            {
                Aplicaciones_Externas_Excepciones oAppExtExcp = new Aplicaciones_Externas_Excepciones()
                {
                    Id_Aplicacion_Externa = Convert.ToInt32(Aplicaciones_Externas.Aplicacion_Externa.ISP),
                    Clase = "frmPartesServiciosConf",
                    Operacion = operacion,
                    Id_Personal = Personal.Id_Login,
                    Mensaje_Error = mensajeError,
                    Id_Usuario = this.idUsuario,
                    Id_Usuario_Locacion = this.idLocacion,
                    Id_Usuario_Servicio = this.idUsuarioServicio,
                    Id_Parte = this.idParte,
                    Id_Usuario_Externo = idCustomer.Value,
                    Id_Locacion_Externa = idLocation.Value,
                    Id_Cuenta_Externa = idAccountAccess.Value,
                    Id_Producto_Externo = idProducto.Value
                };
                oAppExtExcp.Guardar(oAppExtExcp);
            }
            catch {}
        }

        private void AgregarError(string tipo, string usuario, int idUsuarioServicio)
        {
            DataRow dataRow = dtErrores.NewRow();
            dataRow["Tipo_Error"] = tipo;
            dataRow["Usuario"] = usuario;
            dataRow["Id_Usuario_Servicio"] = idUsuarioServicio;
            dtErrores.Rows.Add(dataRow);
        }

        private void btnAsignarTecnico_Click(object sender, EventArgs e)
        {
            int IdTecnico = 0;
            int IdParte = Convert.ToInt32(dgvPartes.SelectedRows[0].Cells["id_parte"].Value);
            int IdPartesEstados = 0;
            frmBusquedaTecnicos frm1 = new frmBusquedaTecnicos();
            frmPopUp frmpopup = new frmPopUp();
            frmpopup.Maximizar = false;
            frmpopup.Formulario = frm1;
            this.idParteSeleccionado = Convert.ToInt32(dgvPartes.SelectedRows[0].Cells["id_parte"].Value);
            this.idOperacionSeleccionado = Convert.ToInt32(cboOperaciones.SelectedValue);
            if (frmpopup.ShowDialog() == DialogResult.OK)
            {
                IdTecnico = frm1.tecnicoSel;

                try
                {
                    oParteComun.AsignarTecnico(IdParte, IdTecnico, Convert.ToInt32(dgvPartes.SelectedRows[0].Cells["id_partes_estados"].Value));
                    IdPartesEstados = oParteComun.SetearEstadoParte(IdParte, 0, 0, DateTime.Now, 0, 0, "");
                    oParteHistorial.Id_Partes_Estados = IdPartesEstados;
                    oParteHistorial.Id_Parte = IdParte;
                    oParteHistorial.Id_Usuarios = Convert.ToInt32(dgvPartes.SelectedRows[0].Cells["id_usuarios"].Value);
                    oParteHistorial.Id_Personal = Personal.Id_Login;
                    oParteHistorial.Fecha_Movimiento = DateTime.Now;
                    oParteHistorial.Id_area = Personal.Id_Area;
                    oParteHistorial.Detalles = "TÉCNICO ASIGNADO.";
                    oParteHistorial.GuardarNuevoDetalle(oParteHistorial);
                }
                catch (Exception)
                {
                    MessageBox.Show("Error en la asignación de técnicos.");
                }
                comenzarCarga();
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            oImpresiones.ImprimirParte(Convert.ToInt32(dgvPartes.SelectedRows[0].Cells["id_parte"].Value));

        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {
            if (txtCodigo.Text.Length == 0)
            {
                txtCodigo.Text = "0";
                FiltrarUsuario();
            }
            else
                FiltrarUsuario();



        }
        private void btnAsignarEquipos_Click(object sender, EventArgs e)
        {
            int idParteEnviar = Convert.ToInt32(dgvPartes.SelectedRows[0].Cells["id_parte"].Value);
            List<int> listaTiposEquipos = new List<int>();
            DataTable dtPartesEquipos = new DataTable();
            int equiposDisponibles = 0;
            idOperacionSeleccionado = Convert.ToInt32(cboOperaciones.SelectedValue);
            idParteSeleccionado = Convert.ToInt32(dgvPartes.SelectedRows[0].Cells["id_parte"].Value);
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
                    idEquipoNuevo = frmAsignacion.idNuevo;
                    idEquipoViejo = frmAsignacion.idViejo;
                    if(frmAsignacion.asigno==true)
                    {
                        oParteComun.AsignarTecnico(idParte, 1, (int)Partes.Partes_Estados.ASIGNADO);
                        comenzarCarga();

                    }
                }
            }
        }
        private Boolean Desconectar(int idAccess)
        {
            string ipRedacctNuevo;
            Boolean escribioUsuario = false,escribioIp=false;

            ipRedacct = oISP.GetIpRedacct(idAccess);
            dtAccesAccounts = oISP.ListarDatosAccoun(idAccess);
            if (!string.IsNullOrEmpty(ipRedacct) || dtAccesAccounts.Rows.Count == 0)
            {
                userName = dtAccesAccounts.Rows[0]["username"].ToString();
                //EstablishSshConnection(ipRedacct, userName);
                //return true;
                escribioUsuario = oTools.EscribirTxt(@"c:\\GIES\\desconectar\\username.txt", 1, userName);
                if (escribioUsuario)
                {
                    escribioIp = oTools.EscribirTxt(@"c:\\GIES\\desconectar\\servidor.txt", 1, ipRedacct);
                    if (escribioIp)
                    {
                        //Thread.Sleep(300000);//a pedido de emanuel se hace 1 cada 5min

                        if (oTools.GetProcesoAbierto("cmd", "desconectar") == false)
                        {
                            oTools.EjecutarAplicacion(@"c:\\GIES\\desconectar\\aplicar.bat");
                            oTools.EjecutarAplicacion(@"c:\\GIES\\desconectar\\desconectar.bat");
                        }
                        else
                        {
                            oTools.EjecutarAplicacion(@"c:\\GIES\\desconectar\\aplicar.bat");

                            oTools.EjecutarAplicacion(@"c:\\GIES\\desconectar\\desconectar.bat");
                        }
                        ipRedacctNuevo = oISP.GetIpRedacct(idAccess);
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Hubo un error al intentar escribir el archivo 'servidor.txt' verifique que alguien mas no tengo el archivo abierto", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        escribioUsuario = oTools.EscribirTxt(@"c:\\GIES\\desconectar\\username.txt", 1, "");
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("Hubo un error al intentar escribir el archivo 'username.txt' verifique que alguien mas no tengo el archivo abierto", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            else
                return false;

        }
    }
}
