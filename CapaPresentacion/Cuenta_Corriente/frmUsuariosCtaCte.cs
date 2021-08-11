
using CapaNegocios;
using CapaPresentacion.Contabilidad;
using CapaPresentacion.General;
using CapaPresentacion.Impresiones;
using CapaPresentacion.Partes_Trabajo;
using CapaPresentacion.Seguridad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Threading;
using System.Windows.Forms;


namespace CapaPresentacion
{
    public partial class frmUsuariosCtaCte : Form
    {
        #region DECLARACIONES
        private Thread hilo;
        private Thread hiloTarea;
        private delegate void myDel();
        private delegate void myDelEstado();

        private Usuarios oUsu = new Usuarios();
        private Usuarios_Locaciones oUsuLoc = new Usuarios_Locaciones();
        private Usuarios_Servicios oUsuServ = new Usuarios_Servicios();
        private Servicios oServ = new Servicios();
        private Equipos oEqui = new Equipos();

        private Usuarios_CtaCte oUsuCtaCte = new Usuarios_CtaCte();
        private Usuarios_CtaCte_Det oUsuCtaCteDet = new Usuarios_CtaCte_Det();

        private Formas_de_pago oFormas_De_Pago = new Formas_de_pago();
        private Comprobantes oComprobante = new Comprobantes();
        private Comprobantes_Tipo oComprobante_Tipo = new Comprobantes_Tipo();
        private Puntos_Cobros OPuntos_cobro = new Puntos_Cobros();
        private Comprobantes_Tipo Ocomprobantes_iva = new Comprobantes_Tipo();

        private Usuarios_CtaCte_Recibos Ousuarios_CtaCte_Recibos = new Usuarios_CtaCte_Recibos();
        private Comprobantes_Iva Ocomprobantes_Iva = new Comprobantes_Iva();
        private Comprobantes_Detalle oCOmprobantes_Detalle = new Comprobantes_Detalle();
        private Facturacion Ofacturacion = new Facturacion();
        private Configuracion oConfig = new Configuracion();
        private dsInformes oDs = new dsInformes();
        private Impresion oImpresion = new Impresion();
        private Presentacion_Debitos oPresentacionDebitos = new Presentacion_Debitos();
        private Punitorio oPunitorio = new Punitorio();
        private frmUsuariosCtacteDetExtras oFrmExtras;
        private Int32 Locacion_Id = 0, idCtacte;
        private DataTable dtLocaciones, dtCtaCteDetfinal, dtCtaCteDetfinalCopiaOriginal, dtCtaCteDet;
        private DataTable dtNotaDebito;
        public static DataTable dtDetalleRecibo;
        public static DataTable dtDetalleReciboCobrador;
        public decimal TotalPagoCobrador = 0, saldoCobrador = 0;
        private Usuarios_Dom_Fiscal oUsuariosDomFiscal = new Usuarios_Dom_Fiscal();

        public int vieneCobrador = 0, idCobrador = 0, idComprobanteCobrador = 0, idusuarioctacterecibo = 0, idCaja;
        private bool tieneDebito = false;
        private string tituloTarea;
        private Decimal Total_recibo = 0;
        private Int32 Cta_seleccion = 0, Punitorios_Tolerancia = 0, Recibo_tipo = 1, nroPuntoVenta;
        public Int32 cuenta = 1;
        private Int32 idusuario;
        private Int32 idlocacion;
        private Int32 flag = 0;
        private decimal montoTotal = 0;
        private Decimal IvaDivide = 1.21m;
        public DateTime FechaRecibo = DateTime.Now;
        public DateTime FechaPago = DateTime.Now;
        private List<Int32> comprobantesSeleccionados = new List<Int32>();


        DialogResult dialogResult;
        #endregion

        #region METODOS

        private void comenzarCarga()
        {
            MostrarInformacionDePuntoDeVenta();
            BloquearDesbloquearControles(false);
            pgCircular.Start();
            dgvLocaciones.DataSource = null;
            dgvCtaCteDet.DataSource = null;
            dgvPagos.AllowUserToOrderColumns = false;
            hilo = new Thread(new ThreadStart(cargarDatos));
            hilo.Start();
        }

        private void cargarDatos()
        {
            dtLocaciones = oUsuLoc.ListarLocacionesServicio(Usuarios.CurrentUsuario.Id);
            oUsuCtaCte.Id_Comprobantes = 0;
            dtCtaCteDetfinal = oUsuCtaCte.LlenarDtModelo(dtLocaciones, "U", 0, Usuarios.CurrentUsuario.Id); ////.get oUsuCtaCte.GetDtModelo();
            myDel MD = new myDel(asignarDatos);
            this.Invoke(MD, new object[] { });
            pgCircular.Stop();
        }

        private void asignarDatos()
        {
            Int32 idl = this.Locacion_Id;
            dgvLocaciones.CellEnter -= new DataGridViewCellEventHandler(this.dgvLocaciones_CellEnter);
            dgvLocaciones.DataSource = dtLocaciones;
            dgvLocaciones.CellEnter += new DataGridViewCellEventHandler(this.dgvLocaciones_CellEnter);
            dgvCtaCteDet.AllowUserToOrderColumns = false;
            dgvCtaCteDet.DataSource = dtCtaCteDetfinal;
            dtCtaCteDetfinalCopiaOriginal = dtCtaCteDetfinal.Copy();
            Columnas();
            // controla_Importes();

            int posi = 0;
            for (int i = 0; i < dgvLocaciones.Rows.Count; i++)
            {
                if (Int32.Parse(dgvLocaciones.Rows[i].Cells["id"].Value.ToString()) == idl)
                    posi = i;
            }
            dgvLocaciones.Rows[posi].Selected = true;
            filtra_por_locaciones();

            if (dtCtaCteDetfinal.Rows.Count > 0 && vieneCobrador == 1)
                EligePrimerComprobante();

            if (cuenta == 1)
                lbCuenta.Visible = false;

            if (cuenta == 2)
                lbCuenta.Visible = true;

            BloquearDesbloquearControles(true);
        }

        private void BloquearDesbloquearControles(bool activar)
        {
            foreach (Control item in this.Controls)
            {
                if (item.Name != "pgCircular")
                    item.Enabled = activar;
            }
        }

        private void EligePrimerComprobante()
        {
            try
            {
                dgvCtaCteDet.Rows[0].Selected = true;
                dgvCtaCteDet.Rows[0].Cells["elige"].Value = true;
                dtCtaCteDetfinal.Rows[0]["elige"] = true;
            }
            catch { }
            agrega_movimientos_a_pagar();

        }

        private void controla_Importes()
        {
            Percepciones.CalcularPercepcionesEnDtFinal(dtCtaCteDetfinal);

            
            foreach (DataRow dr in dtCtaCteDetfinal.Rows)
            {
                if (Convert.ToInt32(dr["encabezado"]) == 1)
                {
                    object sumOri = dtCtaCteDetfinal.Compute("sum(Importe_original)", string.Format("Id_usuarios_servicios = {0} and encabezado ={1} and Id_usuarios_ctacte = {2} ", Convert.ToInt32(dr["Id_usuarios_servicios"]), 0, Convert.ToInt32(dr["Id_usuarios_ctacte"])));
                    object sumPun = dtCtaCteDetfinal.Compute("sum(Importe_punitorio)", string.Format("Id_usuarios_servicios = {0} and encabezado ={1} and Id_usuarios_ctacte = {2} ", Convert.ToInt32(dr["Id_usuarios_servicios"]), 0, Convert.ToInt32(dr["Id_usuarios_ctacte"])));
                    object sumBon = dtCtaCteDetfinal.Compute("sum(Importe_bonificacion)", string.Format("Id_usuarios_servicios = {0} and encabezado ={1} and Id_usuarios_ctacte = {2} ", Convert.ToInt32(dr["Id_usuarios_servicios"]), 0, Convert.ToInt32(dr["Id_usuarios_ctacte"])));
                    object sumSal = dtCtaCteDetfinal.Compute("sum(Importe_saldo)", string.Format("Id_usuarios_servicios = {0} and encabezado ={1} and Id_usuarios_ctacte = {2} ", Convert.ToInt32(dr["Id_usuarios_servicios"]), 0, Convert.ToInt32(dr["Id_usuarios_ctacte"])));
                    object sumTot = dtCtaCteDetfinal.Compute("sum(Importe_total)", string.Format("Id_usuarios_servicios = {0} and encabezado ={1} and Id_usuarios_ctacte = {2} ", Convert.ToInt32(dr["Id_usuarios_servicios"]), 0, Convert.ToInt32(dr["Id_usuarios_ctacte"])));
                    object sumPag = dtCtaCteDetfinal.Compute("sum(Importe_pago)", string.Format("Id_usuarios_servicios = {0} and encabezado ={1} and Id_usuarios_ctacte = {2} ", Convert.ToInt32(dr["Id_usuarios_servicios"]), 0, Convert.ToInt32(dr["Id_usuarios_ctacte"])));
                    object sumPro = dtCtaCteDetfinal.Compute("sum(Importe_Provincial)", string.Format("Id_usuarios_servicios = {0} and encabezado ={1} and Id_usuarios_ctacte = {2} ", Convert.ToInt32(dr["Id_usuarios_servicios"]), 0, Convert.ToInt32(dr["Id_usuarios_ctacte"])));
                    object Fechde = dtCtaCteDetfinal.Compute("min(fecha_desde)", string.Format("Id_usuarios_servicios = {0} and encabezado ={1} and Id_usuarios_ctacte = {2} ", Convert.ToInt32(dr["Id_usuarios_servicios"]), 0, Convert.ToInt32(dr["Id_usuarios_ctacte"])));
                    object Fechha = dtCtaCteDetfinal.Compute("max(fecha_hasta)", string.Format("Id_usuarios_servicios = {0} and encabezado ={1} and Id_usuarios_ctacte = {2} ", Convert.ToInt32(dr["Id_usuarios_servicios"]), 0, Convert.ToInt32(dr["Id_usuarios_ctacte"])));
                    object debito = dtCtaCteDetfinal.Compute("max(id_debito_asociado)", string.Format("Id_usuarios_ctacte = {0} and encabezado ={1}", Convert.ToInt32(dr["Id_usuarios_ctacte"]), 0));

                    dr["fecha_desde"] = Fechde;
                    dr["fecha_hasta"] = Fechha;
                    dr["id_debito_asociado"] = debito;

                    sumSal = sumSal.ToString() == "" ? 0 : sumSal;
                    dr["importe_saldo"] = Convert.ToDecimal(sumSal);

                    sumTot = sumTot.ToString() == "" ? 0 : sumTot;
                    dr["importe_total"] = Convert.ToDecimal(sumTot);

                    sumPun = sumPun.ToString() == "" ? 0 : sumPun;
                    dr["importe_punitorio"] = Convert.ToDecimal(sumPun);

                    sumBon = sumBon.ToString() == "" ? 0 : sumBon;
                    dr["importe_bonificacion"] = Convert.ToDecimal(sumBon);

                    sumPro = sumPro.ToString() == "" ? 0 : sumPro;
                    dr["importe_Provincial"] = Convert.ToDecimal(sumPro);

                    sumOri = sumOri.ToString() == "" ? 0 : sumOri;
                    dr["importe_original"] = Convert.ToDecimal(sumOri);

                    sumPag = sumPag.ToString() == "" ? 0 : sumPag;
                    dr["importe_pago"] = Convert.ToDecimal(sumPag);
                }
            }

            foreach (DataRow dr in dtCtaCteDetfinal.Rows)
            { //// pone bonifica en comprobantes{
                if (Convert.ToInt32(dr["encabezado"]) == 2)
                {
                    object sumSal = dtCtaCteDetfinal.Compute("sum(Importe_saldo)", string.Format("Id_usuarios_ctacte = {0} and encabezado ={1}", Convert.ToInt32(dr["Id_usuarios_ctacte"]), 1));
                    object sumTot = dtCtaCteDetfinal.Compute("sum(Importe_total)", string.Format("Id_usuarios_ctacte = {0} and encabezado ={1}", Convert.ToInt32(dr["Id_usuarios_ctacte"]), 1));
                    object sumPun = dtCtaCteDetfinal.Compute("sum(Importe_punitorio)", string.Format("Id_usuarios_ctacte = {0} and encabezado ={1}", Convert.ToInt32(dr["Id_usuarios_ctacte"]), 1));
                    object sumBon = dtCtaCteDetfinal.Compute("sum(Importe_bonificacion)", string.Format("Id_usuarios_ctacte = {0} and encabezado ={1}", Convert.ToInt32(dr["Id_usuarios_ctacte"]), 1));
                    object sumOri = dtCtaCteDetfinal.Compute("sum(Importe_original)", string.Format("Id_usuarios_ctacte = {0} and encabezado ={1}", Convert.ToInt32(dr["Id_usuarios_ctacte"]), 1));
                    object sumPag = dtCtaCteDetfinal.Compute("sum(Importe_pago)", string.Format("Id_usuarios_ctacte = {0} and encabezado ={1}", Convert.ToInt32(dr["Id_usuarios_ctacte"]), 1));
                    object sumPro = dtCtaCteDetfinal.Compute("sum(Importe_provincial)", string.Format("Id_usuarios_ctacte = {0} and encabezado ={1}", Convert.ToInt32(dr["Id_usuarios_ctacte"]), 1));
                    object Fechde = dtCtaCteDetfinal.Compute("min(fecha_desde)", string.Format("Id_usuarios_ctacte = {0} and encabezado ={1}", Convert.ToInt32(dr["Id_usuarios_ctacte"]), 1));
                    object Fechha = dtCtaCteDetfinal.Compute("max(fecha_hasta)", string.Format("Id_usuarios_ctacte = {0} and encabezado ={1}", Convert.ToInt32(dr["Id_usuarios_ctacte"]), 1));
                    object debito = dtCtaCteDetfinal.Compute("max(id_debito_asociado)", string.Format("Id_usuarios_ctacte = {0} and encabezado ={1}", Convert.ToInt32(dr["Id_usuarios_ctacte"]), 0));

                    dr["fecha_desde"] = Fechde;
                    dr["fecha_hasta"] = Fechha;
                    dr["id_debito_asociado"] = debito;


                    sumSal = sumSal.ToString() == "" ? 0 : sumSal;
                    dr["importe_saldo"] = Convert.ToDecimal(sumSal);

                    sumTot = sumTot.ToString() == "" ? 0 : sumTot;
                    dr["importe_total"] = Convert.ToDecimal(sumTot);

                    sumPun = sumPun.ToString() == "" ? 0 : sumPun;
                    dr["importe_punitorio"] = Convert.ToDecimal(sumPun);

                    sumBon = sumBon.ToString() == "" ? 0 : sumBon;
                    dr["importe_bonificacion"] = Convert.ToDecimal(sumBon);

                    sumPro = sumPro.ToString() == "" ? 0 : sumPro;
                    dr["importe_provincial"] = Convert.ToDecimal(sumPro);

                    sumOri = sumOri.ToString() == "" ? 0 : sumOri;
                    dr["importe_original"] = Convert.ToDecimal(sumOri);


                    sumPag = sumPag.ToString() == "" ? 0 : sumPag;
                    dr["importe_pago"] = Convert.ToDecimal(sumPag);
                }
            }
        }
        #endregion

