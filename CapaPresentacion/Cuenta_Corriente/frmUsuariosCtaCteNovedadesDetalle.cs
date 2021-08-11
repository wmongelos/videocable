using CapaNegocios;
using System;
using System.Data;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;


namespace CapaPresentacion.Cuenta_Corriente
{
    public partial class frmUsuariosCtaCteNovedadesDetalle : Form
    {

        private Thread hilo;
        private delegate void myDel();

        public Usuarios_Servicios_Novedades oNov = new Usuarios_Servicios_Novedades();

        private Usuarios oUsu = new Usuarios();
        private Configuracion oCongif = new Configuracion();
        private Usuarios_Locaciones oUsuLoc = new Usuarios_Locaciones();
        private Usuarios_Locaciones oLocacionElegida = new Usuarios_Locaciones();
        private Usuarios_Servicios oUsuserusu = new Usuarios_Servicios();
        private Servicios oSer = new Servicios();
        private Tipo_Facturacion oTipoFac = new Tipo_Facturacion();
        private Servicios_Categorias oServiciosCategorias = new Servicios_Categorias();
        private Zonas oZonas = new Zonas();
        private DataTable dtServicios = new DataTable();
        private DataTable dtServiciosSub = new DataTable();
        DataTable fechasFactura = new DataTable();

        private DataTable dtLocacionesCargadas = new DataTable();

        private frmPopUp oPop;
        private Busquedas.frmBusquedaUsuarios oBuscaLoc;

        private Int32 flag, idUsuario;
        private Boolean fechasCorrectas = true;
        private DateTime fechaFacturada;

        public frmUsuariosCtaCteNovedadesDetalle()
        {
            InitializeComponent();
        }

        public frmUsuariosCtaCteNovedadesDetalle(DataTable dtLoc)
        {
            InitializeComponent();
            this.dtLocacionesCargadas = dtLoc.Copy();
        }

        private void frmUsuariosCtaCteNovedadesDetalle_Load(object sender, EventArgs e)
        {
            ComenzarCarga();
        }

        private void ComenzarCarga()
        {
            pgCircular.Start();
            hilo = new Thread(new ThreadStart(CargarDatos));
            hilo.Start();
        }

        private void CargarDatos()
        {
            try
            {

                myDel MD = new myDel(AsignarDatos);
                this.Invoke(MD, new object[] { });

            }
            catch (Exception)
            {


            }
            pgCircular.Stop();
        }

