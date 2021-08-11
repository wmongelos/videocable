using CapaNegocios;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class frmUsuariosPagos : Form
    {
        private Formas_de_pago oFormas_De_Pago = new Formas_de_pago();
        private Puntos_Cobros oPuntoCobro = new Puntos_Cobros();
        private DataTable dtTipos_De_Pago; // efectivo ,tarjeta etc
        private DataTable dtFormas_De_Pago_Muestra; // tabka que muestra en las formas de pago
        private DataTable dtFormas_De_Pago;
        private DataTable dtusuarios_Servicios;
        private DataTable dtPuntosCobro;
        private DataTable dtDatosUsuario = new DataTable();
        private DataTable dtAcciones; //servicios a reconectar
        public Int32 viene; //si es 1 viene de ctacte_recibos, si es 2 viene de cajaDetalle
        public Int32 nroPuntoVenta = 0;
        private Partes oPartes = new Partes();
        private Partes_Solicitudes oPartes_Fallas = new Partes_Solicitudes();
        private Servicios oServicios = new Servicios();

        private Configuracion oConfig = new Configuracion();
        Aplicaciones_Externas oAppExterna = new Aplicaciones_Externas();
        public DataTable dtDetalleRecibo = new DataTable();
        private GPS oGps = new GPS();
        private bool edicionFormaDePago;

        private Usuarios_Servicios oUsuarurios_Servicios = new Usuarios_Servicios();
        private int id_Usuario = 0, id_Locacion = 0, tipoCondicionIva;
        public int cuenta = 1, configAgenda = 0;
        public Decimal Total_Recibo = 0;
        public Comprobantes_Tipo.Tipo tipoComprobante;


        public frmUsuariosPagos(bool edicion, decimal vtotal, int idl, int idu, int cuentaActual = 1)
        {
            InitializeComponent();

            if (cuentaActual == 1)
            {
                lbCuenta.Visible = false;
            }
            else if (cuentaActual == 2)
            {
                lbCuenta.Visible = true;
            }
            this.cuenta = cuentaActual;

            this.edicionFormaDePago = edicion;
            id_Usuario = idu;
            id_Locacion = idl;
            dtTipos_De_Pago = new DataTable();
            dtTipos_De_Pago.Columns.Add("tipo", typeof(string)); // ()
            dtTipos_De_Pago.Rows.Add("EFECTIVO");
            dtTipos_De_Pago.Rows.Add("TARJETA CREDITO");
            dtTipos_De_Pago.Rows.Add("TARJETA DEBITO");
            dtTipos_De_Pago.Rows.Add("TRANSFERENCIA");
            dtTipos_De_Pago.Rows.Add("CBU");
            dtTipos_De_Pago.Rows.Add("CHEQUE");

            dtFormas_De_Pago_Muestra = new DataTable();
            dtFormas_De_Pago_Muestra.Columns.Add("tipo", typeof(string));
            dtFormas_De_Pago_Muestra.Columns.Add("nombre", typeof(string));
            dtFormas_De_Pago_Muestra.Columns.Add("id", typeof(Int32));
            dtFormas_De_Pago_Muestra.Columns.Add("tipo_oculto", typeof(string));
            dtFormas_De_Pago_Muestra.Columns.Add("Trabaja_Conciliacion", typeof(Int32));
            dtFormas_De_Pago_Muestra.Columns.Add("Trabaja_Validacion", typeof(Int32));

            dtFormas_De_Pago = oFormas_De_Pago.Listar();
            limpia();
            dgvforma.DataSource = dtFormas_De_Pago_Muestra;
            txttotal.Text = vtotal.ToString();
            dtusuarios_Servicios = oUsuarurios_Servicios.ListarServicios(id_Usuario, id_Locacion);
            dgvUsuarios_servicios.DataSource = dtusuarios_Servicios;

            dtDetalleRecibo = new DataTable();
            dtDetalleRecibo.Columns.Add("Nombre", typeof(String));
            dtDetalleRecibo.Columns.Add("Importe", typeof(Decimal));
            dtDetalleRecibo.Columns.Add("Cliente", typeof(string));
            dtDetalleRecibo.Columns.Add("Cuenta", typeof(string));
            dtDetalleRecibo.Columns.Add("Cuit", typeof(string));
            dtDetalleRecibo.Columns.Add("Banco", typeof(string));
            dtDetalleRecibo.Columns.Add("Sucursal", typeof(string));
            dtDetalleRecibo.Columns.Add("Fecha_Comprobante", typeof(string));
            dtDetalleRecibo.Columns.Add("Fecha_Acreditacion", typeof(string));
            dtDetalleRecibo.Columns.Add("Numero", typeof(string));
            dtDetalleRecibo.Columns.Add("Id_formas_de_pago", typeof(Int32));
            dtDetalleRecibo.Columns.Add("Id_usuarios_locaciones", typeof(Int32));
            dtDetalleRecibo.Columns.Add("Conciliado", typeof(Int32));
            dgvdetallerecibos.DataSource = dtDetalleRecibo;

            arma_formas_de_pago();
        }

        private void arma_formas_de_pago()
        {

            foreach (DataRow dr1 in dtTipos_De_Pago.Rows)
            {

                int cuantos = 0;
                foreach (DataRow dr in dtFormas_De_Pago.Rows)
                {

                    if (dr["tipo_de_forma"].ToString() == dr1["tipo"].ToString())
                    {

                        if (cuantos == 0)
                        {
                            cuantos = 1;
                            dtFormas_De_Pago_Muestra.Rows.Add(dr["tipo_de_forma"].ToString(), dr["Nombre"].ToString(), Convert.ToInt32(dr["id"].ToString()), dr["tipo_de_forma"].ToString(), Convert.ToInt32(dr["trabaja_Conciliacion"]), Convert.ToInt32(dr["Trabaja_Validacion"].ToString()));
                        }
                        else
                        {
                            dtFormas_De_Pago_Muestra.Rows.Add("", dr["Nombre"].ToString(), Convert.ToInt32(dr["id"].ToString()), dr["tipo_de_forma"].ToString(), Convert.ToInt32(dr["trabaja_Conciliacion"].ToString()), Convert.ToInt32(dr["Trabaja_Validacion"].ToString()));
                        }
                    }

                }
            }
            dgvforma.DataSource = dtFormas_De_Pago_Muestra;/// dtforma;
            dgvforma.Columns["tipo"].Width = 100;
            dgvforma.Columns["nombre"].Width = 100;

            dgvforma.Columns["id"].Visible = false;
            dgvforma.Columns["tipo_oculto"].Visible = false;
            dgvforma.Columns["trabaja_validacion"].Visible = false;
            dgvforma.Columns["trabaja_conciliacion"].Visible = false;


            ///            DataGridViewButtonColumn ctotal = new DataGridViewButtonColumn();
            DataGridViewLinkColumn ctotal = new DataGridViewLinkColumn();

            ctotal.Text = "Agregar";
            ctotal.DataPropertyName = "Agregar";
            ctotal.Name = "ctotal";
            ctotal.LinkColor = Color.Blue;
            ctotal.VisitedLinkColor = Color.Blue;
            ctotal.UseColumnTextForLinkValue = true;
            ctotal.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ctotal.Width = 100;

            //ctotal.Name = "ctotal";
            ctotal.HeaderText = "Pago Total";
            dgvforma.Columns.Add(ctotal);


            dgvforma.Columns["ctotal"].Width = 80;


            for (int i = 0; i < dgvUsuarios_servicios.Columns.Count; i++)
                dgvUsuarios_servicios.Columns[i].Visible = false;

            dgvUsuarios_servicios.Columns["servicio"].Visible = true;
            dgvUsuarios_servicios.Columns["estado"].Visible = true;

            dtusuarios_Servicios.Columns.Add("sugerencia", typeof(string));


            if (dtusuarios_Servicios.Rows.Count > 0)
            {
                foreach (DataRow dr in dtusuarios_Servicios.Rows)
                {
                    dr["sugerencia"] = "Conectar servicio";

                }
            }

            for (int i = 0; i < dgvdetallerecibos.Columns.Count; i++)
                dgvdetallerecibos.Columns[i].Visible = false;

            dgvdetallerecibos.Columns["nombre"].Visible = true;
            dgvforma.Columns["nombre"].Width = 150;
            dgvdetallerecibos.Columns["importe"].Visible = true;
            dgvdetallerecibos.Columns["importe"].DefaultCellStyle.Format = "c";
            dgvdetallerecibos.Columns["Importe"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            ///   dgvdetallerecibos.Columns["cliente"].Visible = true;

            ///            dgvforma.ReadOnly = false;


        }

        private void limpia()
        {
            txtnombre.Text = "";
            txtcliente.Text = "";
            spImporte.Text = "0";
            txtcuenta.Text = "";
            txtcuit.Text = "";
            txtbanco.Text = "";
            txtsucursal.Text = "";
            txtnumero.Text = "0";

        }

        private void agregapago()
        {
            int Trabaja_Conciliacion = Convert.ToInt32(dgvforma.CurrentRow.Cells["Trabaja_Conciliacion"].Value.ToString());
            int Trabaja_Validacion = Convert.ToInt32(dgvforma.CurrentRow.Cells["Trabaja_Validacion"].Value.ToString());
            try
            {
                if (Trabaja_Validacion == 1 && (txtcliente.Text == "" || txtnumero.Text == ""))
                    MessageBox.Show("Debe validar los datos.");
                else
                {
                    dtDetalleRecibo.Rows.Add(dgvforma.CurrentRow.Cells["nombre"].Value.ToString(), decimal.Round(Convert.ToDecimal(spImporte.Text), 2), txtcliente.Text, txtcuenta.Text, txtcuit.Text, txtbanco.Text, txtsucursal.Text, txtfecha_acreditacion.Text.ToString(), txtfecha_comprobante.Text.ToString(), txtnumero.Text, Convert.ToInt32(dgvforma.CurrentRow.Cells["id"].Value.ToString()), id_Locacion, dgvforma.CurrentRow.Cells["Trabaja_Conciliacion"].Value.ToString());
                    suma();
                    Formas_de_pago oFormas = new Formas_de_pago();
                    DataTable dtDatosFormaPago = oFormas.ListarPorId(Convert.ToInt32(dgvforma.CurrentRow.Cells["id"].Value));
                    if (cuenta == 2)
                    {
                        if (Convert.ToInt32(dtDatosFormaPago.Rows[0]["id_tipo_de_forma"]) != (Int32)Formas_de_pago.Tipos_Formas_Pagos.EFECTIVO)
                            cuenta = 1;
                    }
                    txtcliente.Enabled = false;

                    txtcuenta.Enabled = false;
                    txtbanco.Enabled = false;
                    txtbanco.Enabled = false;
                    txtsucursal.Enabled = false;
                    txtfecha_acreditacion.Enabled = false;
                    txtfecha_comprobante.Enabled = false;
                    txtcuit.Enabled = false;
                    txtnumero.Enabled = false;
                    btnConfirma.Enabled = false;
                    pnPagos.Visible = false;
                }
            }
            catch (Exception c) { MessageBox.Show("Verifique los datos ingresados para la forma de pago." + c.ToString()); };

        }

        private void suma()
        {
            Decimal monto1 = 0;

            if (dtDetalleRecibo.Rows.Count > 0)
                monto1 = Convert.ToDecimal(dtDetalleRecibo.Compute("SUM(importe)", string.Empty));

            txtsaldo.Text = (Convert.ToDecimal(txttotal.Text) - Convert.ToDecimal(monto1)).ToString();
            txttotalpagos.Text = monto1.ToString();
            Total_Recibo = Convert.ToDecimal(monto1);
        }

        private void dgvforma_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgvforma.Columns[e.ColumnIndex].Name == "ctotal")
                eligio_pago();
        }

        private void eligio_pago()
        {

            limpia();
            string valor = dgvforma.CurrentRow.Cells["tipo_oculto"].Value.ToString();
            if (cuenta == 2 && valor != "EFECTIVO")
            {
                MessageBox.Show("No es posible la forma de pago seleccionada para un comprobante asignado a la cuenta 2\nPara seleccionar esta forma de pago es necesario cambiar a cuenta 1 (Ctrl + W)", "Mensajde del sistema");
                return;
            }

            spImporte.Text = (Convert.ToDecimal(txttotal.Text.ToString()) - Convert.ToDecimal(txttotalpagos.Text.ToString())).ToString();
            spImporte.Maximum = 9999999999;////Convert.ToDecimal(spImporte.Text.ToString());
            spImporte.Minimum = 0;
            if (Convert.ToDecimal(spImporte.Text) > 0)
            {
                if (chkHabilita.Checked == true)
                    Habilita_Datos_Pago(valor);

                else
                {

                    switch (valor)
                    {
                        case "EFECTIVO":
                            agregapago();
                            break;
                        case "TARJETA CREDITO":
                        case "TARJETA DEBITO":
                        case "CHEQUE":
                        case "CBU":
                        case "TRANSFERENCIA":
                            Habilita_Datos_Pago(valor);
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        private void Habilita_Datos_Pago(string tipoPago)
        {

            switch (tipoPago)
            {
                case "EFECTIVO":
                    txtcliente.Enabled = false;
                    txtcuenta.Enabled = false;
                    txtbanco.Enabled = false;
                    txtsucursal.Enabled = false;
                    txtfecha_acreditacion.Enabled = false;
                    txtfecha_comprobante.Enabled = false;
                    txtcuit.Enabled = false;
                    txtnumero.Enabled = false;
                    break;
                case "TARJETA CREDITO":
                    txtcliente.Enabled = true;
                    txtcuenta.Enabled = false;
                    txtbanco.Enabled = false;
                    txtsucursal.Enabled = false;
                    txtfecha_acreditacion.Enabled = false;
                    txtfecha_comprobante.Enabled = false;
                    txtcuit.Enabled = false;
                    txtnumero.Enabled = true;
                    break;
                case "TARJETA DEBITO":
                    txtcliente.Enabled = true;
                    txtcuenta.Enabled = false;
                    txtbanco.Enabled = false;
                    txtsucursal.Enabled = false;
                    txtfecha_acreditacion.Enabled = false;
                    txtfecha_comprobante.Enabled = false;
                    txtcuit.Enabled = false;
                    txtnumero.Enabled = true;
                    break;
                case "CHEQUE":

                    txtcliente.Enabled = true;
                    txtcuenta.Enabled = true;
                    txtbanco.Enabled = true;
                    txtsucursal.Enabled = true;
                    txtfecha_acreditacion.Enabled = true;
                    txtfecha_comprobante.Enabled = true;
                    txtcuit.Enabled = true;
                    txtnumero.Enabled = true;
                    break;
                case "CBU":

                    txtcliente.Enabled = true;
                    txtcuenta.Enabled = true;
                    txtbanco.Enabled = true;
                    txtsucursal.Enabled = true;
                    txtfecha_acreditacion.Enabled = true;
                    txtfecha_comprobante.Enabled = true;
                    txtcuit.Enabled = true;
                    txtnumero.Enabled = true;
                    break;
                case "TRANSFERENCIA":

                    txtcliente.Enabled = true;
                    txtcuenta.Enabled = true;
                    txtbanco.Enabled = true;
                    txtsucursal.Enabled = true;
                    txtfecha_acreditacion.Enabled = true;
                    txtfecha_comprobante.Enabled = true;
                    txtcuit.Enabled = true;
                    txtnumero.Enabled = true;
                    break;
                default:
                    break;
            }
            btnConfirma.Enabled = true;
            txtcliente.Focus();
            pnPagos.Visible = true;

        }

        private void btnConfirma_Click(object sender, EventArgs e)
        {
            agregapago();
        }

        #region

        private void servicios_a_reconectar()
        {
            DataView v1 = dtusuarios_Servicios.DefaultView;
            v1.RowFilter = string.Format("id_servicios_estados= {0} and id_servicios_modalidad<>{1} and id_servicios_modalidad<>{2}", Convert.ToInt16(Servicios.Servicios_Estados.CORTADO), Convert.ToInt16(Servicios._Modalidad.DIA), Convert.ToInt16(Servicios._Modalidad.PERIODO_CERRADO_POR_MES));
            dtAcciones = v1.ToTable();
            dtAcciones.Columns.Add("Elige", typeof(Boolean));
            foreach (DataRow dr in dtAcciones.Rows)
                dr["elige"] = true;
            dgvAcciones.DataSource = dtAcciones;
            for (int i = 0; i < dgvAcciones.Columns.Count; i++)
                dgvAcciones.Columns[i].Visible = false;
            dgvAcciones.Columns["servicio"].Visible = true;
            dgvAcciones.Columns["Elige"].Visible = true;
        }

        private void Ok_Click(object sender, EventArgs e)
        {
            reconexion();
            cierraok();
        }

        private void reconexion()
        {
            DataTable dtPartesParaHacer = oPartes.Get_Estructura_Partes();
            DataTable dtPartesGenerados = new DataTable();
            Servicios_Tipos oServiciosTipos = new Servicios_Tipos();
            configAgenda = oConfig.GetValor_N("Agenda_Trabajo");

            foreach (DataRow dr in dtAcciones.Rows)
            {
                DataTable drParteFalla = oPartes_Fallas.GetFallasPorTipoServYOp(Convert.ToInt32(dr["id_servicios_tipo"].ToString()), Convert.ToInt32(Partes.Partes_Operaciones.RECONEXION));

                if (drParteFalla.Rows.Count > 0)
                {

                    if (Convert.ToBoolean(dr["Elige"].ToString()) == true)
                    {
                        DataRow drDatosServicioTipo;
                        drDatosServicioTipo = oServiciosTipos.ListarDatosTipoServicio(Convert.ToInt32(dr["id_servicios_tipos"]));
                        DataRow drParte = dtPartesParaHacer.NewRow();
                        drParte["Id_Usuarios"] = this.id_Usuario;
                        drParte["Id_Usuarios_Servicios"] = Convert.ToInt32(dr["id"]);
                        drParte["Id_Servicios"] = Convert.ToInt32(dr["id_servicios"]);


                        drParte["Id_Servicios_Tipos"] = Convert.ToInt32(dr["id_servicios_tipos"]);
                        drParte["Id_Servicios_Grupos"] = Convert.ToInt32(drDatosServicioTipo["id_servicios_grupos"]);
                        drParte["Id_Usuarios_Locaciones"] = Convert.ToInt32(dr["id_usuarios_locaciones"]);
                        drParte["Id_Zonas"] = Convert.ToInt32(dr["id_zonas"]);
                        drParte["Id_Partes_Fallas"] = Convert.ToInt32(drParteFalla.Rows[0]["id"]);
                        drParte["Id_Partes_Soluciones"] = 0;
                        drParte["Id_Movil"] = 0;
                        drParte["Id_Tecnico"] = 0;
                        if (configAgenda == Convert.ToInt32(Agenda_Encabezado.Uso_agenda.TRABAJA_CON_AGENDA))
                        {
                            if (Convert.ToInt16(dr["corteautomatico"]) == Convert.ToInt16(Servicios._CorteAutomatico.NO))
                                drParte["Id_Partes_Estados"] = Convert.ToInt16(Partes.Partes_Estados.PENDIENTE_DE_ASIGNACION_DE_TECNICO);
                            else
                            {
                                drParte["Id_Partes_Estados"] = Convert.ToInt16(Partes.Partes_Estados.REALIZADO);
                                drParte["Fecha_Realizado"] = DateTime.Now;
                            }
                        }
                        else
                            drParte["Id_Partes_Estados"] = Convert.ToInt16(Partes.Partes_Estados.PENDIENTE_DE_ASIGNACION_DE_TECNICO);
                        drParte["Id_Operadores"] = this.id_Usuario;
                        drParte["Id_Areas"] = Personal.Id_Area;
                        drParte["Id_Locacion_Anterior"] = 0;
                        drParte["Id_Comprobantes"] = 0;
                        drParte["Fecha_Reclamo"] = DateTime.Now;
                        drParte["Fecha_Movil"] = new DateTime();
                        drParte["Fecha_Recibido"] = DateTime.Now;
                        drParte["Fecha_Programado"] = DateTime.Now;
                        drParte["Detalle_Falla"] = "";
                        drParte["Detalle_Solucion"] = "";
                        drParte["Tipo"] = "";
                        drParte["IdTipoEquipo"] = 0;
                        drParte["CorteAutomatico"] = Convert.ToInt32(dr["corteautomatico"]);


                        dtPartesParaHacer.Rows.Add(drParte);

                        //oPartes.Id_Usuarios = this.id_Usuario;
                        //oPartes.Id_Servicios = Convert.ToInt32(dr["id_servicios"].ToString());
                        //oPartes.Id_Usuarios_Servicios = Convert.ToInt32(dr["id"].ToString());

                        //oPartes.Id_Usuarios_Locaciones = Convert.ToInt32(dr["id_usuarios_locaciones"].ToString());
                        //oPartes.Id_Zonas = 1; ///Convert.ToInt32(dr["id_zonas"].ToString());
                        //oPartes.Id_Partes_Fallas =  Convert.ToInt32(drParteFalla.Rows[0]["id"].ToString());
                        //oPartes.Id_Partes_Soluciones = 0;
                        //oPartes.Id_Tecnico = 0;
                        //oPartes.Id_Movil = 0;
                        //oPartes.Id_Partes_Estados = 2;
                        //oPartes.Id_Operadores = 0;
                        //oPartes.Id_Areas = 0;
                        //oPartes.Fecha_Reclamo = Convert.ToDateTime(DateTime.Now.ToLongTimeString());
                        //oPartes.Detalle_Solucion = "."; // txtDetalle.Text;
                        //oPartes.Detalle_Falla = ".";
                        //oPartes.Guardar(oPartes, 0);
                    }
                }
            }

            if (dtPartesParaHacer.Rows.Count > 0)
            {
                dtPartesGenerados = oPartes.GenerarLotePartes(dtPartesParaHacer, Convert.ToInt32(Partes.Partes_Operaciones.RECONEXION));
                if (dtPartesGenerados.Rows.Count > 0)
                {
                    oPartes.GenerarHistorialPartes(dtPartesGenerados);
                    int idServicio;
                    int idAplicacionExterna;
                    int idCustomer; //es el id del usuario en la base de isp
                    int idLocation; //es el id de la locacion en el sip
                    DataTable dtDatosServicio = new DataTable();
                    DataTable dtDatosAplicacionExterna = new DataTable();
                    foreach (DataRow parte in dtPartesGenerados.Rows)
                    {
                        if (oConfig.GetValor_N("Agenda_Trabajo") == Convert.ToInt32(Agenda_Encabezado.Uso_agenda.TRABAJA_CON_AGENDA))
                            oUsuarurios_Servicios.ActualizarEstado(Convert.ToInt32(parte["id_usuarios_servicios"].ToString()), Convert.ToInt32(Servicios.Servicios_Estados.CONECTADO));
                        else
                        {
                            oGps.EnviarParte(Convert.ToInt32(parte["id"]));
                        }

                        //idServicio = Convert.ToInt32(parte["id_servicios"]);
                        //dtDatosServicio = oServicios.BuscarDatosServicio(idServicio);

                        //if (oConfig.GetValor_N("Agenda_Trabajo") != Convert.ToInt32(Agenda_Encabezado.Uso_agenda.TRABAJA_CON_AGENDA))
                        //{
                        //    idAplicacionExterna = Convert.ToInt32(dtDatosServicio.Rows[0]["id_aplicaciones_externas"]);
                        //    dtDatosAplicacionExterna = oAppExterna.Listar(idAplicacionExterna);
                        //    if (dtDatosAplicacionExterna.Rows[0]["nombre"].ToString().Equals("ISP"))
                        //    {
                        //        idCustomer = oISP.VerificarExisteUsuario(Usuarios.CurrentUsuario.Codigo);
                        //        if (idCustomer > 0)
                        //        {
                        //            idLocation = oISP.VerificarExisteLocacion(Convert.ToInt32(parte["id_usuarios_locaciones"]));
                        //            if (idLocation > 0)
                        //            {

                        //            }
                        //        }

                        //    }
                        //}
                    }

                }

            }


            //oPartes.AgruparPartesTrabajo(dtPartesParaHacer);
        }
        #endregion

        private void cierraok()
        {
            if (edicionFormaDePago)
            {
                if (Convert.ToDecimal(txttotal.Text) == Convert.ToDecimal(txttotalpagos.Text))
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("El total establecido no se puede cambiar", "Mensaje del sistema");
                }
            }
            else
            {
                if (Convert.ToDecimal(txttotalpagos.Text) <= 0)
                {
                    MessageBox.Show("No es posible realizar un pago en 0", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (oConfig.GetValor_N("Cta_Pagos_Parciales") == 1) /// permite pago parciales
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    if (Convert.ToDecimal(txttotal.Text) == Convert.ToDecimal(txttotalpagos.Text))
                    {
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Error en los pagos. Controle que haya seleccionado algún medio de pago.", "Mensaje del sistema");
                    }
                }
            }
        }

        private void txttotalpagos_TextChanged(object sender, EventArgs e)
        {
            ////  if (Convert.ToDecimal(txtsaldo.Text)==0) { cierraok(); }
        }

        private void dgvforma_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            eligio_pago();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try { dtDetalleRecibo.Rows.RemoveAt(dgvdetallerecibos.CurrentRow.Index); }
            catch { }

            suma();
        }

        private void frmUsuariosPagos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!edicionFormaDePago)
            {
                if (Convert.ToInt32(e.KeyChar) == 23)
                {
                    if (cuenta == 1)
                    {
                        lbCuenta.Visible = true;
                        cuenta = 2;
                    }
                    else
                    {
                        lbCuenta.Visible = false;
                        cuenta = 1;
                    }
                }
            }
        }

        private void cierra_Click(object sender, EventArgs e)
        {
            PanelAcciones.Visible = false;
        }

        private void dgvAcciones_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            if (dgvAcciones.Columns[e.ColumnIndex].Name == "Elige")
            {

                Boolean eli = Convert.ToBoolean(dgvAcciones.CurrentRow.Cells["Elige"].Value);
                if (eli == true)
                    dgvAcciones.CurrentRow.Cells["Elige"].Value = false;
                else
                    dgvAcciones.CurrentRow.Cells["Elige"].Value = true;
            }
        }

        private void cmbConfirma_Click(object sender, EventArgs e)
        {
            servicios_a_reconectar();
            if (dtAcciones.Rows.Count > 0)
            {
                PanelAcciones.Location = new Point(
                        this.ClientSize.Width / 2 - PanelAcciones.Size.Width / 2,
                        this.ClientSize.Height / 2 - PanelAcciones.Size.Height / 2);
                PanelAcciones.Anchor = AnchorStyles.None;
                PanelAcciones.BringToFront();
                PanelAcciones.Visible = true;
                btnConfirmarReconexion.Focus();
            }
            else
                cierraok();
        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvforma_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 || e.KeyChar == 9)
                eligio_pago();

        }

        private void frmUsuariosPagos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
                cierraok();

            if (e.KeyCode == Keys.Escape)
                if (pnPagos.Visible == true)
                {
                    pnPagos.Visible = false;
                    dgvforma.Focus();
                }
                else { this.Close(); }
        }

        private void dgvforma_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Space)
                eligio_pago();

        }

        private void imgCancelaPago_Click(object sender, EventArgs e)
        {
            pnPagos.Visible = false;
            dgvforma.Focus();
        }

        private void dgvforma_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            foreach (DataGridViewRow item in dgvforma.Rows)
                item.Height = 30;
        }



        private void btnConfirmarReconexion_Click(object sender, EventArgs e)
        {
            reconexion();
            cierraok();
        }

        private void frmUsuariosPagos_Load(object sender, EventArgs e)
        {
            tipoCondicionIva = Usuarios.CurrentUsuario.Id_Comprobantes_Iva;
            if (Usuarios.CurrentUsuario.Id_Comprobantes_Iva == (int)Comprobantes_Iva.Tipo.RESPONSABLE_INSCRIPTO)
            {
                DataTable dtPuntosVentas = new Comprobantes_Habilitados().GetDatosPuntoVenta(Convert.ToInt32(Comprobantes_Tipo.Tipo.FACTURA_A), Puntos_Cobros.Id_Punto);
                DataRow[] drs = dtPuntosVentas.Select("predeterminado = 1");
                lblTipoCom.Text = "FACTURA A - Punto Cobro: " + Puntos_Cobros.Name_Punto + " - Punto Venta: " + drs[0]["punto_venta_descripcion"];
                tipoComprobante = Comprobantes_Tipo.Tipo.FACTURA_A;

            }
            else
            {
                DataTable dtPuntosVentas = new Comprobantes_Habilitados().GetDatosPuntoVenta(Convert.ToInt32(Comprobantes_Tipo.Tipo.FACTURA_B), Puntos_Cobros.Id_Punto);
                DataRow[] drs = dtPuntosVentas.Select("predeterminado = 1");
                lblTipoCom.Text = "FACTURA B - Punto Cobro: " + Puntos_Cobros.Name_Punto + " - Punto Venta: " + drs[0]["punto_venta_descripcion"];
                tipoComprobante = Comprobantes_Tipo.Tipo.FACTURA_B;

            }
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            PanelAcciones.Visible = false;
        }
    }
}
//111019fedemediodia