        #region LOCACIONES

        private void filtra_por_locaciones()
        {
            try
            {
                lblocalidad.Text = dgvLocaciones.SelectedRows[0].Cells["calle"].Value.ToString().Trim() + "  Nro (" + dgvLocaciones.SelectedRows[0].Cells["Altura"].Value.ToString() + ") - " + dgvLocaciones.SelectedRows[0].Cells["piso"].Value.ToString() + " " + dgvLocaciones.SelectedRows[0].Cells["depto"].Value.ToString() + " ( $ :" + dgvLocaciones.SelectedRows[0].Cells["saldo"].Value.ToString() + ")";
                Locacion_Id = Convert.ToInt32(dgvLocaciones.SelectedRows[0].Cells["id"].Value.ToString());
                Usuarios.Current_IdUsuarioLocacion = Locacion_Id;
                Usuarios.CurrentUsuario.localidad = dgvLocaciones.SelectedRows[0].Cells["localidad"].Value.ToString().Trim();
                Usuarios.CurrentUsuarioDomFiscal = oUsuariosDomFiscal.LlenarDatosLocFiscal(Usuarios.Current_IdUsuarioLocacion);
                lbdomfiscal.Text = Usuarios.CurrentUsuarioDomFiscal.R_Social.ToString().Trim() + " - " + Comprobantes_Iva.CurrentComprobantes_Iva.Descripcion.ToString().Trim() + '"' + Comprobantes_Iva.CurrentComprobantes_Iva.Letra + '"';
                DataView v1 = dtCtaCteDetfinal.DefaultView;
                v1.RowFilter = string.Format("id_usuarios_locaciones = {0} ", Convert.ToInt32(dgvLocaciones.SelectedRows[0].Cells["id"].Value.ToString()));
                dgvPagos.DataSource = v1;
                Ver_movimientos_a_Pagar();
                columnas_pagos();
                oculta_filas_pagos();
                oculta_filas();
            }
            catch { }


        }

