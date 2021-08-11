using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using System.Threading;
using CapaNegocios;

namespace CapaPresentacion.Cuenta_Corriente
{
    public partial class FrmDatosReciboTipoAjuste : Form
    {

        #region PROPIEDADES
        private delegate void myDel();
        public decimal Importe = 0, Importe_decidido = 0, Importe_Completo = 0, SaldoCtacte = 0;
        public string Comprobante;
        public List<int> id_Comprobantes = new List<int>();
        public DateTime desde, hasta, movimiento, fecha_decidida;
        public int id_Locacion = 0;
        private Usuarios_CtaCte oUsuCtacte = new Usuarios_CtaCte();
        private Usuarios_CtaCte_Det oUsuCtacte_det = new Usuarios_CtaCte_Det();
        private Usuarios_CtaCte_Recibos oUsuCtacte_Recibos = new Usuarios_CtaCte_Recibos();
        private Comprobantes_Tipo oComprobante_Tipo = new Comprobantes_Tipo();
        private Comprobantes oCompro = new Comprobantes();
        public int id_Ctacte, Comprobante_Tipo, id_usu , id_locacion, idComprobante;
        #endregion


        public FrmDatosReciboTipoAjuste()
        {
            InitializeComponent();
        }



        #region METODOS
        #endregion

        #region EVENTOS

        private void rbFechaActual_CheckedChanged(object sender, EventArgs e)
        {
            dtpFechaAjuste.Value = DateTime.Now;
        }

        private void rbFechaComprobante_CheckedChanged(object sender, EventArgs e)
        {
            dtpFechaAjuste.Value = Convert.ToDateTime(lblMovimiento.Text);
        }

        private void rbImporteFactura_CheckedChanged(object sender, EventArgs e)
        {
            txtImporteAjuste.Text = Importe.ToString();
        }

