using CapaNegocios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class frmCajaDetalle : Form
    {
        #region DECLARACIONES

        private Thread hilo;
        private delegate void myDel();
        private DataTable dtDatosPuntoCobro = new DataTable();
        private DataTable dtRecibosCuenta1 = new DataTable();
        private DataTable dtDetSubServiciosCuenta1 = new DataTable();
        private DataTable dtPagosCuenta1 = new DataTable();
        private DataTable dataInternernaCuenta1 = new DataTable();
        private DataTable dtRecibosCuenta2 = new DataTable();
        private DataTable dtDetSubServiciosCuenta2 = new DataTable();
        private DataTable dtPagosCuenta2 = new DataTable();
        private DataTable dataInternernaCuenta2 = new DataTable();
        private DataTable datosPunto = new DataTable();
        private DataTable dtEgresos = new DataTable();
        private DataTable dtDetalleRecibo = new DataTable();
        private DataTable dtFormasPagos = new DataTable();
        private DataTable dtFormasPagos2 = new DataTable();
        private DataTable dtFormasPagosTotal = new DataTable();
        private DataTable dtServicios = new DataTable();
        private DataTable dtSubServiciosPagos = new DataTable();
        private DataTable dtRecibosBorradosCuenta1 = new DataTable();
        private DataTable dataInternernaBorradaCuenta1 = new DataTable();
        private DataTable dtDatosCajaDiaria = new DataTable();

        private Formas_de_pago oFormasPagos = new Formas_de_pago();
        private Caja_Diaria oCajaDiaria = new Caja_Diaria();
        private Caja_general oCajaGeneral = new Caja_general();
        private Puntos_Cobros oPuntoCobro = new Puntos_Cobros();
        private Personal oPersonal = new Personal();
        private Caja_Egreso oEgreso = new Caja_Egreso();
        private Usuarios_CtaCte_Recibos oUsuariosCtaCteRecibos = new Usuarios_CtaCte_Recibos();

        private Impresiones.Impresion oImpresion = new Impresiones.Impresion();
        private int idCaja, menu = 0, cantEgresos, idReciboSeleccionado = 0, idComprobanteSeleccionado = 0;
        private Decimal totalCuenta1, TotalCuenta2, montoTotalPagado, total;
        private int idPuntoCobro = 0, numeroPuntoCobro, caja = 1, cantFormas;
        private Decimal totalEgresos;
        private String nombrePuntoGestion;

        private bool detallarDet = false;
        private bool cierraCaja = false;
        int idCajaNueva = 0;
        private List<string> listaPersonal;

        #endregion

        #region METODOS
        private void ResetearValores()
        {
            totalCuenta1 = 0;
            TotalCuenta2 = 0;
            montoTotalPagado = 0;
            total = 0;
        }

        private void imprimirRecibos()
        {

            DataTable dtReporte = new DataTable();
            dtReporte.Columns.Add("Fecha", typeof(String));
            dtReporte.Columns.Add("Cuenta", typeof(String));
            dtReporte.Columns.Add("IdCuenta", typeof(String));
            dtReporte.Columns.Add("idPuntoGestion", typeof(String));
            dtReporte.Columns.Add("nombrePunto", typeof(String));
            dtReporte.Columns.Add("importeTotal", typeof(String));
            dtReporte.Columns.Add("cantidadRecibos", typeof(String));

            DataRow dr1 = dtReporte.NewRow();
            if(cierraCaja)
                dr1["IdCuenta"] = oCajaDiaria.Id;
            else
                dr1["IdCuenta"] = 0;
            dr1["Fecha"] = oCajaDiaria.Fecha.ToShortDateString();
            dr1["Cuenta"] = "1";
            dr1["idPuntoGestion"] = oCajaDiaria.Id_Puntos_cobros.ToString();
            dr1["nombrePunto"] = nombrePuntoGestion;
            dr1["cantidadRecibos"] = dtRecibosCuenta1.Rows.Count;
            dr1["importeTotal"] = total;

            dtReporte.Rows.Add(dr1);
            DataTable dtCopiaDataInterna1;
            if (cboPersonal.Text.ToLower() != "todos" && cierraCaja==false)
            {
                DataView dvdtInterna = dataInternernaCuenta1.DefaultView;
                dvdtInterna.RowFilter = string.Format("personal='{0}'", cboPersonal.Text);
                dtCopiaDataInterna1 = dvdtInterna.ToTable();
            }
            else
                dtCopiaDataInterna1 = dataInternernaCuenta1;
            oImpresion.ImprimirDetalleCajaRecibos(dtReporte, dtCopiaDataInterna1);

        }

        private void comenzarCarga()
        {
            ResetearValores();
            hilo = new Thread(new ThreadStart(cargarDatos));
            hilo.IsBackground = true;
            hilo.Start();
        }
        private void cargarDatos()
        {
            try
            {
                dtFormasPagos = oFormasPagos.Listar();
                if(idCaja==0)
                    idPuntoCobro = Puntos_Cobros.Id_Punto;
                else
                {
                    dtDatosCajaDiaria = oCajaDiaria.Listar(idCaja);
                    if (dtDatosCajaDiaria.Rows.Count > 0)
                    {
                        idPuntoCobro = Convert.ToInt32(dtDatosCajaDiaria.Rows[0]["id_puntos_cobros"]);
                      
                    }
                }
                dtDatosPuntoCobro = oPuntoCobro.PuntoDatos(idPuntoCobro);
                dataInternernaCuenta1.Rows.Clear();
                dataInternernaCuenta1.Columns.Clear();
                dataInternernaCuenta2.Rows.Clear();
                dataInternernaCuenta2.Columns.Clear();
                //cuenta1
                dtRecibosCuenta1 = oCajaDiaria.ListarDetallesRecibos(idPuntoCobro, idCaja, 1, borrado : 0);
                if (dtRecibosCuenta1.Rows.Count > 0)
                {
                    if (detallarDet == true)
                        dtDetSubServiciosCuenta1 = oCajaDiaria.ListarDetallesCtaCteDetSubServicios(idPuntoCobro, idCaja, 1);
                    dtPagosCuenta1 = oCajaDiaria.ListarDetallesCtaCteDetPagos(idPuntoCobro, idCaja, 1);
                }
                //cuenta2
                dtRecibosCuenta2 = oCajaDiaria.ListarDetallesRecibos(idPuntoCobro, idCaja, 2, borrado: 0);
                if (dtRecibosCuenta2.Rows.Count > 0)
                {
                    if (detallarDet == true)
                        dtDetSubServiciosCuenta2 = oCajaDiaria.ListarDetallesCtaCteDetSubServicios(idPuntoCobro, idCaja, 2);
                    dtPagosCuenta2 = oCajaDiaria.ListarDetallesCtaCteDetPagos(idPuntoCobro, idCaja, 2);
                }

                dtRecibosBorradosCuenta1 = oCajaDiaria.ListarDetallesRecibos(idPuntoCobro, idCaja, 1, borrado: 1);

                datosPunto = oPuntoCobro.PuntoDatos(idPuntoCobro);
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
            lblTotal1Dato.Text = "0.00";
            dgvPresentacion.DataSource = null;
            dgvFormas1.DataSource = null;
            dgvFormas2.DataSource = null;
            DataColumn dcImporte = new DataColumn();
            dcImporte.DataType = typeof(decimal);
            dcImporte.ColumnName = "importe";
            dcImporte.DefaultValue = 0;
            dtFormasPagos.Columns.Add(dcImporte);


            DataColumn dcCantidad = new DataColumn();
            dcCantidad.DataType = typeof(Int32);
            dcCantidad.ColumnName = "cantidad";
            dcCantidad.DefaultValue = 0;
            dtFormasPagos.Columns.Add(dcCantidad);

            dtFormasPagos2 = oFormasPagos.Listar();

            DataColumn dcImporte2 = new DataColumn();
            dcImporte2.DataType = typeof(decimal);
            dcImporte2.ColumnName = "importe";
            dcImporte2.DefaultValue = 0;
            dtFormasPagos2.Columns.Add(dcImporte2);


            DataColumn dcCantidad2 = new DataColumn();
            dcCantidad2.DataType = typeof(decimal);
            dcCantidad2.ColumnName = "cantidad";
            dcCantidad2.DefaultValue = 0;
            dtFormasPagos2.Columns.Add(dcCantidad2);

            dtFormasPagosTotal = dtFormasPagos.Clone();

            DataRow drRetiros = dtFormasPagos.NewRow();
            drRetiros["id"] = 0;
            drRetiros["nombre"] = "RETIROS";
            drRetiros["id_tipo_de_forma"] = 0;
            drRetiros["requiere_presentacion"] = 0;
            drRetiros["tipo_de_forma"] = 0;
            drRetiros["cantidad"] = 0;
            drRetiros["codigo_empresa_tarjeta"] = 0;
            drRetiros["codigo_empresa_banco"] = 0;
            drRetiros["importe"] = 0;
            drRetiros["cantidad"] = 0;

            DataRow drTotal = dtFormasPagos.NewRow();
            drTotal["id"] = 999;
            drTotal["nombre"] = "TOTAL";
            drTotal["id_tipo_de_forma"] = 0;
            drTotal["requiere_presentacion"] = 0;
            drTotal["tipo_de_forma"] = 0;
            drTotal["cantidad"] = 0;
            drTotal["codigo_empresa_tarjeta"] = 0;
            drTotal["codigo_empresa_banco"] = 0;
            drTotal["importe"] = 0;
            drTotal["cantidad"] = 0;

            dtFormasPagos.Rows.Add(drRetiros);
            dtFormasPagos.Rows.Add(drTotal);
            dtFormasPagos2.ImportRow(drRetiros);
            dgvFormas1.DataSource = dtFormasPagos;


            if ((dtRecibosCuenta1.Rows.Count == 0) && (dtRecibosCuenta2.Rows.Count == 0))
                btnCerrar2.Enabled = false;
            scMain.Panel2Collapsed = true;
            dataInternernaCuenta1 = CrearTabalaInterna();
            dataInternernaCuenta2 = CrearTabalaInterna();
            dataInternernaBorradaCuenta1 = CrearTabalaInterna();
            AgruparTipo();
            FormatearGrilla();
            ListarEgresos();
            CalcularTotales(discriminaPersonal: false);
            CargarComboPersonal();
            pnlFootTotal.Height = 50;

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

            if (idCaja != 0)
            {
                btnCerrar2.Visible = false;
                btnCambio.Visible = false;
            }
        }

        private void CalcularTotales(bool discriminaPersonal)
        {

            string tipoPago = "";
            int idFormaPago = 0, idFormaPagoAux = 0;
            decimal importe = 0;
            totalCuenta1 = 0;
            totalEgresos = 0;
            total = 0;
            foreach (DataRow item in dtEgresos.Rows)
            {
                if (discriminaPersonal)
                {
                    if (item["nombre"].ToString() == cboPersonal.Text)
                        totalEgresos += Convert.ToDecimal(item["monto"]);
                }
                else
                    totalEgresos += Convert.ToDecimal(item["monto"]);
            }
            cantFormas = 0;
            foreach (DataRow item2 in dtFormasPagos.Rows)
            {
                item2["importe"] = 0;
                item2["cantidad"] = 0;
            }
            foreach (DataGridViewRow item in dgvPresentacion.Rows)
            {
                if (Convert.ToInt32(item.Cells["borrado"].Value) != 1)
                {
                    tipoPago = item.Cells["tipopago"].Value.ToString();
                    if ((tipoPago != "") && (tipoPago != "TOTAL"))
                    {
                        if (discriminaPersonal)
                        {
                            if (item.Cells["personal"].Value.ToString().ToLower() == cboPersonal.Text.ToLower())
                            {
                                idFormaPago = Convert.ToInt32(item.Cells["id_forma_pago"].Value);
                                cantFormas++;
                                importe = Convert.ToDecimal(item.Cells["montoPagado"].Value);
                                totalCuenta1 = totalCuenta1 + importe;
                                idFormaPagoAux = 0;
                            }
                        }
                        else
                        {
                            idFormaPago = Convert.ToInt32(item.Cells["id_forma_pago"].Value);
                            cantFormas++;
                            importe = Convert.ToDecimal(item.Cells["montoPagado"].Value);
                            totalCuenta1 = totalCuenta1 + importe;
                            idFormaPagoAux = 0;
                        }

                        foreach (DataRow item2 in dtFormasPagos.Rows)
                        {
                            idFormaPagoAux = Convert.ToInt32(item2["id"]);
                            if (idFormaPago == idFormaPagoAux)
                            {
                                item2["importe"] = Convert.ToDecimal(item2["importe"]) + importe;
                                item2["cantidad"] = Convert.ToInt32(item2["cantidad"]) + 1;
                            }
                        }
                    }
                }
            }


            foreach (DataRow item2 in dtFormasPagos.Rows)
            {
                idFormaPago = Convert.ToInt32(item2["id"]);

                if (idFormaPago == 0)
                {
                    item2["importe"] = totalEgresos * (-1);
                    item2["cantidad"] = dtEgresos.Rows.Count;
                }
                else if (idFormaPago == 999)
                {
                    item2["importe"] = totalCuenta1 - totalEgresos;
                    item2["cantidad"] = cantFormas;
                }
                else
                {
                    total = total + Convert.ToDecimal(item2["importe"]);
                }
            }
            total = total - totalEgresos;
            dgvFormas1.DataSource = dtFormasPagos;
            FormatearGrillaFormas(dgvFormas1);

            tipoPago = "";
            importe = 0;
            idFormaPagoAux = 0;
            idFormaPago = 0;

            foreach (DataGridViewRow item in dgvPresentacion2.Rows)
            {
                tipoPago = item.Cells["tipopago"].Value.ToString();
                if (Convert.ToInt32(item.Cells["borrado"].Value) != 1)
                {
                    if ((tipoPago != "") && (tipoPago != "TOTAL"))
                    {
                        if (discriminaPersonal)
                        {
                            if (item.Cells["personal"].Value.ToString().ToLower() == cboPersonal.Text.ToLower())
                            {
                                idFormaPago = Convert.ToInt32(item.Cells["id_forma_pago"].Value);
                                cantFormas++;
                                importe = Convert.ToDecimal(item.Cells["montoPagado"].Value);
                                totalCuenta1 = totalCuenta1 + importe;
                                idFormaPagoAux = 0;
                            }
                        }
                        else
                        {
                            idFormaPago = Convert.ToInt32(item.Cells["id_forma_pago"].Value);
                            cantFormas++;
                            importe = Convert.ToDecimal(item.Cells["montoPagado"].Value);
                            totalCuenta1 = totalCuenta1 + importe;
                            idFormaPagoAux = 0;
                        }
                        foreach (DataRow item2 in dtFormasPagos2.Rows)
                        {
                            idFormaPagoAux = Convert.ToInt32(item2["id"]);
                            if (idFormaPago == idFormaPagoAux)
                            {
                                item2["importe"] = Convert.ToDecimal(item2["importe"]) + importe;
                                item2["cantidad"] = Convert.ToInt32(item2["cantidad"]) + 1;

                            }
                        }
                    }
                }
            }
            dgvFormas2.DataSource = dtFormasPagos2;
            FormatearGrillaFormas(dgvFormas2);

            dtFormasPagosTotal = dtFormasPagos.Copy();
            int indiceAux = 0;
            foreach (DataRow item in dtFormasPagosTotal.Rows)
            {
                try
                {
                    if (Convert.ToInt32(item["borrado"]) == 0)
                    {
                        item["cantidad"] = Convert.ToInt32(item["cantidad"]) + Convert.ToInt32(dtFormasPagos2.Rows[indiceAux]["cantidad"]);
                        item["importe"] = Convert.ToDecimal(item["importe"]) + Convert.ToDecimal(dtFormasPagos2.Rows[indiceAux]["importe"]);
                    }

                }
                catch
                {
                }
                indiceAux++;
            }

            dgvFormasTotal.DataSource = dtFormasPagosTotal;
            FormatearGrillaFormas(dgvFormasTotal);

            lblTotal1Dato.Text = (totalCuenta1 - totalEgresos).ToString("c2");
        }


        private void FormatearGrillaFormas(DataGridView dg)
        {
            foreach (DataGridViewColumn item in dg.Columns)
                item.Visible = false;
            dg.Columns["nombre"].Visible = true;
            dg.Columns["nombre"].HeaderText = "Forma de pago";

            dg.Columns["importe"].Visible = true;
            dg.Columns["importe"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dg.Columns["importe"].DefaultCellStyle.Format = "N2";
            dg.Columns["cantidad"].Visible = true;
            dg.Columns["cantidad"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dg.Columns["cantidad"].HeaderText = "Cantidad";

            foreach (DataGridViewRow item in dg.Rows)
            {
                if (Convert.ToInt32(item.Cells["id"].Value) == 999)
                {
                    item.DefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                }
            }
        }

        private DataTable CrearTabalaInterna()
        {
            DataTable dtFinal = new DataTable();
            dtFinal.Columns.Add("tipo", typeof(Int32));
            dtFinal.Columns.Add("Personal", typeof(string));

            dtFinal.Columns.Add("id_recibo", typeof(Int32));
            dtFinal.Columns.Add("id_comprobante", typeof(Int32));

            dtFinal.Columns.Add("cod_usuario", typeof(Int32));
            dtFinal.Columns.Add("id_locacion", typeof(Int32));

            dtFinal.Columns.Add("nombre_usuario", typeof(string));
            dtFinal.Columns.Add("nombre_sub", typeof(string));

            dtFinal.Columns.Add("codigo_muestra", typeof(string));
            dtFinal.Columns.Add("fecha", typeof(DateTime));
            dtFinal.Columns.Add("monto", typeof(decimal));
            dtFinal.Columns.Add("TipoPago", typeof(string));
            dtFinal.Columns.Add("montoPagado", typeof(decimal));
            dtFinal.Columns.Add("id_forma_pago", typeof(Int32));
            dtFinal.Columns.Add("factura", typeof(string));
            dtFinal.Columns.Add("borrado", typeof(Int32));
            DataColumn dcNuevo = new DataColumn
            {
                ColumnName = "nuevo",
                DataType = typeof(Int32),
                DefaultValue = 0
            };
            dtFinal.Columns.Add(dcNuevo);


            return dtFinal;
        }

        private void AgruparTipo()
        {
            var cont = 0;
            DataRow drCreditoACuentaUtilizado = null;
            //cuenta1
            foreach (DataRow item in dtRecibosCuenta1.Rows)
            {
                var idRecibo = Convert.ToInt32(item["id"]);
                var codUsuario = Convert.ToInt32(item["codigo"]);
                var nombreApellido = item["nomape"].ToString();
                var numeroMuestra = item["numero_muestra"].ToString();
                var fecha = Convert.ToDateTime(item["fecha_movimiento"]);
                var monto = Convert.ToDecimal(item["importe_comprobante"]);
                var nombreCajero = item["nombrePersonal"].ToString();
                var idLocacion = Convert.ToInt32(item["id_usuarios_locaciones"]);
                var idComprobante = Convert.ToInt32(item["id_comprobantes"]);
                var factura = item["factura"].ToString();
                var borrado = Convert.ToInt32(item["borrado"]);
                var nuevo = Convert.ToInt32(item["nuevo"]);
                DataRow drCabeza = dataInternernaCuenta1.NewRow();
                drCabeza["tipo"] = 1;

                drCabeza["Personal"] = nombreCajero;
                drCabeza["id_recibo"] = idRecibo;
                drCabeza["cod_usuario"] = codUsuario;
                drCabeza["nombre_usuario"] = nombreApellido;
                drCabeza["codigo_muestra"] = numeroMuestra;
                drCabeza["fecha"] = fecha;
                drCabeza["monto"] = monto;
                drCabeza["montoPagado"] = 0;
                drCabeza["TipoPago"] = "";
                drCabeza["id_locacion"] = idLocacion;
                drCabeza["id_comprobante"] = idComprobante;
                drCabeza["id_forma_pago"] = 0;
                drCabeza["factura"] = factura;
                drCabeza["borrado"] = borrado;
                drCabeza["nuevo"] = nuevo;

                if (nuevo != 2)
                    dataInternernaCuenta1.Rows.Add(drCabeza);
                else
                {
                    drCabeza["TipoPago"] = "Credito a cuenta";
                    drCreditoACuentaUtilizado = drCabeza;
                }

                if (detallarDet == true)
                {
                    DataRow[] drSubservicios = dtDetSubServiciosCuenta1.Select("Id_Usuarios_ctacte_recibos=" + idRecibo);
                    foreach (DataRow subServicios in drSubservicios)
                    {
                        var codSubServicio = 0;
                        var nombreSubServicio = subServicios["sub_servicio"].ToString();
                        var fechaSub = fecha;
                        var montoSub = Convert.ToDecimal(subServicios["importe_imputa"]);
                        DataRow drSubServicios = dataInternernaCuenta1.NewRow();
                        drSubServicios["tipo"] = 2;
                        drSubServicios["id_recibo"] = idRecibo;
                        drSubServicios["nombre_sub"] = "(" + codSubServicio + ") " + nombreSubServicio;
                        drSubServicios["codigo_muestra"] = numeroMuestra;
                        drSubServicios["fecha"] = fecha;
                        drSubServicios["monto"] = 0;
                        drSubServicios["montoPagado"] = montoSub;
                        drSubServicios["id_forma_pago"] = 0;
                        drSubServicios["factura"] = "";
                        drSubServicios["id_comprobante"] = idComprobante;
                        dataInternernaCuenta1.Rows.Add(drSubServicios);

                    }
                }
                DataRow[] drPagos = dtPagosCuenta1.Select("id_usuarios_ctacte_recibos=" + idRecibo);
                foreach (DataRow pagos in drPagos)
                {
                    var personal = pagos["personal"].ToString();
                    var codUsuario_pagos = Convert.ToInt32(pagos["codigo"]);
                    var nombreUsuario = pagos["nomape"].ToString();
                    var fechaSub = Convert.ToDateTime(pagos["fecha_acreditacion"]);
                    var numeroMuestraPago = pagos["numero_muestra"].ToString();
                    var montoPagado = Convert.ToDecimal(pagos["importe"]);
                    //var montoRecibo = Convert.ToDecimal(pagos["importe_recibo"]);
                    var idFormaPago = Convert.ToInt32(pagos["id_formas_de_pago"]);
                    var borradoDet = Convert.ToInt32(pagos["borrado"]);
                    var tipoPago = pagos["nombre"].ToString();


                    if (cont == dtRecibosCuenta1.Rows.Count - 1 || idRecibo != Convert.ToInt32(dtRecibosCuenta1.Rows[cont + 1]["id"]))
                    {
                        DataRow drPago = dataInternernaCuenta1.NewRow();
                        drPago["personal"] = personal;
                        drPago["tipo"] = 3;
                        drPago["id_recibo"] = idRecibo;
                        drPago["cod_usuario"] = codUsuario_pagos;
                        drPago["nombre_usuario"] = nombreUsuario;
                        drPago["codigo_muestra"] = numeroMuestraPago;
                        drPago["fecha"] = fecha;
                        drPago["montoPagado"] = montoPagado;
                        montoTotalPagado = montoTotalPagado + montoPagado;
                        drPago["monto"] = 0;
                        drPago["TipoPago"] = "(" + idFormaPago + ") " + tipoPago;
                        drPago["id_forma_pago"] = idFormaPago;
                        drPago["factura"] = numeroMuestraPago.ToUpper();
                        drPago["id_comprobante"] = idComprobante;
                        drPago["borrado"] = borradoDet;


                        if (drCreditoACuentaUtilizado != null)
                        {
                            dataInternernaCuenta1.Rows.Add(drCreditoACuentaUtilizado);
                            drCreditoACuentaUtilizado = null;
                        }
                        dataInternernaCuenta1.Rows.Add(drPago);

                    }

                }
                cont++;
            }

            cont = 0;
            //Borrados cuenta 1
            foreach (DataRow item in dtRecibosBorradosCuenta1.Rows)
            {
                var idRecibo = Convert.ToInt32(item["id"]);
                var codUsuario = Convert.ToInt32(item["codigo"]);
                var nombreApellido = item["nomape"].ToString();
                var numeroMuestra = item["numero_muestra"].ToString();
                var fecha = Convert.ToDateTime(item["fecha_movimiento"]);
                var monto = Convert.ToDecimal(item["importe_comprobante"]);
                var nombreCajero = item["nombrePersonal"].ToString();
                var idLocacion = Convert.ToInt32(item["id_usuarios_locaciones"]);
                var idComprobante = Convert.ToInt32(item["id_comprobantes"]);
                var factura = item["factura"].ToString();
                var borrado = Convert.ToInt32(item["borrado"]);
                var nuevo = Convert.ToInt32(item["nuevo"]);
                DataRow drCabeza = dataInternernaBorradaCuenta1.NewRow();
                drCabeza["tipo"] = 1;

                drCabeza["Personal"] = nombreCajero;
                drCabeza["id_recibo"] = idRecibo;
                drCabeza["cod_usuario"] = codUsuario;
                drCabeza["nombre_usuario"] = nombreApellido;
                drCabeza["codigo_muestra"] = numeroMuestra;
                drCabeza["fecha"] = fecha;
                drCabeza["monto"] = monto;
                drCabeza["montoPagado"] = 0;
                drCabeza["TipoPago"] = "";
                drCabeza["id_locacion"] = idLocacion;
                drCabeza["id_comprobante"] = idComprobante;
                drCabeza["id_forma_pago"] = 0;
                drCabeza["factura"] = factura;
                drCabeza["borrado"] = borrado;
                drCabeza["nuevo"] = nuevo;

                if (nuevo != 2)
                    dataInternernaBorradaCuenta1.Rows.Add(drCabeza);
                else
                {
                    drCabeza["TipoPago"] = "Credito a cuenta";
                    drCreditoACuentaUtilizado = drCabeza;
                }


 
                if (dtPagosCuenta1.Rows.Count > 0)
                {
                    DataRow[] drPagos = dtPagosCuenta1.Select("id_usuarios_ctacte_recibos=" + idRecibo);
                    foreach (DataRow pagos in drPagos)
                    {
                        var personal = pagos["personal"].ToString();
                        var codUsuario_pagos = Convert.ToInt32(pagos["codigo"]);
                        var nombreUsuario = pagos["nomape"].ToString();
                        var fechaSub = Convert.ToDateTime(pagos["fecha_acreditacion"]);
                        var numeroMuestraPago = pagos["numero_muestra"].ToString();
                        var montoPagado = Convert.ToDecimal(pagos["importe"]);
                        //var montoRecibo = Convert.ToDecimal(pagos["importe_recibo"]);
                        var idFormaPago = Convert.ToInt32(pagos["id_formas_de_pago"]);
                        var borradoDet = Convert.ToInt32(pagos["borrado"]);
                        var tipoPago = pagos["nombre"].ToString();

                        if (cont == dtRecibosBorradosCuenta1.Rows.Count - 1 || idRecibo != Convert.ToInt32(dtRecibosBorradosCuenta1.Rows[cont + 1]["id"]))
                        {
                            DataRow drPago = dataInternernaBorradaCuenta1.NewRow();
                            drPago["personal"] = personal;
                            drPago["tipo"] = 3;
                            drPago["id_recibo"] = idRecibo;
                            drPago["cod_usuario"] = codUsuario_pagos;
                            drPago["nombre_usuario"] = nombreUsuario;
                            drPago["codigo_muestra"] = numeroMuestraPago;
                            drPago["fecha"] = fecha;
                            drPago["montoPagado"] = montoPagado;
                            montoTotalPagado = montoTotalPagado + montoPagado;
                            drPago["monto"] = 0;
                            drPago["TipoPago"] = "(" + idFormaPago + ") " + tipoPago;
                            drPago["id_forma_pago"] = idFormaPago;
                            drPago["factura"] = numeroMuestraPago.ToUpper();
                            drPago["id_comprobante"] = idComprobante;
                            drPago["borrado"] = borradoDet;


                            if (drCreditoACuentaUtilizado != null)
                            {
                                dataInternernaBorradaCuenta1.Rows.Add(drCreditoACuentaUtilizado);
                                drCreditoACuentaUtilizado = null;
                            }
                            dataInternernaBorradaCuenta1.Rows.Add(drPago);
                        }

                    }

                }
                cont++;
            }

            cont = 0;
            //cuenta2
            foreach (DataRow item in dtRecibosCuenta2.Rows)
            {
                var idRecibo = Convert.ToInt32(item["id"]);
                var codUsuario = Convert.ToInt32(item["codigo"]);
                var nombreApellido = item["nomape"].ToString();
                var numeroMuestra = item["numero_muestra"].ToString();
                var fecha = Convert.ToDateTime(item["fecha_movimiento"]);
                var monto = Convert.ToDecimal(item["importe_recibo"]);
                var nombreCajero = item["nombrePersonal"].ToString();
                var idLocacion = Convert.ToInt32(item["id_usuarios_locaciones"]);
                var idComprobante = Convert.ToInt32(item["id_comprobantes"]);
                var factura = item["factura"].ToString();
                var borrado = Convert.ToInt32(item["borrado"]);

                DataRow drCabeza = dataInternernaCuenta2.NewRow();
                drCabeza["tipo"] = 1;
                drCabeza["Personal"] = nombreCajero;

                drCabeza["id_recibo"] = idRecibo;
                drCabeza["cod_usuario"] = codUsuario;
                drCabeza["nombre_usuario"] = nombreApellido;
                drCabeza["codigo_muestra"] = numeroMuestra;
                drCabeza["fecha"] = fecha;
                drCabeza["monto"] = 0;
                drCabeza["montoPagado"] = monto;
                drCabeza["TipoPago"] = "";
                drCabeza["id_locacion"] = idLocacion;
                drCabeza["id_comprobante"] = idComprobante;
                drCabeza["factura"] = factura;
                drCabeza["borrado"] = borrado;

                dataInternernaCuenta2.Rows.Add(drCabeza);
                if (detallarDet == true)
                {

                    DataRow[] drSubservicios = dtDetSubServiciosCuenta2.Select("Id_Usuarios_ctacte_recibos=" + idRecibo);
                    foreach (DataRow subServicios in drSubservicios)
                    {
                        var codSubServicio = 0;
                        var nombreSubServicio = subServicios["sub_servicio"].ToString();
                        var fechaSub = fecha;
                        var montoSub = Convert.ToDecimal(subServicios["importe_imputa"]);
                        DataRow drSubServicios = dataInternernaCuenta2.NewRow();
                        drSubServicios["tipo"] = 2;
                        drSubServicios["id_recibo"] = idRecibo;
                        drSubServicios["nombre_sub"] = "(" + codSubServicio + ") " + nombreSubServicio;
                        drSubServicios["codigo_muestra"] = numeroMuestra;
                        drSubServicios["fecha"] = fecha;
                        drSubServicios["monto"] = montoSub;
                        drSubServicios["montoPagado"] = 0;
                        drSubServicios["factura"] = "";

                        dataInternernaCuenta2.Rows.Add(drSubServicios);

                    }
                }
                DataRow[] drPagos = dtPagosCuenta2.Select("id_usuarios_ctacte_recibos=" + idRecibo);
                foreach (DataRow pagos in drPagos)
                {
                    var codUsuario_pagos = Convert.ToInt32(pagos["codigo"]);
                    var nombreUsuario = pagos["nomape"].ToString();
                    var fechaSub = Convert.ToDateTime(pagos["fecha_acreditacion"]);
                    var numeroMuestraPago = pagos["numero_muestra"].ToString();
                    var montoPagado = Convert.ToDecimal(pagos["importe"]);
                    //var montoRecibo = Convert.ToDecimal(pagos["importe_recibo"]);
                    var idFormaPago = Convert.ToInt32(pagos["id_formas_de_pago"]);
                    var tipoPago = pagos["nombre"].ToString();
                    var borradoDet = Convert.ToInt32(pagos["borrado"]);

                    if (cont == dtRecibosCuenta1.Rows.Count - 1 || idRecibo != Convert.ToInt32(dtRecibosCuenta1.Rows[cont + 1]["id"]))
                    {
                        DataRow drPago = dataInternernaCuenta2.NewRow();
                        drPago["tipo"] = 3;
                        drPago["id_recibo"] = idRecibo;
                        drPago["cod_usuario"] = codUsuario_pagos;
                        drPago["nombre_usuario"] = nombreUsuario;
                        drPago["codigo_muestra"] = numeroMuestraPago;
                        drPago["fecha"] = fecha;
                        drPago["montoPagado"] = 0;
                        montoTotalPagado = montoTotalPagado + montoPagado;
                        drPago["monto"] = montoPagado;
                        drPago["TipoPago"] = tipoPago;
                        drPago["id_forma_pago"] = idFormaPago;
                        drPago["factura"] = "";
                        drPago["borrado"] = borradoDet;

                        dataInternernaCuenta2.Rows.Add(drPago);
                    }

                }
                DataRow drVacia = dataInternernaCuenta2.NewRow();
                drVacia["TipoPago"] = "TOTAL";
                drVacia["tipo"] = 0;
                drVacia["montoPagado"] = montoTotalPagado;
                montoTotalPagado = 0;

                drVacia["tipo"] = 0;
                drVacia["borrado"] = 0;
                dataInternernaCuenta2.Rows.Add(drVacia);

                cont++;
            }

            dgvPresentacion.DataSource = dataInternernaCuenta1;
            dgvPresentacion2.DataSource = dataInternernaCuenta2;
            dgvPresentacionBorrados.DataSource = dataInternernaBorradaCuenta1;

        }

        void FormatearGrilla()
        {
            //cuenta 1
            dgvPresentacion.Columns["tipo"].Visible = false;
            dgvPresentacion.Columns["id_recibo"].Visible = false;
            dgvPresentacion.Columns["id_comprobante"].Visible = false;
            dgvPresentacion.Columns["id_locacion"].Visible = false;
            dgvPresentacion.Columns["id_forma_pago"].Visible = false;
            dgvPresentacion.Columns["nombre_sub"].Visible = false;

            dgvPresentacion.Columns["monto"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvPresentacion.Columns["monto"].DefaultCellStyle.Format = "c";
            dgvPresentacion.Columns["montoPagado"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvPresentacion.Columns["montoPagado"].DefaultCellStyle.Format = "c";
            dgvPresentacion.Columns["montoPagado"].HeaderText = "Rendido";

            dgvPresentacion.Columns["cod_usuario"].HeaderText = "Codigo de usuario";
            dgvPresentacion.Columns["cod_usuario"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvPresentacion.Columns["cod_usuario"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvPresentacion.Columns["nombre_usuario"].HeaderText = "Nombre de usuario";
            dgvPresentacion.Columns["tipopago"].HeaderText = "Forma de pago";
            dgvPresentacion.Columns["nombre_sub"].HeaderText = "Item";
            dgvPresentacion.Columns["factura"].HeaderText = "Numero de recibo / factura ";
            dgvPresentacion.Columns["factura"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvPresentacion.Columns["factura"].DisplayIndex = dgvPresentacion.Columns["codigo_muestra"].DisplayIndex;

            dgvPresentacion.Columns["fecha"].HeaderText = "Fecha";
            dgvPresentacion.Columns["monto"].HeaderText = "Monto";
            dgvPresentacion.Columns["codigo_muestra"].Visible = false;
            dgvPresentacion.Columns["borrado"].Visible = false;
            dgvPresentacion.Columns["nuevo"].Visible = false;

            foreach (DataGridViewRow item in dgvPresentacion.Rows)
            {
                int tipo;
                if (Convert.ToInt32(item.Cells["nuevo"].Value) == 2)
                {
                    tipo = 4;
                }
                else
                    tipo = Convert.ToInt32(item.Cells["tipo"].Value);

                switch (tipo)
                {
                    case 1:
                        item.DefaultCellStyle.BackColor = Color.LimeGreen;
                        break;
                    case 2:
                        item.DefaultCellStyle.BackColor = Color.DarkSeaGreen;
                        break;
                    case 3:
                        item.DefaultCellStyle.BackColor = Color.LightGreen;
                        break;
                    case 4:
                        item.DefaultCellStyle.BackColor = Color.YellowGreen;
                        break;
                    default:
                        item.DefaultCellStyle.BackColor = Color.White;
                        break;

                };
            }

            //cuenta 1 borrados
            dgvPresentacionBorrados.Columns["tipo"].Visible = false;
            dgvPresentacionBorrados.Columns["id_recibo"].Visible = false;
            dgvPresentacionBorrados.Columns["id_comprobante"].Visible = false;
            dgvPresentacionBorrados.Columns["id_locacion"].Visible = false;
            dgvPresentacionBorrados.Columns["id_forma_pago"].Visible = false;
            dgvPresentacionBorrados.Columns["nombre_sub"].Visible = false;

            dgvPresentacionBorrados.Columns["monto"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvPresentacionBorrados.Columns["monto"].DefaultCellStyle.Format = "c";
            dgvPresentacionBorrados.Columns["montoPagado"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvPresentacionBorrados.Columns["montoPagado"].DefaultCellStyle.Format = "c";
            dgvPresentacionBorrados.Columns["montoPagado"].HeaderText = "Rendido";

            dgvPresentacionBorrados.Columns["cod_usuario"].HeaderText = "Codigo de usuario";
            dgvPresentacionBorrados.Columns["cod_usuario"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvPresentacionBorrados.Columns["cod_usuario"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvPresentacionBorrados.Columns["nombre_usuario"].HeaderText = "Nombre de usuario";
            dgvPresentacionBorrados.Columns["tipopago"].HeaderText = "Forma de pago";
            dgvPresentacionBorrados.Columns["nombre_sub"].HeaderText = "Item";
            dgvPresentacionBorrados.Columns["factura"].HeaderText = "Numero de recibo / factura ";
            dgvPresentacionBorrados.Columns["factura"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvPresentacionBorrados.Columns["factura"].DisplayIndex = dgvPresentacion.Columns["codigo_muestra"].DisplayIndex;

            dgvPresentacionBorrados.Columns["fecha"].HeaderText = "Fecha";
            dgvPresentacionBorrados.Columns["monto"].HeaderText = "Monto";
            dgvPresentacionBorrados.Columns["codigo_muestra"].Visible = false;
            dgvPresentacionBorrados.Columns["borrado"].Visible = false;
            dgvPresentacionBorrados.Columns["nuevo"].Visible = false;

            foreach (DataGridViewRow item in dgvPresentacionBorrados.Rows)
            {
                int tipo;
                if (Convert.ToInt32(item.Cells["nuevo"].Value) == 2)
                {
                    tipo = 4;
                }
                else
                tipo = Convert.ToInt32(item.Cells["tipo"].Value);
                switch (tipo)
                {
                    case 1:
                        item.DefaultCellStyle.BackColor = Color.Red;
                        break;
                    case 2:
                        item.DefaultCellStyle.BackColor = Color.DarkRed;
                        break;
                    case 3:
                        item.DefaultCellStyle.BackColor = Color.Tomato;
                        break;
                    case 4:
                        item.DefaultCellStyle.BackColor = Color.Turquoise;
                        break;
                    default:
                        item.DefaultCellStyle.BackColor = Color.White;
                        break;
                };
            }

            //cuenta2
            dgvPresentacion2.Columns["tipo"].Visible = false;
            dgvPresentacion2.Columns["id_recibo"].Visible = false;
            dgvPresentacion2.Columns["id_comprobante"].Visible = false;
            dgvPresentacion2.Columns["id_locacion"].Visible = false;
            dgvPresentacion2.Columns["id_forma_pago"].Visible = false;
            dgvPresentacion2.Columns["factura"].Visible = false;

            dgvPresentacion2.Columns["monto"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvPresentacion2.Columns["monto"].DefaultCellStyle.Format = "c";
            dgvPresentacion2.Columns["montoPagado"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvPresentacion2.Columns["montoPagado"].DefaultCellStyle.Format = "c";
            dgvPresentacion2.Columns["montoPagado"].HeaderText = "Rendido";
            dgvPresentacion2.Columns["cod_usuario"].HeaderText = "Codigo de usuario";
            dgvPresentacion2.Columns["cod_usuario"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvPresentacion2.Columns["cod_usuario"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvPresentacion2.Columns["nombre_usuario"].HeaderText = "Nombre de usuario";
            dgvPresentacion2.Columns["tipopago"].HeaderText = "Forma de pago";
            dgvPresentacion2.Columns["nombre_sub"].HeaderText = "Item";
            dgvPresentacion2.Columns["codigo_muestra"].HeaderText = "Numero de recibo";
            dgvPresentacion2.Columns["codigo_muestra"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvPresentacion2.Columns["fecha"].HeaderText = "Fecha";
            dgvPresentacion2.Columns["monto"].HeaderText = "Monto";

            foreach (DataGridViewRow item in dgvPresentacion2.Rows)
            {
                var tipo = Convert.ToInt32(item.Cells["tipo"].Value);
                switch (tipo)
                {
                    case 1:
                        item.DefaultCellStyle.BackColor = Color.LightSalmon;
                        break;
                    case 2:
                        item.DefaultCellStyle.BackColor = Color.Bisque;
                        break;
                    case 3:
                        item.DefaultCellStyle.BackColor = Color.Bisque;
                        break;
                    default:
                        item.DefaultCellStyle.BackColor = Color.White;
                        break;
                };
            }

            //datagridview no ordenables 

            foreach (DataGridViewColumn column in dgvPresentacion.Columns)
                column.SortMode = DataGridViewColumnSortMode.NotSortable;

            foreach (DataGridViewColumn column in dgvPresentacion2.Columns)
                column.SortMode = DataGridViewColumnSortMode.NotSortable;

        }

        private void CargarComboPersonal()
        {
            listaPersonal = (from row in dataInternernaCuenta1.AsEnumerable()
                             select row.Field<string>("Personal")).Distinct().ToList();

            cboPersonal.Items.Add("Todos");
            foreach (string item in listaPersonal)
            {
                if (!String.IsNullOrEmpty(item))
                    cboPersonal.Items.Add(item);
            }
            cboPersonal.SelectedIndex = 0;
        }


        private void ListarEgresos()
        {
            dtEgresos = oEgreso.Listar(0, Puntos_Cobros.Id_Punto);

            cantEgresos = dtEgresos.Rows.Count;
            totalEgresos = 0;
            if (cantEgresos > 0)
            {
                foreach (DataRow item in dtEgresos.Rows)
                    totalEgresos += Convert.ToDecimal(item["monto"]);
            }
        }


        private void imprimirFormas()
        {

            DataTable dtReporte = new DataTable();
            dtReporte.Columns.Add("Fecha", typeof(String));
            dtReporte.Columns.Add("Cuenta", typeof(String));
            dtReporte.Columns.Add("IdCuenta", typeof(String));
            dtReporte.Columns.Add("idPuntoGestion", typeof(String));
            dtReporte.Columns.Add("nombrePunto", typeof(String));
            dtReporte.Columns.Add("importeTotal", typeof(String));
            dtReporte.Columns.Add("cantidadRecibos", typeof(String));

            DataTable dtReporteServicios = new DataTable();
            dtReporteServicios.Columns.Add("id_servicio", typeof(String));
            dtReporteServicios.Columns.Add("servicio", typeof(String));
            dtReporteServicios.Columns.Add("monto", typeof(String));

            DataTable dtReporte2 = new DataTable();
            dtReporte2.Columns.Add("forma_pago", typeof(String));
            dtReporte2.Columns.Add("cantidad", typeof(String));
            dtReporte2.Columns.Add("monto", typeof(String));

            DataTable dtReporteEgresos = new DataTable();
            dtReporteEgresos.Columns.Add("tipo", typeof(String));
            dtReporteEgresos.Columns.Add("monto", typeof(String));
            dtReporteEgresos.Columns.Add("personal", typeof(String));

            DataTable dtReporteEgresosResumen = new DataTable();
            dtReporteEgresosResumen.Columns.Add("tipo", typeof(String));
            dtReporteEgresosResumen.Columns.Add("monto", typeof(String));



            Puntos_Cobros oPuntoCobro = new Puntos_Cobros();

            nombrePuntoGestion = datosPunto.Rows[0]["descripcion"].ToString();
            ////datatable cuenta1
            DataRow dr1 = dtReporte.NewRow();
            if (cierraCaja)
            {
                dr1["IdCuenta"] = idCajaNueva;

            }
            else
                dr1["IdCuenta"] = 0;
            dr1["Fecha"] = DateTime.Now;
            dr1["Cuenta"] = "1";
            dr1["idPuntoGestion"] = Puntos_Cobros.Id_Punto;
            dr1["nombrePunto"] = nombrePuntoGestion;
            dr1["cantidadRecibos"] = dtRecibosCuenta1.Rows.Count;
            dr1["importeTotal"] = total;

            dtReporte.Rows.Add(dr1);



            DataRow drFormas1;
            foreach (DataRow item in dtFormasPagos.Rows)
            {
                drFormas1 = dtReporte2.NewRow();
                drFormas1["forma_pago"] = item["nombre"].ToString();
                drFormas1["cantidad"] = item["cantidad"].ToString();
                drFormas1["monto"] = item["importe"].ToString();

                dtReporte2.Rows.Add(drFormas1);
            }
            DataRow drEgresos;

            foreach (DataRow item in dtEgresos.Rows)
            {
                drEgresos = dtReporteEgresos.NewRow();
                drEgresos["tipo"] = item["tipo"].ToString().ToUpper();
                drEgresos["monto"] = item["monto"].ToString();
                drEgresos["personal"] = item["nombre"].ToString();

                dtReporteEgresos.Rows.Add(drEgresos);
            }
            DataTable dtEgresosAgrupados = new DataTable();
            dtEgresosAgrupados.Columns.Add("tipo", typeof(string));
            dtEgresosAgrupados.Columns.Add("monto", typeof(decimal));

            if (dtEgresos.Rows.Count > 0)
            {

                dtEgresosAgrupados = dtEgresos.AsEnumerable()
                .GroupBy(r => r.Field<string>("tipo"))
                .Select(g =>
                {
                    var row = dtEgresos.NewRow();

                    row["tipo"] = g.Key;
                    row["monto"] = g.Sum(r => r.Field<decimal>("monto"));


                    return row;
                }).CopyToDataTable();

                DataRow drEgresoResumen = dtEgresosAgrupados.NewRow();
                foreach (DataRow item in dtEgresosAgrupados.Rows)
                {
                    drEgresoResumen = dtEgresosAgrupados.NewRow();
                    drEgresoResumen["tipo"] = item["tipo"].ToString().ToUpper();
                    drEgresoResumen["monto"] = item["monto"].ToString();
                    dtReporteEgresos.ImportRow(drEgresoResumen);
                }
                dtEgresosAgrupados.Columns.Remove("id");
                dtEgresosAgrupados.Columns.Remove("id_punto_gestion");
                dtEgresosAgrupados.Columns.Remove("id_personal");
                dtEgresosAgrupados.Columns.Remove("fecha");
                dtEgresosAgrupados.Columns.Remove("id_caja");
                dtEgresosAgrupados.Columns.Remove("numero_comprobante");
                dtEgresosAgrupados.Columns.Remove("descripcion");
                dtEgresosAgrupados.Columns.Remove("nombre");
                dtEgresosAgrupados.Columns.Remove("detalle");
                //oImpresion.ImprimirEgresos(dtReporte, dtReporteEgresos, dtEgresosAgrupados);
            }

            if (dtSubServiciosPagos.Rows.Count > 0)
            {

                nombrePuntoGestion = datosPunto.Rows[0]["descripcion"].ToString();
                DataTable dtServicios = new DataTable();
                dtServicios.Columns.Add("servicio", typeof(string));
                dtServicios.Columns.Add("monto", typeof(string));

                dtServicios = dtSubServiciosPagos.AsEnumerable()
                .GroupBy(r => r.Field<string>("servicio"))
                .Select(g =>
                {
                    var row = dtServicios.NewRow();

                    row["servicio"] = g.Key;
                    row["monto"] = g.Sum(r => r.Field<decimal>("importe_imputa"));

                    return row;
                }).CopyToDataTable();
                foreach (DataRow item in dtServicios.Rows)
                {
                    if (string.IsNullOrEmpty(item["servicio"].ToString()))
                        item["servicio"] = "OTROS";
                }
                dtServicios.AcceptChanges();

                oImpresion.ImprimirDetalleCaja(dtReporte, dtReporte2, dtServicios, dtReporteEgresos, dtEgresosAgrupados);
            }

        }
        #endregion

        #region CONTROLES
        private void dgvFormas1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int idFormaSeleccionada = Convert.ToInt32(dgvFormas1.SelectedRows[0].Cells["id"].Value);
                if (idFormaSeleccionada == 0)
                {
                    Contabilidad.frmRetiros oFrmRetiros = new Contabilidad.frmRetiros(2, Convert.ToDecimal(dgvFormas1.Rows[0].Cells["importe"].Value));
                    frmPopUp oPop = new frmPopUp();
                    oPop.Formulario = oFrmRetiros;
                    oPop.Maximizar = false;
                    if (oPop.ShowDialog() == DialogResult.OK)
                    {
                        ListarEgresos();
                        comenzarCarga();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            dtSubServiciosPagos = oCajaDiaria.ListarDetallesCtaCteDetSubServicios(idPuntoCobro, idCaja, 1);
            if(cboPersonal.Text.ToLower()!="todos" && cierraCaja == false)
            {
                CalcularTotales(discriminaPersonal: true);
                DataView dvFiltroServiciosPagos = dtSubServiciosPagos.DefaultView;
                dvFiltroServiciosPagos.RowFilter = string.Format("personal='{0}'", cboPersonal.Text);
                dtSubServiciosPagos = dvFiltroServiciosPagos.ToTable();
            }
            else
                CalcularTotales(discriminaPersonal: false);

            //imprimirServicios();

            imprimirFormas();
            imprimirRecibos();
        }

        private void dgvPresentacion_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int tipo;
                tipo = Convert.ToInt32(dgvPresentacion.SelectedRows[0].Cells["tipo"].Value);
                if (tipo == 1)
                {
                    idReciboSeleccionado = Convert.ToInt32(dgvPresentacion.SelectedRows[0].Cells["id_recibo"].Value);
                    idComprobanteSeleccionado = Convert.ToInt32(dgvPresentacion.SelectedRows[0].Cells["id_comprobante"].Value);
                    btnCambio.Enabled = true;

                }
                else
                    btnCambio.Enabled = false;
            }
            catch (Exception)
            {
                throw;
            }
        }
        private void btnCambio_Click(object sender, EventArgs e)
        {
            decimal monto = Convert.ToDecimal(dgvPresentacion.SelectedRows[0].Cells["monto"].Value);
            int idUsuario = Convert.ToInt32(dgvPresentacion.SelectedRows[0].Cells["cod_usuario"].Value);
            int idLocacion = Convert.ToInt32(dgvPresentacion.SelectedRows[0].Cells["id_Locacion"].Value);
            frmUsuariosPagos oFrmUsuariosPagos = new frmUsuariosPagos(edicion: true, monto, idLocacion, idUsuario);
            oFrmUsuariosPagos.cuenta = 1;
            oFrmUsuariosPagos.viene = 2;

            if (oFrmUsuariosPagos.ShowDialog() == DialogResult.OK)
            {
                this.dtDetalleRecibo = oFrmUsuariosPagos.dtDetalleRecibo;
                try
                {
                    oUsuariosCtaCteRecibos.CambiarFormaPagoRecibo(idReciboSeleccionado, idComprobanteSeleccionado, dtDetalleRecibo);
                    MessageBox.Show("Cambios realizados correctamente", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    comenzarCarga();
                }
                catch
                {
                    MessageBox.Show("Hubo un error al cambiar la forma de pago.", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void btnRetiros_Click(object sender, EventArgs e)
        {
            Contabilidad.frmRetiros oFrmRetiros;
            if (this.idCaja==0)
                oFrmRetiros = new Contabilidad.frmRetiros(1, Convert.ToDecimal(dgvFormas1.Rows[0].Cells["importe"].Value));
            else
                oFrmRetiros = new Contabilidad.frmRetiros(2, Convert.ToDecimal(dgvFormas1.Rows[0].Cells["importe"].Value),this.idCaja);
            frmPopUp oPop = new frmPopUp();
            oPop.Formulario = oFrmRetiros;
            oPop.Maximizar = false;
            if (oPop.ShowDialog() == DialogResult.OK)
            {
                comenzarCarga();

            }

        }
        public frmCajaDetalle(int idcaja)
        {
            this.idCaja = idcaja;
            InitializeComponent();
        }

        private void frmCajaDetalle_Load(object sender, EventArgs e)
        {
            comenzarCarga();
        }
       
        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmCaja_Diaria_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
            if (e.KeyCode == Keys.F5)
            {
                if (scMain.Panel2Collapsed == true)
                {
                    scMain.Panel1Collapsed = true;
                    scMain.Panel2Collapsed = false;
                    pnlCuenta1Datos.Visible = false;
                    pnlTotalDatos.Visible = false;
                    pnlCuenta2Datos.Visible = true;

                    FormatearGrilla();
                }
                else
                {
                    scMain.Panel2Collapsed = true;
                    scMain.Panel1Collapsed = false;
                    pnlCuenta2Datos.Visible = false;
                    pnlCuenta1Datos.Visible = true;

                }

            }
        }

        private void txtCodUsuario_TextChanged(object sender, EventArgs e)
        {
            if (txtCodUsuario.Text.Length > 0)
            {

                if (dgvPresentacion.Rows.Count > 0)
                {
                    foreach (DataGridViewRow Row in dgvPresentacion.Rows)
                    {
                        int strFila = Row.Index;
                        string Valor = Convert.ToString(Row.Cells["cod_usuario"].Value);
                        Color ColorViejo = Row.DefaultCellStyle.BackColor;
                        int tipo = Convert.ToInt32(Row.Cells["tipo"].Value);
                        if ((Valor == this.txtCodUsuario.Text) && (tipo == 1))
                        {
                            dgvPresentacion.Rows[strFila].DefaultCellStyle.BackColor = Color.Red;
                            Row.Selected = true;
                        }
                        else
                        {
                            if (tipo == 1)
                            {
                                Row.Selected = false;
                            }
                        }
                    }
                }
                if (dgvPresentacion2.Rows.Count > 0)
                {
                    foreach (DataGridViewRow Row in dgvPresentacion2.Rows)
                    {
                        int strFila = Row.Index;
                        string Valor = Convert.ToString(Row.Cells["cod_usuario"].Value);
                        Color ColorViejo = Row.DefaultCellStyle.BackColor;
                        int tipo = Convert.ToInt32(Row.Cells["tipo"].Value);
                        if ((Valor == this.txtCodUsuario.Text) && (tipo == 1))
                        {
                            dgvPresentacion2.Rows[strFila].DefaultCellStyle.BackColor = Color.Red;
                            Row.Selected = true;
                        }
                        else
                        {
                            if (tipo == 1)
                            {
                                Row.Selected = false;
                            }
                        }
                    }
                }

            }
            else
            {
                FormatearGrilla();
            }
        }
        private void frmCajaDetalle_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 23)
            {
                if (pnlCuenta2Datos.Visible == false)
                {
                    pnlCuenta2Datos.Visible = true;
                    FormatearGrilla();
                    //CalcularTotales();
                    pnlTotalDatos.Visible = true;
                }
                else
                {
                    pnlTotalDatos.Visible = false;
                    pnlCuenta2Datos.Visible = false;
                }
            }
        }
        private void btnDetalles_Click(object sender, EventArgs e)
        {
            frmPopUp oPop = new frmPopUp();
            Contabilidad.frmReciboDetalle oReciboDet = new Contabilidad.frmReciboDetalle();
            oReciboDet.idComprobante = Convert.ToInt32(dgvPresentacion.SelectedRows[0].Cells["id_comprobante"].Value);
            oPop.Formulario = oReciboDet;

            oPop.Maximizar = false;
            oPop.ShowDialog();
        }

        private void comboPersonal_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvPresentacion.Rows)
            {
                try
                {
                    if (cboPersonal.SelectedIndex == 0)
                    {
                        row.Visible = true;
                    }
                    else if (row.Cells["Personal"].Value.ToString() != cboPersonal.Text)
                    {
                        row.Visible = false;
                    }
                    else
                    {
                        row.Visible = true;
                    }
                }
                catch { }
            }
        }        
        private void btnCerrar2_Click(object sender, EventArgs e)
        {
            cierraCaja = true;
            dtSubServiciosPagos = oCajaDiaria.ListarDetallesCtaCteDetSubServicios(idPuntoCobro, idCaja, 1);

       
            int numeroReciboDesde = 0;
            int numeroReciboHasta = 0;
            int puntoCobroNumero = 0;
            int numeroReciboDesde2 = 0;
            int numeroReciboHasta2 = 0;
            int puntoCobroNumero2 = 0;

            if (dtRecibosCuenta1.Rows.Count > 0)
            {
                numeroReciboDesde = Convert.ToInt32(dtRecibosCuenta1.Rows[0]["numero"]);
                numeroReciboHasta = Convert.ToInt32(dtRecibosCuenta1.Rows[dtRecibosCuenta1.Rows.Count - 1]["numero"]);
                puntoCobroNumero = Convert.ToInt32(datosPunto.Rows[0]["punto"]);
            }
            else
            {
                DataTable dtUltimaCaja = oCajaDiaria.UltimaCajaPuntoCobro(idPuntoCobro);
                if (dtUltimaCaja.Rows.Count > 0)
                {
                    numeroReciboDesde = Convert.ToInt32(dtUltimaCaja.Rows[0]["recibo_cuenta1_desde"]);
                    numeroReciboHasta = Convert.ToInt32(dtUltimaCaja.Rows[0]["recibo_cuenta1_hasta"]);
                    puntoCobroNumero = Convert.ToInt32(idPuntoCobro);
                }
                else
                {
                    numeroReciboDesde = 1;
                    numeroReciboHasta = 1;
                    puntoCobroNumero = Convert.ToInt32(idPuntoCobro);
                }
            }
            if (dtRecibosCuenta2.Rows.Count > 0)
            {
                numeroReciboDesde2 = Convert.ToInt32(dtRecibosCuenta2.Rows[0]["numero"]);
                numeroReciboHasta2 = Convert.ToInt32(dtRecibosCuenta2.Rows[dtRecibosCuenta2.Rows.Count - 1]["numero"]);
                puntoCobroNumero2 = Convert.ToInt32(datosPunto.Rows[0]["punto"]);
            }
            else
            {
                DataTable dtUltimaCaja = oCajaDiaria.UltimaCajaPuntoCobro(idPuntoCobro);
                if (dtUltimaCaja.Rows.Count > 0)
                {
                    numeroReciboDesde2 = Convert.ToInt32(dtUltimaCaja.Rows[0]["recibo_cuenta2_hasta"]);
                    numeroReciboHasta2 = Convert.ToInt32(dtUltimaCaja.Rows[0]["recibo_cuenta2_hasta"]);
                    puntoCobroNumero2 = Convert.ToInt32(idPuntoCobro);
                }
                else
                {
                    numeroReciboDesde2 = 0;
                    numeroReciboHasta2 = 0;
                    puntoCobroNumero2 = idPuntoCobro;
                }
            }
            oCajaDiaria.Id = 0;
            oCajaDiaria.Id_Personal = Personal.Id_Login;
            oCajaDiaria.Id_Puntos_cobros = Puntos_Cobros.Id_Punto;
            oCajaDiaria.Id_Cierre_General = 0;
            oCajaDiaria.Numero = 0;
            oCajaDiaria.Importe_cuenta1 = total;
            oCajaDiaria.Importe_cuenta2 = 0;
            oCajaDiaria.Recibo_cuenta1_desde = numeroReciboDesde;
            oCajaDiaria.Recibo_cuenta1_hasta = numeroReciboHasta;
            oCajaDiaria.Recibo_cuenta2_desde = numeroReciboDesde2;
            oCajaDiaria.Recibo_cuenta2_hasta = numeroReciboHasta2;
            oCajaDiaria.Fecha = DateTime.Now;//// .Today;

            string salida = "";
            idCajaNueva = oCajaDiaria.Guardar(oCajaDiaria,out salida);
            if (idCajaNueva > 0)
            {
                oEgreso.ActualizarEgresosCajas(idCajaNueva);

                oCajaDiaria.Asignar_Numero_Recibos(dtRecibosCuenta1, idCajaNueva, out salida);
                //oCajaDiaria.Asignar_Numero_Recibos(dtRecibosCuenta2, idCajaNueva);
                nombrePuntoGestion = datosPunto.Rows[0]["descripcion"].ToString();

                imprimirFormas();
                imprimirRecibos();
                comenzarCarga();
            }
            else
                MessageBox.Show($"Error al cerrar la caja.\n {salida}", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnMax_Click(object sender, EventArgs e)
        {
            if (menu == 0)
            {
                pnlFootTotal.Height = 324;
                btnMax.Visible = false;
                btnMin.Visible = true;
                menu = 1;
            }
            else
            {
                pnlFootTotal.Height = 50;
                btnMin.Visible = false;
                btnMax.Visible = true;
                menu = 0;

            }
        }

        private void txtNumRecibo_TextChanged(object sender, EventArgs e)
        {
            if (txtNumRecibo.Text == "")
            {
                if (dgvPresentacion.Rows.Count > 0)
                {

                    foreach (DataGridViewRow item in dgvPresentacion.Rows)
                    {
                        var tipo = Convert.ToInt32(item.Cells["tipo"].Value);
                        switch (tipo)
                        {
                            case 1:
                                item.DefaultCellStyle.BackColor = Color.LimeGreen;
                                break;
                            case 2:
                                item.DefaultCellStyle.BackColor = Color.DarkSeaGreen;
                                break;
                            case 3:
                                item.DefaultCellStyle.BackColor = Color.LightGreen;
                                break;
                            case 4:
                                item.DefaultCellStyle.BackColor = Color.YellowGreen;
                                break;
                            default:
                                item.DefaultCellStyle.BackColor = Color.White;
                                break;

                        };
                        item.Selected = true;
                    }
                }
                if (dgvPresentacion2.Rows.Count > 0)
                {

                    foreach (DataGridViewRow item in dgvPresentacion2.Rows)
                    {
                        var tipo = Convert.ToInt32(item.Cells["tipo"].Value);
                        switch (tipo)
                        {
                            case 1:
                                item.DefaultCellStyle.BackColor = Color.LimeGreen;
                                break;
                            case 2:
                                item.DefaultCellStyle.BackColor = Color.PaleGreen;
                                break;
                            case 3:
                                item.DefaultCellStyle.BackColor = Color.DarkSeaGreen;
                                break;
                            default:
                                item.DefaultCellStyle.BackColor = Color.White;
                                break;
                        };
                        item.Selected = true;
                    }
                }
            }
            else
            {
                if (dgvPresentacion.Rows.Count > 0)
                {
                    foreach (DataGridViewRow Row in dgvPresentacion.Rows)
                    {
                        int strFila = Row.Index;
                        string Valor = Convert.ToString(Row.Cells["codigo_muestra"].Value);
                        Color ColorViejo = Row.DefaultCellStyle.BackColor;
                        int tipo = Convert.ToInt32(Row.Cells["tipo"].Value);
                        if ((Valor.Contains(this.txtNumRecibo.Text)) && (tipo == 1))
                        {
                            dgvPresentacion.Rows[strFila].DefaultCellStyle.BackColor = Color.Red;
                            Row.Selected = true;
                        }
                        else
                        {
                            if (tipo == 1)
                            {
                                dgvPresentacion.Rows[strFila].DefaultCellStyle.BackColor = Color.LightSalmon;
                                Row.Selected = false;
                            }

                        }
                    }
                }
                if (dgvPresentacion2.Rows.Count > 0)
                {
                    foreach (DataGridViewRow Row in dgvPresentacion2.Rows)
                    {
                        int strFila = Row.Index;
                        string Valor = Convert.ToString(Row.Cells["codigo_muestra"].Value);
                        Color ColorViejo = Row.DefaultCellStyle.BackColor;
                        int tipo = Convert.ToInt32(Row.Cells["tipo"].Value);
                        if ((Valor.Contains(this.txtNumRecibo.Text)) && (tipo == 1))
                        {
                            dgvPresentacion2.Rows[strFila].DefaultCellStyle.BackColor = Color.Green;
                            Row.Selected = true;
                        }
                        else
                        {
                            if (tipo == 1)
                            {
                                dgvPresentacion2.Rows[strFila].DefaultCellStyle.BackColor = Color.LimeGreen;
                                Row.Selected = false;
                            }

                        }
                    }
                }
            }
        }
        #endregion
    }
}
