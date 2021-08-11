using CapaDatos;
using System;
using System.Data;

namespace CapaNegocios
{
    public class Puntos_Cobros
    {
        private Conexion oCon = new Conexion();
        public int Id { get; set; }
        public int Punto { get; set; }
        public string Descripcion { get; set; }
        public string Tipo_Sucursal { get; set; }
        public string Tipo_Facturacion { get; set; }
        public int Numero_Recibo { get; set; }
        public int Numero_Presupuesto { get; set; }
        public int Numero_Factura_A { get; set; }
        public int Numero_Factura_B { get; set; }
        public int Numero_Cierre { get; set; }

        public static Int32 Id_User_Login;
        public static String Name_User_Login;
        public static Int32 Id_Punto;
        public static String Name_Punto;

        public void Guardar(Puntos_Cobros oPuntos_Cobros)
        {
            try
            {
                oCon.Conectar();
                if (oPuntos_Cobros.Id > 0)
                {
                    oCon.CrearComando("UPDATE puntos_cobros SET Descripcion=@descripcion, Punto=@punto, Numero_Factura_a=@numero_factura_a,Numero_Factura_b=@numero_factura_b, Tipo_Sucursal=@tipo_sucursal, Tipo_Facturacion=@tipo_facturacion,Borrado=@Borrado,id_personal=@personal WHERE id=@id; SELECT @@IDENTITY");
                    oCon.AsignarParametroEntero("@id", oPuntos_Cobros.Id);
                }
                else
                    oCon.CrearComando("INSERT INTO puntos_cobros (Descripcion,Punto,Numero_Factura_a,Numero_Factura_b,Tipo_Sucursal,Tipo_Facturacion,Borrado,id_personal) " +
                        "VALUES (@descripcion,@punto,@numero_factura_a,@numero_factura_b,@tipo_sucursal,@tipo_facturacion,@Borrado,@personal); SELECT @@IDENTITY");

                oCon.AsignarParametroCadena("@descripcion", oPuntos_Cobros.Descripcion);
                oCon.AsignarParametroEntero("@punto", oPuntos_Cobros.Punto);
                oCon.AsignarParametroEntero("@numero_factura_a", oPuntos_Cobros.Numero_Factura_A);
                oCon.AsignarParametroEntero("@numero_factura_b", oPuntos_Cobros.Numero_Factura_B);
                oCon.AsignarParametroCadena("@tipo_sucursal", oPuntos_Cobros.Tipo_Sucursal);
                oCon.AsignarParametroCadena("@tipo_facturacion", oPuntos_Cobros.Tipo_Facturacion);
                oCon.AsignarParametroEntero("@Borrado", 0);
                oCon.AsignarParametroEntero("@personal", Personal.Id_Login);
                oCon.ComenzarTransaccion();
                oPuntos_Cobros.Id = oCon.EjecutarScalar();
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
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                oCon.CrearComando("SELECT Id,Descripcion,punto,numero_factura_a,numero_factura_b,tipo_facturacion,tipo_sucursal FROM puntos_cobros WHERE Borrado=0 ORDER BY Descripcion");
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
        public DataTable ListarPorTipoSucursal(string tipo)
        {
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                oCon.CrearComando("SELECT id,descripcion,punto,numero_factura_a,numero_factura_b,tipo_facturacion,tipo_sucursal FROM puntos_cobros WHERE tipo_sucursal=@tipo_sucursal1 and Borrado=0 ORDER BY Id");
                oCon.AsignarParametroCadena("@tipo_sucursal1", tipo);
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
        public void Eliminar(int id)
        {
            try
            {
                oCon.Conectar();
                oCon.ComenzarTransaccion();
                oCon.CrearComando("UPDATE puntos_cobros SET Borrado = 1 WHERE Id = @id");
                oCon.AsignarParametroEntero("@id", id);
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

        public DataTable Listar_Cobradores_Consulta_Pagos(Int32 id_cobrador, Int32 tipo_comprobante)
        {
            string Comando = string.Empty;
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                Comando = "SELECT  usuarios_ctacte_recibos.id as id_Recibo_ref,puntos_cobros.id,puntos_cobros.descripcion,puntos_cobros.tipo_sucursal "
                + ", usuarios_ctacte_recibos.numero,usuarios_ctacte_recibos.id_caja_diaria as id_caja, usuarios_ctacte_recibos.numero_hata, importe_recibo, importe_ajuste,importe_Rendido, importe_saldo,usuarios_ctacte_recibos.id_comprobantes,usuarios_ctacte_recibos.id as idusuariosctacterecibos,usuarios_ctacte_recibos.fecha_movimiento"
                + " FROM puntos_cobros"
                + " inner join usuarios_ctacte_recibos on id_cobrador = puntos_cobros.id"
                + " inner join comprobantes on comprobantes.Id=usuarios_ctacte_recibos.id_comprobantes and comprobantes.Id_comprobantes_tipo=@tipo_comprobante"
                + " WHERE puntos_cobros.id=@id and puntos_cobros.Borrado = 0";

                oCon.CrearComando(String.Format("{0}", Comando));
                oCon.AsignarParametroEntero("@id", id_cobrador);
                oCon.AsignarParametroEntero("@tipo_comprobante", tipo_comprobante);
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
        public DataTable Listar_Cobradores_Consulta_Pagos_Detalle(Int32 id_recibo_referencia)
        {
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                oCon.CrearComando("SELECT usuarios.id AS id_usu,usuarios_ctacte_recibos.id AS id_recibo, " +
                    "usuarios.Codigo AS CodUsu, CONCAT(usuarios.Apellido, ' , ', usuarios.Nombre) AS Usuario, " +
                    "usuarios_ctacte_recibos.Numero_Muestra AS Recibo, usuarios_ctacte_recibos.Importe_Recibo AS Importe " +
                    "FROM usuarios_ctacte_recibos " +
                    "LEFT JOIN usuarios ON usuarios_ctacte_recibos.Id_Usuarios = usuarios.id " +
                    "WHERE id_referencia = @idRef; ");
                oCon.AsignarParametroEntero("@idRef", id_recibo_referencia);
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

        public DataTable PuntoDatos(int idpunto)
        {
            DataTable dt = new DataTable();

            try
            {
                oCon.Conectar();
                oCon.CrearComando("SELECT descripcion,punto,numero_recibo,numero_presupuesto,numero_factura_a,numero_factura_b,tipo_sucursal,numero_cierre,tipo_facturacion from puntos_cobros where id=@id");
                oCon.AsignarParametroEntero("@id", idpunto);
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

        public Int32 ActualizarSaldoCobrador(int idComprobante, decimal rendido)
        {
            DataTable dt = new DataTable();
            decimal rendidoViejo = 0, rendidoNuevo = 0;
            try
            {
                oCon.Conectar();

                oCon.CrearComando("select importe_rendido from usuarios_ctacte_recibos where id_comprobantes=@comprobante");
                oCon.AsignarParametroEntero("@comprobante", idComprobante);
                dt = oCon.Tabla();
                rendidoViejo = Convert.ToDecimal(dt.Rows[0][0]);
                rendidoNuevo = rendidoViejo + rendido;

                oCon.CrearComando("update usuarios_ctacte_recibos set importe_rendido=@rendido where id_comprobantes=@comprobante");
                oCon.AsignarParametroEntero("@comprobante", idComprobante);
                oCon.AsignarParametroDecimal("@rendido", rendidoNuevo);
                oCon.ComenzarTransaccion();
                oCon.EjecutarComando();
                oCon.ConfirmarTransaccion();
                oCon.DesConectar();
                return 0;
            }
            catch (Exception)
            {
                oCon.CancelarTransaccion();
                oCon.DesConectar();
                throw;
                return -1;
            }
        }
    }
}