        private void AsignarDatos()
        {
            fechasFactura.Columns.Add("fechaFactura", typeof(DateTime));
            fechasFactura.Columns.Add("servicio", typeof(string));
            idUsuario = Usuarios.CurrentUsuario.Id;
            cboDirigido.DisplayMember = "Text";
            cboDirigido.ValueMember = "Value";
            var items = new[] {
                new { Text = "USUARIO", Value = "1" },
                new { Text = "OPERADOR", Value = "2" },
            };
            cboDirigido.DataSource = items;
            if (oNov.Id == 0)
            {
                DataRow draux = dtLocacionesCargadas.NewRow();
                draux["Id"] = 0;
                draux["Locacion"] = "GENERAL";
                dtLocacionesCargadas.Rows.Add(draux);
                cboLocacion.DisplayMember = "Locacion";
                cboLocacion.ValueMember = "Id";
                cboLocacion.DataSource = dtLocacionesCargadas;

                //dtServicios.Columns.Add("Id_servicios",typeof(Int32));
                //dtServicios.Columns.Add("Nombre", typeof(String));
                //dtServicios.Columns.Add("Id_Usuarios_Servicios",typeof(Int32));
                dtServiciosSub.Columns.Add("Id_tipo", typeof(Int32));
                dtServiciosSub.Columns.Add("Nombre", typeof(String));
                dtServiciosSub.Columns.Add("tipo", typeof(String));
                dtServiciosSub.Columns.Add("Id_Usuarios_Servicios_sub", typeof(Int32));
                dtServiciosSub.Columns.Add("Porcentaje", typeof(Decimal));
                dtServiciosSub.Columns.Add("Importe", typeof(Decimal));
                dtServiciosSub.Columns.Add("Selecciona", typeof(Boolean));

                //CargaServicios();

                dgvServicios.DataSource = dtServicios;
                GrillaServicios();
                try { dgvServicios.Focus(); }
                catch { }

                pnlServicios.Enabled = true;
            }
            else
            {
                pnlServicios.Enabled = false;
                pnlDescuentos.Enabled = true;
                dtpDesde.Value = oNov.Fecha_Desde;
                dtpHasta.Value = oNov.Fecha_Hasta;
                if (oNov.Finaliza == 1)
                    chkFinaliza.Checked = true;
                else
                    chkFinaliza.Checked = false;

                cboDirigido.SelectedValue = oNov.Imprimir.ToString();
                txtDetalle.Text = oNov.Detalle;

                txtDtoPor.Text = oNov.Porcentaje.ToString();
                txtDtoPes.Text = oNov.Monto.ToString();
            }
            lblUsuario.Text = String.Format("[{0}] - {1}, {2}", Usuarios.CurrentUsuario.Codigo, Usuarios.CurrentUsuario.Apellido, Usuarios.CurrentUsuario.Nombre);
            DataTable dtUsuarios = new DataTable();
            dtUsuarios.Columns.Add("id", typeof(Int32));
            dtUsuarios.Columns.Add("nombre", typeof(String));

            if (Usuarios.CurrentUsuario.Id != 0)
            {
                string nombreCompletoUsuario = Usuarios.CurrentUsuario.Apellido + ", " + Usuarios.CurrentUsuario.Nombre;
                dtUsuarios.Rows.Add(Usuarios.CurrentUsuario.Id, nombreCompletoUsuario);
                //      dtUsuarios.Rows.Add(0, "TODOS LOS USUARIOS");
                cboTipoFacturacion.Visible = false;
                lblLocacion.Text = "Locacion";
            }
            else
                btnAplicar.Enabled = false; //dtUsuarios.Rows.Add(0, "TODOS LOS USUARIOS");

            cboUsuarios.DataSource = dtUsuarios;
            cboUsuarios.DisplayMember = "nombre";
            cboUsuarios.ValueMember = "id";
            try
            {
                if (Convert.ToInt32(cboUsuarios.SelectedValue) == 0)
                {
                    DataTable dtZonasCategorias = new DataTable();
                    cboLocacion.Visible = false;
                    cboTipoFacturacion.Location = cboLocacion.Location;
                    cboTipoFacturacion.Visible = true;
                    cboTipoFacturacion.Enabled = true;
                    int tipoFacturacion = oCongif.GetValor_N("Id_Tipo_Facturacion");
                    if (tipoFacturacion == Convert.ToInt32(Tipo_Facturacion.Id_Tipo_Facturacion.POR_ZONAS))
                    {
                        lblLocacion.Text = "Zona";
                        dtZonasCategorias = oZonas.Listar();
                    }
                    else
                    {
                        lblLocacion.Text = "Categoria";
                        dtZonasCategorias = oServiciosCategorias.Listar();
                    }
                    cboTipoFacturacion.Location = new Point(lblLocacion.Location.X + lblLocacion.Width, cboUsuarios.Location.Y);
                    cboTipoFacturacion.DataSource = dtZonasCategorias;
                    cboTipoFacturacion.DisplayMember = "Nombre";
                    cboTipoFacturacion.ValueMember = "Id";
                }

                CargaSubservicios();

            }
            catch (Exception)
            {

            }
        }

