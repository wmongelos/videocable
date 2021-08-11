using CapaDatos;
using System;
using System.Data;
namespace CapaNegocios
{
    public class Comprobantes_Tipo
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Letra { get; set; }
        public int Numeracion { get; set; }
        public int Codigo_Afip { get; set; }
        public string Presenta_Venta { get; set; }

        public enum Tipo
        {
            FACTURA_A = 1,
            FACTURA_B = 2,
            NOTA_CREDITO_A = 3,
            NOTA_CREDITO_B = 4,
            RECIBO = 5,
            REMITO = 6,
            COMPROBANTE_DEUDA = 7,
            CREDITO_A_CUENTA = 8,
            RECIBO_INTERNO = 9,
            PLAN_DE_PAGO = 10,
            RECIBO_COBRADOR = 11,
            RECIBO_COBRADOR_INTERNO = 12,
            NOTA_DEBITO_A = 13,
            NOTA_DEBITO_B = 14,
            RECIBO_AJUSTE = 15,
            FACTURA_CREDITO_ELECTRONICA_A = 16
        }

        public enum Presenta_Ventas
        {
            NO = 0,
            SI = 1
        }

        private Conexion oCon = new Conexion();

        public static Int32 Id_Login;
        public static String Name_Login;
        public static Int32 Id_Punto_Login;

        public void Guardar(Comprobantes_Tipo oTipoComprobantes)
        {
            try
            {
                oCon.Conectar();
                if (oTipoComprobantes.Id > 0)
                {
                    oCon.CrearComando("UPDATE comprobantes_tipo SET nombre=@nombre, borrado=@borrado, letra=@letra, numeracion=@numeracion, Codigo_Afip=@codigo_afip, presenta_ventas=@presenta_ventas WHERE id=@id");
                    oCon.AsignarParametroEntero("@id", oTipoComprobantes.Id);
                }
                else
                    oCon.CrearComando("INSERT INTO comprobantes_tipo (nombre,letra,numeracion,codigo_afip,presenta_ventas,borrado)" +
                       " VALUES(@nombre,@letra,@numeracion,@codigo_afip,@presenta_ventas,@borrado)");

                oCon.AsignarParametroCadena("@nombre", oTipoComprobantes.Nombre);
                oCon.AsignarParametroCadena("@letra", oTipoComprobantes.Letra);
                oCon.AsignarParametroEntero("@numeracion", oTipoComprobantes.Numeracion);
                oCon.AsignarParametroEntero("@codigo_afip", oTipoComprobantes.Codigo_Afip);
                oCon.AsignarParametroCadena("@presenta_ventas", oTipoComprobantes.Presenta_Venta);
                oCon.AsignarParametroEntero("@borrado", 0);
                oCon.ComenzarTransaccion();
                oCon.EjecutarComando();
                oCon.ConfirmarTransaccion();
                oCon.DesConectar();
            }
            catch (Exception)
            {
                oCon.CancelarTransaccion();
                oCon.DesConectar();

                throw;
            }
        }

        public DataTable Listar()
        {
            oCon.Conectar();
            oCon.CrearComando("SELECT id,concat(nombre,' ',letra) as nombre,codigo_afip,Presenta_Ventas FROM comprobantes_tipo WHERE borrado=0 ORDER BY id ASC");
            DataTable dt = oCon.Tabla();
            oCon.DesConectar();
            return dt;
        }

        public DataTable Listar_Comprobantes_Afip()
        {
            oCon.Conectar();
            oCon.CrearComando("SELECT id, CONCAT(nombre,' ', letra) as nombre,letra,codigo_afip,Presenta_Ventas FROM comprobantes_tipo WHERE Presenta_Ventas=1 and  borrado=0 ORDER BY id ASC");
            DataTable dt = oCon.Tabla();
            oCon.DesConectar();
            return dt;
        }

