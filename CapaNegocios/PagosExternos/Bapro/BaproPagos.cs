using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocios.PagosExternos.Bapro
{
    public class BaproPagos
    {

        public List<PagoExterno> LeerTxt(string ruta)
        {
            string idDeudor;
            string dniDeudor;
            string numAgencia;
            string numTerminar;
            string fechaPago;
            string nroTransaccion;
            string importeAbonado;

            string[] lines = System.IO.File.ReadAllLines(ruta);
            Usuarios oUsuario = new Usuarios();

            foreach (string line in lines)
            {
                idDeudor = line.Substring(0, 7);
                dniDeudor = line.Substring(7, 8);
                numAgencia = line.Substring(15, 4);
                numTerminar = line.Substring(19, 4);
                fechaPago = line.Substring(23, 8);
                nroTransaccion = line.Substring(31, 15);
                importeAbonado = line.Substring(46, 30);
                PagoExterno oPago = new PagoExterno();
                string fechaAux = fechaPago.Insert(2, "/");
                string fechaCompleta = fechaAux.Insert(5, "/");
                oPago.CodigoUsuario = Convert.ToInt32(idDeudor);
                oUsuario = oUsuario.traerUsuario(0, oPago.CodigoUsuario);
                oPago.FechaPago = Convert.ToDateTime(fechaCompleta);
                oPago.FechaVencimiento = new DateTime();
                oPago.IdPago = Convert.ToInt32(nroTransaccion);
                oPago.IdPlataforma = (int)PagosExternos.PagoExterno.Plataforma.BAPROPAGOS;
                oPago.Link = string.Empty;
                oPago.Pagado = false;
                oPago.NombreUsuario = oUsuario.Apellido + ", " + oUsuario.Nombre;
                oPago.IdUsuarioCtaCte = 0;
                oPago.NombrePlataforma = "BAPRO";
                oPago.IdComprobante = 0;
                oPago.IdComprobanteTipo = 0;
                oPago.IdUsuario = oUsuario.Id;
                oPago.Borrado = 0;
                oPago.DescripcionUCC = "";
                oPago.Guardar(oPago);
            }
            return null;
        }
    

    
    }
}
