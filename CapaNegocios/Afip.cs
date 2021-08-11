using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaDatos;
using System.Data;
using FEAFIPLib;


namespace CapaNegocios
{

    public class afip
    {
        public Int32 Punto_Venta;
        public Int32 Tipo_Comprobante;
        public DateTime Fecha_Comprobante;
        public wsfev1 lwsfev1 = new wsfev1();
        public Contribuyente oContribuyenteObjeto = new Contribuyente();
        public wsPadron OpadronAfip = new wsPadron();

        private Facturacion Ofacturacion = new Facturacion();
        private Conexion oCon = new Conexion();

        private Configuracion oConfig = new Configuracion();
        int trabajaHomologacion = 0;

        public enum comprobantes_tipo
        {
            FACTURA_A = 1,
            NOTA_DEBITO_A = 2,
            NOTA_CREDITO_A = 3,
            FACTURA_B = 6,
            NOTA_DEBITO_B = 7,
            NOTA_CREDIT_B = 8
        }

        public enum documentos_tipo
        {
            DNI = 96,
            CUIT = 80
        }
        public Int32 SobreescribeImporteLIbro (Int32 IdIva,Decimal mNeto,Decimal mIva,Decimal mImpuesto,Decimal mFinal)
        {
            Int32 OK = 0;
            try
            {
                oCon.Conectar();

                    oCon.CrearComando("UPDATE iva_ventas SET importe_neto=@Neto,Importe_Iva=@Iva,importe_impuesto_provincial=@Percepcion," + 
                        "Importe_final =@Final WHERE Id = @id");

                oCon.AsignarParametroEntero("@id", IdIva);
                oCon.AsignarParametroDecimal("@Neto", mNeto);
                oCon.AsignarParametroDecimal("@Iva", mIva);
                oCon.AsignarParametroDecimal("@Percepcion", mImpuesto);
                oCon.AsignarParametroDecimal("@Final", mFinal);

                oCon.ComenzarTransaccion();
                oCon.EjecutarComando();
                oCon.ConfirmarTransaccion();

                oCon.CrearComando("UPDATE iva_alicuotas_detalles SET importe_neto=@Neto,Importe_Iva=@Iva WHERE Id_iva_ventas = @id");

                oCon.AsignarParametroEntero("@id", IdIva);
                oCon.AsignarParametroDecimal("@Neto", mNeto);
                oCon.AsignarParametroDecimal("@Iva", mIva);

                oCon.ComenzarTransaccion();
                oCon.EjecutarComando();
                oCon.ConfirmarTransaccion();

                oCon.DesConectar();

            }
            catch (Exception)
            {
                oCon.CancelarTransaccion();
                oCon.DesConectar();
                OK = 1;
                throw;
            }
            return OK;
        }



        public DataTable Get_Punto_Venta(int Punto)
        {
            DataTable dt = new DataTable();

            try
            {
                oCon.Conectar();
                oCon.CrearComando("SELECT *  " +
                    "FROM puntos_venta " +
                    "where puntos_venta.Numero = @Punto_Venta and borrado=0; ");
                oCon.AsignarParametroEntero("@Punto_Venta", Punto);
                dt = oCon.Tabla();
                oCon.DesConectar();
            }
            catch (Exception)
            {
                oCon.DesConectar();
                throw;
            }
            return dt;

        }



        public void ComprobarServicio(out String ServicioWeb, out String ServicioAut, out String ServicioDb)
        {
            lwsfev1.Dummy(out ServicioWeb, out ServicioAut, out ServicioDb);
        }

        public wsfev1 Conectar(out Int32 ResultadoNro, out String ResultadoString)
        {
            ResultadoString = "";
            ResultadoNro = 0;

            string URLWSAA = "";
            //Producción: https://wsaa.afip.gov.ar/ws/services/LoginCms
            string URLWSW = "";
            //Producción: https://servicios1.afip.gov.ar/wsfev1/service.asmx
            string FechaComp = Fecha_Comprobante.ToString("yyyyMMdd");

            if (trabajaHomologacion == 1)
            {
                URLWSAA = "https://wsaahomo.afip.gov.ar/ws/services/LoginCms";
                URLWSW = "https://wswhomo.afip.gov.ar/wsfev1/service.asmx";
                lwsfev1.CUIT = 20939802593; // Cuit del vendedor
                Punto_Venta = 198;
            }
            else
            {
                URLWSAA = "https://wsaa.afip.gov.ar/ws/services/LoginCms";
                URLWSW = "https://servicios1.afip.gov.ar/wsfev1/service.asmx";
                lwsfev1.CUIT = Convert.ToDouble(oConfig.GetValor_C("Cuit"));
            }

            lwsfev1.URL = URLWSW;

            string rutaCertificado = @"C:\GIES\certificado.crt";
            String rutaClave = @"C:\GIES\clave.key";

            if (lwsfev1.login(rutaCertificado, rutaClave, URLWSAA))
            {
                ResultadoNro = 0;
            }
            else
            {
                ResultadoNro = 1;
                ResultadoString = lwsfev1.ErrorDesc.ToString();
            }
            return lwsfev1;
        }

        public Double GetUltimoComprobante(Int32 Punto_Venta, Int32 Comprobante_tipo, out Int32 ResultadoNro, out String ResultadoString)
        {
            Double Nro = 0;
            ResultadoString = "";
            ResultadoNro = 0;

            lwsfev1.RecuperaLastCMP(Punto_Venta, Comprobante_tipo, out Nro);
            return Nro;
        }

        public Comprobante ObtenerComprobante(Int32 Punto_Venta, Int32 Comprobante_tipo, Int32 Comprobante_Numero, out Int32 ResultadoNro, out String ResultadoString)
        {
            ResultadoString = "";
            ResultadoNro = 0;
            Comprobante oComprobanteObjeto = new Comprobante();



            if (lwsfev1.CmpConsultarEx(Comprobante_tipo, Punto_Venta, Comprobante_Numero, oComprobanteObjeto))
                ResultadoString = oComprobanteObjeto.CodAutorizacion;
            else
            {
                ResultadoString = lwsfev1.ErrorDesc;
                ResultadoNro = 1;
            }
            return oComprobanteObjeto;

        }

        public Contribuyente ObtenerContribuyente(Double CuitDni, out Int32 ResultadoNro, out String ResultadoString)
        {
            ResultadoString = "";
            ResultadoNro = 0;

            OpadronAfip.CUIT = Convert.ToDouble(oConfig.GetValor_C("Cuit"));
            OpadronAfip.ModoProduccion = true;

            Contribuyente oContri = new Contribuyente();

            string rutaCertificado = @"C:\GIES\certificado.crt";
            String rutaClave = @"C:\GIES\clave.key";

            if (OpadronAfip.login(rutaCertificado, rutaClave))
            {


                if (OpadronAfip.consultar(CuitDni, oContri))
                {
                    ResultadoString = oContri.nombre;
                    ResultadoNro = 0;
                }
                else
                {
                    ResultadoString = OpadronAfip.ErrorDesc;
                    ResultadoNro = 1;
                }
            }


            return oContri;

        }

    }
}