        private void CargaServicios()
        {
            DataTable dtHab = new DataTable();
            DataTable dtAct = new DataTable();
            dtHab = oTipoFac.GetServiciosPorTipo(1);
            dtAct = oUsuserusu.ListarServicios(Usuarios.CurrentUsuario.Id, Usuarios.CurrentUsuario.Id_Usuarios_Locacion);

            foreach (DataRow dr in dtAct.Rows) /// activos del usuario
            {
                dtServicios.Rows.Add(Convert.ToInt32(dr["id_servicios"].ToString()), dr["servicio"].ToString(), Convert.ToInt32(dr["id"].ToString()));
            }

            foreach (DataRow dr in dtHab.Rows) /// Habilitados
            {
                string busca_tipo = " Id_servicios = " + dr["id_servicios"].ToString();
                DataRow[] foundRows_tipo;
                foundRows_tipo = dtServicios.Select(busca_tipo, "");

                if (foundRows_tipo.Length == 0)
                    dtServicios.Rows.Add(Convert.ToInt32(dr["id_servicios"].ToString()), dr["servicios"].ToString(), 0);
            }

        }

        private void dgvServicios_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                pnlDescuentos.Visible = true;
                int idServicio = Convert.ToInt32(dgvServicios.SelectedRows[0].Cells["id_servicios"].Value);
                if (idServicio != 0)
                {
                    CargaSubservicios();
                }
                else
                {

                    dgvSubservicios.DataSource = null;

                }
            }
            catch
            {
            }
        }

        private void CargaSubservicios()
        {
            DataTable dtActs = new DataTable();
            DataTable dtHabs = new DataTable();
            try
            {
                if (Convert.ToInt32(dgvServicios.SelectedRows[0].Cells["Id_servicios"].Value) > 0)
                {
                    if (Convert.ToInt32(cboUsuarios.SelectedValue) != 0)
                        dtActs = oUsuserusu.ListarServiciosSub(Convert.ToInt32(dgvServicios.SelectedRows[0].Cells["id_usuario_servicio"].Value.ToString()));
                    dtHabs = oTipoFac.GetServiciosSu(Convert.ToInt32(dgvServicios.SelectedRows[0].Cells["id_servicios"].Value.ToString()));
                }
            }
            catch
            {
                throw;
            }

            if (Convert.ToInt32(cboUsuarios.SelectedValue) != 0)
            {
                dtServiciosSub.Clear();
                DataView dvSubTipoS = dtActs.DefaultView;
                dvSubTipoS.RowFilter = "id_servicios_sub_tipos=1";
                dtActs = dvSubTipoS.ToTable();
            }

            DataView dvSubTipoS2 = dtHabs.DefaultView;
            dvSubTipoS2.RowFilter = "idtipodesub=1";

            dtHabs = dvSubTipoS2.ToTable();
            foreach (DataRow dr in dtActs.Rows) /// activos del usuario
            {
                dtServiciosSub.Rows.Add(Convert.ToInt32(dr["id_servicios_sub"].ToString()), dr["descripcion"].ToString(), "S", Convert.ToInt32(dr["id"].ToString()), 0, 0, false);
            }

            foreach (DataRow dr in dtHabs.Rows) /// Habilitados
            {
                string busca_tipo = " Id_tipo = " + dr["id_servicios_sub"].ToString();
                DataRow[] foundRows_tipo;
                foundRows_tipo = dtServiciosSub.Select(busca_tipo, "");

                if (foundRows_tipo.Length == 0)
                    dtServiciosSub.Rows.Add(Convert.ToInt32(dr["id_servicios_sub"].ToString()), dr["servicios_sub"].ToString(), "S", 0, 0, 0, false);
            }

            dgvSubservicios.DataSource = dtServiciosSub;
            GrillaSubservicios();
        }

        private void GrillaServicios()
        {
            try
            {

                Int32 Cancol = dgvServicios.ColumnCount;
                for (int i = 0; i < Cancol; i++)
                    dgvServicios.Columns[i].Visible = false;


                dgvServicios.Columns["servicio"].Visible = true;
                dgvServicios.Columns["servicio"].ReadOnly = true;

                GrillaServiciosColor();
            }
            catch (Exception)
            {

            }

        }

        private void GrillaSubservicios()
        {
            dgvSubservicios.ReadOnly = false;
            dgvServicios.Enabled = true;
            Int32 Cancol = dgvSubservicios.ColumnCount;


            for (int i = 0; i < Cancol; i++)
                dgvSubservicios.Columns[i].Visible = false;


            dgvSubservicios.Columns["nombre"].Visible = true;
            dgvSubservicios.Columns["nombre"].ReadOnly = true;

            dgvSubservicios.Columns["Importe"].ReadOnly = false;
            dgvSubservicios.Columns["Importe"].HeaderText = " Dto $";
            dgvSubservicios.Columns["Importe"].Visible = false;
            dgvSubservicios.Columns["importe"].DefaultCellStyle.Format = "n2";
            dgvSubservicios.Columns["Importe"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvSubservicios.Columns["porcentaje"].ReadOnly = false;
            dgvSubservicios.Columns["porcentaje"].HeaderText = " Dto %";
            dgvSubservicios.Columns["porcentaje"].Visible = false;
            dgvSubservicios.Columns["porcentaje"].DefaultCellStyle.Format = "n2";
            dgvSubservicios.Columns["porcentaje"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvSubservicios.Columns["selecciona"].ReadOnly = false;
            dgvSubservicios.Columns["selecciona"].HeaderText = " ";

            GrillaSubServiciosColor();
        }

        private void GrillaSubServiciosColor()
        {
            foreach (DataGridViewRow dr in dgvSubservicios.Rows)
            {
                if (Convert.ToInt32(dr.Cells["Id_Usuarios_Servicios_sub"].Value.ToString()) == 0)
                    dr.Visible = false;
            }
        }

        private void GrillaServiciosColor()
        {
            foreach (DataGridViewRow dr in dgvServicios.Rows)
            {
                if (Convert.ToInt32(dr.Cells["Id_Usuarios_Servicios"].Value.ToString()) > 0)
                    dr.DefaultCellStyle.ForeColor = Color.Green;
            }
        }

        private void btnCancela_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void btnAplicar_Click(object sender, EventArgs e)
        {
            try
            {
                Double d = Convert.ToDouble(txtDtoPes.Text);
            }
            catch
            {
                MessageBox.Show("Es necesario un valor numerico", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtDtoPes.Focus();
                return;
            }

            if (String.IsNullOrEmpty(txtDetalle.Text.Trim()))
            {
                MessageBox.Show("Es necesario agregar un detalle a la novedad", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }


            GuardarNovedades();
        }

        private void GuardarNovedades()
        {
            DataTable aux = dgvSubservicios.DataSource as DataTable;
            fechasFactura.Clear();
            if (chkFinaliza.Checked)
                oNov.Finaliza = 1;
            else
                oNov.Finaliza = 0;
            try
            {
                if (Convert.ToInt32(cboUsuarios.SelectedValue) == 0)
                {
                    oNov.Id_Usuarios = Convert.ToInt32(cboUsuarios.SelectedValue);
                    oNov.Id_Usuarios_Locaciones = 0;
                    oNov.Id_Servicios = Convert.ToInt32(dgvServicios.SelectedRows[0].Cells["id_servicios"].Value);

                    if (dgvServicios.SelectedRows.Count > 0)
                    {
                        if (Convert.ToInt32(cboUsuarios.SelectedValue) == 0)
                        {
                            oNov.Id_Servicios_Sub = Convert.ToInt32(dgvSubservicios.SelectedRows[0].Cells["Id_tipo"].Value);
                            oNov.Id_Usuarios_Servicios_Sub = 0;
                        }
                        else
                        {
                            oNov.Id_Servicios_Sub = 0;
                            oNov.Id_Usuarios_Servicios_Sub = Convert.ToInt32(dgvSubservicios.SelectedRows[0].Cells["Id_Usuarios_Servicios_sub"].Value);
                        }
                    }
                    else
                    {
                        oNov.Id_Servicios_Sub = 0;
                        oNov.Id_Usuarios_Servicios_Sub = 0;

                    }

                    oNov.Id_Servicios_velocidades = 0;
                    oNov.Id_Servicios_velocidades_tip = 0;
                    oNov.Fecha_Desde = dtpDesde.Value.Date;
                    oNov.Fecha_Hasta = dtpHasta.Value.Date;
                    oNov.Porcentaje = Convert.ToDecimal(txtDtoPor.Text);
                    oNov.Monto = Convert.ToDecimal(txtDtoPes.Text);
                    oNov.Imprimir = Convert.ToInt32(cboDirigido.SelectedValue);
                    oNov.Tipo = "S";
                    oNov.Detalle = txtDetalle.Text;
                    oNov.Id_Usuarios_Servicios = 0;
                    oNov.Id_Origen = Convert.ToInt32(Usuarios_Servicios_Novedades.Origen.OPERADOR);

                    oNov.id_tipo_facturacion = Convert.ToInt32(cboTipoFacturacion.SelectedValue);

                    if ((Convert.ToDecimal(txtDtoPor.Text) == 0) && (Convert.ToDecimal(txtDtoPes.Text) == 0) && (oNov.Id == 0))
                    {
                        MessageBox.Show("Ingrese un valor de descuento/aumento", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtDtoPor.Focus();
                    }
                    else
                    {
                        oNov.Guardar(oNov);
                        MessageBox.Show("Novedad guardada correctamente", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;

                    }
                }
                else
                {
                    int idLocacion = Convert.ToInt32(cboLocacion.SelectedValue);
                    if (idLocacion == 0)
                    {
                        //comprobar que esa locacion no tenga un servicio ya facturado

                        DataTable dtServiciosDeLocacion = new DataTable();
                        DataTable dtLocacionesUsuarios = new DataTable();
                        dtLocacionesUsuarios = oUsuLoc.ListarLocacionesServicio(Convert.ToInt32(cboUsuarios.SelectedValue));
                        if (dtLocacionesUsuarios.Rows.Count > 0)
                        {
                            foreach (DataRow item in dtLocacionesUsuarios.Rows)
                            {
                                int idLoc = Convert.ToInt32(item["id"]);
                                dtServiciosDeLocacion = oUsuserusu.ListarServicios(Convert.ToInt32(cboUsuarios.SelectedValue), idLoc);
                                if (dtServiciosDeLocacion.Rows.Count > 0)
                                {
                                    foreach (DataRow item2 in dtServiciosDeLocacion.Rows)
                                    {
                                        fechasFactura.Rows.Add(Convert.ToDateTime(item2["fecha_factura"]), item2["Servicio"].ToString());
                                    }
                                }

                            }
                        }
                        if (fechasFactura.Rows.Count > 0)
                        {
                            foreach (DataRow item in fechasFactura.Rows)
                            {
                                DateTime fecha;
                                fecha = Convert.ToDateTime(item["fechaFactura"]);
                                if (oNov.Id == 0)
                                {
                                    if (Convert.ToDateTime(dtpDesde.Value) < fecha)
                                    {
                                        fechasCorrectas = false;
                                        fechaFacturada = fecha;
                                    }
                                    else
                                    {
                                        fechasCorrectas = true;
                                    }
                                }
                                else
                                {
                                    fechasCorrectas = true;
                                }
                            }

                        }
                        if (fechasCorrectas == false)
                        {
                            MessageBox.Show("La fecha 'desde' no es valida ya que hay servicios que para esa fecha ya han sido facturados,eliga una fecha posterior a " + fechaFacturada.ToShortDateString(), "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            fechasFactura.Clear();
                            dtpDesde.Focus();
                        }
                        else
                        {

                            oNov.Id_Usuarios = Convert.ToInt32(cboUsuarios.SelectedValue);
                            oNov.Id_Usuarios_Locaciones = 0;
                            oNov.Id_Servicios = 0;
                            oNov.Id_Servicios_Sub = 0;
                            oNov.Id_Servicios_velocidades = 0;
                            oNov.Id_Servicios_velocidades_tip = 0;
                            oNov.Fecha_Desde = dtpDesde.Value.Date;
                            oNov.Fecha_Hasta = dtpHasta.Value.Date;
                            oNov.Porcentaje = Convert.ToDecimal(txtDtoPor.Text);
                            oNov.Monto = Convert.ToDecimal(txtDtoPes.Text);
                            oNov.Imprimir = Convert.ToInt32(cboDirigido.SelectedValue);
                            oNov.Tipo = "S";
                            oNov.Detalle = txtDetalle.Text;
                            oNov.Id_Usuarios_Servicios = 0;
                            oNov.Id_Usuarios_Servicios_Sub = 0;
                            oNov.id_tipo_facturacion = 0;
                            oNov.Id_Origen = Convert.ToInt32(Usuarios_Servicios_Novedades.Origen.OPERADOR);

                            if ((Convert.ToDecimal(txtDtoPor.Text) == 0) && (Convert.ToDecimal(txtDtoPes.Text) == 0) && (oNov.Id == 0))
                            {
                                MessageBox.Show("Ingrese un valor de descuento/aumento", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                txtDtoPor.Focus();
                            }
                            else
                            {
                                oNov.Guardar(oNov);
                                MessageBox.Show("Novedad guardada correctamente", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.DialogResult = DialogResult.OK;

                            }
                        }
                    }
                    else
                    {
                        int idServicio = Convert.ToInt32(dgvServicios.SelectedRows[0].Cells["id_servicios"].Value);
                        int idUsuServicio = Convert.ToInt32(dgvServicios.SelectedRows[0].Cells["id_usuario_servicio"].Value);
                        if (idServicio != 0)
                        {
                            //compruebo que ya no este facturado ese servicio seleccionado a la fecha desde selecccionada

                            DataTable dtDatosUsuSer = oUsuserusu.Traer_datos_usuarios_servicios(idUsuServicio);
                            fechasCorrectas = true;
                            if (dtDatosUsuSer.Rows.Count > 0)
                                fechasFactura.Rows.Add(Convert.ToDateTime(dtDatosUsuSer.Rows[0]["fecha_factura"]), "");

                            if (fechasFactura.Rows.Count > 0)
                            {
                                foreach (DataRow item in fechasFactura.Rows)
                                {
                                    DateTime fecha;
                                    fecha = Convert.ToDateTime(item["fechaFactura"]);
                                    if (Convert.ToDateTime(dtpDesde.Value.Date) < fecha.Date)
                                    {
                                        fechasCorrectas = false;
                                        fechaFacturada = fecha;
                                    }
                                }

                            }
                            if (fechasCorrectas == false)
                            {
                                MessageBox.Show("La fecha 'desde' no es valida ya que hay servicios que para esa fecha ya han sido facturados,eliga una fecha posterior a " + fechaFacturada.ToShortDateString(), "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                dtpDesde.Focus();
                            }
                            else
                            {

                                if (Convert.ToDecimal(txtDtoPor.Text) != 0 || Convert.ToDecimal(txtDtoPes.Text) != 0)
                                {
                                    oNov.Id = 0;
                                    oNov.Id_Usuarios = Usuarios.CurrentUsuario.Id;
                                    oNov.Id_Usuarios_Locaciones = Convert.ToInt32(cboLocacion.SelectedValue);
                                    oNov.Id_Servicios = Convert.ToInt32(dgvServicios.SelectedRows[0].Cells["id_servicios"].Value.ToString());
                                    oNov.Id_Servicios_Sub = Convert.ToInt32(dgvSubservicios.SelectedRows[0].Cells["id_tipo"].Value.ToString());
                                    oNov.Id_Servicios_velocidades = 0;
                                    oNov.Id_Servicios_velocidades_tip = 0;
                                    oNov.Fecha_Desde = dtpDesde.Value.Date;
                                    oNov.Fecha_Hasta = dtpHasta.Value.Date;
                                    oNov.Porcentaje = Convert.ToDecimal(txtDtoPor.Text);
                                    oNov.Monto = Convert.ToDecimal(txtDtoPes.Text);
                                    oNov.Tipo = "S";
                                    oNov.Imprimir = Convert.ToInt32(cboDirigido.SelectedValue);
                                    oNov.Detalle = txtDetalle.Text;
                                    oNov.Id_Usuarios_Servicios = Convert.ToInt32(dgvServicios.SelectedRows[0].Cells["id_usuario_servicio"].Value.ToString());
                                    oNov.Id_Usuarios_Servicios_Sub = Convert.ToInt32(dgvSubservicios.SelectedRows[0].Cells["id_usuarios_servicios_sub"].Value.ToString());
                                    oNov.Guardar(oNov);
                                    oNov.id_tipo_facturacion = 0;
                                    MessageBox.Show("Novedad guardada correctamente", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    this.DialogResult = DialogResult.OK;
                                }
                            }
                        }
                        else
                        {
                            //al elegir una locacion pero no un servicio especifico debo controlar que ningun servicio tenga fecha factura anterior a la fecha desde seleccionada
                            foreach (DataGridViewRow item in dgvServicios.Rows)
                            {
                                int id = Convert.ToInt32(item.Cells["id"].Value);
                                if (id != 0)
                                {
                                    DateTime fechaFac = Convert.ToDateTime(item.Cells["fecha_factura"].Value);
                                    if (dtpDesde.Value < fechaFac)
                                    {
                                        fechaFacturada = fechaFac;
                                        fechasCorrectas = false;
                                    }
                                }
                            }
                            if (fechasCorrectas == false)
                            {
                                MessageBox.Show("La fecha 'desde' no es valida ya que hay servicios que para esa fecha ya han sido facturados,eliga una fecha posterior a " + fechaFacturada.ToShortDateString(), "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                dtpDesde.Focus();
                            }
                            else
                            {

                                if ((Convert.ToDecimal(txtDtoPor.Text) == 0) && (Convert.ToDecimal(txtDtoPes.Text) == 0) && (oNov.Id == 0))
                                {
                                    MessageBox.Show("Ingrese un valor de descuento/aumento", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    txtDtoPor.Focus();
                                }
                                else
                                {
                                    oNov.Id = 0;
                                    oNov.Id_Usuarios = Usuarios.CurrentUsuario.Id;
                                    oNov.Id_Usuarios_Locaciones = Convert.ToInt32(cboLocacion.SelectedValue);
                                    oNov.Id_Servicios = Convert.ToInt32(dgvServicios.SelectedRows[0].Cells["id_servicios"].Value.ToString());
                                    oNov.Id_Servicios_Sub = 0;
                                    oNov.Id_Servicios_velocidades = 0;
                                    oNov.Id_Servicios_velocidades_tip = 0;
                                    oNov.Fecha_Desde = dtpDesde.Value.Date;
                                    oNov.Fecha_Hasta = dtpHasta.Value.Date;
                                    oNov.Porcentaje = Convert.ToDecimal(txtDtoPor.Text.ToString());
                                    oNov.Monto = Convert.ToDecimal(txtDtoPes.Text.ToString());
                                    oNov.Tipo = "S";
                                    oNov.Imprimir = Convert.ToInt32(cboDirigido.SelectedValue);
                                    oNov.Detalle = txtDetalle.Text;
                                    oNov.Id_Usuarios_Servicios = Convert.ToInt32(dgvServicios.SelectedRows[0].Cells["id"].Value.ToString());
                                    oNov.Id_Usuarios_Servicios_Sub = 0;
                                    oNov.id_tipo_facturacion = 0;
                                    oNov.Id_Origen = Convert.ToInt32(Usuarios_Servicios_Novedades.Origen.OPERADOR);


                                    oNov.Guardar(oNov);
                                    MessageBox.Show("Novedad guardada correctamente", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    this.DialogResult = DialogResult.OK;
                                }
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

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmUsuariosCtaCteNovedadesDetalle_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void dgvServicios_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtDtoPor_Leave(object sender, EventArgs e)
        {

        }

        private void txtDtoPes_Leave(object sender, EventArgs e)
        {
            if (txtDtoPes.Text == "")
                txtDtoPes.Text = "0";
        }

        private void dtpHasta_ValueChanged(object sender, EventArgs e)
        {
            if (chkFinaliza.Checked == true)
            {
                DateTime fechaDesde = dtpDesde.Value;
                DateTime fechaHasta = dtpHasta.Value;
                if (fechaHasta < fechaDesde)
                {
                    MessageBox.Show("La fecha hasta no puede ser anterior a la fecha desde", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    dtpHasta.Focus();
                }
            }
        }

        private void frmUsuariosCtaCteNovedadesDetalle_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void cboUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(cboUsuarios.SelectedValue) == 0)
                {
                    dgvServicios.DataSource = null;
                    dgvSubservicios.DataSource = null;
                    DataTable dtZonasCategorias = new DataTable();
                    cboLocacion.Visible = false;
                    cboTipoFacturacion.Location = cboLocacion.Location;
                    cboTipoFacturacion.Visible = true;
                    cboTipoFacturacion.Enabled = true;
                    int tipoFacturacion = oCongif.GetValor_N("Id_Tipo_Facturacion");
                    if (tipoFacturacion == Convert.ToInt32(Tipo_Facturacion.Id_Tipo_Facturacion.POR_ZONAS))
                    {
                        lblLocacion.Text = "Zona";
                        dtZonasCategorias = oZonas.Listar();
                    }
                    else
                    {
                        lblLocacion.Text = "Categoria";
                        dtZonasCategorias = oServiciosCategorias.Listar();
                    }
                    cboTipoFacturacion.Location = new Point(lblLocacion.Location.X + lblLocacion.Width, cboUsuarios.Location.Y);
                    cboTipoFacturacion.DataSource = dtZonasCategorias;
                    cboTipoFacturacion.DisplayMember = "Nombre";
                    cboTipoFacturacion.ValueMember = "Id";

                    cboTipoFacturacion_SelectedIndexChanged(new object(), new EventArgs());

                }
                else
                {
                    dgvSubservicios.DataSource = null;

                    cboLocacion.Enabled = true;
                    cboLocacion.Visible = true;

                    cboTipoFacturacion.Visible = false;
                    lblLocacion.Text = "Locacion";

                    cboLocacion_SelectedValueChanged(new object(), new EventArgs());
                }
            }
            catch (Exception)
            {

            }
        }

        private void cboTipoFacturacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int idTipoFac = Convert.ToInt32(cboTipoFacturacion.SelectedValue);
                dtServicios = oSer.ListarPorTipoFacturacion(idTipoFac);
                dgvServicios.DataSource = dtServicios;
                foreach (DataGridViewColumn item in dgvServicios.Columns)
                    item.Visible = false;
                dgvServicios.Columns["descripcion"].Visible = true;
                dgvServicios.Columns["descripcion"].HeaderText = "SERVICIOS";
                dgvServicios.Enabled = true;
            }
            catch (Exception)
            {
            }
        }

        private void cboLocacion_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void chkFinaliza_CheckedChanged(object sender, EventArgs e)
        {
            if (chkFinaliza.Checked)
                dtpHasta.Enabled = true;
            else
                dtpHasta.Enabled = false;
        }

        private void cboLocacion_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (cboLocacion.Items.Count > 1 && Convert.ToInt32(cboLocacion.SelectedValue) > 0)
                {
                    oLocacionElegida = oLocacionElegida.GetLocacion(Convert.ToInt32(cboLocacion.SelectedValue));

                    dtServicios = oUsuserusu.Listar_Servicios_Activos(Convert.ToInt32(cboLocacion.SelectedValue));
                    DataRow drServiciosGeneral = dtServicios.NewRow();
                    drServiciosGeneral["id_servicios"] = 0;
                    drServiciosGeneral["id"] = 0;
                    //    drServiciosGeneral["servicio"] = "GENERAL";

                    dtServicios.Rows.Add(drServiciosGeneral);
                    dgvServicios.DataSource = dtServicios;
                    GrillaServicios();
                    dgvServicios.Enabled = true;
                    dgvSubservicios.Enabled = true;
                }
                else
                {
                    dgvServicios.DataSource = null;
                    dgvSubservicios.DataSource = null;
                    dgvServicios.Enabled = false;
                }

            }
            catch (Exception)
            {
            }
        }
    }
}
