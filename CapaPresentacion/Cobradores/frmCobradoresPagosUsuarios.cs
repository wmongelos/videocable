using CapaNegocios;
using CapaPresentacion.Busquedas;
using System;
using System.Data;
using System.Windows.Forms;
namespace CapaPresentacion
{
    public partial class frmCobradoresPagosUsuarios : Form
    {
        #region
        private Usuarios oUsuarios = new Usuarios();
        private DataTable dt_usuarios = new DataTable();
        private frmPopUp oFrmPopUp;
        private Formas_de_pago oFormasPago = new Formas_de_pago();
        private DataTable dtDatosCobrado;
        private frmBusquedaUsuarios oFrmBusqueda;
        private Usuarios_CtaCte_Recibos oUsuCtaCteRecibos = new Usuarios_CtaCte_Recibos();
        private Usuarios_Locaciones oUsuLoc = new Usuarios_Locaciones();
        Puntos_Cobros oPuntosCobros = new Puntos_Cobros();
        private DataTable dtLocaciones = new DataTable();
        public int id_comprobante, id_usuario = 0, cod_usuario, idCobrador, idusuarioctacterecibo, idCaja;
        public decimal importe_recibo, importe_rendido, saldo;
        public Int32 Cuenta = 1;
        decimal Total = 0, rendido = 0, recibo = 0;
        int cont = 0;


        #endregion

        public frmCobradoresPagosUsuarios()
        {
            InitializeComponent();
        }

        private void frmCobradoresPagosUsuarios_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Salir();
                this.DialogResult = DialogResult.Cancel;
            }

        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmCobradoresPagosUsuarios_Load(object sender, EventArgs e)
        {
            decimal TotalPago = 0;
            TotalPago=CheckearPago();
            if (Cuenta == 1)
                lbCuenta.Visible = false;

            if (Cuenta == 2)
                lbCuenta.Visible = true;

            if (cont < 1)
            {
                if (TotalPago == 0)
                {
                    if (MessageBox.Show("Operacion completada, se pago el recibo completo.¿Desea continuar?", "Mensaje del Sistema",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        this.Close();
                    }
                }
                cont = cont + 1;
            }


            txtCodUsuario.Focus();
        }

        public decimal CheckearPago()
        {
            if (Cuenta == 1)
                dtDatosCobrado = oPuntosCobros.Listar_Cobradores_Consulta_Pagos(idCobrador, Convert.ToInt32(Comprobantes_Tipo.Tipo.RECIBO_COBRADOR));
            else
                dtDatosCobrado = oPuntosCobros.Listar_Cobradores_Consulta_Pagos(idCobrador, Convert.ToInt32(Comprobantes_Tipo.Tipo.RECIBO_COBRADOR_INTERNO));
            DataView dv = new DataView(dtDatosCobrado);
            dv.RowFilter = "id_comprobantes= " + id_comprobante;
            DataTable dtFiltrada = dv.ToTable();
            if (dtFiltrada.Rows.Count > 0)
            {
                foreach (DataRow drFilt in dtFiltrada.Rows)
                {
                    recibo = Convert.ToDecimal(drFilt["Importe_Recibo"]);
                    rendido = Convert.ToDecimal(drFilt["Importe_rendido"]);
                    txtrecibo.Text = recibo.ToString();
                    txtrendido.Text = rendido.ToString();
                    Total = recibo - rendido;
                    txtsaldo.Text = Total.ToString();
                }
            }
            return Total;
        }

        private void txtReciboNro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                dtpFecha.Focus();
        }

