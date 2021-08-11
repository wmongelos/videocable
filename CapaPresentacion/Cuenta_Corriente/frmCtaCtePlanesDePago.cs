using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using CapaNegocios;
using System.Runtime.InteropServices;
using System.Collections;

namespace CapaPresentacion.Cuenta_Corriente
{
    public partial class frmCtaCtePlanesDePago : Form
    {
        private decimal montoTotalOriginal, montoTotalRestante, montoTotalRecargo, montoAnticipo, montoRecargo, porcentajeAnticipo, porcentajeRecargo, valorAnticipo;
        private int indice, idUsuarios, idUsuariosLocaciones, idReciboPlan;

        private bool generarPlanDePago = false;
        private Thread hilo;
        private delegate void myDel();
        private DataTable dtDatosCtaCte = new DataTable();
        private DataTable dtDatosDb = new DataTable();
        private DataTable dtComprobantesAdeudados = new DataTable();
        private DataTable dtVistaPreviaCuotas = new DataTable();
        private DataTable dtCtaCteDetComprobantesAdeudados = new DataTable();
        private DataTable dtCtaCteDetComprobantesAdeudadosDb = new DataTable();
        private DataTable dtDetalleReciboSeleccionados = new DataTable();
        private DataTable dtDetallesRecibo = new DataTable();
        private DataTable dtDetalleFormaDePago = new DataTable();
        private DataTable dtUsuarios = new DataTable();
        private Usuarios_CtaCte oUsuariosCtaCte = new Usuarios_CtaCte();
        private Comprobantes_Tipo oComprobantesTipo = new Comprobantes_Tipo();
        private Comprobantes oComprobantes = new Comprobantes();
        private Usuarios_CtaCte_Recibos oUsuariosCtaCteRecibos = new Usuarios_CtaCte_Recibos();
        private Usuarios_CtaCte_Det oUsuariosCtaCteDet = new Usuarios_CtaCte_Det();
        private Usuarios oUsuarios = new Usuarios();
        private string muestra;
        private char pad = '0';

        private void ComenzarCarga()
        {
            pgCircular.Start();
            foreach (Control item in this.Controls)
            {
                if (item.Name != "pgCircular")
                    item.Enabled = false;
            }
            hilo = new Thread(new ThreadStart(CargarDatos))
            {
                IsBackground = true
            };
            hilo.Start();
        }

        private void CargarDatos()
        {
            //try
            //{
                myDel MD;
                    oUsuarios.Codigo = 0;
                    oUsuarios.Usuario = "";
                    oUsuarios.Calle = "";
                    oUsuarios.Altura = 0;
                    oUsuarios.Apellido = "";
                    oUsuarios.Nombre = "";
                    oUsuarios.Depto = "";
                    oUsuarios.CUIT = 0;
                    oUsuarios.Numero_Documento = 0;
                    dtUsuarios = oUsuarios.tempDatosUsuarios(Usuarios.CurrentUsuario.Id);

                    dtComprobantesAdeudados.Clear();
                    dtComprobantesAdeudados = dtDetallesRecibo.Clone();

                    ConfigurarGrillaDatosComprobantes();
                MD = new myDel(AsignarDatos);
                this.Invoke(MD, new object[] { });
                pgCircular.Stop();

            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Error al cargar Informacion" + ex.Message);
            //}
        }

