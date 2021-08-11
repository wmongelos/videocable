using CapaDatos;
using System;
using System.Data;

namespace CapaNegocios
{
    public class Formas_de_pago
    {
        public Int32 Id { get; set; }
        public String Nombre { get; set; }
        public Int32 Tipo_De_Forma { get; set; }
        public Int32 Borrado { get; set; }
        public Int32 Requiere_Presentacion { get; set; }
        public String Codigo_Empresa_Tarjeta { get; set; }
        public String Codigo_Empresa_Banco { get; set; }

        private Conexion oCon = new Conexion();

        public enum Tipos_Formas_Pagos
        {
            EFECTIVO = 1,
            TARJETA_CREDITO = 2,
            TARJETA_DEBITO = 3,
            TRANSFERENCIA = 4,
            CBU = 5,
            PLAN_DE_PAGO = 11,
            CHEQUE = 12,
            DEBITO_AUTOMATICO = 13
        }

        public enum Presentacion
        {
            NO = 0,
            SI = 1
        }


        public void Guardar(Formas_de_pago oFormas_De_Pago)
        {
            try
            {
                oCon.Conectar();

                if (oFormas_De_Pago.Id > 0)
                {
                    oCon.CrearComando("UPDATE formas_de_pago set  Nombre = @nombre,Id_Tipo_de_Forma=@tipo_de_forma, Requiere_Presentacion=@requiere_presentacion, codigo_empresa_tarjeta=@codigo_empresa_tarjeta, codigo_empresa_banco=@codigo_empresa_banco,id_personal=@personal WHERE Id = @id");
                    oCon.AsignarParametroEntero("@id", oFormas_De_Pago.Id);
                }
                else
                    oCon.CrearComando("INSERT INTO formas_de_pago(Nombre,Id_Tipo_de_Forma, Requiere_Presentacion, codigo_empresa_tarjeta, codigo_empresa_banco,id_personal) VALUES( @nombre,@tipo_de_forma, @requiere_presentacion, @codigo_empresa_tarjeta, @codigo_empresa_banco,@personal)");

                oCon.AsignarParametroEntero("@tipo_de_forma", oFormas_De_Pago.Tipo_De_Forma);
                oCon.AsignarParametroCadena("@nombre", oFormas_De_Pago.Nombre);
                oCon.AsignarParametroEntero("@requiere_presentacion", oFormas_De_Pago.Requiere_Presentacion);
                oCon.AsignarParametroCadena("@codigo_empresa_tarjeta", oFormas_De_Pago.Codigo_Empresa_Tarjeta);
                oCon.AsignarParametroCadena("@codigo_empresa_banco", oFormas_De_Pago.Codigo_Empresa_Banco);
                oCon.AsignarParametroEntero("@personal", Personal.Id_Login);
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

        public void Eliminar(int id)
        {
            try
            {
                oCon.Conectar();
                oCon.ComenzarTransaccion();
                oCon.CrearComando("UPDATE formas_de_pago SET Borrado = 1 WHERE Id = @id");
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

        public DataTable Listar()
        {
            DataTable dt = new DataTable();

            try
            {
                oCon.Conectar();
                oCon.CrearComando("SELECT formas_de_pago.id AS Id , formas_de_pago.Nombre AS Nombre, formas_de_pago_tipos.Id AS id_Tipo_De_forma,formas_de_pago.Requiere_Presentacion, " +
                    "formas_de_pago_tipos.Nombre AS Tipo_De_Forma, formas_de_pago.Codigo_Empresa_Tarjeta, " +
                    "formas_de_pago.Codigo_Empresa_Banco,formas_de_pago_tipos.Trabaja_Conciliacion, formas_de_pago_tipos.Trabaja_Validacion " +
                    "FROM formas_de_pago " +
                    "LEFT JOIN formas_de_pago_tipos ON formas_de_pago.Id_Tipo_de_Forma = formas_de_pago_tipos.Id " +
                    "WHERE formas_de_pago.Borrado = 0 " +
                    "ORDER BY ID; ");

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

        public DataTable ListarTiposFormasPagos()
        {
            DataTable dt = new DataTable();

            try
            {
                oCon.Conectar();
                oCon.CrearComando("SELECT Id,Nombre from  formas_de_pago_tipos WHERE Borrado = 0 Order By Id");

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

        public DataTable ListarFormasDePagoConPresentacion()
        {
            DataTable dt = new DataTable();

            try
            {
                oCon.Conectar();
                oCon.CrearComando(String.Format("select Id,Nombre,id_Tipo_de_Forma, requiere_presentacion, codigo_empresa_tarjeta, codigo_empresa_banco from formas_de_pago where requiere_presentacion={0}  order by Id", Convert.ToInt32(Formas_de_pago.Presentacion.SI)));
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

        public DataTable ListarPorTipodeForma(int Id_Tipo_de_Forma)
        {
            DataTable dt = new DataTable();

            try
            {
                oCon.Conectar();
                oCon.CrearComando("SELECT Id,Nombre,Id_Tipo_de_Forma, requiere_presentacion, (select Nombre from  formas_de_pago_tipos where Id=formas_de_pago.Id_Tipo_de_Forma) as Tipo_de_Forma, codigo_empresa_tarjeta, codigo_empresa_banco FROM formas_de_pago WHERE Id_Tipo_de_Forma=@id_tipo_de_forma and Borrado = 0 Order By Id");
                oCon.AsignarParametroEntero("@id_tipo_de_forma", Id_Tipo_de_Forma);
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

        public DataTable ListarPorId(int idFormaDePago)
        {
            DataTable dt = new DataTable();

            try
            {
                oCon.Conectar();
                oCon.CrearComando(String.Format("select * from formas_de_pago where id={0} and borrado=0", idFormaDePago));

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

        public DataTable ListarPorFechaDetalle(DateTime desde, DateTime hasta, string id_forma_pago)
        {
            DataTable dt = new DataTable();
            try
            {
                string filtrarFecha = string.Empty;
                string consulta = string.Empty;
                string consultaTotal = string.Empty;


                consulta = "SELECT usuarios_ctacte_recibos.id AS id_recibo,  usuarios.codigo , concat(usuarios.Apellido,', ',usuarios.Nombre) AS Usuario, localidades.Nombre AS Localidad, formas_de_pago.Nombre AS Formapago, usuarios_ctacte_recibos_det.Fecha_Comprobante ,puntos_cobros.Descripcion AS PuntoCobro, personal.Nombre AS Empleado, usuarios_ctacte_recibos_det.Importe AS Importe, usuarios_ctacte_recibos_det.cuit,usuarios_ctacte_recibos_det.Nombre AS Nombre,usuarios_ctacte_recibos_det.Banco AS Banco,usuarios_ctacte_recibos_det.Sucursal AS Sucursal, usuarios_ctacte_recibos.Id_Caja_Diaria AS CajaDiaria, usuarios_ctacte_recibos.Numero_Muestra AS NumeroMuestra, usuarios_ctacte_recibos.Fecha_movimiento AS FechaMovimiento " +
                 "FROM usuarios_ctacte_recibos_det " +
                 "LEFT JOIN formas_de_pago ON usuarios_ctacte_recibos_det.Id_Formas_de_Pago = formas_de_pago.id " +
                 "LEFT JOIN usuarios_ctacte_recibos ON usuarios_ctacte_recibos_det.id = usuarios_ctacte_recibos.id " +
                 "LEFT JOIN usuarios ON usuarios_ctacte_recibos.id_usuarios = usuarios.id " +
                 "LEFT JOIN usuarios_locaciones ON usuarios_ctacte_recibos.Id_Usuarios_Locaciones = usuarios_locaciones.Id " +
                 "LEFT JOIN localidades ON usuarios_locaciones.Id_Localidades = localidades.Id " +
                 "LEFT JOIN puntos_cobros ON usuarios_ctacte_recibos.Id_Puntos_Cobros = puntos_cobros.Id " +
                 "LEFT JOIN comprobantes ON usuarios_ctacte_recibos.Id_Comprobantes = comprobantes.Id " +
                 "LEFT JOIN personal ON usuarios_ctacte_recibos.Id_personal = personal.Id " +
                 "LEFT JOIN caja_diaria ON usuarios_ctacte_recibos.Id_Caja_Diaria = caja_diaria.id";
                filtrarFecha = "WHERE usuarios_ctacte_recibos_det.Fecha_Comprobante between @desde and @hasta and id_Formas_de_pago = @formaPago and usuarios_ctacte_recibos_det.borrado = 0";
                consultaTotal = string.Format("{0} {1}", consulta, filtrarFecha);

                oCon.CrearComando(consultaTotal);
                oCon.AsignarParametroFecha("@desde", desde);
                oCon.AsignarParametroFecha("@hasta", hasta);
                oCon.AsignarParametroCadena("@formaPago", id_forma_pago);
                dt = oCon.Tabla();
                oCon.DesConectar();
            }
            catch
            {

            }


            return dt;
        }

        public DataTable ListadoDetalladoFormaPago(Int32 id_recibo)
        {
            DataTable dt = new DataTable();

            try
            {
                oCon.Conectar();
                oCon.CrearComando("SELECT usuarios.Nombre,usuarios_ctacte.Id_Comprobantes, usuarios_ctacte.Fecha_Desde AS Desde,usuarios_ctacte.Fecha_Hasta as Hasta,usuarios_ctacte.Descripcion as Recibo,usuarios_ctacte.Importe_Bonificacion,usuarios_ctacte.Importe_Original " +
                    "FROM usuarios_ctacte_relacion " +
                    "LEFT JOIN usuarios_ctacte ON usuarios_ctacte_relacion.Id_Usuarios_ctacte = usuarios_ctacte.id " +
                    "LEFT JOIN usuarios ON usuarios_ctacte.Id_Usuarios = usuarios.id " +
                    "WHERE usuarios.borrado = 0 and usuarios_ctacte_relacion.id_usuarios_ctacte_recibos=@id_recibos ");
                oCon.AsignarParametroEntero("@id_recibos", id_recibo);
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

        public DataTable ListarFormaPago()
        {
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                oCon.CrearComando("SELECT id, Nombre " +
                    "FROM formas_de_pago " +
                    "WHERE borrado = 0; ");
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
    }
}
