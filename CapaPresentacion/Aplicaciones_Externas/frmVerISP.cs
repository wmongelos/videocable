using CapaNegocios;
using System;
using System.Data;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace CapaPresentacion.Aplicaciones_Externas
{
    public partial class frmVerISP : Form
    {

        #region DECLARACIONES
        private Thread hilo;
        private delegate void myDel();

        private Partes_Usuarios_Servicios oPartesUsuariosServicios = new Partes_Usuarios_Servicios();
        private AplicacionesExternas oAppExterna = new AplicacionesExternas();
        private Servicios oServicios = new Servicios();
        private Usuarios_Servicios oUsuSer = new Usuarios_Servicios();
        private Isp oISP = new Isp();
        private Equipos oEquipos = new Equipos();

        private Int32 idCustomer, idLocation, idEquipment, idProduct, idAccesAccount;

        private DataTable dtEquipos = new DataTable();
        private DataTable dtEquipments = new DataTable();
        private DataTable dtProductos = new DataTable();
        private DataTable dtDatosServicio = new DataTable();
        private DataTable dtDatosUsuarioServicio = new DataTable();
        private DataTable dtAccountAccess = new DataTable();
        private DataTable dtDatosAppExterna = new DataTable();
        private DataTable dtDatosConexion = new DataTable();

        public bool seleccionarProducto = false;
        public bool cambioEquipo = false;
        public bool reconectar = false;
        public bool cortar = false;
        public bool seleccionarAccount = false;
        public bool ver = false;
        public bool cambiarProdcuto = false;
        public bool error = false;
        public bool noRealizarAccion = false;

        public Int32 idServicio;
        public Int32 idUsuario;
        public Int32 codUsuario;
        public Int32 idUsuarioServicio;
        public Int32 idOperacion;
        public Int32 idParteFalla;
        public Int32 idEquipo;
        public Int32 idLocacion;
        public Int32 idParte;
        public Int32 idParteUsuarioServicio;
        public Int32 idEquipoViejo, idEquipoNuevo;
        public Int32 idAccountSeleccionado;
        public Int32 idAccion = 0;
        //en caso que solo le abra el formlario solo para seleccionar un producto;
        public Int32 idProductoSeleccionado = 0;

        public string nombreUsuario;
        public string apellidoUsuario;
        public string emailUsuario;
        public string telefonoUsuario;
        public string telefonoUsuario2;
        public string ciudadUsuario;
        public string direccion1;
        public string codPostal;
        public string provinciaUsuario = "Buenos Airees";
        public string nombreOperacion;
        public string tipoEquipo;
        public string locacion;
        public string usuario;
        public string servicio;
        public string velocidad;
        public string velocidad_tipo;
        public string mac, serial, equipoUsuario, EquipoContasenia, equipoIp, equipoMarca, equipoModelo;

        private string accountMac, accountIp, accountUsuario, accountPass, accountNote;
        private Int32 idAplicacionExterna, cantEquiposGuardados = 0, idEquipmentSeleccionado;

        public enum acciones
        {
            CONEXION = 1,
            CAMBIO_EQUIPO = 2,
            CAMBIO_PRODUCTO = 3,
            ASIGNACION_EQUIPO = 4,
            SELECCIONAR_CUENTA = 5,
            VER = 6,
            SELECCIONAR_PRODUCTO = 7
        }
        #endregion


        #region METODOS

        private void comenzarCarga()
        {
            bloquearControles();
            dgvProductos.DataSource = null;
            hilo = new Thread(new ThreadStart(CargarDatos));
            hilo.IsBackground = true;
            hilo.Start();
        }

        private void CargarDatos()
        {

            try
            {
                dtDatosServicio = oServicios.BuscarDatosServicio(idServicio);
                if (dtDatosServicio.Rows.Count > 0)
                {
                    idAplicacionExterna = Convert.ToInt32(dtDatosServicio.Rows[0]["id_aplicaciones_externas"]);
                    if (idAplicacionExterna > 0)
                    {
                        dtDatosAppExterna = oAppExterna.Listar(idAplicacionExterna);
                        Isp.cadenaConexion = dtDatosAppExterna.Rows[0]["string_conexion"].ToString();

                        dtEquipos = oEquipos.BuscarEquipoPorUsuarioServicio(idUsuarioServicio);

                        idCustomer = oISP.VerificarExisteUsuario(codUsuario);
                        if (idCustomer > 0)
                            dtAccountAccess = oISP.ListarAccessAccount(idCustomer);
                        else
                        {
                            if (idOperacion != (int)Partes.Partes_Operaciones.CONEXION)
                            {
                                MessageBox.Show("No se escontro customer", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                if (ver == true)
                                {
                                    error = true;
                                }

                            }

                        }
                        dtProductos = oISP.ListarProductos(idAplicacionExterna);
                    }
                    else
                    {
                        MessageBox.Show("Este servicio no tiene una aplicacion asociada", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        this.DialogResult = DialogResult.Cancel;
                    }
                }
                else
                {
                    MessageBox.Show("Error al cargar Información del servicio", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.DialogResult = DialogResult.Cancel;
                }

                myDel MD = new myDel(AsignarDatos);
                this.Invoke(MD, new object[] { });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar Información" + ex.Message);
            }
        }

        private void FormatearGrillaAccount()
        {
            try
            {
                dgvAccounts.Columns["product_id"].Visible = false;
                dgvAccounts.Columns["customer_id"].Visible = false;
                dgvAccounts.Columns["account_id"].Visible = false;
                dgvAccounts.Columns["location_id"].Visible = false;
                dgvAccounts.Columns["ip"].Visible = false;
                dgvAccounts.Columns["notes"].Visible = false;
                dgvAccounts.Columns["password"].Visible = false;
                dgvAccounts.Columns["username"].Visible = false;

                dgvAccounts.Columns["name"].HeaderText = "Producto";
                dgvAccounts.Columns["name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                dgvAccounts.Columns["activo"].HeaderText = "ESTADO";
                dgvAccounts.Columns["enabled"].Visible = false;

            }
            catch
            {
            }
        }

        private void AsignarDatos()
        {

            DataView dv = dtProductos.DefaultView;
            try
            {
                int velocidadNumero = Convert.ToInt32(velocidad);
                int velocidadBytes = velocidadNumero * 1024;
            }
            catch {}

            dgvAccounts.DataSource = dtAccountAccess;
            FormatearGrillaAccount();
            dgvEquipos.DataSource = dtEquipos;
            if (dtEquipos.Rows.Count > 0)
                lblEquipos.Text = string.Format("Equipos asigandos al usuario (GIES)({0})", dtEquipos.Rows.Count);
            if (dtEquipments.Rows.Count > 0)
                lblEquiposISP.Text = string.Format("Equipos asigandos al usuario (ISP)({0})", dtEquipments.Rows.Count);
            int contador = 0;
            foreach (DataGridViewColumn columna in dgvEquipments.Columns)
            {
                if (columna.Name.Equals("desafectar"))
                    contador++;
            }
            if (dgvEquipos.Columns.Contains("asociar") == false)
            {
                DataGridViewLinkColumn oLinkAsociar = new DataGridViewLinkColumn();
                oLinkAsociar.LinkColor = Color.Red;
                oLinkAsociar.VisitedLinkColor = Color.Red;
                oLinkAsociar.Text = "Asociar";
                oLinkAsociar.Name = "asociar";
                oLinkAsociar.DataPropertyName = "asociar";
                oLinkAsociar.UseColumnTextForLinkValue = true;
                oLinkAsociar.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                oLinkAsociar.HeaderText = "";
                oLinkAsociar.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader;
                dgvEquipos.Columns.Add(oLinkAsociar);
            }
            if (dgvEquipments.Columns.Contains("editar") == false)
            {
                DataGridViewLinkColumn oLinkEditar = new DataGridViewLinkColumn();
                oLinkEditar.LinkColor = Color.Red;
                oLinkEditar.VisitedLinkColor = Color.Red;
                oLinkEditar.Text = "Editar";
                oLinkEditar.Name = "editar";
                oLinkEditar.DataPropertyName = "editar";
                oLinkEditar.UseColumnTextForLinkValue = true;
                oLinkEditar.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                oLinkEditar.HeaderText = "";
                oLinkEditar.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader;
                dgvEquipments.Columns.Add(oLinkEditar);
            }
            if (contador == 0)
            {
                DataGridViewLinkColumn oLinkQuitar = new DataGridViewLinkColumn();
                oLinkQuitar.LinkColor = Color.Red;
                oLinkQuitar.VisitedLinkColor = Color.Red;
                oLinkQuitar.Text = "Desafectar";
                oLinkQuitar.Name = "desafectar";
                oLinkQuitar.DataPropertyName = "desafectar";
                oLinkQuitar.UseColumnTextForLinkValue = true;
                oLinkQuitar.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                oLinkQuitar.HeaderText = "";
                oLinkQuitar.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader;
                dgvEquipments.Columns.Add(oLinkQuitar);
            }
            FormatearGrillaEquipos();
            pnlSeleccion.Visible = false;
            pnlInfo.Visible = true;
            dgvProductos.DataSource = dtProductos;
            AccountSeleccion();
            if (this.velocidad != "")
                lblServicioDato.Text = servicio + " " + velocidad + " " + velocidad_tipo;
            else
                lblServicioDato.Text = servicio;

            dgvEquipos.ReadOnly = false;

            lblOperacionDato.Text = this.nombreOperacion;
            lblServicioDato.Text = this.servicio + " " + velocidad + "mb" + velocidad_tipo;
            lblOperacionDato.Text = this.nombreOperacion;


            lblOperacion.Location = new Point(lblServicioDato.Location.X + lblServicioDato.Width + 10, lblOperacion.Location.Y);
            lblOperacionDato.Location = new Point(lblOperacion.Location.X + lblOperacion.Width + 10, lblOperacionDato.Location.Y);

            switch (idAccion)
            {
                case (int)acciones.CAMBIO_EQUIPO:
                    dgvProductos.Enabled = false;
                    spMain.Panel2Collapsed = true;
                    btnTerminar.Visible = true;
                    spMain.Panel2Collapsed = true;
                    break;
                case (int)acciones.VER:

                    spMain.Panel2Collapsed = true;
                    btnCambioProducto.Visible = false;
                    pnlConfirmar.Visible = false;
                    btnGuardar.Visible = false;
                    btnTerminar.Visible = false;
                    lblOperacion.Visible = false;
                    lblOperacionDato.Visible = false;
                    break;
                case (int)acciones.SELECCIONAR_CUENTA:

                    spMain.Panel2Collapsed = true;
                    spMain.Panel1Collapsed = false;
                    pnlEquiposGIES.Visible = false;
                    pnlEquiposISP.Visible = false;
                    lblTituloHeader.Text = "Seleccionar cuenta de acceso";
                    lblTituloHeader.AutoSize = true;
                    lblOperacionDato.Text = this.nombreOperacion;
                    lblServicioDato.Text = this.servicio + " " + velocidad + "mb" + velocidad_tipo;
                    lblOperacionDato.Text = this.nombreOperacion;
                    lblOperacion.Location = new Point(lblServicioDato.Location.X + lblServicioDato.Width + 10, lblOperacion.Location.Y);
                    lblOperacionDato.Location = new Point(lblOperacion.Location.X + lblOperacion.Width + 10, lblOperacionDato.Location.Y);
                    btnGuardar.Visible = false;
                    btnCambioProducto.Visible = false;
                    pnlConfirmar.Visible = false;
                    dgvAccounts.Columns["activo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dgvAccounts.Columns["name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                    dgvAccounts.Columns["name"].Width = 350;
                    this.Height = 450;
                    break;

                case (int)acciones.SELECCIONAR_PRODUCTO:
                    lblTituloHeader.Text = "Seleccionar producto";
                    spMain.Panel1Collapsed = true;
                    btnGuardar.Visible = false;
                    btnTerminar.Visible = false;
                    lblOperacion.Visible = false;
                    lblOperacionDato.Visible = false;
                    lblServicioDato1.Text = this.servicio;
                    pnlSeleccion.Visible = true;
                    pnlInfo.Visible = false;
                    spMain.Panel2Collapsed = false;
                    break;
                case (int)acciones.ASIGNACION_EQUIPO:
                    dgvProductos.Enabled = false;
                    spMain.Panel2Collapsed = true;
                    btnTerminar.Visible = true;
                    cambioEquipo = true;
                    break;
            }

            FormatearGrilla();
            desbloquearControles();
        }

        private void FormatearGrillaEquipos()
        {

            foreach (DataGridViewColumn item in dgvEquipos.Columns)
                item.Visible = false;

            dgvEquipos.Columns["marca"].Visible = true;
            dgvEquipos.Columns["marca"].HeaderText = "Marca";
            dgvEquipos.Columns["marca"].DisplayIndex = 0;

            dgvEquipos.Columns["serie"].Visible = true;
            dgvEquipos.Columns["serie"].HeaderText = "Serie";
            dgvEquipos.Columns["serie"].DisplayIndex = 1;

            dgvEquipos.Columns["mac"].Visible = true;
            dgvEquipos.Columns["mac"].HeaderText = "MAC";
            dgvEquipos.Columns["mac"].DisplayIndex = 2;

            dgvEquipos.Columns["modelo"].Visible = true;
            dgvEquipos.Columns["modelo"].HeaderText = "Modelo";
            dgvEquipos.Columns["modelo"].DisplayIndex = 3;

            dgvEquipos.Columns["Equipo_Usuario"].Visible = true;
            dgvEquipos.Columns["Equipo_Usuario"].HeaderText = "Usuario";
            dgvEquipos.Columns["Equipo_Usuario"].DisplayIndex = 4;
            dgvEquipos.Columns["Equipo_Usuario"].ReadOnly = false;

            dgvEquipos.Columns["Equipo_Clave"].Visible = true;
            dgvEquipos.Columns["Equipo_Clave"].HeaderText = "Clave";
            dgvEquipos.Columns["Equipo_Clave"].DisplayIndex = 5;
            dgvEquipos.Columns["Equipo_Clave"].ReadOnly = false;

            dgvEquipos.Columns["Equipo_IP"].Visible = true;
            dgvEquipos.Columns["Equipo_IP"].HeaderText = "IP";
            dgvEquipos.Columns["Equipo_IP"].DisplayIndex = 6;
            dgvEquipos.Columns["Equipo_IP"].ReadOnly = false;

            dgvEquipos.Columns["asociar"].Visible = true;



        }

        private void FormatearGrilla()
        {
            try
            {
                foreach (DataGridViewColumn item in dgvProductos.Columns)
                    item.Visible = false;

                dgvProductos.Columns["name"].Visible = true;
                dgvProductos.Columns["bandwidth"].Visible = true;
                dgvProductos.Columns["simmetry"].Visible = true;

            }
            catch { }

        }

        private void bloquearControles()
        {
            foreach (Control item in this.Controls)
                item.Enabled = false;
        }

        private void desbloquearControles()
        {
            foreach (Control item in this.Controls)
                item.Enabled = true;
        }

        private void AccountSeleccion()
        {

            if (dgvAccounts.Rows.Count > 0)
            {

                int idAccount = 0;
                int idProducto = 0;
                try
                {
                    if (dgvAccounts.Rows.Count > 0)
                    {
                        idAccountSeleccionado = Convert.ToInt32(dgvAccounts.SelectedRows[0].Cells["account_id"].Value);
                        idAccount = Convert.ToInt32(dgvAccounts.SelectedRows[0].Cells["account_id"].Value);
                        accountUsuario = dgvAccounts.SelectedRows[0].Cells["username"].Value.ToString();
                        accountIp = dgvAccounts.SelectedRows[0].Cells["ip"].Value.ToString();
                        accountPass = dgvAccounts.SelectedRows[0].Cells["password"].Value.ToString();
                        accountNote = dgvAccounts.SelectedRows[0].Cells["notes"].Value.ToString();

                        dtEquipments = oISP.ListarEquiposPorAccount(idAccount);
                        dgvEquipments.DataSource = dtEquipments;
                        dtDatosConexion = oISP.ListarDatosConexion(idAccount);
                        if (dtDatosConexion.Rows.Count > 0)
                        {
                            dgvDatosConexion.DataSource = dtDatosConexion;
                            foreach (DataGridViewColumn item in dgvDatosConexion.Columns)
                            {
                                item.Frozen = false;
                                item.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                            }
                        }
                        int contador = 0;
                        foreach (DataGridViewColumn item in dgvEquipments.Columns)
                        {
                            if (item.Name.Equals("desafectar"))
                                contador++;
                        }
                        if (contador == 0)
                        {
                            DataGridViewLinkColumn oLinkQuitar = new DataGridViewLinkColumn();
                            oLinkQuitar.LinkColor = Color.Red;
                            oLinkQuitar.VisitedLinkColor = Color.Red;
                            oLinkQuitar.Text = "Desafectar";
                            oLinkQuitar.Name = "desafectar";
                            oLinkQuitar.DataPropertyName = "desafectar";
                            oLinkQuitar.UseColumnTextForLinkValue = true;
                            oLinkQuitar.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            oLinkQuitar.HeaderText = "";
                            oLinkQuitar.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader;
                            dgvEquipments.Columns.Add(oLinkQuitar);
                        }
                        idProducto = Convert.ToInt32(dgvAccounts.SelectedRows[0].Cells["product_id"].Value);
                        foreach (DataGridViewRow item in dgvProductos.Rows)
                        {
                            if (Convert.ToInt32(item.Cells["product_id"].Value) == idProducto)
                            {
                                item.Selected = true;
                                dgvProductos.FirstDisplayedScrollingRowIndex = dgvProductos.SelectedRows[0].Index;
                            }

                        }
                        if (dgvEquipments.Rows.Count > 0)
                            dgvEquipments.Columns["equipment"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    }

                }
                catch
                {

                }
            }
        }

        #endregion

        public frmVerISP()
        {
            InitializeComponent();
        }

        private void frmEquiposConfiguracion_Load(object sender, EventArgs e)
        {
            comenzarCarga();
        }

        private void dgvAccounts_SelectionChanged(object sender, EventArgs e)
        {
            AccountSeleccion();
        }

        private void lblEquipos_Click(object sender, EventArgs e)
        {

        }

        private void dgvAccounts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            AccountSeleccion();

        }

        private void dgvEquipments_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int idEquipmentSeleccionado = 0;
                if (dgvEquipments.Columns[e.ColumnIndex].Name == "desafectar")
                {
                    idEquipmentSeleccionado = Convert.ToInt32(dgvEquipments.SelectedRows[0].Cells["equipment"].Value);
                    if (oISP.DesafectarEquipo(idAccountSeleccionado, idEquipmentSeleccionado) == 0)
                    {
                        MessageBox.Show("Equipo desafectado de ISP correctamente", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        comenzarCarga();
                    }
                    else
                    {
                        if (MessageBox.Show("Ocurrio un error al quere desafectar el equipoen ISP.", "Mensaje del Sistema", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning) == DialogResult.Retry)
                        {
                            if (oISP.DesafectarEquipo(idAccountSeleccionado, idEquipmentSeleccionado) == 0)
                            {
                                MessageBox.Show("Equipo desafectado de ISP correctamente", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                comenzarCarga();
                            }
                            else
                            {
                                MessageBox.Show("Ocurrió un error al querer desafectar el equip oen ISP.", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                comenzarCarga();
                            }
                        }
                    }
                }
                else if (dgvEquipments.Columns[e.ColumnIndex].Name == "editar")
                {
                    idEquipmentSeleccionado = Convert.ToInt32(dgvEquipments.SelectedRows[0].Cells["equipment"].Value);
                    Herramientas.frmIspEdicionEquipo oFrmEditarEquipos = new Herramientas.frmIspEdicionEquipo();
                    oFrmEditarEquipos.Mac = dgvEquipments.SelectedRows[0].Cells["mac"].Value.ToString();
                    oFrmEditarEquipos.Ip = dgvEquipments.SelectedRows[0].Cells["ip"].Value.ToString();
                    oFrmEditarEquipos.Serial = dgvEquipments.SelectedRows[0].Cells["serial"].Value.ToString();
                    oFrmEditarEquipos.idEquipment = idEquipmentSeleccionado;
                    oFrmEditarEquipos.marca = dgvEquipments.SelectedRows[0].Cells["brand"].Value.ToString();
                    oFrmEditarEquipos.modelo = dgvEquipments.SelectedRows[0].Cells["model"].Value.ToString();
                    oFrmEditarEquipos.oIsp = this.oISP;
                    if (oFrmEditarEquipos.ShowDialog() == DialogResult.OK)
                        comenzarCarga();
                }

            }
            catch (Exception c)
            {

                throw;
            }
        }

        private void btnTerminar_Click(object sender, EventArgs e)
        {
            if (cantEquiposGuardados > 0)
            {
                oPartesUsuariosServicios.PasarAConfigurado(idParteUsuarioServicio);
                this.DialogResult = DialogResult.OK;
            }
            else
            {

            }
        }

        private void pnlConfirmar_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnSeleccionar_Click_1(object sender, EventArgs e)
        {
            if (dgvProductos.SelectedRows.Count > 0)
            {
                idProductoSeleccionado = Convert.ToInt32(dgvProductos.SelectedRows[0].Cells["product_id"].Value);
                this.DialogResult = DialogResult.OK;
            }
        }

        private void dgvEquipos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int idEquipoSeleccionado = 0, idEquipment = 0;
                idAccountSeleccionado = Convert.ToInt32(dgvAccounts.SelectedRows[0].Cells["account_id"].Value);
                string mac = string.Empty, marca = string.Empty, modelo = string.Empty, serie = string.Empty, usuario = string.Empty, pass = string.Empty, ip = string.Empty;
                usuario = dgvEquipos.CurrentRow.Cells["equipo_usuario"].Value.ToString();
                pass = dgvEquipos.CurrentRow.Cells["equipo_clave"].Value.ToString();

                if (dgvEquipos.Columns[e.ColumnIndex].Name == "asociar")
                {
                    mac = dgvEquipos.CurrentRow.Cells["mac"].Value.ToString();
                    string macIsp = "";
                    int cant = 0;
                    foreach (DataRow item in dtEquipments.Rows)
                    {
                        macIsp = item["mac"].ToString();
                        if (mac.Equals(macIsp))
                            cant++;
                    }
                    if (cant == 0)
                    {
                        if (usuario == string.Empty || pass == string.Empty)
                        {
                            MessageBox.Show("Error al intentar guardar equipo en equipments isp, ingrese usuario y/o contraseña", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            dgvEquipos.CurrentRow.Cells["equipo_usuario"].Selected = true;
                        }
                        else
                        {
                            idEquipment = oISP.VerificarExisteEquipo(mac, "");
                            if (idEquipment == 0)
                            {
                                modelo = dgvEquipos.CurrentRow.Cells["modelo"].Value.ToString();
                                marca = dgvEquipos.CurrentRow.Cells["marca"].Value.ToString();
                                serie = dgvEquipos.CurrentRow.Cells["serie"].Value.ToString();
                                ip = dgvEquipos.CurrentRow.Cells["equipo_ip"].Value.ToString();
                                if (usuario == string.Empty || pass == string.Empty)
                                {
                                    MessageBox.Show("Error al intentar guardar equipo en equipments isp, ingrese usuario y/o contraseña", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    dgvEquipos.CurrentRow.Cells["equipo_usuario"].Selected = true;
                                }
                                else
                                {
                                    idEquipment = oISP.GuardarEquipo(mac, serie, usuario, pass, ip, marca, modelo);
                                    if (idEquipment != 0)
                                    {
                                        if (oISP.GuardarCustomerEquipment(idAccountSeleccionado, idEquipment) == 0)
                                        {
                                            MessageBox.Show("Equipo guardado correctamente isp", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            comenzarCarga();

                                        }
                                        else
                                            MessageBox.Show("Error al intentar guardar equipo en equipments isp", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                    else
                                        MessageBox.Show("Error al intentar guardar equipo en equipments isp", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);

                                }
                            }
                            else
                            {
                                MessageBox.Show("Equipo guardado correctamente isp", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                oISP.GuardarCustomerEquipment(idAccountSeleccionado, idEquipment);
                                comenzarCarga();

                            }

                        }
                    }
                    else
                    {
                        MessageBox.Show("El equipo ya esta asigado", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void boton1_Click(object sender, EventArgs e)
        {
            try
            {
                string ipPing = dgvDatosConexion.SelectedRows[0].Cells["ip_conexion"].Value.ToString();
                frmPing oFrmPing = new frmPing(ipPing);
                oFrmPing.ShowDialog();
            }
            catch (Exception c)
            {
                MessageBox.Show("Error: " + c.Message);
            }
        }
     
        private void dgvAccounts_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (seleccionarAccount == true)
            {
                idAccountSeleccionado = Convert.ToInt32(dgvAccounts.SelectedRows[0].Cells["account_id"].Value);
                this.DialogResult = DialogResult.OK;
            }
        }

        private void btnCambioProducto_Click(object sender, EventArgs e)
        {
            cambiarProdcuto = true;
            spMain.Panel2Collapsed = false;
            dtProductos = oISP.ListarProductos(idAplicacionExterna);
            dgvProductos.DataSource = dtProductos;
            FormatearGrilla();
            dgvProductos.Enabled = true;
            dgvProductos.ReadOnly = false;
            pnlConfirmar.Visible = true;
            btnGuardar.Visible = true;

        }

        private void pnlInfoCabecera_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dgvEquipments_SelectionChanged(object sender, EventArgs e)
        {
           
        }

        private void dgvAccounts_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
        }

        private void lblTituloHeader_Click(object sender, EventArgs e)
        {

        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pnlDatos_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (noRealizarAccion)
            {
                if (idAccountSeleccionado == 0)
                {
                    try
                    {
                        if (dgvAccounts.SelectedRows.Count > 0)
                            idAccountSeleccionado = Convert.ToInt32(dgvAccounts.SelectedRows[0].Cells["account_id"].Value);
                        else
                            idAccountSeleccionado = Convert.ToInt32(dgvAccounts.Rows[0].Cells["account_id"].Value);
                    }
                    catch { }
                }
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                switch (idAccion)
                {
                    case (int)acciones.CAMBIO_EQUIPO:
                        int equiposIguales = 0;
                        cantEquiposGuardados = 0;
                        foreach (DataRow item in dtEquipos.Rows)
                        {
                            equiposIguales = 0;
                            idEquipo = Convert.ToInt32(item["id"]);
                            mac = item["mac"].ToString();
                            serial = item["serie"].ToString();
                            equipoMarca = item["marca"].ToString();
                            equipoModelo = item["modelo"].ToString();
                            string macAux, serialAux;
                            foreach (DataRow item2 in dtEquipments.Rows)
                            {
                                macAux = item2["mac"].ToString();
                                serialAux = item2["serial"].ToString();
                                if (mac == macAux)
                                    equiposIguales++;
                            }
                            if (equiposIguales == 0)
                            {
                                EquipoContasenia = item["equipo_clave"].ToString();
                                equipoUsuario = item["equipo_usuario"].ToString();
                                equipoIp = item["equipo_ip"].ToString();
                                oEquipos.ActualizarDatosConfig(idEquipo, equipoUsuario, EquipoContasenia, equipoIp);
                                //verifico si existe el equipo si no existe lo guardo
                                idEquipment = oISP.VerificarExisteEquipo(mac, serial);
                                if (idEquipment == 0)
                                {
                                    idEquipment = oISP.GuardarEquipo(mac, serial, equipoUsuario, EquipoContasenia, equipoIp, equipoMarca, equipoModelo);
                                    if (idEquipment > 0)
                                        MessageBox.Show("Equipo guardado correctamente en ISP", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    else if (MessageBox.Show("Ocurrió un error al guardar equipo en ISP.", "Mensaje del Sistema", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error) == DialogResult.Retry)
                                    {
                                        idEquipment = oISP.GuardarEquipo(mac, serial, equipoUsuario, EquipoContasenia, equipoIp, equipoMarca, equipoModelo);
                                        if (idEquipment > 0)
                                            MessageBox.Show("Equipo guardado correctamente en ISP", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        else
                                        {
                                            string msjError = "Error al guardar el equipo en el ISP";
                                            GuardarErrorDeAplicacionExterna("CAMBIO_EQUIPO", msjError, idCustomer, idLocation, idAccesAccount, idProduct, mac, serial);
                                            MessageBox.Show("Ocurrió un error al guardar equipo en ISP.", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        }
                                    }
                                    else
                                    {
                                        string msjError = "Error al guardar el equipo en el ISP";
                                        GuardarErrorDeAplicacionExterna("CAMBIO_EQUIPO", msjError, idCustomer, idLocation, idAccesAccount, idProduct, mac, serial);
                                    }
                                }

                                if (idEquipment > 0)
                                {
                                    if (oISP.GuardarCustomerEquipment(idAccountSeleccionado, idEquipment) == 0)
                                    {
                                        cantEquiposGuardados++;
                                        MessageBox.Show("Equipo asignado correctamente en ISP", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        oEquipos.CambiarEstado(idEquipo, Convert.ToInt32(Equipos.Equipos_Estados.ASIGNADO_A_USUARIO));
                                        dtEquipments.Clear();
                                        dtEquipments = oISP.ListarEquiposPorAccount(idAccountSeleccionado);
                                        dgvEquipments.DataSource = dtEquipments;
                                        int contador = 0;
                                        foreach (DataGridViewColumn columna in dgvEquipments.Columns)
                                        {
                                            if (columna.Name.Equals("desafectar"))
                                                contador++;
                                        }
                                        if (contador == 0)
                                        {
                                            DataGridViewLinkColumn oLinkQuitar = new DataGridViewLinkColumn();
                                            oLinkQuitar.LinkColor = Color.Red;
                                            oLinkQuitar.VisitedLinkColor = Color.Red;
                                            oLinkQuitar.Text = "Desafectar";
                                            oLinkQuitar.Name = "desafectar";
                                            oLinkQuitar.DataPropertyName = "desafectar";
                                            oLinkQuitar.UseColumnTextForLinkValue = true;
                                            oLinkQuitar.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                            oLinkQuitar.HeaderText = "";
                                            oLinkQuitar.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader;
                                            dgvEquipments.Columns.Add(oLinkQuitar);
                                        }
                                    }
                                    else
                                    {
                                        string msjError = "Error al asignar el equipo al CUSTOMER en el ISP";
                                        GuardarErrorDeAplicacionExterna("CAMBIO_EQUIPO", msjError, idCustomer, idLocation, idAccesAccount, idProduct, mac, serial);
                                    }
                                }
                            }
                        }
                        break;

                }
                if (cambiarProdcuto == true)
                {
                    if (dtAccountAccess.Rows.Count > 0)
                    {
                        int idAccessAccount = Convert.ToInt32(dgvAccounts.SelectedRows[0].Cells["account_id"].Value);
                        int idProductoNuevo = Convert.ToInt32(dgvProductos.SelectedRows[0].Cells["product_id"].Value);

                        if (MessageBox.Show("Confima cambio de producto?", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            if (oISP.CambiarProducto(idAccessAccount, idProductoNuevo) == 0)
                            {
                                oAppExterna.CambiarProducto(idAccessAccount, idProductoNuevo, 0);
                                MessageBox.Show("Cambio de producto efectuado correctamente", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                spMain.Panel2Collapsed = true;
                            }
                            else
                            {
                                MessageBox.Show("Hubo un error al cambiar producto en ISP", "Mensaje del Sistema");
                                string msjError = "Error al cambiar el producto en el ISP";
                                GuardarErrorDeAplicacionExterna("CAMBIO_PRODUCTO", msjError, idCustomer, idLocation, idAccesAccount, idProductoNuevo);
                            }
                        }
                    }
                }
                else
                {
                    if (cambioEquipo == false && cortar == false && reconectar == false)
                    {
                        if (dgvProductos.SelectedRows.Count > 0)
                        {
                            idProduct = Convert.ToInt32(dgvProductos.SelectedRows[0].Cells["product_id"].Value);
                            //vefrifico si existe el abonado en la tabla customer del isp si no existe lo guardo y me retorna el id
                            idCustomer = oISP.VerificarExisteUsuario(codUsuario);
                            if (idCustomer == 0)
                                idCustomer = oISP.GuardarUsuario(codUsuario, nombreUsuario, apellidoUsuario, emailUsuario);

                            //verfifico si existe la locacion
                            idLocation = oISP.VerificarExisteLocacion(this.idLocacion);
                            if (idLocation == 0)
                                idLocation = oISP.GuardarLocacion(this.idLocacion, idCustomer, nombreUsuario, telefonoUsuario, telefonoUsuario2, direccion1, direccion1, direccion1, ciudadUsuario, provinciaUsuario, codPostal, emailUsuario);

                            //guardo el acces_Account
                            EquipoContasenia = dtEquipos.Rows[0]["equipo_clave"].ToString();
                            equipoUsuario = dtEquipos.Rows[0]["equipo_usuario"].ToString();
                            equipoIp = dtEquipos.Rows[0]["equipo_ip"].ToString();

                            idAccesAccount = oISP.GuardarAccesAccount(idCustomer, idProduct, idLocation, equipoUsuario, EquipoContasenia, equipoIp, "");
                            if (idAccesAccount > 0)
                            {
                                if (oAppExterna.GuardarUsuarioProducto(idUsuario, idLocacion, idProduct, idAccesAccount, idCustomer, idLocation, Personal.Id_Login) == 0)
                                {
                                    foreach (DataRow item in dtEquipos.Rows)
                                    {
                                        idEquipo = Convert.ToInt32(item["id"]);
                                        mac = item["mac"].ToString();
                                        serial = item["serie"].ToString();
                                        EquipoContasenia = item["equipo_clave"].ToString();
                                        equipoUsuario = item["equipo_usuario"].ToString();
                                        equipoIp = item["equipo_ip"].ToString();
                                        equipoMarca = item["marca"].ToString();
                                        equipoModelo = item["modelo"].ToString();
                                        oEquipos.ActualizarDatosConfig(idEquipo, equipoUsuario, EquipoContasenia, equipoIp);
                                        //verifico si existe el equipo si no existe lo guardo
                                        idEquipment = oISP.VerificarExisteEquipo(mac, serial);
                                        if (idEquipment == 0)
                                            idEquipment = oISP.GuardarEquipo(mac, serial, equipoUsuario, EquipoContasenia, equipoIp, equipoMarca, equipoModelo);
                                    }

                                    int cantidadEquipos = dtEquipos.Rows.Count;
                                    int contador = 0;//cuenta los equipos que se estan modificando

                                    foreach (DataRow item in dtEquipos.Rows)
                                    {
                                        idEquipo = Convert.ToInt32(item["id"]);
                                        mac = item["mac"].ToString();
                                        serial = item["serie"].ToString();
                                        EquipoContasenia = item["equipo_clave"].ToString();
                                        equipoUsuario = item["equipo_usuario"].ToString();
                                        equipoIp = item["equipo_ip"].ToString();
                                        equipoMarca = item["marca"].ToString();
                                        equipoModelo = item["modelo"].ToString();
                                        oEquipos.ActualizarDatosConfig(idEquipo, equipoUsuario, EquipoContasenia, equipoIp);
                                        //verifico si existe el equipo si no existe lo guardo
                                        idEquipment = oISP.VerificarExisteEquipo(mac, serial);
                                        if (idEquipment == 0)
                                            idEquipment = oISP.GuardarEquipo(mac, serial, equipoUsuario, EquipoContasenia, equipoIp, equipoMarca, equipoModelo);
                                        oISP.GuardarCustomerEquipment(idAccesAccount, idEquipment);

                                        //actualizo el campo configurado para que se pueda confirmar el parte
                                        if (oEquipos.PasarAConfigurado(this.idUsuarioServicio, this.idEquipo, idEquipment, idAccesAccount, idProduct) == 0)
                                            contador++;

                                    }
                                    if (contador == cantidadEquipos)
                                    {
                                        oPartesUsuariosServicios.PasarAConfigurado(idParteUsuarioServicio);
                                        MessageBox.Show("Datos guardados correctamente", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                    else
                                        MessageBox.Show("Hubo un error al ingresar los datos de un equipo al ISP. Consulte con el administrador ", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);


                                    this.DialogResult = DialogResult.OK;
                                }
                                else
                                    MessageBox.Show("Hubo un error al ingresar los datos del ISP al GIES", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            else
                                MessageBox.Show("Hubo un error al ingresar los datos al ISP", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        }

                    }
                    else
                    {
                        if (cortar == true)
                        {
                            if (dgvAccounts.SelectedRows.Count > 0)
                            {
                                idAccesAccount = Convert.ToInt32(dgvAccounts.SelectedRows[0].Cells["account_id"].Value);
                                idProduct = Convert.ToInt32(dgvAccounts.SelectedRows[0].Cells["product_id"].Value);
                                if (oISP.CortarServicio(idAccesAccount) == 0)
                                {
                                    MessageBox.Show("Servicio cortado en ISP correctamente", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    if (oAppExterna.CambiarProducto(idAccesAccount, 103, idProduct) == 0)
                                    {
                                        MessageBox.Show("Servicio cortado en GIES correctamente", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        oPartesUsuariosServicios.PasarAConfigurado(this.idParteUsuarioServicio);
                                        this.DialogResult = DialogResult.OK;
                                    }
                                    else
                                    {
                                        string msjError = "Error al cortar el producto en el GIES";
                                        GuardarErrorDeAplicacionExterna("CORTE", msjError, idCustomer, idLocation, idAccesAccount, idProduct);
                                        MessageBox.Show("Hubo un error al cortar el servicio en GIES", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        this.DialogResult = DialogResult.Cancel;
                                    }
                                }
                                else
                                {
                                    string msjError = "Error al cortar el producto en el ISP";
                                    GuardarErrorDeAplicacionExterna("CORTE", msjError, idCustomer, idLocation, idAccesAccount, idProduct);
                                    MessageBox.Show("Hubo un error al cortar el servicio en ISP", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    this.DialogResult = DialogResult.Cancel;
                                }
                            }
                        }
                    }
                }
            }    
        }

        private void GuardarErrorDeAplicacionExterna(string operacion, string mensajeError, int? idCustomer = 0, int? idLocation = 0, int? idAccountAccess = 0, int? idProducto = 0, string mac = "", string serie = "")
        {
            try
            {
                Aplicaciones_Externas_Excepciones oAppExtExcp = new Aplicaciones_Externas_Excepciones()
                {
                    Id_Aplicacion_Externa = Convert.ToInt32(AplicacionesExternas.Aplicacion_Externa.ISP),
                    Clase = "frmVerISP",
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
            catch { }
        }

        private void txtEquipoPass_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            if (dgvProductos.SelectedRows.Count > 0)
            {
                idProductoSeleccionado = Convert.ToInt32(dgvProductos.SelectedRows[0].Cells["product_id"].Value);
                this.DialogResult = DialogResult.OK;
            }

        }

        private void pnlInfo_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pnlSeleccion_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dgvEquipos_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            dtEquipos.AcceptChanges();
        }

        private void dgvEquipos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }










    }
}
