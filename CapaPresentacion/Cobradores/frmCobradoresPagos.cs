using CapaNegocios;
using System;
using System.Data;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class frmCobradoresPagos : Form
    {
        #region [PROPIEDADES]
        private Puntos_Cobros oPuntosCobros = new Puntos_Cobros();
        private Formas_de_pago oFormasPago = new Formas_de_pago();
        private Thread hilo;
        private delegate void myDel();
        private DataTable dt_cobradores = new DataTable();
        private DataTable dtFormasPago = new DataTable();
        private DataTable dtFormasPago2 = new DataTable();
        private DataTable dtDetalles = new DataTable();
        private DataTable dtDetalles2 = new DataTable();
        private DataTable dtPagosCuenta1 = new DataTable();
        private DataTable dtPagosCuenta2 = new DataTable();
        private Int32 NroRecibo;
        private string NumeroString_cuenta1, NumeroString_cuenta2;
        private Comprobantes_Tipo oComprobante_Tipo = new Comprobantes_Tipo();
        private Comprobantes oComprobantes = new Comprobantes();
        private Usuarios_CtaCte_Recibos oUsuarios_CtaCte_Recibos = new Usuarios_CtaCte_Recibos();
        private Caja_Diaria ocaja_diaria = new Caja_Diaria();

        private DataRow drDatosComprobanteBlanco;
        private DataRow drDatosComprobanteNegro;
        private int id = 0, idCajaNueva;
        private int id_punto_venta, hasta1, hasta2, desde1, desde2, id_comprobante, num_punto_venta;
        private decimal Total = 0, caja1 = 0, caja2 = 0;
        private DateTime fecha_hoy;
        private Int32 contadorDetalles1 = 0;
        private int idFormaActual = 0;

        #endregion

        public frmCobradoresPagos()
        {
            InitializeComponent();
        }

        private void comenzarCarga()
        {

            hilo = new Thread(new ThreadStart(cargarDatos));
            hilo.Start();
        }

        private void cargarDatos()
        {
            try
            {
                dt_cobradores = oPuntosCobros.ListarPorTipoSucursal("COBRADOR");
                dtFormasPago = oFormasPago.Listar();
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
            dtDetalles.Columns.Add("id", typeof(int));
            dtDetalles.Columns.Add("id_forma_pago", typeof(int));
            dtDetalles.Columns.Add("cod_usu", typeof(int));
            dtDetalles.Columns.Add("forma", typeof(string));
            dtDetalles.Columns.Add("monto", typeof(decimal));
            dtDetalles.Columns.Add("borrado", typeof(int));
            dtDetalles.Columns.Add("id_usu", typeof(int));
            dtDetalles.Columns.Add("activo", typeof(int));
            dtDetalles.Columns.Add("banco", typeof(string));
            dtDetalles.Columns.Add("titular", typeof(string));
            dtDetalles.Columns.Add("cuit", typeof(string));
            dtDetalles.Columns.Add("sucursal", typeof(string));
            dtDetalles.Columns.Add("cuenta", typeof(string));
            dtDetalles.Columns.Add("fecha_comp", typeof(DateTime));
            dtDetalles.Columns.Add("fecha_acre", typeof(DateTime));
            dtDetalles.Columns.Add("numero", typeof(string));

            dtDetalles2 = dtDetalles.Clone();


            dtPagosCuenta1.Columns.Add("id_forma_pago", typeof(int));
            dtPagosCuenta1.Columns.Add("forma_pago", typeof(string));
            dtPagosCuenta1.Columns.Add("monto", typeof(decimal));
            dtPagosCuenta1.Columns.Add("id_tipo_forma_pago", typeof(int));

            dtPagosCuenta2.Columns.Add("id_forma_pago", typeof(int));
            dtPagosCuenta2.Columns.Add("forma_pago", typeof(string));
            dtPagosCuenta2.Columns.Add("monto", typeof(decimal));
            dtPagosCuenta2.Columns.Add("id_tipo_forma_pago", typeof(int));
            if (dtFormasPago.Rows.Count > 0)
            {
                foreach (DataRow item in dtFormasPago.Rows)
                {
                    int idFormaPago = Convert.ToInt32(item["id"]);
                    string nombreFormaPago = item["nombre"].ToString();
                    int idTipoFormaPago = Convert.ToInt32(item["id_tipo_de_forma"]);
                    dtPagosCuenta1.Rows.Add(idFormaPago, nombreFormaPago, 0, idTipoFormaPago);
                    dtPagosCuenta2.Rows.Add(idFormaPago, nombreFormaPago, 0, idTipoFormaPago);

                }
            }
            dgvForma1.ReadOnly = false;
            dgvForma2.ReadOnly = false;

            dgvForma1.DataSource = dtPagosCuenta1;
            dtFormasPago2 = dtPagosCuenta2;
            dgvForma2.DataSource = dtFormasPago2;
            FormatearGrilla(dgvForma1);
            FormatearGrilla(dgvForma2);
            cboCobradores.DataSource = dt_cobradores;
            cboCobradores.ValueMember = "Id";
            cboCobradores.DisplayMember = "Descripcion";
            splitContainer1.SplitterDistance = splitContainer1.Width / 2;
        }

        private void FormatearGrilla(DataGridView dgv)
        {
            dgv.Columns["id_forma_pago"].Visible = false;
            dgv.Columns["id_tipo_forma_pago"].Visible = false;

            dgv.Columns["forma_pago"].HeaderText = "Formas de pago";
            dgv.Columns["monto"].HeaderText = "Monto";

        }

        private void Sumar()
        {
            caja1 = 0;
            foreach (DataRow item in dtDetalles.Rows)
            {
                caja1 = caja1 + Convert.ToDecimal(item["monto"]);
            }
            foreach (DataGridViewRow item in dgvForma1.Rows)
            {
                if (Convert.ToInt32(item.Cells["id_tipo_forma_pago"].Value) == Convert.ToInt32(Formas_de_pago.Tipos_Formas_Pagos.EFECTIVO))
                    caja1 = caja1 + Convert.ToDecimal(item.Cells["monto"].Value);
            }
            lblTotal1.Text = caja1.ToString("c");
            caja2 = 0;

            foreach (DataRow item in dtDetalles2.Rows)
            {
                caja2 = caja2 + Convert.ToDecimal(item["monto"]);
            }
            foreach (DataGridViewRow item in dgvForma2.Rows)
            {
                if (Convert.ToInt32(item.Cells["id_tipo_forma_pago"].Value) == Convert.ToInt32(Formas_de_pago.Tipos_Formas_Pagos.EFECTIVO))
                    caja2 = caja2 + Convert.ToDecimal(item.Cells["monto"].Value);
            }
            lblTotal2.Text = caja2.ToString("c");

            Total = caja1 + caja2;
            lblTotal.Text = Total.ToString();
        }

        private void frmCobradoresPagos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void frmCobradoresPagos_Load(object sender, EventArgs e)
        {
            comenzarCarga();
        }

        private void txtPesos1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) &&
              e.KeyChar != (char)Keys.Back &&
              e.KeyChar != '.' &&
              e.KeyChar != ','
              )
            {
                e.Handled = true;
            }
            else
            {
                if (e.KeyChar == '.')
                {
                    if (((TextBox)sender).Text.Contains('.'))
                        e.Handled = true;
                    else
                        e.Handled = false;
                }
                if (e.KeyChar == ',')
                {
                    if (((TextBox)sender).Text.Contains('.'))
                        e.Handled = true;
                    else
                        e.Handled = false;
                }
            }
        }

        private void txtPesos2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) &&
                e.KeyChar != (char)Keys.Back &&
                e.KeyChar != '.' &&
                e.KeyChar != ','
                )
            {
                e.Handled = true;
            }
            else
            {
                if (e.KeyChar == '.')
                {
                    if (((TextBox)sender).Text.Contains('.'))
                        e.Handled = true;
                    else
                        e.Handled = false;
                }
                if (e.KeyChar == ',')
                {
                    if (((TextBox)sender).Text.Contains('.'))
                        e.Handled = true;
                    else
                        e.Handled = false;
                }
            }
        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtPesos1_TextChanged(object sender, EventArgs e)
        {
            Sumar();
        }

        private void dgvFunciones_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Convert.ToInt32(dgvForma1.CurrentRow.Cells["id_tipo_forma_pago"].Value) != Convert.ToInt32(Formas_de_pago.Tipos_Formas_Pagos.EFECTIVO))
            {
                if (e.ColumnIndex == 2)
                {
                    dgvForma1.CurrentCell.ReadOnly = true;
                    frmCobradoresFormasPagos oCobradoresPagos = new frmCobradoresFormasPagos();

                    oCobradoresPagos.dtDetalles = dtDetalles;
                    oCobradoresPagos.idForma = Convert.ToInt32(dgvForma1.CurrentRow.Cells["id_forma_pago"].Value);
                    oCobradoresPagos.forma = dgvForma1.CurrentRow.Cells["forma_pago"].Value.ToString();
                    frmPopUp oPop = new frmPopUp();
                    oPop.Formulario = oCobradoresPagos;
                    oPop.Maximizar = false;
                    if (oPop.ShowDialog() == DialogResult.OK)
                    {
                        dtDetalles = oCobradoresPagos.dtDetalles;
                        decimal totalForma = 0;
                        foreach (DataRow item in dtDetalles.Rows)
                        {
                            if ((Convert.ToInt32(item["id_forma_pago"]) == Convert.ToInt32(dgvForma1.CurrentRow.Cells["id_forma_pago"].Value)) && (Convert.ToInt32(item["id_forma_pago"]) != 1))
                                totalForma = totalForma + Convert.ToDecimal(item["monto"]);
                        }
                        dgvForma1.CurrentRow.Cells["monto"].Value = totalForma;
                        dgvForma1.ClearSelection();
                    }
                }

            }
        }

        //private void dgv1_CellClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    foreach (DataGridViewRow item in dgv1.Rows)
        //    {
        //        item.Cells["activo"].Value = 0;
        //    }
        //    dgv1.CurrentCell.ReadOnly = false;
        //    btnBusca.Enabled = true;
        //    dgv1.CurrentRow.Cells["activo"].Value = 1;
        //}

        private void btnBusca_Click(object sender, EventArgs e)
        {


        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {

        }

        private void dgvForma2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Convert.ToInt32(dgvForma2.CurrentRow.Cells["id_tipo_forma_pago"].Value) != Convert.ToInt32(Formas_de_pago.Tipos_Formas_Pagos.EFECTIVO))
            {
                if (e.ColumnIndex == 2)
                {
                    dgvForma2.CurrentCell.ReadOnly = true;
                    frmCobradoresFormasPagos oCobradoresPagos = new frmCobradoresFormasPagos();
                    oCobradoresPagos.dtDetalles = dtDetalles2;
                    oCobradoresPagos.idForma = Convert.ToInt32(dgvForma2.CurrentRow.Cells["id_forma_pago"].Value);
                    oCobradoresPagos.forma = dgvForma2.CurrentRow.Cells["forma_pago"].Value.ToString();
                    frmPopUp oPop = new frmPopUp();
                    oPop.Formulario = oCobradoresPagos;
                    oPop.Maximizar = false;
                    if (oPop.ShowDialog() == DialogResult.OK)
                    {
                        dtDetalles2 = oCobradoresPagos.dtDetalles;
                        decimal totalForma = 0;
                        foreach (DataRow item in dtDetalles2.Rows)
                        {
                            if ((Convert.ToInt32(item["id_forma_pago"]) == Convert.ToInt32(dgvForma2.CurrentRow.Cells["id_forma_pago"].Value)) && (Convert.ToInt32(item["id_forma_pago"]) != 1))
                                totalForma = totalForma + Convert.ToDecimal(item["monto"]);
                        }
                        dgvForma2.CurrentRow.Cells["monto"].Value = totalForma;
                        dgvForma2.ClearSelection();
                    }
                }

            }
        }

        private void dgvForma1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            Sumar();
        }

        private void dgvForma1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                idFormaActual = Convert.ToInt32(dgvForma1.CurrentRow.Cells["id_forma_pago"].Value);
            }
            catch { }
        }

        private void dgvForma2_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvForma2_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            Sumar();

        }

        private void pnlSuperior_Paint(object sender, PaintEventArgs e)
        {

        }

        private void boton1_Click(object sender, EventArgs e)
        {
            txtReciboDesde1.ReadOnly = false;
            txtReciboDesde2.ReadOnly = false;


        }

        private void txtPesos2_TextChanged(object sender, EventArgs e)
        {
            Sumar();

        }

        private void txtPesos1_ValueChanged(object sender, EventArgs e)
        {
            Sumar();
        }

        private void txtPesos2_ValueChanged(object sender, EventArgs e)
        {
            Sumar();
        }

        private void txtReciboHasta1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
            }
        }

        private void cboCobradores_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                id = Convert.ToInt32(cboCobradores.SelectedValue);
                drDatosComprobanteBlanco = oComprobante_Tipo.GetNumeracion(Convert.ToInt32(Comprobantes_Tipo.Tipo.RECIBO_COBRADOR), id);
                drDatosComprobanteNegro = oComprobante_Tipo.GetNumeracion(Convert.ToInt32(Comprobantes_Tipo.Tipo.RECIBO_COBRADOR_INTERNO), id);
                id_punto_venta = Convert.ToInt32(drDatosComprobanteNegro["idPuntoVenta"]);
                num_punto_venta = Convert.ToInt32(drDatosComprobanteNegro["numPuntoVenta"]);

                NroRecibo = Convert.ToInt32(drDatosComprobanteBlanco["numComprobante"]);
                txtReciboDesde1.Text = NroRecibo.ToString();

                NroRecibo = Convert.ToInt32(drDatosComprobanteNegro["numComprobante"]);
                txtReciboDesde2.Text = NroRecibo.ToString();

                txtReciboHasta1.Text = "0";
                txtReciboHasta2.Text = "0";

                txtReciboDesde1.Focus();

            }
            catch { }
        }

        private void txtReciboHasta2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            desde1 = Convert.ToInt32(txtReciboDesde1.Text);
            desde2 = Convert.ToInt32(txtReciboDesde2.Text);
            hasta1 = Convert.ToInt32(txtReciboHasta1.Text);
            hasta2 = Convert.ToInt32(txtReciboHasta2.Text);

            ocaja_diaria.Id = 0;
            ocaja_diaria.Id_Personal = Personal.Id_Login;
            ocaja_diaria.Id_Puntos_cobros = id;
            ocaja_diaria.Id_Cierre_General = 0;
            ocaja_diaria.Numero = 0;
            ocaja_diaria.Importe_cuenta1 = caja1;
            ocaja_diaria.Importe_cuenta2 = caja2;
            ocaja_diaria.Recibo_cuenta1_desde = desde1;
            ocaja_diaria.Recibo_cuenta1_hasta = hasta1;

            ocaja_diaria.Recibo_cuenta2_desde = desde2;
            ocaja_diaria.Recibo_cuenta2_hasta = hasta2;

            ocaja_diaria.Fecha = DateTime.Now;//// .Today;
            string salida = "";
            idCajaNueva = ocaja_diaria.Guardar(ocaja_diaria,out salida);

            foreach (DataRow item in dtPagosCuenta1.Rows)
            {
                int idFormaPago = Convert.ToInt32(item["id_forma_pago"]);
                if (idFormaPago == Convert.ToInt32(Formas_de_pago.Tipos_Formas_Pagos.EFECTIVO))
                {
                    decimal monto = Convert.ToDecimal(item["monto"]);
                    if (monto > 0)
                    {
                        DataRow drEfectivo = dtDetalles.NewRow();
                        drEfectivo["id_forma_pago"] = idFormaPago;
                        drEfectivo["monto"] = monto;
                        drEfectivo["id"] = dtDetalles.Rows.Count + 1;
                        drEfectivo["cod_usu"] = 0;
                        drEfectivo["forma"] = "";
                        drEfectivo["borrado"] = 0;
                        drEfectivo["id_usu"] = 0;
                        drEfectivo["activo"] = 0;
                        drEfectivo["banco"] = "";
                        drEfectivo["sucursal"] = "";
                        drEfectivo["numero"] = "0";
                        drEfectivo["fecha_comp"] = DateTime.Now;
                        drEfectivo["fecha_acre"] = DateTime.Now;
                        drEfectivo["titular"] = "";
                        drEfectivo["cuenta"] = "";
                        drEfectivo["cuit"] = "";
                        dtDetalles.Rows.Add(drEfectivo);
                    }
                }
            }


            if ((hasta1 == 0) || (hasta1 > desde1))
            {
                if (hasta1 != 0)
                {
                    fecha_hoy = DateTime.Now;
                    oComprobante_Tipo.SetNumeracion(id_punto_venta, Convert.ToInt32(Comprobantes_Tipo.Tipo.RECIBO_COBRADOR), Convert.ToInt32(txtReciboHasta1.Text), Convert.ToInt32(txtReciboHasta1.Text));
                    NumeroString_cuenta1 = num_punto_venta.ToString().PadLeft(4, '0') + "-" + desde1.ToString().PadLeft(8, '0') + "/" + hasta1.ToString().PadLeft(8, '0');
                    //Cuenta1
                    //Comprobante
                    oComprobantes.Id_Usuarios = 0;
                    oComprobantes.Numero = desde1;
                    oComprobantes.Id_Usuarios_Locaciones = 0;
                    oComprobantes.Fecha = fecha_hoy;
                    oComprobantes.Punto_Venta = id_punto_venta;
                    oComprobantes.Id_Comprobantes_Tipo = Convert.ToInt32(Comprobantes_Tipo.Tipo.RECIBO_COBRADOR);
                    oComprobantes.Importe = caja1;
                    id_comprobante = oComprobantes.Guardar(oComprobantes);
                    //usuario_cta_cte_recibos
                    oUsuarios_CtaCte_Recibos.Id_Usuarios = 0;
                    oUsuarios_CtaCte_Recibos.Id_Usuarios_Locacion = 0;
                    oUsuarios_CtaCte_Recibos.Id_Comprobantes = id_comprobante;
                    oUsuarios_CtaCte_Recibos.Numero = desde1;
                    oUsuarios_CtaCte_Recibos.Fecha_Movimiento = fecha_hoy;
                    oUsuarios_CtaCte_Recibos.Importe_Saldo = caja1;
                    oUsuarios_CtaCte_Recibos.Importe_Final = caja1;
                    oUsuarios_CtaCte_Recibos.Estado = 0;
                    oUsuarios_CtaCte_Recibos.Id_Caja_Diaria = idCajaNueva;
                    oUsuarios_CtaCte_Recibos.Numero_Muestra = NumeroString_cuenta1;
                    oUsuarios_CtaCte_Recibos.Id_Personal = Personal.Id_Login;
                    oUsuarios_CtaCte_Recibos.Id_Puntos_Cobro = Puntos_Cobros.Id_Punto;
                    oUsuarios_CtaCte_Recibos.Numero_Hasta = hasta1;
                    oUsuarios_CtaCte_Recibos.Id_Cobrador = id;
                    oUsuarios_CtaCte_Recibos.Importe_Rendido = 0;
                    oUsuarios_CtaCte_Recibos.Recibo_Tipo = 1;
                    DataTable dtPagadoCuenta1 = new DataTable();
                    DataView dvPagadoCuenta1 = new DataView(dtPagosCuenta1);
                    dvPagadoCuenta1.RowFilter = "monto>0";
                    dtPagadoCuenta1 = dvPagadoCuenta1.ToTable();
                    oUsuarios_CtaCte_Recibos.guardar(oUsuarios_CtaCte_Recibos, 1, dtDetalles);


                    MessageBox.Show("Datos de la cuenta 1 guardados correctamente");
                    txtReciboDesde1.Text = txtReciboHasta1.Text;
                    caja1 = 0;
                }
            }
            else
            {
                MessageBox.Show("El numero de recibo de la cuenta 1 no puede ser menor que " + desde1.ToString());
            }

            if ((hasta2 == 0) || (hasta2 > desde2))
            {
                if (hasta2 != 0)
                {
                    foreach (DataRow item in dtPagosCuenta2.Rows)
                    {
                        int idFormaPago = Convert.ToInt32(item["id_forma_pago"]);
                        if (idFormaPago == Convert.ToInt32(Formas_de_pago.Tipos_Formas_Pagos.EFECTIVO))
                        {
                            decimal monto = Convert.ToDecimal(item["monto"]);
                            if (monto > 0)
                            {
                                DataRow drEfectivo = dtDetalles2.NewRow();
                                drEfectivo["id_forma_pago"] = idFormaPago;
                                drEfectivo["monto"] = monto;
                                drEfectivo["id"] = dtDetalles.Rows.Count + 1;
                                drEfectivo["cod_usu"] = 0;
                                drEfectivo["forma"] = "";
                                drEfectivo["borrado"] = 0;
                                drEfectivo["id_usu"] = 0;
                                drEfectivo["activo"] = 0;
                                drEfectivo["banco"] = "";
                                drEfectivo["sucursal"] = "";
                                drEfectivo["numero"] = "0";
                                drEfectivo["fecha_comp"] = DateTime.Now;
                                drEfectivo["fecha_acre"] = DateTime.Now;
                                drEfectivo["titular"] = "";
                                drEfectivo["cuenta"] = "";
                                drEfectivo["cuit"] = "";
                                dtDetalles2.Rows.Add(drEfectivo);
                            }
                        }
                    }
                    fecha_hoy = DateTime.Now;
                    oComprobante_Tipo.SetNumeracion(id_punto_venta, Convert.ToInt32(Comprobantes_Tipo.Tipo.RECIBO_COBRADOR_INTERNO), Convert.ToInt32(txtReciboHasta2.Text), Convert.ToInt32(txtReciboHasta2.Text));
                    NumeroString_cuenta2 = num_punto_venta.ToString().PadLeft(4, '0') + "-" + desde2.ToString().PadLeft(8, '0') + "/" + hasta2.ToString().PadLeft(8, '0');
                    //Cuenta2
                    //Comprobante
                    oComprobantes.Id_Usuarios = 0;
                    oComprobantes.Numero = desde2;
                    oComprobantes.Id_Usuarios_Locaciones = 0;
                    oComprobantes.Fecha = fecha_hoy;
                    oComprobantes.Punto_Venta = id_punto_venta;
                    oComprobantes.Id_Comprobantes_Tipo = Convert.ToInt32(Comprobantes_Tipo.Tipo.RECIBO_COBRADOR_INTERNO);
                    oComprobantes.Importe = caja2;
                    id_comprobante = oComprobantes.Guardar(oComprobantes);
                    //usuario_cta_cte_recibos
                    oUsuarios_CtaCte_Recibos.Id_Usuarios = 0;
                    oUsuarios_CtaCte_Recibos.Id_Usuarios_Locacion = 0;
                    oUsuarios_CtaCte_Recibos.Id_Comprobantes = id_comprobante;
                    oUsuarios_CtaCte_Recibos.Numero = desde2;
                    oUsuarios_CtaCte_Recibos.Fecha_Movimiento = fecha_hoy;
                    oUsuarios_CtaCte_Recibos.Importe_Saldo = caja2;
                    oUsuarios_CtaCte_Recibos.Importe_Final = caja2;
                    oUsuarios_CtaCte_Recibos.Estado = 0;
                    oUsuarios_CtaCte_Recibos.Id_Caja_Diaria = idCajaNueva;
                    oUsuarios_CtaCte_Recibos.Numero_Muestra = NumeroString_cuenta2;
                    oUsuarios_CtaCte_Recibos.Id_Personal = Personal.Id_Login;
                    oUsuarios_CtaCte_Recibos.Id_Puntos_Cobro = Puntos_Cobros.Id_Punto;
                    oUsuarios_CtaCte_Recibos.Numero_Hasta = hasta2;
                    oUsuarios_CtaCte_Recibos.Id_Cobrador = id;
                    oUsuarios_CtaCte_Recibos.Importe_Rendido = 0;
                    oUsuarios_CtaCte_Recibos.Recibo_Tipo = 1;
                    DataTable dtPagadoCuenta2 = new DataTable();
                    DataView dvPagadoCuenta2 = new DataView(dtPagosCuenta2);
                    dvPagadoCuenta2.RowFilter = "monto>0";
                    dtPagadoCuenta2 = dvPagadoCuenta2.ToTable();
                    oUsuarios_CtaCte_Recibos.guardar(oUsuarios_CtaCte_Recibos, 2, dtDetalles2);


                    MessageBox.Show("Datos de la cuenta 2 guardados correctamente");
                    txtReciboDesde2.Text = txtReciboHasta2.Text;
                    caja2 = 0;
                }
            }
            else
            {
                MessageBox.Show("El numero de recibo de la cuenta 1 no puede ser menor que " + desde1.ToString());
            }
            //NumeroString_cuenta2= num_punto_venta.ToString().PadLeft(4, '0') + "-" + desde2.ToString().PadLeft(8, '0') + "/" + hasta2.ToString().PadLeft(8, '0');

            //if ((hasta2 == 0) || (hasta2 > desde2))
            //{
            //    if (hasta2 != 0)
            //    {
            //         //Cuenta2
            //         //Comprobante
            //         oComprobantes.Id_Usuarios = 0;
            //         oComprobantes.Numero = desde2;
            //         oComprobantes.Id_Usuarios_Locaciones = 0;
            //         oComprobantes.Fecha = fecha_hoy;
            //         oComprobantes.Punto_Venta = id_punto_venta;
            //         oComprobante_Tipo.SetNumeracion(id_punto_venta, Convert.ToInt32(Comprobantes_Tipo.Tipo.RECIBO_COBRADOR_INTERNO), Convert.ToInt32(txtReciboHasta2.Text), Convert.ToInt32(txtReciboHasta2.Text));

            //         oComprobantes.Id_Comprobantes_Tipo = Convert.ToInt32(Comprobantes_Tipo.Tipo.RECIBO_COBRADOR_INTERNO);
            //         oComprobantes.Importe = dtpPesos2.Value;
            //         id_comprobante = oComprobantes.Guardar(oComprobantes);
            //         //usuario_cta_cte_recibos
            //         oUsuarios_CtaCte_Recibos.Id_Usuarios_Locacion = 0;

            //         oUsuarios_CtaCte_Recibos.Id_Comprobantes = id_comprobante;
            //         oUsuarios_CtaCte_Recibos.Numero = desde2;
            //         oUsuarios_CtaCte_Recibos.Fecha_Movimiento = fecha_hoy;
            //         oUsuarios_CtaCte_Recibos.Id_Usuarios = 0;
            //         oUsuarios_CtaCte_Recibos.Importe_Saldo = caja2;
            //         oUsuarios_CtaCte_Recibos.Importe_Final = caja2;
            //         oUsuarios_CtaCte_Recibos.Estado = 0;
            //         oUsuarios_CtaCte_Recibos.Id_Caja_Diaria = 0;
            //         oUsuarios_CtaCte_Recibos.Numero_Muestra = NumeroString_cuenta2;
            //         oUsuarios_CtaCte_Recibos.Id_Personal = Personal.Id_Punto_Login;
            //         oUsuarios_CtaCte_Recibos.Id_Puntos_Cobro = Puntos_Cobros.Id_Punto;
            //         oUsuarios_CtaCte_Recibos.Numero_Hasta = hasta2;
            //         oUsuarios_CtaCte_Recibos.Id_Cobrador = id;
            //         oUsuarios_CtaCte_Recibos.Importe_Rendido = 0;
            //         oUsuarios_CtaCte_Recibos.Recibo_Tipo = 1;
            //         oUsuarios_CtaCte_Recibos.guardar(oUsuarios_CtaCte_Recibos, 1);
            //         MessageBox.Show("Datos de la cuenta 2 guardados correctamente");
            //         txtReciboDesde2.Text = txtReciboHasta2.Text;
            //         dtpPesos2.Value = 0;
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("El numero de recibo de la cuenta 2 no puede ser menor que " + desde2.ToString());
            //}

            //imrpime caja diaria
            ImprimirCaja();
        }
        private void ImprimirCaja()
        {
            Impresiones.Impresion oImpresion = new Impresiones.Impresion();
            DataTable dtusuarios_recibos_1 = ocaja_diaria.ListarDetallesRecibosAVC(Puntos_Cobros.Id_Punto, idCajaNueva, 1,false); ////ocaja_diaria.trae_ultimo_recibos(1, 1);
            DataTable dtusuarios_recibos_2 = ocaja_diaria.ListarDetallesRecibosAVC(Puntos_Cobros.Id_Punto, idCajaNueva, 2, false); ////ocaja_diaria.trae_ultimo_recibos(1, 1);
            DataTable dtformasCta1 = ocaja_diaria.Listar_Recibos_Det(Puntos_Cobros.Id_Punto, 0, idCajaNueva, 1); ////ocaja_diaria.trae_ultimo_recibos(1, 1);
            DataTable dtformasCta2 = ocaja_diaria.Listar_Recibos_Det(Puntos_Cobros.Id_Punto, 0, idCajaNueva, 2); ////ocaja_diaria.trae_ultimo_recibos(1, 1);

            DataTable dtDatosCaja = ocaja_diaria.GetEstructuraDatosCajaDiariaImpresion();
            DataTable dtDatosCaja2 = ocaja_diaria.GetEstructuraDatosCajaDiariaImpresion();
            DataTable dtDatosFormasPago = ocaja_diaria.GetEstructuraDatosFormasPagoImpresion();
            DataTable dtDatosFormasPago2 = ocaja_diaria.GetEstructuraDatosFormasPagoImpresion();



            DataRow drAux = dtDatosCaja.NewRow();
            drAux["recibo_desde"] = 0;
            drAux["recibo_hasta"] = 0;
            drAux["cant_total_recibos"] = 0;
            drAux["monto_total_recibos"] = 0;
            drAux["cant_total_anulados"] = 0;
            drAux["monto_total_anulados"] = 0;
            drAux["cant_final_recibos"] = 0;
            drAux["monto_final_recibos"] = 0;
            drAux["id_personal"] = Personal.Id_Login;
            drAux["personal"] = Personal.Name_Login;
            drAux["punto_cobro"] = id;
            drAux["numero_caja"] = "Caja cerrada - CUENTA 1";
            if (dtusuarios_recibos_1.Rows.Count > 0)
            {
                drAux["recibo_desde"] = Convert.ToInt32(dtusuarios_recibos_1.Rows[0]["numero"]);
                drAux["recibo_hasta"] = Convert.ToInt32(dtusuarios_recibos_1.Rows[0]["numero_hasta"]);
                drAux["cant_total_recibos"] = dtusuarios_recibos_1.Compute("count(Importe_recibo)", string.Empty);
                drAux["monto_total_recibos"] = dtusuarios_recibos_1.Compute("SUM(importe_recibo)", string.Empty);
                drAux["cant_total_anulados"] = dtusuarios_recibos_1.Compute("count(Importe_recibo)", "borrado=1");
                if (Convert.ToInt32(drAux["cant_total_anulados"]) > 0)
                    drAux["monto_total_anulados"] = dtusuarios_recibos_1.Compute("sum(Importe_recibo)", "borrado=1");
                else
                    drAux["monto_total_anulados"] = 0;
                drAux["cant_final_recibos"] = Convert.ToInt32(drAux["cant_total_recibos"]) - Convert.ToInt32(drAux["cant_total_anulados"]);
                drAux["monto_final_recibos"] = Convert.ToDecimal(drAux["monto_total_recibos"]) - Convert.ToDecimal(drAux["monto_total_anulados"]);
            }

            dtDatosCaja.Rows.Add(drAux);


            if (dtformasCta1.Rows.Count > 0)
            {
                foreach (DataRow formaPago in dtformasCta1.Rows)
                {
                    drAux = dtDatosFormasPago.NewRow();
                    drAux["monto"] = 0;
                    drAux["forma_pago"] = formaPago["forma"];
                    drAux["cantidad"] = dtPagosCuenta1.Select(String.Format("id_forma_pago={0}", formaPago["id_formas_de_pago"].ToString())).Length;
                    if (Convert.ToInt32(drAux["cantidad"]) > 0)
                        drAux["monto"] = formaPago["importe"];
                    dtDatosFormasPago.Rows.Add(drAux);
                }
            }
            oImpresion.ImprimirInformeCajaDiaria(dtDatosCaja, dtDatosFormasPago);


            //------cuenta 2

            DataRow drAux2 = dtDatosCaja2.NewRow();
            drAux2["recibo_desde"] = 0;
            drAux2["recibo_hasta"] = 0;
            drAux2["cant_total_recibos"] = 0;
            drAux2["monto_total_recibos"] = 0;
            drAux2["cant_total_anulados"] = 0;
            drAux2["monto_total_anulados"] = 0;
            drAux2["cant_final_recibos"] = 0;
            drAux2["monto_final_recibos"] = 0;
            drAux2["id_personal"] = Personal.Id_Login;
            drAux2["personal"] = Personal.Name_Login;
            drAux2["punto_cobro"] = id;
            drAux2["numero_caja"] = "Caja cerrada - CUENTA 2";
            if (dtusuarios_recibos_2.Rows.Count > 0)
            {
                drAux2["recibo_desde"] = Convert.ToInt32(dtusuarios_recibos_2.Rows[0]["numero"]);
                drAux2["recibo_hasta"] = Convert.ToInt32(dtusuarios_recibos_2.Rows[0]["numero_hasta"]);
                drAux2["cant_total_recibos"] = dtusuarios_recibos_2.Compute("count(Importe_recibo)", string.Empty);
                drAux2["monto_total_recibos"] = dtusuarios_recibos_2.Compute("SUM(importe_recibo)", string.Empty);
                drAux2["cant_total_anulados"] = dtusuarios_recibos_2.Compute("count(Importe_recibo)", "borrado=1");
                if (Convert.ToInt32(drAux2["cant_total_anulados"]) > 0)
                    drAux2["monto_total_anulados"] = dtusuarios_recibos_2.Compute("sum(Importe_recibo)", "borrado=1");
                else
                    drAux2["monto_total_anulados"] = 0;
                drAux2["cant_final_recibos"] = Convert.ToInt32(drAux2["cant_total_recibos"]) - Convert.ToInt32(drAux2["cant_total_anulados"]);
                drAux2["monto_final_recibos"] = Convert.ToDecimal(drAux2["monto_total_recibos"]) - Convert.ToDecimal(drAux2["monto_total_anulados"]);
            }

            dtDatosCaja2.Rows.Add(drAux2);


            if (dtformasCta2.Rows.Count > 0)
            {
                foreach (DataRow formaPago2 in dtformasCta2.Rows)
                {
                    drAux2 = dtDatosFormasPago2.NewRow();
                    drAux2["monto"] = 0;
                    drAux2["forma_pago"] = formaPago2["forma"];
                    drAux2["cantidad"] = dtPagosCuenta2.Select(String.Format("id_forma_pago={0}", formaPago2["id_formas_de_pago"].ToString())).Length;
                    if (Convert.ToInt32(drAux2["cantidad"]) > 0)
                        drAux2["monto"] = formaPago2["importe"];
                    dtDatosFormasPago2.Rows.Add(drAux2);
                }
            }
            oImpresion.ImprimirInformeCajaDiaria(dtDatosCaja2, dtDatosFormasPago2);
        }

    }
}