        private void dtpFecha_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                txtImporte.Focus();
        }

        private void txtImporte_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                btnactualizarpago.Focus();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnactualizarpago_Click(object sender, EventArgs e)
        {
            if (id_usuario == 0)
            {
                MessageBox.Show("Se debe seleccionar un usuario", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtCodUsuario.Focus();
                return;
            }

            if (String.IsNullOrEmpty(txtReciboNro.Text) || txtReciboNro.Text == "0")
            {
                MessageBox.Show("Se debe ingresar el numero de recibo", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtReciboNro.Focus();
                return;
            }

            //listar pagos si no hay ninguno es un solo pago en efectivo
            DataTable dtRecibos = new DataTable();
            dtRecibos = oUsuCtaCteRecibos.ListarCtaCteRecibosdet(id_comprobante, "nada");
            DataView dvFiltro = new DataView(dtRecibos);
            dvFiltro.RowFilter = "cod_usuario=" + oUsuarios.Codigo;
            DataTable dtFiltrada = dvFiltro.ToTable();
            frmUsuariosCtaCte oCtacte = new frmUsuariosCtaCte(oUsuarios.Id, 0);
            oCtacte.idCobrador = this.idCobrador;
            DataTable dtDetalleRecibo = new DataTable();
            dtDetalleRecibo.Columns.Add("Nombre", typeof(String));
            dtDetalleRecibo.Columns.Add("Importe", typeof(Decimal));
            dtDetalleRecibo.Columns.Add("Cliente", typeof(string));
            dtDetalleRecibo.Columns.Add("Cuenta", typeof(string));
            dtDetalleRecibo.Columns.Add("Cuit", typeof(string));
            dtDetalleRecibo.Columns.Add("Banco", typeof(string));
            dtDetalleRecibo.Columns.Add("Sucursal", typeof(string));
            dtDetalleRecibo.Columns.Add("Fecha_Comprobante", typeof(string));
            dtDetalleRecibo.Columns.Add("Fecha_Acreditacion", typeof(string));
            dtDetalleRecibo.Columns.Add("Numero", typeof(Int32));
            dtDetalleRecibo.Columns.Add("Id_formas_de_pago", typeof(Int32));
            dtDetalleRecibo.Columns.Add("Id_usuarios_locaciones", typeof(Int32));
            if (dtFiltrada.Rows.Count > 0)
            {
                foreach (DataRow item in dtFiltrada.Rows)
                {
                    DataRow drNueva = dtDetalleRecibo.NewRow();

                    drNueva["nombre"] = item["descripcion"].ToString();
                    drNueva["importe"] = Convert.ToDecimal(item["importe"]);
                    drNueva["Cliente"] = item["nombre"];
                    drNueva["Cuenta"] = 1;
                    drNueva["Cuit"] = "";
                    drNueva["Banco"] = item["banco"].ToString();
                    drNueva["Sucursal"] = "";
                    drNueva["Fecha_Comprobante"] = Convert.ToDateTime(item["fecha_comprobante"]);
                    drNueva["Fecha_Acreditacion"] = Convert.ToDateTime(item["fecha_acreditacion"]);
                    drNueva["Numero"] = Convert.ToInt32(item["numero"]);
                    drNueva["Id_formas_de_pago"] = Convert.ToInt32(item["id_formas_de_pago"]);
                    drNueva["Id_usuarios_locaciones"] = 0;
                    dtDetalleRecibo.Rows.Add(drNueva);
                }
            }
            else
            {
                DataRow drNueva = dtDetalleRecibo.NewRow();
                DataTable dtFormas = new DataTable();
                dtFormas = oFormasPago.ListarPorTipodeForma(1);
                drNueva["nombre"] = dtFormas.Rows[0]["nombre"].ToString();
                drNueva["importe"] = Convert.ToDecimal(txtImporte.Text);
                drNueva["Cliente"] = "";
                drNueva["Cuenta"] = 1;
                drNueva["Cuit"] = "";
                drNueva["Banco"] = "";
                drNueva["Sucursal"] = "";
                drNueva["Fecha_Comprobante"] = new DateTime();
                drNueva["Fecha_Acreditacion"] = new DateTime();
                drNueva["Numero"] = Convert.ToInt32(txtReciboNro.Text);
                drNueva["Id_formas_de_pago"] = Convert.ToInt32(dtFormas.Rows[0]["id"]);
                drNueva["Id_usuarios_locaciones"] = 0;
                dtDetalleRecibo.Rows.Add(drNueva);

            }
            decimal total = 0;
            foreach (DataRow item in dtDetalleRecibo.Rows)
            {
                total = total + Convert.ToDecimal(item["importe"]);
            }

            if (total < Convert.ToDecimal(txtImporte.Text))
            {
                DataRow drNueva = dtDetalleRecibo.NewRow();
                DataTable dtFormas = new DataTable();
                dtFormas = oFormasPago.ListarPorTipodeForma(1);
                drNueva["nombre"] = dtFormas.Rows[0]["nombre"].ToString();
                drNueva["importe"] = Convert.ToDecimal(txtImporte.Text) - total;
                drNueva["Cliente"] = "";
                drNueva["Cuenta"] = 1;
                drNueva["Cuit"] = "";
                drNueva["Banco"] = "";
                drNueva["Sucursal"] = "";
                drNueva["Fecha_Comprobante"] = new DateTime();
                drNueva["Fecha_Acreditacion"] = new DateTime();
                drNueva["Numero"] = Convert.ToInt32(txtReciboNro.Text);
                drNueva["Id_formas_de_pago"] = Convert.ToInt32(dtFormas.Rows[0]["id"]);
                drNueva["Id_usuarios_locaciones"] = 0;
                dtDetalleRecibo.Rows.Add(drNueva);
            }
            frmUsuariosCtaCte.dtDetalleReciboCobrador = dtDetalleRecibo;
            oCtacte.vieneCobrador = 1;
            oCtacte.TotalPagoCobrador = Convert.ToDecimal(txtImporte.Text);
            oCtacte.idComprobanteCobrador = this.id_comprobante;
            oCtacte.saldoCobrador = saldo;
            oCtacte.idusuarioctacterecibo = idusuarioctacterecibo;
            oCtacte.cuenta = Cuenta;
            oCtacte.FechaRecibo = dtpFecha.Value;
            oCtacte.idCaja = this.idCaja;

            if (oCtacte.ShowDialog() == DialogResult.OK)
            {
                this.DialogResult = DialogResult.OK;

                try
                {
                    txtReciboNro.Text = (Convert.ToDouble(txtReciboNro.Text.ToString()) + 1).ToString();
                }
                catch { txtReciboNro.Text = ""; }
            }
            if (txtCodUsuario.CanFocus)
                txtCodUsuario.Focus();
        }

        private void txtImporte_Enter(object sender, EventArgs e)
        {
            txtImporte.Select(0, txtImporte.Text.Length);

        }

        private void txtImporte_Leave(object sender, EventArgs e)
        {
            decimal resu = 0;
            if (decimal.TryParse(txtImporte.Text, out resu) == true)
            {
                if (resu > 0)
                    btnactualizarpago.Enabled = true;
                else
                    btnactualizarpago.Enabled = false;
            }
            else
                btnactualizarpago.Enabled = false;

        }

        private void txtImporte_Click(object sender, EventArgs e)
        {
            txtImporte.Select(0, txtImporte.Text.Length);

        }

        private void txtCodUsuario_Enter(object sender, EventArgs e)
        {
            Limpia();

        }

        private void frmCobradoresPagosUsuarios_Activated(object sender, EventArgs e)
        {
            CheckearPago();
            txtCodUsuario.Focus();
        }



        private void Limpia()
        {
            txtCodUsuario.Text = "";
            txtImporte.Text = "0";
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            oFrmPopUp = new frmPopUp();
            oFrmBusqueda = new frmBusquedaUsuarios(1, "", "");
            oFrmPopUp.Formulario = oFrmBusqueda;
            oFrmPopUp.Maximizar = false;
            if (oFrmPopUp.ShowDialog() == DialogResult.OK)
            {
                lblusuario.Text = string.Format("Usuario: {0}, {1}", Usuarios.CurrentUsuario.Apellido, Usuarios.CurrentUsuario.Nombre);
                txtCodUsuario.Text = Usuarios.CurrentUsuario.Codigo.ToString();
                dtLocaciones = oUsuLoc.ListarLocacionesServicio(id_usuario);
                id_usuario = Usuarios.CurrentUsuario.Id;
                oUsuarios.Id = id_usuario;
            }
        }

        private void txtCodUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtCodUsuario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtCodUsuario.Text == "")
                    MessageBox.Show("Ingrese un codigo de usuario");
                else 
                { 
                    cod_usuario = Convert.ToInt32(txtCodUsuario.Text);
                    oUsuarios = new Usuarios();
                    oUsuarios = oUsuarios.traerUsuario(0, cod_usuario);
                    if (oUsuarios != null)
                    {
                        oUsuarios.LlenarObjeto(0, cod_usuario);
                        id_usuario = oUsuarios.Id;
                        Usuarios.CurrentUsuario.Id = oUsuarios.Id;
                        lblusuario.Text = string.Format("Usuario: {0}, {1}", oUsuarios.Apellido, oUsuarios.Nombre);
                        dtLocaciones = oUsuLoc.ListarLocacionesServicio(id_usuario);
                        txtReciboNro.Focus();
                    }
                    else
                        MessageBox.Show("Codigo de usuario no encontrado");
                }
            }
        }
        private void Salir()
        {
            id_comprobante = 0;
            id_usuario = 0;
            //lblnumero_compobante.Text = "0";
            txtCodUsuario.Text = "0";
            txtrecibo.Text = "0";
            txtrendido.Text = "0";
            txtsaldo.Text = "0";
        }
    }
}