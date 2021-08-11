using CapaNegocios;
using System;
using System.Data;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace CapaPresentacion.Partes_Trabajo
{
    public partial class frmEquiposConfiguracion : Form
    {

        #region DECLARACIONES
        private Thread hilo;
        private delegate void myDel();

        private Partes_Usuarios_Servicios oPartesUsuariosServicios = new Partes_Usuarios_Servicios();
        private Aplicaciones_Externas oAppExterna = new Aplicaciones_Externas();
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

        public bool seleccionarProducto = false;
        public bool cambioEquipo = false;
        public bool reconectar = false;
        public bool cortar = false;
        public bool seleccionarAccount = false;
        public bool ver = false;
        public bool cambiarProdcuto = false;
        public bool error = false;

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


        private Int32 idAplicacionExterna, cantEquiposGuardados = 0;
        #endregion

        public frmEquiposConfiguracion()
        {
            InitializeComponent();
        }

        #region METODOS
        private void bloquearControles()
        {
            foreach (Control item in this.Controls)
                item.Enabled = false;
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

        private void desbloquearControles()
        {
            foreach (Control item in this.Controls)
                item.Enabled = true;
        }

        private void dgvEquipos_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            dtEquipos.AcceptChanges();
        }

        private void dgvEquipos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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
                        dtEquipments = oISP.ListarEquiposPorAccount(idAccount);
                        dgvEquipments.DataSource = dtEquipments;
                        if (dgvEquipments.Columns.Count == 3)
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
                            dgvEquipments.Columns["id"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    }

                }
                catch
                {

                }
            }
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
            }
            catch (Exception)
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

        private void dgvAccounts_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
        }

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
                        if (seleccionarProducto == false)
                        {
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
                dgvAccounts.Columns["name"].HeaderText = "Producto";
            }
            catch
            {
            }
        }

        private void AsignarDatos()
        {
            if (idAplicacionExterna == 0 || error == true)
                this.DialogResult = DialogResult.Abort;
            else
            {
                DataView dv = dtProductos.DefaultView;
                int velocidadNumero = Convert.ToInt32(velocidad);
                int velocidadBytes = velocidadNumero * 1024;


                if (seleccionarProducto == false)
                {

                    dgvAccounts.DataSource = dtAccountAccess;
                    FormatearGrillaAccount();
                    dgvEquipos.DataSource = dtEquipos;
                    lblEquipos.Text = string.Format("Equipos asigandos al usuario (GIES)({0})", dtEquipos.Rows.Count);
                    lblEquiposISP.Text = string.Format("Equipos asigandos al usuario (ISP)({0})", dtEquipments.Rows.Count);

                    if (dgvEquipments.Columns.Count == 3)
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
                    dv.RowFilter = string.Format("bandwidth={0}", velocidadBytes);

                    dgvProductos.DataSource = dv;
                    AccountSeleccion();
                    if (this.velocidad != "")
                        lblServicioDato.Text = servicio + " " + velocidad + " " + velocidad_tipo;
                    else
                        lblServicioDato.Text = servicio;


                    dgvEquipos.ReadOnly = false;


                    lblLocacionDato.Text = locacion;
                    lblLocacionDato.Text = this.locacion;
                    lblUsuarioDato.Text = this.usuario;
                    lblOperacionDato.Text = this.nombreOperacion;
                    lblServicioDato.Text = this.servicio + " " + velocidad + "mb" + velocidad_tipo;
                    lblOperacionDato.Text = this.nombreOperacion;


                    lblServicio.Location = new Point(lblUsuarioDato.Location.X + lblUsuarioDato.Width + 10, lblServicio.Location.Y);
                    lblServicioDato.Location = new Point(lblServicio.Location.X + lblServicio.Width + 10, lblServicioDato.Location.Y);
                    lblOperacion.Location = new Point(lblServicioDato.Location.X + lblServicioDato.Width + 10, lblOperacion.Location.Y);
                    lblOperacionDato.Location = new Point(lblOperacion.Location.X + lblOperacion.Width + 10, lblOperacionDato.Location.Y);
                    lblLocacion.Location = new Point(lblOperacionDato.Location.X + lblOperacionDato.Width + 10, lblLocacion.Location.Y);
                    lblLocacionDato.Location = new Point(lblLocacion.Location.X + lblLocacion.Width + 10, lblLocacionDato.Location.Y);

                    if (cortar == true)
                    {
                        dgvProductos.Enabled = false;
                        btnGuardar.Text = "Cortar servicio";
                        dgvEquipments.Enabled = false;
                    }
                    if (cambioEquipo == true)
                    {
                        dgvProductos.Enabled = false;
                        dgvAccounts.DataSource = dtAccountAccess;
                        btnTerminar.Visible = true;
                    }
                    if (ver == true)
                    {
                        spMain.Panel2Collapsed = true;
                        btnGuardar.Visible = false;
                        btnTerminar.Visible = false;
                        lblOperacion.Visible = false;
                        lblOperacionDato.Visible = false;
                    }
                }
                else
                {
                    if (seleccionarAccount == true)
                    {
                        spMain.Panel2Collapsed = true;
                        spMain.Panel1Collapsed = false;
                        pnlEquiposGIES.Visible = false;
                        pnlEquiposISP.Visible = false;
                        lblTituloHeader.Text = "Seleccionar cuenta de acceso";
                        lblLocacionDato.Text = locacion;
                        lblLocacionDato.Text = this.locacion;
                        lblUsuarioDato.Text = this.usuario;
                        lblOperacionDato.Text = this.nombreOperacion;
                        lblServicioDato.Text = this.servicio + " " + velocidad + "mb" + velocidad_tipo;
                        lblOperacionDato.Text = this.nombreOperacion;


                        lblServicio.Location = new Point(lblUsuarioDato.Location.X + lblUsuarioDato.Width + 10, lblServicio.Location.Y);
                        lblServicioDato.Location = new Point(lblServicio.Location.X + lblServicio.Width + 10, lblServicioDato.Location.Y);
                        lblOperacion.Location = new Point(lblServicioDato.Location.X + lblServicioDato.Width + 10, lblOperacion.Location.Y);
                        lblOperacionDato.Location = new Point(lblOperacion.Location.X + lblOperacion.Width + 10, lblOperacionDato.Location.Y);
                        lblLocacion.Location = new Point(lblOperacionDato.Location.X + lblOperacionDato.Width + 10, lblLocacion.Location.Y);
                        lblLocacionDato.Location = new Point(lblLocacion.Location.X + lblLocacion.Width + 10, lblLocacionDato.Location.Y);


                    }

                    if (cambioEquipo == true)
                    {
                        dgvProductos.Enabled = false;
                        dgvAccounts.DataSource = dtAccountAccess;

                    }
                    else
                    {
                        pnlAccount.Visible = false;
                        pnlEquiposISP.Visible = false;
                    }


                    lblServicioDato1.Text = this.servicio;
                    pnlSeleccion.Visible = true;
                    pnlInfo.Visible = false;
                    dv.RowFilter = string.Format("bandwidth={0}", velocidadBytes);
                    dgvProductos.DataSource = dv;
                }
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
        #endregion
        private void frmEquiposConfiguracion_Load(object sender, EventArgs e)
        {
            comenzarCarga();
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
            if (cambiarProdcuto == true)
            {
                int idAccessAccount = Convert.ToInt32(dgvAccounts.SelectedRows[0].Cells["account_id"].Value);
                int idProductoNuevo = Convert.ToInt32(dgvProductos.SelectedRows[0].Cells["product_id"].Value);

                if (MessageBox.Show("Confima cambio de producto?", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (oISP.CambiarProducto(idAccessAccount, idEquipoNuevo) == 0)
                        oAppExterna.CambiarProducto(idAccessAccount, idProductoNuevo, 0);
                    else
                        MessageBox.Show("Hubo un error al cambiar producto en ISP", "Mensaje del Sistema");
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

                        //guardo el acces_Account
                        idAccesAccount = oISP.GuardarAccesAccount(idCustomer, idProduct, idLocation, equipoUsuario, EquipoContasenia, equipoIp, "");

                        if (idAccesAccount > 0 && oAppExterna.GuardarUsuarioProducto(idUsuario, idLocacion, idProduct, idAccesAccount, idCustomer, idLocation, Personal.Id_Login) == 0)
                        {

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
                        }
                        else
                            MessageBox.Show("Hubo un error al ingresar los datos de un equipo al ISP. Consulte con el administrador ", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        this.DialogResult = DialogResult.OK;

                    }

                }
                else
                {
                    if (cortar == true)
                    {
                        if (dgvAccounts.SelectedRows.Count > 0 && dgvEquipos.Rows.Count > 0)
                        {
                            idAccesAccount = Convert.ToInt32(dgvAccounts.SelectedRows[0].Cells["account_id"].Value);
                            idEquipo = Convert.ToInt32(dgvEquipments.CurrentRow.Cells["equipment"].Value);
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
                                    MessageBox.Show("Hubo un error al cortar el servicio en GIES", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    this.DialogResult = DialogResult.Cancel;
                                }
                            }
                            else
                            {
                                MessageBox.Show("Hubo un error al cortar el servicio en ISP", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                this.DialogResult = DialogResult.Cancel;
                            }
                        }

                    }
                    else if (cambioEquipo == true)
                    {
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
                                            MessageBox.Show("Ocurrió un error al guardar equipo en ISP.", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }

                                if (idEquipment > 0)
                                {
                                    if (oISP.GuardarCustomerEquipment(idAccountSeleccionado, idEquipment) == 0)
                                    {
                                        cantEquiposGuardados++;
                                        string salida = "";

                                        MessageBox.Show("Equipo asignado correctamente en ISP", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        oEquipos.CambiarEstado(idEquipo, Convert.ToInt32(Equipos.Equipos_Estados.ASIGNADO_A_USUARIO),out salida);
                                        dtEquipments.Clear();
                                        dtEquipments = oISP.ListarEquiposPorAccount(idAccountSeleccionado);
                                        dgvEquipments.DataSource = dtEquipments;

                                        if (dgvEquipments.Columns.Count == 3)
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
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
