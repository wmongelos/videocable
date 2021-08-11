using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CapaNegocios;
using FEAFIPLib;
using System.Collections;
using System.Globalization;

namespace CapaPresentacion.Afip
{
    public partial class frmafipservicios : Form
    {
        private Int32 ErrorNro;
        private String ErrorDescripcion;
        private Int32 idComprobante;
        public DataTable dt_Facturas_iva;
        private DataTable dt_prueba = new DataTable();
        private Double Numero = 0;
        private Impresiones.Impresion oImpresion = new Impresiones.Impresion();
        private afip oAfip = new afip();
        private wsfev1 oAfipLIbreria = new wsfev1();
        private wsPadron oAfipPadron = new wsPadron();
        private Contribuyente oAfipContribuyente = new Contribuyente();
        Configuracion oConfiguracion = new Configuracion();
        private Comprobantes_Tipo OcomprobantesTipo = new Comprobantes_Tipo();
        private Comprobante oComprobanteAfip = new Comprobante(); // Objeto de la DLL DE AFIP
        private Puntos_Venta oPuntosdeventa = new Puntos_Venta();
        private Climpuestos oImpuestos = new Climpuestos();
        private Iva_Alicuotas oIva_Alicuotas = new Iva_Alicuotas();

        private Usuarios oUsuario = new Usuarios();
        private DataTable dtComprobantesTipos = new DataTable();
        private DataTable dtPuntos = new DataTable();
        private Comprobantes oComprobantes = new Comprobantes();
        private DataTable dtIvaVentas = new DataTable();
        private Facturacion oFacturacion = new Facturacion();


        private frmafipListaDeComprobantes oFrmafiplistadecomprobantes;
        private frmafipDatosDelContribuyente oFrmafipdatosdelcontribuyente;

        private frmPopUp oPop;

        public frmafipservicios()
        {
            InitializeComponent();
        }

        private void frmafipservicios_Load(object sender, EventArgs e)
        {
            this.CargarDatos();
        }

        private void CargarDatos()
        {
            dtComprobantesTipos = OcomprobantesTipo.Listar_Comprobantes_Afip();
            dtPuntos = oPuntosdeventa.Listar();
            this.AsignarDatos();
        }

        private void AsignarDatos()
        {
            idComprobante = 0; 
            spNumero.Value = 1;
            spPuntodeVenta.Value = Convert.ToInt32(dtPuntos.Rows[0]["numero"].ToString());
            ErrorNro = 0;
            ErrorDescripcion = "";
            oAfipPadron.CUIT = Convert.ToDouble(oConfiguracion.GetValor_C("Cuit"));
            oAfipPadron.ModoProduccion = true;
            if(dt_Facturas_iva != null)
            {
                cboComprobantes.DataSource = dt_Facturas_iva;
                cboComprobantes.DisplayMember = "Factura";
                cboComprobantes.ValueMember = "codigo_afip";
                spPuntodeVenta.Value = Convert.ToInt32(dt_Facturas_iva.Rows[0]["Punto_Venta"]);
                spNumero.Value = Convert.ToInt32(dt_Facturas_iva.Rows[0]["Numero_COMPROBANTE"]);
                LeerComprobante();
            }
            else
            { 
                cboComprobantes.DataSource = dtComprobantesTipos;
                cboComprobantes.DisplayMember = "nombre";
                cboComprobantes.ValueMember = "codigo_afip";
            }

            String ServicioWeb;
            String ServicioAut;
            String ServicioDb;

            oAfip.ComprobarServicio(out ServicioWeb, out ServicioAut, out ServicioDb);

            if (ServicioWeb == "OK")
                lbservicioweb.ForeColor = Color.Green;
            else
                lbservicioweb.ForeColor = Color.Red;

            if (ServicioAut == "OK")
                lbservicioaut.ForeColor = Color.Green;
            else
                lbservicioaut.ForeColor = Color.Red;

            if (ServicioDb == "OK")
                lbserviciodb.ForeColor = Color.Green;
            else
                lbserviciodb.ForeColor = Color.Red;

        }

        private void btnConsultaComprobante_Click(object sender, EventArgs e)
        {

            LeerComprobante();

        }