        public DataTable Listar_Comprobante_Afip_filtrado(int Codigo_afip)
        {
            oCon.Conectar();
            oCon.CrearComando("SELECT id, CONCAT(nombre,' ', letra) as nombre,letra,codigo_afip,Presenta_Ventas FROM comprobantes_tipo WHERE Codigo_Afip = @codAfip and  borrado=0 ORDER BY id ASC");
            oCon.AsignarParametroEntero("@codAfip", Codigo_afip);
            DataTable dt = oCon.Tabla();
            oCon.DesConectar();
            return dt;
        }

        public DataRow GetNumeracion(int idCompTipo, int idPuntoCobro)
        {
            DataRow dr;
            try
            {
                oCon.Conectar();
                oCon.CrearComando("select numero +1 as numComprobante, puntos_venta_comp.Id_Punto_Venta as idPuntoVenta, (select puntos_venta.Numero from puntos_venta where puntos_venta.id=puntos_venta_comp.Id_Punto_Venta) as numPuntoVenta from " +
                                   "(select comprobantes_habilitados.Id_Punto_Vta_Comp from comprobantes_habilitados where comprobantes_habilitados.Id_Punto_Cobro =@idPuntosCobro and comprobantes_habilitados.Predeterminado = 1 and Borrado = 0)datosIdVentaComp " +
                                   "left JOIN puntos_venta_comp on datosIdVentaComp.Id_Punto_Vta_Comp = puntos_venta_comp.Id where id_comprobantes_tipo = @idCompTipo and borrado=0 ");
                oCon.AsignarParametroEntero("@idPuntosCobro", idPuntoCobro);
                oCon.AsignarParametroEntero("@idCompTipo", idCompTipo);

                DataTable dt = oCon.Tabla();
                oCon.DesConectar();

                dr = dt.NewRow();
                if (dt.Rows.Count > 0)
                {
                    dr["numComprobante"] = dt.Rows[0]["numComprobante"];
                    dr["idPuntoVenta"] = dt.Rows[0]["idPuntoVenta"];
                    dr["numPuntoVenta"] = dt.Rows[0]["numPuntoVenta"];
                }
                else
                {
                    dr["numComprobante"] = 0;
                    dr["idPuntoVenta"] = 0;
                    dr["numPuntoVenta"] = 0;
                }
            }
            catch (Exception)
            {
                oCon.CancelarTransaccion();
                oCon.DesConectar();
                throw;
            }

            return dr;
        }

        public void SetNumeracion(int idPuntoVenta, int idTipoComp, int nro, int nroFijo = 0)
        {
            try
            {
                oCon.Conectar();
                oCon.ComenzarTransaccion();
                if (nroFijo > 0)
                {
                    oCon.CrearComando("update puntos_venta_comp set puntos_venta_comp.Numero=@num where puntos_venta_comp.Id_Punto_Venta=@idPuntoVenta and puntos_venta_comp.Id_Comprobantes_Tipo=@idTipoComp and Borrado=0");
                    oCon.AsignarParametroEntero("@num", nroFijo);
                }
                else
                {
                    oCon.CrearComando("update puntos_venta_comp set puntos_venta_comp.Numero=Numero+1 where puntos_venta_comp.Id_Punto_Venta=@idPuntoVenta and puntos_venta_comp.Id_Comprobantes_Tipo=@idTipoComp and Borrado=0");
                }

                oCon.AsignarParametroEntero("@idPuntoVenta", idPuntoVenta);
                oCon.AsignarParametroEntero("@idTipoComp", idTipoComp);
                oCon.EjecutarComando();
                oCon.ConfirmarTransaccion();
                oCon.DesConectar();
            }
            catch (Exception)
            {
                oCon.CancelarTransaccion();
                oCon.DesConectar();
                throw;
            }
        }

        public Int32 getNumeroAfip(int idComprobanteTipo)
        {
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                oCon.CrearComando("SELECT codigo_afip FROM comprobantes_tipo WHERE id=@idTipo");
                oCon.AsignarParametroEntero("@idTipo", idComprobanteTipo);
                dt = oCon.Tabla();
                oCon.DesConectar();
            }
            catch (Exception)
            {
                oCon.DesConectar();
                throw;
            }
            if (dt.Rows.Count > 0)
                return Convert.ToInt32(dt.Rows[0]["codigo_afip"]);
            else
                return 0;
        }
    }
}
