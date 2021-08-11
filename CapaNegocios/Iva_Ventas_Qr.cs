using CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaNegocios
{
    public class Iva_Ventas_Qr
    {
        public int Id { get; set; }
        public int Id_Iva_Ventas { get; set; }
        public string Texto { get; set; }

        private Conexion oCon = new Conexion();

        public void Guardar(Iva_Ventas_Qr oIvaVentasQr)
        {
            try
            {
                oCon.Conectar();

                oCon.CrearComando("INSERT INTO iva_ventas_qr(Id_Iva_Ventas, Texto) VALUES (@idIvaVentas, @texto)");

                oCon.AsignarParametroEntero("@idIvaVentas", oIvaVentasQr.Id_Iva_Ventas);
                oCon.AsignarParametroCadena("@texto", oIvaVentasQr.Texto);

                oCon.ComenzarTransaccion();
                oCon.EjecutarComando();
                oCon.ConfirmarTransaccion();
                oCon.DesConectar();
            }
            catch (Exception)
            {
                oCon.CancelarTransaccion();
                oCon.DesConectar();
            }
        }
    }
}