        private void LLenarDatosComprobante()
        {
            lbcae.Text = oComprobanteAfip.CodAutorizacion;
            lbclientecuit.Text = oComprobanteAfip.DocNro.ToString();

            lbfecha.Text = oComprobanteAfip.CbteFch.Substring(0,4)+"-"+ oComprobanteAfip.CbteFch.Substring(4, 2)+"-"+ oComprobanteAfip.CbteFch.Substring(6, 2);
            lbdesde.Text = oComprobanteAfip.FchServDesde;
            lbhasta.Text = oComprobanteAfip.FchServHasta;

            lbneto.Text= "$ "+oComprobanteAfip.ImpNeto.ToString();
            lbiva.Text = "$ " + oComprobanteAfip.ImpIVA.ToString();
            lbImpuestos.Text = "$ " + oComprobanteAfip.ImpTrib.ToString();
            lbfinal.Text = "$ " + oComprobanteAfip.Imptotal.ToString();
            LeerContribuyente();
            LeerIvaVentasGies();

        }

        private void cboComprobantes_SelectedIndexChanged(object sender, EventArgs e)
        {

         
        }

        private void LeerComprobante()
        {
            ErrorNro = 0;
            ErrorDescripcion = "";


            if (spNumero.Value == 0)
            {
                spNumero.Focus();
                return;
            }

            if (spPuntodeVenta.Value == 0)
            {
                spPuntodeVenta.Focus();
                return;
            }

            oAfip.Conectar(out ErrorNro, out ErrorDescripcion);
            if (ErrorNro > 0)
            {
                MessageBox.Show(ErrorDescripcion);
                return;
            }

            oComprobanteAfip = oAfip.ObtenerComprobante(Convert.ToInt32(spPuntodeVenta.Value.ToString()), Convert.ToInt32(cboComprobantes.SelectedValue.ToString()), Convert.ToInt32(spNumero.Value.ToString()), out ErrorNro, out ErrorDescripcion);

            if (ErrorNro == 0)
            {

                this.LLenarDatosComprobante();
            }
            else
            {
                MessageBox.Show(ErrorDescripcion);
                return;
            }
        }

        private void ProximoNumero()
        {
            ErrorNro = 0;
            ErrorDescripcion = "";


            oAfip.Conectar(out ErrorNro, out ErrorDescripcion);
            if (ErrorNro > 0)
            {
                MessageBox.Show(ErrorDescripcion);
                return;
            }

           Numero=oAfip.GetUltimoComprobante(Convert.ToInt32(spPuntodeVenta.Value.ToString()), Convert.ToInt32(cboComprobantes.SelectedValue.ToString()), out ErrorNro, out ErrorDescripcion);


            if (ErrorNro == 0)
            {

                spNumero.Value = Convert.ToInt32( Numero.ToString());
                LeerComprobante();
            }
            else
            {
                MessageBox.Show(ErrorDescripcion);
                return;
            }

        }

        private void LeerIvaVentasGies()
        {

            oImpuestos.Cae = lbcae.Text.Trim();
            
            dtIvaVentas = oImpuestos.ListarIvaVentas(Convert.ToInt32(Climpuestos.Campo_Busqueda.cae));
            if (dtIvaVentas.Rows.Count > 0)
            {   
                idComprobante = Convert.ToInt32( dtIvaVentas.Rows[0]["id_comprobantes"].ToString().ToString());
                lbnetogies.Text = "$ " + dtIvaVentas.Rows[0]["importe_neto"].ToString();
                lbivagies.Text = "$ " + dtIvaVentas.Rows[0]["importe_iva"].ToString();
                lbimpuestosgies.Text = "$ " + dtIvaVentas.Rows[0]["importe_impuesto_provincial"].ToString();
                lbfinalgies .Text = "$ " + dtIvaVentas.Rows[0]["importe_final"].ToString();
                lbcodigo.Text = dtIvaVentas.Rows[0]["codigo"].ToString();
                lbapellidousu.Text= dtIvaVentas.Rows[0]["apellido"].ToString();
                lbnombreusu.Text = dtIvaVentas.Rows[0]["nombre"].ToString();
            }
            else
            {
                lbnetogies.Text ="";
                lbivagies.Text = "";
                lbimpuestosgies.Text = "";
                lbfinalgies.Text = "";
                lbcodigo.Text = "";

            }
        }
        private void LeerContribuyente()
        {
            ErrorNro = 0;
            ErrorDescripcion = "";
            oAfipContribuyente =oAfip.ObtenerContribuyente(Convert.ToDouble(lbclientecuit.Text),out ErrorNro, out ErrorDescripcion);

            lbApellido.Text = oAfipContribuyente.apellido;
            lbNombre.Text = oAfipContribuyente.nombre;
            lbestado.Text = oAfipContribuyente.estadoClave;
            lbtipopersona.Text = oAfipContribuyente.tipoPersona;
            lbDireccion.Text=oAfipContribuyente.domicilioFiscal.direccion;
            lbLocalidad.Text = oAfipContribuyente.domicilioFiscal.localidad;
            lblNumero.Text = Numero.ToString();
    
        }