        private void AsignarDatos()
        {
            foreach (Control item in this.Controls)
                item.Enabled = true;
            if (generarPlanDePago == false)
            {
                dgvComprobantesAdeudados.DataSource = null;
                dgvComprobantesAdeudados.DataSource = dtComprobantesAdeudados;
                for (int x = 0; x < dgvComprobantesAdeudados.Columns.Count; x++)
                    dgvComprobantesAdeudados.Columns[x].Visible = false;

                dgvComprobantesAdeudados.Columns["Servicio"].Visible = true;
                dgvComprobantesAdeudados.Columns["importe_total"].Visible = true;
                dgvComprobantesAdeudados.Columns["fecha_desde"].Visible = true;
                dgvComprobantesAdeudados.Columns["fecha_hasta"].Visible = true;
                dgvComprobantesAdeudados.Columns["elegir"].Visible = true;

                dgvComprobantesAdeudados.Columns["Servicio"].HeaderText = "Descripción";
                dgvComprobantesAdeudados.Columns["importe_total"].HeaderText = "Saldo";
                dgvComprobantesAdeudados.Columns["fecha_desde"].HeaderText = "Desde";
                dgvComprobantesAdeudados.Columns["fecha_hasta"].HeaderText = "Hasta";
                dgvComprobantesAdeudados.Columns["elegir"].HeaderText = "Elegir";

                dgvComprobantesAdeudados.Columns["importe_saldo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvComprobantesAdeudados.Columns["fecha_desde"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvComprobantesAdeudados.Columns["fecha_hasta"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvComprobantesAdeudados.Columns["importe_saldo"].DefaultCellStyle.Format = "c2";
                dgvComprobantesAdeudados.Columns["Servicio"].Width = 350;
                dgvComprobantesAdeudados.Columns["elegir"].Width = 70;

                dgvComprobantesAdeudados.ReadOnly = false;
                dgvComprobantesAdeudados.Columns["Servicio"].ReadOnly = true;
                dgvComprobantesAdeudados.Columns["importe_saldo"].ReadOnly = true;
                dgvComprobantesAdeudados.Columns["fecha_desde"].ReadOnly = true;
                dgvComprobantesAdeudados.Columns["fecha_hasta"].ReadOnly = true;
                dgvComprobantesAdeudados.Columns["elegir"].ReadOnly = false;

                montoTotalOriginal = 0;
                foreach(DataRow fila in dtComprobantesAdeudados.Rows)
                {
                    if (fila["elegir"].ToString()=="True" && Convert.ToInt32(fila["encabezado"])==0)
                        montoTotalOriginal += Convert.ToDecimal(fila["importe_total"]);
                }

                if (montoTotalOriginal == 0)
                {
                    spAnticipo.Maximum = montoTotalOriginal;
                    valorAnticipo = 0;
                    porcentajeAnticipo = 0;
                    montoTotalRestante = 0;
                    porcentajeRecargo = 0;
                    montoRecargo = 0;
                    montoTotalRecargo = 0;
                    lblMontoTotalOriginal.Text = String.Format("Monto total original: ${0}", montoTotalOriginal);
                    lblMontoTotalOriginal.Location = new Point(this.Width - lblMontoTotalOriginal.Width, lblMontoTotalOriginal.Location.Y);
                    lblMontoRestante.Text = String.Format("Monto restante: ${0}", montoTotalRestante);
                    lblMontoRecargo.Text = String.Format("Monto final a pagar en cuotas: ${0}", montoTotalRecargo);
                }
                else
                    RecalcularMontos();

                DataView dtv = dtUsuarios.DefaultView;
                dtv.RowFilter = string.Format("id_usuarios_locaciones = {0} ", idUsuariosLocaciones);
                dtUsuarios = dtv.ToTable();
                LBApellido.Text = dtUsuarios.Rows[0]["apellido"].ToString().Trim() + " , " + (dtUsuarios.Rows[0]["nombre"].ToString()).ToUpperInvariant() + " [" + dtUsuarios.Rows[0]["codigo"].ToString() + "]";
                LBNumero_documento.Text = "Documento : (" + dtUsuarios.Rows[0]["tipo_doc"].ToString() + ") Nro " + dtUsuarios.Rows[0]["numero_documento"].ToString();
                lbcuit.Text = "C. Iva : (" + dtUsuarios.Rows[0]["condicion_iva"].ToString() + ") Nro " + dtUsuarios.Rows[0]["cuit"].ToString();
                lblLocacion.Text = String.Format("Locación: {0}, {1} {2} ", dtUsuarios.Rows[0]["localidad"], dtUsuarios.Rows[0]["calle"], dtUsuarios.Rows[0]["altura"]);
                lbcorreo.Text = "Mail: " + dtUsuarios.Rows[0]["Correo_electronico"].ToString();
            }
            else
            {
                btnGenerarComprobantes.Enabled = true;
                generarPlanDePago = false;
                MessageBox.Show("Plan de pago generado correctamente.");
                this.DialogResult = DialogResult.OK;
            }
        }

        private void GenerarVistaPreviaPlanPago()
        {
            indice = 0;
            indice = Convert.ToInt32(spCantidadCuotas.Value);
            int numeroCuota;
            decimal importe;
            DateTime fechaInicio = dpFechaComienzoPago.Value.Date;
            importe =decimal.Round(montoTotalRecargo / indice,2);
           

            dtVistaPreviaCuotas.Clear();
            dgvComprobantesPlanDePago.DataSource = null;

            for (int x=0; x<indice;x++)
            {
                numeroCuota = x + 1;
                //dtVistaPreviaCuotas.Rows.Add(numeroCuota.ToString(), importe.ToString(), fechaInicio.Date.ToString("yyyy-MM-dd"), fechaInicio.Date.AddMonths(1).AddDays(-1).ToString("yyyy-MM-dd"), fechaInicio.Date.AddMonths(1).ToString("yyyy-MM-dd"), fechaInicio.Date.AddMonths(1).AddDays(15).ToString("yyyy-MM-dd"), idUsuarios.ToString(), DateTime.Now.ToString(), idUsuariosLocaciones.ToString());
                dtVistaPreviaCuotas.Rows.Add(numeroCuota.ToString(), importe.ToString(), fechaInicio.Date.ToString("yyyy-MM-dd"), fechaInicio.Date.ToString("yyyy-MM-dd"), fechaInicio.Date.ToString("yyyy-MM-dd"), fechaInicio.Date.ToString("yyyy-MM-dd"), idUsuarios.ToString(), DateTime.Now.ToString(), idUsuariosLocaciones.ToString());

                fechaInicio = fechaInicio.AddMonths(1);
            }

            dgvComprobantesPlanDePago.DataSource = dtVistaPreviaCuotas;

            for (int x = 0; x < dgvComprobantesPlanDePago.Columns.Count; x++)
                dgvComprobantesPlanDePago.Columns[x].Visible = false;

            dgvComprobantesPlanDePago.Columns["numeroCuota"].Visible = true;
            dgvComprobantesPlanDePago.Columns["importe"].Visible = true;
            dgvComprobantesPlanDePago.Columns["primerVencimiento"].Visible = true;
         
            dgvComprobantesPlanDePago.Columns["numeroCuota"].HeaderText = "Cuota";
            dgvComprobantesPlanDePago.Columns["importe"].HeaderText = "Importe";
            dgvComprobantesPlanDePago.Columns["primerVencimiento"].HeaderText = "Vencimiento";

            dgvComprobantesPlanDePago.Columns["numeroCuota"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvComprobantesPlanDePago.Columns["importe"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvComprobantesPlanDePago.Columns["primerVencimiento"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvComprobantesPlanDePago.Columns["importe"].DefaultCellStyle.Format = "c2";
        }

        private void GuardarPlanPago()
        {
            DataRow drDatosComprobante;
            int numeroRecibo, puntoVenta, numeroComprobante;
            string numeroDescripcion;
            dtCtaCteDetComprobantesAdeudados.Clear();
            foreach (DataRow fila in dtComprobantesAdeudados.Rows)
            {

                if (fila["elegir"].ToString() == "True")
                    fila["importe_pago"] = fila["importe_saldo"];


                if(Convert.ToInt32(fila["encabezado"])==2)
                {
                    dtCtaCteDetComprobantesAdeudadosDb.Clear();
                    dtCtaCteDetComprobantesAdeudadosDb = oUsuariosCtaCte.ListarMovimiento(Convert.ToInt32(fila["id"]), 0, 0, 0, DateTime.Now, DateTime.Now, Usuarios_CtaCte.FECHA_CONSULTA_MOVIMIENTOS_CTACTE.FECHA_DESDE);

                    if (dtCtaCteDetComprobantesAdeudados.Rows.Count == 0)
                        dtCtaCteDetComprobantesAdeudados = dtCtaCteDetComprobantesAdeudadosDb.Clone();

                    if(dtCtaCteDetComprobantesAdeudadosDb.Rows.Count>0)
                    {
                        foreach (DataRow registroCtaCteDet in dtCtaCteDetComprobantesAdeudadosDb.Rows)
                            dtCtaCteDetComprobantesAdeudados.ImportRow(registroCtaCteDet);
                    }
                }               
            }

            if (dtCtaCteDetComprobantesAdeudados.Columns.IndexOf("elegir") != -1)
                dtCtaCteDetComprobantesAdeudados.Columns.RemoveAt(dtCtaCteDetComprobantesAdeudados.Columns.IndexOf("elegir"));

            dtCtaCteDetComprobantesAdeudados.Columns.Add("elegir", typeof(bool));

            foreach (DataRow fila in dtCtaCteDetComprobantesAdeudados.Rows)
            {
                try
                {
                    fila["elegir"] = dtComprobantesAdeudados.Select(String.Format("id='{0}' and encabezado=0", fila["id"].ToString()))[0]["elegir"];
                }
                catch { fila["elegir"] = "False"; }
            }

            drDatosComprobante = oComprobantesTipo.GetNumeracion(Convert.ToInt32(Comprobantes_Tipo.Tipo.PLAN_DE_PAGO), Puntos_Cobros.Id_Punto);
            numeroRecibo = Convert.ToInt32(drDatosComprobante["numComprobante"]);
            puntoVenta = Convert.ToInt32(drDatosComprobante["numPuntoVenta"]);
            numeroDescripcion ="PLAN DE PAGO " + puntoVenta.ToString().PadLeft(4, '0') + "-" + numeroRecibo.ToString().PadLeft(8, '0');
            if (numeroRecibo > 0)
                oComprobantesTipo.SetNumeracion(Convert.ToInt32(drDatosComprobante["idPuntoVenta"]), Convert.ToInt32(Comprobantes_Tipo.Tipo.PLAN_DE_PAGO), numeroRecibo);

            oComprobantes.Id_Usuarios = idUsuarios;
            oComprobantes.Fecha = DateTime.Now;
            oComprobantes.Punto_Venta = puntoVenta;
            oComprobantes.Numero = numeroRecibo;
            oComprobantes.Id_Comprobantes_Tipo = (int)Comprobantes_Tipo.Tipo.PLAN_DE_PAGO;
            oComprobantes.Importe = montoTotalOriginal;
            oComprobantes.Id_Punto_Venta = Convert.ToInt32(drDatosComprobante["idPuntoVenta"]);
            oComprobantes.Punto_Venta = puntoVenta;
            oComprobantes.Id_Personal = Personal.Id_Login;
            oComprobantes.Id_Punto_Cobro = Puntos_Cobros.Id_Punto;
            oComprobantes.Id_Usuarios_Locaciones = idUsuariosLocaciones;
            oComprobantes.Id = oComprobantes.Guardar(oComprobantes);

            oUsuariosCtaCteRecibos.Id_Usuarios = Usuarios.CurrentUsuario.Id;
            oUsuariosCtaCteRecibos.Id_Usuarios_Locacion = idUsuariosLocaciones;
            oUsuariosCtaCteRecibos.Fecha_Movimiento = DateTime.Now;
            oUsuariosCtaCteRecibos.Importe_Final = oComprobantes.Importe;
            oUsuariosCtaCteRecibos.Id_Comprobantes = oComprobantes.Id;
            oUsuariosCtaCteRecibos.Numero_Muestra = numeroDescripcion;
            oUsuariosCtaCteRecibos.Descripcion = oUsuariosCtaCteRecibos.Numero_Muestra;
            oUsuariosCtaCteRecibos.Numero = numeroRecibo;
            oUsuariosCtaCteRecibos.Id_Puntos_Cobro = Puntos_Cobros.Id_Punto;
            oUsuariosCtaCteRecibos.Id_Punto_Venta= Convert.ToInt32(drDatosComprobante["idPuntoVenta"]);
            oUsuariosCtaCteRecibos.Id_Personal = Personal.Id_Login;
            oUsuariosCtaCteRecibos.Id_Presentacion_Deb = 0;
            dtDetalleFormaDePago.Rows.Add("", oUsuariosCtaCteRecibos.Importe_Final, "", "", "", "", "", oUsuariosCtaCteRecibos.Fecha_Movimiento.ToString(), DateTime.Now.ToString(), oUsuariosCtaCteRecibos.Numero, Convert.ToInt32(Formas_de_pago.Tipos_Formas_Pagos.PLAN_DE_PAGO), idUsuariosLocaciones);

            DataView dtv = dtComprobantesAdeudados.DefaultView;
            dtv.RowFilter = string.Format("elegir = {0} ", true);
            dtDetalleReciboSeleccionados = dtv.ToTable();
            string salida = "";

            //momentaneamente le cambio el presenta ventas de 1 a 0 porque el importe imputa deja afuera el importe provincial (en el metodo de guardar de recibos, if presenta_ventas==0 importe_provincial=0)
            foreach (DataRow det in dtDetalleReciboSeleccionados.Rows)
            {
                det["importe_pago"] = det["importe_total"];
                det["importe_saldo"] = det["importe_total"];
            }
            oUsuariosCtaCteRecibos.guardar(oUsuariosCtaCteRecibos, dtDetalleFormaDePago, dtDetalleReciboSeleccionados, 1,out salida);
            idReciboPlan = oUsuariosCtaCteRecibos.Id;
            foreach (DataRowView dr in dtv)
            {
                if (Convert.ToInt32(dr["muestra"]) == 1)
                    oUsuariosCtaCte.SetDetallePlanPago(Convert.ToInt32(dr["Id_Usuarios_CtaCte"]), numeroDescripcion);
            }


            if (valorAnticipo>0)
            {
                drDatosComprobante = null;
                drDatosComprobante = oComprobantesTipo.GetNumeracion(Convert.ToInt32(Comprobantes_Tipo.Tipo.PLAN_DE_PAGO), Puntos_Cobros.Id_Punto);
                numeroComprobante = Convert.ToInt32(drDatosComprobante["numComprobante"]);
                if (numeroComprobante > 0)
                    oComprobantesTipo.SetNumeracion(Convert.ToInt32(drDatosComprobante["idPuntoVenta"]), Convert.ToInt32(Comprobantes_Tipo.Tipo.PLAN_DE_PAGO), Convert.ToInt32(drDatosComprobante["numComprobante"]));

                decimal importeAux = 0;
                oComprobantes.Id_Usuarios = idUsuarios;
                oComprobantes.Fecha = DateTime.Now;
                oComprobantes.Punto_Venta = Convert.ToInt32(drDatosComprobante["numPuntoVenta"]);
                oComprobantes.Id_Comprobantes_Tipo = Convert.ToInt32(Comprobantes_Tipo.Tipo.PLAN_DE_PAGO);
                oComprobantes.Numero = Convert.ToInt32(drDatosComprobante["numComprobante"]);

                oComprobantes.Importe = 0;
                foreach (DataRow filaCtaCteDet in dtCtaCteDetComprobantesAdeudados.Select(String.Format("elegir={0}", true)))
                {
                    importeAux = 0;
                    //importeAux = Convert.ToDecimal(filaCtaCteDet["importe_original"]);
                    filaCtaCteDet["importe_original"] = filaCtaCteDet["importe_saldo"];
                    importeAux = Convert.ToDecimal(filaCtaCteDet["importe_original"]);
                    oComprobantes.Importe += (importeAux * porcentajeAnticipo) / 100;
                }

                if (oComprobantes.Importe > 0)
                {
                    oComprobantes.Id_Usuarios_Locaciones = idUsuariosLocaciones;
                    oComprobantes.Id_Punto_Venta = Convert.ToInt32(drDatosComprobante["idPuntoVenta"]);
                    oComprobantes.Id_Personal = Personal.Id_Login;
                    oComprobantes.Id_Punto_Cobro = Puntos_Cobros.Id_Punto;
                    oComprobantes.Id = oComprobantes.Guardar(oComprobantes);

                    oUsuariosCtaCte.Id_Usuarios = idUsuarios;
                    oUsuariosCtaCte.Id_Comprobantes = oComprobantes.Id;
                    oUsuariosCtaCte.Fecha_Movimiento = DateTime.Now;
                    oUsuariosCtaCte.Fecha_Desde = DateTime.Today;
                    oUsuariosCtaCte.Fecha_Hasta = DateTime.Today;
                    

                    muestra = "PLAN DE PAGO " + Convert.ToInt32(drDatosComprobante["numPuntoVenta"]).ToString().PadLeft(4, pad) + "-" + oUsuariosCtaCte.Id_Comprobantes.ToString().PadLeft(8, pad);
                    oUsuariosCtaCte.Descripcion = muestra;
                    oUsuariosCtaCte.Importe_Original = oComprobantes.Importe;
                    oUsuariosCtaCte.Importe_Punitorio = 0;
                    oUsuariosCtaCte.Importe_Bonificacion = 0;
                    oUsuariosCtaCte.Importe_Final = oComprobantes.Importe;
                    oUsuariosCtaCte.Importe_Saldo = oComprobantes.Importe;
                    oUsuariosCtaCte.Id_Usuarios_Locacion = oComprobantes.Id_Usuarios_Locaciones;
                    oUsuariosCtaCte.Numero = oComprobantes.Numero.ToString();
                    oUsuariosCtaCte.Id_Comprobantes_Tipo = Convert.ToInt32(Comprobantes_Tipo.Tipo.PLAN_DE_PAGO);
                    oUsuariosCtaCte.Id_Comprobantes_Ref = 0;
                    oUsuariosCtaCte.Id_Facturacion = 0;
                    oUsuariosCtaCte.Generado_facturacion_mensual = Convert.ToInt32(Usuarios_CtaCte.GENERADO_FACTURACION_MENSUAL.NO);
                    oUsuariosCtaCte.Id_Personal = Personal.Id_Login;
                    oUsuariosCtaCte.Id_Origen = (int)Usuarios_CtaCte.ORIGEN.OTROS;
                    oUsuariosCtaCte.Id_Ctacte_Recibo_Plan = idReciboPlan;
                    oUsuariosCtaCte.Porcentaje_Percepcion = Usuarios.CurrentUsuario.Impuesto_Provincial;
                        
                    oUsuariosCtaCte.Guardar(oUsuariosCtaCte);

                    foreach (DataRow filaCtaCteDet in dtCtaCteDetComprobantesAdeudados.Select(String.Format("elegir={0}", true)))
                    {
                        oUsuariosCtaCteDet.Id_Usuarios_CtaCte = oUsuariosCtaCte.Id;
                        oUsuariosCtaCteDet.Id_Usuarios_Locaciones = Convert.ToInt32(filaCtaCteDet["id_usuarios_locaciones"]);
                        oUsuariosCtaCteDet.Id_Zonas = Convert.ToInt32(filaCtaCteDet["id_tipo_facturacion"]);
                        oUsuariosCtaCteDet.Id_Servicios = Convert.ToInt32(filaCtaCteDet["id_servicios"]);
                        oUsuariosCtaCteDet.Id_Tipo = Convert.ToInt32(filaCtaCteDet["id_tipo"]);
                        oUsuariosCtaCteDet.Tipo = filaCtaCteDet["tipo"].ToString();
                        oUsuariosCtaCteDet.Importe_Original = (Convert.ToDecimal(filaCtaCteDet["importe_original"]) * porcentajeAnticipo) / 100;
                        oUsuariosCtaCteDet.Importe_Saldo = oUsuariosCtaCteDet.Importe_Original;
                        oUsuariosCtaCteDet.Importe_Final = oUsuariosCtaCteDet.Importe_Original;
                       // oUsuariosCtaCteDet.Importe_Saldo = (oUsuariosCtaCteDet.Importe_Saldo * porcentajeAnticipo) / 100 ;
                        oUsuariosCtaCteDet.Importe_Punitorio = 0;
                        oUsuariosCtaCteDet.Importe_Bonificacion = 0;
                        oUsuariosCtaCteDet.Id_Usuarios_Servicios = Convert.ToInt32(filaCtaCteDet["id_usuarios_servicios"]);
                        oUsuariosCtaCteDet.Id_Velocidades_Tip = Convert.ToInt32(filaCtaCteDet["id_velocidades_tip"]);
                        oUsuariosCtaCteDet.Id_Velocidades = Convert.ToInt32(filaCtaCteDet["id_velocidades"]);
                        oUsuariosCtaCteDet.Id_Tipo_Facturacion = Convert.ToInt32(filaCtaCteDet["id_tipo_facturacion"]);

                        try
                        {
                            oUsuariosCtaCteDet.Requiere_IP = Convert.ToInt32(filaCtaCteDet["requiere_ip"]);
                        }
                        catch
                        {
                            oUsuariosCtaCteDet.Requiere_IP = 0;
                        }
                        oUsuariosCtaCteDet.Cantidad_Periodos = Convert.ToInt32(filaCtaCteDet["cantidad_periodos"]);
                        oUsuariosCtaCteDet.Id_Usuarios_Servicios_sub = Convert.ToInt32(filaCtaCteDet["id_usuarios_servicios_sub"]);
                        oUsuariosCtaCteDet.Fecha_Desde = DateTime.Now;
                        oUsuariosCtaCteDet.Fecha_Hasta = DateTime.Now;
                        oUsuariosCtaCteDet.Id_bonificacion_Aplicada = 0;
                        oUsuariosCtaCteDet.Nombre_Bonificacion = "";
                        oUsuariosCtaCteDet.Porcentaje_Bonificacion = 0;
                        oUsuariosCtaCteDet.Periodo_Mes = Convert.ToInt32(filaCtaCteDet["periodo_mes"]);
                        oUsuariosCtaCteDet.Periodo_Ano = Convert.ToInt32(filaCtaCteDet["periodo_ano"]);
                        oUsuariosCtaCteDet.Detalles = "ANTICIPO PLAN DE PAGO";

                        oUsuariosCtaCteDet.Guardar(oUsuariosCtaCteDet);
                    }
                }
            }

            RecalcularMontosCtaCteDetParaCuotas();

            for (int x=0;x<spCantidadCuotas.Value;x++)
            {
                oComprobantes.Importe = 0;
                drDatosComprobante = null;
                drDatosComprobante = oComprobantesTipo.GetNumeracion(Convert.ToInt32(Comprobantes_Tipo.Tipo.PLAN_DE_PAGO), Puntos_Cobros.Id_Punto);
                numeroComprobante = Convert.ToInt32(drDatosComprobante["numComprobante"]);
                if (numeroComprobante > 0)
                    oComprobantesTipo.SetNumeracion(Convert.ToInt32(drDatosComprobante["idPuntoVenta"]), Convert.ToInt32(Comprobantes_Tipo.Tipo.PLAN_DE_PAGO), Convert.ToInt32(drDatosComprobante["numComprobante"]));
                
                oComprobantes.Id_Usuarios = idUsuarios;
                oComprobantes.Fecha = DateTime.Now;
                oComprobantes.Punto_Venta = Convert.ToInt32(drDatosComprobante["numPuntoVenta"]);
                oComprobantes.Id_Comprobantes_Tipo = Convert.ToInt32(Comprobantes_Tipo.Tipo.PLAN_DE_PAGO);
                oComprobantes.Numero = Convert.ToInt32(drDatosComprobante["numComprobante"]);
                muestra = "PLAN DE PAGO " + Convert.ToInt32(drDatosComprobante["numPuntoVenta"]).ToString().PadLeft(4, pad) + "-" + numeroRecibo.ToString().PadLeft(8, '0') + " " + (x + 1).ToString() + " de " + spCantidadCuotas.Value.ToString();
                oComprobantes.Descripcion = muestra;
                foreach (DataRow filaCtaCteDet in dtCtaCteDetComprobantesAdeudados.Select(String.Format("elegir={0}", true)))
                    oComprobantes.Importe += Convert.ToDecimal(filaCtaCteDet["importe_original"]);

                if (oComprobantes.Importe > 0)
                {
                    oComprobantes.Id_Usuarios_Locaciones = idUsuariosLocaciones;
                    oComprobantes.Id_Punto_Venta = Convert.ToInt32(drDatosComprobante["idPuntoVenta"]);
                    oComprobantes.Id_Personal = Personal.Id_Login;
                    oComprobantes.Id_Punto_Cobro = Puntos_Cobros.Id_Punto;
                    oComprobantes.Id = oComprobantes.Guardar(oComprobantes);

                    oUsuariosCtaCte.Id_Usuarios = idUsuarios;
                    oUsuariosCtaCte.Id_Comprobantes = oComprobantes.Id;
                    oUsuariosCtaCte.Fecha_Movimiento = DateTime.Now;
                    oUsuariosCtaCte.Fecha_Desde = Convert.ToDateTime(dtVistaPreviaCuotas.Rows[x]["fechaDesde"]);
                    oUsuariosCtaCte.Fecha_Hasta = Convert.ToDateTime(dtVistaPreviaCuotas.Rows[x]["fechaHasta"]);



                    // muestra = "PLAN DE PAGO " + Convert.ToInt32(drDatosComprobante["numPuntoVenta"]).ToString().PadLeft(4, pad) + "-" + oUsuariosCtaCte.Id_Comprobantes.ToString().PadLeft(8, pad) +" "+ (x+1).ToString() + " de " + spCantidadCuotas.Value.ToString(); ;


                    oUsuariosCtaCte.Descripcion = muestra;
                    oUsuariosCtaCte.Importe_Original = oComprobantes.Importe;
                    oUsuariosCtaCte.Importe_Punitorio = 0;
                    oUsuariosCtaCte.Importe_Bonificacion = 0;
                    oUsuariosCtaCte.Importe_Final = oComprobantes.Importe;
                    oUsuariosCtaCte.Importe_Saldo = oComprobantes.Importe;
                    oUsuariosCtaCte.Id_Usuarios_Locacion = oComprobantes.Id_Usuarios_Locaciones;
                    oUsuariosCtaCte.Numero = oComprobantes.Numero.ToString();
                    oUsuariosCtaCte.Id_Comprobantes_Tipo = Convert.ToInt32(Comprobantes_Tipo.Tipo.PLAN_DE_PAGO);
                    oUsuariosCtaCte.Id_Comprobantes_Ref = 0;
                    oUsuariosCtaCte.Id_Facturacion = 0;
                    oUsuariosCtaCte.Generado_facturacion_mensual = Convert.ToInt32(Usuarios_CtaCte.GENERADO_FACTURACION_MENSUAL.NO);
                    oUsuariosCtaCte.Id_Personal = Personal.Id_Login;
                    oUsuariosCtaCte.Id_Origen = (int)Usuarios_CtaCte.ORIGEN.OTROS;
                    oUsuariosCtaCte.Id_Ctacte_Recibo_Plan = idReciboPlan;
                    oUsuariosCtaCte.Porcentaje_Percepcion = Usuarios.CurrentUsuario.Impuesto_Provincial;

                    oUsuariosCtaCte.Guardar(oUsuariosCtaCte);
                    string salidaDet = "";
                    List<Usuarios_CtaCte_Det> listaDet = new List<Usuarios_CtaCte_Det>();

                    foreach (DataRow filaCtaCteDet in dtCtaCteDetComprobantesAdeudados.Select(String.Format("elegir={0}", true)))
                    {
                        oUsuariosCtaCteDet = new Usuarios_CtaCte_Det();
                        oUsuariosCtaCteDet.Id_Usuarios_CtaCte = oUsuariosCtaCte.Id;
                        oUsuariosCtaCteDet.Id_Usuarios_Locaciones = Convert.ToInt32(filaCtaCteDet["id_usuarios_locaciones"]);
                        if(Convert.ToInt32(filaCtaCteDet["id_usuarios_servicios_sub"])!=0)
                            oUsuariosCtaCteDet.Id_Zonas = Convert.ToInt32(filaCtaCteDet["id_tipo_facturacion"]);
                        else
                            oUsuariosCtaCteDet.Id_Zonas = 0;

                        oUsuariosCtaCteDet.Id_Servicios = Convert.ToInt32(filaCtaCteDet["id_servicios"]);
                        oUsuariosCtaCteDet.Id_Tipo = Convert.ToInt32(filaCtaCteDet["id_tipo"]);
                        oUsuariosCtaCteDet.Tipo = filaCtaCteDet["tipo"].ToString();
                        oUsuariosCtaCteDet.Importe_Original = Convert.ToDecimal(filaCtaCteDet["importe_original"]);
                        oUsuariosCtaCteDet.Importe_Saldo = oUsuariosCtaCteDet.Importe_Original;
                        oUsuariosCtaCteDet.Importe_Final = oUsuariosCtaCteDet.Importe_Original;
                        oUsuariosCtaCteDet.Importe_Punitorio = 0;
                        oUsuariosCtaCteDet.Importe_Bonificacion = 0;
                        oUsuariosCtaCteDet.Id_Usuarios_Servicios = Convert.ToInt32(filaCtaCteDet["id_usuarios_servicios"]);
                        oUsuariosCtaCteDet.Id_Velocidades_Tip = Convert.ToInt32(filaCtaCteDet["id_velocidades_tip"]);
                        oUsuariosCtaCteDet.Id_Velocidades = Convert.ToInt32(filaCtaCteDet["id_velocidades"]);
                        oUsuariosCtaCteDet.Requiere_IP = Convert.ToInt32(filaCtaCteDet["requiere_ip"]);
                        oUsuariosCtaCteDet.Cantidad_Periodos = Convert.ToInt32(filaCtaCteDet["cantidad_periodos"]);
                        oUsuariosCtaCteDet.Id_Usuarios_Servicios_sub = Convert.ToInt32(filaCtaCteDet["id_usuarios_servicios_sub"]);
                        oUsuariosCtaCteDet.Fecha_Desde = oUsuariosCtaCte.Fecha_Desde;
                        oUsuariosCtaCteDet.Fecha_Hasta = oUsuariosCtaCte.Fecha_Hasta;
                        oUsuariosCtaCteDet.Id_bonificacion_Aplicada = 0;
                        oUsuariosCtaCteDet.Nombre_Bonificacion = "";
                        oUsuariosCtaCteDet.Porcentaje_Bonificacion = 0;
                        oUsuariosCtaCteDet.Periodo_Mes = Convert.ToInt32(filaCtaCteDet["periodo_mes"]);
                        oUsuariosCtaCteDet.Periodo_Ano = Convert.ToInt32(filaCtaCteDet["periodo_ano"]);
                        oUsuariosCtaCteDet.Detalles = string.Format("CUOTA PLAN DE PAGO {0} de {1}", x + 1, spCantidadCuotas.Value);
                        object tipoFac = filaCtaCteDet["id_tipo_facturacion"];
                        if (tipoFac == DBNull.Value)
                            oUsuariosCtaCteDet.Id_Tipo_Facturacion = 0;
                        else
                            oUsuariosCtaCteDet.Id_Tipo_Facturacion = Convert.ToInt32(filaCtaCteDet["id_tipo_facturacion"]);


                        listaDet.Add(oUsuariosCtaCteDet);
                    }
                    if(oUsuariosCtaCteDet.Guardar(listaDet,out salidaDet) == false)
                    {
                        MessageBox.Show("Hubo un error al guardar los detalles del plan de pago: \n " + salidaDet, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void RecalcularMontosCtaCteDetParaCuotas()
        {
            decimal importeAux = 0;
            foreach (DataRow fila in dtCtaCteDetComprobantesAdeudados.Rows)
            {
                importeAux = 0;
                //importeAux = Convert.ToDecimal(fila["importe_original"]);
                importeAux = Convert.ToDecimal(fila["importe_saldo"]);

                fila["importe_original"] = importeAux - ((importeAux * porcentajeAnticipo) / 100);

                fila["importe_original"] = Convert.ToDecimal(fila["importe_original"].ToString())+(Convert.ToDecimal(fila["importe_original"].ToString()) * porcentajeRecargo / 100);
                fila["importe_original"] = Convert.ToDecimal(fila["importe_original"].ToString()) / spCantidadCuotas.Value;
                fila["importe_saldo"] = fila["importe_original"];
                fila["importe_punitorio"] = 0;
                fila["importe_bonificacion"] = 0;
                //fila["importe_pago"] = 0;
            }

        }

        private void RecalcularMontos()
        {
            try
            {
                spAnticipo.Maximum = montoTotalOriginal;
                valorAnticipo = spAnticipo.Value;
                porcentajeAnticipo = (valorAnticipo * 100) / montoTotalOriginal;
                montoTotalRestante = montoTotalOriginal - valorAnticipo;
                porcentajeRecargo = spRecargo.Value;
                montoRecargo = (montoTotalRestante * porcentajeRecargo) / 100;
                montoTotalRecargo = montoTotalRestante + Decimal.Round(montoRecargo, 2);
                lblMontoTotalOriginal.Text = String.Format("Monto total original: ${0}", montoTotalOriginal);
                lblMontoRestante.Text = String.Format("Monto restante: ${0}", montoTotalRestante);
                lblMontoRecargo.Text = String.Format("Monto final a pagar en cuotas: ${0}", montoTotalRecargo);
            }
            catch { MessageBox.Show("Error al calcular montos."); }
        }

        private void ConfigurarGrillaDatosComprobantes()
        {
            foreach (DataRow fila in dtDetallesRecibo.Rows)
            {
                if (dtDatosCtaCte.Select(String.Format("idUsuariosCtaCte={0}", fila["id_usuarios_ctacte"])).Length > 0)
                    dtComprobantesAdeudados.ImportRow(fila);
            }

            
            dtComprobantesAdeudados.Columns.Add("elegir", typeof(bool));

            foreach (DataRow fila in dtComprobantesAdeudados.Rows)
            {
                //switch (Convert.ToInt32(fila["encabezado"]))
                //{
                //    case 0:
                //        fila["encabezado"] = Convert.ToInt32(Usuarios_CtaCte.TIPO_REGISTRO_CTACTE.SUBSERVICIO);
                //        break;
                //    case 1:
                //        fila["encabezado"] = Convert.ToInt32(Usuarios_CtaCte.TIPO_REGISTRO_CTACTE.SERVICIO);
                //        break;
                //    case 2:
                //        fila["encabezado"] = Convert.ToInt32(Usuarios_CtaCte.TIPO_REGISTRO_CTACTE.COMPROBANTE);
                //        break;
                //}
                fila["elegir"] = fila["elige"];
            }

            if (dtComprobantesAdeudados.Columns.IndexOf("expande") != -1)
                dtComprobantesAdeudados.Columns.RemoveAt(dtComprobantesAdeudados.Columns.IndexOf("expande"));

            if (dtComprobantesAdeudados.Columns.IndexOf("elige") != -1)
                dtComprobantesAdeudados.Columns.RemoveAt(dtComprobantesAdeudados.Columns.IndexOf("elige"));
        }

        private void dgvComprobantesAdeudados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int tipoRegistro, idUsuariosCtaCte, idUsuariosServicios, idUsuariosCtaCteDet, indiceFila;
            string elegir = String.Empty;

            if (dgvComprobantesAdeudados.Columns[e.ColumnIndex].Name.Equals("elegir"))
            {
                tipoRegistro = Convert.ToInt32(dgvComprobantesAdeudados.SelectedRows[0].Cells["encabezado"].Value);
                if (dgvComprobantesAdeudados.SelectedRows[0].Cells["elegir"].Value.ToString() == "True")
                    elegir = "False";
                else
                    elegir = "True";

                idUsuariosCtaCte = Convert.ToInt32(dgvComprobantesAdeudados.SelectedRows[0].Cells["id_usuarios_ctacte"].Value);
                try
                {
                    idUsuariosServicios = Convert.ToInt32(dgvComprobantesAdeudados.SelectedRows[0].Cells["id_usuarios_servicios"].Value);
                }
                catch { idUsuariosServicios = 0; }

                try
                {
                    idUsuariosCtaCteDet = Convert.ToInt32(dgvComprobantesAdeudados.SelectedRows[0].Cells["id_usuarios_ctacte_det"].Value);
                }
                catch { idUsuariosCtaCteDet = 0; }

                indiceFila = dgvComprobantesAdeudados.SelectedRows[0].Index;

                if (tipoRegistro ==2)
                {
                    foreach (DataRow fila in dtComprobantesAdeudados.Rows)
                    {
                        if (Convert.ToInt32(fila["id_usuarios_ctacte"]) == idUsuariosCtaCte)
                            fila["elegir"] = elegir;
                    }
                }
                else if (tipoRegistro ==1)
                {
                    foreach (DataRow fila in dtComprobantesAdeudados.Rows)
                    {
                        if (Convert.ToInt32(fila["id_usuarios_ctacte"]) == idUsuariosCtaCte && Convert.ToInt32(fila["id_usuarios_servicios"]) == idUsuariosServicios)
                            fila["elegir"] = elegir;
                    }
                }
                else if (tipoRegistro ==0)
                    dtComprobantesAdeudados.Rows[indiceFila]["elegir"] = elegir;


                montoTotalOriginal = 0;
                foreach (DataRow fila in dtComprobantesAdeudados.Rows)
                {
                    if (fila["elegir"].ToString() == "True" && Convert.ToInt32(fila["encabezado"]) == 0)
                        montoTotalOriginal += Convert.ToDecimal(fila["importe_saldo"]);
                }

                if (montoTotalOriginal == 0)
                {
                    spAnticipo.Maximum = montoTotalOriginal;
                    valorAnticipo = 0;
                    porcentajeAnticipo = 0;
                    montoTotalRestante = 0;
                    porcentajeRecargo = 0;
                    montoRecargo = 0;
                    montoTotalRecargo = 0;
                    lblMontoTotalOriginal.Text = String.Format("Monto total original: ${0}", montoTotalOriginal);
                    lblMontoRestante.Text = String.Format("Monto restante: ${0}", montoTotalRestante);
                    lblMontoRecargo.Text = String.Format("Monto final a pagar en cuotas: ${0}", montoTotalRecargo);
                }
                else
                    RecalcularMontos();
                dtComprobantesAdeudados.AcceptChanges();
            }
        }

        public frmCtaCtePlanesDePago(int idUsuarios, int idUsuariosLocaciones, DataTable dtDatosCtaCte, DataTable dtDetallesRecibo)
        {
            this.idUsuarios = idUsuarios;
            this.idUsuariosLocaciones = idUsuariosLocaciones;
            this.dtDatosCtaCte = dtDatosCtaCte;
            this.dtDetallesRecibo = dtDetallesRecibo;
            InitializeComponent();
        }

        private void frmCtaCtePlanesDePago_Load(object sender, EventArgs e)
        {
            dtVistaPreviaCuotas.Columns.Add("numeroCuota",typeof(string));
            dtVistaPreviaCuotas.Columns.Add("importe", typeof(string));
            dtVistaPreviaCuotas.Columns.Add("fechaDesde", typeof(string));
            dtVistaPreviaCuotas.Columns.Add("fechaHasta", typeof(string));
            dtVistaPreviaCuotas.Columns.Add("primerVencimiento", typeof(string));
            dtVistaPreviaCuotas.Columns.Add("segundoVencimiento", typeof(string));
            dtVistaPreviaCuotas.Columns.Add("id_usuarios", typeof(string));
            dtVistaPreviaCuotas.Columns.Add("fechaComprobante", typeof(string));
            dtVistaPreviaCuotas.Columns.Add("id_usuarios_locaciones", typeof(string));

            dtDetalleFormaDePago.Columns.Add("Nombre", typeof(String));
            dtDetalleFormaDePago.Columns.Add("Importe", typeof(Decimal));
            dtDetalleFormaDePago.Columns.Add("Cliente", typeof(string));
            dtDetalleFormaDePago.Columns.Add("Cuenta", typeof(string));
            dtDetalleFormaDePago.Columns.Add("Cuit", typeof(string));
            dtDetalleFormaDePago.Columns.Add("Banco", typeof(string));
            dtDetalleFormaDePago.Columns.Add("Sucursal", typeof(string));
            dtDetalleFormaDePago.Columns.Add("Fecha_Comprobante", typeof(string));
            dtDetalleFormaDePago.Columns.Add("Fecha_Acreditacion", typeof(string));
            dtDetalleFormaDePago.Columns.Add("Numero", typeof(Int32));
            dtDetalleFormaDePago.Columns.Add("Id_formas_de_pago", typeof(Int32));
            dtDetalleFormaDePago.Columns.Add("Id_usuarios_locaciones", typeof(Int32));

            ComenzarCarga();
        }

        private void imgServicios_Unicos_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnVistaPrevia_Click(object sender, EventArgs e)
        {
            GenerarVistaPreviaPlanPago();
        }

        private void btnAsignarItem_Click(object sender, EventArgs e)
        {
            if (montoTotalOriginal > 0 && dtVistaPreviaCuotas.Rows.Count>0)
            {
                btnGenerarComprobantes.Enabled = false;
                generarPlanDePago = true;
                GuardarPlanPago();
                MessageBox.Show("Plan de pago generado correctamente.");
                this.DialogResult = DialogResult.OK;
                this.Close();

//                ComenzarCarga();
            }
            else if(montoTotalOriginal==0)
                MessageBox.Show("La deuda original tiene un valor de $0. Seleccione algún item de la grilla para continuar.","Mensaje del Sistema",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            else
            {
                MessageBox.Show("No ha generado cuotas.", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                spCantidadCuotas.Focus();
            }
        }

        private void spValor_ValueChanged(object sender, EventArgs e)
        {
            RecalcularMontos();
        }

        private void spRecargo_ValueChanged(object sender, EventArgs e)
        {
            RecalcularMontos();
        }

        private void frmCtaCtePlanesDePago_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
    }
}//27112019MAXI CAMPO ID_ORIGEN