        private void rbAjusteSaldoCompleto_CheckedChanged(object sender, EventArgs e)
        {
            txtImporteAjuste.Text = Importe_Completo.ToString();
        }


        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void FrmDatosReciboTipoAjuste_Load(object sender, EventArgs e)
        {
            lblComprobante.Text = Comprobante.ToString();
            lblDesde.Text = desde.ToString();
            lblHasta.Text = hasta.ToString();
            lblImporte.Text = Importe.ToString();
            lblMovimiento.Text = movimiento.ToString();
            if(rbAjusteSaldoCompleto.Checked == true)
                txtImporteAjuste.Text = Importe_Completo.ToString();
            else
                txtImporteAjuste.Text = Importe.ToString();
            dtpFechaAjuste.Value = DateTime.Now;
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            decimal Saldo_Total_Ctacte = 0;
            Usuarios_Locaciones oUsuLoc = new Usuarios_Locaciones();
            if (txtImporteAjuste.Text == "") 
            { 
                MessageBox.Show("Debe seleccionar un importe minimo.");
                txtImporteAjuste.Text = Importe.ToString();
            }
            else 
            { 
                Importe_decidido = Convert.ToDecimal(txtImporteAjuste.Text);
                fecha_decidida = Convert.ToDateTime(dtpFechaAjuste.Value);
                Saldo_Total_Ctacte = SaldoCtacte - Importe_decidido;
                if (rbAjusteSaldoCompleto.Checked == true) 
                {
                    if(id_Comprobantes.Count > 0) 
                    { 
                        foreach (int id_Comp in id_Comprobantes)
                        { 
                            DataRow dr = oUsuCtacte.getDatosCtaCte(id_Comp);                      
                            if(Convert.ToInt32(dr["id"]) > 0) 
                            {
                                //Actualizamos el importe_saldo y el importe_pago de ese Ctacte en caso de haber facturas sin Recibos.
                                oUsuCtacte.ActualizarCtaCte_FacturaSinRecibo(Convert.ToInt32(dr["id"]));
                                //Actualizaremos los ctacte_det del importe_saldo y el importe_pago en caso de haber facturas sin Recibos.
                                oUsuCtacte_det.ActualizarCtaCteDet_FacturasSinRecibo(Convert.ToInt32(dr["id"]));
                            }
                        }
                    }
                    else 
                    {
                        //Actualizamos el importe_saldo y el importe_pago de ese Ctacte en caso de haber facturas sin Recibos.
                        oUsuCtacte.ActualizarCtaCte_FacturaSinRecibo(id_Ctacte);
                        //Actualizaremos los ctacte_det del importe_saldo y el importe_pago en caso de haber facturas sin Recibos.
                        oUsuCtacte_det.ActualizarCtaCteDet_FacturasSinRecibo(id_Ctacte);
                    }
                }
                else
                {
                    //Actualizamos el importe_saldo y el importe_pago de ese Ctacte.
                    oUsuCtacte.ActualizarCtaCte_FacturaSinRecibo(id_Ctacte);
                    //Actualizaremos los ctacte_det del importe_saldo y el importe_pago 
                    oUsuCtacte_det.ActualizarCtaCteDet_FacturasSinRecibo(id_Ctacte);
                }
                oUsuLoc.ActualizarSaldoCtacte(Saldo_Total_Ctacte, id_locacion);
                int Id_Recibo = (int)Comprobantes_Tipo.Tipo.RECIBO_AJUSTE;
                string NumeroString;
                Int32 NroRecibo, PtoRecibo;
                DataRow drComprobante;
                drComprobante = oComprobante_Tipo.GetNumeracion(Id_Recibo, Puntos_Cobros.Id_Punto);
                NroRecibo = Convert.ToInt32(drComprobante["numComprobante"]);
                PtoRecibo = Convert.ToInt32(drComprobante["numPuntoVenta"]);
                NumeroString = PtoRecibo.ToString().PadLeft(4, '0') + "-" + NroRecibo.ToString().PadLeft(8, '0');
                oComprobante_Tipo.SetNumeracion(Convert.ToInt32(drComprobante["idPuntoVenta"]), Id_Recibo, NroRecibo);

                //Creamos un comprobante 
                oCompro.Descripcion = NumeroString;
                oCompro.Id_Comprobantes_Tipo = (int)Comprobantes_Tipo.Tipo.RECIBO_AJUSTE;
                oCompro.Fecha = DateTime.Now;
                oCompro.Id_Personal = Personal.Id_Login;
                oCompro.Id_Punto_Cobro = 0;
                oCompro.Id_Punto_Venta = 0;
                oCompro.Id_Usuarios = Convert.ToInt32(id_usu.ToString());
                oCompro.Id_Usuarios_Locaciones = Convert.ToInt32(id_locacion.ToString());
                oCompro.Importe = Convert.ToDecimal(Importe.ToString());
                oCompro.Numero = NroRecibo;
                oCompro.Id = oCompro.Guardar(oCompro);

                //Creamos un recibo de tipo Ajuste para equilibrar el saldo de la Cuenta Corriente del usuario.
                oUsuCtacte_Recibos.Descripcion = "";
                oUsuCtacte_Recibos.Id_Usuarios = Convert.ToInt32(id_usu.ToString());
                oUsuCtacte_Recibos.Id_Usuarios_Locacion = Convert.ToInt32(id_locacion.ToString());
                oUsuCtacte_Recibos.Id_Comprobantes = oCompro.Id;
                oUsuCtacte_Recibos.Numero_Muestra = "Recibo de AJUSTE Nro " + NumeroString;
                oUsuCtacte_Recibos.Numero = NroRecibo;
                oUsuCtacte_Recibos.Fecha_Movimiento = fecha_decidida;
                oUsuCtacte_Recibos.Importe_Final = Importe_decidido;

                int id_Ctacte_Recibo = oUsuCtacte_Recibos.Guarda_Recibos(oUsuCtacte_Recibos);

                if(rbAjusteSaldoCompleto.Checked == true) 
                {
                    if (id_Comprobantes.Count > 0)
                    {
                        foreach (int id_Comp in id_Comprobantes)
                        {
                            DataRow dr = oUsuCtacte.getDatosCtaCte(id_Comp);
                            if (id_Ctacte_Recibo > 0 && Convert.ToInt32(dr["id"]) > 0)
                            {
                                DataTable dtCtacte_det = new DataTable();
                                dtCtacte_det = oUsuCtacte_det.ListarDetalleDeCtaCte(Convert.ToInt32(dr["id"]));
                                List<Usuarios_CtaCte_Det> ListaDet = new List<Usuarios_CtaCte_Det>();
                                foreach (DataRow drDet in dtCtacte_det.Rows)
                                {
                                    oUsuCtacte_det = new Usuarios_CtaCte_Det();
                                    oUsuCtacte_det.Id = Convert.ToInt32(drDet["id"]);
                                    oUsuCtacte_det.Id_Usuarios_CtaCte = Convert.ToInt32(dr["id"]);
                                    oUsuCtacte_det.Id_Usuarios_Locaciones = Convert.ToInt32(drDet["id_usuarios_locaciones"]);
                                    if (Convert.ToInt32(drDet["id_usuarios_servicios_sub"]) != 0)
                                        oUsuCtacte_det.Id_Zonas = Convert.ToInt32(drDet["id_tipo_facturacion"]);
                                    else
                                        oUsuCtacte_det.Id_Zonas = 0;
                                    oUsuCtacte_det.Id_Servicios = Convert.ToInt32(drDet["id_servicios"]);
                                    oUsuCtacte_det.Id_Tipo = Convert.ToInt32(drDet["id_tipo"]);
                                    oUsuCtacte_det.Tipo = drDet["tipo"].ToString();
                                    oUsuCtacte_det.Importe_Original = Convert.ToDecimal(drDet["importe_original"]);
                                    oUsuCtacte_det.Importe_Saldo = oUsuCtacte_det.Importe_Original;
                                    oUsuCtacte_det.Importe_Final = oUsuCtacte_det.Importe_Original;
                                    oUsuCtacte_det.Importe_Punitorio = 0;
                                    oUsuCtacte_det.Importe_Bonificacion = 0;
                                    oUsuCtacte_det.Id_Usuarios_Servicios = Convert.ToInt32(drDet["id_usuarios_servicios"]);
                                    oUsuCtacte_det.Id_Velocidades_Tip = Convert.ToInt32(drDet["id_velocidades_tip"]);
                                    oUsuCtacte_det.Id_Velocidades = Convert.ToInt32(drDet["id_velocidades"]);
                                    oUsuCtacte_det.Requiere_IP = Convert.ToInt32(drDet["requiere_ip"]);
                                    oUsuCtacte_det.Cantidad_Periodos = Convert.ToInt32(drDet["cantidad_periodos"]);
                                    oUsuCtacte_det.Id_Usuarios_Servicios_sub = Convert.ToInt32(drDet["id_usuarios_servicios_sub"]);
                                    oUsuCtacte_det.Fecha_Desde = desde;
                                    oUsuCtacte_det.Fecha_Hasta = hasta;
                                    oUsuCtacte_det.Id_bonificacion_Aplicada = 0;
                                    oUsuCtacte_det.Nombre_Bonificacion = "";
                                    oUsuCtacte_det.Porcentaje_Bonificacion = 0;
                                    oUsuCtacte_det.Periodo_Mes = Convert.ToInt32(drDet["periodo_mes"]);
                                    oUsuCtacte_det.Periodo_Ano = Convert.ToInt32(drDet["periodo_ano"]);
                                    oUsuCtacte_det.Detalles = "Recibo de AJUSTE Nro " + NumeroString;
                                    object tipoFac = drDet["id_tipo_facturacion"];
                                    if (tipoFac == DBNull.Value)
                                        oUsuCtacte_det.Id_Tipo_Facturacion = 0;
                                    else
                                        oUsuCtacte_det.Id_Tipo_Facturacion = Convert.ToInt32(drDet["id_tipo_facturacion"]);

                                    ListaDet.Add(oUsuCtacte_det);
                                }
                                if (oUsuCtacte_Recibos.GuardarRelacionReciboAjuste(id_Ctacte_Recibo, Convert.ToInt32(dr["id"]), ListaDet, 33, out string Salida))
                                {
                                    if (oUsuCtacte_Recibos.GuardarRelacionReciboServicioReciboAjuste(id_Ctacte_Recibo, ListaDet))
                                        this.DialogResult = DialogResult.OK;
                                }
                            }
                        }
                    }
                    else
                    {
                        DataTable dtCtacte_det = new DataTable();
                        dtCtacte_det = oUsuCtacte_det.ListarDetalleDeCtaCte(id_Ctacte);
                        List<Usuarios_CtaCte_Det> ListaDet = new List<Usuarios_CtaCte_Det>();
                        foreach (DataRow drDet in dtCtacte_det.Rows)
                        {
                            oUsuCtacte_det = new Usuarios_CtaCte_Det();
                            oUsuCtacte_det.Id = Convert.ToInt32(drDet["id"]);
                            oUsuCtacte_det.Id_Usuarios_CtaCte = Convert.ToInt32(id_Ctacte);
                            oUsuCtacte_det.Id_Usuarios_Locaciones = Convert.ToInt32(drDet["id_usuarios_locaciones"]);
                            if (Convert.ToInt32(drDet["id_usuarios_servicios_sub"]) != 0)
                                oUsuCtacte_det.Id_Zonas = Convert.ToInt32(drDet["id_tipo_facturacion"]);
                            else
                                oUsuCtacte_det.Id_Zonas = 0;
                            oUsuCtacte_det.Id_Servicios = Convert.ToInt32(drDet["id_servicios"]);
                            oUsuCtacte_det.Id_Tipo = Convert.ToInt32(drDet["id_tipo"]);
                            oUsuCtacte_det.Tipo = drDet["tipo"].ToString();
                            oUsuCtacte_det.Importe_Original = Convert.ToDecimal(drDet["importe_original"]);
                            oUsuCtacte_det.Importe_Saldo = oUsuCtacte_det.Importe_Original;
                            oUsuCtacte_det.Importe_Final = oUsuCtacte_det.Importe_Original;
                            oUsuCtacte_det.Importe_Punitorio = 0;
                            oUsuCtacte_det.Importe_Bonificacion = 0;
                            oUsuCtacte_det.Id_Usuarios_Servicios = Convert.ToInt32(drDet["id_usuarios_servicios"]);
                            oUsuCtacte_det.Id_Velocidades_Tip = Convert.ToInt32(drDet["id_velocidades_tip"]);
                            oUsuCtacte_det.Id_Velocidades = Convert.ToInt32(drDet["id_velocidades"]);
                            oUsuCtacte_det.Requiere_IP = Convert.ToInt32(drDet["requiere_ip"]);
                            oUsuCtacte_det.Cantidad_Periodos = Convert.ToInt32(drDet["cantidad_periodos"]);
                            oUsuCtacte_det.Id_Usuarios_Servicios_sub = Convert.ToInt32(drDet["id_usuarios_servicios_sub"]);
                            oUsuCtacte_det.Fecha_Desde = desde;
                            oUsuCtacte_det.Fecha_Hasta = hasta;
                            oUsuCtacte_det.Id_bonificacion_Aplicada = 0;
                            oUsuCtacte_det.Nombre_Bonificacion = "";
                            oUsuCtacte_det.Porcentaje_Bonificacion = 0;
                            oUsuCtacte_det.Periodo_Mes = Convert.ToInt32(drDet["periodo_mes"]);
                            oUsuCtacte_det.Periodo_Ano = Convert.ToInt32(drDet["periodo_ano"]);
                            oUsuCtacte_det.Detalles = "Recibo de AJUSTE Nro " + NumeroString;
                            object tipoFac = drDet["id_tipo_facturacion"];
                            if (tipoFac == DBNull.Value)
                                oUsuCtacte_det.Id_Tipo_Facturacion = 0;
                            else
                                oUsuCtacte_det.Id_Tipo_Facturacion = Convert.ToInt32(drDet["id_tipo_facturacion"]);

                            ListaDet.Add(oUsuCtacte_det);
                        }
                        if (oUsuCtacte_Recibos.GuardarRelacionReciboAjuste(id_Ctacte_Recibo, id_Ctacte, ListaDet, 33, out string Salida))
                        {
                            if (oUsuCtacte_Recibos.GuardarRelacionReciboServicioReciboAjuste(id_Ctacte_Recibo, ListaDet))
                                this.DialogResult = DialogResult.OK;
                        }
                    }
                }              
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
        #endregion
    }
}