        private void dgvLocaciones_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (flag == 0)
            {
                try
                {
                    int cantSeleccionados = 0;
                    int idLoc = 0;
                    foreach (DataGridViewRow item in dgvCtaCteDet.Rows)
                    {
                        if (Convert.ToBoolean(item.Cells["elige"].Value) == true)
                        {
                            cantSeleccionados++;
                            idLoc = Convert.ToInt32(item.Cells["id_usuarios_locaciones"].Value);
                        }
                    }
                    if (cantSeleccionados > 0 && vieneCobrador == 0)
                    {
                        if (MessageBox.Show("Quedaron comprobantes seleccionados sin completar el pago, si cambia de locación se perdera la selección, ¿Desea cambiar de locación de todas formas?", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            foreach (DataGridViewRow item in dgvCtaCteDet.Rows)
                                item.Cells["elige"].Value = false;



                            QuitaSeleccion();
                            filtra_por_locaciones();
                        }
                        else
                        {
                            foreach (DataGridViewRow item in dgvLocaciones.Rows)
                            {
                                if (Convert.ToInt32(item.Cells["id"].Value) == idLoc)
                                    item.Selected = true;
                            }
                        }
                    }
                    else
                        filtra_por_locaciones();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        #endregion

        #region COMPROBANTES DE DEUDA

        private DataTable GenerarDtRegistrosGrillaCtaCte()
        {
            DataTable dt = oUsuCtaCte.GenerarDtDatosCtaCteAjustes();
            List<int> listaIdsCtaCteControl = new List<int>();

            if (dtCtaCteDetfinal.Rows.Count > 0)
            {
                foreach (DataRow fila in dtCtaCteDetfinal.Rows)
                {
                    if (Convert.ToBoolean(fila["elige"]) == true && listaIdsCtaCteControl.Contains(Convert.ToInt32(fila["id_usuarios_ctacte"])) == false)
                    {


                        //if (Convert.ToInt32(fila["presenta_ventas"]) == 1)
                        //    cuenta = 1;


                        if (Convert.ToInt32(fila["encabezado"]) == 2)
                        {
                            dt.Rows.Add(Convert.ToInt32(Usuarios_CtaCte.TIPO_REGISTRO_CTACTE.COMPROBANTE), fila["id_usuarios_ctacte"].ToString(), "0", "0", fila["id_usuarios"].ToString(), Convert.ToInt32(fila["presenta_ventas"]));
                            listaIdsCtaCteControl.Add(Convert.ToInt32(fila["id_usuarios_ctacte"]));
                        }
                        else if (Convert.ToInt32(fila["encabezado"]) == 1)
                            dt.Rows.Add(Convert.ToInt32(Usuarios_CtaCte.TIPO_REGISTRO_CTACTE.SERVICIO), fila["id_usuarios_ctacte"].ToString(), fila["id_usuarios_servicios"].ToString(), "0", fila["id_usuarios"].ToString(), Convert.ToInt32(fila["presenta_ventas"]));
                        else if (Convert.ToInt32(fila["encabezado"]) == 0 && dtCtaCteDetfinal.Select(String.Format("id_usuarios_ctacte={0} and id_usuarios_servicios={1} and encabezado={2} and elige={3}", fila["id_usuarios_ctacte"].ToString(), fila["id_usuarios_servicios"].ToString(), "1", "true")).Length == 0)
                            dt.Rows.Add(Convert.ToInt32(Usuarios_CtaCte.TIPO_REGISTRO_CTACTE.SUBSERVICIO), fila["id_usuarios_ctacte"].ToString(), fila["id_usuarios_servicios"].ToString(), fila["id"].ToString(), fila["id_usuarios"].ToString(), Convert.ToInt32(fila["presenta_ventas"]));
                    }
                }
            }
            return dt;
        }

        private void Columnas()
        {
            if (dgvCtaCteDet.Columns["extra"] == null)
            {
                DataGridViewLinkColumn clmLink = new DataGridViewLinkColumn();
                clmLink.Name = "extra";
                clmLink.Text = "ver extras";
                clmLink.DataPropertyName = "Extras";
                clmLink.LinkColor = Color.Blue;
                clmLink.VisitedLinkColor = Color.Blue;
                clmLink.UseColumnTextForLinkValue = true;
                clmLink.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                clmLink.HeaderText = "Extras";
                clmLink.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader;
                dgvCtaCteDet.Columns.Add(clmLink);
            }

            if (dgvCtaCteDet.Columns["autonumerico"] != null)
                dgvCtaCteDet.Columns["autonumerico"].Visible = false;

            for (int i = 0; i < dtCtaCteDetfinal.Columns.Count; i++)
                dgvCtaCteDet.Columns[i].Visible = false;

            for (int i = 0; i < dtCtaCteDetfinal.Columns.Count; i++)
                dgvCtaCteDet.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;

            dgvCtaCteDet.Columns["Servicio"].Visible = true;
            dgvCtaCteDet.Columns["Servicio"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvCtaCteDet.Columns["expande"].Visible = true;
            dgvCtaCteDet.Columns["expande"].Width = 10;
            dgvCtaCteDet.Columns["expande"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            dgvCtaCteDet.Columns["elige"].Visible = true;
            dgvCtaCteDet.Columns["elige"].Width = 80;
            dgvCtaCteDet.Columns["elige"].HeaderText = "Ok";
            dgvCtaCteDet.Columns["elige"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            dgvCtaCteDet.Columns["Fecha_desde"].Visible = true;
            dgvCtaCteDet.Columns["Fecha_desde"].HeaderText = "Desde";
            dgvCtaCteDet.Columns["Fecha_desde"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvCtaCteDet.Columns["Fecha_Hasta"].Visible = true;
            dgvCtaCteDet.Columns["Fecha_Hasta"].HeaderText = "Hasta";
            dgvCtaCteDet.Columns["Fecha_Hasta"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvCtaCteDet.Columns["Importe_saldo"].Visible = true;
            dgvCtaCteDet.Columns["Importe_saldo"].DefaultCellStyle.Format = "c2";
            dgvCtaCteDet.Columns["Importe_saldo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvCtaCteDet.Columns["importe_saldo"].HeaderText = "Deuda Original";


            dgvCtaCteDet.Columns["Importe_punitorio"].Visible = true;
            dgvCtaCteDet.Columns["Importe_punitorio"].DefaultCellStyle.Format = "c2";
            dgvCtaCteDet.Columns["Importe_punitorio"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvCtaCteDet.Columns["importe_punitorio"].HeaderText = "Punitorio";


            dgvCtaCteDet.Columns["Importe_total"].Visible = true;
            dgvCtaCteDet.Columns["Importe_total"].DefaultCellStyle.Format = "c2";
            dgvCtaCteDet.Columns["Importe_total"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvCtaCteDet.Columns["Importe_total"].HeaderText = "Deuda Actualizada";

            dgvCtaCteDet.Columns["extra"].Visible = true;
            dgvCtaCteDet.Columns["extra"].DisplayIndex = dgvCtaCteDet.ColumnCount - 1;

            dgvCtaCteDet.Columns["CalcularPercepcion"].Visible = false;
            dgvCtaCteDet.Columns["Percepcion"].Visible = false;


            if (dtLocaciones.Rows.Count > 0) { this.Locacion_Id = Convert.ToInt32(dgvLocaciones.SelectedRows[0].Cells["id"].Value.ToString()); }

            for (int i = 0; i < dtLocaciones.Columns.Count; i++)
                dgvLocaciones.Columns[i].Visible = false;

            dgvLocaciones.Columns["calle"].Visible = true;
            dgvLocaciones.Columns["Altura"].Visible = true;
            dgvLocaciones.Columns["Piso"].Visible = true;
            dgvLocaciones.Columns["Depto"].Visible = true;
            dgvLocaciones.Columns["saldo"].Visible = true;
        }

        private void dgvCtaCteDet_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
                agrega_movimientos_a_pagar();

            if (e.KeyCode == Keys.Divide)
                expande();

        }

        private void dgvCtaCteDet_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //cada vez que selecciona o deselecciona un registro de ctacte debe verificar si alguno de los comprobantes esta adherido a debito
            //si hay por lo menos 1 registro con debito la variale 'tieneDebito' ya es true

            tieneDebito = false;

            if (dgvCtaCteDet.Columns[e.ColumnIndex].Name == "elige")
            {
                //int cantDetDeb = 0;
                //int idCtacte = Convert.ToInt32(dgvCtaCteDet.Rows[e.RowIndex].Cells["id_usuarios_ctacte"].Value);
                //foreach (DataRow item in dtCtaCteDetfinal.Rows)
                //{
                //    if (Convert.ToBoolean(dgvCtaCteDet.Rows[e.RowIndex].Cells["elige"].Value) == false && Convert.ToInt32(item["id_usuarios_ctacte"]) == idCtacte && Convert.ToInt32(item["encabezado"]) == 0 && Convert.ToInt32(item["id_debito_asociado"]) > 0)
                //        cantDetDeb++;
                //}
                //if (cantDetDeb > 0)
                //    tieneDebito = true;
                //else
                //    tieneDebito = false;
                Boolean Graba = Controla_Movimientos_en_Locaciones();

                if (Graba == true)
                {
                    agrega_movimientos_a_pagar();
                }
            }
            else if (dgvCtaCteDet.Columns[e.ColumnIndex].Name == "expande")
                expande();
            else if (dgvCtaCteDet.Columns[e.ColumnIndex].Name == "extra")
            {
                if (dgvCtaCteDet.SelectedRows[0].Cells["expande"].Value.ToString() == "")
                {

                    oFrmExtras = new frmUsuariosCtacteDetExtras(false);
                    oFrmExtras.idUsuarioCtaCteDetExtra = Convert.ToInt32(dgvCtaCteDet.SelectedRows[0].Cells["id"].Value);
                    frmPopUp oPop = new frmPopUp();
                    oPop.Maximizar = true;
                    oPop.Formulario = oFrmExtras;
                    oPop.ShowDialog();
                }
            }
        }

        private void expande()
        {
            Int32 idi = Convert.ToInt32(dgvCtaCteDet.CurrentRow.Cells["id_usuarios_ctacte"].Value);
            String expa = Convert.ToString(dgvCtaCteDet.CurrentRow.Cells["expande"].Value);
            Int32 ids = Convert.ToInt32(dgvCtaCteDet.CurrentRow.Cells["id_usuarios_servicios"].Value);
            Int32 muestra = 0;
            if (Convert.ToInt32(dgvCtaCteDet.CurrentRow.Cells["encabezado"].Value) > 0) // hizo click en comprobante o servicio
            {
                if (expa == "+")
                {
                    dgvCtaCteDet.CurrentRow.Cells["expande"].Value = "-";
                    muestra = 1;
                }
                else
                {
                    dgvCtaCteDet.CurrentRow.Cells["expande"].Value = "+";
                    muestra = 0;
                }

                if (Convert.ToInt32(dgvCtaCteDet.CurrentRow.Cells["encabezado"].Value) == 2) /// HIZO CLICK EN EL COMPROBANTE
                {
                    foreach (DataRow dr in dtCtaCteDetfinal.Rows)
                    {
                        if (muestra == 0)
                        {
                            if (Convert.ToInt32(dr["encabezado"].ToString()) < 2 && idi == Convert.ToInt32(dr["id_usuarios_ctacte"].ToString()))
                                dr["muestra"] = muestra;
                        }
                        else
                        if (Convert.ToInt32(dr["encabezado"].ToString()) == 1 && idi == Convert.ToInt32(dr["id_usuarios_ctacte"].ToString()))
                            dr["muestra"] = muestra;
                    }
                }

                if (Convert.ToInt32(dgvCtaCteDet.CurrentRow.Cells["encabezado"].Value) == 1) /// HIZO CLICK EN EL SERVICIO
                {
                    foreach (DataRow dr in dtCtaCteDetfinal.Rows)
                    {
                        if (Convert.ToInt32(dr["encabezado"].ToString()) == 0 && ids == Convert.ToInt32(dr["id_usuarios_servicios"].ToString()) && idi == Convert.ToInt32(dr["id_usuarios_ctacte"].ToString()))
                            dr["muestra"] = muestra;
                    }
                }

            }
            oculta_filas();
        }

        private void oculta_filas()
        {
            foreach (DataGridViewRow dr in dgvCtaCteDet.Rows)
            {
                if (Convert.ToInt32(dr.Cells["Muestra"].Value) == 1)
                    dr.Visible = true;
                else
                {
                    try { dr.Visible = false; }
                    catch { }
                }
            }
        }

        private void suma()
        {
            object sumElige = dtCtaCteDetfinal.Compute("sum(Importe_total)", "elige = true and encabezado = 0");
            sumElige = sumElige.ToString() == "" ? 0 : sumElige;
            montoTotal = Convert.ToDecimal(sumElige);
            txttotal.Text = String.Format("${0}", Decimal.Round(montoTotal, 2));

            object sumPerc = dtCtaCteDetfinal.Compute("sum(Importe_provincial)", "elige = true and encabezado = 0 ");
            sumPerc = sumPerc.ToString() == "" ? 0 : sumPerc;

            if (Convert.ToDecimal(sumPerc) == 0)
                txtpercepcion.Text = String.Format("${0}", Decimal.Round(Convert.ToDecimal(sumPerc), 2));
            else
                txtpercepcion.Text = String.Format("${0}", Decimal.Round(Convert.ToDecimal(sumPerc), 2));

        }

        private void btnTotal_Click(object sender, EventArgs e)
        {
            Boolean Graba = Controla_Movimientos_en_Locaciones();

            if (Graba == true)
            {
                foreach (DataRow dr in dtCtaCteDetfinal.Rows)
                {
                    if (Convert.ToInt32(dr["Id_Usuarios_Locaciones"].ToString()) == Convert.ToInt32(dgvLocaciones.SelectedRows[0].Cells["id"].Value.ToString()) && Convert.ToInt32(dr["id_debito_asociado"].ToString()) == 0)
                        dr["elige"] = true;
                }


            }
            controla_Importes();
            Ver_movimientos_a_Pagar();

            suma();
        }

        private Boolean Controla_Movimientos_en_Locaciones()
        {
            Boolean Graba = true;
            try
            {
                DataRow[] dataRows = dtCtaCteDetfinal.Select(String.Format("Id_usuarios_locaciones <> {0} and elige = true", Convert.ToInt32(dgvLocaciones.SelectedRows[0].Cells["id"].Value.ToString())));
                if (dataRows.Length > 0)
                {


                    dialogResult = MessageBox.Show("Tiene Movimientos Seleccionados en otra Locacion ¿Desea Elimanarlos Para continuar?", "", MessageBoxButtons.YesNo);

                    if (dialogResult == DialogResult.Yes)
                    {
                        QuitaSeleccion();
                        Graba = true;
                    }
                    else
                        Graba = false;
                }

            }
            catch { };


            return Graba;
        }

        private void QuitaSeleccion()
        {
            foreach (DataRow dr in dtCtaCteDetfinal.Rows)
            {
                if (Convert.ToInt32(dr["Id_Usuarios_Locaciones"].ToString()) != Convert.ToInt32(dgvLocaciones.SelectedRows[0].Cells["id"].Value.ToString()))
                    dr["elige"] = false;
            }
            dtCtaCteDetfinal.AcceptChanges();
        }

        private void VerificarAfip()
        {
            try
            {
                using (var client = new WebClient())
                {
                    using (client.OpenRead("https://www.google.com/"))
                    {
                        if (Ofacturacion.VerificarAFIP() == false)
                            MessageBox.Show("Servicio de Afip no se encuentra disponible", "Mensaje del Sistema");
                    }
                }
            }
            catch
            {
                MessageBox.Show("Verifique la Conexion de Internet", "Mensaje del Sistema");
            }
        }

        #endregion

        #region MOVIMIMIENTOS ELEGIDOS

        private void columnas_pagos()
        {
            for (int i = 0; i < dtCtaCteDetfinal.Columns.Count; i++)
                dgvPagos.Columns[i].Visible = false;

            dgvPagos.Columns["Servicio"].Visible = true;
            dgvPagos.Columns["Servicio"].Width = 150;

            dgvPagos.Columns["Importe_pago"].Visible = true;
            dgvPagos.Columns["Importe_pago"].HeaderText = "Pago";
            dgvPagos.Columns["Importe_pago"].DefaultCellStyle.Format = "c2";
            dgvPagos.Columns["Importe_pago"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

        }

        private void oculta_filas_pagos()
        {
            try
            {
                foreach (DataGridViewRow dr in dgvPagos.Rows)
                {
                    if (Convert.ToInt32(dr.Cells["encabezado"].Value) == 2)
                        dr.Visible = true;
                    else
                        dr.Visible = false;
                }
            }
            catch { }
        }

        private void agrega_movimientos_a_pagar()
        {
            try
            {
                Int32 idcta = Convert.ToInt32(dgvCtaCteDet.CurrentRow.Cells["id_usuarios_ctacte"].Value);
                Int32 idser = Convert.ToInt32(dgvCtaCteDet.CurrentRow.Cells["id_usuarios_servicios"].Value);
                Int32 idenc = Convert.ToInt32(dgvCtaCteDet.CurrentRow.Cells["encabezado"].Value); // 2 compro 1 servicio 0 suser
                Boolean sigue = true;

                switch (Cta_seleccion)
                {
                    case 1: /// comprobantes
                        if (idenc < 2) { sigue = false; }
                        break;
                    case 2: /// solo servicios
                        if (idenc == 0) { sigue = false; }
                        break;
                    case 3: /// puede pagar cualquier item
                        sigue = true;
                        break;
                }

                if (sigue == true)
                {
                    //            QuitaSeleccion();

                    Boolean eli = Convert.ToBoolean(dgvCtaCteDet.CurrentRow.Cells["elige"].Value);
                    Boolean stado_elige;
                    if (eli == true)
                        stado_elige = false;
                    else
                        stado_elige = true;


                    switch (idenc)
                    {

                        case 0:  // subservicio

                            dtCtaCteDetfinal.Rows[dgvCtaCteDet.CurrentRow.Index]["elige"] = stado_elige;
                            dtCtaCteDetfinal.Rows[dgvCtaCteDet.CurrentRow.Index]["importe_pago"] = 0;
                            if (stado_elige == true) { dtCtaCteDetfinal.Rows[dgvCtaCteDet.CurrentRow.Index]["importe_pago"] = Convert.ToDecimal(dtCtaCteDetfinal.Rows[dgvCtaCteDet.CurrentRow.Index]["importe_total"].ToString()); }

                            /// para que tambien seleccione servicio y comprobante
                            /// 


                            if (stado_elige == true)
                            {
                                foreach (DataRow dr in dtCtaCteDetfinal.Rows)
                                {
                                    if (Convert.ToInt32(dr["id_usuarios_ctacte"]) == idcta && Convert.ToInt32(dr["encabezado"]) > 0)
                                    {
                                        dr["elige"] = stado_elige;
                                        dr["importe_pago"] = 0;
                                        if (stado_elige == true) { dr["importe_pago"] = Convert.ToDecimal(dr["importe_total"].ToString()); }
                                    }
                                }
                            }


                            /// 

                            break;
                        case 1: // servicio
                            foreach (DataRow dr in dtCtaCteDetfinal.Rows)
                            {
                                if (Convert.ToInt32(dr["id_usuarios_ctacte"]) == idcta && Convert.ToInt32(dr["id_usuarios_servicios"]) == idser)
                                {
                                    dr["elige"] = stado_elige;
                                    dr["importe_pago"] = 0;
                                    if (stado_elige == true) { dr["importe_pago"] = Convert.ToDecimal(dr["importe_total"].ToString()); }
                                }
                            }
                            /// para que tambien seleccione servicio y comprobante
                            /// 
                            if (stado_elige == true)
                            {
                                foreach (DataRow dr in dtCtaCteDetfinal.Rows)
                                {
                                    if (Convert.ToInt32(dr["id_usuarios_ctacte"]) == idcta && Convert.ToInt32(dr["encabezado"]) > 0)
                                    {
                                        dr["elige"] = stado_elige;
                                        dr["importe_pago"] = 0;
                                        if (stado_elige == true) { dr["importe_pago"] = Convert.ToDecimal(dr["importe_total"].ToString()); }
                                    }
                                }
                            }
                            /// 

                            break;
                        case 2: // comprobante de deuda
                            if (idenc == 2) // todo el comprobante
                            {
                                foreach (DataRow dr in dtCtaCteDetfinal.Rows)
                                {
                                    if (Convert.ToInt32(dr["id_usuarios_ctacte"]) == idcta)
                                    {
                                        dr["elige"] = stado_elige;
                                        dr["importe_pago"] = 0;
                                        if (stado_elige == true) { dr["importe_pago"] = Convert.ToDecimal(dr["importe_total"].ToString()); }
                                    }
                                }
                            }

                            break;

                    }
                    Ver_movimientos_a_Pagar();
                    oculta_filas_pagos();
                    controla_Importes();
                    suma();
                    oculta_filas();
                }
                else
                {
                    MessageBox.Show("No se puede seleccionar el item a abonar");
                }
            }
            catch { }
        }

        private void Ver_movimientos_a_Pagar()
        {
            DataTable Pagos = dtCtaCteDetfinal.Copy();
            DataView v1 = Pagos.DefaultView;
            v1.RowFilter = string.Format("elige = {0} ", true);
            dgvPagos.DataSource = v1;
            DataRow[] drcuenta = Pagos.Select("cuenta=2 and elige=true ");
            if (vieneCobrador == 0)
            {
                if (drcuenta.Length > 0)
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

        #endregion

        #region PAGOS

        private void pagos_parciales()
        {
            DataTable dtafectado = dtCtaCteDetfinal.Clone();
            Decimal Recibo_resta = Total_recibo;
            if (Total_recibo > montoTotal) // pago distinto paga to y va un pago a cuenta
                Recibo_resta = Total_recibo - montoTotal;
            else
            {
                Int32 IdcomprobanteTipo = 8; // pagos a cuenta

                //// sumo los creditos a cuenta
                object SumNeg = dtCtaCteDetfinal.Compute("sum(Importe_pago)", string.Format("encabezado ={0} and Id_comprobantes_tipo = {1} ", 2, IdcomprobanteTipo));
                SumNeg = SumNeg.ToString() == "" ? 0 : SumNeg;
                /// suma los acuenta al pago
                Recibo_resta = Recibo_resta + Math.Abs(Convert.ToDecimal(SumNeg.ToString()));
                foreach (DataRow dr in dtCtaCteDetfinal.Rows)
                {
                    if (Convert.ToInt32(dr["Id_comprobantes_tipo"].ToString()) != IdcomprobanteTipo) // no toma los pagos cuenta
                    {
                        if (Recibo_resta == 0)
                            dr["Importe_pago"] = 0;
                        if (Convert.ToInt32(dr["encabezado"].ToString()) == 0 && Convert.ToBoolean(dr["elige"].ToString()) == true)
                        {
                            //   dr["Importe_punitorio"] = Recibo_resta;
                            if (Recibo_resta == 0)
                                dr["Importe_pago"] = 0;
                            else
                            {
                                if (Convert.ToDecimal(dr["importe_pago"].ToString()) <= Recibo_resta)
                                    Recibo_resta = Recibo_resta - Convert.ToDecimal(dr["importe_pago"].ToString());
                                else
                                {
                                    dr["Importe_pago"] = Recibo_resta;
                                    Recibo_resta = 0;
                                }
                            }
                            dtafectado.ImportRow(dr);
                        }
                    }
                }
            }
            dtCtaCteDetfinal.AcceptChanges();


            if (Recibo_resta > 0) // sobro plata
                Genera_Comprobante_Credito(Recibo_resta);
        }

        private DataTable generarDtNotaDebito()
        {
            DataTable dtNotaDeDebito = new DataTable();
            List<DataColumn> listaDc = new List<DataColumn>()
            {
                new DataColumn("idCtacte", typeof(int)),
                new DataColumn("importePunitorio", typeof(decimal)),
                new DataColumn("idNotaDebitoComprobante", typeof(int)),
                new DataColumn("CAE", typeof(string)),
                new DataColumn("Numero", typeof(int)),
                new DataColumn("idComprobanteTipo", typeof(int)),
                new DataColumn("docOCuit", typeof(string)),
                new DataColumn("idPuntoVenta", typeof(int)),
                new DataColumn("fecha", typeof(DateTime)),
                new DataColumn("numeroAsociado", typeof(int)),
                new DataColumn("idUsuario", typeof(int)),
                new DataColumn("idLocacion", typeof(int)),
                new DataColumn("salida", typeof(string))
            };
            dtNotaDeDebito.Columns.AddRange(listaDc.ToArray());
            DataTable dtFiltrado = dtCtaCteDetfinal.Copy();
            dtFiltrado.DefaultView.RowFilter = $"elige = {true} and " +
                " encabezado = 2 and " +
                $" (id_comprobantes_tipo = {(int)Comprobantes_Tipo.Tipo.FACTURA_A} or " +
                $" id_comprobantes_tipo = {(int)Comprobantes_Tipo.Tipo.FACTURA_B}) and " +
                " importe_punitorio <> 0";
            dtFiltrado = dtFiltrado.DefaultView.ToTable();

            foreach (DataRow row in dtFiltrado.Rows)
            {
                DataRow dr = dtNotaDeDebito.NewRow();
                dr["idCtacte"] = Convert.ToInt32(row["id_usuarios_ctacte"]);
                dr["importePunitorio"] = Convert.ToDecimal(row["importe_punitorio"]);
                dr["idComprobanteTipo"] = Convert.ToInt32(row["id_comprobantes_tipo"]);
                dr["docOCuit"] = Convert.ToInt32(row["id_comprobantes_tipo"]) == (int)Comprobantes_Tipo.Tipo.FACTURA_A
                              ? Usuarios.CurrentUsuario.CUIT.ToString()
                              : Usuarios.CurrentUsuario.Numero_Documento.ToString();
                dr["fecha"] = DateTime.Now;
                dr["idPuntoVenta"] = Convert.ToInt32(row["punto"]);
                dr["numeroAsociado"] = Convert.ToInt32(row["numero"]);
                dr["idUsuario"] = Usuarios.CurrentUsuario.Id;
                dr["idlocacion"] = Convert.ToInt32(row["id_usuarios_locaciones"]);
                dtNotaDeDebito.Rows.Add(dr);
            }
            return dtNotaDeDebito;
        }

        private void agregarpago()
        {


            if (Total_recibo < montoTotal) // paga de menos
                pagos_parciales();

            DataTable Pagos = dtCtaCteDetfinal.Copy();


            ///////////////////////////////////////////////
            // Filtra los moviemientos abonados
            DataView ViewAbonados = Pagos.DefaultView;
            ViewAbonados.RowFilter = string.Format("elige = {0} ", true);
            DataTable dt_Movimientos_Pagos = ViewAbonados.ToTable();


            DataTable dtFacurasAimprimir = new DataTable();

            dtFacurasAimprimir.Columns.Add("Id_Locacion", typeof(Int32));
            dtFacurasAimprimir.Columns.Add("Id_Comprobantes", typeof(Int32));
            dtFacurasAimprimir.Columns.Add("Punto", typeof(Int32));
            dtFacurasAimprimir.Columns.Add("Numero", typeof(Int32));
            dtFacurasAimprimir.Columns.Add("id_tipo_comprobante", typeof(Int32));

            foreach (DataRow drl in dtLocaciones.Rows)
            {
                drl["saldo"] = 0;
            }

            ///-----------------------------------------------------------
            ///Busca que Locaciones Abono
            foreach (DataRow dr in dt_Movimientos_Pagos.Rows)
            {
                bool tieneSaldo = false;
                foreach (DataRow drl in dtLocaciones.Rows)
                {
                    if (Convert.ToInt32(dr["Id_usuarios_locaciones"].ToString()) == Convert.ToInt32(drl["id"]))
                    {
                        /// linea de subservicio suma por locacion
                        if (Convert.ToInt32(dr["encabezado"].ToString()) == 0)
                        {
                            if (Convert.ToDecimal(dr["Importe_pago"].ToString()) != 0 && tieneSaldo == false)
                            {
                                drl["saldo"] = Convert.ToDecimal(drl["saldo"].ToString());
                                tieneSaldo = true;
                            }
                            drl["saldo"] = Convert.ToDecimal(drl["saldo"].ToString()) + Convert.ToDecimal(dr["Importe_pago"].ToString());
                        }

                        ///Linea del comprobante - Verifica si es factura o C de Deuda

                        if (Convert.ToInt32(dr["encabezado"].ToString()) == 2)
                        {
                            if (Convert.ToInt32(dr["Id_Comprobantes_Tipo"].ToString()) != Convert.ToInt32(Comprobantes_Tipo.Tipo.CREDITO_A_CUENTA)) // no debe ni generar ni imprimir factura
                            {
                                if (Convert.ToInt32(dr["presenta_ventas"].ToString()) == 0) // debe generar factura
                                    drl["Genera_Factura"] = 1;
                                else // ya es una factura y debe reimprimirla
                                {
                                    if (dr["tipo"].ToString() != "C")
                                    {
                                        // "C" es un credito a cuenta temporal  genera an  Genera_Comprobante_Credito(); al pagar de mas
                                        dtFacurasAimprimir.Rows.Add(Convert.ToInt32(drl["id"]), Convert.ToInt32(dr["Id_comprobantes"].ToString()), Convert.ToInt32(dr["Punto"].ToString()), Convert.ToInt32(dr["Numero"].ToString()), Convert.ToInt32(dr["id_comprobantes_tipo"]));
                                        int idCtacte = Convert.ToInt32(dr["id_usuarios_ctacte"]);
                                        DataTable dtNotasDebito = oUsuCtaCte.ListarDatosNotaDebito(idCtacte);
                                        if (dtNotasDebito.Rows.Count > 0)
                                        {
                                            dtFacurasAimprimir.Rows.Add(Convert.ToInt32(drl["id"]), Convert.ToInt32(dtNotasDebito.Rows[0]["Id_comp_notadebito_asociada"]), Convert.ToInt32(dtNotasDebito.Rows[0]["punto_venta"]), Convert.ToInt32(dtNotasDebito.Rows[0]["Numero"]), Convert.ToInt32(dtNotasDebito.Rows[0]["tipo"]));


                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                
            }


            string NumeroFactura = "";

            foreach (DataRow dr in dtLocaciones.Rows) ////divide por locaciones
            {

                int idLocacion = Convert.ToInt32(dr["id"]);

                Usuarios.CurrentUsuario.localidad = dr["localidad"].ToString();
                Usuarios.CurrentUsuario.Cod_postal = dr["codigo_postal"].ToString();
                Usuarios.CurrentUsuario.Calle = dr["calle"].ToString();
                Usuarios.CurrentUsuario.Altura = Convert.ToInt32(dr["Altura"].ToString());
                Usuarios.CurrentUsuario.piso = dr["piso"].ToString();
                Usuarios.CurrentUsuario.Depto = dr["depto"].ToString();
                Usuarios.CurrentUsuario.Entre1 = dr["entre_calle_1"].ToString();
                Usuarios.CurrentUsuario.Entre2 = dr["entre_calle_2"].ToString();

                if (Convert.ToDecimal(dr["saldo"].ToString()) != 0)
                {


                    ///////////////////////////////////////////////
                    // Filtra los moviemientos abonados por locacion
                    DataView ViewAbonadosLocacion = Pagos.DefaultView;
                    ViewAbonadosLocacion.RowFilter = string.Format("Id_usuarios_locaciones = {0} ", Convert.ToInt32(dr["id"]));
                    DataTable dtAbonadosLocacion = ViewAbonadosLocacion.ToTable();

                    ///////////////////////////////////////////////
                    // Filtra todos los movimientos por locacion
                    DataView ViewDetallesLocacion = dtCtaCteDetfinal.DefaultView;
                    ViewAbonadosLocacion.RowFilter = string.Format("Id_usuarios_locaciones = {0} ", Convert.ToInt32(dr["id"]));
                    DataTable dtDetallesLocacion = ViewDetallesLocacion.ToTable();

                    string NumeroString;

                    Int32 NroRecibo, PtoRecibo;
                    if (cuenta == 1)
                    {
                        foreach (DataRow drFacAnt in dtFacurasAimprimir.Rows) //reimprime si hay facturas en el pago
                        {
                            if (Convert.ToInt32(drFacAnt["Id_locacion"].ToString()) == Convert.ToInt32(dr["id"]))
                            {
                               if (this.idCobrador == 0)
                                {
                                    string mensajeImprime = "";
                                    if (Convert.ToInt32(drFacAnt["id_tipo_comprobante"]) == (int)Comprobantes_Tipo.Tipo.FACTURA_A || Convert.ToInt32(drFacAnt["id_tipo_comprobante"]) == (int)Comprobantes_Tipo.Tipo.FACTURA_B)
                                        mensajeImprime = "¿Desea imprimir la factura?";
                                    else if (Convert.ToInt32(drFacAnt["id_tipo_comprobante"]) == (int)Comprobantes_Tipo.Tipo.NOTA_DEBITO_A || Convert.ToInt32(drFacAnt["id_tipo_comprobante"]) == (int)Comprobantes_Tipo.Tipo.NOTA_DEBITO_B)
                                        mensajeImprime = "¿Desea imprimir la nota de debito?";

                                    if (MessageBox.Show(mensajeImprime, "Mensaje de Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                    {
                                        bool impDirecto = !(new Configuracion().GetValor_N("PreviewRecibos") == 1 ? true : false);
                                        oImpresion.Imprime_factura_RDLC(imprimirDirecto: impDirecto, Convert.ToInt32(drFacAnt["Id_comprobantes"].ToString()));
                                    }
                                }
                                if (Convert.ToInt32(drFacAnt["id_tipo_comprobante"]) == (int)Comprobantes_Tipo.Tipo.FACTURA_A || Convert.ToInt32(drFacAnt["id_tipo_comprobante"]) == (int)Comprobantes_Tipo.Tipo.FACTURA_B)
                                {
                                    Ofacturacion.Punto_Venta = Convert.ToInt32(drFacAnt["Punto"].ToString());
                                    Ofacturacion.Numero = Convert.ToInt32(drFacAnt["Numero"].ToString());
                                    Ofacturacion.NumeroMuestra = NumeroString = Ofacturacion.Punto_Venta.ToString().PadLeft(4, '0') + "-" + Ofacturacion.Numero.ToString().PadLeft(8, '0');
                                    NumeroFactura = Ofacturacion.NumeroMuestra;
                                }


                            }
                        }
                        //si es una cuota de un plan de pago de una deuda que ya es factura no debe generar la factura

                        DataView dvCoutasCtate = dtDetallesLocacion.DefaultView;
                        dvCoutasCtate.RowFilter = "elige=true";
                        DataTable dtCuotasElegidos = dvCoutasCtate.ToTable();
                        int idCtacte = 0;
                        string mensaje = "";
                        foreach (DataRow ctactedet in dtCuotasElegidos.Rows)
                        {
                            idCtacte = Convert.ToInt32(ctactedet["id_usuarios_ctacte"]);
                            if (Ofacturacion.PlanDePagoFactura(idCtacte, out mensaje) == true)
                            {
                                ctactedet["elige"] = true;
                            }
                        }
                        if (mensaje == "")
                        {
                            if (Convert.ToInt32(dr["Genera_Factura"].ToString()) == 1)
                            {
                                //dtDetallesLocacion.Rows[0]["CalcularPercepcion"] = 0;
                                DataTable dtRespuestaFactura;
                                dtRespuestaFactura = Ofacturacion.Comprobante_a_Factura(Ofacturacion, dtDetallesLocacion, idLocacion, nroPuntoVenta, permitirHacerRemito: true, facturaDeCredito: false);
                                int contadorRespuestas = dtRespuestaFactura.Rows.Count;
                                Int32 codigoRetorno = Convert.ToInt16(dtRespuestaFactura.Rows[dtRespuestaFactura.Rows.Count - 1]["respuesta_codigo"]);
                                string mensajeRespuesta = dtRespuestaFactura.Rows[0]["respuesta_descripcion"].ToString();

                                if (codigoRetorno == Convert.ToInt32(Facturacion.CODIGOS_RESPUESTA_FACTURACION.NO_SE_REALIZARON_MODIFICACIONES))
                                {
                                    if (oConfig.GetValor_N("ModPuntoGestion") == 2)
                                    {
                                        DialogResult result = MessageBox.Show($"No se pudo completar el pago, hubo un problema con la afip\nError: {mensajeRespuesta}\n¿Desea cambiar el punto de venta?", "Mensaje del sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                        if (result == DialogResult.Yes)
                                        {
                                            using (frmPopUp frm = new frmPopUp())
                                            {
                                                frm.Formulario = new frmCambioPuntosVenta();
                                                frm.Maximizar = false;
                                                if (frm.ShowDialog() == DialogResult.OK)
                                                    comenzarCarga();
                                            }
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show($"No se pudo completar el pago, hubo un problema con la afip\nError: {mensajeRespuesta}", "Mensaje del sistema");
                                    }
                                    return;
                                }

                                if (contadorRespuestas > 1)
                                {
                                    Log.guardarEvento(Log.ACCION.AFIP, idusuario, idlocacion, 0, dtRespuestaFactura.Rows[0]["respuesta_descripcion"].ToString());
                                    String remito = dtRespuestaFactura.Rows[contadorRespuestas - 1]["respuesta_descripcion"].ToString();
                                    MessageBox.Show("Hubo un error al generar la facura, se genero un remito ", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                }

                                if (this.idCobrador == 0)
                                {
                                    if (codigoRetorno == 0)
                                    {
                                        if (MessageBox.Show("¿Desea imprimir Factura?", "Mensaje del sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                        {
                                            bool impDirecto = !(new Configuracion().GetValor_N("PreviewRecibos") == 1 ? true : false);
                                            oImpresion.Imprime_factura_RDLC(imprimirDirecto: impDirecto, Ofacturacion.Id_Comprobantes);
                                        }
                                        NumeroFactura = dtRespuestaFactura.Rows[0]["factura_descripcion"].ToString();
                                    }
                                    else
                                    {
                                        if (MessageBox.Show("¿Desea imprimir el remito?", "Mensaje del sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                        {
                                            bool impDirecto = !(new Configuracion().GetValor_N("PreviewRecibos") == 1 ? true : false);
                                            oImpresion.Imprime_factura_RDLC(imprimirDirecto: impDirecto, Ofacturacion.Id_Comprobantes);
                                        }
                                    }
                                }
                            }
                        }
                    }

                    if (Recibo_tipo == 1) // Recibo con numero propios - Imprimre recibo y facturas
                    {
                        DataRow drDatosComprobante;
                        if (cuenta == 1)
                        {
                            if (idCobrador != 0)
                                drDatosComprobante = oComprobante_Tipo.GetNumeracion(Convert.ToInt32(Comprobantes_Tipo.Tipo.RECIBO_COBRADOR), this.idCobrador);
                            else
                                drDatosComprobante = oComprobante_Tipo.GetNumeracion(Convert.ToInt32(Comprobantes_Tipo.Tipo.RECIBO), Puntos_Cobros.Id_Punto);
                        }
                        else
                        {
                            if (idCobrador != 0)
                                drDatosComprobante = oComprobante_Tipo.GetNumeracion(Convert.ToInt32(Comprobantes_Tipo.Tipo.RECIBO_COBRADOR_INTERNO), this.idCobrador);
                            else
                                drDatosComprobante = oComprobante_Tipo.GetNumeracion(Convert.ToInt32(Comprobantes_Tipo.Tipo.RECIBO_INTERNO), Puntos_Cobros.Id_Punto);
                        }
                        /// true = pago en negro


                        NroRecibo = vieneCobrador == 0 ? Convert.ToInt32(drDatosComprobante["numComprobante"]) : Convert.ToInt32(dtDetalleReciboCobrador.Rows[0]["numero"]);

                        PtoRecibo = Convert.ToInt32(drDatosComprobante["numPuntoVenta"]);
                        NumeroString = PtoRecibo.ToString().PadLeft(4, '0') + "-" + NroRecibo.ToString().PadLeft(8, '0');

                        if (cuenta == 1)
                        {
                            if (this.idCobrador != 0)
                                oComprobante_Tipo.SetNumeracion(Convert.ToInt32(drDatosComprobante["idPuntoVenta"]), Convert.ToInt32(Comprobantes_Tipo.Tipo.RECIBO_COBRADOR), NroRecibo);
                            else
                                oComprobante_Tipo.SetNumeracion(Convert.ToInt32(drDatosComprobante["idPuntoVenta"]), Convert.ToInt32(Comprobantes_Tipo.Tipo.RECIBO), NroRecibo);
                        }
                        else
                        {
                            if (this.idCobrador != 0)
                                oComprobante_Tipo.SetNumeracion(Convert.ToInt32(drDatosComprobante["idPuntoVenta"]), Convert.ToInt32(Comprobantes_Tipo.Tipo.RECIBO_COBRADOR_INTERNO), NroRecibo);
                            else
                                oComprobante_Tipo.SetNumeracion(Convert.ToInt32(drDatosComprobante["idPuntoVenta"]), Convert.ToInt32(Comprobantes_Tipo.Tipo.RECIBO_INTERNO), NroRecibo);
                        }

                    }
                    else // La factura es el recibo
                    {
                        if (cuenta == 1)
                        {
                            NroRecibo = Ofacturacion.Numero;
                            PtoRecibo = Ofacturacion.Punto_Venta;
                            NumeroString = Ofacturacion.NumeroMuestra; // .Descripcion;
                        }
                        else
                        {
                            DataRow drDatosComprobante;
                            if (this.idCobrador != 0)
                                drDatosComprobante = oComprobante_Tipo.GetNumeracion(Convert.ToInt32(Comprobantes_Tipo.Tipo.RECIBO_COBRADOR_INTERNO), this.idCobrador);
                            else
                                drDatosComprobante = oComprobante_Tipo.GetNumeracion(Convert.ToInt32(Comprobantes_Tipo.Tipo.RECIBO_INTERNO), Puntos_Cobros.Id_Punto);
                            NroRecibo = Convert.ToInt32(drDatosComprobante["numComprobante"]);
                            PtoRecibo = Convert.ToInt32(drDatosComprobante["numPuntoVenta"]);
                            NumeroString = PtoRecibo.ToString().PadLeft(4, '0') + "-" + NroRecibo.ToString().PadLeft(8, '0');


                            //if (this.idCobrador != 0)
                            //    //oComprobante_Tipo.SetNumeracion(Convert.ToInt32(drDatosComprobante["idPuntoVenta"]), Convert.ToInt32(Comprobantes_Tipo.Tipo.RECIBO_COBRADOR_INTERNO), NroRecibo);
                            //else
                            //oComprobante_Tipo.SetNumeracion(Convert.ToInt32(drDatosComprobante["idPuntoVenta"]), Convert.ToInt32(Comprobantes_Tipo.Tipo.RECIBO_INTERNO), NroRecibo);

                            if (this.idCobrador != 0)
                                oComprobante_Tipo.SetNumeracion(Convert.ToInt32(drDatosComprobante["idPuntoVenta"]), Convert.ToInt32(dtDetalleReciboCobrador.Rows[0]["numero"]), NroRecibo);
                            else
                                oComprobante_Tipo.SetNumeracion(Convert.ToInt32(drDatosComprobante["idPuntoVenta"]), Convert.ToInt32(Comprobantes_Tipo.Tipo.RECIBO_INTERNO), NroRecibo);
                        }
                    }

                    oComprobante.Id_Usuarios = Usuarios.CurrentUsuario.Id;
                    oComprobante.Fecha = DateTime.Today;
                    oComprobante.Punto_Venta = PtoRecibo;
                    oComprobante.Numero = NroRecibo;
                    if (cuenta == 1)
                    {
                        if (this.idCobrador != 0)
                            oComprobante.Id_Comprobantes_Tipo = (int)Comprobantes_Tipo.Tipo.RECIBO_COBRADOR;
                        else
                            oComprobante.Id_Comprobantes_Tipo = (int)Comprobantes_Tipo.Tipo.RECIBO;
                    }
                    else
                    {
                        if (this.idCobrador != 0)
                            oComprobante.Id_Comprobantes_Tipo = (int)Comprobantes_Tipo.Tipo.RECIBO_COBRADOR_INTERNO;
                        else
                            oComprobante.Id_Comprobantes_Tipo = (int)Comprobantes_Tipo.Tipo.RECIBO_INTERNO;
                    }
                    oComprobante.Importe = Convert.ToDecimal(dr["saldo"].ToString());
                    oComprobante.Id = oComprobante.Guardar(oComprobante);

                    Ousuarios_CtaCte_Recibos.Descripcion = Ofacturacion.Descripcion;
                    Ousuarios_CtaCte_Recibos.Id_Usuarios = Usuarios.CurrentUsuario.Id;
                    Ousuarios_CtaCte_Recibos.Id_Usuarios_Locacion = idLocacion;
                    Ousuarios_CtaCte_Recibos.Fecha_Movimiento = FechaRecibo;
                    if (this.idCobrador != 0)
                    {
                        Ousuarios_CtaCte_Recibos.Id_Caja_Diaria = this.idCaja;
                        Ousuarios_CtaCte_Recibos.Importe_Final = Convert.ToDecimal(dr["saldo"].ToString()); // +Total_recibo;
                    }
                    else
                        Ousuarios_CtaCte_Recibos.Importe_Final = Total_recibo;

                    Ousuarios_CtaCte_Recibos.Id_Comprobantes = oComprobante.Id;
                    Ousuarios_CtaCte_Recibos.Numero_Muestra = "Recibo Nro " + NumeroString;
                    Ousuarios_CtaCte_Recibos.Numero = NroRecibo;
                    Ousuarios_CtaCte_Recibos.Id_Usuarios_Locacion = idLocacion;
                    Ousuarios_CtaCte_Recibos.Id_Presentacion_Deb = 0;
                    Ousuarios_CtaCte_Recibos.Id_Puntos_Cobro = Puntos_Cobros.Id_Punto;

                    DataView dtvAbonadosLocacion = new DataView(dtAbonadosLocacion);
                    dtvAbonadosLocacion.RowFilter = String.Format("elige=true");

                    DataTable dtAbonadosSeleccion = ViewAbonadosLocacion.ToTable();


                    foreach (DataRow drn in dtAbonadosSeleccion.Rows) //renombra servicio para que el recibo grabe el nro de factura
                    {
                        if (NumeroFactura.Length != 0 && Convert.ToInt32(drn["presenta_ventas"].ToString()) == 0)
                            drn["servicio"] = NumeroFactura;
                    }

                    DataView dvFiltrarTrues = dtAbonadosSeleccion.DefaultView;
                    dvFiltrarTrues.RowFilter = "elige=true";
                    DataTable dtFiltrada = dvFiltrarTrues.ToTable();

                    string salida = "";
                    if (this.vieneCobrador != 0)
                        Ousuarios_CtaCte_Recibos.guardar(Ousuarios_CtaCte_Recibos, dtDetalleRecibo, dtFiltrada, cuenta, out salida, idCobrador, idusuarioctacterecibo);
                    else
                        Ousuarios_CtaCte_Recibos.guardar(Ousuarios_CtaCte_Recibos, dtDetalleRecibo, dtFiltrada, cuenta, out salida);

                    //   if (cuenta == 1)
                    //   {
                    oImpresion.Punto = PtoRecibo;
                    oImpresion.Numero = NroRecibo;
                    oImpresion.NumeroMuestra = NumeroString;
                    oImpresion.Fecha = DateTime.Now;

                    if (Recibo_tipo == 1 && idCobrador == 0)// Recibo con numero propios - Imprimre recibo y facturas
                    {
                        //if (!System.Diagnostics.Debugger.IsAttached)
                        Imprime_recibo(oComprobante.Id);
                    }


                    //  }
                }
            }
            if (vieneCobrador != 0)
            {
                OPuntos_cobro.ActualizarSaldoCobrador(this.idComprobanteCobrador, this.TotalPagoCobrador);
            }

            if (Total_recibo > montoTotal) // pago superior queda a cuenta 
            {
                Decimal Montoacuenta = Total_recibo - montoTotal;
                Genera_Comprobante_Credito(Montoacuenta);
            }
              

            this.Close();

        }

        private void Genera_Comprobante_Credito(Decimal ImporteCuenta)
        {
            DataRow drDatosComprobante = oComprobante_Tipo.GetNumeracion(Convert.ToInt32(Comprobantes_Tipo.Tipo.CREDITO_A_CUENTA), Puntos_Cobros.Id_Punto);
            oComprobante_Tipo.SetNumeracion(Convert.ToInt32(drDatosComprobante["idPuntoVenta"]), Convert.ToInt32(Comprobantes_Tipo.Tipo.CREDITO_A_CUENTA), Convert.ToInt32(drDatosComprobante["numComprobante"]));

            //---carga de comprobante
            oComprobante.Id_Usuarios = Usuarios.CurrentUsuario.Id;
            oComprobante.Fecha = DateTime.Today;
            oComprobante.Punto_Venta = Convert.ToInt32(drDatosComprobante["numPuntoVenta"]);
            oComprobante.Id_Comprobantes_Tipo = Convert.ToInt32(Comprobantes_Tipo.Tipo.CREDITO_A_CUENTA);
            oComprobante.Numero = Convert.ToInt32(drDatosComprobante["numComprobante"]);
            oComprobante.Importe = ImporteCuenta * -1;
            oComprobante.Id_Usuarios_Locaciones = Convert.ToInt32(dtCtaCteDetfinal.Rows[0]["id_usuarios_locaciones"].ToString());

            oComprobante.Id = oComprobante.Guardar(oComprobante);
            //--------------------------------------------------------------------

            //----carga de cuenta corriente--------------------
            oUsuCtaCte.Id_Usuarios = Usuarios.CurrentUsuario.Id;
            oUsuCtaCte.Id_Comprobantes = oComprobante.Id;
            oUsuCtaCte.Fecha_Movimiento = DateTime.Today;
            oUsuCtaCte.Fecha_Desde = DateTime.Today;
            oUsuCtaCte.Fecha_Hasta = DateTime.Today;

            string muestra;
            muestra = "CREDITO A CUENTA " + 0.ToString().PadLeft(4, '0') + "-" + oUsuCtaCte.Id_Comprobantes.ToString().PadLeft(8, '0');
            oUsuCtaCte.Descripcion = muestra;

            oUsuCtaCte.Importe_Original = oComprobante.Importe;
            oUsuCtaCte.Importe_Punitorio = 0;
            oUsuCtaCte.Importe_Bonificacion = 0;


            oUsuCtaCte.Importe_Final = oComprobante.Importe;
            oUsuCtaCte.Importe_Saldo = oComprobante.Importe;
            oUsuCtaCte.Id_Usuarios_Locacion = Convert.ToInt32(dtCtaCteDetfinal.Rows[0]["id_usuarios_locaciones"].ToString());
            oUsuCtaCte.Numero = oComprobante.Numero.ToString();
            oUsuCtaCte.Id_Comprobantes_Tipo = Convert.ToInt32(Comprobantes_Tipo.Tipo.CREDITO_A_CUENTA);
            oUsuCtaCte.Id_Comprobantes_Ref = oComprobante.Id;
            oUsuCtaCte.Id_Facturacion = 0;
            oUsuCtaCte.Generado_facturacion_mensual = Convert.ToInt32(Usuarios_CtaCte.GENERADO_FACTURACION_MENSUAL.NO);
            oUsuCtaCte.Id_Personal = Personal.Id_Login;
            oUsuCtaCte.Id_Origen = (int)Usuarios_CtaCte.ORIGEN.CTACTE;
            oUsuCtaCte.Guardar(oUsuCtaCte);


            oUsuCtaCteDet.Id_Usuarios_CtaCte = oUsuCtaCte.Id;
            oUsuCtaCteDet.Id_Usuarios_Locaciones = Convert.ToInt32(dtCtaCteDetfinal.Rows[0]["id_usuarios_locaciones"].ToString());
            oUsuCtaCteDet.Id_Zonas = 0;
            oUsuCtaCteDet.Id_Servicios = 0;
            oUsuCtaCteDet.Id_Tipo = 1;
            oUsuCtaCteDet.Tipo = "S";
            oUsuCtaCteDet.Importe_Original = oComprobante.Importe;
            oUsuCtaCteDet.Importe_Saldo = oComprobante.Importe;
            oUsuCtaCteDet.Importe_Bonificacion = 0;
            oUsuCtaCteDet.Importe_Punitorio = 0;
            oUsuCtaCteDet.Fecha_Desde = DateTime.Today;
            oUsuCtaCteDet.Fecha_Hasta = DateTime.Today;

            oUsuCtaCteDet.Id_Usuarios_Servicios = 0;
            oUsuCtaCteDet.Id_Velocidades = 0;
            oUsuCtaCteDet.Id_Velocidades_Tip = 0;
            oUsuCtaCteDet.Requiere_IP = 0;
            oUsuCtaCteDet.Cantidad_Periodos = 0;

            oUsuCtaCteDet.Id_bonificacion_Aplicada = 0;
            oUsuCtaCteDet.Nombre_Bonificacion = String.Empty;
            oUsuCtaCteDet.Periodo_Ano = oUsuCtaCteDet.Fecha_Desde.Year;
            oUsuCtaCteDet.Periodo_Mes = oUsuCtaCteDet.Fecha_Desde.Month;
            oUsuCtaCteDet.Porcentaje_Bonificacion = 0;
            oUsuCtaCteDet.Detalles = " Credito ";

            oUsuCtaCteDet.Guardar(oUsuCtaCteDet);

            DataRow dro;
            dro = dtCtaCteDetfinal.NewRow();
            dro["servicio"] = muestra;
            dro["importe_pago"] = oComprobante.Importe;
            dro["importe_total"] = oComprobante.Importe;
            dro["importe_punitorio"] = 0;
            dro["importe_bonificacion"] = 0;

            dro["importe_provincial"] = 0;
            dro["presenta_ventas"] = 1;

            dro["id_tipo"] = 0;
            dro["tipo"] = "C";
            dro["id_usuarios_servicios"] = 0;
            dro["id_usuarios_ctacte"] = oUsuCtaCte.Id;
            dro["id"] = oUsuCtaCteDet.Id;
            dro["id_servicios"] = 0;
            dro["fecha_desde"] = DateTime.Now;
            dro["fecha_hasta"] = DateTime.Now;
            dro["importe_saldo"] = 0;
            dro["elige"] = true;
            dro["encabezado"] = 0;
            dro["id_usuarios_locaciones"] = Convert.ToInt32(dtCtaCteDetfinal.Rows[0]["id_usuarios_locaciones"].ToString());
            dro["id_usuarios"] = Convert.ToInt32(dtCtaCteDetfinal.Rows[0]["id_usuarios"].ToString());
            dro["Id_Comprobantes"] = 0;
            dro["Id_Comprobantes_Tipo"] = Convert.ToInt32(Comprobantes_Tipo.Tipo.CREDITO_A_CUENTA);
            dro["Id_Comprobantes_nuevo"] = 0; // s

            dtCtaCteDetfinal.Rows.Add(dro);

        }

        private void Genera_Pago()
        {
            if (Puntos_Cobros.Id_Punto > 0)
            {
                dtDetalleRecibo.Clear();
                Total_recibo = 0;
                string salida = "";
                if (vieneCobrador != 0)
                {
                    Total_recibo = this.TotalPagoCobrador;

                    dtDetalleRecibo = dtDetalleReciboCobrador;
                    if (dtDetalleReciboCobrador.Rows.Count == 0)
                    {
                        DataRow drNueva = dtDetalleRecibo.NewRow();
                        drNueva["Id_formas_de_pago"] = 0;
                        drNueva["Id_usuarios_locaciones"] = 0;
                        dtDetalleRecibo.Rows.Add(drNueva);
                    }
                    dtNotaDebito = generarDtNotaDebito();
                    Ofacturacion.GenerarNotasDebito(dtNotaDebito, Personal.Id_Punto_Venta, out salida);
                    if (salida == "")
                        oUsuCtaCte.ActualizarIdNotaDebitoEnCtacte(dtNotaDebito);
                    else
                        MessageBox.Show($"Error al generar las notas de debito: {salida}", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    agregarpago();
                }
                else
                {
                    frmUsuariosPagos frm = new frmUsuariosPagos(edicion: false, montoTotal, this.Locacion_Id, Usuarios.CurrentUsuario.Id, cuenta);
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        flag = 1;
                        cuenta = frm.cuenta;
                        if (cuenta == 1)
                            lbCuenta.Visible = false;
                        else if (cuenta == 2)
                            lbCuenta.Visible = true;
                        Total_recibo = frm.Total_Recibo;
                        dtDetalleRecibo = frm.dtDetalleRecibo;
                        this.nroPuntoVenta = frm.nroPuntoVenta;
                        dtNotaDebito = generarDtNotaDebito();
                        Ofacturacion.GenerarNotasDebito(dtNotaDebito, Personal.Id_Punto_Venta, out salida);
                        if (salida == "")
                            oUsuCtaCte.ActualizarIdNotaDebitoEnCtacte(dtNotaDebito);
                        else
                            MessageBox.Show($"Error al generar las notas de debito: {salida}", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //agregarpago();

                        /*DataTable dtPartesAbiertos = new Partes().ListarPartesAbiertos(idlocacion, Convert.ToInt32(Partes.Partes_Operaciones.CORTE));
                        if (dtPartesAbiertos.Rows.Count > 0)
                        {
                            MessageBox.Show("El usuario posee partes de corte abiertos, a continuacion se mostraran para que puedan ser anulados.", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            frmPopUp popUp = new frmPopUp();
                            popUp.Formulario = new frmListadoPartesCortesAbierto(idusuario);
                            popUp.Maximizar = false;
                            popUp.ShowDialog();
                        }
                        */

                        //DATOS APP EXTERNAS PARA PREPAGOS..
                        if (Convert.ToInt32(oConfig.GetValor_N("CassServPeriodo")) == (int)Aplicaciones_Externas.GENERA_ACCIONES_SERVICIOS_PERIODOS.PAGA_COMPROBANTE)
                        {
                            int idUsuarioServicio = 0, idServicio = 0, idTipoServicio = 0, idUsuarioServicioAux = 0 , idCtacte =0;

                            DataTable getInfo = dtCtaCteDetfinal.Copy();
                            DataView ViewAbonados = getInfo.DefaultView;
                            ViewAbonados.RowFilter = string.Format("elige = {0} and id_usuarios_servicios > {1} ", true, 0);
                            DataRow drServicio;
                            DataTable getInfoSeleccionada = ViewAbonados.ToTable();
                            DataTable dtUsuServ = new DataTable();

                            getInfoSeleccionada = getInfoSeleccionada.AsEnumerable()
                            .GroupBy(r => new { Col1 = r["id_usuarios_servicios"]})
                            .Select(g => g.OrderBy(r => r["id_usuarios_servicios"]).First())
                            .CopyToDataTable();

                            foreach (DataRow dr in getInfoSeleccionada.Rows)
                            {
                                drServicio = oServ.getInfoServicio(Convert.ToInt32(dr["id_servicios"]));
                                if(  (Convert.ToInt32(drServicio["id_servicios_modalidad"]) == (int)Servicios._Modalidad.DIA ) && (Convert.ToInt32(drServicio["id_aplicaciones_externas"]) > 0))
                                {
                                    idUsuarioServicio = Convert.ToInt32(dr["id_usuarios_servicios"]);
                                    idServicio = Convert.ToInt32(drServicio["id"]);
                                    idTipoServicio = Convert.ToInt32(drServicio["id_servicios_tipos"]);
                                    idCtacte = Convert.ToInt32(dr["id_usuarios_ctacte"]);
                                    dtUsuServ = oUsuServ.getUsuServData(idUsuarioServicio);
                                    if(dtUsuServ.Rows.Count > 0)
                                    {
                                        if(oEqui.verificarUsuario_Equipo_Tarjeta(idUsuarioServicio) == 1)
                                        {
                                            generaGestionAppexternas(idUsuarioServicio, idServicio, idTipoServicio, idusuario, Convert.ToDateTime(dtUsuServ.Rows[0]["fecha_inicio"]), Convert.ToDateTime(dtUsuServ.Rows[0]["fecha_fin"]), idlocacion,idCtacte);
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        this.cuenta = frm.cuenta;
                        if (cuenta == 1)
                            lbCuenta.Visible = false;
                        else if (cuenta == 2)
                            lbCuenta.Visible = true;
                    }
                }
            }
            else
                MessageBox.Show("Usuario de sistema sin atributos");
        }

        private void generaGestionAppexternas(int idUsuarioServicio,int idServicio,int idTipoServicio,int idUsuario,DateTime fechaDesde,DateTime fechaHasta,int idLocacionRecibidaSeleccionada,int idCtacte)
        {
            string resultadoFinal = "", resultadoFinalAccion = "";

            if (Convert.ToInt32(oConfig.GetValor_N("CassServPeriodo")) == (int)Aplicaciones_Externas.GENERA_ACCIONES_SERVICIOS_PERIODOS.PAGA_COMPROBANTE)
            {
                DialogResult dialogResult = MessageBox.Show("¿Desea activar los paquetes de la Aplicacion Externa?", "Mensaje del Sistema.-", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    using (frmPopUp frm = new frmPopUp())
                    {
                        AppExternas.frmPrepagosAppExternas oExterna = new AppExternas.frmPrepagosAppExternas();
                        oExterna.id_servicio = idServicio;
                        oExterna.id_tipo_servicio = idTipoServicio;
                        oExterna.id_usuario = idUsuario;
                        oExterna.fecha_desde = fechaDesde;
                        oExterna.fecha_hasta = fechaHasta;
                        oExterna.fecha_corte = fechaHasta;
                        oExterna.id_locacion = idLocacionRecibidaSeleccionada;
                        oExterna.id_ctacte_global = idCtacte;
                        oExterna.id_usuario_servicio = idUsuarioServicio;
                        oExterna.vieneRecibos = true;
                        frm.Formulario = oExterna;
                        frm.Maximizar = false;
                        frm.ShowDialog();
                    }
                }
            }
        }

        private void btnConfirma_Click(object sender, EventArgs e)
        {
            DataTable dtRegistrosSeleccionados = new DataTable();
            dtRegistrosSeleccionados = GenerarDtRegistrosGrillaCtaCte();
            if (dtRegistrosSeleccionados.Rows.Count > 0)
            {
                GenerarRegistrosDeudasAnexadas();//actualiza la variable tienedebitp
                if (tieneDebito == false)
                    Genera_Pago();
                else
                    MessageBox.Show("No se pueden seleccionar deudas que estan asociadas a un debito automático.", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Stop);

            }
            else
                MessageBox.Show("No se han seleccionado registros de la grilla.");
        }

        private void Imprime_recibo(Int32 IdCo)
        {
            oImpresion.Imprime_Recibo(IdCo, cuenta);
        }

        #endregion

        public frmUsuariosCtaCte(int idUsuario, int idLocacion)
        {
            InitializeComponent();

            Cta_seleccion = oConfig.GetValor_N("Cta_Seleccion");
            Recibo_tipo = oConfig.GetValor_N("Cta_Comprobante_De_Pago");

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
            dtDetalleRecibo.Columns.Add("Numero", typeof(Int32));
            dtDetalleRecibo.Columns.Add("Id_formas_de_pago", typeof(Int32));
            dtDetalleRecibo.Columns.Add("Id_usuarios_locaciones", typeof(Int32));

            this.idusuario = idUsuario;
            this.idlocacion = idLocacion;
            if (cuenta == 1)
                lbCuenta.Visible = false;

            if (cuenta == 2)
                lbCuenta.Visible = true;

        }

        private void btnBonificarPuni_Click(object sender, EventArgs e)
        {
            if (dgvCtaCteDet.Rows.Count == 0 && dgvCtaCteDet.SelectedRows.Count == 0)
                return;

            foreach (DataRow item in dtCtaCteDetfinal.Rows)
            {
                if (Convert.ToBoolean(item["elige"]))
                {
                    idCtacte = Convert.ToInt32(item["id_usuarios_ctacte"]);
                    if (!comprobantesSeleccionados.Contains(idCtacte))
                        comprobantesSeleccionados.Add(idCtacte);
                }
            }

            if(comprobantesSeleccionados.Count == 0)
            {
                MessageBox.Show("Es necesario seleccionar al menos un item para bonificar", "Mensaje del sistema");
                return;
            }

            if(!new Personal_Roles().VerificarSiTienePermiso(Objetos.Acciones.Bonificar_Punitorios))
            {
                frmPersonalResponsable frmPersonalResp = new frmPersonalResponsable(Objetos.Acciones.Bonificar_Punitorios, Entidades.Tabla.Usuarios_Ctacte, comprobantesSeleccionados);
                if (frmPersonalResp.ShowDialog() != DialogResult.OK)
                    return;
            }

            int idUsuarioLocacion = Convert.ToInt32(dgvCtaCteDet.SelectedRows[0].Cells["id_usuarios_locaciones"].Value);
            dtCtaCteDet = oUsuCtaCteDet.ListarCtacteDetConSaldo(bonificacion: true, idUsuarioLocacion: idUsuarioLocacion);
            foreach (Control item in this.Controls)
            {
                if(item.Name!="pgCiruluar")
                    item.Enabled = false;
            }
            BonificarPunitorios();
            foreach (Control item in this.Controls)
                item.Enabled = true;
            cargarDatos();
        }

        private void BonificarPunitorios()
        {
            foreach (Int32 ctacte in comprobantesSeleccionados)
                oPunitorio.RecalcularPunitorio(dtCtaCteDet, ctacte, bonificar: true);
            MessageBox.Show("Punitorios bonificados correctamente", "Mensaje del Sistema", MessageBoxButtons.OK);
        }

        private void btnRecalcularPuni_Click(object sender, EventArgs e)
        {
            if (dgvCtaCteDet.Rows.Count == 0 && dgvCtaCteDet.SelectedRows.Count == 0)
                return;

            frmPopUp popUp = new frmPopUp();
            frmSeleccionarFecha frmSelecFecha = new frmSeleccionarFecha("Fecha hasta");
            popUp.Formulario = frmSelecFecha;
            popUp.Maximizar = false;
            if(popUp.ShowDialog() != DialogResult.OK) return;

            int idCtacte = Convert.ToInt32(dgvCtaCteDet.SelectedRows[0].Cells["id_usuarios_ctacte"].Value);
            if (!new Personal_Roles().VerificarSiTienePermiso(Objetos.Acciones.Recalcular_Punitorios))
            {
                frmPersonalResponsable frmPersonalRespo = new frmPersonalResponsable(Objetos.Acciones.Recalcular_Punitorios, Entidades.Tabla.Usuarios_Ctacte, idCtacte);
                if (frmPersonalRespo.ShowDialog() != DialogResult.OK)
                    return;
            }

            int idUsuarioLocacion = Convert.ToInt32(dgvCtaCteDet.SelectedRows[0].Cells["id_usuarios_locaciones"].Value);
            Usuarios_CtaCte_Det oUsuDet = new Usuarios_CtaCte_Det();
            DataTable dtCtaCteDet = oUsuDet.ListarCtacteDetConSaldo(bonificacion: false, idUsuarioLocacion: idUsuarioLocacion);
            Punitorio oPunitorio = new Punitorio();
            oPunitorio.RecalcularPunitorio(dtCtaCteDet, idCtacte, bonificar: false, frmSelecFecha.FechaSeleccionada);
            cargarDatos();
        }

        private DataTable GenerarRegistrosDeudasAnexadas(bool anexar = false)
        {
            DataTable dt = oUsuCtaCte.GenerarDtDatosCtaCteAjustes();
            List<int> listaIdsCtaCteControl = new List<int>();
            if (dtCtaCteDetfinal.Rows.Count > 0)
            {
                foreach (DataRow fila in dtCtaCteDetfinal.Rows)
                {
                    if (Convert.ToBoolean(fila["elige"]) == true && Convert.ToInt32(fila["encabezado"]) == 0)
                    {
                        if (Convert.ToInt32(fila["id_debito_asociado"]) > 0 && Convert.ToInt32(fila["rechazado"]) == 0)
                        {
                            if (anexar)
                                MessageBox.Show("Deuda ya Anexada, debe marcar esta deuda como rechazada.", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            tieneDebito = true;
                            break;
                        }
                        else
                        {
                            int idctacte = Convert.ToInt32(fila["id_usuarios_ctacte"]);
                            int ctacte_det = Convert.ToInt32(fila["id"]);
                            dt.Rows.Add(Convert.ToInt32(Usuarios_CtaCte.TIPO_REGISTRO_CTACTE.SUBSERVICIO), fila["id_usuarios_ctacte"].ToString(), fila["id_usuarios_servicios"].ToString(), fila["id"].ToString(), fila["id_usuarios"].ToString());
                            listaIdsCtaCteControl.Add(idctacte);
                        }
                    }
                }
            }
            return dt;
        }

        private void btnGeneraComprobantes_Click(object sender, EventArgs e)
        {
            DataTable dtServiciosContratados, dtLocaciones;
            dtServiciosContratados = oUsuServ.ListarServiciosYSubServiciosActivos(Usuarios.CurrentUsuario.Id);
            dtLocaciones = oUsuLoc.ListarLocacionesServicio(Usuarios.CurrentUsuario.Id, 0, true);
            int idLocacionSeleccionada = 0;
            if (dgvLocaciones.SelectedRows.Count > 0)
                idLocacionSeleccionada = Convert.ToInt32(dgvLocaciones.SelectedRows[0].Cells["id"].Value);
            frmGeneraComprobantesManual frm = new frmGeneraComprobantesManual(Usuarios.CurrentUsuario.Id, idLocacionSeleccionada, dtServiciosContratados, dtLocaciones);
            frmPopUp oPop = new frmPopUp();
            oPop.Formulario = frm;
            oPop.Maximizar = true;
            if(oPop.ShowDialog() == DialogResult.OK)
                comenzarCarga();
        }

        private void btnCuentaCorriente_Click(object sender, EventArgs e)
        {
            if (Usuarios.CurrentUsuario.Id != 0)
            {
                try
                {
                    if (dgvLocaciones.SelectedRows.Count > 0)
                    {
                        frmUsuariosCtaCteConsultaNuevo frm = new frmUsuariosCtaCteConsultaNuevo(Usuarios.CurrentUsuario.Id, 0);
                        frmMain.Instance().openForm(frm);
                    }
                }
                catch { }
            }
        }

        private void dgvCtaCteDet_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                int value = Convert.ToInt32(dgvCtaCteDet.Rows[e.RowIndex].Cells["Encabezado"].Value);

                if (dgvCtaCteDet.Rows[e.RowIndex].Cells["expande"].Value.ToString() == "+")
                {
                    if (dgvCtaCteDet.Columns["expande"].Index == e.ColumnIndex)
                        e.CellStyle.ForeColor = Color.Red;
                }

                if (value == 0)
                {
                    e.CellStyle.BackColor = Color.WhiteSmoke;
                    if ((dgvCtaCteDet.Rows[e.RowIndex].Cells["id_debito_asociado"].Value != null && dgvCtaCteDet.Rows[e.RowIndex].Cells["id_debito_asociado"].Value != DBNull.Value) && Convert.ToInt32(dgvCtaCteDet.Rows[e.RowIndex].Cells["id_debito_asociado"].Value) > 0 && Convert.ToInt32(dgvCtaCteDet.Rows[e.RowIndex].Cells["idtiporegistroctactedet"].Value) == Convert.ToInt32(Usuarios_CtaCte_Det.TIPO_REGISTRO_CTACTEDET.DETALLE))
                        e.CellStyle.ForeColor = Color.Red;
                    else if (Convert.ToInt32(dgvCtaCteDet.Rows[e.RowIndex].Cells["idtiporegistroctactedet"].Value) == Convert.ToInt32(Usuarios_CtaCte_Det.TIPO_REGISTRO_CTACTEDET.DETALLE))
                        e.CellStyle.ForeColor = Color.Black;
                    else
                        e.CellStyle.ForeColor = Color.Green;

                    if (Cta_seleccion < 3)
                    {
                        dgvCtaCteDet.Rows[e.RowIndex].Cells["elige"] = new DataGridViewTextBoxCell();
                    }
                }
                else if (value == 1)
                {
                    e.CellStyle.BackColor = Color.Bisque;
                    if (Cta_seleccion < 2)
                    {
                        dgvCtaCteDet.Rows[e.RowIndex].Cells["elige"] = new DataGridViewTextBoxCell();
                    }
                }
                else if (value == 2)
                {
                    e.CellStyle.BackColor = Color.LightSalmon;
                }
            }
            catch {}
        }

        private DataTable GenerarRegistrosDeudasAnexadas_Old()
        {
            DataTable dt = oUsuCtaCte.GenerarDtDatosCtaCteAjustes();
            List<int> listaIdsCtaCteControl = new List<int>();
            if (dtCtaCteDetfinal.Rows.Count > 0)
            {
                foreach (DataRow fila in dtCtaCteDetfinal.Rows)
                {

                    if (Convert.ToBoolean(fila["elige"]) == true && Convert.ToInt32(fila["encabezado"]) == 0 && (Convert.ToInt32(fila["rechazado"]) == 1 && Convert.ToInt32(fila["id_debito_asociado"]) > 0) || (Convert.ToBoolean(fila["elige"]) == true && Convert.ToInt32(fila["rechazado"]) == 0 && Convert.ToInt32(fila["id_debito_asociado"]) == 0))
                    {
                        int idctacte = Convert.ToInt32(fila["id_usuarios_ctacte"]);

                        dt.Rows.Add(Convert.ToInt32(Usuarios_CtaCte.TIPO_REGISTRO_CTACTE.SUBSERVICIO), fila["id_usuarios_ctacte"].ToString(), fila["id_usuarios_servicios"].ToString(), fila["id"].ToString(), fila["id_usuarios"].ToString());
                        listaIdsCtaCteControl.Add(idctacte);
                    }
                }
            }
            return dt;
        }

        private void MostrarInformacionDePuntoDeVenta()
        {
            if (Usuarios.CurrentUsuario.Id_Comprobantes_Iva == (int)Comprobantes_Iva.Tipo.RESPONSABLE_INSCRIPTO)
            {
                DataTable dtPuntosVentas = new Comprobantes_Habilitados().GetDatosPuntoVenta(Convert.ToInt32(Comprobantes_Tipo.Tipo.FACTURA_A), Puntos_Cobros.Id_Punto);
                DataRow[] drs = dtPuntosVentas.Select("predeterminado = 1");
                lblInfoComp.Text = " - FACTURA A";
                lblInfoPuntoCobro.Text = " - Punto Cobro: " + Puntos_Cobros.Name_Punto;
                lblInfoPuntoVenta.Text = " - Punto Venta: " + drs[0]["punto_venta_descripcion"];
            }
            else
            {
                DataTable dtPuntosVentas = new Comprobantes_Habilitados().GetDatosPuntoVenta(Convert.ToInt32(Comprobantes_Tipo.Tipo.FACTURA_B), Puntos_Cobros.Id_Punto);
                DataRow[] drs = dtPuntosVentas.Select("predeterminado = 1");
                lblInfoComp.Text = " - FACTURA B";
                lblInfoPuntoCobro.Text = " - Punto Cobro: " + Puntos_Cobros.Name_Punto;
                lblInfoPuntoVenta.Text = " - Punto Venta: " + drs[0]["punto_venta_descripcion"];
            }
        }

        private void btnAnexarDebito_Click(object sender, EventArgs e)
        {
            DataTable dtRegistrosSeleccionados = new DataTable();
            dtRegistrosSeleccionados = GenerarRegistrosDeudasAnexadas(true);
            if (dtRegistrosSeleccionados.Rows.Count > 0)
            {
                DataTable dtDebitos = oPresentacionDebitos.ListarPlasticosAsociadosAlUsuario(Convert.ToInt32(dtRegistrosSeleccionados.Rows[0]["idusuarios"]));
                if (dtDebitos.Rows.Count > 0)
                {
                    DataTable dtServiciosAsociadosAUnPlastico = new Plasticos_Usuarios().ListarServiciosAsociadosAUnPlastico(Convert.ToInt32(dtDebitos.Rows[0]["id"]));

                    if (dtServiciosAsociadosAUnPlastico.Rows.Count == 0)
                    {
                        MessageBox.Show("No se encontro ningun servicio asociado al plastico", "Mensaje del sistema");
                        return;
                    }

                    List<DateTime> fechasInicioPlasticos = new List<DateTime>();
                    foreach (DataRow row in dtServiciosAsociadosAUnPlastico.Rows)
                    {
                        int idUsuarioServicio = Convert.ToInt32(row["id_usuario_servicio"]);
                        DataTable dtPlasticosServicios = new Plasticos_Usuarios().BuscarPlasticosServicio(idUsuarioServicio);
                        if (dtPlasticosServicios.Rows.Count > 0)
                        {
                            fechasInicioPlasticos.Add(Convert.ToDateTime(dtPlasticosServicios.Rows[0]["fecha_inicio"]));
                        }
                    }

                    DateTime fechaMinima = fechasInicioPlasticos.Min();

                    Debitos_Automaticos.frmDebitosBusqueda frmDebitosBusqueda = new Debitos_Automaticos.frmDebitosBusqueda(dtDebitos);
                    frmPopUp frmpopup = new frmPopUp();
                    frmpopup.Maximizar = false;
                    frmpopup.Formulario = frmDebitosBusqueda;
                    frmpopup.ShowDialog();
                    if (frmDebitosBusqueda.DialogResult == DialogResult.OK)
                    {
                        if (frmDebitosBusqueda.ano < fechaMinima.Year || frmDebitosBusqueda.ano == fechaMinima.Year &&
                           frmDebitosBusqueda.mes < fechaMinima.Month)
                        {
                            MessageBox.Show($"Los servicios asociados al plastico seleccionado inician en una fecha posterior a la fecha ingresada. La fecha minima para anexar es el {fechaMinima.Month} del {fechaMinima.Year}", "Mensaje del sistema");
                            return;
                        }

                        foreach (DataRow fila in dtRegistrosSeleccionados.Rows)
                            oUsuCtaCteDet.ActualizarDebitoPresentacion(Convert.ToInt32(fila["idUsuariosCtaCte"]), Convert.ToInt32(fila["idUsuariosServicios"]), Convert.ToInt32(fila["idUsuariosCtaCteDet"]), frmDebitosBusqueda.idDebitoSeleccionado, frmDebitosBusqueda.mes, frmDebitosBusqueda.ano);

                        MessageBox.Show("Deuda anexada correctamente", "Mensaje del sistema");
                        cargarDatos();
                    }
                }
                else
                    MessageBox.Show("El usuario no se encuentra asociado a ningún débito.", "Mensajde del sistema");
            }
            else
            {
                int cantSinRechazar = 0;
                foreach (DataRow fila in dtRegistrosSeleccionados.Rows)
                {
                    if (Convert.ToInt32(fila["id_origen"]) == 2)
                    {
                        cantSinRechazar++;
                    }
                }
                if (cantSinRechazar > 0)
                    MessageBox.Show("Para anexar una deuda a una futura presentacion debe marcar la deuda como rechazada.", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void btnPlanPago_Click(object sender, EventArgs e)
        {
            GenerarRegistrosDeudasAnexadas();
            if (!tieneDebito)
            {
                //tienen que elegir o solo facturas o solo comprobantes

                DataTable dtRegistrosSeleccionados = new DataTable();
                dtRegistrosSeleccionados = GenerarDtRegistrosGrillaCtaCte();
                if (dtRegistrosSeleccionados.Select(String.Format("idTipoRegistro={0}", Convert.ToInt32(Usuarios_CtaCte.TIPO_REGISTRO_CTACTE.COMPROBANTE))).Length > 0)
                {
                    DataView view = new DataView(dtRegistrosSeleccionados);
                    DataTable distinctValues = view.ToTable(true, "presenta_ventas");
                    if (distinctValues.Rows.Count > 1)
                        MessageBox.Show("No se puede realizar plan de pago de distintos tipos de comprobantes, seleccione solo facturas o comprobantes de deuda.", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    else
                    {
                        //veo si en las deudas que se seleccionaron hay algun comprobante de deuda

                        if ((Usuarios.CurrentUsuario.Id_Comprobantes_Iva == (int)Comprobantes_Iva.Tipo.RESPONSABLE_INSCRIPTO || Usuarios.CurrentUsuario.Id_Comprobantes_Iva == (int)Comprobantes_Iva.Tipo.RESPONSABLE_MONOTRIBUTO) && Convert.ToInt32(distinctValues.Rows[0]["presenta_Ventas"]) == 0)
                            MessageBox.Show("El abonado es Responsable Inscripto o Responsable Monotributo, primero debe pasar a factura y luego generar el plan de pago.", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        else
                        {
                            Int32 idLocacion = Convert.ToInt32(dgvLocaciones.SelectedRows[0].Cells["Id"].Value);
                            Cuenta_Corriente.frmCtaCtePlanesDePago frmPlanesPago = new Cuenta_Corriente.frmCtaCtePlanesDePago(Usuarios.CurrentUsuario.Id, idLocacion, dtRegistrosSeleccionados, dtCtaCteDetfinal);
                            frmPopUp frmpopup = new frmPopUp();
                            frmpopup.Maximizar = false;
                            frmpopup.Formulario = frmPlanesPago;
                            frmpopup.ShowDialog();
                            if (frmPlanesPago.DialogResult == DialogResult.OK)
                                comenzarCarga();
                        }
                    }
                }
                else
                    MessageBox.Show("No se han seleccionado comprobantes");
            }
            else
                MessageBox.Show("No se pueden hacer un plan de pago a deudas que estan asociadas a un debito automático.", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }

        private void btnBonificacion_Click_1(object sender, EventArgs e)
        {
            if (!tieneDebito)
            {

                DataTable dtRegistrosSeleccionados = new DataTable();

                DataView v1 = dtCtaCteDetfinal.DefaultView;
                v1.RowFilter = String.Format("id_comprobantes = {0}", Convert.ToInt32(dgvCtaCteDet.SelectedRows[0].Cells["id_comprobantes"].Value));
                dtRegistrosSeleccionados = v1.ToTable();

                if (dtRegistrosSeleccionados.Rows.Count > 0)
                {
                    Cuenta_Corriente.frmCtaCteAjustesBonificaciones frmAjustesBonificaciones = new Cuenta_Corriente.frmCtaCteAjustesBonificaciones(dtRegistrosSeleccionados);
                    frmPopUp frmpopup = new frmPopUp();
                    frmpopup.Maximizar = false;
                    frmpopup.Formulario = frmAjustesBonificaciones;
                    frmpopup.ShowDialog();
                    if (frmAjustesBonificaciones.DialogResult == DialogResult.OK)
                        cargarDatos();
                    else
                        cargarDatos();
                }
                else
                    MessageBox.Show("No se han seleccionado registros de la grilla.");
            }
            else
                MessageBox.Show("No se pueden seleccionar deudas que estan asociadas a un debito automático.", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Stop);


        }

        private void btnAplicar_Click(object sender, EventArgs e)
        {
            Ver_movimientos_a_Pagar();
            oculta_filas();
            oculta_filas_pagos();
        }

        private void frmUsuariosCtaCte_KeyPress(object sender, KeyPressEventArgs e)
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

        private void frmUsuariosCtaCte_Load(object sender, EventArgs e)
        {
            //VerificarAfip();     
            if (idusuario > 0)
            {
                this.Locacion_Id = idlocacion;
                lblUsuario.Text = String.Format("[{0}] - {1}, {2}", Usuarios.CurrentUsuario.Codigo, Usuarios.CurrentUsuario.Apellido, Usuarios.CurrentUsuario.Nombre);
                comenzarCarga();
            }
        }

        private void frmUsuariosCtaCte_Shown(object sender, EventArgs e)
        {
            if (!new Personal_Roles().VerificarSiTienePermiso(Objetos.Acciones.Acceder_Frm_Recibos))
            {
                MessageBox.Show("No cuentas con el permiso para acceder al formulario", "Mensaje del sistema");
                imgReturn_Click(this, new EventArgs());
            }
        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmUsuariosCtaCte_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
            if (e.KeyCode == Keys.F5)
                Genera_Pago();

            if (e.KeyCode == Keys.F8)
            {
                if (cuenta == 1) { }
                else { }
            }
        }
    }
}//04122020 PUNITORIOS NOTA DE DEBITOS