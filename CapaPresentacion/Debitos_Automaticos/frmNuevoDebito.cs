using CapaNegocios;
using CapaPresentacion.Busquedas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace CapaPresentacion.Debitos_Automaticos
{
    public partial class frmNuevoDebito : Form
    {
        #region PROPIEDADES
        private delegate void myDel();
        private Thread hilo;
        private Plasticos_Usuarios oPlasticosUsuarios = new Plasticos_Usuarios();
        private Plasticos oPlasticos = new Plasticos();
        private Formas_de_pago oFormaPago = new Formas_de_pago();
        private Usuarios_Locaciones oLocaciones = new Usuarios_Locaciones();
        private Configuracion oConfig = new Configuracion();
        private DataTable DtFormasPago = new DataTable();
        private DataTable dtMeses = new DataTable();
        private DataTable dtYears = new DataTable();
        private DataTable dtLocaciones = new DataTable();
        private DataTable dtServiciosSeleccionados = new DataTable();
        private DataTable dtServiciosExistentes = new DataTable();
        private Usuarios oUsuarios = new Usuarios();
        private bool cargoLocaciones = false, plasticoExistente, yaCargoServiciosExistentes;
        private TabPage segunda;
        private TabPage tercera;
        public string titular, numTarjeta, nombreBanco, vencimiento, estado;
        public bool agregaServicio = false;
        private bool cargo = false;
        #endregion

        #region METODOS

        private void ComenzarCarga()
        {
            dgvServiciosContratados.DataSource = null;
            dgvServiciosSeleccionados.DataSource = null;
            hilo = new Thread(new ThreadStart(CargarDatos));
            hilo.IsBackground = true;
            hilo.Start();
        }

        private void CargarDatos()
        {
            DtFormasPago = oFormaPago.ListarFormasDePagoConPresentacion();

            myDel MD = new myDel(AsignarDatos);
            this.Invoke(MD, new object[] { });

        }

        private void AsignarDatos()
        {
            dtMeses.Columns.Add("mes", typeof(string));
            dtYears.Columns.Add("year", typeof(string));
            dtYears.Columns.Add("year_id", typeof(int));
            for (int i = 1; i < 13; i++)
            {
                if (i < 10)
                    dtMeses.Rows.Add("0" + i.ToString());
                else
                    dtMeses.Rows.Add(i.ToString());

            }
            int cantYaears = 10;
            int actualYear = DateTime.Now.Year;

            for (int i = actualYear; i < actualYear + cantYaears; i++)
                dtYears.Rows.Add(i.ToString(),i);//el string es para lo que se ve y el int es para el valor que puede leer de la base en caso que el plastico ya exista

            cboMeses.DataSource = dtMeses;
            cboMeses.DisplayMember = "mes";     
            cboYears.DataSource = dtYears;
            cboYears.DisplayMember = "year";
            cboYears.ValueMember = "year_id";

            cbTarjeta.DataSource = DtFormasPago;
            cbTarjeta.DisplayMember = "Nombre";
            cbTarjeta.ValueMember = "Id";

            cboEstado.SelectedIndex = 0; //por defecto ACTIVA
            dtServiciosSeleccionados.Columns.Add("codigo", typeof(int));
            dtServiciosSeleccionados.Columns.Add("id_usuario_servicio", typeof(int));
            dtServiciosSeleccionados.Columns.Add("servicio", typeof(string));
            dtServiciosSeleccionados.Columns.Add("locacion", typeof(string));
            dtServiciosSeleccionados.Columns.Add("fecha_inicio", typeof(string));
            dtServiciosSeleccionados.Columns.Add("fecha_inicio_dato", typeof(string));
            dtServiciosSeleccionados.Columns.Add("fecha_baja", typeof(string));
            dtServiciosSeleccionados.Columns.Add("fecha_baja_dato", typeof(string));
            dtServiciosSeleccionados.Columns.Add("id_plastico_usuario", typeof(int));
            dgvServiciosSeleccionados.DataSource = null;

            segunda = tbMain.TabPages[1];
            tercera = tbMain.TabPages[2];

            tbMain.TabPages.Remove(segunda);
            tbMain.TabPages.Remove(tercera);
            btnVolver.Enabled = false;
            btnConfirmar.Enabled = false;
            txtNumero.Focus();

            if (this.numTarjeta != null && this.numTarjeta != "")
            {
                txtNumero.Text = numTarjeta;
                VerificarTarjeta();
                txtTitular.Enabled = false;
                txtNumero.Enabled = false;
                cboEstado.Enabled = false;
                cboYears.Enabled = false;
                cboMeses.Enabled = false;
            }

        }

        public frmNuevoDebito()
        {
            InitializeComponent();
        }

        private void frmNuevoDebito_Load(object sender, EventArgs e)
        {
            ComenzarCarga();
        }
        private void Siguiente()
        {
            if (tbMain.SelectedIndex == 0)
            {
                if (txtNumero.Text.Trim().Length != 16)
                {
                    MessageBox.Show("El campo numero de tarjeta debe tener 16 dígitos", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtNumero.Focus();
                } else if (txtNumero.Text[0] != '4')
                {
                    MessageBox.Show("Éste número de tarjeta no es válido", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtNumero.Focus();
                }
                else if (txtTitular.Text.Trim().Length == 0)
                {
                    MessageBox.Show("El campo titular no puede quedar vacio", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtTitular.Focus();
                }
                else
                {
                    txtCodUsuario.Text = Usuarios.CurrentUsuario.Codigo.ToString();
                    oPlasticos.Numero = txtNumero.Text.Trim();
                    oPlasticos.Titular = txtTitular.Text;

                    if (cboEstado.SelectedIndex == 0)
                        oPlasticos.Activo = 1;
                    else
                        oPlasticos.Activo = 0;

                    oPlasticos.Vencimiento = new DateTime(Convert.ToInt32(cboYears.Text), Convert.ToInt32(cboMeses.Text), 1);
                    oPlasticos.Id_Forma_de_Pago = Convert.ToInt32(cbTarjeta.SelectedValue);

                    nombreBanco = cbTarjeta.Text;
                    titular = txtTitular.Text;
                    numTarjeta = txtNumero.Text;
                    vencimiento = string.Format("{0}/{1}", cboMeses.Text, cboYears.Text);
                    estado = cboEstado.Text;

                    lblBancoDato1.Text = nombreBanco;
                    lblNumeroDato1.Text = numTarjeta;
                    lblTitularDato1.Text = titular;
                    lblVencimientoDato1.Text = vencimiento;


                    if (tbMain.TabPages.Count == 1)
                        tbMain.TabPages.Add(segunda);

                    tbMain.SelectedIndex = 1;
                    btnVolver.Enabled = true;
                    btnSiguiente.Enabled = true;
                    BuscarServiciosUsuario();
                }
            }
            else if (tbMain.SelectedIndex == 1)
            {
                if (dgvServiciosSeleccionados.Rows.Count > 0)
                {
                    lblTipoTarjetaDato.Text = nombreBanco;
                    lblNumDato.Text = numTarjeta;
                    lblTitularDato.Text = titular;
                    lblVencimientoDato.Text = vencimiento;
                    lblEstadoDato.Text = estado;

                    if (tbMain.TabPages.Count==2)
                        tbMain.TabPages.Add(tercera);
                    foreach (DataRow item in dtServiciosSeleccionados.Rows)
                    {
                        string[] fechas = new string[2];
                        fechas = item["fecha_inicio"].ToString().Split(' ');
                        item["fecha_inicio"] = fechas[0];
                        fechas = item["fecha_baja"].ToString().Split(' ');
                        item["fecha_baja"] = fechas[0];

                    }
                    dtServiciosSeleccionados.AcceptChanges();
                    BindingSource source = new BindingSource();
                    source.DataSource = dtServiciosSeleccionados;
                    dgvFinal.DataSource = source;
                    dgvFinal.Columns["codigo"].HeaderText = "Cod. Abonado";
                    dgvFinal.Columns["codigo"].DisplayIndex = 0;
                    dgvFinal.Columns["codigo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dgvFinal.Columns["locacion"].HeaderText = "Locacion";
                    dgvFinal.Columns["locacion"].DisplayIndex = 1;
                    dgvFinal.Columns["servicio"].HeaderText = "Servicio";
                    dgvFinal.Columns["fecha_inicio"].HeaderText = "Fecha de inicio";
                    dgvFinal.Columns["fecha_inicio"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgvFinal.Columns["fecha_baja"].HeaderText = "Fecha de fin";
                    dgvFinal.Columns["fecha_baja"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgvFinal.Columns["locacion"].DisplayIndex = 2;
                    dgvFinal.Columns["id_usuario_servicio"].Visible = false;
                    dgvFinal.Columns["fecha_inicio_dato"].Visible = false;
                    dgvFinal.Columns["fecha_baja_dato"].Visible = false;
                    dgvFinal.Columns["id_plastico_usuario"].Visible = false;
                    tbMain.SelectedIndex = 2;

                }
                else
                {
                    MessageBox.Show("No se ha asociado ningun servicio a la tarjeta", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    tbMain.SelectedIndex = 1;
                }

            }
        }

        public void CambiarFecha()
        {
            if (dgvServiciosSeleccionados.SelectedRows.Count > 0)
            {
                dtpDesde.Value = Convert.ToDateTime(dgvServiciosSeleccionados.SelectedRows[0].Cells["fecha_inicio"].Value);
                dtpHasta.Value = Convert.ToDateTime(dgvServiciosSeleccionados.SelectedRows[0].Cells["fecha_baja_dato"].Value);
                frmPopUp oPop = new frmPopUp();
                oPop.InsertarMenu = true;
                oPop.pnlPanel = pnlFechas;
                oPop.Fuente = lblEstado.Font;
                oPop.ShowDialog();
                if (oPop.accionConfirma)
                {
                    dtServiciosSeleccionados.Rows[dgvServiciosSeleccionados.SelectedRows[0].Index]["fecha_inicio"] = dtpDesde.Value.Date.ToString().Split(' ')[0];
                    dtServiciosSeleccionados.Rows[dgvServiciosSeleccionados.SelectedRows[0].Index]["fecha_inicio_dato"] = dtpDesde.Value.Date.ToString();
                    dtServiciosSeleccionados.Rows[dgvServiciosSeleccionados.SelectedRows[0].Index]["fecha_baja"] = dtpHasta.Value.Date.ToString().Split(' ')[0];
                    dtServiciosSeleccionados.Rows[dgvServiciosSeleccionados.SelectedRows[0].Index]["fecha_baja_dato"] = dtpHasta.Value.Date.ToString();
                    foreach (DataGridViewRow item in dgvServiciosSeleccionados.Rows)
                    {
                        if (Convert.ToInt32(item.Cells["id_plastico_usuario"].Value) > 0)
                            item.DefaultCellStyle.BackColor = Color.FromArgb(193, 255, 51);
                    }
                    DateTime fechaFactura = Convert.ToDateTime(dgvServiciosContratados.SelectedRows[0].Cells["fecha_factura"].Value);

                    if (fechaFactura.Date.Year == dtpDesde.Value.Year && fechaFactura.Date.Month == dtpDesde.Value.Date.Month && fechaFactura.Date.Day > dtpDesde.Value.Date.Day)
                    {
                        MessageBox.Show("El servicio agregado ya tiene facturado el mes en curso, empezara a entrar en la proxima presentacion", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }
        private void FormatearGrillaSeleccionados()
        {
            dgvServiciosSeleccionados.Columns["codigo"].HeaderText = "Cod. Abonado";
            dgvServiciosSeleccionados.Columns["codigo"].DisplayIndex = 0;
            dgvServiciosSeleccionados.Columns["locacion"].HeaderText = "Locacion";
            dgvServiciosSeleccionados.Columns["locacion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvServiciosSeleccionados.Columns["locacion"].DisplayIndex = 1;
            dgvServiciosSeleccionados.Columns["servicio"].HeaderText = "Servicio";
            dgvServiciosSeleccionados.Columns["servicio"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvServiciosSeleccionados.Columns["locacion"].DisplayIndex = 2;
            dgvServiciosSeleccionados.Columns["id_usuario_servicio"].Visible = false;
            dgvServiciosSeleccionados.Columns["fecha_inicio"].HeaderText = "Inicio";
            dgvServiciosSeleccionados.Columns["fecha_inicio"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvServiciosSeleccionados.Columns["fecha_baja"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvServiciosSeleccionados.Columns["fecha_inicio_dato"].Visible = false;
            dgvServiciosSeleccionados.Columns["fecha_baja"].HeaderText = "Fin";
            dgvServiciosSeleccionados.Columns["fecha_baja_dato"].Visible = false;
            dgvServiciosSeleccionados.Columns["id_plastico_usuario"].Visible = false;

        }
        private void LimpiarCampos()
        {
            txtTitular.Text = "";
            txtNumero.Text = "";
            cboMeses.SelectedIndex = 0;
            cboYears.SelectedIndex = 0;
            txtTitular.Enabled = true;
            txtNumero.Enabled = true;
            cboEstado.Enabled = true;
            cboYears.Enabled = true;
            cboMeses.Enabled = true;
            oPlasticos.Id = 0;
            plasticoExistente = false;
            cargo = false;
        }
        public void VerificarTarjeta()
        {
            string salida = "";
            int idPlastico;
            DataTable dtDatosPlastico;
            if (oPlasticos.ExisterNumeroTarjeta(txtNumero.Text, out salida, out idPlastico, out dtDatosPlastico, out dtServiciosExistentes) == false)
            {
                if (agregaServicio == false)
                {
                    if (cargo==false && MessageBox.Show(salida, "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        cargo = true;
                        plasticoExistente = true;
                        txtTitular.Text = dtDatosPlastico.Rows[0]["titular"].ToString();
                        txtTitular.Enabled = false;
                        txtNumero.Enabled = false;
                        cboEstado.Enabled = false;
                        cboYears.Enabled = false;
                        cboMeses.Enabled = false;
                        DateTime vencimiento = Convert.ToDateTime(dtDatosPlastico.Rows[0]["vencimiento"]);
                        cboMeses.SelectedIndex = vencimiento.Month - 1;
                        cboMeses.SelectedIndex = vencimiento.Month - 1;
                        if (vencimiento.Year < DateTime.Now.Year)
                        {
                            dtYears.Rows.Add(vencimiento.Year.ToString(), vencimiento.Year);//el string es para lo que se ve y el int es para el valor que puede leer de la base en caso que el plastico ya exista
                            DataView dv = dtYears.DefaultView;
                            dv.Sort = "year asc";
                            dtYears = dv.ToTable();
                        }
                        cboYears.DataSource = dtYears;
                        cboYears.DisplayMember = "year";
                        cboYears.ValueMember = "year_id";

                        cboYears.SelectedValue = vencimiento.Year;
                        if (Convert.ToInt32(dtDatosPlastico.Rows[0]["activo"]) == 1)
                            cboEstado.SelectedIndex = 0;
                        else
                            cboEstado.SelectedIndex = 1;
                        oPlasticos.Id = idPlastico;
                        btnSiguiente.Focus();
                    }
                    else
                        txtNumero.Focus();
                }
                else
                {
                    plasticoExistente = true;
                    txtTitular.Text = dtDatosPlastico.Rows[0]["titular"].ToString();
                    DateTime vencimiento = Convert.ToDateTime(dtDatosPlastico.Rows[0]["vencimiento"]);
                    cboMeses.SelectedIndex = vencimiento.Month - 1;
                    cboMeses.SelectedIndex = vencimiento.Month - 1;
                    if (vencimiento.Year < DateTime.Now.Year)
                    {
                        dtYears.Rows.Add(vencimiento.Year.ToString(), vencimiento.Year);//el string es para lo que se ve y el int es para el valor que puede leer de la base en caso que el plastico ya exista
                        DataView dv = dtYears.DefaultView;
                        dv.Sort = "year asc";
                        dtYears = dv.ToTable();
                    }
                    cboYears.DataSource = dtYears;
                    cboYears.DisplayMember = "year";
                    cboYears.ValueMember = "year_id";

                    cboYears.SelectedValue = vencimiento.Year;
                    if (Convert.ToInt32(dtDatosPlastico.Rows[0]["activo"]) == 1)
                        cboEstado.SelectedIndex = 0;
                    else
                        cboEstado.SelectedIndex = 1;
                    oPlasticos.Id = idPlastico;
                }

            }
        }

        private void BuscarServiciosUsuario()
        {
            int cod_usuario = Convert.ToInt32(txtCodUsuario.Text);
            oUsuarios = oUsuarios.traerUsuario(0, cod_usuario);
            if (oUsuarios != null)
            {
                oUsuarios.LlenarObjeto(0, cod_usuario);
                int id_usuario = oUsuarios.Id;
                Usuarios.CurrentUsuario.Id = oUsuarios.Id;
                lblusuario.Text = string.Format("Usuario: {0}, {1}", oUsuarios.Apellido, oUsuarios.Nombre);
                dtLocaciones = oLocaciones.ListarLocacionesServicio(id_usuario);
                cargoLocaciones = false;
                cboLocaciones.DataSource = dtLocaciones;
                cboLocaciones.ValueMember = "id";
                cboLocaciones.DisplayMember = "Locacion";
                cargoLocaciones = true;
                dgvServiciosContratados.DataSource = null;
                cboLocaciones.Focus();
                if (dtLocaciones.Rows.Count > 0)
                {
                    cboLocaciones.SelectedIndex = dtLocaciones.Rows.Count - 1;
                    int idLocacionSeleccioada = Convert.ToInt32(cboLocaciones.SelectedValue);
                    if (idLocacionSeleccioada > 0)
                    {

                        Usuarios_Servicios oUsuSer = new Usuarios_Servicios();
                        DataTable dtServiciosAbonado = oUsuSer.ListarServiciosYSubServiciosActivos(Usuarios.CurrentUsuario.Id);
                        DataTable dtServiciosLocacion = new DataTable();
                        DataView dvFiltroLocacion = dtServiciosAbonado.DefaultView;
                        dvFiltroLocacion.RowFilter = "id_locacion=" + idLocacionSeleccioada.ToString() + " and id_usuario_servicio_sub=0";
                        dtServiciosLocacion = dvFiltroLocacion.ToTable();
                        dgvServiciosContratados.DataSource = dtServiciosLocacion;
                        foreach (DataGridViewColumn item in dgvServiciosContratados.Columns)
                            item.Visible = false;

                        dgvServiciosContratados.Columns["servicio"].Visible = true;
                        dgvServiciosContratados.Columns["servicio"].HeaderText = "Servicio";
                        dgvServiciosContratados.Columns["servicio"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        dgvServiciosContratados.Columns["categoria"].Visible = true;
                        dgvServiciosContratados.Columns["categoria"].HeaderText = "Categoria";
                        dgvServiciosContratados.Columns["fecha_factura"].Visible = true;
                        dgvServiciosContratados.Columns["fecha_factura"].HeaderText = "Facturado hasta";

                        foreach (DataGridViewRow item in dgvServiciosSeleccionados.Rows)
                        {
                            if (Convert.ToInt32(item.Cells["id_plastico_usuario"].Value) > 0)
                                item.DefaultCellStyle.BackColor = Color.FromArgb(193, 255, 51);
                        }
                    }
                }
            }
        }
        #endregion
        #region METODOS_CONTROLES
        private void tbMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tbMain.SelectedIndex == 2)
                btnConfirmar.Visible = true;
            else
                btnConfirmar.Visible = false;

        }
        #endregion

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            Siguiente();
        }

        private void boton3_Click(object sender, EventArgs e)
        {
            frmPopUp oFrmPopUp = new frmPopUp();
            frmBusquedaUsuarios oFrmBusqueda = new frmBusquedaUsuarios(1, "", "");
            oFrmPopUp.Formulario = oFrmBusqueda;
            oFrmPopUp.Maximizar = false;
            if (oFrmPopUp.ShowDialog() == DialogResult.OK)
            {
                lblusuario.Text = string.Format("Usuario: {0}, {1}", Usuarios.CurrentUsuario.Apellido, Usuarios.CurrentUsuario.Nombre);
                txtCodUsuario.Text = Usuarios.CurrentUsuario.Codigo.ToString();
                dtLocaciones = oLocaciones.ListarLocacionesServicio(Usuarios.CurrentUsuario.Id);
                cargoLocaciones = false;
                cboLocaciones.DataSource = dtLocaciones;
                cboLocaciones.ValueMember = "id";
                cboLocaciones.DisplayMember = "Locacion";
                cargoLocaciones = true;
                oUsuarios = new Usuarios().traerUsuario(Usuarios.CurrentUsuario.Id);
                DataRow drSeleccionar = dtLocaciones.NewRow();
                drSeleccionar["locacion"] = "SELECCIONAR UNA LOCACIÓN";
                drSeleccionar["id"] = 0;
                dtLocaciones.Rows.Add(drSeleccionar);
                dtLocaciones.AcceptChanges();
                if (dtLocaciones.Rows.Count > 0)
                    cboLocaciones.SelectedIndex = dtLocaciones.Rows.Count - 1;

                dgvServiciosContratados.DataSource = null;
                cboLocaciones.Focus();
            }
        }

        private void txtCodUsuario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                int cod_usuario = Convert.ToInt32(txtCodUsuario.Text);
                oUsuarios = new Usuarios().traerUsuario(0, cod_usuario);
                if (oUsuarios != null)
                {
                    oUsuarios.LlenarObjeto(0, cod_usuario);
                    int id_usuario = oUsuarios.Id;
                    Usuarios.CurrentUsuario.Id = oUsuarios.Id;
                    lblusuario.Text = string.Format("Usuario: {0}, {1}", oUsuarios.Apellido, oUsuarios.Nombre);
                    dtLocaciones = oLocaciones.ListarLocacionesServicio(id_usuario);
                    cargoLocaciones = false;
                    cboLocaciones.DataSource = dtLocaciones;
                    cboLocaciones.ValueMember = "id";
                    cboLocaciones.DisplayMember = "Locacion";
                    cargoLocaciones = true;
                        dgvServiciosContratados.DataSource = null;
                    cboLocaciones.Focus();
                    DataRow drSeleccionar = dtLocaciones.NewRow();
                    drSeleccionar["locacion"] = "SELECCIONAR UNA LOCACIÓN";
                    drSeleccionar["id"] = 0;
                    dtLocaciones.Rows.Add(drSeleccionar);
                    dtLocaciones.AcceptChanges();
                    if (dtLocaciones.Rows.Count > 0)
                        cboLocaciones.SelectedIndex = dtLocaciones.Rows.Count - 1;
                }
                else
                    MessageBox.Show("Codigo de usuario no encontrado");
            }
        }

        private void cboLocaciones_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cargoLocaciones)
            { 

                int idLocacionSeleccioada = Convert.ToInt32(cboLocaciones.SelectedValue);
                if(idLocacionSeleccioada>0)
                {

                    Usuarios_Servicios oUsuSer = new Usuarios_Servicios();
                    DataTable dtServiciosAbonado = oUsuSer.ListarServiciosYSubServiciosActivos(Usuarios.CurrentUsuario.Id);
                    DataTable dtServiciosLocacion = new DataTable();
                    DataView dvFiltroLocacion = dtServiciosAbonado.DefaultView;
                    dvFiltroLocacion.RowFilter = "id_locacion=" + idLocacionSeleccioada.ToString() + " and id_usuario_servicio_sub=0" ;
                    dtServiciosLocacion = dvFiltroLocacion.ToTable();
                    dgvServiciosContratados.DataSource = dtServiciosLocacion;
                    foreach (DataGridViewColumn item in dgvServiciosContratados.Columns)
                        item.Visible = false;

                    dgvServiciosContratados.Columns["servicio"].Visible = true;
                    dgvServiciosContratados.Columns["servicio"].HeaderText = "Servicio";
                    dgvServiciosContratados.Columns["servicio"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dgvServiciosContratados.Columns["categoria"].Visible = true;
                    dgvServiciosContratados.Columns["categoria"].HeaderText = "Categoria";
                    dgvServiciosContratados.Columns["fecha_factura"].Visible = true;
                    dgvServiciosContratados.Columns["fecha_factura"].HeaderText = "Facturado hasta";
                }
                else
                {
                    dgvServiciosContratados.DataSource = null;
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (dgvServiciosContratados.SelectedRows.Count>0)
            {
                int idServicio = Convert.ToInt32(dgvServiciosContratados.SelectedRows[0].Cells["id_Servicio"].Value);
                DataView dvServicios = Tablas.DataServicios.DefaultView;
                dvServicios.RowFilter = $"id={idServicio}";
                DataTable dtDatosServicio = dvServicios.ToTable();
               
                if (dtDatosServicio.Rows.Count > 0)
                {

                    if (Convert.ToInt32(dtDatosServicio.Rows[0]["habilita_debito"]) == 0) {
                        MessageBox.Show("Este servicio no esta habilitado para adherir a débito automático. ", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        string salida = "";
                        if(!oPlasticosUsuarios.ValidarUsuarioServicio(Convert.ToInt32(dgvServiciosContratados.SelectedRows[0].Cells["id_usuario_servicio"].Value),out salida))
                            MessageBox.Show(salida, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        else
                        {
                            if (dgvServiciosSeleccionados.Rows.Count > 0)
                            {
                                DataView dvSerrviciosSele = dtServiciosSeleccionados.DefaultView;
                                dvSerrviciosSele.RowFilter = "id_usuario_servicio=" + Convert.ToInt32(dgvServiciosContratados.SelectedRows[0].Cells["id_usuario_servicio"].Value);
                                DataTable dtFiltro = dvSerrviciosSele.ToTable();
                                if(dtFiltro.Rows.Count>0)
                                {
                                    MessageBox.Show("Este servicio ya se encuentra en la lista de servicio a asociar a la tarjeta.", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    dvSerrviciosSele.RowFilter = "";
                                }
                                else
                                {
                                    if(dtFiltro.Rows.Count >0 && (dtFiltro.Rows[0]["modalidad"].ToString().ToLower().Equals("por dia") || dtFiltro.Rows[0]["modalidad"].ToString().ToLower().Equals("por periodo cerrado por dia")))
                                        MessageBox.Show("Este servicio no es un servicio Mensual, por lo tanto no se puede adherir a débito automático.", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    else
                                    {
                                        dvSerrviciosSele.RowFilter = "";
                                        DataRow drNUevo = dtServiciosSeleccionados.NewRow();
                                        drNUevo["codigo"] = Convert.ToInt32(txtCodUsuario.Text);
                                        drNUevo["locacion"] = cboLocaciones.Text;
                                        drNUevo["id_usuario_servicio"] = Convert.ToInt32(dgvServiciosContratados.SelectedRows[0].Cells["id_usuario_servicio"].Value);
                                        drNUevo["servicio"] = dgvServiciosContratados.SelectedRows[0].Cells["servicio"].Value.ToString();
                                        drNUevo["fecha_inicio"] = DateTime.Now.Date.ToString().Split(' ')[0];
                                        drNUevo["fecha_baja"] = Convert.ToDateTime(oConfig.GetValor_C("FechaDebitoFin")).ToString().Split(' ')[0];
                                        drNUevo["fecha_inicio_dato"] = DateTime.Now.Date.ToString().Split(' ')[0];
                                        drNUevo["fecha_baja_dato"] = Convert.ToDateTime(oConfig.GetValor_C("FechaDebitoFin")).ToString().Split(' ')[0];
                                        drNUevo["id_plastico_usuario"] = 0;

                                        dtServiciosSeleccionados.Rows.Add(drNUevo);
                                        dtServiciosSeleccionados.AcceptChanges();
                                        dgvServiciosSeleccionados.DataSource = dtServiciosSeleccionados;

                                        dgvServiciosSeleccionados.Rows[dgvServiciosSeleccionados.Rows.Count - 1].Selected = true;
                                        FormatearGrillaSeleccionados();
                                        CambiarFecha();

                                    }
                                }
                            }
                            else
                            {
                  
                                DataRow drNUevo = dtServiciosSeleccionados.NewRow();
                                drNUevo["codigo"] = Convert.ToInt32(txtCodUsuario.Text);
                                drNUevo["locacion"] = cboLocaciones.Text;
                                drNUevo["id_usuario_servicio"] = Convert.ToInt32(dgvServiciosContratados.SelectedRows[0].Cells["id_usuario_servicio"].Value);
                                drNUevo["servicio"] = dgvServiciosContratados.SelectedRows[0].Cells["servicio"].Value.ToString();
                                drNUevo["fecha_inicio"] = DateTime.Now.Date.ToString().Split(' ')[0];
                                drNUevo["fecha_baja"] = Convert.ToDateTime(oConfig.GetValor_C("FechaDebitoFin")).ToString().Split(' ')[0];
                                drNUevo["fecha_inicio_dato"] = DateTime.Now.Date.ToString().Split(' ')[0];
                                drNUevo["fecha_baja_dato"] = Convert.ToDateTime(oConfig.GetValor_C("FechaDebitoFin")).ToString().Split(' ')[0];
                                drNUevo["id_plastico_usuario"] = 0;
                               
                                dtServiciosSeleccionados.Rows.Add(drNUevo);
                                dtServiciosSeleccionados.AcceptChanges();
                                dgvServiciosSeleccionados.DataSource = dtServiciosSeleccionados;
                                dgvServiciosSeleccionados.Rows[dtServiciosSeleccionados.Rows.Count - 1].Selected = true;
                                FormatearGrillaSeleccionados();
                                CambiarFecha();
                            }
                        }
                    }
                }
            }
        }

        private void tbMain_Selecting(object sender, TabControlCancelEventArgs e)
        {
            foreach (DataGridViewRow item in dgvServiciosSeleccionados.Rows)
            {
                if (Convert.ToInt32(item.Cells["id_plastico_usuario"].Value) > 0)
                    item.DefaultCellStyle.BackColor = Color.FromArgb(193, 255, 51);
            }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if(dgvFinal.Rows.Count>0)
            {
                if(MessageBox.Show("¿Se va a guardar una nueva tarjeta y asociar servicios, ¿Desea confirmar la operación?","Mensaje del Sistema",MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (oPlasticos.Id == 0)
                    {
                        if (oPlasticos.Guardar(oPlasticos))
                        {
                            foreach (DataRow item in dtServiciosSeleccionados.Rows)
                            {
                                if (Convert.ToInt32(item["id_plastico_usuario"]) == 0)
                                {
                                    oPlasticosUsuarios = new Plasticos_Usuarios();
                                    oPlasticosUsuarios.Id_Plastico = oPlasticos.Id;
                                    oPlasticosUsuarios.Fecha_Solicitud = DateTime.Now;
                                    oPlasticosUsuarios.Fecha_Inicio = Convert.ToDateTime(item["fecha_inicio_dato"]);
                                    oPlasticosUsuarios.Fecha_Baja = Convert.ToDateTime(item["fecha_baja_dato"]);
                                    oPlasticosUsuarios.Id_Usuarios_Servicios = Convert.ToInt32(item["id_usuario_servicio"]);
                                    oPlasticosUsuarios.Id_Usuario = Usuarios.CurrentUsuario.Id;
                                    oPlasticosUsuarios.Activo = 1;
                                    oPlasticosUsuarios.Guardar(oPlasticosUsuarios);
                                }
                            }
                            if(MessageBox.Show("Tarjeta guardada correctamente. ¿Desea imprimir los contratos?", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                            {
                                Impresiones.Impresion oImpresiones = new Impresiones.Impresion();
                                foreach (DataRow item in dtServiciosSeleccionados.Rows)
                                {
                                   oImpresiones.ImprimirContratoDebitoAut(txtTitular.Text, txtNumero.Text, lblVencimientoDato.Text, oPlasticos.Id, item["fecha_inicio"].ToString(), item["servicio"].ToString());
                                }
                                this.DialogResult = DialogResult.OK;
                            }
                            else
                                this.DialogResult =  DialogResult.OK;

                           

                        }
                    }
                    else
                    {
                        foreach (DataRow item in dtServiciosSeleccionados.Rows)
                        {
                            if (Convert.ToInt32(item["id_plastico_usuario"]) == 0)
                            {
                                oPlasticosUsuarios = new Plasticos_Usuarios();
                                oPlasticosUsuarios.Id_Plastico = oPlasticos.Id;
                                oPlasticosUsuarios.Fecha_Solicitud = DateTime.Now;
                                oPlasticosUsuarios.Fecha_Inicio = Convert.ToDateTime(item["fecha_inicio_dato"]);
                                oPlasticosUsuarios.Fecha_Baja = Convert.ToDateTime(item["fecha_baja_dato"]);
                                oPlasticosUsuarios.Id_Usuarios_Servicios = Convert.ToInt32(item["id_usuario_servicio"]);
                                oPlasticosUsuarios.Id_Usuario = Usuarios.CurrentUsuario.Id;
                                oPlasticosUsuarios.Activo = 1;
                                oPlasticosUsuarios.Guardar(oPlasticosUsuarios);
                            }
                        }
                        if (MessageBox.Show("Servicios adheridos a la tarjeta correctamente. ¿Desea imprimir los contratos?", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                        {
                            Impresiones.Impresion oImpresiones = new Impresiones.Impresion();
                            foreach (DataRow item in dtServiciosSeleccionados.Rows)
                            {
                                if (Convert.ToInt32(item["id_plastico_usuario"]) == 0)
                                    oImpresiones.ImprimirContratoDebitoAut(txtTitular.Text, txtNumero.Text, lblVencimientoDato.Text, oPlasticos.Id, item["fecha_inicio"].ToString(), item["servicio"].ToString());
                            }
                                
                            this.DialogResult = DialogResult.OK;
                        }
                        else
                            this.DialogResult = DialogResult.OK;
                    }
                }
            }
        }

        private void btnAceptaFechas_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void btnQiutar_Click(object sender, EventArgs e)
        {
            if(dtServiciosSeleccionados.Rows.Count>0 && dgvServiciosSeleccionados.SelectedRows.Count > 0)
            {
                if (Convert.ToInt32(dgvServiciosSeleccionados.SelectedRows[0].Cells["id_plastico_usuario"].Value) > 0)
                    MessageBox.Show("Este servicio ya esta asociado a la tarjeta, para dar de baja el servicio seleccionado, tiene que ir al menú DÉBITOS -> BAJA DE DÉBITO.", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                else
                    dtServiciosSeleccionados.Rows.RemoveAt(dgvServiciosSeleccionados.SelectedRows[0].Index);
            }
        }

        private void tbServicios_Enter(object sender, EventArgs e)
        {
            if(dtServiciosExistentes!=null && dtServiciosExistentes.Rows.Count>0 && yaCargoServiciosExistentes==false)
            {
                foreach (DataRow item in dtServiciosExistentes.Rows)
                {
                    DataRow drNUevo = dtServiciosSeleccionados.NewRow();
                    drNUevo["codigo"] = Convert.ToInt32(item["codigo"]);
                    drNUevo["locacion"] = item["locacion"].ToString();
                    drNUevo["id_usuario_servicio"] = Convert.ToInt32(item["id_usuarios_servicios"]);
                    drNUevo["servicio"] = item["servicio"].ToString();
                    drNUevo["fecha_inicio"] = Convert.ToDateTime(item["fecha_inicio"]).Date.ToString().Split(' ')[0];
                    drNUevo["fecha_baja"] = Convert.ToDateTime(item["fecha_baja"]).Date.ToString().Split(' ')[0];
                    drNUevo["fecha_inicio_dato"] = Convert.ToDateTime(item["fecha_inicio"]).Date.ToString().Split(' ')[0];
                    drNUevo["fecha_baja_dato"] = Convert.ToDateTime(item["fecha_baja"]).Date.ToString().Split(' ')[0];
                    drNUevo["id_plastico_usuario"] = Convert.ToInt32(item["id_plastico_usuario"]);
                    dtServiciosSeleccionados.Rows.Add(drNUevo);

                }
                yaCargoServiciosExistentes = true;
                dtServiciosSeleccionados.AcceptChanges();
                dgvServiciosSeleccionados.DataSource = dtServiciosSeleccionados;
                FormatearGrillaSeleccionados();
            }
            btnSiguiente.Enabled = true;
            btnConfirmar.Enabled = false;
            btnVolver.Enabled = true;
            txtCodUsuario.Focus();
        }

        private void tbConfirmar_Enter(object sender, EventArgs e)
        {
            btnVolver.Enabled = true;
            btnSiguiente.Enabled = false;
            btnConfirmar.Enabled = true;
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            tbMain.SelectedIndex = tbMain.SelectedIndex - 1;
        }

        private void dgvServiciosSeleccionados_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvServiciosSeleccionados.SelectedRows.Count > 0)
            {
                if (Convert.ToInt32(dgvServiciosSeleccionados.SelectedRows[0].Cells["id_plastico_usuario"].Value) == 0)
                {
                    frmPopUp oPop = new frmPopUp();
                    dtpDesde.Value = Convert.ToDateTime(dgvServiciosSeleccionados.SelectedRows[0].Cells["fecha_inicio"].Value);
                    dtpHasta.Value = Convert.ToDateTime(dgvServiciosSeleccionados.SelectedRows[0].Cells["fecha_baja_dato"].Value);
                    oPop.InsertarMenu = true;
                    oPop.pnlPanel = pnlFechas;
                    oPop.Fuente = lblEstado.Font;
                    oPop.ShowDialog();
                    if (oPop.accionConfirma)
                    {
                        dtServiciosSeleccionados.Rows[dgvServiciosSeleccionados.SelectedRows[0].Index]["fecha_inicio"] = dtpDesde.Value.Date.ToString().Split(' ')[0];
                        dtServiciosSeleccionados.Rows[dgvServiciosSeleccionados.SelectedRows[0].Index]["fecha_inicio_dato"] = dtpDesde.Value.Date.ToString();
                        dtServiciosSeleccionados.Rows[dgvServiciosSeleccionados.SelectedRows[0].Index]["fecha_baja"] = dtpHasta.Value.Date.ToString().Split(' ')[0];
                        dtServiciosSeleccionados.Rows[dgvServiciosSeleccionados.SelectedRows[0].Index]["fecha_baja_dato"] = dtpHasta.Value.Date.ToString();
                    }
                }
                else
                    MessageBox.Show("No se puede editar los datos de servicios que ya estan adheridos a la tarjeta", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void txtNumero_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTitular_Leave(object sender, EventArgs e)
        {

        }
        private void btnEligeOtra_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void txtNumero_Leave(object sender, EventArgs e)
        {
             VerificarTarjeta();
        }
        private void tabPage1_Enter(object sender, EventArgs e)
        {
            btnVolver.Enabled = false;
            btnConfirmar.Enabled = false;
            btnSiguiente.Enabled = true;
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            Impresiones.Impresion oImpresiones = new Impresiones.Impresion();
            foreach (DataRow item in dtServiciosSeleccionados.Rows)
                oImpresiones.ImprimirContratoDebitoAut(txtTitular.Text, txtNumero.Text, lblVencimientoDato.Text, oPlasticos.Id, item["fecha_inicio"].ToString(), item["servicio"].ToString());
        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void frmNuevoDebito_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
    }
}