        private void btnUltimocomprobante_Click(object sender, EventArgs e)
        {
            ProximoNumero();
        }

        private void boton1_Click(object sender, EventArgs e)
        {
        
        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Sobreeescribe()
        {
            int id_comprobante = 0;
            Int32 idIva = 0, id_Iva_Ventas = 0;
            double Dni = 0;
            Dni = oComprobanteAfip.DocNro;
            DataTable dt_Punto_venta = new DataTable();
            DataTable dt_Datos_Usuario = new DataTable();
            DataTable dt_Comprobante_Tipo_Filtrado = new DataTable();
            DataTable dt_iva_ventas = new DataTable();
            dt_Punto_venta = oAfip.Get_Punto_Venta(Convert.ToInt32(spPuntodeVenta.Value));
            dt_Datos_Usuario = oUsuario.Buscar_datos_usuario(Convert.ToDouble(Dni));
            dt_Comprobante_Tipo_Filtrado = OcomprobantesTipo.Listar_Comprobante_Afip_filtrado(Convert.ToInt32(cboComprobantes.SelectedValue.ToString()));
            if (dtIvaVentas.Rows.Count > 1)
            {
                idIva = Convert.ToInt32(dtIvaVentas.Rows[0]["id"].ToString().ToString());
                oAfip.SobreescribeImporteLIbro(idIva, Convert.ToDecimal(oComprobanteAfip.ImpNeto.ToString()), Convert.ToDecimal(oComprobanteAfip.ImpIVA.ToString()), Convert.ToDecimal(oComprobanteAfip.ImpTrib.ToString()), Convert.ToDecimal(oComprobanteAfip.Imptotal.ToString()));
            }
            else
            {
                oComprobantes.Numero = Convert.ToInt32(Numero);
                oComprobantes.Punto_Venta = oComprobanteAfip.PtoVta;
                oComprobantes.Importe = Convert.ToDecimal(oComprobanteAfip.Imptotal);
                oComprobantes.Id_Comprobantes_Tipo = Convert.ToInt32(dt_Comprobante_Tipo_Filtrado.Rows[0]["id"]);
                oComprobantes.Fecha = DateTime.ParseExact(oComprobanteAfip.CbteFch, "yyyyMMdd", CultureInfo.InvariantCulture);
                oComprobantes.Id_Punto_Cobro = Puntos_Cobros.Id_Punto;
                oComprobantes.Id_Punto_Venta = Convert.ToInt32(dt_Punto_venta.Rows[0]["id"]);
                oComprobantes.Id_Personal = Personal.Id_Login;
                oComprobantes.Id_Usuarios = Convert.ToInt32(dt_Datos_Usuario.Rows[0]["id_usuario"]);
                oComprobantes.Id_Usuarios_Locaciones = Convert.ToInt32(dt_Datos_Usuario.Rows[0]["id_usuario_locacion"]);
                id_comprobante = oComprobantes.Guardar(oComprobantes);

                oFacturacion.Id_Usuarios = Convert.ToInt32(dt_Datos_Usuario.Rows[0]["id_usuario"]);
                oFacturacion.Id_Usuarios_locacion = Convert.ToInt32(dt_Datos_Usuario.Rows[0]["id_usuario_locacion"]);
                oFacturacion.Id_Comprobantes = id_comprobante;
                oFacturacion.Id_Comprobantes_tipo = Convert.ToInt32(dt_Comprobante_Tipo_Filtrado.Rows[0]["id"]);
                oFacturacion.Letra = Convert.ToString(dt_Comprobante_Tipo_Filtrado.Rows[0]["Letra"]);
                oFacturacion.Id_Comprobantes_iva = Convert.ToInt32(dt_Datos_Usuario.Rows[0]["id_comprobantes_iva"]);
                oFacturacion.Fecha = DateTime.ParseExact(oComprobanteAfip.CbteFch, "yyyyMMdd", CultureInfo.InvariantCulture);
                oFacturacion.Punto_Venta = oComprobanteAfip.PtoVta;
                oFacturacion.Numero = Convert.ToInt32(Numero);
                oFacturacion.Cae = oComprobanteAfip.CodAutorizacion;
                oFacturacion.Cae_vencimiento = DateTime.ParseExact(oComprobanteAfip.FchVto, "yyyyMMdd", CultureInfo.InvariantCulture);
                oFacturacion.Id_Comprobantes_iva = Convert.ToInt32(dt_Datos_Usuario.Rows[0]["id_comprobantes_iva"]);
                oFacturacion.Id_Comprobantes_tipo= Convert.ToInt32(dt_Comprobante_Tipo_Filtrado.Rows[0]["id"]);
                oFacturacion.Calle = Convert.ToString(dt_Datos_Usuario.Rows[0]["Calle"]);
                oFacturacion.Altura = Convert.ToInt32(dt_Datos_Usuario.Rows[0]["Altura"]);
                oFacturacion.Localidad = Convert.ToString(dt_Datos_Usuario.Rows[0]["Localidad"]);
                oFacturacion.Cod_postal = Convert.ToString(dt_Datos_Usuario.Rows[0]["Codigo_Postal"]);
                oFacturacion.Provincia = Convert.ToString(dt_Datos_Usuario.Rows[0]["Provincia"]);
                oFacturacion.Numero_Doc = Convert.ToDouble(dt_Datos_Usuario.Rows[0]["Numero_Documento"]);
                oFacturacion.Importe_Neto = Convert.ToDecimal(oComprobanteAfip.ImpNeto);
                oFacturacion.Importe_Iva = Convert.ToDecimal(oComprobanteAfip.ImpIVA);
                oFacturacion.Importe_Impuesto_Interno = 0;
                oFacturacion.Importe_Impuesto_Nacional = 0;
                oFacturacion.Importe_Impuesto_Municipal = 0;
                oFacturacion.Importe_Impuesto_Otros = 0;
                oFacturacion.Importe_Impuesto_Provincial = Convert.ToDecimal(oComprobanteAfip.ImpTrib);
                oFacturacion.Importe_Final = Convert.ToDecimal(oComprobanteAfip.Imptotal);
                oFacturacion.Razon_Social = oAfipContribuyente.nombre;
                oFacturacion.Fantasia = oAfipContribuyente.nombre;
                oFacturacion.Id_Iva_Ventas = oFacturacion.GuardarIvaVentas(oFacturacion);
                oFacturacion.Guarda_Iva_Alicuotas_Afip(oFacturacion);
               
            }
        }

        private void lblTituloHeader_Click(object sender, EventArgs e)
        {
            oFrmafiplistadecomprobantes = new frmafipListaDeComprobantes();
            oPop = new frmPopUp();


            oPop.Formulario = oFrmafiplistadecomprobantes;
            oPop.Maximizar = false;
            if (oPop.ShowDialog() == DialogResult.OK)
            {
                //                comenzarCarga();
            }
        }

        private void lbservicioweb_Click(object sender, EventArgs e)
        {

            oFrmafipdatosdelcontribuyente = new frmafipDatosDelContribuyente();
            oPop = new frmPopUp();
            oPop.Formulario = oFrmafipdatosdelcontribuyente;
            oPop.Maximizar = false;
            if (oPop.ShowDialog() == DialogResult.OK)
            {
                //                comenzarCarga();
            }
        }

        private void cmdGraba_Click(object sender, EventArgs e)
        {
            this.Sobreeescribe();
        }

        private void btnReimprimir_Click(object sender, EventArgs e)
        {
            if (dt_Facturas_iva.Rows.Count > 0 || dtIvaVentas.Rows.Count > 0)
            {
                    try
                    {
                        if (dt_Facturas_iva != null)
                            oImpresion.Imprime_factura_RDLC(false, Convert.ToInt32(dt_Facturas_iva.Rows[0]["id_comprobante"]));
                        else if (dtIvaVentas != null)
                            oImpresion.Imprime_factura_RDLC(false, idComprobante);
                        else
                            MessageBox.Show("Debe seleccionar una factura.");
                    }
                    catch(Exception ex)
                    {
                    MessageBox.Show("Hubo un error , " + ex);
                    }
            }
        }

        private void cmdFacturas_Click(object sender, EventArgs e)
        {
            oFrmafiplistadecomprobantes = new frmafipListaDeComprobantes();
            oPop = new frmPopUp();


            oPop.Formulario = oFrmafiplistadecomprobantes;
            oPop.Maximizar = true;
            if (oPop.ShowDialog() == DialogResult.OK)
            {
                //                comenzarCarga();
            }
        }
    }
}
